---
title: تعیین قالب اصلی ارائه در جاوا
linktitle: قالب منبع
type: docs
weight: 35
url: /fa/java/detect-presentation-source-format/
keywords:
- قالب منبع
- تشخیص قالب ارائه
- PowerPoint
- OpenDocument
- ارائه
- PPT
- PPTX
- جاوا
- Aspose.Slides
description: "قالب اصلی یک ارائه بارگذاری‌شده را در جاوا با Aspose.Slides برای جاوا بخوانید، APIهای تشخیص را مقایسه کنید و فایل‌ها، استریم‌ها و قالب‌های قدیمی را مدیریت کنید."
---
## **نگاهی کلی**

پس از بارگذاری یک ارائه، متد [Presentation.getSourceFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getSourceFormat--) را صدا بزنید تا قالب اصلی آن را تعیین کنید. این متد همچنین از طریق [IPresentation.getSourceFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentation/#getSourceFormat--) در دسترس است. از آن استفاده کنید زمانی که پردازش بعدی به قالبی که نمونه فعلی از آن بارگذاری شده بستگی دارد.

قالب منبع با [SaveFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/saveformat/) انتخاب‌شده برای فایل خروجی متفاوت است. ذخیره‌سازی به قالب دیگری، قالب منبع نمونه موجود را تغییر نمی‌دهد.

## **خواندن قالب منبع یک فایل**

این مثال به یک فایل `sample.pptx` موجود نیاز دارد. این فایل را بارگذاری می‌کند و به‌جای نام فایل، از سیاست پردازش برنامه با استفاده از [Presentation.getSourceFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getSourceFormat--) انتخاب می‌کند. مسیر ورودی را تغییر دهید تا فرمت‌های دیگر را امتحان کنید. مثال مقدار سیاست انتخاب‌شده را چاپ می‌کند؛ پیام‌ها را با منطق برنامه خود جایگزین کنید.

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

کلاس [SourceFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/sourceformat/) ثابت‌های عددی تعریف می‌کند که قالب‌های ارائه زیر را از یک‌دیگر متمایز می‌کند. پسوندهای زیر پسوندهای متداول هستند و بازسازی نام فایل اصلی نیستند.

| مقدار SourceFormat | پسوند | قالب |
| --- | --- | --- |
| `Ppt` | `.ppt` | ارائه PowerPoint 97–2003 |
| `Pptx` | `.pptx` | ارائه Office Open XML |
| `Pptm` | `.pptm` | ارائه Office Open XML با ماکرو |
| `Pps` | `.pps` | نمایش اسلاید PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | نمایش اسلاید Office Open XML |
| `Ppsm` | `.ppsm` | نمایش اسلاید Office Open XML با ماکرو |
| `Pot` | `.pot` | الگوی PowerPoint 97–2003 |
| `Potx` | `.potx` | الگوی Office Open XML |
| `Potm` | `.potm` | الگوی Office Open XML با ماکرو |
| `Odp` | `.odp` | ارائه OpenDocument |
| `Otp` | `.otp` | الگوی ارائه OpenDocument |
| `Fodp` | `.fodp` | ارائه Flat XML ODF |
| `Xml` | `.xml` | ارائه PowerPoint XML |

## **خواندن قالب منبع یک استریم**

این مثال به یک فایل `sample.pps` موجود نیاز دارد. خواندن بایت‌های آن در یک استریم حافظه، ورودی بدون نام فایل (مانند مقدار پایگاه داده یا آرایه بایتی بارگذاری‌شده) را شبیه‌سازی می‌کند. سازنده [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) فقط استریم را دریافت می‌کند.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

try {
    byte[] bytes = Files.readAllBytes(Paths.get("sample.pps"));
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

PPT، PPS و POT از قالب باینری مشترکی استفاده می‌کنند. هنگام بارگذاری بر پایه مسیر فایل، پسوند می‌تواند به تمییز نشان اسلاید یا الگو کمک کند. بدون نام فایل، محتوای PPS یا POT قدیمی ممکن است به صورت `SourceFormat.Ppt` گزارش شود؛ مثال PPS بالا مقدار عددی `SourceFormat.Ppt` را چاپ می‌کند.

اگر برنامه شما باید این تمایز را حفظ کند، نام فایل اصلی یا متادیتای زیرنوع را جداگانه نگه دارید. یک پسوند برای این زیرنوع‌های قدیمی راهنمای مفیدی است، اما نباید تنها معیار تشخیص محتوای ارائه دلخواه باشد.

## **مقایسه تشخیص قبل و بعد از بارگذاری**

از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) و [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) زمانی که نیاز به بررسی فایل قبل از بارگذاری مدل شیء کامل ارائه دارید، استفاده کنید. وقتی نمونه قبلاً وجود دارد، از [Presentation.getSourceFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getSourceFormat--) استفاده کنید.

این مثال به `sample.pptx` نیاز دارد و مقادیر عددی `LoadFormat.Pptx` و `SourceFormat.Pptx` را به ترتیب چاپ می‌کند. در تولید، API مناسب مرحله پردازش خود را انتخاب کنید؛ یک ارائه‌ای که قبلاً بارگذاری شده نیازی به بازرسی دوم صرفاً برای دریافت قالب منبع ندارد.

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

نتایج از ثابت‌های کلاس‌های مختلف استفاده می‌کنند: [LoadFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadformat/) و [SourceFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/sourceformat/). مقادیر عددی آن‌ها را مقایسه نکنید یا فرض نکنید که برای هر قالب نتایج تشخیص یکسان هستند. PowerPoint XML ممکن است قبل از بارگذاری به عنوان `LoadFormat.Unknown` گزارش شود و پس از بارگذاری به عنوان `SourceFormat.Xml`.

## **نگهداری جداگانه قالب منبع و خروجی**

این مثال به `sample.pptx` نیاز دارد و `converted.odp` را می‌نویسد. مقدار عددی `SourceFormat.Pptx` را هم قبل و هم بعد از ذخیره نمونه اصلی چاپ می‌کند. فقط نمونه جدیدی که از خروجی ODP بارگذاری می‌شود، `Odp` را گزارش می‌دهد.

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

یک ارائه که از صفر با `new Presentation()` ساخته می‌شود، `SourceFormat.Pptx` را گزارش می‌کند. این نمونه فایل ورودی ندارد: این مقدار پیش‌فرض برای یک نمونه تازه ایجاد شده است و نشانه‌ای نیست که یک فایل PPTX بارگذاری شده باشد. اگر این تمایز برای شما مهم است، جداگانه ردیابی کنید که برنامه شما نمونه را ایجاد کرده یا بارگذاری کرده است.

## **نقشه‌برداری قالب منبع به پسوند**

مثال زیر به `sample.pptx` نیاز دارد. هر مقدار فعلی پشتیبانی‌شده از [SourceFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/sourceformat/) را به پسوند متداولی نگاشت می‌کند، بدون اینکه نام فایل ورودی تجزیه شود. حالت پیش‌فرض از اختصاص سکونتی پسوند به مقدار ناشناخته جلوگیری می‌کند.

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

این نگاشت فایلی را تبدیل یا زیرنوع PPS/POT قدیمی را که هنگام بارگذاری استریم از دست رفته بازیابی نمی‌کند. برای ذخیره واقعی، یک [SaveFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/saveformat/) را به‌طور صریح انتخاب کنید یا از تبدیل نشان‌داده‌شده در [Save Presentations in Their Original Format](/slides/fa/java/save-presentation/#save-presentations-in-their-original-format) استفاده کنید.

## **تأیید قالب‌ها با ذخیره و بازگشایی مجدد**

این مثال خودکفا یک ارائه می‌سازد و سه فایل را در پوشه کاری می‌نویسد، فایل‌هایی با نام‌های مشابه را بازنویسی می‌کند. هر خروجی هم از مسیر و هم از یک استریم حافظه باز می‌شود. برای PPTX و ODP، هر دو مسیر قالب ذخیره‌شده را گزارش می‌کنند. برای PPS، بارگذاری از مسیر `Pps` گزارش می‌شود، در حالی که بارگذاری همان بایت‌ها بدون نام فایل `Ppt` گزارش می‌شود.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes = Files.readAllBytes(Paths.get(path));
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

جدول زیر شناسایی قالب منبع برای ارائه‌های دارای پسوندهای مطابق را خلاصه می‌کند. نام‌ها ثابت‌ها را نشان می‌دهند؛ مثال‌های Java مقدار عددی آن‌ها را چاپ می‌کنند:

| قالب ذخیره‌شده | SourceFormat از مسیر فایل | SourceFormat از استریم بدون نام |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | به ترتیب `Pptx`، `Pptm` | همان‌طور که مسیر فایل |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | به ترتیب `Ppsx`، `Ppsm` | همان‌طور که مسیر فایل |
| POT | `Pot` | `Ppt` |
| POTX, POTM | به ترتیب `Potx`، `Potm` | همان‌طور که مسیر فایل |
| ODP, OTP | به ترتیب `Odp`، `Otp` | همان‌طور که مسیر فایل |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

محتوای PPS/POT برای استریم‌های بدون نام به صورت `Ppt` شناسایی می‌شود. جدول شناسایی قالب را توصیف می‌کند، نه حفظ هر ویژگی ارائه در طول تبدیل.

## **سؤالات متداول**

**آیا ذخیره به ODP قالب منبع ارائه‌ای که از PPTX بارگذاری شده را تغییر می‌دهد؟**

خیر. نمونه موجود همچنان `Pptx` را گزارش می‌کند. نمونه‌ای که از فایل ODP ذخیره‌شده بارگذاری می‌شود، `Odp` را گزارش می‌دهد.

**آیا یک استریم همیشه می‌تواند ارائه، نمایش اسلاید یا الگوی قدیمی را متمایز سازد؟**

خیر. PPT، PPS و POT قالب باینری مشترکی دارند. هنگام نیاز به این تمایز، نام فایل یا متادیتای زیرنوع را جداگانه نگه دارید.

**اگر ارائه قبلاً بارگذاری شده باشد، کدام API را باید استفاده کنم؟**

متد [Presentation.getSourceFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getSourceFormat--) را بخوانید. برای بازرسی قبل از بارگذاری، از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) استفاده کنید.