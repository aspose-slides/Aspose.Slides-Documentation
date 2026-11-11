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
- क्रमांकित सूची
- बुलेटेड सूची
- पैराग्राफ गुण
- HTML आयात
- टेक्स्ट को HTML में
- पैराग्राफ को HTML में
- पैराग्राफ को इमेज में
- टेक्स्ट को इमेज में
- पैराग्राफ निर्यात करें
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ पैराग्राफ, भाग, बुलेट, क्रमांकित सूचियाँ, इंडेंट, HTML सामग्री, और पैराग्राफ इमेजेज बनाना और स्वरूपित करना सीखें।"
---
## **अवलोकन**

Aspose.Slides for C++ टेक्स्ट को टेक्स्ट फ्रेम, पैराग्राफ और भागों की पदानुक्रम में दर्शाता है:

* [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) आकार में टेक्स्ट कंटेनर को दर्शाता है और इसके पैराग्राफ संग्रह तक पहुँच प्रदान करता है।
* [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) एक टेक्स्ट फ्रेम में एक पैराग्राफ को दर्शाता है और इसके भागों तथा पैराग्राफ‑स्तर फ़ॉर्मेटिंग तक पहुँच प्रदान करता है।
* [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) एक पैराग्राफ के भीतर टेक्स्ट रन को दर्शाता है। प्रत्येक भाग अपना स्वयं का टेक्स्ट और अक्षर‑स्तर फ़ॉर्मेटिंग रख सकता है।

इस प्रकार एक पैराग्राफ कई भागों का उपयोग करके विभिन्न फ़ॉन्ट, रंग, आकार और अन्य फ़ॉर्मेटिंग वाले टेक्स्ट को समेट सकता है।

## **पैराग्राफ बनाना और स्वरूपित करना**

आकार के टेक्स्ट फ्रेम में पैराग्राफ बनाएं और भागों का उपयोग करके व्यक्तिगत टेक्स्ट रन को स्वरूपित करें। यह अनुभाग प्रत्येक पैराग्राफ के भीतर कई भागों को मिलाकर विभिन्न रंग, फ़ॉन्ट आकार और शैली लागू करने का तरीका दिखाता है।

### **कई भागों के साथ पैराग्राफ बनाना**

निम्नलिखित C++ उदाहरण तीन पैराग्राफ बनाता है, जिनमें प्रत्येक में उसके [IParagraph::get_Portions](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/get_portions/) संग्रह में तीन टेक्स्ट रन होते हैं। यह डिफ़ॉल्ट पैराग्राफ और उसके खाली भाग को पुन: उपयोग करता है, फिर शेष पैराग्राफ और भाग जोड़ता है। फ़ॉर्मेटिंग [IPortion::get_PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/get_portionformat/) के माध्यम से लागू की जाती है: प्रत्येक पैराग्राफ का पहला भाग लाल, बोल्ड और 15 पॉइंट है; दूसरा नीला, इटैलिक और 18 पॉइंट है। तीसरा भाग अपनी डिफ़ॉल्ट फ़ॉर्मेटिंग बनाए रखता है:

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
for (auto paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = textFrame->get_Paragraph(paragraphIndex);
    auto portionCount = paragraph->get_Portions()->get_Count();
    for (auto portionIndex = 0; portionIndex < portionCount; portionIndex++)
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

पैराग्राफ टेक्स्ट को प्रतीकों, संख्याओं या कस्टम छवियों के साथ सूचियों में व्यवस्थित करें। इस अनुभाग में बुलेट फ़ॉर्मेटिंग, बहु‑स्तरीय सूचियों और कस्टम प्रारम्भिक संख्याओं के उदाहरण शामिल हैं।

### **बुलेटेड या क्रमांकित सूची बनाना**

बुलेट और क्रमांकन संबंधित आइटमों को स्कैन करना आसान बनाते हैं। Aspose.Slides में सूची सेटिंग्स को [IBulletFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/) के माध्यम से परिभाषित किया जाता है।

यह C++ उदाहरण एक प्रतीक बुलेट और एक क्रमांकित आइटम को एक ही टेक्स्ट फ्रेम में जोड़ता है। [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) बुलेट प्रकार चुनता है, जबकि [IBulletFormat::set_Char](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_char/) प्रतीक प्रदान करता है और [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) क्रमांक शैली चुनता है। दोनों आइटम काली बुलेट्स का उपयोग 100 % ऊँचाई और 25 पॉइंट पैराग्राफ इंडेंट के साथ करते हैं:

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

### **चित्र बुलेट्स का उपयोग करें**

चित्र बुलेट्स आपको प्रतीक या संख्या के बजाय कस्टम छवि का उपयोग करने की अनुमति देते हैं।

उदाहरण को कार्यशील निर्देशिका में `bullets.png` चाहिए। यह C++ उदाहरण प्रस्तुति की इमेज कलेक्शन में एक छवि को [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) के रूप में जोड़ता है और इसे पैराग्राफ बुलेट के रूप में उपयोग करता है। यह [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) को चित्र बुलेट उपयोग करने के लिए सेट करता है और छवि को [IBulletFormat::get_Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/get_picture/) के माध्यम से असाइन करता है। बुलेट के आकार को पैराग्राफ टेक्स्ट के सापेक्ष रखने हेतु [IBulletFormat::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_height/) को 100 % पर सेट किया जाता है:

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

[IParagraphFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_depth/) को सेट करके पैराग्राफ को सूची की विभिन्न स्तरों पर रखा जाता है। शीर्ष स्तर की गहराई `0` है।

यह C++ उदाहरण चार पैराग्राफ को 0 से 3 तक के [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_depth/) मान देता है, जिससे एक ही टेक्स्ट फ्रेम में पदानुक्रम बनता है। प्रत्येक पैराग्राफ एक प्रतीक बुलेट का उपयोग करता है, जहाँ [IBulletFormat::set_Char](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_char/) गोल बुलेट और हाइफ़न के बीच बदलता रहता है ताकि क्रमागत स्तरों को अलग किया जा सके:

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

### **कस्टम मानों से क्रमांकित सूची आइटम शुरू करें**

क्रमांकित पैराग्राफ के लिए प्रारम्भिक संख्या सेट करने के लिये [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) का उपयोग करें।

यह C++ उदाहरण तीन पैराग्राफ के लिये क्रमांकन उपयोग करने हेतु [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) सेट करता है और क्रमागत प्रारम्भिक मान 2, 3 और 7 को [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) से असाइन करता है। प्रत्येक पैराग्राफ के लिये प्रारम्भिक मान अलग‑अलग कॉन्फ़िगर किया जाता है, जिससे प्रदर्शित संख्याएँ मानों को छोड़ सकती हैं:

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

## **पैराग्राफ लेआउट और अंत गुण नियंत्रित करना**

पहली पंक्ति और रैप्ड पंक्तियों की स्थिति को नियंत्रित करने हेतु पैराग्राफ मार्जिन और इंडेंट को समायोजित करें। आप दृश्यमान टेक्स्ट भागों से अलग पैराग्राफ अंत चिह्न को भी स्वरूपित कर सकते हैं।

### **पहली पंक्ति का इंडेंट सेट करें**

पहली‑पंक्ति इंडेंट को नियंत्रित करने के लिये [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) मेथड का उपयोग करें। यह मेथड केवल पैराग्राफ के बाएँ मार्जिन के सापेक्ष पहली पंक्ति को ही ले जाता है। सकारात्मक मान पहली पंक्ति को दाएँ शिफ्ट करता है, जबकि शेष पंक्तियाँ पैराग्राफ बॉडी के साथ संरेखित रहती हैं।

पूरा पैराग्राफ ले जाने की आवश्यकता होने पर [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/) का उपयोग करें। केवल पहली पंक्ति ले जाने की आवश्यकता होने पर [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) का उपयोग करें।

निम्न उदाहरण तीन पैराग्राफ को समान [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/) 20 पॉइंट और [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) 0, 20 और 40 पॉइंट देता है। पहली पंक्तियाँ क्रमशः बड़े ऑफ़सेट पर शुरू होती हैं, जबकि रैप्ड पंक्तियाँ समान बाएँ मार्जिन बनाए रखती हैं:

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

![पैराग्राफों की पहली पंक्ति का इंडेंट](first_line_indent.png)

### **हैंगिंग इंडेंट सेट करें**

हैंगिंग इंडेंट वह पैराग्राफ लेआउट है जिसमें पहली पंक्ति शेष पंक्तियों से बाएँ शुरू होती है। Aspose.Slides में इसे आप [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) मेथड से बना सकते हैं। बाएँ शिफ्ट करने हेतु नकारात्मक मान पास करें।

व्यावहारिक रूप से, [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/) पैराग्राफ बॉडी की बाएँ स्थिति निर्धारित करता है, और [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) उस मार्जिन के सापेक्ष पहली पंक्ति की स्थिति निर्धारित करता है। हैंगिंग इंडेंट बनाने के लिये एक सकारात्मक `MarginLeft` मान और एक नकारात्मक `Indent` मान सेट करें।

यह फ़ॉर्मेटिंग ग्रंथसूची, संदर्भ, शब्दकोश प्रविष्टियों और अन्य पैराग्राफ़ों में उपयोगी होती है जहाँ रैप्ड पंक्तियों को पैराग्राफ बॉडी के नीचे संरेखित रखना आवश्यक होता है, न कि पहली पंक्ति के पहले अक्षर के नीचे।

निम्न C++ उदाहरण [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/) 40 और 60 पॉइंट मान को [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) -20 और -30 पॉइंट मानों के साथ जोड़ता है। प्रत्येक पैराग्राफ में पहली पंक्ति रैप्ड पंक्तियों से बाएँ शुरू होती है; द्वितीय पैराग्राफ में गहरा हैंगिंग इंडेंट होता है:

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

presentation->Save(u"hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![पैराग्राफों का हैंगिंग इंडेंट](hanging_indent.png)

### **परिच्छेद अंत रन गुण सेट करें**

[IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) मेथड पैराग्राफ अंत चिह्न के फ़ॉर्मेट को नियंत्रित करता है। उदाहरण `Test.pptx` लोड करता है, जिसमें कम से कम एक स्लाइड होनी चाहिए। निम्न उदाहरण एक [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/) बनाता है जिसमें [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_fontheight/) 48 पॉइंट और [IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_latinfont/) Times New Roman पर सेट है। यह फ़ॉर्मेट दूसरे पैराग्राफ के अंत चिह्न को असाइन करता है, जबकि दृश्यमान टेक्स्ट भाग अपरिवर्तित रहता है:

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

## **रेंडर की गई पंक्तियों की गिनती**

उन पैराग्राफ नियमों के लिये जो स्वतः रैपिंग और लाइन समाप्ति पर विराम चिह्न को प्रभावित करते हैं, देखें [Control Line Breaking](/slides/hi/cpp/text-formatting/#control-line-breaking) और [Control Hanging Punctuation](/slides/hi/cpp/text-formatting/#control-hanging-punctuation)।

[IParagraph::GetLinesCount](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getlinescount/) का उपयोग करके पैराग्राफ के टेक्स्ट लेआउट के बाद वह कितनी पंक्तियों में फैला है, इसे गिन सकते हैं, जिसमें स्वचालित रैपिंग भी शामिल है। यह प्रस्तुति टेम्पलेट में टेक्स्ट की लंबाई और लेआउट की जाँच में उपयोगी है।

[ITextFrame::get_Paragraphs](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_paragraphs/) में पैराग्राफ एक वस्तु है, और वह कई रेंडर की गई पंक्तियों को ले सकता है। पैराग्राफ के भीतर स्पष्ट लाइन ब्रेक नई पंक्ति बनाता है बिना नया पैराग्राफ बनाए। स्वचालित रैपिंग उपलब्ध चौड़ाई के आधार पर पंक्तियाँ बनाता है, बिना टेक्स्ट में स्पष्ट लाइन‑ब्रेक डालते। इसलिए पैराग्राफ या लाइन‑ब्रेक अक्षरों की गिनती करने से रेंडर की गई पंक्तियों की गिनती नहीं मिलती।

निम्न उदाहरण एक टेक्स्ट शैप बनाता है, उसकी पंक्तियों की गिनती करता है, शैप को संकरी करता है, और फिर टेक्स्ट को छोटे स्ट्रिंग से बदलता है। उदाहरण [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_wraptext/) को सक्षम करता है और [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) को निष्क्रिय करता है ताकि शैप की चौड़ाई रैपिंग को नियंत्रित करे, बिना टेक्स्ट को स्वतः छोटा किए या शैप को रिसाइज़ किए। प्रत्येक माप [IParagraph::GetLinesCount](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getlinescount/) से किया जाता है। शैप आयाम पॉइंट में होते हैं। अंत में, उदाहरण एक और पैराग्राफ जोड़ता है और टेक्स्ट फ्रेम की कुल पंक्तियों की गिनती करता है:

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

इन टेक्स्ट और आयामों के साथ, शैप को संकरी करने से पंक्तियों की संख्या बढ़ती है, जबकि छोटे स्ट्रिंग से बदलने पर घटती है। सटीक संख्या फ़ॉन्ट उपलब्धता, प्रतिस्थापन, फ़ॉन्ट आकार, मार्जिन, इंडेंटेशन, रैपिंग और ऑटोफिट सेटिंग्स पर निर्भर करती है। टेम्पलेट की जाँच करते समय लक्ष्य वातावरण के लिये नियत फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

केवल पंक्तियों की गिनती यह निर्धारित नहीं करती कि टेक्स्ट अपने कंटेनर से बाहर निकलता है या नहीं। उपलब्ध ऊँचाई, पंक्ति ऊँचाई, पैराग्राफ और पंक्ति स्पेसिंग, तथा ऑटोफिट व्यवहार भी महत्वपूर्ण होते हैं; यहाँ तक कि एक पंक्ति भी रैपिंग निष्क्रिय होने पर उपलब्ध चौड़ाई से अधिक हो सकती है।

## **पैराग्राफ सामग्री आयात और निर्यात**

HTML का उपयोग करके टेक्स्ट को प्रस्तुति में लाएँ या मौजूदा पैराग्राफ को बाहर उपयोग के लिये निर्यात करें। यह अनुभाग यह भी दर्शाता है कि व्यक्तिगत पैराग्राफ को छवि के रूप में कैसे रेंडर करें, जिसमें टेबल सेल में पैराग्राफ भी शामिल हैं।

### **HTML टेक्स्ट को पैराग्राफ में आयात करें**

[ParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/addfromhtml/) का उपयोग करके HTML मार्कअप को टेक्स्ट फ्रेम में पैराग्राफ और भागों में परिवर्तित करें।

यह C++ उदाहरण फ़ाइल से HTML पढ़ता है और मार्कअप को [ParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/addfromhtml/) को पास करता है। यह टेक्स्ट फ्रेम के डिफ़ॉल्ट पैराग्राफ को साफ़ करता है ताकि फ्रेम केवल आयातित सामग्री रखे। आयताकार शैप स्लाइड के प्रत्येक किनारे पर 10‑पॉइंट मार्जिन छोड़ता है:

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

[ParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/exporttohtml/) का उपयोग करके चयनित पैराग्राफ रेंज को HTML के रूप में निर्यात करें। जब प्रस्तुति टेक्स्ट को वेबसाइट पर पुन: उपयोग करते हैं, तो आप स्थानीय इम्फेसिस को फ़ॉन्ट, आकार या टेक्स्ट बॉक्स शैली को ले जाए बिना संरक्षित रखना चाह सकते हैं। निर्यातकर्ता के फ़ॉर्मेटिंग इनहेरिटेंस के अनुसरण को नियंत्रित करने के लिये [TextToHtmlConversionOptions::set_TextInheritanceLimit](https://reference.aspose.com/slides/cpp/aspose.slides.export/texttohtmlconversionoptions/set_textinheritancelimit/) सेट करें।

[text-inheritance.pptx](text-inheritance.pptx) को डाउनलोड करके एप्लिकेशन की कार्यशील निर्देशिका में रखें। इसकी पहली स्लाइड में एक टेक्स्ट शैप है जिसमें टेक्स्ट “Inherited text; explicit red 18pt” है। इनपुट जानबूझकर कई फ़ॉर्मेटिंग स्तरों का उपयोग करता है:

- प्रस्तुति की डिफ़ॉल्ट टेक्स्ट शैली Calibri और 28 pt आकार प्रदान करती है।
- टेक्स्ट फ्रेम की प्रथम‑स्तर टेक्स्ट शैली नीला टेक्स्ट और इटैलिक प्रदान करती है।
- पैराग्राफ स्पष्ट रूप से बोल्ड टेक्स्ट सेट करता है।
- दूसरा भाग, “explicit red 18pt”, स्पष्ट रूप से लाल टेक्स्ट और 18 pt आकार सेट करता है।

निम्न उदाहरण वही पैराग्राफ तीन बार निर्यात करता है। यह निर्यात मेथड को [TextToHtmlConversionOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/texttohtmlconversionoptions/) पास करता है और प्रत्येक परिणाम को अलग‑अलग UTF‑8 HTML फ़ाइल के रूप में लिखता है:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Presentation.h>
#include <Export/TextInheritanceLimit.h>
#include <Export/TextToHtmlConversionOptions.h>
#include <system/array.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;
using namespace System::Text;

auto presentation = MakeObject<Presentation>(u"text-inheritance.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr)
{
    auto paragraphs = textShape->get_TextFrame()->get_Paragraphs();
    auto modes = MakeArray<TextInheritanceLimit>({TextInheritanceLimit::All, TextInheritanceLimit::TextBox, TextInheritanceLimit::ParagraphOnly});
    auto fileNames = MakeArray<String>({u"All.html", u"TextBox.html", u"ParagraphOnly.html"});

    for (auto i = 0; i < modes->get_Length(); i++)
    {
        auto options = MakeObject<TextToHtmlConversionOptions>();
        options->set_TextInheritanceLimit(modes[i]);

        auto html = paragraphs->ExportToHtml(0, paragraphs->get_Count(), options);
        File::WriteAllText(fileNames[i], html, Encoding::get_UTF8());
    }
}
else
{
    Console::WriteLine(u"The first shape is not a text shape.");
}

presentation->Dispose();
```

निर्मित HTML में प्रथम भाग, “Inherited text; ” के लिये निम्न CSS शामिल है। तालिका संबंधित घोषणा सूचीबद्ध करती है; अन्य उत्पन्न गुण स्पष्टता हेतु छोड़े गए हैं।

| आउटपुट | पहले भाग के लिए संबंधित CSS | दिखावट |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | नीला, बोल्ड, इटैलिक टेक्स्ट 28 pt में Calibri, यदि वह फ़ॉन्ट उपलब्ध है। |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | नीला, बोल्ड, इटैलिक टेक्स्ट; आसपास का पेज या ब्राउज़र फ़ॉन्ट परिवार और आकार प्रदान करता है। |
| `ParagraphOnly.html` | `font-weight:bold` | बोल्ड टेक्स्ट; आसपास का पेज या ब्राउज़र फ़ॉन्ट परिवार, आकार, रंग और इटैलिक शैली प्रदान करता है। |

दूसरा भाग सभी तीन आउटपुट में `color:#ff0000`, `font-size:18pt` और `font-weight:bold` को बरकरार रखता है। यह `All` और `TextBox` में इटैलिक भी रखता है, लेकिन `ParagraphOnly` में नहीं। इसलिए इनहेरिटेंस प्रतिबंध पैराग्राफ या भाग को स्पष्ट रूप से असाइन किए गए फ़ॉर्मेट को नहीं हटाता।

फ़ाइलों को एक ही ब्राउज़र में खोलकर तुलना करें। दो प्रतिबंधित मोड में, छोड़ी गई CSS प्रॉपर्टीज़ गंतव्य पेज की शैलियों या ब्राउज़र डिफ़ॉल्ट से हल होती हैं, इसलिए अंतिम दिखावट इस पर निर्भर करती है कि HTML कहाँ उपयोग किया जाता है।

### **HTML क्लिपबोर्ड फ्रैगमेंट उत्पन्न करें**

सामान्य HTML के लिये [TextToHtmlConversionOptions::set_AddClipboardFragmentHeader](https://reference.aspose.com/slides/cpp/aspose.slides.export/texttohtmlconversionoptions/set_addclipboardfragmentheader/) को `false` और क्लिपबोर्ड हेडर शामिल करने के लिये `true` सेट करें। हेडर आसपास के HTML (`StartHTML` और `EndHTML`) और पेस्ट करने योग्य फ़्रैगमेंट (`StartFragment` और `EndFragment`) के UTF‑8 बाइट ऑफ़सेट देता है।

यह उदाहरण दो स्वरूपित पैराग्राफ को सामान्य HTML (`html`) और HTML क्लिपबोर्ड फ्रैगमेंट (`clipboardHtml`) के रूप में निर्यात करता है। फ्रैगमेंट को सिस्टम क्लिपबोर्ड में लिखना एक अलग एप्लिकेशन कदम है। वह क्लिपबोर्ड API जो कच्चा HTML क्लिपबोर्ड बाइट्स स्वीकार करता है, उसे BOM‑रहित UTF‑8 चाहिए।

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/TextToHtmlConversionOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 400, 100);
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();
paragraphs->Clear();
paragraphs->AddFromHtml(u"<p>Status: <b>Ready</b></p><p><i>Next steps</i></p>");

auto options = MakeObject<TextToHtmlConversionOptions>();
options->set_AddClipboardFragmentHeader(false);
auto html = paragraphs->ExportToHtml(0, paragraphs->get_Count(), options);

options->set_AddClipboardFragmentHeader(true);
auto clipboardHtml = paragraphs->ExportToHtml(0, paragraphs->get_Count(), options);
presentation->Dispose();
```

### **पैराग्राफ को इमेज के रूप में रेंडर करें**

[IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/) एकल पैराग्राफ को सीधे रेंडर करता है और एक [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/) लौटाता है। परिणाम को फ़ाइल या स्ट्रीम में [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) से सहेजें। आपको कंटेनिंग शैप को रेंडर करने या बिटमैप को मैन्युअल रूप से क्रॉप करने की आवश्यकता नहीं है।

यदि पैराग्राफ पैरेंट संग्रह में नहीं मिला, वैध रेंडरिंग बॉन्ड नहीं है या रेंडर नहीं हो सकता तो [IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/) `nullptr` लौटा सकता है। सहेजने से पहले परिणाम की जाँच करें और उपयोग के बाद लौटाई गई इमेज को डिस्पोज़ करें।

#### **डिफ़ॉल्ट स्केल पर पैराग्राफ रेंडर करें**

उदाहरण `sample.pptx` का उपयोग करता है, जिसमें एक स्लाइड है और उसकी पहली शैप एक टेक्स्ट बॉक्स है जिसमें तीन पैराग्राफ हैं।

![तीन पैराग्राफ वाला टेक्स्ट बॉक्स](paragraph_to_image_input.png)

निम्न उदाहरण इंडेक्स 1 पर दूसरे पैराग्राफ को चुनता है और स्केल पैरामीटर के बिना [IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/) को कॉल करता है। यह जाँचता है कि शैप आवश्यक पैराग्राफ रखता है और रेंडरिंग इमेज लौटाती है, फिर [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) से PNG प्रारूप में सहेजता है। उदाहरण इमेज को सहेजने के बाद डिस्पोज़ करता है।

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

#### **टेबल सेल में पैराग्राफ को स्केलिंग के साथ रेंडर करें**

[IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/) के ओवरलोड का उपयोग करें जो `float scaleX` और `float scaleY` पैरामीटर स्वीकार करता है ताकि क्षैतिज और लंबवत स्केल फैक्टर सेट हों। निम्न उदाहरण एक टेबल बनाता है, पैराग्राफ को उसकी पहली सेल में डिफ़ॉल्ट चौड़ाई और ऊँचाई के दो गुना पर रेंडर करता है, और परिणाम को PNG इमेज के रूप में सहेजता है।

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

`1` का स्केल फैक्टर उस अक्ष को इसका डिफ़ॉल्ट पिक्सेल आकार रखता है। उदाहरण के लिये, दोनों फैक्टर के लिये `2` सेट करने से इमेज की चौड़ाई और ऊँचाई लगभग डिफ़ॉल्ट आयामों के दो गुना हो जाती है, जिससे चार गुना पिक्सेल बनते हैं। बड़े फैक्टर आमतौर पर ज़ूम या हाई‑रिज़ॉल्यूशन आउटपुट हेतु तेज़ टेक्स्ट देते हैं, परन्तु मेमोरी उपयोग और फ़ाइल आकार भी बढ़ाते हैं। `1` से नीचे के फैक्टर छोटे इमेज कम विवरण के साथ बनाते हैं। समान फैक्टर उपयोग करके पैराग्राफ का अनुपात बनायीँ रखें; विभिन्न क्षैतिज और लंबवत फैक्टर आउटपुट को स्वतंत्र रूप से खींचते हैं।

जब आउटपुट को शैप के फ़िल, बॉर्डर या अन्य दृश्य संदर्भ सहित चाहिए, तब [IShape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getimage/) से पूरे शैप को रेंडर करना उपयोगी रहता है। केवल पैराग्राफ‑इमेज के लिये, [IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/) का उपयोग करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं टेक्स्ट फ्रेम के अंदर लाइन रैपिंग को पूरी तरह अक्षम कर सकता हूँ?**

हाँ। लाइन ब्रेकेज को अक्षम करने के लिये [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_wraptext/) का उपयोग करें, जिससे पंक्तियाँ टेक्स्ट फ्रेम के किनारों पर नहीं टूटेंगी।

**मैं किसी विशिष्ट पैराग्राफ की स्लाइड पर सटीक सीमाएं कैसे प्राप्त कर सकता हूँ?**

पैराग्राफ की बाउंडिंग आयत प्राप्त करने के लिये [IParagraph::GetRect](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getrect/) का उपयोग करें। व्यक्तिगत भाग की सीमाएं प्राप्त करने के लिये [IPortion::GetRect](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/getrect/) उपयोग करें।

**पैराग्राफ संरेखण (बाएँ, दाएँ, केंद्र, या जस्टिफाई) कहाँ नियंत्रित होता है?**

[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) पैराग्राफ‑स्तर की सेटिंग है और व्यक्तिगत भाग के फ़ॉर्मेटिंग से अलग होकर पूरे पैराग्राफ पर लागू होती है।

एक पंक्ति में विभिन्न फ़ॉन्ट आकारों के भागों को लंबवत संरेखित करने के लिये देखें [एक पंक्ति में फ़ॉन्ट संरेखित करना](/slides/hi/cpp/text-formatting/#align-fonts-within-a-line)।

**क्या मैं पैराग्राफ के भाग के लिए प्रूफ़िंग भाषा सेट कर सकता हूँ?**

हाँ। व्यक्तिगत भागों के लिये [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/) का उपयोग करें, ताकि एक पैराग्राफ में कई भाषाओं का टेक्स्ट हो सके।