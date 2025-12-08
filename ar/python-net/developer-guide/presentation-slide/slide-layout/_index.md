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
- تصميم العرض التقديمي
- تصميم الشريحة
- تخطيط غير مستخدم
- رؤية التذييل
- شريحة عنوان
- عنوان ومحتوى
- رأس القسم
- محتويان
- مقارنة
- عنوان فقط
- تخطيط فارغ
- محتوى مع توضيح
- صورة مع توضيح
- عنوان ونص عمودي
- عنوان عمودي ونص
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "تعلم كيفية إدارة وتخصيص تخطيطات الشرائح في Aspose.Slides for Python عبر .NET. استكشف أنواع التخطيطات، التحكم في العناصر النائبة، رؤية التذييل، وتعديل التخطيطات من خلال أمثلة الشيفرة بلغة Python."
---

## **نظرة عامة**

تحدد تخطيط الشريحة ترتيب صناديق العنصر النائب وتنسيق المحتوى على الشريحة. يتحكم في العناصر النائبة المتاحة ومكان ظهورها. تساعد تخطيطات الشرائح في تصميم العروض التقديمية بسرعة وبشكل متسق—سواء كنت تنشئ شيئًا بسيطًا أو أكثر تعقيدًا. من بين أكثر تخطيطات الشرائح شيوعًا في PowerPoint:

**تخطيط شريحة العنوان** – يتضمن عنصرين نصيين نائين: واحد للعنوان وآخر للعنوان الفرعي.

**تخطيط العنوان والمحتوى** – يحتوي على عنصر عنوان أصغر في الأعلى وعنصر أكبر أسفله للمحتوى الرئيسي (مثل النص، النقاط المرتبة، المخططات، الصور، والمزيد).

**تخطيط فارغ** – لا يحتوي على أي عناصر نائبة، مما يمنحك تحكمًا كاملًا لتصميم الشريحة من الصفر.

تعد تخطيطات الشرائح جزءًا من ماستر الشريحة، وهو الشريحة العليا التي تحدد أنماط التخطيط للعرض التقديمي. يمكنك الوصول إلى تخطيطات الشرائح وتعديلها من خلال ماستر الشريحة—إما حسب النوع أو الاسم أو المعرف الفريد. بدلاً من ذلك، يمكنك تعديل تخطيط شريحة معين مباشرة داخل العرض التقديمي.

للعمل مع تخطيطات الشرائح في Aspose.Slides for Python، يمكنك استخدام:

- خصائص مثل [layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/layout_slides/) و[masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) ضمن الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
- أنواع مثل [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/)، [MasterLayoutSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterlayoutslidecollection/)، [LayoutPlaceholderManager](https://reference.aspose.com/slides/python-net/aspose.slides/layoutplaceholdermanager/)، و[LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
لتعلم المزيد حول العمل مع ماسترات الشرائح، اطلع على مقال [Manage PowerPoint Slide Masters in Python](/slides/ar/python-net/slide-master/).
{{% /alert %}}

## **إضافة تخطيطات شرائح إلى العروض التقديمية**

لتخصيص مظهر وهيكل الشرائح الخاصة بك، قد تحتاج إلى إضافة تخطيطات شرائح جديدة إلى عرض تقديمي. يتيح لك Aspose.Slides for Python التحقق مما إذا كان تخطيط معين موجودًا بالفعل، وإضافة واحد جديد إذا لزم الأمر، واستخدامه لإدراج شرائح بناءً على ذلك التخطيط.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الوصول إلى [MasterLayoutSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterlayoutslidecollection/).
1. التحقق مما إذا كان تخطيط الشريحة المطلوب موجودًا بالفعل في المجموعة. إذا لم يكن موجودًا، أضف تخطيط الشريحة الذي تحتاجه.
1. إضافة شريحة فارغة بناءً على تخطيط الشريحة الجديد.
1. حفظ العرض التقديمي.

يظهر الكود التالي بلغة Python كيفية إضافة تخطيط شريحة إلى عرض PowerPoint:
```python
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لفتح ملف العرض التقديمي.
with slides.Presentation("sample.pptx") as presentation:
    # المرور عبر أنواع تخطيطات الشرائح لاختيار تخطيط شريحة.
    layout_slides = presentation.masters[0].layout_slides
    layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)
    if layout_slide is None:
         layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE)

    if layout_slide is None:
        # حالة لا يحتوي فيها العرض التقديمي على جميع أنواع التخطيطات.
        # ملف العرض التقديمي يحتوي فقط على أنواع التخطيط فارغ ومخصص.
        # ومع ذلك، قد تحتوي تخطيطات الشرائح ذات الأنواع المخصصة على أسماء يمكن التعرف عليها،
        # مثل "Title"، "Title and Content"، إلخ، والتي يمكن استخدامها لاختيار تخطيط الشريحة.
        # يمكنك أيضًا الاعتماد على مجموعة من أنواع أشكال العناصر النائبة.
        # على سبيل المثال، يجب أن تحتوي شريحة العنوان على نوع عنصر النائب Title فقط، وهكذا.
        for title_and_object_layout_slide in layout_slides:
            if title_and_object_layout_slide.name == "Title and Object":
                layout_slide = title_and_object_layout_slide
                break

        if layout_slide is None:
            for title_layout_slide in layout_slides:
                if title_layout_slide.name == "Title":
                    layout_slide = title_layout_slide
                    break

            if layout_slide is None:
                layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
                if layout_slide is None:
                    layout_slide = layout_slides.Add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Title and Object")

    # إضافة شريحة فارغة باستخدام تخطيط الشريحة المضاف.
    presentation.slides.insert_empty_slide(0, layout_slide)

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **إزالة تخطيطات الشرائح غير المستخدمة**

توفر Aspose.Slides الطريقة [remove_unused_layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) من الفئة [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) لتسمح لك بحذف تخطيطات الشرائح غير المرغوبة وغير المستخدمة.

يظهر الكود التالي بلغة Python كيفية إزالة تخطيط شريحة من عرض PowerPoint:
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **إضافة عناصر نائبة إلى تخطيطات الشرائح**

توفر Aspose.Slides الخاصية [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/placeholder_manager/)، والتي تتيح لك إضافة عناصر نائبة جديدة إلى تخطيط شريحة.

يحتوي هذا المدير على طرق للأنواع التالية من العناصر النائبة:

| عنصر نائب في PowerPoint | طريقة [LayoutPlaceholderManager](https://reference.aspose.com/slides/python-net/aspose.slides/layoutplaceholdermanager/) |
| --- | --- |
| ![Content](content.png) | add_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Content (Vertical)](contentV.png) | add_vertical_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Text](text.png) | add_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Text (Vertical)](textV.png) | add_vertical_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Picture](picture.png) | add_picture_placeholder(x: float, y: float, width: float, height: float) |
| ![Chart](chart.png) | add_chart_placeholder(x: float, y: float, width: float, height: float) |
| ![Table](table.png) | add_table_placeholder(x: float, y: float, width: float, height: float) |
| ![SmartArt](smartart.png) | add_smart_art_placeholder(x: float, y: float, width: float, height: float) |
| ![Media](media.png) | add_media_placeholder(x: float, y: float, width: float, height: float) |
| ![Online Image](onlineimage.png) | add_online_image_placeholder(x: float, y: float, width: float, height: float) |

يظهر الكود التالي بلغة Python كيفية إضافة أشكال عناصر نائبة جديدة إلى تخطيط الشريحة الفارغة:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # الحصول على شريحة التخطيط الفارغ.
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # الحصول على مدير العناصر النائبة لشريحة التخطيط.
    placeholder_manager = layout.placeholder_manager

    # إضافة عناصر نائبة مختلفة إلى شريحة التخطيط الفارغ.
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    # إضافة شريحة جديدة باستخدام التخطيط الفارغ.
    new_slide = presentation.slides.add_empty_slide(layout)

    presentation.save("placeholders.pptx", slides.export.SaveFormat.PPTX)
```


النتيجة:

![The placeholders on the layout slide](add_placeholders.png)

## **تحديد رؤية تذييل الشريحة لتخطيط معين**

في عروض PowerPoint، يمكن إظهار أو إخفاء عناصر التذييل مثل التاريخ، رقم الشريحة، والنص المخصص بحسب تخطيط الشريحة. يتيح لك Aspose.Slides for Python التحكم في رؤية هذه العناصر النائبة للتذييل. هذا مفيد عندما تريد أن تعرض بعض التخطيطات معلومات التذييل بينما تبقى أخرى نظيفة ومبسطة.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع لتخطيط الشريحة حسب الفهرس.
1. تعيين عنصر تذييل الشريحة إلى مرئي.
1. تعيين عنصر رقم الشريحة إلى مرئي.
1. تعيين عنصر التاريخ/الوقت إلى مرئي.
1. حفظ العرض التقديمي.

يظهر الكود التالي بلغة Python كيفية تعيين رؤية تذييل الشريحة وأداء المهام ذات الصلة:
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    header_footer_manager = presentation.layout_slides[0].header_footer_manager

    if not header_footer_manager.is_footer_visible: 
        header_footer_manager.set_footer_visibility(True) 

    if not header_footer_manager.is_slide_number_visible:  
        header_footer_manager.set_slide_number_visibility(True) 

    if not header_footer_manager.is_date_time_visible: 
        header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_footer_text("Footer text") 
    header_footer_manager.set_date_time_text("Date and time text") 

    presentation.save("output.ppt", slides.export.SaveFormat.PPT)
```


## **تحديد رؤية تذييل الأطفال لشريحة**

​في عروض PowerPoint، يمكن التحكم في عناصر التذييل مثل التاريخ، رقم الشريحة، والنص المخصص على مستوى ماستر الشريحة لضمان الاتساق عبر جميع تخطيطات الشرائح. يتيح لك Aspose.Slides for Python تعيين رؤية ومحتوى هذه العناصر النائبة للتذييل على ماستر الشريحة ونشر هذه الإعدادات إلى جميع تخطيطات الشرائح التابعة. يضمن هذا النهج توحيد معلومات التذييل طوال العرض التقديمي.​

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع للماستر شريحة حسب الفهرس.
1. تعيين جميع عناصر تذييل الماستر وتذييلات الأطفال إلى مرئية.
1. تعيين جميع عناصر رقم الشريحة للماستر والأطفال إلى مرئية.
1. تعيين جميع عناصر التاريخ/الوقت للماستر والأطفال إلى مرئية.
1. حفظ العرض التقديمي.

يظهر الكود التالي بلغة Python هذا الإجراء:
```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager

    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)

    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **الأسئلة المتكررة**

**ما الفرق بين ماستر الشريحة وتخطيط الشريحة؟**

ماستر الشريحة يحدد الهوية العامة والتهيئة الافتراضية، بينما يحدد تخطيط الشريحة ترتيبات محددة للعناصر النائبة لأنواع مختلفة من المحتوى.

**هل يمكنني نسخ تخطيط شريحة من عرض تقديمي إلى آخر؟**

نعم، يمكنك استنساخ تخطيط شريحة من مجموعة [layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/layout_slides/) لعرض تقديمي وإدراجه في عرض آخر باستخدام طريقة `add_clone`.

**ماذا يحدث إذا حذفت تخطيط شريحة ما زال مستخدمًا من قبل شريحة؟**

إذا حاولت حذف تخطيط شريحة لا يزال مُشارًا إليه من قبل شريحة واحدة على الأقل في العرض، سيتسبب Aspose.Slides في إلقاء استثناء [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/). لتجنب ذلك، استخدم طريقة [remove_unused_layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) التي تحذف بأمان فقط تخطيطات الشرائح غير المستخدمة.