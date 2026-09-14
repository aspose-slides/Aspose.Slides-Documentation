---
title: Управление разделами слайдов в презентациях с помощью Python через Java
linktitle: Раздел слайда
type: docs
weight: 90
url: /ru/python-java/slide-section/
keywords:
- создать раздел
- добавить раздел
- редактировать раздел
- изменить раздел
- имя раздела
- получить слайды раздела
- обработать слайды раздела
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Управляйте разделами слайдов с помощью Aspose.Slides for Python via Java: создавайте, переименовывайте, переупорядочивайте, получайте и обрабатывайте слайды разделов в презентациях PPTX."
---
## **Введение**

Разделы упорядочивают последовательные слайды в именованные группы, не меняя содержимое слайдов. С помощью Aspose.Slides for Python via Java вы можете создавать, переупорядочивать, переименовывать, просматривать и удалять разделы через метод [Presentation.getSections](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getSections).

Разделы особенно полезны, когда:

- большая презентация должна быть разбита на логические темы или главы;
- разные группы слайдов назначаются разным сотрудникам;
- слайды необходимо обрабатывать, перемещать или объединять группами.

Выбирайте краткие названия разделов, которые описывают цель сгруппированных слайдов. Поскольку разделы являются частью структуры презентации, используйте API разделов для определения принадлежности, а не выводите её из позиций слайдов.

## **Создание и управление разделами**

Используйте [SectionCollection.addSection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sectioncollection/#addSection) для создания раздела, указывая его имя и стартовый слайд. Aspose.Slides определяет, какие слайды принадлежат разделу, исходя из текущей структуры разделов презентации.

Тот же [SectionCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sectioncollection/) также позволяет:

- переместить раздел вместе со своими слайдами, используя [reorderSectionWithSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sectioncollection/#reorderSectionWithSlides);
- удалить только определение раздела с помощью [removeSection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sectioncollection/#removeSection), сохранив его слайды;
- удалить раздел и его слайды с помощью [removeSectionWithSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sectioncollection/#removeSectionwithslides);
- добавить пустой раздел в конец с помощью [appendEmptySection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sectioncollection/#appendEmptySection).

Следующий пример создает два раздела, перемещает один из них, удаляет его вместе со слайдами и добавляет пустой раздел:

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

После этих операций презентация содержит раздел `Introduction` со своими слайдами и пустой раздел `Appendix`. Раздел `Results` и его слайды были удалены.

## **Переименование разделов**

Чтобы переименовать раздел, вызовите его метод [Section.setName](https://reference.aspose.com/slides/ru/python-java/aspose.slides/section/#setName). Слайды раздела и его позиция остаются без изменений.

Следующий пример создает раздел и меняет его название:

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

## **Получение слайдов из разделов**

Метод [Presentation.getSections](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getSections) возвращает [SectionCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sectioncollection/), по которой можно выполнять итерацию. Для каждого [Section](https://reference.aspose.com/slides/ru/python-java/aspose.slides/section/) вызовите [Section.getSlidesListOfSection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/section/#getSlidesListOfSection), чтобы получить слайды, которые в данный момент принадлежат этому разделу. Метод возвращает [SectionSlideCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sectionslidecollection/), предоставляющий количество, доступ по индексу и возможность итерации.

Следующий пример создает два заполненных раздела и один пустой, затем выводит для каждого раздела его [name](https://reference.aspose.com/slides/ru/python-java/aspose.slides/section/#getName), [identifier](https://reference.aspose.com/slides/ru/python-java/aspose.slides/section/#getSectionId), [starting slide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/section/#getStartedFromSlide), количество слайдов и номера слайдов. Он использует [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sectionslidecollection/#get_Item) для чтения первого слайда и оператор `for` для обработки каждого слайда. Для пустого раздела возвращаемая коллекция имеет размер ноль, метод не вызывается, а итерация не выполняет никаких операций.

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

Членство в разделе определяется структурой разделов презентации. Не вычисляйте диапазон раздела вручную, используя [Section.getStartedFromSlide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/section/#getStartedFromSlide), индексы слайдов и стартовый слайд следующего раздела.

Структурные изменения могут изменить как набор слайдов, возвращаемый для раздела, так и их номера. Это включает переупорядочивание слайдов, клонирование слайда в раздел, перемещение раздела вместе со слайдами, удаление слайдов и удаление разделов. В следующем примере после каждого такого изменения вызывается [Section.getSlidesListOfSection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/section/#getSlidesListOfSection) вместо сохранения предположений о прежних границах раздела.

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

Вызывайте [Section.getSlidesListOfSection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/section/#getSlidesListOfSection) каждый раз, когда слайды или разделы переупорядочиваются, клонируются, перемещаются или удаляются. Это позволяет последующей обработке соответствовать текущей структуре презентации.

Формат PPT (PowerPoint 97–2003) не сохраняет метаданные разделов. Используйте этот рабочий процесс с форматом, поддерживающим разделы, например PPTX; преобразование в PPT удаляет структуру разделов, необходимую для последующей итерации.

## **Часто задаваемые вопросы**

**Сохраняются ли разделы при сохранении в формат PPT (PowerPoint 97–2003)?**

Нет. Формат PPT не поддерживает метаданные разделов, поэтому группировка разделов теряется при сохранении в .ppt.

**Можно ли полностью «скрыть» раздел?**

Нет. У раздела нет состояния видимости. Чтобы скрыть его содержимое, вызовите [Slide.setHidden](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#setHidden) для каждого слайда в этом разделе.

**Как найти раздел, содержащий определённый слайд?**

Итерируйте по коллекции, возвращаемой [Presentation.getSections](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getSections), вызывайте [Section.getSlidesListOfSection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/section/#getSlidesListOfSection) для каждого раздела и сравнивайте полученные слайды с целевым слайдом. Для непустого раздела [Section.getStartedFromSlide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/section/#getStartedFromSlide) возвращает его первый слайд; для пустого раздела он возвращает `None`.