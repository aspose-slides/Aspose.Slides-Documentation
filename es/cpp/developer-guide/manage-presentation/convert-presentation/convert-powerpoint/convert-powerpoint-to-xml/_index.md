---
title: Convertir presentaciones de PowerPoint a XML en C++
linktitle: PowerPoint a XML
type: docs
weight: 145
url: /es/cpp/convert-powerpoint-to-xml/
keywords:
- convertir PowerPoint a XML
- convertir presentación a XML
- PPT a XML
- PPTX a XML
- ODP a XML
- Presentación XML de PowerPoint
- SaveFormat::Xml
- guardar presentación como XML
- exportar presentación a XML
- flujo XML
- C++
- Aspose.Slides
description: "Convertir presentaciones de PowerPoint y OpenDocument a archivos o flujos XML de PowerPoint en C++ con Aspose.Slides para C++."
---
## **Visión general**

Aspose.Slides for C++ puede convertir presentaciones de PowerPoint al formato PowerPoint XML Presentation. La salida XML es útil cuando se necesita una representación basada en texto para inspeccionar la estructura de la presentación, solucionar problemas de documentos generados, comparar resultados en pruebas automatizadas o integrarse con un flujo de trabajo que consume XML en lugar de un paquete de presentación.

Use el método [Presentation::Save](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/save/) con el valor `Xml` del enumerado [SaveFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/saveformat/). Puede escribir el resultado directamente a un archivo o a un flujo.

{{% alert color="info" title="Nota" %}}
`SaveFormat::Xml` crea una PowerPoint XML Presentation. No extrae las partes individuales de Office Open XML almacenadas dentro de un paquete PPTX. Si necesita las partes exactas del paquete PPTX, como `ppt/presentation.xml` o archivos XML de diapositivas individuales, inspeccione el propio paquete PPTX.
{{% /alert %}}

## **Convertir una presentación a un archivo XML**

Cargue una presentación fuente con la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) y luego pase la ruta de salida y `SaveFormat::Xml` a [Presentation::Save](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/save/). La fuente puede ser cualquier formato de presentación compatible para carga, como PPT, PPTX u ODP.

El siguiente ejemplo convierte una presentación PPTX a un archivo XML:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.xml", SaveFormat::Xml);
presentation->Dispose();
```

## **Escribir la salida XML a un flujo**

Utilice la sobrecarga de flujo de [Presentation::Save](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/save/) cuando el XML deba permanecer en memoria o pasarse a otro componente, como un servicio web, un proveedor de almacenamiento o una canalización de procesamiento XML. El siguiente ejemplo escribe el resultado a un [MemoryStream](https://reference.aspose.com/slides/es/cpp/system.io/memorystream/) y retrocede el puntero para lecturas posteriores:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto xmlStream = System::MakeObject<MemoryStream>();

presentation->Save(xmlStream, SaveFormat::Xml);
xmlStream->set_Position(0);
presentation->Dispose();

// Pase xmlStream al siguiente componente en el flujo de trabajo.
```

## **Comparar XML con los formatos de presentación y exportación**

Elija el formato de salida según cómo se vaya a utilizar el resultado:

| Formato | Salida | Uso típico |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Una PowerPoint XML Presentation | Inspección de la estructura, resolución de problemas, comparación de la salida generada e integración basada en XML |
| PPT (`.ppt`) | Un archivo de presentación binario heredado | Compatibilidad con flujos de trabajo de PowerPoint antiguos |
| PPTX (`.pptx`) | Un paquete Office Open XML que contiene múltiples partes | Edición habitual de PowerPoint e intercambio de presentaciones |
| PDF o TIFF | Páginas de diseño fijo o una imagen multipágina | Visualización, impresión y archivado |
| PNG, JPEG o SVG | Una representación renderizada de una diapositiva individual | Miniaturas, vistas previas y recursos de imagen |
| HTML o HTML5 | Salida de presentación orientada a la web | Visualización en navegadores y publicación web |

A diferencia de PPT y PPTX, la salida XML está pensada principalmente para inspección y flujos de trabajo centrados en datos. A diferencia de PDF, TIFF, HTML y los formatos de imagen de diapositivas, representa datos de la presentación en lugar de renderizar diapositivas como páginas o recursos visuales. La tabla de [formatos de archivo admitidos](/slides/es/cpp/supported-file-formats/) enumera PowerPoint XML Presentation como un formato solo de guardado, por lo que no debe usarse cuando un flujo de trabajo necesite cargar el archivo exportado nuevamente en Aspose.Slides para continuar editándolo.

## **Preguntas frecuentes**

**¿Es `SaveFormat::Xml` lo mismo que guardar un archivo PPTX?**

No. PPTX es un paquete que contiene múltiples partes de Office Open XML, mientras que `SaveFormat::Xml` crea un archivo PowerPoint XML Presentation.

**¿Puedo guardar la salida XML sin crear un archivo en disco?**

Sí. Pase un flujo con capacidad de escritura a [Presentation::Save](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/save/). Por ejemplo, use un [MemoryStream](https://reference.aspose.com/slides/es/cpp/system.io/memorystream/) para el procesamiento en memoria.

**¿Puede Aspose.Slides cargar de nuevo el archivo XML exportado?**

No. PowerPoint XML Presentation está soportado actualmente solo para guardado, no para carga. Utilice PPTX u otro formato de presentación admitido cuando sea necesario un ciclo de edición completo.

**¿La conversión a XML renderiza cada diapositiva como una página o imagen?**

No. La conversión a XML escribe datos estructurados de la presentación. Use PDF o TIFF para salida orientada a páginas, o PNG, JPEG y SVG para imágenes de diapositivas individuales.