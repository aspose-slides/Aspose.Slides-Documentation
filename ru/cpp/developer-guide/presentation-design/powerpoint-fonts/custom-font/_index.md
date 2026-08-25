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
description: "Настройте шрифты в слайдах PowerPoint с помощью Aspose.Slides для C++, чтобы ваши презентации были четкими и одинаковыми на любых устройствах."
---
## **Обзор**

Aspose.Slides позволяет использовать пользовательские шрифты в презентациях без их установки в операционной системе. Вы можете загружать шрифты из пользовательских папок, предоставлять шрифты для конкретной презентации через источники шрифтов уровня документа или загружать внешние шрифты напрямую из двоичных данных.

Загруженные шрифты используются при рендеринге или экспорте презентации, например в PDF, изображения и другие поддерживаемые форматы. Это помогает сохранять вывод презентации одинаковым в разных средах. Статья также объясняет, как просматривать папки шрифтов, используемые Aspose.Slides, и как очищать кэш шрифтов после работы с внешними шрифтами.

Регистрация пользовательских шрифтов для рендеринга отличается от встраивания шрифтов в файл PPTX. Если шрифт необходимо хранить внутри самой презентации, используйте функции встраивания шрифтов явно.

Тема презентации может ссылаться на разные семейства шрифтов для отдельных систем написания. Эти сопоставления сохраняют имена шрифтов, но не устанавливают и не загружают файлы шрифтов. См. [Script-Specific Theme Fonts](/slides/ru/cpp/script-specific-font-mappings/) для управления сопоставлениями и используйте параметры загрузки ниже, чтобы сделать указанные шрифты доступными для согласованного рендеринга.

{{% alert color="info" title="Note" %}}
Aspose Slides позволяет загружать эти шрифты с помощью [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) и TrueType Collection (.ttc). Смотрите [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf). Смотрите [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Загрузка пользовательских шрифтов**

Aspose.Slides позволяет загружать шрифты, используемые в презентации, без их установки в системе. Это влияет на вывод при экспорте — например PDF, изображения и другие поддерживаемые форматы — так что получаемые документы выглядят одинаково в разных средах. Шрифты загружаются из пользовательских каталогов.

1. Укажите одну или несколько папок, содержащих файлы шрифтов.  
2. Вызовите статический метод [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsloader/loadexternalfonts/) для загрузки шрифтов из этих папок.  
3. Загрузите и отрендерите/экспортируйте презентацию.  
4. Вызовите [FontsLoader.clearCache](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsloader/clearcache/) для очистки кэша шрифтов.

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

// Отрендерите/экспортируйте презентацию (например, в PDF, изображения или другие форматы), используя загруженные шрифты.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Очистите кэш шрифтов после завершения работы.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsloader/loadexternalfonts/) добавляет дополнительные папки в пути поиска шрифтов, но не меняет порядок инициализации шрифтов.  
Шрифты инициализируются в следующем порядке:

1. Путь к шрифтам по умолчанию операционной системы.  
1. Пути, загруженные через [FontsLoader](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsloader/).
{{%/alert %}}

## **Получение пользовательских папок шрифтов**
Aspose.Slides предоставляет [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsloader/getfontfolders/) для поиска папок шрифтов. Этот метод возвращает папки, добавленные через метод `LoadExternalFonts`, а также системные папки шрифтов.

Следующий пример кода на C++ показывает, как использовать метод [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsloader/getfontfolders/):

``` cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// Эта строка выводит папки, которые проверяются на наличие файлов шрифтов.
// Это папки, добавленные через метод LoadExternalFonts, и системные папки шрифтов.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Указание пользовательских шрифтов для презентации**
Aspose.Slides предоставляет свойство [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) для указания внешних шрифтов, которые будут использоваться с презентацией.

Этот пример кода на C++ показывает, как использовать свойство [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/):

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
    //работайте с презентацией
    //CustomFont1, CustomFont2, а также шрифты из папок assets\fonts & global\fonts и их подпапок доступны презентации
}
```

## **Управление шрифтами извне**
Aspose.Slides предоставляет метод [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsloader/loadexternalfont/) для загрузки внешних шрифтов в массив байтов.

Пример кода на C++ демонстрирует процесс загрузки шрифта в массив байтов:

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

## **FAQ**

### Влияют ли пользовательские шрифты на экспорт во все форматы (PDF, PNG, SVG, HTML)?

Да. Подключённые шрифты используются рендерером во всех форматах экспорта.

### Автоматически ли пользовательские шрифты встраиваются в полученный PPTX?

Нет. Регистрация шрифта для рендеринга не равна его встраиванию в PPTX. Если шрифт должен быть включён в файл презентации, необходимо использовать явные [функции встраивания](/slides/ru/cpp/embedded-font/).

### Можно ли управлять поведением fallback, когда у пользовательского шрифта нет определённых глифов?

Да. Настройте [замену шрифтов](/slides/ru/cpp/font-substitution/), [правила замены](/slides/ru/cpp/font-replacement/) и [наборы fallback](/slides/ru/cpp/fallback-font/), чтобы точно определить, какой шрифт использовать при отсутствии запрошенного глифа.

### Можно ли использовать шрифты в контейнерах Linux/Docker без их системной установки?

Да. Указывайте свои папки шрифтов или загружайте шрифты из массивов байтов. Это устраняет зависимость от системных каталогов шрифтов в образе контейнера.

### Что насчёт лицензирования — могу ли я встраивать любой пользовательский шрифт без ограничений?

Вы отвечаете за соблюдение лицензий на шрифты. Условия различаются; некоторые лицензии запрещают встраивание или коммерческое использование. Всегда проверяйте EULA шрифта перед распространением результатов.