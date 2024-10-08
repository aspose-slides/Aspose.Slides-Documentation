---
title: إدارة فقرات PowerPoint في C++
type: docs
weight: 40
url: /ar/cpp/manage-paragraph/
keywords: "إضافة فقرة PowerPoint، إدارة الفقرات، إندفاع الفقرة، خصائص الفقرة، نص HTML، تصدير نص الفقرة، عرض PowerPoint، C++، CPP، Aspose.Slides لـ C++"
description: "إنشاء وإدارة الفقرات والنص والإندفاع والخصائص في عروض PowerPoint باستخدام C++"
---

توفر Aspose.Slides جميع الواجهات والفئات التي تحتاجها للعمل مع نصوص PowerPoint والفقرات والأجزاء في C++.

* توفر Aspose.Slides واجهة [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) التي تسمح لك بإضافة كائنات تمثل فقرة. يمكن أن يحتوي كائن `ITextFrame` على فقرة واحدة أو عدة فقرات (كل فقرة يتم إنشاؤها من خلال إرجاع عربة).
* توفر Aspose.Slides واجهة [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) التي تسمح لك بإضافة كائنات تمثل الأجزاء. يمكن أن يحتوي كائن `IParagraph` على جزء واحد أو عدة أجزاء (مجموعة من كائنات iPortions).
* توفر Aspose.Slides واجهة [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) التي تسمح لك بإضافة كائنات تمثل النصوص وخصائص التنسيق الخاصة بها.

يمكن لعنصر `IParagraph` التعامل مع نصوص بخصائص تنسيق مختلفة من خلال كائناته الأساسية `IPortion`.

## **إضافة فقرات متعددة تحتوي على عدة أجزاء**

توضح هذه الخطوات كيفية إضافة إطار نص يحتوي على 3 فقرات وكل فقرة تحتوي على 3 أجزاء:

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. الوصول إلى المرجع الشرائحي المعني من خلال فهرسه.
3. أضف شكل مستطيل [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى الشريحة.
4. احصل على ITextFrame المرتبط بـ [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).
5. أنشئ كائني [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) وأضفهما إلى مجموعة `IParagraphs` الخاصة بـ [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/).
6. أنشئ ثلاثة كائنات [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) لكل `IParagraph` جديدة (كائنان من Portion للفقرة الافتراضية) وأضف كل كائن `IPortion` إلى مجموعة IPortion الخاصة بكل `IParagraph`.
7. قم بتعيين نص معين لكل جزء.
8. قم بتطبيق ميزات التنسيق المفضلة لك على كل جزء باستخدام خصائص التنسيق التي يوفرها كائن `IPortion`.
9. احفظ العرض المعدل.

هذا الكود C++ هو تنفيذ للخطوات الخاصة بإضافة فقرات تحتوي على أجزاء: 

```c++
// مسار دليل المستندات.
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// تحميل العرض المطلوب
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// إضافة شكل AutoShape من النوع مستطيل
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// إضافة TextFrame إلى المستطيل
SharedPtr<ITextFrame> tf=ashp->AddTextFrame(u" ");


// الوصول إلى أول فقرة
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


## **إدارة النقاط البصرية للفقرة**

تساعد قوائم النقاط في تنظيم وعرض المعلومات بسرعة وكفاءة. تعتبر الفقرات المنقطة أسهل دائمًا في القراءة والفهم.

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. الوصول إلى المرجع الشرائحي المعني من خلال فهرسه.
3. أضف [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) للشكل.
5. قم بإزالة الفقرة الافتراضية في `TextFrame`.
6. قم بإنشاء مثيل الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/).
7. اضبط نوع النقطة `Type` للفقرة على `Symbol` واضبط حرف النقطة.
8. اضبط `Text` للفقرة.
9. اضبط `Indent` للفقرة للنقطة.
10. اضبط لونًا للنقطة.
11. اضبط ارتفاع النقطة.
12. أضف الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
13. أضف الفقرة الثانية وكرر العملية الموضحة في الخطوات من 7 إلى 13.
14. احفظ العرض.

هذا الكود C++ يوضح لك كيفية إضافة نقطة للفقرة:

```c++
// مسار دليل المستندات.
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// تحميل العرض المطلوب
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// إضافة شكل AutoShape من النوع مستطيل
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// إضافة TextFrame إلى المستطيل
ashp->AddTextFrame(u"");

// الوصول إلى إطار النص
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// إنشاء كائن الفقرة لإطار النص
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

// تعيين النص
paragraph->set_Text(u"مرحبًا بك في Aspose.Slides");

// تعيين إندفاع النقطة
paragraph->get_ParagraphFormat()->set_Indent (25);

// تعيين لون النقطة
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
// تعيين IsBulletHardColor على true لاستخدام لون النقطة الخاص
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// تعيين ارتفاع النقطة
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// إضافة الفقرة إلى إطار النص
txtFrame->get_Paragraphs()->Add(paragraph);

// إنشاء الفقرة الثانية
// إنشاء كائن الفقرة لإطار النص
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

// تعيين النص
paragraph2->set_Text(u"هذه نقطة مرقمة");

// تعيين نوع النقطة وطرازها للفقرة
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// تعيين إندفاع النقطة
paragraph2->get_ParagraphFormat()->set_Indent(25);

// تعيين لون النقطة
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// تعيين IsBulletHardColor على true لاستخدام لون النقطة الخاص
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// تعيين ارتفاع النقطة
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// إضافة الفقرة إلى إطار النص
txtFrame->get_Paragraphs()->Add(paragraph2);


// حفظ PPTX على القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **إدارة النقاط الصورة**

تساعد قوائم النقاط في تنظيم وعرض المعلومات بسرعة وكفاءة. تعتبر الفقرات الصورة سهلة القراءة والفهم.

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. الوصول إلى المرجع الشرائحي المعني من خلال فهرسه.
3. أضف [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) للشكل.
5. قم بإزالة الفقرة الافتراضية في `TextFrame`.
6. قم بإنشاء مثيل الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/).
7. قم بتحميل الصورة في [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/).
8. اضبط نوع النقطة إلى [Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) واضبط الصورة.
9. اضبط `Text` للفقرة.
10. اضبط `Indent` للفقرة للنقطة.
11. اضبط لونًا للنقطة.
12. اضبط ارتفاعًا للنقطة.
13. أضف الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
14. أضف الفقرة الثانية وكرر العملية بناءً على الخطوات السابقة.
15. احفظ العرض المعدل.

هذا الكود C++ يوضح لك كيفية إضافة وإدارة نقاط الصور:

```c++
// يقوم بإنشاء مثيل لفئة Presentation تمثل ملف PPTX
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// يقوم بإنشاء الصورة للنقاط
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// يضيف ويصل إلى الشكل AutoShape
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// الوصول إلى إطار النص لـ autoshape
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// إزالة الفقرة الافتراضية
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// إنشاء فقرة جديدة
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"مرحبًا بك في Aspose.Slides");

// تعيين نمط النقطة ونوع الصورة
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// تعيين ارتفاع النقطة
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// إضافة الفقرة إلى إطار النص
paragraphs->Add(paragraph);

// كتابة العرض كملف PPTX
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// كتابة العرض كملف PPT
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```


## **إدارة النقاط متعددة المستويات**

تساعد قوائم النقاط في تنظيم وعرض المعلومات بسرعة وكفاءة. تعتبر النقاط متعددة المستويات سهلة القراءة والفهم.

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. الوصول إلى المرجع الشرائحي المعني من خلال فهرسه.
3. أضف [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) في الشريحة الجديدة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) لشكل autoshape. 
5. قم بإزالة الفقرة الافتراضية في `TextFrame`.
6. قم بإنشاء مثيل الفقرة الأولى من خلال فئة [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) واضبط العمق على 0.
7. قم بإنشاء مثيل الفقرة الثانية من خلال فئة `Paragraph` واضبط العمق على 1.
8. قم بإنشاء مثيل الفقرة الثالثة من خلال فئة `Paragraph` واضبط العمق على 2.
9. قم بإنشاء مثيل الفقرة الرابعة من خلال فئة `Paragraph` واضبط العمق على 3.
10. أضف الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
11. احفظ العرض المعدل.

هذا الكود C++ يوضح لك كيفية إضافة وإدارة النقاط متعددة المستويات:

```c++
// يقوم بإنشاء مثيل لفئة Presentation تمثل ملف PPTX
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// يضيف ويصل إلى الشكل AutoShape
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// الوصول إلى إطار النص للشكل autoShape
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// مسح الفقرة الافتراضية
text->get_Paragraphs()->Clear();

// إضافة الفقرة الأولى
System::SharedPtr<IParagraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"محتوى");
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
para2->set_Text(u"المستوى الثاني");
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
para3->set_Text(u"المستوى الثالث");
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
para4->set_Text(u"المستوى الرابع");
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

// كتابة العرض كملف PPTX
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```


## **إدارة الفقرات بقائمة مرقمة مخصصة**

توفر واجهة [IBulletFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/) خاصية [NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) وغيرها التي تتيح لك إدارة الفقرات مع ترقيم أو تنسيق مخصص.

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. الوصول إلى الشريحة التي تحتوي على الفقرة.
3. أضف [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) لشكل autoshape. 
5. قم بإزالة الفقرة الافتراضية في `TextFrame`.
6. قم بإنشاء مثيل الفقرة الأولى من خلال فئة [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) واضبط [NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) إلى 2.
7. قم بإنشاء مثيل الفقرة الثانية من خلال فئة `Paragraph` واضبط `NumberedBulletStartWith` إلى 3.
8. قم بإنشاء مثيل الفقرة الثالثة من خلال فئة `Paragraph` واضبط `NumberedBulletStartWith` إلى 7.
9. أضف الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
10. احفظ العرض المعدل.

هذا الكود C++ يوضح لك كيفية إضافة وإدارة الفقرات مع ترقيم مخصص أو تنسيق:

```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// الوصول إلى إطار النص للشكل autoShape
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// إزالة الفقرة الحالية الافتراضية
textFrame->get_Paragraphs()->RemoveAt(0);

// القائمة الأولى
auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->set_Text(u"نقطة 2");
auto paragraph1Format = paragraph1->get_ParagraphFormat();
paragraph1Format->set_Depth(4);
auto bullet1Format = paragraph1Format->get_Bullet();
bullet1Format->set_NumberedBulletStartWith(2);
bullet1Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->set_Text(u"نقطة 3");
auto paragraph2Format = paragraph2->get_ParagraphFormat();
paragraph2Format->set_Depth(4);
auto bullet2Format = paragraph2Format->get_Bullet();
bullet2Format->set_NumberedBulletStartWith(3);
bullet2Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph5 = System::MakeObject<Paragraph>();
paragraph5->set_Text(u"نقطة 7");
auto paragraph5Format = paragraph5->get_ParagraphFormat();
paragraph5Format->set_Depth(4);
auto bullet5Format = paragraph5Format->get_Bullet();
bullet5Format->set_NumberedBulletStartWith(7);
bullet5Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph5);

presentation->Save(u"SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
```


## **تعيين إندفاع الفقرة**

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. الوصول إلى المرجع الشرائحي المعني من خلال فهرسه.
3. أضف شكل مستطيل [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى الشريحة.
4. أضف [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) مع ثلاث فقرات إلى شكل المستطيل.
5. قم بإخفاء خطوط المستطيل.
6. قم بتعيين الإندفاع لكل [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) من خلال خاصية BulletOffset.
7. اكتب العرض المعدل كملف PPT.

هذا الكود C++ يوضح لك كيفية تعيين إندفاع الفقرة: 

```c++
// مسار دليل المستندات.
const String outPath = u"../out/AddingSuperscriptAndSubscriptTextInTextFrame_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// تحميل العرض المطلوب
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// إضافة شكل AutoShape من النوع مستطيل
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// إضافة TextFrame إلى المستطيل
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

tf->get_Paragraphs()->Clear();

// إضافة الفقرة الأولى
SharedPtr<Paragraph> superPar = MakeObject<Paragraph>();
SharedPtr<Portion> portion1 = MakeObject<Portion>(u"عنوان الشريحة");
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

## **تعيين إندفاع معلق للفقرة**

هذا الكود C++ يوضح لك كيفية تعيين الإندفاع المعلق لفقرة:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 250.0f, 550.0f, 150.0f);

System::SharedPtr<Paragraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"مثال");
System::SharedPtr<Paragraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"تعيين إندفاع معلق للفقرة");
System::SharedPtr<Paragraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"هذا الكود C# يوضح لك كيفية تعيين الإندفاع المعلق لفقرة: ");

para2->get_ParagraphFormat()->set_MarginLeft(10.f);
para3->get_ParagraphFormat()->set_MarginLeft(20.f);

auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **إدارة خصائص نهاية فقرة الفقرة**

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. احصل على المرجع للشريحة التي تحتوي على الفقرة من خلال موضعها.
3. أضف شكل مستطيل [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى الشريحة.
4. أضف [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) مع فقرتين إلى المستطيل.
5. قم بتعيين `FontHeight` ونوع الخط للفقرات.
6. قم بتعيين خصائص النهاية للفقرات.
7. اكتب العرض المعدل كملف PPTX.

هذا الكود C++ يوضح لك كيفية تعيين خصائص النهاية للفقرات في PowerPoint: 

```c++
// مسار دليل المستندات.
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// تحميل العرض المطلوب
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// إضافة شكل AutoShape من النوع مستطيل
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// إضافة TextFrame إلى المستطيل
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// إضافة الفقرة الأولى
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"نص تجريبي");

para1->get_Portions()->Add(port01);

// إضافة الفقرة الثانية
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"نص تجريبي 2");

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

توفر Aspose.Slides دعمًا معززًا لاستيراد نص HTML إلى الفقرات.

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. الوصول إلى المرجع الشرائحي المعني من خلال فهرسه.
3. أضف شكل [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى الشريحة.
4. أضف وادخل `autoshape` [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) 
5. قم بإزالة الفقرة الافتراضية في `ITextFrame`.
6. قراءة ملف HTML المصدر في TextReader.
7. قم بإنشاء مثيل الفقرة الأولى من خلال فئة [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) .
8. أضف محتوى ملف HTML في TextReader المقروء إلى مجموعة [ParagraphCollection](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/) الخاصة بـ TextFrame.
9. احفظ العرض المعدل.

هذا الكود C++ هو تنفيذ للخطوات لاستيراد النصوص HTML في الفقرات: 

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// مسار دليل المستندات.
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// تحميل العرض المطلوب
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// إضافة شكل AutoShape من النوع مستطيل
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
// إعادة تعيين لون التعبئة الافتراضي
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// إضافة TextFrame إلى المستطيل
ashp->AddTextFrame(u" ");

// الوصول إلى إطار النص
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

// الحصول على مجموعة الفقرات
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// مسح جميع الفقرات في إطار النص المضاف
ParaCollection->Clear();

// تحميل ملف HTML باستخدام قارئ دفق
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// إضافة النص من قارئ دفق HTML إلى إطار النص
ParaCollection->AddFromHtml(tr->ReadToEnd());


// إنشاء كائن الفقرة لإطار النص
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// إنشاء كائن Portion للفقرة
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"نص Aspose");

// الحصول على تنسيق الجزء
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// تعيين الخط للجزء
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// تعيين خاصية الخط الغامق
pf->set_FontBold(NullableBool::True);

// تعيين خاصية الخط المائل
pf->set_FontItalic(NullableBool::True);

// تعيين خاصية الخط التحتي
pf->set_FontUnderline(TextUnderlineType::Single);

// تعيين ارتفاع الخط
pf->set_FontHeight(25);

// تعيين لون الخط
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// حفظ PPTX على القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);


```


## **تصدير نص الفقرات إلى HTML**

توفر Aspose.Slides دعمًا معززًا لتصدير النصوص (المحتواة في الفقرات) إلى HTML.

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) وتحميل العرض المطلوب.
2. الوصول إلى المرجع الشرائحي المعني من خلال فهرسه.
3. الوصول إلى الشكل الذي يحتوي على النص الذي سيتم تصديره إلى HTML.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) للشكل.
5. إنشاء مثيل من `StreamWriter` وإضافة ملف HTML الجديد.
6. توفير فهرس بدء لـ StreamWriter وتصدير الفقرات التي تفضلها.

هذا الكود C++ يوضح لك كيفية تصدير نصوص فقرات PowerPoint إلى HTML: 

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// مسار دليل المستندات.
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// تحميل العرض المطلوب
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// الوصول إلى الشريحة الأولى الافتراضية للعروض
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// الفهرس المطلوب
int index = 0;

// الوصول إلى الشكل المضاف
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// استخراج الفقرة الأولى كـ HTML
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

// كتابة بيانات الفقرات إلى HTML من خلال توفير فهرس البدء للفقرة، وإجمالي الفقرات التي سيتم نسخها
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();

```