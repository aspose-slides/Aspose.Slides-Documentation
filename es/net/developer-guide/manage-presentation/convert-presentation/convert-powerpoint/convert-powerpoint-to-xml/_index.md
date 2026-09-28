---
title: Convertir presentaciones de PowerPoint a XML en .NET
linktitle: PowerPoint a XML
type: docs
weight: 145
url: /es/net/convert-powerpoint-to-xml/
keywords:
- convertir PowerPoint a XML
- convertir presentación a XML
- PPT a XML
- PPTX a XML
- ODP a XML
- Presentación PowerPoint XML
- SaveFormat.Xml
- guardar presentación como XML
- exportar presentación a XML
- flujo XML
- .NET
- C#
- Aspose.Slides
description: "Convertir presentaciones de PowerPoint y OpenDocument a archivos o flujos XML de PowerPoint en C# con Aspose.Slides para .NET."
---
## **Resumen**

Aspose.Slides for .NET puede convertir presentaciones de PowerPoint al formato PowerPoint XML Presentation. La salida XML es útil cuando necesita una representación basada en texto para inspeccionar la estructura de la presentación, solucionar problemas de documentos generados, comparar la salida en pruebas automatizadas o integrarse con un flujo de trabajo que consume XML en lugar de un paquete de presentación.

Utilice el método [Presentation.Save](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/save/) con el valor `Xml` de la enumeración [SaveFormat](https://reference.aspose.com/slides/es/net/aspose.slides.export/saveformat/). Puede escribir el resultado directamente en un archivo o en un flujo.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` crea una presentación PowerPoint XML. No extrae las partes individuales de Office Open XML almacenadas dentro de un paquete PPTX. Si necesita las partes exactas del paquete PPTX, como `ppt/presentation.xml` o archivos XML de diapositivas individuales, inspeccione el propio paquete PPTX.
{{% /alert %}}

## **Convertir una presentación a un archivo XML**

Cargue una presentación origen con la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) y, a continuación, pase la ruta de salida y `SaveFormat.Xml` a [Presentation.Save](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/save/). El origen puede ser cualquier formato de presentación compatible para carga, como PPT, PPTX o ODP.

El siguiente ejemplo convierte una presentación PPTX a un archivo XML:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **Escribir la salida XML en un flujo**

Utilice la sobrecarga de flujo de [Presentation.Save](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/save/) cuando el XML debe permanecer en memoria o pasarse a otro componente, como un servicio web, un proveedor de almacenamiento o una canalización de procesamiento XML. El siguiente ejemplo escribe el resultado en un [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) y lo rebobina para su lectura posterior:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// Pasar xmlStream al siguiente componente del flujo de trabajo.
```

## **Comparar XML con formatos de presentación y exportación**

Elija el formato de salida según cómo se utilizará el resultado:

| Formato | Salida | Uso típico |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Una presentación PowerPoint XML | Inspección de la estructura, solución de problemas, comparación de la salida generada y integración basada en XML |
| PPT (`.ppt`) | Un archivo de presentación binario heredado | Compatibilidad con flujos de trabajo de PowerPoint antiguos |
| PPTX (`.pptx`) | Un paquete Office Open XML que contiene múltiples partes | Edición normal de PowerPoint e intercambio de presentaciones |
| PDF o TIFF | Páginas de diseño fijo o imágenes TIFF | Visualización, impresión y archivado |
| PNG, JPEG o SVG | Una representación renderizada de una diapositiva individual | Miniaturas, vistas previas y recursos de imagen |
| HTML o HTML5 | Salida de presentación orientada a la web | Visualización en navegador y publicación web |

A diferencia de PPT y PPTX, la salida XML está pensada principalmente para inspección y flujos de trabajo basados en datos. A diferencia de PDF, TIFF, HTML y formatos de imagen de diapositivas, representa datos de la presentación en lugar de renderizar diapositivas como páginas o recursos visuales. La tabla de [supported file formats](/slides/es/net/supported-file-formats/) enumera todos los formatos que Aspose.Slides puede cargar, importar, guardar o renderizar.

## **Preguntas frecuentes**

**¿`SaveFormat.Xml` es lo mismo que guardar un archivo PPTX?**

No. PPTX es un paquete que contiene múltiples partes de Office Open XML, mientras que `SaveFormat.Xml` crea un archivo PowerPoint XML Presentation.

**¿Puedo guardar la salida XML sin crear un archivo en disco?**

Sí. Pase un flujo de escritura a [Presentation.Save](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/save/). Por ejemplo, utilice un [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) para el procesamiento en memoria.

**¿Aspose.Slides puede cargar de nuevo el archivo XML exportado?**

Sí. Pase el archivo XML o un flujo al constructor [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/presentation/). [Presentation.SourceFormat](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/sourceformat/) devuelve entonces `SourceFormat.Xml`. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/es/net/aspose.slides/presentationfactory/getpresentationinfo/) informa `LoadFormat.Unknown` para este formato, por lo que no debe usarlo para decidir si se puede abrir un archivo XML.

**¿La conversión a XML representa cada diapositiva como una página o imagen?**

No. La conversión a XML escribe datos estructurados de la presentación. Utilice PDF o TIFF para salida orientada a páginas, o PNG, JPEG y SVG para imágenes de diapositivas individuales.