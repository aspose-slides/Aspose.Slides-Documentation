---
title: إدارة أقسام الشرائح في العروض التقديمية باستخدام بايثون عبر جافا
linktitle: قسم الشرائح
type: docs
weight: 90
url: /ar/python-java/slide-section/
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
- Java
- Aspose.Slides
description: "إدارة أقسام الشرائح باستخدام Aspose.Slides لـ Python عبر Java: إنشاء، إعادة تسمية، إعادة ترتيب، استرجاع، ومعالجة شرائح الأقسام في عروض PPTX التقديمية."
---
## **مقدمة**

تنظم الأقسام الشرائح المتتالية في مجموعات مسماة دون تغيير محتوى الشريحة. باستخدام Aspose.Slides for Python via Java، يمكنك إنشاء الأقسام وإعادة ترتيبها وإعادة تسميتها وفحصها وإزالتها عبر طريقة [Presentation.getSections](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getSections).

تكون الأقسام مفيدة بشكل خاص عندما:
- يحتاج عرض تقديمي كبير إلى تقسيمه إلى مواضيع أو فصول منطقية؛
- يتم تعيين مجموعات مختلفة من الشرائح إلى متعاونين مختلفين؛
- تحتاج الشرائح إلى المعالجة أو النقل أو الدمج كمجموعات.

اختر أسماء أقسام موجزة تصف هدف الشرائح المجمعة. لأن الأقسام جزء من بنية العرض، استخدم واجهات برمجة تطبيقات الأقسام لتحديد العضوية بدلاً من اشتقاقها من مواضع الشرائح.

## **إنشاء وإدارة الأقسام**

استخدم [SectionCollection.addSection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sectioncollection/#addSection) لإنشاء قسم عن طريق تحديد اسمه والشريحة البداية. يحدد Aspose.Slides أي الشرائح تنتمي إلى القسم من بنية الأقسام الحالية في العرض.

تتيح لك نفس [SectionCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sectioncollection/) أيضًا:
- نقل قسم مع شرائحه باستخدام [reorderSectionWithSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sectioncollection/#reorderSectionWithSlides);
- إزالة تعريف القسم فقط باستخدام [removeSection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sectioncollection/#removeSection)، مع الاحتفاظ بشرائحه;
- إزالة قسم وشراكه باستخدام [removeSectionWithSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sectioncollection/#removeSectionwithslides);
- إضافة قسم فارغ في النهاية باستخدام [appendEmptySection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sectioncollection/#appendEmptySection).

المثال التالي ينشئ قسمين، ينقل أحدهما، يزيله مع شرائحه، ويضيف قسمًا فارغًا:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    title_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    results_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", title_slide)
    results_section = presentation.getSections().addSection("Results", results_slide)

    presentation.getSections().reorderSectionWithSlides(results_section, 0)
    presentation.getSections().removeSectionWithSlides(results_section)
    presentation.getSections().appendEmptySection("Appendix")
finally:
    presentation.dispose()
```

بعد هذه العمليات، يحتوي العرض التقديمي على قسم `Introduction` مع شرائحه وقسم فارغ `Appendix`. تم إزالة قسم `Results` وشراكه.

## **إعادة تسمية الأقسام**

لإعادة تسمية قسم، استدعِ طريقة [Section.setName](https://reference.aspose.com/slides/ar/python-java/aspose.slides/section/#setName). تبقى شرائح القسم وموقعه دون تغيير.

المثال التالي ينشئ قسمًا ويغير اسمه:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    section = presentation.getSections().addSection("Overview", slide)
    section.setName("Introduction")
finally:
    presentation.dispose()
```

## **استرجاع الشرائح من الأقسام**

طريقة [Presentation.getSections](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getSections) تُرجع [SectionCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sectioncollection/) يمكنك iterating overه. لكل [Section](https://reference.aspose.com/slides/ar/python-java/aspose.slides/section/)، استدعِ [Section.getSlidesListOfSection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/section/#getSlidesListOfSection) للحصول على الشرائح التي تنتمي إليه حاليًا. تُرجع الطريقة [SectionSlideCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sectionslidecollection/)، التي توفر عددًا، وصولًا بالفهرس، وتكرارًا.

المثال التالي ينشئ قسمين مملوءين وقسمًا فارغًا، ثم يطبع لكل قسم [name](https://reference.aspose.com/slides/ar/python-java/aspose.slides/section/#getName)، [identifier](https://reference.aspose.com/slides/ar/python-java/aspose.slides/section/#getSectionId)، [starting slide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/section/#getStartedFromSlide)، عدد الشرائح، وأرقام الشرائح. يستخدم [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sectionslidecollection/#get_Item) لقراءة الشريحة الأولى وتعليمة `for` لمعالجة كل شريحة. بالنسبة للقسم الفارغ، يكون حجم المجموعة صفرًا، ولا تُستدعى الطريقة، ولا يؤدي التكرار إلى أي عمليات.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", first_slide)
    presentation.getSections().addSection("Details", third_slide)
    presentation.getSections().appendEmptySection("Appendix")

    for section in presentation.getSections():
        section_slides = section.getSlidesListOfSection()
        starting_slide = "none" if section.getStartedFromSlide() is None else str(section.getStartedFromSlide().getSlideNumber())

        print("Section: ", section.getName(), sep="")
        print("ID: ", section.getSectionId(), sep="")
        print("Starting slide: ", starting_slide, sep="")
        print("Slide count: ", section_slides.size(), sep="")

        if section_slides.size() > 0:
            print("First slide via get_Item: ", section_slides.get_Item(0).getSlideNumber(), sep="")

        print("Slide numbers:", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()
finally:
    presentation.dispose()
```

تحدد عضوية القسم بنية أقسام العرض. لا تحسب نطاق القسم يدويًا من [Section.getStartedFromSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/section/#getStartedFromSlide)، فهارس الشرائح، وشريحة البداية للقسم التالي.

يمكن للتعديلات الهيكلية أن تغير كلًا من الشرائح المسترجعة لقسم ما وأرقامها. يشمل ذلك إعادة ترتيب الشرائح، استنساخ شريحة داخل قسم، نقل قسم مع شرائحه، إزالة شرائح، وإزالة أقسام. المثال التالي يستدعي [Section.getSlidesListOfSection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/section/#getSlidesListOfSection) بعد كل تغيير من هذا النوع بدلاً من الاعتماد على افتراضات حول حدود القسم السابقة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
    first_section = presentation.getSections().addSection("First", first_slide)
    second_section = presentation.getSections().addSection("Second", third_slide)

    def print_section_slides(label, section):
        section_slides = section.getSlidesListOfSection()
        print(f"{label} ({section_slides.size()} slides):", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()

    print_section_slides("Initially", first_section)

    slides_before_clone = first_section.getSlidesListOfSection()
    presentation.getSlides().addClone(slides_before_clone.get_Item(0), first_section)
    print_section_slides("After cloning into the section", first_section)

    slides_before_reorder = first_section.getSlidesListOfSection()
    first_section_position = slides_before_reorder.get_Item(0).getSlideNumber() - 1
    presentation.getSlides().reorder(first_section_position, slides_before_reorder.get_Item(slides_before_reorder.size() - 1))
    print_section_slides("After reordering slides", first_section)

    presentation.getSections().reorderSectionWithSlides(first_section, 1)
    print_section_slides("After moving the section", first_section)

    slides_before_removal = first_section.getSlidesListOfSection()
    presentation.getSlides().remove(slides_before_removal.get_Item(0))
    print_section_slides("After removing a slide", first_section)

    presentation.getSections().removeSectionWithSlides(second_section)
    for section in presentation.getSections():
        print_section_slides("Remaining section", section)
finally:
    presentation.dispose()
```

استدعِ [Section.getSlidesListOfSection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/section/#getSlidesListOfSection) مرة أخرى كلما أُعيد ترتيب الشرائح أو الأقسام، أو استُنسخت، أو نُقلت، أو أُزيلت. يضمن ذلك بقاء المعالجة اللاحقة متوافقة مع بنية العرض الحالية.

تنسيق PPT (PowerPoint 97–2003) لا يحافظ على بيانات تعريف الأقسام. استخدم هذا الإجراء مع تنسيق يدعم الأقسام، مثل PPTX؛ التحويل إلى PPT يزيل بنية الأقسام المطلوبة للتكرار لاحقًا.

## **الأسئلة المتكررة**

**هل يتم الحفاظ على الأقسام عند الحفظ بتنسيق PPT (PowerPoint 97–2003)؟**

لا. لا يدعم تنسيق PPT بيانات تعريف الأقسام، لذا يتم فقدان تجميع الأقسام عند الحفظ بتنسيق .ppt.

**هل يمكن إخفاء قسم كامل؟**

لا. لا يمتلك القسم حالة رؤية. لإخفاء محتوياته، استدعِ [Slide.setHidden](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#setHidden) لكل شريحة في القسم.

**كيف يمكنني العثور على القسم الذي يحتوي على شريحة معينة؟**

قم بالتكرار على المجموعة التي تُرجعها [Presentation.getSections](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getSections)، استدعِ [Section.getSlidesListOfSection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/section/#getSlidesListOfSection) لكل قسم، وقارن الشرائح المسترجعة مع الشريحة المستهدفة. بالنسبة لقسم غير فارغ، تُرجع [Section.getStartedFromSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/section/#getStartedFromSlide) شريحته الأولى؛ بالنسبة لقسم فارغ، تُرجع `None`.