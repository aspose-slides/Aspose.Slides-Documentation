---
title: Administrar secciones de diapositivas en presentaciones con Python
linktitle: Sección de diapositiva
type: docs
weight: 100
url: /es/python-net/slide-section/
keywords:
- crear sección
- agregar sección
- editar sección
- cambiar sección
- nombre de sección
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Simplifique las secciones de diapositivas en PowerPoint y OpenDocument con Aspose.Slides para Python: divida, renombre y reordene para optimizar los flujos de trabajo de PPTX y ODP."
---

## **Resumen**

Con Aspose.Slides para Python, puede organizar una presentación de PowerPoint en secciones que agrupan diapositivas específicas.

Puede que desee crear secciones para organizar o dividir una presentación en partes lógicas en estas situaciones:

- Cuando está trabajando en una presentación grande con un equipo y necesita asignar ciertas diapositivas a colegas específicos.
- Cuando está manejando una presentación que contiene muchas diapositivas y le resulta difícil gestionar o editar todo de una vez.

Idealmente, cree secciones que agrupen diapositivas relacionadas —aquellas que comparten un tema, tópico o propósito— y asigne a cada sección un nombre que refleje claramente su contenido. 

## **Crear secciones en presentaciones**

Para agregar una [Section](https://reference.aspose.com/slides/python-net/aspose.slides/section/) que agrupa diapositivas en una presentación, Aspose.Slides ofrece el método [add_section](https://reference.aspose.com/slides/python-net/aspose.slides/sectioncollection/add_section/). Le permite especificar el nombre de la sección y la diapositiva donde comienza la sección.

El siguiente ejemplo en Python muestra cómo crear una sección en una presentación:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides[0]

    slide1 = presentation.slides.add_empty_slide(layout_slide)
    slide2 = presentation.slides.add_empty_slide(layout_slide)
    slide3 = presentation.slides.add_empty_slide(layout_slide)
    slide4 = presentation.slides.add_empty_slide(layout_slide)

    section1 = presentation.sections.add_section("Section 1", slide1)
    # La sección 1 termina en slide2; la sección 2 comienza en slide3.
    section2 = presentation.sections.add_section("Section 2", slide3) 
      
    presentation.save("presentation_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.reorder_section_with_slides(section2, 0)
    presentation.save("reordered_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.remove_section_with_slides(section2)
    presentation.sections.append_empty_section("Last empty section")
    presentation.save("presentation_with_empty_section.pptx",slides.export.SaveFormat.PPTX)
```

## **Cambiar los nombres de las secciones**

Después de crear una [Section](https://reference.aspose.com/slides/python-net/aspose.slides/section/) en una presentación de PowerPoint, puede decidir cambiar su nombre.

El siguiente ejemplo en Python muestra cómo renombrar una sección en una presentación:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   section = presentation.sections[0]
   section.name = "My section"
```

## **FAQ**

**¿Se conservan las secciones al guardar en el formato PPT (PowerPoint 97–2003)?**

No. El formato PPT no admite metadatos de sección, por lo que la agrupación de secciones se pierde al guardar en .ppt.

**¿Puede ocultarse una sección completa?**

No. Sólo se pueden ocultar diapositivas individuales. Una sección como entidad no tiene estado "oculto".

**¿Puedo encontrar rápidamente una sección a partir de una diapositiva y, a la inversa, la primera diapositiva de una sección?**

Sí. Una sección se define de forma única por su diapositiva inicial; dada una diapositiva puede determinar a qué sección pertenece, y para una sección puede acceder a su primera diapositiva.