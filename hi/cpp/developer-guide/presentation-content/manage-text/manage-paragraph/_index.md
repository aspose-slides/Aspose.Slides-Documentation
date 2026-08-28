---
title: "C++ में PowerPoint टेक्स्ट पैराग्राफ प्रबंधित करें"
linktitle: "पैराग्राफ प्रबंधित करें"
type: docs
weight: 40
url: /hi/cpp/manage-paragraph/
aliases:
  - /cpp/paragraph/
  - /cpp/portion/
keywords:
  - "टेक्स्ट जोड़ें"
  - "पैराग्राफ जोड़ें"
  - "टेक्स्ट प्रबंधित करें"
  - "पैराग्राफ प्रबंधित करें"
  - "बुलेट प्रबंधित करें"
  - "पैराग्राफ इंडेंट"
  - "हैंगिंग इंडेंट"
  - "पैराग्राफ बुलेट"
  - "क्रमांकित सूची"
  - "बुलेटेड सूची"
  - "पैराग्राफ गुण"
  - "HTML आयात करें"
  - "टेक्स्ट को HTML में"
  - "पैराग्राफ को HTML में"
  - "पैराग्राफ को इमेज में"
  - "टेक्स्ट को इमेज में"
  - "पैराग्राफ निर्यात करें"
  - "PowerPoint"
  - "प्रेजेंटेशन"
  - "C++"
  - "Aspose.Slides"
description: "Aspose.Slides for C++ के साथ पैराग्राफ, पोर्शन, बुलेट, क्रमांकित सूचियाँ, इंडेंट, HTML सामग्री, और पैराग्राफ इमेज कैसे बनाएं और फॉर्मेट करें, सीखें।"
---
## **परिचय**

Aspose.Slides for C++ टेक्स्ट को टेक्स्ट फ़्रेम, पैराग्राफ और पोर्शन की पदानुक्रम में दर्शाता है:

* [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) एक आकार में टेक्स्ट कंटेनर को दर्शाता है और इसके पैराग्राफ संग्रह तक पहुँच प्रदान करता है।
* [IParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraph/) एक टेक्स्ट फ़्रेम में एक पैराग्राफ को दर्शाता है और इसके पोर्शन तथा पैराग्राफ‑स्तर फॉर्मेटिंग तक पहुँच प्रदान करता है।
* [IPortion](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportion/) एक पैराग्राफ के भीतर टेक्स्ट रन को दर्शाता है। प्रत्येक पोर्शन का अपना टेक्स्ट और कैरेक्टर‑स्तर फॉर्मेटिंग हो सकता है।

इस प्रकार एक पैराग्राफ विभिन्न फ़ॉन्ट, रंग, आकार और अन्य फॉर्मेटिंग वाले टेक्स्ट को कई पोर्शन का उपयोग करके रख सकता है।

## **पैराग्राफ बनाना और फॉर्मेट करना**

### **एकाधिक पोर्शन के साथ पैराग्राफ बनाना**

निम्न चरण तीन पैराग्राफ वाला टेक्स्ट फ़्रेम बनाते हैं, प्रत्येक में तीन पोर्शन होते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड का रेफरेंस प्राप्त करें।
3. स्लाइड पर एक आयताकार [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
4. आकार के [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) को एक्सेस करें।
5. डिफ़ॉल्ट पैराग्राफ का उपयोग करें और टेक्स्ट फ़्रेम में दो अतिरिक्त [IParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraph/) ऑब्जेक्ट जोड़ें।
6. प्रत्येक पैराग्राफ में तीन पोर्शन रखने के लिए पर्याप्त [IPortion](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportion/) ऑब्जेक्ट जोड़ें। डिफ़ॉल्ट पैराग्राफ में पहले से एक खाली पोर्शन होता है।
7. प्रत्येक पोर्शन का टेक्स्ट सेट करें।
8. [IPortion::get_PortionFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportion/get_portionformat/) के माध्यम से कैरेक्टर‑स्तर फॉर्मेटिंग लागू करें।
9. संशोधित प्रेजेंटेशन को सहेजें।

यह C++ उदाहरण इन चरणों को लागू करता है:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
auto textFrame = shape->get_TextFrame();

auto firstParagraph = textFrame->get_Paragraph(0);
firstParagraph->get_Portions()->Add(MakeObject<Portion>());
firstParagraph->get_Portions()->Add(MakeObject<Portion>());

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
textFrame->get_Paragraphs()->Add(secondParagraph);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
textFrame->get_Paragraphs()->Add(thirdParagraph);

auto paragraphCount = textFrame->get_Paragraphs()->get_Count();
for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = textFrame->get_Paragraph(paragraphIndex);
    auto portionCount = paragraph->get_Portions()->get_Count();
    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = paragraph->get_Portion(portionIndex);
        portion->set_Text(String::Format(u"Portion {0}.{1}", paragraphIndex + 1, portionIndex + 1));
        auto portionFormat = portion->get_PortionFormat();

        if (portionIndex == 0)
        {
            portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
            portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
            portionFormat->set_FontBold(NullableBool::True);
            portionFormat->set_FontHeight(15);
        }
        else if (portionIndex == 1)
        {
            portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
            portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
            portionFormat->set_FontItalic(NullableBool::True);
            portionFormat->set_FontHeight(18);
        }
    }
}

presentation->Save(u"paragraphs_with_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **बुलेटेड और क्रमांकित सूचियाँ बनाना**

### **बुलेटेड या क्रमांकित सूची बनाना**

बुलेट और क्रमांकित सूची आइटमों को पढ़ने में आसान बनाते हैं। Aspose.Slides में सूची सेटिंग्स को [IBulletFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibulletformat/) के माध्यम से परिभाषित किया जाता है।

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड का रेफरेंस प्राप्त करें।
3. चयनित स्लाइड पर एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
4. आकार के [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) को एक्सेस करें।
5. टेक्स्ट फ़्रेम से डिफ़ॉल्ट पैराग्राफ को हटाएँ।
6. एक सिम्बॉल बुलेट के लिए एक [Paragraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides/paragraph/) बनाएं।
7. [IBulletFormat::set_Type](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibulletformat/set_type/) को [BulletType::Symbol](https://reference.aspose.com/slides/hi/cpp/aspose.slides/bullettype/) पर सेट करें और बुलेट कैरेक्टर निर्दिष्ट करें।
8. पैराग्राफ टेक्स्ट, इंडेंट, बुलेट रंग और बुलेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ़्रेम में जोड़ें।
10. दूसरा पैराग्राफ बनाएं और [IBulletFormat::set_Type](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibulletformat/set_type/) को [BulletType::Numbered](https://reference.aspose.com/slides/hi/cpp/aspose.slides/bullettype/) पर सेट करें।
11. क्रमांकित बुलेट शैली को कॉन्फ़िगर करें और पैराग्राफ को टेक्स्ट फ़्रेम में जोड़ें।
12. प्रेजेंटेशन को सहेजें।

यह C++ उदाहरण सिम्बॉल बुलेट और क्रमांकित बुलेट बनाता है:

```cpp
#include <DOM/BulletType.h>
#include <DOM/ColorType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/NumberedBulletStyle.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/convert.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto symbolParagraph = MakeObject<Paragraph>();
symbolParagraph->set_Text(u"Welcome to Aspose.Slides");
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
symbolParagraph->get_ParagraphFormat()->set_Indent(25);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(symbolParagraph);

auto numberedParagraph = MakeObject<Paragraph>();
numberedParagraph->set_Text(u"This is a numbered item");
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
numberedParagraph->get_ParagraphFormat()->set_Indent(25);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(numberedParagraph);

presentation->Save(u"bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **चित्र बुलेट का उपयोग करना**

चित्र बुलेट आपको सिम्बॉल या नंबर की जगह एक कस्टम इमेज उपयोग करने की अनुमति देता है।

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड का रेफरेंस प्राप्त करें।
3. एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें और उसका [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) एक्सेस करें।
4. टेक्स्ट फ़्रेम से डिफ़ॉल्ट पैराग्राफ को हटाएँ।
5. बुलेट इमेज को लोड करें और इसे प्रेजेंटेशन की इमेज कलेक्शन में एक [IPPImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ippimage/) के रूप में जोड़ें।
6. एक [Paragraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides/paragraph/) बनाएं और उसका टेक्स्ट सेट करें।
7. [IBulletFormat::set_Type](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibulletformat/set_type/) को [BulletType::Picture](https://reference.aspose.com/slides/hi/cpp/aspose.slides/bullettype/) पर सेट करें।
8. [ISlidesPicture::set_Image](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidespicture/set_image/) के माध्यम से इमेज असाइन करें और बुलेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ़्रेम में जोड़ें।
10. संशोधित प्रेजेंटेशन को सहेजें।

यह C++ उदाहरण चित्र बुलेट बनाता है:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto bulletImage = Images::FromFile(u"bullets.png");
auto presentationImage = presentation->get_Images()->AddImage(bulletImage);
bulletImage->Dispose();

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph = MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(presentationImage);
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(paragraph);

presentation->Save(u"picture_bullet.pptx", SaveFormat::Pptx);
presentation->Save(u"picture_bullet.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

### **बहु‑स्तरीय सूची बनाना**

[IParagraphFormat::set_Depth](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_depth/) को सेट करके पैराग्राफ को सूची के विभिन्न स्तरों पर रखा जाता है। शीर्ष स्तर का गहराई `0` है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) बनाएं और एक स्लाइड एक्सेस करें।
2. एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें और उसके टेक्स्ट फ़्रेम से डिफ़ॉल्ट पैराग्राफ को साफ़ करें।
3. चार पैराग्राफ बनाएं और उनके बुलेट सिम्बॉल कॉन्फ़िगर करें।
4. उनके [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_depth/) मानों को क्रमशः `0`, `1`, `2` और `3` सेट करें।
5. पैराग्राफ को टेक्स्ट फ़्रेम में जोड़ें और प्रेजेंटेशन को सहेजें।

यह C++ उदाहरण चार‑स्तरीय बुलेटेड सूची बनाता है:

```cpp
#include <DOM/BulletType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/convert.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"Content");
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_Depth(0);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Second level");
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(u'-');
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_Depth(1);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"Third level");
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->get_ParagraphFormat()->set_Depth(2);

auto fourthParagraph = MakeObject<Paragraph>();
fourthParagraph->set_Text(u"Fourth level");
fourthParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
fourthParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(u'-');
fourthParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
fourthParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
fourthParagraph->get_ParagraphFormat()->set_Depth(3);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);
textFrame->get_Paragraphs()->Add(fourthParagraph);

presentation->Save(u"multilevel_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **कस्टम मान से क्रमांकित सूची आइटम शुरू करना**

[IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) का उपयोग करके क्रमांकित पैराग्राफ के प्रारंभिक नंबर को सेट किया जा सकता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) बनाएं और एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) को स्लाइड पर जोड़ें।
2. आकार के टेक्स्ट फ़्रेम से डिफ़ॉल्ट पैराग्राफ को साफ़ करें।
3. तीन क्रमांकित पैराग्राफ बनाएं।
4. संबंधित पैराग्राफ के लिए [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) को क्रमशः `2`, `3` और `7` पर सेट करें।
5. पैराग्राफ को टेक्स्ट फ़्रेम में जोड़ें और प्रेजेंटेशन को सहेजें।

यह C++ उदाहरण प्रत्येक पैराग्राफ के लिए कस्टम प्रारंभिक नंबर असाइन करता है:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"Start at 2");
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(2);
textFrame->get_Paragraphs()->Add(firstParagraph);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Start at 3");
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(3);
textFrame->get_Paragraphs()->Add(secondParagraph);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"Start at 7");
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(7);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"custom_numbered_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **पैराग्राफ लेआउट और अंत गुणों को नियंत्रित करना**

### **पहली‑लाइन इंडेंट सेट करना**

[IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_indent/) का उपयोग करके पैराग्राफ की पहली लाइन की इंडेंट नियंत्रित की जा सकती है। यह विधि केवल पहली लाइन को पैराग्राफ के बाएँ मार्जिन के सापेक्ष ले आती है। सकारात्मक मान पहली लाइन को दाईं ओर शिफ्ट करता है, जबकि शेष लाइनों को पैराग्राफ बॉडी के साथ संरेखित रखता है।

पूरे पैराग्राफ को स्थानांतरित करने के लिये [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_marginleft/) का उपयोग करें। केवल पहली लाइन को स्थानांतरित करने के लिये [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_indent/) का उपयोग करें।

नीचे दिया गया उदाहरण कई पैराग्राफ बनाता है और विभिन्न [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_indent/) मान लागू करके दिखाता है कि पहली‑लाइन इंडेंट पैराग्राफ लेआउट को कैसे प्रभावित करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. लक्ष्य स्लाइड को एक्सेस करें।
3. स्लाइड पर एक आयताकार [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
4. आकार के [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) को एक्सेस करें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. कई पैराग्राफ बनाएं और उनके लिये विभिन्न [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_indent/) मान सेट करें।
6. पैराग्राफ को टेक्स्ट फ़्रेम में जोड़ें।
7. संशोधित प्रेजेंटेशन को सहेजें।

यह कोड दिखाता है कि पैराग्राफ इंडेंट कैसे सेट करें:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"No first-line indent. Wrapped lines start at the same position as the first line.");
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_MarginLeft(20);
firstParagraph->get_ParagraphFormat()->set_Indent(0);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_MarginLeft(20);
secondParagraph->get_ParagraphFormat()->set_Indent(20);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->get_ParagraphFormat()->set_MarginLeft(20);
thirdParagraph->get_ParagraphFormat()->set_Indent(40);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"paragraph_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![पैराग्राफ की पहली‑लाइन इंडेंट](first_line_indent.png)

### **हैंगिंग इंडेंट सेट करना**

हैंगिंग इंडेंट एक पैराग्राफ लेआउट है जिसमें पहली लाइन शेष लाइनों से बायीं ओर शुरू होती है। Aspose.Slides में इसे आप [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_indent/) के साथ नकारात्मक मान सेट करके प्राप्त करते हैं।

व्यावहारिक रूप से, [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_marginleft/) पैराग्राफ बॉडी की बाएँ स्थिति निर्धारित करता है, और [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_indent/) पहली लाइन की स्थिति को उस मार्जिन के सापेक्ष निर्धारित करता है। हैंगिंग इंडेंट बनाने के लिये, एक सकारात्मक margin‑left मान और एक नकारात्मक indent मान सेट करें।

यह फॉर्मेटिंग बिब्लियोग्राफी, रेफ़रेंस, शब्दकोश प्रविष्टियों आदि के लिये उपयोगी है जहाँ रैप्ड लाइनों को पैराग्राफ बॉडी के नीचे संरेखित करना आवश्यक होता है न कि पहली लाइन के पहले अक्षर के नीचे।

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. लक्ष्य स्लाइड को एक्सेस करें।
3. स्लाइड पर एक आयताकार [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
4. आकार के [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) को एक्सेस करें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. पैराग्राफ बनाएं और प्रत्येक के लिये एक सकारात्मक [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_marginleft/) मान सेट करें।
6. हैंगिंग इंडेंट प्रभाव बनाने के लिये नकारात्मक [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_indent/) मान सेट करें।
7. पैराग्राफ को टेक्स्ट फ़्रेम में जोड़ें।
8. संशोधित प्रेजेंटेशन को सहेजें।

यह कोड दिखाता है कि पैराग्राफ के लिये हैंगिंग इंडेंट कैसे सेट करें:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_MarginLeft(40);
firstParagraph->get_ParagraphFormat()->set_Indent(-20);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_MarginLeft(60);
secondParagraph->get_ParagraphFormat()->set_Indent(-30);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"h hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![पैराग्राफ की हैंगिंग इंडेंट](hanging_indent.png)

### **अंत पैराग्राफ रन गुण सेट करना**

[IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) पैराग्राफ अंत चिह्न की फॉर्मेटिंग को नियंत्रित करता है। निम्न उदाहरण दूसरे पैराग्राफ के अंत चिह्न को फ़ॉन्ट आकार और लैटिन फ़ॉन्ट असाइन करता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) लोड करें और एक स्लाइड एक्सेस करें।
2. एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें और उसका डिफ़ॉल्ट पैराग्राफ साफ़ करें।
3. दो पैराग्राफ बनाएं और उनमें टेक्स्ट पोर्शन जोड़ें।
4. दूसरे पैराग्राफ के अंत चिह्न के लिये एक [PortionFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/portionformat/) बनाएं।
5. [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseportionformat/set_fontheight/) और [IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseportionformat/set_latinfont/) सेट करें।
6. [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) के साथ फॉर्मेट असाइन करें और प्रेजेंटेशन को सहेजें।

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_Portions()->Add(MakeObject<Portion>(u"Sample text"));

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_Portions()->Add(MakeObject<Portion>(u"Sample text 2"));

auto endParagraphFormat = MakeObject<PortionFormat>();
endParagraphFormat->set_FontHeight(48);
endParagraphFormat->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));
secondParagraph->set_EndParagraphPortionFormat(endParagraphFormat);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"end_paragraph_format.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **पैराग्राफ सामग्री का आयात और निर्यात**

### **HTML टेक्स्ट को पैराग्राफ में आयात करना**

[IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphcollection/addfromhtml/) का उपयोग करके HTML मार्कअप को टेक्स्ट फ़्रेम में पैराग्राफ और पोर्शन में परिवर्तित किया जाता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. एक स्लाइड एक्सेस करें और एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
3. आकार के [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) को एक्सेस करें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
4. स्रोत HTML फ़ाइल पढ़ें।
5. HTML स्ट्रिंग को [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphcollection/addfromhtml/) में पास करें।
6. संशोधित प्रेजेंटेशन को सहेजें।

यह C++ उदाहरण HTML को टेक्स्ट फ़्रेम में आयात करता है:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/stream_reader.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto slideSize = presentation->get_SlideSize()->get_Size();
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, slideSize.get_Width() - 20, slideSize.get_Height() - 20);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->get_Paragraphs()->Clear();

auto reader = MakeObject<StreamReader>(u"file.html");
auto html = reader->ReadToEnd();
reader->Close();
shape->get_TextFrame()->get_Paragraphs()->AddFromHtml(html);

presentation->Save(u"html_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **पैराग्राफ टेक्स्ट को HTML में निर्यात करना**

[IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphcollection/exporttohtml/) का उपयोग करके चयनित पैराग्राफ रेंज को HTML के रूप में निर्यात किया जाता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) इंस्टेंस बनाएं और इच्छित प्रेजेंटेशन लोड करें।
2. स्लाइड एक्सेस करें और वह [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) खोजें जिसमें टेक्स्ट है।
3. आकार के [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) को एक्सेस करें।
4. शुरूआती पैराग्राफ इंडेक्स और निर्यात करने वाले पैराग्राफों की संख्या के साथ [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphcollection/exporttohtml/) को कॉल करें।
5. लौटाए गए HTML स्ट्रिंग को फ़ाइल में लिखें।

यह C++ उदाहरण पहले टेक्स्ट शेप से सभी पैराग्राफ निर्यात करता है:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/stream_writer.h>
#include <system/object_ext.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;
using namespace System::Text;

auto presentation = MakeObject<Presentation>(u"ExportingHTMLText.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr)
{
    auto paragraphs = textShape->get_TextFrame()->get_Paragraphs();
    auto html = paragraphs->ExportToHtml(0, paragraphs->get_Count(), nullptr);
    auto writer = MakeObject<StreamWriter>(u"paragraphs.html", false, Encoding::get_UTF8());
    writer->Write(html);
    writer->Close();
}
else
{
    Console::WriteLine(u"The first shape is not a text shape.");
}

presentation->Dispose();
```

### **पैराग्राफ को इमेज के रूप में रेंडर करना**

[IParagraph::GetImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraph/getimage/) एक व्यक्तिगत पैराग्राफ को सीधे रेंडर करता है और एक [IImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimage/) लौटाता है। इस परिणाम को [IImage::Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimage/save/) से फ़ाइल या स्ट्रीम में सहेजा जा सकता है। आपको पूरे शेप को रेंडर करने या बिटमैप को मैन्युअली क्रॉप करने की आवश्यकता नहीं है।

[IParagraph::GetImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraph/getimage/) `nullptr` भी दे सकता है यदि पैराग्राफ पैरेंट कलेक्शन में नहीं मिला, वैध रेंडरिंग बाउंड्स नहीं हैं या रेंडर नहीं किया जा सकता। सहेजने से पहले परिणाम की जांच करें और उपयोग के बाद लौटाई गई इमेज को डिस्पोज़ करें।

#### **डिफ़ॉल्ट स्केल पर पैराग्राफ रेंडर करना**

मान लें कि हमारे पास `sample.pptx` नाम की एक प्रेजेंटेशन फ़ाइल है जिसमें एक स्लाइड है, जहाँ पहला शेप तीन पैराग्राफ वाले टेक्स्ट बॉक्स है।

![तीन पैराग्राफ वाले टेक्स्ट बॉक्स](paragraph_to_image_input.png)

निम्न उदाहरण डिफ़ॉल्ट स्केल पर दूसरे पैराग्राफ को रेंडर करता है और PNG स्वरूप में इमेज सहेजता है।

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr && textShape->get_TextFrame()->get_Paragraphs()->get_Count() > 1)
{
    auto paragraph = textShape->get_TextFrame()->get_Paragraph(1);
    auto paragraphImage = paragraph->GetImage();

    if (paragraphImage != nullptr)
    {
        paragraphImage->Save(u"paragraph.png", ImageFormat::Png);
        paragraphImage->Dispose();
    }
    else
    {
        Console::WriteLine(u"The paragraph could not be rendered.");
    }
}
else
{
    Console::WriteLine(u"The expected text shape or paragraph was not found.");
}

presentation->Dispose();
```

परिणाम:

![पैराग्राफ इमेज](paragraph_to_image_output.png)

#### **टेबल सेल में पैराग्राफ को स्केल के साथ रेंडर करना**

[IParagraph::GetImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraph/getimage/) के उस ओवरलोड का उपयोग करें जो `float scaleX` और `float scaleY` पैरामीटर लेता है ताकि क्षैतिज और लंबवत स्केल फ़ैक्टर सेट किए जा सकें। निम्न उदाहरण एक टेबल बनाता है, पहले सेल में पैराग्राफ को डिफ़ॉल्ट चौड़ाई और ऊँचाई के दो गुना पर रेंडर करता है, और परिणाम को PNG इमेज के रूप में सहेजता है।

```cpp
#include <DOM/IParagraph.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/array.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto scaleX = 2.0f;
auto scaleY = 2.0f;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto table = slide->get_Shapes()->AddTable(50, 50, MakeArray<double>({300}), MakeArray<double>({80}));
auto paragraph = table->idx_get(0, 0)->get_TextFrame()->get_Paragraph(0);
paragraph->set_Text(u"Text in a table cell");

auto paragraphImage = paragraph->GetImage(scaleX, scaleY);
if (paragraphImage != nullptr)
{
    paragraphImage->Save(u"table_paragraph.png", ImageFormat::Png);
    paragraphImage->Dispose();
}
else
{
    Console::WriteLine(u"The paragraph could not be rendered.");
}

presentation->Dispose();
```

`1` का स्केल फ़ैक्टर अक्ष को डिफ़ॉल्ट पिक्सेल आकार पर रखता है। उदाहरण के लिये, दोनों फ़ैक्टर `2` होने पर इमेज की चौड़ाई और ऊँचाई लगभग डिफ़ॉल्ट आयामों के दो गुना हो जाती है, जिससे चार गुना पिक्सल बनते हैं। बड़े फ़ैक्टर ज़ूम या हाई‑रिज़ॉल्यूशन आउटपुट के लिये तेज़ टेक्स्ट देते हैं, पर मेमोरी उपयोग और फ़ाइल आकार बढ़ाते हैं। `1` से छोटे फ़ैक्टर छोटे इमेज कम विवरण के साथ बनाते हैं। समान फ़ैक्टर रखकर पैराग्राफ का अनुपात संरक्षित रहता है; अलग-अलग क्षैतिज और लंबवत फ़ैक्टर आउटपुट को स्वतंत्र रूप से खींचते हैं।

पूरे शेप को [IShape::GetImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/getimage/) से रेंडर करना उपयोगी है जब आउटपुट में शेप का फ़िल, बॉर्डर या अन्य दृश्य संदर्भ शामिल होना चाहिए। केवल पैराग्राफ‑इमेज के लिये, [IParagraph::GetImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraph/getimage/) का उपयोग करें।

## **FAQ**

**क्या मैं टेक्स्ट फ़्रेम के भीतर लाइन रैपिंग को पूरी तरह से निष्क्रिय कर सकता हूँ?**

हां। लाइन रैपिंग को निष्क्रिय करने के लिये [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframeformat/set_wraptext/) का उपयोग करें जिससे पंक्तियों को टेक्स्ट फ़्रेम के किनारों पर नहीं तोड़ना पड़े।

**मैं किसी विशिष्ट पैराग्राफ की स्लाइड पर सटीक सीमाएँ कैसे प्राप्त करूँ?**

पैराग्राफ की बाउंडिंग रेक्टैंगल प्राप्त करने के लिये [IParagraph::GetRect](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraph/getrect/) का उपयोग करें। व्यक्तिगत पोर्शन की सीमाएँ प्राप्त करने के लिये [IPortion::GetRect](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportion/getrect/) उपयोग करें।

**पैराग्राफ संरेखण (बाएँ, दाएँ, केंद्र या जस्टिफ़ाई) कहाँ नियंत्रित होता है?**

[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_alignment/) पैराग्राफ‑स्तर की सेटिंग है और यह पूरी पैराग्राफ पर लागू होती है, चाहे व्यक्तिगत पोर्शन फॉर्मेटिंग कुछ भी हो।

**क्या मैं पैराग्राफ के कुछ हिस्से के लिये प्रूफ़िंग भाषा सेट कर सकता हूँ?**

हां। आप व्यक्तिगत पोर्शन के लिये [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseportionformat/set_languageid/) का उपयोग कर सकते हैं, जिससे एक ही पैराग्राफ में कई भाषाओं का टेक्स्ट रखा जा सकता है।