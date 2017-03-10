
object SuperNumber
{
	def main(args: Array[String])
	{
		val start=System.nanoTime()
		
		for(j<-2 to 9)
		{
			var superNumbers=new Array[Int](j)
			val possibilityCount : Int=math.pow(j,j).toInt
			for(i<-0 until possibilityCount-1)
			{
				incrementArray(superNumbers,superNumbers.length-1)
				if(isSuperNumber(superNumbers))
				{
					superNumbers.foreach(print)
					println
				}
			}
		}
		val endTime :Double=System.nanoTime().toDouble
		val seconds :Double = (endTime-start) / 1000000000.0d

		println("Total Seconds:"+seconds)
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
	def isSuperNumber(superNumbers :Array[Int]) : Boolean  =	{
		var count:Int=0
		val digitCount=superNumbers.length
		for(index<-0 until digitCount)
		{
			count=0
			superNumbers.foreach((digit)=>{
				if (digit == index)
					count=count+1
			})
			
			if(count!=superNumbers(index))
				return false
		}
		return true
	}
	
}