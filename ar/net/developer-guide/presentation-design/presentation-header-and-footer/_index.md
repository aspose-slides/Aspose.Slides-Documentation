---
title: إدارة رؤوس وتذييلات العرض التقديمي في .NET
linktitle: رأس وتذييل
type: docs
weight: 140
url: /ar/net/presentation-header-and-footer/
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
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إدارة عناصر النافذة النائبة للتذييل، التاريخ/الوقت، رقم الشريحة، والرأس على الشرائح، صفحات الملاحظات، والنشرات باستخدام Aspose.Slides لـ .NET."
---
## **نظرة عامة**

يستخدم PowerPoint عناصر نائب مختلفة للرأس والتذييل حسب نوع الصفحة. يتيح Aspose.Slides for .NET التحكم في النص ورؤية هذه العناصر النائبة من خلال واجهات مدير الرأس/التذييل.

العناصر النائبة المتاحة تعتمد على النطاق:

| النطاق | الرأس | التذييل | التاريخ/الوقت | رقم الشريحة/الصفحة |
|---|---|---|---|---|
| شريحة عادية | لا | نعم | نعم | نعم |
| قالب الملاحظات | نعم | نعم | نعم | نعم |
| شريحة ملاحظات | نعم | نعم | نعم | نعم |
| قالب النشرة | نعم | نعم | نعم | نعم |

لا تحتوي الشريحة العادية في العرض التقديمي على عنصر نائب للرأس. تتوفر رؤوس الصفحات في صفحات الملاحظات والنشرات. بالنسبة للشرائح العادية، استخدم عناصر نائب التذييل، التاريخ/الوقت، ورقم الشريحة بدلاً من ذلك.

يعتمد نطاق التغيير على المدير الذي تستخدمه. تتحكم الواجهة [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/net/aspose.slides/islideheaderfootermanager/) في شريحة عادية واحدة. تتحكم الواجهة [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/net/aspose.slides/inotesslideheaderfootermanager/) في شريحة ملاحظات واحدة. يمكن لمديري القالب والتخطيط أيضاً نقل الإعدادات إلى الشرائح التابعة، بينما تتحكم الواجهة [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterhandoutslideheaderfootermanager/) في قالب النشرة.

## **تعيين التذييل، التاريخ/الوقت، وأرقام الشرائح على الشرائح العادية**

بالنسبة للشرائح العادية، فإن سير العمل الأساسي هو الوصول إلى مدير الرأس/التذييل لكل شريحة، تعيين نص التذييل والتاريخ/الوقت، تفعيل العناصر النائبة المطلوبة، وحفظ العرض التقديمي. يتم توليد أرقام الشرائح بواسطة العرض التقديمي، لذا لا تحتاج إلا إلى التحكم في رؤيتها.

استخدم [`SetFooterText`](https://reference.aspose.com/slides/ar/net/aspose.slides/baseslideheaderfootermanager/setfootertext/) و[`SetDateTimeText`](https://reference.aspose.com/slides/ar/net/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) لتعيين النص، واستخدم [`SetFooterVisibility`](https://reference.aspose.com/slides/ar/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/)، [`SetDateTimeVisibility`](https://reference.aspose.com/slides/ar/net/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/)، و[`SetSlideNumberVisibility`](https://reference.aspose.com/slides/ar/net/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) لإظهار العناصر النائبة المقابلة.

المثال التالي من البداية إلى النهاية يطبق نفس التذييل، نص التاريخ/الوقت، ورؤية رقم الشريحة على جميع الشرائح العادية:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    var headerFooterManager = slide.HeaderFooterManager;

    headerFooterManager.SetFooterText("Company Confidential");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
```

إذا كنت بحاجة لتحديث شريحة واحدة فقط، فاتصل بهذه الشريحة مباشرة عبر مجموعة [`Slides`](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/slides/ar/) بدلاً من التكرار عبر المجموعة بأكملها.

## **تعيين الرؤوس والتذييلات على القالب الرئيسي للملاحظات**

يحدد القالب الرئيسي للملاحظات تنسيقًا شائعًا وسلوك العناصر النائبة لصفحات الملاحظات. استخدم الواجهة [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/net/aspose.slides/imasternotesslideheaderfootermanager/) عندما تريد تغيير القالب الرئيسي للملاحظات نفسه فقط.

المثال التالي يضبط نص الرأس، التذييل، والتاريخ/الوقت على القالب الرئيسي للملاحظات ويجعل جميع العناصر النائبة المدعومة مرئية على هذا القالب:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Notes header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Notes footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
```

خاصية [`MasterNotesSlide`](https://reference.aspose.com/slides/ar/net/aspose.slides/imasternotesslidemanager/masternotesslide/) تُعيد `null` عندما لا يحتوي العرض التقديمي على قالب ملاحظات رئيسي.

## **تطبيق إعدادات القالب الرئيسي للملاحظات على الشرائح التابعة للملاحظات**

يمكن للقالب الرئيسي للملاحظات تطبيق إعدادات الرأس والتذييل على نفسه وعلى جميع الشرائح التابعة للملاحظات. استخدم طرق النقل المخصصة على [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/net/aspose.slides/imasternotesslideheaderfootermanager/) عندما يجب تطبيق نفس الإعدادات عبر هيكل الملاحظات.

على سبيل المثال، [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/ar/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) و[`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/ar/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) يحدثان رأس القالب الرئيسي للملاحظات وجميع رؤوس الفروع. توجد طرق مكافئة للتذييل، التاريخ/الوقت، وأرقام الشرائح.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderAndChildHeadersText("Notes header");
    headerFooterManager.SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Notes footer");
    headerFooterManager.SetFooterAndChildFootersVisibility(true);

    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation.Save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
```

طرق النقل المستخدمة أعلاه هي [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/ar/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/)، [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/ar/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/)، [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/ar/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/)، [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/ar/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/)، و[`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/ar/net/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **تعيين الرؤوس والتذييلات على شريحة ملاحظات فردية**

تنتمي شريحة الملاحظات إلى شريحة عادية محددة. استخدم الواجهة [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/net/aspose.slides/inotesslideheaderfootermanager/) عندما تريد تخصيص تلك الصفحة الملاحظة فقط.

طريقة [`AddNotesSlide`](https://reference.aspose.com/slides/ar/net/aspose.slides/inotesslidemanager/addnotesslide/) تُعيد شريحة الملاحظات للشفرة الحالية وتُنشئ واحدة إذا لم تكن موجودة بالفعل. المثال التالي يكوّن صفحة الملاحظات المرتبطة بأول شريحة في العرض التقديمي:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var notesSlide = presentation.Slides[0].NotesSlideManager.AddNotesSlide();
var headerFooterManager = notesSlide.HeaderFooterManager;

headerFooterManager.SetHeaderText("Header for the first notes page");
headerFooterManager.SetHeaderVisibility(true);

headerFooterManager.SetFooterText("Footer for the first notes page");
headerFooterManager.SetFooterVisibility(true);

headerFooterManager.SetDateTimeText("Date and time text");
headerFooterManager.SetDateTimeVisibility(true);

headerFooterManager.SetSlideNumberVisibility(true);

presentation.Save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
```

إذا قمت أولاً بنقل الإعدادات من القالب الرئيسي للملاحظات ثم غيرت شريحة ملاحظات فردية، فإن إعدادات الشريحة اللاحقة تتيح لك تخصيص صفحة الملاحظات تلك بشكل مستقل.

## **تعيين الرؤوس والتذييلات على القالب الرئيسي للنشرة**

تستخدم صفحات النشرة القالب الرئيسي للنشرة لعناصر الرأس، التذييل، التاريخ/الوقت، وعناصر رقم الصفحة. على عكس صفحات الملاحظات، يتم إدارة إعدادات النشرة عبر القالب الرئيسي للنشرة بدلاً من عبر شرائح النشرة الفردية.

استخدم الخاصية [`MasterHandoutSlide`](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterhandoutslidemanager/masterhandoutslide/) للوصول إلى القالب الرئيسي للنشرة. إذا لم يكن موجودًا، استدعِ [`SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) لإنشاء القالب الرئيسي للنشرة الافتراضي.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;

if (masterHandoutSlide == null)
{
    presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();
    masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
}

if (masterHandoutSlide != null)
{
    var headerFooterManager = masterHandoutSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Handout header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Handout footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
```

## **فهم النطاق والوراثة**

اختر مدير الرأس/التذييل الذي يتطابق مع النطاق الذي تريد تغييره:

- `ISlideHeaderFooterManager` يغيّر إعدادات التذييل، التاريخ/الوقت، ورقم الشريحة لشريحة عادية واحدة.
- `ILayoutSlideHeaderFooterManager` يتحكم في شريحة تخطيط ويمكنه نقل الإعدادات المدعومة إلى الشرائح التابعة.
- `IMasterSlideHeaderFooterManager` يتحكم في قالب شريحة عادية ويمكنه نقل الإعدادات المدعومة إلى الشرائح التابعة.
- `IMasterNotesSlideHeaderFooterManager` يتحكم في القالب الرئيسي للملاحظات ويمكنه نقل الإعدادات إلى جميع الشرائح التابعة للملاحظات.
- `INotesSlideHeaderFooterManager` يغيّر شريحة ملاحظات واحدة ويدعم عنصر نائب للرأس بالإضافة إلى التذييل، التاريخ/الوقت، ورقم الشريحة.
- `IMasterHandoutSlideHeaderFooterManager` يغيّر القالب الرئيسي للنشرة ويدعم جميع الأنواع الأربعة للعناصر النائبة.

استخدم النقل من قالب رئيسي أو تخطيط عندما يجب أن يُطبق الإعداد نفسه عبر كامل هيكله. استخدم مدير شريحة فردية أو شريحة ملاحظات عندما تحتاج إلى إعداد محلي لصفحة واحدة.

## **الأسئلة الشائعة**

**هل يمكنني إضافة رأس إلى شريحة عادية؟**

لا. لا يحدد PowerPoint عنصر نائب للرأس للشرائح العادية. في الشرائح العادية، استخدم عناصر التذييل، التاريخ/الوقت، ورقم الشريحة. تتوفر عناصر الرأس في صفحات الملاحظات والنشرات.

**ماذا إذا لم يكن عنصر التذييل أو التاريخ/الوقت أو رقم الشريحة مرئياً؟**

استخدم مدير الرأس/التذييل المقابل للتحقق من رؤيته وتمكينه عند الحاجة. على سبيل المثال، [`IsFooterVisible`](https://reference.aspose.com/slides/ar/net/aspose.slides/baseslideheaderfootermanager/isfootervisible/) يُبلغ عما إذا كان عنصر التذييل موجودًا، و[`SetFooterVisibility`](https://reference.aspose.com/slides/ar/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) يُغيّر رؤيته.

**كيف يمكنني بدء ترقيم الشرائح من قيمة غير 1؟**

قم بتعيين خاصية العرض التقديمي [`FirstSlideNumber`](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/firstslidenumber/). حينئذٍ تستخدم عناصر رقم الشريحة تسلسلًا عدديًا محدثًا.

**ماذا يحدث للرؤوس والتذييلات عند التصدير إلى PDF أو صور أو HTML؟**

تُرسم عناصر الرأس والتذييل المرئية مع باقي محتوى العرض التقديمي في تنسيق الإخراج. يعتمد مظهرها على نوع الصفحة التي يتم تصديرها وإعدادات رؤية العناصر النائبة المقابلة.