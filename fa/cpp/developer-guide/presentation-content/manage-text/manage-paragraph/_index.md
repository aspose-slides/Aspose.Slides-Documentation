---
title: "مدیریت پاراگراف‌های متن PowerPoint در C++"
linktitle: "مدیریت پاراگراف"
type: docs
weight: 40
url: /fa/cpp/manage-paragraph/
aliases:
  - /cpp/paragraph/
  - /cpp/portion/
keywords:
  - "افزودن متن"
  - "افزودن پاراگراف"
  - "مدیریت متن"
  - "مدیریت پاراگراف"
  - "مدیریت بولت"
  - "تورفتگی پاراگراف"
  - "تورفتگی معلق"
  - "بولت پاراگراف"
  - "فهرست شماره‌دار"
  - "فهرست بولت‌دار"
  - "ویژگی‌های پاراگراف"
  - "وارد کردن HTML"
  - "متن به HTML"
  - "پاراگراف به HTML"
  - "پاراگراف به تصویر"
  - "متن به تصویر"
  - "صادرات پاراگراف"
  - "PowerPoint"
  - "OpenDocument"
  - "ارائه"
  - "C++"
  - "Aspose.Slides"
description: "قالب‌بندی پیشرفته پاراگراف‌ها با Aspose.Slides برای C++ — بهینه‌سازی تراز، فواصل و سبک در ارائه‌های PPT، PPTX و ODP با C++."
---
## **معرفی**

Aspose.Slides تمام رابط‌ها و کلاس‌هایی را که برای کار با متن‌های PowerPoint، پاراگراف‌ها و بخش‌ها در C++ نیاز دارید، فراهم می‌کند.

* Aspose.Slides رابط [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) را فراهم می‌کند تا بتوانید اشیائی که نمایانگر یک پاراگراف هستند را اضافه کنید. یک شیء `ITextFame` می‌تواند یک یا چند پاراگراف داشته باشد (هر پاراگراف از طریق یک بازگشت carriage ایجاد می‌شود).
* Aspose.Slides رابط [IParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraph/) را فراهم می‌کند تا بتوانید اشیائی که نمایانگر بخش‌ها هستند را اضافه کنید. یک شیء `IParagraph` می‌تواند یک یا چند بخش داشته باشد (مجموعه‌ای از اشیاء iPortions).
* Aspose.Slides رابط [IPortion](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportion/) را فراهم می‌کند تا بتوانید اشیائی که نمایانگر متن‌ها و ویژگی‌های قالب‌بندی آن‌ها هستند را اضافه کنید.

یک شیء `IParagraph` می‌تواند متن‌هایی با ویژگی‌های قالب‌بندی مختلف را از طریق اشیاء `IPortion` زیرین خود مدیریت کند.

## **افزودن چند پاراگراف حاوی چندین بخش**

این مراحل نشان می‌دهد چگونه یک قاب متن شامل ۳ پاراگراف و هر پاراگراف شامل ۳ بخش اضافه کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. از طریق شاخص، به ارجاع اسلاید مربوطه دسترسی پیدا کنید.
3. یک [IAutoShape] مستطیلی به اسلاید اضافه کنید.
4. ITextFrame مرتبط با [IAutoShape] را دریافت کنید.
5. دو شیء [IParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraph/) ایجاد کنید و آن‌ها را به مجموعه `IParagraphs` مربوط به [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) اضافه کنید.
6. برای هر `IParagraph` جدید سه شیء [IPortion](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportion/) (دو شیء Portion برای پاراگراف پیش‌فرض) ایجاد کنید و هر شیء `IPortion` را به مجموعه IPortion مربوط به هر `IParagraph` اضافه کنید.
7. برای هر بخش متنی تنظیم کنید.
8. ویژگی‌های قالب‌بندی مورد نظر خود را بر هر بخش اعمال کنید با استفاده از ویژگی‌های قالب‌بندی ارائه‌شده توسط شیء `IPortion`.
9. ارائه اصلاح‌شده را ذخیره کنید.

```c++
// مسیر به پوشه اسناد.
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

## **مدیریت نشان‌های پاراگراف**

فهرست‌های بولت به شما کمک می‌کند تا اطلاعات را به سرعت و به‌صورت کارآمد سازماندهی و ارائه کنید. پاراگراف‌های دارای بولت همیشه خواندن و درک آن‌ها آسان‌تر است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. از طریق شاخص، به ارجاع اسلاید مربوطه دسترسی پیدا کنید.
3. یک [autoshape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) به اسلاید انتخابی اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) این autoshape دسترسی پیدا کنید. 
5. پاراگراف پیش‌فرض موجود در `TextFrame` را حذف کنید.
6. اولین نمونه پاراگراف را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides/paragraph/) ایجاد کنید.
7. نوع بولت `Type` پاراگراف را به `Symbol` تنظیم کنید و کاراکتر بولت را مشخص نمایید.
8. متن پاراگراف را تنظیم کنید.
9. تورفتگی `Indent` پاراگراف برای بولت را تنظیم کنید.
10. رنگی برای بولت تعیین کنید.
11. ارتفاعی برای بولت تنظیم کنید.
12. پاراگراف جدید را به مجموعه پاراگراف‌های `TextFrame` اضافه کنید.
13. پاراگراف دوم را اضافه کنید و فرآیند مراحل ۷ تا ۱۳ را تکرار کنید.
14. ارائه را ذخیره کنید.

```c++
// مسیر به پوشه اسناد.
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Load the desired the presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Access first slide
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Add an AutoShape of Rectangle type
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Add TextFrame to the Rectangle
ashp->AddTextFrame(u"");

// Accessing the text frame
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// Create the Paragraph object for text frame
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

// تنظیم متن
paragraph->set_Text(u"Welcome to Aspose.Slides");

// تنظیم تورفتگی بولت
paragraph->get_ParagraphFormat()->set_Indent (25);

// تنظیم رنگ بولت
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
// تنظیم IsBulletHardColor به true برای استفاده از رنگ بولت سفارشی
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// تنظیم ارتفاع بولت
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// افزودن پاراگراف به فریم متن
txtFrame->get_Paragraphs()->Add(paragraph);

// Creating second paragraph
// ایجاد شیء Paragraph برای فریم متن
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

// تنظیم متن
paragraph2->set_Text(u"This is numbered bullet");

// تنظیم نوع و سبک بولت پاراگراف
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// تنظیم تورفتگی بولت
paragraph2->get_ParagraphFormat()->set_Indent(25);

// تنظیم رنگ بولت
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// تنظیم IsBulletHardColor به true برای استفاده از رنگ بولت سفارشی
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// تنظیم ارتفاع بولت
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// افزودن پاراگراف به فریم متن
txtFrame->get_Paragraphs()->Add(paragraph2);


// Save PPTX to Disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **مدیریت بولت‌های تصویری**

فهرست‌های بولت به شما کمک می‌کند تا اطلاعات را به سرعت و به‌صورت کارآمد سازماندهی و ارائه کنید. پاراگراف‌های تصویری خواندن آسان‌تری دارند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. از طریق شاخص، به ارجاع اسلاید مربوطه دسترسی پیدا کنید.
3. یک [autoshape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) این autoshape دسترسی پیدا کنید. 
5. پاراگراف پیش‌فرض موجود در `TextFrame` را حذف کنید.
6. اولین نمونه پاراگراف را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides/paragraph/) ایجاد کنید.
7. تصویر را با استفاده از [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) بارگذاری کنید.
8. نوع بولت را به [Picture](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) تنظیم کنید و تصویر را مشخص نمایید.
9. متن پاراگراف را تنظیم کنید.
10. تورفتگی `Indent` پاراگراف برای بولت را تنظیم کنید.
11. رنگی برای بولت تعیین کنید.
12. ارتفاعی برای بولت تنظیم کنید.
13. پاراگراف جدید را به مجموعه پاراگراف‌های `TextFrame` اضافه کنید.
14. پاراگراف دوم را اضافه کنید و فرآیند را بر مبنای مراحل قبلی تکرار کنید.
15. ارائه اصلاح‌شده را ذخیره کنید.

```c++
// یک شیء از کلاس Presentation می‌سازد که نمایانگر یک فایل PPTX است
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// به اولین اسلاید دسترسی پیدا می‌کند
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// تصویر برای بولت‌ها را ایجاد می‌کند
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// افزودن و دسترسی به Autoshape
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// به TextFrame شکل دسترسی پیدا می‌کند
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// پاراگراف پیش‌فرض را حذف می‌کند
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// یک پاراگراف جدید ایجاد می‌کند
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");

// سبک بولت پاراگراف و تصویر را تنظیم می‌کند
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// ارتفاع بولت را تنظیم می‌کند
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// پاراگراف را به TextFrame اضافه می‌کند
paragraphs->Add(paragraph);

// ارائه را به عنوان فایل PPTX می‌نویسد
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// ارائه را به عنوان فایل PPT می‌نویسد
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```


## **مدیریت بولت‌های چندسطحی**

فهرست‌های بولت به شما کمک می‌کند تا اطلاعات را به سرعت و به‌صورت کارآمد سازماندهی و ارائه کنید. بولت‌های چندسطحی خواندن آسان‌تری دارند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. از طریق شاخص، به ارجاع اسلاید مربوطه دسترسی پیدا کنید.
3. یک [autoshape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) در اسلاید جدید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) این autoshape دسترسی پیدا کنید. 
5. پاراگراف پیش‌فرض موجود در `TextFrame` را حذف کنید.
6. اولین پاراگراف را از طریق کلاس [Paragraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides/paragraph/) ایجاد کنید و عمق آن را 0 تنظیم کنید.
7. دومین پاراگراف را از طریق کلاس `Paragraph` ایجاد کنید و عمق آن را 1 تنظیم کنید.
8. سومین پاراگراف را از طریق کلاس `Paragraph` ایجاد کنید و عمق آن را 2 تنظیم کنید.
9. چهارمین پاراگراف را از طریق کلاس `Paragraph` ایجاد کنید و عمق آن را 3 تنظیم کنید.
10. پاراگراف‌های جدید را به مجموعه پاراگراف‌های `TextFrame` اضافه کنید.
11. ارائه اصلاح‌شده را ذخیره کنید.

```c++
// یک شیء از کلاس Presentation می‌سازد که نمایانگر یک فایل PPTX است
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// به اولین اسلاید دسترسی پیدا می‌کند
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Autoshape را اضافه می‌کند و به آن دسترسی پیدا می‌کند
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// به فریم متنی Autoshape ایجاد شده دسترسی پیدا می‌کند
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// پاراگراف پیش‌فرض را پاک می‌کند
text->get_Paragraphs()->Clear();

// پاراگراف اول را اضافه می‌کند
System::SharedPtr<IParagraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Content");
System::SharedPtr<IParagraphFormat> para1Format = para1->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet1Format = para1Format->get_Bullet();
bullet1Format->set_Type(BulletType::Symbol);
bullet1Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat1 = para1Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat1->set_FillType(FillType::Solid);
defaultFillFormat1->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// سطح بولت را تنظیم می‌کند
para1Format->set_Depth(0);

// پاراگراف دوم را اضافه می‌کند
System::SharedPtr<IParagraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Second Level");
System::SharedPtr<IParagraphFormat> para2Format = para2->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet2Format = para2Format->get_Bullet();
bullet2Format->set_Type(BulletType::Symbol);
bullet2Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat2 = para2Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat2->set_FillType(FillType::Solid);
defaultFillFormat2->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// سطح بولت را تنظیم می‌کند
para2Format->set_Depth(1);

// پاراگراف سوم را اضافه می‌کند
System::SharedPtr<IParagraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"Third Level");
System::SharedPtr<IParagraphFormat> para3Format = para3->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet3Format = para3Format->get_Bullet();
bullet3Format->set_Type(BulletType::Symbol);
bullet3Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat3 = para3Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat3->set_FillType(FillType::Solid);
defaultFillFormat3->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// سطح بولت را تنظیم می‌کند
para3Format->set_Depth(2);

// پاراگراف چهارم را اضافه می‌کند
System::SharedPtr<IParagraph> para4 = System::MakeObject<Paragraph>();
para4->set_Text(u"Fourth Level");
System::SharedPtr<IParagraphFormat> para4Format = para4->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet4Format = para4Format->get_Bullet();
bullet4Format->set_Type(BulletType::Symbol);
bullet4Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat4 = para4Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat4->set_FillType(FillType::Solid);
defaultFillFormat4->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// سطح بولت را تنظیم می‌کند
para4Format->set_Depth(3);

// پاراگراف‌ها را به مجموعه اضافه می‌کند
System::SharedPtr<IParagraphCollection> paragraphs = text->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);
paragraphs->Add(para4);

// ارائه را به عنوان فایل PPTX می‌نویسد
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```

## **مدیریت پاراگراف با فهرست عددی سفارشی**

رابط [IBulletFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibulletformat/) ویژگی [NumberedBulletStartWith](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) و دیگر ویژگی‌ها را فراهم می‌کند تا بتوانید پاراگراف‌ها را با شماره‌گذاری یا قالب‌بندی سفارشی مدیریت کنید. 

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید حاوی پاراگراف را دسترسی پیدا کنید.
3. یک [autoshape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) این autoshape دسترسی پیدا کنید. 
5. پاراگراف پیش‌فرض موجود در `TextFrame` را حذف کنید.
6. اولین پاراگراف را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides/paragraph/) ایجاد کنید و [NumberedBulletStartWith](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) را روی 2 تنظیم کنید.
7. دومین پاراگراف را با استفاده از کلاس `Paragraph` ایجاد کنید و `NumberedBulletStartWith` را بر 3 تنظیم کنید.
8. سومین پاراگراف را با استفاده از کلاس `Paragraph` ایجاد کنید و `NumberedBulletStartWith` را بر 7 تنظیم کنید.
9. پاراگراف‌های جدید را به مجموعه پاراگراف‌های `TextFrame` اضافه کنید.
10. ارائه اصلاح‌شده را ذخیره کنید.

```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// به فریم متنی Autoshape ایجاد شده دسترسی پیدا می‌کند
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// پاراگراف پیش‌فرض موجود را حذف می‌کند
textFrame->get_Paragraphs()->RemoveAt(0);

// لیست اول
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

## **تنظیم تورفتگی خط اول برای پاراگراف**

از متد [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_indent/) برای کنترل تورفتگی خط اول یک پاراگراف استفاده کنید. این متد تنها خط اول را نسبت به حاشیه چپ پاراگراف جابه‌جا می‌کند. مقدار مثبت خط اول را به سمت راست حرکت می‌دهد، در حالی که خطوط باقی‌مانده به بدنه پاراگراف چسبیده می‌مانند.

زمانی که نیاز به جابه‌جایی تمام پاراگراف دارید از [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_marginleft/) استفاده کنید. وقتی فقط می‌خواهید خط اول جابه‌جا شود، از [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_indent/) استفاده کنید.

مثال زیر چند پاراگراف ایجاد می‌کند و مقادیر مختلف `Indent` را برای نشان دادن اثر تورفتگی خط اول روی چینش پاراگراف اعمال می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. یک [TextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/textframe/) خالی به شکل اضافه کنید و پاراگراف پیش‌فرض را حذف کنید.
5. چندین پاراگراف ایجاد کنید و مقادیر مختلف [Indent](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_indent/) را برای آن‌ها تنظیم کنید.
6. پاراگراف‌ها را به قاب متن اضافه کنید.
7. ارائه اصلاح‌شده را ذخیره کنید.

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

نتیجه:

![تورفتگی خط اول پاراگراف‌ها](first_line_indent.png)

## **تنظیم تورفتگی معلق برای پاراگراف**

تورفتگی معلق یک طرح‌بندی پاراگراف است که در آن خط اول نسبت به خطوط دیگر به سمت چپ حرکت می‌کند. در Aspose.Slides این اثر را با متد [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_indent/) ایجاد می‌کنید. برای جابه‌جایی خط اول به سمت چپ مقدار `Indent` را منفی کنید.

در عمل، [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_marginleft/) موقعیت چپ بدنه پاراگراف را تعریف می‌کند و [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_indent/) موقعیت خط اول نسبت به آن حاشیه را تعیین می‌کند. برای ایجاد تورفتگی معلق، مقدار `MarginLeft` را مثبت و مقدار `Indent` را منفی تنظیم کنید.

این قالب‌بندی برای منابع کتابشناسی، ارجاعات، ورودی‌های واژه‌نامه و سایر پاراگراف‌هایی که خطوط بسته‌بندی‌شده باید تحت بدنه پاراگراف نه زیر اولین کاراکتر خط اول قرار گیرند، مفید است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. یک [TextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/textframe/) خالی به شکل اضافه کنید و پاراگراف پیش‌فرض را حذف کنید.
5. برای هر پاراگراف مقدار مثبت [MarginLeft](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_marginleft/) تنظیم کنید.
6. برای ایجاد اثر تورفتگی معلق مقدار منفی [Indent](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_indent/) تنظیم کنید.
7. پاراگراف‌ها را به قاب متن اضافه کنید.
8. ارائه اصلاح‌شده را ذخیره کنید.

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

نتیجه:

![تورفتگی معلق پاراگراف‌ها](hanging_indent.png)

## **مدیریت ویژگی‌های انتهای پاراگراف**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید حاوی پاراگراف را از طریق موقعیت آن دریافت کنید.
1. یک [autoshape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) مستطیلی به اسلاید اضافه کنید.
1. یک [TextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) با دو پاراگراف به مستطیل اضافه کنید.
1. `FontHeight` و نوع قلم را برای پاراگراف‌ها تنظیم کنید.
1. ویژگی‌های End را برای پاراگراف‌ها تنظیم کنید.
1. ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

```c++
// مسیر به پوشه اسناد.
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Load the desired the presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Access first slide
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Add an AutoShape of Rectangle type
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Add TextFrame to the Rectangle
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// Adding the first Paragraph
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Sample text");

para1->get_Portions()->Add(port01);

// Adding the second Paragraph
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"Sample text 2");

para2->get_Portions()->Add(port02);


SharedPtr<PortionFormat> endParagraphPortionFormat = MakeObject< PortionFormat>();
endParagraphPortionFormat->set_FontHeight ( 48);
endParagraphPortionFormat->set_LatinFont ( MakeObject< FontData>(u"Times New Roman"));
para2->set_EndParagraphPortionFormat(endParagraphPortionFormat);

ashp->get_TextFrame()->get_Paragraphs()->Add(para1);
ashp->get_TextFrame()->get_Paragraphs()->Add(para2);



// Save PPTX to Disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **وارد کردن متن HTML به پاراگراف‌ها**

Aspose.Slides پشتیبانی پیشرفته‌ای برای وارد کردن متن HTML به پاراگراف‌ها فراهم می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. از طریق شاخص، به ارجاع اسلاید مربوطه دسترسی پیدا کنید.
3. یک [autoshape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
4. `autoshape` را با [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) دسترسی پیدا کنید و اضافه کنید.
5. پاراگراف پیش‌فرض موجود در `ITextFrame` را حذف کنید.
6. فایل HTML منبع را در یک TextReader بخوانید.
7. اولین پاراگراف را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides/paragraph/) ایجاد کنید.
8. محتوای فایل HTML خوانده شده از TextReader را به [ParagraphCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/paragraphcollection/) قاب متن اضافه کنید.
9. ارائه اصلاح‌شده را ذخیره کنید.

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// مسیر به پوشه اسناد.
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// بارگذاری ارائه موردنظر
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// دسترسی به اسلاید اول
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// افزودن AutoShape از نوع مستطیل
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
// بازنشانی رنگ پر پیش‌فرض
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// افزودن TextFrame به مستطیل
ashp->AddTextFrame(u" ");

// دسترسی به فریم متن
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

// دریافت مجموعه Paragraphs
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// پاک کردن تمام پاراگراف‌ها در فریم متن اضافه‌شده
ParaCollection->Clear();

// بارگذاری فایل HTML با استفاده از StreamReader
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// افزودن متن از StreamReader HTML به فریم متن
ParaCollection->AddFromHtml(tr->ReadToEnd());


// ایجاد شیء Paragraph برای فریم متن
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// ایجاد شیء Portion برای پاراگراف
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

// دریافت قالب Portion
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// تنظیم فونت برای Portion
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// تنظیم ویژگی بولد برای فونت
pf->set_FontBold(NullableBool::True);

// تنظیم ویژگی ایتالیک برای فونت
pf->set_FontItalic(NullableBool::True);

// تنظیم ویژگی زیرخط برای فونت
pf->set_FontUnderline(TextUnderlineType::Single);

// تنظیم ارتفاع فونت
pf->set_FontHeight(25);

// تنظیم رنگ فونت
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// ذخیره PPTX بر روی دیسک
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);


```

## **خروجی متن پاراگراف به HTML**

Aspose.Slides پشتیبانی پیشرفته‌ای برای خروجی‌گیری متن‌های موجود در پاراگراف‌ها به HTML فراهم می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید و ارائه موردنظر را بارگذاری کنید.
2. از طریق شاخص، به ارجاع اسلاید مربوطه دسترسی پیدا کنید.
3. به شکل حاوی متنی که قرار است به HTML صادر شود دسترسی پیدا کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) شکل دسترسی پیدا کنید.
5. نمونه‌ای از `StreamWriter` ایجاد کنید و فایل HTML جدید را اضافه کنید.
6. یک شاخص شروع به StreamWriter بدهید و پاراگراف‌های موردنظر خود را صادر کنید.

```c++
// مسیر به پوشه اسناد.
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// بارگذاری ارائه موردنظر
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// دسترسی به اسلاید پیش‌فرض اولین ارائه
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// شاخص موردنظر
int index = 0;

// دسترسی به شکل اضافه‌شده
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// استخراج اولین پاراگراف به صورت HTML
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

// نوشتن داده‌های پاراگراف‌ها به HTML با تعیین شاخص شروع پاراگراف، تعداد کل پاراگراف‌های کپی‌شده
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();

```

## **ذخیره یک پاراگراف به عنوان تصویر**

در این بخش دو مثال بررسی می‌کنیم که نشان می‌دهند چگونه یک پاراگراف متنی، که توسط رابط [IParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraph/) نمایش داده می‌شود، به عنوان تصویر ذخیره شود. هر دو مثال شامل دریافت تصویر شکل حاوی پاراگراف با استفاده از متدهای `GetImage` از رابط [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/) است، محاسبه محدوده پاراگراف داخل شکل و خروجی‌گیری آن به صورت تصویر بیت‌مپ. این روش‌ها به شما امکان می‌دهند بخش‌های خاصی از متن را از ارائه‌های PowerPoint استخراج کنید و به‌صورت تصاویر جداگانه ذخیره نمایید که در سناریوهای مختلف می‌تواند مفید باشد.

فرض کنید یک فایل ارائه به نام sample.pptx با یک اسلاید داشته باشیم که اولین شکل آن یک کادر متن حاوی سه پاراگراف باشد.

![کادر متن با سه پاراگراف](paragraph_to_image_input.png)

**مثال 1**

در این مثال پاراگراف دوم به‌عنوان تصویر استخراج می‌شود. برای این کار، تصویر شکل را از اسلاید اول استخراج می‌کنیم و سپس محدوده پاراگراف دوم در قاب متنی شکل را محاسبه می‌کنیم. سپس پاراگراف بر روی یک تصویر بیت‌مپ جدید بازنگری می‌شود و به صورت PNG ذخیره می‌گردد. این روش مخصوصاً وقتی مفید است که بخواهید یک پاراگراف خاص را به‌صورت تصویر جداگانه ذخیره کنید و ابعاد و قالب‌بندی دقیق متن را حفظ کنید.

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

نتیجه:

![تصویر پاراگراف](paragraph_to_image_output.png)

**مثال 2**

در این مثال رویکرد قبلی با افزودن عوامل مقیاس به تصویر پاراگراف گسترش می‌یابد. شکل از ارائه استخراج می‌شود و با ضریب مقیاس `2` به‌عنوان تصویر ذخیره می‌شود. این امکان خروجی با وضوح بالاتر را هنگام خروجی‌گیری پاراگراف فراهم می‌کند. سپس محدوده پاراگراف با در نظر گرفتن مقیاس محاسبه می‌شود. مقیاس‌بندی به‌ویژه زمانی مفید است که نیاز به تصویر با جزئیات بیشتر باشد، برای مثال برای استفاده در مطالب چاپی با کیفیت بالا.

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

## **سوالات متداول**

**آیا می‌توانم بسته شدن خط در داخل یک قاب متن را به طور کامل غیرفعال کنم؟**

بله. از متد بسته شدن خط قاب متن ([set_WrapText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/textframeformat/set_wraptext/)) استفاده کنید تا بسته شدن خط غیرفعال شود و خطوط در لبه‌های قاب شکسته نشوند.

**چگونه می‌توانم محدوده دقیق یک پاراگراف خاص را روی اسلاید به دست آورم؟**

می‌توانید مستطیل محدوده‌گیری (bounding rectangle) پاراگراف (و حتی یک بخش منفرد) را دریافت کنید تا موقعیت و اندازه دقیق آن را روی اسلاید بدانید.

**کنترل تراز پاراگراف (چپ/راست/وسط/تعدیل) در کجا قرار دارد؟**

[Alignment](https://reference.aspose.com/slides/fa/cpp/aspose.slides/paragraphformat/set_alignment/) یک تنظیم سطح پاراگراف در [ParagraphFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/paragraphformat/) است؛ این تنظیم برای تمام پاراگراف اعمال می‌شود بدون در نظر گرفتن قالب‌بندی بخش‌های جداگانه.

**آیا می‌توانم زبان بررسی املایی را فقط برای بخشی از یک پاراگراف (مثلاً یک کلمه) تنظیم کنم؟**

بله. زبان در سطح بخش تنظیم می‌شود با استفاده از ([PortionFormat::set_LanguageId](https://reference.aspose.com/slides/fa/cpp/aspose.slides/baseportionformat/set_languageid/))، بنابراین می‌توان چندین زبان را در یک پاراگراف همزمان داشته باشید.