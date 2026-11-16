---
title: استرجاع وتحديث خصائص عرض العرض التقديمي في Python
linktitle: خصائص العرض
type: docs
weight: 80
url: /ar/python-net/presentation-view-properties/
keywords:
- خصائص العرض
- العرض العادي
- محتوى المخطط
- أيقونات المخطط
- تقسيم عمودي قابل للالتقاط
- عرض فردي
- حالة الشريط
- حجم البُعد
- تعديل تلقائي
- تكبير افتراضي
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "استخدم Aspose.Slides لبايثون عبر .NET لتكوين تخطيط العرض العادي، وتكبير الشريحة والملاحظات، وتباعد الشبكة، ورؤية التعليقات في عروض PowerPoint التقديمية."
---
## **مقدمة**

في طريقة العرض العادية لـ PowerPoint، تظهر الشريحة بين لوحة جانبية للمعاينات أو المخطط ولوحة ملاحظات أسفلها. يتيح Aspose.Slides للـ Python عبر .NET تفضيلات التحرير المحفوظة للعرض من خلال [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/). وتشمل هذه تخطيط اللوحات، مستويات التكبير، تباعد الشبكة، ورؤية التعليقات.

## **حول NormalViewProperties**

استخدم [normal_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/) للوصول إلى كائن [NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/). يتحكم [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) فيما إذا كانت الأيقونات تظهر بجانب عناوين الشرائح في المخطط. يسمح [snap_vertical_splitter](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/snap_vertical_splitter/) للوحة الجانبية بالانقضاض إلى حالتها المصغرة عندما يضيق المستخدم حجمها. يشير [prefer_single_view](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/prefer_single_view/) إلى تفضيل عرض لوحة واحدة في النافذة الكاملة.

يتحكم [vertical_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/vertical_bar_state/) في الفاصل بين اللوحة الجانبية والشريحة. يتحكم [horizontal_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/horizontal_bar_state/) في الفاصل أعلى لوحة الملاحظات. كلاهما يقبل قيمة من نوع [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) إما `MINIMIZED` أو `MAXIMIZED` أو `RESTORED`.

<!-- visual-explanation:presentation-view-properties:start -->
[![محرر مفهومي يفصل بين لوحة جانبية ومنطقة الشريحة والمنطقة السفلية مع فواصل عمودية وأفقية معنونة.](visual-presentation-view-properties-40ae1765a743.svg)](visual-presentation-view-properties-40ae1765a743.svg)

*في العرض العادي، يتحكم الفاصل العمودي في عرض اللوحة الجانبية. يتحكم الفاصل الأفقي في المساحة أعلى لوحة الملاحظات.*
<!-- visual-explanation:presentation-view-properties:end -->

## **حول استعادة NormalViewProperties**

عند استعادة الفاصل، يوفر [restored_left](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_left/) الحجم المحفوظ للوحة الجانبية و[restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) الحجم المحفوظ للمنطقة العليا للشريحة. كلاهما يكشف عن [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/). تقبل خاصية [dimension_size](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/dimension_size/) نسبة مئوية من 0 إلى 100، وتتحكم [auto_adjust](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/auto_adjust/) فيما إذا كان المحرر يضبط الحجم عند تغيير حجم النافذة.

هذا المثال يحدث عرضًا تقديميًا موجودًا. يستعيد الفاصل الأفقي، يضبط [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) إلى 80٪ مع تمكين الضبط التلقائي، ويعظم الفاصل العمودي. كما يمكّن [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) لعرض المخطط.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    normal_view = presentation.view_properties.normal_view_properties
    normal_view.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    normal_view.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED
    normal_view.restored_top.auto_adjust = True
    normal_view.restored_top.dimension_size = 80
    normal_view.show_outline_icons = True

    presentation.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين قيمة التكبير الافتراضية**

تخزن [slide_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/) و[notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/notes_view_properties/) إعدادات تكبير مستقلة للمحرر. لا تؤثر هذه الإعدادات على أبعاد الشريحة أو تشغيل عرض الشرائح أو دقة تصدير الصورة.

يفتح هذا المثال عرضًا تقديميًا موجودًا ويمكّن [variable_scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/variable_scale/) لتناسب الشريحة مع نافذة التحرير. بالنسبة لصفحة الملاحظات، يعطل التكبير التلقائي ويضبط [scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/scale/) إلى تكبير ثابت بنسبة 80٪.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    view_properties.slide_view_properties.variable_scale = True
    view_properties.notes_view_properties.variable_scale = False
    view_properties.notes_view_properties.scale = 80

    presentation.save("zoom.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين تباعد الشبكة**

يحدد [grid_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/grid_spacing/) المسافة بين خطوط الشبكة التحريرية عبر العرض بأكمله. يأخذ قيمة موجبة بالنقاط، حيث يوجد 72 نقطة لكل بوصة. يطبع هذا المثال التباعد الحالي في عرض تقديمي موجود ويحفظ شبكة ربع بوصة بضبط الفاصل إلى 18 نقطة.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current grid spacing: {view_properties.grid_spacing} points")

    view_properties.grid_spacing = 18.0

    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

تُكرر الشبكة بفاصل ثابت. [دليل الرسم](/slides/ar/python-net/drawing-guides/) يحدد مواضع أفقية أو عمودية فردية. كلاهما أدوات مساعدة في التحرير وتظهر فقط في المحررات التي تعرضها. لا تُظهر عروض الشرائح وتصديرات PDF أو الصور أو SVG تلك الأدلة.

## **إظهار أو إخفاء التعليقات عند فتح عرض تقديمي**

يخزن [show_comments](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/show_comments/) تفضيلًا يستخدمه المحرر المتوافق عند فتح العرض التقديمي. لعرض تقديمي موجود يحتوي على تعليقات، يطبع هذا المثال الإعداد الحالي ويحفظ نسخة مع إخفاء التعليقات. كما يضبط [last_view](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/last_view/) إلى [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/) بحيث تُفتح النسخة في عرض الشريحة.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current comment visibility: {view_properties.show_comments}")

    view_properties.show_comments = slides.NullableBool.FALSE
    view_properties.last_view = slides.ViewType.SLIDE_VIEW
    
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

إخفاء التعليقات يحافظ على نصها ومؤلفيها ومواقعها والردود والحالات. لتغيير التعليقات نفسها، راجع [تعليقات العرض التقديمي](/slides/ar/python-net/presentation-comments/). تتحكم إعدادات التصدير فيما إذا كانت التعليقات تظهر في PDF أو HTML أو الصور أو الملاحظات أو النشرات.

## **الأسئلة الشائعة**

**لماذا تكون الشبكة مخفية عندما أعيد فتح العرض التقديمي؟**

يحفظ العرض التقديمي فاصل الشبكة. لعرض الشبكة، فعّل رؤية الشبكة في المحرر.

**هل يؤدي مسح دليل الرسم إلى تغيير تباعد الشبكة؟**

لا. إضافة دليل أو تحريكه أو مسحه لا يغيّر فاصل الشبكة.

**هل يمكن لأقسام مختلفة من العرض التقديمي أن تكون لديها إعدادات عرض مختلفة؟**

لا. [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) ينطبق على العرض التقديمي بأكمله.

**هل يمكنني حفظ إعدادات عرض مختلفة لمستخدمين مختلفين؟**

الملف يخزن مجموعة واحدة من خصائص العرض للجميع. قد يطبق المحرر أيضًا تفضيلات محلية للمستخدم.

**هل يمكنني حفظ إعدادات العرض في قالب؟**

نعم. العروض التقديمية التي تم إنشاؤها من القالب ورثت إعدادات العرض المحفوظة.