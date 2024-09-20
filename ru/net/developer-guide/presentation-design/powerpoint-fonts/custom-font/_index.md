---
title: Пользовательский шрифт PowerPoint в C#
linktitle: Пользовательский шрифт
type: docs
weight: 20
url: /net/custom-font/
keywords: "Шрифты, пользовательские шрифты, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Пользовательские шрифты PowerPoint в C#"
---

{{% alert color="primary" %}} 

Aspose Slides позволяет загружать эти шрифты с помощью метода [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/):

* Шрифты TrueType (.ttf) и коллекции TrueType (.ttc). См. [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Шрифты OpenType (.otf). См. [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Загрузка пользовательских шрифтов**

Aspose.Slides позволяет загружать шрифты, которые отображаются в презентациях без необходимости их установки. Шрифты загружаются из пользовательского каталога.

1. Создайте экземпляр класса [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) и вызовите метод [LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/).
2. Загрузите презентацию, которая будет отображаться.
3. Очистите кэш в классе [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/).

Этот код C# демонстрирует процесс загрузки шрифтов:

```csharp
// Путь к каталогу документов
string dataDir = "C:\\";

// папки для поиска шрифтов
String[] folders = new String[] { dataDir };

// Загружает шрифты из пользовательского каталога
FontsLoader.LoadExternalFonts(folders);

// Выполняет некоторые действия и производит рендеринг презентации/слайдов
using (Presentation presentation = new Presentation(dataDir + "DefaultFonts.pptx"))
    presentation.Save(dataDir + "NewFonts_out.pptx", SaveFormat.Pptx);

// Очищает кэш шрифтов
FontsLoader.ClearCache();
```

## **Получить папку пользовательских шрифтов**
Aspose.Slides предоставляет метод [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/), который позволяет находить папки шрифтов. Этот метод возвращает папки, добавленные через метод `LoadExternalFonts`, и системные папки шрифтов.

Этот код C# показывает, как использовать [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/):

```c#
// Эта строка выводит папки, которые проверяются на наличие файлов шрифтов.
// Это папки, добавленные через метод LoadExternalFonts и системные папки шрифтов.
string[] fontFolders = FontsLoader.GetFontFolders();
```


## **Указать пользовательские шрифты, используемые с презентацией**
Aspose.Slides предоставляет свойство [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/), которое позволяет указать внешние шрифты, которые будут использоваться с презентацией.

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
    // CustomFont1, CustomFont2 и шрифты из папок assets\fonts и global\fonts, а также их подпапок доступны для презентации
}
```

## **Управление шрифтами извне**

Aspose.Slides предоставляет метод [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data), который позволяет загружать внешние шрифты из двоичных данных.

Этот код C# демонстрирует процесс загрузки шрифтов из массива байтов: 

```c#
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // внешний шрифт загружен в течение времени жизни презентации
    }
}
finally
{
    FontsLoader.ClearCache();
}
```