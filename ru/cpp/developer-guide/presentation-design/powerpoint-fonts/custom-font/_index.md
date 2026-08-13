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
## **Обзор**

Aspose.Slides позволяет использовать пользовательские шрифты в презентациях без их установки в операционной системе. Вы можете загружать шрифты из пользовательских папок, предоставлять шрифты для конкретной презентации через источники шрифтов уровня документа, или загружать внешние шрифты напрямую из двоичных данных.

Загруженные шрифты используются при рендеринге или экспорте презентации, например в PDF, изображения и другие поддерживаемые форматы. Это помогает сохранять консистентность вывода презентации в разных средах. В статье также объясняется, как просмотреть папки шрифтов, используемые Aspose.Slides, и как очистить кеш шрифтов после работы с внешними шрифтами.

Регистрация пользовательских шрифтов для рендеринга отдельна от встраивания шрифтов в файл PPTX. Если шрифт необходимо сохранять внутри самой презентации, используйте функции встраивания шрифтов явно.

{{% alert color="info" %}} 
Aspose Slides позволяет загружать эти шрифты используя [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) и TrueType Collection (.ttc) шрифты. См. [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) шрифты. См. [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Загрузка пользовательских шрифтов**

Aspose.Slides позволяет загружать шрифты, используемые в презентации, без их установки в системе. Это влияет на вывод при экспорте — например PDF, изображения и другие поддерживаемые форматы — так что полученные документы выглядят одинаково в разных средах. Шрифты загружаются из пользовательских каталогов.

1. Укажите одну или несколько папок, содержащих файлы шрифтов.
2. Вызовите статический метод [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsloader/loadexternalfonts/) для загрузки шрифтов из этих папок.
3. Загрузите и отрендерите/экспортируйте презентацию.
4. Вызовите [FontsLoader.clearCache](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsloader/clearcache/) для очистки кеша шрифтов.

Ниже приведён пример кода, демонстрирующий процесс загрузки шрифтов:

```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Определите папки, содержащие пользовательские файлы шрифтов.
String externalFontFolder = u"assets/fonts";
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

{{% alert color="info" title="Note" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsloader/loadexternalfonts/) добавляет дополнительные папки в пути поиска шрифтов, но не изменяет порядок инициализации шрифтов.
Шрифты инициализируются в следующем порядке:

1. Путь к шрифтам по умолчанию операционной системы.
1. Пути, загруженные через [FontsLoader](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsloader/).
{{%/alert %}}

## **Получение пользовательских папок шрифтов**

Aspose.Slides предоставляет [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsloader/getfontfolders/) чтобы позволить вам находить папки шрифтов. Этот метод возвращает папки, добавленные через метод `LoadExternalFonts`, и системные папки шрифтов.

Ниже приведён код C++, показывающий, как использовать метод [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsloader/getfontfolders/):

``` cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// Эта строка выводит папки, проверяемые на наличие файлов шрифтов.
// Это папки, добавленные через метод LoadExternalFonts, и системные папки шрифтов.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Указание пользовательских шрифтов, используемых в презентации**

Aspose.Slides предоставляет свойство [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) чтобы позволить вам указать внешние шрифты, которые будут использоваться с презентацией.

Ниже приведён код C++, показывающий, как использовать свойство [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/):

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
    //работа с презентацией
    //CustomFont1, CustomFont2, а также шрифты из папок assets\fonts & global\fonts и их подпапок доступны для презентации
}
```

## **Внешнее управление шрифтами**

Aspose.Slides предоставляет метод [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsloader/loadexternalfont/) чтобы позволить вам загрузить внешние шрифты в массив байтов.

Ниже показан код C++, демонстрирующий процесс загрузки шрифтов в массив байтов:

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

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

### Влияют ли пользовательские шрифты на экспорт во все форматы (PDF, PNG, SVG, HTML)?

Да. Подключённые шрифты используются рендерером во всех форматах экспорта.

### Встраиваются ли пользовательские шрифты автоматически в получающийся PPTX?

Нет. Регистрация шрифта для рендеринга не равна его встраиванию в PPTX. Если требуется, чтобы шрифт находился внутри файла презентации, необходимо использовать явные [возможности встраивания](/slides/ru/cpp/embedded-font/).

### Могу ли я контролировать поведение fallback, когда у пользовательского шрифта отсутствуют некоторые глифы?

Да. Настройте [замену шрифтов](/slides/ru/cpp/font-substitution/), [правила замены](/slides/ru/cpp/font-replacement/) и [наборы fallback](/slides/ru/cpp/fallback-font/), чтобы точно определить, какой шрифт будет использован, если запрашиваемый глиф отсутствует.

### Могу ли я использовать шрифты в контейнерах Linux/Docker без их установки в системе?

Да. Укажите свои собственные папки со шрифтами или загружайте шрифты из массивов байтов. Это устраняет зависимость от системных каталогов шрифтов в образе контейнера.

### Как обстоят дела с лицензированием — можно ли встраивать любой пользовательский шрифт без ограничений?

Вы несёте ответственность за соблюдение лицензий шрифтов. Условия различаются; некоторые лицензии запрещают встраивание или коммерческое использование. Всегда проверяйте EULA шрифта перед распространением результатов.