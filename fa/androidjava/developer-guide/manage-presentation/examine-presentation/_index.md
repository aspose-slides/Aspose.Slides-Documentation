---
title: دریافت و به‌روزرسانی اطلاعات ارائه در اندروید
linktitle: اطلاعات ارائه
type: docs
weight: 30
url: /fa/androidjava/examine-presentation/
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
- Android
- Java
- Aspose.Slides
description: "اسلایدها، ساختار و متادیتا را در ارائه‌های PowerPoint و OpenDocument با استفاده از Java بررسی کنید تا بینش‌های سریع‌تر و ارزیابی‌های محتوا هوشمندانه‌تری داشته باشید."
---
## **بررسی کلی**

Aspose.Slides می‌تواند قالب ارائه را شناسایی کرده و متادیتای سند آن را بدون ایجاد یک مدل شیء کامل از ارائه بخواند. این کار زمانی مفید است که نیاز به دسته‌بندی فایل‌ها، ساخت یک فهرست یا بررسی ویژگی‌ها قبل از تصمیم‌گیری برای بارگذاری و پردازش محتوای ارائه داشته باشید.

این مقاله با استفاده از [PresentationFactory](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentationfactory/) و [IPresentationInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/) بررسی سبک وزن را نشان می‌دهد و همچنین به‌روزرسانی‌های هدفمند از طریق [IDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties/) را توضیح می‌دهد.

## **بررسی قالب یک ارائه**

از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) برای بازرسی یک فایل بدون ساختن نمونه‌ای از [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) استفاده کنید. متد [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) قالب شناسایی‌شده را گزارش می‌کند؛ به‌عنوان مثال PPTX، PPT یا ODP.

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

## **ساخت یک فهرست سبک وزن از ارائه‌ها**

زمانی که تعداد زیادی از فایل‌های ارائه را پردازش می‌کنید، ممکن است به فهرستی فشرده برای اعتبارسنجی، ایندکس‌گذاری یا یک سیستم مدیریت سند نیاز داشته باشید. در این حالت، از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) برای دریافت یک شیء [IPresentationInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/) استفاده کنید و سپس متد [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) را فراخوانی کنید تا متادیتای سند را بخوانید. این روش نمونه‌ای از [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد نمی‌کند و نیازی به پیمایش کامل مدل شیء ارائه نیست.

ویژگی‌های گسترش‌یافته‌ای که توسط [IDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties/) ارائه می‌شود، مقادیر فهرست زیر را فراهم می‌کند:

| متد | مقدار موجودی |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties/#getSlides--) | تعداد کل اسلایدها. |
| [getHiddenSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | تعداد اسلایدهای پنهان. |
| [getNotes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties/#getNotes--) | تعداد اسلایدهایی که حاوی یادداشت هستند. |
| [getParagraphs](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties/#getParagraphs--) | تعداد کل پاراگراف‌ها (در صورت موجود بودن). |
| [getWords](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties/#getWords--) | تعداد کل کلمات. |
| [getMultimediaClips](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | تعداد کل کلیپ‌های صوتی و تصویری. |

مثال زیر این مقادیر را بدون ایجاد شیء [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) می‌خواند و فهرستی فشرده چاپ می‌کند. همچنین متدهای [getHeadingPairs](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties/#getHeadingPairs--) و [getTitlesOfParts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) را ترکیب کرده تا گروه‌های محتوا مانند قلم‌ها، تم‌ها و عناوین اسلایدها را نمایش دهد.

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

هر [IHeadingPair](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iheadingpair/) نام یک گروه و تعداد آیتم‌های آن گروه را فراهم می‌کند. متد [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) یک آرایهٔ مسطح و ترتیب‌دار برمی‌گرداند، بنابراین تعداد عناوین متوالی مشخص‌شده توسط هر جفت سرعنوان را مصرف کنید.

### **متادیتای ذخیره‌شده و محدودیت‌های قالب**

خواص موجود در فهرست که توسط [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) بازگردانده می‌شود، متادیتای موجود در سند منبع را نشان می‌دهد. Aspose.Slides مدل شیء ارائه را بارگذاری و پیمایش نمی‌کند تا این مقادیر را برای این فراخوانی دوباره محاسبه کند. خواص گمشده با مقادیر پیش‌فرض نشان داده می‌شوند و مقادیر ذخیره‌شده ممکن است منسوخ باشند اگر برنامه‌ای که آخرین بار فایل را ذخیره کرده باشد، ویژگی‌های سند را به‌روز نکرده باشد.

- **PPTX:** این قالب ویژگی‌های گسترش‌یافته سند برای تعداد اسلاید، یادداشت، اسلایدهای پنهان، پاراگراف، کلمه و رسانه‌های چندرسانه‌ای، به‌هم‌راه جفت‌های سرعنوان و عناوین بخش‌ها را فراهم می‌کند. در دسترس بودن این ویژگی‌ها بستگی به این دارد که کدام ویژگی‌ها توسط تولیدکنندهٔ سند نوشته شده‌اند.
- **PPT:** قالب باینری می‌تواند ویژگی‌های خلاصه‌سند متناظر را ذخیره کند. اگر ویژگی‌ای وجود نداشته باشد یا توسط تولیدکنندهٔ سند به‌روز نشده باشد، Aspose.Slides مقدار ذخیره‌شده یا پیش‌فرض را بازمی‌گرداند نه این‌که آن را از اسلایدها محاسبه کند.
- **ODP:** متادیتای OpenDocument آمار کلی سند مثل تعداد صفحات، پاراگراف و کلمات را فراهم می‌کند، اما این مقادیر به تمام ویژگی‌های گسترش‌یافته‌ٔ PowerPoint نگاشت ندارند. متادیتای اسلایدهای پنهان، اسلایدهای یادداشت، چندرسانه‌ای، جفت‌های سرعنوان و عناوین بخش ممکن است در دسترس نباشد و خواص موجودی ممکن است مقادیر پیش‌فرض بازگردانند. صفر یا آرایهٔ خالی را به‌عنوان اثبات قطعی عدم وجود محتوا درنظر نگیرید.

از رویکرد متادیتای سبک وزن برای فهرست‌ها و بررسی‌های اولیه استفاده کنید. وقتی نتایج باید تغییرات در حافظه را بازتاب دهند یا نیاز به تأیید محتوای واقعی ارائه دارید، ارائه را بارگذاری و مدل شیء زندهٔ آن را بازرسی کنید.

## **به‌روزرسانی ویژگی‌های ارائه**

خواص بازگردانده‌شده توسط [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) را می‌توان بدون ایجاد نمونه‌ای از [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) نیز تغییر داد. تغییرات را با [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) اعمال کنید و سپس ارائهٔ بایند شده را با [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-) بنویسید.

تصویر زیر ویژگی‌های سند اصلی ارائهٔ PowerPoint را نشان می‌دهد.

![ویژگی‌های سند اصلی ارائهٔ PowerPoint](input_properties.png)

مثال زیر عنوان و زمان آخرین ذخیره‌سازی را تغییر می‌دهد و نتیجه را در فایل جدیدی می‌نویسد:

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

تصویر زیر ویژگی‌های سند به‌روزشده را نشان می‌دهد.

![ویژگی‌های سند به‌روزشدهٔ ارائهٔ PowerPoint](output_properties.png)

## **پیوندهای مفید**

برای بررسی‌های امنیتی مرتبط و تنظیمات حفاظت، مقالات زیر را ببینید:

- [Password-Protect Presentations](/slides/fa/androidjava/password-protected-presentation/)
- [Write-Protect Presentations](/slides/fa/androidjava/write-protected-presentation/)

## **سوالات متداول**

**چگونه می‌توانم بررسی کنم که آیا قلم‌ها جاسازی شده‌اند و کدام‌ها؟**

ارائه را بارگذاری کنید و از [Presentation.getFontsManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getFontsManager--) استفاده کنید. برای دریافت قلم‌های جاسازی‌شده متد [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) و برای دریافت قلم‌های مورد استفاده در ارائه متد [IFontsManager.getFonts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) را فراخوانی کنید. دو نتیجه را مقایسه کنید تا قلم‌های مورد نیاز برای رندرینگ اما غیرجاسازی‌شده را پیدا کنید.

**چگونه می‌توانم به‌سرعت تشخیص دهم فایل اسلایدهای مخفی دارد و تعداد آن‌ها چیست؟**

زمانی که متادیتای ذخیره‌شدهٔ سند کافی باشد، از [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) از طریق [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) و [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) بخوانید. این روش برای فهرست سبک وزن مناسب است. اگر ارائه در حافظه تغییر کرده باشد یا نیاز به تأیید مقادیر زنده داشته باشید، باید از طریق [Presentation.getSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getSlides--) پیمایش کنید و برای هر اسلاید متد [ISlide.getHidden](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/#getHidden--) را بررسی کنید.

**آیا می‌توانم تشخیص دهم که اندازهٔ سفارشی اسلاید و جهت آن استفاده شده‌اند و آیا از پیش‌فرض‌ها متفاوت هستند؟**

بله. ارائه را بارگذاری کنید و متد [Presentation.getSlideSize](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getSlideSize--) را فراخوانی کنید. با استفاده از [ISlideSize.getType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidesize/#getType--)، [ISlideSize.getSize](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidesize/#getSize--) و [ISlideSize.getOrientation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidesize/#getOrientation--) تنظیمات فعلی را با پیش‌فرض‌ها و ابعاد مورد انتظار مقایسه کنید.

**آیا راه سریعی برای مشاهده این‌که نمودارها به منابع داده خارجی ارجاع می‌دهند وجود دارد؟**

بله. هر [Chart](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chart/) را پیدا کنید و متد [IChartData.getDataSourceType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--) را فراخوانی کنید. برای یک کتاب‌کار خارجی، متد [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) را صدا بزنید. نوع منبع داده و مسیر، ارجاع خارجی را شناسایی می‌کند، اما تأیید موجود بودن هدف نیاز به بررسی منابع جداگانه دارد.

**چگونه می‌توانم «اسلایدهای سنگین» را که ممکن است رندر یا خروجی PDF را کند کنند شناسایی کنم؟**

هیچ خاصیت تک‌واحدی برای پیچیدگی وجود ندارد. با پیمایش [Presentation.getSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getSlides--) و مجموعهٔ [IBaseSlide.getShapes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseslide/#getShapes--) هر اسلاید، شمارش اشکال و حضور تصاویر بزرگ، افکت‌ها، انیمیشن‌ها یا رسانه‌های چندرسانه‌ای را به‌عنوان علائم فیلتر استفاده کنید و پیش از قضاوت نهایی یک رندر یا خروجی نمونه‌ای را اندازه‌گیری کنید.