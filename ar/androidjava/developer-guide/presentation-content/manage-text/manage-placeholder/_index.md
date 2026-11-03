---
title: إدارة المحتوى النائب في العروض التقديمية على Android
linktitle: إدارة المحتويات النائبة
type: docs
weight: 10
url: /ar/androidjava/manage-placeholder/
keywords:
- محتوى نائب
- محتوى نائب نصي
- محتوى نائب صورة
- محتوى نائب مخطط
- محتوى نائب محتوى
- نص موجه
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية فحص وتعديل المحتويات النائبة النصية والصورية والمخططية ومحتوى النائب وفهم وراثة المحتويات النائبة باستخدام Aspose.Slides لـ Android عبر Java."
---
## **نظرة عامة**

المحتوى النائب هو شكل يحجز موضعًا لنوع معين من المحتوى في قالب عرض تقديمي. من الأمثلة الشائعة العناوين، النص الرئيسي، الصور، المخططات، ومحتويات النائب العامة. على عكس الشكل العادي، يمكن للمحتوى النائب أن يرث موقعه وحجمه وتنسيقه وإعداداته الأخرى من شريحة التخطيط أو الشريحة الرئيسية.

Aspose.Slides يعرض معلومات المحتوى النائب عبر طريقة [IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/). تُعيد الطريقة كائنًا من نوع [IPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) أو `null` لشكل عادي. استخدم [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) لتحديد ما يُقصد بالمحتوى النائب.

لا يزال واجهة الشكل ذات أهمية بعد معرفة نوع المحتوى النائب:

- عادةً ما يُمثَّل محتوى نصي، صورة، مخطط أو محتوى نائب فارغ بواسطة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).
- يمكن تمثيل محتوى صورة مملوء بواسطة [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/).
- يمكن تمثيل محتوى مخطط مملوء بواسطة [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/).
- يمكن أن يحتوي محتوى نائب على عدة أنواع من المحتوى. تحقق من كلٍ من [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) وواجهة الشكل في وقت التشغيل بدلاً من الافتراض بأن كل محتوى نائب هو [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) يصف دور المحتوى النائب؛ لكنه لا يضمن نوع الشكل في وقت التشغيل. استخدم دائمًا فحص النوع قبل الوصول إلى النص أو الصورة أو المخطط أو الجدول أو الأعضاء الخاصة بالوسائط.
{{% /alert %}}

## **فهم وراثة المحتوى النائب**

المحتويات النائبة تشكل تسلسلًا هرميًا:

1. تُعرِّف الشريحة الرئيسية الأنماط القابلة لإعادة الاستخدام، وفي بعض الحالات المحتويات النائبة على مستوى الرئيسي.
2. تُعرِّف شريحة التخطيط الترتيب المستخدم من قِبل شريحة أو أكثر عادية ويمكنها الوراثة من الرئيسي.
3. تحتوي الشريحة العادية على المحتويات النائبة لتلك الشريحة ويمكنها الوراثة من تخطيطها.

استدعِ [IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) للانتقال بمستوى واحد أعلى في هذا التسلسل. عادةً ما تُعيد شريحة محتوى نائب محتوى تخطيطها؛ ويمكن لمحتوى التخطيط إرجاع محتوى رئيسي. تُعيد الطريقة `null` عندما لا يكون للشكل محتوى نائب أساسي.

المثال التالي يُدرج المحتويات النائبة في الشريحة الأولى ويُبلغ عن محتوياتها الأساسية:

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

تحرير محتوى نائب في شريحة عادية يُنشئ أو يُغيّر تجاوزًا محليًا لتلك الشريحة. تحرير التخطيط أو الرئيسي المرتبط يمكن أن يؤثر على جميع الشرائح التي ما زالت ترث ذلك الإعداد. لا يحتوي الشكل العادي المحلي على محتوى نائب أساسي ولا يبدأ بالوراثة لمجرد احتلاله نفس الإحداثيات.

## **إزالة حالة المحتوى النائب**

عند تعديل قالب، استخدم [IShape.removePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#removePlaceholder--) لإبقاء كائن موجود كشكل عادي. تُعيد طريقة [getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getPlaceholder--) الخاصة به `null`، لكن الشكل يظل في مجموعة الشرائح. على النقيض، [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) يحذف الشكل من تلك المجموعة.

المثال التالي يتطلب ملف `template.pptx` يحتوي على شريحة واحدة على الأقل ومحتوى نائب نصي غير فارغ في الشريحة الأولى. استخدم محتوى نائب بتنسيق مُورّث من تخطيطه أو رئيسه لرؤية تأثير إزالة تلك العلاقة. يتحقق المثال من بقاء الشكل نفسه، ثم يستدعي الطريقة مرة أخرى على الشكل الآن العادي، ويحفظ النتيجة.

{{% alert color="warning" title="Warning" %}}
إزالة حالة المحتوى النائب لا تحافظ تلقائيًا على إعدادات المظهر الموروثة. المثال أدناه يترك تلك الإعدادات دون تغيير عمدًا، لذا قد يختلف المخرج. الشكل الذي يتم وراثة موقعه وحجمه بالكامل قد يصبح إحداثياته وأبعاده صفرًا بعد الاستدعاء ويصبح غير مرئي رغم بقائه في المجموعة.
{{% /alert %}}

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean found = false;

    for (int index = 0; index < slide.getShapes().size(); index++) {
        IShape candidate = slide.getShapes().get_Item(index);
        if (!(candidate instanceof IAutoShape)) {
            continue;
        }

        IAutoShape shape = (IAutoShape) candidate;
        ITextFrame textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null ||
            textFrame == null ||
            textFrame.getText() == null ||
            textFrame.getText().isEmpty()) {
            continue;
        }

        int shapeCount = slide.getShapes().size();
        shape.removePlaceholder();

        System.out.println("Placeholder removed: " + (shape.getPlaceholder() == null));
        System.out.println("Same shape retained: " + (slide.getShapes().get_Item(index) == shape));
        System.out.println("Shape count unchanged: " + (slide.getShapes().size() == shapeCount));

        // استدعاء الطريقة على شكل عادي لا يؤثر.
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

للمحتوى النائب المطابق، تُطبع جميع الفحوصات الثلاثة `true`. يبقى النص، لكن الموقع والحجم والدوران والخط ومحاذاة الفقرة وهوامش إطار النص والتثبيت الرأسي والتعبئة وإعدادات الخط قد تتغيّر عند إزالة علاقة المحتوى النائب. على سبيل المثال، قد يعود تنسيق العنوان الموروث إلى تنسيق النص العادي. راجع [Slide Layout](/slides/ar/androidjava/slide-layout/) لمزيد من المعلومات حول التخطيطات.

للحفاظ على المظهر المقصود، احصل على الموقع والحجم والدوران المحسوبين قبل الاستدعاء، وانسخ قيم التنسيق الفعال المطلوبة إلى متغيّرات منفصلة. استرجع تلك القيم عبر [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--), [IParagraphFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getEffective--), [ITextFrameFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getEffective--), [IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getEffective--), و[ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--). لا تعتمد فقط على كائنات التنسيق الفعال، لأن قيم تنسيق النص قد تتغيّر بعد إزالة العلاقة. طبّق القيم الملتقطة صراحةً على الشكل العادي لاحقًا، بما في ذلك عائلة الخط وحجمه ونمطه ولونه وإعدادات الفقرة وإعدادات إطار النص والتعبئة والخط المستخدم في القالب.

قد تحتاج هندسة الشكل الموروثة إلى تعيين صريح عبر [IGeometryShape.setShapeType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setShapeType-int-). بالنسبة لمحتوى نائب نصي مستطيل، يعني ذلك تعيين [ShapeType.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/#Rectangle)؛ فاستعادة التعبئة والخط فقط قد لا يستعيد المستطيل المرئي. القوالب التي تحتوي على تأثيرات إضافية أو تنسيقات معقدة تتطلب معالجة تلك الإعدادات أيضًا.

## **تغيير النص في المحتوى النائب**

عادةً ما تدعم عناوين، عناوين مركزية، عناوين فرعية، نص الجسم ومحتويات النائب النصية النص. تحقق من وجود [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) قبل استخدام طريقة [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) الخاصة به.

هذا المثال يُحدّث أول محتوى نائب للعنوان في الشريحة الأولى ويحفظ النتيجة:

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

هذا النمط يتجنب تحويل محتوى صورة أو مخطط أو جدول أو وسائط إلى [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/). كما يحدد المحتوى النائب بناءً على الغرض بدلاً من الاعتماد على فهرس شكل هش.

## **تعيين نص الموجه في التخطيط**

نص الموجه هو التعليمات التي تُعرض في محتوى نائب فارغ أثناء التصميم، مثل *Click to add title*. عيّن نص موجه مخصص في محتوى نائب التخطيط بدلاً من محاولة الوصول إليه عبر مجموعة أشكال شريحة عادية. احصل على التخطيط عبر [ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) وتجوّل في المجموعة التي تُعيدها [ILayoutSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/).

المثال التالي يغيّر نصي الموجه للعنوان والعنوان الفرعي في التخطيط المستخدم من قبل الشريحة الأولى:

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

نص الموجه ليس محتوى شريحة عادي. إنه مخصص لمحتويات النائب الفارغة في تطبيقات التحرير مثل PowerPoint. بمجرد أن يضيف المستخدم أو البرنامج محتوى حقيقي، يتوقف عرض الموجه. تغيير الموجه لا يستبدل النص الموجود على الشرائح التي تستخدم ذلك التخطيط.

## **تحديث محتوى نائب الصورة**

هناك حالتان للتعامل معهما:

- إذا كان محتوى الصورة مُملوءًا بالفعل ومُمثلًا بـ [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/)، استبدل الصورة عبر [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) و[ISlidesPicture.setImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/).
- إذا كان لا يزال محتوى نائب فارغًا، أضف إطار صورة في إحداثيات المحتوى النائب عبر [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) وأزل المحتوى النائب الفارغ.

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

الاستبدال الذي يُنشأ لمحتوى نائب فارغ هو إطار صورة محلي، وليس محتوى نائب جديد، لأن [IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) لا يوفر مُعيّنًا. يظل الموقع المحجوز لكنه لا يرث سلوك المحتوى النائب بعد الآن. إذا كانت علاقة المحتوى النائب ضرورية، حضّر المحتوى النائب في PowerPoint أولاً، ثم حدّث [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) الناتج عبر Aspose.Slides.

لشفافية الصورة والاقتصاص وغيرها من تأثيرات الصورة، راجع [Manage Picture Frames](/slides/ar/androidjava/picture-frame/). تلك العمليات تخص إطار الصورة أو تعبئة الصورة، لا بيانات تعريف المحتوى النائب.

## **العمل مع محتويات النائب للمخطط والمحتوى**

يمكن تمثيل محتوى نائب مخطط مملوء بواسطة [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/). هذا المثال يجد مخططًا من هذا النوع عبر كلٍ من نوع المحتوى النائب والواجهة في وقت التشغيل، يغيّر عناوينه، ويحفظ الملف:

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

عادةً ما يكون محتوى نائب عام من النوع [PlaceholderType.Object](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/). في PowerPoint يعمل كمنطلق لعدة أنواع محتوى، بما في ذلك المخططات والجداول والرسوم التخطيطية والصور والوسائط. بعد أن يتم ملؤه، افحص الواجهة الفعلية للشكل لتعرف ما يحتويه. يمكن للتخطيطات المتخصصة أيضًا أن تُظهر [PlaceholderType.Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/)، [PlaceholderType.Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), أو [PlaceholderType.Diagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/).

Aspose.Slides لا يُحوِّل محتوى نائب [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) فارغ إلى [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) بمجرد تغيير [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/); لا يمكن تغيير النوع عبر الواجهة. لملء مخطط أو منطقة محتوى فارغة برمجيًا، أضف الكائن المطلوب في إحداثيات المحتوى النائب ثم أزل المحتوى النائب الفارغ. المثال التالي يفعل ذلك لمخطط:

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

المخطط المضاف هو مخطط محلي عادي. يحتل مساحة المحتوى النائب لكنه لا يرث من محتوى النائب في التخطيط. استخدم مقالات إدارة المخططات المخصصة [chart management articles](/slides/ar/androidjava/powerpoint-charts/) عندما تحتاج إلى استبدال الفئات أو السلاسل أو بيانات المصنف.

## **مثال كامل: تحديث النص أو محتوى الصورة**

المثال التالي من البداية إلى النهاية يفتح قالبًا، يبحث في الشريحة الأولى عن عنوان أو محتوى نائب صورة، يتحقق من نوع المحتوى النائب والشكل، يحدّث المحتوى المناسب، ويحفظ النتيجة. يتجنب المثال الافتراض بشأن فهرس الشكل أو تحويل كل محتوى نائب إلى نفس الواجهة.

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

**ما هو المحتوى النائب الأساسي؟**

المحتوى النائب الأساسي هو الشكل المقابل في التخطيط أو الرئيسي الذي يرث منه محتوى نائب آخر. استخدم [IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) لاسترجاعه. يُعيد الشكل العادي المحلي `null` لأنه ليس جزءًا من تسلسل المحتوى النائب.

**هل يمكنني تغيير جميع عناوين الشرائح عن طريق تحرير محتوى نائب التخطيط؟**

يمكنك تعديل التنسيق الموروث أو نص الموجه عبر التخطيط، لكن محتوى العنوان الموجود مخزن في الشرائح العادية. لاستبدال نص العنوان الفعلي عبر عرض تقديمي، تجول في الشرائح وقم بتحديث كل محتوى نائب للعنوان.

**كيف أدير محتويات النائب لل تاريخ، رقم الشريحة، الرأس، والتذييل؟**

استخدم مديري الرأس والتذييل في نطاق الشريحة المناسب، التخطيط، الرئيسي، الملاحظات أو النسخة المطبوعة. راجع [Manage Presentation Header and Footer](/slides/ar/androidjava/presentation-header-and-footer/) للحصول على أمثلة كاملة.