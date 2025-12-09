---
title: تحويل ملفات PPT و PPTX إلى JPG في .NET
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
description: "تحويل شرائح PowerPoint (PPT، PPTX) إلى صور JPG عالية الجودة باستخدام C# و Aspose.Slides لـ .NET مع أمثلة شفرة سريعة وموثوقة."
---

## **نظرة عامة**

يساعد تحويل عروض PowerPoint وOpenDocument إلى صور JPG في مشاركة الشرائح، تحسين الأداء، وإدماج المحتوى في المواقع أو التطبيقات. يتيح Aspose.Slides for .NET تحويل ملفات PPTX وPPT وODP إلى صور JPEG عالية الجودة. يشرح هذا الدليل الطرق المختلفة للتحويل.

مع هذه الميزات، يصبح من السهل تنفيذ عارض عروض تقديمية خاص بك وإنشاء صورة مصغرة لكل شريحة. قد يكون ذلك مفيدًا إذا أردت حماية الشرائح من النسخ أو عرض العرض في وضع القراءة فقط. يتيح Aspose.Slides تحويل العرض الكامل أو شريحة معينة إلى صيغ صورة.

## **تحويل شرائح العرض إلى صور JPG**

إليك الخطوات لتحويل ملف PPT أو PPTX أو ODP إلى JPG:

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. احصل على عنصر الشريحة من النوع [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) عبر مجموعة [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides).
1. أنشئ صورة للشريحة باستخدام الطريقة [ISlide.GetImage(float,float)](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5).
1. استدعِ الطريقة [IImage.Save(string,ImageFormat)](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/#save_3) على كائن الصورة. مرّر اسم ملف الإخراج وصيغة الصورة كمعاملين.

{{% alert color="primary" %}} 

**ملاحظة:** يختلف تحويل PPT أو PPTX أو ODP إلى JPG عن التحويل إلى صيغ أخرى في Aspose.Slides .NET API. بالنسبة للصيغ الأخرى، عادةً ما تستخدم الطريقة [IPresentation.Save(String,SaveFormat,ISaveOptions)](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/save/#save_5). ومع ذلك، للتحويل إلى JPG، يجب استخدام الطريقة [IImage.Save(string,ImageFormat)](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/#save_3).

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
            // حفظ الصورة إلى القرص بتنسيق JPEG.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```


## **تحويل الشرائح إلى JPG بأبعاد مخصصة**

لتغيير أبعاد صور JPG الناتجة، يمكنك تعيين حجم الصورة بتمريره إلى الطريقة [ISlide.GetImage(Size)](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_6). يتيح لك ذلك إنشاء صور بعرض وارتفاع محددين، لضمان توافق النتيجة مع متطلبات الدقة والنسبة الباعية. هذه المرونة مفيدة خاصة عند إنشاء صور لتطبيقات الويب أو التقارير أو الوثائق التي تتطلب أبعادًا دقيقة.

```c#
Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // إنشاء صورة الشريحة بالحجم المحدد.
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // حفظ الصورة إلى القرص بتنسيق JPEG.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```


## **عرض التعليقات عند حفظ الشرائح كصور**

يوفر Aspose.Slides for .NET ميزة تسمح لك بعرض التعليقات على شرائح العرض عند تحويلها إلى صور JPG. هذه الوظيفة مفيدة بشكل خاص للحفاظ على الحواشي، الملاحظات أو المناقشات التي يضيفها المتعاونون في عروض PowerPoint. من خلال تمكين هذا الخيار، تضمن ظهور التعليقات في الصور المولدة، مما يسهل مراجعة ومشاركة الملاحظات دون الحاجة لفتح ملف العرض الأصلي.

لنفترض أن لدينا ملف عرض "sample.pptx" يحتوي على شريحة بها تعليقات:

![الشريحة مع التعليقات](slide_with_comments.png)

الكود التالي بلغة C# يحول الشريحة إلى صورة JPG مع الحفاظ على التعليقات:
```c#
int scaleX = 2;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        // تعيين الخيارات لتعليقات الشريحة.
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


الناتج:

![صورة JPG مع التعليقات](image_with_comments.png)

## **انظر أيضًا**

اطلع على خيارات أخرى لتحويل PPT أو PPTX أو ODP إلى صور، مثل:

- [تحويل PowerPoint إلى GIF](/slides/ar/net/convert-powerpoint-to-animated-gif/)
- [تحويل PowerPoint إلى PNG](/slides/ar/net/convert-powerpoint-to-png/)
- [تحويل PowerPoint إلى TIFF](/slides/ar/net/convert-powerpoint-to-tiff/)
- [تحويل PowerPoint إلى SVG](/slides/ar/net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

لرؤية كيفية تحويل Aspose.Slides لملفات PowerPoint إلى صور JPG، جرّب هذه المحولات المجانية على الإنترنت: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) و[PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

![محول مجاني على الإنترنت من PPTX إلى JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

يوفر Aspose تطبيق ويب مجاني لإنشاء الكولاج [FREE Collage web app](https://products.aspose.app/slides/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو PNG إلى PNG، إنشاء [شبكات صور](https://products.aspose.app/slides/collage/photo-grid)، وغيرها.

باستخدام نفس المبادئ الموضحة في هذه المقالة، يمكنك تحويل الصور من صيغة إلى أخرى. للمزيد من المعلومات، اطلع على الصفحات التالية: تحويل [صورة إلى JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); تحويل [JPG إلى صورة](https://products.aspose.com/slides/net/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/)، تحويل [PNG إلى JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/)، تحويل [SVG إلى PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).

{{% /alert %}}

## **الأسئلة المتكررة**

**هل يدعم هذا الأسلوب التحويل على دفعات؟**

نعم، يتيح Aspose.Slides التحويل على دفعات لعدة شرائح إلى JPG في عملية واحدة.

**هل يدعم التحويل كائنات SmartArt والرسوم البيانية والكائنات المعقدة الأخرى؟**

نعم، يقوم Aspose.Slides بمعالجة جميع المحتويات، بما في ذلك SmartArt والرسوم البيانية والجداول والأشكال وغيرها. قد تختلف دقة العرض قليلًا مقارنةً بـ PowerPoint، خاصةً عند استخدام خطوط مخصصة أو مفقودة.

**هل هناك أي قيود على عدد الشرائح التي يمكن معالجتها؟**

لا يفرض Aspose.Slides حدودًا صارمة على عدد الشرائح التي يمكنك معالجتها. إلا أنه قد تواجه خطأ نفاد الذاكرة عند العمل مع عروض تقديمية كبيرة أو صور عالية الدقة.