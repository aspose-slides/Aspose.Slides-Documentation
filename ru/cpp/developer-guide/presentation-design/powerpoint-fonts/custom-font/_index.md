---
title: Пользовательский шрифт в C++
type: docs
weight: 20
url: /cpp/custom-font/
keywords: "Шрифты, пользовательские шрифты, презентация PowerPoint, C++, CPP, Aspose.Slides для C++"
description: "Пользовательские шрифты PowerPoint в C++"
---

{{% alert color="primary" %}} 

Aspose Slides позволяет загружать эти шрифты с помощью [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* Шрифты TrueType (.ttf) и коллекции TrueType (.ttc). См. [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Шрифты OpenType (.otf). См. [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Загрузка пользовательских шрифтов**

Aspose.Slides позволяет загружать шрифты, которые отображаются в презентациях, без необходимости их установки. Шрифты загружаются из пользовательского каталога.

1. Создайте экземпляр класса [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/) и вызовите метод [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/).
2. Загрузите презентацию, которая будет отображаться.
3. Очистите кэш в классе [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/).

Этот код на C++ демонстрирует процесс загрузки шрифтов:

``` cpp
const String fontPath = u"../templates/";
const String outPath = u"../out/UseCustomFonts_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";

// Устанавливает путь к шрифтам
ArrayPtr<String> folders = System::MakeObject<Array<String>>(1, fontPath);

// Загружает шрифты из пользовательского каталога
FontsLoader::LoadExternalFonts(folders);

// Выполните какую-нибудь работу и отрисуйте презентацию/слайды
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);
pres->Save(outPath, Export::SaveFormat::Pptx);

// Очищает кэш шрифтов
FontsLoader::ClearCache();
```

## **Получение папки пользовательских шрифтов**
Aspose.Slides предоставляет [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) для того, чтобы позволить вам находить папки шрифтов. Этот метод возвращает папки, добавленные через метод `LoadExternalFonts`, и системные папки шрифтов.

Этот код на C++ показывает, как использовать метод [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/):

``` cpp
// Эта строка выводит папки, которые проверяются на наличие файлов шрифтов.
// Это папки, добавленные через метод LoadExternalFonts и системные папки шрифтов.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Укажите пользовательские шрифты, используемые с презентацией**
Aspose.Slides предоставляет свойство [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/), чтобы вы могли указать внешние шрифты, которые будут использоваться с презентацией.

Этот код на C++ показывает, как использовать свойство [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/):

``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //работа с презентацией
    //CustomFont1, CustomFont2, а также шрифты из папок assets\fonts и global\fonts и их подкаталогов доступны для презентации
}
```

## **Управление шрифтами извне**
Aspose.Slides предоставляет метод [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfont/), который позволяет вам загружать внешние шрифты в массив байтов.

Этот код на C++ демонстрирует процесс загрузки шрифтов в массив байтов:

```cpp
// Путь к каталогу документов
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });// ;
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```