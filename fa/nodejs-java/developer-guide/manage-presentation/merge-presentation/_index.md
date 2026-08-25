---
title: ادغام کارآمد ارائه‌ها در JavaScript
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
- JavaScript
- Aspose.Slides
description: "یاد بگیرید چگونه ارائه‌های PowerPoint و OpenDocument را در JavaScript با کلون کردن اسلایدها، کنترل مسترها و طرح‌بندی‌ها، تغییر اندازه محتوای اسلاید، حفظ بخش‌ها و مدیریت فایل‌های محافظت‌شده یا بزرگ ادغام کنید."
---
## **مروری کلی**

Aspose.Slides برای Node.js از طریق Java ارائه‌ها را با کلون کردن اسلایدها از یک [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) به دیگری ادغام می‌کند. عمل اصلی [SlideCollection.addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) است که می‌تواند قالب‌بندی اسلاید منبع را حفظ کند یا اسلاید کلون‌شده را به یک مستر یا طرح‌بندی در ارائه مقصد متصل کند.

این مقاله شامل رایج‌ترین روش‌های ادغام است:

- ادغام تمام اسلایدها با حفظ قالب‌بندی منبع؛
- ادغام اسلایدهای انتخابی؛
- اعمال مستر از ارائه مقصد؛
- اعمال یک طرح‌بندی خاص از ارائه مقصد؛
- نرمال‌سازی اندازه‌های مختلف اسلاید قبل از ادغام؛
- افزودن اسلایدهای کلون‌شده به یک بخش؛
- ادغام چندین ارائه در یک جریان کار انتها‑به‑انتهای؛
- مدیریت مسترها، منابع، یادداشت‌ها، نظرات، رسانه‌ها، فونت‌ها، پسوردها، فایل‌های بزرگ و ملاحظات چندنخی.

## **چگونگی تأثیر کلون اسلاید بر مسترها و طرح‌بندی‌ها**

یک اسلاید بخش زیادی از ظاهر خود را از طرح‌بندی و مستر خود به ارث می‌برد. به همین دلیل، نسخهٔ افزودن (overload) که انتخاب می‌کنید تعیین می‌کند اسلاید ادغام‌شده چگونه در ارائه مقصد ادغام می‌شود.

از [SlideCollection.addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidecollection/) به یکی از این روش‌ها استفاده کنید:

- `addClone(sourceSlide)` — حفظ طرح‌بندی و قالب‌بندی اسلاید منبع. در صورت نیاز، مستر منبع می‌تواند به‌صورت خودکار به ارائه مقصد کلون شود. Aspose.Slides به‌طور خودکار مسترهای کلون‌شده را ردیابی می‌کند تا اسلایدهای تکراری که از همان مستر منبع استفاده می‌کنند، مستر را چندین بار کلون نکنند.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — اتصال اسلاید کلون‌شده به یک [MasterSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterslide/) هدف خاص. Aspose.Slides با جستجوی طرح‌بندی مطابقت‌دار زیر آن مستر بر اساس نوع یا نام طرح‌بندی، عمل می‌کند.
- `addClone(sourceSlide, destinationLayout)` — اتصال اسلاید کلون‌شده مستقیم به یک [LayoutSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutslide/) هدف خاص.

مستر یا طرح‌بندی که به یک overload از `addClone` پاس داده می‌شود باید به ارائه **مقصد** تعلق داشته باشد، نه به ارائه منبع.

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

در نتیجه ممکن است ارائه شامل چندین مستر باشد وقتی که منبع و مقصد دارای طرح‌های متفاوتی هستند. این حالت طبیعی است زیرا قالب‌بندی منبع به‌صورت عمدی حفظ می‌شود.

## **ادغام اسلایدهای انتخابی**

لازم نیست هر اسلاید را کلون کنید. مثال زیر تنها ایندکس‌های اسلایدهای انتخابی را از ارائه منبع وارد می‌کند.

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

قبل از کلون کردن ایندکس‌های اسلاید را اعتبارسنجی کنید، به‌ویژه وقتی که از ورودی کاربر یا پیکربندی خارجی می‌آیند.

## **ادغام اسلایدها با استفاده از مستر مقصد**

هنگامی که اسلایدهای وارد شده باید از یک مستر استفاده کنند که قبلاً به ارائه مقصد تعلق دارد، overload `[addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-)` را به کار ببندید.

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

Aspose.Slides یک طرح‌بندی مناسب زیر مستر مشخص‌شده را بر اساس نوع یا نام طرح‌بندی منبع انتخاب می‌کند. اگر طرح‌بندی مناسبی وجود نداشته باشد و `allowCloneMissingLayout` برابر `true` باشد، طرح‌بندی منبع کلون می‌شود تا اسلاید اضافه شود. اگر `false` باشد، یک [PptxEditException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pptxeditexception/) افزاخ می‌شود.

در زمانی که می‌خواهید ادغام به‌جای افزودن طرح‌بندی جدید به مستر مقصد شکست بخورد، از `false` استفاده کنید.

## **ادغام اسلایدها با استفاده از یک طرح‌بندی مقصد خاص**

وقتی دقیقا می‌دانید که اسلایدهای وارد شده باید از کدام طرح‌بندی مقصد استفاده کنند، overload `[addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-)` را به کار ببندید.

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

اعمال یک طرح‌بندی مقصد رابطهٔ وراثتی طرح‌بندی را تغییر می‌دهد؛ اما محتوای اسلاید منبع را بازطراحی نمی‌کند. اگر طرح‌بندی‌های منبع و مقصد ساختارهای placeholder متفاوتی داشته باشند، نتیجه را بررسی کنید تا اطمینان یابید قالب‌بندی وراثتی و رفتار placeholder مناسب است.

## **ادغام ارائه‌ها با اندازه‌های اسلاید متفاوت**

ارائه‌هایی با ابعاد اسلاید متفاوت می‌توانند ادغام شوند، اما کلون یک اسلاید به ارائه‌ای با اندازهٔ اسلاید دیگر به‌صورت خودکار محتوای آن را برای بوم جدید بازطراحی نمی‌کند. بنابراین اشکال ممکن است جابجا، مقیاس‌دار یا خارج از ناحیهٔ قابل مشاهده اسلاید ظاهر شوند.

یک روش عملی این است که پیش از کلون کردن، اندازهٔ ارائه منبع را تغییر اندازه دهید. متد `[SlideSize.setSize](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-)` می‌تواند محتوای موجود را در حین تغییر ابعاد اسلاید مقیاس‌گذاری کند. `[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidesizescaletype/)` محتوا را طوری مقیاس‌گذاری می‌کند که در اندازهٔ درخواست‌شده جا بگیرد.

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

تغییر اندازه، شیء ارائه منبع را در حافظه تغییر می‌دهد. اگر به ارائهٔ منبع اصلی برای عملیات‌های دیگر نیاز دارید، یک نمونهٔ جداگانه برای ادغام باز کنید.

## **ادغام اسلایدها در یک بخش ارائه**

حلقهٔ اساسی کلون اسلایدها بخش‌های سلسله‌مراتبی ارائه منبع را بازتولید نمی‌کند. اگر بخش‌ها در خروجی مهم هستند، در ارائه مقصد بخش‌ها را ایجاد یا انتخاب کنید و اسلایدها را به‌صورت صریح با `[addClone(Slide, Section)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-)` به آن‌ها کلون کنید.

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

اسلایدهای کلون‌شده به بخش مقصد مشخص‌شده افزوده می‌شوند. برای حفظ چندین بخش منبع، `[Presentation.getSections](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getSections)` را مرور کنید، اسلایدهای هر بخش منبع را با `[Section.getSlidesListOfSection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/section/#getSlidesListOfSection)` دریافت کنید، بخش‌ها را در مقصد بازسازی کنید و هر اسلاید بازگردانده‌شده را به بخش مقصد متناظر کلون کنید. برای مثال کامل در خصوص شمارش بخش‌ها، شامل بخش‌های خالی و تغییرات ساختاری، به [Manage Slide Sections](/slides/fa/nodejs-java/slide-section/) مراجعه کنید.

## **ادغام چندین ارائه به‌صورت ایمن**

مثال انتها‑به‑انهای زیر از اولین ارائه به‌عنوان مقصد استفاده می‌کند، اندازهٔ اسلاید هر منبع اضافی را نرمال‌سازی می‌کند، هر منبع را فقط در زمان کپی باز می‌دارد و در نهایت فایل نهایی را یک‌بار ذخیره می‌کند.

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

این یک پایهٔ مفید برای حفظ قالب‌بندی اسلایدهای وارد‌شده است. اگر خروجی شما باید از یک تم واحد استفاده کند، فراخوانی سادهٔ `addClone(sourceSlide)` را با overload مناسب مستر یا طرح‌بندی مقصد که پیشتر نشان داده شد، جایگزین کنید.

## **ملاحظات عملی**

### **مسترها، طرح‌بندی‌ها و صحت قالب‌بندی**

کلون پیش‌فرض اسلاید می‌تواند مستر مورد نیاز منبع را به‌صورت خودکار به ارائه مقصد بیاورد. Aspose.Slides یک رجیستری داخلی برای مسترهای کلون‌شده خودکار نگهداری می‌کند تا از کلون مکرر یک مستر جلوگیری کند. مسترهای کلون‌شده به‌صورت دستی در آن رجیستری ثبت نمی‌شوند، بنابراین از پیش‑کلون کردن مسترها خودداری کنید مگر اینکه نیاز به کنترل صریح بر ساختار مستر داشته باشید.

به این نکته توجه داشته باشید که دو مستر یا طرح‌بندی با همان نام لزوماً برابر نیستند. اگر یک الگوی شرکتی باید ظاهر نهایی را کنترل کند، مستر یا طرح‌بندی مقصد را صریحاً انتخاب کنید و پس از ادغام نتیجه را بررسی نمایید.

### **یادداشت‌ها و نظرات**

یادداشت‌های گوینده و نظرات اسلاید با محتوی اسلاید مرتبط هستند و هنگام کلون اسلاید کپی می‌شوند. Aspose.Slides همچنین APIهای اختصاصی برای [presentation notes](/slides/fa/nodejs-java/presentation-notes/) و [presentation comments](/slides/fa/nodejs-java/presentation-comments/) فراهم می‌کند.

اگر قالب‌بندی صفحهٔ یادداشت‌ها مهم است، ارائهٔ ادغام‌شده را بررسی کنید زیرا مسترهای یادداشت در سطح ارائه هستند و ممکن است بین فایل‌های منبع متفاوت باشند. برای جریان‌های بازبینی، نویسندگان نظرات و نظرات زنجیره‌ای را پس از ترکیب فایل‌ها از نویسندگان یا قالب‌های مختلف نیز بررسی کنید.

### **تصاویر، صدا، ویدیو، اشیای OLE و لینک‌های خارجی**

اسلایدها می‌توانند به منابع سطح ارائه مانند تصاویر، صداهای جاسازی‌شده، ویدیوهای جاسازی‌شده و داده‌های OLE ارجاع دهند. به‌جای کپی فقط اشکال قابل مشاهده، کلون کامل اسلاید را انجام دهید تا Aspose.Slides بتواند روابط اسلاید با منابعش را حفظ کند.

منابع جاسازی‌شده و لینک‌شده باید به‌صورت متفاوتی رفتار شوند. یک صوت، ویدیو، شیء OLE یا لینک خارجی همچنان به هدف خارجی خود وابسته می‌ماند؛ کلون اسلاید یک لینک خارجی را به محتوای جاسازی‌شده تبدیل نمی‌کند. مسیرها و URLهای منابع لینک‌شده را در محیطی که ارائهٔ ادغام‌شده باز می‌شود، آزمایش کنید.

Aspose.Slides به‌صورت صریح مسترهای کلون‌شده خودکار را ردیابی می‌کند، اما این به‌عنوان تضمین کلی برای حذف تکرار باینری منابع مشابه از ارائه‌های نامرتبط در نظر گرفته نشود. اگر حجم فایل خروجی مهم است، بستهٔ ادغام‌شده را بررسی کنید و نتیجه را اندازه‌گیری کنید، به‌جای اتکای مطلق به حذف تکرار ضمنی.

### **فونت‌های جاسازی‌شده و در دسترس بودن فونت‌ها**

فونت‌ها در سطح ارائه مدیریت می‌شوند. اگر نیاز به نگه داشتن تایپوگرافی یکسان بین دستگاه‌ها دارید، تنها کلون اسلایدها تضمین‌کنندهٔ در دسترس بودن هر فونت مورد نیاز در محیط مقصد نیست. می‌توانید فونت‌های جاسازی‌شده را با `[FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--)` بررسی کنید و به‌طور صریح همان‌طور که در [Embed Fonts in Presentations](/slides/fa/nodejs-java/embedded-font/) توضیح داده شده، مدیریت کنید.

همچنین اطمینان حاصل کنید که اجازهٔ جاسازی فونت‌های استفاده‌شده در فایل‌های منبع را دارید؛ مجوزهای فونت ممکن است جاسازی را محدود کنند.

### **ارائه‌های دارای رمز عبور**

یک منبع دارای رمز عبور باید پیش از کلون اسلایدها با موفقیت باز شود. رمز عبور را از طریق `[LoadOptions.setPassword](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#setPassword-String-)` ارائه دهید.

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

باز کردن یک منبع رمزگذاری‌شده به‌طور خودکار حفاظت مشابهی را به ارائه مقصد اعمال نمی‌کند. در صورت نیاز، حفاظت خروجی را جداگانه پیکربندی کنید.

### **ارائه‌های بزرگ و مصرف حافظه**

ارائه‌های بزرگ که شامل تصاویر با وضوح بالا، صدا، ویدیو یا اشیای باینری بزرگ دیگر هستند می‌توانند حافظهٔ قابل توجهی مصرف کنند. `[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--)` کنترل‌های مدیریت BLOB و استفاده از فایل موقت را فراهم می‌کند. برای استراتژی‌های فایل‌های بزرگ به [Manage Presentation BLOBs](/slides/fa/nodejs-java/manage-blob/) مراجعه کنید.

برای فایل‌های بزرگ، در صورت امکان از مسیرهای فایل برای بارگذاری استفاده کنید، هر ارائه منبع را به‌محض اتمام ادغام دفع (dispose) کنید و از ذخیره‌سازی مکرر نتایج میانی خودداری کنید مگر اینکه گردش کار نیاز به نقطه‌بررسی داشته باشد.

### **ایمنی در چندنخی**

یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) را همزمان در چندین رشته (thread) بارگذاری، ذخیره یا کلون نکنید. این عملیات‌ها برای استفادهٔ چندنخی پشتیبانی نمی‌شوند. اگر نیاز به هم‌زمان‌سازی شغل‌های ادغام مستقل دارید، چندین فرآیند تک‌رشته‌ای با نمونه‌های جداگانهٔ ارائه استفاده کنید و راهنمایی‌های چندنخی Aspose.Slides را در [/slides/fa/nodejs-java/multithreading/](/slides/fa/nodejs-java/multithreading/) دنبال کنید.

## **سؤالات متداول**

**چگونه می‌توان طراحی اصلی هر ارائهٔ منبع را نگهداری کرد؟**

بدون ارائه مستر یا طرح‌بندی مقصد، از `[addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-)` استفاده کنید. Aspose.Slides می‌تواند مستر منبع را به‌صورت خودکار کلون کند هنگامی که اسلاید وارد شده به آن نیاز دارد.

**چگونه می‌توان اسلایدهای وارد شده را به تم مقصد تغییر داد؟**

منجر (overload) را که مستر مقصد می‌پذیرد، به کار ببندید. یک مستر از ارائه مقصد، نه منبع، پاس دهید. Aspose.Slides سعی می‌کند هر اسلاید منبع را به یک طرح‌بندی مناسب زیر آن مستر مطابقت دهد.

**چه زمانی باید به‌جای مستر مقصد، یک طرح‌بندی مقصد خاص استفاده شود؟**

وقتی همهٔ اسلایدهای وارد شده باید از یک طرح‌بندی شناخته‌شده استفاده کنند، از طرح‌بندی خاص استفاده کنید. وقتی می‌خواهید Aspose.Slides بین طرح‌بندی‌های مستر بر اساس نوع یا نام طرح‌بندی منبع انتخاب کند، از مستر استفاده کنید.

**آیا می‌توان ارائه‌هایی با اندازهٔ اسلاید متفاوت را ادغام کرد؟**

بله، اما محتوای اسلاید به‌صورت خودکار برای ابعاد مقصد بازطراحی نمی‌شود. برای داشتن موقعیت‌بندی پیش‌بینی‌شده ابتدا منبع را با `[SlideSize.setSize](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-)` و `[SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidesizescaletype/)` تغییر اندازه دهید.

**آیا می‌توانم فایل‌های PPT، PPTX و ODP را در یک فایل ترکیب کنم؟**

بله. هر ارائهٔ منبع را بارگذاری کنید، اسلایدهای مورد نیاز را به یک مقصد کلون کنید و مقصد را در یک قالب خروجی پشتیبانی‌شده ذخیره کنید. چون فرمت‌های ارائه دقیقاً مجموعهٔ ویژگی‌های یکسانی ندارند، پس از ترکیب فرمت‑متقاطع محتویات پیچیده را بررسی کنید. به [Supported File Formats](/slides/fa/nodejs-java/supported-file-formats/) مراجعه کنید.

**آیا بخش‌های منبع به‌صورت خودکار حفظ می‌شوند؟**

نه، در یک حلقهٔ ساده که فقط اسلایدها را کلون می‌کند بخش‌ها حفظ نمی‌شوند. برای حفظ ساختار بخش‌ها، آنها را در مقصد بازسازی کنید و overload بخش `[addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-)` را به کار ببندید.

**آیا یادداشت‌های گوینده و نظرات حفظ می‌شوند؟**

آنها همراه با اسلاید کلون‌شده کپی می‌شوند. برای جریان‌های کاری که به استایل مستر یادداشت‌ها، نویسندگان نظرات یا داده‌های بازبینی زنجیره‌ای وابسته‌اند، نتیجهٔ ادغام را بررسی کنید زیرا این سناریوها شامل ساختارهای سطح ارائه به‌علاوه محتواهای سطح اسلاید هستند.

**چه اتفاقی برای صدا، ویدیو، اشیای OLE و هایپرلینک‌ها می‌افتد؟**

محتوای جاسازی‌شده به‌عنوان بخشی از روابط منبع اسلاید به اسلاید کلون‌شده منتقل می‌شود. لینک‌های خارجی همچنان خارجی می‌مانند، بنابراین فایل‌ها یا URLهای هدف باید پس از ادغام در دسترس باشند.

**آیا فونت‌های جاسازی‌شده از هر منبع گارانتی می‌شوند که در ارائهٔ ادغام‌شده در دسترس باشند؟**

به‌تنهایی کلون اسلاید برای استقرار فونت اطمینان کافی نیست. فونت‌های جاسازی‌شده در مقصد را بررسی کنید و برای نگه داشتن تایپوگرافی مهم، به‌صورت صریح مدیریت فونت‌های جاسازی‌شده یا در دسترس بودن فونت‌های خارجی را انجام دهید.

**چگونه می‌توان یک فایل دارای رمز عبور را ادغام کرد؟**

با `[LoadOptions.setPassword](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#setPassword-String-)` صحیح آن را باز کنید، سپس اسلایدهای آن را به‌صورت معمولی کلون کنید. حفاظت خروجی به‌صورت جداگانه پیکربندی می‌شود.

**چگونه باید با ارائه‌های بسیار بزرگ برخورد کرد؟**

از مدیریت BLOB استفاده کنید هنگامی که اشیای باینری بزرگ حافظه را به‌هم می‌زنند، برای فایل‌های بسیار بزرگ ترجیحاً از بارگذاری مسیر فایل استفاده کنید، نمونه‌های ارائهٔ منبع را بلافاصله پس از ادغام دفع کنید و نتیجهٔ نهایی را تنها زمانی ذخیره کنید که نیاز باشد.

**آیا می‌توانم اسلایدها را از چندین رشته همزمان ادغام کنم؟**

یک نمونهٔ Presentation را در چندین رشته بارگذاری، ذخیره یا کلون نکنید. برای کارهای ادغام مستقل، چندین فرآیند تک‌رشته‌ای با نمونه‌های جداگانهٔ ارائه استفاده کنید. برای راهنمایی‌های چندنخی به [/slides/fa/nodejs-java/multithreading/](/slides/fa/nodejs-java/multithreading/) مراجعه کنید.