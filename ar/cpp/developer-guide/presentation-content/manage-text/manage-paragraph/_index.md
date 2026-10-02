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
- إدارة النص
- إدارة الفقرة
- إدارة الرصاصة
- إزاحة الفقرة
- إزاحة معلقة
- رصاصة الفقرة
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
description: "تعلم كيفية إنشاء وتنسيق الفقرات، الأجزاء، الرصاصات، القوائم المرقمة، الإزاحات، محتوى HTML، وصور الفقرات باستخدام Aspose.Slides للغة C++."
---
## **نظرة عامة**

تمثِّل Aspose.Slides للغة C++ النص كهرمية من إطارات النص والفقرات والأجزاء:

* [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) يمثل حاوية النص داخل الشكل ويقدم الوصول إلى مجموعة الفقرات الخاصة به.
* [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) يمثل فقرة واحدة في إطار النص ويقدم الوصول إلى أجزائه وتنسيق الفقرة.
* [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) يمثل تشغيل نص داخل الفقرة. يمكن لكل جزء أن يحتوي على نصه وتنسيق الأحرف الخاص به.

يمكن للفقرة إذن أن تحتوي على نص بخطوط، ألوان، أحجام، وتنسيقات أخرى مختلفة عن طريق استخدام عدة أجزاء.

## **إنشاء وتنسيق الفقرات**

### **إنشاء فقرات متعددة الأجزاء**

الخطوات التالية تنشئ إطار نص يحتوي على ثلاث فقرات، كل منها يحتوي على ثلاثة أجزاء:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرسها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) مستطيلة إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) الخاص بالشكل.
5. استخدام الفقرة الافتراضية وإضافة كائنين إضافيين من نوع [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) إلى إطار النص.
6. إضافة ما يكفي من كائنات [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) لكل فقرة لتحتوي على ثلاثة أجزاء. الفقرة الافتراضية تحتوي بالفعل على جزء فارغ واحد.
7. تعيين نص كل جزء.
8. تطبيق تنسيق على مستوى الحرف عبر [IPortion::get_PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/get_portionformat/).
9. حفظ العرض التقديمي المعدل.

هذا المثال بلغة C++ يُنفّذ الخطوات:

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

## **إنشاء القوائم النقطية والمرقمة**

### **إنشاء قائمة نقطية أو مرقمة**

تجعل الرصاصات والترقيم العناصر ذات الصلة أسهل في الاستعراض. في Aspose.Slides، يتم تعريف إعدادات القائمة عبر [IBulletFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/).

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرسها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى الشريحة المحددة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/).
5. إزالة الفقرة الافتراضية من إطار النص.
6. إنشاء [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) لرمز الرصاصة.
7. تعيين [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) إلى [BulletType::Symbol](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/) وتحديد حرف الرصاصة.
8. تعيين نص الفقرة والمسافة البادئة ولون الرصاصة وارتفاعها.
9. إضافة الفقرة إلى إطار النص.
10. إنشاء فقرة ثانية وتعيين [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) إلى [BulletType::Numbered](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/).
11. تكوين نمط الرصاصة المرقمة وإضافة الفقرة إلى إطار النص.
12. حفظ العرض التقديمي.

هذا المثال بلغة C++ ينشئ رصاصة رمزية ورصاصة مرقمة:

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

### **استخدام رصاصات صورة**

تتيح رصاصات الصورة لك استخدام صورة مخصصة بدلاً من رمز أو رقم.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرسها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) والوصول إلى [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/).
4. إزالة الفقرة الافتراضية من إطار النص.
5. تحميل صورة الرصاصة وإضافتها إلى مجموعة صور العرض التقديمي كـ [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/).
6. إنشاء [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) وتعيين نصه.
7. تعيين [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) إلى [BulletType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/).
8. تعيين الصورة عبر [ISlidesPicture::set_Image](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/set_image/) وتحديد ارتفاع الرصاصة.
9. إضافة الفقرة إلى إطار النص.
10. حفظ العرض التقديمي المعدل.

هذا المثال بلغة C++ ينشئ رصاصة صورة:

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

تعيين [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_depth/) لتحديد الفقرات في مستويات مختلفة من القائمة. المستوى الأعلى له عمق `0`.

1. إنشاء [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) والوصول إلى شريحة.
2. إضافة [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) وإزالة الفقرة الافتراضية من إطار النص الخاص به.
3. إنشاء أربع فقرات وتكوين رموز الرصاص الخاصة بها.
4. تعيين قيم [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_depth/) إلى `0` و`1` و`2` و`3`.
5. إضافة الفقرات إلى إطار النص وحفظ العرض التقديمي.

هذا المثال بلغة C++ ينشئ قائمة نقطية ذات أربعة مستويات:

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

### **بدء بنود القائمة المرقمة بقيم مخصصة**

استخدام [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) لتعيين الرقم الأول المعروض للفقرة المُرقَّمة.

1. إنشاء [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) وإضافة [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى شريحة.
2. مسح الفقرة الافتراضية من إطار النص الخاص بالشكل.
3. إنشاء ثلاث فقرات مُرقَّمة.
4. تعيين [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) إلى `2` و`3` و`7` للفقرات المعنية.
5. إضافة الفقرات إلى إطار النص وحفظ العرض التقديمي.

هذا المثال بلغة C++ يعيّن رقمًا ابتدائيًا مخصصًا لكل فقرة:

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

### **تعيين إزاحة السطر الأول**

استخدم [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) للتحكم في إزاحة السطر الأول للفقرة. هذه الطريقة تحرك السطر الأول فقط نسبة إلى الهامش الأيسر للفقرة. القيمة الموجبة تحرك السطر الأول إلى اليمين، بينما تبقى الأسطر المتبقية متراصة مع جسم الفقرة.

استخدم [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/) عندما تحتاج إلى تحريك الفقرة بأكملها. استخدم [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) عندما تحتاج إلى تحريك السطر الأول فقط.

المثال أدناه ينشئ عدة فقرات ويطبق قيم مختلفة لـ [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) لتوضيح كيف تؤثر إزاحة السطر الأول على تخطيط الفقرة.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) مستطيلة إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) الخاص بالشكل وإزالة الفقرة الافتراضية.
5. إنشاء عدة فقرات وتعيين قيم مختلفة لـ [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) لكل منها.
6. إضافة الفقرات إلى إطار النص.
7. حفظ العرض التقديمي المعدل.

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

الإزاحة المعلقة هي تخطيط فقرة يكون فيه السطر الأول يبدأ إلى اليسار من بقية الأسطر. في Aspose.Slides، يمكنك إنشاء هذا التأثير باستخدام [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/). قم بتعيين الإزاحة إلى قيمة سالبة لتحريك السطر الأول إلى اليسار بالنسبة إلى جسم الفقرة.

في الممارسة العملية، يحدد [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/) موضع الجانب الأيسر لجسم الفقرة، ويحدد [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) موضع السطر الأول نسبة إلى ذلك الهامش. لإنشاء إزاحة معلقة، عيّن قيمة موجبة للـ margin‑left وقيمة سالبة للإزاحة.

هذا التنسيق مفيد للببليوغرافيا والمراجع ومداخل القاموس وغيرها من الفقرات حيث يجب أن تتطابق الأسطر الملتفة تحت جسم الفقرة بدلاً من الحرف الأول للسطر الأول.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) مستطيلة إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) الخاص بالشكل وإزالة الفقرة الافتراضية.
5. إنشاء فقرات وتعيين قيمة موجبة لـ [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/) لكل فقرة.
6. تعيين قيمة سالبة لـ [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) لإنشاء تأثير الإزاحة المعلقة.
7. إضافة الفقرات إلى إطار النص.
8. حفظ العرض التقديمي المعدل.

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

presentation->Save(u"hhangind_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![الإزاحة المعلقة للفقرات](hanging_indent.png)

### **تعيين خصائص تشغيل الفقرة النهائية**

يتحكم [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) في تنسيق علامة نهاية الفقرة. المثال التالي يعيّن حجم الخط وخط اللاتينية لعلامة النهاية للفقرة الثانية:

1. تحميل [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) والوصول إلى شريحة.
2. إضافة [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ومسح الفقرة الافتراضية الخاصة به.
3. إنشاء فقرتين وإضافة أجزاء نصية إليهما.
4. إنشاء [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/) لعلامة نهاية الفقرة الثانية.
5. تعيين [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_fontheight/) و[IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_latinfont/).
6. تعيين التنسيق باستخدام [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) وحفظ العرض التقديمي.

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

## **عدد الأسطر المُعروضة**

للقواعد الخاصة بالفقرات التي تؤثر على الالتفاف التلقائي وعلامات الترقيم في نهايات السطر، راجع [التحكم في كسر السطر](/slides/ar/cpp/text-formatting/#control-line-breaking) و[التحكم في الترقيم المعلق](/slides/ar/cpp/text-formatting/#control-hanging-punctuation).

استخدم [IParagraph::GetLinesCount](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getlinescount/) لحساب عدد الأسطر التي يشغلها الفقرة بعد تخطيط النص، بما في ذلك الالتفاف التلقائي. هذا مفيد عند التحقق من طول النص وتخطيطه في قوالب العروض التقديمية.

الفقرة هي عنصر واحد في [ITextFrame::get_Paragraphs](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_paragraphs/)، ويمكن أن تشغل عدة أسطر مُعروضة. كسر السطر الصريح داخل الفقرة يُسبب سطرًا جديدًا دون إنشاء فقرة أخرى. الالتفاف التلقائي يخلق أسطرًا بناءً على العرض المتاح دون إدراج كسر سطر صريح في النص. لذا لا يُعطي عدد الفقرات أو عدد أحرف كسر السطر عدد الأسطر المُعروضة.

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

مع هذا النص وهذه الأبعاد، يؤدي تضييق الشكل إلى زيادة عدد الأسطر، بينما استبدال النص بالسلسلة القصيرة يقلل منه. قد تختلف الأحصاءات الدقيقة باختلاف توفر الخطوط والاستبدال، وحجم الخط، والهامش، والمسافات، والالتفاف، وإعدادات الملاءمة التلقائية. استخدم الخطوط وإعدادات التخطيط المقصودة للبيئة المستهدفة عند فحص القالب.

عدد الأسطر وحده لا يُحدِّد ما إذا كان النص سيتجاوز حاويته. الارتفاع المتاح، ارتفاع الأسطر، مسافات الفقرات والأسطر، وسلوك الملاءمة التلقائية أيضًا مهمة؛ حتى السطر الواحد قد يتجاوز العرض المتاح عندما يكون الالتفاف معطلاً.

## **استيراد وتصدير محتوى الفقرة**

### **استيراد نص HTML إلى الفقرات**

استخدم [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphcollection/addfromhtml/) لتحويل ترميز HTML إلى فقرات وأجزاء داخل إطار نص.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. الوصول إلى شريحة وإضافة [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).
3. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) الخاص بالشكل وإزالة الفقرة الافتراضية.
4. قراءة ملف HTML المصدر.
5. تمرير سلسلة HTML إلى [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphcollection/addfromhtml/).
6. حفظ العرض التقديمي المعدل.

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

استخدم [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphcollection/exporttohtml/) لتصدير نطاق محدد من الفقرات كملف HTML.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) وتحميل العرض التقديمي المطلوب.
2. الوصول إلى الشريحة والعثور على [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) الذي يحتوي على النص.
3. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/).
4. استدعاء [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphcollection/exporttohtml/) مع فهرس الفقرة الابتدائي وعدد الفقرات المراد تصديرها.
5. كتابة سلسلة HTML المرجعة إلى ملف.

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

### **عرض الفقرة كصورة**

[IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/) يعرض فقرة فردية مباشرةً ويعيد كائنًا من نوع [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/). احفظ النتيجة إلى ملف أو تدفق باستخدام [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/). لا تحتاج إلى عرض الشكل المحتوي أو قص صورة bitmap يدويًا.

[IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/) قد يعيد `nullptr` إذا تعذر العثور على الفقرة في مجموعتها الأصلية، أو لا توجد حدود عرض صالحة، أو لا يمكن عرضها. تحقق من النتيجة قبل حفظها وتخلص من الصورة المسترجعة بعد الاستخدام.

#### **عرض الفقرة بالمقياس الافتراضي**

لنفترض أن لدينا ملف عرض تقديمي يسمى sample.pptx يحتوي على شريحة واحدة، حيث يكون الشكل الأول عبارة عن مربع نص يحتوي على ثلاث فقرات.

![مربع النص بثلاث فقرات](paragraph_to_image_input.png)

المثال التالي يعرض الفقرة الثانية في شكل نص عادي بالمقياس الافتراضي ويحفظ الصورة الناتجة بصيغة PNG.

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

#### **عرض الفقرة في خلية جدول مع التحجيم**

استخدم نسخة [IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/) التي تقبل المتغيرين `float scaleX` و `float scaleY` لتحديد عوامل التحجيم الأفقي والرأسي. المثال التالي ينشئ جدولًا، يعرض الفقرة في خليةه الأولى بعرض وارتفاع مضاعفين، ويحفظ النتيجة كصورة PNG.

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

قيمة التحجيم `1` تبقي هذا المحور بالحجم البكسلي الافتراضي. على سبيل المثال، `2` لكل العاملين ينتج صورة عرضها وارتفاعها تقريبًا ضعف الأبعاد الافتراضية، ما يعادل أربع مرات عدد البكسلات. القيم الأكبر عادةً ما تنتج نصًا أكثر وضوحًا عند التكبير أو الإخراج عالي الدقة، لكنها أيضًا تزيد من استهلاك الذاكرة وحجم الملف. القيم الأقل من `1` تنتج صورًا أصغر بتفاصيل أقل. استخدم عوامل متماثلة للحفاظ على نسبة أبعاد الفقرة؛ العوامل الأفقية والرأسية المختلفة تُمدّد الناتج بشكل مستقل.

عرض شكل كامل باستخدام [IShape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getimage/) يظل مفيدًا عندما يجب أن يتضمن الإخراج تعبئة الشكل أو حدوده أو سياقه البصري الآخر. للحصول على صورة لفقرة فقط، استخدم [IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/).

## **الأسئلة الشائعة**

**هل يمكنني تعطيل التفاف السطر بالكامل داخل إطار النص؟**

نعم. استخدم [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_wraptext/) لتعطيل الالتفاف بحيث لا تنكسر الأسطر عند حواف إطار النص.

**كيف يمكنني الحصول على الحدود الدقيقة للفقرة المحددة على الشريحة؟**

استخدم [IParagraph::GetRect](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getrect/) لاسترجاع المستطيل المحيط بالفقرة. يوفر [IPortion::GetRect](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/getrect/) حدود الجزء الفردي.

**أين يتم التحكم في محاذاة الفقرة (يسار، يمين، مركز أو ضبط)؟**

[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) هو إعداد على مستوى الفقرة ويطبّق على الفقرة بأكملها بغض النظر عن تنسيق الأجزاء الفردية.

لتحاذي عمودي لأجزاء ذات أحجام خطوط مختلفة ضمن كل سطر، راجع [محاذاة الخطوط داخل السطر](/slides/ar/cpp/text-formatting/#align-fonts-within-a-line).

**هل يمكنني تعيين لغة التدقيق لجزء من الفقرة؟**

نعم. استخدم [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/) للأجزاء الفردية، بحيث يمكن للفقرة أن تحتوي نصًا بعدة لغات.