---
title: خط
type: docs
weight: 50
url: /ar/nodejs-java/Line/
---

{{% alert color="primary" %}} 

يدعم Aspose.Slides for Node.js via Java إضافة أنواع مختلفة من الأشكال إلى الشرائح. في هذا الموضوع، سنبدأ العمل مع الأشكال بإضافة خطوط إلى الشرائح. باستخدام Aspose.Slides for Node.js via Java، لا يمكن للمطورين إنشاء خطوط بسيطة فقط، بل يمكن أيضًا رسم خطوط متقنة على الشرائح.

{{% /alert %}} 

## **إنشاء خط بسيط**

لإضافة خط بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات التالية:

- إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
- الحصول على مرجع شريحة باستخدام فهرستها.
- إضافة AutoShape من النوع Line باستخدام الطريقة [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) التي توفرها كائن [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) .
- احفظ العرض التقديمي المعدل كملف PPTX.

في المثال أدناه، قمنا بإضافة خط إلى الشريحة الأولى من العرض التقديمي.
```javascript
// إنشاء فئة PresentationEx التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // إضافة AutoShape من النوع خط
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // كتابة PPTX إلى القرص
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إنشاء خط على شكل سهم**

يسمح Aspose.Slides for Node.js via Java أيضًا للمطورين بتكوين بعض خصائص الخط لجعله أكثر جاذبية. دعونا نجرب تكوين بعض خصائص الخط لجعله يبدو كسهم. يرجى اتباع الخطوات التالية للقيام بذلك:

- إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
- الحصول على مرجع شريحة باستخدام فهرستها.
- إضافة AutoShape من النوع Line باستخدام الطريقة [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) التي توفرها كائن [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) .
- ضبط [Line Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineStyle) إلى أحد الأنماط التي توفرها Aspose.Slides for Node.js via Java.
- ضبط عرض الخط.
- ضبط [Dash Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineDashStyle) للخط إلى أحد الأنماط التي توفرها Aspose.Slides for Node.js via Java.
- ضبط [Arrow Head Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadStyle) و[Length](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadLength) لنقطة البداية للخط.
- ضبط [Arrow Head Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadStyle) و[Length](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadLength) لنقطة النهاية للخط.
- احفظ العرض التقديمي المعدل كملف PPTX.
```javascript
// إنشاء فئة PresentationEx التي تمثل ملف PPTX
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
    // كتابة PPTX إلى القرص
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**هل يمكنني تحويل خط عادي إلى موصل بحيث "يلتصق" بالأشكال؟**

لا. الخط العادي (وهو [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) من النوع [Line](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/)) لا يتحول تلقائيًا إلى موصل. لجعله يلتصق بالأشكال، استخدم النوع المخصص [Connector](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/) و[corresponding APIs](/slides/ar/nodejs-java/connector/) الخاصة بالاتصالات.

**ماذا أفعل إذا كانت خصائص الخط موروثة من السمة ويصعب تحديد القيم النهائية؟**

[اقرأ الخصائص الفعّالة](/slides/ar/nodejs-java/shape-effective-properties/) عبر الفئات `ILineFormatEffectiveData`/`ILineFillFormatEffectiveData`—هذه الفئات تحتسب بالفعل الوراثة وأنماط السمة.

**هل يمكنني قفل خط لمنع التحرير (النقل، تغيير الحجم)؟**

نعم. تُوفر الأشكال [كائنات القفل](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/getautoshapelock/) التي تسمح لك [disallow editing operations](/slides/ar/nodejs-java/applying-protection-to-presentation/).