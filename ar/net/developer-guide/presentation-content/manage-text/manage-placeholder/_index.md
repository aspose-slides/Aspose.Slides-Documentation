---
title: إدارة عنصر نائب
type: docs
weight: 10
url: /net/manage-placeholder/
keywords: "عنصر نائب, نص العنصر النائب, نص الترويسة, عرض تقديمي في PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "تغيير نص العنصر النائب ونص الترويسة في عروض PowerPoint باستخدام C# أو .NET"
---

## **تغيير النص في العنصر النائب**
باستخدام [Aspose.Slides for .NET](/slides/net/)، يمكنك العثور على العناصر النائبة وتعديلها في الشرائح داخل العروض التقديمية. يتيح لك Aspose.Slides إجراء تغييرات على النص في العنصر النائب.

**المتطلبات الأساسية**: تحتاج إلى عرض تقديمي يحتوي على عنصر نائب. يمكنك إنشاء مثل هذا العرض في تطبيق Microsoft PowerPoint العادي.

إليك كيفية استخدام Aspose.Slides لاستبدال النص في العنصر النائب في ذلك العرض:

1. قم بإنشاء كائن من فئة [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation) ومرر العرض كوسيط.
2. احصل على مرجع الشريحة من خلال فهرسها.
3. قم بالتكرار خلال الأشكال للعثور على العنصر النائب.
4. قم بتحويل شكل العنصر النائب إلى [`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) وتغيير النص باستخدام [`TextFrame`](https://reference.aspose.com/slides/net/aspose.slides/textframe/) المرتبط بـ [`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/). 
5. احفظ العرض المعدل.

يوضح هذا الكود C# كيفية تغيير النص في عنصر نائب:

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
            ((IAutoShape)shp).TextFrame.Text = "هذا عنصر نائب";
        }

    // حفظ العرض على القرص
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **تعيين نص الترويسة في العنصر النائب**
تحتوي التخطيطات القياسية والمعدة مسبقًا على نصوص ترويسة العناصر النائبة مثل ***اضغط لإضافة عنوان*** أو ***اضغط لإضافة عنوان فرعي***. باستخدام Aspose.Slides، يمكنك إدراج نصوص ترويسة مفضلة لديك في تخطيطات العناصر النائبة.

يوضح هذا الكود C# كيفية تعيين نص الترويسة في عنصر نائب:

```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // التكرار عبر الشريحة
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) // يعرض PowerPoint "اضغط لإضافة عنوان"
            {
                text = "أضف عنوانًا";
            }
            else if (shape.Placeholder.Type == PlaceholderType.Subtitle) // إضافة عنوان فرعي
            {
                text = "أضف عنوانًا فرعيًا";
            }

            ((IAutoShape)shape).TextFrame.Text = text;

            Console.WriteLine($"عنصر نائب بالنص: {text}");
        }
    }

    pres.Save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
}
```

## **تعيين شفافية صورة العنصر النائب**

يتيح لك Aspose.Slides تعيين شفافية الصورة الخلفية في عنصر نائب نص. من خلال ضبط شفافية الصورة في مثل هذا الإطار، يمكنك جعل النص أو الصورة بارزًا (اعتمادًا على ألوان النص والصورة).

يوضح هذا الكود C# كيفية تعيين الشفافية لخلفية صورة (داخل شكل):

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