---
title: قالب‌بندی اشکال پاورپوینت در جاوا
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/java/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- اثر اسکچ
- خط شکل اسکچ
- قالب‌بندی سبک جوین
- پرکردن گرادیان
- پرکردن الگو
- پرکردن تصویر
- پرکردن بافت
- پرکردن رنگ جامد
- شفافیت شکل
- رندرینگ شکل سیاه‑سفید
- رندرینگ شکل مقیاس خاکستری
- چرخاندن شکل
- اثر بویل سه‌بعدی
- اثر چرخش سه‌بعدی
- بازنشانی قالب‌بندی
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه در Java با استفاده از Aspose.Slides اشکال PowerPoint را قالب‌بندی کنید—پر، خط و سبک‌های اثر را برای فایل‌های PPT و PPTX با دقت و کنترل کامل تنظیم کنید."
---
## **مقدمه**

با تنظیم خطوط مرزی، پرکردن‌ها و اثرات، اشکال در PowerPoint را قالب‌بندی کنید. Aspose.Slides for Java به شما امکان می‌دهد این تنظیمات را به‌صورت برنامه‌نویسی کنترل کنید، از جمله شفافیت، چرخش و قالب‌بندی سه‌بعدی.

![گزینه‌های قالب‌بندی شکل در PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Java رابط‌ها و متدهایی ارائه می‌دهد که به شما اجازه می‌دهد اشکال را با همان گزینه‌های موجود در PowerPoint قالب‌بندی کنید.

## **قالب‌بندی خطوط**

از [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) برای کنترل خط مرزی یک شکل استفاده کنید. این مثال یک مستطیل بدون پرکردن با یک خط آبی، خط‌چین ایجاد می‌کند. [ILineFormat.setStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setStyle-byte-) خط ترکیبی ضخیم-نازک را انتخاب می‌کند، در حالی که [ILineFormat.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) عرض آن را به ۷ پوینت تنظیم می‌کند و [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) الگوی خط‌چین را انتخاب می‌نماید.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![خطوط قالب‌بندی‌شده در ارائه](formatted-lines.png)

### **تنظیم الگوهای خط‌چین سفارشی**

زمانی که سبک‌های پیش‌تعریف‌شده خطوط طول‌ها و فواصل مورد نیاز شما را فراهم نمی‌کنند، از [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCustomDashPattern-float---) استفاده کنید، برای مثال برای خطوط برند یا نمودارهای فنی. اختصاص یک الگو به‌صورت خودکار سبک خط‌چین را به [LineDashStyle.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) تغییر می‌دهد.

مقادیر آرایه به‌صورت متناوب بین طول خط و فاصله جفت می‌شوند، با یک خط آغاز می‌شود. هر مقدار چندبرابر عرض خط است: `{ 4, 2 }` با عرض ۳ پوینت یک خط ۱۲ پوینتی سپس فاصله ۶ پوینتی تولید می‌کند. از جفت مقادیر محدود، غیرمنفی برای تعریف بخش‌های کامل خط و فاصله استفاده کنید. این مثال از مقادیر مثبت استفاده می‌کند تا هر خط و فاصله دیده شوند.

این مثال پنج خط آبی با طول یکسان و نوک صاف ایجاد می‌کند. سه خط اول الگوها را با عرض ۳ پوینت مقایسه می‌کنند. چهارم الگوی اول را با دو برابر عرض تکرار می‌کند و هر دو طول خط و فاصله را دو برابر می‌کند. پنجم از الگوی سفارشی به خط یک‌دانه سوئیچ می‌کند.

```java
import com.aspose.slides.*;
import java.awt.Color;

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
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        line.getLineFormat().setCapStyle(LineCapStyle.Flat);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setCustomDashPattern(patterns[i]);
    }

    // خط آخر را به سبک یکدست برمی‌گردانیم.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای بازگشت به یک سبک خط‌چین پیش‌تعریف‌شده، به‌جای آن [LineDashStyle.Dash](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) را به [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) منتقل کنید. سبک انتخاب‌شده ظاهر خط را کنترل می‌کند.

نتیجه در PowerPoint، از بالا به پایین: **{4, 2}, 3 pt**؛ **{1, 2}, 3 pt**؛ **{6, 2, 1, 2}, 3 pt**؛ **{4, 2}, 6 pt**؛ و **Solid, 3 pt**.

![سه الگوی خط‌چین سفارشی، یک خط گسترده‌تر با الگوی اول، و یک خط یک‌دانه در PowerPoint](custom-dash-patterns.png)

### **تنظیم نوک خط**

از [ILineFormat.setCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCapStyle-byte-) برای تنظیم انتهای یک خط باز استفاده کنید. کلاس [LineCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linecapstyle/) سه سبک صریح نوک را ارائه می‌دهد:

- `Flat`: خط در نقطه انتها متوقف می‌شود.
- `Round`: یک نوک نیم‌دایره‌ای نصف عرض خط فراتر از نقطه انتها گسترش می‌یابد.
- `Square`: یک نوک مربعی نصف عرض خط فراتر از نقطه انتها گسترش می‌یابد.

این کلاس همچنین `NotDefined` را شامل می‌شود که به این معنی است که هیچ نوک صریحی اختصاص داده نشده است.

نوک‌ها متفاوت از سرهای پیکانی هستند که نمادهایی به انتهای خط اضافه می‌کنند و از جوین‌ها که گوشه‌های بین بخش‌های خط را کنترل می‌کنند. این مثال با استفاده از [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) و [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-) سرهای پیکانی را غیرفعال می‌کند تا فقط شکل‌های نوک مقایسه شوند.

مثال زیر سه خط افقی تقریباً одинаковی، با عرض ۲۰ پوینت، ایجاد می‌کند. از بالا به پایین، نوک‌های flat، round و square استفاده می‌شود. نقاط انتهایی آن‌ها مختصات افقی یکسانی دارند؛ نوک‌های round و square ۱۰ پوینت بیش از هر انتها گسترش می‌یابند.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] capStyles = new byte[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

    for (int i = 0; i < capStyles.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
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

![نوک‌های flat، round و square روی خطوط ضخیم یکسان در PowerPoint](line-caps.png)

## **اعمال اثرات Sketch به خطوط شکل**

یک اثر sketch ظاهر خط شکل را شبیه‌سازی می‌کند که به‌صورت دستی کشیده شده است. از [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) برای دسترسی به تنظیمات خط، [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getSketchFormat--) برای دسترسی به تنظیمات sketch، و [ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#setSketchType-int-) برای انتخاب مقدار از کلاس [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) استفاده کنید.

کد Java زیر نشان می‌دهد چگونه یک اثر [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) اعمال شود، مقدار اختصاصی خوانده شود و اثر با [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) حذف گردد:

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

مقداری که توسط [ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#getSketchType--) بازگردانده می‌شود، تنظیمی است که مستقیماً به شکل اختصاص یافته است. اگر قالب‌بندی خط بتواند از یک تم، اسلاید اصلی یا اسلاید چیدمان به ارث برسد، از [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--)، دسترسی به [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--) و خواندن [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/#getSketchType--) استفاده کنید. مقدار موثر نشان‌دهنده قالب‌بندی است که پس از حل ارث‌بری واقعاً اعمال می‌شود. این مثال نیاز به یک ارائه موجود دارد که حداقل یک شکل در اولین اسلاید داشته باشد و هر دو مقدار را چاپ می‌کند:

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

## **قالب‌بندی سبک‌های جوین**

در اینجا سه گزینه نوع جوین موجود است:

* Round
* Miter
* Bevel

سبک جوین تعیین می‌کند دو بخش مرزی چگونه در گوشه به هم می‌پیوندند. برای گوشه‌های گرد، **Round** را، برای گوشه‌های تیز **Miter** را و برای گوشه‌های صاف **Bevel** را استفاده کنید.

![سبک جوین در ارائه](join-style-powerpoint.png)

این مثال سه مستطیل سیاه با خطوط مرزی آبی ۱۵ پوینت ایجاد می‌کند. از [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) برای تنظیم مقادیر miter، bevel و round در [LineJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/) به ترتیب استفاده می‌شود تا نحوه کشیده شدن گوشه‌ها مقایسه شود.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

### **محدود کردن جوین‌های Miter در گوشه‌های تیز**

از [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setMiterLimit-float-) همراه با [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) تنظیم‌شده به [LineJoinStyle.Miter](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/) برای محدود کردن میزان گسترش یک گوشه تیز استفاده کنید.

محدودیت نسبت فاصله داخلی و خارجی جوین به عرض خط است. برای مثال، مقدار `8` اجازه می‌دهد طول miter تا هشت برابر عرض خط باشد؛ این یک اندازه بر حسب پوینت نیست. اگر گوشه از این حد عبور کند، PowerPoint یک جوین bevel شده در آن گوشه استفاده می‌کند. حد بزرگ‌تر نقاط تیزتر را امکان می‌دهد. این تنظیم فقط بر جوین‌های miter تأثیر می‌گذارد و تغییر آن زمانی که گوشه در هر دو حد باقی بماند، تأثیر دیده‌پذیری ندارد.

این مثال دو مثلث بدون پرکردن یکسان با خطوط مرزی ۲۰ پوینت ایجاد می‌کند. مثلث سمت چپ حد `2` و سمت راست حد `8` دارد. هر مثلث ۸۰ پوینت عرض و ۱۶۰ پوینت ارتفاع دارد که نسبت طول miter به عرض خط آن تقریباً `4.12` است. در نتیجه PowerPoint نوک چپ را bevel می‌کند و نوک راست را حفظ می‌کند.

```java
import com.aspose.slides.*;
import java.awt.Color;

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
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
        triangle.getLineFormat().setMiterLimit(miterLimits[i]);
    }

    presentation.save("miter_limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه در PowerPoint: **Miter limit 2** در چپ و **miter limit 8** در راست.

![یک نوک bevel شده با حد miter 2 و یک نوک نوک‌دار با حد miter 8 در PowerPoint](miter-limits.png)

## **پرکردن گرادیان**

پرکردن گرادیان رنگ‌ها را در یک شکل ترکیب می‌کند. این مثال یک بیضی را با گرادیان خطی با زاویه ۴۵ درجه از قرمز به بنفش با استفاده از [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getGradientFormat--) پر می‌کند. متد [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/java/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) رنگ توقف‌ها را در ۰ و ۱، یعنی ابتدای و انتهای گرادیان، قرار می‌دهد. پاک کردن توقف‌های موجود تضمین می‌کند فقط این دو رنگ استفاده شوند.

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

![بیضی با پرکردن گرادیان](gradient-fill.png)

اگر یک گرادیان در تصویر استخراج‌شده ظاهری متفاوت نسبت به PowerPoint داشته باشد، به بخش [Choose a Gradient Rendering Style](/slides/fa/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) مراجعه کنید. می‌توانید یک سبک رندرینگ را بدون تغییر پرکردن گرادیان ذخیره‌شده در ارائه انتخاب کنید.

### **تنظیم زاویه گرادیان خطی**

از [IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) برای کنترل جهت یک پرکردن [GradientShape.Linear](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/) استفاده کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود و ساعتگرد افزایشی دارد: `0` از چپ به راست، `90` از بالا به پایین، `180` از راست به چپ، و `270` از پایین به بالا. زوایای کسری نیز پشتیبانی می‌شوند. زوایای متناهی خارج از بازه `[0, 360)` به یک دور کامل عادی می‌شوند؛ برای مثال `-45` به `315` و `360` به `0` تبدیل می‌شود.

این مثال شش مستطیل با توقف‌های قرمز، سبز و آبی یکسان در موقعیت‌های `0`، `0.5` و `1` ایجاد می‌کند. مقیاس‌گذاری غیرفعال است تا زاویه مستقل از نسبت‌های مستطیل‌ها مقایسه شود. زوایا، از چپ به راست، در ردیف اول `0`، `45` و `90` و در ردیف دوم `135`، `180` و `270` هستند.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![گرادیان‌های خطی با زوایای 0، 45 و 90 درجه در ردیف بالا، و 135، 180 و 270 درجه در ردیف پایین](linear-gradient-angles.png)

### **مقیاس‌گذاری گرادیان خطی با شکل**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) یک مقدار [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) می‌پذیرد. به‌صورت صریح به `False` تنظیم کنید تا زاویه هندسی گرادیان با تغییر نسبت‌های شکل ثابت بماند، یا به `True` تا گرادیان با عرض و ارتفاع شکل مقیاس‌بندی شود. با فعال‌سازی مقیاس‌بندی، زاویه قابل مشاهده می‌تواند در یک شکل غیرمربع متفاوت از زاویه تعیین‌شده باشد.

مثال زیر از زاویه `45` درجه و همان توقف‌های رنگی که در مقایسه زاویه استفاده شد، استفاده می‌کند. ستون چپ `False` و ستون راست `True` است. هر ستون شامل یک مستطیل گسترده در بالا و یک مستطیل بلند در پایین است. هر دو با همان ابعاد گسترده شروع می‌شوند؛ تغییر عرض و ارتفاع مستطیل دوم نشان می‌دهد پرکردن چگونه بدون تغییر تنظیمات گرادیان به اندازه‌گیری مجدد پاسخ می‌دهد.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

نتیجه در PowerPoint، با مقیاس‌گذاری غیرفعال در چپ و فعال در راست:

![مستطیل‌های پهن و بلند با یک گرادیان 45 درجه، مقایسه LinearGradientScaled False در چپ با True در راست](linear-gradient-scaling.png)

با مقیاس‌گذاری غیرفعال، نوارهای رنگی قطری در هر دو مستطیل همان جهت را حفظ می‌کنند. با مقیاس‌گذاری فعال، نوارها با نسبت‌های شکل کشیده می‌شوند. این به بازتولید گرادیان یک قالب هنگام تطبیق شکل با اندازه متفاوت کمک می‌کند. در یک مربع، فعال‌سازی مقیاس‌گذاری ظاهر این گرادیان `45` درجه را تغییر نمی‌دهد.

هر دو تنظیم زاویه و مقیاس‌گذاری بر گرادیان‌های خطی اعمال می‌شوند. آنها بر پرکردن‌های [GradientShape.Radial یا GradientShape.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/) تأثیری ندارند.

### **ترکیب زاویه با جهت گرادیان**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setGradientDirection-int-) یک سبک گرادیان را از کلاس [GradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/gradientdirection/) انتخاب می‌کند؛ این جایگزین زاویه عددی نیست. برای یک گرادیان خطی، سبک‌های گوشه می‌توانند ناحیه توزیع رنگ‌ها را بدون تغییر زاویه تعیین‌شده توسط [setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) تغییر دهند. هنگام مقایسه زوایا یا مقیاس‌گذاری، جهت را ثابت نگه دارید.

مثال زیر همان تنظیمات را در ترتیب‌های مخالف اعمال می‌کند. دو مستطیل ظاهر یکسانی دارند: اختصاص جهت قبل یا بعد از زاویه نتیجه را تغییر نمی‌دهد.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **پر کردن الگو**

یک پرکردن الگو یک طرح دو رنگی مانند نقطه‌ها، نوارها یا شطرنج‌ها را اعمال می‌کند. این مثال از [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) برای انتخاب یک الگوی trellis استفاده می‌کند. [IPatternFormat.getBackColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getBackColor--) پس‌زمینه خاکستری روشن را فراهم می‌کند و [IPatternFormat.getForeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getForeColor--) رنگ زرد الگو را فراهم می‌کند.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Pattern);
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![مستطیل با پرکردن الگو](pattern-fill.png)

## **پر کردن تصویر**

یک پرکردن تصویر یک تصویر را داخل یک شکل استفاده می‌کند. این مثال به یک تصویر محلی نیاز دارد و از [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) برای بارگذاری آن به مجموعه تصویر ارائه استفاده می‌کند. تنظیم [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) به حالت tiled تصویر را داخل مستطیل تکرار می‌کند. تصویر منبع استفاده‌شده در زیر نشان داده شده است:

![تصویر لوتوس](lotus.png)

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

![شکل با پرکردن تصویر](picture-fill.png)

### ** tiled کردن تصویر به عنوان بافت**

اگر می‌خواهید یک تصویر tiled را به‌عنوان بافت تنظیم کنید و رفتار تایلینگ را سفارشی کنید، می‌توانید از روش‌های زیر اینترفیس [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) استفاده کنید:

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): حالت پرکردن تصویر را تنظیم می‌کند — `Tile` یا `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): تراز تایل‌ها داخل شکل را مشخص می‌کند.
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): تعیین می‌کند تایل به‌صورت افقی، عمودی یا هر دو وارونه شود.
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): افست افقی تایل (به پوینت) از مبدأ شکل را تنظیم می‌کند.
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): افست عمودی تایل (به پوینت) از مبدأ شکل را تنظیم می‌کند.
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): مقیاس افقی تایل را به درصد تعریف می‌کند.
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): مقیاس عمودی تایل را به درصد تعریف می‌کند.

این مثال به یک تصویر محلی نیاز دارد و [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) را تنظیم می‌کند تا آن را با ۵۰٪ اندازه اصلی تکرار کند. افست‌های ‑32 پوینت تایل‌ها را به‌صورت افقی و عمودی جابجا می‌کند؛ تراز پایین‑راست و وارون شدن در هر دو جهت نحوهٔ چینش بافت تکرار شده را تعیین می‌کند.

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

![گزینه‌های تایل](tile-options.png)

## **پر کردن رنگ جامد**

یک پرکردن جامد یک شکل را با یک رنگ یکنواخت می‌دهد. این مثال از [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) برای تنظیم حالت پرکردن جامد استفاده می‌کند و رنگ زرد را از طریق [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) اختصاص می‌دهد، سپس مستطیل را در یک ارائه ذخیره می‌کند.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![شکل با پرکردن رنگ جامد](solid-color-fill.png)

### **کپی کردن رنگ‌ها با حفظ ارجاعات تم**

از [IColorFormat.copyFrom](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#copyFrom-com.aspose.slides.IColorFormat-) برای کپی کردن تعریف رنگ، شامل نوع رنگ، ارجاع به تم و تبدیل‌ها استفاده کنید. این برای انتقال رنگ پرکردن بین شکل‌هایی که باید ادامه دهند تم ارائه را دنبال کنند مفید است. متد فقط رنگ را کپی می‌کند: نوع پرکردن، خط مرزی یا دیگر قالب‌بندی‌های شکل را کپی نمی‌کند. نوع پرکردن مقصد را به‌صورت صریح با [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) تنظیم کنید.

این مثال سه مستطیل، از چپ به راست: منبع، کپی آگاه به تم و کپی RGB ثابت ایجاد می‌کند. منبع با استفاده از [IColorFormat.setSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#setSchemeColor-int-) به اولین رنگ accent ارجاع می‌دهد و از طریق [IColorOperationCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/icoloroperationcollection/#add-int-float-) یک سایه اضافه می‌کند. کپی RGB از رنگ پرکردن موثر منبع استفاده می‌کند به‌طوری‌که هر سه در ابتدا یک‌سان به نظر برسند. فراخوانی [IColorFormat.setColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#setColor-java.awt.Color-) مقدار RGB ثابت تنظیم می‌کند و هر تبدیل رنگ موجود را پاک می‌کند.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(new Color(65, 105, 225));

    IAutoShape source = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 40, 180, 140);
    IAutoShape themeCopy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 240, 40, 180, 140);
    IAutoShape rgbCopy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 450, 40, 180, 140);

    for (IAutoShape shape : new IAutoShape[] { source, themeCopy, rgbCopy }) {
        shape.getFillFormat().setFillType(FillType.Solid);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    }

    IColorFormat sourceColor = source.getFillFormat().getSolidFillColor();
    sourceColor.setSchemeColor(SchemeColor.Accent1);
    sourceColor.getColorTransform().add(ColorTransformOperation.Tint, 0.75f);

    themeCopy.getFillFormat().getSolidFillColor().copyFrom(sourceColor);
    rgbCopy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor());

    IImage before = slide.getImage(1f, 1f);
    try {
        before.save("color-copy-before.png", ImageFormat.Png);
    } finally {
        before.dispose();
    }

    // ارجاعات تم پس از رنگ accent جدید دنبال می‌شوند؛ مقدار RGB ثابت این‌گونه نیست.
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(new Color(255, 69, 0));

    IImage after = slide.getImage(1f, 1f);
    try {
        after.save("color-copy-after.png", ImageFormat.Png);
    } finally {
        after.dispose();
    }
    presentation.save("copied_colors.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

قبل از تغییر تم، هر سه پرکردن یکسان هستند:

![منبع، مقصد copyFrom و مقصد RGB ثابت با پرکردن آبی یکسان](color-copy-before.png)

بعد از تغییر تم، منبع و کپی آگاه به تم رنگ accent جدید را دنبال می‌کنند و سایه خود را حفظ می‌کنند. کپی RGB ثابت آبی می‌ماند:

![منبع و مقصد copyFrom با پرکردن نارنجی، در حالی که مقصد RGB ثابت آبی می‌ماند](color-copy-after.png)

تعریف کپی‌شده مستقل از منبع است. تغییر بعدی ارجاع تم منبع، اختصاص رنگ دیگر یا افزودن/حذف تبدیل‌ها، مقصد را تغییر نمی‌دهد. تغییر تم همچنان هر دو شکل را تحت تأثیر قرار می‌دهد زیرا هر یک به‌صورت مستقل به همان رنگ تم ارجاع می‌دهند.

ذخیره و باز کردن مجدد PPTX نوع رنگ کپی‌شده بازگردانده‌شده توسط [IColorFormat.getColorType](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#getColorType--)، ارجاع تم و مجموعه تبدیل‌های بازگردانده‌شده توسط [IColorFormat.getColorTransform](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#getColorTransform--) را حفظ می‌کند؛ این تعریف را به RGB صاف نمی‌کند.

هنگام کپی بین زمینه‌های تم مختلف، مانند ارائه‌هایی با پالت‌های accent متفاوت، ارجاع کپی‌شده در مقابل تم مقصد حل می‌شود. بنابراین همان ارجاع و تبدیل‌ها می‌توانند رنگ قابل مشاهده متفاوتی تولید کنند. به بخش [Presentation Theme](/slides/fa/java/presentation-theme/) برای اطلاعات بیشتر درباره پیکربندی رنگ‌های تم مراجعه کنید.

## **استفاده از پس‌زمینه اسلاید به‌عنوان پرکردن شکل**

از [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) وقتی که یک شکل باید با پس‌زمینه اسلاید مطابقت داشته باشد، مثلاً در یک قالب ارائه، استفاده کنید. ابتدا نوع پرکردن را با [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) به [FillType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) تنظیم کنید تا هر پرکردن صریحی حذف شود. با این ترکیب، شکل به‌جای پرکردن سبک خود از پس‌زمینه اسلاید استفاده می‌کند. فعال‌سازی این پرچم به‌تنهایی پرکردن صریح موجود را حذف نمی‌کند.

این متفاوت از [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) است: پرکردن پس‌زمینه اشیائی پشت شکل را با ناحیه متناظر پس‌زمینه اسلاید پوشش می‌دهد، در حالی که NoFill آن اشیا را قابل مشاهده می‌گذارد. یک گرادیان همچنان با اسلاید هم‌راستا می‌ماند نه اینکه داخل هر شکل دوباره شروع شود.

مثال زیر یک پس‌زمینه مستر که توسط اسلاید به ارث می‌رسد ایجاد می‌کند و یک نوار مژنتا را پشت سه مستطیل قرار می‌دهد. مستطیل چپ از پس‌زمینه استفاده می‌کند، مستطیل میانی هیچ پرکردنی ندارد، و مستطیل راست از پرکردن پس‌زمینه به یک پرکردن نارنجی صریح سوئیچ می‌کند.

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    gradient.getGradientStops().add(0, new Color(0, 0, 139));
    gradient.getGradientStops().add(1, new Color(135, 206, 250));

    // این آبجکت را ابتدا اضافه کنید تا پشت مستطیل‌ها ظاهر شود.
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

    // غیرفعال کردن پرکردن پس‌زمینه قبل از اعمال یک پرکردن صریح.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه، از چپ به راست: **پرکردن پس‌زمینه**، **بدون پرکردن** و **پرکردن صریح**. نوار مژنتا توسط مستطیل‌های چپ و راست مخفی می‌شود اما از طریق مستطیل میانی قابل رؤیت است.

![پرکردن پس‌زمینه، بدون پرکردن و پرکردن صریح نارنجی روی نوار مژنتا](background-fill.png)

رفتار یکسانی برای پس‌زمینه‌ای که مستقیماً روی اسلاید تعریف شده یا از یک Layout به ارث رسیده، اعمال می‌شود. شکل از پس‌زمینه حل‌شده اسلاید استفاده می‌کند؛ مثال هر دو پس‌زمینه اسلاید و Layout را تعریف‌نشده می‌گذارد تا مستر آن را فراهم کند.

## **تنظیم شفافیت**

برای یک پرکردن جامد، مؤلفه آلفا رنگ، شفافیت را کنترل می‌کند: ۰ کاملاً شفاف و ۲۵۵ کاملاً مات است. این مثال از مقدار آلفا ۱۲۸ برای یک مستطیل زرد استفاده می‌کند که تقریباً ۵۰٪ شفاف است، بنابراین مستطیل زیرین قابل رؤیت می‌ماند. رنگ از طریق [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) اختصاص داده می‌شود.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 128));

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![شکل شفاف](shape-transparency.png)

## **چرخاندن اشکال**

از [IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) برای چرخاندن یک شکل در صفحه اسلاید استفاده کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود؛ این مثال یک مستطیل را ۵ درجه ساعتگرد می‌چرخاند و ارائه را ذخیره می‌کند.

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

## **اضافه‌کردن اثرات Bevel سه‌بعدی**

از [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) برای افزودن عمق و لبه‌های برجسته به یک شکل استفاده کنید. این مثال یک بیضی سبز با خط مرزی نارنجی ایجاد می‌کند، از [IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) برای تنظیم عمق به ۴ پوینت استفاده می‌کند و یک bevel بالایی دایره‌ای با عرض و ارتفاع ۶ پوینت از طریق [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--) اعمال می‌نماید. یک دوربین ارتوگرافیک روبه‌رو و نورپردازی سه‌نقطه‌ای باعث مشاهده واضح bevel می‌شود.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
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

![اثر Bevel سه‌بعدی](3D-bevel-effect.png)

## **اضافه‌کردن اثرات چرخش سه‌بعدی**

نمایش سه‌بعدی یک شکل توسط تنظیمات دوربین آن کنترل می‌شود. این مثال از [ICamera.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-) با زوایای عرض، طول و انقلاب به ترتیب ۴۰، ۳۵ و ۲۰ درجه استفاده می‌کند. یک دوربین ایزومتریک از طریق [ICamera.setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) و نورپردازی متعادل از طریق [ILightRig.setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-) انتخاب می‌شود، سپس مستطیل قالب‌بندی‌شده ذخیره می‌شود.

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

![اثر چرخش سه‌بعدی](3D-rotation-effect.png)

## **کنترل رندرینگ سیاه‌سفید برای اشکال**

متد [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) تعیین می‌کند یک شکل به‌تنهایی هنگام نمایش یا پردازش ارائه در حالت سیاه‌سفید چگونه رندر شود. این خود به‌تنهایی حالت سیاه‌سفید را فعال نمی‌کند و قالب‌بندی پر، خط یا دیگر تنظیمات رنگی شکل را در حالت رنگ عادی تغییر نمی‌دهد.

از مقداری از کلاس [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) برای انتخاب رفتار موردنظر استفاده کنید. برای مثال، `Automatic` اجازه می‌دهد برنامه رندرینگ تبدیل را انتخاب کند، `Gray` و `LightGray` رنگ‌گذاری خاکستری را استفاده می‌کنند، `BlackWhite` فقط سیاه و سفید را به کار می‌برد، `Black` و `White` یک رنگ ثابت را اعمال می‌کنند، `Color` رنگ عادی را حفظ می‌کند و `Hidden` شکل را در حالت سیاه‌سفید حذف می‌کند. `NotDefined` به این معنی است که هیچ حالت سطح‑شکل اختصاص داده نشده است.

این مثال یک مستطیل نارنجی ایجاد می‌کند و از [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) برای تنظیم حالت به gray استفاده می‌کند. شکل ذخیره‌شده پرکردن نارنجی خود را برای نمایش رنگ عادی حفظ می‌کند و برای برنامه‌هایی که تنظیمات نمایش سیاه‌سفید را رعایت می‌کنند، درخواست رنگ‌گذاری خاکستری می‌کند:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

در حالت رنگ عادی، مستطیل پرکردن نارنجی خود را حفظ می‌کند. در یک جریان کاری نمایش سیاه‌سفید، از رنگ‌گذاری خاکستری استفاده می‌کند زیرا حالت آن به `Gray` تنظیم شده است. این امکان را می‌دهد که اسلاید رنگ کامل را حفظ کنید و ظاهر متفاوتی برای چاپ، پیش‌نمایش یا سایر جریان‌های کاری که تنظیمات نمایش سیاه‌سفید ارائه را رعایت می‌کنند، تعریف کنید.

## **بازنشانی قالب‌بندی**

از [ISlide.reset](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#reset--) برای بازگرداندن موقعیت، اندازه و قالب‌بندی موارد نگه‌دارنده اسلاید از موارد متناظر در چیدمان استفاده کنید. این مثال به یک ارائه موجود با موارد نگه‌دارنده مرتبط به چیدمان نیاز دارد و قبل از ذخیره همه اسلایدها را بازنشانی می‌کند. اشکالی که مورد نگه‌دارنده متناظر در چیدمان ندارند، بازنشانی نمی‌شوند.

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

رنگ‌ها، سبک‌های خط و تنظیمات اثر معمولاً داده کمی نسبت به تصاویر و رسانه‌های جاسازی‌شده اضافه می‌کنند. پرکردن‌های تصویری می‌توانند حجم فایل را افزایش دهند زیرا تصاویر آن‌ها در ارائه ذخیره می‌شوند.

**چگونه می‌توانم اشکالی را که در یک اسلاید قالب‌بندی یکسان دارند شناسایی کنم تا بتوانم آن‌ها را گروه‌بندی کنم؟**

هر ویژگی کلیدی قالب‌بندی شکل را—پرکردن، خط و تنظیمات اثر—مقایسه کنید. اگر تمام مقادیر متناظر مطابق باشند، سبک‌های آن‌ها را یکسان در نظر بگیرید و به‌طور منطقی آن اشکال را گروه‌بندی کنید، که مدیریت سبک بعدی را ساده می‌کند.

**آیا می‌توانم یک مجموعهٔ سفارشی از سبک‌های شکل را در فایلی جداگانه ذخیره کنم تا در ارائه‌های دیگر دوباره استفاده کنم؟**

بله. اشکال نمونه با سبک‌های دلخواه را در یک اسلاید قالب یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد یک ارائه جدید، قالب را باز کنید، اشکال سبک‌دار موردنیاز را کلون کنید و قالب‌بندی آن‌ها را هرجا که نیاز باشد مجدداً اعمال کنید.