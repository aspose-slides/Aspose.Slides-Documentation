---
title: Пользовательский шрифт PowerPoint в C#
linktitle: Пользовательский шрифт
type: docs
weight: 20
url: /ru/net/custom-font/
keywords: "Шрифты, пользовательские шрифты, презентация PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Пользовательские шрифты PowerPoint в C#"
---

{{% alert color="primary" %}} 

Aspose Slides позволяет загружать эти шрифты с помощью метода [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) и TrueType Collection (.ttc) шрифты. См. [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) шрифты. См. [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Загрузка пользовательских шрифтов**

Aspose.Slides позволяет загружать шрифты, которые рендерятся в презентациях, без необходимости их установки. Шрифты загружаются из пользовательского каталога. 

1. Создайте экземпляр класса [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) и вызовите метод [LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/).
2. Загрузите презентацию, которую нужно отобразить.
3. Очистите кэш в классе [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/).

Этот код C# демонстрирует процесс загрузки шрифтов:
``` csharp
// Путь к каталогу документов
string dataDir = "C:\\";

// папки для поиска шрифтов
String[] folders = new String[] { dataDir };

// Загружает шрифты из пользовательского каталога шрифтов
FontsLoader.LoadExternalFonts(folders);

// Выполните некоторые операции и отрисуйте презентацию/слайды
using (Presentation presentation = new Presentation(dataDir + "DefaultFonts.pptx"))
    presentation.Save(dataDir + "NewFonts_out.pptx", SaveFormat.Pptx);

// Очищает кэш шрифтов
FontsLoader.ClearCache();
```


## **Получить папку пользовательских шрифтов**

Aspose.Slides предоставляет метод [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/), позволяющий находить папки со шрифтами. Этот метод возвращает папки, добавленные через метод `LoadExternalFonts`, а также системные папки шрифтов.

Этот код C# показывает, как использовать [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/):
```c#
 // Эта строка выводит папки, которые проверяются на наличие файлов шрифтов.
 // Это папки, добавленные через метод LoadExternalFonts, и системные папки шрифтов.
string[] fontFolders = FontsLoader.GetFontFolders();
```


## **Указание пользовательских шрифтов, используемых в презентации**

Aspose.Slides предоставляет свойство [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/), позволяющее указать внешние шрифты, которые будут использоваться в презентации.

Этот код C# показывает, как использовать свойство [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/):
```c#
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


## **Управление шрифтами извне**

Aspose.Slides предоставляет метод [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data), позволяющий загружать внешние шрифты из бинарных данных.

Этот код C# демонстрирует процесс загрузки шрифтов из массива байтов: 
```c#
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // внешний шрифт загружен в течение жизни презентации
    }
}
finally
{
    FontsLoader.ClearCache();
}
```


## **FAQ**

**Влияют ли пользовательские шрифты на экспорт во все форматы (PDF, PNG, SVG, HTML)?**

Да. Подключенные шрифты используются рендерером во всех форматах экспорта.

**Автоматически ли пользовательские шрифты встраиваются в получающийся PPTX?**

Нет. Регистрация шрифта для рендеринга не то же самое, что его встраивание в PPTX. Если необходимо, чтобы шрифт находился внутри файла презентации, следует использовать явные [возможности встраивания](/slides/ru/net/embedded-font/).

**Могу ли я контролировать поведение при отсутствии некоторых глифов в пользовательском шрифте?**

Да. Настройте [замену шрифтов](/slides/ru/net/font-substitution/), [правила замены](/slides/ru/net/font-replacement/) и [наборы резервных шрифтов](/slides/ru/net/fallback-font/), чтобы точно указать, какой шрифт использовать, когда запрашиваемый глиф отсутствует.

**Могу ли я использовать шрифты в контейнерах Linux/Docker без их системной установки?**

Да. Укажите свои папки со шрифтами или загружайте шрифты из массивов байтов. Это устраняет любую зависимость от системных каталогов шрифтов в образе контейнера.

**Что касается лицензирования — можно ли встраивать любой пользовательский шрифт без ограничений?**

Вы несёте ответственность за соблюдение лицензий на шрифты. Условия различаются; некоторые лицензии запрещают встраивание или коммерческое использование. Всегда проверяйте EULA шрифта перед распространением результатов.