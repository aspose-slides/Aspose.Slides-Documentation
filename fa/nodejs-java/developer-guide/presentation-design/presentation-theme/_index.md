---
title: مدیریت تم‌های ارائه در جاوااسکریپت
linktitle: تم ارائه
type: docs
weight: 10
url: /fa/nodejs-java/presentation-theme/
keywords:
- تم PowerPoint
- تم ارائه
- تم اسلاید
- تنظیم تم
- تغییر تم
- مدیریت تم
- تم خارجی
- THMX
- رنگ تم
- پالت اضافی
- قلم تم
- استایل تم
- افکت تم
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "مدیریت تم‌های اصلی ارائه در جاوااسکریپت با Aspose.Slides برای Node.js به‌منظور ایجاد، سفارشی‌سازی و تبدیل فایل‌های PowerPoint با برندینگ یکسان."
---
## **مقدمه**

یک تم ارائه مجموعه‌ای هماهنگ از رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه، پرکردن‌ها، خطوط و افکت‌ها را تعریف می‌کند. اشیاء آگاه به تم به‌جای ذخیرهٔ هر ویژگی بصری به‌عنوان مقدار ثابت، به این تعاریف مشترک ارجاع می‌دهند، بنابراین تغییر تم می‌تواند بسیاری از اشیاء را همزمان به‌روز کند.

در Aspose.Slides، تم سطح ارائه از طریق [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/getmastertheme/) در دسترس است. یک ارائه می‌تواند همچنین بازنویسی‌های تم را در سطوح پایین‌تر داشته باشد. یک مستر می‌تواند تم ارائه را از طریق [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterthememanager/) بازنویسی کند، در حالی که یک لایه یا یک اسلاید جداگانه می‌تواند تم وارث خود را از طریق [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseoverridethememanager/) بازنویسی کند. در عمل، تم مؤثر برای یک اسلاید از طریق این زنجیرهٔ وراثت حل می‌شود: تم ارائه، بازنویسی مستر، بازنویسی لایه، و بازنویسی اسلاید.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

بخش‌های زیر رایج‌ترین جریان‌های کاری تم را نشان می‌دهند: بازرسی یک تم، تغییر رنگ‌ها و قلم‌ها، کپی یا اعمال یک تم، به‌روزرسانی سبک‌های پس‌زمینه و افکت، و خواندن مقادیر مؤثر پس از حل وراثت و بازنویسی‌ها.

## **بازرسی یک تم**

شیء [MasterTheme](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/mastertheme/) طرح رنگ، طرح قلم و طرح فرمت تم را از طریق [MasterTheme.getColorScheme](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/mastertheme/)، [MasterTheme.getFontScheme](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/mastertheme/)، و [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/mastertheme/) در معرض نمایش می‌گذارد. بازرسی این مجموعه‌ها پیش از تغییر آنها به‌خصوص وقتی ارائه از منبع خارجی می‌آید مفید است، زیرا تعداد و محتوای ورودی‌های سبک می‌تواند متفاوت باشد.

مثال زیر ویژگی‌های اصلی تم را می‌خواند و تعداد سبک‌های پس‌زمینه، پرکردن، خط و افکت ذخیره‌شده در تم را گزارش می‌کند:

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

اگر فایلی از چند مستر استفاده کند، فرض نکنید که هر اسلاید همان تم مؤثر را دارد. مستر مرتبط با اسلاید را بازرسی کنید و وقتی بازنویسی‌های لایه یا اسلاید ممکن است وجود داشته باشند، از جریان کاری تم مؤثر نشان‌داده‌شده در ادامهٔ این مقاله استفاده کنید.

## **تغییر رنگ‌های تم**

پرکردن‌ها، خطوط و متن‌های آگاه به تم می‌توانند به یک رنگ منطقی از شمارش‌گر [SchemeColor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/schemecolor/) ارجاع دهند. هنگامی که ورودی متناظر را در [ColorScheme](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/colorscheme/) تغییر می‌دهید، تمام اشیائی که هنوز به آن رنگ تم ارجاع می‌دهند نسبت به مقدار جدید حل می‌شوند. اشیائی که رنگ RGB مستقیم استفاده می‌کنند توسط به‌روزرسانی رنگ تم تغییر نخواهند کرد.

مثال کامل زیر یک شکل ایجاد می‌کند که از `Accent4` استفاده می‌کند، رنگ `Accent4` تم را به قرمز تغییر می‌دهد، ارائه را ذخیره می‌کند، دوباره باز می‌کند و رنگ پرکردن نهایی را چاپ می‌کند:

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

از آنجا که مستطیل به `Accent4` متصل می‌ماند، رنگ قابل مشاهده آن پس از تغییر تم به قرمز می‌شود. اگر رنگ طرح را با یک رنگ مستقیم بر روی شکل جایگزین کنید، تغییرات بعدی `Accent4` دیگر بر آن پرکردن تأثیر نخواهد گذاشت.

### **استفاده از رنگ‌ها از پالت اضافی**

PowerPoint با اعمال تبدیلات رنگ، نسخه‌های روشن‌تر و تیره‌تر را از یک رنگ تم استخراج می‌کند. Aspose.Slides این تبدیلات را از طریق شمارش‌گر [ColorTransformOperation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/colortransformoperation/) در دسترس می‌گذارد.

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - رنگ‌های اصلی تم.  
**2** - نسخه‌های روشن‌تر و تیره‌تر تولید‌شده از رنگ‌های اصلی تم.

مثال زیر شش مستطیل بر پایه `Accent4` ایجاد می‌کند، برای پنج تا از آنها تبدیلات درخشانی را اعمال می‌کند و نتیجه را ذخیره می‌نماید:

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

این نسخه‌ها همچنان بر پایه رنگ تم باقی می‌مانند. اگر `Accent4` بعدها تغییر کند، رنگ‌های تبدیل‌شده از مقدار جدید `Accent4` محاسبه مجدداً می‌شوند.

### **نقشه‌برداری مقادیر `SchemeColor` به خانه‌های `ColorScheme`**

شمارش‌گر [SchemeColor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/schemecolor/) از `Text1`، `Background1`، `Text2` و `Background2` استفاده می‌کند، در حالی که [ColorScheme](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/colorscheme/) همان اسلات‌های تم را به‌عنوان `Dark1`، `Light1`، `Dark2` و `Light2` در معرض نمایش می‌گذارد. نقشه‌بندی ثابت است:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

این‌ها نام‌های جایگزین برای همان اسلات‌های تم هستند؛ آنها مقادیری نیستند که به‌صورت پویا از یک فرم به فرم دیگر تبدیل شوند.

## **تغییر قلم‌های تم**

یک طرح قلم تم شامل یک مجموعهٔ اصلی برای عناوین و یک مجموعهٔ فرعی برای متن بدنه است. توابع [FontScheme.getMajor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontscheme/) و [FontScheme.getMinor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontscheme/) این مجموعه‌ها را در معرض نمایش می‌گذارند.

شناسه‌های قلم تم سازگار با PowerPoint می‌توانند در قالب‌بندی متن استفاده شوند:

* `+mn-lt` - قلم بدنه لاتین (Minor Latin Font)
* `+mj-lt` - قلم عنوان لاتین (Major Latin Font)
* `+mn-ea` - قلم بدنه آسیای شرقی (Minor East Asian Font)
* `+mj-ea` - قلم عنوان آسیای شرقی (Major East Asian Font)

مثال زیر یک عنوان که از قلم لاتین اصلی تم استفاده می‌کند و یک خط بدنه که از قلم لاتین فرعی تم استفاده می‌کند ایجاد می‌کند. سپس قلم‌های تم را تغییر داده و نتیجه را ذخیره می‌نماید:

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

عنوان از قلم اصلی پیروی می‌کند و متن بدنه از قلم فرعی. متنی که به‌جای شناسهٔ تم نام قلم صریح دارد، به‌صورت خودکار هنگام تغییر طرح قلم تم تغییر نخواهد کرد.

مجموعه‌های قلم اصلی و فرعی می‌توانند شامل نگاشت‌های قلم برای سیستم‌های نوشتاری خاص مانند سیریلیک، عربی، ژاپنی، گرجی و ثان هم باشند. برای بازرسی، افزودن، جایگزین یا حذف این نگاشت‌ها، به [Script-Specific Theme Fonts](/slides/fa/nodejs-java/script-specific-font-mappings/) مراجعه کنید.

{{% alert color="info" title="Tip" %}}برای اطلاعات بیشتر درباره قلم‌های ارائه، به [PowerPoint Fonts](/slides/fa/nodejs-java/powerpoint-fonts/) نگاه کنید.{{% /alert %}}

## **کپی یا اعمال یک تم**

جریان‌های کاری زیر مشکلات مختلف مرتبط با تم را حل می‌کنند.

### **اعمال تم خارجی به اسلایدهای وابسته به یک مستر**

از [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterslide/) وقتی فایل تم PowerPoint (`.thmx`) دارید و می‌خواهید تمام اسلایدهایی که به مستر خاصی وابسته‌اند را بازطراحی کنید، استفاده کنید. مستر را از مجموعهٔ [Presentation.getMasters](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) که توسط [MasterSlideCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterslidecollection/) نمایان می‌شود، انتخاب کنید و مسیر فایل تم را به متد پاس دهید.

متد عملیات زیر را انجام می‌دهد:

1. یک اسلاید مستر جدید بر پایه مستر انتخاب‌شده می‌سازد.  
1. تم خارجی را به مستر جدید اعمال می‌کند.  
1. مستر جدید را به تمام اسلایدهایی که پیش‌تر به مستر انتخاب‌شده وابسته بودند، اختصاص می‌دهد.  
1. شیء [MasterSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterslide/) تازه ایجاد‑شده را برمی‌گرداند.

مثال زیر تم خارجی را بر اسلایدهایی که به اولین مستر وابسته‌اند اعمال می‌کند و ارائه را ذخیره می‌نماید:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const selectedMaster = presentation.getMasters().get_Item(0);
    const themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    console.log("Created master: " + themedMaster.getName());
    presentation.save("presentation-with-external-theme.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

یک تم نامعتبر، خراب یا نام پشتیبانی‌شده می‌تواند موجب [PptxReadException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pptxreadexception/) شود. مسیرهای ارائه‌شده توسط کاربران را اعتبارسنجی کنید، شکست‌های دسترسی به سیستم‌فایل را مدیریت کنید و تنها پس از اعمال موفقیت‌آمیز تم، ارائه را ذخیره کنید.

فقط اسلایدهایی که به مستر انتخاب‌شده وابسته بودند، مجدداً اختصاص می‌یابند. اسلایدهای مرتبط با مسترهای دیگر مستر و تم‌های موجود خود را حفظ می‌کنند. رنگ‌ها، قلم‌ها، پرکردن‌ها، خطوط، پس‌زمینه‌ها و افکت‌های آگاه به تم نسبت به تم خارجی حل می‌شوند. رنگ‌ها، قلم‌ها، پرکردن‌ها و فرمت‌های صریحی که مستقیماً اختصاص داده شده‌اند ممکن است بدون تغییر بمانند. بازنویسی‌های سطح لایه و اسلاید نیز می‌توانند بر مقادیر وارث‌شده از مستر جدید اولویت داشته باشند.

تم می‌تواند قلم‌هایی را ارجاع دهد که در محیط اجرایی موجود نیستند. برای رندرینگ و خروجی سازگار، قلم‌های لازم را نصب کنید، از [منابع قلم سفارشی](/slides/fa/nodejs-java/custom-font/) استفاده کنید یا [جایگزینی قلم](/slides/fa/nodejs-java/font-substitution/) را پیکربندی کنید.

این یک جریان کاری مستقیم سطح مستر است: متد مسیر فایلی با پسوند `.thmx` را می‌پذیرد و نیازی به ایجاد دستی بازنویسی‌های تم سطح اسلاید یا لایه ندارد.

### **اعمال تم‌های خارجی متفاوت در یک ارائه چندمستری**

وقتی مستر مرتبط از پیش شناخته نشده باشد، از طریق [Slide.getLayoutSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/) و [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutslide/) یک نماینده اسلاید به دست آورید. پیش از اعمال هر تمی، ارجاع‌های اصلی مستر را ذخیره کنید، زیرا هر فراخوانی یک مستر دیگر در ارائه ایجاد می‌کند.

مثال زیر از اسلایدهای دو بخش برای یافتن مسترهایشان استفاده می‌کند و برای هر گروه تم خارجی متفاوتی اعمال می‌نماید:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        console.log("The presentation does not contain the expected representative slides.");
    } else {
        const firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        const secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() === secondGroupMaster.getSlideId()) {
            console.log("The representative slides use the same master.");
        } else {
            const firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            const secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            console.log("First themed master: " + firstThemedMaster.getName());
            console.log("Second themed master: " + secondThemedMaster.getName());
            presentation.save("multi-master-with-external-themes.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

فراخوانی اول فقط اسلایدهایی را تحت تأثیر `firstGroupMaster` تغییر می‌دهد و فراخوانی دوم فقط اسلایدهایی را تحت تأثیر `secondGroupMaster` تغییر می‌دهد. اسلایدهای متعلق به هر مستر دیگر بازطراحی نمی‌شوند.

### **حفظ تم منبع هنگام جابه‌جایی اسلایدها**

اگر می‌خواهید اسلایدی را به ارائه دیگری انتقال دهید و طراحی اصلی آن را حفظ کنید، مستر منبع را با [MasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterslidecollection/) به ارائه هدف اضافه کنید، سپس اسلاید را با [SlideCollection.addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidecollection/) و مستر کلون‌شده کپی کنید. این کار مستر، لایه‌های آن و تم مرتبط را به‌هم پیوسته می‌سازد.

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

این جریان کاری ترجیحاً وقتی اسلاید منبع باید دقیقاً همان ظاهر را در مقصد داشته باشد، استفاده می‌شود. فقط کپی محتوا به مستر مقصدی نامرتبط می‌تواند باعث تغییر رنگ‌ها، قلم‌ها، پس‌زمینه‌ها و افکت‌های مبتنی بر تم شود.

### **اعمال مقادیر تم به اسلاید موجود**

اگر اسلاید هدف باید بر روی مستر و لایهٔ فعلی خود بماند، یک بازنویسی سطح اسلایدی از تم منبع اولیه کنید. متدهای [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/overridetheme/)، [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/overridetheme/) و [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/overridetheme/) سه مؤلفهٔ اصلی تم را به بازنویسی کپی می‌کنند.

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

این کار تم استفاده‌شده توسط آن اسلاید را بدون تغییر تم وارث‌شده توسط اسلایدهای دیگر تغییر می‌دهد. برای حذف بازنویسی محلی و بازگشت به مقادیر وارث‌شده، [OverrideTheme.clear](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/overridetheme/) را فراخوانی کنید.

### **اعمال بازنویسی تم به یک لایه**

یک بازنویسی سطح لایه بر اسلایدهایی که از آن لایه استفاده می‌کنند اعمال می‌شود، مگر اینکه اسلاید خاصی بازنویسی جداگانه داشته باشد. همان متدهای اولیه می‌توانند از طریق [LayoutSlideThemeManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutslidethememanager/) استفاده شوند:

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

زمانی که بسیاری از لایه‌ها و اسلایدها باید همان طراحی پایه را به اشتراک بگذارند، از تم سطح مستر یا ارائه استفاده کنید؛ زمانی که یک خانوادهٔ لایه نیاز به استایل متفاوت دارد، از بازنویسی لایه؛ و فقط برای استثناهای واقعی از بازنویسی اسلایدی استفاده کنید. بازنویسی‌های بیش از حد سطح اسلاید، اعمال تغییرات سراسری تم را در آینده دشوار می‌کند.

## **به‌روزرسانی سبک‌های پس‌زمینه تم**

پرکردن‌های پس‌زمینهٔ تم در [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/formatscheme/) ذخیره می‌شوند. PowerPoint می‌تواند گزینه‌های پس‌زمینه بیشتری در رابط کاربری خود نمایش دهد نسبت به تعداد تعاریف پرکردن فیزیکی موجود در این مجموعه، چرا که رابط می‌تواند پرکردن‌های تم را با رنگ‌های تم و مراجع سبک دیگر ترکیب کند.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

پیش از استفاده از یک سبک پس‌زمینه، مجموعهٔ ذخیره‌شده و مقدار فعلی [Background.getStyleIndex](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/background/) را بازرسی کنید. یک ایندکس سبک `0` به این معنی است که هیچ پرکردن تمی وجود ندارد؛ مقادیر مثبت به مراجع سبک پس‌زمینهٔ تم اشاره می‌کنند. این متفاوت از ایندکس‌گذاری مستقیم مجموعهٔ جاوااسکریپت است که در آن `0` اولین مورد ذخیره‌شده را نشان می‌دهد. فرض نکنید که هر ارائه همان تعداد سبک پرکردن پس‌زمینه را دارد.

مثال زیر تعداد پرکردن‌های پس‌زمینهٔ موجود را گزارش می‌کند، یک مرجع پس‌زمینه تمی به اولین مستر اختصاص می‌دهد و ارائه را ذخیره می‌کند:

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

نتیجهٔ قابل مشاهده به ورودی تمی که مستر به آن ارجاع می‌دهد و هر بازنویسی پس‌زمینه در سطح لایه یا اسلاید بستگی دارد. اگر اسلاید پس‌زمینهٔ خودش را داشته باشد، تغییر تنها پس‌زمینهٔ مستر ممکن است بر آن اسلید تأثیر نگذارد. برای دانستن پس‌زمینهٔ نهایی پس از اعمال وراثت، از [Background.getEffective](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/background/) استفاده کنید.

{{% alert color="warning" title="Warning" %}}ایندکس سبک را به‌عنوان یک ایندکس صفرپایهٔ مجموعه در نظر نگیرید. همچنین از استفادهٔ ثابت یک عدد سبک از یک فایل و فرض کردن ظاهر یکسان آن در فایل دیگر خودداری کنید؛ تعاریف سبک تم برای هر ارائه متفاوت است.{{% /alert %}}

{{% alert color="info" title="Tip" %}}برای قالب‌بندی مستقیم پس‌زمینه و وراثت پس‌زمینه، به [Presentation Background](/slides/fa/nodejs-java/presentation-background/) مراجعه کنید.{{% /alert %}}

## **به‌روزرسانی افکت‌های تم**

یک طرح فرمت تم مجموعه‌های جداگانهٔ پرکردن، خط و افکت را از طریق [FormatScheme.getFillStyles](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/formatscheme/)، [FormatScheme.getLineStyles](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/formatscheme/)، و [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/formatscheme/) در معرض نمایش می‌گذارد. تم‌های معمول اداری اغلب سه ورودی اصلی دارند که به‌صورت بصری به استایل‌های ملایم، متوسط و قوی متناظرند، اما کد باید هر مجموعه را بازرسی کند و به‌جای فرض تعداد ثابت، از موجودیت آن‌ها اطمینان حاصل کند.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

زمانی که این مجموعه‌ها را در JavaScript دسترسی می‌کنید، ایندکس مجموعه صفرپایه است: `0` اولین سبک ذخیره‌شده و `2` سومین سبک است. ایندکس‌های ارجاع‑سبک یک شکل مفهوم جداگانه‌ای هستند که از طریق [ShapeStyle](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapestyle/) در دسترس‌اند. تغییر یک سبک تم بر شکل‌هایی که به آن ارجاع می‌دهند تأثیر می‌گذارد؛ شکل‌هایی که فرمت‌گذاری مستقیم دارند ممکن است بدون تغییر بمانند.

مثال زیر بررسی می‌کند که ورودی‌های سبک لازم وجود دارند، اولین سبک خط را تغییر می‌دهد، سومین سبک پرکردن را تغییر می‌دهد، یک سایهٔ خارجی را در سومین سبک افکت فعال می‌کند و نتیجه را ذخیره می‌کند:

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

برای شکل‌هایی که به این اسلات‌ها ارجاع می‌دهند، اولین سبک خط تم قرمز می‌شود، سومین سبک پرکردن تم به سبز جنگلی سفت تغییر می‌کند و سومین سبک افکت یک سایهٔ خارجی با فاصلهٔ 10 نقطه به‌دست می‌آورد. نتیجهٔ بصری دقیق همچنان به این که هر شکل به کدام اسلات‌ها ارجاع می‌دهد و آیا فرمت‌گذاری مستقیم بر تم غالب است، بستگی دارد.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **خواندن مقادیر تم مؤثر**

اشیاء خام تم به شما می‌گویند که در سطح خاصی چه چیزی تعریف شده است. مقادیر مؤثر به شما می‌گویند که یک اسلاید یا شکل بعد از حل وراثت و بازنویسی‌های محلی واقعاً چه چیزی استفاده می‌کند. برای یک اسلاید، [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseoverridethememanager/) را فراخوانی کنید. برای یک پس‌زمینه، از [Background.getEffective](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/background/) و برای یک پرکردن، از [FillFormat.getEffective](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fillformat/) استفاده کنید.

مثال زیر تم مؤثر، پس‌زمینه و اولین پرکردن شکل را از یک اسلاید می‌خواند:

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

از داده‌های مؤثر برای تشخیص رندر، اعتبارسنجی و مقایسه‌ها استفاده کنید. اگر فقط [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/getmastertheme/) را بازرسی کنید، ممکن است یک بازنویسی مستر، لایه، اسلاید یا شکل را که ظاهر نهایی را تغییر می‌دهد، از دست بدهید.

## **پرسش‌های متداول**

**آیا اعمال تم خارجی بر تمام اسلایدهای ارائه تأثیر می‌گذارد؟**  
خیر. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterslide/) فقط اسلایدهایی را که به مستر منتخب وابسته‌اند، دوباره اختصاص می‌دهد. اسلایدهایی که از مسترهای دیگر استفاده می‌کنند تم‌های موجود خود را حفظ می‌کنند.

**آیا می‌توانم تم را بر روی یک اسلاید واحد بدون تغییر مستر اعمال کنم؟**  
بله. از [SlideThemeManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidethememanager/) اسلاید استفاده کنید و تم بازنویسی آن را مقداردهی اولیه کنید. تغییر فقط برای آن اسلاید محلی می‌ماند؛ اسلایدهای دیگر تم‌های موجود خود را وارث می‌گیرند.

**امن‌ترین روش برای انتقال تم از یک ارائه به ارائهٔ دیگر چیست؟**  
وقتی اسلایدی را جابجا می‌کنید و می‌خواهید ظاهر منبع را حفظ کنید، مستر منبع را با [MasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterslidecollection/) به مقصد اضافه کنید و سپس اسلاید را با همان مستر با [SlideCollection.addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidecollection/) کلون کنید. این کار مستر، لایه‌ها و تم را با هم نگه می‌دارد.

**چگونه می‌توانم مقادیر مؤثر را پس از وراثت و بازنویسی‌ها ببینم؟**  
از [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseoverridethememanager/) برای تم اسلاید یا لایه استفاده کنید و متدهای داده‌های مؤثر مربوطه را برای اشیاء فرمت مانند [Background.getEffective](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/background/) و [FillFormat.getEffective](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fillformat/) فراخوانی کنید. این APIها مقادیر حل‑شده پس از اعمال وراثت و بازنویسی‌ها را برمی‌گردانند.