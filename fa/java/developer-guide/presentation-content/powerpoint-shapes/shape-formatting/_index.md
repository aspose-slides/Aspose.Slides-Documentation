---
title: قالب‌بندی اشکال PowerPoint در Java
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/java/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- افکت اسکچ
- خط اسکچ‌شکل
- قالب‌بندی سبک اتصال
- پرکردن گرادیان
- پرکردن الگو
- پرکردن تصویر
- پرکردن بافت
- پرکردن رنگ ثابت
- شفافیت شکل
- رندرینگ سیاه‑وسفید شکل
- رندرینگ خاکستری شکل
- چرخش شکل
- افکت Bevel سه‌بعدی
- افکت چرخش سه‌بعدی
- بازنشانی قالب‌بندی
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال PowerPoint را در Java با استفاده از Aspose.Slides قالب‌بندی کنید—پر کردن، خطوط و سبک‌های افکت را برای فایل‌های PPT، PPTX و ODP با دقت و کنترل کامل تنظیم کنید."
---
## **مقدمه**

در PowerPoint می‌توانید اشکال را به اسلایدها اضافه کنید. از آنجایی که اشکال از خطوط تشکیل شده‌اند، می‌توانید آنها را با تغییر یا اعمال افکت‌ها بر روی خطوط کانتور قالب‌بندی کنید. علاوه بر این، می‌توانید با تعیین تنظیماتی که نحوه پر شدن داخل اشکال را کنترل می‌کند، اشکال را قالب‌بندی کنید.

![قالب‌گذاری‌شکل‑PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Java رابط‌ها و متدهایی را فراهم می‌کند که به شما امکان می‌دهد اشکال را با استفاده از همان گزینه‌های موجود در PowerPoint قالب‌بندی کنید.

## **قالب‌گذاری خطوط**

با استفاده از Aspose.Slides می‌توانید یک سبک خط سفارشی برای یک شکل تعیین کنید. مراحل زیر روند را نشان می‌دهند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلایدی با ایندکس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. سبک خط ([line style](https://reference.aspose.com/slides/java/com.aspose.slides/linestyle/)) شکل را تنظیم کنید.
1. عرض خط را تنظیم کنید.
1. سبک dash ([dash style](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/)) خط را تنظیم کنید.
1. رنگ خط شکل را تنظیم کنید.
1. ارائهٔ تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

کد زیر نحوه قالب‌گذاری یک `AutoShape` مستطیلی را نشان می‌دهد:

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // یک شکل خودکار از نوع Rectangle اضافه کنید.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // رنگ پر کردن شکل مستطیل را تنظیم کنید.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // قالب‌بندی خطوط مستطیل را اعمال کنید.
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

![خطوط قالب‌بندی شده در ارائه](formatted-lines.png)

## **اعمال اثرات Sketch به خطوط شکل**

یک اثر sketch باعث می‌شود خط شکل شبیه به کشیده دست باشد. از [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) برای دسترسی به تنظیمات خط، از [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/) برای دسترسی به تنظیمات sketch، و از [ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/) برای انتخاب مقدار از enumeration [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) استفاده کنید.

کد جاوا زیر نشان می‌دهد چگونه یک اثر [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) را اعمال کنید، مقدار اختصاص‑یافته صریح را بخوانید، و اثر را با [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) حذف کنید:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // دسترسی به قالب‌بندی خط شکل و قالب اسکچ آن.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // اعمال یک افکت اسکچ.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // خواندن افکت اسکچ که مستقیماً به شکل اختصاص داده شده است.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // حذف افکت اسکچ.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

مقداری که توسط [ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/) بازگردانده می‌شود، نمایانگر تنظیمی است که مستقیماً به شکل اختصاص داده شده است. اگر قالب‌بندی خط می‌تواند از یک تم، اسلاید اصلی یا اسلاید چیدمان به ارث برسد، از [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/)، دسترسی به [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/)، و خواندن [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/) استفاده کنید. مقدار مؤثر قالب‌بندی را که پس از حل ارث‌بری اعمال می‌شود، نشان می‌دهد:

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

## **قالب‌گذاری سبک‌های اتصال**

در اینجا سه گزینهٔ نوع اتصال وجود دارد:

* گرد
* میتر
* لبه‌دار

به‌طور پیش‌فرض، وقتی PowerPoint دو خط را در زاویه‌ای (مانند گوشهٔ شکل) به هم متصل می‌کند، از تنظیم **Round** استفاده می‌کند. اما اگر شکل با زوایای تیز ترسیم می‌کنید، ممکن است گزینهٔ **Miter** را ترجیح دهید.

![سبک اتصال در ارائه](join-style-powerpoint.png)

کد جاوا زیر نشان می‌دهد چگونه سه مستطیل (همان‌طور که در تصویر بالا نشان داده شده) با استفاده از تنظیمات نوع اتصال Miter، Bevel و Round ایجاد شدند:

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // سه شکل خودکار از نوع Rectangle اضافه کنید.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // رنگ پر کردن هر شکل مستطیلی را تنظیم کنید.
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

## **پرکردن گرادیان**

در PowerPoint، Gradient Fill یک گزینهٔ قالب‌بندی است که به شما امکان می‌دهد ترکیبی مداوم از رنگ‌ها را بر روی یک شکل اعمال کنید. به‌عنوان مثال، می‌توانید دو یا چند رنگ را به‌طوری اعمال کنید که یکی به‌تدریج به دیگری محو شود.

در اینجا نحوهٔ اعمال پرکردن گرادیان به یک شکل با استفاده از Aspose.Slides آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلایدی با ایندکس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. نوع پر کردن شکل ([FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/)) را به `Gradient` تنظیم کنید.
1. دو رنگ دلخواه خود را با موقعیت‌های تعریف‌شده با استفاده از متدهای `add` مجموعهٔ توقف‌گرادیان که توسط رابط [IGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/) افشا می‌شود، اضافه کنید.
1. ارائهٔ تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

کد جاوا زیر نشان می‌دهد چگونه یک افکت پرکردن گرادیان به یک بیضی اعمال می‌شود:

```java
import com.aspose.slides.*;

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

    // دو توقف‌گرادیان اضافه کنید.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // فایل PPTX را روی دیسک ذخیره کنید.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![بیضی با پرکردن گرادیان](gradient-fill.png)

اگر یک گرادیان در تصویر خروجی متفاوت از آنچه در PowerPoint دیده می‌شود، ظاهر شود، می‌توانید به [Choose a Gradient Rendering Style](/slides/fa/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) مراجعه کنید. می‌توانید یک سبک رندرینگ را بدون تغییر پرکردن گرادیان ذخیره‌شده در ارائه انتخاب کنید.

## **پرکردن الگو**

در PowerPoint، Pattern Fill یک گزینهٔ قالب‌بندی است که به شما اجازه می‌دهد یک طرح دو‌رنگ—مانند‌نقطه‌ها، نوارها، خطوط متقاطع یا شطرنجی—را بر روی یک شکل اعمال کنید. می‌توانید رنگ‌های پیش‌زمینه و پس‌زمینه طرح را به‌صورت دلخواه انتخاب کنید.

Aspose.Slides بیش از ۴۵ سبک پیش‌تعریف‌شدهٔ الگو را ارائه می‌دهد که می‌توانید بر روی اشکال اعمال کنید تا جذابیت بصری ارائه‌هایتان را افزایش دهید. حتی پس از انتخاب یک الگوی پیش‌تعریف‌شده، می‌توانید رنگ‌های دقیق مورد استفاده آن را مشخص کنید.

در اینجا نحوهٔ اعمال پرکردن الگو به یک شکل با استفاده از Aspose.Slides آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلایدی با ایندکس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. نوع پر کردن شکل ([FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/)) را به `Pattern` تنظیم کنید.
1. یک سبک الگو از گزینه‌های پیش‌تعریف‌شده انتخاب کنید.
1. رنگ پس‌زمینهٔ الگو ([Background Color](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getBackColor--)) را تنظیم کنید.
1. رنگ پیش‌زمینهٔ الگو ([Foreground Color](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getForeColor--)) را تنظیم کنید.
1. ارائهٔ تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

کد جاوا زیر نشان می‌دهد چگونه پرکردن الگو به یک مستطیل اعمال می‌شود:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    // رنگ‌های پس‌زمینه و پیش‌زمینه الگو را تنظیم کنید.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // فایل PPTX را روی دیسک ذخیره کنید.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![مستطیل با پرکردن الگو](pattern-fill.png)

## **پرکردن تصویر**

در PowerPoint، Picture Fill یک گزینهٔ قالب‌بندی است که به شما امکان می‌دهد یک تصویر را داخل یک شکل قرار دهید—در واقع تصویر را به‌عنوان پس‌زمینهٔ شکل استفاده کنید.

در اینجا نحوهٔ استفاده از Aspose.Slides برای اعمال پرکردن تصویر به یک شکل آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلایدی با ایندکس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. نوع پر کردن شکل ([FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/)) را به `Picture` تنظیم کنید.
1. حالت پرکردن تصویر را به `Tile` (یا حالت دلخواه دیگر) تنظیم کنید.
1. یک شیء [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) از تصویری که می‌خواهید استفاده کنید، ایجاد کنید.
1. تصویر را به متد `ISlidesPicture.setImage` پاس دهید.
1. ارائهٔ تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

فرض کنید فایلی به نام «lotus.png» داریم که تصویر زیر را دارد:

![تصویر لوتوس](lotus.png)

کد جاوا زیر نشان می‌دهد چگونه یک شکل را با تصویر پر کنید:

```java
import com.aspose.slides.*;

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

![شکل با پرکردن تصویر](picture-fill.png)

### **Tile Picture As Texture**

اگر می‌خواهید یک تصویر تقسیم‌شده را به‌عنوان بافت تنظیم کنید و رفتار تقسیم را سفارشی کنید، می‌توانید از متدهای زیر رابط [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) استفاده کنید:

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): حالت پرکردن تصویر را تنظیم می‌کند—یا `Tile` یا `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): تراز کاشی‌ها داخل شکل را مشخص می‌کند.
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): کنترل می‌کند که کاشی به‌صورت افقی، عمودی یا هر دو معکوس شود.
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): افست افقی کاشی (به نقطه) را از مبدأ شکل تنظیم می‌کند.
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): افست عمودی کاشی (به نقطه) را از مبدأ شکل تنظیم می‌کند.
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): مقیاس افقی کاشی را به‌صورت درصد تعریف می‌کند.
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): مقیاس عمودی کاشی را به‌صورت درصد تعریف می‌کند.

نمونه کد زیر نشان می‌دهد چگونه یک شکل مستطیلی با پرکردن تصویر کاشی‌شده اضافه کنید و گزینه‌های کاشی را پیکربندی کنید:

```java
import com.aspose.slides.*;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // یک شکل خودکار مستطیلی اضافه کنید.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // نوع پرکردن شکل را به Picture تنظیم کنید.
    shape.getFillFormat().setFillType(FillType.Picture);

    // تصویر را بارگذاری کنید و به منابع ارائه اضافه کنید.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // تصویر را به شکل اختصاص دهید.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // حالت پرکردن تصویر و خصوصیات کاشی‌گذاری را پیکربندی کنید.
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

## **پرکردن رنگ ثابت**

در PowerPoint، Solid Color Fill یک گزینهٔ قالب‌بندی است که یک شکل را با یک رنگ یک‌دست و یکنواخت پر می‌کند. این رنگ پس‌زمینه ساده بدون هیچ‌گونه گرادیان، بافت یا الگوی اعمال می‌شود.

برای اعمال پرکردن رنگ ثابت به یک شکل با استفاده از Aspose.Slides، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلایدی با ایندکس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. نوع پر کردن شکل ([FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/)) را به `Solid` تنظیم کنید.
1. رنگ پر کردن دلخواه خود را به شکل اختصاص دهید.
1. ارائهٔ تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

کد جاوا زیر نشان می‌دهد چگونه یک مستطیل در یک اسلاید PowerPoint با پرکردن رنگ ثابت قالب‌بندی شود:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    // فایل PPTX را روی دیسک ذخیره کنید.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![شکل با پرکردن رنگ ثابت](solid-color-fill.png)

## **تنظیم شفافیت**

در PowerPoint، زمانی که یک رنگ ثابت، گرادیان، تصویر یا بافت را به اشکال اعمال می‌کنید، می‌توانید سطح شفافیت را نیز تنظیم کنید تا میزان شفافیت پر کردن کنترل شود. مقدار شفافیت بالاتر باعث می‌شود شکل بیشتر شفاف باشد و پس‌زمینه یا اشیای زیرین به‌جزئی قابل مشاهده باشند.

Aspose.Slides به شما اجازه می‌دهد سطح شفافیت را با تنظیم مقدار آلفای رنگ استفاده‌شده برای پر کردن تنظیم کنید. نحوه انجام این کار به شرح زیر است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلایدی با ایندکس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. نوع پر کردن ([FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/)) را به `Solid` تنظیم کنید.
1. از `Color` برای تعریف رنگی با شفافیت (جزء `alpha` شفافیت را کنترل می‌کند) استفاده کنید.
1. ارائه را ذخیره کنید.

کد جاوا زیر نشان می‌دهد چگونه یک رنگ پر کردن شفاف به یک مستطیل اعمال شود:

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // یک شکل خودکار مستطیل ثابت اضافه کنید.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // یک شکل خودکار مستطیل شفاف روی شکل ثابت اضافه کنید.
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

Aspose.Slides به شما امکان می‌دهد اشکال را در ارائه‌های PowerPoint بچرخانید. این می‌تواند هنگام قرار دادن عناصر بصری با نیازهای خاص ترازبندی یا طراحی مفید باشد.

برای چرخاندن یک شکل در اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلایدی با ایندکس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی چرخش شکل را به زاویهٔ دلخواه تنظیم کنید.
1. ارائه را ذخیره کنید.

کد جاوا زیر نشان می‌دهد چگونه یک شکل را به‌طور ۵ درجه بچرخانید:

```java
import com.aspose.slides.*;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // اسلاید اول را دریافت کنید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // یک شکل خودکار از نوع Rectangle اضافه کنید.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // شکل را به ‌۵ درجه بچرخانید.
    shape.setRotation(5);

    // فایل PPTX را روی دیسک ذخیره کنید.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![چرخش شکل](shape-rotation.png)

## **اضافه کردن افکت‌های Bevel 3‑بعدی**

Aspose.Slides به شما اجازه می‌دهد افکت‌های Bevel 3‑بعدی را به اشکال اعمال کنید با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/).

برای افزودن افکت‌های Bevel 3‑بعدی به یک شکل، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلایدی با ایندکس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) شکل را برای تعریف تنظیمات bevel پیکربندی کنید.
1. ارائه را ذخیره کنید.

کد جاوا زیر نشان می‌دهد چگونه افکت‌های Bevel 3‑بعدی را به یک شکل اعمال کنید:

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

    // ارائه را به عنوان فایل PPTX ذخیره کنید.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![افکت Bevel 3‑بعدی](3D-bevel-effect.png)

## **اضافه کردن افکت‌های چرخش 3‑بعدی**

Aspose.Slides به شما اجازه می‌دهد افکت‌های چرخش 3‑بعدی را به اشکال اعمال کنید با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/).

برای اعمال چرخش 3‑بعدی به یک شکل:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلایدی با ایندکس آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) به اسلید اضافه کنید.
1. با استفاده از [setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) و [setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-) چرخش 3‑بعدی را تعریف کنید.
1. ارائه را ذخیره کنید.

کد جاوا زیر نشان می‌دهد چگونه افکت‌های چرخش 3‑بعدی را به یک شکل اعمال کنید:

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

![افکت چرخش 3‑بعدی](3D-rotation-effect.png)

## **کنترل رندرینگ سیاه‑وسفید برای اشکال**

متد [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) تعیین می‌کند که یک شکل به‌صورت منفرد چگونه هنگام مشاهده یا پردازش ارائه در حالت سیاه‑وسفید رندر شود. این متد به‌تنهایی حالت سیاه‑وسفید را فعال نمی‌کند و رنگ پر، خط یا سایر قالب‌بندی‌های شکل را در حالت رنگ عادی تغییر نمی‌دهد.

از مقداری از کلاس [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) برای انتخاب رفتار موردنظر استفاده کنید. برای مثال، `Automatic` اجازه می‌دهد برنامهٔ رندرینگ تبدیل را انتخاب کند، `Gray` و `LightGray` از رنگ خاکستری استفاده می‌کنند، `BlackWhite` فقط سیاه و سفید را استفاده می‌کند، `Black` و `White` یک رنگ واحد را تحمیل می‌کنند، `Color` رنگ عادی را حفظ می‌کند، و `Hidden` شکل را در حالت سیاه‑وسفید حذف می‌کند. `NotDefined` به این معنی است که هیچ حالت سطح‑شکلی تعیین نشده است.

کد جاوا زیر یک شکل رنگی ایجاد می‌کند و آن را در حالت نمایش سیاه‑وسفید خاکستری نشان می‌دهد:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // در حالت رنگ پر شدن نارنجی را حفظ کنید، اما شکل را در حالت سیاه‑وسفید با رنگ خاکستری رندر کنید.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

در حالت رنگ عادی، مستطیل رنگ پرشدن نارنجی خود را حفظ می‌کند. در یک جریان کاری نمایش سیاه‑وسفید، به‌دلیل تنظیم حالت به `Gray`، رنگ خاکستری استفاده می‌شود. این امکان را می‌دهد تا اسلاید رنگی کامل را حفظ کنید و ظاهری متفاوت برای چاپ، پیش‌نمایش یا سایر جریان‌های کاری که به تنظیمات نمایش سیاه‑وسفید ارائه احترام می‌گذارند، تعریف کنید.

## **بازنشانی قالب‌بندی**

کد جاوا زیر نشان می‌دهد چگونه قالب‌بندی یک اسلاید را بازنشانی کنید و موقعیت، اندازه و قالب‌بندی تمام اشکال با نگهدارنده‌ها در [LayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslide/) را به تنظیمات پیش‌فرض برگردانید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // بازنشانی هر شکلی در اسلاید که در چیدمان یک نگهدارنده دارد.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**آیا قالب‌بندی شکل بر اندازهٔ نهایی فایل ارائه تأثیر می‌گذارد؟**

فقط به‌صورت حداقلی. تصاویر و رسانه‌های تعبیه‌شده بیشتر فضا را اشغال می‌کنند، در حالی که پارامترهای شکل مانند رنگ‌ها، افکت‌ها و گرادیان‌ها به‌عنوان فراداده ذخیره می‌شوند و تقریباً هیچ حجم اضافه‌ای ایجاد نمی‌کنند.

**چگونه می‌توانم اشکالی را در یک اسلاید که قالب‌بندی یکسانی دارند شناسایی کنم تا بتوانم آنها را گروه‌بندی کنم؟**

ویژگی‌های کلیدی قالب‌بندی هر شکل—پر کردن، خط و تنظیمات افکت—را مقایسه کنید. اگر همه مقادیر متناظر مطابقت داشته باشند، سبک‌ها را یکسان درنظر بگیرید و آن اشکال را به‌صورت منطقی گروه‌بندی کنید که مدیریت سبک‌ها را در مراحل بعدی ساده‌تر می‌کند.

**آیا می‌توانم یک مجموعهٔ سبک سفارشی شکل را در یک فایل جداگانه ذخیره کنم تا در ارائه‌های دیگر استفاده کنم؟**

بله. اشکال نمونه با سبک‌های دلخواه را در یک اسلاید قالب یا فایل قالب `.POTX` ذخیره کنید. هنگام ایجاد یک ارائهٔ جدید، قالب را باز کنید، اشکال سبک‌دار مورد نیاز را کلون کنید و قالب‌بندی آنها را در هر جایی که لازم است دوباره اعمال کنید.