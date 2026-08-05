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
- إدارة النقطة
- مسافة بادئة للفقرة
- مسافة بادئة متدلية
- نقطة الفقرة
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
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "إتقان تنسيق الفقرات مع Aspose.Slides لـ C++ — تحسين المحاذاة والمسافات والنمط في عروض PPT و PPTX و ODP في C++."
---
## **المقدمة**

توفر Aspose.Slides جميع الواجهات والفئات التي تحتاجها للعمل مع نصوص PowerPoint والفقرات والأقسام في C++.

* Aspose.Slides توفر واجهة [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/) لتتيح لك إضافة كائنات تمثل فقرة. يمكن لكائن `ITextFame` أن يحتوي على فقرة واحدة أو متعددة (يتم إنشاء كل فقرة عبر إرجاع السطر).
* Aspose.Slides توفر واجهة [IParagraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraph/) لتتيح لك إضافة كائنات تمثل أقسامًا. يمكن لكائن `IParagraph` أن يحتوي على قسم واحد أو متعددة (مجموعة من كائنات iPortions).
* Aspose.Slides توفر واجهة [IPortion](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportion/) لتتيح لك إضافة كائنات تمثل النصوص وخصائص تنسيقها. 

يمكن لكائن `IParagraph` معالجة النصوص ذات خصائص تنسيق مختلفة عبر كائنات `IPortion` الأساسية.

## **إضافة فقرات متعددة تحتوي على أقسام متعددة**

تظهر هذه الخطوات كيفية إضافة إطار نص يحتوي على 3 فقرات وكل فقرة تحتوي على 3 أقسام:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة مستطيل [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) إلى الشريحة.
4. الحصول على ITextFrame المرتبط بـ [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/).
5. إنشاء كائنين من [IParagraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraph/) وإضافتهما إلى مجموعة `IParagraphs` الخاصة بـ [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/).
6. إنشاء ثلاثة كائنات من [IPortion](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportion/) لكل `IParagraph` جديد (كائنين Portion للفقرة الافتراضية) وإضافة كل كائن `IPortion` إلى مجموعة IPortion الخاصة بكل `IParagraph`.
7. تعيين نص لكل قسم.
8. تطبيق خصائص التنسيق المفضلة على كل قسم باستخدام خصائص التنسيق التي يوفرها كائن `IPortion`.
9. حفظ العرض التقديمي المعدل.

هذا الكود C++ هو تنفيذ للخطوات لإضافة فقرات تحتوي على أقسام: 

```c++
// مسار دليل المستندات.
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// Load the desired the presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Access first slide
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Add an AutoShape of Rectangle type
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Add TextFrame to the Rectangle
SharedPtr<ITextFrame> tf=ashp->AddTextFrame(u" ");


// Accessing the first Paragraph
SharedPtr<IParagraph> para0 = tf->get_Paragraphs()->idx_get(0);
	
SharedPtr<Portion> port01 = MakeObject<Portion>();
SharedPtr<Portion> port02 = MakeObject<Portion>();
para0->get_Portions()->Add(port01);
para0->get_Portions()->Add(port02);

// Adding second Paragraph
SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para1);
SharedPtr<Portion> port10 = MakeObject<Portion>();
SharedPtr<Portion> port11 = MakeObject<Portion>();
SharedPtr<Portion> port12 = MakeObject<Portion>();
para1->get_Portions()->Add(port10);
para1->get_Portions()->Add(port11);
para1->get_Portions()->Add(port12);

// Adding third Paragraph
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para2);
SharedPtr<Portion> port20 = MakeObject<Portion>();
SharedPtr<Portion> port21 = MakeObject<Portion>();
SharedPtr<Portion> port22 = MakeObject<Portion>();
para2->get_Portions()->Add(port20);
para2->get_Portions()->Add(port21);
para2->get_Portions()->Add(port22);


for (int i = 0; i < 3; i++)
{
	for (int j = 0; j < 3; j++)
	{
		tf->get_Paragraphs()->idx_get(i)->get_Portions()->idx_get(j)->set_Text(u"Portion_"+j);
		SharedPtr<IPortionFormat>format = tf->get_Paragraphs()->idx_get(i)->get_Portions()->idx_get(j)->get_PortionFormat();

		if (j == 0)
		{
			format->get_FillFormat()->set_FillType(FillType::Solid);
			format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
			format->set_FontBold(NullableBool::True);
			format->set_FontHeight(15);
		}
		else if (j == 1)
		{
			format->get_FillFormat()->set_FillType(FillType::Solid);
			format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
			format->set_FontBold(NullableBool::True);
			format->set_FontHeight(18);
		}
	}

}

// Save PPTX to Disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **إدارة نقط الفقرات**

قوائم النقط تساعدك على تنظيم وعرض المعلومات بسرعة وكفاءة. الفقرات ذات النقاط دائمًا أسهل في القراءة والفهم.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة [autoshape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) إلى الشريحة المختارة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/) للشكل.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء مثال الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides/paragraph/).
7. تعيين `Type` للنقطة إلى `Symbol` وتعيين حرف النقطة.
8. تعيين `Text` للفقرة.
9. تعيين `Indent` للفقرة للنقطة.
10. تعيين لون للنقطة.
11. تعيين ارتفاع للنقطة.
12. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
13. إضافة الفقرة الثانية وتكرار العملية الموضحة في الخطوات من 7 إلى 13.
14. حفظ العرض التقديمي.

هذا الكود C++ يوضح كيفية إضافة نقطة فقرة: 

```c++
// مسار دليل المستندات.
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// تحميل العرض التقديمي المطلوب.
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى.
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// إضافة AutoShape من نوع مستطيل.
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// إضافة TextFrame إلى المستطيل.
ashp->AddTextFrame(u"");

// الوصول إلى إطار النص.
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// إنشاء كائن الفقرة لإطار النص.
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

// تعيين النص.
paragraph->set_Text(u"Welcome to Aspose.Slides");

// تعيين إزاحة النقطة.
paragraph->get_ParagraphFormat()->set_Indent (25);

// تعيين لون النقطة.
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
// تعيين IsBulletHardColor إلى true لاستخدام لون النقطة الخاص.
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// تعيين ارتفاع النقطة.
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// إضافة الفقرة إلى إطار النص.
txtFrame->get_Paragraphs()->Add(paragraph);

// إنشاء الفقرة الثانية.
 // إنشاء كائن الفقرة لإطار النص.
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

// تعيين النص.
paragraph2->set_Text(u"This is numbered bullet");

// تعيين نوع الفقرة ونمط النقطة.
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// تعيين إزاحة النقطة.
paragraph2->get_ParagraphFormat()->set_Indent(25);

// تعيين لون النقطة.
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// تعيين IsBulletHardColor إلى true لاستخدام لون النقطة الخاص.
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// تعيين ارتفاع النقطة.
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// إضافة الفقرة إلى إطار النص.
txtFrame->get_Paragraphs()->Add(paragraph2);


// حفظ PPTX إلى القرص.
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **إدارة نقط الصورة**

قوائم النقط تساعدك على تنظيم وعرض المعلومات بسرعة وكفاءة. فقرات الصور سهلة القراءة والفهم.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة [autoshape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/) للشكل.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء مثال الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides/paragraph/).
7. تحميل الصورة في [IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/).
8. تعيين نوع النقطة إلى [Picture](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/) وتعيين الصورة.
9. تعيين `Text` للفقرة.
10. تعيين `Indent` للفقرة للنقطة.
11. تعيين لون للنقطة.
12. تعيين ارتفاع للنقطة.
13. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
14. إضافة الفقرة الثانية وتكرار العملية بناءً على الخطوات السابقة.
15. حفظ العرض التقديمي المعدل.

هذا الكود C++ يوضح كيفية إضافة وإدارة نقط الصور: 

```c++
// إنشاء كائن من فئة Presentation تمثل ملف PPTX
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// إنشاء صورة للنقاط
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// إضافة والوصول إلى الشكل التلقائي (AutoShape)
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// الوصول إلى إطار النص للشكل التلقائي
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// إزالة الفقرة الافتراضية
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// إنشاء فقرة جديدة
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");

// تعيين نمط نقطة الفقرة والصورة
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// تعيين ارتفاع النقطة
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// إضافة الفقرة إلى إطار النص
paragraphs->Add(paragraph);

// حفظ العرض التقديمي كملف PPTX
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// حفظ العرض التقديمي كملف PPT
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```

## **إدارة النقاط المتعددة المستويات**

قوائم النقط تساعدك على تنظيم وعرض المعلومات بسرعة وكفاءة. النقاط متعددة المستويات سهلة القراءة والفهم.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة [autoshape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) في الشريحة الجديدة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/) للشكل.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء مثال الفقرة الأولى عبر فئة [Paragraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides/paragraph/) وتعيين العمق إلى 0.
7. إنشاء مثال الفقرة الثانية عبر فئة `Paragraph` وتعيين العمق إلى 1.
8. إنشاء مثال الفقرة الثالثة عبر فئة `Paragraph` وتعيين العمق إلى 2.
9. إنشاء مثال الفقرة الرابعة عبر فئة `Paragraph` وتعيين العمق إلى 3.
10. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
11. حفظ العرض التقديمي المعدل.

هذا الكود C++ يوضح كيفية إضافة وإدارة النقاط متعددة المستويات: 

```c++
// إنشاء كائن من فئة Presentation يمثل ملف PPTX
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// إضافة والوصول إلى الشكل التلقائي (AutoShape)
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// الوصول إلى إطار النص للشكل التلقائي المُنشأ
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// مسح الفقرة الافتراضية
text->get_Paragraphs()->Clear();

// إضافة الفقرة الأولى
System::SharedPtr<IParagraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Content");
System::SharedPtr<IParagraphFormat> para1Format = para1->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet1Format = para1Format->get_Bullet();
bullet1Format->set_Type(BulletType::Symbol);
bullet1Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat1 = para1Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat1->set_FillType(FillType::Solid);
defaultFillFormat1->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// تعيين مستوى النقطة
para1Format->set_Depth(0);

// إضافة الفقرة الثانية
System::SharedPtr<IParagraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Second Level");
System::SharedPtr<IParagraphFormat> para2Format = para2->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet2Format = para2Format->get_Bullet();
bullet2Format->set_Type(BulletType::Symbol);
bullet2Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat2 = para2Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat2->set_FillType(FillType::Solid);
defaultFillFormat2->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// تعيين مستوى النقطة
para2Format->set_Depth(1);

// إضافة الفقرة الثالثة
System::SharedPtr<IParagraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"Third Level");
System::SharedPtr<IParagraphFormat> para3Format = para3->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet3Format = para3Format->get_Bullet();
bullet3Format->set_Type(BulletType::Symbol);
bullet3Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat3 = para3Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat3->set_FillType(FillType::Solid);
defaultFillFormat3->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// تعيين مستوى النقطة
para3Format->set_Depth(2);

// إضافة الفقرة الرابعة
System::SharedPtr<IParagraph> para4 = System::MakeObject<Paragraph>();
para4->set_Text(u"Fourth Level");
System::SharedPtr<IParagraphFormat> para4Format = para4->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet4Format = para4Format->get_Bullet();
bullet4Format->set_Type(BulletType::Symbol);
bullet4Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat4 = para4Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat4->set_FillType(FillType::Solid);
defaultFillFormat4->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// تعيين مستوى النقطة
para4Format->set_Depth(3);

// إضافة الفقرات إلى المجموعة
System::SharedPtr<IParagraphCollection> paragraphs = text->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);
paragraphs->Add(para4);

// حفظ العرض التقديمي كملف PPTX
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```

## **إدارة فقرة بقائمة مرقمة مخصصة**

توفر واجهة [IBulletFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibulletformat/) الخاصية [NumberedBulletStartWith](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) وغيرها التي تتيح لك إدارة الفقرات ذات الترقيم أو التنسيق المخصص.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
2. الوصول إلى الشريحة التي تحتوي على الفقرة.
3. إضافة [autoshape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/) للشكل.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء مثال الفقرة الأولى عبر فئة [Paragraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides/paragraph/) وتعيين [NumberedBulletStartWith](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) إلى 2.
7. إنشاء مثال الفقرة الثانية عبر فئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 3.
8. إنشاء مثال الفقرة الثالثة عبر فئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 7.
9. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
10. حفظ العرض التقديمي المعدل.

هذا الكود C++ يوضح كيفية إضافة وإدارة الفقرات ذات الترميز أو التنسيق المخصص: 

```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// الوصول إلى إطار النص للشكل التلقائي المُنشأ
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// يزيل الفقرة الافتراضية الموجودة
textFrame->get_Paragraphs()->RemoveAt(0);

// القائمة الأولى
auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->set_Text(u"bullet 2");
auto paragraph1Format = paragraph1->get_ParagraphFormat();
paragraph1Format->set_Depth(4);
auto bullet1Format = paragraph1Format->get_Bullet();
bullet1Format->set_NumberedBulletStartWith(2);
bullet1Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->set_Text(u"bullet 3");
auto paragraph2Format = paragraph2->get_ParagraphFormat();
paragraph2Format->set_Depth(4);
auto bullet2Format = paragraph2Format->get_Bullet();
bullet2Format->set_NumberedBulletStartWith(3);
bullet2Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph5 = System::MakeObject<Paragraph>();
paragraph5->set_Text(u"bullet 7");
auto paragraph5Format = paragraph5->get_ParagraphFormat();
paragraph5Format->set_Depth(4);
auto bullet5Format = paragraph5Format->get_Bullet();
bullet5Format->set_NumberedBulletStartWith(7);
bullet5Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph5);

presentation->Save(u"SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
```

## **ضبط مسافة البادئة للخط الأول للفقرة**

استخدم الطريقة [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/set_indent/) للتحكم في مسافة البادئة للخط الأول للفقرة. هذه الطريقة تحرك فقط السطر الأول بالنسبة لهامش الشريحة الأيسر. القيمة الموجبة تحرك السطر الأول إلى اليمين، بينما تظل الأسطر المتبقية محاذية إلى جسم الفقرة.

استخدم [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/set_marginleft/) عندما تحتاج إلى تحريك الفقرة بأكملها. استخدم [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/set_indent/) عندما تحتاج إلى تحريك السطر الأول فقط.

المثال أدناه ينشئ عدة فقرات ويطبق قيم `Indent` مختلفة لتوضيح تأثير مسافة البادئة للخط الأول على تخطيط الفقرة.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. إضافة [TextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/textframe/) فارغ إلى الشكل وإزالة الفقرة الافتراضية.
5. إنشاء عدة فقرات وتعيين قيم مختلفة لـ [Indent](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/set_indent/) لها.
6. إضافة الفقرات إلى إطار النص.
7. حفظ العرض التقديمي المعدل.

هذا الكود يوضح كيفية ضبط مسافة بادئة للفقرة:

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto rectangleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
rectangleShape->get_FillFormat()->set_FillType(FillType::NoFill);
rectangleShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
rectangleShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = rectangleShape->AddTextFrame(u"");
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->RemoveAt(0);

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->set_Text(u"No first-line indent. Wrapped lines start at the same position as the first line.");
firstParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
firstParagraph->get_ParagraphFormat()->set_Indent(0.f);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->set_Text(u"First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
secondParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
secondParagraph->get_ParagraphFormat()->set_Indent(20.f);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->set_Text(u"First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
thirdParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
thirdParagraph->get_ParagraphFormat()->set_Indent(40.f);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"paragraph_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![المسافة البادئة للخط الأول في الفقرات](first_line_indent.png)

## **ضبط مسافة البادئة المتدلية للفقرة**

المسافة المتدلية هي تخطيط فقرة يبدأ فيه السطر الأول إلى يسار الأسطر المتبقية. في Aspose.Slides، يمكنك إنشاء هذا التأثير باستخدام الطريقة [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/set_indent/). اضبط البادئة إلى قيمة سالبة لتحريك السطر الأول إلى اليسار بالنسبة إلى جسم الفقرة.

عمليًا، تحدد [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/set_marginleft/) موضع الجهة اليسرى لجسم الفقرة، وتحدد [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/set_indent/) موضع السطر الأول بالنسبة إلى ذلك الهامش. لإنشاء مسافة متدلية، اضبط قيمة `MarginLeft` إلى قيمة موجبة وقيمة `Indent` إلى قيمة سالبة.

هذا التنسيق مفيد للمراجع، الاقتباسات، مدخلات القاموس، وغيرها من الفقرات التي يجب أن تكون الأسطر الملتفة تحت جسم الفقرة وليس تحت الحرف الأول للسطر الأول.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. إضافة [TextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/textframe/) فارغ إلى الشكل وإزالة الفقرة الافتراضية.
5. إنشاء فقرات وتعيين قيمة `MarginLeft` موجبة لكل فقرة.
6. تعيين قيمة `Indent` سالبة لإنشاء تأثير المسافة المتدلية.
7. إضافة الفقرات إلى إطار النص.
8. حفظ العرض التقديمي المعدل.

هذا الكود يوضح كيفية ضبط مسافة متدلية للفقرة:

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto rectangleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
rectangleShape->get_FillFormat()->set_FillType(FillType::NoFill);
rectangleShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
rectangleShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = rectangleShape->AddTextFrame(u"");
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->RemoveAt(0);

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->set_Text(u"A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
firstParagraph->get_ParagraphFormat()->set_MarginLeft(40.f);
firstParagraph->get_ParagraphFormat()->set_Indent(-20.f);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->set_Text(u"This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
secondParagraph->get_ParagraphFormat()->set_MarginLeft(60.f);
secondParagraph->get_ParagraphFormat()->set_Indent(-30.f);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![المسافة المتدلية للفقرات](hanging_indent.png)

## **إدارة خصائص تشغيل الفقرة النهائية**

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
1. الحصول على مرجع الشريحة التي تحتوي على الفقرة عبر موقعها.
1. إضافة [autoshape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) مستطيل إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/) يحتوي على فقرتين إلى المستطيل.
1. تعيين `FontHeight` ونوع الخط للفقرات.
1. تعيين الخصائص النهائية للفقرات.
1. كتابة العرض التقديمي المعدل كملف PPTX.

هذا الكود C++ يوضح كيفية تعيين الخصائص النهائية للفقرات في PowerPoint: 

```c++
// مسار دليل المستندات.
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// تحميل العرض التقديمي المطلوب
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// إضافة AutoShape من نوع مستطيل
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// إضافة TextFrame إلى المستطيل
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// إضافة الفقرة الأولى
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Sample text");

para1->get_Portions()->Add(port01);

// إضافة الفقرة الثانية
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"Sample text 2");

para2->get_Portions()->Add(port02);


SharedPtr<PortionFormat> endParagraphPortionFormat = MakeObject< PortionFormat>();
endParagraphPortionFormat->set_FontHeight ( 48);
endParagraphPortionFormat->set_LatinFont ( MakeObject< FontData>(u"Times New Roman"));
para2->set_EndParagraphPortionFormat(endParagraphPortionFormat);

ashp->get_TextFrame()->get_Paragraphs()->Add(para1);
ashp->get_TextFrame()->get_Paragraphs()->Add(para2);



// حفظ PPTX إلى القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **استيراد نص HTML إلى الفقرات**

توفر Aspose.Slides دعمًا محسّنًا لاستيراد نص HTML إلى الفقرات.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة [autoshape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) إلى الشريحة.
4. إضافة الوصول إلى `autoshape` [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/) 
5. إزالة الفقرة الافتراضية في `ITextFrame`.
6. قراءة ملف HTML المصدر في TextReader.
7. إنشاء مثال الفقرة الأولى عبر فئة [Paragraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides/paragraph/).
8. إضافة محتوى ملف HTML من TextReader إلى [ParagraphCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/paragraphcollection/) الخاص بـ TextFrame.
9. حفظ العرض التقديمي المعدل.

هذا الكود C++ هو تنفيذ للخطوات لاستيراد نصوص HTML إلى الفقرات: 

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// مسار دليل المستندات.
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
	// تحميل العرض التقديمي المطلوب
SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// الوصول إلى الشريحة الأولى
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

	// إضافة AutoShape من نوع مستطيل
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
	//إعادة تعيين لون التعبئة الافتراضي
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
	// إضافة TextFrame إلى المستطيل
ashp->AddTextFrame(u" ");

// الوصول إلى إطار النص
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

// الحصول على مجموعة الفقرات
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// مسح جميع الفقرات في إطار النص المضاف
ParaCollection->Clear();

// تحميل ملف HTML باستخدام قارئ الدفق
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// إضافة النص من قارئ الدفق HTML إلى إطار النص
ParaCollection->AddFromHtml(tr->ReadToEnd());


// إنشاء كائن الفقرة لإطار النص
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// إنشاء كائن Portion للفقرة
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

// الحصول على تنسيق الجزء
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// تعيين الخط للجزء
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// تعيين خاصية الخط العريض
pf->set_FontBold(NullableBool::True);

// تعيين خاصية الخط المائل
pf->set_FontItalic(NullableBool::True);

// تعيين خاصية الخط المسطر
pf->set_FontUnderline(TextUnderlineType::Single);

// تعيين ارتفاع الخط
pf->set_FontHeight(25);

// تعيين لون الخط
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// حفظ PPTX إلى القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **تصدير نص الفقرة إلى HTML**

توفر Aspose.Slides دعمًا محسّنًا لتصدير النصوص (الموجودة في الفقرات) إلى HTML.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) وتحميل العرض التقديمي المطلوب.
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. الوصول إلى الشكل الذي يحتوي على النص الذي سيُصدّر إلى HTML.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/) الخاص بالشكل.
5. إنشاء مثال من `StreamWriter` وإضافة ملف HTML الجديد.
6. توفير فهرس بدء إلى StreamWriter وتصدير الفقرات المفضلة لديك.

هذا الكود C++ يوضح كيفية تصدير نصوص فقرات PowerPoint إلى HTML: 

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// مسار دليل المستندات.
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// Load the desired the presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// Acesss the default first slide of presentation
// الوصول إلى الشريحة الأولى الافتراضية في العرض التقديمي
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Desired index
// الفهرس المطلوب
int index = 0;

// Accessing the added shape
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// Extracting first paragraph as HTML
// استخراج الفقرة الأولى كـ HTML
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

//Writing Paragraphs data to HTML by providing paragraph starting index, total paragraphs to be copied
// كتابة بيانات الفقرات إلى HTML بتحديد فهرس بدء الفقرة وعدد الفقرات المراد نسخها
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();

```

## **حفظ الفقرة كصورة**

في هذا القسم، سنستعرض مثالين يوضحان كيفية حفظ فقرة نصية، ممثلة بواجهة [IParagraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraph/)، كصورة. كلا المثالين يتضمنان الحصول على صورة الشكل الذي يحتوي الفقرة باستخدام طرق `GetImage` من واجهة [IShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/)، حساب حدود الفقرة داخل الشكل، وتصديرها كصورة bitmap. تسمح لك هذه الأساليب باستخلاص أجزاء معينة من النص من عروض PowerPoint وحفظها كصور منفصلة، مما قد يكون مفيدًا لاستخدامات أخرى.

لنفترض أن لدينا ملف عرض تقديمي اسمه **sample.pptx** يحتوي على شريحة واحدة، حيث الشكل الأول هو مربع نص يحتوي على ثلاث فقرات.

![مربع النص مع ثلاث فقرات](paragraph_to_image_input.png)

**مثال 1**

في هذا المثال نحصل على الفقرة الثانية كصورة. للقيام بذلك، نستخرج صورة الشكل من الشريحة الأولى للعرض ثم نحسب حدود الفقرة الثانية في إطار النص داخل الشكل. تُعاد رسم الفقرة على صورة bitmap جديدة تُحفظ بصيغة PNG. هذه الطريقة مفيدة عند الحاجة لحفظ فقرة معينة كصورة منفصلة مع الحفاظ على أبعادها وتنسيقها الأصلي.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Save the shape in memory as a bitmap.
auto shapeImage = firstShape->GetImage();
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Create a shape bitmap from memory.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Calculate the boundaries of the second paragraph.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();

// Calculate the size for the output image (minimum size - 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Prepare a bitmap for the paragraph.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

النتيجة:

![صورة الفقرة](paragraph_to_image_output.png)

**مثال 2**

في هذا المثال نُوسّع النهج السابق بإضافة عوامل مقياس إلى صورة الفقرة. يُستخرج الشكل من العرض ويُحفظ كصورة بمعامل مقياس `2`. يتيح ذلك إخراجًا بدقة أعلى عند تصدير الفقرة. ثم تُحسب حدود الفقرة مع الأخذ في الاعتبار المقياس. يمكن أن يكون المقياس مفيدًا عندما يلزم الحصول على صورة ذات جودة تفاصيل أعلى، مثالًا على ذلك الاستخدام في مواد مطبوعة عالية الجودة.

```cpp
auto imageScaleX = 2.0f;
auto imageScaleY = imageScaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// حفظ الشكل في الذاكرة كصورة bitmap مع التحجيم.
auto shapeImage = firstShape->GetImage(ShapeThumbnailBounds::Shape, imageScaleX, imageScaleY);
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Create a shape bitmap from memory.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Calculate the boundaries of the second paragraph.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();
paragraphRectangle.set_X(paragraphRectangle.get_X() * imageScaleX);
paragraphRectangle.set_Y(paragraphRectangle.get_Y() * imageScaleY);
paragraphRectangle.set_Width(paragraphRectangle.get_Width() * imageScaleX);
paragraphRectangle.set_Height(paragraphRectangle.get_Height() * imageScaleY);

// Calculate the size for the output image (minimum size - 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Prepare a bitmap for the paragraph.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

## **الأسئلة الشائعة**

**هل يمكنني إلغاء تمكين التفاف السطر داخل إطار النص تمامًا؟**

نعم. استخدم طريقة التفاف النص في إطار النص ([set_WrapText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/textframeformat/set_wraptext/)) لإيقاف التفاف السطور بحيث لا تنكسر عند حواف الإطار.

**كيف يمكنني الحصول على الحدود الدقيقة للفقرة على الشريحة؟**

يمكنك استرجاع المستطيل المحيط بالفقرة (وحتى بقسم واحد) لتحديد موقعها الدقيق وحجمها على الشريحة.

**أين يتم التحكم في محاذاة الفقرة (يسار/يمين/منتصف/ضبط)?**

[Alignment](https://reference.aspose.com/slides/ar/cpp/aspose.slides/paragraphformat/set_alignment/) هو إعداد على مستوى الفقرة في [ParagraphFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/paragraphformat/); يُطبق على الفقرة بأكملها بغض النظر عن تنسيق الأقسام الفردية.

**هل يمكنني تعيين لغة تدقيق إملائي لجزء فقط من الفقرة (مثل كلمة واحدة)؟**

نعم. يتم تعيين اللغة على مستوى القسم باستخدام ([PortionFormat::set_LanguageId](https://reference.aspose.com/slides/ar/cpp/aspose.slides/baseportionformat/set_languageid/)), لذلك يمكن وجود لغات متعددة داخل نفس الفقرة.