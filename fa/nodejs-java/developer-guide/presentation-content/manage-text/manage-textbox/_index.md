---
title: مدیریت جعبه‌های متن در ارائه‌ها با استفاده از JavaScript
linktitle: مدیریت جعبه متن
type: docs
weight: 20
url: /fa/nodejs-java/manage-textbox/
keywords:
- جعبه متن
- قاب متن
- افزودن متن
- به‌روزرسانی متن
- ایجاد جعبه متن
- بررسی جعبه متن
- افزودن ستون متن
- افزودن پیوند
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides برای Node.js ایجاد، ویرایش و کلون کردن جعبه‌های متن در فایل‌های PowerPoint و OpenDocument را ساده می‌کند و خودکارسازی ارائه‌های شما را ارتقاء می‌دهد."
---
## **مقدمه**

متن‌ها در اسلایدها معمولاً در جعبه‌های متن یا شکل‌ها وجود دارند. بنابراین، برای افزودن متن به یک اسلاید، باید یک جعبه متن اضافه کنید و سپس متنی داخل آن قرار دهید. Aspose.Slides برای Node.js از طریق Java کلاس [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/AutoShape) را ارائه می‌دهد که به شما امکان اضافه کردن شکلی حاوی متن را می‌دهد.

{{% alert title="Info" color="info" %}}
Aspose.Slides همچنین کلاس [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Shape) را ارائه می‌دهد که به شما امکان افزودن شکل‌ها به اسلایدها را می‌دهد. با این حال، همه شکل‌های اضافه شده از طریق کلاس `Shape` نمی‌توانند متن داشته باشند. اما شکل‌هایی که از طریق کلاس [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/AutoShape) اضافه می‌شوند می‌توانند حاوی متن باشند.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
بنابراین، هنگام کار با شکلی که می‌خواهید متن به آن اضافه کنید، ممکن است بخواهید بررسی و تأیید کنید که آن از طریق کلاس `AutoShape` تبدیل شده است. تنها در این صورت می‌توانید با [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/TextFrame) کار کنید که یک ویژگی تحت `AutoShape` است. بخش [Update Text](https://docs.aspose.com/slides/fa/nodejs-java/manage-textbox/#update-text) در این صفحه را ببینید.
{{% /alert %}}

## **ایجاد جعبه متن روی اسلاید**

برای ایجاد جعبه متن روی اسلاید، این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. یک ارجاع به اولین اسلاید در ارائه تازه ایجاد شده به دست آورید. 
3. یک شیء [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/AutoShape) با [ShapeType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/GeometryShape#setShapeType-int-) تنظیم‌شده به `Rectangle` در موقعیت مشخصی روی اسلاید اضافه کنید و ارجاع به شیء `AutoShape` تازه اضافه‌شده را به دست آورید.
4. یک ویژگی `TextFrame` به شیء `AutoShape` اضافه کنید که متنی را در بر خواهد داشت. در مثال زیر، این متن را اضافه کرده‌ایم: *Aspose TextBox*
5. در نهایت، فایل PPTX را از طریق شیء `Presentation` بنویسید. 

این کد JavaScript—پیاده‌سازی مراحل فوق—نحوه افزودن متن به اسلاید را نشان می‌دهد:

```javascript
// یک نمونه از Presentation ایجاد می‌کند
var pres = new aspose.slides.Presentation();
try {
    // اولین اسلاید در ارائه را دریافت می‌کند
    var sld = pres.getSlides().get_Item(0);
    // یک AutoShape با نوع Rectangle اضافه می‌کند
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // TextFrame را به Rectangle اضافه می‌کند
    ashp.addTextFrame(" ");
    // به فریم متن دسترسی پیدا می‌کند
    var txtFrame = ashp.getTextFrame();
    // شیء Paragraph را برای فریم متن ایجاد می‌کند
    var para = txtFrame.getParagraphs().get_Item(0);
    // شیء Portion را برای پاراگراف ایجاد می‌کند
    var portion = para.getPortions().get_Item(0);
    // متن را تنظیم می‌کند
    portion.setText("Aspose TextBox");
    // ارائه را روی دیسک ذخیره می‌کند
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **بررسی شکل جعبه متن**

Aspose.Slides روش [isTextBox](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/#isTextBox) را از کلاس [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) ارائه می‌دهد که به شما امکان بررسی شکل‌ها و شناسایی جعبه‌های متن را می‌دهد.

![Text box and shape](istextbox.png)

این کد JavaScript نشان می‌دهد چگونه بررسی کنید آیا یک شکل به صورت جعبه متن ایجاد شده است یا نه:

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    java.callStaticMethodSync("ForEach", "shape", presentation, (shape, slide, index) -> {
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var autoShape = shape;
            console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

توجه داشته باشید که اگر به سادگی یک autoshape را با استفاده از متد `addAutoShape` از کلاس [ShapeCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapecollection/) اضافه کنید، متد `isTextBox` آن autoshape مقدار `false` را باز خواهد گرداند. اما پس از افزودن متن به autoshape با استفاده از متد `addTextFrame` یا متد `setText`، ویژگی `isTextBox` مقدار `true` را برمی‌گرداند.

```javascript
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

## **اضافه کردن ستون در جعبه متن**

Aspose.Slides متدهای [setColumnCount](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) و [setColumnSpacing](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) را از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/TextFrameFormat) ارائه می‌دهد که به شما امکان افزودن ستون‌ها به جعبه‌های متن را می‌دهد. می‌توانید تعداد ستون‌ها در یک جعبه متن را مشخص کنید و فاصله بین ستون‌ها را بر حسب نقطه تنظیم کنید.

این کد در JavaScript عملیات توصیف‌شده را نشان می‌دهد: 

```javascript
var pres = new aspose.slides.Presentation();
try {
    // اولین اسلاید در ارائه را دریافت می‌کند
    var slide = pres.getSlides().get_Item(0);
    // یک AutoShape با نوع Rectangle اضافه می‌کند
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // TextFrame را به Rectangle اضافه می‌کند
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!"));
    // قالب متن TextFrame را دریافت می‌کند
    var format = aShape.getTextFrame().getTextFrameFormat();
    // تعداد ستون‌ها در TextFrame را مشخص می‌کند
    format.setColumnCount(3);
    // فاصله بین ستون‌ها را مشخص می‌کند
    format.setColumnSpacing(10);
    // ارائه را ذخیره می‌کند
    pres.save("ColumnCount.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **اضافه کردن ستون در فریم متن**

Aspose.Slides برای Node.js از طریق Java متد [setColumnCount](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) را از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/TextFrameFormat) ارائه می‌دهد که به شما امکان افزودن ستون‌ها در فریم‌های متن را می‌دهد. با استفاده از این ویژگی، می‌توانید تعداد ستون‌های مورد نظرتان را در یک فریم متن مشخص کنید.

این کد JavaScript نشان می‌دهد چگونه یک ستون داخل فریم متن اضافه کنید:

```javascript
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
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", java.getStaticFieldValue("java.lang.Double", "NaN") == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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
        java.callStaticMethodSync("Assert", "assertTrue", 3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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

Aspose.Slides به شما امکان تغییر یا به‌روزرسانی متن موجود در یک جعبه متن یا تمام متون موجود در یک ارائه را می‌دهد. 

این کد JavaScript عملی را نشان می‌دهد که در آن تمام متون یک ارائه به‌روزرسانی یا تغییر می‌یابند:

```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // بررسی می‌کند آیا شکل فریم متن (IAutoShape) را پشتیبانی می‌کند.
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // در فریم متن از پاراگراف‌ها عبور می‌کند
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // در پاراگراف از هر بخش عبور می‌کند
                    for (let k = 0; k < paragraph.getPortions().getCount(); k++) {
                        let portion = paragraph.getPortions().get_Item(k);
                        portion.setText(portion.getText().replace("years", "months"));// متن را تغییر می‌دهد
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// قالب‌بندی را تغییر می‌دهد
                    }
                }
            }
        }
    }
    // ارائهٔ اصلاح‌شده را ذخیره می‌کند
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **اضافه کردن جعبه متن با پیوند** 

می‌توانید یک لینک داخل جعبه متن وارد کنید. هنگامی که جعبه متن کلیک شود، کاربران به باز کردن لینک هدایت می‌شوند. 

برای افزودن جعبه متن حاوی لینک، این مراحل را دنبال کنید:

1. یک نمونه از کلاس `Presentation` ایجاد کنید. 
2. یک ارجاع به اولین اسلاید در ارائه تازه ایجاد شده به دست آورید. 
3. یک شیء `AutoShape` با `ShapeType` تنظیم‌شده به `Rectangle` در موقعیت مشخصی روی اسلاید اضافه کنید و ارجاع به شیء AutoShape تازه اضافه‌شده را به دست آورید.
4. یک `TextFrame` به شیء `AutoShape` اضافه کنید که متن پیش‌فرض *Aspose TextBox* را داشته باشد. 
5. کلاس `HyperlinkManager` را نمونه‌سازی کنید. 
6. شیء `HyperlinkManager` را به ویژگی [HyperlinkClick](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Shape#getHyperlinkClick--) که به بخشی مورد نظر شما در `TextFrame` مرتبط است، اختصاص دهید.
7. در نهایت، فایل PPTX را از طریق شیء `Presentation` بنویسید. 

این کد JavaScript—پیاده‌سازی مراحل فوق—نحوه افزودن جعبه متن با پیوند به اسلاید را نشان می‌دهد:

```javascript
// یک نمونه از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
var pres = new aspose.slides.Presentation();
try {
    // اولین اسلاید در ارائه را دریافت می‌کند
    var slide = pres.getSlides().get_Item(0);
    // یک شیء AutoShape با نوع Rectangle اضافه می‌کند
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // شکل را به AutoShape تبدیل می‌کند
    var pptxAutoShape = shape;
    // به ویژگی ITextFrame مرتبط با AutoShape دسترسی پیدا می‌کند
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // متنی به فریم اضافه می‌کند
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // پیوند (Hyperlink) متن بخش را تنظیم می‌کند
    var hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");
    // ارائه PPTX را ذخیره می‌کند
    pres.save("hLink_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **پرسش‌های متداول**

**فرق بین جعبه متن و نگهدارنده متن هنگام کار با اسلایدهای اصلی چیست؟**

یک [placeholder](/slides/fa/nodejs-java/manage-placeholder/) سبک/موقعیت را از [master](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterslide/) ارث‌بری می‌کند و می‌تواند در [layouts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutslide/) بازنویسی شود، در حالی که یک جعبه متن عادی یک شیء مستقل بر روی اسلاید خاص است و هنگام جابجایی طرح‌بندی‌ها تغییر نمی‌کند.

**چگونه می‌توانم یک جایگزینی متنی کلی روی ارائه انجام دهم بدون اینکه به متن داخل نمودارها، جداول و SmartArt دست بزنم؟**

تکرار خود را فقط به auto-shapeهایی که دارای فریم متن هستند محدود کنید و اشیای جاسازی‌شده ([charts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chart/)، [tables](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/table/)، [SmartArt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/smartart/)) را با پیمایش جداگانهٔ مجموعه‌هایشان یا صرف‌نظر کردن از آن نوع اشیاء، حذف کنید.