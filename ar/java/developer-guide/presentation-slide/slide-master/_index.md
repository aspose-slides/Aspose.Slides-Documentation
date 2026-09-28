---
title: إدارة شرائح ماستر العرض التقديمي في Java
linktitle: شريحة ماستر
type: docs
weight: 70
url: /ar/java/slide-master/
keywords:
- شريحة رئيسية
- شريحة ماستر
- شريحة ماستر PPT
- شرائح ماستر متعددة
- مقارنة شرائح الماستر
- خلفية
- عنصر نائب
- استنساخ شريحة ماستر
- نسخ شريحة ماستر
- تكرار شريحة ماستر
- شريحة ماستر غير مستخدمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "إدارة شرائح الماستر في Aspose.Slides لـ Java: الوصول، التحرير، الاستنساخ، المقارنة وإزالة شرائح الماستر في عروض PowerPoint وOpenDocument التقديمية."
---
## **نظرة عامة**

**slide master** يعرّف إعدادات التصميم المشتركة لمجموعة من الشرائح. يمكن أن يحتوي على أشكال مشتركة، شعارات، خلفيات، أنماط نص، إعدادات tema، وإعدادات تذييل. في PowerPoint، تعديل **slide master** هو الطريقة المعتادة للحفاظ على اتساق العرض التقديمي دون تكرار نفس التنسيق في كل شريحة.

Aspose.Slides for Java يدعم نفس النموذج. يمكن للعرض التقديمي أن يحتوي على شريحة رئيسية واحدة أو أكثر، ويمكن لكل شريحة رئيسية أن تحتوي على عدة شرائح تخطيط. الشرائح العادية عادة لا تُشير مباشرة إلى شريحة رئيسية. بدلاً من ذلك، تستخدم الشريحة العادية شريحة تخطيط، وتلك الشريحة التخطيطية تنتمي إلى شريحة رئيسية.

التسلسل الهرمي هو:

1. **Slide master** - يعرّف التصميم المشترك وال tema.
1. **Layout slide** - يعرّف ترتيبًا محددًا لعناصر العنصر النائب وتنسيق مستوى التخطيط.
1. **Normal slide** - يحتوي على محتوى العرض الفعلي ويستخدم شريحة تخطيط واحدة.

![تسلسل شريحة الرئيسة، شرائح التخطيط، والشرائح العادية](slide-master_2.jpg)

في Aspose.Slides، يُمثَّل **slide master** بواجهة [IMasterSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslide/). جميع الشرائح الرئيسية في العرض التقديمي متاحة من خلال مجموعة [Presentation.getMasters](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getMasters--)، والتي تنفّذ [IMasterSlideCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
عند تعريف الخاصية نفسها في أكثر من مستوى، يفوز المستوى الأكثر تحديدًا. على سبيل المثال، إذا عرّفت شريحة رئيسية وشريحة تخطيط خلفية، فإن الشرائح المستندة إلى ذلك التخطيط تستخدم خلفية التخطيط. لمزيد من المعلومات حول شرائح التخطيط، راجع [Apply or Change Slide Layouts](/slides/ar/java/slide-layout/).
{{% /alert %}}

## **الوصول إلى Slide Masters**

في PowerPoint، يمكنك فتح عرض **Slide Master** من **View** > **Slide Master**.

![أمر Slide Master في علامة تبويب View ببرنامج PowerPoint](slide-master_3.jpg)

في Aspose.Slides، استخدم مجموعة `getMasters()` للوصول إلى الشرائح الرئيسية:

```java
import com.aspose.slides.*;

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

يمكنك أيضًا الحصول على الشريحة الرئيسية التي تستخدمها شريحة عادية عبر تخطيطها:

```java
import com.aspose.slides.*;

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

## **ما الذي يحتويه Slide Master**

الشريحة الرئيسية هي كائن شبيه بالشفرة. فهي تنفّذ [IBaseSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseslide/)، لذا فإنها تعرض العديد من خصائص الشريحة نفسها التي تُستخدم في الشرائح العادية وتخطيطاتها. الأعضاء الخاصة بالماستر مُدرجة في صفحة API الخاصة بـ [IMasterSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslide/).

الأعضاء الشائعة الاستخدام في شريحة الماستر تشمل:

| العضو | الغرض |
| --- | --- |
| `getBackground()` | يحدد خلفية الشريحة على مستوى الماستر. |
| `getShapes()` | يخزن الأشكال الموجودة على الماستر، مثل الشعارات، إطارات الصور، والنص المشترك. |
| `getLayoutSlides()` | يخزن شرائح التخطيط التي تنتمي إلى الماستر. |
| `getThemeManager()` | يوفر الوصول إلى API tema الخاصة بالماستر. |
| `getHeaderFooterManager()` | يتحكم في رؤوس وتذييلات وتواريخ وأرقام الشرائح للماستر وتخطيطاته الفرعية. |
| `getDependingSlides()` | يُرجِع الشرائح العادية التي تعتمد على الماستر عبر تخطيطاتها. |

## **إضافة صورة إلى Slide Master**

عند إضافة صورة إلى شريحة ماستر، تظهر في الشرائح التي تستخدم تخطيطات من ذلك الماستر. هذا مفيد للشعارات، العلامات المائية، الشرائط الزخرفية، وغيرها من العناصر البصرية المتكررة.

المثال التالي يضيف شعارًا إلى أول شريحة ماستر:

```java
import com.aspose.slides.*;

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

لمزيد من المعلومات حول إطارات الصور، راجع [Picture Frame](/slides/ar/java/picture-frame/).

## **التحكم في رؤية رسومات الماستر**

استخدم [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) لإخفاء الرسومات الموروثة من الماستر، مثل الشعارات أو الأشكال الزخرفية، دون حذفها من الماستر. مرّر `false` إلى [Slide.setShowMasterShapes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slide/#setShowMasterShapes-boolean-) على الشريحة التي يجب أن تُستثنى تلك الرسومات واتركه `true` على الشرائح التي يجب أن تعرضها.

المثال التالي يُنشئ شريطًا زخرفيًا أزرق على ماستر وشريحتين تستخدمان نفس التخطيط الفارغ. الشريط مرئي على الشريحة الأولى ومخفي على الشريحة الثانية. لا يتطلب أي عرض تقديمي أو صورة كدخل.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    Color bandColor = new Color(70, 130, 180);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ISlide visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    ISlide hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يستخدم المثال تخطيط **Blank** المقدم مع عرض تقديمي جديد ويزيل العناصر النائبة الخاصة بالشريحة الأولية.

### **اختر نطاق الإعداد**

تستخدم الشريحة العادية ماسترها عبر [ISlide.getLayoutSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islide/#getLayoutSlide--) و [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutslide/#getMasterSlide--). ضبط الخاصية على شريحة فردية يؤثر فقط على تلك الشريحة. تمرير `false` إلى [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) يخفي رسومات الماستر للشرائح التي تستخدم ذلك التخطيط المشترك، حتى وإن كان إعدادها الخاص `true`. لإخفاء الرسومات على شريحة واحدة فقط، غير خاصية الشريحة واترك التخطيط المشترك دون تغيير.

الإعداد غير مدعم كعنصر تحكم في الرؤية على الشريحة الرئيسية نفسها. على الماستر، [getShowMasterShapes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/masterslide/#getShowMasterShapes--) يُرجِع دائمًا `false`، وتمرير `true` إلى [setShowMasterShapes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) يسبب استثناءً. طبّقها على شريحة عادية أو تخطيط بدلاً من ذلك.

### **تمييز الرسومات عن الخلفية**

| العملية | النتيجة |
| --- | --- |
| إخفاء رسومات الماستر | يتحكم في رؤية الأشكال الموروثة من الماستر دون حذفها أو تغيير أشكال الشريحة نفسها. |
| تغيير تعبئة خلفية الشريحة | يغيّر لون الخلفية أو التدرج أو الصورة. رسومات الماستر هي أشكال منفصلة ويمكن أن تبقى مرئية فوق تلك الخلفية. راجع [Presentation Background](/slides/ar/java/presentation-background/). |
| حذف شكل من الماستر | يزيل الشكل المصدر المشترك، وبالتالي لا يصبح متاحًا لأي شريحة تستخدم ذلك الماستر. |

## **العمل مع العناصر النائبة (Placeholders)**

عادةً ما تُعرّف العناصر النائبة على شرائح التخطيط. تقدم الشريحة الرئيسية النمط المشترك والtema التي يرثها تلك التخطيطات، بينما يقرر كل تخطيط أي عناصر نائبة متاحة وأين توضع.

في PowerPoint، تتوفر أوامر العناصر النائبة في عرض **Slide Master**.

![أمر Insert Placeholder في عرض Slide Master ببرنامج PowerPoint](slide-master_5.png)

لإضافة عناصر نائبة جديدة باستخدام Aspose.Slides، عمل مع شريحة التخطيط التي تنتمي إلى الماستر:

```java
import com.aspose.slides.*;

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

يمكنك أيضًا تنسيق أشكال العناصر النائبة الموجودة بالفعل على شريحة ماستر. المثال التالي يجد عنصر العنصر النائب للعنوان ويطبّق تعبئة تدرج خطي:

```java
import com.aspose.slides.*;
import java.awt.Color;

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
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![عنصر عنوان مُنسق يُرث من الشرائح العادية](slide-master_8.png)

لمزيد من خيارات تنسيق العناصر النائبة والنص، راجع [Set Prompt Text in Placeholder](/slides/ar/java/manage-placeholder/) و[Text Formatting](/slides/ar/java/text-formatting/).

## **تغيير خلفية Slide Master**

خلفية الماستر تُورّث إلى التخطيطات والشرائح التي لا تُعيد تعريفها. المثال التالي يحدد لون خلفية ثابت للماستر الأول:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

للمواضيع ذات الصلة، راجع [Presentation Background](/slides/ar/java/presentation-background/) و[Presentation Theme](/slides/ar/java/presentation-theme/).

## **استنساخ Slide Master إلى عرض تقديمي آخر**

استخدم [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) لنسخ شريحة ماستر إلى عرض تقديمي آخر. يمكن بعد ذلك استخدام الماستر المنسوخ عبر التخطيطات والشرائح في العرض الوجهة.

```java
import com.aspose.slides.*;

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

إذا كنت بحاجة إلى استنساخ الشرائح العادية مع الماستر الخاص بها، راجع [Clone Slides](/slides/ar/java/clone-slides/).

## **إضافة عدة Slide Masters**

يمكن للعرض التقديمي أن يحتوي على عدة شرائح رئيسية. هذا مفيد عندما تتطلب الأقسام المختلفة علامات تجارية، هيكل صفحات أو إعدادات tema مختلفة.

![أوامر PowerPoint لإدراج وإدارة شرائح الماستر](slide-master_9.jpg)

المثال التالي يستنسخ الماستر الافتراضي، يعطي النسخة المستنسخة خلفية مختلفة، يُنشئ تخطيطًا تحت ذلك الماستر المستنسخ، ويضيف شريحة جديدة تعتمد على ذلك التخطيط:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **مقارنة Slide Masters**

يمكن مقارنة الشرائح الرئيسية باستخدام طريقة `equals` الموروثة من [IBaseSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseslide/). المقارنة تتحقق من البنية والمحتوى الثابت، مثل الأشكال، النص، التنسيق، الرسوم المتحركة، وإعدادات الشريحة الأخرى. لا تُقارن المعرفات الفريدة مثل معرفات الشرائح، أو قيم العناصر النائبة الديناميكية مثل التاريخ الحالي.

```java
import com.aspose.slides.*;

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

لمزيد من المعلومات، راجع [Compare Presentation Slides](/slides/ar/java/compare-slides/).

## **تعيين عرض Slide Master كعرض افتراضي**

استخدم طريقة `setLastView` على [ViewProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/viewproperties/) للتحكم في العرض الذي يفتحه PowerPoint أولاً. المثال التالي يفتح العرض في عرض Slide Master:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

لمزيد من إعدادات العرض، راجع [Save Presentation](/slides/ar/java/save-presentation/).

## **إزالة Slide Masters غير المستخدمة**

أحيانًا يحتوي العرض التقديمي على شرائح رئيسية لم يعد أي شريحة عادية تستخدمها. إزالة الماسترات غير المستخدمة يمكن أن يقلص حجم الملف ويسهّل صيانة القوالب.

استخدم `removeUnused` لإزالة الماسترات غير المستخدمة من مجموعة `getMasters()`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يمكنك أيضًا استخدام طريقة منخفضة الكود [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة الشائعة**

**ما الفرق بين slide master و layout slide؟**

slide master يعرّف إعدادات التصميم المشتركة مثل tema، الخلفية، الأشكال المشتركة، وأنماط النص. layout slide ينتمي إلى slide master ويعرّف ترتيبًا محددًا للعناصر النائبة. الشريحة العادية تستخدم layout slide، وبالتالي ترث من كلٍ من التخطيط والماستر.

**هل يمكن أن يحتوي عرض تقديمي واحد على عدة slide masters؟**

نعم. يمكن للعرض التقديمي أن يحتوي على عدة slide masters. استخدم عدة ماسترات عندما تحتاج أقسام مختلفة إلى أنظمة بصرية أو علامات تجارية مختلفة.

**هل يجب إضافة العناصر النائبة إلى slide master أم إلى layout slide؟**

في معظم الحالات، أضف العناصر النائبة إلى layout slides. ضع العناصر البصرية المشتركة والتنسيقات المشتركة على slide master، ثم ضع عناصر العنصر النائب للمحتوى على التخطيطات التي ستستخدمها الشرائح العادية.

**هل يمكن حذف slide master لا يزال مستخدمًا؟**

لا. لا يمكن حذف شريحة ماستر لها شرائح تبعية بأمان مباشرة. انقل تلك الشرائح أولًا إلى تخطيطات تحت ماستر آخر، أو استخدم طريقة تنظيف الماسترات غير المستخدمة التي تزيل فقط الماسترات التي لا تُستَخدم.