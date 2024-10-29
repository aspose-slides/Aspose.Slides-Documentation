---
title: بيضاوي
type: docs
weight: 30
url: /ar/java/ellipse/
---

{{% alert color="primary" %}} 

في هذا الموضوع، سوف نقدم للمطورين كيفية إضافة أشكال البيضاوي إلى شرائحهم باستخدام Aspose.Slides لـ Java. توفر Aspose.Slides لـ Java مجموعة أسهل من واجهات برمجة التطبيقات لرسم أشكال مختلفة بعدد قليل من أسطر التعليمات البرمجية.

{{% /alert %}} 

## **إنشاء بيضاوي**
لإضافة بيضاوي بسيط إلى شريحة محددة من العرض التقديمي، يُرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- الحصول على مرجع لشريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من نوع بيضاوي باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) التي يوفرها كائن [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- كتابة العرض التقديمي المعدل كملف PPTX.

في المثال المقدم أدناه، قمنا بإضافة بيضاوي إلى الشريحة الأولى

```java
// إنشاء مثيل من فئة Presentation التي تمثل PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // إضافة AutoShape من نوع البيضاوي
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // كتابة ملف PPTX إلى القرص
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إنشاء بيضاوي مُنسق**
لإضافة بيضاوي أفضل تنسيقًا إلى شريحة، يُرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- الحصول على مرجع لشريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من نوع بيضاوي باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) التي يوفرها كائن [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- ضبط نوع التعبئة للبيضاوي إلى صلب.
- ضبط لون البيضاوي باستخدام خاصية SolidFillColor.Color المقدمة من كائن [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IFillFormat) المرتبط بكائن [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape).
- ضبط لون خطوط البيضاوي.
- ضبط عرض خطوط البيضاوي.
- كتابة العرض التقديمي المعدل كملف PPTX.

في المثال المقدم أدناه، قمنا بإضافة بيضاوي مُنسق إلى الشريحة الأولى من العرض التقديمي.

```java
// إنشاء مثيل من فئة Presentation التي تمثل PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة AutoShape من نوع البيضاوي
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // تطبيق بعض التنسيق على شكل البيضاوي
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // تطبيق بعض التنسيق على خط البيضاوي
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // كتابة ملف PPTX إلى القرص
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```