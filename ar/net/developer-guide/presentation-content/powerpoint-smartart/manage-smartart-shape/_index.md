---
title: "إدارة رسومات SmartArt في العروض التقديمية باستخدام .NET"
linktitle: "رسومات SmartArt"
type: docs
weight: 20
url: /ar/net/manage-smartart-shape/
keywords:
- "كائن SmartArt"
- "رسمة SmartArt"
- "نمط SmartArt"
- "لون SmartArt"
- "إنشاء SmartArt"
- "إضافة SmartArt"
- "تحرير SmartArt"
- "تغيير SmartArt"
- "الوصول إلى SmartArt"
- "نوع تخطيط SmartArt"
- "PowerPoint"
- "عرض تقديمي"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "أتمتة إنشاء وتحرير وتنسيق رسومات SmartArt في PowerPoint باستخدام .NET وAspose.Slides، مع أمثلة شفرة مختصرة وإرشادات تركّز على الأداء."
---

## **إنشاء شكل SmartArt**
Aspose.Slides لـ .NET يتيح الآن إضافة أشكال SmartArt مخصصة إلى الشرائح من الصفر. قدم Aspose.Slides لـ .NET أبسط واجهة برمجة تطبيقات لإنشاء أشكال SmartArt بأبسط طريقة. لإنشاء شكل SmartArt في شريحة، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
- الحصول على مرجع شريحة باستخدام فهرستها.
- إضافة شكل SmartArt عن طريق تعيين LayoutType.
- كتابة العرض التقديمي المعدل كملف PPTX.
```c#
// إنشاء العرض التقديمي
using (Presentation pres = new Presentation())
{

    // الوصول إلى شريحة العرض التقديمي
    ISlide slide = pres.Slides[0];

    // إضافة شكل Smart Art
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

    // حفظ العرض التقديمي
    pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **الوصول إلى شكل SmartArt على شريحة**
سيتم استخدام الشيفرة التالية للوصول إلى أشكال SmartArt المضافة في شريحة العرض التقديمي. في الشيفرة النموذجية سنستعرض كل شكل داخل الشريحة ونتحقق مما إذا كان شكل SmartArt. إذا كان الشكل من نوع SmartArt فسنقوم بتحويله إلى مثيل SmartArt.
```c#
// تحميل العرض التقديمي المطلوب
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{

    // استعراض كل شكل داخل الشريحة الأولى
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (shape is ISmartArt)
        {
            // تحويل الشكل إلى SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("Shape Name:" + smart.Name);

        }
    }
}
```


## **الوصول إلى شكل SmartArt بنوع تخطيط معين**
سيساعدك الشيفرة النموذجية التالية على الوصول إلى شكل SmartArt بنوع LayoutType معين. يرجى ملاحظة أنه لا يمكنك تغيير LayoutType لعملية SmartArt لأنه للقراءة فقط ويُحدد فقط عند إضافة الشكل.

- إنشاء مثيل من الفئة `Presentation` وتحميل العرض التقديمي الذي يحتوي على شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام فهرستها.
- استعراض كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان كذلك.
- فحص شكل SmartArt ذو LayoutType معين وتنفيذ ما يلزم لاحقًا.
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // استعراض كل شكل داخل الشريحة الأولى
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
ستساعدك الشيفرة النموذجية التالية على الوصول إلى شكل SmartArt بنوع LayoutType معين.

- إنشاء مثيل من الفئة `Presentation` وتحميل العرض التقديمي الذي يحتوي على شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام فهرستها.
- استعراض كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان كذلك.
- العثور على شكل SmartArt بنمط معين.
- تعيين النمط الجديد لشكل SmartArt.
- حفظ العرض التقديمي.
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // استعراض كل شكل داخل الشريحة الأولى
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
في هذا المثال سنتعلم كيفية تغيير نمط اللون لأي شكل SmartArt. ستقوم الشيفرة النموذجية التالية بالوصول إلى شكل SmartArt بنمط لون معين وتغيير نمطه.

- إنشاء مثيل من الفئة `Presentation` وتحميل العرض التقديمي الذي يحتوي على شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام فهرستها.
- استعراض كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان كذلك.
- العثور على شكل SmartArt بنمط لون معين.
- تعيين نمط اللون الجديد لشكل SmartArt.
- حفظ العرض التقديمي.
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // استعراض كل شكل داخل الشريحة الأولى
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

نعم. SmartArt هو شكل، لذلك يمكنك تطبيق [حركات قياسية](/slides/ar/net/powerpoint-animation/) عبر واجهة برمجة تطبيقات الحركات (دخول، خروج، تأكيد، مسارات الحركة) تمامًا مثل باقي الأشكال.

**كيف يمكنني العثور على SmartArt معين في شريحة إذا لم أكن أعرف معرفه الداخلي؟**

قم بتعيين واستخدام النص البديل (AltText) وابحث عن الشكل باستخدام تلك القيمة — هذه طريقة موصى بها لتحديد الشكل المستهدف.

**هل يمكنني تجميع SmartArt مع أشكال أخرى؟**

نعم. يمكنك تجميع SmartArt مع أشكال أخرى (صور، جداول، إلخ) ثم [التعامل مع المجموعة](/slides/ar/net/group/).

**كيف أحصل على صورة لـ SmartArt معين (مثلاً للمعاينة أو التقرير)؟**

صدّر صورة مصغرة/صورة للشكل؛ يمكن للمكتبة [عرض أشكال فردية](/slides/ar/net/create-shape-thumbnails/) إلى ملفات نقطية (PNG/JPG/TIFF).

**هل سيُحافظ مظهر SmartArt عند تحويل العرض التقديمي بالكامل إلى PDF؟**

نعم. محرك العرض يستهدف دقة عالية لـ [تصدير PDF](/slides/ar/net/convert-powerpoint-to-pdf/)، مع مجموعة من خيارات الجودة والتوافق.