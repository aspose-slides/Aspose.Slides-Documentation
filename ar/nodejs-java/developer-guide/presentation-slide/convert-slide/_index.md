---
title: تحويل شرائح العروض التقديمية إلى صور في جافا سكريبت
linktitle: الشريحة إلى صورة
type: docs
weight: 35
url: /ar/nodejs-java/convert-slide/
keywords:
- تحويل الشريحة
- تصدير الشريحة
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
- Node.js
- JavaScript
- Aspose.Slides
description: "تحويل الشرائح من عروض PPT و PPTX و ODP إلى PNG و JPEG و GIF و TIFF و EMF وغيرها من تنسيقات الصور في جافا سكريبت باستخدام Aspose.Slides."
---
## **مقدمة**

يمكن لـ Aspose.Slides for Node.js عبر Java عرض الشرائح الفردية من عروض PowerPoint و OpenDocument كصور PNG و JPEG و GIF و TIFF وغيرها من تنسيقات الصور.

لتحويل شريحة إلى صورة، اتبع الخطوات التالية:

1. حمّل العرض باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/).
2. حدد الشريحة التي تريد عرضها.
3. إذا لزم الأمر، قم بتكوين العرض باستخدام الفئة [RenderingOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/renderingoptions/) أو الفئة [TiffOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tiffoptions/).
4. استدعِ طريقة [Slide.getImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/#getImage). تُعيد كائنًا من نوع [IImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/iimage/).
5. استدعِ طريقة [IImage.save](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/iimage/#save) وحدد تنسيق الإخراج باستخدام قيمة من نوع [ImageFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imageformat/).

## **تحويل شريحة إلى صورة PNG**

أبسط طريقة للتحويل تستخدم إعدادات العرض الافتراضية. يمكن معالجة كائن [IImage] الناتج في الذاكرة أو حفظه إلى ملف.

المثال التالي بلغة JavaScript يعرض الشريحة الأولى ويحفظها كصورة PNG:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage();
    try {
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **تحويل الشرائح إلى صور بأحجام مخصصة**

استخدم نسخة overload من [Slide.getImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/#getImage) التي تقبل قيمة `java.awt.Dimension` لعرض شريحة بأبعاد بكسلية دقيقة.

المثال التالي ينشئ صورة JPEG بحجم 1820 × 1040:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **تحويل الشرائح مع الملاحظات والتعليقات إلى صور**

بشكل افتراضي، لا تتضمن صور الشرائح الملاحظات أو التعليقات. مرّر كائنًا من [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/notescommentslayoutingoptions/) إلى طريقة [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) للتحكم في موضع ظهور الملاحظات والتعليقات.

المثال التالي يضع الملاحظات المقتصرة أسفل الشريحة والتعليقات إلى يمينها:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = scaleX;

const commentsAreaColor = java.newInstanceSync("java.awt.Color", 250, 235, 215);

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

const renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
في تحويل الشرائح إلى صور، لا تمرر [BottomFull](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/notespositions/) إلى طريقة [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). قد تحتوي الملاحظات على نص أكثر مما يمكن لحجم الصورة الثابت استيعابه. استخدم [BottomTruncated](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/notespositions/) بدلاً من ذلك.
{{% /alert %}}

## **تحويل الشرائح إلى صور باستخدام خيارات TIFF**

تتيح لك الفئة [TiffOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tiffoptions/) التحكم في الحجم والدقة وغيرها من خصائص صورة TIFF المعروضة.

المثال التالي يعرض الشريحة الأولى كصورة TIFF بحجم 2160 × 2880 بدقة 300 DPI:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 2160, 2880);

const tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
دعم TIFF غير مضمون في إصدارات Java الأقدم من JDK 9.
{{% /alert %}}

## **تحويل جميع الشرائح إلى صور**

كرر عبر مجموعة الشرائح لتحويل العرض الكامل إلى سلسلة من الصور. تشمل الشرائح المخفية ما لم تقم بتخطيها صراحة.

المثال التالي يعرض كل شريحة كصورة JPEG بمعاملات تكبير أفقية ورأسية مقدارها 2:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const scaleX = 2;
const scaleY = scaleX;

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.getSlides().get_Item(index);
        const image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **إنشاء إخراج Enhanced Metafile**

Enhanced Metafile (EMF) مفيد عندما يجب تبادل الرسومات المستندة إلى المتجهات مع Microsoft Office أو تطبيقات Windows الأخرى التي تدعم ملفات ميتاويندوز. على عكس الصورة القائمة على البكسل، يمكن لـ EMF الاحتفاظ بعمليات الرسم المتجهية التي يمكن تكبيرها دون فقدان الحدة. ومع ذلك، فإن EMF هو أساسًا صيغة توافق للتطبيقات التي تدعم ملفات ميتاويندوز، وليس صيغة تبادل شاملة. بالإضافة إلى ذلك، قد يتم تخزين محتوى الشريحة المعقد، مثل الصور النقطية وبعض التأثيرات، كعناصر rasterized داخل حاوية ملف الميتا المتجه.

### **تصدير شريحة إلى EMF**

طريقة [Slide.writeAsEmf](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/#writeAsEmf) تكتب شريحة إلى تدفق هدف بصيغة EMF. المثال التالي يحمل عرضًا تقديميًا، يحدد الشريحة الأولى، ويكتبها إلى تدفق ملف EMF:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.FileOutputStream", "Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

المستدعي يمتلك التدفق الممرَّ إلى [Slide.writeAsEmf](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/#writeAsEmf) وهو المسؤول عن إغلاقه، كما هو موضح أعلاه.

### **تحويل صورة SVG إلى EMF وإضافتها إلى عرض تقديمي**

استخدم [SvgImage.writeAsEmf](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgimage/#writeAsEmf) لتحويل محتوى SVG إلى EMF. يمكن إضافة البايتات الناتجة إلى العرض عبر [ImageCollection.addImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagecollection/#addImage) ووضعها على شريحة باستخدام [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapecollection/#addPictureFrame).

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
const svgImage = new aspose.slides.SvgImage(svgContent);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        svgImage.writeAsEmf(emfStream);

        const emfData = java.newArray("byte", Array.from(emfStream.toByteArray()));
        const image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgimage/#writeAsEmf) لا يتملك تدفق الوجهة. يخزن `java.io.ByteArrayOutputStream` جميع البيانات المولدة في الذاكرة، لذلك لا يلزم إعادة تعيين الموضع قبل استدعاء `toByteArray`. يبقى مصفوفة البايتات المسترجعة صالحة بعد إغلاق التدفق.

تتوفر إنشاء EMF على أنظمة التشغيل المدعومة من قبل Aspose.Slides for Node.js via Java وتكوين JDK المختار، لكن العرض قد يختلف بين المنصات عندما تكون الخطوط أو تبعيات الرسوم غير متاحة. قم بتثبيت الخطوط المستخدمة في المحتوى الأصلي أو تكوين بدائل مناسبة، واتبع [متطلبات النظام](/slides/ar/nodejs-java/system-requirements/) لـ Aspose.Slides for Node.js via Java، وتحقق من النتيجة في التطبيق المستهلك لـ EMF. غالبًا ما تكون تطبيقات Linux و macOS ذات دعم محدود أو غير متسق لعرض وتحرير ملفات ميتاويندوز.

## **عرض رموز الإيموجي ملونة**

{{% alert title="Note" color="info" %}}
لعرض رموز الإيموجي الملونة بشكل صحيح عند تحويل شرائح العرض إلى صور، يجب تثبيت خطوط الإيموجي المستخدمة في العرض وتوفرها على النظام الذي يقوم بالتحويل. على سبيل المثال، إذا كان العرض يستخدم **Segoe UI Emoji** وكان هذا الخط مفقودًا، قد تظهر الإيموجي بالأبيض والأسود في الصور الناتجة.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يدعم Aspose.Slides عرض الشرائح مع الرسوم المتحركة؟**

لا. طريقة [Slide.getImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/#getImage) تعرض صورة ثابتة للشريحة ولا تصدر الرسوم المتحركة.

**هل يمكن تصدير الشرائح المخفية كصور؟**

نعم. يمكن عرض الشرائح المخفية مثل الشرائح العادية. اشملها في حلقة المعالجة، كما هو موضح في المثال أعلاه.

**هل يتم الحفاظ على الظلال وغيرها من التأثيرات في صور الشرائح؟**

نعم. تقوم Aspose.Slides بعرض الظلال والشفافية وغيرها من التأثيرات الرسومية المدعومة في صور الشرائح.