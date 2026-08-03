---
title: C++ में प्रस्तुति आकृतियों के थंबनेल बनाएं
linktitle: आकृति थंबनेल
type: docs
weight: 70
url: /hi/cpp/shape-thumbnails/
keywords:
- आकृति थंबनेल
- आकृति छवि
- आकृति रेंडर
- आकृति रेंडरिंग
- दृश्य सीमाएँ
- आकृति सीमाएँ
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint स्लाइड्स से उच्च-गुणवत्ता वाले आकृति थंबनेल उत्पन्न करें - आसानी से प्रस्तुति थंबनेल बनाएं और निर्यात करें।"
---
## **परिचय**

Aspose.Slides का उपयोग प्रस्तुति फ़ाइलें बनाने के लिए किया जाता है जहाँ प्रत्येक पृष्ठ एक स्लाइड होता है। ये स्लाइडें Microsoft PowerPoint का उपयोग करके खोलकर देखी जा सकती हैं। लेकिन कभी‑कभी डेवलपर्स को आकृतियों की छवियों को अलग से किसी इमेज व्यूअर में देखना पड़ता है। ऐसे मामलों में Aspose.Slides स्लाइड आकृतियों की थंबनेल छवियों को उत्पन्न करने में मदद करता है। इस सुविधा के उपयोग का वर्णन इस लेख में दिया गया है।  
यह लेख विभिन्न तरीकों से स्लाइड थंबनेल उत्पन्न करने के तरीके समझाता है:

- स्लाइड के अंदर आकृति थंबनेल उत्पन्न करना।
- उपयोगकर्ता द्वारा परिभाषित आयामों के साथ स्लाइड आकृति के लिए थंबनेल उत्पन्न करना।
- आकृति के प्रकट स्वरूप की सीमाओं में थंबनेल उत्पन्न करना।

## **स्लाइड से आकृति थंबनेल उत्पन्न करें**
Aspose.Slides for C++ का उपयोग करके किसी भी स्लाइड से आकृति थंबनेल उत्पन्न करने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
1. उसके ID या इंडेक्स का उपयोग करके किसी भी स्लाइड का संदर्भ प्राप्त करें।
1. संदर्भित स्लाइड से डिफ़ॉल्ट स्केल पर आकृति थंबनेल छवि प्राप्त करें।
1. थंबनेल छवि को इच्छित किसी भी इमेज फ़ॉर्मेट में सहेजें।

नीचे दिया गया उदाहरण आकृति थंबनेल उत्पन्न करता है।

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **उपयोगकर्ता‑परिभाषित स्केलिंग फ़ैक्टर थंबनेल उत्पन्न करें**
Aspose.Slides for C++ का उपयोग करके किसी भी स्लाइड आकृति का थंबनेल उत्पन्न करने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
1. उसके ID या इंडेक्स का उपयोग करके किसी भी स्लाइड का संदर्भ प्राप्त करें।
1. आकृति सीमाओं के साथ संदर्भित स्लाइड की थंबनेल छवि प्राप्त करें।
1. थंबनेल छवि को इच्छित किसी भी इमेज फ़ॉर्मेट में सहेजें।

नीचे दिया गया उदाहरण उपयोगकर्ता‑परिभाषित स्केलिंग फ़ैक्टर के साथ थंबनेल उत्पन्न करता है।

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // X और Y अक्षों के साथ स्केलिंग।

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **सीमा‑आधारित आकृति प्रकट स्वरूप थंबनेल बनाएं**
यह विधि डेवलपर्स को आकृति के प्रकट स्वरूप की सीमाओं में थंबनेल उत्पन्न करने की अनुमति देती है। यह सभी आकार प्रभावों को ध्यान में रखती है। उत्पन्न आकृति थंबनेल स्लाइड सीमाओं द्वारा प्रतिबंधित रहता है। किसी भी स्लाइड आकृति के प्रकट स्वरूप की सीमा में थंबनेल उत्पन्न करने के लिए नीचे दिया गया नमूना कोड उपयोग करें:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
1. उसके ID या इंडेक्स का उपयोग करके किसी भी स्लाइड का संदर्भ प्राप्त करें।
1. संदर्भित स्लाइड की थंबनेल छवि को आकृति सीमाओं के रूप में प्रकट स्वरूप के साथ प्राप्त करें।
1. थंबनेल छवि को इच्छित किसी भी इमेज फ़ॉर्मेट में सहेजें।

नीचे दिया गया उदाहरण उपयोगकर्ता‑परिभाषित स्केलिंग फ़ैक्टर के साथ थंबनेल बनाता है।

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // X और Y अक्षों के साथ स्केलिंग।

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **आकृति की वास्तविक दृश्य सीमा प्राप्त करें**

[IShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/) की फ्रेम प्रॉपर्टी—`IShape::get_X()`, `IShape::get_Y()`, `IShape::get_Width()`, और `IShape::get_Height()`—प्रस्तुति मॉडल में संग्रहीत आयत को वर्णित करती हैं। वास्तव में रेंडर की गई सामग्री इस फ्रेम से आगे बढ़ सकती है या अलग अक्ष‑सरणी आयत को घेर सकती है। घुमाव, आउटलाइन, तीर सिर, टेक्स्ट लेआउट और ओवरफ़्लो, उत्पन्न SmartArt ज्योमेट्री, और अन्य रेंडरिंग प्रभाव सभी घिरे हुए क्षेत्र को बदल सकते हैं।

`Shape::GetVisualBounds` को उपयोग करके बिना छवि बनाए उस घिरे हुए क्षेत्र की गणना करें। यह मेथड स्लाइड निर्देशांक में एक [RectangleF](https://reference.aspose.com/slides/hi/cpp/system.drawing/rectanglef/) लौटाता है। लौटाई गई आयत स्लाइड तक सीमित नहीं है, इसलिए जब सामग्री स्लाइड मूल बिंदु से बाहर विस्तृत होती है तो उसके निर्देशांक नकारात्मक हो सकते हैं।

`Shape::GetVisualBounds` वर्तमान में [IShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/) इंटरफ़ेस द्वारा घोषित नहीं है। इसलिए स्लाइड के shape collection से प्राप्त आकृति को इंटरफ़ेस प्रकार के रूप में रखें और केवल मेथड को कॉल करते समय ही कास्ट करें।

निम्नलिखित उदाहरण फ्रेम और दृश्य सीमाओं को प्राप्त करके तुलना करता है:

```cpp
auto presentation = MakeObject<Presentation>(u"example.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto visualBounds = System::AsCast<Shape>(shape)->GetVisualBounds();

System::Drawing::RectangleF frameBounds(
    shape->get_X(), shape->get_Y(), shape->get_Width(), shape->get_Height());

Console::WriteLine(u"Frame bounds: {0}", frameBounds);
Console::WriteLine(u"Visual bounds: {0}", visualBounds);

presentation->Dispose();
```

एक ही [RectangleF](https://reference.aspose.com/slides/hi/cpp/system.drawing/rectanglef/) का उपयोग निकटवर्ती आकृतियों को उसके `RectangleF::get_Left()`, `RectangleF::get_Right()`, `RectangleF::get_Top()`, या `RectangleF::get_Bottom()` किनारे पर संरेखित करने, उत्पन्न लेआउट में पर्याप्त स्थान आरक्षित करने, या अनुमत क्षेत्र के बाहर की सामग्री का पता लगाने के लिए किया जा सकता है। दृश्य सीमाएँ विशेष रूप से SmartArt, टेक्स्ट बॉक्स, तीर, चित्र, घुमा हुआ आकार, और समूह आकार के लिए उपयोगी होती हैं, जहाँ संग्रहीत फ्रेम पूरी रेंडर परिणाम को नहीं दर्शा सकता।

जब आपको लेआउट या वैधता के लिए निर्देशांक चाहिए और बिटमैप नहीं चाहिए, तो `Shape::GetVisualBounds` का उपयोग करें। जब आपको आकार को रेंडर करने की आवश्यकता हो, तो `IShape::GetImage` का उपयोग करें। `ShapeThumbnailBounds` के साथ, `ShapeThumbnailBounds::Shape` आकृति सीमाओं (आउटलाइन सेटिंग्स सहित) से छवि का आकार तय करता है, जबकि `ShapeThumbnailBounds::Appearance` आकृति के प्रकट स्वरूप से आकार तय करता है और परिणाम को स्लाइड सीमाओं तक सीमित करता है। इसके विपरीत, `Shape::GetVisualBounds` केवल गणना किए गए आयत को लौटाता है और उसे स्लाइड तक क्लिप नहीं करता।

## **अक्सर पूछे जाने वाले प्रश्न**

**आकृति थंबनेल सहेजते समय कौन‑से इमेज फ़ॉर्मेट उपयोग किए जा सकते हैं?**  

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imageformat/), और अन्य। आकृतियों को SVG वेक्टर के रूप में भी [एक्सपोर्ट किया जा सकता है](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shape/writeassvg/) जब आप आकृति की सामग्री को SVG के रूप में सहेजते हैं।

**थंबनेल रेंडर करते समय Shape और Appearance सीमाओं में क्या अंतर है?**  

`Shape` आकृति की ज्यामिति का उपयोग करता है; `Appearance` [visual effects](/slides/hi/cpp/shape-effect/) (छायाएँ, चमक आदि) को ध्यान में रखता है।

**यदि कोई आकृति छुपी हुई चिह्नित है तो क्या वह थंबनेल के रूप में रेंडर होगी?**  

छुपी हुई आकृति मॉडल का हिस्सा बनी रहती है और रेंडर की जा सकती है; छुपी हुई फ़्लैग स्लाइडशो प्रदर्शन को प्रभावित करती है लेकिन आकृति की छवि बनाने में बाधा नहीं बनती।

**क्या समूह आकृतियां, चार्ट, SmartArt, और अन्य जटिल वस्तुएं समर्थित हैं?**  

हाँ। कोई भी वस्तु जो [Shape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shape/) के रूप में प्रदर्शित होती है (जिसमें [GroupShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chart/), और [SmartArt](https://reference.aspose.com/slides/hi/cpp/aspose.slides.smartart/smartart/) शामिल हैं) को थंबनेल या SVG के रूप में सहेजा जा सकता है।

**क्या सिस्टम‑इंस्टॉल फ़ॉन्ट्स टेक्स्ट आकृतियों के थंबनेल की गुणवत्ता को प्रभावित करते हैं?**  

हाँ। अनचाहे फ़ॉन्ट फॉलबैक्स और टेक्स्ट रीफ़्लो से बचने के लिए आपको आवश्यक फ़ॉन्ट्स [प्रदान करने चाहिए](/slides/hi/cpp/custom-font/) (या [फ़ॉन्ट प्रतिस्थापन कॉन्फ़िगर करें](/slides/hi/cpp/font-substitution/))।