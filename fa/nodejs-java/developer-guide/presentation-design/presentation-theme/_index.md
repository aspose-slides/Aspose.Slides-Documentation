---
title: "مدیریت تم‌های ارائه در جاوااسکریپت"
linktitle: "تم ارائه"
type: docs
weight: 10
url: /fa/nodejs-java/presentation-theme/
keywords:
- تم پاورپوینت
- تم ارائه
- تم اسلاید
- تنظیم تم
- تغییر تم
- مدیریت تم
- رنگ تم
- پالت اضافی
- قلم تم
- ستایل تم
- افکت تم
- پاورپوینت
- اُپن‌داکیومنت
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "تم‌های اصلی ارائه را در جاوااسکریپت با Aspose.Slides برای Node.js مدیریت کنید تا فایل‌های پاورپوینت را با برندینگ یکسان ایجاد، سفارشی‌سازی و تبدیل کنید."
---
## **مقدمه**

یک تم ارائه مجموعه‌ای هماهنگ از رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه، پرکننده‌ها، خطوط و افکت‌ها را تعریف می‌کند. اشیای آگاه از تم به‌جای ذخیرهٔ هر ویژگی بصری به‌صورت مقدار ثابت، به این تعاریف مشترک ارجاع می‌دهند، بنابراین تغییر تم می‌تواند تعداد زیادی شی را به‌صورت همزمان به‌روزرسانی کند.

در Aspose.Slides، تم سطح ارائه از طریق [Presentation.getMasterTheme] در دسترس است. یک ارائه می‌تواند همچنین بازنویسی‌های تم را در سطوح پایین‌تر داشته باشد. یک master می‌تواند تم ارائه را از طریق [MasterThemeManager.getOverrideTheme] بازنویسی کند، در حالی که یک layout یا یک اسلاید منفرد می‌تواند تم ارث‌بردهٔ خود را از طریق [BaseOverrideThemeManager.getOverrideTheme] بازنویسی کند. در عمل، تم مؤثر برای یک اسلاید از طریق این زنجیرهٔ ارث‌بری حل می‌شود: تم ارائه، بازنویسی master، بازنویسی layout و بازنویسی اسلاید.

![اجزای تم: رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه و افکت‌ها](theme-constituents.png)

بخش‌های زیر رایج‌ترین گردش‌کارهای تم را نشان می‌دهند: بررسی یک تم، تغییر رنگ‌ها و قلم‌ها، کپی یا اعمال یک تم، به‌روزرسانی سبک‌های پس‌زمینه و افکت، و خواندن مقادیر مؤثر پس از حل ارث‌بری و بازنویسی‌ها.

## **بررسی یک تم**

شیء [MasterTheme] طرح رنگ، طرح قلم و طرح قالب تم را از طریق [MasterTheme.getColorScheme]، [MasterTheme.getFontScheme] و [MasterTheme.getFormatScheme] افشا می‌کند. بررسی این مجموعه‌ها قبل از تغییر آنها بویژه زمانی مفید است که یک ارائه از منبع خارجی آمده باشد، زیرا تعداد و محتوای ورودی‌های سبک می‌توانند متفاوت باشند.

مثال زیر ویژگی‌های اصلی تم را می‌خواند و گزارش می‌دهد که چند سبک پس‌زمینه، پرکننده، خط و افکت در تم ذخیره شده‌اند:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const theme = presentation.getMasterTheme();
    console.log("Theme name: " + theme.getName());
    console.log("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    console.log("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    console.log("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    console.log("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    console.log("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

اگر فایلی از چند master استفاده کند، فرض نکنید که هر اسلاید همان تم مؤثر را دارد. master مرتبط با اسلاید را بررسی کنید و از گردش‌کار تم مؤثر که در ادامه این مقاله نشان داده شده استفاده کنید وقتی که بازنویسی‌های layout یا اسلاید ممکن است وجود داشته باشند.

## **تغییر رنگ‌های تم**

پرکننده‌ها، خطوط و متن‌های آگاه از تم می‌توانند به یک رنگ منطقی از شمارش [SchemeColor] ارجاع دهند. زمانی که ورودی متناظر در [ColorScheme] را تغییر می‌دهید، تمام اشیایی که هنوز به آن رنگ تم ارجاع می‌دهند، نسبت به مقدار جدید حل می‌شوند. اشیایی که از یک رنگ RGB مستقیم استفاده می‌کنند، توسط به‌روزرسانی رنگ تم تغییر نمی‌کنند.

مثال انتها‑به‑انتها زیر یک شکل ایجاد می‌کند که از `Accent4` استفاده می‌کند، رنگ `Accent4` تم را به قرمز تغییر می‌دهد، ارائه را ذخیره می‌کند، آن را دوباره باز می‌کند و رنگ پرکننده مؤثر را چاپ می‌کند:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("theme-color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new aspose.slides.Presentation("theme-color.pptx");
try {
    const savedSlide = savedPresentation.getSlides().get_Item(0);
    const savedShape = savedSlide.getShapes().get_Item(0);
    const effectiveFill = savedShape.getFillFormat().getEffective();
    console.log("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

چون مستطیل همچنان به `Accent4` متصل است، رنگ قابل مشاهده‌اش پس از تغییر تم به قرمز تبدیل می‌شود. اگر رنگ طرح را با یک رنگ مستقیم روی شکل جایگزین کنید، تغییرات بعدی `Accent4` دیگر آن پرکننده را تحت تأثیر قرار نخواهد داد.

### **استفاده از رنگ‌ها از پالت اضافی**

PowerPoint برای تولید نسخه‌های روشن‌تر و تیره‌تر یک رنگ تم، تبدیل‌های رنگی اعمال می‌کند. Aspose.Slides این تبدیل‌ها را از طریق شمارش [ColorTransformOperation] در دسترس می‌گذارد.

![رنگ‌های اصلی تم و رنگ‌های روشن‌تر و تیره‌تر تولید شده از پالت اضافی](additional-palette-colors.png)

**1** – رنگ‌های اصلی تم.  
**2** – نسخه‌های روشن‌تر و تیره‌تر تولید شده از رنگ‌های اصلی تم.

مثال زیر شش مستطیل بر پایه `Accent4` ایجاد می‌کند، به پنج مورد از آنها تبدیل روشنایی می‌دهد و نتیجه را ذخیره می‌کند:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.2));
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.8));

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.4));
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.6));

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.6));
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.4));

    const shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.75));

    const shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.5));

    presentation.save("theme-color-palette.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

این نسخه‌ها بر پایه رنگ تم باقی می‌مانند. اگر `Accent4` بعدها تغییر کند، رنگ‌های تبدیل‌شده از مقدار جدید `Accent4` دوباره محاسبه می‌شوند.

### **نقشه‌برداری مقادیر `SchemeColor` به شکاف‌های `ColorScheme`**

شمارش [SchemeColor] از `Text1`، `Background1`، `Text2` و `Background2` استفاده می‌کند، در حالی که [ColorScheme] همان شکاف‌های تم را به عنوان `Dark1`، `Light1`، `Dark2` و `Light2` نشان می‌دهد. نگاشت ثابت است:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

این‌ها نام‌های جایگزین برای همان شکاف‌های تم هستند؛ آنها مقادیر دینامیکی نیستند که از یک فرم به فرم دیگر تبدیل شوند.

## **تغییر قلم‌های تم**

یک طرح قلم تم شامل یک مجموعهٔ قلم بزرگ برای عناوین و یک مجموعهٔ قلم کوچک برای متن بدنه است. متدهای [FontScheme.getMajor] و [FontScheme.getMinor] این مجموعه‌ها را افشا می‌کنند.

شناسه‌های قلم تم سازگار با PowerPoint می‌توانند در قالب‌بندی متن استفاده شوند:

* `+mn‑lt` – قلم بدنه لاتین (Minor Latin Font)
* `+mj‑lt` – قلم عنوان لاتین (Major Latin Font)
* `+mn‑ea` – قلم بدنه شرق آسیایی (Minor East Asian Font)
* `+mj‑ea` – قلم عنوان شرق آسیایی (Major East Asian Font)

مثال زیر یک عنوان که از قلم لاتین بزرگ تم استفاده می‌کند و یک خط بدنه که از قلم لاتین کوچک تم استفاده می‌کند ایجاد می‌کند. سپس قلم‌های تم را تغییر می‌دهد و نتیجه را ذخیره می‌کند:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const heading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mj-lt"));

    const body = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
    presentation.save("theme-fonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

عنوان از قلم بزرگ پیروی می‌کند و متن بدنه از قلم کوچک. متنی که نام قلم صریحی به‌جای شناسهٔ تم داشته باشد، هنگام تغییر طرح قلم تم به‌طور خودکار جابجا نخواهد شد.

{{% alert color="info" title="نکته" %}}

برای اطلاعات بیشتر درباره قلم‌های ارائه، به [PowerPoint Fonts](/slides/fa/nodejs-java/powerpoint-fonts/) مراجعه کنید.

{{% /alert %}}

## **کپی یا اعمال یک تم**

دو گردش‌کار رایج وجود دارد که هر یک مشکل متفاوتی را حل می‌کند.

### **حفظ تم منبع هنگام جابجایی اسلایدها**

اگر می‌خواهید اسلایدی را به ارائهٔ دیگری منتقل کنید و طراحی اصلی آن را حفظ کنید، master منبع را با استفاده از [MasterSlideCollection.addClone] به ارائهٔ هدف اضافه کنید، سپس اسلاید را با [SlideCollection.addClone] و master کلون‌شده کپی کنید. این کار master، layoutهای آن و تم مرتبط را به‌همراه خود می‌برد.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceSlide = source.getSlides().get_Item(0);
        const clonedMaster = target.getMasters().addClone(sourceSlide.getLayoutSlide().getMasterSlide());
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

این روش ترجیحی است وقتی اسلاید منبع باید در مقصد همان ظاهر را داشته باشد. به سادگی کلون کردن محتوا روی master نامرتبط مقصد می‌تواند رنگ‌ها، قلم‌ها، پس‌زمینه‌ها و افکت‌های وابسته به تم را تغییر دهد.

### **اعمال مقادیر تم به یک اسلاید موجود**

اگر اسلاید هدف باید بر روی master و layout فعلی خود بماند، یک بازنویسی سطح اسلاید را از تم منبع مقداردهی اولیه کنید. متدهای [OverrideTheme.initColorSchemeFrom]، [OverrideTheme.initFontSchemeFrom] و [OverrideTheme.initFormatSchemeFrom] سه مؤلفهٔ اصلی تم را به بازنویسی کپی می‌کنند.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

این کار تم استفاده‌شده توسط آن اسلاید را بدون تغییر تم ارث‌بردهٔ سایر اسلایدها تغییر می‌دهد. برای حذف بازنویسی محلی و بازگشت به مقادیر ارث‌برده، [OverrideTheme.clear] را فراخوانی کنید.

### **اعمال بازنویسی تم به یک Layout**

یک بازنویسی سطح layout برای اسلایدهایی که از آن layout استفاده می‌کنند اعمال می‌شود، مگر اینکه اسلاید خاصی بازنویسی خود را داشته باشد. همان متدهای مقداردهی اولیه می‌توانند از طریق [LayoutSlideThemeManager] استفاده شوند:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getLayoutSlide().getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-layout.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

از تم سطح master یا ارائه استفاده کنید وقتی بسیاری از layoutها و اسلایدها باید همان طراحی پایه را به‌اشتراک بگذارند؛ یک بازنویسی layout زمانی مفید است که یک خانوادهٔ layout نیاز به سبک‌گذاری متفاوت داشته باشد؛ و بازنویسی اسلاید فقط برای استثنای واقعی استفاده شود. بازنویسی‌های بیش از حد در سطح اسلاید، پیش‌بینی تغییرات تم سراسری بعدی را دشوار می‌کند.

## **به‌روزرسانی سبک‌های پس‌زمینه تم**

پرکننده‌های پس‌زمینهٔ تم در [FormatScheme.getBackgroundFillStyles] ذخیره می‌شوند. PowerPoint می‌تواند گزینه‌های پس‌زمینه بیشتری در رابط کاربری خود نمایش دهد نسبت به تعداد تعاریف پرکننده‌ای که فیزیکی در این مجموعه ذخیره شده‌اند، زیرا UI می‌تواند پرکننده‌های تم را با رنگ‌های تم و دیگر مراجع سبک ترکیب کند.

![گالری سبک‌های پس‌زمینه PowerPoint برای یک تم ارائه](presentation-design_8.png)

قبل از استفاده از یک سبک پس‌زمینه، مجموعهٔ ذخیره‌شده و [Background.getStyleIndex] جاری را بررسی کنید. یک شاخص سبک `0` به معنای عدم وجود پرکنندهٔ تم است؛ مقادیر مثبت ارجاع‌های سبک پس‌زمینهٔ تم هستند. این متفاوت از ایندکس‌گذاری مستقیم مجموعهٔ JavaScript است، جایی که شاخص `0` اولین مورد ذخیره‌شده را نشان می‌دهد. فرض نکنید که هر ارائه همان تعداد سبک پرکنندهٔ پس‌زمینه را دارد.

مثال زیر تعداد پرکننده‌های پس‌زمینهٔ موجود را گزارش می‌کند، یک ارجاع پس‌زمینهٔ تم‌شده به اولین master اختصاص می‌دهد و ارائه را ذخیره می‌کند:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    console.log("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() === 0) {
        throw new Error("The presentation theme does not contain background fill styles.");
    }

    const masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.Themed));
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجهٔ قابل مشاهده به ورودی تمی که توسط master ارجاع داده شده و هر بازنویسی پس‌زمینه در سطح layout یا اسلاید بستگی دارد. اگر اسلاید پس‌زمینهٔ خودش را داشته باشد، فقط تغییر پس‌زمینهٔ master ممکن است آن اسلاید را تغییر ندهد. وقتی نیاز به دانستن پس‌زمینهٔ نهایی پس از اعمال ارث‌بری دارید، از [Background.getEffective] استفاده کنید.

{{% alert color="warning" title="هشدار" %}}

شاخص سبک را به‌عنوان یک ایندکس صفر‑پایه مجموعه تصور نکنید. همچنین از کدنویسی ثابت یک شماره سبک از یک فایل و فرض اینکه در فایل دیگر همان ظاهر را دارد، خودداری کنید؛ تعاریف سبک تم مخصوص هر ارائه هستند.

{{% /alert %}}

{{% alert color="info" title="نکته" %}}

برای قالب‌بندی مستقیم پس‌زمینه و ارث‌بری پس‌زمینه، به [Presentation Background](/slides/fa/nodejs-java/presentation‑background/) مراجعه کنید.

{{% /alert %}}

## **به‌روزرسانی افکت‌های تم**

یک طرح قالب تم شامل مجموعه‌های جداگانهٔ پرکننده، خط و افکت است که از طریق [FormatScheme.getFillStyles]، [FormatScheme.getLineStyles] و [FormatScheme.getEffectStyles] در دسترس هستند. تم‌های عمومی Office اغلب سه ورودی سبک اصلی دارند که به‌صورت بصری به فرمت‌های دقیق، متوسط و شدید متناظر هستند، اما کد باید هر مجموعه را بررسی کند به‌جای این‌که تعداد ثابت فرض کند.

![افکت‌های تم دقیق، متوسط و شدید که بر یک شکل اعمال شده‌اند](presentation-design_10.png)

هنگامی که این مجموعه‌ها را در JavaScript دسترسی می‌دهید، ایندکس مجموعه صفر‑پایه است: ایندکس `0` اولین سبک ذخیره‌شده و ایندکس `2` سومین است. ایندکس‌های ارجاع‑سبک یک شکل مفهوم جداگانه‌ای است که از طریق [ShapeStyle] در دسترس است. تغییر یک سبک تم بر اشکالی که به آن سبک ارجاع می‌دهند تاثیر می‌گذارد؛ اشکالی که قالب‌بندی مستقیم دارند ممکن است بدون تغییر بمانند.

مثال زیر بررسی می‌کند که ورودی‌های سبک مورد نیاز وجود دارند، اولین سبک خط را تغییر می‌دهد، سومین سبک پرکننده را تغییر می‌دهد، یک سایهٔ بیرونی را در سومین سبک افکت فعال می‌کند و نتیجه را ذخیره می‌کند:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    const formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new Error("The theme does not contain the style entries required by this example.");
    }

    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    formatScheme.getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 34, 139, 34));
    const effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10);
    presentation.save("theme-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای اشکالی که به این شکاف‌ها ارجاع می‌دهند، اولین سبک خط تم قرمز می‌شود، سومین سبک پرکننده تم به سبز جنگلی ثابت تغییر می‌کند و سومین سبک افکت یک سایهٔ بیرونی با فاصلهٔ ۱۰ نقطه دریافت می‌کند. نتیجهٔ بصری دقیق همچنان به این‌که هر شکل به کدام شکاف‌ها ارجاع می‌دهد و آیا قالب‌بندی مستقیم تم را بازنویسی می‌کند یا نه، بستگی دارد.

![سبک‌های افکت تم پس از تغییر تنظیمات خط، پرکننده و سایه](presentation-design_11.png)

## **خواندن مقادیر مؤثر تم**

اشیای خام تم به شما می‌گویند چه چیزی در سطح خاصی تعریف شده است. مقادیر مؤثر به شما می‌گویند یک اسلاید یا شکل پس از حل ارث‌بری و بازنویسی‌های محلی چه چیزی واقعاً استفاده می‌کند. برای یک اسلاید، [BaseOverrideThemeManager.createThemeEffective] را فراخوانی کنید. برای یک پس‌زمینه، از [Background.getEffective] استفاده کنید و برای یک پرکننده، از [FillFormat.getEffective] استفاده کنید.

مثال زیر تم مؤثر، پس‌زمینه و اولین پرکننده شکل از یک اسلاید را می‌خواند:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const effectiveTheme = slide.getThemeManager().createThemeEffective();
    const effectiveBackground = slide.getBackground().getEffective();
    console.log("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        const effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        console.log("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() === aspose.slides.FillType.Solid) {
            console.log("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

از داده‌های مؤثر برای تشخیص رندر، اعتبارسنجی و مقایسه‌ها استفاده کنید. اگر فقط [Presentation.getMasterTheme] را بررسی کنید، ممکن است یک بازنویسی master، layout، اسلاید یا شکل را که ظاهر نهایی را تغییر می‌دهد، از دست بدهید.

## **سؤالات متداول**

**آیا می‌توانم تم را فقط به یک اسلاید اعمال کنم بدون تغییر master؟**

بله. از [SlideThemeManager] اسلاید استفاده کنید و بازنویسی تم آن را مقداردهی اولیه کنید. تغییر به‌صورت محلی به همان اسلاید باقی می‌ماند؛ اسلایدهای دیگر ادامه می‌دهند تم‌های موجودشان را به ارث ببرند.

**ایمن‌ترین روش برای انتقال یک تم از یک ارائه به ارائه دیگر چیست؟**

هنگام جابجایی یک اسلاید و حفظ ظاهر منبع آن، master منبع را به مقصد کلون کنید و اسلاید را با آن master از طریق [MasterSlideCollection.addClone] و [SlideCollection.addClone] کلون کنید. این کار master، layoutها و تم را با هم نگه می‌دارد.

**چگونه می‌توانم مقادیر مؤثر را پس از ارث‌بری و بازنویسی‌ها ببینم؟**

از [BaseOverrideThemeManager.createThemeEffective] برای یک اسلاید یا تم layout استفاده کنید و متدهای داده‑مؤثر مربوطه برای اشیای قالب مانند [Background.getEffective] و [FillFormat.getEffective] استفاده کنید. این APIها مقادیر حل‌شده پس از اعمال ارث‌بری و بازنویسی‌ها را برمی‌گردانند.