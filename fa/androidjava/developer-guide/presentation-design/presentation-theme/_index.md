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
- تم خارجی
- THMX
- رنگ تم
- پالت تکمیلی
- قلم تم
- سبک تم
- اثر تم
- پاورپوینت
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "تم‌های اصلی ارائه در Aspose.Slides برای اندروید از طریق جاوا برای ایجاد، سفارشی‌سازی و تبدیل فایل‌های پاورپوینت با برندینگ یکسان."
---
## **مقدمه**

یک تم ارائه مجموعه‌ای هماهنگ از رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه، پرکننده‌ها، خطوط و اثرها را تعریف می‌کند. اشیاء آگاه از تم به‌جای ذخیره هر ویژگی بصری به‌صورت مقدار ثابت، به این تعاریف مشترک ارجاع می‌دهند، بنابراین تغییر تم می‌تواند تعداد زیادی از اشیاء را به‌طور همزمان به‌روزرسانی کند.

در Aspose.Slides، تم سطح ارائه از طریق [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) در دسترس است. یک ارائه همچنین می‌تواند بازنویسی‌های تم در سطوح پایین‌تر داشته باشد. یک مستر می‌تواند تم ارائه را از طریق [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/masterthememanager/) بازنویسی کند، در حالی که یک لایه یا اسلاید تک‌تک می‌تواند تم ارث‌برده خود را از طریق [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/baseoverridethememanager/) بازنویسی کند. در عمل، تم مؤثر برای یک اسلاید از طریق این زنجیره وراثت حل می‌شود: تم ارائه، بازنویسی مستر، بازنویسی لایه و بازنویسی اسلاید.

![اجزای تم: رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه و اثرها](theme-constituents.png)

بخش‌های زیر رایج‌ترین گردش‌های کار با تم را نشان می‌دهند: بررسی یک تم، تغییر رنگ‌ها و قلم‌ها، کپی یا اعمال یک تم، به‌روزرسانی سبک‌های پس‌زمینه و اثر، و خواندن مقادیر مؤثر پس از حل وراثت و بازنویسی‌ها.

## **بررسی یک تم**

شیء [MasterTheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/mastertheme/) اسکیم رنگ، اسکیم قلم و اسکیم فرمت تم را از طریق [MasterTheme.getColorScheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/mastertheme/)، [MasterTheme.getFontScheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/mastertheme/)، و [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/mastertheme/) در دسترس می‌کند. بررسی این مجموعه‌ها پیش از تغییرشان بویژه وقتی مفید است که ارائه‌ای از منبع خارجی آمده باشد، زیرا تعداد و محتوای ورودی‌های سبک می‌تواند متفاوت باشد.

مثال زیر ویژگی‌های اصلی تم را می‌خواند و تعداد سبک‌های پس‌زمینه، پرکننده، خط و اثر ذخیره‌شده در تم را گزارش می‌کند:

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

اگر فایلی از چند مستر استفاده کند، فرض نکنید که هر اسلاید همان تم مؤثر را دارد. مستری که به اسلاید مربوط است را بررسی کنید و در صورتی که بازنویسی‌های لایه یا اسلاید وجود داشته باشد، از گردش کار تم مؤثر نشان‌داده‌شده در ادامه این مقاله استفاده کنید.

## **تغییر رنگ‌های تم**

پرکننده‌ها، خطوط و متون آگاه از تم می‌توانند به یک رنگ منطقی از شماردار [SchemeColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/schemecolor/) ارجاع دهند. وقتی ورودی مربوطه در [IColorScheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icolorscheme/) تغییر می‌کند، تمام اشیائی که هنوز به آن رنگ تم ارجاع می‌دهند، نسبت به مقدار جدید حل می‌شوند. اشیائی که از رنگ RGB مستقیم استفاده می‌کنند، توسط به‌روزرسانی رنگ تم تغییر نمی‌کنند.

مثال پایان‑به‑پایان زیر یک شکل ایجاد می‌کند که از `Accent4` استفاده می‌کند، رنگ `Accent4` تم را به قرمز تغییر می‌دهد، ارائه را ذخیره می‌کند، مجدداً باز می‌کند و رنگ پرکننده مؤثر را چاپ می‌کند:

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

از آنجا که مستطیل به `Accent4` متصل باقی می‌ماند، رنگ قابل مشاهده آن پس از تغییر تم، قرمز می‌شود. اگر رنگ شماردار را با یک رنگ مستقیم روی شکل جایگزین کنید، تغییرات بعدی `Accent4` دیگر بر آن پرکننده تأثیر نخواهد گذاشت.

### **استفاده از رنگ‌ها از پالت تکمیلی**

PowerPoint انواع روشن‌تر و تاریک‌تر را از یک رنگ تم با اعمال تبدیل‌های رنگی تولید می‌کند. Aspose.Slides این تبدیل‌ها را از طریق شماردار [ColorTransformOperation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/colortransformoperation/) در دسترس می‌گذارد.

![رنگ‌های اصلی تم و رنگ‌های روشن‌تر و تاریک‌تر تولیدشده از پالت تکمیلی](additional-palette-colors.png)

**1** – رنگ‌های اصلی تم.  
**2** – انواع روشن‌تر و تاریک‌تر تولیدشده از رنگ‌های اصلی تم.

مثال زیر شش مستطیل بر پایه `Accent4` ایجاد می‌کند، به پنج مورد از آن‌ها تبدیل‌های روشنایی اعمال می‌کند و نتیجه را ذخیره می‌سازد:

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

این انواع مبتنی بر رنگ تم باقی می‌مانند. اگر `Accent4` بعدها تغییر کند، رنگ‌های تبدیل‌شده از مقدار جدید `Accent4` دوباره محاسبه می‌شوند.

### **نقشه‌برداری مقادیر `SchemeColor` به فضاهای `IColorScheme`**

شماردار [SchemeColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/schemecolor/) از `Text1`، `Background1`، `Text2` و `Background2` استفاده می‌کند، در حالی که [IColorScheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icolorscheme/) همان فضاهای تم را به صورت `Dark1`، `Light1`، `Dark2` و `Light2` باز می‌کند. نقشه‌برداری ثابت است:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

این‌ها نام‌های جایگزین برای همان فضاهای تم هستند؛ آن‌ها مقدارهایی نیستند که به‌صورت دینامیک از یک شکل به شکل دیگر تبدیل شوند.

## **تغییر قلم‌های تم**

یک اسکیم قلم تم شامل یک مجموعه قلم بزرگ برای عناوین و یک مجموعه قلم کوچک برای متن بدنه است. روش‌های [IFontScheme.getMajor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifontscheme/) و [IFontScheme.getMinor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifontscheme/) این مجموعه‌ها را در اختیار می‌گذارند.

شناسه‌های قلم متناسب با PowerPoint می‌توانند در قالب‌بندی متن استفاده شوند:

* `+mn‑lt` – قلم بدنه لاتین (Minor Latin Font)
* `+mj‑lt` – قلم عنوان لاتین (Major Latin Font)
* `+mn‑ea` – قلم بدنه آسیای شرقی (Minor East Asian Font)
* `+mj‑ea` – قلم عنوان آسیای شرقی (Major East Asian Font)

مثال زیر یک عنوان که از قلم لاتین بزرگ تم استفاده می‌کند و یک خط بدنه که از قلم لاتین کوچک تم استفاده می‌کند، ایجاد می‌کند. سپس قلم‌های تم را تغییر می‌دهد و نتیجه را ذخیره می‌کند:

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

عنوان از قلم بزرگ پیروی می‌کند و متن بدنه از قلم کوچک. متنی که نام قلم صریح دارد به‌جای شناسه تم، به‌صورت خودکار هنگام تغییر اسکیم قلم تم سوئیچ نمی‌شود.

مجموعه‌های قلم بزرگ و کوچک می‌توانند شامل نگاشت‌های قلم برای سیستم‌های نوشتاری فردی مانند سیریلیک، عربی، ژاپنی، گرجی و تانا باشند. برای بررسی، افزودن، جایگزینی یا حذف این نگاشت‌ها، به بخش [Script‑Specific Theme Fonts](/slides/fa/androidjava/script-specific-font-mappings/) مراجعه کنید.

{{% alert color="info" title="نکته" %}}
برای اطلاعات بیشتر درباره قلم‌های ارائه، به [PowerPoint Fonts](/slides/fa/androidjava/powerpoint-fonts/) مراجعه کنید.
{{% /alert %}}

## **کپی یا اعمال یک تم**

گردش‌های کار زیر به‌حل مشکلات مختلف مرتبط با تم می‌پردازند.

### **اعمال تم خارجی به اسلایدهای وابسته به یک مستر**

زمانی که فایل تم PowerPoint (`.thmx`) دارید و می‌خواهید همه اسلایدهایی که به یک مستر خاص وابسته‌اند را دوباره سبک‌بندی کنید، از [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterslide/) استفاده کنید. مستر موردنظر را از مجموعه [Presentation.getMasters](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) که پیاده‌سازی‌شده توسط [IMasterSlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterslidecollection/) انتخاب کنید و مسیر فایل تم را به متد پاس دهید.

این متد عملیات زیر را انجام می‌دهد:

1. یک اسلاید مستر جدید بر پایه مستر انتخاب‌شده می‌سازد.  
1. تم خارجی را به مستر جدید اعمال می‌کند.  
1. مستر جدید را به تمام اسلایدهایی که پیش از این به مستر انتخاب‌شده وابسته بودند، اختصاص می‌دهد.  
1. مستر جدید ساخته‌شده [IMasterSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterslide/) را برمی‌گرداند.

مثال زیر تم خارجی را بر اسلایدهای وابسته به اولین مستر اعمال می‌کند و ارائه را ذخیره می‌سازد:

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

یک تم نامعتبر، خراب یا پشتیبانی‌نشده می‌تواند منجر به [PptxReadException](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pptxreadexception/) شود. مسیرهای ارائه‌شده توسط کاربران را اعتبارسنجی کنید، خطاهای دسترسی به فایل‌سیستم را مدیریت کنید و تنها پس از اعمال موفقیت‌آمیز تم، ارائه را ذخیره کنید.

تنها اسلایدهایی که به مستر انتخاب‌شده وابسته بودند، مجدداً اختصاص می‌یابند. اسلایدهای مرتبط با مسترهای دیگر مستر و تم‌های فعلی خود را حفظ می‌کنند. رنگ‌ها، قلم‌ها، پرکننده‌ها، خطوط، پس‌زمینه‌ها و اثرهای آگاه از تم نسبت به تم خارجی حل می‌شوند. رنگ‌ها، قلم‌ها، پرکننده‌ها و قالب‌بندی‌های صریح ممکن است بدون تغییر بمانند. بازنویسی‌های سطح لایه و اسلاید نیز می‌توانند بر مقادیر ارث‌برده از مستر جدید اولویت داشته باشند.

تم ممکن است به قلم‌هایی ارجاع دهد که در محیط زمان اجرا موجود نیستند. برای رندر و صادرات سازگار، قلم‌های موردنیاز را نصب کنید، از [منابع قلم سفارشی](/slides/fa/androidjava/custom-font/) فراهم کنید یا [جایگزینی قلم](/slides/fa/androidjava/font-substitution/) را پیکربندی کنید.

این یک گردش کار مستقیم در سطح مستر است: متد مسیر یک فایل `.thmx` را می‌گیرد و نیازی به ایجاد دستی بازنویسی‌های تم در سطح اسلاید یا لایه نیست.

### **اعمال تم‌های خارجی متفاوت در ارائه با چند مستر**

زمانی که مستر مربوطه از پیش شناخته نشده است، می‌توانید آن را از یک اسلاید نماینده از طریق [ISlide.getLayoutSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/) و [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilayoutslide/) دریافت کنید. قبل از اعمال هر تمی، مراجع مسترهای اصلی را ذخیره کنید زیرا هر فراخوانی یک مستر جدید در ارائه می‌سازد.

مثال زیر از اسلایدهای دو بخش برای یافتن مسترهایشان استفاده می‌کند و تم خارجی متفاوتی را به هر گروه اعمال می‌کند:

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

فراخوانی اول فقط بر اسلایدهایی که به `firstGroupMaster` وابسته بودند اثر می‌گذارد و فراخوانی دوم فقط بر اسلایدهایی که به `secondGroupMaster` وابسته بودند. اسلایدهای متعلق به هر مستر دیگر دوباره سبک‌بندی نمی‌شوند.

### **حفظ تم مبدأ هنگام جابه‌جایی اسلایدها**

اگر می‌خواهید اسلایدی را به ارائه دیگری منتقل کنید و طرح اصلی آن را حفظ کنید، مستر منبع را با استفاده از [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterslidecollection/) به ارائه هدف کلون کنید، سپس اسلاید را همراه با مستر کلون‌شده با [ISlideCollection.addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidecollection/) کلون کنید. این کار مستر، لایه‌های آن و تم مرتبط را به‌هم می‌چسباند.

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

این گردش کار ترجیحی است وقتی اسلاید مبدأ باید در مقصد همان ظاهر را داشته باشد. فقط کلون کردن محتوا روی یک مستر مقصد نامرتبط می‌تواند رنگ‌ها، قلم‌ها، پس‌زمینه‌ها و اثرهای مبتنی بر تم را تغییر دهد.

### **اعمال مقادیر تم به یک اسلاید موجود**

اگر اسلاید هدف باید بر روی مستر و لایه فعلی خود بماند، یک بازنویسی در سطح اسلاید از تم منبع راه‌اندازی کنید. متدهای [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/overridetheme/)، [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/overridetheme/)، و [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/overridetheme/) سه مؤلفه اصلی تم را به بازنویسی کپی می‌کنند.

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

این کار تم استفاده‌شده توسط آن اسلاید را بدون تغییر تم ارث‌برده توسط اسلایدهای دیگر تغییر می‌دهد. برای حذف بازنویسی محلی و بازگشت به مقادیر ارث‌برده، متد [OverrideTheme.clear](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/overridetheme/) را فراخوانی کنید.

### **اعمال بازنویسی تم به یک لایه**

یک بازنویسی در سطح لایه بر اسلایدهایی که از آن لایه استفاده می‌کنند اثر می‌گذارد، مگر این که اسلاید خاصی بازنویسی خود را داشته باشد. همان متدهای راه‌اندازی می‌توانند از طریق [LayoutSlideThemeManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/layoutslidethememanager/) استفاده شوند:

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

زمانی که تعداد زیادی لایه و اسلاید باید طراحی پایه یکسانی را به‌اشتراک بگذارند، از تم در سطح مستر یا ارائه استفاده کنید؛ برای یک خانواده لایه که به سبک متفاوتی نیاز دارد، از بازنویسی لایه استفاده کنید؛ و برای استثنای واقعی فقط از بازنویسی اسلاید استفاده کنید. بازنویسی‌های بیش از حد در سطح اسلاید، تغییرات تم سراسری بعدی را پیش‌بینی‌ناپذیر می‌کند.

## **به‌روزرسانی سبک‌های پس‌زمینه تم**

پرکننده‌های پس‌زمینه تم در [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iformatscheme/) ذخیره می‌شوند. PowerPoint می‌تواند در رابط کاربری خود گزینه‌های پس‌زمینه بیشتری نسبت به تعداد تعریف‌های پرکننده فیزیکی در این مجموعه نشان دهد، زیرا رابط می‌تواند پرکننده‌های تم را با رنگ‌های تم و سایر ارجاعات سبک ترکیب کند.

![گالری سبک پس‌زمینه PowerPoint برای تم ارائه](presentation-design_8.png)

قبل از استفاده از یک سبک پس‌زمینه، مجموعه ذخیره‌شده و مقدار [Background.getStyleIndex](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/background/) فعلی را بررسی کنید. مقدار شاخص `0` به این معنی است که پرکننده تمی نیست؛ مقادیر مثبت ارجاع‌های سبک پس‌زمینه تم هستند. این موضوع با ایندکس‌گذاری مستقیم مجموعه Java متفاوت است؛ `get_Item(0)` به اولین مورد ذخیره‌شده اشاره دارد. فرض نکنید که هر ارائه همان تعداد سبک پرکننده پس‌زمینه را دارد.

مثال زیر تعداد پرکننده‌های پس‌زمینه موجود را گزارش می‌کند، یک ارجاع پس‌زمینه تم به اولین مستر اختصاص می‌دهد و ارائه را ذخیره می‌کند:

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

نتیجهٔ قابل مشاهده به ورودی تم ارجاع‌شده توسط مستر و هر بازنویسی پس‌زمینه در سطح لایه یا اسلاید بستگی دارد. اگر اسلاید پس‌زمینهٔ خود را داشته باشد، تغییر فقط پس‌زمینهٔ مستر ممکن است آن اسلاید را تغییر ندهد. برای دانستن پس‌زمینهٔ نهایی پس از اعمال وراثت، از [Background.getEffective](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/background/) استفاده کنید.

{{% alert color="warning" title="هشدار" %}}
شاخص سبک را به‌عنوان ایندکس صفر‑پایهٔ یک مجموعه در نظر نگیرید. همچنین از کدگذاری یک شماره سبک از یک فایل و فرض بر اینکه در فایل دیگر همان ظاهر را دارد، خودداری کنید؛ تعاریف سبک تم برای هر ارائه خاص هستند.
{{% /alert %}}

{{% alert color="info" title="نکته" %}}
برای قالب‌بندی مستقیم پس‌زمینه و وراثت پس‌زمینه، به [Presentation Background](/slides/fa/androidjava/presentation-background/) مراجعه کنید.
{{% /alert %}}

## **به‌روزرسانی اثرهای تم**

یک اسکیم فرمت تم شامل مجموعه‌های جداگانهٔ پرکننده، خط و اثر است که از طریق [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iformatscheme/)، [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iformatscheme/)، و [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iformatscheme/) در دسترس هستند. تم‌های معمولی Office اغلب سه ورودی اصلی سبک دارند که به‌صورت بصری به قالب‌بندی‌های ملایم، متوسط و شدید متناظرند، اما کد باید هر مجموعه را بررسی کند و از فرض تعداد ثابت خودداری کند.

![اثرهای ملایم، متوسط و شدید تم که بر همان شکل اعمال شده‌اند](presentation-design_10.png)

هنگام دسترسی به این مجموعه‌ها در Java، ایندکس مجموعه صفر‑پایه است: `get_Item(0)` اولین سبک ذخیره‌شده و `get_Item(2)` سومین است. ایندکس‌های ارجاع به سبک یک شکل مفهومی جداگانه است که از طریق [IShapeStyle](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapestyle/) در دسترس است. تغییر یک سبک تم بر شکل‌هایی که به آن ارجاع می‌دهند اثر می‌گذارد؛ شکل‌هایی با قالب‌بندی مستقیم ممکن است بدون تغییر بمانند.

مثال زیر وجود ورودی‌های سبک لازم را بررسی می‌کند، اولین سبک خط را تغییر می‌دهد، سومین سبک پرکننده را تغییر می‌دهد، یک سایهٔ خارجی را در سومین سبک اثر فعال می‌کند و نتیجه را ذخیره می‌سازد:

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

برای شکل‌هایی که به این فضاها ارجاع می‌دهند، اولین سبک خط تم به‌قرمز می‌شود، سومین سبک پرکننده تم به رنگ سبز جنگلی ثابت تبدیل می‌شود و سومین سبک اثر یک سایهٔ خارجی با فاصلهٔ 10 پوینت دریافت می‌کند. نتیجهٔ بصری نهایی هنوز به این بستگی دارد که هر شکل به کدام فضاها ارجاع می‌دهد و آیا قالب‌بندی مستقیم بر تم ارجاع دارد یا نه.

![سبک‌های اثر تم پس از تغییر تنظیمات خط، پرکننده و سایه](presentation-design_11.png)

## **تشخیص اینکه آیا یک پرکنندهٔ جامد مؤثر از رنگ تم استفاده می‌کند**

یک پرکننده می‌تواند به‌صورت مستقیم بر روی شیء ذخیره شود یا از یک پاراگراف، لایه، مستر، سبک تم یا سطح دیگری از قالب‌بندی وراثت بگیرد. برای حل این سلسله‌مراتب به یک شیء غیرقابل تغییر [IFillFormatEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifillformateffectivedata/) می‌توانید از [IFillFormat.getEffective](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifillformat/) استفاده کنید. ابتدا [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifillformateffectivedata/) را بررسی کنید. فقط زمانی که مقدار `FillType.Solid` باشد، باید خواص پرکنندهٔ جامد را بخوانید.

برای یک پرکنندهٔ جامد، [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifillformateffectivedata/) مقدار نهایی RGB پس از وراثت، جست‌وجوی تم و اعمال تبدیل‌های رنگی را برمی‌گرداند. [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifillformateffectivedata/) اسلات منطقی مربوط به [SchemeColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/schemecolor/) را مانند `Text1` یا `Accent6` برمی‌گرداند. مقدار `SchemeColor.NotDefined` به این معناست که پرکنندهٔ جامد مؤثر بر پایهٔ یک رنگ شماردار نیست. در کاری که پرکننده‌ها یا رنگ‌های تم یا رنگ‌های مستقیم RGB هستند، این مقدار یک پرکنندهٔ مستقیم RGB را شناسایی می‌کند.

فقط از مقدار محلی [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icolorformat/) برای طبقه‌بندی پرکننده استفاده نکنید. برای مثال، بخشی از متن ممکن است رنگ شماردار محلی نداشته باشد، بنابراین مقدار محلی‌اش `NotDefined` است، در حالی که پرکنندهٔ مؤثر آن یک رنگ تم ارث‌بری شده و به `Text1` یا `Accent6` حل می‌شود. برعکس، `getSolidFillSchemeColor` به شما می‌گوید کدام اسلات منطقی تم رنگ نهایی را تولید کرده، اما نمی‌گوید این اسلات از شیء، پاراگراف، لایه، مستر یا سطح دیگری آمده است.

مثال زیر ارائه‌ای را بارگذاری می‌کند، پرکننده‌های شکل و پرکننده‌های بخش‌های متن را بررسی می‌کند، هر مقدار RGB نهایی و رنگ شماردار مرتبط را چاپ می‌کند و پرکننده‌های جامدی که تغییرات رنگ تم را دنبال نمی‌کنند، علامت‌گذاری می‌کند:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    int rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, Color.red(rgb), Color.green(rgb), Color.blue(rgb));
    System.out.println(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor.NotDefined) {
        System.out.println(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        System.out.println(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
};

Presentation presentation = new Presentation("input.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);

        int shapeCount = slide.getShapes().size();
        for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            String shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill.accept(shapeName, shape.getFillFormat());

            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                int paragraphCount = autoShape.getTextFrame().getParagraphs().getCount();
                for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    int portionCount = paragraph.getPortions().getCount();
                    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        IPortion portion = paragraph.getPortions().get_Item(portionIndex);
                        String portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill.accept(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

شاخهٔ `NotDefined` فهرستی از پرکننده‌های جامد ارائه می‌دهد که به تغییرات اسلات رنگ تم واکنش نمی‌دهند. هنگام نیاز به پیروی یک ارائه از پالت برند جدید، این اشیا را بازبینی کنید. مقدار RGB گزارش‌شده هنوز ظاهر فعلی را نشان می‌دهد، در حالی که مقدار شماردار توضیح می‌دهد که آیا آن ظاهر به تم مرتبط است یا نه.

اشیاء مؤثر‑فرمت اسنپ‌شات هستند. پس از تغییر تم ارائه، بازنویسی تم یا هر قالب‌بندی ارث‌بری‌شده، دوباره `getEffective` را فراخوانی کنید و قبل از مقایسه یا گزارش رنگ‌ها، شیء جدید `IFillFormatEffectiveData` را بخوانید.

## **خواندن مقادیر مؤثر تم**

اشیاء تم خام به شما می‌گویند چه چیزی در یک سطح خاص تعریف شده است. مقادیر مؤثر به شما می‌گویند یک اسلاید یا شکل پس از حل وراثت و بازنویسی‌های محلی دقیقاً چه چیزی استفاده می‌کند. برای یک اسلاید، متد [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/baseoverridethememanager/) را فراخوانی کنید. برای پس‌زمینه، از [Background.getEffective](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/background/) و برای پرکننده، از [FillFormat.getEffective](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fillformat/) استفاده کنید.

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

از داده‌های مؤثر برای عیب‌یابی رندر، اعتبارسنجی و مقایسه‌ها استفاده کنید. اگر فقط [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) را بررسی کنید، ممکن است بازنویسی‌های مستر، لایه، اسلاید یا شکل که ظاهر نهایی را تغییر می‌دهند از دست بدهید.

## **سؤال‌های متداول**

**آیا اعمال تم خارجی بر تمام اسلایدهای ارائه تأثیر می‌گذارد؟**

خیر. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterslide/) فقط اسلایدهایی را که به مستر انتخاب‌شده وابسته‌اند، مجدداً اختصاص می‌دهد. اسلایدهایی که از مسترهای دیگر استفاده می‌کنند تم‌های موجود خود را حفظ می‌کنند.

**آیا می‌توانم تم را تنها بر یک اسلاید بدون تغییر مستر اعمال کنم؟**

بله. از [SlideThemeManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slidethememanager/) اسلاید استفاده کنید و بازنویسی تم آن را اولیه کنید. تغییر فقط به‌صورت محلی بر آن اسلاید باقی می‌ماند؛ اسلایدهای دیگر همچنان تم‌های موجود خود را ارث می‌برند.

**امن‌ترین روش برای انتقال تم از یک ارائه به ارائه دیگر چیست؟**

هنگام جابه‌جایی یک اسلاید و حفظ ظاهر مبدأ، مستر منبع را به مقصد کلون کنید و سپس اسلاید را همراه با آن مستر با استفاده از [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterslidecollection/) و [ISlideCollection.addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidecollection/) کلون کنید. این کار مستر، لایه‌ها و تم را با هم نگه می‌دارد.

**چگونه می‌توانم مقادیر مؤثر پس از وراثت و بازنویسی‌ها را مشاهده کنم؟**

از [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/baseoverridethememanager/) برای یک اسلاید یا تم لایه استفاده کنید و برای اشیاء فرمت مربوطه از روش‌های دادهٔ مؤثر مثل [Background.getEffective](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/background/) و [FillFormat.getEffective](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fillformat/) بهره بگیرید. این APIها مقادیر حل‌شده پس از اعمال وراثت و بازنویسی‌ها را برمی‌گردانند.