---
title: خط
type: docs
weight: 50
url: /ar/java/Line/
---


{{% alert color="primary" %}} 

Aspose.Slides لـ Java يدعم إضافة أشكال مختلفة إلى الشرائح. في هذا الموضوع، سنبدأ العمل مع الأشكال عن طريق إضافة خطوط إلى الشرائح. باستخدام Aspose.Slides لـ Java، يمكن للمطورين إنشاء خطوط بسيطة، ولكن يمكن أيضًا رسم بعض الخطوط الجميلة على الشرائح.

{{% /alert %}} 

## **إنشاء خط عادي**

لإضافة خط عادي بسيط إلى شريحة محددة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- الحصول على مرجع شريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من نوع الخط باستخدام [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) method الذي يتم الكشف عنه بواسطة [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) object.
- كتابة العرض التقديمي المعدل كملف PPTX.

في المثال المقدم أدناه، أضفنا خطًا إلى الشريحة الأولى من العرض التقديمي.

```java
// Instantiate PresentationEx class that represents the PPTX file
Presentation pres = new Presentation();
try {
    // Get the first slide
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Add an AutoShape of type line
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Write the PPTX to Disk
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إنشاء خط على شكل سهم**

Aspose.Slides لـ Java يسمح أيضًا للمطورين بتكوين بعض خصائص الخط لجعله يبدو أكثر جاذبية. دعنا نحاول تكوين بعض خصائص الخط لجعله يبدو كأنه سهم. يرجى متابعة الخطوات أدناه للقيام بذلك:

- إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- الحصول على مرجع شريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من نوع الخط باستخدام [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) method الذي يتم الكشف عنه بواسطة [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) object.
- تعيين [أسلوب الخط](https://reference.aspose.com/slides/java/com.aspose.slides/LineStyle) لأحد الأنماط المعروضة بواسطة Aspose.Slides لـ Java.
- تعيين عرض الخط.
- تعيين [أسلوب النمط المتقطع](https://reference.aspose.com/slides/java/com.aspose.slides/LineDashStyle) للخط لأحد الأنماط المعروضة بواسطة Aspose.Slides لـ Java.
- تعيين [أسلوب رأس السهم](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadStyle) و[طول](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadLength) نقطة البداية للخط.
- تعيين [أسلوب رأس السهم](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadStyle) و[طول](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadLength) نقطة النهاية للخط.
- كتابة العرض التقديمي المعدل كملف PPTX.

```java
// Instantiate PresentationEx class that represents the PPTX file
Presentation pres = new Presentation();
try {
    // Get the first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Add an AutoShape of type line
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Apply some formatting on the line
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // Write the PPTX to Disk
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```