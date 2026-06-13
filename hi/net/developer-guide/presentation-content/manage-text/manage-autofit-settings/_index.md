---
title: AutoFit के साथ .NET में अपनी प्रस्तुतियों को बेहतर बनाएं
linktitle: ऑटोफ़िट सेटिंग्स
type: docs
weight: 30
url: /hi/net/manage-autofit-settings/
keywords:
- टेक्स्टबॉक्स
- ऑटोफ़िट
- ऑटोफ़िट न करें
- टेक्स्ट फिट करें
- टेक्स्ट घटाएँ
- टेक्स्ट रैप करें
- आकार री-साइज़ करें
- PowerPoint
- प्रस्तुति
- C#
- .NET
- Aspose.Slides
description: "Aspose.Slides for .NET में AutoFit सेटिंग्स को कैसे प्रबंधित करें, ताकि आपके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट प्रदर्शन को अनुकूलित किया जा सके और सामग्री की पढ़ने योग्यता में सुधार हो।"
---
## **परिचय**

डिफ़ॉल्ट रूप से, जब आप एक टेक्स्टबॉक्स जोड़ते हैं, Microsoft PowerPoint उस टेक्स्टबॉक्स के लिए **Resize shape to fit text** सेटिंग का उपयोग करता है—यह स्वचालित रूप से टेक्स्टबॉक्स का आकार बदलता है ताकि उसका टेक्स्ट हमेशा उसमें फिट हो।

![PowerPoint में एक टेक्स्टबॉक्स](textbox-in-powerpoint.png)

* जब टेक्स्टबॉक्स में टेक्स्ट लंबा या बड़ा हो जाता है, PowerPoint स्वचालित रूप से टेक्स्टबॉक्स को बड़ा कर देता है—उसकी ऊँचाई बढ़ाकर—ताकि वह अधिक टेक्स्ट समा सके।
* जब टेक्स्टबॉक्स में टेक्स्ट छोटा या कम हो जाता है, PowerPoint स्वचालित रूप से टेक्स्टबॉक्स को घटा देता है—उसकी ऊँचाई घटाकर—ताकि बेमतलब की जगह हटाई जा सके।

PowerPoint में ये चार महत्वपूर्ण पैरामीटर या विकल्प हैं जो टेक्स्टबॉक्स के ऑटोफ़िट व्यवहार को नियंत्रित करते हैं:

* **ऑटोफ़िट न करें**
* **ओवरफ़्लो पर टेक्स्ट घटाएँ**
* **आकार को टेक्स्ट में फिट करने के लिए री-साइज़ करें**
* **आकार में टेक्स्ट रैप करें**

![PowerPoint में ऑटोफ़िट विकल्प](autofit-options-powerpoint.png)

Aspose.Slides for .NET समान विकल्प—[TextFrameFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/textframeformat) क्लास के अंतर्गत प्रॉपर्टीज़—प्रदान करता है, जो प्रस्तुतियों में टेक्स्टबॉक्स के ऑटोफ़िट व्यवहार को नियंत्रित करने की अनुमति देती हैं।

## **आकार को टेक्स्ट में फिट करने के लिए री-साइज़ करें**

यदि आप चाहते हैं कि बॉक्स में टेक्स्ट हमेशा परिवर्तनों के बाद भी बॉक्स में फिट रहे, तो आपको **Resize shape to fit text** विकल्प का उपयोग करना होगा। इस सेटिंग को निर्दिष्ट करने के लिए, `AutofitType` प्रॉपर्टी को [TextFrameFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/textframeformat) क्लास से `Shape` पर सेट करें।

![टेक्स्ट में फिट करने के लिए आकार री-साइज़ सेटिंग](alwaysfit-setting-powerpoint.png)

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

यदि टेक्स्ट लंबा या बड़ा हो जाता है, तो टेक्स्टबॉक्स स्वचालित रूप से री-साइज़ हो गया (ऊँचाई बढ़ेगी) ताकि सभी टेक्स्ट उसमें फिट हो सके। यदि टेक्स्ट छोटा हो जाता है, तो इसके विपरीत होगा।

## **ऑटोफ़िट न करें**

यदि आप चाहते हैं कि कोई टेक्स्टबॉक्स या आकार टेक्स्ट में किए गए परिवर्तनों के बावजूद अपने आयाम बनाए रखें, तो आपको **Do not Autofit** विकल्प का उपयोग करना होगा। इस सेटिंग को निर्दिष्ट करने के लिए, `AutofitType` प्रॉपर्टी को [TextFrameFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/textframeformat) क्लास से `None` पर सेट करें।

![PowerPoint में "Do not Autofit" सेटिंग](donotautofit-setting-powerpoint.png)

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.None;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

जब टेक्स्ट बॉक्स के लिए बहुत लंबा हो जाता है, तो वह बाहर निकल जाता है।

## **ओवरफ़्लो पर टेक्स्ट घटाएँ**

यदि टेक्स्ट बॉक्स के लिए बहुत लंबा हो जाता है, तो **Shrink text on overflow** विकल्प के माध्यम से आप निर्धारित कर सकते हैं कि टेक्स्ट का आकार और अंतराल घटाया जाए ताकि वह बॉक्स में फिट हो सके। इस सेटिंग को निर्दिष्ट करने के लिए, `AutofitType` प्रॉपर्टी को [TextFrameFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/textframeformat) क्लास से `Normal` पर सेट करें।

![PowerPoint में "Shrink text on overflow" सेटिंग](shrinktextonoverflow-setting-powerpoint.png)

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Normal;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Info" color="info" %}}
जब **Shrink text on overflow** विकल्प का उपयोग किया जाता है, तो सेटिंग केवल तब लागू होती है जब टेक्स्ट बॉक्स के लिए बहुत लंबा हो जाता है।
{{% /alert %}}

## **टेक्स्ट रैप करें**

यदि आप चाहते हैं कि आकार के भीतर टेक्स्ट बॉर्डर (केवल चौड़ाई) से बाहर जाने पर रैप हो जाए, तो आपको **Wrap text in shape** पैरामीटर का उपयोग करना होगा। इस सेटिंग को निर्दिष्ट करने के लिए, आपको `WrapText` प्रॉपर्टी को [TextFrameFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/textframeformat) क्लास से `NullableBool.True` पर सेट करना होगा।

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.WrapText = NullableBool.True;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Note" color="warning" %}} 
यदि आप किसी आकार के लिए `WrapText` प्रॉपर्टी को `NullableBool.False` पर सेट करते हैं, तो जब आकार के भीतर टेक्स्ट उसकी चौड़ाई से लंबा हो जाता है, तो टेक्स्ट एक ही लाइन में आकार की सीमाओं से बाहर निकल जाता है।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या टेक्स्ट फ्रेम के आंतरिक मार्जिन AutoFit को प्रभावित करते हैं?**

हां। पैडिंग (आंतरिक मार्जिन) टेक्स्ट के उपयोग योग्य क्षेत्र को कम कर देती है, इसलिए AutoFit पहले शुरू होता है—फ़ॉन्ट को छोटा करके या आकार को पहले री-साइज़ करके। AutoFit को ट्यून करने से पहले मार्जिन की जाँच और समायोजित करें।

**AutoFit मैनुअल और सॉफ्ट लाइन ब्रेक के साथ कैसे इंटरैक्ट करता है?**

फ़ोर्स्ड ब्रेक वहीं रहते हैं, और AutoFit उन के आसपास फ़ॉन्ट आकार और अंतराल को समायोजित करता है। अनावश्यक ब्रेक हटाने से अक्सर AutoFit को टेक्स्ट को बहुत अधिक घटाने की आवश्यकता कम हो जाती है।

**थीम फ़ॉन्ट बदलने या फ़ॉन्ट प्रतिस्थापन ट्रिगर करने से AutoFit परिणामों पर असर पड़ता है क्या?**

हां। अलग ग्लिफ़ मेट्रिक्स वाले फ़ॉन्ट में प्रतिस्थापन करने से टेक्स्ट की चौड़ाई/ऊँचाई बदलती है, जो अंतिम फ़ॉन्ट आकार और लाइन रैप को बदल सकता है। किसी भी फ़ॉन्ट परिवर्तन या प्रतिस्थापन के बाद स्लाइड्स को फिर से जाँचें।