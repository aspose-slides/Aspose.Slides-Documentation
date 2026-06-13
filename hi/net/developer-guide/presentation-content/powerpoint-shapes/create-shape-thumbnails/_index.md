---
title: .NET में प्रस्तुति आकृतियों के थंबनेल बनाएं
linktitle: आकृति थंबनेल
type: docs
weight: 70
url: /hi/net/create-shape-thumbnails/
keywords:
- आकृति थंबनेल
- आकृति छवि
- आकृति रेंडर
- आकृति रेंडरिंग
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "PowerPoint स्लाइड्स से Aspose.Slides for .NET के साथ उच्च-गुणवत्ता वाले आकृति थंबनेल उत्पन्न करें – आसानी से प्रस्तुति थंबनेल बनाएं और निर्यात करें।"
---
## **परिचय**

Aspose.Slides for .NET का उपयोग प्रस्तुति फ़ाइलें बनाने के लिए किया जाता है जहाँ प्रत्येक पृष्ठ एक स्लाइड होता है। इन स्लाइड्स को Microsoft PowerPoint के माध्यम से प्रस्तुति फ़ाइलें खोलकर देखा जा सकता है। लेकिन कभी‑कभी डेवलपर्स को आकृतियों की छवियों को अलग से इमेज व्यूअर में देखना पड़ता है। ऐसे मामलों में, Aspose.Slides for .NET आपको स्लाइड आकृतियों की थंबनेल छवियां बनाने में मदद करता है। इस सुविधा का उपयोग कैसे करें, इस लेख में बताया गया है।

यह लेख विभिन्न तरीकों से स्लाइड थंबनेल बनाने के बारे में बताता है:

- स्लाइड के भीतर एक आकृति थंबनेल बनाना।
- उपयोगकर्ता द्वारा निर्दिष्ट आयामों के साथ स्लाइड आकृति के लिए आकृति थंबनेल बनाना।
- आकृति की उपस्थिति के सीमा में आकृति थंबनेल बनाना।

## **स्लाइड से आकृति थंबनेल बनाना**
Aspose.Slides for .NET का उपयोग करके किसी भी स्लाइड से आकृति थंबनेल बनाने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
1. उसके ID या सूचकांक (index) का उपयोग करके किसी भी स्लाइड का संदर्भ प्राप्त करें।
1. डिफ़ॉल्ट स्केल पर संदर्भित स्लाइड का आकृति थंबनेल इमेज प्राप्त करें।
1. थंबनेल इमेज को इच्छित किसी भी इमेज फ़ॉर्मेट में सहेजें।

निम्न उदाहरण आकृति थंबनेल बनाता है।

```c#
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage())
    {
        image.Save("Shape_thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **उपयोगकर्ता-परिभाषित स्केलिंग फैक्टर थंबनेल बनाना**
Aspose.Slides for .NET का उपयोग करके किसी भी स्लाइड आकृति का थंबनेल बनाने के लिए:

1. `Presentation` क्लास का एक इंस्टेंस बनाएं।
1. उसके ID या सूचकांक (index) का उपयोग करके किसी भी स्लाइड का संदर्भ प्राप्त करें।
1. संदर्भित स्लाइड का थंबनेल इमेज आकृति की सीमाओं (shape bounds) के साथ प्राप्त करें।
1. थंबनेल इमेज को इच्छित किसी भी इमेज फ़ॉर्मेट में सहेजें।

निम्न उदाहरण उपयोगकर्ता-परिभाषित स्केलिंग फैक्टर के साथ थंबनेल बनाता है।

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // X और Y अक्षों के साथ स्केलिंग।

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **सीमा-आधारित आकृति उपस्थिति थंबनेल बनाएँ**
आकृतियों के थंबनेल बनाने की यह विधि डेवलपर्स को आकृति की उपस्थिति (appearance) की सीमा में थंबनेल उत्पन्न करने की अनुमति देती है। यह सभी आकृति प्रभावों (shape effects) को ध्यान में रखती है। उत्पन्न आकृति थंबनेल स्लाइड की सीमाओं द्वारा प्रतिबंधित रहता है। किसी भी स्लाइड आकृति को उसकी उपस्थिति की सीमा में थंबनेल बनाने के लिए, नीचे दिया गया नमूना कोड उपयोग करें:

1. `Presentation` क्लास का एक इंस्टेंस बनाएं।
1. उसके ID या सूचकांक (index) का उपयोग करके किसी भी स्लाइड का संदर्भ प्राप्त करें।
1. संदर्भित स्लाइड का थंबनेल इमेज आकृति की सीमाओं को उपस्थिति (appearance) के रूप में लेकर प्राप्त करें।
1. थंबनेल इमेज को इच्छित किसी भी इमेज फ़ॉर्मेट में सहेजें।

निम्न उदाहरण उपयोगकर्ता-परिभाषित स्केलिंग फैक्टर के साथ थंबनेल बनाता है।

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // X और Y अक्षों के साथ स्केलिंग।

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```

## **FAQ**

**आकृति थंबनेल सहेजने के लिए कौन से इमेज फ़ॉर्मेट उपयोग किए जा सकते हैं?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/hi/net/aspose.slides/imageformat/), और अन्य। आकृतियों को उनके कंटेंट को SVG के रूप में सहेजकर [vector SVG के रूप में निर्यात](https://reference.aspose.com/slides/hi/net/aspose.slides/shape/writeassvg/) भी किया जा सकता है।

**थंबनेल रेंडर करते समय Shape और Appearance सीमाओं में क्या अंतर है?**

`Shape` आकृति की ज्यामिति (geometry) का उपयोग करता है; `Appearance` [विज़ुअल इफ़ेक्ट्स](/slides/hi/net/shape-effect/) (छायाएँ, चमक आदि) को ध्यान में रखता है।

**यदि कोई आकृति छिपी हुई (hidden) चिह्नित की गई है तो क्या होता है? क्या वह फिर भी थंबनेल के रूप में रेंडर होगी?**

एक hidden आकृति मॉडल का हिस्सा बनी रहती है और रेंडर की जा सकती है; hidden फ़्लैग स्लाइडशो प्रदर्शन को प्रभावित करता है लेकिन आकृति की छवि बनाने से रोकता नहीं है।

**क्या समूह आकृतियाँ (group shapes), चार्ट, SmartArt और अन्य जटिल ऑब्जेक्ट्स समर्थित हैं?**

हाँ। कोई भी ऑब्जेक्ट जो [Shape](https://reference.aspose.com/slides/hi/net/aspose.slides/shape/) के रूप में दर्शाया गया है (जिसमें [GroupShape](https://reference.aspose.com/slides/hi/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chart/), और [SmartArt](https://reference.aspose.com/slides/hi/net/aspose.slides.smartart/smartart/) शामिल हैं) को थंबनेल या SVG के रूप में सहेजा जा सकता है।

**क्या सिस्टम में स्थापित फ़ॉन्ट्स टेक्स्ट आकृतियों के थंबनेल की गुणवत्ता को प्रभावित करते हैं?**

हाँ। अनपेक्षित फ़ॉलबैक और टेक्स्ट रीफ़्लो से बचने के लिए आपको [आवश्यक फ़ॉन्ट्स प्रदान करने](/slides/hi/net/custom-font/) चाहिए (या [फ़ॉन्ट प्रतिस्थापन कॉन्फ़िगर करने](/slides/hi/net/font-substitution/) चाहिए)।