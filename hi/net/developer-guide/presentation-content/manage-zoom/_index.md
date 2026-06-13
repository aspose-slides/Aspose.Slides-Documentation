---
title: .NET में प्रस्तुति ज़ूम प्रबंधित करें
linktitle: ज़ूम प्रबंधित करें
type: docs
weight: 60
url: /hi/net/manage-zoom/
keywords:
- ज़ूम
- ज़ूम फ्रेम
- स्लाइड ज़ूम
- सेक्शन ज़ूम
- सारांश ज़ूम
- ज़ूम जोड़ें
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ ज़ूम बनाएं और अनुकूलित करें — सेक्शनों के बीच कूदें, थंबनेल और ट्रांज़िशन जोड़ें, और PPT, PPTX व ODP प्रस्तुतियों में प्रयोग करें।"
---
## **परिचय**

PowerPoint में ज़ूम आपको प्रस्तुति की विशिष्ट स्लाइड्स, सेक्शन्स और भागों के बीच कूदने की अनुमति देता है। जब आप प्रस्तुति दे रहे होते हैं, तो सामग्री के बीच तेज़ी से नेविगेट करने की यह क्षमता बहुत उपयोगी साबित हो सकती है।

![overview_image](overview.png)

* किसी एक स्लाइड पर पूरी प्रस्तुति को सारांशित करने के लिए, एक [Summary Zoom](#Summary-Zoom) उपयोग करें।
* केवल चयनित स्लाइड्स दिखाने के लिए, एक [Slide Zoom](#Slide-Zoom) उपयोग करें।
* केवल एक सेक्शन दिखाने के लिए, एक [Section Zoom](#Section-Zoom) उपयोग करें।

## **स्लाइड ज़ूम**
स्लाइड ज़ूम आपकी प्रस्तुति को अधिक गतिशील बना सकता है, जिससे आप अपनी इच्छानुसार किसी भी क्रम में स्लाइड्स के बीच स्वतंत्र रूप से नेविगेट कर सकते हैं, बिना प्रस्तुति के प्रवाह को बाधित किए। स्लाइड ज़ूम छोटे प्रस्तुतियों के लिए उपयुक्त हैं जिनमें बहुत अधिक सेक्शन नहीं होते, लेकिन आप उन्हें विभिन्न प्रस्तुति परिदृश्यों में भी उपयोग कर सकते हैं।

स्लाइड ज़ूम आपको कई सूचना टुकड़ों में गहराई से जाने की सुविधा देते हैं जबकि आप एक ही कैनवास पर काम कर रहे होते हैं।

![overview_image](slidezoomsel.png)

स्लाइड ज़ूम ऑब्जेक्ट्स के लिए, Aspose.Slides [ZoomImageType](https://reference.aspose.com/slides/hi/net/aspose.slides/zoomimagetype) एनीमरेशन, [IZoomFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/izoomframe) इंटरफ़ेस, तथा [IShapeCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection) इंटरफ़ेस के कुछ मेथड्स प्रदान करता है।

### **ज़ूम फ्रेम बनाएं**
आप स्लाइड पर ज़ूम फ्रेम इस प्रकार जोड़ सकते हैं:

1.	[Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
2.	नई स्लाइड्स बनाएं जिनसे आप ज़ूम फ्रेम लिंक करना चाहते हैं। 
3.	बनाई गई स्लाइड्स में पहचान टेक्स्ट और बैकग्राउंड जोड़ें।
4.	पहली स्लाइड में ज़ूम फ्रेम (जिसमें बनाई गई स्लाइड्स के रेफ़रेंसेज़ हों) जोड़ें।
5.	संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

``` csharp 
using (Presentation pres = new Presentation())
{
    //प्रस्तुति में नई स्लाइड्स जोड़ता है
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    //दूसरी स्लाइड के लिए पृष्ठभूमि बनाता है
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    //दूसरी स्लाइड के लिए टेक्स्ट बॉक्स बनाता है
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    //तीसरी स्लाइड के लिए पृष्ठभूमि बनाता है
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    //तीसरी स्लाइड के लिए टेक्स्ट बॉक्स बनाता है
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //ZoomFrame ऑब्जेक्ट्स जोड़ता है
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    //प्रस्तुति को सहेजता है
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **कस्टम इमेज के साथ ज़ूम फ्रेम बनाएं**
Aspose.Slides for .NET के साथ, आप एक अलग स्लाइड प्रीव्यू इमेज के साथ ज़ूम फ्रेम इस प्रकार बना सकते हैं: 
1.	[Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
2.	एक नई स्लाइड बनाएं जिसे आप ज़ूम फ्रेम से लिंक करना चाहते हैं। 
3.	स्लाइड में पहचान टेक्स्ट और बैकग्राउंड जोड़ें।
4.	[IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage) ऑब्जेक्ट बनाएं, जिसमें वह इमेज हो जो [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) ऑब्जेक्ट की Images कलेक्शन में जोड़ें, जिससे फ्रेम भर जाएगा।
5.	पहली स्लाइड में ज़ूम फ्रेम (जिसमें बनाई गई स्लाइड का रेफ़रेंस हो) जोड़ें।
6.	संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

``` csharp 
using (Presentation pres = new Presentation())
{
    //प्रस्तुति में एक नई स्लाइड जोड़ता है
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    //दूसरी स्लाइड के लिए पृष्ठभूमि बनाता है
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    //तीसरी स्लाइड के लिए टेक्स्ट बॉक्स बनाता है
    IAutoShape autoshape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    //ज़ूम ऑब्जेक्ट के लिए नई छवि बनाता है
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //ZoomFrame ऑब्जेक्ट जोड़ता है
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    //प्रस्तुति को सहेजता है
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **ज़ूम फ्रेम को फ़ॉर्मेट करें**
पिछले सेक्शन्स में हमने दिखाया कि साधारण ज़ूम फ्रेम कैसे बनाते हैं। अधिक जटिल ज़ूम फ्रेम बनाने के लिए, आपको साधारण फ्रेम के फ़ॉर्मेट को बदलना होगा। ज़ूम फ्रेम पर लागू करने के लिए कई फ़ॉर्मेटिंग विकल्प उपलब्ध हैं। 

आप स्लाइड पर ज़ूम फ्रेम के फ़ॉर्मेट को इस प्रकार नियंत्रित कर सकते हैं:

1.	[Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
2.	नई स्लाइड्स बनाएं जिन्हें आप ज़ूम फ्रेम से लिंक करना चाहते हैं। 
3.	बनाई गई स्लाइड्स में कुछ पहचान टेक्स्ट और बैकग्राउंड जोड़ें।
4.	पहली स्लाइड में ज़ूम फ्रेम (बनाई गई स्लाइड्स के रेफ़रेंसेज़ के साथ) जोड़ें।
5.	[IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage) ऑब्जेक्ट बनाएं, जिसमें वह इमेज हो जो [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) ऑब्जेक्ट की Images कलेक्शन में जोड़ें, जिससे फ्रेम भर जाएगा।
6.	पहले ज़ूम फ्रेम ऑब्जेक्ट के लिए कस्टम इमेज सेट करें।
7.	दूसरे ज़ूम फ्रेम ऑब्जेक्ट के लिए लाइन फ़ॉर्मेट बदलें।
8.	दूसरे ज़ूम फ्रेम ऑब्जेक्ट की इमेज से बैकग्राउंड हटाएँ।
5.	संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

``` csharp 
using (Presentation pres = new Presentation())
{
    //प्रस्तुति में नई स्लाइड्स जोड़ता है
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // दूसरे स्लाइड के लिए पृष्ठभूमि बनाता है
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // दूसरे स्लाइड के लिए टेक्स्ट बॉक्स बनाता है
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // तीसरी स्लाइड के लिए पृष्ठभूमि बनाता है
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // तीसरी स्लाइड के लिए टेक्स्ट बॉक्स बनाता है
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //ZoomFrame ऑब्जेक्ट्स जोड़ता है
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // ज़ूम ऑब्जेक्ट के लिए नई छवि बनाता है
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // zoomFrame1 ऑब्जेक्ट के लिए कस्टम इमेज सेट करता है
    zoomFrame1.ZoomImage = ppImage;

    // zoomFrame2 ऑब्जेक्ट के लिए ज़ूम फ्रेम फ़ॉर्मेट सेट करता है
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    // zoomFrame2 ऑब्जेक्ट के लिए बैकग्राउंड न दिखाने की सेटिंग
    zoomFrame2.ShowBackground = false;

    // प्रस्तुति को सहेजता है
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **सेक्शन ज़ूम**

एक सेक्शन ज़ूम आपके प्रस्तुति के एक सेक्शन से लिंक होता है। आप सेक्शन ज़ूम का उपयोग उन सेक्शनों को फिर से दिखाने के लिए कर सकते हैं जिन्हें आप विशेष रूप से उजागर करना चाहते हैं। या आप इन्हें यह दर्शाने के लिए उपयोग कर सकते हैं कि आपके प्रस्तुति के विभिन्न हिस्से कैसे आपस में जुड़े हैं।

![overview_image](seczoomsel.png)

सेक्शन ज़ूम ऑब्जेक्ट्स के लिए, Aspose.Slides [ISectionZoomFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/isectionzoomframe) इंटरफ़ेस और [IShapeCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection) इंटरफ़ेस के कुछ मेथड्स प्रदान करता है।

### **सेक्शन ज़ूम फ्रेम बनाएं**
आप स्लाइड पर सेक्शन ज़ूम फ्रेम इस प्रकार जोड़ सकते हैं:

1.	[Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
2.	एक नई स्लाइड बनाएं। 
3.	बनाई गई स्लाइड में पहचान बैकग्राउंड जोड़ें।
4.	एक नया सेक्शन बनाएं जिसे आप ज़ूम फ्रेम से लिंक करना चाहते हैं। 
5.	पहली स्लाइड में सेक्शन ज़ूम फ्रेम (बनाए गए सेक्शन के रेफ़रेंसेज़ के साथ) जोड़ें।
6.	संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

``` csharp 
using (Presentation pres = new Presentation())
{
    //प्रस्तुति में एक नई स्लाइड जोड़ता है
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // एक नया सेक्शन जोड़ता है
    pres.Sections.AddSection("Section 1", slide);

    // SectionZoomFrame ऑब्जेक्ट जोड़ता है
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // प्रस्तुति को सहेजता है
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **कस्टम इमेज के साथ सेक्शन ज़ूम फ्रेम बनाएं**
Aspose.Slides for .NET का उपयोग करके, आप एक अलग स्लाइड प्रीव्यू इमेज के साथ सेक्शन ज़ूम फ्रेम इस प्रकार बना सकते हैं: 

1.	[Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
2.	एक नई स्लाइड बनाएं।
3.	बनाई गई स्लाइड में पहचान बैकग्राउंड जोड़ें।
4.	एक नया सेक्शन बनाएं जिसे आप ज़ूम फ्रेम से लिंक करना चाहते हैं। 
5.	[IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage) ऑब्जेक्ट बनाएं, जिसमें वह इमेज हो जो [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) ऑब्जेक्ट की Images कलेक्शन में जोड़ें, जिससे फ्रेम भर जाएगा।
5.	पहली स्लाइड में सेक्शन ज़ूम फ्रेम (बनाए गए सेक्शन के रेफ़रेंस के साथ) जोड़ें।
6.	संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

``` csharp 
using (Presentation pres = new Presentation())
{
    //प्रस्तुति में नई स्लाइड जोड़ता है
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // प्रस्तुति में एक नया सेक्शन जोड़ता है
    pres.Sections.AddSection("Section 1", slide);

    // ज़ूम ऑब्जेक्ट के लिए नई छवि बनाता है
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // SectionZoomFrame ऑब्जेक्ट जोड़ता है
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    // प्रस्तुति को सहेजता है
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **सेक्शन ज़ूम फ्रेम को फ़ॉर्मेट करें**
अधिक जटिल सेक्शन ज़ूम फ्रेम बनाने के लिए, आपको साधारण फ्रेम के फ़ॉर्मेट को बदलना होगा। सेक्शन ज़ूम फ्रेम पर लागू करने के कई फ़ॉर्मेटिंग विकल्प उपलब्ध हैं। 

आप स्लाइड पर सेक्शन ज़ूम फ्रेम के फ़ॉर्मेट को इस प्रकार नियंत्रित कर सकते हैं:

1.	[Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
2.	एक नई स्लाइड बनाएं।
3.	बनाई गई स्लाइड में पहचान बैकग्राउंड जोड़ें।
4.	एक नया सेक्शन बनाएं जिसे आप ज़ूम फ्रेम से लिंक करना चाहते हैं। 
5.	पहली स्लाइड में सेक्शन ज़ूम फ्रेम (बनाए गए सेक्शन के रेफ़रेंसेज़ के साथ) जोड़ें।
6.	बनाए गए सेक्शन ज़ूम ऑब्जेक्ट का आकार और स्थिति बदलें।
7.	[IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage) ऑब्जेक्ट बनाएं, जिसमें वह इमेज हो जो [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) ऑब्जेक्ट की Images कलेक्शन में जोड़ें, जिससे फ्रेम भर जाएगा।
8.	बनाए गए सेक्शन ज़ूम फ्रेम ऑब्जेक्ट के लिए कस्टम इमेज सेट करें।
9.	*लिंक्ड सेक्शन से मूल स्लाइड पर लौटने* की क्षमता सेट करें। 
10.	सेक्शन ज़ूम फ्रेम ऑब्जेक्ट की इमेज से बैकग्राउंड हटाएँ।
11.	दूसरे ज़ूम फ्रेम ऑब्जेक्ट की लाइन फ़ॉर्मेट बदलें।
12.	ट्रांज़िशन की अवधि बदलें।
13.	संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

``` csharp 
using (Presentation pres = new Presentation())
{
    //प्रस्तुति में नई स्लाइड जोड़ता है
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // प्रस्तुति में नया सेक्शन जोड़ता है
    pres.Sections.AddSection("Section 1", slide);

    // SectionZoomFrame ऑब्जेक्ट जोड़ता है
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // SectionZoomFrame के लिए फ़ॉर्मेटिंग
    sectionZoomFrame.X = 100;
    sectionZoomFrame.Y = 300;
    sectionZoomFrame.Width = 100;
    sectionZoomFrame.Height = 75;

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    sectionZoomFrame.ZoomImage = ppImage;

    sectionZoomFrame.ReturnToParent = true;
    sectionZoomFrame.ShowBackground = false;

    sectionZoomFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    sectionZoomFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Brown;
    sectionZoomFrame.LineFormat.DashStyle = LineDashStyle.DashDot;
    sectionZoomFrame.LineFormat.Width = 2.5f;

    sectionZoomFrame.TransitionDuration = 1.5f;

    // प्रस्तुति को सहेजता है
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **सारांश ज़ूम**

सारांश ज़ूम एक लैंडिंग पेज की तरह होता है जहाँ आपके प्रस्तुति के सभी हिस्से एक साथ प्रदर्शित होते हैं। प्रस्तुति देते समय, आप ज़ूम का उपयोग करके किसी भी क्रम में एक स्थान से दूसरे स्थान पर जा सकते हैं। आप रचनात्मक बन सकते हैं, आगे की स्लाइड को स्किप कर सकते हैं, या अपने स्लाइड शो के भागों को फिर से देख सकते हैं बिना प्रस्तुति के प्रवाह को बाधित किए।

![overview_image](sumzoomsel.png)

सारांश ज़ूम ऑब्जेक्ट्स के लिए, Aspose.Slides [ISummaryZoomFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/isummaryzoomframe), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/hi/net/aspose.slides/isummaryzoomsection), और [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/isummaryzoomsectioncollection) इंटरफ़ेस तथा [IShapeCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection) इंटरफ़ेस के कुछ मेथड्स प्रदान करता है।

### **सारांश ज़ूम बनाएं**
आप स्लाइड पर सारांश ज़ूम फ्रेम इस प्रकार जोड़ सकते हैं:

1.	[Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
2.	पहचान बैकग्राउंड और नए सेक्शन्स के साथ नई स्लाइड्स बनाएं।
3.	पहली स्लाइड में सारांश ज़ूम फ्रेम जोड़ें।
4.	संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

``` csharp 
using (Presentation pres = new Presentation())
{
    //प्रस्तुति में नई स्लाइड जोड़ता है
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    //प्रस्तुति में नया सेक्शन जोड़ता है
    pres.Sections.AddSection("Section 1", slide);

    //प्रस्तुति में नई स्लाइड जोड़ता है
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    //प्रस्तुति में नया सेक्शन जोड़ता है
    pres.Sections.AddSection("Section 2", slide);

    //प्रस्तुति में नई स्लाइड जोड़ता है
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    //प्रस्तुति में नया सेक्शन जोड़ता है
    pres.Sections.AddSection("Section 3", slide);

    //प्रस्तुति में नई स्लाइड जोड़ता है
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    //प्रस्तुति में नया सेक्शन जोड़ता है
    pres.Sections.AddSection("Section 4", slide);

    //SummaryZoomFrame ऑब्जेक्ट जोड़ता है
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //प्रस्तुति को सहेजता है
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **सारांश ज़ूम सेक्शन जोड़ें और हटाएँ**
सारांश ज़ूम फ्रेम में सभी सेक्शन [ISummaryZoomFrameSection](https://reference.aspose.com/slides/hi/net/aspose.slides/isummaryzoomsection) ऑब्जेक्ट्स द्वारा दर्शाए जाते हैं, जो [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/isummaryzoomsectioncollection) ऑब्जेक्ट में संग्रहित होते हैं। आप [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/isummaryzoomsectioncollection) इंटरफ़ेस के माध्यम से सारांश ज़ूम सेक्शन ऑब्जेक्ट को इस प्रकार जोड़ या हटा सकते हैं:

1.	[Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
2.	पहचान बैकग्राउंड और नए सेक्शन्स के साथ नई स्लाइड्स बनाएं।
3.	पहली स्लाइड में सारांश ज़ूम फ्रेम जोड़ें।
4.	प्रस्तुति में एक नई स्लाइड और सेक्शन जोड़ें।
5.	बनाए गए सेक्शन को सारांश ज़ूम फ्रेम में जोड़ें।
6.	सारांश ज़ूम फ्रेम से पहला सेक्शन हटाएँ।
7.	संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

``` csharp 
using (Presentation pres = new Presentation())
{
    //प्रस्तुति में नई स्लाइड जोड़ता है
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // प्रस्तुति में नया सेक्शन जोड़ता है
    pres.Sections.AddSection("Section 1", slide);

    //प्रस्तुति में नई स्लाइड जोड़ता है
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // प्रस्तुति में नया सेक्शन जोड़ता है
    pres.Sections.AddSection("Section 2", slide);

    // SummaryZoomFrame ऑब्जेक्ट जोड़ता है
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //प्रस्तुति में नई स्लाइड जोड़ता है
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // प्रस्तुति में नया सेक्शन जोड़ता है
    ISection section3 = pres.Sections.AddSection("Section 3", slide);

    // Summary Zoom में एक सेक्शन जोड़ता है
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // Summary Zoom से सेक्शन हटाता है
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // प्रस्तुति को सहेजता है
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **सारांश ज़ूम सेक्शन्स को फ़ॉर्मेट करें**
अधिक जटिल सारांश ज़ूम सेक्शन ऑब्जेक्ट बनाने के लिए, आपको साधारण फ्रेम के फ़ॉर्मेट को बदलना होगा। सारांश ज़ूम सेक्शन ऑब्जेक्ट पर कई फ़ॉर्मेटिंग विकल्प लागू किए जा सकते हैं। 

आप सारांश ज़ूम फ्रेम में एक सारांश ज़ूम सेक्शन ऑब्जेक्ट के फ़ॉर्मेट को इस प्रकार नियंत्रित कर सकते हैं:

1.	[Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
2.	पहचान बैकग्राउंड और नए सेक्शन्स के साथ नई स्लाइड्स बनाएं।
3.	पहली स्लाइड में सारांश ज़ूम फ्रेम जोड़ें।
4.	`ISummaryZoomSectionCollection` से पहले ऑब्जेक्ट के लिए सारांश ज़ूम सेक्शन ऑब्जेक्ट प्राप्त करें।
7.	[IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage) ऑब्जेक्ट बनाएं, जिसमें वह इमेज हो जो [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) ऑब्जेक्ट की Images कलेक्शन में जोड़ें, जिससे फ्रेम भर जाएगा।
8.	बनाए गए सेक्शन ज़ूम फ्रेम ऑब्जेक्ट के लिए कस्टम इमेज सेट करें।
9.	*लिंक्ड सेक्शन से मूल स्लाइड पर लौटने* की क्षमता सेट करें। 
11.	दूसरे ज़ूम फ्रेम ऑब्जेक्ट की लाइन फ़ॉर्मेट बदलें।
12.	ट्रांज़िशन की अवधि बदलें।
13.	संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

``` csharp 
using (Presentation pres = new Presentation())
{
    //प्रस्तुति में नई स्लाइड जोड़ता है
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // प्रस्तुति में नया सेक्शन जोड़ता है
    pres.Sections.AddSection("Section 1", slide);

    //प्रस्तुति में नई स्लाइड जोड़ता है
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // प्रस्तुति में नया सेक्शन जोड़ता है
    pres.Sections.AddSection("Section 2", slide);

    // SummaryZoomFrame ऑब्जेक्ट जोड़ता है
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // पहला SummaryZoomSection ऑब्जेक्ट प्राप्त करता है
    ISummaryZoomSection summarySection = summaryZoomFrame.SummaryZoomCollection[0];

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // SummaryZoomSection ऑब्जेक्ट के लिए फ़ॉर्मेटिंग
    summarySection.ZoomImage = ppImage;
    summarySection.ReturnToParent = false;

    summarySection.LineFormat.FillFormat.FillType = FillType.Solid;
    summarySection.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    summarySection.LineFormat.DashStyle = LineDashStyle.DashDot;
    summarySection.LineFormat.Width = 1.5f;

    summarySection.TransitionDuration = 1.5f;

    // प्रस्तुति को सहेजता है
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं लक्षित सामग्री दिखाने के बाद 'पैरेंट' स्लाइड पर वापस लौटने को नियंत्रित कर सकता हूँ?**

हाँ। [Zoom frame](https://reference.aspose.com/slides/hi/net/aspose.slides/zoomframe/) या [section](https://reference.aspose.com/slides/hi/net/aspose.slides/sectionzoomframe/) में `ReturnToParent` व्यवहार होता है जो सक्षम करने पर दर्शकों को लक्ष्य सामग्री देखने के बाद मूल स्लाइड पर वापस ले जाता है।

**क्या मैं ज़ूम ट्रांज़िशन की 'स्पीड' या अवधि को समायोजित कर सकता हूँ?**

हाँ। ज़ूम में `TransitionDuration` सेट करने की सुविधा है जिससे आप एनीमेशन की अवधि नियंत्रित कर सकते हैं।

**क्या प्रस्तुति में ज़ूम ऑब्जेक्ट्स की संख्या पर कोई सीमा है?**

दस्तावेज़ीकृत कोई कठोर API सीमा नहीं है। व्यावहारिक सीमाएँ प्रस्तुति की जटिलता और दर्शक के प्रदर्शन पर निर्भर करती हैं। आप कई ज़ूम फ्रेम जोड़ सकते हैं, लेकिन फ़ाइल आकार और रेंडरिंग समय का ध्यान रखें।