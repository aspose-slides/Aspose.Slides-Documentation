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
description: "Настраивайте шрифты в слайдах PowerPoint с помощью Aspose.Slides для .NET, чтобы ваши презентации оставались четкими и согласованными на любом устройстве."
---

{{% alert color="primary" %}} 

Aspose Slides позволяет загружать эти шрифты с помощью метода [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/):

* Шрифты TrueType (.ttf) и коллекции TrueType (.ttc). См. [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Шрифты OpenType (.otf). См. [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Load Custom Fonts**

Aspose.Slides позволяет загружать шрифты, которые используются при рендеринге презентаций, без их установки в системе. Шрифты загружаются из пользовательского каталога. 

1. Создайте экземпляр класса [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) и вызовите метод [LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/).
2. Загрузите презентацию, которую необходимо отрисовать.
3. Очистите кэш в классе [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/).

Этот C#‑код демонстрирует процесс загрузки шрифтов:
``` csharp
// Путь к каталогу документов
string dataDir = "C:\\";

// папки для поиска шрифтов
String[] folders = new String[] { dataDir };

// Загружает шрифты из пользовательского каталога шрифтов
FontsLoader.LoadExternalFonts(folders);

// Выполните некоторую работу и сделайте рендеринг презентации/слайда
using (Presentation presentation = new Presentation(dataDir + "DefaultFonts.pptx"))
    presentation.Save(dataDir + "NewFonts_out.pptx", SaveFormat.Pptx);

// Очищает кэш шрифтов
FontsLoader.ClearCache();
```


## **Get Custom Font Folders**
Aspose.Slides предоставляет метод [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/), позволяющий находить папки шрифтов. Метод возвращает папки, добавленные через метод `LoadExternalFonts`, а также системные папки шрифтов.

Этот C#‑код показывает, как использовать [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/):
```c#
 // Эта строка выводит папки, проверяемые на наличие файлов шрифтов.
 // Это папки, добавленные через метод LoadExternalFonts, а также системные папки шрифтов.
string[] fontFolders = FontsLoader.GetFontFolders();
```



## **Specify Custom Fonts Used with a Presentation**
Aspose.Slides предоставляет свойство [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/), позволяющее указать внешние шрифты, которые будут использованы в презентации.

Этот C#‑код показывает, как использовать свойство [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/):
```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Работа с презентацией
    // CustomFont1, CustomFont2 и шрифты из папок assets\fonts & global\fonts, а также их подпапок доступны для презентации
}
```


## **Manage Fonts Externally**

Aspose.Slides предоставляет метод [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data), позволяющий загружать внешние шрифты из бинарных данных.

Этот C#‑код демонстрирует процесс загрузки шрифтов из массива байтов: 
```c#
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // внешний шрифт, загруженный на время жизни презентации
    }
}
finally
{
    FontsLoader.ClearCache();
}
```


## **FAQ**

**Влияют ли пользовательские шрифты на экспорт во все форматы (PDF, PNG, SVG, HTML)?**

Да. Подключённые шрифты используются рендерером во всех форматах экспорта.

**Встраиваются ли пользовательские шрифты автоматически в полученный файл PPTX?**

Нет. Регистрация шрифта для рендеринга не равна его встраиванию в PPTX. Если нужен шрифт внутри файла презентации, необходимо использовать явные [встроенные функции](/slides/ru/net/embedded-font/).

**Можно ли контролировать поведение fallback, когда у пользовательского шрифта отсутствуют отдельные глифы?**

Да. Настройте [font substitution](/slides/ru/net/font-substitution/), [replacement rules](/slides/ru/net/font-replacement/) и [fallback sets](/slides/ru/net/fallback-font/), чтобы точно определить, какой шрифт использовать при отсутствии требуемого глифа.

**Можно ли использовать шрифты в контейнерах Linux/Docker без их системной установки?**

Да. Указывайте свои каталоги шрифтов или загружайте шрифты из массивов байтов. Это устраняет зависимость от системных каталогов шрифтов в образе контейнера.

**Что касается лицензирования — можно ли встраивать любой пользовательский шрифт без ограничений?**

Вы несёте ответственность за соблюдение лицензий шрифтов. Условия различаются; некоторые лицензии запрещают встраивание или коммерческое использование. Всегда проверяйте EULA шрифта перед распространением результатов.