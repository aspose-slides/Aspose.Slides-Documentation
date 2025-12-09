---
title: إدارة عناصر النائب في العرض التقديمي باستخدام .NET
linktitle: إدارة العناصر النائبة
type: docs
weight: 10
url: /ar/net/manage-placeholder/
keywords:
- عنصر نائب
- عنصر نائب نصي
- عنصر نائب صورة
- عنصر نائب مخطط
- نص المطالبة
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إدارة العناصر النائبة بسهولة في Aspose.Slides للـ .NET: استبدال النص، تخصيص نصوص المطالبة وضبط شفافية الصورة في PowerPoint وOpenDocument."
---

## **تغيير النص في العنصر النائب**
باستخدام [Aspose.Slides for .NET](/slides/ar/net/)، يمكنك العثور على العناصر النائبة وتعديلها في الشرائح داخل العروض التقديمية. يتيح Aspose.Slides لك إجراء تغييرات على النص داخل العنصر النائب.

**المتطلبات المسبقة**: تحتاج إلى عرض تقديمي يحتوي على عنصر نائب. يمكنك إنشاء مثل هذا العرض التقديمي في تطبيق Microsoft PowerPoint القياسي.

هذه هي الطريقة التي تستخدم بها Aspose.Slides لاستبدال النص في العنصر النائب داخل ذلك العرض التقديمي:

1. إنشاء كائن من الفئة [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation) وتمرير العرض التقديمي كمعامل.
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. تكرار عبر الأشكال للعثور على العنصر النائب.
4. تحويل شكل العنصر النائب إلى [`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) وتغيير النص باستخدام [`TextFrame`](https://reference.aspose.com/slides/net/aspose.slides/textframe/) المرتبط بـ[`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/). 
5. حفظ العرض التقديمي المعدل.

This C# code shows how to change the text in a placeholder:
```c#
// ينشئ كائن من فئة Presentation
using (Presentation pres = new Presentation("ReplacingText.pptx"))
{

    // يصل إلى الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // يتنقل عبر الأشكال للعثور على العنصر النائب
    foreach (IShape shp in sld.Shapes)
        if (shp.Placeholder != null)
        {
            // يغيّر النص في كل عنصر نائب
            ((IAutoShape)shp).TextFrame.Text = "This is a Placeholder";
        }

    // يحفظ العرض التقديمي إلى القرص
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **تعيين نص المطالبة في العنصر النائب**
تحتوي التخطيطات القياسية والمُعدة مسبقًا على نصوص مطالبة للعنصر النائب مثل ***انقر لإضافة عنوان*** أو ***انقر لإضافة عنوان فرعي***. باستخدام Aspose.Slides، يمكنك إدراج نصوص المطالبة المفضلة لديك في تخطيطات العناصر النائبة.

This C# code shows you how to set the prompt text in a placeholder:
```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // يتنقل عبر الشريحة
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) // PowerPoint يعرض "Click to add title"
            {
                text = "Add Title";
            }
            else if (shape.Placeholder.Type == PlaceholderType.Subtitle) // يضيف عنوانًا فرعيًا
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

يتيح Aspose.Slides لك ضبط شفافية صورة الخلفية في عنصر نائب نصي. من خلال تعديل شفافية الصورة داخل هذا الإطار، يمكنك إبراز النص أو الصورة (اعتمادًا على ألوان النص والصورة).

This C# code shows you how to set the transparency for a picture background (inside a shape):
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

**ما هو العنصر النائب الأساسي، وكيف يختلف عن الشكل المحلي في الشريحة؟**

العنصر النائب الأساسي هو الشكل الأصلي في تخطيط أو القالب الذي يرث منه شكل الشريحة—النوع، الموضع، وبعض التنسيقات تأتي منه. الشكل المحلي مستقل؛ إذا لم يكن هناك عنصر نائب أساسي، فإن الوراثة لا تنطبق.

**كيف يمكنني تحديث جميع العناوين أو التسميات التوضيحية عبر العرض التقديمي دون التكرار على كل شريحة؟**

قم بتحرير العنصر النائب المقابل في التخطيط أو القالب. ستورث الشرائح التي تعتمد على تلك التخطيطات/القالب التغيير تلقائيًا.

**كيف يمكنني التحكم في عناصر النائب القياسية للترويسة/التذييل—التاريخ والوقت، رقم الشريحة، ونص التذييل؟**

استخدم مديري HeaderFooter في النطاق المناسب (الشرائح العادية، التخطيطات، القالب، ملاحظات/نشرات) لتفعيل أو إلغاء تفعيل تلك العناصر النائبة ولتحديد محتواها.