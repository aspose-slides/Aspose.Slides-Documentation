---
title: Metered Licensing
type: docs
weight: 90
url: /net/metered-licensing/
---

{{% alert color="primary" %}} 

Aspose.Slides allows developers to apply metered keys. It is a new licensing mechanism. The new licensing mechanism can be used alongside existing licensing methods. If you prefer to be billed based on your usage API features, you can use the metered licensing. For more details, please refer to [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) section.

{{% /alert %}} 
## **Metered Licensing**
To use the Metered class, do this:

1. Create an instance of Metered class.
1. Pass public & private keys to SetMeteredKey method.
1. Do some processing (perform tasks).
1. Call the GetConsumptionQuantity method of the Metered class.

   You should see the amount/quantity of API requests you have consumed so far.

This sample code shows you how to set metered public and private keys:

```c#
 // Create an instance of CAD Metered class
            Aspose.Slides.Metered metered = new Aspose.Slides.Metered();

            // Access the setMeteredKey property and pass public and private keys as parameters
            metered.SetMeteredKey("*****", "*****");

            // Get metered data amount before calling API
            decimal amountbefore = Aspose.Slides.Metered.GetConsumptionQuantity();

            // Display information
            Console.WriteLine("Amount Consumed Before: " + amountbefore.ToString());
            // Get metered data amount After calling API
            decimal amountafter = Aspose.Slides.Metered.GetConsumptionQuantity();

            // Display information
            Console.WriteLine("Amount Consumed After: " + amountafter.ToString());
```

