---
title: ذخیره ارائه‌ها در اندروید
linktitle: ذخیره ارائه
type: docs
weight: 80
url: /fa/androidjava/save-presentation/
keywords:
- ذخیره پاورپوینت
- ذخیره OpenDocument
- ذخیره ارائه
- ذخیره اسلاید
- ذخیره PPT
- ذخیره PPTX
- ذخیره ODP
- ارائه به فایل
- ارائه به جریان
- نوع نمای پیش‌تعریف‌شده
- قالب Strict Office Open XML
- حالت Zip64
- تازه‌سازی تصویر کوچک
- پیشرفت ذخیره‌سازی
- Android
- Java
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید ارائه‌ها را در جاوا با استفاده از Aspose.Slides برای اندروید ذخیره کنید—به‌صورت PowerPoint یا OpenDocument صادر کنید در حالی که چینش‌ها، قلم‌ها و افکت‌ها را حفظ می‌کنید."
---
## **بررسی کلی**

[Open Presentations on Android](/slides/fa/androidjava/open-presentation/) نحوه استفاده از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) برای باز کردن یک ارائه را شرح داد. این مقاله چگونگی ایجاد و ذخیره ارائه‌ها را توضیح می‌دهد. کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) محتویات یک ارائه را شامل می‌شود. چه از ابتدا یک ارائه بسازید و چه یک ارائه موجود را اصلاح کنید، پس از اتمام می‌خواهید آن را ذخیره کنید. با Aspose.Slides برای Android می‌توانید به **فایل** یا **جریان** ذخیره کنید. این مقاله روش‌های مختلف ذخیره یک ارائه را توضیح می‌دهد.

## **ذخیره ارائه‌ها در فایل‌ها**

یک ارائه را با فراخوانی متد `save` کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) به یک فایل ذخیره کنید. نام فایل و فرمت ذخیره را به متد پاس دهید. مثال زیر نشان می‌دهد چگونه یک ارائه را با Aspose.Slides ذخیره کنید.

```java
import com.aspose.slides.*;

// یک شیء از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // برخی کارها را در اینجا انجام دهید...

    // ارائه را در یک فایل ذخیره کنید.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ذخیره ارائه‌ها در جریان‌ها**

می‌توانید یک ارائه را با عبور یک خروجی جریان به متد `save` کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ذخیره کنید. یک ارائه می‌تواند به انواع مختلف جریان‌ها نوشته شود. در مثال زیر، یک ارائه جدید ایجاد کرده و آن را در یک جریان فایل ذخیره می‌کنیم.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// یک شیء از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
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

## **ذخیره ارائه‌ها با نوع نمای پیش‌تعریف شده**

Aspose.Slides به شما امکان تنظیم نمای اولیه‌ای که PowerPoint هنگام باز کردن ارائه تولید شده استفاده می‌کند را از طریق کلاس [ViewProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/viewproperties/) می‌دهد. از متد [setLastView](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) با مقدار از شمارش‌گر [ViewType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/viewtype/) استفاده کنید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ذخیره ارائه‌ها در قالب Strict Office Open XML**

Aspose.Slides به شما امکان ذخیره یک ارائه در قالب Strict Office Open XML را می‌دهد. از کلاس [PptxOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pptxoptions/) استفاده کنید و ویژگی conformance آن را هنگام ذخیره تنظیم کنید. اگر [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict) را تنظیم کنید، فایل خروجی در قالب Strict Office Open XML ذخیره می‌شود.

مثال زیر یک ارائه ایجاد کرده و آن را در قالب Strict Office Open XML ذخیره می‌کند.

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// یک شیء از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // ارائه را در قالب Strict Office Open XML ذخیره کنید.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **ذخیره ارائه‌ها در قالب Office Open XML در حالت Zip64**

یک فایل Office Open XML یک آرشیو ZIP است که محدودیت ۴ GB (۲^۳۲ بایت) برای اندازهٔ غیر فشرده هر فایل، اندازهٔ فشرده هر فایل و اندازهٔ کل آرشیو دارد و همچنین آرشیو را به ۶۵ ۵۳۵ (۲^۱۶‑۱) فایل محدود می‌کند. افزونه‌های قالب ZIP64 این محدودیت‌ها را به ۲^۶۴ ارتقا می‌دهند.

متد [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) به شما اجازه می‌دهد هنگام ذخیرهٔ فایل Office Open XML چه زمانی از افزونه‌های قالب ZIP64 استفاده کنید.

این متد می‌تواند با حالت‌های زیر استفاده شود:

- [IfNecessary](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/zip64mode/#IfNecessary) فقط در صورتی که ارائه محدودیت‌های فوق را فرا بگیرد از افزونه‌های ZIP64 استفاده می‌کند. این حالت پیش‌فرض است.
- [Never](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/zip64mode/#Never) هرگز از افزونه‌های ZIP64 استفاده نمی‌کند.
- [Always](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/zip64mode/#Always) همیشه از افزونه‌های ZIP64 استفاده می‌کند.

کد زیر نشان می‌دهد چگونه یک ارائه را به صورت فایل PPTX با فعال‌سازی افزونه‌های قالب ZIP64 ذخیره کنید:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setZip64Mode(Zip64Mode.Always);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="توجه" color="warning" %}}

هنگامی که با [Zip64Mode.Never](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/zip64mode/#Never) ذخیره می‌کنید، اگر ارائه نتواند در قالب ZIP32 ذخیره شود، یک [PptxException](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pptxexception/) پرتاب می‌شود.

{{% /alert %}}

## **ذخیره ارائه‌ها در قالب Office Open XML با سطوح فشرده‌سازی**

هنگام کار با ارائه‌های بزرگ، می‌توانید سطح فشرده‌سازی را تنظیم کنید تا بین اندازهٔ فایل و زمان پردازش تعادل برقرار شود. بسته به نیازهای شما، ممکن است پردازش سریع‌تر یا فایل‌های خروجی کوچک‌تر را ترجیح دهید.

Aspose.Slides متد [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-) را فراهم می‌کند که به شما اجازه می‌دهد سطح فشرده‌سازی مورد استفاده هنگام ذخیرهٔ یک ارائه در قالب Office Open XML را مشخص کنید.

سطوح فشرده‌سازی موجود عبارت‌اند از:

- [**None**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compressionlevel/#None): هیچ فشرده‌سازی‌ای اعمال نمی‌شود. فایل‌ها به همان شکل ذخیره می‌شوند.
- [**Level1**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compressionlevel/#Level1): سریع‌ترین فشرده‌سازی با کم‌ترین نسبت فشرده‌سازی.
- [**Level2**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compressionlevel/#Level2): فشرده‌سازی سریع‌تر با نسبت کمی بهتر نسبت به **Level1**.
- [**Level3**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compressionlevel/#Level3): فشرده‌سازی بهتر نسبت به **Level2** با تاثیر متوسط بر زمان پردازش.
- [**Level4**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compressionlevel/#Level4): فشرده‌سازی بهتر نسبت به **Level3**.
- [**Level5**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compressionlevel/#Level5): بهبود فشرده‌سازی نسبت به **Level4** با زمان پردازش اضافی.
- [**Level6**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compressionlevel/#Level6): فشرده‌سازی استاندارد که تعادل خوبی بین سرعت پردازش و حجم فایل ارائه می‌دهد. این **سطح فشرده‌سازی پیش‌فرض** است.
- [**Level7**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compressionlevel/#Level7): فشرده‌سازی بهتر نسبت به **Level6** با پردازش آهسته‌تر.
- [**Level8**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compressionlevel/#Level8): فشرده‌سازی بهتر نسبت به **Level7**.
- [**Level9**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compressionlevel/#Level9): حداکثر فشرده‌سازی. کوچک‌ترین حجم فایل را با هزینهٔ طولانی‌ترین زمان پردازش تولید می‌کند.

مثال زیر نشان می‌دهد چگونه یک ارائه را به صورت فایل PPTX *بدون فشرده‌سازی* ذخیره کنید:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.None);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

این مثال چگونگی ذخیره یک ارائه به صورت فایل PPTX با *حداکثر فشرده‌سازی* را نشان می‌دهد:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.Level9);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **ذخیره ارائه‌ها بدون تازه‌سازی تصویر کوچک**

متد [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) کنترل می‌کند که هنگام ذخیرهٔ یک ارائه به PPTX تصویر کوچک ساخته شود یا نه:

- اگر `true` تنظیم شود، تصویر کوچک هنگام ذخیره تازه می‌شود. این حالت پیش‌فرض است.
- اگر `false` تنظیم شود، تصویر کوچک جاری محفوظ می‌ماند. اگر ارائه تصویر کوچکی نداشته باشد، هیچ‌کدام تولید نمی‌شود.

در کد زیر، ارائه بدون تازه‌سازی تصویر کوچک به PPTX ذخیره می‌شود.

```java
import com.aspose.slides.*;

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

{{% alert title="اطلاع" color="info" %}}

این گزینه به کاهش زمان لازم برای ذخیرهٔ یک ارائه در قالب PPTX کمک می‌کند.

{{% /alert %}}

## **ذخیره به‌روزرسانی‌های پیشرفت به درصد**

رابط [IProgressCallback](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iprogresscallback/) از طریق متد `setProgressCallback` که توسط رابط [ISaveOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isaveoptions/) و کلاس انتزاعی [SaveOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/saveoptions/) افشا می‌شود، استفاده می‌شود. یک پیاده‌سازی از [IProgressCallback](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iprogresscallback/) را با `setProgressCallback` انتساب دهید تا به‌روزرسانی‌های پیشرفت ذخیره به صورت درصد دریافت کنید.

کدهای زیر نشان می‌دهند چگونه از `IProgressCallback` استفاده کنید.

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // از مقدار درصد پیشرفت در اینجا استفاده کنید.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="اطلاع" color="info" %}}

Aspose یک برنامهٔ رایگان تقسیم‌کننده PowerPoint [Free PowerPoint Splitter app](https://products.aspose.app/slides/fa/splitter) با استفاده از API خود توسعه داده است. این برنامه به شما اجازه می‌دهد ارائه را به چندین فایل تقسیم کنید و اسلایدهای انتخاب شده را به صورت فایل‌های PPTX یا PPT جدید ذخیره کنید.

{{% /alert %}}

## **سؤال‌های متداول**

**آیا ذخیره سریع (ذخیره افزایشی) پشتیبانی می‌شود تا فقط تغییرات نوشته شوند؟**

خیر. هر بار ذخیره یک فایل هدف کامل ایجاد می‌کند؛ ذخیره سریع «افزایشی» پشتیبانی نمی‌شود.

**آیا ذخیرهٔ یک نمونهٔ Presentation از چندین نخ همزمان امن است؟**

خیر. یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) **امن برای چندنخی نیست**؛ آن را از یک نخ واحد ذخیره کنید.

**هنگام ذخیره چه می‌شود از هایپرلینک‌ها و فایل‌های لینک‌خورده به‌صورت خارجی؟**

[هایپرلینک‌ها](/slides/fa/androidjava/manage-hyperlinks/) حفظ می‌شوند. فایل‌های لینک‌خوردهٔ خارجی (مانند ویدیوها با مسیرهای نسبی) به‌صورت خودکار کپی نمی‌شوند—مطمئن شوید مسیرهای مرجع در دسترس باقی بمانند.

**آیا می‌توان متادیتاهای سند (نویسنده، عنوان، شرکت، تاریخ) را تنظیم/ذخیره کرد؟**

بله. ویژگی‌های استاندارد [document properties](/slides/fa/androidjava/presentation-properties/) پشتیبانی می‌شوند و هنگام ذخیره به فایل نوشته می‌شوند.