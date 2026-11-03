---
title: إدارة العناصر النائبة في العروض التقديمية بجافا
linktitle: إدارة العناصر النائبة
type: docs
weight: 10
url: /ar/java/manage-placeholder/
keywords:
- عنصر نائب
- عنصر نائب نصي
- عنصر نائب صورة
- عنصر نائب مخطط
- عنصر نائب محتوى
- نص إرشادي
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية فحص وتحرير عناصر النائب النصية والصورية والمخططية ومحتوى، وفهم وراثة العناصر النائبة باستخدام Aspose.Slides for Java."
---
## **نظرة عامة**

العنصر النائب هو شكل يحجز موقعًا لنوع معين من المحتوى في قالب عرض. أمثلة شائعة هي العنوان، النص الأساسي، الصورة، المخطط، وعناصر نائب عامة للمحتوى. على عكس الشكل العادي، يمكن للعنصر النائب أن يرث موقعه وحجمه وتنسيقه وإعدادات أخرى من شريحة التخطيط أو الشريحة الرئيسية.

Aspose.Slides تُظهر معلومات العنصر النائب عبر طريقة [IShape.getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)​. تُرجع الطريقة كائنًا من نوع [IPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/)​ أو `null` لشكل عادي. استخدم [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) لتحديد ما يُقصد أن يحتويه العنصر النائب.

لا يزال واجهة الشكل مهمة بعد معرفة نوع العنصر النائب:

- عادةً ما يُمثَّل عنصر نائب فارغ للنص أو الصورة أو المخطط أو المحتوى بواسطة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)​.
- يمكن تمثيل عنصر نائب صورة مُعبَّأ بواسطة [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/)​.
- يمكن تمثيل عنصر نائب مخطط مُعبَّأ بواسطة [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/)​.
- يمكن لعنصر نائب المحتوى احتواء عدة أنواع من المحتوى. تحقق من كل من [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) وواجهة الشكل في وقت التشغيل بدلاً من افتراض أن كل عنصر نائب هو [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)​.

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) يصف دور العنصر النائب؛ لكنه لا يضمن نوع الشكل في وقت التشغيل. استخدم دائماً فحص النوع قبل الوصول إلى النص أو الصورة أو المخطط أو الجدول أو الأعضاء الخاصة بالوسائط.
{{% /alert %}}

## **فهم وراثة العنصر النائب**

تشكل العناصر النائبة تسلسلاً هرميًا:

1. تُعرِّف شريحة رئيسية الأنماط القابلة لإعادة الاستخدام، وفي بعض الحالات، العناصر النائبة على مستوى الرئيس.
2. تُعرِّف شريحة تخطيط الترتيب الذي يستخدمه شريحة أو أكثر عادية ويمكن أن يرث من الرئيس.
3. تحتوي شريحة عادية على العناصر النائبة لتلك الشريحة ويمكن أن ترث من التخطيط الخاص بها.

استدعِ [IShape.getBasePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) للانتقال مستوىً واحدًا أعلى في هذا الهرم. عادةً ما تُرجع شريحة العنصر النائب العنصر النائب الخاص بالتخطيط؛ ويمكن لعناصر النائب في التخطيط إرجاع العنصر النائب الرئيسي. تُرجع الطريقة `null` عندما لا يملك الشكل عنصرًا نائبًا أساسيًا.

المثال التالي يسرد العناصر النائبة في الشريحة الأولى ويُظهر عناصرها النائبة الأساسية:

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

تحرير عنصر نائب في شريحة عادية يُنشئ أو يغيّر تجاوزًا محليًا لتلك الشريحة. تحرير التخطيط أو الرئيس المرتبط يمكن أن يُؤثر على جميع الشرائح التي لا تزال ترث هذا الإعداد. الشكل العادي المحلي ليس له عنصر نائب أساسي ولا يبدأ في الوراثة لمجرد أنه يشغل نفس الإحداثيات.

## **إزالة حالة العنصر النائب**

عند تعديل قالب، استخدم [IShape.removePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#removePlaceholder--) لإبقاء الكائن الحالي كشكل عادي. تُرجع طريقة [getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getPlaceholder--)`null`، لكن يبقى الشكل في مجموعة الشرائح. بالمقابل، [IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) يحذف الشكل من تلك المجموعة.

المثال التالي يتطلب ملف `template.pptx` يحتوي على شريحة واحدة على الأقل وعنصر نائب نص غير فارغ في الشريحة الأولى. استخدم عنصر نائب بتنسيق مُورَّث من التخطيط أو الرئيس لرؤية تأثير إزالة تلك العلاقة. يتحقق المثال من بقاء الشكل نفسه، ثم يستدعي الطريقة مرة أخرى على الشكل الآن العادي، ويحفظ النتيجة.

{{% alert color="warning" title="Warning" %}}
إزالة حالة العنصر النائب لا تحتفظ تلقائيًا بإعدادات المظهر الموروثة. المثال أدناه يترك تلك الإعدادات دون تغيير، لذا قد يبدو الناتج مختلفًا. الشكل الذي يرث موقعه وحجمه بالكامل قد يصبح إحداثياته وأبعاده صفرًا بعد الاستدعاء ويصبح غير مرئي رغم بقاءه في المجموعة.
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

بالنسبة لعنصر نائب مطابق، تُظهر الفحوصات الثلاثة `true`. يبقى النص موجودًا، لكن الموقع والحجم والدوران والخط ومحاذاة الفقرة وهوامش إطار النص والتثبيت العمودي والتعبئة وإعدادات الخط قد تتغير عند إزالة علاقة العنصر النائب. على سبيل المثال، قد يعود تنسيق العنوان الموروث إلى تنسيق النص العادي. راجع [Slide Layout](/slides/ar/java/slide-layout/) لمزيد من المعلومات حول التخطيطات.

للحفاظ على المظهر المقصود، احصل على الموقع والحجم والدوران المحلولين قبل الاستدعاء، وانسخ قيم التنسيق الفعَّال المطلوبة إلى متغيرات منفصلة. استرجع تلك القيم عبر [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--), [IParagraphFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getEffective--), [ITextFrameFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getEffective--), [IFillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getEffective--), و[ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--). لا تعتمد على الاحتفاظ فقط بكائنات التنسيق الفعَّال، لأن قيم تنسيق النص قد تتغير بعد إزالة العلاقة. طبّق القيم الملتقطة صراحةً على الشكل العادي بعد ذلك، بما في ذلك عائلة الخط، الحجم، النمط، اللون، إعدادات الفقرة، إعدادات إطار النص، التعبئة، والخط المستخدم في القالب.

قد تحتاج أيضاً إلى تعيين هندسة الشكل الموروثة صراحةً عبر [IGeometryShape.setShapeType](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setShapeType-int-). بالنسبة لعنصر نائب نص مستطيل، يعني ذلك تعيين [ShapeType.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/shapetype/#Rectangle)؛ فقد لا يُعيد استعادة التعبئة والخط فقط المستطيل المرئي. القوالب التي تحتوي على تأثيرات إضافية أو تنسيقات أكثر تعقيدًا تتطلب معالجة تلك الإعدادات أيضًا.

## **تغيير النص في عنصر نائب**

عادةً ما تدعم العناوين والعناوين المركزية والعناوين الفرعية والعناصر النصية والنصوص عناصر نائب النص. تحقّق من وجود [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) قبل استخدام طريقة [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) الخاصة بها.

المثال التالي يُحدّث أول عنصر نائب للعنوان في الشريحة الأولى ويحفظ النتيجة:

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

هذا النمط يتجنب تحويل عناصر النائب للصورة أو المخطط أو الجدول أو الوسائط إلى [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/). كما يحدد عنصر النائب بناءً على الغرض بدلاً من الاعتماد على فهرس الشكل الهش.

## **تعيين نص إرشادي في التخطيط**

النص الإرشادي هو التعليمات التي تُعرض في عنصر نائب فارغ أثناء التصميم، مثل *انقر لإضافة عنوان*. عيّن نصًا إرشاديًا مخصصًا على عنصر النائب في التخطيط بدلاً من محاولة الوصول إليه عبر مجموعة أشكال الشريحة العادية. احصل على التخطيط عبر [ISlide.getLayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) وتكرَّر عبر المجموعة التي تُرجعها [ILayoutSlide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/).

المثال التالي يغيّر نصوص الإرشاد للعنوان والعنوان الفرعي في التخطيط المستخدم من قبل الشريحة الأولى:

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

النص الإرشادي ليس محتوى شريحة عادي. إنه مخصص للعناصر النائبة الفارغة في تطبيقات التحرير مثل PowerPoint. بمجرد أن يضيف المستخدم أو البرنامج محتوىً حقيقيًا، لا يُظهر النص الإرشادي بعد ذلك. تغيير نص إرشادي لا يستبدل النص الموجود على الشرائح التي تستخدم التخطيط.

## **تحديث عنصر نائب لصورة**

هناك حالتان للتعامل معهما:

- إذا كان عنصر نائب الصورة مُعبَّأًا بالفعل ومُمثَّلًا بـ[IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/)، استبدل الصورة عبر [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) و[ISlidesPicture.setImage](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/)​.
- إذا كان لا يزال عنصرًا نائبًا فارغًا، أضف إطار صورة عند إحداثيات العنصر النائب باستخدام [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/) وأزل العنصر النائب الفارغ.

المثال التالي يدعم الحالتين ويحفظ العرض:

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

الاستبدال الذي يُنشأ لعنصر نائب فارغ هو إطار صورة محلي، وليس عنصرًا نائبًا جديدًا، لأن [IShape.getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) لا يوفر طريقة تعيين. يحتفظ بالموقع المحجوز لكنه لا يرث سلوك العنصر النائب بعد الآن. إذا كان الحفاظ على علاقة العنصر النائب أمرًا أساسيًا، فقم بإعداد وتعبئة العنصر النائب في PowerPoint أولاً، ثم حدّث [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) الناتج باستخدام Aspose.Slides.

لشفافية الصورة والاقتصاص وتأثيرات الصورة الأخرى، راجع [Manage Picture Frames](/slides/ar/java/picture-frame/). تلك العمليات تتبع إطار الصورة أو تعبئة الصورة، لا بيانات تعريف العنصر النائب.

## **العمل مع عناصر نائب المخطط والمحتوى**

يمكن تمثيل عنصر نائب مخطط مُعبَّأ بواسطة [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/). يحدد هذا المثال مثل هذا المخطط عبر كل من نوع العنصر النائب والواجهة في وقت التشغيل، يغيّر عنوانه، ويحفظ الملف:

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

عادةً ما يكون عنصر نائب محتوى عام هو [PlaceholderType.Object](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/). في PowerPoint يعمل كمنقِّل للعديد من أنواع المحتوى، بما في ذلك المخططات والجدولين والرسوم البيانية والصور والوسائط. بعد تعبئته، افحص واجهة الشكل الفعلية لمعرفة ما يحتويه. يمكن للتخطيطات المتخصصة أيضًا أن تُظهر [PlaceholderType.Chart](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/)، [PlaceholderType.Table](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), أو [PlaceholderType.Diagram](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/).

Aspose.Slides لا يحول عنصر نائب [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) فارغ إلى [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) فقط بتغيير [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/). لا يمكن تغيير النوع عبر الواجهة. لملء مخطط أو منطقة محتوى فارغة برمجيًا، أضف الكائن المطلوب عند إحداثيات العنصر النائب ثم أزل العنصر النائب الفارغ. المثال التالي يفعل ذلك لمخطط:

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

المخطط المضاف هو مخطط محلي عادي. يشغل مساحة العنصر النائب لكنه لا يرث من العنصر النائب في التخطيط. استخدم [مقالات إدارة المخططات](/slides/ar/java/powerpoint-charts/) عندما تحتاج إلى استبدال الفئات أو السلاسل أو بيانات المصنف الخاصة به.

## **مثال كامل: تحديث النص أو محتوى الصورة**

المثال التالي من البداية إلى النهاية يفتح قالبًا، يبحث في الشريحة الأولى عن عنصر نائب للعنوان أو الصورة، يتحقق من نوع العنصر النائب والشكل، يُحدِّث المحتوى المناسب، ويحفظ النتيجة. يتجنب المثال افتراض فهرس شكل أو تحويل كل عنصر نائب إلى نفس الواجهة.

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

## **الأسئلة المتكررة**

**ما هو العنصر النائب الأساسي؟**

العنصر النائب الأساسي هو الشكل المقابل في التخطيط أو الرئيس التي يرث منها عنصر نائب آخر. استخدم [IShape.getBasePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) لاسترجاعه. الشكل العادي المحلي يُرجع `null` لأنه ليس جزءًا من تسلسل العناصر النائبة.

**هل يمكنني تغيير جميع عناوين الشرائح عن طريق تعديل عنصر نائب في التخطيط؟**

يمكنك تغيير التنسيق الموروث أو النص الإرشادي عبر التخطيط، لكن محتوى العنوان الموجود يُخزن في الشرائح العادية. لاستبدال نص العنوان الفعلي عبر العرض بالكامل، تكرّر على الشرائح وقم بتحديث كل عنصر نائب للعنوان.

**كيف أدير عناصر نائب التاريخ ورقم الشريحة والرأس وتذييل الصفحة؟**

استخدم مديري الرأس والتذييل في نطاق الشريحة أو التخطيط أو الرئيس أو الملاحظات أو نسخة التوزيع. راجع [Manage Presentation Header and Footer](/slides/ar/java/presentation-header-and-footer/) للحصول على أمثلة كاملة.