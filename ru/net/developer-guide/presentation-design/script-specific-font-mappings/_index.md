---
title: Управление шрифтами темы, специфичными для скриптов, в .NET
linktitle: Шрифты темы, специфичные для скриптов
type: docs
weight: 15
url: /ru/net/script-specific-font-mappings/
keywords:
- шрифт, специфичный для скриптов
- сопоставление шрифтов темы
- многоязычная презентация
- система письма
- кириллический шрифт
- арабский шрифт
- японский шрифт
- грузинский шрифт
- шрифт Таана
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Просматривайте, добавляйте, заменяйте и удаляйте скрипт-специфичные сопоставления шрифтов в темах PowerPoint с помощью Aspose.Slides для .NET."
---
## **Обзор**

Тема презентации может выбирать разные семейства шрифтов для разных систем письма. Это позволяет многоязычному тексту, который всё ещё использует шрифты темы, следовать единой согласованной схеме шрифтов, используя подходящие шрифты для кириллицы, арабского, японского, грузинского, таана и других систем письма.

Тема содержит [IFontScheme](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/ifontscheme/) с основной коллекцией шрифтов, обычно используемой для заголовков, и вспомогательной коллекцией шрифтов, обычно используемой для основного текста. Помимо их латинских и восточноазиатских свойств шрифтов, обе коллекции предоставляют отображения от тегов системы письма к именам семейств шрифтов через интерфейс [IFonts](https://reference.aspose.com/slides/ru/net/aspose.slides/ifonts/).

В этой статье показано, как просматривать и изменять эти сопоставления в основной теме презентации и проверять, что изменения сохраняются после цикла сохранения‑и‑перезагрузки.

## **Понимание тегов скриптов**

Методы шрифтов скриптов используют четырёхсимвольные подтипы BCP 47 для идентификации систем письма. Распространённые значения включают:

| Тег скрипта | Система письма |
|---|---|
| `Cyrl` | Кириллица |
| `Arab` | Арабский |
| `Hans` | Упрощённый китайский |
| `Jpan` | Японский |
| `Geor` | Грузинский |
| `Thaa` | Таана |

Эти сопоставления относятся к схеме шрифтов темы, а не к отдельным фрагментам текста. Презентация может определять разные сопоставления для основной и вспомогательной коллекций, а также может опустить сопоставления для некоторых скриптов.

## **Доступ и просмотр сопоставлений шрифтов скриптов**

Используйте [Presentation.MasterTheme](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/mastertheme/) для доступа к теме уровня презентации. Свойства [FontScheme.Major](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/fontscheme/major/) и [FontScheme.Minor](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/fontscheme/minor/) возвращают две коллекции [IFonts](https://reference.aspose.com/slides/ru/net/aspose.slides/ifonts/).

Вызовите [IFonts.GetScriptFontMap](https://reference.aspose.com/slides/ru/net/aspose.slides/fonts/getscriptfontmap/) чтобы получить все сопоставления из коллекции. Чтобы найти одну систему письма, вызовите [IFonts.GetScriptFont](https://reference.aspose.com/slides/ru/net/aspose.slides/fonts/getscriptfont/) с её тегом скрипта. `GetScriptFont` возвращает `null`, если эта коллекция не определяет запрошенное сопоставление.

## **Изменение сопоставлений и проверка их сохранения**

Используйте [IFonts.SetScriptFont](https://reference.aspose.com/slides/ru/net/aspose.slides/fonts/setscriptfont/) чтобы создать сопоставление или заменить текущий шрифт. Используйте [IFonts.RemoveScriptFont](https://reference.aspose.com/slides/ru/net/aspose.slides/fonts/removescriptfont/) чтобы удалить сопоставление.

Следующий пример от начала до конца читает все существующие основные и вспомогательные сопоставления, ищет основной шрифт для японского, изменяет основной шрифт для кириллицы, удаляет вспомогательное сопоставление для таана, сохраняет презентацию и открывает её снова, чтобы проверить оба изменения. Чтобы сделать шаг удаления независимым от исходной темы, пример сначала создаёт сопоставление для таана только если оно ещё не определено.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

static void PrintScriptFontMap(string label, IFonts fonts)
{
    Console.WriteLine(label);
    foreach (var mapping in fonts.GetScriptFontMap())
    {
        Console.WriteLine($"  {mapping.Key}: {mapping.Value}");
    }
}

using var presentation = new Presentation();
var fontScheme = presentation.MasterTheme.FontScheme;
var majorFonts = fontScheme.Major;
var minorFonts = fontScheme.Minor;

PrintScriptFontMap("Existing major mappings:", majorFonts);
PrintScriptFontMap("Existing minor mappings:", minorFonts);

var japaneseFont = majorFonts.GetScriptFont("Jpan");
if (japaneseFont is null)
{
    Console.WriteLine("No major Japanese font is defined.");
}
else
{
    Console.WriteLine($"Major Japanese font: {japaneseFont}");
}

majorFonts.SetScriptFont("Cyrl", "Arial");

if (minorFonts.GetScriptFont("Thaa") is null)
{
    minorFonts.SetScriptFont("Thaa", "Arial");
}

minorFonts.RemoveScriptFont("Thaa");
presentation.Save("script-font-mappings.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("script-font-mappings.pptx");
var savedMajorFonts = savedPresentation.MasterTheme.FontScheme.Major;
var savedMinorFonts = savedPresentation.MasterTheme.FontScheme.Minor;
var savedCyrillicFont = savedMajorFonts.GetScriptFont("Cyrl");
var savedThaanaFont = savedMinorFonts.GetScriptFont("Thaa");

if (savedCyrillicFont == "Arial")
{
    Console.WriteLine("The Cyrillic mapping was preserved.");
}
else
{
    Console.WriteLine("The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont is null)
{
    Console.WriteLine("The Thaana mapping removal was preserved.");
}
else
{
    Console.WriteLine("The Thaana mapping still exists.");
}
```

Проверка использует то же поведение `null`, что и обычный поиск: после сохранения удаления `GetScriptFont("Thaa")` возвращает `null` для вспомогательной коллекции.

## **Различие сопоставлений темы от других настроек шрифтов**

Сопоставления темы, специфичные для скриптов, участвуют в выборе шрифта, но решают другую задачу, чем прямое форматирование текста, подстановка и резервный шрифт:

| Механизм | Назначение | Эффект изменения сопоставления темы |
|---|---|---|
| Сопоставление шрифта темы, специфичное для скрипта | Выбирает основной или вспомогательный шрифт темы для системы письма. | Текст, который продолжает использовать соответствующий шрифт темы, может перейти к новому сопоставленному семейству. |
| Шрифт, назначенный явно отдельному фрагменту текста | Фиксирует требуемое семейство шрифтов на этом фрагменте вместо использования темы. | Фрагмент может остаться без изменений, поскольку его прямое форматирование перекрывает выбор темы. |
| Подстановка шрифта | Заменяет запрашиваемый шрифт, когда он недоступен или применяется правило подстановки. | Она работает после запроса шрифта; не переопределяет скриптовое сопоставление темы. |
| Резервный шрифт | Предоставляет глифы, отсутствующие в выбранном шрифте, часто для определённых диапазонов Unicode. | Он заполняет недостающие глифы; не изменяет сохранённое сопоставление темы. |

Для получения дополнительной информации о последних двух механизмах см. [Подстановка шрифтов](/slides/ru/net/font-substitution/) и [Резервные шрифты](/slides/ru/net/fallback-font/).

Изменение сопоставления в [Presentation.MasterTheme](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/mastertheme/) влияет только на содержимое, чье эффективное форматирование всё ещё зависит от этой темы. Текст может наследовать переопределение темы от мастера, макета или слайда, либо использовать явно назначенный шрифт. Проверьте эти уровни, когда видимый результат не соответствует сопоставлению уровня презентации.

## **Обеспечение доступности сопоставленных шрифтов и проверка результата**

Сопоставление скрипта сохраняет только название семейства шрифтов; оно не устанавливает и не загружает соответствующий файл шрифта. Для согласованного рендеринга и экспорта каждый сопоставленный шрифт должен быть установлен в окружении или предоставлен Aspose.Slides через пользовательский источник, такой как [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsloader/loadexternalfonts/) или [LoadOptions.DocumentLevelFontSources](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/documentlevelfontsources/). См. [Custom Fonts](/slides/ru/net/custom-font/) для доступных вариантов загрузки.

Проверка сохранённого сопоставления подтверждает лишь, что определение темы было сохранено. Это не доказывает, что шрифт доступен, содержит все необходимые глифы или создаёт требуемую разметку. Сгенерируйте представительный текст для каждой необходимой системы письма в виде изображения или PDF и проверьте результат. Это позволяет обнаружить отсутствующие шрифты, неполный набор глифов, поведение резервных шрифтов и изменения разметки до распространения презентации. См. [Convert PowerPoint Presentations](/slides/ru/net/convert-powerpoint/) для примеров рендеринга и экспорта.

## **FAQ**

**Что возвращает `GetScriptFont`, когда скрипт не сопоставлен?**

[IFonts.GetScriptFont](https://reference.aspose.com/slides/ru/net/aspose.slides/fonts/getscriptfont/) возвращает `null`, когда запрошенное сопоставление скрипта не определено в этой основной или вспомогательной коллекции шрифтов.

**Добавляет ли `SetScriptFont` второе сопоставление, если скрипт уже существует?**

Нет. [IFonts.SetScriptFont](https://reference.aspose.com/slides/ru/net/aspose.slides/fonts/setscriptfont/) создаёт сопоставление, если его нет, и заменяет сопоставленное семейство шрифтов, когда тег скрипта уже присутствует.

**Почему изменение сопоставления темы не изменило некоторый текст?**

Текст может иметь явно назначенный шрифт, наследовать другую тему через переопределение или быть затронут подстановкой или резервным шрифтом во время рендеринга. Сопоставление скрипта на уровне презентации управляет только тем текстом, чье эффективное форматирование всё ещё ссылается на эту коллекцию шрифтов темы.

**Достаточно ли сохранить и открыть заново для проверки многоязычного вывода?**

Нет. Перезапуск проверяет сохранность данных темы. Кроме того, необходимо сгенерировать представительный текст для каждой требуемой системы письма, чтобы убедиться, что сопоставленные шрифты доступны и содержат необходимые глифы.