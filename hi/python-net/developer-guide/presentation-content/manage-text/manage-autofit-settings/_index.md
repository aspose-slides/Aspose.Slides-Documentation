---
title: ऑटोफ़िट के साथ Python में अपनी प्रस्तुतियों को सुधारें
linktitle: ऑटोफ़िट सेटिंग्स
type: docs
weight: 30
url: /hi/python-net/manage-autofit-settings/
keywords:
- टेक्स्टबॉक्स
- ऑटोफ़िट
- ऑटोफ़िट न करें
- टेक्स्ट फिट करना
- टेक्स्ट सिकोड़ना
- टेक्स्ट रैप करना
- शेप री‑साइज़ करना
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: Aspose.Slides for Python via .NET में AutoFit सेटिंग्स को प्रबंधित करना सीखें ताकि आप अपने PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट डिस्प्ले को अनुकूलित कर सकें और सामग्री की पठनीयता में सुधार कर सकें।
---
## **परिचय**

डिफ़ॉल्ट रूप से, जब आप एक टेक्स्टबॉक्स जोड़ते हैं, Microsoft PowerPoint टेक्स्टबॉक्स के लिए **Resize shape to fix text** सेटिंग का उपयोग करता है—यह स्वतः टेक्स्टबॉक्स का आकार बदल देता है ताकि उसका टेक्स्ट हमेशा उसमें फिट हो सके।

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* जब टेक्स्टबॉक्स में टेक्स्ट लंबा या बड़ा हो जाता है, PowerPoint स्वतः टेक्स्टबॉक्स को बड़ा कर देता है—उसकी ऊँचाई बढ़ाता है—ताकि अधिक टेक्स्ट समा सके।  
* जब टेक्स्टबॉक्स में टेक्स्ट छोटा या कम हो जाता है, PowerPoint स्वतः टेक्स्टबॉक्स को छोटा कर देता है—उसकी ऊँचाई घटाता है—ताकि अतिरिक्त जगह हट जाए।  

PowerPoint में ये 4 महत्वपूर्ण पैरामीटर या विकल्प हैं जो टेक्स्टबॉक्स के ऑटोफ़िट व्यवहार को नियंत्रित करते हैं:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via .NET समान विकल्प प्रदान करता है—[TextFrameFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/) क्लास के अंतर्गत कुछ प्रॉपर्टीज़—जो आपको प्रस्तुतियों में टेक्स्टबॉक्स के ऑटोफ़िट व्यवहार को नियंत्रित करने की अनुमति देती हैं।

## **आकार को टेक्स्ट में फिट करने के लिए री‑साइज़ करें**

यदि आप चाहते हैं कि बॉक्स में टेक्स्ट हमेशा उस बॉक्स में फिट रहे, तो आपको **Resize shape to fix text** विकल्प का उपयोग करना होगा। इस सेटिंग को निर्दिष्ट करने के लिए, [TextFrameFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/) क्लास की `autofit_type` प्रॉपर्टी को `SHAPE` पर सेट करें।

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

यदि टेक्स्ट लंबा या बड़ा हो जाता है, तो टेक्स्टबॉक्स स्वतः री‑साइज़ हो जाएगा (ऊँचाई बढ़ेगी) ताकि सभी टेक्स्ट उसमें फिट हो सके। यदि टेक्स्ट छोटा हो जाता है, तो इसके विपरीत होगा।

## **ऑटोफ़िट न करें**

यदि आप चाहते हैं कि टेक्स्टबॉक्स या आकार अपने आयामों को बनाए रखे चाहे अंदर का टेक्स्ट कितना भी बदल जाए, तो आपको **Do not Autofit** विकल्प का उपयोग करना होगा। इस सेटिंग को निर्दिष्ट करने के लिए, [TextFrameFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/) क्लास की `autofit_type` प्रॉपर्टी को `NONE` पर सेट करें।

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

जब टेक्स्ट अपने बॉक्स से अधिक लंबा हो जाता है, तो वह बाहर निकल जाता है।

## **ओवरफ़्लो पर टेक्स्ट छोटा करें**

यदि टेक्स्ट अपने बॉक्स से अधिक लंबा हो जाए, तो **Shrink text on overflow** विकल्प के माध्यम से आप यह निर्दिष्ट कर सकते हैं कि टेक्स्ट का आकार और स्पेसिंग घटा दी जाए ताकि वह बॉक्स में फिट हो सके। इस सेटिंग को निर्दिष्ट करने के लिए, [TextFrameFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/) क्लास की `autofit_type` प्रॉपर्टी को `NORMAL` पर सेट करें।

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NORMAL

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}
जब **Shrink text on overflow** विकल्प का उपयोग किया जाता है, तो यह सेटिंग केवल तब लागू होती है जब टेक्स्ट अपने बॉक्स से अधिक लंबा हो जाता है।  
{{% /alert %}}

## **टेक्स्ट रैप करें**

यदि आप चाहते हैं कि आकार के भीतर टेक्स्ट रैप हो जाए जब टेक्स्ट आकार की सीमा (केवल चौड़ाई) से बाहर निकल जाए, तो आपको **Wrap text in shape** पैरामीटर का उपयोग करना होगा। इस सेटिंग को निर्दिष्ट करने के लिए, आपको [TextFrameFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/) क्लास की `wrap_text` प्रॉपर्टी को `NullableBool.TRUE` पर सेट करना होगा।

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame_format.wrap_text = slides.NullableBool.TRUE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Note" color="warning" %}}
यदि आप किसी आकार के लिए `wrap_text` प्रॉपर्टी को `NullableBool.FALSE` पर सेट करते हैं, तो जब आकार के भीतर टेक्स्ट उसकी चौड़ाई से अधिक हो जाता है, तो टेक्स्ट एक ही पंक्ति में आकार की सीमाओं के बाहर विस्तार कर देगा।  
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या टेक्स्ट फ्रेम के आंतरिक मार्जिन AutoFit को प्रभावित करते हैं?**  
हाँ। पैडिंग (आंतरिक मार्जिन) टेक्स्ट के उपयोग योग्य क्षेत्र को घटा देती है, इसलिए AutoFit पहले सक्रिय हो जाता है—फ़ॉन्ट छोटा करके या आकार को जल्दी री‑साइज़ करके। AutoFit को ट्यून करने से पहले मार्जिन को जांचें और आवश्यकतानुसार समायोजित करें।

**AutoFit मैनुअल और सॉफ्ट लाइन ब्रेक्स के साथ कैसे इंटरैक्ट करता है?**  
फ़ोर्स्ड ब्रेक्स वही रहते हैं, और AutoFit उनके आसपास फ़ॉन्ट आकार और स्पेसिंग को समायोजित करता है। अनावश्यक ब्रेक्स को हटाने से अक्सर AutoFit को टेक्स्ट को छोटा करने की जरूरत कम हो जाती है।

**क्या थीम फ़ॉन्ट बदलने या फ़ॉन्ट प्रतिस्थापन को ट्रिगर करने से AutoFit के परिणाम बदलते हैं?**  
हाँ। अलग ग्लिफ़ मेट्रिक्स वाले फ़ॉन्ट में बदलने से टेक्स्ट की चौड़ाई/ऊँचाई बदलती है, जिससे अंतिम फ़ॉन्ट आकार और लाइन रैप बदल सकता है। किसी भी फ़ॉन्ट बदलाव या प्रतिस्थापन के बाद स्लाइड्स को पुनः जाँचें।