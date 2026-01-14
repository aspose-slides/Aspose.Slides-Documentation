---
title: استرجاع وتحديث خصائص عرض العرض التقديمي في بايثون
linktitle: خصائص العرض
type: docs
weight: 80
url: /ar/python-net/presentation-view-properties/
keywords:
- خصائص العرض
- العرض العادي
- محتوى المخطط التفصيلي
- أيقونات المخطط التفصيلي
- تثبيت القسّام العمودي
- عرض منفرد
- حالة الشريط
- حجم البُعد
- تعديل تلقائي
- تكبير افتراضي
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "اكتشف خصائص العرض في Aspose.Slides للبايثون عبر .NET لتخصيص صيغ PPT و PPTX و ODP — تعديل التخطيطات ومستويات التكبير وإعدادات العرض."
---

{{% alert color="primary" %}} 

العرض العادي يتكون من ثلاث مناطق محتوى: الشريحة نفسها، منطقة محتوى جانبية، ومنطقة محتوى سفلية. الخصائص المتعلقة بموضع المناطق المختلفة للمحتوى. تتيح هذه المعلومات للتطبيق حفظ حالة العرض في الملف، بحيث عند إعادة الفتح تكون الحالة هي نفسها كما كانت عند حفظ العرض آخر مرة.

تم إضافة الخاصية [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/) لتوفير الوصول إلى خصائص العرض العادي للعرض التقديمي.  

تم إضافة الفئات [NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/)، [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/) وفروعها، وتعداد [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/)  

{{% /alert %}} 

## **حول INormalViewProperties** 

تمثل خصائص العرض العادي.

خاصية **ShowOutlineIcons** تحدد ما إذا كان يجب على التطبيق عرض الأيقونات عند عرض محتوى المخطط التفصيلي في أي من مناطق المحتوى في وضع العرض العادي.

خاصية **SnapVerticalSplitter** تحدد ما إذا كان يجب على الفاصل العمودي الانتقال إلى الحالة المصغرة عندما تكون المنطقة الجانبية صغيرة بما يكفي.

خاصية **PreferSingleView** تحدد ما إذا كان يفضل المستخدم رؤية منطقة محتوى واحدة ملء النافذة بدلًا من العرض العادي القياسي الذي يحتوي على ثلاث مناطق محتوى. إذا تم تمكينها، قد يختار التطبيق عرض إحدی مناطق المحتوى في كامل النافذة.

الخصائص **VerticalBarState** و**HorizontalBarState** تحدد الحالة التي يجب أن يُظهر فيها شريط الفاصل الأفقي أو العمودي. شريط الفاصل الأفقي يفصل الشريحة عن منطقة المحتوى أسفل الشريحة، شريط الفاصل العمودي يفصل الشريحة عن منطقة المحتوى الجانبية. القيم الممكنة هي: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** و**SplitterBarStateType.Restored**.

الخصائص **RestoredLeft** و**RestoredTop** تحدد حجم منطقة الشريحة العلوية أو الجانبية في العرض العادي، عندما يتم تطبيق القيمة **SplitterBarStateType.Restored** على **VerticalBarState** و**HorizontalBarState** على التوالي.

## **حول استعادة INormalViewProperties** 

تحدد حجم منطقة الشريحة (العرض عندما تكون فرعًا لـ **restoredTop**، الارتفاع عندما تكون فرعًا لـ **restoredLeft**) في العرض العادي، عندما تكون المنطقة بحجم مستعاد متغير (ليس مصغّرًا ولا مكبّرًا).  

خاصية **DimensionSize** تحدد حجم منطقة الشريحة (العرض عندما تكون فرعًا لـ **restoredTop**, الارتفاع عندما تكون فرعًا لـ **restoredLeft**).  

خاصية **AutoAdjust** تحدد ما إذا كان يجب على منطقة المحتوى الجانبية تعديل حجمها لتعويض الحجم الجديد عند تغيير حجم النافذة التي تحتوي على العرض داخل التطبيق.  

يوضح المثال أدناه كيفية الوصول إلى خصائص **ViewProperties.NormalViewProperties** لعرض تقديمي.  
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # استعادة خصائص العرض للعرض التقديمي
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```


## **تعيين قيمة التكبير الافتراضية** 

أصبح Aspose.Slides for Python عبر .NET يدعم الآن تعيين قيمة التكبير الافتراضية للعرض التقديمي بحيث يتم تعيين التكبير مسبقًا عند فتح العرض. يمكن القيام بذلك عن طريق تعيين [view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) للعرض التقديمي. يمكن تعيين خصائص عرض الشريحة وكذلك [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/notes_view_properties/) برمجياً. في هذا الموضوع، سنرى مثالًا يوضح كيفية تعيين خصائص العرض للعرض التقديمي في Aspose.Slides.  

لتعيين خصائص العرض، يرجى اتباع الخطوات التالية:  

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)  
1. تعيين [view properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) للعرض التقديمي  
1. حفظ العرض التقديمي كملف PPTX  

في المثال أدناه، قمنا بتعيين قيمة التكبير لعرض الشريحة وكذلك لعرض الملاحظات.  
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # ضبط خصائص العرض للعرض التقديمي
    presentation.view_properties.slide_view_properties.scale = 100 # قيمة التكبير بالنسبة المئوية لعرض الشريحة
    presentation.view_properties.notes_view_properties.scale = 100 # قيمة التكبير بالنسبة المئوية لعرض الملاحظات 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```


## **الأسئلة المتكررة**  

**هل يمكنني تعيين إعدادات عرض مختلفة لأقسام مختلفة من العرض التقديمي؟**  

يتم تعريف [View settings](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) على مستوى العرض التقديمي ([Normal View](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/))، وليس لكل قسم، وبالتالي يطبق مجموعة واحدة من المعلمات على المستند بأكمله عند فتحه.  

**هل يمكنني تحديد حالات عرض مختلفة لمستخدمين مختلفين مسبقًا؟**  

لا. يتم تخزين الإعدادات في الملف وتُشارك. قد تقوم تطبيقات العرض باحترام تفضيلات المستخدم، لكن الملف نفسه يحتوي على مجموعة واحدة من خصائص العرض.  

**هل يمكنني إعداد قالب يحتوي على خصائص عرض محددة مسبقًا بحيث تفتح العروض التقديمية الجديدة بنفس الطريقة؟**  

نعم. لأن [view properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) تُخزن على مستوى العرض التقديمي، يمكنك تضمينها في قالب وإنشاء مستندات جديدة منه بنفس تكوين العرض الأولي.