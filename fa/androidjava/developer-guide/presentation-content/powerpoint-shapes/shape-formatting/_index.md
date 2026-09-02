---
title: قالب‌بندی اشکال PowerPoint در Android
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/androidjava/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- اثر طرح‌کشی
- خط شکل طرح‌کشی
- قالب‌بندی سبک اتصال
- پرکردن گرادیان
- پرکردن الگو
- پرکردن تصویر
- پرکردن بافت
- پر کردن رنگ ثابت
- شفافیت شکل
- رندر شکل سیاه‌سفید
- رندر شکل خاکستری
- چرخاندن شکل
- افکت برجستگی 3D
- افکت چرخش 3D
- بازنشانی قالب‌بندی
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "بیاموزید چگونه اشکال PowerPoint را در Android با استفاده از Aspose.Slides—پرکردن، خط و سبک‌های افکت را برای فایل‌های PPT، PPTX و ODP با دقت و کنترل کامل تنظیم کنید."
---
## **مقدمه**

در PowerPoint می‌توانید اشکال را به اسلایدها اضافه کنید. از آنجا که اشکال از خطوط تشکیل شده‌اند، می‌توانید آن‌ها را با تغییر یا اعمال افکت‌ها به خطوط حاشیه‌ای‌شان قالب‌بندی کنید. علاوه بر این، می‌توانید با تعیین تنظیماتی که نحوه پر شدن داخلی آن‌ها را کنترل می‌کند، اشکال را قالب‌بندی کنید.

![فرمت اشکال در پاورپوینت](format-shape-powerpoint.png)

Aspose.Slides برای Android از طریق Java رابط‌ها و متدهایی را فراهم می‌کند که به شما امکان می‌دهد اشکال را با همان گزینه‌های موجود در PowerPoint قالب‌بندی کنید.

## **قالب‌بندی خطوط**

با استفاده از Aspose.Slides می‌توانید یک سبک خط سفارشی برای یک شکل مشخص کنید. مراحل زیر روش کار را شرح می‌دهند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از شاخص، به یک اسلاید ارجاع پیدا کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. [سبک خط](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/linestyle/) شکل را تنظیم کنید.
1. ضخامت خط را تنظیم کنید.
1. [سبک خط شکسته](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/linedashstyle/) را تنظیم کنید.
1. رنگ خط برای شکل را تنظیم کنید.
1. ارائه اصلاح شده را به عنوان فایل PPTX ذخیره کنید.

کد زیر نشان می‌دهد چگونه یک `AutoShape` مستطیل را قالب‌بندی کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // اولین اسلاید را دریافت کنید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // یک شکل خودکار از نوع Rectangle اضافه کنید.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // پر کردن شکل مستطیل را حذف کنید تا فقط خطوط آن قابل مشاهده باشد.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // قالب‌بندی خطوط مستطیل را اعمال کنید.
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

![خطوط قالب‌بندی شده در ارائه](formatted-lines.png)

## **اعمال افکت‌های Sketch به خطوط شکل**

یک افکت Sketch ظاهر خط شکل را شبیه به رسم دستی می‌کند. از [IShape.getLineFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/) برای دسترسی به تنظیمات خط، [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilineformat/) برای دسترسی به تنظیمات sketch و [ISketchFormat.setSketchType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isketchformat/) برای انتخاب مقدار از enum [LineSketchType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/linesketchtype/) استفاده کنید.

کد Java زیر نشان می‌دهد چگونه افکت [LineSketchType.Curved](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/linesketchtype/) را اعمال، مقدار اختصاص داده‌شده به‌صورت صریح را بخوانید و با [LineSketchType.None](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/linesketchtype/) افکت را حذف کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // دسترسی به قالب خط شکل و قالب اسکیچ آن.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // اعمال یک افکت اسکیچ.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // خواندن افکت اسکیچ اختصاص داده شده به‌صورت مستقیم به شکل.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // حذف افکت اسکیچ.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

مقداری که توسط [ISketchFormat.getSketchType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isketchformat/) برگردانده می‌شود، تنظیمی است که مستقیماً به شکل اختصاص یافته است. اگر قالب‌بندی خط می‌تواند از یک تم، اسلاید مادر یا اسلاید چیدمان به ارث برسد، از [ILineFormat.getEffective](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilineformat/) استفاده کنید، به [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilineformateffectivedata/) دسترسی پیدا کنید و [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isketchformateffectivedata/) را بخوانید. مقدار مؤثر، قالب‌بندی‌ای را نشان می‌دهد که پس از حل ارث‌بری واقعی اعمال می‌شود:

```java
import com.aspose.slides.*;

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

## **قالب‌بندی سبک‌های Join**

سه گزینهٔ نوع Join عبارتند از:

* Round
* Miter
* Bevel

به‌طور پیش‌فرض، وقتی PowerPoint دو خط را در یک زاویه (مثلاً در گوشهٔ یک شکل) به هم می‌پیوندد، از تنظیم **Round** استفاده می‌کند. اما اگر شما شکلی با زوایای تیز می‌کشید، ممکن است گزینهٔ **Miter** را ترجیح دهید.

![سبک Join در ارائه](join-style-powerpoint.png)

کد Java زیر نشان می‌دهد چگونه three مستطیل (همان‌طور که در تصویر بالا می‌بینید) با استفاده از تنظیمات Join نوع Miter، Bevel و Round ساخته شدند:

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // اولین اسلاید را دریافت کنید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // سه شکل خودکار از نوع Rectangle اضافه کنید.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // رنگ پر کردن هر شکل مستطیل را تنظیم کنید.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // ضخامت خط را تنظیم کنید.
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

    // فایل PPTX را بر روی دیسک ذخیره کنید.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **پر کردن Gradient**

در PowerPoint، Gradient Fill یک گزینهٔ قالب‌بندی است که به شما اجازه می‌دهد ترکیبی پیوسته از رنگ‌ها را بر روی یک شکل اعمال کنید. به‌عنوان مثال، می‌توانید دو یا چند رنگ را به‌گونه‌ای اعمال کنید که یکی به‌تدریج به دیگری محو شود.

نحوهٔ اعمال Gradient Fill به یک شکل با استفاده از Aspose.Slides:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از شاخص، به یک اسلاید ارجاع پیدا کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/filltype/) شکل را به `Gradient` تنظیم کنید.
1. دو رنگ دلخواه خود را با موقعیت‌های تعریف‌شده با استفاده از متدهای `add` از مجموعهٔ gradient stopهایی که توسط رابط [IGradientFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/igradientformat/) در دسترس است، اضافه کنید.
1. ارائه اصلاح شده را به‌عنوان فایل PPTX ذخیره کنید.

کد Java زیر نشان می‌دهد چگونه یک افکت Gradient Fill به یک بیضی اعمال می‌شود:

```java
import com.aspose.slides.*;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // اولین اسلاید را دریافت کنید.
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

![بیضی با Gradient Fill](gradient-fill.png)

## **پر کردن Pattern**

در PowerPoint، Pattern Fill یک گزینهٔ قالب‌بندی است که به شما اجازه می‌دهد یک الگوی دو‌رنگ—مانند نقطه‌ها، خط‌ها، خط‌کشی یا جعبه‌ها—را به یک شکل اعمال کنید. می‌توانید رنگ‌های سفارشی برای پیش‌زمینه و پس‌زمینهٔ الگو انتخاب کنید.

Aspose.Slides بیش از ۴۵ سبک پیش‌تعریف‌شدهٔ الگو را فراهم می‌کند که می‌توانید آن‌ها را به اشکال اعمال کنید تا جذابیت بصری ارائه‌تان افزایش یابد. حتی پس از انتخاب یک الگوی پیش‌تعریف‌شده، می‌توانید رنگ‌های دقیق مورد استفاده را مشخص کنید.

نحوهٔ اعمال Pattern Fill به یک شکل با استفاده از Aspose.Slides:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از شاخص، به یک اسلاید ارجاع پیدا کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/filltype/) شکل را به `Pattern` تنظیم کنید.
1. یک سبک الگو را از گزینه‌های پیش‌تعریف‌شده انتخاب کنید.
1. [Background Color](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/patternformat/#getBackColor--) الگو را تنظیم کنید.
1. [Foreground Color](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/patternformat/#getForeColor--) الگو را تنظیم کنید.
1. ارائه اصلاح شده را به‌عنوان فایل PPTX ذخیره کنید.

کد Java زیر نشان می‌دهد چگونه Pattern Fill به یک مستطیل اعمال می‌شود:

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // اولین اسلاید را دریافت کنید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // یک شکل خودکار از نوع Rectangle اضافه کنید.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // نوع پر کردن را به Pattern تنظیم کنید.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // سبک الگو را تنظیم کنید.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // رنگ پس‌زمینه و پیش‌زمینهٔ الگو را تنظیم کنید.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // فایل PPTX را بر روی دیسک ذخیره کنید.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![مستطیل با Pattern Fill](pattern-fill.png)

## **پر کردن Picture**

در PowerPoint، Picture Fill یک گزینهٔ قالب‌بندی است که به شما اجازه می‌دهد یک تصویر را داخل یک شکل قرار دهید—به‌طور مؤثری تصویر را به‌عنوان پس‌زمینهٔ شکل استفاده می‌کند.

نحوهٔ استفاده از Aspose.Slides برای اعمال Picture Fill به یک شکل:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از شاخص، به یک اسلاید ارجاع پیدا کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/filltype/) شکل را به `Picture` تنظیم کنید.
1. حالت پر کردن تصویر را به `Tile` (یا حالت دلخواه دیگر) تنظیم کنید.
1. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) از تصویری که می‌خواهید استفاده کنید، بسازید.
1. تصویر را به متد `ISlidesPicture.setImage` پاس بدهید.
1. ارائه اصلاح شده را به‌عنوان فایل PPTX ذخیره کنید.

فرض کنید فایلی به نام "lotus.png" داریم که تصویر زیر را نشان می‌دهد:

![تصویر لوتوس](lotus.png)

کد Java زیر نشان می‌دهد چگونه یک شکل را با تصویر پر کنید:

```java
import com.aspose.slides.*;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // اولین اسلاید را دریافت کنید.
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

    // فایل PPTX را بر روی دیسک ذخیره کنید.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![شکل با Picture Fill](picture-fill.png)

### **Tile Picture As Texture**

اگر می‌خواهید یک تصویر تک‌تکه را به‌عنوان بافت تنظیم کنید و رفتار کاشی‌گذاری را سفارشی کنید، می‌توانید از متدهای زیر رابط [IPictureFillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/picturefillformat/) استفاده کنید:

- [setPictureFillMode](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): حالت پر کردن تصویر را تنظیم می‌کند—`Tile` یا `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): تراز کاشی‌ها درون شکل را تعیین می‌کند.
- [setTileFlip](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): تعیین می‌کند آیا کاشی به‌صورت افقی، عمودی یا هر دو معکوس شود.
- [setTileOffsetX](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): افست افقی کاشی (به نقاط) نسبت به مبدأ شکل را تنظیم می‌کند.
- [setTileOffsetY](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): افست عمودی کاشی (به نقاط) نسبت به مبدأ شکل را تنظیم می‌کند.
- [setTileScaleX](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): مقیاس افقی کاشی را به‌صورت درصد تعریف می‌کند.
- [setTileScaleY](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): مقیاس عمودی کاشی را به‌صورت درصد تعریف می‌کند.

نمونه کد زیر نشان می‌دهد چگونه یک شکل مستطیل با پر کردن تصویر کاشی‌دار اضافه کنید و گزینه‌های کاشی را پیکربندی کنید:

```java
import com.aspose.slides.*;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // اولین اسلاید را دریافت کنید.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // یک شکل خودکار مستطیل اضافه کنید.
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

    // فایل PPTX را بر روی دیسک ذخیره کنید.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![گزینه‌های کاشی](tile-options.png)

## **پر کردن Solid Color**

در PowerPoint، Solid Color Fill یک گزینهٔ قالب‌بندی است که یک شکل را با یک رنگ یکنواخت پر می‌کند. این رنگ پس‌زمینه ساده بدون هیچ گرادیان، بافت یا الگو‌ای اعمال می‌شود.

برای اعمال Solid Color Fill به یک شکل با استفاده از Aspose.Slides، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از شاخص، به یک اسلاید ارجاع پیدا کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/filltype/) شکل را به `Solid` تنظیم کنید.
1. رنگ پر شدن دلخواه خود را به شکل اختصاص دهید.
1. ارائه اصلاح شده را به‌عنوان فایل PPTX ذخیره کنید.

کد Java زیر نشان می‌دهد چگونه یک Solid Color Fill به یک مستطیل در یک اسلاید PowerPoint اعمال می‌شود:

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // اولین اسلاید را دریافت کنید.
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

![شکل با Solid Color Fill](solid-color-fill.png)

## **تنظیم شفافیت**

در PowerPoint، هنگامی که پر کردن Solid Color، Gradient، Picture یا Texture را به اشکال اعمال می‌کنید، می‌توانید سطح شفافیت را تنظیم کنید تا میزان کدری پر کردن را کنترل کنید. مقدار شفافیت بالاتر، شکل را شفاف‌تر می‌کند و زمینه یا اشیای زیرین را به‌صورت جزئی قابل مشاهده می‌سازد.

Aspose.Slides به شما امکان می‌دهد سطح شفافیت را با تنظیم مقدار آلفا در رنگ استفاده‌شده برای پر کردن تنظیم کنید. نحوه انجام این کار:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از شاخص، به یک اسلاید ارجاع پیدا کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/filltype/) را به `Solid` تنظیم کنید.
1. از `Color` برای تعریف رنگی با شفافیت استفاده کنید (مولفهٔ `alpha` شفافیت را کنترل می‌کند).
1. ارائه را ذخیره کنید.

کد Java زیر نشان می‌دهد چگونه یک رنگ پر شفاف به یک مستطیل اعمال کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // اولین اسلاید را دریافت کنید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // یک شکل خودکار مستطیل با پر کردن ثابت اضافه کنید.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // یک شکل خودکار مستطیل شفاف روی شکل ثابت اضافه کنید.
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

Aspose.Slides به شما اجازه می‌دهد اشکال را در ارائه‌های PowerPoint چرخاند. این می‌تواند هنگام موقعیت‌یابی عناصر بصری با نیازهای خاص هم‌ترازی یا طراحی مفید باشد.

برای چرخاندن یک شکل روی اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از شاخص، به یک اسلاید ارجاع پیدا کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. خاصیت چرخش شکل را به زاویهٔ موردنظر تنظیم کنید.
1. ارائه را ذخیره کنید.

کد Java زیر نشان می‌دهد چگونه یک شکل را به اندازهٔ 5 درجه بچرخانید:

```java
import com.aspose.slides.*;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
Presentation presentation = new Presentation();
try {
    // اولین اسلاید را دریافت کنید.
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

## **افکت‌های 3D Bevel**

Aspose.Slides به شما امکان می‌دهد افکت‌های 3D Bevel را به اشکال اعمال کنید با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/threedformat/) آن‌ها.

برای افزودن افکت‌های 3D Bevel به یک شکل، مراحل زیر را دنبال کنید:

1. نمونه‌ای از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از شاخص، به یک اسلاید ارجاع پیدا کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی [ThreeDFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/threedformat/) شکل را پیکربندی کنید تا تنظیمات bevel را تعریف کنید.
1. ارائه را ذخیره کنید.

کد Java زیر نشان می‌دهد چگونه افکت‌های 3D Bevel را به یک شکل اعمال کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

// یک نمونه از کلاس Presentation را ایجاد کنید.
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

![افکت 3D Bevel](3D-bevel-effect.png)

## **افکت‌های چرخش 3D**

Aspose.Slides به شما امکان می‌دهد افکت‌های چرخش 3D را به اشکال اعمال کنید با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/threedformat/) آن‌ها.

برای اعمال چرخش 3D به یک شکل:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از شاخص، به یک اسلاید ارجاع پیدا کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. از متدهای [setCameraType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icamera/#setCameraType-int-) و [setLightType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) برای تعریف چرخش 3D استفاده کنید.
1. ارائه را ذخیره کنید.

کد Java زیر نشان می‌دهد چگونه افکت‌های چرخش 3D را به یک شکل اعمال کنید:

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

    // ارائه را به عنوان فایل PPTX ذخیره کنید.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![افکت چرخش 3D](3D-rotation-effect.png)

## **کنترل رندر سیاه‑سفید برای اشکال**

متد [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) مشخص می‌کند که یک شکل به‌صورت فردی هنگام مشاهده یا پردازش ارائه در حالت سیاه‑سفید چگونه رندر شود. این متد به‌تنهایی حالت نمایش سیاه‑سفید را فعال نمی‌کند و رنگ پر، خط یا دیگر قالب‌بندی‌های شکل را در حالت رنگی عادی تغییر نمی‌دهد.

از مقدارهای موجود در کلاس [BlackWhiteMode](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/blackwhitemode/) برای انتخاب رفتار موردنظر استفاده کنید. به‌عنوان مثال، `Automatic` اجازه می‌دهد برنامه رندرینگ تبدیل را انتخاب کند، `Gray` و `LightGray` از رنگ خاکستری استفاده می‌کنند، `BlackWhite` فقط سیاه و سفید، `Black` و `White` یک رنگ ثابت اعمال می‌کنند، `Color` رنگ عادی را حفظ می‌کند و `Hidden` شکل را در حالت سیاه‑سفید حذف می‌کند. `NotDefined` به این معناست که هیچ حالت سطح شکلی تعیین نشده است.

کد Java زیر یک شکل رنگی ایجاد می‌کند و آن را طوری تنظیم می‌کند که در حالت نمایش سیاه‑سفید به رنگ خاکستری ظاهر شود:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    // پر کردن نارنجی را در حالت رنگی نگه دارید، اما شکل را در حالت سیاه‑سفید با رنگ خاکستری رندر کنید.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

در حالت رنگی عادی، مستطیل پر شدن نارنجی خود را حفظ می‌کند. در یک جریان کاری نمایش سیاه‑سفید، به‌دلیل تنظیم حالت به `Gray`، از رنگ خاکستری استفاده می‌کند. این به شما امکان می‌دهد اسلاید کامل‑رنگ را حفظ کنید در حالی که ظاهر متمایزی برای چاپ، پیش‌نمایش یا سایر جریان‌های کاری که تنظیمات نمایش سیاه‑سفید ارائه را رعایت می‌کنند، تعریف کنید.

## **بازنشانی قالب‌بندی**

کد Java زیر نشان می‌دهد چگونه قالب‌بندی یک اسلاید را بازنشانی کنید و موقعیت، اندازه و قالب‌بندی تمام اشکال با جای‌گیرها در [LayoutSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/layoutslide/) را به تنظیمات پیش‌فرض برگردانید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // بازنشانی هر شکل در اسلایدی که جای‌گیر در طرح‌بندی دارد.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سؤالات متداول**

**آیا قالب‌بندی شکل‌ها بر حجم نهایی فایل ارائه تاثیر می‌گذارد؟**

به‌صورت خردی. تصاویر و رسانه‌های توکار بخش عمدهٔ فضای فایل را شامل می‌شوند، در حالی که پارامترهای شکل مانند رنگ‌ها، افکت‌ها و گرادیان‌ها به‌عنوان متاداده ذخیره می‌شوند و تقریباً هیچ حجم اضافه‌ای ایجاد نمی‌کنند.

**چگونه می‌توانم اشکالی را در یک اسلاید که قالب‌بندی یکسانی دارند شناسایی کنم تا بتوانم آن‌ها را گروه‌بندی کنم؟**

ویژگی‌های کلیدی قالب‌بندی هر شکل—پر، خط و تنظیمات افکت—را مقایسه کنید. اگر تمام مقادیر مربوطه مطابقت داشته باشند، سبک آن‌ها را یکسان در نظر بگیرید و منطقی آن شکل‌ها را گروه‌بندی کنید؛ این کار مدیریت سبک‌ها را در مراحل بعدی ساده‌تر می‌کند.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در فایلی جداگانه ذخیره کنم تا در ارائه‌های دیگر دوباره استفاده کنم؟**

بله. اشکال نمونه با سبک‌های موردنیاز را در یک دک اسلاید قالب یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد یک ارائهٔ جدید، قالب را باز کنید، اشکال استایل‌دار موردنظر را کلون کنید و قالب‌بندی آن‌ها را در مکان‌های لازم مجدداً اعمال کنید.