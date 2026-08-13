---
title: مدیریت فونت‌ها در ارائه‌ها در اندروید
linktitle: مدیریت فونت‌ها
type: docs
weight: 10
url: /fa/androidjava/manage-fonts/
keywords:
- مدیریت فونت‌ها
- ویژگی‌های فونت
- پاراگراف
- قالب‌بندی متن
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "کنترل فونت‌ها در Java با Aspose.Slides برای Android: جاسازی، جایگزینی و بارگذاری فونت‌های سفارشی برای حفظ وضوح، ایمن بودن برند و سازگاری ارائه‌های PPT، PPTX و ODP."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های قلم را در متن ارائه به‌طور مستقیم از داخل کد خود مدیریت کنید. می‌توانید متن در اسلایدها را از طریق اشکال، فریم‌های متنی، پاراگراف‌ها و Portion دسترسی پیدا کنید و سپس قالب‌بندی را بر روی متن انتخاب‌شده اعمال کنید.

این مقاله نحوه پیکربندی ویژگی‌های مربوط به قلم برای متن موجود در یک ارائه را توضیح می‌دهد، از جمله خانواده قلم، حالت‌های بولد و ایتالیک، تراز پاراگراف و رنگ قلم. همچنین نشان می‌دهد چگونه یک جعبه متنی ایجاد کنید، متنی به آن اضافه کنید و ویژگی‌های قلم مانند خانواده قلم، بولد، ایتالیک، زیرخط، اندازه قلم و رنگ را تنظیم کنید قبل از اینکه نتیجه را به‌صورت فایل PPTX ذخیره کنید.

## **مدیریت ویژگی‌های مربوط به قلم**
{{% alert color="info" %}} 

ارائه‌ها معمولاً شامل متن و تصاویر هستند. متن می‌تواند به روش‌های مختلف قالب‌بندی شود، چه برای برجسته‌سازی بخش‌ها و کلمات خاص و چه برای سازگاری با استایل‌های سازمانی. قالب‌بندی متن به کاربران کمک می‌کند تا ظاهر محتویات ارائه را متنوع کنند. این مقاله نشان می‌دهد چگونه از Aspose.Slides برای Android از طریق Java برای پیکربندی ویژگی‌های قلم پاراگراف‌های متن در اسلایدها استفاده کنید.

{{% /alert %}} 

برای مدیریت ویژگی‌های قلم یک پاراگراف با استفاده از Aspose.Slides برای Android از طریق Java:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
1. مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید.
1. اشکال [Placeholder](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/placeholder/) را در اسلاید دسترسی پیدا کنید و آنها را به [AutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/autoshape/) تبدیل کنید.
1. از [AutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/autoshape/) ارائه‌شده، [Paragraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/paragraph/) را از [TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textframe/) دریافت کنید.
1. پاراگراف را تراز کنید.
1. به [Portion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/portion/) متن یک [Paragraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/paragraph/) دسترسی پیدا کنید.
1. قلم را با استفاده از [FontData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontdata/) تعریف کنید و **Font** متن [Portion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/portion/) را به‌طور مناسب تنظیم کنید.
   1. قلم را به حالت بولد تنظیم کنید.
   1. قلم را به حالت ایتالیک تنظیم کنید.
1. رنگ قلم را با استفاده از [FillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fillformat/) که توسط شیء [Portion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/portion/) ارائه می‌شود تنظیم کنید.
1. ارائه اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

پیاده‌سازی مراحل بالا در ادامه آورده شده است. این کد یک ارائه ساده را می‌گیرد و قلم‌ها را در یکی از اسلایدها قالب‌بندی می‌کند. تصویرهای زیر فایل ورودی و نحوه تغییر آن توسط کد را نشان می‌دهند. کد قلم، رنگ و سبک قلم را تغییر می‌دهد.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**شکل: متن در فایل ورودی**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**شکل: همان متن با قالب‌بندی بروز شده**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک شی Presentation که نمایانگر فایل PPTX است را ایجاد کنید
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// دسترسی به اسلاید با استفاده از موقعیت آن
	ISlide slide = pres.getSlides().get_Item(0);

	// دسترسی به اولین و دومین مکان‌نگهدار در اسلاید و تبدیل نوع آن به AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// دسترسی به اولین پاراگراف
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// پاراگراف را توجیهی کنید
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// دسترسی به اولین Portion
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// تعریف قلم‌های جدید
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// تخصیص قلم‌های جدید به Portion
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// قلم را به حالت بولد تنظیم کنید
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// قلم را به حالت ایتالیک تنظیم کنید
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// تنظیم رنگ قلم
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// ذخیره فایل PPTX بر روی دیسک
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **تنظیم ویژگی‌های قلم متن**
{{% alert color="info" %}} 

همان‌طور که در **مدیریت ویژگی‌های مربوط به قلم** اشاره شد، یک [Portion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/portion/) برای نگه‌داری متنی با سبک قالب‌بندی مشابه در یک پاراگراف استفاده می‌شود. این مقاله نشان می‌دهد چگونه از Aspose.Slides برای Android از طریق Java برای ایجاد یک جعبه متن با برخی متن‌ها و سپس تعریف قلم خاص و سایر ویژگی‌های دسته خانواده قلم استفاده کنید.

{{% /alert %}} 

برای ایجاد یک جعبه متن و تنظیم ویژگی‌های قلم متن در داخل آن:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
1. مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/autoshape/) از نوع **Rectangle** به اسلاید اضافه کنید.
1. سبک پر (fill) مرتبط با [AutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/autoshape/) را حذف کنید.
1. به [TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textframe/) مربوط به [AutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/autoshape/) دسترسی پیدا کنید.
1. متنی را به [TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textframe/) اضافه کنید.
1. به شیء [Portion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/portion/) مرتبط با [TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textframe/) دسترسی پیدا کنید.
1. قلم مورد استفاده برای [Portion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/portion/) را تعریف کنید.
1. سایر ویژگی‌های قلم مانند بولد، ایتالیک، زیرخط، رنگ و ارتفاع را با استفاده از ویژگی‌های مربوطه که توسط شیء [Portion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/portion/) ارائه می‌شود تنظیم کنید.
1. ارائه اصلاح‌شده را به‌صورت فایل PPTX بنویسید.

پیاده‌سازی مراحل فوق در ادامه آورده شده است.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**شکل: متن با برخی ویژگی‌های قلم تنظیم‌شده توسط Aspose.Slides برای Android از طریق Java**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک شی Presentation که نمایانگر یک فایل PPTX است را ایجاد کنید
Presentation pres = new Presentation();
try {
	// دریافت اولین اسلاید
	ISlide sld = pres.getSlides().get_Item(0);
	
	// افزودن AutoShape از نوع Rectangle
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// حذف هر سبک پر (fill) مرتبط با AutoShape
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