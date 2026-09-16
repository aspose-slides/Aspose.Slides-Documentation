---
title: Управление гиперссылками презентаций в .NET
linktitle: Управление гиперссылками
type: docs
weight: 20
url: /ru/net/manage-hyperlinks/
keywords:
- добавить URL
- добавить гиперссылку
- создать гиперссылку
- форматировать гиперссылку
- удалить гиперссылку
- обновить гиперссылку
- текстовая гиперссылка
- гиперссылка слайда
- гиперссылка фигуры
- гиперссылка изображения
- гиперссылка видео
- изменяемая гиперссылка
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Добавление, форматирование, обновление и удаление гиперссылок в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для .NET, используя примеры на C#."
---
## **Введение**

Гиперссылка соединяет содержимое презентации с веб‑сайтом или местом внутри презентации. В PowerPoint гиперссылки обычно служат двум целям:

* Открыть веб‑сайт из текста, фигуры или медиакадра.
* Перейти к другому слайду, например, из оглавления.

Aspose.Slides для .NET позволяет добавлять такие ссылки, управлять их внешним видом и звуком, обновлять свойства и удалять их. Примеры ниже показывают, как работать с гиперссылками на отдельных элементах и как получать доступ к гиперссылкам уровня презентации, слайда или текстового кадра.

{{% alert color="info" title="Note" %}}

Вы также можете редактировать презентации с помощью [бесплатного онлайн‑редактора Aspose PowerPoint](https://products.aspose.app/slides/ru/editor).

{{% /alert %}} 

## **Добавить гиперссылки URL**

Вы можете назначить URL веб‑сайта тексту, фигуре или медиакадру. Элемент, к которому назначена гиперссылка, определяет кликабельную область: часть текста связывает выбранный текст, а фигура или кадр связывают объект слайда.

### **Добавить гиперссылки URL к тексту**

Чтобы связать текст с веб‑сайтом, назначьте [Hyperlink](https://reference.aspose.com/slides/ru/net/aspose.slides/hyperlink/) свойству [HyperlinkClick](https://reference.aspose.com/slides/ru/net/aspose.slides/portionformat/hyperlinkclick/) части текста, как показано ниже. Кликабельным становится только эта часть текста.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var textShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
textShape.AddTextFrame("Aspose: File Format APIs");
var portionFormat = textShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
portionFormat.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";
portionFormat.FontHeight = 32;

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

### **Добавить гиперссылки URL к фигурам и медиакадрам**

Чтобы сделать фигуру или кадр кликабельными, задайте их свойство [HyperlinkClick](https://reference.aspose.com/slides/ru/net/aspose.slides/shape/hyperlinkclick/). Гиперссылка принадлежит самому объекту, а не части текста внутри него.

Такой же подход применяется к кадрам изображений, аудио и видео: назначьте гиперссылку кадру и, при необходимости, задайте её [Tooltip](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlink/tooltip/).

Следующий пример делает прямоугольник кликабельным:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **Использовать гиперссылки для создания оглавления**

Внутренние гиперссылки позволяют читателям переходить из оглавления к конкретному слайду. В следующем примере используется [SetInternalHyperlinkClick](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) для ссылки текста «Страница 2» на первом слайде к второму слайду.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var tableOfContents = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
tableOfContents.FillFormat.FillType = FillType.NoFill;
tableOfContents.LineFormat.FillFormat.FillType = FillType.NoFill;
tableOfContents.TextFrame.Paragraphs.Clear();

var paragraph = new Paragraph();
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
paragraph.Text = "Title of slide 2 .......... ";

var linkPortion = new Portion();
linkPortion.Text = "Page 2";
linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

paragraph.Portions.Add(linkPortion);
tableOfContents.TextFrame.Paragraphs.Add(paragraph);

presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
```

## **Форматировать гиперссылки**

### **Цвет**

Свойство [ColorSource](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlink/colorsource/) интерфейса [IHyperlink](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlink/) определяет, использует ли гиперссылка цвет гиперссылки презентации или форматирование части текста. Чтобы задать пользовательский цвет текста, выберите [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/hyperlinkcolorsource/) и установите цвет заливки части. Эта возможность была введена в PowerPoint 2019; более старые версии эту настройку не поддерживают.

Следующий пример добавляет две текстовые гиперссылки на один слайд. Первая использует красный цвет заливки текста, а вторая сохраняет цвет гиперссылки по умолчанию.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var coloredShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
coloredShape.AddTextFrame("This hyperlink uses a custom color.");
var coloredPortionFormat = coloredShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
coloredPortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
coloredPortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
coloredPortionFormat.FillFormat.FillType = FillType.Solid;
coloredPortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

var defaultShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
defaultShape.AddTextFrame("This hyperlink uses the default color.");
defaultShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
```
### **Звук**

Гиперссылка может воспроизводить звук при активации или останавливать уже звучащий звук. Используйте следующие свойства для настройки этих поведений:

- [IHyperlink.Sound](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlink/sound/) задаёт аудио, связанное с гиперссылкой.
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlink/stopsoundonclick/) определяет, останавливает ли активация гиперссылки предыдущий звук.

#### **Добавить звук к гиперссылке**

Следующий пример загружает `sampleaudio.wav` и связывает его с кнопкой на первом слайде. Нажатие кнопки воспроизводит звук и переходит к следующему слайду. Вторая фигура на этом слайде останавливает предыдущий звук при нажатии, не выполняя перехода.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var audioData = File.ReadAllBytes("sampleaudio.wav");
var hyperlinkSound = presentation.Audios.AddAudio(audioData);

var firstSlide = presentation.Slides[0];

var playButton = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
playButton.HyperlinkClick = Hyperlink.NextSlide;

if (!playButton.HyperlinkClick.StopSoundOnClick && playButton.HyperlinkClick.Sound == null)
{
    playButton.HyperlinkClick.Sound = hyperlinkSound;
}

var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var stopButton = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
stopButton.HyperlinkClick = Hyperlink.NoAction;

stopButton.HyperlinkClick.StopSoundOnClick = true;

presentation.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
```

#### **Извлечь звук из гиперссылки**

Следующий пример открывает презентацию, созданную выше, и считывает аудио гиперссылки первой фигуры в память через [Sound](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlink/sound/) и [BinaryData](https://reference.aspose.com/slides/ru/net/aspose.slides/iaudio/binarydata/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("hyperlink-sound.pptx");

if (presentation.Slides.Count > 0 && presentation.Slides[0].Shapes.Count > 0)
{
    var hyperlink = presentation.Slides[0].Shapes[0].HyperlinkClick;
    var sound = hyperlink?.Sound;
    if (sound != null)
    {
        var audioData = sound.BinaryData;
        Console.WriteLine($"Extracted {audioData.Length} bytes of hyperlink audio.");
    }
    else
    {
        Console.WriteLine("The first shape has no hyperlink sound.");
    }
}
else
{
    Console.WriteLine("The presentation has no first slide or shape to inspect.");
}
```

### **Всплывающая подсказка и параметры взаимодействия**

После назначения гиперссылки тексту или фигуре вы можете обновить следующие свойства интерфейса [IHyperlink](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlink/):

- [Tooltip](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlink/tooltip/) задаёт текст, который просмотрщик может отобразить как подсказку к ссылке.
- [TargetFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlink/targetframe/) указывает целевой кадр внутри родительского HTML‑фреймсета, если это применимо.
- [History](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlink/history/) определяет, добавлять ли пункт назначения в список просмотренных гиперссылок при активации.
- [HighlightClick](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlink/highlightclick/) управляет тем, будет ли гиперссылка подсвечиваться при щелчке.

## **Удалить гиперссылки из презентаций**

Используйте [GetAnyHyperlinks](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) для сбора контейнеров гиперссылок, включая ссылки частей текста, перед их изменением. В следующем примере удаляются оба типа активации с первого слайда. Чтобы удалить только один тип, вызовите лишь [RemoveHyperlinkClick](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) или [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/); удаление действия щелчка не удаляет его аналог при наведении мыши.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

if (presentation.Slides.Count > 0)
{
    var containers = presentation.Slides[0].HyperlinkQueries.GetAnyHyperlinks().ToList();
    foreach (var container in containers)
    {
        container.HyperlinkManager.RemoveHyperlinkClick();
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
    presentation.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The presentation has no slides to process.");
}
```

Для безусловного удаления [RemoveAllHyperlinks](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) удаляет оба типа активации в выбранном диапазоне одним вызовом. Для выборочной очистки и охвата мастеров, макетов и заметок см. раздел [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Создать полную инвентаризацию гиперссылок**

Перед распространением презентации проинвентарьте её интерактивные действия и веб‑ссылки. [GetAnyHyperlinks](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) возвращает объекты [IHyperlinkContainer](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlinkcontainer/), а не простой список строк URL. Проверяйте как [HyperlinkClick](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/), так и [HyperlinkMouseOver](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) у каждого контейнера. Они независимы: один контейнер может содержать оба действия, поэтому полный отчёт требует до двух строк на контейнер.

Сканирование только гиперссылок уровня фигур может пропустить ссылки, прикреплённые к частям текста. Запрашивайте соответствующий диапазон и сохраняйте полученные контейнеры, чтобы позже обновлять или удалять их действия.

### **Запросы диапазонов презентации, слайда и текстового кадра**

Интерфейс [IHyperlinkQueries](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlinkqueries/) доступен через [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseslide/hyperlinkqueries/) и [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/hyperlinkqueries/). Каждый диапазон поддерживает одинаковые запросы:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) возвращает контейнеры с действием щелчка.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) возвращает контейнеры с действием наведения мыши.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) возвращает контейнеры с любым из действий или с обоими.

Следующий пример создаёт `hyperlink-audit-input.pptx` с внешней ссылкой‑клик, ссылкой‑наведение‑мыши на файл, внутренней навигацией по слайдам, ссылкой‑наведение‑мыши на текст и макросом. Он не выполняет ни одного из этих действий. Три указанных запроса работают на каждом диапазоне; их результаты описывают количество контейнеров, а не количество действий. Диапазон текстового кадра исключает ссылки самой охватывающей фигуры.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var destination = presentation.Slides.AddEmptySlide(slide.LayoutSlide);
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
shape.TextFrame.Text = "Click the text to go to slide 2";
shape.HyperlinkManager.SetExternalHyperlinkClick("https://example.com/");
shape.HyperlinkClick.Tooltip = "Public website";
shape.HyperlinkManager.SetExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

var portionFormat = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkManager.SetInternalHyperlinkClick(destination);
portionFormat.HyperlinkManager.SetExternalHyperlinkMouseOver("https://example.com/help");
var macroButton = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
macroButton.HyperlinkManager.SetMacroHyperlinkClick("ReviewPresentation");

PrintCounts("Presentation", presentation.HyperlinkQueries);
PrintCounts("Slide 1", slide.HyperlinkQueries);
PrintCounts("Text frame", shape.TextFrame.HyperlinkQueries);
presentation.Save("hyperlink-audit-input.pptx", SaveFormat.Pptx);

static void PrintCounts(string scope, IHyperlinkQueries queries)
{
    var clickContainers = queries.GetHyperlinkClicks();
    var mouseOverContainers = queries.GetHyperlinkMouseOvers();
    var allContainers = queries.GetAnyHyperlinks();
    Console.WriteLine($"{scope}: click={clickContainers.Count}, mouse-over={mouseOverContainers.Count}, any={allContainers.Count}");
}
```

Для данного примера запросы презентации и слайда каждый возвращают три контейнера‑клика, два контейнера‑наведения и три контейнера с любым действием. Запрос текстового кадра возвращает по одному контейнеру в каждой категории.

### **Классификация действий и назначений**

Используйте [IHyperlink.ActionType](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlink/actiontype/) для интерпретации действия перед определением его назначения. Значения [HyperlinkActionType](https://reference.aspose.com/slides/ru/net/aspose.slides/hyperlinkactiontype/) охватывают больше, чем веб‑навигацию:

| Значения | Значение для аудита |
| --- | --- |
| `Hyperlink` | Внешняя гиперссылка; проверьте URL и его схему. |
| `JumpSpecificSlide` | Внутренняя навигация к определённому слайду. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Встроенная навигация слайда, разрешаемая в контексте слайд‑шоу. |
| `JumpEndShow`, `StartCustomSlideShow` | Завершить текущую демонстрацию или запустить пользовательскую. |
| `StartMacro` | Выполнить макрос. |
| `StartProgram` | Запустить программу. |
| `OpenFile`, `OpenPresentation` | Открыть файл или другую презентацию; рассматривайте отдельно от веб‑URL. |
| `StartStopMedia` | Запустить или остановить воспроизведение медиа. |
| `NoAction`, `Unknown` | Нет навигационного действия или неизвестное действие, требующее проверки. |

Чтение внешних назначений осуществляется через [ExternalUrl](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlink/externalurl/), а конкретных внутренних — через [TargetSlide](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlink/targetslide/). Внутренние действия и встроенные команды могут не иметь внешнего URL; пустой URL не означает отсутствие действия. Сохраняйте [ExternalUrlOriginal](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlink/externalurloriginal/), если он отличается от нормализованного URL, и включайте [Tooltip](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlink/tooltip/), когда он доступен.

### **Отчёт, очистка и проверка гиперссылок**

Следующий пример на .NET 6+ читает существующую презентацию (используйте файл, созданный выше), записывает `hyperlink-audit.json`, применяет политику, сохраняет `hyperlink-sanitized.pptx` и открывает её вновь для повторной проверки обоих типов активации. Он собирает контейнеры до их изменения и использует проверку ссылочного равенства, чтобы не обрабатывать один и тот же контейнер дважды. Запросы презентации охватывают обычные слайды; для инвентаризации всего пакета он также явно запрашивает мастера, макеты, заметки и мастера заметок и раздаточных листов, если они присутствуют.

Отчёт фиксирует индекс слайда, начиная с 1, и [SlideId](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseslide/slideid/), если он доступен. [ISlideComponent.Slide](https://reference.aspose.com/slides/ru/net/aspose.slides/islidecomponent/slide/) предоставляет владелец‑слайд для поддерживаемых контейнеров. У мастеров, макетов и заметок обычного индекса слайда нет; они идентифицируются по своему диапазону. Контейнеры фигур и контейнеры форматирования частей текста маркируются отдельно; остальные типы контейнеров сохраняют своё имя типа во время выполнения. Каждый контейнер получает локальный ID отчёта, чтобы его два действия можно было сопоставить.

Эта преднамеренно строгая политика приложений допускает только абсолютные HTTPS‑URL и действительные внутренние цели слайдов. Она отклоняет макросы, программы, файловые действия, другие действия слайд‑шоу, неизвестные действия и другие схемы URL. Эти отклонения — решения политики, а не оценка безопасности Aspose.Slides. Один лишь HTTPS не гарантирует доверие: добавьте списки разрешённых хостов и другие проверки для вашего приложения. Проверяются как оригинальные, так и нормализованные внешние URL. Пример аудирует метаданные без переходов по ссылкам и без выполнения действий.

Для исправления контейнерный [HyperlinkManager](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) поддерживает [SetExternalHyperlinkClick](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) и [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Здесь запрещённые внешние ссылки‑клик заменяются фиксированной HTTPS‑страницей; другие запрещённые клики и действия‑наведение удаляются независимо. Установите `replaceExternalClicks` в `false`, чтобы удалить все нарушения политики. Выберите страницу‑заменитель, принадлежащую вашему приложению, перед развертыванием.

Флаг экспорта в отчёте использует консервативную политику проверки PDF: помечаются действия‑наведение и всё, что не является внешней ссылкой или переходом к конкретному слайду, как потенциально неподдерживаемое. Это лишь подсказка для ревью, а не проверка возможностей или гарантия, что непомеченные ссылки сохранятся при экспорте. Поддерживаемый экспорт в [PDF](/slides/ru/net/convert-powerpoint-to-pdf/) и [HTML](/slides/ru/net/convert-powerpoint-to-html/) может сохранять гиперссылки в зависимости от действия, параметров экспорта и средства просмотра. Растровые [изображения](/slides/ru/net/convert-powerpoint-to-png/) и [видео](/slides/ru/net/convert-powerpoint-to-video/) не могут сохранять интерактивные гиперссылки; помечайте каждое действие при аудите для этих форматов вывода.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

const bool replaceExternalClicks = true;
const string replacementUrl = "https://example.com/blocked-link";
using var presentation = new Presentation("hyperlink-audit-input.pptx");
var containers = CollectContainers(presentation);
var rows = new List<object>();

for (var index = 0; index < containers.Count; index++)
{
    var container = containers[index];
    AddRow(container.HyperlinkClick, "click", container, index + 1);
    AddRow(container.HyperlinkMouseOver, "mouse-over", container, index + 1);
}

var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
var json = JsonSerializer.Serialize(rows, jsonOptions);
File.WriteAllText("hyperlink-audit.json", json);

foreach (var container in containers)
{
    var click = container.HyperlinkClick;
    if (PolicyViolation(click) != null)
    {
        if (replaceExternalClicks && click.ActionType == HyperlinkActionType.Hyperlink)
        {
            container.HyperlinkManager.SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container.HyperlinkManager.RemoveHyperlinkClick();
        }
    }
    if (PolicyViolation(container.HyperlinkMouseOver) != null)
    {
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
}

presentation.Save("hyperlink-sanitized.pptx", SaveFormat.Pptx);
using var reopened = new Presentation("hyperlink-sanitized.pptx");
var remainingContainers = CollectContainers(reopened);
var violations = 0;
foreach (var container in remainingContainers)
{
    if (PolicyViolation(container.HyperlinkClick) != null) violations++;
    if (PolicyViolation(container.HyperlinkMouseOver) != null) violations++;
}
Console.WriteLine($"Audit rows: {rows.Count}; prohibited actions after reopening: {violations}");
if (violations != 0)
{
    Console.WriteLine("Verification failed: do not distribute the saved presentation.");
    Environment.ExitCode = 1;
}

void AddRow(IHyperlink? link, string activation, IHyperlinkContainer container, int containerId)
{
    if (link == null) return;
    var ownerSlide = (container as ISlideComponent)?.Slide;
    var targetSlide = link.TargetSlide;
    var violation = PolicyViolation(link);
    var ownerType = container is IShape ? "Shape" : container is IPortionFormat ? "Text portion" : container.GetType().Name;
    var ordinaryAction = link.ActionType == HyperlinkActionType.Hyperlink || link.ActionType == HyperlinkActionType.JumpSpecificSlide;
    rows.Add(new
    {
        ContainerId = containerId,
        SlideIndex = SlideIndex(presentation, ownerSlide),
        SlideId = ownerSlide?.SlideId,
        Scope = ownerSlide?.GetType().Name,
        OwnerType = ownerType,
        Activation = activation,
        ActionType = link.ActionType.ToString(),
        ExternalUrl = link.ExternalUrl,
        TargetSlideIndex = SlideIndex(presentation, targetSlide),
        TargetSlideId = targetSlide?.SlideId,
        Tooltip = link.Tooltip,
        OriginalExternalUrl = link.ExternalUrlOriginal != link.ExternalUrl ? link.ExternalUrlOriginal : null,
        PotentiallyUnsafe = violation != null,
        PolicyViolation = violation,
        TargetExport = "PDF",
        PotentiallyUnsupportedByExport = activation == "mouse-over" || !ordinaryAction
    });
}

static int? SlideIndex(IPresentation presentation, IBaseSlide? slide)
{
    for (var index = 0; index < presentation.Slides.Count; index++)
    {
        if (ReferenceEquals(presentation.Slides[index], slide)) return index + 1;
    }
    return null;
}

static string? PolicyViolation(IHyperlink? link)
{
    if (link == null) return null;
    if (link.ActionType == HyperlinkActionType.JumpSpecificSlide)
    {
        return link.TargetSlide == null ? "Missing target slide" : null;
    }
    if (link.ActionType != HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!IsHttps(link.ExternalUrl)) return "Normalized URL is not absolute HTTPS";
    var original = link.ExternalUrlOriginal;
    if (!string.IsNullOrEmpty(original) && !IsHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

static bool IsHttps(string? value)
{
    return Uri.TryCreate(value, UriKind.Absolute, out var uri) && uri.Scheme == Uri.UriSchemeHttps;
}

static List<IHyperlinkContainer> CollectContainers(IPresentation presentation)
{
    var found = new List<IHyperlinkContainer>();
    found.AddRange(presentation.HyperlinkQueries.GetAnyHyperlinks());
    foreach (var master in presentation.Masters) AddScope(master);
    foreach (var layout in presentation.LayoutSlides) AddScope(layout);
    foreach (var slide in presentation.Slides) AddScope(slide.NotesSlideManager.NotesSlide);
    AddScope(presentation.MasterNotesSlideManager.MasterNotesSlide);
    AddScope(presentation.MasterHandoutSlideManager.MasterHandoutSlide);
    return found.Distinct<IHyperlinkContainer>(ReferenceEqualityComparer.Instance).ToList();

    void AddScope(IBaseSlide? slide)
    {
        if (slide != null) found.AddRange(slide.HyperlinkQueries.GetAnyHyperlinks());
    }
}
```

С созданным выше вводом отчёт содержит пять строк действий. Ссылка‑наведение‑мыши на файл и макрос‑клик удаляются, тогда как HTTPS‑ссылки и внутренняя навигация по слайдам остаются. Проверка выводит ноль запрещённых действий. Ввод, содержащий запрещённый внешний URL‑клик, также демонстрирует ветвь замены. Контейнер с разрешённым кликом и запрещённым наведением сохраняет действие‑клик.

Эта выборочная очистка отличается от [RemoveAllHyperlinks](https://reference.aspose.com/slides/ru/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), который удаляет оба типа активации во всём выбранном диапазоне независимо от политики. Проверка здесь проверяет только действия гиперссылки; она не удаляет внедрённые проекты VBA, OLE‑объекты или другое активное содержимое и не проверяет экспортированный PDF или HTML файл.

## **FAQ**

**Как создать ссылку на раздел или его первый слайд?**

Разделы в PowerPoint группируют слайды, но внутренняя гиперссылка ориентируется на отдельный слайд. Чтобы создать навигацию к разделу, свяжите её с первым слайдом этого раздела.

**Можно ли прикрепить гиперссылку к элементам мастер‑слайда, чтобы она работала на всех слайдах?**

Да. Элементы мастер‑слайда и макета поддерживают гиперссылки. Ссылки на этих элементах доступны во время показа слайдов на всех слайдах, использующих соответствующий мастер или макет.

**Сохранятся ли гиперссылки при экспорте в PDF, HTML, изображения или видео?**

Поддерживаемый экспорт в PDF и HTML может сохранять гиперссылки; растровые изображения и видео — нет. См. соображения экспорта в разделе [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).