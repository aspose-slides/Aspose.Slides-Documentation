---
title: إدارة شكل SmartArt
type: docs
weight: 20
url: /ar/net/manage-smartart-shape/
keywords: "شكل SmartArt، نمط شكل SmartArt، نمط لون شكل SmartArt، عرض PowerPoint، C#، Csharp، Aspose.Slides for .NET"
description: "إدارة SmartArt في عروض PowerPoint في C# أو .NET"
---

## **إنشاء شكل SmartArt**
Aspose.Slides for .NET الآن تسهل إضافة أشكال SmartArt مخصصة في الشرائح من الصفر. لقد قدمت Aspose.Slides for .NET أبسط واجهة برمجة تطبيقات لإنشاء أشكال SmartArt بأسهل طريقة. لإنشاء شكل SmartArt في شريحة، يرجى اتباع الخطوات أدناه:

- إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة شكل SmartArt عن طريق تعيين LayoutType.
- كتابة العرض المعدل كملف PPTX.

```c#
// إنشاء العرض
using (Presentation pres = new Presentation())
{

    // الوصول إلى شريحة العرض
    ISlide slide = pres.Slides[0];

    // إضافة شكل Smart Art
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

    // حفظ العرض
    pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **الوصول إلى شكل SmartArt في الشريحة**
سيتم استخدام الكود التالي للوصول إلى أشكال SmartArt المضافة في شريحة العرض. في الكود النموذجي، سنقوم بالتجول عبر كل شكل داخل الشريحة والتحقق مما إذا كان شكل SmartArt. إذا كان الشكل من نوع SmartArt، فسنقوم بتحويله إلى مثيل SmartArt.

```c#
// تحميل العرض المطلوب
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{

    // التجول في كل شكل داخل الشريحة الأولى
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // التحقق مما إذا كان الشكل من نوع SmartArt
        if (shape is ISmartArt)
        {
            // تحويل الشكل إلى SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("اسم الشكل:" + smart.Name);
        }
    }
}
```



## **الوصول إلى شكل SmartArt بنوع تخطيط معين**
سيساعد الكود النموذجي التالي في الوصول إلى شكل SmartArt بنوع LayoutType معين. يرجى ملاحظة أنه لا يمكنك تغيير LayoutType لشكل SmartArt لأنه قابل للقراءة فقط ويتم تعيينه فقط عند إضافة شكل SmartArt.

- إنشاء كائن من فئة `Presentation` وتحميل العرض مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- التجول في كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان هو SmartArt.
- تحقق من شكل SmartArt بنوع LayoutType معين وقم بما يلزم القيام به بعد ذلك.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // التجول في كل شكل داخل الشريحة الأولى
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
                Console.WriteLine("قم ببعض الشيء هنا....");
            }
        }
    }
}
```



## **تغيير نمط شكل SmartArt**
سيساعد الكود النموذجي التالي في الوصول إلى شكل SmartArt بنوع LayoutType معين.

- إنشاء كائن من فئة `Presentation` وتحميل العرض مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- التجول في كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان هو SmartArt.
- العثور على شكل SmartArt بنمط معين.
- تعيين نمط جديد لشكل SmartArt.
- حفظ العرض.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // التجول في كل شكل داخل الشريحة الأولى
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

    // حفظ العرض
    presentation.Save("ChangeSmartArtStyle_out.pptx", SaveFormat.Pptx);
}
```



## **تغيير نمط لون شكل SmartArt**
في هذا المثال، سنتعلم كيفية تغيير نمط اللون لأي شكل SmartArt. في الكود النموذجي التالي، سنقوم بالوصول إلى شكل SmartArt بنمط لون معين وسنغير أسلوبه.

- إنشاء كائن من فئة `Presentation` وتحميل العرض مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- التجول في كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان هو SmartArt.
- العثور على شكل SmartArt بنمط لون معين.
- تعيين نمط لون جديد لشكل SmartArt.
- حفظ العرض.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // التجول في كل شكل داخل الشريحة الأولى
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

    // حفظ العرض
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```