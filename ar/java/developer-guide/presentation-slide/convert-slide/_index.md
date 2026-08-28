---
title: تحويل شرائح العروض إلى صور في Java
linktitle: شريحة إلى صورة
type: docs
weight: 35
url: /ar/java/convert-slide/
keywords:
- تحويل شريحة
- تصدير شريحة
- شريحة إلى صورة
- حفظ الشريحة كصورة
- شريحة إلى EMF
- شريحة إلى PNG
- شريحة إلى JPEG
- شريحة إلى صورة نقطية
- شريحة إلى TIFF
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تحويل الشرائح من عروض PPT وPPTX وODP إلى صيغ PNG وJPEG وGIF وTIFF وEMF وغيرها من صيغ الصور في Java باستخدام Aspose.Slides."
---
## **المقدمة**

يمكن لـ Aspose.Slides for Java تحويل الشرائح الفردية من عروض PowerPoint وOpenDocument إلى صيغ PNG وJPEG وGIF وTIFF وغيرها من صيغ الصور.

لتحويل شريحة إلى صورة، اتبع الخطوات التالية:

1. احمل العرض باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) .
2. اختر الشريحة التي تريد تحويلها.
3. إذا لزم الأمر، قم بتكوين عملية التحويل باستخدام الفئة [RenderingOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/renderingoptions/) أو الفئة [TiffOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/) .
4. استدعِ الطريقة [ISlide.getImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islide/#getImage--) . تُعيد كائنًا من النوع [IImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/) .
5. استدعِ الطريقة [IImage.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/#save-java.lang.String-int-) وحدد صيغة الإخراج باستخدام قيمة من النوع [ImageFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imageformat/) .

## **تحويل شريحة إلى صورة PNG**

أبسط طريقة للتحويل تستخدم إعدادات التحويل الافتراضية. يمكن معالجة كائن [IImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/) الناتج في الذاكرة أو حفظه إلى ملف.

المثال التالي بلغة Java يقوم بتحويل الشريحة الأولى وحفظها كصورة PNG:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage();
    try {
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **تحويل الشرائح إلى صور بأحجام مخصصة**

استخدم التحميل الزائد للطريقة [ISlide.getImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) الذي يقبل قيمة من النوع [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) لتحديد أبعاد البكسل الدقيقة للشفرة.

المثال التالي ينشئ صورة JPEG بحجم 1820 × 1040 بكسل:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import java.awt.Dimension;

Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **تحويل الشرائح مع الملاحظات والتعليقات إلى صور**

بشكل افتراضي، لا تشمل صور الشرائح الملاحظات أو التعليقات. مرّر كائنًا من النوع [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/notescommentslayoutingoptions/) إلى الطريقة [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) للتحكم في موضع ظهور الملاحظات والتعليقات.

المثال التالي يضع الملاحظات المختصرة أسفل الشريحة والتعليقات إلى يمينها:

```java
import com.aspose.slides.CommentsPositions;
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.NotesCommentsLayoutingOptions;
import com.aspose.slides.NotesPositions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import java.awt.Color;

float scaleX = 2f;
float scaleY = scaleX;

Color commentsAreaColor = new Color(250, 235, 215);

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
لتحويل الشرائح إلى صور، لا تمرر [BottomFull](https://reference.aspose.com/slides/ar/java/com.aspose.slides/notespositions/) إلى الطريقة [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/ar/java/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-) . قد تحتوي الملاحظات على نص أكثر مما تسمح به مساحة الصورة الثابتة. استخدم [BottomTruncated](https://reference.aspose.com/slides/ar/java/com.aspose.slides/notespositions/) بدلًا من ذلك.
{{% /alert %}}

## **تحويل الشرائح إلى صور باستخدام خيارات TIFF**

تتيح الفئة [TiffOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/) التحكم في الحجم والدقة والخصائص الأخرى لصورة TIFF المُحوَّلة.

المثال التالي يحول الشريحة الأولى إلى صورة TIFF بحجم 2160 × 2880 بكسل وبنقطة 300 DPI:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.TiffOptions;
import java.awt.Dimension;

Dimension imageSize = new Dimension(2160, 2880);

TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
دعم TIFF غير مضمون في إصدارات Java السابقة لـ JDK 9.
{{% /alert %}}

## **تحويل جميع الشرائح إلى صور**

قم بالتكرار عبر مجموعة الشرائح لتحويل كامل العرض إلى سلسلة من الصور. تُضمّن الشرائح المخفية ما لم تقم بتخطيها صراحةً.

المثال التالي يحول كل شريحة إلى صورة JPEG مع عوامل مقياس أفقي ورأسي مقدارها 2:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

float scaleX = 2f;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **إنشاء مخرج Metafile محسن (EMF)**

يُعد Enhanced Metafile (EMF) مفيدًا عندما يجب تبادل الرسوميات القائمة على المتجهات مع Microsoft Office أو تطبيقات Windows الأخرى التي تدعم ملفات Metafile. على عكس الصورة القائمة على البكسل، يمكن لـ EMF الاحتفاظ بعمليات الرسم المتجهية التي تُوسع دون فقدان الحدة. ومع ذلك، يُعَد EMF في الأساس صيغة توافق لتطبيقات تدعم ملفات Metafile على Windows، وليس صيغة تبادل عالمية. بالإضافة إلى ذلك، قد يتم تخزين محتوى الشريحة المعقد، مثل الصور النقطية وبعض التأثيرات، كعناصر مُرصَّصة داخل حاوية ملف Metafile المتجه.

### **تصدير شريحة إلى EMF**

تكتب الطريقة [ISlide.writeAsEmf](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) كائنًا من النوع [ISlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islide/) إلى تدفق الهدف بصيغة EMF. المثال التالي يحمل عرضًا، يختار الشريحة الأولى، ويكتبها إلى تدفق ملف EMF:

```java
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    FileOutputStream emfStream = new FileOutputStream("Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

يمتلك المتصل التدفق الممرَّ إلى [ISlide.writeAsEmf](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) ويكون مسؤولاً عن إغلاقه، كما هو موضح أعلاه.

### **تحويل صورة SVG إلى EMF وإضافتها إلى عرض**

استخدم الطريقة [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) لتحويل محتوى SVG إلى EMF. يمكن إضافة البايتات الناتجة إلى العرض عبر الطريقة [IImageCollection.addImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimagecollection/#addImage-byte:A-) ووضعها على شريحة باستخدام الطريقة [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) .

المثال التالي ينشئ كائنًا من النوع [SvgImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/svgimage/) من شيفرة SVG، يحوله إلى EMF في الذاكرة، يدرج ملف Metafile على الشريحة الأولى، ويحفظ العرض:

```java
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ISvgImage;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import com.aspose.slides.SvgImage;
import java.io.ByteArrayOutputStream;

String svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
ISvgImage svgImage = new SvgImage(svgContent);

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ByteArrayOutputStream emfStream = new ByteArrayOutputStream();
    try {
        svgImage.writeAsEmf(emfStream);

        byte[] emfData = emfStream.toByteArray();
        IPPImage image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

الطريقة [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) لا تتولى ملكية تدفق الوجهة. تخزن فئة [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) جميع البيانات المُولَّدة في الذاكرة، لذا لا يلزم إعادة تعيين الموضع قبل استدعاء `toByteArray`. يظل مصفوفة البايتات المرجعية صالحة بعد إغلاق التدفق.

يتوفر توليد EMF على أنظمة التشغيل التي تدعمها تكوينات Aspose.Slides for Java وJDK المختارة، لكن قد تختلف عملية التحويل عبر الأنظمة عندما تكون الخطوط أو تبعيات الرسوميات غير متاحة. ثبّت الخطوط المستخدمة في المحتوى الأصلي أو قم بتكوين بدائل مناسبة، وتبع [متطلبات النظام](/slides/ar/java/system-requirements/) لـ Aspose.Slides for Java، وتحقق من النتيجة في التطبيق المستهدف الذي يستهلك EMF. غالبًا ما يكون لدعم تطبيقات Linux وmacOS لعرض وتحرير ملفات Metafile الخاص بـ Windows قيود أو عدم اتساق.

## **تجسيد الرموز التعبيرية الملونة**

{{% alert title="Note" color="info" %}}
لضمان تجسيد الرموز التعبيرية الملونة بشكل صحيح عند تحويل شرائح العرض إلى صور، يجب أن تكون خطوط الرموز التعبيرية المستخدمة في العرض مثبتة ومتاحة على النظام الذي يجري التحويل. على سبيل المثال، إذا كان العرض يستخدم **Segoe UI Emoji** وكانت هذه الخط غير موجودة، قد تظهر الرموز التعبيرية بأحادية اللون في الصور الناتجة.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يدعم Aspose.Slides تجسيد الشرائح مع الرسوم المتحركة؟**

لا. الطريقة [ISlide.getImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islide/#getImage--) تُنتج صورة ثابتة للشريحة ولا تُصدِّر الرسوم المتحركة.

**هل يمكن تصدير الشرائح المخفية كصور؟**

نعم. يمكن تحويل الشرائح المخفية مثل الشرائح العادية. تضمّنها في حلقة المعالجة، كما هو موضح في المثال أعلاه.

**هل تُحفظ الظلال وغيرها من التأثيرات في صور الشرائح؟**

نعم. يقوم Aspose.Slides بتجسيد الظلال والشفافية وغيرها من التأثيرات الرسومية المدعومة في صور الشرائح.