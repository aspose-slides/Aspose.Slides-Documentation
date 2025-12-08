---
title: Управление разделами слайдов в презентациях с помощью Python
linktitle: Раздел слайда
type: docs
weight: 100
url: /ru/python-net/slide-section/
keywords:
- создать раздел
- добавить раздел
- редактировать раздел
- изменить раздел
- название раздела
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Упрощайте работу с разделами слайдов в PowerPoint и OpenDocument с помощью Aspose.Slides для Python — разделяйте, переименовывайте и переупорядочивайте для оптимизации процессов PPTX и ODP."
---

## **Обзор**

С помощью Aspose.Slides for Python вы можете упорядочить презентацию PowerPoint в разделы, которые группируют определённые слайды.

Возможно, вам понадобится создавать разделы для организации или разделения презентации на логические части в следующих ситуациях:

- Когда вы работаете над большой презентацией в команде и нужно назначить определённые слайды конкретным коллегам.
- Когда презентация содержит много слайдов и вам трудно управлять ими или редактировать их все одновременно.

Оптимально создавать разделы, которые группируют связанные слайды — те, что имеют общую тему, предмет или цель, — и давать каждому разделу название, чётко отражающее его содержимое. 

## **Создание разделов в презентациях**

Чтобы добавить [Section](https://reference.aspose.com/slides/python-net/aspose.slides/section/) , который группирует слайды в презентации, Aspose.Slides предоставляет метод [add_section](https://reference.aspose.com/slides/python-net/aspose.slides/sectioncollection/add_section/). Он позволяет указать имя раздела и слайд, с которого начинается раздел.

Следующий пример на Python показывает, как создать раздел в презентации:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides[0]

    slide1 = presentation.slides.add_empty_slide(layout_slide)
    slide2 = presentation.slides.add_empty_slide(layout_slide)
    slide3 = presentation.slides.add_empty_slide(layout_slide)
    slide4 = presentation.slides.add_empty_slide(layout_slide)

    section1 = presentation.sections.add_section("Section 1", slide1)
    # Раздел 1 заканчивается на слайде 2; Раздел 2 начинается со слайда 3.
    section2 = presentation.sections.add_section("Section 2", slide3) 
      
    presentation.save("presentation_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.reorder_section_with_slides(section2, 0)
    presentation.save("reordered_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.remove_section_with_slides(section2)
    presentation.sections.append_empty_section("Last empty section")
    presentation.save("presentation_with_empty_section.pptx",slides.export.SaveFormat.PPTX)
```


## **Изменение названий разделов**

После создания [Section](https://reference.aspose.com/slides/python-net/aspose.slides/section/) в презентации PowerPoint вы можете решить переименовать его.

Следующий пример на Python показывает, как переименовать раздел в презентации:
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   section = presentation.sections[0]
   section.name = "My section"
```


## **FAQ**

**Сохраняются ли разделы при сохранении в формате PPT (PowerPoint 97–2003)?**

Нет. Формат PPT не поддерживает метаданные разделов, поэтому группировка разделов теряется при сохранении в .ppt.

**Можно ли скрыть весь раздел?**

Нет. Скрывать можно только отдельные слайды. У раздела как сущности нет состояния «скрыт».

**Можно ли быстро найти раздел по слайду и, наоборот, первый слайд раздела?**

Да. Раздел уникально определяется своим начальным слайдом; зная слайд, можно определить, к какому разделу он принадлежит, а для раздела можно получить его первый слайд.