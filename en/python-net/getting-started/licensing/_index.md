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

## **Evaluate Aspose.Slides**

You can download an evaluation version of **Aspose.Slides for Python via .NET** from its [download page](https://pypi.org/project/Aspose.Slides/). The evaluation version provides the same features as the licensed product. The evaluation package is identical to the purchased package and becomes licensed after you add a few lines of code to apply the license.

When you’re satisfied with your evaluation of **Aspose.Slides**, you can [purchase a license](https://purchase.aspose.com/buy). We recommend reviewing the available subscription options. If you have questions, contact the Aspose sales team.

Every Aspose license includes a one-year subscription with free upgrades to new versions and fixes released during that period. Both licensed and evaluation users receive free, unlimited technical support.

**Limitations of the Evaluation Version**

* While the Aspose.Slides evaluation version (when no license is applied) provides full functionality, it adds an evaluation watermark at the top of the document whenever you open or save it.
* When extracting text from a presentation, you are limited to one slide.

{{% alert color="primary" %}}

To test Aspose.Slides without limitations, you can request a **30-day Temporary License**. See the [How to Get a Temporary License](https://purchase.aspose.com/temporary-license) page for details.

{{% /alert %}}

## **Licensing in Aspose.Slides**

* An evaluation version becomes licensed after you purchase a license and add a couple of lines of code to apply it.
* The license is a plain-text XML file that contains details such as the product name, the number of developers it covers, the subscription expiry date, and so on.
* The license file is digitally signed, so you must not modify it. Even adding a single line break will invalidate it.
* Aspose.Slides for Python via .NET typically looks for the license in these locations:
  * An explicit path you provide
  * The folder that contains the Python script that calls Aspose.Slides for Python via .NET
* To avoid the evaluation limitations, set the license before using Aspose.Slides. You only need to set it once per application or process.

{{% alert color="primary" %}}

You may also want to review [Metered Licensing](/slides/python-net/metered-licensing/).

{{% /alert %}}

## **Applying a License**

A license can be loaded from a **file**, **stream**, or **embedded resource**. 

{{% alert color="primary" %}}

Aspose.Slides provides the [License](https://reference.aspose.com/slides/python-net/aspose.slides/license/) class to handle licensing.

{{% /alert %}}

{{% alert color="warning" %}}

New licenses can activate Aspose.Slides only with version 21.4 or later. Earlier versions use a different licensing system and will not recognize these licenses.

{{% /alert %}}

### **File**

The easiest way to set a license is to place the license file in the same folder as the component’s DLL and specify only the file name (without a path).

The following Python code shows how to set the license file:

```py
import aspose.slides as slides

# Instantiates the License class. 
license = slides.License()

# Sets the license file path.
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" %}}

If you place the license file in a different directory, when you call [License.set_license()](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/#str), the file name at the end of the explicit path must match your license file’s name.

For example, you can rename the license file to *Aspose.Slides.lic.xml*. Then, in your code, pass the full path to that file (ending with Aspose.Slides.lic.xml) to the [License.set_license()](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/#str) method.

{{% /alert %}}

### **Stream**

You can load a license from a stream. The following Python example shows how to apply a license from a stream:

```py
import aspose.slides as slides

# Instantiates the License class.
license = slides.License()

# Set the license from a stream.
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

{{% alert title="Note" color="warning" %}}

The [License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/) methods are not thread-safe. If it needs to be called concurrently from multiple threads, use synchronization primitives (e.g., `threading.Lock`) to avoid issues.

{{% /alert %}}

## **FAQ**

**Can I apply the license in a completely offline environment (no internet access)?**

Yes. License validation is performed locally using the license file; no internet connection is required.

**What happens after the one-year subscription expires? Will the library stop working?**

No. The license is perpetual: you can continue using versions released before your subscription end date; you just won’t be eligible to use newer releases without renewing.
