---
title: Gestionar superíndice y subíndice en presentaciones usando Python mediante Java
linktitle: Superíndice y subíndice
type: docs
weight: 80
url: /es/python-java/superscript-and-subscript/
keywords:
- superíndice
- subíndice
- añadir superíndice
- añadir subíndice
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Domina el superíndice y subíndice en Aspose.Slides para Python mediante Java y eleva tus presentaciones con un formato de texto profesional para lograr el máximo impacto."
---
## **Visión general**

Aspose.Slides ofrece funciones para integrar texto en superíndice y subíndice en sus presentaciones PowerPoint (PPT, PPTX) y OpenDocument (ODP). Ya sea que necesite resaltar fórmulas químicas, ecuaciones matemáticas o anotar contenido con notas al pie, estas opciones de formato especial ayudan a mantener la claridad y precisión. En este artículo, aprenderá a aplicar de forma fluida los estilos de superíndice y subíndice y a garantizar resultados profesionales en cada diapositiva.

## **Gestionar texto en superíndice y subíndice**

Puede añadir texto en superíndice y subíndice a cualquier parte de un párrafo. Para aplicar este formato en un marco de texto de Aspose.Slides, utilice el método [setEscapement](https://reference.aspose.com/slides/es/python-java/aspose.slides/portionformat/#setEscapement) de la clase [PortionFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/portionformat/).

El valor de escapement varía de -100% (subíndice) a 100% (superíndice). Por ejemplo:

- Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
- Obtener una diapositiva por su índice.
- Añadir un [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) de tipo [ShapeType.Rectangle](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapetype/#Rectangle) a la diapositiva.
- Acceder al [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/) asociado al [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/).
- Borrar los párrafos existentes.
- Crear un párrafo para contener texto en superíndice y añadirlo a la [paragraph collection](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/#getParagraphs) del marco de texto.
- Crear una porción.
- Utilizar [setEscapement](https://reference.aspose.com/slides/es/python-java/aspose.slides/portionformat/#setEscapement) para establecer un valor de 0 a 100 para superíndice (0 significa sin superíndice).
- Establecer el texto de la [Portion](https://reference.aspose.com/slides/es/python-java/aspose.slides/portion/) y añadirlo a la colección de porciones del párrafo.
- Crear un párrafo para contener texto en subíndice y añadirlo a la [paragraph collection](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/#getParagraphs) del marco de texto.
- Crear una porción.
- Utilizar [setEscapement](https://reference.aspose.com/slides/es/python-java/aspose.slides/portionformat/#setEscapement) para establecer un valor de -100 a 0 para subíndice (0 significa sin subíndice).
- Establecer el texto de la [Portion](https://reference.aspose.com/slides/es/python-java/aspose.slides/portion/) y añadirlo a la colección de porciones del párrafo.
- Guardar la presentación como archivo PPTX.

El siguiente ejemplo implementa estos pasos:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Portion, Presentation, SaveFormat, ShapeType

# Crear una presentación.
presentation = Presentation()
try:
    # Obtener la diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Crear un cuadro de texto.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # Crear un párrafo para texto en superíndice.
    superscript_paragraph = Paragraph()

    # Crear una porción con texto normal.
    title_portion = Portion()
    title_portion.setText("SlideTitle")
    superscript_paragraph.getPortions().add(title_portion)

    # Crear una porción con texto en superíndice.
    superscript_portion = Portion()
    superscript_portion.getPortionFormat().setEscapement(30)
    superscript_portion.setText("TM")
    superscript_paragraph.getPortions().add(superscript_portion)

    # Crear un párrafo para texto en subíndice.
    subscript_paragraph = Paragraph()

    # Crear una porción con texto normal.
    base_portion = Portion()
    base_portion.setText("a")
    subscript_paragraph.getPortions().add(base_portion)

    # Crear una porción con texto en subíndice.
    subscript_portion = Portion()
    subscript_portion.getPortionFormat().setEscapement(-25)
    subscript_portion.setText("i")
    subscript_paragraph.getPortions().add(subscript_portion)

    # Añadir los párrafos al cuadro de texto.
    text_frame.getParagraphs().add(superscript_paragraph)
    text_frame.getParagraphs().add(subscript_paragraph)

    presentation.save("formatText.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Se conservará el superíndice y subíndice al exportar a PDF u otros formatos?**

Sí, Aspose.Slides conserva correctamente el formato de superíndice y subíndice al exportar presentaciones a PDF, PPT/PPTX, imágenes y otros formatos compatibles. El formato especializado permanece intacto en todos los archivos de salida.

**¿Se pueden combinar superíndice y subíndice con otros estilos de formato como negrita o cursiva?**

Sí, Aspose.Slides permite mezclar varios estilos de texto dentro de una única porción de texto. Puede habilitar negrita, cursiva, subrayado y aplicar simultáneamente superíndice o subíndice configurando las propiedades correspondientes en [PortionFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/portionformat/).

**¿Funciona el formato de superíndice y subíndice para texto dentro de tablas, gráficos o SmartArt?**

Sí, Aspose.Slides admite el formato dentro de la mayoría de los objetos, incluidas tablas y elementos de gráfico. Cuando se trabaja con SmartArt, es necesario acceder a los elementos apropiados (como [SmartArtNode](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartartnode/)) y sus contenedores de texto, y luego configurar las propiedades de [PortionFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/portionformat/) de manera similar.