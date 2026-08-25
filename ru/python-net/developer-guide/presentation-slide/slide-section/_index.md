---
title: Управление разделами слайдов в презентациях с помощью Python
linktitle: Раздел слайдов
type: docs
weight: 100
url: /ru/python-net/slide-section/
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
- Aspose.Slides
description: "Управляйте разделами слайдов с помощью Aspose.Slides для Python via .NET: создавайте, переименовывайте, переупорядочивайте, получайте и обрабатывайте слайды разделов в презентациях PPTX."
---
## **Введение**

Разделы организуют последовательные слайды в именованные группы, не изменяя содержимое слайдов. С помощью Aspose.Slides for Python via .NET вы можете создавать, переупорядочивать, переименовывать, просматривать и удалять разделы через свойство [Presentation.sections](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/sections/).

РазделыEspecially полезны, когда:

- большая презентация должна быть разделена на логические темы или главы;
- разные группы слайдов назначаются разным сотрудникам;
- слайды необходимо обрабатывать, перемещать или объединять группами.

Выбирайте краткие названия разделов, которые описывают назначение сгруппированных слайдов. Поскольку разделы являются частью структуры презентации, используйте API разделов для определения членства, а не выводите его из позиций слайдов.

## **Создание и управление разделами**

Используйте [SectionCollection.add_section](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sectioncollection/add_section/) для создания раздела, указывая его имя и стартовый слайд. Aspose.Slides определяет, какие слайды принадлежат разделу, исходя из текущей структуры разделов презентации.

Тот же [SectionCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sectioncollection/) также позволяет:

- переместить раздел вместе с его слайдами, используя [SectionCollection.reorder_section_with_slides](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sectioncollection/reorder_section_with_slides/);
- удалить только определение раздела с помощью [SectionCollection.remove_section](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sectioncollection/remove_section/), при этом слайды сохраняются;
- удалить раздел и его слайды с помощью [SectionCollection.remove_section_with_slides](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sectioncollection/remove_section_with_slides/);
- добавить пустой раздел в конце с помощью [SectionCollection.append_empty_section](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sectioncollection/append_empty_section/).

Следующий пример создаёт два раздела, перемещает один из них, удаляет его вместе с слайдами и добавляет пустой раздел:

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

После этих операций презентация содержит раздел `Introduction` со своими слайдами и пустой раздел `Appendix`. Раздел `Results` и его слайды были удалены.

## **Переименование разделов**

Чтобы переименовать раздел, задайте его свойство [Section.name](https://reference.aspose.com/slides/ru/python-net/aspose.slides/section/name/). Слайды раздела и его позиция остаются без изменений.

Следующий пример создаёт раздел и изменяет его имя:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    section = presentation.sections.add_section("Overview", slide)
    section.name = "Introduction"
```

## **Получение слайдов из разделов**

Свойство [Presentation.sections](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/sections/) возвращает [SectionCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sectioncollection/), по которой можно итерироваться. Для каждого [Section](https://reference.aspose.com/slides/ru/python-net/aspose.slides/section/) вызовите [Section.get_slides_list_of_section](https://reference.aspose.com/slides/ru/python-net/aspose.slides/section/get_slides_list_of_section/) чтобы получить слайды, которые в данный момент принадлежат этому разделу. Метод возвращает [SectionSlideCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sectionslidecollection/), которая предоставляет количество, доступ по индексу и возможность итерации.

Следующий пример создаёт два заполненных раздела и один пустой раздел, затем выводит для каждого раздела его [name](https://reference.aspose.com/slides/ru/python-net/aspose.slides/section/name/), [identifier](https://reference.aspose.com/slides/ru/python-net/aspose.slides/section/section_id/), [starting slide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/section/started_from_slide/), количество слайдов и номера слайдов. Он использует доступ по индексу для чтения первого слайда и цикл `for` для обработки каждого слайда. Для пустого раздела возвращаемая коллекция имеет количество ноль, индекс не используется, и итерация не выполняет шагов.

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

Членство в разделе определяется структурой разделов презентации. Не рассчитывайте диапазон раздела вручную, используя [Section.started_from_slide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/section/started_from_slide/), индексы слайдов и стартовый слайд следующего раздела.

Структурные изменения могут изменить как набор слайдов, возвращаемый для раздела, так и их номера. Это включает переупорядочивание слайдов, клонирование слайда в раздел, перемещение раздела вместе с его слайдами, удаление слайдов и удаление разделов. В следующем примере после каждого такого изменения вызывается [Section.get_slides_list_of_section](https://reference.aspose.com/slides/ru/python-net/aspose.slides/section/get_slides_list_of_section/) вместо сохранения предположений о прежних границах раздела.

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

Вызывайте [Section.get_slides_list_of_section](https://reference.aspose.com/slides/ru/python-net/aspose.slides/section/get_slides_list_of_section/) снова каждый раз, когда слайды или разделы переупорядочиваются, клонируются, перемещаются или удаляются. Это сохраняет согласованность дальнейшей обработки с текущей структурой презентации.

Формат PPT (PowerPoint 97–2003) не сохраняет метаданные разделов. Используйте этот рабочий процесс с форматом, поддерживающим разделы, например PPTX; преобразование в PPT удаляет структуру разделов, необходимую для последующей итерации.

## **Вопросы и ответы**

**Сохраняются ли разделы при сохранении в формат PPT (PowerPoint 97–2003)?**

Нет. Формат PPT не поддерживает метаданные разделов, поэтому группировка разделов теряется при сохранении в .ppt.

**Можно ли полностью «скрыть» раздел?**

Нет. У раздела нет состояния видимости. Чтобы скрыть его содержимое, установите свойство [Slide.hidden](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slide/hidden/) для каждого слайда в разделе.

**Как найти раздел, содержащий конкретный слайд?**

Итерируйтесь по [Presentation.sections](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/sections/), вызывайте [Section.get_slides_list_of_section](https://reference.aspose.com/slides/ru/python-net/aspose.slides/section/get_slides_list_of_section/) для каждого раздела и сравнивайте полученные слайды с целевым слайдом. Для непустого раздела [Section.started_from_slide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/section/started_from_slide/) возвращает его первый слайд; для пустого раздела он возвращает `None`.