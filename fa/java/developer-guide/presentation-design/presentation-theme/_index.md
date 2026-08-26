---
title: مدیریت تم‌های ارائه در جاوا
linktitle: تم ارائه
type: docs
weight: 10
url: /fa/java/presentation-theme/
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
- پالت افزایشی
- قلم تم
- استایل تم
- افکت تم
- PowerPoint
- OpenDocument
- ارائه
- جاوا
- Aspose.Slides
description: "تم‌های اصلی ارائه در Aspose.Slides برای جاوا برای ایجاد، سفارشی‌سازی و تبدیل فایل‌های PowerPoint با برندینگ یکسان."
---
## **معرفی**

یک تم ارائه مجموعه‌ای هماهنگ از رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه، پرکننده‌ها، خطوط و افکت‌ها را تعریف می‌کند. اشیای آگاه از تم به این تعاریف مشترک ارجاع می‌دهند به جای ذخیره کردن هر ویژگی بصری به‌عنوان مقدار ثابت، بنابراین تغییر تم می‌تواند بسیاری از اشیا را به‌صورت یکجا به‌روزرسانی کند.

در Aspose.Slides، تم سطح ارائه از طریق [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) در دسترس است. یک ارائه می‌تواند نیز بازنویسی‌های تم در سطوح پایین‌تر داشته باشد. یک master می‌تواند تم ارائه را از طریق [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/masterthememanager/) بازنویسی کند، در حالی که یک layout یا یک اسلاید منفرد می‌تواند تم ارث‌برده خود را از طریق [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseoverridethememanager/) بازنویسی کند. در عمل، تم مؤثر برای یک اسلاید از طریق این زنجیره ارث‌بری حل می‌شود: تم ارائه، بازنویسی master، بازنویسی layout و بازنویسی اسلاید.

![اجزای تم: رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه و افکت‌ها](theme-constituents.png)

بخش‌های زیر رایج‌ترین گردش‌کارهای تم را نشان می‌دهند: بررسی یک تم، تغییر رنگ‌ها و قلم‌ها، کپی یا اعمال یک تم، به‌روزرسانی سبک‌های پس‌زمینه و افکت، و خواندن مقادیر مؤثر پس از حل ارث‌بری و بازنویسی‌ها.

## **بازرسی تم**

شیء [MasterTheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mastertheme/) طرح‌واره رنگ، طرح‌واره قلم و طرح‌واره فرمت تم را از طریق [MasterTheme.getColorScheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mastertheme/)، [MasterTheme.getFontScheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mastertheme/) و [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mastertheme/) در دسترس می‌کند. بازرسی این مجموعه‌ها پیش از تغییر آنها به‌ویژه وقتی ارائه‌ای از منبع خارجی می‌آید مفید است، زیرا تعداد و محتوی ورودی‌های سبک می‌تواند متفاوت باشد.

مثال زیر ویژگی‌های اصلی تم را می‌خواند و گزارش می‌دهد که چند سبک پس‌زمینه، پرکننده، خط و افکت در تم ذخیره شده‌اند:

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

اگر فایلی از چند master استفاده کند، فرض نکنید که هر اسلاید همان تم مؤثر را دارد. master مرتبط با اسلاید را بازرسی کنید و از گردش‌کار تم مؤثر که در ادامه مقاله نشان داده شده استفاده کنید وقتی بازنویسی‌های layout یا اسلاید ممکن است وجود داشته باشند.

## **تغییر رنگ‌های تم**

پرکننده‌ها، خطوط و متن‌های آگاه از تم می‌توانند به یک رنگ منطقی از enumeration [SchemeColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/schemecolor/) ارجاع دهند. وقتی ورودی مربوطه در [IColorScheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icolorscheme/) را تغییر می‌دهید، تمام اشیایی که هنوز به آن رنگ تم ارجاع می‌دهند نسبت به مقدار جدید حل می‌شوند. اشیایی که از رنگ RGB مستقیم استفاده می‌کنند توسط به‌روزرسانی رنگ تم تغییر نمی‌کنند.

مثال کامل زیر یک شکل ایجاد می‌کند که از `Accent4` استفاده می‌کند، رنگ `Accent4` تم را به قرمز تغییر می‌دهد، ارائه را ذخیره می‌کند، دوباره باز می‌کند و رنگ پرکننده مؤثر را چاپ می‌کند:

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

از آنجا که مستطیل به `Accent4` لینک شده باقی می‌ماند، رنگ قابل مشاهده آن پس از تغییر تم به قرمز تبدیل می‌شود. اگر رنگ طرح‌واره را با یک رنگ مستقیم روی شکل جایگزین کنید، تغییرات بعدی `Accent4` دیگر بر آن پرکننده تأثیر نمی‌گذارد.

### **استفاده از رنگ‌ها از پالت افزایشی**

PowerPoint با اعمال تبدیلات رنگ، واریانت‌های روشن‌تر و تاریک‌تر را از یک رنگ تم استخراج می‌کند. Aspose.Slides این تبدیلات را از طریق enumeration [ColorTransformOperation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/colortransformoperation/) در دسترس قرار می‌دهد.

![رنگ‌های اصلی تم و رنگ‌های روشن‌تر و تاریک‌تر تولید شده از پالت افزایشی](additional-palette-colors.png)

**1** - رنگ‌های اصلی تم.  
**2** - واریانت‌های روشن‌تر و تاریک‌تر تولید شده از رنگ‌های اصلی تم.

مثال زیر شش مستطیل مبتنی بر `Accent4` ایجاد می‌کند، برای پنج مورد تبدیل روشنایی اعمال می‌کند و نتیجه را ذخیره می‌کند:

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

این واریانت‌ها مبتنی بر رنگ تم می‌مانند. اگر `Accent4` بعداً تغییر کند، رنگ‌های تبدیل‌شده بر اساس مقدار جدید `Accent4` مجدداً محاسبه می‌شوند.

### **نقشه‌برداری مقادیر `SchemeColor` به اسلات‌های `IColorScheme`**

enumeration [SchemeColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/schemecolor/) از `Text1`، `Background1`، `Text2` و `Background2` استفاده می‌کند، در حالی که [IColorScheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icolorscheme/) همان اسلات‌های تم را به‌صورت `Dark1`، `Light1`، `Dark2` و `Light2` ارائه می‌دهد. نقشه‌برداری ثابت است:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

این‌ها نام‌های جایگزین برای همان اسلات‌های تم هستند؛ مقادیری که به‌صورت پویا از یک فرم به فرم دیگر تبدیل می‌شوند نیستند.

## **تغییر قلم‌های تم**

یک طرح‌واره قلم تم شامل یک مجموعه قلم اصلی برای عناوین و یک مجموعه قلم فرعی برای متن بدنه است. متدهای [IFontScheme.getMajor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontscheme/) و [IFontScheme.getMinor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontscheme/) این مجموعه‌ها را در دسترس می‌گذارند.

شناسه‌های قلم تم سازگار با PowerPoint می‌توانند در قالب‌بندی متن استفاده شوند:

* `+mn-lt` - Body Font Latin (قلم بدنه لاتین)
* `+mj-lt` - Heading Font Latin (قلم عنوان لاتین)
* `+mn-ea` - Body Font East Asian (قلم بدنه شرق‌آسیا)
* `+mj-ea` - Heading Font East Asian (قلم عنوان شرق‌آسیا)

مثال زیر یک عنوان که از قلم لاتین اصلی تم استفاده می‌کند و یک خط بدنه که از قلم لاتین فرعی تم استفاده می‌کند ایجاد می‌کند. سپس قلم‌های تم را تغییر داده و نتیجه را ذخیره می‌کند:

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

عنوان از قلم اصلی پیروی می‌کند و متن بدنه از قلم فرعی. متنی که به‌صورت صریح نام قلم دارد به‌جای شناسه تم، هنگام تغییر طرح‌واره قلم تم به‌صورت خودکار سوئیچ نمی‌شود.

مجموعه‌های قلم اصلی و فرعی می‌توانند شامل نگاشت‌های قلم برای سیستم‌های نوشتاری فردی مانند سیریلیک، عربی، ژاپنی، گرجی و ثانا باشند. برای بازرسی، افزودن، جایگزینی یا حذف این نگاشت‌ها، به سند [Script-Specific Theme Fonts](/slides/fa/java/script-specific-font-mappings/) مراجعه کنید.

{{% alert color="info" title="نکته" %}}

برای اطلاعات بیشتر درباره قلم‌های ارائه، به [PowerPoint Fonts](/slides/fa/java/powerpoint-fonts/) نگاه کنید.

{{% /alert %}}

## **کپی یا اعمال تم**

گردش‌کارهای زیر مسائل مختلف مرتبط با تم را حل می‌کنند.

### **اعمال تم خارجی به اسلایدهای وابسته به یک Master**

از [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslide/) زمانی که فایل تم PowerPoint (`.thmx`) داشته باشید و بخواهید تمام اسلایدهای وابسته به یک master خاص را مجدداً سبک دهید، استفاده کنید. master مورد نظر را از مجموعه [Presentation.getMasters](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) که پیاده‌ساز [IMasterSlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslidecollection/) است، انتخاب کنید و مسیر فایل تم را به متد پاس بدهید.

متد عملیات زیر را انجام می‌دهد:

1. یک اسلاید master جدید بر پایه master انتخاب‌شده ایجاد می‌کند.
1. تم خارجی را بر master جدید اعمال می‌کند.
1. master جدید را به تمام اسلایدهایی که قبلاً به master انتخاب‌شده وابسته بودند، اختصاص می‌دهد.
1. شیء جدید [IMasterSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslide/) را برمی‌گرداند.

مثال زیر تم خارجی را بر اسلایدهای وابسته به اولین master اعمال می‌کند و ارائه را ذخیره می‌کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide selectedMaster = presentation.getMasters().get_Item(0);
    IMasterSlide themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    System.out.println("Created master: " + themedMaster.getName());
    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

یک تم نامعتبر، خراب یا پشتیبانی‌نشده می‌تواند منجر به [PptxReadException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pptxreadexception/) شود. مسیرهای ورودی کاربر را اعتبارسنجی کنید، خطاهای دسترسی به سیستم‌فایل را مدیریت کنید و ارائه را تنها پس از اعمال موفقیت‌آمیز تم ذخیره کنید.

فقط اسلایدهایی که به master انتخاب‌شده وابسته بودند دوباره انتساب می‌یابند. اسلایدهای مرتبط با سایر master‌ها master و تم فعلی خود را حفظ می‌کنند. رنگ‌ها، قلم‌ها، پرکننده‌ها، خطوط، پس‌زمینه‌ها و افکت‌های آگاه از تم نسبت به تم خارجی حل می‌شوند. رنگ‌ها، قلم‌ها، پرکننده‌ها و سایر قالب‌بندی‌های صریح ممکن است بدون تغییر بمانند. بازنویسی‌های سطح layout و اسلاید نیز می‌توانند بر مقادیر ارث‌برده از master جدید اولویت داشته باشند.

تم می‌تواند به قلم‌هایی ارجاع دهد که در محیط زمان اجرا در دسترس نیستند. برای رندرینگ و خروجی ثابت، قلم‌های مورد نیاز را نصب کنید، از طریق [custom font sources](/slides/fa/java/custom-font/) فراهم کنید یا [font substitution](/slides/fa/java/font-substitution/) را پیکربندی کنید.

این یک گردش‌کار مستقیم در سطح master است: متد مسیر فایل `.thmx` را می‌گیرد و نیازی به ایجاد دستی بازنویسی‌های تم در سطح اسلاید یا layout ندارد.

### **اعمال تم‌های خارجی متفاوت در یک ارائه چند‑master**

وقتی master مرتبط از پیش مشخص نباشد، آن را از یک اسلاید نماینده از طریق [ISlide.getLayoutSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/) و [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutslide/) به دست آورید. قبل از اعمال هر تمی، مراجع master اصلی را ذخیره کنید زیرا هر فراخوانی یک master دیگر در ارائه ایجاد می‌کند.

مثال زیر از اسلایدهای دو بخش استفاده می‌کند تا masterهایشان را بیابد و تم خارجی متفاوتی را به هر گروه اعمال می‌کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        System.out.println("The presentation does not contain the expected representative slides.");
    } else {
        IMasterSlide firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        IMasterSlide secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() == secondGroupMaster.getSlideId()) {
            System.out.println("The representative slides use the same master.");
        } else {
            IMasterSlide firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            IMasterSlide secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            System.out.println("First themed master: " + firstThemedMaster.getName());
            System.out.println("Second themed master: " + secondThemedMaster.getName());
            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

فراخوانی اول تنها بر اسلایدهایی که به `firstGroupMaster` وابسته بودند اثر می‌گذارد و فراخوانی دوم تنها بر اسلایدهایی که به `secondGroupMaster` وابسته بودند. اسلایدهای متعلق به هر master دیگری استایلشان عوض نمی‌شود.

### **حفظ تم منبع هنگام جابجایی اسلایدها**

اگر می‌خواهید اسلایدی را به ارائه دیگری منتقل کنید و طراحی اصلی آن را حفظ نمایید، master منبع را با استفاده از [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslidecollection/) در ارائه هدف کلون کنید، سپس اسلاید را با [ISlideCollection.addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecollection/) و master کلون‌شده کلون کنید. این کار master، layoutهای آن و تم مرتبط را همراه خود می‌برد.

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

این روش ترجیحی است وقتی اسلاید منبع باید در مقصد همان ظاهر را داشته باشد. صرفاً کلون کردن محتوا بر روی master مقصد نامرتبط می‌تواند رنگ‌ها، قلم‌ها، پس‌زمینه‌ها و افکت‌های مبتنی بر تم را تغییر دهد.

### **اعمال مقادیر تم به یک اسلاید موجود**

اگر اسلاید هدف باید بر روی master و layout جاری خود بماند، بازنویسی سطح اسلاید را از تم منبع مقداردهی اولیه کنید. متدهای [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/fa/java/com.aspose.slides/overridetheme/)، [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/fa/java/com.aspose.slides/overridetheme/) و [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/fa/java/com.aspose.slides/overridetheme/) سه مؤلفه اصلی تم را در بازنویسی کپی می‌کنند.

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

این تغییر تم استفاده شده توسط آن اسلاید را بدون تغییر تم ارث‌برده توسط سایر اسلایدها اعمال می‌کند. برای حذف بازنویسی محلی و بازگشت به مقادیر ارث‌برده، [OverrideTheme.clear](https://reference.aspose.com/slides/fa/java/com.aspose.slides/overridetheme/) را فراخوانی کنید.

### **اعمال بازنویسی تم به یک Layout**

بازنویسی سطح layout بر اسلایدهایی که از آن layout استفاده می‌کنند اعمال می‌شود، مگر این که اسلاید خاص خود بازنویسی داشته باشد. همان متدهای مقداردهی اولیه می‌توانند از طریق [LayoutSlideThemeManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/layoutslidethememanager/) استفاده شوند:

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

از تم master یا سطح ارائه استفاده کنید وقتی بسیاری از layoutها و اسلایدها باید طراحی پایه یکسانی داشته باشند، از بازنویسی layout وقتی یک خانواده layout نیاز به استایل متفاوت دارد و از بازنویسی اسلاید فقط برای استثنای واقعی. بازنویسی‌های بیش از حد در سطح اسلاید، تغییرات تم سراسری بعدی را پیش‌بینی‌ناپذیر می‌کند.

## **به‌روزرسانی سبک‌های پس‌زمینه تم**

پرکننده‌های پس‌زمینه تم در [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iformatscheme/) ذخیره می‌شوند. PowerPoint می‌تواند در رابط کاربری خود گزینه‌های پس‌زمینه بیشتری نشان دهد نسبت به تعداد تعریف‌های پرکننده فیزیکی موجود در این مجموعه، زیرا UI می‌تواند پرکننده‌های تم را با رنگ‌های تم و سایر ارجاعات سبک ترکیب کند.

![گالری سبک پس‌زمینه PowerPoint برای تم ارائه](presentation-design_8.png)

قبل از استفاده از یک سبک پس‌زمینه، مجموعه ذخیره‌شده و مقدار فعلی [Background.getStyleIndex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/background/) را بررسی کنید. مقدار شاخص سبک `0` به معنای عدم وجود پرکننده تم است؛ مقادیر مثبت به ارجاع‌های سبک پس‌زمینه تم اشاره دارند. این متفاوت از اندیس‌گذاری مستقیم مجموعه Java است، جایی که `get_Item(0)` اولین مورد ذخیره‌شده را برمی‌گرداند. فرض نکنید هر ارائه همان تعداد سبک پرکننده پس‌زمینه را دارد.

مثال زیر تعداد پرکننده‌های پس‌زمینه موجود را گزارش می‌کند، یک ارجاع پس‌زمینه تم را به اولین master اختصاص می‌دهد و ارائه را ذخیره می‌کند:

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

نتیجه قابل مشاهده به ورودی تم ارجاع‌داده‌شده توسط master و هر بازنویسی پس‌زمینه در سطح layout یا اسلاید بستگی دارد. اگر اسلاید پس‌زمینه خود را داشته باشد، تغییر تنها پس‌زمینه master ممکن است آن اسلاید را تغییر ندهد. برای دانستن پس‌زمینه نهایی پس از اعمال ارث‌بری، از [Background.getEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/background/) استفاده کنید.

{{% alert color="warning" title="هشدار" %}}

شاخص سبک را به‌عنوان اندیس‌گذاری صفر‑پایه مجموعه در نظر نگیرید. همچنین از کدگذاری ثابت یک عدد سبک از یک فایل و فرض داشتن همان ظاهر در فایل دیگر خودداری کنید؛ تعریف‌های سبک تم به‌طور خاص برای هر ارائه هستند.

{{% /alert %}}

{{% alert color="info" title="نکته" %}}

برای قالب‌بندی مستقیم پس‌زمینه و ارث‌بری پس‌زمینه، به [Presentation Background](/slides/fa/java/presentation-background/) مراجعه کنید.

{{% /alert %}}

## **به‌روزرسانی افکت‌های تم**

یک طرح‌واره فرمت تم شامل مجموعه‌های جداگانه پرکننده، خط و افکت است که از طریق [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iformatscheme/)، [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iformatscheme/) و [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iformatscheme/) در دسترس هستند. تم‌های معمولی در Office اغلب شامل سه ورودی اصلی هستند که به‌صورت بصری به استایل‌های ظریف، متوسط و پرشتاب مرتبط می‌شوند، اما کد باید هر مجموعه را بازرسی کند به جای اینکه به شمارش ثابت اعتماد کند.

![افکت‌های تم ظریف، متوسط و پرشتاب که بر همان شکل اعمال شده‌اند](presentation-design_10.png)

وقتی این مجموعه‌ها را در Java دسترسی می‌یابید، ایندکس مجموعه صفر‑پایه است: `get_Item(0)` اولین استایل ذخیره‌شده و `get_Item(2)` سومین استایل است. ایندکس‌های مرجع استایل شکل یک مفهوم جداگانه است که از طریق [IShapeStyle](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapestyle/) در دسترس است. تغییر یک استایل تم بر اشکالی که به آن استایل ارجاع می‌دهند تأثیر می‌گذارد؛ اشکالی که به‌صورت مستقیم قالب‌بندی شده‌اند ممکن است بدون تغییر بمانند.

مثال زیر وجود ورودی‌های استایل مورد نیاز را بررسی می‌کند، اولین استایل خط را تغییر می‌دهد، سومین استایل پرکننده را تغییر می‌دهد، یک سایه خارجی را در سومین استایل افکت فعال می‌کند و نتیجه را ذخیره می‌کند:

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

برای اشکالی که به این اسلات‌ها ارجاع می‌دهند، اولین استایل خط تم قرمز می‌شود، سومین استایل پرکننده تم به‌صورت سبز جنگلی سفت می‌شود و سومین استایل افکت یک سایه خارجی با فاصله ۱۰ نقطه می‌گیرد. نتیجه بصری دقیق همچنان به این بستگی دارد که هر شکل به کدام اسلات استایل ارجاع داده و آیا قالب‌بندی مستقیم بر تم ارجاع‌شده اولویت دارد یا نه.

![استایل‌های افکت تم پس از تغییر تنظیمات خط، پرکننده و سایه](presentation-design_11.png)

## **خواندن مقادیر مؤثر تم**

اشیاء تم خام چیزی را می‌گویند که در سطح خاصی تعریف شده است. مقادیر مؤثر آنچه که یک اسلاید یا شکل پس از حل ارث‌بری و بازنویسی‌های محلی استفاده می‌کند، نشان می‌دهند. برای یک اسلاید، [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseoverridethememanager/) را فراخوانی کنید. برای پس‌زمینه، از [Background.getEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/background/) و برای پرکننده، از [FillFormat.getEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fillformat/) استفاده کنید.

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

از داده‌های مؤثر برای تشخیص رندر، اعتبارسنجی و مقایسه‌ها استفاده کنید. اگر فقط [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) را بررسی کنید، ممکن است بازنویسی‌های master، layout، slide یا shape که ظاهر نهایی را تغییر می‌دهند از دست بدهید.

## **سوالات متداول**

**آیا اعمال تم خارجی بر تمام اسلایدهای ارائه اثر می‌گذارد؟**

خیر. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslide/) تنها اسلایدهایی را که به master انتخاب‌شده وابسته‌اند، بازنویسی می‌کند. اسلایدهایی که از masterهای دیگر استفاده می‌کنند تم موجود خود را حفظ می‌کنند.

**آیا می‌توانم تم را بر یک اسلاید واحد اعمال کنم بدون تغییر master؟**

بله. از [SlideThemeManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slidethememanager/) اسلاید استفاده کنید و تم بازنویسی آن را مقداردهی اولیه کنید. تغییر تنها به آن اسلاید محلی می‌ماند؛ سایر اسلایدها تم‌های موجود خود را ادامه می‌دهند.

**ایمن‌ترین روش برای انتقال تم از یک ارائه به ارائه دیگر چیست؟**

وقتی اسلایدی را جابجا می‌کنید و می‌خواهید ظاهر منبع را نگه دارید، master منبع را به مقصد کلون کنید و سپس اسلاید را با همان master با استفاده از [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslidecollection/) و [ISlideCollection.addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecollection/) کلون کنید. این کار master، layoutها و تم را با هم نگه می‌دارد.

**چگونه می‌توانم مقادیر مؤثر را پس از ارث‌بری و بازنویسی‌ها ببینم؟**

از [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseoverridethememanager/) برای یک اسلاید یا تم layout و متدهای داده‑موثر مربوط به اشیای فرمت مثل [Background.getEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/background/) و [FillFormat.getEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fillformat/) استفاده کنید. این APIها مقادیر حل‑شده پس از اعمال ارث‌بری و بازنویسی‌ها را برمی‌گردانند.