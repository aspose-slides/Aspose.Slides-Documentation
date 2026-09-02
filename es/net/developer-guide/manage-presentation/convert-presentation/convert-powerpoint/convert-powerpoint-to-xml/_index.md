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
- Presentación XML de PowerPoint
- SaveFormat.Xml
- guardar presentación como XML
- exportar presentación a XML
- flujo XML
- .NET
- C#
- Aspose.Slides
description: "Convertir presentaciones de PowerPoint y OpenDocument a archivos o flujos XML de PowerPoint en C# con Aspose.Slides para .NET."
---
## **Descripción general**

Aspose.Slides for .NET puede convertir presentaciones de PowerPoint al formato Presentación XML de PowerPoint. La salida XML es útil cuando necesita una representación basada en texto para inspeccionar la estructura de la presentación, solucionar problemas de documentos generados, comparar la salida en pruebas automatizadas o integrarse con un flujo de trabajo que consume XML en lugar de un paquete de presentación.

Utilice el método [Presentation.Save](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/save/) con el valor `Xml` del enumerado [SaveFormat](https://reference.aspose.com/slides/es/net/aspose.slides.export/saveformat/). Puede escribir el resultado directamente en un archivo o en un flujo.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` crea una Presentación XML de PowerPoint. No extrae las partes individuales de Office Open XML almacenadas dentro de un paquete PPTX. Si necesita las partes exactas del paquete PPTX, como `ppt/presentation.xml` o los archivos XML de diapositivas individuales, examine el propio paquete PPTX.
{{% /alert %}}

## **Convertir una presentación a un archivo XML**

Cargue una presentación de origen con la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) y, a continuación, pase la ruta de salida y `SaveFormat.Xml` a [Presentation.Save](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/save/). El origen puede ser cualquier formato de presentación compatible para carga, como PPT, PPTX u ODP.

El siguiente ejemplo convierte una presentación PPTX a un archivo XML:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **Escribir la salida XML a un flujo**

Utilice la sobrecarga de flujo de [Presentation.Save](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/save/) cuando el XML deba permanecer en memoria o pasar a otro componente, como un servicio web, proveedor de almacenamiento o canal de procesamiento XML. El siguiente ejemplo escribe el resultado en un [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) y lo rebobina para su lectura posterior:

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
| PowerPoint XML (`.xml`) | Una Presentación XML de PowerPoint | Inspección de la estructura, solución de problemas, comparación de la salida generada e integración basada en XML |
| PPT (`.ppt`) | Un archivo de presentación binario heredado | Compatibilidad con flujos de trabajo de PowerPoint más antiguos |
| PPTX (`.pptx`) | Un paquete Office Open XML que contiene múltiples partes | Edición regular de PowerPoint e intercambio de presentaciones |
| PDF o TIFF | Páginas de diseño fijo o una imagen multipágina | Visualización, impresión y archivo |
| PNG, JPEG o SVG | Una representación renderizada de una diapositiva individual | Miniaturas, vistas previas y recursos de imagen |
| HTML o HTML5 | Salida de presentación orientada a la web | Visualización en navegador y publicación web |

A diferencia de PPT y PPTX, la salida XML está principalmente destinada a la inspección y a flujos de trabajo orientados a datos. A diferencia de PDF, TIFF, HTML y los formatos de imagen de diapositivas, representa datos de la presentación en lugar de renderizar diapositivas como páginas o recursos visuales. La tabla de [formatos de archivo compatibles](/slides/es/net/supported-file-formats/) indica que Presentación XML de PowerPoint es un formato solo de guardado, por lo que no debe usarse cuando un flujo de trabajo necesita cargar el archivo exportado de nuevo en Aspose.Slides para continuar editándolo.

## **Preguntas frecuentes**

**¿Es `SaveFormat.Xml` lo mismo que guardar un archivo PPTX?**  
No. PPTX es un paquete que contiene múltiples partes de Office Open XML, mientras que `SaveFormat.Xml` crea un archivo Presentación XML de PowerPoint.

**¿Puedo guardar la salida XML sin crear un archivo en disco?**  
Sí. Pase un flujo con acceso de escritura a [Presentation.Save](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/save/). Por ejemplo, use un [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) para el procesamiento en memoria.

**¿Puede Aspose.Slides cargar de nuevo el archivo XML exportado?**  
No. Presentación XML de PowerPoint es actualmente compatible solo para guardar, no para cargar. Use PPTX u otro formato de presentación compatible cuando sea necesario un ciclo de edición completo.

**¿La conversión a XML renderiza cada diapositiva como una página o imagen?**  
No. La conversión a XML escribe datos estructurados de la presentación. Use PDF o TIFF para una salida orientada a páginas, o PNG, JPEG y SVG para imágenes de diapositivas individuales.