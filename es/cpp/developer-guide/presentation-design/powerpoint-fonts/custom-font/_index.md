---
title: Fuente personalizada en C++
type: docs
weight: 20
url: /es/cpp/custom-font/
keywords: "Fuentes, fuentes personalizadas, presentación de PowerPoint, C++, CPP, Aspose.Slides para C++"
description: "Fuentes personalizadas de PowerPoint en C++"
---

{{% alert color="primary" %}} 

Aspose Slides te permite cargar estas fuentes usando [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* Fuentes TrueType (.ttf) y Colección TrueType (.ttc). Ver [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Fuentes OpenType (.otf). Ver [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Cargar Fuentes Personalizadas**

Aspose.Slides te permite cargar fuentes que se renderizan en presentaciones sin necesidad de instalar esas fuentes. Las fuentes se cargan desde un directorio personalizado. 

1. Crea una instancia de la clase [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/) y llama al método [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/).
2. Carga la presentación que se va a renderizar.
3. Limpia la caché en la clase [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/).

Este código C++ demuestra el proceso de carga de fuentes:

``` cpp
const String fontPath = u"../templates/";
const String outPath = u"../out/UseCustomFonts_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";

// Establece la ruta de las fuentes
ArrayPtr<String> folders = System::MakeObject<Array<String>>(1, fontPath);

// Carga las fuentes del directorio de fuentes personalizadas
FontsLoader::LoadExternalFonts(folders);

// Realiza algún trabajo y realiza la renderización de la presentación/diapositiva
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);
pres->Save(outPath, Export::SaveFormat::Pptx);

// Limpia la caché de fuentes
FontsLoader::ClearCache();
```

## **Obtener la Carpeta de Fuentes Personalizadas**
Aspose.Slides proporciona [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) para permitirte encontrar carpetas de fuentes. Este método devuelve las carpetas añadidas a través del método `LoadExternalFonts` y las carpetas de fuentes del sistema.

Este código C++ te muestra cómo usar el método [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/):

``` cpp
// Esta línea muestra las carpetas que se revisan para archivos de fuentes.
// Esas son las carpetas añadidas a través del método LoadExternalFonts y las carpetas de fuentes del sistema.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Especificar Fuentes Personalizadas Usadas con la Presentación**
Aspose.Slides proporciona la propiedad [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) para permitirte especificar fuentes externas que se usarán con la presentación.

Este código C++ te muestra cómo usar la propiedad [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/):

``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //trabajar con la presentación
    //CustomFont1, CustomFont2 así como fuentes de las carpetas assets\fonts & global\fonts y sus subcarpetas están disponibles para la presentación
}
```

## **Gestionar Fuentes Externamente**
Aspose.Slides proporciona el método [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfont/) para permitirte cargar fuentes externas en un array de bytes.

Este código C++ demuestra el proceso de carga de fuentes en un array de bytes:

```cpp
// La ruta al directorio de documentos
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);

SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```