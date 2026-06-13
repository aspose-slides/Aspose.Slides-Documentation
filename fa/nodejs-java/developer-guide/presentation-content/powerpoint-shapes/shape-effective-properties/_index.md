---
title: دریافت ویژگی‌های مؤثر شکل از ارائه‌ها در JavaScript
linktitle: ویژگی‌های مؤثر
type: docs
weight: 50
url: /fa/nodejs-java/shape-effective-properties/
keywords:
- ویژگی‌های شکل
- ویژگی‌های دوربین
- نورپردازی
- شکل بویل
- قاب متن
- سبک متن
- ارتفاع قلم
- قالب پر کردن
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: کشف کنید Aspose.Slides برای Node.js از طریق Java چگونه ویژگی‌های مؤثر شکل را محاسبه و اعمال می‌کند تا رندر دقیق PowerPoint انجام شود.
---
## **نمای کلی**

این موضوع تفاوت بین ویژگی‌های **محلی** و **موثر** را توضیح می‌دهد. مقادیر محلی، مقادیری هستند که به طور مستقیم در یک سطح خاص قالب‌بندی تنظیم می‌شوند، مانند:

1. ویژگی‌های بخش بر روی یک اسلاید.
2. سبک‌های متن شکل نمونه در یک طرح‌بندی یا اسلاید اصلی، هنگامی که شکل قاب متن بخش دارای آن باشد.
3. تنظیمات متن سراسری در یک ارائه.

مقدارهای محلی می‌توانند در هر سطحی تعریف یا حذف شوند. وقتی Aspose.Slides به قالب‌بندی نهایی “به صورت رندر شده” نیاز دارد، زنجیرهٔ وراثت را حل می‌کند و مقادیر **موثر** را برمی‌گرداند. می‌توانید این مقادیر را با فراخوانی متد `getEffective` بر روی شیء قالب‌بندی محلی دریافت کنید.

مثال زیر نشان می‌دهد که چگونه مقادیر موثر را به دست آورید. فرض می‌شود که اولین شکل در اولین اسلاید یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) با یک قاب متن و حداقل یک بخش باشد.

```javascript

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    let localPortionFormat = paragraph.getPortions().get_Item(0).getPortionFormat();
    let effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
داده‌های قالب‌بندی مؤثر، قالب‌بندی محاسبه‌شدهٔ فعلی پس از اعمال وراثت را نشان می‌دهند. در پیاده‌سازی فعلی، برخی از اشیای دادهٔ مؤثر ممکن است به‌صورت داخلی کش شوند. فراخوانی دوبارهٔ `getEffective` پس از تغییر قالب‌بندی والد یا وراثت شده می‌تواند کش را تازه‌سازی کند و شیء‌ای که قبلاً دریافت شده ممکن است دیگر نشانگر وضعیت قبلی نباشد. اگر نیاز به حفظ مقادیر مؤثر برای استفادهٔ بعدی دارید، خصوصیات مورد نیاز مانند ارتفاع قلم، رنگ پر، سبک قلم یا تراز را در شیء دادهٔ خودتان کپی کنید.
{{% /alert %}}

## **دریافت ویژگی‌های مؤثر یک دوربین**

Aspose.Slides به شما امکان دریافت ویژگی‌های مؤثر یک دوربین را می‌دهد. شیء دادهٔ دوربین مؤثر شامل ویژگی‌های تغییرناپذیر دوربین است و از طریق مقادیر مؤثری که برای [ThreeDFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/) برگردانده می‌شود، در دسترس قرار می‌گیرد.

کد نمونهٔ زیر نشان می‌دهد که چگونه ویژگی‌های مؤثر دوربین را دریافت کنید. فرض می‌شود که اولین شکل در اولین اسلاید قالب‌بندی ۳بعدی دارد.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let camera = threeDEffectiveData.getCamera();
    let cameraType = camera.getCameraType();
    let fieldOfViewAngle = camera.getFieldOfViewAngle();
    let zoom = camera.getZoom();

    console.log("= Effective camera properties =");
    console.log("Type: " + cameraType);
    console.log("Field of view: " + fieldOfViewAngle);
    console.log("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **دریافت ویژگی‌های مؤثر یک Light Rig**

Aspose.Slides به شما امکان دریافت ویژگی‌های مؤثر یک Light Rig را می‌دهد. شیء دادهٔ Light Rig مؤثر شامل ویژگی‌های تغییرناپذیر Light Rig است و از طریق مقادیر مؤثری که برای [ThreeDFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/) برگردانده می‌شود، در دسترس قرار می‌گیرد.

کد نمونهٔ زیر نشان می‌دهد که چگونه ویژگی‌های مؤثر Light Rig را دریافت کنید. فرض می‌شود که اولین شکل در اولین اسلاید قالب‌بندی ۳بعدی دارد.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let lightRig = threeDEffectiveData.getLightRig();
    let lightType = lightRig.getLightType();
    let direction = lightRig.getDirection();

    console.log("= Effective light rig properties =");
    console.log("Type: " + lightType);
    console.log("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **دریافت ویژگی‌های مؤثر یک Bevel Shape**

Aspose.Slides به شما امکان دریافت ویژگی‌های مؤثر یک Bevel Shape را می‌دهد. شیء دادهٔ Bevel Shape مؤثر شامل ویژگی‌های تغییرناپذیر برجستگی (face‑relief) برای یک شکل است و از طریق مقادیر مؤثری که برای [ThreeDFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/) برگردانده می‌شود، در دسترس قرار می‌گیرد.

کد نمونهٔ زیر نشان می‌دهد که چگونه ویژگی‌های مؤثر برجستگی بالایی یک شکل را دریافت کنید. فرض می‌شود که اولین شکل در اولین اسلاید قالب‌بندی ۳بعدی دارد.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let bevelTop = threeDEffectiveData.getBevelTop();
    let bevelType = bevelTop.getBevelType();
    let bevelWidth = bevelTop.getWidth();
    let bevelHeight = bevelTop.getHeight();

    console.log("= Effective shape's top face relief properties =");
    console.log("Type: " + bevelType);
    console.log("Width: " + bevelWidth);
    console.log("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **دریافت ویژگی‌های مؤثر یک قاب متن**

با استفاده از Aspose.Slides، می‌توانید ویژگی‌های مؤثر یک قاب متن را دریافت کنید. شیء دادهٔ مؤثر برگردانده‌شده شامل خصوصیات قالب‌بندی قاب متن است.

کد نمونهٔ زیر نشان می‌دهد که چگونه خصوصیات قالب‌بندی مؤثر قاب متن را به دست آورید. فرض می‌شود که اولین شکل در اولین اسلاید یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) با یک قاب متن باشد.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = textFrameFormat.getEffective();
    let anchoringType = effectiveTextFrameFormat.getAnchoringType();
    let autofitType = effectiveTextFrameFormat.getAutofitType();
    let textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    let marginLeft = effectiveTextFrameFormat.getMarginLeft();
    let marginTop = effectiveTextFrameFormat.getMarginTop();
    let marginRight = effectiveTextFrameFormat.getMarginRight();
    let marginBottom = effectiveTextFrameFormat.getMarginBottom();

    console.log("Anchoring type: " + anchoringType);
    console.log("Autofit type: " + autofitType);
    console.log("Text vertical type: " + textVerticalType);
    console.log("Margins");
    console.log("   Left: " + marginLeft);
    console.log("   Top: " + marginTop);
    console.log("   Right: " + marginRight);
    console.log("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **دریافت ویژگی‌های مؤثر یک سبک متن**

با استفاده از Aspose.Slides، می‌توانید ویژگی‌های مؤثر یک سبک متن را دریافت کنید. شیء دادهٔ مؤثر برگردانده‌شده شامل خصوصیات سبک متن است.

کد نمونهٔ زیر نشان می‌دهد که چگونه خصوصیات مؤثر سبک متن را به دست آورید. فرض می‌شود که اولین شکل در اولین اسلاید یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) با یک قاب متن باشد.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);
    let effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    let levelCount = 9;

    for (let levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        let effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        let depth = effectiveStyleLevel.getDepth();
        let indent = effectiveStyleLevel.getIndent();
        let alignment = effectiveStyleLevel.getAlignment();
        let fontAlignment = effectiveStyleLevel.getFontAlignment();

        console.log("= Effective paragraph formatting for style level #" + levelIndex + " =");

        console.log("Depth: " + depth);
        console.log("Indent: " + indent);
        console.log("Alignment: " + alignment);
        console.log("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **دریافت مقدار ارتفاع قلم مؤثر**

با استفاده از Aspose.Slides، می‌توانید ارتفاع قلم مؤثر را دریافت کنید. کد زیر نشان می‌دهد که چگونه ارتفاع قلم مؤثر یک بخش پس از تنظیم مقادیر ارتفاع قلم محلی در سطوح مختلف ساختار ارائه تغییر می‌کند.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shapeType = aspose.slides.ShapeType.Rectangle;
    let autoShape = slide.getShapes().addAutoShape(shapeType, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    let firstPortion = new aspose.slides.Portion("Sample text with first portion");
    let secondPortion = new aspose.slides.Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    let firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    let secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    let firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    let secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height just after creation:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting the presentation default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting paragraph default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #0 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #1 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    let saveFormat = aspose.slides.SaveFormat.Pptx;
    presentation.save("SetLocalFontHeightValues.pptx", saveFormat);
} finally {
    presentation.dispose();
}
```

## **دریافت قالب پر کردن مؤثر برای یک جدول**

با استفاده از Aspose.Slides، می‌توانید قالب پر کردن مؤثر برای قسمت‌های مختلف جدول را دریافت کنید. شیء دادهٔ مؤثر برگردانده‌شده شامل خصوصیات قالب پر کردن است. قالب‌بندی سلول نسبت به قالب‌بندی ردیف اولویت بالاتری دارد، قالب‌بندی ردیف نسبت به قالب‌بندی ستون و قالب‌بندی ستون نسبت به قالب‌بندی کل جدول اولویت بالاتری دارد.

در نتیجه، خصوصیات قالب‌بندی مؤثر سلول برای رسم سلول جدول استفاده می‌شود. کد نمونهٔ زیر نشان می‌دهد که چگونه قالب پر کردن مؤثر برای قسمت‌های مختلف جدول را به دست آورید. فرض می‌شود که اولین شکل در اولین اسلاید یک [Table](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/table/) باشد.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let table = slide.getShapes().get_Item(0);

    let tableFormatEffective = table.getTableFormat().getEffective();
    let rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    let columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    let cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    let tableFillFormatEffective = tableFormatEffective.getFillFormat();
    let rowFillFormatEffective = rowFormatEffective.getFillFormat();
    let columnFillFormatEffective = columnFormatEffective.getFillFormat();
    let cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

**آیا `getEffective` یک snapshot برمی‌گرداند؟**

همیشه نیست. داده‌های مؤثر قالب‌بندی محاسبه‌شده پس از اعمال وراثت را نشان می‌دهند، اما ممکن است برخی از اشیای دادهٔ مؤثر به‌صورت داخلی کش شوند. فراخوانی بعدی `getEffective` ممکن است قالب‌بندی را دوباره محاسبه کند و کش را تازه‌سازی کند، بنابراین شیء‌ای که قبلاً دریافت شده نباید به‌عنوان یک snapshot دائمی در نظر گرفته شود.

**چه زمانی باید ویژگی‌های مؤثر را دوباره بخوانم؟**

پس از تغییر قالب‌بندی محلی، سبک‌های والد، قالب‌بندی طرح‌بندی، قالب‌بندی اصلی یا پیش‌فرض‌های سطح ارائه، `getEffective` را دوباره فراخوانی کنید. فراخوانی بعدی سلسله‌مراتبی قالب‌بندی را مجدداً ارزیابی می‌کند و نتیجهٔ مؤثر فعلی را برمی‌گرداند.

**آیا تغییر یا حذف یک اسلاید طرح‌بندی/اصلی بر ویژگی‌های مؤثری که قبلاً دریافت شده‌اند تأثیر می‌گذارد؟**

بله، اما تغییر تنها در فراخوانی بعدی `getEffective` بازتاب می‌یابد. اگر منبع قالب‌بندی والد تغییر یا حذف شود، دادهٔ مؤثر قبلاً دریافت‌شده ممکن است منسوخ شود. با فراخوانی دوباره `getEffective`، Aspose.Slides درخت قالب‌بندی را مجدداً ارزیابی می‌کند و ممکن است فونت‌ها، رنگ‌ها، اندازه‌ها یا مقادیر دیگر تغییر کنند.

**آیا می‌توانم مقادیر را از طریق اشیای دادهٔ مؤثر تغییر دهم؟**

نه. اشیای دادهٔ مؤثر فقط مقادیر محاسبه‌شده را نشان می‌دهند. تغییرات را در اشیای قالب‌بندی محلی اعمال کنید و سپس مقادیر مؤثر را دوباره دریافت کنید.

**اگر ویژگی‌ای در سطح شکل، در طرح‌بندی/اسلاید اصلی یا تنظیمات سراسری تنظیم نشده باشد، چه می‌شود؟**

مقدار مؤثر بر پایهٔ مکانیزم پیش‌فرض تعیین می‌شود که شامل پیش‌فرض‌های PowerPoint و Aspose.Slides می‌شود. آن مقدار حل‌شده بخشی از دادهٔ مؤثر جاری می‌شود.

**آیا می‌توانم از مقدار قلم مؤثر تشخیص دهم که کدام سطح اندازه یا نوع فونت را ارائه داده است؟**

به‌طور مستقیم نمی‌توان. دادهٔ مؤثر فقط مقدار نهایی را برمی‌گرداند. برای پیدا کردن منبع، مقادیر محلی را در بخش، پاراگراف، قاب متن و سبک‌های متن در سطوح طرح‌بندی، اصلی و ارائه بررسی کنید تا اولین تعریف صریح را بیابید.

**چرا گاهی مقادیر مؤثر شبیه به مقادیر محلی به نظر می‌رسند؟**

چون مقدار محلی در نهایت نهایی شده است (نیازی به وراثت از سطح بالاتر نبوده). در چنین مواردی مقدار مؤثر با مقدار محلی یکسان است.

**چه زمانی باید از ویژگی‌های مؤثر استفاده کنم و چه زمانی فقط با ویژگی‌های محلی کار کنم؟**

زمانی که به نتیجهٔ “به صورت رندر شده” پس از اعمال تمام وراثت‌ها نیاز دارید—مثلاً برای تطبیق رنگ‌ها، تو رفتگی‌ها یا اندازه‌ها—از دادهٔ مؤثر استفاده کنید. اگر می‌خواهید این مقادیر را صرف‌نظر از تغییرات آینده قالب‌بندی حفظ کنید، خصوصیات مورد نیاز را در شیء خود کپی کنید. اگر می‌خواهید قالب‌بندی را در سطح خاصی تغییر دهید، ویژگی‌های محلی را اصلاح کنید و سپس در صورت نیاز دادهٔ مؤثر را دوباره خوانده تا نتیجه را تأیید کنید.