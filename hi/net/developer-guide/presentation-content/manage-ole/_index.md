---
title: .NET में प्रस्तुतियों में OLE ऑब्जेक्ट्स का प्रबंधन
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
  - प्रस्तुति
  - .NET
  - C#
  - Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint और OpenDocument फ़ाइलों में OLE ऑब्जेक्ट प्रबंधन को अनुकूलित करें। OLE सामग्री को सहजता से एम्बेड, अपडेट और निर्यात करें।"
---
## **परिचय**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) एक Microsoft तकनीक है जो एक एप्लिकेशन में निर्मित डेटा और ऑब्जेक्ट्स को लिंकिंग या एम्बेडिंग के माध्यम से दूसरे एप्लिकेशन में रखने की अनुमति देती है।

{{% /alert %}} 

एक चार्ट को MS Excel में बनाया गया मान लें। फिर वह चार्ट PowerPoint स्लाइड के अंदर रखा जाता है। वह Excel चार्ट एक OLE ऑब्जेक्ट माना जाता है। 

- एक OLE ऑब्जेक्ट आइकन के रूप में दिखाई दे सकता है। इस स्थिति में, जब आप आइकन पर डबल‑क्लिक करते हैं, तो चार्ट अपने संबद्ध एप्लिकेशन (Excel) में खुलता है, या आपको ऑब्जेक्ट खोलने या संपादित करने के लिए एक एप्लिकेशन चुनने के लिए कहा जाता है। 
- एक OLE ऑब्जेक्ट अपने वास्तविक सामग्री, जैसे कि चार्ट की सामग्री, प्रदर्शित कर सकता है। इस स्थिति में, चार्ट PowerPoint में सक्रिय हो जाता है, चार्ट इंटरफ़ेस लोड होता है, और आप PowerPoint के भीतर चार्ट डेटा को संशोधित कर सकते हैं।

[Aspose.Slides for .NET](https://products.aspose.com/slides/hi/net/) आपको स्लाइड्स में OLE ऑब्जेक्ट्स को OLE ऑब्जेक्ट फ्रेम ([OleObjectFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/oleobjectframe)) के रूप में सम्मिलित करने की अनुमति देता है।

## **स्लाइड्स में OLE ऑब्जेक्ट फ्रेम जोड़ें**

मान लें कि आपने Microsoft Excel में पहले से ही एक चार्ट बनाया है और आप इसे Aspose.Slides for .NET का उपयोग करके OLE ऑब्जेक्ट फ्रेम के रूप में स्लाइड में एम्बेड करना चाहते हैं, तो आप इसे इस प्रकार कर सकते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का इंस्टेंस बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का रेफरेंस प्राप्त करें।  
3. Excel फ़ाइल को बाइट ऐरे के रूप में पढ़ें।  
4. OLE ऑब्जेक्ट के बारे में बाइट ऐरे और अन्य जानकारी के साथ स्लाइड में [OleObjectFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/oleobjectframe) जोड़ें।  
5. परिवर्तित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।  

नीचे दिए गए उदाहरण में, हमने Aspose.Slides for .NET का उपयोग करके Excel फ़ाइल से एक चार्ट को स्लाइड में एक [OleObjectFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/oleobjectframe) के रूप में जोड़ा है।  
**ध्यान दें** कि [OleEmbeddedDataInfo](https://reference.aspose.com/slides/hi/net/aspose.slides.dom.ole/oleembeddeddatainfo/) कंस्ट्रक्टर दूसरे पैरामीटर के रूप में एम्बेडेबल ऑब्जेक्ट एक्सटेंशन लेता है। यह एक्सटेंशन PowerPoint को फ़ाइल प्रकार को सही ढंग से समझने और इस OLE ऑब्जेक्ट को खोलने के लिए उपयुक्त एप्लिकेशन चुनने की अनुमति देता है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // OLE ऑब्जेक्ट के लिए डेटा तैयार करें।
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // OLE ऑब्जेक्ट फ्रेम को स्लाइड में जोड़ें।
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **लिंक्ड OLE ऑब्जेक्ट फ्रेम जोड़ें**

Aspose.Slides for .NET आपको डेटा एम्बेड किए बिना, केवल फ़ाइल के लिंक के साथ एक [OleObjectFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/oleobjectframe) जोड़ने की अनुमति देता है।

यह C# कोड आपको दिखाता है कि कैसे एक लिंक्ड Excel फ़ाइल के साथ एक [OleObjectFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/oleobjectframe) को स्लाइड में जोड़ा जाए:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // लिंक्ड Excel फ़ाइल के साथ OLE ऑब्जेक्ट फ्रेम जोड़ें।
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **OLE ऑब्जेक्ट फ्रेम तक पहुंचें**

यदि एक OLE ऑब्जेक्ट पहले से ही स्लाइड में एम्बेडेड है, तो आप इसे इस तरह आसानी से खोज या एक्सेस कर सकते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का इंस्टेंस बनाकर एम्बेडेड OLE ऑब्जेक्ट वाली प्रेजेंटेशन लोड करें।  
2. इंडेक्स का उपयोग करके स्लाइड का रेफरेंस प्राप्त करें।  
3. [OleObjectFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/oleobjectframe) आकार (shape) तक पहुंचें।  
   हमारे उदाहरण में, हमने पहले से बनाए गए PPTX का उपयोग किया जिसमें पहली स्लाइड पर केवल एक shape था। फिर हमने उस ऑब्जेक्ट को *cast* करके एक [IOleObjectFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ioleobjectframe) बना दिया। यह वही वांछित OLE ऑब्जेक्ट फ्रेम था जिसे एक्सेस करना था।  
4. एक बार OLE ऑब्जेक्ट फ्रेम एक्सेस हो जाने पर, आप उस पर कोई भी ऑपरेशन कर सकते हैं।

नीचे के उदाहरण में, एक OLE ऑब्जेक्ट फ्रेम (स्लाइड में एम्बेडेड Excel चार्ट ऑब्जेक्ट) और उसकी फ़ाइल डेटा को एक्सेस किया गया है।

```csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // पहले शेप को OLE ऑब्जेक्ट फ्रेम के रूप में प्राप्त करें।
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // एम्बेडेड फ़ाइल डेटा प्राप्त करें।
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // एम्बेडेड फ़ाइल का एक्सटेंशन प्राप्त करें।
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **लिंक्ड OLE ऑब्जेक्ट फ्रेम प्रॉपर्टीज़ तक पहुंचें**

Aspose.Slides आपको लिंक्ड OLE ऑब्जेक्ट फ्रेम की प्रॉपर्टीज़ तक पहुंचने की अनुमति देता है।

यह C# कोड दिखाता है कि कैसे यह जांचा जाए कि OLE ऑब्जेक्ट लिंक्ड है और फिर लिंक्ड फ़ाइल का पाथ प्राप्त किया जाए:

```csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // पहले शेप को OLE ऑब्जेक्ट फ्रेम के रूप में प्राप्त करें।
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // जांचें कि OLE ऑब्जेक्ट लिंक्ड है या नहीं।
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // लिंक्ड फ़ाइल का पूर्ण पथ प्रिंट करें।
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // यदि मौजूद हो तो लिंक्ड फ़ाइल का रिलेटिव पथ प्रिंट करें।
        // केवल PPT प्रस्तुतियों में रिलेटिव पथ हो सकता है।
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **OLE ऑब्जेक्ट डेटा बदलें**

{{% alert color="info" %}} 

इस अनुभाग में, नीचे दिया गया कोड उदाहरण [Aspose.Cells for .NET](/cells/net/) का उपयोग करता है।

{{% /alert %}}

यदि एक OLE ऑब्जेक्ट स्लाइड में पहले से ही एम्बेडेड है, तो आप इस तरह आसानी से उस ऑब्जेक्ट को एक्सेस करके उसका डेटा संशोधित कर सकते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का इंस्टेंस बनाकर एम्बेडेड OLE ऑब्जेक्ट वाली प्रेजेंटेशन लोड करें।  
2. इंडेक्स के माध्यम से स्लाइड का रेफरेंस प्राप्त करें।  
3. [OLEObjectFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/oleobjectframe) आकार तक पहुंचें।  
   हमारे उदाहरण में, हमने पहले से बनाए गए PPTX का उपयोग किया जिसमें पहली स्लाइड पर एक shape था। फिर हमने उस ऑब्जेक्ट को *cast* करके एक [IOleObjectFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ioleobjectframe) बना दिया। यह वही वांछित OLE ऑब्जेक्ट फ्रेम था जिसे एक्सेस करना था।  
4. एक बार OLE ऑब्जेक्ट फ्रेम एक्सेस हो जाने पर, आप उस पर कोई भी ऑपरेशन कर सकते हैं।  
5. `Workbook` ऑब्जेक्ट बनाएं और OLE डेटा तक पहुंचें।  
6. इच्छित `Worksheet` तक पहुंचें और डेटा में संशोधन करें।  
7. अद्यतित `Workbook` को एक स्ट्रीम में सहेजें।  
8. स्ट्रीम से OLE ऑब्जेक्ट डेटा बदलें।  

नीचे के उदाहरण में, एक OLE ऑब्जेक्ट फ्रेम (स्लाइड में एम्बेडेड Excel चार्ट ऑब्जेक्ट) को एक्सेस किया गया है, और उसके फ़ाइल डेटा को चार्ट डेटा को अपडेट करने के लिए संशोधित किया गया है।

```csharp
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

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
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Workbook डेटा को संशोधित करें।
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                Aspose.Cells.OoxmlSaveOptions fileOptions = new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
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

Excel चार्ट के अलावा, Aspose.Slides for .NET आपको स्लाइड्स में अन्य प्रकार की फ़ाइलें एम्बेड करने की अनुमति देता है। उदाहरण के लिए, आप HTML, PDF, और ZIP फ़ाइलों को ऑब्जेक्ट के रूप में सम्मिलित कर सकते हैं। जब उपयोगकर्ता सम्मिलित ऑब्जेक्ट पर डबल‑क्लिक करता है, तो वह स्वचालित रूप से संबंधित प्रोग्राम में खुल जाता है, या उपयोगकर्ता को इसे खोलने के लिए उपयुक्त प्रोग्राम चुनने के लिए कहा जाता है।

यह C# कोड दिखाता है कि कैसे HTML और ZIP को स्लाइड में एम्बेड किया जाए:

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

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

## **एम्बेडेड ऑब्जेक्ट्स के फ़ाइल प्रकार सेट करें**

प्रेजेंटेशन के साथ काम करते समय, आपको पुराने OLE ऑब्जेक्ट्स को नए से बदलना पड़ सकता है या असमर्थित OLE ऑब्जेक्ट को समर्थित से बदलना पड़ सकता है। Aspose.Slides for .NET आपको एम्बेडेड ऑब्जेक्ट के फ़ाइल प्रकार को सेट करने की अनुमति देता है, जिससे आप OLE फ्रेम डेटा या उसकी एक्सटेंशन को अपडेट कर सकते हैं।

यह C# कोड दिखाता है कि कैसे एम्बेडेड OLE ऑब्जेक्ट के फ़ाइल प्रकार को `zip` पर सेट किया जाए:

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

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

## **एम्बेडेड ऑब्जेक्ट्स के लिए आइकन इमेज और शीर्षक सेट करें**

एक OLE ऑब्जेक्ट को एम्बेड करने के बाद, एक आइकन इमेज से बनी पूर्वावलोकन स्वचालित रूप से जोड़ दी जाती है। यह पूर्वावलोकन वही है जिसे उपयोगकर्ता OLE ऑब्जेक्ट तक पहुंचने या खोलने से पहले देखते हैं। यदि आप पूर्वावलोकन में एक विशिष्ट इमेज और टेक्स्ट का उपयोग करना चाहते हैं, तो आप Aspose.Slides for .NET का उपयोग करके आइकन इमेज और शीर्षक सेट कर सकते हैं।

यह C# कोड दिखाता है कि कैसे एम्बेडेड ऑब्जेक्ट के लिए आइकन इमेज और शीर्षक सेट किया जाए: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // प्रस्तुति संसाधनों में एक छवि जोड़ें।
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // OLE पूर्वावलोकन के लिए शीर्षक और छवि सेट करें।
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **OLE ऑब्जेक्ट फ्रेम को आकार बदलने और स्थान बदलने से रोकें**

जब आप एक लिंक्ड OLE ऑब्जेक्ट को प्रेजेंटेशन स्लाइड में जोड़ते हैं, और PowerPoint में प्रेजेंटेशन खोलते हैं, तो आपको लिंक अपडेट करने का संदेश दिखाई दे सकता है। "Update Links" बटन पर क्लिक करने से OLE ऑब्जेक्ट फ्रेम का आकार और स्थिति बदल सकती है क्योंकि PowerPoint लिंक्ड OLE ऑब्जेक्ट से डेटा अपडेट करता है और ऑब्जेक्ट पूर्वावलोकन को रीफ़्रेश करता है। PowerPoint को ऑब्जेक्ट का डेटा अपडेट करने के लिए प्रेरित होने से रोकने हेतु, [IOleObjectFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ioleobjectframe/) इंटरफ़ेस की `UpdateAutomatic` प्रॉपर्टी को `false` सेट करें:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // PowerPoint लिंक अपडेट करने पर OLE ऑब्जेक्ट फ्रेम का आकार और स्थिति बनाए रखें।
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **एम्बेडेड फ़ाइलें निकालें**

Aspose.Slides for .NET आपको स्लाइड्स में एम्बेडेड फ़ाइलों को OLE ऑब्जेक्ट के रूप में इस प्रकार निकालने की अनुमति देता है:

1. ऐसी [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का इंस्टेंस बनाएं जिसमें आप निकालना चाहते हैं OLE ऑब्जेक्ट्स हों।  
2. प्रेजेंटेशन में सभी shapes पर लूप करें और [OLEObjectFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/oleobjectframe) shapes तक पहुंचें।  
3. OLE ऑब्जेक्ट फ्रेम से एम्बेडेड फ़ाइलों का डेटा एक्सेस करके उसे डिस्क पर लिखें।  

यह C# कोड दिखाता है कि कैसे स्लाइड में एम्बेडेड फ़ाइलों को OLE ऑब्जेक्ट्स के रूप में निकाला जाए:

```c#
using Aspose.Slides;

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

### क्या स्लाइड्स को PDF/इमेजेज़ में एक्सपोर्ट करने पर OLE कंटेंट रेंडर होगा?

स्लाइड पर जो दिखता है वह रेंडर किया जाता है—आइकन/प्लेसहोल्डर इमेज (पूर्वावलोकन)। "लाइव" OLE कंटेंट रेंडरिंग के दौरान निष्पादित नहीं होता। यदि आवश्यक हो, तो निर्यातित PDF में अपेक्षित रूप सुनिश्चित करने के लिए अपना स्वयं का पूर्वावलोकन इमेज सेट करें।

### मैं स्लाइड पर OLE ऑब्जेक्ट को कैसे लॉक करूँ ताकि उपयोगकर्ता इसे PowerPoint में मूव/एडिट ना कर सकें?

शेप को लॉक करें: Aspose.Slides [shape-level locks](/slides/hi/net/applying-protection-to-presentation/) प्रदान करता है। यह एन्क्रिप्शन नहीं है, लेकिन यह आकस्मिक संपादन और मूवमेंट को प्रभावी रूप से रोकता है।

### जब मैं प्रेजेंटेशन खोलता हूँ तो लिंक्ड Excel ऑब्जेक्ट "जम्प" क्यों करता है या आकार बदलता है?

PowerPoint लिंक्ड OLE के पूर्वावलोकन को रीफ़्रेश कर सकता है। स्थिर रूप के लिए, [Working Solution for Worksheet Resizing](/slides/hi/net/working-solution-for-worksheet-resizing/) के अभ्यास का पालन करें—या तो फ्रेम को रेंज के अनुसार फिट करें, या रेंज को एक स्थिर फ्रेम में स्केल करें और उपयुक्त प्लेसहोल्डर इमेज सेट करें।

### क्या PPTX फ़ॉर्मेट में लिंक्ड OLE ऑब्जेक्ट्स के रिलेटिव पाथ सुरक्षित रहेंगे?

PPTX में "relative path" जानकारी उपलब्ध नहीं है—केवल पूर्ण पाथ। रिलेटिव पाथ पुराने PPT फ़ॉर्मेट में पाए जाते हैं। पोर्टेबिलिटी के लिए, विश्वसनीय एब्सोल्यूट पाथ/एक्सेसिबल URI या एम्बेडिंग को प्राथमिकता दें।