---
title: إضافة مستطيلات إلى العروض التقديمية في .NET
linktitle: مستطيل
type: docs
weight: 80
url: /ar/net/rectangle/
keywords:
- إضافة مستطيل
- إنشاء مستطيل
- شكل مستطيل
- مستطيل بسيط
- مستطيل منسق
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "عزّز عروض PowerPoint التقديمية الخاصة بك بإضافة مستطيلات باستخدام Aspose.Slides for .NET — صمم وعدّل الأشكال برمجيًا بسهولة."
---

## **إنشاء مستطيل بسيط**
مثل المواضيع السابقة، يتناول هذا أيضًا إضافة شكل وهذه المرة سنناقش المستطيل. في هذا الموضوع، وصفنا كيف يمكن للمطورين إضافة مستطيلات بسيطة أو مُنسَّقة إلى الشرائح باستخدام Aspose.Slides for .NET. لإضافة مستطيل بسيط إلى شريحة محددة من العرض التقديمي، يرجى اتباع الخطوات التالية:

1. إنشاء كائن من فئة [العرض التقديمي](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الحصول على مرجع الشريحة باستخدام فهرسها.
3. إضافة IAutoShape من نوع Rectangle باستخدام طريقة AddAutoShape التي يوفرها كائن IShapes.
4. كتابة العرض التقديمي المعدل كملف PPTX.

في المثال أدناه، قمنا بإضافة مستطيل بسيط إلى الشريحة الأولى من العرض التقديمي.
```c#
// إنشاء كائن من الفئة Presentation الذي يمثل ملف PPTX
using (Presentation pres = new Presentation())
{

    // الحصول على الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // إضافة شكل تلقائي من نوع مستطيل
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    //احفظ ملف PPTX إلى القرص
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```


## **إنشاء مستطيل مُنسَّق**
لإضافة مستطيل مُنسَّق إلى شريحة، يرجى اتباع الخطوات التالية:

1. إنشاء كائن من فئة [العرض التقديمي](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الحصول على مرجع الشريحة باستخدام فهرسها.
3. إضافة IAutoShape من نوع Rectangle باستخدام طريقة AddAutoShape التي يوفرها كائن IShapes.
4. ضبط نوع التعبئة للمستطيل إلى Solid.
5. ضبط لون المستطيل باستخدام الخاصية SolidFillColor.Color التي يوفّرها كائن FillFormat المرتبط بكائن IShape.
6. ضبط لون خطوط المستطيل.
7. ضبط عرض خطوط المستطيل.
8. كتابة العرض التقديمي المعدل كملف PPTX.
   تم تنفيذ الخطوات السابقة في المثال أدناه.
```c#
 // إنشاء كائن من فئة Presentation الذي يمثل ملف PPTX
 using (Presentation pres = new Presentation())
 {
 
     // الحصول على الشريحة الأولى
     ISlide sld = pres.Slides[0];
 
     // إضافة شكل تلقائي من نوع مستطيل
     IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);
 
     // تطبيق بعض التنسيقات على شكل المستطيل
     shp.FillFormat.FillType = FillType.Solid;
     shp.FillFormat.SolidFillColor.Color = Color.Chocolate;
 
     // تطبيق بعض التنسيقات على خط المستطيل
     shp.LineFormat.FillFormat.FillType = FillType.Solid;
     shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
     shp.LineFormat.Width = 5;
 
     // حفظ ملف PPTX على القرص
     pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```


## **الأسئلة المتكررة**

**كيف يمكنني إضافة مستطيل بزوايا مستديرة؟**

استخدم نوع الشكل [shape type](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) ذو الزوايا المستديرة واضبط نصف قطر الزاوية في خصائص الشكل؛ يمكن أيضًا تطبيق الاستدارة على كل زاوية عبر تعديل الهندسة.

**كيف أملأ المستطيل بصورة (نقش)؟**

اختر [fill type](https://reference.aspose.com/slides/net/aspose.slides/filltype/) الخاص بالصورة، حدد مصدر الصورة، واضبط أوضاع [التمدد/التكرار](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/).

**هل يمكن للمستطيل أن يحتوي على ظل وتوهج؟**

نعم. [الظل الخارجي/الداخلي، التوهج، وحواف ناعمة](/slides/ar/net/shape-effect/) متاحة مع معلمات قابلة للتعديل.

**هل يمكن تحويل المستطيل إلى زر مع ارتباط تشعبي؟**

نعم. [تعيين ارتباط تشعبي](/slides/ar/net/manage-hyperlinks/) للنقر على الشكل (للانتقال إلى شريحة، ملف، عنوان ويب، أو بريد إلكتروني).

**كيف أحمي المستطيل من الحركة والتعديل؟**

[استخدام قفل الشكل](/slides/ar/net/applying-protection-to-presentation/): يمكنك منع التحريك، إعادة الحجم، الاختيار، أو تحرير النص للحفاظ على التخطيط.

**هل يمكنني تحويل المستطيل إلى صورة نقطية أو SVG؟**

نعم. يمكنك [تصدير الشكل](http://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) إلى صورة بحجم/مقياس محدد أو [تصديره كـ SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) للاستخدام المتجهي.

**كيف أحصل بسرعة على الخصائص الفعلية (الفعّالة) للمستطيل مع مراعاة السمة والوراثة؟**

[استخدام الخصائص الفعّالة للشكل](/slides/ar/net/shape-effective-properties/): تُعيد الواجهة البرمجية القيم المحسوبة التي تأخذ في اعتبارها أنماط السمة، التخطيط، والإعدادات المحلية، مما يبسّط تحليل التنسيق.