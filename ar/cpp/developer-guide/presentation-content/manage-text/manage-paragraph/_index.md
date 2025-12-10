---
title: إدارة فقرات نص PowerPoint في C++
linktitle: إدارة الفقرة
type: docs
weight: 40
url: /ar/cpp/manage-paragraph/
keywords:
- إضافة نص
- إضافة فقرة
- إدارة النص
- إدارة الفقرة
- إدارة النقاط
- إزاحة الفقرة
- إزاحة معلقة
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
description: "تحكم في تنسيق الفقرات باستخدام Aspose.Slides للـ C++ - حسّن المحاذاة، التباعد والأسلوب في عروض PPT، PPTX و ODP باستخدام C++."
---

توفر Aspose.Slides جميع الواجهات والفئات التي تحتاجها للعمل مع نصوص PowerPoint والفقرات والأجزاء في C++.

* توفر Aspose.Slides واجهة [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) لتسمح لك بإضافة كائنات تمثل فقرة. يمكن لكائن `ITextFame` أن يحتوي على فقرة واحدة أو متعددة (كل فقرة تُنشأ عبر عودة السطر).
* توفر Aspose.Slides واجهة [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) لتسمح لك بإضافة كائنات تمثل أجزاء. يمكن لكائن `IParagraph` أن يحتوي على جزء واحد أو متعددة (مجموعة من كائنات iPortions).
* توفر Aspose.Slides واجهة [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) لتسمح لك بإضافة كائنات تمثل النصوص وخصائص التنسيق الخاصة بها.

يمكن لكائن `IParagraph` التعامل مع النصوص ذات خصائص تنسيق مختلفة عبر كائنات `IPortion` المتضمنة.

## **إضافة فقرات متعددة تحتوي على أجزاء متعددة**

توضح هذه الخطوات كيفية إضافة إطار نص يحتوي على 3 فقرات، وكل فقرة تحتوي على 3 أجزاء:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة مستطيل [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى الشريحة.
4. الحصول على ITextFrame المرتبط بـ [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).
5. إنشاء كائنين من نوع [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) وإضافتهما إلى مجموعة `IParagraphs` الخاصة بـ [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/).
6. إنشاء ثلاثة كائنات من نوع [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) لكل `IParagraph` جديد (كائنان من النوع Portion للفقرة الافتراضية) وإضافة كل كائن `IPortion` إلى مجموعة IPortion الخاصة بكل `IParagraph`.
7. تعيين نص لكل جزء.
8. تطبيق ميزات التنسيق المفضلة لكل جزء باستخدام خصائص التنسيق التي يوفرها كائن `IPortion`.
9. حفظ العرض التقديمي المعدل.

هذا الكود C++ هو تنفيذ للخطوات الخاصة بإضافة فقرات تحتوي على أجزاء: 
```c++
// مسار مجلد المستندات.
const String outPath = u"../out/MultipleParagraphs_out.pptx";


// تحميل العرض التقديمي المطلوب
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// إضافة AutoShape من النوع مستطيل
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// إضافة TextFrame إلى المستطيل
SharedPtr<ITextFrame> tf=ashp->AddTextFrame(u" ");


// الوصول إلى الفقرة الأولى
SharedPtr<IParagraph> para0 = tf->get_Paragraphs()->idx_get(0);
	
SharedPtr<Portion> port01 = MakeObject<Portion>();
SharedPtr<Portion> port02 = MakeObject<Portion>();
para0->get_Portions()->Add(port01);
para0->get_Portions()->Add(port02);

// إضافة الفقرة الثانية
SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para1);
SharedPtr<Portion> port10 = MakeObject<Portion>();
SharedPtr<Portion> port11 = MakeObject<Portion>();
SharedPtr<Portion> port12 = MakeObject<Portion>();
para1->get_Portions()->Add(port10);
para1->get_Portions()->Add(port11);
para1->get_Portions()->Add(port12);

// إضافة الفقرة الثالثة
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

// حفظ PPTX على القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **إدارة نقاط الفقرات**

قوائم النقاط تساعدك على تنظيم وعرض المعلومات بسرعة وكفاءة. الفقرات ذات النقاط تكون دائمًا أسهل في القراءة والفهم.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) الخاص بـ autoshape.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء نسخة الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/).
7. تعيين `Type` النقطة للفقرة إلى `Symbol` وتعيين حرف النقطة.
8. تعيين `Text` للفقرة.
9. تعيين `Indent` للفقرة بالنسبة للنقطة.
10. تعيين لون للنقطة.
11. تعيين ارتفاع للنقطة.
12. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
13. إضافة الفقرة الثانية وتكرار العملية المذكورة في الخطوات 7 إلى 13.
14. حفظ العرض التقديمي.

هذا الكود C++ يوضح لك كيفية إضافة نقطة فقرة:
```c++
// مسار مجلد المستندات.
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// تحميل العرض التقديمي المطلوب
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// إضافة AutoShape من النوع مستطيل
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// إضافة TextFrame إلى المستطيل
ashp->AddTextFrame(u"");

// الوصول إلى إطار النص
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// إنشاء كائن الفقرة لإطار النص
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

//تعيين النص
paragraph->set_Text(u"Welcome to Aspose.Slides");

// ضبط إزاحة الفقرة
paragraph->get_ParagraphFormat()->set_Indent (25);

// ضبط لون النقطة
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
// set IsBulletHardColor to true to use own bullet color
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// ضبط ارتفاع النقطة
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// إضافة فقرة إلى إطار النص
txtFrame->get_Paragraphs()->Add(paragraph);

// إنشاء الفقرة الثانية
// إنشاء كائن الفقرة لإطار النص
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

//تعيين النص
paragraph2->set_Text(u"This is numbered bullet");

// ضبط نوع الفقرة ونمط النقطة
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// ضبط إزاحة الفقرة
paragraph2->get_ParagraphFormat()->set_Indent(25);

// ضبط لون النقطة
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// set IsBulletHardColor to true to use own bullet color
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// ضبط ارتفاع النقطة
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// إضافة فقرة إلى إطار النص
txtFrame->get_Paragraphs()->Add(paragraph2);


// حفظ PPTX على القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **إدارة نقاط الصور**

قوائم النقاط تساعدك على تنظيم وعرض المعلومات بسرعة وكفاءة. فقرات الصور سهلة القراءة والفهم.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) الخاص بـ autoshape.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء نسخة الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/).
7. تحميل الصورة في [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/).
8. تعيين نوع النقطة إلى [Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) وتعيين الصورة.
9. تعيين `Text` الفقرة.
10. تعيين `Indent` للفقرة بالنسبة للنقطة.
11. تعيين لون للنقطة.
12. تعيين ارتفاع للنقطة.
13. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
14. إضافة الفقرة الثانية وتكرار العملية بناءً على الخطوات السابقة.
15. حفظ العرض التقديمي المعدل.

هذا الكود C++ يوضح لك كيفية إضافة وإدارة نقاط الصور:
```c++
// إنشاء فئة Presentation التي تمثل ملف PPTX
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// إنشاء صورة للنقاط
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// إضافة والوصول إلى AutoShape
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// الوصول إلى إطار النص في الـ AutoShape
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


## **إدارة نقاط متعددة المستويات**

قوائم النقاط تساعدك على تنظيم وعرض المعلومات بسرعة وكفاءة. النقاط متعددة المستويات سهلة القراءة والفهم.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة [autoshape] في الشريحة الجديدة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) الخاص بـ autoshape.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء نسخة الفقرة الأولى عبر فئة [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) وتعيين العمق إلى 0.
7. إنشاء نسخة الفقرة الثانية عبر فئة `Paragraph` وتعيين العمق إلى 1.
8. إنشاء نسخة الفقرة الثالثة عبر فئة `Paragraph` وتعيين العمق إلى 2.
9. إنشاء نسخة الفقرة الرابعة عبر فئة `Paragraph` وتعيين العمق إلى 3.
10. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
11. حفظ العرض التقديمي المعدل.

هذا الكود C++ يوضح لك كيفية إضافة وإدارة نقاط متعددة المستويات:
```c++
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// إضافة والوصول إلى AutoShape
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// الوصول إلى إطار النص للـ AutoShape المُنشأ
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


## **إدارة فقرة مع قائمة مرقمة مخصصة**

توفر واجهة [IBulletFormat] الخاصية [NumberedBulletStartWith] وغيرها التي تسمح لك بإدارة الفقرات بترقيم أو تنسيق مخصص.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. الوصول إلى الشريحة التي تحتوي على الفقرة.
3. إضافة [autoshape] إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) الخاص بـ autoshape.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء نسخة الفقرة الأولى عبر فئة [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) وتعيين [NumberedBulletStartWith] إلى 2.
7. إنشاء نسخة الفقرة الثانية عبر فئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 3.
8. إنشاء نسخة الفقرة الثالثة عبر فئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 7.
9. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
10. حفظ العرض التقديمي المعدل.

هذا الكود C++ يوضح لك كيفية إضافة وإدارة فقرات ذات ترقيم مخصص أو تنسيق مخصص:
```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// الوصول إلى إطار النص للـ AutoShape المُنشأ
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// إزالة الفقرة الافتراضية الموجودة
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


## **تعيين مسافة الفقرة**

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة مستطيل [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى الشريحة.
4. إضافة [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) يحتوي على ثلاث فقرات إلى المستطيل.
5. إخفاء خطوط المستطيل.
6. تعيين المسافة لكل [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) عبر خاصية BulletOffset الخاصة بها.
7. كتابة العرض التقديمي المعدل كملف PPT.

هذا الكود C++ يوضح لك كيفية تعيين مسافة الفقرة: 
```c++
// مسار مجلد المستندات.
const String outPath = u"../out/AddingSuperscriptAndSubscriptTextInTextFrame_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// تحميل العرض التقديمي المطلوب
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// إضافة AutoShape من النوع مستطيل
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// إضافة TextFrame إلى المستطيل
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

tf->get_Paragraphs()->Clear();

// إضافة الفقرة الأولى
SharedPtr<Paragraph> superPar = MakeObject<Paragraph>();
SharedPtr<Portion> portion1 = MakeObject<Portion>(u"SlideTitle");
superPar->get_Portions()->Add(portion1);

SharedPtr<Portion> superPortion = MakeObject<Portion>();
superPortion->get_PortionFormat()->set_Escapement(30);
superPortion->set_Text(u"TM");
superPar->get_Portions()->Add(superPortion);


// إضافة الفقرة الأولى
SharedPtr<Paragraph> subPar = MakeObject<Paragraph>();
SharedPtr<Portion> portion2 = MakeObject<Portion>(u"a");
subPar->get_Portions()->Add(portion2);

SharedPtr<Portion> subPortion = MakeObject<Portion>();
subPortion->get_PortionFormat()->set_Escapement(-25);
subPortion->set_Text(u"i");
subPar->get_Portions()->Add(subPortion);

//إضافة إلى إطار النص
ashp->get_TextFrame()->get_Paragraphs()->Add(superPar);
ashp->get_TextFrame()->get_Paragraphs()->Add(subPar);


// حفظ PPTX على القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **تعيين مسافة معلقة لفقرة**

هذا الكود C++ يوضح لك كيفية تعيين المسافة المعلقة لفقرة:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 250.0f, 550.0f, 150.0f);

System::SharedPtr<Paragraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Example");
System::SharedPtr<Paragraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Set Hanging Indent for Paragraph");
System::SharedPtr<Paragraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"This C# code shows you how to set the hanging indent for a paragraph: ");

para2->get_ParagraphFormat()->set_MarginLeft(10.f);
para3->get_ParagraphFormat()->set_MarginLeft(20.f);

auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


## **إدارة خصائص تشغيل نهاية الفقرة**

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. الحصول على مرجع الشريحة التي تحتوي على الفقرة عبر موضعها.
3. إضافة مستطيل [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى الشريحة.
4. إضافة [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) يحتوي على فقرتين إلى المستطيل.
5. تعيين `FontHeight` ونوع الخط للفقرات.
6. تعيين خصائص End للفقرات.
7. كتابة العرض التقديمي المعدل كملف PPTX.

هذا الكود C++ يوضح لك كيفية تعيين خصائص End للفقرات في PowerPoint: 
```c++
// مسار مجلد المستندات.
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// تحميل العرض التقديمي المطلوب
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// إضافة AutoShape من النوع مستطيل
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



// حفظ PPTX على القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```


## **استيراد نص HTML إلى الفقرات**

توفر Aspose.Slides دعمًا محسنًا لاستيراد نص HTML إلى الفقرات.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى الشريحة.
4. إضافة والوصول إلى `autoshape` [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) 
5. إزالة الفقرة الافتراضية في `ITextFrame`.
6. قراءة ملف HTML المصدر في كائن TextReader.
7. إنشاء نسخة الفقرة الأولى عبر فئة [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/).
8. إضافة محتوى ملف HTML المقروء من TextReader إلى مجموعة [ParagraphCollection](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/) الخاصة بـ TextFrame.
9. حفظ العرض التقديمي المعدل.

هذا الكود C++ هو تنفيذ للخطوات الخاصة باستيراد نصوص HTML في الفقرات: 
```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// مسار مجلد المستندات.
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// تحميل العرض التقديمي المطلوب
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// إضافة AutoShape من النوع مستطيل
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

// تحميل ملف HTML باستخدام قارئ تدفق
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// إضافة النص من قارئ تدفق HTML إلى إطار النص
ParaCollection->AddFromHtml(tr->ReadToEnd());


// إنشاء كائن الفقرة لإطار النص
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// إنشاء كائن الجزء للفقرة
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

// الحصول على تنسيق الجزء
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// تعيين الخط للجزء
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// تعيين خاصية الغامق للخط
pf->set_FontBold(NullableBool::True);

// تعيين خاصية المائل للخط
pf->set_FontItalic(NullableBool::True);

// تعيين خاصية التسطير للخط
pf->set_FontUnderline(TextUnderlineType::Single);

// تعيين ارتفاع الخط
pf->set_FontHeight(25);

// تعيين لون الخط
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// حفظ PPTX على القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **تصدير نص الفقرة إلى HTML**

توفر Aspose.Slides دعمًا محسنًا لتصدير النصوص (الموجودة في الفقرات) إلى HTML.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) وتحميل العرض التقديمي المطلوب.
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. الوصول إلى الشكل الذي يحتوي على النص الذي سيتم تصديره إلى HTML.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) الخاص بالشكل.
5. إنشاء نسخة من `StreamWriter` وإضافة ملف HTML جديد.
6. توفير فهرس بداية إلى StreamWriter وتصدير الفقرات المفضلة لديك.

هذا الكود C++ يوضح لك كيفية تصدير نصوص فقرات PowerPoint إلى HTML: 
```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// مسار مجلد المستندات.
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// تحميل العرض التقديمي المطلوب
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// الوصول إلى الشريحة الأولى الافتراضية في العرض التقديمي
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// الفهرس المطلوب
int index = 0;

// الوصول إلى الشكل المضاف
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// استخراج الفقرة الأولى كـ HTML
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

// كتابة بيانات الفقرات إلى HTML بتوفير فهرس بدء الفقرة وإجمالي عدد الفقرات المنقولة
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();
```


## **حفظ الفقرة كصورة**

في هذا القسم، سنستعرض مثالين يوضحان كيفية حفظ فقرة نصية، ممثلة بواجهة [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/)، كصورة. يتضمن كل مثال الحصول على صورة الشكل الذي يحتوي الفقرة باستخدام طرق `GetImage` من واجهة [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)، حساب حدود الفقرة داخل الشكل، وتصديرها كصورة بتنسيق bitmap. تسمح هذه الأساليب باستخراج أجزاء محددة من النص من عروض PowerPoint وحفظها كصور منفصلة، ما قد يكون مفيدًا للاستخدام لاحقًا في سيناريوهات متنوعة.

لنفترض أن لدينا ملف عرض تقديمي اسمه sample.pptx يحتوي شريحة واحدة، حيث الشكل الأول هو مربع نص يحتوي على ثلاث فقرات.

![مربع النص مع ثلاث فقرات](paragraph_to_image_input.png)

**مثال 1**

في هذا المثال، نحصل على الفقرة الثانية كصورة. للقيام بذلك، نستخرج صورة الشكل من الشريحة الأولى للعرض ثم نحسب حدود الفقرة الثانية في إطار النص الخاص بالشكل. تُعاد رسم الفقرة على صورة bitmap جديدة، يتم حفظها بصيغة PNG. هذه الطريقة مفيدة جدًا عندما تحتاج إلى حفظ فقرة معينة كصورة منفصلة مع الحفاظ على أبعاد النص وتنسيقه بدقة.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// حفظ الشكل في الذاكرة كصورة نقطية.
auto shapeImage = firstShape->GetImage();
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// إنشاء صورة نقطية للشكل من الذاكرة.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// حساب حدود الفقرة الثانية.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();

// حساب حجم الصورة الناتجة (الحد الأدنى - بكسل واحد × 1).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// إعداد صورة نقطية للفقرة.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// إعادة رسم الفقرة من صورة الشكل إلى صورة الفقرة.
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

في هذا المثال، نُضيف عوامل تكبير إلى صورة الفقرة. يُستخرج الشكل من العرض ويُحفظ كصورة بمتغير تكبير `2`. يتيح ذلك إخراجًا بدقة أعلى عند تصدير الفقرة. تُحسب حدود الفقرة مع مراعاة مقياس التكبير. يمكن أن يكون التكبير مفيدًا عندما تحتاج إلى صورة ذات تفصيل أعلى، مثل استخدامها في مواد مطبوعة عالية الجودة.

```cpp
auto imageScaleX = 2.0f;
auto imageScaleY = imageScaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Save the shape in memory as a bitmap with scaling.
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

**هل يمكنني تعطيل التفاف السطر داخل إطار النص تمامًا؟**

نعم. استخدم طريقة التفاف النص في إطار النص ([set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_wraptext/)) لإيقاف التفاف السطر بحيث لا تنكسر الأسطر عند حواف الإطار.

**كيف يمكنني الحصول على حدود الفقرة المحددة داخل الشريحة بدقة؟**

يمكنك استرجاع مستطيل الحد للفقرة (وحتى للجزء الواحد) لمعرفة موقعها الدقيق وحجمها على الشريحة.

**أين يتم التحكم في محاذاة الفقرة (يسار/يمين/وسط/ضبط)؟**

تُتاح خاصية [Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/set_alignment/) على مستوى الفقرة في [ParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/); وتطبق على الفقرة بأكملها بغض النظر عن تنسيق الأجزاء الفردية.

**هل يمكنني تحديد لغة التدقيق الإملائي لجزء واحد فقط من الفقرة (مثل كلمة واحدة)؟**

نعم. تُحدد اللغة على مستوى الجزء باستخدام ([PortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/)), لذا يمكن وجود لغات متعددة داخل نفس الفقرة.