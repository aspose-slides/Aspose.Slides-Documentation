---
title: إضافة أشكال خطوط إلى العروض التقديمية على Android
linktitle: خط
type: docs
weight: 50
url: /ar/androidjava/line/
keywords:
- خط
- إنشاء خط
- إضافة خط
- خط عادي
- تهيئة الخط
- تخصيص الخط
- نمط الخط المتقطع
- رأس السهم
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية معالجة تنسيق الخطوط في عروض PowerPoint التقديمية باستخدام Aspose.Slides for Android. اكتشف الخصائص والطرق وأمثلة Java."
---
## **نظرة عامة**

تسمح لك Aspose.Slides بإضافة أشكال خطوط إلى شرائح PowerPoint برمجياً. يوضح هذا المقال كيفية إنشاء خط بسيط وكيفية تخصيص الخط ليظهر كسهم.

ستتعلم كيفية إضافة شكل خط إلى شريحة، وضبط مظهره البصري، وحفظ العرض المحدث. تركّز الأمثلة على إعدادات تنسيق الخط العملية مثل النمط، العرض، نمط الخط المتقطع، خيارات رأس السهم، ولون التعبئة.

## **إنشاء خط عادي**

لإضافة خط عادي بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation) .
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من نوع Line باستخدام الطريقة [addAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) التي يوفرها كائن [IShapeCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IShapeCollection) .
- كتابة العرض المعدل كملف PPTX.

في المثال أدناه، قمنا بإضافة خط إلى الشريحة الأولى من العرض التقديمي.

```java
// إنشاء الفئة PresentationEx التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // إضافة AutoShape من النوع خط
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // كتابة ملف PPTX إلى القرص
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إنشاء خط على شكل سهم**

تسمح Aspose.Slides for Android via Java أيضاً للمطورين بتكوين بعض خصائص الخط لجعله أكثر جاذبية. لنحاول تكوين بعض الخصائص للخط لجعله يبدو كسهم. يرجى اتباع الخطوات أدناه للقيام بذلك:

- إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation) .
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من نوع Line باستخدام الطريقة [addAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) التي يوفرها كائن [IShapeCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IShapeCollection) .
- تعيين [Line Style](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/LineStyle) إلى أحد الأنماط المتوفرة في Aspose.Slides for Android via Java.
- تعيين عرض الخط.
- تعيين [Dash Style](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/LineDashStyle) للخط إلى أحد الأنماط المتوفرة في Aspose.Slides for Android via Java.
- تعيين [Arrow Head Style](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/LineArrowheadStyle) و[Length](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/LineArrowheadLength) لنقطة البداية للخط.
- تعيين [Arrow Head Style](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/LineArrowheadStyle) و[Length](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/LineArrowheadLength) لنقطة النهاية للخط.
- كتابة العرض المعدل كملف PPTX.

```java
// إنشاء فئة PresentationEx التي تمثل ملف PPTX
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

    // كتابة ملف PPTX إلى القرص
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الأسئلة المتكررة**

**هل يمكنني تحويل خط عادي إلى موصل بحيث "يلتقط" الأشكال؟**

لا. الخط العادي (وهو [AutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/autoshape/) من النوع [Line](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/shapetype/)) لا يتحول تلقائياً إلى موصل. لجعله يلتقط الأشكال، استخدم النوع المخصص [Connector](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/connector/) والـ[APIs المقابلة](/slides/ar/androidjava/connector/) للاتصالات.

**ماذا أفعل إذا كانت خصائص الخط موروثة من السمة ويصعب تحديد القيم النهائية؟**

اقرأ الخصائص الفعّالة عبر [ILineFormatEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilinefillformateffectivedata/) — هذه الواجهات تأخذ بالفعل في الاعتبار الوراثة وأنماط السمة.

**هل يمكنني قفل الخط لمنع التعديلات (النقل، تغيير الحجم)؟**

نعم. توفر الأشكال كائنات [lock objects](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) التي تتيح لك منع عمليات التحرير.