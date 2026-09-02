---
title: عرض شرائح العرض التقديمي كصور SVG في جافا
linktitle: شريحة إلى SVG
type: docs
weight: 50
url: /ar/java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint إلى SVG
- العرض التقديمي إلى SVG
- شريحة إلى SVG
- PPT إلى SVG
- PPTX إلى SVG
- خيارات تصدير SVG
- SVG تفاعلي
- PowerPoint
- العرض التقديمي
- جافا
- Aspose.Slides
description: "تصدير شرائح PowerPoint كصور SVG في جافا والتحكم في الخطوط والنصوص والصور والمعرفات والأحداث باستخدام Aspose.Slides."
---
## **نظرة عامة**

SVG هو تنسيق صورة قائم على XML قابل للتوسع يعمل بشكل جيد للنشر على الويب، وعارضات الشرائح، وسير عمل إمكانية الوصول، والمعالجة اللاحقة المؤتمتة. يقوم Aspose.Slides بتصدير كل شريحة إلى ملف SVG منفصل ويسمح لك بالتحكم في كيفية كتابة النصوص، الخطوط، الصور، وعناصر SVG.

استخدم [SVGOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/svgoptions/) عندما يكون الـ SVG المُصدَّر يجب أن يكون مضغوطًا، قابلاً للتوقع عبر المتصفحات، أو جاهزًا للاستخدام التفاعلي.

## **تصدير شريحة كـ SVG**

أنشئ [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/)، حدد شريحة، واكتبها إلى تدفق باستخدام [ISlide.writeAsSvg](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). المثال التالي يصدر كل شريحة في العرض التقديمي كملف SVG منفصل.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        String outputFileName = String.format("slide-%d.svg", slide.getSlideNumber());

        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            slide.writeAsSvg(svgStream);
        }
    }
} finally {
    presentation.dispose();
}
```

يستخدم اسم الملف [ISlide.getSlideNumber](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islide/#getSlideNumber--) بدلاً من فهرس الحلقة. يمكنك أيضًا تصدير شكل فردي باستخدام [IShape.writeAsSvg](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) عندما يحتاج عارض الشرائح أو صفحة الويب إلى ذلك الشكل فقط.

## **تكوين إخراج SVG**

[SVGOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/svgoptions/) يتحكم في عرض SVG. بالنسبة لإطارات النص، [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/ar/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) يتضمن إطار النص في منطقة العرض، و[SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) يحدد ما إذا كان يتم تطبيق دوران الإطار. اضبط [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/ar/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) إلى `true` عندما يجب عرض النص دون الأحرف المتصلة.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-custom-options.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **التحكم في النصوص والخطوط**

### **تحويل كل النص إلى رسومات متجهة**

اضبط [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) إلى `true` لكتابة كل نص الشريحة كرسومات متجهة. هذا يلغي الاعتماد على الخطوط ويجعل النتيجة البصرية أكثر اتساقًا عبر المتصفحات، لكن النص لن يكون قابلًا للتحديد أو البحث كالنص في SVG.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setVectorizeText(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-vectorized-text.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

### **اختر طريقة معالجة الخطوط الخارجية**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/ar/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) يستخدم قيمة من نوع [SvgExternalFontsHandling](https://reference.aspose.com/slides/ar/java/com.aspose.slides/svgexternalfontshandling/) للخطوط التي يتم تحميلها خارجيًا. اختر `AddLinksToFontFiles` للإشارة إلى ملفات خطوط منفصلة، `Embed` لتضمين بيانات الخط في SVG، أو `Vectorize` لعرض النص الذي يستخدم خطوطًا خارجية كرسومات. تحقق من ترخيص الخط قبل تضمين الخطوط.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    SVGOptions linkedFontsOptions = new SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.AddLinksToFontFiles);
    try (FileOutputStream linkedFontsStream = new FileOutputStream("slide-with-font-links.svg")) {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    }

    SVGOptions embeddedFontsOptions = new SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Embed);
    try (FileOutputStream embeddedFontsStream = new FileOutputStream("slide-with-embedded-fonts.svg")) {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    }

    SVGOptions vectorizedExternalFontsOptions = new SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Vectorize);
    try (FileOutputStream vectorizedExternalFontsStream = new FileOutputStream("slide-with-vectorized-external-fonts.svg")) {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    }
} finally {
    presentation.dispose();
}
```

## **تقليل حجم الصور المضمنة**

استخدم [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/ar/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) لتقليل دقة الصور المضمنة، و[SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/ar/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) لاستبعاد المناطق المقصوصة من المصدر، و[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/ar/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) للتحكم في جودة ترميز JPEG. هذه الإعدادات تقلل حجم الملف على حساب دقة الصورة أو البيانات المحتفظ بها.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setPicturesCompression(PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("compressed-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **تعيين معرفات ثابتة للأشكال والنص**

استخدم [ISvgShapeFormattingController](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isvgshapeformattingcontroller/) لتعيين [ISvgShape.setId](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) لكل شكل SVG. لتعيين قيم [ISvgTSpan.setId](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) على عناصر النص `tspan` أيضًا، نفّذ [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isvgshapeandtextformattingcontroller/). عيّن أي من المتحكمين باستخدام [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ar/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

```java
class StableSvgIdController implements ISvgShapeAndTextFormattingController {
    private String currentShapeId = "";
    private int textSpanIndex;

    public void formatShape(ISvgShape svgShape, IShape shape) {
        currentShapeId = String.format("shape-%d", shape.getOfficeInteropShapeId());
        textSpanIndex = 0;
        svgShape.setId(currentShapeId);
    }

    public void formatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame) {
        svgTSpan.setId(String.format("%s-text-%d", currentShapeId, textSpanIndex++));
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new StableSvgIdController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-stable-ids.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **إضافة معالجات أحداث SVG**

في [ISvgShapeFormattingController](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isvgshapeformattingcontroller/)، استدعِ [ISvgShape.setEventHandler](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) مع قيمة من نوع [SvgEvent](https://reference.aspose.com/slides/ar/java/com.aspose.slides/svgevent/) لإضافة معالج حدث جافا سكريبت إلى شكل مُصدَّر. عيّن المتحكم باستخدام [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ar/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) وعرّف دالة جافا سكريبت في الصفحة أو مستند SVG الذي يستضيف النتيجة.

```java
class SvgEventController implements ISvgShapeFormattingController {
    public void formatShape(ISvgShape svgShape, IShape shape) {
        if ("ActionButton".equals(shape.getName())) {
            svgShape.setId("action-button");
            svgShape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new SvgEventController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("interactive-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

يمكن للصفحة المستضيفة تعريف دالة جافا سكريبت التي يشير إليها المعالج. تعيين المعرفات ومعالجات الأحداث يمكنّ عارضات الشرائح، وتعزيزات إمكانية الوصول، وغيرها من سير عمل SVG التفاعلية.

## **الأسئلة المتكررة**

**متى يجب عليّ استخدام [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) بدلًا من [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ar/java/com.aspose.slides/svgexternalfontshandling/)?**

استخدم [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) عندما يجب أن يكون جميع النص مستقلًا عن الخطوط. استخدم [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ar/java/com.aspose.slides/svgexternalfontshandling/) عندما ينبغي تحويل النص الذي يستخدم خطوطًا خارجية فقط إلى رسومات.

**ما هي أفضل طريقة لتصغير حجم SVG؟**

ابدأ بضغط الصور المضمنة، حذف المناطق المقصوصة من الصورة، واختيار ملفات الخطوط المرتبطة عندما يكون بإمكان البيئة المستهدفة تقديمها. اختبر النتيجة لأن خفض دقة الصورة، خفض جودة JPEG، وتحويل النص إلى متجهات كلّها لها مفاضلات مختلفة بين الجودة والحجم.

**هل يمكنني تعديل عناصر SVG المُصدَّرة بعد التصدير؟**

نعم. عيّن المعرفات عبر متحكم التنسيق، ثم اختر عناصر SVG المطابقة في أداة المعالجة اللاحقة أو سكريبت المتصفح.