---
title: قالب‌بندی اشکال PowerPoint در جاوا
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/java/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- افکت Sketch
- خط شکل Sketch
- قالب‌بندی سبک Join
- پر کردن Gradient
- پر کردن Pattern
- پر کردن Picture
- پر کردن Texture
- پر کردن Solid Color
- شفافیت شکل
- رندر سیاه‑سفید شکل
- رندر خاکستری شکل
- چرخاندن شکل
- افکت Bevel سه‌بعدی
- افکت چرخش سه‌بعدی
- بازنشانی قالب‌بندی
- PowerPoint
- ارائه
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال PowerPoint را در جاوا با استفاده از Aspose.Slides—پر کردن، خط و سبک افکت‌ها را برای فایل‌های PPT، PPTX و ODP با دقت و کنترل کامل تنظیم کنید."
---
## **مقدمه**

در PowerPoint می‌توانید اشکال را به اسلایدها اضافه کنید. از آنجا که اشکال از خطوط تشکیل شده‌اند، می‌توانید آنها را با تغییر یا اعمال افکت بر روی خطوط حاشیه‌دارشان قالب‌بندی کنید. علاوه بر این، می‌توانید با تعیین تنظیماتی که پر کردن داخلی آنها را کنترل می‌کند، اشکال را قالب‌بندی کنید.

![فرمت‌گذاری‌اشکال‑پاورپوینت](format-shape-powerpoint.png)

Aspose.Slides for Java رابط‌ها و متدهایی را فراهم می‌آورد که به شما امکان می‌دهد اشکال را با همان گزینه‌های موجود در PowerPoint قالب‌بندی کنید.

## **قالب‌بندی خطوط**

با استفاده از Aspose.Slides می‌توانید یک سبک خط سفارشی برای یک شکل تعیین کنید. مراحل زیر این فرآیند را شرح می‌دهند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس آن، به یک اسلاید مراجعه کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) را به اسلاید اضافه کنید.
1. [قالب خط](https://reference.aspose.com/slides/fa/java/com.aspose.slides/linestyle/) شکل را تنظیم کنید.
1. ضخامت خط را تعیین کنید.
1. [قالب نقطه‌چین](https://reference.aspose.com/slides/fa/java/com.aspose.slides/linedashstyle/) خط را تنظیم کنید.
1. رنگ خط شکل را تنظیم کنید.
1. ارائهٔ اصلاح‌شده را به عنوان فایل PPTX ذخیره کنید.

کد زیر نشان می‌دهد چطور یک `AutoShape` مستطیل را قالب‌بندی کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // یک شکل خودکار از نوع Rectangle اضافه کنید.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // رنگ پر کردن برای شکل مستطیل تنظیم کنید.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // قالب‌بندی را بر خطوط مستطیل اعمال کنید.
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

![خطوط قالب‌بندی‌شده در ارائه](formatted-lines.png)

## **اعمال افکت Sketch بر خطوط شکل**

یک افکت Sketch باعث می‌شود خط شکل به‌نظر برسد که دست‌نویس باشد. از [IShape.getLineFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/) برای دسترسی به تنظیمات خط، [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilineformat/) برای دسترسی به تنظیمات Sketch و [ISketchFormat.setSketchType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isketchformat/) برای انتخاب مقدار از شمارش‌گر [LineSketchType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/linesketchtype/) استفاده کنید.

کد زیر نشان می‌دهد چطور افکت [LineSketchType.Curved](https://reference.aspose.com/slides/fa/java/com.aspose.slides/linesketchtype/) را اعمال، مقدار اختصاص داده‌شده را بخوانید و افکت را با [LineSketchType.None](https://reference.aspose.com/slides/fa/java/com.aspose.slides/linesketchtype/) حذف کنید:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // دسترسی به قالب خط شکل و قالب Sketch آن.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // اعمال یک افکت Sketch.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // خواندن افکت Sketch که مستقیم به شکل اختصاص داده شده است.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // حذف افکت Sketch.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

مقداری که توسط [ISketchFormat.getSketchType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isketchformat/) بازگردانده می‌شود، تنظیمی است که مستقیماً به شکل اختصاص یافته است. اگر قالب‌بندی خط می‌تواند از یک تم، اسلاید اصلی یا اسلاید چیدمان به ارث برده شود، از [ILineFormat.getEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilineformat/) استفاده کنید، به [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilineformateffectivedata/) دسترسی پیدا کنید و [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isketchformateffectivedata/) را بخوانید. مقدار مؤثر، قالب‌بندی واقعی است که پس از حل ارث‌بری اعمال می‌شود:

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

## **قالب‌بندی انواع Join**

سه گزینهٔ نوع Join عبارتند از:

* Round
* Miter
* Bevel

به طور پیش‌فرض، زمانی که PowerPoint دو خط را تحت زاویه‌ای (مانند گوشهٔ یک شکل) به هم وصل می‌کند، از تنظیم **Round** استفاده می‌کند. اما اگر شکلی با زوایای تیز می‌کشید، شاید گزینهٔ **Miter** را ترجیح دهید.

![سبک Join در ارائه](join-style-powerpoint.png)

کد زیر نشان می‌دهد چگونه سه مستطیل (مانند تصویر بالا) با استفاده از تنظیمات Join نوع Miter، Bevel و Round ایجاد شدند:

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // سه شکل خودکار از نوع Rectangle اضافه کنید.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // رنگ پر کردن برای هر شکل مستطیل تنظیم کنید.
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

    // سبک اتصال (Join) را تنظیم کنید.
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

## **پر کردن Gradient**

در PowerPoint، پر کردن Gradient یک گزینهٔ قالب‌بندی است که به شما اجازه می‌دهد ترکیب پیوسته‌ای از رنگ‌ها را بر روی یک شکل اعمال کنید. به‌عنوان مثال می‌توانید دو یا چند رنگ را به‌گونه‌ای اعمال کنید که یکی به‌تدریج به دیگری محو شود.

نحوهٔ اعمال پر کردن Gradient به یک شکل با Aspose.Slides:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس، به یک اسلاید مراجعه کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) را به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/filltype/) شکل را به `Gradient` تنظیم کنید.
1. دو رنگ مطلوب خود را با موقعیت‌های تعریف‌شده با استفاده از متدهای `add` مجموعهٔ توقف Gradient که توسط رابط [IGradientFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/igradientformat/) در دسترس است، اضافه کنید.
1. ارائهٔ اصلاح‌شده را به عنوان فایل PPTX ذخیره کنید.

کد زیر نحوهٔ اعمال افکت پر کردن Gradient به یک بیضی را نشان می‌دهد:

```java
import com.aspose.slides.*;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // یک شکل خودکار از نوع Ellipse اضافه کنید.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // قالب‌بندی گرادیان را بر الیپس اعمال کنید.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // جهت گرادیان را تنظیم کنید.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // دو نقطه توقف گرادیان اضافه کنید.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // فایل PPTX را روی دیسک ذخیره کنید.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![بیضی با پر کردن Gradient](gradient-fill.png)

## **پر کردن Pattern**

در PowerPoint، پر کردن Pattern یک گزینهٔ قالب‌بندی است که به شما اجازه می‌دهد طرح دو‑رنگی—مانند نقطه‌ها، خط‌راه‌ها، خط‌قاطع یا شطرنجی‌ها—را بر روی یک شکل اعمال کنید. می‌توانید رنگ‌های سفارشی برای پیش‌زمینه و پس‌زمینهٔ الگو انتخاب کنید.

Aspose.Slides بیش از ۴۵ سبک پیش‌تعریف‌شدهٔ Pattern را فراهم می‌کند که می‌توانید به اشکال اعمال کنید تا جذابیت بصری ارائه‌هایتان افزایش یابد. حتی پس از انتخاب یک Pattern پیش‌تعریف‌شده، می‌توانید رنگ‌های دقیق موردنظر را تعیین کنید.

نحوهٔ اعمال پر کردن Pattern به یک شکل با Aspose.Slides:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس، به یک اسلاید مراجعه کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) را به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/filltype/) شکل را به `Pattern` تنظیم کنید.
1. یک سبک Pattern از گزینه‌های پیش‌تعریف‌شده انتخاب کنید.
1. [Background Color](https://reference.aspose.com/slides/fa/java/com.aspose.slides/patternformat/#getBackColor--) الگو را تنظیم کنید.
1. [Foreground Color](https://reference.aspose.com/slides/fa/java/com.aspose.slides/patternformat/#getForeColor--) الگو را تنظیم کنید.
1. ارائهٔ اصلاح‌شده را به عنوان فایل PPTX ذخیره کنید.

کد زیر نحوهٔ اعمال پر کردن Pattern به یک مستطیل را نشان می‌دهد:

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // یک شکل خودکار از نوع Rectangle اضافه کنید.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // نوع پر کردن را به Pattern تنظیم کنید.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // سبک الگوی (Pattern) را تنظیم کنید.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // رنگ پس‌زمینه و پیش‌زمینهٔ الگو را تنظیم کنید.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // فایل PPTX را روی دیسک ذخیره کنید.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![مستطیل با پر کردن Pattern](pattern-fill.png)

## **پر کردن Picture**

در PowerPoint، پر کردن Picture یک گزینهٔ قالب‌بندی است که به شما امکان می‌دهد یک تصویر را داخل یک شکل قرار دهید—عملاً تصویر را به‌عنوان پس‌زمینهٔ شکل استفاده کنید.

نحوهٔ استفاده از Aspose.Slides برای اعمال پر کردن Picture به یک شکل:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس، به یک اسلاید مراجعه کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) را به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/filltype/) شکل را به `Picture` تنظیم کنید.
1. حالت پر کردن تصویر را به `Tile` (یا حالت دیگر موردنظر) تنظیم کنید.
1. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ippimage/) از تصویری که می‌خواهید استفاده کنید، ایجاد کنید.
1. تصویر را به متد `ISlidesPicture.setImage` پاس دهید.
1. ارائهٔ اصلاح‌شده را به عنوان فایل PPTX ذخیره کنید.

تصویر زیر را با نام «lotus.png» در نظر بگیرید:

![عکس لوتوس](lotus.png)

کد زیر نحوهٔ پر کردن یک شکل با تصویر را نشان می‌دهد:

```java
import com.aspose.slides.*;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
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

    // یک تصویر را بارگذاری کنید و به منابع ارائه اضافه کنید.
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

![شکل با پر کردن Picture](picture-fill.png)

### **Tile Picture As Texture**

اگر می‌خواهید یک تصویر کاشی‌شده را به‌عنوان بافت تنظیم کنید و رفتار کاشی‌گذاری را سفارشی کنید، می‌توانید از متدهای زیر رابط [IPictureFillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/picturefillformat/) استفاده کنید:

- [setPictureFillMode](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): حالت پر کردن تصویر را تنظیم می‌کند—یا `Tile` یا `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): ترازبندی کاشی‌ها را درون شکل مشخص می‌کند.
- [setTileFlip](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): تعیین می‌کند که کاشی به صورت افقی، عمودی یا هر دو معکوس شود.
- [setTileOffsetX](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): افست افقی کاشی (بر حسب نقطه) را از مبدأ شکل تنظیم می‌کند.
- [setTileOffsetY](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): افست عمودی کاشی (بر حسب نقطه) را از مبدأ شکل تنظیم می‌کند.
- [setTileScaleX](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): مقیاس افقی کاشی به‌صورت درصد تعریف می‌شود.
- [setTileScaleY](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): مقیاس عمودی کاشی به‌صورت درصد تعریف می‌شود.

نمونه کد زیر نشان می‌دهد چطور یک شکل مستطیل با پر کردن تصویر کاشی‌شده اضافه کنید و گزینه‌های کاشی را پیکربندی کنید:

```java
import com.aspose.slides.*;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // یک شکل خودکار مستطیلی اضافه کنید.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // نوع پر کردن شکل را به Picture تنظیم کنید.
    shape.getFillFormat().setFillType(FillType.Picture);

    // تصویر را بارگذاری کنید و به منابع ارائه اضافه کنید.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // تصویر را به شکل اختصاص دهید.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // حالت پر کردن تصویر و ویژگی‌های کاشی‌گذاری را پیکربندی کنید.
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

![گزینه‌های کاشی](tile-options.png)

## **پر کردن Solid Color**

در PowerPoint، پر کردن Solid Color یک گزینهٔ قالب‌بندی است که یک شکل را با یک رنگ یکنواخت پر می‌کند. این رنگ ساده بدون هیچ Gradient، Texture یا Patternی اعمال می‌شود.

برای اعمال پر کردن Solid Color به یک شکل با Aspose.Slides، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس، به یک اسلاید مراجعه کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) را به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/filltype/) شکل را به `Solid` تنظیم کنید.
1. رنگ پر کردن موردنظر خود را به شکل اختصاص دهید.
1. ارائهٔ اصلاح‌شده را به عنوان فایل PPTX ذخیره کنید.

کد زیر نحوهٔ اعمال پر کردن Solid Color به یک مستطیل در اسلاید PowerPoint را نشان می‌دهد:

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
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

    // فایل PPTX را روی دیسک ذخیره کنید.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![شکل با پر کردن Solid Color](solid-color-fill.png)

## **تنظیم Transparency**

در PowerPoint، هنگام اعمال پر کردن Solid Color، Gradient، Picture یا Texture به اشکال، می‌توانید سطح شفافیت را تنظیم کنید تا میزان شفافیت پر کردن کنترل شود. مقدار شفافیت بالاتر، شکل را شفاف‌تر می‌کند و پس‌زمینه یا اشیای زیرین را تا حدی قابل مشاهده می‌سازد.

Aspose.Slides به شما اجازه می‌دهد با تنظیم مقدار آلفا در رنگ مورد استفاده برای پر کردن، سطح شفافیت را تنظیم کنید. نحوهٔ انجام این کار به شرح زیر است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس، به یک اسلاید مراجعه کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) را به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/filltype/) را به `Solid` تنظیم کنید.
1. از `Color` برای تعریف رنگی با شفافیت استفاده کنید (مقدار `alpha` شفافیت را کنترل می‌کند).
1. ارائه را ذخیره کنید.

کد زیر نحوهٔ اعمال رنگ پر کردن شفاف به یک مستطیل را نشان می‌دهد:

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // یک شکل خودکار مستطیل صلب اضافه کنید.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // یک شکل خودکار مستطیل شفاف بر روی شکل صلب اضافه کنید.
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

![شکل شفاف](shape-transparency.png)

## **چرخاندن اشکال**

Aspose.Slides به شما امکان می‌دهد اشکال را در ارائه‌های PowerPoint چرخانید. این قابلیت برای موقعیت‌یابی عناصر بصری با تنظیمات خاص چیدمان یا نیازهای طراحی مفید است.

برای چرخاندن یک شکل در یک اسلاید، مراحل زیر را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس، به یک اسلاید مراجعه کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) را به اسلاید اضافه کنید.
1. ویژگی چرخش شکل را به زاویهٔ موردنظر تنظیم کنید.
1. ارائه را ذخیره کنید.

کد زیر نشان می‌دهد چطور یک شکل را به‌صورت ۵ درجه بچرخانید:

```java
import com.aspose.slides.*;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
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

![چرخش شکل](shape-rotation.png)

## **افزودن افکت‌های Bevel سه‌بعدی**

Aspose.Slides به شما امکان می‌دهد افکت‌های Bevel سه‌بعدی را با تنظیم ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/threedformat/) برای اشکال اعمال کنید.

برای افزودن افکت‌های Bevel سه‌بعدی به یک شکل، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس، به یک اسلاید مراجعه کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) را به اسلاید اضافه کنید.
1. ویژگی [ThreeDFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/threedformat/) شکل را پیکربندی کنید تا تنظیمات Bevel تعریف شوند.
1. ارائه را ذخیره کنید.

کد زیر نشان می‌دهد چطور افکت‌های Bevel سه‌بعدی را به یک شکل اعمال کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    // ارائه را به‌عنوان فایل PPTX ذخیره کنید.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![افکت Bevel سه‌بعدی](3D-bevel-effect.png)

## **افزودن افکت‌های چرخش سه‌بعدی**

Aspose.Slides به شما امکان می‌دهد افکت‌های چرخش سه‌بعدی را با تنظیم ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/threedformat/) برای اشکال اعمال کنید.

برای اعمال چرخش سه‌بعدی به یک شکل:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس، به یک اسلاید مراجعه کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) را به اسلاید اضافه کنید.
1. از متدهای [setCameraType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icamera/#setCameraType-int-) و [setLightType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilightrig/#setLightType-int-) برای تعریف چرخش سه‌بعدی استفاده کنید.
1. ارائه را ذخیره کنید.

کد زیر نشان می‌دهد چطور افکت‌های چرخش سه‌بعدی را به یک شکل اعمال کنید:

```java
import com.aspose.slides.*;

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

    // ارائه را به‌عنوان فایل PPTX ذخیره کنید.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![افکت چرخش سه‌بعدی](3D-rotation-effect.png)

## **کنترل رندر سیاه‑سفید برای اشکال**

متد [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) مشخص می‌کند که یک شکل منفرد هنگام مشاهده یا پردازش ارائه در حالت سیاه‑سفید چگونه رندر شود. این متد به‌تنهایی حالت سیاه‑سفید را فعال نمی‌کند و رنگ، خط یا سایر قالب‌بندی‌های شکل را در حالت رنگی عادی تغییر نمی‌دهد.

از مقدارهای موجود در کلاس [BlackWhiteMode](https://reference.aspose.com/slides/fa/java/com.aspose.slides/blackwhitemode/) برای انتخاب رفتار موردنظر استفاده کنید. برای مثال، `Automatic` اجازه می‌دهد برنامه رندر خود تصمیم بگیرد، `Gray` و `LightGray` رنگ‌های خاکستری استفاده می‌کنند، `BlackWhite` فقط سیاه و سفید، `Black` و `White` یک رنگ ثابت، `Color` رنگ معمولی را حفظ می‌کند و `Hidden` شکل را در حالت سیاه‑سفید حذف می‌کند. `NotDefined` به این معنی است که هیچ حالت سطح‑شکل اختصاص داده نشده است.

کد زیر یک شکل رنگی ایجاد می‌کند و آن را در حالت نمایش سیاه‑سفید به‌صورت خاکستری نشان می‌دهد:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // پر کردن نارنجی را در حالت رنگی نگه دارید، اما شکل را در حالت سیاه‑سفید با رنگ خاکستری رندر کنید.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

در حالت رنگی عادی، مستطیل پرگیری نارنجی خود را حفظ می‌کند. در جریان کاری نمایش سیاه‑سفید، به‌دلیل تنظیم حالت به `Gray`، از رنگ خاکستری استفاده می‌کند. این امکان به شما می‌دهد اسلاید رنگی کامل را داشته باشید و در عین حال ظاهر متفاوتی برای چاپ، پیش‌نمایش یا سایر جریان‌های کاری که تنظیمات سیاه‑سفید ارائه را رعایت می‌کنند، تعریف کنید.

## **بازنشانی قالب‌بندی**

کد زیر نشان می‌دهد چطور قالب‌بندی یک اسلاید را بازنشانی کنید و موقعیت، اندازه و قالب‌بندی تمام اشکال با جای‌نگهدارنده‌ها را در [LayoutSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/layoutslide/) به تنظیمات پیش‌فرض برگردانید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // هر شکلی را در اسلاید که یک placeholder در layout دارد، بازنشانی کنید.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سؤالات متداول**

**آیا قالب‌بندی شکل بر حجم نهایی فایل ارائه تأثیر می‌گذارد؟**

اثر اندکی دارد. تصاویر و رسانه‌های داخلی بیش‌ترین حجم فایل را اشغال می‌کنند، در حالی که پارامترهای شکل مانند رنگ‌ها، افکت‌ها و Gradientها به‌عنوان متادیتا ذخیره می‌شوند و تقریباً هیچ حجم اضافی اضافه نمی‌کنند.

**چگونه می‌توانم شکل‌هایی را که قالب‌بندی یکسانی دارند شناسایی کنم تا آنها را گروه‌بندی کنم؟**

ویژگی‌های کلیدی قالب‌بندی هر شکل—مانند پر کردن، خط و تنظیمات افکت—را مقایسه کنید. اگر تمام مقادیر متناظر مشابه باشند، سبک‌ها را یکسان درنظر گرفته و منطقی آن شکل‌ها را گروه‌بندی کنید؛ این کار مدیریت سبک‌ها را در آینده ساده می‌کند.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در فایلی جداگانه ذخیره کنم تا در ارائه‌های دیگر استفاده شود؟**

بله. شکل‌های نمونه با سبک‌های دلخواه را در یک اسلاید قالب یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد ارائهٔ جدید، قالب را باز کنید، شکل‌های استایل‌دار موردنیاز را کپی کنید و قالب‌بندی آنها را در جاهای موردنظر اعمال کنید.