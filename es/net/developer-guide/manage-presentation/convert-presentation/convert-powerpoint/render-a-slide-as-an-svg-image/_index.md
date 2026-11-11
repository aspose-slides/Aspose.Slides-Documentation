---
title: Renderizar diapositivas de presentación como imágenes SVG en .NET
linktitle: Diapositiva a SVG
type: docs
weight: 50
url: /es/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint a SVG
- presentación a SVG
- diapositiva a SVG
- PPT a SVG
- PPTX a SVG
- opciones de exportación SVG
- SVG interactivo
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Exportar diapositivas de PowerPoint como imágenes SVG en .NET y controlar fuentes, texto, imágenes, identificadores y eventos con Aspose.Slides."
---
## **Visión general**

SVG es un formato de imagen escalable basado en XML que funciona bien para la publicación web, visores de diapositivas, flujos de trabajo de accesibilidad y post‑procesado automatizado. Aspose.Slides exporta cada diapositiva a un archivo SVG independiente y le permite controlar cómo se escriben el texto, las fuentes, las imágenes y los elementos SVG.

Utilice [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) cuando el SVG exportado deba ser compacto, predecible en todos los navegadores o estar listo para uso interactivo.

## **Exportar una diapositiva como SVG**

Cree una [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), seleccione una diapositiva y escríbala en un flujo. El siguiente ejemplo exporta cada diapositiva de una presentación a un archivo SVG independiente.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

El nombre de archivo utiliza [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) en lugar del índice del bucle. También puede exportar una forma individual con [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/) cuando un visor de diapositivas o una página web necesita únicamente esa forma.

## **Configurar la salida SVG**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) controla la renderización de SVG. Para marcos de texto, [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) incluye el marco de texto en el área de renderizado, y [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) determina si se aplica la rotación del marco. Establezca [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) a `true` cuando el texto deba renderizarse sin ligaduras.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    DisableFontLigatures = true,
    UseFrameSize = true,
    UseFrameRotation = false
};

using var svgStream = File.Create("slide-with-custom-options.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **Controlar el recorte al final de la línea en las puntas de flecha**

SVG 1.1 no tiene una configuración de inserción de marcador para especificar dónde debe detenerse una línea debajo de una punta de flecha. De forma predeterminada, Aspose.Slides acorta la línea exportada para que su trazo no sobresalga del marcador. Establezca [SVGOptions.DisableLineEndCropping](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablelineendcropping/) a `true` para dibujar el trazo hasta el punto final original de la línea. Esta opción afecta únicamente a la salida SVG. La línea mantiene su posición y longitud en la diapositiva.

El ejemplo dibuja puntas de flecha de triángulo y diamante en líneas de 2 y 10 puntos de ancho. Exporta la misma diapositiva dos veces, cambiando solo la opción de recorte.

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var y = 40;

foreach (var style in new[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond })
{
    foreach (var width in new[] { 2, 10 })
    {
        var line = slide.Shapes.AddAutoShape(ShapeType.Line, 40, y, 200, 0);
        var format = line.LineFormat;
        format.FillFormat.FillType = FillType.Solid;
        format.FillFormat.SolidFillColor.Color = Color.DarkBlue;
        format.Width = width;
        format.EndArrowheadStyle = style;
        y += 50;
    }
}

var options = new SVGOptions { DisableLineEndCropping = false };
using var cropped = File.Create("cropped.svg");
slide.WriteAsSvg(cropped, options);

options.DisableLineEndCropping = true;
using var uncropped = File.Create("uncropped.svg");
slide.WriteAsSvg(uncropped, options);
```

La comparación muestra la punta de flecha triangular en la línea de 10 puntos. Con el recorte habilitado, la punta es afilada. Con el recorte deshabilitado, el trazo sobresale por los lados inclinados del marcador y deja un extremo plano.

![Triángulo de 10 puntos ampliado con una punta afilada cuando el recorte está habilitado y un extremo plano cuando el recorte está deshabilitado](line-end-cropping.png)

En las otras líneas del ejemplo, el trazo sobresaliente es menos visible en el triángulo de 2 puntos. El diamante relleno cubre el extremo del trazo en ambos anchos.

## **Controlar texto y fuentes**

Al exportar diapositivas a SVG, puede controlar si el texto permanece como texto o se convierte en gráficos vectoriales, y cómo se incluyen o referencian las fuentes externas. Las siguientes opciones le ayudan a equilibrar la consistencia visual, la selección de texto y las dependencias de fuentes en el SVG exportado.

### **Vectorizar todo el texto**

Establezca [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) a `true` para escribir todo el texto de la diapositiva como gráficos vectoriales. Esto elimina las dependencias de fuentes y hace que el resultado visual sea más consistente entre navegadores, pero el texto ya no será seleccionable ni buscable como texto SVG.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    VectorizeText = true
};

using var svgStream = File.Create("slide-with-vectorized-text.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

### **Elegir cómo se gestionan las fuentes externas**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) utiliza un valor de [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) para las fuentes que se cargan externamente. Elija `AddLinksToFontFiles` para referenciar archivos de fuentes separados, `Embed` para incluir los datos de la fuente en el SVG, o `Vectorize` para renderizar solo el texto que utiliza fuentes externas como gráficos. Verifique la licencia de las fuentes antes de incrustarlas.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var linkedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.AddLinksToFontFiles
};

using var linkedFontsStream = File.Create("slide-with-font-links.svg");
presentation.Slides[0].WriteAsSvg(linkedFontsStream, linkedFontsOptions);

var embeddedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Embed
};

using var embeddedFontsStream = File.Create("slide-with-embedded-fonts.svg");
presentation.Slides[0].WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);

var vectorizedExternalFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Vectorize
};

using var vectorizedExternalFontsStream = File.Create("slide-with-vectorized-external-fonts.svg");
presentation.Slides[0].WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
```

## **Reducir el tamaño de las imágenes incrustadas**

Utilice [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) para reducir la resolución de las imágenes incrustadas, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) para omitir las áreas recortadas de la fuente, y [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) para controlar la calidad de codificación JPEG. Estas opciones reducen el tamaño del archivo a costa de la fidelidad de la imagen o de los datos de la imagen retenidos.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    PicturesCompression = PicturesCompression.Dpi150,
    DeletePicturesCroppedAreas = true,
    JpegQuality = 80
};

using var svgStream = File.Create("compressed-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **Controlar la resolución de rasterización de metarchivos**

[SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) establece el límite de resolución inferior para rasterizar metarchivos durante la exportación a SVG. Úselo para equilibrar el detalle y el tamaño del archivo cuando se rasteriza una imagen EMF o WMF. No define un DPI global para el SVG ni obliga a que cada objeto en la diapositiva se convierta en una imagen raster.

Descargue [metafile-rasterization.pptx](metafile-rasterization.pptx), que contiene una imagen EMF con líneas diagonales muy próximas. El siguiente ejemplo exporta su primera diapositiva a tres resoluciones de rasterización mediante [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/). Todas las demás configuraciones de exportación permanecen idénticas para que los resultados puedan compararse.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("metafile-rasterization.pptx");

foreach (var dpi in new[] { 72, 150, 300 })
{
    var svgOptions = new SVGOptions
    {
        MetafileRasterizationDpi = dpi,
        PicturesCompression = PicturesCompression.Dpi330,
        JpegQuality = 90
    };

    using var svgStream = File.Create($"slide-{dpi}.svg");
    presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
}
```

En la salida, el EMF se convirtió en un PNG incrustado en cada SVG. Las siguientes mediciones corresponden a la presentación suministrada; no son una fórmula general para convertir DPI a dimensiones en píxeles.

| DPI de rasterización del metarchivo | Dimensiones del PNG incrustado | Tamaño del archivo SVG (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

La comparación a continuación muestra la misma zona del raster incrustado al mismo tamaño de visualización ampliado. Las líneas diagonales presentan pixelación visible a 72 DPI y bordes más suaves a resoluciones mayores, mientras que el archivo SVG aumenta de tamaño. Incrementar el valor no mejora necesariamente cada detalle ni cambia cada imagen exportada.

![Detalle ampliado de líneas diagonales a 72, 150 y 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) controla la reducción de la resolución de la imagen y puede enmascarar el efecto de cambiar la resolución de rasterización del metarchivo. [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) controla la calidad de codificación JPEG, no la resolución de rasterización del metarchivo.

## **Asignar identificadores estables a formas y texto**

Utilice [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) para establecer [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/) de cada forma SVG. Para establecer también valores de [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/) en los elementos `tspan` de texto, implemente [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). Asigne cualquiera de los controladores mediante [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/).

El siguiente controlador utiliza [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/), que es estable durante la vida útil de la forma, y un contador repetible para sus rangos de texto. Esto hace que los ID generados sean adecuados para el post‑procesado de una presentación sin cambios.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new StableSvgIdController()
};

using var svgStream = File.Create("slide-with-stable-ids.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class StableSvgIdController : ISvgShapeAndTextFormattingController
{
    private string currentShapeId = string.Empty;
    private int textSpanIndex;

    public ISvgShapeFormattingController AsISvgShapeFormattingController => this;

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        currentShapeId = $"shape-{shape.OfficeInteropShapeId}";
        textSpanIndex = 0;
        svgShape.Id = currentShapeId;
    }

    public void FormatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame)
    {
        svgTSpan.Id = $"{currentShapeId}-text-{textSpanIndex++}";
    }
}
```

## **Agregar controladores de eventos SVG**

En un [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/), llame a [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) con un valor [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/) para añadir un controlador de eventos JavaScript a una forma exportada. Asigne el controlador mediante [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) y defina la función JavaScript en la página o documento SVG que aloje el resultado.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new SvgEventController()
};

using var svgStream = File.Create("interactive-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class SvgEventController : ISvgShapeFormattingController
{
    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        if (shape.Name == "ActionButton")
        {
            svgShape.Id = "action-button";
            svgShape.SetEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}
```

La página anfitriona puede definir la función JavaScript referenciada por el controlador. Asignar identificadores y controladores de eventos permite visores de diapositivas, mejoras de accesibilidad y otros flujos de trabajo SVG interactivos.

## **FAQ**

**¿Cuándo debo usar [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) en lugar de [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)?**

Utilice [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) cuando todo el texto deba ser independiente de las fuentes. Utilice [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) cuando solo el texto que utiliza fuentes externas deba convertirse en gráficos.

**¿Cuál es la mejor forma de reducir el tamaño de un SVG?**

Comience por comprimir las imágenes incrustadas, eliminar las áreas recortadas de las imágenes y elegir archivos de fuentes vinculados cuando el entorno de destino pueda servirlos. Pruebe el resultado porque la reducción de la resolución de la imagen, la disminución de la calidad JPEG y el texto vectorizado tienen cada uno diferentes compromisos entre calidad y tamaño.

**¿Puedo modificar los elementos SVG exportados después de la exportación?**

Sí. Asigne identificadores mediante un controlador de formato y luego seleccione los elementos SVG coincidentes en su herramienta de post‑procesado o en un script de navegador.