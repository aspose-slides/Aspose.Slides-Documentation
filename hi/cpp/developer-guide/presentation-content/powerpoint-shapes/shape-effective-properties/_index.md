---
title: C++ में प्रस्तुतियों से आकार के प्रभावी गुण प्राप्त करें
linktitle: प्रभावी गुण
type: docs
weight: 50
url: /hi/cpp/shape-effective-properties/
keywords:
- आकार गुण
- कैमरा गुण
- लाइट रिग
- बेवेल आकार
- टेक्स्ट फ्रेम
- टेक्स्ट स्टाइल
- फ़ॉन्ट ऊँचाई
- फ़िल फ़ॉर्मेट
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ कैसे प्रभावी आकार गुणों की गणना और लागू करता है ताकि सटीक PowerPoint रेंडरिंग हो सके, यह जानें।"
---
## **अवलोकन**

यह विषय **स्थानीय** और **प्रभावी** गुणों के बीच अंतर को समझाता है। स्थानीय मान वह मान होते हैं जो किसी विशिष्ट स्वरूपण स्तर पर सीधे सेट किए जाते हैं, जैसे:

1. स्लाइड पर पोर्शन गुण।
1. लेआउट या मास्टर स्लाइड पर प्रोटोटाइप आकार के पाठ शैलियों, जब पोर्शन के टेक्स्ट फ्रेम आकार में एक हो।
1. प्रस्तुति में ग्लोबल टेक्स्ट सेटिंग्स।

स्थानीय मान किसी भी स्तर पर परिभाषित या छोड़े जा सकते हैं। जब Aspose.Slides को अंतिम “जैसे रेंडर किया गया” स्वरूपण चाहिए, तो वह विरासत श्रृंखला को हल करता है और **प्रभावी** मान लौटाता है। आप इन्हें स्थानीय स्वरूप ऑब्जेक्ट पर `GetEffective` मेथड को कॉल करके प्राप्त कर सकते हैं।

निम्न उदाहरण दिखाता है कि प्रभावी मान कैसे प्राप्त किए जाएँ। यह मानता है कि पहली स्लाइड पर पहला आकार एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) है जिसमें टेक्स्ट फ्रेम और कम से कम एक पोर्शन है।

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto textFrame = shape->get_TextFrame();
auto effectiveTextFrameFormat = textFrame->get_TextFrameFormat()->GetEffective();

auto portion = textFrame->get_Paragraph(0)->get_Portion(0);
auto effectivePortionFormat = portion->get_PortionFormat()->GetEffective();

presentation->Dispose();
```

{{% alert color="info" %}}
प्रभावी स्वरूपण डेटा वह वर्तमान गणना किया गया स्वरूपण दर्शाता है जो विरासत लागू होने के बाद प्राप्त होता है। वर्तमान कार्यान्वयन में, कुछ प्रभावी डेटा ऑब्जेक्ट जैसे [IPortionFormatEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportionformateffectivedata/) को आंतरिक रूप से कैश किया जा सकता है। पैरेंट या विरासतित स्वरूपण बदलने के बाद `GetEffective` को फिर से कॉल करने से कैशेड डेटा रीफ़्रेश हो सकता है, और पहले प्राप्त किया गया ऑब्जेक्ट अब पूर्व अवस्था का प्रतिनिधित्व नहीं कर सकता। यदि आपको बाद में पुनः उपयोग के लिए प्रभावी मान सुरक्षित रखने की आवश्यकता है, तो आवश्यक गुणों—जैसे फ़ॉन्ट ऊँचाई, भराव रंग, फ़ॉन्ट शैली या संरेखण—को अपने स्वयं के डेटा ऑब्जेक्ट में कॉपी करें।
{{% /alert %}}

## **कैमरा के प्रभावी गुण प्राप्त करें**

Aspose.Slides आपको कैमरा के प्रभावी गुण प्राप्त करने की अनुमति देता है। [ICameraEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icameraeffectivedata/) इंटरफ़ेस एक अपरिवर्तनीय ऑब्जेक्ट का प्रतिनिधित्व करता है जिसमें प्रभावी कैमरा गुण होते हैं। एक [ICameraEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icameraeffectivedata/) इंस्टेंस [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformateffectivedata/) के माध्यम से प्रदान किया जाता है, जो [IThreeDFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/) के लिए प्रभावी मान देता है।

निम्न कोड नमूना दिखाता है कि कैमरा के प्रभावी गुण कैसे प्राप्त किए जाएँ। यह मानता है कि पहली स्लाइड पर पहला आकार 3D स्वरूपण रखता है।

```cpp
#include <DOM/ICameraEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

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

Aspose.Slides आपको लाइट रिग के प्रभावी गुण प्राप्त करने की अनुमति देता है। [ILightRigEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilightrigeffectivedata/) इंटरफ़ेस एक अपरिवर्तनीय ऑब्जेक्ट का प्रतिनिधित्व करता है जिसमें प्रभावी लाइट रिग गुण होते हैं। एक [ILightRigEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilightrigeffectivedata/) इंस्टेंस [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformateffectivedata/) के माध्यम से प्रदान किया जाता है, जो [IThreeDFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/) के लिए प्रभावी मान देता है।

निम्न कोड नमूना दिखाता है कि लाइट रिग के प्रभावी गुण कैसे प्राप्त किए जाएँ। यह मानता है कि पहली स्लाइड पर पहला आकार 3D स्वरूपण रखता है।

```cpp
#include <DOM/ILightRigEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

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

## **आकारीय बेवेल के प्रभावी गुण प्राप्त करें**

Aspose.Slides आपको शेप बेवेल के प्रभावी गुण प्राप्त करने की अनुमति देता है। [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapebeveleffectivedata/) इंटरफ़ेस एक अपरिवर्तनीय ऑब्जेक्ट का प्रतिनिधित्व करता है जिसमें आकार के लिए प्रभावी फेस‑रिलीफ़ गुण होते हैं। एक [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapebeveleffectivedata/) इंस्टेंस [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformateffectivedata/) के माध्यम से प्रदान किया जाता है, जो [IThreeDFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/) के लिए प्रभावी मान देता है।

निम्न कोड नमूना दिखाता है कि आकार के शीर्ष बेवेल के प्रभावी गुण कैसे प्राप्त किए जाएँ। यह मानता है कि पहली स्लाइड पर पहला आकार 3D स्वरूपण रखता है।

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeBevelEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

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

Aspose.Slides का उपयोग करके आप टेक्स्ट फ्रेम के प्रभावी गुण प्राप्त कर सकते हैं। [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframeformateffectivedata/) इंटरफ़ेस प्रभावी टेक्स्ट फ्रेम स्वरूपण गुणों को रखता है।

निम्न कोड नमूना दिखाता है कि प्रभावी टेक्स्ट फ्रेम स्वरूपण गुण कैसे प्राप्त किए जाएँ। यह मानता है कि पहली स्लाइड पर पहला आकार एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) है जिसमें टेक्स्ट फ्रेम है।

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextFrameFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

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

Aspose.Slides का उपयोग करके आप टेक्स्ट स्टाइल के प्रभावी गुण प्राप्त कर सकते हैं। [ITextStyleEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextstyleeffectivedata/) इंटरफ़ेस प्रभावी टेक्स्ट स्टाइल गुणों को रखता है।

निम्न कोड नमूना दिखाता है कि प्रभावी टेक्स्ट स्टाइल गुण कैसे प्राप्त किए जाएँ। यह मानता है कि पहली स्लाइड पर पहला आकार एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) है जिसमें टेक्स्ट फ्रेम है।

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/ITextStyleEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

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

Aspose.Slides का उपयोग करके आप प्रभावी फ़ॉन्ट ऊँचाई प्राप्त कर सकते हैं। निम्न कोड दर्शाता है कि विभिन्न प्रस्तुति संरचना स्तरों पर स्थानीय फ़ॉन्ट ऊँचाई मान सेट करने के बाद पोर्शन की प्रभावी फ़ॉन्ट ऊँचाई कैसे बदलती है।

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextStyle.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

Aspose.Slides का उपयोग करके आप विभिन्न टेबल भागों के लिए प्रभावी फ़िल स्वरूपण प्राप्त कर सकते हैं। [IFillFormatEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifillformateffectivedata/) इंटरफ़ेस प्रभावी फ़िल स्वरूपण गुणों को रखता है। सेल स्वरूपण की प्राथमिकता पंक्ति स्वरूपण से अधिक होती है, पंक्ति स्वरूपण की प्राथमिकता कॉलम स्वरूपण से अधिक होती है, और कॉलम स्वरूपण की प्राथमिकता पूर्ण‑टेबल स्वरूपण से अधिक होती है।

परिणामस्वरूप, [ICellFormatEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icellformateffectivedata/) गुण टेबल सेल को ड्रॉ करने के लिए उपयोग होते हैं। निम्न कोड नमूना दिखाता है कि विभिन्न टेबल भागों के लिए प्रभावी फ़िल स्वरूपण कैसे प्राप्त किया जाए। यह मानता है कि पहली स्लाइड पर पहला आकार एक [ITable](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itable/) है।

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/ICellFormatEffectiveData.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnFormat.h>
#include <DOM/Table/IColumnFormatEffectiveData.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowFormat.h>
#include <DOM/Table/IRowFormatEffectiveData.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ITableFormat.h>
#include <DOM/Table/ITableFormatEffectiveData.h>
using namespace Aspose::Slides;

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

### क्या `GetEffective` एक स्नैपशॉट लौटाता है?

हमेशा नहीं। प्रभावी डेटा विरासत लागू होने के बाद गणना किया गया स्वरूपण दर्शाता है, लेकिन कुछ प्रभावी डेटा ऑब्जेक्ट आंतरिक रूप से कैश किए जा सकते हैं। बाद में `GetEffective` कॉल स्वरूपण को पुन: गणना कर सकता है और कैशेड डेटा को रीफ़्रेश कर सकता है, इसलिए पहले प्राप्त किया गया ऑब्जेक्ट स्थायी स्नैपशॉट नहीं माना जाना चाहिए।

### कब मुझे प्रभावी गुणों को फिर से पढ़ना चाहिए?

स्थानीय स्वरूपण, पैरेंट शैलियों, लेआउट स्वरूपण, मास्टर स्वरूपण या प्रस्तुति‑स्तर डिफ़ॉल्ट बदलने के बाद `GetEffective` को फिर से कॉल करें। अगला कॉल स्वरूपण पदानुक्रम का पुन: मूल्यांकन करता है और वर्तमान प्रभावी परिणाम लौटाता है।

### क्या लेआउट/मास्टर स्लाइड बदलने या हटाने से पहले प्राप्त प्रभावी गुण प्रभावित होते हैं?

हां, लेकिन परिवर्तन अगले `GetEffective` कॉल पर परिलक्षित होगा। यदि पैरेंट स्वरूपण स्रोत बदलता या हटाया जाता है, तो पहले प्राप्त प्रभावी डेटा पुराना हो सकता है। एक बार `GetEffective` फिर से बुलाने पर, Aspose.Slides स्वरूपण वृक्ष का पुन: मूल्यांकन करता है और resulting फ़ॉन्ट, रंग, आकार या अन्य मान बदल सकते हैं।

### क्या मैं प्रभावी डेटा ऑब्जेक्ट्स के माध्यम से मान बदल सकता हूँ?

नहीं। प्रभावी डेटा ऑब्जेक्ट्स गणना किए गए मान ही दर्शाते हैं। स्थानीय स्वरूपण ऑब्जेक्ट्स में परिवर्तन करें, और फिर प्रभावी मानों को पुनः प्राप्त करें।

### यदि कोई गुण आकार स्तर पर, न लेआउट/मास्टर पर, न ही ग्लोबल सेटिंग्स में निर्धारित नहीं है, तो क्या होता है?

प्रभावी मान डिफ़ॉल्ट तंत्र द्वारा निर्धारित किया जाता है, जिसमें PowerPoint और Aspose.Slides के डिफ़ॉल्ट शामिल हैं। वह निर्धारित मान वर्तमान प्रभावी डेटा का हिस्सा बन जाता है।

### प्रभावी फ़ॉन्ट मान से क्या मैं बता सकता हूँ कि किस स्तर ने आकार या फ़ॉन्ट प्रदान किया?

सीधे नहीं। प्रभावी डेटा अंतिम मान लौटाता है। स्रोत पता करने के लिए पोर्शन, पैराग्राफ, टेक्स्ट फ्रेम और लेआउट, मास्टर एवं प्रस्तुति स्तर पर स्थानीय मानों की जाँच करें ताकि पहली स्पष्ट परिभाषा का स्तर देख सकें।

### कभी‑कभी प्रभावी मान स्थानीय मानों जैसे क्यों दिखते हैं?

क्योंकि स्थानीय मान अंततः अंतिम हो गया (ऊँचा‑स्तर विरासत की आवश्यकता नहीं रही)। ऐसे मामलों में प्रभावी मान स्थानीय मान से मेल खाता है।

### मुझे कब प्रभावी गुणों का उपयोग करना चाहिए, और कब केवल स्थानीय गुणों के साथ काम करना चाहिए?

जब आपको सभी विरासत लागू होने के बाद “जैसे रेंडर किया गया” परिणाम चाहिए, जैसे रंग, इंडेंट या आकार संरेखित करने के लिए, तो प्रभावी डेटा उपयोग करें। यदि आप उन मानों को बाद में स्वरूपण परिवर्तन के बावजूद संरक्षित रखना चाहते हैं, तो आवश्यक गुणों को अपने स्वयं के ऑब्जेक्ट में कॉपी करें। यदि आप किसी विशिष्ट स्तर पर स्वरूपण बदलना चाहते हैं, तो स्थानीय गुणों को संशोधित करें और फिर आवश्यक होने पर प्रभावी डेटा को पुनः पढ़कर परिणाम सत्यापित करें।