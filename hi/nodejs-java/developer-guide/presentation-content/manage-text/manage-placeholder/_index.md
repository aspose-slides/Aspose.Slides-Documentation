---
title: "जावास्क्रिप्ट में प्रस्तुति प्लेसहोल्डर प्रबंधित करें"
linktitle: "प्लेसहोल्डर प्रबंधित करें"
type: docs
weight: 10
url: /hi/nodejs-java/manage-placeholder/
keywords:
- प्लेसहोल्डर
- पाठ प्लेसहोल्डर
- छवि प्लेसहोल्डर
- चार्ट प्लेसहोल्डर
- प्रॉम्प्ट टेक्स्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js के लिए Aspose.Slides में प्लेसहोल्डर को सहजता से प्रबंधित करें: पाठ बदलें, प्रॉम्प्ट को अनुकूलित करें एवं PowerPoint और OpenDocument में छवि की पारदर्शिता सेट करें।"
---
## **अवलोकन**

Aspose.Slides आपको प्रस्तुति प्लेसहोल्डर को प्रोग्रामmatically प्रबंधित करने की अनुमति देती है। यह लेख बताता है कि स्लाइडों पर प्लेसहोल्डर कैसे खोजें और उनका पाठ बदलें, प्लेसहोल्डर लेआउट के लिए कस्टम प्रॉम्प्ट टेक्स्ट कैसे सेट करें, और प्लेसहोल्डर पृष्ठभूमि के रूप में उपयोग की गई छवि की पारदर्शिता को कैसे समायोजित करें। इसमें एक छोटा FAQ भी शामिल है जो बेस प्लेसहोल्डर और स्थानीय आकार के बीच अंतर बताता है, समझाता है कि प्लेसहोल्डर परिवर्तन लेआउट या मास्टर के माध्यम से कैसे लागू किए जा सकते हैं, और हेडर व फूटर प्लेसहोल्डर प्रबंधन की ओर इशारा करता है।

## **प्लेसहोल्डर में पाठ बदलें**

[ Aspose.Slides for Node.js via Java](/slides/hi/nodejs-java/) का उपयोग करके आप प्रस्तुतियों की स्लाइडों पर प्लेसहोल्डर खोज और संशोधित कर सकते हैं। Aspose.Slides आपको प्लेसहोल्डर के पाठ को बदलने की सुविधा देती है।

**Prerequisite**: आपको एक ऐसी प्रस्तुति चाहिए जिसमें प्लेसहोल्डर हो। आप ऐसी प्रस्तुति माइक्रोसॉफ्ट पावरपॉइंट एप्लिकेशन में बना सकते हैं।

यह है कि आप Aspose.Slides का उपयोग करके उस प्रस्तुति में प्लेसहोल्डर का पाठ कैसे बदलते हैं:

1. [`Presentation`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं और प्रस्तुति को तर्क के रूप में पास करें।  
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
3. आकारों (shapes) को इटररेट करके प्लेसहोल्डर खोजें।  
4. प्लेसहोल्डर आकार को [`AutoShape`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/AutoShape) में टाइपकास्ट करें और associated [`TextFrame`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/TextFrame) का उपयोग करके पाठ बदलें।  
5. संशोधित प्रस्तुति को सहेजें।

यह JavaScript कोड दिखाता है कि प्लेसहोल्डर में पाठ कैसे बदलें:

```javascript
// एक Presentation क्लास का इंस्टेंस बनाता है
var pres = new aspose.slides.Presentation("ReplacingText.pptx");
try {
    // पहली स्लाइड तक पहुंचता है
    var sld = pres.getSlides().get_Item(0);
    // प्लेसहोल्डर खोजने के लिए आकारों (shapes) पर इटररेट करता है
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (shp.getPlaceholder() != null) {
            // प्रत्येक प्लेसहोल्डर में पाठ बदलता है
            shp.getTextFrame().setText("This is Placeholder");
        }
    }
    // प्रेजेंटेशन को डिस्क पर सहेजता है
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **प्लेसहोल्डर में प्रॉम्प्ट टेक्स्ट सेट करें**

स्टैण्डर्ड और प्री‑बिल्ट लेआउट में प्लेसहोल्डर प्रॉम्प्ट टेक्स्ट होते हैं जैसे ***Click to add a title*** या ***Click to add a subtitle***। Aspose.Slides का उपयोग करके आप अपने पसंदीदा प्रॉम्प्ट टेक्स्ट को प्लेसहोल्डर लेआउट में डाल सकते हैं।

यह JavaScript कोड दिखाता है कि प्लेसहोल्डर में प्रॉम्प्ट टेक्स्ट कैसे सेट करें:

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // स्लाइड के माध्यम से इटररेट करता है
    for (let i = 0; i < slide.getSlide().getShapes().size(); i++) {
        let shape = slide.getSlide().getShapes().get_Item(i);
        if ((shape.getPlaceholder() != null) && (java.instanceOf(shape, "com.aspose.slides.AutoShape"))) {
            var text = "";
            // PowerPoint "Click to add title" दर्शाता है
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.CenteredTitle) {
                text = "Add Title";
            } else // उपशीर्षक जोड़ता है
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.Subtitle) {
                text = "Add Subtitle";
            }
            shape.getTextFrame().setText(text);
            console.log("Placeholder with text: " + text);
        }
    }
    pres.save("Placeholders_PromptText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **प्लेसहोल्डर छवि की पारदर्शिता सेट करें**

Aspose.Slides आपको टेक्स्ट प्लेसहोल्डर की पृष्ठभूमि छवि की पारदर्शिता सेट करने की अनुमति देती है। ऐसी फ्रेम में चित्र की पारदर्शिता समायोजित करके आप पाठ या चित्र को बेहतर बना सकते हैं (पाठ और चित्र के रंगों पर निर्भर करता है)।

यह JavaScript कोड दिखाता है कि चित्र पृष्ठभूमि (एक आकार के भीतर) की पारदर्शिता कैसे सेट करें:

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (var i = 0; i < operationCollection.size(); i++) {
    if (java.instanceOf(operationCollection.get_Item(i), "com.aspose.slides.AlphaModulateFixed")) {
        var alphaModulate = operationCollection.get_Item(i);
        var currentValue = 100 - alphaModulate.getAmount();
        console.log("Current transparency value: " + currentValue);
        var alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}
presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
```

## **FAQ**

**एक बेस प्लेसहोल्डर क्या है, और यह स्लाइड पर स्थानीय आकार से कैसे अलग है?**

एक बेस प्लेसहोल्डर वह मूल आकार है जो लेआउट या मास्टर पर होता है और जिससे स्लाइड का आकार प्रकार, स्थिति और कुछ फॉर्मेटिंग विरासत में लेता है। एक स्थानीय आकार स्वतंत्र होता है; यदि कोई बेस प्लेसहोल्डर नहीं है, तो विरासत लागू नहीं होती।

**मैं बिना प्रत्येक स्लाइड पर इटररेटर किए पूरी प्रस्तुति में सभी शीर्षक या कैप्शन कैसे अपडेट कर सकता हूँ?**

लेआउट या मास्टर पर संबंधित प्लेसहोल्डर को संपादित करें। उन लेआउट/मास्टर पर आधारित स्लाइडें स्वतः परिवर्तन विरासत में ले लेंगी।

**मैं मानक हेडर/फ़ूटर प्लेसहोल्डर—तारीख व समय, स्लाइड नंबर, और फूटर टेक्स्ट—को कैसे नियंत्रित करूँ?**

उचित स्कोप (सामान्य स्लाइड, लेआउट, मास्टर, नोट्स/हैंडआउट) पर HeaderFooter प्रबंधकों का उपयोग करके इन प्लेसहोल्डर को ऑन या ऑफ कर सकते हैं और उनका कंटेंट सेट कर सकते हैं।