---
title: Android पर ऑटॉफ़िट के साथ अपनी प्रस्तुतियों को बेहतर बनाएँ
linktitle: ऑटॉफ़िट सेटिंग्स
type: docs
weight: 30
url: /hi/androidjava/manage-autofit-settings/
keywords:
- टेक्स्टबॉक्स
- ऑटॉफ़िट
- ऑटॉफ़िट न करें
- टेक्स्ट फिट करें
- टेक्स्ट छोटा करें
- टेक्स्ट रैप करें
- आकार बदलें
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android में Java के माध्यम से AutoFit सेटिंग्स को प्रबंधित करके अपने PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट प्रदर्शन को अनुकूलित करें और सामग्री की पठनीयता में सुधार करें।"
---
## **परिचय**

डिफ़ॉल्ट रूप से, जब आप एक टेक्स्टबॉक्स जोड़ते हैं, Microsoft PowerPoint टेक्स्टबॉक्स के लिए **Resize shape to fix text** सेटिंग का उपयोग करता है—यह स्वचालित रूप से टेक्स्टबॉक्स का आकार बदलता है ताकि उसका टेक्स्ट हमेशा उसमें फिट हो सके।

![पावरपॉइंट-में-टेक्स्टबॉक्स](textbox-in-powerpoint.png)

* जब टेक्स्टबॉक्स में टेक्स्ट लंबा या बड़ा हो जाता है, तो PowerPoint स्वचालित रूप से टेक्स्टबॉक्स को ऊँचा कर देता है—उसकी ऊँचाई बढ़ा देता है—ताकि वह अधिक टेक्स्ट रख सके।  
* जब टेक्स्टबॉक्स में टेक्स्ट छोटा या छोटा हो जाता है, तो PowerPoint स्वचालित रूप से टेक्स्टबॉक्स को छोटा कर देता है—उसकी ऊँचाई घटा देता है—ताकि अतिरिक्त जगह हटाई जा सके।

PowerPoint में, ये 4 महत्वपूर्ण पैरामीटर या विकल्प हैं जो एक टेक्स्टबॉक्स के ऑटोफिट व्यवहार को नियंत्रित करते हैं:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![ऑटोफिट-विकल्प-पावरपॉइंट](autofit-options-powerpoint.png)

Aspose.Slides for Android via Java समान विकल्प प्रदान करता है—[TextFrameFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/TextFrameFormat) क्लास के तहत कुछ प्रॉपर्टीज़—जो आपको प्रस्तुतियों में टेक्स्टबॉक्स के ऑटोफिट व्यवहार को नियंत्रित करने की अनुमति देती हैं।

## **Resize a Shape to Fit Text**

यदि आप चाहते हैं कि बॉक्स में टेक्स्ट हमेशा उस बॉक्स में फिट रहे, भले ही टेक्स्ट में परिवर्तन हों, तो आपको **Resize shape to fix text** विकल्प का उपयोग करना होगा। इस सेटिंग को निर्दिष्ट करने के लिए, [AutofitType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) प्रॉपर्टी (जो [TextFrameFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/TextFrameFormat) क्लास से है) को `Shape` पर सेट करें।

![alwaysfit-सेटिंग-पावरपॉइंट](alwaysfit-setting-powerpoint.png)

यह Java कोड दिखाता है कि कैसे यह निर्दिष्ट किया जाए कि टेक्स्ट को हमेशा अपने बॉक्स में फिट होना चाहिए:

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

यदि टेक्स्ट लंबा या बड़ा हो जाता है, तो टेक्स्टबॉक्स स्वचालित रूप से आकार बदल लेगा (ऊँचाई बढ़ेगी) ताकि सभी टेक्स्ट उसमें फिट हो सके। यदि टेक्स्ट छोटा हो जाता है, तो इसके विपरीत होगा।

## **Do Not Autofit**

यदि आप चाहते हैं कि टेक्स्टबॉक्स या आकार अपनी मापदंडों को बना रखे, चाहे उसमें मौजूद टेक्स्ट में कोई भी परिवर्तन हो, तो आपको **Do not Autofit** विकल्प का उपयोग करना होगा। इस सेटिंग को निर्दिष्ट करने के लिए, [AutofitType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) प्रॉपर्टी को `None` पर सेट करें।

![donotautofit-सेटिंग-पावरपॉइंट](donotautofit-setting-powerpoint.png)

यह Java कोड दिखाता है कि कैसे यह निर्दिष्ट किया जाए कि टेक्स्टबॉक्स हमेशा अपनी मापदंडों को बनाए रखे:

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

जब टेक्स्ट उसके बॉक्स से बहुत लंबा हो जाता है, तो वह बाहर निकल जाता है।

## **Shrink Text on Overflow**

यदि टेक्स्ट उसके बॉक्स से बहुत लंबा हो जाता है, तो **Shrink text on overflow** विकल्प के माध्यम से आप निर्दिष्ट कर सकते हैं कि टेक्स्ट का आकार और स्पेसिंग घटा दी जाए ताकि वह बॉक्स में फिट हो सके। इस सेटिंग को निर्दिष्ट करने के लिए, [AutofitType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) प्रॉपर्टी को `Normal` पर सेट करें।

![shrinktextonoverflow-सेटिंग-पावरपॉइंट](shrinktextonoverflow-setting-powerpoint.png)

यह Java कोड दिखाता है कि कैसे यह निर्दिष्ट किया जाए कि टेक्स्ट को अत्यधिक लम्बे होने पर छोटा किया जाए:

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

जब **Shrink text on overflow** विकल्प का उपयोग किया जाता है, तो यह सेटिंग केवल तब लागू होती है जब टेक्स्ट उसके बॉक्स से बहुत लंबा हो जाता है।

{{% /alert %}}

## **Wrap Text**

यदि आप चाहते हैं कि आकार के भीतर टेक्स्ट बॉर्डर (केवल चौड़ाई) से बाहर जाने पर उसकी सीमा के अंदर रैप हो, तो आपको **Wrap text in shape** पैरामीटर का उपयोग करना होगा। इस सेटिंग को निर्दिष्ट करने के लिए, आपको [WrapText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/TextFrameFormat#getWrapText--) प्रॉपर्टी को `true` पर सेट करना होगा।

यह Java कोड दिखाता है कि PowerPoint प्रस्तुति में Wrap Text सेटिंग कैसे उपयोग की जाए:

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

यदि आप किसी आकार के लिए `WrapText` प्रॉपर्टी को `False` सेट करते हैं, तो जब टेक्स्ट आकार की चौड़ाई से बड़ा हो जाता है, तो टेक्स्ट एक ही पंक्ति में आकार की सीमाओं के बाहर बढ़ जाता है।

{{% /alert %}}

## **FAQ**

**क्या टेक्स्ट फ्रेम के आंतरिक मार्जिन AutoFit को प्रभावित करते हैं?**

हां। पैडिंग (आंतरिक मार्जिन) टेक्स्ट के उपयोग योग्य क्षेत्र को कम कर देती है, इसलिए AutoFit पहले सक्रिय हो जाता है—फ़ॉन्ट को छोटा करके या आकार को जल्दी बदलकर। AutoFit को ट्यून करने से पहले मार्जिन की जाँच और समायोजन करें।

**AutoFit मैन्युअल और सॉफ़्ट लाइन ब्रेक्स के साथ कैसे इंटरैक्ट करता है?**

फ़ोर्स्ड ब्रेक्स वहीं रहते हैं, और AutoFit उनके आसपास फ़ॉन्ट साइज और स्पेसिंग को समायोजित करता है। अनावश्यक ब्रेक्स को हटाने से अक्सर AutoFit को टेक्स्ट को अधिक घटाने की आवश्यकता कम हो जाती है।

**क्या थीम फ़ॉन्ट बदलने या फ़ॉन्ट प्रतिस्थापन को ट्रिगर करने से AutoFit परिणाम प्रभावित होते हैं?**

हां। विभिन्न ग्लिफ़ मेट्रिक्स वाले फ़ॉन्ट में प्रतिस्थापन करने से टेक्स्ट की चौड़ाई/ऊँचाई बदलती है, जिससे अंतिम फ़ॉन्ट साइज और लाइन रैप बदल सकते हैं। किसी भी फ़ॉन्ट परिवर्तन या प्रतिस्थापन के बाद स्लाइड्स की पुनः जाँच करना न भूलें।