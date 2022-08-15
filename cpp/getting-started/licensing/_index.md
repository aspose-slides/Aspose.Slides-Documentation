---
title: Licensing
type: docs
weight: 120
url: /cpp/licensing/
---

## **Evaluate Aspose.Slides**

{{% alert color="primary" %}} 

You can download an evaluation version of **Aspose.Slides for C++** from [its NuGet download page](https://www.nuget.org/packages/Aspose.Slides.CPP/). The evaluation version provides the same functionalities as the licensed version of the product. he evaluation package is the same as the purchased package. The evaluation version simply becomes licensed after you add a few lines of code to it (to apply the license).

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
* Aspose.Slides for C++ typically tries to find the license in these locations:
  * An explicit path
  * The folder containing the dll of the component (included in Aspose.Slides)
  * The folder containing the assembly that calls the dll of the component (included in Aspose.Slides)
  * The folder containing the entry assembly (your .exe)
* To avoid the limitations associated with the evaluation version, you need to set a license before using Aspose.Slides. You only have to set a license once per application or process.

## **Applying a License**

A license can be loaded from a **file**, **stream**, or **embedded resource**. 

{{% alert color="primary" %}}

Aspose.Slides provides the [License](https://reference.aspose.com/slides/cpp/class/aspose.slides.license/) class for licensing operations.

{{% /alert %}} 

### **File**

The easiest method of setting a license requires you to place the license file in the same folder containing the component's DLL (included in Aspose.Slides) and specify the file name without its path.

This C++ code shows you how to set a license file:

```c++
SharedPtr<Aspose::Slides::License> lic = MakeObject<Aspose::Slides::License>();

lic->SetLicense(L"Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

When you call the `SetLicense` method, the string must have the same name as your license file. For example, you can change the license file name to "*Aspose.Slides.lic.xml*". Then, in your code, you have to pass the new license name *Aspose.Slides.lic.xml* to the `SetLicense` method.

{{% /alert %}}

### **Stream**

You can load a license from a stream. This C++ code shows you how to apply a license from a stream:

```c++
SharedPtr<Aspose::Slides::License> lic = MakeObject<Aspose::Slides::License>();

System::SharedPtr<System::IO::FileStream> stream= System::IO::File::OpenRead(L"Aspose.Slides.lic");

lic->SetLicense(stream); 
```

## **Validating a License**

To check whether a license has been set properly, you can validate it. This C++ code shows you how to validate a license:

```c++
SharedPtr<Aspose::Slides::License> license= MakeObject<Aspose::Slides::License>();

license->SetLicense(L"Aspose.Slides.lic");

license->ResetLicense();

auto isLicensed = license->IsLicensed();

if(!isLicensed)
{
    license->SetLicense(L"Aspose.Slides.lic");
}
```

## **Thread Safety**

{{% alert title="Note" color="warning" %}} 

The [License::SetLicense()](https://reference.aspose.com/slides/cpp/class/aspose.slides.license#a44102d1d52a5e45643345448b1814a67) method is not thread safe. If this method has to be called simultaneously from many threads, you may want to use synchronization primitives (like a lock) to avoid issues. 

{{% /alert %}}
