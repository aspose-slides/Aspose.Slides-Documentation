---
title: Gestionar secciones de diapositivas en presentaciones con Python
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
- recuperar diapositivas de sección
- procesar diapositivas de sección
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Gestiona secciones de diapositivas con Aspose.Slides para Python a través de .NET: crea, renombra, reordena, recupera y procesa diapositivas de sección en presentaciones PPTX."
---
## **Introducción**

Las secciones organizan diapositivas consecutivas en grupos con nombre sin cambiar el contenido de la diapositiva. Con Aspose.Slides para Python a través de .NET, puedes crear, reordenar, renombrar, inspeccionar y eliminar secciones mediante la propiedad [Presentation.sections](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/sections/).

Las secciones son especialmente útiles cuando:

- una presentación grande necesita dividirse en temas o capítulos lógicos;
- diferentes grupos de diapositivas se asignan a diferentes colaboradores;
- las diapositivas necesitan ser procesadas, movidas o combinadas como grupos.

Elige nombres de sección concisos que describan el propósito de las diapositivas agrupadas. Dado que las secciones forman parte de la estructura de la presentación, utiliza las API de sección para determinar la pertenencia en lugar de derivarla de las posiciones de las diapositivas.

## **Crear y gestionar secciones**

Utiliza [SectionCollection.add_section](https://reference.aspose.com/slides/es/python-net/aspose.slides/sectioncollection/add_section/) para crear una sección especificando su nombre y diapositiva inicial. Aspose.Slides determina qué diapositivas pertenecen a la sección a partir de la estructura de secciones actual de la presentación.

El mismo [SectionCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/sectioncollection/) también permite:

- mover una sección junto con sus diapositivas usando [SectionCollection.reorder_section_with_slides](https://reference.aspose.com/slides/es/python-net/aspose.slides/sectioncollection/reorder_section_with_slides/);
- eliminar solo la definición de la sección con [SectionCollection.remove_section](https://reference.aspose.com/slides/es/python-net/aspose.slides/sectioncollection/remove_section/), lo que conserva sus diapositivas;
- eliminar una sección y sus diapositivas con [SectionCollection.remove_section_with_slides](https://reference.aspose.com/slides/es/python-net/aspose.slides/sectioncollection/remove_section_with_slides/);
- añadir una sección vacía al final con [SectionCollection.append_empty_section](https://reference.aspose.com/slides/es/python-net/aspose.slides/sectioncollection/append_empty_section/).

El siguiente ejemplo crea dos secciones, mueve una de ellas, la elimina junto con sus diapositivas y añade una sección vacía:

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

Después de estas operaciones, la presentación contiene la sección `Introduction` con sus diapositivas y una sección vacía `Appendix`. La sección `Results` y sus diapositivas han sido eliminadas.

## **Renombrar secciones**

Para renombrar una sección, asigna su propiedad [Section.name](https://reference.aspose.com/slides/es/python-net/aspose.slides/section/name/). Las diapositivas y la posición de la sección permanecen sin cambios.

El siguiente ejemplo crea una sección y cambia su nombre:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    section = presentation.sections.add_section("Overview", slide)
    section.name = "Introduction"
```

## **Obtener diapositivas de secciones**

La propiedad [Presentation.sections](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/sections/) devuelve una [SectionCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/sectioncollection/) que puedes iterar. Para cada [Section](https://reference.aspose.com/slides/es/python-net/aspose.slides/section/), llama a [Section.get_slides_list_of_section](https://reference.aspose.com/slides/es/python-net/aspose.slides/section/get_slides_list_of_section/) para obtener las diapositivas que le pertenecen actualmente. El método devuelve una [SectionSlideCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/sectionslidecollection/), que proporciona un recuento, acceso indexado e iteración.

El siguiente ejemplo crea dos secciones pobladas y una sección vacía, luego imprime el [name](https://reference.aspose.com/slides/es/python-net/aspose.slides/section/name/), el [identifier](https://reference.aspose.com/slides/es/python-net/aspose.slides/section/section_id/), la [starting slide](https://reference.aspose.com/slides/es/python-net/aspose.slides/section/started_from_slide/), el recuento de diapositivas y los números de diapositiva de cada sección. Utiliza acceso indexado para leer la primera diapositiva y un bucle `for` para procesar cada diapositiva. Para la sección vacía, la colección devuelta tiene un recuento de cero, no se accede al índice y la iteración no realiza pasos.

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

La pertenencia a una sección se determina por la estructura de secciones de la presentación. No calcules manualmente el rango de una sección a partir de [Section.started_from_slide](https://reference.aspose.com/slides/es/python-net/aspose.slides/section/started_from_slide/), los índices de diapositivas y la diapositiva inicial de la siguiente sección.

Las ediciones estructurales pueden cambiar tanto las diapositivas devueltas para una sección como sus números de diapositiva. Esto incluye reordenar diapositivas, clonar una diapositiva en una sección, mover una sección junto con sus diapositivas, eliminar diapositivas y eliminar secciones. El siguiente ejemplo llama a [Section.get_slides_list_of_section](https://reference.aspose.com/slides/es/python-net/aspose.slides/section/get_slides_list_of_section/) después de cada cambio de este tipo en lugar de mantener suposiciones sobre los límites anteriores de la sección.

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

Llama a [Section.get_slides_list_of_section](https://reference.aspose.com/slides/es/python-net/aspose.slides/section/get_slides_list_of_section/) nuevamente siempre que las diapositivas o secciones se reordenen, clonen, muevan o eliminen. Esto mantiene el procesamiento posterior alineado con la estructura actual de la presentación.

El formato PPT (PowerPoint 97–2003) no conserva los metadatos de sección. Utiliza este flujo de trabajo con un formato que admita secciones, como PPTX; convertir a PPT elimina la estructura de secciones necesaria para la iteración posterior.

## **Preguntas frecuentes**

**¿Se conservan las secciones al guardar en formato PPT (PowerPoint 97–2003)?**

No. El formato PPT no admite metadatos de sección, por lo que la agrupación de secciones se pierde al guardar en .ppt.

**¿Puede ocultarse una sección completa?**

No. Una sección no tiene estado de visibilidad. Para ocultar su contenido, establece la propiedad [Slide.hidden](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/hidden/) en cada diapositiva de la sección.

**¿Cómo puedo encontrar la sección que contiene una diapositiva?**

Itera sobre [Presentation.sections](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/sections/), llama a [Section.get_slides_list_of_section](https://reference.aspose.com/slides/es/python-net/aspose.slides/section/get_slides_list_of_section/) para cada sección y compara las diapositivas devueltas con la diapositiva objetivo. Para una sección no vacía, [Section.started_from_slide](https://reference.aspose.com/slides/es/python-net/aspose.slides/section/started_from_slide/) devuelve su primera diapositiva; para una sección vacía, devuelve `None`.