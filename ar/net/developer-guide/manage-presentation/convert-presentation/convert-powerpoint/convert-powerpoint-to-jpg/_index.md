---
title: تحويل PPT و PPTX إلى JPG في .NET
linktitle: PowerPoint إلى JPG
type: docs
weight: 60
url: /ar/net/convert-powerpoint-to-jpg/
keywords:
- تحويل PowerPoint
- تحويل العرض
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى JPG
- العرض إلى JPG
- الشريحة إلى JPG
- PPT إلى JPG
- PPTX إلى JPG
- حفظ PowerPoint كـ JPG
- حفظ العرض كـ JPG
- حفظ الشريحة كـ JPG
- حفظ PPT كـ JPG
- حفظ PPTX كـ JPG
- تصدير PPT إلى JPG
- تصدير PPTX إلى JPG
- .NET
- C#
- Aspose.Slides
description: "تحويل شرائح PowerPoint (PPT، PPTX) إلى صور JPG عالية الجودة في C# باستخدام Aspose.Slides لـ .NET عبر أمثلة شفرة سريعة وموثوقة."
---
## **المقدمة**

تحويل عروض PowerPoint و OpenDocument إلى صور JPG يساعد في مشاركة الشرائح، تحسين الأداء، وإدراج المحتوى في المواقع الإلكترونية أو التطبيقات. يتيح Aspose.Slides for .NET تحويل ملفات PPTX و PPT و ODP إلى صور JPEG عالية الجودة. يشرح هذا الدليل طرق التحويل المختلفة.

مع هذه الميزات، يصبح من السهل تنفيذ عارض عروض تقديمية خاص بك وإنشاء صورة مصغرة لكل شريحة. قد يكون ذلك مفيدًا إذا أردت حماية شرائح العرض من النسخ أو عرض العرض في وضع القراءة فقط. يتيح Aspose.Slides تحويل العرض الكامل أو شريحة محددة إلى صيغ صور.

## **تحويل شرائح العرض إلى صور JPG**

إليك خطوات تحويل ملف PPT أو PPTX أو ODP إلى JPG:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) .
2. الحصول على كائن الشريحة من النوع [ISlide](https://reference.aspose.com/slides/ar/net/aspose.slides/islide) من مجموعة [Presentation.Slides](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/properties/slides) .
3. إنشاء صورة للشريحة باستخدام الطريقة [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/ar/net/aspose.slides/islide/getimage/#getimage_5) .
4. استدعاء الطريقة [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/save/#save_3) على كائن الصورة. مرّر اسم ملف الإخراج وصيغة الصورة كمعاملات.

{{% alert color="info" %}} 
**ملاحظة:** يختلف التحويل من PPT أو PPTX أو ODP إلى JPG عن التحويل إلى صيغ أخرى في Aspose.Slides .NET API. بالنسبة للصيغ الأخرى، عادةً ما تستخدم الطريقة [IPresentation.Save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/save/#save_5). ومع ذلك، لتحويل إلى JPG، يجب عليك استخدام الطريقة [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/save/#save_3). 
{{% /alert %}}

```c#
using Aspose.Slides;

int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // إنشاء صورة للشريحة بالمقياس المحدد.
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

لتغيير أبعاد صور JPG الناتجة، يمكنك ضبط حجم الصورة بتمريره إلى الطريقة [ISlide.GetImage(Size)](https://reference.aspose.com/slides/ar/net/aspose.slides/islide/getimage/#getimage_6). يتيح لك ذلك إنشاء صور بعرض وارتفاع محددين، مما يضمن أن يكون الإخراج وفق متطلباتك من الدقة والنسبة. هذه المرونة مفيدة بشكل خاص عند إنشاء صور لتطبيقات الويب أو التقارير أو الوثائق، حيث تُطلب أبعاد دقيقة للصور.

```c#
using System.Drawing;
using Aspose.Slides;

Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // إنشاء صورة لشريحة بالحجم المحدد.
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

يوفر Aspose.Slides for .NET ميزة تتيح لك عرض التعليقات على شرائح العرض عند تحويلها إلى صور JPG. هذه الوظيفة مفيدة بشكل خاص للحفاظ على الملاحظات، التعليقات، أو المناقشات التي يضيفها المتعاونون في عروض PowerPoint. بتمكين هذا الخيار، تضمن أن تكون التعليقات مرئية في الصور المُولدة، مما يسهل مراجعة ومشاركة الملاحظات دون الحاجة لفتح ملف العرض الأصلي.

لنفترض أن لدينا ملف عرض باسم "sample.pptx" يحتوي على شريحة تتضمن تعليقات:

![الشريحة مع التعليقات](slide_with_comments.png)

الكود التالي بلغة C# يحول الشريحة إلى صورة JPG مع الحفاظ على التعليقات:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

النتيجة:

![صورة JPG مع التعليقات](image_with_comments.png)

## **انظر أيضًا**

اطلع على خيارات أخرى لتحويل PPT أو PPTX أو ODP إلى صور، مثل:

- [تحويل PowerPoint إلى GIF](/slides/ar/net/convert-powerpoint-to-animated-gif/)
- [تحويل PowerPoint إلى PNG](/slides/ar/net/convert-powerpoint-to-png/)
- [تحويل PowerPoint إلى TIFF](/slides/ar/net/convert-powerpoint-to-tiff/)
- [تحويل PowerPoint إلى SVG](/slides/ar/net/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 
لرؤية كيفية تحويل Aspose.Slides لـ PowerPoint إلى صور JPG، جرّب هذه المحولات المجانية عبر الإنترنت: PowerPoint [PPTX إلى JPG](https://products.aspose.app/slides/ar/conversion/pptx-to-jpg) و [PPT إلى JPG](https://products.aspose.app/slides/ar/conversion/ppt-to-jpg). 
{{% /alert %}} 

![محول PPTX إلى JPG عبر الإنترنت مجانًا](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}
توفر Aspose تطبيق ويب [FREE Collage](https://products.aspose.app/slides/ar/collage) مجاني. باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج صور [JPG إلى JPG](https://products.aspose.app/slides/ar/collage/jpg) أو PNG إلى PNG، وإنشاء [شبكات الصور](https://products.aspose.app/slides/ar/collage/photo-grid)، وما إلى ذلك.

باستخدام نفس المبادئ الموصوفة في هذه المقالة، يمكنك تحويل الصور من صيغة إلى أخرى. لمزيد من المعلومات، راجع هذه الصفحات: تحويل [الصورة إلى JPG](https://products.aspose.com/slides/ar/net/conversion/image-to-jpg/); تحويل [JPG إلى صورة](https://products.aspose.com/slides/ar/net/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/ar/net/conversion/jpg-to-png/)، تحويل [PNG إلى JPG](https://products.aspose.com/slides/ar/net/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/ar/net/conversion/png-to-svg/)، تحويل [SVG إلى PNG](https://products.aspose.com/slides/ar/net/conversion/svg-to-png/).
{{% /alert %}}

## **الأسئلة المتكررة**

### هل تدعم هذه الطريقة التحويل الدفعي؟

نعم، يتيح Aspose.Slides التحويل الدفعي للعديد من الشرائح إلى JPG في عملية واحدة.

### هل يدعم التحويل SmartArt والمخططات وغيرها من الكائنات المعقدة؟

نعم، يقوم Aspose.Slides بتصوير جميع المحتويات، بما في ذلك SmartArt والمخططات والجداول والأشكال والمزيد. ومع ذلك، قد يختلف دقة التصوير قليلًا مقارنة بـ PowerPoint، خاصة عند استخدام خطوط مخصصة أو مفقودة.

### هل هناك أي قيود على عدد الشرائح التي يمكن معالجتها؟

لا يفرض Aspose.Slides أي حدود صارمة على عدد الشرائح التي يمكنك معالجتها. ومع ذلك، قد تواجه خطأ نفاد الذاكرة عند العمل مع عروض تقديمية ضخمة أو صور ذات دقة عالية.