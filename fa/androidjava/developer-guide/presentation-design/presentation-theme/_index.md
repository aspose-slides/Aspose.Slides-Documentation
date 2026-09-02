---
title: مدیریت تم‌های ارائه در اندروید
linktitle: تم ارائه
type: docs
weight: 10
url: /fa/androidjava/presentation-theme/
keywords:
- تم پاورپوینت
- تم ارائه
- تم اسلاید
- تنظیم تم
- تغییر تم
- مدیریت تم
- رنگ تم
- پالت اضافه
- قلم تم
- سبک تم
- اثر تم
- پاورپوینت
- OpenDocument
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "تم‌های اصلی ارائه در Aspose.Slides برای اندروید از طریق جاوا برای ایجاد، سفارشی‌سازی و تبدیل فایل‌های پاورپوینت با برندینگ یکپارچه."
---
## **مقدمه**

یک تم ارائه مجموعهٔ هماهنگی از رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه، پرکننده‌ها، خطوط و افکت‌ها را تعریف می‌کند. اشیاء آگاه از تم به‌جای ذخیرهٔ هر ویژگی بصری به‌صورت مقدار ثابت، به این تعاریف مشترک ارجاع می‌دهند، بنابراین تغییر تم می‌تواند بسیاری از اشیاء را یک‌بار به‌روزرسانی کند.

در Aspose.Slides، تم سطح ارائه از طریق [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) در دسترس است. یک ارائه می‌تواند بازنویسی‌های تم را در سطوح پایین‌تر نیز داشته باشد. یک master می‌تواند تم ارائه را از طریق [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/masterthememanager/) بازنویسی کند، در حالی که یک layout یا یک اسلاید تک‌تک می‌تواند تم وارث شده خود را از طریق [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/baseoverridethememanager/) بازنویسی کند. در عمل، تم مؤثر برای یک اسلاید از طریق این زنجیرهٔ ارث‌بری حل می‌شود: تم ارائه، بازنویسی master، بازنویسی layout و بازنویسی اسلاید.

![مؤلفه‌های تم: رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه و افکت‌ها](theme-constituents.png)

بخش‌های زیر رایج‌ترین جریان‌های کاری تم را نشان می‌دهند: بازرسی یک تم، تغییر رنگ‌ها و قلم‌ها، کپی یا اعمال یک تم، به‌روزرسانی سبک‌های پس‌زمینه و افکت، و خواندن مقادیر مؤثر پس از حل ارث‌بری و بازنویسی‌ها.

## **بازرسی یک تم**

شیء [MasterTheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/mastertheme/) طرح رنگی، طرح قلمی و طرح قالب تم را از طریق [MasterTheme.getColorScheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/mastertheme/)، [MasterTheme.getFontScheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/mastertheme/) و [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/mastertheme/) در معرض نمایش می‌گذارد. بازرسی این مجموعه‌ها قبل از تغییر آن‌ها به‌ویژه زمانی مفید است که یک ارائه از منبع خارجی آمده باشد، زیرا تعداد و محتوای ورودی‌های سبک می‌تواند متفاوت باشد.

مثال زیر ویژگی‌های اصلی تم را می‌خواند و گزارش می‌دهد که چند سبک پس‌زمینه، پرکننده، خط و افکت در تم ذخیره شده‌اند:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    int accent1 = theme.getColorScheme().getAccent1().getColor();
    System.out.println("Theme name: " + theme.getName());
    System.out.println(String.format("Accent 1: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(accent1), Color.red(accent1), Color.green(accent1), Color.blue(accent1)));
    System.out.println("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    System.out.println("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    System.out.println("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    System.out.println("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

اگر فایلی از چند master استفاده کند، فرض نکنید هر اسلاید همان تم مؤثر را داشته باشد. master مرتبط با اسلاید را بازرسی کنید و از جریان کاری تم مؤثر که بعداً در این مقاله نشان داده شده است استفاده کنید زمانی که بازنویسی‌های layout یا اسلاید ممکن است وجود داشته باشند.

## **تغییر رنگ‌های تم**

پرکننده‌ها، خطوط و متن‌های آگاه از تم می‌توانند به یک رنگ منطقی از شمارش‌گر [SchemeColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/schemecolor/) ارجاع دهند. وقتی ورودی متناظر در [IColorScheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icolorscheme/) را تغییر می‌دهید، تمام اشیائی که هنوز به آن رنگ تم ارجاع می‌دهند، نسبت به مقدار جدید حل می‌شوند. اشیائی که از یک رنگ RGB مستقیم استفاده می‌کنند، با به‌روزرسانی رنگ تم تغییر نمی‌کنند.

مثال انتها‑به‑انتها زیر یک شکل ایجاد می‌کند که از `Accent4` استفاده می‌کند، رنگ `Accent4` تم را به قرمز تغییر می‌دهد، ارائه را ذخیره می‌کند، دوباره باز می‌کند و رنگ پرکننده مؤثر را چاپ می‌کند:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
    presentation.save("theme-color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("theme-color.pptx");
try {
    ISlide savedSlide = savedPresentation.getSlides().get_Item(0);
    IShape savedShape = savedSlide.getShapes().get_Item(0);
    IFillFormatEffectiveData effectiveFill = savedShape.getFillFormat().getEffective();
    int effectiveColor = effectiveFill.getSolidFillColor();
    System.out.println(String.format("Effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
} finally {
    savedPresentation.dispose();
}
```

از آنجا که مستطیل به `Accent4` مرتبط باقی می‌ماند، رنگ قابل مشاهده آن پس از تغییر تم به قرمز تبدیل می‌شود. اگر رنگ طرح را با یک رنگ مستقیم روی شکل جایگزین کنید، تغییرات بعدی `Accent4` دیگر آن پرکننده را تحت تأثیر قرار نمی‌دهد.

### **استفاده از رنگ‌ها از پالت اضافه**

PowerPoint با اعمال تبدیلات رنگی، متغیرهای روشن‌تر و تیره‌تر را از یک رنگ تم استخراج می‌کند. Aspose.Slides این تبدیلات را از طریق شمارش‌گر [ColorTransformOperation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/colortransformoperation/) در معرض نمایش می‌گذارد.

![رنگ‌های اصلی تم و رنگ‌های روشن‌تر و تیره‌تر تولید شده از پالت اضافه](additional-palette-colors.png)

**1** - رنگ‌های اصلی تم.

**2** - متغیرهای روشن‌تر و تیره‌تر تولید شده از رنگ‌های اصلی تم.

مثال زیر شش مستطیل بر پایه `Accent4` ایجاد می‌کند، برای پنج تا از آن‌ها تبدیلات روشنایی اعمال می‌کند و نتیجه را ذخیره می‌نماید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

این متغیرها بر پایه رنگ تم باقی می‌مانند. اگر `Accent4` بعداً تغییر کند، رنگ‌های تبدیل‌شده از مقدار جدید `Accent4` مجدداً محاسبه می‌شوند.

### **نقشه‌برداری مقادیر `SchemeColor` به اسلات‌های `IColorScheme`**

شمارش‌گر [SchemeColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/schemecolor/) از `Text1`، `Background1`، `Text2` و `Background2` استفاده می‌کند، در حالی که [IColorScheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icolorscheme/) همان اسلات‌های تم را به عنوان `Dark1`، `Light1`، `Dark2` و `Light2` در دسترس می‌گذارد. نقشه ثابت است:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

این‌ها نام‌های جایگزین برای همان اسلات‌های تم هستند؛ آن‌ها مقادیری نیستند که به‌صورت پویا از یک فرم به فرم دیگر تبدیل شوند.

## **تغییر قلم‌های تم**

یک طرح قلمی تم شامل یک مجموعه قلم اصلی برای سرفصل‌ها و یک مجموعه قلم فرعی برای متن بدنه است. متدهای [IFontScheme.getMajor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifontscheme/) و [IFontScheme.getMinor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifontscheme/) این مجموعه‌ها را در معرض نمایش می‌گذارند.

شناسه‌های قلم تم سازگار با PowerPoint می‌توانند در قالب‌بندی متن استفاده شوند:

* `+mn-lt` - قلم بدنه لاتین (Minor Latin Font)
* `+mj-lt` - قلم سرفصل لاتین (Major Latin Font)
* `+mn-ea` - قلم بدنه آسیای شرقی (Minor East Asian Font)
* `+mj-ea` - قلم سرفصل آسیای شرقی (Major East Asian Font)

مثال زیر یک سرفصل که از قلم لاتین اصلی تم استفاده می‌کند و یک خط بدنه که از قلم لاتین فرعی تم استفاده می‌کند، ایجاد می‌کند. سپس قلم‌های تم را تغییر می‌دهد و نتیجه را ذخیره می‌کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mj-lt"));

    IAutoShape body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

سرفصل از قلم اصلی پیروی می‌کند و متن بدنه از قلم فرعی. متنی که دارای نام قلم صریح به‌جای شناسهٔ تم باشد، به‌صورت خودکار تغییر نمی‌کند وقتی طرح قلمی تم تغییر یابد.

مجموعه‌های قلم اصلی و فرعی می‌توانند شامل نگاشت‌های قلم برای سیستم‌های نوشتاری مختلف مانند سیریلی، عربی، ژاپنی، گرجی و ثانا باشند. برای بازرسی، افزودن، جایگزینی یا حذف این نگاشت‌ها، به بخش [Script‑Specific Theme Fonts](/slides/fa/androidjava/script-specific-font-mappings/) مراجعه کنید.

{{% alert color="info" title="نکته" %}}
برای اطلاعات بیشتر درباره قلم‌های ارائه، به [PowerPoint Fonts](/slides/fa/androidjava/powerpoint-fonts/) مراجعه کنید.
{{% /alert %}}

## **کپی یا اعمال یک تم**

دو جریان کاری رایج وجود دارد که هر کدام مشکل متفاوتی را حل می‌کنند.

### **حفظ تم منبع هنگام جابجایی اسلایدها**

اگر می‌خواهید یک اسلاید را به ارائهٔ دیگری منتقل کنید و طراحی اصلی آن را حفظ نمایید، master منبع را با استفاده از [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterslidecollection/) به ارائه هدف اضافه کنید، سپس اسلاید را با [ISlideCollection.addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidecollection/) و master کلون‌شده کپی کنید. این کار master، لایه‌های آن و تم مرتبط را همراه‌هم می‌برد.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide sourceSlide = source.getSlides().get_Item(0);
        IMasterSlide sourceMaster = sourceSlide.getLayoutSlide().getMasterSlide();
        IMasterSlide clonedMaster = target.getMasters().addClone(sourceMaster);
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

این جریان کاری زمانی ترجیح داده می‌شود که اسلاید منبع باید در مقصد همان ظاهر را داشته باشد. ساده‌سازی محتوا روی master مقصدی نامرتبط می‌تواند رنگ‌ها، قلم‌ها، پس‌زمینه‌ها و افکت‌های مبتنی بر تم را تغییر دهد.

### **اعمال مقادیر تم به یک اسلاید موجود**

اگر اسلاید هدف باید روی master و layout فعلی خود بماند، یک بازنویسی سطح اسلاید را از تم منبع مقداردهی اولیه کنید. متدهای [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/overridetheme/)، [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/overridetheme/) و [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/overridetheme/) سه بخش اصلی تم را به بازنویسی کپی می‌کنند.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
        IOverrideTheme overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

این کار تم استفاده‌شده توسط آن اسلاید را بدون تغییر تم وارث‌شده توسط سایر اسلایدها تغییر می‌دهد. برای حذف بازنویسی محلی و بازگشت به مقادیر وارث‌شده، متد [OverrideTheme.clear](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/overridetheme/) را فراخوانی کنید.

### **اعمال بازنویسی تم به یک Layout**

یک بازنویسی سطح layout بر اسلایدهایی که از آن layout استفاده می‌کنند اعمال می‌شود مگر این که اسلاید خاص خود بازنویسی داشته باشد. همان متدهای مقداردهی اولیه می‌توانند از طریق [LayoutSlideThemeManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/layoutslidethememanager/) استفاده شوند:

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
        ILayoutSlide targetLayout = targetSlide.getLayoutSlide();
        IOverrideTheme overrideTheme = targetLayout.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

از تم master یا سطح ارائه استفاده کنید زمانی که بسیاری از layoutها و اسلایدها باید همان طراحی پایه را به اشتراک بگذارند، یک بازنویسی layout زمانی استفاده شود که یک خانواده layout نیاز به استایل متفاوت داشته باشد، و یک بازنویسی اسلاید فقط برای استثناهای واقعی. بازنویسی‌های بیش از حد در سطح اسلاید، اعمال تغییرات سراسری تم بعدی را دشوار می‌کند.

## **به‌روزرسانی سبک‌های پس‌زمینه تم**

سبک‌های پرکننده پس‌زمینه تم در [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iformatscheme/) ذخیره می‌شوند. PowerPoint می‌تواند گزینه‌های پس‌زمینه بیشتری در UI خود نشان دهد نسبت به تعداد تعاریف پرکننده‌ای که فیزیکی در این مجموعه ذخیره شده‌اند، زیرا UI می‌تواند پرکننده‌های تم را با رنگ‌های تم و سایر ارجاعات سبک ترکیب کند.

![گالری سبک پس‌زمینهٔ PowerPoint برای تم یک ارائه](presentation-design_8.png)

قبل از استفاده از یک سبک پس‌زمینه، مجموعه ذخیره‌شده و مقدار فعلی [Background.getStyleIndex](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/background/) را بازرسی کنید. یک شاخص سبک برابر با `0` به معنی عدم وجود پرکنندهٔ تم است؛ مقادیر مثبت ارجاع‌های سبک پس‌زمینهٔ تم هستند. این متفاوت از ایندکس‌گذاری مستقیم مجموعهٔ Java است، جایی که `get_Item(0)` اولین آیتم ذخیره‌شده را نشان می‌دهد. فرض نکنید هر ارائه همان تعداد سبک پرکننده پس‌زمینه دارد.

مثال زیر تعداد پرکننده‌های پس‌زمینهٔ موجود را گزارش می‌کند، یک ارجاع پس‌زمینهٔ تم به اولین master اختصاص می‌دهد و ارائه را ذخیره می‌کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IFillFormatCollection backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    System.out.println("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() == 0) {
        throw new IllegalStateException("The presentation theme does not contain background fill styles.");
    }

    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(BackgroundType.Themed);
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجهٔ قابل مشاهده به تم‌ای که توسط master ارجاع داده شده و هر بازنویسی پس‌زمینه‌ای در سطح layout یا اسلاید بستگی دارد. اگر اسلاید پس‌زمینهٔ خود را داشته باشد، تغییر فقط پس‌زمینهٔ master ممکن است آن اسلاید را تحت تأثیر قرار ندهد. برای دانستن پس‌زمینهٔ نهایی پس از اعمال ارث‌بری، از [Background.getEffective](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/background/) استفاده کنید.

{{% alert color="warning" title="هشدار" %}}
شاخص سبک را به‌عنوان یک ایندکس صفر‑محور مجموعه در نظر نگیرید. همچنین از کدنویسی ثابت عدد سبک از یک فایل و انتظار داشتن ظاهر یکسان در فایل دیگر خودداری کنید؛ تعاریف سبک تم به ارائه خاص مربوط می‌شود.
{{% /alert %}}

{{% alert color="info" title="نکته" %}}
برای قالب‌بندی مستقیم پس‌زمینه و ارث‌بری پس‌زمینه، به [Presentation Background](/slides/fa/androidjava/presentation-background/) مراجعه کنید.
{{% /alert %}}

## **به‌روزرسانی افکت‌های تم**

یک طرح قالب تم شامل مجموعه‌های جداگانهٔ پرکننده، خط و افکت است که از طریق [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iformatscheme/)، [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iformatscheme/) و [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iformatscheme/) در دسترس هستند. تم‌های معمولی Office اغلب سه ورودی اصلی دارند که بصورت بصری به فرمت‌های Subtle، Moderate و Intense متناظر هستند، اما کد باید هر مجموعه را بازرسی کند به‌جای فرض تعداد ثابت.

![افکت‌های تم Subtle، Moderate و Intense که بر همان شکل اعمال شده‌اند](presentation-design_10.png)

هنگام دسترسی به این مجموعه‌ها در Java، ایندکس مجموعه صفر‑محور است: `get_Item(0)` اولین سبک ذخیره‌شده و `get_Item(2)` سومین است. ایندکس‌های مرجع سبک یک شکل مفهوم جداگانه‌ای هستند که از طریق [IShapeStyle](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapestyle/) در دسترس‌اند. تغییر یک سبک تم بر شکل‌هایی که به آن سبک ارجاع می‌دهند اثر می‌گذارد؛ شکل‌هایی که قالب‌بندی مستقیم دارند ممکن است بدون تغییر باقی بمانند.

مثال زیر بررسی می‌کند که ورودی‌های سبک لازم وجود دارند، اولین سبک خط را تغییر می‌دهد، سومین سبک پرکننده را تغییر می‌دهد، یک سایهٔ خارجی را در سومین سبک افکت فعال می‌کند و نتیجه را ذخیره می‌کند:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.rgb(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای شکل‌هایی که این اسلات‌ها را ارجاع می‌دهند، اولین سبک خط تم به قرمز، سومین سبک پرکننده تم به سبز جنگلی سفت و سومین سبک افکت یک سایهٔ خارجی با فاصلهٔ 10 پوینت می‌گیرد. نتیجهٔ بصری دقیق هنوز به این بستگی دارد که هر شکل به کدام اسلات‌ها ارجاع می‌دهد و آیا قالب‌بندی مستقیم تم را بازنویسی می‌کند یا نه.

![سبک‌های افکت تم پس از تغییر تنظیمات خط، پرکننده و سایه](presentation-design_11.png)

## **خواندن مقادیر مؤثر تم**

اشیاء خام تم به شما می‌گویند که در یک سطح خاص چه چیزی تعریف شده است. مقادیر مؤثر به شما می‌گویند یک اسلاید یا شکل پس از حل ارث‌بری و بازنویسی‌های محلی واقعاً چه چیزی استفاده می‌کند. برای یک اسلاید، متد [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/baseoverridethememanager/) را فراخوانی کنید. برای پس‌زمینه، از [Background.getEffective](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/background/) استفاده کنید و برای پرکننده، از [FillFormat.getEffective](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fillformat/) استفاده کنید.

مثال زیر تم مؤثر، پس‌زمینه و اولین پرکنندهٔ شکل را از یک اسلاید می‌خواند:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IThemeEffectiveData effectiveTheme = slide.getThemeManager().createThemeEffective();
    IBackgroundEffectiveData effectiveBackground = slide.getBackground().getEffective();
    System.out.println("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        IFillFormatEffectiveData effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        System.out.println("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() == FillType.Solid) {
            int effectiveColor = effectiveFill.getSolidFillColor();
            System.out.println(String.format("First shape effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
        }
    }
} finally {
    presentation.dispose();
}
```

از داده‌های مؤثر برای عیب‌یابی رندر، اعتبارسنجی و مقایسه استفاده کنید. اگر فقط [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) را بازرسی کنید، ممکن است یک بازنویسی master، layout، اسلاید یا شکل را که ظاهر نهایی را تغییر می‌دهد، از دست بدهید.

## **پرسش‌های متداول**

**آیا می‌توانم یک تم را فقط بر یک اسلاید اعمال کنم بدون اینکه master را تغییر دهم؟**

بله. از [SlideThemeManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slidethememanager/) اسلاید استفاده کنید و تم بازنویسی‌شدهٔ آن را مقداردهی کنید. تغییر فقط به‌صورت محلی بر آن اسلاید باقی می‌ماند؛ اسلایدهای دیگر به تم‌های موجود خود ادامه می‌دهند.

**امن‌ترین روش برای انتقال یک تم از یک ارائه به ارائه دیگر چیست؟**

هنگام انتقال یک اسلاید و حفظ ظاهر منبع، master منبع را به مقصد کلون کنید و اسلاید را با همان master با استفاده از [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterslidecollection/) و [ISlideCollection.addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidecollection/) کلون کنید. این کار master، layoutها و تم را همراه‌هم نگه می‌دارد.

**چگونه می‌توانم مقادیر مؤثر را پس از ارث‌بری و بازنویسی‌ها ببینم؟**

از [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/baseoverridethememanager/) برای یک اسلاید یا تم layout استفاده کنید و متدهای داده‌های مؤثر مربوط به اشیای قالب مانند [Background.getEffective](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/background/) و [FillFormat.getEffective](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fillformat/) را به‌کار ببرید. این APIها مقادیر حل‌شده پس از اعمال ارث‌بری و بازنویسی‌ها را برمی‌گردانند.