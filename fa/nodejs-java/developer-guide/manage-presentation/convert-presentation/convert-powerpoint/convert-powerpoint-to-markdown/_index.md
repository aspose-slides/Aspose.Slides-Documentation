---
title: تبدیل ارائه‌های PowerPoint به Markdown در JavaScript
linktitle: PowerPoint به Markdown
type: docs
weight: 140
url: /fa/nodejs-java/convert-powerpoint-to-markdown/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به MD
- ارائه به MD
- اسلاید به MD
- PPT به MD
- PPTX به MD
- ذخیره PowerPoint به صورت Markdown
- ذخیره ارائه به صورت Markdown
- ذخیره اسلاید به صورت Markdown
- ذخیره PPT به صورت MD
- ذخیره PPTX به صورت MD
- صادرات PPT به MD
- صادرات PPTX به MD
- PowerPoint
- ارائه
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "تبدیل اسلایدهای PowerPoint در JavaScript—PPT، PPTX—به Markdown تمیز با Aspose.Slides برای Node.js از طریق Java، مستندسازی را خودکار کنید و قالب‌بندی را حفظ کنید."
---
## **مقدمه**

Aspose.Slides به شما امکان می‌دهد ارائه‌های PowerPoint را به Markdown تبدیل کنید، که می‌تواند برای جریان‌های کاری مستندسازی، تولید سایت‌های ثابت، مهاجرت محتوا و انتشار متنی تحت کنترل نسخه مفید باشد. این API از خروجی مستقیم ارائه‌های PPT و PPTX به فایل‌های MD پشتیبانی می‌کند و گزینه‌های اضافی برای کنترل نحوه نمایش محتوای اسلایدها در سند Markdown تولید شده فراهم می‌سازد.

می‌توانید ارائه‌ها را به صورت Markdown ساده خروجی بگیرید، از بین چندین نوع Markdown مانند CommonMark و GitHub Flavored Markdown انتخاب کنید و نحوهٔ پردازش تصاویر را هنگام خروجی تنظیم کنید. برای ارائه‌هایی که محتوای تصویری دارند، Aspose.Slides همچنین به شما اجازه می‌دهد تصاویر را در یک پوشه جداگانه ذخیره کرده و از فایل Markdown تولید شده به آنها ارجاع دهید.

{{% alert color="warning" %}} 
صدور PowerPoint به markdown به صورت پیش‌فرض **بدون تصاویر** است. اگر می‌خواهید سند PowerPoint شامل تصاویر را صادر کنید، باید `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` را فراخوانی کرده و همچنین `BasePath` را تنظیم کنید که تصاویر ارجاع شده در سند markdown در آن ذخیره شوند.
{{% /alert %}} 

## **تبدیل PowerPoint به مارک‌داون**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید تا نمایانگر شیء ارائه باشد.  
2. از متد [save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#save-aspose.slides.IXamlOptions-) برای ذخیرهٔ شیء به عنوان فایل markdown استفاده کنید.

این کد JavaScript نشان می‌دهد چگونه PowerPoint را به markdown تبدیل کنید:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.md", aspose.slides.SaveFormat.Md);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تبدیل PowerPoint به قالب مارک‌داون**

Aspose.Slides به شما امکان می‌دهد PowerPoint را به markdown (دارای نحو پایه)، CommonMark، GitHub flavored markdown، Trello، XWiki، GitLab و ۱۷ قالب دیگر مارک‌داون تبدیل کنید.

این کد JavaScript نشان می‌دهد چطور PowerPoint را به CommonMark تبدیل کنید:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.CommonMark);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

۲۳ قالب مارک‌داون پشتیبانی‌شده در [فهرست تحت شمارش Flavor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/flavor/) از کلاس [MarkdownSaveOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/markdownsaveoptions/) آمده‌اند.

## **تبدیل ارائه شامل تصاویر به مارک‌داون**

کلاس [MarkdownSaveOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/markdownsaveoptions/) ویژگی‌ها و شمارشی‌ها را فراهم می‌کند که امکان استفاده از گزینه‌ها یا تنظیمات خاص برای فایل markdown خروجی را می‌دهد. برای مثال، شمارشی [MarkdownExportType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/markdownexporttype/) می‌تواند به مقادیری تنظیم شود که تعیین می‌کنند تصاویر چگونه رندر یا پردازش شوند: `Sequential`، `TextOnly`، `Visual`.

### **تبدیل تصاویر به صورت پی‌درپی**

اگر می‌خواهید تصاویر به‌صورت تک‌تک یکی پس از دیگری در markdown نهایی ظاهر شوند، باید گزینهٔ sequential را انتخاب کنید. این کد JavaScript نشان می‌دهد چگونه ارائه‌ای شامل تصاویر را به markdown تبدیل کنید:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.Github);
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(aspose.slides.NewLineType.Windows);
    pres.save("doc.md", java.newArray("int", [1, 2, 3, 4, 5, 6, 7, 8, 9]), aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **تبدیل تصاویر به صورت بصری**

اگر می‌خواهید تصاویر به‌صورت گروهی در markdown نهایی ظاهر شوند، باید گزینهٔ visual را انتخاب کنید. در این حالت، تصاویر در پوشهٔ جاری برنامه ذخیره می‌شوند (و مسیر نسبی برای آنها در سند markdown ساخته می‌شود)، یا می‌توانید مسیر و نام پوشه دلخواه خود را مشخص کنید.

این کد JavaScript عملیات را نشان می‌دهد:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    final var outPath = "c:/documents";
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **پرسش‌های متداول**

**آیا لینک‌های فراخوانی در خروجی Markdown حفظ می‌شوند؟**

بله. متن [لینک‌های متنی](/slides/fa/nodejs-java/manage-hyperlinks/) به‌صورت لینک‌های استاندارد Markdown حفظ می‌شوند. [انتقالات](/slides/fa/nodejs-java/slide-transition/) و [انیمیشن‌ها](/slides/fa/nodejs-java/powerpoint-animation/) تبدیل نمی‌شوند.

**آیا می‌توانم با اجرای چندین رشته سرعت تبدیل را افزایش دهم؟**

می‌توانید پردازش را بین فایل‌ها موازی کنید، اما [به‌اشتراک‌گذاری نکنید](/slides/fa/nodejs-java/multithreading/) همان نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) را بین رشته‌ها. برای جلوگیری از تداخل، برای هر فایل از نمونه‌ها/فرآیندهای جداگانه استفاده کنید.

**چه اتفاقی برای تصاویر می‌افتد—کجا ذخیره می‌شوند و مسیرها آیا نسبی هستند؟**

[تصاویر](/slides/fa/nodejs-java/image/) به یک پوشهٔ اختصاصی صادر می‌شوند و فایل Markdown به‌صورت پیش‌فرض از مسیرهای نسبی برای آنها ارجاع می‌دهد. می‌توانید مسیر خروجی پایه و نام پوشهٔ دارایی را پیکربندی کنید تا ساختار مخزن پیش‌بینی‌پذیری داشته باشید.