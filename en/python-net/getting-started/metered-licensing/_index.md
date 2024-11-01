---
title: Metered Licensing
type: docs
weight: 90
url: /python-net/metered-licensing/
keywords:
- license
- metered licensing
- Python
- .NET
- Aspose.Slides for Python via .NET
---

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
metered.set_metered_key("<valid pablic key>", "<valid private key>")

# Gets the consumed quantity value before API calls
amount_before = slides.metered.get_consumption_quantity()
print("Amount consumed before:", amount_before)

# Do something with Aspose.Slides API here
# ...

# Gets the consumed quantity value after API calls
amount_after = slides.metered.get_consumption_quantity()
print("Amount consumed after:", amount_after)
```

{{% alert color="warning" title="NOTE"  %}} 

To use metered licensing, you need a stable internet connection because the licensing mechanism uses the internet to constantly interact with our services and perform calculations.

{{% /alert %}} 
