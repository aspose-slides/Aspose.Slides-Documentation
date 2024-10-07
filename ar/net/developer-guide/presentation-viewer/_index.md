---
title: عارض العروض التقديمية
type: docs
weight: 50
url: /net/presentation-viewer/
keywords: 
- عرض تقديمية PowerPoint
- عرض ppt
- عرض PPTX
- C#
- Csharp
- Aspose.Slides لـ .NET
description: "عرض عروض PowerPoint في C# أو .NET"
---



استخدام Aspose.Slides لـ .NET لإنشاء ملفات العروض التقديمية، مكتملة بالشرائح. يمكن عرض هذه الشرائح عن طريق فتح العروض باستخدام Microsoft PowerPoint. لكن في بعض الأحيان، قد يحتاج المطورون أيضًا إلى عرض الشرائح كصور في عارض الصور المفضل لديهم أو إنشاء عارض تقديماتهم الخاصة. في مثل هذه الحالات، يتيح لك Aspose.Slides لـ .NET تصدير شريحة فردية إلى صورة. تصف هذه المقالة كيفية القيام بذلك. 
## **مثال حي**
يمكنك تجربة [**عارض Aspose.Slides**](https://products.aspose.app/slides/viewer/) تطبيق مجاني لرؤية ما يمكنك تنفيذه باستخدام واجهة برمجة تطبيقات Aspose.Slides:

![powerpoint-in-aspose-viewer](powerpoint-in-aspose-viewer.png)

## **إنشاء صورة SVG من الشريحة**
لإنشاء صورة SVG من أي شريحة مطلوبة باستخدام Aspose.Slides.PPTX لـ .NET، يرجى اتباع الخطوات أدناه:

- أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- احصل على مرجع الشريحة المطلوبة باستخدام معرفها أو فهرسها.
- احصل على صورة SVG في دفق الذاكرة.
- احفظ دفق الذاكرة في ملف.

```c#
// إنشاء مثيل من فئة Presentation تمثل ملف العرض التقديمي

using (Presentation pres = new Presentation("CreateSlidesSVGImage.pptx"))
{

    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // إنشاء كائن دفق ذاكرة
    MemoryStream SvgStream = new MemoryStream();

    // إنشاء صورة SVG من الشريحة وحفظها في دفق الذاكرة
    sld.WriteAsSvg(SvgStream);
    SvgStream.Position = 0;

    // حفظ دفق الذاكرة في ملف
    using (Stream fileStream = System.IO.File.OpenWrite("Aspose_out.svg"))
    {
        byte[] buffer = new byte[8 * 1024];
        int len;
        while ((len = SvgStream.Read(buffer, 0, buffer.Length)) > 0)
        {
            fileStream.Write(buffer, 0, len);
        }

    }
    SvgStream.Close();
}
```


## **إنشاء SVG بمعرفات شكل مخصصة**
يمكن استخدام Aspose.Slides لـ .NET لإنشاء [SVG ](https://docs.fileformat.com/page-description-language/svg/)من الشريحة بمعرف شكل مخصص. للقيام بذلك، استخدم خاصية ID من [ISvgShape](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape)، التي تمثل معرف الشكل المخصص في SVG الناتج. يمكن استخدام CustomSvgShapeFormattingController لتعيين معرف الشكل.

```c#
using (Presentation pres = new Presentation("pptxFileName.pptx"))
{
    using (FileStream stream = new FileStream(outputPath, FileMode.OpenOrCreate))
    {
        SVGOptions svgOptions = new SVGOptions
        {
            ShapeFormattingController = new CustomSvgShapeFormattingController()
        };

        pres.Slides[0].WriteAsSvg(stream, svgOptions);
    }
}
```



```c#
class CustomSvgShapeFormattingController : ISvgShapeFormattingController
{
	private int m_shapeIndex;
	
	public CustomSvgShapeFormattingController(int shapeStartIndex = 0)
	{
		m_shapeIndex = shapeStartIndex;
	}

	public void FormatShape(ISvgShape svgShape, IShape shape)
	{
		svgShape.Id = string.Format("shape-{0}", m_shapeIndex++);
	}
}
```


## **إنشاء صورة مصغرة للشرائح**
يساعدك Aspose.Slides لـ .NET في إنشاء صور مصغرة للشرائح. لإنشاء الصورة المصغرة لأي شريحة مطلوبة باستخدام Aspose.Slides لـ .NET:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. احصل على مرجع لأي شريحة مطلوبة باستخدام معرفها أو فهرسها.
1. احصل على صورة مصغرة للشريحة المشار إليها على مقياس محدد.
1. احفظ الصورة المصغرة في أي تنسيق صورة مطلوب.

```c#
// إنشاء مثيل من فئة Presentation تمثل ملف العرض التقديمي
using (Presentation pres = new Presentation("ThumbnailFromSlide.pptx"))
{
    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // إنشاء صورة بحجم كامل
    using (IImage image = sld.GetImage(1f, 1f))
    {
        // حفظ الصورة على القرص في تنسيق JPEG
        image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    }
}
```


## **إنشاء صورة مصغرة بأبعاد معرفها المستخدم**
1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. احصل على مرجع لأي شريحة مطلوبة باستخدام معرفها أو فهرسها.
1. احصل على صورة مصغرة للشريحة المشار إليها على مقياس محدد.
1. احفظ الصورة المصغرة في أي تنسيق صورة مطلوب.

```c#
// إنشاء مثيل من فئة Presentation تمثل ملف العرض التقديمي
using (Presentation pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx"))
{

    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // أبعاد معرفها المستخدم
    int desiredX = 1200;
    int desiredY = 800;

    // الحصول على القيم المتدرجة من X و Y
    float ScaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float ScaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;


    // إنشاء صورة بحجم كامل
    using (IImage image = sld.GetImage(ScaleX, ScaleY))
    {
        // حفظ الصورة على القرص في تنسيق JPEG
        image.Save("Thumbnail2_out.jpg", ImageFormat.Jpeg);
    }
}
```


## **إنشاء صورة مصغرة من الشريحة في عرض الملاحظات**
لإنشاء صورة مصغرة لأي شريحة مطلوبة في عرض الملاحظات باستخدام Aspose.Slides لـ .NET:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. احصل على مرجع لأي شريحة مطلوبة باستخدام معرفها أو فهرسها.
1. احصل على صورة مصغرة للشريحة المشار إليها على مقياس محدد في عرض الملاحظات.
1. احفظ الصورة المصغرة في أي تنسيق صورة مطلوب.

الكود أدناه ينتج صورة مصغرة للشريحة الأولى من العرض في عرض الملاحظات.

```c#
// إنشاء مثيل من فئة Presentation تمثل ملف العرض التقديمي
using (Presentation pres = new Presentation("ThumbnailFromSlideInNotes.pptx"))
{
    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // أبعاد معرفها المستخدم
    int desiredX = 1200;
    int desiredY = 800;

    // الحصول على القيم المتدرجة من X و Y
    float ScaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float ScaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    // إنشاء صورة بحجم كامل                
    using (IImage image = sld.GetImage(ScaleX, ScaleY))
    {
        // حفظ الصورة على القرص في تنسيق JPEG
        image.Save("Notes_tnail_out.jpg", ImageFormat.Jpeg);
    }
}
```