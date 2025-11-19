---
title: Metered Licensing
type: docs
weight: 90
url: /python-net/metered-licensing/
keywords:
- license
- metered license
- license keys
- public key
- private key
- consumption quantity
- Python
- Aspose.Slides
description: "Learn how Aspose.Slides for Python via .NET metered licensing lets you process PowerPoint and OpenDocument files flexibly, paying only for what you use."
---

## **Apply Metered Keys**

{{% alert color="primary" %}} 

Metered licensing is a new licensing mechanism that can be used alongside existing licensing methods. If you want to be billed based on your usage of Aspose.Slides API features, you choose metered licensing.

When you purchase a metered license, you get keys (and not a license file). This metered key can be applied using the [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) class Aspose provided for metering operations. For more details, see [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Create an instance the [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) class.
1. Pass your public and private keys to the [set_metered_key](https://reference.aspose.com/slides/python-net/aspose.slides/metered/set_metered_key/#str-str) method.
1. Do some processing (perform tasks).
1. Call the [get_consumption_quantity](https://reference.aspose.com/slides/python-net/aspose.slides/metered/get_consumption_quantity/#) method of the `Metered` class.

You should see the amount/quantity of API requests you have consumed so far.

This sample code shows you how to use metered licensing:

```python
import aspose.slides as slides

# Creates an instance of the Metered class
metered = slides.Metered()

# Passes the public and private keys to the Metered object
metered.set_metered_key("<valid public key>", "<valid private key>")

# Gets the consumed quantity value before API calls
amount_before = slides.Metered.get_consumption_quantity()
print("Amount consumed before:", amount_before)

# Do something with Aspose.Slides API here
# ...

# Gets the consumed quantity value after API calls
amount_after = slides.Metered.get_consumption_quantity()
print("Amount consumed after:", amount_after)
```

{{% alert color="warning" title="NOTE"  %}} 

To use metered licensing, you need a stable internet connection because the licensing mechanism uses the internet to constantly interact with our services and perform calculations.

{{% /alert %}} 

## **FAQ**

**Can I use a metered license together with a regular one (perpetual or temporary) in the same application?**

Yes. Metered is an additional licensing mechanism that can be used alongside existing [licensing methods](/slides/python-net/licensing/). You choose which mechanism to apply when the application starts.

**What exactly counts as consumption under a metered license: operations or files?**

API usage is counted, meaning the number of requests or operations. You can obtain the current consumption via [consumption-tracking methods](https://reference.aspose.com/slides/python-net/aspose.slides/metered/).

**Is metered suitable for microservices and serverless environments where instances restart frequently?**

Yes. Since accounting is done at the API-call level, scenarios with frequent cold starts are compatible, provided there is stable network access for metered calculations.

**Does the library’s functionality differ when using a metered license compared to a perpetual license?**

No. This is only about the licensing and billing mechanism; the product’s capabilities are the same.

**How does metered relate to the trial version and the temporary license?**

The trial version has limitations and watermarks, the [temporary license](https://purchase.aspose.com/temporary-license/) removes limitations for 30 days, and metered removes limitations and charges based on actual usage.

**Can I control the budget by automatically reacting when a consumption threshold is exceeded?**

Yes. A common practice is to periodically read current consumption via [tracking methods](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) and implement your own limits or alerts at the application or monitoring level.
