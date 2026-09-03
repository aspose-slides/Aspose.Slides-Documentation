---
title: Встраивание шрифтов в презентации в .NET
linktitle: Встроенные шрифты
type: docs
weight: 40
url: /ru/net/embedded-font/
keywords:
- добавить шрифт
- встроить шрифт
- встраивание шрифтов
- получить встроенный шрифт
- добавить встроенный шрифт
- удалить встроенный шрифт
- сжать встроенный шрифт
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Управляйте встроенными шрифтами в PowerPoint с помощью Aspose.Slides для .NET. Используйте C# для добавления, получения, удаления и сжатия шрифтов, чтобы сохранять внешний вид текста и уменьшать размер файла."
---
## **Введение**

Встраивание шрифтов сохраняет данные шрифта внутри презентации PowerPoint. Когда средство просмотра поддерживает встроенные шрифты, оно может отображать текст с этими шрифтами, даже если они не установлены в целевой системе. Это помогает сохранить переносы строк, интервалы текста и макет слайда.

Aspose.Slides for .NET позволяет получать, добавлять и удалять встроенные шрифты через свойство [FontsManager](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/fontsmanager/) объекта [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/). Вы также можете уменьшить размер данных встроенного шрифта, удалив символы, которые презентация не использует.

Приведённые ниже примеры работают с файлами PPTX. Перед встраиванием шрифта убедитесь, что его данные доступны Aspose.Slides и лицензия позволяет встраивание.

## **Получение и удаление встроенных шрифтов**

Используйте [GetEmbeddedFonts](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsmanager/getembeddedfonts/) для получения списка шрифтов, хранящихся в презентации. Чтобы удалить один из них, передайте шрифт из этого списка в [RemoveEmbeddedFont](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsmanager/removeembeddedfont/), затем сохраните презентацию.

Следующий пример выводит список встроенных шрифтов в файле `EmbeddedFonts.pptx` и удаляет Calibri, если он присутствует:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("EmbeddedFonts.pptx");
var fontsManager = presentation.FontsManager;
var embeddedFonts = fontsManager.GetEmbeddedFonts();

foreach (var font in embeddedFonts)
{
    Console.WriteLine(font.FontName);
}

var fontToRemove = Array.Find(embeddedFonts, font => string.Equals(font.FontName, "Calibri", StringComparison.OrdinalIgnoreCase));
if (fontToRemove != null)
{
    fontsManager.RemoveEmbeddedFont(fontToRemove);
    presentation.Save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Calibri is not embedded. No output file was created.");
}
```

Удаление встроенного шрифта удаляет его сохранённые данные; это не меняет шрифт, назначенный тексту. Если шрифт установлен в целевой системе, текст всё равно может его использовать. В противном случае при рендеринге может потребоваться [font substitution](/slides/ru/net/font-substitution/), что может повлиять на разметку.

## **Проверка данных шрифта и прав на встраивание**

Используйте интерфейс [IFontsManager](https://reference.aspose.com/slides/ru/net/aspose.slides/ifontsmanager/) для проверки шрифтов перед их встраиванием. Вызовите [IFontsManager.GetFonts](https://reference.aspose.com/slides/ru/net/aspose.slides/ifontsmanager/getfonts/) для получения шрифтов, используемых в презентации. Для каждого шрифта передайте объект [IFontData](https://reference.aspose.com/slides/ru/net/aspose.slides/ifontdata/) и требуемое значение [FontStyleType](https://reference.aspose.com/slides/ru/net/aspose.slides/fontstyletype/) в [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/ru/net/aspose.slides/ifontsmanager/getfontbytes/). Метод возвращает бинарные данные для данного стиля шрифта или `null`, если запрошенный шрифт или стиль недоступны. Не передавайте результат `null` в [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/ru/net/aspose.slides/ifontsmanager/getfontembeddinglevel/), поскольку этот метод требует массив байтов.

[EmbeddingLevel](https://reference.aspose.com/slides/ru/net/aspose.slides/embeddinglevel/) — это перечисление‑флажки, описывающее ограничения встраивания, хранящиеся в шрифте:

- `Installable` — разрешает встраивание и постоянную установку на другой системе, в соответствии с лицензией шрифта.
- `Restricted` — запрещает встраивание, если не получено разрешение от юридического владельца шрифта, когда это единственный флаг разрешения использования.
- `PreviewPrint` — разрешает временное использование для просмотра и печати; документ, содержащий шрифт, должен быть только для чтения.
- `Editable` — разрешает временное использование и позволяет редактировать и сохранять документ.
- `NoSubsetting` — дополнительное ограничение, запрещающее встраивание только подмножества глифов. При наличии этого флага необходимо встраивать все символы.
- `BitmapOnly` — дополнительное ограничение, позволяющее встраивать только растровые варианты шрифта, но не контурные данные. Если у шрифта нет растровых вариантов, его нельзя встраивать.

Первые четыре значения описывают разрешение на использование, тогда как `NoSubsetting` и `BitmapOnly` могут комбинироваться с ними. Проверяйте модификаторы побитовыми операциями. Поскольку `Installable` имеет значение 0, не используйте `HasFlag` для его обнаружения; маскируйте биты разрешения и сравнивайте результат с `Installable`. Текущие шрифты должны устанавливать не более одного бита разрешения использования. Для совместимости со старыми шрифтами, которые могут установить несколько, вспомогательная функция ниже выбирает наименее ограничительное разрешение: `Editable`, затем `PreviewPrint`, затем `Restricted`.

Следующий пример проверяет обычные, полужирные, курсивные и полужирно‑курсивные данные для каждого шрифта, возвращённого `GetFonts`. Он пропускает недоступные стили, ограниченные шрифты, только‑растровые шрифты, шрифты, ограниченные предварительным просмотром и печатью (поскольку вывод остаётся редактируемым), а также уже встроенные шрифты. Если любой доступный стиль имеет `NoSubsetting`, для этой семейства шрифтов встраиваются все символы.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

static EmbeddingLevel GetUsagePermission(EmbeddingLevel level)
{
    const EmbeddingLevel permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel.Editable) != 0)
    {
        return EmbeddingLevel.Editable;
    }

    if ((permissions & EmbeddingLevel.PreviewPrint) != 0)
    {
        return EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & EmbeddingLevel.Restricted) != 0)
    {
        return EmbeddingLevel.Restricted;
    }

    return EmbeddingLevel.Installable;
}

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var fontStyles = new[]
{
    FontStyleType.Regular,
    FontStyleType.Bold,
    FontStyleType.Italic,
    FontStyleType.Bold | FontStyleType.Italic
};

var embeddedFontNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
foreach (var embeddedFont in fontsManager.GetEmbeddedFonts())
{
    embeddedFontNames.Add(embeddedFont.FontName);
}

var embeddingPlan = new List<(IFontData Font, EmbedFontCharacters Rule)>();
foreach (var font in fontsManager.GetFonts())
{
    if (embeddedFontNames.Contains(font.FontName))
    {
        Console.WriteLine($"{font.FontName}: already embedded.");
        continue;
    }

    var hasAvailableData = false;
    var allAvailableStylesCanBeEmbedded = true;
    var previewPrintOnly = false;
    var requiresFullFont = false;

    foreach (var fontStyle in fontStyles)
    {
        var fontBytes = fontsManager.GetFontBytes(font, fontStyle);
        if (fontBytes == null)
        {
            Console.WriteLine($"{font.FontName} ({fontStyle}): font data is unavailable.");
            continue;
        }

        hasAvailableData = true;
        var embeddingLevel = fontsManager.GetFontEmbeddingLevel(fontBytes, font.FontName);
        var usagePermission = GetUsagePermission(embeddingLevel);
        var noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
        var bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

        Console.WriteLine($"{font.FontName} ({fontStyle}): {embeddingLevel}.");
    }

    if (!hasAvailableData)
    {
        Console.WriteLine($"{font.FontName}: skipped because no requested style is available.");
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console.WriteLine($"{font.FontName}: skipped because at least one available style does not permit outline embedding.");
    }
    else if (previewPrintOnly)
    {
        Console.WriteLine($"{font.FontName}: skipped because this example produces an editable presentation.");
    }
    else
    {
        var rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
        embeddingPlan.Add((font, rule));
    }
}

foreach (var item in embeddingPlan)
{
    fontsManager.AddEmbeddedFont(item.Font, item.Rule);
}

presentation.Save("WithAuditedFonts.pptx", SaveFormat.Pptx);
```

Эта проверка сообщает о ограничениях, закодированных в каждом файле шрифта. Она не предоставляет лицензии, не доказывает, что вы получили шрифт легально, и не заменяет проверку лицензионного соглашения шрифта перед распространением встроенной копии.

## **Добавление встроенных шрифтов**

Используйте [AddEmbeddedFont](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsmanager/addembeddedfont/) для встраивания шрифта. Его перегрузки принимают либо объект [IFontData](https://reference.aspose.com/slides/ru/net/aspose.slides/ifontdata/), либо массив байтов, содержащий данные шрифта. Перечисление [EmbedFontCharacters](https://reference.aspose.com/slides/ru/net/aspose.slides.export/embedfontcharacters/) управляет тем, какие символы включаются:

- [All](https://reference.aspose.com/slides/ru/net/aspose.slides.export/embedfontcharacters/) — встраивает все символы шрифта. Используйте эту опцию, когда получатели должны иметь возможность редактировать презентацию и вводить новый текст.
- [OnlyUsed](https://reference.aspose.com/slides/ru/net/aspose.slides.export/embedfontcharacters/) — встраивает только используемые в презентации символы для уменьшения размера файла. Выбирайте эту опцию для готовой презентации, предназначенной в основном для просмотра.

Следующий пример использует [GetFonts](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsmanager/getfonts/) для получения шрифтов, применённых в `Fonts.pptx`, и встраивает те, которые ещё не встроены. Шрифты для добавления должны быть доступны на машине, где выполняется код. Существующие встроенные шрифты сохраняют свои текущие наборы символов.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var allFonts = fontsManager.GetFonts();
var embeddedFonts = fontsManager.GetEmbeddedFonts();
var embeddedFontNames = embeddedFonts.Select(font => font.FontName);
var embeddedNames = new HashSet<string>(embeddedFontNames, StringComparer.OrdinalIgnoreCase);

foreach (var font in allFonts)
{
    if (!embeddedNames.Contains(font.FontName))
    {
        fontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
        embeddedNames.Add(font.FontName);
    }
}

presentation.Save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
```

## **Сжатие встроенных шрифтов**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/compress/compressembeddedfonts/) уменьшает данные встроенного шрифта, удаляя неиспользуемые символы. Он работает с уже встроенными шрифтами, поэтому степень экономии зависит от количества неиспользуемых данных шрифта в презентации.

Следующий пример сжимает шрифты в файле `EmbeddedFonts.pptx` и сохраняет результат в отдельный файл:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

Сохраняйте оригинальный файл, если получатели могут позже добавить текст. Символы, удалённые в процессе сжатия, более недоступны из встроенного шрифта, даже если изначально были встроены все символы.

## **FAQ**

**Как проверить, будет ли встроенный шрифт всё ещё заменяться при рендеринге?**

Вызовите [GetSubstitutions](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsmanager/getsubstitutions/) в окружении, где вы рендерите презентацию, чтобы увидеть, какие шрифты Aspose.Slides заменит. Также проверьте настройки [font substitution](/slides/ru/net/font-substitution/) и правила [font fallback](/slides/ru/net/fallback-font/). Механизм fallback обрабатывает отсутствующие символы, поэтому встраивание шрифта не решает проблему символов, которых нет в самом шрифте.

**Стоит ли встраивать распространённые шрифты, такие как Arial и Calibri?**

Решение следует принимать, ориентируясь на целевую среду. Если необходимые шрифты доступны на каждом устройстве, открывающем или рендерящем презентацию, их встраивание может лишь увеличить размер файла без пользы. Если у получателей или серверов могут отсутствовать эти шрифты, их встраивание поможет сохранить задуманное оформление, при условии, что лицензии позволяют такое встраивание.