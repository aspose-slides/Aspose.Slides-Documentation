---
title: .NET में प्रेजेंटेशन में OLE ऑब्जेक्ट्स प्रबंधित करें
linktitle: OLE प्रबंधित करें
type: docs
weight: 40
url: /hi/net/manage-ole/
keywords:
- OLE ऑब्जेक्ट
- ऑब्जेक्ट लिंकिंग एवं एम्बेडिंग
- OLE जोड़ें
- OLE एम्बेड करें
- ऑब्जेक्ट जोड़ें
- ऑब्जेक्ट एम्बेड करें
- फ़ाइल जोड़ें
- फ़ाइल एम्बेड करें
- जुड़ा ऑब्जेक्ट
- जुड़ी फ़ाइल
- OLE बदलें
- OLE आइकन
- OLE शीर्षक
- OLE निकालें
- ऑब्जेक्ट निकालें
- फ़ाइल निकालें
- PowerPoint
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint और OpenDocument फ़ाइलों में OLE ऑब्जेक्ट प्रबंधन को अनुकूलित करें। OLE सामग्री को सहजता से एम्बेड, अपडेट और निर्यात करें।"
---
## **परिचय**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) माइक्रोसॉफ्ट की एक तकनीक है जो एक एप्लिकेशन में निर्मित डेटा और वस्तुओं को लिंकिंग या एंबेडिंग के माध्यम से दूसरे एप्लिकेशन में रखने की अनुमति देती है।

{{% /alert %}} 

मान लें कि MS Excel में एक चार्ट बनाया गया है। फिर वह चार्ट PowerPoint स्लाइड में रख दिया जाता है। वह Excel चार्ट एक OLE ऑब्जेक्ट माना जाता है। 

- एक OLE ऑब्जेक्ट एक आइकन के रूप में दिखा सकता है। इस स्थिति में, जब आप आइकन पर डबल-क्लिक करते हैं, तो चार्ट अपने सम्बद्ध एप्लिकेशन (Excel) में खुल जाता है, या आपसे ऑब्जेक्ट को खोलने या संपादित करने के लिए एक एप्लिकेशन चुनने को कहा जाता है। 
- एक OLE ऑब्जेक्ट अपनी वास्तविक सामग्री प्रदर्शित कर सकता है, जैसे कि चार्ट की सामग्री। इस स्थिति में, चार्ट PowerPoint में सक्रिय हो जाता है, चार्ट इंटरफ़ेस लोड होता है, और आप PowerPoint के भीतर चार्ट के डेटा को संशोधित कर सकते हैं। 

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) आपको OLE ऑब्जेक्ट्स को स्लाइड्स में OLE ऑब्जेक्ट फ्रेम के रूप में सम्मिलित करने की अनुमति देता है ([OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)).

## **स्लाइड्स में OLE ऑब्जेक्ट फ्रेम जोड़ें**

मान लें कि आप पहले ही Microsoft Excel में एक चार्ट बना चुके हैं और इसे Aspose.Slides for .NET का उपयोग करके OLE ऑब्जेक्ट फ्रेम के रूप में स्लाइड में एंबेड करना चाहते हैं, आप इसे इस तरह कर सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. Excel फ़ाइल को बाइट एरे के रूप में पढ़ें।  
4. स्लाइड में बाइट एरे और OLE ऑब्जेक्ट के बारे में अन्य जानकारी सहित [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) जोड़ें।  
5. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।  

नीचे दिए गए उदाहरण में, हमने Excel फ़ाइल से एक चार्ट को Aspose.Slides for .NET का उपयोग करके एक [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) के रूप में स्लाइड में जोड़ा।  
**ध्यान दें** कि [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) कंस्ट्रक्टर दूसरा पैरामीटर के रूप में एक एंबेडेबल ऑब्जेक्ट एक्सटेंशन लेता है। यह एक्सटेंशन PowerPoint को फ़ाइल प्रकार को सही ढंग से समझने और इस OLE ऑब्जेक्ट को खोलने के लिए सही एप्लिकेशन चुनने में सक्षम बनाता है।

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

    // स्लाइड में OLE ऑब्जेक्ट फ्रेम जोड़ें।
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **जुड़े हुए OLE ऑब्जेक्ट फ्रेम जोड़ें**

Aspose.Slides for .NET आपको डेटा एंबेड किए बिना, केवल फ़ाइल के लिंक के साथ एक [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) जोड़ने की अनुमति देता है।

यह C# कोड आपको दिखाता है कि कैसे एक जुड़े हुए Excel फ़ाइल के साथ [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) को स्लाइड में जोड़ें:

```csharp 
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // जुड़ी हुई Excel फ़ाइल के साथ एक OLE ऑब्जेक्ट फ्रेम जोड़ें।
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **OLE ऑब्जेक्ट फ्रेम तक पहुँच**

यदि कोई OLE ऑब्जेक्ट पहले से ही स्लाइड में एंबेड किया गया है, तो आप इसे इस तरह आसानी से खोज या पहुँच सकते हैं:

1. एंबेडेड OLE ऑब्जेक्ट वाले प्रेजेंटेशन को [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाकर लोड करें।  
2. उसके इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।  
3. [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) आकार तक पहुँचें। हमारे उदाहरण में, हमने पहले बनाई गई PPTX का उपयोग किया जिसमें पहली स्लाइड पर केवल एक आकार है। फिर हमने उस ऑब्जेक्ट को [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe) के रूप में *cast* किया। यह वह वांछित OLE ऑब्जेक्ट फ्रेम था जिसे एक्सेस करना था।  
4. एक बार OLE ऑब्जेक्ट फ्रेम तक पहुँचने के बाद, आप उस पर कोई भी ऑपरेशन कर सकते हैं।  

नीचे दिए गए उदाहरण में, एक OLE ऑब्जेक्ट फ्रेम (एक स्लाइड में एंबेड किया गया Excel चार्ट ऑब्जेक्ट) और उसकी फ़ाइल डेटा तक पहुँच प्राप्त की गई है।

```csharp 
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // पहले आकार को OLE ऑब्जेक्ट फ्रेम के रूप में प्राप्त करें।
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

### **जुड़े हुए OLE ऑब्जेक्ट फ्रेम गुणों तक पहुँच**

Aspose.Slides आपको जुड़े हुए OLE ऑब्जेक्ट फ्रेम के गुणों तक पहुँच प्रदान करता है।

यह C# कोड आपको दिखाता है कि कैसे जांचें कि OLE ऑब्जेक्ट जुड़ा हुआ है और फिर जुड़े फ़ाइल का पथ प्राप्त करें:

```csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // पहले आकार को OLE ऑब्जेक्ट फ्रेम के रूप में प्राप्त करें।
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // जाँचें कि OLE ऑब्जेक्ट जुड़ा है या नहीं।
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // जुड़ी फ़ाइल का पूर्ण पथ प्रिंट करें।
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // यदि मौजूद हो तो जुड़ी फ़ाइल का सापेक्ष पथ प्रिंट करें।
        // केवल PPT प्रेजेंटेशन्स में सापेक्ष पथ हो सकता है।
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **OLE ऑब्जेक्ट डेटा बदलें**

{{% alert color="info" title="Note" %}}

इस अनुभाग में, नीचे दिया गया कोड उदाहरण [Aspose.Cells for .NET](https://docs.aspose.com/cells/net/) का उपयोग करता है।

{{% /alert %}}

यदि कोई OLE ऑब्जेक्ट पहले से ही स्लाइड में एंबेड किया गया है, तो आप इस तरह आसानी से उस ऑब्जेक्ट तक पहुँच सकते हैं और उसके डेटा को संशोधित कर सकते हैं:

1. एंबेडेड OLE ऑब्जेक्ट वाला प्रेजेंटेशन को [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाकर लोड करें।  
2. उसके इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) आकार तक पहुँचें। हमारे उदाहरण में, हमने पहले बनाई गई PPTX का उपयोग किया जिसमें पहली स्लाइड पर एक आकार है। फिर हमने उस ऑब्जेक्ट को [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe) के रूप में *cast* किया। यह वह वांछित OLE ऑब्जेक्ट फ्रेम था जिसे एक्सेस किया जाना था।  
4. एक बार OLE ऑब्जेक्ट फ्रेम तक पहुँचने के बाद, आप उस पर कोई भी ऑपरेशन कर सकते हैं।  
5. एक `Workbook` ऑब्जेक्ट बनाएं और OLE डेटा तक पहुँचें।  
6. इच्छित `Worksheet` तक पहुँचें और डेटा में संशोधन करें।  
7. अद्यतन `Workbook` को एक स्ट्रीम में सहेजें।  
8. स्ट्रीम से OLE ऑब्जेक्ट डेटा बदलें।  

नीचे दिए गए उदाहरण में, एक OLE ऑब्जेक्ट फ्रेम (स्लाइड में एंबेड किया गया Excel चार्ट ऑब्जेक्ट) तक पहुँच प्राप्त की गई है, और उसकी फ़ाइल डेटा को चार्ट डेटा को अपडेट करने के लिए संशोधित किया गया है।

```csharp 
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // पहले आकार को OLE ऑब्जेक्ट फ्रेम के रूप में प्राप्त करें।
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // OLE ऑब्जेक्ट डेटा को Workbook ऑब्जेक्ट के रूप में पढ़ें।
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // वर्कबुक डेटा संशोधित करें।
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

## **स्लाइड्स में अन्य फ़ाइल प्रकार एंबेड करें**

Excel चार्ट के अलावा, Aspose.Slides for .NET आपको स्लाइड्स में अन्य प्रकार की फ़ाइलें एंबेड करने की अनुमति देता है। उदाहरण के लिए, आप HTML, PDF, और ZIP फ़ाइलों को ऑब्जेक्ट के रूप में सम्मिलित कर सकते हैं। जब कोई उपयोगकर्ता सम्मिलित ऑब्जेक्ट पर डबल-क्लिक करता है, तो यह स्वचालित रूप से संबंधित प्रोग्राम में खुल जाता है, या उपयोगकर्ता को इसे खोलने के लिए उपयुक्त प्रोग्राम चुनने के लिए प्रेरित किया जाता है।

यह C# कोड आपको दिखाता है कि कैसे HTML और ZIP को स्लाइड में एंबेड किया जाए:

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

## **एंबेडेड ऑब्जेक्ट्स के लिए फ़ाइल प्रकार निर्धारित करें**

प्रेजेंटेशन के साथ काम करते समय, आपको पुराने OLE ऑब्जेक्ट्स को नए से बदलना पड़ सकता है या असमर्थित OLE ऑब्जेक्ट को समर्थित से बदलना पड़ सकता है। Aspose.Slides for .NET आपको एंबेडेड ऑब्जेक्ट के लिए फ़ाइल प्रकार सेट करने की अनुमति देता है, जिससे आप OLE फ्रेम डेटा या उसके एक्सटेंशन को अपडेट कर सकते हैं।

यह C# कोड आपको दिखाता है कि कैसे एंबेडेड OLE ऑब्जेक्ट का फ़ाइल प्रकार `zip` सेट किया जाए:

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

## **एंबेडेड ऑब्जेक्ट्स के लिए आइकन इमेज और शीर्षक सेट करें**

OLE ऑब्जेक्ट को एंबेड करने के बाद, एक आइकन इमेज से बनी प्रीव्यू स्वचालित रूप से जोड़ दी जाती है। यह प्रीव्यू वह है जो उपयोगकर्ता OLE ऑब्जेक्ट को एक्सेस या खोलने से पहले देखते हैं। यदि आप प्रीव्यू में विशिष्ट इमेज और टेक्स्ट को तत्वों के रूप में उपयोग करना चाहते हैं, तो आप Aspose.Slides for .NET का उपयोग करके आइकन इमेज और शीर्षक सेट कर सकते हैं।

यह C# कोड आपको दिखाता है कि कैसे एंबेडेड ऑब्जेक्ट के लिए आइकन इमेज और शीर्षक सेट किया जाए: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // प्रेजेंटेशन संसाधनों में एक छवि जोड़ें।
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // OLE प्रीव्यू के लिए शीर्षक और छवि सेट करें।
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **OLE ऑब्जेक्ट फ्रेम को आकार बदलने और पुनःस्थिति करने से रोकें**

जब आप एक जुड़ा हुआ OLE ऑब्जेक्ट प्रेजेंटेशन स्लाइड में जोड़ते हैं, और PowerPoint में प्रेजेंटेशन खोलते हैं, तो आपको लिंक अपडेट करने का संदेश दिख सकता है। "Update Links" बटन पर क्लिक करने से OLE ऑब्जेक्ट फ्रेम का आकार और स्थिति बदल सकती है क्योंकि PowerPoint जुड़े OLE ऑब्जेक्ट से डेटा अपडेट करता है और ऑब्जेक्ट प्रीव्यू को रीफ़्रेश करता है। PowerPoint को ऑब्जेक्ट डेटा अपडेट करने के लिए प्रेरित होने से रोकने के लिए, [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) इंटरफ़ेस की `UpdateAutomatic` प्रॉपर्टी को `false` सेट करें:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // PowerPoint लिंक को अपडेट करने पर OLE ऑब्जेक्ट फ्रेम का आकार और स्थिति बरकरार रखें।
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **एंबेडेड फ़ाइलों को निकालें**

Aspose.Slides for .NET आपको स्लाइड्स में एंबेडेड फ़ाइलों को OLE ऑब्जेक्ट्स के रूप में इस प्रकार निकालने की अनुमति देता है:
1. वह [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं जिसमें आप निकालने वाले OLE ऑब्जेक्ट्स हों।  
2. प्रेजेंटेशन में सभी आकारों (shapes) के माध्यम से लूप करें और [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) आकारों तक पहुँचें।  
3. OLE ऑब्जेक्ट फ्रेम से एंबेडेड फ़ाइलों का डेटा एक्सेस करें और इसे डिस्क पर लिखें।  

यह C# कोड आपको दिखाता है कि कैसे स्लाइड में एंबेडेड फ़ाइलों को OLE ऑब्जेक्ट्स के रूप में निकाला जाए:

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

## **FAQ**

**क्या OLE सामग्री स्लाइड्स को PDF/छवियों में निर्यात करते समय रेंडर होगी?**

जिस चीज़ को स्लाइड पर दिखाया जाता है, वह रेंडर होती है—आइकन/सबस्टीट्यूट इमेज (प्रीव्यू)। "live" OLE सामग्री रेंडरिंग के दौरान निष्पादित नहीं होती। यदि आवश्यक हो, तो निर्यातित PDF में अपेक्षित दिखावट सुनिश्चित करने के लिए अपना स्वयं का प्रीव्यू इमेज सेट करें।  
एंबेडेड फ़ाइल को PDF अटैचमेंट के रूप में भी संरक्षित करने के लिए, [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) को `true` सेट करें। यह विकल्प डिफ़ॉल्ट रूप से अक्षम है। उदाहरण और अटैचमेंट की जाँच करने के निर्देश के लिए देखें [Preserve Embedded OLE Files as PDF Attachments](/slides/hi/net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments)।

**मैं एक OLE ऑब्जेक्ट को स्लाइड पर कैसे लॉक करूँ ताकि उपयोगकर्ता इसे PowerPoint में नहीं हिला/संपादित कर सकें?**

शेप को लॉक करें: Aspose.Slides [shape-level locks](/slides/hi/net/applying-protection-to-presentation/) प्रदान करता है। यह एन्क्रिप्शन नहीं है, लेकिन यह आकस्मिक संपादन और आंदोलन को प्रभावी रूप से रोकता है।

**जब मैं प्रेजेंटेशन खोलता हूँ तो जुड़ा हुआ Excel ऑब्जेक्ट "जम्प" क्यों करता है या आकार बदलता है?**

PowerPoint जुड़े हुए OLE का प्रीव्यू रीफ़्रेश कर सकता है। स्थिर दिखावट के लिए, [Working Solution for Worksheet Resizing](/slides/hi/net/working-solution-for-worksheet-resizing/) के अभ्यासों का पालन करें—या तो फ्रेम को रेंज के अनुसार फिट करें, या रेंज को एक निश्चित फ्रेम में स्केल करें और उचित सब्स्टीट्यूट इमेज सेट करें।

**क्या PPTX फ़ॉर्मेट में जुड़े OLE ऑब्जेक्ट्स के रिलेटिव पाथ संरक्षित रहेंगे?**

PPTX में "relative path" जानकारी उपलब्ध नहीं है—केवल पूरा पाथ होता है। रिलेटिव पाथ्स पुरानी PPT फ़ॉर्मेट में मिलते हैं। पोर्टेबिलिटी के लिए, विश्वसनीय एब्सॉल्यूट पाथ/एक्सेसिबल URI या एंबेडिंग को प्राथमिकता दें।