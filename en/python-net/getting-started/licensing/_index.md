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

{{% alert color="primary" %}} 

You can download an evaluation version of **Aspose.Slides for Python via .NET** from its [download page](https://pypi.org/project/Aspose.Slides/). The evaluation version provides the same functionalities as the licensed version of the product. The evaluation package is the same as the purchased package. The evaluation version simply becomes licensed after you add a few lines of code to it (to apply the license).

Once you are happy with your evaluation of **Aspose.Slides**, you can [purchase a license](https://purchase.aspose.com/buy). We recommend you go through the different subscription types. If you have questions, contact the Aspose sales team.

Every Aspose license comes with one-year subscription for free upgrades to new versions or fixes released within the subscription period. Users with licensed products or even evaluation versions get free and unlimited technical support.

{{% /alert %}} 

**Evaluation version limitations**

* While Aspose.Slides evaluation version (without a license specified) provides full product functionality, it inserts an evaluation watermark at the top of the document on open and save operations. 
* You are limited to one slide when extracting texts from presentation slides.

{{% alert color="primary" %}} 

To test Aspose.Slides without limitations, you can ask for a **30-Day Temporary License**. See the [How to get a Temporary License](https://purchase.aspose.com/temporary-license) page for more information.

{{% /alert %}}

## **Licensing in Aspose.Slides**

* An evaluation version becomes licensed after you purchase a license and add a couple of lines of code to it (to apply the license).
* The license is a plain-text XML file that contains details such as the product name, number of developers it is licensed to, subscription expiry date, and so on. 
* The license file is digitally signed, so you must not modify the file. Even an inadvertent addition of an extra line break to the contents of the file will invalidate it.
* Aspose.Slides for Python via .NET typically tries to find the license in these locations:
  * An explicit path
  * The folder containing the Python script that calls Aspose.Slides for Python via .NET
* To avoid the limitations associated with the evaluation version, you need to set a license before using Aspose.Slides. You only have to set a license once per application or process.

{{% alert color="primary" %}} 

You may want to see [Metered Licensing](/slides/python-net/metered-licensing/).

{{% /alert %}} 


## **Applying a License**

A license can be loaded from a **file**, **stream**, or **embedded resource**. 

{{% alert color="primary" %}}

Aspose.Slides provides the [License](https://reference.aspose.com/slides/python-net/aspose.slides/license/) class for licensing operations.

{{% /alert %}} 

### **File**

The easiest method of setting a license requires you to place the license file in the same folder containing the component's DLL (included in Aspose.Slides) and specify the file name without its path.

This Python code shows you how to set a license file:

``` python
import aspose.slides as slides

# Instantiates the License class 
license = slides.License()

# Sets the license file path
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" %}} 

If you place the license file in a different directory, when you call the [License.set_license()](https://reference.aspose.com/slides/python-net/aspose.slides/license/) method, the license file name at the end of the specified explicit must be the same as your license file.

For example, you can change the license file name to *Aspose.Slides.lic.xml*. Then, in your code, you have to pass the path to the file (ending with *Aspose.Slides.lic.xml*) to the [License.set_license()](https://reference.aspose.com/slides/python-net/aspose.slides/license/) method.

{{% /alert %}}

### **Stream**

You can load a license from a stream. This Python code shows you how to apply a license from a stream:

``` python
import aspose.slides as slides

# Instantiates the License class 
license = slides.License()

#Sets the license through a stream
license.set_license(stream)
```

## **Validating a License**

To check whether a license has been set properly, you can validate it. This Python code shows you how to validate a license:

```python
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("License is good!")
```

## **Thread Safety**

{{% alert title="Note" color="warning" %}} 

The [License.set_license()](https://reference.aspose.com/slides/python-net/aspose.slides/license/) method is not thread safe. If this method has to be called simultaneously from many threads, you may want to use synchronization primitives (like a lock) to avoid issues. 

{{% /alert %}}
