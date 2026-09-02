---
title: مدیریت تم‌های ارائه در جاوا
linktitle: تم ارائه
type: docs
weight: 10
url: /fa/java/presentation-theme/
keywords:
- تم پاورپوینت
- تم ارائه
- تم اسلاید
- تنظیم تم
- تغییر تم
- مدیریت تم
- رنگ تم
- پالت افزودنی
- قلم تم
- سبک تم
- اثر تم
- پاورپوینت
- سند باز
- ارائه
- جاوا
- Aspose.Slides
description: "تم‌های اصلی ارائه در Aspose.Slides برای جاوا برای ایجاد، سفارشی‌سازی و تبدیل فایل‌های پاورپوینت با برندینگ ثابت."
---
## **مقدمه**

یک تم ارائه مجموعه‌ای هماهنگ از رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه، پرکننده‌ها، خطوط و اثرات را تعریف می‌کند. اشیای آگاه از تم به‌جای ذخیره هر ویژگی بصری به‌عنوان مقدار ثابت، به این تعاریف مشترک ارجاع می‌دهند، بنابراین تغییر تم می‌تواند بسیاری از اشیا را به‌صورت همزمان به‌روزرسانی کند.

در Aspose.Slides، تم سطح ارائه از طریق [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) در دسترس است. یک ارائه می‌تواند همچنین پوشش‌های تم در سطوح پایین‌تر داشته باشد. یک مستر می‌تواند تم ارائه را از طریق [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/masterthememanager/) بازنویسی کند، در حالی که یک طرح‌بندی یا اسلاید منفرد می‌تواند تم وارث خود را از طریق [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseoverridethememanager/) بازنویسی کند. در عمل، تم مؤثر برای یک اسلاید از طریق این زنجیره وراثت حل می‌شود: تم ارائه، بازنویسی مستر، بازنویسی طرح‌بندی و بازنویسی اسلاید.

![اجزای تم: رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه و اثرات](theme-constituents.png)

بخش‌های زیر رایج‌ترین جریان‌های کاری تم را نشان می‌دهند: بررسی یک تم، تغییر رنگ‌ها و قلم‌ها، کپی یا اعمال تم، به‌روزرسانی سبک‌های پس‌زمینه و اثرات، و خواندن مقادیر مؤثر پس از حل وراثت و بازنویسی‌ها.

## **بررسی یک تم**

شیء [MasterTheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mastertheme/) طرح رنگ تم، طرح قلم تم و طرح فرمت تم را از طریق [MasterTheme.getColorScheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mastertheme/)، [MasterTheme.getFontScheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mastertheme/) و [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mastertheme/) در اختیار می‌گذارد. بررسی این مجموعه‌ها پیش از تغییر آن‌ها به‌ویژه وقتی مفید است که ارائه‌ای از منبع خارجی دریافت شده باشد، زیرا تعداد و محتوای ورودی‌های سبک می‌تواند متفاوت باشد.

مثال زیر ویژگی‌های اصلی تم را می‌خواند و گزارش می‌دهد که چه تعداد سبک پس‌زمینه، پرکننده، خط و اثر در تم ذخیره شده‌اند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    System.out.println("Theme name: " + theme.getName());
    System.out.println("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
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

اگر فایلی از چند مستر استفاده کند، فرض نکنید هر اسلاید همان تم مؤثر را دارد. مستری که به اسلاید مرتبط است را بررسی کنید و از جریان کاری تم مؤثر که در ادامه این مقاله نشان داده شده است استفاده کنید وقتی ممکن است بازنویسی‌های طرح‌بندی یا اسلاید وجود داشته باشد.

## **تغییر رنگ‌های تم**

پرکننده‌ها، خطوط و متن‌های آگاه از تم می‌توانند به یک رنگ منطقی از شمارش [SchemeColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/schemecolor/) ارجاع دهند. وقتی ورودی متناظر در [IColorScheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icolorscheme/) را تغییر می‌دهید، تمام اشیایی که هنوز به آن رنگ تم ارجاع می‌دهند نسبت به مقدار جدید حل می‌شوند. اشیایی که از یک رنگ مستقیم RGB استفاده می‌کنند توسط به‌روزرسانی رنگ تم تغییر نمی‌کنند.

مثال انتها‑به‑انتها زیر یک شکل ایجاد می‌کند که از `Accent4` استفاده می‌کند، رنگ `Accent4` تم را به قرمز تغییر می‌دهد، ارائه را ذخیره می‌کند، دوباره باز می‌کند و رنگ پرکننده مؤثر را چاپ می‌کند:

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    System.out.println("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

چون مستطیل همچنان به `Accent4` متصل است، رنگ قابل مشاهده آن پس از تغییر تم به قرمز می‌شود. اگر رنگ شماره‌ای را مستقیماً بر روی شکل جایگزین کنید، تغییرات آینده `Accent4` دیگر آن پرکننده را تحت تأثیر قرار نمی‌دهد.

### **استفاده از رنگ‌ها از پالت افزودنی**

PowerPoint واریان‌های روشن‌تر و تیره‌تر را از یک رنگ تم با اعمال تبدیلات رنگی به‌دست می‌آورد. Aspose.Slides این تبدیلات را از طریق شمارش [ColorTransformOperation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/colortransformoperation/) در اختیار می‌گذارد.

![رنگ‌های اصلی تم و رنگ‌های روشن‌تر و تیره‌تر تولید شده از پالت افزودنی](additional-palette-colors.png)

**1** - رنگ‌های اصلی تم.  

**2** - واریان‌های روشن‌تر و تیره‌تر تولید شده از رنگ‌های اصلی تم.

مثال زیر شش مستطیل مبتنی بر `Accent4` ایجاد می‌کند، برای پنج‌تای آن‌ها تبدیلات روشنایی اعمال می‌کند و نتیجه را ذخیره می‌نماید:

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

این واریان‌ها همچنان مبتنی بر رنگ تم هستند. اگر later `Accent4` تغییر کند، رنگ‌های تبدیل‌شده از مقدار جدید `Accent4` مجدداً محاسبه می‌شوند.

### **نقشه‌برداری مقادیر `SchemeColor` به اسلات‌های `IColorScheme`**

شمارش [SchemeColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/schemecolor/) از `Text1`، `Background1`، `Text2` و `Background2` استفاده می‌کند، در حالی که [IColorScheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icolorscheme/) همان اسلات‌های تم را به‌صورت `Dark1`، `Light1`، `Dark2` و `Light2` نمایش می‌دهد. نقشه ثابت است:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

این‌ها نام‌های جایگزین برای همان اسلات‌های تم هستند؛ مقادیری نیستند که به‌صورت پویا از یک فرم به فرم دیگر تبدیل شوند.

## **تغییر قلم‌های تم**

یک طرح قلم تم شامل یک مجموعه قلم اصلی برای عناوین و یک مجموعه قلم فرعی برای متن اصلی است. متدهای [IFontScheme.getMajor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontscheme/) و [IFontScheme.getMinor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontscheme/) این مجموعه‌ها را در اختیار می‌گذارند.

شناسه‌های قلم تم سازگار با PowerPoint می‌توانند در قالب‌بندی متن استفاده شوند:

* `+mn-lt` - قلم بدنه لاتین (Minor Latin Font)
* `+mj-lt` - قلم عنوان لاتین (Major Latin Font)
* `+mn-ea` - قلم بدنه آسیای شرقی (Minor East Asian Font)
* `+mj-ea` - قلم عنوان آسیای شرقی (Major East Asian Font)

مثال زیر یک عنوان ایجاد می‌کند که از قلم لاتین اصلی تم استفاده می‌کند و یک خط بدنه که از قلم لاتین فرعی تم استفاده می‌کند. سپس قلم‌های تم را تغییر می‌دهد و نتیجه را ذخیره می‌کند:

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

عنوان از قلم اصلی پیروی می‌کند و متن اصلی از قلم فرعی. متنی که نام قلم صریح داشته باشد به‌جای شناسه تم، هنگام تغییر طرح قلم تم به‌طور خودکار سوئیچ نمی‌شود.

مجموعه‌های قلم اصلی و فرعی می‌توانند شامل نگاشت‌های قلم برای سیستم‌های نوشتاری فردی نیز باشند، مانند سیریلیک، عربی، ژاپنی، گرجی و ثانا. برای بررسی، افزودن، جایگزینی یا حذف این نگاشت‌ها، به [فونت‌های تم مخصوص اسکریپت](/slides/fa/java/script-specific-font-mappings/) مراجعه کنید.

{{% alert color="info" title="نکته" %}}

برای اطلاعات بیشتر درباره قلم‌های ارائه، به [قلم‌های PowerPoint](/slides/fa/java/powerpoint-fonts/) نگاه کنید.

{{% /alert %}}

## **کپی یا اعمال تم**

دو جریان کاری رایج وجود دارد و هر کدام مشکل متفاوتی را حل می‌کنند.

### **حفظ تم منبع هنگام جابجایی اسلایدها**

اگر می‌خواهید اسلایدی را به ارائه دیگری منتقل کنید و طراحی اصلی آن را حفظ نمایید، مستر منبع را با استفاده از [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslidecollection/) به ارائه هدف اضافه کنید، سپس اسلاید را با استفاده از [ISlideCollection.addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecollection/) و مستر کپی‌شده کلون کنید. این کار مستر، طرح‌بندی‌های آن و تم مرتبط را همراه می‌برد.

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

این جریان کاری ترجیح داده می‌شود وقتی اسلاید منبع باید همان شکل را در مقصد داشته باشد. تنها کلون کردن محتوا روی مستری نامرتبط می‌تواند رنگ‌های مبتنی بر تم، قلم‌ها، پس‌زمینه‌ها و اثرات را تغییر دهد.

### **اعمال مقادیر تم به اسلاید موجود**

اگر اسلاید هدف باید روی مستر و طرح‌بندی جاری خود بماند، یک بازنویسی سطح اسلاید را از تم منبع مقداردهی اولیه کنید. متدهای [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/fa/java/com.aspose.slides/overridetheme/)، [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/fa/java/com.aspose.slides/overridetheme/) و [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/fa/java/com.aspose.slides/overridetheme/) سه مؤلفه اصلی تم را در بازنویسی کپی می‌کنند.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
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

این کار تم استفاده‌شده توسط آن اسلاید را بدون تغییر تم وارث شده توسط اسلایدهای دیگر تغییر می‌دهد. برای حذف بازنویسی محلی و بازگشت به مقادیر وارث‌شده، متد [OverrideTheme.clear](https://reference.aspose.com/slides/fa/java/com.aspose.slides/overridetheme/) را صدا بزنید.

### **اعمال بازنویسی تم به یک طرح‌بندی**

یک بازنویسی سطح طرح‌بندی به اسلایدهایی که از همان طرح‌بندی استفاده می‌کنند اعمال می‌شود مگر اینکه اسلاید خاص خود بازنویسی داشته باشد. همان متدهای مقداردهی اولیه می‌توانند از طریق [LayoutSlideThemeManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/layoutslidethememanager/) استفاده شوند:

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
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

هنگامی که بسیاری از طرح‌بندی‌ها و اسلایدها باید طراحی پایه مشترکی داشته باشند، از تم سطح مستر یا ارائه استفاده کنید؛ برای یک خانواده طرح‌بندی که به استایل متفاوتی نیاز دارد، از بازنویسی طرح‌بندی استفاده کنید؛ و برای موارد استثنایی واقعی فقط از بازنویسی اسلاید استفاده کنید. بازنویسی‌های افراطی در سطح اسلاید، تغییرات تم سراسری بعدی را پیش‌بینی‌ناپذیر می‌کند.

## **به‌روزرسانی سبک‌های پس‌زمینه تم**

پرکننده‌های پس‌زمینه تم در [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iformatscheme/) ذخیره می‌شوند. PowerPoint می‌تواند گزینه‌های پس‌زمینه بیشتری در رابط کاربری خود نمایش دهد نسبت به تعداد تعریف‌های پرکننده فیزیکی ذخیره شده در این مجموعه، زیرا رابط کاربری می‌تواند پرکننده‌های تم را با رنگ‌های تم و سایر مراجع سبک ترکیب کند.

![گالری سبک پس‌زمینه PowerPoint برای تم یک ارائه](presentation-design_8.png)

قبل از استفاده از یک سبک پس‌زمینه، مجموعه ذخیره‌شده و مقدار فعلی [Background.getStyleIndex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/background/) را بررسی کنید. مقدار شاخص سبک `0` به این معنی است که پرکننده‌ای تم‌شده وجود ندارد؛ مقادیر مثبت به مراجع سبک پس‌زمینه تم اشاره دارند. این متفاوت از ایندکس‌گذاری مستقیم مجموعه جاوا است، جایی که `get_Item(0)` اولین مورد ذخیره‌شده را برمی‌گرداند. فرض نکنید هر ارائه همان تعداد سبک پرکننده پس‌زمینه را دارد.

مثال زیر تعداد پرکننده‌های پس‌زمینه موجود را گزارش می‌کند، یک مرجع پس‌زمینه تم‌شده را به اولین مستر اختصاص می‌دهد و ارائه را ذخیره می‌کند:

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

نتیجه قابل مشاهده به ورودی تمی که توسط مستر ارجاع شده و به هر بازنویسی پس‌زمینه در سطح طرح‌بندی یا اسلاید بستگی دارد. اگر اسلاید پس‌زمینه خود را داشته باشد، تغییر فقط پس‌زمینه مستر ممکن است آن اسلاید را تغییر ندهد. زمانی که نیاز به دانستن پس‌زمینه نهایی پس از اعمال وراثت دارید، از [Background.getEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/background/) استفاده کنید.

{{% alert color="warning" title="هشدار" %}}

شاخص سبک را به‌عنوان ایندکس صفر‑پایه مجموعه در نظر نگیرید. همچنین از کدنویسی ثابت یک شماره سبک از یک فایل و فرض اینکه در فایل دیگر همان ظاهر را دارد، خودداری کنید؛ تعاریف سبک تم به‌صورت خاص برای هر ارائه هستند.

{{% /alert %}}

{{% alert color="info" title="نکته" %}}

برای قالب‌بندی مستقیم پس‌زمینه و وراثت پس‌زمینه، به [پس‌زمینه ارائه](/slides/fa/java/presentation-background/) نگاه کنید.

{{% /alert %}}

## **به‌روزرسانی اثرات تم**

یک طرح فرمت تم شامل مجموعه‌های جداگانه پرکننده، خط و اثر است که از طریق [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iformatscheme/)، [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iformatscheme/) و [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iformatscheme/) در دسترس هستند. تم‌های اداری معمولاً سه ورودی سبک اصلی دارند که به‌صورت بصری متناظر با قالب‌بندی ظریف، متوسط و پرقدرت هستند، اما کد باید هر مجموعه را بررسی کند نه اینکه تعداد ثابت را فرض کند.

![اثرات تم ظریف، متوسط و پرقدرت اعمال‌شده بر یک شکل یکسان](presentation-design_10.png)

زمانی که این مجموعه‌ها را در Java دسترسی می‌یابید، ایندکس مجموعه صفر‑پایه است: `get_Item(0)` اولین سبک ذخیره‌شده و `get_Item(2)` سومین سبک است. ایندکس‌های مرجع سبک یک شکل مفهوم جداگانه‌ای است که از طریق [IShapeStyle](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapestyle/) در دسترس است. اصلاح یک سبک تم بر اشکالی که به آن سبک ارجاع می‌دهند تأثیر می‌گذارد؛ اشکالی که به‌صورت مستقیم قالب‌بندی شده‌اند ممکن است بدون تغییر بمانند.

مثال زیر بررسی می‌کند که ورودی‌های سبک مورد نیاز وجود دارند، اولین سبک خط را تغییر می‌دهد، سومین سبک پرکننده را تغییر می‌دهد، یک سایه خارجی را در سومین سبک اثر فعال می‌کند و نتیجه را ذخیره می‌کند:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(new Color(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای اشکالی که به این اسلات‌ها ارجاع می‌دهند، اولین سبک خط تم به قرمز تبدیل می‌شود، سومین سبک پرکننده تم به سبز جنگلی ثابت تغییر می‌یابد و سومین سبک اثر یک سایه خارجی با فاصله 10 پوینت به دست می‌آورد. نتیجه بصری دقیق همچنان به این بستگی دارد که هر شکل به کدام اسلات‌های سبک ارجاع می‌دهد و آیا قالب‌بندی مستقیم بر تم اولویت دارد یا نه.

![سبک‌های اثر تم پس از تغییر تنظیمات خط، پرکننده و سایه](presentation-design_11.png)

## **خواندن مقادیر مؤثر تم**

اشیای خام تم به شما می‌گویند که در یک سطح خاص چه چیزی تعریف شده است. مقادیر مؤثر به شما می‌گویند که یک اسلاید یا شکل پس از حل وراثت و بازنویسی‌های محلی واقعاً چه چیزی استفاده می‌کند. برای یک اسلاید، متد [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseoverridethememanager/) را فراخوانی کنید. برای پس‌زمینه، از [Background.getEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/background/) استفاده کنید و برای پرکننده، از [FillFormat.getEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fillformat/) استفاده نمایید.

مثال زیر تم مؤثر، پس‌زمینه و اولین پرکننده شکل را از یک اسلاید می‌خواند:

```java
import com.aspose.slides.*;

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
            System.out.println("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

از داده‌های مؤثر برای تشخیص رندر، اعتبارسنجی و مقایسه‌ها استفاده کنید. اگر فقط [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) را بررسی کنید، ممکن است یک بازنویسی مستر، طرح‌بندی، اسلاید یا شکل را که ظاهر نهایی را تغییر می‌دهد از دست بدهید.

## **سؤالات متداول**

**آیا می‌توانم تم را فقط بر یک اسلاید اعمال کنم بدون تغییر مستر؟**

بله. از [SlideThemeManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slidethememanager/) اسلاید استفاده کنید و تم بازنویسی‌شده آن را مقداردهی اولیه کنید. تغییر فقط برای آن اسلاید محلی می‌ماند؛ اسلایدهای دیگر تم‌های موجود خود را وارث می‌کنند.

**ایمن‌ترین روش برای انتقال یک تم از یک ارائه به ارائه دیگر چیست؟**

هنگام جابجایی اسلاید و حفظ ظاهر منبع، مستر منبع را به مقصد کلون کنید و اسلاید را با استفاده از [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslidecollection/) و [ISlideCollection.addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecollection/) کلون کنید. این کار مستر، طرح‌بندی‌ها و تم را همراه‌ هم نگه می‌دارد.

**چگونه می‌توانم مقادیر مؤثر را پس از وراثت و بازنویسی‌ها ببینم؟**

از [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseoverridethememanager/) برای یک تم اسلاید یا طرح‌بندی و متدهای داده‑مؤثر مربوط به اشیای فرمت مانند [Background.getEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/background/) و [FillFormat.getEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fillformat/) استفاده کنید. این APIها مقادیر حل‑شده پس از اعمال وراثت و بازنویسی‌ها را برمی‌گردانند.