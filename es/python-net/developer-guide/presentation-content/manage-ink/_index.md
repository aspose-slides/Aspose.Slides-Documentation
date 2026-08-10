---
title: Gestionar objetos de tinta en presentaciones con Python
linktitle: Gestionar tinta
type: docs
weight: 95
url: /es/python-net/manage-ink/
keywords:
- tinta
- objeto de tinta
- trazo de tinta
- gestionar tinta
- dibujar tinta
- dibujo
- exportación de tinta
- renderizado de tinta
- ocultar tinta
- InkOptions
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Gestiona objetos de tinta de PowerPoint, edita trazos y propiedades del pincel, y controla la apariencia de la tinta durante la exportación a PDF, HTML, SVG, TIFF y de imágenes con Aspose.Slides para Python mediante .NET."
---
## **Introducción**

PowerPoint ofrece una función de tinta que le permite dibujar trazos libres. La tinta se puede usar para resaltar otros objetos, mostrar conexiones y procesos, y dirigir la atención a elementos específicos en una diapositiva.

El espacio de nombres [aspose.slides.ink](https://reference.aspose.com/slides/es/python-net/aspose.slides.ink/) contiene las clases necesarias para trabajar con objetos de tinta. Por ejemplo, la clase [Ink](https://reference.aspose.com/slides/es/python-net/aspose.slides.ink/ink/) representa un objeto de tinta en una diapositiva.

## **Diferencias entre objetos regulares y objetos de tinta**

Los objetos en una diapositiva de PowerPoint suelen estar representados por objetos de forma. En su forma más simple, una forma es un contenedor que define el área del propio objeto (su marco) junto con propiedades como el tamaño del contenedor, la forma y el fondo. Para obtener más información, consulte [Shape Layout Format](https://docs.aspose.com/slides/es/python-net/shape-manipulations/#access-layout-formats-for-shape).

Sin embargo, cuando PowerPoint maneja un objeto de tinta, ignora todas las propiedades del marco del objeto (contenedor) excepto su tamaño. El tamaño del área del contenedor se determina mediante las propiedades estándar [Ink.width](https://reference.aspose.com/slides/es/python-net/aspose.slides.ink/ink/width/) y [Ink.height](https://reference.aspose.com/slides/es/python-net/aspose.slides.ink/ink/height/):

![ink_powerpoint1](ink_powerpoint1.png)

## **Trazos de tinta**

Un trazo de tinta es un elemento básico usado para registrar la trayectoria de un bolígrafo mientras el usuario escribe tinta digital. Un trazo almacena una secuencia de puntos conectados.

La forma más simple de codificación especifica las coordenadas X e Y de cada punto de muestra. Cuando se renderizan todos los puntos conectados, se produce una imagen como esta:

![ink_powerpoint2](ink_powerpoint2.png)

## **Propiedades del pincel para dibujar**

Un pincel se utiliza para dibujar líneas que conectan los puntos de un trazo de tinta. Sus propiedades [InkBrush.color](https://reference.aspose.com/slides/es/python-net/aspose.slides.ink/inkbrush/color/) y [InkBrush.size](https://reference.aspose.com/slides/es/python-net/aspose.slides.ink/inkbrush/size/) controlan su color y tamaño.

### **Establecer color del pincel de tinta**

Este código Python muestra cómo establecer el color de un pincel de tinta:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.color = draw.Color.red
```

### **Establecer tamaño del pincel de tinta**

Este código Python muestra cómo establecer el tamaño de un pincel de tinta:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.size = draw.SizeF(5.0, 10.0)
```

En general, el ancho y la altura de un pincel no coinciden, por lo que PowerPoint no muestra el tamaño del pincel (la sección de datos correspondiente está atenuada). Cuando el ancho y la altura del pincel coinciden, PowerPoint muestra su tamaño de la siguiente manera:

![ink_powerpoint3](ink_powerpoint3.png)

Para mayor claridad, aumentemos la altura del objeto de tinta y revisemos las dimensiones importantes:

![ink_powerpoint4](ink_powerpoint4.png)

El contenedor (marco) no tiene en cuenta el tamaño de los pinceles; siempre asume que el grosor de la línea es cero (ver la imagen anterior).

Por lo tanto, para determinar el área visible de todo el objeto de tinta, se debe tener en cuenta el tamaño del pincel de sus trazos. Aquí, el objeto objetivo (el trazo de texto manuscrito) se ha escalado al tamaño del contenedor (marco). Cuando el tamaño del contenedor cambia, el tamaño del pincel permanece constante, y viceversa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint utiliza un comportamiento similar para los objetos de texto:

![ink_powerpoint6](ink_powerpoint6.png)

## **Control de la apariencia de la tinta durante la exportación y el renderizado**

Aspose.Slides proporciona la clase [InkOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/inkoptions/) para controlar cómo aparecen los objetos de tinta en la salida exportada o renderizada. Puede usar sus propiedades para ocultar la tinta por completo o cambiar la forma en que se interpretan las operaciones de máscara del pincel de tinta.

Las opciones de tinta están disponibles a través de las opciones de exportación o renderizado para varios tipos de salida:

| Salida | Propiedad de opciones de tinta |
| --- | --- |
| PDF | [`PdfOptions.ink_options`](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/pdfoptions/ink_options/) |
| HTML | [`HtmlOptions.ink_options`](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/htmloptions/ink_options/) |
| SVG | [`SVGOptions.ink_options`](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/svgoptions/ink_options/) |
| TIFF | [`TiffOptions.ink_options`](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/tiffoptions/ink_options/) |
| Slide image | [`RenderingOptions.ink_options`](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/renderingoptions/ink_options/) |

Los mismos dos ajustes están disponibles a través de estas propiedades:

- [`InkOptions.hide_ink`](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/inkoptions/hide_ink/) determina si los objetos de tinta se incluyen en la salida. Su valor predeterminado es `False`.
- [`InkOptions.interpret_mask_op_as_opacity`](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) determina si una operación de máscara se interpreta como opacidad al renderizar un pincel de tinta. Su valor predeterminado es `True`; establézcalo en `False` para usar la operación ROP en su lugar.

### **Ocultar objetos de tinta en la salida PDF**

De forma predeterminada, los objetos de tinta permanecen visibles durante la exportación. Establezca [`InkOptions.hide_ink`](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/inkoptions/hide_ink/) a `True` cuando necesite una salida limpia sin anotaciones manuscritas u otro contenido de tinta.

El siguiente ejemplo en Python exporta una presentación a PDF mientras oculta todos los objetos de tinta:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    pdf_options = slides.export.PdfOptions()
    pdf_options.ink_options.hide_ink = True

    presentation.save("presentation_without_ink.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Ocultar objetos de tinta al renderizar una diapositiva como imagen**

Para ocultar los objetos de tinta al renderizar diapositivas como imágenes bitmap, configure [`RenderingOptions.ink_options`](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/renderingoptions/ink_options/) y pase las opciones de renderizado al método [`Slide.get_image`](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/get_image/).

El siguiente ejemplo en Python renderiza la primera diapositiva como una imagen PNG sin objetos de tinta:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    rendering_options = slides.export.RenderingOptions()
    rendering_options.ink_options.hide_ink = True

    with presentation.slides[0].get_image(rendering_options) as image:
        image.save("slide_without_ink.png", slides.ImageFormat.PNG)
```

### **Controlar el renderizado de máscara de tinta**

La propiedad [`InkOptions.interpret_mask_op_as_opacity`](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) controla cómo se interpretan las operaciones de máscara al renderizar pinceles de tinta. El valor predeterminado es `True`, que utiliza opacidad. Establezca la propiedad en `False` para usar la operación ROP en su lugar.

El siguiente ejemplo en Python exporta una diapositiva a SVG y utiliza renderizado basado en ROP para las operaciones de máscara de tinta:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.ink_options.interpret_mask_op_as_opacity = False

    with open("slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

El mismo ajuste puede aplicarse a través de [`TiffOptions.ink_options`](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/tiffoptions/ink_options/) al exportar una presentación o renderizar una diapositiva a TIFF.

### **Elegir si ocultar o preservar la tinta**

Establezca [`InkOptions.hide_ink`](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/inkoptions/hide_ink/) a `True` cuando el archivo exportado deba ser una versión limpia de una presentación anotada, por ejemplo, una copia final destinada a distribución sin marcas de revisión.

Deje [`InkOptions.hide_ink`](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/inkoptions/hide_ink/) con su valor predeterminado `False` cuando las anotaciones de tinta formen parte del contenido previsto, como comentarios de revisión, notas manuscritas, resaltados o dibujos que deben permanecer visibles en el resultado exportado. Esto permite a las aplicaciones generar salidas de revisión y finales separadas a partir de la misma presentación sin modificar los objetos de tinta originales.

## **Preguntas frecuentes**

**¿Puedo cambiar el color o el tamaño de un trazo de tinta existente?**

Sí. Obtenga el trazo desde [Ink.traces](https://reference.aspose.com/slides/es/python-net/aspose.slides.ink/ink/traces/), luego cambie su [InkTrace.brush](https://reference.aspose.com/slides/es/python-net/aspose.slides.ink/inktrace/brush/). Puede establecer las propiedades [InkBrush.color](https://reference.aspose.com/slides/es/python-net/aspose.slides.ink/inkbrush/color/) y [InkBrush.size](https://reference.aspose.com/slides/es/python-net/aspose.slides.ink/inkbrush/size/) del pincel.

**¿Ocultar la tinta modifica la presentación original?**

No. [`InkOptions.hide_ink`](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/inkoptions/hide_ink/) afecta solo al resultado renderizado o exportado; no elimina ni modifica los objetos de tinta en la presentación original.

**¿Qué formatos de exportación admiten opciones de tinta?**

Puede configurar opciones de tinta para PDF, HTML, SVG, TIFF y imágenes bitmap de diapositivas mediante las opciones de exportación o renderizado correspondientes mostradas arriba.

**Lecturas adicionales**

* Para leer sobre formas en general, consulte la sección [Formas de PowerPoint](https://docs.aspose.com/slides/es/python-net/powerpoint-shapes/).
* Para obtener más información sobre valores efectivos, vea [Propiedades efectivas de forma](https://docs.aspose.com/slides/es/python-net/shape-effective-properties/#get-effective-font-height-value).
* Para detalles sobre la exportación a PDF, vea [Convertir PPT y PPTX a PDF](https://docs.aspose.com/slides/es/python-net/convert-powerpoint-to-pdf/).
* Para detalles sobre la exportación a HTML, vea [Convertir presentaciones de PowerPoint a HTML](https://docs.aspose.com/slides/es/python-net/convert-powerpoint-to-html/).
* Para detalles sobre la exportación a SVG, vea [Renderizar diapositivas de presentación como imágenes SVG](https://docs.aspose.com/slides/es/python-net/render-a-slide-as-an-svg-image/).
* Para detalles sobre la exportación a TIFF, vea [Convertir presentaciones de PowerPoint a TIFF](https://docs.aspose.com/slides/es/python-net/convert-powerpoint-to-tiff/).
* Para detalles sobre el renderizado de diapositiva a imagen, vea [Convertir diapositivas de presentación a imágenes](https://docs.aspose.com/slides/es/python-net/convert-slide/).