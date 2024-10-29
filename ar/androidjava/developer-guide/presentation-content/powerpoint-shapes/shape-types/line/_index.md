---
title: خط
type: docs
weight: 50
url: /ar/androidjava/Line/
---


{{% alert color="primary" %}} 

Aspose.Slides لنظام Android عبر Java يدعم إضافة أنواع مختلفة من الأشكال إلى الشرائح. في هذا الموضوع، سنبدأ العمل مع الأشكال عن طريق إضافة خطوط إلى الشرائح. باستخدام Aspose.Slides لنظام Android عبر Java، يمكن للمطورين ليس فقط إنشاء خطوط بسيطة، ولكن يمكن أيضًا رسم بعض الخطوط المميزة على الشرائح.

{{% /alert %}} 

## **إنشاء خط عادي**

لإضافة خط بسيط عادي إلى شريحة محددة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- الحصول على مرجع شريحة باستخدام فهرسها.
- إضافة شكل أوتوماتيكي من نوع خط باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) المعروضة بواسطة كائن [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- كتابة العرض التقديمي المعدل كملف PPTX.

في المثال المقدم أدناه، أضفنا خطًا إلى الشريحة الأولى من العرض التقديمي.

```java
// إنشاء مثيل لفئة PresentationEx التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // إضافة شكل أوتوماتيكي من نوع خط
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // كتابة PPTX إلى القرص
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إنشاء خط بشكل سهم**

Aspose.Slides لنظام Android عبر Java يتيح أيضًا للمطورين تكوين بعض خصائص الخط لجعله يبدو أكثر جاذبية. دعونا نحاول تكوين بعض خصائص الخط لجعله يبدو مثل سهم. يرجى اتباع الخطوات أدناه للقيام بذلك:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- الحصول على مرجع شريحة باستخدام فهرسها.
- إضافة شكل أوتوماتيكي من نوع خط باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) المعروضة بواسطة كائن [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- تعيين [نمط الخط](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineStyle) إلى أحد الأنماط كما هو موضح من قبل Aspose.Slides لنظام Android عبر Java.
- تعيين عرض الخط.
- تعيين [نمط النقاط المتقطعة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineDashStyle) للخط إلى أحد الأنماط المُقدمة من قبل Aspose.Slides لنظام Android عبر Java.
- تعيين [نمط رأس السهم](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) و[الطول](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength) لنقطة بداية الخط.
- تعيين [نمط رأس السهم](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) و[الطول](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength) لنقطة نهاية الخط.
- كتابة العرض التقديمي المعدل كملف PPTX.

```java
// إنشاء مثيل لفئة PresentationEx التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة شكل أوتوماتيكي من نوع خط
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // تطبيق بعض التنسيقات على الخط
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // كتابة PPTX إلى القرص
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```