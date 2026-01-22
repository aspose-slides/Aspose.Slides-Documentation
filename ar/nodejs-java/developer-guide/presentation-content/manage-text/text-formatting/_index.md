---
title: تنسيق نص PowerPoint في JavaScript
linktitle: تنسيق النص
type: docs
weight: 50
url: /ar/nodejs-java/text-formatting/
keywords:
- تمييز النص
- تعبير نمطي
- محاذاة الفقرة
- نمط النص
- خلفية النص
- شفافية النص
- تباعد الأحرف
- خصائص الخط
- عائلة الخط
- دوران النص
- زاوية الدوران
- إطار النص
- تباعد الأسطر
- خاصية الملاءمة التلقائية
- مرساة إطار النص
- جدولة النص
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تنسيق وتنسيق النص في عروض PowerPoint وOpenDocument التقديمية باستخدام JavaScript وAspose.Slides لـ Node.js. تخصيص الخطوط والألوان والمحاذاة والمزيد."
---

## **تمييز النص**

تمت إضافة الطريقة [highlightText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#highlightText-java.lang.String-java.awt.Color-) إلى الفئة [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) و الفئة [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame).

تتيح هذه الطريقة تمييز جزء من النص بلون الخلفية باستخدام عينة نص، مشابهة لأداة تمييز النص بلون الخلفية في PowerPoint 2019.

يوضح المقتطف البرمجي أدناه كيفية استخدام هذه الميزة:
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var textHighlightingOptions = new aspose.slides.TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightText("title", java.getStaticFieldValue("java.awt.Color", "BLUE"));// تمييز جميع الكلمات 'important'
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightText("to", java.getStaticFieldValue("java.awt.Color", "MAGENTA"), textHighlightingOptions);// تمييز جميع حدوث 'the' المنفصلة
    pres.save("OutputPresentation-highlight.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 

توفر Aspose خدمة بسيطة، [خدمة تحرير PowerPoint مجانية عبر الإنترنت](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **تمييز النص باستخدام التعبير النمطي**

تمت إضافة الطريقة [highlightRegex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#highlightRegex-java.lang.String-java.awt.Color-aspose.slides.ITextHighlightingOptions-) إلى الفئة [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) و الفئة [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame).

تتيح هذه الطريقة تمييز جزء من النص بلون الخلفية باستخدام تعبير نمطي، مشابهة لأداة تمييز النص بلون الخلفية في PowerPoint 2019.

يوضح المقتطف البرمجي أدناه كيفية استخدام هذه الميزة:
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var options = new aspose.slides.TextHighlightingOptions();
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.getStaticFieldValue("java.awt.Color", "YELLOW"), options);// تمييز جميع الكلمات التي تتكون من 10 رموز أو أكثر
    pres.save("OutputPresentation-highlight.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تعيين لون خلفية النص**

Aspose.Slides يتيح لك تحديد اللون المفضل لخلفية النص.

يظهر هذا الكود JavaScript كيفية تعيين لون الخلفية لنص كامل:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();
    var para = new aspose.slides.Paragraph();
    var portion1 = new aspose.slides.Portion("Black");
    portion1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    var portion2 = new aspose.slides.Portion(" Red ");
    var portion3 = new aspose.slides.Portion("Black");
    portion3.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    para.getPortions().add(portion1);
    para.getPortions().add(portion2);
    para.getPortions().add(portion3);
    autoShape.getTextFrame().getParagraphs().add(para);
    pres.save("text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
const pres = new aspose.slides.Presentation("text.pptx");
try {
    const slide = pres.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    if (autoShape.getTextFrame() != null) {
        const paragraphs = autoShape.getTextFrame().getParagraphs();
        const paragraphCount = paragraphs.size();
        for (let i = 0; i < paragraphCount; i++) {
            const portions = paragraphs.get_Item(i).getPortions();
            const portionCount = portions.size();
            for (let j = 0; j < portionCount; j++) {
                const portion = portions.get_Item(j);
                portion.getPortionFormat().getHighlightColor().setColor(Color.BLUE);
            }
        }
    }
    pres.save("text-red.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


يظهر هذا الكود JavaScript كيفية تعيين لون الخلفية لجزء فقط من النص:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();
    var para = new aspose.slides.Paragraph();
    var portion1 = new aspose.slides.Portion("Black");
    portion1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    var portion2 = new aspose.slides.Portion(" Red ");
    var portion3 = new aspose.slides.Portion("Black");
    portion3.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    para.getPortions().add(portion1);
    para.getPortions().add(portion2);
    para.getPortions().add(portion3);
    autoShape.getTextFrame().getParagraphs().add(para);
    pres.save("text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
var presentation = new aspose.slides.Presentation("text.pptx");
try {
    var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var redPortion = java.callStaticMethodSync("StreamSupport", "stream", autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().spliterator(), false).filter(p -> p.getText().contains("Red")).findFirst();
    if (redPortion.isPresent()) {
        redPortion.get().getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    }
    presentation.save("text-red.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **محاذاة فقرات النص**

تنسيق النص هو أحد العناصر الأساسية أثناء إنشاء أي نوع من المستندات أو العروض التقديمية. نعلم أن Aspose.Slides for Node.js via Java يدعم إضافة النص إلى الشرائح، ولكن في هذا الموضوع سنتعرف على كيفية التحكم في محاذاة فقرات النص داخل الشريحة. يرجى اتباع الخطوات أدناه لمحاذاة فقرات النص باستخدام Aspose.Slides for Node.js via Java:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة باستخدام Index الخاص بها.
3. الوصول إلى الأشكال Placeholder الموجودة في الشريحة وتحويلها إلى كائن من نوع [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
4. الحصول على الفقرة (التي تحتاج إلى محاذاة) من [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#getTextFrame--) المعروضة بواسطة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. محاذاة الفقرة. يمكن محاذاة الفقرة إلى اليمين أو اليسار أو الوسط أو تعديل العرض.
6. كتابة العرض المعدل كملف PPTX.

التنفيذ العملي للخطوات أعلاه موضح أدناه.
```javascript
// إنشاء كائن Presentation يمثل ملف PPTX
var pres = new aspose.slides.Presentation("ParagraphsAlignment.pptx");
try {
    // الوصول إلى الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // الوصول إلى العنصر النائب الأول والثاني في الشريحة وتحويله إلى AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // تغيير النص في كلا العنصرين النائبين
    tf1.setText("Center Align by Aspose");
    tf2.setText("Center Align by Aspose");
    // الحصول على الفقرة الأولى من العنصرين النائبين
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // محاذاة فقرة النص إلى الوسط
    para1.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);
    // كتابة العرض التقديمي كملف PPTX
    pres.save("Centeralign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تعيين الشفافية للنص**

يوضح هذا المقال كيفية تعيين خاصية الشفافية لأي شكل نص باستخدام Aspose.Slides for Node.js via Java. لتعيين الشفافية للنص، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. الحصول على مرجع شريحة.
3. تعيين لون الظل.
4. كتابة العرض كملف PPTX.

التنفيذ العملي للخطوات أعلاه موضح أدناه.
```javascript
var pres = new aspose.slides.Presentation("transparency.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();
    var outerShadowEffect = effects.getOuterShadowEffect();
    var shadowColor = outerShadowEffect.getShadowColor().getColor();
    console.log((shadowColor.toString() + " - transparency is: ") + ((shadowColor.getAlpha() / 255.0) * 100));
    // تعيين الشفافية إلى صفر بالمئة
    outerShadowEffect.getShadowColor().setColor(java.newInstanceSync("java.awt.Color", shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));
    pres.save("transparency-2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تعيين تباعد الأحرف للنص**

Aspose.Slides يتيح لك ضبط المسافة بين الحروف داخل مربع النص. بهذه الطريقة يمكنك تعديل كثافة عرض سطر أو كتلة نصية بتوسيع أو تقليص المسافات بين الأحرف.

يظهر هذا الكود JavaScript كيفية توسيع التباعد لسطر نص واحد وتضييق التباعد لسطر آخر:
```javascript
var presentation = new aspose.slides.Presentation("in.pptx");
var textBox1 = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var textBox2 = presentation.getSlides().get_Item(0).getShapes().get_Item(1);
textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20);// توسيع
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2);// تقليل
presentation.save("out.pptx", aspose.slides.SaveFormat.Pptx);
```


## **إدارة خصائص خط الفقرة**

عادةً ما يحتوي العرض التقديمي على نصوص وصور. يمكن تنسيق النص بطرق متعددة، إما لتسليط الضوء على أقسام وكلمات معينة أو للامتثال للأنماط المؤسسية. يساعد تنسيق النص المستخدمين على تعديل مظهر محتوى العرض. يوضح هذا المقال كيفية استخدام Aspose.Slides for Node.js via Java لتكوين خصائص الخط للفقرة داخل الشرائح. لإدارة خصائص الخط للفقرة باستخدام Aspose.Slides for Node.js via Java:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. الحصول على مرجع شريحة باستخدام الفهرس الخاص بها.
1. الوصول إلى الأشكال Placeholder في الشريحة وتحويلها إلى [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
1. الحصول على [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) من [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) المعروضة بواسطة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
1. تعديل محاذاة الفقرة.
1. الوصول إلى Portion النص داخل الفقرة.
1. تعريف الخط باستخدام FontData وتعيين الخط للـ Portion وفقًا لذلك.
   1. جعل الخط غامقًا.
   1. جعل الخط مائلًا.
1. تعيين لون الخط باستخدام [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BasePortionFormat#getFillFormat--) المعروض من كائن [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion).
1. كتابة العرض المعدل إلى ملف [PPTX](https://docs.fileformat.com/presentation/pptx/).

التنفيذ العملي للخطوات أعلاه موضح أدناه. يستخدم عرضًا بسيطًا ويضبط الخطوط على إحدى الشرائح.
```javascript
// إنشاء كائن Presentation يمثل ملف PPTX
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // الوصول إلى شريحة باستخدام موضعها
    var slide = pres.getSlides().get_Item(0);
    // الوصول إلى العنصر النائب الأول والثاني في الشريحة وتحويلهما إلى AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // الوصول إلى الفقرة الأولى
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // الوصول إلى الجزء الأول
    var port1 = para1.getPortions().get_Item(0);
    var port2 = para2.getPortions().get_Item(0);
    // تعريف خطوط جديدة
    var fd1 = new aspose.slides.FontData("Elephant");
    var fd2 = new aspose.slides.FontData("Castellar");
    // تعيين الخطوط الجديدة إلى الجزء
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);
    // ضبط الخط إلى غامق
    port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // ضبط الخط إلى مائل
    port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // ضبط لون الخط
    port1.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // كتابة ملف PPTX إلى القرص
    pres.save("WelcomeFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إدارة عائلة الخط للنص**

يُستخدم Portion لاحتواء نص له نمط تنسيق موحد داخل الفقرة. يوضح هذا المقال كيفية استخدام Aspose.Slides for Node.js via Java لإنشاء مربع نص يحتوي على نص ثم تعريف خط محدد، بالإضافة إلى خصائص أخرى لفئة عائلة الخط. لإنشاء مربع نص وتعيين خصائص الخط للنص الموجود فيه:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. الحصول على مرجع شريحة باستخدام الفهرس الخاص بها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) من النوع [Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType#Rectangle) إلى الشريحة.
4. إزالة نمط التعبئة المرتبط بـ [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. الوصول إلى TextFrame الخاص بـ AutoShape.
6. إضافة نص إلى TextFrame.
7. الوصول إلى كائن Portion المرتبط بـ [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
8. تعريف الخط الذي سيُستخدم للـ [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion).
9. تعيين خصائص الخط الأخرى مثل الغامق، المائل، التسطير، اللون والارتفاع باستخدام الخصائص المناسبة لكائن Portion.
10. كتابة العرض المعدل كملف PPTX.

التنفيذ العملي للخطوات أعلاه موضح أدناه.
```javascript
// إنشاء كائن Presentation
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // إضافة AutoShape من النوع Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // إزالة أي نمط تعبئة مرتبط بالـ AutoShape
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // الوصول إلى TextFrame المرتبط بالـ AutoShape
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // الوصول إلى Portion المرتبط بـ TextFrame
    var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
    // تعيين الخط للـ Portion
    port.getPortionFormat().setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // تعيين خاصية الغامق للخط
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // تعيين خاصية المائل للخط
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // تعيين خاصية التسطير للخط
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // تعيين ارتفاع الخط
    port.getPortionFormat().setFontHeight(25);
    // تعيين لون الخط
    port.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // كتابة ملف PPTX إلى القرص
    pres.save("SetTextFontProperties_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تعيين حجم الخط للنص**

Aspose.Slides يتيح لك اختيار حجم الخط المفضل للنص الموجود بالفعل في الفقرة وأي نص قد يضاف إلى الفقرة لاحقًا.

يظهر هذا الكود JavaScript كيفية تعيين حجم الخط للنصوص الموجودة داخل الفقرة:
```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // الحصول على الشكل الأول، على سبيل المثال.
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        var autoShape = shape;
        // الحصول على الفقرة الأولى، على سبيل المثال.
        var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
        // تعيين حجم الخط الافتراضي إلى 20 نقطة لجميع أجزاء النص في الفقرة.
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
        // تعيين حجم الخط إلى 20 نقطة لأجزاء النص الحالية في الفقرة.
        for (let i = 0; i < paragraph.getPortions().getCount(); i++) {
            let portion = paragraph.getPortions().get_Item(i);
            portion.getPortionFormat().setFontHeight(20);
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **تعيين دوران النص**

Aspose.Slides for Node.js via Java يسمح للمطورين بتدوير النص. يمكن تعيين النص ليظهر كـ [Horizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Horizontal)، [Vertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Vertical)، [Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Vertical270)، [WordArtVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#WordArtVertical)، [EastAsianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#EastAsianVertical)، [MongolianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#MongolianVertical) أو [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). لتدوير نص أي TextFrame، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. [دوران النص](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setTextVerticalType-byte-).
6. حفظ الملف إلى القرص.
```javascript
// إنشاء كائن من فئة Presentation
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // إضافة AutoShape من النوع Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // إضافة TextFrame إلى الشكل المستطيل
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // الوصول إلى إطار النص
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(aspose.slides.TextVerticalType.Vertical270);
    // إنشاء كائن Paragraph لإطار النص
    var para = txtFrame.getParagraphs().get_Item(0);
    // إنشاء كائن Portion للفقرة
    var portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // حفظ العرض التقديمي
    pres.save("RotateText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تعيين زاوية دوران مخصصة لإطار النص**

Aspose.Slides for Node.js via Java يدعم الآن تعيين زاوية دوران مخصصة لإطار النص. في هذا الموضوع سنستعرض مثالًا يوضح كيفية تعيين خاصية RotationAngle في Aspose.Slides. تم إضافة الطريقتين الجددتين [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setRotationAngle-float-) و [getRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#getRotationAngle--) إلى الفئة [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) ، مما يتيح تعيين زاوية دوران مخصصة لإطار النص. لتعيين RotationAngle، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. إضافة رسم بياني إلى الشريحة.
3. [تعيين خاصية RotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setRotationAngle-float-).
4. كتابة العرض كملف PPTX.

في المثال أدناه، نقوم بتعيين خاصية RotationAngle.
```javascript
// إنشاء مثيل لفئة Presentation
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // إضافة AutoShape من نوع Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // إضافة TextFrame إلى المستطيل
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // الوصول إلى إطار النص
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);
    // إنشاء كائن Paragraph لإطار النص
    var para = txtFrame.getParagraphs().get_Item(0);
    // إنشاء كائن Portion للفقرة
    var portion = para.getPortions().get_Item(0);
    portion.setText("Text rotation example.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // حفظ العرض التقديمي
    pres.save(resourcesOutputPath + "RotateText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تباعد الأسطر للفقرة**

Aspose.Slides يوفر خصائص تحت [`ParagraphFormat`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ParagraphFormat)—`SpaceAfter`، `SpaceBefore` و `SpaceWithin`—تسمح لك بإدارة تباعد الأسطر للفقرة. تُستعمل الخصائص الثلاث بهذه الطريقة:

* لتحديد تباعد الأسطر للفقرة كنسبة مئوية، استخدم قيمة موجبة. 
* لتحديد تباعد الأسطر للفقرة بالنقاط، استخدم قيمة سالبة.

على سبيل المثال، يمكنك تطبيق تباعد أسطر 16pt للفقرة عن طريق تعيين خاصية `SpaceBefore` إلى -16.

إليك طريقة تحديد تباعد الأسطر لفقرة معينة:

1. تحميل عرض يحتوي على AutoShape به بعض النص.
2. الحصول على مرجع الشريحة عبر الفهرس الخاص بها.
3. الوصول إلى TextFrame.
4. الوصول إلى Paragraph.
5. تعيين خصائص الفقرة.
6. حفظ العرض.

يظهر هذا الكود JavaScript كيفية تحديد تباعد الأسطر للفقرة:
```javascript
// إنشاء مثيل لفئة Presentation
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها
    var sld = pres.getSlides().get_Item(0);
    // الوصول إلى TextFrame
    var tf1 = sld.getShapes().get_Item(0).getTextFrame();
    // الوصول إلى الفقرة
    var para = tf1.getParagraphs().get_Item(0);
    // تعيين خصائص الفقرة
    para.getParagraphFormat().setSpaceWithin(80);
    para.getParagraphFormat().setSpaceBefore(40);
    para.getParagraphFormat().setSpaceAfter(40);
    // حفظ العرض التقديمي
    pres.save("LineSpacing_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تعيين خاصية AutofitType لإطار النص**

في هذا الموضوع نستكشف خصائص تنسيق مختلفة لإطار النص. يغطي هذا المقال كيفية تعيين خاصية AutofitType لإطار النص، وموقع النص داخل الشكل، وتدوير النص في العرض. Aspose.Slides for Node.js via Java يسمح للمطورين بتعيين خاصية AutofitType لأي إطار نص. يمكن تعيين AutofitType إلى [Normal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Normal) أو [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Shape). إذا تم تعيينها إلى [Normal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Normal) سيظل الشكل نفسه بينما يتم تعديل النص دون تغيير الشكل، أما إذا تم تعيينها إلى [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Shape) فسيتم تعديل الشكل بحيث يحتوي فقط على النص المطلوب. لتعيين خاصية AutofitType لإطار نص، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. [تعيين خاصية AutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType-byte-) لإطار النص.
6. حفظ الملف إلى القرص.
```javascript
// إنشاء مثيل لفئة Presentation
var pres = new aspose.slides.Presentation();
try {
    // الوصول إلى الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // إضافة AutoShape من النوع Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 150);
    // إضافة TextFrame إلى المستطيل
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // الوصول إلى إطار النص
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(aspose.slides.TextAutofitType.Shape);
    // إنشاء كائن Paragraph لإطار النص
    var para = txtFrame.getParagraphs().get_Item(0);
    // إنشاء كائن Portion للفقرة
    var portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // حفظ العرض التقديمي
    pres.save(resourcesOutputPath + "formatText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تعيين مرساة إطار النص**

Aspose.Slides for Node.js via Java يسمح للمطورين بتعيين مرساة لأي TextFrame. يحدد TextAnchorType مكان وضع النص داخل الشكل. يمكن تعيين AnchorType إلى [Top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Top)، [Center](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Center)، [Bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Bottom)، [Justified](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Justified) أو [Distributed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Distributed). لتعيين مرساة أي TextFrame، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. [تعيين TextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAnchoringType-byte-) لإطار النص.
6. حفظ الملف إلى القرص.
```javascript
// إنشاء مثيل لفئة Presentation
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // إضافة AutoShape من نوع Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // إضافة TextFrame إلى المستطيل
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // الوصول إلى إطار النص
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(aspose.slides.TextAnchorType.Bottom);
    // إنشاء كائن Paragraph لإطار النص
    var para = txtFrame.getParagraphs().get_Item(0);
    // إنشاء كائن Portion للفقرة
    var portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // حفظ العرض التقديمي
    pres.save("AnchorText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الجدولة وEffectiveTabs في العرض**

جميع علامات الجدولة للنص تُعطى بوحدات البكسل.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Figure: 2 Explicit Tabs and 2 Default Tabs**|
- الخاصية EffectiveTabs.ExplicitTabCount (2 في مثالنا) تساوي Tabs.Count.
- مجموعة EffectiveTabs تشمل جميع علامات الجدولة (من مجموعة Tabs والعلامات الافتراضية).
- الخاصية EffectiveTabs.ExplicitTabCount (2 في مثالنا) تساوي Tabs.Count.
- الخاصية EffectiveTabs.DefaultTabSize (294) تُظهر المسافة بين علامات الجدولة الافتراضية (3 و 4 في مثالنا).
- EffectiveTabs.GetTabByIndex(index) مع index = 0 يُعيد أول علامة صريحة (Position = 731)، index = 1 يُعيد العلامة الثانية (Position = 1241). إذا طلبت العلامة التالية بـ index = 2 سيُعيد أول علامة افتراضية (Position = 1470) وهكذا.
- EffectiveTabs.GetTabAfterPosition(pos) يُستخدم للحصول على علامة الجدولة التالية بعد نص معين. على سبيل المثال لديك النص: "Hello World!". لتصميم هذا النص تحتاج إلى معرفة مكان بدء رسم "world!". أولًا، احسب طول "Hello" بالبكسل ثم استدعِ GetTabAfterPosition بهذه القيمة. ستحصل على موقع العلامة التالية لرسم "world!".

## **تعيين نمط النص الافتراضي**

إذا كنت بحاجة إلى تطبيق تنسيق نص افتراضي موحد على جميع عناصر النص في عرضٍ تقديمي مرة واحدة، يمكنك استخدام طريقة `getDefaultTextStyle` من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) وتعيين التنسيق المفضل. يوضح المثال البرمجي أدناه كيفية تعيين خط عريض افتراضي (14 pt) للنص على جميع الشرائح في عرض جديد.
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // احصل على تنسيق الفقرة المستوى الأعلى.
    var paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);
    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    }
    presentation.save("DefaultTextStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **استخراج النص بتأثير الأحرف الكبيرة كلها**

في PowerPoint، تطبيق تأثير الخط **All Caps** يجعل النص يظهر بأحرف كبيرة على الشريحة حتى لو تم كتابته بحروف صغيرة. عند استخراج مثل هذا الجزء النصي باستخدام Aspose.Slides، تُعيد المكتبة النص كما تم إدخاله. للتعامل مع ذلك، تحقق من [TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/)—إذا كان يساوي `All`، حوّل السلسلة المُسترجعة إلى أحرف كبيرة حتى يتطابق المخرجات مع ما يراه المستخدمون على الشريحة.

لنفترض أن لدينا صندوق نص كما هو موضح في الشريحة الأولى من ملف sample2.pptx.

![The All Caps effect](all_caps_effect.png)

يظهر المثال البرمجي أدناه كيفية استخراج النص مع تطبيق تأثير **All Caps**:
```js
var presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    var autoShape = slide.getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    var textPortion = paragraph.getPortions().get_Item(0);

    console.log("Original text:", textPortion.getText());

    var textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == aspose.slides.TextCapType.All) {
        var text = textPortion.getText().toUpperCase();
        console.log("All-Caps effect:", text);
    }
} finally {
    presentation.dispose();
}
```


الناتج:
```text
النص الأصلي: Hello, Aspose!
تأثير الأحرف الكبيرة: HELLO, ASPOSE!
```


## **الأسئلة الشائعة**

**كيف يمكن تعديل النص في جدول داخل شريحة؟**

لتعديل النص في جدول داخل شريحة، تحتاج إلى استخدام كائن [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/). يمكنك التنقل عبر جميع الخلايا في الجدول وتغيير النص في كل خلية بالوصول إلى خصائص `TextFrame` و `ParagraphFormat` داخل كل خلية.

**كيف يمكن تطبيق لون تدرجي على النص في شريحة PowerPoint؟**

لتطبيق لون تدرجي على النص، استخدم خاصية Fill Format في [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/). عيّن Fill Format إلى `Gradient`، حيث يمكنك تحديد ألوان البداية والنهاية للتدرج، بالإضافة إلى خصائص أخرى مثل الاتجاه والشفافية لإنشاء تأثير التدرج على النص.