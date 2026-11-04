---
title: قالب‌بندی اشکال PowerPoint در JavaScript
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/nodejs-java/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- اثر طرح‌دار
- خط شکل طرح‌دار
- قالب‌بندی سبک جوین
- پر کردن گرادیان
- پر کردن الگو
- پر کردن تصویر
- پر کردن بافت
- پر کردن با رنگ ثابت
- شفافیت شکل
- رندر سیاه‑سفید شکل
- رندر خاکستری شکل
- چرخاندن شکل
- اثر برجسته‌سازی 3D
- اثر چرخش 3D
- بازنشانی قالب‌بندی
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "نحوهٔ قالب‌بندی اشکال PowerPoint را در JavaScript با استفاده از Aspose.Slides بیاموزید—پر کردن، خط و سبک‌های اثر را برای فایل‌های PPT و PPTX با دقت و کنترل کامل تنظیم کنید."
---
## **مقدمه**

شکل‌ها را در PowerPoint با تنظیم حاشیه، پرکننده و اثراتشان قالب‌بندی کنید. Aspose.Slides for Node.js via Java به شما امکان می‌دهد این تنظیمات را به‌صورت برنامه‌نویسی کنترل کنید، از جمله شفافیت، چرخش و قالب‌بندی 3‑بعدی.

![گزینه‌های فرمت‌بندی شکل در PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java کلاس‌ها و متدهایی فراهم می‌کند که به شما اجازه می‌دهد شکل‌ها را با همان گزینه‌های موجود در PowerPoint قالب‌بندی کنید.

## **فرمت خطوط**

از [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) برای کنترل حاشیهٔ یک شکل استفاده کنید. این مثال یک مستطیل بدون پرکننده با حاشیهٔ آبی، خط‌چین ایجاد می‌کند. [LineFormat.setStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setStyle) یک خط ترکیبی ضخیم‑نازک را انتخاب می‌کند، در حالی که [LineFormat.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setWidth) عرض آن را به ۷ پوینت تنظیم می‌کند و [LineFormat.setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setDashStyle) الگوی خط‌چین را انتخاب می‌کند.

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

![خطوط قالب‌بندی‌شده در ارائه](formatted-lines.png)

### **تنظیم الگوهای خط سفارشی**

وقتی سبک‌های پیش‌فرض خط طول‌ها و فاصله‌های مورد نیاز شما را فراهم نمی‌کنند، از [LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setCustomDashPattern) استفاده کنید، برای مثال برای حاشیه‌های برند یا نمودارهای فنی. اختصاص یک الگو به‌طور خودکار سبک خط‌چین را به [LineDashStyle.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) تغییر می‌دهد.

ورودی‌های آرایه به‌صورت متناوب بین طول خط و فاصله تعویض می‌شوند، از خط شروع می‌شود. هر مقدار مضربی از عرض خط است: `[4, 2]` با عرض ۳ پوینت یک خط ۱۲‑پوینتی به‌همراه فاصلهٔ ۶‑پوینتی تولید می‌کند. برای تعریف بخش‌های کامل خط‑و‑فاصله از جفت مقادیر متناهی و غیرمنفی استفاده کنید. این مثال برای وضوح همهٔ خطوط و فواصل از مقادیر مثبت استفاده می‌کند.

این مثال پنج خط آبی با طول یکسان و سرهای صاف ایجاد می‌کند. سه خط اول الگوها را با عرض ۳ پوینت مقایسه می‌کنند. خط چهارم الگوی اول را با دو برابر عرض تکرار می‌کند و هم طول خط و هم فاصله را دو برابر می‌کند. خط پنجم از الگوی سفارشی به خط پیوسته تغییر می‌دهد.

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

    // خط آخر را به سبک ثابت باز می‌گردانیم.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Solid));

    presentation.save("custom_dash_patterns.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای بازگشت به یک سبک پیش‌فرض خط‌چین، به‌جای آن، [LineDashStyle.Dash](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) را به [LineFormat.setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setDashStyle) پاس دهید. سبک انتخاب‌شده ظاهر خط را کنترل می‌کند.

نتیجه در PowerPoint، از بالا به پایین: **{4, 2}, 3 pt**؛ **{1, 2}, 3 pt**؛ **{6, 2, 1, 2}, 3 pt**؛ **{4, 2}, 6 pt**؛ و **Solid, 3 pt**.

![سه الگوی خط سفارشی، یک خط پهن‌تر با الگوی اول، و یک خط پیوسته در PowerPoint](custom-dash-patterns.png)

### **تنظیم سرهای خط**

از [LineFormat.setCapStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setCapStyle) برای تنظیم انتهای یک خط باز استفاده کنید. کلاس [LineCapStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linecapstyle/) سه سبک سر صریح را ارائه می‌دهد:

- `Flat`: قلم در نقطهٔ انتهایی متوقف می‌شود.
- `Round`: یک سر نیم‌دایره‌ای تا نصف عرض خط فراتر از نقطهٔ انتها ادامه می‌یابد.
- `Square`: یک سر مربعی تا نصف عرض خط فراتر از نقطهٔ انتها ادامه می‌یابد.

این کلاس همچنین `NotDefined` را شامل می‌شود که به این معنی است که هیچ سبک سر صریحی اختصاص داده نشده است.

سرها متفاوت از سرهای پیکان هستند که نمادهایی به انتهای خط اضافه می‌کنند، و از جوین‌ها که گوشه‌های بین قطعات خط را کنترل می‌کنند. این مثال سرهای پیکان را با استفاده از [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setBeginArrowheadStyle) و [LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setEndArrowheadStyle) غیرفعال می‌کند تا فقط شکل‌های سر مقایسه شوند.

مثال زیر سه خط افقی تقریباً یکسان با عرض ۲۰ پوینت ایجاد می‌کند. از بالا به پایین، سرهای flat، round و square استفاده می‌شوند. نقاط انتهایی آن‌ها مختصات افقی یکسانی دارند؛ سرهای round و square ۱۰ پوینت بالاتر از هر انتها گسترش می‌یابند.

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

نتیجه در PowerPoint، از بالا به پایین: **Flat**, **Round**, و **Square**.

![سرهای flat، round و square بر روی خطوط ضخیم یکسان در PowerPoint](line-caps.png)

## **اعمال اثرات طرح‌دار بر خطوط شکل**

یک اثر طرح‌دار باعث می‌شود خط شکل شبیه به دست‌نویس شود. از [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) برای دسترسی به تنظیمات خط، از [LineFormat.getSketchFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getSketchFormat) برای دسترسی به تنظیمات طرح‌دار و از [SketchFormat.setSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/#setSketchType) برای انتخاب مقدار از کلاس [LineSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) استفاده کنید.

کد JavaScript زیر نشان می‌دهد چگونه اثر [LineSketchType.Curved](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) را اعمال کنید، مقدار اختصاص‌یافته صریح را بخوانید و اثر را با [LineSketchType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) حذف کنید:

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

مقداری که توسط [SketchFormat.getSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/#getSketchType) بازگردانده می‌شود، تنظیمی را نشان می‌دهد که مستقیماً به شکل اختصاص یافته است. اگر قالب‌بندی خط می‌تواند از یک تم، اسلاید مستر یا اسلاید چیدمان به ارث برده شود، از [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getEffective) استفاده کنید، `getSketchFormat` را روی شیء برگردانده شده فراخوانی کنید و سپس متد `getSketchType` آن را صدا بزنید. مقدار مؤثر بازتاب‌دهندهٔ قالب‌بندی است که پس از حل ارث‌بری واقعی اعمال می‌شود. این مثال نیاز به یک ارائهٔ موجود دارد که حداقل یک شکل در اولین اسلاید داشته باشد و هر دو مقدار را چاپ می‌کند:

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

## **فرمت‌گذاری سبک‌های وصل**

در اینجا سه گزینهٔ نوع جوین وجود دارد:

* Round
* Miter
* Bevel

سبک جوین کنترل می‌کند که دو قطعهٔ حاشیه چگونه در یک گوشه به هم می‌رسند. برای گوشه‌های گرد از **Round**، برای گوشه‌های تیز از **Miter** و برای گوشه‌های صاف از **Bevel** استفاده کنید.

![سبک جوین در ارائه](join-style-powerpoint.png)

این مثال سه مستطیل سیاه با حاشیهٔ آبی ۱۵ پوینت ایجاد می‌کند. از [LineFormat.setJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setJoinStyle) برای اعمال مقادیر miter، bevel و round از کلاس [LineJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linejoinstyle/) به ترتیب استفاده می‌کند تا نشان دهد گوشه‌ها چگونه رسم می‌شوند.

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

### **محدود کردن جوین‌های Miter در گوشه‌های تیز**

از [LineFormat.setMiterLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setMiterLimit) همراه با [LineFormat.setJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setJoinStyle) تنظیم‌شده بر روی [LineJoinStyle.Miter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linejoinstyle/) برای محدود کردن طول بیشینهٔ یک گوشهٔ تیز استفاده کنید.

محدودیت نسبتی است بین فاصلهٔ داخلی و خارجی گوشهٔ جوین نسبت به عرض خط. به‌عنوان مثال مقدار `8` اجازه می‌دهد طول miter تا هشت برابر عرض خط باشد؛ این یک واحد اندازه‌گیری در پوینت نیست. اگر گوشه از این حد فراتر رود، PowerPoint در آن گوشه از جوین beveled استفاده می‌کند. محدودیت بزرگ‌تر نقاط تیزتر ایجاد می‌کند. این تنظیم فقط بر جوین‌های miter تأثیر می‌گذارد و تغییر آن وقتی گوشه در هر دو حد قرار دارد، اثر قابل مشاهده‌ای ندارد.

این مثال دو مثلث هم‌ساخت بدون پرکننده با حاشیهٔ ۲۰ پوینت ایجاد می‌کند. مثلث چپ از حد `2` و مثلث راست از حد `8` استفاده می‌کند. هر مثلث ۸۰ پوینت عرض و ۱۶۰ پوینت ارتفاع دارد، به‌طوری که نسبت طول miter به عرض خط در بالای آن تقریباً `4.12` است. در نتیجه PowerPoint انتهای چپ را bevel می‌کند و انتهای راست را حفظ می‌کند.

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

![یک رأس beveled با حد miter 2 و یک رأس نوک‌دار با حد miter 8 در PowerPoint](miter-limits.png)

## **پر کردن گرادیان**

پر کردن گرادیان رنگ‌ها را در یک شکل به‌صورت تدریجی ترکیب می‌کند. این مثال یک بیضی را با یک گرادیان خطی در زاویهٔ ۴۵ درجه از قرمز به بنفش پر می‌کند با استفاده از [FillFormat.getGradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getGradientFormat). روش [GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientstopcollection/#addPresetColor) رنگ‌های توقف را در موقعیت ۰ و ۱، آغاز و انتهای گرادیان، قرار می‌دهد. حذف توقف‌های موجود تضمین می‌کند که فقط این دو رنگ استفاده شوند.

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

![بیضی با پر کردن گرادیان](gradient-fill.png)

اگر یک گرادیان در تصویر خروجی نسبت به همان‌طور که در PowerPoint دیده می‌شود متفاوت باشد، راهنمایی [Choose a Gradient Rendering Style](/slides/fa/nodejs-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) را ببینید. می‌توانید بدون تغییر گرادیان ذخیره‌شده در ارائه، سبک رندرینگ را انتخاب کنید.

### **تنظیم زاویهٔ گرادیان خطی**

از [GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientAngle) برای کنترل جهت یک پر کردن [GradientShape.Linear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientshape/) استفاده کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود و ساعت‌گرد افزایش می‌یابد: `0` از چپ به راست، `90` از بالا به پایین، `180` از راست به چپ و `270` از پایین به بالا. زوایای کسری پشتیبانی می‌شوند. زوایای متناهی خارج از `[0, 360)` به یک چرخش کامل نرمال‌سازی می‌شوند؛ برای مثال `-45` تبدیل به `315` و `360` تبدیل به `0` می‌شود.

این مثال شش مستطیل با توقف‌های رنگی قرمز، سبز و آبی یکسان در موقعیت‌های `0`، `0.5` و `1` ایجاد می‌کند. مقیاس‌سازی غیرفعال است تا زاویه مستقل از نسبت‌های مستطیل‌ها مقایسه شود. زوایا، از چپ به راست، `0`، `45` و `90` در ردیف اول، و `135`، `180` و `270` در ردیف دوم هستند.

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

![گرادیان‌های خطی در زاویه‌های 0، 45 و 90 درجه در ردیف بالا، و 135، 180 و 270 درجه در ردیف پایین](linear-gradient-angles.png)

### **مقیاس‌بندی یک گرادیان خطی با شکل**

[GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientScaled) یک مقدار [NullableBool](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) می‌گیرد. به‌صورت صریح `False` تنظیم کنید تا زاویهٔ هندسی گرادیان در تغییر ابعاد شکل ثابت بماند، یا `True` تا گرادیان با عرض و ارتفاع شکل مقیاس‌بندی شود. با فعال‌سازی مقیاس‌بندی، زاویهٔ قابل مشاهده می‌تواند در یک شکل غیر مربع متفاوت از زاویهٔ اختصاص‌یافته باشد.

مثال زیر از زاویهٔ `45` درجه و همان توقف‌های رنگی استفاده می‌کند که در مقایسهٔ زاویه استفاده شد. ستون چپ `False`؛ ستون راست `True`. هر ستون شامل یک مستطیل عریض در بالا و یک مستطیل بلند در پایین است. هر دو با همان ابعاد عریض شروع می‌شوند؛ تغییر عرض و ارتفاع مستطیل دوم نشان می‌دهد پر کردن چگونه بدون تغییر تنظیمات گرادیان به تغییر اندازه واکنش نشان می‌دهد.

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

نتیجه در PowerPoint، با مقیاس‌بندی غیرفعال در چپ و فعال در راست:

![مستطیل‌های عریض و بلند با گرادیان 45 درجه، مقایسه‌ٔ LinearGradientScaled False در چپ با True در راست](linear-gradient-scaling.png)

با غیرفعال بودن مقیاس‌بندی، باندهای رنگی قطری همان جهت را در هر دو مستطیل حفظ می‌کنند. با فعال شدن مقیاس‌بندی، باندها با نسبت‌های شکل کشیده می‌شوند. این کمک می‌کند تا یک قالب گرادیان را هنگام تغییر اندازهٔ شکل بازتولید کنید. در یک مربع، فعال‌سازی مقیاس‌بندی تغییری در ظاهر این گرادیان 45 درجه ایجاد نمی‌کند.

هر دو تنظیم زاویه و مقیاس برای گرادیان‌های خطی اعمال می‌شود. آنها بر پر کردن‌های [GradientShape.Radial یا GradientShape.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientshape/) کنترل ندارند.

### **ترکیب زاویه با جهت گرادیان**

[GradientFormat.setGradientDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setGradientDirection) یک سبک گرادیان را از کلاس [GradientDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientdirection/) انتخاب می‌کند؛ این جایگزین یک زاویهٔ عددی نیست. برای یک گرادیان خطی، سبک‌های گوشه می‌توانند مساحت توزیع رنگ‌ها را بدون تغییر زاویهٔ اختصاصی شده توسط [setLinearGradientAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientAngle) تغییر دهند. هنگام مقایسهٔ زوایا یا مقیاس‌بندی، جهت را ثابت نگه دارید.

مثال زیر همان تنظیمات را به ترتیب مخالف اعمال می‌کند. دو مستطیل همان ظاهر را دارند: اختصاص جهت قبل یا بعد از زاویه نتیجه را تغییر نمی‌دهد.

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

## **پر کردن با الگو**

پر کردن با الگو یک طرح دو‌رنگ مانند نقاط، خطوط یا شطرنجی‌ها را اعمال می‌کند. این مثال از [PatternFormat.setPatternStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#setPatternStyle) برای انتخاب یک الگوی trellis استفاده می‌کند. [PatternFormat.getBackColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getBackColor) پس‌زمینهٔ خاکستری روشن را فراهم می‌کند و [PatternFormat.getForeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getForeColor) رنگ زرد الگو را فراهم می‌کند.

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

![مستطیل با پر کردن الگو](pattern-fill.png)

## **پر کردن با تصویر**

پر کردن با تصویر یک تصویر را داخل یک شکل قرار می‌دهد. این مثال نیاز به یک تصویر محلی دارد و از [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) برای بارگذاری آن در مجموعهٔ تصاویر ارائه استفاده می‌کند. تنظیم [PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode) به حالت کاشی (Tile) تصویر را داخل مستطیل تکرار می‌کند. تصویر منبع استفاده‌شده در زیر نشان داده شده است:

![تصویر لوتوس](lotus.png)

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

![شکل با پر کردن تصویر](picture-fill.png)

### **کاشی تصویر به عنوان بافت**

اگر می‌خواهید یک تصویر کاشی‌شده را به عنوان بافت تنظیم کنید و رفتار کاشی‌گذاری را سفارشی کنید، می‌توانید از متدهای زیر کلاس [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) استفاده کنید:

- [setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): حالت پر کردن تصویر را تنظیم می‌کند — `Tile` یا `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): تراز کاشی‌ها را در داخل شکل مشخص می‌کند.
- [setTileFlip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): کنترل می‌کند که آیا کاشی به‌صورت افقی، عمودی یا هر دو معکوس شود.
- [setTileOffsetX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): افست افقی کاشی (به پوینت) را نسبت به مبدأ شکل تنظیم می‌کند.
- [setTileOffsetY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): افست عمودی کاشی (به پوینت) را نسبت به مبدأ شکل تنظیم می‌کند.
- [setTileScaleX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): مقیاس افقی کاشی را به‌صورت درصد تعریف می‌کند.
- [setTileScaleY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): مقیاس عمودی کاشی را به‌صورت درصد تعریف می‌کند.

این مثال نیاز به یک تصویر محلی دارد و [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) را تنظیم می‌کند تا تصویر را با اندازهٔ ۵۰٪ از اندازهٔ اصلیش تکرار کند. افست‌های −32 پوینت تصویر را به‌صورت افقی و عمودی جابه‌جا می‌کند؛ تراز راست‑پایین و معکوس شدن در هر دو جهت تعیین می‌کند که بافت تکراری چگونه چیده شود.

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

![گزینه‌های کاشی](tile-options.png)

## **پر کردن با رنگ ثابت**

یک پر کردن ثابت یک رنگ یکنواخت به شکل می‌دهد. این مثال از [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) برای انتخاب حالت پر کردن ثابت استفاده می‌کند و رنگ زرد را از طریق [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor) اختصاص می‌دهد، سپس مستطیل را در یک ارائه ذخیره می‌کند.

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

![شکل با پر کردن رنگ ثابت](solid-color-fill.png)

## **استفاده از پس‌زمینهٔ اسلاید به‌عنوان پر کردن شکل**

از [AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#setUseBackgroundFill) استفاده کنید زمانی که یک شکل باید با پس‌زمینهٔ اسلاید مطابقت داشته باشد، برای مثال در یک الگوی ارائه. ابتدا با استفاده از [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) مقدار [FillType.NotDefined](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) را انتخاب کنید تا هر پر کردن صریحی حذف شود. با این ترکیب، شکل به جای سبک پر کردن خود، از پس‌زمینهٔ اسلاید استفاده می‌کند. فعال‌سازی تنها این پرچم، پر کردن صریح موجود را حذف نمی‌کند.

این رفتار متفاوت از [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) است: پر کردن پس‌زمینه اشیائی را که پشت شکل قرار دارند با ناحیهٔ متناظر پس‌زمینهٔ اسلاید می‌پوشاند، در حالی که بدون پر کردن آن اشیا قابل مشاهده می‌مانند. یک گرادیان همچنان با اسلاید هم‌راستا می‌ماند نه اینکه داخل هر شکل دوباره آغاز شود.

مثال زیر یک پس‌زمینهٔ مستر که توسط اسلاید به ارث می‌رسد ایجاد می‌کند و نوار صورتی را پشت سه مستطیل قرار می‌دهد. مستطیل چپ از پس‌زمینه استفاده می‌کند، مستطیل وسط هیچ پر کردن ندارد و مستطیل راست از پر کردن پس‌زمینه به یک پر کردن صریح نارنجی تغییر می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    // گرادیان را از مستر به ارث می‌گیرد.
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

    // این شی را ابتدا اضافه کنید تا پشت مستطیل‌ها ظاهر شود.
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

    // قبل از اعمال پر کردن صریح، پر کردن پس‌زمینه را غیرفعال کنید.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    explicitShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));

    presentation.save("background_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه، از چپ به راست: **پر کردن پس‌زمینه**، **بدون پر کردن** و **پر کردن صریح**. نوار صورتی توسط مستطیل‌های چپ و راست скрыт می‌شود اما از طریق مستطیل وسط قابل رؤيت است.

![پر کردن پس‌زمینه، بدون پر کردن، و پر کردن نارنجی صریح روی یک نوار صورتی](background-fill.png)

رفتار مشابه برای پس‌زمینه‌ای که مستقیماً بر روی اسلاید تعریف شده یا از یک چیدمان به ارث برده می‌شود، اعمال می‌شود. شکل از پس‌زمینهٔ حل‌شدهٔ اسلاید استفاده می‌کند؛ این مثال هر دو پس‌زمینهٔ اسلاید و چیدمان را تعریف نشده می‌گذارد تا مستر آن را تامین کند.

## **تنظیم شفافیت**

برای یک پر کردن ثابت، مؤلفهٔ آلفای رنگ، میزان شفافیت را کنترل می‌کند: ۰ به‌طور کامل شفاف و ۲۵۵ به‌طور کامل مات است. این مثال از مقدار آلفا ۱۲۸ برای یک مستطیل زرد استفاده می‌کند، به‌طوری که تقریباً ۵۰٪ شفاف باشد و مستطیل زیرین قابل رؤیت بماند. رنگ از طریق [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor) اختصاص می‌یابد.

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

از [Shape.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) برای چرخاندن یک شکل در صفحهٔ اسلاید استفاده کنید. زاوه بر حسب درجه اندازه‌گیری می‌شود؛ این مثال یک مستطیل را ۵ درجه ساعت‌گرد می‌چرخاند و ارائه را ذخیره می‌کند.

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

## **افزودن افکت‌های برجسته‌سازی 3D**

از [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) برای افزودن عمق و لبه‌های برجسته به یک شکل استفاده کنید. این مثال یک بیضی سبز با حاشیهٔ نارنجی ایجاد می‌کند، از [ThreeDFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) برای تنظیم عمق به ۴ پوینت استفاده می‌کند و یک برجستهٔ بالایی دایره‌ای با عرض و ارتفاع ۶ پوینت از طریق [ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelTop) اعمال می‌کند. یک دوربین ارتوغرافیک روبه‌رو و نور سه‑نقطه‌ای برجسته را قابل مشاهده می‌سازند.

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

![افکت برجسته‌سازی 3D](3D-bevel-effect.png)

## **افزودن افکت‌های چرخش 3D**

نمایش 3D یک شکل توسط تنظیمات دوربین آن کنترل می‌شود. این مثال از [Camera.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setRotation) با زوایای عرض، طول و چرخش ۴۰، ۳۵ و ۲۰ درجه به ترتیب استفاده می‌کند. یک دوربین ایزومتریک را از طریق [Camera.setCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setCameraType) و نورپردازی متعادل را از طریق [LightRig.setLightType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lightrig/#setLightType) انتخاب می‌کند، سپس مستطیل قالب‌بندی‌شده را ذخیره می‌کند.

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

![افکت چرخش 3D](3D-rotation-effect.png)

## **کنترل رندر سیاه‑سفید برای اشکال**

متد [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) مشخص می‌کند که یک شکل منفرد چگونه هنگام نمایش یا پردازش ارائه در حالت سیاه‑سفید رندر شود. این متد به‌تنهایی نمایش سیاه‑سفید را فعال نمی‌کند و پر کردن، خط یا سایر قالب‌بندی‌های شکل را در حالت رنگی عادی تغییر نمی‌دهد.

یک مقدار از کلاس [BlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blackwhitemode/) را برای انتخاب رفتار موردنظر استفاده کنید. برای مثال، `Automatic` اجازه می‌دهد برنامه رندرینگ تبدیل را انتخاب کند، `Gray` و `LightGray` از رنگ‌آمیزی خاکستری استفاده می‌کنند، `BlackWhite` تنها سیاه و سفید را به‌کار می‌برد، `Black` و `White` یک رنگ ثابت را تحمیل می‌کنند، `Color` رنگ‌گذاری عادی را حفظ می‌کند و `Hidden` شکل را در حالت سیاه‑سفید حذف می‌کند. `NotDefined` به این معنی است که هیچ حالت سطح‑شکلی اختصاص نیافته است.

این مثال یک مستطیل نارنجی ایجاد می‌کند و از [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) برای انتخاب رنگ‌سازی خاکستری استفاده می‌کند. شکل ذخیره‌شده پرکردن نارنجی خود را برای نمایش رنگی عادی حفظ می‌کند و برای برنامه‌هایی که تنظیمات نمایش سیاه‑سفید را رعایت می‌کنند، درخواست رنگ‌سازی خاکستری می‌کند:

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

در حالت رنگی عادی، مستطیل پرکردن نارنجی خود را حفظ می‌کند. در یک گردش کاری نمایش سیاه‑سفید، از رنگ‌سازی خاکستری استفاده می‌کند چون حالت آن روی `Gray` تنظیم شده است. این به شما امکان می‌دهد یک اسلاید تمام‌رنگ را حفظ کنید و ظاهر متفاوتی برای چاپ، پیش‌نمایش یا گردش‌های کاری دیگر که تنظیمات نمایش سیاه‑سفید ارائه را رعایت می‌کنند، تعریف کنید.

## **بازنشانی فرمت‌بندی**

از [Slide.reset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#reset) برای بازگرداندن موقعیت، اندازه و قالب‌بندی جای‌نگهدارهای اسلاید از جای‌نگهدارهای متناظر در طرح‌بندی استفاده کنید. این مثال به یک ارائهٔ موجود با جای‌نگهدارهای مرتبط با طرح‌بندی نیاز دارد و قبل از ذخیره هر اسلاید را بازنشانی می‌کند. اشکالی که جای‌نگهدار متناظر در طرح‌بندی ندارند، بازنشانی نمی‌شوند.

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

## **سوالات متداول**

**آیا فرمت‌بندی شکل بر حجم نهایی فایل ارائه تأثیر می‌گذارد؟**

رنگ‌ها، سبک‌های خط و تنظیمات اثر معمولاً دادهٔ کمی اضافه می‌کنند نسبت به تصاویر و رسانه‌های جاسازی‌شده. پر کردن با تصویر می‌تواند حجم فایل را افزایش دهد زیرا تصاویر آن در ارائه ذخیره می‌شوند.

**چگونه می‌توانم شکل‌هایی را در یک اسلاید شناسایی کنم که قالب‌بندی یکسان دارند تا بتوانم آن‌ها را گروه‌بندی کنم؟**

ویژگی‌های کلیدی قالب‌بندی هر شکل — پر کردن، خط و تنظیمات اثر — را مقایسه کنید. اگر تمام مقادیر متناظر برابر باشند، سبک آن‌ها را یکسان در نظر بگیرید و آن شکل‌ها را به‌صورت منطقی گروه‌بندی کنید؛ این کار مدیریت سبک‌ها را در مراحل بعدی ساده می‌کند.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در فایلی جداگانه ذخیره کنم تا در ارائه‌های دیگر استفاده کنم؟**

بله. شکل‌های نمونه با سبک‌های موردنظر را در یک اسلاید قالب یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد یک ارائهٔ جدید، قالب را باز کنید، شکل‌های سبک‌دار موردنیاز را کپی کنید و قالب‌بندی آن‌ها را در هر جایی که نیاز دارید دوباره اعمال کنید.