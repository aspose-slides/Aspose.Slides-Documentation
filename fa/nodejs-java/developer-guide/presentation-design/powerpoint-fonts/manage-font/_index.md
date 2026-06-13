---
title: مدیریت قلم‌ها در ارائه‌ها با استفاده از جاوا اسکریپت
linktitle: مدیریت قلم‌ها
type: docs
weight: 10
url: /fa/nodejs-java/manage-fonts/
keywords:
- مدیریت قلم‌ها
- ویژگی‌های قلم
- پاراگراف
- قالب‌بندی متن
- پاورپوینت
- سند باز
- ارائه
- Node.js
- جاوا اسکریپت
- Aspose.Slides
description: "قلم‌ها را با Aspose.Slides برای Node.js از طریق Java کنترل کنید: افزودن، جایگزینی و بارگذاری قلم‌های سفارشی برای حفظ وضوح و سازگاری ارائه‌های PPT، PPTX و ODP."
---
## **مقدمه**

ارائه‌ها معمولاً حاوی هر دو متن و تصویر هستند. متن می‌تواند به روش‌های مختلف قالب‌بندی شود، چه برای برجسته‌سازی بخش‌ها و کلمات خاص و چه برای هماهنگ‌سازی با سبک‌های شرکتی. قالب‌بندی متن به کاربران کمک می‌کند ظاهر و احساس محتوای ارائه را متغیر کنند. این مقاله نشان می‌دهد چگونه از Aspose.Slides برای Node.js از طریق Java برای پیکربندی ویژگی‌های قلم پاراگراف‌های متن در اسلایدها استفاده شود.

## **مدیریت ویژگی‌های مرتبط با قلم**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید.  
1. با استفاده از ایندکس اسلاید، ارجاع آن را به دست آورید.  
1. به اشکال [Placeholder](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/placeholder/) در اسلاید دسترسی پیدا کنید و آن‌ها را به [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) تبدیل نوع (typecast) کنید.  
1. از [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) که توسط [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) نمایان شده است، [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) را به دست آورید.  
1. پاراگراف را تراز کنید.  
1. به [Portion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/) متن یک [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) دسترسی پیدا کنید.  
1. قلم را با استفاده از [FontData](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontdata/) تعریف کنید و **Font** متن [Portion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/) را متناسب تنظیم کنید.  
   1. فونت را به حالت بولد (پررنگ) تنظیم کنید.  
   1. فونت را به حالت ایتالیک تنظیم کنید.  
1. رنگ قلم را با استفاده از [FillFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fillformat/) که توسط شیء [Portion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/) نمایان شده است، تنظیم کنید.  
1. ارائه‌ی اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

پیاده‌سازی مراحل فوق در زیر ارائه شده است. این کد یک ارائهٔ ساده را می‌گیرد و قلم‌ها را در یکی از اسلایدها قالب‌بندی می‌کند. اسکرین‌شات‌های زیر فایل ورودی و نحوهٔ تغییر آن توسط قطعات کد را نشان می‌دهند. این کد قلم، رنگ و سبک قلم را تغییر می‌دهد.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figure: متن در فایل ورودی**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figure: همان متن با قالب‌بندی به‌روزشده**|

```javascript
// ایجاد یک شیء Presentation که نمایانگر یک فایل PPTX است
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // دسترسی به یک اسلاید با استفاده از موقعیت اسلاید آن
    var slide = pres.getSlides().get_Item(0);
    // دسترسی به اولین و دومین placeholder در اسلاید و تبدیل نوع آن به AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // دسترسی به اولین پاراگراف
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // تراز کردن پاراگراف
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.JustifyLow);
    // دسترسی به اولین بخش
    var port1 = para1.getPortions().get_Item(0);
    var port2 = para2.getPortions().get_Item(0);
    // تعریف قلم‌های جدید
    var fd1 = new aspose.slides.FontData("Elephant");
    var fd2 = new aspose.slides.FontData("Castellar");
    // اختصاص قلم‌های جدید به بخش
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);
    // تنظیم قلم به حالت بولد
    port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // تنظیم قلم به حالت ایتالیک
    port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // تنظیم رنگ قلم
    port1.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // ذخیرهٔ PPTX در دیسک
    pres.save("WelcomeFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تنظیم ویژگی‌های قلم متن**
{{% alert color="primary" %}} 

همان‌طور که در **Managing Font Related Properties** اشاره شد، یک [Portion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/) برای نگه‌داشتن متنی با سبک قالب‌بندی مشابه در یک پاراگراف استفاده می‌شود. این مقاله نشان می‌دهد چگونه از Aspose.Slides برای Node.js از طریق Java برای ایجاد یک جعبهٔ متن با برخی متن‌ها استفاده کرده و سپس یک قلم خاص و ویژگی‌های مختلف دیگر دستهٔ خانوادهٔ قلم را تعریف کنیم. 

{{% /alert %}} 

برای ایجاد یک جعبهٔ متن و تنظیم ویژگی‌های قلم متن در آن:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید.  
1. با استفاده از ایندکس اسلاید، ارجاع آن را به دست آورید.  
1. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) از نوع **Rectangle** به اسلاید اضافه کنید.  
1. سبک پر کردن مرتبط با [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) را حذف کنید.  
1. به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) مربوط به [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) دسترسی پیدا کنید.  
1. متنی را به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) اضافه کنید.  
1. به شیء [Portion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/) مرتبط با [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) دسترسی پیدا کنید.  
1. قلم مورد استفاده برای [Portion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/) را تعریف کنید.  
1. ویژگی‌های دیگر قلم مانند بولد، ایتالیک، زیرخط، رنگ و ارتفاع را با استفاده از ویژگی‌های مرتبط که توسط شیء [Portion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/) نمایان شده است، تنظیم کنید.  
1. ارائهٔ اصلاح‌شده را به‌عنوان فایل PPTX بنویسید.

پیاده‌سازی مراحل فوق در زیر ارائه شده است.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figure: متن با برخی ویژگی‌های قلم تنظیم‌شده توسط Aspose.Slides برای Node.js از طریق Java**|

```javascript
// یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
var pres = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید
    var sld = pres.getSlides().get_Item(0);
    // یک AutoShape از نوع Rectangle اضافه می‌کند
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // حذف هر سبک پر کردن مرتبط با AutoShape
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // دسترسی به TextFrame مرتبط با AutoShape
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // دسترسی به Portion مرتبط با TextFrame
    var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
    // تنظیم قلم برای Portion
    port.getPortionFormat().setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // تنظیم ویژگی بولد قلم
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // تنظیم ویژگی ایتالیک قلم
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // تنظیم ویژگی زیرخط قلم
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // تنظیم ارتفاع قلم
    port.getPortionFormat().setFontHeight(25);
    // تنظیم رنگ قلم
    port.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // ذخیرهٔ ارائه در دیسک
    pres.save("pptxFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```