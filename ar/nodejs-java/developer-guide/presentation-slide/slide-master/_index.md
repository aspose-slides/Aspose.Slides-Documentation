---
title: إدارة قوالب شرائح العروض التقديمية في جافا سكريبت
linktitle: قالب الشريحة
type: docs
weight: 70
url: /ar/nodejs-java/slide-master/
keywords:
- قالب الشريحة
- شريحة رئيسية
- شريحة رئيسية في PPT
- عدة قوالب شرائح
- مقارنة قوالب الشرائح
- خلفية
- عنصر نائب
- استنساخ قالب الشريحة
- نسخ قالب الشريحة
- تكرار قالب الشريحة
- قالب شريحة غير مستخدم
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إدارة قوالب الشرائح في Aspose.Slides لـ Node.js عبر Java: الوصول، التعديل، الاستنساخ، المقارنة، وإزالة قوالب الشرائح في عروض PowerPoint وOpenDocument."
---
## **نظرة عامة**

**قالب الشريحة** يحدد إعدادات التصميم المشتركة لمجموعة من الشرائح. يمكن أن يحتوي على أشكال شائعة، شعارات، خلفيات، أنماط نص، إعدادات سمة، وإعدادات تذييل. في PowerPoint، تعديل قالب الشريحة هو الطريقة المعتادة للحفاظ على اتساق العرض دون تكرار نفس التنسيق في كل شريحة.

Aspose.Slides for Node.js via Java يدعم نفس النموذج. يمكن للعرض أن يحتوي على شريحة رئيسية واحدة أو أكثر، ويمكن لكل شريحة رئيسية أن تحتوي على عدة شرائح تخطيط. الشرائح العادية عادة لا تشير إلى شريحة رئيسية مباشرة. بدلاً من ذلك، تستخدم الشريحة العادية شريحة تخطيط، وتلك الشريحة التخطيطية تنتمي إلى شريحة رئيسية.

التسلسل الهرمي هو:

1. **قالب الشريحة** - يحدد التصميم المشترك والسمة.
1. **شريحة التخطيط** - تحدد ترتيبًا محددًا لعناصر النائب وتنسيق على مستوى التخطيط.
1. **الشريحة العادية** - تحتوي على محتوى العرض الفعلي وتستخدم شريحة تخطيط واحدة.

![التسلسل الهرمي لشرائح القالب، شرائح التخطيط، والشرائح العادية](slide-master_2.jpg)

في Aspose.Slides، يُمثَّل قالب الشريحة بواسطة الفئة [MasterSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslide/). جميع قوالب الشرائح في عرض ما متاحة من خلال مجموعة `Presentation.getMasters()`.

{{% alert color="info" title="الوراثة" %}}

عند تعريف الخاصية نفسها على أكثر من مستوى، يفوز المستوى الأكثر تحديدًا. على سبيل المثال، إذا عَرَّف قالب الشريحة وشريحة التخطيط خلفية، فإن الشرائح المستندة إلى ذلك التخطيط تستخدم خلفية التخطيط. لمزيد من المعلومات حول شرائح التخطيط، راجع [تطبيق أو تغيير تخطيطات الشريحة](/nodejs-java/slide-layout/).

{{% /alert %}}

## **الوصول إلى قوالب الشرائح**

في PowerPoint، يمكنك فتح عرض قالب الشريحة من **View** > **Slide Master**.

![أمر قالب الشريحة في علامة تبويب العرض في PowerPoint](slide-master_3.jpg)

في Aspose.Slides، استخدم مجموعة `getMasters()` للوصول إلى قوالب الشرائح:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let firstMasterSlide = presentation.getMasters().get_Item(0);
    let masterSlideCount = presentation.getMasters().size();
    let firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    console.log("Master slides: " + masterSlideCount);
    console.log("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

يمكنك أيضًا الحصول على قالب الشريحة المستخدم بواسطة شريحة عادية عبر تخطيطها:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let layoutSlide = slide.getLayoutSlide();
    let masterSlide = layoutSlide.getMasterSlide();
    let masterSlideName = masterSlide.getName();

    console.log(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **ما يحتويه قالب الشريحة**

قالب الشريحة هو كائن شبيه بالشريحة. إنه يرث سلوك الشريحة العامة من [BaseSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseslide/)، لذا فهو يتيح العديد من خصائص الشريحة نفسها المستخدمة في الشرائح العادية وشرائح التخطيط. يتم سرد الأعضاء الخاصة بالقالب في صفحة API لـ [MasterSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslide/).

الأعضاء الشائعة لقالب الشريحة تشمل:

| العضو | الغرض |
| --- | --- |
| `getBackground()` | يعيّن خلفية الشريحة على مستوى القالب. |
| `getShapes()` | يخزن الأشكال الموضوعة على القالب، مثل الشعارات، إطارات الصور، والنص المشترك. |
| `getLayoutSlides()` | يخزن شرائح التخطيط التي تنتمي إلى القالب. |
| `getThemeManager()` | يوفر الوصول إلى واجهات برمجة تطبيقات سمة القالب. |
| `getHeaderFooterManager()` | يتحكم في رؤوس وتذييلات وتواريخ وأرقام الشرائح للقالب وتخطيطاته الفرعية. |
| `getDependingSlides()` | يُرجع الشرائح العادية التي تعتمد على القالب من خلال تخطيطاتها. |

## **إضافة صورة إلى قالب الشريحة**

عند إضافة صورة إلى قالب الشريحة، تظهر على الشرائح التي تستخدم تخطيطات من ذلك القالب. هذا مفيد للشعارات، العلامات المائية، الأشرطة الزخرفية، وغيرها من العناصر البصرية المتكررة.

المثال التالي يضيف شعارًا إلى القالب الأول:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let logo = aspose.slides.Images.fromFile("logo.png");

    try {
        let logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            20,
            20,
            80,
            80,
            logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

لمزيد من المعلومات حول إطارات الصور، راجع [Picture Frame](/nodejs-java/picture-frame/).

## **التحكم في ظهور الرسومات القالبية**

استخدم [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseslide/#setShowMasterShapes) لإخفاء الرسومات القالبية الموروثة، مثل الشعارات أو الأشكال الزخرفية، دون حذفها من القالب. مرّر `false` إلى [Slide.setShowMasterShapes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/#setShowMasterShapes) على الشريحة التي ينبغي أن تحذف تلك الرسومات واحتفظ بـ `true` على الشرائح التي يجب أن تُظهرها.

المثال التالي المستقل يُنشئ شريطًا أزرقًا زخرفيًا على قالب ويستخدم شريحتين تخطيطية فارغتين. الشريط ظاهر على الشريحة الأولى ومخفي على الثانية. لا يلزم وجود عرض إدخال أو صورة.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);
    layoutSlide.setShowMasterShapes(true);

    let slideHeight = presentation.getSlideSize().getSize().getHeight();
    let band = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 60, slideHeight);
    let bandColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let noFillType = java.newByte(aspose.slides.FillType.NoFill);
    band.getFillFormat().setFillType(solidFillType);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(noFillType);

    let visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    let hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يستخدم المثال تخطيط **Blank** المرفق مع عرض جديد ويزيل العناصر النائبة الخاصة بالشريحة الأولية.

### **اختر نطاق الإعداد**

الشريحة العادية تستخدم القالب عبر [Slide.getLayoutSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/#getLayoutSlide) و[LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutslide/#getMasterSlide). ضبط الخاصية على شريحة فردية يؤثر فقط على تلك الشريحة. تمرير `false` إلى [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutslide/#setShowMasterShapes) يخفي الرسومات القالبية للشرائح التي تستخدم ذلك التخطيط المشترك، حتى وإن كان إعدادها الخاص `true`. لإخفاء الرسومات على شريحة واحدة فقط، غيّر خاصية الشريحة واترك التخطيط المشترك دون تغيير.

الإعداد غير مدعوم كتحكم في الظهور على القالب نفسه. على القالب، [getShowMasterShapes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslide/#getShowMasterShapes) يُعيد دائمًا `false`، وتمرير `true` إلى [setShowMasterShapes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslide/#setShowMasterShapes) يرفع استثناءً. طبّق ذلك على شريحة عادية أو تخطيط بدلاً من ذلك.

### **تمييز الرسومات عن الخلفية**

| العملية | التأثير |
| --- | --- |
| إخفاء الرسومات القالبية | يتحكم في ظهور الأشكال القالبية الموروثة دون حذفها أو تغيير أشكال الشريحة الخاصة. |
| تغيير تعبئة خلفية الشريحة | يغيّر لون الخلفية أو التدرج أو الصورة. الرسومات القالبية هي أشكال منفصلة ويمكن أن تظل مرئية فوق تلك الخلفية. راجع [Presentation Background](/slides/ar/nodejs-java/presentation-background/). |
| حذف شكل من القالب | يزيل الشكل المشترك المصدر، بحيث لا يصبح متاحًا لأي شريحة تستخدم ذلك القالب. |

## **العمل مع العناصر النائبة**

العناصر النائبة تُعرّف عادةً على شرائح التخطيط. يقدم قالب الشريحة النمط المشترك والسمة التي يرثها تلك التخطيطات، بينما يقرر كل تخطيط أي عناصر نائبة متاحة وأين تُوضع.

في PowerPoint، أوامر العنصر النائب متاحة في عرض قالب الشريحة.

![أمر إدراج العنصر النائب في عرض قالب الشريحة في PowerPoint](slide-master_5.png)

لإضافة عناصر نائبة جديدة باستخدام Aspose.Slides، اعمل مع شريحة التخطيط التي تنتمي إلى القالب:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayoutSlide === null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(blankLayoutType, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يمكنك أيضًا تنسيق أشكال العناصر النائبة الموجودة بالفعل على قالب الشريحة. المثال التالي يجد العنصر النائب للعنوان ويطبق تعبئة تدرج خطية:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titlePlaceholder = null;
    let masterShapes = masterSlide.getShapes();
    let masterShapeCount = masterShapes.size();

    for (let masterShapeIndex = 0; masterShapeIndex < masterShapeCount; masterShapeIndex++) {
        let shape = masterShapes.get_Item(masterShapeIndex);

        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            let placeholder = shape.getPlaceholder();

            if (placeholder !== null && placeholder.getType() === aspose.slides.PlaceholderType.Title) {
                titlePlaceholder = shape;
                break;
            }
        }
    }

    if (titlePlaceholder !== null) {
        let gradientFillType = java.newByte(aspose.slides.FillType.Gradient);
        let linearGradientShape = java.newByte(aspose.slides.GradientShape.Linear);
        let redGradientColor = java.newInstanceSync("java.awt.Color", 255, 0, 0);
        let purpleGradientColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(gradientFillType);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(linearGradientShape);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![العنوان النائب المُنسق الموروث من الشرائح العادية](slide-master_8.png)

لمزيد من خيارات تنسيق العناصر النائبة والنص، راجع [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) و[Text Formatting](/nodejs-java/text-formatting/).

## **تغيير خلفية قالب الشريحة**

خلفية القالب تُورّث إلى التخطيطات والشرائح التي لا تتجاوزها. المثال التالي يعيّن لون خلفية صلب للقالب الأول:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let masterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "GREEN");

    masterSlide.getBackground().setType(ownBackgroundType);
    masterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

للمواضيع ذات الصلة، راجع [Presentation Background](/nodejs-java/presentation-background/) و[Presentation Theme](/nodejs-java/presentation-theme/).

## **استنساخ قالب شريحة إلى عرض آخر**

استخدم `MasterSlideCollection.addClone` لنسخ قالب شريحة إلى عرض آخر. يمكن بعد ذلك استخدام القالب المنسوخ بواسطة التخطيطات والشرائح في العرض الوجهة.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let sourcePresentation = new aspose.slides.Presentation("source.pptx");
let destinationPresentation = new aspose.slides.Presentation("destination.pptx");
try {
    let sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    let clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

إذا كنت بحاجة إلى استنساخ الشرائح العادية مع قالبها، راجع [Clone Slides](/nodejs-java/clone-slides/).

## **إضافة قوالب شرائح متعددة**

يمكن للعرض أن يحتوي على عدة قوالب شرائح. هذا مفيد عندما تتطلب الأقسام المختلفة علامات تجارية مختلفة أو بنية صفحة أو إعدادات سمة مختلفة.

![أوامر PowerPoint لإدراج وإدارة قوالب الشرائح](slide-master_9.jpg)

المثال التالي يستنسخ القالب الافتراضي، يعطي النسخة خلفية مختلفة، يُنشئ تخطيطًا تحت ذلك القالب المستنسخ، ويضيف شريحة جديدة تستند إلى ذلك التخطيط:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let defaultMasterSlide = presentation.getMasters().get_Item(0);
    let sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let sectionMasterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    sectionMasterSlide.getBackground().setType(ownBackgroundType);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(blankLayoutType);
    if (sourceBlankLayout === null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    let sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **مقارنة قوالب الشرائح**

يمكن مقارنة قوالب الشرائح باستخدام طريقة `equals` الموروثة من [BaseSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseslide/). تقوم المقارنة بفحص الهيكل والمحتوى الثابت، مثل الأشكال والنص والتنسيق والرسوم المتحركة وإعدادات الشريحة الأخرى. لا تُقارن المعرفات الفريدة مثل معرفات الشرائح أو قيم العناصر النائبة الديناميكية مثل التاريخ الحالي.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let firstPresentation = new aspose.slides.Presentation("first.pptx");
let secondPresentation = new aspose.slides.Presentation("second.pptx");
try {
    let firstPresentationMasterCount = firstPresentation.getMasters().size();
    let secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (let firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (let secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            let firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            let secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            let areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                console.log(
                    "first.pptx master #" + firstMasterIndex +
                    " equals second.pptx master #" + secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

لمزيد من المعلومات، راجع [Compare Presentation Slides](/slides/ar/nodejs-java/compare-slides/).

## **ضبط عرض قالب الشريحة كعرض افتراضي**

استخدم طريقة `setLastView` على [ViewProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/viewproperties/) للتحكم في العرض الذي يفتحه PowerPoint أولًا. المثال التالي يفتح العرض في وضع قالب الشريحة:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

لإعدادات العرض الإضافية، راجع [Save Presentation](/slides/ar/nodejs-java/save-presentation/).

## **إزالة قوالب الشرائح غير المستخدمة**

أحيانًا تحتوي العروض على قوالب شرائح لم تعد تُستخدم من قبل أي شريحة عادية. إزالة القوالب غير المستخدمة يمكن أن يقلل حجم الملف ويبسط صيانة القالب.

استخدم `removeUnused` لإزالة القوالب غير المستخدمة من مجموعة `getMasters()`:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يمكنك أيضًا استخدام طريقة `Compress.removeUnusedMasterSlides` ذات الكود القليل:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة الشائعة**

**ما الفرق بين قالب الشريحة وشريحة التخطيط؟**

قالب الشريحة يحدد إعدادات التصميم المشتركة مثل السمة، الخلفية، الأشكال المشتركة، وأنماط النص. شريحة التخطيط تنتمي إلى قالب شريحة وتحدد ترتيبًا معينًا للعناصر النائبة. الشريحة العادية تستخدم شريحة التخطيط، لذا فإنها ترث من كل من التخطيط والقالب.

**هل يمكن لعرض واحد أن يحتوي على عدة قوالب شرائح؟**

نعم. يمكن للعرض أن يحتوي على عدة قوالب شرائح. استخدم قوالب متعددة عندما تحتاج أقسام مختلفة إلى أنظمة بصرية أو علامات تجارية مختلفة.

**هل يجب إضافة العناصر النائبة إلى قالب الشريحة أم إلى شريحة التخطيط؟**

في معظم الحالات، أضف العناصر النائبة إلى شرائح التخطيط. ضع العناصر البصرية المشتركة والتنسيق المشترك على قالب الشريحة، ثم ضع عناصر النائب المحتوى على التخطيطات التي ستستخدمها الشرائح العادية.

**هل يمكنني حذف قالب شريحة لا يزال قيد الاستخدام؟**

لا. لا يمكن حذف قالب شريحة لديه شرائح معتمدة بشكل آمن مباشرة. انقل تلك الشرائح إلى تخطيطات تحت قالب آخر، أو استخدم طريقة تنظيف القوالب غير المستخدمة التي تزيل فقط القوالب التي لا تُستَخدم.