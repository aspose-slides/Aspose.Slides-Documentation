---
title: تخطيط الشريحة
type: docs
weight: 60
url: /ar/python-net/slide-layout/
keyword: "تعيين حجم الشريحة، تعيين خيارات الشريحة، تحديد حجم الشريحة، رؤية التذييل، تذييل فرعي، توسيع المحتوى، حجم الصفحة، بايثون، Aspose.Slides"
description: "تعيين حجم الشريحة وخياراتها في PowerPoint باستخدام بايثون"
---

يتضمن تخطيط الشريحة مربعات النماذج ومعلومات التنسيق لجميع المحتويات التي تظهر في الشريحة. يحدد التخطيط أماكن النماذج المتاحة وأماكن وضعها.

تسمح تخطيطات الشرائح لك بإنشاء وتصميم العروض التقديمية بسرعة (سواء كانت بسيطة أو معقدة). هذه بعض من أكثر تخطيطات الشرائح شيوعاً المستخدمة في عروض PowerPoint:

* **تخطيط شريحة العنوان**. يتكون هذا التخطيط من نموذجين نصيين. نموذج واحد للعنوان والآخر للرئيسية.
* **تخطيط العنوان والمحتوى**. يحتوي هذا التخطيط على نموذج صغير نسبيًا في الأعلى للعنوان ونموذج أكبر للمحتوى الأساسي (مخطط، فقرات، قائمة نقطية، قائمة مرقمة، صور، إلخ).
* **تخطيط فارغ**. يفتقر هذا التخطيط للنماذج، لذا فإنه يسمح لك بإنشاء العناصر من الصفر.

نظرًا لأن الشريحة الرئيسية هي أعلى شريحة هرمية تخزن معلومات حول تخطيطات الشرائح، يمكنك استخدام الشريحة الرئيسية للوصول إلى تخطيطات الشرائح وإجراء تغييرات عليها. يمكن الوصول إلى شريحة التخطيط عن طريق النوع أو الاسم. وبالمثل، تحتوي كل شريحة على معرف فريد، يمكن استخدامه للوصول إليها.

بدلاً من ذلك، يمكنك إجراء تغييرات مباشرة على تخطيط شريحة معينة في عرض تقديمي.

* للسماح لك بالعمل مع تخطيطات الشرائح (بما في ذلك تلك الموجودة في الشرائح الرئيسية)، توفر Aspose.Slides خصائص مثل `layout_slides` و `masters` تحت class [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
* لأداء المهام ذات الصلة، توفر Aspose.Slides [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/)، [MasterLayoutSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterlayoutslidecollection/)، [SlideSize](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/)، [BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/python-net/aspose.slides/baseslideheaderfootermanager/)، والعديد من الأنواع الأخرى.

{{% alert title="معلومات" color="info" %}}

للحصول على مزيد من المعلومات حول العمل مع الشرائح الرئيسية بشكل خاص، راجع المقالة [Slide Master](https://docs.aspose.com/slides/python-net/slide-master/).

{{% /alert %}}

## **إضافة تخطيط شريحة إلى العرض التقديمي**

1. قم بإنشاء مثيل class [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الوصول إلى [مجموعة MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasterlayoutslidecollection/).
1. مرور عبر شرائح التخطيط الموجودة للتأكد من أن شريحة التخطيط المطلوبة موجودة في مجموعة تخطيطات الشرائح. خلاف ذلك، أضف شريحة التخطيط التي تريدها.
1. أضف شريحة فارغة بناءً على شريحة التخطيط الجديدة.
1. احفظ العرض التقديمي.

يوضح كود بايثون هذا كيفية إضافة تخطيط شريحة إلى عرض PowerPoint:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# يتم إنشاء مثيل من class Presentation الذي يمثل ملف العرض التقديمي
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # يمر عبر أنواع تخطيط الشرائح
    layoutSlides = presentation.masters[0].layout_slides
    layoutSlide = layoutSlides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)  
    if layoutSlide is None:
         layoutSlide = layoutSlides.get_by_type(slides.SlideLayoutType.TITLE)

    if layoutSlide is None:
        # الحالة التي لا يحتوي فيها العرض التقديمي على بعض أنواع التخطيطات.
        # يحتوي ملف العرض التقديمي فقط على أنواع تخطيطات فارغة ومخصصة.
        # ولكن الشرائح التخطيطية من أنواع مخصصة لها أسماء شرائح مختلفة،
        # مثل "عنوان"، "عنوان ومحتوى"، إلخ. ومن الممكن استخدام هذه
        # الأسماء لاختيار شريحة التخطيط.
        # يمكنك أيضًا استخدام مجموعة من أنواع شكلي النماذج. على سبيل المثال،
        # يجب أن تحتوي شريحة العنوان على نوع نموذج عنوان فقط، إلخ.
        for titleAndObjectLayoutSlide in layoutSlides:
            if titleAndObjectLayoutSlide.name == "Title and Object":
                layoutSlide = titleAndObjectLayoutSlide
                break

        if layoutSlide is None:
            for titleLayoutSlide in layoutSlides:
                if titleLayoutSlide.name == "Title":
                    layoutSlide = titleLayoutSlide
                    break

            if layoutSlide is None:
                layoutSlide = layoutSlides.get_by_type(slides.SlideLayoutType.BLANK)
                if layoutSlide is None:
                    layoutSlide = layoutSlides.Add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Title and Object")

    # يضيف شريحة فارغة مع إضافة شريحة التخطيط
    presentation.slides.insert_empty_slide(0, layoutSlide)

    # يحفظ العرض التقديمي على القرص
    presentation.save("AddLayoutSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **إزالة شريحة التخطيط غير المستخدمة**

توفر Aspose.Slides طريقة `remove_unused_layout_slides` من class [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) للسماح لك بحذف الشرائح التخطيطية غير المرغوب فيها وغير المستخدمة. يوضح كود بايثون هذا كيفية إزالة شريحة التخطيط من عرض PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slides.lowcode.Compress.remove_unused_layout_slides(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين الحجم والنوع لتخطيط الشريحة**

للسماح لك بتعيين الحجم والنوع لشريحة تخطيط معينة، توفر Aspose.Slides خصائص `type` و `size` (من class [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)). يوضح هذا الكود في بايثون العملية:

```python
import aspose.slides as slides

// قم بإنشاء كائن Presentation يمثل ملف عرض تقديمي 
# يتم إنشاء كائن Presentation يمثل ملف عرض تقديمي 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    with slides.Presentation() as auxPresentation:
        slide = presentation.slides[0]

        # تعيين حجم الشريحة للعرض التقديمي الناتج إلى ما يخص المصدر
        auxPresentation.slide_size.set_size(presentation.slide_size.type, slides.SlideSizeScaleType.ENSURE_FIT)

        auxPresentation.slides.insert_clone(0, slide)
        auxPresentation.slides.remove_at(0)
        # يحفظ العرض التقديمي على القرص
        auxPresentation.save("Set_Size&Type_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين رؤية التذييل داخل الشريحة**

1. قم بإنشاء مثيل من class [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مرجع الشريحة من خلال فهرسها.
1. اجعل نموذج تذييل الشريحة مرئيًا.
1. اجعل نموذج التاريخ والوقت مرئيًا.
1. احفظ العرض التقديمي.

يوضح كود بايثون هذا كيفية تعيين الرؤية لتذييل الشريحة (وأداء المهام ذات الصلة):

```python
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    headerFooterManager = presentation.slides[0].header_footer_manager
    # يتم استخدام الخاصية is_footer_visible لتحديد ما إذا كان نموذج تذييل الشريحة مفقودًا
    if not headerFooterManager.is_footer_visible: 
        # يتم استخدام الطريقة set_footer_visibility لتعيين نموذج تذييل الشريحة ليكون مرئيًا
        headerFooterManager.set_footer_visibility(True) 
        # يتم استخدام الخاصية is_slide_number_visible لتحديد ما إذا كان نموذج رقم الشريحة مفقودًا
    if not headerFooterManager.is_slide_number_visible:  
        # يتم استخدام الطريقة set_slide_number_visibility لتعيين نموذج رقم الشريحة ليكون مرئيًا
        headerFooterManager.set_slide_number_visibility(True) 
        # يتم استخدام الخاصية is_date_time_visible لتحديد ما إذا كان نموذج التاريخ والوقت مفقودًا
    if not headerFooterManager.is_date_time_visible: 
        # يتم استخدام الطريقة set_date_time_visibility لتعيين نموذج التاريخ والوقت ليكون مرئيًا 
        headerFooterManager.set_date_time_visibility(True)

    # يتم استخدام الطريقة set_footer_text لتعيين نص لنموذج تذييل الشريحة 
    headerFooterManager.set_footer_text("نص التذييل") 
    # يتم استخدام الطريقة set_date_time_text لتعيين نص لنموذج التاريخ والوقت.
    headerFooterManager.set_date_time_text("نص التاريخ والوقت") 

    # يحفظ العرض التقديمي على القرص
    presentation.save("Presentation.ppt", slides.export.SaveFormat.PPT)
```

## **تعيين رؤية تذييل الفرع داخل الشريحة**

1. قم بإنشاء مثيل من class [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مرجع للشريحة الرئيسية من خلال فهرسها. 
1. اجعل الشريحة الرئيسية وجميع نماذج تذييل الفرع مرئية.
1. قم بتعيين نص للشريحة الرئيسية وجميع نماذج تذييل الفرع. 
1. قم بتعيين نص للشريحة الرئيسية وجميع نماذج التاريخ والوقت للفرع. 
1. احفظ العرض التقديمي.

يوضح كود بايثون هذا العملية:

```python
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    manager = presentation.masters[0].header_footer_manager
    manager.set_footer_and_child_footers_visibility(True) # يتم استخدام الطريقة set_footer_and_child_footers_visibility لتعيين الشريحة الرئيسية وجميع نماذج تذييل الفرع لتكون مرئية
    manager.set_slide_number_and_child_slide_numbers_visibility(True) # يتم استخدام الطريقة set_slide_number_and_child_slide_numbers_visibility لتعيين الشريحة الرئيسية وجميع نماذج أرقام الصفحات الفرعية لتكون مرئية
    manager.set_date_time_and_child_date_times_visibility(True) # يتم استخدام الطريقة set_date_time_and_child_date_times_visibility لتعيين الشريحة الرئيسية وجميع نماذج التاريخ والوقت للفرع لتكون مرئية

    manager.set_footer_and_child_footers_text("نص التذييل") # يتم استخدام الطريقة set_footer_and_child_footers_text لتعيين النصوص للشريحة الرئيسية وجميع نماذج تذييل الفرع
    manager.set_date_time_and_child_date_times_text("نص التاريخ والوقت") # يتم استخدام الطريقة set_date_time_and_child_date_times_text لتعيين النص للشريحة الرئيسية وجميع نماذج التاريخ والوقت للفرع
```

## **تعيين حجم الشريحة بالنسبة لتوسيع المحتوى**

1. قم بإنشاء مثيل من class [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وتحميل العرض التقديمي الذي يحتوي على الشريحة التي تريد تعيين حجمها. 
1. قم بإنشاء مثيل آخر من class [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) لإنشاء عرض تقديمي جديد. 
1. احصل على مرجع الشريحة (من العرض التقديمي الأول) من خلال فهرسها.
1. اجعل نموذج تذييل الشريحة مرئيًا. 
1. اجعل نموذج التاريخ والوقت مرئيًا. 
1. احفظ العرض التقديمي.

هذا الكود في بايثون يوضح العملية: 

```python
import aspose.slides as slides

# يتم إنشاء كائن Presentation الذي يمثل ملف عرض تقديمي 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    with slides.Presentation() as auxPresentation:
        slide = presentation.slides[0]

        # تعيين حجم الشريحة للعروض التقديمية الناتجة إلى ما يخص المصدر
        presentation.slide_size.set_size(540, 720, slides.SlideSizeScaleType.ENSURE_FIT) # يتم استخدام الطريقة set_size لتعيين حجم الشريحة مع توسيع المحتوى لضمان الملاءمة
        presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.MAXIMIZE) # يتم استخدام الطريقة set_size لتعيين حجم الشريحة بأقصى حجم للمحتوى
                
        # يحفظ العرض التقديمي على القرص
        auxPresentation.save("Set_Size&Type_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين حجم الصفحة عند إنشاء PDF**

تُحوَّل بعض العروض التقديمية (مثل الملصقات) غالبًا إلى ملفات PDF. إذا كنت ترغب في تحويل PowerPoint إلى PDF للحصول على أفضل خيارات الطباعة والوصول، فيجب عليك تعيين شرائحك على أحجام تناسب مستندات PDF (A4، على سبيل المثالي).

توفر Aspose.Slides class [SlideSize](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/) للسماح لك بتحديد إعداداتك المفضلة للشرائح. يوضح كود بايثون هذا كيفية استخدام خاصية `type` (من class `SlideSize`) لتعيين حجم ورق معين للشرائح في عرض تقديمي:

```python
import aspose.slides as slides

# يتم إنشاء كائن Presentation الذي يمثل ملف عرض تقديمي  
with slides.Presentation() as presentation:
    # تعيين خصائص SlideSize.Type 
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.ENSURE_FIT)

    # تعيين خصائص مختلفة لخيارات PDF
    opts = slides.export.PdfOptions()
    opts.sufficient_resolution = 600

    # يحفظ العرض التقديمي على القرص
    presentation.save("SetPDFPageSize_out.pdf", slides.export.SaveFormat.PDF, opts)
```