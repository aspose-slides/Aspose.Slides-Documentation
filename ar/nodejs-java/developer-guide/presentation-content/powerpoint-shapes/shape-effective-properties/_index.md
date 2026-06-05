---
title: الحصول على الخصائص الفعّالة للأشكال من العروض التقديمية في جافا سكريبت
linktitle: الخصائص الفعّالة
type: docs
weight: 50
url: /ar/nodejs-java/shape-effective-properties/
keywords:
- خصائص الشكل
- خصائص الكاميرا
- تركيب الإضاءة
- شكل الحافة
- إطار النص
- نمط النص
- ارتفاع الخط
- تنسيق التعبئة
- PowerPoint
- العرض التقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "اكتشف كيف تحسب وتطبق Aspose.Slides لـ Node.js عبر Java الخصائص الفعّالة للأشكال لتحقيق عرض PowerPoint بدقة."
---
## **نظرة عامة**

يوضح هذا الموضوع الفرق بين الخصائص **المحلية** والخصائص **الفعّالة**. القيم المحلية هي القيم التي يتم تعيينها مباشرةً على مستوى تنسيق معين، مثل:

1. خصائص الجزء على الشريحة.
1. أنماط نص الشكل النموذجي على تخطيط أو شريحة رئيسية، عندما يكون لدى شكل إطار النص للجزء واحدة.
1. إعدادات النص العامة في العرض التقديمي.

يمكن تعريف القيم المحلية أو حذفها على أي مستوى. عندما تحتاج Aspose.Slides إلى التنسيق النهائي "كما يتم عرضه"، تقوم بحل سلسلة الوراثة وتعيد القيم **الفعّالة**. يمكنك الحصول عليها بواسطة استدعاء الطريقة `getEffective` على كائن التنسيق المحلي.

يظهر المثال التالي كيفية الحصول على القيم الفعّالة. يُفترض أن الشكل الأول على الشريحة الأولى هو [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) يحتوي على إطار نص وعلى الأقل جزء واحد.

```javascript

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    let localPortionFormat = paragraph.getPortions().get_Item(0).getPortionFormat();
    let effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
تُمثل بيانات التنسيق الفعّال التنسيق المُحسب الحالي بعد تطبيق الوراثة. في التنفيذ الحالي، قد يتم تخزين بعض كائنات البيانات الفعّالة مؤقتًا داخليًا. قد يؤدي استدعاء `getEffective` مرة أخرى بعد تعديل تنسيق الوالد أو التنسيق المُورّث إلى تحديث البيانات المخزنة مؤقتًا، وقد لا يمثل الكائن الذي تم الحصول عليه مسبقًا الحالة السابقة. إذا كنت بحاجة إلى الحفاظ على القيم الفعّالية لإعادة استخدامها لاحقًا، انسخ الخصائص المطلوبة، مثل ارتفاع الخط، لون التعبئة، نمط الخط، أو المحاذاة، إلى كائن البيانات الخاص بك.
{{% /alert %}}

## **الحصول على الخصائص الفعّالة للكاميرا**

تتيح لك Aspose.Slides الحصول على الخصائص الفعّالة للكاميرا. يحتوي كائن بيانات الكاميرا الفعّالية على خصائص كاميرا ثابتة ويتم إتاحة ذلك من خلال القيم الفعّالة التي تُرجعها الفئة [ThreeDFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/).

يعرض عينة الشيفرة التالية كيفية الحصول على الخصائص الفعّالة للكاميرا. يُفترض أن الشكل الأول على الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let camera = threeDEffectiveData.getCamera();
    let cameraType = camera.getCameraType();
    let fieldOfViewAngle = camera.getFieldOfViewAngle();
    let zoom = camera.getZoom();

    console.log("= Effective camera properties =");
    console.log("Type: " + cameraType);
    console.log("Field of view: " + fieldOfViewAngle);
    console.log("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **الحصول على الخصائص الفعّالة لتركيب الإضاءة**

تتيح لك Aspose.Slides الحصول على الخصائص الفعّالة لتركيب الإضاءة. يحتوي كائن بيانات تركيب الإضاءة الفعّالية على خصائص تركيب إضاءة ثابتة ويتم إتاحة ذلك من خلال القيم الفعّالة التي تُرجعها الفئة [ThreeDFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/).

يعرض عينة الشيفرة التالية كيفية الحصول على الخصائص الفعّالة لتركيب الإضاءة. يُفترض أن الشكل الأول على الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let lightRig = threeDEffectiveData.getLightRig();
    let lightType = lightRig.getLightType();
    let direction = lightRig.getDirection();

    console.log("= Effective light rig properties =");
    console.log("Type: " + lightType);
    console.log("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **الحصول على الخصائص الفعّالة لحافة الشكل**

تتيح لك Aspose.Slides الحصول على الخصائص الفعّالة لحافة الشكل. يحتوي كائن بيانات حافة الشكل الفعّالية على خصائص إغراس الوجه ثابتة ويتم إتاحة ذلك من خلال القيم الفعّالة التي تُرجعها الفئة [ThreeDFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/threedformat/).

يعرض عينة الشيفرة التالية كيفية الحصول على الخصائص الفعّالة للحافة العليا للشكل. يُفترض أن الشكل الأول على الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let bevelTop = threeDEffectiveData.getBevelTop();
    let bevelType = bevelTop.getBevelType();
    let bevelWidth = bevelTop.getWidth();
    let bevelHeight = bevelTop.getHeight();

    console.log("= Effective shape's top face relief properties =");
    console.log("Type: " + bevelType);
    console.log("Width: " + bevelWidth);
    console.log("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **الحصول على الخصائص الفعّالة لإطار النص**

باستخدام Aspose.Slides، يمكنك الحصول على الخصائص الفعّالة لإطار النص. يحتوي كائن البيانات الفعّالية المرتجع على خصائص تنسيق إطار النص.

يعرض عينة الشيفرة التالية كيفية الحصول على خصائص تنسيق إطار النص الفعّالية. يُفترض أن الشكل الأول على الشريحة الأولى هو [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) يحتوي على إطار نص.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = textFrameFormat.getEffective();
    let anchoringType = effectiveTextFrameFormat.getAnchoringType();
    let autofitType = effectiveTextFrameFormat.getAutofitType();
    let textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    let marginLeft = effectiveTextFrameFormat.getMarginLeft();
    let marginTop = effectiveTextFrameFormat.getMarginTop();
    let marginRight = effectiveTextFrameFormat.getMarginRight();
    let marginBottom = effectiveTextFrameFormat.getMarginBottom();

    console.log("Anchoring type: " + anchoringType);
    console.log("Autofit type: " + autofitType);
    console.log("Text vertical type: " + textVerticalType);
    console.log("Margins");
    console.log("   Left: " + marginLeft);
    console.log("   Top: " + marginTop);
    console.log("   Right: " + marginRight);
    console.log("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **الحصول على الخصائص الفعّالة لنمط النص**

باستخدام Aspose.Slides، يمكنك الحصول على الخصائص الفعّالة لنمط النص. يحتوي كائن البيانات الفعّالية المرتجع على خصائص نمط النص.

يعرض عينة الشيفرة التالية كيفية الحصول على خصائص نمط النص الفعّالية. يُفترض أن الشكل الأول على الشريحة الأولى هو [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) يحتوي على إطار نص.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);
    let effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    let levelCount = 9;

    for (let levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        let effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        let depth = effectiveStyleLevel.getDepth();
        let indent = effectiveStyleLevel.getIndent();
        let alignment = effectiveStyleLevel.getAlignment();
        let fontAlignment = effectiveStyleLevel.getFontAlignment();

        console.log("= Effective paragraph formatting for style level #" + levelIndex + " =");

        console.log("Depth: " + depth);
        console.log("Indent: " + indent);
        console.log("Alignment: " + alignment);
        console.log("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **الحصول على قيمة ارتفاع الخط الفعّالية**

باستخدام Aspose.Slides، يمكنك الحصول على ارتفاع الخط الفعّالي. يوضح الشيفرة التالية كيف يتغيّر ارتفاع الخط الفعّالي للجزء بعد تعيين قيم ارتفاع الخط المحلي على مستويات مختلفة من بنية العرض التقديمي.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shapeType = aspose.slides.ShapeType.Rectangle;
    let autoShape = slide.getShapes().addAutoShape(shapeType, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    let firstPortion = new aspose.slides.Portion("Sample text with first portion");
    let secondPortion = new aspose.slides.Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    let firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    let secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    let firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    let secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height just after creation:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting the presentation default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting paragraph default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #0 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #1 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    let saveFormat = aspose.slides.SaveFormat.Pptx;
    presentation.save("SetLocalFontHeightValues.pptx", saveFormat);
} finally {
    presentation.dispose();
}
```

## **الحصول على تنسيق التعبئة الفعّالي للجدول**

باستخدام Aspose.Slides، يمكنك الحصول على تنسيق التعبئة الفعّالي لأجزاء مختلفة من الجدول. يحتوي كائن البيانات الفعّالية المرتجع على خصائص تنسيق التعبئة. تنسيق الخلية له أولوية أعلى من تنسيق الصف، وتنسيق الصف له أولوية أعلى من تنسيق العمود، وتنسيق العمود له أولوية أعلى من تنسيق الجدول بأكمله.

وبالتالي، تُستخدم خصائص تنسيق الخلية الفعّالية لرسم خلية الجدول. يعرض عينة الشيفرة التالية كيفية الحصول على تنسيق التعبئة الفعّالي لأجزاء مختلفة من الجدول. يُفترض أن الشكل الأول على الشريحة الأولى هو [Table](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/table/).

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let table = slide.getShapes().get_Item(0);

    let tableFormatEffective = table.getTableFormat().getEffective();
    let rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    let columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    let cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    let tableFillFormatEffective = tableFormatEffective.getFillFormat();
    let rowFillFormatEffective = rowFormatEffective.getFillFormat();
    let columnFillFormatEffective = columnFormatEffective.getFillFormat();
    let cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **الأسئلة الشائعة**

**هل تُعيد الدالة `getEffective` لقطة؟**

ليس دائماً. تمثّل البيانات الفعّالية التنسيق المُحسب بعد تطبيق الوراثة، لكن بعض كائنات البيانات الفعّالية قد تُخزّن مؤقتًا داخليًا. قد يؤدي استدعاء `getEffective` لاحقًا إلى إعادة حساب التنسيق وتحديث البيانات المخزنة، لذا لا ينبغي اعتبار الكائن الذي تم الحصول عليه مسبقًا كقطة ثابتة.

**متى يجب قراءة الخصائص الفعّالة مرة أخرى؟**

استدعِ `getEffective` مرة أخرى بعد تعديل التنسيق المحلي أو أنماط الوالد أو تنسيق التخطيط أو تنسيق الرئيس أو الإعدادات الافتراضية على مستوى العرض التقديمي. ستُعيد المكالمة التالية تقييم شجرة التنسيق وتُعيد النتيجة الفعّالية الحالية.

**هل يؤثر تعديل أو إزالة شريحة تخطيط/رئيسية على الخصائص الفعّالة التي تم استردادها مسبقًا؟**

نعم، لكن التغيير ينعكس في الاستدعاء التالي لـ `getEffective`. إذا تم تعديل مصدر تنسيق الوالد أو إزالته، قد تصبح البيانات الفعّالية المسترجعة سابقًا قديمة. بمجرد استدعاء `getEffective` مرة أخرى، تعيد Aspose.Slides تقييم شجرة التنسيق وقد تتغير الخطوط أو الألوان أو الأحجام أو القيم الأخرى.

**هل يمكنني تعديل القيم من خلال كائنات البيانات الفعّالية؟**

لا. تُظهر كائنات البيانات الفعّالية القيم المُحسبّة فقط. قم بإجراء التغييرات في كائنات التنسيق المحلي، ثم احصل على القيم الفعّالية مرة أخرى.

**ماذا يحدث إذا لم يتم تعيين خاصية على مستوى الشكل ولا على التخطيط/الرئيسية ولا في الإعدادات العامة؟**

يُحدَّد القيمة الفعّالية عبر الآلية الافتراضية، التي تشمل إعدادات PowerPoint وAspose.Slides. تصبح القيمة المُحللة جزءًا من البيانات الفعّالية الحالية.

**من قيمة الخط الفعّالي، هل يمكنني معرفة أي مستوى قدم الحجم أو نوع الخط؟**

ليس مباشرة. تُعيد البيانات الفعّالية القيمة النهائية. لتحديد المصدر، راجع القيم المحلية على مستوى الجزء، الفقرة، إطار النص، أنماط النص في التخطيط، الرئيس، ومستوى العرض التقديمي لتحديد أول تعريف صريح يظهر.

**لماذا تبدو القيم الفعّالية أحيانًا مطابقة للقيم المحلية؟**

لأن القيمة المحلية انتهت بأنها النهائية (لم يكن هناك حاجة للوراثة من مستوى أعلى). في هذه الحالة، تتطابق القيمة الفعّالية مع القيمة المحلية.

**متى يجب استخدام الخصائص الفعّالية، ومتى أكتفي بالخصائص المحلية؟**

استخدم البيانات الفعّالية عندما تحتاج إلى النتيجة "كما تُعرض" بعد تطبيق كل الوراثة، مثل مطابقة الألوان أو الهوامش أو الأحجام. إذا كنت بحاجة إلى الحفاظ على هذه القيم بغض النظر عن التغييرات المستقبلية، انسخ الخصائص المطلوبة إلى كائنك الخاص. إذا كنت بحاجة إلى تعديل التنسيق على مستوى معين، عدّل الخصائص المحلية ثم، إذا لزم الأمر، اقرأ البيانات الفعّالية مرة أخرى للتحقق من النتيجة.