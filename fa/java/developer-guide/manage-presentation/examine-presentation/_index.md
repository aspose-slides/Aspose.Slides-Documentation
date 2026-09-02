---
title: بازیابی و به‌روزرسانی اطلاعات ارائه در جاوا
linktitle: اطلاعات ارائه
type: docs
weight: 30
url: /fa/java/examine-presentation/
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
- جاوا
- Aspose.Slides
description: "اسلایدها، ساختار و متادیتا را در ارائه‌های PowerPoint و OpenDocument با استفاده از جاوا بررسی کنید تا بینش‌های سریع‌تر و ارزیابی محتوای هوشمندتر حاصل شود."
---
## **بررسی کلی**

Aspose.Slides می‌تواند فرمت یک ارائه را شناسایی کرده و متادیتای سند آن را بدون ایجاد یک مدل شیء کامل ارائه بخواند. این زمانی مفید است که نیاز به دسته‌بندی فایل‌ها، ساخت یک موجودی یا بررسی ویژگی‌ها قبل از تصمیم‌گیری درباره بارگذاری و پردازش محتوای ارائه داشته باشید.

این مقاله بازرسی سبک وزن را از طریق [PresentationFactory](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentationfactory/) و [IPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/) نشان می‌دهد و همچنین به‌روزرسانی‌های هدفمند را از طریق [IDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties/) ارائه می‌کند.

## **بررسی فرمت یک ارائه**

از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) برای بازرسی یک فایل بدون ایجاد یک نمونه [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) استفاده کنید. متد [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) فرمت شناسایی‌شده را گزارش می‌دهد، مانند PPTX، PPT یا ODP.

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

## **ساخت موجودی سبک وزن برای ارائه**

هنگام پردازش تعداد زیادی فایل ارائه، ممکن است به یک موجودی فشرده برای اعتبارسنجی، ایندکس‌سازی یا سیستم مدیریت اسناد نیاز داشته باشید. در این حالت، از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) برای به‌دست آوردن یک شیء [IPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/) استفاده کنید و سپس متد [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) را فراخوانی کنید تا متادیتای سند را بخوانید. این رویکرد هیچ نمونه‌ای از [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد نمی‌کند و نیازی به پیمایش کامل مدل شیء ارائه نیست.

ویژگی‌های گسترش‌یافته‌ای که توسط [IDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties/) ارائه می‌شوند، مقادیر موجودی زیر را فراهم می‌کنند:

| متد | مقدار موجودی |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties/#getSlides--) | کل تعداد اسلایدها. |
| [getHiddenSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | تعداد اسلایدهای مخفی. |
| [getNotes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties/#getNotes--) | تعداد اسلایدهایی که حاوی یادداشت هستند. |
| [getParagraphs](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties/#getParagraphs--) | کل تعداد پاراگراف‌ها، در صورت موجود بودن. |
| [getWords](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties/#getWords--) | کل تعداد کلمات. |
| [getMultimediaClips](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | کل تعداد کلیپ‌های صوتی و تصویری. |

مثال زیر این مقادیر را بدون ایجاد یک شیء [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) می‌خواند و موجودی فشرده‌ای چاپ می‌کند. همچنین [getHeadingPairs](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties/#getHeadingPairs--) را با [getTitlesOfParts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) ترکیب می‌کند تا گروه‌های محتوا مانند قلم‌ها، تم‌ها و عناوین اسلاید را نمایش دهد.

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

هر [IHeadingPair](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iheadingpair/) یک نام گروه و تعداد آیتم‌های آن گروه را فراهم می‌کند. متد [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) یک آرایهٔ صاف و مرتب بر می‌گرداند، بنابراین تعداد عناوین متوالی تعیین‌شده توسط هر جفت سرعنوان را مصرف کنید.

### **متادیتای ذخیره‌شده و محدودیت‌های فرمت**

ویژگی‌های موجودی بازگردانده‌شده توسط [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) متادیتایی را منعكس می‌کنند که در سند منبع موجود است. Aspose.Slides مدل شیء ارائه را بارگذاری و پیمایش نمی‌کند تا این مقادیر را برای این فراخوانی دوباره محاسبه کند. ویژگی‌های گمشده با مقادیر پیش‌فرض نشان داده می‌شوند و مقادیر ذخیره‌شده ممکن است منسوخ باشند اگر برنامه‌ای که آخرین بار فایل را ذخیره کرده است، ویژگی‌های سند را به‌روز نکرده باشد.

- **PPTX:** این فرمت ویژگی‌های سند گسترش‌یافته برای شمارش اسلاید، یادداشت، اسلاید مخفی، پاراگراف، کلمه و موارد چندرسانه‌ای، همچنین جفت‌های سرعنوان و عناوین بخش‌ها را فراهم می‌کند. در دسترس بودن آن بستگی به این دارد که کدام ویژگی‌ها توسط تولیدکننده سند نوشته شده‌اند.
- **PPT:** فرمت باینری می‌تواند ویژگی‌های خلاصه سند متناظر را ذخیره کند. اگر ویژگی‌ای غایب باشد یا توسط تولیدکننده سند تازه‌سازی نشده باشد، Aspose.Slides مقدار ذخیره‌شده یا پیش‌فرض آن را بر می‌گرداند نه اینکه از اسلایدها محاسبه کند.
- **ODP:** متادیتای OpenDocument آمار کلی سند مانند تعداد صفحه، پاراگراف و کلمه را ارائه می‌دهد، اما این مقادیر به هر ویژگی گسترش‌یافته خاص PowerPoint نقشه نمی‌شوند. متادیتای اسلاید مخفی، اسلاید یادداشت، چندرسانه‌ای، جفت سرعنوان و عناوین بخش ممکن است در دسترس نباشد و ویژگی‌های موجودی ممکن است مقادیر پیش‌فرض برگردانند. مقدار صفر یا آرایهٔ خالی را به عنوان اثبات قطعی نبودن محتوا در نظر نگیرید.

از روش متادیتای سبک وزن برای موجودی‌ها و بررسی‌های اولیه استفاده کنید. زمانی که نتیجه باید تغییرات حافظهٔ درون‌محیطی را منعکس کند یا نیاز به تأیید محتوای واقعی ارائه دارید، ارائه را بارگذاری کنید و مدل شیء زندهٔ آن را بررسی کنید.

## **به‌روزرسانی ویژگی‌های ارائه**

ویژگی‌های بازگردانده‌شده توسط [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) را می‌توان بدون ایجاد یک نمونه [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) نیز تغییر داد. تغییرات را با [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) اعمال کنید و سپس ارائهٔ متصل را با [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-) بنویسید.

تصویر زیر ویژگی‌های سند اصلی ارائه PowerPoint را نشان می‌دهد.

![ویژگی‌های سند اصلی ارائه PowerPoint](input_properties.png)

مثال زیر عنوان و زمان آخرین ذخیره‌سازی را تغییر می‌دهد و نتیجه را در فایلی جدید می‌نویسد:

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

تصویر زیر ویژگی‌های سند تغییر یافته ارائه PowerPoint را نشان می‌دهد.

![ویژگی‌های سند تغییر یافته ارائه PowerPoint](output_properties.png)

## **لینک‌های مفید**

برای بررسی‌های امنیتی مرتبط و تنظیمات محافظت، مقاله‌های زیر را ببینید:

- [محافظت از ارائه‌ها با رمز عبور](/slides/fa/java/password-protected-presentation/)
- [محافظت از ارائه‌ها در نوشتن](/slides/fa/java/write-protected-presentation/)

## **سوالات متداول**

**چگونه می‌توانم بررسی کنم که آیا فونت‌ها جاسازی شده‌اند و کدام‌ها هستند؟**

ارائه را بارگذاری کنید و از [Presentation.getFontsManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getFontsManager--) استفاده کنید. متد [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) فونت‌های جاسازی‌شده را بر می‌گرداند و [IFontsManager.getFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontsmanager/#getFonts--) فونت‌های مورد استفاده در ارائه را برمی‌گرداند. با مقایسهٔ این دو نتیجه می‌توانید فونت‌های لازم برای رندر که جاسازی نشده‌اند را پیدا کنید.

**چگونه می‌توانم به سرعت تشخیص دهم آیا فایل اسلایدهای مخفی دارد و چقدر؟**

زمانی که متادیتای ذخیره‌شدهٔ سند کافی باشد، [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) را از طریق [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) و [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) بخوانید. این برای موجودی سبک وزن مناسب است. اگر ارائه در حافظهٔ اجرا تغییر کرده باشد یا نیاز به صحت‌سنجی مقادیر زنده داشته باشید، به‌جای آن از [Presentation.getSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getSlides--) عبور کنید و برای هر اسلاید متد [ISlide.getHidden](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/#getHidden--) را بررسی کنید.

**آیا می‌توانم تشخیص دهم آیا اندازه و جهت سفارشی اسلاید استفاده شده است و آیا با پیش‌فرض‌ها متفاوت است؟**

بله. ارائه را بارگذاری کنید و متد [Presentation.getSlideSize](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getSlideSize--) را فراخوانی کنید. از [ISlideSize.getType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidesize/#getType--)، [ISlideSize.getSize](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidesize/#getSize--) و [ISlideSize.getOrientation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidesize/#getOrientation--) برای مقایسهٔ تنظیمات فعلی با پیش‌فرض‌های از پیش تعیین‌شده و ابعاد استفاده کنید.

**آیا روش سریعی برای مشاهده اینکه آیا نمودارها به منابع داده خارجی ارجاع می‌دهند وجود دارد؟**

بله. هر [Chart](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chart/) را پیدا کنید و متد [IChartData.getDataSourceType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdata/#getDataSourceType--) را صدا بزنید. برای یک کتاب‌کار خارجی، متد [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) را فراخوانی کنید. نوع منبع داده و مسیر یک ارجاع خارجی را شناسایی می‌کنند، اما بررسی موجودیت هدف نیاز به بررسی منبع جداگانه دارد.

**چگونه می‌توانم اسلایدهای «سنگین» که ممکن است رندر یا خروجی PDF را کند کنند ارزیابی کنم؟**

هیچ ویژگی تک‌نخی برای پیچیدگی وجود ندارد. از [Presentation.getSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getSlides--) و مجموعهٔ [IBaseSlide.getShapes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseslide/#getShapes--) برای هر اسلاید عبور کنید. از شمارش اشکال و حضور تصاویر بزرگ، افکت‌ها، انیمیشن‌ها یا چندرسانه‌ای‌ها به عنوان سیگنال‌های غربالگری استفاده کنید و یک رندر یا خروجی نمایشی نمونه‌برداری کنید تا قبل از تعیین اسلاید به‌عنوان گلوگاه عملکردی، آن را تأیید کنید.