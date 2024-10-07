---
title: تحويل PowerPoint إلى JPG في C#
linktitle: تحويل PowerPoint PPT إلى JPG
type: docs
weight: 60
url: /net/convert-powerpoint-to-jpg/
keywords: 
- تحويل عرض PowerPoint
- JPG
- JPEG
- PowerPoint إلى JPG
- PowerPoint إلى JPEG
- PPT إلى JPG
- PPTX إلى JPG
- PPT إلى JPEG
- PPTX إلى JPEG
- C#
- Csharp
- .NET
- Aspose.Slides
description: "تحويل PowerPoint إلى JPG في C# أو .NET. حفظ الشريحة كصورة JPG"
---

## **نظرة عامة**

توضح هذه المقالة كيفية تحويل عرض PowerPoint إلى تنسيق JPG باستخدام C#. تغطي المواضيع التالية:

- [C# تحويل PowerPoint إلى JPG](#convert-powerpoint-pptpptx-to-jpg)
- [C# تحويل PPT إلى JPG](#convert-powerpoint-pptpptx-to-jpg)
- [C# تحويل PPTX إلى JPG](#convert-powerpoint-pptpptx-to-jpg)
- [C# تحويل ODP إلى JPG](#convert-powerpoint-pptpptx-to-jpg)
- [C# تحويل شريحة PowerPoint إلى صورة](#convert-powerpoint-pptpptx-to-jpg)

## **C# PowerPoint إلى JPG**

لاستخدام كود C# لتحويل PowerPoint إلى JPG، يرجى الاطلاع على القسم أدناه أي [تحويل PowerPoint إلى JPG](#convert-powerpoint-pptpptx-to-jpg). يمكن أن يقوم الكود بتحميل عدد من التنسيقات مثل PPT وPPTX وODP في كائن Presentation ثم حفظ صورة مصغرة لشريحته في تنسيق JPG. يتم مناقشة تحويلات PowerPoint إلى صورة الأخرى التي تشبه PNG وBMP وTIFF وSVG في هذه المقالات.

- [C# PowerPoint إلى PNG](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)
- [C# PowerPoint إلى BMP](#convert-powerpoint-pptpptx-to-jpg)
- [C# PowerPoint إلى TIFF](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPoint إلى SVG](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **حول تحويل PowerPoint إلى JPG**
مع [**Aspose.Slides .NET API**](https://products.aspose.com/slides/net/)  يمكنك تحويل عرض PowerPoint PPT أو PPTX إلى صورة JPG. من الممكن أيضًا تحويل PPT/PPTX إلى BMP أو PNG أو SVG. مع هذه الميزات، من السهل تنفيذ عارض العروض التقديمية الخاص بك، وإنشاء الصورة المصغرة لكل شريحة. قد يكون هذا مفيدًا إذا كنت ترغب في حماية شرائح العرض من حقوق الطبع والنشر، وعرض العرض في وضع القراءة فقط. يسمح Aspose.Slides بتحويل العرض التقديمي الكامل أو شريحة معينة إلى تنسيقات الصور.

{{% alert color="primary" %}} 

لرؤية كيفية تحويل Aspose.Slides PowerPoint إلى صور JPG، قد ترغب في تجربة هذه المحولات المجانية عبر الإنترنت: PowerPoint [PPTX إلى JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) و[PPT إلى JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **تحويل PowerPoint PPT/PPTX إلى JPG**
إليك الخطوات لتحويل PPT/PPTX إلى JPG:

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. احصل على كائن الشريحة من نوع [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) من مجموعة [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides).
3. أنشئ صورة مصغرة لكل شريحة ثم قم بتحويلها إلى JPG. تستخدم طريقة [**ISlide.GetImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5) للحصول على صورة مصغرة لشريحة، حيث تُرجع كائن [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=netframework-4.8) كنتيجة. يجب أن تُستدعى طريقة [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5) من الشريحة المطلوبة من نوع [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide)، ويتم تمرير مقاييس الصورة المصغرة الناتجة إلى الطريقة.
4. بعد الحصول على صورة الشريحة المصغرة، استدعِ [**Image.Save(string filename, ImageFormat format)**](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.image.save?view=netframework-4.8) من كائن الصورة المصغرة. تمرير اسم الملف الناتج وتنسيق الصورة إلى تلك الطريقة.

{{% alert color="primary" %}} 
**ملاحظة**: تحويل PPT/PPTX إلى JPG يختلف عن التحويل إلى أنواع أخرى في Aspose.Slides .NET API. بالنسبة لأنواع أخرى، عادةً ما تستخدم [**IPresentation.SaveMethod(String, SaveFormat, ISaveOptions)** ](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5) لكن هنا تحتاج إلى [**Image.Save(string filename, ImageFormat format)**](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.image.save?view=netframework-4.8).
{{% /alert %}} 

```c#
const int imageScale = 1;

using (Presentation pres = new Presentation("PowerPoint-Presentation.ppt"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // Creates a full scale image
        using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
        {
            // Saves the image to disk in JPEG format
			string imageFileName = string.Format("Slide_{0}.jpg", slide.SlideNumber);
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **تحويل PowerPoint PPT/PPTX إلى JPG بأبعاد مخصصة**
لتغيير أبعاد الصورة المصغرة الناتجة وصورة JPG، يمكنك تعيين قيم *ScaleX* و*ScaleY* عن طريق تمريرها إلى طريقة [**ISlide.GetImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5):

```c#
using (Presentation pres = new Presentation("PowerPoint-Presentation.pptx"))
{
    // Defines dimensions
    int desiredX = 1200;
    int desiredY = 800;

    // Gets scaled values of X and Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    foreach (ISlide slide in pres.Slides)
    {
        // Creates a full scale image
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // Saves the image to disk in JPEG format
			string imageFileName = string.Format("Slide_{0}.jpg", slide.SlideNumber);
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```


## **عرض التعليقات عند حفظ العرض التقديمي كصورة**
يوفر Aspose.Slides لـ .NET ميزة تتيح لك عرض التعليقات في شرائح العرض التقديمي عندما تقوم بتحويل هذه الشرائح إلى صور. يوضح هذا الكود C# العملية:

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,
            CommentsAreaColor = Color.Red,
            CommentsAreaWidth = 200,
            CommentsPosition = CommentsPositions.Right
        }
    };

    using (IImage image = presentation.Slides[0].GetImage(options))
    {
        image.Save("OutPresBitmap.png", ImageFormat.Png);
    }

    System.Diagnostics.Process.Start("OutPresBitmap.png");
}
```

{{% alert title="نصيحة" color="primary" %}}

يقدم Aspose تطبيق ويب [مجانًا لتجميع الصور](https://products.aspose.app/slides/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو PNG إلى PNG، وإنشاء [شبكات صور](https://products.aspose.app/slides/collage/photo-grid)، وما إلى ذلك. 

باستخدام نفس المبادئ الموضحة في هذه المقالة، يمكنك تحويل الصور من تنسيق إلى آخر. لمزيد من المعلومات، انتقل إلى هذه الصفحات: تحويل [صورة إلى JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/)؛ تحويل [JPG إلى صورة](https://products.aspose.com/slides/net/conversion/jpg-to-image/)؛ تحويل [JPG إلى PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/)؛ تحويل [PNG إلى JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/)؛ تحويل [PNG إلى SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/)؛ تحويل [SVG إلى PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).

{{% /alert %}}

## **انظر أيضًا**

راجع خيارات أخرى لتحويل PPT/PPTX إلى صورة مثل:

- [تحويل PPT/PPTX إلى SVG](/slides/net/render-a-slide-as-an-svg-image/).