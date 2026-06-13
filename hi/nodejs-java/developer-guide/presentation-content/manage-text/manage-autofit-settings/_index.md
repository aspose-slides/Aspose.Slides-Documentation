---
title: "ऑटोफ़िट के साथ जावास्क्रिप्ट में अपनी प्रस्तुतियों को बेहतर बनाएं"
linktitle: "ऑटोफ़िट सेटिंग्स"
type: docs
weight: 30
url: /hi/nodejs-java/manage-autofit-settings/
keywords:
- टेक्स्टबॉक्स
- ऑटोफ़िट
- ऑटोफ़िट न करें
- टेक्स्ट फिट करें
- टेक्स्ट छोटा करें
- टेक्स्ट रैप करें
- आकार बदलें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js में ऑटोफ़िट सेटिंग्स को प्रबंधित करें ताकि आपके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट प्रदर्शन को अनुकूलित किया जा सके और सामग्री की पठनीयता में सुधार हो सके।"
---
## **परिचय**

डिफ़ॉल्ट रूप से, जब आप एक टेक्स्टबॉक्स जोड़ते हैं, Microsoft PowerPoint टेक्स्टबॉक्स के लिए **Resize shape to fix text** सेटिंग का उपयोग करता है—यह स्वचालित रूप से टेक्स्टबॉक्स का आकार बदलता है ताकि उसका टेक्स्ट हमेशा उसमें फिट हो सके।

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* जब टेक्स्टबॉक्स का टेक्स्ट लंबा या बड़ा हो जाता है, PowerPoint स्वचालित रूप से टेक्स्टबॉक्स को बड़ा करता है—उसकी ऊँचाई बढ़ाता है—ताकि अधिक टेक्स्ट समा सके।  
* जब टेक्स्टबॉक्स का टेक्स्ट छोटा या छोटा हो जाता है, PowerPoint स्वचालित रूप से टेक्स्टबॉक्स को छोटा करता है—उसकी ऊँचाई घटाता है—ताकि अतिरिक्त स्थान हटाया जा सके।

PowerPoint में, ये चार महत्वपूर्ण पैरामीटर या विकल्प हैं जो टेक्स्टबॉक्स के ऑटोफ़िट व्यवहार को नियंत्रित करते हैं:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Node.js via Java समान विकल्प प्रदान करता है—[TextFrameFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/TextFrameFormat) वर्ग के कुछ गुण—जो प्रस्तुतियों में टेक्स्टबॉक्स के ऑटोफ़िट व्यवहार को नियंत्रित करने की अनुमति देते हैं।

## **Resize Shape to Fit Text**

यदि आप चाहते हैं कि बॉक्स का टेक्स्ट हमेशा उस बॉक्स में फिट हो, तो आपको **Resize shape to fix text** विकल्प का उपयोग करना होगा। इस सेटिंग को निर्दिष्ट करने के लिए, `Shape` मान के साथ [TextFrameFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/TextFrameFormat) वर्ग की [setAutofitType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) विधि को कॉल करें।

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

यह JavaScript कोड दर्शाता है कि PowerPoint प्रस्तुति में टेक्स्ट को हमेशा उसके बॉक्स में फिट करने के लिए कैसे निर्दिष्ट किया जाए:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Shape);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

यदि टेक्स्ट लंबा या बड़ा हो जाता है, तो टेक्स्टबॉक्स स्वचालित रूप से आकार बदल लेगा (ऊँचाई बढ़ेगी) ताकि सभी टेक्स्ट उसमें फिट हो सके। यदि टेक्स्ट छोटा हो जाता है, तो इसके विपरीत होगा।

## **Do Not Autofit**

यदि आप चाहते हैं कि टेक्स्टबॉक्स या आकार अपने आयामों को बनाए रखे, चाहे उसके अंदर का टेक्स्ट कितना भी बदल जाए, तो आपको **Do not Autofit** विकल्प का उपयोग करना होगा। इस सेटिंग को निर्दिष्ट करने के लिए, `None` मान के साथ [TextFrameFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/TextFrameFormat) वर्ग की [setAutofitType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) विधि को कॉल करें।

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

यह JavaScript कोड दर्शाता है कि PowerPoint प्रस्तुति में टेक्स्टबॉक्स को हमेशा उसका मूल आकार बनाए रखने के लिए कैसे निर्दिष्ट किया जाए:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.None);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

जब टेक्स्ट बॉक्स से बहुत लंबा हो जाता है, तो वह बाहर निकल जाता है।

## **Shrink Text on Overflow**

यदि कोई टेक्स्ट बॉक्स से बहुत लंबा हो जाता है, तो **Shrink text on overflow** विकल्प के माध्यम से आप निर्दिष्ट कर सकते हैं कि टेक्स्ट का आकार और अंतराल कम किया जाए ताकि वह बॉक्स में फिट हो जाए। इस सेटिंग को निर्दिष्ट करने के लिए, `Normal` मान के साथ [TextFrameFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/TextFrameFormat) वर्ग की [setAutofitType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) विधि को कॉल करें।

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

यह JavaScript कोड दर्शाता है कि PowerPoint प्रस्तुति में टेक्स्ट को overflow पर छोटा करने के लिए कैसे निर्दिष्ट किया जाए:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Normal);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="सूचना" color="info" %}}
जब **Shrink text on overflow** विकल्प का उपयोग किया जाता है, तो यह सेटिंग केवल तब लागू होती है जब टेक्स्ट बॉक्स से बहुत लंबा हो जाए।
{{% /alert %}}

## **Wrap Text**

यदि आप चाहते हैं कि आकार के भीतर का टेक्स्ट, जब आकार की सीमा (केवल चौड़ाई) से बाहर जाता है, तो वह आकार के अंदर ही रैप हो जाए, तो आपको **Wrap text in shape** पैरामीटर का उपयोग करना होगा। इस सेटिंग को निर्दिष्ट करने के लिए, `true` मान के साथ [TextFrameFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/TextFrameFormat) वर्ग की [setWrapText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/TextFrameFormat#setWrapText) विधि को कॉल करें।

यह JavaScript कोड दर्शाता है कि PowerPoint प्रस्तुति में Wrap Text सेटिंग का उपयोग कैसे किया जाए:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(aspose.slides.NullableBool.True);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="ध्यान दें" color="warning" %}}
यदि आप किसी आकार के लिए `setWrapText` विधि को `False` मान के साथ कॉल करते हैं, तो जब आकार के भीतर का टेक्स्ट आकार की चौड़ाई से अधिक हो जाता है, तो टेक्स्ट एक ही पंक्ति में आकार की सीमाओं से बाहर निकल जाता है।
{{% /alert %}}

## **FAQ**

**क्या टेक्स्ट फ्रेम के आंतरिक मार्जिन AutoFit को प्रभावित करते हैं?**

हाँ। पैडिंग (आंतरिक मार्जिन) टेक्स्ट के उपयोग योग्य क्षेत्र को घटा देती है, इसलिए AutoFit पहले सक्रिय हो जाता है—फ़ॉन्ट को छोटा करता है या आकार को पहले बदलता है। AutoFit को ट्यून करने से पहले मार्जिन जांचें और समायोजित करें।

**AutoFit मैन्युअल और सॉफ़्ट लाइन ब्रेक्स के साथ कैसे इंटरैक्ट करता है?**

फ़ोर्स्ड ब्रेक्स बना रहते हैं, और AutoFit उनके आसपास फ़ॉन्ट आकार और अंतराल को अनुकूलित करता है। अनावश्यक ब्रेक्स को हटाने से अक्सर AutoFit को टेक्स्ट को छोटा करने की आवश्यकता कम हो जाती है।

**क्या थीम फ़ॉन्ट बदलने या फ़ॉन्ट प्रतिस्थापन को ट्रिगर करने से AutoFit परिणाम प्रभावित होते हैं?**

हाँ। विभिन्न ग्लिफ़ मीट्रिक्स वाले फ़ॉन्ट में बदलने से टेक्स्ट की चौड़ाई/ऊँचाई बदलती है, जिससे अंतिम फ़ॉन्ट आकार और लाइन रैपिंग बदल सकती है। किसी भी फ़ॉन्ट परिवर्तन या प्रतिस्थापन के बाद स्लाइड्स को पुनः जांचें।