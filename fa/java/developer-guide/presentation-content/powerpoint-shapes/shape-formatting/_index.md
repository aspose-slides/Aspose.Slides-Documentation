---
title: قالب‌بندی اشکال PowerPoint در جاوا
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/java/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- اثر طرح‌خطی
- خط طرح‌خطی شکل
- قالب‌بندی سبک اتصال
- پرکنندهٔ گرادیان
- پرکنندهٔ الگو
- پرکنندهٔ تصویر
- پرکنندهٔ بافت
- پرکنندهٔ رنگ ثابت
- شفافیت شکل
- رندر سیاه‑سفید شکل
- رندر خاکستری شکل
- چرخاندن شکل
- افکت برآمدگی 3D
- افکت چرخش 3D
- بازنشانی قالب‌بندی
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه در جاوا با استفاده از Aspose.Slides اشکال PowerPoint را قالب‌بندی کنید — پرکننده، خط و سبک‌های افکت را برای فایل‌های PPT و PPTX با دقت و کنترل کامل تنظیم کنید."
---
## **معرفی**

شکل‌ها را در PowerPoint با تنظیم خطوط مرزی، پرکننده‌ها و افکت‌ها قالب‌بندی کنید. Aspose.Slides for Java به شما امکان می‌دهد این تنظیمات را به صورت برنامه‌نویسی کنترل کنید، از جمله شفافیت، چرخش و قالب‌بندی 3D.

![گزینه‌های قالب‌بندی شکل در PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Java رابط‌ها و متدهایی را فراهم می‌کند که به شما اجازه می‌دهد شکل‌ها را با استفاده از همان گزینه‌های موجود در PowerPoint قالب‌بندی کنید.

## **قالب‌بندی خطوط**

از [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) برای کنترل خطوط مرزی یک شکل استفاده کنید. این مثال یک مستطیل بدون پرکننده با یک خطوط مرزی آبی و نقطه‌دار ایجاد می‌کند. [ILineFormat.setStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setStyle-byte-) یک خط ترکیبی ضخیم‑نازک را انتخاب می‌کند، در حالی که [ILineFormat.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) عرض آن را به ۷ پوینت تنظیم می‌کند و [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) الگوی نقطه‌دار را انتخاب می‌کند.

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

![خطوط قالب‌بندی شده در ارائه](formatted-lines.png)

### **تنظیم الگوهای خط نقطه‌دار سفارشی**

از [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCustomDashPattern-float:A-) وقتی سبک‌های پیش‌تعریف‌شده طول‌ها و فواصل نقطه‌دار مورد نیاز شما را فراهم نمی‌کنند، برای مثال برای خطوط برند یا نمودارهای فنی، استفاده کنید. اختصاص یک الگو به طور خودکار سبک نقطه‌دار خط را به [LineDashStyle.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) تغییر می‌دهد.

ورودی‌های آرایه به طور متناوب بین طول نقطه و فاصله جفت می‌شوند، از یک نقطه شروع می‌شود. هر مقدار مضربی از عرض خط است: `{ 4, 2 }` با عرض ۳ پوینت یک نقطه ۱۲ پوینتی و سپس یک فاصله ۶ پوینتی تولید می‌کند. برای تعریف بخش‌های کامل نقطه‑و‑فاصله از جفت‌های مقدارهای محدود و غیرمنفی استفاده کنید. این مثال از مقادیر مثبت استفاده می‌کند تا هر نقطه و فاصله قابل رؤیت باشد.

این مثال پنج خط آبی با طول مساوی و سرهای صاف ایجاد می‌کند. سه خط اول الگوها را در عرض ۳ پوینت مقایسه می‌کنند. خط چهارم همان الگو را با دو برابر عرض تکرار می‌کند و هر دو طول نقطه و فاصله را دو برابر می‌سازد. خط پنجم از الگوی سفارشی به خط یک‌دسته‌ای تغییر می‌دهد.

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

    // آخرین خط را به سبک یک‌دسته‌ای بازگردانید.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای بازگشت به یک سبک نقطه‌دار پیش‌تعریف‌شده، به جای آن [LineDashStyle.Dash](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) را به [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) پاس بدهید. سبک انتخاب‌شده ظاهر خط را کنترل می‌کند.

نتیجه در PowerPoint، از بالا به پایین: **{4, 2}, 3 pt**؛ **{1, 2}, 3 pt**؛ **{6, 2, 1, 2}, 3 pt**؛ **{4, 2}, 6 pt**؛ و **Solid, 3 pt**.

![سه الگوی نقطه‌دار سفارشی، خطی گسترده‌تر با استفاده از الگوی اول، و یک خط یک‌دسته‌ای در PowerPoint](custom-dash-patterns.png)

### **تنظیم سرهای خط**

از [ILineFormat.setCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCapStyle-byte-) برای تنظیم انتهای یک خط باز استفاده کنید. کلاس [LineCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linecapstyle/) سه سبک صریح سر را فراهم می‌کند:

- `Flat`: ضربه در نقطهٔ انتهایی متوقف می‌شود.
- `Round`: یک سر نیم‌دایره‌ای به اندازهٔ نیمی از عرض خط از نقطهٔ انتهایی فراتر می‌رود.
- `Square`: یک سر مربع‌مانند به اندازهٔ نیمی از عرض خط از نقطهٔ انتهایی فراتر می‌رود.

این کلاس همچنین شامل `NotDefined` است که به این معنی است که هیچ سبک سر صریحی اختصاص داده نشده است.

سرها متفاوت از سرهای فلشی هستند که نمادهایی به انتهای خط اضافه می‌کنند، و از مفاصلی که گوشه‌های بین قطعات خط را کنترل می‌کنند. این مثال سرهای فلشی را از طریق [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) و [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-) غیرفعال می‌کند تا فقط اشکال سرها مقایسه شوند.

مثال زیر سه خط افقی تقریباً یکسان با عرض ۲۰ پوینت ایجاد می‌کند. از بالا به پایین، سرهای صاف، گرد و مربع استفاده می‌شوند. نقاط انتهایی آن‌ها همان مختصات افقی را دارند؛ سرهای گرد و مربع ۱۰ پوینت بیش از هر نقطهٔ انتهایی امتداد می‌یابند.

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

![سرهای صاف، گرد و مربع روی خطوط ضخیم یکسان در PowerPoint](line-caps.png)

## **اعمال افکت‌های طرح‌خطی بر خطوط شکل‌ها**

یک افکت طرح‌خطی باعث می‌شود خط شکل مثل دست‌نویس به نظر برسد. از [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) برای دسترسی به تنظیمات خط، از [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getSketchFormat--) برای دسترسی به تنظیمات طرح‌خطی، و از [ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#setSketchType-int-) برای انتخاب یک مقدار از کلاس [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) استفاده کنید.

کد جاوا زیر نشان می‌دهد چگونه یک افکت [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) اعمال شده، مقدار صریحاً اختصاص داده‌شده را بخوانید و افکت را با [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) حذف کنید:

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

مقداری که توسط [ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#getSketchType--) برگردانده می‌شود، تنظیمی را نشان می‌دهد که مستقیماً به شکل اختصاص داده شده است. اگر قالب‌بندی خط بتواند از یک تم، اسلاید مادر یا اسلاید چیدمان به ارث برده شود، از [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--) استفاده کنید، به [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--) دسترسی پیدا کنید، و [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/#getSketchType--) را بخوانید. مقدار مؤثر نمایانگر قالب‌بندی است که پس از حل وراثت واقعاً اعمال می‌شود. این مثال نیاز به یک ارائه موجود دارد که حداقل یک شکل در اولین اسلاید آن باشد و هر دو مقدار را چاپ می‌کند:

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

در اینجا سه گزینهٔ نوع اتصال آورده شده است:

* Round
* Miter
* Bevel

سبک اتصال کنترل می‌کند دو بخش خط مرزی چگونه در یک گوشه به هم می‌رسند. از **Round** برای گوشه‌های گرد، **Miter** برای گوشه‌های تیز، یا **Bevel** برای گوشه‌های مسطح استفاده کنید.

![سبک اتصال در ارائه](join-style-powerpoint.png)

این مثال سه مستطیل سیاه با خطوط مرزی آبی به عرض ۱۵ پوینت ایجاد می‌کند. از [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) برای تنظیم مقادیر miter، bevel و round کلاس [LineJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/) به ترتیب استفاده می‌کند تا مقایسه کند گوشه‌ها چگونه رسم می‌شوند.

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

### **محدود کردن اتصال‌های Miter در گوشه‌های تیز**

از [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setMiterLimit-float-) همراه با [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) که به [LineJoinStyle.Miter](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/) تنظیم شده است، برای محدود کردن میزان امتداد یک گوشهٔ تیز استفاده کنید.

محدودیت نسبت فاصله بین گوشه‌های داخلی و خارجی اتصال به عرض خط است. برای مثال، مقدار `8` اجازه می‌دهد طول miter تا هشت برابر عرض خط باشد؛ این یک اندازه‌گیری به پوینت نیست. اگر گوشه از این حد فراتر رود، PowerPoint به جای آن از یک اتصال bevel استفاده می‌کند. محدودیت بزرگ‌تر نقطه‌های تیزتر را امکان‌پذیر می‌سازد. این تنظیم فقط بر اتصال‌های miter تأثیر دارد و تغییر آن در زمانی که گوشه در هر دو حد باقی بماند، اثر قابل مشاهده‌ای ندارد.

این مثال دو مثلث یکسان بدون پرکننده با خطوط مرزی به عرض ۲۰ پوینت ایجاد می‌کند. مثلث چپ از محدودیت `2` استفاده می‌کند و مثلث راست از `8`. هر مثلث ۸۰ پوینت عرض و ۱۶۰ پوینت ارتفاع دارد که نسبت طول miter به عرض خط در گوشهٔ بالایی آن تقریباً `4.12` است. بنابراین PowerPoint گوشهٔ چپ را bevel می‌کند و گوشهٔ راست را همان‌طور که است حفظ می‌کند.

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

نتیجه در PowerPoint: **Miter limit 2** در سمت چپ و **miter limit 8** در سمت راست.

![یک نوک bevel با محدودیت miter 2 و یک نوک تیز با محدودیت miter 8 در PowerPoint](miter-limits.png)

## **پرکنندهٔ گرادیان**

یک پرکنندهٔ گرادیان رنگ‌ها را در سراسر شکل ترکیب می‌کند. این مثال یک بیضی را با یک گرادیان خطی به زاویهٔ ۴۵ درجه از قرمز به بنفش پر می‌کند با استفاده از [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getGradientFormat--). متد [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/java/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) رنگ‌های توقف را در ۰ و ۱، یعنی آغاز و پایان گرادیان قرار می‌دهد. پاک‌سازی توقف‌های موجود تضمین می‌کند تنها این دو رنگ استفاده شوند.

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

اگر یک گرادیان در تصویر صادر شده نسبت به آنچه در PowerPoint دیده می‌شود متفاوت باشد، به [Choose a Gradient Rendering Style](/slides/fa/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) مراجعه کنید. می‌توانید یک سبک رندرینگ انتخاب کنید بدون آنکه پرکنندهٔ گرادیان ذخیره‌شده در ارائه تغییر کند.

### **تنظیم زاویهٔ گرادیان خطی**

از [IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) برای کنترل جهت یک پرکنندهٔ [GradientShape.Linear](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/) استفاده کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود و ساعتگرد افزایش می‌یابد: `0` از چپ به راست، `90` از بالا به پایین، `180` از راست به چپ و `270` از پایین به بالا. زاویه‌های کسری نیز پشتیبانی می‌شوند. زاویه‌های متناهی خارج از بازهٔ `[0, 360)` به یک چرخش کامل نرمال می‌شوند؛ برای مثال `-45` به `315` و `360` به `0` تبدیل می‌شود.

این مثال شش مستطیل با توقف‌های رنگ قرمز، سبز و آبی یکسان در موقعیت‌های `0`، `0.5` و `1` ایجاد می‌کند. مقیاس‌گذاری غیرفعال است تا زاویه به‌صورت مستقل از نسبت‌های مستطیل‌ها مقایسه شود. زاویه‌ها از چپ به راست، در ردیف اول `0`، `45` و `90` و در ردیف دوم `135`، `180` و `270` هستند.

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

![گرادیان‌های خطی با زاویه‌های 0، 45 و 90 درجه در ردیف بالا، و 135، 180 و 270 درجه در ردیف پایین](linear-gradient-angles.png)

### **مقیاس‌گذاری یک گرادیان خطی با شکل**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) یک مقدار [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) می‌گیرد. آن را صریحاً به `False` تنظیم کنید تا زاویهٔ ژئومتریک گرادیان هنگام تغییر نسبت‌های شکل ثابت بماند، یا به `True` تا گرادیان با عرض و ارتفاع شکل مقیاس‌گذاری شود. با فعال بودن مقیاس‌گذاری، زاویهٔ قابل مشاهده می‌تواند در یک شکل غیر مربع متفاوت از زاویهٔ اختصاصی باشد.

مثال زیر از زاویهٔ `45` درجه و همان توقف‌های رنگی که برای مقایسه زاویه استفاده شده‌اند، استفاده می‌کند. ستون چپ از `False`، و ستون راست از `True` استفاده می‌کند. هر ستون شامل یک مستطیل عریض بالای یک مستطیل بلند است. هر دو با همان اندازه عریض شروع می‌شوند؛ تغییر عرض و ارتفاع مستطیل دوم نشان می‌دهد پرکننده چگونه بدون تغییر تنظیمات گرادیان به تغییر اندازه واکنش نشان می‌دهد.

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

نتیجه در PowerPoint، با مقیاس‌گذاری غیرفعال در سمت چپ و فعال در سمت راست:

![مستطیل‌های عریض و بلند با گرادیان 45 درجه، مقایسه LinearGradientScaled False در چپ با True در راست](linear-gradient-scaling.png)

با غیرفعال بودن مقیاس‌گذاری، نوارهای رنگی قطری همان جهت را در هر دو مستطیل حفظ می‌کنند. با فعال بودن مقیاس‌گذاری، نوارها با نسبت‌های شکل کشیده می‌شوند. این کمک می‌کند تا گرادیان یک قالب را هنگام تطبیق شکل با اندازهٔ متفاوت بازتولید کنید. در یک مربع، فعال کردن مقیاس‌گذاری ظاهر این گرادیان 45 درجه را تغییر نمی‌دهد.

هر دو تنظیم زاویه و مقیاس‌گذاری برای گرادیان‌های خطی اعمال می‌شوند. آن‌ها بر پرکننده‌های [GradientShape.Radial or GradientShape.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/) تأثیر ندارند.

### **ترکیب زاویه با جهت گرادیان**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setGradientDirection-int-) یک سبک گرادیان را از کلاس [GradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/gradientdirection/) انتخاب می‌کند؛ این جایگزین یک زاویهٔ عددی نیست. برای یک گرادیان خطی، سبک‌های گوشه می‌توانند ناحیه‌ای که رنگ‌ها در آن توزیع می‌شوند را بدون تغییر زاویه‌ای که از طریق [setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) اختصاص داده شده است، تغییر دهند. هنگام مقایسه زاویه‌ها یا مقیاس‌گذاری، جهت را بدون تغییر نگه دارید.

مثال زیر همان تنظیمات را به ترتیب مخالف اعمال می‌کند. دو مستطیل ظاهر یکسانی دارند: اختصاص جهت قبل یا بعد از زاویه نتیجه را تغییر نمی‌دهد.

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

## **پرکنندهٔ الگو**

یک پرکنندهٔ الگو یک طرح دو رنگی مانند نقطه‌ها، نوارها یا چهارخانه‌ها را اعمال می‌کند. این مثال از [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) برای انتخاب یک الگوی trellis استفاده می‌کند. [IPatternFormat.getBackColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getBackColor--) پس‌زمینهٔ خاکستری روشن را فراهم می‌کند و [IPatternFormat.getForeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getForeColor--) رنگ الگوی زرد را فراهم می‌کند.

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

![مستطیل با پرکنندهٔ الگو](pattern-fill.png)

## **پرکنندهٔ تصویر**

یک پرکنندهٔ تصویر از یک تصویر داخل شکل استفاده می‌کند. این مثال به یک تصویر محلی نیاز دارد و از [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) برای بارگذاری آن در مجموعهٔ تصاویر ارائه استفاده می‌کند. تنظیم [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) به حالت tiled تصویر را در داخل مستطیل تکرار می‌کند. تصویر منبع استفاده‌شده در زیر نشان داده شده است:

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

![شکل با پرکنندهٔ تصویر](picture-fill.png)

### **تایل کردن تصویر به‌عنوان بافت**

اگر می‌خواهید یک تصویر تایل‌شده را به‌عنوان بافت تنظیم کنید و رفتار تایل را سفارشی کنید، می‌توانید از روش‌های زیر اینترفیس [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) استفاده کنید:

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): حالت پرکنندهٔ تصویر را تنظیم می‌کند — یا `Tile` یا `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): هم‌راستایی کاشی‌ها در داخل شکل را مشخص می‌کند.
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): کنترل می‌کند آیا کاشی افقی، عمودی یا هر دو معكوس شود.
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): افست افقی کاشی (بر حسب پوینت) از مبدأ شکل را تنظیم می‌کند.
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): افست عمودی کاشی (بر حسب پوینت) از مبدأ شکل را تنظیم می‌کند.
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): مقیاس افقی کاشی را به‌عنوان درصد تعریف می‌کند.
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): مقیاس عمودی کاشی را به‌عنوان درصد تعریف می‌کند.

این مثال به یک تصویر محلی نیاز دارد و [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) را طوری تنظیم می‌کند که آن را با ۵۰٪ اندازهٔ اصلی تکرار کند. افست‌های −32 پوینت کاشی‌ها را به صورت افقی و عمودی جابه‌جا می‌کند؛ هم‌راستایی پایین‑راست و معکوس کردن در هر دو جهت تعیین می‌کند که بافت تکراری چگونه چیده شود.

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

## **پرکنندهٔ رنگ ثابت**

یک پرکنندهٔ ثابت یک شکل را به یک رنگ یکنواخت می‌دهد. این مثال از [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) برای تنظیم حالت پرکنندهٔ ثابت استفاده می‌کند و رنگ زرد را از طریق [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) اختصاص می‌دهد، سپس مستطیل را در یک ارائه ذخیره می‌کند.

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

![شکل با پرکنندهٔ رنگ ثابت](solid-color-fill.png)

## **استفاده از پس‌زمینهٔ اسلاید به‌عنوان پرکنندهٔ شکل**

از [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) زمانی که یک شکل باید با پس‌زمینهٔ اسلاید مطابقت داشته باشد، مثلا در یک قالب ارائه، استفاده کنید. ابتدا از [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) برای تنظیم به [FillType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) استفاده کنید تا هر پرکنندهٔ صریحی حذف شود. با این ترکیب، شکل به جای استفاده از پرکنندهٔ سبک خود، از پس‌زمینهٔ اسلاید استفاده می‌کند. فعال کردن پرچم به‌تنهایی پرکنندهٔ صریح موجود را حذف نمی‌کند.

این متفاوت از [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) است: پرکنندهٔ پس‌زمینه اشیاء پشت شکل را با ناحیهٔ متناظر پس‌زمینه اسلاید می‌پوشاند، در حالی که هیچ پرکننده‌ای آن اشیاء را قابل مشاهده می‌گذارد. یک گرادیان با اسلاید هم‌راستاست نه اینکه در هر شکل از نو شروع شود.

مثال زیر یک پس‌زمینهٔ مادر که توسط اسلاید ارث‌بری می‌شود ایجاد می‌کند و یک نوار ماژنتا را پشت سه مستطیل قرار می‌دهد. مستطیل چپ از پس‌زمینه استفاده می‌کند، مستطیل میانی بدون پرکننده است و مستطیل راست از پس‌زمینه به یک پرکنندهٔ نارنجی صریح تغییر می‌یابد.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    // گرادیان را از مستر ارث‌بری کنید.
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

    // پرکنندهٔ پس‌زمینه را قبل از اعمال پرکنندهٔ صریح غیرفعال کنید.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه، از چپ به راست: **پرکنندهٔ پس‌زمینه**، **بدون پرکننده** و **پرکنندهٔ صریح**. نوار ماژنتا توسط مستطیل‌های چپ و راست مخفی می‌شود اما از طریق مستطیل میانی قابل مشاهده باقی می‌ماند.

![پرکنندهٔ پس‌زمینه، بدون پرکننده، و پرکنندهٔ نارنجی صریح بر روی یک نوار ماژنتا](background-fill.png)

رفتار یکسانی برای پس‌زمینه‌ای که مستقیماً بر روی اسلاید تعریف شده یا از یک چیدمان ارث‌بری می‌شود نیز اعمال می‌شود. شکل از پس‌زمینهٔ حل‌شدهٔ اسلاید استفاده می‌کند؛ مثال هر دو پس‌زمینهٔ اسلاید و چیدمان را بدون تعریف می‌گذارد تا مادر آن را فراهم کند.

## **تنظیم شفافیت**

برای یک پرکنندهٔ ثابت، مولفهٔ آلفای رنگ شدت شفافیت را کنترل می‌کند: ۰ کاملاً شفاف و ۲۵۵ کاملاً مات است. این مثال از مقدار آلفای ۱۲۸ برای یک مستطیل زرد استفاده می‌کند، که تقریباً ۵۰٪ شفاف است تا مستطیل زیرین قابل رؤیت بماند. رنگ از طریق [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) اختصاص داده می‌شود.

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

## **چرخاندن شکل‌ها**

از [IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) برای چرخاندن یک شکل در صفحهٔ اسلاید استفاده کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود؛ این مثال یک مستطیل را ۵ درجه ساعتگرد می‌چرخاند و ارائه را ذخیره می‌کند.

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

## **افزودن افکت‌های برآمدگی 3D**

از [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) برای دادن عمق و لبه‌های برآمدگی به یک شکل استفاده کنید. این مثال یک بیضی سبز با خطوط مرزی نارنجی ایجاد می‌کند، از [IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) برای تنظیم عمق به ۴ پوینت استفاده می‌کند و یک برآمدگی بالایی دایره‌ای با عرض و ارتفاع ۶ پوینت از طریق [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--) اعمال می‌کند. یک دوربین ارتوگرافیک رو به جلو و نورپردازی سه نقطه‌ای برآمدگی را قابل مشاهده می‌کند.

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

![افکت برآمدگی 3D](3D-bevel-effect.png)

## **افزودن افکت‌های چرخش 3D**

دید 3D یک شکل توسط تنظیمات دوربین آن کنترل می‌شود. این مثال از [ICamera.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-) با زاویه‌های latitude، longitude و revolution به ترتیب ۴۰، ۳۵ و ۲۰ درجه استفاده می‌کند. با استفاده از [ICamera.setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) یک دوربین ایزومتریک انتخاب می‌شود و با [ILightRig.setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-) نورپردازی متعادل تنظیم می‌شود، سپس مستطیل قالب‌بندی‌شده ذخیره می‌شود.

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

متد [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) مشخص می‌کند یک شکل به‌تنهایی هنگام نمایش یا پردازش ارائه در حالت سیاه‑سفید چگونه رندر شود. این متد به تنهایی حالت سیاه‑سفید را فعال نمی‌کند و پرکننده، خط یا قالب‌بندی دیگر شکل را در حالت رنگ عادی تغییر نمی‌دهد.

از یک مقدار کلاس [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) برای انتخاب رفتار مورد نظر استفاده کنید. برای مثال، `Automatic` به برنامه رندر اجازه می‌دهد تبدیل را انتخاب کند، `Gray` و `LightGray` از رنگ خاکستری استفاده می‌کنند، `BlackWhite` فقط سیاه و سفید، `Black` و `White` یک رنگ ثابت، `Color` رنگ عادی را حفظ می‌کند و `Hidden` شکل را در حالت سیاه‑سفید حذف می‌کند. `NotDefined` به این معنی است که هیچ حالت سطح‑شکل تعیین نشده است.

این مثال یک مستطیل نارنجی ایجاد می‌کند و از [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) برای تنظیم حالت به خاکستری استفاده می‌کند. شکل ذخیره‌شده پرکنندهٔ نارنجی خود را برای نمایش رنگ عادی حفظ می‌کند و برای برنامه‌هایی که تنظیمات نمایش سیاه‑سفید را رعایت می‌کنند، درخواست رنگ خاکستری می‌دهد:

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

در حالت رنگ عادی، مستطیل پرکنندهٔ نارنجی خود را حفظ می‌کند. در یک جریان کاری نمایش سیاه‑سفید، از رنگ خاکستری استفاده می‌کند زیرا حالت آن روی `Gray` تنظیم شده است. این به شما امکان می‌دهد یک اسلاید تمام‑رنگ را حفظ کنید و ظاهر متفاوتی برای چاپ، پیش‌نمایش یا سایر جریان‌های کاری که تنظیمات نمایش سیاه‑سفید ارائه را رعایت می‌کنند، تعریف کنید.

## **بازنشانی قالب‌بندی**

از [ISlide.reset](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#reset--) برای بازگرداندن موقعیت، اندازه و قالب‌بندی نگهدارنده‌های اسلاید از نگهدارنده‌های متناظر در چیدمان استفاده کنید. این مثال به یک ارائه موجود با نگهدارنده‌های مرتبط با چیدمان نیاز دارد و قبل از ذخیره‌سازی هر اسلاید را بازنشانی می‌کند. شکل‌هایی که نگهدارندهٔ متناظر در چیدمان ندارند بازنشانی نمی‌شوند.

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

## **پرسش‌های متداول**

**آیا قالب‌بندی شکل بر اندازهٔ نهایی فایل ارائه تأثیر می‌گذارد؟**

رنگ‌ها، سبک‌های خط و تنظیمات افکت معمولاً دادهٔ کمی اضافه می‌کنند در مقایسه با تصاویر و رسانه‌های جاسازی‌شده. پرکننده‌های تصویری می‌توانند اندازهٔ فایل را افزایش دهند زیرا تصاویر آن‌ها در ارائه ذخیره می‌شوند.

**چگونه می‌توانم شکل‌هایی روی یک اسلاید که قالب‌بندی یکسان دارند شناسایی کنم تا بتوانم آن‌ها را گروه‌بندی کنم؟**

هر یک از ویژگی‌های کلیدی قالب‌بندی شکل — پرکننده، خط و تنظیمات افکت — را مقایسه کنید. اگر تمام مقادیر مربوطه مطابقت داشته باشند، سبک‌های آن‌ها را یکسان در نظر بگیرید و منطقی آن شکل‌ها را گروه‌بندی کنید؛ این کار مدیریت سبک‌ها را در مراحل بعدی ساده می‌کند.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در یک فایل جداگانه ذخیره کنم تا در ارائه‌های دیگر استفاده کنم؟**

بله. شکل‌های نمونه با سبک‌های موردنظر را در یک اسلاید قالب یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد یک ارائه جدید، قالب را باز کنید، شکل‌های سبک‌دار موردنیاز را کلون کنید و قالب‌بندی آن‌ها را هرجا که لازم باشد اعمال کنید.