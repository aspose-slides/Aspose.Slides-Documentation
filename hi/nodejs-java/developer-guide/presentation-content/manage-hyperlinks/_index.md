---
title: जावास्क्रिप्ट में प्रस्तुति हाइपरलिंक प्रबंधित करें
linktitle: हाइपरलिंक प्रबंधित करें
type: docs
weight: 20
url: /hi/nodejs-java/manage-hyperlinks/
keywords:
- URL जोड़ें
- हाइपरलिंक जोड़ें
- हाइपरलिंक बनाएं
- हाइपरलिंक स्वरूपित करें
- हाइपरलिंक हटाएं
- हाइपरलिंक अपडेट करें
- पाठ हाइपरलिंक
- स्लाइड हाइपरलिंक
- आकृति हाइपरलिंक
- छवि हाइपरलिंक
- वीडियो हाइपरलिंक
- परिवर्तनीय हाइपरलिंक
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js के साथ PowerPoint और OpenDocument प्रस्तुतियों में हाइपरलिंक को सहजता से प्रबंधित करें—कुछ ही मिनटों में इंटरैक्टिविटी और कार्यप्रवाह में सुधार करें।"
---
## **परिचय**

हाइपरलिंक एक वस्तु, डेटा या किसी स्थान का संदर्भ होता है। PowerPoint प्रस्तुतियों में ये सामान्य हाइपरलिंक होते हैं:

* पाठ, आकृति या मीडिया के भीतर वेबसाइटों के लिंक
* स्लाइडों के लिंक

Aspose.Slides for Node.js via Java आपको प्रस्तुतियों में हाइपरलिंक से संबंधित कई कार्य करने की अनुमति देता है।

{{% alert color="primary" %}} 

आप Aspose सरल, [नि:शुल्क ऑनलाइन PowerPoint संपादक.](https://products.aspose.app/slides/hi/editor) देखना चाह सकते हैं।

{{% /alert %}} 

## **URL हाइपरलिंक जोड़ना**

### **पाठ में URL हाइपरलिंक जोड़ना**

यह JavaScript कोड आपको दिखाता है कि कैसे किसी पाठ में वेबसाइट हाइपरलिंक जोड़ा जाए:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.addTextFrame("Aspose: File Format APIs");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    portionFormat.setFontHeight(32);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **आकृतियों या फ्रेम में URL हाइपरलिंक जोड़ना**

यह JavaScript नमूना कोड आपको दिखाता है कि कैसे एक आकृति में वेबसाइट हाइपरलिंक जोड़ा जाए:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);
    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **मीडिया में URL हाइपरलिंक जोड़ना**

Aspose.Slides आपको चित्रों, ऑडियो और वीडियो फ़ाइलों में हाइपरलिंक जोड़ने की अनुमति देता है। 

यह नमूना कोड आपको दिखाता है कि कैसे **चित्र** में हाइपरलिंक जोड़ा जाए:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // प्रस्तुति में चित्र जोड़ता है
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // पहले जोड़ी गई छवि के आधार पर स्लाइड 1 पर चित्र फ्रेम बनाता है
    var pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pictureFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

यह नमूना कोड आपको दिखाता है कि कैसे **ऑडियो फ़ाइल** में हाइपरलिंक जोड़ा जाए:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var audio = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.mp3")));
    var audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);
    audioFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    audioFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

यह नमूना कोड आपको दिखाता है कि कैसे **वीडियो** में हाइपरलिंक जोड़ा जाए:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var video = pres.getVideos().addVideo(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "video.avi")));
    var videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);
    videoFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    videoFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert  title="Tip"  color="primary"  %}} 

आप *[Manage OLE](/slides/hi/nodejs-java/manage-ole/)* देखना चाह सकते हैं।

{{% /alert %}}

## **हाइपरलिंक का उपयोग करके अनुक्रमणिका बनाना**

चूंकि हाइपरलिंक आपको वस्तुओं या स्थानों के संदर्भ जोड़ने की अनुमति देता है, आप उनका उपयोग करके अनुक्रमणिका बना सकते हैं। 

यह नमूना कोड आपको दिखाता है कि कैसे हाइपरलिंक के साथ अनुक्रमणिका बनाई जाए:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var firstSlide = pres.getSlides().get_Item(0);
    var secondSlide = pres.getSlides().addEmptySlide(firstSlide.getLayoutSlide());
    var contentTable = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    contentTable.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    contentTable.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    contentTable.getTextFrame().getParagraphs().clear();
    var paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");
    var linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);
    paragraph.getPortions().add(linkPortion);
    contentTable.getTextFrame().getParagraphs().add(paragraph);
    pres.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **हाइपरलिंक का स्वरूपण**

### **रंग**

आप [Hyperlink](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Hyperlink) वर्ग में [setColorSource](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Hyperlink#setColorSource-int-) मेथड का उपयोग करके हाइपरलिंक का रंग सेट कर सकते हैं और हाइपरलिंक से रंग जानकारी भी प्राप्त कर सकते हैं। यह सुविधा पहली बार PowerPoint 2019 में प्रस्तुत की गई थी, इसलिए इस गुण में किए गए परिवर्तन पुराने PowerPoint संस्करणों पर लागू नहीं होते हैं।

यह नमूना कोड एक ऑपरेशन दर्शाता है जहाँ अलग-अलग रंगों के हाइपरलिंक एक ही स्लाइड में जोड़े गए:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.addTextFrame("This is a sample of colored hyperlink.");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    portionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    var shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.addTextFrame("This is a sample of usual hyperlink.");
    shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    pres.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **प्रस्तुतियों में हाइपरलिंक हटाना**

### **पाठ से हाइपरलिंक हटाना**

यह JavaScript कोड आपको दिखाता है कि प्रस्तुति स्लाइड के पाठ से हाइपरलिंक कैसे हटाया जाए:

```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            // जांचें कि आकृति टेक्स्ट फ्रेम (IAutoShape) का समर्थन करती है।
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                var autoShape = shape;
                // टेक्स्ट फ्रेम में पैराग्राफ़ों पर इटररेट करें
                for (let i1 = 0; i1 < autoShape.getTextFrame().getParagraphs().getCount(); i1++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i1);
                    // पैराग्राफ़ में प्रत्येक भाग पर इटररेट करें
                    for (let j1 = 0; j1 < paragraph.getPortions().getCount(); j1++) {
                        let portion = paragraph.getPortions().get_Item(j1)
                        portion.setText(portion.getText().replace("years", "months"));// पाठ बदलता है
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// फ़ॉर्मेट बदलता है
                    }
                }
            }
        }
    }
    // संशोधित प्रस्तुति को सहेजें
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **आकृतियों या फ्रेम से हाइपरलिंक हटाना**

यह JavaScript कोड आपको दिखाता है कि प्रस्तुति स्लाइड की आकृति से हाइपरलिंक कैसे हटाया जाए:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        shape.getHyperlinkManager().removeHyperlinkClick();
    }
    pres.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **परिवर्तनीय हाइपरलिंक**

[Hyperlink](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Hyperlink) वर्ग परिवर्तनशील है। इस वर्ग के साथ आप इन गुणों के मान बदल सकते हैं:

- [Hyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Hyperlink#setTargetFrame-java.lang.String-)
- [Hyperlink.setTooltip(String value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Hyperlink#setTooltip-java.lang.String-)
- [Hyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Hyperlink#setHistory-boolean-)
- [Hyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Hyperlink#setHighlightClick-boolean-)
- [Hyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick-boolean-)

यह कोड स्निपेट आपको दिखाता है कि कैसे स्लाइड में हाइपरलिंक जोड़ा जाए और बाद में उसका टूलटिप संपादित किया जाए:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.addTextFrame("Aspose: File Format APIs");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    portionFormat.setFontHeight(32);
    pres.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **IHyperlinkQueries में समर्थित गुण**

आप प्रस्तुति, स्लाइड या पाठ से [HyperlinkQueries](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/HyperlinkQueries) तक पहुंच सकते हैं, जिसके लिए हाइपरलिंक परिभाषित है।

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries--)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries--)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries--)

[HyperlinkQueries](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/HyperlinkQueries) वर्ग इन मेथड और गुणों का समर्थन करता है:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks--)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers--)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks--)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks--)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं आंतरिक नेविगेशन केवल स्लाइड के बजाय "सेक्शन" या सेक्शन की पहली स्लाइड के लिए कैसे बना सकता हूँ?**

PowerPoint में सेक्शन स्लाइडों के समूह होते हैं; नेविगेशन तकनीकी रूप से किसी विशेष स्लाइड को लक्षित करता है। "सेक्शन पर नेविगेट करने" के लिए, आप आमतौर पर उसकी पहली स्लाइड से लिंक करते हैं।

**क्या मैं मास्टर स्लाइड तत्वों पर हाइपरलिंक संलग्न कर सकता हूँ ताकि यह सभी स्लाइडों पर कार्य करे?**

हां। मास्टर स्लाइड और लेआउट तत्व हाइपरलिंक का समर्थन करते हैं। ऐसे लिंक चाइल्ड स्लाइडों पर दिखाई देते हैं और स्लाइडशो के दौरान क्लिक करने योग्य होते हैं।

**क्या PDF, HTML, इमेज या वीडियो में निर्यात करते समय हाइपरलिंक बरकरार रहेंगे?**

In [PDF](/slides/hi/nodejs-java/convert-powerpoint-to-pdf/) और [HTML](/slides/hi/nodejs-java/convert-powerpoint-to-html/) में, हां—लिंक सामान्यतः संरक्षित रहते हैं। जब [images](/slides/hi/nodejs-java/convert-powerpoint-to-png/) और [video](/slides/hi/nodejs-java/convert-powerpoint-to-video/) में निर्यात किया जाता है, तो क्लिक करने योग्यता इन फ़ॉर्मेट की प्रकृति के कारण नहीं रहती (रास्टर फ्रेम/वीडियो हाइपरलिंक का समर्थन नहीं करता)।