---
title: إدارة عناصر النائب في العرض التقديمي على Android
linktitle: إدارة العناصر النائبة
type: docs
weight: 10
url: /ar/androidjava/manage-placeholder/
keywords:
- عنصر نائب
- عنصر نائب نصي
- عنصر نائب صورة
- عنصر نائب مخطط
- عنصر نائب محتوى
- نص تلميح
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية فحص وتحرير العناصر النائبة للنص والصورة والمخطط والمحتوى وفهم وراثة العناصر النائبة باستخدام Aspose.Slides لنظام Android عبر Java."
---
## **نظرة عامة**

العنصر النائب هو شكل يحجز موضعًا لنوع معين من المحتوى في قالب عرض تقديمي. من الأمثلة الشائعة: العنوان، النص الأساسي، الصورة، المخطط، والعناصر النائبة العامة المحتوى. على عكس الشكل العادي، يمكن للعنصر النائب أن يرث موضعه وحجمه وتنسيقه وإعدادات أخرى من شريحة تخطيط أو شريحة رئيسية.

Aspose.Slides يكشف معلومات العنصر النائب عبر طريقة [IShape.getPlaceholder](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/). تُعيد الطريقة كائنًا من نوع [IPlaceholder](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/placeholder/) أو `null` لشكل عادي. استخدم طريقة [IPlaceholder.getType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/placeholder/) لتحديد ما يُقصد أن يحتويه العنصر النائب.

واجهة الشكل لا تزال مهمة بعد معرفة نوع العنصر النائب:

- عنصر نائب فارغ للنص أو الصورة أو المخطط أو المحتوى عادةً ما يُمثَّل بواسطة [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/).
- عنصر نائب صورة مُملوء يمكن تمثيله بواسطة [IPictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframe/).
- عنصر نائب مخطط مُملوء يمكن تمثيله بواسطة [IChart](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichart/).
- عنصر نائب محتوى يمكن أن يحتوي عدة أنواع من المحتوى. تحقق من كلٍ من [IPlaceholder.getType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/placeholder/) وواجهة الشكل في وقت التنفيذ بدلاً من افتراض أن كل عنصر نابٍ هو [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/placeholder/) يصف دور العنصر النائب؛ لكنه لا يضمن نوع الشكل في وقت التنفيذ. استخدم دائمًا فحص النوع قبل الوصول إلى النص أو الصورة أو المخطط أو الجدول أو الأعضاء الخاصة بالوسائط.
{{% /alert %}}

## **فهم وراثة العناصر النائبة**

تشكل العناصر النائبة هرمية:

1. تحدد الشريحة الرئيسية الأنماط القابلة لإعادة الاستخدام، وفي بعض الحالات، العناصر النائبة على مستوى الرئيسية.
2. تحدد شريحة التخطيط الترتيب المستخدم من قبل شريحة (شرائح) عادية واحدة أو أكثر ويمكن أن ترث من الرئيسية.
3. تحتوي الشريحة العادية على العناصر النائبة لتلك الشريحة ويمكن أن ترث من تخطيطها.

استدعِ طريقة [IShape.getBasePlaceholder](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/) للانتقال مستوىً واحدًا أعلى في هذه الهرمية. عادةً ما تُعيد عنصر نائب الشريحة عنصر نائب التخطيط؛ ويمكن أن يُعيد عنصر نائب التخطيط عنصر نائب الرئيسي. تُعيد الطريقة `null` عندما لا يحتوي الشكل على عنصر نائب أساسي.

المثال التالي يسرد العناصر النائبة في الشريحة الأولى ويظهر عناصرها النائبة الأساسية:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        String typeName = shape.getClass().getSimpleName();
        String slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape interface: " + typeName;
        System.out.println(slidePlaceholderMessage);

        IShape layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            IPlaceholder layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            Byte layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            String layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            System.out.println(layoutPlaceholderMessage);

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                IPlaceholder masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                Byte masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                String masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                System.out.println(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

تحرير عنصر نائب في شريحة عادية ينشئ أو يغيّر تجاوزًا محليًا لتلك الشريحة. تحرير التخطيط أو الرئيسي المرتبط يمكن أن يؤثر على جميع الشرائح التي لا تزال ترث هذا الإعداد. الشكل العادي المحلي ليس له عنصر نائب أساسي ولا يبدأ بالوراثة لمجرد أنه يشغل نفس الإحداثيات.

## **تغيير النص في العنصر النائب**

عناصر النائب للعنوان، العنوان المركزي، العنوان الفرعي، النص الأساسي، والنص عادةً ما تدعم النص. تحقق من وجود [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) قبل استخدام طريقة [getTextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/).

هذا المثال يُحدِّث أول عنصر نائب للعنوان في الشريحة الأولى ويحفظ النتيجة:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape titleShape = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            titleShape = autoShape;
            break;
        }
    }

    if (titleShape == null) {
        throw new IllegalStateException("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

هذا النمط يتجنب تحويل عناصر النائب للصور أو المخططات أو الجداول أو الوسائط إلى [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/). كما يُعرّف العنصر النائب حسب الغرض بدلاً من الاعتماد على فهرس الشكل الهش.

## **تعيين نص التلميح في التخطيط**

نص التلميح هو التعليمات التصميمية التي تُعرض في عنصر نائب فارغ، مثل *Click to add title*. اضبط نص التلميح المخصص على عنصر نائب التخطيط بدلاً من محاولة الوصول إليه عبر مجموعة أشكال الشريحة العادية. وصول إلى التخطيط يتم عبر [ISlide.getLayoutSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islide/) وتكرار المجموعة التي تُعيدها [ILayoutSlide.getShapes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseslide/).

المثال التالي يغيّر تلميحات العنوان والعنوان الفرعي في التخطيط المستخدم من قبل الشريحة الأولى:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getSlides().get_Item(0).getLayoutSlide();

    for (IShape shape : layoutSlide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            autoShape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType == PlaceholderType.Subtitle) {
            autoShape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نص التلميح ليس محتوى شريحة عادية. هو مخصص للعناصر النائبة الفارغة في تطبيقات التحرير مثل PowerPoint. بمجرد أن يضيف المستخدم أو البرنامج محتوى فعلي، لم يعد التلميح يُعرض. تغيير التلميح لا يستبدل النص الموجود على الشرائح التي تستخدم التخطيط.

## **تحديث العنصر النائب للصور**

هناك حالتان للتعامل معهما:

- إذا كان عنصر نائب الصورة مُملوءًا بالفعل ومُمَثَّلًا بـ [IPictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframe/)، استبدل الصورة عبر [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/) و[ISlidesPicture.setImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidespicture/).
- إذا كان لا يزال عنصر نائب فارغًا، أضف إطار صورة عند إحداثيات العنصر النائب باستخدام [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/) وأزل العنصر النائب الفارغ.

المثال التالي يدعم الحالتين ويحفظ العرض التقديمي:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("picture-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape picturePlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a picture placeholder.");
    }

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

    if (picturePlaceholder instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) picturePlaceholder;
        pictureFrame.getPictureFormat().getPicture().setImage(image);
    } else {
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, picturePlaceholder.getX(), picturePlaceholder.getY(), picturePlaceholder.getWidth(), picturePlaceholder.getHeight(), image);
        slide.getShapes().remove(picturePlaceholder);
    }

    presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

البديل المُنشأ لعنصر نائب فارغ هو إطار صورة محلي، وليس عنصرًا نائبًا جديدًا، لأن [IShape.getPlaceholder](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/) لا يُوفّر مُعيّنًا. يحتفظ بالموقع المحجوز لكنه لا يرث سلوك العنصر النائب بعد الآن. إذا كان الحفاظ على علاقة العنصر النائب أمرًا أساسيًا، حضِّر العنصر النائب في PowerPoint أولًا، ثم حدِّث الـ [IPictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframe/) الناتج باستخدام Aspose.Slides.

للشفافية، الاقتصاص، وتأثيرات الصورة الأخرى، راجع [Manage Picture Frames](/slides/ar/androidjava/picture-frame/). تلك العمليات تنتمي إلى إطار الصورة أو تعبئة الصورة، لا إلى بيانات العنصر النائب.

## **التعامل مع العناصر النائبة للمخططات والمحتوى**

عنصر نائب المخطط المُملوء يمكن تمثيله بـ [IChart](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichart/). هذا المثال يجد مثل هذا المخطط عبر كلٍ من نوع العنصر النائب والواجهة في وقت التنفيذ، يغيّر عنوانه، ويحفظ الملف:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart placeholderChart = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IPlaceholder placeholder = chart.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Chart) {
            placeholderChart = chart;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new IllegalStateException("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

العنصر النائب للمحتوى العام عادةً ما يكون من النوع [PlaceholderType.Object](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/placeholdertype/). في PowerPoint يعمل كمنطلق لعدة أنواع محتوى، بما في ذلك المخططات والجداول والرسوم التخطيطية والصور والوسائط. بعد ملئه، فحص واجهة الشكل الفعلية لتحديد ما يحتويه. التخطيطات المتخصصة يمكن أن تُظهر أيضًا [PlaceholderType.Chart](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/placeholdertype/)، [PlaceholderType.Table](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/placeholdertype/), أو [PlaceholderType.Diagram](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/placeholdertype/).

Aspose.Slides لا يُحوِّل عنصر نائب فارغ من نوع [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) إلى [IChart](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichart/) بمجرد تغيير [IPlaceholder.getType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/placeholder/); لا يمكن تغيير النوع عبر الواجهة. لملء مخطط أو منطقة محتوى فارغة برمجيًا، أضف الكائن المطلوب عند إحداثيات العنصر النائب ثم أزل العنصر النائب الفارغ. المثال التالي يوضح ذلك لمخطط:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("content-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape targetPlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Chart || placeholderType == PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a chart or content placeholder.");
    }

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, targetPlaceholder.getX(), targetPlaceholder.getY(), targetPlaceholder.getWidth(), targetPlaceholder.getHeight());
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    slide.getShapes().remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

المخطط المضاف هو مخطط محلي عادي. يشغل مساحة العنصر النائب لكنه لا يرث من عنصر نائب التخطيط. استخدم مقالات إدارة المخططات المخصصة [/slides/ar/androidjava/powerpoint-charts/] عند الحاجة إلى استبدال الفئات أو السلاسل أو بيانات المصنف.

## **مثال كامل: تحديث النص أو محتوى الصورة**

المثال الشامل التالي يفتح قالبًا، يبحث في الشريحة الأولى عن عنصر نائب للعنوان أو الصورة، يتحقق من نوع العنصر النائب والشكل، يُحدِّث المحتوى المناسب، ويحفظ الناتج. يتجنب المثال افتراض فهرس الشكل أو تحويل كل عنصر نائب إلى نفس الواجهة.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean updated = false;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape instanceof IAutoShape) {
            IAutoShape titleShape = (IAutoShape) shape;
            titleShape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType == PlaceholderType.Picture) {
            IPPImage image;
            try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
                image = presentation.getImages().addImage(imageStream);
            }

            if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                pictureFrame.getPictureFormat().getPicture().setImage(image);
            } else {
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image);
                slide.getShapes().remove(shape);
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new IllegalStateException("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة الشائعة**

**ما هو العنصر النائب الأساسي؟**

العنصر النائب الأساسي هو الشكل المقابل على التخطيط أو الرئيسي الذي يرث منه عنصر نائب آخر. استخدم طريقة [IShape.getBasePlaceholder](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/) لاسترجاعه. الشكل المحلي العادي يُعيد `null` لأنه ليس جزءًا من هرمية العناصر النائبة.

**هل يمكنني تغيير جميع عناوين الشرائح عن طريق تعديل عنصر نائب في التخطيط؟**

يمكنك تغيير التنسيق الموروث أو نص التلميح عبر التخطيط، لكن محتوى العنوان الفعلي يُخزن في الشرائح العادية. لاستبدال نص العنوان عبر العرض التقديمي بالكامل، قم بتكرار الشرائح وتحديث كل عنصر نائب للعنوان.

**كيف أدير عناصر نائب التاريخ، رقم الشريحة، الرأس، والتذييل؟**

استخدم مديري الرأس والتذييل في نطاق الشريحة، التخطيط، الرئيسي، الملاحظات، أو النشرات. راجع دليل [Manage Presentation Header and Footer](/slides/ar/androidjava/presentation-header-and-footer/) للحصول على أمثلة كاملة.