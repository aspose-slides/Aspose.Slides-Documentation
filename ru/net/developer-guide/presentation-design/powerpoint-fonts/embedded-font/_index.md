---
title: Встраивание шрифтов в презентации на .NET
linktitle: Встроенные шрифты
type: docs
weight: 40
url: /ru/net/embedded-font/
keywords:
- добавить шрифт
- встроить шрифт
- встраивание шрифта
- получить встроенный шрифт
- добавить встроенный шрифт
- удалить встроенный шрифт
- сжать встроенный шрифт
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Управляйте встроенными шрифтами в PowerPoint с помощью Aspose.Slides для .NET. Используйте C# для добавления, получения, удаления и сжатия шрифтов, чтобы сохранить внешний вид текста и уменьшить размер файла."
---
## **Введение**

Встраивание шрифтов сохраняет данные шрифта внутри презентации PowerPoint. Когда средство просмотра поддерживает встроенные шрифты, оно может отображать текст с использованием этих шрифтов, даже если они не установлены в целевой системе. Это помогает сохранять разрывы строк, интервал текста и макет слайда.

Aspose.Slides for .NET позволяет получать, добавлять и удалять встроенные шрифты через свойство [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) объекта [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Вы также можете уменьшить размер данных встроенного шрифта, удалив символы, которые не используются в презентации.

Приведённые ниже примеры работают с файлами PPTX. Перед встраиванием шрифта убедитесь, что его данные доступны Aspose.Slides и его лицензия позволяет встраивание.

## **Получение и удаление встроенных шрифтов**

Используйте [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) для получения списка шрифтов, хранящихся в презентации. Чтобы удалить один из них, передайте шрифт из этого списка в [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont/), затем сохраните презентацию.

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

Удаление встроенного шрифта удаляет его сохранённые данные шрифта; это не меняет шрифт, назначенный тексту. Если шрифт установлен в целевой системе, текст всё равно может его использовать. В противном случае при рендеринге может потребоваться [замена шрифтов](/slides/ru/net/font-substitution/), что может повлиять на макет.

## **Проверка данных шрифта и прав встраивания**

Используйте интерфейс [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) для проверки шрифтов перед их встраиванием. Вызовите [IFontsManager.GetFonts](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfonts/) для получения шрифтов, используемых в презентации. Для каждого шрифта передайте объект [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/) и требуемое значение [FontStyleType](https://reference.aspose.com/slides/net/aspose.slides/fontstyletype/) в [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontbytes/). Метод возвращает бинарные данные для данного стиля шрифта или `null`, если запрошенный шрифт или стиль недоступны. Не передавайте результат `null` в [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontembeddinglevel/), так как этот метод требует массив байтов.

[EmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/embeddinglevel/) — это перечисление флагов, которое сообщает о ограничениях встраивания, хранящихся в шрифте:

- `Installable` позволяет встраивание и постоянную установку на другой системе, при условии соблюдения лицензии шрифта.
- `Restricted` запрещает встраивание, если только не получено разрешение от законного владельца шрифта, когда это единственный флаг разрешения использования.
- `PreviewPrint` разрешает временное использование для просмотра и печати; документ, содержащий шрифт, должен быть только для чтения.
- `Editable` разрешает временное использование и позволяет редактировать и сохранять документ.
- `NoSubsetting` — дополнительное ограничение, запрещающее встраивание только подмножества глифов. При наличии этого флага встраиваются все символы.
- `BitmapOnly` — дополнительное ограничение, позволяющее встраивать только bitmap‑варианты шрифта, а не контурные данные. Если у шрифта нет bitmap‑вариантов, его нельзя встраивать.

Первые четыре значения описывают разрешения на использование, тогда как `NoSubsetting` и `BitmapOnly` могут комбинироваться с ними. Проверяйте модификаторы битовыми операциями. Поскольку `Installable` имеет значение ноль, не используйте `HasFlag` для его обнаружения; маскируйте биты разрешения на использование и сравнивайте результат с `Installable`. Текущие шрифты должны устанавливать не более одного бита разрешения на использование. Для совместимости со старыми шрифтами, которые задают более одного, вспомогательная функция ниже выбирает наименее ограничительное разрешение: `Editable`, затем `PreviewPrint`, затем `Restricted`.

Следующий пример проверяет обычные, полужирные, курсивные и полужирно‑курсивные данные, доступные для каждого шрифта, возвращённого `GetFonts`. Он пропускает недоступные стили, ограниченные шрифты, шрифты только bitmap, шрифты, ограниченные просмотром и печатью, поскольку вывод остаётся редактируемым, а также шрифты, которые уже встроены. Если любой доступный стиль имеет `NoSubsetting`, встраиваются все символы для данного семейства шрифтов.
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

Эта проверка сообщает об ограничениях, закодированных в каждом файле шрифта. Она не предоставляет лицензии, не доказывает, что вы законно получили шрифт, и не заменяет проверку лицензионного соглашения шрифта перед распространением встроенной копии.

## **Добавление встроенных шрифтов**

Используйте [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/) для встраивания шрифта. Его перегрузки принимают либо объект [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/), либо массив байтов, содержащий данные шрифта. Перечисление [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) управляет тем, какие символы включаются:

- [All](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) встраивает все символы шрифта. Используйте этот вариант, когда получателям необходимо редактировать презентацию и вводить новый текст.
- [OnlyUsed](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) встраивает только те символы, которые использованы в презентации, для уменьшения размера файла. Выбирайте этот вариант для готовой презентации, предназначенной в основном для просмотра.

Следующий пример использует [GetFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) для получения шрифтов, используемых в `Fonts.pptx`, и встраивает те, которые ещё не встроены. Шрифты для добавления должны быть доступны на машине, где выполняется код. Существующие встроенные шрифты сохраняют текущие наборы символов.
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

[CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) уменьшает данные встроенных шрифтов, удаляя неиспользуемые символы. Он работает с уже встроенными шрифтами, поэтому степень уменьшения размера зависит от количества неиспользуемых данных шрифта в презентации.

Следующий пример сжимает шрифты в файле `EmbeddedFonts.pptx` и сохраняет результат в отдельный файл:
```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

Сохраняйте оригинальный файл, если получателям может понадобиться добавлять текст позже. Символы, удалённые при сжатии, больше не доступны из встроенного шрифта, даже если изначально встраивались все символы.

Чтобы позволить соответствующему зарегистрированному шрифту получить приоритет при экспорте без удаления встроенного шрифта, см. [Предпочитать зарегистрированные шрифты над встроенными шрифтами](/slides/ru/net/font-selection-sequence/#prefer-registered-fonts-over-embedded-fonts) (.NET 26.11 или новее).

## **Вопросы и ответы**

**Как я могу проверить, будет ли встроенный шрифт все еще заменяться при рендеринге?**

Вызовите [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) в среде, где вы рендерите презентацию, чтобы увидеть, какие шрифты Aspose.Slides заменит. Также проверьте настройки [замена шрифтов](/slides/ru/net/font-substitution/) и правила [резервный шрифт](/slides/ru/net/fallback-font/). Fallback обрабатывает отсутствующие символы, поэтому встраивание шрифта не решает проблему символов, которых сам шрифт не содержит.

**Стоит ли встраивать распространённые шрифты, такие как Arial и Calibri?**

Базируйте решение на целевой среде. Если необходимые шрифты доступны на каждом компьютере, открывающем или рендерящем презентацию, их встраивание может увеличить размер файла без надобности. Если у получателей или серверов могут отсутствовать эти шрифты, их встраивание может помочь сохранить ожидаемый внешний вид, при условии, что лицензии позволяют это.