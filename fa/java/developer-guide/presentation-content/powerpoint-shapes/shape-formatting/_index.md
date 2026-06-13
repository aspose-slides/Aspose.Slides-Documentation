---
title: قالب‌بندی اشکال PowerPoint در جاوا
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/java/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- قالب‌بندی سبک اتصال
- پر کردن گرادیان
- پر کردن با الگو
- پر کردن با تصویر
- پر کردن با بافت
- پر کردن با رنگ ثابت
- شفافیت شکل
- چرخاندن شکل
- اثر Bevel سه‌بعدی
- اثر چرخش سه‌بعدی
- بازنشانی قالب‌بندی
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه با استفاده از Aspose.Slides اشکال PowerPoint را در جاوا قالب‌بندی کنید—قالب‌های پر کردن، خط و اثر را برای پرونده‌های PPT، PPTX و ODP با دقت و کنترل کامل تنظیم کنید."
---
## **مقدمه**

در PowerPoint می‌توانید شکل‌ها را به اسلایدها اضافه کنید. از آنجا که شکل‌ها از خطوط تشکیل شده‌اند، می‌توانید با تغییر یا اعمال افکت به خطوط حاشیه‌ای‌شان آن‌ها را قالب‌بندی کنید. علاوه بر این، می‌توانید با تعیین تنظیماتی که پر کردن داخلی را کنترل می‌کند، شکل‌ها را قالب‌بندی کنید.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java رابط‌ها و متدهایی را فراهم می‌کند که به شما امکان می‌دهد شکل‌ها را با همان گزینه‌های موجود در PowerPoint قالب‌بندی کنید.

## **قالب‌بندی خطوط**

با استفاده از Aspose.Slides می‌توانید سبک خط سفارشی را برای یک شکل مشخص کنید. مراحل زیر روش انجام این کار را توضیح می‌دهند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از ایندکس، به یک اسلاید ارجاع دهید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) را به اسلاید اضافه کنید.
1. [خط style](https://reference.aspose.com/slides/fa/java/com.aspose.slides/linestyle/) شکل را تنظیم کنید.
1. ضخامت خط را تنظیم کنید.
1. [dash style](https://reference.aspose.com/slides/fa/java/com.aspose.slides/linedashstyle/) خط را تنظیم کنید.
1. رنگ خط برای شکل را تنظیم کنید.
1. ارائهٔ اصلاح‌شده را به عنوان یک فایل PPTX ذخیره کنید.

کد زیر نشان می‌دهد چگونه یک `AutoShape` مستطیل را قالب‌بندی کنید:

```java
// یک شی از کلاس Presentation که نشانگر یک فایل ارائه است.
Presentation presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // افزودن یک شکل خودکار از نوع Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // تنظیم رنگ پر برای شکل مستطیل.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // اعمال قالب‌بندی بر خطوط مستطیل.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // تنظیم رنگ برای خط مستطیل.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // ذخیره‌سازی فایل PPTX بر روی دیسک.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The formatted lines in the presentation](formatted-lines.png)

## **قالب‌بندی سبک‌های Join**

سه گزینهٔ نوع Join عبارتند از:

* Round
* Miter
* Bevel

به‌طور پیش‌فرض، وقتی PowerPoint دو خط را در یک زاویه (مانند گوشهٔ یک شکل) به هم می‌پیوندد، از تنظیم **Round** استفاده می‌کند. اما اگر شکل با زوایای تیز رسم می‌کنید، ممکن است گزینهٔ **Miter** را ترجیح دهید.

![The join style in the presentation](join-style-powerpoint.png)

کد زیر در Java نشان می‌دهد چگونه سه مستطیل (همان‌طور که در تصویر بالا نشان داده شده) با تنظیمات Join نوع Miter، Bevel و Round ساخته شدند:

```java
// یک شی از کلاس Presentation که نشانگر یک فایل ارائه است.
Presentation presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // افزودن سه شکل خودکار از نوع Rectangle.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // تنظیم رنگ پر برای هر شکل مستطیل.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // تنظیم ضخامت خط.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // تنظیم رنگ برای خط هر مستطیل.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // تنظیم سبک اتصال.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // افزودن متن به هر مستطیل.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // ذخیره‌سازی فایل PPTX بر روی دیسک.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **پر کردن گرادیان**

در PowerPoint، Gradient Fill یک گزینهٔ قالب‌بندی است که به شما امکان می‌دهد ترکیب پیوسته‌ای از رنگ‌ها را بر یک شکل اعمال کنید. به‌عنوان مثال می‌توانید دو یا چند رنگ را طوری اعمال کنید که یکی به‌تدریج به دیگری محو شود.

در ادامه نحوهٔ اعمال Gradient Fill به یک شکل با استفاده از Aspose.Slides آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از ایندکس، به یک اسلاید ارجاع دهید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) را به اسلاید اضافه کنید.
1. [FillType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/filltype/) شکل را به `Gradient` تنظیم کنید.
1. دو رنگ مورد نظرتان را با موقعیت‌های تعریف‌شده با استفاده از متدهای `add` مجموعهٔ توقف گرادیان که توسط رابط [IGradientFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/igradientformat/) ارائه می‌شود، اضافه کنید.
1. ارائهٔ اصلاح‌شده را به عنوان یک فایل PPTX ذخیره کنید.

کد زیر در Java نشان می‌دهد چگونه یک افکت Gradient Fill را بر یک بیضی اعمال کنید:

```java
// یک شی از کلاس Presentation که نشانگر یک فایل ارائه است.
Presentation presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // افزودن یک شکل خودکار از نوع Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // اعمال قالب‌بندی گرادیان به بیضی.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // تنظیم جهت گرادیان.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // افزودن دو توقف گرادیان.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // ذخیره‌سازی فایل PPTX بر روی دیسک.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The ellipse with gradient fill](gradient-fill.png)

## **پر کردن با الگوی Pattern**

در PowerPoint، Pattern Fill یک گزینهٔ قالب‌بندی است که به شما امکان می‌دهد یک طرح دو رنگی—مانند نقطه‌ها، خط‌ها، خطوط متقاطع یا شطرنجی—را بر یک شکل اعمال کنید. می‌توانید رنگ‌های سفارشی برای پیش‌زمینه و پس‌زمینهٔ الگو انتخاب کنید.

Aspose.Slides بیش از 45 سبک الگوی پیش‌تعریف‌شده را فراهم می‌کند که می‌توانید بر شکل‌ها اعمال کنید تا جذابیت بصری ارائه‌های خود را افزایش دهید. حتی پس از انتخاب یک الگوی پیش‌تعریف‌شده، می‌توانید رنگ‌های دقیق مورد استفاده را نیز مشخص کنید.

در ادامه نحوهٔ اعمال Pattern Fill به یک شکل با استفاده از Aspose.Slides آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از ایندکس، به یک اسلاید ارجاع دهید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) را به اسلاید اضافه کنید.
1. [FillType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/filltype/) شکل را به `Pattern` تنظیم کنید.
1. یک سبک الگو را از گزینه‌های پیش‌تعریف‌شده انتخاب کنید.
1. [Background Color](https://reference.aspose.com/slides/fa/java/com.aspose.slides/patternformat/#getBackColor--) الگو را تنظیم کنید.
1. [Foreground Color](https://reference.aspose.com/slides/fa/java/com.aspose.slides/patternformat/#getForeColor--) الگو را تنظیم کنید.
1. ارائهٔ اصلاح‌شده را به عنوان یک فایل PPTX ذخیره کنید.

کد زیر در Java نشان می‌دهد چگونه Pattern Fill را بر یک مستطیل اعمال کنید:

```java
// یک شی از کلاس Presentation که نشانگر یک فایل ارائه است.
Presentation presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // افزودن یک شکل خودکار از نوع Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // تنظیم نوع پر کردن به Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // تنظیم سبک الگو.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // تنظیم رنگ‌های پس‌زمینه و پیش‌زمینه الگو.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // ذخیره‌سازی فایل PPTX بر روی دیسک.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The rectangle with pattern fill](pattern-fill.png)

## **پر کردن با تصویر Picture Fill**

در PowerPoint، Picture Fill یک گزینهٔ قالب‌بندی است که به شما امکان می‌دهد یک تصویر را داخل یک شکل درج کنید—به‌طور مؤثر تصویر را به‌عنوان پس‌زمینهٔ شکل استفاده کنید.

در ادامه نحوهٔ استفاده از Aspose.Slides برای اعمال Picture Fill به یک شکل آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از ایندکس، به یک اسلاید ارجاع دهید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) را به اسلاید اضافه کنید.
1. [FillType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/filltype/) شکل را به `Picture` تنظیم کنید.
1. حالت پر کردن تصویر را به `Tile` (یا حالت مورد نظر دیگر) تنظیم کنید.
1. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ippimage/) از تصویری که می‌خواهید استفاده کنید، ایجاد کنید.
1. تصویر را به متد `ISlidesPicture.setImage` پاس دهید.
1. ارائهٔ اصلاح‌شده را به عنوان یک فایل PPTX ذخیره کنید.

فرض کنید فایل «lotus.png» با تصویر زیر داریم:

![The lotus picture](lotus.png)

کد زیر در Java نشان می‌دهد چگونه یک شکل را با تصویر پر کنید:

```java
// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است.
Presentation presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // افزودن یک شکل خودکار از نوع Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // تنظیم نوع پر کردن به Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // تنظیم حالت پر کردن تصویر.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // بارگذاری یک تصویر و افزودن آن به منابع ارائه.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // تنظیم تصویر.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // ذخیره فایل PPTX بر روی دیسک.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The shape with picture fill](picture-fill.png)

### **Tile Picture As Texture**

اگر می‌خواهید یک تصویر کاشی‌شده را به‌عنوان بافت تنظیم کنید و رفتار کاشی شدن را سفارشی کنید، می‌توانید از متدهای زیر رابط [IPictureFillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/picturefillformat/) استفاده کنید:

- [setPictureFillMode](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): حالت پر کردن تصویر را تنظیم می‌کند—یا `Tile` یا `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): تراز کاشی‌ها درون شکل را مشخص می‌کند.
- [setTileFlip](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): تعیین می‌کند که کاشی به‌صورت افقی، عمودی یا هر دو وارونه شود.
- [setTileOffsetX](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): افست افقی کاشی (به نقاط) از مبدأ شکل را تنظیم می‌کند.
- [setTileOffsetY](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): افست عمودی کاشی (به نقاط) از مبدأ شکل را تنظیم می‌کند.
- [setTileScaleX](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): مقیاس افقی کاشی را به‌صورت درصد تعریف می‌کند.
- [setTileScaleY](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): مقیاس عمودی کاشی را به‌صورت درصد تعریف می‌کند.

کد زیر نشان می‌دهد چگونه یک شکل مستطیل با پر کردن تصویر کاشی‌شده اضافه کنید و گزینه‌های کاشی را پیکربندی کنید:

```java
// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است.
Presentation presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // افزودن یک شکل خودکار مستطیلی.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // تنظیم نوع پر کردن شکل به Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // بارگذاری تصویر و افزودن آن به منابع ارائه.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // اختصاص تصویر به شکل.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // پیکربندی حالت پر کردن تصویر و ویژگی‌های کاشی.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // ذخیرهٔ فایل PPTX بر روی دیسک.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The tile options](tile-options.png)

## **پر کردن با رنگ ثابت Solid Color Fill**

در PowerPoint، Solid Color Fill یک گزینهٔ قالب‌بندی است که شکل را با یک رنگ یکنواخت پر می‌کند. این پس‌زمینهٔ ساده بدون هیچ‌گونه گرادیان، بافت یا الگوی دیگری اعمال می‌شود.

برای اعمال Solid Color Fill به یک شکل با استفاده از Aspose.Slides، این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از ایندکس، به یک اسلاید ارجاع دهید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) را به اسلاید اضافه کنید.
1. [FillType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/filltype/) شکل را به `Solid` تنظیم کنید.
1. رنگ پر کردن مورد نظر خود را به شکل اختصاص دهید.
1. ارائهٔ اصلاح‌شده را به عنوان یک فایل PPTX ذخیره کنید.

کد زیر در Java نشان می‌دهد چگونه Solid Color Fill را بر یک مستطیل در اسلاید PowerPoint اعمال کنید:

```java
// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است.
Presentation presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // افزودن یک شکل خودکار از نوع Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // تنظیم نوع پر کردن به Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // تنظیم رنگ پر کردن.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // ذخیرهٔ فایل PPTX بر روی دیسک.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The shape with solid color fill](solid-color-fill.png)

## **تنظیم شفافیت Transparency**

در PowerPoint، هنگامی که پر کردن رنگ ثابت، گرادیان، تصویر یا بافت را بر شکل‌ها اعمال می‌کنید، می‌توانید سطح شفافیت را نیز تنظیم کنید تا میزان تراكم پر کردن کنترل شود. مقدار بالاتر شفافیت باعث می‌شود شکل بیشتر شفاف باشد و پس‌زمینه یا اجسام زیرین به‌صورت جزئی دیده شوند.

Aspose.Slides به شما امکان می‌دهد سطح شفافیت را با تنظیم مقدار آلفا در رنگ استفاده‌شده برای پر کردن تنظیم کنید. در ادامه چگونگی انجام این کار آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از ایندکس، به یک اسلاید ارجاع دهید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) را به اسلاید اضافه کنید.
1. [FillType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/filltype/) را به `Solid` تنظیم کنید.
1. با استفاده از `Color` رنگی با شفافیت تعریف کنید (مقدار `alpha` شفافیت را کنترل می‌کند).
1. ارائه را ذخیره کنید.

کد زیر در Java نشان می‌دهد چگونه یک رنگ پر کردن شفاف را بر یک مستطیل اعمال کنید:

```java
// یک شی از کلاس Presentation که نشانگر یک فایل ارائه است.
Presentation presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // افزودن یک شکل خودکار مستطیل ثابت.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // افزودن یک شکل خودکار مستطیل شفاف بر روی شکل ثابت.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // ذخیرهٔ فایل PPTX بر روی دیسک.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The transparent shape](shape-transparency.png)

## **چرخاندن اشکال Rotate Shapes**

Aspose.Slides به شما امکان می‌دهد اشکال را در ارائه‌های PowerPoint بچرخانید. این می‌تواند هنگام موقعیت‌یابی عناصر بصری با نیازهای خاص تراز یا طراحی مفید باشد.

برای چرخاندن یک شکل در یک اسلاید، این مراحل را پیش بگیرید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از ایندکس، به یک اسلاید ارجاع دهید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) را به اسلاید اضافه کنید.
1. ویژگی چرخش شکل را به زاویهٔ موردنظر تنظیم کنید.
1. ارائه را ذخیره کنید.

کد زیر در Java نشان می‌دهد چگونه یک شکل را به‌صورت 5 درجه بچرخانید:

```java
// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است.
Presentation presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // افزودن یک شکل خودکار از نوع Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // چرخاندن شکل به میزان 5 درجه.
    shape.setRotation(5);

    // ذخیره‌سازی فایل PPTX بر روی دیسک.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The shape rotation](shape-rotation.png)

## **افزودن اثرات Bevel سه‌بعدی Add 3D Bevel Effects**

Aspose.Slides به شما اجازه می‌دهد اثرات bevel سه‌بعدی را بر اشکال با تنظیم خصوصیات [ThreeDFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/threedformat/) اعمال کنید.

برای افزودن اثرات bevel سه‌بعدی به یک شکل، این مراحل را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از ایندکس، به یک اسلاید ارجاع دهید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) را به اسلاید اضافه کنید.
1. [ThreeDFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/threedformat/) شکل را پیکربندی کنید تا تنظیمات bevel را تعریف کنید.
1. ارائه را ذخیره کنید.

کد زیر در Java نشان می‌دهد چگونه اثرات bevel سه‌بعدی را بر یک شکل اعمال کنید:

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

## **افزودن اثرات چرخش سه‌بعدی Add 3D Rotation Effects**

Aspose.Slides به شما امکان می‌دهد اثرات چرخش سه‌بعدی را بر اشکال با تنظیم خصوصیات [ThreeDFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/threedformat/) اعمال کنید.

برای اعمال چرخش سه‌بعدی به یک شکل:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از ایندکس، به یک اسلاید ارجاع دهید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) را به اسلاید اضافه کنید.
1. از متدهای [setCameraType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icamera/#setCameraType-int-) و [setLightType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilightrig/#setLightType-int-) برای تعریف چرخش سه‌بعدی استفاده کنید.
1. ارائه را ذخیره کنید.

کد زیر در Java نشان می‌دهد چگونه اثرات چرخش سه‌بعدی را بر یک شکل اعمال کنید:

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

    // ارائه را به عنوان فایل PPTX ذخیره کنید.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The 3D rotation effect](3D-rotation-effect.png)

## **بازنشانی قالب‌بندی Reset Formatting**

کد زیر در Java نشان می‌دهد چگونه قالب‌بندی یک اسلاید را بازنشانی کنید و موقعیت، اندازه و قالب‌بندی تمام اشکالی که در [LayoutSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/layoutslide/) دارای placeholder هستند به تنظیمات پیش‌فرض بازگردانید:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // بازنشانی هر شکلی در اسلاید که در طرح‌بندی placeholder دارد.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سوالات متداول FAQ**

**آیا قالب‌بندی شکل بر حجم نهایی فایل ارائه تأثیر می‌گذارد؟**

تنها به‌صورت جزئی. تصاویر و رسانه‌های جاسازی‌شده بیشترین فضای فایل را اشغال می‌کنند، در حالی که پارامترهای شکل مانند رنگ‌ها، افکت‌ها و گرادیان‌ها به‌عنوان متادیتا ذخیره می‌شوند و تقریباً هیچ حجم اضافی ایجاد نمی‌کنند.

**چگونه می‌توانم شکل‌هایی را در اسلاید که قالب‌بندی یکسانی دارند شناسایی کنم تا آنها را گروه‌بندی کنم؟**

ویژگی‌های کلیدی قالب‌بندی هر شکل—پر کردن، خط و تنظیمات افکت—را مقایسه کنید. اگر تمام مقادیر مربوطه مطابقت داشته باشند، سبک آن‌ها را یکسان در نظر بگیرید و منطقاً آن‌ها را گروه‌بندی کنید؛ این کار مدیریت سبک‌ها را در مراحل بعدی ساده می‌سازد.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در یک فایل جداگانه ذخیره کنم تا در ارائه‌های دیگر استفاده شود؟**

بله. شکل‌های نمونه با سبک‌های موردنظر را در یک اسلاید قالب یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد ارائهٔ جدید، قالب را باز کنید، شکل‌های سبک‌دار موردنیاز را کلون کنید و قالب‌بندی آن‌ها را در هر جا که لازم باشد مجدداً اعمال کنید.