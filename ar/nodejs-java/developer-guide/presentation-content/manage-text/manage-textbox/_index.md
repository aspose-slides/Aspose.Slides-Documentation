---
title: إدارة مربعات النص في العروض التقديمية باستخدام JavaScript
linktitle: إدارة مربع النص
type: docs
weight: 20
url: /ar/nodejs-java/manage-textbox/
keywords:
- مربع نص
- إطار نص
- إضافة نص
- تحديث نص
- إنشاء مربع نص
- التحقق من مربع النص
- إضافة عمود نص
- إضافة ارتباط تشعبي
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تسهّل Aspose.Slides for Node.js إنشاء وتحرير واستنساخ مربعات النص في ملفات PowerPoint وOpenDocument، مما يعزز أتمتة العروض التقديمية الخاصة بك."
---
## **المقدمة**

عادةً ما تكون النصوص على الشرائح موجودة في مربعات النص أو الأشكال. لذلك، لإضافة نص إلى شريحة، عليك إضافة مربع نص ثم وضع بعض النص داخل مربع النص. توفر Aspose.Slides for Node.js via Java فئة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/AutoShape) التي تتيح لك إضافة شكل يحتوي على نص.

{{% alert title="Info" color="info" %}}
توفر Aspose.Slides أيضًا فئة [Shape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Shape) التي تتيح لك إضافة أشكال إلى الشرائح. ومع ذلك، لا يمكن لجميع الأشكال المضافة عبر فئة `Shape` احتواء نص. ولكن الأشكال المضافة عبر فئة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/AutoShape) قد تحتوي على نص.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
لذلك، عند التعامل مع شكل تريد إضافة نص إليه، قد ترغب في التحقق والتأكد أنه تم تحويله عبر فئة `AutoShape`. فقط عندئذٍ ستكون قادرًا على العمل مع [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/TextFrame)، وهو خاصية تحت `AutoShape`. راجع قسم [تحديث النص](https://docs.aspose.com/slides/ar/nodejs-java/manage-textbox/#update-text) في هذه الصفحة.
{{% /alert %}}

## **إنشاء مربع نص على الشريحة**

لإنشاء مربع نص على شريحة، اتبع الخطوات التالية:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation).
2. الحصول على مرجع للشفرة الأولى في العرض التقديمي الذي تم إنشاؤه حديثًا.
3. إضافة كائن من نوع [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/AutoShape) مع [ShapeType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/GeometryShape#setShapeType-int-) محددًا كـ `Rectangle` في موضع محدد على الشريحة واحصل على مرجع لكائن `AutoShape` المضاف حديثًا.
4. إضافة خاصية `TextFrame` إلى كائن `AutoShape` الذي سيحتوي على نص. في المثال أدناه، أضفنا هذا النص: *Aspose TextBox*
5. أخيرًا، احفظ ملف PPTX عبر كائن `Presentation`.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// إنشاء عرض تقديمي
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى في العرض التقديمي
    var sld = pres.getSlides().get_Item(0);
    // إضافة AutoShape مع تعيين النوع كـ Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // إضافة TextFrame إلى المستطيل
    ashp.addTextFrame(" ");
    // الوصول إلى إطار النص
    var txtFrame = ashp.getTextFrame();
    // إنشاء كائن Paragraph لإطار النص
    var para = txtFrame.getParagraphs().get_Item(0);
    // إنشاء كائن Portion للفقرة
    var portion = para.getPortions().get_Item(0);
    // تعيين النص
    portion.setText("Aspose TextBox");
    // حفظ العرض التقديمي إلى القرص
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **التحقق من شكل مربع النص**

يوفر Aspose.Slides الطريقة [isTextBox](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/#isTextBox) من فئة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) ، مما يتيح لك فحص الأشكال وتحديد مربعات النص.

![Text box and shape](istextbox.png)

هذا الكود JavaScript يوضح لك كيفية التحقق مما إذا تم إنشاء الشكل كمربع نص:

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

لاحظ أنه إذا قمت ببساطة بإضافة شكل تلقائي باستخدام الطريقة `addAutoShape` من فئة [ShapeCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapecollection/)، فإن طريقة `isTextBox` لهذا الشكل ستعيد `false`. ومع ذلك، بعد إضافة نص إلى الشكل باستخدام الطريقة `addTextFrame` أو الطريقة `setText`، ستعيد الخاصية `isTextBox` القيمة `true`.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() يرجع false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() يرجع true

var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() يرجع false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() يرجع true

var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() يرجع false
shape3.addTextFrame("");
// shape3.isTextBox() يرجع false

var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() يرجع false
shape4.getTextFrame().setText("");
// shape4.isTextBox() يرجع false
```

## **العثور على الشكل الذي يمتلك TextFrame**

في كود معالجة النصوص العام، قد تتلقى كائنًا من نوع [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) دون معرفة أي كائن عرض تقديمي يحتويه مسبقًا. استخدم الطريقة [TextFrame.getParentShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#getParentShape--) للعودة إلى الشكل المالك [Shape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/).

بالنسبة لإطار نص ينتمي إلى [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) أو شكل آخر يحتوي على نص، تُعيد الطريقة [TextFrame.getParentShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#getParentShape--) المالك وتُعيد الطريقة [TextFrame.getParentCell](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#getParentCell--) القيمة `null`. كلا الطريقتين توفران تنقلًا للقراءة فقط، لذا فإن استدعائهما لا يغيّر الملكية. تحقق دائمًا من أن القيمة المرتجعة ليست `null` قبل الوصول إلى الشكل.

للحصول على مثال كامل يحدد أصحاب الأشكال وخلايا الجدول، بما في ذلك الأشكال المرتبطة بعقد SmartArt، انظر [البحث واستبدال النص](/slides/ar/nodejs-java/search-and-replace-text/).

## **إضافة عمود في مربع النص**

توفر Aspose.Slides الفئات [setColumnCount](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) و [setColumnSpacing](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) من فئة [TextFrameFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/TextFrameFormat) التي تتيح لك إضافة أعمدة إلى مربعات النص. يمكنك تحديد عدد الأعمدة في مربع النص وتعيين المسافة بين الأعمدة بالنقاط.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى في العرض التقديمي
    var slide = pres.getSlides().get_Item(0);
    // إضافة AutoShape مع تعيين النوع كـ Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // إضافة TextFrame إلى المستطيل
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!");
    // الحصول على تنسيق TextFrame
    var format = aShape.getTextFrame().getTextFrameFormat();
    // تحديد عدد الأعمدة في TextFrame
    format.setColumnCount(3);
    // تحديد المسافة بين الأعمدة
    format.setColumnSpacing(10);
    // حفظ العرض التقديمي
    pres.save("ColumnCount.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **إضافة عمود في TextFrame**

توفر Aspose.Slides for Node.js via Java الطريقة [setColumnCount](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) من فئة [TextFrameFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/TextFrameFormat) التي تسمح لك بإضافة أعمدة في إطارات النص. من خلال هذه الخاصية، يمكنك تحديد عدد الأعمدة المفضل لديك في إطار النص.

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
        // لم يتم تحديد مسافة العمود أبدًا، لذلك يتم الإبلاغ عنها كقيمة NaN.
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

## **تحديث النص**

تمكنك Aspose.Slides من تغيير أو تحديث النص الموجود في مربع نص أو جميع النصوص الموجودة في عرض تقديمي.

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
            // يتحقق مما إذا كان الشكل يدعم إطار النص (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // يتنقل عبر الفقرات في إطار النص
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // يتنقل عبر كل جزء في الفقرة
                    for (let k = 0; k < paragraph.getPortions().getCount(); k++) {
                        let portion = paragraph.getPortions().get_Item(k);
                        portion.setText(portion.getText().replace("years", "months"));// يغيّر النص
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// يغيّر التنسيق
                    }
                }
            }
        }
    }
    // يحفظ العرض التقديمي المعدل
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **إضافة مربع نص مع ارتباط تشعبي** 

يمكنك إدراج رابط داخل مربع نص. عند النقر على مربع النص، يُوجه المستخدمون لفتح الرابط.

لإضافة مربع نص يحتوي على رابط، اتبع الخطوات التالية:

1. إنشاء نسخة من فئة `Presentation`.
2. الحصول على مرجع للشفرة الأولى في العرض التقديمي الذي تم إنشاؤه حديثًا.
3. إضافة كائن `AutoShape` مع `ShapeType` محددًا كـ `Rectangle` في موضع محدد على الشريحة واحصل على مرجع لكائن AutoShape المضاف حديثًا.
4. إضافة `TextFrame` إلى كائن `AutoShape` وتعيين نص الجزئية الأولى. في المثال أدناه، استخدمنا هذا النص: *Aspose.Slides*
5. الحصول على `HyperlinkManager` لتلك الجزئية عبر `PortionFormat` الخاصة بها.
6. استدعاء `setExternalHyperlinkClick` على `HyperlinkManager` لإرفاق الرابط بالجزئية.
7. أخيرًا، احفظ ملف PPTX عبر كائن `Presentation`.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى في العرض التقديمي
    var slide = pres.getSlides().get_Item(0);
    // إضافة كائن AutoShape مع تعيين النوع كـ Rectangle
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // تحويل الشكل إلى AutoShape
    var pptxAutoShape = shape;
    // الوصول إلى خاصية ITextFrame المرتبطة بـ AutoShape
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // إضافة بعض النص إلى الإطار
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // تعيين الارتباط التشعبي لنص الجزء
    var hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");
    // حفظ العرض التقديمي بصيغة PPTX
    pres.save("hLink_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **الأسئلة الشائعة**

**ما الفرق بين مربع النص وعلامة النص النائبة عند العمل مع الشرائح الرئيسة؟**

[placeholder](/slides/ar/nodejs-java/manage-placeholder/) يرث النمط/الموقع من [master](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslide/) ويمكن تجاوزه في [layouts](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutslide/)، بينما مربع النص العادي هو كائن مستقل على شريحة محددة ولا يتغير عندما تقوم بتبديل التخطيطات.

**كيف يمكنني إجراء استبدال نصي جماعي عبر العرض التقديمي دون التأثير على النص داخل المخططات والجداول وSmartArt؟**

قصر التكرار على الأشكال التلقائية التي تحتوي على إطارات نص واستبعاد الكائنات المضمنة ([charts](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chart/)، [tables](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/table/)، [SmartArt](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/smartart/)) عن طريق استعراض مجموعاتها بشكل منفصل أو تخطي تلك الأنواع من الكائنات.