---
title: إدارة الخطوط في العروض التقديمية باستخدام جافاسكريبت
linktitle: إدارة الخطوط
type: docs
weight: 10
url: /ar/nodejs-java/manage-fonts/
keywords:
- إدارة الخطوط
- خصائص الخط
- فقرة
- تنسيق النص
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "التحكم في الخطوط باستخدام Aspose.Slides لـ Node.js عبر Java: تضمين الخطوط، استبدالها، وتحميل خطوط مخصصة للحفاظ على وضوح واتساق عروض PPT، PPTX و ODP."
---

## **إدارة خصائص الخط ذات الصلة**
{{% alert color="primary" %}} 

عادةً ما تحتوي العروض التقديمية على كل من النصوص والصور. يمكن تنسيق النص بطرق متعددة، إما لتسليط الضوء على أقسام وكلمات معينة أو للامتثال للأنماط المؤسسية. يساعد تنسيق النص المستخدمين على تنويع المظهر والشعور بمحتوى العرض. يوضح هذا المقال كيف يمكن استخدام Aspose.Slides for Node.js via Java لتكوين خصائص الخط للفقرات النصية على الشرائح.

{{% /alert %}} 

لإدارة خصائص الخط لفقرة باستخدام Aspose.Slides for Node.js via Java:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) .
1. الحصول على مرجع الشريحة باستخدام فهرسها.
1. الوصول إلى أشكال [Placeholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Placeholder) في الشريحة وتحويلها إلى النوع [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/AutoShape) .
1. جلب الـ [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Paragraph) من الـ [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/TextFrame) الذي توفره [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/AutoShape) .
1. ضبط محاذاة الفقرة (Justify).
1. الوصول إلى نص الـ [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Paragraph) عبر الـ [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion) .
1. تعريف الخط باستخدام [FontData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/FontData) وتعيين **Font** لنص الـ [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion) وفقاً لذلك.
   1. تعيين الخط إلى غامق (Bold).
   1. تعيين الخط إلى مائل (Italic).
1. تعيين لون الخط باستخدام الـ [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/FillFormat) الذي توفره كائن الـ [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion) .
1. حفظ العرض المعدل إلى ملف PPTX.

التنفيذ العملي للخطوات المذكورة أعلاه موضح أدناه. يتم أخذ عرض تقديمي بسيط وتنسيق الخطوط في إحدى الشرائح. اللقطات التي تلي ذلك تعرض ملف الإدخال وكيفية تعديل الكود له. يغيّر الكود الخط واللون ونمط الخط.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**الشكل: النص في ملف الإدخال**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**الشكل: نفس النص بعد تحديث التنسيق**|
```javascript
    // إنشاء كائن Presentation يمثل ملف PPTX
    var pres = new aspose.slides.Presentation("FontProperties.pptx");
    try {
        // الوصول إلى شريحة باستخدام موضعها
        var slide = pres.getSlides().get_Item(0);
        // الوصول إلى العنصر النائب الأول والثاني في الشريحة وتحويله إلى AutoShape
        var tf1 = slide.getShapes().get_Item(0).getTextFrame();
        var tf2 = slide.getShapes().get_Item(1).getTextFrame();
        // الوصول إلى الفقرة الأولى
        var para1 = tf1.getParagraphs().get_Item(0);
        var para2 = tf2.getParagraphs().get_Item(0);
        // ضبط محاذاة الفقرة
        para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.JustifyLow);
        // الوصول إلى الجزء الأول
        var port1 = para1.getPortions().get_Item(0);
        var port2 = para2.getPortions().get_Item(0);
        // تعريف خطوط جديدة
        var fd1 = new aspose.slides.FontData("Elephant");
        var fd2 = new aspose.slides.FontData("Castellar");
        // تعيين خطوط جديدة للجزء
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
        port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
        port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
        // حفظ ملف PPTX إلى القرص
        pres.save("WelcomeFont.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```


## **تعيين خصائص خط النص**
{{% alert color="primary" %}} 

كما ذُكر في **إدارة خصائص الخط ذات الصلة**، يُستخدم الـ [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion) لتجميع النصوص التي تشترك في نمط تنسيق مماثل داخل الفقرة. يوضح هذا المقال كيف يمكن استخدام Aspose.Slides for Node.js via Java لإنشاء صندوق نص يحتوي على بعض النصوص ثم تعريف خط محدد، بالإضافة إلى خصائص أخرى لفئة عائلة الخط.

{{% /alert %}} 

لإنشاء صندوق نص وتعيين خصائص الخط للنص داخلّه:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) .
1. الحصول على مرجع شريحة باستخدام فهرسها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/AutoShape) من النوع **Rectangle** إلى الشريحة.
1. إزالة نمط التعبئة المرتبط بالـ [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/AutoShape) .
1. الوصول إلى الـ [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/TextFrame) الخاص بالـ [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/AutoShape) .
1. إضافة بعض النص إلى الـ [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/TextFrame) .
1. الوصول إلى كائن الـ [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion) المرتبط بالـ [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/TextFrame) .
1. تعريف الخط الذي سيُستخدم للـ [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion) .
1. تعيين خصائص الخط الأخرى مثل الغامق، المائل، الخط السفلي، اللون والارتفاع باستخدام الخصائص المعروضة من خلال كائن الـ [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion) .
1. كتابة العرض المعدل كملف PPTX.

التنفيذ العملي للخطوات المذكورة أعلاه موضح أدناه.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**الشكل: نص مع بعض خصائص الخط التي ضبطتها Aspose.Slides for Node.js via Java**|
```javascript
// إنشاء كائن Presentation يمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // إضافة AutoShape من نوع Rectangle
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
    // تعيين خاصية التسطير للخط
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // تعيين ارتفاع الخط
    port.getPortionFormat().setFontHeight(25);
    // تعيين لون الخط
    port.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // حفظ العرض التقديمي إلى القرص
    pres.save("pptxFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
