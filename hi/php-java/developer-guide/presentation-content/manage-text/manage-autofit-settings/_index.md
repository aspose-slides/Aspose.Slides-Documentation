---
title: PHP में ऑटॉफ़िट के साथ अपनी प्रस्तुतियों को उन्नत बनाएं
linktitle: ऑटॉफ़िट सेटिंग्स
type: docs
weight: 30
url: /hi/php-java/manage-autofit-settings/
keywords:
- टेक्स्टबॉक्स
- ऑटॉफ़िट
- ऑटॉफ़िट न करें
- टेक्स्ट फिट करें
- टेक्स्ट संकुचित करें
- टेक्स्ट रैप करें
- आकार पुन:आकारित करें
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PHP के लिए Aspose.Slides में ऑटॉफ़िट सेटिंग्स प्रबंधित करें ताकि आपके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट प्रदर्शन को अनुकूलित किया जा सके और सामग्री की पठनीयता में सुधार हो।"
---
## **परिचय**

डिफ़ॉल्ट रूप में, जब आप एक टेक्स्टबॉक्स जोड़ते हैं, Microsoft PowerPoint टेक्स्टबॉक्स के लिए **Resize shape to fix text** सेटिंग का उपयोग करता है—यह स्वचालित रूप से टेक्स्टबॉक्स का आकार बदलता है ताकि उसके टेक्स्ट हमेशा उसमें फिट हो सके। 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* जब टेक्स्टबॉक्स में टेक्स्ट लंबा या बड़ा हो जाता है, PowerPoint स्वचालित रूप से टेक्स्टबॉक्स को बड़ा कर देता है—उसकी ऊँचाई बढ़ाता है—ताकि वह अधिक टेक्स्ट रख सके। 
* जब टेक्स्टबॉक्स में टेक्स्ट छोटा या कम हो जाता है, PowerPoint स्वचालित रूप से टेक्स्टबॉक्स को छोटा कर देता है—उसकी ऊँचाई घटाता है—ताकि अतिरिक्त जगह हटाई जा सके। 

PowerPoint में, ये 4 महत्वपूर्ण पैरामीटर या विकल्प हैं जो टेक्स्टबॉक्स के ऑटोफिट व्यवहार को नियंत्रित करते हैं: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for PHP via Java समान विकल्प प्रदान करता है—[TextFrameFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/TextFrameFormat) क्लास के कुछ गुण—जो आपको प्रस्तुतियों में टेक्स्टबॉक्स के ऑटोफिट व्यवहार को नियंत्रित करने की अनुमति देते हैं।

## **शेप को टेक्स्ट में फिट करने के लिए रिसाइज़ करें**

यदि आप चाहते हैं कि बॉक्स में टेक्स्ट हमेशा बदलने के बाद भी उसी बॉक्स में फिट हो, तो आपको **Resize shape to fix text** विकल्प का उपयोग करना होगा। इस सेटिंग को निर्दिष्ट करने के लिए, [AutofitType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/TextFrameFormat#getAutofitType--) प्रॉपर्टी (जो [TextFrameFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/TextFrameFormat) क्लास में है) को `Shape` पर सेट करें।

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

यह PHP कोड दर्शाता है कि कैसे यह निर्धारित किया जाए कि टेक्स्ट को हमेशा PowerPoint प्रस्तुति में उसके बॉक्स में फिट होना चाहिए:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Shape);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

यदि टेक्स्ट लंबा या बड़ा हो जाता है, तो टेक्स्टबॉक्स स्वचालित रूप से रिसाइज़ हो जाएगा (ऊँचाई बढ़ेगी) ताकि सभी टेक्स्ट उसमें फिट हो सके। यदि टेक्स्ट छोटा हो जाता है, तो विपरीत होगा।

## **ऑटोफिट न करें**

यदि आप चाहते हैं कि एक टेक्स्टबॉक्स या शेप अपने आयामों को बनाए रखे, चाहे उसके अंदर के टेक्स्ट में कितनी भी परिवर्तन हों, तो आपको **Do not Autofit** विकल्प का उपयोग करना होगा। इस सेटिंग को निर्दिष्ट करने के लिए, [AutofitType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/TextFrameFormat#getAutofitType--) प्रॉपर्टी (जो [TextFrameFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/TextFrameFormat) क्लास में है) को `None` पर सेट करें।

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

यह PHP कोड दर्शाता है कि कैसे यह निर्दिष्ट किया जाए कि PowerPoint प्रस्तुति में एक टेक्स्टबॉक्स हमेशा अपने आयामों को बनाए रखे:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::None);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

जब टेक्स्ट बॉक्स के लिए बहुत लंबा हो जाता है, तो यह बाहर निकल जाता है।

## **ओवरफ़्लो पर टेक्स्ट को छोटा करना**

यदि टेक्स्ट बॉक्स के लिए बहुत लंबा हो जाता है, तो **Shrink text on overflow** विकल्प के माध्यम से आप निर्धारित कर सकते हैं कि टेक्स्ट का आकार और अंतराल कम किया जाए ताकि वह बॉक्स में फिट हो सके। इस सेटिंग को निर्दिष्ट करने के लिए, [AutofitType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/TextFrameFormat#getAutofitType--) प्रॉपर्टी (जो [TextFrameFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/TextFrameFormat) क्लास में है) को `Normal` पर सेट करें।

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

यह PHP कोड दर्शाता है कि कैसे यह निर्दिष्ट किया जाए कि एक टेक्स्ट को PowerPoint प्रस्तुति में ओवरफ़्लो पर छोटा किया जाना चाहिए:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Normal);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Info" color="info" %}}
जब **Shrink text on overflow** विकल्प का उपयोग किया जाता है, तो सेटिंग केवल तब लागू होती है जब टेक्स्ट बॉक्स के लिए बहुत लंबा हो जाता है।
{{% /alert %}}

## **Wrap Text**

यदि आप चाहते हैं कि किसी शेप में टेक्स्ट उसकी सीमा (केवल चौड़ाई) से बाहर जाने पर उसके भीतर रैप हो, तो आपको **Wrap text in shape** पैरामीटर का उपयोग करना होगा। इस सेटिंग को निर्दिष्ट करने के लिए, आपको [WrapText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/TextFrameFormat#getWrapText--) प्रॉपर्टी (जो [TextFrameFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/TextFrameFormat) क्लास में है) को `true` पर सेट करना होगा।

यह PHP कोड दर्शाता है कि कैसे PowerPoint प्रस्तुति में Wrap Text सेटिंग का उपयोग किया जाए:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setWrapText(NullableBool::True);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 
यदि आप किसी शेप के लिए `WrapText` प्रॉपर्टी को `False` सेट करते हैं, तो जब शेप के भीतर का टेक्स्ट उसकी चौड़ाई से अधिक हो जाता है, तो टेक्स्ट एक ही पंक्ति में शेप की सीमाओं से बाहर तक बढ़ जाता है। 
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या टेक्स्ट फ्रेम के आंतरिक मार्जिन AutoFit को प्रभावित करते हैं?**

हाँ। पैडिंग (आंतरिक मार्जिन) टेक्स्ट के उपयोगी क्षेत्र को घटाता है, इसलिए AutoFit पहले सक्रिय हो जाता है—फ़ॉन्ट को छोटा करने या शेप को जल्दी रिसाइज़ करने के लिए। AutoFit को ट्यून करने से पहले मार्जिन की जाँच करें और आवश्यकतानुसार समायोजित करें।

**AutoFit मैनुअल और सॉफ्ट लाइन ब्रेक्स के साथ कैसे इंटरैक्ट करता है?**

जबरन लगाए गए ब्रेक अपने स्थान पर रहते हैं, और AutoFit उनके चारों ओर फ़ॉन्ट आकार और अंतराल को समायोजित करता है। अनावश्यक ब्रेक हटाने से अक्सर AutoFit को टेक्स्ट को अत्यधिक छोटा करने की आवश्यकता कम हो जाती है।

**क्या थीम फ़ॉन्ट बदलने या फ़ॉन्ट सब्स्टिट्यूशन ट्रिगर करने से AutoFit परिणाम प्रभावित होते हैं?**

हाँ। अलग ग्लिफ़ मेट्रिक्स वाले फ़ॉन्ट में बदलने से टेक्स्ट की चौड़ाई/ऊँचाई बदलती है, जिससे अंतिम फ़ॉन्ट आकार और लाइन रैपिंग पर असर पड़ सकता है। किसी भी फ़ॉन्ट परिवर्तन या सब्स्टिट्यूशन के बाद स्लाइड्स को पुनः जांचें।