---
title: مستطيل
type: docs
weight: 80
url: /ar/androidjava/rectangle/
---

{{% alert color="primary" %}} 

مثل المواضيع السابقة، يتناول هذا الموضوع أيضًا إضافة شكل وفي هذه المرة الشكل الذي سنناقشه هو **مستطيل**. في هذا الموضوع، وصفنا كيف يمكن للمطورين إضافة مستطيلات بسيطة أو منسقة إلى شرائحهم باستخدام Aspose.Slides لنظام Android عبر Java.

{{% /alert %}} 

## **إضافة مستطيل إلى الشريحة**
لإضافة مستطيل بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

- أنشئ مثيلًا من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) class.
- احصل على مرجع شريحة باستخدام فهرسها.
- أضف [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) من نوع المستطيل باستخدام [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) method المعروض بواسطة [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) object.
- قم بكتابة العرض التقديمي المعدل كملف PPTX.

في المثال المقدم أدناه، أضفنا مستطيلًا بسيطًا إلى الشريحة الأولى من العرض التقديمي.

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
لإضافة مستطيل منسق إلى شريحة، يرجى اتباع الخطوات أدناه:

- أنشئ مثيلًا من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) class.
- احصل على مرجع شريحة باستخدام فهرسها.
- أضف [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) من نوع المستطيل باستخدام [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) method المعروض بواسطة [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) object.
- تعيين [Fill Type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) للمستطيل إلى Solid.
- تعيين لون المستطيل باستخدام [SolidFillColor.setColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) method كما تم عرضه بواسطة [IFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFillFormat) object المرتبط بـ [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) object.
- تعيين لون خطوط المستطيل.
- تعيين عرض خطوط المستطيل.
- قم بكتابة العرض التقديمي المعدل كملف PPTX.

يتم تنفيذ الخطوات المذكورة أعلاه في المثال المقدم أدناه.

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