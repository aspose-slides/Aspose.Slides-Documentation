---
title: إدارة أدلة الرسم في العروض التقديمية في .NET
linktitle: أدلة الرسم
type: docs
weight: 85
url: /ar/net/drawing-guides/
keywords:
- دليل رسم
- دليل أفقي
- دليل عمودي
- دليل محاذاة
- عرض شريحة
- شريحة رئيسية
- شريحة تخطيط
- قالب ملاحظات
- قالب نسخة ملاحظات
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إضافة، الوصول، ومسح أدلة الرسم الأفقية والعمودية في عروض PowerPoint باستخدام Aspose.Slides ل .NET."
---
## **نظرة عامة**

دلالات الرسم هي خطوط أفقية وعمودية قابلة للتعديل تساعد المستخدمين على محاذاة الأشكال بشكل ثابت أثناء تحرير عرض تقديمي في PowerPoint. تكون مفيدة بشكل خاص عندما يقوم تطبيق بإنشاء عرض تقديمي سيُنقّح يدوياً لاحقاً: يمكن للتطبيق حفظ أدوات المحاذاة نفسها التي يجب على المؤلفين اتباعها عند إضافة أو نقل المحتوى.

دلالات الرسم هي أدوات تحرير، ليست محتوىً للشرائح. لا تظهر في عرض الشرائح أو في المخرجات المرسومة. يتيح Aspose.Slides for .NET الوصول إليها عبر واجهة [IDrawingGuidesCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/idrawingguidescollection/) . تمثّل [IDrawingGuide](https://reference.aspose.com/slides/ar/net/aspose.slides/idrawingguide/) دليلًا وله اتجاه وموقع ولون.

الموقع يُقاس بالنقاط من الزاوية العليا اليسرى للشفرة أو القالب المناسب. يستخدم الدليل العمودي إحداثيًا أفقيًا، عادةً بين الصفر وعرض الشريحة. يستخدم الدليل الأفقي إحداثيًا عموديًا، عادةً بين الصفر وارتفاع الشريحة.

## **إضافة أدلة إلى عرض الشريحة**

استخدم [ICommonSlideViewProperties.DrawingGuides](https://reference.aspose.com/slides/ar/net/aspose.slides/icommonslideviewproperties/drawingguides/) لإدارة الأدلة المعروضة أثناء تحرير الشرائح العادية. استدعِ [IDrawingGuidesCollection.Add](https://reference.aspose.com/slides/ar/net/aspose.slides/idrawingguidescollection/add/) مع قيمة [Orientation](https://reference.aspose.com/slides/ar/net/aspose.slides/orientation/) وموقع بالنقاط.

المثال التالي يضيف دليلًا عموديًا واحدًا إلى يمين مركز الشريحة ودليلًا أفقيًا واحدًا تحته:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

guides.Add(Orientation.Vertical, slideSize.Width / 2 + 12.5f);
guides.Add(Orientation.Horizontal, slideSize.Height / 2 + 12.5f);

presentation.Save("drawing-guides.pptx", SaveFormat.Pptx);
```

## **الوصول إلى دلالات الرسم**

توفر خاصية [IDrawingGuidesCollection.Count](https://reference.aspose.com/slides/ar/net/aspose.slides/idrawingguidescollection/count/) والفهرس الوصول إلى الأدلة الموجودة. يمكن قراءة أو تعديل خصائص [IDrawingGuide.Orientation](https://reference.aspose.com/slides/ar/net/aspose.slides/idrawingguide/orientation/)، [IDrawingGuide.Position](https://reference.aspose.com/slides/ar/net/aspose.slides/idrawingguide/position/)، و[IDrawingGuide.Color](https://reference.aspose.com/slides/ar/net/aspose.slides/idrawingguide/color/) .

المثال التالي يقرأ أدلة عرض الشرائح من العرض التقديمي الذي تم إنشاؤه أعلاه:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("drawing-guides.pptx");

var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

for (var index = 0; index < guides.Count; index++)
{
    var guide = guides[index];
    Console.WriteLine($"Guide {index}: orientation = {guide.Orientation}, position = {guide.Position}, color = {guide.Color}");
}
```

## **إضافة أدلة إلى القوالب والشريحة التخطيطية**

يمكن للقالب الرئيسي ولكل من شرائحه التخطيطية أن يمتلك مجموعات دلالات رسم خاصة به. استخدم [IMasterSlide.DrawingGuides](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslide/drawingguides/) للقالب الرئيسي و[ILayoutSlide.DrawingGuides](https://reference.aspose.com/slides/ar/net/aspose.slides/ilayoutslide/drawingguides/) لشريحة التخطيط.

المثال التالي يضيف دليلًا عموديًا إلى أول قالب رئيسي ودليلًا أفقيًا إلى أول شريحة تخطيط:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var masterGuides = presentation.Masters[0].DrawingGuides;
var layoutGuides = presentation.LayoutSlides[0].DrawingGuides;

masterGuides.Add(Orientation.Vertical, slideSize.Width / 2 - 20f);
layoutGuides.Add(Orientation.Horizontal, slideSize.Height / 2 + 20f);

presentation.Save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **إضافة أدلة إلى ملاحظات الماستر ونسخ الملاحظات**

تدعم ملاحظات الماستر ونسخ الملاحظات أيضًا دلالات الرسم. استخدم [IMasterNotesSlide.DrawingGuides](https://reference.aspose.com/slides/ar/net/aspose.slides/imasternotesslide/drawingguides/) و[IMasterHandoutSlide.DrawingGuides](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterhandoutslide/drawingguides/) للوصول إلى مجموعاتهم. إذا لم يحتوي العرض التقديمي على أحد هذه القوالب، فإن [IMasterNotesSlideManager.SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) أو [IMasterHandoutSlideManager.SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) ينشئ القالب الافتراضي ويعيده.

المثال التالي يضيف دليلًا أفقيًا إلى قالب ملاحظات ودليلًا عموديًا إلى قالب نسخة الملاحظات:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var notesSize = presentation.NotesSize.Size;
var notesMaster = presentation.MasterNotesSlideManager.SetDefaultMasterNotesSlide();
var handoutMaster = presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();

notesMaster.DrawingGuides.Add(Orientation.Horizontal, notesSize.Height / 2 + 50f);
handoutMaster.DrawingGuides.Add(Orientation.Vertical, notesSize.Width / 2 - 50f);

presentation.Save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **مسح دلالات الرسم**

استدعِ [IDrawingGuidesCollection.Clear](https://reference.aspose.com/slides/ar/net/aspose.slides/idrawingguidescollection/clear/) لإزالة كل دليل من مجموعة معينة. مسح مجموعة واحدة لا يؤثر على الأدلة المخزنة في نطاق آخر.

المثال التالي يمسح أدلة عرض الشرائح وكل الأدلة على القوالب الرئيسية، شرائح التخطيط، قالب الملاحظات، وقالب نسخة الملاحظات دون إنشاء قوالب مفقودة:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation-with-guides.pptx");

presentation.ViewProperties.SlideViewProperties.DrawingGuides.Clear();

foreach (var masterSlide in presentation.Masters)
{
    masterSlide.DrawingGuides.Clear();
}

foreach (var layoutSlide in presentation.LayoutSlides)
{
    layoutSlide.DrawingGuides.Clear();
}

var notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;
if (notesMaster != null)
{
    notesMaster.DrawingGuides.Clear();
}

var handoutMaster = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
if (handoutMaster != null)
{
    handoutMaster.DrawingGuides.Clear();
}

presentation.Save("presentation-without-guides.pptx", SaveFormat.Pptx);
```

## **الأسئلة الشائعة**

**هل تظهر دلالات الرسم في عرض الشرائح أو الصور المصدرة؟**

لا. دلالات الرسم هي أدوات محاذاة للتحرير ولا يتم عرضها كمحتوى للعرض.

**هل يمكن إضافة دليل رسم مباشرة إلى شريحة عادية منفردة؟**

تُخزن أدلة تحرير الشرائح العادية في خصائص عرض الشرائح للعرض التقديمي. تتوفر مجموعات أدلة منفصلة للقوالب الرئيسية، شرائح التخطيط، ملاحظات الماستر، ونسخ الملاحظات.

**ما هي الوحدات المستخدمة لمواقع الأدلة؟**

يتم تحديد المواقع بالنقاط، حيث أن 72 نقطة تساوي بوصة واحدة. تُقاس المواقع الرأسية من الحافة اليسرى، وتُقاس المواقع الأفقية من الحافة العلوية.

**هل يؤدي مسح دلالات الرسم إلى إزالة الأشكال أو تغيير محتوى الشريحة؟**

لا. طريقة `Clear` تزيل فقط الأدلة في المجموعة المحددة. تبقى الأشكال ومحتوى الشريحة دون تغيير.