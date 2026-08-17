---
title: تطبيق أو تغيير تخطيطات الشرائح في Python
linktitle: تخطيط الشريحة
type: docs
weight: 60
url: /ar/python-net/slide-layout/
keywords:
- تخطيط الشريحة
- تخطيط المحتوى
- عنصر نائب
- تصميم العرض
- تصميم الشريحة
- تخطيط غير مستخدم
- إظهار التذييل
- شريحة العنوان
- عنوان ومحتوى
- عنوان القسم
- محتوى مزدوج
- مقارنة
- عنوان فقط
- تخطيط فارغ
- محتوى مع تسمية
- صورة مع تسمية
- عنوان ونص عمودي
- عنوان عمودي ونص
- PowerPoint
- OpenDocument
- عرض
- Python
- Aspose.Slides
description: "تطبيق وإنشاء وتعديل تخطيطات الشرائح في Aspose.Slides لـ Python عبر .NET، إضافة عناصر نائب، إزالة التخطيطات غير المستخدمة، والتحكم في إظهار التذييل."
---
## **نظرة عامة**

يحدد تخطيط الشريحة مواضع وتنسيق العناصر النائبة مثل العناوين والنصوص والصور والمخططات والجداول. يضيف تطبيق تخطيط هيكلًا متسقًا للشرائح مع السماح لكل شريحة بأن تحتوي على محتواها الخاص.

أكثر التخطيطات شيوعًا هي:

- **شريحة العنوان**: تحتوي على عناصر عنوان وعنوان فرعي.
- **العنوان والمحتوى**: يحتوي على عنصر عنوان وعنصر محتوى عام.
- **فارغة**: لا تحتوي على عناصر محتوى وتكون مفيدة عندما يتم وضع كل شكل يدوياً.

## **فهم وراثة التخطيط**

العرض التقديمي يحتوي على ثلاثة مستويات مرتبطة:

1. شريحة [master slide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslide/) تحدد السمة، التنسيق المشترك، الخلفيات، والكائنات العامة.
2. شريحة [layout slide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutslide/) تنتمي إلى رئيس وتحدد ترتيبًا معينًا لعناصر النائب.
3. شريحة [normal slide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/) تستخدم تخطيطًا واحدًا وتخزن المحتوى المدخل لتلك الشريحة.

تورّث الشريحة العادية السمة والتنسيق من تخطيطها، ويورّث التخطيط من رئيسه. أي قيمة تُحدَّد مباشرةً على الشريحة العادية تتجاوز القيمة الموروثة في ذلك المستوى. عند إنشاء شريحة عادية، تُنشأ أشكال العناصر النائبة منها بناءً على التخطيط المختار، بينما يكون المحتوى المدخل في تلك العناصر النائبة تابعًا للشريحة العادية.

أضف العناصر النائبة المطلوبة إلى التخطيط قبل إنشاء الشرائح منه. إضافة عنصر نائب آخر إلى التخطيط لاحقًا لا يضيف تلقائيًا شكل عنصر نائب مماثل إلى الشرائح العادية الموجودة.

لهذا العلاقة نتيجتين مهمتين:

- تغيير التنسيق الموروث أو شكل العنصر النائب الموجود في التخطيط يمكن أن يحدّث كل الشريحة التي تعتمد عليه. قبل تعديل تخطيط قيد الاستخدام بالفعل، راجع الشرائح التابعة له واطلع على العرض الناتج.
- لا يمكن حذف تخطيط لا يزال مستخدمًا من قبل شريحة. أعد تعيين الشرائح التابعة له إلى تخطيط آخر أولاً، أو احذف التخطيطات غير المستخدمة فقط.

لمزيد من المعلومات حول المستوى العلوي لهذه الهرمية، راجع [Slide Master](/slides/ar/python-net/slide-master/).

## **اختيار وتطبيق تخطيط شريحة**

استخدم نوع تخطيط عندما يتبع العرض التعريفات القياسية لتخطيطات PowerPoint. أسماء التخطيطات قابلة للتحرير من قبل المستخدم ويمكن تعريبها، لذا فإن الاختيار بناءً على الاسم أقل موثوقية ما لم تتحكم في القالب المصدر.

المثال التالي يبحث عن **Title and Content** في أول رئيس. إذا كان ذلك التخطيط غير متاح، فإنه يعود عمدًا إلى **Blank**. الفحص الثاني للـ null ضروري لأن العرض قد يحتوي فقط على تخطيطات مخصصة. بعد ذلك يتم تطبيق التخطيط المختار على أول شريحة عادية عبر الخاصية [Slide.layout_slide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/layout_slide/).

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slides = presentation.masters[0].layout_slides
    target_layout = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if target_layout is None:
        target_layout = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if target_layout is None:
        raise RuntimeError("The first master does not contain a suitable layout slide.")

    presentation.slides[0].layout_slide = target_layout
    presentation.save("output-with-new-layout.pptx", slides.export.SaveFormat.PPTX)
```

تغيير تخطيط الشريحة لا يزيل الأشكال العادية التي أضيفت مباشرةً إلى الشريحة. ومع ذلك، قد تتغير مواضع العناصر النائبة، والتنسيق الموروث، والارتباط بين العناصر النائبة الموجودة والتخطيط الجديد، لذا راجع الناتج عند التبديل بين تخطيطات مختلفة اختلافًا كبيرًا.

## **إضافة شريحة تخطيط**

الاختيار والإنشاء عمليات منفصلة. المثال السابق يختار تخطيطًا موجودًا؛ لا ينشئ واحدًا. لإنشاء تخطيط، استدعِ طريقة [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterlayoutslidecollection/add/) على مجموعة تخطيطات الرئيس المستهدف.

المثال التالي يضيف دائمًا تخطيطًا جديدًا **Title and Content** باسم `Report Title and Content`، ثم يضيف شريحة عادية بناءً عليه. يجب أن تكون أسماء التخطيطات فريدة داخل المجموعة.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

أضف تخطيطًا فقط عندما يحتاج القالب فعلاً إلى هيكل قابل لإعادة الاستخدام آخر. إذا كان هناك تخطيط مناسب موجود بالفعل، فاختره وأعد استخدامه بدلًا من إنشاء نسخة مكررة.

## **إضافة عناصر نائبة إلى شريحة تخطيط**

توفر الخاصية [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutslide/placeholder_manager/) كائنًا من النوع [LayoutPlaceholderManager](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutplaceholdermanager/) لإضافة أشكال عناصر نائبة إلى التخطيط.

| العنصر النائب في PowerPoint | طريقة `LayoutPlaceholderManager` |
| --------------------------- | --------------------------------- |
| ![المحتوى](content.png) | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![المحتوى (عمودي)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![نص](text.png) | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![نص (عمودي)](textV.png) | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![صورة](picture.png) | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![مخطط](chart.png) | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![جدول](table.png) | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png) | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![وسائط](media.png) | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![صورة عبر الإنترنت](onlineImage.png) | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

المثال التالي يتحقق من وجود تخطيط **Blank**، يضيف أربعة عناصر نائبة إليه، ثم ينشئ شريحة عادية تستخدم التخطيط المعدل. الترتيب متعمد: تُضاف العناصر النائبة قبل إنشاء الشريحة العادية، بحيث يمكن Aspose.Slides توليد أشكال العناصر النائبة المقابلة على تلك الشريحة.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout is None:
        raise RuntimeError("The presentation does not contain a Blank layout slide.")

    placeholder_manager = blank_layout.placeholder_manager
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    presentation.slides.add_empty_slide(blank_layout)
    presentation.save("output-with-placeholders.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![العناصر النائبة على شريحة التخطيط](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
تغيير التنسيق الموروث أو شكل العناصر النائبة الموجودة في التخطيط يمكن أن يؤثر على الشرائح التابعة. العنصر النائب المُضاف حديثًا لا يُملأ تلقائيًا في الشرائح العادية الموجودة. اختبر تغييرات التخطيط على نسخة من العرض وراجع كل شريحة تابعة.
{{% /alert %}}

## **إزالة تخطيطات الشرائح غير المستخدمة**

استخدام الطريقة [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) لإزالة التخطيطات التي لا تُشير إليها أي شريحة عادية. تترك الطريقة التخطيطات التي لا تزال قيد الاستخدام كما هي.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

لإزالة تخطيط محدد، استخدم أولاً خاصية [has_depending_slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutslide/has_depending_slides/) أو طريقة [get_depending_slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutslide/get_depending_slides/). أعد تعيين أي شرائح تابعة قبل استدعاء [LayoutSlide.remove](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutslide/remove/). محاولة إزالة تخطيط مستخدم تُثير استثناءً من نوع [PptxEditException](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pptxeditexception/).

## **التحكم في مرئية التذييل على شريحة تخطيط**

يحتوي التخطيط على تذييل خاص به، ورقم الشريحة، وعناصر نائبة للوقت والتاريخ. استخدم الخاصية [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutslide/header_footer_manager/) للتحكم في تلك العناصر النائبة لتخطيط واحد. يكون ذلك مفيدًا عندما، على سبيل المثال، يجب أن تُظهر تخطيطات المحتوى التذييلات لكن لا ينبغي لتخطيطات العنوان إظهارها.

المثال التالي يختار تخطيطًا بأمان ويجعل عناصر التذييل مرئية:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if layout_slide is None:
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if layout_slide is None:
        raise RuntimeError("The presentation does not contain a suitable layout slide.")

    header_footer_manager = layout_slide.header_footer_manager
    header_footer_manager.set_footer_visibility(True)
    header_footer_manager.set_slide_number_visibility(True)
    header_footer_manager.set_date_time_visibility(True)
    header_footer_manager.set_footer_text("Footer text")
    header_footer_manager.set_date_time_text("Date and time text")

    presentation.save("output-with-layout-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **التحكم في مرئية التذييل على رئيس وتخطيطات الأبن التابعة له**

لتطبيق إعدادات تذييل متسقة عبر تسلسل هرمي للرئيس، استخدم الخاصية [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslide/header_footer_manager/). تعمل طرق النشر في [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslideheaderfootermanager/) على الرئيس وتخطيطات الأبن التابعة له والشرائح العادية؛ لا تستهدف شريحة عادية واحدة فقط.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager
    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)
    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output-with-master-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة الشائعة**

**ما الفرق بين شريحة رئيس وشريحة تخطيط؟**

تحدد شريحة الرئيس سمة العرض والتنسيق المشترك. تنتمي شريحة التخطيط إلى رئيس وتحدد ترتيبًا قابلاً لإعادة الاستخدام للعناصر النائبة. تستخدم الشرائح العادية تلك التخطيطات وتخزن محتوىً خاصًا بكل شريحة.

**هل يمكنني نسخ شريحة تخطيط من عرض تقديمي إلى آخر؟**

نعم. أضف نسخة إلى مجموعة الوجهة باستخدام طريقة [add_clone](https://reference.aspose.com/slides/ar/python-net/aspose.slides/globallayoutslidecollection/add_clone/). عند النسخ بين العروض، تحقق أيضًا من الخطوط، والسمات، والصور، وغيرها من الموارد المستخدمة في التخطيط المصدر.

**ماذا يحدث عندما أقوم بتعديل تخطيط قيد الاستخدام بالفعل؟**

تورّث الشرائح التابعة التغييرات في التخطيط ما لم تقم بتجاوز التنسيق أو الكائنات المتأثرة محليًا. قد يتغير شكل العناصر النائبة والتنسيق الموروث على العديد من الشرائح دفعة واحدة. استخدم [get_depending_slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutslide/get_depending_slides/) لتحديد الشرائح المتأثرة قبل تحرير التخطيط.

**ماذا يحدث إذا قمت بإزالة تخطيط لا يزال قيد الاستخدام؟**

تُثير Aspose.Slides استثناءً من نوع [PptxEditException](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pptxeditexception/). أعد تعيين الشرائح التابعة أولاً، أو استخدم [remove_unused_layout_slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) لإزالة التخطيطات غير المرجعية فقط.