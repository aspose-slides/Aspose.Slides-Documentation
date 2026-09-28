---
title: إدارة الشرائح الرئيسة للعرض التقديمي على Android
linktitle: الشريحة الرئيسة
type: docs
weight: 70
url: /ar/androidjava/slide-master/
keywords:
- شريحة رئيسية
- شريحة رئيسية
- شريحة رئيسية PPT
- شرائح رئيسية متعددة
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
- Android
- Java
- Aspose.Slides
description: "إدارة الشرائح الرئيسة في Aspose.Slides لأجهزة Android عبر Java: الوصول، التعديل، الاستنساخ، المقارنة، وإزالة الشرائح الرئيسة في عروض PowerPoint وOpenDocument التقديمية."
---
## **نظرة عامة**

يحدد **شريحة رئيسية** إعدادات التصميم المشتركة لمجموعة من الشرائح. يمكن أن تحتوي على أشكال مشتركة، وشعارات، وخلفيات، وأنماط نص، وإعدادات سمة، وإعدادات تذييل. في PowerPoint، تعديل الشريحة الرئيسية هو الطريقة المعتادة للحفاظ على تناسق العرض التقديمي دون تكرار نفس التنسيق على كل شريحة.

يدعم Aspose.Slides for Android via Java نفس النموذج. يمكن أن يحتوي العرض التقديمي على شريحة رئيسية واحدة أو أكثر، ويمكن لكل شريحة رئيسية أن تحتوي على عدة شرائح تخطيط. عادةً لا تشير الشرائح العادية إلى شريحة رئيسية مباشرة. بدلاً من ذلك، تستخدم الشريحة العادية شريحة تخطيط، وتكون شريحة التخطيط تابعة لشريحة رئيسية.

التسلسل الهرمي هو:

1. **الشريحة الرئيسية** - تحدد التصميم المشترك والسمة.
1. **شريحة التخطيط** - تحدد ترتيبًا محددًا للعنناصر النائبة وتنسيق المستوى التخطيطي.
1. **الشريحة العادية** - تحتوي على محتوى العرض الفعلي وتستخدم شريحة تخطيط واحدة.

![تسلسل هرمي للشرائح الرئيسية، شرائح التخطيط، والشرائح العادية](slide-master_2.jpg)

في Aspose.Slides، تمثل الشريحة الرئيسية الواجهة [IMasterSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterslide/). جميع الشرائح الرئيسية في عرض تقديمي متاحة من خلال مجموعة [Presentation.getMasters](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getMasters--)، التي تنفذ [IMasterSlideCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterslidecollection/). للحصول على السطح الكامل لواجهة برمجة تطبيقات Android via Java، راجع [مرجع API com.aspose.slides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/).

{{% alert color="info" title="Inheritance" %}}
عند تعريف الخاصية نفسها على أكثر من مستوى، يفوز المستوى الأكثر تحديدًا. على سبيل المثال، إذا عرّفت شريحة رئيسية وشريحة تخطيط خلفية، فإن الشرائح المستندة إلى هذا التخطيط تستخدم خلفية التخطيط. لمزيد من المعلومات حول شرائح التخطيط، راجع [تطبيق أو تغيير تخطيطات الشرائح](/slides/ar/androidjava/slide-layout/).
{{% /alert %}}

## **الوصول إلى الشرائح الرئيسية**

في PowerPoint، يمكنك فتح عرض شريحة رئيسية من **عرض** > **شريحة رئيسية**.

![أمر شريحة رئيسية في علامة تبويب عرض PowerPoint](slide-master_3.jpg)

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

يمكنك أيضًا الحصول على الشريحة الرئيسية المستخدمة بواسطة شريحة عادية من خلال التخطيط الخاص بها:

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

## **ما الذي تحتويه الشريحة الرئيسية**

الشريحة الرئيسية هي كائن شبيه بالشريحة. إنها تنفّذ [IBaseSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseslide/)، لذا فإنها تكشف عن العديد من خصائص الشريحة نفسها المستخدمة في الشرائح العادية وشرائح التخطيط.

الأعضاء الشائعون في شريحة رئيسية تشمل:

| العضو | الغرض |
| --- | --- |
| `getBackground()` | يحدد خلفية الشريحة على مستوى الرئيسة. |
| `getShapes()` | يخزن الأشكال الموضوعة على الرئيسة، مثل الشعارات، وإطارات الصور، والنص المشترك. |
| `getLayoutSlides()` | يخزن شرائح التخطيط التي تنتمي إلى الرئيسة. |
| `getThemeManager()` | يوفر وصولًا إلى واجهات برمجة تطبيقات سمة الرئيسة. |
| `getHeaderFooterManager()` | يتحكم في رؤوس وتذييلات وتواريخ وأرقام الشرائح للرئيسة وتخطيطاتها الفرعية. |
| `getDependingSlides()` | يرجع الشرائح العادية التي تعتمد على الرئيسة عبر تخطيطاتها. |

## **إضافة صورة إلى شريحة رئيسية**

عند إضافة صورة إلى شريحة رئيسية، تظهر على الشرائح التي تستخدم تخطيطات من تلك الرئيسة. هذا مفيد للشعارات، والعلامات المائية، والأشرطة الزخرفية، وغيرها من العناصر البصرية المتكررة.

المثال التالي يضيف شعارًا إلى الشريحة الرئيسية الأولى:

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

لمزيد من المعلومات حول إطارات الصور، راجع [إطار الصورة](/slides/ar/androidjava/picture-frame/).

## **التحكم في رؤية الرسومات الرئيسة**

استخدم [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) لإخفاء الرسومات الرئيسة الموروثة، مثل الشعارات أو الأشكال الزخرفية، دون حذفها من الرئيسة. مرّر `false` إلى [Slide.setShowMasterShapes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slide/#setShowMasterShapes-boolean-) على الشريحة التي يجب أن تحذف تلك الرسومات واحتفظ بـ `true` على الشرائح التي يجب أن تعرضها.

المثال التالي، المستقل تمامًا، ينشئ شريطًا أزرقًا زخرفيًا على الرئيسة وشريحتين تستخدمان نفس التخطيط الفارغ. الشريط مرئي على الشريحة الأولى ومخفي على الثانية. لا يلزم وجود عرض تقديمي أو صورة مدخلية.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    int bandColor = Color.rgb(70, 130, 180);
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

يستخدم المثال تخطيط **Blank** المرفق مع عرض تقديمي جديد ويزيل العناصر النائبة الخاصة بالشريحة الأولية.

### **اختر نطاق الإعداد**

تستخدم الشريحة العادية الرئيسة عبر [ISlide.getLayoutSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islide/#getLayoutSlide--) و[ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutslide/#getMasterSlide--). ضبط الخاصية على شريحة فردية يؤثر فقط على تلك الشريحة. تمرير `false` إلى [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) يخفي رسومات الرئيسة للشرائح التي تستخدم ذلك التخطيط المشترك، حتى وإن كان إعدادها الخاص `true`. لإخفاء الرسومات على شريحة واحدة فقط، غير خاصية الشريحة واترك التخطيط المشترك بدون تغيير.

الإعداد غير مدعوم كتحكم في الرؤية على شريحة الرئيسة نفسها. على الرئيسة، دائمًا ما يعيد [getShowMasterShapes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/masterslide/#getShowMasterShapes--) `false`، وتمرير `true` إلى [setShowMasterShapes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) يثير استثناءً. طبّقها على شريحة عادية أو تخطيط بدلاً من ذلك.

### **تمييز الرسومات عن الخلفية**

| العملية | التأثير |
| --- | --- |
| إخفاء رسومات الرئيسة | يتحكم في رؤية الأشكال الرئيسة الموروثة دون حذفها أو تعديل الأشكال الخاصة بالشريحة. |
| تغيير تعبئة خلفية الشريحة | يغيّر لون الخلفية أو التدرج أو الصورة. الرسومات الرئيسة هي أشكال منفصلة ويمكن أن تبقى مرئية فوق تلك الخلفية. راجع [خلفية العرض التقديمي](/slides/ar/androidjava/presentation-background/). |
| حذف شكل من الرئيسة | يزيل الشكل المصدر المشترك، بحيث لا يصبح متاحًا لأي شريحة تستخدم تلك الرئيسة. |

## **التعامل مع العناصر النائبة**

عادةً ما تُعرّف العناصر النائبة على شرائح التخطيط. توفر الشريحة الرئيسية النمط والسمة المشتركة التي يرثها تلك التخطيطات، بينما يقرر كل تخطيط أي عناصر نائبة تكون متاحة وأين توضع.

في PowerPoint، أوامر العناصر النائبة متوفرة في عرض شريحة رئيسية.

![أمر إدراج عنصر نائب في عرض شريحة رئيسية في PowerPoint](slide-master_5.png)

لإضافة عناصر نائبة جديدة باستخدام Aspose.Slides، اعمل مع شريحة التخطيط التي تنتمي إلى الرئيسة:

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

يمكنك أيضًا تنسيق أشكال العناصر النائبة الموجودة بالفعل على شريحة رئيسية. المثال التالي يُعثر على عنصر نائب العنوان ويطبّق تعبئة تدرج خطية:

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

![عنصر نائب عنوان مُنسق يورثه الشرائح العادية](slide-master_8.png)

لمزيد من خيارات تنسيق العناصر النائبة والنص، راجع [تعيين نص موجه في عنصر نائب](/slides/ar/androidjava/manage-placeholder/) و[تنسيق النص](/slides/ar/androidjava/text-formatting/).

## **تغيير خلفية الشريحة الرئيسية**

الخلفية الرئيسة تُورّث من قبل التخطيطات والشرائح التي لا تتجاوزها. المثال التالي يحدد لون خلفية صلب للشريحة الرئيسية الأولى:

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

للمواضيع ذات الصلة، راجع [خلفية العرض التقديمي](/slides/ar/androidjava/presentation-background/) و[سمة العرض التقديمي](/slides/ar/androidjava/presentation-theme/).

## **استنساخ شريحة رئيسية إلى عرض تقديمي آخر**

استخدم [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) لنسخ شريحة رئيسية إلى عرض تقديمي آخر. يمكن بعد ذلك استخدام الرئيسة المنسوخة بواسطة التخطيطات والشرائح في عرض الوجهة.

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

إذا كنت بحاجة إلى استنساخ الشرائح العادية مع رئيستها، راجع [استنساخ الشرائح](/slides/ar/androidjava/clone-slides/).

## **إضافة عدة شرائح رئيسية**

يمكن للعرض التقديمي أن يحتوي على عدة شرائح رئيسية. هذا مفيد عندما تتطلب الأقسام المختلفة علامات تجارية أو هياكل صفحات أو إعدادات سمة مختلفة.

![أوامر PowerPoint لإدراج وإدارة الشرائح الرئيسة](slide-master_9.jpg)

المثال التالي يستنسخ الرئيسة الافتراضية، يمنح النسخة المستنسخة خلفية مختلفة، ينشئ تخطيطًا تحت تلك الرئيسة المستنسخة، ويضيف شريحة جديدة بناءً على ذلك التخطيط:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.GRAY;

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

## **مقارنة الشرائح الرئيسة**

يمكن مقارنة الشرائح الرئيسة باستخدام طريقة `equals` الموروثة من [IBaseSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseslide/). تقوم المقارنة بفحص البنية والمحتوى الثابت، مثل الأشكال، والنص، والتنسيق، والرسوم المتحركة، وإعدادات الشريحة الأخرى. لا تقارن المعرفات الفريدة مثل معرفات الشرائح، أو قيم العناصر النائبة الديناميكية مثل التاريخ الحالي.

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

لمزيد من المعلومات، راجع [مقارنة شرائح العرض التقديمي](/slides/ar/androidjava/compare-slides/).

## **تعيين عرض شريحة رئيسية كعرض افتراضي**

استخدم طريقة `setLastView` على [ViewProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/viewproperties/) للتحكم في العرض الذي يفتحه PowerPoint أولًا. المثال التالي يفتح العرض التقديمي في عرض شريحة رئيسية:

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

لمزيد من إعدادات العرض، راجع [حفظ العرض التقديمي](/slides/ar/androidjava/save-presentation/).

## **إزالة الشرائح الرئيسة غير المستخدمة**

أحيانًا يحتوي العرض التقديمي على شرائح رئيسة لم تعد تستخدمها أي شرائح عادية. إزالة الرئيسات غير المستخدمة يمكن أن يقلل من حجم الملف ويبسط صيانة القالب.

استخدم `removeUnused` لإزالة الرئيسات غير المستخدمة من مجموعة `getMasters()`:

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

يمكنك أيضًا استخدام طريقة [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) منخفضة الشيفرة:

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

## **التعليمات المتكررة**

**ما الفرق بين الشريحة الرئيسة وشريحة التخطيط؟**

الشريحة الرئيسة تُعرّف إعدادات التصميم المشترك مثل السمة، والخلفية، والأشكال المشتركة، وأنماط النص. شريحة التخطيط تنتمي إلى شريحة رئيسة وتُعرّف ترتيبًا محددًا للعناصر النائبة. الشريحة العادية تستخدم شريحة تخطيط، لذا فإنها ترث من كل من التخطيط والرئيسة.

**هل يمكن أن يحتوي عرض تقديمي واحد على عدة شرائح رئيسة؟**

نعم. يمكن لعرض تقديمي أن يحتوي على عدة شرائح رئيسة. استخدم عدة رئيسات عندما تحتاج أقسام مختلفة إلى أنظمة بصرية أو علامات تجارية مختلفة.

**هل يجب إضافة العناصر النائبة إلى الشريحة الرئيسة أم شريحة التخطيط؟**

في معظم الحالات، أضف العناصر النائبة إلى شرائح التخطيط. ضع العناصر البصرية المشتركة والتنسيقات المشتركة على الشريحة الرئيسة، ثم ضع عناصر النائب للمحتوى على التخطيطات التي ستستخدمها الشرائح العادية.

**هل يمكنني حذف شريحة رئيسة ما زالت مستخدمة؟**

لا. لا يمكن حذف شريحة رئيسة لها شرائح معتمدة بأمان مباشرة. انقل تلك الشرائح أولًا إلى تخطيطات تحت رئيسة أخرى، أو استخدم طريقة تنظيف الرئيسات غير المستخدمة التي تزيل فقط الرئيسات التي لا تُستَخدم.