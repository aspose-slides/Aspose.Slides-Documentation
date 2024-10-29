---
title: خصائص عرض الشريحة
type: docs
url: /ar/cpp/presentation-view-properties/
---

{{% alert color="primary" %}} 

يتكون العرض العادي من ثلاث مناطق محتوى: الشريحة نفسها، ومنطقة محتوى جانبية، ومنطقة محتوى سفلية. الخصائص المتعلقة بمكان وجود مناطق المحتوى المختلفة. هذه المعلومات تتيح للتطبيق حفظ حالة العرض في الملف، بحيث عند إعادة فتحه تكون حالة العرض كما كانت عند آخر حفظ للعروض.

تمت إضافة الطريقة [**IViewProperties::get_NormalViewProperties()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_view_properties#aa8add44edf3e3ac578e0bf8f32617b06) لتوفير الوصول إلى خصائص العرض العادي للعروض. 

تمت إضافة واجهتي [**INormalViewProperties**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_normal_view_properties) و [**INormalViewRestoredProperties**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_normal_view_restored_properties) وورثتها، بالإضافة إلى تعداد [**SplitterBarStateType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#ac12b36e68eb35cfd6ae026915e071950).

{{% /alert %}} 



## **حول INormalViewProperties** #

تمثل خصائص العرض العادي.

تحدد خاصية **ShowOutlineIcons** ما إذا كان يجب على التطبيق عرض الأيقونات عند عرض محتوى المخطط في أي من مناطق المحتوى لوضع العرض العادي.

تحدد خاصية **SnapVerticalSplitter** ما إذا كان يجب أن تنقر الفاصل العمودي إلى حالة مصغرة عندما تكون المنطقة الجانبية صغيرة بما يكفي.

تحدد خاصية **PreferSingleView** ما إذا كان المستخدم يفضل رؤية منطقة محتوى مفردة في نافذة كاملة بدلاً من العرض العادي القياسي مع ثلاث مناطق محتوى. إذا تم تمكينه، قد يختار التطبيق عرض واحدة من مناطق المحتوى في النافذة بأكملها.

تحدد خصائص **VerticalBarState** و **HorizontalBarState** الحالة التي يجب عرض الفاصل الأفقي أو العمودي بها. يفصل الفاصل الأفقي الشريحة عن منطقة المحتوى أسفل الشريحة، بينما يفصل الفاصل العمودي الشريحة عن المنطقة الجانبية للمحتوى. القيم الممكنة هي: **SplitterBarStateType.Minimized** و **SplitterBarStateType.Maximized** و **SplitterBarStateType.Restored**.

تحدد خصائص **RestoredLeft** و **RestoredTop** حجم منطقة الشريحة العلوية أو الجانبية من العرض العادي، عندما يتم تطبيق قيمة **SplitterBarStateType.Restored** على **VerticalBarState** و **HorizontalBarState** على التوالي.



## **حول INormalViewRestoredProperties** #

تحدد حجم منطقة الشريحة ((العرض عند كونها طفلاً لـ RestoredTop، الارتفاع عند كونها طفلاً لـ RestoredLeft) من العرض العادي، عندما تكون المنطقة بحجم متغير تم استرداده (لا مصغر ولا مكبر).

تحدد خاصية **DimensionSize** حجم منطقة الشريحة (العرض عند كونها طفلاً لـ restoredTop، الارتفاع عند كونها طفلاً لـ restoredLeft).

تحدد خاصية **AutoAdjust** ما إذا كان يجب أن يعوض حجم منطقة المحتوى الجانبية عن الحجم الجديد عند تغيير حجم النافذة التي تحتوي على العرض داخل التطبيق.

يُعطى مثال أدناه يوضح كيفية الوصول إلى خصائص **ViewProperties.NormalViewProperties** لعروض تقديمية.

``` cpp
// إنشاء كائن عرض تقديمي يمثل ملف عرض تقديمي
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```


## **تعيين قيمة التكبير الافتراضية**
يدعم Aspose.Slides لــ C++ الآن تعيين قيمة التكبير الافتراضية للعروض التقديمية بحيث يتم تعيين التكبير بالفعل عند فتح العرض. يمكن القيام بذلك من خلال تعيين [**ViewProperties**](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties) للعرض التقديمي. يمكن تعيين خصائص عرض الشرائح وكذلك [get_NotesViewProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties#a86ad6559c9c0768d8210fdb86c86cf98) برمجياً. في هذا الموضوع، سنرى مع مثال كيفية تعيين خصائص العرض للتقديم في Aspose.Slides.

لتعيين خصائص العرض، يرجى اتباع الخطوات أدناه:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)
1. تعيين خصائص العرض [Properties](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties) للعرض التقديمي
1. كتابة العرض التقديمي كملف PPTX

في المثال المعطى أدناه، قمنا بتعيين قيمة التكبير لعرض الشرائح وكذلك عرض الملاحظات.

``` cpp
// إنشاء كائن عرض تقديمي يمثل ملف عرض تقديمي
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
// تعيين خصائص عرض تقديمي

presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100);
// قيمة التكبير بالنسبة المئوية لعرض الشرائح
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100);
// قيمة التكبير بالنسبة المئوية لعرض الملاحظات 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```



## **تعيين خصائص العرض**
لتعيين خصائص العرض، يرجى اتباع الخطوات أدناه:

1. إنشاء نسخة من فئة عرض تقديمي.
1. تعيين خصائص عرض تقديمي.
1. كتابة العرض التقديمي كملف PPTX.

في المثال المعطى أدناه، قمنا بتعيين قيمة التكبير لعرض الشرائح وكذلك عرض الملاحظات.

``` cpp
// إنشاء كائن عرض تقديمي يمثل ملف عرض تقديمي
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// تعيين خصائص عرض تقديمي
// قيمة التكبير بالنسبة المئوية لعرض الشرائح
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100);
// قيمة التكبير بالنسبة المئوية لعرض الملاحظات
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100);

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```