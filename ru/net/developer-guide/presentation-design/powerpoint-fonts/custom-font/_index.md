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
- загрузить шрифт
- управлять шрифтами
- папка шрифтов
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Настройте шрифты в слайдах PowerPoint с помощью Aspose.Slides для .NET, чтобы ваши презентации выглядели чётко и согласованно на любом устройстве."
---
## **Обзор**

Aspose.Slides позволяет использовать пользовательские шрифты в презентациях без их установки в операционной системе. Вы можете загружать шрифты из пользовательских папок, предоставлять шрифты для конкретной презентации через источники шрифтов уровня документа или загружать внешние шрифты непосредственно из бинарных данных.

Загруженные шрифты используются при рендеринге или экспорте презентации, например в PDF, изображениях и других поддерживаемых форматах. Это помогает сохранять согласованность вывода презентации в разных средах. В статье также объясняется, как просматривать папки шрифтов, используемые Aspose.Slides, и как очистить кэш шрифтов после работы с внешними шрифтами.

Регистрация пользовательских шрифтов для рендеринга отличается от встраивания шрифтов в файл PPTX. Если шрифт необходимо хранить внутри самой презентации, используйте функции встраивания шрифтов явно.

{{% alert color="info" %}} 

Aspose Slides позволяет загружать эти шрифты с помощью метода [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) и TrueType Collection (.ttc) шрифты. См. [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) шрифты. См. [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Загрузка пользовательских шрифтов**

Aspose.Slides позволяет загружать шрифты, используемые в презентации, без их установки в системе. Это влияет на вывод при экспорте — например в PDF, изображения и другие поддерживаемые форматы — поэтому полученные документы выглядят одинаково в разных средах. Шрифты загружаются из пользовательских каталогов.

1. Укажите одну или несколько папок, содержащих файлы шрифтов.  
2. Вызовите статический метод [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsloader/loadexternalfonts/), чтобы загрузить шрифты из этих папок.  
3. Загрузите и отрендерите/экспортируйте презентацию.  
4. Вызовите [FontsLoader.ClearCache](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsloader/clearcache/) для очистки кэша шрифтов.

Следующий пример кода демонстрирует процесс загрузки шрифтов:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Определите папки, содержащие пользовательские файлы шрифтов.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Загрузите пользовательские шрифты из указанных папок.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Отрендерите/экспортируйте презентацию (например, в PDF, изображения или другие форматы), используя загруженные шрифты.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Очистите кэш шрифтов после завершения работы.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Примечание" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsloader/loadexternalfonts/) добавляет дополнительные папки в пути поиска шрифтов, но не изменяет порядок инициализации шрифтов.  
Шрифты инициализируются в следующем порядке:

1. Путь шрифтов операционной системы по умолчанию.  
1. Путь, загруженный через [FontsLoader](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Получение пользовательских папок шрифтов**

Aspose.Slides предоставляет метод [GetFontFolders](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsloader/getfontfolders/), позволяющий находить папки шрифтов. Этот метод возвращает папки, добавленные через метод `LoadExternalFonts`, а также системные папки шрифтов.

Пример кода на C# показывает, как использовать [GetFontFolders](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsloader/getfontfolders/):

```c#
using Aspose.Slides;

// Эта строка выводит папки, проверяемые на наличие файлов шрифтов.
// Это папки, добавленные через метод LoadExternalFonts, и системные папки шрифтов.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Указание пользовательских шрифтов, используемых в презентации**

Aspose.Slides предоставляет свойство [DocumentLevelFontSources](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/documentlevelfontsources/), позволяющее задавать внешние шрифты, которые будут использоваться с презентацией.

Пример кода на C# показывает, как использовать свойство [DocumentLevelFontSources](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/documentlevelfontsources/):

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
    // CustomFont1, CustomFont2 и шрифты из папок assets\fonts и global\fonts, а также их подпапок доступны для презентации
}
```

## **Управление шрифтами извне**

Aspose.Slides предоставляет метод [LoadExternalFont](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data), позволяющий загружать внешние шрифты из бинарных данных.

Пример кода на C# демонстрирует процесс загрузки шрифта из массива байтов:

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // внешний шрифт загружен в период жизни презентации
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

Нет. Регистрация шрифта для рендеринга отличается от его встраивания в PPTX. Если требуется, чтобы шрифт находился внутри файла презентации, необходимо использовать явные [возможности встраивания](/slides/ru/net/embedded-font/).

**Можно ли контролировать поведение fallback, когда у пользовательского шрифта отсутствуют некоторые глифы?**

Да. Настраивайте [замену шрифтов](/slides/ru/net/font-substitution/), [правила замены](/slides/ru/net/font-replacement/) и [наборы fallback](/slides/ru/net/fallback-font/), чтобы точно определить, какой шрифт будет использоваться при отсутствии требуемого глифа.

**Можно ли использовать шрифты в контейнерах Linux/Docker без их системной установки?**

Да. Укажите свои собственные папки шрифтов или загружайте шрифты из массивов байтов. Это устраняет любую зависимость от системных каталогов шрифтов в образе контейнера.

> **Примечание для Linux/Docker**: При вызове `FontsLoader.LoadExternalFonts` убедитесь, что каждый элемент массива `directories` содержит непустой путь к существующей директории. Если переменная окружения, использующаяся для формирования пути к шрифту, неопределена или пуста, Aspose.Slides может попытаться интерпретировать пустое значение как полный путь, что приведёт к `System.ArgumentException`.

**Что насчёт лицензирования — можно ли встраивать любой пользовательский шрифт без ограничений?**

Вы отвечаете за соблюдение лицензий на шрифты. Условия различаются; некоторые лицензии запрещают встраивание или коммерческое использование. Всегда проверяйте EULA шрифта перед распространением полученных результатов.