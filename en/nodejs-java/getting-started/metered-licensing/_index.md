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

## **Apply Metered Keys**

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
var metered = new aspose.slides.Metered();

// Passes the public and private keys to the Metered object
metered.setMeteredKey("<valid public key>", "<valid private key>");

// Gets the consumed quantity value before API calls
var amountBefore = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed before:", amountBefore);

// Do something with Aspose.Slides API here
// ...

// Gets the consumed quantity value after API calls
var amountAfter = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed after:", amountAfter);
```

{{% alert color="warning" title="NOTE"  %}} 

To use metered licensing, you need a stable internet connection because the licensing mechanism uses the internet to constantly interact with our services and perform calculations.

{{% /alert %}} 

## **FAQ**

**Can I use a metered license together with a regular one (perpetual or temporary) in the same application?**

Yes. Metered is an additional licensing mechanism that can be used alongside existing [licensing methods](/slides/nodejs-java/licensing/). You choose which mechanism to apply when the application starts.

**What exactly counts as consumption under a metered license: operations or files?**

API usage is counted, meaning the number of requests or operations. You can obtain the current consumption via [consumption-tracking methods](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/).

**Is metered suitable for microservices and serverless environments where instances restart frequently?**

Yes. Since accounting is done at the API-call level, scenarios with frequent cold starts are compatible, provided there is stable network access for metered calculations.

**Does the library’s functionality differ when using a metered license compared to a perpetual license?**

No. This is only about the licensing and billing mechanism; the product’s capabilities are the same.

**How does metered relate to the trial version and the temporary license?**

The trial version has limitations and watermarks, the [temporary license](https://purchase.aspose.com/temporary-license/) removes limitations for 30 days, and metered removes limitations and charges based on actual usage.

**Can I control the budget by automatically reacting when a consumption threshold is exceeded?**

Yes. A common practice is to periodically read current consumption via [tracking methods](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) and implement your own limits or alerts at the application or monitoring level.
