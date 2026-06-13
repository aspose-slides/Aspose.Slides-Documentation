---
title: خودکارسازی بومی‌سازی ارائه در جاوااسکریپت
linktitle: بومی‌سازی ارائه
type: docs
weight: 100
url: /fa/nodejs-java/presentation-localization/
keywords:
- تغییر زبان
- بررسی املایی
- شناسه زبان
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "خودکارسازی بومی‌سازی اسلایدهای PowerPoint و OpenDocument در جاوااسکریپت با Aspose.Slides، با استفاده از نمونه‌های کد عملی و نکات برای انتشار سریع‌تر جهانی."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه با استفاده از Aspose.Slides شناسه `LanguageId` را برای متن در یک ارائه تنظیم کنید. این مقاله نشان می‌دهد چگونه یک ارائه را باز کنید، یک شکل با متن اضافه کنید، شناسه زبان را به یک بخش متن اختصاص دهید و نتیجه را به صورت فایل PPTX ذخیره کنید.

## **تغییر زبان برای متن ارائه و شکل**

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
- با استفاده از Index آن، مرجع یک اسلاید را به‌دست آورید.
- یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/AutoShape) از نوع [Rectangle](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeType#Rectangle) به اسلاید اضافه کنید.
- متنی به TextFrame اضافه کنید.
- [تنظیم شناسه زبان](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/BasePortionFormat#setLanguageId-java.lang.String-) برای متن.
- ارائه را به عنوان فایل PPTX ذخیره کنید.

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");
    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سوالات متداول**

**آیا شناسه زبان ترجمه خودکار متن را فعال می‌کند؟**

خیر. [setLanguageId](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) در Aspose.Slides زبان را برای بررسی املایی و گرامری ذخیره می‌کند، اما متن را ترجمه یا تغییر نمی‌دهد. این یک متادیتا است که PowerPoint برای تصحیح می‌داند.

**آیا شناسه زبان بر تشخیص هجا و شکست خط هنگام رندر تأثیر می‌گذارد؟**

در Aspose.Slides، [setLanguageId](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) برای تصحیح است. کیفیت تشخیص هجا و شکست خط عمدتاً به دسترس بودن [فونت‌های مناسب](/slides/fa/nodejs-java/powerpoint-fonts/) و تنظیمات چیدمان/شکست خط برای سیستم نوشتاری وابسته است. برای اطمینان از رندر صحیح، فونت‌های مورد نیاز را در دسترس قرار دهید، [قوانین جایگزینی فونت](/slides/fa/nodejs-java/font-substitution/) را پیکربندی کنید و/یا [فونت‌ها را جاسازی](/slides/fa/nodejs-java/embedded-font/) کنید.

**آیا می‌توانم زبان‌های متفاوت را در یک پاراگراف واحد تنظیم کنم؟**

بله. [setLanguageId](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) در سطح بخش متن اعمال می‌شود، بنابراین یک پاراگراف می‌تواند ترکیبی از چند زبان با تنظیمات تصحیح متفاوت باشد.