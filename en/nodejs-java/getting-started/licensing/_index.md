---
title: Licensing
type: docs
weight: 80
url: /nodejs-java/licensing/
keywords:
- license
- temporary license
- set license
- use license
- validate license
- license file
- evaluation version
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Apply, manage, and troubleshoot licenses in Aspose.Slides for Node.js. Ensure uninterrupted access to full features with our step-by-step licensing guide."
---

## **Introduction**

Sometimes, for the best evaluation outcomes, a hands-on approach might be needed. For this reason, Aspose.Slides provides different purchase plans and also offers a Free Trial and a 30-day Temporary License for evaluation.

{{% alert color="info" title="Note" %}}

Note that there are a number of general policies and practices that guide you on how to evaluate, properly license, and purchase our products. You can find them in the ["Purchase Policies and FAQ"](https://purchase.aspose.com/policies) section.

{{% /alert %}}

## **Evaluate Aspose.Slides**
You can easily download Aspose.Slides for evaluation. The evaluation package is the same as the purchased package. The evaluation version simply becomes licensed after you add a few lines of code to apply the license. 

## **Evaluation Version Limitation**
The evaluation version of Aspose.Slides (without a license specified) provides the full product functionality, with two limitations:

* It adds an evaluation watermark text box to every slide of each presentation it saves.
* Text longer than five characters that your code reads from a presentation is cut to its first five characters, followed by `... text has been truncated due to evaluation version limitation.` Text of five characters or fewer is returned unchanged, and text that your code writes is saved in full.

{{% alert color="info" title="Note" %}}

If you want to test Aspose.Slides without the evaluation version limitations, you can request a **30 Day Temporary License**. Please refer to [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) for more information.

{{% /alert %}}

## **About the License**
You can easily download an evaluation version of Aspose.Slides for Node.js via Java from its [download page](https://releases.aspose.com/slides/nodejs-java/). The evaluation version has the same features as the licensed version, with the limitations described above. Furthermore, the evaluation version simply becomes licensed after you purchase a license and add a couple of lines of code to apply the license.

The license is a plain-text XML file that contains details such as the product name, number of developers it is licensed to, subscription expiry date, and so on. The file is digitally signed, so do not modify the file. Even an inadvertent addition of an extra line break to the contents of the file will invalidate it.

To avoid the limitations associated with the evaluation version, you need to set a license before using **Aspose.Slides**. You are only required to set a license once per application or process.

{{% alert color="info" title="Note" %}}

You may want to see [Metered Licensing](/slides/nodejs-java/metered-licensing/).

{{% /alert %}}

## **Purchased License**

After purchase, you need to apply the license file or stream. 

{{% alert color="info" title="Note" %}}

You need to set the license:
* only once per process
* before using any other Aspose.Slides classes

{{% /alert %}}

{{% alert color="info" title="Note" %}}

You can find pricing information on the [“Pricing Information”](https://purchase.aspose.com/pricing/slides/family) page.

{{% /alert %}}

### **Setting a License in Aspose.Slides for Node.js via Java**

Licenses can be applied from these locations:

* Explicit path
* Stream
* As a Metered License – a new licensing mechanism

{{% alert color="info" title="Note" %}}

Use the **setLicense** method to license a component.

While multiple calls to **setLicense** aren't harmful, they are a waste of resources (processor).

{{% /alert %}}

#### **Applying a License Using a File**

This code snippet is used to set a license file:

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");

const license = new asposeSlides.License();
license.setLicense("Aspose.Slides.lic");
console.log("The license was applied.");

// Aspose.Slides runs in a Java virtual machine that keeps Node.js running, so end the process explicitly.
process.exit(0);
```

When calling the setLicense method, the license name should be the same as that of your license file. For example, you can change the license file name to "Aspose.Slides.lic.xml". Then, in your code, you have to pass the new license name (Aspose.Slides.lic.xml) to the setLicense method. If the file is missing or does not contain a valid license, [setLicense](https://reference.aspose.com/slides/nodejs-java/aspose.slides/license/setlicense/) throws an exception, which ends the script with an error.

#### **Applying a License from a Stream**

To apply a license from a stream, pass the [License](https://reference.aspose.com/slides/nodejs-java/aspose.slides/license/) object and a readable stream to the static [setLicenseFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/license/setlicense/) method. The stream is read asynchronously, and the callback receives an error if the stream does not contain a valid license:

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");

const license = new asposeSlides.License();
const readStream = fs.createReadStream("Aspose.Slides.lic");
asposeSlides.License.setLicenseFromStream(license, readStream, function (error) {
    if (error) {
        console.error("The license was not applied:", error.message);
    } else {
        console.log("The license was applied.");
    }

    // Aspose.Slides runs in a Java virtual machine that keeps Node.js running, so end the process explicitly.
    process.exit(0);
});
```

The license is applied when the whole stream has been read, just before the callback runs, so start other Aspose.Slides work from the callback.

Both samples call `process.exit(0)` when they finish, because the Java virtual machine that runs Aspose.Slides keeps Node.js running. In an application, continue with your Aspose.Slides code instead of ending the process.

## **FAQ**

### Can I apply the license in a completely offline environment (no internet access)?

Yes. License validation is performed locally using the license file; no internet connection is required.

### What happens after the one-year subscription expires? Will the library stop working?

No. The license is perpetual: you can continue using versions released before your subscription end date; you just won’t be eligible to use newer releases without renewing.
