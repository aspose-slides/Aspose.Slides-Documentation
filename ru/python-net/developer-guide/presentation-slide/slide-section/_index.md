---
title: Управление разделами слайдов в презентациях с помощью Python
linktitle: Раздел слайдов
type: docs
weight: 100
url: /ru/python-net/developer-guide/presentation-slide/slide-section/
keywords:
- создать раздел
- добавить раздел
- редактировать раздел
- изменить раздел
- имя раздела
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Оптимизируйте разделы слайдов в PowerPoint и OpenDocument с помощью Aspose.Slides для Python — разделяйте, переименовывайте и переупорядочивайте для улучшения рабочих процессов PPTX и ODP."
---

## **Обзор**

С помощью Aspose.Slides для Python вы можете организовать презентацию PowerPoint в разделы, группирующие определённые слайды.

Возможно, вы захотите создать разделы для организации или разделения презентации на логические части в следующих ситуациях:

- Когда вы работаете над большой презентацией в команде и нужно назначить определённые слайды конкретным коллегам.
- Когда вы имеете дело с презентацией, содержащей много слайдов, и вам трудно управлять ими или редактировать всё сразу.

Оптимально создавать разделы, группирующие связанные слайды — те, которые имеют общую тему, предмет или цель, — и давать каждому разделу имя, чётко отражающее его содержимое. 

## **Создание разделов в презентациях**

Чтобы добавить [Раздел](https://reference.aspose.com/slides/python-net/aspose.slides/section/), группирующий слайды в презентации, Aspose.Slides предоставляет метод [add_section](https://reference.aspose.com/slides/python-net/aspose.slides/sectioncollection/add_section/). Он позволяет указать имя раздела и слайд, с которого начинается раздел.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides[0]

    slide1 = presentation.slides.add_empty_slide(layout_slide)
    slide2 = presentation.slides.add_empty_slide(layout_slide)
    slide3 = presentation.slides.add_empty_slide(layout_slide)
    slide4 = presentation.slides.add_empty_slide(layout_slide)

    section1 = presentation.sections.add_section("Section 1", slide1)
    # Section 1 ends at slide2; Section 2 starts at slide3.
    section2 = presentation.sections.add_section("Section 2", slide3) 
      
    presentation.save("presentation_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.reorder_section_with_slides(section2, 0)
    presentation.save("reordered_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.remove_section_with_slides(section2)
    presentation.sections.append_empty_section("Last empty section")
    presentation.save("presentation_with_empty_section.pptx",slides.export.SaveFormat.PPTX)
```

## **Изменение имен разделов**

После создания [Раздела](https://reference.aspose.com/slides/python-net/aspose.slides/section/) в презентации PowerPoint вы можете решить изменить его имя.

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

Нет. Скрывать можно только отдельные слайды. У раздела как сущности нет состояния «скрыт».

**Можно ли быстро найти раздел по слайду и, наоборот, первый слайд раздела?**

Да. Раздел uniquely определяется своим начальным слайдом; имея слайд, можно определить, к какому разделу он принадлежит, а для раздела можно получить его первый слайд.