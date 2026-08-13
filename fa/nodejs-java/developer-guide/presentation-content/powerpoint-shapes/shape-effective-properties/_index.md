---
title: "دریافت ویژگی‌های مؤثر شکل از ارائه‌ها در JavaScript"
linktitle: "ویژگی‌های مؤثر"
type: docs
weight: 50
url: /fa/nodejs-java/shape-effective-properties/
keywords:
- "ویژگی‌های شکل"
- "ویژگی‌های دوربین"
- "نورپردازی"
- "شکل برجسته"
- "قالب متن"
- "سبک متن"
- "ارتفاع قلم"
- "قالب پرکن"
- "PowerPoint"
- "ارائه"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "یاد بگیرید چگونه از Aspose.Slides برای Node.js از طریق Java استفاده کنید تا قالب‌بندی محلی، ارث‌بری و مؤثر اشکال را در ارائه‌های PowerPoint تشخیص دهید."
---
## **درک ویژگی‌های محلی، ارث‌بری و مؤثر**

قالب‌بندی در PowerPoint می‌تواند از مکان‌های مختلفی بیاید. مقداری که مستقیماً روی یک شیء ذخیره می‌شود، **مقدار محلی** آن است. اگر آن مقدار تنظیم نشده باشد، PowerPoint به منابع قالب‌بندی والد نگاه می‌کند، مانند پیش‌فرض پاراگراف، سبک متن، طرح یا اسلاید اصلی، تم یا پیش‌فرض‌های سطح ارائه. این مقادیر **مقادیر ارث‌بری** هستند. مقداری که پس از حل کامل سلسله مراتب باقی می‌ماند، **مقدار مؤثر** است — مقداری که برای رندر کردن شیء استفاده می‌شود.

به‌عنوان مثال، ممکن است یک بخش متن ارتفاع قلم خود را تعریف نکند. مقدار محلی آن با متد [getFontHeight](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portionformat/#getFontHeight) سپس `NaN` خواهد بود که به معنای «در اینجا تنظیم نشده» است. این بخش می‌تواند ارتفاع را از پاراگراف خود، سبک متن پیش‌فرض ارائه یا منبع دیگری به ارث ببرد. فراخوانی [getEffective](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portionformat/#getEffective) بر روی فرمت بخش، ارتفاع نهایی حل‌شده را برمی‌گرداند.

از دو نوع داده قالب‌بندی برای مقاصد متفاوت استفاده کنید:

- برای خواندن یا تغییر یک شیء قالب محلی، مانند [PortionFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portionformat/)، زمانی که نیاز به کنترل مکان تعریف مقدار دارید.
- برای خواندن [داده مؤثر بازگشتی توسط PortionFormat.getEffective](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portionformat/#getEffective) زمانی که به نتیجه نهایی رندر شده نیاز دارید. داده مؤثر فقط‑خواندنی است.

قبل از اجرای مثال‌ها، [install Aspose.Slides for Node.js via Java](/slides/fa/nodejs-java/installation/).

## **مقایسه مقادیر محلی، ارث‌بری و مؤثر**

مثال کامل زیر یک شکل ایجاد می‌کند و ارتفاع قلم را در سطوح ارائه، پاراگراف و بخش اعمال می‌کند. هر مرحله مقادیر تعریف‌شده در آن سطوح و مقدار مؤثر حاصل برای همان بخش متن را چاپ می‌کند. همچنین نشان می‌دهد چرا پس از تغییرات قالب‌بندی باید داده مؤثر دوباره خوانده شود.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatLocalValue(value) {
    return Number.isNaN(value) ? "<not set>" : value.toString();
}

function printFontHeights(caption, presentation, paragraph, portion) {
    const presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
    const paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
    const localValue = portion.getPortionFormat().getFontHeight();

    // خواندن داده مؤثر پس از تغییرات قبلی.
    const effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

    console.log(caption);
    console.log("  Presentation default: " + formatLocalValue(presentationValue));
    console.log("  Paragraph default:    " + formatLocalValue(paragraphValue));
    console.log("  Portion local:        " + formatLocalValue(localValue));
    console.log("  Portion effective:    " + effectiveValue);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 500, 80, false);
    const textFrame = shape.addTextFrame("Effective formatting");
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    // تعریف مقادیر ارث‌بری در دو سطح مختلف.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

    // مقدار محلی در بخش هر دو مقدار ارث‌بری را نادیده می‌گیرد.
    portion.getPortionFormat().setFontHeight(36);
    printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

    // تغییر مقدار ارث‌بری، مقدار محلی موجود را تحت تأثیر قرار نمی‌دهد.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
    printFontHeights("The local value still has priority", presentation, paragraph, portion);

    // پاک کردن مقدار محلی. بخش اکنون دوباره از پاراگراف ارث می‌برد.
    portion.getPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The local value is cleared", presentation, paragraph, portion);

    // پاک کردن مقدار پاراگراف. پیش‌فرض ارائه اکنون نتیجه را تأمین می‌کند.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

    presentation.save("effective-properties.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

اولویت در این مثال، قالب‌بندی محلی بخش، سپس قالب‌بندی پاراگراف و در نهایت پیش‌فرض ارائه است. اشیاء دیگر می‌توانند زنجیره‌های ارث‌بری متفاوتی داشته باشند، اما اصل همان است: مقدار صریح خاص‌تر پیروز می‌شود و [getEffective](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portionformat/#getEffective) نتیجه نهایی را برمی‌گرداند.

## **دریافت ویژگی‌های متن مؤثر**

قالب‌بندی متن در چندین شیء تقسیم می‌شود:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/#getEffective) ویژگی‌های فریم‑متن مانند حاشیه‌ها، تکیه‌گاه، خود‑تنظیمی و جهت عمودی متن را حل می‌کند.
- [TextStyle.getEffective](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textstyle/#getEffective) قالب‌بندی پاراگراف برای هر سطح سبک متن را حل می‌کند.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#getEffective) ویژگی‌های پاراگراف مانند تراز، تو رفتگی و بولت‌ها را حل می‌کند.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portionformat/#getEffective) ویژگی‌های کاراکتر مانند ارتفاع قلم، نوع قلم، رنگ، بولد و ایتالیک را حل می‌کند.

برای مثال بعدی، فایل `text-formatting.pptx` باید حداقل یک اسلاید و یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) با فریم متنی غیرخالی داشته باشد. AutoShape می‌تواند در هر موقعیتی از مجموعهٔ اشکال ظاهر شود؛ کد یک شیء مناسب را جستجو کرده و پیش از استفاده آن را اعتبارسنجی می‌کند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function hasNonEmptyText(shape) {
    if (shape.getTextFrame() == null) {
        return false;
    }
    if (shape.getTextFrame().getParagraphs().getCount() === 0) {
        return false;
    }
    return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
}

function findAutoShapeWithText(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const candidate = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(candidate, "com.aspose.slides.AutoShape") && hasNonEmptyText(candidate)) {
            return candidate;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("text-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
    if (shape == null) {
        throw new Error("The first slide must contain an AutoShape with non-empty text.");
    }

    const textFrame = shape.getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    const textFrameEffective = textFrame.getTextFrameFormat().getEffective();
    const paragraphEffective = paragraph.getParagraphFormat().getEffective();
    const portionEffective = portion.getPortionFormat().getEffective();

    console.log("Text frame margins:");
    console.log("  Left: " + textFrameEffective.getMarginLeft());
    console.log("  Top: " + textFrameEffective.getMarginTop());
    console.log("  Right: " + textFrameEffective.getMarginRight());
    console.log("  Bottom: " + textFrameEffective.getMarginBottom());
    console.log("Paragraph alignment: " + paragraphEffective.getAlignment());
    console.log("Font height: " + portionEffective.getFontHeight());
    console.log("Bold: " + portionEffective.getFontBold());

    const effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
    for (let level = 0; level < 9; level++) {
        const levelEffective = effectiveTextStyle.getLevel(level);
        console.log("Level " + level + " indent: " + levelEffective.getIndent());
    }
} finally {
    presentation.dispose();
}
```

## **دریافت ویژگی‌های سه‌بعدی مؤثر**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#getEffective) یک شیء داده مؤثر بازمی‌گرداند که تمام تنظیمات سه‑بعدی حل‌شده را گروه‌بندی می‌کند. متدهای [getCamera](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#getCamera)، [getLightRig](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#getLightRig)، [getBevelTop](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#getBevelTop) و [getBevelBottom](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/threedformat/#getBevelBottom) داده مؤثر مربوطه را نمایش می‌دهند. خواندن این تنظیمات مرتبط به‌صورت همزمان، درک ظاهر نهایی سه‑بعدی یک شکل را آسان‌تر می‌کند.

برای این مثال، فایل `shape-3d.pptx` باید حداقل یک شکل در اولین اسلاید داشته باشد. اگر می‌خواهید خروجی شامل مقادیر دیگری به‌جز پیش‌فرض‌ها باشد، دوربین سه‑بعدی، نورپردازی یا تنظیمات برج را برای آن شکل اعمال کنید.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("shape-3d.pptx");
try {
    if (presentation.getSlides().size() === 0 || presentation.getSlides().get_Item(0).getShapes().size() === 0) {
        throw new Error("The first slide must contain a shape.");
    }

    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const threeDEffective = shape.getThreeDFormat().getEffective();

    console.log("Camera:");
    console.log("  Type: " + threeDEffective.getCamera().getCameraType());
    console.log("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
    console.log("  Zoom: " + threeDEffective.getCamera().getZoom());

    console.log("Light rig:");
    console.log("  Type: " + threeDEffective.getLightRig().getLightType());
    console.log("  Direction: " + threeDEffective.getLightRig().getDirection());

    console.log("Top bevel:");
    console.log("  Type: " + threeDEffective.getBevelTop().getBevelType());
    console.log("  Width: " + threeDEffective.getBevelTop().getWidth());
    console.log("  Height: " + threeDEffective.getBevelTop().getHeight());
} finally {
    presentation.dispose();
}
```

## **دریافت قالب‌بندی جدول مؤثر**

قالب‌بندی جدول می‌تواند از سبک جدول و یا از قالب‌های اعمال‌شده به کل جدول، یک ستون، یک ردیف یا یک سلول فردی سرچشمه بگیرد. در برخورد میان پرکن‌های صریح، اولویت به ترتیب سلول، ردیف، ستون و سپس کل جدول است. قالب مؤثر یک سلول، قالب نهایی استفاده‌شده برای رسم آن سلول است.

برای این مثال، فایل `table-formatting.pptx` باید حداقل یک جدول در اولین اسلاید داشته باشد. جدول باید حداقل یک ردیف و یک ستون داشته باشد. کد به‌جای فرض اینکه `getShapes().get_Item(0)` یک جدول است، به دنبال یک [Table](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/table/) می‌گردد.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function findTable(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.Table")) {
            return shape;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("table-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const table = findTable(presentation.getSlides().get_Item(0));
    if (table == null) {
        throw new Error("The first slide must contain a table.");
    }
    if (table.getRows().size() === 0 || table.getColumns().size() === 0) {
        throw new Error("The table must contain at least one cell.");
    }

    const tableEffective = table.getTableFormat().getEffective();
    const rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    const columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    const cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    console.log("Table fill: " + tableEffective.getFillFormat().getFillType());
    console.log("Row fill: " + rowEffective.getFillFormat().getFillType());
    console.log("Column fill: " + columnEffective.getFillFormat().getFillType());
    console.log("Final cell fill: " + cellEffective.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

اگر به رنگ نیاز داشته باشید نه فقط نوع پرکن، ابتدا نوع پرکن مؤثر را با [getFillType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fillformat/#getFillType) بررسی کنید و سپس متد مربوط به آن نوع را بخوانید — به‌عنوان مثال، [getSolidFillColor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fillformat/#getSolidFillColor) برای پرکن جامد.

## **دوباره‌خوانی داده مؤثر پس از تغییرات**

داده مؤثر توصیف‌کنندهٔ سلسله مراتب قالب‌بندی در لحظهٔ حل آن است. پس از تغییر هر چیزی که می‌تواند در این سلسله مراتب شرکت کند، دوباره `getEffective` را فراخوانی کنید، از جمله:

- قالب‌بندی محلی شیء;
- پیش‌فرض‌های پاراگراف یا فریم‑متن;
- یک سبک جدول، جدول، ستون، ردیف یا قالب سلول;
- قالب‌بندی طرح یا اسلاید اصلی;
- داده‌های تم یا پیش‌فرض‌های سطح ارائه;
- طرح یا اسلاید اصلی اختصاص داده‌شده به یک اسلاید.

شیء داده مؤثر را به‌عنوان یک snapshot دائمی نگه ندارید. Aspose.Slides ممکن است برخی داده‌های مؤثر را به‌صورت داخلی کش کند و یک فراخوانی بعدی `getEffective` می‌تواند آن داده‌ها را به‌روز کند. اگر نیاز به مقایسه مقادیر قبل و بعد از یک تغییر دارید، مقادیر اسکالر مورد نیاز (مانند ارتفاع قلم، رنگ، تراز یا عرض برج) را پیش از اعمال تغییر در متغیرهای خود کپی کنید.

برای تغییر یک مقدار، شیء قالب محلی مناسب را به‌روزرسانی کنید و سپس `getEffective` را فراخوانی کنید تا نتیجه را تأیید کنید. اشیاء دادهٔ مؤثر به‌خودی فقط‑خواندنی‌اند.

## **FAQ**

**چگونه می‌توانم تشخیص دهم کدام سطح مقدار مؤثر را فراهم کرده است؟**

داده مؤثر فقط مقدار نهایی را شامل می‌شود، نه منبع آن. از اشیاء محلی قابل اعمال از سطح خاص‌ترین به سمت بیرون بررسی کنید. برای متن، این می‌تواند شامل بخش، پاراگراف، فریم‑متن، طرح، اسلاید اصلی، تم و پیش‌فرض‌های ارائه باشد. مقادیر تعریف‌نشده مانند `NaN` یا `null` نشان می‌دهد که جستجو به سطح دیگری ادامه می‌یابد.

**چه اتفاقی می‌افتد وقتی هیچ سطحی خاصیتی را تعریف نکند؟**

Aspose.Slides مقدار پیش‌فرض مناسب PowerPoint یا کتابخانه را حل می‌کند. آن مقدار حل‌شده در دادهٔ مؤثر ظاهر می‌شود حتی اگر هیچ شیء محلی صریحاً آن را تعریف نکرده باشد.

**چرا گاهی مقدار مؤثر برابر مقدار محلی می‌شود؟**

مقدار محلی محاسبهٔ ارث‌بری را برنده شده است. این حالت زمانی پیش می‌آید که ویژگی به‌وضوح بر روی شیء تنظیم شده باشد و هیچ قاعدهٔ خاص‌تری آن را بازنویسی نکرده باشد.

**چه زمانی باید از دادهٔ محلی به‌جای دادهٔ مؤثر استفاده کنم؟**

از دادهٔ محلی برای بررسی یا ویرایش یک سطح خاص قالب‌بندی استفاده کنید. از دادهٔ مؤثر زمانی استفاده کنید که به ظاهر نهایی پس از ارث‌بری، قوانین تم و سبک‌های کاربردی نیاز دارید. مثال کامل مقایسهٔ [مقایسه مقادیر محلی، ارث‌بری و مؤثر](#compare-local-inherited-and-effective-values) هر دو را در یک گردش کار نشان می‌دهد.