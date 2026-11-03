---
title: إدارة مكوّنات النائب في العروض التقديمية في JavaScript
linktitle: إدارة المكوّنات النائبة
type: docs
weight: 10
url: /ar/nodejs-java/manage-placeholder/
keywords:
- مكوّن نائب
- مكوّن نائب نص
- مكوّن نائب صورة
- مكوّن نائب مخطط
- مكوّن نائب محتوى
- نص توجيه
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية فحص وتحرير مكوّنات النائب للنص والصورة والمخطط والمحتوى وفهم وراثة المكوّنات النائبة باستخدام Aspose.Slides لـ Node.js عبر Java."
---
## **نظرة عامة**

المكوّن النائب هو شكل يحجز موضعًا لنوع معين من المحتوى في قالب عرض تقديمي. الأمثلة الشائعة هي العنوان، النص الأساسي، الصورة، المخطط، ومكوّنات النائب للمحتوى العامة. على عكس الشكل العادي، يمكن للمكوّن النائب أن يرث موضعه وحجمه وتنسيقه وإعدادات أخرى من شريحة تخطيط أو شريحة رئيسية.

Aspose.Slides يكشف معلومات المكوّن النائب عبر طريقة [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder). تُعيد الطريقة كائن [Placeholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/) أو `null` لشكل عادي. استخدم [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) لتحديد ما يُقصد أن يحتويه المكوّن النائب.

فئة الشكل لا تزال مهمة بعد معرفة نوع المكوّن النائب:

- عادةً ما يُمثَّل المكوّن النائب الفارغ للنص أو الصورة أو المخطط أو المحتوى بـ [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
- يمكن تمثيل مكوّن النائب للصورة المُعبَّأ بـ [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/).
- يمكن تمثيل مكوّن النائب للمخطط المُعبَّأ بـ [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/).
- يمكن أن يحتوي مكوّن النائب للمحتوى على عدة أنواع من المحتوى. تحقق من كل من [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) وفئة الشكل في وقت التشغيل بدلاً من افتراض أن كل مكوّن نائب هو [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).

{{% alert color="warning" title="تحذير" %}}
[Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) يصف دور المكوّن النائب؛ لكنه لا يضمن نوع الشكل في وقت التشغيل. استخدم دائمًا فحص النوع قبل الوصول إلى النص أو الصورة أو المخطط أو الجدول أو الأعضاء الخاصة بالوسائط.
{{% /alert %}}

## **فهم وراثة المكوّن النائب**

المكوّنات النائبة تُكوِّن تسلسلًا هرميًا:

1. تُعَرِّف الشريحة الرئيسية الأنماط القابلة لإعادة الاستخدام، وفي بعض الحالات، المكوّنات النائبة على مستوى الرئيسي.
2. تُعَرِّف شريحة التخطيط الترتيب المستخدم من قبل شريحة عادية واحدة أو أكثر ويمكن أن ترث من الرئيسي.
3. تحتوي الشريحة العادية على المكوّنات النائبة لتلك الشريحة ويمكن أن ترث من تخطيطها.

استدعِ [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) للانتقال مستوىً واحدًا أعلى في هذا التسلسل. عادةً ما تُعيد شريحة النائب النائب الخاص بتخطيطها؛ ويمكن لنائب التخطيط أن يُعيد نائبه الرئيسي. تُعيد الطريقة `null` عندما لا يملك الشكل نائبًا أساسيًا.

المثال التالي يسرد المكوّنات النائبة في الشريحة الأولى ويُبلغ عن النائب الأساسي لكل منها:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getShapeClassName(shape) {
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        return "AutoShape";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        return "PictureFrame";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
        return "Chart";
    }

    return "Shape";
}

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const shapeClassName = getShapeClassName(shape);
        const slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape class: " + shapeClassName;
        console.log(slidePlaceholderMessage);

        const layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            const layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            const layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            const layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            console.log(layoutPlaceholderMessage);

            const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                const masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                const masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                const masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                console.log(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

تحرير مكوّن نائب على شريحة عادية يُنشئ أو يغيّر تجاوزًا محليًا لتلك الشريحة. تحرير التخطيط أو الرئيسي المرتبط يمكن أن يؤثر على جميع الشرائح التي لا تزال ترث هذا الإعداد. الشكل العادي المحلي ليس له نائب أساسي ولا يبدأ في الوراثة لمجرد أنه يحتل نفس الإحداثيات.

## **إزالة حالة المكوّن النائب**

عند تعديل قالب، استخدم [Shape.removePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#removePlaceholder) لإبقاء كائن موجود كشكل عادي. تُعيد طريقة [getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) `null`، لكن الشكل يبقى في مجموعة الشرائح. بالمقابل، [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#remove) يحذف الشكل من تلك المجموعة.

المثال التالي يتطلّب `template.pptx` يحتوي على شريحة واحدة على الأقل ومكوّن نائب نص غير فارغ في الشريحة الأولى. استخدم مكوّن نائب بتنسيق مُورَث من تخطيطه أو رئيسه لتُرى تأثير إزالة العلاقة. يتحقّق المثال من بقاء الشكل نفسه، يُستدعي الطريقة مرة أخرى على الشكل العادي الآن، ويحفظ النتيجة.

{{% alert color="warning" title="تحذير" %}}
إزالة حالة المكوّن النائب لا تحتفظ تلقائيًا بإعدادات المظهر الموروثة. المثال أدناه يترك تلك الإعدادات دون تعديل عمدًا، لذا قد يبدو الناتج مختلفًا. الشكل الذي يتم وراثة موضعه وحجمه بالكامل قد يصبح إحداثياته وأبعاده صفرًا بعد الاستدعاء ويصبح غير مرئي رغم بقائه في المجموعة.
{{% /alert %}}

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapes = slide.getShapes();
    let found = false;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null || textFrame == null) {
            continue;
        }

        const text = textFrame.getText();
        if (text == null || text.length === 0) {
            continue;
        }

        const shapeCount = shapes.size();
        shape.removePlaceholder();

        console.log("Placeholder removed: " + (shape.getPlaceholder() == null));
        const retainedShape = shapes.get_Item(index);
        console.log("Same shape retained: " + shape.equals(retainedShape));
        console.log("Shape count unchanged: " + (shapes.size() === shapeCount));

        // استدعاء الطريقة على شكل عادي لا يؤثر.
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

للمكوّن النائب المطابق، تُظهر الفحوصات الثلاثة `true`. يبقى النص، لكن الموضع والحجم والدوران والخط ومحاذاة الفقرة وهوامش إطار النص والربط العمودي والتعبئة وإعدادات الخط قد تتغيّر عندما تُزال علاقة المكوّن النائب. على سبيل المثال، قد يعود تنسيق العنوان الموروث إلى تنسيق النص العادي. راجع [Slide Layout](/slides/ar/nodejs-java/slide-layout/) لمزيد من المعلومات حول التخطيطات.

للحفاظ على المظهر المقصود، احفظ الموضع والحجم والدوران المحلولين قبل الاستدعاء، وانسخ قيم التنسيق الفعّال المطلوبة إلى متغيّرات منفصلة. احصل على تلك القيم عبر [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective)، [ParagraphFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getEffective)، [TextFrameFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getEffective)، [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getEffective)، و[LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getEffective). لا تعتمد على الاحتفاظ فقط بأجسام التنسيق الفعّال، لأن قيم تنسيق النص قد تتغيّر بعد إزالة العلاقة. طبّق القيم المحفوظة صراحةً على الشكل العادي لاحقًا، بما في ذلك عائلة الخط، الحجم، النمط، اللون، إعدادات الفقرة، إعدادات إطار النص، التعبئة، والخط المستخدم في القالب الخاص بك.

قد تحتاج أيضًا إلى تعيين هندسة الشكل الموروثة صراحةً عبر [GeometryShape.setShapeType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setShapeType). للمكوّن النائب النصي المستطيل، يعني ذلك تعيين [ShapeType.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/#Rectangle)؛ فاستعادة التعبئة والخط فقط قد لا تُعيد المستطيل المرئي. القوالب التي تحتوي على تأثيرات إضافية أو تنسيق أكثر تعقيدًا تتطلّب معالجة تلك الإعدادات كذلك.

## **تغيير النص في مكوّن نائب**

عادةً ما تدعم العناوين، العناوين المركزية، العناوين الفرعية، النص الأساسي، ومكوّنات النائب النصية النص. تحقق من وجود [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) قبل استخدام طريقة [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#getTextFrame) الخاصة به.

هذا المثال يحدّث أول مكوّن نائب للعنوان في الشريحة الأولى ويحفظ النتيجة:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let titleShape = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            titleShape = shape;
            break;
        }
    }

    if (titleShape == null) {
        throw new Error("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

هذا النمط يتجنّب اعتبار الصور أو المخططات أو الجداول أو وسائط المكوّن النائب ككائنات [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/). كما يحدد المكوّن النائب بحسب الغرض بدلاً من الاعتماد على فهرس شكل هش.

## **تعيين نص التلميح في التخطيط**

نص التلميح هو التعليمات التي تُعرض أثناء التصميم داخل مكوّن نائب فارغ، مثل *انقر لإضافة عنوان*. عيّن نص التلميح المخصّص على مكوّن نائب التخطيط بدلاً من محاولة الوصول إليه عبر مجموعة أشكال الشريحة العادية. احصل على التخطيط عبر [Slide.getLayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getLayoutSlide) وتجوّل في المجموعة التي تُرجِعها [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes).

المثال التالي يغيّر تلميحات العنوان والعنوان الفرعي في التخطيط المستخدم من قبل الشريحة الأولى:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const firstSlide = slides.get_Item(0);
    const layoutSlide = firstSlide.getLayoutSlide();
    const shapes = layoutSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();

        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            shape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType === aspose.slides.PlaceholderType.Subtitle) {
            shape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نص التلميح ليس محتوى شريحة عادي. هو مخصص للمكوّنات النائبة الفارغة في تطبيقات التحرير مثل PowerPoint. بمجرد أن يزوِّد المستخدم أو البرنامج محتوىً حقيقيًا، لا يُظهر التلميح بعد ذلك. تغيير التلميح لا يستبدل النص الموجود على الشرائح التي تستخدم التخطيط.

## **تحديث مكوّن نائب الصورة**

هناك حالتان يجب التعامل معهما:

- إذا كان مكوّن نائب الصورة مُعبَّأً بالفعل ومُمَثَّلًا بـ [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/)، استبدل الصورة عبر [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/#getPictureFormat)، [PictureFillFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#getPicture)، و[Picture.setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage).
- إذا كان لا يزال مكوّن نائبًا فارغًا، أضف إطار صورة في إحداثيات المكوّن النائب عبر [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) وأزل المكوّن النائب الفارغ.

المثال التالي يدعم الحالتين ويحفظ العرض التقديمي:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("picture-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let picturePlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new Error("The first slide does not contain a picture placeholder.");
    }

    const sourceImage = aspose.slides.Images.fromFile("replacement.png");
    try {
        const image = presentation.getImages().addImage(sourceImage);

        if (java.instanceOf(picturePlaceholder, "com.aspose.slides.IPictureFrame")) {
            picturePlaceholder.getPictureFormat().getPicture().setImage(image);
        } else {
            const x = picturePlaceholder.getX();
            const y = picturePlaceholder.getY();
            const width = picturePlaceholder.getWidth();
            const height = picturePlaceholder.getHeight();
            const frameX = java.newFloat(x);
            const frameY = java.newFloat(y);
            const frameWidth = java.newFloat(width);
            const frameHeight = java.newFloat(height);
            shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
            shapes.remove(picturePlaceholder);
        }
    } finally {
        sourceImage.dispose();
    }

    presentation.save("picture-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

البديل المُنشأ لمكوّن نائب فارغ هو إطار صورة محلي، ليس مكوّن نائب جديد، لأن [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) لا يوفر مُعدِّل. يحتفظ بالموضع المحجوز لكنه لم يعد يرث سلوك المكوّن النائب. إذا كان الحفاظ على علاقة المكوّن النائب أمرًا أساسيًا، حضّر واملأ المكوّن النائب في PowerPoint أولاً، ثم حدّث الـ [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) الناتج باستخدام Aspose.Slides.

لشفافية الصورة، القص، وغيرها من تأثيرات الصورة الخاصة، راجع [Manage Picture Frames](/slides/ar/nodejs-java/picture-frame/). تلك العمليات تنتمي إلى إطار الصورة أو تعبئة الصورة، لا إلى بيانات ميتا المكوّن النائب.

## **العمل مع مكوّنات نائب المخطط والمحتوى**

يمكن تمثيل مكوّن نائب المخطط المُعبَّأ بـ [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/). هذا المثال يجد مثل هذا المخطط عبر كل من نوع المكوّن النائب والفئة في وقت التشغيل، يغيّر عنوانه، ويحفظ الملف:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let placeholderChart = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Chart) {
            placeholderChart = shape;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new Error("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

عادةً ما يكون مكوّن نائب المحتوى العام من نوع [PlaceholderType.Object](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Object). في PowerPoint يعمل كمنقذ لعدة أنواع محتوى، بما في ذلك المخططات والجداول والرسوم التخطيطية والصور والوسائط. بعد تعبئته، افحص فئة الشكل الفعلية لتعرف ما يحتويه. يمكن للتخطيطات المتخصصة أيضًا أن تكشف عن [PlaceholderType.Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Chart)، [PlaceholderType.Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Table)، [PlaceholderType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Picture)، [PlaceholderType.Media](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Media)، أو [PlaceholderType.Diagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides لا يُحوِّل مكوّن نائب [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) فارغ إلى [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) بمجرد تغيير [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType)؛ لا يمكن تغيير النوع عبر الكائن. لملء مخطط أو مساحة محتوى فارغة برمجيًا، أضف الكائن المطلوب في إحداثيات المكوّن النائب ثم أزل المكوّن النائب الفارغ. المثال التالي يفعل ذلك لمخطط:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("content-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let targetPlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Chart || placeholderType === aspose.slides.PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new Error("The first slide does not contain a chart or content placeholder.");
    }

    const x = targetPlaceholder.getX();
    const y = targetPlaceholder.getY();
    const width = targetPlaceholder.getWidth();
    const height = targetPlaceholder.getHeight();
    const chartX = java.newFloat(x);
    const chartY = java.newFloat(y);
    const chartWidth = java.newFloat(width);
    const chartHeight = java.newFloat(height);
    const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, chartX, chartY, chartWidth, chartHeight);
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    shapes.remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

المخطط المضاف هو مخطط محلي عادي. يحتل مساحة المكوّن النائب لكنه لا يرث من مكوّن نائب التخطيط. استخدم مقالات إدارة المخططات المخصَّصة [chart management articles](/slides/ar/nodejs-java/powerpoint-charts/) عندما تحتاج إلى استبدال الفئات أو السلاسل أو بيانات المصنف.

## **مثال كامل: تحديث نص أو محتوى صورة**

المثال التالي من البداية إلى النهاية يفتح قالبًا، يبحث في الشريحة الأولى عن مكوّن نائب للعنوان أو الصورة، يتحقق من نوع المكوّن النائب والشكل، يحدّث المحتوى المناسب، ويحفظ النتيجة. يتجنّب المثال الافتراض حول فهرس الشكل أو معاملة كل مكوّن نائب كفئة واحدة.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let updated = false;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const isTitlePlaceholder = placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle;

        if (isTitlePlaceholder && java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType === aspose.slides.PlaceholderType.Picture) {
            const sourceImage = aspose.slides.Images.fromFile("replacement.png");
            try {
                const image = presentation.getImages().addImage(sourceImage);

                if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                    shape.getPictureFormat().getPicture().setImage(image);
                } else {
                    const x = shape.getX();
                    const y = shape.getY();
                    const width = shape.getWidth();
                    const height = shape.getHeight();
                    const frameX = java.newFloat(x);
                    const frameY = java.newFloat(y);
                    const frameWidth = java.newFloat(width);
                    const frameHeight = java.newFloat(height);
                    shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
                    shapes.remove(shape);
                }
            } finally {
                sourceImage.dispose();
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new Error("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة الشائعة**

**ما هو المكوّن النائب الأساسي؟**

المكوّن النائب الأساسي هو الشكل المقابل في التخطيط أو الرئيسي الذي يرث منه مكوّن نائب آخر. استخدم [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) لاسترجاعه. الشكل العادي المحلي يُعيد `null` لأنه ليس جزءًا من تسلسل المكوّنات النائبة.

**هل يمكنني تغيير جميع عناوين الشرائح عبر تحرير مكوّن نائب التخطيط؟**

يمكنك تغيير التنسيق الموروث أو نص التلميح من خلال التخطيط، لكن محتوى العنوان الموجود يُخزّن على الشرائح العادية. لاستبدال نص العنوان الفعلي عبر عرض تقديمي كامل، تجوَّل الشرائح وقم بتحديث كل مكوّن نائب للعنوان.

**كيف أُدير مكوّنات نائب التاريخ، رقم الشريحة، الرأس، والتذييل؟**

استخدم مديرات الرأس والتذييل في نطاق الشريحة أو التخطيط أو الرئيسي أو الملاحظات أو النسخة الموزَّعة. راجع [Manage Presentation Header and Footer](/slides/ar/nodejs-java/presentation-header-and-footer/) لأمثلة كاملة.