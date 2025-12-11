---
title: Настройка шрифтов PowerPoint в C++
linktitle: Пользовательский шрифт
type: docs
weight: 20
url: /ru/cpp/custom-font/
keywords:
- шрифт
- пользовательский шрифт
- внешний шрифт
- загрузка шрифта
- управление шрифтами
- папка шрифтов
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Настраивайте шрифты в слайдах PowerPoint с помощью Aspose.Slides для C++, чтобы ваши презентации выглядели чётко и одинаково на любом устройстве."
---

{{% alert color="primary" %}} 

Aspose Slides позволяет загружать эти шрифты с помощью [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* Шрифты TrueType (.ttf) и коллекции TrueType (.ttc). См. [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Шрифты OpenType (.otf). См. [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Загрузка пользовательских шрифтов**

Aspose.Slides позволяет загружать шрифты, которые будут отрисованы в презентациях, без их установки в системе. Шрифты загружаются из пользовательского каталога. 

1. Создайте экземпляр класса [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/) и вызовите метод [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/).
2. Загрузите презентацию, которая будет отрисована.
3. Очистите кэш в классе [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/).

``` cpp
const String fontPath = u"../templates/";
const String outPath = u"../out/UseCustomFonts_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";

// Устанавливает путь к шрифтам
ArrayPtr<String> folders = System::MakeObject<Array<String>>(1, fontPath);

// Загружает шрифты из пользовательского каталога шрифтов
FontsLoader::LoadExternalFonts(folders);

// Выполняет некоторые действия и рендеринг презентации/слайда
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);
pres->Save(outPath, Export::SaveFormat::Pptx);

// Очищает кэш шрифтов
FontsLoader::ClearCache();
```


## **Получить пользовательские каталоги шрифтов**
Aspose.Slides предоставляет [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) для поиска каталогов шрифтов. Этот метод возвращает каталоги, добавленные через метод `LoadExternalFonts`, и системные каталоги шрифтов.

``` cpp
// Эта строка выводит каталоги, проверяемые на наличие файлов шрифтов.
// Это каталоги, добавленные через метод LoadExternalFonts и системные каталоги шрифтов.
auto fontFolders = FontsLoader::GetFontFolders();
```


## **Указать пользовательские шрифты, используемые в презентации**
Aspose.Slides предоставляет свойство [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) для указания внешних шрифтов, которые будут использоваться в презентации.

``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    // работа с презентацией
    // CustomFont1, CustomFont2, а также шрифты из папок assets\fonts и global\fonts и их подпапок доступны презентации
}
```


## **Управление шрифтами извне**
Aspose.Slides предоставляет метод [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfont/) для загрузки внешних шрифтов в массив байтов.

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


## **FAQ**

**Влияют ли пользовательские шрифты на экспорт во все форматы (PDF, PNG, SVG, HTML)?**

Да. Подключённые шрифты используются рендерером во всех форматах экспорта.

**Автоматически ли пользовательские шрифты встраиваются в получающийся PPTX?**

Нет. Регистрация шрифта для отрисовки не является встраиванием его в PPTX. Если требуется, чтобы шрифт находился внутри файла презентации, необходимо использовать явные [embedding features](/slides/ru/cpp/embedded-font/).

**Можно ли управлять поведением fallback, когда у пользовательского шрифта отсутствуют определённые глифы?**

Да. Настройте [font substitution](/slides/ru/cpp/font-substitution/), [replacement rules](/slides/ru/cpp/font-replacement/) и [fallback sets](/slides/ru/cpp/fallback-font/), чтобы точно определить, какой шрифт использовать, когда запрашиваемый глиф отсутствует.

**Можно ли использовать шрифты в контейнерах Linux/Docker без их установки в системе?**

Да. Укажите свои каталоги шрифтов или загрузите шрифты из массивов байтов. Это устраняет любую зависимость от системных каталогов шрифтов в образе контейнера.

**Что насчёт лицензирования — можно ли встраивать любой пользовательский шрифт без ограничений?**

Вы несёте ответственность за соблюдение лицензий шрифтов. Условия различаются; некоторые лицензии запрещают встраивание или коммерческое использование. Всегда проверяйте EULA шрифта перед распространением результатов.