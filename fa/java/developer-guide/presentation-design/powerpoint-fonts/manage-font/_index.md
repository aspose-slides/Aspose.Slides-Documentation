---
title: مدیریت قلم‌ها در ارائه‌ها با استفاده از جاوا
linktitle: مدیریت قلم‌ها
type: docs
weight: 10
url: /fa/java/manage-fonts/
keywords:
- مدیریت قلم‌ها
- ویژگی‌های قلم
- پاراگراف
- قالب‌بندی متن
- PowerPoint
- OpenDocument
- ارائه
- جاوا
- Aspose.Slides
description: "قلم‌ها را در جاوا با Aspose.Slides کنترل کنید: تعبیه، جایگزینی و بارگذاری قلم‌های سفارشی برای حفظ واضح، ایمن برای برند و سازگار بودن ارائه‌های PPT، PPTX و ODP."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد که ویژگی‌های قلم را در متن ارائه‌ها مستقیماً از کد خود مدیریت کنید. می‌توانید متن در اسلایدها را از طریق اشکال، قاب‌های متن، پاراگراف‌ها و بخش‌ها دسترسی یافته و سپس قالب‌بندی را بر روی متن انتخاب‌شده اعمال کنید.

این مقاله توضیح می‌دهد که چگونه ویژگی‌های مربوط به قلم را برای متن موجود در یک ارائه پیکربندی کنید، از جمله خانواده قلم، سبک‌های ضخیم و کج، تراز پاراگراف و رنگ قلم. همچنین نشان می‌دهد چگونه یک جعبه متن ایجاد کنید، متنی به آن اضافه کنید و ویژگی‌های قلم مانند خانواده قلم، ضخیم، کج، زیرخط، اندازه قلم و رنگ را قبل از ذخیره نتیجه به‌صورت فایل PPTX تنظیم کنید.

## **مدیریت ویژگی‌های مربوط به قلم**
{{% alert color="primary" %}} 

ارائه‌ها معمولاً شامل هر دو متن و تصویر هستند. متن می‌تواند به روش‌های مختلف قالب‌بندی شود، چه برای برجسته کردن بخش‌ها و کلمات خاص و چه برای هماهنگی با سبک‌های شرکتی. قالب‌بندی متن به کاربران کمک می‌کند ظاهر و احساس محتوای ارائه را متنوع کنند. این مقاله نشان می‌دهد چگونه از Aspose.Slides برای Java برای پیکربندی ویژگی‌های قلم پاراگراف‌های متن در اسلایدها استفاده کنید.

{{% /alert %}} 

برای مدیریت ویژگی‌های قلم یک پاراگراف با استفاده از Aspose.Slides برای Java:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
1. مرجع یک اسلاید را با استفاده از ایندکس آن به دست آورید.
1. به اشکال [Placeholder](https://reference.aspose.com/slides/fa/java/com.aspose.slides/placeholder/) در اسلاید دسترسی پیدا کنید و آنها را به نوع [AutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/autoshape/) تبدیل کنید.
1. [Paragraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/paragraph/) را از [TextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textframe/) که توسط [AutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/autoshape/) ارائه می‌شود، دریافت کنید.
1. پاراگراف را هم‌تراز کنید.
1. به [Portion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/portion/) متن یک [Paragraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/paragraph/) دسترسی پیدا کنید.
1. قلم را با استفاده از [FontData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontdata/) تعریف کنید و **Font** متن [Portion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/portion/) را متناسب تنظیم کنید.
   1. قلم را به حالت ضخیم (Bold) تنظیم کنید.
   1. قلم را به حالت کج (Italic) تنظیم کنید.
1. رنگ قلم را با استفاده از [FillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fillformat/) که توسط شیء [Portion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/portion/) ارائه می‌شود، تنظیم کنید.
1. ارائه اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

پیاده‌سازی قدم‌های فوق در زیر آورده شده است. این کد یک ارائه ساده را گرفته و قلم‌های یکی از اسلایدها را قالب‌بندی می‌کند. اسکرین‌شات‌های زیر فایل ورودی و نحوه تغییر آن توسط کد را نشان می‌دهند. کد قلم، رنگ و سبک قلم را تغییر می‌دهد.

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
		// دسترسی به اسلاید با استفاده از موقعیت آن
		ISlide slide = pres.getSlides().get_Item(0);

		// دسترسی به اولین و دومین placeholder در اسلاید و تبدیل نوع آن به AutoShape
		ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
		ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

		// دسترسی به اولین پاراگراف
		IParagraph para1 = tf1.getParagraphs().get_Item(0);
		IParagraph para2 = tf2.getParagraphs().get_Item(0);

		// هم‌تراز کردن پاراگراف
		para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

		// دسترسی به اولین بخش
		IPortion port1 = para1.getPortions().get_Item(0);
		IPortion port2 = para2.getPortions().get_Item(0);

		// تعریف قلم‌های جدید
		FontData fd1 = new FontData("Elephant");
		FontData fd2 = new FontData("Castellar");

		// اختصاص قلم‌های جدید به بخش
		port1.getPortionFormat().setLatinFont(fd1);
		port2.getPortionFormat().setLatinFont(fd2);

		// تنظیم قلم به حالت ضخیم
		port1.getPortionFormat().setFontBold(NullableBool.True);
		port2.getPortionFormat().setFontBold(NullableBool.True);

		// تنظیم قلم به حالت کج
		port1.getPortionFormat().setFontItalic(NullableBool.True);
		port2.getPortionFormat().setFontItalic(NullableBool.True);

		// تنظیم رنگ قلم
		port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
		port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
		port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
		port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

		// ذخیره PPTX بر روی دیسک
		pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
		if (pres != null) pres.dispose();
}
```

## **تنظیم ویژگی‌های قلم متن**
{{% alert color="primary" %}} 

همان‌طور که در **مدیریت ویژگی‌های مربوط به قلم** اشاره شد، یک [Portion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/portion/) برای نگهداری متنی با سبک قالب‌بندی مشابه در یک پاراگراف استفاده می‌شود. این مقاله نشان می‌دهد چگونه از Aspose.Slides برای Java برای ایجاد یک جعبه متن حاوی برخی متن‌ها استفاده کنید و سپس یک قلم خاص و ویژگی‌های مختلف دیگر دسته‌بندی خانواده قلم را تعریف کنید.

{{% /alert %}} 

برای ایجاد یک جعبه متن و تنظیم ویژگی‌های قلم متن داخل آن:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
1. مرجع یک اسلاید را با استفاده از ایندکس آن به دست آورید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/autoshape/) از نوع **Rectangle** به اسلاید اضافه کنید.
1. سبک پر شدن مرتبط با [AutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/autoshape/) را حذف کنید.
1. به [TextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textframe/) مربوط به [AutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/autoshape/) دسترسی پیدا کنید.
1. متنی به [TextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textframe/) اضافه کنید.
1. به شیء [Portion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/portion/) مرتبط با [TextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textframe/) دسترسی پیدا کنید.
1. قلم مورد استفاده برای [Portion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/portion/) را تعریف کنید.
1. سایر ویژگی‌های قلم مانند ضخیم، کج، زیرخط، رنگ و ارتفاع را با استفاده از ویژگی‌های مربوطه که توسط شیء [Portion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/portion/) ارائه می‌شود، تنظیم کنید.
1. ارائه اصلاح‌شده را به‌عنوان فایل PPTX بنویسید.

پیاده‌سازی قدم‌های فوق در زیر آورده شده است.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**شکل: متن با برخی ویژگی‌های قلم که توسط Aspose.Slides for Java تنظیم شده است**|

```java
// یک شی Presentation ایجاد کنید که نمایانگر یک فایل PPTX است
Presentation pres = new Presentation();
try {
	// دریافت اولین اسلاید
	ISlide sld = pres.getSlides().get_Item(0);
	
	// افزودن یک AutoShape از نوع Rectangle
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// حذف هر سبک پر شدن مرتبط با AutoShape
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
	
	// ذخیره ارائه بر روی دیسک
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```