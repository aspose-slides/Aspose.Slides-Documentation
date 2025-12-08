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
- التقاط المقسم الرأسي
- العرض الفردي
- حالة الشريط
- حجم البُعد
- تعديل تلقائي
- تكبير افتراضي
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "اكتشف خصائص العرض في Aspose.Slides للبايثون عبر .NET لتخصيص صيغ PPT و PPTX و ODP — ضبط التخطيطات ومستويات التكبير وإعدادات العرض."
---

{{% alert color="primary" %}} 

العرض العادي يتكون من ثلاث مناطق محتوى: الشريحة نفسها، منطقة محتوى جانبية، ومنطقة محتوى سفلية. الخصائص المتعلقة بموضع المناطق المختلفة تسمح للتطبيق بحفظ حالة العرض في الملف، بحيث يكون العرض عند إعادة الفتح في نفس الحالة التي كان عليها عند آخر حفظ للعرض التقديمي.

تمت إضافة الخاصية [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/iviewproperties/) لتوفير الوصول إلى خصائص العرض العادي للعرض التقديمي.  

تمت إضافة الواجهات [INormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/inormalviewproperties/)، [INormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/inormalviewrestoredproperties/) وسلفهما، والعدد [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) إلى المشروع.  

{{% /alert %}} 

## **About INormalViewProperties** 

يمثل خصائص العرض العادي.

تحدد الخاصية **ShowOutlineIcons** ما إذا كان يجب على التطبيق إظهار الأيقونات عند عرض محتوى المخطط التفصيلي في أيٍ من مناطق المحتوى في وضع العرض العادي.

تحدد الخاصية **SnapVerticalSplitter** ما إذا كان على المقسم الرأسي الانتقال إلى حالة مصغرة عندما تكون المنطقة الجانبية صغيرة بما فيه الكفاية.

تحدد الخاصية **PreferSingleView** ما إذا كان المستخدم يفضل رؤية منطقة محتوى واحدة بملء النافذة بدلاً من العرض العادي القياسي الذي يحتوي على ثلاث مناطق محتوى. إذا تم تمكينها، قد يختار التطبيق عرض إحدى مناطق المحتوى في النافذة بالكامل.

تحدد الخصائص **VerticalBarState** و **HorizontalBarState** الحالة التي يجب أن يُظهر فيها شريط المقسم الأفقي أو الرأسي. الشريط المقسم الأفقي يفصل الشريحة عن منطقة المحتوى أسفل الشريحة، والشريط المقسم الرأسي يفصل الشريحة عن المنطقة الجانبية. القيم الممكنة هي: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** و **SplitterBarStateType.Restored**.

تحدد الخصائص **RestoredLeft** و **RestoredTop** حجم منطقة الشريحة العلوية أو الجانبية في العرض العادي عندما تُطبّق القيمة **SplitterBarStateType.Restored** على **VerticalBarState** و **HorizontalBarState** على التوالي.

## **About Restoring INormalViewProperties**

تحدد حجم منطقة الشريحة (العرض عندما تكون فرعية لـ RestoredTop، الارتفاع عندما تكون فرعية لـ RestoredLeft) في العرض العادي عندما تكون المنطقة بحجم مستعاد متغير (ليس مصغراً ولا مكبراً).  

تحدد الخاصية **DimensionSize** حجم منطقة الشريحة (العرض عندما تكون فرعية لـ restoredTop، الارتفاع عندما تكون فرعية لـ restoredLeft).  

تحدد الخاصية **AutoAdjust** ما إذا كان يجب على منطقة المحتوى الجانبية تعديل حجمها تلقائياً لتتناسب مع الحجم الجديد عند تغيير حجم النافذة التي تحتوي على العرض داخل التطبيق.  

يوضح المثال أدناه كيفية الوصول إلى خصائص **ViewProperties.NormalViewProperties** للعرض التقديمي.  
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


## **Set Default Zoom Value**

أصبح Aspose.Slides for Python via .NET يدعم الآن تعيين قيمة التكبير الافتراضية للعرض التقديمي بحيث يكون التكبير مضبوطاً مسبقاً عند فتح العرض. يمكن تحقيق ذلك بتعيين [view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) للعرض التقديمي. يمكن تعيين خصائص عرض الشريحة وكذلك [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) برمجياً. في هذا الموضوع، سنستعرض مثالاً يوضح كيفية تعيين خصائص العرض للعرض التقديمي في Aspose.Slides.

لتعيين خصائص العرض، يرجى اتباع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)  
2. تعيين [Properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) العرض للعرض التقديمي  
3. حفظ العرض التقديمي كملف PPTX  

في المثال أدناه، قمنا بتعيين قيمة التكبير لكل من عرض الشريحة وعرض الملاحظات.  
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # ضبط خصائص العرض للعرض التقديمي
    presentation.view_properties.slide_view_properties.scale = 100 # قيمة التكبير بالنسبة المئوية لعرض الشريحة
    presentation.view_properties.notes_view_properties.scale = 100 # قيمة التكبير بالنسبة المئوية لعرض الملاحظات

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**هل يمكنني تعيين إعدادات عرض مختلفة لأقسام مختلفة من العرض التقديمي؟**

يتم تعريف [View settings](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) على مستوى العرض التقديمي ([Normal View](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/))، وليس لكل قسم على حدة، لذا يتم تطبيق مجموعة واحدة من المعلمات على المستند بالكامل عند الفتح.

**هل يمكنني تحديد حالات عرض مسبقة لمستخدمين مختلفين؟**

لا. تُخزن الإعدادات في الملف وتُشارك بين جميع المستخدمين. قد تلتزم تطبيقات العرض بتفضيلات المستخدم، لكن الملف نفسه يحتوي على مجموعة واحدة فقط من خصائص العرض.

**هل يمكنني إعداد قالب يحتوي على خصائص عرض مسبقة بحيث تفتح العروض الجديدة بنفس الطريقة؟**

نعم. لأن [view properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) تُخزن على مستوى العرض التقديمي، يمكنك تضمينها في قالب وإنشاء مستندات جديدة منه بنفس تكوين العرض الأولي.