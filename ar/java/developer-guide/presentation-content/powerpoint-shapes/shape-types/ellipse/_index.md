---
title: إضافة أشكال إهليلجية إلى العروض التقديمية في Java
linktitle: إهليلج
type: docs
weight: 30
url: /ar/java/ellipse/
keywords:
- إهليلج
- شكل
- إضافة إهليلج
- إنشاء إهليلج
- رسم إهليلج
- إهليلج منسق
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية إنشاء وتنسيق والتعامل مع أشكال الإهليلج في Aspose.Slides for Java عبر عروض PPT و PPTX — تشمل أمثلة كود Java."
---

{{% alert color="primary" %}} 

في هذا الموضوع، سنُعرّف المطورين عن إضافة أشكال إهليلجية إلى الشرائح باستخدام Aspose.Slides for Java. توفر Aspose.Slides for Java مجموعة أسهل من واجهات برمجة التطبيقات لرسم أنواع مختلفة من الأشكال ببضع أسطر من الشيفرة.

{{% /alert %}} 

## **إنشاء إهليلج**
لإضافة إهليلج بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات التالية:

- إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) .
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من نوع Ellipse باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) المُعرّفة في كائن [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) .
- كتابة العرض التقديمي المعدّل كملف PPTX.

في المثال أدناه، قمنا بإضافة إهليلج إلى الشريحة الأولى
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // إضافة AutoShape من النوع إهليلج
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // حفظ ملف PPTX على القرص
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إنشاء إهليلج منسق**
لإضافة إهليلج منسق إلى شريحة، يرجى اتباع الخطوات التالية:

- إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) .
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها .
- إضافة AutoShape من نوع Ellipse باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) المُعرّفة في كائن [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) .
- تعيين نوع التعبئة للـ إهليلج إلى صلبة.
- تعيين لون الإهليلج باستخدام الخاصية SolidFillColor.Color كما هو مُعرّف في كائن [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IFillFormat) المرتبط بكائن [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) .
- تعيين لون خطوط الإهليلج.
- تعيين عرض خطوط الإهليلج.
- كتابة العرض التقديمي المعدّل كملف PPTX.

في المثال أدناه، قمنا بإضافة إهليلج منسق إلى الشريحة الأولى من العرض التقديمي.
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة AutoShape من نوع إهليلج
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // تطبيق بعض التنسيقات على شكل الإهليلج
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // تطبيق بعض التنسيقات على خط الإهليلج
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // حفظ ملف PPTX على القرص
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة الشائعة**

**كيف يمكنني تعيين الموضع الدقيق وحجم الإهليلج بالنسبة إلى وحدات الشريحة؟**

عادةً ما يتم تحديد الإحداثيات والأحجام **بالنقاط**. للحصول على نتائج متوقعة، قم بحساباتك بناءً على حجم الشريحة وحوّل المليمترات أو البوصات المطلوبة إلى نقاط قبل تعيين القيم.

**كيف يمكنني وضع إهليلج فوق أو تحت كائنات أخرى (التحكم في ترتيب التراص)؟**

عدّل ترتيب الرسم للكائن عن طريق إرساله إلى الأمام أو إلى الخلف. هذا يتيح للإهليلج أن يتقاطع مع كائنات أخرى أو يكشف ما تحتها.

**كيف يمكنني تحريك ظهور أو إبراز إهليلج؟**

استخدم [Apply](/slides/ar/java/shape-animation/) لتطبيق تأثيرات الدخول أو التأكيد أو الخروج على الشكل، وقم بتكوين المشغلات والتوقيت لتنسيق متى وكيف تُجرى الرسوم المتحركة.