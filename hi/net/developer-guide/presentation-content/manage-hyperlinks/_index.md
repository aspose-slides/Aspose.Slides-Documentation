---
title: ".NET में प्रस्तुति हाइपरलिंक प्रबंधित करें"
linktitle: "हाइपरलिंक प्रबंधन"
type: docs
weight: 20
url: /hi/net/manage-hyperlinks/
keywords:
- "URL जोड़ें"
- "हाइपरलिंक जोड़ें"
- "हाइपरलिंक बनाएं"
- "हाइपरलिंक स्वरूपित करें"
- "हाइपरलिंक हटाएं"
- "हाइपरलिंक अपडेट करें"
- "पाठ हाइपरलिंक"
- "स्लाइड हाइपरलिंक"
- "आकार हाइपरलिंक"
- "छवि हाइपरलिंक"
- "वीडियो हाइपरलिंक"
- "परिवर्तनीय हाइपरलिंक"
- PowerPoint
- OpenDocument
- "प्रस्तुति"
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint और OpenDocument प्रस्तुतियों में हाइपरलिंक को सहजता से प्रबंधित करें—मिनटों में इंटरैक्टिविटी और कार्यप्रवाह को बढ़ाएँ।"
---
## **परिचय**

हाइपरलिंक एक वस्तु, डेटा या किसी जगह का संदर्भ है। ये PowerPoint प्रस्तुतियों में सामान्य हाइपरलिंक हैं:

* टेक्स्ट, आकार, या मीडिया में वेबसाइट के लिंक
* स्लाइड्स के लिंक

Aspose.Slides for .NET आपको प्रस्तुतियों में हाइपरलिंक से जुड़े कई कार्य करने की अनुमति देता है।

{{% alert color="info" %}} 

आप Aspose सरल, [नि:शुल्क ऑनलाइन PowerPoint संपादक.](https://products.aspose.app/slides/hi/editor) देखना चाहते हो सकता है।

{{% /alert %}} 

## **URL हाइपरलिंक जोड़ें**

### **टेक्स्ट में URL हाइपरलिंक जोड़ें**

यह C# कोड आपको दिखाता है कि टेक्स्ट में वेबसाइट हाइपरलिंक कैसे जोड़ें:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

यह C# नमूना कोड आपको दिखाता है कि आकार में वेबसाइट हाइपरलिंक कैसे जोड़ें:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

### **मीडिया में URL हाइपरलिंक जोड़ें**

Aspose.Slides आपको छवियों, ऑडियो, और वीडियो फ़ाइलों में हाइपरलिंक जोड़ने की अनुमति देता है।

यह नमूना कोड आपको दिखाता है कि **छवि** में हाइपरलिंक कैसे जोड़ें:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

यह नमूना कोड आपको दिखाता है कि **ऑडियो फ़ाइल** में हाइपरलिंक कैसे जोड़ें:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes("audio.mp3"));
    IAudioFrame audioFrame = pres.Slides[0].Shapes.AddAudioFrameEmbedded(10, 10, 100, 100, audio);

    audioFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    audioFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

यह नमूना कोड आपको दिखाता है कि **वीडियो** में हाइपरलिंक कैसे जोड़ें:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IVideo video = pres.Videos.AddVideo(File.ReadAllBytes("video.avi"));
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 100, 100, video);

    videoFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    videoFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

{{%  alert  title="Tip"  color="info"  %}} 

आप *[OLE प्रबंधन](https://docs.aspose.com/slides/hi/net/manage-ole/)* देखना चाहेंगे।

{{% /alert %}}

## **हाइपरलिंक का उपयोग करके सामग्री-सूची बनाएं**

चूंकि हाइपरलिंक आपको वस्तुओं या स्थानों के संदर्भ जोड़ने की अनुमति देते हैं, आप उनका उपयोग करके सामग्री-सूची बना सकते हैं।

यह नमूना कोड आपको दिखाता है कि हाइपरलिंक के साथ सामग्री-सूची कैसे बनाएं:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **हाइपरलिंक का स्वरूप**

### **रंग**

आप [ColorSource](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlink/properties/colorsource) प्रॉपर्टी को [IHyperlink](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlink) इंटरफ़ेस में उपयोग करके हाइपरलिंक का रंग निर्धारित कर सकते हैं और हाइपरलिंक से रंग की जानकारी प्राप्त कर सकते हैं। यह सुविधा पहली बार PowerPoint 2019 में पेश की गई थी, इसलिए इस प्रॉपर्टी में परिवर्तन पुराने PowerPoint संस्करणों पर लागू नहीं होते।

यह नमूना कोड एक ऑपरेशन दर्शाता है जहाँ विभिन्न रंगों वाले हाइपरलिंक एक ही स्लाइड में जोड़े गए थे:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

Aspose.Slides यह प्रॉपर्टीज़ प्रदान करता है जिससे आप हाइपरलिंक को ध्वनि के साथ जोर दे सकते हैं:
- [IHyperlink.Sound](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **हाइपरलिंक ध्वनि जोड़ें**

यह C# कोड आपको दिखाता है कि ध्वनि चलाने वाला हाइपरलिंक कैसे सेट करें और उसे दूसरे हाइपरलिंक से रोकें:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
	// प्रस्तुति की ऑडियो संग्रह में नया ऑडियो जोड़ता है
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// अगली स्लाइड के हाइपरलिंक के साथ नया आकार जोड़ता है
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// "No Sound" के लिए हाइपरलिंक की जाँच करता है
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// वह हाइपरलिंक सेट करता है जो ध्वनि चलाता है
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// खाली स्लाइड जोड़ता है 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// NoAction हाइपरलिंक के साथ नया आकार जोड़ता है
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// हाइपरलिंक "पिछली ध्वनि रोकें" फ़्लैग सेट करता है
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```

#### **हाइपरलिंक ध्वनि निकालें**

यह C# कोड आपको दिखाता है कि हाइपरलिंक में प्रयुक्त ध्वनि कैसे निकालें:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// पहले आकार के हाइपरलिंक को प्राप्त करता है
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// हाइपरलिंक ध्वनि को बाइट एरे में निकालता है
		byte[] audioData = link.Sound.BinaryData;
	}
}
```

## **प्रस्तुतियों से हाइपरलिंक हटाएँ**

### **टेक्स्ट से हाइपरलिंक हटाएँ**

यह C# कोड आपको दिखाता है कि प्रस्तुति स्लाइड में टेक्स्ट से हाइपरलिंक कैसे हटाएँ:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

यह C# कोड आपको दिखाता है कि प्रस्तुति स्लाइड में आकार से हाइपरलिंक कैसे हटाएँ:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

The [Hyperlink](https://reference.aspose.com/slides/hi/net/aspose.slides/hyperlink) क्लास परिवर्तनीय है। इस क्लास का उपयोग करके आप इन प्रॉपर्टीज़ के मान बदल सकते हैं:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlink/properties/highlightclick)

The code snippet shows you how to add a hyperlink to a slide and edit its tooltip later:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **IHyperlinkQueries में समर्थित प्रॉपर्टीज़**

You can access IHyperlinkQueries from a presentation, slide, or text for which the hyperlink is defined. 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/properties/hyperlinkqueries)

The IHyperlinkQueries class supports these methods and properties: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **अक्सर पूछे जाने वाले प्रश्न**

### मैं कैसे आंतरिक नेविगेशन बना सकता हूँ केवल स्लाइड तक नहीं, बल्कि "सेक्शन" या सेक्शन की पहली स्लाइड तक?

PowerPoint में सेक्शन स्लाइडों के समूह होते हैं; नेविगेशन तकनीकी रूप से एक विशिष्ट स्लाइड को लक्ष्य करता है। 'एक सेक्शन में नेविगेट करने' के लिए आप आमतौर पर उसकी पहली स्लाइड से लिंक करते हैं।

### क्या मैं मास्टर स्लाइड तत्वों पर हाइपरलिंक संलग्न कर सकता हूँ ताकि यह सभी स्लाइडों पर काम करे?

हां। मास्टर स्लाइड और लेआउट तत्व हाइपरलिंक का समर्थन करते हैं। ऐसे लिंक चाइल्ड स्लाइडों पर भी दिखाई देते हैं और स्लाइड शो के दौरान क्लिक करने योग्य होते हैं।

### क्या हाइपरलिंक PDF, HTML, इमेजेज, या वीडियो में एक्सपोर्ट करने पर संरक्षित रहेंगे?

[PDF](/slides/hi/net/convert-powerpoint-to-pdf/) और [HTML](/slides/hi/net/convert-powerpoint-to-html/) में, हाँ—लिंक सामान्यतः संरक्षित रहते हैं। जब आप [images](/slides/hi/net/convert-powerpoint-to-png/) और [video](/slides/hi/net/convert-powerpoint-to-video/) में एक्सपोर्ट करते हैं, तो क्लिकएबिलिटी नहीं रहेगी क्योंकि इन फॉर्मेट्स (रास्टर फ्रेम/वीडियो) हाइपरलिंक का समर्थन नहीं करते।