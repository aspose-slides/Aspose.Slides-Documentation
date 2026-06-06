---
title: إدارة القوائم النقطية والمرقمة في العروض التقديمية بلغة C++
linktitle: إدارة القوائم
type: docs
weight: 70
url: /ar/cpp/manage-lists/
keywords:
- نقطة
- قائمة نقطية
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
description: "تعرف على كيفية إنشاء وتنسيق القوائم النقطية، والقوائم المصورة، والقوائم متعددة المستويات، والقوائم المرقمة في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة C++."
---
## **نظرة عامة**

تتيح لك Aspose.Slides للغة C++ إنشاء وتنسيق القوائم ذات الرصاص والقوائم المرقمة في عروض PowerPoint وOpenDocument. عنصر القائمة هو فقرة تُتحكم إعدادات الرصاص الخاصة بها عبر تنسيق الفقرة الخاص بها.

استخدم الطريقة [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraph/get_paragraphformat/) للوصول إلى إعدادات القائمة على مستوى الفقرة. نقطة الدخول الرئيسية هي [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/get_bullet/)، والتي تُعيد كائنًا من نوع [IBulletFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibulletformat/). باستخدام هذا الكائن، يمكنك تعيين نوع الرصاص، الرمز، الصورة، اللون، الحجم، نمط الترقيم، ورقم البداية.

توضع هذه المقالة لتوضيح كيفية:

- إنشاء قائمة ذات رصاص برمز مخصص
- إنشاء رصاص بصورة
- إنشاء قائمة متعددة المستويات عن طريق تعيين عمق الفقرة
- إنشاء قائمة مرقمة
- فحص وتغيير تنسيق القائمة في عرض تقديمي موجود

## **إنشاء قائمة ذات رصاص**

لإنشاء قائمة ذات رصاص، أضف كائنات [Paragraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides/paragraph/) إلى [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/) وعيّن [IBulletFormat::set_Type](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibulletformat/set_type/) إلى [BulletType::Symbol](https://reference.aspose.com/slides/ar/cpp/aspose.slides/bullettype/). بعد ذلك يمكنك تعيين [IBulletFormat::set_Char](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibulletformat/set_char/)، [IBulletFormat::get_Color](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibulletformat/get_color/)، و[IBulletFormat::set_Height](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibulletformat/set_height/) للتحكم في مظهر الرصاص.

الرمز التالي بلغة C++ يوضح كيفية إنشاء قائمة ذات رصاص في شريحة:

```cpp
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

استخدم القوائم المرقمة عندما يكون ترتيب العناصر مهمًا. عيّن [IBulletFormat::set_Type](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibulletformat/set_type/) إلى [BulletType::Numbered](https://reference.aspose.com/slides/ar/cpp/aspose.slides/bullettype/). يمكنك أيضًا اختيار تنسيق الترقيم باستخدام [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) أو تعيين [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) عندما يجب أن تبدأ القائمة بقيمة غير 1.

الرمز التالي بلغة C++ يوضح كيفية إنشاء قائمة مرقمة في شريحة:

```cpp
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

![الرموز المرقمة](numbered_bullets.png)

## **إنشاء رصاص صورة**

تسمح لك Aspose.Slides باستبدال رمز الرصاص العادي بصورة. تعمل رصاصات الصورة بشكل أفضل مع الصور البسيطة التي تبقى قابلة للقراءة بحجم صغير، مثل الأيقونات أو ملفات PNG الشفافة الصغيرة.

{{% alert color="primary" %}}
من الناحية المثالية، إذا كنت تخطط لاستبدال رمز الرصاص العادي بصورة، فمن الأفضل اختيار رسم بسيط بخلفية شفافة. تعمل هذه الصور جيدًا كرموز رصاص مخصصة.

تذكر أن الصورة سيتم تصغيرها إلى حجم صغير جدًا. لهذا السبب نوصي بشدة باختيار صورة تظل واضحة وفعالة بصريًا عند استخدامها كرصاص في قائمة.
{{% /alert %}}

لإنشاء رصاص صورة، أضف صورة إلى [IPresentation::get_Images](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/get_images/) وعيّن الكائن [IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/) المرتجع إلى [IBulletFormat::get_Picture](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibulletformat/get_picture/). عيّن [IBulletFormat::set_Type](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibulletformat/set_type/) إلى [BulletType::Picture](https://reference.aspose.com/slides/ar/cpp/aspose.slides/bullettype/) قبل تعيين الصورة.

لنفترض أن لدينا ملف "image.png":

![صورة للرصاص](picture_for_bullets.png)

الرمز التالي بلغة C++ يوضح كيفية إنشاء رصاصات صورة في شريحة:

```cpp
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

![رصاصات الصورة](picture_bullets.png)

## **إنشاء قائمة متعددة المستويات**

استخدم [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/set_depth/) لتحديد عناصر القائمة على مستويات مختلفة. المستوى 0 هو المستوى الأعلى، المستوى 1 هو متداخَل تحته، وهكذا.

الرمز التالي بلغة C++ يوضح كيفية إنشاء قائمة ذات رصاص متعددة المستويات:

```cpp
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

لتغيير تنسيق القائمة في عرض تقديمي موجود، احصل على الفقرة المستهدفة وقم بتحديث إعدادات [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/get_bullet/) الخاصة بها. يمكن استخدام نفس الخصائص المستخدمة لإنشاء القوائم لتفقد أو تعديل القوائم المحملة من ملف PPT أو PPTX أو ODP.

الرمز التالي بلغة C++ يغيّر الفقرة الأولى في إطار نص لاستخدام نمط القائمة المرقمة:

```cpp
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

**هل يمكن تصدير القوائم ذات الرصاص والمرقمة إلى PDF أو صور؟**

نعم. تقوم Aspose.Slides بالحفاظ على تنسيق القائمة عندما يدعم التنسيق المستهدف تخطيط النص والميزات الخاصة بالرصاص ذات الصلة.

**هل يمكنني تحرير القوائم في العروض التقديمية الموجودة؟**

نعم. حمّل العرض التقديمي، احصل على الفقرة المستهدفة، تفقد أو حدّث إعدادات [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/get_bullet/)، ثم احفظ العرض التقديمي.

**هل يمكن أن تحتوي القوائم على نص غير لاتيني؟**

نعم. يمكن أن يحتوي نص عنصر القائمة على أحرف Unicode، لذا يمكنك إنشاء قوائم في عروض تقديمية متعددة اللغات. تأكد من أن الخطوط المستخدمة في العرض التقديمي تدعم الأحرف التي تحتاجها.