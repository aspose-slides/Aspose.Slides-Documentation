---
title: Gestionar objetos de tinta de presentación en .NET
linktitle: Gestionar tinta
type: docs
weight: 95
url: /es/net/manage-ink/
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
- IInkOptions
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Gestionar objetos de tinta de PowerPoint, editar trazos y propiedades del pincel, y controlar la apariencia de la tinta durante la exportación a PDF, HTML, SVG, TIFF e imágenes con Aspose.Slides para .NET."
---
## **Introducción**

PowerPoint proporciona una función de tinta que le permite dibujar trazos libres. La tinta puede usarse para resaltar otros objetos, mostrar conexiones y procesos, y llamar la atención sobre elementos específicos en una diapositiva.

El [Aspose.Slides.Ink](https://reference.aspose.com/slides/es/net/aspose.slides.ink/) namespace contiene las clases e interfaces necesarias para trabajar con objetos de tinta. Por ejemplo, la interfaz [IInk](https://reference.aspose.com/slides/es/net/aspose.slides.ink/iink/) representa un objeto de tinta en una diapositiva.

## **Diferencias entre objetos normales y objetos de tinta**

Los objetos en una diapositiva de PowerPoint suelen representarse mediante objetos de forma. En su forma más simple, una forma es un contenedor que define el área del propio objeto (su marco) junto con propiedades como el tamaño del contenedor, la forma y el fondo. Para obtener más información, consulte [Formato de diseño de forma](https://docs.aspose.com/slides/es/net/shape-manipulations/#access-layout-formats-for-shape).

Sin embargo, cuando PowerPoint maneja un objeto de tinta, ignora todas las propiedades del marco del objeto (contenedor) excepto su tamaño. El tamaño del área del contenedor se determina mediante las propiedades estándar [IShape.Width](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/width/) y [IShape.Height](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/height/):

![ink_powerpoint1](ink_powerpoint1.png)

## **Trazos de tinta**

Un trazo de tinta es un elemento básico utilizado para registrar la trayectoria de un lápiz mientras el usuario escribe tinta digital. Un trazo almacena una secuencia de puntos conectados.

La forma más simple de codificación especifica las coordenadas X e Y de cada punto de muestra. Cuando se renderizan todos los puntos conectados, producen una imagen como esta:

![ink_powerpoint2](ink_powerpoint2.png)

## **Propiedades del pincel para dibujar**

Un pincel se utiliza para dibujar líneas que conectan los puntos de un trazo de tinta. El pincel tiene su propio color y tamaño, representados por las propiedades [IInkBrush.Color](https://reference.aspose.com/slides/es/net/aspose.slides.ink/iinkbrush/color/) y [IInkBrush.Size](https://reference.aspose.com/slides/es/net/aspose.slides.ink/iinkbrush/size/).

### **Establecer color del pincel de tinta**

Este código C# muestra cómo establecer el color de un pincel de tinta:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Color = Color.Red;
```

### **Establecer tamaño del pincel de tinta**

Este código C# muestra cómo establecer el tamaño de un pincel de tinta:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Size = new SizeF(5f, 10f);
```

En general, el ancho y la altura de un pincel no coinciden, por lo que PowerPoint no muestra el tamaño del pincel (la sección de datos correspondiente está atenuada). Cuando el ancho y la altura del pincel coinciden, PowerPoint muestra su tamaño de esta manera:

![ink_powerpoint3](ink_powerpoint3.png)

Para mayor claridad, aumentemos la altura del objeto de tinta y revisemos las dimensiones importantes:

![ink_powerpoint4](ink_powerpoint4.png)

El contenedor (marco) no tiene en cuenta el tamaño de los pinceles; siempre asume que el grosor de la línea es cero (ver la imagen anterior).

Por lo tanto, para determinar el área visible de todo el objeto de tinta, debe tenerse en cuenta el tamaño del pincel de sus trazos. Aquí, el objeto objetivo (el trazo de texto manuscrito) se ha escalado al tamaño del contenedor (marco). Cuando el tamaño del contenedor cambia, el tamaño del pincel permanece constante, y viceversa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint utiliza un comportamiento similar para los objetos de texto:

![ink_powerpoint6](ink_powerpoint6.png)

## **Controlar la apariencia de la tinta durante la exportación y el renderizado**

Aspose.Slides proporciona la interfaz [IInkOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/iinkoptions/) para controlar cómo aparecen los objetos de tinta en la salida exportada o renderizada. Puede usar sus propiedades para ocultar la tinta por completo o cambiar la forma en que se interpretan las operaciones de máscara del pincel de tinta.

Las opciones de tinta están disponibles a través de las opciones de exportación o renderizado para varios tipos de salida:

| Salida | Propiedad de opciones de tinta |
| --- | --- |
| PDF | [`PdfOptions.InkOptions`](https://reference.aspose.com/slides/es/net/aspose.slides.export/pdfoptions/inkoptions/) |
| HTML | [`HtmlOptions.InkOptions`](https://reference.aspose.com/slides/es/net/aspose.slides.export/htmloptions/inkoptions/) |
| SVG | [`SVGOptions.InkOptions`](https://reference.aspose.com/slides/es/net/aspose.slides.export/svgoptions/inkoptions/) |
| TIFF | [`TiffOptions.InkOptions`](https://reference.aspose.com/slides/es/net/aspose.slides.export/tiffoptions/inkoptions/) |
| Imagen de diapositiva | [`RenderingOptions.InkOptions`](https://reference.aspose.com/slides/es/net/aspose.slides.export/renderingoptions/inkoptions/) |

Los mismos dos ajustes están disponibles a través de estas propiedades:

- [`HideInk`](https://reference.aspose.com/slides/es/net/aspose.slides.export/iinkoptions/hideink/) determina si los objetos de tinta se incluyen en la salida. Su valor predeterminado es `false`.
- [`InterpretMaskOpAsOpacity`](https://reference.aspose.com/slides/es/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) determina si una operación de máscara se interpreta como opacidad al renderizar un pincel de tinta. Su valor predeterminado es `true`; establézcalo en `false` para usar la operación ROP en su lugar.

### **Ocultar objetos de tinta en la salida PDF**

Por defecto, los objetos de tinta permanecen visibles durante la exportación. Establezca [IInkOptions.HideInk](https://reference.aspose.com/slides/es/net/aspose.slides.export/iinkoptions/hideink/) a `true` cuando necesite una salida limpia sin anotaciones manuscritas u otro contenido de tinta.

El siguiente ejemplo en C# exporta una presentación a PDF mientras oculta todos los objetos de tinta:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var pdfOptions = new PdfOptions();
pdfOptions.InkOptions.HideInk = true;

presentation.Save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Ocultar objetos de tinta al renderizar una diapositiva como imagen**

Para ocultar los objetos de tinta al renderizar diapositivas como imágenes bitmap, configure [RenderingOptions.InkOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/renderingoptions/inkoptions/) y pase las opciones de renderizado al método [ISlide.GetImage](https://reference.aspose.com/slides/es/net/aspose.slides/islide/getimage/).

El siguiente ejemplo en C# renderiza la primera diapositiva como una imagen PNG sin objetos de tinta:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var renderingOptions = new RenderingOptions();
renderingOptions.InkOptions.HideInk = true;

using var image = presentation.Slides[0].GetImage(renderingOptions);
image.Save("slide_without_ink.png", ImageFormat.Png);
```

### **Controlar el renderizado de la máscara de tinta**

La propiedad [IInkOptions.InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/es/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) controla cómo se interpretan las operaciones de máscara al renderizar pinceles de tinta. El valor predeterminado es `true`, lo que emplea opacidad. Establezca la propiedad en `false` para usar la operación ROP en su lugar.

El siguiente ejemplo en C# exporta una diapositiva a SVG y utiliza renderizado basado en ROP para las operaciones de máscara de tinta:

```c#
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var svgOptions = new SVGOptions();
svgOptions.InkOptions.InterpretMaskOpAsOpacity = false;

using var stream = File.Create("slide.svg");
presentation.Slides[0].WriteAsSvg(stream, svgOptions);
```

El mismo ajuste puede aplicarse a través de [TiffOptions.InkOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/tiffoptions/inkoptions/) al exportar una presentación o renderizar una diapositiva a TIFF.

### **Elegir si ocultar o conservar la tinta**

Use [IInkOptions.HideInk](https://reference.aspose.com/slides/es/net/aspose.slides.export/iinkoptions/hideink/) establecido en `true` cuando el archivo exportado deba ser una versión limpia de una presentación anotada, por ejemplo, una copia final destinada a distribución sin marcas de revisión.

Deje [IInkOptions.HideInk](https://reference.aspose.com/slides/es/net/aspose.slides.export/iinkoptions/hideink/) en su valor predeterminado `false` cuando las anotaciones de tinta forman parte del contenido previsto, como comentarios de revisión, notas manuscritas, resaltados o dibujos que deben permanecer visibles en el resultado exportado. Esto permite a las aplicaciones generar salidas de revisión y finales separadas a partir de la misma presentación sin modificar los objetos de tinta originales.

## **Preguntas frecuentes**

**¿Puedo cambiar el color o el tamaño de un trazo de tinta existente?**

Sí. Obtenga el trazo de [IInk.Traces](https://reference.aspose.com/slides/es/net/aspose.slides.ink/iink/traces/), luego cambie su [IInkTrace.Brush](https://reference.aspose.com/slides/es/net/aspose.slides.ink/iinktrace/brush/). Puede establecer las propiedades [IInkBrush.Color](https://reference.aspose.com/slides/es/net/aspose.slides.ink/iinkbrush/color/) y [IInkBrush.Size](https://reference.aspose.com/slides/es/net/aspose.slides.ink/iinkbrush/size/).

**¿Ocultar la tinta cambia la presentación original?**

No. [IInkOptions.HideInk](https://reference.aspose.com/slides/es/net/aspose.slides.export/iinkoptions/hideink/) afecta solo al resultado renderizado o exportado; no elimina ni modifica los objetos de tinta en la presentación original.

**¿Qué formatos de exportación admiten opciones de tinta?**

Puede configurar opciones de tinta para PDF, HTML, SVG, TIFF y imágenes bitmap de diapositivas mediante las opciones de exportación o renderizado correspondientes mostradas arriba.

**Lecturas adicionales**

* Para leer sobre formas en general, consulte la sección [PowerPoint Shapes](https://docs.aspose.com/slides/es/net/powerpoint-shapes/).
* Para más información sobre valores efectivos, vea [Shape Effective Properties](https://docs.aspose.com/slides/es/net/shape-effective-properties/#get-effective-font-height-value).
* Para obtener detalles sobre la exportación a PDF, vea [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/es/net/convert-powerpoint-to-pdf/).
* Para obtener detalles sobre la exportación a HTML, vea [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/es/net/convert-powerpoint-to-html/).
* Para obtener detalles sobre la exportación a SVG, vea [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/es/net/render-a-slide-as-an-svg-image/).
* Para obtener detalles sobre la exportación a TIFF, vea [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/es/net/convert-powerpoint-to-tiff/).
* Para obtener detalles sobre el renderizado de diapositiva a imagen, vea [Convert Presentation Slides to Images](https://docs.aspose.com/slides/es/net/convert-slide/).