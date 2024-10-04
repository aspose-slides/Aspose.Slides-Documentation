---
title: Rectángulo
type: docs
weight: 80
url: /python-net/rectangle/
keywords: "Crear rectángulo, forma de PowerPoint, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Crear rectángulo en presentación de PowerPoint en Python"
---


## **Crear Rectángulo Simple**
Al igual que en los temas anteriores, este también trata sobre añadir una forma y esta vez la forma que discutiremos es el Rectángulo. En este tema, hemos descrito cómo los desarrolladores pueden añadir rectángulos simples o formateados a sus diapositivas utilizando Aspose.Slides para Python a través de .NET. Para añadir un rectángulo simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenga la referencia de una diapositiva utilizando su índice.
1. Agregue un IAutoShape de tipo Rectángulo utilizando el método AddAutoShape expuesto por el objeto IShapes.
1. Escriba la presentación modificada como un archivo PPTX.

En el ejemplo dado a continuación, hemos añadido un rectángulo simple a la primera diapositiva de la presentación.

```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa el PPTX
with slides.Presentation() as pres:
    # Obtener la primera diapositiva
    sld = pres.slides[0]

    # Agregar autoshape de tipo rectángulo
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Escribir el archivo PPTX en el disco
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Crear Rectángulo Formateado**
Para añadir un rectángulo formateado a una diapositiva, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenga la referencia de una diapositiva utilizando su índice.
1. Agregue un IAutoShape de tipo Rectángulo utilizando el método AddAutoShape expuesto por el objeto IShapes.
1. Establezca el tipo de relleno del Rectángulo a Sólido.
1. Establezca el color del Rectángulo utilizando la propiedad SolidFillColor.Color expuesta por el objeto FillFormat asociado con el objeto IShape.
1. Establezca el color de las líneas del Rectángulo.
1. Establezca el ancho de las líneas del Rectángulo.
1. Escriba la presentación modificada como archivo PPTX.
   Los pasos anteriores se implementan en el ejemplo dado a continuación.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar la clase Presentation que representa el PPTX
with slides.Presentation() as pres:
    # Obtener la primera diapositiva
    sld = pres.slides[0]

    # Agregar autoshape de tipo rectángulo
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Aplicar algún formato a la forma del rectángulo
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Aplicar algún formato a la línea del rectángulo
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    # Escribir el archivo PPTX en el disco
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```