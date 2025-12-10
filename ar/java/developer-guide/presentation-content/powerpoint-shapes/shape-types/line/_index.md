---
title: إضافة أشكال الخطوط إلى العروض التقديمية في Java
linktitle: خط
type: docs
weight: 50
url: /ar/java/Line/
keywords:
- خط
- إنشاء خط
- إضافة خط
- خط بسيط
- تكوين الخط
- تخصيص الخط
- نمط متقطع
- رأس السهم
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية معالجة تنسيق الخطوط في عروض PowerPoint التقديمية باستخدام Aspose.Slides for Java. اكتشف الخصائص والطرق والأمثلة."
---

{{% alert color="primary" %}} 
يدعم Aspose.Slides for Java إضافة أشكال مختلفة إلى الشرائح. في هذا الموضوع، سنبدأ العمل مع الأشكال عن طريق إضافة خطوط إلى الشرائح. باستخدام Aspose.Slides for Java، يمكن للمطورين إنشاء خطوط بسيطة فقط، بل يمكن أيضًا رسم خطوط مزينة على الشرائح.
{{% /alert %}} 

## **إنشاء خط بسيط**

لإضافة خط بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
- الحصول على مرجع شريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من نوع Line باستخدام الطريقة [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) المعروضة بواسطة كائن [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) .
- حفظ العرض التقديمي المعدل كملف PPTX.

في المثال الموضح أدناه، قمنا بإضافة خط إلى الشريحة الأولى من العرض التقديمي.
```java
// إنشاء كائن من الفئة PresentationEx التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // إضافة AutoShape من النوع خط
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // حفظ ملف PPTX على القرص
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إنشاء خط على شكل سهم**

يسمح Aspose.Slides for Java أيضًا للمطورين بتكوين بعض خصائص الخط لجعله أكثر جاذبية. دعونا نجرب ضبط بعض خصائص الخط لجعله يبدو كسهم. يرجى اتباع الخطوات أدناه للقيام بذلك:

- إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
- الحصول على مرجع شريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من نوع Line باستخدام الطريقة [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) المعروضة بواسطة كائن [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) .
- ضبط [Line Style](https://reference.aspose.com/slides/java/com.aspose.slides/LineStyle) إلى أحد الأنماط المتوفرة في Aspose.Slides for Java.
- ضبط عرض الخط.
- ضبط [Dash Style](https://reference.aspose.com/slides/java/com.aspose.slides/LineDashStyle) للخط إلى أحد الأنماط المتوفرة في Aspose.Slides for Java.
- ضبط [Arrow Head Style](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadStyle) و[Length](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadLength) لنقطة البداية للخط.
- ضبط [Arrow Head Style](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadStyle) و[Length](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadLength) لنقطة النهاية للخط.
- حفظ العرض التقديمي المعدل كملف PPTX.
```java
// إنشاء كائن من الفئة PresentationEx التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
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

    // حفظ ملف PPTX على القرص
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة الشائعة**

**هل يمكن تحويل خط عادي إلى موصل بحيث "يلصق" بالأشكال؟**

لا. الخط العادي (وهو [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/) من النوع [Line](https://reference.aspose.com/slides/java/com.aspose.slides/shapetype/)) لا يتحول تلقائيًا إلى موصل. لجعله يلتصق بالأشكال، استخدم النوع المخصص [Connector](https://reference.aspose.com/slides/java/com.aspose.slides/connector/) والـ[APIs المقابلة](/slides/ar/java/connector/) للاتصالات.

**ماذا أفعل إذا كانت خصائص الخط موروثة من السمة ويصعب تحديد القيم النهائية؟**

اقرأ الخصائص الفعالة [/slides/java/shape-effective-properties/] عبر الواجهات [ILineFormatEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ilinefillformateffectivedata/) — فإنها تأخذ بالفعل في الاعتبار الوراثة وأنماط السمة.

**هل يمكن قفل الخط ضد التحرير (النقل، تغيير الحجم)؟**

نعم. توفر الأشكال [كائنات القفل](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/#getAutoShapeLock--) التي تسمح لك [بمنع عمليات التحرير](/slides/ar/java/applying-protection-to-presentation/).