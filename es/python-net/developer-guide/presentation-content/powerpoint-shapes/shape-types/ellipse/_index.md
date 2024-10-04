---
title: Elipse
type: docs
weight: 30
url: /python-net/ellipse/
keywords: "Elipse, forma de PowerPoint, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Crear elipse en presentación de PowerPoint en Python"
---


## **Crear Elipse**
En este tema, presentaremos a los desarrolladores cómo agregar formas de elipse a sus diapositivas utilizando Aspose.Slides para Python a través de .NET. Aspose.Slides para Python a través de .NET proporciona un conjunto más fácil de APIs para dibujar diferentes tipos de formas con solo unas pocas líneas de código. Para agregar una elipse simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
1. Obtenga la referencia de una diapositiva utilizando su índice
1. Agregue una AutoShape de tipo Elipse utilizando el método AddAutoShape expuesto por el objeto IShapes
1. Escriba la presentación modificada como un archivo PPTX

En el ejemplo que se presenta a continuación, hemos agregado una elipse a la primera diapositiva.

```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa el PPTX
with slides.Presentation() as pres:
    # Obtener la primera diapositiva
    sld = pres.slides[0]

    # Agregar AutoShape de tipo elipse
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # Escribir el archivo PPTX en el disco
    pres.save("EllipseShp1_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Crear Elipse Formateada**
Para agregar una elipse mejor formateada a una diapositiva, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenga la referencia de una diapositiva utilizando su índice.
1. Agregue una AutoShape de tipo Elipse utilizando el método AddAutoShape expuesto por el objeto IShapes.
1. Establezca el tipo de relleno de la elipse a Sólido.
1. Establezca el color de la elipse utilizando la propiedad SolidFillColor.Color expuesta por el objeto FillFormat asociado al objeto IShape.
1. Establezca el color de las líneas de la elipse.
1. Establezca el ancho de las líneas de la elipse.
1. Escriba la presentación modificada como un archivo PPTX.

En el ejemplo que se presenta a continuación, hemos agregado una elipse formateada a la primera diapositiva de la presentación.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar la clase Presentation que representa el PPTX
with slides.Presentation() as pres:
    # Obtener la primera diapositiva
    sld = pres.slides[0]

    # Agregar AutoShape de tipo elipse
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # Aplicar un formato a la forma de elipse
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Aplicar un formato a la línea de la elipse
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    # Escribir el archivo PPTX en el disco
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```