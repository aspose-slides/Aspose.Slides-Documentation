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
- فونت تم
- سبک تم
- اثر تم
- پاورپوینت
- OpenDocument
- ارائه
- جاوا
- Aspose.Slides
description: "تم‌های ارائه اصلی در Aspose.Slides برای جاوا برای ایجاد، سفارشی‌سازی و تبدیل فایل‌های پاورپوینت با برندینگ یکسان."
---
## **مقدمه**

یک تم ارائه خصوصیات عناصر طراحی را تعریف می‌کند. هنگامی که یک تم ارائه را انتخاب می‌کنید، در واقع یک مجموعه خاص از عناصر بصری و ویژگی‌های آن‌ها را برمی‌گزینید.

در پاورپوینت، یک تم شامل رنگ‌ها، [فونت‌ها](/slides/fa/java/powerpoint-fonts/)، [سبک‌های پس‌زمینه](/slides/fa/java/presentation-background/)، و افکت‌ها است.

![theme-constituents](theme-constituents.png)

## **تغییر رنگ تم**

یک تم پاورپوینت برای عناصر مختلف یک اسلاید یک مجموعه خاص از رنگ‌ها را استفاده می‌کند. اگر رنگ‌ها را دوست ندارید، می‌توانید با اعمال رنگ‌های جدید برای تم، رنگ‌ها را تغییر دهید. برای این که بتوانید یک رنگ تم جدید انتخاب کنید، Aspose.Slides مقادیر زیر مجموعه SchemeColor را فراهم می‌کند.

این کد Java نشان می‌دهد چگونه رنگ برجسته یک تم را تغییر دهید:

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

به این روش می‌توانید مقدار مؤثر رنگ حاصل را تعیین کنید:

```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

برای نشان دادن بیشتر عملیات تغییر رنگ، یک عنصر دیگر ایجاد می‌کنیم و رنگ برجسته (از عملیات اولیه) را به آن اختصاص می‌دهیم. سپس رنگ را در تم تغییر می‌دهیم:

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

رنگ جدید به‌صورت خودکار بر روی هر دو عنصر اعمال می‌شود.

### **تنظیم رنگ تم از پالت اضافه**

هنگامی که تبدیلات روشنایی را بر رنگ اصلی تم (1) اعمال می‌کنید، رنگ‌هایی از پالت اضافه (2) شکل می‌گیرند. سپس می‌توانید این رنگ‌های تم را تنظیم و دریافت کنید.

![additional-palette-colors](additional-palette-colors.png)

**1** - رنگ‌های اصلی تم  
**2** - رنگ‌های پالت اضافه.

این کد Java نشان می‌دهد چگونه رنگ‌های پالت اضافه از رنگ اصلی تم استخراج شده و سپس در شکل‌ها استفاده می‌شوند:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // برجسته 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // برجسته 4، روشن‌تر 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // برجسته 4، روشن‌تر 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // برجسته 4، روشن‌تر 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // برجسته 4، تاریک‌تر 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // برجسته 4، تاریک‌تر 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **نقشه‌برداری `SchemeColor` به رنگ‌های `IColorScheme`**

هنگامی که با [SchemeColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/schemecolor/) کار می‌کنید، ممکن است متوجه شوید که شامل مقادیر رنگ تم زیر است: `Background1`, `Background2`, `Text1`, و `Text2`.

اما `Presentation.getMasterTheme().getColorScheme()` یک [IColorScheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icolorscheme/) را برمی‌گرداند که رنگ‌های متناظر را به‌صورت زیر ارائه می‌دهد: `Dark1`, `Dark2`, `Light1`, و `Light2`.

این تفاوت فقط در نام‌گذاری است. این مقادیر به همان شکاف‌های رنگ تم اشاره دارند و نگاشت ثابت است:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هیچ تبدیل پویا بین `Text`/`Background` و `Dark`/`Light` وجود ندارد. آن‌ها صرفاً نام‌های جایگزین برای همان رنگ‌های تم هستند.

این اختلاف در نام‌گذاری ناشی از اصطلاحات Microsoft Office است. نسخه‌های قدیمی Office از `Dark 1`, `Light 1`, `Dark 2`, و `Light 2` استفاده می‌کردند، در حالی که نسخه‌های جدید UI همان شکاف‌ها را به عنوان `Text 1`, `Background 1`, `Text 2`, و `Background 2` نمایش می‌دهند.

## **تغییر فونت تم**

برای این که بتوانید فونت‌ها را برای تم‌ها و مقاصد دیگر انتخاب کنید، Aspose.Slides از این شناسه‌های خاص (مشابه آنچه در پاورپوینت استفاده می‌شود) بهره می‌گیرد:

* **+mn-lt** - فونت بدنه لاتین (Minor Latin Font)
* **+mj-lt** - فونت سرعنوان لاتین (Major Latin Font)
* **+mn-ea** - فونت بدنه شرق آسیا (Minor East Asian Font)
* **+mj-ea** - فونت سرعنوان شرق آسیا (Major East Asian Font)

این کد Java نشان می‌دهد چگونه فونت لاتین را به یک عنصر تم اختصاص دهید:

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

این کد Java نشان می‌دهد چگونه فونت تم ارائه را تغییر دهید:

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

فونت در تمام جعبه‌های متن به‌روز خواهد شد.

{{% alert color="primary" title="نکته" %}} 
ممکن است بخواهید [فونت‌های پاورپوینت](/slides/fa/java/powerpoint-fonts/) را ببینید.
{{% /alert %}}

## **تغییر سبک پس‌زمینه تم**

به طور پیش‌فرض، برنامه پاورپوینت 12 پس‌زمینه پیش‌تعریف‌شده ارائه می‌دهد اما فقط 3 مورد از این 12 پس‌زمینه در یک ارائه معمولی ذخیره می‌شوند.

![todo:image_alt_text](presentation-design_8.png)

به عنوان مثال، پس از ذخیره یک ارائه در برنامه پاورپوینت، می‌توانید این کد Java را اجرا کنید تا تعداد پس‌زمینه‌های پیش‌تعریف‌شده در ارائه را بیابید:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
با استفاده از ویژگی [BackgroundFillStyles](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) از کلاس [FormatScheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FormatScheme) می‌توانید سبک پس‌زمینه را در یک تم پاورپوینت اضافه یا دسترسی پیدا کنید.
{{% /alert %}} 

این کد Java نشان می‌دهد چگونه پس‌زمینه‌ای برای یک ارائه تنظیم کنید:

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**راهنمای ایندکس**: 0 برای بدون پرکنش استفاده می‌شود. ایندکس از 1 شروع می‌شود.

{{% alert color="primary" title="نکته" %}} 
ممکن است بخواهید [پس‌زمینه پاورپوینت](/slides/fa/java/presentation-background/) را ببینید.
{{% /alert %}}

## **تغییر اثر تم**

یک تم پاورپوینت معمولاً 3 مقدار برای هر آرایه سبک دارد. این آرایه‌ها به 3 اثر زیر ترکیب می‌شوند: ملایم، متوسط، و شدید. به عنوان مثال، این نتیجه است وقتی اثرها بر یک شکل خاص اعمال می‌شوند:

![todo:image_alt_text](presentation-design_10.png)

با استفاده از 3 ویژگی ([FillStyles](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FormatScheme#getEffectStyles--)) از کلاس [FormatScheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FormatScheme) می‌توانید عناصر یک تم را (حتی انعطاف‌پذیرتر از گزینه‌های موجود در پاورپوینت) تغییر دهید.

```java
Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(FillType.Solid);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.GREEN);

    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10f);

    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

تغییرات حاصل در رنگ پر، نوع پر، اثر سایه و غیره:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**آیا می‌توانم یک تم را فقط بر روی یک اسلاید اعمال کنم بدون اینکه مستر را تغییر دهم؟**

بله. Aspose.Slides از اضافه‌کردن تم در سطح اسلاید پشتیبانی می‌کند، بنابراین می‌توانید یک تم محلی را فقط برای آن اسلاید اعمال کنید در حالی که تم مستر دست نخورده می‌ماند (از طریق [SlideThemeManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slidethememanager/)).

**ایمن‌ترین روش برای انتقال یک تم از یک ارائه به ارائه دیگر چیست؟**

[کپی اسلایدها](/slides/fa/java/clone-slides/) همراه با مسترشان را به ارائه هدف منتقل کنید. این کار مستر، طرح‌بندی‌ها و تم مرتبط را حفظ می‌کند تا ظاهر یکسان بماند.

**چگونه می‌توانم مقادیر "موثر" را پس از تمام ارث‌بری و بازنویسی‌ها مشاهده کنم؟**

از نمای ["موثر"](/slides/fa/java/shape-effective-properties/) برای تم/رنگ/فونت/اثر استفاده کنید. این نماها ویژگی‌های نهایی حل‌شده پس از اعمال مستر و هر گونه بازنویسی محلی را برمی‌گردانند.