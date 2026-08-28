---
title: تحويل شرائح العروض التقديمية إلى صور على Android
linktitle: شريحة إلى صورة
type: docs
weight: 35
url: /ar/androidjava/convert-slide/
keywords:
- تحويل شريحة
- تصدير شريحة
- شريحة إلى صورة
- حفظ الشريحة كصورة
- شريحة إلى EMF
- شريحة إلى PNG
- شريحة إلى JPEG
- شريحة إلى bitmap
- شريحة إلى TIFF
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تحويل الشرائح من عروض PPT و PPTX و ODP إلى PNG و JPEG و GIF و TIFF و EMF وغيرها من تنسيقات الصور على Android باستخدام Aspose.Slides."
---
## **المقدمة**

Aspose.Slides for Android via Java يمكنه عرض الشرائح الفردية من عروض PowerPoint و OpenDocument كصور PNG، JPEG، GIF، TIFF، وغيرها من تنسيقات الصور.

لتحويل شريحة إلى صورة، اتبع الخطوات التالية:

1. قم بتحميل العرض باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) .
2. اختر الشريحة التي تريد عرضها.
3. إذا لزم الأمر، قم بتكوين العرض باستخدام الفئة [RenderingOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/renderingoptions/) أو [TiffOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tiffoptions/) .
4. استدعِ الطريقة [ISlide.getImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islide/#getImage--) . تُعيد كائنًا من نوع [IImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/) .
5. استدعِ الطريقة [IImage.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) وحدد تنسيق الإخراج باستخدام قيمة [ImageFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imageformat/) .

## **تحويل شريحة إلى صورة PNG**

أبسط عملية تحويل تستخدم إعدادات العرض الافتراضية. يمكن معالجة كائن [IImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/) الناتج في الذاكرة أو حفظه إلى ملف.

المثال التالي بلغة Java يعرض الشريحة الأولى ويحفظها كصورة PNG:

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

استخدم نسخة overload من [ISlide.getImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) التي تقبل قيمة [Size](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.android/size/) لعرض شريحة بأبعاد بكسلية دقيقة.

المثال التالي ينشئ صورة JPEG بحجم 1820 × 1040:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.android.Size;

Size imageSize = new Size(1820, 1040);

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

افتراضيًا، لا تتضمن صور الشرائح الملاحظات أو التعليقات. مرّر كائنًا من نوع [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/notescommentslayoutingoptions/) إلى الطريقة [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) للتحكم في موضع ظهور الملاحظات والتعليقات.

المثال التالي يضع الملاحظات المختصرة أسفل الشريحة والتعليقات على يمينها:

```java
import android.graphics.Color;
import com.aspose.slides.CommentsPositions;
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.NotesCommentsLayoutingOptions;
import com.aspose.slides.NotesPositions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;

float scaleX = 2f;
float scaleY = scaleX;

int commentsAreaColor = Color.rgb(250, 235, 215);

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
في عملية تحويل الشرائح إلى صور، لا تمرر [BottomFull](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/notespositions/) إلى الطريقة [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-) . قد تحتوي الملاحظات على نص أكثر مما يمكن لحجم الصورة الثابت استيعابه. استخدم [BottomTruncated](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/notespositions/) بدلًا من ذلك.
{{% /alert %}}

## **تحويل الشرائح إلى صور باستخدام خيارات TIFF**

تتيح لك الفئة [TiffOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tiffoptions/) التحكم في الحجم، الدقة، والخصائص الأخرى لصورة TIFF المُنتجة.

المثال التالي يعرض الشريحة الأولى كصورة TIFF بحجم 2160 × 2880 بدقة 300 DPI:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.TiffOptions;
import com.aspose.slides.android.Size;

Size imageSize = new Size(2160, 2880);

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

## **تحويل جميع الشرائح إلى صور**

قم بالتكرار عبر مجموعة الشرائح لتحويل العرض الكامل إلى سلسلة من الصور. تُضمّن الشرائح المخفية ما لم تقم بتخطيها صراحةً.

المثال التالي يعرض كل شريحة كصورة JPEG بعامل تكبير أفقي ورأسي مقداره 2:

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

## **إنشاء مخرجات Metafile المحسّنة**

Enhanced Metafile (EMF) مفيد عندما يجب تبادل الرسوميات القائمة على المتجهات مع Microsoft Office أو تطبيقات Windows الأخرى التي تدعم ملفات Metafile الخاصة بـ Windows. على عكس الصورة القائمة على البكسل، يمكن لـ EMF الاحتفاظ بعمليات الرسم المتجهة التي تُقاس دون فقدان الحدة نفسه. مع ذلك، يُعد EMF في الأساس تنسيق توافق لتطبيقات تدعم ملفات Metafile الخاصة بـ Windows، وليس تنسيق تبادل عالمي. بالإضافة إلى ذلك، قد يتم تخزين محتوى شريحة معقد، مثل صور bitmap وبعض التأثيرات، كعناصر rasterized داخل حاوية ملف Metafile المتجه.

### **تصدير شريحة إلى EMF**

الطريقة [ISlide.writeAsEmf](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) تكتب كائن [ISlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islide/) إلى تدفق هدف بصيغة EMF. المثال التالي يحمل عرضًا، يختار الشريحة الأولى، ويكتبها إلى تدفق ملف EMF:

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

المستدعي يملك التدفق الممرّر إلى [ISlide.writeAsEmf](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) ويتحمل مسؤولية إغلاقه، كما هو موضح أعلاه.

### **تحويل صورة SVG إلى EMF وإضافتها إلى عرض تقديمي**

استخدم [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) لتحويل محتوى SVG إلى EMF. يمكن إضافة البايتات الناتجة إلى العرض عبر [IImageCollection.addImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimagecollection/#addImage-byte:A-) ووضعها على شريحة باستخدام [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) .

المثال التالي ينشئ كائن [SvgImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/svgimage/) من شفرة SVG، يحوله إلى EMF في الذاكرة، يدرج ملف الميتا على الشريحة الأولى، ويحفظ العرض:

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

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) لا تتولى ملكية تدفق الوجهة. يقوم [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) بتخزين جميع البيانات المولدة في الذاكرة، لذلك لا يلزم إعادة تعيين الموضع قبل استدعاء `toByteArray`. يظل مصفوفة البايتات المرجعة صالحة بعد إغلاق التدفق.

تتوفر توليد ملفات EMF على إصدارات Android المدعومة وتكوينات الأجهزة، ولكن قد يختلف العرض عندما تكون الخطوط أو تبعيات الرسومات غير متوفرة. قم بتثبيت الخطوط المستخدمة في المحتوى الأصلي أو تكوين بدائل مناسبة، واتبع [دليل التثبيت](/slides/ar/androidjava/install-aspose-slides-for-android-via-java/) لـ Aspose.Slides for Android via Java، وتحقق من النتيجة في التطبيق المستهلك لـ EMF. غالبًا ما تكون التطبيقات على الأنظمة غير الويندوز ذات دعم محدود أو غير متسق لعرض وتحرير ملفات الميتا الويندوز.

## **عرض الرموز التعبيرية الملونة**

{{% alert title="Note" color="info" %}}
لعرض الرموز التعبيرية الملونة بشكل صحيح عند تحويل شرائح العرض إلى صور، يجب تثبيت خطوط الرموز التعبيرية المستخدمة في العرض وتوافرها على النظام الذي يقوم بالتحويل. على سبيل المثال، إذا كان العرض يستخدم **Segoe UI Emoji** وكان هذا الخط غير موجود، قد تظهر الرموز التعبيرية بالأبيض والأسود في الصور الناتجة.
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يدعم Aspose.Slides عرض الشرائح مع الرسوم المتحركة؟**

لا. الطريقة [ISlide.getImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islide/#getImage--) تعرض صورة ثابتة للشريحة ولا تُصدّر الرسوم المتحركة.

**هل يمكن تصدير الشرائح المخفية كصور؟**

نعم. يمكن عرض الشرائح المخفية مثل الشرائح العادية. قم بتضمينها في حلقة المعالجة، كما هو موضح في المثال أعلاه.

**هل تُحافظ صور الشرائح على الظلال وغيرها من التأثيرات؟**

نعم. Aspose.Slides تُظهر الظلال والشفافية وغيرها من التأثيرات الرسومية المدعومة في صور الشرائح.