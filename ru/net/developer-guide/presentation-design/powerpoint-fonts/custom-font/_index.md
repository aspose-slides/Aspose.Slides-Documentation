---
title: Настройка шрифтов PowerPoint в .NET
linktitle: Пользовательский шрифт
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
description: "Настройте шрифты в слайдах PowerPoint с помощью Aspose.Slides для .NET, чтобы ваши презентации оставались чёткими и согласованными на любом устройстве."
---
## **Обзор**

Aspose.Slides позволяет использовать пользовательские шрифты в презентациях без их установки в операционной системе. Вы можете загружать шрифты из пользовательских папок, предоставлять шрифты для конкретной презентации через источники шрифтов уровня документа, либо загружать внешние шрифты напрямую из двоичных данных.

Загруженные шрифты используются при рендеринге или экспорте презентации, например в PDF, изображения и другие поддерживаемые форматы. Это помогает поддерживать единообразный вывод презентации в разных средах. В статье также объясняется, как проверить папки шрифтов, используемые Aspose.Slides, и как очистить кеш шрифтов после работы с внешними шрифтами.

Регистрация пользовательских шрифтов для рендеринга отличается от встраивания шрифтов в файл PPTX. Если шрифт должен быть сохранён внутри самой презентации, используйте функции встраивания шрифтов явно.

Тема презентации может ссылаться на разные семейства шрифтов для отдельных систем письма. Эти сопоставления хранят имена шрифтов, но не устанавливают и не загружают файлы шрифтов. См. [Script-Specific Theme Fonts](/slides/ru/net/script-specific-font-mappings/) для управления сопоставлениями и используйте параметры загрузки ниже, чтобы сделать указанные шрифты доступными для последовательного рендеринга.

{{% alert color="info" title="Примечание" %}}
Aspose Slides позволяет загружать эти шрифты с помощью метода [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) и TrueType Collection (.ttc) шрифты. См. [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) шрифты. См. [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Загрузка пользовательских шрифтов**

Aspose.Slides позволяет загружать шрифты, используемые в презентации, без их установки в системе. Это влияет на вывод при экспорте — например PDF, изображения и другие поддерживаемые форматы — так что полученные документы выглядят одинаково в разных средах. Шрифты загружаются из пользовательских каталогов.

1. Укажите одну или несколько папок, содержащих файлы шрифтов.
2. Вызовите статический метод [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsloader/loadexternalfonts/) для загрузки шрифтов из этих папок.
3. Загрузите и отрендерите/экспортируйте презентацию.
4. Вызовите [FontsLoader.ClearCache](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsloader/clearcache/) для очистки кеша шрифтов.

Ниже приведён пример кода, демонстрирующего процесс загрузки шрифтов:

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

// Очистите кеш шрифтов после завершения работы.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Примечание" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsloader/loadexternalfonts/) добавляет дополнительные папки в пути поиска шрифтов, но не меняет порядок инициализации шрифтов.
Шрифты инициализируются в следующем порядке:

1. Путь к шрифтам по умолчанию операционной системы.
1. Пути, загруженные через [FontsLoader](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsloader/).
{{%/alert %}}

## **Получить папки пользовательских шрифтов**
Aspose.Slides предоставляет метод [GetFontFolders](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsloader/getfontfolders/) для поиска папок шрифтов. Этот метод возвращает папки, добавленные через метод `LoadExternalFonts`, и системные папки шрифтов.

Этот C#‑код демонстрирует, как использовать [GetFontFolders](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsloader/getfontfolders/):

```c#
using Aspose.Slides;

// Эта строка выводит папки, которые проверяются на наличие файлов шрифтов.
// Это папки, добавленные через метод LoadExternalFonts, и системные папки шрифтов.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Указать пользовательские шрифты, используемые в презентации**
Aspose.Slides предоставляет свойство [DocumentLevelFontSources](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/documentlevelfontsources/) для указания внешних шрифтов, которые будут использоваться в презентации.

Этот C#‑код показывает, как использовать свойство [DocumentLevelFontSources](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/documentlevelfontsources/):

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
    // CustomFont1, CustomFont2 и шрифты из папок assets\fonts и global\fonts и их подпапок доступны презентации
}
```

## **Управление шрифтами внешне**

Aspose.Slides предоставляет метод [LoadExternalFont](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) для загрузки внешних шрифтов из бинарных данных.

Этот C#‑код демонстрирует процесс загрузки шрифта из массива байтов:

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // внешний шрифт, загруженный на протяжении жизни презентации
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **Часто задаваемые вопросы**

**Влияют ли пользовательские шрифты на экспорт во все форматы (PDF, PNG, SVG, HTML)?**

Да. Подключённые шрифты используются рендерером во всех форматах экспорта.

**Встраиваются ли пользовательские шрифты автоматически в получаемый PPTX?**

Нет. Регистрация шрифта для рендеринга не равна его встраиванию в PPTX. Если нужен шрифт внутри файла презентации, необходимо использовать явные [возможности встраивания](/slides/ru/net/embedded-font/).

**Можно ли управлять поведением fallback, когда пользовательскому шрифту не хватает некоторых глифов?**

Да. Настройте [замену шрифтов](/slides/ru/net/font-substitution/), [правила замены](/slides/ru/net/font-replacement/) и [наборы fallback](/slides/ru/net/fallback-font/), чтобы точно определить, какой шрифт использовать при отсутствии запрашиваемого глифа.

**Можно ли использовать шрифты в контейнерах Linux/Docker без их установки в системе?**

Да. Указывайте собственные папки шрифтов или загружайте шрифты из массивов байтов. Это устраняет любую зависимость от системных каталогов шрифтов в образе контейнера.

> **Примечание для Linux/Docker**: При вызове `FontsLoader.LoadExternalFonts` убедитесь, что каждый элемент массива `directories` содержит непустой путь к существующей папке. Если переменная окружения, использующаяся для построения пути к шрифту, не определена или пуста, Aspose.Slides может попытаться трактовать пустое значение как полный путь, что приведёт к `System.ArgumentException`.

**Что касается лицензирования — можно ли встраивать любой пользовательский шрифт без ограничений?**

Вы несёте ответственность за соблюдение лицензий шрифтов. Условия различаются; некоторые лицензии запрещают встраивание или коммерческое использование. Всегда проверяйте EULA шрифта перед распространением результатов.