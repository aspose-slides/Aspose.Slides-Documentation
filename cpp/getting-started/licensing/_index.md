---
title: Licensing
type: docs
weight: 120
url: /cpp/licensing/
---

## **Evaluate Aspose.Slides**
You can easily download Aspose.Slides for evaluation. The evaluation download is the same as the purchased download. The evaluation version simply becomes licensed when you add a few lines of code to apply the license. The evaluation version of Aspose.Slides (without a license specified) provides full product functionality, but it inserts an evaluation watermark at the top of the document on open and save, and limits to one slide when extracting the text from presentation slides. If you want to test Aspose.Slides without the evaluation version limitations, you can also request a 30-day Temporary License. Please refer to [How to get a Temporary License?](https://purchase.aspose.com/temporary-license)
## **Evaluation Version Limitation**
Evaluation version of Aspose.Slides (without a license specified) provides full product functionality except that when you save your presentations using Aspose.Slides, an **Evaluation Watermark** is injected at the center of each slide. If you want to test Aspose.Slides without evaluation version limitations, you can also request a **30 Day Temporary License** . Please refer to How [to get a Temporary License](https://purchase.aspose.com/temporary-license)?.
## **About the License**
You can easily download an evaluation version of Aspose.Slides for C++ from its [download page](https://downloads.aspose.com/slides/cpp) . The evaluation version provides **absolutely** the same capabilities as the licensed version of Aspose.Slides. Furthermore, evaluation version simply becomes licensed when you purchase a license and add a couple of lines of code to apply the license.

The license is a plain text XML file that contains details such as the product name, number of developers it is licensed to, subscription expiry date and so on. The file is digitally signed, so don't modify the file. Even inadvertent addition of an extra line break into the file will invalidate it. You need to set a license before utilizing Aspose.Slides for C++ if you want to avoid its evaluation limitations. It is only required to set a license once per application (or process).
## **Apply License using File or Stream Object**
The license can be loaded from a file or stream object. Aspose.Cells for C++ will try to find the license in the following locations:

1. Explicit path.
1. The folder that contains Aspose.Slides.dll.
1. The folder that contains the assembly that called Aspose.Slides.dll.
1. The folder that contains the entry assembly (your .exe).
1. An embedded resource in the assembly that called Aspose.Slides.dll.

The easiest way to set a license is to put the license file in the same folder as the Aspose.Slides.dll file and specify the file name, without a path, as shown in the example below.
### **Loading a License from File**
The easiest way to apply a license is to put the license file in the same folder as the Aspose.Slides.dll file and specify just the file name without a path.

{{% alert color="primary" %}} 

When you call the SetLicense method, the license name that you pass should be that of the license file. For example, if you change the license file name to "Aspose.Slides.lic.xml" pass that file name to the Cells->SetLicense(…) method.

{{% /alert %}} 

**C++**

``` cpp

 SharedPtr<Aspose::Slides::License> lic = MakeObject<Aspose::Slides::License>();

lic->SetLicense(L"Aspose.Slides.lic");

```
### **Loading a License from a Stream Object**
The following example shows how to load a license from a stream.

**C++**

``` cpp

 SharedPtr<Aspose::Slides::License> lic = MakeObject<Aspose::Slides::License>();

System::SharedPtr<System::IO::FileStream> stream= System::IO::File::OpenRead(L"Aspose.Slides.lic");

lic->SetLicense(stream); 

```
## **Check If Aspose.Slides License is Applied in Application**
It is also possible to check if Aspose.Slides license is properly in the application or not. This is helpful when you're unsure whether the license is applied or not and saves you from running into license related issues. The following code snippet is used to check the license.

**C#**

``` cpp

 //Instantiate an instance of license and set the license through a stream

SharedPtr<Aspose::Slides::License> license= MakeObject<Aspose::Slides::License>();

//Setting license path

license->SetLicense(L"Aspose.Slides.lic");

//Reset the applied license

license->ResetLicense();

//Get status if license is applied or not

auto isLicensed = license->IsLicensed();

if(!isLicensed)

{

    license->SetLicense(L"Aspose.Slides.lic");

}



```

## **Thread Safety**

{{% alert title="Note" color="warning" %}} 

The `license->SetLicense` method is not thread safe. If this method has to be called simultaneously from many threads, you may want to use synchronization primitives (like a lock) to avoid issues. 

{{% /alert %}}
