
object NumberPossibilities
{
	def main(args: Array[String])
	{
		val start=System.nanoTime()
		//digit count starts from 0.
		val digitCount:Int=9
		var superNumbers=new Array[Int](digitCount)
		val possibilityCount : Int=math.pow(digitCount,digitCount).toInt
		for(i<-0 until possibilityCount-1)
		{
			incrementArray(superNumbers,superNumbers.length-1)
		}
		print("Max Digits:");
		superNumbers.foreach(print)
	
		val endTime :Double=System.nanoTime().toDouble
		val seconds :Double = (endTime-start) / 1000000000.0d

		println("\nTotal Seconds:"+seconds)
	}

	def incrementArray(possibilities: Array[Int],digitIndex:Int)
	{
		var tmp:Int=0
		var digitCount:Int = possibilities.length
		tmp=possibilities(digitIndex)+1
		if(tmp%digitCount==0)
		{
			possibilities(digitIndex)=0
			incrementArray(possibilities,digitIndex-1)
		}
		else
			possibilities(digitIndex)=tmp
	}
}