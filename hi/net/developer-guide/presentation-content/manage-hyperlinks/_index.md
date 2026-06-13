---
title: .NET में प्रस्तुति हाइपरलिंक प्रबंधित करें
linktitle: हाइपरलिंक प्रबंधित करें
type: docs
weight: 20
url: /hi/net/manage-hyperlinks/
keywords:
- URL जोड़ें
- हाइपरलिंक जोड़ें
- हाइपरलिंक बनाएँ
- हाइपरलिंक फॉर्मेट करें
- हाइपरलिंक हटाएँ
- हाइपरलिंक अपडेट करें
- टेक्स्ट हाइपरलिंक
- स्लाइड हाइपरलिंक
- आकार हाइपरलिंक
- छवि हाइपरलिंक
- वीडियो हाइपरलिंक
- परिवर्तनशील हाइपरलिंक
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint और OpenDocument प्रस्तुतियों में हाइपरलिंक को आसानी से प्रबंधित करें—क्षणों में इंटरैक्टिविटी और कार्यप्रवाह को बढ़ाएँ।"
---
## **परिचय**

हाइपरलिंक किसी वस्तु, डेटा या किसी स्थान का संदर्भ होता है। ये PowerPoint प्रस्तुतियों में सामान्य हाइपरलिंक हैं:

* टेक्स्ट, आकार या मीडिया के भीतर वेबसाइट लिंक
* स्लाइड्स के लिंक

Aspose.Slides for .NET आपको प्रस्तुतियों में हाइपरलिंक संबंधित कई कार्य करने की अनुमति देता है।

{{% alert color="primary" %}} 
आप Aspose का सरल, [नि:शुल्क ऑनलाइन PowerPoint संपादक.](https://products.aspose.app/slides/hi/editor) देखना चाह सकते हैं।
{{% /alert %}} 

## **URL हाइपरलिंक जोड़ें**

### **पाठ में URL हाइपरलिंक जोड़ें**

यह C# कोड आपको दिखाता है कि कैसे पाठ में वेबसाइट हाइपरलिंक जोड़ा जाए:
```c#
using (Presentation presentation = new Presentation())
{
	IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.AddTextFrame("Aspose: File Format APIs");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;

	presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

### **आकार या फ्रेम में URL हाइपरलिंक जोड़ें**

यह C# नमूना कोड आपको दिखाता है कि कैसे आकार में वेबसाइट हाइपरलिंक जोड़ा जाए:
```c#
using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

### **मीडिया में URL हाइपरलिंक जोड़ें**

Aspose.Slides आपको चित्रों, ऑडियो और वीडियो फ़ाइलों में हाइपरलिंक जोड़ने की अनुमति देता है।

यह नमूना कोड आपको दिखाता है कि **चित्र** में हाइपरलिंक कैसे जोड़ा जाए:
```c#
using (Presentation pres = new Presentation())
{
    // प्रस्तुति में छवि जोड़ता है
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // पहले जोड़ी गई छवि के आधार पर स्लाइड 1 पर चित्र फ्रेम बनाता है
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

यह नमूना कोड आपको दिखाता है कि **ऑडियो फ़ाइल** में हाइपरलिंक कैसे जोड़ा जाए:
```c#
using (Presentation pres = new Presentation())
{
    IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes("audio.mp3"));
    IAudioFrame audioFrame = pres.Slides[0].Shapes.AddAudioFrameEmbedded(10, 10, 100, 100, audio);

    audioFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    audioFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

यह नमूना कोड आपको दिखाता है कि **वीडियो** में हाइपरलिंक कैसे जोड़ा जाए:
``` csharp
using (Presentation pres = new Presentation())
{
    IVideo video = pres.Videos.AddVideo(File.ReadAllBytes("video.avi"));
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 100, 100, video);

    videoFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    videoFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

{{%  alert  title="Tip"  color="primary"  %}} 
आप *[OLE प्रबंधन](https://docs.aspose.com/slides/hi/net/manage-ole/)* देखना चाह सकते हैं।
{{% /alert %}}

## **हाइपरलिंक का उपयोग करके सामग्री तालिका बनाएं**

चूंकि हाइपरलिंक आपको वस्तुओं या स्थानों के संदर्भ जोड़ने की अनुमति देते हैं, आप उनका उपयोग करके सामग्री तालिका बना सकते हैं।

यह नमूना कोड आपको दिखाता है कि हाइपरलिंक के साथ सामग्री तालिका कैसे बनाई जाए:
```c#
using (var presentation = new Presentation())
{
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

    var contentTable = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    contentTable.FillFormat.FillType = FillType.NoFill;
    contentTable.LineFormat.FillFormat.FillType = FillType.NoFill;
    contentTable.TextFrame.Paragraphs.Clear();

    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    paragraph.Text = "Title of slide 2 .......... ";

    var linkPortion = new Portion();
    linkPortion.Text = "Page 2";
    linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

    paragraph.Portions.Add(linkPortion);
    contentTable.TextFrame.Paragraphs.Add(paragraph);

    presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
}
```

## **हाइपरलिंक को फॉर्मेट करें**

### **रंग**

आप [ColorSource](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlink/properties/colorsource) गुण के साथ [IHyperlink](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlink) इंटरफ़ेस में हाइपरलिंक का रंग सेट कर सकते हैं और हाइपरलिंक से रंग जानकारी प्राप्त कर सकते हैं। यह सुविधा PowerPoint 2019 में पहली बार पेश हुई, इसलिए इस गुण में परिवर्तन पुराने PowerPoint संस्करणों पर लागू नहीं होते।

यह नमूना कोड एक ऑपरेशन दर्शाता है जिसमें विभिन्न रंगों के हाइपरलिंक एक ही स्लाइड में जोड़े गए थे:
```c#
using (Presentation presentation = new Presentation())
{
    IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.AddTextFrame("This is a sample of colored hyperlink.");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

    IAutoShape shape2 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.AddTextFrame("This is a sample of usual hyperlink.");
    shape2.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

    presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
}
```
### **ध्वनि**

Aspose.Slides इन गुणों को प्रदान करता है जिससे आप हाइपरलिंक को ध्वनि के साथ प्रमुख बना सकते हैं:
- [IHyperlink.Sound](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlink/properties/sound)
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **हाइपरलिंक ध्वनि जोड़ें**

यह C# कोड आपको दिखाता है कि ध्वनि चलाने वाला हाइपरलिंक कैसे सेट करें और इसे दूसरे हाइपरलिंक से कैसे रोकें:
```c#
using (Presentation pres = new Presentation())
{
	// प्रस्तुति ऑडियो संग्रह में नई ऑडियो जोड़ता है
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// अगली स्लाइड के लिए हाइपरलिंक के साथ नया आकार जोड़ता है
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// हाइपरलिंक को "नो साउंड" के लिए जांचता है
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// ध्वनि चलाने वाला हाइपरलिंक सेट करता है
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// खाली स्लाइड जोड़ता है 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// नोएक्शन हाइपरलिंक के साथ नया आकार जोड़ता है
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// हाइपरलिंक "पिछली ध्वनि रोकें" फ़्लैग सेट करता है
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```

#### **हाइपरलिंक ध्वनि निकालें**

यह C# कोड आपको दिखाता है कि हाइपरलिंक में उपयोग की गई ध्वनि को कैसे निकाला जाए:
```c#
using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// पहले आकार का हाइपरलिंक प्राप्त करता है
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// हाइपरलिंक ध्वनि को बाइट एरे में निकालता है
		byte[] audioData = link.Sound.BinaryData;
	}
}
```

## **प्रस्तुति से हाइपरलिंक हटाएँ**

### **पाठ से हाइपरलिंक हटाएँ**

यह C# कोड आपको दिखाता है कि प्रस्तुति स्लाइड के पाठ से हाइपरलिंक कैसे हटाया जाए:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        IAutoShape autoShape = shape as IAutoShape;
        if (autoShape != null)
        {
            foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
            {
                foreach (IPortion portion in paragraph.Portions)
                {
                    portion.PortionFormat.HyperlinkManager.RemoveHyperlinkClick();
                }
            }
        }
    }
    
    pres.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
}
```

### **आकार या फ्रेम से हाइपरलिंक हटाएँ**

यह C# कोड आपको दिखाता है कि प्रस्तुति स्लाइड के आकार से हाइपरलिंक कैसे हटाया जाए:
``` csharp
using (Presentation pres = new Presentation("demo.pptx")) 
{ 
   ISlide slide = pres.Slides[0]; 
   foreach (IShape shape in slide.Shapes) 
     { 
       shape.HyperlinkManager.RemoveHyperlinkClick(); 
     } 
   pres.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx); 
}
```

## **परिवर्तनीय हाइपरलिंक**

[Hyperlink](https://reference.aspose.com/slides/hi/net/aspose.slides/hyperlink) वर्ग परिवर्तनशील है। इस वर्ग के साथ, आप इन गुणों के मान बदल सकते हैं:
- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlink/properties/highlightclick)

यह कोड स्निपेट आपको दिखाता है कि स्लाइड में हाइपरलिंक कैसे जोड़ा जाए और बाद में उसका टूलटिप कैसे संपादित किया जाए:
```c#
using (Presentation presentation = new Presentation())
{   
   IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);    
    
   shape1.AddTextFrame("Aspose: File Format APIs");
    
   shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;
    
 presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **IHyperlinkQueries में समर्थित गुण**

आप किसी प्रस्तुति, स्लाइड, या टेक्स्ट से IHyperlinkQueries तक पहुंच सकते हैं जिसके लिए हाइपरलिंक परिभाषित है।

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/properties/hyperlinkqueries)

IHyperlinkQueries वर्ग इन विधियों और गुणों का समर्थन करता है:

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **FAQ**

**मैं केवल स्लाइड के बजाय एक "सेक्शन" या सेक्शन की पहली स्लाइड पर आंतरिक नेविगेशन कैसे बना सकता हूं?**

PowerPoint में सेक्शन स्लाइड्स के समूह होते हैं; नेविगेशन तकनीकी रूप से एक विशिष्ट स्लाइड को लक्ष्य बनाता है। "सेक्शन पर नेविगेट करने" के लिए, आप आमतौर पर उसकी पहली स्लाइड से लिंक करते हैं।

**क्या मैं मास्टर स्लाइड तत्वों पर हाइपरलिंक संलग्न कर सकता हूं ताकि यह सभी स्लाइड्स पर काम करे?**

हाँ। मास्टर स्लाइड और लेआउट तत्व हाइपरलिंक का समर्थन करते हैं। ऐसे लिंक चाइल्ड स्लाइड्स पर दिखाई देते हैं और स्लाइडशो के दौरान क्लिक करने योग्य होते हैं।

**क्या हाइपरलिंक PDF, HTML, चित्रों या वीडियो में निर्यात करते समय संरक्षित रहेंगे?**

[PDF](/slides/hi/net/convert-powerpoint-to-pdf/) और [HTML](/slides/hi/net/convert-powerpoint-to-html/) में, हाँ—लिंक सामान्यतः संरक्षित रहते हैं। जब आप [images](/slides/hi/net/convert-powerpoint-to-png/) और [video](/slides/hi/net/convert-powerpoint-to-video/) में निर्यात करते हैं, तो क्लिक करने की क्षमता उन स्वरूपों की प्रकृति के कारण नहीं रहती (रास्टर फ्रेम/वीडियो हाइपरलिंक का समर्थन नहीं करते)।