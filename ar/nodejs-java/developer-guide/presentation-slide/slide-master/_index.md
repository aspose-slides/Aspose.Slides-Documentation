---
title: إدارة شرائح الماستر في العروض التقديمية باستخدام JavaScript
linktitle: ماستر الشريحة
type: docs
weight: 70
url: /ar/nodejs-java/slide-master/
keywords:
- ماستر الشريحة
- شريحة ماستر
- شريحة ماستر PPT
- شرائح ماستر متعددة
- مقارنة شرائح الماستر
- خلفية
- حامل مكان
- استنساخ شريحة ماستر
- نسخ شريحة ماستر
- تكرار شريحة ماستر
- شريحة ماستر غير مستخدمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إدارة شرائح الماستر في Aspose.Slides لـ Node.js عبر Java: الوصول، التحرير، الاستنساخ، المقارنة، وإزالة شرائح الماستر في عروض PowerPoint وOpenDocument."
---
## **نظرة عامة**

**slide master** يعرّف إعدادات التصميم المشتركة لمجموعة من الشرائح. يمكن أن يحتوي على أشكال شائعة، شعارات، خلفيات، أنماط نصية، إعدادات سمة، وإعدادات تذييل. في PowerPoint، تعديل الـ slide master هو الطريقة المعتادة للحفاظ على اتساق العرض دون تكرار نفس التنسيق في كل شريحة.

Aspose.Slides for Node.js via Java يدعم النموذج نفسه. يمكن للعرض التقديمي أن يحتوي على شريحة رئيسية واحدة أو أكثر، ويمكن لكل شريحة رئيسية أن تحتوي على عدة شرائح تخطيط. الشرائح العادية عادةً لا تشير مباشرة إلى شريحة رئيسية. بدلاً من ذلك، تستخدم الشريحة العادية شريحة تخطيط، وتلك الشريحة التخطيطية تنتمي إلى شريحة رئيسية.

التسلسل الهرمي هو:

1. **Slide master** - يحدد التصميم المشترك والسمة.
1. **Layout slide** - يحدد ترتيبًا محددًا للحوامل وتنسيق على مستوى التخطيط.
1. **Normal slide** - يحتوي على محتوى العرض الفعلي ويستخدم شريحة تخطيط واحدة.

![التسلسل الهرمي لشرائح الماستر، شرائح التخطيط، والشرائح العادية](slide-master_2.jpg)

في Aspose.Slides، تمثّل شريحة الماستر بواسطة الفئة [MasterSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslide/). جميع شرائح الماستر في عرض تقديمي متاحة عبر مجموعة `Presentation.getMasters()`.

{{% alert color="info" title="Inheritance" %}}

عند تعريف الخاصية نفسها على أكثر من مستوى، المستوى الأكثر تحديدًا هو الفائز. على سبيل المثال، إذا عرّفت شريحة ماستر وشريحة تخطيط خلفية، فإن الشرائح القائمة على ذلك التخطيط تستخدم خلفية التخطيط. لمزيد من المعلومات حول شرائح التخطيط، راجع [Apply or Change Slide Layouts](/nodejs-java/slide-layout/).

{{% /alert %}}

## **الوصول إلى Slide Masters**

في PowerPoint، يمكنك فتح عرض شريحة الماستر من **View** > **Slide Master**.

![أمر Slide Master في علامة تبويب View في PowerPoint](slide-master_3.jpg)

في Aspose.Slides، استخدم مجموعة `getMasters()` للوصول إلى شرائح الماستر:

```javascript
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

يمكنك أيضًا الحصول على شريحة الماستر المستخدمة من قبل شريحة عادية عبر تخطيطها:

```javascript
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

## **ما يحتويه Slide Master**

شريحة الماستر هي كائن يشبه الشريحة. إنها ترث سلوك الشريحة العامة من [BaseSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseslide/)، لذا فهي تعرض العديد من خصائص الشريحة نفسها المستخدمة في الشرائح العادية وشرائح التخطيط. الأعضاء الخاصة بالماستر مدرجة في صفحة API الخاصة بـ [MasterSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslide/).

الأعضاء الشائعة المستخدمة في شريحة الماستر تشمل:

| العضو | الغرض |
| --- | --- |
| `getBackground()` | يحدد خلفية الشريحة على مستوى الماستر. |
| `getShapes()` | يخزن الأشكال الموضوعة على الماستر، مثل الشعارات وإطارات الصور والنص المشترك. |
| `getLayoutSlides()` | يخزن شرائح التخطيط التي تنتمي إلى الماستر. |
| `getThemeManager()` | يوفر الوصول إلى واجهات برمجة سمة الماستر. |
| `getHeaderFooterManager()` | يتحكم في رؤوس وتذييلات وتواريخ وأرقام الشرائح للماستر وتخطيطاته الفرعية. |
| `getDependingSlides()` | يرجع الشرائح العادية التي تعتمد على الماستر عبر تخطيطاتها. |

## **إضافة صورة إلى Slide Master**

عند إضافة صورة إلى شريحة ماستر، تظهر على الشرائح التي تستخدم تخطيطات من ذلك الماستر. هذا مفيد للشعارات، العلامات المائية، الشرائط الزخرفية، وغيرها من العناصر البصرية المتكررة.

المثال التالي يضيف شعارًا إلى أول شريحة ماستر:

```javascript
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

لمزيد من المعلومات حول إطارات الصور، اطلع على [Picture Frame](/nodejs-java/picture-frame/).

## **العمل مع Placeholders**

عادةً ما تُعرّف الحوامل (placeholders) على شرائح التخطيط. يوفر شريحة الماستر النمط والسمة المشتركة التي يرثها تلك التخطيطات، بينما يقرر كل تخطيط أي الحوامل متاحة وأين توضع.

في PowerPoint، تتوفر أوامر الحواجز في عرض Slide Master.

![أمر Insert Placeholder في عرض Slide Master في PowerPoint](slide-master_5.png)

لإضافة حواجز جديدة باستخدام Aspose.Slides، تعامل مع شريحة التخطيط التي تنتمي إلى الماستر:

```javascript
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

يمكنك أيضًا تنسيق أشكال الحواجز الموجودة مسبقًا على شريحة ماستر. المثال التالي يجد حامل العنوان ويطبق تعبئة تدرج خطية:

```javascript
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
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![حامل عنوان مُنسق موروث من الشرائح العادية](slide-master_8.png)

لمزيد من خيارات تنسيق الحواجز والنص، راجع [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) و[Text Formatting](/nodejs-java/text-formatting/).

## **تغيير خلفية Slide Master**

خلفية الماستر تُورّث من قبل التخطيطات والشرائح التي لا تتجاوزها. المثال التالي يحدد لون خلفية صلبة لأول شريحة ماستر:

```javascript
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

## **استنساخ Slide Master إلى عرض تقديمي آخر**

استخدم `MasterSlideCollection.addClone` لنسخ شريحة ماستر إلى عرض تقديمي آخر. يمكن بعد ذلك استخدام الماستر المنسوخ بواسطة التخطيطات والشرائح في العرض الوجهة.

```javascript
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

إذا كنت بحاجة إلى استنساخ الشرائح العادية مع الماستر الخاص بها، راجع [Clone Slides](/nodejs-java/clone-slides/).

## **إضافة عدة Slide Masters**

يمكن للعرض التقديمي أن يحتوي على عدة شرائح ماستر. هذا مفيد عندما تتطلب الأقسام المختلفة علامات تجارية مختلفة أو بنية صفحة أو إعدادات سمة.

![أوامر PowerPoint لإدراج وإدارة شرائح الماستر](slide-master_9.jpg)

المثال التالي يستنسخ الماستر الافتراضي، يمنح الاستنساخ خلفية مختلفة، ينشئ تخطيطًا تحت ذلك الماستر المستنسخ، ويضيف شريحة جديدة تعتمد على ذلك التخطيط:

```javascript
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

## **مقارنة Slide Masters**

يمكن مقارنة شرائح الماستر باستخدام طريقة `equals` الموروثة من [BaseSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseslide/). يقارن الهيكل والمحتوى الثابت، مثل الأشكال والنص والتنسيق والرسوم المتحركة وإعدادات الشريحة الأخرى. لا يقارن المعرفات الفريدة مثل معرفات الشرائح أو قيم الحواجز الديناميكية مثل التاريخ الحالي.

```javascript
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

لمزيد من المعلومات، راجع [Compare Presentation Slides](/nodejs-java/compare-slides/).

## **تعيين عرض Slide Master كعرض افتراضي**

استخدم طريقة `setLastView` على [ViewProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/viewproperties/) للتحكم في العرض الذي يفتحه PowerPoint أولاً. المثال التالي يفتح العرض في وضع Slide Master:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

لإعدادات عرض إضافية، راجع [Save Presentation](/nodejs-java/save-presentation/).

## **إزالة Slide Masters غير المستخدمة**

أحيانًا يحتوي العرض على شرائح ماستر لم تعد تُستخدم من قبل أي شرائح عادية. إزالة الماسترات غير المستخدمة يمكن أن يقلل من حجم الملف ويسهّل صيانة القالب.

استخدم `removeUnused` لإزالة الماسترات غير المستخدمة من مجموعة `getMasters()`:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يمكنك أيضًا استخدام طريقة `Compress.removeUnusedMasterSlides` ذات الكود المنخفض:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**ما الفرق بين slide master و layout slide؟**

slide master يحدد إعدادات التصميم المشتركة مثل السمة، الخلفية، الأشكال المشتركة، وأنماط النص. layout slide ينتمي إلى slide master ويعرّف ترتيبًا محددًا للحوامل. الشريحة العادية تستخدم layout slide، وبالتالي ترث من كل من التخطيط والماستر.

**هل يمكن لعرض تقديمي واحد أن يحتوي على عدة slide masters؟**

نعم. يمكن للعرض أن يحتوي على عدة slide masters. استخدم عدة ماسترات عندما تحتاج أقسام مختلفة إلى أنظمة بصرية أو علامات تجارية مختلفة.

**هل يجب إضافة الحواجز إلى slide master أم إلى layout slide؟**

في معظم الحالات، أضف الحواجز إلى layout slides. ضع العناصر البصرية المشتركة والتنسيق المشترك على slide master، ثم ضع حواجز المحتوى على التخطيطات التي ستستخدمها الشرائح العادية.

**هل يمكنني حذف شريحة ماستر لا تزال مستخدمة؟**

لا. لا يمكن حذف شريحة ماستر لديها شرائح تابعة بأمان. يجب أولاً نقل تلك الشرائح إلى تخطيطات تحت ماستر آخر، أو استخدام طريقة تنظيف الماسترات غير المستخدمة التي تزيل فقط الماسترات غير المستعملة.