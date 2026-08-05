---
title: "قالب‌بندی اشکال پاورپوینت در اندروید"
linktitle: "قالب‌بندی شکل"
type: docs
weight: 20
url: /fa/androidjava/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- افکت اسکیچ
- خط اسکیچ شکل
- قالب‌بندی سبک پیوست
- پر کردن گرادیان
- پر کردن الگو
- پر کردن تصویر
- پر کردن بافت
- پر کردن رنگ جامد
- شفافیت شکل
- چرخاندن شکل
- افکت برجسته ۳بعدی
- افکت چرخش ۳بعدی
- بازنشانی قالب‌بندی
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال پاورپوینت را در اندروید با استفاده از Aspose.Slides قالب‌بندی کنید—پر، خط و سبک‌های افکت را برای فایل‌های PPT، PPTX و ODP با دقت و کنترل کامل تنظیم نمایید."
---
## **معرفی**

در پاورپوینت، می‌توانید اشکال را به اسلایدها اضافه کنید. از آنجا که اشکال از خطوط تشکیل شده‌اند، می‌توانید آن‌ها را با تغییر یا اعمال افکت‌ها بر حاشیه‌هایشان قالب‌بندی کنید. علاوه بر این، می‌توانید اشکال را با تعیین تنظیماتی که نحوه پر شدن داخلی آن‌ها را کنترل می‌کند، قالب‌بندی کنید.

![فرمت‌کردن شکل در پاورپوینت](format-shape-powerpoint.png)

Aspose.Slides for Android via Java رابط‌ها و متدهایی را فراهم می‌کند که به شما امکان می‌دهد اشکال را با استفاده از همان گزینه‌های موجود در پاورپوینت قالب‌بندی کنید.

## **قالب‌بندی خطوط**

با استفاده از Aspose.Slides، می‌توانید یک سبک خط سفارشی برای یک شکل مشخص کنید. مراحل زیر روش را توضیح می‌دهند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. قالب [line style](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/linestyle/) شکل را تنظیم کنید.
1. عرض خط را تنظیم کنید.
1. قالب [dash style](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/linedashstyle/) خط را تنظیم کنید.
1. رنگ خط شکل را تنظیم کنید.
1. ارائهٔ تغییر یافته را به عنوان فایل PPTX ذخیره کنید.

کد زیر نشان می‌دهد چگونه یک `AutoShape` مستطیل را قالب‌بندی کنید:

```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
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

    // ذخیرهٔ فایل PPTX به دیسک.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![خطوط قالب‌بندی‌شده در ارائه](formatted-lines.png)

## **اعمال افکت‌های Sketch بر خطوط شکل**

یک افکت sketch باعث می‌شود خط شکل مانند دست‌نویس به نظر برسد. از [IShape.getLineFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/) برای دسترسی به تنظیمات خط، [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilineformat/) برای دسترسی به تنظیمات sketch، و [ISketchFormat.setSketchType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isketchformat/) برای انتخاب مقداری از شمارش [LineSketchType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/linesketchtype/) استفاده کنید.

کد Java زیر نشان می‌دهد چگونه یک افکت [LineSketchType.Curved](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/linesketchtype/) اعمال کنید، مقدار به‌طور صریح اختصاص داده شده را بخوانید، و افکت را با [LineSketchType.None](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/linesketchtype/) حذف کنید:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // دسترسی به قالب خط شکل و قالب اسکیچ آن.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // اعمال یک افکت اسکیچ.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // خواندن افکت اسکیچ اختصاصی به شکل.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // حذف افکت اسکیچ.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

مقدار بازگشتی توسط [ISketchFormat.getSketchType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isketchformat/) نشان‌دهنده تنظیمی است که مستقیماً به شکل اختصاص داده شده است. اگر قالب‌بندی خط می‌تواند از یک تم، اسلاید اصلی یا اسلاید چیدمان به ارث برده شود، از [ILineFormat.getEffective](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilineformat/) استفاده کنید، به [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilineformateffectivedata/) دسترسی پیدا کنید، و مقدار [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isketchformateffectivedata/) را بخوانید. مقدار مؤثر نمایانگر قالب‌بندی است که پس از حل ارث‌بری واقعاً اعمال می‌شود:

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

## **قالب‌بندی سبک‌های پیوست**

در اینجا سه گزینهٔ نوع پیوست وجود دارد:

* Round
* Miter
* Bevel

به‌طور پیش‌فرض، وقتی پاورپوینت دو خط را در یک زاویه (مانند گوشهٔ یک شکل) به‌هم می‌پیوندد، تنظیم **Round** را به‌کار می‌برد. اما اگر شما شکلی با زاویه‌های تیز می‌کشید، ممکن است گزینهٔ **Miter** را ترجیح دهید.

![سبک پیوست در ارائه](join-style-powerpoint.png)

کد Java زیر نشان می‌دهد چگونه سه مستطیل (همان‌طور که در تصویر بالا دیده می‌شود) با استفاده از تنظیمات سبک پیوست Miter، Bevel و Round ایجاد شده‌اند:

```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
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

    // تنظیم عرض خط.
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

    // تنظیم سبک پیوست.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // افزودن متن به هر مستطیل.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // ذخیرهٔ فایل PPTX به دیسک.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **پر کردن گرادیان**

در پاورپوینت، پر کردن گرادیان یک گزینهٔ قالب‌بندی است که به شما امکان می‌دهد ترکیبی پیوسته از رنگ‌ها را بر روی یک شکل اعمال کنید. به‌عنوان مثال، می‌توانید دو یا چند رنگ را به‌طوری اعمال کنید که یکی به‌تدریج به دیگری محو شود.

در اینجا نحوهٔ اعمال پر کردن گرادیان به یک شکل با استفاده از Aspose.Slides آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/filltype/) شکل را به `Gradient` تنظیم کنید.
1. دو رنگ دلخواه خود را با موقعیت‌های تعریف‌شده با استفاده از متدهای `add` از مجموعه توقف گرادیان که توسط رابط [IGradientFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/igradientformat/) ارائه می‌شود، اضافه کنید.
1. ارائهٔ تغییر یافته را به عنوان فایل PPTX ذخیره کنید.

```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
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

    // ذخیرهٔ فایل PPTX به دیسک.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![بیضی با پر کردن گرادیان](gradient-fill.png)

## **پر کردن الگو**

در پاورپوینت، پر کردن الگو یک گزینهٔ قالب‌بندی است که به شما اجازه می‌دهد طرحی دو‌رنگ‌ مانند نقطه‌ها، خط‌ها، خطوط متقاطع یا شطرنجی را بر روی یک شکل اعمال کنید. می‌توانید رنگ‌های دلخواه برای پیش‌زمینه و پس‌زمینهٔ الگو انتخاب کنید.

Aspose.Slides بیش از ۴۵ سبک الگوی پیش‌فرض را فراهم می‌کند که می‌توانید به اشکال اعمال کنید تا ظاهر ارائه‌هایتان بهبود یابد. حتی پس از انتخاب یک الگوی از پیش تعریف شده، می‌توانید رنگ‌های دقیق مورد استفاده را مشخص کنید.

در اینجا نحوهٔ اعمال پر کردن الگو به یک شکل با استفاده از Aspose.Slides آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/filltype/) شکل را به `Pattern` تنظیم کنید.
1. یک سبک الگو از گزینه‌های پیش‌تعریف‌شده انتخاب کنید.
1. رنگ [Background Color](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/patternformat/#getBackColor--) الگو را تنظیم کنید.
1. رنگ [Foreground Color](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/patternformat/#getForeColor--) الگو را تنظیم کنید.
1. ارائهٔ تغییر یافته را به عنوان فایل PPTX ذخیره کنید.

```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
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

    // تنظیم رنگ‌های پس‌زمینه و پیش‌زمینهٔ الگو.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // ذخیرهٔ فایل PPTX به دیسک.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![مستطیل با پر کردن الگو](pattern-fill.png)

## **پر کردن تصویر**

در پاورپوینت، پر کردن تصویر یک گزینهٔ قالب‌بندی است که به شما امکان می‌دهد یک تصویر را داخل یک شکل قرار دهید—به‌طور مؤثری تصویر را به‌عنوان پس‌زمینهٔ شکل استفاده می‌کند.

در اینجا نحوهٔ استفاده از Aspose.Slides برای اعمال پر کردن تصویر به یک شکل آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/filltype/) شکل را به `Picture` تنظیم کنید.
1. حالت پر کردن تصویر را به `Tile` (یا حالت دلخواه دیگر) تنظیم کنید.
1. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) از تصویری که می‌خواهید استفاده کنید، ایجاد کنید.
1. تصویر را به متد `ISlidesPicture.setImage` منتقل کنید.
1. ارائهٔ تغییر یافته را به عنوان فایل PPTX ذخیره کنید.

![عکس لوتوس](lotus.png)

کد Java زیر نشان می‌دهد چگونه یک شکل را با تصویر پر کنید:

```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
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

    // ذخیرهٔ فایل PPTX به دیسک.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![شکل با پر کردن تصویر](picture-fill.png)

### **کاشی تصویر به‌عنوان بافت**

اگر می‌خواهید تصویر کاشی‌شده‌ای را به‌عنوان بافت تنظیم کنید و رفتار کاشی‌گذاری را سفارشی کنید، می‌توانید از متدهای زیر رابط [IPictureFillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/picturefillformat/) استفاده کنید:

- [setPictureFillMode](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): حالت پر کردن تصویر را تنظیم می‌کند—یا `Tile` یا `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): تراز کاشی‌ها درون شکل را مشخص می‌کند.
- [setTileFlip](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): تعیین می‌کند که کاشی به صورت افقی، عمودی یا هر دو معکوس شود.
- [setTileOffsetX](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): افست افقی کاشی (برحسب نقطه) از مبدأ شکل را تنظیم می‌کند.
- [setTileOffsetY](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): افست عمودی کاشی (برحسب نقطه) از مبدأ شکل را تنظیم می‌کند.
- [setTileScaleX](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): مقیاس افقی کاشی را به‌صورت درصد تعریف می‌کند.
- [setTileScaleY](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): مقیاس عمودی کاشی را به‌صورت درصد تعریف می‌کند.

نمونه کد زیر نشان می‌دهد چگونه یک شکل مستطیل با پر کردن تصویر کاشی‌شده اضافه کنید و گزینه‌های کاشی را پیکربندی کنید:

```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
Presentation presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // افزودن یک شکل خودکار مستطیل.
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

    // پیکربندی حالت پر کردن تصویر و ویژگی‌های کاشی‌گذاری.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // ذخیرهٔ فایل PPTX به دیسک.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![گزینه‌های کاشی](tile-options.png)

## **پر کردن رنگ جامد**

در پاورپوینت، پر کردن رنگ جامد یک گزینهٔ قالب‌بندی است که یک شکل را با یک رنگ یکدست و یکنواخت پر می‌کند. این رنگ پس‌زمینه ساده بدون هیچ‌گونه گرادیان، بافت یا الگو اعمال می‌شود.

برای اعمال پر کردن رنگ جامد به یک شکل با استفاده از Aspose.Slides، مراحل زیر را اجرا کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/filltype/) شکل را به `Solid` تنظیم کنید.
1. رنگ پر کردن دلخواه خود را به شکل اختصاص دهید.
1. ارائهٔ تغییر یافته را به عنوان فایل PPTX ذخیره کنید.

```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
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

    // ذخیرهٔ فایل PPTX به دیسک.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![شکل با پر کردن رنگ جامد](solid-color-fill.png)

## **تنظیم شفافیت**

در پاورپوینت، هنگامی که پر کردن رنگ ثابت، گرادیان، تصویر یا بافت را به اشکال اعمال می‌کنید، می‌توانید سطح شفافیت را نیز تنظیم کنید تا میزان کدورت پر کردن را کنترل نمایید. مقدار بالاتر شفافیت باعث می‌شود شکل بیشتر شفاف باشد و پس‌زمینه یا اشیای زیرین به‌صورت جزئی دیده شوند.

Aspose.Slides به شما امکان می‌دهد سطح شفافیت را با تنظیم مقدار آلفا در رنگ مورد استفاده برای پر کردن تنظیم کنید. در اینجا نحوهٔ انجام آن آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/filltype/) را به `Solid` تنظیم کنید.
1. از `Color` برای تعریف رنگی با شفافیت (مؤلفهٔ آلفا شفافیت را کنترل می‌کند) استفاده کنید.
1. ارائه را ذخیره کنید.

```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
Presentation presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // افزودن یک شکل خودکار مستطیل جامد.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // افزودن یک شکل خودکار مستطیل شفاف بر روی شکل جامد.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // ذخیرهٔ فایل PPTX به دیسک.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![شکل شفاف](shape-transparency.png)

## **چرخاندن اشکال**

Aspose.Slides به شما امکان می‌دهد اشکال را در ارائه‌های پاورپوینت چرخانید. این کار می‌تواند هنگام موقعیت‌دهی به عناصر بصری با نیازهای خاص هم‌ترازی یا طراحی مفید باشد.

برای چرخاندن یک شکل در اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی چرخش شکل را به زاویهٔ مورد نظر تنظیم کنید.
1. ارائه را ذخیره کنید.

```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
Presentation presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // افزودن یک شکل خودکار از نوع Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // چرخاندن شکل به‌ میزان 5 درجه.
    shape.setRotation(5);

    // ذخیرهٔ فایل PPTX به دیسک.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![چرخش شکل](shape-rotation.png)

## **افکت‌های برجسته 3D را اضافه کنید**

Aspose.Slides به شما امکان می‌دهد افکت‌های برجستهٔ 3 بعدی را به اشکال اعمال کنید با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/threedformat/) آن‌ها.

برای افزودن افکت‌های برجستهٔ 3 بعدی به یک شکل، مراحل زیر را اجرا کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی [ThreeDFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/threedformat/) شکل را برای تعریف تنظیمات برجسته پیکربندی کنید.
1. ارائه را ذخیره کنید.

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

    // ارائه را به صورت فایل PPTX ذخیره کنید.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![اثر برجستگی 3D](3D-bevel-effect.png)

## **افکت‌های چرخش 3D را اضافه کنید**

Aspose.Slides به شما امکان می‌دهد افکت‌های چرخش 3 بعدی را به اشکال اعمال کنید با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/threedformat/) آن‌ها.

برای اعمال چرخش 3 بعدی به یک شکل:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. برای تعریف چرخش 3 بعدی از متدهای [setCameraType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icamera/#setCameraType-int-) و [setLightType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) استفاده کنید.
1. ارائه را ذخیره کنید.

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

![اثر چرخش 3D](3D-rotation-effect.png)

## **بازنشانی قالب‌بندی**

کد Java زیر نشان می‌دهد چگونه قالب‌بندی یک اسلاید را بازنشانی کنید و موقعیت، اندازه و قالب‌بندی تمام اشکال با نگهدارنده‌ها در [LayoutSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/layoutslide/) را به تنظیمات پیش‌فرض برگردانید:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // بازنشانی هر شکلی در اسلاید که در طرح‌بندی دارای نگهدارنده است.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**آیا قالب‌بندی اشکال بر حجم نهایی فایل ارائه تأثیر می‌گذارد؟**

فقط به‌صورت کمینه. تصاویر و رسانه‌های جاسازی‌شده بیشترین فضای فایل را اشغال می‌کنند، در حالی که پارامترهای شکل مانند رنگ‌ها، افکت‌ها و گرادیان‌ها به‌عنوان متاداده ذخیره می‌شوند و به‌طور واقعی حجم اضافی اضافه نمی‌کنند.

**چگونه می‌توانم اشکالی را در یک اسلاید شناسایی کنم که قالب‌بندی یکسانی دارند تا بتوانم آن‌ها را گروه‌بندی کنم؟**

ویژگی‌های کلیدی قالب‌بندی هر شکل—مانند تنظیمات پر، خط و افکت‌ها—را مقایسه کنید. اگر تمام مقادیر متناظر برابر باشند، سبک آن‌ها را یکسان در نظر بگیرید و منطقی آن‌ها را گروه‌بندی کنید؛ این کار مدیریت سبک‌ها را در مراحل بعدی ساده می‌کند.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در یک فایل جداگانه ذخیره کنم تا در ارائه‌های دیگر استفاده مجدد کنم؟**

بله. اشکال نمونه با سبک‌های دلخواه را در یک اسلاید قالب یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد ارائهٔ جدید، قالب را باز کنید، اشکال قالب‌دار مورد نیاز را کلون کنید و قالب‌بندی آن‌ها را در هر جایی که لازم است دوباره اعمال کنید.