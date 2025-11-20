---
title: تحويل PPT و PPTX و ODP إلى JPG في C#
linktitle: تحويل الشرائح إلى صور JPG
type: docs
weight: 60
url: /ar/net/convert-powerpoint-to-jpg/
keywords:
- تحويل PowerPoint إلى JPG
- تحويل العرض التقديمي إلى JPG
- تحويل الشريحة إلى JPG
- تحويل PPT إلى JPG
- تحويل PPTX إلى JPG
- تحويل ODP إلى JPG
- PowerPoint إلى JPG
- العرض التقديمي إلى JPG
- الشريحة إلى JPG
- PPT إلى JPG
- PPTX إلى JPG
- ODP إلى JPG
- تحويل PowerPoint إلى JPEG
- تحويل العرض التقديمي إلى JPEG
- تحويل الشريحة إلى JPEG
- تحويل PPT إلى JPEG
- تحويل PPTX إلى JPEG
- تحويل ODP إلى JPEG
- PowerPoint إلى JPEG
- العرض التقديمي إلى JPEG
- الشريحة إلى JPEG
- PPT إلى JPEG
- PPTX إلى JPEG
- ODP إلى JPEG
- C#
- Csharp
- .NET
- Aspose.Slides
description: "تعلم كيف تحوّل شرائحك من عروض PowerPoint وOpenDocument إلى صور JPEG عالية الجودة ببضع أسطر من الشيفرة. حسّن العروض للاستخدام على الويب، المشاركة، والأرشفة. اقرأ الدليل الكامل الآن!"
---

## **نظرة عامة**

يساعد تحويل عروض PowerPoint وOpenDocument إلى صور JPG في مشاركة الشرائح، وتحسين الأداء، وتضمين المحتوى في مواقع الويب أو التطبيقات. يتيح Aspose.Slides for .NET تحويل ملفات PPTX وPPT وODP إلى صور JPEG عالية الجودة. يشرح هذا الدليل طرق التحويل المختلفة.

مع هذه الميزات، يصبح من السهل تنفيذ عارض عروضك الخاص وإنشاء صورة مصغرة لكل شريحة. قد يكون ذلك مفيدًا إذا كنت تريد حماية شرائح العرض من النسخ أو عرض العرض في وضع القراءة فقط. يتيح Aspose.Slides تحويل العرض الكامل أو شريحة محددة إلى صيغ الصور.

## **تحويل شرائح العرض إلى صور JPG**

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
1. الحصول على كائن الشريحة من النوع [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) من مجموعة [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) .
1. إنشاء صورة للشريحة باستخدام الطريقة [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5) .
1. استدعاء الطريقة [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/#save_3) على كائن الصورة. تمرير اسم ملف الإخراج وصيغة الصورة كمعاملات.

{{% alert color="primary" %}} 
**ملاحظة:** التحويل من PPT أو PPTX أو ODP إلى JPG يختلف عن التحويل إلى صيغ أخرى في Aspose.Slides .NET API. بالنسبة للصيغ الأخرى، عادةً ما تستخدم الطريقة [IPresentation.Save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/save/#save_5). ومع ذلك، لتحويل إلى JPG، تحتاج إلى استخدام الطريقة [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/#save_3).
{{% /alert %}} 
```c#
int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // إنشاء صورة الشريحة بالمقياس المحدد.
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // حفظ الصورة على القرص بتنسيق JPEG.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```


## **تحويل الشرائح إلى JPG بأبعاد مخصصة**

لتغيير أبعاد صور JPG الناتجة، يمكنك ضبط حجم الصورة بتمريره إلى الطريقة [ISlide.GetImage(Size)](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_6). يتيح لك ذلك إنشاء صور بأبعاد عرض وارتفاع محددة، مما يضمن أن الإخراج يلبي متطلباتك من حيث الدقة ونسبة العرض إلى الارتفاع. هذه المرونة مفيدة بشكل خاص عند إنشاء صور لتطبيقات الويب أو التقارير أو الوثائق، حيث يُطلب أبعاد دقيقة للصور.
```c#
Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // إنشاء صورة للشرائح بالحجم المحدد.
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // حفظ الصورة على القرص بتنسيق JPEG.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```


## **عرض التعليقات عند حفظ الشرائح كصور**

يقدم Aspose.Slides for .NET ميزة تسمح لك بعرض التعليقات على شرائح العرض عند تحويلها إلى صور JPG. تكون هذه الوظيفة مفيدة بشكل خاص للحفاظ على الملاحظات أو التعليقات أو المناقشات التي يضيفها المتعاونون في عروض PowerPoint. من خلال تمكين هذا الخيار، تضمن ظهور التعليقات في الصور المولدة، مما يجعل مراجعة ومشاركة الملاحظات أسهل دون الحاجة إلى فتح ملف العرض الأصلي.

لنفترض أن لدينا ملف عرض، "sample.pptx"، يحتوي على شريحة بها تعليقات:

![The slide with comments](slide_with_comments.png)

الكود التالي بلغة C# يحول الشريحة إلى صورة JPG مع الحفاظ على التعليقات:
```c#
int scaleX = 2;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        // ضبط الخيارات لتعليقات الشريحة.
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            CommentsPosition = CommentsPositions.Right,
            CommentsAreaWidth = 200,
            CommentsAreaColor = Color.DarkOrange                  
        }
    };

    // تحويل الشريحة الأولى إلى صورة.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        image.Save("Slide_1.jpg", ImageFormat.Jpeg);
    }
}
```


النتيجة:

![The JPG image with comments](image_with_comments.png)

## **انظر أيضًا**

اطلع على خيارات أخرى لتحويل PPT أو PPTX أو ODP إلى صور، مثل:

- [تحويل PowerPoint إلى GIF](/slides/ar/net/convert-powerpoint-to-animated-gif/)
- [تحويل PowerPoint إلى PNG](/slides/ar/net/convert-powerpoint-to-png/)
- [تحويل PowerPoint إلى TIFF](/slides/ar/net/convert-powerpoint-to-tiff/)
- [تحويل PowerPoint إلى SVG](/slides/ar/net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
لمشاهدة كيفية تحويل Aspose.Slides لـ PowerPoint إلى صور JPG، جرّب هذه المحولات المجانية عبر الإنترنت: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) و[PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 
{{% /alert %}} 

![Free Online PPTX to JPG Converter](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

توفر Aspose تطبيق ويب مجاني للتجميع يُدعى [FREE Collage web app](https://products.aspose.app/slides/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG to JPG](https://products.aspose.app/slides/collage/jpg) أو PNG إلى PNG، وإنشاء [شبكات صور](https://products.aspose.app/slides/collage/photo-grid)، وما إلى ذلك. 

باستخدام نفس المبادئ الموضحة في هذه المقالة، يمكنك تحويل الصور من صيغة إلى أخرى. لمزيد من المعلومات، راجع الصفحات التالية: تحويل [image to JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); تحويل [JPG to image](https://products.aspose.com/slides/net/conversion/jpg-to-image/); تحويل [JPG to PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/)، تحويل [PNG to JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); تحويل [PNG to SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/)، تحويل [SVG to PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يدعم هذا الأسلوب التحويل الجماعي؟**

نعم، يتيح Aspose.Slides التحويل الجماعي لعدة شرائح إلى JPG في عملية واحدة.

**هل يدعم التحويل عناصر SmartArt والرسوم البيانية والكائنات المعقدة الأخرى؟**

نعم، يقوم Aspose.Slides بعرض جميع المحتويات، بما في ذلك SmartArt والرسوم البيانية والجداول والأشكال والمزيد. ومع ذلك، قد تختلف دقة العرض قليلًا مقارنةً بـ PowerPoint، خاصةً عند استخدام خطوط مخصصة أو مفقودة.

**هل هناك أي قيود على عدد الشرائح التي يمكن معالجتها؟**

لا يفرض Aspose.Slides حدودًا صارمة على عدد الشرائح التي يمكنك معالجتها. ومع ذلك، قد تواجه أخطاء نفاد الذاكرة عند العمل مع عروض تقديمية كبيرة أو صور ذات دقة عالية.