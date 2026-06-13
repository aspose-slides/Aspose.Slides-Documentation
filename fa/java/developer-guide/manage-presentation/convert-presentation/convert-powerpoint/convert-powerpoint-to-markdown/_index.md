---
title: تبدیل ارائه‌های PowerPoint به Markdown در Java
linktitle: PowerPoint به Markdown
type: docs
weight: 140
url: /fa/java/convert-powerpoint-to-markdown/
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
- Java
- Aspose.Slides
description: "تبدیل اسلایدهای PowerPoint—PPT، PPTX—به Markdown تمیز با Aspose.Slides برای Java، خودکارسازی مستندات و حفظ قالب‌بندی."
---
## **مقدمه**

Aspose.Slides به شما امکان می‌دهد ارائه‌های PowerPoint را به Markdown تبدیل کنید، که می‌تواند برای جریان‌های کاری مستندسازی، تولید سایت‌های استاتیک، مهاجرت محتوا و انتشار متن تحت کنترل نسخه مفید باشد. API از خروجی مستقیم ارائه‌های PPT و PPTX به فایل‌های MD پشتیبانی می‌کند و گزینه‌های اضافی برای کنترل نحوه نمایش محتوای اسلایدها در سند Markdown تولید‌شده ارائه می‌دهد.

می‌توانید ارائه‌ها را به صورت Markdown ساده صادر کنید، از بین چندین نوع Markdown مانند CommonMark و GitHub Flavored Markdown انتخاب کنید و نحوه پردازش تصاویر را در طول خروجی تنظیم کنید. برای ارائه‌هایی که محتوای بصری دارند، Aspose.Slides همچنین به شما اجازه می‌دهد تصاویر را در پوشه‌ای جداگانه ذخیره کنید و از آن‌ها در فایل Markdown تولید شده ارجاع دهید.

{{% alert color="warning" %}}
صدور PowerPoint به markdown به‌طور پیش‌فرض **بدون تصاویر** است. اگر می‌خواهید سند PowerPoint حاوی تصاویر را صادر کنید، باید از `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` استفاده کنید و همچنین `setBasePath` را تعیین کنید که در آن تصاویر ارجاع‌شده در سند markdown ذخیره می‌شوند.
{{% /alert %}}

## **تبدیل PowerPoint به Markdown**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید تا یک شیء ارائه را نمایش دهد.
2. از متد [Save ](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) برای ذخیره‌سازی شیء به عنوان یک فایل markdown استفاده کنید.

این کد Java نشان می‌دهد چگونه PowerPoint را به markdown تبدیل کنید:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تبدیل PowerPoint به فرمت‌های Markdown**

Aspose.Slides به شما امکان می‌دهد PowerPoint را به markdown (حاوی سینتکس پایه)، CommonMark، GitHub flavored markdown، Trello، XWiki، GitLab و ۱۷ فرمت دیگر markdown تبدیل کنید.

این کد Java نشان می‌دهد چگونه PowerPoint را به CommonMark تبدیل کنید:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(Flavor.CommonMark);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

۲۳ فرمت پشتیبانی‌شده markdown در [Flavor enumeration](https://reference.aspose.com/slides/fa/java/com.aspose.slides/flavor/) از کلاس [MarkdownSaveOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/markdownsaveoptions/) فهرست شده‌اند.

## **تبدیل ارائه حاوی تصاویر به Markdown**

کلاس [MarkdownSaveOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/markdownsaveoptions/) ویژگی‌ها و enumerationهایی ارائه می‌دهد که به شما امکان استفاده از گزینه‌ها یا تنظیمات خاص برای فایل markdown حاصل را می‌دهد. به‌عنوان مثال، enum [MarkdownExportType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/markdownexporttype/) می‌تواند به مقادیری تنظیم شود که نحوه نمایش یا پردازش تصاویر را تعیین می‌کند: `Sequential`، `TextOnly`، `Visual`.

### **تبدیل تصاویر به‌صورت ترتیبی**

اگر می‌خواهید تصاویر به‌صورت تک‌تک و یکی پس از دیگری در markdown نهایی ظاهر شوند، باید گزینه sequential را انتخاب کنید. این کد Java نشان می‌دهد چگونه یک ارائه حاوی تصاویر را به markdown تبدیل کنید:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(Flavor.Github);
    markdownSaveOptions.setExportType(MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(NewLineType.Windows);
    pres.save("doc.md", new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **تبدیل تصاویر به‌صورت بصری**

اگر می‌خواهید تصاویر به‌صورت گروهی در markdown نهایی ظاهر شوند، باید گزینه visual را انتخاب کنید. در این حالت، تصاویر در دایرکتوری جاری برنامه ذخیره می‌شوند (و مسیر نسبی برای آن‌ها در سند markdown ساخته می‌شود)، یا می‌توانید مسیر و نام پوشه دلخواه خود را تعیین کنید.

این کد Java عملیات را نشان می‌دهد:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    final String outPath = "c:/documents";
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setExportType(MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سؤالات متداول**

**آیا هایپرلینک‌ها پس از صادرات به Markdown حفظ می‌شوند؟**

بله. متن [hyperlinks](/slides/fa/java/manage-hyperlinks/) به‌عنوان لینک‌های استاندارد Markdown حفظ می‌شود. اسلاید [transitions](/slides/fa/java/slide-transition/) و [animations](/slides/fa/java/powerpoint-animation/) تبدیل نمی‌شوند.

**آیا می‌توانم با اجرای تبدیل در چندین رشته (thread) سرعت را افزایش دهم؟**

می‌توانید پردازش را بین فایل‌ها موازی کنید، اما [don’t share](/slides/fa/java/multithreading/) همان نمونه [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) را بین رشته‌ها به اشتراک نگذارید. برای هر فایل از نمونه‌ها/فرایندهای جداگانه استفاده کنید تا از تداخل جلوگیری شود.

**چه اتفاقی برای تصاویر می‌افتد—کجا ذخیره می‌شوند و آیا مسیرها نسبی هستند؟**

[Images](/slides/fa/java/image/) به یک پوشه اختصاصی صادر می‌شوند و به‌طور پیش‌فرض فایل Markdown با مسیرهای نسبی به آن‌ها ارجاع می‌دهد. می‌توانید مسیر خروجی پایه و نام پوشه دارایی‌ها را تنظیم کنید تا ساختار مخزن قابل پیش‌بینی باشد.