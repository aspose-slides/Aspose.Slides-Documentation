---
title: تشخیص قالب اصلی ارائه در اندروید
linktitle: قالب منبع
type: docs
weight: 35
url: /fa/androidjava/detect-presentation-source-format/
keywords:
- قالب منبع
- تشخیص قالب ارائه
- پاورپوینت
- OpenDocument
- ارائه
- PPT
- PPTX
- اندروید
- جاوا
- Aspose.Slides
description: قالب اصلی یک ارائه بارگذاری‌شده را در اندروید با Aspose.Slides برای اندروید از طریق جاوا بخوانید، APIهای تشخیص را مقایسه کنید و با فایل‌ها، جریان‌ها و قالب‌های قدیمی کار کنید.
---
## **نمای کلی**

پس از بارگذاری یک ارائه، متد [Presentation.getSourceFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getSourceFormat--) را فراخوانی کنید تا قالب اصلی آن را تعیین کنید. این متد همچنین از طریق [IPresentation.getSourceFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--) در دسترس است. زمانی که پردازش‌های بعدی به قالبی که نمونه‌ی فعلی از آن بارگذاری شده وابسته است، از آن استفاده کنید.

قالب منبع با [SaveFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/saveformat/) انتخاب‌شده برای فایل خروجی متفاوت است. ذخیره‌سازی در قالب دیگری، قالب منبع نمونه‌ی موجود را تغییر نمی‌دهد.

مثال‌ها از جاوا و مسیرهای فایل استفاده می‌کنند. در اندروید، مسیرهای نمونه را با مسیرهای موجود در ذخیره‌سازی قابل دسترسی برنامه (مانند پوشهٔ داخلی برنامه) جایگزین کنید.

## **خواندن قالب منبع یک فایل**

این مثال به یک فایل `sample.pptx` موجود نیاز دارد. فایل را بارگذاری می‌کند و به‌جای نام فایل، سیاست پردازش برنامه را با استفاده از [Presentation.getSourceFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getSourceFormat--) انتخاب می‌کند. مسیر ورودی را تغییر دهید تا قالب‌های دیگر را آزمایش کنید. مثال سیاست انتخاب‌شده را چاپ می‌کند؛ پیام‌ها را با منطق برنامه‌ی خود جایگزین کنید.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
        case SourceFormat.Pps:
        case SourceFormat.Pot:
            System.out.println("Use the legacy PowerPoint processing policy.");
            break;
        case SourceFormat.Pptx:
            System.out.println("Use the standard PPTX processing policy.");
            break;
        default:
            System.out.println("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **شناسایی مقادیر پشتیبانی‌شده**

کلاس [SourceFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/sourceformat/) ثابت‌های عددی را تعریف می‌کند که قالب‌های ارائه زیر را متمایز می‌سازند. پسوندهای زیر پسوندهای متداول هستند و بازسازی نام اصلی فایل را نشان نمی‌دهند.

| مقدار SourceFormat | پسوند | قالب |
| --- | --- | --- |
| `Ppt` | `.ppt` | ارائهٔ PowerPoint 97–2003 |
| `Pptx` | `.pptx` | ارائهٔ Office Open XML |
| `Pptm` | `.pptm` | ارائهٔ Office Open XML با ماکرو |
| `Pps` | `.pps` | نمایش اسلاید PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | نمایش اسلاید Office Open XML |
| `Ppsm` | `.ppsm` | نمایش اسلاید Office Open XML با ماکرو |
| `Pot` | `.pot` | قالب PowerPoint 97–2003 |
| `Potx` | `.potx` | قالب Office Open XML |
| `Potm` | `.potm` | قالب Office Open XML با ماکرو |
| `Odp` | `.odp` | ارائهٔ OpenDocument |
| `Otp` | `.otp` | قالب ارائهٔ OpenDocument |
| `Fodp` | `.fodp` | ارائهٔ Flat XML ODF |
| `Xml` | `.xml` | ارائهٔ PowerPoint XML |

## **خواندن قالب منبع یک جریان**

این مثال به یک فایل `sample.pps` موجود نیاز دارد. خواندن بایت‌های آن در یک جریان حافظه، مدلی برای ورودی بدون نام فایل (مانند مقدار پایگاه‌داده یا آرایه بایت آپلودشده) است. سازندهٔ [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) فقط جریان را می‌گیرد.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

try {
    byte[] bytes;
    try (FileInputStream input = new FileInputStream("sample.pps");
         ByteArrayOutputStream output = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = input.read(buffer)) != -1) {
            output.write(buffer, 0, bytesRead);
        }
        bytes = output.toByteArray();
    }
    try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
        Presentation presentation = new Presentation(stream);
        try {
            System.out.println("Source format: " + presentation.getSourceFormat());
        } finally {
            presentation.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read the presentation: " + exception.getMessage());
}
```

PPT، PPS و POT از همان قالب دودویی زیرساختی استفاده می‌کنند. هنگام بارگذاری از مسیر فایل، پسوند می‌تواند به تشخیص نمایش اسلاید یا قالب کمک کند. بدون نام فایل، محتوای قدیمی PPS و POT ممکن است به عنوان `SourceFormat.Ppt` گزارش شود؛ مثال PPS در بالا مقدار عددی `SourceFormat.Ppt` را چاپ می‌کند.

اگر برنامه‌ی شما نیاز به حفظ این تمایز دارد، نام فایل اصلی یا فرادادهٔ زیرنوع را به‌صورت جداگانه نگه دارید. پسوند یک سرنخ مفید برای این زیرنوع‌های قدیمی است، اما نباید تنها معیار شناسایی محتوای ارائهٔ دلخواه باشد.

## **مقایسهٔ تشخیص قبل و بعد از بارگذاری**

هنگامی که نیاز به بازرسی یک فایل قبل از بارگذاری تمام مدل شیء ارائه دارید، از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) و [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) استفاده کنید. وقتی نمونه قبلاً وجود دارد، از [Presentation.getSourceFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getSourceFormat--) استفاده کنید.

این مثال به `sample.pptx` نیاز دارد و مقادیر عددی `LoadFormat.Pptx` و `SourceFormat.Pptx` را به ترتیب چاپ می‌کند. در محیط تولید، API متناسب با مرحله پردازش خود را انتخاب کنید؛ یک ارائه‌ی بارگذاری‌شده دیگر نیازی به بازرسی دوم صرفاً برای دریافت قالب منبع ندارد.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;

String path = "sample.pptx";
IPresentationInfo information = PresentationFactory.getInstance().getPresentationInfo(path);
System.out.println("Before loading: " + information.getLoadFormat());

Presentation presentation = new Presentation(path);
try {
    System.out.println("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

نتیجه‌ها از ثابت‌های کلاس‌های متفاوتی استفاده می‌کنند: [LoadFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/loadformat/) و [SourceFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/sourceformat/). مقدار عددی آن‌ها را با هم مقایسه نکنید و فرض نکنید که هر قالب نتایج تشخیص یکسانی دارد. PowerPoint XML ممکن است قبل از بارگذاری به عنوان `LoadFormat.Unknown` گزارش شود و پس از بارگذاری به عنوان `SourceFormat.Xml`.

## **نگهداری مجزا قالب منبع و خروجی**

این مثال به `sample.pptx` نیاز دارد و `converted.odp` را می‌نویسد. مقدار عددی `SourceFormat.Pptx` را هم قبل و هم بعد از ذخیره‌سازی نمونهٔ اصلی چاپ می‌کند. فقط نمونهٔ جدید بارگذاری‌شده از خروجی ODP، `Odp` را گزارش می‌دهد.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", SaveFormat.Odp);
    System.out.println("After saving: " + presentation.getSourceFormat());

    Presentation reopened = new Presentation("converted.odp");
    try {
        System.out.println("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

یک ارائه که از ابتدا با `new Presentation()` ساخته می‌شود، `SourceFormat.Pptx` را گزارش می‌کند. این نمونه ورودی ندارد: این مقدار پیش‌فرض برای یک نمونهٔ تازه ساخته‌شده است و نشانگر این نیست که فایلی با فرمت PPTX بارگذاری شده است. اگر این تمایز برای برنامه‌تان مهم است، به‌طور جداگانه پیگیری کنید که آیا نمونه ساخته یا بارگذاری شده است.

## **نگاشت قالب منبع به پسوند**

مثال زیر به `sample.pptx` نیاز دارد. هر مقدارcurrently پشتیبانی‌شده از [SourceFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/sourceformat/) را به یک پسوند متداول نگاشت می‌کند، بدون تجزیه نام فایل ورودی. اگر مقدار شناخته نشود، هیچ پسوندی به‌صورت خاموش اختصاص داده نمی‌شود.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    String extension;
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case SourceFormat.Pps:
            extension = ".pps";
            break;
        case SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case SourceFormat.Pot:
            extension = ".pot";
            break;
        case SourceFormat.Potx:
            extension = ".potx";
            break;
        case SourceFormat.Potm:
            extension = ".potm";
            break;
        case SourceFormat.Odp:
            extension = ".odp";
            break;
        case SourceFormat.Otp:
            extension = ".otp";
            break;
        case SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    System.out.println(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

این نگاشت فایلی را تبدیل نمی‌کند و زیرنوع قدیمی PPS/POT که هنگام بارگذاری از جریان از دست رفته است را بازنشانی نمی‌کند. برای ذخیره‌سازی واقعی، یک [SaveFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/saveformat/) را به‌صورت صریح انتخاب کنید یا از تبدیل نشان داده‌شده در [Save Presentations in Their Original Format](/slides/fa/androidjava/save-presentation/#save-presentations-in-their-original-format) استفاده کنید.

## **تأیید قالب‌ها با ذخیره‌سازی و بازگشایی مجدد**

این مثال مستقل یک ارائه ایجاد می‌کند و سه فایل را در پوشه کاری می‌نویسد، فایل‌های هم‌نام را بازنویسی می‌کند. هر خروجی را هم از مسیر و هم از یک جریان حافظه باز می‌کند. برای PPTX و ODP، هر دو مسیر قالب ذخیره‌شده را گزارش می‌دهند. برای PPS، بارگذاری از مسیر `Pps` را گزارش می‌کند، در حالی که بارگذاری همان بایت‌ها بدون نام فایل `Ppt` را گزارش می‌دهد.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes;
            try (FileInputStream input = new FileInputStream(path);
                 ByteArrayOutputStream output = new ByteArrayOutputStream()) {
                byte[] buffer = new byte[8192];
                int bytesRead;
                while ((bytesRead = input.read(buffer)) != -1) {
                    output.write(buffer, 0, bytesRead);
                }
                bytes = output.toByteArray();
            }
            try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
                Presentation fromStream = new Presentation(stream);
                try {
                    System.out.println(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            }
        } finally {
            fromFile.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read a saved presentation: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

جدول زیر شناسایی قالب منبع برای ارائه‌هایی با پسوندهای منطبق را خلاصه می‌کند. نام‌ها ثابت‌ها هستند؛ مثال‌های جاوا مقادیر عددی آن‌ها را چاپ می‌کنند:

| قالب ذخیره‌شده | SourceFormat از مسیر فایل | SourceFormat از جریان بی‌نام |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` به ترتیب | همانند مسیر فایل |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` به ترتیب | همانند مسیر فایل |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` به ترتیب | همانند مسیر فایل |
| ODP, OTP | `Odp`, `Otp` به ترتیب | همانند مسیر فایل |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

محتوای PPS/POT برای جریان‌های بی‌نام به عنوان `Ppt` شناسایی می‌شود. جدول صرفاً شناسایی قالب را توصیف می‌کند و نه حفظ تمام ویژگی‌های ارائه در حین تبدیل.

## **سوالات متداول**

**آیا ذخیره‌سازی به ODP قالب منبع ارائه‌ای که از PPTX بارگذاری شده است را تغییر می‌دهد؟**

خیر. نمونه موجود همچنان `Pptx` را گزارش می‌کند. نمونه‌ای که از فایل ODP ذخیره‌شده بارگذاری می‌شود `Odp` را گزارش می‌دهد.

**آیا یک جریان همیشه می‌تواند یک ارائه، نمایش اسلاید یا قالب قدیمی را متمایز کند؟**

خیر. PPT، PPS و POT قالب دودویی یکسانی دارند. وقتی این تمایز لازم است، نام فایل یا فرادادهٔ زیرنوع را به‌صورت جداگانه نگه دارید.

**اگر ارائه قبلاً بارگذاری شده باشد، کدام API را باید استفاده کنم؟**

[Presentation.getSourceFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getSourceFormat--) را بخوانید. برای بازرسی قبل از بارگذاری، از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) استفاده کنید.