---
title: Administrar objetos de tinta de presentación en Python mediante Java
linktitle: Administrar tinta
type: docs
weight: 95
url: /es/python-java/manage-ink/
keywords:
- tinta
- objeto de tinta
- trazo de tinta
- administrar tinta
- dibujar tinta
- dibujo
- exportación de tinta
- renderizado de tinta
- ocultar tinta
- InkOptions
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Administrar objetos de tinta de PowerPoint, editar trazos y propiedades de pincel, y controlar la apariencia de la tinta durante la exportación a PDF, HTML, SVG, TIFF y de imágenes con Aspose.Slides para Python mediante Java."
---
## **Introducción**

PowerPoint ofrece una función de tinta que permite dibujar trazos libres. La tinta se puede usar para resaltar otros objetos, mostrar conexiones y procesos, y llamar la atención sobre elementos específicos en una diapositiva.

Aspose.Slides proporciona los tipos necesarios para trabajar con objetos de tinta. Por ejemplo, la clase [Ink](https://reference.aspose.com/slides/es/python-java/aspose.slides/ink/) representa un objeto de tinta en una diapositiva.

## **Diferencias entre objetos normales y objetos de tinta**

Los objetos en una diapositiva de PowerPoint se representan normalmente mediante objetos de forma. En su forma más simple, una forma es un contenedor que define el área del propio objeto (su marco) junto con propiedades como el tamaño del contenedor, la forma y el fondo. Para obtener más información, consulta [Shape Layout Format](/slides/es/python-java/shape-manipulations/#access-layout-formats-for-shape).

Sin embargo, cuando PowerPoint maneja un objeto de tinta, ignora todas las propiedades del marco del objeto (contenedor) excepto su tamaño. El tamaño del área del contenedor se determina mediante los métodos estándar [Shape.getWidth](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getWidth) y [Shape.getHeight](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getHeight):

![ink_powerpoint1](ink_powerpoint1.png)

## **Trazos de tinta**

Un trazo de tinta es un elemento básico utilizado para registrar la trayectoria de un lápiz mientras el usuario escribe tinta digital. Un trazo almacena una secuencia de puntos conectados.

La forma más sencilla de codificación especifica las coordenadas X e Y de cada punto de muestra. Cuando se renderizan todos los puntos conectados, producen una imagen como esta:

![ink_powerpoint2](ink_powerpoint2.png)

## **Propiedades del pincel para dibujar**

Un pincel se usa para dibujar líneas que conectan los puntos de un trazo de tinta. El pincel tiene su propio color y tamaño, representados por los métodos [InkBrush.getColor](https://reference.aspose.com/slides/es/python-java/aspose.slides/inkbrush/#getColor) y [InkBrush.getSize](https://reference.aspose.com/slides/es/python-java/aspose.slides/inkbrush/#getSize).

### **Establecer el color del pincel de tinta**

Este código Python muestra cómo establecer el color de un pincel de tinta:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush.setColor(Color.RED)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

### **Establecer el tamaño del pincel de tinta**

Este código Python muestra cómo establecer el tamaño de un pincel de tinta:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush_size = Dimension(5, 10)
            brush.setSize(brush_size)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

En general, el ancho y la altura de un pincel no coinciden, por lo que PowerPoint no muestra el tamaño del pincel (la sección de datos correspondiente aparece atenuada). Cuando el ancho y la altura del pincel coinciden, PowerPoint muestra su tamaño de esta forma:

![ink_powerpoint3](ink_powerpoint3.png)

Para mayor claridad, aumentemos la altura del objeto de tinta y revisemos las dimensiones importantes:

![ink_powerpoint4](ink_powerpoint4.png)

El contenedor (marco) no tiene en cuenta el tamaño de los pinceles; siempre asume que el grosor de la línea es cero (ver la imagen anterior).

Por lo tanto, para determinar el área visible de todo el objeto de tinta, se debe tener en cuenta el tamaño del pincel de sus trazos. Aquí, el objeto objetivo (el trazo de texto manuscrito) se ha escalado al tamaño del contenedor (marco). Cuando el tamaño del contenedor cambia, el tamaño del pincel permanece constante, y viceversa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint utiliza un comportamiento similar para los objetos de texto:

![ink_powerpoint6](ink_powerpoint6.png)

## **Controlar la apariencia de la tinta durante la exportación y el renderizado**

Aspose.Slides proporciona la clase [InkOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/inkoptions/) para controlar cómo aparecen los objetos de tinta en la salida exportada o renderizada. Puedes usar sus propiedades para ocultar la tinta por completo o cambiar la forma en que se interpretan las operaciones de máscara del pincel de tinta.

Las opciones de tinta están disponibles a través de las opciones de exportación o renderizado para varios tipos de salida:

| Salida | Propiedad de opciones de tinta |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/tiffoptions/#getInkOptions) |
| Imagen de diapositiva | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/renderingoptions/#getInkOptions) |

Los siguientes métodos de [InkOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/inkoptions/) exponen las mismas dos configuraciones:

- [getHideInk](https://reference.aspose.com/slides/es/python-java/aspose.slides/inkoptions/#getHideInk) determina si los objetos de tinta se incluyen en la salida. Su valor predeterminado es `False`.
- [getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/es/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) determina si una operación de máscara se interpreta como opacidad al renderizar un pincel de tinta. Su valor predeterminado es `True`; llama a [setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/es/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) con `False` para usar la operación ROP en su lugar.

### **Ocultar objetos de tinta en la salida PDF**

De forma predeterminada, los objetos de tinta permanecen visibles durante la exportación. Para crear una salida limpia sin anotaciones manuscritas u otro contenido de tinta, llama a [InkOptions.setHideInk](https://reference.aspose.com/slides/es/python-java/aspose.slides/inkoptions/#setHideInk) con `True`.

El siguiente ejemplo en Python exporta una presentación a PDF ocultando todos los objetos de tinta:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PdfOptions, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.getInkOptions().setHideInk(True)

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Ocultar objetos de tinta al renderizar una diapositiva como imagen**

Para ocultar los objetos de tinta al renderizar diapositivas como imágenes bitmap, configura [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/renderingoptions/#getInkOptions) y pasa las opciones de renderizado a [Slide.getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/#getImage).

El siguiente ejemplo en Python renderiza la primera diapositiva como una imagen PNG sin objetos de tinta:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RenderingOptions, ImageFormat

presentation = Presentation("presentation.pptx")
try:
    rendering_options = RenderingOptions()
    rendering_options.getInkOptions().setHideInk(True)

    slide = presentation.getSlides().get_Item(0)
    image = slide.getImage(rendering_options)
    try:
        image.save("slide_without_ink.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

### **Controlar el renderizado de la máscara de tinta**

La configuración [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/es/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) controla cómo se interpretan las operaciones de máscara al renderizar pinceles de tinta. El valor predeterminado es `True`, lo que utiliza opacidad. Para usar la operación ROP en su lugar, llama a [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/es/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) con `False`.

El siguiente ejemplo en Python exporta una diapositiva a SVG y utiliza renderizado basado en ROP para las operaciones de máscara de tinta:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.getInkOptions().setInterpretMaskOpAsOpacity(False)

    stream = FileOutputStream("slide.svg")
    try:
        slide = presentation.getSlides().get_Item(0)
        slide.writeAsSvg(stream, svg_options)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

La misma configuración puede aplicarse mediante [TiffOptions.getInkOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/tiffoptions/#getInkOptions) al exportar una presentación o renderizar una diapositiva a TIFF.

### **Elegir si ocultar o conservar la tinta**

Cuando necesitas una versión limpia de una presentación anotada para distribución sin marcas de revisión, llama a [InkOptions.setHideInk](https://reference.aspose.com/slides/es/python-java/aspose.slides/inkoptions/#setHideInk) con `True` durante la exportación.

Deja [InkOptions.getHideInk](https://reference.aspose.com/slides/es/python-java/aspose.slides/inkoptions/#getHideInk) con su valor predeterminado `False` cuando las anotaciones de tinta forman parte del contenido previsto, como comentarios de revisión, notas manuscritas, resaltados o dibujos que deben permanecer visibles en el resultado exportado. Esto permite a las aplicaciones generar salidas de revisión y finales separadas a partir de la misma presentación sin modificar los objetos de tinta originales.

## **Preguntas frecuentes**

**¿Puedo cambiar el color o el tamaño de un trazo de tinta existente?**

Sí. Obtén el trazo mediante [Ink.getTraces](https://reference.aspose.com/slides/es/python-java/aspose.slides/ink/#getTraces), luego cambia su [InkTrace.getBrush](https://reference.aspose.com/slides/es/python-java/aspose.slides/inktrace/#getBrush). Llama a [InkBrush.setColor](https://reference.aspose.com/slides/es/python-java/aspose.slides/inkbrush/#setColor) o [InkBrush.setSize](https://reference.aspose.com/slides/es/python-java/aspose.slides/inkbrush/#setSize) para cambiar el pincel.

**¿Ocultar la tinta modifica la presentación original?**

No. Llamar a [InkOptions.setHideInk](https://reference.aspose.com/slides/es/python-java/aspose.slides/inkoptions/#setHideInk) afecta solo al resultado renderizado o exportado; no elimina ni modifica los objetos de tinta en la presentación original.

**¿Qué formatos de exportación admiten opciones de tinta?**

Puedes configurar opciones de tinta para PDF, HTML, SVG, TIFF y imágenes bitmap de diapositivas mediante las opciones de exportación o renderizado correspondientes mostradas arriba.

**Lecturas adicionales**

* Para leer sobre formas en general, consulta la sección [PowerPoint Shapes](/slides/es/python-java/powerpoint-shapes/).
* Para más información sobre valores efectivos, consulta [Shape Effective Properties](/slides/es/python-java/shape-effective-properties/#get-effective-font-height-value).
* Para detalles sobre la exportación a PDF, consulta [Convert PPT and PPTX to PDF](/slides/es/python-java/convert-powerpoint-to-pdf/).
* Para detalles sobre la exportación a HTML, consulta [Convert PowerPoint Presentations to HTML](/slides/es/python-java/convert-powerpoint-to-html/).
* Para detalles sobre la exportación a SVG, consulta [Render Presentation Slides as SVG Images](/slides/es/python-java/render-a-slide-as-an-svg-image/).
* Para detalles sobre la exportación a TIFF, consulta [Convert PowerPoint Presentations to TIFF](/slides/es/python-java/convert-powerpoint-to-tiff/).
* Para detalles sobre el renderizado de diapositivas a imágenes, consulta [Convert Presentation Slides to Images](/slides/es/python-java/convert-slide/).