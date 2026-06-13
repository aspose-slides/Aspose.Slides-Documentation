---
title: जावा में प्रस्तुति ज़ूम प्रबंधित करें
linktitle: ज़ूम प्रबंधित करें
type: docs
weight: 60
url: /hi/java/manage-zoom/
keywords:
- ज़ूम
- ज़ूम फ़्रेम
- स्लाइड ज़ूम
- सेक्शन ज़ूम
- सारांश ज़ूम
- ज़ूम जोड़ें
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ ज़ूम बनाएं और अनुकूलित करें — सेक्शनों के बीच कूदें, थंबनेल और ट्रांज़िशन जोड़ें, PPT, PPTX और ODP प्रस्तुतियों में।"
---
## **परिचय**

PowerPoint में ज़ूम आपको प्रस्तुति की विशिष्ट स्लाइडों, सेक्शन और भागों के बीच कूदने की सुविधा देता है। जब आप प्रस्तुति दे रहे हों, यह तेज़ी से नेविगेट करने की क्षमता बहुत उपयोगी हो सकती है।

![overview_image](overview.png)

* संपूर्ण प्रस्तुति को एक ही स्लाइड में सारांशित करने के लिए, एक [सारांश ज़ूम](#Summary-Zoom) का उपयोग करें।
* केवल चयनित स्लाइड्स दिखाने के लिए, एक [स्लाइड ज़ूम](#Slide-Zoom) का उपयोग करें।
* केवल एक सेक्शन दिखाने के लिए, एक [सेक्शन ज़ूम](#Section-Zoom) का उपयोग करें।

## **स्लाइड ज़ूम**
एक स्लाइड ज़ूम आपकी प्रस्तुति को अधिक गतिशील बना सकता है, जिससे आप अपनी इच्छा अनुसार किसी भी क्रम में स्लाइड्स के बीच स्वतंत्र रूप से नेविगेट कर सकते हैं बिना प्रस्तुति के प्रवाह को बाधित किए। स्लाइड ज़ूम छोटे प्रस्तुतियों में बहुत उपयोगी होते हैं, लेकिन आप उन्हें विभिन्न प्रस्तुति परिदृश्यों में भी उपयोग कर सकते हैं।

स्लाइड ज़ूम आपको कई जानकारी के टुकड़ों में गहराई तक पहुंचने में मदद करते हैं जबकि आप महसूस करते हैं कि आप एक ही कैनवास पर हैं।

![overview_image](slidezoomsel.png)

स्लाइड ज़ूम ऑब्जेक्ट्स के लिए, Aspose.Slides प्रदान करता है [ZoomImageType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ZoomImageType) enumeration, [IZoomFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IZoomFrame) interface, और कुछ मेथड्स [IShapeCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection) interface के अंतर्गत।

### **ज़ूम फ्रेम बनाएं**

आप इस प्रकार स्लाइड पर ज़ूम फ्रेम जोड़ सकते हैं:

1.	[Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
2.	नई स्लाइड्स बनाएं जिनसे आप ज़ूम फ्रेम लिंक करना चाहते हैं। 
3.	बनायी गई स्लाइड्स में पहचान पाठ और बैकग्राउंड जोड़ें।
4.	पहली स्लाइड में ज़ूम फ्रेम (बनायी गई स्लाइड्स के रेफ़रेंस के साथ) जोड़ें।
5.	संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह Java कोड आपको दिखाता है कि स्लाइड पर ज़ूम फ्रेम कैसे बनाएं:

``` java
Presentation pres = new Presentation();
try {
    //प्रस्तुति में नई स्लाइड्स जोड़ता है
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // दूसरा स्लाइड के लिए बैकग्राउंड बनाता है
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // दूसरे स्लाइड के लिए टेक्स्ट बॉक्स बनाता है
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // तीसरे स्लाइड के लिए बैकग्राउंड बनाता है
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // तीसरे स्लाइड के लिए टेक्स्ट बॉक्स बनाता है
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //ZoomFrame ऑब्जेक्ट्स जोड़ता है
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // प्रस्तुति को सहेजता है
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **कस्टम इमेज के साथ ज़ूम फ्रेम बनाएं**
Aspose.Slides for Java के साथ, आप इस प्रकार एक अलग स्लाइड प्रीव्यू इमेज के साथ ज़ूम फ्रेम बना सकते हैं:
1.	[Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
2.	एक नई स्लाइड बनाएं जिससे आप ज़ूम फ्रेम लिंक करना चाहते हैं। 
3.	स्लाइड में पहचान पाठ और बैकग्राउंड जोड़ें।
4.	[IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPPImage) ऑब्जेक्ट को उन इमेजेज कलेक्शन में जोड़ें जो [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) ऑब्जेक्ट से जुड़े हैं, ताकि फ्रेम को भरने में उपयोग हो सके।
5.	पहली स्लाइड में ज़ूम फ्रेम (बनायी गई स्लाइड के रेफ़रेंस के साथ) जोड़ें।
6.	संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह Java कोड आपको दिखाता है कि अलग इमेज के साथ ज़ूम फ्रेम कैसे बनाएं:

``` java
Presentation pres = new Presentation();
try {
    //प्रस्तुति में नई स्लाइड जोड़ता है
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    //दूसरी स्लाइड के लिए बैकग्राउंड बनाता है
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    //तीसरी स्लाइड के लिए टेक्स्ट बॉक्स बनाता है
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    //ज़ूम ऑब्जेक्ट के लिए नई छवि बनाता है
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //ZoomFrame ऑब्जेक्ट जोड़ता है
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    //प्रस्तुति को सहेजता है
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **ज़ूम फ्रेम फ़ॉर्मेट करें**
पिछले सेक्शन में हमने आपको सरल ज़ूम फ्रेम बनाने का तरीका दिखाया था। अधिक जटिल ज़ूम फ्रेम बनाने के लिए आपको एक साधारण फ्रेम के फ़ॉर्मेटिंग को बदलना होगा। ज़ूम फ्रेम पर लागू करने के लिए कई फ़ॉर्मेटिंग विकल्प उपलब्ध हैं।

आप इस प्रकार स्लाइड पर ज़ूम फ्रेम की फ़ॉर्मेटिंग नियंत्रित कर सकते हैं:

1.	[Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
2.	नई स्लाइड्स बनाएं जिनसे आप ज़ूम फ्रेम लिंक करना चाहते हैं। 
3.	बनायी गई स्लाइड्स में कुछ पहचान पाठ और बैकग्राउंड जोड़ें।
4.	पहली स्लाइड में ज़ूम फ्रेम (बनायी गई स्लाइड्स के रेफ़रेंस के साथ) जोड़ें।
5.	[IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPPImage) ऑब्जेक्ट को उन इमेजेज कलेक्शन में जोड़ें जो [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) ऑब्जेक्ट से जुड़े हैं, ताकि फ्रेम को भरने में उपयोग हो सके।
6.	पहली ज़ूम फ्रेम ऑब्जेक्ट के लिए कस्टम इमेज सेट करें।
7.	दूसरी ज़ूम फ्रेम ऑब्जेक्ट की लाइन फ़ॉर्मेट बदलें।
8.	दूसरी ज़ूम फ्रेम ऑब्जेक्ट की इमेज से बैकग्राउंड हटाएँ।
5.	संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह Java कोड आपको दिखाता है कि स्लाइड पर ज़ूम फ्रेम की फ़ॉर्मेटिंग कैसे बदलें:

``` java 
Presentation pres = new Presentation();
try {
    //प्रस्तुति में नई स्लाइड्स जोड़ता है
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    //दूसरे स्लाइड के लिए बैकग्राउंड बनाता है
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    //दूसरे स्लाइड के लिए टेक्स्ट बॉक्स बनाता है
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    //तीसरे स्लाइड के लिए बैकग्राउंड बनाता है
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    //तीसरे स्लाइड के लिए टेक्स्ट बॉक्स बनाता है
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //ZoomFrame ऑब्जेक्ट्स जोड़ता है
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    //ज़ूम ऑब्जेक्ट के लिए नई छवि बनाता है
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //zoomFrame1 ऑब्जेक्ट के लिए कस्टम इमेज सेट करता है
    zoomFrame1.setImage(picture);

    //zoomFrame2 ऑब्जेक्ट के लिए ज़ूम फ्रेम फ़ॉर्मेट सेट करता है
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    //zoomFrame2 ऑब्जेक्ट के लिए बैकग्राउंड न दिखाने की सेटिंग
    zoomFrame2.setShowBackground(false);

    //प्रस्तुति को सहेजता है
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **सेक्शन ज़ूम**

एक सेक्शन ज़ूम आपके प्रस्तुति के एक सेक्शन का लिंक होता है। आप सेक्शन ज़ूम का उपयोग उन सेक्शनों पर वापस जाने के लिए कर सकते हैं जिन्हें आप विशेष रूप से उजागर करना चाहते हैं। या आप उन्हें यह दिखाने के लिए उपयोग कर सकते हैं कि आपके प्रस्तुति के विभिन्न हिस्से कैसे जुड़े हैं।

![overview_image](seczoomsel.png)

सेक्शन ज़ूम ऑब्जेक्ट्स के लिए, Aspose.Slides प्रदान करता है [ISectionZoomFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISectionZoomFrame) interface और कुछ मेथड्स [IShapeCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection) interface के अंतर्गत।

### **सेक्शन ज़ूम फ्रेम बनाएं**

आप इस प्रकार स्लाइड पर सेक्शन ज़ूम फ्रेम जोड़ सकते हैं:

1.	[Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
2.	एक नई स्लाइड बनाएं। 
3.	बनायी गई स्लाइड में पहचान बैकग्राउंड जोड़ें।
4.	एक नया सेक्शन बनाएं जिससे आप ज़ूम फ्रेम लिंक करना चाहते हैं। 
5.	पहली स्लाइड में सेक्शन ज़ूम फ्रेम (बनाए गए सेक्शन के रेफ़रेंस के साथ) जोड़ें।
6.	संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह Java कोड आपको दिखाता है कि स्लाइड पर ज़ूम फ्रेम कैसे बनाएं:

``` java
Presentation pres = new Presentation();
try {
    //प्रस्तुति में नई स्लाइड जोड़ता है
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // प्रस्तुति में एक नया सेक्शन जोड़ता है
    pres.getSections().addSection("Section 1", slide);

    // सेक्शनज़ूमफ़्रेम ऑब्जेक्ट जोड़ता है
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    //प्रस्तुति को सहेजता है
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **कस्टम इमेज के साथ सेक्शन ज़ूम फ्रेम बनाएं**

Aspose.Slides for Java के साथ, आप इस प्रकार एक अलग स्लाइड प्रीव्यू इमेज के साथ सेक्शन ज़ूम फ्रेम बना सकते हैं:

1.	[Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
2.	एक नई स्लाइड बनाएं।
3.	बनायी गई स्लाइड में पहचान बैकग्राउंड जोड़ें।
4.	एक नया सेक्शन बनाएं जिससे आप ज़ूम फ्रेम लिंक करना चाहते हैं। 
5.	[IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPPImage) ऑब्जेक्ट को उन इमेजेज कलेक्शन में जोड़ें जो [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) ऑब्जेक्ट से जुड़े हैं, ताकि फ्रेम को भरने में उपयोग हो सके।
5.	पहली स्लाइड में सेक्शन ज़ूम फ्रेम (बनाए गए सेक्शन के रेफ़रेंस के साथ) जोड़ें।
6.	संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह Java कोड आपको दिखाता है कि अलग इमेज के साथ ज़ूम फ्रेम कैसे बनाएं:

``` java 
Presentation pres = new Presentation();
try {
    //प्रस्तुति में नई स्लाइड जोड़ता है
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // एक नया सेक्शन जोड़ता है
    pres.getSections().addSection("Section 1", slide);

    // एक नई छवि बनाता है
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // सेक्शनज़ूमफ़्रेम ऑब्जेक्ट जोड़ता है
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    //प्रस्तुति को सहेजता है
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **सेक्शन ज़ूम फ्रेम फ़ॉर्मेट करें**

अधिक जटिल सेक्शन ज़ूम फ्रेम बनाने के लिए आपको एक साधारण फ्रेम की फ़ॉर्मेटिंग बदलनी होगी। सेक्शन ज़ूम फ्रेम पर लागू करने के लिए कई फ़ॉर्मेटिंग विकल्प उपलब्ध हैं।

आप इस प्रकार स्लाइड पर सेक्शन ज़ूम फ्रेम की फ़ॉर्मेटिंग नियंत्रित कर सकते हैं:

1.	[Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
2.	एक नई स्लाइड बनाएं।
3.	बनायी गई स्लाइड में पहचान बैकग्राउंड जोड़ें।
4.	एक नया सेक्शन बनाएं जिससे आप ज़ूम फ्रेम लिंक करना चाहते हैं। 
5.	पहली स्लाइड में सेक्शन ज़ूम फ्रेम (बनाए गए सेक्शन के रेफ़रेंस के साथ) जोड़ें।
6.	बनाए गए सेक्शन ज़ूम ऑब्जेक्ट का आकार और स्थिति बदलें।
7.	[IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPPImage) ऑब्जेक्ट को उन इमेजेज कलेक्शन में जोड़ें जो [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) ऑब्जेक्ट से जुड़े हैं, ताकि फ्रेम को भरने में उपयोग हो सके।
8.	बनाए गए सेक्शन ज़ूम फ्रेम ऑब्जेक्ट के लिए कस्टम इमेज सेट करें।
9.	*लिंक्ड सेक्शन से मूल स्लाइड पर लौटने* की क्षमता सेट करें। 
10.	सेक्शन ज़ूम फ्रेम ऑब्जेक्ट की इमेज से बैकग्राउंड हटाएँ।
11.	दूसरे ज़ूम फ्रेम ऑब्जेक्ट की लाइन फ़ॉर्मेट बदलें।
12.	ट्रांज़िशन अवधि बदलें।
13.	संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह Java कोड आपको दिखाता है कि सेक्शन ज़ूम फ्रेम की फ़ॉर्मेटिंग कैसे बदलें:

``` java
Presentation pres = new Presentation();
try {
    //प्रस्तुति में नई स्लाइड जोड़ता है
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // एक नया सेक्शन जोड़ता है
    pres.getSections().addSection("Section 1", slide);

    // SectionZoomFrame ऑब्जेक्ट जोड़ता है
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // SectionZoomFrame के लिए फ़ॉर्मेटिंग
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
         picture = pres.getImages().addImage(image);
     } finally {
        if (image != null) image.dispose();
     }
    sectionZoomFrame.setImage(picture);

    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);

    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray);
    sectionZoomFrame.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5f);

    sectionZoomFrame.setTransitionDuration(1.5f);

    // प्रस्तुति को सहेजता है
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **सारांश ज़ूम**

एक सारांश ज़ूम लैंडिंग पेज के समान है जहाँ आपकी प्रस्तुति के सभी हिस्से एक साथ प्रदर्शित होते हैं। आप प्रस्तुति देते समय ज़ूम का उपयोग करके किसी भी क्रम में एक स्थान से दूसरे स्थान पर जा सकते हैं। आप रचनात्मक बन सकते हैं, आगे कूद सकते हैं, या अपने स्लाइड शो के हिस्सों को बिना प्रस्तुति के प्रवाह को बाधित किए फिर से देख सकते हैं।

![overview_image](sumzoomsel.png)

सारांश ज़ूम ऑब्जेक्ट्स के लिए, Aspose.Slides प्रदान करता है [ISummaryZoomFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISummaryZoomSection), और [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISummaryZoomSectionCollection) interfaces और कुछ मेथड्स [IShapeCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection) interface के अंतर्गत।

### **सारांश ज़ूम बनाएं**

आप इस प्रकार स्लाइड पर सारांश ज़ूम फ्रेम जोड़ सकते हैं:

1.	[Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
2.	नई स्लाइड्स बनाएं जिनमें पहचान बैकग्राउंड और नई सेक्शन्स हों।
3.	पहली स्लाइड में सारांश ज़ूम फ्रेम जोड़ें।
4.	संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह Java कोड आपको दिखाता है कि स्लाइड पर सारांश ज़ूम फ्रेम कैसे बनाएं:

``` java 
Presentation pres = new Presentation();
try {
    //प्रस्तुति में नई स्लाइड जोड़ता है
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // प्रस्तुति में नया सेक्शन जोड़ता है
    pres.getSections().addSection("Section 1", slide);

    //प्रस्तुति में नई स्लाइड जोड़ता है
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // प्रस्तुति में नया सेक्शन जोड़ता है
    pres.getSections().addSection("Section 2", slide);

    //प्रस्तुति में नई स्लाइड जोड़ता है
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // प्रस्तुति में नया सेक्शन जोड़ता है
    pres.getSections().addSection("Section 3", slide);

    //प्रस्तुति में नई स्लाइड जोड़ता है
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // प्रस्तुति में नया सेक्शन जोड़ता है
    pres.getSections().addSection("Section 4", slide);

    // सारांश ज़ूमफ़्रेम ऑब्जेक्ट जोड़ता है
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // प्रस्तुति को सहेजता है
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **सारांश ज़ूम सेक्शन जोड़ें और हटाएँ**

सभी सेक्शन्स एक सारांश ज़ूम फ्रेम में [ISummaryZoomSection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISummaryZoomSection) ऑब्जेक्ट्स द्वारा दर्शाए जाते हैं, जो [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISummaryZoomSectionCollection) ऑब्जेक्ट में संग्रहीत होते हैं। आप [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISummaryZoomSectionCollection) इंटरफ़ेस के माध्यम से सारांश ज़ूम सेक्शन ऑब्जेक्ट को इस प्रकार जोड़ या हटा सकते हैं:

1.	[Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
2.	नई स्लाइड्स बनाएं जिनमें पहचान बैकग्राउंड और नई सेक्शन्स हों।
3.	पहली स्लाइड में सारांश ज़ूम फ्रेम जोड़ें।
4.	प्रस्तुति में एक नई स्लाइड और सेक्शन जोड़ें।
5.	बनाए गए सेक्शन को सारांश ज़ूम फ्रेम में जोड़ें।
6.	सारांश ज़ूम फ्रेम से पहली सेक्शन हटाएँ।
7.	संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह Java कोड आपको दिखाता है कि सारांश ज़ूम फ्रेम में सेक्शन कैसे जोड़ें और हटाएँ:

``` java
Presentation pres = new Presentation();
try {
    //प्रस्तुति में नई स्लाइड जोड़ता है
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // नई सेक्शन को प्रस्तुति में जोड़ता है
    pres.getSections().addSection("Section 1", slide);

    //Adds a new slide to the presentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // नई सेक्शन को प्रस्तुति में जोड़ता है
    pres.getSections().addSection("Section 2", slide);

    // Adds SummaryZoomFrame object
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Adds a new slide to the presentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    ISection section3 = pres.getSections().addSection("Section 3", slide);

    // Adds a section to the Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // Removes section from the Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // Saves the presentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **सारांश ज़ूम सेक्शन्स फ़ॉर्मेट करें**

अधिक जटिल सारांश ज़ूम सेक्शन ऑब्जेक्ट्स बनाने के लिए आपको एक साधारण फ्रेम की फ़ॉर्मेटिंग बदलनी होगी। सारांश ज़ूम सेक्शन ऑब्जेक्ट पर लागू करने के लिए कई फ़ॉर्मेटिंग विकल्प उपलब्ध हैं।

आप इस प्रकार सारांश ज़ूम फ्रेम में सारांश ज़ूम सेक्शन ऑब्जेक्ट की फ़ॉर्मेटिंग नियंत्रित कर सकते हैं:

1.	[Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
2.	नई स्लाइड्स बनाएं जिनमें पहचान बैकग्राउंड और नई सेक्शन्स हों।
3.	पहली स्लाइड में सारांश ज़ूम फ्रेम जोड़ें।
4.	`ISummaryZoomSectionCollection` से पहले ऑब्जेक्ट का सारांश ज़ूम सेक्शन ऑब्जेक्ट प्राप्त करें।
7.	[IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPPImage) ऑब्जेक्ट को उन इमेजेज कलेक्शन में जोड़ें जो [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) ऑब्जेक्ट से जुड़े हैं, ताकि फ्रेम को भरने में उपयोग हो सके।
8.	बनाए गए सेक्शन ज़ूम फ्रेम ऑब्जेक्ट के लिए कस्टम इमेज सेट करें।
9.	*लिंक्ड सेक्शन से मूल स्लाइड पर लौटने* की क्षमता सेट करें। 
11.	दूसरे ज़ूम फ्रेम ऑब्जेक्ट की लाइन फ़ॉर्मेट बदलें।
12.	ट्रांज़िशन अवधि बदलें।
13.	संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह Java कोड आपको दिखाता है कि सारांश ज़ूम सेक्शन ऑब्जेक्ट की फ़ॉर्मेटिंग कैसे बदलें:

``` java
Presentation pres = new Presentation();
try {
    //प्रस्तुति में नई स्लाइड जोड़ता है
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // नई सेक्शन को प्रस्तुति में जोड़ता है
    pres.getSections().addSection("Section 1", slide);

    //Adds a new slide to the presentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // नई सेक्शन को प्रस्तुति में जोड़ता है
    pres.getSections().addSection("Section 2", slide);

    // नया SummaryZoomFrame ऑब्जेक्ट जोड़ता है
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // पहले SummaryZoomSection ऑब्जेक्ट को प्राप्त करता है
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    // SummaryZoomSection ऑब्जेक्ट के लिए फ़ॉर्मेटिंग
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
    summarySection.setImage(picture);

    summarySection.setReturnToParent(false);

    summarySection.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black);
    summarySection.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5f);

    summarySection.setTransitionDuration(1.5f);

    // प्रस्तुति को सहेजता है
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**क्या मैं लक्ष्य दिखाने के बाद 'पैरेंट' स्लाइड पर लौटने को नियंत्रित कर सकता हूँ?**

हां। [Zoom frame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/zoomframe/) या [section](https://reference.aspose.com/slides/hi/java/com.aspose.slides/sectionzoomframe/) में `ReturnToParent` व्यवहार होता है जिसे सक्षम करने पर दर्शकों को लक्ष्य सामग्री देखने के बाद मूल स्लाइड पर वापस भेजा जाता है।

**क्या मैं ज़ूम ट्रांज़िशन की 'गति' या अवधि को समायोजित कर सकता हूँ?**

हां। ज़ूम `TransitionDuration` सेट करने का समर्थन करता है जिससे आप कूद एनीमेशन की अवधि को नियंत्रित कर सकते हैं।

**क्या प्रस्तुति में ज़ूम ऑब्जेक्ट्स की संख्या पर कोई सीमा है?**

दस्तावेज़ में कोई कठोर API सीमा निर्धारित नहीं है। व्यावहारिक सीमाएं कुल प्रस्तुति जटिलता और दर्शक के प्रदर्शन पर निर्भर करती हैं। आप कई ज़ूम फ्रेम जोड़ सकते हैं, लेकिन फ़ाइल आकार और रेंडरिंग समय का ध्यान रखें।