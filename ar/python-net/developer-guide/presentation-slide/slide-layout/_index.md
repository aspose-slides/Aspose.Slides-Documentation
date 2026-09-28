---
title: "تطبيق أو تغيير تخطيطات الشرائح في بايثون"
linktitle: "تخطيط الشريحة"
type: docs
weight: 60
url: /ar/python-net/slide-layout/
keywords:
- "تخطيط الشريحة"
- "تخطيط المحتوى"
- "عنصر نائب"
- "تصميم العرض التقديمي"
- "تصميم الشريحة"
- "تخطيط غير مستخدم"
- "إظهار التذييل"
- "شريحة عنوان"
- "العنوان والمحتوى"
- "عنوان القسم"
- "محتوى مزدوج"
- "مقارنة"
- "عنوان فقط"
- "تخطيط فارغ"
- "محتوى مع توضيح"
- "صورة مع توضيح"
- "عنوان ونص عمودي"
- "عنوان عمودي ونص"
- "PowerPoint"
- "OpenDocument"
- "عرض تقديمي"
- "Python"
- "Aspose.Slides"
description: "تطبيق وإنشاء وتعديل تخطيطات الشرائح في Aspose.Slides للبايثون عبر .NET، إضافة عناصر نائبة، إزالة التخطيطات غير المستخدمة، والتحكم في إظهار التذييل."
---
## **نظرة عامة**

يحدد تخطيط الشريحة مواضع وتنسيق العناصر النائبة مثل العناوين والنصوص والصور والرسوم البيانية والجداول. يتيح تطبيق التخطيط للشرائح بنية متسقة مع السماح لكل شريحة باحتواء محتواها الخاص.

تشمل التخطيطات الأكثر شيوعًا:

- **شريحة عنوان**: تحتوي على عناصر نائبة للعنوان والعنوان الفرعي.
- **العنوان والمحتوى**: تحتوي على عنصر نائب للعنوان وعنصر نائب للمحتوى عام الاستخدام.
- **فارغ**: لا يحتوي على عناصر نائبة للمحتوى ويكون مفيدًا عندما يتم وضع كل شكل يدويًا.

## **فهم وراثة التخطيط**

للعرض ثلاثة مستويات مرتبطة:

1. تُعرّف [شريحة رئيسية](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslide/) السمة، التنسيق المشترك، الخلفيات، والكائنات العامة.
2. تنتمي [شريحة تخطيط](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutslide/) إلى شريحة رئيسية وتحدد ترتيبًا معينًا للعناصر النائبة.
3. تستخدم [شريحة عادية](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/) تخطيطًا واحدًا وتخزن المحتوى المُدخل لهذه الشريحة.

توارث الشريحة العادية السمة والتنسيق من تخطيطها، ويورّث التخطيط من الشريحة الرئيسة. القيمة التي تُحدد مباشرةً على الشريحة العادية تتجاوز القيمة الموروثة في ذلك المستوى. عند إنشاء شريحة عادية، تُولد أشكال العناصر النائبة من التخطيط المحدد، بينما المحتوى المُدخل في تلك العناصر النائبة يُنتمي إلى الشريحة العادية.

أضف العناصر النائبة المطلوبة إلى التخطيط قبل إنشاء شرائح منه. إضافة عنصر نائب آخر إلى التخطيط لاحقًا لا يضيف تلقائيًا شكل عنصر نائب مطابق إلى الشرائح العادية الموجودة.

للعلاقة نتيجةان مهمتان:

- يمكن أن يؤدي تغيير التنسيق الموروث أو هندسة العناصر النائبة الموجودة في التخطيط إلى تحديث كل شريحة تعتمد عليه. قبل تعديل تخطيط قيد الاستخدام بالفعل، افحص الشرائح التابعة له وراجع العرض الناتج.
- لا يمكن حذف تخطيط لا يزال يُستخدم من قبل شريحة. أعد تعيين الشرائح التابعة له إلى تخطيط آخر أولاً، أو احذف فقط التخطيطات غير المستخدمة.

لمزيد من المعلومات حول المستوى الأعلى من هذه الهرمية، راجع [الشريحة الرئيسية](/slides/ar/python-net/slide-master/).

لإخفاء الشعارات الموروثة أو الأشكال الزخرفية في الشريحة الرئيسة على شريحة واحدة أو من خلال تخطيط مشترك، راجع [التحكم في إظهار رسومات الشريحة الرئيسة](/slides/ar/python-net/slide-master/). المقارنة توضح مثالًا بين شريحتين تستخدمان نفس الشريحة الرئيسة.

## **اختيار وتطبيق تخطيط شريحة**

استخدم نوع التخطيط عندما يتبع العرض تعريفات تخطيطات PowerPoint القياسية. يمكن للمستخدم تحرير أسماء التخطيطات ويمكن تعريبها، لذا فإن الاختيار بناءً على الاسم أقل موثوقية ما لم تتحكم في القالب المصدر.

المثال التالي يبحث عن **العنوان والمحتوى** في الشريحة الرئيسة الأولى. إذا كان ذلك التخطيط غير متوفر، فإنه يعيد التبديل عمدًا إلى **فارغ**. الفحص الثاني للnull ضروري لأن العرض قد يحتوي فقط على تخطيطات مخصصة. ثم يُطبق التخطيط المختار على الشريحة العادية الأولى عبر خاصية [Slide.layout_slide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/layout_slide/).

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

تغيير تخطيط الشريحة لا يُزيل الأشكال العادية المضافة مباشرةً إلى الشريحة. ومع ذلك، قد تتغير مواضع العناصر النائبة، التنسيق الموروث، والارتباط بين العناصر النائبة الحالية والتخطيط الجديد، لذا افحص النتيجة عند التبديل بين تخطيطات مختلفة بشكل كبير.

## **إضافة شريحة تخطيط**

الاختيار والإنشاء عمليتان منفصلتان. المثال السابق يحدد تخطيطًا موجودًا؛ لا ينشئ واحدًا. لإنشاء تخطيط، استدعِ طريقة [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterlayoutslidecollection/add/) على مجموعة تخطيط الشريحة الرئيسة المستهدفة.

المثال التالي يضيف دائمًا تخطيطًا جديدًا **العنوان والمحتوى** باسم `Report Title and Content`، ثم يضيف شريحة عادية تستند إليه. يجب أن تكون أسماء التخطيطات فريدة داخل المجموعة.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

أضف تخطيطًا فقط عندما يحتاج القالب فعليًا إلى بنية قابلة لإعادة الاستخدام أخرى. إذا كان هناك تخطيط مناسب موجودًا بالفعل، فحدد وأعِده استخدامه بدلًا من إنشاء نسخة مكررة.

## **إضافة عناصر نائبة إلى شريحة تخطيط**

توفر خاصية [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutslide/placeholder_manager/) كائنًا من نوع [LayoutPlaceholderManager](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutplaceholdermanager/) لإضافة أشكال العناصر النائبة إلى التخطيط.

| العنصر النائب في PowerPoint | `LayoutPlaceholderManager` Method |
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

يتحقق المثال التالي من وجود التخطيط **فارغ**، ويضيف أربعة عناصر نائبة إليه، ثم ينشئ شريحة عادية تستخدم التخطيط المعدل. الترتيب متعمد: تُضاف العناصر النائبة قبل إنشاء الشريحة العادية، بحيث يستطيع Aspose.Slides توليد أشكال العناصر النائبة المطابقة على تلك الشريحة.

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
يمكن أن يؤثر تغيير التنسيق الموروث أو هندسة العناصر النائبة الموجودة في التخطيط على الشرائح التابعة. لا يتم ملء عنصر نائب التخطيط المضاف حديثًا إلى الشرائح العادية الموجودة. اختبر تغييرات التخطيط على نسخة من العرض وتفقد كل شريحة تابعة.
{{% /alert %}}

## **إزالة تخطيطات الشرائح غير المستخدمة**

استخدم طريقة [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) لإزالة التخطيطات التي لا تُشير إليها أي شريحة عادية. تترك الطريقة التخطيطات التي لا تزال قيد الاستخدام دون تغيير.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

لإزالة تخطيط محدد واحد، استخدم أولاً خاصية [has_depending_slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutslide/has_depending_slides/) أو طريقة [get_depending_slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutslide/get_depending_slides/). أعد تعيين أي شرائح تابعة قبل استدعاء [LayoutSlide.remove](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutslide/remove/). محاولة إزالة تخطيط قيد الاستخدام يثير استثناءً من نوع [PptxEditException](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pptxeditexception/).

## **التحكم في إظهار التذييل على شريحة تخطيط**

يحتوي التخطيط على تذييل خاص به، وعناصر نائبة لرقم الشريحة، وتاريخ/وقت. استخدم خاصية [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutslide/header_footer_manager/) للتحكم في تلك العناصر النائبة لتخطيط واحد. يكون ذلك مفيدًا عندما، على سبيل المثال، يجب أن تُظهر تخطيطات المحتوى التذييل بينما لا تُظهر تخطيطات العنوان ذلك.

المثال التالي يختار تخطيطًا بأمان ويجعل عناصر تذييله مرئية:

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

## **التحكم في إظهار التذييل على الشريحة الرئيسة وتخطيطاتها الفرعية**

لتطبيق إعدادات تذييل متسقة عبر هيكلية الشريحة الرئيسة، استخدم خاصية [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslide/header_footer_manager/). تعمل طرق النشر الخاصة بـ [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslideheaderfootermanager/) على الشريحة الرئيسة وتخطيطاتها الفرعية والشُرائح العادية التابعة؛ ولا تستهدف شريحة عادية واحدة فقط.

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

## **الأسئلة المتكررة**

**ما هو الفرق بين الشريحة الرئيسة وشريحة التخطيط؟**

تُعرّف الشريحة الرئيسة سمة العرض والتنسيق المشترك. تنتمي شريحة التخطيط إلى الشريحة الرئيسة وتحدد ترتيبًا قابلاً لإعادة الاستخدام للعناصر النائبة. تستخدم الشرائح العادية هذه التخطيطات وتخزن المحتوى الخاص بكل شريحة.

**هل يمكنني نسخ شريحة تخطيط من عرض إلى آخر؟**

نعم. أضف نسخة إلى مجموعة الوجهة باستخدام طريقة [add_clone](https://reference.aspose.com/slides/ar/python-net/aspose.slides/globallayoutslidecollection/add_clone/). عند النسخ بين عروض، تحقق أيضًا من الخطوط والسمات والصور والموارد الأخرى المستخدمة في التخطيط المصدر.

**ماذا يحدث عندما أقوم بتعديل تخطيط يتم استخدامه بالفعل؟**

تورّث الشرائح التابعة تغييرات التخطيط ما لم تقم بتجاوز التنسيق أو الكائنات المتأثرة محليًا. يمكن أن تتغير هندسة العناصر النائبة وتنسيقها الموروث على العديد من الشرائح دفعة واحدة. استخدم [get_depending_slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutslide/get_depending_slides/) لتحديد الشرائح المتأثرة قبل تعديل التخطيط.

**ماذا يحدث إذا أزلت تخطيطًا لا يزال قيد الاستخدام؟**

يقوم Aspose.Slides بإثارة استثناءً من نوع [PptxEditException](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pptxeditexception/). أعد تعيين الشرائح التابعة أولاً، أو استخدم [remove_unused_layout_slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) لإزالة التخطيطات غير المرجعية فقط.