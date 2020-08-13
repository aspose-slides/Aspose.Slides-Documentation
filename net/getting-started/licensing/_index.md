---
title: Licensing
type: docs
weight: 80
url: /net/licensing/
---

## **Evaluate Aspose.Slides**
You can easily download Aspose.Slides for evaluation. The evaluation download is the same as the purchased download. The evaluation version simply becomes licensed when you add a few lines of code to apply the license. The evaluation version of Aspose.Slides (without a license specified) provides full product functionality, but it inserts an evaluation watermark at the top of the document on open and save, and limits to one slide when extracting the text from presentation slides. If you want to test Aspose.Slides without the evaluation version limitations, you can also request a 30-day Temporary License. Please refer to [How to get a Temporary License?](https://purchase.aspose.com/temporary-license)
## **Evaluation Version Limitation**
Evaluation version of Aspose.Slides (without a license specified) provides full product functionality except that when you save your presentations using Aspose.Slides, an **Evaluation Watermark** is injected at the center of each slide. If you want to test Aspose.Slides without evaluation version limitations, you can also request a **30 Day Temporary License** . Please refer to [How to get a Temporary License?](https://purchase.aspose.com/temporary-license).
## **About the License**
You can easily download an evaluation version of Aspose.Slides for .NET from its [download page](https://www.nuget.org/packages/Aspose.Slides.NET/) . The evaluation version provides **absolutely** the same capabilities as the licensed version of Aspose.Slides. Furthermore, evaluation version simply becomes licensed when you purchase a license and add a couple of lines of code to apply the license.

The license is a plain text XML file that contains details such as the product name, number of developers it is licensed to, subscription expiry date and so on. The file is digitally signed, so don't modify the file. Even inadvertent addition of an extra line break into the file will invalidate it. You need to set a license before utilizing Aspose.Slides for .NET if you want to avoid its evaluation limitations. It is only required to set a license once per application (or process).
## **Setting a License in Aspose.Slides for .NET**
In Aspose.Slides for .NET, license can be loaded from a **file** , **stream** or an **embedded resource** . Aspose.Slides for .NET tries to find the license in the following locations:

- Explicit path
- The folder that contains the dll of the component (included in Aspose.Slides)
- The folder that contains the assembly that called the dll of the component (included in Aspose.Slides)
- The folder that contains the entry assembly (your .exe)
- An embedded resource in the assembly that called the dll of the component (included in Aspose.Slides)

There are two common methods to set the license as discussed in continuing sections.
## **Applying a License Using File**
### **Applying a License Using File**
The easiest way to set a license is to put the license file in the same folder as that of the component's DLL (included in Aspose.Slides) and specify just the file name without its path.

**C#**

{{< highlight csharp >}}

 //Instantiate an instance of license and set the license file through its path

Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");


{{< /highlight >}}



When calling the SetLicense method, the license name should be same as that of your license file. For example, you may change the license file name to "Aspose.Slides.lic.xml". Then in your code, you should pass the new license name (Aspose.Slides.lic.xml) to the SetLicense method.
### **Applying a License Using Stream**
It is also possible to load a license from a stream. The following code snippet is used to apply a license from a stream.

**C#**

{{< highlight csharp >}}

 //Instantiate an instance of license and set the license through a stream

Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense(myStream);

{{< /highlight >}}


### **Check If Aspose.Slides License is Applied in Application**
It is also possible to check if Aspose.Slides license is properly in the application or not. This is helpful when you're unsure whether the license is applied or not and saves you from running into license related issues. The following code snippet is used to check the license.

**C#**

{{< highlight csharp >}}

 //Instantiate an instance of license and set the license through a stream

Aspose.Slides.License license = new Aspose.Slides.License();

//Setting License

license.SetLicense("Aspose.Slides.lic");

//Reset the applied license

license.ResetLicense();

//Get status if license is applied or not

bool isLicensed = license.IsLicensed();

if(!isLicensed)

{

    license.SetLicense("Aspose.Slides.lic");

    Debug.Assert(!license.IsLicensed());

}



{{< /highlight >}}


### **Embedding a Resource**
One way of applying a license is to set it [using a file or stream](/slides/net/licensing/). Another neat way of packaging the license with your application and making sure it will not be lost is to include it as an embedded resource into one of the assemblies that calls the component's DLL (included in Aspose.Slides). To include the license file as an embedded resource:

1. In Visual Studio .NET, include the license (.lic) file into the project by selecting **File**, then **Add Existing Item** and finally **Add**.
1. Select the file in the Solution Explorer.
1. Set the **Build Action** to **Embedded Resource** in the Properties window.
1. To access the license embedded in the assembly (as an embedded resource), just add the license file as an embedded resource to the project and pass the name of the license file to the SetLicense method. The License class automatically finds the license file in the embedded resources. There's no need to call the GetExecutingAssembly and GetManifestResourceStream methods of the System.Reflection.Assembly class in the Microsoft .NET Framework.

The following code snippet is used to set the license.

**C#**

{{< highlight csharp >}}

 //Instantiate the License class

Aspose.Slides.License license = new Aspose.Slides.License();

//Pass only the name of the license file embedded in the assembly

license.SetLicense("Aspose.Slides.lic");



{{< /highlight >}}




