---
title: Licensing
type: docs
weight: 80
url: /net/licensing/
---

## **Evaluate Aspose.Slides**
You can easily download Aspose.Slides for evaluation. The evaluation package is the same as the purchased package. The evaluation version simply becomes licensed after you add a few lines of code to apply the license. 
## **Evaluation Version Limitation**
The evaluation version of Aspose.Slides (without a license specified) provides the full product functionality, but it inserts an evaluation watermark at the top of the document on open and save. You are also limited to one slide when extracting texts from presentation slides.

{{% alert color="primary" %}} 

If you want to test Aspose.Slides without the evaluation version limitations, you can request a **30 Day Temporary License**. Please refer to [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) for more information.

{{% /alert %}} 

## **About the License**
You can easily download an evaluation version of Aspose.Slides for .NET from its [download page](https://www.nuget.org/packages/Aspose.Slides.NET/). The evaluation version provides absolutely **the same capabilities** as the licensed version of Aspose.Slides. Furthermore, the evaluation version simply becomes licensed after you purchase a license and add a couple of lines of code to apply the license.

The license is a plain-text XML file that contains details such as the product name, number of developers it is licensed to, subscription expiry date, and so on. The file is digitally signed, so do not modify the file. Even an inadvertent addition of an extra line break to the contents of the file will invalidate it.

To avoid the limitations associated with the evaluation version, you need to set a license before using **Aspose.Slides**. You are only required to set a license once per application or process.

## **Setting a License in Aspose.Slides for .NET**
In Aspose.Slides for .NET, the license can be loaded from a **file**, **stream**, or an **embedded resource**. 

Aspose.Slides for .NET typically tries to find the license in these locations:

- Explicit path
- The folder containing the dll of the component (included in Aspose.Slides)
- The folder containing the assembly that called the dll of the component (included in Aspose.Slides)
- The folder containing the entry assembly (your .exe)
- An embedded resource in the assembly that called the dll of the component (included in Aspose.Slides)

In the sections below, we will describe the two common methods used to set the license. 

{{% alert color="primary" %}}

For license operations, Aspose.Slides provides the [License](https://apireference.aspose.com/slides/net/aspose.slides/license) class. 

{{% /alert %}} 

## **Applying a License Using File**
### **Applying a License Using a File**
The easiest method of setting a license requires you to place the license file in the same folder containing the component's DLL (included in Aspose.Slides) and specify just the file name without its path.

This code snippet is used to set a license file:

**C#**

``` csharp

 //Instantiate an instance of license and set the license file through its path
Aspose.Slides.License license = new Aspose.Slides.License();
license.SetLicense("Aspose.Slides.lic");

```

When calling the SetLicense method, the license name should be same as that of your license file. For example, you can change the license file name to "Aspose.Slides.lic.xml". Then, in your code, you have to pass the new license name (Aspose.Slides.lic.xml) to the SetLicense method.

### **Applying a License from a Stream**
You can load a license from a stream. 

This code snippet is used to apply a license from a stream:

**C#**

``` csharp
 //Instantiate an instance of license and set the license through a stream
Aspose.Slides.License license = new Aspose.Slides.License();
license.SetLicense(myStream);
```

### **Embedding a Resource**
You can apply a license by [using a file or stream](/slides/net/licensing/). You can package the license with your application (to avoid losing it) this way: add the license as an embedded resource into one of the assemblies that calls the component's DLL (included in Aspose.Slides). 

To add the license file as an embedded resource, do this:

1. In Visual Studio, add the license (.lic) file to the project this way: Go through **File** > **Add Existing Item** > **Add**. 

1. Select the file in the Solution Explorer.

1. Set the **Build Action** to **Embedded Resource** in the Properties window.

1. To access the license embedded in the assembly (as an embedded resource), add the license file as an embedded resource to the project and pass the name of the license file to the SetLicense method. 

   The License class automatically finds the license file in the embedded resources. You do not need to call the GetExecutingAssembly and GetManifestResourceStream methods of the System.Reflection.Assembly class in the Microsoft .NET Framework.

This code snippet is used to set the license:

**C#**

``` csharp

 //Instantiate the License class
Aspose.Slides.License license = new Aspose.Slides.License();

//Pass only the name of the license file embedded in the assembly
license.SetLicense("Aspose.Slides.lic");

```

## **Thread Safety**

{{% alert title="Note" color="warning" %}} 

The `license.SetLicense` method is not thread safe. If this method has to be called simultaneously from many threads, you may want to use synchronization primitives (like a lock) to avoid issues. 

{{% /alert %}}

