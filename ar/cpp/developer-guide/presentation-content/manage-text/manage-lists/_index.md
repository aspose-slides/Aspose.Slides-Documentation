---
title: إدارة القوائم المنقطة والمرقمة في العروض التقديمية بلغة C++
linktitle: إدارة القوائم
type: docs
weight: 70
url: /ar/cpp/manage-lists/
keywords:
- نقطة
- قائمة منقطة
- قائمة مرقمة
- نقطة رمزية
- نقطة صورة
- نقطة مخصصة
- قائمة متعددة المستويات
- إنشاء نقطة
- إضافة نقطة
- إضافة قائمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية إنشاء وتنسيق القوائم المنقطة، وصور النقاط، والقوائم متعددة المستويات، والقوائم المرقمة في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة C++."
---
## **نظرة عامة**

تتيح لك Aspose.Slides للـ C++ إنشاء وتنسيق القوائم ذات النقاط والترقيم في عروض PowerPoint وOpenDocument. عنصر القائمة هو فقرة يتم التحكم في إعدادات النقطة الخاصة به عبر تنسيق الفقرة.

استخدم طريقة [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraph/get_paragraphformat/) للوصول إلى إعدادات القائمة على مستوى الفقرة. نقطة الدخول الرئيسية هي [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/get_bullet/)، والتي تُرجِع كائنًا من نوع [IBulletFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibulletformat/). باستخدام هذا الكائن، يمكنك تعيين نوع النقطة، الرمز، الصورة، اللون، الحجم، نمط الترقيم، ورقم البداية.

تظهر هذه المقالة كيفية:

- إنشاء قائمة منقطة برمز مخصص
- إنشاء نقطة على شكل صورة
- إنشاء قائمة متعددة المستويات عن طريق تعيين عمق الفقرة
- إنشاء قائمة مرقمة
- فحص وتغيير تنسيق القائمة في عرض تقديمي موجود

## **إنشاء قائمة منقطة**

لإنشاء قائمة منقطة، أضف كائنات [Paragraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides/paragraph/) إلى [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/) وقم بتعيين [IBulletFormat::set_Type](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibulletformat/set_type/) إلى [BulletType::Symbol](https://reference.aspose.com/slides/ar/cpp/aspose.slides/bullettype/). بعد ذلك يمكنك تعيين [IBulletFormat::set_Char](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibulletformat/set_char/)، [IBulletFormat::get_Color](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibulletformat/get_color/)، و[IBulletFormat::set_Height](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibulletformat/set_height/) للتحكم في مظهر النقطة.

الكود التالي بلغة C++ يوضح كيفية إنشاء قائمة منقطة في شريحة:

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

النتيجة:

![الرموز النقطية](symbol_bullets.png)

## **إنشاء قائمة مرقمة**

استخدم القوائم المرقمة عندما يكون ترتيب العناصر مهمًا. قم بتعيين [IBulletFormat::set_Type](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibulletformat/set_type/) إلى [BulletType::Numbered](https://reference.aspose.com/slides/ar/cpp/aspose.slides/bullettype/). يمكنك أيضًا اختيار تنسيق الترقيم باستخدام [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) أو تعيين [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) عندما يجب أن يبدأ القائمة من قيمة غير 1.

الكود التالي بلغة C++ يوضح كيفية إنشاء قائمة مرقمة في شريحة:

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

النتيجة:

![النقاط المرقمة](numbered_bullets.png)

## **إنشاء نقطة صورة**

تتيح لك Aspose.Slides استبدال رمز النقطة العادية بصورة. تعمل نقاط الصورة بشكل أفضل مع صور بسيطة تظل مقروءة بحجم صغير، مثل الأيقونات أو ملفات PNG الشفافة الصغيرة.

{{% alert color="info" %}}
من الناحية المثالية، إذا كنت تخطط لاستبدال رمز النقطة العادية بصورة، فمن الأفضل اختيار رسم بسيط بخلفية شفافة. هذه الصور تعمل جيدًا كرموز نقاط مخصصة.
{{% /alert %}}

لإنشاء نقطة صورة، أضف صورة إلى [IPresentation::get_Images](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/get_images/) وعيّن الكائن [IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/) المعاد إلى [IBulletFormat::get_Picture](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibulletformat/get_picture/). قم بتعيين [IBulletFormat::set_Type](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibulletformat/set_type/) إلى [BulletType::Picture](https://reference.aspose.com/slides/ar/cpp/aspose.slides/bullettype/) قبل تعيين الصورة.

لنفترض أن لدينا ملف "image.png":

![صورة للنقاط](picture_for_bullets.png)

الكود التالي بلغة C++ يوضح كيفية إنشاء نقاط صورة في شريحة:

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

النتيجة:

![نقاط الصورة](picture_bullets.png)

## **إنشاء قائمة متعددة المستويات**

استخدم [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/set_depth/) لتحديد عناصر القائمة على مستويات مختلفة. المستوى 0 هو المستوى الأعلى، المستوى 1 هو المستوى الفرعي تحته، وهكذا.

الكود التالي بلغة C++ يوضح كيفية إنشاء قائمة منقطة متعددة المستويات:

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

النتيجة:

![القائمة متعددة المستويات](multilevel_list.png)

## **تغيير قائمة موجودة**

لتغيير تنسيق القائمة في عرض تقديمي موجود، قم بالوصول إلى الفقرة المستهدفة وتحديث إعدادات [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/get_bullet/) الخاصة بها. يمكن استخدام نفس الخصائص المستخدمة لإنشاء القوائم لفحص أو تعديل القوائم التي تم تحميلها من ملف PPT أو PPTX أو ODP.

الكود التالي بلغة C++ يغيّر الفقرة الأولى في إطار نص لاستخدام نمط قائمة مرقمة:

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

## **الأسئلة الشائعة**

### هل يمكن تصدير القوائم المنقطة والمرقمة إلى PDF أو صور؟

نعم. تحافظ Aspose.Slides على تنسيق القوائم عندما يدعم تنسيق الهدف تخطيط النص والخصائص المرتبطة بالنقاط.

### هل يمكنني تعديل القوائم في عروض تقديمية موجودة؟

نعم. قم بتحميل العرض التقديمي، وصول إلى الفقرة المستهدفة، افحص أو حدّث إعدادات [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/get_bullet/)، ثم احفظ العرض التقديمي.

### هل يمكن للقوائم أن تحتوي على نص غير لاتيني؟

نعم. يمكن أن يحتوي نص عنصر القائمة على أحرف يونيكود، وبالتالي يمكنك إنشاء قوائم في عروض متعددة اللغات. تأكد من أن الخطوط المستخدمة في العرض تدعم الأحرف التي تحتاجها.