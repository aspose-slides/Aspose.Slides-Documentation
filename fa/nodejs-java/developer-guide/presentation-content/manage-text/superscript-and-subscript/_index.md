---
title: مدیریت بالانویس و زیرنویس در ارائه‌ها با استفاده از JavaScript
linktitle: بالانویس و زیرنویس
type: docs
weight: 80
url: /fa/nodejs-java/superscript-and-subscript/
keywords:
- بالانویس
- زیرنویس
- افزودن بالانویس
- افزودن زیرنویس
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "بالانویس و زیرنویس را در Aspose.Slides برای Node.js از طریق Java به‌کار ببرید و ارائه‌های خود را با قالب‌بندی متن حرفه‌ای برای بیشترین تأثیر ارتقا دهید."
---
## **نمای کلی**

Aspose.Slides قابلیت افزودن متن بالانویس و زیرنویس را به ارائه‌های PowerPoint (PPT، PPTX) و OpenDocument (ODP) شما فراهم می‌کند. چه برای برجسته‌کردن فرمول‌های شیمیایی، معادلات ریاضی یا افزودن پاورقی به محتوا نیاز داشته باشید، این گزینه‌های قالب‌بندی تخصصی به حفظ وضوح و دقت کمک می‌کند. در این مقاله می‌آموزید که چگونه به‌صورت یکپارچه سبک‌های بالانویس و زیرنویس را اعمال کنید و نتایج حرفه‌ای در هر اسلاید به‌دست آورید.

## **مدیریت متن بالانویس و زیرنویس**

می‌توانید متن بالانویس و زیرنویس را در هر بخش از پاراگراف اضافه کنید. برای افزودن متن بالانویس یا زیرنویس در قاب متن Aspose.Slides باید از متد [**setEscapement**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/BasePortionFormat#setEscapement-float-) کلاس [PortionFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PortionFormat) استفاده کنید.

این ویژگی مقدار بالانویس یا زیرنویس متن را برمی‌گرداند یا تنظیم می‌کند (مقدار از -100٪ (زیرنویس) تا 100٪ (بالانویس)). برای مثال:

- ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation).
- دریافت مرجع یک اسلاید با استفاده از ایندکس آن.
- افزودن یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/AutoShape) از نوع [Rectangle](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeType#Rectangle) به اسلاید.
- دسترسی به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/TextFrame) مرتبط با [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/AutoShape).
- پاک‌سازی Paragraphهای موجود.
- ایجاد یک شی پاراگراف جدید برای نگهداری متن بالانویس و اضافه کردن آن به [Paragraphs collection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/TextFrame#getParagraphs--) از [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/TextFrame).
- ایجاد یک شی Portion جدید.
- تنظیم ویژگی Escapement برای Portion بین 0 تا 100 برای افزودن بالانویس. (0 به معنی عدم بالانویس)
- تعیین متنی برای [Portion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Portion) و سپس افزودن آن به مجموعه Portionهای پاراگراف.
- ایجاد یک شی پاراگراف جدید برای نگهداری متن زیرنویس و اضافه کردن آن به مجموعه IParagraphs از ITextFrame.
- ایجاد یک شی Portion جدید.
- تنظیم ویژگی Escapement برای Portion بین 0 تا -100 برای افزودن زیرنویس. (0 به معنی عدم زیرنویس)
- تعیین متنی برای [Portion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Portion) و سپس افزودن آن به مجموعه Portionهای پاراگراف.
- ذخیره ارائه به عنوان فایل PPTX.

پیاده‌سازی مراحل فوق در زیر ارائه شده است.

```javascript
// یک شی از کلاس Presentation که نمایانگر یک فایل PPTX است ایجاد کنید
var pres = new aspose.slides.Presentation();
try {
    // دریافت اسلاید
    var slide = pres.getSlides().get_Item(0);
    // ایجاد جعبه متن
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();
    // ایجاد پاراگراف برای متن بالانویس
    var superPar = new aspose.slides.Paragraph();
    // ایجاد بخش با متن معمولی
    var portion1 = new aspose.slides.Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);
    // ایجاد بخش با متن بالانویس
    var superPortion = new aspose.slides.Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);
    // ایجاد پاراگراف برای متن زیرنویس
    var paragraph2 = new aspose.slides.Paragraph();
    // ایجاد بخش با متن معمولی
    var portion2 = new aspose.slides.Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);
    // ایجاد بخش با متن زیرنویس
    var subPortion = new aspose.slides.Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);
    // افزودن پاراگراف‌ها به جعبه متن
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);
    pres.save("formatText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سئوالات متداول**

**آیا بالانویس و زیرنویس هنگام صادرات به PDF یا دیگر فرمت‌ها حفظ می‌شوند؟**

بله، Aspose.Slides به‌درستی قالب‌بندی بالانویس و زیرنویس را هنگام صادرات ارائه‌ها به PDF، PPT/PPTX، تصاویر و سایر فرمت‌های پشتیبانی‌شده حفظ می‌کند. این قالب‌بندی تخصصی در تمام فایل‌های خروجی دست‌نخورده می‌ماند.

**آیا می‌توان بالانویس و زیرنویس را با دیگر سبک‌های قالب‌بندی مانند بولد یا ایتالیک ترکیب کرد؟**

بله، Aspose.Slides به شما امکان می‌دهد سبک‌های مختلف متن را در یک Portion ترکیب کنید. می‌توانید بولد، ایتالیک، زیرخط را فعال کنید و همزمان بالانویس یا زیرنویس را با تنظیم ویژگی‌های مربوطه در [PortionFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portionformat/) اعمال کنید.

**آیا قالب‌بندی بالانویس و زیرنویس برای متن داخل جداول، نمودارها یا SmartArt کار می‌کند؟**

بله, Aspose.Slides قالب‌بندی را در اکثر اشیاء، از جمله جداول و عناصر نمودار پشتیبانی می‌کند. هنگام کار با SmartArt، باید به عناصر مناسب (مانند [SmartArtNode](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/smartartnode/)) و کانتینرهای متنی آن‌ها دسترسی پیدا کنید و سپس ویژگی‌های [PortionFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portionformat/) را به همان شیوه تنظیم نمایید.