---
title: مستطيل
type: docs
weight: 80
url: /ar/net/rectangle/
keywords: "إنشاء مستطيل, شكل PowerPoint, عرض PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "إنشاء مستطيل في عرض PowerPoint باستخدام C# أو .NET"
---

## **إنشاء مستطيل بسيط**
مثل المواضيع السابقة، هذا الموضوع أيضًا يتناول إضافة شكل، وهذه المرة الشكل الذي سنناقشه هو المستطيل. في هذا الموضوع، وصفنا كيف يمكن للمطورين إضافة مستطيلات بسيطة أو مُنسّقة إلى شرائحهم باستخدام Aspose.Slides for .NET. لإضافة مستطيل بسيط إلى شريحة محددة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

1. إنشاء نسخة من فئة [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)
2. الحصول على مرجع شريحة باستخدام الفهرس الخاص بها.
3. إضافة IAutoShape من نوع Rectangle باستخدام طريقة AddAutoShape التي تعرضها كائن IShapes.
4. كتابة العرض التقديمي المعدّل كملف PPTX.

في المثال الموضّح أدناه، أضفنا مستطيلًا بسيطًا إلى الشريحة الأولى من العرض التقديمي.
```c#
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
using (Presentation pres = new Presentation())
{

    // الحصول على الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // إضافة شكل تلقائي من النوع مستطيل
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // حفظ ملف PPTX على القرص
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```


## **إنشاء مستطيل مُنسّق**
لإضافة مستطيل مُنسّق إلى شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء نسخة من فئة [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)
2. الحصول على مرجع شريحة باستخدام الفهرس الخاص بها.
3. إضافة IAutoShape من نوع Rectangle باستخدام طريقة AddAutoShape التي تعرضها كائن IShapes.
4. إعداد نوع التعبئة للمستطيل إلى Solid.
5. ضبط لون المستطيل باستخدام الخاصية SolidFillColor.Color التي تعرضها كائن FillFormat المرتبط بكائن IShape.
6. ضبط لون خطوط المستطيل.
7. ضبط عرض خطوط المستطيل.
8. كتابة العرض التقديمي المعدّل كملف PPTX.

تم تنفيذ الخطوات المذكورة أعلاه في المثال الموضّح أدناه.
```c#
// إنشاء كائن من فئة Presentation الذي يمثل ملف PPTX
using (Presentation pres = new Presentation())
{

    // احصل على الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // إضافة شكل تلقائي من النوع مستطيل
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

**كيف يمكنني إضافة مستطيل بأركان مدورة؟**  
استخدم نوع الشكل [shape type](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) بأركان مدورة واضبط نصف قطر الزاوية في خصائص الشكل؛ يمكن أيضًا تطبيق التدوير على كل زاوية عبر تعديل الهندسة.

**كيف أملأ مستطيلًا بصورة (نقش)؟**  
اختر [fill type](https://reference.aspose.com/slides/net/aspose.slides/filltype/) للصورة، قدم مصدر الصورة، وقم بضبط [stretching/tiling modes](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/).

**هل يمكن للمستطيل أن يحتوي على ظل وتوهّج؟**  
نعم. [Outer/inner shadow, glow, and soft edges](/slides/ar/net/shape-effect/) متاحة مع معلمات قابلة للتعديل.

**هل يمكنني تحويل المستطيل إلى زر مع ارتباط تشعبي؟**  
نعم. [Assign a hyperlink](/slides/ar/net/manage-hyperlinks/) للنقر على الشكل (الانتقال إلى شريحة، ملف، عنوان ويب، أو بريد إلكتروني).

**كيف يمكنني حماية المستطيل من التحريك والتغييرات؟**  
[Use shape locks](/slides/ar/net/applying-protection-to-presentation/): يمكنك منع التحريك، تغيير الحجم، الاختيار، أو تحرير النص للحفاظ على التخطيط.

**هل يمكنني تحويل المستطيل إلى صورة نقطية أو SVG؟**  
نعم. يمكنك [render the shape](http://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) إلى صورة بحجم/مقياس محدد أو [export it as SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) للاستخدام كمتجه.

**كيف أحصل بسرعة على الخصائص الفعلية (الفعّالة) للمستطيل مع مراعاة السمة والوراثة؟**  
[Use the shape’s effective properties](/slides/ar/net/shape-effective-properties/): تُعيد الواجهة البرمجية القيم المحسوبة التي تأخذ في الاعتبار أنماط السمة، التخطيط، والإعدادات المحلية، مما يبسط تحليل التنسيق.