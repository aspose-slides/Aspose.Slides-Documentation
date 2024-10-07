---
title: خصائص عرض العروض التقديمية
type: docs
url: /net/presentation-view-properties/
keywords: "عارض PowerPoint، خصائص العارض، عرض PowerPoint، C#، Csharp، Aspose.Slides لـ .NET"
description: "خصائص عارض العروض التقديمية في C# أو .NET"
---

{{% alert color="primary" %}} 

يتكون العرض العادي من ثلاث مناطق محتوى: الشريحة نفسها، منطقة محتوى جانبية، ومنطقة محتوى سفلية. الخصائص المتعلقة بتحديد مواقع مناطق المحتوى المختلفة. هذه المعلومات تجعل التطبيق قادرًا على حفظ حالة العرض إلى الملف، بحيث عند إعادة الفتح يكون العرض في نفس الحالة كما كان عند آخر حفظ للعرض التقديمي.

تم إضافة خاصية [**IViewProperties.NormalViewProperties**](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/properties/normalviewproperties) لتوفير الوصول إلى خصائص العرض العادي للعرض التقديمي. 

تمت إضافة الواجهتين [**INormalViewProperties**](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties) و [**INormalViewRestoredProperties**](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties) وورثتها، بالإضافة إلى التعداد [**SplitterBarStateType**](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype).

{{% /alert %}} 



## **حول INormalViewProperties** #

تمثل خصائص العرض العادي.

تحدد خاصية **ShowOutlineIcons** ما إذا كان يجب على التطبيق عرض أيقونات عند عرض محتوى المخطط في أي من مناطق المحتوى في وضع العرض العادي.

تحدد خاصية **SnapVerticalSplitter** ما إذا كان يجب أن يتم تثبيت الفاصل العمودي في حالة مصغرة عندما تكون المنطقة الجانبية صغيرة بما فيه الكفاية.

تحدد خاصية **PreferSingleView** ما إذا كان يفضل المستخدم رؤية منطقة محتوى واحدة بملء الشاشة بدلاً من العرض العادي القياسي مع ثلاث مناطق محتوى. إذا تم تفعيلها، قد يختار التطبيق عرض واحدة من مناطق المحتوى في النافذة الكاملة.

تحدد الخصائص **VerticalBarState** و **HorizontalBarState** الحالة التي يجب عرض شريط الفاصل الأفقي أو العمودي بها. يفصل شريط الفاصل الأفقي الشريحة عن منطقة المحتوى تحت الشريحة، بينما يفصل شريط الفاصل العمودي الشريحة عن المنطقة الجانبية. القيم الممكنة هي: **SplitterBarStateType.Minimized، SplitterBarStateType.Maximized** و **SplitterBarStateType.Restored.**

تحدد الخصائص **RestoredLeft** و **RestoredTop** حجم منطقة الشريحة العلوية أو الجانبية في العرض العادي، عند تطبيق قيمة **SplitterBarStateType.Restored** لـ **VerticalBarState** و **HorizontalBarState** وفقًا لذلك.



## **حول INormalViewRestoredProperties** #

تحدد حجم منطقة الشريحة (العرض عند كونها طفلاً لـ RestoredTop، الارتفاع عند كونها طفلاً لـ RestoredLeft) في العرض العادي، عندما تكون المنطقة بحجم مستعاد متغير (لا مصغر ولا محسّن).

تحدد خاصية **DimensionSize** حجم منطقة الشريحة (العرض عند كونها طفلاً لـ restoredTop، الارتفاع عند كونها طفلاً لـ restoredLeft).

تحدد خاصية **AutoAdjust** ما إذا كان يجب أن تعوض حجم منطقة المحتوى الجانبية عن الحجم الجديد عند إعادة حجم النافذة التي تحتوي على العرض ضمن التطبيق.

يتم إعطاء مثال أدناه يوضح كيفية الوصول إلى خصائص **ViewProperties.NormalViewProperties** لعرض تقديمي.

```c#
//Instantiate a presentation object that represents a presentation file
using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```




## **تعيين قيمة التكبير الافتراضية**
يدعم Aspose.Slides لـ .NET الآن تعيين القيمة الافتراضية للتكبير للعرض التقديمي بحيث عند فتح العرض التقديمي، يتم تعيين التكبير مسبقًا. يمكن القيام بذلك عن طريق تعيين [**ViewProperties**](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) لعرض تقديمي. يمكن تعيين خصائص عرض الشريحة وكذلك [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/properties/notesviewproperties) برمجيًا. في هذا الموضوع، سنرى من خلال مثال كيفية تعيين خصائص العرض للعرض التقديمي في Aspose.Slides.

لتعيين خصائص العرض. يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)
1. تعيين خصائص العرض [Properties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) للعرض التقديمي
1. كتابة العرض التقديمي كملف PPTX

في المثال المذكور أدناه، قمنا بتعيين قيمة التكبير لعرض الشريحة وكذلك عرض الملاحظات.

```c#
// Instantiate a Presentation object that represents a presentation file
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Setting View Properties of Presentation

    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Zoom value in percentages for slide view
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Zoom value in percentages for notes view 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```



## **تعيين خصائص العرض**
لتعيين خصائص العرض. يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة Presentation.
1. تعيين خصائص العرض للعرض التقديمي.
1. كتابة العرض التقديمي كملف PPTX.

في المثال المذكور أدناه، قمنا بتعيين قيمة التكبير لعرض الشريحة وكذلك عرض الملاحظات.

```c#
// Instantiate a Presentation object that represents a presentation file
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Setting View Properties of Presentation

    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Zoom value in percentages for slide view
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Zoom value in percentages for notes view 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```