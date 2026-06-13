---
title: مدیریت بالانویس و زیرنویس در ارائه‌ها روی Android
linktitle: بالانویس و زیرنویس
type: docs
weight: 80
url: /fa/androidjava/superscript-and-subscript/
keywords:
- بالانویس
- زیرنویس
- افزودن بالانویس
- افزودن زیرنویس
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "بالانویس و زیرنویس را در Aspose.Slides برای Android با استفاده از Java مسلط شوید و ارائه‌های خود را با قالب‌بندی متن حرفه‌ای برای حداکثر تاثیر ارتقا دهید."
---
## **بررسی کلی**

Aspose.Slides ویژگی‌هایی برای ادغام متن بالانویس و زیرنویس در ارائه‌های PowerPoint (PPT، PPTX) و OpenDocument (ODP) شما فراهم می‌کند. چه نیاز به برجسته‌سازی فرمول‌های شیمیایی، معادلات ریاضی یا افزودن یادداشت‌های پاورقی داشته باشید، این گزینه‌های قالب‌بندی تخصصی به حفظ وضوح و دقت کمک می‌کنند. در این مقاله، نحوه اعمال بدون مشکل سبک‌های بالانویس و زیرنویس و تضمین نتایج حرفه‌ای در هر اسلاید را خواهید آموخت.

## **مدیریت متن بالانویس و زیرنویس**
می‌توانید متن بالانویس و زیرنویس را داخل هر بخش از پاراگراف اضافه کنید. برای افزودن متن بالانویس یا زیرنویس در فریم متن Aspose.Slides باید از روش [**setEscapement**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IBasePortionFormat#setEscapement-float-) کلاس [PortionFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/PortionFormat) استفاده کنید.

این ویژگی مقدار بالانویس یا زیرنویس را بر می‌گرداند یا تنظیم می‌کند (مقدار از -100٪ (زیرنویس) تا 100٪ (بالانویس)). برای مثال:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
- با استفاده از شاخص آن، مرجع یک اسلاید را دریافت کنید.
- یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IAutoShape) از نوع [Rectangle](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ShapeType#Rectangle) را به اسلاید اضافه کنید.
- به [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITextFrame) مرتبط با [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IAutoShape) دسترسی پیدا کنید.
- پاراگراف‌های موجود را پاک کنید
- یک شیء پاراگراف جدید برای نگهداری متن بالانویس ایجاد کنید و آن را به مجموعه [IParagraphs collection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITextFrame#getParagraphs--) از [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITextFrame) اضافه کنید.
- یک شیء Portion جدید ایجاد کنید
- مقدار ویژگی Escapement را برای Portion بین 0 تا 100 تنظیم کنید تا بالانویس اضافه شود. (0 به معنای عدم بالانویس است)
- متنی برای [Portion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Portion) تنظیم کنید و سپس آن را به مجموعه Portionهای پاراگراف اضافه کنید.
- یک شیء پاراگراف جدید برای نگهداری متن زیرنویس ایجاد کنید و آن را به مجموعه IParagraphs از ITextFrame اضافه کنید.
- یک شیء Portion جدید ایجاد کنید
- مقدار ویژگی Escapement را برای Portion بین 0 تا -100 تنظیم کنید تا زیرنویس اضافه شود. (0 به معنای عدم زیرنویس است)
- متنی برای [Portion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Portion) تنظیم کنید و سپس آن را به مجموعه Portionهای پاراگراف اضافه کنید.
- ارائه را به صورت فایل PPTX ذخیره کنید.

```java
// یک نمونه از کلاس Presentation که نمایانگر یک فایل PPTX است
Presentation pres = new Presentation();
try {
    // اسلاید را دریافت کنید
    ISlide slide = pres.getSlides().get_Item(0);

    // ایجاد جعبه متن
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // ایجاد پاراگراف برای متن بالانویس
    IParagraph superPar = new Paragraph();

    // ایجاد بخش با متن معمولی
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // ایجاد بخش با متن بالانویس
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // ایجاد پاراگراف برای متن زیرنویس
    IParagraph paragraph2 = new Paragraph();

    // ایجاد بخش با متن معمولی
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // ایجاد بخش با متن زیرنویس
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // اضافه کردن پاراگراف‌ها به جعبه متن
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

**آیا هنگام خروجی گرفتن به PDF یا سایر فرمت‌ها بالانویس و زیرنویس حفظ می‌شوند؟**

بله، Aspose.Slides قالب‌بندی بالانویس و زیرنویس را به درستی هنگام خروجی گرفتن ارائه‌ها به PDF، PPT/PPTX، تصاویر و سایر فرمت‌های پشتیبانی شده حفظ می‌کند. این قالب‌بندی تخصصی در تمام فایل‌های خروجی دست نخورده می‌ماند.

**آیا می‌توان بالانویس و زیرنویس را با سایر سبک‌های قالب‌بندی مانند ضخیم یا ایتالیک ترکیب کرد؟**

بله، Aspose.Slides به شما امکان می‌دهد که سبک‌های متنی مختلف را در یک Portion ترکیب کنید. می‌توانید ضخیم، ایتالیک، زیرخط را فعال کنید و به‌طور همزمان بالانویس یا زیرنویس را با تنظیم ویژگی‌های مربوطه در [PortionFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/portionformat/) اعمال کنید.

**آیا قالب‌بندی بالانویس و زیرنویس برای متنی داخل جدول‌ها، نمودارها یا SmartArt کار می‌کند؟**

بله، Aspose.Slides قالب‌بندی را در اکثر اشیاء، از جمله جدول‌ها و عناصر نمودار پشتیبانی می‌کند. هنگام کار با SmartArt، باید به عناصر مناسب (مانند [SmartArtNode](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/smartartnode/)) و محفظه‌های متنی آن‌ها دسترسی پیدا کنید و سپس ویژگی‌های [PortionFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/portionformat/) را به‌صورت مشابه تنظیم کنید.