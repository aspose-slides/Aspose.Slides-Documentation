---
title: مدیریت تم‌های ارائه در Java
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
- پالت افزودنی
- قلم تم
- استایل تم
- افکت تم
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "مدیریت تم‌های ارائه اصلی در Aspose.Slides برای Java برای ایجاد، سفارشی‌سازی و تبدیل فایل‌های PowerPoint با یک برند یکسان."
---
## **مقدمه**

یک تم ارائه مجموعه‌ای هماهنگ از رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه، پرکننده‌ها، خطوط و افکت‌ها را تعریف می‌کند. شیءهای آگاه از تم به جای ذخیره هر ویژگی بصری به‌صورت مقدار ثابت، به این تعاریف مشترک ارجاع می‌دهند، بنابراین تغییر تم می‌تواند بسیاری از اشیا را به‌صورت همزمان به‌روزرسانی کند.

در Aspose.Slides، تم سطح ارائه از طریق [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) در دسترس است. یک ارائه می‌تواند همچنین بازنویسی‌های تم را در سطوح پایین‌تر داشته باشد. یک مستر می‌تواند تم ارائه را از طریق [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/masterthememanager/) بازنویسی کند، در حالی که یک لِیَوت یا اسلاید فردی می‌تواند تم ارث‌بری شده خود را از طریق [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseoverridethememanager/) بازنویسی کند. در عمل، تم مؤثر برای یک اسلاید از طریق این زنجیره وراثت حل می‌شود: تم ارائه، بازنویسی مستر، بازنویسی لِیَوت و بازنویسی اسلاید.

![اجزای تم: رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه و افکت‌ها](theme-constituents.png)

بخش‌های زیر رایج‌ترین کارهای مربوط به تم را نشان می‌دهند: بررسی یک تم، تغییر رنگ‌ها و قلم‌ها، کپی یا اعمال یک تم، به‌روزرسانی سبک‌های پس‌زمینه و افکت، و خواندن مقادیر مؤثر پس از حل وراثت و بازنویسی‌ها.

## **بررسی یک تم**

شیء [MasterTheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mastertheme/) طرح‌واره رنگ، طرح‌واره قلم و طرح‌واره قالب تم را از طریق [MasterTheme.getColorScheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mastertheme/)، [MasterTheme.getFontScheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mastertheme/) و [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/mastertheme/) در دسترس می‌گذارد. بررسی این مجموعه‌ها پیش از تغییر آن‌ها به‌ویژه زمانی که یک ارائه از منبع خارجی می‌آید مفید است، چون تعداد و محتویات ورودی‌های سبک می‌تواند متفاوت باشد.

مثال زیر ویژگی‌های اصلی تم را می‌خواند و تعداد سبک‌های پس‌زمینه، پرکننده، خط و افکت ذخیره‌شده در تم را گزارش می‌کند:

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

اگر فایلی از چند مستر استفاده کند، فرض نکنید که هر اسلاید همان تم مؤثر را دارد. مستری که با اسلاید مرتبط است را بررسی کنید و هنگام وجود بازنویسی‌های لِیَوت یا اسلاید، از کاربرگی تم مؤثر نشان‌داده‌شده در ادامه مقاله استفاده کنید.

## **تغییر رنگ‌های تم**

پرکننده‌ها، خطوط و متن‌های آگاه از تم می‌توانند به یک رنگ منطقی از شمارشگر [SchemeColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/schemecolor/) ارجاع دهند. زمانی که ورودی مربوطه در [IColorScheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icolorscheme/) را تغییر می‌دهید، تمام اشیائی که هنوز به آن رنگ تم ارجاع می‌دهند بر اساس مقدار جدید حل می‌شوند. اشیائی که از رنگ RGB مستقیم استفاده می‌کنند توسط به‌روزرسانی رنگ تم تغییر نمی‌کنند.

مثال زیر به‌صورت سراسری یک شکل ایجاد می‌کند که از `Accent4` استفاده می‌کند، رنگ `Accent4` تم را به قرمز تغییر می‌دهد، ارائه را ذخیره می‌کند، دوباره باز می‌کند و رنگ پرکننده مؤثر را چاپ می‌کند:

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

چون مستطیل به `Accent4` مرتبط است، پس از تغییر تم رنگ قابل‌ مشاهده آن به قرمز تبدیل می‌شود. اگر رنگ طرح‌واره را با یک رنگ مستقیم بر روی شکل جایگزین کنید، تغییرات بعدی `Accent4` دیگر آن پرکننده را تحت تأثیر قرار نمی‌دهد.

### **استفاده از رنگ‌های پالت اضافه**

PowerPoint از یک رنگ تم، نسخه‌های روشن‌تر و تیره‌تر را با اعمال تبدیل‌های رنگی تولید می‌کند. Aspose.Slides این تبدیل‌ها را از طریق شمارشگر [ColorTransformOperation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/colortransformoperation/) در دسترس می‌گذارد.

![رنگ‌های اصلی تم و رنگ‌های روشن‌تر و تیره‌تر تولیدشده از پالت اضافه](additional-palette-colors.png)

**1** - رنگ‌های اصلی تم.  
**2** - نسخه‌های روشن‌تر و تیره‌تر تولیدشده از رنگ‌های اصلی تم.

مثال زیر شش مستطیل مبتنی بر `Accent4` ایجاد می‌کند، به پنج‌تای آن‌ها تبدیل‌های روشنایی اعمال می‌کند و نتیجه را ذخیره می‌نماید:

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

این نسخه‌ها همچنان بر پایه رنگ تم باقی می‌مانند. اگر `Accent4` بعداً تغییر کند، رنگ‌های تبدیل‌شده از مقدار جدید `Accent4` محاسبه می‌شوند.

### **نقشه‌برداری مقادیر `SchemeColor` به اسلات‌های `IColorScheme`**

شمارشگر [SchemeColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/schemecolor/) از مقادیر `Text1`، `Background1`، `Text2` و `Background2` استفاده می‌کند، در حالی که [IColorScheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icolorscheme/) همان اسلات‌های تم را به‌صورت `Dark1`، `Light1`، `Dark2` و `Light2` نشان می‌دهد. نقشه‌برداری ثابت است:

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

اینها نام‌های جایگزین برای همان اسلات‌های تم هستند؛ آنها مقادیر دینامیکی که از یک شکل به شکل دیگر تبدیل می‌شوند نیستند.

## **تغییر قلم‌های تم**

یک طرح‌واره قلم تم شامل یک مجموعه قلم اصلی برای عناوین و یک مجموعه قلم فرعی برای متن اصلی است. متدهای [IFontScheme.getMajor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontscheme/) و [IFontScheme.getMinor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontscheme/) این مجموعه‌ها را افشا می‌کنند.

شناسه‌های قلم تم سازگار با PowerPoint می‌توانند در قالب‌بندی متن استفاده شوند:

* `+mn-lt` - قلم بدنه لاتین (قلم فرعی لاتین)  
* `+mj-lt` - قلم عنوان لاتین (قلم اصلی لاتین)  
* `+mn-ea` - قلم بدنه آسیای شرقی (قلم فرعی آسیای شرقی)  
* `+mj-ea` - قلم عنوان آسیای شرقی (قلم اصلی آسیای شرقی)

مثال زیر یک عنوان ایجاد می‌کند که از قلم اصلی لاتین تم استفاده می‌کند و یک خط بدنه که از قلم فرعی لاتین تم استفاده می‌کند. سپس قلم‌های تم را تغییر داده و نتیجه را ذخیره می‌کند:

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

عنوان از قلم اصلی و متن اصلی از قلم فرعی پیروی می‌کند. متنی که نام قلم صریحی دارد به‌جای شناسه تم، در زمان تغییر طرح‌واره قلم تم به‌طور خودکار تغییر نمی‌کند.

مجموعه‌های قلم اصلی و فرعی می‌توانند حاوی نگاشت‌های قلم برای سیستم‌های نوشتاری فردی باشند، مانند سیریلیک، عربی، ژاپنی، گرجستانی و ثانا. برای بررسی، افزودن، جایگزینی یا حذف این نگاشت‌ها، به [قلم‌های تم مخصوص زبان اسکریپت](/slides/fa/java/script-specific-font-mappings/) مراجعه کنید.

{{% alert color="info" title="نکته" %}}

برای اطلاعات بیشتر درباره قلم‌های ارائه، به [قلم‌های PowerPoint](/slides/fa/java/powerpoint-fonts/) نگاه کنید.

{{% /alert %}}

## **کپی یا اعمال یک تم**

کارهای زیر مشکلات مختلف مرتبط با تم را حل می‌کنند.

### **اعمال تم خارجی به اسلایدهای وابسته به یک مستر**

از [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslide/) زمانی که فایل تم PowerPoint (`.thmx`) داشته باشید و بخواهید تمام اسلایدهایی که به یک مستر خاص وابسته‌اند را بازطراحی کنید، استفاده کنید. مستر را از مجموعه [Presentation.getMasters](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) که پیاده‌سازی کننده [IMasterSlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslidecollection/) است، انتخاب کرده و مسیر فایل تم را به متد پاس دهید.

متد عملیات زیر را انجام می‌دهد:

1. یک اسلاید مستر جدید بر پایه مستر انتخاب‌شده می‌سازد.  
1. تم خارجی را به مستر جدید اعمال می‌کند.  
1. مستر جدید را به تمام اسلایدهایی که پیش‌تر به مستر انتخاب‌شده وابسته بودند اختصاص می‌دهد.  
1. `[IMasterSlide]` تازه ساخته‌شده را بر می‌گرداند.

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

تم نامعتبر، خراب یا پشتیبانی‌نشده می‌تواند خطای [PptxReadException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pptxreadexception/) ایجاد کند. مسیرهای ورودی کاربر را اعتبارسنجی کنید، شکست‌های دسترسی به سیستم فایل را مدیریت کنید و فقط پس از اعمال موفقیت‌آمیز تم، ارائه را ذخیره کنید.

فقط اسلایدهایی که به مستر انتخاب‌شده وابسته بودند بازتخصیص می‌شوند. اسلایدهای مرتبط با سایر مسترها مستر و تم‌های موجود خود را حفظ می‌کنند. رنگ‌ها، قلم‌ها، پرکننده‌ها، خطوط، پس‌زمینه‌ها و افکت‌های آگاه از تم بر پایه تم خارجی حل می‌شوند. رنگ‌ها، قلم‌ها، پرکننده‌ها و قالب‌بندی‌های صریحی که به‌طور مستقیم اختصاص یافته‌اند ممکن است بدون تغییر باقی بمانند. بازنویسی‌های سطح لِیَوت و اسلاید نیز می‌توانند بر مقادیر ارث‌بری شده از مستر جدید ارجحیت داشته باشند.

تم می‌تواند به قلم‌هایی که در محیط زمان اجرا موجود نیستند اشاره کند. برای رندر و صادرات یکسان، قلم‌های موردنیاز را نصب کنید، از [منابع قلم سفارشی](/slides/fa/java/custom-font/) استفاده کنید یا [جایگزینی قلم](/slides/fa/java/font-substitution/) را پیکربندی کنید.

این یک کار مستقیم در سطح مستر است: متد مسیر فایل `.thmx` را می‌پذیرد و نیازی به ایجاد دستی بازنویسی‌های تم در سطح اسلاید یا لِیَوت نیست.

### **اعمال تم‌های خارجی متفاوت در یک ارائه چند‑مستر**

هنگامی که مستر مرتبط از پیش شناخته نشده است، آن را از یک اسلاید نماینده از طریق [ISlide.getLayoutSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/) و [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutslide/) به دست آورید. قبل از اعمال هر تمی، مراجع مستر اصلی را ذخیره کنید چون هر فراخوانی یک مستر دیگر در ارائه می‌سازد.

مثال زیر از اسلایدهای دو بخش برای پیدا کردن مسترهایشان استفاده می‌کند و تم خارجی متفاوتی را به هر گروه اعمال می‌کند:

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

فراخوانی اول فقط اسلایدهایی را تحت تأثیر قرار می‌دهد که به `firstGroupMaster` وابسته بودند و فراخوانی دوم فقط اسلایدهایی را که به `secondGroupMaster` وابسته بودند. اسلایدهای متعلق به سایر مسترها بازطراحی نمی‌شوند.

### **حفظ تم منبع هنگام جابجایی اسلایدها**

اگر می‌خواهید اسلایدی را به ارائه دیگری منتقل کنید و طراحی اصلی آن را حفظ کنید، مستر منبع را با [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslidecollection/) به ارائه هدف کلون کنید، سپس اسلاید را با [ISlideCollection.addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecollection/) و مستر کلون‌شده کلون کنید. این کار مستر، لِیَوت‌های آن و تم مرتبط را به‌هم می‌پیوندد.

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

این روش ترجیحی است وقتی اسلاید منبع باید در مقصد همان ظاهر را داشته باشد. فقط کلون‌کردن محتوا روی یک مستر مقصد نامرتبط می‌تواند رنگ‌ها، قلم‌ها، پس‌زمینه‌ها و افکت‌های مبتنی بر تم را تغییر دهد.

### **اعمال مقادیر تم به یک اسلاید موجود**

اگر اسلاید هدف باید بر روی مستر و لِیَوت فعلی خود باقی بماند، یک بازنویسی سطح اسلاید از تم منبع مقداردهی اولیه کنید. متدهای [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/fa/java/com.aspose.slides/overridetheme/)، [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/fa/java/com.aspose.slides/overridetheme/) و [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/fa/java/com.aspose.slides/overridetheme/) سه مؤلفه اصلی تم را به بازنویسی کپی می‌کنند.

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

این تغییر تم مورد استفاده‌ی آن اسلاید را بدون تغییر تم ارث‌بری شده توسط سایر اسلایدها اعمال می‌کند. برای حذف بازنویسی محلی و بازگشت به مقادیر ارث‌بری شده، متد [OverrideTheme.clear](https://reference.aspose.com/slides/fa/java/com.aspose.slides/overridetheme/) را صدا بزنید.

### **اعمال بازنویسی تم به یک لِیَوت**

یک بازنویسی سطح لِیَوت بر اسلایدهایی که از آن لِیَوت استفاده می‌کنند اعمال می‌شود، مگر این که اسلاید خاص خود بازنویسی داشته باشد. همان متدهای مقداردهی اولیه می‌توانند از طریق [LayoutSlideThemeManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/layoutslidethememanager/) استفاده شوند:

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

از تم مستر یا تم سطح ارائه استفاده کنید وقتی بسیاری از لِیَوت‌ها و اسلایدها باید پایه طراحی یکسانی را به‌اشتراک بگذارند؛ از بازنویسی لِیَوت وقتی یک خانواده لِیَوت نیاز به استایل متفاوت دارد؛ و از بازنویسی اسلاید فقط برای استثناهای واقعی. بازنویسی‌های بیش از حد سطح اسلاید، اعمال تغییرات سراسری تم را در آینده دشوار می‌کند.

## **به‌روزرسانی سبک‌های پس‌زمینه تم**

پرکننده‌های پس‌زمینه تم در [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iformatscheme/) ذخیره می‌شوند. PowerPoint می‌تواند گزینه‌های پس‌زمینه بیشتری در رابط کاربری خود نمایش دهد نسبت به تعداد تعریف‌های پرکننده‌ای که فیزیکی در این مجموعه ذخیره شده‌اند، چون رابط می‌تواند پرکننده‌های تم را با رنگ‌های تم و سایر ارجاع‌های سبک ترکیب کند.

![گالری سبک پس‌زمینه PowerPoint برای تم ارائه](presentation-design_8.png)

قبل از استفاده از یک سبک پس‌زمینه، مجموعه ذخیره‌شده و مقدار فعلی [Background.getStyleIndex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/background/) را بررسی کنید. مقدار شاخص سبک `0` به معنی عدم وجود پرکننده تم است؛ مقادیر مثبت ارجاع‌های سبک پس‌زمینه تم هستند. این متفاوت از ایندکس‌گذاری مستقیم مجموعهٔ جاوا است، جایی که `get_Item(0)` اولین مورد ذخیره‌شده را نشان می‌دهد. فرض نکنید که هر ارائه همان تعداد سبک پرکننده پس‌زمینه را دارد.

مثال زیر تعداد پرکننده‌های پس‌زمینه موجود را گزارش می‌دهد، یک ارجاع پس‌زمینه تم به اولین مستر اختصاص می‌دهد و ارائه را ذخیره می‌کند:

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

نتیجهٔ قابل مشاهده بستگی به ورودی تم ارجاع‌شده توسط مستر و هر بازنویسی پس‌زمینه در سطح لِیَوت یا اسلاید دارد. اگر اسلاید پس‌زمینهٔ خاص خود را داشته باشد، تغییر فقط پس‌زمینهٔ مستر ممکن است آن اسلاید را تغییر ندهد. هنگام نیاز به دانستن پس‌زمینهٔ نهایی پس از اعمال وراثت، از [Background.getEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/background/) استفاده کنید.

{{% alert color="warning" title="هشدار" %}}

شاخص سبک را به‌عنوان ایندکس صفر‑پایه مجموعه در نظر نگیرید. همچنین از کدگذاری ثابت یک شماره سبک از یک فایل و فرض اینکه در فایل دیگر هم ظاهر یکسانی دارد خودداری کنید؛ تعریف‌های سبک تم مخصوص ارائه هستند.

{{% /alert %}}

{{% alert color="info" title="نکته" %}}

برای قالب‌بندی مستقیم پس‌زمینه و وراثت پس‌زمینه، به [پس‌زمینه ارائه](/slides/fa/java/presentation-background/) مراجعه کنید.

{{% /alert %}}

## **به‌روزرسانی افکت‌های تم**

یک طرح‌واره قالب تم شامل مجموعه‌های جداگانهٔ پرکننده، خط و افکت است که از طریق [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iformatscheme/)، [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iformatscheme/) و [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iformatscheme/) در دسترس هستند. تم‌های معمولی Office غالباً سه ورودی اصلی دارند که بصورت ظریف، متوسط و پر‌رنگ ظاهر می‌شوند، اما کد باید هر مجموعه را بررسی کند به جای این‌که تعداد ثابت را فرض کند.

![افکت‌های تم ظریف، متوسط و پررنگ اعمال‌شده به همان شکل](presentation-design_10.png)

هنگامی که این مجموعه‌ها را در Java دسترسی می‌کنید، ایندکس مجموعه صفر‑پایه است: `get_Item(0)` اولین سبک ذخیره‌شده و `get_Item(2)` سومین است. ایندکس‌های ارجاع‑سبک یک شکل مفهوم جداگانه‌ای است که از طریق [IShapeStyle](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapestyle/) در دسترس است. تغییر یک سبک تم بر شکل‌هایی که به آن ارجاع می‌دهند تأثیر می‌گذارد؛ شکل‌هایی که قالب‌بندی مستقیم دارند ممکن است بدون تغییر بمانند.

مثال زیر بررسی می‌کند که آیا ورودی‌های سبک مورد نیاز وجود دارد، اولین سبک خط را تغییر می‌دهد، سومین سبک پرکننده را تغییر می‌دهد، یک سایهٔ بیرونی را در سومین سبک افکت فعال می‌کند و نتیجه را ذخیره می‌کند:

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

برای شکل‌هایی که به این اسلات‌ها ارجاع می‌دهند، اولین سبک خط تم به قرمز، سومین سبک پرکننده تم به سبز جنگلی ثابت و سومین سبک افکت یک سایهٔ بیرونی با فاصلهٔ ۱۰ نقطه می‌گیرد. نتیجهٔ بصری دقیق همچنان به این‌که هر شکل کدام اسلات‌ها را ارجاع می‌دهد و آیا قالب‌بندی مستقیم بر تم ارجاع دارد یا نه، وابسته است.

![سبک‌های افکت تم پس از تغییر تنظیمات خط، پرکننده و سایه](presentation-design_11.png)

## **تشخیص اینکه آیا یک پرکنندهٔ جامد مؤثر از رنگ تم استفاده می‌کند**

یک پرکننده می‌تواند مستقیماً بر روی شیء ذخیره شود یا از یک پاراگراف، لِیَوت، مستر، سبک تم یا سطح قالب‌بندی دیگری ارث‌بری شود. برای حل این سلسله‌مراتب به یک [IFillFormat.getEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifillformat/) صدا بزنید تا به یک [IFillFormatEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifillformateffectivedata/) ثابت تبدیل شود. ابتدا [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifillformateffectivedata/) را بررسی کنید. فقط زمانی که مقدار `FillType.Solid` باشد باید ویژگی‌های پرکنندهٔ جامد را بخوانید.

برای یک پرکنندهٔ جامد، [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifillformateffectivedata/) مقدار نهایی RGB پس از وراثت، جستجوی تم و اعمال تبدیل‌های رنگی را برمی‌گرداند. [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifillformateffectivedata/) اسلات منطقی [SchemeColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/schemecolor/) مرتبط، مثل `Text1` یا `Accent6` را برمی‌گرداند. مقدار `SchemeColor.NotDefined` به این معنی است که پرکنندهٔ جامد مؤثر بر پایه یک رنگ طرح‌واره نیست. در کاری که پرکننده‌ها یا رنگ‌های تم یا رنگ‌های RGB مستقیم هستند، این مقدار یک پرکنندهٔ RGB مستقیم را شناسایی می‌کند.

از مقدار محلی [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icolorformat/) به تنهایی برای دسته‌بندی پرکننده استفاده نکنید. برای مثال، یک بخش متن ممکن است رنگ طرح‌وارهٔ محلی نداشته باشد، بنابراین مقدار محلی آن `NotDefined` است، در حالی که پرکنندهٔ مؤثر آن یک رنگ تم ارث‌بری می‌کند و به `Text1` یا `Accent6` تبدیل می‌شود. برعکس، `getSolidFillSchemeColor` به شما می‌گوید کدام اسلات منطقی تم رنگ نهایی را تولید کرده، اما نمی‌گوید این اسلات از شیء، پاراگراف، لِیَوت، مستر یا سطح دیگری از سلسله‌مراتب آمده است.

مثال زیر یک ارائه را بارگذاری می‌کند، پرکننده‌های شکل‌ها و پرکننده‌های بخش‌های متنی را ممیزی می‌کند، هر مقدار RGB نهایی و رنگ طرح‌واره مرتبط را چاپ می‌کند و پرکننده‌های جامدی که تغییرات رنگ تم را دنبال نمی‌کنند پرچم‌گذاری می‌کند:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    Color rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, rgb.getRed(), rgb.getGreen(), rgb.getBlue());
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

شاخهٔ `NotDefined` فهرستی از پرکننده‌های جامد ارائه می‌دهد که به تغییرات اسلات‌های رنگ تم واکنش نشان نمی‌دهند. این اشیا را زمانی که یک ارائه باید از پالت برند جدید پیروی کند بررسی کنید. مقدار RGB گزارش‌شده هنوز ظاهر کنونی را نشان می‌دهد، در حالی که مقدار طرح‌واره توضیح می‌دهد آیا این ظاهر به تم متصل است یا خیر.

اشیای فرمت مؤثر تنها تصویر ثابت هستند. پس از تغییر تم ارائه، بازنویسی تم یا هر قالب‌بندی وراثتی، دوباره `getEffective` را فراخوانی کنید و قبل از مقایسه یا گزارش رنگ‌ها یک شیء جدید `IFillFormatEffectiveData` بخوانید.

## **خواندن مقادیر مؤثر تم**

اشیای خام تم به شما می‌گویند در یک سطح خاص چه تعریف شده است. مقادیر مؤثر به شما می‌گویند یک اسلاید یا شکل پس از حل وراثت و بازنویسی‌های محلی دقیقاً چه چیزی استفاده می‌کند. برای یک اسلاید، متد [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseoverridethememanager/) را صدا بزنید. برای یک پس‌زمینه، از [Background.getEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/background/) استفاده کنید و برای یک پرکننده، از [FillFormat.getEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fillformat/) استفاده کنید.

مثال زیر تم مؤثر، پس‌زمینه و اولین پرکنندهٔ شکل را از یک اسلاید می‌خواند:

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

از داده‌های مؤثر برای عیب‌یابی رندر، اعتبارسنجی و مقایسه‌ها استفاده کنید. اگر فقط [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) را بررسی کنید، ممکن است یک بازنویسی در مستر، لِیَوت، اسلاید یا شکل را که ظاهر نهایی را تغییر می‌دهد، از دست بدهید.

## **سوالات متداول**

**آیا اعمال تم خارجی بر تمام اسلایدهای ارائه تأثیر می‌گذارد؟**

نه. متد [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslide/) فقط اسلایدهایی را که به مستر انتخاب‌شده وابسته‌اند، بازتخصیص می‌دهد. اسلایدهای استفاده‌کننده از مسترهای دیگر تم‌های موجود خود را حفظ می‌کنند.

**آیا می‌توانم تم را فقط روی یک اسلاید بدون تغییر مستر اعمال کنم؟**

بله. از [SlideThemeManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slidethememanager/) اسلاید استفاده کنید و بازنویسی تم آن را مقداردهی اولیه کنید. تغییر فقط به‌صورت محلی بر آن اسلاید باقی می‌ماند؛ اسلایدهای دیگر تم‌های موجود خود را ارث‌بری می‌کنند.

**ایمن‌ترین روش برای انتقال تم از یک ارائه به ارائه دیگر چیست؟**

هنگامی که اسلایدی را جابجا می‌کنید و ظاهر منبع را می‌خواهید حفظ کنید، مستر منبع را با استفاده از [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslidecollection/) به مقصد کلون کنید و سپس اسلاید را با همان مستر با [ISlideCollection.addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecollection/) کلون کنید. این کار مستر، لِیَوت‌ها و تم را همراه هم نگه می‌دارد.

**چگونه می‌توانم مقادیر مؤثر پس از وراثت و بازنویسی‌ها را ببینم؟**

از [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseoverridethememanager/) برای یک اسلاید یا تم لِیَوت و متدهای دادهٔ مؤثر مربوطه برای اشیای قالب مانند [Background.getEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/background/) و [FillFormat.getEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fillformat/) استفاده کنید. این APIها مقادیر حل‌شده پس از اعمال وراثت و بازنویسی‌ها را برمی‌گردانند.