---
title: مدیریت جعبه‌های متن در ارائه‌ها با استفاده از JavaScript
linktitle: مدیریت جعبه متن
type: docs
weight: 20
url: /fa/nodejs-java/manage-textbox/
keywords:
- جعبه متن
- چارچوب متن
- افزودن متن
- به‌روزرسانی متن
- ایجاد جعبه متن
- بررسی جعبه متن
- افزودن ستون متن
- افزودن پیوند
- پاورپوینت
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides برای Node.js ایجاد، ویرایش و تکثیر جعبه‌های متن در فایل‌های PowerPoint و OpenDocument را آسان می‌سازد و خودکارسازی ارائه‌های شما را بهبود می‌بخشد."
---
## **مقدمه**

متن‌ها در اسلایدها معمولاً در جعبه‌های متن یا شکل‌ها وجود دارند. بنابراین، برای افزودن متن به یک اسلاید، باید یک جعبه متن اضافه کنید و سپس متنی داخل آن قرار دهید. Aspose.Slides برای Node.js از طریق Java کلاس [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/AutoShape) را فراهم می‌کند که به شما امکان افزودن شکلی حاوی متن را می‌دهد.

{{% alert title="Info" color="info" %}}

Aspose.Slides همچنین کلاس [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Shape) را فراهم می‌کند که به شما امکان افزودن شکل‌ها به اسلایدها را می‌دهد. اما همهٔ شکل‌های اضافه‌شده از طریق کلاس `Shape` می‌توانند متن را نگه دارند. اما شکل‌هایی که از طریق کلاس [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/AutoShape) اضافه می‌شوند می‌توانند متن داشته باشند.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

بنابراین، وقتی با شکلی که می‌خواهید متن به آن اضافه کنید سروکار دارید، ممکن است بخواهید بررسی و تأیید کنید که آن از طریق کلاس `AutoShape` تبدیل شده است. تنها در این صورت می‌توانید با [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/TextFrame) که یک ویژگی تحت `AutoShape` است کار کنید. بخش [Update Text](https://docs.aspose.com/slides/fa/nodejs-java/manage-textbox/#update-text) را در این صفحه ببینید.

{{% /alert %}}

## **ایجاد جعبه متن در اسلاید**

برای ایجاد یک جعبه متن در اسلاید، این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.  
2. مرجع اولین اسلاید در ارائهٔ تازه‌ساخته‌شده را دریافت کنید.  
3. یک شیء [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/AutoShape) با [ShapeType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/GeometryShape#setShapeType-int-) تنظیم‌شده به `Rectangle` در موقعیت مشخصی روی اسلاید اضافه کنید و مرجع شیء `AutoShape` جدید را به دست آورید.  
4. یک ویژگی `TextFrame` به شیء `AutoShape` اضافه کنید که متنی درون آن قرار می‌گیرد. در مثال زیر این متن را اضافه کردیم: *Aspose TextBox*  
5. در نهایت، فایل PPTX را از طریق شیء `Presentation` بنویسید.  

این کد JavaScript—اجرای مراحل فوق—نحوه افزودن متن به یک اسلاید را نشان می‌دهد:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// نمونه‌سازی Presentation
// دریافت اولین اسلاید در ارائه
// افزودن AutoShape با نوع تنظیم‌شده به Rectangle
// افزودن TextFrame به Rectangle
// دسترسی به فریم متن
// ایجاد شیء Paragraph برای فریم متن
// ایجاد شیء Portion برای پاراگراف
// تنظیم متن
// ذخیره ارائه در دیسک
var pres = new aspose.slides.Presentation();
try {
    // Gets the first slide in the presentation
    var sld = pres.getSlides().get_Item(0);
    // Adds an AutoShape with type set as Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Adds TextFrame to the Rectangle
    ashp.addTextFrame(" ");
    // Accesses the text frame
    var txtFrame = ashp.getTextFrame();
    // Creates the Paragraph object for text frame
    var para = txtFrame.getParagraphs().get_Item(0);
    // Creates a Portion object for paragraph
    var portion = para.getPortions().get_Item(0);
    // Sets Text
    portion.setText("Aspose TextBox");
    // Saves the presentation to disk
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **بررسی شکل جعبه متن**

Aspose.Slides متد [isTextBox](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/#isTextBox) را از کلاس [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) فراهم می‌کند که به شما امکان بررسی شکل‌ها و شناسایی جعبه‌های متن را می‌دهد.

![Text box and shape](istextbox.png)

این کد JavaScript نشان می‌دهد چگونه بررسی کنید آیا یک شکل به‌عنوان جعبه متن ایجاد شده است یا نه:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (var slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        var slide = presentation.getSlides().get_Item(slideIndex);
        for (var shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            var shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

توجه داشته باشید که اگر فقط یک AutoShape را با متد `addAutoShape` از کلاس [ShapeCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapecollection/) اضافه کنید، متد `isTextBox` برای آن AutoShape مقدار `false` را برمی‌گرداند. اما پس از افزودن متن به AutoShape با استفاده از متد `addTextFrame` یا `setText`، ویژگی `isTextBox` مقدار `true` می‌دهد.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() مقدار false را برمی‌گرداند
shape1.addTextFrame("shape 1");
// shape1.isTextBox() مقدار true را برمی‌گرداند

var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() مقدار false را برمی‌گرداند
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() مقدار true را برمی‌گرداند

var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() مقدار false را برمی‌گرداند
shape3.addTextFrame("");
// shape3.isTextBox() مقدار false را برمی‌گرداند

var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() مقدار false را برمی‌گرداند
shape4.getTextFrame().setText("");
// shape4.isTextBox() مقدار false را برمی‌گرداند
```

## **یافتن شکلی که مالک TextFrame است**

در کدهای عمومی پردازش متن، ممکن است یک [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) دریافت کنید بدون اینکه بدانید کدام شیء ارائه آن را شامل می‌شود. از متد [TextFrame.getParentShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#getParentShape--) برای بازگشت به [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/) مالک استفاده کنید.

برای یک TextFrame که به یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) یا شکل دیگری حاوی متن تعلق دارد، متد [TextFrame.getParentShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#getParentShape--) مالک را برمی‌گرداند و متد [TextFrame.getParentCell](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#getParentCell--) مقدار `null` برمی‌گرداند. هر دو متد مسیریابی فقط‑خواندنی هستند، بنابراین فراخوانی آن‌ها مالکیت را تغییر نمی‌دهد. همیشه قبل از دسترسی به شکل، مقدار برگشتی را برای `null` بررسی کنید.

برای مثال کامل که مالکین شکل و سلول جدول را شناسایی می‌کند، از جمله شکل‌های مرتبط با گره‌های SmartArt، به [Search and Replace Text](/slides/fa/nodejs-java/search-and-replace-text/) مراجعه کنید.

## **افزودن ستون در جعبه متن**

Aspose.Slides متدهای [setColumnCount](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) و [setColumnSpacing](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) را از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/TextFrameFormat) ارائه می‌دهد که به شما امکان افزودن ستون‌ها به جعبه‌های متن را می‌دهد. می‌توانید تعداد ستون‌ها را در یک جعبه متن مشخص کنید و فاصلهٔ بین ستون‌ها را بر حسب پوینت تنظیم کنید.

این کد JavaScript عملیات توصیف‌شده را نشان می‌دهد:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید در ارائه
    var slide = pres.getSlides().get_Item(0);
    // افزودن AutoShape با نوع تنظیم‌شده به Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // افزودن TextFrame به Rectangle
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!");
    // دریافت قالب متن TextFrame
    var format = aShape.getTextFrame().getTextFrameFormat();
    // تعیین تعداد ستون‌ها در TextFrame
    format.setColumnCount(3);
    // تعیین فاصله بین ستون‌ها
    format.setColumnSpacing(10);
    // ذخیرهٔ ارائه
    pres.save("ColumnCount.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **افزودن ستون در TextFrame**

Aspose.Slides برای Node.js از طریق Java متد [setColumnCount](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) را از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/TextFrameFormat) فراهم می‌کند که به شما امکان افزودن ستون‌ها در TextFrameها را می‌دهد. از طریق این ویژگی می‌توانید تعداد ستون‌های دلخواه خود را در یک TextFrame مشخص کنید.

این کد JavaScript نشان می‌دهد چگونه یک ستون داخل TextFrame اضافه کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const assert = require("assert");

var outPptxFileName = "ColumnsTest.pptx";
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    var format = shape1.getTextFrame().getTextFrameFormat();
    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " + "you can add or delete text - and the new or remaining text automatically adjusts " + "itself to stay within the container. You cannot have text spill over from one container " + "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        // فاصله ستون هرگز تنظیم نشد، بنابراین به صورت NaN گزارش می‌شود.
        assert.ok(Number.isNaN(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing()));
    } finally {
        if (test != null) {
            test.dispose();
        }
    }
    format.setColumnSpacing(20);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test1 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test1.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 20);
    } finally {
        if (test1 != null) {
            test1.dispose();
        }
    }
    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test2 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test2.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 3);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 15);
    } finally {
        if (test2 != null) {
            test2.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **به‌روزرسانی متن**

Aspose.Slides به شما اجازه می‌دهد متن موجود در یک جعبه متن یا تمام متون موجود در یک ارائه را تغییر یا به‌روزرسانی کنید.

این کد JavaScript عملیاتی را نشان می‌دهد که در آن تمام متون یک ارائه به‌روزرسانی یا تغییر می‌یابند:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // بررسی می‌کند که آیا شکل از فریم متن (IAutoShape) پشتیبانی می‌کند.
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // در میان پاراگراف‌های فریم متن پیمایش می‌کند
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // در میان هر بخش از پاراگراف پیمایش می‌کند
                    for (let k = 0; k < paragraph.getPortions().getCount(); k++) {
                        let portion = paragraph.getPortions().get_Item(k);
                        portion.setText(portion.getText().replace("years", "months"));// متن را تغییر می‌دهد
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// قالب‌بندی را تغییر می‌دهد
                    }
                }
            }
        }
    }
    // ارائهٔ تغییر یافته را ذخیره می‌کند
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **افزودن جعبه متن با پیوند** 

می‌توانید یک لینک را داخل جعبه متن درج کنید. وقتی جعبه متن کلیک شود، کاربران به باز کردن لینک هدایت می‌شوند.

برای افزودن جعبه متن حاوی یک لینک، این مراحل را دنبال کنید:

1. یک نمونه از کلاس `Presentation` ایجاد کنید.  
2. مرجع اولین اسلاید در ارائهٔ تازه‌ساخته‌شده را دریافت کنید.  
3. یک شیء `AutoShape` با `ShapeType` تنظیم‌شده به `Rectangle` در موقعیت مشخصی روی اسلاید اضافه کنید و مرجع شیء AutoShape جدید را به دست آورید.  
4. یک `TextFrame` به شیء `AutoShape` اضافه کنید و متن اولین بخش آن را تنظیم کنید. در مثال زیر از این متن استفاده کردیم: *Aspose.Slides*  
5. `HyperlinkManager` آن بخش را از طریق `PortionFormat` آن دریافت کنید.  
6. متد `setExternalHyperlinkClick` را روی `HyperlinkManager` فراخوانی کنید تا لینک به بخش متصل شود.  
7. در نهایت، فایل PPTX را از طریق شیء `Presentation` بنویسید.  

این کد JavaScript—اجرای مراحل فوق—نحوه افزودن جعبه متن با پیوند به اسلاید را نشان می‌دهد:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// یک نمونه از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
var pres = new aspose.slides.Presentation();
try {
    // اولین اسلاید در ارائه را دریافت می‌کند
    var slide = pres.getSlides().get_Item(0);
    // یک شیء AutoShape با نوع تنظیم‌شده به Rectangle اضافه می‌کند
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // تبدیل (کست) شیء shape به AutoShape
    var pptxAutoShape = shape;
    // به ویژگی ITextFrame مرتبط با AutoShape دسترسی پیدا می‌کند
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // متنی به فریم اضافه می‌کند
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // پیوند (Hyperlink) متن بخش را تنظیم می‌کند
    var hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");
    // ارائهٔ PPTX را ذخیره می‌کند
    pres.save("hLink_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سوالات متداول**

**تفاوت جعبه متن و جای‌نگهدار متن در هنگام کار با اسلایدهای مستر چیست؟**

یک [placeholder](/slides/fa/nodejs-java/manage-placeholder/) استایل/موقعیت را از [master](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterslide/) به ارث می‌برد و می‌تواند در [layouts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutslide/) بازنویسی شود، در حالی که یک جعبه متن معمولی یک شیء مستقل بر روی اسلاید مشخص است و هنگام تغییر لایه‌ها تغییر نمی‌کند.

**چگونه می‌توانم جایگزینی متنی انبوه را در سراسر ارائه انجام دهم بدون آنکه به متن داخل نمودارها، جدول‌ها و SmartArt دست بزنم؟**

دورهٔ تکرار خود را به AutoShapeهایی که TextFrame دارند محدود کنید و اشیای جاسازی‌شده ([charts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chart/)، [tables](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/table/)، [SmartArt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/smartart/)) را با پیمایش مجموعه‌های آن‌ها به‌صورت جداگانه یا نادیده‌گیری آن انواع اشیاء حذف کنید.