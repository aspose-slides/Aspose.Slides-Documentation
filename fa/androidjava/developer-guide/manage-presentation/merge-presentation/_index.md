---
title: ادغام مؤثر ارائه‌ها در اندروید
linktitle: ادغام ارائه‌ها
type: docs
weight: 40
url: /fa/androidjava/merge-presentation/
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
- اندروید
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه ارائه‌های PowerPoint و OpenDocument را در اندروید با کلون‌کردن اسلایدها، کنترل مسترها و طرح‌بندی‌ها، تغییر اندازه محتویات اسلاید، حفظ بخش‌ها و مدیریت فایل‌های محافظت‌شده یا بزرگ ادغام کنید."
---
## **نمای کلی**

Aspose.Slides for Android via Java ارائه‌ها را با کلون‌کردن اسلایدها از یک [ارائه](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) به دیگری ترکیب می‌کند. عملیات اصلی، [ISlideCollection.addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) است که می‌تواند قالب‌بندی اسلاید منبع را حفظ کند یا اسلاید کلون‌شده را به یک مستر یا طرح‌بندی در ارائه مقصد متصل کند.

این مقاله رایج‌ترین جریان‌های ترکیب را پوشش می‌دهد:

- ترکیب تمام اسلایدها در حالی که قالب‌بندی منبع حفظ می‌شود؛
- ترکیب اسلایدهای انتخابی؛
- اعمال یک مستر از ارائه مقصد؛
- اعمال یک طرح‌بندی خاص از ارائه مقصد؛
- نرمال‌سازی اندازه اسلایدهای مختلف قبل از ترکیب؛
- افزودن اسلایدهای کلون‌شده به یک بخش؛
- ترکیب چندین ارائه در یک جریان کاری انتها‑به‑انتها؛
- مدیریت مسترها، منابع، یادداشت‌ها، نظرات، رسانه‌ها، فونت‌ها، رمزهای عبور، فایل‌های بزرگ و ملاحظات چندنخی.

## **چگونه کلون‌کردن اسلاید بر مسترها و طرح‌بندی‌ها تأثیر می‌گذارد**

یک اسلاید ظاهر بسیاری از ویژگی‌های خود را از طرح‌بندی و مستر خود به ارث می‌برد. به همین دلیل، بارگذاری (overload) کلون‌کردنی که انتخاب می‌کنید تعیین می‌کند اسلاید ترکیب‌شده چطور در ارائه مقصد ادغام می‌شود.

از [ISlideCollection.addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidecollection/) به یکی از روش‌های زیر استفاده کنید:

- `addClone(sourceSlide)` — قالب‌بندی و طرح‌بندی اسلاید منبع را حفظ می‌کند. در صورت لزوم، مستر منبع می‌تواند به‌صورت خودکار به ارائه مقصد کلون شود. Aspose.Slides به‌طور خودکار مسترهای کلون‌شده را پیگیری می‌کند تا اسلایدهای تکراری که از همان مستر منبع استفاده می‌کنند، مستر را چندبار کلون نکنند.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — اسلاید کلون‌شده را به یک [IMasterSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterslide/) مقصد خاص متصل می‌کند. Aspose.Slides برای آن مستر، طرح‌بندی منطبق را بر اساس نوع یا نام طرح‌بندی جستجو می‌کند.
- `addClone(sourceSlide, destinationLayout)` — اسلاید کلون‌شده را مستقیماً به یک [ILayoutSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilayoutslide/) مقصد خاص متصل می‌کند.

مستر یا طرح‌بندی‌ای که به یک overload `addClone` پاس می‌شود باید متعلق به **ارائه مقصد** باشد، نه ارائه منبع.

## **ترکیب کل ارائه‌ها و حفظ قالب‌بندی منبع**

ساده‌ترین ترکیب، کپی تمام اسلایدها از ارائه منبع به ارائه مقصد است. این گزینه زمانی مناسب است که اسلایدهای واردشده باید تم، مستر و روابط طرح‌بندی اصلی خود را حفظ کنند.

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

ارائه حاصل ممکن است دارای چندین مستر باشد وقتی که ارائه‌های منبع و مقصد از طرح‌های مختلف استفاده می‌کنند. این وضعیت به‌طور طبیعی زمانی رخ می‌دهد که قالب‌بندی منبع عمداً حفظ می‌شود.

## **ترکیب اسلایدهای انتخابی**

لازم نیست همه اسلایدها را کلون کنید. مثال زیر فقط شاخص‌های اسلاید انتخاب‌شده را از ارائه منبع وارد می‌کند.

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

قبل از کلون‌کردن، شاخص‌های اسلاید را وقتی از ورودی کاربر یا پیکربندی خارجی می‌آیند، اعتبارسنجی کنید.

## **ترکیب اسلایدها با استفاده از یک مستر مقصد**

زمانی که اسلایدهای واردشده باید از یک مستری استفاده کنند که از پیش به ارائه مقصد تعلق دارد، overload `[addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-)` را به کار ببرید.

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

Aspose.Slides یک طرح‌بندی مناسب زیر مستر مشخص‌شده را بر اساس نوع یا نام طرح‌بندی منبع انتخاب می‌کند. اگر طرح‌بندی مناسب وجود نداشته باشد و `allowCloneMissingLayout` برابر `true` باشد، طرح‌بندی منبع کلون می‌شود تا اسلاید قابلیت افزودن داشته باشد. اگر `false` باشد، یک [PptxEditException](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pptxeditexception/) پرتاب می‌شود.

وقتی می‌خواهید ترکیب به جای اضافه کردن طرح‌بندی جدید به مستر مقصد، با خطا مواجه شود، مقدار `false` را استفاده کنید.

## **ترکیب اسلایدها با استفاده از یک طرح‌بندی مقصد خاص**

زمانی که دقیقاً می‌دانید هر اسلاید واردشده باید از کدام طرح‌بندی مقصد استفاده کند، overload `[addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-)` را به کار ببرید.

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

اعمال یک طرح‌بندی مقصد رابطهٔ وراثتی طرح‌بندی را تغییر می‌دهد؛ محتویات اصلی اسلاید بازطراحی نمی‌شود. اگر طرح‌بندی‌های منبع و مقصد ساختار فضاهای نگهدارنده متفاوتی داشته باشند، نتیجه را بررسی کنید تا از صحت قالب‌بندی وراثتی و رفتار فضاهای نگهدارنده اطمینان حاصل کنید.

## **ترکیب ارائه‌ها با اندازه اسلایدهای متفاوت**

می‌توان ارائه‌هایی با ابعاد اسلاید مختلف را ترکیب کرد، اما کلون‌کردن یک اسلاید در ارائه‌ای که اندازه اسلاید متفاوتی دارد، به‌طور خودکار محتوا را برای بوم جدید بازطراحی نمی‌کند. بنابراین شکل‌ها ممکن است جابجا، مقیاس‌بندی یا خارج از ناحیه قابل مشاهده ظاهر شوند.

یک رویکرد عملی این است که قبل از کلون‌کردن، اندازه ارائه منبع را تغییر دهید. متد `[SlideSize.setSize](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-)` می‌تواند محتویات موجود را هنگام تغییر ابعاد اسلاید مقیاس‌بندی کند. `[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slidesizescaletype/)` محتوا را برای متناسب شدن با اندازهٔ درخواست‌شده مقیاس می‌دهد.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    SizeF sourceSize = source.getSlideSize().getSize();
    SizeF destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
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

تغییر اندازه، شیء ارائه منبع را در حافظه تغییر می‌دهد. اگر لازم است ارائهٔ منبع اصلی برای عملیات دیگر دست‌نخورده بماند، یک نمونهٔ جداگانه برای ترکیب باز کنید.

## **ترکیب اسلایدها در یک بخش ارائه**

حلقهٔ پایهٔ کلون‌کردن اسلایدها سلسله‌مراتبی بخش‌های ارائه منبع را بازتولید نمی‌کند. اگر بخش‌ها در خروجی مهم هستند، در ارائه مقصد بخش‌ها را ایجاد یا انتخاب کنید و اسلایدها را به‌صورت صریح با `[addClone(ISlide, ISection)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-)` به آن‌ها کلون کنید.

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

اسلایدهای کلون‌شده به بخش مقصد مشخص‌شده اضافه می‌شوند. برای حفظ چندین بخش منبع، ابتدا `[Presentation.getSections](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getSections--)` را فراخوانی کنید، اسلایدهای هر بخش منبع را با `[ISection.getSlidesListOfSection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--)` دریافت کنید، بخش‌ها را در مقصد بازسازی کنید و هر اسلاید بازگردانده‌شده را به بخش متناظر در مقصد کلون کنید. برای مثال کامل دربارهٔ بازشناسی بخش‌ها، شامل بخش‌های خالی و تغییرات ساختاری، به مستندات [Manage Slide Sections](/slides/fa/androidjava/slide-section/) مراجعه کنید.

## **ترکیب ایمن چندین ارائه**

مثال انتها‑به‑انتها در زیر از اولین ارائه به‌عنوان مقصد استفاده می‌کند، اندازه اسلاید هر منبع اضافی را نرمال می‌کند، هر منبع را فقط در زمان کپی باز نگه می‌دارد و در پایان یک‌بار فایل نهایی را ذخیره می‌کند.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    SizeF mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            SizeF sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
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

این یک پایهٔ مفید برای حفظ قالب‌بندی اسلایدهای واردشده است. اگر خروجی شما باید از یک تم مقصد استفاده کند، فراخوانی سادهٔ `addClone(slide)` را با overload مناسب مستر یا طرح‌بندی مقصد که پیش‌تر نشان داده شد، جایگزین کنید.

## **ملاحظات عملی**

### **مسترها، طرح‌بندی‌ها و دقت قالب‌بندی**

کلون‌کردن پیش‌فرض اسلاید می‌تواند مستر مورد نیاز منبع را به‌صورت خودکار به ارائه مقصد بیاورد. Aspose.Slides یک رجیستری داخلی برای مسترهای کلون‌شده به‌صورت خودکار نگه می‌دارد تا از کلون‌کردن مکرر یک مستر جلوگیری کند. مسترهای کلون‌شده به‌صورت دستی در این رجیستری پیگیری نمی‌شوند، بنابراین از پیش‌کلون‌کردن مسترها، مگر آنکه کنترل صریحی بر ساختار مستر نیاز داشته باشید، خودداری کنید.

فرض نکنید دو مستر یا طرح‌بندی با نام یکسان بصری یکسان هستند. اگر یک قالب سازمانی باید ظاهر نهایی را کنترل کند، یک مستر یا طرح‌بندی مقصد را صراحتاً انتخاب کنید و بعد از ترکیب نتیجه را بررسی نمایید.

### **یادداشت‌ها و نظرات**

یادداشت‌های سخنران و نظرات اسلاید با محتویات اسلاید مرتبط هستند و هنگام کلون‌کردن اسلاید کپی می‌شوند. Aspose.Slides همچنین APIهای اختصاصی برای [یادداشت‌های ارائه](/slides/fa/androidjava/presentation-notes/) و [نظرات ارائه](/slides/fa/androidjava/presentation-comments/) ارائه می‌دهد.

اگر قالب‌بندی صفحهٔ یادداشت‌ها مهم است، ارائه ترکیبی را بررسی کنید چون مسترهای یادداشت در سطح ارائه هستند و ممکن است بین فایل‌های منبع متفاوت باشند. برای جریان‌های بازبینی، نویسندگان نظرات و نگارش‌های زنجیره‌ای را پس از ترکیب فایل‌های مختلف از نویسندگان یا قالب‌های مختلف نیز بررسی کنید.

### **تصاویر، صدا، ویدئو، اشیای OLE و لینک‌های خارجی**

اسلایدها می‌توانند به منابع سطح‌ارائه مانند تصاویر، صداهای جاسازی‌شده، ویدئوهای جاسازی‌شده و داده‌های OLE ارجاع دهند. به‌جای کپی فقط شکل‌های قابل‌مشاهده، کلون اسلاید را انجام دهید تا Aspose.Slides روابط اسلاید با این منابع را حفظ کند.

منابع جاسازی‌شده و لینک‌شده باید به‌طور متفاوتی مدیریت شوند. یک صدا، ویدئو، شیء OLE یا ابرلینک لینک‌شده همچنان وابسته به هدف خارجی خود باقی می‌ماند؛ کلون‌کردن اسلاید یک لینک خارجی را به محتویات جاسازی‌شده تبدیل نمی‌کند. مسیرها و URLهای منابع لینک‌شده را در محیطی که ارائه ترکیبی باز خواهد شد، تست کنید.

Aspose.Slides مسترهای کلون‌شده به‌طور خودکار را پیگیری می‌کند، اما این به معنای تضمین عمومی این نیست که منابع باینری یکسان از ارائه‌های مستقل همیشه حذف تکراری شوند. اگر اندازهٔ فایل خروجی مهم است، بسته ترکیبی را بررسی کرده و نتیجه را اندازه‌گیری کنید به‌جای اتکا به حذف تکراری ضمنی.

### **فونت‌های جاسازی‌شده و در دسترس بودن فونت**

فونت‌ها در سطح ارائه مدیریت می‌شوند. اگر قلم‌نگاری باید در دستگاه‌های مختلف یکسان بماند، فرض نکنید فقط کلون‌کردن اسلایدها تضمین می‌کند تمام فونت‌های مورد نیاز در محیط مقصد در دسترس هستند. می‌توانید فونت‌های جاسازی‌شده را با `[FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--)` بررسی کنید و همان‌گونه که در مستندات [Embed Fonts in Presentations](/slides/fa/androidjava/embedded-font/) توضیح داده شده، به‌صورت صریح آن‌ها را مدیریت کنید.

همچنین اطمینان حاصل کنید که اجازهٔ جاسازی فونت‌های استفاده‌شده در فایل‌های منبع را دارید؛ مجوزهای فونت ممکن است جاسازی را محدود کنند.

### **ارائه‌های دارای رمز عبور**

یک منبع محافظت‌شده با رمز عبور باید پیش از کلون‌کردن اسلایدها با موفقیت باز شود. رمز عبور را از طریق `[LoadOptions.setPassword](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)` فراهم کنید.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // با ارائه رمزگشایی‌شده کار کنید.
} finally {
    source.dispose();
}
```

باز کردن منبع رمزگذاری‌شده به‌طور خودکار همان حفاظت را به ارائه مقصد اعمال نمی‌کند. در صورت نیاز، حفاظت خروجی را جداگانه پیکربندی کنید.

### **ارائه‌های بزرگ و مصرف حافظه**

ارائه‌های بزرگ که شامل تصاویر با وضوح بالا، صدا، ویدئو یا سایر اشیای باینری بزرگ هستند، می‌توانند حافظهٔ قابل‌ملاحظه‌ای مصرف کنند. `[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--)` گزینه‌هایی برای مدیریت BLOB و استفاده از فایل‌های موقت فراهم می‌آورد. برای استراتژی‌های فایل‌های بزرگ، به مستندات [Manage Presentation BLOBs](/slides/fa/androidjava/manage-blob/) مراجعه کنید.

برای فایل‌های بزرگ، تا حد امکان بارگذاری از مسیرهای فایل را ترجیح دهید، هر ارائه منبع را پس از ترکیب بلافاصله آزاد کنید و از ذخیرهٔ مکرر نتایج میانی خودداری کنید مگر اینکه جریان کاری نیاز به نقطه‌های بررسی داشته باشد.

### **ایمنی در چندنخی**

از بارگذاری، تغییر، ذخیره یا کلون‌کردن یک نمونهٔ `[Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/)` به‌صورت همزمان از چندین رشتهٔ (thread) خودداری کنید. هر نمونهٔ ارائه را به یک عملیات ترکیب محدود کنید. اگر کارهای مستقل را به‌صورت موازی اجرا می‌کنید، از نمونه‌های مستقل ارائه استفاده کنید و راهنمایی‌های چندنخی Aspose.Slides را دنبال کنید [/slides/fa/androidjava/multithreading/].

## **سوالات متداول**

**چگونه می‌توانم طراحی اصلی هر ارائهٔ منبع را حفظ کنم؟**

بدون ارائهٔ مستر یا طرح‌بندی مقصد، از `[addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-)` استفاده کنید. Aspose.Slides می‌تواند مستر منبع را به‌صورت خودکار کلون کند وقتی اسلاید واردشده به آن نیاز دارد.

**چگونه می‌توانم اسلایدهای واردشده را به تم مقصد بگیرم؟**

overloadی را که مستر مقصد را می‌پذیرد، استفاده کنید. یک مستر از ارائهٔ مقصد (نه منبع) پاس دهید. Aspose.Slides سعی می‌کند هر اسلاید منبع را به یک طرح‌بندی مناسب تحت آن مستر متصل کند.

**چه زمانی باید به‌جای مستر مقصد، یک طرح‌بندی مقصد خاص استفاده کنم؟**

وقتی هر اسلاید واردشده باید از یک طرح‌بندی شناخته‌شده استفاده کند، از طرح‌بندی خاص استفاده کنید. وقتی می‌خواهید Aspose.Slides بر اساس نوع یا نام طرح‌بندی منبع، بین طرح‌بندی‌های مستر انتخاب کند، از مستر استفاده کنید.

**آیا می‌توان ارائه‌هایی با اندازه اسلاید متفاوت را ترکیب کرد؟**

بله، ولی محتویات اسلاید به‌طور خودکار برای ابعاد مقصد بازطراحی نمی‌شود. برای داشتن جای‌گذاری پیش‌بینی‌شده، پیش از ترکیب، اندازهٔ ارائه منبع را با `[SlideSize.setSize](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-)` و `[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slidesizescaletype/)` تغییر دهید.

**آیا می‌توانم فرمت‌های PPT، PPTX و ODP را در یک فایل ترکیب کنم؟**

بله. هر ارائهٔ منبع را بارگذاری کنید، اسلایدهای موردنیاز را به یک مقصد کلون کنید و مقصد را در فرمت خروجی پشتیبانی‌شده ذخیره کنید. چون فرمت‌های ارائه دقیقاً یک مجموعه ویژگی یکسان ندارند، پس از ترکیب فرمت‌متقاطع محتویات پیچیده را بررسی کنید. برای فهرست فرمت‌های پشتیبانی‌شده به [Supported File Formats](/slides/fa/androidjava/supported-file-formats/) رجوع کنید.

**آیا بخش‌های منبع به‌صورت خودکار حفظ می‌شوند؟**

نه؛ یک حلقهٔ پایه که فقط اسلایدها را کلون می‌کند، بخش‌های منبع را حفظ نمی‌کند. برای حفظ ساختار بخش‌ها، آن‌ها را در مقصد بازسازی کنید و overload بخش از `[addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-)` را استفاده کنید.

**آیا یادداشت‌های سخنران و نظرات حفظ می‌شوند؟**

بله، همراه با اسلاید کلون‌شده کپی می‌شوند. برای جریان‌های کاری که به قالب‌بندی مستر یادداشت، نویسندگان نظرات یا داده‌های بازبینی زنجیره‌ای وابسته‌اند، نتیجه ترکیب را بررسی کنید چون این سناریوها شامل ساختارهای سطح‌ارائه و محتویات سطح‌اسلاید می‌شوند.

**چه اتفاقی برای صدا، ویدئو، اشیای OLE و ابرلینک‌ها می‌افتد؟**

محتویات جاسازی‌شده به‌عنوان بخشی از روابط منبع اسلایدی که کلون شده، منتقل می‌شوند. لینک‌های خارجی همچنان خارجی می‌مانند، بنابراین فایل‌ها یا URLهای هدف باید پس از ترکیب در دسترس بمانند.

**آیا فونت‌های جاسازی‌شده از هر منبع تضمین می‌شود که در ارائه ترکیبی موجود باشند؟**

فقط کلون‌کردن اسلایدها برای استقرار فونت کافی نیست. فونت‌های جاسازی‌شدهٔ مقصد را بررسی کنید و به‌صورت صریح مدیریت فونت یا در دسترس بودن فونت‌های خارجی را انجام دهید زمانی که قلم‌نگاری مهم است.

**چگونه می‌توانم یک فایل دارای رمز عبور را ترکیب کنم؟**

ابتدا آن را با `[LoadOptions.setPassword](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)` صحیح باز کنید، سپس اسلایدهای آن را به‌صورت معمول کلون کنید. حفاظت خروجی به‌صورت جداگانه پیکربندی می‌شود.

**چگونه باید با ارائه‌های بسیار بزرگ برخورد کنم؟**

از مدیریت BLOB استفاده کنید زمانی که اشیای باینری بزرگ بر مصرف حافظه غلبه می‌کنند، بارگذاری از مسیرهای فایل را برای فایل‌های خیلی بزرگ ترجیح دهید، ارائه‌های منبع را به‌سرعت پس از ترکیب آزاد کنید و نتیجهٔ نهایی را فقط زمانی ذخیره کنید که لازم باشد.

**آیا می‌توانم اسلایدها را از چندین رشته ترکیب کنم؟**

از یک نمونهٔ `[Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/)` به‌صورت همزمان در چندین رشته استفاده نکنید. هر عملیات ترکیب را به یک نمونهٔ ارائهٔ مستقل محدود کنید.