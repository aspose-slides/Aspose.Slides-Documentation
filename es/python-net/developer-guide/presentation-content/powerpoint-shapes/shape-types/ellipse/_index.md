---
title: Agregar Elipses a Presentaciones en Python
linktitle: Elipse
type: docs
weight: 30
url: /es/python-net/ellipse/
keywords:
- elipse
- forma
- agregar elipse
- crear elipse
- dibujar elipse
- elipse formateada
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprenda a crear, formatear y manipular formas de elipse en Aspose.Slides para Python a través de .NET en presentaciones PPT, PPTX y ODP, con ejemplos de código incluidos."
---

## **Crear Elipse**
En este tema, presentaremos a los desarrolladores cómo agregar formas de elipse a sus diapositivas usando Aspose.Slides for Python via .NET. Aspose.Slides for Python via .NET ofrece un conjunto de API más sencillo para dibujar diferentes tipos de formas con solo unas pocas líneas de código. Para agregar una elipse simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. Obtener la referencia de una diapositiva usando su Index
3. Agregar un AutoShape de tipo Ellipse usando el método AddAutoShape expuesto por el objeto IShapes
4. Guardar la presentación modificada como un archivo PPTX

En el ejemplo a continuación, hemos agregado una elipse a la primera diapositiva.
```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa el PPTX
with slides.Presentation() as pres:
    # Obtener la primera diapositiva
    sld = pres.slides[0]

    # Agregar una autoforma de tipo elipse
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    #Guardar el archivo PPTX en disco
    pres.save("EllipseShp1_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Crear Elipse Formateada**
Para agregar una elipse mejor formateada a una diapositiva, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtener la referencia de una diapositiva usando su Index.
3. Agregar un AutoShape de tipo Ellipse usando el método AddAutoShape expuesto por el objeto IShapes.
4. Establecer el tipo de relleno de la elipse a sólido.
5. Establecer el color de la elipse usando la propiedad SolidFillColor.Color expuesta por el objeto FillFormat asociado al objeto IShape.
6. Establecer el color de las líneas de la elipse.
7. Establecer el ancho de las líneas de la elipse.
8. Guardar la presentación modificada como un archivo PPTX.

En el ejemplo a continuación, hemos agregado una elipse formateada a la primera diapositiva de la presentación.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar la clase Presentation que representa el PPTX
with slides.Presentation() as pres:
    # Obtener la primera diapositiva
    sld = pres.slides[0]

    # Agregar una autoforma de tipo elipse
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # Aplicar algo de formato a la forma de elipse
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Aplicar algo de formato a la línea de la elipse
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Guardar el archivo PPTX en disco
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**¿Cómo establezco la posición exacta y el tamaño de una elipse respecto a las unidades de la diapositiva?**
Las coordenadas y tamaños se especifican típicamente **en puntos**. Para obtener resultados predecibles, base sus cálculos en el tamaño de la diapositiva y convierta los milímetros o pulgadas necesarios a puntos antes de asignar los valores.

**¿Cómo puedo colocar una elipse por encima o por debajo de otros objetos (controlar el orden de apilamiento)?**
Ajuste el orden de dibujo del objeto llevándolo al frente o enviándolo al fondo. Esto permite que la elipse se superponga a otros objetos o revele los que están debajo de ella.

**¿Cómo animo la aparición o énfasis de una elipse?**
[Apply](/slides/es/python-net/shape-animation/) efectos de entrada, énfasis o salida a la forma, y configure disparadores y temporización para orquestar cuándo y cómo se reproduce la animación.