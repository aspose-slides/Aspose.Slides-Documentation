---
title: "जावा में ऑटोफ़िट के साथ अपनी प्रस्तुतियों को बेहतर बनाएं"
linktitle: "ऑटोफ़िट सेटिंग्स"
type: docs
weight: 30
url: /hi/java/manage-autofit-settings/
keywords:
- टेक्स्ट बॉक्स
- ऑटोफ़िट
- ऑटोफ़िट न करें
- टेक्स्ट फिट करें
- टेक्स्ट संकुचित करें
- टेक्स्ट रैप करें
- आकार बदलें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में ऑटोफ़िट सेटिंग्स को प्रबंधित करके, अपनी PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट प्रदर्शित करने को अनुकूलित करें और सामग्री की पठनीयता में सुधार करें।"
---
## **परिचय**

डिफ़ॉल्ट रूप से, जब आप एक textbox जोड़ते हैं, Microsoft PowerPoint **Resize shape to fix text** सेटिंग का उपयोग करता है—यह स्वचालित रूप से textbox का आकार बदलता है ताकि उसका टेक्स्ट हमेशा उसमें फिट हो सके।

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* जब textbox में टेक्स्ट लंबा या बड़ा हो जाता है, PowerPoint स्वचालित रूप से textbox को बड़ा कर देता है—उसकी ऊँचाई बढ़ाता है—ताकि वह अधिक टेक्स्ट समा सके।  
* जब textbox में टेक्स्ट छोटा या कम हो जाता है, PowerPoint स्वचालित रूप से textbox को छोटा कर देता है—उसकी ऊँचाई घटाता है—ताकि अतिरिक्त खाली स्थान हटाया जा सके।  

PowerPoint में, textbox के autofit व्यवहार को नियंत्रित करने वाले 4 महत्वपूर्ण पैरामीटर या विकल्प हैं:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Java समान विकल्प प्रदान करता है—कुछ प्रॉपर्टीज़ [TextFrameFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/TextFrameFormat) क्लास के तहत—जो प्रस्तुतियों में textbox के autofit व्यवहार को नियंत्रित करने देती हैं। 

## **टेक्स्ट के अनुसार आकार बदलें**

यदि आप चाहते हैं कि बॉक्स का टेक्स्ट हमेशा उस बॉक्स में फिट रहे, तो आपको **Resize shape to fix text** विकल्प का उपयोग करना होगा। इस सेटिंग को निर्दिष्ट करने के लिए, [AutofitType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/TextFrameFormat#getAutofitType--) प्रॉपर्टी (जो [TextFrameFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/TextFrameFormat) क्लास में है) को `Shape` पर सेट करें।

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

यह Java कोड दिखाता है कि PowerPoint प्रस्तुति में टेक्स्ट को हमेशा उसके बॉक्स में फिट रखने के लिए कैसे निर्दिष्ट करें:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Shape);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

यदि टेक्स्ट लंबा या बड़ा हो जाता है, तो textbox स्वचालित रूप से आकार बदल लेगा (ऊँचाई बढ़ेगी) ताकि सभी टेक्स्ट उसमें फिट हो सके। यदि टेक्स्ट छोटा हो जाता है, तो इसके विपरीत होगा। 

## **Do Not Autofit**

यदि आप चाहते हैं कि textbox या shape का आकार टेक्स्ट में बदलाव के बावजूद अपरिवर्तित रहे, तो आपको **Do not Autofit** विकल्प का उपयोग करना होगा। इस सेटिंग को निर्दिष्ट करने के लिए, [AutofitType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/TextFrameFormat#getAutofitType--) प्रॉपर्टी (जो [TextFrameFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/TextFrameFormat) क्लास में है) को `None` पर सेट करें। 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

यह Java कोड दिखाता है कि PowerPoint प्रस्तुति में textbox का आकार हमेशा स्थिर रखने के लिए कैसे निर्दिष्ट करें:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.None);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

जब टेक्स्ट बॉक्स के लिए बहुत लंबा हो जाता है, तो वह बाहर निकल जाता है। 

## **Shrink Text on Overflow**

यदि टेक्स्ट बॉक्स के लिए बहुत लंबा हो जाता है, तो **Shrink text on overflow** विकल्प के माध्यम से आप यह निर्दिष्ट कर सकते हैं कि टेक्स्ट का आकार और स्पेसिंग घटाया जाए ताकि वह बॉक्स में फिट हो सके। इस सेटिंग को निर्दिष्ट करने के लिए, [AutofitType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/TextFrameFormat#getAutofitType--) प्रॉपर्टी (जो [TextFrameFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/TextFrameFormat) क्लास में है) को `Normal` पर सेट करें। 

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

यह Java कोड दिखाता है कि PowerPoint प्रस्तुति में overflow पर टेक्स्ट को छोटा करने के लिए कैसे निर्दिष्ट करें:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Normal);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
जब **Shrink text on overflow** विकल्प का उपयोग किया जाता है, तो यह सेटिंग केवल तभी लागू होती है जब टेक्स्ट बॉक्स के लिए बहुत लंबा हो जाता है। 
{{% /alert %}}

## **Wrap Text**

यदि आप चाहते हैं कि टेक्स्ट shape के भीतर wrap हो जाए जब टेक्स्ट shape की सीमा (सिर्फ चौड़ाई) से बाहर निकल जाए, तो आपको **Wrap text in shape** पैरामीटर का उपयोग करना होगा। इस सेटिंग को निर्दिष्ट करने के लिए, आपको [WrapText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/TextFrameFormat#getWrapText--) प्रॉपर्टी (जो [TextFrameFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/TextFrameFormat) क्लास में है) को `true` पर सेट करना होगा। 

यह Java कोड दिखाता है कि PowerPoint प्रस्तुति में Wrap Text सेटिंग का उपयोग कैसे करें:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(NullableBool.True);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
यदि आप किसी shape के लिए `WrapText` प्रॉपर्टी को `False` पर सेट करते हैं, तो जब shape के भीतर का टेक्स्ट shape की चौड़ाई से लंबा हो जाता है, तो टेक्स्ट एक ही लाइन में shape की सीमाओं के बाहर तक विस्तार कर लेता है। 
{{% /alert %}}

## **FAQ**

**क्या टेक्स्ट फ्रेम के आंतरिक मार्जिन AutoFit को प्रभावित करते हैं?**

हाँ। Padding (आंतरिक मार्जिन) टेक्स्ट के उपयोग योग्य क्षेत्र को घटा देता है, इसलिए AutoFit जल्दी सक्रिय हो जाता है—फ़ॉन्ट छोटा करने या shape का आकार बदलने से पहले। AutoFit को ट्यून करने से पहले मार्जिन की जाँच और समायोजन करें।

**AutoFit मैन्युअल और सॉफ्ट लाइन ब्रेक्स के साथ कैसे इंटरैक्ट करता है?**

फ़ोर्स्ड ब्रेक्स अपनी जगह बनाये रखते हैं, और AutoFit उनके आसपास फ़ॉन्ट आकार और स्पेसिंग को समायोजित करता है। अनावश्यक ब्रेक्स को हटाने से अक्सर AutoFit को टेक्स्ट को कम करने की ज़रूरत कम हो जाती है।

**क्या थीम फ़ॉन्ट बदलने या फ़ॉन्ट प्रतिस्थापन को ट्रिगर करने से AutoFit परिणाम प्रभावित होते हैं?**

हाँ। विभिन्न glyph मेट्रिक्स वाले फ़ॉन्ट में बदलने से टेक्स्ट की चौड़ाई/ऊँचाई बदलती है, जिससे अंतिम फ़ॉन्ट आकार और लाइन रैपिंग बदल सकती है। किसी भी फ़ॉन्ट परिवर्तन या प्रतिस्थापन के बाद स्लाइड्स की पुनः जाँच करें।