---
title: "C++ का उपयोग करके PowerPoint तालिकाओं में पंक्तियों और कॉलम को प्रबंधित करें"
linktitle: "पंक्तियाँ और कॉलम"
type: docs
weight: 20
url: /hi/cpp/manage-rows-and-columns/
keywords:
- तालिका पंक्ति
- तालिका कॉलम
- पहली पंक्ति
- तालिका हेडर
- पंक्ति क्लोन करें
- कॉलम क्लोन करें
- पंक्ति कॉपी करें
- कॉलम कॉपी करें
- पंक्ति हटाएँ
- कॉलम हटाएँ
- पंक्ति पाठ फ़ॉर्मेटिंग
- कॉलम पाठ फ़ॉर्मेटिंग
- तालिका शैली
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint में तालिका पंक्तियों और कॉलम को प्रबंधित करें और प्रस्तुति संपादन और डेटा अपडेट को तेज़ करें।"
---
## **परिचय**

Aspose.Slides for C++ आपको PowerPoint प्रस्तुतियों में तालिका संरचना और फ़ॉर्मेटिंग को [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) क्लास और [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) इंटरफ़ेस के माध्यम से प्रबंधित करने देता है। आप हेडर पंक्ति निर्दिष्ट कर सकते हैं, पंक्तियों और कॉलम को क्लोन या हटाया जा सकता है, और पूरे पंक्ति या कॉलम पर पाठ फ़ॉर्मेटिंग लागू कर सकते हैं।

यह लेख इन ऑपरेशनों को C++ उदाहरणों के साथ समझाता है। यह भी दिखाता है कि तालिका की शैली प्रीसेट को कैसे प्राप्त किया जाए ताकि आप उसे पुनः उपयोग कर सकें। तालिका पंक्ति और कॉलम सूचकांक शून्य‑आधारित होते हैं।

## **पंक्ति की ऊँचाई नियंत्रित करें**

[IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) का उपयोग करके पंक्ति की न्यूनतम ऊँचाई बिंदुओं में सेट करें। यह एक निचली सीमा है, न कि स्थिर ऊँचाई। [IRow::get_Height](https://reference.aspose.com/slides/cpp/aspose.slides/irow/get_height/) वास्तविक ऊँचाई लौटाता है; इस मान को सीधे सेट नहीं किया जा सकता। पंक्ति तक पहुँचने के लिए [ITable::get_Rows](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_rows/) का उपयोग करें।

उदाहरण में [row-height-input.pptx](row-height-input.pptx) लोड किया जाता है, जिसमें पहली स्लाइड पर पहली आकृति के रूप में एक तालिका होती है। इसकी पहली पंक्ति 70 बिंदु से शुरू होती है। कोशिकाएँ 18‑बिंदु Arial पाठ, रैपिंग, और 6‑बिंदु शीर्ष व नीचे मार्जिन का उपयोग करती हैं; दूसरे कॉलम में लंबा पाठ कई पंक्तियों में रैप होता है। उदाहरण न्यूनतम को 100 बिंदु बढ़ाता है, फिर 20 बिंदु तक घटाता है, प्रत्येक परिवर्तन के बाद वास्तविक ऊँचाई प्रिंट करता है, और दोनों परिणाम सहेजता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRow.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"row-height-input.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
auto row = table->get_Rows()->idx_get(0);

row->set_MinimalHeight(100);
Console::WriteLine(u"Increased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-increased.pptx", SaveFormat::Pptx);

row->set_MinimalHeight(20);
Console::WriteLine(u"Decreased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-decreased.pptx", SaveFormat::Pptx);
```

प्रदान किए गए प्रस्तुति के साथ, न्यूनतम बढ़ाने से पंक्ति में स्थान जोड़ता है। घटाने से वह अतिरिक्त स्थान हट जाता है, लेकिन वास्तविक ऊँचाई 20 बिंदु से अधिक रहती है क्योंकि पाठ और कोशिका मार्जिन को अधिक जगह की आवश्यकता होती है। केवल न्यूनतम को घटाने से पंक्ति को उसकी सामग्री द्वारा आवश्यक स्थान से नीचे नहीं धकेला जा सकता।

वास्तविक ऊँचाई को प्रभावित करने वाले कई कारक:

- **पाठ और फ़ॉन्ट आकार:** लंबा पाठ, स्पष्ट लाइन ब्रेक, या बड़ा फ़ॉन्ट अधिक ऊर्ध्वाधर स्थान की आवश्यकता कर सकता है।
- **रैपिंग और कॉलम चौड़ाई:** रैपिंग सक्षम होने पर, [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) के साथ कॉलम चौड़ाई घटाने से अधिक पंक्तियाँ बन सकती हैं। व्यापक कॉलम ऊर्ध्वाधर स्थान की जरूरत को कम कर सकता है।
- **कोशिका मार्जिन:** [ICell::set_MarginTop](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_margintop/) और [ICell::set_MarginBottom](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginbottom/) मार्जिन नियंत्रित करते हैं जो ऊर्ध्वाधर जगह जोड़ते हैं। [ICell::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginleft/) और [ICell::set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginright/) मार्जिन नियंत्रित करते हैं जो पाठ के लिए उपलब्ध चौड़ाई घटाते हैं और अतिरिक्त रैपिंग का कारण बन सकते हैं।

इस तालिका में कोई मिश्रित कोशिकाएँ नहीं हैं, इसलिए सबसे अधिक ऊर्ध्वाधर स्थान वाली कोशिका पूरी पंक्ति के लिए सामग्री‑निर्धारित निचली सीमा निर्धारित करती है। पंक्ति को छोटा करने के लिए, आपको पाठ को छोटा करना, फ़ॉन्ट आकार या मार्जिन घटाना, या कॉलम को चौड़ा करना पड़ सकता है।

नीचे दिखाए गए चित्र समान तालिका को समान माप में प्रदर्शित करते हैं। यहाँ प्रदर्शित .NET रन में वास्तविक ऊँचाइयाँ क्रमशः 70, 100 और 55.2 बिंदु थीं: अंतिम पंक्ति अपने 20‑बिंदु न्यूनतम से अधिक लंबी रही। सटीक पाठ माप आपके वातावरण में उपलब्ध फ़ॉन्ट्स के अनुसार बदल सकता है। सहेजे गए परिणाम डाउनलोड करें: [increased minimum](row-height-increased.pptx) और [decreased minimum](row-height-decreased.pptx)。

| मूल: न्यूनतम 70 pt, वास्तविक 70 pt | बढ़ाया: न्यूनतम 100 pt, वास्तविक 100 pt | घटाया: न्यूनतम 20 pt, वास्तविक 55.2 pt |
| --- | --- | --- |
| ![मूल तालिका जिसमें 70‑बिंदु की पहली पंक्ति है.](row-height-before.png) | ![पहली पंक्ति का न्यूनतम 100 बिंदु करने के बाद तालिका.](row-height-increased.png) | ![पहली पंक्ति का न्यूनतम 20 बिंदु करने के बाद तालिका; रैप किया गया पाठ पंक्ति को न्यूनतम से अधिक ऊँचा रखता है.](row-height-decreased.png) |

## **पहली पंक्ति को हेडर रूप में सेट करें**

पहली पंक्ति को हेडर फ़ॉर्मेटिंग के लिए चिह्नित करने हेतु [set_FirstRow](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_firstrow/) मेथड का उपयोग करें। इसका स्वरूप तालिका पर लागू तालिका शैली पर निर्भर करता है।

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) क्लास से प्रस्तुति लोड करें।  
2. पहली स्लाइड तक पहुँचें।  
3. स्लाइड पर पहली आकृति के रूप में संग्रहीत तालिका तक पहुँचें।  
4. उसकी पहली पंक्ति के लिए हेडर फ़ॉर्मेटिंग सक्षम करें।  
5. संशोधित प्रस्तुति सहेजें।

उदाहरण में `table.pptx` आवश्यक है जिसमें पहली स्लाइड पर पहली आकृति के रूप में एक तालिका हो। यह पहली पंक्ति के लिए हेडर फ़ॉर्मेटिंग सक्षम करता है और `First_row_header.pptx` सहेजता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
table->set_FirstRow(true);

presentation->Save(u"First_row_header.pptx", SaveFormat::Pptx);
```

## **तालिका पंक्ति या कॉलम को क्लोन करें**

पंक्तियों या कॉलम को क्लोन करके उनकी सामग्री और फ़ॉर्मेटिंग को पुनः उपयोग करें। आप कॉपी को तालिका के अंत में जोड़ सकते हैं या किसी विशिष्ट स्थिति में डाल सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) क्लास से प्रस्तुति लोड करें।  
2. पहली स्लाइड तक पहुँचें।  
3. कॉलम चौड़ाई और पंक्ति ऊँचाई निर्धारित करें।  
4. [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) मेथड से तालिका जोड़ें।  
5. आवश्यक पंक्तियों को क्लोन करें।  
6. आवश्यक कॉलम को क्लोन करें।  
7. संशोधित प्रस्तुति सहेजें।

उदाहरण में `Test.pptx` आवश्यक है जिसमें कम से कम एक स्लाइड हो। यह तीन कॉलम और पाँच पंक्तियों वाली तालिका बनाता है, बिंदुओं में निर्दिष्ट आयामों के साथ। यह पहली पंक्ति और कॉलम के प्रतिलिपियों को अंत में जोड़ता है, फिर दूसरी पंक्ति और कॉलम की प्रतिलिपियों को इंडेक्स 3 (चौथा स्थान) पर डालता है। परिणामी तालिका में सात पंक्तियाँ और पाँच कॉलम होते हैं। `false` तर्क संयोजित/मर्ज्ड पंक्तियों या कॉलमों में क्लोनिंग को निष्क्रिय करता है; इस तालिका में कोई मर्ज्ड कोशिकाएँ नहीं हैं।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Table/ICell.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 50, 50, 50 });
auto rowHeights = MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 1");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 2");
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

table->idx_get(0, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 1");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 2");
table->get_Rows()->InsertClone(3, table->get_Rows()->idx_get(1), false);

table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);
table->get_Columns()->InsertClone(3, table->get_Columns()->idx_get(1), false);

presentation->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **तालिका से पंक्ति या कॉलम हटाएँ**

तालिका में अब आवश्यकता न रही पंक्तियों या कॉलमों को हटाएँ। किसी आइटम को हटाने से उसके बाद वाली पंक्तियों या कॉलमों के सूचकांक शिफ्ट हो जाते हैं।

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) क्लास से प्रस्तुति बनाएँ।  
2. पहली स्लाइड तक पहुँचें।  
3. कॉलम चौड़ाई और पंक्ति ऊँचाई निर्धारित करें।  
4. [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) मेथड से तालिका जोड़ें।  
5. दूसरी पंक्ति और दूसरा कॉलम हटाएँ।  
6. संशोधित प्रस्तुति सहेजें।

यह उदाहरण तीन‑बाय‑तीन तालिका बनाता है और इंडेक्स 1 पर पंक्ति और कॉलम हटाता है, जिससे `TestTable_out.pptx` में दो‑बाय‑दो तालिका बचती है। आयाम बिंदुओं में हैं। `false` तर्क निकटवर्ती मर्ज्ड पंक्तियों या कॉलमों के हटाने को निष्क्रिय करता है; इस तालिका में कोई मर्ज्ड कोशिकाएँ नहीं हैं।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 50, 30 });
auto rowHeights = MakeArray<double>({ 30, 50, 30 });
auto table = slide->get_Shapes()->AddTable(100, 100, columnWidths, rowHeights);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);

presentation->Save(u"TestTable_out.pptx", SaveFormat::Pptx);
```

## **तालिका पंक्ति स्तर पर पाठ फ़ॉर्मेटिंग सेट करें**

पूरी पंक्ति पर पाठ फ़ॉर्मेटिंग लागू करें ताकि उसकी कोशिकाएँ समान रहें। आप फ़ॉन्ट गुण, पैराग्राफ फ़ॉर्मेटिंग, और पाठ दिशा सेट कर सकते हैं बिना प्रत्येक कोशिका को अलग‑अलग फ़ॉर्मेट किए।

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) क्लास से प्रस्तुति लोड करें।  
2. पहली स्लाइड पर तालिका तक पहुँचें।  
3. पहली पंक्ति के लिए [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) द्वारा फ़ॉन्ट ऊँचाई सेट करें।  
4. पहली पंक्ति के लिए [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) और [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) के साथ संरेखण और दायाँ पैराग्राफ मार्जिन सेट करें।  
5. दूसरी पंक्ति के लिए [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) द्वारा पाठ दिशा सेट करें।  
6. संशोधित प्रस्तुति सहेजें।

उदाहरण में `table.pptx` आवश्यक है जिसमें पहली स्लाइड पर पहली आकृति के रूप में एक तालिका हो और कम से कम दो पंक्तियाँ हों। यह पहली पंक्ति पर 25‑बिंदु पाठ, दायाँ संरेखण, और 20‑बिंदु दायाँ पैराग्राफ मार्जिन लागू करता है, फिर दूसरी पंक्ति में लंबवत पाठ सेट करता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IRow.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"row_formatting.pptx", SaveFormat::Pptx);
```

## **तालिका कॉलम स्तर पर पाठ फ़ॉर्मेटिंग सेट करें**

पूरे कॉलम पर पाठ फ़ॉर्मेटिंग लागू करें ताकि उसकी कोशिकाएँ समान रहें। आप फ़ॉन्ट गुण, पैराग्राफ फ़ॉर्मेटिंग, और पाठ दिशा सेट कर सकते हैं बिना प्रत्येक कोशिका को अलग‑अलग फ़ॉर्मेट किए।

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) क्लास से प्रस्तुति लोड करें।  
2. पहली स्लाइड पर तालिका तक पहुँचें।  
3. पहली कॉलम के लिए [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) द्वारा फ़ॉन्ट ऊँचाई सेट करें।  
4. पहली कॉलम के लिए [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) और [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) के साथ संरेखण और दायाँ पैराग्राफ मार्जिन सेट करें।  
5. दूसरी कॉलम के लिए [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) द्वारा पाठ दिशा सेट करें।  
6. संशोधित प्रस्तुति सहेजें।

उदाहरण में `table.pptx` आवश्यक है जिसमें पहली स्लाइड पर पहली आकृति के रूप में एक तालिका हो और कम से कम दो कॉलम हों। यह पहली कॉलम पर 25‑बिंदु पाठ, दायाँ संरेखण, और 20‑बिंदु दायाँ पैराग्राफ मार्जिन लागू करता है, फिर दूसरी कॉलम में लंबवत पाठ सेट करता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IColumn.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"column_formatting.pptx", SaveFormat::Pptx);
```

## **तालिका शैली गुण प्राप्त करें**

[get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) मेथड का उपयोग करके तालिका पर लागू प्रीसेट प्राप्त करें और उसे दूसरी तालिका पर पुनः उपयोग करें। यह व्यक्तिगत कोशिका फ़ॉर्मेट ओवरराइड के बजाय प्रीसेट की पहचान करता है।

उदाहरण एक तालिका बनाता है, [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) लागू करता है, और प्रीसेट को वापस पढ़ता है। यह `DarkStyle1` प्रिंट करता है और तालिका को `table.pptx` में सहेजता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <DOM/TableStylePreset.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 150 });
auto rowHeights = MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

Console::WriteLine(u"{0}", table->get_StylePreset());

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पहले से बनी तालिका पर PowerPoint थीम/शैलियों को लागू कर सकता हूँ?**

हां। तालिका स्लाइड/लेआउट/मास्टर थीम को विरासत में लेती है, और आप अभी भी फ़िल, बॉर्डर, और पाठ रंगों को उस थीम के ऊपर ओवरराइट कर सकते हैं।

**क्या मैं Excel की तरह तालिका पंक्तियों को सॉर्ट कर सकता हूँ?**

नहीं, Aspose.Slides तालिकाओं में अंतर्निर्मित सॉर्टिंग या फ़िल्टर नहीं होते। पहले डेटा को मेमोरी में सॉर्ट करें, फिर उसी क्रम में तालिका पंक्तियों को पुनः भरें।

**क्या मैं बैंडेड (धारीदार) कॉलम रख सकता हूँ जबकि विशिष्ट कोशिकाओं पर कस्टम रंग बनाये रखूँ?**

हां। बैंडेड कॉलम सक्षम करें, फिर विशिष्ट कोशिकाओं को स्थानीय फ़ॉर्मेटिंग से ओवरराइट करें; कोशिका‑स्तर की फ़ॉर्मेटिंग तालिका शैली पर प्राथमिकता लेती है।

{{end}}