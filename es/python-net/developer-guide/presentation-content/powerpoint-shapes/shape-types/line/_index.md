---
title: Crear formas de línea en presentaciones con Python
linktitle: Línea
type: docs
weight: 50
url: /es/python-net/line/
keywords:
- línea
- crear línea
- añadir línea
- línea simple
- configurar línea
- personalizar línea
- estilo de guión
- punta de flecha
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprenda a manipular el formato de líneas en presentaciones PowerPoint y OpenDocument con Aspose.Slides para Python a través de .NET. Descubra propiedades, métodos y ejemplos."
---

## **Visión general**

Aspose.Slides para Python a través de .NET admite la incorporación de diferentes tipos de formas a las diapositivas. En este tema, empezaremos a trabajar con formas añadiendo líneas a las diapositivas. Con Aspose.Slides, los desarrolladores pueden no solo crear líneas simples, sino también dibujar líneas más elaboradas en las diapositivas.

## **Crear líneas simples**

Use Aspose.Slides para añadir una línea simple a una diapositiva como separador o conector. Para añadir una línea simple a una diapositiva seleccionada en una presentación, siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenga una referencia a la diapositiva por índice.
3. Agregue una [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) de tipo `LINE` usando el método `add_auto_shape` en el objeto [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).
4. Guarde la presentación como un archivo PPTX.

En el ejemplo a continuación, se añade una línea a la primera diapositiva de la presentación.

```py
import aspose.slides as slides

# Instanciar la clase Presentation.
with slides.Presentation() as presentation:

    # Obtener la primera diapositiva.
    slide = presentation.slides[0]

    # Agregar una autoforma del tipo LINE.
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Guardar la presentación como un archivo PPTX.
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Crear líneas con forma de flecha**

Aspose.Slides le permite configurar propiedades de la línea para que resulten más atractivas visualmente. A continuación, configuramos algunas propiedades de una línea para que tenga forma de flecha. Siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenga una referencia a una diapositiva por índice.
3. Agregue una [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) de tipo `LINE` usando el método `add_auto_shape` en el objeto [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).
4. Configure el [estilo de línea](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/).
5. Configure el ancho de la línea.
6. Configure el [estilo de guión](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/).
7. Configure el [estilo de punta de flecha](https://reference.aspose.com/slides/python-net/aspose.slides/linearrowheadstyle/) y la longitud para el punto de inicio de la línea.
8. Configure el estilo de punta de flecha y la longitud para el punto final de la línea.
9. Guarde la presentación como un archivo PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar la clase Presentation que representa el archivo PPTX.
with slides.Presentation() as presentation:
    # Obtener la primera diapositiva.
    slide = presentation.slides[0]

    # Agregar una autoforma del tipo LINE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Aplicar formato a la línea.
    shape.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shape.line_format.width = 10

    shape.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shape.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shape.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shape.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shape.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # Guardar la presentación como un archivo PPTX.
    presentation.save("line_shape_2.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Puedo convertir una línea regular en un conector para que se “ajuste” a las formas?**

No. Una línea regular (una [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) de tipo [LINE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/)) no se convierte automáticamente en un conector. Para que se ajuste a las formas, use el tipo [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/) dedicado y las [API correspondientes](/slides/es/python-net/connector/) para conexiones.

**¿Qué debo hacer si las propiedades de una línea se heredan del tema y es difícil determinar los valores finales?**

Consulte las [propiedades efectivas](/slides/es/python-net/shape-effective-properties/) a través de las clases [ILineFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilinefillformateffectivedata/), que ya tienen en cuenta la herencia y los estilos del tema.

**¿Puedo bloquear una línea contra la edición (mover, redimensionar)?**

Sí. Las formas proporcionan [objetos de bloqueo](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) que le permiten [denegar operaciones de edición](/slides/es/python-net/applying-protection-to-presentation/).