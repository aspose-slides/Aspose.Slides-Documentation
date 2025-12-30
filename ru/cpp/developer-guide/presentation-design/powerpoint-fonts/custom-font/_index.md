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
description: "Настройте шрифты в слайдах PowerPoint с помощью Aspose.Slides для C++, чтобы ваши презентации выглядели чётко и одинаково на любом устройстве."
---

{{% alert color="primary" %}} 

Aspose Slides позволяет загружать эти шрифты с помощью [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) и TrueType Collection (.ttc) шрифты. См. [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) шрифты. См. [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Загрузка пользовательских шрифтов**

Aspose.Slides позволяет загружать шрифты, используемые в презентации, без их установки в системе. Это влияет на экспорт — такие форматы, как PDF, изображения и другие поддерживаемые форматы — поэтому полученные документы выглядят одинаково в разных окружениях. Шрифты загружаются из пользовательских каталогов.

1. Укажите одну или несколько папок, содержащих файлы шрифтов.
2. Вызовите статический метод [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/) для загрузки шрифтов из этих папок.
3. Загрузите и отрендерите/экспортируйте презентацию.
4. Вызовите [FontsLoader.clearCache](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/clearcache/) для очистки кэша шрифтов.

Ниже приведён пример кода, демонстрирующего процесс загрузки шрифтов:
```cpp
// Определите папки, содержащие пользовательские файлы шрифтов.
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Загрузите пользовательские шрифты из указанных папок.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Отрендерите/экспортируйте презентацию (например, в PDF, изображения или другие форматы), используя загруженные шрифты.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Очистите кэш шрифтов после завершения работы.
FontsLoader::ClearCache();
```


{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/) добавляет дополнительные папки в пути поиска шрифтов, но не меняет порядок инициализации шрифтов.
Шрифты инициализируются в следующем порядке:

1. Путь к шрифтам по умолчанию операционной системы.
1. Пути, загруженные через [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/).

{{%/alert %}}

## **Получить пользовательские папки шрифтов**
Aspose.Slides предоставляет [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) для получения папок шрифтов. Этот метод возвращает папки, добавленные через метод `LoadExternalFonts`, а также системные папки шрифтов.

Этот C++ код показывает, как использовать метод [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/):
``` cpp
// Эта строка выводит папки, которые проверяются на наличие файлов шрифтов.
// Это папки, добавленные через метод LoadExternalFonts, и системные папки шрифтов.
auto fontFolders = FontsLoader::GetFontFolders();
```


## **Указать пользовательские шрифты, используемые в презентации**
Aspose.Slides предоставляет свойство [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) для указания внешних шрифтов, которые будут использоваться в презентации.

Этот C++ код показывает, как использовать свойство [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/):
``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //работа с презентацией
    //CustomFont1, CustomFont2, а также шрифты из папок assets\fonts & global\fonts и их подпапок доступны презентации
}
```


## **Управление шрифтами извне**
Aspose.Slides предоставляет метод [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfont/) для загрузки внешних шрифтов в массив байтов.

Этот C++ код демонстрирует процесс загрузки шрифта в массив байтов:
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


## **Часто задаваемые вопросы**

**Влияют ли пользовательские шрифты на экспорт во все форматы (PDF, PNG, SVG, HTML)?**

Да. Подключённые шрифты используются рендерером во всех форматах экспорта.

**Встраиваются ли пользовательские шрифты автоматически в конечный PPTX?**

Нет. Регистрация шрифта для рендеринга не равна его встраиванию в PPTX. Если нужен шрифт внутри файла презентации, используйте явные [возможности встраивания](/slides/ru/cpp/embedded-font/).

**Можно ли контролировать поведение fallback, когда у пользовательского шрифта отсутствуют некоторые глифы?**

Да. Настройте [замену шрифтов](/slides/ru/cpp/font-substitution/), [правила замены](/slides/ru/cpp/font-replacement/) и [наборы fallback](/slides/ru/cpp/fallback-font/), чтобы точно определить, какой шрифт использовать при отсутствии запрашиваемого глифа.

**Можно ли использовать шрифты в контейнерах Linux/Docker без их установки в системе?**

Да. Указывайте свои папки со шрифтами или загружайте шрифты из массивов байтов. Это устраняет любую зависимость от системных каталогов шрифтов в образе контейнера.

**Что насчёт лицензирования — можно ли встраивать любой пользовательский шрифт без ограничений?**

Вы отвечаете за соблюдение лицензий на шрифты. Условия различаются; некоторые лицензии запрещают встраивание или коммерческое использование. Всегда проверяйте EULA шрифта перед распространением результатов.