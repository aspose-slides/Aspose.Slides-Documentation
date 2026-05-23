---
title: إدارة شرائح ماستر العرض في Java
linktitle: شريحة ماستر
type: docs
weight: 70
url: /ar/java/slide-master/
keywords:
- شريحة ماستر
- شريحة رئيسية
- شريحة ماستر PPT
- شرائح ماستر متعددة
- مقارنة شرائح ماستر
- خلفية
- ملف نائب
- استنساخ شريحة ماستر
- نسخ شريحة ماستر
- تكرار شريحة ماستر
- شريحة ماستر غير مستخدمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "إدارة شرائح ماستر في Aspose.Slides for Java: الوصول، التعديل، الاستنساخ، المقارنة، وإزالة شرائح ماستر في عروض PowerPoint و OpenDocument."
---
## **نظرة عامة**

**الشريحة الرئيسية** تُعرّف إعدادات التصميم المشتركة لمجموعة من الشرائح. يمكن أن تحتوي على أشكال مشتركة، شعارات، خلفيات، أنماط نص، إعدادات السمة، وإعدادات التذييل. في PowerPoint، تعديل الشريحة الرئيسية هو الطريقة المعتادة للحفاظ على تناسق العرض دون تكرار نفس التنسيق في كل شريحة.

Aspose.Slides for Java يدعم النموذج نفسه. يمكن للعرض أن يحتوي على شريحة رئيسية أو أكثر، ويمكن لكل شريحة رئيسية أن تحتوي على عدة شرائح تخطيط. عادةً لا تشير الشرائح العادية إلى شريحة رئيسية مباشرةً. بدلاً من ذلك، تستخدم الشريحة العادية شريحة تخطيط، وتلك الشريحة التخطيطية تنتمي إلى شريحة رئيسية.

التسلسل الهرمي هو:

1. **الشريحة الرئيسية** - تُعرّف التصميم والسمة المشتركة.  
1. **شريحة التخطيط** - تُعرّف ترتيبًا محددًا للملفات النائبة وتنسيقًا على مستوى التخطيط.  
1. **الشريحة العادية** - تحتوي على محتوى العرض الفعلي وتستخدم شريحة تخطيط واحدة.

![تسلسل الشريحة الرئيسية، شرائح التخطيط، والشرائح العادية](slide-master_2.jpg)

في Aspose.Slides، تُمثل الشريحة الرئيسية الواجهة [IMasterSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslide/). جميع الشرائح الرئيسية في عرض ما يمكن الوصول إليها من خلال مجموعة [Presentation.getMasters](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getMasters--) التي تُنفّذ [IMasterSlideCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslidecollection/).

{{% alert color="info" title="الوراثة" %}}
عند تعريف الخاصية نفسها في أكثر من مستوى، يفوز المستوى الأكثر تحديدًا. على سبيل المثال، إذا عرّفت شريحة رئيسية وشريحة تخطيط خلفية، فإن الشرائح المعتمدة على ذلك التخطيط تستخدم خلفية التخطيط. لمزيد من المعلومات حول شرائح التخطيط، اطلع على [Apply or Change Slide Layouts](/slides/ar/java/slide-layout/).
{{% /alert %}}

## **الوصول إلى الشرائح الرئيسية**

في PowerPoint، يمكنك فتح نافذة عرض الشريحة الرئيسية من **View**>**Slide Master**.

![أمر شريحة رئيسية في علامة تبويب العرض في PowerPoint](slide-master_3.jpg)

في Aspose.Slides، استخدم مجموعة `getMasters()` للوصول إلى الشرائح الرئيسية:

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

يمكنك أيضًا الحصول على الشريحة الرئيسية التي يستخدمها شريحة عادية من خلال تخطيطها:

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

## **ما الذي تحتويه الشريحة الرئيسية**

الشريحة الرئيسية هي كائن شبيه بالشريحة. إنها تنفّذ [IBaseSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseslide/)، لذا تُظهر العديد من خصائص الشرائح نفسها المستخدمة في الشرائح العادية وشرائح التخطيط. تُدرج الأعضاء الخاصة بالشريحة الرئيسية في صفحة API [IMasterSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslide/).

الأعضاء الشائعة الاستخدام في الشريحة الرئيسية تشمل:

| العضو | الغرض |
| --- | --- |
| `getBackground()` | يحدد خلفية الشريحة على مستوى الشريحة الرئيسية. |
| `getShapes()` | يخزن الأشكال الموضوعة على الشريحة الرئيسية، مثل الشعارات، إطارات الصور، والنص المشترك. |
| `getLayoutSlides()` | يخزن شرائح التخطيط التي تنتمي إلى الشريحة الرئيسية. |
| `getThemeManager()` | يوفّر الوصول إلى واجهات برمجة تطبيقات سمة الشريحة الرئيسية. |
| `getHeaderFooterManager()` | يتحكم في رؤوس وتذييلات وتواريخ وأرقام الشرائح للشريحة الرئيسية وتخطيطاتها الفرعية. |
| `getDependingSlides()` | يُرجع الشرائح العادية التي تعتمد على الشريحة الرئيسية عبر تخطيطاتها. |

## **إضافة صورة إلى الشريحة الرئيسية**

عند إضافة صورة إلى شريحة رئيسية، تظهر في الشرائح التي تستخدم تخطيطات من تلك الشريحة. هذا مفيد للشعارات، العلامات المائية، الشرائط الزخرفية، والعناصر البصرية المتكررة الأخرى.

المثال التالي يضيف شعارًا إلى الشريحة الرئيسية الأولى:

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

لمزيد من المعلومات حول إطارات الصور، انظر [Picture Frame](/slides/ar/java/picture-frame/).

## **العمل مع الملفات النائبة**

عادةً ما تُعرّف الملفات النائبة على شرائح التخطيط. توفر الشريحة الرئيسية النمط والسمة المشتركة التي يرثها تلك التخطيطات، بينما تقرّر كل تخطيط أي الملفات النائبة متاحة وأين تُوضع.

في PowerPoint، تتوفر أوامر الملفات النائبة في عرض الشريحة الرئيسية.

![أمر إدراج ملف نائب في عرض الشريحة الرئيسية في PowerPoint](slide-master_5.png)

لإضافة ملفات نائبة جديدة باستخدام Aspose.Slides، اعمل مع شريحة التخطيط التي تنتمي إلى الشريحة الرئيسية:

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

يمكنك أيضًا تنسيق أشكال الملفات النائبة الموجودة بالفعل على شريحة رئيسية. المثال التالي يجد ملف العنوان النائب ويطبّق تعبئة تدرج خطي:

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
        Color redGradientColor = new Color(255, 0, 0);
        Color purpleGradientColor = new Color(128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![ملف عنوان مُنسق يورثه الشرائح العادية](slide-master_8.png)

لمزيد من خيارات تنسيق الملفات النائبة والنص، اطلع على [Set Prompt Text in Placeholder](/slides/ar/java/manage-placeholder/) و[Text Formatting](/slides/ar/java/text-formatting/).

## **تغيير خلفية الشريحة الرئيسية**

الخلفية الرئيسية تُورّث من قبل التخطيطات والشرائح التي لا تتجاوزها. المثال التالي يحدّد لون خلفية صلب للشريحة الرئيسية الأولى:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    Color masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

للموضوعات ذات الصلة، انظر [Presentation Background](/slides/ar/java/presentation-background/) و[Presentation Theme](/slides/ar/java/presentation-theme/).

## **استنساخ شريحة رئيسية إلى عرض آخر**

استخدم [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) لنسخ شريحة رئيسية إلى عرض آخر. يمكن بعد ذلك استخدام الشريحة المستنسخة من قبل التخطيطات والشرائح في العرض الوجهة.

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

إذا كنت بحاجة إلى استنساخ الشرائح العادية مع شريطها الرئيسي، انظر [Clone Slides](/slides/ar/java/clone-slides/).

## **إضافة عدة شرائح رئيسية**

يمكن للعرض أن يحتوي على عدة شرائح رئيسية. هذا مفيد عندما تتطلب أقسام مختلفة علامات تجارية، بنية صفحات، أو إعدادات سمة مختلفة.

![أوامر PowerPoint لإدراج وإدارة الشرائح الرئيسية](slide-master_9.jpg)

المثال التالي يستنسخ الشريحة الرئيسية الافتراضية، يمنح النسخة المستنسخة خلفية مختلفة، يُنشئ تخطيطًا تحت تلك الشريحة المستنسخة، ويضيف شريحة جديدة تعتمد على ذلك التخطيط:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.LIGHT_GRAY;

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

## **مقارنة الشرائح الرئيسية**

يمكن مقارنة الشرائح الرئيسية باستخدام طريقة `equals` الموروثة من [IBaseSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseslide/). تتحقق المقارنة من الهيكل والمحتوى الثابت مثل الأشكال، النص، التنسيق، الحركات، وإعدادات الشريحة الأخرى. لا تُقارن المعرّفات الفريدة مثل معرفات الشرائح أو القيم الديناميكية للملفات النائبة مثل التاريخ الحالي.

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

لمزيد من المعلومات، انظر [Compare Presentation Slides](/slides/ar/java/compare-slides/).

## **تعيين عرض الشريحة الرئيسية كعرض افتراضي**

استخدم طريقة `setLastView` على [ViewProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/viewproperties/) للتحكم في العرض الذي يفتح PowerPoint أولاً. المثال التالي يفتح العرض في عرض الشريحة الرئيسية:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

لمزيد من إعدادات العرض، انظر [Save Presentation](/slides/ar/java/save-presentation/).

## **إزالة الشرائح الرئيسية غير المستخدمة**

أحيانًا تحتوي العروض على شرائح رئيسية لم تعد تُستَخدم من قبل أي شرائح عادية. يمكن أن يقلل إزالة الشرائح غير المستخدمة من حجم الملف ويسهّل صيانة القالب.

استخدم `removeUnused` لإزالة الشرائح الرئيسية غير المستخدمة من مجموعة `getMasters()`:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يمكنك أيضًا استخدام الطريقة منخفضة الكود [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) :

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة الشائعة**

**ما الفرق بين الشريحة الرئيسية وشريحة التخطيط؟**

الشريحة الرئيسية تُعرّف إعدادات التصميم المشتركة مثل السمة، الخلفية، الأشكال المشتركة، وأنماط النص. شريحة التخطيط تنتمي إلى شريحة رئيسية وتُعرّف ترتيبًا محددًا للملفات النائبة. الشريحة العادية تستخدم شريحة تخطيط، وبالتالي تُورّث من كل من التخطيط والشريحة الرئيسية.

**هل يمكن لعرض واحد أن يحتوي على عدة شرائح رئيسية؟**

نعم. يمكن للعرض أن يحتوي على عدة شرائح رئيسية. استخدم عدة شرائح عندما تحتاج أقسام مختلفة إلى أنظمة بصرية أو علامات تجارية مختلفة.

**هل يجب إضافة الملفات النائبة إلى الشريحة الرئيسية أم شريحة التخطيط؟**

في معظم الحالات، أضف الملفات النائبة إلى شرائح التخطيط. ضع العناصر البصرية المشتركة والتنسيقات المشتركة على الشريحة الرئيسية، ثم ضع ملفات المحتوى على التخطيطات التي ستستخدمها الشرائح العادية.

**هل يمكنني حذف شريحة رئيسية لا تزال قيد الاستخدام؟**

لا. لا يمكن حذف شريحة رئيسية لديها شرائح تابعة بأمان مباشرةً. انقل تلك الشرائح إلى تخطيطات تحت شريحة رئيسية أخرى، أو استخدم طريقة تنظيف الشرائح الرئيسية غير المستخدمة التي تُزيل فقط الشرائح غير المستخدمة.