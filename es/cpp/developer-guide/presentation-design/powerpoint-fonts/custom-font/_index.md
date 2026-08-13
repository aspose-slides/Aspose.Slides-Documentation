---
title: Personalizar fuentes de PowerPoint en C++
linktitle: Fuente personalizada
type: docs
weight: 20
url: /es/cpp/custom-font/
keywords:
- fuente
- fuente personalizada
- fuente externa
- cargar fuente
- gestionar fuentes
- carpeta de fuentes
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Personaliza las fuentes en diapositivas de PowerPoint con Aspose.Slides para C++ y mantiene tus presentaciones nítidas y coherentes en cualquier dispositivo."
---
## **Visión general**

Aspose.Slides le permite utilizar fuentes personalizadas en presentaciones sin instalarlas en el sistema operativo. Puede cargar fuentes desde carpetas personalizadas, proporcionar fuentes para una presentación específica a través de fuentes a nivel de documento, o cargar fuentes externas directamente desde datos binarios.

Las fuentes cargadas se utilizan cuando una presentación se renderiza o exporta, por ejemplo a PDF, imágenes y otros formatos compatibles. Esto ayuda a mantener la salida de la presentación coherente en diferentes entornos. El artículo también explica cómo inspeccionar las carpetas de fuentes utilizadas por Aspose.Slides y cómo borrar la caché de fuentes después de trabajar con fuentes externas.

Registrar fuentes personalizadas para la renderización es independiente de incrustar fuentes en un archivo PPTX. Si una fuente debe almacenarse dentro de la propia presentación, utilice explícitamente las funciones de incrustación de fuentes.

{{% alert color="info" %}} 
Aspose Slides le permite cargar estas fuentes mediante [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* Fuentes TrueType (.ttf) y TrueType Collection (.ttc). Consulte [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Fuentes OpenType (.otf). Consulte [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Cargar fuentes personalizadas**

Aspose.Slides le permite cargar fuentes utilizadas en una presentación sin instalarlas en el sistema. Esto afecta la salida de exportación —como PDF, imágenes y otros formatos compatibles— de modo que los documentos resultantes se vean coherentes entre entornos. Las fuentes se cargan desde directorios personalizados.

1. Especifique una o más carpetas que contengan los archivos de fuentes.  
2. Llame al método estático [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontsloader/loadexternalfonts/) para cargar fuentes desde esas carpetas.  
3. Cargue y renderice/expórtela presentación.  
4. Llame a [FontsLoader.clearCache](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontsloader/clearcache/) para borrar la caché de fuentes.

El siguiente ejemplo de código muestra el proceso de carga de fuentes:

```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Define carpetas que contengan archivos de fuentes personalizados.
String externalFontFolder = u"assets/fonts";
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Load fuentes personalizadas desde las carpetas especificadas.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Renderiza/exporta la presentación (p.ej., a PDF, imágenes u otros formatos) usando las fuentes cargadas.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Borra la caché de fuentes después de que el trabajo haya finalizado.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Nota" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontsloader/loadexternalfonts/) agrega carpetas adicionales a las rutas de búsqueda de fuentes, pero no cambia el orden de inicialización de fuentes.
Las fuentes se inicializan en este orden:

1. La ruta de fuentes predeterminada del sistema operativo.  
1. Las rutas cargadas a través de [FontsLoader](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontsloader/).

{{%/alert %}}

## **Obtener carpetas de fuentes personalizadas**
Aspose.Slides proporciona [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontsloader/getfontfolders/) para permitirle encontrar carpetas de fuentes. Este método devuelve las carpetas añadidas mediante el método `LoadExternalFonts` y las carpetas de fuentes del sistema.

Este código C++ le muestra cómo usar el método [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontsloader/getfontfolders/):

``` cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// Esta línea muestra las carpetas que se comprueban para archivos de fuentes.
// Esas son carpetas añadidas mediante el método LoadExternalFonts y carpetas de fuentes del sistema.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Especificar fuentes personalizadas usadas con una presentación**
Aspose.Slides proporciona la propiedad [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/es/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) para permitirle especificar fuentes externas que se usarán con la presentación.

Este código C++ le muestra cómo usar la propiedad [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/es/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/):

``` cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //trabajar con la presentación
    //CustomFont1, CustomFont2 así como fuentes de las carpetas assets\fonts y global\fonts y sus subcarpetas están disponibles para la presentación
}
```

## **Gestionar fuentes externamente**
Aspose.Slides proporciona el método [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontsloader/loadexternalfont/) para permitirle cargar fuentes externas en una matriz de bytes.

Este código C++ demuestra el proceso de carga de fuentes en una matriz de bytes:

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

// La ruta al directorio de documentos
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });// ;
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```

## **Preguntas frecuentes**

### ¿Las fuentes personalizadas afectan la exportación a todos los formatos (PDF, PNG, SVG, HTML)?

Sí. Las fuentes conectadas son utilizadas por el motor de renderizado en todos los formatos de exportación.

### ¿Las fuentes personalizadas se incrustan automáticamente en el PPTX resultante?

No. Registrar una fuente para la renderización no es lo mismo que incrustarla en un PPTX. Si necesita que la fuente esté incluida dentro del archivo de la presentación, debe utilizar las [funciones de incrustación](/slides/es/cpp/embedded-font/).

### ¿Puedo controlar el comportamiento de reserva cuando una fuente personalizada carece de ciertos glifos?

Sí. Configure la [sustitución de fuentes](/slides/es/cpp/font-substitution/), las [reglas de reemplazo](/slides/es/cpp/font-replacement/), y los [conjuntos de reserva](/slides/es/cpp/fallback-font/) para definir exactamente qué fuente se utiliza cuando el glifo solicitado no está disponible.

### ¿Puedo usar fuentes en contenedores Linux/Docker sin instalarlas a nivel del sistema?

Sí. Apunte a sus propias carpetas de fuentes o cargue fuentes desde matrices de bytes. Esto elimina cualquier dependencia de los directorios de fuentes del sistema en la imagen del contenedor.

### ¿Qué pasa con la licencia—puedo incrustar cualquier fuente personalizada sin restricciones?

Usted es responsable de cumplir con la licencia de la fuente. Los términos varían; algunas licencias prohíben la incrustación o el uso comercial. Siempre revise la EULA de la fuente antes de distribuir los resultados.