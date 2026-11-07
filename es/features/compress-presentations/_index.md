---
title: Comprimir presentaciones
description: Reducir el tamaño de la presentación comprimiendo imágenes y eliminando contenido no usado.
type: docs
url: /es/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **Visión general**

Comprima imágenes, elimine áreas recortadas de las imágenes cuando ya no sean necesarias y elija la configuración de compresión de la presentación antes de guardar. Esto es útil para presentaciones con fotografías grandes o medios repetidos. La cantidad ahorrada depende del contenido y de la configuración que elija.

## **Ejemplo de uso**

Este ejemplo en C# carga `input.pptx`, comprime la presentación y la guarda como `compressed.pptx`.

Utilice Aspose.Slides for .NET 26.11 o posterior. Para la configuración, consulte [Instalar Aspose.Slides for .NET](/slides/es/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

## **Preguntas frecuentes**

### **¿Es este un conmutador único de optimización de archivo completo?**

Aspose.Slides for .NET 26.11 añade [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/), que combina la eliminación de disposiciones/maestros no usados, la subconfiguración de fuentes incrustadas y la compresión de imágenes a 150 DPI. Elimina permanentemente las áreas recortadas de las imágenes. Para el procesamiento solo de imágenes, use [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/); para un control más fino, consulte el [ejemplo de compresión de imagen individual](/slides/es/net/examples/optimization-batch/compression/). Estos nuevos asistentes son específicos de la versión .NET indicada; consulte la guía correspondiente para otros SDK.

### **¿La compresión de imágenes cambia el texto editable o los gráficos?**

La compresión de imágenes se dirige a los datos de las imágenes, no al texto editable ni a los datos de los gráficos. Revise las imágenes porque el redimensionado o la recompresión pueden reducir su detalle.

### **¿Cómo debo elegir una resolución para las imágenes de la presentación?**

Elija un objetivo en función del tamaño de la imagen mostrada y del uso previsto en pantalla o impresión. Mantenga mayor resolución para pantallas grandes, impresión y diagramas detallados, y compare el resultado renderizado antes de descartar el original.

## **Guías**

- [Comprimir toda la presentación en .NET](/slides/es/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [Optimizar la gestión de imágenes en presentaciones en .NET](/slides/es/net/image/)

Funcionalidad relacionada: [Eliminar maestros, disposiciones y medios no usados](/slides/es/features/remove-unused-content/).

## Ejemplos ejecutables .NET

- [Reducir el tamaño de la presentación](/slides/es/net/examples/optimization-batch/compression/)