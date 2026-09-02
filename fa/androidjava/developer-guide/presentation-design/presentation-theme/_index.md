---
title: مدیریت تم‌های ارائه در Android
linktitle: تم ارائه
type: docs
weight: 10
url: /fa/androidjava/presentation-theme/
keywords:
- "تم PowerPoint"
- "تم ارائه"
- "تم اسلاید"
- "ست تم"
- "تغییر تم"
- "مدیریت تم"
- "تم خارجی"
- "THMX"
- "رنگ تم"
- "پالت اضافی"
- "قلم تم"
- "استایل تم"
- "افکت تم"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "Android"
- "Java"
- "Aspose.Slides"
description: "مدیریت تم‌های اصلی ارائه در Aspose.Slides برای Android توسط Java برای ایجاد، سفارشی‌سازی و تبدیل فایل‌های PowerPoint با برندینگ ثابت."
---
## **معرفی**

یک تم ارائه مجموعه‌ای هماهنگ از رنگ‌ها، قلم‌ها، سبک‌های پس‌زمينه، پرکننده‌ها، خطوط و افکت‌ها را تعریف می‌کند. اشیاء آگاه از تم به این تعاریف مشترک مراجعه می‌کنند به‌جای این‌که هر ویژگی بصری را به‌عنوان مقدار ثابت ذخیره کنند، بنابراین تغییر تم می‌تواند بسیاری از اشیاء را به‌صورت همزمان به‌روزرسانی کند.

در Aspose.Slides، تم سطح ارائه از طریق [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) در دسترس است. یک ارائه می‌تواند بازنویسی‌های تم را در سطوح پایین‌تر نیز داشته باشد. یک مستر می‌تواند تم ارائه را از طریق [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/masterthememanager/) بازنویسی کند، در حالی که یک طرح‌بندی یا اسلاید منفرد می‌تواند تم ارث‌بری شده خود را از طریق [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/baseoverridethememanager/) بازنویسی کند. در عمل، تم مؤثر برای یک اسلاید از طریق این زنجیره ارث‌بری حل می‌شود: تم ارائه، بازنویسی مستر، بازنویسی طرح‌بندی، و بازنویسی اسلاید.

![اجزای تم: رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه و افکت‌ها](theme-constituents.png)

بخش‌های زیر رایج‌ترین جریان‌کارهای تم را نشان می‌دهند: بررسی یک تم، تغییر رنگ‌ها و قلم‌ها، کپی یا اعمال یک تم، به‌روزرسانی سبک‌های پس‌زمینه و افکت، و خواندن مقادیر مؤثر پس از حل ارث‌بری و بازنویسی‌ها.

## **بررسی یک تم**

شیء [MasterTheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/mastertheme/) طرح‌وارهٔ رنگ، طرح‌وارهٔ قلم و طرح‌وارهٔ قالب تم را از طریق [MasterTheme.getColorScheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/mastertheme/)، [MasterTheme.getFontScheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/mastertheme/)، و [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/mastertheme/) عرضه می‌کند. بررسی این مجموعه‌ها پیش از تغییر آنها به‌ویژه وقتی ارائه از منبع خارجی می‌آید مفید است؛ زیرا تعداد و محتوای ورودی‌های سبک می‌توانند متفاوت باشند.

مثال زیر ویژگی‌های اصلی تم را می‌خواند و تعداد سبک‌های پس‌زمینه، پرکننده، خط و افکت ذخیره‌شده در تم را گزارش می‌دهد:

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

اگر فایلی از چند مستر استفاده کند، فرض نکنید که هر اسلاید همان تم مؤثر را دارد. مستری که به اسلاید مربوط است را بررسی کنید و از جریان‌کار تم مؤثر که در ادامه مقاله نشان داده شده است استفاده کنید وقتی بازنویسی‌های طرح‌بندی یا اسلاید ممکن است وجود داشته باشند.

## **تغییر رنگ‌های تم**

پرکننده‌ها، خطوط و متن‌های آگاه از تم می‌توانند به یک رنگ منطقی از شمارشگر [SchemeColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/schemecolor/) ارجاع دهند. وقتی ورودی مربوطه در [IColorScheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icolorscheme/) تغییر می‌کند، تمام اشیائی که هنوز به آن رنگ تم ارجاع می‌دهند بر اساس مقدار جدید حل می‌شوند. اشیائی که از رنگ RGB مستقیم استفاده می‌کنند توسط به‌روزرسانی رنگ تم تغییر نمی‌کنند.

مثال انتها به انتهای زیر یک شکل ایجاد می‌کند که از `Accent4` استفاده می‌کند، رنگ `Accent4` تم را به قرمز تغییر می‌دهد، ارائه را ذخیره می‌کند، دوباره باز می‌کند و رنگ پرکننده مؤثر را چاپ می‌کند:

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

چون مستطیل همچنان به `Accent4` مرتبط است، رنگ قابل مشاهده آن پس از تغییر تم به قرمز می‌شود. اگر رنگ طرح‌واره را با یک رنگ مستقیم در شکل جایگزین کنید، تغییرات بعدی `Accent4` دیگر بر آن پرکننده تأثیر نخواهد داشت.

### **استفاده از رنگ‌ها از پالت اضافی**

PowerPoint با اعمال تبدیلات رنگ، انواع روشن‌تر و تیره‌تر را از یک رنگ تم تولید می‌کند. Aspose.Slides این تبدیلات را از طریق شمارشگر [ColorTransformOperation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/colortransformoperation/) عرضه می‌کند.

![رنگ‌های اصلی تم و رنگ‌های روشن‌تر و تیره‌تری که از پالت اضافی تولید شده‌اند](additional-palette-colors.png)

**1** - رنگ‌های اصلی تم.

**2** - انواع روشن‌تر و تیره‌تری که از رنگ‌های اصلی تم تولید شده‌اند.

مثال زیر شش مستطیل مبتنی بر `Accent4` ایجاد می‌کند، برای پنج‌ تا از آنها تبدیلات روشنایی اعمال می‌کند و نتیجه را ذخیره می‌کند:

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

این انواع همچنان مبتنی بر رنگ تم هستند. اگر `Accent4` پس از آن تغییر کند، رنگ‌های تبدیل‌شده از مقدار جدید `Accent4` بازمحاسبه می‌شوند.

### **نقشه‌برداری مقادیر `SchemeColor` به اسلات‌های `IColorScheme`**

شمارشگر [SchemeColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/schemecolor/) از `Text1`، `Background1`، `Text2` و `Background2` استفاده می‌کند، در حالی که [IColorScheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icolorscheme/) همان اسلات‌های تم را به‌صورت `Dark1`، `Light1`، `Dark2` و `Light2` نمایان می‌کند. نقشه‌برداری ثابت است:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

این‌ها نام‌های جایگزین برای همان اسلات‌های تم هستند؛ مقادیری که به‌صورت پویا از یک شکل به شکل دیگر تبدیل می‌شوند نیستند.

## **تغییر قلم‌های تم**

یک طرح‌وارهٔ قلم تم شامل مجموعهٔ اصلی قلم برای عناوین و مجموعهٔ فرعی قلم برای متن بدنه است. متدهای [IFontScheme.getMajor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifontscheme/) و [IFontScheme.getMinor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifontscheme/) این مجموعه‌ها را نمایان می‌کنند.

شناسه‌های قلم تم سازگار با PowerPoint می‌توانند در قالب‌بندی متن استفاده شوند:

* `+mn-lt` - قلم بدنه لاتین (Minor Latin Font)
* `+mj-lt` - قلم عنوان لاتین (Major Latin Font)
* `+mn-ea` - قلم بدنه آسیای شرقی (Minor East Asian Font)
* `+mj-ea` - قلم عنوان آسیای شرقی (Major East Asian Font)

مثال زیر یک عنوان که از قلم لاتین اصلی تم استفاده می‌کند و یک خط بدنه که از قلم لاتین فرعی تم استفاده می‌کند، ایجاد می‌کند. سپس قلم‌های تم را تغییر داده و نتیجه را ذخیره می‌کند:

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

عنوان از قلم اصلی پیروی می‌کند و متن بدنه از قلم فرعی. متنی که به‌صورت صریح نام قلم دارد به‌جای شناسهٔ تم، هنگام تغییر طرح‌وارهٔ قلم تم به‌صورت خودکار تغییر نمی‌کند.

مجموعه‌های قلم اصلی و فرعی می‌توانند شامل نگاشت‌های قلم برای سیستم‌های نوشتاری جداگانه مانند سیریلیک، عربی، ژاپنی، گرجی و ثان نیز باشند. برای بررسی، افزودن، جایگزینی یا حذف این نگاشت‌ها، به [قلم‌های تم مخصوص اسکریپت](/slides/fa/androidjava/script-specific-font-mappings/) مراجعه کنید.

{{% alert color="info" title="Tip" %}}
برای اطلاعات بیشتر درباره قلم‌های ارائه، به [قلم‌های PowerPoint](/slides/fa/androidjava/powerpoint-fonts/) مراجعه کنید.
{{% /alert %}}

## **کپی یا اعمال یک تم**

جریان‌کارهای زیر مشکلات مختلف مرتبط با تم را حل می‌کنند.

### **اعمال تم خارجی به اسلایدهای وابسته به یک مستر**

از [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterslide/) زمانی که فایل تم PowerPoint (`.thmx`) داشته باشید و بخواهید تمام اسلایدهایی که به یک مستر خاص وابسته‌اند را بازطراحی کنید، استفاده کنید. مستر را از مجموعه [Presentation.getMasters](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) که پیاده‌سازی‌شده توسط [IMasterSlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterslidecollection/) است، انتخاب کنید و مسیر فایل تم را به متد پاس بدهید.

متد عملیات‌های زیر را انجام می‌دهد:

1. یک مستر اسلاید جدید بر پایه مستر انتخاب‌شده ایجاد می‌کند.
1. تم خارجی را بر روی مستر جدید اعمال می‌کند.
1. مستر جدید را به تمام اسلایدهایی که قبلاً به مستر انتخاب‌شده وابسته بودند انتساب می‌دهد.
1. شیء تازه ساخته‌شدهٔ [IMasterSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterslide/) را برمی‌گرداند.

مثال زیر تم خارجی را بر اسلایدهایی که به اولین مستر وابسته‌اند اعمال می‌کند و ارائه را ذخیره می‌نماید:

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

یک تم نامعتبر، خراب یا پشتیبانی‌نشده می‌تواند منجر به [PptxReadException](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pptxreadexception/) شود. مسیرهای تأمین‌شده توسط کاربران را اعتبارسنجی کنید، خطاهای دسترسی به فایل‌سیستم را مدیریت کنید و فقط پس از موفقیت‌آمیز بودن اعمال تم، ارائه را ذخیره کنید.

فقط اسلایدهایی که به مستر انتخاب‌شده وابسته بودند بازاختصاص می‌یابند. اسلایدهایی که به مسترهای دیگر مرتبط‌اند مستر و تم‌های موجود خود را حفظ می‌کنند. رنگ‌ها، قلم‌ها، پرکننده‌ها، خطوط، پس‌زمینه‌ها و افکت‌های آگاه از تم بر اساس تم خارجی حل می‌شوند. رنگ‌ها، قلم‌ها، پرکننده‌ها و سایر قالب‌بندی‌های صریح ممکن است تغییری نکنند. بازنویسی‌های سطح طرح‌بندی و سطح اسلاید نیز می‌توانند بر مقادیر ارث‌بری شده از مستر جدید اولویت داشته باشند.

تم می‌تواند به قلم‌هایی اشاره کند که در محیط زمان اجرا موجود نیستند. برای رندرینگ و خروجی ثابت، قلم‌های مورد نیاز را نصب کنید، از [منابع قلم سفارشی](/slides/fa/androidjava/custom-font/) استفاده کنید یا [جایگزینی قلم](/slides/fa/androidjava/font-substitution/) را پیکربندی کنید.

این یک جریان‌کار مستقیم در سطح مستر است: متد مسیر فایل `.thmx` را می‌پذیرد و نیازی به ایجاد بازنویسی‌های تم در سطح اسلاید یا طرح‌بندی به‌صورت دستی نیست.

### **اعمال تم‌های خارجی متفاوت در ارائه چندمستری**

وقتی مستر مربوطه پیشاپیش شناخته نشده باشد، آن را از یک اسلاید نماینده از طریق [ISlide.getLayoutSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/) و [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilayoutslide/) بدست آورید. پیش از اعمال هر تمی، مراجع مستر اصلی را ذخیره کنید زیرا هر فراخوانی یک مستر دیگر در ارائه ایجاد می‌کند.

مثال زیر اسلایدهای دو بخش را برای یافتن مسترهایشان استفاده می‌کند و برای هر گروه تم خارجی متفاوتی اعمال می‌نماید:

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

فراخوانی اول فقط بر اسلایدهایی که به `firstGroupMaster` وابسته‌اند تأثیر می‌گذارد و فراخوانی دوم فقط بر اسلایدهایی که به `secondGroupMaster` وابسته‌اند. اسلایدهایی که به هر مستر دیگری تعلق دارند بازطراحی نمی‌شوند.

### **حفظ تم منبع هنگام جابجایی اسلایدها**

اگر می‌خواهید اسلایدی را به ارائه دیگری منتقل کنید و طرح اولیه آن را حفظ کنید، مستر منبع را با استفاده از [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterslidecollection/) به ارائه هدف کلون کنید، سپس اسلاید را با استفاده از [ISlideCollection.addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidecollection/) و مستر کلون‌شده کلون کنید. این کار مستر، طرح‌بندی‌های آن و تم مربوطه را همراه خود می‌برد.

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

این جریان‌کار ترجیحی است وقتی اسلاید منبع باید در مقصد همان ظاهر را داشته باشد. به‌سادگی کلون کردن محتوا روی مستری نامرتبط در مقصد می‌تواند رنگ‌ها، قلم‌ها، پس‌زمینه‌ها و افکت‌های مبتنی بر تم را تغییر دهد.

### **اعمال مقادیر تم به یک اسلاید موجود**

اگر اسلاید هدف باید روی مستر و طرح‌بندی فعلی خود بماند، یک بازنویسی سطح اسلاید را از تم منبع مقداردهی اولیه کنید. متدهای [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/overridetheme/)، [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/overridetheme/) و [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/overridetheme/) سه مؤلفهٔ اصلی تم را به بازنویسی کپی می‌کنند.

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

این کار تم استفاده‌شده توسط آن اسلاید را بدون تغییر تم ارث‌بری‌شده توسط سایر اسلایدها تغییر می‌دهد. برای حذف بازنویسی محلی و بازگشت به مقادیر ارث‌بری‌شده، متد [OverrideTheme.clear](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/overridetheme/) را فراخوانی کنید.

### **اعمال بازنویسی تم به یک طرح‌بندی**

بازنویسی سطح طرح‌بندی بر اسلایدهایی که از آن طرح‌بندی استفاده می‌کنند اعمال می‌شود، مگر اینکه اسلاید خاصی بازنویسی خودش را داشته باشد. همان متدهای مقداردهی اولیه می‌توانند از طریق [LayoutSlideThemeManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/layoutslidethememanager/) استفاده شوند:

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

زمانی که بسیاری از طرح‌بندی‌ها و اسلایدها باید همان طراحی پایه را به‌اشتراک بگذارند، از تم سطح مستر یا ارائه استفاده کنید؛ وقتی یک خانوادهٔ طرح‌بندی نیاز به استایل متفاوتی دارد، بازنویسی طرح‌بندی؛ و برای استثنای واقعی فقط بازنویسی اسلاید. بازنویسی‌های افراطی در سطح اسلاید، تغییرات تم سراسری بعدی را پیش‌بینی‌ناپذیر می‌سازد.

## **به‌روزرسانی سبک‌های پس‌زمینه تم**

پرکننده‌های پس‌زمینه تم در [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iformatscheme/) ذخیره می‌شوند. PowerPoint می‌تواند گزینه‌های پس‌زمینه بیشتری را در رابط کاربری خود نشان دهد نسبت به تعداد تعریف‌های پرکننده فیزیکی ذخیره‌شده در این مجموعه، زیرا UI می‌تواند پرکننده‌های تم را با رنگ‌های تم و سایر مراجع سبک ترکیب کند.

![گالری سبک‌های پس‌زمینه PowerPoint برای تم یک ارائه](presentation-design_8.png)

قبل از استفاده از یک سبک پس‌زمینه، مجموعه ذخیره‌شده و مقدار فعلی [Background.getStyleIndex](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/background/) را بررسی کنید. یک ایندکس سبک `0` به این معنی است که پرکننده تمی وجود ندارد؛ مقادیر مثبت ارجاع به استایل‌های پس‌زمینهٔ تم هستند. این متفاوت از ایندکس‌گذاری مستقیم مجموعهٔ Java است که در آن `get_Item(0)` اولین آیتم ذخیره‌شده را برمی‌گرداند. فرض نکنید که هر ارائه همان تعداد سبک پس‌زمینه دارد.

مثال زیر تعداد پرکننده‌های پس‌زمینه موجود را گزارش می‌کند، یک ارجاع پس‌زمینهٔ تم‌شده را به اولین مستر اختصاص می‌دهد و ارائه را ذخیره می‌کند:

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

نتیجهٔ قابل مشاهده بسته به ورودی تم‌ای که مستر به آن ارجاع می‌دهد و هر بازنویسی پس‌زمینه در سطح طرح‌بندی یا اسلاید متفاوت است. اگر اسلاید پس‌زمینهٔ خود را داشته باشد، تغییر فقط پس‌زمینهٔ مستر ممکن است آن اسلاید را تغییر ندهد. برای دانستن پس‌زمینهٔ نهایی پس از اعمال ارث‌بری، از [Background.getEffective](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/background/) استفاده کنید.

{{% alert color="warning" title="Warning" %}}
ایندکس سبک را به‌عنوان یک ایندکس صفر‑پایه مجموعه در نظر نگیرید. همچنین از سخت‌کد کردن شمارهٔ سبک از یک فایل و فرض اینکه در فایل دیگر همان ظاهر را دارد خودداری کنید؛ تعریف‌های سبک تم به‌صورت خاص برای هر ارائه‌اند.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
برای قالب‌بندی مستقیم پس‌زمینه و ارث‌بری پس‌زمینه، به [پس‌زمینهٔ ارائه](/slides/fa/androidjava/presentation-background/) مراجعه کنید.
{{% /alert %}}

## **به‌روزرسانی افکت‌های تم**

یک طرح‌وارهٔ قالب تم شامل مجموعه‌های جداگانهٔ پرکننده، خط و افکت است که از طریق [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iformatscheme/)، [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iformatscheme/)، و [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iformatscheme/) در دسترس هستند. تم‌های معمول Office اغلب شامل سه ورودی اصلی هستند که به‌صورت بصری به استایل‌های «ملایم»، «متوسط» و «قوی» متناظر می‌شوند، اما کد باید هر مجموعه را بررسی کند به‌جای این‌که تعداد ثابت فرض کند.

![افکت‌های تم ملایم، متوسط و قوی که بر یک شکل یکسان اعمال شده‌اند](presentation-design_10.png)

وقتی این مجموعه‌ها را در Java دسترسی می‌یابید، ایندکس مجموعه صفر‑پایه است: `get_Item(0)` اولین استایل ذخیره‌شده و `get_Item(2)` سومین استایل. ایندکس‌های مرجع استایل‌ یک شکل مفهومی جداگانه است که از طریق [IShapeStyle](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapestyle/) ارائه می‌شود. تغییر یک استایل تم بر اشکالی که به آن استایل ارجاع می‌دهند تأثیر می‌گذارد؛ اشکالی که به‌صورت مستقیم قالب‌بندی شده‌اند ممکن است تغییر نکنند.

مثال زیر بررسی می‌کند که ورودی‌های استایل مورد نیاز وجود دارند، اولین استایل خط را تغییر می‌دهد، سومین استایل پرکننده را تغییر می‌دهد، یک سایهٔ بیرونی را در سومین استایل افکت فعال می‌کند و نتیجه را ذخیره می‌کند:

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

برای اشکالی که به این اسلات‌ها ارجاع می‌دهند، اولین استایل خط تم به قرمز تغییر می‌یابد، سومین استایل پرکننده تم به سبز جنگلی ثابت می‌شود و سومین استایل افکت یک سایهٔ بیرونی با فاصلهٔ ۱۰ پوینت دریافت می‌کند. نتیجهٔ بصری دقیق همچنان به اینکه هر شکل به کدام اسلات استایل ارجاع می‌دهد و آیا قالب‌بندی مستقیم بر تم ارجاع برتری دارد یا نه، بستگی دارد.

![استایل‌های افکت تم پس از تغییر تنظیمات خط، پرکننده و سایه](presentation-design_11.png)

## **خواندن مقادیر مؤثر تم**

اشیاء تم خام به شما می‌گویند چه چیزی در یک سطح خاص تعریف شده است. مقادیر مؤثر به شما می‌گویند یک اسلاید یا شکل پس از حل ارث‌بری و بازنویسی‌های محلی چه چیزی استفاده می‌کند. برای یک اسلاید، متد [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/baseoverridethememanager/) را صدا بزنید. برای یک پس‌زمینه، از [Background.getEffective](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/background/) استفاده کنید و برای یک پرکننده، از [FillFormat.getEffective](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fillformat/) استفاده کنید.

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

از داده‌های مؤثر برای تشخیص رندر، اعتبارسنجی و مقایسه‌ها استفاده کنید. اگر فقط [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) را بررسی کنید، ممکن است بازنویسی‌های مستر، طرح‌بندی، اسلاید یا شکل را که ظاهر نهایی را تغییر می‌دهند از دست بدهید.

## **سوالات متداول**

**آیا اعمال تم خارجی بر همه اسلایدهای ارائه تأثیر می‌گذارد؟**

خیر. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterslide/) فقط اسلایدهایی را بازاختصاص می‌دهد که به مستر انتخاب‌شده وابسته‌اند. اسلایدهایی که از مسترهای دیگر استفاده می‌کنند تم موجود خود را حفظ می‌کنند.

**آیا می‌توانم تم را فقط به یک اسلاید اعمال کنم بدون تغییر مستر؟**

بله. از [SlideThemeManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slidethememanager/) اسلاید استفاده کنید و بازنویسی تم آن را مقداردهی اولیه کنید. تغییر فقط به‌صورت محلی به آن اسلاید اعمال می‌شود؛ اسلایدهای دیگر به تم‌های موجود خود ادامه می‌دهند.

**امن‌ترین روش برای انتقال تم از یک ارائه به ارائه دیگر چیست؟**

هنگام جابجایی اسلاید و حفظ ظاهر منبع، مستر منبع را به مقصد کلون کنید و اسلاید را با همان مستر با استفاده از [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterslidecollection/) و [ISlideCollection.addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidecollection/) کلون کنید. این کار مستر، طرح‌بندی‌ها و تم را به‌صورت یک‌جا نگه می‌دارد.

**چگونه می‌توانم مقادیر مؤثر را پس از ارث‌بری و بازنویسی‌ها ببینم؟**

از [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/baseoverridethememanager/) برای یک اسلاید یا تم طرح‌بندی استفاده کنید و برای اشیای قالب مانند [Background.getEffective](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/background/) و [FillFormat.getEffective](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fillformat/) از متدهای مؤثر‑داده مربوطه استفاده کنید. این APIها مقادیر حل‌ شده پس از اعمال ارث‌بری و بازنویسی‌ها را برمی‌گردانند.