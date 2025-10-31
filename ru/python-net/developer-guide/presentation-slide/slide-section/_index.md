---
title: Управление секциями слайдов в презентациях с помощью Python
linktitle: Раздел слайдов
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
description: "Упорядочьте секции слайдов в PowerPoint и OpenDocument с помощью Aspose.Slides для Python — разделяйте, переименовывайте и переупорядочивайте для оптимизации рабочих процессов с PPTX и ODP."
---

## **Обзор**

С помощью Aspose.Slides для Python вы можете организовать презентацию PowerPoint в разделы, которые группируют определённые слайды.

Возможно, вам потребуется создать разделы для организации или разделения презентации на логические части в следующих ситуациях:

- Когда вы работаете над крупной презентацией вместе с командой и нужно назначить определённые слайды конкретным коллегам.
- Когда вы имеете дело с презентацией, содержащей множество слайдов, и вам сложно управлять или редактировать всё сразу.

Оптимально создавать разделы, которые группируют связанные слайды — те, что имеют общую тему, предмет или цель, — и давать каждому разделу название, чётко отражающее его содержимое. 

## **Создание разделов в презентациях**

Чтобы добавить [Section](https://reference.aspose.com/slides/python-net/aspose.slides/section/), который группирует слайды в презентации, Aspose.Slides предоставляет метод [add_section](https://reference.aspose.com/slides/python-net/aspose.slides/sectioncollection/add_section/). Он позволяет указать название раздела и слайд, с которого начинается раздел.

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
    # Раздел 1 заканчивается на slide2; Раздел 2 начинается на slide3.
    section2 = presentation.sections.add_section("Section 2", slide3) 
      
    presentation.save("presentation_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.reorder_section_with_slides(section2, 0)
    presentation.save("reordered_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.remove_section_with_slides(section2)
    presentation.sections.append_empty_section("Last empty section")
    presentation.save("presentation_with_empty_section.pptx",slides.export.SaveFormat.PPTX)
```

## **Изменение названий разделов**

После создания [Section](https://reference.aspose.com/slides/python-net/aspose.slides/section/) в презентации PowerPoint вы можете решить изменить его название.

Следующий пример на Python показывает, как переименовать раздел в презентации:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   section = presentation.sections[0]
   section.name = "My section"
```

## **FAQ**

**Сохраняются ли разделы при сохранении в формат PPT (PowerPoint 97–2003)?**

Нет. Формат PPT не поддерживает метаданные разделов, поэтому группировка разделов теряется при сохранении в .ppt.

**Можно ли полностью скрыть раздел?**

Нет. Можно скрыть только отдельные слайды. У раздела как сущности нет состояния "скрыт".

**Можно ли быстро найти раздел по слайду и, наоборот, первый слайд раздела?**

Да. Раздел однозначно определяется стартовым слайдом; по данному слайду можно определить, к какому разделу он относится, а для раздела можно получить его первый слайд.