---
title: فرمت‌دهی اشکال PowerPoint در Java
linktitle: فرمت‌دادن شکل
type: docs
weight: 20
url: /fa/java/shape-formatting/
keywords:
- فرمت‌دادن شکل
- فرمت‌دادن خط
- اثر اسکچ
- خط اسکچ‌شده شکل
- فرمت‌دادن سبک اتصال
- پرکردن گرادیان
- پرکردن الگو
- پرکردن تصویر
- پرکردن بافت
- پرکردن رنگ ثابت
- شفافیت شکل
- چرخش شکل
- اثر برج 3بعدی
- اثر چرخش 3بعدی
- بازنشانی فرمت‌بندی
- پاورپوینت
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال PowerPoint را در Java با استفاده از Aspose.Slides فرمت دهید—پرکننده، خط و سبک اثرها را برای فایل‌های PPT، PPTX و ODP با دقت و کنترل کامل تنظیم کنید."
---
## **مقدمه**

در پاورپوینت می‌توانید اشکال را به اسلایدها اضافه کنید. از آنجا که اشکال از خطوط تشکیل شده‌اند، می‌توانید آنها را با تغییر یا اعمال اثر بر حاشیه‌هایشان فرمت‌بندی کنید. علاوه بر این، می‌توانید اشکال را با تعیین تنظیماتی که نحوه پر شدن داخل آنها را کنترل می‌کند، فرمت‌بندی نمایید.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java رابط‌ها و متدهایی فراهم می‌کند که به شما امکان می‌دهد اشکال را با همان گزینه‌های موجود در پاورپوینت فرمت‌بندی کنید.

## **فرمت خطوط**

با استفاده از Aspose.Slides می‌توانید یک سبک خط سفارشی برای یک شکل مشخص کنید. مراحل زیر روش انجام کار را شرح می‌دهند:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلایدی با ایندکس مشخص دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. [سبک خط](https://reference.aspose.com/slides/fa/java/com.aspose.slides/linestyle/) شکل را تنظیم کنید.
1. عرض خط را تنظیم کنید.
1. [سبک نوک خط](https://reference.aspose.com/slides/fa/java/com.aspose.slides/linedashstyle/) را تنظیم کنید.
1. رنگ خط را برای شکل تعیین کنید.
1. ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

کد زیر نشان می‌دهد چگونه یک `AutoShape` مستطیلی را فرمت‌بندی کنید:

```java
// یک شی از کلاس Presentation که نمایانگر فایل ارائه است را نمونه‌سازی کنید.
Presentation presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // یک شکل خودکار از نوع Rectangle اضافه کنید.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // رنگ پرشدگی شکل مستطیل را تنظیم کنید.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // فرمت‌بندی را بر خطوط مستطیل اعمال کنید.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // رنگ خط مستطیل را تنظیم کنید.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // فایل PPTX را روی دیسک ذخیره کنید.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The formatted lines in the presentation](formatted-lines.png)

## **اعمال اثرات اسکچ بر خطوط شکل**

یک اثر اسکچ باعث می‌شود خط یک شکل دست‌نویس به نظر برسد. از [IShape.getLineFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/) برای دسترسی به تنظیمات خط، [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilineformat/) برای دسترسی به تنظیمات اسکچ و [ISketchFormat.setSketchType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isketchformat/) برای انتخاب یک مقدار از نوع شناور [LineSketchType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/linesketchtype/) استفاده کنید.

کد جاوا زیر نشان می‌دهد چگونه اثر [LineSketchType.Curved](https://reference.aspose.com/slides/fa/java/com.aspose.slides/linesketchtype/) را اعمال، مقدار اختصاص داده‌شده را بخوانید و اثر را با [LineSketchType.None](https://reference.aspose.com/slides/fa/java/com.aspose.slides/linesketchtype/) حذف کنید:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // دسترسی به فرمت خط شکل و فرمت اسکچ آن.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // اعمال یک اثر اسکچ.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // خواندن اثر اسکچ اختصاص داده‌شده مستقیم به شکل.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // حذف اثر اسکچ.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

مقداری که توسط [ISketchFormat.getSketchType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isketchformat/) برگردانده می‌شود، تنظیمی است که مستقیماً به شکل اختصاص یافته است. اگر فرمت‌بندی خط می‌تواند از یک تم، اسلاید ماسِر یا اسلاید طرح‌بندی به ارث برسد، از [ILineFormat.getEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilineformat/) استفاده کنید، به [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilineformateffectivedata/) دسترسی پیدا کنید و [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isketchformateffectivedata/) را بخوانید. مقدار مؤثر فرمت‌بندی واقعی پس از حل ارث‌بری را نشان می‌دهد:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    ILineFormat lineFormat = shape.getLineFormat();

    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **فرمت سبک‌های اتصال**

سه گزینه نوع اتصال عبارتند از:

* Round
* Miter
* Bevel

به طور پیش‌فرض، زمانی که پاورپوینت دو خط را در یک زاویه (مانند گوشه یک شکل) به هم وصل می‌کند، از تنظیم **Round** استفاده می‌کند. اما اگر شما شکلی با زاویه‌های تیز ترسیم می‌کنید، ممکن است گزینه **Miter** را ترجیح دهید.

![The join style in the presentation](join-style-powerpoint.png)

کد جاوا زیر نشان می‌دهد چگونه سه مستطیل (همان‌طور که در تصویر بالا نشان داده شده) با تنظیمات نوع اتصال Miter، Bevel و Round ایجاد شدند:

```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
Presentation presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // سه شکل خودکار از نوع Rectangle را اضافه کنید.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // رنگ پرشدگی هر شکل مستطیل را تنظیم کنید.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // عرض خط را تنظیم کنید.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // رنگ خط هر مستطیل را تنظیم کنید.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // سبک اتصال را تنظیم کنید.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // متن را به هر مستطیل اضافه کنید.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // فایل PPTX را روی دیسک ذخیره کنید.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **پر کردن با گرادیان**

در پاورپوینت، پر کردن با گرادیان یک گزینه فرمت‌بندی است که به شما امکان می‌دهد ترکیبی پیوسته از رنگ‌ها را بر روی یک شکل اعمال کنید. به عنوان مثال می‌توانید دو یا چند رنگ را به‌گونه‌ای اعمال کنید که یکی به‌تدریج به دیگری محو شود.

نحوه اعمال پر کردن گرادیان به یک شکل با Aspose.Slides:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلایدی با ایندکس مشخص دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/filltype/) شکل را به `Gradient` تنظیم کنید.
1. دو رنگ دلخواه خود را با موقعیت‌های تعریف‌شده با استفاده از متدهای `add` مجموعهٔ توقف گرادیان که توسط رابط [IGradientFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/igradientformat/) افشا می‌شود، اضافه کنید.
1. ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

کد جاوا زیر نحوه اعمال اثر پر کردن گرادیان به یک بیضی را نشان می‌دهد:

```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
Presentation presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // یک شکل خودکار از نوع Ellipse اضافه کنید.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // اعمال فرمت گرادیان به بیضی.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // تعیین جهت گرادیان.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // اضافه کردن دو نقطه توقف گرادیان.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // ذخیره فایل PPTX روی دیسک.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The ellipse with gradient fill](gradient-fill.png)

## **پر کردن با الگو**

در پاورپوینت، پر کردن با الگو یک گزینه فرمت‌بندی است که به شما اجازه می‌دهد طرح دو‌رنگی—مانند نقاط، نوارها، خطوط متقاطع یا تیک‌ها—را بر روی یک شکل اعمال کنید. می‌توانید رنگ‌های پیش‌زمینه و پیش‌رو الگو را به‌صورت سفارشی انتخاب کنید.

Aspose.Slides بیش از ۴۵ سبک الگوی پیش‌تعریف‌شده ارائه می‌دهد که می‌توانید برای بهبود جذابیت بصری ارائه‌هایتان به اشکال اعمال کنید. حتی پس از انتخاب یک الگوی پیش‌تعریف‌شده، هنوز می‌توانید رنگ‌های دقیق مورد استفاده را مشخص کنید.

نحوه اعمال پر کردن الگو به یک شکل با Aspose.Slides:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلایدی با ایندکس مشخص دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/filltype/) شکل را به `Pattern` تنظیم کنید.
1. یک سبک الگو از گزینه‌های پیش‌تعریف‌شده انتخاب کنید.
1. [Background Color](https://reference.aspose.com/slides/fa/java/com.aspose.slides/patternformat/#getBackColor--) الگو را تنظیم کنید.
1. [Foreground Color](https://reference.aspose.com/slides/fa/java/com.aspose.slides/patternformat/#getForeColor--) الگو را تنظیم کنید.
1. ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

کد جاوا زیر نحوه اعمال پر کردن الگو به یک مستطیل را نشان می‌دهد:

```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
Presentation presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // یک شکل خودکار از نوع Rectangle اضافه کنید.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // نوع پرشدگی را به Pattern تنظیم کنید.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // سبک الگو را تنظیم کنید.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // رنگ پس‌زمینه و پیش‌زمینه الگو را تنظیم کنید.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // فایل PPTX را روی دیسک ذخیره کنید.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The rectangle with pattern fill](pattern-fill.png)

## **پر کردن با تصویر**

در پاورپوینت، پر کردن با تصویر یک گزینه فرمت‌بندی است که به شما اجازه می‌دهد یک تصویر را داخل یک شکل درج کنید—به‌طوری که تصویر به‌عنوان پس‌زمینهٔ شکل عمل کند.

نحوه استفاده از Aspose.Slides برای اعمال پر کردن تصویر به یک شکل:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلایدی با ایندکس مشخص دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/filltype/) شکل را به `Picture` تنظیم کنید.
1. حالت پر کردن تصویر را به `Tile` (یا حالت دلخواه دیگر) تنظیم کنید.
1. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ippimage/) از تصویر مورد نظر ایجاد کنید.
1. تصویر را به متد `ISlidesPicture.setImage` پاس دهید.
1. ارائه اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

فرض کنید فایلی به نام "lotus.png" با تصویر زیر داشته باشیم:

![The lotus picture](lotus.png)

کد جاوا زیر نشان می‌دهد چگونه یک شکل را با تصویر پر کنید:

```java
// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // یک شکل خودکار از نوع Rectangle اضافه کنید.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // نوع پرشدگی را به Picture تنظیم کنید.
    shape.getFillFormat().setFillType(FillType.Picture);

    // حالت پر کردن تصویر را تنظیم کنید.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // یک تصویر بارگذاری کنید و به منابع ارائه اضافه کنید.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // تصویر را تنظیم کنید.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // فایل PPTX را روی دیسک ذخیره کنید.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The shape with picture fill](picture-fill.png)

### **تصویر کاشی به‌عنوان بافت**

اگر می‌خواهید یک تصویر کاشی‌شده را به‌عنوان بافت تنظیم کنید و رفتار کاشی را سفارشی کنید، می‌توانید از متدهای زیر رابط [IPictureFillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/picturefillformat/) استفاده کنید:

- [setPictureFillMode](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): حالت پر کردن تصویر را تنظیم می‌کند—`Tile` یا `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): ترازبندی کاشی‌ها را درون شکل مشخص می‌کند.
- [setTileFlip](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): تعیین می‌کند آیا کاشی به‌صورت افقی، عمودی یا هر دو وارون شود.
- [setTileOffsetX](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): افست افقی کاشی (به‌پونت) را از مبدأ شکل تنظیم می‌کند.
- [setTileOffsetY](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): افست عمودی کاشی (به‌پونت) را از مبدأ شکل تنظیم می‌کند.
- [setTileScaleX](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): مقیاس افقی کاشی را به‌صورت درصد تعریف می‌کند.
- [setTileScaleY](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): مقیاس عمودی کاشی را به‌صورت درصد تعریف می‌کند.

کد نمونه زیر نشان می‌دهد چگونه یک شکل مستطیلی با پر کردن تصویر کاشی‌شده اضافه کرده و گزینه‌های کاشی را پیکربندی کنید:

```java
// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // یک شکل خودکار مستطیلی اضافه کنید.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // نوع پرشدگی شکل را به Picture تنظیم کنید.
    shape.getFillFormat().setFillType(FillType.Picture);

    // تصویر را بارگذاری کنید و به منابع ارائه اضافه کنید.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // تصویر را به شکل اختصاص دهید.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // حالت پر کردن تصویر و ویژگی‌های کاشی را پیکربندی کنید.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // فایل PPTX را روی دیسک ذخیره کنید.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The tile options](tile-options.png)

## **پر کردن با رنگ ثابت**

در پاورپوینت، پر کردن با رنگ ثابت یک گزینه فرمت‌بندی است که یک شکل را با یک رنگ یکنواخت پر می‌کند. این پس‌زمینه ساده بدون هیچ‌گونه گرادیان، بافت یا الگو اعمال می‌شود.

برای اعمال پر کردن با رنگ ثابت به یک شکل با Aspose.Slides، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلایدی با ایندکس مشخص دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/filltype/) شکل را به `Solid` تنظیم کنید.
1. رنگ پرکنندهٔ دلخواه خود را به شکل اختصاص دهید.
1. ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

کد جاوا زیر نحوه اعمال پر کردن با رنگ ثابت به یک مستطیل در اسلاید پاورپوینت را نشان می‌دهد:

```java
// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // یک شکل خودکار از نوع Rectangle اضافه کنید.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // نوع پرشدگی را به Solid تنظیم کنید.
    shape.getFillFormat().setFillType(FillType.Solid);

    // رنگ پرشدگی را تنظیم کنید.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // فایل PPTX را روی دیسک ذخیره کنید.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The shape with solid color fill](solid-color-fill.png)

## **تنظیم شفافیت**

در پاورپوینت، هنگامی که یک پر کردن رنگ ثابت، گرادیان، تصویر یا بافت را بر روی اشکال اعمال می‌کنید، می‌توانید سطح شفافیتی را تنظیم کنید تا میزان تیرگی پر کردن را کنترل کنید. مقدار شفافیت بالاتر باعث می‌شود شکل بیشتر شفاف شود و پس‌زمینه یا اشیای زیرین به‌صورت جزئی دیده شوند.

Aspose.Slides به شما امکان می‌دهد سطح شفافیت را با تنظیم مقدار آلفا در رنگ مورد استفاده برای پر کردن تنظیم کنید. نحوه انجام این کار به شرح زیر است:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلایدی با ایندکس مشخص دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/filltype/) را به `Solid` تنظیم کنید.
1. از `Color` برای تعریف رنگی با شفافیت (مولفهٔ `alpha` شفافیت را کنترل می‌کند) استفاده کنید.
1. ارائه را ذخیره کنید.

کد جاوا زیر نحوه اعمال رنگ پر کردن شفاف به یک مستطیل را نشان می‌دهد:

```java
// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است را نمونه‌سازی کنید.
Presentation presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // یک شکل خودکار مستطیل ثابت اضافه کنید.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // یک شکل خودکار مستطیل شفاف بر بالای شکل ثابت اضافه کنید.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // فایل PPTX را روی دیسک ذخیره کنید.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The transparent shape](shape-transparency.png)

## **چرخاندن اشکال**

Aspose.Slides به شما امکان می‌دهد اشکال را در ارائه‌های پاورپوینت چرخانید. این می‌تواند هنگام موقعیت‌دهی عناصر بصری با نیازهای خاص ترازبندی یا طراحی مفید باشد.

برای چرخاندن یک شکل در اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلایدی با ایندکس مشخص دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی چرخش شکل را به زاویهٔ دلخواه تنظیم کنید.
1. ارائه را ذخیره کنید.

کد جاوا زیر چگونگی چرخاندن یک شکل به‌مقدار 5 درجه را نشان می‌دهد:

```java
    // یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است را نمونه‌سازی کنید.
    Presentation presentation = new Presentation();
    try {
        // اسلاید اول را دریافت کنید.
        ISlide slide = presentation.getSlides().get_Item(0);

        // یک شکل خودکار از نوع Rectangle اضافه کنید.
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

        // شکل را به میزان 5 درجه بچرخانید.
        shape.setRotation(5);

        // فایل PPTX را روی دیسک ذخیره کنید.
        presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
```

نتیجه:

![The shape rotation](shape-rotation.png)

## **اضافه کردن اثرات برج 3بعدی**

Aspose.Slides به شما اجازه می‌دهد اثرات 3بعدی برج را با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/threedformat/) به شکل‌ها اعمال کنید.

برای افزودن اثرات 3بعدی برج به یک شکل، مراحل زیر را دنبال کنید:

1. نمونهٔ کلاس [ارائه](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) را ایجاد کنید.
1. یک ارجاع به اسلایدی با ایندکس مشخص دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی [ThreeDFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/threedformat/) شکل را برای تعریف تنظیمات برج پیکربندی کنید.
1. ارائه را ذخیره کنید.

کد جاوا زیر نشان می‌دهد چگونه اثرات 3بعدی برج را به یک شکل اعمال کنید:

```java
// یک نمونه از کلاس Presentation ایجاد کنید.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // یک شکل به اسلاید اضافه کنید.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // ویژگی‌های ThreeDFormat شکل را تنظیم کنید.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // ارائه را به عنوان فایل PPTX ذخیره کنید.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The 3D bevel effect](3D-bevel-effect.png)

## **اضافه کردن اثرات چرخش 3بعدی**

Aspose.Slides به شما امکان می‌دهد اثرات چرخش 3بعدی را با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/threedformat/) به اشکال اعمال کنید.

برای اعمال چرخش 3بعدی به یک شکل:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلایدی با ایندکس مشخص دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. از [setCameraType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icamera/#setCameraType-int-) و [setLightType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilightrig/#setLightType-int-) برای تعریف چرخش 3بعدی استفاده کنید.
1. ارائه را ذخیره کنید.

کد جاوا زیر نشان می‌دهد چگونه اثرات چرخش 3بعدی را به یک شکل اعمال کنید:

```java
// یک نمونه از کلاس Presentation ایجاد کنید.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // ارائه را به صورت فایل PPTX ذخیره کنید.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The 3D rotation effect](3D-rotation-effect.png)

## **بازنشانی فرمت‌بندی**

کد جاوا زیر نشان می‌دهد چگونه فرمت‌بندی یک اسلاید را بازنشانی کنید و موقعیت، اندازه و فرمت‌بندی تمام اشکال با نگهدارنده‌ها را در [LayoutSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/layoutslide/) به تنظیمات پیش‌فرض بازگردانید:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // بازنشانی هر شکلی در اسلاید که در طرح‌بندی یک نگهدارنده دارد.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سؤالات متداول**

**آیا فرمت‌بندی شکل بر حجم نهایی فایل ارائه تأثیر می‌گذارد؟**

به‌صورت کمینه. تصاویر و رسانه‌های جاسازی‌شده بیشتر فضا را اشغال می‌کنند، در حالی که پارامترهای شکل مانند رنگ‌ها، اثرات و گرادیان‌ها به‌عنوان متادیتا ذخیره می‌شوند و تقریباً هیچ حجم اضافی اضافه نمی‌کنند.

**چگونه می‌توانم اشکالی را در اسلاید که فرمت‌بندی مشابه دارند شناسایی کنم تا بتوانم آنها را گروه‌بندی کنم؟**

ویژگی‌های کلیدی فرمت‌بندی هر شکل—پر کردن، خط و تنظیمات اثر—را مقایسه کنید. اگر تمام مقادیر متناظر برابر باشند، سبک آنها را یکسان در نظر بگیرید و این اشکال را به‌صورت منطقی گروه‌بندی کنید که مدیریت سبک بعدی را ساده‌تر می‌سازد.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در یک فایل جداگانه ذخیره کنم تا در ارائه‌های دیگر استفاده شوند؟**

بله. اشکال نمونه با سبک‌های دلخواه را در یک مجموعهٔ اسلاید قالب یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد ارائه جدید، قالب را باز کنید، اشکال استایل‌دار مورد نیاز را کلون کنید و فرمت‌بندی آنها را در هر نقطه‌ای که لازم است دوباره اعمال کنید.