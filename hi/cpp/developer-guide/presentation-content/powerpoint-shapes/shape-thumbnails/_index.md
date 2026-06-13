---
title: C++ में प्रस्तुति आकारों के थंबनेल बनाना
linktitle: आकार थंबनेल
type: docs
weight: 70
url: /hi/cpp/shape-thumbnails/
keywords:
- आकार थंबनेल
- आकार छवि
- आकार रेंडर
- आकार रेंडरिंग
- पावरपॉइंट
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint स्लाइडों से उच्च गुणवत्ता वाले आकार थंबनेल उत्पन्न करें – आसानी से प्रस्तुति थंबनेल बनाएं और निर्यात करें।"
---
## **परिचय**

Aspose.Slides का उपयोग प्रस्तुति फ़ाइलें बनाने के लिए किया जाता है जहाँ प्रत्येक पृष्ठ एक स्लाइड होता है। इन स्लाइडों को Microsoft PowerPoint का उपयोग करके प्रस्तुतियों को खोलकर देखा जा सकता है। लेकिन कभी‑कभी डेवलपर्स को आकारों की छवियों को अलग से एक इमेज व्यूअर में देखना पड़ता है। ऐसे मामलों में Aspose.Slides आपको स्लाइड आकारों की थंबनेल इमेज बनाने में मदद करता है। इस सुविधा का उपयोग कैसे किया जाता है, यह लेख में वर्णित है।

यह लेख विभिन्न तरीकों से स्लाइड थंबनेल जनरेट करने के बारे में बताता है:

- स्लाइड के भीतर आकार की थंबनेल बनाना।
- उपयोगकर्ता द्वारा परिभाषित आयामों के साथ स्लाइड आकार के लिए आकार की थंबनेल बनाना।
- आकार की उपस्थिति की सीमाओं में आकार की थंबनेल बनाना।

## **स्लाइड से आकार थंबनेल उत्पन्न करना**
Aspose.Slides for C++ का उपयोग करके किसी भी स्लाइड से आकार थंबनेल उत्पन्न करने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2. उसके ID या इंडेक्स का उपयोग करके किसी भी स्लाइड का रेफ़रेंस प्राप्त करें।
3. डिफ़ॉल्ट स्केल पर संदर्भित स्लाइड की आकार थंबनेल इमेज प्राप्त करें।
4. थंबनेल इमेज को इच्छित किसी भी इमेज फ़ॉर्मेट में सहेजें।

नीचे दिया गया उदाहरण आकार थंबनेल बनाता है।

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **उपयोगकर्ता-परिभाषित स्केलिंग फैक्टर थंबनेल बनाना**
Aspose.Slides for C++ का उपयोग करके किसी भी स्लाइड आकार की थंबनेल उत्पन्न करने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2. उसके ID या इंडेक्स का उपयोग करके किसी भी स्लाइड का रेफ़रेंस प्राप्त करें।
3. संदर्भित स्लाइड की थंबनेल इमेज आकार की सीमाओं (shape bounds) के साथ प्राप्त करें।
4. थंबनेल इमेज को इच्छित किसी भी इमेज फ़ॉर्मेट में सहेजें।

नीचे दिया गया उदाहरण उपयोगकर्ता-परिभाषित स्केलिंग फैक्टर के साथ थंबनेल बनाता है।

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // X और Y अक्षों पर स्केलिंग.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **बॉण्ड्स‑आधारित आकार उपस्थिति थंबनेल बनाना**
आकारों के थंबनेल बनाने के लिए यह विधि डेवलपर्स को आकार की उपस्थिति की सीमाओं में थंबनेल जनरेट करने देती है। यह सभी आकार प्रभावों को ध्यान में रखती है। उत्पन्न आकार थंबनेल स्लाइड सीमाओं द्वारा सीमित रहता है। किसी भी स्लाइड आकार की उपस्थिति की सीमा में थंबनेल जनरेट करने के लिए नीचे दिया गया नमूना कोड उपयोग करें:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2. उसके ID या इंडेक्स का उपयोग करके किसी भी स्लाइड का रेफ़रेंस प्राप्त करें।
3. संदर्भित स्लाइड की थंबनेल इमेज आकार की सीमाओं को उपस्थिति (appearance) के रूप में लेकर प्राप्त करें।
4. थंबनेल इमेज को इच्छित किसी भी इमेज फ़ॉर्मेट में सहेजें।

नीचे दिया गया उदाहरण उपयोगकर्ता-परिभाषित स्केलिंग फैक्टर के साथ थंबनेल बनाता है।

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // X और Y अक्षों पर स्केलिंग।

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**आकार थंबनेल सहेजते समय कौन से इमेज फ़ॉर्मैट का उपयोग किया जा सकता है?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imageformat/), और अन्य। आकार को SVG वेक्टर के रूप में भी [exported as vector SVG](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shape/writeassvg/) करके SVG के रूप में सहेजा जा सकता है।

**थंबनेल रेंडर करने पर Shape और Appearance सीमाओं में क्या अंतर है?**

`Shape` आकार की ज्यामिति का उपयोग करता है; `Appearance` [visual effects](/slides/hi/cpp/shape-effect/) (छायाएँ, चमक आदि) को ध्यान में रखता है।

**यदि कोई आकार hidden के रूप में चिह्नित है तो क्या होगा? क्या वह अभी भी थंबनेल के रूप में रेंडर होगा?**

एक hidden आकार मॉडल का हिस्सा बना रहता है और इसे रेंडर किया जा सकता है; hidden फ़्लैग स्लाइडशो प्रदर्शन को प्रभावित करता है लेकिन आकार की इमेज उत्पन्न करने से नहीं रोकता।

**क्या समूह आकार (group shapes), चार्ट, SmartArt, और अन्य जटिल ऑब्जेक्ट्स समर्थित हैं?**

हां। कोई भी ऑब्जेक्ट जो [Shape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shape/) के रूप में दर्शाया गया है (जिसमें [GroupShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chart/) और [SmartArt](https://reference.aspose.com/slides/hi/cpp/aspose.slides.smartart/smartart/) शामिल हैं) थंबनेल या SVG के रूप में सहेजा जा सकता है।

**क्या सिस्टम में स्थापित फोंट टेक्स्ट आकारों के थंबनेल की गुणवत्ता को प्रभावित करते हैं?**

हां। आपको अनावश्यक फ़ॉन्ट बैकअप और टेक्स्ट रीफ़्लो से बचने के लिए [required fonts प्रदान](/slides/hi/cpp/custom-font/) (या [font substitutions कॉन्फ़िगर](/slides/hi/cpp/font-substitution/)) करने चाहिए।