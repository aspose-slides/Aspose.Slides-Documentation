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
description: "Настройте шрифты в слайдах PowerPoint с помощью Aspose.Slides для .NET, чтобы ваши презентации были четкими и единообразными на любом устройстве."
---

{{% alert color="primary" %}} 

Aspose Slides позволяет загружать эти шрифты с помощью метода [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) :

* Шрифты TrueType (.ttf) и TrueType Collection (.ttc). См. [TrueType](https://en.wikipedia.org/wiki/TrueType).
* Шрифты OpenType (.otf). См. [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Загрузка пользовательских шрифтов**

Aspose.Slides позволяет загружать шрифты, используемые в презентации, без их установки в системе. Это влияет на вывод при экспорте — например PDF, изображения и другие поддерживаемые форматы — поэтому получаемые документы выглядят одинаково в разных средах. Шрифты загружаются из пользовательских каталогов.

1. Укажите одну или несколько папок, содержащих файлы шрифтов.  
2. Вызовите статический метод [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) для загрузки шрифтов из указанных папок.  
3. Загрузите и отрендерите/экспортируйте презентацию.  
4. Вызовите [FontsLoader.ClearCache](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/clearcache/) для очистки кэша шрифтов.

Ниже приведён пример кода, демонстрирующий процесс загрузки шрифтов:
```cs
// Определите папки, содержащие пользовательские файлы шрифтов.
string[] fontFolders = { externalFontFolder1, externalFontFolder2 };

// Загрузите пользовательские шрифты из указанных папок.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Отрендерите/экспортируйте презентацию (например, в PDF, изображения или другие форматы), используя загруженные шрифты.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Очистите кэш шрифтов после завершения работы.
FontsLoader.ClearCache();
```


{{% alert color="info" title="Note" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) добавляет дополнительные папки в пути поиска шрифтов, но не меняет порядок инициализации шрифтов. Шрифты инициализируются в следующем порядке:

1. Путь к шрифтам операционной системы по умолчанию.  
1. Пути, загруженные через [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Получить пользовательские папки шрифтов**
Aspose.Slides предоставляет метод [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) для поиска папок шрифтов. Этот метод возвращает папки, добавленные через метод `LoadExternalFonts`, а также системные папки шрифтов.

Пример кода на C# показывает, как использовать [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/):
```c#
// Эта строка выводит папки, которые проверяются на наличие файлов шрифтов.
// Это папки, добавленные через метод LoadExternalFonts и системные папки шрифтов.
string[] fontFolders = FontsLoader.GetFontFolders();
```


## **Указать пользовательские шрифты, используемые в презентации**
Aspose.Slides предоставляет свойство [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) для указания внешних шрифтов, которые будут использованы в презентации.

Пример кода на C# показывает, как использовать свойство [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/):
```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Работа с презентацией
    // CustomFont1, CustomFont2 и шрифты из папок assets\fonts & global\fonts и их подпапок доступны презентации
}
```


## **Управление шрифтами внешне**

Aspose.Slides предоставляет метод [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) для загрузки внешних шрифтов из бинарных данных.

Пример кода на C# демонстрирует процесс загрузки шрифта из массива байтов: 
```c#
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // внешний шрифт загружен на время жизни презентации
    }
}
finally
{
    FontsLoader.ClearCache();
}
```


## **Вопросы и ответы**

**Влияют ли пользовательские шрифты на экспорт во все форматы (PDF, PNG, SVG, HTML)?**

Да. Подключённые шрифты используются рендерером во всех форматах экспорта.

**Встраиваются ли пользовательские шрифты автоматически в полученный PPTX?**

Нет. Регистрация шрифта для рендеринга не равна его встраиванию в PPTX. Если нужен шрифт внутри файла презентации, используйте явные возможности [встраивания](/slides/ru/net/embedded-font/).

**Можно ли управлять поведением fallback, если у пользовательского шрифта отсутствуют некоторые глифы?**

Да. Настройте [замену шрифтов](/slides/ru/net/font-substitution/), [правила замены](/slides/ru/net/font-replacement/) и [наборы fallback](/slides/ru/net/fallback-font/) для точного указания шрифта, который будет использован при отсутствии запрашиваемого глифа.

**Можно ли использовать шрифты в контейнерах Linux/Docker без их системной установки?**

Да. Указывайте свои папки со шрифтами или загружайте шрифты из массивов байтов. Это убирает любую зависимость от системных каталогов шрифтов в образе контейнера.

**Что насчёт лицензирования — могу ли я встраивать любые пользовательские шрифты без ограничений?**

Вы отвечаете за соблюдение лицензий шрифтов. Условия различаются; некоторые лицензии запрещают встраивание или коммерческое использование. Всегда проверяйте EULA шрифта перед распространением результатов.