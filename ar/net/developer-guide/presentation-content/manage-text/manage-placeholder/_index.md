---
title: إدارة العنصر النائب
type: docs
weight: 10
url: /ar/net/manage-placeholder/
keywords: "عنصر نائب, نص العنصر النائب, نص الإرشاد, عرض تقديمي PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "تغيير نص العنصر النائب ونص الإرشاد في عروض PowerPoint التقديمية باستخدام C# أو .NET"
---

## **تغيير النص في العنصر النائب**
باستخدام [Aspose.Slides for .NET](/slides/ar/net/)، يمكنك العثور على العناصر النائبة وتعديلها على الشرائح في العروض التقديمية. يسمح لك Aspose.Slides بإجراء تغييرات على النص داخل العنصر النائب.

**المتطلب المسبق**: تحتاج إلى عرض تقديمي يحتوي على عنصر نائب. يمكنك إنشاء مثل هذا العرض التقديمي باستخدام تطبيق Microsoft PowerPoint القياسي.

إليك طريقة استخدام Aspose.Slides لاستبدال النص في العنصر النائب داخل ذلك العرض التقديمي:

1. إنشاء كائن من الفئة [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation) وتمرير العرض التقديمي كمعامل.
2. احصل على مرجع الشريحة من خلال فهرسها.
3. قم بالتكرار عبر الأشكال للعثور على العنصر النائب.
4. حوّل شكل العنصر النائب إلى [`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) ثم غيّر النص باستخدام [`TextFrame`](https://reference.aspose.com/slides/net/aspose.slides/textframe/) المرتبط بـ [`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/). 
5. احفظ العرض التقديمي المعدّل.

هذا الكود C# يعرض طريقة تغيير النص في العنصر النائب:
```c#
// إنشاء كائن من فئة Presentation
using (Presentation pres = new Presentation("ReplacingText.pptx"))
{

    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // التكرار عبر الأشكال للعثور على العنصر النائب
    foreach (IShape shp in sld.Shapes)
        if (shp.Placeholder != null)
        {
            // تغيير النص في كل عنصر نائب
            ((IAutoShape)shp).TextFrame.Text = "This is a Placeholder";
        }

    // حفظ العرض التقديمي إلى القرص
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **تعيين نص الإرشاد في العنصر النائب**
تحتوي القوالب القياسية والمُعدة مسبقاً على نصوص إرشادية في العنصر النائب مثل ***انقر لإضافة عنوان*** أو ***انقر لإضافة نص فرعي***. باستخدام Aspose.Slides، يمكنك إدراج نصوص الإرشاد المفضلة لديك في قوالب العناصر النائبة.

هذا الكود C# يوضح طريقة تعيين نص الإرشاد في العنصر النائب:
```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // يتكرر عبر الشريحة
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) // PowerPoint يعرض "انقر لإضافة عنوان"
            {
                text = "Add Title";
            }
            else if (shape.Placeholder.Type == PlaceholderType.Subtitle) // يضيف العنوان الفرعي
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).TextFrame.Text = text;

            Console.WriteLine($"Placeholder with text: {text}");
        }
    }

    pres.Save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
}
```


## **تعيين شفافية صورة العنصر النائب**

يسمح لك Aspose.Slides بتعيين شفافية صورة الخلفية في عنصر نائب نصي. من خلال تعديل شفافية الصورة داخل هذا الإطار، يمكنك إبراز النص أو الصورة (حسب ألوان النص والصورة).

هذا الكود C# يوضح طريقة تعيين الشفافية لخلفية الصورة (داخل الشكل):
```c#
using (var presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    
    autoShape.FillFormat.FillType = FillType.Picture;
    autoShape.FillFormat.PictureFillFormat.Picture.Image = presentation.Images.AddImage(File.ReadAllBytes("image.png"));
    autoShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    autoShape.FillFormat.PictureFillFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(75);
}
```


## **الأسئلة المتكررة**

**ما هو العنصر النائب الأساسي، وكيف يختلف عن الشكل المحلي على الشريحة؟**

العنصر النائب الأساسي هو الشكل الأصلي الموجود في القالب أو القالب الرئيسي الذي يرث منه شكل الشريحة — النوع، الموضع، وبعض التنسيقات تأتي منه. الشكل المحلي مستقل؛ إذا لم يكن هناك عنصر نائب أساسي، لا يتم تطبيق الوراثة.

**كيف يمكنني تحديث جميع العناوين أو التسميات التوضيحية في العرض التقديمي دون التكرار على كل شريحة؟**

قم بتحرير العنصر النائب المقابل في القالب أو القالب الرئيسي. ستورث الشرائح المستندة إلى تلك القوالب/القالب الرئيسي التغيّر تلقائيًا.

**كيف يمكنني التحكم في العناصر النائبة القياسية للترويسة/التذييل — التاريخ والوقت، رقم الشريحة، ونص التذييل؟**

استخدم مديري HeaderFooter في النطاق المناسب (الشرائح العادية، القوالب، القالب الرئيسي، الملاحظات/المطبوعات) لتفعيل أو إلغاء تلك العناصر النائبة وتعيين محتواها.