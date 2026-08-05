---
title: إضافة أشكال الخط إلى العروض التقديمية في Java
linktitle: الخط
type: docs
weight: 50
url: /ar/java/line/
keywords:
- خط
- إنشاء خط
- إضافة خط
- خط عادي
- تكوين خط
- تخصيص خط
- نمط المتقطع
- رأس السهم
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية تعديل تنسيق الخط في عروض PowerPoint التقديمية باستخدام Aspose.Slides for Java. اكتشف الخصائص والطرق والأمثلة."
---
## **نظرة عامة**

Aspose.Slides يتيح لك إضافة أشكال الخط إلى شرائح PowerPoint برمجيًا. يوضح هذا المقال كيفية إنشاء خط بسيط وكيفية تخصيص الخط ليظهر كسهم.

ستتعلم كيفية إضافة شكل خط إلى شريحة، وضبط مظهره البصري، وحفظ العرض المحدث. تركز الأمثلة على إعدادات تنسيق الخط العملية مثل النمط، العرض، نمط النقاط المتقطعة، خيارات رأس السهم، ولون التعبئة.

## **إنشاء خط عادي**

لإضافة خط عادي بسيط إلى شريحة محددة في العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء نسخة من صنف [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation).
- الحصول على مرجع الشريحة باستخدام فهرسها.
- إضافة AutoShape من نوع Line باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) المعروضة في كائن [IShapeCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IShapeCollection).
- حفظ العرض المعدل كملف PPTX.

في المثال أدناه، قمنا بإضافة خط إلى الشريحة الأولى من العرض التقديمي.

```java
// إنشاء كلاس PresentationEx الذي يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // إضافة AutoShape من النوع خط
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // حفظ ملف PPTX إلى القرص
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إنشاء خط على شكل سهم**

Aspose.Slides for Java يتيح أيضًا للمطورين ضبط بعض خصائص الخط لجعله أكثر جاذبية. لنحاول ضبط بعض الخصائص للخط ليظهر كسهم. يرجى اتباع الخطوات أدناه:

- إنشاء نسخة من صنف [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation).
- الحصول على مرجع الشريحة باستخدام فهرسها.
- إضافة AutoShape من نوع Line باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) المعروضة في كائن [IShapeCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IShapeCollection).
- تعيين [Line Style](https://reference.aspose.com/slides/ar/java/com.aspose.slides/LineStyle) إلى أحد الأنماط المتوفرة في Aspose.Slides for Java.
- تعيين عرض الخط.
- تعيين [Dash Style](https://reference.aspose.com/slides/ar/java/com.aspose.slides/LineDashStyle) للخط إلى أحد الأنماط المتوفرة في Aspose.Slides for Java.
- تعيين [Arrow Head Style](https://reference.aspose.com/slides/ar/java/com.aspose.slides/LineArrowheadStyle) و[Length](https://reference.aspose.com/slides/ar/java/com.aspose.slides/LineArrowheadLength) لنقطة البداية للخط.
- تعيين [Arrow Head Style](https://reference.aspose.com/slides/ar/java/com.aspose.slides/LineArrowheadStyle) و[Length](https://reference.aspose.com/slides/ar/java/com.aspose.slides/LineArrowheadLength) لنقطة النهاية للخط.
- حفظ العرض المعدل كملف PPTX.

```java
// إنشاء كلاس PresentationEx الذي يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة AutoShape من النوع خط
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

    // حفظ ملف PPTX إلى القرص
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الأسئلة الشائعة**

**هل يمكنني تحويل خط عادي إلى موصل بحيث "يندمج" مع الأشكال؟**

لا. الخط العادي (وهو [AutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/autoshape/) من النوع [Line](https://reference.aspose.com/slides/ar/java/com.aspose.slides/shapetype/)) لا يتحول تلقائيًا إلى موصل. لجعل الخط يندمج مع الأشكال، استخدم نوع [Connector](https://reference.aspose.com/slides/ar/java/com.aspose.slides/connector/) المتخصص و[واجهات برمجة التطبيقات المقابلة](/slides/ar/java/connector/) للاتصالات.

**ماذا أفعل إذا كانت خصائص الخط موروثة من السمة ومن الصعب تحديد القيم النهائية؟**

اقرأ [الخصائص الفعّالة](/slides/ar/java/shape-effective-properties/) عبر واجهات [ILineFormatEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilinefillformateffectivedata/) — هذه الواجهات تأخذ في الاعتبار الوراثة وأنماط السمة بالفعل.

**هل يمكنني قفل الخط لمنع التعديل (النقل، تغيير الحجم)؟**

نعم. توفر الأشكال [قفل الكائنات](https://reference.aspose.com/slides/ar/java/com.aspose.slides/autoshape/#getAutoShapeLock--) التي تسمح لك بـ[منع عمليات التعديل](/slides/ar/java/applying-protection-to-presentation/).