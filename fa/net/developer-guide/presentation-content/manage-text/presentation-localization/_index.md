---
title: اتوماسیون بومی‌سازی ارائه در .NET
linktitle: بومی‌سازی ارائه
type: docs
weight: 100
url: /fa/net/presentation-localization/
keywords:
- تغییر زبان
- بررسی املایی
- شناسه زبان
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "اتوماسیون بومی‌سازی اسلایدهای PowerPoint و OpenDocument در .NET با Aspose.Slides، با استفاده از نمونه‌های کد عملی C# و نکات برای انتشار سریع‌تر جهانی."
---
## **مروری کلی**

این مقاله توضیح می‌دهد که چگونه با استفاده از Aspose.Slides مقدار `LanguageId` را برای متن در یک ارائه تنظیم کنید. همچنین نشان می‌دهد چگونه یک ارائه را باز کنید، شکلی با متن اضافه کنید، شناسه زبان را به یک بخش متن اختصاص دهید و نتیجه را به صورت فایل PPTX ذخیره نمایید.

## **تغییر زبان برای یک ارائه و متن شکل**
- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
- مرجع یک اسلاید را با استفاده از Index آن به‌دست آورید.
- یک AutoShape از نوع Rectangle را به اسلاید اضافه کنید.
- متن را به TextFrame اضافه کنید.
- تنظیم Language Id برای متن.
- ارائه را به‌صورت فایل PPTX ذخیره کنید.

پیاده‌سازی مراحل فوق در مثال زیر نشان داده شده است.

```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Text to apply spellcheck language");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **سوالات متداول**

**آیا Language ID ترجمه خودکار متن را فعال می‌کند؟**

خیر. [LanguageId](https://reference.aspose.com/slides/fa/net/aspose.slides/baseportionformat/languageid/) در Aspose.Slides زبان را برای بررسی املا و گرامر ذخیره می‌کند، اما متن را ترجمه یا تغییر نمی‌دهد. این یک فراداده است که PowerPoint برای بررسی می‌فهمد.

**آیا Language ID بر توربندی و شکست خطوط هنگام رندرینگ تأثیر می‌گذارد؟**

در Aspose.Slides، [LanguageId](https://reference.aspose.com/slides/fa/net/aspose.slides/baseportionformat/languageid/) برای بررسی استفاده می‌شود. کیفیت توربندی و پیچ‌کردن خطوط عمدتاً به در دسترس بودن [proper fonts](/slides/fa/net/powerpoint-fonts/) و تنظیمات چیدمان/شکست خط برای سیستم نوشتاری وابسته است. برای اطمینان از رندرینگ صحیح، فونت‌های مورد نیاز را در دسترس قرار دهید، [قوانین جایگزینی فونت](/slides/fa/net/font-substitution/) را پیکربندی کنید و/یا [فونت‌ها را جاسازی](/slides/fa/net/embedded-font/) کنید.

**آیا می‌توانم زبان‌های مختلف را در یک پاراگراف تنظیم کنم؟**

بله. [LanguageId](https://reference.aspose.com/slides/fa/net/aspose.slides/baseportionformat/languageid/) در سطح بخش متن اعمال می‌شود، بنابراین یک پاراگراف می‌تواند چندین زبان با تنظیمات بررسی متفاوت ترکیب کند.