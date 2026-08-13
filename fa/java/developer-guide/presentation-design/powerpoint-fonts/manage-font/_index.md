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
- Java
- Aspose.Slides
description: "قلم‌ها را در جاوا با Aspose.Slides کنترل کنید: جاسازی، جایگزینی و بارگذاری قلم‌های سفارشی برای این‌که ارائه‌های PPT، PPTX و ODP واضح، سازگار با برند و یکدست بمانند."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های قلم را در متن ارائه‌ها به‌صورت مستقیم از کد خود مدیریت کنید. می‌توانید به متن در اسلایدها از طریق اشکال، فریم‌های متن، پاراگراف‌ها و بخش‌ها دسترسی پیدا کنید و سپس قالب‌بندی را بر روی متن انتخاب‌شده اعمال کنید.

این مقاله توضیح می‌دهد چگونه ویژگی‌های مربوط به قلم برای متن موجود در یک ارائه تنظیم شود، از جمله خانواده قلم، سبک‌های بولد و ایتالیک، تراز پاراگراف و رنگ قلم. همچنین نشان می‌دهد چگونه یک جعبه متن ایجاد کنید، متن را به آن اضافه کنید و ویژگی‌های قلم مانند خانواده قلم، بولد، ایتالیک، زیرخط، اندازه قلم و رنگ را تنظیم کرده و در نهایت نتیجه را به‌صورت فایل PPTX ذخیره کنید.

## **مدیریت ویژگی‌های مرتبط با قلم**
{{% alert color="info" %}} 

ارائه‌ها معمولاً شامل متن و تصویر هستند. متن می‌تواند به‌روش‌های مختلفی قالب‌بندی شود، چه برای برجسته‌سازی بخش‌ها و واژه‌های خاص و چه برای سازگاری با سبک‌های شرکتی. قالب‌بندی متن به کاربران امکان می‌دهد ظاهر محتوای ارائه را متنوع کنند. این مقاله نشان می‌دهد چگونه از Aspose.Slides for Java برای تنظیم ویژگی‌های قلم پاراگراف‌های متنی در اسلایدها استفاده کنید.

{{% /alert %}} 

برای مدیریت ویژگی‌های قلم یک پاراگراف با Aspose.Slides for Java:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
1. با استفاده از اندیس آن، مرجع یک اسلاید را به دست آورید.
1. اشکال [Placeholder](https://reference.aspose.com/slides/fa/java/com.aspose.slides/placeholder/) را در اسلاید دریافت کنید و آن‌ها را به [AutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/autoshape/) تبدیل کنید.
1. از [TextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textframe/) ارائه‌شده توسط [AutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/autoshape/)، یک [Paragraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/paragraph/) دریافت کنید.
1. پاراگراف را تو رفتگی (Justify) کنید.
1. متن یک [Paragraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/paragraph/) را از طریق [Portion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/portion/) دسترسی پیدا کنید.
1. قلم را با استفاده از [FontData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontdata/) تعریف کنید و **Font** متن [Portion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/portion/) را به‌صورت مناسب تنظیم کنید.
   1. قلم را به حالت بولد (Bold) تنظیم کنید.
   1. قلم را به حالت ایتالیک (Italic) تنظیم کنید.
1. رنگ قلم را با استفاده از [FillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fillformat/) ارائه‌شده توسط شیء [Portion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/portion/) تنظیم کنید.
1. ارائه اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

پیاده‌سازی مراحل فوق در زیر آورده شده است. این کد یک ارائه ساده را می‌گیرد و قلم‌های یک اسلاید را قالب‌بندی می‌کند. اسکرین‌شات‌های زیر فایل ورودی و نحوه تغییر آن توسط کد را نشان می‌دهند. کد قلم، رنگ و سبک قلم را تغییر می‌دهد.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**تصویر: متن در فایل ورودی**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**تصویر: همان متن با قالب‌بندی به‌روز شده**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instantiate a Presentation object that represents a PPTX file
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Accessing a slide using its slide position
	ISlide slide = pres.getSlides().get_Item(0);

	// Accessing the first and second placeholder in the slide and typecasting it as AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// Accessing the first Paragraph
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// Justify the paragraph
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Accessing the first portion
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Define new fonts
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Assign new fonts to portion
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Set font to Bold
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Set font to Italic
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// Set font color
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// Save the PPTX to disk
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **تنظیم ویژگی‌های قلم متن**
{{% alert color="info" %}} 

همان‌طور که در **Managing Font Related Properties** اشاره شد، یک [Portion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/portion/) برای نگه داشتن متنی با سبک قالب‌بندی مشابه در یک پاراگراف استفاده می‌شود. این مقاله نشان می‌دهد چگونه با Aspose.Slides برای Java یک جعبه متن ایجاد کنید، متنی به آن اضافه کنید و سپس قلم خاصی و سایر ویژگی‌های مربوط به دسته قلم را تعریف کنید.

{{% /alert %}} 

برای ایجاد یک جعبه متن و تنظیم ویژگی‌های قلم متن داخل آن:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
1. با استفاده از اندیس، مرجع یک اسلاید را به دست آورید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/autoshape/) از نوع **Rectangle** به اسلاید اضافه کنید.
1. سبک پر شدن (Fill) مرتبط با [AutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/autoshape/) را حذف کنید.
1. به [TextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textframe/) مربوط به [AutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/autoshape/) دسترسی پیدا کنید.
1. متنی به [TextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textframe/) اضافه کنید.
1. به شیء [Portion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/portion/) مرتبط با [TextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textframe/) دسترسی پیدا کنید.
1. قلم مورد استفاده برای [Portion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/portion/) را تعریف کنید.
1. سایر ویژگی‌های قلم مانند بولد، ایتالیک، زیرخط، رنگ و ارتفاع را با استفاده از ویژگی‌های مربوطه در شیء [Portion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/portion/) تنظیم کنید.
1. ارائه اصلاح‌شده را به‌صورت فایل PPTX بنویسید.

پیاده‌سازی مراحل فوق در زیر آورده شده است.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**تصویر: متن با برخی ویژگی‌های قلم تنظیم‌شده توسط Aspose.Slides for Java**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// نمونه‌ای از شی Presentation که نشان‌دهنده یک فایل PPTX است
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
	
	// تنظیم خصوصیت بولد قلم
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// تنظیم خصوصیت ایتالیک قلم
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// تنظیم خصوصیت زیرخط قلم
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// تنظیم ارتفاع قلم
	port.getPortionFormat().setFontHeight(25);
	
	// تنظیم رنگ قلم
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// ذخیرهٔ ارائه در دیسک
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```