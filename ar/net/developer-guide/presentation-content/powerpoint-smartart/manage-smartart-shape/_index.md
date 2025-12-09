---
title: إدارة رسومات SmartArt في العروض التقديمية في .NET
linktitle: رسومات SmartArt
type: docs
weight: 20
url: /ar/net/manage-smartart-shape/
keywords:
- كائن SmartArt
- رسم SmartArt
- نمط SmartArt
- لون SmartArt
- إنشاء SmartArt
- إضافة SmartArt
- تحرير SmartArt
- تغيير SmartArt
- الوصول إلى SmartArt
- نوع تخطيط SmartArt
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "أتمتة إنشاء وتحرير وتنسيق رسومات PowerPoint SmartArt في .NET باستخدام Aspose.Slides، مع أمثلة شفرة مختصرة وإرشادات تركّز على الأداء."
---

## **إنشاء شكل SmartArt**
Aspose.Slides for .NET الآن يتيح إضافة أشكال SmartArt مخصصة في الشرائح من الصفر. Aspose.Slides for .NET قد قدمت أبسط API لإنشاء أشكال SmartArt بطريقة سهلة. لإنشاء شكل SmartArt في شريحة، يرجى اتباع الخطوات أدناه:

- إنشاء كائن من فئة [العرض التقديمي](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- الحصول على مرجع الشريحة باستخدام فهرسها.
- إضافة شكل SmartArt عن طريق تحديد LayoutType له.
- كتابة العرض المعدل كملف PPTX.
```c#
    // إنشاء كائن العرض التقديمي
using (Presentation pres = new Presentation())
{
    // الوصول إلى شريحة العرض التقديمي
    ISlide slide = pres.Slides[0];
    // إضافة شكل SmartArt
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    // حفظ العرض التقديمي
    pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```




## **الوصول إلى شكل SmartArt في الشريحة**
سيتم استخدام الشيفرة التالية للوصول إلى أشكال SmartArt المضافة في شريحة العرض. في الشيفرة النموذجية سنستعرض كل شكل داخل الشريحة ونتحقق إذا كان شكل SmartArt. إذا كان الشكل من نوع SmartArt فسنقوم بتحويله إلى كائن SmartArt.
```c#
 // Load the desired the presentation
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{

    // Traverse through every shape inside first slide
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Check if shape is of SmartArt type
        if (shape is ISmartArt)
        {
            // Typecast shape to SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("Shape Name:" + smart.Name);

        }
    }
}
```




## **الوصول إلى شكل SmartArt بنوع تخطيط معين**
ستساعد الشيفرة النموذجية التالية في الوصول إلى شكل SmartArt بنوع LayoutType معين. يرجى ملاحظة أنه لا يمكن تغيير LayoutType الخاص بـ SmartArt لأنه للقراءة فقط ويُحدد فقط عند إضافة شكل SmartArt.

- إنشاء كائن من فئة `Presentation` وتحميل العرض الذي يحتوي على شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
- استعراض كل شكل داخل الشريحة الأولى.
- التحقق إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.
- التحقق من شكل SmartArt بنوع LayoutType معين وإجراء ما يلزم بعد ذلك.
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // التنقل عبر كل شكل داخل الشريحة الأولى
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (shape is ISmartArt)
        {
            // تحويل الشكل إلى SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // التحقق من تخطيط SmartArt
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("Do some thing here....");
            }
        }
    }
}
```




## **تغيير نمط شكل SmartArt**
ستساعد الشيفرة النموذجية التالية في الوصول إلى شكل SmartArt بنوع LayoutType معين.

- إنشاء كائن من فئة `Presentation` وتحميل العرض الذي يحتوي على شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
- استعراض كل شكل داخل الشريحة الأولى.
- التحقق إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.
- العثور على شكل SmartArt بنمط معين.
- تعيين النمط الجديد لشكل SmartArt.
- حفظ العرض.
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // التنقل عبر كل شكل داخل الشريحة الأولى
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (shape is ISmartArt)
        {
            // تحويل الشكل إلى SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // التحقق من نمط SmartArt
            if (smart.QuickStyle == SmartArtQuickStyleType.SimpleFill)
            {
                // تغيير نمط SmartArt
                smart.QuickStyle = SmartArtQuickStyleType.Cartoon;
            }
        }
    }

    // حفظ العرض التقديمي
    presentation.Save("ChangeSmartArtStyle_out.pptx", SaveFormat.Pptx);
}
```




## **تغيير نمط لون شكل SmartArt**
في هذا المثال، سنتعلم كيفية تغيير نمط اللون لأي شكل SmartArt. في الشيفرة النموذجية التالية سنصل إلى شكل SmartArt بنمط لون معين ونغيّر نمطه.

- إنشاء كائن من فئة `Presentation` وتحميل العرض الذي يحتوي على شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام فهرسها.
- استعراض كل شكل داخل الشريحة الأولى.
- التحقق إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.
- العثور على شكل SmartArt بنمط لون معين.
- تعيين نمط اللون الجديد لشكل SmartArt.
- حفظ العرض.
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // التنقل عبر كل شكل داخل الشريحة الأولى
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (shape is ISmartArt)
        {
            // تحويل الشكل إلى SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // التحقق من نوع لون SmartArt
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // تغيير نوع لون SmartArt
                smart.ColorStyle = SmartArtColorType.ColorfulAccentColors;
            }
        }
    }

    // حفظ العرض التقديمي
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة الشائعة**

**هل يمكنني تحريك SmartArt ككائن واحد؟**

نعم. SmartArt هو شكل، لذا يمكنك تطبيق [الرسوم المتحركة القياسية](/slides/ar/net/powerpoint-animation/) عبر API الرسوم المتحركة (دخول، خروج، تأكيد، مسارات الحركة) تمامًا كما هو الحال مع الأشكال الأخرى.

**كيف يمكنني العثور على SmartArt معين في شريحة إذا لم أعرف معرفه الداخلي؟**

قم بتعيين واستخدام النص البديل (AltText) وابحث عن الشكل باستخدام تلك القيمة—هذه طريقة موصى بها لتحديد الشكل المستهدف.

**هل يمكنني تجميع SmartArt مع أشكال أخرى؟**

نعم. يمكنك تجميع SmartArt مع أشكال أخرى (صور، جداول، إلخ) ثم [التعامل مع المجموعة](/slides/ar/net/group/).

**كيف أحصل على صورة لSmartArt معين (مثلاً للمعاينة أو التقرير)؟**

صدّر صورة مصغرة/صورة للشكل؛ المكتبة يمكنها [إنتاج صور للأشكال الفردية](/slides/ar/net/create-shape-thumbnails/) إلى ملفات نقطية (PNG/JPG/TIFF).

**هل سيُحافظ على مظهر SmartArt عند تحويل العرض بالكامل إلى PDF؟**

نعم. محرك التصيير يستهدف دقة عالية لتصدير [PDF](/slides/ar/net/convert-powerpoint-to-pdf/)، مع مجموعة من خيارات الجودة والتوافق.