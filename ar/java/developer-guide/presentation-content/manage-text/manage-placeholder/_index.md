---
title: إدارة عناصر نائب العرض التقديمي في Java
linktitle: إدارة العناصر النائبة
type: docs
weight: 10
url: /ar/java/manage-placeholder/
keywords:
- عنصر نائب
- عنصر نائب نص
- عنصر نائب صورة
- عنصر نائب مخطط
- عنصر نائب محتوى
- نص المطالبة
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعرف على كيفية فحص وتحرير عناصر نائب النص والصورة والمخطط والمحتوى وفهم وراثة العناصر النائبة باستخدام Aspose.Slides للغة Java."
---
## **نظرة عامة**

العنصر النائب هو شكل يحجز موضعًا لنوع معين من المحتوى في قالب عرض تقديمي. الأمثلة الشائعة تشمل العنوان، النص الأساسي، الصورة، المخطط، وعناصر نائب المحتوى العامة. على عكس الشكل العادي، يمكن للعناصر النائبة أن ترث موضعها وحجمها وتنسيقها وإعدادات أخرى من شريحة تخطيط أو شريحة رئيسية.

تُظهر Aspose.Slides معلومات العنصر النائب عبر طريقة [IShape.getPlaceholder](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/). تُعيد هذه الطريقة كائنًا من نوع [IPlaceholder](https://reference.aspose.com/slides/ar/java/com.aspose.slides/placeholder/) أو `null` لشكل عادي. استخدم [IPlaceholder.getType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/placeholder/) لتحديد ما يُقصد من العنصر النائب احتوائه.

ما زال واجهة الشكل مهمة بعد معرفة نوع العنصر النائب:

- عادةً ما يُمثَّل العنصر النائب الفارغ للنص أو الصورة أو المخطط أو المحتوى بواسطة [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/).
- يمكن تمثيل العنصر النائب للصورة المُعبَّأة بواسطة [IPictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframe/).
- يمكن تمثيل العنصر النائب للمخطط المُعبَّأ بواسطة [IChart](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichart/).
- يمكن أن يحتوي العنصر النائب للمحتوى على عدة أنواع من المحتوى. تحقق من كل من [IPlaceholder.getType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/placeholder/) وواجهة الشكل في وقت التشغيل بدلاً من افتراض أن كل عنصر نائب هو [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/placeholder/) يصف دور العنصر النائب؛ لا يضمن نوع الشكل في وقت التشغيل. استخدم دائمًا فحص النوع قبل الوصول إلى النص أو الصورة أو المخطط أو الجدول أو الأعضاء الخاصة بالوسائط.
{{% /alert %}}

## **فهم وراثة العنصر النائب**

العناصر النائبة تشكل هيكلًا هرميًا:

1. تحدد الشريحة الرئيسية الأنماط القابلة لإعادة الاستخدام، وفي بعض الحالات، العناصر النائبة على مستوى الشريحة الرئيسية.
2. تحدد شريحة التخطيط التوزيع المستخدم من قِبل شريحة واحدة أو أكثر عادية ويمكنها الوراثة من الشريحة الرئيسية.
3. تحتوي الشريحة العادية على العناصر النائبة لتلك الشريحة ويمكنها الوراثة من تخطيطها.

استدعِ [IShape.getBasePlaceholder](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/) للانتقال مستوى واحد أعلى في هذا الهيكل. عادةً ما يُعيد العنصر النائب للشريحة العنصر النائب لتخطيطها؛ ويمكن للعنصر النائب للتخطيط إرجاع العنصر النائب الرئيسي. تُعيد الطريقة `null` عندما لا يكون للشكل عنصر نائب أساسي.

تُظهر المثال التالي العناصر النائبة في الشريحة الأولى وتُبلغ عن عناصرها النائبة الأساسـية:

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

تحرير عنصر نائب في شريحة عادية يخلق أو يغيّر تجاوزًا محليًا لتلك الشريحة. تحرير التخطيط أو الشريحة الرئيسية المرتبط يمكن أن يؤثر على جميع الشرائح التي لا تزال وراثة هذا الإعداد. لا يمتلك الشكل العادي المحلي عنصرًا نائبًا أساسيًا ولا يبدأ في الوراثة لمجرد أنه يشغل نفس الإحداثيات.

## **تغيير النص في عنصر نائب**

عادةً ما تدعم عناصر نائب العنوان، العنوان المركز، العنوان الفرعي، النص الأساسي، والنص، النص. تحقق من وجود [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) قبل استخدام طريقة [getTextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/).

يقوم هذا المثال بتحديث أول عنصر نائب للعنوان في الشريحة الأولى ويحفظ النتيجة:

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

يتجنب هذا النمط تحويل عناصر النائب للصورة أو المخطط أو الجدول أو الوسائط إلى [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/). كما يحدد العنصر النائب حسب الغرض بدلاً من الاعتماد على فهرس شكل هش.

## **تعيين نص المطالبة في التخطيط**

نص المطالبة هو التعليمات المعروضة أثناء التصميم في عنصر نائب فارغ، مثل *انقر لإضافة عنوان*. قم بتعيين نص مطالبة مخصص على عنصر نائب التخطيط بدلاً من محاولة الوصول إليه عبر مجموعة الأشكال في شريحة عادية. احصل على التخطيط من خلال [ISlide.getLayoutSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islide/) وتكرَّر عبر المجموعة التي تُرجعها [ILayoutSlide.getShapes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseslide/).

يُغيّر المثال التالي نص المطالبة للعنوان والعنوان الفرعي في التخطيط المستخدم من قبل الشريحة الأولى:

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

نص المطالبة ليس محتوى شريحة عادي. إنه مخصص للعناصر النائبة الفارغة في تطبيقات التحرير مثل PowerPoint. بمجرد أن يضيف المستخدم أو البرنامج محتوى حقيقي، لا يُظهر النص المطالبة بعد ذلك. تغيير المطالبة لا يستبدل النص الموجود على الشرائح التي تستخدم هذا التخطيط.

## **تحديث عنصر نائب الصورة**

هناك حالتان يجب التعامل معهما:

- إذا كان عنصر نائب الصورة مُعبَّأًا بالفعل ومُمثَّلًا بواسطة [IPictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframe/), استبدل الصورة عبر [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/) و[ISlidesPicture.setImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidespicture/).
- إذا كان لا يزال عنصرًا نائبًا فارغًا، أضف إطار صورة عند إحداثيات العنصر النائب باستخدام [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/) وقم بإزالة العنصر النائب الفارغ.

يدعم المثال التالي الحالتين ويحفظ العرض تقديميًا:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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

    Path imagePath = Paths.get("replacement.png");
    byte[] imageBytes = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageBytes);

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

الاستبدال الذي يُنشأ لعنصر نائب فارغ هو إطار صورة محلي، وليس عنصرًا نائبًا جديدًا، لأن [IShape.getPlaceholder](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/) لا يوفر مُعِد. يحتفظ بالموقع المحجوز لكنه لا يرث سلوك العنصر النائب بعد الآن. إذا كان الحفاظ على علاقة العنصر النائب ضروريًا، فقم بإعداد وتعبئة العنصر النائب في PowerPoint أولًا، ثم حدّث [IPictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframe/) الناتج باستخدام Aspose.Slides.

لشفافية الصورة والقص وغيرها من التأثيرات الخاصة بالصور، راجع [Manage Picture Frames](/slides/ar/java/picture-frame/). هذه العمليات تتعلق بإطار الصورة أو تعبئة الصورة، لا ببيانات العنصر النائب.

## **العمل مع عناصر نائب المخطط والمحتوى**

يمكن تمثيل عنصر نائب المخطط المُعبَّأ بواسطة [IChart](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichart/). يعثر هذا المثال على مثل هذا المخطط من خلال كل من نوع العنصر النائب والواجهة في وقت التشغيل، يغيّر عنوانه، ويحفظ الملف:

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

عادةً ما يكون للعنصر النائب للمحتوى العام النوع [PlaceholderType.Object](https://reference.aspose.com/slides/ar/java/com.aspose.slides/placeholdertype/). في PowerPoint يعمل كمُطلق للعديد من أنواع المحتوى، بما في ذلك المخططات، الجداول، المخططات البيانية، الصور، والوسائط. بعد تعبئته، افحص واجهة الشكل الفعلية لمعرفة ما يحتويه. يمكن للتخطيطات المتخصصة أيضًا أن تُظهر [PlaceholderType.Chart](https://reference.aspose.com/slides/ar/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/ar/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/ar/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/ar/java/com.aspose.slides/placeholdertype/), أو [PlaceholderType.Diagram](https://reference.aspose.com/slides/ar/java/com.aspose.slides/placeholdertype/).

لا تقوم Aspose.Slides بتحويل عنصر نائب فارغ من نوع [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) إلى [IChart](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichart/) بمجرد تغيير [IPlaceholder.getType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/placeholder/); لا يمكن تغيير النوع عبر الواجهة. لملء مخطط فارغ أو منطقة محتوى برمجيًا، أضف الكائن المطلوب عند إحداثيات العنصر النائب ثم احذف العنصر النائب الفارغ. يوضح المثال التالي ذلك لمخطط:

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

المخطط المضاف هو مخطط محلي عادي. يشغل مساحة العنصر النائب لكنه لا يرث من عنصر النائب في التخطيط. استخدم مقالات إدارة المخططات المخصصة [chart management articles](/slides/ar/java/powerpoint-charts/) عندما تحتاج إلى استبدال الفئات أو السلاسل أو بيانات ملف العمل.

## **مثال كامل: تحديث النص أو محتوى الصورة**

يفتح المثال الشامل التالي قالبًا، يبحث في الشريحة الأولى عن عنصر نائب للعنوان أو الصورة، يتحقق من أنواع العنصر النائب والشكل، يُحدّث المحتوى المناسب، ويحفظ النتيجة. يتجنب المثال عمدًا افتراض فهرس شكل أو تحويل كل عنصر نائب إلى نفس الواجهة.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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
            Path imagePath = Paths.get("replacement.png");
            byte[] imageBytes = Files.readAllBytes(imagePath);
            IPPImage image = presentation.getImages().addImage(imageBytes);

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

العنصر النائب الأساسي هو الشكل المقابل على التخطيط أو الشريحة الرئيسية التي يرث منها عنصر نائب آخر. استخدم [IShape.getBasePlaceholder](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/) لاسترجاعه. يُعيد الشكل المحلي العادي `null` لأنه ليس جزءًا من هيكل العنصر النائب.

**هل يمكنني تغيير جميع عناوين الشرائح عبر تحرير عنصر نائب التخطيط؟**

يمكنك تغيير التنسيق الوراثي أو نص المطالبة من خلال التخطيط، لكن محتوى العنوان الموجود مخزن على الشرائح العادية. لاستبدال نص العنوان الفعلي عبر العرض الكامل، قم بتكرار الشرائح وتحديث كل عنصر نائب للعنوان.

**كيف يمكنني إدارة عناصر نائب التاريخ ورقم الشريحة والرأس والتذييل؟**

استخدم مديري الرأس والتذييل في الشريحة أو التخطيط أو الشريحة الرئيسية أو الملاحظات أو النسخة الموزعة حسب الحاجة. راجع [Manage Presentation Header and Footer](/slides/ar/java/presentation-header-and-footer/) للحصول على أمثلة كاملة.