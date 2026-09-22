---
title: بازیابی و به‌روزرسانی اطلاعات ارائه در Android
linktitle: اطلاعات ارائه
type: docs
weight: 30
url: /fa/androidjava/examine-presentation/
keywords:
- فرمت ارائه
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
- Android
- Java
- Aspose.Slides
description: "اسلایدها، ساختار و متادیتا در ارائه‌های PowerPoint و OpenDocument را با استفاده از Java برای دسترسی‌های سریع‌تر و بررسی‌های هوشمند محتوا بررسی کنید."
---
## **بررسی کلی**

Aspose.Slides می‌تواند قالب یک ارائه را شناسایی کند و متادیتای سند آن را بدون ایجاد یک مدل شیء کامل ارائه بخواند. این برای زمانی مفید است که نیاز به طبقه‌بندی فایل‌ها، ساخت فهرست موجودی یا بررسی ویژگی‌ها قبل از تصمیم‌گیری برای بارگذاری و پردازش محتوای ارائه دارید.

این مقاله با استفاده از [PresentationFactory](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentationfactory/) و [IPresentationInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/) بازرسی سبک را نشان می‌دهد و همچنین به‌روزرسانی‌های هدفمند را از طریق [IDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties/) ارائه می‌دهد.

## **بررسی قالب یک ارائه**

اگر پیش از این یک ارائه بارگذاری شده داشته باشید، برای تشخیص پس از بارگذاری و محدودیت‌های جریان‌های PPT، PPS و POT قدیمی، به مقاله [Determine the Original Presentation Format](/slides/fa/androidjava/detect-presentation-source-format/) مراجعه کنید.

از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) برای بررسی یک فایل بدون ایجاد یک نمونه [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) استفاده کنید. متد [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) قالب شناسایی‌شده را گزارش می‌دهد، مانند PPTX، PPT یا ODP.

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

## **ساخت یک فهرست موجودی سبک برای ارائه‌ها**

هنگامی که تعداد زیادی فایل ارائه را پردازش می‌کنید، ممکن است به یک فهرست موجودی فشرده برای اعتبارسنجی، فهرست‌گذاری یا یک سیستم مدیریت سند نیاز داشته باشید. در این حالت، از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) برای دریافت یک شیء [IPresentationInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/) استفاده کنید و سپس متد [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) را فراخوانی کنید تا متادیتای سند را بخوانید. این رویکرد شیء [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ای ایجاد نمی‌کند و نیازی به پیمایش کامل مدل شیء ارائه ندارید.

ویژگی‌های گسترش‌یافته‌ای که توسط [IDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties/) ارائه می‌شوند، مقادیر موجودی زیر را فراهم می‌آورند:

| متد | مقدار موجودی |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties/#getSlides--) | مجموع تعداد اسلایدها. |
| [getHiddenSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | تعداد اسلایدهای مخفی. |
| [getNotes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties/#getNotes--) | تعداد اسلایدهایی که حاوی یادداشت هستند. |
| [getParagraphs](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties/#getParagraphs--) | مجموع تعداد پاراگراف‌ها، در صورت موجود بودن. |
| [getWords](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties/#getWords--) | مجموع تعداد کلمات. |
| [getMultimediaClips](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | مجموع تعداد کلیپ‌های صوتی و تصویری. |

مثال زیر این مقادیر را بدون ایجاد یک شیء [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) می‌خواند و فهرست موجودی فشرده‌ای را چاپ می‌کند. همچنین با ترکیب [getHeadingPairs](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties/#getHeadingPairs--) و [getTitlesOfParts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) گروه‌های محتوا مانند قلم‌ها، تم‌ها و عناوین اسلاید نمایش داده می‌شود.

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

هر [IHeadingPair](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iheadingpair/) یک نام گروه و تعداد آیتم‌های موجود در آن گروه را فراهم می‌کند. متد [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) یک آرایهٔ صاف و مرتب برمی‌گرداند، بنابراین تعداد عناوین متوالی مشخص شده توسط هر جفت سرنویس را مصرف کنید.

### **متادیتای ذخیره‌شده و محدودیت‌های قالب**

ویژگی‌های موجودی که توسط [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) بازگردانده می‌شوند، متادیتای موجود در سند منبع را منعکس می‌کنند. Aspose.Slides برای این فراخوانی مدل شیء ارائه را بارگذاری و پیمایش نمی‌کند تا این مقادیر را مجدداً محاسبه کند. ویژگی‌های مفقود به‌صورت مقدارهای پیش‌فرض نشان داده می‌شوند و مقادیر ذخیره‌شده ممکن است قدیمی باشند اگر برنامه‌ای که آخرین بار فایل را ذخیره کرده بود، ویژگی‌های سند را به‌روزرسانی نکرده باشد.

- **PPTX:** این قالب ویژگی‌های مستند گسترش‌یافته برای شمارش اسلاید، یادداشت، اسلاید مخفی، پاراگراف، کلمه و چندرسانه‌ای، همچنین جفت‌های سرنویس و عناوین بخش‌ها را فراهم می‌کند. در دسترس بودن آن به این بستگی دارد که کدام ویژگی‌ها توسط تولیدکننده سند نوشته شده‌اند.
- **PPT:** قالب باینری می‌تواند ویژگی‌های خلاصه‌سندی مشابه را ذخیره کند. اگر ویژگی‌ای غایب باشد یا توسط تولیدکننده سند به‌روزرسانی نشده باشد، Aspose.Slides مقدار ذخیره‌شده یا پیش‌فرض آن را برمی‌گرداند نه اینکه آن را از اسلایدها محاسبه کند.
- **ODP:** متادیتای OpenDocument آمار کلی سند مانند تعداد صفحات، پاراگراف و کلمه را ارائه می‌دهد، اما این مقادیر به هر ویژگی گسترش‌یافته خاص PowerPoint نگاشته نمی‌شوند. متادیتای اسلاید مخفی، اسلاید یادداشت، چندرسانه‌ای، جفت‑سرنویس و عناوین بخش ممکن است در دسترس نباشند و ویژگی‌های موجودی ممکن است مقادیر پیش‌فرض را برگردانند. مقدار صفر یا آرایهٔ خالی را به‌عنوان اثبات قطعی عدم وجود محتوا در نظر نگیرید.

از روش متادیتای سبک برای فهرست‌ها و بررسی‌های مقدماتی استفاده کنید. زمانی که نتیجه باید تغییرات در حافظه را نشان دهد یا نیاز به تأیید محتوای واقعی ارائه دارید، ارائه را بارگذاری و مدل شیء زنده آن را بررسی کنید.

## **به‌روزرسانی ویژگی‌های ارائه**

ویژگی‌های بازگردانده‌شده توسط [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) می‌توانند بدون ایجاد یک نمونه [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) نیز تغییر کنند. تغییرات را با [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) اعمال کنید و سپس ارائهٔ پیوست‌شده را با [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-) بنویسید.

تصویر زیر ویژگی‌های سند اصلی ارائهٔ PowerPoint را نشان می‌دهد.

![Original document properties of the PowerPoint presentation](input_properties.png)

مثال زیر عنوان و زمان آخرین ذخیره شدن را تغییر می‌دهد و نتیجه را به یک فایل جدید می‌نویسد:

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

تصویر زیر ویژگی‌های سند به‌روزرسانی‌شده را نشان می‌دهد.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **لینک‌های مفید**

برای بررسی‌های امنیتی مرتبط و تنظیمات حفاظت، به مقالات زیر مراجعه کنید:

- [Password-Protect Presentations](/slides/fa/androidjava/password-protected-presentation/)
- [Write-Protect Presentations](/slides/fa/androidjava/write-protected-presentation/)

## **سوالات متداول**

**چگونه می‌توانم بررسی کنم آیا فونت‌ها embedded هستند و کدام‌ها؟**

ارائه را بارگذاری کنید و از [Presentation.getFontsManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getFontsManager--) استفاده کنید. متد [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) فونت‌های embedded را برمی‌گرداند و [IFontsManager.getFonts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) فونت‌های مورد استفاده در ارائه را برمی‌گرداند. دو نتیجه را مقایسه کنید تا فونت‌های لازم برای رندر ولی نه‌ embedded را بیابید.

**چگونه می‌توانم سریعاً بفهمم آیا فایل اسلایدهای مخفی دارد و چه تعداد؟**

زمانی که متادیتای ذخیره‌شده سند کافی باشد، [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) را از طریق [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) و [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) بخوانید. این برای فهرست موجودی سبک مناسب است. اگر ارائه در حافظه تغییر کرده باشد یا نیاز به تأیید مقادیر زنده داشته باشید، به‌جای آن به‌صورت تحلیلی از طریق [Presentation.getSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getSlides--) پیمایش کنید و متد [ISlide.getHidden](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/#getHidden--) هر اسلاید را بررسی کنید.

**آیا می‌توانم تشخیص دهم آیا اندازه و جهت سفارشی اسلاید استفاده شده‌اند و آیا با پیش‌فرض‌ها متفاوت هستند؟**

بله. ارائه را بارگذاری کنید و متد [Presentation.getSlideSize](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getSlideSize--) را فراخوانی کنید. با استفاده از [ISlideSize.getType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidesize/#getType--)، [ISlideSize.getSize](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidesize/#getSize--) و [ISlideSize.getOrientation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidesize/#getOrientation--) تنظیمات فعلی را با پیش‌فرض‌ها و ابعاد مورد انتظار مقایسه کنید.

**آیا راهی سریع برای مشاهده این‌که نمودارها به منبع دادهٔ خارجی ارجاع می‌دهند وجود دارد؟**

بله. هر [Chart](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chart/) را پیدا کنید و متد [IChartData.getDataSourceType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--) را فراخوانی کنید. برای یک کتاب‌کار خارجی، متد [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) را صدا بزنید. نوع منبع داده و مسیر، یک ارجاع خارجی را نشان می‌دهد، اما برای تأیید موجودیت هدف نیاز به بررسی منابع جداگانه‌ای دارد.

**چگونه می‌توانم اسلایدهای «سنگین» که ممکن است رندر یا خروجی PDF را کند کنند ارزیابی کنم؟**

هیچ ویژگی پیچیدگی واحدی وجود ندارد. به‌وسیلهٔ پیمایش [Presentation.getSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getSlides--) و مجموعهٔ [IBaseSlide.getShapes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseslide/#getShapes--) هر اسلاید، تعداد شکل‌ها و وجود تصاویر بزرگ، افکت‌ها، انیمیشن‌ها یا چندرسانه‌ای‌ها را به‌عنوان سیگنال‌های فیلترسازی استفاده کنید و قبل از تصمیم‌گیری نهایی یک رندر یا خروجی نمونه‌ای را اندازه‌گیری کنید.