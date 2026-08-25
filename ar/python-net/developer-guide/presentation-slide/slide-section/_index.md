---
title: إدارة أقسام الشرائح في العروض التقديمية باستخدام Python
linktitle: قسم الشريحة
type: docs
weight: 100
url: /ar/python-net/slide-section/
keywords:
- إنشاء قسم
- إضافة قسم
- تحرير قسم
- تغيير قسم
- اسم القسم
- استرجاع شرائح القسم
- معالجة شرائح القسم
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "إدارة أقسام الشرائح باستخدام Aspose.Slides للغة Python عبر .NET: إنشاء، إعادة تسمية، إعادة ترتيب، استرجاع، ومعالجة شرائح الأقسام في عروض PPTX التقديمية."
---
## **مقدمة**

تقوم الأقسام بتنظيم الشرائح المتتالية في مجموعات مسماة دون تغيير محتوى الشريحة. باستخدام Aspose.Slides for Python عبر .NET، يمكنك إنشاء الأقسام وإعادة ترتيبها وإعادة تسميتها وفحصها وإزالتها من خلال الخاصية [Presentation.sections](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/sections/) .

الأقسام مفيدة بشكل خاص عندما:

- يحتاج عرض تقديمي كبير إلى تقسيمه إلى مواضيع أو فصول منطقية؛
- تُعطى مجموعات مختلفة من الشرائح إلى متعاونين مختلفين؛
- يجب معالجة الشرائح أو نقلها أو دمجها كمجموعات.

اختر أسماء أقسام موجزة تصف هدف الشرائح المجمعة. لأن الأقسام هي جزء من بنية العرض التقديمي، استخدم واجهات برمجة التطبيقات الخاصة بالأقسام لتحديد العضوية بدلاً من استنتاجها من مواضع الشرائح.

## **إنشاء وإدارة الأقسام**

استخدم [SectionCollection.add_section](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sectioncollection/add_section/) لإنشاء قسم عن طريق تحديد اسمه والشريحة البادئة. يحدد Aspose.Slides الشرائح التي تنتمي إلى القسم من هيكل الأقسام الحالي للعرض التقديمي.

تتيح لك نفس [SectionCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sectioncollection/) أيضًا:

- نقل قسم مع الشرائح الخاصة به باستخدام [SectionCollection.reorder_section_with_slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sectioncollection/reorder_section_with_slides/) ;
- إزالة تعريف القسم فقط باستخدام [SectionCollection.remove_section](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sectioncollection/remove_section/) مع الحفاظ على الشرائح؛
- إزالة قسم مع الشرائح باستخدام [SectionCollection.remove_section_with_slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sectioncollection/remove_section_with_slides/) ;
- إضافة قسم فارغ في النهاية باستخدام [SectionCollection.append_empty_section](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sectioncollection/append_empty_section/) .

المثال التالي ينشئ قسمين، يحرك أحدهما، يزيله مع الشرائح الخاصة به، ويضيف قسمًا فارغًا في النهاية:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    title_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    results_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    presentation.sections.add_section("Introduction", title_slide)
    results_section = presentation.sections.add_section("Results", results_slide)

    presentation.sections.reorder_section_with_slides(results_section, 0)
    presentation.sections.remove_section_with_slides(results_section)
    presentation.sections.append_empty_section("Appendix")
```

بعد هذه العمليات، يحتوي العرض التقديمي على قسم `Introduction` مع شرائحه وقسم `Appendix` فارغ. تم إزالة قسم `Results` وشرائحه.

## **إعادة تسمية الأقسام**

لإعادة تسمية قسم، عيّن خاصية [Section.name](https://reference.aspose.com/slides/ar/python-net/aspose.slides/section/name/) الخاصة به. تبقى شرائح القسم وموقعه دون تغيير.

المثال التالي ينشئ قسمًا ويغيّر اسمه:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    section = presentation.sections.add_section("Overview", slide)
    section.name = "Introduction"
```

## **استرجاع الشرائح من الأقسام**

خاصية [Presentation.sections](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/sections/) تُعيد [SectionCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sectioncollection/) يمكنك تكرارها. لكل [Section](https://reference.aspose.com/slides/ar/python-net/aspose.slides/section/)، استدعِ [Section.get_slides_list_of_section](https://reference.aspose.com/slides/ar/python-net/aspose.slides/section/get_slides_list_of_section/) للحصول على الشرائح التي تنتمي إليه حاليًا. تُعيد الطريقة [SectionSlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sectionslidecollection/) التي توفر عددًا، وصولًا مفهرسًا، وتكرارًا.

المثال التالي ينشئ قسمين مُعبّأين وقسمًا فارغًا، ثم يطبع لكل قسم [name](https://reference.aspose.com/slides/ar/python-net/aspose.slides/section/name/) و[identifier](https://reference.aspose.com/slides/ar/python-net/aspose.slides/section/section_id/) و[starting slide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/section/started_from_slide/) وعدد الشرائح وأرقامها. يستخدم وصولًا مفهرسًا لقراءة الشريحة الأولى وحلقة `for` لمعالجة كل شريحة. بالنسبة للقسم الفارغ، تكون المجموعة المُسترجعة عددها صفر، ولا يتم الوصول إلى الفهرس، ولا تؤدي الحلقة إلى أي خطوة.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    third_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])

    presentation.sections.add_section("Introduction", first_slide)
    presentation.sections.add_section("Details", third_slide)
    presentation.sections.append_empty_section("Appendix")

    for section in presentation.sections:
        section_slides = section.get_slides_list_of_section()
        starting_slide = "none" if section.started_from_slide is None else str(section.started_from_slide.slide_number)

        print(f"Section: {section.name}")
        print(f"ID: {section.section_id}")
        print(f"Starting slide: {starting_slide}")
        print(f"Slide count: {section_slides.count}")

        if section_slides.count > 0:
            print(f"First slide via index: {section_slides[0].slide_number}")

        print("Slide numbers:", end="")
        for slide in section_slides:
            print(f" {slide.slide_number}", end="")
        print()
```

تحدد عضوية القسم بواسطة بنية الأقسام في العرض التقديمي. لا تحسب نطاق القسم يدويًا استنادًا إلى [Section.started_from_slide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/section/started_from_slide/) ومؤشرات الشرائح والشريحة البادئة للقسم التالي.

يمكن للتعديلات الهيكلية أن تغيّر كلًا من الشرائح المُسترجعة للقسم وأرقامها. يشمل ذلك إعادة ترتيب الشرائح، استنساخ شريحة داخل قسم، نقل قسم مع شرائحه، إزالة شرائح، وإزالة أقسام. المثال التالي يستدعي [Section.get_slides_list_of_section](https://reference.aspose.com/slides/ar/python-net/aspose.slides/section/get_slides_list_of_section/) بعد كل تغيير من هذا النوع بدلاً من الاعتماد على افتراضات حول حدود القسم السابقة.

```py
import aspose.slides as slides


def print_section_slides(label, section):
    section_slides = section.get_slides_list_of_section()
    print(f"{label} ({section_slides.count} slides):", end="")
    for slide in section_slides:
        print(f" {slide.slide_number}", end="")
    print()


with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    third_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    first_section = presentation.sections.add_section("First", first_slide)
    second_section = presentation.sections.add_section("Second", third_slide)

    print_section_slides("Initially", first_section)

    slides_before_clone = first_section.get_slides_list_of_section()
    presentation.slides.add_clone(slides_before_clone[0], first_section)
    print_section_slides("After cloning into the section", first_section)

    slides_before_reorder = first_section.get_slides_list_of_section()
    first_section_position = slides_before_reorder[0].slide_number - 1
    presentation.slides.reorder(first_section_position, slides_before_reorder[slides_before_reorder.count - 1])
    print_section_slides("After reordering slides", first_section)

    presentation.sections.reorder_section_with_slides(first_section, 1)
    print_section_slides("After moving the section", first_section)

    slides_before_removal = first_section.get_slides_list_of_section()
    presentation.slides.remove(slides_before_removal[0])
    print_section_slides("After removing a slide", first_section)

    presentation.sections.remove_section_with_slides(second_section)
    for section in presentation.sections:
        print_section_slides("Remaining section", section)
```

استدعِ [Section.get_slides_list_of_section](https://reference.aspose.com/slides/ar/python-net/aspose.slides/section/get_slides_list_of_section/) مرة أخرى كلما أُعيد ترتيب الشرائح أو الأقسام أو استُنسخت أو نُقلت أو أُزيلت. يضمن ذلك بقاء المعالجة اللاحقة متناسبة مع بنية العرض التقديمي الحالية.

تنسيق PPT (PowerPoint 97–2003) لا يحافظ على بيانات الأقسام. استخدم هذا سير العمل مع تنسيق يدعم الأقسام، مثل PPTX؛ التحويل إلى PPT يزيل بنية الأقسام اللازمة للمعالجة اللاحقة.

## **الأسئلة المتكررة**

**هل يتم الحفاظ على الأقسام عند الحفظ بتنسيق PPT (PowerPoint 97–2003)؟**

لا. لا يدعم تنسيق PPT بيانات الأقسام، لذا تُفقد تجميعات الأقسام عند الحفظ إلى .ppt.

**هل يمكن إخفاء قسم كامل؟**

لا. لا يمتلك القسم حالة ظهور. لإخفاء محتوياته، عيّن خاصية [Slide.hidden](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/hidden/) لكل شريحة في القسم.

**كيف يمكنني العثور على القسم الذي يحتوي على شريحة معينة؟**

قم بالتكرار على [Presentation.sections](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/sections/)، استدعِ [Section.get_slides_list_of_section](https://reference.aspose.com/slides/ar/python-net/aspose.slides/section/get_slides_list_of_section/) لكل قسم، وقارن الشرائح المُسترجعة مع الشريحة المستهدفة. بالنسبة لقسم غير فارغ، تُعيد [Section.started_from_slide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/section/started_from_slide/) شريحته الأولى؛ بالنسبة لقسم فارغ، تُعيد `None`.