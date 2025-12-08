---
title: مستطيل
type: docs
weight: 80
url: /ar/nodejs-java/rectangle/
---

{{% alert color="primary" %}} 

مثل المواضيع السابقة، هذا الموضوع أيضًا يتناول إضافة شكل وهذه المرة سنناقش الشكل **Rectangle**. في هذا الموضوع، وصفنا كيف يمكن للمطورين إضافة مستطيلات بسيطة أو مُنسقة إلى شرائحهم باستخدام Aspose.Slides for Node.js عبر Java.

{{% /alert %}} 

## **إضافة مستطيل إلى الشريحة**
لإضافة مستطيل بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات التالية:

- إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) .
- الحصول على مرجع الشريحة باستخدام فهرسها.
- إضافة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) من نوع Rectangle باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) التي توفرها كائن [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) .
- كتابة العرض التقديمي المعدل كملف PPTX.

في المثال المعطى أدناه، قمنا بإضافة مستطيل بسيط إلى الشريحة الأولى من العرض التقديمي.
```javascript
// إنشاء فئة Prseetation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // احصل على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // إضافة AutoShape من نوع الشكل البيضاوي
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // كتابة ملف PPTX إلى القرص
    pres.save("RecShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إضافة مستطيل مُنسق إلى الشريحة**
لإضافة مستطيل مُنسق إلى شريحة، يرجى اتباع الخطوات التالية:

- إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) .
- الحصول على مرجع الشريحة باستخدام فهرسها.
- إضافة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) من نوع Rectangle باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) التي توفرها كائن [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) .
- تعيين [Fill Type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillType) للمستطيل إلى Solid.
- تعيين لون المستطيل باستخدام طريقة [SolidFillColor.setColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ColorFormat#setColor-java.awt.Color-) كما تُعرض من خلال كائن [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillFormat) المرتبط بكائن [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) .
- تعيين لون خطوط المستطيل.
- تعيين عرض خطوط المستطيل.
- كتابة العرض التقديمي المعدل كملف PPTX.

تم تنفيذ الخطوات السابقة في المثال المعطى أدناه.
```javascript
// إنشاء فئة Presentation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // إضافة AutoShape من نوع إهليلج
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

استخدم نوع الشكل [shape type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/) ذو الزوايا المستديرة وقم بضبط نصف قطر الزاوية في خصائص الشكل؛ يمكن أيضًا تطبيق الاستدارة على كل زاوية عبر تعديلات الهندسة.

**كيف أملأ مستطيلًا بصورة (نقش)؟**

اختر [fill type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) للصور، قدم مصدر الصورة، وقم بضبط أوضاع [stretching/tiling modes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) .

**هل يمكن للمستطيل أن يحتوي على ظل وتوهج؟**

نعم. [Outer/inner shadow, glow, and soft edges](/slides/ar/nodejs-java/shape-effect/) متاحة مع معلمات قابلة للتعديل.

**هل يمكنني تحويل المستطيل إلى زر مع ارتباط تشعبي؟**

نعم. [Assign a hyperlink](/slides/ar/nodejs-java/manage-hyperlinks/) للنقر على الشكل (الانتقال إلى شريحة، ملف، عنوان ويب، أو بريد إلكتروني).

**كيف يمكنني حماية المستطيل من التحرك والتغييرات؟**

[Use shape locks](/slides/ar/nodejs-java/applying-protection-to-presentation/): يمكنك منع التحرك، إعادة الحجم، الاختيار أو تحرير النص للحفاظ على التخطيط.

**هل يمكنني تحويل المستطيل إلى صورة نقطية أو SVG؟**

نعم. يمكنك [render the shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) إلى صورة بحجم/مقياس محدد أو [export it as SVG](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) للاستخدام كمتجه.

**كيف أحصل بسرعة على الخصائص الفعلية (الفعّالة) للمستطيل مع مراعاة السمة والوراثة؟**

[Use the shape’s effective properties](/slides/ar/nodejs-java/shape-effective-properties/): تُعيد الـ API قيمًا محسوبة تأخذ في الاعتبار أنماط السمة، التخطيط، والإعدادات المحلية، مما يبسط تحليل التنسيق.