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
description: "Настраивайте шрифты в слайдах PowerPoint с помощью Aspose.Slides для C++, чтобы ваши презентации оставались четкими и одинаковыми на любом устройстве."
---
## **Обзор**

Aspose.Slides позволяет использовать пользовательские шрифты в презентациях без их установки в операционной системе. Вы можете загружать шрифты из пользовательских папок, предоставлять шрифты для конкретной презентации через источники шрифтов уровня документа или загружать внешние шрифты непосредственно из бинарных данных.

Загруженные шрифты используются при рендеринге или экспорте презентации, например в PDF, изображения и другие поддерживаемые форматы. Это помогает сохранять единообразный вывод презентаций в разных средах. В статье также объясняется, как проверить папки шрифтов, используемые Aspose.Slides, и как очистить кеш шрифтов после работы с внешними шрифтами.

Регистрация пользовательских шрифтов для рендеринга отличается от встраивания шрифтов в файл PPTX. Если шрифт должен быть сохранён внутри самой презентации, используйте функции встраивания шрифтов явно.

{{% alert color="primary" %}} 
Aspose Slides позволяет загружать эти шрифты с помощью [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) и TrueType Collection (.ttc) шрифты. Смотрите [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) шрифты. Смотрите [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Загрузка пользовательских шрифтов**

Aspose.Slides позволяет загружать шрифты, используемые в презентации, без их установки в системе. Это влияет на вывод при экспорте — например в PDF, изображения и другие поддерживаемые форматы — поэтому полученные документы выглядят одинаково в разных средах. Шрифты загружаются из пользовательских каталогов.

1. Укажите одну или несколько папок, содержащих файлы шрифтов.  
2. Вызовите статический метод [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsloader/loadexternalfonts/) для загрузки шрифтов из этих папок.  
3. Загрузите и отрендерите/экспортируйте презентацию.  
4. Вызовите [FontsLoader.clearCache](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsloader/clearcache/) для очистки кеша шрифтов.

Ниже приведён пример кода, демонстрирующий процесс загрузки шрифтов:

```cpp
// Определите папки, содержащие пользовательские файлы шрифтов.
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Загрузите пользовательские шрифты из указанных папок.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Выполните рендеринг/экспорт презентации (например, в PDF, изображения или другие форматы), используя загруженные шрифты.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Очистите кеш шрифтов после завершения работы.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Примечание" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsloader/loadexternalfonts/) добавляет дополнительные папки в пути поиска шрифтов, но не изменяет порядок инициализации шрифтов.  
Шрифты инициализируются в следующем порядке:

1. Путь к шрифтам операционной системы по умолчанию.  
1. Пути, загруженные через [FontsLoader](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsloader/).
{{%/alert %}}

## **Получить пользовательские папки шрифтов**

Aspose.Slides предоставляет [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsloader/getfontfolders/) для поиска папок шрифтов. Этот метод возвращает папки, добавленные через метод `LoadExternalFonts`, а также системные папки шрифтов.

Ниже показан пример C++ кода, использующего метод [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsloader/getfontfolders/):

``` cpp
// Эта строка выводит папки, проверяемые на наличие файлов шрифтов.
// Это папки, добавленные через метод LoadExternalFonts, и системные папки шрифтов.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Указание пользовательских шрифтов, используемых в презентации**

Aspose.Slides предоставляет свойство [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) для указания внешних шрифтов, которые будут использоваться в презентации.

Ниже показан пример C++ кода, использующего свойство [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/):

``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //работа с презентацией
    //CustomFont1, CustomFont2, а также шрифты из папок assets\fonts & global\fonts и их подпапок доступны для презентации
}
```

## **Управление шрифтами внешне**

Aspose.Slides предоставляет метод [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsloader/loadexternalfont/) для загрузки внешних шрифтов в массив байтов.

Ниже показан пример C++ кода, демонстрирующего процесс загрузки шрифта в массив байтов:

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

**Встраиваются ли пользовательские шрифты автоматически в полученный PPTX?**

Нет. Регистрация шрифта для рендеринга не равна его встраиванию в PPTX. Если необходимо, чтобы шрифт находился внутри файла презентации, используйте явные [возможности встраивания](/slides/ru/cpp/embedded-font/).

**Можно ли управлять поведением fallback, когда у пользовательского шрифта отсутствуют некоторые глифы?**

Да. Настройте [замену шрифтов](/slides/ru/cpp/font-substitution/), [правила замены](/slides/ru/cpp/font-replacement/) и [наборы резервных шрифтов](/slides/ru/cpp/fallback-font/), чтобы точно определить, какой шрифт будет использоваться, если нужный глиф отсутствует.

**Можно ли использовать шрифты в контейнерах Linux/Docker без их системной установки?**

Да. Укажите свои собственные папки шрифтов или загружайте шрифты из массивов байтов. Это устраняет любую зависимость от системных каталогов шрифтов в образе контейнера.

**А как насчёт лицензирования — можно ли встраивать любые пользовательские шрифты без ограничений?**

Вы несёте ответственность за соблюдение лицензий шрифтов. Условия различаются; некоторые лицензии запрещают встраивание или коммерческое использование. Всегда проверяйте EULA шрифта перед распространением результатов.