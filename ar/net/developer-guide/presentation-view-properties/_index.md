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
- تثبيت القاطع العمودي
- عرض مفرد
- حالة الشريط
- حجم البُعد
- تعديل تلقائي
- التكبير الافتراضي
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "اكتشف خصائص عرض Aspose.Slides for .NET لتخصيص صيغ PPT و PPTX و ODP — تعديل التخطيطات ومستويات التكبير وإعدادات العرض."
---

{{% alert color="primary" %}} 

يتكون العرض العادي من ثلاث مناطق محتوى: الشريحة نفسها، ومنطقة محتوى جانبية، ومنطقة محتوى سفلية. خصائص تتعلق بتموضع مناطق المحتوى المختلفة. تسمح هذه المعلومات للتطبيق بحفظ حالة العرض في الملف، بحيث يكون العرض عند الفتح مرة أخرى في نفس الحالة التي كان عليها عندما تم حفظ العرض التقديمي آخر مرة.

تمت إضافة الخاصية [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/properties/normalviewproperties) لتوفير الوصول إلى خصائص العرض العادي للعرض التقديمي.  

تمت إضافة الواجهات [INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties), والأنواع التابعة لها، بالإضافة إلى تعداد [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype).

{{% /alert %}}

## **حول INormalViewProperties**

يمثل خصائص العرض العادي.

تحدد الخاصية **ShowOutlineIcons** ما إذا كان يجب على التطبيق عرض أيقونات عند عرض محتوى المخطط في أي من مناطق المحتوى في وضع العرض العادي.

تحدد الخاصية **SnapVerticalSplitter** ما إذا كان يجب أن يثبت القاطع العمودي في حالة مصغرة عندما تكون المنطقة الجانبية صغيرة بما يكفي.

تحدد الخاصية **PreferSingleView** ما إذا كان المستخدم يفضل رؤية منطقة محتوى واحدة بملء النافذة بدلاً من العرض العادي القياسي بثلاث مناطق محتوى. إذا تم تمكينها، قد يختار التطبيق عرض إحدى مناطق المحتوى في النافذة بأكملها.

تحدد الخصائص **VerticalBarState** و **HorizontalBarState** الحالة التي يجب أن يظهر فيها شريط القاطع الأفقي أو الرأسي. يفصل شريط القاطع الأفقي بين الشريحة ومنطقة المحتوى أسفل الشريحة، ويفصل الشريط الرأسي بين الشريحة ومنطقة المحتوى الجانبية. القيم المحتملة هي: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** و **SplitterBarStateType.Restored.**

تحدد الخصائص **RestoredLeft** و **RestoredTop** حجم منطقة الشريحة العلوية أو الجانبية في العرض العادي، عندما يتم تطبيق قيمة **SplitterBarStateType.Restored** على **VerticalBarState** و **HorizontalBarState** وفقًا لذلك.

## **حول استعادة INormalViewProperties**

يحدد حجم منطقة الشريحة (العرض عندما تكون طفلاً لـ RestoredTop، والارتفاع عندما تكون طفلاً لـ RestoredLeft) في العرض العادي، عندما تكون المنطقة ذات حجم مستعاد متغير (ليس مصغرة ولا مكبرة).

تحدد الخاصية **DimensionSize** حجم منطقة الشريحة (العرض عندما تكون طفلاً لـ restoredTop، والارتفاع عندما تكون طفلاً لـ restoredLeft).

تحدد الخاصية **AutoAdjust** ما إذا كان يجب أن يعوض حجم منطقة المحتوى الجانبية الحجم الجديد عند تغيير حجم النافذة التي تحتوي على العرض داخل التطبيق.

يوضح المثال أدناه كيفية الوصول إلى خصائص **ViewProperties.NormalViewProperties** لعرض تقديمي.
```c#
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

يتيح Aspose.Slides for .NET الآن تعيين قيمة التكبير الافتراضية للعرض التقديمي بحيث تكون التكبير محددة مسبقًا عند فتح العرض. يمكن تحقيق ذلك عن طريق تعيين [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) للعرض التقديمي. يمكن أيضًا تعيين خصائص عرض الشريحة وكذلك [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/properties/notesviewproperties) برمجيًا. في هذا الموضوع، سنرى من خلال مثال كيفية تعيين خصائص العرض للعرض التقديمي في Aspose.Slides.

لتعيين خصائص العرض، الرجاء اتباع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)
2. تعيين خصائص العرض [Properties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) للعرض التقديمي
3. حفظ العرض التقديمي كملف PPTX

في المثال أدناه، قمنا بتعيين قيمة التكبير لكل من عرض الشريحة وعرض الملاحظات.
```c#
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // تعيين خصائص العرض للعرض التقديمي
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // قيمة التكبير بالنسبة المئوية لعرض الشريحة
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // قيمة التكبير بالنسبة المئوية لعرض الملاحظات 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة الشائعة**

**هل يمكنني تعيين إعدادات عرض مختلفة لأقسام مختلفة من العرض التقديمي؟**

يتم تعريف [إعدادات العرض](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) على مستوى العرض التقديمي ([العرض العادي](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/normalviewproperties/)/[عرض الشريحة](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/slideviewproperties/))، وليس لكل قسم، لذا تُطبق مجموعة واحدة من المعلمات على المستند بأكمله عند الفتح.

**هل يمكنني تحديد حالات عرض مختلفة مسبقًا لمستخدمين مختلفين؟**

لا. تُخزن الإعدادات في الملف وتُشارك. قد تُراعي تطبيقات العرض تفضيلات المستخدم، لكن الملف نفسه يحتوي على مجموعة واحدة من خصائص العرض.

**هل يمكنني إعداد قالب يحتوي على خصائص عرض محددة مسبقًا بحيث يفتح العروض التقديمية الجديدة بنفس الطريقة؟**

نعم. نظرًا لأن [خصائص العرض](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) تُخزن على مستوى العرض التقديمي، يمكنك تضمينها في قالب وإنشاء مستندات جديدة منه بنفس تكوين العرض الأولي.