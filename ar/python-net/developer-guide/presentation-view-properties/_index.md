---
title: استرجاع وتحديث خصائص عرض العرض التقديمي في بايثون
linktitle: خصائص العرض
type: docs
weight: 80
url: /ar/python-net/presentation-view-properties/
keywords:
- خصائص العرض
- العرض العادي
- محتوى المخطط
- أيقونات المخطط
- إلتقاط الفاصل العمودي
- عرض واحد
- حالة الشريط
- حجم البُعد
- ضبط تلقائي
- تكبير افتراضي
- PowerPoint
- العرض التقديمي
- Python
- Aspose.Slides
description: "اكتشف خصائص عرض Aspose.Slides لبايثون عبر .NET لتخصيص صيغ PPT و PPTX و ODP—ضبط التخطيطات ومستويات التكبير وإعدادات العرض."
---
## **المقدمة**

يتكوّن العرض العادي من ثلاث مناطق محتوى: الشريحة نفسها، منطقة محتوى جانبية، ومنطقة محتوى سفلية. الخصائص المتعلقة بموضع مناطق المحتوى المختلفة. تسمح هذه المعلومات للتطبيق بحفظ حالة العرض في الملف، بحيث عند إعادة الفتح يكون العرض في نفس الحالة التي تم حفظ العرض فيها آخر مرة.

تم إضافة الخاصية [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/viewproperties/normal_view_properties/) لتوفير الوصول إلى خصائص العرض العادي للعرض التقديمي.

تم إضافة الفئات [NormalViewProperties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/normalviewproperties/)، [NormalViewRestoredProperties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/normalviewrestoredproperties/) وسلفها، والعدد [SplitterBarStateType](https://reference.aspose.com/slides/ar/python-net/aspose.slides/splitterbarstatetype/) enum.

## **حول INormalViewProperties**

يمثّل خصائص العرض العادي.

تحدد الخاصية **ShowOutlineIcons** ما إذا كان يجب على التطبيق إظهار الأيقونات عند عرض محتوى المخطط في أي من مناطق المحتوى في وضع العرض العادي.

تحدد الخاصية **SnapVerticalSplitter** ما إذا كان يجب على الفاصل العمودي الالتصاق بحالة مصغرة عندما تكون المنطقة الجانبية صغيرة بما يكفي.

تحدد الخاصية **PreferSingleView** ما إذا كان المستخدم يفضّل رؤية منطقة محتوى واحدة بملء النافذة بدلاً من العرض العادي القياسي الذي يحتوي على ثلاث مناطق محتوى. إذا تم تمكينها، قد يختار التطبيق عرض إحدى مناطق المحتوى في النافذة بالكامل.

تحدد الخصائص **VerticalBarState** و**HorizontalBarState** الحالة التي يجب أن يُظهر فيها شريط الفاصل الأفقي أو العمودي. الشريط الفاصل الأفقي يفصل بين الشريحة ومنطقة المحتوى أسفل الشريحة، بينما يفصل الشريط الفاصل العمودي بين الشريحة ومنطقة المحتوى الجانبية. القيم الممكنة هي: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** و **SplitterBarStateType.Restored**.

تحدد الخصائص **RestoredLeft** و**RestoredTop** حجم منطقة الشريحة العلوية أو الجانبية في العرض العادي، عندما تُطبق قيمة **SplitterBarStateType.Restored** على **VerticalBarState** و**HorizontalBarState** وفقاً لذلك.

## **حول استعادة INormalViewProperties**

تحدد حجم منطقة الشريحة (العرض عندما تكون فرعاً من RestoredTop، الارتفاع عندما تكون فرعاً من RestoredLeft) في العرض العادي، عندما تكون المنطقة ذات حجم مستعاد متغيّر (ليس مصغراً ولا مكبّراً).

تحدد الخاصية **DimensionSize** حجم منطقة الشريحة (العرض عندما تكون فرعاً من RestoredTop، الارتفاع عندما تكون فرعاً من RestoredLeft).

تحدد الخاصية **AutoAdjust** ما إذا كان يجب على منطقة المحتوى الجانبية تعويض الحجم الجديد عند تغيير حجم النافذة التي تحتوي على العرض داخل التطبيق.

فيما يلي مثال يوضح كيفية الوصول إلى خصائص **ViewProperties.NormalViewProperties** لعرض تقديمي.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # استعادة خصائص العرض للعرض التقديمي
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين قيمة التكبير الافتراضية**

أصبح Aspose.Slides for Python via .NET يدعم الآن تعيين قيمة التكبير الافتراضية للعرض التقديمي بحيث يتم تعيين التكبير مسبقاً عند فتح العرض. يمكن تنفيذ ذلك عن طريق تعيين [view_properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/view_properties/) للعرض التقديمي. يمكن تعيين خصائص عرض الشريحة وكذلك [notes_view_properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/viewproperties/notes_view_properties/) برمجيًا. في هذا الموضوع، سنستعرض مثالاً يوضح كيفية تعيين خصائص العرض للعرض التقديمي في Aspose.Slides.

للتعيين، يرجى اتباع الخطوات التالية:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
1. تعيين [view properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/viewproperties/) للعرض التقديمي.
1. كتابة العرض التقديمي كملف PPTX.

في المثال أدناه، تم تعيين قيمة التكبير لكل من عرض الشريحة وعرض الملاحظات.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # تعيين خصائص العرض للعرض التقديمي
    presentation.view_properties.slide_view_properties.scale = 100 # قيمة التكبير كنسبة مئوية للعرض الشريحة
    presentation.view_properties.notes_view_properties.scale = 100 # قيمة التكبير كنسبة مئوية لعرض الملاحظات 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين تباعد الشبكة**

استخدم [Presentation.view_properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/view_properties/) للوصول إلى إعدادات العرض على مستوى العرض التقديمي. خاصية [ViewProperties.grid_spacing](https://reference.aspose.com/slides/ar/python-net/aspose.slides/viewproperties/grid_spacing/) تقرأ أو تغيّر الفاصل الزمني للشبكة التحريرية الأساسية. ينطبق هذا الإعداد على كامل العرض التقديمي، وليس على شريحة فردية. يُحدّد تباعد الشبكة بالنقاط، حيث تساوي 72 نقطة بوصة واحدة. استخدم قيمة موجبة كما هو مطلوب في وثائق API.

المثال التالي يفتح ملف `demo.pptx` موجود، يطبع تباعد الشبكة الحالي، يعيّن فاصلًا ربع بوصة، ثم يحفظ النتيجة.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

الشبكة تختلف عن [drawing guides](/slides/ar/python-net/drawing-guides/). تباعد الشبكة يتحكم في فاصل زمني منتظم، بينما الأدلة الرسومية هي خطوط محاذاة أفقية أو عمودية موضوعة بشكل فردي. إضافة أو نقل أو مسح الأدلة الرسومية لا يغيّر تباعد الشبكة.

كلا من الشبكة والأدلة الرسومية هما مساعدات تحرير. لا تُعرض كجزء من محتوى الشريحة في PDF أو الصور أو SVG أو عرض الشرائح. تخزين تباعد الشبكة لا يضمن أن المحرر سيظهر الشبكة: تعتمد رؤيتها أيضًا على تفضيلات العارض أو المحرر.

## **إظهار أو إخفاء التعليقات عند فتح عرض تقديمي**

استخدم [Presentation.view_properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/view_properties/) للوصول إلى إعدادات العرض على مستوى العرض التقديمي. اقرأ أو غير [ViewProperties.show_comments](https://reference.aspose.com/slides/ar/python-net/aspose.slides/viewproperties/show_comments/) لتخزين تفضيل ما إذا كانت التعليقات يجب أن تُظهر عند فتح العرض التقديمي في PowerPoint أو محرر متوافق آخر.

هذا الإعداد يتحكم فقط في تفضيل العرض المخزن. لا يضيف أو يزيل أو يحرر أو يحل التعليقات. إخفاء التعليقات يحافظ على محتواها ومؤلفيها ومواقعها والردود عليها وحالاتها. راجع [Presentation Comments](/slides/ar/python-net/presentation-comments/) للعمليات التي تغيّر التعليقات نفسها.

المثال التالي يتطلب وجود ملف `comments.pptx` يحتوي على تعليقات. يطبع إعداد الرؤية الحالي، يطلب إخفاء التعليقات، ويحفظ ملف PPTX جديد دون إزالة أي تعليقات. كما يعيّن [ViewProperties.last_view](https://reference.aspose.com/slides/ar/python-net/aspose.slides/viewproperties/last_view/) إلى [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/ar/python-net/aspose.slides/viewtype/) لتكوين طريقة التحرير الأولية جنبًا إلى جنب مع رؤية التعليقات.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    show_comments = presentation.view_properties.show_comments
    print(f"Current comment visibility: {show_comments}")

    presentation.view_properties.show_comments = slides.NullableBool.FALSE
    presentation.view_properties.last_view = slides.ViewType.SLIDE_VIEW
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

هذا الإعداد لا يحدّد ما إذا كانت التعليقات تُدرج في تصديرات PDF أو HTML أو الصور أو الملاحظات أو النشرات. اضبط الخيارات الخاصة بكل تصديرة على حدة.

## **الأسئلة المتكررة**

**لماذا لا تكون الشبكة مرئية بعد إعادة فتح العرض التقديمي؟**

يخزن الملف تباعد الشبكة، لكن المحرر يتحكم فيما إذا كانت الشبكة تُعرض. تحقق من إعدادات رؤية الشبكة في المحرر.

**هل مسح الأدلة الرسومية يغيّر تباعد الشبكة؟**

لا. الأدلة الرسومية وتباعد الشبكة إعدادات مستقلة. مسح الأدلة يترك الفاصل الزمني المخزن للشبكة دون تغيير.

**هل يمكنني تعيين إعدادات عرض مختلفة لأقسام مختلفة من العرض التقديمي؟**

[إعدادات العرض](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/view_properties/) تُعرّف على مستوى العرض التقديمي ([Normal View](https://reference.aspose.com/slides/ar/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/ar/python-net/aspose.slides/viewproperties/slide_view_properties/))، وليس لكل قسم، لذا يتطبق مجموعة واحدة من المعلمات على المستند بأكسره عند الفتح.

**هل يمكنني تعيين حالات عرض مختلفة لمستخدمين مختلفين؟**

لا. تُخزن الإعدادات في الملف وتُشارك. قد تحترم تطبيقات العرض تفضيلات المستخدم، لكن الملف نفسه يحتوي على مجموعة واحدة من خصائص العرض.

**هل يمكنني إعداد قالب بخصائص عرض مسبقة حتى يفتح العروض التقديمية الجديدة بنفس الطريقة؟**

نعم. نظرًا لأن [view properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/view_properties/) تُخزن على مستوى العرض التقديمي، يمكنك تضمينها في قالب وإنشاء مستندات جديدة منه مع نفس تكوين العرض الأولي.