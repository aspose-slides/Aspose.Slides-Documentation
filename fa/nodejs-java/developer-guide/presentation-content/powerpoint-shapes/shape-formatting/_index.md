---
title: قالب‌بندی اشکال پاورپوینت در جاوااسکریپت
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/nodejs-java/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- افکت اسکیچ
- خط اسکیچ شکل
- قالب‌بندی سبک اتصال
- پرکردن گرادیان
- پرکردن الگو
- پرکردن تصویر
- پرکردن بافت
- پرکردن رنگ ثابت
- شفافیت شکل
- رندر سیاه-سفید شکل
- رندر درجات خاکستری شکل
- چرخاندن شکل
- افکت برش سه‌بعدی
- افکت چرخش سه‌بعدی
- بازنشانی قالب‌بندی
- پاورپوینت
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال PowerPoint را در JavaScript با استفاده از Aspose.Slides—پرکردن، خط و سبک افکت‌ها را برای فایل‌های PPT و PPTX با دقت و کنترل کامل تنظیم کنید."
---
## **معرفی**

اشکال‌ها را در PowerPoint با تنظیم خطوط مرزی، پرکننده‌ها و افکت‌ها قالب‌بندی کنید. Aspose.Slides for Node.js via Java به شما امکان کنترل این تنظیمات به‌صورت برنامه‌نویسی را می‌دهد، شامل شفافیت، چرخش و قالب‌بندی سه‌بعدی.

![گزینه‌های قالب‌بندی اشکال در PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java کلاس‌ها و متدهایی را فراهم می‌کند که به شما امکان قالب‌بندی اشکال با استفاده از همان گزینه‌های موجود در PowerPoint را می‌دهد.

## **قالب‌بندی خطوط**

از [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) برای کنترل خطوط مرزی یک شکل استفاده کنید. این مثال یک مستطیل بدون پرکننده با یک خط درهم‌خطی آبی ایجاد می‌کند. [LineFormat.setStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setStyle) یک خط ترکیبی ضخیم-نازک را انتخاب می‌کند، در حالی که [LineFormat.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setWidth) عرض آن را روی ۷ پوینت تنظیم می‌کند و [LineFormat.setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setDashStyle) الگوی خط‌چین را انتخاب می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![خطوط قالب‌بندی شده در ارائه](formatted-lines.png)

### **تنظیم الگوهای سفارشی خط‌چین**

از [LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setCustomDashPattern) وقتی سبک‌های پیش‌تعریف‌شده خط طول‌ها و فاصله‌های خط‌چین مورد نیاز شما را فراهم نمی‌کنند، مثلاً برای خطوط مرزی برندی یا نمودارهای فنی استفاده کنید. اختصاص یک الگو به‌طور خودکار سبک خط‌چین را به [LineDashStyle.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) تغییر می‌دهد.

ورودی‌های آرایه به‌صورت متناوب بین طول خط‌چین و فاصله تغییر می‌کنند، با یک خط‌چین آغاز می‌شود. هر مقدار چند برابر عرض خط است: `[4, 2]` با عرض ۳ پوینت یک خط‌چین ۱۲ پوینتی به‌دنبال یک فاصله ۶ پوینتی تولید می‌کند. برای تعریف بخش‌های کامل خط‌چین‑فاصله از جفت مقادیر متناهی و غیرمنفی استفاده کنید. در این مثال از مقادیر مثبت استفاده شده تا هر دو خط‌چین و فاصله‌ای قابل مشاهده باشد.

این مثال پنج خط آبی با همان طول و سرهای صاف ایجاد می‌کند. سه خط اول الگوها را با عرض ۳ پوینت مقایسه می‌کنند. خط چهارم الگوی اول را با دو برابر عرض تکرار می‌کند و هر دو طول خط‌چین و فاصله را دو برابر می‌سازد. خط پنجم از یک الگوی سفارشی به یک خط صلب تغییر می‌یابد.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(600, 300, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ];

    for (let i = 0; i < patterns.length; i++) {
        let line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 50 + i * 50, 500, 0);
        line.getLineFormat().setWidth(i == 3 ? 6 : 3);
        line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        line.getLineFormat().setCapStyle(java.newByte(aspose.slides.LineCapStyle.Flat));
        line.getLineFormat().setBeginArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        line.getLineFormat().setEndArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        let pattern = java.newArray("float", patterns[i]);
        line.getLineFormat().setCustomDashPattern(pattern);
    }

    // خط آخر را به سبک صلب برگردانید.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Solid));

    presentation.save("custom_dash_patterns.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای بازگشت به یک سبک پیش‌تعریف‌شده خط‌چین، به جای آن [LineDashStyle.Dash](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) را به [LineFormat.setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setDashStyle) پاس دهید. سبک انتخاب شده ظاهر خط را کنترل می‌کند.

نتیجه در PowerPoint، از بالا به پایین: **{4, 2}, 3 pt**؛ **{1, 2}, 3 pt**؛ **{6, 2, 1, 2}, 3 pt**؛ **{4, 2}, 6 pt**؛ و **Solid, 3 pt**.

![سه الگوی سفارشی خط‌چین، یک خط پهن‌تر با استفاده از الگوی اول، و یک خط صلب در PowerPoint](custom-dash-patterns.png)

### **تنظیم سرهای خط**

از [LineFormat.setCapStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setCapStyle) برای تنظیم انتهای یک خط باز استفاده کنید. کلاس [LineCapStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linecapstyle/) سه سبک صریح سر خط را فراهم می‌کند:

- `Flat`: خط در نقطه انتهایی متوقف می‌شود.
- `Round`: یک سر نیم‌دایره‌ای فاصله‌ای برابر نصف عرض خط پس از نقطه انتهایی اضافه می‌کند.
- `Square`: یک سر مربعی فاصله‌ای برابر نصف عرض خط پس از نقطه انتهایی اضافه می‌کند.

این کلاس همچنین شامل `NotDefined` است که به این معنی است که هیچ سبک سرخطی به‌صورت صریح اختصاص داده نشده است.

سرهای خط متفاوت از سرهای پیکان هستند که نمادهایی به انتهای خط اضافه می‌کنند، و اتصالات که گوشه‌های بین بخش‌های خط را کنترل می‌کنند. این مثال سرهای پیکان را با استفاده از [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setBeginArrowheadStyle) و [LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setEndArrowheadStyle) غیرفعال می‌کند تا فقط شکل‌های سرخط مقایسه شوند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let capStyles = [aspose.slides.LineCapStyle.Flat, aspose.slides.LineCapStyle.Round, aspose.slides.LineCapStyle.Square];

    for (let i = 0; i < capStyles.length; i++) {
        let line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        line.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Solid));
        line.getLineFormat().setCapStyle(java.newByte(capStyles[i]));
        line.getLineFormat().setBeginArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        line.getLineFormat().setEndArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
    }

    presentation.save("line_caps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه در PowerPoint، از بالا به پایین: **Flat**، **Round** و **Square**.

![سرهای صاف، گرد و مربع روی خطوط ضخیم یکسان در PowerPoint](line-caps.png)

## **اعمال افکت‌های اسکیچ به خطوط شکل**

یک افکت اسکیچ باعث می‌شود خط شکل شبیه به دست‌خط باشد. از [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) برای دسترسی به تنظیمات خط، [LineFormat.getSketchFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getSketchFormat) برای دسترسی به تنظیمات اسکیچ، و [SketchFormat.setSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/#setSketchType) برای انتخاب مقداری از کلاس [LineSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) استفاده کنید.

کد JavaScript زیر نشان می‌دهد چگونه یک افکت [LineSketchType.Curved](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) اعمال کنید، مقدار اختصاص داده‌شده به‌صورت صریح را بخوانید، و افکت را با [LineSketchType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) حذف کنید:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    let sketchFormat = shape.getLineFormat().getSketchFormat();
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

مقداری که توسط [SketchFormat.getSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/#getSketchType) برگردانده می‌شود، تنظیمی را نشان می‌دهد که مستقیماً به شکل اختصاص داده شده است. اگر قالب‌بندی خط می‌تواند از یک تم، اسلاید اصلی یا اسلاید طرح‌بندی ارث‌بری شود، از [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getEffective) استفاده کنید، `getSketchFormat` را روی شیء بازگردانده صدا بزنید، سپس متد `getSketchType` آن را فراخوانی کنید. مقدار مؤثر، قالب‌بندی واقعی اعمال‌شده پس از حل ارث‌بری را منعکس می‌کند. این مثال به یک ارائه موجود با حداقل یک شکل در اسلاید اول نیاز دارد و هر دو مقدار را چاپ می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    let lineFormat = shape.getLineFormat();
    let explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    let effectiveLineFormat = lineFormat.getEffective();
    let effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    console.log("Explicit sketch type: " + explicitSketchType);
    console.log("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **قالب‌بندی سبک‌های اتصال**

در اینجا سه گزینه نوع اتصال وجود دارد:

* Round
* Miter
* Bevel

سبک اتصال تعیین می‌کند دو بخش خط مرزی در یک گوشه چگونه به‌هم می‌رسند. از **Round** برای گوشه‌های گرد، **Miter** برای گوشه‌های تیز، یا **Bevel** برای گوشه‌های مسطح استفاده کنید.

![سبک اتصال در ارائه](join-style-powerpoint.png)

این مثال سه مستطیل سیاه با خطوط مرزی آبی به عرض ۱۵ پوینت ایجاد می‌کند. از [LineFormat.setJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setJoinStyle) برای اعمال مقادیر miter، bevel و round از [LineJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linejoinstyle/) به ترتیب استفاده می‌کند تا نحوه رسم گوشه‌ها مقایسه شود.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let miterShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let bevelShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let roundShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    miterShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    miterShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    bevelShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    bevelShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    roundShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    roundShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    miterShape.getLineFormat().setWidth(15);
    bevelShape.getLineFormat().setWidth(15);
    roundShape.getLineFormat().setWidth(15);

    miterShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    miterShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    bevelShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    bevelShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    roundShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    roundShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    miterShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    bevelShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    roundShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    miterShape.getTextFrame().setText("Miter Join Style");
    bevelShape.getTextFrame().setText("Bevel Join Style");
    roundShape.getTextFrame().setText("Round Join Style");

    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **محدود کردن اتصالات Miter در گوشه‌های تیز**

از [LineFormat.setMiterLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setMiterLimit) همراه با [LineFormat.setJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setJoinStyle) که روی [LineJoinStyle.Miter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linejoinstyle/) تنظیم شده است، برای محدود کردن فاصله‌ای که یک گوشه تیز می‌تواند گسترش یابد، استفاده کنید.

محدودیت یک نسبت بین فاصله بین گوشه‌های داخلی و خارجی اتصال به عرض خط است. برای مثال، مقدار `8` اجازه می‌دهد طول miter تا هشت برابر عرض خط باشد؛ این یک اندازه‌گیری در پوینت نیست. اگر گوشه از حد مجاز عبور کند، PowerPoint در آن گوشه از اتصال bevel استفاده می‌کند. یک حد بزرگتر نقاط تیزتر را امکان‌پذیر می‌کند. این تنظیم فقط بر اتصالات miter تأثیر می‌گذارد و تغییر آن تأثیر قابل مشاهده‌ای ندارد وقتی گوشه در هر دو حد باقی می‌ماند.

این مثال دو مثلث یکسان بدون پرکننده با خطوط مرزی به عرض ۲۰ پوینت ایجاد می‌کند. مثلث چپ از حد `2` استفاده می‌کند و مثلث راست از حد `8`. هر دو مثلث به عرض ۸۰ پوینت و ارتفاع ۱۶۰ پوینت هستند، که نسبت طول miter به عرض خط در گوشه بالایی آن تقریباً `4.12` است. بنابراین PowerPoint گوشه چپ را به bevel تبدیل می‌کند و گوشه راست را حفظ می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(500, 320, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let miterLimits = [2, 8];

    for (let i = 0; i < miterLimits.length; i++) {
        let triangle = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
        triangle.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        triangle.getLineFormat().setWidth(20);
        triangle.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        triangle.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
        triangle.getLineFormat().setMiterLimit(java.newFloat(miterLimits[i]));
    }

    presentation.save("miter_limits.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه در PowerPoint: **Miter limit 2** در سمت چپ و **miter limit 8** در سمت راست.

![یک رأس bevel شده با محدودیت miter 2 و یک رأس نوک‌دار با محدودیت miter 8 در PowerPoint](miter-limits.png)

## **پرکردن گرادیان**

یک پرکننده گرادیان رنگ‌ها را در یک شکل ترکیب می‌کند. این مثال یک بیضی را با یک گرادیان خطی با زاویه ۴۵ درجه از قرمز به بنفش پر می‌کند با استفاده از [FillFormat.getGradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getGradientFormat). متد [GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientstopcollection/#addPresetColor) نقاط رنگ را در ۰ و ۱، شروع و پایان گرادیان قرار می‌دهد. پاک‌کردن نقاط موجود اطمینان می‌دهد که تنها این دو رنگ استفاده شوند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45);
    shape.getFillFormat().getGradientFormat().getGradientStops().clear();
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, aspose.slides.PresetColor.Red);

    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![بیضی با پرکردن گرادیان](gradient-fill.png)

اگر یک گرادیان در یک تصویر صادر شده نسبت به PowerPoint متفاوت به نظر می‌رسد، به [Choose a Gradient Rendering Style](/slides/fa/nodejs-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) مراجعه کنید. می‌توانید یک سبک رندرسازی را انتخاب کنید بدون اینکه پرکردن گرادیان ذخیره‌شده در ارائه را تغییر دهید.

### **تنظیم زاویه گرادیان خطی**

از [GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientAngle) برای کنترل جهت پرکننده [GradientShape.Linear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientshape/) استفاده کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود و در جهت ساعت‌دار افزایش می‌یابد: `0` از چپ به راست، `90` از بالا به پایین، `180` از راست به چپ، و `270` از پایین به بالا. زاویه‌های کسری نیز پشتیبانی می‌شوند. زاویه‌های متناهی خارج از بازه `[0, 360)` به یک دور نرمال می‌شوند؛ برای مثال، `-45` به `315` و `360` به `0` تبدیل می‌شود.

این مثال شش مستطیل با نقاط توقف قرمز، سبز و آبی یکسان در موقعیت‌های `0`، `0.5` و `1` ایجاد می‌کند. مقیاس‌پذیری غیرفعال است تا زاویه به‌صورت مستقل از نسبت‌های مستطیل‌ها مقایسه شود. زاویه‌ها، از چپ به راست، در ردیف اول `0`، `45` و `90` و در ردیف دوم `135`، `180` و `270` هستند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let angles = [0, 45, 90, 135, 180, 270];

    for (let i = 0; i < angles.length; i++) {
        let x = 30 + (i % 3) * 230;
        let y = 30 + Math.floor(i / 3) * 190;

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 200, 150);
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

        let gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
        gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
        gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
        gradient.setLinearGradientScaled(java.newByte(aspose.slides.NullableBool.False));
        gradient.setLinearGradientAngle(angles[i]);
    }

    presentation.save("linear_gradient_angles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه در PowerPoint:

![گرادیان‌های خطی با زاویه 0، 45 و 90 درجه در ردیف بالا، و 135، 180 و 270 درجه در ردیف پایین](linear-gradient-angles.png)

### **مقیاس‌پذیری یک گرادیان خطی با شکل**

[GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientScaled) یک مقدار از نوع [NullableBool](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) می‌پذیرد. به‌طور صریح آن را به `False` تنظیم کنید تا زاویه جئومتریک گرادیان هنگام تغییر نسبت‌های شکل ثابت بماند، یا به `True` تا گرادیان با عرض و ارتفاع شکل مقیاس‌پذیر شود. با فعال بودن مقیاس‌پذیری، زاویه قابل مشاهده می‌تواند با زاویه اختصاص داده‌شده در یک شکل غیرمربع متفاوت باشد.

مثال زیر از زاویه `45` درجه و همان نقاط رنگی که در مقایسه زاویه استفاده شد، بهره می‌برد. ستون چپ از `False` استفاده می‌کند؛ ستون راست از `True`. هر ستون شامل یک مستطیل پهن بالای یک مستطیل بلند است. هر دو با همان ابعاد پهن شروع می‌شوند؛ تغییر عرض و ارتفاع مستطیل دوم نشان می‌دهد که پرکننده چگونه به تغییر اندازه واکنش نشان می‌دهد بدون آنکه تنظیمات گرادیان تغییر کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 460, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let scalingOptions = [aspose.slides.NullableBool.False, aspose.slides.NullableBool.True];

    for (let column = 0; column < scalingOptions.length; column++) {
        for (let row = 0; row < 2; row++) {
            let x = 30 + column * 360;
            let y = row == 0 ? 30 : 150;

            let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 300, 90);
            shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

            let gradient = shape.getFillFormat().getGradientFormat();
            gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
            gradient.getGradientStops().clear();
            gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
            gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
            gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
            gradient.setLinearGradientAngle(45);
            gradient.setLinearGradientScaled(java.newByte(scalingOptions[column]));

            if (row == 1) {
                shape.setWidth(90);
                shape.setHeight(280);
            }
        }
    }

    presentation.save("linear_gradient_scaling.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه در PowerPoint، با مقیاس‌پذیری غیرفعال در سمت چپ و فعال در سمت راست:

![مستطیل‌های پهن و بلند با گرادیان 45 درجه، مقایسه LinearGradientScaled False در سمت چپ با True در سمت راست](linear-gradient-scaling.png)

با غیرفعال بودن مقیاس‌پذیری، نوارهای رنگی مورب همان جهت را در هر دو مستطیل حفظ می‌کنند. با فعال شدن مقیاس‌پذیری، نوارها با نسبت‌های شکل کشیده می‌شوند. این به بازآفرینی گرادیان یک قالب هنگام سازگار کردن یک شکل با اندازه متفاوت کمک می‌کند. در یک مربع، فعال‌سازی مقیاس‌پذیری ظاهر این گرادیان `45` درجه را تغییر نمی‌دهد.

هر دو تنظیم زاویه و مقیاس‌پذیری بر گرادیان‌های خطی اعمال می‌شوند. آن‌ها کنترل پرکننده‌های [GradientShape.Radial یا GradientShape.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientshape/) را ندارند.

### **ترکیب زاویه با جهت گرادیان**

[GradientFormat.setGradientDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setGradientDirection) یک سبک گرادیان را از کلاس [GradientDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientdirection/) انتخاب می‌کند؛ این جایگزین یک زاویه عددی نیست. برای یک گرادیان خطی، سبک‌های گوشه می‌توانند ناحیه‌ای که رنگ‌ها توزیع می‌شوند بدون تغییر زاویه اختصاص داده‌شده از طریق [setLinearGradientAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientAngle) تغییر دهند. هنگام مقایسه زاویه‌ها یا مقیاس‌پذیری، جهت را ثابت نگه دارید.

مثال زیر همان تنظیمات را به ترتیب مخالف اعمال می‌کند. دو مستطیل ظاهر یکسانی دارند: اختصاص جهت قبل یا بعد از زاویه نتیجه را تغییر نمی‌دهد.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < 2; i++) {
        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

        let gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
        gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
        gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
        gradient.setLinearGradientScaled(java.newByte(aspose.slides.NullableBool.True));

        if (i == 0) {
            gradient.setGradientDirection(aspose.slides.GradientDirection.FromCorner1);
            gradient.setLinearGradientAngle(30);
        } else {
            gradient.setLinearGradientAngle(30);
            gradient.setGradientDirection(aspose.slides.GradientDirection.FromCorner1);
        }
    }

    presentation.save("linear_gradient_direction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **پرکردن الگو**

یک پرکردن الگو یک طرح دو رنگی مانند نقطه‌ها، خط‌ها یا شطرنجی‌ها را اعمال می‌کند. این مثال از [PatternFormat.setPatternStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#setPatternStyle) برای انتخاب یک الگوی trellis استفاده می‌کند. [PatternFormat.getBackColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getBackColor) پس‌زمینه خاکستری روشن را فراهم می‌کند و [PatternFormat.getForeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getForeColor) رنگ زرد الگو را تأمین می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![مستطیل با پرکردن الگو](pattern-fill.png)

## **پرکردن تصویر**

یک پرکردن تصویر از یک تصویر داخل یک شکل استفاده می‌کند. این مثال به یک تصویر محلی نیاز دارد و از [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) برای بارگذاری آن در مجموعه تصاویر ارائه استفاده می‌کند. تنظیم [PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode) به حالت tiled تصویر را داخل مستطیل تکرار می‌کند. تصویر منبع استفاده‌شده در زیر نشان داده شده است:

![عکس لوطوس](lotus.png)

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture;
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![شکل با پرکردن تصویر](picture-fill.png)

### **تایل کردن تصویر به‌عنوان بافت**

اگر می‌خواهید یک تصویر تایل‌شده را به‌عنوان بافت تنظیم کنید و رفتار تایلینگ را سفارشی کنید، می‌توانید از روش‌های زیر کلاس [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) استفاده کنید:

- [setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): حالت پرکردن تصویر را تنظیم می‌کند — یا `Tile` یا `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): تراز تایل‌ها داخل شکل را مشخص می‌کند.
- [setTileFlip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): کنترل می‌کند آیا تایل به‌صورت افقی، عمودی یا هر دو معکوس شود.
- [setTileOffsetX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): افست افقی تایل (به پوینت) را نسبت به مبدأ شکل تنظیم می‌کند.
- [setTileOffsetY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): افست عمودی تایل (به پوینت) را نسبت به مبدأ شکل تنظیم می‌کند.
- [setTileScaleX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): مقیاس افقی تایل را به‌صورت درصد تعریف می‌کند.
- [setTileScaleY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): مقیاس عمودی تایل را به‌صورت درصد تعریف می‌کند.

این مثال به یک تصویر محلی نیاز دارد و [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) را طوری تنظیم می‌کند که آن را در ۵۰٪ اندازه اصلی تکرار کند. افست‌های −۳۲ پوینت تایل‌ها را به‌صورت افقی و عمودی منتقل می‌کند؛ تراز پایین‑راست و معکوس‌سازی در هر دو جهت نحوهٔ چینش بافت تکراری را تعیین می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![گزینه‌های تایل](tile-options.png)

## **پرکردن تک‌رنگ**

یک پرکردن تک‌رنگ به شکل یک رنگ واحد و یکنواخت می‌دهد. این مثال از [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) برای انتخاب حالت پرکردن تک‌رنگ استفاده می‌کند و از طریق [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor) رنگ زرد را اختصاص می‌دهد، سپس مستطیل را در یک ارائه ذخیره می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![شکل با پرکردن تک‌رنگ](solid-color-fill.png)

### **کپی رنگ‌ها به‌صورت حفظ ارجاعات تم**

از [ColorFormat.copyFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#copyFrom) برای کپی کردن تعریف یک رنگ، شامل نوع رنگ، ارجاع تم، و تبدیل‌ها استفاده کنید. این برای انتقال رنگ پرکردن بین شکل‌هایی که باید تم ارائه را دنبال کنند مفید است. این متد تنها رنگ را کپی می‌کند: نوع پرکردن، خط مرزی یا سایر قالب‌بندی‌های شکل را کپی نمی‌کند. نوع پرکردن مقصد را به‌صورت صریح با [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) تنظیم کنید.

این مثال سه مستطیل، از چپ به راست: منبع، یک کپی آگاه به تم، و یک کپی ثابت RGB ایجاد می‌کند. منبع از [ColorFormat.setSchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#setSchemeColor) برای ارجاع به اولین رنگ تاکیدی استفاده می‌کند و از طریق [ColorOperationCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/coloroperationcollection/#add) یک رنگ مایل (tint) اضافه می‌کند. کپی RGB از رنگ پرکردن مؤثر منبع استفاده می‌کند تا هر سه در ابتدا یکسان به نظر برسند. فراخوانی [ColorFormat.setColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#setColor) یک مقدار ثابت RGB تنظیم می‌کند و هر تبدیل رنگ موجود را پاک می‌سازد.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(java.newInstanceSync("java.awt.Color", 65, 105, 225));

    let source = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 40, 180, 140);
    let themeCopy = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 240, 40, 180, 140);
    let rgbCopy = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 450, 40, 180, 140);

    for (let shape of [source, themeCopy, rgbCopy]) {
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }

    let sourceColor = source.getFillFormat().getSolidFillColor();
    sourceColor.setSchemeColor(aspose.slides.SchemeColor.Accent1);
    sourceColor.getColorTransform().add(aspose.slides.ColorTransformOperation.Tint, java.newFloat(0.75));

    themeCopy.getFillFormat().getSolidFillColor().copyFrom(sourceColor);
    rgbCopy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor());

    let before = slide.getImage(1, 1);
    try {
        before.save("color-copy-before.png", aspose.slides.ImageFormat.Png);
    } finally {
        before.dispose();
    }

    // ارجاعات تم به رنگ جدید Accent پیروی می‌کنند؛ مقدار ثابت RGB این‌طور نیست.
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(java.newInstanceSync("java.awt.Color", 255, 69, 0));

    let after = slide.getImage(1, 1);
    try {
        after.save("color-copy-after.png", aspose.slides.ImageFormat.Png);
    } finally {
        after.dispose();
    }
    presentation.save("copied_colors.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

قبل از تغییر تم، همه سه پرکردن مطابقت دارند:

![منبع، مقصد copyFrom، و مقصد ثابت RGB با پرکردن‌های آبی یکسان](color-copy-before.png)

پس از تغییر تم، منبع و کپی آگاه به تم رنگ تاکیدی جدید را دنبال می‌کنند و مایل خود را حفظ می‌کنند. کپی ثابت RGB همچنان آبی می‌ماند:

![منبع و مقصد copyFrom با پرکردن‌های نارنجی، در حالی که مقصد ثابت RGB آبی می‌ماند](color-copy-after.png)

تعریف کپی‌شده مستقل از منبع است. تغییر بعدی ارجاع تم منبع، اختصاص رنگ دیگری، یا افزودن یا حذف تبدیل‌های آن، مقصد را تغییر نمی‌دهد. تغییر تم همچنان هر دو شکل را تحت تأثیر قرار می‌دهد زیرا هر کدام به‌صورت مستقل به همان رنگ تم ارجاع می‌دهند.

ذخیره و باز کردن مجدد فایل PPTX نوع رنگ کپی‌شده برگردانده‌شده توسط [ColorFormat.getColorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#getColorType)، ارجاع تم، و مجموعهٔ تبدیل‌های برگردانده‌شده توسط [ColorFormat.getColorTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#getColorTransform) را حفظ می‌کند؛ این تعریف به RGB تبدیل نمی‌شود.

هنگام کپی بین زمینه‌های تم متفاوت، مانند ارائه‌هایی با پالت‌های تاکیدی مختلف، ارجاع کپی‌شده بر اساس تم مقصد حل می‌شود. همان ارجاع و تبدیل‌ها می‌توانند بنابراین رنگ قابل مشاهده متفاوتی ایجاد کنند. برای اطلاعات بیشتر درباره پیکربندی رنگ‌های تم، به [Presentation Theme](/slides/fa/nodejs-java/presentation-theme/) مراجعه کنید.

## **استفاده از پس‌زمینه اسلاید به‌عنوان پرکردن شکل**

از [AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#setUseBackgroundFill) وقتی یک شکل باید با پس‌زمینه اسلاید مطابقت داشته باشد، نمونه‌ً در یک قالب ارائه، استفاده کنید. ابتدا نوع پرکردن را با [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) به [FillType.NotDefined](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) تنظیم کنید تا هر پرکردن صریحی حذف شود. با این ترکیب، شکل از پس‌زمینه اسلاید به‌جای پرکردن استایل خود استفاده می‌کند. فعال‌سازی پرچم به‌تنهایی پرکردن صریح موجود را حذف نمی‌کند.

این متفاوت از [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) است: پرکردن پس‌زمینه objects پشت شکل را با ناحیهٔ متناظر پس‌زمینه اسلاید می‌پوشاند، در حالی که بدون پرکردن آن اشیاء را قابل مشاهده می‌گذارد. یک گرادیان با اسلاید هم‌راستا می‌ماند به‌جای این که داخل هر شکل دوباره شروع شود.

مثال زیر یک پس‌زمینهٔ اصلی که توسط اسلاید به ارث می‌برد ایجاد می‌کند و یک نوار سرخ‌فام پشت سه مستطیل قرار می‌دهد. مستطیل چپ از پس‌زمینه استفاده می‌کند، مستطیل وسط هیچ پرکردنی ندارد، و مستطیل راست از پرکردن پس‌زمینه به یک پرکردن صریح نارنجی سوئیچ می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    // گرادیان را از مستر به ارث ببرید.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.NotDefined));
    slide.getLayoutSlide().getBackground().setType(java.newByte(aspose.slides.BackgroundType.NotDefined));
    let background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    let gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, java.newInstanceSync("java.awt.Color", 0, 0, 139));
    gradient.getGradientStops().add(1, java.newInstanceSync("java.awt.Color", 135, 206, 250));

    // این شیء را ابتدا اضافه کنید تا پشت مستطیل‌ها ظاهر شود.
    let band = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 25, 150, 670, 100);
    band.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    band.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    band.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    let backgroundShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 100, 160, 200);
    backgroundShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NotDefined));
    backgroundShape.setUseBackgroundFill(true);

    let noFillShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 280, 100, 160, 200);
    noFillShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    let explicitShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 510, 100, 160, 200);
    explicitShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NotDefined));
    explicitShape.setUseBackgroundFill(true);

    // پرکردن پس‌زمینه را قبل از اعمال پرکردن صریح غیرفعال کنید.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    explicitShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));

    presentation.save("background_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه، از چپ به راست: **پرکردن پس‌زمینه**، **بدون پرکردن** و **پرکردن صریح**. نوار سرخ‌فام توسط مستطیل‌های چپ و راست پنهان می‌شود اما از طریق مستطیل وسط قابل مشاهده است.

![پرکردن پس‌زمینه، بدون پرکردن، و پرکردن صریح نارنجی روی یک نوار سرخ‌فام](background-fill.png)

رفتار مشابهی برای پس‌زمینه‌ای که مستقیماً بر روی اسلاید تعریف شده یا از یک طرح‌بندی ارث‌بری شده اعمال می‌شود. شکل از پس‌زمینهٔ حل‌شدهٔ اسلاید استفاده می‌کند؛ مثال هر دو پس‌زمینهٔ اسلاید و طرح‌بندی را تعریف‌نشده می‌گذارد تا مستر آن را تامین کند.

## **تنظیم شفافیت**

برای یک پرکردن تک‌رنگ، مؤلفه آلفای رنگ شفافیت را کنترل می‌کند: 0 کاملاً شفاف و 255 کاملاً مات است. این مثال از مقدار آلفا 128 برای یک مستطیل زرد استفاده می‌کند، که تقریباً 50٪ شفاف می‌شود تا مستطیل زیرین قابل مشاهده بماند. رنگ از طریق [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor) اختصاص داده می‌شود.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 128));

    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![شکل شفاف](shape-transparency.png)

## **چرخاندن اشکال**

از [Shape.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) برای چرخاندن یک شکل در صفحه اسلاید استفاده کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود؛ این مثال یک مستطیل را 5 درجه ساعت‌دار می‌چرخاند و ارائه را ذخیره می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.setRotation(5);

    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![چرخش شکل](shape-rotation.png)

## **افزودن افکت‌های برش سه‌بعدی**

از [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) برای افزودن عمق و لبه‌های برش به یک شکل استفاده کنید. این مثال یک بیضی سبز با خطوط مرزی نارنجی ایجاد می‌کند، از [ThreeDFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) برای تنظیم عمق به 4 پوینت استفاده می‌کند و از طریق [ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelTop) یک برش بالایی دایره‌ای با عرض و ارتفاع 6 پوینت اعمال می‌کند. یک دوربین ارتوگرافیک رو به جلو و نورپردازی سه‌نقطه‌ای برش را قابل مشاهده می‌سازند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));
    shape.getLineFormat().setWidth(2.0);
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![افکت برش سه‌بعدی](3D-bevel-effect.png)

## **افزودن افکت‌های چرخش سه‌بعدی**

نمایش سه‌بعدی یک شکل توسط تنظیمات دوربین آن کنترل می‌شود. این مثال از [Camera.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setRotation) با زاویه‌های عرض، طول‌جغرافیایی و چرخش 40، 35 و 20 درجه به ترتیب استفاده می‌کند. یک دوربین ایزومتریک را از طریق [Camera.setCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setCameraType) انتخاب می‌کند و نورپردازی متعادل را از طریق [LightRig.setLightType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lightrig/#setLightType) تنظیم می‌کند، سپس مستطیل قالب‌بندی‌شده را ذخیره می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![افکت چرخش سه‌بعدی](3D-rotation-effect.png)

## **کنترل رندر سیاه‑سفید برای اشکال**

متد [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) تعیین می‌کند یک شکل فردی چگونه در حالت نمایش یا پردازش سیاه‑سفید رندر می‌شود. این متد به‌تنهایی نمایش سیاه‑سفید را فعال نمی‌کند و قالب‌بندی‌های پرکردن، خط یا سایر ویژگی‌های شکل را در حالت رنگ عادی تغییر نمی‌دهد.

از یک مقدار کلاس [BlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blackwhitemode/) برای انتخاب رفتار موردنظر استفاده کنید. برای مثال، `Automatic` به برنامه رندرسازی اجازه می‌دهد تبدیل را انتخاب کند، `Gray` و `LightGray` رنگ‌گریه‌ای استفاده می‌کنند، `BlackWhite` فقط سیاه و سفید استفاده می‌کند، `Black` و `White` یک رنگ را تحمیل می‌کنند، `Color` رنگ عادی را حفظ می‌کند، و `Hidden` شکل را در حالت سیاه‑سفید حذف می‌کند. `NotDefined` به این معنی است که هیچ حالت سطح‌شکل‌ای اختصاص داده نشده است.

این مثال یک مستطیل نارنجی ایجاد می‌کند و از [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) برای انتخاب رنگ‌گریه استفاده می‌کند. شکل ذخیره‌شده پرکردن نارنجی خود را برای نمایش رنگ عادی حفظ می‌کند و از برنامه‌های احترام‌گذار به تنظیمات نمایش سیاه‑سفید درخواست رنگ‌گریه می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

در حالت رنگ عادی، مستطیل پرکردن نارنجی خود را حفظ می‌کند. در یک جریان کاری نمایش سیاه‑سفید، به‌دلیل تنظیم حالت به `Gray`، از رنگ‌گریه استفاده می‌کند. این به شما امکان می‌دهد یک اسلاید رنگ‌تمام را حفظ کنید در حالی که ظاهر متمایزی برای چاپ، پیش‌نمایش یا سایر جریان‌های کاری که تنظیمات نمایش سیاه‑سفید ارائه را رعایت می‌کنند تعریف کنید.

## **بازنشانی قالب‌بندی**

از [Slide.reset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#reset) برای بازگرداندن موقعیت، اندازه و قالب‌بندی مکان‌نگهدارهای اسلاید از مکان‌نگهدارهای طرح‌بندی متناظر استفاده کنید. این مثال به یک ارائه موجود با مکان‌نگهدارهای پیوندی به طرح‌بندی نیاز دارد و قبل از ذخیره‌سازی، هر اسلاید را بازنشانی می‌کند. اشکالی که مکان‌نگهدارهای متناظر در طرح‌بندی ندارند بازنشانی نمی‌شوند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        slide.reset();
    }

    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**آیا قالب‌بندی شکل بر اندازه نهایی فایل ارائه تأثیر می‌گذارد؟**

رنگ‌ها، سبک‌های خط و تنظیمات افکت به‌طور کلی دادهٔ کمی نسبت به تصاویر و رسانه‌های جاسازی‌شده اضافه می‌کنند. پرکردن‌های تصویری می‌توانند اندازهٔ فایل را افزایش دهند زیرا تصاویرشان در ارائه ذخیره می‌شوند.

**چگونه می‌توانم اشکالی را در یک اسلاید که قالب‌بندی یکسانی دارند شناسایی کنم تا بتوانم آن‌ها را گروه‌بندی کنم؟**

هر یک از ویژگی‌های کلیدی قالب‌بندی شکل‌ها — پرکردن، خط و تنظیمات افکت — را مقایسه کنید. اگر تمام مقادیر متناظر مطابقت داشته باشند، سبک‌های آن‌ها را یکسان در نظر بگیرید و منطقی آن اشکال را گروه‌بندی کنید، که مدیریت سبک‌های بعدی را ساده می‌کند.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در یک فایل جداگانه ذخیره کنم تا در ارائه‌های دیگر استفاده شود؟**

بله. اشکال نمونه با سبک‌های موردنظر را در یک مجموعهٔ اسلاید قالب یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد یک ارائه جدید، قالب را باز کنید، اشکال سبک‌دار موردنیاز را کلون کنید، و قالب‌بندی آن‌ها را در هرجایی که لازم است دوباره اعمال کنید.