---
title: إدارة عناصر النائب في العروض التقديمية عبر .NET
linktitle: إدارة العناصر النائبة
type: docs
weight: 10
url: /ar/net/manage-placeholder/
keywords:
- عنصر نائب
- نص عنصر نائب
- صورة عنصر نائب
- مخطط عنصر نائب
- نص المطالبة
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إدارة العناصر النائبة بسهولة في Aspose.Slides لـ .NET: استبدال النص، تخصيص نصوص المطالبة وضبط شفافية الصورة في PowerPoint وOpenDocument."
---

## **تغيير النص في العنصر النائب**
باستخدام [Aspose.Slides for .NET](/slides/ar/net/)، يمكنك العثور على العناصر النائبة في الشرائح وتعديلها في العروض التقديمية. يتيح لك Aspose.Slides إجراء تغييرات على النص داخل عنصر نائب.

**متطلب مسبق**: تحتاج إلى عرض تقديمي يحتوي على عنصر نائب. يمكنك إنشاء مثل هذا العرض في تطبيق Microsoft PowerPoint القياسي.

هذه هي الطريقة التي تستخدم بها Aspose.Slides لاستبدال النص في العنصر النائب في ذلك العرض التقديمي:

1. إنشاء كائن من الفئة [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation) وتمرير العرض التقديمي كمعامل.  
2. الحصول على مرجع للشفرة عبر فهرسها.  
3. التنقل بين الأشكال للعثور على العنصر النائب.  
4. تحويل شكل العنصر النائب إلى [`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) وتغيير النص باستخدام [`TextFrame`](https://reference.aspose.com/slides/net/aspose.slides/textframe/) المرتبط بـ[`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/).  
5. حفظ العرض التقديمي المعدل.

```c#
// ينشئ فئة Presentation
using (Presentation pres = new Presentation("ReplacingText.pptx"))
{

    // يصل إلى الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // يتجول عبر الأشكال للعثور على العنصر النائب
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


## **تعيين نص المطالبة في عنصر نائب**
تحتوي التخطيطات القياسية والمُعدة مسبقًا على نصوص مطالبة في العناصر النائبة مثل ***انقر لإضافة عنوان*** أو ***انقر لإضافة عنوان فرعي***. باستخدام Aspose.Slides، يمكنك إدراج نصوص المطالبة المفضلة لديك في تخطيطات العناصر النائبة.

```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // يتجول عبر الشريحة
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) // PowerPoint يعرض "انقر لإضافة عنوان"
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
يتيح لك Aspose.Slides ضبط شفافية صورة الخلفية في عنصر نائب نصي. من خلال ضبط شفافية الصورة داخل هذا الإطار، يمكنك إبراز النص أو الصورة (اعتمادًا على ألوان النص والصورة).

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
العنصر النائب الأساسي هو الشكل الأصلي في التخطيط أو القالب الذي يرث منه شكل الشريحة — النوع، الموضع، وبعض التنسيقات تأتي منه. الشكل المحلي مستقل؛ إذا لم يكن هناك عنصر نائب أساسي، لا يُطبق الوراثة.

**كيف يمكنني تحديث جميع العناوين أو التسميات التوضيحية عبر عرض تقديمي دون التنقل عبر كل شريحة؟**  
قم بتحرير العنصر النائب المقابل في التخطيط أو القالب. الشرائح التي تعتمد على تلك التخطيطات/القالب ستورّث التغيير تلقائيًا.

**كيف أتحكم في العناصر النائبة القياسية للترويسة/التذييل — التاريخ والوقت، رقم الشريحة، ونص التذييل؟**  
استخدم مديري HeaderFooter في النطاق المناسب (الشرائح العادية، التخطيطات، القالب، الملاحظات/النشرات) لتفعيل أو إلغاء تفعيل تلك العناصر النائبة وتعيين محتواها.