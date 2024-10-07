---
title: بيضاوي
type: docs
weight: 30
url: /androidjava/ellipse/
---

{{% alert color="primary" %}} 

في هذا الموضوع، سنقدم للمطورين كيفية إضافة أشكال بيضاوية إلى شرائحهم باستخدام Aspose.Slides لنظام Android عبر Java. يوفر Aspose.Slides لنظام Android عبر Java مجموعة أسهل من واجهات البرمجة لتصميم أنواع مختلفة من الأشكال مع بضع سطور من الشيفرة.

{{% /alert %}} 

## **إنشاء بيضاوي**
لإضافة بيضاوي بسيط إلى شريحة محددة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- الحصول على مرجع من الشريحة باستخدام فهرسها.
- إضافة AutoShape من نوع البيضاوي باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) المعروضة بواسطة كائن [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- كتابة العرض التقديمي المعدل كملف PPTX.

في المثال المذكور أدناه، قمنا بإضافة بيضاوي إلى الشريحة الأولى.

```java
// إنشاء مثيل من فئة Presentation التي تمثل ملف PPTX
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

## **إنشاء بيضاوي بتنسيق أفضل**
لإضافة بيضاوي بتنسيق أفضل إلى الشريحة، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- الحصول على مرجع من الشريحة باستخدام فهرسها.
- إضافة AutoShape من نوع البيضاوي باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) المعروضة بواسطة كائن [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- تعيين نوع التعبئة للبيضاوي إلى صلب.
- تعيين لون البيضاوي باستخدام خاصية SolidFillColor.Color المعروضة بواسطة كائن [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFillFormat) المرتبط بكائن [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape).
- تعيين لون خطوط البيضاوي.
- تعيين عرض خطوط البيضاوي.
- كتابة العرض التقديمي المعدل كملف PPTX.

في المثال المذكور أدناه، قمنا بإضافة بيضاوي بتنسيق إلى الشريحة الأولى من العرض التقديمي.

```java
// إنشاء مثيل من فئة Presentation التي تمثل ملف PPTX
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