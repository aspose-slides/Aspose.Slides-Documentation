---
title: Metered Licensing
type: docs
weight: 90
url: /net/metered-licensing/
keywords:
- license
- metered licensing
- C#
- Aspose.Slides for .NET
---

{{% alert color="primary" %}} 

Metered licensing is a new licensing mechanism that can be used alongside existing licensing methods. If you want to be billed based on your usage of Aspose.Slides API features, you choose metered licensing.

When you purchase a metered license, you get keys (and not a license file). This metered key can be applied using the [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/) class Aspose provided for metering operations. For more details, see [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Create an instance of the [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/) class.
1. Pass your public and private keys to the [SetMeteredKey](https://reference.aspose.com/slides/net/aspose.slides/metered/setmeteredkey/) method.
1. Do some processing (perform tasks).
1. Call the [GetConsumptionQuantity](https://reference.aspose.com/slides/net/aspose.slides/metered/getconsumptionquantity/) method of the `Metered` class.

You should see the amount/quantity of API requests you have consumed so far.

This sample code shows you how to use metered licensing:

```cs
// Creates an instance of the Metered class
Aspose.Slides.Metered metered = new Aspose.Slides.Metered();

// Passes the public and private keys to the Metered object
metered.SetMeteredKey("<valid public key>", "<valid private key>");

// Gets the metered data quantity before API call
decimal amountBefore = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed before: " + amountBefore.ToString());

// Do something with Aspose.Slides API here
// ...

// Gets the metered data amount after API call
decimal amountAfter = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed after: " + amountAfter.ToString());
```

{{% alert color="warning" title="NOTE"  %}} 

To use metered licensing, you need a stable internet connection because the licensing mechanism uses the internet to constantly interact with our services and perform calculations.

{{% /alert %}} 
