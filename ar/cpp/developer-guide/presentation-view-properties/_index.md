---
title: استرجاع وتحديث خصائص عرض العرض التقديمي في C++
linktitle: خصائص العرض
type: docs
weight: 80
url: /ar/cpp/presentation-view-properties/
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
- تكبير افتراضي
- PowerPoint
- OpenDocument
- العرض التقديمي
- C++
- Aspose.Slides
description: "اكتشف خصائص عرض Aspose.Slides لـ C++ لتخصيص صيغ PPT و PPTX و ODP — ضبط التخطيطات ومستويات التكبير وإعدادات العرض."
---

{{% alert color="primary" %}}

يتكون العرض العادي من ثلاث مناطق محتوى: الشريحة نفسها، ومنطقة محتوى جانبية، ومنطقة محتوى سفلية. الخصائص المتعلقة بموضع المناطق المختلفة تسمح للتطبيق بحفظ حالة العرض في الملف، بحيث يكون العرض في الحالة نفسها عند إعادة فتحه كما كان عند آخر حفظ للعرض التقديمي.

تمت إضافة الطريقة [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) لتوفير إمكانية الوصول إلى خصائص العرض العادي للعرض التقديمي.

تمت إضافة الواجهات [INormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/)، [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/) ومستقبلها، بالإضافة إلى تعداد [SplitterBarStateType](https://reference.aspose.com/slides/cpp/aspose.slides/splitterbarstatetype/).

{{% /alert %}}

## **حول INormalViewProperties**

يمثل خصائص العرض العادي.

تحدد الخاصية **ShowOutlineIcons** ما إذا كان ينبغي للتطبيق إظهار الأيقونات عند عرض محتوى المخطط في أي من مناطق المحتوى في وضع العرض العادي.

تحدد الخاصية **SnapVerticalSplitter** ما إذا كان يجب على القاطع العمودي الانتقال إلى حالة مصغرة عندما تكون المنطقة الجانبية صغيرة بما يكفي.

تحدد الخاصية **PreferSingleView** ما إذا كان المستخدم يفضل رؤية منطقة محتوى واحدة على كامل النافذة بدلاً من العرض العادي القياسي الذي يحتوي على ثلاث مناطق محتوى. إذا تم تمكينها، قد يختار التطبيق عرض إحدى مناطق المحتوى في كامل النافذة.

تحدد الخصائص **VerticalBarState** و**HorizontalBarState** الحالة التي يجب أن يُظهر فيها شريط القاطع الرأسي أو الأفقي. يُقسم شريط القاطع الأفقي الشريحة عن منطقة المحتوى الموجودة أسفل الشريحة، بينما يُقسم شريط القاطع الرأسي الشريحة عن المنطقة الجانبية. القيم الممكنة هي: **SplitterBarStateType.Minimized**، **SplitterBarStateType.Maximized** و**SplitterBarStateType.Restored**.

تحدد الخصائص **RestoredLeft** و**RestoredTop** حجم منطقة الشريحة العلوية أو الجانبية في العرض العادي عندما يكون قيمة **SplitterBarStateType.Restored** مطبقة على **VerticalBarState** و**HorizontalBarState** على التوالي.

## **حول استعادة INormalViewProperties**

تحدد حجم منطقة الشريحة (العرض عندما تكون فرعًا من RestoredTop، الارتفاع عندما تكون فرعًا من RestoredLeft) في العرض العادي عندما تكون المنطقة بحجم مستعاد متغير (ليس مصغرة ولا مكبرة).

تحدد الخاصية **DimensionSize** حجم منطقة الشريحة (العرض عندما تكون فرعًا من RestoredTop، الارتفاع عندما تكون فرعًا من RestoredLeft).

تحدد الخاصية **AutoAdjust** ما إذا كان يجب أن تعوض منطقة المحتوى الجانبية عن الحجم الجديد عند تغيير حجم النافذة التي تحتوي على العرض داخل التطبيق.

يوضح المثال أدناه كيفية الوصول إلى خصائص **ViewProperties.NormalViewProperties** لعرض تقديمي.
```cpp
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

يدعم Aspose.Slides لـ C++ الآن ضبط قيمة التكبير الافتراضية للعرض التقديمي بحيث يتم تعيين التكبير مسبقًا عند فتح العرض التقديمي. يمكن تحقيق ذلك عن طريق ضبط [ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/) للعرض التقديمي. يمكن ضبط خصائص عرض الشريحة وكذلك [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_notesviewproperties/) برمجيًا. في هذا الموضوع، سنستعرض مثالًا يوضح كيفية ضبط خصائص العرض للعرض التقديمي في Aspose.Slides.

لضبط خصائص العرض، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من فئة [العرض التقديمي](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)  
2. ضبط [خصائص العرض](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/) للعرض التقديمي  
3. حفظ العرض التقديمي كملف PPTX  

في المثال المرفق أدناه، قمنا بضبط قيمة التكبير لعرض الشريحة وعرض الملاحظات.
```cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// تعيين خصائص العرض للعرض التقديمي
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // قيمة التكبير كنسبة مئوية لعرض الشريحة
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // قيمة التكبير كنسبة مئوية لعرض الملاحظات 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```


## **الأسئلة الشائعة**

**هل يمكنني ضبط إعدادات عرض مختلفة لأقسام مختلفة من العرض التقديمي؟**

يتم تعريف [إعدادات العرض](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) على مستوى العرض التقديمي ([العرض العادي](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[عرض الشريحة](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_slideviewproperties/))، وليس لكل قسم. لذلك تُطبق مجموعة واحدة من المعلمات على المستند بأكمله عند فتحه.

**هل يمكنني تحديد حالات عرض مختلفة مسبقًا لمستخدمين مختلفين؟**

لا. تُحفظ الإعدادات في الملف وتُشارك بين الجميع. قد تلتزم تطبيقات العرض بتفضيلات المستخدم، لكن الملف نفسه يحتوي على مجموعة واحدة من خصائص العرض.

**هل يمكنني إعداد قالب يحتوي على خصائص عرض مُعرّفة مسبقًا بحيث تُفتح العروض التقديمية الجديدة بنفس الطريقة؟**

نعم. نظرًا لأن [خصائص العرض](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) تُحفظ على مستوى العرض التقديمي، يمكنك تضمينها في قالب وإنشاء مستندات جديدة منه مع نفس تكوين العرض الأولي.