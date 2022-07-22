---
title: Licensing
type: docs
weight: 80
url: /net/licensing/
---

## **Evaluate Aspose.Slides**
You can easily download Aspose.Slides for evaluation. The evaluation package is the same as the purchased package. The evaluation version simply becomes licensed after you add a few lines of code to apply the license. 
### **Evaluation Version Limitation**
* While the evaluation version of Aspose.Slides (without a license specified) provides a full product functionality, it inserts an evaluation watermark at the top of the document on open and save operations. 
* When you use the evaluation version, you are also limited to one slide when extracting texts from presentation slides.

{{% alert color="primary" %}} 

To test Aspose.Slides without limitations, you can ask for a **30-Day Temporary License**. Please refer to [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) for more information.

{{% /alert %}}

## **Licensing in Aspose.Slides**
* You can easily download an evaluation version of Aspose.Slides for .NET from its [download page](https://www.nuget.org/packages/Aspose.Slides.NET/). The evaluation version provides absolutely **the same capabilities** as the licensed version of Aspose.Slides. 
* An evaluation version becomes licensed after you purchase a license and add a couple of lines of code to apply the license.

* The license is a plain-text XML file that contains details such as the product name, number of developers it is licensed to, subscription expiry date, and so on. 
* The license file is digitally signed, so you must not modify the file. Even an inadvertent addition of an extra line break to the contents of the file will invalidate it.

* To avoid the limitations associated with the evaluation version, you need to set a license before using **Aspose.Slides**. You are only required to set a license once per application or process.


## **Applying a License**
In Aspose.Slides for .NET, a license can be loaded from a **file**, **stream**, or **embedded resource**. 

Aspose.Slides for .NET typically tries to find the license in these locations:

* An explicit path
* The folder containing the dll of the component (included in Aspose.Slides)
* The folder containing the assembly that called the dll of the component (included in Aspose.Slides)
* The folder containing the entry assembly (your .exe)
* An embedded resource in the assembly that called the dll of the component (included in Aspose.Slides)

{{% alert color="primary" %}}

For license operations, Aspose.Slides provides the [License](https://reference.aspose.com/slides/net/aspose.slides/license) class. 

{{% /alert %}} 

### **Using a File**
The easiest method of setting a license requires you to place the license file in the same folder containing the component's DLL (included in Aspose.Slides) and specify the file name without its path.

This C# code shows you how to set a license file:

``` csharp

 //Instantiate an instance of license and set the license file through its path
Aspose.Slides.License license = new Aspose.Slides.License();
license.SetLicense("Aspose.Slides.lic");

```

When you call the `SetLicense` method, the string should be same as the name of your license file. For example, you can change the license file name to "*Aspose.Slides.lic.xml*". Then, in your code, you have to pass the new license name *Aspose.Slides.lic.xml* to the `SetLicense` method.

### **Using a Stream**
You can load a license from a stream. 

This C# code shows you how to apply a license from a stream:

``` csharp
 //Instantiate an instance of license and set the license through a stream
Aspose.Slides.License license = new Aspose.Slides.License();
license.SetLicense(myStream);
```

### **Embedding a Resource**
You can package the license with your application (to avoid losing it) by adding the license as an embedded resource into one of the assemblies that call the component's DLL (included in Aspose.Slides). 

This is how you add a license file as an embedded resource:

1. In Visual Studio, add the license (.lic) file to the project this way: Go through **File** > **Add Existing Item** > **Add**. 
2. Select the file in the **Solution Explorer**.
3. Set the **Build Action** to **Embedded Resource** on the **Properties** window.
4. To access the license embedded in the assembly (as an embedded resource), add the license file as an embedded resource to the project and pass the name of the license file to the `SetLicense` method. 


The `License` class automatically finds the license file in the embedded resources. You do not need to call the `GetExecutingAssembly` and `GetManifestResourceStream` methods of the `System.Reflection.Assembly` class in the Microsoft .NET Framework.

This C# code shows you how to set a license as an embedded resource:

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

