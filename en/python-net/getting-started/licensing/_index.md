---
title: Licensing
type: docs
weight: 80
url: /python-net/licensing/
keywords:
- license
- temporary license
- set license
- use license
- validate license
- license file
- evaluation version
- Python
- Aspose.Slides
description: "Learn how to apply, manage, and troubleshoot licenses in Aspose.Slides for Python via .NET. Ensure uninterrupted access to full features with our step-by-step licensing guide."
---

## **Overview**

Aspose.Slides can be used in evaluation mode or with a valid license. The evaluation version provides the same functionality as the licensed version, but it adds an evaluation watermark to every slide of each presentation it saves and truncates text that your code reads from presentations.

## **Evaluate Aspose.Slides**

You can download an evaluation version of **Aspose.Slides for Python via .NET** from its [download page](https://pypi.org/project/Aspose.Slides/). The evaluation version provides the same features as the licensed product. The evaluation package is identical to the purchased package and becomes licensed after you add a few lines of code to apply the license.

When you’re satisfied with your evaluation of **Aspose.Slides**, you can [purchase a license](https://purchase.aspose.com/pricing/slides/python-net/). We recommend reviewing the available subscription options. If you have questions, contact the Aspose sales team.

Every Aspose license includes a one-year subscription with free upgrades to new versions and fixes released during that period. Both licensed and evaluation users receive free, unlimited technical support.

**Limitations of the Evaluation Version**

* The evaluation version (when no license is applied) provides full functionality, but it adds an evaluation watermark text box to every slide of each presentation it saves.
* Text that your code reads from a presentation is truncated to its first few characters, followed by a notice about the evaluation limitation. Text that your code writes is saved in full.

{{% alert color="info" title="Note" %}}

To test Aspose.Slides without limitations, you can request a **30-day Temporary License**. See the [How to Get a Temporary License](https://purchase.aspose.com/temporary-license) page for details.

{{% /alert %}}

## **Licensing in Aspose.Slides**

* An evaluation version becomes licensed after you purchase a license and add a couple of lines of code to apply it.
* The license is a plain-text XML file that contains details such as the product name, the number of developers it covers, the subscription expiry date, and so on.
* The license file is digitally signed, so you must not modify it. Even adding a single line break will invalidate it.
* Aspose.Slides for Python via .NET looks for the license at the path you pass to it. A relative path, or a file name without a path, is resolved against the current working directory, which is not necessarily the folder that contains your Python script.
* To avoid the evaluation limitations, set the license before using Aspose.Slides. You only need to set it once per application or process.

{{% alert color="info" title="Note" %}}

You may also want to review [Metered Licensing](/slides/python-net/metered-licensing/).

{{% /alert %}}

## **Applying a License**

A license can be loaded from a **file** or a **stream**.

{{% alert color="info" title="Note" %}}

Aspose.Slides provides the [License](https://reference.aspose.com/slides/python-net/aspose.slides/license/) class to handle licensing.

{{% /alert %}}

{{% alert color="warning" title="Warning" %}}

New licenses can activate Aspose.Slides only with version 21.4 or later. Earlier versions use a different licensing system and will not recognize these licenses.

{{% /alert %}}

### **File**

The simplest way to set a license is to pass the path of the license file to the [set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/) method. If you pass only the file name, as in the example below, Aspose.Slides looks for the file in the current working directory.

The following Python code shows how to set the license file:

```py
import aspose.slides as slides

# Instantiates the License class. 
license = slides.License()

# Sets the license file path.
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" title="Warning" %}}

If you place the license file in a different directory, when you call [License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/#str), the file name at the end of the explicit path must match your license file’s name.

For example, you can rename the license file to *Aspose.Slides.lic.xml*. Then, in your code, pass the full path to that file (ending with Aspose.Slides.lic.xml) to the [License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/#str) method.

{{% /alert %}}

### **Stream**

You can load a license from a stream. The following Python example shows how to apply a license from a stream:

```py
import aspose.slides as slides

# Instantiates the License class.
license = slides.License()

# Set the license from a stream.
with open("Aspose.Slides.lic", "rb") as stream:
    license.set_license(stream)
```

## **Validating a License**

To verify that the license has been applied correctly, you can validate it. The following Python code demonstrates how to validate a license:

```py
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("License is good!")
```

## **Thread Safety**

{{% alert color="warning" title="Warning" %}}

The [License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/) method is not thread-safe. If you need to call it concurrently from multiple threads, use a synchronization primitive, such as `threading.Lock`, to avoid issues.

{{% /alert %}}

## **FAQ**

### Can I apply the license in a completely offline environment (no internet access)?

Yes. License validation is performed locally using the license file; no internet connection is required.

### What happens after the one-year subscription expires? Will the library stop working?

No. The license is perpetual: you can continue using versions released before your subscription end date; you just won’t be eligible to use newer releases without renewing.
