---
title: قالب‌بندی اشکال PowerPoint در Android
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/androidjava/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- اثر اسکیچ
- خط اسکیچ شکل
- قالب‌بندی سبک اتصال
- پرکننده گرادیان
- پرکننده الگو
- پرکننده تصویر
- پرکننده بافت
- پرکننده رنگ جامد
- شفافیت شکل
- رندرینگ شکل سیاه‑سفید
- رندرینگ شکل در مقیاس خاکستری
- چرخش شکل
- اثر بریده‌سازی 3D
- اثر چرخش 3D
- بازنشانی قالب‌بندی
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "به‌دست آوردن نحوه قالب‌بندی اشکال PowerPoint در Android با استفاده از Aspose.Slides—تنظیم سبک‌های پرکننده، خط و افکت برای فایل‌های PPT و PPTX با دقت و کنترل کامل."
---
## **معرفی**

شکل‌ها را در PowerPoint با تنظیم خطوط حاشیه، پرکننده‌ها و افکت‌ها قالب‌بندی کنید. Aspose.Slides for Android via Java به شما امکان می‌دهد این تنظیمات را به‌صورت برنامه‌نویسی کنترل کنید، از جمله شفافیت، چرخش و قالب‌بندی 3D.

![گزینه‌های قالب‌بندی شکل در PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java رابط‌ها و متدهایی را فراهم می‌کند که به شما اجازه می‌دهد شکل‌ها را با استفاده از همان گزینه‌های موجود در PowerPoint قالب‌بندی کنید.

## **قالب‌بندی خطوط**

از [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) برای کنترل حاشیهٔ یک شکل استفاده کنید. این مثال یک مستطیل بدون پرکننده با حاشیهٔ آبی و خط‌شکسته ایجاد می‌کند. [ILineFormat.setStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setStyle-byte-) یک خط ترکیبی ضخیم‑باریک را انتخاب می‌کند، در حالی که [ILineFormat.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-) عرض آن را به ۷ پوینت تنظیم می‌کند و [ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-) الگوی خط‌شکسته را انتخاب می‌نماید.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![خطوط قالب‌بندی شده در ارائه](formatted-lines.png)

### **تنظیم الگوهای سفارشی خط‌شکسته**

از [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCustomDashPattern-float---) زمانی که سبک‌های پیش‌فرض خط طول و فاصلهٔ دلخواه شما را فراهم نمی‌کنند، استفاده کنید؛ برای مثال برای حاشیه‌های برند یا نمودارهای فنی. اختصاص یک الگو به‌صورت خودکار سبک خط‌شکسته را به [LineDashStyle.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) تغییر می‌دهد.

مقدارهای آرایه به‌صورت متناوب بین طول خط و فاصلهٔ آن جابجا می‌شوند، با یک خط شروع می‌شود. هر مقدار مضرب عرض خط است: `{ 4, 2 }` با عرض ۳ پوینت یک خط ۱۲ پوینتی سپس فاصلهٔ ۶ پوینتی تولید می‌کند. برای تعریف بخش‌های کامل خط و فاصله از جفت مقادیر متناهی و غیرمنفی استفاده کنید. مثال از مقادیر مثبت استفاده می‌کند تا هر خط و فاصله قابل مشاهده باشد.

این مثال پنج خط آبی با طول یکسان و سرهای صاف ایجاد می‌کند. سه مثال اول الگوها را با عرض ۳ پوینت مقایسه می‌نمایند. مثال چهارم همان الگو را با دو برابر عرض تکرار می‌کند و هم طول خط و هم فاصله را دو برابر می‌کند. مثال پنجم از الگوی سفارشی به خط یک‌دست سوئیچ می‌کند.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[][] patterns = {
        { 4, 2 },
        { 1, 2 },
        { 6, 2, 1, 2 },
        { 4, 2 },
        { 4, 2 }
    };

    for (int i = 0; i < patterns.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
        line.getLineFormat().setWidth(i == 3 ? 6 : 3);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        line.getLineFormat().setCapStyle(LineCapStyle.Flat);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setCustomDashPattern(patterns[i]);
    }

    // خط آخر را به سبک یک‌دست بازگردانید.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای برگرداندن به یک سبک پیش‌فرض خط‌شکسته، به جای آن [LineDashStyle.Dash](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) را به [ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-) پاس دهید. سبک انتخاب شده ظاهر خط را کنترل می‌کند.

نتیجه در PowerPoint، از بالا به پایین: **{4, 2}, 3 pt**؛ **{1, 2}, 3 pt**؛ **{6, 2, 1, 2}, 3 pt**؛ **{4, 2}, 6 pt**؛ و **Solid, 3 pt**.

![سه الگو سفارشی خط‌شکسته، خطی عریض‌تر با اولین الگو، و یک خط یک‌دست در PowerPoint](custom-dash-patterns.png)

### **تنظیم سرهای خط**

از [ILineFormat.setCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCapStyle-byte-) برای تنظیم انتهای یک خط باز استفاده کنید. کلاس [LineCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linecapstyle/) سه سبک صریح سر را فراهم می‌کند:

- `Flat`: خط در نقطهٔ انتها متوقف می‌شود.
- `Round`: سر نیم‌دایره‌ای نیم‌عرض خط را فراتر از نقطهٔ انتها گسترش می‌دهد.
- `Square`: سر مربع‌وار نیم‌عرض خط را فراتر از نقطهٔ انتها گسترش می‌دهد.

این کلاس همچنین شامل `NotDefined` است که به معنای عدم اختصاص صریح سبک سر می‌باشد.

سرها متفاوت از سرهای پیکان هستند که نمادهایی به انتهای خط می‌افزایند، و اتصال‌ها که گوشه‌های بین قطعات خط را کنترل می‌کنند. این مثال سرهای پیکان را با استفاده از [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) و [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-) غیرفعال می‌کند تا فقط شکل سرها مقایسه شوند.

مثال زیر سه خط افقی تقریباً یکسان، به‌عرض ۲۰ پوینت، ایجاد می‌کند. از بالا به پایین، سرهای صاف، گرد و مربع را به‌کار می‌برد. نقاط انتهایی آنها مختصات افقی یکسانی دارند؛ سرهای گرد و مربع ۱۰ پوینت بیش از هر انتها گسترش می‌یابند.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] capStyles = new byte[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

    for (int i = 0; i < capStyles.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        line.getLineFormat().setDashStyle(LineDashStyle.Solid);
        line.getLineFormat().setCapStyle(capStyles[i]);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
    }

    presentation.save("line_caps.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه در PowerPoint، از بالا به پایین: **Flat**, **Round**, و **Square**.

![سرهای صاف، گرد و مربع روی خطوط ضخیم یکسان در PowerPoint](line-caps.png)

## **اعمال افکت‌های اسکیچ به خطوط شکل**

یک افکت اسکیچ باعث می‌شود خط شکل دست‌نویس به‌نظر برسد. از [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) برای دسترسی به تنظیمات خط، از [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getSketchFormat--) برای دسترسی به تنظیمات اسکیچ، و از [ISketchFormat.setSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#setSketchType-int-) برای انتخاب یک مقدار از کلاس [LineSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) استفاده کنید.

کد جاوای زیر نشان می‌دهد چگونه افکت [LineSketchType.Curved](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) اعمال شود، مقدار صریحاً اختصاص داده‌شده خوانده شود، و با [LineSketchType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) افکت حذف گردد:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();
    sketchFormat.setSketchType(LineSketchType.Curved);
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

مقداری که توسط [ISketchFormat.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#getSketchType--) برگردانده می‌شود، تنظیمی است که مستقیماً به شکل اختصاص داده شده است. اگر قالب‌بندی خط می‌تواند از تم، اسلاید مستر یا اسلاید طرح‌بندی به ارث برسد، از [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--)، دسترسی به [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--) و خواندن [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformateffectivedata/#getSketchType--) استفاده کنید. مقدار مؤثر، قالب‌بندی‌ای را نشان می‌دهد که پس از حل ارث‌بری واقعاً اعمال می‌شود. این مثال نیاز به یک ارائهٔ موجود دارد که حداقل یک شکل در اسلاید اول داشته باشد و هر دو مقدار را چاپ می‌کند:

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

## **قالب‌بندی سبک‌های اتصال**

در اینجا سه گزینهٔ نوع اتصال آورده شده‌اند:

* Round
* Miter
* Bevel

سبک اتصال نحوهٔ برخورد دو قطعهٔ حاشیه را در یک گوشه کنترل می‌کند. از **Round** برای گوشه‌های گرد، **Miter** برای گوشه‌های تیز، یا **Bevel** برای گوشه‌های مسطح استفاده کنید.

![سبک اتصال در ارائه](join-style-powerpoint.png)

این مثال سه مستطیل مشکی با حاشیهٔ آبی به‌عرض ۱۵ پوینت ایجاد می‌کند. از [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) برای اعمال مقادیر miter، bevel و round کلاس [LineJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/) به‌صورت متناوب استفاده می‌شود تا مشاهده شود گوشه‌ها چگونه ترسیم می‌شوند.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape miterShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape bevelShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape roundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    miterShape.getFillFormat().setFillType(FillType.Solid);
    miterShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    bevelShape.getFillFormat().setFillType(FillType.Solid);
    bevelShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    roundShape.getFillFormat().setFillType(FillType.Solid);
    roundShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    miterShape.getLineFormat().setWidth(15);
    bevelShape.getLineFormat().setWidth(15);
    roundShape.getLineFormat().setWidth(15);

    miterShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    miterShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    bevelShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    bevelShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    roundShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    roundShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    miterShape.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    bevelShape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    roundShape.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    miterShape.getTextFrame().setText("Miter Join Style");
    bevelShape.getTextFrame().setText("Bevel Join Style");
    roundShape.getTextFrame().setText("Round Join Style");

    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **محدود کردن اتصال‌های Miter در گوشه‌های تیز**

از [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setMiterLimit-float-) همراه با [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) که به [LineJoinStyle.Miter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/) تنظیم شده است، برای محدودکردن طولی که یک گوشهٔ تیز می‌تواند گسترش یابد، استفاده کنید.

محدودیت نسبت فاصلهٔ بین گوشهٔ داخلی و خارجی اتصال به عرض خط است. برای مثال، مقدار `8` اجازه می‌دهد طول miter تا هشت برابر عرض خط افزایش یابد؛ این یک اندازه در پوینت نیست. اگر گوشه از حد تعیین‌شده فراتر رود، PowerPoint در آن گوشه از یک اتصال bevel استفاده می‌کند. محدودیت بزرگ‌تر نقاط تیزتر ایجاد می‌کند. این تنظیم فقط روی اتصال‌های miter تأثیر می‌گذارد و تغییر آن زمانی اثر قابل‌مشاهده‌ای ندارد که گوشه در هر دو حد باقی بماند.

این مثال دو مثلث بدون پرکنندهٔ یکسان، با حاشیهٔ ۲۰ پوینت، ایجاد می‌کند. مثلث چپ از حد `2` و مثلث راست از حد `8` استفاده می‌کند. هر مثلث به‌عرض ۸۰ پوینت و به‌ارتفاع ۱۶۰ پوینت است که نسبت طول miter به عرض خط گوشهٔ بالا تقریباً `4.12` است. Consequently, PowerPoint bevels the left apex and preserves the right apex.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] miterLimits = new float[] { 2f, 8f };

    for (int i = 0; i < miterLimits.length; i++) {
        IAutoShape triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
        triangle.getFillFormat().setFillType(FillType.NoFill);
        triangle.getLineFormat().setWidth(20);
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
        triangle.getLineFormat().setMiterLimit(miterLimits[i]);
    }

    presentation.save("miter_limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه در PowerPoint: **Miter limit 2** در سمت چپ و **miter limit 8** در سمت راست.

![یک نوک bevel شده با محدودیت miter 2 و یک نوک تیز با محدودیت miter 8 در PowerPoint](miter-limits.png)

## **پرکنندهٔ گرادیان**

پرکنندهٔ گرادیان رنگ‌ها را در طول یک شکل ترکیب می‌کند. این مثال یک بیضی را با یک گرادیان خطی به‌زاویهٔ ۴۵ درجه از قرمز به بنفش پر می‌کند با استفاده از [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getGradientFormat--). متد [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) رنگ‌های توقف را در ۰ و ۱ (آغاز و پایان گرادیان) قرار می‌دهد. پاک‌سازی توقف‌های موجود تضمین می‌کند که فقط این دو رنگ استفاده شوند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45);
    shape.getFillFormat().getGradientFormat().getGradientStops().clear();
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0f, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0f, PresetColor.Red);

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![بیضی با پرکنندهٔ گرادیان](gradient-fill.png)

اگر یک گرادیان در تصویر خروجی متفاوت از آنچه در PowerPoint دیده می‌شود، به [Choose a Gradient Rendering Style](/slides/fa/androidjava/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) مراجعه کنید. می‌توانید یک سبک رندرینگ را بدون تغییر گرادیان ذخیره‌شده در ارائه انتخاب کنید.

### **تنظیم زاویهٔ گرادیان خطی**

از [IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) برای کنترل جهت یک پرکنندهٔ [GradientShape.Linear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/) استفاده کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود و ساعتگرد افزایش می‌یابد: `0` از چپ به راست، `90` از بالا به پایین، `180` از راست به چپ، و `270` از پایین به بالا. زواید جزئی نیز پشتیبانی می‌شوند. زوایای محدود به `[0, 360)` به یک دور کامل نرمال‌سازی می‌شوند؛ برای مثال، `-45` تبدیل به `315` و `360` تبدیل به `0` می‌شود.

این مثال شش مستطیل با توقف‌های رنگی قرمز، سبز و آبی یکسان در مکان‌های `0`، `0.5` و `1` ایجاد می‌کند. مقیاس‌گذاری غیرفعال است تا زاویه به‌صورت مستقل از نسبت‌های مستطیل‌ها مقایسه شود. زوایا، از چپ به راست، در ردیف اول `0`، `45` و `90` و در ردیف دوم `135`، `180` و `270` هستند.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] angles = new float[] { 0, 45, 90, 135, 180, 270 };

    for (int i = 0; i < angles.length; i++) {
        int x = 30 + (i % 3) * 230;
        int y = 30 + (i / 3) * 190;

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.False);
        gradient.setLinearGradientAngle(angles[i]);
    }

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه در PowerPoint:

![گرادیان خطی با زوایای ۰، ۴۵ و ۹۰ درجه در ردیف بالا، و ۱۳۵، ۱۸۰ و ۲۷۰ درجه در ردیف پایین](linear-gradient-angles.png)

### **مقیاس‌گذاری یک گرادیان خطی با شکل**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) مقدار یک [NullableBool](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) می‌گیرد. به‌طور صریح `False` تنظیم کنید تا زاویهٔ هندسی گرادیان با تغییر نسبت‌های شکل ثابت بماند، یا `True` تا گرادیان با عرض و ارتفاع شکل مقیاس‌گذاری شود. با فعال‌سازی مقیاس‌گذاری، زاویهٔ قابل‌مشاهده می‌تواند با زاویهٔ اختصاصی در یک شکل غیر‌مربع متفاوت باشد.

مثال زیر از زاویهٔ `45` درجه و همان توقف‌های رنگی همانند مقایسهٔ زاویه استفاده می‌کند. ستون چپ `False` و ستون راست `True` را به‌کار می‌برد. هر ستون شامل یک مستطیل عریض بالا و یک مستطیل بلند در زیر است. هر دو با ابعاد عریض یکسان شروع می‌شوند؛ تغییر عرض و ارتفاع مستطیل دوم نشان می‌دهد پرکننده چگونه به تغییر اندازه واکنش می‌دهد بدون اینکه تنظیمات گرادیان را تغییر دهد.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] scalingOptions = new byte[] { NullableBool.False, NullableBool.True };

    for (int column = 0; column < scalingOptions.length; column++) {
        for (int row = 0; row < 2; row++) {
            int x = 30 + column * 360;
            int y = row == 0 ? 30 : 150;

            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90);
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
            shape.getFillFormat().setFillType(FillType.Gradient);

            IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
            gradient.setGradientShape(GradientShape.Linear);
            gradient.getGradientStops().clear();
            gradient.getGradientStops().add(0f, Color.RED);
            gradient.getGradientStops().add(0.5f, Color.GREEN);
            gradient.getGradientStops().add(1f, Color.BLUE);
            gradient.setLinearGradientAngle(45);
            gradient.setLinearGradientScaled(scalingOptions[column]);

            if (row == 1) {
                shape.setWidth(90);
                shape.setHeight(280);
            }
        }
    }

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه در PowerPoint، با مقیاس‌گذاری غیرفعال در سمت چپ و فعال در سمت راست:

![مستطیل‌های عریض و بلند با گرادیان ۴۵ درجه، مقایسه LinearGradientScaled False در سمت چپ با True در سمت راست](linear-gradient-scaling.png)

با مقیاس‌گذاری غیرفعال، نوارهای رنگی مورب همان جهت را در هر دو مستطیل حفظ می‌کنند. با مقیاس‌گذاری فعال، نوارها با نسبت‌های شکل کشیده می‌شوند. این کمک می‌کند تا گرادیان یک قالب هنگام تغییر اندازهٔ شکل بازتولید شود. در یک مربع، فعال‌سازی مقیاس‌گذاری نمای ظاهری این گرادیان `45` درجه را تغییر نمی‌دهد.

هر دو تنظیم زاویه و مقیاس‌گذاری برای گرادیان‌های خطی اعمال می‌شوند. آنها کنترل پرکننده‌های [GradientShape.Radial or GradientShape.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/) را ندارند.

### **ترکیب زاویه با جهت گرادیان**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setGradientDirection-int-) یک سبک گرادیان را از کلاس [GradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientdirection/) انتخاب می‌کند؛ این جایگزین یک زاویهٔ عددی نیست. برای یک گرادیان خطی، سبک‌های گوشه می‌توانند ناحیه‌ای را که رنگ‌ها توزیع می‌شوند بدون تغییر زاویهٔ اختصاصی از طریق [setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) تغییر دهند. هنگام مقایسهٔ زوایا یا مقیاس‌گذاری، جهت را ثابت نگه دارید.

مثال زیر همان تنظیمات را در ترتیب مخالف اعمال می‌کند. دو مستطیل ظاهر یکسانی دارند: اختصاص جهت قبل یا بعد از زاویه نتیجه را تغییر نمی‌دهد.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (int i = 0; i < 2; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.True);

        if (i == 0) {
            gradient.setGradientDirection(GradientDirection.FromCorner1);
            gradient.setLinearGradientAngle(30);
        } else {
            gradient.setLinearGradientAngle(30);
            gradient.setGradientDirection(GradientDirection.FromCorner1);
        }
    }

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **پرکنندهٔ الگو**

یک پرکنندهٔ الگو یک طرح دو‌رنگ مانند نقطه‌ها، نوارها یا شطرنج‌ها را اعمال می‌کند. این مثال از [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) برای انتخاب یک الگو trellis استفاده می‌کند. [IPatternFormat.getBackColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getBackColor--) پس‌زمینهٔ خاکستری روشن را فراهم می‌کند و [IPatternFormat.getForeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getForeColor--) رنگ زرد الگو را تأمین می‌کند.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Pattern);
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.rgb(192, 192, 192));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![مستطیل با پرکنندهٔ الگو](pattern-fill.png)

## **پرکنندهٔ تصویر**

یک پرکنندهٔ تصویر از یک تصویر داخل یک شکل استفاده می‌کند. این مثال به یک تصویر محلی نیاز دارد و از [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) برای بارگذاری آن در مجموعهٔ تصویر ارائه استفاده می‌کند. تنظیم [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) به حالت کاشی‌ای (tiled) تصویر را در داخل مستطیل تکرار می‌کند. تصویر منبع مورد استفاده در زیر نشان داده شده است:

![عکس نیلوفر lotus](lotus.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    IImage image = Images.fromFile("lotus.png");
    IPPImage picture;
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![شکل با پرکنندهٔ تصویر](picture-fill.png)

### **کاشی تصویر به‌عنوان بافت**

اگر می‌خواهید یک تصویر کاشی‌ای را به‌عنوان بافت تنظیم کنید و رفتار کاشی‌گذاری را سفارشی کنید، می‌توانید از متدهای زیر رابط [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) استفاده کنید:

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): حالت پرکنندهٔ تصویر را تنظیم می‌کند — `Tile` یا `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): هم‌ترازی کاشی‌ها درون شکل را مشخص می‌کند.
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): کنترل می‌کند آیا کاشی به‌صورت افقی، عمودی یا هر دو معکوس شود.
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): افست افقی کاشی (به پوینت) از مبدأ شکل را تنظیم می‌کند.
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): افست عمودی کاشی (به پوینت) از مبدأ شکل را تنظیم می‌کند.
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): مقیاس افقی کاشی را به‌صورت درصد تعریف می‌کند.
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): مقیاس عمودی کاشی را به‌صورت درصد تعریف می‌کند.

این مثال به یک تصویر محلی نیاز دارد و [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) را برای تکرار آن در ۵۰٪ اندازهٔ اصلی پیکربندی می‌کند. افست‌های ‑۳۲ پوینت کاشی‌ها را به‌صورت افقی و عمودی جابجا می‌کند؛ هم‌ترازی پایین‑راست و معکوس کردن در هر دو جهت تعیین می‌کند که بافت تکراری چگونه مرتب شود.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
    shape.getFillFormat().setFillType(FillType.Picture);

    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![گزینه‌های کاشی](tile-options.png)

## **پرکنندهٔ رنگ جامد**

یک پرکنندهٔ جامد یک رنگ یکنواخت به شکل می‌دهد. این مثال از [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) برای انتخاب حالت پرکنندهٔ جامد استفاده می‌کند و رنگ زرد را از طریق [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) اختصاص می‌دهد، سپس مستطیل را در یک ارائه ذخیره می‌کند.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![شکل با پرکنندهٔ رنگ جامد](solid-color-fill.png)

## **استفاده از پس‌زمینهٔ اسلاید به‌عنوان پرکنندهٔ شکل**

از [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) وقتی یک شکل باید با پس‌زمینهٔ اسلاید مطابقت داشته باشد، استفاده کنید؛ برای مثال در یک قالب ارائه. ابتدا از [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) با [FillType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) برای حذف هر پرکنندهٔ صریح استفاده کنید. با این ترکیب، شکل به‌جای پرکنندهٔ سبک خود، پس‌زمینهٔ اسلاید را استفاده می‌کند. فعال‌سازی تنها پرچم، پرکنندهٔ صریح موجود را حذف نمی‌کند.

این رفتار با [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) متفاوت است: پرکنندهٔ پس‌زمینه اشیایی که پشت شکل قرار دارند را با ناحیهٔ متناظر پس‌زمینه اسلاید می‌پوشاند، در حالی که بدون پرکننده آن اشیا قابل مشاهده می‌مانند. یک گرادیان در ارتباط با اسلاید باقی می‌ماند و در داخل هر شکل از نو شروع نمی‌شود.

مثال زیر یک پس‌زمینهٔ مستر که توسط اسلاید به ارث می‌رسد ایجاد می‌کند و یک نوار سرخوردن پشت سه مستطیل قرار می‌دهد. مستطیل چپ از پس‌زمینه استفاده می‌کند، مستطیل میانی بدون پرکننده است، و مستطیل راست از پرکنندهٔ پس‌زمینه به یک پرکنندهٔ نارنجی صریح سوئیچ می‌کند.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    // گرادیان را از مستر به ارث ببرید.
    slide.getBackground().setType(BackgroundType.NotDefined);
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined);
    IBackground background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Gradient);
    IGradientFormat gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(GradientShape.Linear);
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, Color.rgb(0, 0, 139));
    gradient.getGradientStops().add(1, Color.rgb(135, 206, 250));

    // این شیء را ابتدا اضافه کنید تا پشت مستطیل‌ها ظاهر شود.
    IAutoShape band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    IAutoShape backgroundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
    backgroundShape.getFillFormat().setFillType(FillType.NotDefined);
    backgroundShape.setUseBackgroundFill(true);

    IAutoShape noFillShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
    noFillShape.getFillFormat().setFillType(FillType.NoFill);

    IAutoShape explicitShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
    explicitShape.getFillFormat().setFillType(FillType.NotDefined);
    explicitShape.setUseBackgroundFill(true);

    // پرکردن پس‌زمینه را قبل از اعمال پرکننده صریح غیرفعال کنید.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه، از چپ به راست: **پرکنندهٔ پس‌زمینه**، **بدون پرکننده**، و **پرکنندهٔ صریح**. نوار سرخوردن توسط مستطیل‌های چپ و راست پنهان می‌شود ولی از طریق مستطیل میانی قابل مشاهده است.

![پرکنندهٔ پس‌زمینه، بدون پرکننده، و پرکنندهٔ نارنجی صریح روی یک نوار سرخوردن](background-fill.png)

رفتار مشابه برای پس‌زمینه‌ای که مستقیماً بر روی اسلاید تعریف شده یا از یک طرح‌بندی به ارث برده می‌شود نیز صادق است. شکل از پس‌زمینهٔ حل‌شدهٔ اسلید استفاده می‌کند؛ مثال هر دو پس‌زمینهٔ اسلاید و طرح‌بندی را بدون تعریف می‌گذارد تا مستر آن را تأمین کند.

## **تنظیم شفافیت**

برای یک پرکنندهٔ جامد، مؤلفهٔ آلفای رنگ، شفافیت را کنترل می‌کند: ۰ کاملاً شفاف و ۲۵۵ کاملاً مات. این مثال از مقدار آلفا ۱۲۸ برای یک مستطیل زرد استفاده می‌کند، تقریباً ۵۰٪ شفاف، طوری که مستطیل زیرین قابل مشاهده بماند. رنگ از طریق [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) اختصاص می‌یابد.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(Color.argb(128, 255, 255, 0));

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![شکل شفاف](shape-transparency.png)

## **چرخش شکل‌ها**

از [IShape.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setRotation-float-) برای چرخاندن یک شکل در صفحهٔ اسلاید استفاده کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود؛ این مثال یک مستطیل را ۵ درجه ساعتگرد می‌چرخاند و ارائه را ذخیره می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.setRotation(5);

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![چرخش شکل](shape-rotation.png)

## **افزودن افکت‌های بریده‌سازی 3D**

از [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) برای افزودن عمق و لبه‌های بریده‌سازی به یک شکل استفاده کنید. این مثال یک بیضی سبز با حاشیهٔ نارنجی ایجاد می‌کند، از [IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) برای تنظیم عمق به ۴ پوینت استفاده می‌کند و از طریق [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) یک بریده‌سازی بالایی دایره‌ای با عرض و ارتفاع ۶ پوینت اعمال می‌کند. یک دوربین ارتوگرافیک جلو و نورپردازی سه‌نقطه‌ای، بریده‌سازی را قابل مشاهده می‌کند.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.getLineFormat().setWidth(2.0);
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![افکت بریده‌سازی 3D](3D-bevel-effect.png)

## **افزودن افکت‌های چرخش 3D**

نمای 3D یک شکل توسط تنظیمات دوربین آن کنترل می‌شود. این مثال از [ICamera.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-) با زوایای عرض، طول و چرخش به ترتیب ۴۰، ۳۵ و ۲۰ درجه استفاده می‌کند. از [ICamera.setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) برای انتخاب یک دوربین ایزومتریک و از [ILightRig.setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) برای نورپردازی متعادل استفاده می‌کند، سپس مستطیل قالب‌بندی‌شده را ذخیره می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![افکت چرخش 3D](3D-rotation-effect.png)

## **کنترل رندرینگ سیاه‑سفید برای شکل‌ها**

متد [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) مشخص می‌کند که یک شکل به‌صورت فردی هنگام نمایش یا پردازش ارائه در حالت سیاه‑سفید چگونه رندر شود. این خود به‌تنهایی حالت سیاه‑سفید را فعال نمی‌کند و پرکننده، خط یا سایر قالب‌بندی‌های شکل را در حالت رنگ عادی تغییر نمی‌دهد.

از یک مقدار کلاس [BlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blackwhitemode/) برای انتخاب رفتار موردنظر استفاده کنید. برای مثال، `Automatic` اجازه می‌دهد برنامه رندرینگ تبدیل را انتخاب کند، `Gray` و `LightGray` از رنگ‌سیاه استفاده می‌کنند، `BlackWhite` فقط سیاه و سفید، `Black` و `White` یک‌رنگ را اعمال می‌کنند، `Color` رنگ‌بندی عادی را حفظ می‌کند، و `Hidden` شکل را در حالت سیاه‑سفید حذف می‌کند. `NotDefined` به این معنی است که هیچ حالت سطح‌شکلی اختصاص داده نشده است.

این مثال یک مستطیل نارنجی ایجاد می‌کند و با استفاده از [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) رنگ‌نگاری خاکستری را انتخاب می‌کند. شکل ذخیره‌شده پرکنندهٔ نارنجی خود را برای نمایش رنگ عادی حفظ می‌کند و برای برنامه‌هایی که تنظیمات نمایش سیاه‑سفید را رعایت می‌کنند، درخواست رنگ‌نگاری خاکستری می‌کند:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

در حالت رنگ عادی، مستطیل پرکنندهٔ نارنجی خود را حفظ می‌کند. در یک جریان کاری نمایش سیاه‑سفید، به‌دلیل تنظیم حالت روی `Gray`، رنگ‌نگاری خاکستری استفاده می‌شود. این امکان را می‌دهد تا همان اسلاید رنگ‌پایهٔ کامل را حفظ کنید در حالی که نمای متفاوتی برای چاپ، پیش‌نمایش یا سایر جریان‌های کاری که تنظیمات نمایش سیاه‑سفید ارائه را رعایت می‌کنند، تعریف کنید.

## **بازنشانی قالب‌بندی**

از [ISlide.reset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#reset--) برای بازگرداندن موقعیت، اندازه و قالب‌بندی نگه‌دارنده‌های اسلاید از نگه‌دارنده‌های متناظر طرح‌بندی استفاده کنید. این مثال به یک ارائهٔ موجود که نگه‌دارنده‌های مرتبط با طرح‌بندی دارد نیاز دارد و قبل از ذخیره‌سازی هر اسلاید را بازنشانی می‌کند. شکل‌هایی که نگه‌دارندهٔ متناظر در طرح‌بندی ندارند بازنشانی نمی‌شوند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        slide.reset();
    }

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**آیا قالب‌بندی شکل بر حجم نهایی فایل ارائه تأثیر می‌گذارد؟**

رنگ‌ها، سبک‌های خط و تنظیمات افکت معمولاً داده کمی اضافه می‌کنند نسبت به تصاویر و رسانه‌های جاسازی‌شده. پرکننده‌های تصویری می‌توانند حجم فایل را افزایش دهند چون تصویرشان در ارائه ذخیره می‌شود.

**چگونه می‌توانم شکل‌هایی را در یک اسلاید که قالب‌بندی یکسانی دارند شناسایی کنم تا بتوانم آنها را گروه‌بندی کنم؟**

ویژگی‌های کلیدی قالب‌بندی هر شکل — پرکننده، خط و تنظیمات افکت — را مقایسه کنید. اگر همهٔ مقادیر متناظر برابر باشند، سبک‌هایشان را یکسان درنظر بگیرید و به‌صورت منطقی آن‌ها را گروه‌بندی کنید که مدیریت بعدی سبک را ساده‌تر می‌کند.

**آیا می‌توانم یک مجموعه از سبک‌های سفارشی شکل را در فایلی جداگانه ذخیره کنم تا در ارائه‌های دیگر استفاده کنم؟**

بله. شکل‌های نمونه با سبک‌های دلخواه را در یک اسلاید قالب یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد یک ارائهٔ جدید، قالب را باز کنید، شکل‌های سبک‌دار موردنیاز را کلون کنید و قالب‌بندی آن‌ها را در هر جایی که نیاز است، مجدداً اعمال کنید.