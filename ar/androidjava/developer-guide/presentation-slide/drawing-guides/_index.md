---
title: إدارة أدلة الرسم في العروض التقديمية على Android
linktitle: أدلة الرسم
type: docs
weight: 85
url: /ar/androidjava/drawing-guides/
keywords:
- دليل رسم
- دليل أفقي
- دليل عمودي
- دليل محاذاة
- عرض شريحة
- شريحة قالب
- شريحة تخطيط
- قالب ملاحظات
- قالب نشرة
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إضافة، والوصول إلى، ومسح أدلة الرسم الأفقية والعمودية في عروض PowerPoint التقديمية باستخدام Aspose.Slides لنظام Android عبر Java."
---
## **نظرة عامة**

دليل الرسم هو خطوط أفقية وعمودية قابلة للتعديل تساعد المستخدمين على محاذاة الأشكال بشكل ثابت أثناء تعديل عرض تقديمي في PowerPoint. تكون مفيدة بشكل خاص عندما يولد تطبيق عرضًا تقديميًا سيتتم تحسينه يدويًا لاحقًا: يمكن للتطبيق حفظ نفس أدوات المحاذاة التي يجب على المؤلفين اتباعها عند إضافة أو نقل المحتوى.

دليل الرسم هو أداة تحرير، ليس محتوى شريحة. لا تظهر في عرض الشرائح أو الإخراج المُصوَّر. تُظهر Aspose.Slides for Android عبر Java هذه الأدوات من خلال الواجهة [IDrawingGuidesCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idrawingguidescollection/). يُمثَّل الدليل بواسطة [IDrawingGuide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idrawingguide/) ويحتوي على اتجاه وموقع ولون.

يُقاس الموقع بوحدات النقاط من الزاوية العلوية اليسرى للشفرة أو القالب ذات الصلة. يستخدم الدليل العمودي إحداثيًا أفقيًا، عادةً بين الصفر وعرض الشريحة. يستخدم الدليل الأفقي إحداثيًا عموديًا، عادةً بين الصفر وارتفاع الشريحة.

## **إضافة أدلة إلى عرض الشريحة**

استخدم [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) لإدارة الأدلة المعروضة أثناء تحرير الشرائح العادية. استدعِ [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idrawingguidescollection/#add-byte-float-) مع قيمة [Orientation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/orientation/) وموقع بوحدات النقاط.

المثال التالي يضيف دليلًا عموديًا واحدًا إلى يمين مركز الشريحة ودليلًا أفقيًا أسفله:
```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, slideSize.getWidth() / 2 + 12.5f);
    guides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5f);

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الوصول إلى أدلة الرسم**

توفر طُرُق [IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idrawingguidescollection/#getCount--) و [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idrawingguidescollection/#get_Item-int-) إمكانية الوصول إلى الأدلة الموجودة. تُعيد طُرُق [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idrawingguide/#getOrientation--)، [IDrawingGuide.getPosition](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iddrawingguide/#getPosition--)، و [IDrawingGuide.getColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iddrawingguide/#getColor--) قيمًا يمكن أيضًا تعديلها عبر طُرُق الضبط المقابلة.

المثال التالي يقرأ أدلة عرض الشريحة من العرض التقديمي الذي تم إنشاؤه أعلاه:
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

## **إضافة أدلة إلى القوالب وعروض التخطيط**

يمكن لقالب الشريحة وكل من شرائح التخطيط الخاص به أن يمتلك مجموعات أدلة رسم خاصة. استخدم [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterslide/#getDrawingGuides--) لقالب الشريحة و [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutslide/#getDrawingGuides--) لشرائح التخطيط.

المثال التالي يضيف دليلًا عموديًا إلى أول شريحة قالب ودليلًا أفقيًا إلى أول شريحة تخطيط:
```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إضافة أدلة إلى قوالب الملاحظات والنشرات**

تدعم قوالب الملاحظات وقوالب النشرات أيضًا أدلة الرسم. استخدم [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasternotesslide/#getDrawingGuides--) و [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) للوصول إلى مجموعاتهم. إذا لم يحتوي العرض التقديمي على أحد هذه القوالب، فإن [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) أو [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) يقوم بإنشاء القالب الافتراضي ويعيده.

المثال التالي يضيف دليلًا أفقيًا إلى قالب ملاحظات ودليلًا عموديًا إلى قالب نشرة:
```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **مسح أدلة الرسم**

استدعِ [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) لإزالة كل دليل من مجموعة معينة. مسح مجموعة واحدة لا يؤثر على الأدلة المخزنة في نطاق آخر.

المثال التالي يمسح أدلة عرض الشريحة وجميع الأدلة على قوالب الشرائح، شرائح التخطيط، قالب الملاحظات، وقالب النشرة دون إنشاء القوالب المفقودة:
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

## **الأسئلة المتداولة**

**هل تظهر أدلة الرسم في عرض الشرائح أو الصور المصدَّرة؟**  
لا. أدلة الرسم هي أدوات محاذاة للتعديل ولا تُعرض كجزء من محتوى العرض.

**هل يمكن إضافة دليل رسم مباشرةً إلى شريحة عادية فردية؟**  
تُخزن أدلة تحرير الشرائح العادية في خصائص عرض الشرائح الخاصة بالعرض التقديمي. تتوفر مجموعات أدلة منفصلة لقوالب الشرائح، شرائح التخطيط، قوالب الملاحظات، وقوالب النشرات.

**ما الوحدات المستخدمة لمواقع الأدلة؟**  
يتم تحديد المواقع بوحدات النقاط، حيث 72 نقطة تساوي بوصة واحدة. تُقاس المواقع الرأسية من الحافة اليسرى، وتُقاس المواقع الأفقية من الحافة العلوية.

**هل يؤدي مسح أدلة الرسم إلى إزالة الأشكال أو تغيير محتوى الشريحة؟**  
لا. تُزيل طريقة [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) فقط الأدلة في المجموعة المختارة. تبقى الأشكال ومحتوى الشريحة الآخر دون تغيير.