---
title: Línea
type: docs
weight: 50
url: /es/python-net/line/
keywords: "Línea, forma de PowerPoint, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Agregar línea en presentación de PowerPoint en Python"
---

Aspose.Slides para Python a través de .NET admite agregar diferentes tipos de formas a las diapositivas. En este tema, comenzaremos a trabajar con formas agregando líneas a las diapositivas. Usando Aspose.Slides para Python a través de .NET, los desarrolladores no solo pueden crear líneas simples, sino que también se pueden dibujar algunas líneas elegantes en las diapositivas.
## **Crear Línea Simple**
Para agregar una línea simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Obtenga la referencia de una diapositiva utilizando su índice.
- Agregue una AutoShape de tipo Línea usando el método [add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) expuesto por el objeto Shapes.
- Escriba la presentación modificada como un archivo PPTX.

En el ejemplo dado a continuación, hemos agregado una línea a la primera diapositiva de la presentación.

```py
import aspose.slides as slides

# Instanciar la clase PresentationEx que representa el archivo PPTX
with slides.Presentation() as pres:
    # Obtener la primera diapositiva
    sld = pres.slides[0]

    # Agregar una autoshape de tipo línea
    sld.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Escribir el PPTX en el disco
    pres.save("LineShape1_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Crear Línea con Forma de Flecha**
Aspose.Slides para Python a través de .NET también permite a los desarrolladores configurar algunas propiedades de la línea para hacerla más atractiva. Intentemos configurar algunas propiedades de una línea para que parezca una flecha. Siga los pasos a continuación para hacerlo:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Obtenga la referencia de una diapositiva utilizando su índice.
- Agregue una AutoShape de tipo Línea usando el método AddAutoShape expuesto por el objeto Shapes.
- Establezca el estilo de línea en uno de los estilos ofrecidos por Aspose.Slides para Python a través de .NET.
- Establezca el ancho de la línea.
- Establezca el [Estilo de Guion](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) de la línea en uno de los estilos ofrecidos por Aspose.Slides para Python a través de .NET.
- Establezca el [Estilo de Cabeza de Flecha](https://reference.aspose.com/slides/python-net/aspose.slides/linearrowheadstyle/) y la longitud del punto de inicio de la línea.
- Establezca el estilo de la cabeza de flecha y la longitud del punto final de la línea.
- Escriba la presentación modificada como un archivo PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar la clase PresentationEx que representa el archivo PPTX
with slides.Presentation() as pres:
    # Obtener la primera diapositiva
    sld = pres.slides[0]

    # Agregar una autoshape de tipo línea
    shp = sld.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Aplicar algún formato en la línea
    shp.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shp.line_format.width = 10

    shp.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shp.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shp.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shp.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shp.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # Escribir el PPTX en el disco
    pres.save("LineShape2_out.pptx", slides.export.SaveFormat.PPTX)
```