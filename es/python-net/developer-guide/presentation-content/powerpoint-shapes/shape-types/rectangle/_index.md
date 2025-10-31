---
title: Añadir rectángulos a presentaciones en Python
linktitle: Rectángulo
type: docs
weight: 80
url: /es/python-net/rectangle/
keywords:
- añadir rectángulo
- crear rectángulo
- forma de rectángulo
- rectángulo simple
- rectángulo con formato
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Mejore sus presentaciones PowerPoint y OpenDocument añadiendo rectángulos con Aspose.Slides para Python vía .NET, diseñando y modificando formas de forma programática."
---

## **Crear rectángulo simple**
Al igual que en temas anteriores, este también trata sobre agregar una forma y, en esta ocasión, la forma que discutiremos es el Rectángulo. En este tema, describimos cómo los desarrolladores pueden añadir rectángulos simples o con formato a sus diapositivas usando Aspose.Slides para Python vía .NET. Para añadir un rectángulo simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenga la referencia de una diapositiva usando su índice.
3. Añada un IAutoShape de tipo Rectángulo mediante el método AddAutoShape expuesto por el objeto IShapes.
4. Guarde la presentación modificada como un archivo PPTX.

En el ejemplo a continuación, hemos añadido un rectángulo simple a la primera diapositiva de la presentación.

```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa el PPTX
with slides.Presentation() as pres:
    # Obtener la primera diapositiva
    sld = pres.slides[0]

    # Añadir autoshape de tipo rectángulo
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Guardar el archivo PPTX en disco
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Crear rectángulo con formato**
Para añadir un rectángulo con formato a una diapositiva, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenga la referencia de una diapositiva usando su índice.
3. Añada un IAutoShape de tipo Rectángulo mediante el método AddAutoShape expuesto por el objeto IShapes.
4. Establezca el tipo de relleno del rectángulo a sólido.
5. Defina el color del rectángulo usando la propiedad SolidFillColor.Color del objeto FillFormat asociado al objeto IShape.
6. Defina el color de las líneas del rectángulo.
7. Establezca el ancho de las líneas del rectángulo.
8. Guarde la presentación modificada como archivo PPTX.  
Los pasos anteriores se implementan en el ejemplo que sigue.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar la clase Presentation que representa el PPTX
with slides.Presentation() as pres:
    # Obtener la primera diapositiva
    sld = pres.slides[0]

    # Añadir autoshape de tipo rectángulo
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Aplicar algo de formato a la forma de rectángulo
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Aplicar algo de formato a la línea del rectángulo
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    # Guardar el archivo PPTX en disco
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**¿Cómo añado un rectángulo con esquinas redondeadas?**  
Utilice el tipo de forma [rounded-corner](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) y ajuste el radio de las esquinas en las propiedades de la forma; también puede aplicar redondeo por esquina mediante ajustes geométricos.

**¿Cómo lleno un rectángulo con una imagen (textura)?**  
Seleccione el tipo de relleno [picture](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), proporcione la fuente de la imagen y configure los modos de [stretching/tiling](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/).

**¿Puede un rectángulo tener sombra y resplandor?**  
Sí. Las sombras [externas/internas], el resplandor y los bordes suaves](/slides/es/python-net/shape-effect/) están disponibles con parámetros ajustables.

**¿Puedo convertir un rectángulo en un botón con un hipervínculo?**  
Sí. [Asigne un hipervínculo](/slides/es/python-net/manage-hyperlinks/) al clic de la forma (ir a una diapositiva, archivo, dirección web o correo electrónico).

**¿Cómo puedo proteger un rectángulo de moverlo y cambios?**  
[Utilice bloqueos de forma](/slides/es/python-net/applying-protection-to-presentation/): puede impedir mover, cambiar tamaño, seleccionar o editar texto para preservar el diseño.

**¿Puedo convertir un rectángulo a una imagen raster o SVG?**  
Sí. Puede [renderizar la forma](http://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) a una imagen con tamaño/escala especificados o [exportarla como SVG](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) para uso vectorial.

**¿Cómo obtengo rápidamente las propiedades reales (efectivas) de un rectángulo considerando el tema y la herencia?**  
[Utilice las propiedades efectivas de la forma](/slides/es/python-net/shape-effective-properties/): la API devuelve valores calculados que tienen en cuenta estilos de tema, diseño y configuraciones locales, simplificando el análisis de formato.