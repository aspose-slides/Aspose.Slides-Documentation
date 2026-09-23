---
title: استرجاع وتحديث خصائص عرض العرض التقديمي في .NET
linktitle: خصائص العرض
type: docs
weight: 80
url: /ar/net/presentation-view-properties/
keywords:
- خصائص العرض
- العرض الطبيعي
- محتوى المخطط
- أيقونات المخطط
- تثبيت الفاصل العمودي
- العرض المفرد
- حالة الشريط
- حجم البُعد
- ضبط تلقائي
- تكبير افتراضي
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "اكتشف خصائص العرض في Aspose.Slides for .NET لتخصيص صيغ شرائح PPT و PPTX و ODP — ضبط التخطيطات ومستويات التكبير وإعدادات العرض."
---
## **المقدمة**

يتكون العرض الطبيعي من ثلاث مناطق محتوى: الشريحة نفسها، منطقة محتوى جانبية، ومنطقة محتوى سفلية. الخصائص المتعلقة بموضع المناطق المختلفة للمحتوى. تسمح هذه المعلومات للتطبيق بحفظ حالة العرض في الملف، بحيث يكون العرض في نفس الحالة عند إعادة فتحه كما كان عندما تم حفظ العرض آخر مرة.

تمت إضافة الخاصية [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/iviewproperties/properties/normalviewproperties) لتوفير الوصول إلى خصائص العرض الطبيعي للعرض التقديمي.  

تمت إضافة الواجهات [INormalViewProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/inormalviewproperties)، [INormalViewRestoredProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/inormalviewrestoredproperties) وسلالتها، وتعداد [SplitterBarStateType](https://reference.aspose.com/slides/ar/net/aspose.slides/splitterbarstatetype).

## **حول INormalViewProperties**

يمثل خصائص العرض الطبيعي.

تحدد الخاصية **ShowOutlineIcons** ما إذا كان يجب على التطبيق إظهار الأيقونات عند عرض محتوى المخطط في أي من مناطق المحتوى في وضع العرض الطبيعي.

تحدد الخاصية **SnapVerticalSplitter** ما إذا كان يجب أن ينتقل الفاصل الرأسي إلى حالة مصغرة عندما تكون المنطقة الجانبية صغيرة بما يكفي.

تحدد الخاصية **PreferSingleView** ما إذا كان المستخدم يفضّل رؤية منطقة محتوى واحدة بملء النافذة بدلاً من العرض الطبيعي القياسي بثلاث مناطق محتوى. إذا تم تمكينها، قد يختار التطبيق عرض إحدى مناطق المحتوى في النافذة بالكامل.

تحدد الخصائص **VerticalBarState** و**HorizontalBarState** الحالة التي يجب أن يُظهر فيها شريط الفاصل الرأسي أو الأفقي. شريط الفاصل الأفقي يفصل الشريحة عن منطقة المحتوى أسفل الشريحة، وشريط الفاصل الرأسي يفصل الشريحة عن منطقة المحتوى الجانبية. القيم المحتملة هي: **SplitterBarStateType.Minimized**، **SplitterBarStateType.Maximized** و**SplitterBarStateType.Restored**.

تحدد الخصائص **RestoredLeft** و**RestoredTop** حجم منطقة الشريحة العلوية أو الجانبية في العرض الطبيعي عندما تكون قيمة **SplitterBarStateType.Restored** مُطبقة على **VerticalBarState** و**HorizontalBarState** على التوالي.

## **حول استعادة INormalViewProperties**

تحدد حجم منطقة الشريحة (العرض عندما تكون فرعًا من RestoredTop، الارتفاع عندما تكون فرعًا من RestoredLeft) في العرض الطبيعي، عندما تكون المنطقة بحجم مستعاد متغيّر (ليس مصغّرًا ولا مكبّرًا).

تحدد الخاصية **DimensionSize** حجم منطقة الشريحة (العرض عندما تكون فرعًا من RestoredTop، الارتفاع عندما تكون فرعًا من RestoredLeft).

تحدد الخاصية **AutoAdjust** ما إذا كان يجب على منطقة المحتوى الجانبية التعويض عن الحجم الجديد عند تغيير حجم النافذة التي تحتوي على العرض داخل التطبيق.

يُظهر المثال أدناه كيفية الوصول إلى خصائص **ViewProperties.NormalViewProperties** لعرض تقديمي.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // استعادة خصائص العرض للعرض التقديمي
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **ضبط قيمة التكبير الافتراضية**

يدعم Aspose.Slides for .NET الآن ضبط قيمة التكبير الافتراضية للعرض التقديمي بحيث يتم تعيين التكبير مسبقًا عند فتح العرض. يمكن القيام بذلك عن طريق ضبط [ViewProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/viewproperties) للعرض التقديمي. يمكن ضبط خصائص عرض الشريحة بالإضافة إلى [NotesViewProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/viewproperties/properties/notesviewproperties) برمجيًا. في هذا الموضوع، سنرى من خلال مثال كيف نضبط خصائص العرض للعرض التقديمي في Aspose.Slides.

لضبط خصائص العرض، يرجى اتباع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation)
1. ضبط [Properties](https://reference.aspose.com/slides/ar/net/aspose.slides/viewproperties) للعرض للعرض التقديمي
1. كتابة العرض التقديمي كملف PPTX

في المثال المرفق أدناه، قمنا بضبط قيمة التكبير لعرض الشريحة وعرض الملاحظات.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // ضبط خصائص العرض للعرض التقديمي
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // قيمة التكبير بالنسبة المئوية لعرض الشريحة
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // قيمة التكبير بالنسبة المئوية لعرض الملاحظات 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **ضبط تباعد الشبكة**

استخدم [Presentation.ViewProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/viewproperties/) للوصول إلى إعدادات العرض على مستوى العرض التقديمي. الخاصية [IViewProperties.GridSpacing](https://reference.aspose.com/slides/ar/net/aspose.slides/iviewproperties/gridspacing/) تقرأ أو تغير الفاصل الزمني للشبكة التحريرية الأساسية. يُطبق هذا الإعداد على كامل العرض التقديمي، وليس على شريحة فردية. يُحدد تباعد الشبكة بالنقاط، حيث أن 72 نقطة تساوي بوصة واحدة. استخدم قيمة موجبة كما هو مطلوب في وثائق API.

يفتح المثال التالي ملف `demo.pptx` الموجود، يطبع تباعد الشبكة الحالي، يضبط فاصل ربع بوصة، ويحفظ النتيجة.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");
var gridSpacing = presentation.ViewProperties.GridSpacing;
Console.WriteLine($"Current grid spacing: {gridSpacing} points");

presentation.ViewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

الشبكة تختلف عن [drawing guides](/slides/ar/net/drawing-guides/). يتحكم تباعد الشبكة في فاصل منتظم، بينما الأدلة الرسومية هي خطوط محاذاة أفقية أو رأسية موضوعة بشكل فردي. إضافة أو نقل أو مسح الأدلة الرسومية لا يغيّر تباعد الشبكة.

كل من الشبكة والأدلة الرسومية هي مساعدات تحرير. لا يتم عرضها كمحتوى شريحة في PDF أو صور أو SVG أو عرض شرائح. تخزين تباعد الشبكة لا يضمن أن المحرر سيعرض الشبكة: تعتمد رؤيتها أيضًا على تفضيلات المشاهد أو المحرر.

## **إظهار أو إخفاء التعليقات عند فتح عرض تقديمي**

استخدم [Presentation.ViewProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/viewproperties/) للوصول إلى إعدادات العرض على مستوى العرض التقديمي. اقرأ أو غير [IViewProperties.ShowComments](https://reference.aspose.com/slides/ar/net/aspose.slides/iviewproperties/showcomments/) لتخزين تفضيل ما إذا كان يجب إظهار التعليقات عند فتح العرض التقديمي في PowerPoint أو محرر متوافق آخر.

هذا الإعداد يتحكم فقط في تفضيل العرض المخزن. لا يضيف، لا يزيل، لا يحرّر، ولا يحلّ التعليقات. إخفاء التعليقات يحافظ على محتواها، مؤلفيها، مواقعها، ردودها، وحالاتها. راجع [Presentation Comments](/slides/ar/net/presentation-comments/) للعمليات التي تغير التعليقات نفسها.

المثال التالي يتطلب وجود `comments.pptx` يحتوي على تعليقات. يطبع إعداد الرؤية الحالي، يطلب إخفاء التعليقات، ويحفظ ملف PPTX جديد دون إزالة أي تعليقات. كما يضبط [IViewProperties.LastView](https://reference.aspose.com/slides/ar/net/aspose.slides/iviewproperties/lastview/) إلى [ViewType.SlideView](https://reference.aspose.com/slides/ar/net/aspose.slides/viewtype/) لتكوين طريقة التحرير الأولية جنبًا إلى جنب مع رؤية التعليقات.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");
var showComments = presentation.ViewProperties.ShowComments;
Console.WriteLine($"Current comment visibility: {showComments}");

presentation.ViewProperties.ShowComments = NullableBool.False;
presentation.ViewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

هذا الإعداد لا يحدد ما إذا كانت التعليقات تُضمّن في تصدير PDF أو HTML أو صورة أو ملاحظات أو نشرة. قم بتهيئة الخيارات الخاصة بالتصدير ذات الصلة بشكل منفصل.

## **الأسئلة الشائعة**

**لماذا لا تظهر الشبكة بعد إعادة فتح العرض التقديمي؟**

الملف يخزن تباعد الشبكة، لكن المحرر يتحكم ما إذا كانت الشبكة تُعرض. تحقق من إعدادات رؤية الشبكة في المحرر.

**هل مسح الأدلة الرسومية يغيّر تباعد الشبكة؟**

لا. الأدلة الرسومية وتباعد الشبكة إعدادات مستقلة. مسح الأدلة يترك الفاصل المخزن للشبكة دون تغيير.

**هل يمكن ضبط إعدادات عرض مختلفة لأقسام مختلفة من العرض التقديمي؟**

إعدادات العرض [View settings](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/viewproperties/) تُعرّف على مستوى العرض التقديمي ([Normal View](https://reference.aspose.com/slides/ar/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ar/net/aspose.slides/viewproperties/slideviewproperties/))، وليس لكل قسم، لذا تُطبق مجموعة واحدة من المعاملات على المستند بأكمله عند الفتح.

**هل يمكنني تحديد حالات عرض مختلفة مسبقًا لمستخدمين مختلفين؟**

لا. تُخزن الإعدادات في الملف وتُشارك. قد تُراعي تطبيقات العرض تفضيلات المستخدم، لكن الملف نفسه يحتوي على مجموعة واحدة من خصائص العرض.

**هل يمكنني إعداد قالب بخصائص عرض معرفة مسبقًا بحيث تُفتح العروض الجديدة بنفس الطريقة؟**

نعم. بما أن [view properties](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/viewproperties/) تُخزن على مستوى العرض التقديمي، يمكنك تضمينها في قالب وإنشاء مستندات جديدة منه بنفس تكوين العرض الأولي.