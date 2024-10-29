---
title: عارض العروض التقديمية
type: docs
weight: 50
url: /ar/androidjava/presentation-viewer/
keywords: "عارض PowerPoint PPT"
description: "عارض PowerPoint PPT بلغة Java"
---

{{% alert color="primary" %}} 

تُستخدم Aspose.Slides for Android عبر Java لإنشاء ملفات العروض التقديمية، مكتملة بالشرائح. يمكن عرض هذه الشرائح عن طريق فتح العروض التقديمية باستخدام Microsoft PowerPoint. لكن في بعض الأحيان، قد يحتاج المطورون أيضًا إلى عرض الشرائح كصور في عارض الصور المفضل لديهم أو إنشاء عارض عروض تقديمية خاص بهم. في مثل هذه الحالات، تتيح لك Aspose.Slides for Android عبر Java تصدير شريحة فردية إلى صورة. تشرح هذه المقالة كيفية القيام بذلك.

{{% /alert %}} 

## **مثال حي**
يمكنك تجربة تطبيق [**عارض Aspose.Slides**](https://products.aspose.app/slides/viewer/) المجاني لرؤية ما يمكنك تنفيذه باستخدام واجهة برمجة تطبيقات Aspose.Slides:

[](https://products.aspose.app/slides/viewer/)

[![todo:image_alt_text](slides-viewer.png)](https://products.aspose.app/slides/viewer/)

## **إنشاء صورة SVG من شريحة**
لإنشاء صورة SVG من أي شريحة مرغوبة باستخدام Aspose.Slides for Android عبر Java، يرجى اتباع الخطوات التالية:

- إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class.
- الحصول على مرجع الشريحة المرغوبة باستخدام معرفها أو فهرسها.
- الحصول على صورة SVG في دفق الذاكرة.
- حفظ دفق الذاكرة إلى ملف.

```java
// إنشاء فئة Presentation تمثل ملف العرض التقديمي
Presentation pres = new Presentation("CreateSlidesSVGImage.pptx");
try {
    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إنشاء كائن دفق ذاكرة
    FileOutputStream svgStream = new FileOutputStream("Aspose_out.svg");

    // إنشاء صورة SVG للشريحة وحفظها في دفق الذاكرة
    sld.writeAsSvg(svgStream);

    svgStream.close();
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **إنشاء SVG بمعرفات أشكال مخصصة**
يمكن استخدام Aspose.Slides for Android عبر Java لإنشاء [SVG](https://docs.fileformat.com/page-description-language/svg/) من شريحة بمعرف شكل مخصص. لهذا، استخدم خاصية المعرف من [ISvgShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISvgShape)، التي تمثل معرف الشكل المخصص للأشكال في SVG المُنشأ. يمكن استخدام CustomSvgShapeFormattingController لتعيين معرف الشكل.

```java
Presentation pres = new Presentation("pptxFileName.pptx");
try {
    FileOutputStream stream = new FileOutputStream("Aspose_out.svg");
    try {
        SVGOptions svgOptions = new SVGOptions();
        svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController());

        pres.getSlides().get_Item(0).writeAsSvg(stream, svgOptions);
    } finally {
        if (stream != null) stream.close();
    }
} catch (IOException e) {
} finally {
    pres.dispose();
}
```
```java
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController()
    {
        m_shapeIndex = 0;
    }
    
    public CustomSvgShapeFormattingController(int shapeStartIndex)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```

## **إنشاء صورة مصغرة للشرائح**
تساعدك Aspose.Slides for Android عبر Java على إنشاء صور مصغرة للشرائح. لإنشاء صورة مصغرة لأي شريحة مرغوبة باستخدام Aspose.Slides for Android عبر Java:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class.
1. الحصول على مرجع لأي شريحة مرغوبة باستخدام معرفها أو فهرسها.
1. الحصول على صورة المصغرة للشريحة المرجعة على مقياس محدد.
1. حفظ صورة المصغرة في أي تنسيق صورة مرغوب.

```java
// إنشاء فئة Presentation تمثل ملف العرض التقديمي
Presentation pres = new Presentation("ThumbnailFromSlide.pptx");
try {
    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إنشاء صورة بدقة كاملة
    IImage slideImage = sld.getImage(1f, 1f);

    // حفظ الصورة على القرص بتنسيق JPEG
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    pres.dispose();
}
```

## **إنشاء صورة مصغرة بأبعاد محددة من قبل المستخدم**

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class.
1. الحصول على مرجع لأي شريحة مرغوبة باستخدام معرفها أو فهرسها.
1. الحصول على صورة المصغرة للشريحة المرجعة على مقياس محدد.
1. حفظ صورة المصغرة في أي تنسيق صورة مرغوب.

```java
// إنشاء فئة Presentation تمثل ملف العرض التقديمي
Presentation pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
try {
    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // أبعاد محددة من قبل المستخدم
    int desiredX = 1200;
    int desiredY = 800;

    // الحصول على القيمة المقياس لـ X و Y
    float ScaleX = (float)(1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float)(1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;
    
    // إنشاء صورة بدقة كاملة
    IImage slideImage = sld.getImage(ScaleX, ScaleY);

    // حفظ الصورة على القرص بتنسيق JPEG
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    pres.dispose();
}
```

## **إنشاء صورة مصغرة من شريحة في عرض شرائح الملاحظات**
لإنشاء صورة مصغرة لأي شريحة مرغوبة في عرض شرائح الملاحظات باستخدام Aspose.Slides for Android عبر Java:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class.
1. الحصول على مرجع لأي شريحة مرغوبة باستخدام معرفها أو فهرسها.
1. الحصول على صورة المصغرة للشريحة المرجعة على مقياس محدد في عرض شرائح الملاحظات.
1. حفظ صورة المصغرة في أي تنسيق صورة مرغوب.

يؤدي مقتطف الشيفرة أدناه إلى إنتاج صورة مصغرة للشريحة الأولى من عرض تقديمي في عرض شريحة الملاحظات.

```java
// إنشاء فئة Presentation تمثل ملف العرض التقديمي
Presentation pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
try {
    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // أبعاد محددة من قبل المستخدم
    int desiredX = 1200;
    int desiredY = 800;

    // الحصول على القيمة المقياس لـ X و Y
    float ScaleX = (float)(1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float)(1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    RenderingOptions opts = new RenderingOptions();
    opts.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);
    
    // إنشاء صورة بدقة كاملة
    IImage slideImage = sld.getImage(opts, ScaleX, ScaleY);

    // حفظ الصورة على القرص بتنسيق JPEG
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    pres.dispose();
}
```