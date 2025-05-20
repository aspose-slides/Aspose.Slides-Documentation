---
title: Licensing
description: "Aspose.Slides for Python via Java provides different plans for purchase or offers a Free Trial and a 30-day Temporary License for evaluation using Licensing and Subscription policies."
type: docs
weight: 80
url: /python-java/licensing/
---

Sometimes, for the best evaluation outcomes, a hands-on approach might be needed. For this reason, Aspose.Slides provides different purchase plans and also offers a Free Trial and a 30-day Temporary License for evaluation.

{{% alert color="primary" %}}

Note that there are a number of general policies and practices that guide you on how to evaluate, properly license, and purchase our products. You can find them in the ["Purchase Policies and FAQ"](https://purchase.aspose.com/policies) section.

{{% /alert %}}

## **Evaluate Aspose.Slides**
You can easily download Aspose.Slides for evaluation. The evaluation package is the same as the purchased package. The evaluation version simply becomes licensed after you add a few lines of code to apply the license. 

## **Evaluation Version Limitation**
The evaluation version of Aspose.Slides (without a license specified) provides the full product functionality, but it inserts an evaluation watermark at the top of the document on open and save. You are also limited to one slide when extracting texts from presentation slides.

{{% alert color="primary" %}} 

If you want to test Aspose.Slides without the evaluation version limitations, you can request a **30 Day Temporary License**. Please refer to [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) for more information.

{{% /alert %}} 

## **About the License**
You can easily download an evaluation version of Aspose.Slides for Python via Java from its [download page](https://releases.aspose.com/slides/python-java/). The evaluation version provides absolutely **the same capabilities** as the licensed version of Aspose.Slides. Furthermore, the evaluation version simply becomes licensed after you purchase a license and add a couple of lines of code to apply the license.

The license is a plain-text XML file that contains details such as the product name, number of developers it is licensed to, subscription expiry date, and so on. The file is digitally signed, so do not modify the file. Even an inadvertent addition of an extra line break to the contents of the file will invalidate it.

To avoid the limitations associated with the evaluation version, you need to set a license before using **Aspose.Slides**. You are only required to set a license once per application or process.

## Purchased License

After purchase, you need to apply the license file or stream. 

{{% alert color="primary" %}}

You need to set the license:
* only once per application domain
* before using any other Aspose.Slides classes

{{% /alert %}}

{{% alert color="primary" %}}

You can find pricing information on the [“Pricing Information”](https://purchase.aspose.com/pricing/slides/family) page.

{{% /alert %}}

### **Setting a License in Aspose.Slides for Python via Java**

Licenses can be applied from these locations:

* Explicit path
* Stream
* As a Metered License – a new licensing mechanism

{{% alert color="primary" %}}

Use the **setLicense** method to license a component.

While multiple calls to **setLicense** aren't harmful, they are a waste of resources (processor).

{{% /alert %}}

{{% alert color="warning" %}}

New licenses can activate Aspose.Slides only with version 21.4 or later. Earlier versions use a different licensing system and will not recognize these licenses.

{{% /alert %}}

#### **Applying a License Using a File**

This code snippet is used to set a license file:

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
pres = Presentation()
license.setLicense("Aspose.Slides.lic");

jpype.shutdownJVM()
```

When calling the setLicense method, the license name should be same as that of your license file. For example, you can change the license file name to "Aspose.Slides.lic.xml". Then, in your code, you have to pass the new license name (Aspose.Slides.lic.xml) to the setLicense method.

#### **Applying a License from a Bytes**

This code snippet is used to apply a license from a bytes:

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
input = open("Aspose.Slides.lic", mode="rb")
data = input.read()
pres = Presentation()
license.setLicenseFromBytes(data);

jpype.shutdownJVM()
```

#### Apply Metered License

Aspose.Slides allows developers to apply a metered key. This is a new licensing mechanism.

The new licensing mechanism will be used along with the existing licensing method. Those customers who want to be billed based on the use of API features can use the Metered Licensing.

After completing all the necessary steps to obtain this type of license, you will receive the keys, not the license file. This metered key can be applied using the **Metered** class specially introduced for this purpose.

The following code example shows how to set metered public and private keys:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, Metered, SaveFormat

# Create an instance of CAD Metered class
metered = Metered();

# Access the set_metered_key property and pass public and private keys as parameters
metered.setMeteredKey("*****", "*****");

# Get metered data amount before calling API
amountbefore = Metered.getConsumptionQuantity()

# Display information
print("Amount Consumed Before: \" + amountbefore + \"" )

# Load the document from disk.
pres = Presentation();

# Get the page count of document
print("Amount Consumed After: \" +  pres.getSlides().size()) + \"" )

# save as PDF
pres.save("out_pdf.pdf", SaveFormat.Pdf);

# Get metered data amount After calling API
amountafter = Metered.getConsumptionQuantity()

# Display information
print("Amount Consumed After: \" + amountafter + \"" )

jpype.shutdownJVM()
```

{{% alert color="primary" %}}

Please note that you must have a stable Internet connection for the correct use of the Metered license, since the Metered mechanism requires the constant interaction with our services for correct calculations. For more details, refer to the [“Metered Licensing FAQ”](https://purchase.aspose.com/faqs/licensing/metered) section.

{{% /alert %}}
