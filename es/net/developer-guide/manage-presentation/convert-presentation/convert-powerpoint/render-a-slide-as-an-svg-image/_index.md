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

SVG es un formato de imagen basado en XML y escalable que funciona bien para la publicación web, los visualizadores de diapositivas, los flujos de trabajo de accesibilidad y el post‑procesado automatizado. Aspose.Slides exporta cada diapositiva a un archivo SVG separado y le permite controlar cómo se escriben el texto, las fuentes, las imágenes y los elementos SVG.

Utilice SVGOptions cuando el SVG exportado deba ser compacto, predecible en distintos navegadores o estar listo para su uso interactivo.

## **Exportar una diapositiva como SVG**

Cree una Presentation, seleccione una diapositiva y escríbala en un flujo. El siguiente ejemplo exporta cada diapositiva de una presentación como un archivo SVG separado.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

El nombre de archivo usa ISlide.SlideNumber en lugar del índice del bucle. También puede exportar una forma individual con IShape.WriteAsSvg cuando un visualizador de diapositivas o una página web necesita sólo esa forma.

## **Configurar la salida SVG**

SVGOptions controla la renderización de SVG. Para los marcos de texto, SVGOptions.UseFrameSize incluye el marco de texto en el área de renderizado, y SVGOptions.UseFrameRotation determina si se aplica la rotación del marco. Establezca SVGOptions.DisableFontLigatures a `true` cuando el texto deba renderizarse sin ligaduras.

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

## **Controlar texto y fuentes**

### **Vectorizar todo el texto**

Establezca SVGOptions.VectorizeText a `true` para escribir todo el texto de la diapositiva como gráficos vectoriales. Esto elimina las dependencias de fuentes y hace que el resultado visual sea más coherente en distintos navegadores, pero el texto ya no es seleccionable ni buscable como texto SVG.

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

SVGOptions.ExternalFontsHandling utiliza un valor SvgExternalFontsHandling para las fuentes que se cargan externamente. Elija AddLinksToFontFiles para referenciar archivos de fuentes separados, Embed para incluir los datos de la fuente en el SVG, o Vectorize para renderizar sólo el texto que usa fuentes externas como gráficos. Verifique la licencia de las fuentes antes de incrustarlas.

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

## **Reducir el tamaño de imágenes incrustadas**

Utilice SVGOptions.PicturesCompression para reducir la resolución de las imágenes incrustadas, SVGOptions.DeletePicturesCroppedAreas para omitir áreas recortadas de la fuente y SVGOptions.JpegQuality para controlar la calidad de codificación JPEG. Estas configuraciones reducen el tamaño del archivo a costa de la fidelidad de la imagen o de los datos retenidos.

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

## **Asignar ID estables a formas y texto**

Utilice ISvgShapeFormattingController para establecer ISvgShape.Id para cada forma SVG. Para establecer también valores ISvgTSpan.Id en los elementos de texto `tspan`, implemente ISvgShapeAndTextFormattingController. Asigne cualquiera de los controladores con SVGOptions.ShapeFormattingController.

El siguiente controlador utiliza IShape.OfficeInteropShapeId, que es estable durante la vida útil de la forma, y un contador repetible para sus segmentos de texto. Esto hace que los ID generados sean adecuados para el post‑procesado de una presentación sin cambios.

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

En un ISvgShapeFormattingController, llame a ISvgShape.SetEventHandler con un valor SvgEvent para agregar un controlador de eventos JavaScript a una forma exportada. Asigne el controlador con SVGOptions.ShapeFormattingController y defina la función JavaScript en la página o documento SVG que aloja el resultado.

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

La página anfitriona puede definir la función JavaScript referenciada por el controlador. La asignación de ID y controladores de eventos habilita visualizadores de diapositivas, mejoras de accesibilidad y otros flujos de trabajo interactivos con SVG.

## **Preguntas frecuentes**

**¿Cuándo debería usar SVGOptions.VectorizeText en lugar de SvgExternalFontsHandling.Vectorize?**

Utilice SVGOptions.VectorizeText cuando todo el texto deba ser independiente de las fuentes. Utilice SvgExternalFontsHandling.Vectorize cuando sólo el texto que usa fuentes externas deba convertirse en gráficos.

**¿Cuál es la mejor manera de reducir el tamaño de un SVG?**

Comience comprimiendo las imágenes incrustadas, eliminando las áreas recortadas y eligiendo archivos de fuentes enlazados cuando el entorno de destino pueda servirlos. Pruebe el resultado, ya que la menor resolución de la imagen, la menor calidad JPEG y el texto vectorizado tienen cada uno diferentes compromisos entre calidad y tamaño.

**¿Puedo modificar los elementos SVG exportados después de la exportación?**

Sí. Asigne ID mediante un controlador de formato y luego seleccione los elementos SVG correspondientes en su herramienta de post‑procesado o script del navegador.