---
title: إدارة شرائح الرئيس في العروض التقديمية على Android
linktitle: شريحة الرئيس
type: docs
weight: 70
url: /ar/androidjava/slide-master/
keywords:
- شريحة رئيس
- شريحة رئيسية
- شريحة رئيس PPT
- شرائح رئيسية متعددة
- مقارنة شرائح الرئيس
- خلفية
- عنصر نائب
- استنساخ شريحة رئيس
- نسخ شريحة رئيس
- تكرار شريحة رئيس
- شريحة رئيس غير مستخدمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إدارة شرائح الرئيس في Aspose.Slides for Android عبر Java: الوصول، التعديل، الاستنساخ، المقارنة، وإزالة شرائح الرئيس في عروض PowerPoint وOpenDocument."
---
## **نظرة عامة**

يُعرّف **slide master** إعدادات التصميم المشتركة لمجموعة من الشرائح. يمكن أن يحتوي على أشكال مشتركة، وشعارات، وخلفيات، وأنماط نصية، وإعدادات سمة، وإعدادات تذييل. في PowerPoint، يُعد تعديل slide master الطريقة المعتادة للحفاظ على تناسق العرض التقديمي دون تكرار نفس التنسيق في كل شريحة.

يدعم Aspose.Slides for Android عبر Java النموذج نفسه. يمكن للعرض التقديمي أن يحتوي على شريحة رئيسية واحدة أو أكثر، ويمكن لكل شريحة رئيسية أن تحتوي على عدة شرائح تخطيط. عادةً لا تُشير الشرائح العادية إلى شريحة رئيسية مباشرة. بدلاً من ذلك، تستخدم الشريحة العادية شريحة تخطيط، وتلك الشريحة التخطيطية تنتمي إلى شريحة رئيسية.

التسلسل الهرمي هو:

1. **Slide master** - يحدد التصميم والسمة المشتركة.  
1. **Layout slide** - يعرّف ترتيبًا محددًا للعناصر النائبة وتنسيق على مستوى التخطيط.  
1. **Normal slide** - يحتوي على محتوى العرض الفعلي ويستخدم شريحة تخطيط واحدة.

![تسلسل شريحة الرئيس، شرائح التخطيط، والشرائح العادية](slide-master_2.jpg)

في Aspose.Slides، يُمثَّل slide master بواجهة [IMasterSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterslide/). جميع الشرائح الرئيسة في عرض تقديمي متوفرة عبر مجموعة [Presentation.getMasters](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getMasters--)، التي تُنفّذ [IMasterSlideCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterslidecollection/). للاطلاع على كامل سطح API لـ Android عبر Java، راجع [مرجع API com.aspose.slides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/).

{{% alert color="info" title="Inheritance" %}}

عند تعريف الخاصية نفسها على أكثر من مستوى، يفوز المستوى الأكثر تحديدًا. على سبيل المثال، إذا عرّف كل من slide master وlayout slide خلفية، فإن الشرائح القائمة على ذلك التخطيط تستخدم خلفية التخطيط. لمزيد من المعلومات حول شرائح التخطيط، راجع [Apply or Change Slide Layouts](/slides/ar/androidjava/slide-layout/).

{{% /alert %}}

## **الوصول إلى Slide Masters**

في PowerPoint، يمكنك فتح عرض Slide Master من **View** > **Slide Master**.

![أمر Slide Master في تبويب View في PowerPoint](slide-master_3.jpg)

في Aspose.Slides، استخدم مجموعة `getMasters()` للوصول إلى الشرائح الرئيسة:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
    int masterSlideCount = presentation.getMasters().size();
    int firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    System.out.println("Master slides: " + masterSlideCount);
    System.out.println("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

يمكنك أيضًا الحصول على شريحة الرئيس المستخدمة من قبل شريحة عادية عبر تخطيطها:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = slide.getLayoutSlide();
    IMasterSlide masterSlide = layoutSlide.getMasterSlide();
    String masterSlideName = masterSlide.getName();

    System.out.println(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **ما يحتويه Slide Master**

شريحة الرئيس هي كائن شبيه بالشريحة. فهي تُنفّذ [IBaseSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseslide/)، لذا تُظهر العديد من خصائص الشريحة نفسها المستخدمة في الشرائح العادية وشرائح التخطيط.

تشمل الأعضاء الشائعة المستخدمة في شريحة الرئيس ما يلي:

| العضو | الغرض |
| --- | --- |
| `getBackground()` | يضبط خلفية الشريحة على مستوى الرئيس. |
| `getShapes()` | يخزن الأشكال الموجودة على الرئيس، مثل الشعارات، وإطارات الصور، والنص المشترك. |
| `getLayoutSlides()` | يخزن شرائح التخطيط التي تنتمي إلى الرئيس. |
| `getThemeManager()` | يُوفر الوصول إلى واجهات برمجة تطبيقات سمة الرئيس. |
| `getHeaderFooterManager()` | يتحكم في رؤوس وتذييلات وتواريخ وأرقام الشرائح للـ master وتخطيطاتها الفرعية. |
| `getDependingSlides()` | يُعيد الشرائح العادية التي تعتمد على الرئيس عبر تخطيطاتها. |

## **إضافة صورة إلى Slide Master**

عند إضافة صورة إلى شريحة رئيسية، تظهر على الشرائح التي تستخدم تخطيطات من هذا الرئيس. وهذا مفيد للشعارات، العلامات المائية، الشرائط الزخرفية، والعناصر البصرية المتكررة الأخرى.

المثال التالي يضيف شعارًا إلى الشريحة الرئيسة الأولى:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IImage logo = Images.fromFile("logo.png");

    try {
        IPPImage logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                20,
                20,
                80,
                80,
                logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

لمزيد من المعلومات حول إطارات الصور، راجع [Picture Frame](/slides/ar/androidjava/picture-frame/).

## **العمل مع العناصر النائبة (Placeholders)**

عادةً ما تُعرّف العناصر النائبة في شرائح التخطيط. توفر شريحة الرئيس النمط والسمة المشتركة التي يرثها تلك التخطيطات، بينما يقرر كل تخطيط أي العناصر النائبة متاحة وأين توضع.

في PowerPoint، تتوفر أوامر العناصر النائبة في عرض Slide Master.

![أمر Insert Placeholder في عرض Slide Master في PowerPoint](slide-master_5.png)

لإضافة عناصر نائبة جديدة باستخدام Aspose.Slides، اعمل مع شريحة التخطيط التي تنتمي إلى الرئيس:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide blankLayoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayoutSlide == null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يمكنك أيضًا تنسيق أشكال العناصر النائبة التي توجد بالفعل على شريحة الرئيس. المثال التالي يجد العنصر النائب للعنوان ويطبق تعبئة تدرجية خطية:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IAutoShape titlePlaceholder = null;

    for (IShape shape : masterSlide.getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;

            if (autoShape.getPlaceholder() != null &&
                    autoShape.getPlaceholder().getType() == PlaceholderType.Title) {
                titlePlaceholder = autoShape;
                break;
            }
        }
    }

    if (titlePlaceholder != null) {
        int redGradientColor = Color.valueOf(255, 0, 0).toArgb();
        int purpleGradientColor = Color.valueOf(128, 0, 128).toArgb();

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![العنوان المُنسق الموروث من شريحة الرئيس إلى الشرائح العادية](slide-master_8.png)

لمزيد من خيارات تنسيق العناصر النائبة والنص، راجع [Set Prompt Text in Placeholder](/slides/ar/androidjava/manage-placeholder/) و[Text Formatting](/slides/ar/androidjava/text-formatting/).

## **تغيير خلفية Slide Master**

الخلفية الرئيسة تُورّث إلى التخطيطات والشرائح التي لا تُعيد تعريفها. المثال التالي يضبط لون خلفية صلبة للشريحة الرئيسة الأولى:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    int masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

للمواضيع ذات الصلة، راجع [Presentation Background](/slides/ar/androidjava/presentation-background/) و[Presentation Theme](/slides/ar/androidjava/presentation-theme/).

## **استنساخ Slide Master إلى عرض تقديمي آخر**

استخدم [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) لنسخ شريحة الرئيس إلى عرض تقديمي آخر. يمكن بعد ذلك استخدام الرئيس المستنسخ في التخطيطات والشرائح بالعرض الهدف.

```java
Presentation sourcePresentation = new Presentation("source.pptx");
Presentation destinationPresentation = new Presentation("destination.pptx");
try {
    IMasterSlide sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    IMasterSlide clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

إذا كنت بحاجة إلى استنساخ الشرائح العادية مع الرئيس الخاص بها، راجع [Clone Slides](/slides/ar/androidjava/clone-slides/).

## **إضافة عدة Slide Masters**

يمكن للعرض التقديمي أن يحتوي على عدة شرائح رئيسية. هذا مفيد عندما تتطلب الأقسام المختلفة هوية بصرية، أو هيكل صفحات، أو إعدادات سمة مختلفة.

![أوامر PowerPoint لإدراج وإدارة شرائح الرئيس](slide-master_9.jpg)

المثال التالي يستنسخ الرئيس الافتراضي، يمنح النسخة خلفية مختلفة، ينشئ تخطيطًا تحت هذا الرئيس المستنسخ، ويضيف شريحة جديدة تعتمد على ذلك التخطيط:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    int sectionMasterBackgroundColor = Color.GRAY;

    sectionMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    ILayoutSlide sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    if (sourceBlankLayout == null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    ILayoutSlide sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **مقارنة Slide Masters**

يمكن مقارنة شرائح الرئيس باستخدام طريقة `equals` الموروثة من [IBaseSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseslide/). تتحقق المقارنة من الهيكل والمحتوى الثابت، مثل الأشكال، والنص، والتنسيق، والرسوم المتحركة، وإعدادات الشريحة الأخرى. لا تُقارن المعرفات الفريدة مثل معرفات الشرائح، ولا قيم العناصر النائبة الديناميكية مثل التاريخ الحالي.

```java
Presentation firstPresentation = new Presentation("first.pptx");
Presentation secondPresentation = new Presentation("second.pptx");
try {
    int firstPresentationMasterCount = firstPresentation.getMasters().size();
    int secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (int firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (int secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            IMasterSlide firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            IMasterSlide secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            boolean areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                System.out.printf(
                        "first.pptx master #%d equals second.pptx master #%d%n",
                        firstMasterIndex,
                        secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

لمزيد من المعلومات، راجع [Compare Presentation Slides](/slides/ar/androidjava/compare-slides/).

## **ضبط عرض Slide Master كعرض افتراضي**

استخدم طريقة `setLastView` على [ViewProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/viewproperties/) للتحكم في العرض الذي يفتحه PowerPoint أولاً. المثال التالي يفتح العرض التقديمي في عرض Slide Master:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

لمزيد من إعدادات العرض، راجع [Save Presentation](/slides/ar/androidjava/save-presentation/).

## **إزالة شرائح الرئيس غير المستخدمة**

أحيانًا يحتوي العرض التقديمي على شرائح رئيسة لم تعد تُستخدم من قبل أي شريحة عادية. إزالة الشرائح الرئيسة غير المستخدمة يمكن أن يقلل حجم الملف ويسهّل صيانة القوالب.

استخدم `removeUnused` لإزالة الشرائح الرئيسة غير المستخدمة من مجموعة `getMasters()`:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يمكنك أيضًا استخدام طريقة منخفضة الكود [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) :

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة المتداولة**

**ما الفرق بين slide master وlayout slide؟**

Slide master يحدد إعدادات التصميم المشتركة مثل السمة، الخلفية، الأشكال المشتركة، وأنماط النص. Layout slide ينتمي إلى slide master ويُعرّف ترتيبًا محددًا للعناصر النائبة. الشريحة العادية تستخدم layout slide، thus تُورّث من كل من التخطيط والرئيس.

**هل يمكن للعرض التقديمي أن يحتوي على عدة slide masters؟**

نعم. يمكن للعرض التقديمي أن يحتوي على عدة slide masters. استخدم عدة رؤساء عندما تحتاج الأقسام المختلفة إلى أنظمة بصرية أو هوية علامة تجارية مختلفة.

**هل يجب إضافة العناصر النائبة إلى slide master أم إلى layout slide؟**

في معظم الحالات، أضف العناصر النائبة إلى layout slides. ضع العناصر البصرية المشتركة والتنسيق المشترك على slide master، ثم ضع عناصر النائب للمحتوى على التخطيطات التي ستستخدمها الشرائح العادية.

**هل يمكن حذف شريحة رئيسة لا تزال قيد الاستخدام؟**

لا. لا يمكن حذف شريحة رئيسة لها شرائح معتمدة بأمان مباشرة. انقل تلك الشرائح أولاً إلى تخطيطات تحت رئيس آخر، أو استخدم طريقة تنظيف الرؤساء غير المستخدمة التي تُزيل فقط الرؤساء غير المستعملة.