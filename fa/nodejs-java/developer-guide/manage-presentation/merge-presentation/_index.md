---
title: ادغام مؤثر ارائه‌ها در جاوااسکریپت
linktitle: ادغام ارائه‌ها
type: docs
weight: 40
url: /fa/nodejs-java/merge-presentation/
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
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "یاد بگیرید چگونه ارائه‌های PowerPoint و OpenDocument را در جاوااسکریپت با تکثیر اسلایدها، کنترل مسترها و طرح‌بندی‌ها، تغییر اندازه محتوای اسلاید، حفظ بخش‌ها و مدیریت فایل‌های محافظت‌شده یا بزرگ ادغام کنید."
---
## **مرور کلی**

Aspose.Slides برای Node.js از طریق Java ارائه‌ها را با تکثیر اسلایدها از یک [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) به دیگری ترکیب می‌کند. عملیات اصلی [SlideCollection.addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) است که می‌تواند قالب‌بندی اسلاید منبع را حفظ کند یا اسلاید تکثیر شده را به یک مستر یا طرح‌بندی در ارائه مقصد پیوست کند.

این مقاله رایج‌ترین جریان‌های کاری ادغام را پوشش می‌دهد:

- ادغام تمام اسلایدها در حالی که قالب‌بندی منبع آن‌ها حفظ می‌شود؛  
- ادغام اسلایدهای انتخابی؛  
- اعمال یک مستر از ارائه مقصد؛  
- اعمال یک طرح‌بندی خاص از ارائه مقصد؛  
- نرمال‌سازی اندازه‌های مختلف اسلاید قبل از ادغام؛  
- افزودن اسلایدهای تکثیر شده به یک بخش؛  
- ادغام چندین ارائه در یک جریان کار انتها به انتها؛  
- مدیریت مسترها، منابع، یادداشت‌ها، نظرات، رسانه‌ها، قلم‌ها، رمزهای عبور، فایل‌های بزرگ و مسائل چندنخی.

## **چگونه تکثیر اسلاید بر مسترها و طرح‌بندی‌ها تأثیر می‌گذارد**

یک اسلاید بخش زیادی از ظاهر خود را از طرح‌بندی و مستر خود به ارث می‌برد. به همین دلیل، نسخه‌ی اضافه‌شده (overload) تکثیر که انتخاب می‌کنید تعیین می‌کند اسلاید ادغام‌شده چگونه در ارائه مقصد یکپارچه می‌شود.

از [SlideCollection.addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidecollection/) به یکی از روش‌های زیر استفاده کنید:

- `addClone(sourceSlide)` — قالب‌بندی و طرح‌بندی اسلاید منبع را حفظ می‌کند. در صورت نیاز، مستر منبع می‌تواند به‌صورت خودکار به ارائه مقصد تکثیر شود. Aspose.Slides مسترهای تکثیر شده به‌صورت خودکار را ردیابی می‌کند تا اسلایدهای مکرری که از همان مستر منبع استفاده می‌کنند، مستر را چندین بار تکثیر نکنند.  
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — اسلاید تکثیر شده را به یک [MasterSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterslide/) خاص در مقصد پیوست می‌کند. Aspose.Slides یک طرح‌بندی مطابقت‌دهنده تحت آن مستر را بر اساس نوع یا نام طرح‌بندی جستجو می‌کند.  
- `addClone(sourceSlide, destinationLayout)` — اسلاید تکثیر شده را مستقیماً به یک [LayoutSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutslide/) خاص در مقصد پیوست می‌کند.

مستر یا طرح‌بندی‌ای که به یک overload از `addClone` ارسال می‌شود باید متعلق به ارائه **مقصد** باشد، نه ارائه منبع.

## **ادغام کل ارائه‌ها و حفظ قالب‌بندی منبع**

ساده‌ترین روش ادغام، کپی کردن هر اسلاید از ارائه منبع به ارائه مقصد است. این گزینه زمانی مناسب است که اسلایدهای وارد شده باید تم، مستر و روابط طرح‌بندی اصلی خود را حفظ کنند.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

ارائه نتیجه ممکن است دارای چندین مستر باشد وقتی که منبع و مقصد از طرح‌های متفاوتی استفاده می‌کنند. این حالت زمانی که قالب‌بندی منبع عمداً حفظ شده باشد، انتظار می‌رود.

## **ادغام اسلایدهای انتخابی**

نیازی به تکثیر تمام اسلایدها ندارید. مثال زیر فقط ایندکس‌های اسلایدهای انتخابی را از ارائه منبع وارد می‌کند.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const slideIndexes = [0, 2, 4];

    for (const index of slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

قبل از تکثیر، ایندکس‌های اسلاید را زمانی که از ورودی کاربر یا پیکربندی خارجی می‌آیند، اعتبارسنجی کنید.

## **ادغام اسلایدها با استفاده از مستر مقصد**

وقتی اسلایدهای وارد شده باید تحت مستری که پیشاپیش به ارائه مقصد تعلق دارد، باشند، از overload [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) استفاده کنید.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationMaster = destination.getMasters().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides یک طرح‌بندی مناسب زیر مستر مشخص را بر اساس تطبیق نوع یا نام طرح‌بندی منبع انتخاب می‌کند. اگر طرح‌بندی مناسبی وجود نداشته باشد و مقدار `allowCloneMissingLayout` برابر `true` باشد، طرح‌بندی منبع تکثیر می‌شود تا اسلاید اضافه شود. اگر `false` باشد، یک [PptxEditException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pptxeditexception/) ایجاد می‌شود.

زمانی که می‌خواهید ادغام شکست بخورد به جای افزودن یک طرح‌بندی جدید به مستر مقصد، مقدار `false` را استفاده کنید.

## **ادغام اسلایدها با استفاده از طرح‌بندی خاص مقصد**

وقتی دقیقاً می‌دانید اسلایدهای وارد شده باید از کدام طرح‌بندی مقصد استفاده کنند، از overload [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) استفاده کنید.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

اعمال یک طرح‌بندی مقصد رابطهٔ وراثتی طرح‌بندی را تغییر می‌دهد؛ اما محتوای اسلاید منبع را بازطراحی نمی‌کند. اگر طرح‌بندی‌های منبع و مقصد ساختارهای جای‌گیر متفاوتی داشته باشند، نتیجه را بررسی کنید تا تأیید کنید قالب‌بندی وراثت‌ یافته و رفتار جای‌گیرها مناسب است.

## **ادغام ارائه‌ها با اندازه‌های اسلاید متفاوت**

ارائه‌هایی با ابعاد اسلاید متفاوت می‌توانند ادغام شوند، اما تکثیر یک اسلاید به ارائه‌ای با اندازه اسلاید دیگر محتوای آن را به‌صورت خودکار برای بوم جدید بازطراحی نمی‌کند. به‌این دلیل اشکال ممکن است جابه‌جا، مقیاس‌دار به‌صورت ناخواسته یا خارج از ناحیهٔ قابل مشاهده اسلاید ظاهر شوند.

یک راهکار عملی این است که قبل از تکثیر، اندازهٔ ارائه منبع را تغییر دهید. متد [SlideSize.setSize](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) می‌تواند محتوای موجود را در حین تغییر ابعاد اسلاید مقیاس‌بندی کند. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidesizescaletype/) محتوا را برای سازگاری با اندازهٔ درخواستی مقیاس می‌دهد.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const sourceSize = source.getSlideSize().getSize();
    const destinationSize = destination.getSlideSize().getSize();
    const sizesDiffer = sourceSize.getWidth() !== destinationSize.getWidth() || 
                        sourceSize.getHeight() !== destinationSize.getHeight();

    if (sizesDiffer) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            aspose.slides.SlideSizeScaleType.EnsureFit);
    }

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged-same-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

تغییر اندازه، شیء ارائه منبع را در حافظه تغییر می‌دهد. اگر به ارائه منبع اصلی برای عملیات دیگر بدون تغییر نیاز دارید، برای ادغام یک نمونهٔ جداگانه باز کنید.

## **ادغام اسلایدها در یک بخش ارائه**

حلقهٔ پایهٔ تکثیر اسلاید، سلسله‌مراتب بخش‌های ارائه منبع را بازسازی نمی‌کند. اگر بخش‌ها در خروجی مهم هستند، در ارائه مقصد بخش‌ها را ایجاد یا انتخاب کنید و اسلایدها را به‌صورت صریح با [addClone(Slide, Section)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-) به آن‌ها تکثیر کنید.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), importedSection);
    }

    destination.save("merged-with-section.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

اسلایدهای تکثیر شده به بخش مقصد مشخص اضافه می‌شوند. برای حفظ چندین بخش منبع، آن بخش‌ها را در مقصد بازسازی کنید و هر اسلاید منبع را به بخش مقصد متناظر نقشه‌بندی کنید.

## **ادغام امن چندین ارائه**

مثال انتها به انتهای زیر از اولین ارائه به‌عنوان مقصد استفاده می‌کند، اندازهٔ اسلاید هر منبع اضافه را نرمال‌سازی می‌کند، هر منبع را تنها در طول زمان کپی کردن باز نگه می‌دارد و در نهایت فایل نهایی را یک بار ذخیره می‌کند.

```javascript
const aspose = require("aspose.slides.via.java");

const inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

const merged = new aspose.slides.Presentation(inputFiles[0]);
try {
    const mergedSize = merged.getSlideSize().getSize();

    for (let fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        const source = new aspose.slides.Presentation(inputFiles[fileIndex]);
        try {
            const sourceSize = source.getSlideSize().getSize();
            const sizesDiffer = sourceSize.getWidth() !== mergedSize.getWidth() || 
                                sourceSize.getHeight() !== mergedSize.getHeight();

            if (sizesDiffer) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    aspose.slides.SlideSizeScaleType.EnsureFit);
            }

            for (let slideIndex = 0; slideIndex < source.getSlides().size(); slideIndex++) {
                merged.getSlides().addClone(source.getSlides().get_Item(slideIndex));
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

این یک پایهٔ مفید برای حفظ قالب‌بندی منبع اسلایدهای وارد شده است. اگر خروجی شما باید از یک تم مقصد واحد استفاده کند، فراخوانی سادهٔ `addClone(sourceSlide)` را با overload مناسب مستر یا طرح‌بندی مقصد که قبلاً نشان داده شد، جایگزین کنید.

## **موارد عملی**

### **مسترها، طرح‌بندی‌ها و صحت قالب‌بندی**

تکثیر پیش‌فرض اسلاید می‌تواند مستر مورد نیاز منبع را به‌صورت خودکار به ارائه مقصد بیاورد. Aspose.Slides یک رجیستری داخلی برای مسترهای تکثیر شده به‌صورت خودکار نگه می‌دارد تا از تکثیر مکرر همان مستر جلوگیری کند. مسترهای تکثیر شده به‌صورت دستی توسط آن رجیستری ردیابی نمی‌شوند، بنابراین از پیش تکثیر مسترها خودداری کنید مگر اینکه کنترل صریحی بر ساختار مستر نیاز داشته باشید.

فرض نکنید دو مستر یا طرح‌بندی با نام یکسان از نظر بصری برابر هستند. اگر یک قالب سازمانی باید ظاهر نهایی را کنترل کند، مستر یا طرح‌بندی مقصد را به‌صورت صریح انتخاب کنید و پس از ادغام نتیجه را تأیید کنید.

### **یادداشت‌ها و نظرات**

یادداشت‌های سخنران و نظرات اسلاید با محتوای اسلاید مرتبط هستند و هنگام تکثیر اسلاید کپی می‌شوند. Aspose.Slides همچنین API‌های اختصاصی برای [presentation notes](https://docs.aspose.com/slides/fa/nodejs-java/presentation-notes/) و [presentation comments](https://docs.aspose.com/slides/fa/nodejs-java/presentation-comments/) فراهم می‌کند.

اگر قالب‌بندی صفحهٔ یادداشت‌ها مهم است، ارائه ادغام‌شده را بررسی کنید چون مسترهای یادداشت در سطح ارائه هستند و ممکن است بین فایل‌های منبع متفاوت باشند. برای جریان‌های کاری مرور، نویسندگان نظرات و نظرات زنجیره‌ای را پس از ترکیب فایل‌ها از نویسندگان یا قالب‌های مختلف نیز بررسی کنید.

### **تصاویر، صدا، ویدئو، اشیای OLE و پیوندهای خارجی**

اسلایدها می‌توانند به منابع سطح ارائه مانند تصاویر، صداهای توکار، ویدئوهای توکار و داده‌های OLE ارجاع دهند. به‌جای کپی فقط اشکال قابل مشاهده، کل اسلاید را تکثیر کنید تا Aspose.Slides بتواند روابط اسلاید با منابعش را حفظ کند.

منابع توکار و پیوندی باید به‌طور متفاوتی رفتار شوند. یک صدا، ویدئو، شیء OLE یا ابرپیوند لینک‌شده به هدف خارجی خود وابسته می‌ماند؛ تکثیر اسلاید لینک خارجی را به محتوا توکار تبدیل نمی‌کند. مسیرها و URLهای منابع لینک‌شده را در محیطی که ارائه ادغام‌شده باز خواهد شد، آزمایش کنید.

Aspose.Slides به‌صورت صریح مسترهای تکثیر شده به‌صورت خودکار را ردیابی می‌کند، اما این نباید به‌عنوان یک تضمین کلی تلقی شود که منابع باینری یکسان از ارائه‌های منبع نامرتبط همیشه حذف تکرار می‌شوند. اگر حجم فایل خروجی مهم است، بستهٔ ادغام‌شده را بررسی و نتیجه را اندازه‌گیری کنید به‌جای تکیه بر حذف تکرار ضمنی.

### **قلم‌های توکار و در دسترس بودن قلم‌ها**

قلم‌ها در سطح ارائه مدیریت می‌شوند. اگر تایپوگرافی باید در دستگاه‌های مختلف یکسان بماند، فرض نکنید که تنها تکثیر اسلایدها تضمین می‌کند تمام قلم‌های مورد نیاز در محیط مقصد موجود هستند. می‌توانید قلم‌های توکار را با [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) بررسی کنید و توکار کردن را به‌صورت صریح همانند راهنمای [Embed Fonts in Presentations](https://docs.aspose.com/slides/fa/nodejs-java/embedded-font/) مدیریت کنید.

همچنین اطمینان حاصل کنید که اجازه توکار کردن قلم‌های استفاده شده در فایل‌های منبع را دارید. مجوزهای قلم می‌توانند توكار کردن را محدود کنند.

### **ارائه‌های دارای رمز عبور**

یک منبع دارای رمز عبور باید پیش از تکثیر اسلایدهایش با موفقیت باز شود. رمز عبور را از طریق [LoadOptions.setPassword](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#setPassword-String-) ارائه دهید.

```javascript
const aspose = require("aspose.slides.via.java");

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

const source = new aspose.slides.Presentation("protected.pptx", loadOptions);
try {
    // با ارائهٔ رمزگشایی‌شده کار کنید.
} finally {
    source.dispose();
}
```

باز کردن منبع رمزگذاری‌شده به‌صورت خودکار همان حفاظت را به ارائه مقصد اعمال نمی‌کند. در صورت نیاز، حفاظت خروجی را به‌صورت جداگانه پیکربندی کنید.

### **ارائه‌های بزرگ و مصرف حافظه**

ارائه‌های بزرگ حاوی تصاویر با وضوح بالا، صدا، ویدئو یا سایر اشیای باینری بزرگ می‌توانند حافظه‌ زیادی مصرف کنند. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--) کنترل‌هایی برای مدیریت BLOB و استفاده از فایل‌های موقت ارائه می‌دهد. برای استراتژی‌های فایل‌های بزرگ، به [Manage Presentation BLOBs](https://docs.aspose.com/slides/fa/nodejs-java/manage-blob/) مراجعه کنید.

برای فایل‌های بزرگ، در صورت امکان ترجیحاً از مسیرهای فایل بارگذاری کنید، هر ارائه منبع را به محض ادغام آن آزاد کنید و از ذخیره مداوم نتایج میانی خودداری کنید مگر اینکه جریان کاری به نقاط بررسی نیاز داشته باشد.

### **ایمنی در چندنخی**

یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) را در چندین رشته بارگذاری، ذخیره یا تکثیر نکنید. این عملیات برای استفادهٔ چندنخی پشتیبانی نمی‌شود. اگر نیاز به موازی‌سازی شغل‌های ادغام مستقل دارید، از چندین پردازش تک‌نخی استفاده کنید، هر کدام دارای نمونه‌های ارائه خود باشند و راهنمای [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/fa/nodejs-java/multithreading/) را دنبال کنید.

## **سوالات متداول**

**چگونه می‌توانم طراحی اصلی هر ارائه منبع را حفظ کنم؟**

از [`addClone(sourceSlide)`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) بدون ارائهٔ مستر یا طرح‌بندی مقصد استفاده کنید. Aspose.Slides می‌تواند مستر منبع را به‌صورت خودکار زمانی که اسلاید وارد شده به آن نیاز دارد، تکثیر کند.

**چگونه اسلایدهای وارد شده را به استفاده از تم مقصد برسانم؟**

از overload ای که مستر مقصد را می‌پذیرد استفاده کنید. یک مستر از ارائه مقصد، نه منبع، عبور دهید. Aspose.Slides سعی می‌کند هر اسلاید منبع را به یک طرح‌بندی مناسب تحت آن مستر نگاشت کند.

**کی باید به‌جای مستر مقصد از یک طرح‌بندی خاص مقصد استفاده کنم؟**

وقتی هر اسلاید وارد شده باید از یک طرح‌بندی شناخته‌شده استفاده کند، یک طرح‌بندی خاص را به کار ببرید. وقتی می‌خواهید Aspose.Slides بر اساس نوع یا نام طرح‌بندی منبع، میان طرح‌بندی‌های مستر انتخاب کند، از مستر استفاده کنید.

**آیا می‌توان ارائه‌های با اندازه اسلاید متفاوت را ادغام کرد؟**

بله، اما محتوای اسلاید به‌صورت خودکار برای ابعاد مقصد بازطراحی نمی‌شود. زمانی که به‌جایگذاری پیش‌بینی‌پذیر نیاز دارید، ابتدا اندازهٔ ارائه منبع را تغییر دهید، برای مثال با [SlideSize.setSize](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) و [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidesizescaletype/).

**آیا می‌توانم فایل‌های PPT، PPTX و ODP را در یک فایل ترکیب کنم؟**

بله. هر ارائه منبع را بارگذاری کنید، اسلایدهای مورد نیاز را به یک مقصد تکثیر کنید و مقصد را در یک قالب خروجی پشتیبانی‌شده ذخیره کنید. چون قالب‌های ارائه دقیقاً مجموعهٔ ویژگی‌های یکسانی ندارند، پس از ادغام‌های متقابل قالب، محتوای پیچیده را بررسی کنید. به [Supported File Formats](https://docs.aspose.com/slides/fa/nodejs-java/supported-file-formats/) مراجعه نمایید.

**آیا بخش‌های منبع به‌صورت خودکار حفظ می‌شوند؟**

خیر، یک حلقهٔ ساده که فقط اسلایدها را تکثیر می‌کند، بخش‌های منبع را حفظ نمی‌کند. بخش‌های مورد نیاز را در مقصد بازسازی کنید و زمانی که ساختار بخش‌ها باید حفظ شود، از overload بخش [addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-) استفاده کنید.

**آیا یادداشت‌های سخنران و نظرات حفظ می‌شوند؟**

آنها همراه با اسلاید تکثیر شده کپی می‌شوند. برای جریان‌های کاری که به قالب‌بندی notes‑master، نویسندگان نظرات یا داده‌های مرور زنجیره‌ای وابسته‌اند، نتیجه‌ی ادغام را بررسی کنید زیرا این سناریوها شامل ساختارهای سطح ارائه و همچنین محتوای سطح اسلاید می‌شوند.

**چه اتفاقی برای صدا، ویدئو، اشیای OLE و ابرپیوندها می‌افتد؟**

محتوای توکار به‌عنوان بخشی از روابط منابع اسلاید تکثیر شده منتقل می‌شود. لینک‌های خارجی همچنان خارجی می‌مانند، بنابراین فایل‌ها یا URLهای هدف آن‌ها باید پس از ادغام در دسترس باشند.

**آیا قلم‌های توکار از هر منبع تضمین می‌شود که در ارائه ادغام‌شده موجود باشند؟**

به‌تنهایی بر تکثیر اسلاید برای استقرار قلم‌ها تکیه نکنید. قلم‌های توکار مقصد را بررسی کنید و هنگام اهمیت تایپوگرافی، توکار کردن قلم یا در دسترس بودن قلم‌های خارجی را به‌صورت صریح مدیریت کنید.

**چگونه یک فایل دارای رمز عبور را ادغام کنم؟**

آن را با [LoadOptions.setPassword](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#setPassword-String-) صحیح باز کنید، سپس اسلایدهای آن را به‌صورت معمول تکثیر کنید. حفاظت خروجی به‌صورت جداگانه پیکربندی می‌شود.

**چگونه باید با ارائه‌های بسیار بزرگ برخورد کنم؟**

زمانی که اشیای باینری بزرگ مصرف حافظه را فراگیری می‌کنند، از مدیریت BLOB استفاده کنید، برای فایل‌های بسیار بزرگ ترجیحاً از بارگذاری مسیر فایل استفاده کنید، ارائه‌های منبع را به‌سرعت آزاد کنید و فقط در صورت نیاز نتیجهٔ نهایی را ذخیره کنید.

**آیا می‌توانم اسلایدها را از چندین رشته ادغام کنم؟**

در چندین رشته نمونهٔ ارائه را بارگذاری، ذخیره یا تکثیر نکنید. برای کارهای ادغام موازی، از پروسه‌های تک‌نخی جداگانه و نمونه‌های ارائه مستقل استفاده کنید.