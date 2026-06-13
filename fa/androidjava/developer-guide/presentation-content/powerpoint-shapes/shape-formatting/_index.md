---
title: قالب‌بندی اشکال پاورپوینت در اندروید
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/androidjava/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- قالب‌بندی سبک پیوند
- پر کردن گرادیان
- پر کردن الگو
- پر کردن تصویر
- پر کردن بافت
- پر کردن رنگ واحد
- شفافیت شکل
- چرخاندن شکل
- اثر برش 3 بعدی
- اثر چرخش 3 بعدی
- بازنشانی قالب‌بندی
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "بیاموزید چگونه اشکال پاورپوینت را در اندروید با استفاده از Aspose.Slides قالب‌بندی کنید—پر کردن، خط و سبک افکت‌ها را برای فایل‌های PPT، PPTX و ODP با دقت و کنترل کامل تنظیم کنید."
---
## **معرفی**

در PowerPoint می‌توانید اشکال را به اسلایدها اضافه کنید. از آنجا که اشکال از خطوط تشکیل شده‌اند، می‌توانید آن‌ها را با اصلاح یا اعمال افکت‌ها به خطوط مرزی‌شان قالب‌بندی کنید. همچنین می‌توانید با تنظیماتی که نحوه پر کردن داخلی آن‌ها را کنترل می‌کند، اشکال را قالب‌بندی کنید.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java رابط‌ها و روش‌هایی ارائه می‌دهد که به شما امکان می‌دهد اشکال را با همان گزینه‌های موجود در PowerPoint قالب‌بندی کنید.

## **قالب‌بندی خطوط**

با استفاده از Aspose.Slides می‌توانید یک سبک خط سفارشی برای یک شکل مشخص کنید. مراحل زیر این فرایند را توضیح می‌دهند:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلایدی بر اساس اندیس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. [سبک خط](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/linestyle/) شکل را تنظیم کنید.
1. ضخامت خط را تنظیم کنید.
1. [سبک خط‌چین](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/linedashstyle/) را تنظیم کنید.
1. رنگ خط برای شکل را تعیین کنید.
1. ارائه تغییر یافته را به عنوان یک فایل PPTX ذخیره کنید.

کد زیر نشان می‌دهد چگونه یک `AutoShape` مستطیلی را قالب‌بندی کنید:

```java
// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // یک شکل خودکار از نوع Rectangle اضافه کنید.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // رنگ پر کردن برای شکل مستطیل را تنظیم کنید.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // قالب‌بندی را بر خطوط مستطیل اعمال کنید.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // رنگ خط مستطیل را تنظیم کنید.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // فایل PPTX را بر روی دیسک ذخیره کنید.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![خطوط قالب‌بندی‌شده در ارائه](formatted-lines.png)

## **قالب‌بندی انواع پیوند**

سه گزینه نوع پیوند وجود دارد:

* گرد
* میتر
* زاویه‌دار

به‌طور پیش‌فرض، وقتی PowerPoint دو خط را در زاویه‌ای (مانند گوشهٔ یک شکل) به هم متصل می‌کند، از تنظیم **گرد** استفاده می‌کند. با این حال، اگر شکلی با زوایای تیز رسم می‌کنید، ممکن است گزینه **میتر** را ترجیح دهید.

![سبک پیوند در ارائه](join-style-powerpoint.png)

کد زیر نشان می‌دهد چگونه سه مستطیل (همان‌طور که در تصویر بالا می‌بینید) با استفاده از تنظیمات پیوند میتر، زاویه‌دار و گرد ایجاد شدند:

```java
// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // سه شکل خودکار از نوع Rectangle اضافه کنید.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // رنگ پر کردن برای هر شکل مستطیل را تنظیم کنید.
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

    // سبک پیوند را تنظیم کنید.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // متن را به هر مستطیل اضافه کنید.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // فایل PPTX را بر روی دیسک ذخیره کنید.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **پر کردن گرادیان**

در PowerPoint، پر کردن گرادیان یک گزینه قالب‌بندی است که به شما امکان می‌دهد ترکیبی پیوسته از رنگ‌ها را روی یک شکل اعمال کنید. به‌عنوان مثال، می‌توانید دو یا چند رنگ را به‌گونه‌ای اعمال کنید که یکی به تدریج به دیگری محو شود.

در ادامه نحوه اعمال پر کردن گرادیان به یک شکل با استفاده از Aspose.Slides آورده شده است:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلایدی بر اساس اندیس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. `FillType` شکل را به `Gradient` تنظیم کنید.
1. دو رنگ مورد نظر خود را با موقعیت‌های تعریف‌شده با استفاده از متدهای `add` مجموعهٔ نقاط توقف گرادیان که توسط رابط [IGradientFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/igradientformat/) فراهم می‌شود، اضافه کنید.
1. ارائه تغییر یافته را به عنوان یک فایل PPTX ذخیره کنید.

کد زیر نشان می‌دهد چگونه یک اثر پر کردن گرادیان را روی یک بیضی اعمال کنید:

```java
// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // یک شکل خودکار از نوع Ellipse اضافه کنید.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // قالب‌بندی گرادیان را بر روی بیضی اعمال کنید.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // جهت گرادیان را تنظیم کنید.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // دو نقطه توقف گرادیان اضافه کنید.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // فایل PPTX را بر روی دیسک ذخیره کنید.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


نتیجه:

![بیضی با پر کردن گرادیان](gradient-fill.png)

## **پر کردن الگو**

در PowerPoint، پر کردن الگو یک گزینه قالب‌بندی است که به شما اجازه می‌دهد طراحی دو‌رنگی—مانند نقاط، خطوط، خطوط متقاطع یا شطرنجی—را روی یک شکل اعمال کنید. می‌توانید رنگ‌های دلخواه برای پیش‌زمینه و پس‌زمینه الگو انتخاب کنید.

Aspose.Slides بیش از ۴۵ سبک الگوی از پیش تعریف‌شده ارائه می‌دهد که می‌توانید آن‌ها را روی اشکال اعمال کنید تا جذابیت بصری ارائه‌های خود را افزایش دهید. حتی پس از انتخاب یک الگوی از پیش تعریف‌شده، می‌توانید رنگ‌های دقیق مورد استفاده را مشخص کنید.

در ادامه نحوه اعمال پر کردن الگو به یک شکل با استفاده از Aspose.Slides آمده است:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلایدی بر اساس اندیس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. `FillType` شکل را به `Pattern` تنظیم کنید.
1. یک سبک الگو از گزینه‌های از پیش تعریف‌شده انتخاب کنید.
1. [رنگ پس‌زمینه](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/patternformat/#getBackColor--) الگو را تنظیم کنید.
1. [رنگ پیش‌زمینه](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/patternformat/#getForeColor--) الگو را تنظیم کنید.
1. ارائه تغییر یافته را به عنوان یک فایل PPTX ذخیره کنید.

کد زیر نشان می‌دهد چگونه یک پر کردن الگو را روی یک مستطیل اعمال کنید:

```java
// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // یک شکل خودکار از نوع Rectangle اضافه کنید.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // نوع پر کردن را به Pattern تنظیم کنید.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // سبک الگو را تنظیم کنید.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // رنگ زمینه و پیش‌زمینه الگو را تنظیم کنید.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // فایل PPTX را بر روی دیسک ذخیره کنید.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![مستطیل با پر کردن الگو](pattern-fill.png)

## **پر کردن تصویر**

در PowerPoint، پر کردن تصویر یک گزینه قالب‌بندی است که به شما امکان می‌دهد یک تصویر را داخل یک شکل قرار دهید—در واقع تصویر را به‌عنوان پس‌زمینهٔ شکل استفاده کنید.

در ادامه نحوه استفاده از Aspose.Slides برای اعمال پر کردن تصویر به یک شکل آورده شده است:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلایدی بر اساس اندیس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. `FillType` شکل را به `Picture` تنظیم کنید.
1. حالت پر کردن تصویر را به `Tile` (یا حالت دلخواه دیگر) تنظیم کنید.
1. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) از تصویری که می‌خواهید استفاده کنید، ایجاد کنید.
1. تصویر را به متد `ISlidesPicture.setImage` پاس بدهید.
1. ارائه تغییر یافته را به عنوان یک فایل PPTX ذخیره کنید.

فرض کنید فایلی به نام «lotus.png» با تصویر زیر داریم:

![تصویر لوتوس](lotus.png)

کد زیر نشان می‌دهد چگونه یک شکل را با تصویر پر کنید:

```java
// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // یک شکل خودکار از نوع Rectangle اضافه کنید.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // نوع پر کردن را به Picture تنظیم کنید.
    shape.getFillFormat().setFillType(FillType.Picture);

    // حالت پر کردن تصویر را تنظیم کنید.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // یک تصویر را بارگذاری کرده و به منابع ارائه اضافه کنید.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // تصویر را تنظیم کنید.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // فایل PPTX را بر روی دیسک ذخیره کنید.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![شکل با پر شدن تصویر](picture-fill.png)

### **کاشی کردن تصویر به‌عنوان بافت**

اگر می‌خواهید یک تصویر کاشی‌شده را به‌عنوان بافت تنظیم کنید و رفتار کاشی‌بندی را سفارشی کنید، می‌توانید از روش‌های زیر رابط [IPictureFillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/picturefillformat/) استفاده کنید:

- [setPictureFillMode](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): حالت پر کردن تصویر را تنظیم می‌کند—یا `Tile` یا `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): تراز کاشی‌ها داخل شکل را مشخص می‌کند.
- [setTileFlip](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): مشخص می‌سازد که آیا کاشی به‌صورت افقی، عمودی یا هر دو معکوس شود.
- [setTileOffsetX](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): افست افقی کاشی (بر حسب نقاط) از مبدأ شکل را تنظیم می‌کند.
- [setTileOffsetY](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): افست عمودی کاشی (بر حسب نقاط) از مبدأ شکل را تنظیم می‌کند.
- [setTileScaleX](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): مقیاس افقی کاشی را به‌صورت درصد تعریف می‌کند.
- [setTileScaleY](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): مقیاس عمودی کاشی را به‌صورت درصد تعریف می‌کند.

نمونه کد زیر نشان می‌دهد چگونه یک شکل مستطیل با پر شدن تصویر کاشی‌شده اضافه کنید و گزینه‌های کاشی را پیکربندی کنید:

```java
// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // یک شکل خودکار مستطیل اضافه کنید.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // نوع پر کردن شکل را به Picture تنظیم کنید.
    shape.getFillFormat().setFillType(FillType.Picture);

    // تصویر را بارگذاری کرده و به منابع ارائه اضافه کنید.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // تصویر را به شکل اختصاص دهید.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // حالت پر کردن تصویر و مشخصات کاشی‌بندی را تنظیم کنید.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // فایل PPTX را بر روی دیسک ذخیره کنید.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![گزینه‌های کاشی](tile-options.png)

## **پر کردن رنگ واحد**

در PowerPoint، پر کردن رنگ واحد یک گزینه قالب‌بندی است که یک شکل را با یک رنگ یکنواخت پر می‌کند. این رنگ پس‌زمینه ساده بدون هیچ گرادیان، بافت یا الگویی اعمال می‌شود.

برای اعمال پر کردن رنگ واحد به یک شکل با استفاده از Aspose.Slides، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلایدی بر اساس اندیس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. `FillType` شکل را به `Solid` تنظیم کنید.
1. رنگ پر کردن دلخواه خود را به شکل اختصاص دهید.
1. ارائه تغییر یافته را به عنوان یک فایل PPTX ذخیره کنید.

کد زیر نشان می‌دهد چگونه یک پر کردن رنگ واحد را روی یک مستطیل در اسلاید PowerPoint اعمال کنید:

```java
// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // یک شکل خودکار از نوع Rectangle اضافه کنید.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // نوع پر کردن را به Solid تنظیم کنید.
    shape.getFillFormat().setFillType(FillType.Solid);

    // رنگ پر کردن را تنظیم کنید.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // فایل PPTX را بر روی دیسک ذخیره کنید.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![شکل با پر کردن رنگ واحد](solid-color-fill.png)

## **تنظیم شفافیت**

در PowerPoint، وقتی یک پر کردن رنگی، گرادیان، تصویر یا بافت را بر روی اشکال اعمال می‌کنید، می‌توانید سطح شفافیت را تنظیم کنید تا میزان مات بودن پر شدن را کنترل کنید. مقدار شفافیت بالاتر باعث می‌شود شکل بیشتر شفاف باشد و پس‌زمینه یا اشیای زیرین به‌طور جزئی قابل مشاهده شوند.

Aspose.Slides به شما اجازه می‌دهد سطح شفافیت را با تنظیم مقدار آلفا در رنگ استفاده‌شده برای پر کردن تنظیم کنید. در ادامه نحوه انجام این کار آورده شده است:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلایدی بر اساس اندیس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. `FillType` را به `Solid` تنظیم کنید.
1. از `Color` برای تعریف یک رنگ با شفافیت (مولفهٔ `alpha` شفافیت را کنترل می‌کند) استفاده کنید.
1. ارائه را ذخیره کنید.

کد زیر نشان می‌دهد چگونه یک رنگ پر کردن شفاف را بر روی یک مستطیل اعمال کنید:

```java
// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // یک شکل خودکار مستطیل ثابت اضافه کنید.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // یک شکل خودکار مستطیل شفاف بالای شکل ثابت اضافه کنید.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // فایل PPTX را بر روی دیسک ذخیره کنید.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![شکل شفاف](shape-transparency.png)

## **چرخاندن اشکال**

Aspose.Slides به شما امکان می‌دهد اشکال را در ارائه‌های PowerPoint بچرخانید. این می‌تواند هنگام موقعیت‌یابی عناصر بصری با نیازهای خاص تراز یا طراحی مفید باشد.

برای چرخاندن یک شکل در یک اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلایدی بر اساس اندیس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی چرخش شکل را به زاویهٔ مورد نیاز تنظیم کنید.
1. ارائه را ذخیره کنید.

کد زیر نشان می‌دهد چگونه یک شکل را به‌صورت 5 درجه بچرخانید:

```java
// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // یک شکل خودکار از نوع Rectangle اضافه کنید.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // شکل را به اندازه 5 درجه بچرخانید.
    shape.setRotation(5);

    // فایل PPTX را بر روی دیسک ذخیره کنید.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![چرخش شکل](shape-rotation.png)

## **افزودن اثرات برش 3 بعدی**

Aspose.Slides به شما امکان می‌دهد اثرات برش 3 بعدی را به اشکال اعمال کنید با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/threedformat/) آنها.

برای افزودن اثرات برش 3 بعدی به یک شکل، مراحل زیر را انجام دهید:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلایدی بر اساس اندیس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/threedformat/) شکل را تنظیم کنید تا تنظیمات برش را تعریف کنید.
1. ارائه را ذخیره کنید.

کد زیر نشان می‌دهد چگونه اثرات برش 3 بعدی را به یک شکل اعمال کنید:

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

![اثر برش 3 بعدی](3D-bevel-effect.png)

## **افزودن اثرات چرخش 3 بعدی**

Aspose.Slides به شما امکان می‌دهد اثرات چرخش 3 بعدی را به اشکال اعمال کنید با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/threedformat/) آنها.

برای اعمال چرخش 3 بعدی به یک شکل:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلایدی بر اساس اندیس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. از متدهای [setCameraType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icamera/#setCameraType-int-) و [setLightType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) برای تعریف چرخش 3 بعدی استفاده کنید.
1. ارائه را ذخیره کنید.

کد زیر نشان می‌دهد چگونه اثرات چرخش 3 بعدی را به یک شکل اعمال کنید:

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

![اثر چرخش 3 بعدی](3D-rotation-effect.png)

## **بازنشانی قالب‌بندی**

کد زیر نشان می‌دهد چگونه قالب‌بندی یک اسلاید را بازنشانی کنید و موقعیت، اندازه و قالب‌بندی تمام اشکالی که دارای نگهدارنده‌ها در [LayoutSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/layoutslide/) هستند، به تنظیمات پیش‌فرض برگردانید:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // بازنشانی هر شکلی در اسلاید که یک نگه‌دارنده در طرح‌بندی دارد.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **پرسش‌های متداول**

**آیا قالب‌بندی شکل بر حجم نهایی فایل ارائه تأثیر می‌گذارد؟**

تقریبا نه. تصاویر و رسانه‌های جاسازی‌شده بیشترین فضای فایل را اشغال می‌کنند، در حالی که پارامترهای شکل مانند رنگ‌ها، افکت‌ها و گرادیان‌ها به‌عنوان متادیتا ذخیره می‌شوند و به‌طور قابل‌توجهی حجم اضافی اضافه نمی‌کنند.

**چگونه می‌توانم اشکالی را در اسلاید که قالب‌بندی یکسانی دارند شناسایی کنم تا بتوانم آن‌ها را گروه‌بندی کنم؟**

خواص کلیدی قالب‌بندی هر شکل—تنظیمات پر کردن، خط و افکت—را مقایسه کنید. اگر تمام مقادیر متناظر مطابقت داشته باشند، سبک آن‌ها را یکسان در نظر بگیرید و به‌صورت منطقی آن اشکال را گروه‌بندی کنید که مدیریت سبک‌ها را بعداً ساده می‌سازد.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در یک فایل جداگانه ذخیره کنم تا در ارائه‌های دیگر دوباره استفاده کنم؟**

بله. اشکال نمونه با سبک‌های مورد نظر را در یک اسلاید قالب یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد یک ارائه جدید، قالب را باز کنید، اشکال سبک‌دار مورد نیاز را کلون کنید و قالب‌بندی آن‌ها را در هر جایی که نیاز باشد، دوباره اعمال کنید.