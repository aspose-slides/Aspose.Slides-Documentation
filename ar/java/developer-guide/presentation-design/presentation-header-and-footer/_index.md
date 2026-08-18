---
title: إدارة رؤوس وتذييلات العرض التقديمي في Java
linktitle: الرأس والتذييل
type: docs
weight: 140
url: /ar/java/presentation-header-and-footer/
keywords:
- رأس
- نص الرأس
- تذييل
- نص التذييل
- تعيين رأس
- تعيين تذييل
- نشرة
- ملاحظات
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية إدارة نوازل التذييل، التاريخ والوقت، رقم الشريحة، والرأس على الشرائح، صفحات الملاحظات، والنشرات باستخدام Aspose.Slides for Java."
---
## **نظرة عامة**

يستخدم PowerPoint نوازل رأس وتذييل مختلفة حسب نوع الصفحة. يتيح Aspose.Slides for Java التحكم في النص وإمكانية رؤية هذه النوازل من خلال واجهات مدير الرأس/التذييل.

تعتمد النوازل المتاحة على النطاق:

| النطاق | الرأس | التذييل | التاريخ/الوقت | رقم الشريحة/الصفحة |
|---|---|---|---|---|
| شريحة عادية | لا | نعم | نعم | نعم |
| قالب الملاحظات | نعم | نعم | نعم | نعم |
| شريحة ملاحظات | نعم | نعم | نعم | نعم |
| قالب النشرة | نعم | نعم | نعم | نعم |

لا تحتوي الشريحة العادية في العرض التقديمي على نقش رأس. تتوفر رؤوس الصفحات على صفحات الملاحظات والنشرات. بالنسبة للشرائح العادية، استخدم نوازل التذييل، التاريخ/الوقت، ورقم الشريحة بدلاً من ذلك.

يعتمد نطاق التغيير على المدير الذي تستخدمه. تتحكم واجهة [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islideheaderfootermanager/) في شريحة عادية واحدة. تتحكم واجهة [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/inotesslideheaderfootermanager/) في شريحة ملاحظات واحدة. يمكن لمديري القالب وتخطيط الشريحة أيضًا نشر الإعدادات إلى الشرائح التابعة، بينما تتحكم واجهة [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) في قالب النشرة.

## **تعيين التذييل، التاريخ/الوقت، وأرقام الشرائح على الشرائح العادية**

بالنسبة للشرائح العادية، تدفق العمل الأساسي هو الوصول إلى مدير الرأس/التذييل لكل شريحة، ضبط نص التذييل والتاريخ/الوقت، تمكين النوازل المطلوبة، ثم حفظ العرض التقديمي. يتم توليد أرقام الشرائح بواسطة العرض التقديمي، لذا يكفي التحكم في رؤيتها فقط.

استخدم [`setFooterText`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) و[`setDateTimeText`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-) لتعيين النص، واستخدم [`setFooterVisibility`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-)، [`setDateTimeVisibility`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-)، و[`setSlideNumberVisibility`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-) لإظهار النوازل المقابلة.

المثال التالي يطبق نفس التذييل، نص التاريخ/الوقت، ورؤية رقم الشريحة على جميع الشرائح العادية:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideHeaderFooterManager headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

إذا كنت بحاجة إلى تحديث شريحة واحدة فقط، يمكنك الوصول إلى تلك الشريحة مباشرة عبر طريقة [`getSlides`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getSlides--) بدلاً من التنقل عبر المجموعة بأكملها.

## **تعيين الرؤوس والتذييلات على قالب الملاحظات**

يحدد قالب الملاحظات تنسيقًا مشتركًا وسلوك النوازل لصفحات الملاحظات. استخدم واجهة [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasternotesslideheaderfootermanager/) عندما تريد تغيير قالب الملاحظات نفسه فقط.

المثال التالي يضبط رأس، تذييل، ونص التاريخ/الوقت على قالب الملاحظات ويجعل جميع النوازل المدعومة مرئية على ذلك القالب:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

طريقة [`getMasterNotesSlide`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) تُرجع `null` عندما لا يحتوي العرض التقديمي على قالب ملاحظات.

## **تطبيق إعدادات قالب الملاحظات على شرائح الملاحظات الفرعية**

يمكن لقالب الملاحظات تطبيق إعدادات الرأس والتذييل على نفسه وعلى جميع شرائح الملاحظات التابعة. استخدم طرق النشر المخصصة على [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasternotesslideheaderfootermanager/) عندما يجب تطبيق نفس الإعدادات عبر هيكل الملاحظات.

على سبيل المثال، تقوم كل من [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) و[`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) بتحديث رأس قالب الملاحظات وجميع رؤوس الأطفال. تتوفر طرق مكافئة للتذييلات، التاريخ/الوقت، وأرقام الشرائح.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

طرق النشر المستخدمة أعلاه هي [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-)، [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-)، [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-)، [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-)، و[`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-).

## **تعيين الرؤوس والتذييلات على شريحة ملاحظات فردية**

تنتمي شريحة الملاحظات إلى شريحة عادية محددة. استخدم واجهة [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/inotesslideheaderfootermanager/) عندما تريد تخصيص تلك الصفحة الملاحظة فقط.

طريقة [`addNotesSlide`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/inotesslidemanager/#addNotesSlide--) تُرجع شريحة الملاحظات للشريحة الحالية وتُنشئ واحدة إذا لم تكن موجودة مسبقًا. المثال التالي يكوّن صفحة الملاحظات المرتبطة بأول شريحة في العرض التقديمي:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();
    INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

إذا قمت أولاً بنشر الإعدادات من قالب الملاحظات ثم غيرت شريحة ملاحظات فردية، فإن الإعدادات اللاحقة لكل شريحة تسمح لك بتخصيص تلك الصفحة بشكل مستقل.

## **تعيين الرؤوس والتذييلات على قالب النشرة**

تستخدم صفحات النشرة قالب النشرة لنوازل الرأس، التذييل، التاريخ/الوقت، ورقم الصفحة. على عكس صفحات الملاحظات، تُدار إعدادات النشرة عبر قالب النشرة بدلاً من الشرائح الفردية.

استخدم طريقة [`getMasterHandoutSlide`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) للوصول إلى قالب النشرة. إذا لم يكن موجودًا، استدعِ [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) لإنشاء قالب النشرة الافتراضي.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterHandoutSlide masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide == null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide != null) {
        IMasterHandoutSlideHeaderFooterManager headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **فهم النطاق والوراثة**

اختر مدير الرأس/التذييل الذي يتطابق مع النطاق الذي تريد تغييره:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islideheaderfootermanager/) يغيّر إعدادات التذييل، التاريخ/الوقت، ورقم الشريحة لشريحة عادية واحدة.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutslideheaderfootermanager/) يتحكم في شريحة تخطيط ويمكنه نشر الإعدادات المدعومة إلى الشرائح التابعة.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslideheaderfootermanager/) يتحكم في قالب شريحة عادية ويمكنه نشر الإعدادات المدعومة إلى الشرائح التابعة.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasternotesslideheaderfootermanager/) يتحكم في قالب الملاحظات ويمكنه نشر الإعدادات إلى جميع الشرائح التابعة للملاحظات.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/inotesslideheaderfootermanager/) يغيّر شريحة ملاحظات واحدة ويدعم نقش رأس بالإضافة إلى التذييل، التاريخ/الوقت، ورقم الشريحة.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) يغيّر قالب النشرة ويدعم جميع أنواع النوازل الأربعة.

استخدم النشر من قالب أو تخطيط عندما يجب أن يُطبق الإعداد نفسه عبر هيكله. استخدم مدير شريحة فردية أو شريحة ملاحظات عندما تحتاج إلى إعداد محلي لصفحة واحدة.

## **الأسئلة المتكررة**

**هل يمكنني إضافة رأس إلى شريحة عادية؟**

لا. لا يحدد PowerPoint نقش رأس للشريحة العادية. على الشرائح العادية، استخدم نوازل التذييل، التاريخ/الوقت، ورقم الشريحة. نوازل الرأس متوفرة على صفحات الملاحظات والنشرات.

**ماذا يحدث إذا لم يكن نقش التذييل، أو التاريخ/الوقت، أو رقم الشريحة مرئيًا؟**

استخدم مدير الرأس/التذييل المقابل للتحقق من رؤيته وتمكينه عند الحاجة. على سبيل المثال، تُظهر الطريقة [`isFooterVisible`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) ما إذا كان نقش التذييل موجودًا، وتغيّر الطريقة [`setFooterVisibility`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) رؤيته.

**كيف أبدأ ترقيم الشرائح من قيمة غير 1؟**

استدعِ طريقة [`setFirstSlideNumber`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) في العرض التقديمي. ثم تستخدم نوازل رقم الشريحة تسلسل الترقيم المحدث.

**ماذا يحدث للرؤوس والتذييلات عند التصدير إلى PDF أو صور أو HTML؟**

يتم تضمين عناصر الرأس والتذييل المرئية مع محتوى العرض التقديمي في صيغة الإخراج. يحدد نوع الصفحة التي يتم تصديرها وإعدادات رؤية النوازل المظهر النهائي.