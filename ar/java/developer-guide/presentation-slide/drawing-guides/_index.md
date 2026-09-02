---
title: إدارة أدلة الرسم في العروض التقديمية بجافا
linktitle: أدلة الرسم
type: docs
weight: 85
url: /ar/java/drawing-guides/
keywords:
- دليل رسم
- دليل أفقي
- دليل عمودي
- دليل محاذاة
- عرض الشريحة
- شريحة القالب
- شريحة التخطيط
- قالب الملاحظات
- قالب النشرات
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "إضافة، الوصول إلى، وإزالة أدلة الرسم الأفقية والعمودية في عروض PowerPoint باستخدام Aspose.Slides for Java."
---
## **نظرة عامة**

أدلة الرسم هي خطوط أفقية وعمودية قابلة للتعديل تساعد المستخدمين على محاذاة الأشكال بشكل ثابت أثناء تحرير عرض تقديمي في PowerPoint. تكون مفيدة بشكل خاص عندما يُنشئ تطبيق عرضًا تقديميًا سيُعدل يدويًا لاحقًا: يمكن للتطبيق حفظ نفس أدوات المحاذاة التي يجب على المؤلفين اتباعها عند إضافة أو تحريك المحتوى.

أدلة الرسم هي أدوات تحرير، ليست محتوىً للشرائح. لا تظهر في عرض الشرائح أو في المخرجات المرسومة. تُتيح Aspose.Slides for Java الوصول إليها عبر واجهة [IDrawingGuidesCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idrawingguidescollection/) . يتم تمثيل الدليل بواسطة [IDrawingGuide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idrawingguide/) ويحتوي على توجيه وموقع ولون.

يُقاس الموضع بالنقاط من الزاوية العلوية اليسرى للشفرة أو القالب المعني. تستخدم الدليل العمودي إحداثيًا أفقيًا، عادةً بين الصفر وعرض الشريحة. يستخدم الدليل الأفقي إحداثيًا عموديًا، عادةً بين الصفر وارتفاع الشريحة.

## **إضافة الأدلة إلى عرض الشريحة**

استخدم [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) لإدارة الأدلة المعروضة أثناء تحرير الشرائح العادية. استدعِ [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idrawingguidescollection/#add-byte-float-) مع قيمة [Orientation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/orientation/) وموقع بالنقاط.

The following example adds one vertical guide to the right of the slide center and one horizontal guide below it:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 + 12.5));
    guides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 12.5));

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الوصول إلى أدلة الرسم**

توفر طُرُق [IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idrawingguidescollection/#getCount--) و[IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idrawingguidescollection/#get_Item-int-) إمكانية الوصول إلى الأدلة الموجودة. تُعيد طُرُق [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idrawingguide/#getOrientation--), [IDrawingGuide.getPosition](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idrawingguide/#getPosition--), و[IDrawingGuide.getColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idrawingguide/#getColor--) قيمًا يمكن أيضًا تعديلها عبر طرُق الضبط المقابلة.

The following example reads the slide-view guides from the presentation created above:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("drawing-guides.pptx");
try {
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (int index = 0; index < guides.getCount(); index++) {
        IDrawingGuide guide = guides.get_Item(index);
        System.out.println("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **إضافة الأدلة إلى شريحة القالب وتخطيطات الشرائح**

يمكن أن يكون للقالب الشريحي ولكل من شرائح التخطيط الخاصة به مجموعات خاصة من أدلة الرسم. استخدم [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslide/#getDrawingGuides--) لقالب الشريحة و[ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutslide/#getDrawingGuides--) لشريحة التخطيط.

The following example adds a vertical guide to the first master slide and a horizontal guide to the first layout slide:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 - 20));
    layoutGuides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 20));

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إضافة الأدلة إلى قالب الملاحظات وقالب النسخ**

تدعم قوالب الملاحظات وقوالب النسخ أيضًا أدلة الرسم. استخدم [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasternotesslide/#getDrawingGuides--) و[IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) للوصول إلى مجموعاتهم. إذا لم يحتوي العرض التقديمي على أحد هذه القوالب، فإن [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) أو [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) ينشئ القالب الافتراضي ويعيده.

The following example adds a horizontal guide to a notes master and a vertical guide to a handout master:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, (float) (notesSize.getHeight() / 2 + 50));
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, (float) (notesSize.getWidth() / 2 - 50));

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **مسح أدلة الرسم**

استدعِ [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idrawingguidescollection/#clear--) لإزالة كل دليل من مجموعة معينة. مسح مجموعة واحدة لا يؤثر على الأدلة المخزنة في نطاق آخر.

The following example clears the slide-view guides and all guides on slide masters, layout slides, the notes master, and the handout master without creating missing masters:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (IMasterSlide masterSlide : presentation.getMasters()) {
        masterSlide.getDrawingGuides().clear();
    }

    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        layoutSlide.getDrawingGuides().clear();
    }

    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        notesMaster.getDrawingGuides().clear();
    }

    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster != null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة المتكررة**

**هل تظهر أدلة الرسم في عرض الشرائح أو الصور المصدرة؟**

لا. أدلة الرسم هي أدوات محاذاة للتحرير ولا تُظهر كجزء من محتوى العرض.

**هل يمكن إضافة دليل رسم مباشرةً إلى شريحة عادية فردية؟**

تُخزن أدلة تحرير الشرائح العادية في خصائص عرض الشرائح في العرض التقديمي. تتوفر مجموعات أدلة منفصلة لقوالب الشرائح، شرائح التخطيط، قوالب الملاحظات، وقوالب النسخ.

**ما الوحدات المستخدمة لمواقع الأدلة؟**

يُحدد الموضع بالنقاط، حيث يساوي 72 نقطة بوصة واحدة. تُقاس المواضع العمودية من الحافة اليسرى، وتُقاس المواضع الأفقية من الحافة العلوية.

**هل يؤدي مسح أدلة الرسم إلى إزالة الأشكال أو تغيير محتوى الشريحة؟**

لا. تُزيل طريقة [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idrawingguidescollection/#clear--) الأدلة فقط في المجموعة المحددة. تبقى الأشكال ومحتوى الشريحة الآخر دون تغيير.