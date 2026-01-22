---
title: إضافة مستطيلات إلى العروض التقديمية في JavaScript
linktitle: مستطيل
type: docs
weight: 80
url: /ar/nodejs-java/rectangle/
keywords:
- إضافة مستطيل
- إنشاء مستطيل
- شكل مستطيل
- مستطيل بسيط
- مستطيل منسق
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "عزز عروض PowerPoint التقديمية الخاصة بك بإضافة مستطيلات باستخدام JavaScript و Aspose.Slides لـ Node.js—صمم وعدّل الأشكال برمجيًا بسهولة."
---

{{% alert color="primary" %}} 

مثل المواضيع السابقة، يتناول هذا الموضوع أيضاً إضافة شكل، وهذه المرة سنتحدث عن **المستطيل**. في هذا الموضوع، وصفنا كيف يمكن للمطورين إضافة مستطيلات بسيطة أو منسقة إلى شرائحهم باستخدام Aspose.Slides for Node.js عبر Java.

{{% /alert %}} 

## **إضافة مستطيل إلى الشريحة**
لإضافة مستطيل بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات التالية:

- إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) من نوع المستطيل باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) التي يوفرها كائن [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).
- حفظ العرض التقديمي المعدل كملف PPTX.

في المثال المعطى أدناه، قمنا بإضافة مستطيل بسيط إلى الشريحة الأولى من العرض التقديمي.
```javascript
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // إضافة AutoShape من نوع Rectangle
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // كتابة ملف PPTX إلى القرص
    pres.save("RecShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إضافة مستطيل منسق إلى الشريحة**
لإضافة مستطيل منسق إلى شريحة، يرجى اتباع الخطوات التالية:

- إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) من نوع المستطيل باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) التي يوفرها كائن [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).
- ضبط [Fill Type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillType) للمستطيل إلى Solid.
- ضبط لون المستطيل باستخدام طريقة [SolidFillColor.setColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ColorFormat#setColor-java.awt.Color-) كما يوفرها كائن [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillFormat) المرتبط بكائن [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape).
- ضبط لون خطوط المستطيل.
- ضبط عرض خطوط المستطيل.
- حفظ العرض التقديمي المعدل كملف PPTX.

تم تنفيذ الخطوات أعلاه في المثال المعطى أدناه.
```javascript
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // إضافة AutoShape من نوع إهليلجي
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // تطبيق بعض التنسيقات على شكل الإهليلج
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    // تطبيق بعض التنسيقات على خط الإهليلج
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // كتابة ملف PPTX إلى القرص
    pres.save("RecShp2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة الشائعة**

**كيف يمكنني إضافة مستطيل بزوايا مستديرة؟**

استخدم [shape type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/) ذو الزوايا المستديرة واضبط نصف قطر الزاوية في خصائص الشكل؛ يمكن أيضًا تطبيق الاستدراج على كل زاوية على حدة عبر تعديلات الهندسة.

**كيف يمكنني ملء مستطيل بصورة (نقش)؟**

اختر [fill type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) للصور، قدم مصدر الصورة، وقم بتكوين أوضاع [stretching/tiling modes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/).

**هل يمكن للمستطيل أن يحتوي على ظل وتوهج؟**

نعم. تتوفر [الظل الخارجي/الداخلي، التوهج، والحواف الناعمة](/slides/ar/nodejs-java/shape-effect/) مع معاملات قابلة للتعديل.

**هل يمكنني تحويل المستطيل إلى زر مع ارتباط تشعبي؟**

نعم. يمكنك [Assign a hyperlink](/slides/ar/nodejs-java/manage-hyperlinks/) للنقر على الشكل (الانتقال إلى شريحة، ملف، عنوان ويب، أو بريد إلكتروني).

**كيف يمكنني حماية المستطيل من التحرك والتغييرات؟**

استخدم أقفال الشكل: يمكنك منع التحرك، تغيير الحجم، التحديد، أو تحرير النص للحفاظ على التخطيط.

**هل يمكنني تحويل المستطيل إلى صورة نقطية أو SVG؟**

نعم. يمكنك [render the shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) إلى صورة بحجم/مقياس محدد أو [export it as SVG](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) للاستخدام كمتجه.

**كيف أحصل بسرعة على الخصائص الفعلية (الفعّالة) للمستطيل مع مراعاة السمة والوراثة؟**

استخدم [shape’s effective properties](/slides/ar/nodejs-java/shape-effective-properties/): تُرجِع الواجهة البرمجية القيم المحسوبة التي تأخذ في الاعتبار أنماط السمة، التخطيط، والإعدادات المحلية، مما يبسط تحليل التنسيق.