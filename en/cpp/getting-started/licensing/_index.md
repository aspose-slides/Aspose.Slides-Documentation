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

## **Overview**

Aspose.Slides can be used in evaluation mode or with a valid license. The evaluation version provides the same functionality as the licensed version, but it adds an evaluation watermark to every slide of each presentation it saves and truncates text that your code reads from presentations.

This article explains how licensing works in Aspose.Slides and how to apply a license before using the library. A license can be loaded from a file or a stream by using the `License` class. The article also shows how to validate whether a license has been applied correctly.

## **Evaluate Aspose.Slides**

{{% alert color="info" title="Note" %}}

You can download an evaluation version of **Aspose.Slides for C++** from [its NuGet download page](https://www.nuget.org/packages/Aspose.Slides.Cpp/) or, as a ZIP package, from the [download page](https://releases.aspose.com/slides/cpp/). The evaluation version offers the same functionality as the licensed product. In fact, the evaluation package is identical to the purchased one—it simply becomes licensed once you add a few lines of code to apply the license.

Once you're satisfied with your evaluation of **Aspose.Slides**, you can [purchase a license](https://purchase.aspose.com/pricing/slides/cpp/). We recommend reviewing the available subscription types. If you have any questions, feel free to contact the Aspose sales team.

Every Aspose license includes a one-year subscription for free upgrades, including new versions and bug fixes released during that period. Whether you're using a licensed or evaluation version, you receive free and unlimited technical support.

{{% /alert %}} 

**Evaluation Version Limitations**

* The evaluation version (without a license specified) provides full product functionality, but it adds an evaluation watermark text box to every slide of each presentation it saves.
* Text that your code reads from a presentation is truncated to its first few characters, followed by a notice about the evaluation limitation. Text that your code writes is saved in full.

{{% alert color="info" title="Note" %}}

To test Aspose.Slides without limitations, you can request a **30-Day Temporary License**. For more information, see the [How to Get a Temporary License](https://purchase.aspose.com/temporary-license) page.

{{% /alert %}}

## **Licensing in Aspose.Slides**

* An evaluation version becomes licensed after you purchase a license and apply it by adding a couple of lines of code.
* The license is a plain-text XML file that contains details such as the product name, the number of developers it is licensed to, the subscription expiry date, and more.
* The license file is digitally signed, so it must not be modified. Even an accidental change—such as adding a line break—will invalidate the file.
* When you pass a file name without a folder, Aspose.Slides for C++ looks for the license file in the current working directory only. It does not search the folder of your executable or of the Aspose.Slides library, so pass the full path when the license file is stored elsewhere.
* To avoid the limitations of the evaluation version, you must set the license before using Aspose.Slides. A license only needs to be set once per application or process.

## **Apply a License**

A license can be loaded from a **file** or a **stream**.

{{% alert color="info" title="Note" %}}

Aspose.Slides provides the [License](https://reference.aspose.com/slides/cpp/aspose.slides/license/) class for licensing operations.

{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}

New licenses can activate Aspose.Slides only with version 21.4 or later. Earlier versions use a different licensing system and will not recognize these licenses.

{{% /alert %}}

### **File**

The easiest way to set a license is to place the license file in the working directory of your program and specify only the file name, without the path. Otherwise, specify the full path to the file.

The following C++ code applies the license file *Aspose.Slides.lic* from the working directory of the program:

```c++
#include <Util/License.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

If the license is valid, [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) returns and the program ends without output; from then on, Aspose.Slides works without the evaluation limitations. If the file is not in the working directory, the method throws a [FileNotFoundException](https://reference.aspose.com/slides/cpp/system.io/filenotfoundexception/) with the message *License "Aspose.Slides.lic" doesn't exist or access is restricted*. The example does not handle the exception, so the program stops.

{{% alert color="warning" title="Warning" %}}

If you place the license file in a different directory, then when calling the [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) method, the file name at the end of the specified explicit path must exactly match the name of your license file.

For example, if you rename your license file to *Aspose.Slides.lic.xml*, you must pass the full path ending with *Aspose.Slides.lic.xml* to the [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) method in your code.

{{% /alert %}}

### **Stream**

Load a license from a stream when your program does not keep the license as a file that it can name, for example, when it reads the license from a database. [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) accepts any [Stream](https://reference.aspose.com/slides/cpp/system.io/stream/) that contains the license. To keep the example short, the following C++ code opens *Aspose.Slides.lic* in the working directory with [File::OpenRead](https://reference.aspose.com/slides/cpp/system.io/file/openread/) and applies the license from that stream:

```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

int main()
{
    auto license = MakeObject<License>();
    auto stream = File::OpenRead(u"Aspose.Slides.lic");
    license->SetLicense(stream);

    return 0;
}
```

A valid license gives the same result as in the file example. If the file does not exist, [File::OpenRead](https://reference.aspose.com/slides/cpp/system.io/file/openread/) throws a [FileNotFoundException](https://reference.aspose.com/slides/cpp/system.io/filenotfoundexception/) before the license is applied, and the program stops.

## **Validate a License**

To check whether a license has been set properly, call [License::IsLicensed](https://reference.aspose.com/slides/cpp/aspose.slides/license/islicensed/). It returns `true` only after a valid license has been applied, and `false` before that. The following C++ code applies the license file from the working directory and then checks it:

```c++
#include <Util/License.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    if (license->IsLicensed())
    {
        Console::WriteLine(u"License is good!");
    }

    return 0;
}
```

With a valid license, the program prints *License is good!*. If the file is missing or is not a license file, [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) throws an exception before the check, and the program stops without printing anything. If the file is a license whose signature does not match, for example because it was edited, SetLicense returns without an error but `IsLicensed` returns `false`, so nothing is printed and Aspose.Slides stays in evaluation mode.

## **Thread Safety**

{{% alert color="warning" title="Warning" %}}

The [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) method is **not thread-safe**. If you need to call this method from multiple threads simultaneously, it's recommended to use synchronization primitives (such as a lock) to prevent potential issues.

{{% /alert %}}

## **FAQ**

### Can I apply the license in a completely offline environment (no internet access)?

Yes. License validation is performed locally using the license file; no internet connection is required.

### What happens after the one-year subscription expires? Will the library stop working?

No. The license is perpetual: you can continue using versions released before your subscription end date; you just won’t be eligible to use newer releases without renewing.
