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
- تدوير النص
- زاوية الدوران
- إطار النص
- تباعد الأسطر
- خاصية الملاءمة التلقائية
- مرساة إطار النص
- تبويب النص
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- العرض التقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعرف على كيفية تنسيق وتنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لـ Node.js عبر Java. خصّص الخطوط والألوان والمحاذاة وغير ذلك باستخدام أمثلة كود JavaScript القوية."
---

## **تمييز النص**

تم إضافة طريقة [highlightText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#highlightText-java.lang.String-java.awt.Color-) إلى الفئة [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) و الفئة [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame).

تتيح لك تمييز جزء من النص بلون خلفية باستخدام عينة نصية، مشابه لأداة تمييز النص بالألوان في PowerPoint 2019.

المقتطف البرمجي أدناه يوضح كيفية استخدام هذه الميزة:
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var textHighlightingOptions = new aspose.slides.TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightText("title", java.getStaticFieldValue("java.awt.Color", "BLUE"));// تمييز جميع الكلمات 'important'
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightText("to", java.getStaticFieldValue("java.awt.Color", "MAGENTA"), textHighlightingOptions);// تمييز جميع حدوث كلمة 'the' المنفصلة
    pres.save("OutputPresentation-highlight.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 
توفر Aspose خدمة تحرير PowerPoint مجانية عبر الإنترنت بسيطة، [خدمة تحرير PowerPoint المجانية عبر الإنترنت](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **تمييز النص باستخدام التعبير النمطي**

تم إضافة طريقة [highlightRegex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#highlightRegex-java.lang.String-java.awt.Color-aspose.slides.ITextHighlightingOptions-) إلى الفئة [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) و الفئة [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame).

تتيح لك تمييز جزء من النص بلون خلفية باستخدام تعبير نمطي، مشابه لأداة تمييز النص بالألوان في PowerPoint 2019.

المقتطف البرمجي أدناه يوضح كيفية استخدام هذه الميزة:
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var options = new aspose.slides.TextHighlightingOptions();
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.getStaticFieldValue("java.awt.Color", "YELLOW"), options);// تمييز جميع الكلمات التي تحتوي على 10 رموز أو أكثر
    pres.save("OutputPresentation-highlight.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تعيين لون خلفية النص**

تتيح لك Aspose.Slides تحديد اللون المفضل لخلفية النص.

يُظهر لك هذا الكود JavaScript كيفية تعيين لون الخلفية لكامل النص:
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


يُظهر لك هذا الكود JavaScript كيفية تعيين لون الخلفية لجزء فقط من النص:
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

تنسيق النص هو أحد العناصر الأساسية عند إنشاء أي نوع من المستندات أو العروض التقديمية. نعلم أن Aspose.Slides لـ Node.js عبر Java يدعم إضافة النص إلى الشرائح، ولكن في هذا الموضوع، سنرى كيف يمكننا التحكم في محاذاة فقرات النص في الشريحة. الرجاء اتباع الخطوات التالية لمحاذاة فقرات النص باستخدام Aspose.Slides لـ Node.js عبر Java:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. الحصول على مرجع الشريحة باستخدام فهرستها.
3. الوصول إلى أشكال Placeholder الموجودة في الشريحة وتحويلها إلى [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) .
4. الحصول على الفقرة (التي تحتاج إلى محاذاة) من [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#getTextFrame--) المعروض بواسطة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) .
5. محاذاة الفقرة. يمكن محاذاة الفقرة إلى اليمين أو اليسار أو الوسط أو الضبط.
6. حفظ العرض التقديمي المعدل كملف PPTX.

التنفيذ للخطوات أعلاه موضح أدناه.
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

توضح هذه المقالة كيفية تعيين خاصية الشفافية لأي شكل نص باستخدام Aspose.Slides لـ Node.js عبر Java. لتعيين الشفافية للنص، يرجى اتباع الخطوات التالية:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. الحصول على مرجع شريحة.
3. تعيين لون الظل
4. حفظ العرض التقديمي كملف PPTX.

التنفيذ للخطوات أعلاه موضح أدناه.
```javascript
var pres = new aspose.slides.Presentation("transparency.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();
    var outerShadowEffect = effects.getOuterShadowEffect();
    var shadowColor = outerShadowEffect.getShadowColor().getColor();
    console.log((shadowColor.toString() + " - transparency is: ") + ((shadowColor.getAlpha() / 255.0) * 100));
    // ضبط الشفافية إلى صفر بالمائة
    outerShadowEffect.getShadowColor().setColor(java.newInstanceSync("java.awt.Color", shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));
    pres.save("transparency-2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تعيين تباعد الأحرف للنص**

تتيح لك Aspose.Slides تعيين المسافة بين الحروف داخل مربع النص. بهذه الطريقة يمكنك تعديل الكثافة البصرية لسطر أو كتلة نصية عن طريق توسيع أو تقليل التباعد بين الأحرف.

يُظهر لك هذا الكود JavaScript كيفية توسيع التباعد لسطر نص واحد وتقليل التباعد لسطر آخر:
```javascript
var presentation = new aspose.slides.Presentation("in.pptx");
var textBox1 = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var textBox2 = presentation.getSlides().get_Item(0).getShapes().get_Item(1);
textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20);// توسيع
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2);// تقليل
presentation.save("out.pptx", aspose.slides.SaveFormat.Pptx);
```


## **إدارة خصائص الخط للفقرة**

عادةً ما تحتوي العروض التقديمية على نصوص وصور. يمكن تنسيق النص بطرق متعددة، إما لتسليط الضوء على أقسام معينة أو لتوافق الأنماط المؤسسية. يساعد تنسيق النص المستخدمين على تنويع مظهر محتوى العرض. توضح هذه المقالة كيفية استخدام Aspose.Slides لـ Node.js عبر Java لتكوين خصائص الخط للفقرات النصية على الشرائح. لإدارة خصائص الخط لفقرة باستخدام Aspose.Slides لـ Node.js عبر Java:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. الحصول على مرجع شريحة باستخدام فهرستها.
3. الوصول إلى أشكال Placeholder في الشريحة وتحويلها إلى [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) .
4. الحصول على [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) من [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) المعروض بواسطة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) .
5. ضبط الفقرة.
6. الوصول إلى الجزء النصي للفقرة.
7. تعريف الخط باستخدام FontData وتعيين الخط للجزء النصي وفقًا لذلك.
   1. تعيين الخط إلى غامق.
   2. تعيين الخط إلى مائل.
8. تعيين لون الخط باستخدام [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BasePortionFormat#getFillFormat--) المعروض بواسطة كائن [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion) .
9. حفظ العرض التقديمي المعدل كملف [PPTX](https://docs.fileformat.com/presentation/pptx/) .

التنفيذ للخطوات أعلاه موضح أدناه. يأخذ عرضًا تقديميًا بسيطًا ويُنسق الخطوط في إحدى الشرائح.
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
    // تعيين الخط إلى غامق
    port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // تعيين الخط إلى مائل
    port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // تعيين لون الخط
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

يُستخدم الجزء (Portion) لاحتضان نص بتنسيق موحد داخل فقرة. توضح هذه المقالة كيفية استخدام Aspose.Slides لـ Node.js عبر Java لإنشاء مربع نص يحتوي على بعض النص ثم تعريف خط معين، بالإضافة إلى خصائص أخرى لعائلة الخط. لإنشاء مربع نص وتعيين خصائص الخط للنص فيه:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. الحصول على مرجع شريحة باستخدام فهرستها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) من النوع [Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType#Rectangle) إلى الشريحة.
4. إزالة نمط التعبئة المرتبط بـ [AutoShape] .
5. الوصول إلى TextFrame الخاص بـ AutoShape.
6. إضافة بعض النص إلى TextFrame.
7. الوصول إلى كائن Portion المرتبط بـ [TextFrame] .
8. تحديد الخط المستخدم للـ [Portion] .
9. تعيين خصائص الخط الأخرى مثل الغامق، المائل، تحت الخط، اللون والارتفاع باستخدام الخصائص ذات الصلة المعروضة بواسطة كائن Portion.
10. حفظ العرض التقديمي المعدل كملف PPTX.

التنفيذ للخطوات أعلاه موضح أدناه.
```javascript
// إنشاء كائن Presentation
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // إضافة AutoShape من نوع مستطيل
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // إزالة أي نمط تعبئة مرتبط بـ AutoShape
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // الوصول إلى TextFrame المرتبط بـ AutoShape
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
    // تعيين خاصية الخط السفلي للخط
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

تتيح لك Aspose.Slides اختيار حجم الخط المفضل للنص الموجود بالفعل في فقرة والنصوص التي قد تُضاف إلى الفقرة لاحقًا.

يُظهر لك هذا الكود JavaScript كيفية تعيين حجم الخط للنصوص الموجودة داخل فقرة:
```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // يحصل على الشكل الأول، على سبيل المثال.
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        var autoShape = shape;
        // يحصل على الفقرة الأولى، على سبيل المثال.
        var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
        // يضبط حجم الخط الافتراضي إلى 20 نقطة لجميع أجزاء النص في الفقرة.
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
        // يضبط حجم الخط إلى 20 نقطة لأجزاء النص الحالية في الفقرة.
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

تسمح Aspose.Slides لـ Node.js عبر Java للمطورين بتدوير النص. يمكن ضبط النص ليظهر كـ [Horizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Horizontal)، [Vertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Vertical)، [Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Vertical270)، [WordArtVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#WordArtVertical)، [EastAsianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#EastAsianVertical)، [MongolianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#MongolianVertical) أو [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). لتدوير نص أي TextFrame، يرجى اتباع الخطوات التالية:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. الوصول إلى الشريحة الأولى.
3. إضافة أي Shape إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) .
5. [دوّر النص](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setTextVerticalType-byte-) .
6. حفظ الملف إلى القرص.
```javascript
// إنشاء كائن من فئة Presentation
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // إضافة AutoShape من نوع مستطيل
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // إضافة TextFrame إلى المستطيل
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

يدعم الآن Aspose.Slides لـ Node.js عبر Java تعيين زاوية دوران مخصصة لإطار النص. في هذا الموضوع، سنوضح بالمثال كيفية تعيين خاصية RotationAngle في Aspose.Slides. تمت إضافة الطريقتين [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setRotationAngle-float-) و [getRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#getRotationAngle--) إلى الفئة [ChartTextBlockFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartTextBlockFormat) وفئة [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) ، وتسمح بتعيين زاوية دوران مخصصة لإطار النص. لتعيين RotationAngle، يرجى اتباع الخطوات التالية:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. إضافة مخطط إلى الشريحة.
3. [تعيين خاصية RotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setRotationAngle-float-) .
4. حفظ العرض التقديمي كملف PPTX.

في المثال أدناه، نقوم بتعيين خاصية RotationAngle.
```javascript
// إنشاء كائن من فئة Presentation
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // إضافة AutoShape من نوع مستطيل
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

تقدم Aspose.Slides خصائص ضمن [`ParagraphFormat`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ParagraphFormat) —`SpaceAfter`، `SpaceBefore` و `SpaceWithin`— التي تتيح لك إدارة تباعد الأسطر لفقرة. تُستخدم الخصائص الثلاثة كالتالي:

* لتحديد تباعد الأسطر للفقرة كنسبة مئوية، استخدم قيمة موجبة. 
* لتحديد تباعد الأسطر للفقرة بوحدات النقاط، استخدم قيمة سالبة.

على سبيل المثال، يمكنك تطبيق تباعد أسطر 16pt لفقرة عن طريق ضبط خاصية `SpaceBefore` إلى -16.

هكذا تحدد تباعد الأسطر لفقرة محددة:

1. تحميل عرض تقديمي يحتوي على AutoShape به بعض النص.
2. الحصول على مرجع شريحة من خلال فهرستها.
3. الوصول إلى TextFrame.
4. الوصول إلى Paragraph.
5. ضبط خصائص الفقرة.
6. حفظ العرض التقديمي.

يُظهر لك هذا الكود JavaScript كيفية تحديد تباعد الأسطر لفقرة:
```javascript
    // إنشاء كائن من فئة Presentation
    var pres = new aspose.slides.Presentation("Fonts.pptx");
    try {
        // الحصول على مرجع الشريحة باستخدام الفهرس
        var sld = pres.getSlides().get_Item(0);
        // الوصول إلى TextFrame
        var tf1 = sld.getShapes().get_Item(0).getTextFrame();
        // الوصول إلى الفقرة
        var para = tf1.getParagraphs().get_Item(0);
        // ضبط خصائص الفقرة
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

في هذا الموضوع، نستكشف مختلف خصائص تنسيق إطار النص. تغطي المقالة كيفية تعيين خاصية AutofitType لإطار النص، وتثبيت النص وتدويره في العرض. يسمح Aspose.Slides لـ Node.js عبر Java للمطورين بتعيين خاصية AutofitType لأي إطار نص. يمكن ضبط AutofitType إلى [Normal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Normal) أو [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Shape). إذا تم ضبطه إلى [Normal]، يبقى الشكل كما هو بينما يُعدل النص دون تغيير الشكل؛ وإذا تم ضبطه إلى [Shape]، يتم تعديل الشكل لاحتواء النص المطلوب فقط. لتعيين خاصية AutofitType لإطار نص، يرجى اتباع الخطوات التالية:

1. إنشاء مثال من الفئة [Presentation ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) .
5. [تعيين AutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType-byte-) لإطار النص.
6. حفظ الملف إلى القرص.
```javascript
// إنشاء كائن من فئة Presentation
var pres = new aspose.slides.Presentation();
try {
    // الوصول إلى الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // إضافة AutoShape من نوع مستطيل
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


## **تعيين مرساة لإطار النص**

يسمح Aspose.Slides لـ Node.js عبر Java للمطورين بتعيين مرساة لأي TextFrame. يحدد TextAnchorType موضع النص داخل الشكل. يمكن ضبط AnchorType إلى [Top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Top)، [Center](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Center)، [Bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Bottom)، [Justified](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Justified) أو [Distributed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Distributed). لتعيين مرساة لأي TextFrame، يرجى اتباع الخطوات التالية:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) .
5. [تعيين TextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAnchoringType-byte-) لإطار النص.
6. حفظ الملف إلى القرص.
```javascript
// Create an instance of Presentation class
var pres = new aspose.slides.Presentation();
try {
    // Get the first slide
    var slide = pres.getSlides().get_Item(0);
    // Add an AutoShape of Rectangle type
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // Add TextFrame to the Rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Accessing the text frame
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(aspose.slides.TextAnchorType.Bottom);
    // Create the Paragraph object for text frame
    var para = txtFrame.getParagraphs().get_Item(0);
    // Create Portion object for paragraph
    var portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Save Presentation
    pres.save("AnchorText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **علامات التبويب وEffectiveTabs في العرض التقديمي**

جميع التبويبات النصية مُعطاة بوحدة البكسل.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Figure: 2 Explicit Tabs and 2 Default Tabs**|
- الخاصية EffectiveTabs.ExplicitTabCount (2 في مثالنا) تساوي عدد Tabs.
- مجموعة EffectiveTabs تشمل جميع التبويبات (من مجموعة Tabs والتبويبات الافتراضية).
- الخاصية EffectiveTabs.ExplicitTabCount (2 في مثالنا) تساوي عدد Tabs.
- الخاصية EffectiveTabs.DefaultTabSize (294) تُظهر المسافة بين التبويبات الافتراضية (3 و 4 في مثالنا).
- الدالة EffectiveTabs.GetTabByIndex(index) مع index = 0 تُعيد أول تبويب صريح (Position = 731)، index = 1‑‑التبويب الثاني (Position = 1241). إذا حاولت الحصول على تبويب التالي بالـ index = 2 ستُعيد أول تبويب افتراضي (Position = 1470) وهكذا.
- الدالة EffectiveTabs.GetTabAfterPosition(pos) تُستخدم للحصول على التبويب التالي بعد نص معين. على سبيل المثال لديك النص: "Hello World!". لتصيير هذا النص تحتاج إلى معرفة أين تبدأ رسم "world!". أولاً، احسب طول "Hello" بالبكسل ثم استدعِ GetTabAfterPosition بهذه القيمة. ستحصل على موضع التبويب التالي لرسم "world!".

## **تعيين نمط النص الافتراضي**

إذا كنت بحاجة لتطبيق نفس تنسيق النص الافتراضي على جميع عناصر النص في عرض تقديمي مرة واحدة، يمكنك استخدام طريقة `getDefaultTextStyle` من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) وتعيين التنسيق المفضل. يوضح المثال البرمجي أدناه كيفية تعيين الخط العريض الافتراضي (14 pt) للنص على جميع الشرائح في عرض تقديمي جديد.
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // احصل على تنسيق الفقرة من المستوى الأعلى.
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


## **استخراج النص مع تأثير الأحرف الكبيرة**

في PowerPoint، يجعل تطبيق تأثير الخط **All Caps** النص يظهر بالحروف الكبيرة على الشريحة حتى لو تم كتابته أصلاً بأحرف صغيرة. عند استخراج هذا الجزء النصي باستخدام Aspose.Slides، تُعيد المكتبة النص كما تم إدخاله. لمعالجة ذلك، تحقق من [TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/)—إذا أظهر `All`، قم بتحويل السلسلة المسترجعة إلى أحرف كبيرة حتى يتطابق الإخراج مع ما يراه المستخدم على الشريحة.

لنفترض أن لدينا مربع النص التالي على الشريحة الأولى من ملف sample2.pptx.

![The All Caps effect](all_caps_effect.png)

 يوضح المثال البرمجي أدناه كيفية استخراج النص مع تطبيق تأثير **All Caps**:
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


الإخراج:
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **الأسئلة الشائعة**

**كيف يمكن تعديل النص في جدول على شريحة؟**

لتعديل النص في جدول على شريحة، تحتاج إلى استخدام كائن [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/). يمكنك iterating عبر جميع الخلايا في الجدول وتغيير النص في كل خلية عبر الوصول إلى خصائص `TextFrame` و `ParagraphFormat` الخاصة بها.

**كيف يمكن تطبيق تدرج اللون على النص في شريحة PowerPoint؟**

لتطبيق تدرج اللون على النص، استخدم خاصية Fill Format في [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/). اضبط Fill Format إلى `Gradient` حيث يمكنك تحديد ألوان البداية والنهاية للتدرج، بالإضافة إلى خصائص أخرى مثل الاتجاه والشفافية لإنشاء تأثير التدرج على النص.