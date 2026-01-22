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
- تكوين خط
- تخصيص خط
- نمط المتقطع
- رأس السهم
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية تعديل تنسيق الخط في عروض PowerPoint التقديمية باستخدام Aspose.Slides for Android. اكتشف الخصائص والأساليب وأمثلة Java."
---

{{% alert color="primary" %}} 

يدعم Aspose.Slides for Android via Java إضافة أنواع مختلفة من الأشكال إلى الشرائح. في هذا الموضوع، سنبدأ العمل مع الأشكال عن طريق إضافة خطوط إلى الشرائح. باستخدام Aspose.Slides for Android via Java، لا يستطيع المطورون إنشاء خطوط بسيطة فقط، بل يمكنهم أيضًا رسم خطوط مزخرفة على الشرائح.

{{% /alert %}} 

## **إنشاء خط عادي**

لإضافة خط عادي بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- احصل على مرجع الشريحة باستخدام الفهرس الخاص بها.
- أضف AutoShape من النوع Line باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) المعروضة بواسطة كائن [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- احفظ العرض التقديمي المعدل كملف PPTX.

في المثال الوارد أدناه، قمنا بإضافة خط إلى الشريحة الأولى من العرض التقديمي.
```java
// إنشاء فئة PresentationEx التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // احصل على الشريحة الأولى
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

يوفر Aspose.Slides for Android via Java أيضًا للمطورين القدرة على تكوين بعض خصائص الخط لجعله أكثر جاذبية. دعونا نجرب تكوين بعض خصائص الخط لجعله يبدو كسهم. يرجى اتباع الخطوات أدناه للقيام بذلك:

- إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- احصل على مرجع الشريحة باستخدام الفهرس الخاص بها.
- أضف AutoShape من النوع Line باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) المعروضة بواسطة كائن [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- حدد [Line Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineStyle) إلى أحد الأنماط المتاحة في Aspose.Slides for Android via Java.
- حدد عرض الخط.
- حدد [Dash Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineDashStyle) للخط إلى أحد الأنماط المتاحة في Aspose.Slides for Android via Java.
- حدد [Arrow Head Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) و[Length](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength) لنقطة البداية للخط.
- حدد [Arrow Head Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) و[Length](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength) لنقطة النهاية للخط.
- احفظ العرض التقديمي المعدل كملف PPTX.
```java
// إنشاء فئة PresentationEx التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // احصل على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة AutoShape من النوع خط
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // تطبيق بعض التنسيق على الخط
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

**هل يمكنني تحويل خط عادي إلى موصل بحيث "يلتصق" بالأشكال؟**

لا. الخط العادي (‏[AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/) من النوع [Line](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/)) لا يتحول تلقائيًا إلى موصل. لجعله يلتصق بالأشكال، استخدم النوع المخصص [Connector](https://reference.aspose.com/slides/androidjava/com.aspose.slides/connector/) والـ[APIs المقابلة](/slides/ar/androidjava/connector/) للاتصالات.

**ماذا أفعل إذا كانت خصائص الخط مُورثة من السمة ويصعب تحديد القيم النهائية؟**

[قراءة الخصائص الفعالة](/slides/ar/androidjava/shape-effective-properties/) عبر واجهات [ILineFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilinefillformateffectivedata/) — هذه الواجهات تأخذ بالفعل في الاعتبار الوراثة وأساليب السمة.

**هل يمكنني قفل خط لمنع التحرير (النقل، تغيير الحجم)؟**

نعم. توفر الأشكال [lock objects](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) التي تسمح لك بمنع عمليات التحرير.