---
title: "ذخیره ارائه‌ها در جاوا"
linktitle: "ذخیره ارائه"
type: docs
weight: 80
url: /fa/java/save-presentation/
keywords:
- "ذخیره پاورپوینت"
- "ذخیره OpenDocument"
- "ذخیره ارائه"
- "ذخیره اسلاید"
- "ذخیره PPT"
- "ذخیره PPTX"
- "ذخیره ODP"
- "ارائه به فایل"
- "ارائه به جریان"
- "نوع نمای پیش‌تعریف‌شده"
- "قالب Strict Office Open XML"
- "حالت Zip64"
- "تازه‌سازی تصویر بندانگشتی"
- "پیشرفت ذخیره‌سازی"
- "جاوا"
- "Aspose.Slides"
description: "کشف کنید چگونه در جاوا با استفاده از Aspose.Slides ارائه‌ها را ذخیره کنید—به PowerPoint یا OpenDocument صادر کنید در حالی که چیدمان‌ها، قلم‌ها و افکت‌ها حفظ می‌شوند."
---
## **بررسی کلی**

[Open Presentations in Java](/slides/fa/java/open-presentation/) نحوه استفاده از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) برای باز کردن یک ارائه را توضیح می‌دهد. این مقاله نحوه ایجاد و ذخیره ارائه‌ها را شرح می‌دهد. کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) محتوای یک ارائه را شامل می‌شود. چه از صفر یک ارائه ایجاد کنید و چه یک ارائه موجود را ویرایش کنید، پس از اتمام می‌خواهید آن را ذخیره کنید. با Aspose.Slides for Java، می‌توانید به یک **فایل** یا **جریان** ذخیره کنید. این مقاله روش‌های مختلف ذخیره یک ارائه را توضیح می‌دهد.

## **ذخیره ارائه‌ها در فایل‌ها**

یک ارائه را با صدا زدن متد `save` کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) در یک فایل ذخیره کنید. نام فایل و قالب ذخیره را به متد پاس دهید. مثال زیر نشان می‌دهد چگونه یک ارائه را با Aspose.Slides ذخیره کنید.

```java
// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است.
Presentation presentation = new Presentation();
try {
    // اینجا برخی کارها را انجام دهید...
    // ارائه را در یک فایل ذخیره کنید.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ذخیره ارائه‌ها در جریان‌ها**

می‌توانید یک ارائه را به یک جریان ذخیره کنید با پاس کردن یک خروجی استریم به متد `save` کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/). یک ارائه می‌تواند به انواع مختلف جریان‌ها نوشته شود. در مثال زیر، یک ارائه جدید ایجاد می‌کنیم و آن را در یک جریان فایل ذخیره می‌کنیم.

```java
// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است، ایجاد می‌کنید.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // ارائه را در جریان ذخیره کنید.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **ذخیره ارائه‌ها با نوع نمای از پیش تعریف شده**

Aspose.Slides به شما امکان می‌دهد نمای اولیه‌ای که PowerPoint هنگام باز شدن ارائه تولید شده استفاده می‌کند را از طریق کلاس [ViewProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/viewproperties/) تنظیم کنید. از متد [setLastView](https://reference.aspose.com/slides/fa/java/com.aspose.slides/viewproperties/#setLastView-int-) با یک مقدار از enumeration [ViewType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/viewtype/) استفاده کنید.

```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ذخیره ارائه‌ها در قالب Strict Office Open XML**

Aspose.Slides به شما امکان می‌دهد یک ارائه را در قالب Strict Office Open XML ذخیره کنید. هنگام ذخیره از کلاس [PptxOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pptxoptions/) استفاده کرده و ویژگی conformance آن را تنظیم کنید. اگر مقدار [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/fa/java/com.aspose.slides/conformance/#Iso29500-2008-Strict) را تنظیم کنید، فایل خروجی در قالب Strict Office Open XML ذخیره می‌شود.

مثال زیر یک ارائه ایجاد می‌کند و آن را در قالب Strict Office Open XML ذخیره می‌کند.

```java
PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است، ایجاد می‌کنید.
Presentation presentation = new Presentation();
try {
    // ارائه را در قالب Strict Office Open XML ذخیره کنید.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **ذخیره ارائه‌ها در قالب Office Open XML در حالت Zip64**

یک فایل Office Open XML یک آرشیو ZIP است که محدودیت ۴ گیگابایت (۲^۳۲ بایت) برای اندازه غیر فشرده هر فایل، اندازه فشرده هر فایل و کل حجم آرشیو اعمال می‌کند، و همچنین تعداد فایل‌های آرشیو را به ۶۵٬۵۳۵ (۲^۱۶‑۱) محدود می‌کند. افزونه‌های قالب ZIP64 این محدودیت‌ها را به ۲^۶۴ افزایش می‌دهند.

متد [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) به شما امکان می‌دهد زمان استفاده از افزونه‌های قالب ZIP64 هنگام ذخیره یک فایل Office Open XML را انتخاب کنید.

این متد می‌تواند با حالت‌های زیر استفاده شود:

- [IfNecessary](https://reference.aspose.com/slides/fa/java/com.aspose.slides/zip64mode/#IfNecessary) فقط در صورتی که ارائه از محدودیت‌های بالا تجاوز کند از افزونه‌های قالب ZIP64 استفاده می‌کند. این حالت پیش‌فرض است.
- [Never](https://reference.aspose.com/slides/fa/java/com.aspose.slides/zip64mode/#Never) هرگز از افزونه‌های قالب ZIP64 استفاده نمی‌کند.
- [Always](https://reference.aspose.com/slides/fa/java/com.aspose.slides/zip64mode/#Always) همیشه از افزونه‌های قالب ZIP64 استفاده می‌کند.

کد زیر نشان می‌دهد چگونه یک ارائه را به صورت PPTX با افزونه‌های قالب ZIP64 فعال ذخیره کنید:

```java
PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setZip64Mode(Zip64Mode.Always);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
هنگامی که با [Zip64Mode.Never](https://reference.aspose.com/slides/fa/java/com.aspose.slides/zip64mode/#Never) ذخیره می‌کنید، اگر امکان ذخیره ارائه در قالب ZIP32 وجود نداشته باشد، یک [PptxException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pptxexception/) صادر می‌شود.
{{% /alert %}}

## **ذخیره ارائه‌ها بدون تازه‌سازی تصویر بندانگشتی**

متد [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) نحوه تولید تصویر بندانگشتی هنگام ذخیره یک ارائه به PPTX را کنترل می‌کند:

- اگر به `true` تنظیم شود، تصویر بندانگشتی در حین ذخیره تازه‌سازی می‌شود. این مقدار پیش‌فرض است.
- اگر به `false` تنظیم شود، تصویر بندانگشتی فعلی حفظ می‌شود. اگر ارائه تصویر بندانگشتی نداشته باشد، هیچ تصویر جدیدی تولید نمی‌شود.

در کد زیر، ارائه بدون تازه‌سازی تصویر بندانگشتی خود به PPTX ذخیره می‌شود.

```java
PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setRefreshThumbnail(false);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
این گزینه به کاهش زمان مورد نیاز برای ذخیره یک ارائه در قالب PPTX کمک می‌کند.
{{% /alert %}}

## **دریافت به‌روزرسانی پیشرفت ذخیره به درصد**

رابطه [IProgressCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iprogresscallback/) از طریق متد `setProgressCallback` که توسط رابط [ISaveOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isaveoptions/) و کلاس انتزاعی [SaveOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/saveoptions/) ارائه می‌شود استفاده می‌شود. یک پیاده‌سازی از [IProgressCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iprogresscallback/) را با `setProgressCallback` اختصاص دهید تا به‌روزرسانی‌های پیشرفت ذخیره را به صورت درصد دریافت کنید.

کدهای زیر نشان می‌دهند چگونه از `IProgressCallback` استفاده کنید.

```java
ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```
```java
class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // از مقدار درصد پیشرفت در اینجا استفاده کنید.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose یک برنامه [رایگان تقسیم‌کننده PowerPoint](https://products.aspose.app/slides/fa/splitter) با استفاده از API خود توسعه داده است. این برنامه به شما امکان می‌دهد یک ارائه را به چندین فایل تقسیم کنید با ذخیره اسلایدهای انتخاب‌شده به عنوان فایل‌های جدید PPTX یا PPT.
{{% /alert %}}

## پرسش‌های متداول

**آیا ذخیره سریع (ذخیره افزایشی) پشتیبانی می‌شود تا فقط تغییرات نوشته شوند؟**

خیر. هر بار ذخیره‌سازی فایل هدف کامل را ایجاد می‌کند؛ ذخیره سریع (افزایشی) پشتیبانی نمی‌شود.

**آیا ذخیره‌سازی نمونه Presentation از چند رشته همزمان ایمن است؟**

خیر. یک نمونه [Presentation](/slides/fa/java/multithreading/) [thread‑safe نیست]؛ آن را فقط از یک رشته ذخیره کنید.

**هنگام ذخیره چه بر سر هایپرلینک‌ها و فایل‌های لینک‌شده خارجی می‌آید؟**

[هایپرلینک‌ها](/slides/fa/java/manage-hyperlinks/) حفظ می‌شوند. فایل‌های لینک‌شده خارجی (مانند ویدیوها با مسیرهای نسبی) به‌صورت خودکار کپی نمی‌شوند—اطمینان حاصل کنید مسیرهای مرجع در دسترس باقی بمانند.

**آیا می‌توانم متادیتاهای سند (نویسنده، عنوان، شرکت، تاریخ) را تنظیم/ذیره کنم؟**

بله. [خصوصیات استاندارد سند](/slides/fa/java/presentation-properties/) پشتیبانی می‌شوند و هنگام ذخیره در فایل نوشته می‌شوند.