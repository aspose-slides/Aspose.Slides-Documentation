---
title: مستطيل
type: docs
weight: 80
url: /java/rectangle/
---

{{% alert color="primary" %}} 

مثل المواضيع السابقة، هذا الموضوع أيضًا يتناول إضافة شكل هذه المرة الشكل الذي سنتحدث عنه هو **مستطيل**. في هذا الموضوع، وصفنا كيفية إضافة المطورين لمستطيلات بسيطة أو منسقة إلى الشرائح الخاصة بهم باستخدام Aspose.Slides لـ Java.

{{% /alert %}} 

## **إضافة مستطيل إلى الشريحة**
لإضافة مستطيل بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات التالية:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- الحصول على مرجع الشريحة باستخدام مؤشرها.
- إضافة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) من نوع المستطيل باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) التي يتم عرضها بواسطة كائن [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- كتابة العرض التقديمي المعدل كملف PPTX.

في المثال المعطى أدناه، أضفنا مستطيلًا بسيطًا إلى الشريحة الأولى من العرض التقديمي.

```java
// Instantiate Prseetation class that represents the PPTX
Presentation pres = new Presentation();
try {
    // Get the first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Add AutoShape of ellipse type
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Write the PPTX file to disk
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إضافة مستطيل منسق إلى الشريحة**
لإضافة مستطيل منسق إلى شريحة، يرجى اتباع الخطوات التالية:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- الحصول على مرجع الشريحة باستخدام مؤشرها.
- إضافة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) من نوع المستطيل باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) التي يتم عرضها بواسطة كائن [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- تعيين [نوع الملء](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) للمستطيل إلى صلب.
- تعيين لون المستطيل باستخدام طريقة [SolidFillColor.setColor](https://reference.aspose.com/slides/java/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) كما هو موضح بواسطة كائن [IFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IFillFormat) المرتبط بكائن [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape).
- تعيين لون خطوط المستطيل.
- تعيين عرض خطوط المستطيل.
- كتابة العرض التقديمي المعدل كملف PPTX.

تتم تطبيق الخطوات أعلاه في المثال المعطى أدناه.

```java
// Instantiate Prseetation class that represents the PPTX
Presentation pres = new Presentation();
try {
    // Get the first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Add AutoShape of ellipse type
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Apply some formatting to ellipse shape
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // Apply some formatting to the line of Ellipse
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Write the PPTX file to disk
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```