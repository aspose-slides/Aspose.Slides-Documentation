---
title: "Настройка шрифтов PowerPoint в .NET"
linktitle: "Пользовательский шрифт"
type: docs
weight: 20
url: /ru/net/custom-font/
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
- .NET
- C#
- Aspose.Slides
description: "Настройте шрифты в слайдах PowerPoint с помощью Aspose.Slides для .NET, чтобы ваши презентации выглядели чётко и одинаково на любом устройстве."
---
## **Обзор**

Aspose.Slides позволяет использовать пользовательские шрифты в презентациях без их установки в операционной системе. Вы можете загружать шрифты из пользовательских папок, предоставлять шрифты для конкретной презентации через источники шрифтов уровня документа или загружать внешние шрифты напрямую из бинарных данных.

Загруженные шрифты используются при рендеринге или экспорте презентации, например в PDF, изображения и другие поддерживаемые форматы. Это помогает сохранять согласованность вывода презентации в разных средах. Статья также объясняет, как проверить папки шрифтов, используемые Aspose.Slides, и как очистить кэш шрифтов после работы с внешними шрифтами.

Регистрация пользовательских шрифтов для рендеринга отделена от встраивания шрифтов в файл PPTX. Если шрифт должен быть сохранён внутри самой презентации, используйте функции встраивания шрифтов явно.

Тема презентации может ссылаться на разные семейства шрифтов для отдельных систем письма. Эти сопоставления хранят имена шрифтов, но не устанавливают и не загружают файлы шрифтов. См. [Шрифты темы, специфичные для сценариев](/slides/ru/net/script-specific-font-mappings/), чтобы управлять сопоставлениями, и используйте параметры загрузки ниже, чтобы сделать указанные шрифты доступными для согласованного рендеринга.

{{% alert color="info" title="Note" %}}

Aspose Slides позволяет загружать эти шрифты, используя метод [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) и TrueType Collection (.ttc) шрифты. См. [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) шрифты. См. [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Загрузка пользовательских шрифтов**

Aspose.Slides позволяет загружать шрифты, используемые в презентации, без их установки в системе. Это влияет на вывод при экспорте — например PDF, изображения и другие поддерживаемые форматы — так что полученные документы выглядят одинаково в разных средах. Шрифты загружаются из пользовательских каталогов.

1. Укажите одну или несколько папок, содержащих файлы шрифтов.
2. Вызовите статический метод [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/), чтобы загрузить шрифты из этих папок.
3. Загрузите и отрендерите/экспортируйте презентацию.
4. Вызовите [FontsLoader.ClearCache](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/clearcache/), чтобы очистить кэш шрифтов.

Следующий пример кода демонстрирует процесс загрузки шрифтов:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Определите папки, содержащие пользовательские файлы шрифтов.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Загрузите пользовательские шрифты из указанных папок.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Выполните рендеринг/экспорт презентации (например, в PDF, изображения или другие форматы), используя загруженные шрифты.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Очистите кэш шрифтов после завершения работы.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) добавляет дополнительные папки в пути поиска шрифтов, но не меняет порядок инициализации шрифтов. Шрифты инициализируются в следующем порядке:

1. Путь к шрифтам по умолчанию операционной системы.
1. Пути, загруженные через [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Получение пользовательских папок шрифтов**

Aspose.Slides предоставляет метод [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/), позволяющий находить папки шрифтов. Этот метод возвращает папки, добавленные через метод `LoadExternalFonts`, и системные папки шрифтов.

Этот пример кода C# показывает, как использовать [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/):

```c#
using Aspose.Slides;

// Эта строка выводит папки, которые проверяются на наличие файлов шрифтов.
// Это папки, добавленные через метод LoadExternalFonts и системные папки шрифтов.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Указание пользовательских шрифтов, используемых в презентации**

Aspose.Slides предоставляет свойство [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/), позволяющее указывать внешние шрифты, которые будут использоваться в презентации.

Этот пример кода C# показывает, как использовать свойство [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/):

```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Работа с презентацией
    // CustomFont1, CustomFont2 и шрифты из папок assets\fonts & global\fonts и их подпапок доступны в презентации
}
```

## **Управление шрифтами извне**

Aspose.Slides предоставляет метод [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data), позволяющий загружать внешние шрифты из бинарных данных.

Этот пример кода C# демонстрирует процесс загрузки шрифта из массива байтов:

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // внешний шрифт, загруженный в течение жизненного цикла презентации
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

Чтобы позволить зарегистрированному шрифту иметь приоритет при экспорте без удаления встроенного шрифта, см. [Предпочтение зарегистрированных шрифтов встроенным](/slides/ru/net/font-selection-sequence/#prefer-registered-fonts-over-embedded-fonts) (.NET 26.11 или новее).

## **Вопросы и ответы**

**Влияют ли пользовательские шрифты на экспорт во все форматы (PDF, PNG, SVG, HTML)?**

Да. Подключенные шрифты используются рендерером во всех форматах экспорта.

**Встраиваются ли пользовательские шрифты автоматически в получающийся PPTX?**

Нет. Регистрация шрифта для рендеринга не то же самое, что его встраивание в PPTX. Если вам требуется, чтобы шрифт был включён в файл презентации, необходимо использовать явные [возможности встраивания](/slides/ru/net/embedded-font/).

**Могу ли я управлять поведением резервного шрифта, когда пользовательский шрифт не содержит определённых глифов?**

Да. Настройте [замена шрифтов](/slides/ru/net/font-substitution/), [правила замены](/slides/ru/net/font-replacement/) и [наборы резервных шрифтов](/slides/ru/net/fallback-font/), чтобы точно указать, какой шрифт использовать, когда запрашиваемый глиф отсутствует.

**Могу ли я использовать шрифты в контейнерах Linux/Docker без их установки на уровне системы?**

Да. Указывайте свои собственные папки шрифтов или загружайте шрифты из массивов байтов. Это устраняет любую зависимость от системных каталогов шрифтов в образе контейнера.

> **Примечание для Linux/Docker**: При вызове `FontsLoader.LoadExternalFonts` убедитесь, что каждый элемент массива `directories` содержит непустой путь к существующей папке. Если переменная среды, использующаяся для построения пути к шрифту, не определена или пуста, Aspose.Slides может попытаться интерпретировать пустое значение как полный путь, что приведёт к `System.ArgumentException`.

**Что насчёт лицензирования — могу ли я встраивать любой пользовательский шрифт без ограничений?**

Вы отвечаете за соблюдение лицензий на шрифты. Условия различаются; некоторые лицензии запрещают встраивание или коммерческое использование. Всегда проверяйте лицензионное соглашение (EULA) шрифта перед распространением результатов.