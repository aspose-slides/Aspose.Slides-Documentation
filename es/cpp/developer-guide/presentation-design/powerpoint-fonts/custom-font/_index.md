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
- administrar fuentes
- carpeta de fuentes
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Personaliza las fuentes en diapositivas de PowerPoint con Aspose.Slides para C++ para mantener tus presentaciones nítidas y consistentes en cualquier dispositivo."
---

{{% alert color="primary" %}} 

Aspose Slides le permite cargar estas fuentes usando [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* Fuentes TrueType (.ttf) y TrueType Collection (.ttc). Véase [TrueType](https://en.wikipedia.org/wiki/TrueType).
* Fuentes OpenType (.otf). Véase [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Cargar fuentes personalizadas**

Aspose.Slides le permite cargar fuentes que se renderizan en presentaciones sin tener que instalar esas fuentes. Las fuentes se cargan desde un directorio personalizado. 

1. Cree una instancia de la clase [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/) y llame al método [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/).
2. Cargue la presentación que se renderizará.
3. Borre la caché en la clase [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/).

Este código C++ demuestra el proceso de carga de fuentes:
``` cpp
const String fontPath = u"../templates/";
const String outPath = u"../out/UseCustomFonts_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";

// Establece la ruta de las fuentes
ArrayPtr<String> folders = System::MakeObject<Array<String>>(1, fontPath);

// Carga las fuentes del directorio de fuentes personalizadas
FontsLoader::LoadExternalFonts(folders);

// Realiza alguna tarea y renderiza la presentación/diapositiva
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);
pres->Save(outPath, Export::SaveFormat::Pptx);

// Borra la caché de fuentes
FontsLoader::ClearCache();
```


## **Obtener carpetas de fuentes personalizadas**
Aspose.Slides proporciona [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) para permitirle encontrar carpetas de fuentes. Este método devuelve las carpetas agregadas mediante el método `LoadExternalFonts` y las carpetas de fuentes del sistema.

Este código C++ le muestra cómo usar el método [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/):
``` cpp
// Esta línea muestra las carpetas que se verifican para archivos de fuentes.
// Estas son carpetas añadidas mediante el método LoadExternalFonts y carpetas de fuentes del sistema.
auto fontFolders = FontsLoader::GetFontFolders();
```


## **Especificar fuentes personalizadas usadas con una presentación**
Aspose.Slides proporciona la propiedad [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) para permitirle especificar fuentes externas que se usarán con la presentación.

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
    //CustomFont1, CustomFont2 así como fuentes de las carpetas assets\fonts y global\fonts y sus subcarpetas están disponibles para la presentación
}
```


## **Administrar fuentes externamente**
Aspose.Slides proporciona el método [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfont/) para permitirle cargar fuentes externas en una matriz de bytes.

Este código C++ demuestra el proceso de carga de fuentes en una matriz de bytes:
```cpp
// Ruta al directorio de documentos
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

**¿Las fuentes personalizadas afectan la exportación a todos los formatos (PDF, PNG, SVG, HTML)?**

Sí. Las fuentes conectadas son usadas por el motor de renderizado en todos los formatos de exportación.

**¿Se incrustan automáticamente las fuentes personalizadas en el PPTX resultante?**

No. Registrar una fuente para renderizar no es lo mismo que incrustarla en un PPTX. Si necesita que la fuente se incluya dentro del archivo de la presentación, debe usar las [funciones de incrustación](/slides/es/cpp/embedded-font/).

**¿Puedo controlar el comportamiento de respaldo cuando una fuente personalizada carece de ciertos glifos?**

Sí. Configure la [sustitución de fuentes](/slides/es/cpp/font-substitution/), las [reglas de reemplazo](/slides/es/cpp/font-replacement/) y los [conjuntos de respaldo](/slides/es/cpp/fallback-font/) para definir exactamente qué fuente se usa cuando falta el glifo solicitado.

**¿Puedo usar fuentes en contenedores Linux/Docker sin instalarlas a nivel del sistema?**

Sí. Apunte a sus propias carpetas de fuentes o cargue fuentes desde matrices de bytes. Esto elimina cualquier dependencia de los directorios de fuentes del sistema en la imagen del contenedor.

**¿Qué pasa con la licencia—puedo incrustar cualquier fuente personalizada sin restricciones?**

Usted es responsable del cumplimiento de la licencia de la fuente. Los términos varían; algunas licencias prohíben la incrustación o el uso comercial. Siempre revise el EULA de la fuente antes de distribuir los resultados.