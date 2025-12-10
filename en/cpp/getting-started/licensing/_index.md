---
title: Licensing
type: docs
weight: 120
url: /cpp/licensing/
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
- C++
- Aspose.Slides
description: "Apply, manage, and troubleshoot licenses in Aspose.Slides for C++. Ensure uninterrupted access to full features with our step-by-step licensing guide."
---

## **Evaluate Aspose.Slides**

{{% alert color="primary" %}} 

You can download an evaluation version of **Aspose.Slides for C++** from [its NuGet download page](https://www.nuget.org/packages/Aspose.Slides.CPP/). The evaluation version offers the same functionality as the licensed product. In fact, the evaluation package is identical to the purchased one—it simply becomes licensed once you add a few lines of code to apply the license.

Once you're satisfied with your evaluation of **Aspose.Slides**, you can [purchase a license](https://purchase.aspose.com/buy). We recommend reviewing the available subscription types. If you have any questions, feel free to contact the Aspose sales team.

Every Aspose license includes a one-year subscription for free upgrades, including new versions and bug fixes released during that period. Whether you're using a licensed or evaluation version, you receive free and unlimited technical support.

{{% /alert %}} 

**Evaluation Version Limitations**

* While the Aspose.Slides evaluation version (when no license is applied) provides full product functionality, it inserts an evaluation watermark at the top of the document during open and save operations.
* Text extraction is limited to one slide when using the evaluation version.

{{% alert color="primary" %}} 

To test Aspose.Slides without limitations, you can request a **30-Day Temporary License**. For more information, see the [How to Get a Temporary License](https://purchase.aspose.com/temporary-license) page.

{{% /alert %}}

## **Licensing in Aspose.Slides**

* An evaluation version becomes licensed after you purchase a license and apply it by adding a couple of lines of code.
* The license is a plain-text XML file that contains details such as the product name, the number of developers it is licensed to, the subscription expiry date, and more.
* The license file is digitally signed, so it must not be modified. Even an accidental change—such as adding a line break—will invalidate the file.
* Aspose.Slides for C++ typically looks for the license file in the following locations:
  * A path explicitly specified in your code
  * The folder containing the component’s DLL (included in Aspose.Slides)
  * The folder containing the assembly that calls the component’s DLL
* To avoid the limitations of the evaluation version, you must set the license before using Aspose.Slides. A license only needs to be set once per application or process.

## **Apply a License**

A license can be loaded from a **file**, a **stream**, or an **embedded resource**.

{{% alert color="primary" %}}

Aspose.Slides provides the [License](https://reference.aspose.com/slides/cpp/class/aspose.slides.license/) class for licensing operations.

{{% /alert %}} 

{{% alert color="warning" %}}

New licenses can activate Aspose.Slides only with version 21.4 or later. Earlier versions use a different licensing system and will not recognize these licenses.

{{% /alert %}}

### **File**

The easiest way to set a license is to place the license file in the same folder as the component’s DLL (included in Aspose.Slides) and specify only the file name, without the path.

The following C++ code shows how to set a license file:

```c++
#include <Util/License.h>

using namespace Aspose::Slides;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

{{% alert color="warning" %}} 

If you place the license file in a different directory, then when calling the [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) method, the file name at the end of the specified explicit path must exactly match the name of your license file.

For example, if you rename your license file to *Aspose.Slides.lic.xml*, you must pass the full path ending with *Aspose.Slides.lic.xml* to the [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) method in your code.

{{% /alert %}}

### **Stream**

You can load a license from a stream. The following C++ code shows how to apply a license from a stream:

```c++
auto license = MakeObject<License>();

auto stream = File::OpenRead(u"Aspose.Slides.lic");

license->SetLicense(stream);
```

## **Validate a License**

To check whether a license has been set properly, you can validate it. The following C++ code shows how to validate a license:

```c++
auto license = MakeObject<License>();

license->SetLicense(u"Aspose.Slides.lic");

if (license->IsLicensed())
{
    Console::WriteLine(u"License is good!");
    Console::ReadKey();
}
```

## **Thread Safety**

{{% alert title="Note" color="warning" %}} 

The [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) method is **not thread-safe**. If you need to call this method from multiple threads simultaneously, it's recommended to use synchronization primitives (such as a lock) to prevent potential issues.

{{% /alert %}}

## **FAQ**

**Can I apply the license in a completely offline environment (no internet access)?**

Yes. License validation is performed locally using the license file; no internet connection is required.

**What happens after the one-year subscription expires? Will the library stop working?**

No. The license is perpetual: you can continue using versions released before your subscription end date; you just won’t be eligible to use newer releases without renewing.
