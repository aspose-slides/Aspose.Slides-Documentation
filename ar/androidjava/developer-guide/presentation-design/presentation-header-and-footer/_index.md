---
title: إدارة رؤوس وتذييلات العرض التقديمي على Android
linktitle: رأس وتذييل
type: docs
weight: 140
url: /ar/androidjava/presentation-header-and-footer/
keywords:
- رأس
- نص الرأس
- تذييل
- نص التذييل
- تعيين الرأس
- تعيين التذييل
- نشرة
- ملاحظات
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية إدارة نواِب التذييل، التاريخ/الوقت، رقم الشريحة، والرأس على الشرائح، صفحات الملاحظات، والنشرات باستخدام Aspose.Slides لنظام Android عبر Java."
---
## **نظرة عامة**

يستخدم PowerPoint نائِبات رأس وتذييل مختلفة حسب نوع الصفحة. يتيح Aspose.Slides لنظام Android عبر Java التحكم في النص ورؤية هذه النائِبات من خلال واجهات مدير رأس/تذييل.

تعتمد النائِبات المتاحة على النطاق:

| النطاق | رأس | تذييل | التاريخ/الوقت | رقم الشريحة/الصفحة |
|---|---|---|---|---|
| شريحة عادية | لا | نعم | نعم | نعم |
| قالب ملاحظات | نعم | نعم | نعم | نعم |
| شريحة ملاحظات | نعم | نعم | نعم | نعم |
| قالب توزيع | نعم | نعم | نعم | نعم |

ليس لدى شريحة عرض عادية نائِب رأس. يتوفر الرأس في صفحات الملاحظات والنشرات. بالنسبة للشرائح العادية، استخدم نائِبات التذييل، التاريخ/الوقت، ورقم الشريحة بدلاً من ذلك.

يعتمد نطاق التغيير على المدير الذي تستخدمه. واجهة [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islideheaderfootermanager/) تتحكم في شريحة عادية واحدة. واجهة [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) تتحكم في شريحة ملاحظات واحدة. يمكن لمديري القالب وتخطيط الشرائح أيضًا نشر الإعدادات إلى الشرائح التابعة، بينما تتحكم واجهة [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) في قالب النشرة.

## **تعيين التذييل، التاريخ/الوقت، وأرقام الشرائح في الشرائح العادية**

بالنسبة للشرائح العادية، يكون سير العمل الأساسي هو الوصول إلى مدير رأس/تذييل كل شريحة، تعيين نص التذييل والتاريخ/الوقت، تمكين النائِبات المطلوبة، ثم حفظ العرض التقديمي. تُولّد أرقام الشرائح من قبل العرض التقديمي، لذلك تحتاج فقط للتحكم في رؤيتها.

استخدم [`setFooterText`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) و[`setDateTimeText`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-) لتعيين النص، واستخدم [`setFooterVisibility`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-)،[`setDateTimeVisibility`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-)، و[`setSlideNumberVisibility`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-) لإظهار النائِبات المقابلة.

المثال الكامل التالي يطبق نفس التذييل، نص التاريخ/الوقت، ورؤية رقم الشريحة على جميع الشرائح العادية:

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

إذا كنت بحاجة لتحديث شريحة واحدة فقط، يمكنك الوصول إلى تلك الشريحة مباشرة عبر طريقة [`getSlides`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getSlides--) بدلاً من التكرار عبر المجموعة بأكملها.

## **تعيين الرؤوس والتذييلات في قالب الملاحظات**

يحدد قالب الملاحظات التنسيق المشترك وسلوك النائب لصفحات الملاحظات. استخدم واجهة [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) عندما تريد تغيير قالب الملاحظات نفسه فقط.

المثال التالي يضبط رأس، تذييل، ونص التاريخ/الوقت في قالب الملاحظات ويجعل جميع النوابئ المدعومة مرئية في ذلك القالب:

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

طريقة [`getMasterNotesSlide`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) تُرجع `null` عندما لا يحتوي العرض التقديمي على قالب ملاحظات.

## **تطبيق إعدادات قالب الملاحظات على الشرائح التابعة**

يمكن لقالب الملاحظات تطبيق إعدادات الرأس والتذييل على نفسه وعلى جميع الشرائح التابعة. استخدم طرق النشر المخصصة في [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) عندما يجب تطبيق نفس الإعدادات عبر شجرة الملاحظات.

على سبيل المثال، تقوم طريقتا [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) و[`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) بتحديث رأس قالب الملاحظات وجميع رؤوس الأطفال. تتوفر طرق مماثلة للتذييلات، التاريخ/الوقت، وأرقام الشرائح.

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

طرق النشر المستخدمة أعلاه هي [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-)،[`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-)،[`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-)،[`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-)، و[`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-).

## **تعيين الرؤوس والتذييلات في شريحة ملاحظات فردية**

تنتمي شريحة الملاحظات إلى شريحة عرض عادية محددة. استخدم واجهة [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) عندما تريد تخصيص تلك الصفحة الملاحظة فقط.

طريقة [`addNotesSlide`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/inotesslidemanager/#addNotesSlide--) تُرجع شريحة الملاحظات للشريحة الحالية وتُنشئ واحدة إذا لم تكن موجودة. المثال التالي يكوّن صفحة الملاحظات المرتبطة بأول شريحة عرض:

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

إذا قمت أولاً بنشر الإعدادات من قالب الملاحظات ثم غيرت شريحة ملاحظات فردية، فإن الإعدادات الخاصة بالشرائح الفردية تسمح لك بتخصيص تلك الصفحة بشكل مستقل.

## **تعيين الرؤوس والتذييلات في قالب النشرة**

تستخدم صفحات النشرة قالب النشرة لرؤوسها، تذييلها، تاريخ/وقت، ورقم الصفحة. على عكس صفحات الملاحظات، تُدار إعدادات النشرة عبر قالب النشرة وليس عبر شرائح النشرة الفردية.

استخدم طريقة [`getMasterHandoutSlide`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) للوصول إلى قالب النشرة. إذا لم يكن موجودًا، استدعِ [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) لإنشاء قالب النشرة الافتراضي.

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

اختر مدير الرأس/التذييل الذي يتناسب مع النطاق الذي تريد تغييره:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islideheaderfootermanager/) يغيّر إعدادات التذييل، التاريخ/الوقت، ورقم الشريحة لشريحة عادية واحدة.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/) يتحكم في شريحة تخطيط ويمكنه نشر الإعدادات المدعومة إلى الشرائح التابعة.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) يتحكم في قالب شريحة عرض عادي ويمكنه نشر الإعدادات المدعومة إلى الشرائح التابعة.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) يتحكم في قالب الملاحظات ويمكنه نشر الإعدادات إلى جميع الشرائح التابعة.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) يغيّر شريحة ملاحظات واحدة ويدعم نائِب رأس بالإضافة إلى التذييل، التاريخ/الوقت، ورقم الشريحة.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) يغيّر قالب النشرة ويدعم جميع أنواع النوابئ الأربعة.

استخدم النشر من قالب أو تخطيط عندما يجب أن يُطبق الإعداد نفسه عبر كامل الهيكل. استخدم مدير شريحة فردية أو شريحة ملاحظات عندما تحتاج إلى إعداد محلي لصفحة واحدة.

## **الأسئلة المتكررة**

**هل يمكنني إضافة رأس إلى شريحة عادية؟**

لا. لا يعرف PowerPoint نائِب رأس للشرائح العادية. في الشرائح العادية، استخدم نواِب التذييل، التاريخ/الوقت، ورقم الشريحة. نواِب الرأس متوفرة في صفحات الملاحظات والنشرات.

**ماذا إذا لم يكن نائِب التذييل أو التاريخ/الوقت أو رقم الشريحة مرئيًا؟**

استخدم مدير الرأس/التذييل المقابل للتحقق من رؤيته وتمكينه عند الحاجة. على سبيل المثال، [`isFooterVisible`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) يوضح ما إذا كان نائِب التذييل موجودًا، و[`setFooterVisibility`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) يغيّر رؤيته.

**كيف أبدأ ترقيم الشرائح من قيمة غير 1؟**

استدعِ طريقة [`setFirstSlideNumber`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) في العرض التقديمي. ثم تستخدم نواِب رقم الشريحة تسلسل الترقيم المحدث.

**ماذا يحدث للرؤوس والتذييلات عند التصدير إلى PDF أو صور أو HTML؟**

العناصر المرئية للرأس والتذييل تُرسم مع باقي محتوى العرض في صيغة الإخراج. مظهرها يعتمد على نوع الصفحة التي يتم تصديرها وإعدادات رؤية النائب المقابلة.