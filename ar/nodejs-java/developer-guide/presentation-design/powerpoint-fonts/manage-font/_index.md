---
title: إدارة الخطوط في العروض التقديمية باستخدام JavaScript
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
description: "التحكم في الخطوط باستخدام Aspose.Slides لـ Node.js عبر Java: تضمين، استبدال، وتحميل خطوط مخصصة للحفاظ على وضوح وتناسق عروض PPT و PPTX و ODP."
---

## **إدارة الخصائص المتعلقة بالخط**
{{% alert color="primary" %}} 

عادةً ما تحتوي العروض التقديمية على النصوص والصور معًا. يمكن تنسيق النص بطرق متعددة، إما لتسليط الضوء على أقسام وكلمات معينة أو للامتثال لأنماط الشركة. يساعد تنسيق النص المستخدمين على تنويع مظهر ومحتوى العرض التقديمي. توضح هذه المقالة كيفية استخدام Aspose.Slides for Node.js via Java لتكوين خصائص الخط في فقرات النص على الشرائح.

{{% /alert %}} 

لإدارة خصائص الخط في فقرة باستخدام Aspose.Slides for Node.js via Java:

1. إنشاء مثيل للفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. الحصول على مرجع الشريحة باستخدام فهرستها.
1. الوصول إلى أشكال [Placeholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/) في الشريحة وتحويل نوعها إلى [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
1. الحصول على [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) من [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) المعروض بواسطة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
1. ضبط محاذاة الفقرة.
1. الوصول إلى [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) النصي للـ [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/).
1. تعريف الخط باستخدام [FontData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) وتعيين **Font** لجزء النص [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) وفقًا لذلك.
   1. ضبط الخط إلى غامق.
   1. ضبط الخط إلى مائل.
1. تعيين لون الخط باستخدام [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) المعروض بواسطة كائن [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/).
1. حفظ العرض التقديمي المعدل إلى ملف PPTX.

التنفيذ للخطوات أعلاه موضح أدناه. يأخذ عرضًا تقديميًا غير معدل ويقوم بتنسيق الخطوط في إحدى الشرائح. توضح اللقطات التالية ملف الإدخال وكيفية تغيير الشيفرة له. تقوم الشيفرة بتغيير الخط واللون ونمط الخط.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**شكل: النص في ملف الإدخال**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**شكل: نفس النص مع تنسيق محدث**|
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
    // تعديل محاذاة الفقرة إلى محاذاة مبررة
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.JustifyLow);
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

كما هو مذكور في **Managing Font Related Properties**، يُستخدم [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) لحفظ النص الذي يمتلك نمط تنسيق مشابه في الفقرة. توضح هذه المقالة كيفية استخدام Aspose.Slides for Node.js via Java لإنشاء مربع نص يحتوي على بعض النصوص ثم تعريف خط معين، بالإضافة إلى خصائص أخرى لفئة الخط.

{{% /alert %}} 

لإنشاء مربع نص وتعيين خصائص الخط للنص الموجود فيه:

1. إنشاء مثيل للفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. الحصول على مرجع الشريحة باستخدام فهرستها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) من النوع **Rectangle** إلى الشريحة.
1. إزالة نمط الملء المرتبط بـ [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) الخاص بـ [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
1. إضافة بعض النص إلى [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).
1. الوصول إلى كائن [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) المرتبط بـ [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).
1. تعريف الخط الذي سيُستخدم للـ [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/).
1. تعيين خصائص أخرى للخط مثل الغامق، المائل، التحتي، اللون والارتفاع باستخدام الخصائص ذات الصلة التي يُظهرها كائن [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/).
1. كتابة العرض التقديمي المعدل كملف PPTX.

التنفيذ للخطوات أعلاه موضح أدناه.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**شكل: نص مع بعض خصائص الخط التي تم ضبطها بواسطة Aspose.Slides for Node.js via Java**|
```javascript
// إنشاء كائن Presentation يمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // إضافة AutoShape من النوع Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // إزالة أي نمط تعبئة مرتبط بـ AutoShape
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // الوصول إلى TextFrame المرتبط بـ AutoShape
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // الوصول إلى Portion المرتبط بـ TextFrame
    var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
    // تعيين الخط للجزء
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
