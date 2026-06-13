---
title: जावास्क्रिप्ट में प्रस्तुतियों में अंडाकार जोड़ें
linktitle: अंडाकार
type: docs
weight: 30
url: /hi/nodejs-java/ellipse/
keywords:
- अंडाकार
- आकार
- अंडाकार जोड़ें
- अंडाकार बनाएं
- अंडाकार खींचें
- स्वरूपित अंडाकार
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js में PPT और PPTX प्रस्तुतियों के लिए अंडाकार आकार को बनाना, स्वरूपित करना और नियंत्रित करना सीखें—जावास्क्रिप्ट कोड उदहारण सहित।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint स्लाइड्स में एलिप्स आकार जोड़ने का तरीका दर्शाता है। यह एक साधारण एलिप्स बनाना, स्वरूपित एलिप्स बनाना, और अपडेटेड प्रस्तुति को PPTX फ़ाइल के रूप में सहेजने को कवर करता है। यह एलिप्स की स्थिति और आकार, स्टैकिंग क्रम को नियंत्रित करने, और एनीमेशन इफ़ेक्ट लागू करने जैसे सम्बन्धित प्रश्नों को भी छूता है।

## **एलिप्स बनाएं**
प्रस्तुति की चयनित स्लाइड में एक साधारण एलिप्स जोड़ने के लिए, नीचे दिए गए चरणों का पालन करें:

- एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) क्लास का इंस्टेंस बनाएं।
- इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
- Ellipse प्रकार के AutoShape को [addAutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) मेथड का उपयोग करके, जो [ShapeCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeCollection) ऑब्जेक्ट द्वारा उपलब्ध है, जोड़ें।
- संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने पहली स्लाइड में एक एलिप्स जोड़ा है

```javascript
// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    var sld = pres.getSlides().get_Item(0);
    // अंडाकार प्रकार का AutoShape जोड़ें
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // PPTX फ़ाइल को डिस्क पर लिखें
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **स्वरूपित एलिप्स बनाएं**
स्लाइड में बेहतर स्वरूपित एलिप्स जोड़ने के लिए, नीचे दिए गए चरणों का पालन करें:

- एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) क्लास का इंस्टेंस बनाएं।
- इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
- Ellipse प्रकार के AutoShape को [addAutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) मेथड का उपयोग करके, जो [ShapeCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeCollection) ऑब्जेक्ट द्वारा उपलब्ध है, जोड़ें।
- एलिप्स की Fill Type को Solid सेट करें।
- एलिप्स का रंग सेट करने के लिए SolidFillColor.Color प्रॉपर्टी का उपयोग करें, जो [FillFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/FillFormat) ऑब्जेक्ट द्वारा उपलब्ध कराई गई है, जो [Shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Shape) ऑब्जेक्ट से जुड़ी है।
- एलिप्स की लाइनों का रंग सेट करें।
- एलिप्स की लाइनों की चौड़ाई सेट करें।
- संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने प्रस्तुति की पहली स्लाइड में एक स्वरूपित एलिप्स जोड़ा है।

```javascript
// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    var sld = pres.getSlides().get_Item(0);
    // अंडाकार प्रकार का AutoShape जोड़ें
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // अंडाकार आकार पर कुछ स्वरूपण लागू करें
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Chocolate));
    // अंडाकार की रेखा पर कुछ स्वरूपण लागू करें
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // PPTX फ़ाइल को डिस्क पर लिखें
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
 
## **अक्सर पूछे जाने वाले प्रश्न**

**मैं स्लाइड की इकाइयों के संदर्भ में एलिप्स की ठीक स्थिति और आकार कैसे सेट करूँ?**

निर्देशांक और आकार आमतौर पर **पॉइंट्स** में निर्दिष्ट किए जाते हैं। पूर्वानुमानित परिणामों के लिए, अपनी गणनाएँ स्लाइड के आकार पर आधारित करें और मान सौंपने से पहले आवश्यक मिलीमीटर या इंच को पॉइंट्स में बदलें।

**मैं अन्य वस्तुओं के ऊपर या नीचे एलिप्स कैसे रखूँ (स्टैकिंग क्रम नियंत्रित करने के लिए)?**

ऑब्जेक्ट की ड्राइंग क्रम को सामने लाकर या पीछे भेजकर समायोजित करें। इससे एलिप्स अन्य वस्तुओं को ओवरलैप कर सकता है या उनके नीचे की वस्तुओं को दिखा सकता है।

**मैं एलिप्स की उपस्थिति या महत्व को कैसे एनीमेट करूँ?**

[Apply](/slides/hi/nodejs-java/shape-animation/) प्रवेश, महत्व या निकास इफ़ेक्ट को आकार पर लागू करें, और ट्रिगर व टाइमिंग कॉन्फ़िगर करके एनीमेशन कब और कैसे चले, निर्धारित करें।