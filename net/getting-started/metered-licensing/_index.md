---
title: Metered Licensing
type: docs
weight: 90
url: /net/metered-licensing/
---

{{% alert color="primary" %}} 

Metered licensing is a new licensing mechanism that can be used alongside existing licensing methods. When you purchase a metered license, you get keys (and not a license file).

If you want to be billed based on your usage of Aspose.Slides API features, you may want to choose metered licensing. For more details, see [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

Aspose provides the [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/) class for metered licensing operations.

1. Create an instance of the [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/) class.
1. Pass your public and private keys to the [SetMeteredKey](https://reference.aspose.com/slides/net/aspose.slides/metered/setmeteredkey/) method.
1. Do some processing (perform tasks).
1. Call the [GetConsumptionQuantity](https://reference.aspose.com/slides/net/aspose.slides/metered/getconsumptionquantity/) method of the Metered class.

   You should see the amount/quantity of API requests you have consumed so far.

This C# code shows you how to set metered public and private keys:

```c#
//  Creates an instance of the Metered class
	Aspose.Slides.Metered metered = new Aspose.Slides.Metered();

//  Accesses the SetMeteredKey property and passes the public and private keys as parameters
	metered.SetMeteredKey("*****", "*****");

//  Gets the metered data quantity before API call
	decimal amountbefore = Aspose.Slides.Metered.GetConsumptionQuantity();

//  Displays the information
	Console.WriteLine("Amount Consumed Before: " + amountbefore.ToString());

//  Gets the metered data amount after API call
	decimal amountafter = Aspose.Slides.Metered.GetConsumptionQuantity();

//  Displays the information
	Console.WriteLine("Amount Consumed After: " + amountafter.ToString());
```

{{% alert color="warning" title="NOTE"  %}} 

To use metered licensing, you need a stable internet connection because the licensing mechanism uses the internet to constantly interact with our services and perform calculations.

{{% /alert %}} 
