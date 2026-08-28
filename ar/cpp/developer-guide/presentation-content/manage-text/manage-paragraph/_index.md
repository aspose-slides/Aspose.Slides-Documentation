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
- قائمة رقمية
- قائمة نقطية
- خصائص الفقرة
- استيراد HTML
- تحويل النص إلى HTML
- تحويل الفقرة إلى HTML
- تحويل الفقرة إلى صورة
- تحويل النص إلى صورة
- تصدير الفقرة
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية إنشاء وتنسيق الفقرات، الجزءات، الرصاصات، القوائم الرقمية، الإزاحات، محتوى HTML، وصور الفقرات باستخدام Aspose.Slides للغة C++."
---
## **نظرة عامة**

Aspose.Slides for C++ يمثل النص كهرمية من إطارات النص، الفقرات، والجزءات:

* [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/) يمثل حاوية النص في الشكل ويوفر الوصول إلى مجموعة الفقرات الخاصة به.
* [IParagraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraph/) يمثل فقرة واحدة في إطار النص ويعطي الوصول إلى الجزءات وتنسيق الفقرة على مستوى الفقرة.
* [IPortion](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportion/) يمثل تشغيل نص داخل الفقرة. يمكن لكل جزء أن يحتوي على نصه الخاص وتنسيق على مستوى الأحرف.

يمكن للفقرة إذن أن تحتوي على نص بخطوط، ألوان، أحجام، وتنسيقات أخرى مختلفة عن طريق استخدام جزءات متعددة.

## **إنشاء وتنسيق الفقرات**

### **إنشاء فقرات مع جزءات متعددة**

الخطوات التالية تنشئ إطار نص يحتوي على ثلاث فقرات، كل منها يحتوي على ثلاث جزءات:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) مستطيلة إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/) الخاص بالشكل.
5. استخدام الفقرة الافتراضية وإضافة عنصرين إضافيين من نوع [IParagraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraph/) إلى إطار النص.
6. إضافة عدد كافٍ من كائنات [IPortion](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportion/) لكل فقرة بحيث تحتوي على ثلاث جزءات. تحتوي الفقرة الافتراضية بالفعل على جزء فارغ واحد.
7. تعيين نص كل جزء.
8. تطبيق تنسيق على مستوى الأحرف عبر [IPortion::get_PortionFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportion/get_portionformat/).
9. حفظ العرض التقديمي المعدل.

هذا المثال بلغة C++ يطبق الخطوات:

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

## **إنشاء قوائم نقطية ومرقمة**

### **إنشاء قائمة نقطية أو مرقمة**

تجعل النقاط والترقيم العناصر المتعلقة أسهل في المسح. في Aspose.Slides، يتم تعريف إعدادات القائمة من خلال [IBulletFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibulletformat/).

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) إلى الشريحة المحددة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية من إطار النص.
6. إنشاء [Paragraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides/paragraph/) لنقطة رمزية.
7. تعيين [IBulletFormat::set_Type](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibulletformat/set_type/) إلى [BulletType::Symbol](https://reference.aspose.com/slides/ar/cpp/aspose.slides/bullettype/) وتحديد حرف الرصاصة.
8. تعيين نص الفقرة، والمسافة البادئة، ولون الرصاصة، وارتفاع الرصاصة.
9. إضافة الفقرة إلى إطار النص.
10. إنشاء فقرة ثانية وتعيين [IBulletFormat::set_Type](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibulletformat/set_type/) إلى [BulletType::Numbered](https://reference.aspose.com/slides/ar/cpp/aspose.slides/bullettype/).
11. تهيئة نمط الرصاصة المرقمة وإضافة الفقرة إلى إطار النص.
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

تتيح لك رصاصات الصورة استخدام صورة مخصصة بدلاً من رمز أو رقم.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) والوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/) الخاص به.
4. إزالة الفقرة الافتراضية من إطار النص.
5. تحميل صورة الرصاصة وإضافتها إلى مجموعة صور العرض التقديمي كـ [IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/).
6. إنشاء [Paragraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides/paragraph/) وتعيين نصه.
7. تعيين [IBulletFormat::set_Type](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibulletformat/set_type/) إلى [BulletType::Picture](https://reference.aspose.com/slides/ar/cpp/aspose.slides/bullettype/).
8. تعيين الصورة عبر [ISlidesPicture::set_Image](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidespicture/set_image/) وتحديد ارتفاع الرصاصة.
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

استخدم [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/set_depth/) لتحديد الفقرات في مستويات مختلفة من القائمة. المستوى العلوي له عمق `0`.

1. إنشاء [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) والوصول إلى شريحة.
2. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) وإزالة الفقرة الافتراضية من إطار النص الخاص به.
3. إنشاء أربع فقرات وتكوين رموز الرصاص الخاصة بها.
4. تعيين قيم [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/set_depth/) إلى `0`، `1`، `2`، و`3`.
5. إضافة الفقرات إلى إطار النص وحفظ العرض التقديمي.

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

استخدم [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) لتحديد الرقم الأولي المعروض للفقرة المرقمة.

1. إنشاء [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) وإضافة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) إلى شريحة.
2. إزالة الفقرة الافتراضية من إطار النص الخاص بالشكل.
3. إنشاء ثلاث فقرات مرقمة.
4. تعيين [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) إلى `2`، `3`، و`7` للفقرات المعنية.
5. إضافة الفقرات إلى إطار النص وحفظ العرض التقديمي.

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

استخدام [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/set_indent/) للتحكم في إزاحة السطر الأول للفقرة. تقوم هذه الطريقة بنقل السطر الأول فقط بالنسبة لهامش الفقرة الأيسر. قيمة موجبة تحرك السطر الأول إلى اليمين، بينما تظل الأسطر المتبقية محاذاة إلى جسم الفقرة.

استخدم [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/set_marginleft/) عندما تحتاج إلى نقل الفقرة بأكملها. استخدم [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/set_indent/) عندما تحتاج إلى نقل السطر الأول فقط.

يعرض المثال أدناه إنشاء عدة فقرات وتطبيق قيم مختلفة من [IParagraphFormat::set_Indent] لتوضيح كيف تؤثر إزاحة السطر الأول على تخطيط الفقرة.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) مستطيلة إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/) الخاص بالشكل وإزالة الفقرة الافتراضية.
5. إنشاء عدة فقرات وتعيين قيم مختلفة من [IParagraphFormat::set_Indent] لها.
6. إضافة الفقرات إلى إطار النص.
7. حفظ العرض التقديمي المعدل.

هذا الكود يوضح لك كيفية تعيين إزاحة الفقرة:

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

الإزاحة المعلقة هي تخطيط للفقرة حيث يبدأ السطر الأول إلى اليسار من الأسطر المتبقية. في Aspose.Slides، يمكنك إنشاء هذا التأثير باستخدام [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/set_indent/). قم بتعيين الإزاحة إلى قيمة سالبة لتحريك السطر الأول إلى اليسار بالنسبة إلى جسم الفقرة.

عمليًا، [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/set_marginleft/) يحدد الموضع الأيسر لجسم الفقرة، و[IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/set_indent/) يحدد موضع السطر الأول بالنسبة لذلك الهامش. لإنشاء إزاحة معلقة، عيّن قيمة هامش-يسار إيجابية وقيمة إزاحة سالبة.

هذا التنسيق مفيد للمراجع، القوائم الببليوغرافية، مفردات القاموس، وغيرها من الفقرات التي يجب أن تكون الأسطر الملتفة محاذية تحت جسم الفقرة وليس تحت الحرف الأول للسطر الأول.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) مستطيلة إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/) الخاص بالشكل وإزالة الفقرة الافتراضية.
5. إنشاء فقرات وتعيين قيمة إيجابية من [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/set_marginleft/) لكل فقرة.
6. تعيين قيمة سالبة من [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/set_indent/) لإنشاء تأثير الإزاحة المعلقة.
7. إضافة الفقرات إلى إطار النص.
8. حفظ العرض التقديمي المعدل.

هذا الكود يوضح لك كيفية تعيين إزاحة معلقة لفقرة:

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

![إزاحة معلقة للفقرات](hanging_indent.png)

### **تعيين خصائص تشغيل نهاية الفقرة**

[IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) يتحكم في تنسيق علامة نهاية الفقرة. المثال التالي يعيّن حجم الخط والخط اللاتيني لعلامة نهاية الفقرة الثانية:

1. تحميل [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) والوصول إلى شريحة.
2. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) وإزالة الفقرة الافتراضية.
3. إنشاء فقرتين وإضافة جزءات نصية إليهما.
4. إنشاء [PortionFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/portionformat/) لعلامة نهاية الفقرة الثانية.
5. تعيين [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseportionformat/set_fontheight/) و[IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseportionformat/set_latinfont/).
6. ربط التنسيق باستخدام [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) وحفظ العرض التقديمي.

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

## **استيراد وتصدير محتوى الفقرة**

### **استيراد نص HTML إلى الفقرات**

استخدم [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphcollection/addfromhtml/) لتحويل ترميز HTML إلى فقرات وجزءات في إطار النص.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
2. الوصول إلى شريحة وإضافة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/).
3. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/) وإزالة الفقرة الافتراضية.
4. قراءة ملف HTML المصدر.
5. تمرير سلسلة HTML إلى [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphcollection/addfromhtml/).
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

استخدم [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphcollection/exporttohtml/) لتصدير نطاق محدد من الفقرات كملف HTML.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) وتحميل العرض التقديمي المطلوب.
2. الوصول إلى الشريحة والعثور على [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) الذي يحتوي على النص.
3. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/).
4. استدعاء [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphcollection/exporttohtml/) مع مؤشر الفقرة البداية وعدد الفقرات المراد تصديرها.
5. كتابة سلسلة HTML المعادة إلى ملف.

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

### **عرض فقرة كصورة**

[IParagraph::GetImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraph/getimage/) يعرض فقرة فردية مباشرة ويعيد كائن [IImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimage/). احفظ النتيجة إلى ملف أو تدفق باستخدام [IImage::Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimage/save/). لا تحتاج إلى عرض الشكل المحتوي أو قص صورة bitmap يدوياً.

[IParagraph::GetImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraph/getimage/) يمكن أن يعيد `nullptr` إذا لم تُعثر على الفقرة في مجموعة الأم، أو لا توجد حدود عرض صالحة، أو لا يمكن عرضها. تحقق من النتيجة قبل حفظها وتخلص من الصورة المعادة بعد الاستخدام.

#### **عرض فقرة بالمقياس الافتراضي**

لنفترض أن لدينا ملف عرض تقديمي اسمه sample.pptx يحتوي على شريحة واحدة، حيث يكون الشكل الأول مربع نص يحتوي على ثلاث فقرات.

![مربع النص مع ثلاث فقرات](paragraph_to_image_input.png)

المثال التالي يعرض الفقرة الثانية في شكل نص عادي بالمقياس الافتراضي ويحفظ الصورة المعادة بصيغة PNG.

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

#### **عرض فقرة في خلية جدول مع التحجيم**

استخدم نسخة [IParagraph::GetImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraph/getimage/) التي تقبل معلمات `float scaleX` و `float scaleY` لتعيين عوامل التحجيم الأفقي والعمودي. المثال التالي ينشئ جدولًا، يعرض الفقرة في خليةه الأولى بعرض وارتفاع مرتين عن القيم الافتراضية، ويحفظ النتيجة كصورة PNG.

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

عامل التحجيم `1` يحافظ على ذلك المحور بحجمه البكسلي الافتراضي. على سبيل المثال، `2` لكلا العاملين ينتج صورة عرضها وارتفاعها تقريبًا ضعف الأبعاد الافتراضية، ما يؤدي إلى أربعة أضعاف عدد البكسلات. العوامل الأكبر عادةً ما تُنتج نصًا أكثر حدة للزوم أو الإخراج عالي الدقة، لكنها تزيد من استهلاك الذاكرة وحجم الملف. القيم أدنى `1` تُنتج صورًا أصغر بتفاصيل أقل. استخدم عوامل متساوية للحفاظ على نسبة أبعاد الفقرة؛ العوامل الأفقية والعمودية المختلفة تُمدد النتيجة بشكل مستقل.

عرض الشكل كاملًا باستخدام [IShape::GetImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/getimage/) يظل مفيدًا عندما يجب أن يتضمن الإخراج تعبئة الشكل، حدوده، أو سياقًا بصريًا آخر. للصور التي تحتوي على الفقرة فقط، استخدم [IParagraph::GetImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraph/getimage/).

## **الأسئلة الشائعة**

**هل يمكنني تعطيل التفاف السطر بالكامل داخل إطار النص؟**

نعم. استخدم [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/set_wraptext/) لتعطيل الالتفاف بحيث لا تنكسر الأسطر عند حدود إطار النص.

**كيف يمكنني الحصول على الحدود الدقيقة للفقرة على الشريحة؟**

استخدم [IParagraph::GetRect](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraph/getrect/) لاسترجاع مستطيل الحدود الخاص بالفقرة. [IPortion::GetRect](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportion/getrect/) يوفر حدود الجزء الفردي.

**أين يتم التحكم في محاذاة الفقرة (يسار، يمين، وسط أو ضبط)؟**

[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/set_alignment/) هو إعداد على مستوى الفقرة وينطبق على الفقرة بأكملها بغض النظر عن تنسيق الأجزاء الفردية.

**هل يمكنني تعيين لغة التدقيق لجزء من الفقرة؟**

نعم. استخدم [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseportionformat/set_languageid/) للأجزاء الفردية، بحيث يمكن لفقرة واحدة أن تحتوي نصًا بلغات متعددة.