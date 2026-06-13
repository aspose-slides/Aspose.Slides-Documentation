---
title: .NET में प्रेजेंटेशन में OLE ऑब्जेक्ट्स का प्रबंधन
linktitle: OLE प्रबंधन
type: docs
weight: 40
url: /hi/net/manage-ole/
keywords:
- OLE ऑब्जेक्ट
- ऑब्जेक्ट लिंकिंग और एम्बेडिंग
- OLE जोड़ें
- OLE एम्बेड करें
- ऑब्जेक्ट जोड़ें
- ऑब्जेक्ट एम्बेड करें
- फ़ाइल जोड़ें
- फ़ाइल एम्बेड करें
- लिंक्ड ऑब्जेक्ट
- लिंक्ड फ़ाइल
- OLE बदलें
- OLE आइकन
- OLE शीर्षक
- OLE निकालें
- ऑब्जेक्ट निकालें
- फ़ाइल निकालें
- PowerPoint
- प्रेज़ेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint और OpenDocument फ़ाइलों में OLE ऑब्जेक्ट प्रबंधन को अनुकूलित करें। OLE सामग्री को सहजता से एम्बेड, अपडेट और एक्सपोर्ट करें।"
---
## **परिचय**

{{% alert title="सूचना" color="info" %}}
OLE (ऑब्जेक्ट लिंकिंग एवं एम्बेडिंग) एक माइक्रोसॉफ्ट तकनीक है जो एक एप्लिकेशन में बने डेटा और ऑब्जेक्ट को लिंकिंग या एम्बेडिंग के माध्यम से दूसरे एप्लिकेशन में रखने की अनुमति देती है। 
{{% /alert %}} 

MS Excel में बनाई गई एक चार्ट को देखें। इस चार्ट को फिर PowerPoint स्लाइड में रखा जाता है। वह Excel चार्ट एक OLE ऑब्जेक्ट माना जाता है। 

- एक OLE ऑब्जेक्ट आइकन के रूप में दिखाई दे सकता है। इस स्थिति में, जब आप आइकन को डबल‑क्लिक करते हैं, तो चार्ट अपने संबद्ध एप्लिकेशन (Excel) में खुल जाता है, या आपको ऑब्जेक्ट खोलने या संपादित करने के लिए एप्लिकेशन चुनने का अनुरोध किया जाता है। 
- एक OLE ऑब्जेक्ट अपना वास्तविक कंटेंट, जैसे कि चार्ट का कंटेंट, प्रदर्शित कर सकता है। इस स्थिति में, चार्ट PowerPoint में सक्रिय हो जाता है, चार्ट इंटरफ़ेस लोड होता है, और आप PowerPoint के भीतर चार्ट के डेटा को संशोधित कर सकते हैं। 

[Aspose.Slides for .NET](https://products.aspose.com/slides/hi/net/) आपको स्लाइड्स में OLE ऑब्जेक्ट्स को OLE ऑब्जेक्ट फ्रेम के रूप में सम्मिलित करने की अनुमति देता है ([OleObjectFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/oleobjectframe))।

## **स्लाइड्स में OLE ऑब्जेक्ट फ्रेम जोड़ें**

मान लीजिए आपने Microsoft Excel में एक चार्ट बना लिया है और Aspose.Slides for .NET का उपयोग करके उसे OLE ऑब्जेक्ट फ्रेम के रूप में स्लाइड में एम्बेड करना चाहते हैं, तो आप इसे इस तरह कर सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।  
2. स्लाइड को उसके इंडेक्स द्वारा प्राप्त करें।  
3. Excel फ़ाइल को बाइट एरे के रूप में पढ़ें।  
4. बाइट एरे और OLE ऑब्जेक्ट के अन्य विवरणों के साथ स्लाइड में [OleObjectFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/oleobjectframe) जोड़ें।  
5. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।  

नीचे दिए गए उदाहरण में, हमने Excel फ़ाइल से एक चार्ट को Aspose.Slides for .NET का उपयोग करके एक स्लाइड में [OleObjectFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/oleobjectframe) के रूप में जोड़ा है।  
**ध्यान दें** कि [OleEmbeddedDataInfo](https://reference.aspose.com/slides/hi/net/aspose.slides.dom.ole/oleembeddeddatainfo/) कन्स्ट्रक्टर दूसरा पैरामीटर के रूप में एम्बेडेबल ऑब्जेक्ट एक्स्टेंशन लेता है। यह एक्स्टेंशन PowerPoint को फ़ाइल प्रकार को सही ढंग से समझने और इस OLE ऑब्जेक्ट को खोलने के लिए उचित एप्लिकेशन चुनने में मदद करता है।

```csharp 
using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // OLE ऑब्जेक्ट के लिए डेटा तैयार करें।
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // स्लाइड में OLE ऑब्जेक्ट फ्रेम जोड़ें।
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **लिंक्ड OLE ऑब्जेक्ट फ्रेम जोड़ें**

Aspose.Slides for .NET आपको डेटा एम्बेड किए बिना केवल फ़ाइल के लिंक के साथ एक [OleObjectFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/oleobjectframe) जोड़ने की अनुमति देता है।

यह C# कोड दिखाता है कि कैसे एक लिंक्ड Excel फ़ाइल के साथ एक [OleObjectFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/oleobjectframe) को स्लाइड में जोड़ा जाए:

```csharp 
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // लिंक्ड Excel फ़ाइल के साथ एक OLE ऑब्जेक्ट फ्रेम जोड़ें।
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **OLE ऑब्जेक्ट फ्रेम तक पहुंचें**

यदि कोई OLE ऑब्जेक्ट पहले से ही स्लाइड में एम्बेड किया गया है, तो आप इसे इस तरह आसानी से खोज या एक्सेस कर सकते हैं:

1. एम्बेडेड OLE ऑब्जेक्ट वाली प्रेजेंटेशन को लोड करने के लिए [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।  
2. स्लाइड को उसके इंडेक्स द्वारा प्राप्त करें।  
3. [OleObjectFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/oleobjectframe) शेप को एक्सेस करें। हमारे उदाहरण में, हमने पहले बनाए गए PPTX का उपयोग किया जिसमें पहली स्लाइड पर केवल एक शेप है। फिर हमने उस ऑब्जेक्ट को [IOleObjectFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ioleobjectframe) के रूप में *cast* किया। यही वांछित OLE ऑब्जेक्ट फ्रेम था जिसे एक्सेस किया जाना था।  
4. एक बार OLE ऑब्जेक्ट फ्रेम एक्सेस हो जाने पर, आप उस पर कोई भी ऑपरेशन कर सकते हैं।  

नीचे दिए गए उदाहरण में, एक OLE ऑब्जेक्ट फ्रेम (एक स्लाइड में एम्बेडेड Excel चार्ट ऑब्जेक्ट) और उसके फ़ाइल डेटा को एक्सेस किया गया है।

```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // पहले शेप को OLE ऑब्जेक्ट फ्रेम के रूप में प्राप्त करें।
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // एंबेडेड फ़ाइल डेटा प्राप्त करें।
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // एंबेडेड फ़ाइल का एक्सटेंशन प्राप्त करें।
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **लिंक्ड OLE ऑब्जेक्ट फ्रेम प्रॉपर्टी एक्सेस करें**

Aspose.Slides आपको लिंक्ड OLE ऑब्जेक्ट फ्रेम प्रॉपर्टी एक्सेस करने की सुविधा देता है।

यह C# कोड दिखाता है कि कैसे यह जांचा जाए कि OLE ऑब्जेक्ट लिंक्ड है और फिर लिंक्ड फ़ाइल का पाथ प्राप्त किया जाए:

```csharp
using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // पहले शेप को OLE ऑब्जेक्ट फ्रेम के रूप में प्राप्त करें।
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // जाँचें कि OLE ऑब्जेक्ट लिंक्ड है या नहीं।
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // लिंक्ड फ़ाइल का पूर्ण पाथ प्रिंट करें।
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // यदि मौजूद हो तो लिंक्ड फ़ाइल का रिलेटिव पाथ प्रिंट करें।
        // केवल PPT प्रेजेंटेशन में रिलेटिव पाथ हो सकता है।
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **OLE ऑब्जेक्ट डेटा बदलें**

{{% alert color="primary" %}} 
इस सेक्शन में, नीचे दिया गया कोड उदाहरण [Aspose.Cells for .NET](/cells/net/) का उपयोग करता है। 
{{% /alert %}}

यदि कोई OLE ऑब्जेक्ट पहले से ही स्लाइड में एम्बेड किया गया है, तो आप इसे इस तरह एक्सेस करके उसका डेटा बदल सकते हैं:

1. एम्बेडेड OLE ऑब्जेक्ट वाली प्रेजेंटेशन को लोड करने के लिए [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।  
2. स्लाइड को उसके इंडेक्स द्वारा प्राप्त करें।  
3. [OLEObjectFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/oleobjectframe) शेप को एक्सेस करें। हमारे उदाहरण में, हमने पहले बनाए गए PPTX का उपयोग किया जिसमें पहली स्लाइड पर एक शेप है। फिर हमने उस ऑब्जेक्ट को [IOleObjectFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ioleobjectframe) के रूप में *cast* किया। यही वांछित OLE ऑब्जेक्ट फ्रेम था जिसे एक्सेस किया जाना था।  
4. एक बार OLE ऑब्जेक्ट फ्रेम एक्सेस हो जाने पर, आप उस पर कोई भी ऑपरेशन कर सकते हैं।  
5. एक `Workbook` ऑब्जेक्ट बनाएं और OLE डेटा को एक्सेस करें।  
6. इच्छित `Worksheet` को एक्सेस करें और डेटा में बदलाव करें।  
7. अपडेटेड `Workbook` को एक स्ट्रीम में सहेजें।  
8. स्ट्रीम से OLE ऑब्जेक्ट डेटा बदलें।  

नीचे दिए गए उदाहरण में, एक OLE ऑब्जेक्ट फ्रेम (एक स्लाइड में एम्बेडेड Excel चार्ट ऑब्जेक्ट) को एक्सेस किया गया है, और उसकी फ़ाइल डेटा को संशोधित करके चार्ट डेटा को अपडेट किया गया है।

```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // पहले शेप को OLE ऑब्जेक्ट फ्रेम के रूप में प्राप्त करें।
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // OLE ऑब्जेक्ट डेटा को Workbook ऑब्जेक्ट के रूप में पढ़ें।
            Workbook workbook = new Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // वर्कबुक डेटा को संशोधित करें।
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // OLE फ्रेम ऑब्जेक्ट डेटा बदलें।
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **स्लाइड्स में अन्य फ़ाइल प्रकार एम्बेड करें**

Excel चार्ट के अलावा, Aspose.Slides for .NET आपको स्लाइड्स में विभिन्न प्रकार की फ़ाइलें एम्बेड करने की अनुमति देता है। उदाहरण के लिए, आप HTML, PDF और ZIP फ़ाइलों को ऑब्जेक्ट के रूप में सम्मिलित कर सकते हैं। जब उपयोगकर्ता सम्मिलित ऑब्जेक्ट को डबल‑क्लिक करता है, तो वह स्वतः संबंधित प्रोग्राम में खुल जाता है, या उपयोगकर्ता को उपयुक्त प्रोग्राम चुनने के लिए प्रेरित किया जाता है।

यह C# कोड दिखाता है कि कैसे HTML और ZIP को स्लाइड में एम्बेड किया जाए:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    byte[] htmlData = File.ReadAllBytes("sample.html");
    IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
    IOleObjectFrame htmlOleFrame = slide.Shapes.AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
    htmlOleFrame.IsObjectIcon = true;

    byte[] zipData = File.ReadAllBytes("sample.zip");
    IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
    IOleObjectFrame zipOleFrame = slide.Shapes.AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
    zipOleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **एम्बेडेड ऑब्जेक्ट्स के लिए फ़ाइल प्रकार निर्धारित करें**

प्रेजेंटेशन्स के साथ काम करते समय, आप पुराने OLE ऑब्जेक्ट को नए से बदलना या असमर्थित OLE ऑब्जेक्ट को समर्थित से बदलना चाह सकते हैं। Aspose.Slides for .NET आपको एम्बेडेड ऑब्जेक्ट के फ़ाइल प्रकार को सेट करने की सुविधा देता है, जिससे आप OLE फ्रेम डेटा या उसकी एक्स्टेंशन को अपडेट कर सकते हैं।

यह C# कोड दिखाता है कि कैसे एम्बेडेड OLE ऑब्जेक्ट का फ़ाइल प्रकार `zip` सेट किया जाए:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
    byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

    Console.WriteLine($"Current embedded file extension is: {fileExtension}");

    // फ़ाइल प्रकार को ZIP में बदलें।
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **एम्बेडेड ऑब्जेक्ट्स के लिए आइकन इमेज और शीर्षक निर्धारित करें**

एक OLE ऑब्जेक्ट को एम्बेड करने के बाद, एक प्रीव्यू जिसमें आइकन इमेज होती है, स्वतः जोड़ा जाता है। यह प्रीव्यू वही है जो उपयोगकर्ता OLE ऑब्जेक्ट को एक्सेस या खोलने से पहले देखते हैं। यदि आप प्रीव्यू में विशिष्ट इमेज और टेक्स्ट का उपयोग करना चाहते हैं, तो आप Aspose.Slides for .NET का उपयोग करके आइकन इमेज और शीर्षक सेट कर सकते हैं।

यह C# कोड दिखाता है कि कैसे एम्बेडेड ऑब्जेक्ट के लिए आइकन इमेज और शीर्षक सेट किया जाए: 

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // प्रेजेंटेशन संसाधनों में एक इमेज जोड़ें।
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // OLE प्रीव्यू के लिए शीर्षक और इमेज सेट करें।
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **OLE ऑब्जेक्ट फ्रेम को आकार बदलने और पुनः स्थिति बदलने से रोकें**

जब आप एक लिंक्ड OLE ऑब्जेक्ट को प्रेजेंटेशन स्लाइड में जोड़ते हैं, और PowerPoint में प्रेजेंटेशन खोलते हैं, तो आपको लिंक अपडेट करने का संदेश मिल सकता है। "Update Links" बटन पर क्लिक करने से OLE ऑब्जेक्ट फ्रेम का आकार और स्थिति बदल सकती है क्योंकि PowerPoint लिंक्ड OLE ऑब्जेक्ट से डेटा अपडेट करता है और ऑब्जेक्ट प्रीव्यू को रिफ्रेश करता है। इसे रोकने के लिए, [IOleObjectFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ioleobjectframe/) इंटरफ़ेस की `UpdateAutomatic` प्रॉपर्टी को `false` सेट करें:

```cs
oleFrame.UpdateAutomatic = false;
```

## **एम्बेडेड फ़ाइलें निकालें**

Aspose.Slides for .NET आपको स्लाइड्स में OLE ऑब्जेक्ट के रूप में एम्बेडेड फ़ाइलों को इस प्रकार निकालने की अनुमति देता है:
1. उस [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं जिसमें आप जिन OLE ऑब्जेक्ट्स को निकालना चाहते हैं वे मौजूद हों।  
2. प्रेजेंटेशन में सभी शेप्स के माध्यम से लूप करें और [OLEObjectFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/oleobjectframe) शेप्स को एक्सेस करें।  
3. एम्बेडेड फ़ाइलों का डेटा OLE ऑब्जेक्ट फ्रेम से एक्सेस करें और उसे डिस्क पर लिखें।  

यह C# कोड दिखाता है कि कैसे एक स्लाइड में OLE ऑब्जेक्ट के रूप में एम्बेडेड फ़ाइलों को निकाला जाए:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    for (int index = 0; index < slide.Shapes.Count; index++)
    {
        IShape shape = slide.Shapes[index];
        IOleObjectFrame oleFrame = shape as IOleObjectFrame;

        if (oleFrame != null)
        {
            byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;
            string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

            string filePath = $"OLE_object_{index}{fileExtension}";
            File.WriteAllBytes(filePath, fileData);
        }
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या स्लाइड्स को PDF/इमेज में निर्यात करते समय OLE कंटेंट रेंडर होगा?**  
स्लाइड पर जो दिखाई देता है वह रेंडर किया जाता है—आइकन/सब्स्टीट्यूट इमेज (प्रीव्यू)। "लाइव" OLE कंटेंट रेंडरिंग के दौरान निष्पादित नहीं होता। यदि आवश्यक हो, तो अपने स्वयं के प्रीव्यू इमेज को सेट करें ताकि निर्यातित PDF में अपेक्षित रूप दिखे।

**मैं स्लाइड पर OLE ऑब्जेक्ट को कैसे लॉक करूँ ताकि उपयोगकर्ता PowerPoint में इसे स्थानांतरित/संपादित न कर सकें?**  
शेप को लॉक करें: Aspose.Slides [shape‑level locks](/slides/hi/net/applying-protection-to-presentation/) प्रदान करता है। यह एन्क्रिप्शन नहीं है, लेकिन यह आकस्मिक संपादन और मूवमेंट को प्रभावी रूप से रोकता है।

**जब मैं प्रेजेंटेशन खोलता हूँ तो लिंक्ड Excel ऑब्जेक्ट "जम्प" करता है या आकार बदल जाता है, क्यों?**  
PowerPoint लिंक्ड OLE का प्रीव्यू रिफ्रेश कर सकता है। स्थिर दिखावट के लिए, [Worksheet Resizing के लिए वर्किंग सॉल्यूशन](/slides/hi/net/working-solution-for-worksheet-resizing/) के अभ्यासों का पालन करें—या तो फ्रेम को रेंज के अनुरूप फिट करें, या रेंज को स्थिर फ्रेम में स्केल करें और उपयुक्त सब्स्टीट्यूट इमेज सेट करें।

**क्या PPTX फॉर्मेट में लिंक्ड OLE ऑब्जेक्ट्स के रिलेटिव पाथ्स संरक्षित रहते हैं?**  
PPTX में "रिलेटिव पाथ" जानकारी उपलब्ध नहीं होती—केवल पूर्ण पाथ। रिलेटिव पाथ्स पुराने PPT फॉर्मेट में मिलते हैं। पोर्टेबिलिटी के लिए विश्वसनीय एब्सोल्यूट पाथ्स/एक्सेसिबल URIs या एम्बेडिंग को प्राथमिकता दें।