---
title: Gestionar superíndice y subíndice en Python
linktitle: Superíndice y Subíndice
type: docs
weight: 80
url: /es/python-net/superscript-and-subscript/
keywords:
- superíndice
- subíndice
- agregar superíndice
- agregar subíndice
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Domina el superíndice y subíndice en Aspose.Slides para Python a través de .NET y eleva tus presentaciones con un formato de texto profesional para lograr el máximo impacto."
---

## **Agregar texto superíndice y subíndice**

Puedes agregar texto superíndice y subíndice a cualquier porción de párrafo. En Aspose.Slides, usa la propiedad `escapement` de la clase [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) para controlarlo.

`escapement` es un porcentaje de **-100% a 100%**:

- **> 0** → superíndice (p.ej., 25% = elevación ligera; 100% = superíndice completo)
- **0** → línea base (sin superíndice/subíndice)
- **< 0** → subíndice (p.ej., -25% = descenso ligero; -100% = subíndice completo)

Pasos:

1. Crea una [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y obtén una diapositiva.
1. Añade un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) rectangular y accede a su [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Limpia los párrafos existentes.
1. Para superíndice: crea un párrafo y una porción, establece `portion.portion_format.escapement` a un valor entre **0 y 100**, asigna el texto y agrega la porción.
1. Para subíndice: crea otro párrafo y una porción, establece `escapement` a un valor entre **-100 y 0**, asigna el texto y agrega la porción.
1. Guarda la presentación como PPTX.
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # Obtener una diapositiva.
    slide = presentation.slides[0]

    # Crear un cuadro de texto.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    shape.text_frame.paragraphs.clear()

    # Crear un párrafo para texto superíndice.
    superscript_paragraph = slides.Paragraph()

    # Crear una porción de texto con texto normal.
    portion1 = slides.Portion()
    portion1.text = "SlideTitle"
    superscript_paragraph.portions.add(portion1)

    # Crear una porción de texto con superíndice.
    superscript_portion = slides.Portion()
    superscript_portion.portion_format.escapement = 30
    superscript_portion.text = "TM"
    superscript_paragraph.portions.add(superscript_portion)

    # Crear un párrafo para texto subíndice.
    subscript_paragraph = slides.Paragraph()

    # Crear una porción de texto con texto normal.
    portion2 = slides.Portion()
    portion2.text = "a"
    subscript_paragraph.portions.add(portion2)

    # Crear una porción de texto con subíndice.
    subscript_portion = slides.Portion()
    subscript_portion.portion_format.escapement = -25
    subscript_portion.text = "i"
    subscript_paragraph.portions.add(subscript_portion)

    # Añadir los párrafos al cuadro de texto.
    shape.text_frame.paragraphs.add(superscript_paragraph)
    shape.text_frame.paragraphs.add(subscript_paragraph)

    presentation.save("TestOut.pptx", slides.export.SaveFormat.PPTX)
```


## **Preguntas frecuentes**

**¿Puedo aplicar superíndice/subíndice en tablas y otros contenedores, no solo en cuadros de texto normales?**

Sí. Puedes dar formato al texto como superíndice o subíndice dentro de cualquier objeto que exponga un [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) (incluidas las celdas de tabla). El formato se aplica a las porciones de texto dentro de ese marco.

**¿Se conservarán los superíndices/subíndices al exportar a PDF, HTML o imágenes?**

Sí. Aspose.Slides conserva el formato de superíndice/subíndice al exportar a formatos comunes como [PDF](/slides/es/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/es/python-net/convert-powerpoint-to-html/), y [imágenes raster](/slides/es/python-net/convert-powerpoint-to-png/) porque el pipeline de renderizado respeta el formato de texto a nivel de porción.

**¿Puedo combinar superíndice/subíndice con hipervínculos en el mismo fragmento de texto?**

Sí. Los [hipervínculos](/slides/es/python-net/manage-hyperlinks/) se asignan a nivel de porción (fragmento), por lo que una porción puede tener simultáneamente un hipervínculo y estar formateada como superíndice o subíndice.