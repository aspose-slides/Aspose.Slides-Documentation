---
title: C++ में PowerPoint टेक्स्ट पैराग्राफ प्रबंधित करें
linktitle: पैराग्राफ प्रबंधित करें
type: docs
weight: 40
url: /hi/cpp/manage-paragraph/
aliases:
  - /cpp/paragraph/
  - /cpp/portion/
keywords:
- टेक्स्ट जोड़ें
- पैराग्राफ जोड़ें
- टेक्स्ट प्रबंधित करें
- पैराग्राफ प्रबंधित करें
- बुलेट प्रबंधित करें
- पैराग्राफ इंडेंट
- हैंगिंग इंडेंट
- पैराग्राफ बुलेट
- न्यूमेरिक सूची
- बुलेटेड सूची
- पैराग्राफ गुण
- HTML आयात
- टेक्स्ट को HTML में
- पैराग्राफ को HTML में
- पैराग्राफ को इमेज में
- टेक्स्ट को इमेज में
- पैराग्राफ निर्यात
- PowerPoint
- प्रेजेंटेशन
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ पैराग्राफ, पोर्शन, बुलेट, न्यूमेरिक सूचियाँ, इंडेंट, HTML कंटेंट, और पैराग्राफ इमेज बनाना और फ़ॉर्मेट करना सीखें।"
---
## **अवलोकन**

Aspose.Slides for C++ पाठ को टेक्स्ट फ्रेम, पैराग्राफ और पोर्शन की पदानुक्रम के रूप में दर्शाता है:

* [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) आकार में टेक्स्ट कंटेनर को दर्शाता है और इसके पैराग्राफ संग्रह तक पहुंच प्रदान करता है।
* [IParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraph/) एक टेक्स्ट फ्रेम में एक पैराग्राफ का प्रतिनिधित्व करता है और इसके पोर्शन और पैराग्राफ-स्तर फ़ॉर्मेटिंग तक पहुंच प्रदान करता है।
* [IPortion](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportion/) एक पैराग्राफ के भीतर टेक्स्ट रन का प्रतिनिधित्व करता है। प्रत्येक पोर्शन का अपना टेक्स्ट और कैरेक्टर-स्तर फ़ॉर्मेटिंग हो सकता है।

इसलिए एक पैराग्राफ विभिन्न फ़ॉन्ट, रंग, आकार और अन्य फ़ॉर्मेटिंग वाले टेक्स्ट को कई पोर्शन का उपयोग करके रख सकता है।

## **पैराग्राफ बनाएं और फ़ॉर्मेट करें**

### **कई पोर्शन के साथ पैराग्राफ बनाएं**

निम्नलिखित चरण एक टेक्स्ट फ्रेम बनाते हैं जिसमें तीन पैराग्राफ होते हैं, प्रत्येक में तीन पोर्शन होते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
4._shape के [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) तक पहुंचें।
5. डिफ़ॉल्ट पैराग्राफ का उपयोग करें और टेक्स्ट फ्रेम में दो अतिरिक्त [IParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraph/) ऑब्जेक्ट जोड़ें।
6. प्रत्येक पैराग्राफ में तीन पोर्शन रखने के लिए पर्याप्त [IPortion](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportion/) ऑब्जेक्ट जोड़ें। डिफ़ॉल्ट पैराग्राफ में पहले से ही एक खाली पोर्शन होता है।
7. प्रत्येक पोर्शन का टेक्स्ट सेट करें।
8. कैरेक्टर-स्तर फ़ॉर्मेटिंग को [IPortion::get_PortionFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportion/get_portionformat/) के माध्यम से लागू करें।
9. संशोधित प्रस्तुति को सहेजें।

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

## **बुलेटेड और न्यूमेरिक सूचियाँ बनाएं**

### **बुलेटेड या न्यूमेरिक सूची बनाएं**

बुलेट और क्रमांकन संबंधित आइटम को बेहतर ढंग से स्कैन करने में मदद करते हैं। Aspose.Slides में, सूची सेटिंग्स [IBulletFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibulletformat/) के माध्यम से परिभाषित की जाती हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड का संदर्भ प्राप्त करें।
3. चयनित स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
4._shape के [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) तक पहुंचें।
5. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएँ।
6. सिम्बोल बुलेट के लिए एक [Paragraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides/paragraph/) बनाएं।
7. [IBulletFormat::set_Type](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibulletformat/set_type/) को [BulletType::Symbol](https://reference.aspose.com/slides/hi/cpp/aspose.slides/bullettype/) पर सेट करें और बुलेट कैरेक्टर निर्दिष्ट करें।
8. पैराग्राफ टेक्स्ट, इंडेंट, बुलेट रंग और बुलेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. दूसरा पैराग्राफ बनाएँ और [IBulletFormat::set_Type](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibulletformat/set_type/) को [BulletType::Numbered](https://reference.aspose.com/slides/hi/cpp/aspose.slides/bullettype/) पर सेट करें।
11. न्यूमेरिक बुलेट शैली को कॉन्फ़िगर करें और पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
12. प्रस्तुति को सहेजें।

यह C++ उदाहरण सिम्बोल बुलेट और न्यूमेरिक बुलेट बनाता है:

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

### **पिक्चर बुलेट्स का उपयोग करें**

पिक्चर बुलेट्स आपको सिम्बोल या नंबर के बजाय एक कस्टम इमेज उपयोग करने की अनुमति देते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
2. इंडेक्स के माध्यम से संबंधित स्लाइड का संदर्भ प्राप्त करें।
3. एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें और उसके [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) तक पहुंचें।
4. टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. बुलेट इमेज लोड करें और इसे प्रस्तुति की इमेज कलेक्शन में एक [IPPImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ippimage/) के रूप में जोड़ें।
6. एक [Paragraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides/paragraph/) बनाएं और उसका टेक्स्ट सेट करें।
7. [IBulletFormat::set_Type](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibulletformat/set_type/) को [BulletType::Picture](https://reference.aspose.com/slides/hi/cpp/aspose.slides/bullettype/) पर सेट करें।
8. [ISlidesPicture::set_Image](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidespicture/set_image/) के माध्यम से इमेज असाइन करें और बुलेट ऊँचाई सेट करें।
9. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
10. संशोधित प्रस्तुति को सहेजें।

यह C++ उदाहरण पिक्चर बुलेट बनाता है:

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

### **मल्टीलेवल सूची बनाएं**

सूची के विभिन्न स्तरों पर पैराग्राफ रखने के लिए [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_depth/) सेट करें। शीर्ष स्तर का डेप्थ `0` है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) बनाएं और एक स्लाइड तक पहुंचें।
2. एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें और उसके टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएँ।
3. चार पैराग्राफ बनाएं और उनके बुलेट सिम्बॉल कॉन्फ़िगर करें।
4. उनके [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_depth/) मानों को `0`, `1`, `2`, और `3` सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रस्तुति सहेजें।

यह C++ उदाहरण चार-स्तरीय बुलेटेड सूची बनाता है:

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

### **कस्टम मानों पर न्यूमेरिक सूची आइटम शुरू करें**

न्यूमेरिक पैराग्राफ के लिए प्रारंभिक संख्या सेट करने के लिए [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) का उपयोग करें।

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) बनाएं और एक स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
2. शेप के टेक्स्ट फ्रेम से डिफ़ॉल्ट पैराग्राफ हटाएँ।
3. तीन न्यूमेरिक पैराग्राफ बनाएं।
4. प्रत्येक पैराग्राफ के लिए [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) को क्रमशः `2`, `3`, और `7` सेट करें।
5. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें और प्रस्तुति सहेजें।

यह C++ उदाहरण प्रत्येक पैराग्राफ के लिए कस्टम प्रारंभिक संख्या असाइन करता है:

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

## **पैराग्राफ लेआउट और एंड प्रॉपर्टी को नियंत्रित करें**

### **पहली पंक्ति इंडेंट सेट करें**

पहली पंक्ति इंडेंट को नियंत्रित करने के लिए [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_indent/) का उपयोग करें। यह मेथड केवल पैराग्राफ की बायीं मार्जिन के सापेक्ष पहली पंक्ति को ही स्थानांतरित करता है। एक सकारात्मक मान पहली पंक्ति को दाहिनी ओर ले जाता है, जबकि बाकी पंक्तियां पैराग्राफ बॉडी के साथ संरेखित रहती हैं।

यदि आपको पूरी पैराग्राफ को ले जाना है तो [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_marginleft/) का उपयोग करें। केवल पहली पंक्ति को ले जाना हो तो [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_indent/) का उपयोग करें।

नीचे दिया गया उदाहरण कई पैराग्राफ बनाता है और विभिन्न [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_indent/) मान लागू करता है ताकि दिखाया जा सके कि पहली पंक्ति इंडेंट पैराग्राफ लेआउट को कैसे प्रभावित करता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
2. लक्ष्य स्लाइड तक पहुंचें।
3. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
4._shape के [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) तक पहुंचें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. कई पैराग्राफ बनाएं और प्रत्येक के लिए विभिन्न [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_indent/) मान सेट करें।
6. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
7. संशोधित प्रस्तुति को सहेजें।

यह कोड आपको पैराग्राफ इंडेंट सेट करने का तरीका दिखाता है:

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

![पैराग्राफ की पहली पंक्ति इंडेंट](first_line_indent.png)

### **हैंगिंग इंडेंट सेट करें**

हैंगिंग इंडेंट वह पैराग्राफ लेआउट है जिसमें पहली पंक्ति शेष पंक्तियों से बायीं ओर शुरू होती है। Aspose.Slides में, आप इस प्रभाव को [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_indent/) से बना सकते हैं। पहली पंक्ति को पैराग्राफ बॉडी के सापेक्ष बायीं ओर ले जाने के लिए इंडेंट को नकारात्मक मान पर सेट करें।

व्यावहारिक रूप से, [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_marginleft/) पैराग्राफ बॉडी की बायीं स्थिति निर्धारित करता है, और [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_indent/) पहली पंक्ति की स्थिति को उस मार्जिन के सापेक्ष निर्धारित करता है। हैंगिंग इंडेंट बनाने के लिए, सकारात्मक margin-left मान और नकारात्मक इंडेंट मान सेट करें।

यह फ़ॉर्मेटिंग ग्रंथसूची, संदर्भ, शब्दकोश प्रविष्टियों और उन पैराग्राफ़ों के लिए उपयोगी है जहाँ रैप्ड पंक्तियों को पैराग्राफ बॉडी के नीचे संरेखित होना चाहिए न कि पहली पंक्ति के पहले अक्षर के नीचे।

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
2. लक्ष्य स्लाइड तक पहुंचें।
3. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
4._shape के [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) तक पहुंचें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
5. पैराग्राफ बनाएं और प्रत्येक पैराग्राफ के लिए सकारात्मक [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_marginleft/) मान सेट करें।
6. हैंगिंग इंडेंट प्रभाव बनाने के लिए नकारात्मक [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_indent/) मान सेट करें।
7. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
8. संशोधित प्रस्तुति को सहेजें।

यह कोड आपको पैराग्राफ के लिए हैंगिंग इंडेंट सेट करने का तरीका दिखाता है:

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

presentation->Save(u"hhangin_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![पैराग्राफ का हैंगिंग इंडेंट](hanging_indent.png)

### **एंड पैराग्राफ रन प्रॉपर्टी सेट करें**

[IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) पैराग्राफ अंत चिन्ह के फ़ॉर्मेट को नियंत्रित करता है। निम्न उदाहरण दूसरे पैराग्राफ के अंत चिन्ह को फ़ॉन्ट आकार और लैटिन फ़ॉन्ट असाइन करता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) लोड करें और एक स्लाइड तक पहुंचें।
2. एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें और उसका डिफ़ॉल्ट पैराग्राफ साफ़ करें।
3. दो पैराग्राफ बनाएं और उनमें टेक्स्ट पोर्शन जोड़ें।
4. दूसरे पैराग्राफ के अंत चिन्ह के लिए एक [PortionFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/portionformat/) बनाएं।
5. [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseportionformat/set_fontheight/) और [IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseportionformat/set_latinfont/) सेट करें।
6. फ़ॉर्मेट को [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) से असाइन करें और प्रस्तुति सहेजें।

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

## **रेन्डर की गई लाइनों की गिनती**

[IParagraph::GetLinesCount](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraph/getlinescount/) का उपयोग करके आप पैराग्राफ के टेक्स्ट लेआउट के बाद निकली लाइनों की संख्या गिन सकते हैं, जिसमें स्वचालित रैपिंग शामिल है। यह प्रस्तुति टेम्पलेट में टेक्स्ट की लंबाई और लेआउट जांचने में उपयोगी है।

एक पैराग्राफ [ITextFrame::get_Paragraphs](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/get_paragraphs/) में एक आइटम है, और यह कई रेंडर की गई लाइनों को घेर सकता है। पैराग्राफ के भीतर स्पष्ट लाइन ब्रेक नई लाइन बनाता है बिना नया पैराग्राफ बनाए। स्वचालित रैपिंग उपलब्ध चौड़ाई के आधार पर लाइनों को बनाता है बिना टेक्स्ट में स्पष्ट ब्रेक डाले। इसलिए पैराग्राफ की गिनती या लाइन‑ब्रेक कैरेक्टर रेंडर की गई लाइन गिनती नहीं देते।

निम्न उदाहरण एक टेक्स्ट शैप बनाता है, उसकी लाइनों की गिनती करता है, शैप को संकुचित करता है, फिर टेक्स्ट को छोटे स्ट्रिंग से बदलता है। रैपिंग सक्षम है और ऑटो‑फिट निष्क्रिय है ताकि शैप की चौड़ाई रैपिंग को नियंत्रित करे और टेक्स्ट या शैप को स्वतः छोटा न हो। शैप आयाम पॉइंट में होते हैं। अंत में उदाहरण एक और पैराग्राफ जोड़ता है और टेक्स्ट फ्रेम में कुल लाइन गिनती करता है।

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::True);
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);

auto paragraph = textFrame->get_Paragraph(0);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20);
paragraph->set_Text(u"This text demonstrates how automatic wrapping changes the number of rendered lines.");
Console::WriteLine(u"Original width: {0}", paragraph->GetLinesCount());

shape->set_Width(150);
Console::WriteLine(u"Narrower shape: {0}", paragraph->GetLinesCount());

paragraph->set_Text(u"Short text.");
Console::WriteLine(u"Shorter text: {0}", paragraph->GetLinesCount());

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Another paragraph.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20);
textFrame->get_Paragraphs()->Add(secondParagraph);

auto totalLineCount = 0;
for (auto currentParagraph : textFrame->get_Paragraphs())
{
    totalLineCount += currentParagraph->GetLinesCount();
}
Console::WriteLine(u"Total lines in the text frame: {0}", totalLineCount);
presentation->Dispose();
```

इन टेक्स्ट और आयामों के साथ, शैप को संकरी करने से लाइन गिनती बढ़ती है, जबकि छोटा स्ट्रिंग रखने से घटती है। सटीक गिनती फ़ॉन्ट उपलब्धता, फ़ॉन्ट आकार, मार्जिन, इंडेंट, रैपिंग और ऑटो‑फिट सेटिंग्स पर निर्भर करती है। टेम्पलेट जांचते समय लक्ष्य परिवेश के फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

सिर्फ लाइन गिनती यह निर्धारित नहीं करती कि टेक्स्ट कंटेनर से बाहर निकलेगा या नहीं। उपलब्ध ऊँचाई, लाइन ऊँचाई, पैराग्राफ और लाइन स्पेसिंग, तथा ऑटो‑फिट व्यवहार भी महत्वपूर्ण हैं; यहाँ तक कि एक ही लाइन भी जब रैपिंग निष्क्रिय होती है तो उपलब्ध चौड़ाई से अधिक हो सकती है।

## **पैराग्राफ कंटेंट आयात और निर्यात**

### **HTML टेक्स्ट को पैराग्राफ में आयात करें**

[ IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphcollection/addfromhtml/) का उपयोग करके HTML मार्कअप को टेक्स्ट फ्रेम में पैराग्राफ और पोर्शन में परिवर्तित किया जा सकता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
2. एक स्लाइड तक पहुंचें और एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
3._shape के [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) तक पहुंचें और डिफ़ॉल्ट पैराग्राफ हटाएँ।
4. स्रोत HTML फ़ाइल पढ़ें।
5. HTML स्ट्रिंग को [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphcollection/addfromhtml/) में पास करें।
6. संशोधित प्रस्तुति को सहेजें।

यह C++ उदाहरण HTML को टेक्स्ट फ्रेम में आयात करता है:

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

### **पैराग्राफ टेक्स्ट को HTML में एक्सपोर्ट करें**

[IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphcollection/exporttohtml/) का उपयोग करके चयनित पैराग्राफ रेंज को HTML के रूप में एक्सपोर्ट किया जा सकता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का उदाहरण बनाएं और वांछित प्रस्तुति लोड करें।
2. स्लाइड तक पहुंचें और वह [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) ढूंढें जिसमें टेक्स्ट है।
3._shape के [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) तक पहुंचें।
4. शुरूआती पैराग्राफ इंडेक्स और एक्सपोर्ट करने वाले पैराग्राफ की संख्या के साथ [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphcollection/exporttohtml/) को कॉल करें।
5. प्राप्त HTML स्ट्रिंग को फ़ाइल में लिखें।

यह C++ उदाहरण पहले टेक्स्ट शैप के सभी पैराग्राफ को एक्सपोर्ट करता है:

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

### **पैराग्राफ को इमेज के रूप में रेंडर करें**

[IParagraph::GetImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraph/getimage/) व्यक्तिगत पैराग्राफ को सीधे रेंडर करता है और एक [IImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimage/) लौटाता है। परिणाम को फ़ाइल या स्ट्रीम में [IImage::Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimage/save/) से सहेजा जा सकता है। आपको कंटेनिंग शैप को रेंडर करने या बिटमैप को मैन्युअली क्रॉप करने की आवश्यकता नहीं है।

[IParagraph::GetImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraph/getimage/) `nullptr` लौटा सकता है यदि पैराग्राफ पैरेंट कलेक्शन में नहीं मिला, वैध रेंडरिंग बाउंड्स नहीं हैं, या रेंडर नहीं किया जा सका। सहेजने से पहले परिणाम जांचें और उपयोग के बाद लौटाए गए इमेज को डिस्पोज़ करें।

#### **डिफ़ॉल्ट स्केल पर पैराग्राफ रेंडर करें**

मान लें कि हमारे पास `sample.pptx` नामक एक प्रस्तुति फ़ाइल है जिसमें एक स्लाइड है, जहाँ पहला शैप तीन पैराग्राफ वाला टेक्स्ट बॉक्स है।

![तीन पैराग्राफ वाला टेक्स्ट बॉक्स](paragraph_to_image_input.png)

निम्न उदाहरण दूसरे पैराग्राफ को नियमित टेक्स्ट शैप में डिफ़ॉल्ट स्केल पर रेंडर करता है और PNG फ़ॉर्मेट में इमेज सहेजता है।

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

#### **टेबल सेल में पैराग्राफ रेंडर करें स्केलिंग के साथ**

`float scaleX` और `float scaleY` पैरामीटर स्वीकार करने वाले [IParagraph::GetImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraph/getimage/) ओवरलोड का उपयोग करके क्षैतिज और ऊर्ध्वाधर स्केल फैक्टर सेट किया जा सकता है। निम्न उदाहरण एक टेबल बनाता है, पहले सेल में पैराग्राफ को डिफ़ॉल्ट चौड़ाई और ऊँचाई से दो गुना करके रेंडर करता है, और परिणाम PNG इमेज के रूप में सहेजता है।

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

`1` का स्केल फैक्टर उस अक्ष को उसकी डिफ़ॉल्ट पिक्सेल साइज पर रखता है। उदाहरण के लिए, दोनों फैक्टर के लिए `2` सेट करने से इमेज की चौड़ाई और ऊँचाई लगभग दो गुना हो जाती है, जिससे चार गुना अधिक पिक्सेल बनते हैं। बड़े फैक्टर ज़ूम या हाई‑रेज़ोल्यूशन आउटपुट के लिए तेज़ टेक्स्ट देते हैं, लेकिन मेमोरी उपयोग और फ़ाइल आकार बढ़ाते हैं। `1` से कम फैक्टर छोटे इमेज बनाते हैं जिनमें कम विवरण होता है। समान फैक्टर उपयोग करने से पैराग्राफ का आस्पेक्ट रेशियो बना रहता है; अलग-अलग क्षैतिज और ऊर्ध्वाधर फैक्टर आउटपुट को स्वतंत्र रूप से खींचते हैं।

पूरा शैप **IShape::GetImage** के साथ रेंडर करना उपयोगी रहता है जब आउटपुट में शैप का फ़िल, बॉर्डर या अन्य दृश्य संदर्भ शामिल होना चाहिए। केवल पैराग्राफ‑केवल इमेज के लिए **IParagraph::GetImage** का उपयोग करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं टेक्स्ट फ्रेम के भीतर लाइन रैपिंग को पूरी तरह निष्क्रिय कर सकता हूँ?**

हाँ। लाइन रैपिंग निष्क्रिय करने के लिए [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframeformat/set_wraptext/) का प्रयोग करें ताकि लाइन्स टेक्स्ट फ्रेम के किनारों पर न टूटें।

**मैं एक विशिष्ट पैराग्राफ की ऑन‑स्लाइड बाउंड्स कैसे प्राप्त करूँ?**

पैराग्राफ की बाउंडिंग रेक्टैंगल प्राप्त करने के लिए [IParagraph::GetRect](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraph/getrect/) का उपयोग करें। व्यक्तिगत पोर्शन के बाउंड्स के लिए [IPortion::GetRect](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportion/getrect/) प्रदान करता है।

**पैराग्राफ अलाइनमेंट (बाएँ, दाएँ, केंद्र या जस्टिफ़ाई) कहाँ नियंत्रित होता है?**

[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_alignment/) एक पैराग्राफ‑स्तर की सेटिंग है और यह पूरी पैराग्राफ पर लागू होती है, चाहे व्यक्तिगत पोर्शन के फ़ॉर्मेटिंग कुछ भी हों।

**क्या मैं पैराग्राफ के कुछ हिस्से के लिए प्रूफ़िंग भाषा सेट कर सकता हूँ?**

हाँ। व्यक्तिगत पोर्शन के लिए [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseportionformat/set_languageid/) का उपयोग करें, जिससे एक ही पैराग्राफ में कई भाषाओं का टेक्स्ट हो सकता है।