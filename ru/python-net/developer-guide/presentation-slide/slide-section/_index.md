---
title: Раздел слайдов
type: docs
weight: 100
url: /python-net/slide-section/
keywords: "Создать раздел, Добавить раздел, Изменить имя раздела, Презентация PowerPoint, Python, Aspose.Slides"
description: "Добавление и редактирование раздела в презентации PowerPoint на Python"
---

С помощью Aspose.Slides для Python через .NET вы можете организовать презентацию PowerPoint на разделы. Вы можете создавать разделы, которые содержат определенные слайды.

Вам может потребоваться создать разделы и использовать их для организации или деления слайдов в презентации на логические части в следующих ситуациях:

- Когда вы работаете над большой презентацией с другими людьми или командой — и вам нужно назначить определенные слайды коллеге или некоторым членам команды.
- Когда вы имеете дело с презентацией, содержащей множество слайдов — и вам трудно управлять или редактировать ее содержимое сразу.

Идеально было бы создать раздел, который включает в себя похожие слайды — слайды имеют что-то общее или могут существовать в группе на основе правила — и дать разделу имя, которое описывает слайды внутри него.

## Создание разделов в презентациях

Чтобы добавить раздел, который будет содержать слайды в презентации, Aspose.Slides для Python через .NET предоставляет метод AddSection, который позволяет указать имя раздела, который вы намереваетесь создать, и слайд, с которого начинается раздел.

Этот пример кода показывает, как создать раздел в презентации на Python:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    defaultSlide = pres.slides[0]
    newSlide1 = pres.slides.add_empty_slide(pres.layout_slides[0])
    newSlide2 = pres.slides.add_empty_slide(pres.layout_slides[0])
    newSlide3 = pres.slides.add_empty_slide(pres.layout_slides[0])
    newSlide4 = pres.slides.add_empty_slide(pres.layout_slides[0])

    section1 = pres.sections.add_section("Раздел 1", newSlide1)
    # section1 закончится на newSlide2, и после него начнется section2 
    section2 = pres.sections.add_section("Раздел 2", newSlide3) 
      
    
    pres.save("pres-sections.pptx", slides.export.SaveFormat.PPTX)
    
    pres.sections.reorder_section_with_slides(section2, 0)
    pres.save("pres-sections-moved.pptx", slides.export.SaveFormat.PPTX)
    
    pres.sections.remove_section_with_slides(section2)
    
    pres.sections.append_empty_section("Последний пустой раздел")
    
    pres.save("pres-section-with-empty.pptx",slides.export.SaveFormat.PPTX)
```

## Изменение имен разделов

После создания раздела в презентации PowerPoint вы можете решить изменить его имя.

Этот пример кода показывает, как изменить имя раздела в презентации на Python с использованием Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation("pres-sections.pptx") as pres:
   section = pres.sections[0]
   section.name = "Мой раздел"
```