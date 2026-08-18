---
title: إدارة رؤوس وتذييلات العروض التقديمية في JavaScript
linktitle: رأس وتذييل
type: docs
weight: 140
url: /ar/nodejs-java/presentation-header-and-footer/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية إدارة نوافل التذييل, التاريخ-الوقت, رقم الشريحة, والرأس على الشرائح, صفحات الملاحظات, والنشرات باستخدام Aspose.Slides لـ Node.js عبر Java."
---
## **نظرة عامة**

يستخدم PowerPoint نوافل رأس وتذييل مختلفة اعتمادًا على نوع الصفحة. يتيح لك Aspose.Slides لـ Node.js عبر Java التحكم في النص ورؤية هذه النوافل من خلال فئات مدير الرأس/التذييل.

تعتمد النوافل المتاحة على النطاق:

| النطاق | الرأس | التذييل | التاريخ/الوقت | رقم الشريحة/الصفحة |
|---|---|---|---|---|
| شريحة عادية | لا | نعم | نعم | نعم |
| قالب الملاحظات | نعم | نعم | نعم | نعم |
| شريحة ملاحظات | نعم | نعم | نعم | نعم |
| قالب النشرة | نعم | نعم | نعم | نعم |

الشريحة العادية في العرض التقديمي لا تحتوي على نافذة رأس. تتوفر رؤوس الصفحات في صفحات الملاحظات والنشرات. بالنسبة للشرائح العادية، استخدم نوافل التذييل، التاريخ/الوقت، ورقم الشريحة بدلاً منها.

يعتمد نطاق التغيير على المدير الذي تستخدمه. تتحكم فئة [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideheaderfootermanager/) في شريحة عادية واحدة. تتحكم فئة [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/notesslideheaderfootermanager/) في شريحة ملاحظات واحدة. يمكن لمديري القالب وتخطيط الشرائح أيضًا نشر الإعدادات إلى الشرائح التابعة، بينما تتحكم فئة [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) في قالب النشرة.

## **تحديد التذييل، التاريخ/الوقت، وأرقام الشرائح في الشرائح العادية**

بالنسبة للشرائح العادية، سير العمل الأساسي هو الوصول إلى مدير الرأس/التذييل لكل شريحة، تحديد نص التذييل والتاريخ/الوقت، تمكين النوافل المطلوبة، ثم حفظ العرض التقديمي. يتم إنشاء أرقام الشرائح بواسطة العرض التقديمي، لذلك تحتاج فقط إلى التحكم في رؤية هذه الأرقام.

استخدم [`setFooterText`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) و[`setDateTimeText`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) لتحديد النص، واستخدم [`setFooterVisibility`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility)،[`setDateTimeVisibility`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility)،و[`setSlideNumberVisibility`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) لإظهار النوافل المقابلة.

المثال التالي يطبق نفس التذييل، نص التاريخ/الوقت، ورؤية رقم الشريحة على جميع الشرائح العادية:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

إذا كنت تحتاج إلى تحديث شريحة واحدة فقط، فالوصول إلى تلك الشريحة مباشرة عبر طريقة [`getSlides`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/getslides/) بدلاً من التكرار عبر المجموعة بالكامل.

## **تحديد الرؤوس والتذييلات في قالب الملاحظات**

يحدد قالب الملاحظات تنسيقًا مشتركًا وسلوك النوافل لصفحات الملاحظات. استخدم فئة [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) عندما تريد تغيير قالب الملاحظات نفسه فقط.

المثال التالي يحدد نص الرأس، التذييل، والتاريخ/الوقت في قالب الملاحظات ويجعل جميع النوافل المدعومة مرئية في ذلك القالب:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

طريقة [`getMasterNotesSlide`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masternotesslidemanager/#getMasterNotesSlide) تُرجع `null` عندما لا يحتوي العرض التقديمي على قالب ملاحظات.

## **تطبيق إعدادات قالب الملاحظات على شرائح الملاحظات التابعة**

يمكن لقالب الملاحظات تطبيق إعدادات الرأس والتذييل على نفسه وعلى جميع شرائح الملاحظات التابعة. استخدم طرق النشر المخصصة على فئة [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) عندما يجب تطبيق نفس الإعدادات عبر تسلسل الملاحظات.

على سبيل المثال، تقوم الطريقة [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) والطريقة [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) بتحديث رأس قالب الملاحظات وجميع رؤوس الشرائح التابعة. تتوفر طرق مكافئة للتذييلات، التاريخ/الوقت، وأرقام الشرائح.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

طرق النشر المستخدمة أعلاه هي [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText)،[`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility)،[`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText)،[`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility)،و[`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **تحديد الرؤوس والتذييلات في شريحة ملاحظات فردية**

تنتمي شريحة الملاحظات إلى شريحة عادية محددة. استخدم فئة [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/notesslideheaderfootermanager/) عندما تريد تخصيص تلك الصفحة الملاحظة فقط.

طريقة [`addNotesSlide`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/notesslidemanager/#addNotesSlide) تُرجع شريحة الملاحظات للشريحة الحالية وتُنشئ واحدة إذا لم تكن موجودة بالفعل. المثال التالي يكوّن صفحة الملاحظات المرتبطة بأول شريحة في العرض التقديمي:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const headerFooterManager = slide.getNotesSlideManager().addNotesSlide().getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

إذا قمت أولًا بنشر الإعدادات من قالب الملاحظات ثم غيرت شريحة ملاحظات فردية، فإن الإعدادات اللاحقة لكل شريحة تسمح لك بتخصيص تلك الصفحة بشكل مستقل.

## **تحديد الرؤوس والتذييلات في قالب النشرة**

تستخدم صفحات النشرة قالب النشرة لنوافل الرأس، التذييل، التاريخ/الوقت، ورقم الصفحة. على عكس صفحات الملاحظات، تُدار إعدادات النشرة من خلال قالب النشرة وليس من خلال شرائح النشرة الفردية.

استخدم طريقة [`getMasterHandoutSlide`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterhandoutslidemanager/#getMasterHandoutSlide) للوصول إلى قالب النشرة. إذا لم يكن موجودًا، استدعِ طريقة [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterhandoutslidemanager/#setDefaultMasterHandoutSlide) لإنشاء قالب النشرة الافتراضي.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    let masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide === null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide !== null) {
        const headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **فهم النطاق والوراثة**

اختر مدير الرأس/التذييل الذي يتطابق مع النطاق الذي تريد تغييره:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideheaderfootermanager/) يغيّر إعدادات التذييل، التاريخ/الوقت، ورقم الشريحة لشريحة عادية واحدة.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutslideheaderfootermanager/) يتحكم في شريحة تخطيط ويمكنه نشر الإعدادات المدعومة إلى الشرائح التابعة.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslideheaderfootermanager/) يتحكم في قالب شريحة عادية ويمكنه نشر الإعدادات المدعومة إلى الشرائح التابعة.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) يتحكم في قالب الملاحظات ويمكنه نشر الإعدادات إلى جميع شرائح الملاحظات التابعة.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/notesslideheaderfootermanager/) يغيّر شريحة ملاحظات واحدة ويدعم نافذة رأس بالإضافة إلى التذييل، التاريخ/الوقت، ورقم الشريحة.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) يغيّر قالب النشرة ويدعم جميع أنواع النوافل الأربعة.

استخدم النشر من قالب أو تخطيط عندما يجب تطبيق الإعداد نفسه عبر كامل التسلسل الهرمي. استخدم مدير شريحة فردية أو شريحة ملاحظات عندما تحتاج إلى إعداد محلي لصفحة واحدة.

## **الأسئلة المتكررة**

**هل يمكنني إضافة رأس إلى شريحة عادية؟**

لا. لا يعرف PowerPoint نافذة رأس للشرائح العادية. في الشرائح العادية، استخدم نوافل التذييل، التاريخ/الوقت، ورقم الشريحة. تتوفر نوافل الرأس في صفحات الملاحظات والنشرات.

**ماذا لو لم يكن نافذة التذييل أو التاريخ/الوقت أو رقم الشريحة مرئية؟**

استخدم مدير الرأس/التذييل المقابل للتحقق من رؤيته وتمكينه عند الحاجة. على سبيل المثال، طريقة [`isFooterVisible`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) تُبلغ ما إذا كان نافذة التذييل موجودة، وطريقة [`setFooterVisibility`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) تُغيّر رؤيته.

**كيف أبدأ ترقيم الشرائح من قيمة غير 1؟**

استدعِ طريقة [`setFirstSlideNumber`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) في العرض التقديمي. ثم ستستخدم نوافل رقم الشريحة سلسلة ترقيم محدثة.

**ماذا يحدث للرؤوس والتذييلات عند التصدير إلى PDF أو صور أو HTML؟**

يتم عرض عناصر الرأس والتذييل المرئية مع باقي محتوى العرض التقديمي في صيغة الإخراج. تعتمد مظهرها على نوع الصفحة التي يتم تصديرها وإعدادات رؤية النوافل المقابلة.