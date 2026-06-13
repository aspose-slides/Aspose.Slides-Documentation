---
title: "اتوماتیک‌سازی بومی‌سازی ارائه در جاوا"
linktitle: "بومی‌سازی ارائه"
type: docs
weight: 100
url: /fa/java/presentation-localization/
keywords:
  - "تغییر زبان"
  - "بررسی املایی"
  - "شناسه زبان"
  - "PowerPoint"
  - "OpenDocument"
  - "ارائه"
  - "Java"
  - "Aspose.Slides"
description: "اتوماتیک‌سازی بومی‌سازی اسلایدهای PowerPoint و OpenDocument در جاوا با Aspose.Slides، با استفاده از نمونه‌های کد عملی و نکات برای اجرای سریع‌تر جهانی."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه با استفاده از Aspose.Slides شناسه `LanguageId` را برای متن در یک ارائه تنظیم کنید. این مقاله نشان می‌دهد چگونه یک ارائه را باز کنید، یک شکل با متن اضافه کنید، یک شناسه زبان را به یک بخش متن اختصاص دهید و نتیجه را به صورت فایل PPTX ذخیره کنید.

## **تغییر زبان برای یک ارائه و متن شکل**
- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) را ایجاد کنید.
- با استفاده از ایندکس، مرجع یک اسلاید را دریافت کنید.
- یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IAutoShape) از نوع [Rectangle](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ShapeType#Rectangle) را به اسلاید اضافه کنید.
- متنی به TextFrame اضافه کنید.
- برای متن، [Setting Language Id](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) را تنظیم کنید.
- ارائه را به صورت فایل PPTX ذخیره کنید.

پیاده‌سازی مراحل فوق در مثال زیر نمایش داده شده است.

```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **پرسش‌های متداول**

**آیا شناسه زبان باعث ترجمه خودکار متن می‌شود؟**

خیر. [Language ID](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) در Aspose.Slides زبان را برای بررسی املا و گرامر ذخیره می‌کند، اما متن را ترجمه یا تغییر نمی‌دهد. این یک فراداده است که PowerPoint برای تصحیح می‌فهمد.

**آیا شناسه زبان بر تقسیم واژگان و شکست خطوط هنگام رندر تأثیر دارد؟**

در Aspose.Slides، [language ID](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) برای تصحیح است. کیفیت هیفنیشن و شکست خطوط عمدتاً به در دسترس بودن [proper fonts](/slides/fa/java/powerpoint-fonts/) و تنظیمات چیدمان/شکست خطوط برای سیستم نوشتاری بستگی دارد. برای اطمینان از رندر صحیح، فونت‌های مورد نیاز را در دسترس قرار دهید، [قواعد جایگزینی فونت](/slides/fa/java/font-substitution/) را پیکربندی کنید، و/یا [فونت‌ها را تعبیه](/slides/fa/java/embedded-font/) کنید.

**آیا می‌توانم زبان‌های مختلف را در یک پاراگراف واحد تنظیم کنم؟**

بله. [Language ID](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) در سطح بخش متن اعمال می‌شود، بنابراین یک پاراگراف می‌تواند چند زبان مختلف با تنظیمات تصحیح متفاوت داشته باشد.