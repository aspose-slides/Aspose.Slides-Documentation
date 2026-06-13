---
title: تبدیل ارائه‌های PowerPoint به Markdown در Android
linktitle: PowerPoint به Markdown
type: docs
weight: 140
url: /fa/androidjava/convert-powerpoint-to-markdown/
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
- ذخیره PowerPoint به عنوان Markdown
- ذخیره ارائه به عنوان Markdown
- ذخیره اسلاید به عنوان Markdown
- ذخیره PPT به عنوان MD
- ذخیره PPTX به عنوان MD
- صادرات PPT به MD
- exportPPTX به MD
- PowerPoint
- ارائه
- Markdown
- Android
- Java
- Aspose.Slides
description: "اسلایدهای PowerPoint—PPT، PPTX—را به Markdown تمیز تبدیل کنید با Aspose.Slides برای Android از طریق Java، مستندسازی را خودکار کنید و قالب‌بندی را حفظ کنید."
---
## **مقدمه**

Aspose.Slides به شما امکان تبدیل ارائه‌های PowerPoint به Markdown را می‌دهد که می‌تواند برای جریان‌های کاری مستندسازی، تولید سایت‌های ایستا، مهاجرت محتوا و انتشار متن تحت کنترل نسخه مفید باشد. این API از خروجی مستقیم از ارائه‌های PPT و PPTX به فایل‌های MD پشتیبانی می‌کند و گزینه‌های اضافی برای کنترل نحوه نمایش محتوای اسلاید در سند Markdown تولید شده فراهم می‌کند.

می‌توانید ارائه‌ها را به صورت Markdown ساده صادر کنید، از بین چندین نوع Markdown مانند CommonMark و GitHub Flavored Markdown انتخاب کنید و نحوهٔ پردازش تصاویر در حین خروجی را پیکربندی کنید. برای ارائه‌هایی که شامل محتوای تصویری هستند، Aspose.Slides همچنین به شما اجازه می‌دهد تصاویر را در پوشه‌ای جداگانه ذخیره کرده و از آن‌ها در فایل Markdown تولید شده ارجاع دهید.

Aspose.Slides از تبدیل ارائه به markdown پشتیبانی می‌کند.

{{% alert color="warning" %}} 

صادر کردن PowerPoint به markdown به‌صورت پیش‌فرض **بدون تصاویر** است. اگر می‌خواهید سند PowerPoint شامل تصاویر را صادر کنید، باید `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` را تنظیم کنید و همچنین `BasePath` را مشخص کنید که تصاویر ارجاع‌شده در سند markdown در آن ذخیره شوند.

{{% /alert %}} 

## **تبدیل PowerPoint به Markdown**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید تا شیء ارائه را نمایندگی کند.
2. از متد [Save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) برای ذخیرهٔ شیء به عنوان فایل markdown استفاده کنید.

این کد Java نشان می‌دهد چگونه PowerPoint را به markdown تبدیل کنید:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تبدیل PowerPoint به نوع Markdown**

Aspose.Slides به شما امکان تبدیل PowerPoint به markdown (دارای سینتکس پایه)، CommonMark، GitHub flavored markdown، Trello، XWiki، GitLab و ۱۷ نوع دیگر markdown را می‌دهد.

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

۲۳ نوع markdown پشتیبانی‌شده در [لیست زیر در شمارش Flavor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/flavor/) از کلاس [MarkdownSaveOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/markdownsaveoptions/) آمده است.

## **تبدیل ارائه حاوی تصاویر به Markdown**

کلاس [MarkdownSaveOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/markdownsaveoptions/) ویژگی‌ها و شمارش‌هایی را فراهم می‌کند که به شما اجازه می‌دهد گزینه‌ها یا تنظیمات خاصی را برای فایل markdown خروجی اعمال کنید. برای مثال، شمارش [MarkdownExportType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/markdownexporttype/) می‌تواند به مقادیری تنظیم شود که تعیین می‌کند تصاویر چگونه رندر یا پردازش شوند: `Sequential`، `TextOnly`، `Visual`.

### **تبدیل تصاویر به‌صورت متوالی**

اگر می‌خواهید تصاویر به‌صورت جداگانه یکی پس از دیگری در markdown نهایی ظاهر شوند، باید گزینهٔ sequential را انتخاب کنید. این کد Java روش تبدیل ارائه حاوی تصاویر به markdown را نشان می‌دهد:

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

اگر می‌خواهید تصاویر به‌صورت جمع‑اجرا در markdown نهایی ظاهر شوند، باید گزینهٔ visual را انتخاب کنید. در این حالت، تصاویر در پوشهٔ جاری برنامه ذخیره می‌شوند (و مسیر نسبی برای آن‌ها در سند markdown ساخته می‌شود) یا می‌توانید مسیر و نام پوشهٔ دلخواه خود را مشخص کنید.

این کد Java این عملیات را نشان می‌دهد:

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

## **سوالات متداول**

**آیا پیوندهای متنی پس از صادرات به Markdown حفظ می‌شوند؟**

بله. متن [پیوندهای متنی](/slides/fa/androidjava/manage-hyperlinks/) به‌عنوان لینک‌های استاندارد Markdown حفظ می‌شود. اسلایدهای [انتقالات](/slides/fa/androidjava/slide-transition/) و [انیمیشن‌ها](/slides/fa/androidjava/powerpoint-animation/) تبدیل نمی‌شوند.

**آیا می‌توانم با اجرای همزمان در چندین نخ سرعت تبدیل را افزایش دهم؟**

می‌توانید پردازش را بین فایل‌ها موازی کنید، اما [به‌اشتراک‌گذاری‌نشود](/slides/fa/androidjava/multithreading/) همان نمونهٔ [ارائه](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) را بین نخ‌ها به اشتراک نگذارید. برای جلوگیری از تداخل، برای هر فایل از نمونه‌ها/فرآیندهای جداگانه استفاده کنید.

**تصاویر در چه مکانی ذخیره می‌شوند و آیا مسیرها نسبی هستند؟**

[تصاویر](/slides/fa/androidjava/image/) به یک پوشهٔ اختصاصی صادر می‌شوند و فایل Markdown به‌طور پیش‌فرض آن‌ها را با مسیرهای نسبی ارجاع می‌دهد. می‌توانید مسیر خروجی پایه و نام پوشهٔ دارایی‌ها را تنظیم کنید تا ساختار مخزن پیش‌بینی‌پذیر بماند.