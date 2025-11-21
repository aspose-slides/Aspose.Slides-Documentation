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
description: "تحويل شرائح PowerPoint (PPT، PPTX) إلى صور JPG عالية الجودة في C# باستخدام Aspose.Slides لـ .NET باستخدام أمثلة كود سريعة وموثوقة."
---

## **نظرة عامة**

يساعد تحويل عروض PowerPoint وOpenDocument إلى صور JPG على مشاركة الشرائح، تحسين الأداء، وتضمين المحتوى في مواقع الويب أو التطبيقات. يتيح Aspose.Slides for .NET تحويل ملفات PPTX وPPT وODP إلى صور JPEG عالية الجودة. يشرح هذا الدليل طرق التحويل المختلفة.

مع هذه الميزات، من السهل تنفيذ عارض عروض تقديمية خاص بك وإنشاء صورة مصغرة لكل شريحة. قد يكون ذلك مفيدًا إذا كنت ترغب في حماية شرائح العرض من النسخ أو عرض العرض بوضع القراءة فقط. يتيح Aspose.Slides تحويل العرض بالكامل أو شريحة محددة إلى صيغ الصور.

## **تحويل شرائح العرض إلى صور JPG**

إليك الخطوات لتحويل ملف PPT أو PPTX أو ODP إلى JPG:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الحصول على كائن الشريحة من النوع [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) من مجموعة [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides).
3. إنشاء صورة للشريحة باستخدام الطريقة [ISlide.GetImage(float,float)](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5).
4. استدعاء الطريقة [IImage.Save(string,ImageFormat)](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/#save_3) على كائن الصورة. مرر اسم ملف الإخراج وصيغة الصورة كمعاملات.

{{% alert color="primary" %}} 
**ملاحظة:** يختلف التحويل من PPT أو PPTX أو ODP إلى JPG عن التحويل إلى صيغ أخرى في Aspose.Slides .NET API. بالنسبة للصيغ الأخرى، عادةً ما تستخدم الطريقة [IPresentation.Save(String,SaveFormat,ISaveOptions)](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/save/#save_5). ومع ذلك، بالنسبة للتحويل إلى JPG، تحتاج إلى استخدام الطريقة [IImage.Save(string,ImageFormat)](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/#save_3).
{{% /alert %}} 
```c#
int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // إنشاء صورة للشريحة بالمقياس المحدد.
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

لتغيير أبعاد صور JPG الناتجة، يمكنك ضبط حجم الصورة بتمريره إلى الطريقة [ISlide.GetImage(Size)](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_6). يتيح لك ذلك إنشاء صور بأبعاد عرض وارتفاع محددة، مما يضمن أن المخرجات تلبي متطلباتك من حيث الدقة ونسبة الطول إلى العرض. هذه المرونة مفيدة بشكل خاص عند إنشاء صور لتطبيقات الويب أو التقارير أو الوثائق، حيث تُطلب أبعاد صورة دقيقة.
```c#
Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // إنشاء صورة للشريحة بالحجم المحدد.
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // حفظ الصورة إلى القرص بتنسيق JPEG.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```


## **تضمين التعليقات عند حفظ الشرائح كصور**

يوفر Aspose.Slides for .NET ميزة تسمح لك بتضمين التعليقات على شرائح العرض عند تحويلها إلى صور JPG. تُعد هذه الوظيفة مفيدة جدًا لحفظ الملاحظات أو التعليقات أو المناقشات التي أضافها المتعاونون في عروض PowerPoint. من خلال تمكين هذا الخيار، تضمن ظهور التعليقات في الصور المولدة، مما يسهل مراجعة ومشاركة الملاحظات دون الحاجة إلى فتح ملف العرض الأصلي.

لنفترض أن لدينا ملف عرض باسم "sample.pptx" يحتوي على شريحة بها تعليقات:

![الشريحة مع التعليقات](slide_with_comments.png)

الكود C# التالي يحول الشريحة إلى صورة JPG مع الحفاظ على التعليقات:
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


النتيجة:

![صورة JPG مع التعليقات](image_with_comments.png)

## **أنظر أيضًا**

انظر خيارات أخرى لتحويل PPT أو PPTX أو ODP إلى صور، مثل:

- [Convert PowerPoint to GIF](/slides/ar/net/convert-powerpoint-to-animated-gif/)
- [Convert PowerPoint to PNG](/slides/ar/net/convert-powerpoint-to-png/)
- [Convert PowerPoint to TIFF](/slides/ar/net/convert-powerpoint-to-tiff/)
- [Convert PowerPoint to SVG](/slides/ar/net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
لرؤية كيفية تحويل Aspose.Slides لملفات PowerPoint إلى صور JPG، جرّب هذه المحولات المجانية عبر الإنترنت: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) و[PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 
{{% /alert %}} 

![محول مجاني عبر الإنترنت من PPTX إلى JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}
توفر Aspose تطبيق ويب مجاني لإنشاء الكولاج [FREE Collage web app](https://products.aspose.app/slides/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG to JPG](https://products.aspose.app/slides/collage/jpg) أو PNG إلى PNG، إنشاء [شبكات صور](https://products.aspose.app/slides/collage/photo-grid)، وما إلى ذلك.

باستخدام المبادئ نفسها الموضحة في هذه المقالة، يمكنك تحويل الصور من صيغة إلى أخرى. للمزيد من المعلومات، راجع الصفحات التالية: تحويل [image to JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); تحويل [JPG to image](https://products.aspose.com/slides/net/conversion/jpg-to-image/); تحويل [JPG to PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/)، تحويل [PNG to JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); تحويل [PNG to SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/)، تحويل [SVG to PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يدعم هذا الأسلوب التحويل على دفعات؟**

نعم، يتيح Aspose.Slides التحويل على دفعات لعدة شرائح إلى JPG في عملية واحدة.

**هل يدعم التحويل SmartArt والرسوم البيانية والكائنات المعقدة الأخرى؟**

نعم، يقوم Aspose.Slides بتصوير كل المحتوى، بما في ذلك SmartArt والرسوم البيانية والجداول والأشكال وغيرها. ومع ذلك، قد تختلف دقة التصوير قليلاً مقارنةً بـ PowerPoint، خاصةً عند استخدام خطوط مخصصة أو مفقودة.

**هل هناك أي قيود على عدد الشرائح التي يمكن معالجتها؟**

لا يفرض Aspose.Slides حدًا صارمًا على عدد الشرائح التي يمكنك معالجتها. ومع ذلك، قد تواجه خطأ نفاد الذاكرة عند العمل على عروض تقديمية كبيرة أو صور ذات دقة عالية.