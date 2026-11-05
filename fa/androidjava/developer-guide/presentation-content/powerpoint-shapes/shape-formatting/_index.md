---
title: قالب‌بندی اشکال PowerPoint در Android
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/androidjava/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- افکت طرح‌دستی
- خط طرح‌دستی شکل
- قالب‌بندی سبک اتصال
- پر کردن گرادیان
- پر کردن طرح
- پر کردن تصویر
- پر کردن بافت
- پر کردن رنگ یکدست
- شفافیت شکل
- رندر شکل سیاه‌سفید
- رندر شکل خاکستری
- چرخاندن شکل
- افکت برج‌دار 3D
- افکت چرخش 3D
- بازنشانی قالب‌بندی
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "یام یاد بگیرید چگونه اشکال PowerPoint را در Android با استفاده از Aspose.Slides—پر کردن، خط و سبک‌های افکت را برای فایل‌های PPT و PPTX با دقت و کنترل کامل تنظیم کنید."
---
## **معرفی**

شکل‌ها را در PowerPoint با تنظیم خطوط مرزی، پر کردن‌ها و افکت‌ها قالب‌بندی کنید. Aspose.Slides برای Android از طریق Java به شما امکان می‌دهد این تنظیمات را به‌صورت برنامه‌نویسی کنترل کنید، از جمله شفافیت، چرخش و قالب‌بندی 3D.

![گزینه‌های قالب‌بندی شکل در PowerPoint](format-shape-powerpoint.png)

Aspose.Slides برای Android از طریق Java رابط‌ها و متدهایی را فراهم می‌کند که به شما اجازه می‌دهد شکل‌ها را با استفاده از همان گزینه‌های موجود در PowerPoint قالب‌بندی کنید.

## **قالب‌بندی خطوط**

از [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) برای کنترل خط مرزی یک شکل استفاده کنید. این مثال یک مستطیل بدون پر با خط مرزی آبی و نقطه‌چین ایجاد می‌کند. [ILineFormat.setStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setStyle-byte-) یک خط ترکیبی ضخیم‑نازک را انتخاب می‌کند، در حالی که [ILineFormat.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-) عرض آن را به ۷ نقطه تنظیم می‌کند و [ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-) الگوی نقطه‌چین را انتخاب می‌کند.

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

### **تنظیم الگوهای خط نقطه‌چین سفارشی**

از [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCustomDashPattern-float---) زمانی که سبک‌های پیش‌فرض خط طول‌ها و فواصل نقطه‌چین مورد نیاز شما را فراهم نمی‌کنند، برای مثال برای خطوط مرزی برند شده یا نمودارهای فنی استفاده کنید. اختصاص یک الگو به‌طور خودکار سبک خط نقطه‌چین را به [LineDashStyle.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) تغییر می‌دهد.

ورودی‌های آرایه به‌صورت متناوب بین طول‌های خط و فاصله‌ها جابجا می‌شوند، با یک خط شروع می‌شوند. هر مقدار چند برابر عرض خط است: `{ 4, 2 }` با عرض ۳ نقطه یک خط ۱۲ نقطه‌ای و سپس یک فاصله ۶ نقطه‌ای تولید می‌کند. برای تعریف بخش‌های کامل خط‑و‑فاصله از جفت مقادیر محدود و غیرمنفی استفاده کنید. مثال از مقادیر مثبت استفاده می‌کند تا هر خط و فاصله قابل مشاهده باشد.

این مثال پنج خط آبی با طول برابر و سرهای صاف ایجاد می‌کند. سه خط اول الگوها را با عرض ۳ نقطه مقایسه می‌کنند. خط چهارم الگوی اول را با دو برابر عرض تکرار می‌کند و هر دو طول خط و فاصله را دو برابر می‌کند. خط پنجم از یک الگوی سفارشی به خط یک‌رنگ تبدیل می‌شود.

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

    //    خط آخر را به سبک تک‌رنگ برگردانید.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای بازگشت به یک سبک نقطه‌چین پیش‌تعریف‌شده، به جای آن، [LineDashStyle.Dash](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) را به [ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-) پاس دهید. سبک انتخاب‌شده ظاهر خط را کنترل می‌کند.

نتیجه در PowerPoint، از بالا به پایین: **{4, 2}, 3 pt**؛ **{1, 2}, 3 pt**؛ **{6, 2, 1, 2}, 3 pt**؛ **{4, 2}, 6 pt**؛ و **Solid, 3 pt**.

![سه الگوی خط نقطه‌چین سفارشی، خطی پهن‌تر با استفاده از اولین الگو، و یک خط یک‌رنگ در PowerPoint](custom-dash-patterns.png)

### **تنظیم سرهای خط**

از [ILineFormat.setCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCapStyle-byte-) برای تنظیم انتهای یک خط باز استفاده کنید. کلاس [LineCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linecapstyle/) سه سبک صریح سر خط را فراهم می‌کند:

- `Flat`: خط در نقطه انتها متوقف می‌شود.
- `Round`: یک سر نیم‌دایره‌ای تا نصف عرض خط فراتر از نقطه انتها ادامه می‌یابد.
- `Square`: یک سر مربعی تا نصف عرض خط فراتر از نقطه انتها ادامه می‌یابد.

این کلاس همچنین `NotDefined` را شامل می‌شود، که به این معناست که هیچ سبک سر خطی به‌صورت صریح اختصاص داده نشده است.

سرها متفاوت از سرهای پیکانی هستند که نمادهایی به انتهای خط اضافه می‌کنند، و از اتصالات که گوشه‌های بین بخش‌های خط را کنترل می‌کنند. این مثال سرهای پیکانی را از طریق [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) و [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-) غیرفعال می‌کند تا فقط شکل‌های سر مقایسه شوند.

مثال زیر سه خط افقی در اصل یکسان با عرض ۲۰ نقطه ایجاد می‌کند. از بالا به پایین، آن‌ها از سرهای flat، round و square استفاده می‌کنند. انتهای آن‌ها دارای همان مختصات افقی است؛ سرهای round و square ۱۰ نقطه فراتر از هر انتها ادامه می‌دهند.

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

نتیجه در PowerPoint، از بالا به پایین: **Flat**، **Round** و **Square**.

![سرهای flat، round و square بر روی خطوط ضخیم یکسان در PowerPoint](line-caps.png)

## **اعمال افکت‌های اسکچ بر خطوط شکل**

یک افکت اسکچ باعث می‌شود خط یک شکل دست‌نویس به‌نظر برسد. از [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) برای دسترسی به تنظیمات خط، [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getSketchFormat--) برای دسترسی به تنظیمات اسکچ، و [ISketchFormat.setSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#setSketchType-int-) برای انتخاب یک مقدار از کلاس [LineSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) استفاده کنید.

کد زیر در Java نشان می‌دهد چگونه یک افکت [LineSketchType.Curved](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) اعمال شود، مقدار اختصاص داده شده صریحاً خوانده شود، و افکت با [LineSketchType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) حذف شود:

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

مقداری که توسط [ISketchFormat.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#getSketchType--) بازگردانده می‌شود، نمایانگر تنظیمی است که مستقیماً به شکل اختصاص داده شده است. اگر قالب‌بندی خط می‌تواند از یک تم، اسلاید اصلی یا اسلاید طرح‌بندی به ارث برسد، از [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--) استفاده کنید، به [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--) دسترسی پیدا کنید، و [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformateffectivedata/#getSketchType--) را بخوانید. مقدار مؤثر قالب‌بندی واقعی‌ای را نشان می‌دهد که پس از حل ارث‌بری اعمال می‌شود. این مثال به یک ارائه موجود با حداقل یک شکل در اسلاید اول نیاز دارد و هر دو مقدار را چاپ می‌کند:

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

در اینجا سه گزینه نوع اتصال موجود است:

* گرد
* میتر
* شیب‌دار

سبک اتصال کنترل می‌کند که دو بخش خط مرزی در یک گوشه چگونه به‌هم می‌رسند. برای گوشه‌های گرد از **Round**، برای گوشه‌های تیز از **Miter**، یا برای گوشه‌های مسطح از **Bevel** استفاده کنید.

![سبک اتصال در ارائه](join-style-powerpoint.png)

این مثال سه مستطیل سیاه با خطوط مرزی آبی با عرض ۱۵ نقطه ایجاد می‌کند. از [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) برای اعمال مقادیر miter، bevel و round کلاس [LineJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/) به ترتیب استفاده می‌کند تا نحوه رسم گوشه‌ها را مقایسه کند.

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

### **محدود کردن اتصالات میتر در گوشه‌های تیز**

از [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setMiterLimit-float-) همراه با [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) که به [LineJoinStyle.Miter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/) تنظیم شده استفاده کنید تا محدود کنید که یک گوشه تیز تا چه اندازه می‌تواند گسترش یابد.

حد مقدار نسبت فاصله بین گوشه داخلی و خارجی اتصال به عرض خط است. به‌عنوان مثال، مقدار `8` اجازه می‌دهد طول میتر تا هشت برابر عرض خط باشد؛ این یک اندازه‌گیری به نقطه نیست. اگر گوشه از حد عبور کند، PowerPoint از یک اتصال زاویه‌دار در آن گوشه استفاده می‌کند. حد بزرگتر نقاط تیزتر را ممکن می‌سازد. این تنظیم فقط بر اتصالات میتر تأثیر دارد و تغییر آن زمانی که گوشه در هر دو حد باقی بماند، اثر قابل مشاهده‌ای ندارد.

این مثال دو مثلث یکسان بدون پر با خطوط مرزی ۲۰ نقطه‌ای ایجاد می‌کند. مثلث چپ از حد `2` استفاده می‌کند و مقطع راست از `8`. هر مثلث عرض ۸۰ نقطه و ارتفاع ۱۶۰ نقطه دارد که نسبت طول میتر به عرض خط در بالای آن حدود `4.12` است. در نتیجه، PowerPoint گوشه چپ را به‌صورت زاویه‌دار می‌کند و گوشه راست را حفظ می‌کند.

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

![یک رأس زاویه‌دار با حد میتر ۲ و یک رأس تیز با حد میتر ۸ در PowerPoint](miter-limits.png)

## **پر کردن گرادیان**

یک پر کردن گرادیان رنگ‌ها را در یک شکل ترکیب می‌کند. این مثال یک بیضی را با یک گرادیان خطی با زاویه ۴۵ درجه از قرمز به بنفش پر می‌کند با استفاده از [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getGradientFormat--). متد [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) نقاط رنگ را در ۰ و ۱، ابتدا و انتهای گرادیان قرار می‌دهد. پاکسازی نقاط موجود اطمینان می‌دهد که فقط این دو رنگ استفاده شوند.

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

![بیضی با پر کردن گرادیان](gradient-fill.png)

اگر یک گرادیان در تصویر خروجی متفاوت از آنچه در PowerPoint دیده می‌شود، به‌نظر می‌رسد، به [Choose a Gradient Rendering Style](/slides/fa/androidjava/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) مراجعه کنید. می‌توانید یک سبک رندرینگ را انتخاب کنید بدون اینکه پر کردن گرادیان ذخیره‌شده در ارائه را تغییر دهید.

### **تنظیم زاویه گرادیان خطی**

از [IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) برای کنترل جهت یک پر کردن [GradientShape.Linear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/) استفاده کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود و به سمت ساعت افزایش می‌یابد: `0` از چپ به راست، `90` از بالا به پایین، `180` از راست به چپ و `270` از پایین به بالا. زاویه‌های کسری پشتیبانی می‌شوند. زاویه‌های محدود خارج از `[0, 360)` به یک دوره نرمال‌سازی می‌شوند؛ به‌عنوان مثال، `-45` به `315` و `360` به `0` تبدیل می‌شود.

این مثال شش مستطیل ایجاد می‌کند که نقاط توقف قرمز، سبز و آبی یکسانی در موقعیت‌های `0`، `0.5` و `1` دارند. مقیاس‌گذاری غیرفعال است تا زاویه بتواند به‌صورت مستقل از نسبت‌های مستطیل‌ها مقایسه شود. زاویه‌ها، از چپ به راست، در ردیف اول `0`، `45` و `90` و در ردیف دوم `135`، `180` و `270` هستند.

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

![گرادیان‌های خطی در زاویه‌های 0، 45 و 90 درجه در ردیف بالا، و 135، 180 و 270 درجه در ردیف پایین](linear-gradient-angles.png)

### **مقیاس‌گذاری یک گرادیان خطی با شکل**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) یک مقدار [NullableBool](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) می‌گیرد. به‌طور صریح آن را به `False` تنظیم کنید تا زاویه‌ٔ هندسی گرادیان در هنگام تغییر نسبت‌های شکل ثابت بماند، یا به `True` تا گرادیان با عرض و ارتفاع شکل مقیاس شود. با فعال بودن مقیاس‌گذاری، زاویه قابل مشاهده می‌تواند از زاویهٔ اختصاص‌یافته در یک شکل غیر مربع متفاوت باشد.

مثال زیر از یک زاویه `45` درجه و همان نقاط توقف رنگی مانند مقایسهٔ زاویه استفاده می‌کند. ستون چپ از `False` استفاده می‌کند؛ ستون راست از `True`. هر ستون شامل یک مستطیل پهن در بالای یک مستطیل بلند است. هر دو با همان ابعاد پهن شروع می‌شوند؛ تغییر عرض و ارتفاع مستطیل دوم نشان می‌دهد که پر کردن چگونه به تغییر اندازه پاسخ می‌دهد بدون اینکه تنظیمات گرادیان را تغییر دهد.

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

![مستطیل‌های پهن و بلند با یک گرادیان 45 درجه، مقایسه LinearGradientScaled False در سمت چپ با True در سمت راست](linear-gradient-scaling.png)

با غیرفعال بودن مقیاس‌گذاری، باندهای رنگی مورب همان جهت را در هر دو مستطیل حفظ می‌کنند. با فعال شدن مقیاس‌گذاری، باندها با نسبت‌های شکل کشیده می‌شوند. این کمک می‌کند تا گرادیان یک قالب را هنگام تغییر اندازهٔ شکل بازتولید کنید. در یک مربع، فعال کردن مقیاس‌گذاری ظاهر این گرادیان `45` درجه را تغییر نمی‌دهد.

هر دو تنظیمات زاویه و مقیاس‌گذاری برای گرادیان‌های خطی اعمال می‌شوند. آن‌ها کنترل پر کردن‌های [GradientShape.Radial یا GradientShape.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/) را ندارند.

### **ترکیب زاویه با جهت گرادیان**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setGradientDirection-int-) یک سبک گرادیان را از کلاس [GradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientdirection/) انتخاب می‌کند؛ این جایگزین یک زاویه عددی نیست. برای یک گرادیان خطی، سبک‌های گوشه می‌توانند ناحیه توزیع رنگ‌ها را بدون تغییر زاویه‌ای که از طریق [setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) اختصاص داده شده است، تغییر دهند. جهت را هنگام مقایسهٔ زوایا یا مقیاس‌گذاری ثابت نگه دارید.

مثال زیر همان تنظیمات را به ترتیب مخالف اعمال می‌کند. دو مستطیل ظاهر یکسانی دارند: اختصاص جهت قبل یا بعد از زاویه نتیجه را تغییر نمی‌دهد.

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

## **پر کردن طرح**

یک پر کردن طرح یک طراحی دو‌رنگی مانند نقطه‌ها، خطوط یا شطرنجی‌ها را اعمال می‌کند. این مثال از [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) برای انتخاب یک الگوی توری استفاده می‌کند. [IPatternFormat.getBackColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getBackColor--) پس‌زمینهٔ خاکستری روشن را فراهم می‌کند و [IPatternFormat.getForeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getForeColor--) رنگ الگوی زرد را فراهم می‌کند.

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

![مستطیل با پر کردن طرح](pattern-fill.png)

## **پر کردن تصویر**

یک پر کردن تصویر از یک تصویر داخل یک شکل استفاده می‌کند. این مثال به یک تصویر محلی نیاز دارد و از [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) برای بارگذاری آن در مجموعهٔ تصاویر ارائه استفاده می‌کند. تنظیم [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) به حالت موزیق تصویر را در داخل مستطیل تکرار می‌کند. تصویر منبع استفاده‌شده در زیر نمایش داده شده است:

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

![شکل با پر کردن تصویر](picture-fill.png)

### **کاشی‌کردن تصویر به‌عنوان بافت**

اگر می‌خواهید یک تصویر را به‌صورت موزیق به‌عنوان بافت تنظیم کنید و رفتار موزیق را سفارشی کنید، می‌توانید از روش‌های زیر در رابط [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) استفاده کنید:

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): حالت پر کردن تصویر را تنظیم می‌کند — یا `Tile` یا `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): تراز موزیق‌ها داخل شکل را مشخص می‌کند.
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): کنترل می‌کند که آیا موزیق به‌صورت افقی، عمودی یا هر دو معکوس شود.
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): افست افقی موزیق (به نقطه) را از مبدأ شکل تنظیم می‌کند.
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): افست عمودی موزیق (به نقطه) را از مبدأ شکل تنظیم می‌کند.
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): مقیاس افقی موزیق را به‌صورت درصد تعریف می‌کند.
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): مقیاس عمودی موزیق را به‌صورت درصد تعریف می‌کند.

این مثال به یک تصویر محلی نیاز دارد و [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) را طوری پیکربندی می‌کند که آن را در ۵۰٪ از اندازهٔ اصلی تکرار کند. افست‌های −32 نقطه موزیق‌ها را به‌صورت افقی و عمودی جابجا می‌کند؛ تراز پایین‑راست و معکوس کردن در هر دو جهت نحوهٔ چینش بافت تکراری را تعیین می‌کند.

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

![گزینه‌های موزیق](tile-options.png)

## **پر کردن رنگ یک‌دسته**

یک پر کردن یک‌دسته به یک شکل یک رنگ یکنواخت می‌دهد. این مثال از [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) برای انتخاب حالت پر کردن یک‌دسته استفاده می‌کند و رنگ زرد را از طریق [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) اختصاص می‌دهد، سپس مستطیل را در یک ارائه ذخیره می‌کند.

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

![شکل با پر کردن رنگ یک‌دسته](solid-color-fill.png)

### **رنگ‌ها را هنگام حفظ ارجاع‌های تم کپی کنید**

از [IColorFormat.copyFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#copyFrom-com.aspose.slides.IColorFormat-) برای کپی کردن یک تعریف رنگ، شامل نوع رنگ، ارجاع تم و تبدیل‌ها استفاده کنید. این برای انتقال رنگ پر کردن بین شکل‌هایی که باید به تم ارائه ادامه دهند مفید است. این متد فقط رنگ را کپی می‌کند: نوع پر کردن، خط مرزی یا سایر قالب‌بندی‌های شکل را کپی نمی‌کند. نوع پر کردن مقصد را به‌طور صریح با [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) تنظیم کنید.

این مثال سه مستطیل ایجاد می‌کند، از چپ به راست: منبع، کپی‌ایی آگاه به تم، و کپی ثابت RGB. منبع با استفاده از [IColorFormat.setSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#setSchemeColor-int-) به اولین رنگ تأکید ارجاع می‌دهد و با [IColorOperationCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icoloroperationcollection/#add-int-float-) یک سایه اضافه می‌کند. کپی RGB از رنگ پر کردن مؤثر منبع استفاده می‌کند تا هر سه در ابتدا یک‌مانند به‌نظر برسند. فراخوانی [IColorFormat.setColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#setColor-java.lang.Integer-) مقدار ثابت RGB تنظیم می‌کند و هر تبدیل رنگ موجود را پاک می‌کند.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(Color.rgb(65, 105, 225));

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

    // ارجاع‌های تم رنگ تأکید جدید را پیروی می‌کنند؛ مقدار ثابت RGB این کار را نمی‌کند.
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(Color.rgb(255, 69, 0));

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

پیش از تغییر تم، هر سه پر کردن مطابقت دارند:

![منبع، مقصد copyFrom و مقصد ثابت RGB با پر کردن‌های آبی یکسان](color-copy-before.png)

پس از تغییر تم، منبع و کپی آگاه به تم رنگ تأکید جدید را دنبال می‌کنند و سایهٔ خود را حفظ می‌کنند. کپی ثابت RGB ثابت می‌ماند و آبی می‌ماند:

![منبع و مقصد copyFrom با پر کردن‌های نارنجی، در حالی که مقصد ثابت RGB آبی می‌ماند](color-copy-after.png)

تعریف کپی شده مستقل از منبع است. پس از آن تغییر ارجاع تم منبع، اختصاص رنگ دیگر، یا افزودن یا حذف تبدیل‌های آن، مقصد را تغییر نمی‌دهد. تغییر تم همچنان هر دو شکل را تحت تأثیر قرار می‌دهد چون هر یک به‌صورت مستقل به همان رنگ تم ارجاع می‌دهند.

ذخیره و باز کردن مجدد فایل PPTX نوع رنگ کپی‌شده‌ای که توسط [IColorFormat.getColorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#getColorType--) برگردانده می‌شود، ارجاع تم، و مجموعهٔ تبدیل‌های برگردانده شده توسط [IColorFormat.getColorTransform](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#getColorTransform--) را حفظ می‌کند؛ این تعریف به RGB مسطح نمی‌شود.

هنگام کپی بین زمینه‌های تم مختلف، مانند ارائه‌هایی با پالت‌های تأکید متفاوت، ارجاع کپی‌شده بر اساس تم مقصد حل می‌شود. بنابراین همان ارجاع و تبدیل‌ها می‌توانند رنگ قابل‌مشاهده متفاوتی تولید کنند. برای اطلاعات بیشتر در مورد پیکربندی رنگ‌های تم به [Presentation Theme](/slides/fa/androidjava/presentation-theme/) مراجعه کنید.

## **استفاده از پس‌زمینه اسلاید به‌عنوان پر کردن شکل**

از [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) زمانی که یک شکل باید با پس‌زمینه اسلاید مطابقت داشته باشد، مثلاً در یک قالب ارائه، استفاده کنید. ابتدا نوع پر کردن را با [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) به [FillType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) تنظیم کنید تا هر پر کردن صریحی حذف شود. با این ترکیب، شکل از پس‌زمینه اسلاید به‌جای پر کردن سبک خود استفاده می‌کند. فعال‌سازی تنها این فلگ، پر کردن صریح موجود را حذف نمی‌کند.

این با [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) متفاوت است: پر کردن پس‌زمینه اشیای پشت شکل را با ناحیهٔ متناظر پس‌زمینه اسلاید می‌پوشاند، در حالی که بدون پر کردن این اشیا قابل مشاهده می‌مانند. یک گرادیان با اسلاید هم‌راستا می‌ماند نه اینکه در هر شکل دوباره آغاز شود.

مثال زیر یک پس‌زمینهٔ اصلی که توسط اسلاید به ارث می‌رسد ایجاد می‌کند و یک نوار ماژنتا را پشت سه مستطیل قرار می‌دهد. مستطیل چپ از پس‌زمینه استفاده می‌کند، مستطیل وسط بدون پر کردن است، و مستطیل راست از پر کردن پس‌زمینه به یک پر کردن صریح نارنجی تغییر می‌کند.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    //    گرادیان را از مستر به ارث ببرید.
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

    //    این شی را ابتدا اضافه کنید تا پشت مستطیل‌ها ظاهر شود.
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

    //    پیش از اعمال یک پر کردن صریح، پر کردن پس‌زمینه را غیرفعال کنید.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه، از چپ به راست: **پر کردن پس‌زمینه**، **بدون پر کردن** و **پر کردن صریح**. نوار ماژنتا توسط مستطیل‌های چپ و راست پنهان می‌شود اما از طریق مستطیل وسط قابل مشاهده است.

![پر کردن پس‌زمینه، بدون پر کردن و پر کردن صریح نارنجی روی یک نوار ماژنتا](background-fill.png)

این رفتار برای پس‌زمینه‌ای که به‌صورت مستقیم بر روی اسلاید تعریف شده یا از یک طرح‌بندی به ارث برده شده نیز صادق است. شکل از پس‌زمینهٔ حل‌شدهٔ اسلاید استفاده می‌کند؛ مثال هر دو پس‌زمینهٔ اسلاید و طرح‌بندی را تعریف‌نشده می‌گذارد تا اصلی آن را فراهم کند.

## **تنظیم شفافیت**

برای یک پر کردن یک‌دسته، مؤلفهٔ آلفای رنگ شفافیت را کنترل می‌کند: ۰ کاملاً شفاف و ۲۵۵ کاملاً مات است. این مثال از مقدار آلفا ۱۲۸ برای یک مستطیل زرد استفاده می‌کند، به‌طوری که تقریباً ۵۰٪ شفاف باشد تا مستطیل زیرین قابل مشاهده بماند. رنگ از طریق [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) اختصاص داده می‌شود.

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

## **چرخاندن شکل‌ها**

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

## **افزودن افکت‌های برج‌دار 3D**

از [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) برای دادن عمق و لبه‌های برج‌دار به یک شکل استفاده کنید. این مثال یک بیضی سبز با خط مرزی نارنجی ایجاد می‌کند، از [IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) برای تنظیم عمق به ۴ نقطه استفاده می‌کند و یک برج‌دار بالایی دایره‌ای با عرض و ارتفاع ۶ نقطه از طریق [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) اعمال می‌کند. یک دوربین ارتوگرافیک رو به جلو و نورپردازی سه‌نقطه‌ای برج را قابل مشاهده می‌سازند.

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

![افکت برج‌دار 3D](3D-bevel-effect.png)

## **افزودن افکت‌های چرخش 3D**

نمای 3D یک شکل توسط تنظیمات دوربین آن کنترل می‌شود. این مثال از [ICamera.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-) با زوایای عرض، طول و دوران به ترتیب ۴۰، ۳۵ و ۲۰ درجه استفاده می‌کند. یک دوربین ایزومتریک را از طریق [ICamera.setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) انتخاب می‌کند و نورپردازی متعادل را از طریق [ILightRig.setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) تنظیم می‌کند، سپس مستطیل قالب‌بندی‌شده را ذخیره می‌کند.

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

## **کنترل رندر سیاه‌سفید برای اشکال**

متد [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) مشخص می‌کند که یک شکل منفرد چگونه رندر می‌شود هنگامی‌که یک ارائه در حالت سیاه‌سفید مشاهده یا پردازش می‌شود. این متد به‌تنهایی نمایش سیاه‌سفید را فعال نمی‌کند و قالب‌بندی‌های پر کردن، خط یا سایر قالب‌بندی‌های شکل را در حالت رنگ عادی تغییر نمی‌دهد.

از یک مقدار کلاس [BlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blackwhitemode/) برای انتخاب رفتار موردنظر استفاده کنید. برای مثال، `Automatic` اجازه می‌دهد برنامه رندرینگ تبدیل را انتخاب کند، `Gray` و `LightGray` از رنگ خاکستری استفاده می‌کنند، `BlackWhite` فقط سیاه و سفید را به‌کار می‌برد، `Black` و `White` یک رنگ واحد را اعمال می‌کند، `Color` رنگ عادی را حفظ می‌کند، و `Hidden` شکل را در حالت سیاه‌سفید حذف می‌کند. `NotDefined` به معنای عدم تخصیص حالت در سطح شکل است.

این مثال یک مستطیل نارنجی ایجاد می‌کند و از [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) برای انتخاب رنگ خاکستری استفاده می‌کند. شکل ذخیره‌شده پر کردن نارنجی خود را برای نمایش رنگ عادی حفظ می‌کند و درخواست رنگ خاکستری را از برنامه‌هایی که تنظیمات نمایش سیاه‌سفید را رعایت می‌کنند می‌کند:

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

در حالت رنگ عادی، مستطیل پر کردن نارنجی خود را حفظ می‌کند. در یک جریان کار نمایش سیاه‌سفید، از رنگ خاکستری استفاده می‌کند چون حالت آن به `Gray` تنظیم شده است. این امکان را می‌دهد تا یک اسلاید با رنگ کامل حفظ شود و ظاهر متمایزی برای چاپ، پیش‌نمایش یا سایر جریان‌های کاری که تنظیمات نمایش سیاه‌سفید ارائه را رعایت می‌کنند، تعریف کنید.

## **بازنشانی قالب‌بندی**

از [ISlide.reset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#reset--) برای بازگرداندن موقعیت، اندازه و قالب‌بندی جای‌گیرهای اسلاید از جای‌گیرهای متناظر طرح‌بندی استفاده کنید. این مثال به یک ارائه موجود با جای‌گیرهای پیوندشده به طرح‌بندی نیاز دارد و قبل از ذخیره‌سازی هر اسلاید را بازنشانی می‌کند. شکل‌هایی که جای‌گیرهای متناظر در طرح‌بندی ندارند، بازنشانی نمی‌شوند.

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

رنگ‌ها، سبک‌های خطوط و تنظیمات افکت عموماً داده کمی نسبت به تصاویر و رسانه‌های جاسازی‌شده اضافه می‌کنند. پر کردن‌های تصویری می‌توانند حجم فایل را افزایش دهند زیرا تصاویر آن‌ها در ارائه ذخیره می‌شود.

**چگونه می‌توانم شکل‌هایی را در یک اسلاید که قالب‌بندی یکسانی دارند شناسایی کنم تا بتوانم آن‌ها را گروه‌بندی کنم؟**

خواص کلیدی قالب‌بندی هر شکل—پر کردن، خط و تنظیمات افکت—را مقایسه کنید. اگر همه مقادیر متناظر مطابقت داشته باشند، سبک‌های آن‌ها را یکسان در نظر بگیرید و به‌صورت منطقی آن شکل‌ها را گروه‌بندی کنید، که مدیریت سبک‌ها را در آینده ساده‌تر می‌کند.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در یک فایل جداگانه ذخیره کنم تا در ارائه‌های دیگر استفاده شود؟**

بله. شکل‌های نمونه با سبک‌های دلخواه را در یک دک اسلاید قالب یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد یک ارائه جدید، قالب را باز کنید، شکل‌های سبک‌دار مورد نیاز را کلون کنید و قالب‌بندی آن‌ها را هرجا که لازم باشد دوباره اعمال کنید.