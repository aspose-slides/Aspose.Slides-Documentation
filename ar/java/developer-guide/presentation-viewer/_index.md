---
title: عارض العروض التقديمية
type: docs
weight: 50
url: /java/presentation-viewer/
keywords: "عارض PPT PowerPoint"
description: "عارض PPT PowerPoint في جافا"
---

{{% alert color="primary" %}} 

تستخدم Aspose.Slides لجافا لإنشاء ملفات العروض التقديمية، كاملة مع الشرائح. يمكن عرض هذه الشرائح من خلال فتح العروض التقديمية باستخدام Microsoft PowerPoint. ولكن أحيانًا، قد يحتاج المطورون أيضًا إلى عرض الشرائح كصور في عارض الصور المفضل لديهم أو إنشاء عارض عروض تقديمية خاص بهم. في هذه الحالات، تتيح لك Aspose.Slides لجافا تصدير شريحة فردية إلى صورة. تصف هذه المقالة كيفية القيام بذلك.

{{% /alert %}} 

## **مثال حي**
يمكنك تجربة [**عارض Aspose.Slides**](https://products.aspose.app/slides/viewer/) تطبيق مجاني لترى ما يمكنك تنفيذه باستخدام واجهة برمجة التطبيقات Aspose.Slides:

[](https://products.aspose.app/slides/viewer/)

[![todo:image_alt_text](slides-viewer.png)](https://products.aspose.app/slides/viewer/)

## **إنشاء صورة SVG من الشريحة**
لإنشاء صورة SVG من أي شريحة مرغوبة باستخدام Aspose.Slides لجافا، يرجى اتباع الخطوات أدناه:

- أنشئ مثيلًا من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- احصل على مرجع الشريحة المرغوبة باستخدام معرفها أو فهرسها.
- احصل على صورة SVG في تدفق الذاكرة.
- احفظ تدفق الذاكرة في ملف.

```java
// Instantiate a Presentation class that represents the presentation file
Presentation pres = new Presentation("CreateSlidesSVGImage.pptx");
try {
    // Access the first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Create a memory stream object
    FileOutputStream svgStream = new FileOutputStream("Aspose_out.svg");

    // Generate SVG image of slide and save in memory stream
    sld.writeAsSvg(svgStream);

    svgStream.close();
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **إنشاء SVG مع معرفات أشكال مخصصة**
يمكن استخدام Aspose.Slides لجافا لإنشاء [SVG](https://docs.fileformat.com/page-description-language/svg/) من الشريحة مع معرف الشكل المخصص. لذلك، استخدم خاصية ID من [ISvgShape](https://reference.aspose.com/slides/java/com.aspose.slides/ISvgShape)، والتي تمثل معرفًا مخصصًا للأشكال في SVG الناتج. يمكن استخدام CustomSvgShapeFormattingController لتعيين معرف الشكل.

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
تساعدك Aspose.Slides لجافا في إنشاء صور مصغرة للشرائح. لإنشاء الصورة المصغرة لأي شريحة مرغوبة باستخدام Aspose.Slides لجافا:

1. أنشئ مثيلًا من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. احصل على مرجع لأي شريحة مرغوبة باستخدام معرفها أو فهرسها.
1. احصل على الصورة المصغرة للشريحة المراجع على مقياس محدد.
1. احفظ الصورة المصغرة بأي تنسيق صورة مرغوب.

```java
// Instantiate a Presentation class that represents the presentation file
Presentation pres = new Presentation("ThumbnailFromSlide.pptx");
try {
    // Access the first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Create a full scale image
    IImage slideImage = sld.getImage(1f, 1f);

    // Save the image to disk in JPEG format
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

1. أنشئ مثيلًا من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. احصل على مرجع لأي شريحة مرغوبة باستخدام معرفها أو فهرسها.
1. احصل على الصورة المصغرة للشريحة المراجع على مقياس محدد.
1. احفظ الصورة المصغرة بأي تنسيق صورة مرغوب.

```java
// Instantiate a Presentation class that represents the presentation file
Presentation pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
try {
    // Access the first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // User defined dimension
    int desiredX = 1200;
    int desiredY = 800;

    // Getting scaled value of X and Y
    float ScaleX = (float)(1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float)(1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;
    
    // Create a full scale image
    IImage slideImage = sld.getImage(ScaleX, ScaleY);

    // Save the image to disk in JPEG format
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    pres.dispose();
}
```

## **إنشاء صورة مصغرة من الشريحة في عرض الملاحظات**
لإنشاء الصورة المصغرة لأي شريحة مرغوبة في عرض الملاحظات باستخدام Aspose.Slides لجافا:

1. أنشئ مثيلًا من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. احصل على مرجع لأي شريحة مرغوبة باستخدام معرفها أو فهرسها.
1. احصل على الصورة المصغرة للشريحة المرجعية على مقياس محدد في عرض الملاحظات.
1. احفظ الصورة المصغرة بأي تنسيق صورة مرغوب.

تنتج الشيفرة أدناه صورة مصغرة للشرائح الأولى من عرض تقديمي في عرض الملاحظات.

```java
// Instantiate a Presentation class that represents the presentation file
Presentation pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
try {
    // Access the first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // User defined dimension
    int desiredX = 1200;
    int desiredY = 800;

    // Getting scaled value of X and Y
    float ScaleX = (float)(1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float)(1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    RenderingOptions opts = new RenderingOptions();
    opts.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);
    
    // Create a full scale image
    IImage slideImage = sld.getImage(opts, ScaleX, ScaleY);

    // Save the image to disk in JPEG format
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    pres.dispose();
}
```