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
- پالت اضافه
- قلم تم
- سبک تم
- اثر تم
- پاورپوینت
- OpenDocument
- ارائه
- جاوا
- Aspose.Slides
description: "تم‌های اصلی ارائه در Aspose.Slides برای جاوا جهت ایجاد، سفارشی‌سازی و تبدیل فایل‌های PowerPoint با برندسازی یکسان."
---
## **مقدمه**

یک تم ارائه مجموعه‌ای هماهنگ از رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه، پرکننده‌ها، خطوط و اثرها را تعریف می‌کند. اشیائی که‌از تم‌آگاه هستند به این تعریف‌های مشترک اشاره می‌کنند به‌جای این‌که هر ویژگی بصری را به‌عنوان مقدار ثابت ذخیره کنند، بنابراین تغییر تم می‌تواند بسیاری از اشیاء را همزمان به‌روز کند.

در Aspose.Slides، تم در سطح ارائه از طریق [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) در دسترس است. یک ارائه می‌تواند همچنین بازنویسی‌های تم را در سطوح پایین‌تر داشته باشد. یک مستر می‌تواند تم ارائه را از طریق [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/masterthememanager/) بازنویسی کند، در حالی که یک لِی‌آوت یا اسلاید منفرد می‌تواند تم وراثت‌دیده خود را از طریق [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseoverridethememanager/) بازنویسی کند. در عمل، تم مؤثر برای یک اسلاید از طریق این زنجیره وراثت حل می‌شود: تم ارائه، بازنویسی مستر، بازنویسی لِی‌آوت و بازنویسی اسلاید.

![اجزای تم: رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه و اثرها](theme-constituents.png)

بخش‌های زیر رایج‌ترین جریان‌های کاری تم را نشان می‌دهند: بازرسی تم، تغییر رنگ‌ها و قلم‌ها، کپی یا اعمال تم، به‌روزرسانی سبک‌های پس‌زمینه و اثر، و خواندن مقادیر مؤثر پس از حل وراثت و بازنویسی‌ها.

## **بازرسی یک تم**

شیء [MasterTheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mastertheme/) طرح رنگی، طرح قلمی و طرح قالب تم را از طریق [MasterTheme.getColorScheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mastertheme/)، [MasterTheme.getFontScheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mastertheme/) و [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mastertheme/) در دسترس می‌کند. بازرسی این مجموعه‌ها پیش از تغییر آن‌ها به‌ویژه وقتی که یک ارائه از منبع خارجی می‌آید مفید است، زیرا تعداد و محتوی ورودی‌های سبک می‌تواند متفاوت باشد.

مثال زیر ویژگی‌های اصلی تم را می‌خواند و گزارش می‌دهد که چند سبک پس‌زمینه، پرکننده، خط و اثر در تم ذخیره شده‌اند:

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

اگر فایلی از چند مستر استفاده کند، فرض نکنید که هر اسلاید همان تم مؤثر را دارد. مستری که به اسلاید مرتبط است را بازرسی کنید و از جریان کاری تم مؤثر که در ادامه این مقاله نشان داده شده است استفاده کنید زمانی که بازنویسی‌های لِی‌آوت یا اسلاید ممکن است وجود داشته باشند.

## **تغییر رنگ‌های تم**

پرکننده‌ها، خطوط و متن‌های تم‌آگاه می‌توانند به یک رنگ منطقی از شمارش [SchemeColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/schemecolor/) ارجاع دهند. وقتی ورودی متناظر در [IColorScheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icolorscheme/) را تغییر می‌دهید، تمام اشیائی که هنوز به آن رنگ تم اشاره می‌کنند نسبت به مقدار جدید حل می‌شوند. اشیائی که از یک رنگ RGB مستقیم استفاده می‌کنند توسط به‌روزرسانی رنگ تم تغییر نمی‌کنند.

مثال انتهایی زیر یک شکل ایجاد می‌کند که از `Accent4` استفاده می‌کند، رنگ `Accent4` تم را به قرمز تغییر می‌دهد، ارائه را ذخیره می‌کند، دوباره باز می‌کند و رنگ پرکننده مؤثر را چاپ می‌کند:

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

چون مستطیل به `Accent4` متصل باقی می‌ماند، رنگ قابل مشاهده آن پس از تغییر تم به قرمز تبدیل می‌شود. اگر رنگ طرح را با یک رنگ مستقیم روی شکل جایگزین کنید، تغییرات بعدی `Accent4` دیگر بر آن پرکننده تأثیر نمی‌گذارد.

### **استفاده از رنگ‌ها از پالت اضافی**

PowerPoint با اعمال تبدیل‌های رنگی، انواع روشن‌تر و تاریک‌تر را از یک رنگ تم استخراج می‌کند. Aspose.Slides این تبدیلات را از طریق شمارش [ColorTransformOperation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/colortransformoperation/) در دسترس می‌گذارد.

![رنگ‌های اصلی تم و رنگ‌های روشن‌تر و تاریک‌تر تولید شده از پالت اضافی](additional-palette-colors.png)

**1** - رنگ‌های اصلی تم.

**2** - گونه‌های روشن‌تر و تاریک‌تر تولید شده از رنگ‌های اصلی تم.

مثال زیر شش مستطیل بر پایه `Accent4` ایجاد می‌کند، به پنج مورد از آن‌ها تبدیل‌های روشنایی اعمال می‌کند و نتیجه را ذخیره می‌نماید:

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

این گونه‌ها بر پایه رنگ تم باقی می‌مانند. اگر `Accent4` بعداً تغییر کند، رنگ‌های تبدیل‌شده از مقدار جدید `Accent4` مجدداً محاسبه می‌شوند.

### **نقشه‌برداری مقادیر `SchemeColor` به اسلات‌های `IColorScheme`**

شمارش [SchemeColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/schemecolor/) از `Text1`، `Background1`، `Text2` و `Background2` استفاده می‌کند، در حالی که [IColorScheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icolorscheme/) همان اسلات‌های تم را به عنوان `Dark1`، `Light1`، `Dark2` و `Light2` افشا می‌کند. نقشه ثابت است:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

این‌ها نام‌های جایگزین برای همان اسلات‌های تم هستند؛ آن‌ها مقادیری نیستند که به‌صورت پویا از یک فرم به فرم دیگر تبدیل شوند.

## **تغییر قلم‌های تم**

یک طرح قلمی تم شامل مجموعه قلم اصلی برای سرعنوان‌ها و مجموعه قلم جزئی برای متن بدنه است. روش‌های [IFontScheme.getMajor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontscheme/) و [IFontScheme.getMinor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontscheme/) این مجموعه‌ها را نمایش می‌دهند.

شناسه‌های قلم تم سازگار با PowerPoint می‌توانند در قالب‌بندی متن استفاده شوند:

* `+mn-lt` - قلم بدنه لاتین (قلم لاتین جزئی)
* `+mj-lt` - قلم سرعنوان لاتین (قلم لاتین اصلی)
* `+mn-ea` - قلم بدنه آسیای شرقی (قلم آسیای شرقی جزئی)
* `+mj-ea` - قلم سرعنوان آسیای شرقی (قلم آسیای شرقی اصلی)

مثال زیر یک سرعنوان که از قلم لاتین اصلی تم استفاده می‌کند و یک خط بدنه که از قلم لاتین جزئی تم استفاده می‌کند ایجاد می‌کند. سپس قلم‌های تم را تغییر می‌دهد و نتیجه را ذخیره می‌کند:

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

سرعنوان از قلم اصلی پیروی می‌کند و متن بدنه از قلم جزئی. متنی که نام قلم صریحی به‌جا یک شناسه تم داشته باشد به‌صورت خودکار زمانی که طرح قلم تم تغییر کند، جابه‌جا نخواهد شد.

{{% alert color="info" title="Tip" %}}
برای اطلاعات بیشتر درباره قلم‌های ارائه، به [فونت‌های پاورپوینت](/slides/fa/java/powerpoint-fonts/) مراجعه کنید.
{{% /alert %}}

## **کپی یا اعمال یک تم**

دو جریان کاری رایج وجود دارد و آن‌ها مسائل متفاوتی را حل می‌کنند.

### **حفظ تم منبع هنگام جابه‌جایی اسلایدها**

اگر می‌خواهید یک اسلاید را به ارائه دیگری منتقل کنید و طراحی اصلی آن را حفظ کنید، مستر منبع را با استفاده از [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslidecollection/) به ارائه هدف اضافه کنید، سپس اسلاید را با [ISlideCollection.addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecollection/) و مستر کلون‌شده کپی کنید. این کار مستر، لِی‌آوت‌های آن و تم مرتبط را با هم حمل می‌کند.

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

این جریان کاری ترجیحی است وقتی اسلاید منبع باید در مقصد همان شکل را داشته باشد. سادهً کپی محتوا روی یک مستر مقصد نامرتبط می‌تواند رنگ‌ها، قلم‌ها، پس‌زمینه‌ها و اثرهای مبتنی بر تم را تغییر دهد.

### **اعمال مقادیر تم به یک اسلاید موجود**

اگر اسلاید هدف باید بر روی مستر و لِی‌آوت فعلی خود بماند، یک بازنویسی سطح اسلاید از تم منبع مقداردهی اولیه کنید. روش‌های [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/fa/java/com.aspose.slides/overridetheme/)، [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/fa/java/com.aspose.slides/overridetheme/) و [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/fa/java/com.aspose.slides/overridetheme/) سه مؤلفه اصلی تم را به بازنویسی کپی می‌کنند.

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

این کار تم مورد استفاده توسط آن اسلاید را بدون تغییر تم ارث‌بری شده توسط سایر اسلایدها تغییر می‌دهد. برای حذف بازنویسی محلی و بازگشت به مقادیر ارث‌بری شده، از [OverrideTheme.clear](https://reference.aspose.com/slides/fa/java/com.aspose.slides/overridetheme/) فراخوانی کنید.

### **اعمال بازنویسی تم به یک لِی‌آوت**

یک بازنویسی سطح لِی‌آوت بر اسلایدهایی که از آن لِی‌آوت استفاده می‌کنند اعمال می‌شود، مگر آنکه اسلاید خاصی بازنویسی خود را داشته باشد. همان روش‌های مقداردهی اولیه می‌توانند از طریق [LayoutSlideThemeManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/layoutslidethememanager/) استفاده شوند:

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

از تم سطح مستر یا ارائه استفاده کنید وقتی بسیاری از لِی‌آوت‌ها و اسلایدها باید همان طراحی پایه را به‌اشتراک بگذارند، از بازنویسی لِی‌آوت وقتی یک خانواده لِی‌آوت نیاز به سبک متفاوت دارد، و از بازنویسی اسلاید فقط برای استثناهای واقعی. بازنویسی‌های بیش از حد سطح اسلاید باعث می‌شود تغییرات جهانی تم بعداً پیش‌بینی سخت‌تری داشته باشند.

## **به‌روزرسانی سبک‌های پس‌زمینه تم**

پرکننده‌های پس‌زمینه تم در [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iformatscheme/) ذخیره می‌شوند. PowerPoint می‌تواند گزینه‌های پس‌زمینه بیشتری در رابط کاربری خود نشان دهد نسبت به تعداد تعاریف پرکننده‌ای که فیزیکی در این مجموعه ذخیره شده‌اند، زیرا رابط کاربری می‌تواند پرکننده‌های تم را با رنگ‌های تم و سایر مراجع سبک ترکیب کند.

![گالری سبک پس‌زمینه PowerPoint برای تم یک ارائه](presentation-design_8.png)

قبل از استفاده از یک سبک پس‌زمینه، مجموعه ذخیره‌شده و اندیس سبک جاری را با [Background.getStyleIndex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/background/) بررسی کنید. یک اندیس سبک `0` به این معناست که پرکننده تمی نیست؛ مقادیر مثبت مراجع سبک پس‌زمینه تم هستند. این متفاوت از ایندکس‌گذاری مستقیم مجموعه جاوا است که در آن `get_Item(0)` به اولین آیتم ذخیره‌شده اشاره دارد. فرض نکنید که هر ارائه همان تعداد سبک پرکننده پس‌زمینه را دارد.

مثال زیر تعداد پرکننده‌های پس‌زمینه موجود را گزارش می‌دهد، یک مرجع پس‌زمینه تم به اولین مستر اختصاص می‌دهد و ارائه را ذخیره می‌کند:

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

نتیجه قابل مشاهده به ورودی تم مرجع‌دار توسط مستر و هر بازنویسی پس‌زمینه در لِی‌آوت یا سطح اسلاید بستگی دارد. اگر اسلاید پس‌زمینه خود را داشته باشد، تغییر فقط پس‌زمینه مستر ممکن است آن اسلاید را تغییر ندهد. زمانی که نیاز به دانستن پس‌زمینه نهایی پس از اعمال وراثت دارید، از [Background.getEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/background/) استفاده کنید.

{{% alert color="warning" title="Warning" %}}
اندیس سبک را به‌عنوان ایندکس صفر‑محور مجموعه در نظر نگیرید. همچنین از کدنویسی هارد‑کد یک شماره سبک از یک فایل و فرض این‌که در فایل دیگر همان ظاهر را دارد خودداری کنید؛ تعاریف سبک تم به‌صورت خاص برای هر ارائه هستند.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
برای قالب‌بندی مستقیم پس‌زمینه و وراثت پس‌زمینه، به [پس‌زمینه ارائه](/slides/fa/java/presentation-background/) مراجعه کنید.
{{% /alert %}}

## **به‌روزرسانی اثرهای تم**

یک طرح قالب تم شامل مجموعه‌های جداگانه پرکننده، خط و اثر است که از طریق [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iformatscheme/)، [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iformatscheme/) و [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iformatscheme/) در دسترس هستند. تم‌های متداول Office اغلب سه ورودی سبک اصلی دارند که بصورت بصری به قالب‌بندی‌های ملایم، متوسط و شدید متناظر می‌شوند، اما کد باید هر مجموعه را بازرسی کند به‌جای اینکه تعداد ثابت را فرض کند.

![اثرهای تم ملایم، متوسط و شدید که بر یک شکل اعمال شده‌اند](presentation-design_10.png)

زمانی که این مجموعه‌ها را در Java دسترسی می‌دهید، ایندکس مجموعه صفر‑محور است: `get_Item(0)` اولین سبک ذخیره‌شده و `get_Item(2)` سومین است. ایندکس‌های مرجع‑سبک یک شکل مفهومی جداگانه است که از طریق [IShapeStyle](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapestyle/) در دسترس است. تغییر یک سبک تم بر اشکالی که به آن سبک ارجاع می‌دهند تأثیر می‌گذارد؛ اشکالی که قالب‌بندی مستقیم دارند ممکن است بدون تغییر بمانند.

مثال زیر وجود ورودی‌های سبک مورد نیاز را بررسی می‌کند، اولین سبک خط را تغییر می‌دهد، سومین سبک پرکننده را تغییر می‌دهد، یک سایهٔ خارجی را در سومین سبک اثر فعال می‌کند و نتیجه را ذخیره می‌کند:

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

برای شکل‌هایی که به این اسلات‌ها ارجاع می‌دهند، اولین سبک خط تم به قرمز تبدیل می‌شود، سومین سبک پرکننده تم به سبز جنگلی ثابت تبدیل می‌شود و سومین سبک اثر یک سایهٔ خارجی با فاصله 10 پوینت دریافت می‌کند. نتیجه بصری دقیق همچنان به این بستگی دارد که هر شکل به کدام اسلات‌ها ارجاع می‌دهد و آیا قالب‌بندی مستقیم تم را بازنویسی می‌کند یا خیر.

![سبک‌های اثر تم پس از تغییر تنظیمات خط، پرکننده و سایه](presentation-design_11.png)

## **خواندن مقادیر مؤثر تم**

اشیاء تم خام آنچه در یک سطح خاص تعریف شده را به شما می‌گویند. مقادیر مؤثر آنچه یک اسلاید یا شکل پس از حل وراثت و بازنویسی‌های محلی واقعا استفاده می‌کند، نمایش می‌دهد. برای یک اسلاید، [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseoverridethememanager/) را فراخوانی کنید. برای پس‌زمینه، از [Background.getEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/background/) استفاده کنید و برای پرکننده، از [FillFormat.getEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fillformat/) بهره بگیرید.

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

از داده‌های مؤثر برای تشخیص رندر، اعتبارسنجی و مقایسه‌ها استفاده کنید. اگر فقط [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) را بازرسی کنید، ممکن است یک بازنویسی مستر، لِی‌آوت، اسلاید یا شکل را که ظاهر نهایی را تغییر می‌دهد، از دست بدهید.

## **سؤالات متداول**

**آیا می‌توانم یک تم را به یک اسلاید منفرد اعمال کنم بدون این‌که مستر را تغییر دهم؟**

بله. از [SlideThemeManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slidethememanager/) اسلاید استفاده کنید و بازنویسی تم آن را مقداردهی اولیه کنید. این تغییر به‌صورت محلی به آن اسلاید محدود می‌شود؛ سایر اسلایدها تم‌های موجود خود را ارث می‌برند.

**ایمن‌ترین روش برای انتقال یک تم از یک ارائه به ارائهٔ دیگر چیست؟**

هنگام جابه‌جا کردن اسلاید و حفظ ظاهر منبع، مستر منبع را به مقصد کلون کنید و سپس اسلاید را همراه با آن مستر با استفاده از [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslidecollection/) و [ISlideCollection.addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecollection/) کلون کنید. این کار مستر، لِی‌آوت‌ها و تم را با هم حفظ می‌کند.

**چگونه می‌توانم مقادیر مؤثر را پس از وراثت و بازنویسی‌ها ببینم؟**

از [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseoverridethememanager/) برای یک تم اسلاید یا لِی‌آوت و روش‌های داده‑مؤثر مربوط به اشیاء قالب مانند [Background.getEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/background/) و [FillFormat.getEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fillformat/) استفاده کنید. این APIها مقادیر حل‌شده پس از اعمال وراثت و بازنویسی‌ها را بر می‌گردانند.