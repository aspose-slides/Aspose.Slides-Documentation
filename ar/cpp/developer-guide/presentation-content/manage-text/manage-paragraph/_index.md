---
title: إدارة فقرات نص PowerPoint في C++
linktitle: إدارة الفقرة
type: docs
weight: 40
url: /ar/cpp/manage-paragraph/
aliases:
  - /cpp/paragraph/
  - /cpp/portion/
keywords:
- إضافة نص
- إضافة فقرة
- إدارة نص
- إدارة فقرة
- إدارة نقطه
- إزاحة الفقرة
- إزاحة معلقة
- نقطه الفقرة
- قائمة مرقمة
- قائمة نقطية
- خصائص الفقرة
- استيراد HTML
- نص إلى HTML
- فقرة إلى HTML
- فقرة إلى صورة
- نص إلى صورة
- تصدير الفقرة
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعرف على كيفية إنشاء وتنسيق الفقرات، الأجزاء، النقط، القوائم المرقمة، الإزاحات، محتوى HTML، وصور الفقرات باستخدام Aspose.Slides للغة C++."
---
## **نظرة عامة**

تُمثل Aspose.Slides للغة C++ النص كهيكل هرمي من إطارات النص، الفقرات، والأجزاء:

* [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) يمثل حاوية النص داخل الشكل ويوفر إمكانية الوصول إلى مجموعة الفقرات الخاصة به.
* [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) يمثل فقرة واحدة داخل إطار النص ويوفر إمكانية الوصول إلى أجزائه وتنسيق مستوى الفقرة.
* [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) يمثل تشغيل نص داخل الفقرة. يمكن لكل جزء أن يحتوي على نصه الخاص وتنسيق مستوى الحرف.

يمكن للفقرة إذًا أن تحتوي على نص بخطوط، ألوان، أحجام، وتنسيقات أخرى مختلفة باستخدام عدة أجزاء.

## **إنشاء وتنسيق الفقرات**

قم بإنشاء فقرات داخل إطار النص للشكل واستخدم الأجزاء لتنسيق تشغيلات النص الفردية. يوضح هذا القسم كيفية دمج عدة أجزاء داخل كل فقرة وتطبيق ألوان، أحجام خطوط، وأنماط مختلفة.

### **إنشاء فقرات مع عدة أجزاء**

المثال التالي بلغة C++ ينشئ ثلاث فقرات، كل منها يحتوي على ثلاث تشغيلات نصية في مجموعة [IParagraph::get_Portions](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/get_portions/). يعيد استخدام الفقرة الافتراضية والجزء الفارغ الخاص بها، ثم يضيف الفقرات والأجزاء المتبقية. يتم تطبيق التنسيق عبر [IPortion::get_PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/get_portionformat/): الجزء الأول في كل فقرة يكون أحمر، عريض، وحجمه 15 نقطة؛ الجزء الثاني أزرق، مائل، وحجمه 18 نقطة. الجزء الثالث يحتفظ بتنسيقه الافتراضي:

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

## **إنشاء القوائم النقطية والمرقمة**

نظم نص الفقرة في قوائم باستخدام رموز، أرقام، أو صور مخصصة. تغطي الأمثلة في هذا القسم تنسيق النقاط، القوائم المتعددة المستويات، وأرقام البدء المخصصة.

### **إنشاء قائمة نقطية أو مرقمة**

تسهل النقاط والترقيم قراءة العناصر المتعلقة. في Aspose.Slides، تُعرّف إعدادات القوائم عبر [IBulletFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/).

يضيف هذا المثال بلغة C++ نقطة رمزية وبندًا مرقمًا إلى نفس إطار النص. تقوم [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) باختيار نوع النقطة، بينما تقوم [IBulletFormat::set_Char](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_char/) بتوفير الرمز و[IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) باختيار نمط الترقيم. يستخدم العنصران نقاطًا سوداء بارتفاع 100٪ وإزاحة فقرة 25 نقطة:

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

### **استخدام نقاط صورة**

تتيح لك نقاط الصورة استخدام صورة مخصصة بدلاً من رمز أو رقم.

يتطلب المثال وجود ملف `bullets.png` في دليل العمل. يضيف هذا المثال بلغة C++ صورة إلى مجموعة صور العرض كـ [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) ويستخدمها كنقطة فقرة. يحدد [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) لاستخدام نقطة صورة ويعين الصورة عبر [IBulletFormat::get_Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/get_picture/). يتم ضبط [IBulletFormat::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_height/) على 100٪ لتحديد حجم النقطة بالنسبة لنص الفقرة:

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

### **إنشاء قائمة متعددة المستويات**

قم بتعيين [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_depth/) لوضع الفقرات في مستويات مختلفة من القائمة. المستوى الأعلى له عمق `0`.

المثال التالي بلغة C++ يعيّن قيم [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_depth/) من 0 إلى 3 لأربع فقرات، مُنشئًا هيكلًا داخل إطار نص واحد. تستخدم كل فقرة نقطة رمزية، مع تبديل [IBulletFormat::set_Char](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_char/) بين نقطة دائرية وشرطة لتمييز المستويات المتجاورة:

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

### **بدء عناصر القائمة المرقمة بقيم مخصصة**

استخدم [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) لتعيين الرقم الأولي المعروض لفقرة مرقمة.

المثال التالي بلغة C++ يحدد [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) لاستخدام الترقيم لثلاث فقرات ويعيّن قيم [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) 2 و3 و7. يتم تكوين القيمة الابتدائية بشكل منفصل لكل فقرة، مما يسمح بتخطي الأرقام بين الفقرات:

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

## **التحكم في تخطيط الفقرة وخصائص النهاية**

قم بضبط هوامش الفقرة والمسافات لتحديد موضع السطر الأول والأسطر المُلتفة. يمكنك أيضًا تنسيق علامة نهاية الفقرة بشكل منفصل عن أجزاء النص الظاهرة.

### **تعيين إزاحة السطر الأول**

استخدم طريقة [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) للتحكم في إزاحة السطر الأول للفقرة. تُحرك هذه الطريقة السطر الأول فقط بالنسبة لهامش الفقرة الأيسر. القيمة الموجبة تُحرك السطر الأول إلى اليمين، بينما تبقى الأسطر المتبقية محاذاة إلى جسم الفقرة.

استخدم [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/) عندما تحتاج إلى نقل الفقرة بأكملها. استخدم [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) عندما تحتاج إلى نقل السطر الأول فقط.

المثال التالي يمنح ثلاث فقرات نفس قيمة [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/) البالغة 20 نقطة، وقيم [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) 0 و20 و40 نقطة. تبدأ الأسطر الأولى بإزاحات متزايدة تدريجيًا، بينما تحتفظ الأسطر المُلتفة بنفس الهامش الأيسر:

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

النتيجة:

![إزاحة السطر الأول للفقرات](first_line_indent.png)

### **تعيين إزاحة معلقة**

إزاحة معلقة هي تخطيط فقرة يبدأ فيه السطر الأول إلى اليسار من الأسطر المتبقية. في Aspose.Slides، يمكنك إنشاء هذا التأثير باستخدام طريقة [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/). مرّر قيمة سالبة لتحريك السطر الأول إلى اليسار بالنسبة إلى جسم الفقرة.

عمليًا، يحدد [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/) الموضع الأيسر لجسم الفقرة، ويحدد [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) موضع السطر الأول بالنسبة لهذا الهامش. لإنشاء إزاحة معلقة، عيّن قيمة إيجابية لـ `MarginLeft` وقيمة سالبة لـ `Indent`.

هذا التنسيق مفيد للمراجع، المراجع الببليوغرافية، مدخلات القاموس، وغيرها من الفقرات التي يجب أن تكون الأسطر المُلتفة محاذية تحت جسم الفقرة بدلاً من الحرف الأول للسطر الأول.

المثال التالي بلغة C++ يقرّن قيم [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/) 40 و60 نقطة مع قيم [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) -20 و-30 نقطة. في كل فقرة، يبدأ السطر الأول إلى اليسار من الأسطر المُلتفة؛ الفقرة الثانية لديها إزاحة معلقة أعمق:

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

النتيجة:

![الإزاحة المعلقة للفقرات](hanging_indent.png)

### **تعيين خصائص تشغيل نهاية الفقرة**

تتحكم طريقة [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) في تنسيق علامة نهاية الفقرة. يحمل المثال ملف `Test.pptx` الذي يجب أن يحتوي على شريحة واحدة على الأقل. ينشئ المثال التالي كائنًا من النوع [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/) مع تعيين [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_fontheight/) إلى 48 نقطة و[IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_latinfont/) إلى Times New Roman. يُعيّن هذا التنسيق إلى علامة نهاية الفقرة الثانية، مع إبقاء أجزاء النص الظاهرة دون تغيير:

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

## **عدد الأسطر المُرَسَمة**

للقواعد المتعلقة بالفقرة التي تؤثر على الالتفاف التلقائي وعلامات الترقيم في نهايات السطر، راجع [Control Line Breaking](/slides/ar/cpp/text-formatting/#control-line-breaking) و[Control Hanging Punctuation](/slides/ar/cpp/text-formatting/#control-hanging-punctuation).

استخدم [IParagraph::GetLinesCount](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getlinescount/) لحساب عدد الأسطر التي تشغلها الفقرة بعد تخطيط النص، بما في ذلك الالتفاف التلقائي. وهذا مفيد عند التحقق من طول النص وتخطيطه في قوالب العروض التقديمية.

الفقرة هي عنصر واحد في [ITextFrame::get_Paragraphs](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_paragraphs/)، ويمكن أن تحتل عدة أسطر مُرَسَمة. يُجبر فاصل السطر الصريح داخل الفقرة على سطر جديد دون إنشاء فقرة أخرى. يولِّد الالتفاف التلقائي أسطرًا بناءً على العرض المتاح دون إدخال فواصل صريحة إلى النص. لذا فإن عد الفقرات أو حروف فاصل السطر لا يعطي عدد الأسطر المُرَسَمة.

المثال التالي ينشئ شكل نص، يحسب أسطره، يضيق الشكل، ثم يستبدل النص بسلسلة أقصر. يُفعِّل المثال [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_wraptext/) ويعطل [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) بحيث يتحكم عرض الشكل في الالتفاف دون تصغير النص تلقائيًا أو تغيير حجم الشكل. كل قياس يستخدم [IParagraph::GetLinesCount](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getlinescount/). أبعاد الشكل بوحدة النقاط. أخيرًا، يضيف المثال فقرة أخرى ويجمع عدد الأسطر عبر إطار النص.

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

مع هذا النص وهذه الأبعاد، يؤدي تضييق الشكل إلى زيادة عدد الأسطر، بينما يؤدي استبدال النص بالسلسلة القصيرة إلى تقليلها. قد تختلف العدادات الدقيقة بحسب توفر الخطوط والاستبدال، حجم الخط، الهوامش، الإزاحات، الالتفاف، وإعدادات الملاءمة التلقائية. استخدم الخطوط وإعدادات التخطيط المستهدفة عند فحص القالب.

عدد الأسطر وحده لا يحدد ما إذا كان النص يفيض عن حاويته. الارتفاع المتاح، ارتفاعات الأسطر، تباعد الفقرة والسطر، وسلوك الملاءمة التلقائية أيضًا مهم؛ حتى سطر واحد قد يتجاوز العرض المتاح عندما يكون الالتفاف مُعطَّلًا.

## **استيراد وتصدير محتوى الفقرة**

استخدم HTML لإدخال النص إلى عرض تقديمي أو لتصدير الفقرات الحالية للاستخدام خارجها. يُظهر هذا القسم أيضًا كيفية تصيّر الفقرات الفردية كصور، بما في ذلك الفقرات داخل خلايا الجداول.

### **استيراد نص HTML إلى الفقرات**

استخدم [ParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/addfromhtml/) لتحويل علامات HTML إلى فقرات وأجزاء في إطار النص.

يقرأ هذا المثال بلغة C++ HTML من ملف ويمرر العلامات إلى [ParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/addfromhtml/). يزيل الفقرة الافتراضية في إطار النص بحيث يحتوي الإطار على المحتوى المستورد فقط. يترك الشكل المستطيل هامشًا قدره 10 نقاط على كل جانب من الشريحة:

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

### **تصدير نص الفقرة إلى HTML**

استخدم [ParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/exporttohtml/) لتصدير مجموعة مختارة من الفقرات كـ HTML. عند إعادة استخدام نص العرض على موقع ويب، قد ترغب في الحفاظ على التشديد المحلي دون نقل خطوط، حجم، أو أنماط صندوق النص من العرض. اضبط [TextToHtmlConversionOptions::set_TextInheritanceLimit](https://reference.aspose.com/slides/cpp/aspose.slides.export/texttohtmlconversionoptions/set_textinheritancelimit/) للتحكم إلى أي مدى يتبع المُصدِّر وراثة التنسيق.

حمّل [العرض التجريبي](text-inheritance.pptx) وضعه في دليل عمل التطبيق. يحتوي شريحته الأولى على شكل نص يحتوي على النص "Inherited text; explicit red 18pt". يستخدم الإدخال عدة مستويات تنسيق عمدًا:

- نمط النص الافتراضي للعرض يوفِّر Calibri بحجم 28 pt.
- نمط النص من المستوى الأول في إطار النص يوفِّر نصًا أزرق ومائل.
- الفقرة تُعيّن صراحةً نصًا عريضًا.
- الجزء الثاني، "explicit red 18pt"، يُعيّن صراحةً نصًا أحمر وحجم 18 pt.

المثال التالي يصدر نفس الفقرات ثلاث مرات. يمرّر [TextToHtmlConversionOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/texttohtmlconversionoptions/) إلى طريقة التصدير ويكتب كل نتيجة كملف HTML منفصل بترميز UTF-8:

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

يحتوي HTML المُنشأ على CSS التالي للجزء الأول، "Inherited text; ". الجدول يسرد التعريفات ذات الصلة؛ تُحذف الخصائص المُولَّدة الأخرى للوضوح.

| الناتج | CSS ذي الصلة للجزء الأول | المظهر |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | نص أزرق، عريض، مائل بحجم 28 pt في Calibri، إذا كان الخط متاحًا. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | نص أزرق، عريض، مائل؛ يُوفر المتصفح أو الصفحة المحيطة عائلة الخط والحجم. |
| `ParagraphOnly.html` | `font-weight:bold` | نص عريض؛ تُوفر الصفحة أو المتصفح المحيط عائلة الخط، الحجم، اللون، والنمط المائل. |

يحتفظ الجزء الثاني بـ `color:#ff0000`، `font-size:18pt`، و`font-weight:bold` في جميع المخرجات الثلاث. كما يحتفظ بالمائل في `All` و`TextBox`، لكن ليس في `ParagraphOnly`. لذلك لا يُزيل تقييد الوراثة التنسيق المعين صراحةً لفقرة أو جزء.

افتح الملفات في نفس المتصفح للمقارنة. في الوضعين المقيدين، تُحل الخصائص CSS المفقودة بواسطة أنماط الصفحة الوجهة أو القيم الافتراضية للمتصفح، لذا يعتمد المظهر النهائي على مكان استخدام HTML.

### **تصيّر فقرة كصورة**

[IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/) يصوّر فقرة واحدة مباشرةً ويعيد كائنًا من النوع [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/). احفظ النتيجة إلى ملف أو تدفق باستخدام [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/). لا تحتاج إلى تصيّر الشكل المحتوي أو قص صورة يدوية.

[IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/) قد يُعيد `nullptr` إذا لم تُعثر الفقرة في مجموعة أمتها، أو لا تملك حدود تصيّر صالحة، أو لا يمكن تصيّرها. تحقق من النتيجة قبل حفظها وتخلص من الصورة المرجعية بعد الاستخدام.

#### **تصيّر فقرة بالمقياس الافتراضي**

يستخدم المثال `sample.pptx`، عرضًا يحتوي شريحة واحدة يكون شكلها الأول صندوق نص يضم ثلاث فقرات.

![صندوق النص مع ثلاث فقرات](paragraph_to_image_input.png)

المثال التالي يختار الفقرة الثانية عند الفهرس 1 ويستدعي [IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/) دون معلمات مقياس. يتحقق من أن الشكل يحتوي على الفقرة المطلوبة وأن التصيّر يُعيد صورة قبل استدعاء [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) لحفظها بصيغة PNG. يتخلص المثال من الصورة بعد حفظها.

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

النتيجة:

![صورة الفقرة](paragraph_to_image_output.png)

#### **تصيّر فقرة في خلية جدول مع مقياس**

استخدم نسخة [IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/) التي تقبل معلمات `float scaleX` و `float scaleY` لتحديد عوامل المقياس الأفقي والرأسي. ينشئ المثال التالي جدولًا، يصوّر الفقرة في خليةه الأولى بضعف العرض والارتفاع الافتراضيين، ويحفظ النتيجة كصورة PNG.

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

القيمة `1` تبقي المحور بحجمه الأصلي بالبكسل. على سبيل المثال، `2` لكل العاملين ينتج صورة يبلغ عرضها وارتفاعها تقريبًا ضعف الأبعاد الافتراضية، ما يعادل أربعة أضعاف عدد البكسلات. القيم الأكبر تُنتج عادة نصًا أكثر حدة للتقريب أو الإخراج عالي الدقة، لكنها أيضًا تُزيد من استهلاك الذاكرة وحجم الملف. القيم الأقل من `1` تُنتج صورًا أصغر مع تفاصيل أقل. استخدم عوامل متماثلة للحفاظ على نسبة أبعاد الفقرة؛ العوامل الأفقية والرأسية المختلفة تُشوّه الإخراج بشكل مستقل.

لا يزال تصيّر الشكل كاملًا باستخدام [IShape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getimage/) مفيدًا عندما يجب تضمين تعبئة الشكل، حدوده، أو سياقه البصري. لتصوّر صورة للفقرة فقط، استخدم [IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/).

## **FAQ**

**هل يمكنني تعطيل التفاف السطر بالكامل داخل إطار النص؟**

نعم. استخدم [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_wraptext/) لتعطيل الالتفاف بحيث لا تُقسم الأسطر عند حواف إطار النص.

**كيف يمكنني الحصول على حدود الفقرة المحددة داخل الشريحة؟**

استخدم [IParagraph::GetRect](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getrect/) لاسترجاع المستطيل المحيط بالفقرة. توفر [IPortion::GetRect](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/getrect/) حدود الجزء الفردي.

**أين يتم التحكم في محاذاة الفقرة (يسار، يمين، مركز، أو مبرر)؟**

[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) هو إعداد على مستوى الفقرة ويُطبق على الفقرة بأكملها بغض النظر عن تنسيق الأجزاء الفردية.

للمحاذاة العمودية للأجزاء ذات أحجام الخط المختلفة داخل كل سطر، راجع [Align Fonts Within a Line](/slides/ar/cpp/text-formatting/#align-fonts-within-a-line).

**هل يمكنني تعيين لغة التدقيق لجزء من الفقرة؟**

نعم. استخدم [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/) للأجزاء الفردية، بحيث يمكن لفقرة واحدة أن تحتوي نصًا بعدة لغات.