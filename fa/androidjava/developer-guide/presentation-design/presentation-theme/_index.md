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
- پالت اضافی
- قلم تم
- سبک تم
- افکت تم
- پاورپوینت
- OpenDocument
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "استفاده از تم‌های اصلی ارائه در Aspose.Slides برای اندروید با جاوا برای ایجاد، سفارشی‌سازی و تبدیل فایل‌های پاورپوینت با برندینگ یکسان."
---
## **مقدمه**

یک تم ارائه ویژگی‌های عناصر طراحی را تعریف می‌کند. هنگامی که یک تم ارائه را انتخاب می‌کنید، در واقع مجموعه‌ای خاص از عناصر بصری و ویژگی‌های آن‌ها را برمی‌گزینید.

در پاورپوینت، یک تم شامل رنگ‌ها، [قلم‌ها](/slides/fa/androidjava/powerpoint-fonts/)، [سبک‌های پس‌زمینه](/slides/fa/androidjava/presentation-background/)، و افکت‌ها است.

![عناصر تم](theme-constituents.png)

## **تغییر رنگ تم**

یک تم پاورپوینت مجموعه خاصی از رنگ‌ها را برای عناصر مختلف یک اسلاید استفاده می‌کند. اگر رنگ‌ها را دوست ندارید، می‌توانید با اعمال رنگ‌های جدید برای تم، آن‌ها را تغییر دهید. برای این که بتوانید یک رنگ تم جدید انتخاب کنید، Aspose.Slides مقادیر را تحت شمارش‌گر [SchemeColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SchemeColor) ارائه می‌دهد.

این کد جاوا نشان می‌دهد چگونه رنگ تاکید تم را تغییر دهید:
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

می‌توانید مقدار مؤثر رنگ حاصل را به این روش تعیین کنید:
```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

برای نشان دادن بیشتر عملیات تغییر رنگ، یک عنصر دیگر ایجاد می‌کنیم و رنگ تاکید (از عملیات اولیه) را به آن اختصاص می‌دهیم. سپس رنگ را در تم تغییر می‌دهیم:
```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

رنگ جدید به‌صورت خودکار بر روی هر دو عنصر اعمال می‌شود.

### **تنظیم رنگ تم از پالت اضافی**

زمانی که تغییرات روشنایی را بر رنگ اصلی تم (1) اعمال می‌کنید، رنگ‌های پالت اضافی (2) شکل می‌گیرند. سپس می‌توانید این رنگ‌های تم را تنظیم و دریافت کنید.

![رنگ‌های پالت اضافی](additional-palette-colors.png)

**1** - رنگ‌های اصلی تم  
**2** - رنگ‌های پالت اضافی.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Accent 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Accent 4، روشن‌تر 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Accent 4، روشن‌تر 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Accent 4، روشن‌تر 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // Accent 4، تیره‌تر 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Accent 4، تیره‌تر 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **نقشه `SchemeColor` به رنگ‌های `IColorScheme`**

هنگامی که با [SchemeColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/schemecolor/) کار می‌کنید، ممکن است متوجه شوید که شامل مقادیر رنگ تم زیر است:
`Background1`, `Background2`, `Text1`, and `Text2`.

با این حال، `Presentation.getMasterTheme().getColorScheme()` یک [IColorScheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icolorscheme/) بر می‌گرداند که رنگ‌های对应 را به صورت زیر نشان می‌دهد:
`Dark1`, `Dark2`, `Light1`, and `Light2`.

این تفاوت فقط در نام‌گذاری است. این مقادیر به همان اسلات‌های رنگ تم اشاره دارند و نگاشت ثابت است:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هیچ تبدیل دینامیکی بین `Text`/`Background` و `Dark`/`Light` وجود ندارد. آن‌ها تنها نام‌های دیگری برای همان رنگ‌های تم هستند.

این تفاوت در نام‌گذاری از اصطلاحات Microsoft Office ناشی می‌شود. نسخه‌های قدیمی Office از `Dark 1`، `Light 1`، `Dark 2` و `Light 2` استفاده می‌کردند، در حالی که نسخه‌های جدید UI همان اسلات‌ها را به صورت `Text 1`، `Background 1`، `Text 2` و `Background 2` نشان می‌دهند.

## **تغییر قلم تم**

برای این که بتوانید قلم‌ها را برای تم‌ها و مقاصد دیگر انتخاب کنید، Aspose.Slides از این شناساگرهای خاص (مشابه آن‌چه در پاورپوینت استفاده می‌شود) بهره می‌گیرد:

* **+mn-lt** - قلم بدنه لاتین (قلم لاتین جزئی)
* **+mj-lt** - قلم عنوان لاتین (قلم لاتین اصلی)
* **+mn-ea** - قلم بدنه شرق‌آسیایی (قلم شرق‌آسیایی جزئی)
* **+mj-ea** - قلم بدنه شرق‌آسیایی (قلم شرق‌آسیایی اصلی)

این کد جاوا نشان می‌دهد چگونه قلم لاتین را به یک عنصر تم اختصاص دهید:
```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

این کد جاوا نشان می‌دهد چگونه قلم تم ارائه را تغییر دهید:
```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

قلم در تمام جعبه‌های متن به روز خواهد شد.

{{% alert color="primary" title="TIP" %}} 
ممکن است بخواهید [قلم‌های پاورپوینت](/slides/fa/androidjava/powerpoint-fonts/) را ببینید.
{{% /alert %}}

## **تغییر سبک پس‌زمینه تم**

به‌صورت پیش‌فرض، برنامه پاورپوینت ۱۲ پس‌زمینه پیش‌تعریف‌شده ارائه می‌دهد اما تنها ۳ مورد از این ۱۲ پس‌زمینه در یک ارائه معمولی ذخیره می‌شوند.

![طراحی ارائه](presentation-design_8.png)

به عنوان مثال، پس از ذخیره یک ارائه در برنامه پاورپوینت، می‌توانید این کد جاوا را اجرا کنید تا تعداد پس‌زمینه‌های پیش‌تعریف‌شده در ارائه را بیابید:
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
با استفاده از ویژگی [BackgroundFillStyles](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) از کلاس [FormatScheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FormatScheme)، می‌توانید سبک پس‌زمینه را در یک تم پاورپوینت اضافه یا دسترسی پیدا کنید.
{{% /alert %}} 

این کد جاوا نشان می‌دهد چگونه پس‌زمینه یک ارائه را تنظیم کنید:
```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**راهنمای ایندکس**: 0 برای عدم پر شدن استفاده می‌شود. ایندکس از ۱ شروع می‌شود.

{{% alert color="primary" title="TIP" %}} 
ممکن است بخواهید [پس‌زمینه پاورپوینت](/slides/fa/androidjava/presentation-background/) را ببینید.
{{% /alert %}}

## **تغییر افکت تم**

یک تم پاورپوینت معمولاً برای هر آرایه سبک ۳ مقدار دارد. این آرایه‌ها به ۳ افکت ترکیب می‌شوند: ظریف، متوسط و شدید. به عنوان مثال، این نتیجه است وقتی افکت‌ها بر یک شکل خاص اعمال می‌شوند:
![نتیجه ارائه](presentation-design_10.png)

با استفاده از ۳ ویژگی ([FillStyles](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FormatScheme#getFillStyles--)، [LineStyles](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FormatScheme#getLineStyles--)، [EffectStyles](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--)) از کلاس [FormatScheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FormatScheme)، می‌توانید عناصر در یک تم را تغییر دهید (حتی نسبت به گزینه‌های موجود در پاورپوینت انعطاف‌پذیرتر).
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

تغییرات حاصل در رنگ پر، نوع پر، افکت سایه و غیره:
![تغییرات افکت](presentation-design_11.png)

## **سؤالات متداول**

**آیا می‌توانم تم را به یک اسلاید واحد اعمال کنم بدون تغییر مستر؟**  
بله. Aspose.Slides از دل‌خواهی تم در سطح اسلاید پشتیبانی می‌کند، بنابراین می‌توانید تم محلی را فقط به آن اسلاید اعمال کنید در حالی که تم مستر را دست‌نخورده نگه می‌دارید (از طریق [SlideThemeManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slidethememanager/)).

**ایمن‌ترین روش برای انتقال تم از یک ارائه به ارائه دیگر چیست؟**  
[کلون اسلایدها](/slides/fa/androidjava/clone-slides/) همراه با مستر آن‌ها به ارائه هدف انتقال دهید. این کار مستر، طرح‌بندی‌ها و تم مرتبط را حفظ می‌کند تا ظاهر یکپارچه بماند.

**چگونه می‌توانم مقادیر «مؤثر» را پس از تمام وراثت و بازنویسی‌ها ببینم؟**  
از نمای ["effective"](/slides/fa/androidjava/shape-effective-properties/) API برای تم/رنگ/قلم/افکت استفاده کنید. این نماها پس از اعمال مستر به‌همراه هر بازنویسی محلی، ویژگی‌های نهایی و حل‌شده را بر می‌گردانند.