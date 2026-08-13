---
title: C++ में प्रस्तुतियों में बुलेटेड और क्रमांकित सूचियों का प्रबंधन
linktitle: सूचियों का प्रबंधन
type: docs
weight: 70
url: /hi/cpp/manage-lists/
keywords:
- बुलेट
- बुलेटेड सूची
- क्रमांकित सूची
- प्रतीक बुलेट
- चित्र बुलेट
- कस्टम बुलेट
- बहु-स्तरीय सूची
- बुलेट बनाएं
- बुलेट जोड़ें
- सूची जोड़ें
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में बुलेटेड, चित्र, बहु-स्तरीय और क्रमांकित सूचियों को बनाना और स्वरूपित करना सीखें."
---
## **अवलोकन**

Aspose.Slides for C++ आपको PowerPoint और OpenDocument प्रस्तुतियों में बुलेटेड और क्रमांकित सूचियों को बनाने और स्वरूपित करने की अनुमति देता है। एक सूची आइटम वह पैराग्राफ है जिसके बुलेट सेटिंग्स उसके पैराग्राफ फ़ॉर्मेट द्वारा नियंत्रित होते हैं।

पैराग्राफ‑स्तर की सूची सेटिंग्स तक पहुंचने के लिए [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraph/get_paragraphformat/) मेथड का उपयोग करें। मुख्य प्रवेश बिंदु है [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/get_bullet/), जो एक [IBulletFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibulletformat/) ऑब्जेक्ट लौटाता है। इस ऑब्जेक्ट के साथ, आप बुलेट का प्रकार, प्रतीक, तस्वीर, रंग, आकार, क्रमांक शैली, और प्रारंभिक संख्या सेट कर सकते हैं।

यह लेख दर्शाता है कि कैसे:

- कस्टम प्रतीक के साथ बुलेटेड सूची बनाएं
- चित्र बुलेट बनाएं
- पैराग्राफ डेप्थ सेट करके मल्टीलेवल सूची बनाएं
- क्रमांकित सूची बनाएं
- मौजूदा प्रस्तुति में सूची का फ़ॉर्मेट निरीक्षण और परिवर्तन करें

## **बुलेटेड सूची बनाएं**

बुलेटेड सूची बनाने के लिए, एक [Paragraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides/paragraph/) ऑब्जेक्ट को एक [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) में जोड़ें और [IBulletFormat::set_Type](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibulletformat/set_type/) को [BulletType::Symbol](https://reference.aspose.com/slides/hi/cpp/aspose.slides/bullettype/) पर सेट करें। फिर आप बुलेट की उपस्थिति को नियंत्रित करने के लिए [IBulletFormat::set_Char](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibulletformat/set_char/), [IBulletFormat::get_Color](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibulletformat/get_color/), और [IBulletFormat::set_Height](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibulletformat/set_height/) सेट कर सकते हैं।

निम्नलिखित C++ कोड स्लाइड में बुलेटेड सूची बनाने का उदाहरण है:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto createParagraph = [](System::String text)
{
    auto paragraph = System::MakeObject<Paragraph>();
    auto paragraphFormat = paragraph->get_ParagraphFormat();
    auto bulletFormat = paragraphFormat->get_Bullet();

    bulletFormat->set_Type(BulletType::Symbol);
    bulletFormat->set_Char(u'*');
    paragraphFormat->set_Indent(15);
    bulletFormat->set_IsBulletHardColor(NullableBool::True);
    bulletFormat->get_Color()->set_Color(System::Drawing::Color::get_IndianRed());
    bulletFormat->set_Height(100);
    paragraph->set_Text(text);

    return paragraph;
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = createParagraph(u"The first paragraph");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = createParagraph(u"The second paragraph");
textFrame->get_Paragraphs()->Add(paragraph2);

presentation->Save(u"symbol_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![प्रतीक बुलेट्स](symbol_bullets.png)

## **क्रमांकित सूची बनाएं**

जब आइटमों का क्रम महत्वपूर्ण हो, तो क्रमांकित सूचियों का उपयोग करें। [IBulletFormat::set_Type](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibulletformat/set_type/) को [BulletType::Numbered](https://reference.aspose.com/slides/hi/cpp/aspose.slides/bullettype/) पर सेट करें। आप क्रमांक फ़ॉर्मेट को [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) से चुन सकते हैं या सूची को 1 से अलग किसी मान से शुरू करने के लिए [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) सेट कर सकते हैं।

निम्नलिखित C++ कोड स्लाइड में क्रमांकित सूची बनाने का उदाहरण है:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph1->set_Text(u"Apple");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph2->set_Text(u"Orange");
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph3 = System::MakeObject<Paragraph>();
paragraph3->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph3->set_Text(u"Banana");
textFrame->get_Paragraphs()->Add(paragraph3);

presentation->Save(u"numbered_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![क्रमांकित बुलेट्स](numbered_bullets.png)

## **चित्र बुलेट बनाएं**

Aspose.Slides आपको नियमित बुलेट प्रतीक को एक छवि से बदलने की अनुमति देता है। चित्र बुलेट उन सरल छवियों के साथ सबसे अच्छा कार्य करता है जो छोटे आकार में भी पढ़ने योग्य रहें, जैसे आइकॉन या छोटे पारदर्शी PNG फ़ाइलें।

{{% alert color="info" %}}
आदर्श रूप से, यदि आप नियमित बुलेट प्रतीक को एक छवि से बदलने की योजना बनाते हैं, तो पारदर्शी पृष्ठभूमि वाली एक सरल ग्राफ़िक चुनना सबसे अच्छा रहता है। ऐसी छवियां कस्टम बुलेट प्रतीकों के रूप में बहुत उपयुक्त होती हैं।

ध्यान रखें कि छवि को बहुत छोटे आकार में स्केल किया जाएगा। इसलिए हम दृढ़ता से अनुशंसा करते हैं कि ऐसी छवि चुनें जो सूची में बुलेट के रूप में उपयोग करने पर भी स्पष्ट और दृश्य रूप से प्रभावी बनी रहे।
{{% /alert %}}

चित्र बुलेट बनाने के लिए, एक छवि को [IPresentation::get_Images](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/get_images/) में जोड़ें और लौटाए गए [IPPImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ippimage/) ऑब्जेक्ट को [IBulletFormat::get_Picture](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibulletformat/get_picture/) को असाइन करें। छवि असाइन करने से पहले [IBulletFormat::set_Type](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibulletformat/set_type/) को [BulletType::Picture](https://reference.aspose.com/slides/hi/cpp/aspose.slides/bullettype/) पर सेट करें।

मान लें कि हमारे पास "image.png" मौजूद है:

![बुलेट्स के लिए एक चित्र](picture_for_bullets.png)

निम्नलिखित C++ कोड स्लाइड में चित्र बुलेट बनाने का उदाहरण है:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto createParagraph = [](System::String text, System::SharedPtr<IPPImage> image)
{
    auto paragraph = System::MakeObject<Paragraph>();
    auto paragraphFormat = paragraph->get_ParagraphFormat();
    auto bulletFormat = paragraphFormat->get_Bullet();

    bulletFormat->set_Type(BulletType::Picture);
    bulletFormat->get_Picture()->set_Image(image);
    paragraphFormat->set_Indent(15);
    bulletFormat->set_Height(100);
    paragraph->set_Text(text);

    return paragraph;
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto sourceImage = Images::FromFile(u"image.png");
auto bulletImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

auto paragraph1 = createParagraph(u"The first paragraph", bulletImage);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = createParagraph(u"The second paragraph", bulletImage);
textFrame->get_Paragraphs()->Add(paragraph2);

presentation->Save(u"picture_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![चित्र बुलेट्स](picture_bullets.png)

## **बहु-स्तरीय सूची बनाएं**

सूची आइटमों को विभिन्न स्तरों पर रखने के लिए [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_depth/) का उपयोग करें। स्तर 0 शीर्ष स्तर है, स्तर 1 उसके नीचे नेस्टेड है, और इसी प्रकार आगे।

निम्नलिखित C++ कोड बहु-स्तरीय बुलेटेड सूची बनाने का उदाहरण है:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->get_ParagraphFormat()->set_Depth(0);
paragraph1->set_Text(u"My text - Depth 0");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->get_ParagraphFormat()->set_Depth(1);
paragraph2->set_Text(u"My text - Depth 1");
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph3 = System::MakeObject<Paragraph>();
paragraph3->get_ParagraphFormat()->set_Depth(2);
paragraph3->set_Text(u"My text - Depth 2");
textFrame->get_Paragraphs()->Add(paragraph3);

auto paragraph4 = System::MakeObject<Paragraph>();
paragraph4->get_ParagraphFormat()->set_Depth(3);
paragraph4->set_Text(u"My text - Depth 3");
textFrame->get_Paragraphs()->Add(paragraph4);

presentation->Save(u"multilevel_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![बहु-स्तरीय सूची](multilevel_list.png)

## **मौजूदा सूची बदलें**

मौजूदा प्रस्तुति में सूची फ़ॉर्मेट बदलने के लिए, लक्ष्य पैराग्राफ तक पहुंचें और उसके [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/get_bullet/) सेटिंग्स को अपडेट करें। सूची बनाने के लिए उपयोग किए गए वही गुण PPT, PPTX या ODP फ़ाइल से लोड की गई सूचियों का निरीक्षण या संशोधन करने के लिए उपयोग किए जा सकते हैं।

निम्नलिखित C++ कोड एक टेक्स्ट फ़्रेम में पहले पैराग्राफ को क्रमांकित सूची शैली में बदलता है:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NumberedBulletStyle.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);
auto autoShape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

auto paragraphFormat = paragraph->get_ParagraphFormat();
auto bulletFormat = paragraphFormat->get_Bullet();

bulletFormat->set_Type(BulletType::Numbered);
bulletFormat->set_NumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
bulletFormat->set_NumberedBulletStartWith(1);
paragraphFormat->set_MarginLeft(30);
paragraphFormat->set_Indent(-20);

presentation->Save(u"updated_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या बुलेटेड और क्रमांकित सूचियों को PDF या छवियों में निर्यात किया जा सकता है?

हाँ। Aspose.Slides सूची फ़ॉर्मेट को संरक्षित रखता है जब लक्ष्य फ़ॉर्मेट संबंधित टेक्स्ट लेआउट और बुलेट सुविधाओं का समर्थन करता है।

### क्या मैं मौजूदा प्रस्तुतियों में सूचियों को संपादित कर सकता हूँ?

हाँ। प्रस्तुति लोड करें, लक्ष्य पैराग्राफ तक पहुंचें, उसके [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/get_bullet/) सेटिंग्स का निरीक्षण या अद्यतन करें, और प्रस्तुति को सहेजें।

### क्या सूचियों में गैर‑लैटिन टेक्स्ट हो सकता है?

हाँ। सूची आइटम टेक्स्ट Unicode अक्षरों को समायोजित कर सकता है, इसलिए आप बहुभाषी प्रस्तुतियों में सूचियाँ बना सकते हैं। सुनिश्चित करें कि प्रस्तुति में प्रयुक्त फ़ॉन्ट्स आवश्यक अक्षरों का समर्थन करते हैं।