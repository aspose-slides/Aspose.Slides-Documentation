---
title: JavaScript में प्रेज़ेंटेशन ज़ूम प्रबंधित करें
linktitle: ज़ूम प्रबंधित करें
type: docs
weight: 60
url: /hi/nodejs-java/manage-zoom/
keywords:
- ज़ूम
- ज़ूम फ्रेम
- स्लाइड ज़ूम
- सेक्शन ज़ूम
- सारांश ज़ूम
- ज़ूम जोड़ें
- PowerPoint
- प्रेज़ेंटेशन
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js के साथ ज़ूम बनाएं और अनुकूलित करें — PPT, PPTX और ODP प्रस्तुतियों में सेक्शन के बीच कूदें, थंबनेल और ट्रांज़िशन जोड़ें।"
---
## **परिचय**

PowerPoint में Zoom आपको प्रस्तुति की विशिष्ट स्लाइड्स, सेक्शन और भागों के बीच कूदने की अनुमति देता है। जब आप प्रस्तुति दे रहे हों, तो सामग्री के बीच तेज़ी से नेविगेट करने की यह क्षमता अत्यंत उपयोगी हो सकती है।

![overview_image](overview.png)

* संपूर्ण प्रस्तुति को एक ही स्लाइड पर सारांशित करने के लिए, एक [Summary Zoom](#Summary-Zoom) का उपयोग करें।
* केवल चयनित स्लाइड्स दिखाने के लिए, एक [Slide Zoom](#Slide-Zoom) का उपयोग करें।
* केवल एक सेक्शन दिखाने के लिए, एक [Section Zoom](#Section-Zoom) का उपयोग करें।

## **स्लाइड ज़ूम**

स्लाइड ज़ूम आपके प्रस्तुति को अधिक गतिशील बना सकता है, जिससे आप अपनी मनचाही क्रम में स्लाइड्स के बीच स्वतंत्र रूप से नेविगेट कर सकते हैं बिना प्रस्तुति के प्रवाह को बाधित किए। स्लाइड ज़ूम छोटे प्रस्तुतियों में बहुत उपयोगी होते हैं जिनमें कई सेक्शन नहीं होते, लेकिन आप इन्हें विभिन्न प्रस्तुतियों के परिदृश्यों में भी उपयोग कर सकते हैं।

स्लाइड ज़ूम आपको कई जानकारी के टुकड़े एक ही कैनवास पर देखने जैसा महसूस कराते हैं।

![overview_image](slidezoomsel.png)

स्लाइड ज़ूम ऑब्जेक्ट्स के लिए, Aspose.Slides [ZoomImageType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ZoomImageType) enumeration, [ZoomFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ZoomFrame) class, और [ShapeCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeCollection) class के तहत कुछ विधियों को प्रदान करता है।

### **जूम फ्रेम बनाना**

आप स्लाइड पर इस प्रकार जूम फ्रेम जोड़ सकते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) वर्ग का उदाहरण बनाएं।
2. जूम फ्रेम को लिंक करने के लिए नई स्लाइड्स बनाएं। 
3. बनाई गई स्लाइड्स में एक पहचान पाठ और पृष्ठभूमि जोड़ें।
4. पहली स्लाइड में जूम फ्रेम्स (बनाई गई स्लाइड्स के रेफ़रेंस सहित) जोड़ें।
5. परिवर्तनशुदा प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```javascript
var pres = new aspose.slides.Presentation();
try {
    // प्रस्तुति में नई स्लाइड्स जोड़ता है
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // दूसरी स्लाइड के लिए बैकग्राउंड बनाता है
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // दूसरी स्लाइड के लिए टेक्स्ट बॉक्स बनाता है
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // तीसरी स्लाइड के लिए बैकग्राउंड बनाता है
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // तीसरी स्लाइड के लिए टेक्स्ट बॉक्स बनाता है
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // ZoomFrame ऑब्जेक्ट्स जोड़ता है
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // प्रस्तुति को सेव करता है
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **कस्टम इमेज के साथ जूम फ्रेम बनाना**

Aspose.Slides for Node.js via Java के साथ आप इस प्रकार एक अलग स्लाइड प्रीव्यू इमेज के साथ जूम फ्रेम बना सकते हैं:
1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) वर्ग का उदाहरण बनाएं।
2. जूम फ्रेम को लिंक करने के लिए नई स्लाइड बनाएं। 
3. स्लाइड में पहचान पाठ और पृष्ठभूमि जोड़ें।
4. एक [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PPImage) ऑब्जेक्ट बनाएं जिससे इमेज को उन Images संग्रह में जोड़ें जो [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) ऑब्जेक्ट से संबंधित हों और जो फ्रेम को भरने के लिए उपयोग की जाएगी।
5. पहली स्लाइड में जूम फ्रेम्स (बनाई गई स्लाइड के रेफ़रेंस सहित) जोड़ें।
6. परिवर्तनशुदा प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```javascript
var pres = new aspose.slides.Presentation();
try {
    // प्रेज़ेंटेशन में एक नई स्लाइड जोड़ता है
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // दूसरी स्लाइड के लिए बैकग्राउंड बनाता है
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // तीसरी स्लाइड के लिए टेक्स्ट बॉक्स बनाता है
    var autoshape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // ज़ूम ऑब्जेक्ट के लिए नई इमेज बनाता है
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // ZoomFrame ऑब्जेक्ट जोड़ता है
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);
    // प्रेज़ेंटेशन को सेव करता है
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **जूम फ्रेम का स्वरूपण**

पिछले अनुभागों में हमने सरल जूम फ्रेम बनाना दर्शाया। अधिक जटिल जूम फ्रेम बनाने के लिए आपको एक साधारण फ्रेम के स्वरूपण को बदलना होगा। जूम फ्रेम पर लागू करने योग्य कई स्वरूपण विकल्प हैं। 

आप स्लाइड पर जूम फ्रेम के स्वरूपण को इस प्रकार नियंत्रित कर सकते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) वर्ग का उदाहरण बनाएं।
2. जूम फ्रेम को लिंक करने के लिए नई स्लाइड्स बनाएं। 
3. बनाई गई स्लाइड्स में कुछ पहचान पाठ और पृष्ठभूमि जोड़ें।
4. पहली स्लाइड में जूम फ्रेम्स (बनाई गई स्लाइड्स के रेफ़रेंस सहित) जोड़ें।
5. एक [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PPImage) ऑब्जेक्ट बनाएं जिससे इमेज को उन Images संग्रह में जोड़ें जो [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) ऑब्जेक्ट से संबंधित हों और जो फ्रेम को भरने के लिए उपयोग की जाएगी।
6. पहले जूम फ्रेम ऑब्जेक्ट के लिए एक कस्टम इमेज सेट करें।
7. दूसरे जूम फ्रेम ऑब्जेक्ट के लिए लाइन फ़ॉर्मेट बदलें।
8. दूसरे जूम फ्रेम ऑब्जेक्ट की इमेज से पृष्ठभूमि हटाएँ।
5. परिवर्तनशुदा प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```javascript
var pres = new aspose.slides.Presentation();
try {
    // प्रस्तुति में नई स्लाइड्स जोड़ता है
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // दूसरी स्लाइड के लिए बैकग्राउंड बनाता है
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // दूसरी स्लाइड के लिए टेक्स्ट बॉक्स बनाता है
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // तीसरी स्लाइड के लिए बैकग्राउंड बनाता है
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // तीसरी स्लाइड के लिए टेक्स्ट बॉक्स बनाता है
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // ZoomFrame ऑब्जेक्ट्स जोड़ता है
    var zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    var zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // ज़ूम ऑब्जेक्ट के लिए नई इमेज बनाता है
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // zoomFrame1 ऑब्जेक्ट के लिए कस्टम इमेज सेट करता है
    zoomFrame1.setImage(picture);
    // zoomFrame2 ऑब्जेक्ट के लिए ज़ूम फ्रेम फ़ॉर्मेट सेट करता है
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "pink"));
    zoomFrame2.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // zoomFrame2 ऑब्जेक्ट के लिए पृष्ठभूमि न दिखाने की सेटिंग
    zoomFrame2.setShowBackground(false);
    // प्रस्तुति को सेव करता है
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **सेक्शन ज़ूम**

सेक्शन ज़ूम आपके प्रस्तुति के एक सेक्शन के लिए लिंक होता है। आप सेक्शन ज़ूम का उपयोग उन सेक्शन पर वापस जाने के लिए कर सकते हैं जिन्हें आप विशेष रूप से उजागर करना चाहते हैं। या आप इसका उपयोग करके दिखा सकते हैं कि आपके प्रस्तुति के कुछ भाग कैसे आपस में जुड़े हुए हैं। 

![overview_image](seczoomsel.png)

सेक्शन ज़ूम ऑब्जेक्ट्स के लिए, Aspose.Slides [SectionZoomFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SectionZoomFrame) क्लास और [ShapeCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeCollection) क्लास के तहत कुछ मेथड प्रदान करता है।

### **सेक्शन ज़ूम फ्रेम बनाना**

आप स्लाइड पर इस प्रकार सेक्शन ज़ूम फ्रेम जोड़ सकते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) वर्ग का उदाहरण बनाएं।
2. एक नई स्लाइड बनाएं। 
3. बनाई गई स्लाइड में पहचान पृष्ठभूमि जोड़ें।
4. वह नया सेक्शन बनाएं जिसे आप जूम फ्रेम के साथ लिंक करना चाहते हैं। 
5. पहली स्लाइड में सेक्शन ज़ूम फ्रेम (बनाए गए सेक्शन के रेफ़रेंस सहित) जोड़ें।
6. परिवर्तनशुदा प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```javascript
var pres = new aspose.slides.Presentation();
try {
    // प्रेज़ेंटेशन में एक नई स्लाइड जोड़ता है
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // प्रेज़ेंटेशन में एक नया सेक्शन जोड़ता है
    pres.getSections().addSection("Section 1", slide);
    // SectionZoomFrame ऑब्जेक्ट जोड़ता है
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // प्रेज़ेंटेशन को सेव करता है
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **कस्टम इमेज के साथ सेक्शन ज़ूम फ्रेम बनाना**

Aspose.Slides for Node.js via Java का उपयोग करके आप इस प्रकार एक अलग स्लाइड प्रीव्यू इमेज के साथ सेक्शन ज़ूम फ्रेम बना सकते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) वर्ग का उदाहरण बनाएं।
2. नई स्लाइड बनाएं।
3. बनाई गई स्लाइड में पहचान पृष्ठभूमि जोड़ें।
4. वह नया सेक्शन बनाएं जिसे आप जूम फ्रेम के साथ लिंक करना चाहते हैं। 
5. एक [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PPImage) ऑब्जेक्ट बनाएं जिससे इमेज को उन Images संग्रह में जोड़ें जो [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) ऑब्जेक्ट से संबंधित हों और जो फ्रेम को भरने के लिए उपयोग की जाएगी।
5. पहली स्लाइड में सेक्शन ज़ूम फ्रेम (बनाए गए सेक्शन के रेफ़रेंस सहित) जोड़ें।
6. परिवर्तनशुदा प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```javascript
var pres = new aspose.slides.Presentation();
try {
    // प्रेज़ेंटेशन में नई स्लाइड जोड़ता है
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // प्रेज़ेंटेशन में नया सेक्शन जोड़ता है
    pres.getSections().addSection("Section 1", slide);
    // ज़ूम ऑब्जेक्ट के लिए नई इमेज बनाता है
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // SectionZoomFrame ऑब्जेक्ट जोड़ता है
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);
    // प्रेज़ेंटेशन को सेव करता है
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **सेक्शन ज़ूम फ्रेम का स्वरूपण**

अधिक जटिल सेक्शन ज़ूम फ्रेम बनाने के लिए आपको एक साधारण फ्रेम के स्वरूपण को बदलना होगा। सेक्शन ज़ूम फ्रेम पर लागू करने योग्य कई स्वरूपण विकल्प हैं। 

आप स्लाइड पर सेक्शन ज़ूम फ्रेम के स्वरूपण को इस प्रकार नियंत्रित कर सकते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) वर्ग का उदाहरण बनाएं।
2. नई स्लाइड बनाएं।
3. बनाई गई स्लाइड में पहचान पृष्ठभूमि जोड़ें।
4. वह नया सेक्शन बनाएं जिसे आप जूम फ्रेम के साथ लिंक करना चाहते हैं। 
5. पहली स्लाइड में सेक्शन ज़ूम फ्रेम (बनाए गए सेक्शन के रेफ़रेंस सहित) जोड़ें।
6. बनाए गए सेक्शन ज़ूम ऑब्जेक्ट का आकार और स्थिति बदलें।
7. एक [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PPImage) ऑब्जेक्ट बनाएं जिससे इमेज को उन Images संग्रह में जोड़ें जो [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) ऑब्जेक्ट से संबंधित हों और जो फ्रेम को भरने के लिए उपयोग की जाएगी।
8. बनाए गए सेक्शन ज़ूम फ्रेम ऑब्जेक्ट के लिए कस्टम इमेज सेट करें।
9. *लिंक्ड सेक्शन से मूल स्लाइड पर लौटने* की क्षमता सेट करें। 
10. सेक्शन ज़ूम फ्रेम ऑब्जेक्ट की इमेज से पृष्ठभूमि हटाएँ।
11. दूसरे जूम फ्रेम ऑब्जेक्ट के लिए लाइन फ़ॉर्मेट बदलें।
12. ट्रांज़िशन की अवधि बदलें।
13. परिवर्तनशुदा प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```javascript
var pres = new aspose.slides.Presentation();
try {
    // प्रेज़ेंटेशन में नई स्लाइड जोड़ता है
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // प्रेज़ेंटेशन में नया सेक्शन जोड़ता है
    pres.getSections().addSection("Section 1", slide);
    // SectionZoomFrame ऑब्जेक्ट जोड़ता है
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // SectionZoomFrame के लिये स्वरूपण
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    sectionZoomFrame.setImage(picture);
    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);
    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    sectionZoomFrame.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5);
    sectionZoomFrame.setTransitionDuration(1.5);
    // प्रेज़ेंटेशन को सेव करता है
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **सारांश ज़ूम**

सारांश ज़ूम एक लैंडिंग पेज की तरह है जहाँ आपके प्रस्तुति के सभी भाग एक साथ प्रदर्शित होते हैं। जब आप प्रस्तुति दे रहे हों, तो आप ज़ूम का उपयोग करके अपनी प्रस्तुति के किसी भी हिस्से से किसी भी क्रम में दूसरे हिस्से पर जा सकते हैं। आप रचनात्मक हो सकते हैं, आगे कूद सकते हैं, या अपने स्लाइड शो के हिस्सों को बिना प्रस्तुति के प्रवाह को बाधित किए पुनः देख सकते हैं।

![overview_image](sumzoomsel.png)

सारांश ज़ूम ऑब्जेक्ट्स के लिए, Aspose.Slides [SummaryZoomFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SummaryZoomFrame), [SummaryZoomSection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SummaryZoomSection), और [SummaryZoomSectionCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SummaryZoomSectionCollection) क्लास और [ShapeCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeCollection) क्लास के तहत कुछ मेथड प्रदान करता है।

### **सारांश ज़ूम बनाना**

आप स्लाइड पर इस प्रकार सारांश ज़ूम फ्रेम जोड़ सकते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) वर्ग का उदाहरण बनाएं।
2. नई स्लाइड्स बनाएं जिनमें पहचान पृष्ठभूमि और नई सेक्शन हों।
3. पहली स्लाइड में सारांश ज़ूम फ्रेम जोड़ें।
4. परिवर्तनशुदा प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```javascript
var pres = new aspose.slides.Presentation();
try {
    // प्रेज़ेंटेशन में नई स्लाइड जोड़ता है
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // प्रेज़ेंटेशन में नया सेक्शन जोड़ता है
    pres.getSections().addSection("Section 1", slide);
    // प्रेज़ेंटेशन में नई स्लाइड जोड़ता है
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // प्रेज़ेंटेशन में नया सेक्शन जोड़ता है
    pres.getSections().addSection("Section 2", slide);
    // प्रेज़ेंटेशन में नई स्लाइड जोड़ता है
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // प्रेज़ेंटेशन में नया सेक्शन जोड़ता है
    pres.getSections().addSection("Section 3", slide);
    // प्रेज़ेंटेशन में नई स्लाइड जोड़ता है
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "green"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // प्रेज़ेंटेशन में नया सेक्शन जोड़ता है
    pres.getSections().addSection("Section 4", slide);
    // सारांश ज़ूम फ्रेम ऑब्जेक्ट जोड़ता है
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // प्रेज़ेंटेशन को सेव करता है
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **सारांश ज़ूम सेक्शन जोड़ना और हटाना**

सभी सेक्शन एक सारांश ज़ूम फ्रेम में [SummaryZoomSection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SummaryZoomSection) ऑब्जेक्ट द्वारा दर्शाए जाते हैं, जो [SummaryZoomSectionCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SummaryZoomSectionCollection) ऑब्जेक्ट में संग्रहीत होते हैं। आप [SummaryZoomSectionCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SummaryZoomSectionCollection) क्लास के माध्यम से सारांश ज़ूम सेक्शन ऑब्जेक्ट को जोड़ या हटा सकते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) वर्ग का उदाहरण बनाएं।
2. नई स्लाइड्स बनाएं जिनमें पहचान पृष्ठभूमि और नई सेक्शन हों।
3. पहली स्लाइड में एक सारांश ज़ूम फ्रेम जोड़ें।
4. प्रस्तुति में एक नई स्लाइड और सेक्शन जोड़ें।
5. बनाए गए सेक्शन को सारांश ज़ूम फ्रेम में जोड़ें।
6. सारांश ज़ूम फ्रेम से पहली सेक्शन को हटाएँ।
7. परिवर्तनशुदा प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```javascript
var pres = new aspose.slides.Presentation();
try {
    // प्रेज़ेंटेशन में नई स्लाइड जोड़ता है
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // प्रेज़ेंटेशन में नया सेक्शन जोड़ता है
    pres.getSections().addSection("Section 1", slide);
    // प्रेज़ेंटेशन में नई स्लाइड जोड़ता है
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // प्रेज़ेंटेशन में नया सेक्शन जोड़ता है
    pres.getSections().addSection("Section 2", slide);
    // SummaryZoomFrame ऑब्जेक्ट जोड़ता है
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // प्रेज़ेंटेशन में नई स्लाइड जोड़ता है
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // प्रेज़ेंटेशन में नया सेक्शन जोड़ता है
    var section3 = pres.getSections().addSection("Section 3", slide);
    // Summary Zoom में सेक्शन जोड़ता है
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);
    // Summary Zoom से सेक्शन हटाता है
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));
    // प्रेज़ेंटेशन को सेव करता है
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **सारांश ज़ूम सेक्शन का स्वरूपण**

अधिक जटिल सारांश ज़ूम सेक्शन ऑब्जेक्ट बनाने के लिए आपको एक साधारण फ्रेम के स्वरूपण को बदलना होगा। सारांश ज़ूम सेक्शन ऑब्जेक्ट पर लागू करने योग्य कई स्वरूपण विकल्प हैं। 

आप सारांश ज़ूम फ्रेम में सारांश ज़ूम सेक्शन ऑब्जेक्ट के स्वरूपण को इस प्रकार नियंत्रित कर सकते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) वर्ग का उदाहरण बनाएं।
2. नई स्लाइड्स बनाएं जिनमें पहचान पृष्ठभूमि और नई सेक्शन हों।
3. पहली स्लाइड में सारांश ज़ूम फ्रेम जोड़ें।
4. `ISummaryZoomSectionCollection` से पहली ऑब्जेक्ट का सारांश ज़ूम सेक्शन ऑब्जेक्ट प्राप्त करें।
7. एक [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PPImage) ऑब्जेक्ट बनाएं जिससे इमेज को उन images संग्रह में जोड़ें जो [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) ऑब्जेक्ट से संबंधित हों और जो फ्रेम को भरने के लिए उपयोग की जाएगी।
8. बनाए गए सेक्शन ज़ूम फ्रेम ऑब्जेक्ट के लिए कस्टम इमेज सेट करें।
9. *लिंक्ड सेक्शन से मूल स्लाइड पर लौटने* की क्षमता सेट करें। 
11. दूसरे ज़ूम फ्रेम ऑब्जेक्ट के लिए लाइन फ़ॉर्मेट बदलें।
12. ट्रांज़िशन की अवधि बदलें।
13. परिवर्तनशुदा प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```javascript
var pres = new aspose.slides.Presentation();
try {
    // प्रेज़ेंटेशन में नई स्लाइड जोड़ता है
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // प्रेज़ेंटेशन में नया सेक्शन जोड़ता है
    pres.getSections().addSection("Section 1", slide);
    // प्रेज़ेंटेशन में नई स्लाइड जोड़ता है
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // प्रेज़ेंटेशन में नया सेक्शन जोड़ता है
    pres.getSections().addSection("Section 2", slide);
    // SummaryZoomFrame ऑब्जेक्ट जोड़ता है
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // पहला SummaryZoomSection ऑब्जेक्ट प्राप्त करता है
    var summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);
    // SummaryZoomSection ऑब्जेक्ट के लिये स्वरूपण
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    summarySection.setImage(picture);
    summarySection.setReturnToParent(false);
    summarySection.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "black"));
    summarySection.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5);
    summarySection.setTransitionDuration(1.5);
    // प्रेज़ेंटेशन को सेव करता है
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**क्या मैं लक्ष्य दिखाने के बाद 'पैरेंट' स्लाइड पर लौटने को नियंत्रित कर सकता हूँ?**

हाँ। [Zoom frame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/zoomframe/) या [section](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sectionzoomframe/) में `setReturnToParent` मेथड है जो सक्षम होने पर दर्शकों को लक्ष्य सामग्री देखने के बाद मूल स्लाइड पर वापस भेज देता है।

**क्या मैं ज़ूम ट्रांज़िशन की 'गति' या अवधि को समायोजित कर सकता हूँ?**

हाँ। ज़ूम में `setTransitionDuration` मेथड उपलब्ध है जिससे आप एनीमेशन की अवधि को नियंत्रित कर सकते हैं।

**क्या प्रस्तुति में ज़ूम ऑब्जेक्ट्स की संख्या पर कोई सीमा है?**

दस्तावेज़ित किसी कठोर API सीमा नहीं है। व्यावहारिक सीमाएँ प्रस्तुति की कुल जटिलता और दर्शक के प्रदर्शन पर निर्भर करती हैं। आप कई ज़ूम फ्रेम जोड़ सकते हैं, लेकिन फ़ाइल आकार और रेंडरिंग समय का ध्यान रखें।