---
title: Comprimir presentaciones
description: Reducir el tamaño de la presentación con compresión de imágenes y guardar la configuración.
type: docs
url: /es/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/image/
---
## **Resumen**

Comprime imágenes, elimina áreas recortadas que ya no son necesarias y elige la configuración de compresión de la presentación antes de guardar. Esto es útil para presentaciones con fotografías grandes o medios repetidos. La cantidad ahorrada depende del contenido y de la configuración que elijas.

## **Ejemplo de uso**

Este ejemplo en C# utiliza Aspose.Slides para .NET. Genera visiblemente un PNG de degradado de 1600 × 900 píxeles, lo inserta en un pequeño marco de imagen y guarda *before.pptx*. Luego comprime esa imagen a una resolución objetivo de 96 DPI y guarda *compressed.pptx*. Compara ambos tamaños de archivo y vistas previas: el ahorro depende de la imagen de origen y del tamaño mostrado.

Para la configuración, consulta [Instalar Aspose.Slides para .NET](/slides/es/net/installation/).

```csharp
using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var bitmap = new Bitmap(1600, 900))
{
    for (var y = 0; y < bitmap.Height; y++)
        for (var x = 0; x < bitmap.Width; x++)
            bitmap.SetPixel(x, y, Color.FromArgb(x % 256, y % 256, (x + y) % 256));
    bitmap.Save("large.png", System.Drawing.Imaging.ImageFormat.Png);
}
using var presentation = new Presentation();
var title = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 500, 60);
title.TextFrame.Text = "Photo";
var bytes = File.ReadAllBytes("large.png");
var image = presentation.Images.AddImage(bytes);
var picture = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 40, 120, 240, 135, image);
presentation.Save("before.pptx", SaveFormat.Pptx);
var compressed = picture.PictureFormat.CompressImage(true, 96f);
Console.WriteLine($"Picture compressed: {compressed}");
presentation.Save("compressed.pptx", SaveFormat.Pptx);
using var preview = presentation.Slides[0].GetImage(1f, 1f);
preview.Save("compressed.png", ImageFormat.Png);
```

## **Preguntas frecuentes**

### **¿Es este un interruptor de optimización de todo el archivo?**

Aspose.Slides para .NET 26.11 añade [Compress.CompressPresentation](/slides/es/net/low-code-presentation-operations/#compress-the-whole-presentation), que combina la eliminación de diseños/maestras no utilizados, el sub-conjunto de fuentes incrustadas y la compresión de imágenes a 150 DPI. Elimina permanentemente las áreas recortadas de las imágenes. Para procesar solo imágenes, usa Compress.CompressImages; para un control más fino, mantén el flujo de trabajo por imagen descrito arriba. Estos nuevos ayudantes son específicos para la versión .NET indicada; consulta la guía correspondiente para otros SDK.

### **¿La compresión de imágenes altera el texto o los gráficos editables?**

La compresión de imágenes afecta los datos de la imagen, no el texto editable ni los datos de los gráficos. Revisa las imágenes porque el cambio de tamaño o la recompresión pueden reducir su nivel de detalle.

### **¿Cómo debo elegir una resolución para las imágenes de la presentación?**

Elige una resolución objetivo basada en el tamaño mostrado de la imagen y el uso previsto en pantalla o impresión. Conserva mayor resolución para pantallas grandes, impresiones y diagramas detallados, y compara el resultado renderizado antes de descartar el original.

## **Guías**

- [Optimizar la gestión de imágenes en presentaciones en .NET](/slides/es/net/image/)

Funcionalidad relacionada: [Eliminar maestros, diseños y medios sin usar](/slides/es/features/remove-unused-content/).

## Runnable .NET examples

- [Reducir el tamaño de la presentación](/slides/es/net/examples/optimization-batch/compression/)