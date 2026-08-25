---
title: إدارة الشرائح الرئيسية للعرض التقديمي في JavaScript
linktitle: الشريحة الرئيسية
type: docs
weight: 70
url: /ar/nodejs-java/slide-master/
keywords:
- شريحة رئيسية
- شريحة رئيسية
- شريحة رئيسية PPT
- عدة شرائح رئيسية
- مقارنة الشرائح الرئيسية
- خلفية
- عنصر نائب
- استنساخ شريحة رئيسية
- نسخ شريحة رئيسية
- تكرار شريحة رئيسية
- شريحة رئيسية غير مستخدمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إدارة الشرائح الرئيسية في Aspose.Slides لـ Node.js عبر Java: الوصول، التعديل، الاستنساخ، المقارنة، وإزالة الشرائح الرئيسية في عروض PowerPoint و OpenDocument."
---
## **نظرة عامة**

تحدّد **الشريحة الرئيسية** إعدادات التصميم المشتركة لمجموعة من الشرائح. يمكن أن تحتوي على أشكال مشتركة، وشعارات، وخلفيات، وأنماط نص، وإعدادات السمة، وإعدادات التذييل. في PowerPoint، يعتبر تعديل الشريحة الرئيسية الطريقة المعتادة للحفاظ على تناسق العرض التقديمي دون تكرار نفس التنسيق في كل شريحة.

يدعم Aspose.Slides لـ Node.js عبر Java النموذج نفسه. يمكن للعرض التقديمي أن يحتوي على شريحة رئيسية واحدة أو أكثر، ويمكن لكل شريحة رئيسية أن تحتوي على عدة شرائح تخطيط. عادةً لا تشير الشرائح العادية إلى شريحة رئيسية مباشرةً. بدلاً من ذلك، تستخدم الشريحة العادية شريحة تخطيط، وتكون شريحة التخطيط تلك جزءًا من شريحة رئيسية.

التسلسل الهرمي هو:

1. **الشريحة الرئيسية** - تحدد التصميم المشترك والسمة.
1. **شريحة التخطيط** - تحدد ترتيبًا محددًا للأنماط النائبة وتنسيق مستوى التخطيط.
1. **الشريحة العادية** - تحتوي على محتوى العرض التقديمي الفعلي وتستخدم شريحة تخطيط واحدة.

![تسلسل الشرائح الرئيسية، شرائح التخطيط، والشرائح العادية](slide-master_2.jpg)

في Aspose.Slides، تمثّلت الشريحة الرئيسية بواسطة الفئة [MasterSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslide/). جميع الشرائح الرئيسية في عرض تقديمي متاحة من خلال مجموعة `Presentation.getMasters()`.

{{% alert color="info" title="Inheritance" %}}
عند تعريف الخاصية نفسها في أكثر من مستوى، يفوز المستوى الأكثر تحديدًا. على سبيل المثال، إذا كانت الشريحة الرئيسية وشريحة التخطيط كل منهما تحدد خلفية، فإن الشرائح المستندة إلى ذلك التخطيط تستخدم خلفية التخطيط. للمزيد من المعلومات حول شرائح التخطيط، راجع [تطبيق أو تغيير تخطيطات الشرائح](/nodejs-java/slide-layout/).
{{% /alert %}}

## **الوصول إلى الشرائح الرئيسية**

في PowerPoint، يمكنك فتح عرض الشريحة الرئيسية من **View** > **Slide Master**.

![أمر الشريحة الرئيسية في علامة تبويب View في PowerPoint](slide-master_3.jpg)

في Aspose.Slides، استخدم مجموعة `getMasters()` للوصول إلى الشرائح الرئيسية:

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

يمكنك أيضًا الحصول على الشريحة الرئيسية المستخدمة بواسطة شريحة عادية من خلال تخطيطها:

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

## **ما تحتويه الشريحة الرئيسية**

الشريحة الرئيسية هي كائن شبيه بالشريحة. تورث السلوك الشائع للشرائح من الفئة [BaseSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseslide/). وبالتالي تكشف عن العديد من خصائص الشرائح نفسها التي تُستخدم في الشرائح العادية وشرائح التخطيط. الأعضاء الخاصة بالشريحة الرئيسية مدرجة في صفحة API لـ [MasterSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslide/).

الأعضاء الشائعة الاستخدام في الشريحة الرئيسية تشمل:

| العضو | الغرض |
| --- | --- |
| `getBackground()` | يضبط خلفية الشريحة على مستوى الشريحة الرئيسية. |
| `getShapes()` | يخزن الأشكال الموضوعة على الشريحة الرئيسية، مثل الشعارات، وإطارات الصور، والنص المشترك. |
| `getLayoutSlides()` | يخزن شرائح التخطيط التي تنتمي إلى الشريحة الرئيسية. |
| `getThemeManager()` | يوفر الوصول إلى واجهات برمجة تطبيقات سمة الشريحة الرئيسية. |
| `getHeaderFooterManager()` | يتحكم في رؤوس وتذييلات وتواريخ وأرقام الشرائح للشريحة الرئيسية وتخطيطاتها الفرعية. |
| `getDependingSlides()` | يرجع الشرائح العادية التي تعتمد على الشريحة الرئيسية عبر تخطيطاتها. |

## **إضافة صورة إلى الشريحة الرئيسية**

عند إضافة صورة إلى الشريحة الرئيسية، تظهر على الشرائح التي تستخدم تخطيطات من تلك الشريحة. هذا مفيد للشعارات، العلامات المائية، الأشرطة الزخرفية، وعناصر بصرية أخرى متكررة.

المثال التالي يضيف شعارًا إلى الشريحة الرئيسية الأولى:

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

للمزيد من المعلومات حول إطارات الصور، راجع [إطار الصورة](/nodejs-java/picture-frame/).

## **العمل مع العناصر النائبة**

عادةً ما تُعرَّف العناصر النائبة على شرائح التخطيط. توفر الشريحة الرئيسية النمط والسمة المشتركة التي يرثها تلك التخطيطات، بينما يقرر كل تخطيط أي العناصر النائبة متاحة وأين يتم وضعها.

في PowerPoint، أوامر العناصر النائبة متوفرة في عرض الشريحة الرئيسية.

![أمر إدراج عنصر نائبي في عرض الشريحة الرئيسية في PowerPoint](slide-master_5.png)

لإضافة عناصر نائبة جديدة باستخدام Aspose.Slides، تعامل مع شريحة التخطيط التي تنتمي إلى الشريحة الرئيسية:

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

يمكنك أيضًا تنسيق أشكال العناصر النائبة الموجودة بالفعل على الشريحة الرئيسية. المثال التالي يجد عنصر النائب للعنوان ويطبق تعبئة تدرج خطي:

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

![عنصر نائب للعنوان مُنسق ومُرث من الشرائح العادية](slide-master_8.png)

للمزيد من خيارات تنسيق العناصر النائبة والنص، راجع [تعيين نص المطالبة في العنصر النائب](/nodejs-java/manage-placeholder/) و[تنسيق النص](/nodejs-java/text-formatting/).

## **تغيير خلفية الشريحة الرئيسية**

يتم توريث خلفية الشريحة الرئيسية إلى التخطيطات والشرائح التي لا تقوم بتجاوزها. المثال التالي يضبط لون خلفية صلب للشريحة الرئيسية الأولى:

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

للمواضيع ذات الصلة، راجع [خلفية العرض التقديمي](/nodejs-java/presentation-background/) و[سمة العرض التقديمي](/nodejs-java/presentation-theme/).

## **استنساخ شريحة رئيسية إلى عرض تقديمي آخر**

استخدم `MasterSlideCollection.addClone` لنسخ شريحة رئيسية إلى عرض تقديمي آخر. يمكن بعد ذلك استخدام الشريحة المنسوخة من قبل التخطيطات والشرائح في العرض التقديمي الهدف.

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

إذا كنت بحاجة إلى استنساخ الشرائح العادية مع شريحتها الرئيسية، راجع [استنساخ الشرائح](/nodejs-java/clone-slides/).

## **إضافة عدة شرائح رئيسية**

يمكن للعرض التقديمي أن يحتوي على عدة شرائح رئيسية. هذا مفيد عندما تتطلب الأقسام المختلفة علامة تجارية مختلفة أو هيكل صفحة أو إعدادات سمة مختلفة.

![أوامر PowerPoint لإدراج وإدارة الشرائح الرئيسية](slide-master_9.jpg)

المثال التالي يستنسخ الشريحة الرئيسية الافتراضية، يمنح النسخة نسخة خلفية مختلفة، ينشئ تخطيطًا تحت تلك الشريحة المستنسخة، ويضيف شريحة جديدة بناءً على ذلك التخطيط:

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

## **مقارنة الشرائح الرئيسية**

يمكن مقارنة الشرائح الرئيسية باستخدام طريقة `equals` الموروثة من [BaseSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseslide/). تقوم المقارنة بفحص الهيكل والمحتوى الثابت، مثل الأشكال والنص والتنسيق والرسوم المتحركة وإعدادات الشرائح الأخرى. لا تتم مقارنة المعرفات الفريدة، مثل معرفات الشرائح، أو القيم الديناميكية للعناصر النائبة، مثل التاريخ الحالي.

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

للمزيد من المعلومات، راجع [مقارنة شرائح العرض التقديمي](/slides/ar/nodejs-java/compare-slides/).

## **تعيين عرض شريحة رئيسية كعرض افتراضي**

استخدم طريقة `setLastView` على [ViewProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/viewproperties/) للتحكم في العرض الذي يفتحه PowerPoint أولاً. المثال التالي يفتح العرض التقديمي في عرض الشريحة الرئيسية:

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

للمزيد من إعدادات العرض، راجع [حفظ العرض التقديمي](/slides/ar/nodejs-java/save-presentation/).

## **إزالة الشرائح الرئيسية غير المستخدمة**

أحيانًا يحتوي العروض التقديمية على شرائح رئيسية لم تعد تُستخدم من قبل أي شريحة عادية. يمكن أن يقلل إزالة الشرائح الرئيسية غير المستخدمة من حجم الملف ويسهل صيانة القالب.

استخدم `removeUnused` لإزالة الشرائح الرئيسية غير المستخدمة من مجموعة `getMasters()`:

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

يمكنك أيضًا استخدام طريقة `Compress.removeUnusedMasterSlides` منخفضة الكود:

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

## **الأسئلة المتكررة**

### ما الفرق بين الشريحة الرئيسية وشريحة التخطيط؟

تحدد الشريحة الرئيسية إعدادات التصميم المشتركة مثل السمة، الخلفية، الأشكال المشتركة، وأنماط النص. تنتمي شريحة التخطيط إلى الشريحة الرئيسية وتحدد ترتيبًا محددًا للعناصر النائبة. تستخدم الشريحة العادية شريحة تخطيط، وبالتالي ترث من كل من التخطيط والشريحة الرئيسية.

### هل يمكن لعرض تقديمي واحد أن يحتوي على عدة شرائح رئيسية؟

نعم. يمكن للعرض التقديمي أن يحتوي على عدة شرائح رئيسية. استخدم عدة شرائح رئيسية عندما تحتاج الأقسام المختلفة إلى أنظمة بصرية أو علامات تجارية مختلفة.

### هل يجب إضافة العناصر النائبة إلى الشريحة الرئيسية أم إلى شريحة التخطيط؟

في معظم الحالات، أضف العناصر النائبة إلى شرائح التخطيط. ضع العناصر البصرية المشتركة والتنسيق المشترك على الشريحة الرئيسية، ثم ضع عناصر المحتوى النائبة على التخطيطات التي ستستخدمها الشرائح العادية.

### هل يمكن حذف شريحة رئيسية لا تزال قيد الاستخدام؟

لا. لا يمكن حذف شريحة رئيسية لديها شرائح معتمدة بأمان مباشرةً. يجب أولاً نقل تلك الشرائح إلى تخطيطات تحت شريحة أخرى، أو استخدام طريقة تنظيف الشرائح الرئيسية غير المستخدمة التي تزيل فقط الشرائح التي لا تُستَخدم.