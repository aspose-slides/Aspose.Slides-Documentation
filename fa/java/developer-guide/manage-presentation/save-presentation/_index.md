---
title: ذخیره ارائه‌ها در جاوا
linktitle: ذخیره ارائه
type: docs
weight: 80
url: /fa/java/save-presentation/
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
- به‌روزرسانی تصویر کوچک
- پیشرفت ذخیره‌سازی
- جاوا
- Aspose.Slides
description: "کشف کنید چگونه در جاوا با استفاده از Aspose.Slides ارائه‌ها را ذخیره کنید—صادرات به پاورپوینت یا OpenDocument هنگام حفظ طرح‌بندی‌ها، فونت‌ها و افکت‌ها."
---
## **بررسی کلی**

[Open Presentations in Java](/slides/fa/java/open-presentation/) توضیح می‌دهد که چگونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) برای باز کردن یک ارائه استفاده کنید. این مقاله نحوه ایجاد و ذخیره ارائه‌ها را بیان می‌کند. کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) شامل محتویات یک ارائه است. چه از صفر یک ارائه ایجاد کنید و چه یک ارائه موجود را تغییر دهید، پس از پایان کار باید آن را ذخیره کنید. با Aspose.Slides برای Java می‌توانید به یک **فایل** یا **جریان** ذخیره کنید. این مقاله روش‌های مختلف ذخیره یک ارائه را توضیح می‌دهد.

## **ذخیره ارائه‌ها در فایل‌ها**

یک ارائه را با فراخوانی متد `save` کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) به یک فایل ذخیره کنید. نام فایل و قالب ذخیره را به این متد پاس دهید. مثال زیر نشان می‌دهد که چگونه یک ارائه را با Aspose.Slides ذخیره کنید.

```java
import com.aspose.slides.*;

// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است.
Presentation presentation = new Presentation();
try {
    // انجام برخی کارها در اینجا...

    // ارائه را در یک فایل ذخیره می‌کند.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ذخیره ارائه‌ها در جریان‌ها**

می‌توانید یک ارائه را به یک جریان ذخیره کنید با پاس کردن یک خروجی جریان به متد `save` کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/). یک ارائه می‌تواند به انواع مختلف جریان‌ها نوشته شود. در مثال زیر، یک ارائه جدید ایجاد می‌کنیم و آن را به یک جریان فایل ذخیره می‌کنیم.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // ارائه را در جریان ذخیره می‌کند.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **ذخیره ارائه‌ها با نوع نمای پیش‌فرض**

Aspose.Slides به شما امکان می‌دهد نمای اولیه‌ای را که PowerPoint هنگام باز شدن ارائه تولید شده استفاده می‌کند، از طریق کلاس [ViewProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/viewproperties/) تنظیم کنید. از متد [setLastView](https://reference.aspose.com/slides/fa/java/com.aspose.slides/viewproperties/#setLastView-int-) همراه با مقداری از شمارش [ViewType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/viewtype/) استفاده کنید.

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

Aspose.Slides به شما امکان می‌دهد یک ارائه را در قالب Strict Office Open XML ذخیره کنید. هنگام ذخیره از کلاس [PptxOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pptxoptions/) استفاده کنید و ویژگی conformance آن را تنظیم کنید. اگر [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/fa/java/com.aspose.slides/conformance/#Iso29500-2008-Strict) را تنظیم کنید، فایل خروجی در قالب Strict Office Open XML ذخیره می‌شود.

مثال زیر یک ارائه ایجاد می‌کند و آن را در قالب Strict Office Open XML ذخیره می‌نماید.

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است.
Presentation presentation = new Presentation();
try {
    // ارائه را در قالب Strict Office Open XML ذخیره می‌کند.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **ذخیره ارائه‌ها در قالب Office Open XML در حالت Zip64**

یک فایل Office Open XML یک آرشیو ZIP است که محدودیت 4 GB (2^32 بایت) برای اندازهٔ غیر فشرده، اندازهٔ فشرده و کل آرشیو اعمال می‌کند و همچنین تعداد فایل‌ها را به 65 535 (2^16‑1) محدود می‌سازد. افزونه‌های قالب ZIP64 این محدودیت‌ها را به 2^64 افزایش می‌دهند.

متد [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) به شما امکان می‌دهد هنگام ذخیرهٔ یک فایل Office Open XML، زمان استفاده از افزونه‌های قالب ZIP64 را انتخاب کنید.

این متد می‌تواند با حالت‌های زیر استفاده شود:
- [IfNecessary](https://reference.aspose.com/slides/fa/java/com.aspose.slides/zip64mode/#IfNecessary) فقط در صورتی که ارائه محدودیت‌های فوق را تجاوز کند از افزونه‌های قالب ZIP64 استفاده می‌کند. این حالت پیش‌فرض است.
- [Never](https://reference.aspose.com/slides/fa/java/com.aspose.slides/zip64mode/#Never) هرگز از افزونه‌های قالب ZIP64 استفاده نمی‌کند.
- [Always](https://reference.aspose.com/slides/fa/java/com.aspose.slides/zip64mode/#Always) همیشه از افزونه‌های قالب ZIP64 استفاده می‌کند.

کد زیر نشان می‌دهد چگونه یک ارائه را به عنوان فایل PPTX با فعال‌سازی افزونه‌های قالب ZIP64 ذخیره کنید:

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

{{% alert title="NOTE" color="warning" %}}
زمانی که با [Zip64Mode.Never](https://reference.aspose.com/slides/fa/java/com.aspose.slides/zip64mode/#Never) ذخیره می‌کنید، اگر ارائه نتواند در قالب ZIP32 ذخیره شود، یک [PptxException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pptxexception/) پرتاب می‌شود.
{{% /alert %}}

## **ذخیره ارائه‌ها در قالب Office Open XML با سطوح فشرده‌سازی**

در کار با ارائه‌های بزرگ، می‌توانید سطح فشرده‌سازی را تنظیم کنید تا بین اندازهٔ فایل و زمان پردازش تعادل برقرار شود. بسته به نیازهای شما ممکن است پردازش سریع‌تر یا فایل‌های خروجی کوچکتر را ترجیح دهید.

Aspose.Slides متد [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-) را فراهم می‌کند که به شما امکان می‌دهد سطح فشرده‌سازی مورد استفاده هنگام ذخیرهٔ یک ارائه در قالب Office Open XML را مشخص کنید.

سطوح فشرده‌سازی زیر در دسترس هستند:
- [**None**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compressionlevel/#None): هیچ فشرده‌سازی‌ای اعمال نمی‌شود. فایل‌ها به همان شکل ذخیره می‌شوند.
- [**Level1**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compressionlevel/#Level1): سریع‌ترین فشرده‌سازی با پایین‌ترین نسبت فشرده‌سازی.
- [**Level2**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compressionlevel/#Level2): فشرده‌سازی سریع‌تر با نسبت فشرده‌سازی کمی بهتر نسبت به **Level1**.
- [**Level3**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compressionlevel/#Level3): فشرده‌سازی بهتری نسبت به **Level2** با تأثیر متوسط بر زمان پردازش ارائه می‌دهد.
- [**Level4**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compressionlevel/#Level4): فشرده‌سازی بهتری نسبت به **Level3** ارائه می‌دهد.
- [**Level5**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compressionlevel/#Level5): فشرده‌سازی بهبود یافته نسبت به **Level4** با زمان پردازش بیشتر فراهم می‌کند.
- [**Level6**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compressionlevel/#Level6): فشرده‌سازی استاندارد که تعادل خوبی بین سرعت پردازش و اندازهٔ فایل فراهم می‌کند. این *سطح فشرده‌سازی پیش‌فرض* است.
- [**Level7**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compressionlevel/#Level7): فشرده‌سازی بهتری نسبت به **Level6** با پردازش کندتر ارائه می‌دهد.
- [**Level8**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compressionlevel/#Level8): فشرده‌سازی بهتری نسبت به **Level7** ارائه می‌دهد.
- [**Level9**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compressionlevel/#Level9): حداکثر فشرده‌سازی. کوچک‌ترین حجم فایل را با هزینهٔ طولانی‌ترین زمان پردازش تولید می‌کند.

مثال زیر نشان می‌دهد چگونه یک ارائه را به عنوان فایل PPTX *بدون فشرده‌سازی* ذخیره کنید:

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

این مثال نشان می‌دهد چگونه یک ارائه را به عنوان فایل PPTX با *حداکثر فشرده‌سازی* ذخیره کنید:

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

## **ذخیره ارائه‌ها بدون به‌روزرسانی تصویر کوچک**

متد [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) تولید تصویر کوچک را هنگام ذخیرهٔ یک ارائه به PPTX کنترل می‌کند:
- اگر به `true` تنظیم شود، تصویر کوچک در هنگام ذخیره به‌روزرسانی می‌شود. این مقدار پیش‌فرض است.
- اگر به `false` تنظیم شود، تصویر کوچک فعلی حفظ می‌شود. اگر ارائه تصویر کوچکی نداشته باشد، هیچ‌کدام تولید نمی‌شود.

در کد زیر، ارائه بدون به‌روزرسانی تصویر کوچک خود به PPTX ذخیره می‌شود.

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

{{% alert title="Info" color="info" %}}
این گزینه به کاهش زمان مورد نیاز برای ذخیرهٔ یک ارائه در قالب PPTX کمک می‌کند.
{{% /alert %}}

## **ذخیره به‌روزرسانی پیشرفت به درصد**

رابطه [IProgressCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iprogresscallback/) از طریق متد `setProgressCallback` که توسط رابط [ISaveOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isaveoptions/) و کلاس انتزاعی [SaveOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/saveoptions/) ارائه شده است، استفاده می‌شود. یک پیاده‌سازی از [IProgressCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iprogresscallback/) را با `setProgressCallback` اختصاص دهید تا به‌روزرسانی‌های پیشرفت ذخیره به صورت درصد دریافت کنید.

کد زیر نشان می‌دهد چگونه از `IProgressCallback` استفاده کنید.

```java
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // از مقدار درصد پیشرفت در اینجا استفاده کنید.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}

ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
شرکت Aspose یک برنامهٔ رایگان [PowerPoint Splitter](https://products.aspose.app/slides/fa/splitter) را با استفاده از API خود توسعه داده است. این برنامه به شما امکان می‌دهد یک ارائه را به چندین فایل تقسیم کنید با ذخیرهٔ اسلایدهای انتخاب‌شده به عنوان فایل‌های جدید PPTX یا PPT.
{{% /alert %}}

## **FAQ**

**آیا «ذخیره سریع» (ذخیره افزایشی) پشتیبانی می‌شود به‌طوری که تنها تغییرات نوشته شوند؟**

خیر. هر بار ذخیره‌سازی، فایل هدف کامل ساخته می‌شود؛ «ذخیره سریع» افزایشی پشتیبانی نمی‌شود.

**آیا ذخیرهٔ نمونهٔ Presentation یکسان از چندین رشته به‌صورت همزمان ایمن است؟**

خیر. یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایمن برای چند رشته نیست؛ آن را از یک رشته ذخیره کنید.

**چه اتفاقی برای پیوندهای فراخوانی و فایل‌های لینک‌خورده خارجی هنگام ذخیره می‌افتد؟**

[Hyperlinks](/slides/fa/java/manage-hyperlinks/) حفظ می‌شوند. فایل‌های لینک‌خوردهٔ خارجی (مانند ویدئوها از طریق مسیرهای نسبی) به‌صورت خودکار کپی نمی‌شوند؛ باید اطمینان حاصل کنید مسیرهای ارجاع‌شده قابل دسترسی باقی بمانند.

**آیا می‌توانم متادادهٔ سند (نویسنده، عنوان، شرکت، تاریخ) را تنظیم/ذخیره کنم؟**

بله. ویژگی‌های استاندارد سند پشتیبانی می‌شوند و هنگام ذخیره به فایل نوشته می‌شوند.