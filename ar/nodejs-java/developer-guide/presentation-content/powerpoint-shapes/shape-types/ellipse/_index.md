---
title: إهليلج
type: docs
weight: 30
url: /ar/nodejs-java/ellipse/
---

{{% alert color="primary" %}} 

في هذا الموضوع، سنقدم للمطورين طريقة إضافة أشكال إهليلجية إلى الشرائح باستخدام Aspose.Slides for Node.js via Java. يوفر Aspose.Slides for Node.js via Java مجموعة أسهل من واجهات برمجة التطبيقات لرسم أنواع مختلفة من الأشكال ببضع أسطر من الشيفرة فقط.

{{% /alert %}} 

## **إنشاء إهليلج**
لإضافة إهليلج بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) .
- الحصول على مرجع شريحة باستخدام فهرسها.
- إضافة AutoShape من نوع Ellipse باستخدام الطريقة [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) التي توفرها كائن [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) .
- كتابة العرض التقديمي المعدل كملف PPTX.

في المثال المذكور أدناه، قمنا بإضافة إهليلج إلى الشريحة الأولى
```javascript
// إنشاء كائن من الفئة Presentation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // إضافة AutoShape من نوع Ellipse
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // كتابة ملف PPTX إلى القرص
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إنشاء إهليلج مُنسق**
لإضافة إهليلج منسق بشكل أفضل إلى شريحة، يرجى اتباع الخطوات أدناه:

- إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) .
- الحصول على مرجع شريحة باستخدام فهرسها.
- إضافة AutoShape من نوع Ellipse باستخدام الطريقة [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) التي توفرها كائن [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) .
- ضبط نوع تعبئة الإهليلج إلى Solid.
- ضبط لون الإهليلج باستخدام الخاصية SolidFillColor.Color التي يوفرها كائن [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillFormat) المرتبط بكائن [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) .
- ضبط لون خطوط الإهليلج.
- ضبط عرض خطوط الإهليلج.
- كتابة العرض التقديمي المعدل كملف PPTX.

في المثال المذكور أدناه، قمنا بإضافة إهليلج مُنسق إلى الشريحة الأولى من العرض التقديمي.
```javascript
// إنشاء مثيل لفئة Presentation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // إضافة AutoShape من نوع Ellipse
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // تطبيق بعض التنسيقات على شكل الإهليلج
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Chocolate));
    // تطبيق بعض التنسيقات على خط الإهليلج
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // كتابة ملف PPTX إلى القرص
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

 
## **الأسئلة الشائعة**

**كيف يمكنني تعيين الموضع والحجم الدقيقين لإهليلج بالنسبة لوحدات الشريحة؟**

عادةً ما يتم تحديد الإحداثيات والأحجام **in points**. للحصول على نتائج متوقعة، اعتمد حساباتك على حجم الشريحة وحوِّل المليمترات أو الإنشات المطلوبة إلى نقاط قبل تعيين القيم.

**كيف يمكنني وضع إهليلج فوق أو تحت كائنات أخرى (التحكم بترتيب الطبقات)؟**

قم بضبط ترتيب الرسم للكائن عن طريق إحضاره إلى الأمام أو إرساله إلى الخلف. يتيح هذا للإهليلج أن يتراكب مع كائنات أخرى أو أن يكشف ما هو تحتها.

**كيف يمكنني تحريك ظهور أو إبراز إهليلج؟**

[تطبيق](/slides/ar/nodejs-java/shape-animation/) تأثيرات الدخول أو التأكيد أو الخروج على الشكل، وقم بتكوين المشغلات والتوقيت لتحديد متى وكيف يتم تشغيل الرسوم المتحركة.