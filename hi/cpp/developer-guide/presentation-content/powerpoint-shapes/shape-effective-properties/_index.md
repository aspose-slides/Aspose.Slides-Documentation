---
title: "C++ में प्रेज़ेंटेशन से शेप प्रभावी गुण प्राप्त करें"
linktitle: "प्रभावी गुण"
type: docs
weight: 50
url: /hi/cpp/shape-effective-properties/
keywords:
- शेप गुण
- कैमरा गुण
- लाइट रिग
- बिवेल शेप
- टेक्स्ट फ्रेम
- टेक्स्ट स्टाइल
- फ़ॉन्ट ऊँचाई
- फ़िल फ़ॉर्मेट
- PowerPoint
- प्रेज़ेंटेशन
- C++
- Aspose.Slides
description: "जानेँ कि C++ के लिए Aspose.Slides कैसे सटीक PowerPoint रेंडरिंग के लिए प्रभावी शेप गुणों की गणना और लागू करता है।"
---
## **समीक्षा**

यह विषय **स्थानीय** और **प्रभावी** गुणों के बीच अंतर समझाता है। स्थानीय मान वे मान होते हैं जो किसी विशिष्ट फॉर्मेटिंग स्तर पर सीधे सेट किए जाते हैं, जैसे कि:

1. स्लाइड पर भाग गुण।
1. लेआउट या मास्टर स्लाइड पर प्रोटोटाइप शेप टेक्स्ट स्टाइल, जब भाग के टेक्स्ट फ्रेम शेप में एक हो।
1. प्रेजेंटेशन में वैश्विक टेक्स्ट सेटिंग्स।

स्थानीय मान किसी भी स्तर पर परिभाषित या छोड़े जा सकते हैं। जब Aspose.Slides को अंतिम "जैसा रेंडर किया गया" फॉर्मेटिंग चाहिए होती है, तो यह इनहेरिटेंस चेन को हल करता है और **प्रभावी** मान लौटाता है। आप इन्हें स्थानीय फॉर्मेट ऑब्जेक्ट पर `GetEffective` मेथड को कॉल करके प्राप्त कर सकते हैं।

निम्न उदाहरण दिखाता है कि प्रभावी मान कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड पर पहला शेप एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) है जिसमें एक टेक्स्ट फ्रेम और कम से कम एक भाग हो।

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto textFrame = shape->get_TextFrame();
auto effectiveTextFrameFormat = textFrame->get_TextFrameFormat()->GetEffective();

auto portion = textFrame->get_Paragraph(0)->get_Portion(0);
auto effectivePortionFormat = portion->get_PortionFormat()->GetEffective();

presentation->Dispose();
```

{{% alert color="primary" %}}
प्रभावी फॉर्मेटिंग डेटा वह वर्तमान गणना किया गया फॉर्मेटिंग दर्शाता है जो इनहेरिटेंस लागू होने के बाद प्राप्त होता है। वर्तमान कार्यान्वयन में, कुछ प्रभावी डेटा ऑब्जेक्ट, जैसे कि [IPortionFormatEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportionformateffectivedata/), आंतरिक रूप से कैश किए जा सकते हैं। पैरेंट या विरासत में मिली फॉर्मेटिंग बदलने के बाद `GetEffective` को फिर से कॉल करने से कैश किया गया डेटा रीफ़्रेश हो सकता है, और पहले प्राप्त ऑब्जेक्ट अब पहले की स्थिति को दर्शा नहीं सकता। यदि आपको बाद में पुन: उपयोग के लिए प्रभावी मानों को संरक्षित रखना है, तो आवश्यक गुणों जैसे फ़ॉन्ट ऊँचाई, फ़िल रंग, फ़ॉन्ट शैली या संरेखण को अपने स्वयं के डेटा ऑब्जेक्ट में कॉपी करें।
{{% /alert %}}

## **कैमरा के प्रभावी गुण प्राप्त करें**

Aspose.Slides आपको कैमरा के प्रभावी गुण प्राप्त करने की अनुमति देता है। [ICameraEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icameraeffectivedata/) इंटरफ़ेस एक अपरिवर्तनीय ऑब्जेक्ट का प्रतिनिधित्व करता है जिसमें प्रभावी कैमरा गुण होते हैं। एक [ICameraEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icameraeffectivedata/) उदाहरण [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformateffectivedata/) के माध्यम से उजागर किया जाता है, जो [IThreeDFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/) के लिए प्रभावी मान प्रदान करता है।

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto camera = threeDEffectiveData->get_Camera();

System::Console::WriteLine(u"= Effective camera properties =");
auto cameraType = System::ObjectExt::ToString(camera->get_CameraType());
System::Console::WriteLine(System::String(u"Type: ") + cameraType);

auto fieldOfViewAngle = camera->get_FieldOfViewAngle();
System::Console::WriteLine(System::String(u"Field of view: ") + fieldOfViewAngle);

auto cameraZoom = camera->get_Zoom();
System::Console::WriteLine(System::String(u"Zoom: ") + cameraZoom);

presentation->Dispose();
```

## **लाइट रिग के प्रभावी गुण प्राप्त करें**

Aspose.Slides आपको लाइट रिग के प्रभावी गुण प्राप्त करने की अनुमति देता है। [ILightRigEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilightrigeffectivedata/) इंटरफ़ेस एक अपरिवर्तनीय ऑब्जेक्ट का प्रतिनिधित्व करता है जिसमें प्रभावी लाइट रिग गुण होते हैं। एक [ILightRigEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilightrigeffectivedata/) उदाहरण [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformateffectivedata/) के माध्यम से उजागर किया जाता है, जो [IThreeDFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/) के लिए प्रभावी मान प्रदान करता है।

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto lightRig = threeDEffectiveData->get_LightRig();

System::Console::WriteLine(u"= Effective light rig properties =");
auto lightType = System::ObjectExt::ToString(lightRig->get_LightType());
System::Console::WriteLine(System::String(u"Type: ") + lightType);

auto lightDirection = System::ObjectExt::ToString(lightRig->get_Direction());
System::Console::WriteLine(System::String(u"Direction: ") + lightDirection);

presentation->Dispose();
```

## **शेप बिवेल के प्रभावी गुण प्राप्त करें**

Aspose.Slides आपको शेप बिवेल के प्रभावी गुण प्राप्त करने की अनुमति देता है। [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapebeveleffectivedata/) इंटरफ़ेस एक अपरिवर्तनीय ऑब्जेक्ट का प्रतिनिधित्व करता है जिसमें शेप के लिए प्रभावी फेस‑रिलिफ़ गुण होते हैं। एक [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapebeveleffectivedata/) उदाहरण [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformateffectivedata/) के माध्यम से उजागर किया जाता है, जो [IThreeDFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/) के लिए प्रभावी मान प्रदान करता है।

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto bevelTop = threeDEffectiveData->get_BevelTop();

System::Console::WriteLine(u"= Effective shape's top face relief properties =");
auto bevelType = System::ObjectExt::ToString(bevelTop->get_BevelType());
System::Console::WriteLine(System::String(u"Type: ") + bevelType);

auto bevelWidth = bevelTop->get_Width();
System::Console::WriteLine(System::String(u"Width: ") + bevelWidth);

auto bevelHeight = bevelTop->get_Height();
System::Console::WriteLine(System::String(u"Height: ") + bevelHeight);

presentation->Dispose();
```

## **टेक्स्ट फ्रेम के प्रभावी गुण प्राप्त करें**

Aspose.Slides का उपयोग करके आप टेक्स्ट फ्रेम के प्रभावी गुण प्राप्त कर सकते हैं। [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframeformateffectivedata/) इंटरफ़ेस में प्रभावी टेक्स्ट फ्रेम फॉर्मेटिंग गुण होते हैं।

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto effectiveTextFrameFormat = shape->get_TextFrame()->get_TextFrameFormat()->GetEffective();

auto anchoringType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AnchoringType());
System::Console::WriteLine(System::String(u"Anchoring type: ") + anchoringType);

auto autofitType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AutofitType());
System::Console::WriteLine(System::String(u"Autofit type: ") + autofitType);

auto textVerticalType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_TextVerticalType());
System::Console::WriteLine(System::String(u"Text vertical type: ") + textVerticalType);

System::Console::WriteLine(u"Margins");
auto marginLeft = effectiveTextFrameFormat->get_MarginLeft();
System::Console::WriteLine(System::String(u"   Left: ") + marginLeft);

auto marginTop = effectiveTextFrameFormat->get_MarginTop();
System::Console::WriteLine(System::String(u"   Top: ") + marginTop);

auto marginRight = effectiveTextFrameFormat->get_MarginRight();
System::Console::WriteLine(System::String(u"   Right: ") + marginRight);

auto marginBottom = effectiveTextFrameFormat->get_MarginBottom();
System::Console::WriteLine(System::String(u"   Bottom: ") + marginBottom);

presentation->Dispose();
```

## **टेक्स्ट स्टाइल के प्रभावी गुण प्राप्त करें**

Aspose.Slides का उपयोग करके आप टेक्स्ट स्टाइल के प्रभावी गुण प्राप्त कर सकते हैं। [ITextStyleEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextstyleeffectivedata/) इंटरफ़ेस में प्रभावी टेक्स्ट स्टाइल गुण होते हैं।

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto effectiveTextStyle = shape->get_TextFrame()->get_TextFrameFormat()->get_TextStyle()->GetEffective();
int levelCount = 9;

for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    auto effectiveStyleLevel = effectiveTextStyle->GetLevel(levelIndex);

    auto depth = effectiveStyleLevel->get_Depth();
    auto indent = effectiveStyleLevel->get_Indent();
    auto alignment = System::ObjectExt::ToString(effectiveStyleLevel->get_Alignment());
    auto fontAlignment = System::ObjectExt::ToString(effectiveStyleLevel->get_FontAlignment());

    System::Console::WriteLine(System::String(u"= Effective paragraph formatting for style level #") + levelIndex + u" =");
    System::Console::WriteLine(System::String(u"Depth: ") + depth);
    System::Console::WriteLine(System::String(u"Indent: ") + indent);
    System::Console::WriteLine(System::String(u"Alignment: ") + alignment);
    System::Console::WriteLine(System::String(u"Font alignment: ") + fontAlignment);
}

presentation->Dispose();
```

## **प्रभावी फ़ॉन्ट ऊँचाई मान प्राप्त करें**

Aspose.Slides का उपयोग करके आप प्रभावी फ़ॉन्ट ऊँचाई प्राप्त कर सकते हैं। निम्न कोड दर्शाता है कि विभिन्न प्रेजेंटेशन स्ट्रक्चर स्तरों पर स्थानीय फ़ॉन्ट ऊँचाई मान सेट करने के बाद भाग की प्रभावी फ़ॉन्ट ऊँचाई कैसे बदलती है।

```cpp
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 400.0f, 75.0f, false);
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portions = paragraph->get_Portions();
portions->Clear();

auto firstPortion = System::MakeObject<Portion>(u"Sample text with first portion");
auto secondPortion = System::MakeObject<Portion>(u" and second portion.");

portions->Add(firstPortion);
portions->Add(secondPortion);

System::Console::WriteLine(u"Effective font height just after creation:");
auto firstPortionFormat = firstPortion->get_PortionFormat();
auto secondPortionFormat = secondPortion->get_PortionFormat();

auto printEffectiveFontHeights = [&]()
{
    auto firstPortionFontHeight = firstPortionFormat->GetEffective()->get_FontHeight();
    auto secondPortionFontHeight = secondPortionFormat->GetEffective()->get_FontHeight();

    System::Console::WriteLine(System::String(u"Portion #0: ") + firstPortionFontHeight);
    System::Console::WriteLine(System::String(u"Portion #1: ") + secondPortionFontHeight);
};

printEffectiveFontHeights();

presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(24.0f);

System::Console::WriteLine(u"Effective font height after setting the presentation default font height:");
printEffectiveFontHeights();

paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(40.0f);

System::Console::WriteLine(u"Effective font height after setting paragraph default font height:");
printEffectiveFontHeights();

firstPortionFormat->set_FontHeight(55.0f);

System::Console::WriteLine(u"Effective font height after setting portion #0 font height:");
printEffectiveFontHeights();

secondPortionFormat->set_FontHeight(18.0f);

System::Console::WriteLine(u"Effective font height after setting portion #1 font height:");
printEffectiveFontHeights();

presentation->Save(u"SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **टेबल के लिए प्रभावी फ़िल फ़ॉर्मेट प्राप्त करें**

Aspose.Slides का उपयोग करके आप विभिन्न टेबल भागों के लिए प्रभावी फ़िल फॉर्मेटिंग प्राप्त कर सकते हैं। [IFillFormatEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifillformateffectivedata/) इंटरफ़ेस में प्रभावी फ़िल फॉर्मेटिंग गुण होते हैं। सेल फ़ॉर्मेटिंग की प्राथमिकता पंक्ति फ़ॉर्मेटिंग से अधिक होती है, पंक्ति फ़ॉर्मेटिंग की प्राथमिकता कॉलम फ़ॉर्मेटिंग से अधिक होती है, और कॉलम फ़ॉर्मेटिंग की प्राथमिकता पूरी टेबल फ़ॉर्मेटिंग से अधिक होती है।

परिणामस्वरूप, [ICellFormatEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icellformateffectivedata/) गुणों का उपयोग टेबल सेल को ड्रॉ करने के लिए किया जाता है। निम्न कोड नमूना विभिन्न टेबल भागों के लिए प्रभावी फ़िल फॉर्मेटिंग प्राप्त करने को दर्शाता है। यह मानता है कि पहली स्लाइड पर पहला शेप एक [ITable](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itable/) है।

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto tableFillFormatEffective = table->get_TableFormat()->GetEffective()->get_FillFormat();
auto rowFillFormatEffective = table->get_Row(0)->get_RowFormat()->GetEffective()->get_FillFormat();
auto columnFillFormatEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective()->get_FillFormat();
auto cellFillFormatEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective()->get_FillFormat();

presentation->Dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या `GetEffective` एक स्नैपशॉट लौटाता है?**

हमेशा नहीं। प्रभावी डेटा इनहेरिटेंस लागू होने के बाद गणना किया गया फॉर्मेटिंग दर्शाता है, लेकिन कुछ प्रभावी डेटा ऑब्जेक्ट आंतरिक रूप से कैश किए जा सकते हैं। अगला `GetEffective` कॉल फॉर्मेटिंग को पुनः गणना कर सकता है और कैश किया गया डेटा रीफ़्रेश कर सकता है, इसलिए पहले प्राप्त ऑब्जेक्ट को टिकाऊ स्नैपशॉट के रूप में नहीं माना जाना चाहिए।

**मुझे प्रभावी गुण फिर से कब पढ़ने चाहिए?**

स्थानीय फॉर्मेटिंग, पैरेंट स्टाइल, लेआउट फॉर्मेटिंग, मास्टर फॉर्मेटिंग या प्रेजेंटेशन‑स्तर के डिफ़ॉल्ट बदलने के बाद `GetEffective` को फिर से कॉल करें। अगला कॉल फॉर्मेटिंग पदानुक्रम का पुनर्मूल्यांकन करता है और वर्तमान प्रभावी परिणाम लौटाता है।

**क्या लेआउट/मास्टर स्लाइड बदलने या हटाने से पहले प्राप्त प्रभावी गुण प्रभावित होते हैं?**

हां, लेकिन परिवर्तन अगली `GetEffective` कॉल पर प्रतिबिंबित होता है। यदि पैरेंट फॉर्मेटिंग स्रोत बदलता या हटाया जाता है, तो पहले प्राप्त प्रभावी डेटा पुराना हो सकता है। जब `GetEffective` फिर से कॉल किया जाता है, तो Aspose.Slides फॉर्मेटिंग ट्री को पुनः मूल्यांकित करता है और resulting फ़ॉन्ट, रंग, आकार या अन्य मान बदल सकते हैं।

**क्या मैं प्रभावी डेटा ऑब्जेक्ट्स के माध्यम से मानों को संशोधित कर सकता हूं?**

नहीं। प्रभावी डेटा ऑब्जेक्ट गणना किए गए मानों को उजागर करते हैं। स्थानीय फॉर्मेटिंग ऑब्जेक्ट्स में परिवर्तन करें, फिर प्रभावी मान फिर से प्राप्त करें।

**यदि गुण शैप स्तर पर, न लेआउट/मास्टर पर, न ही वैश्विक सेटिंग्स में सेट नहीं है तो क्या होता है?**

प्रभावी मान डिफ़ॉल्ट तंत्र द्वारा निर्धारित किया जाता है, जिसमें PowerPoint और Aspose.Slides के डिफ़ॉल्ट शामिल हैं। वह हल किया गया मान वर्तमान प्रभावी डेटा का हिस्सा बन जाता है।

**एक प्रभावी फ़ॉन्ट मान से क्या मैं बता सकता हूं कि कौनसे स्तर ने आकार या फ़ॉन्ट प्रदान किया?**

सीधे नहीं। प्रभावी डेटा अंतिम मान लौटाता है। स्रोत पता लगाने के लिए भाग, पैराग्राफ, टेक्स्ट फ्रेम पर स्थानीय मान और लेआउट, मास्टर और प्रेजेंटेशन स्तर पर टेक्स्ट स्टाइल देखें ताकि पहली स्पष्ट परिभाषा कहाँ है पता चल सके।

**क्यों प्रभावी मान कभी‑कभी स्थानीय मानों के समान दिखते हैं?**

क्योंकि स्थानीय मान अंतिम बन गया था (उच्च‑स्तर की इनहेरिटेंस की आवश्यकता नहीं थी)। ऐसे मामलों में प्रभावी मान स्थानीय मान से मेल खाता है।

**कब मुझे प्रभावी गुणों का उपयोग करना चाहिए, और कब केवल स्थानीय गुणों के साथ काम करना चाहिए?**

जब आपको सभी इनहेरिटेंस लागू होने के बाद "जैसा रेंडर किया गया" परिणाम चाहिए, जैसे रंग, इंडेंट या आकार संरेखित करने के लिए, तब प्रभावी डेटा उपयोग करें। यदि आपको बाद में फॉर्मेटिंग बदलने के बावजूद इन मानों को संरक्षित रखना है, तो आवश्यक गुणों को अपने स्वयं के ऑब्जेक्ट में कॉपी करें। यदि आपको किसी विशिष्ट स्तर पर फॉर्मेटिंग बदलनी है, तो स्थानीय गुणों को संशोधित करें और आवश्यक होने पर प्रभावी डेटा फिर से पढ़ें ताकि परिणाम की पुष्टि हो सके।