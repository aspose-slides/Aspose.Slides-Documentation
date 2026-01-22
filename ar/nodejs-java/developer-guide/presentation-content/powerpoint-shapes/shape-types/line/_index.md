---
title: إضافة أشكال الخط إلى العروض التقديمية في JavaScript
linktitle: خط
type: docs
weight: 50
url: /ar/nodejs-java/line/
keywords:
- خط
- إنشاء خط
- إضافة خط
- خط بسيط
- تكوين خط
- تخصيص خط
- نمط متقطع
- رأس السهم
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية تعديل تنسيق الخط في عروض PowerPoint باستخدام JavaScript وAspose.Slides لـ Node.js. اكتشف الخصائص والطرق والأمثلة."
---

{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java يدعم إضافة أنواع مختلفة من الأشكال إلى الشرائح. في هذا الموضوع، سنبدأ العمل مع الأشكال عن طريق إضافة خطوط إلى الشرائح. باستخدام Aspose.Slides for Node.js via Java، يمكن للمطورين ليس فقط إنشاء خطوط بسيطة، بل أيضًا رسم خطوط مزخرفة على الشرائح.

{{% /alert %}} 

## **إنشاء خط بسيط**

لإضافة خط بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من نوع خط باستخدام الطريقة [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) المعروضة بواسطة كائن [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) .
- كتابة العرض التقديمي المعدل كملف PPTX.

في المثال المذكور أدناه، أضفنا خطًا إلى الشريحة الأولى من العرض التقديمي.
```javascript
// إنشاء كائن من الفئة PresentationEx التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // إضافة AutoShape من النوع خط
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // حفظ ملف PPTX إلى القرص
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إنشاء خط على شكل سهم**

Aspose.Slides for Node.js via Java يسمح أيضًا للمطورين بتكوين بعض خصائص الخط لجعله أكثر جاذبية. دعونا نجرب تكوين بعض الخصائص للخط لجعله يبدو كسهم. يرجى اتباع الخطوات أدناه للقيام بذلك:

- إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من نوع خط باستخدام الطريقة [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) المعروضة بواسطة كائن [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) .
- تعيين [Line Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineStyle) إلى أحد الأنماط المتاحة من قبل Aspose.Slides for Node.js via Java.
- تعيين عرض الخط.
- تعيين [Dash Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineDashStyle) للخط إلى أحد الأنماط المتاحة من قبل Aspose.Slides for Node.js via Java.
- تعيين [Arrow Head Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadStyle) و[Length](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadLength) لنقطة البداية للخط.
- تعيين [Arrow Head Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadStyle) و[Length](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadLength) لنقطة النهاية للخط.
- كتابة العرض التقديمي المعدل كملف PPTX.
```javascript
// إنشاء كائن من الفئة PresentationEx التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // إضافة AutoShape من النوع خط
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // تطبيق بعض التنسيقات على الخط
    shp.getLineFormat().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);
    shp.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    shp.getLineFormat().setBeginArrowheadLength(aspose.slides.LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(aspose.slides.LineArrowheadStyle.Oval);
    shp.getLineFormat().setEndArrowheadLength(aspose.slides.LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Maroon));
    // حفظ ملف PPTX إلى القرص
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة المتكررة**

**هل يمكنني تحويل خط عادي إلى موصل بحيث "يلتصق" بالأشكال؟**

لا. الخط العادي (‏[AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) من النوع [Line](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/)) لا يصبح موصلًا تلقائيًا. لجعله يلتصق بالأشكال، استخدم النوع المخصص [Connector](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/) والـ[APIs المقابلة](/slides/ar/nodejs-java/connector/) للاتصالات.

**ماذا أفعل إذا كانت خصائص الخط مُورّثة من السمة ومن الصعب تحديد القيم النهائية؟**

[اقرأ الخصائص الفعّالة](/slides/ar/nodejs-java/shape-effective-properties/) عبر الفئات `ILineFormatEffectiveData`/`ILineFillFormatEffectiveData`—هذه الفئات تأخذ في الاعتبار الوراثة وأنماط السمة بالفعل.

**هل يمكنني قفل الخط ضد التحرير (النقل، تغيير الحجم)؟**

نعم. توفر الأشكال [كائنات القفل](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/getautoshapelock/) التي تتيح لك منع عمليات التحرير.