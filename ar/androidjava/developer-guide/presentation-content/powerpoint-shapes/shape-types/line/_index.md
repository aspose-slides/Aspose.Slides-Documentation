---
title: إضافة أشكال الخط إلى العروض التقديمية على Android
linktitle: خط
type: docs
weight: 50
url: /ar/androidjava/Line/
keywords:
- خط
- إنشاء خط
- إضافة خط
- خط عادي
- تكوين الخط
- تخصيص الخط
- نمط الشرطية المتقطعة
- رأس السهم
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية تعديل تنسيق الخط في عروض PowerPoint التقديمية باستخدام Aspose.Slides for Android. اكتشف الخصائص والطرق وأمثلة Java."
---

{{% alert color="primary" %}} 

يدعم Aspose.Slides for Android عبر Java إضافة أنواع مختلفة من الأشكال إلى الشرائح. في هذا الموضوع، سنبدأ العمل مع الأشكال عن طريق إضافة خطوط إلى الشرائح. باستخدام Aspose.Slides for Android عبر Java، يمكن للمطورين ليس فقط إنشاء خطوط بسيطة، بل يمكن أيضًا رسم بعض الخطوط المتقنة على الشرائح.

{{% /alert %}} 

## **إنشاء خط عادي**

لإضافة خط عادي بسيط إلى شريحة محددة في العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء نسخة من الفئة [العرض التقديمي](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- الحصول على مرجع الشريحة باستخدام فهرسها.
- إضافة AutoShape من نوع Line باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) المعروضة في كائن [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- كتابة العرض التقديمي المعدل كملف PPTX.

في المثال المعطى أدناه، أضفنا خطًا إلى الشريحة الأولى من العرض التقديمي.
```java
// إنشاء كائن من فئة PresentationEx التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // إضافة AutoShape من النوع line
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // حفظ ملف PPTX إلى القرص
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إنشاء خط على شكل سهم**

يسمح Aspose.Slides for Android عبر Java أيضًا للمطورين بتكوين بعض خصائص الخط لجعله يبدو أكثر جاذبية. لنحاول تكوين بعض خصائص الخط لجعله يبدو كسهم. يرجى اتباع الخطوات أدناه للقيام بذلك:

- إنشاء نسخة من الفئة [العرض التقديمي](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- الحصول على مرجع الشريحة باستخدام فهرسها.
- إضافة AutoShape من نوع Line باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) المعروضة في كائن [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- تعيين [نمط الخط](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineStyle) إلى أحد الأنماط التي توفرها Aspose.Slides for Android عبر Java.
- تعيين عرض الخط.
- تعيين [نمط الشرطية المتقطعة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineDashStyle) للخط إلى أحد الأنماط المتاحة في Aspose.Slides for Android عبر Java.
- تعيين [نمط رأس السهم](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) و[الطول](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength) لنقطة البداية للخط.
- تعيين [نمط رأس السهم](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) و[الطول](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength) لنقطة النهاية للخط.
- كتابة العرض التقديمي المعدل كملف PPTX.
```java
// إنشاء كائن من فئة PresentationEx التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة AutoShape من النوع line
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


## **الأسئلة المتكررة**

**هل يمكنني تحويل خط عادي إلى موصل بحيث “ينغلق” على الأشكال؟**

لا. الخط العادي (وهو [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/) من النوع [Line](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/)) لا يتحول تلقائيًا إلى موصل. لجعله يلتقط الأشكال، استخدم النوع المخصص [Connector](https://reference.aspose.com/slides/androidjava/com.aspose.slides/connector/) و[واجهات برمجة التطبيقات المقابلة](/slides/ar/androidjava/connector/) للاتصالات.

**ماذا أفعل إذا كانت خصائص الخط موروثة من السمة وكان من الصعب تحديد القيم النهائية؟**

[اقرأ الخصائص الفعّالة](/slides/ar/androidjava/shape-effective-properties/) عبر واجهات [ILineFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilinefillformateffectivedata/)—هذه الواجهات تأخذ بالفعل في الاعتبار الوراثة وأنماط السمة.

**هل يمكنني قفل الخط ضد التعديل (النقل، تغيير الحجم)؟**

نعم. توفر الأشكال كائنات القفل [lock objects](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) التي تتيح لك [منع عمليات التحرير](/slides/ar/androidjava/applying-protection-to-presentation/).