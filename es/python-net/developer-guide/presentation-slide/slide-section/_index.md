---
title: Sección de Diapositivas
type: docs
weight: 100
url: /es/python-net/slide-section/
keywords: "Crear sección, Añadir sección, Editar nombre de sección, Presentación de PowerPoint, Python, Aspose.Slides"
description: "Añadir y editar secciones en una presentación de PowerPoint en Python"
---

Con Aspose.Slides para Python a través de .NET, puedes organizar una presentación de PowerPoint en secciones. Puedes crear secciones que contengan diapositivas específicas.

Puede que quieras crear secciones y usarlas para organizar o dividir las diapositivas en una presentación en partes lógicas en estas situaciones:

- Cuando estás trabajando en una gran presentación con otras personas o un equipo—y necesitas asignar ciertas diapositivas a un colega o a algunos miembros del equipo.
- Cuando estás manejando una presentación que contiene muchas diapositivas—y te cuesta gestionar o editar su contenido todo a la vez.

Idealmente, deberías crear una sección que contenga diapositivas similares—las diapositivas tienen algo en común o pueden existir en un grupo basado en una regla—y darle a la sección un nombre que describa las diapositivas dentro de ella.

## Creando Secciones en Presentaciones

Para añadir una sección que albergue diapositivas en una presentación, Aspose.Slides para Python a través de .NET proporciona el método AddSection que te permite especificar el nombre de la sección que deseas crear y la diapositiva desde la cual comienza la sección.

Este código de ejemplo te muestra cómo crear una sección en una presentación en Python:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    defaultSlide = pres.slides[0]
    newSlide1 = pres.slides.add_empty_slide(pres.layout_slides[0])
    newSlide2 = pres.slides.add_empty_slide(pres.layout_slides[0])
    newSlide3 = pres.slides.add_empty_slide(pres.layout_slides[0])
    newSlide4 = pres.slides.add_empty_slide(pres.layout_slides[0])

    section1 = pres.sections.add_section("Sección 1", newSlide1)
    # section1 terminará en newSlide2 y después comenzará section2 
    section2 = pres.sections.add_section("Sección 2", newSlide3) 
      
    
    pres.save("pres-sections.pptx", slides.export.SaveFormat.PPTX)
    
    pres.sections.reorder_section_with_slides(section2, 0)
    pres.save("pres-sections-moved.pptx", slides.export.SaveFormat.PPTX)
    
    pres.sections.remove_section_with_slides(section2)
    
    pres.sections.append_empty_section("Última sección vacía")
    
    pres.save("pres-section-with-empty.pptx",slides.export.SaveFormat.PPTX)
```

## Cambiando los Nombres de las Secciones

Después de crear una sección en una presentación de PowerPoint, puedes decidir cambiar su nombre.

Este código de ejemplo te muestra cómo cambiar el nombre de una sección en una presentación en Python usando Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation("pres-sections.pptx") as pres:
   section = pres.sections[0]
   section.name = "Mi sección"
```