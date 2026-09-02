---
title: إدارة عناصر النائب في العرض التقديمي باستخدام JavaScript
linktitle: إدارة العناصر النائبة
type: docs
weight: 10
url: /ar/nodejs-java/manage-placeholder/
keywords:
- عنصر نائب
- عنصر نائب نص
- عنصر نائب صورة
- عنصر نائب مخطط
- عنصر نائب محتوى
- نص إرشادي
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية فحص وتحرير النصوص والصور والمخططات والعناصر النائبة للمحتوى وفهم وراثة العناصر النائبة باستخدام Aspose.Slides لـ Node.js عبر Java."
---
## **نظرة عامة**

العنصر النائب هو شكل يحجز موضعًا لنوع معين من المحتوى في قالب عرض تقديمي. الأمثلة الشائعة هي العنوان، النص الأساسي، الصورة، المخطط، والعناصر النائبة للمحتوى العامة. على عكس الشكل العادي، يمكن للعنصر النائب أن يرث موقعه وحجمه وتنسيقه وإعدادات أخرى من شريحة تخطيط أو شريحة رئيسية.

Aspose.Slides تقوم بالكشف عن معلومات العنصر النائب من خلال طريقة [Shape.getPlaceholder](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/#getPlaceholder). تُعيد الطريقة كائنًا من نوع [Placeholder](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/placeholder/) أو `null` لشكل عادي. استخدم [Placeholder.getType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/placeholder/#getType) لتحديد ما يُقصد أن يحتويه العنصر النائب.

لا يزال فئة الشكل مهمة بعد معرفة نوع العنصر النائب:

- عادةً ما يتم تمثيل عنصر نائب فارغ للنص أو الصورة أو المخطط أو المحتوى بواسطة [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/).
- يمكن تمثيل عنصر نائب صورة مملوء بـ [PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/).
- يمكن تمثيل عنصر نائب مخطط مملوء بـ [Chart](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chart/).
- يمكن لعنصر نائب محتوى أن يحتوي عدة أنواع من المحتوى. تحقق من كل من [Placeholder.getType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/placeholder/#getType) وفئة الشكل في وقت التشغيل بدلاً من افتراض أن كل عنصر نائب هو [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/placeholder/#getType) يصف دور العنصر النائب؛ لكنه لا يضمن نوع الشكل في وقت التشغيل. احرص دائمًا على فحص النوع قبل الوصول إلى النص أو الصورة أو المخطط أو الجدول أو الأعضاء الخاصة بالوسائط.
{{% /alert %}}

## **فهم وراثة العنصر النائب**

العناصر النائبة تشكل تسلسلًا هرميًا:

1. تحدد الشريحة الرئيسة الأنماط القابلة لإعادة الاستخدام، وفي بعض الحالات، العناصر النائبة على مستوى الرئيسة.
2. تحدد شريحة التخطيط الترتيب المستخدم في شريحة أو أكثر عادية ويمكنها الوراثة من الرئيسة.
3. تحتوي الشريحة العادية على العناصر النائبة لتلك الشريحة ويمكنها الوراثة من التخطيط الخاص بها.

استدعِ [Shape.getBasePlaceholder](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/#getBasePlaceholder) للانتقال مستوى واحد أعلى في هذا التسلسل. عادةً ما تُعيد العنصر النائب لشريحة ما عنصر النائب الخاص بالتخطيط؛ ويمكن لعنصر نائب التخطيط أن يُعيد عنصر النائب الرئيس. تُعيد الطريقة `null` عندما لا يملك الشكل عنصر نائب أساسي.

المثال التالي يسرد العناصر النائبة في الشريحة الأولى ويُبلغ عن عناصرها الأساسية:

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

تحرير عنصر نائب في شريحة عادية يخلق أو يغيّر تجاوزًا محليًا لتلك الشريحة. تحرير التخطيط أو الرئيس المرتبط يمكن أن يؤثر على جميع الشرائح التي لا تزال ترث ذلك الإعداد. الشكل العادي المحلي لا يملك عنصر نائب أساسي ولا يبدأ الوراثة لمجرد أنه يشغل نفس الإحداثيات.

## **تغيير النص في العنصر النائب**

العناوين، العنوان المركزي، العنوان الفرعي، النص الأساسي، وعناصر النائب النصية تدعم النص عادةً. تحقق من وجود [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) قبل استخدام طريقة [getTextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/#getTextFrame).

المثال التالي يُحدّث أول عنصر نائب للعنوان في الشريحة الأولى ويحفظ النتيجة:

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

هذا النمط يتجنب معاملة العناصر النائبة للصور أو المخططات أو الجداول أو الوسائط ككائنات [AutoShape]. كما يحدد العنصر النائب بحسب الغرض بدلاً من الاعتماد على فهرس شكل هش.

## **تعيين نص تلميحي على التخطيط**

النص التلميحي هو التعليمات المعروضة في وقت التصميم داخل عنصر نائب فارغ، مثل *Click to add title*. ضع نصًا تلميحيًا مخصصًا على عنصر النائب في التخطيط بدلاً من محاولة الوصول إليه عبر مجموعة أشكال الشريحة العادية. يمكن الوصول إلى التخطيط عبر [Slide.getLayoutSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/#getLayoutSlide) والتكرار على المجموعة التي تُرجعها [BaseSlide.getShapes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseslide/#getShapes).

المثال التالي يُغيّر تلميحات العنوان والعنوان الفرعي في التخطيط المستخدم من قبل الشريحة الأولى:

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

النص التلميحي ليس محتوى شريحة عادي. يُقصد به العناصر النائبة الفارغة في تطبيقات التحرير مثل PowerPoint. بمجرد أن يضيف المستخدم أو البرنامج محتوى حقيقي، لن يُعرض التلميح بعد ذلك. تعديل التلميح لا يستبدل النص الموجود على الشرائح التي تستخدم التخطيط.

## **تحديث عنصر نائب للصورة**

هناك حالتان للتعامل معهما:

- إذا كان عنصر النائب للصورة مملوءًا بالفعل ومُمثلًا بـ [PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/)، استبدل الصورة من خلال [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/#getPictureFormat)، [PictureFillFormat.getPicture](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/#getPicture)، و[Picture.setImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picture/#setImage).
- إذا كان لا يزال عنصرًا نائبًا فارغًا، أضف إطار صورة عند إحداثيات العنصر النائب باستخدام [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) وأزل العنصر النائب الفارغ.

المثال التالي يدعم الحالتين ويحفظ العرض:

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

البديل المُنشأ لعنصر نائب فارغ هو إطار صورة محلي، وليس عنصرًا نائبًا جديدًا، لأن [Shape.getPlaceholder](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/#getPlaceholder) لا يوفر مُحددًا. يحتفظ بالموضع المحجوز لكنه لا يرث سلوك العنصر النائب بعد الآن. إذا كان الحفاظ على علاقة العنصر النائب أمرًا أساسيًا، حضّر العنصر النائب واملأه في PowerPoint أولاً، ثم حدّث [PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/) الناتج باستخدام Aspose.Slides.

لشفافية الصورة، القص، وغيرها من التأثيرات الخاصة بالصور، راجع [Manage Picture Frames](/slides/ar/nodejs-java/picture-frame/). تلك العمليات تنتمي إلى إطار الصورة أو تعبئة الصورة، لا إلى بيانات تعريف العنصر النائب.

## **العمل مع العناصر النائبة للمخطط والمحتوى**

يمكن تمثيل عنصر نائب مخطط مملوء بـ [Chart](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chart/). يُظهر المثال التالي كيفية العثور على مثل هذا المخطط عبر كل من نوع العنصر النائب وفئة الشكل في وقت التشغيل، وتغيير عنوانه، ثم حفظ الملف:

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

عادةً ما يحمل عنصر نائب المحتوى العام قيمة [PlaceholderType.Object](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/placeholdertype/#Object). في PowerPoint يعمل كمنطلق لعدة أنواع من المحتوى، بما في ذلك المخططات والجداول والرسوم التخطيطية والصور والوسائط. بعد ملئه، فحص فئة الشكل الفعلية لمعرفة ما يحتويه. يمكن للتخطيطات المتخصصة أيضًا أن تُظهر [PlaceholderType.Chart](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/placeholdertype/#Chart)، [PlaceholderType.Table](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/placeholdertype/#Table)، [PlaceholderType.Picture](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/placeholdertype/#Picture)، [PlaceholderType.Media](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/placeholdertype/#Media)، أو [PlaceholderType.Diagram](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides لا يحول عنصر نائب [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) فارغ إلى [Chart] بمجرد تغيير [Placeholder.getType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/placeholder/#getType)؛ لا يمكن تغيير النوع عبر الكائن. لملء مخطط أو منطقة محتوى فارغة برمجيًا، أضف الكائن المطلوب عند إحداثيات العنصر النائب ثم أزل العنصر النائب الفارغ. المثال التالي يوضح ذلك لمخطط:

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

المخطط المضاف هو مخطط محلي عادي. يشغل مساحة العنصر النائب لكنه لا يرث من عنصر النائب في التخطيط. استخدم مقالات إدارة المخططات المخصصة [chart management articles](/slides/ar/nodejs-java/powerpoint-charts/) عندما تحتاج إلى استبدال الفئات أو السلسلات أو بيانات المصنف.

## **مثال كامل: تحديث النص أو محتوى الصورة**

المثال التالي يغطي خطوة بخطوة فتح قالب، البحث في الشريحة الأولى عن عنصر نائب للعنوان أو الصورة، التحقق من نوع العنصر النائب والشكل، تحديث المحتوى المناسب، ثم حفظ النتيجة. يتجنب المثال بشكل مقصود افتراض فهرس شكل أو معاملة كل عنصر نائب كفئة واحدة:

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

**ما هو العنصر النائب الأساسي؟**

العنصر النائب الأساسي هو الشكل المقابل على التخطيط أو الرئيسة الذي يرث منه عنصر نائب آخر. استخدم [Shape.getBasePlaceholder](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/#getBasePlaceholder) لاسترجاعه. الشكل المحلي العادي يُعيد `null` لأنه ليس جزءًا من تسلسل العنصر النائب.

**هل يمكنني تغيير جميع عناوين الشرائح بتحرير عنصر نائب في التخطيط؟**

يمكنك تعديل التنسيق الموروث أو النص التلميحي عبر التخطيط، لكن محتوى العنوان الموجود يُخزن على الشرائح العادية. لاستبدال نص العنوان الفعلي في عرض تقديمي كامل، كرّر عبر الشرائح وقم بتحديث كل عنصر نائب للعنوان.

**كيف أدير عناصر النائب للتاريخ، رقم الشريحة، الرأس والتذييل؟**

استخدم مديري الرأس والتذييل في النطاق المناسب سواءً كان شريحة، تخطيط، رئيس، ملاحظات أو موزع يدوي. راجع [Manage Presentation Header and Footer](/slides/ar/nodejs-java/presentation-header-and-footer/) للحصول على أمثلة كاملة.