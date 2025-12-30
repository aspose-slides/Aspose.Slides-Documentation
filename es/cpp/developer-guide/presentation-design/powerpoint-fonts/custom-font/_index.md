---
title: Personalizar fuentes de PowerPoint en С++
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
- С++
- Aspose.Slides
description: "Personaliza las fuentes en diapositivas de PowerPoint con Aspose.Slides para С++ para que tus presentaciones sean nítidas y consistentes en cualquier dispositivo."
---

{{% alert color="primary" %}} 

Aspose Slides le permite cargar estas fuentes usando [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* Fuentes TrueType (.ttf) y TrueType Collection (.ttc). Consulte [TrueType](https://en.wikipedia.org/wiki/TrueType).
* Fuentes OpenType (.otf). Consulte [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Cargar fuentes personalizadas**

Aspose.Slides le permite cargar fuentes utilizadas en una presentación sin instalarlas en el sistema. Esto afecta la salida de exportación —como PDF, imágenes y otros formatos compatibles— de modo que los documentos resultantes se vean consistentes en todos los entornos. Las fuentes se cargan desde directorios personalizados.

1. Especifique una o más carpetas que contengan los archivos de fuentes.
2. Llame al método estático [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/) para cargar fuentes desde esas carpetas.
3. Cargue y renderice/exporte la presentación.
4. Llame a [FontsLoader.clearCache](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/clearcache/) para borrar la caché de fuentes.

El siguiente ejemplo de código muestra el proceso de carga de fuentes:
```cpp
// Definir carpetas que contienen archivos de fuentes personalizados.
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Cargar fuentes personalizadas desde las carpetas especificadas.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Renderizar/exportar la presentación (p.ej., a PDF, imágenes u otros formatos) usando las fuentes cargadas.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Borrar la caché de fuentes después de que el trabajo haya finalizado.
FontsLoader::ClearCache();
```


{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/) añade carpetas adicionales a las rutas de búsqueda de fuentes, pero no cambia el orden de inicialización de fuentes.
Las fuentes se inicializan en este orden:

1. La ruta de fuentes predeterminada del sistema operativo.
1. Las rutas cargadas a través de [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/).

{{%/alert %}}

## **Obtener carpetas de fuentes personalizadas**
Aspose.Slides proporciona [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) para que pueda encontrar carpetas de fuentes. Este método devuelve las carpetas añadidas mediante el método `LoadExternalFonts` y las carpetas de fuentes del sistema.

Este código C++ le muestra cómo usar el método [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/):
``` cpp
// Esta línea muestra las carpetas que se comprueban para archivos de fuentes.
// Son carpetas añadidas mediante el método LoadExternalFonts y carpetas de fuentes del sistema.
auto fontFolders = FontsLoader::GetFontFolders();
```


## **Especificar fuentes personalizadas usadas con una presentación**
Aspose.Slides proporciona la propiedad [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) para que pueda especificar fuentes externas que se usarán con la presentación.

Este código C++ le muestra cómo usar la propiedad [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/):
``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //trabajar con la presentación
    //CustomFont1, CustomFont2, así como fuentes de las carpetas assets\fonts y global\fonts y sus subcarpetas están disponibles para la presentación
}
```


## **Gestionar fuentes externamente**
Aspose.Slides proporciona el método [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfont/) para que pueda cargar fuentes externas en una matriz de bytes.

Este código C++ demuestra el proceso de carga de fuentes en una matriz de bytes:
```cpp
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

**¿Afectan las fuentes personalizadas a la exportación a todos los formatos (PDF, PNG, SVG, HTML)?**

Sí. Las fuentes vinculadas son utilizadas por el motor de renderizado en todos los formatos de exportación.

**¿Se incrustan automáticamente las fuentes personalizadas en el PPTX resultante?**

No. Registrar una fuente para el renderizado no es lo mismo que incrustarla en un PPTX. Si necesita que la fuente se incluya dentro del archivo de presentación, debe usar las [funcionalidades de incrustación](/slides/es/cpp/embedded-font/).

**¿Puedo controlar el comportamiento de sustitución cuando una fuente personalizada carece de ciertos glifos?**

Sí. Configure la [sustitución de fuentes](/slides/es/cpp/font-substitution/), las [reglas de reemplazo](/slides/es/cpp/font-replacement/) y los [conjuntos de fuentes de respaldo](/slides/es/cpp/fallback-font/) para definir exactamente qué fuente se usa cuando el glifo solicitado no está disponible.

**¿Puedo usar fuentes en contenedores Linux/Docker sin instalarlas en todo el sistema?**

Sí. Apunte a sus propias carpetas de fuentes o cargue fuentes desde matrices de bytes. Esto elimina cualquier dependencia de los directorios de fuentes del sistema en la imagen del contenedor.

**¿Qué pasa con la licencia—puedo incrustar cualquier fuente personalizada sin restricciones?**

Usted es responsable del cumplimiento de la licencia de la fuente. Los términos varían; algunas licencias prohíben la incrustación o el uso comercial. Siempre revise la EULA de la fuente antes de distribuir los resultados.