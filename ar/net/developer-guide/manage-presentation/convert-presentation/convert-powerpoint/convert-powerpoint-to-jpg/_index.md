---
title: تحويل PPT و PPTX إلى JPG في .NET
linktitle: PowerPoint إلى JPG
type: docs
weight: 60
url: /ar/net/convert-powerpoint-to-jpg/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى JPG
- العرض التقديمي إلى JPG
- الشريحة إلى JPG
- PPT إلى JPG
- PPTX إلى JPG
- حفظ PowerPoint كـ JPG
- حفظ العرض التقديمي كـ JPG
- حفظ الشريحة كـ JPG
- حفظ PPT كـ JPG
- حفظ PPTX كـ JPG
- تصدير PPT إلى JPG
- تصدير PPTX إلى JPG
- .NET
- C#
- Aspose.Slides
description: "تحويل شرائح PowerPoint (PPT، PPTX) إلى صور JPG عالية الجودة في C# باستخدام Aspose.Slides لـ .NET مع أمثلة برمجية سريعة وموثوقة."
---

## **Overview**

يساعد تحويل عروض PowerPoint وOpenDocument إلى صور JPG على مشاركة الشرائح، وتحسين الأداء، وتضمين المحتوى في المواقع الإلكترونية أو التطبيقات. يتيح Aspose.Slides for .NET تحويل ملفات PPTX وPPT وODP إلى صور JPEG عالية الجودة. يشرح هذا الدليل طرق التحويل المختلفة.

مع هذه الميزات، يصبح من السهل تنفيذ عارض عروض تقديمية خاص بك وإنشاء صورة مصغرة لكل شريحة. قد يكون ذلك مفيدًا إذا كنت ترغب في حماية شرائح العرض من النسخ أو عرض العرض في وضع القراءة فقط. يتيح Aspose.Slides تحويل العرض بالكامل أو شريحة معينة إلى صيغ الصور.

## **Convert Presentation Slides to JPG Images**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الحصول على كائن الشريحة من النوع [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) من مجموعة [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides).
3. إنشاء صورة للشريحة باستخدام الطريقة [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5).
4. استدعاء الطريقة [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/#save_3) على كائن الصورة. مرّر اسم ملف الإخراج وصيغة الصورة كوسيطات.

{{% alert color="primary" %}} 
**Note:** يختلف تحويل PPT أو PPTX أو ODP إلى JPG عن التحويل إلى تنسيقات أخرى في Aspose.Slides .NET API. بالنسبة للتنسيقات الأخرى، عادةً ما تستخدم الطريقة [IPresentation.Save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/save/#save_5). ومع ذلك، لتحويل إلى JPG، تحتاج إلى استخدام الطريقة [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/#save_3).
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
            // حفظ الصورة إلى القرص بصيغة JPEG.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```


## **Convert Slides to JPG with Customized Dimensions**

لتغيير أبعاد صور JPG الناتجة، يمكنك ضبط حجم الصورة بتمريره إلى الطريقة [ISlide.GetImage(Size)](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_6). يتيح لك ذلك إنشاء صور بعرض وارتفاع محددين، مما يضمن أن يكون الناتج مطابقًا لمتطلباتك من حيث الدقة ونسبة الأبعاد. هذه المرونة مفيدة بشكل خاص عند إنشاء صور لتطبيقات الويب أو التقارير أو الوثائق، حيث يُطلب أبعاد صور دقيقة.
```c#
Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // إنشاء صورة الشريحة بالحجم المحدد.
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // حفظ الصورة إلى القرص بصيغة JPEG.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```


## **Render Comments When Saving Slides as Images**

يوفر Aspose.Slides for .NET ميزة تتيح لك عرض التعليقات على شرائح العرض عند تحويلها إلى صور JPG. هذه الوظيفة مفيدة بشكل خاص للحفاظ على التعليقات، والملاحظات، أو المناقشات التي أضافها المتعاونون في عروض PowerPoint. بتمكين هذا الخيار، تضمن ظهور التعليقات في الصور المولدة، مما يسهل مراجعة ومشاركة الملاحظات دون الحاجة لفتح ملف العرض الأصلي.

لنفترض أن لدينا ملف عرض، "sample.pptx"، يحتوي على شريحة بها تعليقات:
![الشريحة مع التعليقات](slide_with_comments.png)

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
![صورة JPG مع التعليقات](image_with_comments.png)

## **See Also**

انظر خيارات أخرى لتحويل PPT أو PPTX أو ODP إلى صور، مثل:
- [تحويل PowerPoint إلى GIF](/slides/ar/net/convert-powerpoint-to-animated-gif/)
- [تحويل PowerPoint إلى PNG](/slides/ar/net/convert-powerpoint-to-png/)
- [تحويل PowerPoint إلى TIFF](/slides/ar/net/convert-powerpoint-to-tiff/)
- [تحويل PowerPoint إلى SVG](/slides/ar/net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
لرؤية كيفية تحويل Aspose.Slides لـ PowerPoint إلى صور JPG، جرّب هذه المحولات المجانية عبر الإنترنت: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) و[PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 
{{% /alert %}} 

![محول PPTX إلى JPG عبر الإنترنت مجاني](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}
توفر Aspose تطبيق ويب مجاني لتجميع الصور [تطبيق كولاج مجاني على الويب](https://products.aspose.app/slides/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج صور [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو PNG إلى PNG، وإنشاء [شبكات صور](https://products.aspose.app/slides/collage/photo-grid)، وما إلى ذلك.

باستخدام نفس المبادئ الموصوفة في هذه المقالة، يمكنك تحويل الصور من تنسيق إلى آخر. للمزيد من المعلومات، راجع هذه الصفحات: تحويل [صورة إلى JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); تحويل [JPG إلى صورة](https://products.aspose.com/slides/net/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), تحويل [PNG إلى JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), تحويل [SVG إلى PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).
{{% /alert %}}

## **FAQ**

**هل يدعم هذا الأسلوب التحويل على دفعات؟**

نعم، يتيح Aspose.Slides تحويل دفعة من عدة شرائح إلى JPG في عملية واحدة.

**هل يدعم التحويل عناصر SmartArt والمخططات وغيرها من الكائنات المعقدة؟**

نعم، يقوم Aspose.Slides بعرض جميع المحتويات، بما في ذلك SmartArt والمخططات والجداول والأشكال وأكثر. ومع ذلك، قد تختلف دقة العرض قليلاً مقارنةً بـ PowerPoint، خاصةً عند استخدام خطوط مخصصة أو مفقودة.

**هل هناك أي قيود على عدد الشرائح التي يمكن معالجتها؟**

لا يفرض Aspose.Slides نفسه أي حدود صارمة على عدد الشرائح التي يمكنك معالجتها. ومع ذلك، قد تواجه خطأ نفاد الذاكرة عند العمل على عروض كبيرة أو صور عالية الدقة.