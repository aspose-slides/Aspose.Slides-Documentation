---
title: Convertir PPT a PPTX en C++
linktitle: PPT a PPTX
type: docs
weight: 20
url: /es/cpp/convert-ppt-to-pptx/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- PPT a PPTX
- guardar PPT como PPTX
- exportar PPT a PPTX
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Convertir archivos PPT heredados a PPTX en C++ con Aspose.Slides. Incluye ejemplos en C++ para conversión de un solo archivo y por lotes, manejo de errores y notas sobre fidelidad."
---
## **Visión general**

PPT es el formato binario heredado de PowerPoint, mientras que PPTX es el formato Open XML más reciente. Aspose.Slides for C++ puede cargar un archivo PPT y guardarlo como PPTX sin Microsoft PowerPoint. Este artículo muestra cómo convertir un archivo o un directorio de archivos y explica qué verificar después de la conversión.

## **Convertir un archivo PPT a PPTX**

Cargue el archivo fuente con la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/), luego llame a [Presentation::Save](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/save/) con [SaveFormat::Pptx](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/saveformat/). Libere la presentación cuando ya no sea necesaria para liberar sus recursos.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Cargar la presentación PPT heredada.
auto presentation = System::MakeObject<Presentation>(u"presentation.ppt");

// Guardar la presentación en formato PPTX.
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

La extensión del archivo no selecciona el formato de salida por sí sola; lo hace el argumento [SaveFormat::Pptx](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/saveformat/). Mantenga diferentes las rutas de entrada y salida si necesita conservar el archivo PPT original.

## **Convertir varios archivos PPT**

El siguiente ejemplo convierte cada archivo `.ppt` en un directorio. Cada archivo se procesa de forma independiente, por lo que una conversión fallida no detiene el resto del lote.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String inputDirectory = u"input";
String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory, u"*.ppt", SearchOption::TopDirectoryOnly);
for (const auto& inputPath : inputPaths)
{
    auto outputFileName = Path::GetFileNameWithoutExtension(inputPath) + u".pptx";
    auto outputPath = Path::Combine(outputDirectory, outputFileName);

    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);
        presentation->Save(outputPath, SaveFormat::Pptx);
        presentation->Dispose();
        Console::WriteLine(String::Format(u"Converted: {0}", inputPath));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Failed: {0} ({1})", inputPath, exception->get_Message()));
    }
}
```

Para cargas de trabajo de producción, registre la excepción completa, decida si se puede sobrescribir un archivo de salida existente y escriba los nombres de los archivos que fallaron en una cola de reintento o revisión. Los archivos corruptos, los archivos protegidos con contraseña abiertos sin la contraseña requerida, las rutas inaccesibles y el contenido no compatible pueden causar que una conversión falle. Consulte [Password-Protected Presentations](/cpp/password-protected-presentation/) para cargar archivos cifrados.

## **Fidelidad y características heredadas**

La conversión normalmente preserva diapositivas, patrones, diseños, texto, formas, imágenes, tablas y gráficos. Sin embargo, PPT y PPTX no representan cada característica de la misma manera exacta. Una característica heredada que no tiene equivalente en PPTX, o que no es compatible con la biblioteca, puede ser normalizada, omitida o mostrada de forma diferente.

Compruebe el archivo convertido cuando contenga animaciones, transiciones, objetos OLE incrustados o vinculados, controles ActiveX, medios incrustados, fuentes poco comunes o macros VBA. Un archivo PPTX sencillo no es un formato con macros, por lo que debe usar un flujo de trabajo adecuado con macros cuando VBA deba permanecer disponible. También verifique que las fuentes necesarias y los recursos externos estén presentes en el entorno donde se abrirá o renderizará la presentación convertida.

Para documentos importantes, reabra el PPTX generado programáticamente e inspeccione el número clave de diapositivas y su contenido, luego compare su apariencia y el comportamiento de la presentación en el visor previsto. No considere que una llamada exitosa a [Presentation::Save](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/save/) sea prueba de que cada característica heredada tiene una representación exacta en PPTX.

## **Cuándo usar PPTX**

Utilice PPTX cuando la presentación se editará en versiones actuales de PowerPoint, se intercambiará con sistemas que trabajan con paquetes Open XML, o se almacene en un formato más fácil de inspeccionar y recuperar que el binario heredado PPT. Conserve el PPT original como copia de archivo o de retroceso hasta que la presentación convertida haya superado sus pruebas de fidelidad.

Si necesita PDF, HTML, imágenes, XPS u otro tipo de salida, utilice la guía específica de formato en [Convert Presentations to Multiple Formats](/cpp/convert-presentation/) en lugar de suponer que todos los destinos preservan las características editables de PowerPoint.

## **Conversor en línea**

Para un archivo ocasional o una comparación rápida, puede usar el [online PPT to PPTX converter](https://products.aspose.app/slides/es/conversion/ppt-to-pptx). Para conversiones repetibles, procesamiento por lotes o manejo de errores a nivel de aplicación, utilice la API de C++.

## **Artículos relacionados**

- [Guardar presentaciones en C++](/cpp/save-presentation/)
- [Formatos de archivo compatibles](/cpp/supported-file-formats/)
- [Abrir presentaciones en C++](/cpp/open-presentation/)

## **Preguntas frecuentes**

**¿Puedo convertir PPT a PPTX sin tener Microsoft PowerPoint instalado?**

Sí. Aspose.Slides for C++ carga y guarda archivos de presentación sin requerir Microsoft PowerPoint.

**¿La conversión de PPT a PPTX preservará todo el contenido exactamente?**

Preserva el contenido común de la presentación, pero la fidelidad exacta no está garantizada para cada característica heredada o no compatible. Revise el archivo generado cuando contenga macros, objetos OLE o ActiveX, medios, animaciones especializadas o fuentes poco comunes.

**¿Puedo convertir un archivo PPT protegido con contraseña?**

Sí, si proporciona la contraseña correcta al cargar el archivo. Una contraseña ausente o incorrecta hace que la operación de carga falle.

**¿Debo eliminar el archivo PPT después de la conversión?**

Conserve el original hasta que haya verificado el PPTX en los visores y flujos de trabajo que le importan. Esto proporciona una copia de retroceso si una característica heredada se convierte de forma diferente.