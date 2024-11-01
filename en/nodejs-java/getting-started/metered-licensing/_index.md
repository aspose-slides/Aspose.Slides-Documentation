---
title: Metered Licensing
type: docs
weight: 100
url: /nodejs-java/metered-licensing/
keywords:
- license
- metered licensing
- Node.js
- Java
- Aspose.Slides for Node.js via Java
---

{{% alert color="primary" %}} 

Metered licensing is a new licensing mechanism that can be used alongside existing licensing methods. If you want to be billed based on your usage of Aspose.Slides API features, you choose metered licensing.

When you purchase a metered license, you get keys (and not a license file). This metered key can be applied using the [Metered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) class Aspose provided for metering operations. For more details, see [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Create an instance of the [Metered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) class.

1. Pass your public and private keys to the [setMeteredKey](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/#setMeteredKey) method.

1. Do some processing (perform tasks).

1. Call the [getConsumptionQuantity](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/#getConsumptionQuantity) method of the `Metered` class.

You should see the amount/quantity of API requests you have consumed so far.

This sample code shows you how to use metered licensing:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Creates an instance of the Metered class
var metered = new asposeSlides.Metered();

// Passes the public and private keys to the Metered object
metered.setMeteredKey("<valid public key>", "<valid private key>");

// Gets the consumed quantity value before API calls
var amountBefore = asposeSlides.Metered.getConsumptionQuantity();
console.log("Amount consumed before:", amountBefore);

// Do something with Aspose.Slides API here
// ...

// Gets the consumed quantity value after API calls
var amountAfter = asposeSlides.Metered.getConsumptionQuantity();
console.log("Amount consumed after:", amountAfter);
```

{{% alert color="warning" title="NOTE"  %}} 

To use metered licensing, you need a stable internet connection because the licensing mechanism uses the internet to constantly interact with our services and perform calculations.

{{% /alert %}} 
