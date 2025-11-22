---
title: خصائص عرض العرض التقديمي
type: docs
weight: 80
url: /ar/net/presentation-view-properties/
keywords:
- خصائص العرض
- العرض العادي
- محتوى المخطط
- أيقونات المخطط
- تثبيت الفاصل العمودي
- عرض فردي
- حالة الشريط
- حجم البُعد
- تلقائي الضبط
- التكبير الافتراضي
- PowerPoint
- عرض تقديمي
- C#
- Csharp
- Aspose.Slides for .NET
description: "إدارة خصائص عرض العروض التقديمية في PowerPoint باستخدام C# أو .NET"
---

{{% alert color="primary" %}} 

العرض العادي يتكون من ثلاث مناطق محتوى: الشريحة نفسها، منطقة محتوى جانبية، ومنطقة محتوى سفلية. الخصائص المتعلقة بموضع المناطق المختلفة تسمح للتطبيق بحفظ حالة العرض إلى الملف، بحيث عند إعادة الفتح تكون الحالة نفسها كما كانت عند آخر حفظ للعرض التقديمي.

الخاصية [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/properties/normalviewproperties) تم إضافتها لتوفير وصول إلى خصائص العرض العادي للعرض التقديمي.  

[INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties)، [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties) الواجهات وأبناءها، [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype) التعداد تم إضافتهم.  

{{% /alert %}}

## **حول INormalViewProperties**

تمثل خصائص العرض العادي.

الخاصية **ShowOutlineIcons** تحدد ما إذا كان يجب على التطبيق إظهار أيقونات عند عرض محتوى المخطط التفصيلي في أي من مناطق المحتوى في وضع العرض العادي.

الخاصية **SnapVerticalSplitter** تحدد ما إذا كان يجب على الفاصل الرأسي الانتقال إلى حالة مصغرة عندما تكون المنطقة الجانبية صغيرة بما يكفي.

الخاصية **PreferSingleView** تحدد ما إذا كان المستخدم يفضل رؤية منطقة محتوى واحدة تمتد عبر نافذة كاملة بدلاً من وضع العرض العادي القياسي الذي يحتوي على ثلاث مناطق محتوى. إذا تمكينها، قد يختار التطبيق عرض إحدى مناطق المحتوى في النافذة بالكامل.

الخصائص **VerticalBarState** و **HorizontalBarState** تحدد الحالة التي يجب أن يُظهر فيها شريط الفاصل الأفقي أو الرأسي. الشريط الأفقي يفصل الشريحة عن منطقة المحتوى أسفل الشريحة، والشريط الرأسي يفصل الشريحة عن منطقة المحتوى الجانبية. القيم الممكنة هي: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** و **SplitterBarStateType.Restored**.

الخصائص **RestoredLeft** و **RestoredTop** تحدد حجم منطقة الشريحة العلوية أو الجانبية في العرض العادي عندما تكون القيمة **SplitterBarStateType.Restored** مطبقة على **VerticalBarState** و **HorizontalBarState** على التوالي.

## **حول استعادة INormalViewProperties** 

تحدد حجم منطقة الشريحة (العرض عندما تكون فرعًا من **RestoredTop**، الارتفاع عندما تكون فرعًا من **RestoredLeft**) في العرض العادي، عندما تكون المنطقة بحجم مستعاد متغير (ليس مصغرًا ولا مكبرًا).  

الخاصية **DimensionSize** تحدد حجم منطقة الشريحة (العرض عندما تكون فرعًا من **RestoredTop**، الارتفاع عندما تكون فرعًا من **RestoredLeft**).  

الخاصية **AutoAdjust** تحدد ما إذا كان يجب على حجم منطقة المحتوى الجانبية التعويض عن الحجم الجديد عند تغيير حجم النافذة التي تحتوي على العرض داخل التطبيق.  

يوضح المثال أدناه كيفية الوصول إلى خصائص **ViewProperties.NormalViewProperties** لعروض تقديمية.  
```c#
using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // استعادة خصائص عرض العرض التقديمي
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```


## **تحديد قيمة التكبير الافتراضية**

أصبح Aspose.Slides for .NET يدعم الآن تعيين قيمة التكبير الافتراضية للعرض التقديمي بحيث يتم ضبط التكبير تلقائيًا عند فتح العرض. يمكن القيام بذلك عن طريق تعيين [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) للعرض التقديمي. يمكن تعيين خصائص عرض الشريحة وكذلك [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/properties/notesviewproperties) برمجيًا. في هذا الموضوع، سنرى من خلال مثال كيفية تعيين خصائص العرض للعرض التقديمي في Aspose.Slides.

لضبط خصائص العرض، يرجى اتباع الخطوات التالية:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).  
1. تعيين [Properties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) العرض للعرض التقديمي.  
1. حفظ العرض التقديمي كملف PPTX.  

في المثال الموضح أدناه، قمنا بتعيين قيمة التكبير لكل من عرض الشريحة وعرض الملاحظات.  
```c#
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // تعيين خصائص العرض للعرض التقديمي
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // قيمة التكبير بالنسبة المئوية لعرض الشريحة
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // قيمة التكبير بالنسبة المئوية لعرض الملاحظات 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة المتكررة**

**هل يمكنني تعيين إعدادات عرض مختلفة لأقسام مختلفة من العرض التقديمي؟**  

يتم تعريف [إعدادات العرض](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) على مستوى العرض التقديمي ([Normal View](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/slideviewproperties/))، وليس لكل قسم. لذلك يتم تطبيق مجموعة واحدة من المعلمات على المستند بأكمله عند الفتح.  

**هل يمكنني تحديد حالات عرض مختلفة لمستخدمين مختلفين مسبقًا؟**  

لا. يتم تخزين الإعدادات في الملف وتُشَارَك. قد تحترم تطبيقات العرض تفضيلات المستخدم، ولكن الملف نفسه يحتوي على مجموعة واحدة من خصائص العرض.  

**هل يمكنني إعداد قالب يحتوي على خصائص عرض معرفة مسبقًا بحيث يفتح العروض التقديمية الجديدة بنفس الطريقة؟**  

نعم. نظرًا لأن [خصائص العرض](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) تُخزن على مستوى العرض التقديمي، يمكنك تضمينها في قالب وإنشاء مستندات جديدة منه بنفس تكوين العرض الأولي.  