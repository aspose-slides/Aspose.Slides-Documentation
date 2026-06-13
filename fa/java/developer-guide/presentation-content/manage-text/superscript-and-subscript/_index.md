---
title: مدیریت فوق‌نویس و زیرنویس در ارائه‌ها با استفاده از جاوا
linktitle: فوق‌نویس و زیرنویس
type: docs
weight: 80
url: /fa/java/superscript-and-subscript/
keywords:
- فوق‌نویس
- زیرنویس
- افزودن فوق‌نویس
- افزودن زیرنویس
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "فوق‌نویس و زیرنویس را در Aspose.Slides برای جاوا به‌صورت حرفه‌ای مسلط کنید و با قالب‌بندی متن حرفه‌ای، ارائه‌های خود را برای حداکثر تأثیر ارتقا دهید."
---
## **مرور کلی**

Aspose.Slides ویژگی‌هایی برای ادغام متن فوق‌نویس و زیرنویس در ارائه‌های PowerPoint (PPT، PPTX) و OpenDocument (ODP) شما فراهم می‌کند. اگر نیاز به برجسته‌سازی فرمول‌های شیمیایی، معادلات ریاضی یا افزودن حاشیه‌نویس به محتوا دارید، این گزینه‌های قالب‌بندی ویژه به حفظ وضوح و دقت کمک می‌کند. در این مقاله، خواهید آموخت که چگونه به‌صورت یکپارچه سبک‌های فوق‌نویس و زیرنویس را اعمال کنید و در هر اسلاید نتایج حرفه‌ای به دست آورید.

## **مدیریت متن فوق‌نویس و زیرنویس**
می‌توانید متن فوق‌نویس و زیرنویس را در هر بخش پاراگراف اضافه کنید. برای افزودن متن فوق‌نویس یا زیرنویس در فریم متنی Aspose.Slides باید از متد [**setEscapement**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IBasePortionFormat#setEscapement-float-) کلاس [PortionFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/PortionFormat) استفاده کنید.

این ویژگی مقدار متن فوق‌نویس یا زیرنویس را برمی‌گرداند یا تنظیم می‌کند (مقدار از -100٪ (زیرنویس) تا 100٪ (فوق‌نویس)). به عنوان مثال:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
- با استفاده از شاخص آن، مرجع یک اسلاید را به دست آورید.
- یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IAutoShape) از نوع [Rectangle](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ShapeType#Rectangle) به اسلاید اضافه کنید.
- به [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITextFrame) مرتبط با [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IAutoShape) دسترسی پیدا کنید.
- پاراگراف‌های موجود را پاک کنید.
- یک شی پاراگراف جدید برای نگهداری متن فوق‌نویس ایجاد کنید و آن را به مجموعه [IParagraphs](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITextFrame#getParagraphs--) از [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITextFrame) اضافه کنید.
- یک شی Portion جدید ایجاد کنید.
- مقدار ویژگی Escapement را برای Portion بین 0 تا 100 تنظیم کنید تا فوق‌نویس اضافه شود. (0 یعنی بدون فوق‌نویس)
- متنی برای [Portion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Portion) تنظیم کنید و سپس آن را به مجموعه Portionهای پاراگراف اضافه کنید.
- یک شی پاراگراف جدید برای نگهداری متن زیرنویس ایجاد کنید و آن را به مجموعه IParagraphs از ITextFrame اضافه کنید.
- یک شی Portion جدید ایجاد کنید.
- مقدار ویژگی Escapement را برای Portion بین 0 تا -100 تنظیم کنید تا زیرنویس اضافه شود. (0 یعنی بدون زیرنویس)
- متنی برای [Portion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Portion) تنظیم کنید و سپس آن را به مجموعه Portionهای پاراگراف اضافه کنید.
- ارائه را به عنوان فایل PPTX ذخیره کنید.

پیاده‌سازی مراحل فوق در زیر ارائه شده است.

```java
// یک شیء از کلاس Presentation که نمایانگر یک PPTX است، ایجاد کنید
Presentation pres = new Presentation();
try {
    // اسلاید را دریافت کنید
    ISlide slide = pres.getSlides().get_Item(0);

    // جعبه متن را ایجاد کنید
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // پاراگراف برای متن فوق‌نویس ایجاد کنید
    IParagraph superPar = new Paragraph();

    // بخش با متن معمولی ایجاد کنید
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // بخش با متن فوق‌نویس ایجاد کنید
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // پاراگراف برای متن زیرنویس ایجاد کنید
    IParagraph paragraph2 = new Paragraph();

    // بخش با متن معمولی ایجاد کنید
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // بخش با متن زیرنویس ایجاد کنید
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // پاراگراف‌ها را به جعبه متن اضافه کنید
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سؤال‌های متداول**

**آیا فوق‌نویس و زیرنویس هنگام استخراج به PDF یا فرمت‌های دیگر حفظ می‌شوند؟**

بله، Aspose.Slides قالب‌بندی فوق‌نویس و زیرنویس را به‌درستی هنگام استخراج ارائه‌ها به PDF، PPT/PPTX، تصاویر و سایر فرمت‌های پشتیبانی شده حفظ می‌کند. این قالب‌بندی ویژه در تمام فایل‌های خروجی دست‌نخورده باقی می‌ماند.

**آیا می‌توان فوق‌نویس و زیرنویس را همراه با استایل‌های دیگر مانند بولد یا ایتالیک ترکیب کرد؟**

بله، Aspose.Slides به شما امکان می‌دهد سبک‌های مختلف متن را در یک Portion ترکیب کنید. می‌توانید بولد، ایتالیک، زیرخط و همزمان فوق‌نویس یا زیرنویس را با تنظیم ویژگی‌های مربوطه در [PortionFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/portionformat/) فعال کنید.

**آیا قالب‌بندی فوق‌نویس و زیرنویس برای متن داخل جدول‌ها، نمودارها یا SmartArt کار می‌کند؟**

بله، Aspose.Slides قالب‌بندی را در بیشتر اشیاء، از جمله جدول‌ها و عناصر نمودار، پشتیبانی می‌کند. هنگام کار با SmartArt، باید به عناصر مناسب (مانند [SmartArtNode](https://reference.aspose.com/slides/fa/java/com.aspose.slides/smartartnode/)) و کانتینرهای متن آن‌ها دسترسی پیدا کنید و سپس ویژگی‌های [PortionFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/portionformat/) را به‌صورت مشابه تنظیم کنید.