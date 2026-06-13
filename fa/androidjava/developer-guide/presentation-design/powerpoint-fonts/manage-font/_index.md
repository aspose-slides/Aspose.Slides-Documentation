---
title: مدیریت قلم‌ها در ارائه‌ها روی اندروید
linktitle: مدیریت قلم‌ها
type: docs
weight: 10
url: /fa/androidjava/manage-fonts/
keywords:
- مدیریت قلم‌ها
- ویژگی‌های قلم
- پاراگراف
- قالب‌بندی متن
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "قلم‌ها را در جاوا با Aspose.Slides برای اندروید کنترل کنید: قلم‌های سفارشی را درج، جایگزین و بارگذاری کنید تا ارائه‌های PPT، PPTX و ODP واضح، امن برای برند و سازگار باقی بمانند."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد که ویژگی‌های قلم را در متن ارائه به‌صورت مستقیم از کد خود مدیریت کنید. می‌توانید متن اسلایدها را از طریق شکل‌ها، فریم‌های متن، پاراگراف‌ها و Portion دسترسی پیدا کنید و سپس قالب‌بندی موردنظر را بر روی متن انتخاب‌شده اعمال کنید.

این مقاله نحوه پیکربندی ویژگی‌های مربوط به قلم برای متن موجود در یک ارائه را توضیح می‌دهد، از جمله خانواده قلم، سبک‌های بولد و ایتالیک، تراز پاراگراف و رنگ قلم. همچنین نشان می‌دهد چگونه یک جعبه متن ایجاد کنید، متنی به آن اضافه کنید، و ویژگی‌های قلم مانند خانواده قلم، بولد، ایتالیک، زیرخط، اندازه قلم و رنگ را تنظیم کنید قبل از ذخیره نتایج به عنوان فایل PPTX.

## **مدیریت ویژگی‌های مربوط به قلم**
{{% alert color="primary" %}} 

معمولاً ارائه‌ها شامل هر دو متن و تصویر هستند. متن می‌تواند به روش‌های مختلفی قالب‌بندی شود، چه برای برجسته‌سازی بخش‌ها و کلمات خاص و چه برای سازگاری با سبک‌های سازمانی. قالب‌بندی متن به کاربران امکان می‌دهد ظاهر و حس محتوای ارائه را متنوع‌تر کنند. این مقاله نشان می‌دهد چگونه از Aspose.Slides for Android via Java برای پیکربندی ویژگی‌های قلم پاراگراف‌های متن در اسلایدها استفاده کنید.

{{% /alert %}} 

برای مدیریت ویژگی‌های قلم یک پاراگراف با استفاده از Aspose.Slides for Android via Java:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
1. با استفاده از اندیس آن، مرجع یک اسلاید را دریافت کنید.
1. شکل‌های [Placeholder](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/placeholder/) را در اسلاید دسترسی پیدا کنید و آنها را به نوع [AutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/autoshape/) تبدیل کنید.
1. [Paragraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/paragraph/) را از [TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textframe/) که توسط [AutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/autoshape/) ارائه شده دریافت کنید.
1. پاراگراف را تراز (Justify) کنید.
1. به متن یک [Paragraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/paragraph/)، بخش [Portion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/portion/) دسترسی پیدا کنید.
1. قلم را با استفاده از [FontData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontdata/) تعریف کنید و **Font** متن [Portion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/portion/) را به‌همین ترتیب تنظیم کنید.
   1. قلم را به حالت بولد تنظیم کنید.
   1. قلم را به حالت ایتالیک تنظیم کنید.
1. رنگ قلم را با استفاده از [FillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fillformat/) که توسط شیء [Portion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/portion/) ارائه شده، تنظیم کنید.
1. ارائه تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

پیاده‌سازی گام‌های بالا در کد زیر نشان داده شده است. این کد یک ارائهٔ ساده را می‌گیرد و قلم‌های یکی از اسلایدها را قالب‌بندی می‌کند. تصاویر زیر فایل ورودی و نحوهٔ تغییر کدها را نشان می‌دهند. کد قلم، رنگ و سبک قلم را تغییر می‌دهد.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**شکل: متن در فایل ورودی**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**شکل: همان متن با قالب‌بندی به‌روزرسانی‌شده**|

```java
// یک شی Presentation ایجاد کنید که نمایانگر یک فایل PPTX است
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// دسترسی به اسلاید با استفاده از موقعیت اسلاید آن
	ISlide slide = pres.getSlides().get_Item(0);

	// دسترسی به اولین و دومین Placeholder در اسلاید و تبدیل نوع آن به AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// دسترسی به پاراگراف اول
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// تراز کردن پاراگراف
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// دسترسی به اولین Portion
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// تعریف قلم‌های جدید
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// اختصاص قلم‌های جدید به Portion
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// تنظیم قلم به حالت Bold
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// تنظیم قلم به حالت Italic
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// تنظیم رنگ قلم
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// ذخیره PPTX در دیسک
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **تنظیم ویژگی‌های قلم متن**
{{% alert color="primary" %}} 

همان‌طور که در **مدیریت ویژگی‌های مربوط به قلم** اشاره شد، یک [Portion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/portion/) برای نگه‌دارند متن با سبک قالب‌بندی مشابه در یک پاراگراف استفاده می‌شود. این مقاله نشان می‌دهد چگونه با استفاده از Aspose.Slides for Android via Java یک جعبه متن با متنی ایجاد کنید و سپس یک قلم خاص و ویژگی‌های مختلف دستهٔ خانواده قلم را تعریف کنید.

{{% /alert %}} 

برای ایجاد یک جعبه متن و تنظیم ویژگی‌های قلم متن داخل آن:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
1. مرجع یک اسلاید را با استفاده از اندیس آن به‌دست آورید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/autoshape/) از نوع **Rectangle** به اسلاید اضافه کنید.
1. سبک پر (fill) مرتبط با [AutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/autoshape/) را حذف کنید.
1. به [TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textframe/) متعلق به [AutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/autoshape/) دسترسی پیدا کنید.
1. برخی متن‌ها را به [TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textframe/) اضافه کنید.
1. شیء [Portion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/portion/) مرتبط با [TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textframe/) را دسترسی پیدا کنید.
1. قلم مورد استفاده برای [Portion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/portion/) را تعریف کنید.
1. سایر ویژگی‌های قلم مانند بولد، ایتالیک، زیرخط، رنگ و ارتفاع را با استفاده از ویژگی‌های مربوطه که توسط شیء [Portion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/portion/) ارائه شده، تنظیم کنید.
1. ارائه تغییر یافته را به‌عنوان فایل PPTX بنویسید.

پیاده‌سازی گام‌های بالا در کد زیر آمده است.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**شکل: متن با برخی ویژگی‌های قلم که توسط Aspose.Slides for Android via Java تنظیم شده است**|

```java
// یک شی Presentation ایجاد کنید که نمایانگر یک فایل PPTX است
Presentation pres = new Presentation();
try {
	// دریافت اولین اسلاید
	ISlide sld = pres.getSlides().get_Item(0);
	
	// یک AutoShape از نوع Rectangle اضافه کنید
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// هر سبک fill مرتبط با AutoShape را حذف کنید
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// دسترسی به TextFrame مرتبط با AutoShape
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// دسترسی به Portion مرتبط با TextFrame
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// تنظیم قلم برای Portion
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// تنظیم ویژگی Bold قلم
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// تنظیم ویژگی Italic قلم
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// تنظیم ویژگی Underline قلم
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// تنظیم ارتفاع قلم
	port.getPortionFormat().setFontHeight(25);
	
	// تنظیم رنگ قلم
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// ذخیره ارائه در دیسک
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```