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
- إغلاق الفاصل العمودي
- عرض واحد
- حالة الشريط
- حجم البُعد
- تعديل تلقائي
- تكبير افتراضي
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "اكتشف خصائص عرض Aspose.Slides لبايثون عبر .NET لتخصيص صيغ PPT و PPTX و ODP — ضبط التخطيطات ومستويات التكبير وإعدادات العرض."
---
## **المقدمة**

يتكوّن العرض العادي من ثلاث مناطق محتوى: الشريحة نفسها، منطقة محتوى جانبية، ومنطقة محتوى سفلية. الخصائص المتعلقة بموضع المناطق المختلفة للمحتوى. تسمح هذه المعلومات للتطبيق بحفظ حالة عرضه في الملف، بحيث يكون العرض في نفس الحالة عند إعادة فتحه كما كان عند آخر حفظ للعرض التقديمي.

تمت إضافة الخاصية [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/viewproperties/normal_view_properties/) لتوفير الوصول إلى خصائص العرض العادي للعرض التقديمي.

تم إضافة الفئات [NormalViewProperties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/normalviewproperties/)، [NormalViewRestoredProperties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/normalviewrestoredproperties/) وسلالتها، والعدد [SplitterBarStateType](https://reference.aspose.com/slides/ar/python-net/aspose.slides/splitterbarstatetype/) enum.

## **حول INormalViewProperties**

يمثل خصائص العرض العادي.

تحدد الخاصية **ShowOutlineIcons** ما إذا كان يجب على التطبيق إظهار الأيقونات عند عرض محتوى المخطط التفصيلي في أي من مناطق المحتوى في وضع العرض العادي.

تحدد الخاصية **SnapVerticalSplitter** ما إذا كان يجب أن يتحرك الفاصل العمودي إلى حالة مصغرة عندما تصبح المنطقة الجانبية صغيرة بما يكفي.

تحدد الخاصية **PreferSingleView** ما إذا كان المستخدم يفضّل رؤية منطقة محتوى واحدة بملء النافذة بدلاً من العرض العادي القياسي بثلاث مناطق محتوى. إذا تم تمكينها، قد يختار التطبيق عرض إحدى مناطق المحتوى في كامل النافذة.

تحدد الخصائص **VerticalBarState** و **HorizontalBarState** الحالة التي يجب أن يُظهر فيها شريط الفاصل الأفقي أو الرأسي. شريط الفاصل الأفقي يفصل الشريحة عن منطقة المحتوى أسفل الشريحة، وشريط الفاصل الرأسي يفصل الشريحة عن المنطقة الجانبية. القيم الممكنة هي: **SplitterBarStateType.Minimized**، **SplitterBarStateType.Maximized** و **SplitterBarStateType.Restored**.

تحدد الخصائص **RestoredLeft** و **RestoredTop** حجم المنطقة العلوية أو الجانبية للشريحة في العرض العادي، عندما يتم تطبيق القيمة **SplitterBarStateType.Restored** على **VerticalBarState** و **HorizontalBarState** على التوالي.

## **حول استعادة INormalViewProperties**

تحدد حجم منطقة الشريحة (العرض عندما يكون الطفل لـ RestoredTop، الارتفاع عندما يكون الطفل لـ RestoredLeft) في العرض العادي، عندما تكون المنطقة بحجم مستعيد متغيّر (ليس مصغّرًا ولا مكبّرًا).

تحدد الخاصية **DimensionSize** حجم منطقة الشريحة (العرض عندما يكون الطفل لـ restoredTop، الارتفاع عندما يكون الطفل لـ restoredLeft).

تحدد الخاصية **AutoAdjust** ما إذا كان يجب أن تعوض منطقة المحتوى الجانبية عن الحجم الجديد عند تعديل حجم النافذة التي تحتوي العرض داخل التطبيق.

يتم تقديم مثال أدناه يوضح كيفية الوصول إلى خصائص **ViewProperties.NormalViewProperties** للعرض التقديمي.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # استعادة خصائص عرض العرض التقديمي
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين قيمة التكبير الافتراضية**

يدعم Aspose.Slides for Python via .NET الآن تعيين قيمة التكبير الافتراضية للعرض التقديمي بحيث يتم تعيين التكبير مسبقًا عند فتح العرض. يمكن القيام بذلك عن طريق تعيين [view_properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/view_properties/) للعرض التقديمي. يمكن تعيين خصائص عرض الشريحة وكذلك [notes_view_properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/viewproperties/notes_view_properties/) برمجيًا. في هذا الموضوع، سنرى مثالًا يوضح كيفية تعيين خصائص العرض للعرض التقديمي في Aspose.Slides.

لتعيين خصائص العرض، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/)
1. تعيين [view properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/viewproperties/) للعرض التقديمي
1. كتابة العرض التقديمي كملف PPTX

في المثال المقدم أدناه، قمنا بتعيين قيمة التكبير لعرض الشريحة وكذلك عرض الملاحظات.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # ضبط خصائص العرض للعرض التقديمي
    presentation.view_properties.slide_view_properties.scale = 100 # قيمة التكبير بالنسبة المئوية لعرض الشريحة
    presentation.view_properties.notes_view_properties.scale = 100 # قيمة التكبير بالنسبة المئوية لعرض الملاحظات 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين تباعد الشبكة**

استخدم [Presentation.view_properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/view_properties/) للوصول إلى إعدادات العرض على مستوى العرض التقديمي بأكمله. تقرأ الخاصية [ViewProperties.grid_spacing](https://reference.aspose.com/slides/ar/python-net/aspose.slides/viewproperties/grid_spacing/) أو تغير الفاصل الزمني لشبكة التحرير الأساسية. ينطبق هذا الإعداد على كامل العرض التقديمي، لا على شريحة فردية. يتم تحديد تباعد الشبكة بالنقاط، حيث أن 72 نقطة تساوي بوصة واحدة. استخدم قيمة موجبة كما هو مطلوب في وثائق API.

يفتح المثال التالي ملف `demo.pptx` الموجود مسبقًا، يطبع تباعد الشبكة الحالي، يعيّن فاصل ربع بوصة، ويحفظ النتيجة.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

الشبكة تختلف عن [drawing guides](/slides/ar/python-net/drawing-guides/). يتحكم تباعد الشبكة في فاصل منتظم، بينما تكون الأدلة الرسومية خطوط محاذاة أفقية أو رأسية موضوعة يدويًا. إضافة أو نقل أو مسح الأدلة الرسومية لا يغيّر تباعد الشبكة.

كل من الشبكة والأدلة الرسومية هما أدوات تحرير. لا يتم تمثيلهما كمحتوى شريحة في PDF أو صور أو SVG أو عرض شرائح. تخزين تباعد الشبكة لا يضمن أن المحرر سيظهر الشبكة: تعتمد رؤيتها أيضًا على تفضيلات المشاهد أو المحرر.

## **الأسئلة الشائعة**

**لماذا لا تظهر الشبكة بعد إعادة فتح العرض التقديمي؟**

يقوم الملف بتخزين تباعد الشبكة، لكن المحرر يتحكم فيما إذا كانت الشبكة معروضة. تحقق من إعدادات رؤية الشبكة في المحرر.

**هل يؤدي مسح الأدلة الرسومية إلى تغيير تباعد الشبكة؟**

لا. الأدلة الرسومية وتباعد الشبكة إعدادات مستقلة. مسح الأدلة يترك الفاصل المخزن للشبكة دون تغيير.

**هل يمكنني تعيين إعدادات عرض مختلفة لأقسام مختلفة من العرض التقديمي؟**

يتم تعريف [إعدادات العرض](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/view_properties/) على مستوى العرض التقديمي ([العرض العادي](https://reference.aspose.com/slides/ar/python-net/aspose.slides/viewproperties/normal_view_properties/)/[عرض الشريحة](https://reference.aspose.com/slides/ar/python-net/aspose.slides/viewproperties/slide_view_properties/))، وليس لكل قسم، لذا يتم تطبيق مجموعة واحدة من المعلمات على المستند كاملًا عند الفتح.

**هل يمكنني تحديد حالات عرض مختلفة لمستخدمين مختلفين؟**

لا. تُخزن الإعدادات في الملف وتُشارك. قد تحترم تطبيقات المشاهدة تفضيلات المستخدم، لكن الملف نفسه يحتوي على مجموعة واحدة من خصائص العرض.

**هل يمكنني إعداد قالب يحتوي على خصائص عرض مسبقة التعريف بحيث تفتح العروض التقديمية الجديدة بنفس الطريقة؟**

نعم. بما أن [خصائص العرض](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/view_properties/) تُخزن على مستوى العرض التقديمي، يمكنك تضمينها في قالب وإنشاء مستندات جديدة منه بنفس تكوين العرض الأولي.