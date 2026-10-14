---
title: قالب‌بندی اشکال PowerPoint در اندروید
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/androidjava/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- افکت اسکچ
- خط شکل اسکچ
- قالب‌بندی سبک پیوست
- پرکردن گرادیان
- پرکردن الگو
- پرکردن تصویر
- پرکردن بافت
- پرکردن رنگیکامل
- شفافیت شکل
- رندر شکل سیاه‌سفید
- رندر شکل خاکستری
- چرخاندن شکل
- افکت برش 3بعدی
- افکت چرخش 3بعدی
- بازنشانی قالب‌بندی
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "بیاموزید چگونه اشکال PowerPoint را در اندروید با استفاده از Aspose.Slides قالب‌بندی کنید—پر، خط و سبک‌های افکت را برای فایل‌های PPT، PPTX و ODP با دقت و کنترل کامل تنظیم کنید."
---
## **مقدمه**

در PowerPoint می‌توانید اشکال را به اسلایدها اضافه کنید. از آنجا که اشکال از خط‌ها تشکیل شده‌اند، می‌توانید آن‌ها را با تغییر یا اعمال افکت‌ها بر روی حاشیه‌هایشان قالب‌بندی کنید. علاوه بر این، می‌توانید اشکال را با تعیین تنظیماتی که نحوه پرکردن داخلی آن‌ها را کنترل می‌کنند، قالب‌بندی کنید.

![قالب‌سازی-شکل-پاورپوینت](format-shape-powerpoint.png)

Aspose.Slides برای Android از طریق Java رابط‌ها و متدهایی را فراهم می‌کند که به شما امکان می‌دهد اشکال را با استفاده از همان گزینه‌های موجود در PowerPoint قالب‌بندی کنید.

## **قالب‌بندی خطوط**

با Aspose.Slides می‌توانید یک سبک خط سفارشی برای یک شکل تعیین کنید. مراحل زیر این روند را شرح می‌دهند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلاید را بر اساس شاخص آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. قالب‌بندی [line style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linestyle/) را برای شکل تنظیم کنید.
1. عرض خط را تنظیم کنید.
1. قالب‌بندی [dash style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) خط را تنظیم کنید.
1. رنگ خط را برای شکل تنظیم کنید.
1. ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

کد زیر نشان می‌دهد چگونه یک `AutoShape` مستطیل را قالب‌بندی کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
Presentation presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // افزودن یک AutoShape از نوع Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // حذف پرکردگی از شکل مستطیل تا فقط خطوط آن قابل مشاهده باشند.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // اعمال قالب‌بندی بر خطوط مستطیل.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // تنظیم رنگ برای خط مستطیل.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // ذخیره فایل PPTX بر روی دیسک.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![خطوط قالب‌بندی‌شده در ارائه](formatted-lines.png)

## **اعمال افکت‌های اسکچ به خطوط شکل**

یک افکت اسکچ باعث می‌شود خط شکل شبیه به دست‌نویس به‌نظر برسد. از [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) برای دسترسی به تنظیمات خط، [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/) برای دسترسی به تنظیمات اسکچ، و [ISketchFormat.setSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/) برای انتخاب مقدار از شمارش‌گر [LineSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) استفاده کنید.

کد جاوای زیر نشان می‌دهد چگونه یک افکت [LineSketchType.Curved](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) را اعمال کنید، مقدار اختصاص‌یافته به‌وضوح را بخوانید، و افکت را با [LineSketchType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) حذف کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // دسترسی به قالب‌بندی خط شکل و قالب‌بندی اسکچ آن.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // اعمال یک افکت اسکچ.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // خواندن افکت اسکچ اختصاص‌یافته مستقیم به شکل.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // حذف افکت اسکچ.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

مقداری که توسط [ISketchFormat.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/) بازگردانده می‌شود، تنظیمی است که مستقیماً به شکل اختصاص داده شده است. اگر قالب‌بندی خط بتواند از یک تم، اسلاید اصلی یا اسلاید طرح‌بندی به ارث برده شود، از [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/) استفاده کنید، به [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/) دسترسی پیدا کنید، و [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformateffectivedata/) را بخوانید. مقدار مؤثر، قالب‌بندی‌ای را نشان می‌دهد که پس از حل ارث‌بری واقعاً اعمال می‌شود:

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

## **قالب‌بندی سبک‌های پیوست**

این‌ها سه گزینه نوع پیوست هستند:

* گرد
* میتر
* برش

به‌طور پیش‌فرض، زمانی که PowerPoint دو خط را در یک زاویه (مانند گوشهٔ یک شکل) به هم وصل می‌کند، از تنظیم **Round** استفاده می‌کند. اما اگر شکل با زوایای تیز ترسیم می‌کنید، ممکن است گزینه **Miter** را ترجیح دهید.

![سبک پیوست در ارائه](join-style-powerpoint.png)

کد جاوای زیر نشان می‌دهد چگونه سه مستطیل (همان‌طور که در تصویر بالا نشان داده شده) با استفاده از تنظیمات نوع پیوست Miter، Bevel و Round ایجاد شدند:

```java
import com.aspose.slides.*;
import java.awt.Color;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
Presentation presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // افزودن سه AutoShape از نوع Rectangle.
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

    // ذخیره فایل PPTX بر روی دیسک.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **پرکردن گرادیان**

در PowerPoint، پرکردن گرادیان یک گزینه قالب‌بندی است که به شما امکان می‌دهد ترکیبی پیوسته از رنگ‌ها را بر روی یک شکل اعمال کنید. به‌عنوان مثال، می‌توانید دو یا چند رنگ را به‌گونه‌ای که یکی به‌تدریج به دیگری محو شود، اعمال کنید.

در اینجا نحوه اعمال پرکردن گرادیان به یک شکل با استفاده از Aspose.Slides آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلاید را بر اساس شاخص آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. نوع [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) شکل را روی `Gradient` تنظیم کنید.
1. دو رنگ دلخواه خود را با موقعیت‌های تعریف‌شده با استفاده از متدهای `add` مجموعه توقف گرادیان که توسط رابط [IGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/) در دسترس است، اضافه کنید.
1. ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

کد جاوای زیر نشان می‌دهد چگونه یک افکت پرکردن گرادیان را به یک بیضی اعمال کنید:

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
Presentation presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // افزودن یک AutoShape از نوع Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // اعمال قالب‌بندی گرادیان به بیضی.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // تنظیم جهت گرادیان.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // افزودن دو نقطه توقف گرادیان.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // ذخیره فایل PPTX بر روی دیسک.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![بیضی با پرکردن گرادیان](gradient-fill.png)

اگر یک گرادیان در تصویر خروجی متفاوت از آنکه در PowerPoint نمایش داده می‌شود باشد، به [Choose a Gradient Rendering Style](/slides/fa/androidjava/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) مراجعه کنید. می‌توانید سبک رندر را بدون تغییر پرکردن گرادیان ذخیره‌شده در ارائه انتخاب کنید.

## **پرکردن الگو**

در PowerPoint، پرکردن الگو یک گزینه قالب‌بندی است که به شما امکان می‌دهد یک طرح دو‌رنگ—مانند نقاط، خطوط، شطرنج یا چک‌ها—را بر روی یک شکل اعمال کنید. می‌توانید رنگ‌های سفارشی برای پیش‌زمینه و پس‌زمینهٔ الگو انتخاب کنید.

Aspose.Slides بیش از ۴۵ سبک الگوی پیش‌تعریف‌شده را ارائه می‌دهد که می‌توانید به اشکال اعمال کنید تا ظاهر ارائه‌تان جذاب‌تر شود. حتی پس از انتخاب یک الگوی پیش‌تعریف‌شده، می‌توانید رنگ‌های دقیق موردنیاز را مشخص کنید.

در اینجا نحوه اعمال پرکردن الگو به یک شکل با استفاده از Aspose.Slides آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلاید را بر اساس شاخص آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. نوع [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) شکل را روی `Pattern` تنظیم کنید.
1. یک سبک الگو را از گزینه‌های پیش‌تعریف‌شده انتخاب کنید.
1. [Background Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/patternformat/#getBackColor--) الگو را تنظیم کنید.
1. [Foreground Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/patternformat/#getForeColor--) الگو را تنظیم کنید.
1. ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

کد جاوای زیر نشان می‌دهد چگونه یک پرکردن الگو را به یک مستطیل اعمال کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
Presentation presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // افزودن یک AutoShape از نوع Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // تنظیم نوع پر کردن به Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // تنظیم سبک الگو.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // تنظیم رنگ پس‌زمینه و پیش‌زمینهٔ الگو.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // ذخیره فایل PPTX بر روی دیسک.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![مستطیل با پرکردن الگو](pattern-fill.png)

## **پرکردن تصویر**

در PowerPoint، پرکردن تصویر یک گزینه قالب‌بندی است که به شما امکان می‌دهد یک تصویر را داخل یک شکل قرار دهید—به‌صورت عملی تصویر به‌عنوان پس‌زمینهٔ شکل استفاده می‌شود.

در اینجا نحوه استفاده از Aspose.Slides برای اعمال پرکردن تصویر به یک شکل آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلاید را بر اساس شاخص آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. نوع [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) شکل را روی `Picture` تنظیم کنید.
1. حالت پرکردن تصویر را روی `Tile` (یا حالت دلخواه دیگر) تنظیم کنید.
1. یک شیء [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) از تصویری که می‌خواهید استفاده کنید، ایجاد کنید.
1. تصویر را به متد `ISlidesPicture.setImage` پاس دهید.
1. ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

فرض کنید فایلی به نام "lotus.png" با تصویر زیر داشته باشیم:

![تصویر لوتوس](lotus.png)

کد جاوای زیر نشان می‌دهد چگونه یک شکل را با تصویر پر کنید:

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
Presentation presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // افزودن یک AutoShape از نوع Rectangle.
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

![شکل با پرکردن تصویر](picture-fill.png)

### **کاشی‌گذاری تصویر به‌عنوان بافت**

اگر می‌خواهید تصویری کاشی‌شده را به‌عنوان بافت تنظیم کنید و رفتار کاشی‌گذاری را سفارشی کنید، می‌توانید از روش‌های زیر رابط [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) استفاده کنید:

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): حالت پرکردن تصویر را تنظیم می‌کند—یا `Tile` یا `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): تراز کاشی‌ها را داخل شکل مشخص می‌کند.
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): تعیین می‌کند آیا کاشی به صورت افقی، عمودی یا هر دو وارونه شود.
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): افست افقی کاشی (به پوینت) را از مبدأ شکل تنظیم می‌کند.
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): افست عمودی کاشی (به پوینت) را از مبدأ شکل تنظیم می‌کند.
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): مقیاس افقی کاشی را به‌صورت درصد تعریف می‌کند.
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): مقیاس عمودی کاشی را به‌صورت درصد تعریف می‌کند.

نمونه کد زیر نشان می‌دهد چگونه یک شکل مستطیل با پرکردن تصویر کاشی‌شده اضافه کنید و گزینه‌های کاشی را پیکربندی کنید:

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
Presentation presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // افزودن یک AutoShape مستطیل.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // تنظیم نوع پر شدن شکل به Picture.
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

    // ذخیره فایل PPTX بر روی دیسک.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![گزینه‌های کاشی](tile-options.png)

## **پرکردن رنگیکامل**

در PowerPoint، پرکردن رنگیکامل یک گزینه قالب‌بندی است که شکل را با یک رنگ یکنواخت پر می‌کند. این پس‌زمینهٔ ساده بدون هیچ‌گونه گرادیان، بافت یا الگوی دیگری اعمال می‌شود.

برای اعمال پرکردن رنگیکامل به یک شکل با استفاده از Aspose.Slides، این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلاید را بر اساس شاخص آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. نوع [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) شکل را روی `Solid` تنظیم کنید.
1. رنگ پر دلخواه خود را به شکل اختصاص دهید.
1. ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

کد جاوای زیر نشان می‌دهد چگونه یک پرکردن رنگیکامل را به یک مستطیل در اسلاید PowerPoint اعمال کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
Presentation presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // افزودن یک AutoShape از نوع Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // تنظیم نوع پر کردن به Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // تنظیم رنگ پر.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // ذخیره فایل PPTX بر روی دیسک.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![شکل با پرکردن رنگیکامل](solid-color-fill.png)

## **تنظیم شفافیت**

در PowerPoint، هنگام اعمال پر رنگیکامل، گرادیان، تصویر یا بافت به اشکال، می‌توانید سطح شفافیت را نیز تنظیم کنید تا میزان تاری پر را کنترل کنید. مقدار شفافیت بالاتر، شکل را شفاف‌تر می‌کند و پس‌زمینه یا اشیاء زیرین را به‌طور جزئی قابل مشاهده می‌سازد.

Aspose.Slides به شما امکان می‌دهد سطح شفافیت را با تنظیم مقدار آلفا در رنگ مورد استفاده برای پر تنظیم کنید. در اینجا نحوه انجام این کار آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلاید را بر اساس شاخص آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. نوع [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) را روی `Solid` تنظیم کنید.
1. از `Color` برای تعریف رنگی با شفافیت (کامپوننت `alpha` شفافیت را کنترل می‌کند) استفاده کنید.
1. ارائه را ذخیره کنید.

کد جاوای زیر نشان می‌دهد چگونه یک رنگ پر شفافیت را به یک مستطیل اعمال کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
Presentation presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // افزودن یک AutoShape مستطیل پر.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // افزودن یک AutoShape مستطیل شفاف بر روی شکل ثابت.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // ذخیره فایل PPTX بر روی دیسک.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![شکل شفاف](shape-transparency.png)

## **چرخاندن اشکال**

Aspose.Slides به شما امکان می‌دهد اشکال را در ارائه‌های PowerPoint بچرخانید. این می‌تواند هنگام موقعیت‌یابی عناصر بصری با نیازهای خاص طراحی یا تراز مفید باشد.

برای چرخاندن یک شکل بر روی اسلاید، این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلاید را بر اساس شاخص آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی چرخش شکل را روی زاویهٔ دلخواه تنظیم کنید.
1. ارائه را ذخیره کنید.

کد جاوای زیر نشان می‌دهد چگونه یک شکل را به‌صورت 5 درجه بچرخانید:

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
Presentation presentation = new Presentation();
try {
    // دریافت اولین اسلاید.
    ISlide slide = presentation.getSlides().get_Item(0);

    // افزودن یک AutoShape از نوع Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // چرخاندن شکل به مقدار 5 درجه.
    shape.setRotation(5);

    // ذخیره فایل PPTX بر روی دیسک.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![چرخش شکل](shape-rotation.png)

## **افزودن افکت‌های برش 3بعدی**

Aspose.Slides به شما امکان می‌دهد افکت‌های برش 3بعدی را به اشکال اعمال کنید با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) آنها.

برای افزودن افکت‌های برش 3بعدی به یک شکل، این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلاید را بر اساس شاخص آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) شکل را پیکربندی کنید تا تنظیمات برش را تعریف کنید.
1. ارائه را ذخیره کنید.

کد جاوای زیر نشان می‌دهد چگونه افکت‌های برش 3بعدی را به یک شکل اعمال کنید:

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

    // خصوصیات ThreeDFormat شکل را تنظیم کنید.
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

![افکت برش 3بعدی](3D-bevel-effect.png)

## **افزودن افکت‌های چرخش 3بعدی**

Aspose.Slides به شما امکان می‌دهد افکت‌های چرخش 3بعدی را به اشکال اعمال کنید با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) آنها.

برای اعمال چرخش 3بعدی به یک شکل:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلاید را بر اساس شاخص آن دریافت کنید.
1. یک [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. از [setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) و [setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) برای تعریف چرخش 3بعدی استفاده کنید.
1. ارائه را ذخیره کنید.

کد جاوای زیر نشان می‌دهد چگونه افکت‌های چرخش 3بعدی را به یک شکل اعمال کنید:

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

![افکت چرخش 3بعدی](3D-rotation-effect.png)

## **کنترل رندر سیاه‌سفید برای اشکال**

متد [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) مشخص می‌کند که یک شکل به‌صورت تک‌رنگ سیاه‌سفید چگونه رندر شود وقتی ارائه در حالت سیاه‌سفید مشاهده یا پردازش می‌شود. این متد به‌تنهایی حالت نمایش سیاه‌سفید را فعال نمی‌کند و قالب‌بندی پر، خط یا سایر تنظیمات شکل را در حالت رنگ عادی تغییر نمی‌دهد.

از یک مقدار کلاس [BlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blackwhitemode/) برای انتخاب رفتار موردنظر استفاده کنید. به‌عنوان مثال، `Automatic` اجازه می‌دهد برنامه رندر تبدیل را انتخاب کند، `Gray` و `LightGray` از رنگ خاکستری استفاده می‌کنند، `BlackWhite` فقط سیاه و سفید را استفاده می‌کند، `Black` و `White` یک رنگ را مجبور می‌کنند، `Color` رنگ‌بندی عادی را حفظ می‌کند و `Hidden` شکل را در حالت سیاه‌سفید حذف می‌کند. `NotDefined` یعنی هیچ حالت سطح‌شکل‌گذاری اختصاص داده نشده است.

کد جاوای زیر یک شکل رنگی ایجاد می‌کند و آن را در حالت نمایش سیاه‌سفید به‌صورت خاکستری نشان می‌دهد:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    // در حالت رنگ، پرکردن نارنجی را حفظ کنید، اما شکل را در حالت سیاه‌سفید با رنگ خاکستری رندر کنید.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

در حالت رنگ عادی، مستطیل پر رنگ نارنجی خود را حفظ می‌کند. در یک گردش کاری نمایش سیاه‌سفید، به‌دلیل تنظیم حالت روی `Gray` از رنگ خاکستری استفاده می‌کند. این به شما اجازه می‌دهد اسلاید رنگی کامل را حفظ کنید در حالی که ظاهر متفاوتی برای چاپ، پیش‌نمایش یا دیگر گردش‌های کاری که تنظیمات نمایش سیاه‌سفید ارائه را رعایت می‌کنند، تعریف کنید.

## **بازنشانی قالب‌بندی**

کد جاوای زیر نشان می‌دهد چگونه قالب‌بندی یک اسلاید را بازنشانی کنید و موقعیت، اندازه و قالب‌بندی تمام اشکالی که دارای جای‌نگهدار در [LayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslide/) هستند را به تنظیمات پیش‌فرض برگردانید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // بازنشانی هر شکل بر روی اسلایدی که یک جای‌نگهدار در طرح‌بندی دارد.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**آیا قالب‌بندی شکل بر حجم نهایی فایل ارائه تأثیر می‌گذارد؟**

فقط به‌صورت جزئی. تصاویر و رسانه‌های جاسازی‌شده بیشتر فضای فایل را اشغال می‌کنند، در حالی که پارامترهای شکل مانند رنگ‌ها، افکت‌ها و گرادیان‌ها به‌عنوان فراداده ذخیره می‌شوند و تقریباً هیچ حجم اضافی اضافه نمی‌کنند.

**چگونه می‌توانم اشکالی را در یک اسلاید که قالب‌بندی یکسان دارند شناسایی کنم تا بتوانم آن‌ها را گروه‌بندی کنم؟**

خصوصیات کلیدی قالب‌بندی هر شکل—پر، خط و تنظیمات افکت—را مقایسه کنید. اگر تمام مقادیر متناظر یکسان باشند، سبک آن‌ها را یکسان درنظر بگیرید و منطقی آن‌ها را گروه‌بندی کنید؛ این کار مدیریت سبک‌های بعدی را ساده می‌کند.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در فایلی جداگانه ذخیره کنم تا در ارائه‌های دیگر دوباره استفاده شود؟**

بله. اشکال نمونه با سبک‌های موردنظر را در یک ارائهٔ قالب یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد ارائهٔ جدید، قالب را باز کنید، اشکال دارای سبک موردنیاز را کلون کنید و قالب‌بندی آن‌ها را در هر مکان موردنیاز دوباره اعمال کنید.