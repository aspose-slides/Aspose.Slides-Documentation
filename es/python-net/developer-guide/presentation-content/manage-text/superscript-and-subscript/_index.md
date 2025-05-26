---
title: Gestionar superíndice y subíndice en Python
linktitle: Superíndice y subíndice
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
description: "Domina el superíndice y el subíndice en Aspose.Slides para Python vía .NET y eleva tus presentaciones con un formato de texto profesional para un impacto máximo."
---

## **Gestionar Texto en Superíndice y Subíndice**
Puedes agregar texto en superíndice y subíndice dentro de cualquier porción de párrafo. Para agregar texto en Superíndice o Subíndice en el marco de texto de Aspose.Slides, se deben utilizar las propiedades **Escapement** de la clase PortionFormat.

Esta propiedad devuelve o establece el texto en superíndice o subíndice (valor de -100% (subíndice) a 100% (superíndice). Por ejemplo:

- Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Obtén la referencia de una diapositiva utilizando su índice.
- Agrega una forma de IAutoShape de tipo Rectángulo a la diapositiva.
- Accede al ITextFrame asociado con el IAutoShape.
- Limpia los párrafos existentes.
- Crea un nuevo objeto de párrafo para contener texto en superíndice y agrégalo a la colección IParagraphs del ITextFrame.
- Crea un nuevo objeto de porción.
- Establece la propiedad Escapement para la porción entre 0 y 100 para agregar superíndice. (0 significa sin superíndice)
- Establece algún texto para la Porción y luego agrégalo a la colección de porciones del párrafo.
- Crea un nuevo objeto de párrafo para contener texto en subíndice y agrégalo a la colección IParagraphs del ITextFrame.
- Crea un nuevo objeto de porción.
- Establece la propiedad Escapement para la porción entre 0 y -100 para agregar subíndice. (0 significa sin subíndice)
- Establece algún texto para la Porción y luego agrégalo a la colección de porciones del párrafo.
- Guarda la presentación como un archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # Obtener diapositiva
    slide = presentation.slides[0]

    # Crear cuadro de texto
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    textFrame = shape.text_frame
    textFrame.paragraphs.clear()

    # Crear párrafo para texto en superíndice
    superPar = slides.Paragraph()

    # Crear porción con texto habitual
    portion1 = slides.Portion()
    portion1.text = "SlideTitle"
    superPar.portions.add(portion1)

    # Crear porción con texto en superíndice
    superPortion = slides.Portion()
    superPortion.portion_format.escapement = 30
    superPortion.text = "TM"
    superPar.portions.add(superPortion)

    # Crear párrafo para texto en subíndice
    paragraph2 = slides.Paragraph()

    # Crear porción con texto habitual
    portion2 = slides.Portion()
    portion2.text = "a"
    paragraph2.portions.add(portion2)

    # Crear porción con texto en subíndice
    subPortion = slides.Portion()
    subPortion.portion_format.escapement = -25
    subPortion.text = "i"
    paragraph2.portions.add(subPortion)

    # Agregar párrafos al cuadro de texto
    textFrame.paragraphs.add(superPar)
    textFrame.paragraphs.add(paragraph2)

    presentation.save("TestOut.pptx", slides.export.SaveFormat.PPTX)
```