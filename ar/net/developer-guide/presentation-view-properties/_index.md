---
title: استرجاع وتحديث خصائص عرض العرض التقديمي في .NET
linktitle: خصائص العرض
type: docs
weight: 80
url: /ar/net/presentation-view-properties/
keywords:
- خصائص العرض
- العرض العادي
- محتوى المخطط
- أيقونات المخطط
- تثبيت المقسم العمودي
- العرض الفردي
- حالة الشريط
- حجم البُعد
- تعديل تلقائي
- تكبير افتراضي
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "اكتشف خصائص عرض Aspose.Slides لـ .NET لتخصيص صيغ شرائح PPT، PPTX، وODP—ضبط التخطيطات ومستويات التكبير وإعدادات العرض."
---
## **مقدمة**

العرض العادي يتكون من ثلاث مناطق محتوى: الشريحة نفسها، منطقة محتوى جانبية، ومنطقة محتوى سفلية. الخصائص المتعلقة بموضع المناطق المختلفة للمحتوى. هذه المعلومات تسمح للتطبيق بحفظ حالة العرض إلى الملف، بحيث عند إعادة الفتح يكون العرض في نفس الحالة التي كان عليها عندما تم حفظ العرض آخر مرة.

تمت إضافة الخاصية [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/iviewproperties/properties/normalviewproperties) لتوفير الوصول إلى خصائص العرض العادي للعرض التقديمي.  

تمت إضافة الواجهات [INormalViewProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/inormalviewproperties)، [INormalViewRestoredProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/inormalviewrestoredproperties) وكذلك سابقتها، وتعداد [SplitterBarStateType](https://reference.aspose.com/slides/ar/net/aspose.slides/splitterbarstatetype).

## **حول INormalViewProperties**

يمثل خصائص العرض العادي.

الخاصية **ShowOutlineIcons** تحدد ما إذا كان يجب على التطبيق إظهار الأيقونات عند عرض محتوى المخطط التفصيلي في أي من مناطق المحتوى في وضع العرض العادي.

الخاصية **SnapVerticalSplitter** تحدد ما إذا كان يجب أن ينكمش المقسم العمودي إلى حالة مصغرة عندما تكون المنطقة الجانبية صغيرة بما يكفي.

الخاصية **PreferSingleView** تحدد ما إذا كان المستخدم يفضل رؤية منطقة محتوى واحدة تملأ النافذة بالكامل بدلاً من العرض العادي القياسي بثلاث مناطق محتوى. إذا تم تفعيلها، قد يختار التطبيق عرض إحدى مناطق المحتوى في كامل النافذة.

الخاصيتان **VerticalBarState** و **HorizontalBarState** تحددان الحالة التي يجب أن يظهر فيها شريط المقسم الأفقي أو العمودي. شريط المقسم الأفقي يفصل الشريحة عن منطقة المحتوى أسفل الشريحة، وشريط المقسم العمودي يفصل الشريحة عن المنطقة الجانبية. القيم الممكنة هي: **SplitterBarStateType.Minimized**، **SplitterBarStateType.Maximized** و **SplitterBarStateType.Restored**.

الخاصيتان **RestoredLeft** و **RestoredTop** تحددان حجم المنطقة العلوية أو الجانبية للشريحة في العرض العادي عندما تُطبق القيمة **SplitterBarStateType.Restored** على **VerticalBarState** و **HorizontalBarState** وفقًا لذلك.

## **حول استعادة INormalViewProperties**

تحدد حجم منطقة الشريحة (العرض عندما تكون فرعًا من RestoredTop، الارتفاع عندما تكون فرعًا من RestoredLeft) في العرض العادي، عندما تكون المنطقة بحجم مستعادة متغير (ليس مصغرة ولا موسعة).

الخاصية **DimensionSize** تحدد حجم منطقة الشريحة (العرض عندما تكون فرعًا من RestoredTop، الارتفاع عندما تكون فرعًا من RestoredLeft).

الخاصية **AutoAdjust** تحدد ما إذا كان يجب على منطقة المحتوى الجانبية تعويض الحجم الجديد عند تغيير حجم النافذة التي تحتوي على العرض داخل التطبيق.

في المثال أدناه يوضح كيفية الوصول إلى خصائص **ViewProperties.NormalViewProperties** لعرض تقديمي.

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

## **تعيين قيمة التكبير الافتراضية**

أصبحت Aspose.Slides for .NET تدعم الآن تعيين قيمة التكبير الافتراضية للعرض التقديمي بحيث يتم تعيين التكبير بالفعل عند فتح العرض. يمكن تحقيق ذلك بتعيين [ViewProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/viewproperties) للعرض التقديمي. يمكن تعيين خصائص عرض الشريحة وكذلك [NotesViewProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/viewproperties/properties/notesviewproperties) برمجيًا. في هذا الموضوع، سنوضح من خلال مثال كيفية تعيين خصائص العرض للعرض التقديمي في Aspose.Slides.

لتعيين خصائص العرض، يرجى اتباع الخطوات التالية:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation)
1. تعيين [Properties](https://reference.aspose.com/slides/ar/net/aspose.slides/viewproperties) للعرض التقديمي
1. كتابة العرض التقديمي كملف PPTX

في المثال المقدم أدناه، قمنا بتعيين قيمة التكبير لكل من عرض الشريحة وعرض الملاحظات.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // تعيين خصائص العرض للعرض التقديمي
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // قيمة التكبير بالنسبة المئوية لعرض الشريحة
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // قيمة التكبير بالنسبة المئوية لعرض الملاحظات 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **تعيين تباعد الشبكة**

استخدم [Presentation.ViewProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/viewproperties/) للوصول إلى إعدادات العرض على مستوى العرض التقديمي. الخاصية [IViewProperties.GridSpacing](https://reference.aspose.com/slides/ar/net/aspose.slides/iviewproperties/gridspacing/) تقرأ أو تغير فاصلة الشبكة التحريرية الأساسية. ينطبق هذا الإعداد على العرض التقديمي بأكمله، لا على شريحة منفردة. يتم تحديد تباعد الشبكة بالنقاط، حيث يساوي 72 نقطة بوصة واحدة. استخدم قيمة موجبة كما هو مطلوب في وثائق API.

المثال التالي يفتح ملف `demo.pptx` الموجود، يطبع تباعد الشبكة الحالي، يضبط فاصلة ربع بوصة، ثم يحفظ النتيجة.

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

الشبكة تختلف عن [drawing guides](/slides/ar/net/drawing-guides/). تباعد الشبكة يتحكم في فواصل منتظمة، بينما الأدلة الرسمية هي خطوط محاذاة أفقية أو عمودية يتم موضعها بشكل فردي. إضافة أو نقل أو مسح الأدلة لا يغير تباعد الشبكة.

كلا من الشبكة والأدلة هي مساعدات تحرير. لا يتم عرضها كجزء من محتوى الشريحة في ملفات PDF أو الصور أو SVG أو عرض الشرائح. تخزين تباعد الشبكة لا يضمن أن محررًا سيعرض الشبكة: يعتمد ظهورها أيضًا على تفضيلات المشاهد أو المحرر.

## **الأسئلة المتكررة**

**لماذا لا تكون الشبكة مرئية بعد إعادة فتح العرض التقديمي؟**

يقوم الملف بتخزين تباعد الشبكة، لكن المحرر يتحكم في ما إذا كانت الشبكة تُعرض. تحقق من إعدادات رؤية الشبكة في المحرر.

**هل مسح الأدلة الرسمية يغير تباعد الشبكة؟**

لا. الأدلة الرسمية وتباعد الشبكة إعدادات مستقلة. مسح الأدلة يترك فترة الشبكة المخزنة دون تغيير.

**هل يمكنني تعيين إعدادات عرض مختلفة لأقسام مختلفة من العرض التقديمي؟**

يتم تعريف [إعدادات العرض](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/viewproperties/) على مستوى العرض التقديمي ([Normal View](https://reference.aspose.com/slides/ar/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ar/net/aspose.slides/viewproperties/slideviewproperties/))، وليس لكل قسم على حدة، لذا مجموعة واحدة من المعلمات تنطبق على المستند بأكمله عند الفتح.

**هل يمكنني تحديد حالات عرض مختلفة لمستخدمين مختلفين مسبقًا؟**

لا. تُخزن الإعدادات في الملف وتُشارك. قد تحترم تطبيقات المشاهدة تفضيلات المستخدم، لكن الملف نفسه يحتوي على مجموعة واحدة من خصائص العرض.

**هل يمكنني إعداد قالب مع خصائص عرض مسبقة التحديد بحيث يفتح العروض الجديدة بنفس الطريقة؟**

نعم. نظرًا لأن [خصائص العرض](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/viewproperties/) تُخزن على مستوى العرض التقديمي، يمكنك تضمينها في قالب وإنشاء مستندات جديدة منه بنفس تكوين العرض الأولي.