---
title: Metered Licensing
type: docs
weight: 90
url: /python-net/metered-licensing/
---

{{% alert color="primary" %}} 

Metered licensing is a new licensing mechanism that can be used alongside existing licensing methods. If you want to be billed based on your usage of Aspose.Slides API features, you choose metered licensing.

When you purchase a metered license, you get keys (and not a license file). This metered key can be applied using the [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) class Aspose provided for metering operations. For more details, see [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Create an instance the [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) class.
1. Pass your public and private keys to the `set_metered_key` method.
1. Do some processing (perform tasks).
1. Call the `get_consumption_quantity()` method of the Metered class.

   You should see the amount/quantity of API requests you have consumed so far.

This Python code shows you how to set metered public and private keys:

```python
import aspose.slides as slides

# Creates an instance of CAD Metered class
metered = slides.Metered()

# Accesses the set_metered_key property and pass public and private keys as parameters
metered.set_metered_key("*****", "*****")

# Gets the metered data amount before calling API
amountbefore = slides.metered.get_consumption_quantity()
# Display information
print("Amount Consumed Before: " + str(amountbefore))

# Loads the document from disk.
with slides.Presentation("Presentation.pptx") as pres:
   #Gets the page count of document
   print(len(pres.slides))
   # Saves as PDF
   pres.save("out_pdf.pdf", slides.export.SaveFormat.PDF)

# Gets the metered data amount After calling API
amountafter = slides.metered.get_consumption_quantity()
# Displays information
print("Amount Consumed After: " + str(amountafter))
```

{{% alert color="warning" title="NOTE"  %}} 

To use metered licensing, you need a stable internet connection because the licensing mechanism uses the internet to constantly interact with our services and perform calculations.

{{% /alert %}} 
