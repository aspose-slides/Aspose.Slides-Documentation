---
title: Agregar rectángulos a presentaciones en Python
linktitle: Rectángulo
type: docs
weight: 80
url: /es/python-net/rectangle/
keywords:
- agregar rectángulo
- crear rectángulo
- forma de rectángulo
- rectángulo simple
- rectángulo con formato
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Mejore sus presentaciones PowerPoint y OpenDocument añadiendo rectángulos con Aspose.Slides para Python a través de .NET—diseñe y modifique formas programáticamente."
---

## **Crear rectángulo simple**
Al igual que en los temas anteriores, este también trata sobre agregar una forma y esta vez la forma de la que hablaremos es Rectángulo. En este tema, hemos descrito cómo los desarrolladores pueden agregar rectángulos simples o formateados a sus diapositivas usando Aspose.Slides para Python a través de .NET. Para agregar un rectángulo simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenga la referencia de una diapositiva usando su índice.
3. Agregue un IAutoShape de tipo Rectangle usando el método AddAutoShape expuesto por el objeto IShapes.
4. Guarde la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos agregado un rectángulo simple a la primera diapositiva de la presentación.
```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa el PPTX
with slides.Presentation() as pres:
    # Obtener la primera diapositiva
    sld = pres.slides[0]

    # Añadir una autoshape de tipo rectángulo
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Escribir el archivo PPTX en disco
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Crear rectángulo formateado**
Para agregar un rectángulo formateado a una diapositiva, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenga la referencia de una diapositiva usando su índice.
3. Agregue un IAutoShape de tipo Rectangle usando el método AddAutoShape expuesto por el objeto IShapes.
4. Establezca el tipo de relleno del rectángulo a sólido.
5. Establezca el color del rectángulo mediante la propiedad SolidFillColor.Color expuesta por el objeto FillFormat asociado al objeto IShape.
6. Establezca el color de las líneas del rectángulo.
7. Establezca el ancho de las líneas del rectángulo.
8. Guarde la presentación modificada como archivo PPTX.

Los pasos anteriores se implementan en el ejemplo que se muestra a continuación.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar la clase Presentation que representa el PPTX
with slides.Presentation() as pres:
    # Obtener la primera diapositiva
    sld = pres.slides[0]

    # Agregar una autoshape de tipo rectángulo
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Aplicar formato a la forma de rectángulo
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Aplicar formato a la línea del rectángulo
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Escribir el archivo PPTX en disco
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Preguntas frecuentes**

**¿Cómo agregar un rectángulo con esquinas redondeadas?**  
Utilice el [shape type](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) de esquinas redondeadas y ajuste el radio de la esquina en las propiedades de la forma; el redondeado también puede aplicarse por esquina mediante ajustes geométricos.

**¿Cómo lleno un rectángulo con una imagen (textura)?**  
Seleccione el [fill type](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) de imagen, proporcione la fuente de la imagen y configure los [modos de estiramiento/segmentación](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/).

**¿Puede un rectángulo tener sombra y resplandor?**  
Sí. [Outer/inner shadow, glow, and soft edges](/slides/es/python-net/shape-effect/) están disponibles con parámetros ajustables.

**¿Puedo convertir un rectángulo en un botón con un hipervínculo?**  
Sí. [Assign a hyperlink](/slides/es/python-net/manage-hyperlinks/) al hacer clic en la forma (ir a una diapositiva, archivo, dirección web o correo electrónico).

**¿Cómo puedo proteger un rectángulo de movimientos y cambios?**  
[Use shape locks](/slides/es/python-net/applying-protection-to-presentation/): puede prohibir mover, redimensionar, seleccionar o editar texto para preservar el diseño.

**¿Puedo convertir un rectángulo a una imagen raster o SVG?**  
Sí. Puede [render the shape](http://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) a una imagen con un tamaño/escala especificado o [export it as SVG](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) para uso vectorial.

**¿Cómo obtener rápidamente las propiedades reales (efectivas) de un rectángulo considerando el tema y la herencia?**  
[Use the shape’s effective properties](/slides/es/python-net/shape-effective-properties/): la API devuelve valores calculados que tienen en cuenta los estilos de tema, el diseño y la configuración local, simplificando el análisis de formato.