---
title: ادغام مؤثر ارائه‌ها در اندروید
linktitle: ادغام ارائه‌ها
type: docs
weight: 40
url: /fa/androidjava/merge-presentation/
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
- اندروید
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه در اندروید ارائه‌های PowerPoint و OpenDocument را با کپی اسلایدها، کنترل masterها و layoutها، تغییر اندازه محتوای اسلاید، حفظ بخش‌ها و مدیریت فایل‌های محافظت‌شده یا بزرگ ادغام کنید."
---
## **بررسی کلی**

Aspose.Slides for Android via Java ارائه‌ها را با کپی کردن اسلایدها از یک [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) به ارائه دیگر ادغام می‌کند. عمل اصلی [ISlideCollection.addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) است که می‌تواند قالب‌بندی اسلاید منبع را حفظ کند یا اسلاید کپی‑شده را به یک master یا layout در ارائه مقصد متصل کند.

این مقاله رایج‌ترین جریان‌های ادغام را پوشش می‌دهد:

- ادغام همه اسلایدها در حالی که قالب‌بندی منبع آن‌ها حفظ می‌شود؛
- ادغام اسلایدهای انتخابی؛
- اعمال master از ارائه مقصد؛
- اعمال یک layout خاص از ارائه مقصد؛
- نرمال‌سازی اندازه‌های مختلف اسلاید پیش از ادغام؛
- افزودن اسلایدهای کپی‌شده به یک بخش؛
- ادغام چندین ارائه در یک جریان کار انتها‑به‑انتها؛
- مدیریت masterها، منابع، یادداشت‌ها، نظرات، رسانه‌ها، قلم‌ها، رمزهای عبور، فایل‌های بزرگ و مسائل مربوط به چندنخی.

## **چگونگی تأثیر کپی اسلاید بر Masterها و Layoutها**

یک اسلاید ظاهر بسیاری از ویژگی‌های خود را از layout و master ارث می‌برد. بنابراین، overloadی که برای کپی انتخاب می‌کنید، تعیین می‌کند اسلاید ادغام‌شده چگونه در ارائه مقصد یکپارچه می‌شود.

از [ISlideCollection.addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidecollection/) به یکی از روش‌های زیر استفاده کنید:

- `addClone(sourceSlide)` — قالب‌بندی و layout اسلاید منبع را حفظ می‌کند. در صورت لزوم، master منبع می‌تواند به‌صورت خودکار به ارائه مقصد کپی شود. Aspose.Slides به‌صورت خودکار masterهای کپی‌شده را ردیابی می‌کند تا اسلایدهای تکراری که از همان master منبع استفاده می‌کنند، باعث کپی مکرر master نشوند.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — اسلاید کپی‌شده را به یک [IMasterSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterslide/) مقصد خاص متصل می‌کند. Aspose.Slides با جستجوی layout مطابق با نوع یا نام زیر آن master، layout مناسب را پیدا می‌کند.
- `addClone(sourceSlide, destinationLayout)` — اسلاید کپی‌شده را مستقیماً به یک [ILayoutSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilayoutslide/) مقصد خاص متصل می‌کند.

master یا layout که به overload `addClone` پاس می‌شود باید متعلق به **ارائه مقصد** باشد، نه ارائه منبع.

## **ادغام کامل ارائه‌ها و حفظ قالب‌بندی منبع**

ساده‌ترین روش ادغام، کپی کردن هر اسلاید از ارائه منبع به ارائه مقصد است. این گزینه زمانی مناسب است که اسلایدهای وارد شده باید تم، master و روابط layout اصلی خود را حفظ کنند.

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

ارائه حاصل ممکن است چندین master داشته باشد وقتی که ارائه منبع و مقصد از طراحی‌های متفاوتی استفاده می‌کنند. این رفتار طبیعی است زیرا قالب‌بندی منبع به‌صورت عمدی حفظ شده است.

## **ادغام اسلایدهای انتخابی**

لازم نیست هر اسلایدی را کپی کنید. مثال زیر فقط ایندکس‌های اسلاید انتخابی را از ارائه منبع وارد می‌کند.

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

قبل از کپی، ایندکس‌های اسلاید را در صورتی که از ورودی کاربر یا پیکربندی خارجی دریافت می‌شوند، اعتبارسنجی کنید.

## **ادغام اسلایدها با استفاده از Master مقصد**

زمانی که اسلایدهای وارد شده باید از masterی استفاده کنند که پیشاپیش در ارائه مقصد وجود دارد، overload `[addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-)` را به‌کار ببرید.

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

Aspose.Slides با مطابقت نوع یا نام layout منبع، layout مناسب را زیر master مشخص‌شده انتخاب می‌کند. اگر layout مناسبی موجود نباشد و `allowCloneMissingLayout` برابر `true` باشد، layout منبع کپی می‌شود تا اسلاید اضافه شود. اگر `false` باشد، یک [PptxEditException](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pptxeditexception/) پرتاب می‌شود.

وقتی می‌خواهید ادغام به‌جای افزودن یک layout جدید به master مقصد شکست بخورد، مقدار `false` را استفاده کنید.

## **ادغام اسلایدها با استفاده از یک Layout مقصد خاص**

وقتی دقیقاً می‌دانید اسلایدهای وارد شده باید از کدام layout مقصد استفاده کنند، overload `[addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-)` را به‌کار ببرید.

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

اعمال layout مقصد رابطه inheritance layout را تغییر می‌دهد؛ محتوای اسلاید منبع بازطراحی نمی‌شود. اگر layoutهای منبع و مقصد ساختار placeholderهای متفاوتی داشته باشند، نتیجه را بررسی کنید تا اطمینان حاصل شود قالب‌بندی و رفتار placeholderها مناسب است.

## **ادغام ارائه‌ها با اندازه اسلایدهای متفاوت**

ارائه‌هایی با ابعاد اسلاید متفاوت می‌توانند ادغام شوند، اما کپی یک اسلاید به ارائه‌ای با اندازه اسلاید دیگر به‌صورت خودکار محتوای آن را برای بوم جدید بازطراحی نمی‌کند. بنابراین اشکال ممکن است جابجا، مقیاس‌دار یا خارج از ناحیه قابل مشاهده اسلاید شوند.

رویکرد عملی این است که پیش از کپی، اندازه ارائه منبع را تغییر دهید. متد [SlideSize.setSize](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) می‌تواند محتوای موجود را در حین تغییر ابعاد اسلاید مقیاس کند. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slidesizescaletype/) محتوا را طوری مقیاس می‌کند که در اندازه درخواست‌شده جا بگیرد.

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

تغییر اندازه، شیء ارائه منبع را در حافظه تغییر می‌دهد. اگر نیاز دارید ارائه منبع اصلی برای عملیات دیگر دست نخورده بماند، یک نمونه جداگانه برای ادغام باز کنید.

## **ادغام اسلایدها به یک بخش از ارائه**

حلقه پایه کپی اسلاید‌ها سلسله‌مراتبی بخش‌های ارائه منبع را بازتولید نمی‌کند. اگر در خروجی به بخش‌ها نیاز دارید، بخش‌ها را در ارائه مقصد ایجاد یا انتخاب کرده و اسلایدها را به‌طور صریح با `[addClone(ISlide, ISection)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-)` به آنها کپی کنید.

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

اسلایدهای کپی‌شده به بخش مقصد مشخص‌شده اضافه می‌شوند. برای حفظ چندین بخش منبع، آن بخش‌ها را در مقصد بازسازی کنید و هر اسلاید منبع را به بخش مقصد متناظر نگاشت کنید.

## **ادغام چندین ارائه به‌صورت ایمن**

مثال انتها‑به‑انتها زیر از اولین ارائه به‌عنوان مقصد استفاده می‌کند، اندازه اسلاید هر منبع اضافه را نرمال می‌کند، هر منبع را تنها در زمانی که در حال کپی است باز نگه می‌دارد و در پایان فایل نهایی را یک‌بار ذخیره می‌کند.

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

این یک پایهٔ مفید برای حفظ قالب‌بندی اسلایدهای وارد شده است. اگر خروجی شما باید از یک تم واحد استفاده کند، فراخوانی ساده `addClone(slide)` را با overload مناسب master یا layout مقصد که پیشتر نشان دادیم، جایگزین کنید.

## **ملاحظات عملی**

### **Masterها، Layoutها و حفظ وفاداری قالب‌بندی**

کپی پیش‌فرض اسلاید می‌تواند master مورد نیاز منبع را به صورت خودکار به ارائه مقصد بیاورد. Aspose.Slides یک رجیستری داخلی برای masterهای کپی‌شده به‌صورت خودکار نگه می‌دارد تا از کپی مکرر یک master جلوگیری کند. masterهای کپی‌شده به‌صورت دستی توسط این رجیستری ردیابی نمی‌شوند، بنابراین از پیش‌کپی masterها صرف‌نظر کنید مگر اینکه کنترل صریحی بر ساختار master بخواهید.

فرض نکنید دو master یا layout با نام یکسان بصورت بصری برابر هستند. اگر یک قالب سازمانی باید ظاهر نهایی را کنترل کند، master یا layout مقصد را صریحاً انتخاب کنید و پس از ادغام نتیجه را تأیید نمایید.

### **یادداشت‌ها و نظرات**

یادداشت‌های سخنران و نظرات اسلاید به محتوی اسلاید مرتبط هستند و هنگام کپی اسلاید کپی می‌شوند. Aspose.Slides همچنین APIهای مخصوص برای [presentation notes](https://docs.aspose.com/slides/fa/androidjava/presentation-notes/) و [presentation comments](https://docs.aspose.com/slides/fa/androidjava/presentation-comments/) ارائه می‌دهد.

اگر قالب‌بندی صفحه یادداشت‌ها مهم است، ارائه ادغام‌شده را بررسی کنید زیرا masterهای یادداشت‌ها در سطح ارائه قرار دارند و ممکن است بین فایل‌های منبع متفاوت باشند. برای گردش کارهای مرور، نویسندگان نظرات و نظرات تو در تو را پس از ترکیب فایل‌ها از نویسندگان یا قالب‌های مختلف نیز بررسی کنید.

### **تصاویر، صدا، ویدئو، اشیای OLE و لینک‌های خارجی**

اسلایدها می‌توانند به منابع سطح ارائه مانند تصاویر، صدا یا ویدئوی جاسازی‌شده و داده‌های OLE ارجاع دهند. به‌جای کپی فقط اشکال قابل مشاهده، کل اسلاید را کپی کنید تا Aspose.Slides بتواند روابط اسلاید با این منابع را حفظ کند.

منابع جاسازی‌شده و لینک‌شده باید به‌صورت متفاوتی رفتار شوند. یک صدا، ویدئو، شیء OLE یا hyperlink لینک‌شده همچنان وابسته به هدف خارجی خود می‌ماند؛ کپی اسلاید یک لینک خارجی را به محتوی جاسازی‌شده تبدیل نمی‌کند. مسیرها و URLهای منابع لینک‌شده را در محیطی که ارائه ادغام‌شده باز خواهد شد، تست کنید.

Aspose.Slides به‌صورت صریح masterهای کپی‌شده به‌صورت خودکار را ردیابی می‌کند، اما این به معنای تضمین کلی برای حذف تکرار منابع باینری مشابه از ارائه‌های نامرتبط نیست. اگر حجم فایل خروجی مهم است، بسته ادغام‌شده را بررسی و اندازهٔ نهایی را اندازه‌گیری کنید به‌جای این‌که به حذف تکرار ضمنی وابسته باشید.

### **قلم‌های جاسازی‌شده و در دسترس بودن فونت‌ها**

قلم‌ها در سطح ارائه مدیریت می‌شوند. اگر نوشتار باید در دستگاه‌های مختلف سازگار باشد، فرض نکنید که فقط کپی اسلایدها تضمین می‌کند همه فونت‌های لازم در محیط مقصد موجود باشند. می‌توانید فونت‌های جاسازی‌شده را با `[FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--)` بررسی کنید و همان‌طور که در [Embed Fonts in Presentations](https://docs.aspose.com/slides/fa/androidjava/embedded-font/) توضیح داده شده است، به‌صورت صریح آن‌ها را مدیریت کنید.

همچنین اطمینان حاصل کنید که مجوزهای لازم برای جاسازی فونت‌های استفاده‌شده در فایل‌های منبع را دارید؛ برخی مجوزهای فونت ممکن است جاسازی را محدود کنند.

### **ارائه‌های حفاظت‌شده با رمز عبور**

منبعی که با رمز عبور محافظت شده است باید قبل از کپی اسلایدها با موفقیت باز شود. رمز عبور را از طریق `[LoadOptions.setPassword](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)` ارائه کنید.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // کار با ارائه رمزگشایی شده.
} finally {
    source.dispose();
}
```

بازکردن منبع رمزگذاری‌شده به‌طور خودکار همان حفاظت را به ارائه مقصد اعمال نمی‌کند. در صورت نیاز حفاظت خروجی را به‌صورت جداگانه پیکربندی کنید.

### **ارائه‌های بزرگ و استفاده از حافظه**

ارائه‌های بزرگ که شامل تصاویر با وضوح بالا، صدا، ویدئو یا اشیای باینری بزرگ هستند می‌توانند حافظه قابل‌توجهی مصرف کنند. `[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--)` گزینه‌هایی برای مدیریت BLOB و استفاده از فایل‌های موقت فراهم می‌کند. برای استراتژی‌های فایل‌های بزرگ به [Manage Presentation BLOBs](https://docs.aspose.com/slides/fa/androidjava/manage-blob/) رجوع کنید.

برای فایل‌های بزرگ، هنگام امکان، بارگذاری از مسیرهای فایل را ترجیح دهید، هر ارائه منبع را به‌محض اتمام ادغام dispose کنید و از ذخیره‌سازی مکرر نتایج میانی خودداری کنید مگر اینکه گردش کار به نقاط بررسی نیاز داشته باشد.

### **امنیت در استفاده از چندنخی**

از بارگذاری، تغییر، ذخیره یا کپی یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) به طور همزمان در چندین نخ خودداری کنید. هر نمونهٔ ارائه را به یک عملیات ادغام محدود کنید. اگر کارهای مستقل را موازی می‌کنید، از نمونه‌های مستقل استفاده کنید و راهنمایی‌های چندنخی Aspose.Slides را در [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/fa/androidjava/multithreading/) دنبال کنید.

## **FAQ**

**چگونه می‌توانم طراحی اصلی هر ارائه منبع را حفظ کنم؟**

از [`addClone(sourceSlide)`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) بدون ارائه master یا layout مقصد استفاده کنید. Aspose.Slides می‌تواند master منبع را به‌صورت خودکار وقتی که اسلاید وارد‌شده به آن نیاز دارد، کپی کند.

**چگونه می‌توانم اسلایدهای وارد شده را به تم مقصد سازگار کنم؟**

overloadی را که master مقصد را می‌پذیرد استفاده کنید. یک master از ارائه مقصد (نه منبع) پاس کنید. Aspose.Slides سعی می‌کند هر اسلاید منبع را به یک layout مناسب تحت آن master مطابقت دهد.

**چه زمانی باید به‌جای master مقصد از یک layout مقصد خاص استفاده کنم؟**

وقتی هر اسلاید وارد شده باید از یک layout شناخته‌شده استفاده کند، از layout خاص استفاده کنید. وقتی می‌خواهید Aspose.Slides بر اساس نوع یا نام layout منبع، بین layoutهای master انتخاب کند، از master استفاده کنید.

**آیا می‌توان ارائه‌هایی با اندازه اسلاید متفاوت را ادغام کرد؟**

بله، اما محتوی اسلایدها به‌صورت خودکار برای ابعاد مقصد بازطراحی نمی‌شوند. برای موقعیت‌یابی قابل پیش‌بینی، پیش از ادغام اندازه ارائه منبع را با استفاده از `[SlideSize.setSize](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-)` و `[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slidesizescaletype/)` تغییر دهید.

**آیا می‌توانم فایل‌های PPT، PPTX و ODP را در یک فایل ادغام کنم؟**

بله. هر ارائه منبع را بارگذاری کنید، اسلایدهای مورد نیاز را به یک مقصد کپی کنید و مقصد را در یک فرمت خروجی پشتیبانی‌شده ذخیره کنید. چون مجموعه ویژگی‌های فرمت‌های ارائه متفاوت است، پس از ادغام‌های فرمت‑متقاطع محتوی پیچیده را بررسی کنید. برای فرمت‌های پشتیبانی‌شده به [Supported File Formats](https://docs.aspose.com/slides/fa/androidjava/supported-file-formats/) مراجعه کنید.

**آیا بخش‌های منبع به‌صورت خودکار حفظ می‌شوند؟**

خیر. یک حلقهٔ ساده که فقط اسلایدها را کپی می‌کند این کار را انجام نمی‌دهد. برای حفظ ساختار بخش‌ها، آن‌ها را در مقصد بازسازی کنید و overload بخش `[addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-)` را به‌کار ببرید.

**آیا یادداشت‌های سخنران و نظرات حفظ می‌شوند؟**

آن‌ها همراه با اسلاید کپی‌شده منتقل می‌شوند. برای گردش کارهایی که به قالب‌بندی master یادداشت‌ها، نویسندگان نظرات یا داده‌های بررسی تو در تو وابسته هستند، نتیجهٔ ادغام را بررسی کنید چون این سناریوها شامل ساختارهای سطح ارائه نیز می‌شوند.

**چه اتفاقی برای صدا، ویدئو، اشیای OLE و لینک‌های فراخوانی می‌افتد؟**

محتویات جاسازی‌شده به‌عنوان بخشی از روابط منبع اسلاید منتقل می‌شوند. لینک‌های خارجی همچنان خارجی می‌مانند، بنابراین فایل‌ها یا URLهای هدف باید پس از ادغام در دسترس باشند.

**آیا می‌توان تضمین کرد که تمام فونت‌های جاسازی‌شده از هر منبع در ارائه ادغام‌شده موجود باشند؟**

به تنها کپی اسلایدها برای توزیع فونت اطمینان نکنید. فونت‌های جاسازی‌شده در مقصد را بررسی کنید و برای اطمینان از در دسترس بودن، یا به‌صورت صریح فونت‌ها را جاسازی کنید یا از دسترسی به فونت‌های خارجی اطمینان حاصل کنید.

**چگونه می‌توانم یک فایل محافظت‌شده با رمز عبور را ادغام کنم؟**

با `[LoadOptions.setPassword](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)` آن را باز کنید، سپس اسلایدهایش را به‌صورت معمول کپی کنید. حفاظت خروجی به‌صورت جداگانه تنظیم می‌شود.

**چگونه باید با ارائه‌های بسیار بزرگ مقابله کنم؟**

از مدیریت BLOB استفاده کنید وقتی که اشیای باینری بزرگ بر استفاده از حافظه تأثیر می‌گذارند، برای فایل‌های بسیار بزرگ بارگذاری از مسیرهای فایل را ترجیح دهید، ارائه‌های منبع را به‌محض اتمام ادغام آزاد کنید و فقط در زمان نیاز نتیجهٔ نهایی را ذخیره کنید.

**آیا می‌توانم اسلایدها را از چندین نخ ادغام کنم؟**

از یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) به‌طور همزمان در چندین نخ استفاده نکنید. هر عملیات ادغام را به نمونه‌های جداگانه‌ای محدود کنید.