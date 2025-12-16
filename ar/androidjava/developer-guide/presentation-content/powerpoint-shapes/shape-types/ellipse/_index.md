---
title: إضافة أشكال إهليلجية إلى العروض التقديمية على نظام Android
linktitle: إهليلج
type: docs
weight: 30
url: /ar/androidjava/ellipse/
keywords:
- إهليلج
- شكل
- إضافة إهليلج
- إنشاء إهليلج
- رسم إهليلج
- إهليلج منسق
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية إنشاء وتنسيق ومعالجة أشكال الإهليلج في Aspose.Slides لنظام Android عبر عروض PPT و PPTX — تشمل أمثلة شفرة Java."
---

{{% alert color="primary" %}} 

في هذا الموضوع، سنعرف المطورين على إضافة أشكال إهليلجية إلى شرائحهم باستخدام Aspose.Slides for Android via Java. Aspose.Slides for Android via Java يوفر مجموعة أسهل من واجهات برمجة التطبيقات لرسم أنواع مختلفة من الأشكال ببضع أسطر من الكود فقط.

{{% /alert %}} 

## **إنشاء إهليلج**
لإضافة إهليلج بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) .
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من نوع إهليلج باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) المعروضة بواسطة كائن [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) .
- حفظ العرض التقديمي المعدل كملف PPTX.

في المثال المقدم أدناه، أضفنا إهليلجًا إلى الشريحة الأولى
```java
// إنشاء كائن Presentation الذي يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // إضافة AutoShape من نوع إهليلجي
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // كتابة ملف PPTX إلى القرص
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إنشاء إهليلج مُنسق**
لإضافة إهليلج مُنسق بشكل أفضل إلى شريحة، يرجى اتباع الخطوات أدناه:

- إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) .
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من نوع إهليلج باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) المعروضة بواسطة كائن [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) .
- تعيين نوع التعبئة للإهليلج إلى صلبة.
- تعيين لون الإهليلج باستخدام الخاصية SolidFillColor.Color كما هو معروض في كائن [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFillFormat) المرتبط بكائن [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) .
- تعيين لون خطوط الإهليلج.
- تعيين عرض خطوط الإهليلج.
- حفظ العرض التقديمي المعدل كملف PPTX.

في المثال المقدم أدناه، أضفنا إهليلجًا مُنسقًا إلى الشريحة الأولى من العرض التقديمي.
```java
// إنشاء كائن فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة AutoShape من نوع إهليلج
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // تطبيق بعض التنسيق على شكل الإهليلج
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // تطبيق بعض التنسيق على حد الإهليلج
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // كتابة ملف PPTX إلى القرص
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة المتكررة**

**كيف يمكنني ضبط الموضع الدقيق وحجم الإهليلج بالنسبة إلى وحدات الشريحة؟**

عادةً ما يتم تحديد الإحداثيات والأحجام **بالنقاط**. للحصول على نتائج متوقعة، قم بحساباتك بناءً على حجم الشريحة وحول المليمترات أو البوصات المطلوبة إلى نقاط قبل تعيين القيم.

**كيف يمكنني وضع إهليلج فوق أو تحت عناصر أخرى (التحكم في ترتيب التراكب)؟**

قم بضبط ترتيب رسم العنصر عن طريق إحضاره إلى المقدمة أو إرساله إلى الخلف. هذا يسمح للإهليلج بتراكب العناصر الأخرى أو إظهار ما هو تحتها.

**كيف أقوم بتحريك ظهور أو إبراز الإهليلج؟**

[Apply](/slides/ar/androidjava/shape-animation/) تأثيرات الدخول أو الإبراز أو الخروج على الشكل، وتكوين المشغلات والتوقيت لتحديد متى وكيفية تشغيل الرسوم المتحركة.