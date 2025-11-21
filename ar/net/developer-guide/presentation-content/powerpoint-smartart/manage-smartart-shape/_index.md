---
title: إدارة شكل SmartArt
type: docs
weight: 20
url: /ar/net/manage-smartart-shape/
keywords: "شكل SmartArt, نمط شكل SmartArt, نمط لون شكل SmartArt, عرض تقديمي PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "إدارة SmartArt في عروض PowerPoint التقديمية باستخدام C# أو .NET"
---

## **إنشاء شكل SmartArt**
Aspose.Slides for .NET الآن يتيح إضافة أشكال SmartArt مخصصة في الشرائح من الصفر. Aspose.Slides for .NET قد وفر أبسط واجهة برمجة تطبيقات لإنشاء أشكال SmartArt بأبسط طريقة. لإنشاء شكل SmartArt في شريحة، يرجى اتباع الخطوات التالية:

- إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
- الحصول على مرجع الشريحة باستخدام الـ Index الخاص بها.
- إضافة شكل SmartArt عن طريق ضبط LayoutType الخاص به.
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


## **الوصول إلى شكل SmartArt في الشريحة**
سيتم استخدام الشيفرة التالية للوصول إلى أشكال SmartArt المضافة في شريحة العرض التقديمي. في مثال الشيفرة سنقوم بالتنقل عبر كل شكل داخل الشريحة والتحقق مما إذا كان شكل SmartArt. إذا كان الشكل من نوع SmartArt فسنقوم بتحويله إلى مثيل SmartArt.
```c#
// تحميل العرض التقديمي المطلوب
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{

    // التنقل عبر كل شكل داخل الشريحة الأولى
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


## **الوصول إلى شكل SmartArt مع نوع Layout معين**
ستساعد الشيفرة النموذجية التالية في الوصول إلى شكل SmartArt بنوع LayoutType معين. يرجى ملاحظة أنه لا يمكنك تغيير LayoutType الخاص بـ SmartArt لأنه للقراءة فقط ويتم تعيينه فقط عند إضافة شكل SmartArt.

- إنشاء مثيل من الفئة `Presentation` وتحميل العرض التقديمي مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام الـ Index الخاص بها.
- التنقل عبر كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.
- فحص شكل SmartArt بنوع LayoutType معين وتنفيذ ما يلزم بعد ذلك.
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

- إنشاء مثيل من الفئة `Presentation` وتحميل العرض التقديمي مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام الـ Index الخاص بها.
- التنقل عبر كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.
- العثور على شكل SmartArt بنمط معين.
- تعيين النمط الجديد لشكل SmartArt.
- حفظ العرض التقديمي.
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
في هذا المثال، سنتعلم كيفية تغيير نمط اللون لأي شكل SmartArt. في الشيفرة النموذجية التالية سنصل إلى شكل SmartArt بنمط لون معين وسنغير نمطه.

- إنشاء مثيل من الفئة `Presentation` وتحميل العرض التقديمي مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام الـ Index الخاص بها.
- التنقل عبر كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.
- العثور على شكل SmartArt بنمط لون معين.
- تعيين نمط اللون الجديد لشكل SmartArt.
- حفظ العرض التقديمي.
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


## **الأسئلة المتكررة**

**هل يمكنني تحريك SmartArt ككائن واحد؟**

نعم. SmartArt هو شكل، لذا يمكنك تطبيق [الرسوم المتحركة القياسية](/slides/ar/net/powerpoint-animation/) عبر واجهة برمجة تطبيقات الرسوم المتحركة (الدخول، الخروج، التشديد، مسارات الحركة) كما هو الحال مع الأشكال الأخرى.

**كيف يمكنني العثور على SmartArt محدد في شريحة إذا لم أعرف الـ ID الداخلي الخاص به؟**

قم بتعيين واستخدام النص البديل (AltText) وابحث عن الشكل باستخدام تلك القيمة — هذا هو الطريقة الموصى بها لتحديد موقع الشكل المستهدف.

**هل يمكنني تجميع SmartArt مع أشكال أخرى؟**

نعم. يمكنك تجميع SmartArt مع أشكال أخرى (صور، جداول، إلخ) ثم [التعامل مع المجموعة](/slides/ar/net/group/).

**كيف أحصل على صورة لـ SmartArt محدد (مثلاً للمعاينة أو التقرير)؟**

صدّر صورة مصغرة/صورة للشكل؛ يمكن للمكتبة [تصيير الأشكال الفردية](/slides/ar/net/create-shape-thumbnails/) إلى ملفات نقطية (PNG/JPG/TIFF).

**هل سيتم الحفاظ على مظهر SmartArt عند تحويل كامل العرض التقديمي إلى PDF؟**

نعم. محرك التصيير يهدف إلى دقة عالية لتصدير [PDF](/slides/ar/net/convert-powerpoint-to-pdf/)، مع مجموعة من خيارات الجودة والتوافق.