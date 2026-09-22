---
title: اخذ و به‌روزرسانی اطلاعات ارائه در جاوا
linktitle: اطلاعات ارائه
type: docs
weight: 30
url: /fa/java/examine-presentation/
keywords:
- قالب ارائه
- ویژگی‌های ارائه
- ویژگی‌های سند
- دریافت ویژگی‌ها
- خواندن ویژگی‌ها
- تغییر ویژگی‌ها
- اصلاح ویژگی‌ها
- به‌روزرسانی ویژگی‌ها
- بررسی PPTX
- بررسی PPT
- بررسی ODP
- PowerPoint
- OpenDocument
- ارائه
- جاوا
- Aspose.Slides
description: "با استفاده از جاوا، اسلایدها، ساختار و فراداده‌های ارائه‌های PowerPoint و OpenDocument را کاوش کنید تا بینش‌های سریع‌تر و ارزیابی‌های محتوا هوشمندانه‌تری داشته باشید."
---
## **مرور کلی**

Aspose.Slides می‌تواند قالب یک ارائه را شناسایی کرده و فراداده‌های سند آن را بدون ایجاد یک مدل شیء کامل ارائه بخواند. این برای مواقعی مفید است که نیاز به طبقه‌بندی فایل‌ها، ساخت فهرست یا بررسی ویژگی‌ها قبل از تصمیم‌گیری برای بارگذاری و پردازش محتوای ارائه داشته باشید.

این مقاله با استفاده از [PresentationFactory](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentationfactory/) و [IPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/) بررسی سبک را نشان می‌دهد و همچنین به‌روزرسانی‌های هدفمند را از طریق [IDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties/) ارائه می‌کند.

## **بررسی قالب ارائه**

اگر قبلاً یک ارائه بارگذاری شده دارید، برای شناسایی پس از بارگذاری و محدودیت‌های جریان‌های PPT، PPS و POT قدیمی، مقاله [Determine the Original Presentation Format](/slides/fa/java/detect-presentation-source-format/) را ببینید.

از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) برای بازرسی یک فایل بدون ایجاد یک نمونه [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) استفاده کنید. متد [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) قالب شناسایی‌شده را گزارش می‌کند، مانند PPTX، PPT یا ODP.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;

String[] fileNames = { "pres.pptx", "pres.ppt", "pres.odp" };

for (String fileName : fileNames) {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(fileName);
    int loadFormat = presentationInfo.getLoadFormat();
    String formatName = "Other (" + loadFormat + ")";

    if (loadFormat == LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat == LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat == LoadFormat.Odp) {
        formatName = "ODP";
    }

    System.out.println(fileName + ": " + formatName);
}
```

## **ساخت موجودی سبک ارائه**

هنگامی که فایل‌های ارائه زیادی را پردازش می‌کنید، ممکن است به یک فهرست فشرده برای اعتبارسنجی، ایندکس‌گذاری یا سیستم مدیریت سند نیاز داشته باشید. در این حالت، از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) برای دریافت یک شیء [IPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/) استفاده کنید و سپس متد [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) را برای خواندن فراداده‌های سند فراخوانی نمایید. این رویکرد هیچ نمونه‌ای از [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد نمی‌کند و نیازی به مرور کامل مدل شیء ارائه ندارد.

ویژگی‌های گسترش یافته‌ای که توسط [IDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties/) ارائه می‌شود، مقادیر موجودی زیر را فراهم می‌کند:

| متد | مقدار موجودی |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties/#getSlides--) | کل تعداد اسلایدها. |
| [getHiddenSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | تعداد اسلایدهای مخفی. |
| [getNotes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties/#getNotes--) | تعداد اسلایدهایی که حاوی یادداشت هستند. |
| [getParagraphs](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties/#getParagraphs--) | کل تعداد پاراگراف‌ها، در صورت موجود بودن. |
| [getWords](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties/#getWords--) | کل تعداد کلمات. |
| [getMultimediaClips](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | کل تعداد کلیپ‌های صوتی و تصویری. |

مثال زیر این مقادیر را بدون ایجاد شیء [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) می‌خواند و یک فهرست فشرده چاپ می‌کند. همچنین با ترکیب [getHeadingPairs](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties/#getHeadingPairs--) و [getTitlesOfParts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) گروه‌های محتوایی مانند قلم‌ها، تم‌ها و عناوین اسلاید را نمایش می‌دهد.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IHeadingPair;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;
import java.nio.file.Paths;

String filePath = "sample.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

int loadFormat = presentationInfo.getLoadFormat();
String formatName = "Other (" + loadFormat + ")";

if (loadFormat == LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat == LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat == LoadFormat.Odp) {
    formatName = "ODP";
}

System.out.println("File: " + Paths.get(filePath).getFileName());
System.out.println("Format: " + formatName);
System.out.println("Title: " + documentProperties.getTitle());
System.out.println("Author: " + documentProperties.getAuthor());
System.out.println("Statistics:");
System.out.println("  Slides: " + documentProperties.getSlides());
System.out.println("  Hidden slides: " + documentProperties.getHiddenSlides());
System.out.println("  Slides with notes: " + documentProperties.getNotes());
System.out.println("  Paragraphs: " + documentProperties.getParagraphs());
System.out.println("  Words: " + documentProperties.getWords());
System.out.println("  Multimedia clips: " + documentProperties.getMultimediaClips());

IHeadingPair[] headingPairs = documentProperties.getHeadingPairs();
String[] titlesOfParts = documentProperties.getTitlesOfParts();
headingPairs = headingPairs != null ? headingPairs : new IHeadingPair[0];
titlesOfParts = titlesOfParts != null ? titlesOfParts : new String[0];
int partIndex = 0;

if (headingPairs.length == 0 || titlesOfParts.length == 0) {
    System.out.println("Content groups: not available");
} else {
    System.out.println("Content groups:");

    for (IHeadingPair headingPair : headingPairs) {
        System.out.println("  " + headingPair.getName() + " (" + headingPair.getCount() + ")");

        for (int partOffset = 0; partOffset < headingPair.getCount() && partIndex < titlesOfParts.length; partOffset++) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        System.out.println("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }
}
```

هر [IHeadingPair](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iheadingpair/) یک نام گروه و تعداد آیتم‌های آن گروه را فراهم می‌کند. متد [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) یک آرایهٔ صاف و ترتیب‌دار برمی‌گرداند، بنابراین تعداد عناوین متوالی مشخص‌شده توسط هر جفت سرصفحه را مصرف کنید.

### **فراداده‌های ذخیره‌شده و محدودیت‌های قالب**

ویژگی‌های موجودی که توسط [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) برگردانده می‌شود، فراداده‌های موجود در سند منبع را نشان می‌دهد. Aspose.Slides برای این فراخوانی مدل شیء ارائه را بارگذاری و مرور نمی‌کند تا این مقادیر را دوباره محاسبه کند. ویژگی‌های گمشده با مقادیر پیش‌فرض نشان داده می‌شوند و مقادیر ذخیره‌شده ممکن است منسوخ باشند اگر برنامه‌ای که آخرین بار فایل را ذخیره کرده است، ویژگی‌های سند را به‌روز نکرده باشد.

- **PPTX:** این قالب ویژگی‌های گسترش یافتهٔ سند را برای شمارش اسلاید، یادداشت، اسلاید مخفی، پاراگراف، کلمه و چندرسانه‌ای، همچنین جفت‌های سرصفحه و عناوین بخش‌ها فراهم می‌کند. در دسترس بودن آن به این بستگی دارد که کدام ویژگی‌ها توسط تولیدکننده سند نوشته شده‌اند.
- **PPT:** قالب باینری می‌تواند ویژگی‌های خلاصهٔ سند مربوطه را ذخیره کند. اگر ویژگی‌ای موجود نباشد یا توسط تولیدکننده سند به‌روزرسانی نشده باشد، Aspose.Slides مقدار ذخیره‌شده یا پیش‌فرض آن را برمی‌گرداند نه محاسبه‌شده از اسلایدها.
- **ODP:** فراداده‌های OpenDocument آمار کلی سند مانند شمارش صفحه، پاراگراف و کلمه را فراهم می‌کند، اما این مقادیر به هر ویژگی گسترش یافتهٔ خاص PowerPoint نگاشت ندارند. متادیتای اسلاید مخفی، اسلاید یادداشت، چندرسانه‌ای، جفت سرصفحه و عنوان بخش ممکن است در دسترس نباشد و ویژگی‌های موجودی ممکن است مقادیر پیش‌فرض برگردانند. مقدار صفر یا آرایهٔ خالی را به‌عنوان اثبات قطعی عدم وجود محتوای مرتبط در نظر نگیرید.

از رویکرد فراداده سبک برای فهرست‌ها و بررسی‌های اولیه استفاده کنید. زمانی که نتیجه باید تغییرات در حافظه را منعکس کند یا نیاز به تأیید محتوای واقعی ارائه دارید، ارائه را بارگذاری و مدل شیء زندهٔ آن را بازرسی کنید.

## **به‌روزرسانی ویژگی‌های ارائه**

ویژگی‌هایی که توسط [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) برگردانده می‌شود، می‌توانند بدون ایجاد یک نمونه [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) نیز تغییر کنند. تغییرات را با [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) اعمال کنید و سپس ارائهٔ مرتبط را با [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-) بنویسید.

تصویر زیر ویژگی‌های سند اصلی ارائهٔ PowerPoint را نشان می‌دهد.

![ویژگی‌های سند اصلی ارائهٔ پاورپوینت](input_properties.png)

مثال زیر عنوان و زمان آخرین ذخیره‌سازی را تغییر داده و نتیجه را در فایلی جدید می‌نویسد:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.io.FileOutputStream;
import java.io.OutputStream;
import java.util.Date;

String sourceFile = "sample.pptx";
String outputFile = "sample_with_updated_properties.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(sourceFile);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(new Date());

presentationInfo.updateDocumentProperties(documentProperties);
try (OutputStream outputStream = new FileOutputStream(outputFile)) {
    presentationInfo.writeBindedPresentation(outputStream);
}
```

تصویر زیر ویژگی‌های سند به‌روزرسانی‌شدهٔ ارائهٔ PowerPoint را نشان می‌دهد.

![ویژگی‌های سند به‌روزرسانی‌شدهٔ پاورپوینت](output_properties.png)

## **لینک‌های مفید**

برای بررسی‌های امنیتی مرتبط و تنظیمات محافظت، مقالات زیر را ببینید:

- [Password-Protect Presentations](/slides/fa/java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/fa/java/write-protected-presentation/)

## **سوالات متداول**

**چگونه می‌توانم بررسی کنم که آیا قلم‌ها جاسازی شده‌اند و کدام‌ها هستند؟**

ارائه را بارگذاری کنید و از [Presentation.getFontsManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getFontsManager--) استفاده کنید. متد [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) قلم‌های جاسازی‌شده را برمی‌گرداند و [IFontsManager.getFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontsmanager/#getFonts--) قلم‌های استفاده‌شده در ارائه را برمی‌گرداند. دو نتیجه را مقایسه کنید تا قلم‌های موردنیاز برای رندر که جاسازی نشده‌اند، پیدا کنید.

**چگونه می‌توانم به‌سرعت تشخیص دهم که آیا فایل اسلایدهای مخفی دارد و چند تا؟**

زمانی که فرادادهٔ ذخیره‌شدهٔ سند کافی باشد، از [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) از طریق [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) و [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) بخوانید. این روش برای فهرست سبک مناسب است. اگر ارائه در حافظه تغییر کرده باشد، فرادادهٔ ذخیره‌شده ممکن است گمشده یا منسوخ باشد؛ در این صورت برای تأیید مقدار زنده، از [Presentation.getSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getSlides--) عبور کرده و متد [ISlide.getHidden](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/#getHidden--) هر اسلاید را بررسی کنید.

**آیا می‌توانم تشخیص دهم که آیا اندازه و جهت‌گیری سفارشی اسلاید استفاده شده است و آیا با پیش‌فرض‌ها متفاوت است؟**

بله. ارائه را بارگذاری کنید و متد [Presentation.getSlideSize](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getSlideSize--) را فراخوانی کنید. از [ISlideSize.getType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidesize/#getType--)، [ISlideSize.getSize](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidesize/#getSize--) و [ISlideSize.getOrientation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidesize/#getOrientation--) برای مقایسه تنظیمات فعلی با پیش‌تنظیمات و ابعاد مورد انتظار استفاده کنید.

**آیا راه سریعى برای مشاهده اینکه آیا نمودارها به منابع داده خارجی ارجاع می‌دهند وجود دارد؟**

بله. هر [Chart](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chart/) را پیدا کنید و متد [IChartData.getDataSourceType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdata/#getDataSourceType--) را فراخوانی کنید. برای یک کتاب‌کار خارجی، متد [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) را صدا بزنید. نوع منبع داده و مسیر نشانگر ارجاع خارجی هستند، اما تأیید در دسترس بودن هدف نیاز به بررسی منبع جداگانه دارد.

**چگونه می‌توانم اسلایدهای «سنگین» که ممکن است رندر یا خروجی PDF را کند کنند، ارزیابی کنم؟**

هیچ ویژگی پیچیدگی واحدی وجود ندارد. از [Presentation.getSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getSlides--) و مجموعهٔ [IBaseSlide.getShapes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseslide/#getShapes--) هر اسلاید عبور کنید. شمارش اشکال و وجود تصاویر بزرگ، افکت‌ها، انیمیشن‌ها یا چندرسانه‌ای را به‌عنوان سیگنال‌های فیلترینگ استفاده کنید و قبل از این‌که اسلاید را به‌عنوان گلوگاه عملکردی تأیید کنید، یک رندر یا خروجی نماینده را اندازه‌گیری کنید.