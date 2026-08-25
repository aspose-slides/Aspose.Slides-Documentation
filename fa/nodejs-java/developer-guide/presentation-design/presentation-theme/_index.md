---
title: مدیریت تم‌های ارائه در JavaScript
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
- رنگ تم
- پالت اضافه
- قلم تم
- سبک تم
- افکت تم
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "تم‌های اصلی ارائه در JavaScript با Aspose.Slides برای Node.js جهت ایجاد، سفارشی‌سازی و تبدیل فایل‌های PowerPoint با برندینگ یکسان."
---
## **مقدمه**

یک تم ارائه مجموعه‌ای هماهنگ از رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه، پرکننده‌ها، خطوط و افکت‌ها را تعریف می‌کند. اشیای آگاه از تم به این تعاریف مشترک ارجاع می‌دهند به جای ذخیره هر ویژگی بصری به عنوان مقدار ثابت، بنابراین تغییر تم می‌تواند بسیاری از اشیا را به‌صورت همزمان به‌روزرسانی کند.

در Aspose.Slides، تم سطح ارائه از طریق [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/getmastertheme/) در دسترس است. یک ارائه می‌تواند بازنویسی‌های تم را در سطوح پایین‌تر نیز داشته باشد. یک مستر می‌تواند تم ارائه را از طریق [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterthememanager/) بازنویسی کند، در حالی که یک طرح‌بندی یا یک اسلاید منفرد می‌تواند تم وارث خود را از طریق [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseoverridethememanager/) بازنویسی کند. در عمل، تم مؤثر برای یک اسلاید از طریق این زنجیره وراثت حل می‌شود: تم ارائه، بازنویسی مستر، بازنویسی طرح‌بندی و بازنویسی اسلاید.

![اجزاء تم: رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه و افکت‌ها](theme-constituents.png)

بخش‌های زیر رایج‌ترین جریان‌های کار با تم را نشان می‌دهند: بازرسی یک تم، تغییر رنگ‌ها و قلم‌ها، کپی یا اعمال تم، به‌روزرسانی سبک‌های پس‌زمینه و افکت، و خواندن مقادیر مؤثر پس از حل وراثت و بازنویسی‌ها.

## **بازرسی یک تم**

شیء [MasterTheme](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/mastertheme/) طرح رنگ، طرح قلم و طرح قالب تم را از طریق [MasterTheme.getColorScheme](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/mastertheme/)، [MasterTheme.getFontScheme](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/mastertheme/) و [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/mastertheme/) در دسترس می‌کند. بازرسی این مجموعه‌ها پیش از تغییر آن‌ها به‌ویژه زمانی که یک ارائه از منبع خارجی می‌آید مفید است، زیرا تعداد و محتوای ورودی‌های سبک می‌تواند متفاوت باشد.

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

اگر فایلی از چند مستر استفاده کند، فرض نکنید که هر اسلاید همان تم مؤثر را دارد. مستری که به اسلاید مرتبط است را بازرسی کنید و از جریان کار تم مؤثر که در ادامه این مقاله نشان داده شده استفاده کنید وقتی که بازنویسی‌های طرح‌بندی یا اسلاید وجود دارد.

## **تغییر رنگ‌های تم**

پرکننده‌ها، خطوط و متن‌های آگاه از تم می‌توانند به یک رنگ منطقی از مجموعه [SchemeColor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/schemecolor/) ارجاع دهند. وقتی ورودی متناظر در [ColorScheme](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/colorscheme/) را تغییر می‌دهید، همه اشیایی که هنوز به آن رنگ تم ارجاع می‌دهند نسبت به مقدار جدید حل می‌شوند. اشیایی که از رنگ RGB مستقیم استفاده می‌کنند توسط به‌روزرسانی رنگ تم تغییر نمی‌کنند.

مثال انتها‑به‑انتها زیر یک شکل ایجاد می‌کند که از `Accent4` استفاده می‌کند، رنگ `Accent4` تم را به قرمز تغییر می‌دهد، ارائه را ذخیره می‌کند، دوباره باز می‌کند و رنگ پرکننده مؤثر را چاپ می‌کند:

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

چون مستطیل به `Accent4` متصل می‌ماند، رنگ قابل مشاهده‌اش پس از تغییر تم به قرمز می‌شود. اگر رنگ طرح را با یک رنگ مستقیم روی شکل جایگزین کنید، تغییرات بعدی `Accent4` دیگر بر آن پرکننده تأثیر نخواهد داشت.

### **استفاده از رنگ‌ها از پالت اضافه**

PowerPoint انواع روشن‌تر و تیره‌تر را از یک رنگ تم با اعمال تبدیل‌های رنگی استخراج می‌کند. Aspose.Slides این تبدیل‌ها را از طریق مجموعه [ColorTransformOperation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/colortransformoperation/) در دسترس می‌گذارد.

![رنگ‌های اصلی تم و رنگ‌های روشن‌تر و تیره‌تر تولید شده از پالت اضافه](additional-palette-colors.png)

**1** - رنگ‌های اصلی تم.  
**2** - انواع روشن‌تر و تیره‌تر تولید شده از رنگ‌های اصلی تم.

مثال زیر شش مستطیل بر پایه `Accent4` ایجاد می‌کند، به پنج تا از آن‌ها تبدیل‌های روشنایی اعمال می‌کند و نتیجه را ذخیره می‌کند:

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

این انواع بر پایه رنگ تم باقی می‌مانند. اگر `Accent4` بعدها تغییر کند، رنگ‌های تبدیل‌شده از مقدار جدید `Accent4` بازمحاسبه می‌شوند.

### **نقشه‌برداری مقادیر `SchemeColor` به اسلات‌های `ColorScheme`**

مجموعه [SchemeColor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/schemecolor/) از `Text1`، `Background1`، `Text2` و `Background2` استفاده می‌کند، در حالی که [ColorScheme](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/colorscheme/) همان اسلات‌های تم را به صورت `Dark1`، `Light1`، `Dark2` و `Light2` ارائه می‌دهد. نگاشت ثابت است:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

این‌ها نام‌های جایگزین برای همان اسلات‌های تم هستند؛ آن‌ها مقادیری نیستند که به‌صورت پویا از یک فرم به فرم دیگر تبدیل شوند.

## **تغییر فونت‌های تم**

یک طرح قلم تم شامل یک مجموعه قلم اصلی برای عناوین و یک مجموعه قلم فرعی برای متن اصلی است. روش‌های [FontScheme.getMajor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontscheme/) و [FontScheme.getMinor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontscheme/) این مجموعه‌ها را در دسترس می‌گذارند.

شناسه‌های فونت تم سازگار با PowerPoint می‌توانند در قالب‌بندی متن استفاده شوند:

* `+mn-lt` - قلم بدن لاتین (Minor Latin Font)
* `+mj-lt` - قلم عنوان لاتین (Major Latin Font)
* `+mn-ea` - قلم بدن آسیای شرقی (Minor East Asian Font)
* `+mj-ea` - قلم عنوان آسیای شرقی (Major East Asian Font)

مثال زیر یک عنوان ایجاد می‌کند که از قلم لاتین اصلی تم استفاده می‌کند و یک خط بدنه که از قلم لاتین فرعی تم استفاده می‌کند. سپس فونت‌های تم را تغییر می‌دهد و نتیجه را ذخیره می‌کند:

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

عنوان از قلم اصلی پیروی می‌کند و متن بدنه از قلم فرعی پیروی می‌کند. متنی که یک نام قلم صریح به‌جای شناسه تم داشته باشد، زمانی که طرح قلم تم تغییر کند به‌صورت خودکار سوئیچ نمی‌شود.

مجموعه‌های قلم اصلی و فرعی می‌توانند شامل نگاشت‌های قلم برای سیستم‌های نوشتاری جداگانه مانند سیریلیک، عربی، ژاپنی، گرجی و ثانا نیز باشند. برای بازرسی، افزودن، جایگزینی یا حذف این نگاشت‌ها، به [فونت‌های تم مخصوص اسکریپت](/slides/fa/nodejs-java/script-specific-font-mappings/) مراجعه کنید.

{{% alert color="info" title="Tip" %}}
برای اطلاعات بیشتر درباره فونت‌های ارائه، به [فونت‌های PowerPoint](/slides/fa/nodejs-java/powerpoint-fonts/) مراجعه کنید.
{{% /alert %}}

## **کپی یا اعمال تم**

دو جریان کار رایج وجود دارد که هر کدام مشکل متفاوتی را حل می‌کنند.

### **حفظ یک تم منبع هنگام جابجایی اسلایدها**

اگر می‌خواهید اسلایدی را به ارائهٔ دیگری منتقل کنید و طراحی اصلی آن را حفظ نمایید، مستر منبع را با استفاده از [MasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterslidecollection/) به ارائهٔ هدف اضافه کنید، سپس اسلاید را با استفاده از [SlideCollection.addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidecollection/) و مستر کلون شده کپی کنید. این کار مستر، طرح‌بندی‌های آن و تم مرتبط را به‌صورت یکجا منتقل می‌کند.

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

این جریان کار ترجیح داده می‌شود وقتی که اسلاید منبع باید در مقصد همان ظاهر را داشته باشد. تنها کپی محتوا روی مستر مقصد نامرتبط می‌تواند رنگ‌ها، قلم‌ها، پس‌زمینه‌ها و افکت‌های وابسته به تم را تغییر دهد.

### **اعمال مقادیر تم به یک اسلاید موجود**

اگر اسلاید هدف باید بر روی مستر و طرح‌بندی فعلی خود بماند، یک بازنویسی سطح اسلاید را از تم منبع مقداردهی اولیه کنید. روش‌های [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/overridetheme/)، [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/overridetheme/) و [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/overridetheme/) سه مؤلفهٔ اصلی تم را به بازنویسی کپی می‌کنند.

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

این کار تم استفاده‌شده توسط آن اسلاید را بدون تغییر تم وارث شده توسط سایر اسلایدها تغییر می‌دهد. برای حذف بازنویسی محلی و بازگشت به مقادیر وارث شده، [OverrideTheme.clear](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/overridetheme/) را فراخوانی کنید.

### **اعمال بازنویسی تم به یک طرح‌بندی**

یک بازنویسی سطح طرح‌بندی به اسلایدهایی که از آن طرح‌بندی استفاده می‌کنند اعمال می‌شود، مگر این‌که اسلاید خاصی بازنویسی خودش را داشته باشد. همان روش‌های مقداردهی اولیه می‌توانند از طریق [LayoutSlideThemeManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutslidethememanager/) استفاده شوند:

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

وقتی تعداد زیادی layout و اسلاید باید همان طراحی پایه را به اشتراک بگذارند، از تم سطح مستر یا ارائه استفاده کنید؛ وقتی یک خانوادهٔ layout به استایل متفاوتی نیاز دارد، از بازنویسی طرح‌بندی استفاده کنید؛ و فقط برای استثنای واقعی از بازنویسی اسلاید بهره بگیرید. بازنویسی‌های افراطی سطح اسلاید باعث می‌شود پیش‌بینی تغییرات تم‌های سراسری بعدی دشوارتر شود.

## **به‌روزرسانی استایل‌های پس‌زمینه تم**

پرکننده‌های پس‌زمینه تم در [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/formatscheme/) ذخیره می‌شوند. PowerPoint می‌تواند گزینه‌های پس‌زمینه بیشتری را در رابط کاربری خود نشان دهد نسبت به تعداد تعریف‌های پرکنندهٔ فیزیکی موجود در این مجموعه، زیرا رابط می‌تواند پرکننده‌های تم را با رنگ‌های تم و سایر مراجع سبک ترکیب کند.

![گالری سبک پس‌زمینه PowerPoint برای یک تم ارائه](presentation-design_8.png)

قبل از استفاده از یک سبک پس‌زمینه، مجموعهٔ ذخیره‌شده و مقدار فعلی [Background.getStyleIndex](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/background/) را بازرسی کنید. مقدار شاخص سبک `0` به این معنی است که هیچ پرکنندهٔ تمی وجود ندارد؛ مقادیر مثبت مراجع سبک پس‌زمینهٔ تم هستند. این متفاوت از ایندکس‌گذاری مستقیم مجموعهٔ JavaScript است، جایی که `0` اولین مورد ذخیره‌شده را نشان می‌دهد. فرض نکنید که هر ارائهٔ دیگری همان تعداد سبک پرکنندهٔ پس‌زمینه را دارد.

مثال زیر تعداد پرکننده‌های پس‌زمینهٔ موجود را گزارش می‌کند، یک مرجع پس‌زمینهٔ تم را به اولین مستر اختصاص می‌دهد و ارائه را ذخیره می‌کند:

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

نتیجهٔ قابل مشاهده به ورودی تمی که توسط مستر ارجاع داده می‌شود و به هر بازنویسی پس‌زمینهٔ موجود در سطح طرح‌بندی یا اسلاید بستگی دارد. اگر اسلاید پس‌زمینهٔ خود را داشته باشد، تغییر فقط پس‌زمینهٔ مستر ممکن است آن اسلاید را تغییر ندهد. وقتی نیاز به دانستن پس‌زمینهٔ نهایی پس از اعمال وراثت دارید، از [Background.getEffective](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/background/) استفاده کنید.

{{% alert color="warning" title="Warning" %}}
شاخص سبک را به‌عنوان ایندکس صفر‑پایهٔ مجموعه تفسیر نکنید. همچنین از کدگذاری عددی یک سبک از یک فایل و فرض اینکه در فایل دیگری همان ظاهر را دارد، خودداری کنید؛ تعاریف سبک تم خصوصیات خود ارائه هستند.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
برای قالب‌بندی مستقیم پس‌زمینه و وراثت پس‌زمینه، به [پس‌زمینهٔ ارائه](/slides/fa/nodejs-java/presentation-background/) مراجعه کنید.
{{% /alert %}}

## **به‌روزرسانی افکت‌های تم**

یک طرح قالب تم شامل مجموعه‌های جداگانهٔ پرکننده، خط و افکت است که از طریق [FormatScheme.getFillStyles](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/formatscheme/)، [FormatScheme.getLineStyles](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/formatscheme/) و [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/formatscheme/) در دسترس هستند. تم‌های معمولی Office اغلب شامل سه ورودی سبک اصلی هستند که از نظر بصری به ترتیب به سبک‌های ظریف، متوسط و قوی مربوط می‌شوند، اما کد باید هر مجموعه را بازرسی کند به‌جای این‌که شمارش ثابت فرض کند.

![افکت‌های تم ظریف، متوسط و قوی که بر یک شکل اعمال شده‌اند](presentation-design_11.png)

هنگامی که این مجموعه‌ها را در JavaScript دسترسی می‌یابید، ایندکس مجموعه صفر‑پایه است: `0` اولین سبک ذخیره‌شده و `2` سومین است. ایندکس‌های ارجاع به سبک در یک شکل مفهوم جداگانه‌ای دارند که از طریق [ShapeStyle](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapestyle/) در دسترس هستند. تغییر یک سبک تم بر اشکالی که به آن سبک ارجاع می‌دهند تاثیر می‌گذارد؛ اشکالی با قالب‌بندی مستقیم ممکن است بدون تغییر بمانند.

مثال زیر بررسی می‌کند که ورودی‌های سبک موردنیاز وجود دارند، اولین سبک خط را تغییر می‌دهد، سومین سبک پرکننده را تغییر می‌دهد، یک سایهٔ بیرونی را در سومین سبک افکت فعال می‌کند و نتیجه را ذخیره می‌کند:

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

برای اشکالی که به این اسلات‌ها ارجاع می‌دهند، اولین سبک خط تم قرمز می‌شود، سومین سبک پرکننده تم به سبز جنگلی سفت تبدیل می‌شود و سومین سبک افکت یک سایهٔ بیرونی با فاصلهٔ 10 نقطه می‌گیرد. نتیجهٔ بصری دقیق هنوز به این بستگی دارد که هر شکل به کدام اسلات‌ها ارجاع می‌دهد و آیا قالب‌بندی مستقیم قالب تم را بازنویسی می‌کند یا نه.

## **خواندن مقادیر مؤثر تم**

اشیای خام تم به شما می‌گویند چه چیزی در یک سطح خاص تعریف شده است. مقادیر مؤثر به شما می‌گویند یک اسلاید یا شکل پس از حل وراثت و بازنویسی‌های محلی چه چیزی را واقعاً استفاده می‌کند. برای یک اسلاید، [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseoverridethememanager/) را صدا بزنید. برای پس‌زمینه، از [Background.getEffective](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/background/) استفاده کنید و برای پرکننده از [FillFormat.getEffective](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fillformat/) استفاده کنید.

مثال زیر تم مؤثر، پس‌زمینه و پرکنندهٔ اولین شکل را از یک اسلاید می‌خواند:

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

از داده‌های مؤثر برای تشخیص رندر، اعتبارسنجی و مقایسه‌ها استفاده کنید. اگر فقط [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/getmastertheme/) را بازرسی کنید، ممکن است یک بازنویسی مستر، طرح‌بندی، اسلاید یا شکل که ظاهر نهایی را تغییر می‌دهد از دست بدهید.

## **سوالات متداول**

**آیا می‌توانم تم را فقط روی یک اسلاید اعمال کنم بدون تغییر مستر؟**

بله. از [SlideThemeManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidethememanager/) اسلاید استفاده کنید و تم بازنویسی‌شدهٔ آن را مقداردهی اولیه کنید. این تغییر به‌صورت محلی به همان اسلاید باقی می‌ماند؛ اسلایدهای دیگر به تم‌های موجود خود ادامه می‌دهند.

**ایمن‌ترین روش برای انتقال تم از یک ارائه به ارائهٔ دیگر چیست؟**

هنگام جابجایی یک اسلاید و حفظ ظاهر منبع، مستر منبع را به مقصد کلون کنید و اسلاید را با آن مستر با استفاده از [MasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterslidecollection/) و [SlideCollection.addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidecollection/) کلون کنید. این کار مستر، طرح‌بندی‌ها و تم را همراه هم نگه می‌دارد.

**چگونه می‌توانم مقادیر مؤثر را پس از وراثت و بازنویسی‌ها ببینم؟**

از [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseoverridethememanager/) برای یک اسلاید یا تم طرح‌بندی استفاده کنید و برای اشیاء قالب مانند [Background.getEffective](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/background/) و [FillFormat.getEffective](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fillformat/) از روش‌های دادهٔ مؤثر مربوطه استفاده کنید. این APIها مقادیر حل‌شده پس از اعمال وراثت و بازنویسی‌ها را برمی‌گردانند.