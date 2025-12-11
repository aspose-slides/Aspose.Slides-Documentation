---
title: استرجاع وتحديث خصائص عرض العرض التقديمي في C++
linktitle: خصائص العرض
type: docs
weight: 80
url: /ar/cpp/presentation-view-properties/
keywords:
- خصائص العرض
- عرض عادي
- محتوى المخطط
- أيقونات المخطط
- إمساك الفاصل العمودي
- عرض وحيد
- حالة الشريط
- حجم البُعد
- ضبط تلقائي
- التكبير الافتراضي
- PowerPoint
- OpenDocument
- العرض التقديمي
- C++
- Aspose.Slides
description: "اكتشف خصائص عرض Aspose.Slides لـ C++ لتخصيص تنسيقات الشرائح PPT و PPTX و ODP — ضبط التخطيطات ومستويات التكبير وإعدادات العرض."
---

{{% alert color="primary" %}} 

العرض العادي يتكون من ثلاث مناطق محتوى: الشريحة نفسها، منطقة محتوى جانبية، ومنطقة محتوى سفلية. خصائص تتعلق بموضع المناطق المختلفة للمحتوى. هذه المعلومات تسمح للتطبيق بحفظ حالة العرض إلى الملف، بحيث عند إعادة الفتح تكون الحالة نفسها كما كانت عندما تم حفظ العرض آخر مرة.

تم إضافة الطريقة [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_view_properties#aa8add44edf3e3ac578e0bf8f32617b06) لتوفير الوصول إلى خصائص العرض العادي للعرض التقديمي. 

تمت إضافة الواجهات [INormalViewProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_normal_view_properties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_normal_view_restored_properties) ونسلها، وعدد التعداد [SplitterBarStateType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#ac12b36e68eb35cfd6ae026915e071950) .

{{% /alert %}} 

## **حول INormalViewProperties**

تمثل خصائص العرض العادي.

الخاصية **ShowOutlineIcons** تحدد ما إذا كان يجب على التطبيق إظهار الأيقونات عند عرض محتوى المخطط في أي من مناطق المحتوى في وضع العرض العادي.

الخاصية **SnapVerticalSplitter** تحدد ما إذا كان يجب أن يلتقط الفاصل العمودي إلى حالة مصغرة عندما تكون المنطقة الجانبية صغيرة بما فيه الكفاية.

الخاصية **PreferSingleView** تحدد ما إذا كان المستخدم يفضّل رؤية منطقة محتوى واحدة بملء النافذة بدلاً من العرض العادي القياسي الذي يضم ثلاث مناطق محتوى. إذا تم تمكينها، قد يختار التطبيق عرض إحدى مناطق المحتوى في كامل النافذة.

الخصائص **VerticalBarState** و **HorizontalBarState** تحدد الحالة التي يجب عرض شريط الفاصل الأفقي أو العمودي فيها. شريط الفاصل الأفقي يفصل الشريحة عن منطقة المحتوى أسفل الشريحة، شريط الفاصل العمودي يفصل الشريحة عن منطقة المحتوى الجانبية. القيم الممكنة هي: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** و **SplitterBarStateType.Restored**.

الخصائص **RestoredLeft** و **RestoredTop** تحدد حجم منطقة الشريحة العلوية أو الجانبية في العرض العادي، عندما تكون قيمة **SplitterBarStateType.Restored** مطبقة على **VerticalBarState** و **HorizontalBarState** على التوالي.

## **حول استعادة INormalViewProperties**

يحدد حجم منطقة الشريحة (العرض عندما تكون طفلاً لـ RestoredTop، والارتفاع عندما تكون طفلاً لـ RestoredLeft) في العرض العادي، عندما تكون المنطقة بحجم مستعاد متغير (ليس مصغرة ولا مكبرة). 

الخاصية **DimensionSize** تحدد حجم منطقة الشريحة (العرض عندما تكون طفلاً لـ restoredTop، والارتفاع عندما تكون طفلاً لـ restoredLeft).

الخاصية **AutoAdjust** تحدد ما إذا كان يجب على منطقة المحتوى الجانبية التعويض عن الحجم الجديد عند تغيير حجم النافذة التي تحتوي العرض داخل التطبيق.

يظهر المثال أدناه كيف يمكنك الوصول إلى خصائص **ViewProperties.NormalViewProperties** لعرض تقديمي.
``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// استعادة خصائص عرض العرض التقديمي
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```


## **ضبط قيمة التكبير الافتراضية**

أصبح Aspose.Slides for C++ الآن يدعم تعيين قيمة التكبير الافتراضية للعرض التقديمي بحيث يتم تعيين التكبير مسبقًا عند فتح العرض. يمكن تنفيذ ذلك عن طريق تعيين [ViewProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties) للعرض التقديمي. يمكن أيضًا تعيين خصائص عرض الشريحة وكذلك [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties#a86ad6559c9c0768d8210fdb86c86cf98) برمجيًا. في هذا الموضوع، سنرى من خلال مثال كيفية تعيين خصائص العرض للعرض التقديمي في Aspose.Slides.

لتعيين خصائص العرض، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)
1. تعيين [Properties](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties) للعرض التقديمي
1. كتابة العرض التقديمي كملف PPTX

في المثال أدناه، قمنا بتعيين قيمة التكبير لكل من عرض الشريحة وعرض الملاحظات.
``` cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// ضبط خصائص العرض للعرض التقديمي
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // قيمة التكبير بالنسبة المئوية لعرض الشريحة
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // قيمة التكبير بالنسبة المئوية لعرض الملاحظات

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```


## **الأسئلة المتداولة**

**هل يمكنني تعيين إعدادات عرض مختلفة لأقسام مختلفة من العرض التقديمي؟**

إعدادات [View settings](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) تُحدد على مستوى العرض التقديمي ([Normal View](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_slideviewproperties/))، وليس لكل قسم، لذا فإن مجموعة واحدة من المعلمات تُطبق على المستند بأكمله عند فتحه.

**هل يمكنني تعريف حالات عرض مختلفة مسبقًا لمستخدمين مختلفين؟**

لا. تُخزن الإعدادات في الملف وتُشارك. قد تُحترم تفضيلات المستخدم في تطبيقات العرض، لكن الملف نفسه يحتوي على مجموعة واحدة من خصائص العرض.

**هل يمكنني إعداد قالب بخصائص عرض مسبقة التعريف بحيث يفتح العروض التقديمية الجديدة بنفس الطريقة؟**

نعم. بما أن [view properties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) تُخزن على مستوى العرض التقديمي، يمكنك تضمينها في قالب وإنشاء مستندات جديدة منه بنفس تكوين العرض الأولي.