---
title: Licensing
type: docs
weight: 80
url: /net/licensing/
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
- .NET
- C#
- Aspose.Slides
description: "Apply, manage, and troubleshoot licenses in Aspose.Slides for .NET. Ensure uninterrupted access to full features with our step-by-step licensing guide."
---

## **Evaluate Aspose.Slides**

{{% alert color="primary" %}} 

You can download an evaluation version of **Aspose.Slides for NET** from [its NuGet download page](https://www.nuget.org/packages/Aspose.Slides.NET/). The evaluation version provides the same functionalities as the licensed version of the product. The evaluation package is the same as the purchased package. The evaluation version simply becomes licensed after you add a few lines of code to it (to apply the license).

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
* Aspose.Slides for .NET typically tries to find the license in these locations:
  * An explicit path
  * The folder containing the dll of the component (included in Aspose.Slides)
  * The folder containing the assembly that called the dll of the component (included in Aspose.Slides)
  * The folder containing the entry assembly (your .exe)
  * An embedded resource in the assembly that called the dll of the component (included in Aspose.Slides).
* To avoid the limitations associated with the evaluation version, you need to set a license before using Aspose.Slides. You only have to set a license once per application or process.

{{% alert color="primary" %}} 

You may want to see [Metered Licensing](https://docs.aspose.com/slides/net/metered-licensing/).

{{% /alert %}} 


## **Apply a License**
A license can be loaded from a **file**, **stream**, or **embedded resource**. 

{{% alert color="primary" %}}

Aspose.Slides provides the [License](https://reference.aspose.com/slides/net/aspose.slides/license) class for licensing operations.

{{% /alert %}} 

{{% alert color="warning" %}} 

New licenses can activate Aspose.Slides only with version 21.4 or later. Earlier versions use a different licensing system and will not recognize these licenses.

{{% /alert %}}

### **File**
The easiest method of setting a license requires you to place the license file in the same folder containing the component's DLL (included in Aspose.Slides) and specify only the file name without its path.

This C# code shows you how to set a license file:

``` csharp
// Instantiates the License class 
Aspose.Slides.License license = new Aspose.Slides.License();

// Sets the license file path
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

If you place the license file in a different directory, when you call the [SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1) method, the license file name at the end of the specified explicit must be the same as your license file.

For example, you can change the license file name to *Aspose.Slides.lic.xml*. Then, in your code, you have to pass the path to the file (ending with *Aspose.Slides.lic.xml*) to the [SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1) method.

{{% /alert %}}

### **Stream**
You can load a license from a stream. This C# code shows you how to apply a license from a stream:

``` csharp
// Instantiates the License class 
Aspose.Slides.License license = new Aspose.Slides.License();

// Sets the license through a stream
license.SetLicense(myStream);
```

### **Embedded Resource**
You can package the license with your application (to avoid losing it) by adding the license as an embedded resource into one of the assemblies that call the component's DLL (included in Aspose.Slides). 

This is how you add a license file as an embedded resource:

1. In Visual Studio, add the license (.lic) file to the project this way: Go through **File** > **Add Existing Item** > **Add**. 
2. Select the file in the **Solution Explorer**.
3. On the **Properties** window, set the **Build Action** to **Embedded Resource**.
4. To access the license embedded in the assembly, add the license file as an embedded resource to the project, and then pass the license file name to the `SetLicense` method. 


The `License` class automatically finds the license file in the embedded resources. You do not need to call the `GetExecutingAssembly` and `GetManifestResourceStream` methods of the `System.Reflection.Assembly` class in the Microsoft .NET Framework.

This C# code shows you how to set a license as an embedded resource:

``` csharp
// Instantiates the License class
Aspose.Slides.License license = new Aspose.Slides.License();

// Passes the license file name embedded in the assembly
license.SetLicense("Aspose.Slides.lic");
```

## **Validate a License**

To check whether a license has been set properly, you can validate it. This C# code shows you how to validate a license:

```c#
Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");

if (license.IsLicensed())
{
    Console.WriteLine("License is good!");
    Console.Read();
}
```

## **Thread Safety**

{{% alert title="Note" color="warning" %}} 

The [license.SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/) method is not thread-safe. If this method has to be called simultaneously from many threads, you may want to use synchronization primitives (like a lock) to avoid issues. 

{{% /alert %}}

## **FAQ**

**Can I apply the license in a completely offline environment (no internet access)?**

Yes. License validation is performed locally using the license file; no internet connection is required.

**What happens after the one-year subscription expires? Will the library stop working?**

No. The license is perpetual: you can continue using versions released before your subscription end date; you just won’t be eligible to use newer releases without renewing.
