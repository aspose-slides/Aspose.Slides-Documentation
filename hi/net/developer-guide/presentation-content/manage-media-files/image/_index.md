---
title: .NET में प्रस्तुतियों में छवि प्रबंधन को अनुकूलित करें
linktitle: छवियों को प्रबंधित करें
type: docs
weight: 10
url: /hi/net/image/
keywords:
- छवि जोड़ें
- चित्र जोड़ें
- बिटमैप जोड़ें
- छवि बदलें
- चित्र बदलें
- वेब से
- पृष्ठभूमि
- PNG जोड़ें
- JPG जोड़ें
- SVG जोड़ें
- EMF जोड़ें
- WMF जोड़ें
- TIFF जोड़ें
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint और OpenDocument में छवि प्रबंधन को सरल बनाएं, प्रदर्शन को अनुकूलित करें और आपके कार्यप्रवाह को स्वचालित करें।"
---
## **परिचय**

छवियां प्रस्तुतियों को अधिक आकर्षक और रोचक बनाती हैं। Microsoft PowerPoint में, आप फ़ाइल, इंटरनेट या अन्य स्थानों से चित्रों को स्लाइड्स में सम्मिलित कर सकते हैं। इसी तरह, Aspose.Slides आपको विभिन्न प्रक्रियाओं के माध्यम से अपनी प्रस्तुतियों में स्लाइड्स पर छवियां जोड़ने की अनुमति देता है।

{{% alert  title="टिप" color="primary" %}} 

Aspose मुफ्त रूपांतरण उपकरण प्रदान करता है—[JPEG से PowerPoint](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG से PowerPoint](https://products.aspose.app/slides/hi/import/png-to-ppt)—जो लोगों को छवियों से तेज़ी से प्रस्तुतियां बनाने में सक्षम बनाते हैं। 

{{% /alert %}} 

{{% alert title="जानकारी" color="info" %}}

यदि आप किसी छवि को फ़्रेम ऑब्जेक्ट के रूप में जोड़ना चाहते हैं—विशेषकर यदि आप इसका आकार बदलने, प्रभाव जोड़ने आदि के लिए मानक फ़ॉर्मेटिंग विकल्पों का उपयोग करने की योजना बनाते हैं—तो देखें [चित्र फ़्रेम](https://docs.aspose.com/slides/hi/net/picture-frame/). 

{{% /alert %}} 

{{% alert title="नोट" color="warning" %}}

आप छवियों और PowerPoint प्रस्तुतियों के बीच इनपुट/आउटपुट संचालन को नियंत्रित करके एक छवि को एक स्वरूप से दूसरे स्वरूप में बदल सकते हैं। इन पृष्ठों को देखें: रूपांतरण [छवि से JPG](https://products.aspose.com/slides/hi/net/conversion/image-to-jpg/); रूपांतरण [JPG से छवि](https://products.aspose.com/slides/hi/net/conversion/jpg-to-image/); रूपांतरण [JPG से PNG](https://products.aspose.com/slides/hi/net/conversion/jpg-to-png/), रूपांतरण [PNG से JPG](https://products.aspose.com/slides/hi/net/conversion/png-to-jpg/); रूपांतरण [PNG से SVG](https://products.aspose.com/slides/hi/net/conversion/png-to-svg/), रूपांतरण [SVG से PNG](https://products.aspose.com/slides/hi/net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides इन लोकप्रिय स्वरूपों में छवियों के साथ संचालन का समर्थन करता है: JPEG, PNG, BMP, GIF, और अन्य। 

## **स्थानीय रूप से संग्रहीत छवियां स्लाइड्स में जोड़ें**

आप अपने कंप्यूटर पर एक या कई छवियों को प्रस्तुति की स्लाइड पर जोड़ सकते हैं। C# में यह नमूना कोड आपको दिखाता है कि स्लाइड में छवि कैसे जोड़ें:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **वेब से छवियां स्लाइड्स में जोड़ें**

यदि आप जिस छवि को स्लाइड में जोड़ना चाहते हैं वह आपके कंप्यूटर पर उपलब्ध नहीं है, तो आप छवि को सीधे वेब से जोड़ सकते हैं। 

यह नमूना कोड C# में वेब से छवि को स्लाइड में जोड़ने का तरीका दिखाता है:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **स्लाइड मास्टर में छवियां जोड़ें**

स्लाइड मास्टर वह शीर्ष स्लाइड है जो उसके तहत सभी स्लाइड्स की जानकारी (थीम, लेआउट आदि) संग्रहित और नियंत्रित करता है। इसलिए, जब आप स्लाइड मास्टर में छवि जोड़ते हैं, तो वह छवि उस स्लाइड मास्टर के तहत सभी स्लाइड्स में दिखाई देती है। 

यह C# नमूना कोड दिखाता है कि स्लाइड मास्टर में छवि कैसे जोड़ें:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **स्लाइड पृष्ठभूमि के रूप में छवियां जोड़ें**

आप किसी विशेष स्लाइड या कई स्लाइड्स की पृष्ठभूमि के रूप में चित्र का उपयोग करने का निर्णय ले सकते हैं। ऐसे में, आपको *[स्लाइड पृष्ठभूमि के रूप में छवियों का सेट करना](https://docs.aspose.com/slides/hi/net/presentation-background/#setting-images-as-background-for-slides)* देखना चाहिए।

## **प्रस्तुतियों में SVG जोड़ें**

आप [AddPictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/methods/addpictureframe) मेथड का उपयोग करके, जो [IShapeCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection) इंटरफ़ेस से संबंधित है, किसी भी छवि को प्रस्तुति में जोड़ या सम्मिलित कर सकते हैं।

SVG छवि पर आधारित एक इमेज ऑब्जेक्ट बनाने के लिए, आप इसे इस प्रकार कर सकते हैं:

1. ImageShapeCollection में सम्मिलित करने के लिए SvgImage ऑब्जेक्ट बनाएं
2. ISvgImage से PPImage ऑब्जेक्ट बनाएं
3. IPPImage इंटरफ़ेस का उपयोग करके PictureFrame ऑब्जेक्ट बनाएं

यह नमूना कोड उपरोक्त चरणों को लागू करके प्रस्तुति में SVG छवि जोड़ने का तरीका दिखाता है:
``` csharp 
// दस्तावेज़ निर्देशिका का पथ
string dataDir = @"D:\Documents\";

// स्रोत SVG फ़ाइल नाम
string svgFileName = dataDir + "sample.svg";

// आउटपुट प्रस्तुति फ़ाइल नाम
string outPptxPath = dataDir + "presentation.pptx";

// नई प्रस्तुति बनाएं
using (var p = new Presentation())
{
    // SVG फ़ाइल की सामग्री पढ़ें
    string svgContent = File.ReadAllText(svgFileName);

    // SvgImage ऑब्जेक्ट बनाएं
    ISvgImage svgImage = new SvgImage(svgContent);

    // PPImage ऑब्जेक्ट बनाएं
    IPPImage ppImage = p.Images.AddImage(svgImage);

    // एक नया PictureFrame बनाता है
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // प्रस्तुति को PPTX प्रारूप में सहेजें
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **SVG को आकारों के सेट में बदलें**

Aspose.Slides का SVG को आकारों के सेट में रूपांतरण PowerPoint की SVG छवियों के साथ काम करने की कार्यक्षमता के समान है:

![PowerPoint पॉपअप मेन्यू](img_01_01.png)

यह कार्यक्षमता [IShapeCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection) इंटरफ़ेस के [AddGroupShape](https://reference.aspose.com/slides/hi/net/aspose.slides.ishapecollection/addgroupshape/methods/1) मेथड के एक ओवरलोड द्वारा प्रदान की जाती है जो पहले तर्क के रूप में एक [ISvgImage](https://reference.aspose.com/slides/hi/net/aspose.slides/isvgimage) ऑब्जेक्ट लेता है।

यह नमूना कोड दिखाता है कि वर्णित मेथड का उपयोग करके SVG फ़ाइल को आकारों के सेट में कैसे बदलें:

``` csharp 
// दस्तावेज़ निर्देशिका का पथ
string dataDir = @"D:\Documents\";

// स्रोत SVG फ़ाइल नाम
string svgFileName = dataDir + "sample.svg";

// आउटपुट प्रस्तुति फ़ाइल नाम
string outPptxPath = dataDir + "presentation.pptx";

// नई प्रस्तुति बनाएं
using (IPresentation presentation = new Presentation())
{
    // SVG फ़ाइल की सामग्री पढ़ें
    string svgContent = File.ReadAllText(svgFileName);

    // SvgImage ऑब्जेक्ट बनाएं
    ISvgImage svgImage = new SvgImage(svgContent);

    // स्लाइड आकार प्राप्त करें
    SizeF slideSize = presentation.SlideSize.Size;

    // SVG छवि को आकारों के समूह में बदलें और इसे स्लाइड आकार के अनुसार स्केल करें
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // प्रस्तुति को PPTX स्वरूप में सहेजें
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **छवियों को EMF के रूप में स्लाइड्स में जोड़ें**

Aspose.Slides for .NET आपको Excel शीट्स से EMF छवियां उत्पन्न करने और Aspose.Cells के साथ स्लाइड्स में उन्हें EMF के रूप में जोड़ने की अनुमति देता है।  

यह नमूना कोड दिखाता है कि वर्णित कार्य कैसे किया जाए:

``` csharp 
using (Workbook book = new Workbook(dataDir + "chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;

    //वर्कबुक को स्ट्रीम में सहेजें
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = dataDir + "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save(dataDir + "Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **इमेज कलेक्शन में छवियों को बदलें**

Aspose.Slides आपको प्रस्तुति के इमेज कलेक्शन में संग्रहीत छवियों (स्लाइड शेप्स द्वारा उपयोग की गई सहित) को बदलने देता है। यह अनुभाग कलेक्शन में छवियों को अपडेट करने के कई तरीके दिखाता है। API सीधे तरीकों से छवि को कच्चे बाइट डेटा, एक [IImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) इंस्टेंस, या कलेक्शन में पहले से मौजूद दूसरी छवि का उपयोग करके बदलने की सुविधा देता है।

नीचे दिए गए कदमों का पालन करें:

1. प्रस्तुति फ़ाइल को जिसमें छवियां हैं, [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का उपयोग करके लोड करें।
2. फ़ाइल से नई छवि को बाइट एरे में लोड करें।
3. बाइट एरे का उपयोग करके लक्ष्य छवि को नई छवि से बदलें।
4. दूसरे तरीके में, छवि को एक [IImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) ऑब्जेक्ट में लोड करें और लक्ष्य छवि को उस ऑब्जेक्ट से बदलें।
5. तीसरे तरीके में, लक्ष्य छवि को प्रस्तुति के इमेज कलेक्शन में पहले से मौजूद छवि से बदलें।
6. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```cs
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
using Presentation presentation = new Presentation("sample.pptx");

// पहला तरीका।
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// दूसरा तरीका।
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// तीसरा तरीका।
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// प्रस्तुति को फ़ाइल में सहेजें।
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="जानकारी" color="info" %}}

Aspose FREE [Text to GIF](https://products.aspose.app/slides/hi/text-to-gif) कनवर्टर का उपयोग करके, आप आसानी से पाठों को एनीमेट कर सकते हैं, पाठों से GIF बना सकते हैं, आदि। 

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मूल छवि का रिज़ॉल्यूशन सम्मिलन के बाद भी बरकरार रहता है?**

हाँ। स्रोत पिक्सेल संरक्षित रहते हैं, लेकिन अंतिम रूप से दिखावट इस पर निर्भर करती है कि स्लाइड पर [चित्र](/slides/hi/net/picture-frame/) को कैसे स्केल किया गया है और सहेजते समय कौन सी संपीड़न लागू हुई है।

**कई स्लाइड्स में एक ही लोगो को एक साथ बदलने का सबसे अच्छा तरीका क्या है?**

लोगो को मास्टर स्लाइड या लेआउट पर रखें और प्रस्तुति के इमेज कलेक्शन में इसे बदलें—अपडेट्स उन सभी तत्वों तक पहुँचेंगे जो उस संसाधन का उपयोग करते हैं।

**क्या सम्मिलित SVG को संपाद्य आकारों में बदला जा सकता है?**

हां। आप SVG को आकारों के समूह में बदल सकते हैं, जिसके बाद व्यक्तिगत भाग मानक आकार गुणों के साथ संपादन योग्य हो जाते हैं।

**मैं कैसे एक ही समय में कई स्लाइड्स की पृष्ठभूमि के रूप में एक चित्र सेट कर सकता हूँ?**

[चित्र को पृष्ठभूमि के रूप में असाइन करें](/slides/hi/net/presentation-background/) मास्टर स्लाइड या संबंधित लेआउट पर—उस मास्टर/लेआउट का उपयोग करने वाली सभी स्लाइड्स पृष्ठभूमि को विरासत में प्राप्त करेंगी।

**कई चित्रों के कारण प्रस्तुति का आकार बहुत बड़ा होने से कैसे बचें?**

डुप्लिकेट के बजाय एक ही छवि संसाधन को पुन: उपयोग करें, उचित रिज़ॉल्यूशन चुनें, सहेजते समय संपीड़न लागू करें, और जहाँ उपयुक्त हो वहाँ दोहराए गए ग्राफिक्स को मास्टर पर रखें।