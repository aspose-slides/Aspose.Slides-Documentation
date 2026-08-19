---
title: ادغام مؤثر ارائه‌ها در جاوا
linktitle: ادغام ارائه‌ها
type: docs
weight: 40
url: /fa/java/merge-presentation/
keywords:
- ادغام PowerPoint
- ادغام ارائه‌ها
- ادغام اسلایدها
- ادغام PPT
- ادغام PPTX
- ادغام ODP
- ترکیب PowerPoint
- ترکیب ارائه‌ها
- ترکیب اسلایدها
- ترکیب PPT
- ترکیب PPTX
- ترکیب ODP
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه در جاوا ارائه‌های PowerPoint و OpenDocument را با کلون کردن اسلایدها، کنترل مسترها و لِی‌آوت‌ها، تغییر اندازه محتوای اسلاید، حفظ بخش‌ها و مدیریت فایل‌های محافظت‌شده یا بزرگ ادغام کنید."
---
## **نمای کلی**

Aspose.Slides for Java ارائه‌ها را با کلون کردن اسلایدها از یک [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) به دیگری ادغام می‌کند. عملیات اصلی [ISlideCollection.addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) است که می‌تواند قالب‌بندی اسلاید منبع را حفظ کند یا اسلاید کلون‌شده را به یک مستر یا لِی‌آوت در ارائه مقصد پیوست کند.

این مقاله رایج‌ترین جریان‌های ادغام را پوشش می‌دهد:

- ادغام تمام اسلایدها در حالی که قالب‌بندی منبع آن‌ها حفظ می‌شود؛
- ادغام اسلایدهای انتخابی؛
- استفاده از یک مستر از ارائه مقصد؛
- استفاده از یک لِی‌آوت خاص از ارائه مقصد؛
- نرمال‌سازی اندازه‌های مختلف اسلاید قبل از ادغام؛
- افزودن اسلایدهای کلون‌شده به یک بخش؛
- ادغام چندین ارائه در یک جریان کار انتها‑به‑انتها؛
- مدیریت مسترها، منابع، یادداشت‌ها، نظرات، رسانه‌ها، قلم‌ها، رمزهای عبور، فایل‌های بزرگ و مسائل مرتبط با چندنخی‌سازی.

## **چگونه کلون‌ کردن اسلاید بر مسترها و لِی‌آوت‌ها تأثیر می‌گذارد**

یک اسلاید بخش زیادی از ظاهر خود را از لِی‌آوت و مستر خود به ارث می‌برد. به همین دلیل، نسخه‌ی اضافه‌شده (overload) کلون‌ کردن که انتخاب می‌کنید تعیین می‌کند اسلاید ادغام‌شده چگونه در ارائه مقصد یکپارچه می‌شود.

از [ISlideCollection.addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecollection/) در یکی از روش‌های زیر استفاده کنید:

- `addClone(sourceSlide)` — حفظ لِی‌آوت و قالب‌بندی اسلاید منبع. در صورت نیاز، مستر منبع می‌تواند به‌صورت خودکار به ارائه مقصد کلون شود. Aspose.Slides مسترهای کلون‌شده خودکار را ردیابی می‌کند تا اسلایدهای تکراری که از همان مستر منبع استفاده می‌کنند، مستر را بارها کلون نکنند.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — پیوست اسلاید کلون‌شده به یک [IMasterSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslide/) خاص در مقصد. Aspose.Slides به‌دنبال یک لِی‌آوت مطابق زیر مستر بر اساس نوع یا نام لِی‌آوت می‌گردد.
- `addClone(sourceSlide, destinationLayout)` — پیوست مستقیم اسلاید کلون‌شده به یک [ILayoutSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutslide/) خاص در مقصد.

مستر یا لِی‌آوتی که به یک overload از `addClone` پاس داده می‌شود باید متعلق به ارائه **مقصد** باشد، نه ارائه منبع.

## **ادغام تمام ارائه‌ها و حفظ قالب‌بندی منبع**

ساده‌ترین روش ادغام، کپی کردن هر اسلاید از ارائه منبع به ارائه مقصد است. این گزینه زمانی مناسب است که اسلایدهای وارد شده باید تم، مستر و روابط لِی‌آوت اصلی خود را حفظ کنند.

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

ممکن است ارائه حاصل چندین مستر داشته باشد وقتی که منبع و مقصد از طرح‌های متفاوتی استفاده می‌کنند. این رفتار زمانی که قالب‌بندی منبع به‌صورت عمدی حفظ می‌شود، طبیعی است.

## **ادغام اسلایدهای انتخابی**

لازم نیست همه اسلایدها را کلون کنید. مثال زیر تنها اندیس‌های اسلایدهای انتخابی را از ارائه منبع وارد می‌کند.

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

قبل از کلون، اندیس‌های اسلاید را زمانی که از ورودی کاربر یا پیکربندی خارجی می‌آیند، اعتبارسنجی کنید.

## **ادغام اسلایدها با استفاده از مستر مقصد**

از overload [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) استفاده کنید وقتی که اسلایدهای وارد شده باید از یک مستر استفاده کنند که پیشاپیش به ارائه مقصد تعلق دارد.

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

Aspose.Slides یک لِی‌آوت مناسب زیر مستر مشخص شده را بر پایهٔ تطابق نوع یا نام لِی‌آوت منبع انتخاب می‌کند. اگر لِی‌آوت مناسبی وجود نداشته باشد و مقدار `allowCloneMissingLayout` برابر `true` باشد، لِی‌آوت منبع کلون می‌شود تا اسلاید اضافه شود. اگر `false` باشد، یک [PptxEditException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pptxeditexception/) پرتاب می‌شود.

هنگامی که می‌خواهید ادغام با خطا پایان یابد به‌جای افزودن یک لِی‌آوت جدید به مستر مقصد، مقدار `false` را استفاده کنید.

## **ادغام اسلایدها با استفاده از لِی‌آوت خاص مقصد**

وقتی دقیق می‌دانید کدام لِی‌آوت مقصد باید توسط اسلایدهای وارد شده استفاده شود، از overload [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) استفاده کنید.

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

اعمال یک لِی‌آوت مقصد رابطهٔ ارث‌بری لِی‌آوت را تغییر می‌دهد؛ اما محتویات اسلاید منبع را بازطراحی نمی‌کند. اگر لِی‌آوت‌های منبع و مقصد ساختارهای مختلفی برای جای‌گیرها داشته باشند، نتیجه را بررسی کنید تا از مناسب بودن قالب‌بندی وارث شده و رفتار جای‌گیرها اطمینان حاصل کنید.

## **ادغام ارائه‌ها با اندازه‌های اسلاید متفاوت**

امکان ادغام ارائه‌هایی با ابعاد اسلاید متفاوت وجود دارد، اما کلون کردن یک اسلاید به ارائه‌ای با اندازه اسلاید دیگر به‌صورت خودکار محتویات را برای بوم جدید بازطراحی نمی‌کند. بنابراین اشکال ممکن است جابجا، به‌صورت غیرمنتظره‌ای مقیاس‌بندی شوند یا خارج از ناحیه قابل مشاهده اسلاید ظاهر شوند.

یک رویکرد عملی، تغییر اندازهٔ ارائه منبع قبل از کلون کردن است. متد [SlideSize.setSize](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slidesize/#setSize-float-float-int-) می‌تواند محتویات موجود را همزمان با تغییر ابعاد اسلاید مقیاس‌بندی کند. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slidesizescaletype/) محتویات را طوری مقیاس می‌کند که در اندازهٔ درخواست‌شده جا بگیرد.

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

تغییر اندازه، شی ارائه منبع را در حافظه تغییر می‌دهد. اگر به ارائه منبع اصلی بدون تغییر برای عملیات دیگر نیاز دارید، برای ادغام یک نمونهٔ جداگانه باز کنید.

## **ادغام اسلایدها در یک بخش از ارائه**

حلقهٔ اساسی کلون‌ کردن اسلایدها سلسله‌مراتب بخش‌های ارائه منبع را بازسازی نمی‌کند. اگر بخش‌ها در خروجی مهم هستند، در ارائه مقصد بخش‌ها را ایجاد یا انتخاب کنید و اسلایدها را به‌صورت صریح با [addClone(ISlide, ISection)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) به آن‌ها کلون کنید.

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

اسلایدهای کلون‌شده به بخش مقصد مشخص شده اضافه می‌شوند. برای حفظ چندین بخش منبع، آن بخش‌ها را در مقصد بازسازی کنید و هر اسلاید منبع را به بخش مقصد متناظر نگاشت کنید.

## **ادغام ایمن چندین ارائه**

مثال انتها‑به‑انتها زیر از اولین ارائه به‌عنوان مقصد استفاده می‌کند، اندازه اسلاید هر منبع اضافه را نرمال‌سازی می‌کند، هر منبع را تنها در حین کپی شدن باز می‌گذارد و در نهایت یک‌بار فایل نهایی را ذخیره می‌کند.

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

این یک پایه مفید برای حفظ قالب‌بندی منبع اسلایدهای وارد شده است. اگر خروجی شما باید از یک تم واحد مقصد استفاده کند، فراخوانی سادهٔ `addClone(slide)` را با overload مناسب مستر یا لِی‌آوت مقصد که پیشتر نشان داده شد، جایگزین کنید.

## **ملاحظات عملی**

### **مسترها، لِی‌آوت‌ها و صحت قالب‌بندی**

کلون‌ کردن پیش‌فرض اسلاید می‌تواند مستر مورد نیاز منبع را به‌صورت خودکار به ارائه مقصد بیاورد. Aspose.Slides یک رجیستری داخلی برای مسترهای کلون‌شده خودکار نگهداری می‌کند تا از کلون مکرر یک مستر جلوگیری شود. مسترهای کلون‌شده به‌صورت دستی توسط آن رجیستری ردیابی نمی‌شوند، بنابراین از پیش‑کلون کردن مسترها خودداری کنید مگر اینکه کنترل صریح بر ساختار مستر نیاز داشته باشید.

فرض نکنید که دو مستر یا لِی‌آوت با نام یکسان از نظر بصری معادل هستند. اگر یک قالب سازمانی باید ظاهر نهایی را کنترل کند، مستر یا لِی‌آوت مقصد را به‌صورت صریح انتخاب کنید و پس از ادغام نتیجه را بررسی کنید.

### **یادداشت‌ها و نظرات**

یادداشت‌های گوینده و نظرات اسلاید با محتوای اسلاید مرتبط هستند و هنگام کلون یک اسلاید کپی می‌شوند. Aspose.Slides همچنین APIهای اختصاصی برای [presentation notes](https://docs.aspose.com/slides/fa/java/presentation-notes/) و [presentation comments](https://docs.aspose.com/slides/fa/java/presentation-comments/) فراهم می‌کند.

اگر قالب‌بندی صفحهٔ یادداشت‌ها مهم است، ارائه ادغام‌شده را بررسی کنید زیرا مسترهای یادداشت‌ها شی‌های سطح ارائه هستند و ممکن است بین فایل‌های منبع متفاوت باشند. برای جریان‌های کاری بازبینی، نویسندگان نظرات و نظرات پویا را پس از ترکیب فایل‌ها از نویسندگان یا قالب‌های مختلف نیز بررسی کنید.

### **تصاویر، صدا، ویدئو، اشیاء OLE و لینک‌های خارجی**

اسلایدها می‌توانند به منابع سطح ارائه مانند تصاویر، صداهای توکار، ویدئوهای توکار و داده‌های OLE ارجاع دهند. به‌جای کپی کردن فقط شکل‌های قابل مشاهده، اسلاید را به‌صورت کامل کلون کنید تا Aspose.Slides روابط اسلاید با منابعش را حفظ کند.

منابع توکار و لینک‌شده باید به‌صورت متفاوتی برخورد شوند. یک صوت، ویدئو، شیء OLE یا ابرلینک لینک‌شده همچنان به هدف خارجی خود وابسته است؛ کلون یک اسلاید آن لینک خارجی را به محتوای توکار تبدیل نمی‌کند. مسیرها و URLهای منابع لینک‌شده را در محیطی که ارائه ادغام‌شده باز خواهد شد، تست کنید.

Aspose.Slides به‌صورت صریح مسترهای کلون‌شده خودکار را ردیابی می‌کند، اما این نباید به‌عنوان تضمین کلی برای حذف تکرار منابع باینری یکسان از ارائه‌های منبع نامرتبط تلقی شود. اگر حجم فایل خروجی مهم است، بستهٔ ادغام‌شده را بررسی کنید و نتیجه را اندازه‌گیری کنید به‌جای اتکای به حذف تکرار ضمنی.

### **قلم‌های توکار و در دسترس بودن قلم**

قلم‌ها در سطح ارائه مدیریت می‌شوند. اگر تایپوگرافی باید در همه‌ی ماشین‌ها یکسان باقی بماند، فرض نکنید که فقط کلون کردن اسلایدها تضمین می‌کند هر قلم مورد نیاز در محیط مقصد در دسترس باشد. می‌توانید قلم‌های توکار را با [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) بررسی کنید و همان‌طور که در [Embed Fonts in Presentations](https://docs.aspose.com/slides/fa/java/embedded-font/) توضیح داده شده است، توکارسازی را به‌صورت صریح مدیریت کنید.

همچنین اطمینان حاصل کنید که مجوز توکارسازی قلم‌های استفاده‌شده در فایل‌های منبع را دارید. مجوزهای قلم ممکن است توکارسازی را محدود کنند.

### **ارائه‌های محافظت‌شده با رمز عبور**

یک منبع محافظت‌شده با رمز عبور باید پیش از کلون اسلایدهای آن با موفقیت باز شود. رمز عبور را از طریق [LoadOptions.setPassword](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) ارائه دهید.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // با ارائه رمزگشایی شده کار کنید.
} finally {
    source.dispose();
}
```

باز کردن منبع رمزنگاری‌شده به‌طور خودکار همان حفاظت را به ارائه مقصد اعمال نمی‌کند. در صورت نیاز، حفاظت خروجی را به‌صورت جداگانه پیکربندی کنید.

### **ارائه‌های بزرگ و مصرف حافظه**

ارائه‌های بزرگ که شامل تصویرهای با وضوح بالا، صدا، ویدئو یا سایر اشیاء باینری بزرگ هستند، می‌توانند حافظهٔ قابل‌توجهی مصرف کنند. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) کنترل‌های مربوط به مدیریت BLOB و استفاده از فایل‌های موقت را فراهم می‌کند. برای استراتژی‌های فایل‌های بزرگ، به [Manage Presentation BLOBs](https://docs.aspose.com/slides/fa/java/manage-blob/) مراجعه کنید.

برای فایل‌های بزرگ، در صورت امکان ترجیحاً از مسیرهای فایل برای بارگذاری استفاده کنید، هر ارائه منبع را همان‌زمانی که ادغام شد، آزاد کنید و از ذخیرهٔ مکرر نتایج میانی خودداری کنید مگر اینکه جریان کاری به نقاط بررسی (checkpoint) نیاز داشته باشد.

### **ایمنی در برابر چندنخی**

از بارگذاری، تغییر، ذخیره یا کلون یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) به‌صورت همزمان از چندین نخ خودداری کنید. هر نمونهٔ ارائه را به یک عملیات ادغام محدود کنید. اگر کارهای مستقل را به‌صورت موازی اجرا می‌کنید، از نمونه‌های مستقل استفاده کنید و راهنمایی‌های [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/fa/java/multithreading/) را دنبال کنید.

## **سوالات متداول**

**چگونه می‌توانم طراحی اصلی هر ارائه منبع را حفظ کنم؟**

از [`addClone(sourceSlide)`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) بدون ارائه مستر یا لِی‌آوت مقصد استفاده کنید. Aspose.Slides می‌تواند مستر منبع را به‌صورت خودکار کلون کند هنگامی که اسلاید وارد شده به آن نیاز دارد.

**چگونه می‌توانم اسلایدهای وارد شده را به استفاده از تم مقصد وادار کنم؟**

از overload‌ای استفاده کنید که مستر مقصد را می‌پذیرد. مستری از ارائه مقصد پاس کنید، نه از منبع. Aspose.Slides سعی خواهد کرد هر اسلاید منبع را به یک لِی‌آوت مناسب تحت آن مستر نگاشت کند.

**چه زمانی باید به جای مستر مقصد از لِی‌آوت مقصد خاص استفاده کنم؟**

وقتی هر اسلاید وارد شده باید از یک لِی‌آوت شناخته‌شده استفاده کند، لِی‌آوت مشخصی را استفاده کنید. وقتی می‌خواهید Aspose.Slides بر اساس نوع یا نام لِی‌آوت منبع بین لِی‌آوت‌های آن مستر انتخاب کند، از مستر استفاده کنید.

**آیا می‌توان ارائه‌هایی با اندازه‌های اسلاید متفاوت را ادغام کرد؟**

بله، اما محتویات اسلاید به‌صورت خودکار برای ابعاد مقصد بازطراحی نمی‌شود. هنگامی که به قرارگیری پیش‌بینی‌شده نیاز دارید، ابتدا ارائه منبع را تغییر اندازه دهید؛ برای مثال با استفاده از [SlideSize.setSize](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slidesize/#setSize-float-float-int-) و [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slidesizescaletype/).

**آیا می‌توانم ارائه‌های PPT، PPTX و ODP را در یک فایل ادغام کنم؟**

بله. هر ارائه منبع را بارگذاری کنید، اسلایدهای مورد نیاز را به یک مقصد کلون کنید و مقصد را در قالب خروجی پشتیبانی‌شده ذخیره کنید. چون فرمت‌های ارائه دقیقاً همان مجموعه ویژگی‌ها را پشتیبانی نمی‌کنند، پس از ادغام‌های فرمت‌متقاطع محتوای پیچیده را بررسی کنید. به [Supported File Formats](https://docs.aspose.com/slides/fa/java/supported-file-formats/) مراجعه کنید.

**آیا بخش‌های منبع به‌صورت خودکار حفظ می‌شوند؟**

نه، با یک حلقهٔ ساده که فقط اسلایدها را کلون می‌کند این‌گونه نیست. بخش‌های مورد نیاز را در مقصد بازسازی کنید و زمانی که ساختار بخش باید حفظ شود، از overload بخش‌دار [addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) استفاده کنید.

**آیا یادداشت‌های گوینده و نظرات حفظ می‌شوند؟**

آن‌ها همراه با اسلاید کلون‌شده کپی می‌شوند. برای جریان‌های کاری که به استایل مستر یادداشت‌ها، نویسندگان نظرات یا داده‌های بازبینی سلسله‌وار وابسته‌اند، نتیجهٔ ادغام را بررسی کنید چون این موارد شامل ساختارهای سطح ارائه و محتوای سطح اسلاید می‌شوند.

**چه اتفاقی برای صدا، ویدئو، اشیاء OLE و ابرلینک‌ها می‌افتد؟**

محتوای توکار به‌عنوان بخشی از روابط منابع اسلاید کلون‌شده منتقل می‌شود. لینک‌های خارجی همچنان خارجی باقی می‌مانند، بنابراین فایل‌ها یا URLهای هدف آن‌ها پس از ادغام باید در دسترس باشند.

**آیا قلم‌های توکار هر منبع تضمین می‌شود در ارائه ادغام‌شده در دسترس باشند؟**

به‌تنهایی به کلون اسلاید برای استقرار قلم‌ها تکیه نکنید. قلم‌های توکار مقصد را بررسی کنید و هنگام اهمیت تایپوگرافی، توکارسازی قلم‌ها یا در دسترس بودن قلم‌های خارجی را به‌صورت صریح مدیریت کنید.

**چگونه یک فایل محافظت‌شده با رمز عبور را ادغام کنم؟**

آن را با [LoadOptions.setPassword](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) صحیح باز کنید، سپس اسلایدهای آن را به‌صورت معمولی کلون کنید. حفاظت خروجی به‌صورت جداگانه پیکربندی می‌شود.

**چگونه با ارائه‌های بسیار بزرگ برخورد کنم؟**

هنگامی که اشیاء باینری بزرگ باعث مصرف زیاد حافظه می‌شوند، از مدیریت BLOB استفاده کنید، برای فایل‌های بسیار بزرگ ترجیحاً از بارگذاری مسیر فایل استفاده کنید، ارائه‌های منبع را به‌سرعت آزاد کنید و فقط در زمان نیاز نتیجهٔ نهایی را ذخیره کنید.

**آیا می‌توانم اسلایدها را از چندین نخ ادغام کنم؟**

از یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) به‌صورت همزمان در چندین نخ استفاده نکنید. هر عملیات ادغام را به‌صورت جداگانه در نمونه‌های مستقل ارائه نگه دارید.