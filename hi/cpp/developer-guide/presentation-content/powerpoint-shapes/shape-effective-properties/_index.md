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
- बीवेल आकार
- टेक्स्ट फ्रेम
- टेक्स्ट शैली
- फ़ॉन्ट ऊँचाई
- फ़िल फ़ॉर्मेट
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "PowerPoint प्रस्तुतियों में स्थानीय, विरासत में मिले, और प्रभावी आकार फ़ॉर्मेटिंग को पहचानने के लिए C++ के लिए Aspose.Slides का उपयोग करना सीखें।"
---
## **स्थानीय, विरासत में मिले, और प्रभावी गुणों को समझें**

PowerPoint फ़ॉर्मेटिंग कई स्थानों से आ सकती है। किसी वस्तु पर सीधे संग्रहीत मान उसका **स्थानीय मान** है। यदि वह मान सेट नहीं है, तो PowerPoint पैराग्राफ़ डिफ़ॉल्ट, टेक्स्ट शैली, लेआउट या मास्टर स्लाइड, थीम, या प्रस्तुति‑स्तर डिफ़ॉल्ट जैसे मूल फ़ॉर्मेटिंग स्रोतों को देखता है। ये मान **विरासत में मिले मान** हैं। पूरी पदानुक्रम हल होने के बाद जो मान बचता है, वह **प्रभावी मान** है—वह मान जो वस्तु को रेंडर करने के लिए उपयोग किया जाता है।

उदाहरण के लिए, किसी टेक्स्ट भाग ने अपना फ़ॉन्ट ऊँचाई परिभाषित नहीं की हो सकती है। इसका स्थानीय [फ़ॉन्ट ऊँचाई](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseportionformat/) तब `std::numeric_limits<float>::quiet_NaN()` होता है, जिसका अर्थ है “यहाँ सेट नहीं है।” भाग पैराग्राफ़, प्रस्तुति की डिफ़ॉल्ट टेक्स्ट शैली, या अन्य लागू स्रोत से ऊँचाई विरासत में ले सकता है। भाग फ़ॉर्मेट पर [GetEffective](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportionformat/) को कॉल करने से अंतिम निर्धारित ऊँचाई प्राप्त होती है।

इन दो प्रकार के फ़ॉर्मेटिंग डेटा का उपयोग विभिन्न उद्देश्यों के लिए किया जाता है:

- किसी स्थानीय फ़ॉर्मेट ऑब्जेक्ट को पढ़ें या बदलें, जैसे कि [IPortionFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportionformat/), जब आपको नियंत्रित करना हो कि मान कहाँ परिभाषित है।
- किसी प्रभावी डेटा ऑब्जेक्ट को पढ़ें, जैसे कि [IPortionFormatEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportionformateffectivedata/), जब आपको अंतिम, रेंडर किया गया परिणाम चाहिए। प्रभावी डेटा केवल पढ़ने‑के‑लिए है।

## **स्थानीय, विरासत में मिले, और प्रभावी मानों की तुलना**

निम्नलिखित पूर्ण उदाहरण एक आकार बनाता है और प्रस्तुति, पैराग्राफ और भाग स्तर पर फ़ॉन्ट ऊँचाइयों को लागू करता है। प्रत्येक चरण उन स्तरों पर परिभाषित मानों और समान टेक्स्ट भाग के लिए परिणामी प्रभावी मान को प्रिंट करता है। यह यह भी दिखाता है कि फ़ॉर्मेटिंग परिवर्तन के बाद प्रभावी डेटा को फिर से पढ़ना क्यों आवश्यक है।

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <cmath>
#include <limits>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 500.0f, 80.0f, false);
auto textFrame = shape->AddTextFrame(u"Effective formatting");
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

// Define inherited values at two different levels.
presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(20.0f);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);

auto formatLocalValue = [](float value) -> System::String
{
    return std::isnan(value) ? System::String(u"<not set>") : System::ObjectExt::ToString(value);
};

auto printFontHeights = [&](System::String caption)
{
    auto presentationValue = presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->get_FontHeight();
    auto paragraphValue = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FontHeight();
    auto localValue = portion->get_PortionFormat()->get_FontHeight();

    // Read effective data after the preceding changes.
    auto effectiveValue = portion->get_PortionFormat()->GetEffective()->get_FontHeight();

    System::Console::WriteLine(caption);
    System::Console::WriteLine(System::String(u"  Presentation default: ") + formatLocalValue(presentationValue));
    System::Console::WriteLine(System::String(u"  Paragraph default:    ") + formatLocalValue(paragraphValue));
    System::Console::WriteLine(System::String(u"  Portion local:        ") + formatLocalValue(localValue));
    System::Console::WriteLine(System::String(u"  Portion effective:    ") + effectiveValue);
};

printFontHeights(u"The portion inherits from the paragraph");

// A local value on the portion overrides both inherited values.
portion->get_PortionFormat()->set_FontHeight(36.0f);
printFontHeights(u"A local value overrides inherited values");

// Changing an inherited value does not override an existing local value.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(30.0f);
printFontHeights(u"The local value still has priority");

// Clear the local value. The portion now inherits from the paragraph again.
portion->get_PortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The local value is cleared");

// Clear the paragraph value. The presentation default now supplies the result.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The paragraph value is cleared");

presentation->Save(u"effective-properties.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

इस उदाहरण में प्राथमिकता भाग का स्थानीय फ़ॉर्मेट, फिर पैराग्राफ फ़ॉर्मेट, फिर प्रस्तुति डिफ़ॉल्ट है। अन्य वस्तुओं की विरासत श्रृंखलाएँ अलग हो सकती हैं, लेकिन सिद्धांत समान है: अधिक विशिष्ट स्पष्ट मान जीतता है, और [GetEffective](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportionformat/) अंतिम परिणाम लौटाता है।

## **प्रभावी टेक्स्ट गुण प्राप्त करें**

टेक्स्ट फ़ॉर्मेटिंग कई वस्तुओं में बँटी होती है:

- [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframeformat/) मार्जिन, एंकरिंग, ऑटोफ़िट और वर्टिकल टेक्स्ट डायरेक्शन जैसे टेक्स्ट‑फ़्रेम गुणों को हल करता है।
- [ITextStyle::GetEffective](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextstyle/) प्रत्येक टेक्स्ट शैली स्तर के लिए पैराग्राफ फ़ॉर्मेटिंग को हल करता है।
- [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/) संरेखण, इंडेंटेशन और बुलेट्स जैसे पैराग्राफ गुणों को हल करता है।
- [IPortionFormat::GetEffective](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportionformat/) फ़ॉन्ट ऊँचाई, टाइपफ़ेस, रंग, बोल्ड और इटैलिक जैसे कैरेक्टर गुणों को हल करता है।

अगले उदाहरण के लिए, `text-formatting.pptx` में कम से कम एक स्लाइड और एक गैर‑खाली टेक्स्ट फ़्रेम वाला [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) होना चाहिए। IAutoShape आकार संग्रह में कहीं भी प्रदर्शित हो सकता है; कोड उपयुक्त वस्तु को खोजता है और उपयोग से पहले उसकी वैधता जांचता है।

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"text-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<IAutoShape> shape;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (!System::ObjectExt::Is<IAutoShape>(candidate))
        continue;

    auto autoShape = System::ExplicitCast<IAutoShape>(candidate);
    auto candidateTextFrame = autoShape->get_TextFrame();

    if (candidateTextFrame == nullptr || candidateTextFrame->get_Paragraphs()->get_Count() == 0)
        continue;

    if (candidateTextFrame->get_Paragraph(0)->get_Portions()->get_Count() == 0)
        continue;

    shape = autoShape;
    break;
}

if (shape == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain an IAutoShape with non-empty text.");

auto textFrame = shape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

auto textFrameEffective = textFrame->get_TextFrameFormat()->GetEffective();
auto paragraphEffective = paragraph->get_ParagraphFormat()->GetEffective();
auto portionEffective = portion->get_PortionFormat()->GetEffective();

System::Console::WriteLine(u"Text frame margins:");
System::Console::WriteLine(System::String(u"  Left: ") + textFrameEffective->get_MarginLeft());
System::Console::WriteLine(System::String(u"  Top: ") + textFrameEffective->get_MarginTop());
System::Console::WriteLine(System::String(u"  Right: ") + textFrameEffective->get_MarginRight());
System::Console::WriteLine(System::String(u"  Bottom: ") + textFrameEffective->get_MarginBottom());
System::Console::WriteLine(System::String(u"Paragraph alignment: ") + System::ObjectExt::ToString(paragraphEffective->get_Alignment()));
System::Console::WriteLine(System::String(u"Font height: ") + portionEffective->get_FontHeight());
System::Console::WriteLine(System::String(u"Bold: ") + System::ObjectExt::ToString(portionEffective->get_FontBold()));

auto effectiveTextStyle = textFrame->get_TextFrameFormat()->get_TextStyle()->GetEffective();
for (int level = 0; level < 9; ++level)
{
    auto levelEffective = effectiveTextStyle->GetLevel(level);
    System::Console::WriteLine(System::String(u"Level ") + level + u" indent: " + levelEffective->get_Indent());
}

presentation->Dispose();
```

## **प्रभावी 3D गुण प्राप्त करें**

[IThreeDFormat::GetEffective](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformat/) एक [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ithreedformateffectivedata/) ऑब्जेक्ट लौटाता है जो सभी हल किए गए 3D सेटिंग्स को समूहित करता है। इसका [camera](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icameraeffectivedata/), [light rig](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilightrigeffectivedata/), [top bevel](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapebeveleffectivedata/) और [bottom bevel](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapebeveleffectivedata/) डेटा संबंधित प्रभावी सेटिंग्स को उजागर करता है। इन संबंधित सेटिंग्स को साथ‑साथ पढ़ने से आकार की अंतिम 3D उपस्थिति को समझना आसान हो जाता है।

इस उदाहरण के लिए, `shape-3d.pptx` में पहली स्लाइड पर कम से कम एक आकार होना चाहिए। यदि आप आउटपुट में डिफ़ॉल्ट के अलावा मान देखना चाहते हैं, तो उस आकार पर 3D कैमरा, लाइटिंग या बीवेल सेटिंग्स लागू करें।

```cpp
#include <DOM/ICameraEffectiveData.h>
#include <DOM/ILightRigEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeBevelEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"shape-3d.pptx");

if (presentation->get_Slides()->get_Count() == 0 || presentation->get_Slide(0)->get_Shapes()->get_Count() == 0)
    throw System::InvalidOperationException(u"The first slide must contain a shape.");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto threeDEffective = shape->get_ThreeDFormat()->GetEffective();

System::Console::WriteLine(u"Camera:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_Camera()->get_CameraType()));
System::Console::WriteLine(System::String(u"  Field of view: ") + threeDEffective->get_Camera()->get_FieldOfViewAngle());
System::Console::WriteLine(System::String(u"  Zoom: ") + threeDEffective->get_Camera()->get_Zoom());

System::Console::WriteLine(u"Light rig:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_LightType()));
System::Console::WriteLine(System::String(u"  Direction: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_Direction()));

System::Console::WriteLine(u"Top bevel:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_BevelTop()->get_BevelType()));
System::Console::WriteLine(System::String(u"  Width: ") + threeDEffective->get_BevelTop()->get_Width());
System::Console::WriteLine(System::String(u"  Height: ") + threeDEffective->get_BevelTop()->get_Height());

presentation->Dispose();
```

## **प्रभावी टेबल फ़ॉर्मेटिंग प्राप्त करें**

टेबल फ़ॉर्मेटिंग टेबल शैली और पूरी टेबल, एक कॉलम, एक पंक्ति या व्यक्तिगत सेल पर लागू फ़ॉर्मेट से आ सकती है। स्पष्ट रूप से परिभाषित फ़िल्स के बीच टकराव की स्थिति में प्राथमिकता क्रम सेल, पंक्ति, कॉलम, और फिर पूरी टेबल है। किसी सेल का प्रभावी फ़ॉर्मेट वह अंतिम फ़ॉर्मेट है जो उस सेल को ड्रॉ करने के लिए उपयोग किया जाता है।

इस उदाहरण के लिए, `table-formatting.pptx` में पहली स्लाइड पर कम से कम एक टेबल होना चाहिए। टेबल में कम से कम एक पंक्ति और एक कॉलम होना अनिवार्य है। कोड यह मानने के बजाय एक [ITable](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itable/) खोजता है कि पहली आकार टेबल है।

```cpp
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IColumnFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRowFormat.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ITableFormat.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"table-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (System::ObjectExt::Is<ITable>(candidate))
    {
        table = System::ExplicitCast<ITable>(candidate);
        break;
    }
}

if (table == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain a table.");

if (table->get_Rows()->get_Count() == 0 || table->get_Columns()->get_Count() == 0)
    throw System::InvalidOperationException(u"The table must contain at least one cell.");

auto tableEffective = table->get_TableFormat()->GetEffective();
auto rowEffective = table->get_Row(0)->get_RowFormat()->GetEffective();
auto columnEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective();
auto cellEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective();

System::Console::WriteLine(System::String(u"Table fill: ") + System::ObjectExt::ToString(tableEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Row fill: ") + System::ObjectExt::ToString(rowEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Column fill: ") + System::ObjectExt::ToString(columnEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Final cell fill: ") + System::ObjectExt::ToString(cellEffective->get_FillFormat()->get_FillType()));

presentation->Dispose();
```

यदि आपको केवल फ़िल टाइप के बजाय रंग चाहिए, तो पहले प्रभावी [FillType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifillformateffectivedata/) की जाँच करें, और फिर उस प्रकार पर लागू प्रॉपर्टी पढ़ें—उदाहरण के लिए, ठोस फ़िल के लिए [SolidFillColor](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifillformateffectivedata/)।

## **परिवर्तन के बाद प्रभावी डेटा को पुनः पढ़ें**

प्रभावी डेटा उस समय की फ़ॉर्मेटिंग पदानुक्रम का वर्णन करता है जब उसे हल किया गया था। `GetEffective` को फिर से कॉल करें जब भी आप उस पदानुक्रम में भाग लेने वाली किसी भी चीज़ को बदलें, जिनमें शामिल हैं:

- वस्तु का स्थानीय फ़ॉर्मेट;
- पैराग्राफ या टेक्स्ट‑फ़्रेम डिफ़ॉल्ट;
- टेबल शैली, टेबल, कॉलम, पंक्ति या सेल फ़ॉर्मेट;
- लेआउट या मास्टर स्लाइड फ़ॉर्मेट;
- थीम डेटा या प्रस्तुति‑स्तर डिफ़ॉल्ट;
- स्लाइड को सौंपा गया लेआउट या मास्टर।

एक प्रभावी डेटा ऑब्जेक्ट को स्थायी स्नैपशॉट के रूप में न रखें। Aspose.Slides कुछ प्रभावी डेटा को आंतरिक रूप से कैश कर सकता है, और बाद में `GetEffective` कॉल उस डेटा को रीफ़्रेश कर सकता है। यदि आपको परिवर्तन से पहले और बाद में मानों की तुलना करनी है, तो परिवर्तन करने से पहले आवश्यक स्केलर मानों—जैसे फ़ॉन्ट ऊँचाई, रंग, संरेखण या बीवेल चौड़ाई—को अपनी स्वयं की वेरिएबल्स में कॉपी कर लें।

किसी मान को बदलने के लिए, उपयुक्त स्थानीय फ़ॉर्मेट ऑब्जेक्ट को अद्यतन करें और फिर `GetEffective` को कॉल करके परिणाम को सत्यापित करें। प्रभावी डेटा ऑब्जेक्ट स्वयं केवल‑पढ़ने‑के‑लिए होते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे पता कर सकता हूँ कि कौन सा स्तर प्रभावी मान प्रदान कर रहा है?**

प्रभावी डेटा केवल अंतिम मान रखता है, स्रोत नहीं। सबसे विशिष्ट स्तर से बाहर की ओर लागू स्थानीय वस्तुओं की जाँच करें। टेक्स्ट के लिए यह भाग, पैराग्राफ, टेक्स्ट फ्रेम, लेआउट, मास्टर, थीम और प्रस्तुति डिफ़ॉल्ट शामिल कर सकता है। `std::numeric_limits<float>::quiet_NaN()` या `nullptr` जैसी अपरिभाषित मान यह दर्शाते हैं कि खोज आगे के स्तर पर जारी रहती है।

**जब कोई स्तर किसी प्रॉपर्टी को परिभाषित नहीं करता तो क्या होता है?**

Aspose.Slides उपयुक्त PowerPoint या लाइब्रेरी डिफ़ॉल्ट को हल करता है। वह हल किया गया मान प्रभावी डेटा में दिखाई देता है जबकि कोई स्थानीय वस्तु इसे स्पष्ट रूप से परिभाषित नहीं करती।

**कभी‑कभी प्रभावी मान स्थानीय मान के बराबर क्यों होता है?**

स्थानीय मान ने विरासत गणना जीत ली है। यह तब अपेक्षित है जब प्रॉपर्टी स्पष्ट रूप से वस्तु पर सेट की गई हो और कोई अधिक विशिष्ट नियम उसे ओवरराइड न करे।

**मुझे स्थानीय डेटा के बजाय प्रभावी डेटा कब उपयोग करना चाहिए?**

स्थानीय डेटा का उपयोग किसी विशिष्ट फ़ॉर्मेटिंग स्तर को निरीक्षण या संपादित करने के लिए करें। प्रभावी डेटा का उपयोग तब करें जब आपको विरासत, थीम नियम और लागू शैलियों के हल होने के बाद अंतिम उपस्थिति चाहिए। [complete comparison example](#compare-local-inherited-and-effective-values) दोनों को एक ही कार्यप्रवाह में दर्शाता है।