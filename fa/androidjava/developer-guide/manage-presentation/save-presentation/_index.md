---
title: ذخیرهٔ ارائه‌ها در اندروید
linktitle: ذخیره ارائه
type: docs
weight: 80
url: /fa/androidjava/save-presentation/
keywords:
- ذخیره PowerPoint
- ذخیره OpenDocument
- ذخیره ارائه
- ذخیره اسلاید
- ذخیره PPT
- ذخیره PPTX
- ذخیره ODP
- ارائه به فایل
- ارائه به جریان
- نوع نمای پیش‌تعریف‌شده
- فرمت Strict Office Open XML
- حالت Zip64
- به‌روزرسانی تصویر بندانگشتی
- پیشرفت ذخیره‌سازی
- اندروید
- جاوا
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید ارائه‌ها را در جاوا با استفاده از Aspose.Slides برای اندروید ذخیره کنید—به‌صورت PowerPoint یا OpenDocument صادر کنید در حالی که چیدمان‌ها، قلم‌ها و افکت‌ها حفظ می‌شوند."
---
## **بررسی کلی**

[Open Presentations on Android](/slides/fa/androidjava/open-presentation/) توضیح می‌دهد چگونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) برای باز کردن یک ارائه استفاده کنید. این مقاله نحوه ایجاد و ذخیرهٔ ارائه‌ها را توضیح می‌دهد. کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) حاوی محتوای یک ارائه است. چه از ابتدا یک ارائه ایجاد کنید و چه یک ارائه موجود را ویرایش کنید، پس از اتمام باید آن را ذخیره کنید. با Aspose.Slides برای Android می‌توانید به **فایل** یا **جریان** ذخیره کنید. این مقاله روش‌های مختلف ذخیرهٔ یک ارائه را شرح می‌دهد.

## **ذخیرهٔ ارائه‌ها به فایل‌ها**

برای ذخیرهٔ یک ارائه به یک فایل، متد `save` کلاس [Presentation] را فراخوانی کنید. نام فایل و قالب ذخیره را به متد پاس دهید. مثال زیر نشان می‌دهد چگونه یک ارائه را با Aspose.Slides ذخیره کنید.

```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
Presentation presentation = new Presentation();
try {
    // در اینجا کاری انجام دهید...

    // ارائه را به یک فایل ذخیره کنید.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ذخیرهٔ ارائه‌ها به جریان‌ها**

می‌توانید یک ارائه را به یک جریان ذخیره کنید با پاس کردن یک خروجی جریان به متد `save` کلاس [Presentation]. یک ارائه می‌تواند به انواع مختلف جریان‌ها نوشته شود. در مثال زیر، یک ارائه جدید ایجاد می‌کنیم و آن را به یک جریان فایل ذخیره می‌کنیم.

```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // ارائه را به جریان ذخیره کنید.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **ذخیرهٔ ارائه‌ها با نوع نمای پیش‌تعریف‌شده**

Aspose.Slides به شما اجازه می‌دهد نمای اولیه‌ای که PowerPoint هنگام باز کردن ارائه‌ی تولید شده استفاده می‌کند را از طریق کلاس [ViewProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/viewproperties/) تنظیم کنید. از متد [setLastView](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) با مقدار از شمارنده [ViewType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/viewtype/) استفاده کنید.

```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ذخیرهٔ ارائه‌ها در فرمت Strict Office Open XML**

Aspose.Slides به شما اجازه می‌دهد یک ارائه را در فرمت Strict Office Open XML ذخیره کنید. از کلاس [PptxOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pptxoptions/) استفاده کنید و هنگام ذخیره‌سازی ویژگی conformance آن را تنظیم کنید. اگر [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict) را تنظیم کنید، فایل خروجی در فرمت Strict Office Open XML ذخیره می‌شود.

مثال زیر یک ارائه ایجاد می‌کند و آن را در فرمت Strict Office Open XML ذخیره می‌کند.

```java
PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
Presentation presentation = new Presentation();
try {
    // ارائه را در فرمت Strict Office Open XML ذخیره کنید.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **ذخیرهٔ ارائه‌ها در فرمت Office Open XML در حالت Zip64**

یک فایل Office Open XML یک آرشیو ZIP است که محدودیت ۴ گیگابایت (۲^۳۲ بایت) برای اندازهٔ فشرده‌نشدهٔ هر فایل، اندازهٔ فشردهٔ هر فایل و اندازهٔ کل آرشیو دارد و همچنین تعداد فایل‌ها را به ۶۵٬۵۳۵ (۲^۱۶‑۱) محدود می‌کند. افزونه‌های فرمت ZIP64 این محدودیت‌ها را به ۲^۶۴ ارتقاء می‌دهند.

متد [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) به شما امکان می‌دهد زمان استفاده از افزونه‌های فرمت ZIP64 را هنگام ذخیرهٔ یک فایل Office Open XML انتخاب کنید.

این متد می‌تواند با حالت‌های زیر استفاده شود:

- [IfNecessary](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/zip64mode/#IfNecessary) فقط در صورتی که ارائه محدودیت‌های فوق را تجاوز کند از افزونه‌های فرمت ZIP64 استفاده می‌کند. این حالت پیش‌فرض است.
- [Never](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/zip64mode/#Never) هرگز از افزونه‌های فرمت ZIP64 استفاده نمی‌کند.
- [Always](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/zip64mode/#Always) همیشه از افزونه‌های فرمت ZIP64 استفاده می‌کند.

کد زیر نشان می‌دهد چگونه یک ارائه را به عنوان PPTX با فعال کردن افزونه‌های فرمت ZIP64 ذخیره کنید:

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
هنگامی که با [Zip64Mode.Never](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/zip64mode/#Never) ذخیره می‌کنید، اگر ارائه نتواند در فرمت ZIP32 ذخیره شود، یک [PptxException](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pptxexception/) پرتاب می‌شود.
{{% /alert %}}

## **ذخیرهٔ ارائه‌ها بدون به‌روزرسانی تصویر بندانگشتی**

متد [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) کنترل ایجاد تصویر بندانگشتی هنگام ذخیرهٔ یک ارائه به PPTX را دارد:

- اگر به `true` تنظیم شود، تصویر بندانگشتی در طول ذخیره به‌روز می‌شود. این حالت پیش‌فرض است.
- اگر به `false` تنظیم شود، تصویر بندانگشتی جاری حفظ می‌شود. اگر ارائه تصویر بندانگشتی نداشته باشد، هیچ تصویری تولید نمی‌شود.

در کد زیر، ارائه بدون به‌روزرسانی تصویر بندانگشتی به PPTX ذخیره می‌شود.

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
این گزینه به کاهش زمان مورد نیاز برای ذخیرهٔ یک ارائه در فرمت PPTX کمک می‌کند.
{{% /alert %}}

## **ذخیره‌سازی به‌روزرسانی‌های پیشرفت به درصد**

رابط [IProgressCallback](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iprogresscallback/) از طریق متد `setProgressCallback` که توسط رابط [ISaveOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isaveoptions/) و کلاس انتزاعی [SaveOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/saveoptions/) ارائه می‌شود، استفاده می‌شود. با تخصیص یک پیاده‌سازی از [IProgressCallback](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iprogresscallback/) به `setProgressCallback` می‌توانید به‌روزرسانی‌های پیشرفت ذخیره‌سازی را به‌صورت درصد دریافت کنید.

قطعه کدهای زیر نشان می‌دهند چگونه از `IProgressCallback` استفاده کنید.

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
        // در اینجا از مقدار درصد پیشرفت استفاده کنید.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose یک برنامهٔ رایگان [PowerPoint Splitter](https://products.aspose.app/slides/fa/splitter) با استفاده از API خود توسعه داده است. این برنامه به شما امکان می‌دهد یک ارائه را به چندین فایل تقسیم کنید با ذخیرهٔ اسلایدهای انتخاب شده به عنوان فایل‌های جدید PPTX یا PPT.
{{% /alert %}}

## **سوالات متداول**

**آیا «ذخیره سریع» (ذخیره افزایشی) پشتیبانی می‌شود به‌گونه‌ای که فقط تغییرات نوشته شوند؟**

خیر. هر بار ذخیره‌سازی یک فایل کامل هدف را ایجاد می‌کند؛ «ذخیره سریع» افزایشی پشتیبانی نمی‌شود.

**آیا ذخیرهٔ همزمان یک شیء Presentation از چندین رشته ایمن است؟**

خیر. یک شیء [Presentation] [ایمن برای چندنخی نیست](/slides/fa/androidjava/multithreading/); آن را از یک رشته واحد ذخیره کنید.

**وقتی ذخیره می‌شود، چه اتفاقی برای پیوندهای ابرمتن و فایل‌های به‌صورت خارجی لینک‌شده می‌افتد؟**

[Hyperlinks](/slides/fa/androidjava/manage-hyperlinks/) حفظ می‌شوند. فایل‌های لینک‌شدهٔ خارجی (مثلاً ویدیوها با مسیرهای نسبی) به‌صورت خودکار کپی نمی‌شوند — اطمینان حاصل کنید مسیرهای ارجاع‌شده در دسترس باقی بمانند.

**آیا می‌توانم ویژگی‌های متادیتای سند (نویسنده، عنوان، شرکت، تاریخ) را تنظیم/ذخیره کنم؟**

بله. [ویژگی‌های سند](/slides/fa/androidjava/presentation-properties/) استاندارد پشتیبانی می‌شوند و هنگام ذخیره‌سازی به فایل نوشته می‌شوند.