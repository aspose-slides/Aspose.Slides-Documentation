---
title: إدارة صندوق النص
type: docs
weight: 20
url: /ar/nodejs-java/manage-textbox/
keywords:
- صندوق نص
- إطار نص
- إضافة نص
- تحديث نص
- صندوق نص مع ارتباط تشعبي
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides for Node.js via Java
description: "إدارة صندوق نص أو إطار نص في عروض PowerPoint التقديمية باستخدام JavaScript"
---

عادةً ما تكون النصوص على الشرائح موجودة في مربعات نص أو أشكال. لذلك، لإضافة نص إلى شريحة، عليك إضافة مربع نص ثم وضع بعض النص داخل مربع النص. توفر Aspose.Slides for Node.js via Java الفئة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) التي تسمح لك بإضافة شكل يحتوي على نص.

{{% alert title="Info" color="info" %}}

توفر Aspose.Slides أيضًا الفئة [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) التي تسمح لك بإضافة أشكال إلى الشرائح. ومع ذلك، ليست كل الأشكال المضافة عبر الفئة `Shape` يمكنها احتواء نص. لكن الأشكال المضافة عبر الفئة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) قد تحتوي على نص.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

لذلك، عند التعامل مع شكل تريد إضافة نص إليه، قد ترغب في التحقق والتأكد من أنه تم تحويله عبر الفئة `AutoShape`. فقط عندئذٍ ستكون قادرًا على العمل مع [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame)، وهو خاصية ضمن `AutoShape`. راجع قسم [Update Text](https://docs.aspose.com/slides/nodejs-java/manage-textbox/#update-text) في هذه الصفحة.

{{% /alert %}}

## **إنشاء مربع نص على الشريحة**

لإنشاء مربع نص على شريحة، اتبع هذه الخطوات:

1. أنشئ نسخة من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. احصل على مرجع للشرائح الأولى في العرض التقديمي الذي تم إنشاؤه حديثًا. 
3. أضف كائن [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) مع [ShapeType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape#setShapeType-int-) محدد كـ `Rectangle` في موضع محدد على الشريحة واحصل على مرجع لكائن `AutoShape` المضاف حديثًا.
4. أضف الخاصية `TextFrame` إلى كائن `AutoShape` الذي سيحتوي على نص. في المثال أدناه، أضفنا هذا النص: *Aspose TextBox*
5. أخيرًا، احفظ ملف PPTX عبر كائن `Presentation`. 

يظهر هذا الكود JavaScript—تنفيذ للخطوات أعلاه—كيفية إضافة نص إلى شريحة:
```javascript
// ينشئ كائن Presentation
var pres = new aspose.slides.Presentation();
try {
    // يحصل على الشريحة الأولى في العرض التقديمي
    var sld = pres.getSlides().get_Item(0);
    // يضيف AutoShape مع تعيين النوع كـ Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // يضيف TextFrame إلى المستطيل
    ashp.addTextFrame(" ");
    // الوصول إلى إطار النص
    var txtFrame = ashp.getTextFrame();
    // ينشئ كائن Paragraph لإطار النص
    var para = txtFrame.getParagraphs().get_Item(0);
    // ينشئ كائن Portion للفقرة
    var portion = para.getPortions().get_Item(0);
    // يضبط النص
    portion.setText("Aspose TextBox");
    // يحفظ العرض التقديمي إلى القرص
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **التحقق من شكل مربع النص**

توفر Aspose.Slides الطريقة [isTextBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#isTextBox) من الفئة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) التي تسمح لك بفحص الأشكال وتحديد مربعات النص.

![Text box and shape](istextbox.png)

يظهر هذا الكود JavaScript كيفية التحقق مما إذا كان الشكل قد تم إنشاؤه كمربع نص:
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


لاحظ أنه إذا قمت فقط بإضافة AutoShape باستخدام الطريقة `addAutoShape` من الفئة [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/)، فإن طريقة `isTextBox` للـ AutoShape ستُعيد `false`. ومع ذلك، بعد إضافة نص إلى الـ AutoShape باستخدام الطريقة `addTextFrame` أو الطريقة `setText`، ستُعيد الخاصية `isTextBox` القيمة `true`.
```javascript
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


## **إضافة عمود في مربع النص**

توفر Aspose.Slides الطريقتين [setColumnCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) و [setColumnSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) من الفئة [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) التي تسمح لك بإضافة أعمدة إلى مربعات النص. يمكنك تحديد عدد الأعمدة في مربع النص وتعيين المسافة بين الأعمدة بنقاط.

يظهر هذا الكود JavaScript العملية الموضحة:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // يحصل على الشريحة الأولى في العرض التقديمي
    var slide = pres.getSlides().get_Item(0);
    // إضافة AutoShape مع تعيين النوع كـ Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // إضافة TextFrame إلى المستطيل
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!");
    // يحصل على تنسيق النص لإطار النص
    var format = aShape.getTextFrame().getTextFrameFormat();
    // يحدد عدد الأعمدة في إطار النص
    format.setColumnCount(3);
    // يحدد المسافة بين الأعمدة
    format.setColumnSpacing(10);
    // يحفظ العرض التقديمي
    pres.save("ColumnCount.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إضافة عمود في إطار النص**

توفر Aspose.Slides for Node.js via Java الطريقة [setColumnCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) من الفئة [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) التي تسمح لك بإضافة أعمدة في إطارات النص. من خلال هذه الخاصية، يمكنك تحديد عدد الأعمدة المفضلة في إطار النص.

يظهر هذا الكود JavaScript كيفية إضافة عمود داخل إطار نص:
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


## **تحديث النص**

تمكنك Aspose.Slides من تغيير أو تحديث النص الموجود في مربع نص أو جميع النصوص الموجودة في عرض تقديمي.

يظهر هذا الكود JavaScript عملية تحديث أو تغيير جميع النصوص في عرض تقديمي:
```javascript
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

يمكنك إدراج ارتباط داخل مربع نص. عند النقر على مربع النص، يتم توجيه المستخدمين لفتح الارتباط.

 لإضافة مربع نص يحتوي على ارتباط، اتبع هذه الخطوات:

1. أنشئ نسخة من الفئة `Presentation`. 
2. احصل على مرجع للشرائح الأولى في العرض التقديمي الذي تم إنشاؤه حديثًا. 
3. أضف كائن `AutoShape` مع `ShapeType` محدد كـ `Rectangle` في موضع محدد على الشريحة واحصل على مرجع لكائن AutoShape المضاف حديثًا.
4. أضف `TextFrame` إلى كائن `AutoShape` يحتوي على *Aspose TextBox* كنص افتراضي. 
5. أنشئ نسخة من الفئة `HyperlinkManager`. 
6. عيّن كائن `HyperlinkManager` إلى الخاصية [HyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkClick--) المرتبطة بالجزء المفضَل داخل `TextFrame`.
7. أخيرًا، احفظ ملف PPTX عبر كائن `Presentation`. 

يظهر هذا الكود JavaScript—تنفيذ للخطوات أعلاه—كيفية إضافة مربع نص مع ارتباط تشعبي إلى شريحة:
```javascript
// ينشئ كائن Presentation يمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // يحصل على الشريحة الأولى في العرض التقديمي
    var slide = pres.getSlides().get_Item(0);
    // يضيف كائن AutoShape مع تعيين النوع كـ Rectangle
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // يحول الشكل إلى AutoShape
    var pptxAutoShape = shape;
    // يصل إلى الخاصية ITextFrame المرتبطة بـ AutoShape
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // يضيف بعض النص إلى الإطار
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // يحدد الارتباط التشعبي لنص الجزء
    var hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");
    // يحفظ عرض PPTX
    pres.save("hLink_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة الشائعة**

**ما الفرق بين مربع النص وعنصر النائب النصي عند العمل مع الشرائح الرئيسية؟**

يُورث [placeholder](/slides/ar/nodejs-java/manage-placeholder/) النمط/الموقع من الـ [master](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) ويمكن تجاوزه في [layouts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/)، بينما يُعد مربع النص العادي كائنًا مستقلاً على شريحة محددة ولا يتغير عند تغيير التخطيطات.

**كيف يمكنني إجراء استبدال جماعي للنص عبر العرض التقديمي دون المساس بالنص داخل المخططات والجداول وSmartArt؟**

قم بتقييد التكرار على الأشكال ذات إطارات النص واستبعد الكائنات المدمجة ([charts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/)، [tables](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/)، [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/)) عبر استعراض مجموعاتها بشكل منفصل أو تخطي تلك الأنواع من الكائنات.