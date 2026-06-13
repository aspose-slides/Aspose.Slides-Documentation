---
title: خودکارسازی بومی‌سازی ارائه در اندروید
linktitle: بومی‌سازی ارائه
type: docs
weight: 100
url: /fa/androidjava/presentation-localization/
keywords:
- تغییر زبان
- بررسی املا
- شناسه زبان
- پاورپوینت
- OpenDocument
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "بومی‌سازی اسلایدهای PowerPoint و OpenDocument را به صورت خودکار در جاوا با Aspose.Slides برای اندروید انجام دهید، با استفاده از نمونه‌های کد عملی و نکات برای انتشار سریع جهانی."
---
## **نمایش کلی**

این مقاله نحوه تنظیم `LanguageId` برای متن در یک ارائه را با استفاده از Aspose.Slides توضیح می‌دهد. این مقاله نشان می‌دهد چگونه یک ارائه را باز کنید، یک شکل با متن اضافه کنید، شناسه زبان را به یک بخش متن اختصاص دهید و نتیجه را به صورت فایل PPTX ذخیره کنید.

## **تغییر زبان برای متن ارائه و شکل**
- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
- مرجع یک اسلاید را با استفاده از شاخص آن به دست آورید.
- یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IAutoShape) از نوع [Rectangle](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ShapeType#Rectangle) را به اسلاید اضافه کنید.
- متنی به TextFrame اضافه کنید.
- [تنظیم شناسه زبان](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) را برای متن تنظیم کنید.
- ارائه را به صورت فایل PPTX ذخیره کنید.

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

## **سوالات متداول**

**آیا شناسه زبان ترجمه خودکار متن را فعال می‌کند؟**

خیر. [Language ID](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) در Aspose.Slides زبان را برای بررسی املا و دستور زبان ذخیره می‌کند، اما متن را ترجمه یا تغییر نمی‌دهد. این یک متادیتا است که PowerPoint برای بررسی می‌فهمد.

**آیا شناسه زبان بر فروریز (هایفن‌گذاری) و شکست خطوط هنگام رندرینگ تأثیر می‌گذارد؟**

در Aspose.Slides، [language ID](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) برای بررسی است. کیفیت هایفن‌گذاری و بسته‌بندی خطوط عمدتاً به در دسترس بودن [فونت‌های مناسب](/slides/fa/androidjava/powerpoint-fonts/) و تنظیمات چیدمان/شکست خطوط برای سیستم نوشتاری بستگی دارد. برای اطمینان از رندرینگ صحیح، فونت‌های مورد نیاز را در دسترس بگذارید، [قواعد جایگزینی فونت](/slides/fa/androidjava/font-substitution/) را پیکربندی کنید و/یا [فونت‌ها را جاسازی](/slides/fa/androidjava/embedded-font/) کنید.

**آیا می‌توانم زبان‌های متفاوت را در یک پاراگراف تنظیم کنم؟**

بله. [Language ID](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) در سطح بخش متن اعمال می‌شود، بنابراین یک پاراگراف می‌تواند چندین زبان با تنظیمات بررسی متفاوت ترکیب کند.