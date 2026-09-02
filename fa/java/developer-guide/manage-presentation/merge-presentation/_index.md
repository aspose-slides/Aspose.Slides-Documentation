---
title: ادغام کارآمد ارائه‌ها در جاوا
linktitle: ادغام ارائه‌ها
type: docs
weight: 40
url: /fa/java/merge-presentation/
keywords:
- ادغام پاورپوینت
- ادغام ارائه‌ها
- ادغام اسلایدها
- ادغام PPT
- ادغام PPTX
- ادغام ODP
- ترکیب پاورپوینت
- ترکیب ارائه‌ها
- ترکیب اسلایدها
- ترکیب PPT
- ترکیب PPTX
- ترکیب ODP
- جاوا
- Aspose.Slides
description: "بیاموزید چگونه در جاوا با کلون کردن اسلایدها، کنترل مسترها و طرح‌بندی‌ها، تغییر اندازه محتویات اسلاید، حفظ بخش‌ها و مدیریت فایل‌های محافظت‌شده یا بزرگ، ارائه‌های PowerPoint و OpenDocument را ادغام کنید."
---
## **بررسی کلی**

Aspose.Slides for Java ارائه‌ها را با کلون کردن اسلایدها از یک [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) به ارائه دیگر ترکیب می‌کند. عملیات اصلی، [ISlideCollection.addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) است که می‌تواند قالب‌بندی اسلاید منبع را حفظ کند یا اسلاید کلون‌شده را به یک مستر یا طرح‌بندی در ارائه مقصد پیوست کند.

این مقاله رایج‌ترین جریان‌های ترکیب را پوشش می‌دهد:

- ترکیب تمام اسلایدها در حالی که قالب‌بندی منبع حفظ می‌شود؛
- ترکیب اسلایدهای انتخابی؛
- اعمال یک مستر از ارائه مقصد؛
- اعمال یک طرح‌بندی خاص از ارائه مقصد؛
- نرمال‌سازی اندازه‌های مختلف اسلاید قبل از ترکیب؛
- افزودن اسلایدهای کلون‌شده به یک بخش؛
- ترکیب چندین ارائه در یک جریان کار انتها‑به‑انتهای واحد؛
- پردازش مسترها، منابع، یادداشت‌ها، نظرات، رسانه‌ها، قلم‌ها، گذرواژه‌ها، فایل‌های بزرگ و ملاحظات چندریشته‌ای.

## **چگونه کلون اسلاید بر مسترها و طرح‌بندی‌ها تاثیر می‌گذارد**

یک اسلاید ظاهر زیادی از طرح‌بندی و مستر خود به ارث می‌برد. به همین دلیل، overloadی که برای کلون انتخاب می‌کنید، نحوه ادغام اسلاید ترکیبی در ارائه مقصد را تعیین می‌کند.

از [ISlideCollection.addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecollection/) به یکی از روش‌های زیر استفاده کنید:

- `addClone(sourceSlide)` — قالب‌بندی و طرح‌بندی اسلاید منبع را حفظ می‌کند. در صورت نیاز، مستر منبع می‌تواند به‌صورت خودکار به ارائه مقصد کلون شود. Aspose.Slides مسترهای کلون‌شده به‌صورت خودکار را ردیابی می‌کند تا اسلایدهای تکراری که از همان مستر منبع استفاده می‌کنند، مستر را بارها کلون نکنند.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — اسلاید کلون‌شده را به یک [IMasterSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslide/) خاص در مقصد پیوست می‌کند. Aspose.Slides برای آن مستر، طرح‌بندی منطبق را بر اساس نوع یا نام طرح‌بندی جستجو می‌کند.
- `addClone(sourceSlide, destinationLayout)` — اسلاید کلون‌شده را مستقیماً به یک [ILayoutSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutslide/) خاص در مقصد پیوست می‌کند.

مستر یا طرح‌بندی‌ای که به overload `addClone` منتقل می‌شود باید متعلق به **ارائه مقصد** باشد، نه ارائه منبع.

## **ترکیب کامل ارائه‌ها و حفظ قالب‌بندی منبع**

ساده‌ترین ترکیب، تمام اسلایدها را از ارائه منبع به ارائه مقصد کپی می‌کند. این گزینه زمانی مناسب است که اسلایدهای وارد شده باید تم، مستر و ارتباطات طرح‌بندی اصلی خود را حفظ کنند.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

ارائه حاصل ممکن است چندین مستر داشته باشد هنگامی که منبع و مقصد از طرح‌های متفاوتی استفاده می‌کنند. این رفتار طبیعی است هنگامی که قالب‌بندی منبع عمداً حفظ می‌شود.

## **ترکیب اسلایدهای انتخابی**

لازم نیست هر اسلایدی را کلون کنید. مثال زیر فقط ایندکس‌های اسلایدهای انتخابی را از ارائه منبع وارد می‌کند.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    int[] slideIndexes = { 0, 2, 4 };

    for (int index : slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

قبل از کلون کردن، ایندکس‌های اسلاید را زمانی که از ورودی کاربر یا پیکربندی خارجی می‌آیند، اعتبارسنجی کنید.

## **ترکیب اسلایدها با استفاده از مستر مقصد**

زمانی که اسلایدهای وارد شده باید از مستری که قبلاً به ارائه مقصد تعلق دارد پیروی کنند، overload [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) را استفاده کنید.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    IMasterSlide destinationMaster = destination.getMasters().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides یک طرح‌بندی مناسب زیر مستر مشخص‌شده را بر پایه تطبیق نوع یا نام طرح‌بندی منبع انتخاب می‌کند. اگر طرح‌بندی مناسب وجود نداشته باشد و `allowCloneMissingLayout` برابر `true` باشد، طرح‌بندی منبع کلون می‌شود تا اسلاید اضافه شود. اگر `false` باشد، یک [PptxEditException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pptxeditexception/) پرتاب می‌شود.

هنگامی که می‌خواهید ترکیب به‌جای افزودن یک طرح‌بندی جدید به مستر مقصد، شکست بخورد، مقدار `false` را استفاده کنید.

## **ترکیب اسلایدها با استفاده از یک طرح‌بندی خاص مقصد**

وقتی دقیقاً می‌دانید که اسلایدهای وارد شده باید از کدام طرح‌بندی مقصد استفاده کنند، overload [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) را به‌کار ببرید.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ILayoutSlide destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

استفاده از یک طرح‌بندی مقصد رابطه طرح‌بندی ارث‌بری را تغییر می‌دهد؛ محتویات اسلاید منبع بازطراحی نمی‌شود. اگر طرح‌بندی‌های منبع و مقصد ساختارهای جایگزین متفاوتی داشته باشند، نتیجه را بررسی کنید تا اطمینان حاصل شود که قالب‌بندی ارث‌بری و رفتار جایگزین‌ها مناسب است.

## **ترکیب ارائه‌ها با اندازه‌های متفاوت اسلاید**

ارائه‌هایی با ابعاد اسلاید متفاوت می‌توانند ترکیب شوند، اما کلون یک اسلاید به ارائه‌ای با اندازه اسلاید دیگر به‌طور خودکار محتویات را برای بوم جدید بازطراحی نمی‌کند. بنابراین اشکال ممکن است جابه‌جا، مقیاس‌گذاری نادرست یا خارج از ناحیه قابل مشاهده اسلاید ظاهر شوند.

یک راه‌حل عملی، تغییر اندازه ارائه منبع قبل از کلون است. متد [SlideSize.setSize](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slidesize/#setSize-float-float-int-) می‌تواند محتویات موجود را در حین تغییر ابعاد اسلاید مقیاس‌بندی کند. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slidesizescaletype/) محتویات را برای اندازهٔ درخواست‌شده منطبق می‌کند.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    Dimension2D sourceSize = source.getSlideSize().getSize();
    Dimension2D destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            (float) destinationSize.getWidth(), 
            (float) destinationSize.getHeight(), 
            SlideSizeScaleType.EnsureFit);
    }

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

تغییر اندازه شیء ارائه منبع را در حافظه تغییر می‌دهد. اگر به ارائهٔ منبع اصلی به‌صورت دست‌نخورده برای عملیات دیگر نیاز دارید، یک نمونهٔ جداگانه برای ترکیب باز کنید.

## **ترکیب اسلایدها در یک بخش ارائه**

حلقهٔ پایهٔ کلون اسلاید بخش‌های سلسله‌مراتبی ارائهٔ منبع را بازتولید نمی‌کند. اگر بخش‌ها در خروجی مهم هستند، در ارائه مقصد بخش‌ها را ایجاد یا انتخاب کنید و اسلایدها را به‌صورت صریح با [addClone(ISlide, ISection)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) به آن‌ها کلون کنید.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ISection importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, importedSection);
    }

    destination.save("merged-with-section.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

اسلایدهای کلون‌شده به بخش مقصد مشخص‌شده اضافه می‌شوند. برای حفظ چندین بخش منبع، [Presentation.getSections](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getSections--) را پیمایش کنید، اسلایدهای جاری هر بخش منبع را با [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isection/#getSlidesListOfSection--) دریافت کنید، بخش‌ها را در مقصد بازسازی کنید و هر اسلاید بازگردانده‌شده را به بخش مقصد متناظر کلون کنید. برای مثال کامل پیاده‌سازی بخش‌ها، به [Manage Slide Sections](/slides/fa/java/slide-section/) مراجعه کنید؛ شامل بخش‌های خالی و تغییرات ساختاری می‌شود.

## **ترکیب چندین ارائه به‌صورت ایمن**

مثال انتها‑به‑انتهای زیر، اولین ارائه را به‌عنوان مقصد استفاده می‌کند، اندازهٔ اسلاید هر منبع اضافه را نرمال می‌کند، هر منبع را تنها در زمان کپی باز نگه می‌دارد و در نهایت فایل نهایی را ذخیره می‌کند.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    Dimension2D mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            Dimension2D sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    (float) mergedSize.getWidth(), 
                    (float) mergedSize.getHeight(), 
                    SlideSizeScaleType.EnsureFit);
            }

            for (ISlide slide : source.getSlides()) {
                merged.getSlides().addClone(slide);
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

این یک پایهٔ مفید برای حفظ قالب‌بندی منبع اسلایدهای وارد شده است. اگر خروجی شما باید از یک تم واحد در مقصد استفاده کند، فراخوانی سادهٔ `addClone(slide)` را با overload مناسب مستر یا طرح‌بندی مقصد که پیش‌تر نشان داده شد، جایگزین کنید.

## **ملاحظات عملی**

### **مسترها، طرح‌بندی‌ها و صحت قالب‌بندی**

کلون اسلاید پیش‌فرض می‌تواند مستر مورد نیاز منبع را به‌صورت خودکار به ارائه مقصد بیاورد. Aspose.Slides یک رجیستری داخلی برای مسترهای کلون‌شده خودکار نگهداری می‌کند تا از کلون مکرر همان مستر جلوگیری شود. مسترهای کلون‌شده دستی توسط آن رجیستری ردیابی نمی‌شوند، بنابراین از پیش‌کلون کردن مسترها اجتناب کنید مگر اینکه کنترل صریحی بر ساختار مستر بخواهید.

فرض نکنید دو مستر یا طرح‌بندی با همان نام بصری یکسان هستند. اگر یک قالب سازمانی باید ظاهر نهایی را کنترل کند، مستر یا طرح‌بندی مقصد را صریحاً انتخاب کنید و پس از ترکیب نتیجه را تأیید کنید.

### **یادداشت‌ها و نظرات**

یادداشت‌های گوینده و نظرات اسلاید به‌صورت اتوماتیک با محتویات اسلاید همراه هستند و هنگام کلون اسلاید کپی می‌شوند. Aspose.Slides همچنین APIهای اختصاصی برای [presentation notes](/slides/fa/java/presentation-notes/) و [presentation comments](/slides/fa/java/presentation-comments/) ارائه می‌دهد.

اگر قالب‌بندی صفحهٔ یادداشت‌ها مهم است، ارائه ترکیبی را بررسی کنید چون مسترهای یادداشت در سطح ارائه هستند و ممکن است بین فایل‌های منبع متفاوت باشند. برای گردش‌های بازبینی، نویسندگان نظرات و نظرات زنجیره‌ای را پس از ترکیب فایل‌ها از نویسندگان یا قالب‌های مختلف نیز بررسی کنید.

### **تصاویر، صدا، ویدئو، اشیاء OLE و لینک‌های خارجی**

اسلایدها می‌توانند به منابع سطح ارائه مانند تصاویر، صوت جاسازی‌شده، ویدئو جاسازی‌شده و داده‌های OLE ارجاع دهند. به جای کپی فقط اشکال قابل‌مشاهده، اسلاید را کلون کنید تا Aspose.Slides بتواند روابط اسلاید با منابعش را حفظ کند.

منابع جاسازی‌شده و لینک‌شده باید به‌طور متفاوتی مدیریت شوند. یک صدا، ویدئو، شیء OLE یا پیوندهای خارجی لینک‌شده همچنان به هدف خارجی خود وابسته‌اند؛ کلون یک اسلاید یک لینک خارجی را به محتویات جاسازی‌شده تبدیل نمی‌کند. مسیرها و URLهای منابع لینک‌شده را در محیطی که ارائه ترکیبی باز می‌شود، آزمایش کنید.

Aspose.Slides به‌صورت صریح مسترهای کلون‌شده خودکار را ردیابی می‌کند، اما این به‌معنای تضمین کلی برای حذف تکراری منابع باینری یکسان از ارائه‌های نامرتبط نیست. اگر حجم فایل خروجی مهم است، بسته ترکیبی را بررسی کنید و نتیجه را اندازه‌گیری کنید به‌جای تکیه بر حذف تکراری ضمنی.

### **قلم‌های جاسازی‌شده و دسترسی به قلم‌ها**

قلم‌ها در سطح ارائه مدیریت می‌شوند. اگر نوشتار باید بین ماشین‌ها یکسان باشد، فرض نکنید که تنها کلون اسلایدها تضمین می‌کند همه قلم‌های مورد نیاز در محیط مقصد موجود هستند. می‌توانید قلم‌های جاسازی‌شده را با [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) بررسی کنید و همان‌طور که در [Embed Fonts in Presentations](/slides/fa/java/embedded-font/) توضیح داده شده، جاسازی را صریحاً مدیریت کنید.

همچنین اطمینان حاصل کنید که اجازهٔ جاسازی قلم‌های مورد استفاده در فایل‌های منبع را دارید. مجوزهای قلم ممکن است جاسازی را محدود کنند.

### **ارائه‌های حفاظت‌شده با گذرواژه**

یک منبع حفاظت‌شده با گذرواژه باید پیش از کلون اسلایدها با موفقیت باز شود. گذرواژه را از طریق [LoadOptions.setPassword](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) ارائه دهید.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // با ارائهٔ رمزگشایی‌شده کار کنید.
} finally {
    source.dispose();
}
```

باز کردن یک منبع رمزنگاری‌شده به‌صورت خودکار همان حفاظت را به ارائهٔ مقصد اعمال نمی‌کند. در صورت نیاز، حفاظت خروجی را به‌صورت جداگانه پیکربندی کنید.

### **ارائه‌های بزرگ و مصرف حافظه**

ارائه‌های بزرگ حاوی تصاویر با وضوح بالا، صدا، ویدئو یا اشیاء باینری بزرگ می‌توانند حافظهٔ قابل‌ملاحظه‌ای مصرف کنند. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) کنترل‌هایی برای مدیریت BLOB و استفاده از فایل‌های موقت فراهم می‌کند. برای استراتژی‌های فایل‌های بزرگ به [Manage Presentation BLOBs](/slides/fa/java/manage-blob/) مراجعه کنید.

برای فایل‌های بزرگ، در صورت امکان از مسیرهای فایل برای بارگذاری استفاده کنید، هر ارائهٔ منبع را به‌محض ترکیب، آزاد کنید و از ذخیره‌سازی مکرر نتایج میانی اجتناب کنید مگر اینکه گردش کار نیاز به نقطه‌های بررسی داشته باشد.

### **ایمنی در استفاده از چندریشته**

از بارگذاری، تغییر، ذخیره یا کلون یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) به‌صورت همزمان از چندین ریخته استفاده نکنید. هر نمونهٔ ارائه را به یک عملیات ترکیب محدود کنید. اگر کارهای مستقل را به‌صورت موازی اجرا می‌کنید، از نمونه‌های ارائهٔ مستقل استفاده کنید و راهنمایی‌های چندریشته‌ای Aspose.Slides را دنبال کنید [/slides/fa/java/multithreading/].

## **سوالات متداول**

**چگونه می‌توانم طراحی اصلی هر ارائه منبع را حفظ کنم؟**

بدون ارائهٔ مستر یا طرح‌بندی مقصد، از [addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) استفاده کنید. Aspose.Slides می‌تواند مستر منبع را به‌صورت خودکار کلون کند هنگامی که اسلاید وارد شده به آن نیاز دارد.

**چگونه می‌توانم اسلایدهای وارد شده را باعث استفاده از تم مقصد کنم؟**

overloadی که مستر مقصد را می‌پذیرد استفاده کنید. یک مستر از ارائهٔ مقصد، نه منبع، منتقل کنید. Aspose.Slides سعی می‌کند هر اسلاید منبع را به یک طرح‌بندی مناسب تحت آن مستر نگاشت کند.

**چه زمانی باید به‌جای مستر مقصد، یک طرح‌بندی خاص مقصد را استفاده کنم؟**

زمانی که هر اسلاید وارد شده باید از یک طرح‌بندی مشخص استفاده کند، از طرح‌بندی خاص استفاده کنید. وقتی می‌خواهید Aspose.Slides بین طرح‌بندی‌های مستر بر پایهٔ نوع یا نام طرح‌بندی منبع انتخاب کند، از مستر استفاده کنید.

**آیا می‌توان ارائه‌هایی با اندازه‌های اسلاید متفاوت را ترکیب کرد؟**

بله، اما محتویات اسلاید به‌صورت خودکار برای ابعاد مقصد بازطراحی نمی‌شود. برای قرارگیری پیش‌بینی‌شده، ابتدا منبع را با [SlideSize.setSize](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slidesize/#setSize-float-float-int-) و [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slidesizescaletype/) تغییر اندازه دهید.

**آیا می‌توانم فایل‌های PPT، PPTX و ODP را در یک فایل ترکیب کنم؟**

بله. هر ارائه منبع را بارگذاری کنید، اسلایدهای مورد نیاز را به یک مقصد کلون کنید و مقصد را در یک فرمت خروجی پشتیبانی‌شده ذخیره کنید. چون فرمت‌های ارائه دقیقاً همان مجموعه ویژگی‌ها را پشتیبانی نمی‌کنند، پس از ترکیب فرمت‌متقاطع محتویات پیچیده را بررسی کنید. به [Supported File Formats](/slides/fa/java/supported-file-formats/) مراجعه کنید.

**آیا بخش‌های منبع به‌صورت خودکار حفظ می‌شوند؟**

نه توسط یک حلقهٔ پایه‌ای که تنها اسلایدها را کلون می‌کند. برای حفظ ساختار بخش‌ها، آن‌ها را در مقصد بازسازی کنید و overload بخش از [addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) را هنگامی که ساختار بخش باید حفظ شود، به‌کار ببرید.

**آیا یادداشت‌های گوینده و نظرات حفظ می‌شوند؟**

آن‌ها همراه با اسلاید کلون‌شده کپی می‌شوند. برای گردش‌کارهایی که به استایل مستر یادداشت‌ها، نویسندگان نظرات یا داده‌های بازبینی زنجیره‌ای وابسته‌اند، نتیجه ترکیبی را بررسی کنید چون این سناریوها شامل ساختارهای سطح ارائه به‌علاوه محتویات سطح اسلاید هستند.

**چه اتفاقی برای صدا، ویدئو، اشیاء OLE و پیوندهای Hyperlink می‌افتد؟**

محتویات جاسازی‌شده به‌عنوان بخشی از روابط منابع اسلاید کلون‌شده منتقل می‌شود. لینک‌های خارجی همچنان خارجی می‌مانند، بنابراین فایل‌ها یا URLهای هدف باید پس از ترکیب در دسترس باشند.

**آیا قلم‌های جاسازی‌شده از هر منبع به‌صورت تضمینی در ارائه ترکیبی موجود خواهند بود؟**

فقط به‌کارگیری کلون اسلاید برای استقرار قلم‌ها کافی نیست. قلم‌های موجود در مقصد را بررسی کنید و هنگام اهمیت تایپوگرافی، جاسازی قلم یا دسترسی به قلم‌های خارجی را صریحاً مدیریت کنید.

**چگونه می‌توانم یک فایل حفاظت‌شده با گذرواژه را ترکیب کنم؟**

آن را با [LoadOptions.setPassword](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) صحیح باز کنید، سپس اسلایدهای آن را به‌صورت معمول کلون کنید. حفاظت خروجی به‌صورت جداگانه پیکربندی می‌شود.

**چگونه باید با ارائه‌های بسیار بزرگ برخورد کنم؟**

از مدیریت BLOB هنگامیکه اشیاء باینری بزرگ حافظه را اشغال می‌کنند استفاده کنید، برای فایل‌های بسیار بزرگ بارگذاری از مسیرهای فایل را ترجیح دهید، به‌محض ترکیب هر ارائه منبع را آزاد کنید و نتیجه نهایی را فقط در زمان نیاز ذخیره کنید.

**آیا می‌توانم اسلایدها را از چندین ریخته ترکیب کنم؟**

از یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) به‌صورت همزمان در چندین ریخته استفاده نکنید. هر عملیات ترکیب را به نمونه‌های ارائهٔ مستقل محدود کنید.