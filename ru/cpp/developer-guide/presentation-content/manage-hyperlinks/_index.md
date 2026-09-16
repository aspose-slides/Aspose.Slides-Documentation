---
title: Управление гиперссылками презентации в C++
linktitle: Управление гиперссылками
type: docs
weight: 20
url: /ru/cpp/manage-hyperlinks/
keywords:
- добавить URL
- добавить гиперссылку
- создать гиперссылку
- форматировать гиперссылку
- удалить гиперссылку
- обновить гиперссылку
- гиперссылка в тексте
- гиперссылка на слайд
- гиперссылка на фигуру
- гиперссылка на изображение
- гиперссылка на видео
- изменяемая гиперссылка
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Добавляйте, форматируйте, обновляйте и удаляйте гиперссылки в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для C++, используя примеры на C++."
---
## **Введение**

Гиперссылка соединяет содержимое презентации с веб‑сайтом или местом внутри презентации. В PowerPoint гиперссылки обычно служат двум целям:

* Открыть веб‑сайт из текста, фигуры или медиа‑кадра.
* Перейти к другому слайду, например, из оглавления.

Aspose.Slides для C++ позволяет добавлять такие ссылки, управлять их внешним видом и звуком, изменять их параметры и удалять их. Приведённые ниже примеры показывают, как работать с гиперссылками на отдельных элементах и как получать доступ к гиперссылкам на уровне презентации, слайда или текстового кадра.

{{% alert color="info" title="Note" %}}
Вы также можете редактировать презентации с помощью [бесплатного онлайн‑редактора Aspose PowerPoint](https://products.aspose.app/slides/ru/editor).
{{% /alert %}} 

## **Добавить гиперссылки URL**

Вы можете назначить URL веб‑сайта тексту, фигуре или медиа‑кадру. Элемент, к которому назначена гиперссылка, определяет область клика: часть текста связывает выбранный текст, а фигура или кадр связывают объект слайда.

### **Добавить гиперссылки URL к тексту**

Чтобы связать текст с веб‑сайтом, создайте [Hyperlink](https://reference.aspose.com/slides/ru/cpp/aspose.slides/hyperlink/) и назначьте его через метод [set_HyperlinkClick](https://reference.aspose.com/slides/ru/cpp/aspose.slides/portionformat/set_hyperlinkclick/) части текста, как показано ниже. Только эта часть текста станет кликабельной.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto textShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
textShape->AddTextFrame(u"Aspose: File Format APIs");
auto portionFormat = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"Explore Aspose file format APIs");
portionFormat->set_FontHeight(32);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

### **Добавить гиперссылки URL к фигурам и медиа‑кадрам**

Чтобы сделать фигуру или кадр кликабельным, используйте её метод [set_HyperlinkClick](https://reference.aspose.com/slides/ru/cpp/aspose.slides/shape/set_hyperlinkclick/). Гиперссылка относится к самому объекту, а не к части текста внутри него.

Тот же подход применяется к кадрам изображений, аудио и видео: назначьте гиперссылку кадру и при необходимости используйте [set_Tooltip](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlink/set_tooltip/) для добавления подсказки.

Следующий пример делает прямоугольник кликабельным:

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"Explore Aspose file format APIs");

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

## **Использовать гиперссылки для создания оглавления**

Внутренние гиперссылки позволяют читателям переходить из оглавления к конкретному слайду. В следующем примере используется [SetInternalHyperlinkClick](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) для связывания текста «Page 2» на первом слайде со вторым слайдом.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto tableOfContents = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
tableOfContents->get_FillFormat()->set_FillType(FillType::NoFill);
tableOfContents->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
tableOfContents->get_TextFrame()->get_Paragraphs()->Clear();

auto paragraph = System::MakeObject<Paragraph>();
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
paragraph->set_Text(u"Title of slide 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Page 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
tableOfContents->get_TextFrame()->get_Paragraphs()->Add(paragraph);

presentation->Save(u"link_to_slide.pptx", SaveFormat::Pptx);
```

## **Форматировать гиперссылки**

### **Цвет**

Метод [set_ColorSource](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlink/set_colorsource/) интерфейса [IHyperlink](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlink/) определяет, использует ли гиперссылка цвет гиперссылки презентации или форматирование части текста. Чтобы применить пользовательский цвет текста, выберите [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/hyperlinkcolorsource/) и задайте цвет заливки части. Эта функция была внедрена в PowerPoint 2019; более старые версии эту настройку не поддерживают.

Следующий пример добавляет две текстовые гиперссылки на один и тот же слайд. Первая использует красный цвет текста, а вторая сохраняет цвет гиперссылки по умолчанию.

```cpp
#include <DOM/FillType.h>
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkColorSource.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlink.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto coloredShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
coloredShape->AddTextFrame(u"This hyperlink uses a custom color.");
auto coloredPortionFormat = coloredShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
coloredPortionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
coloredPortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
coloredPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
coloredPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

auto defaultShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
defaultShape->AddTextFrame(u"This hyperlink uses the default color.");
defaultShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```
### **Звук**

Гиперссылка может воспроизводить звук при активации или останавливать уже воспроизводимый звук. Для настройки этих поведений используйте следующие методы:

- [IHyperlink::set_Sound](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlink/set_sound/) указывает аудио, связанное с гиперссылкой.
- [IHyperlink::set_StopSoundOnClick](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlink/set_stopsoundonclick/) управляет тем, останавливается ли предыдущий звук при активации гиперссылки.

#### **Добавить звук к гиперссылке**

В следующем примере загружается `sampleaudio.wav` и связывается с кнопкой на первом слайде. Нажатие кнопки воспроизводит звук и переходит к следующему слайду. Вторая фигура на том же слайде останавливает предыдущий звук при нажатии, не выполняя перехода.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto audioData = System::IO::File::ReadAllBytes(u"sampleaudio.wav");
auto hyperlinkSound = presentation->get_Audios()->AddAudio(audioData);

auto firstSlide = presentation->get_Slide(0);

auto playButton = firstSlide->get_Shapes()->AddAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
playButton->set_HyperlinkClick(Hyperlink::get_NextSlide());

if (!playButton->get_HyperlinkClick()->get_StopSoundOnClick() && playButton->get_HyperlinkClick()->get_Sound() == nullptr)
{
    playButton->get_HyperlinkClick()->set_Sound(hyperlinkSound);
}

auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto stopButton = secondSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
stopButton->set_HyperlinkClick(Hyperlink::get_NoAction());

stopButton->get_HyperlinkClick()->set_StopSoundOnClick(true);

presentation->Save(u"hyperlink-sound.pptx", SaveFormat::Pptx);
```

#### **Извлечь звук из гиперссылки**

В следующем примере открывается ранее созданная презентация и звук гиперссылки первой фигуры считывается в память с помощью методов [get_Sound](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlink/get_sound/) и [get_BinaryData](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iaudio/get_binarydata/).

```cpp
#include <DOM/IAudio.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"hyperlink-sound.pptx");

if (presentation->get_Slides()->get_Count() > 0 && presentation->get_Slide(0)->get_Shapes()->get_Count() > 0)
{
    auto hyperlink = presentation->get_Slide(0)->get_Shape(0)->get_HyperlinkClick();
    auto sound = hyperlink != nullptr ? hyperlink->get_Sound() : nullptr;
    if (sound != nullptr)
    {
        auto audioData = sound->get_BinaryData();
        System::Console::WriteLine(u"Extracted {0} bytes of hyperlink audio.", audioData->get_Length());
    }
    else
    {
        System::Console::WriteLine(u"The first shape has no hyperlink sound.");
    }
}
else
{
    System::Console::WriteLine(u"The presentation has no first slide or shape to inspect.");
}
```

### **Настройки подсказки и взаимодействия**

После назначения гиперссылки тексту или фигуре вы можете обновить следующие настройки [IHyperlink](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlink/) с помощью указанных методов:

- [set_Tooltip](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlink/set_tooltip/) задает текст, который пользователь может видеть как подсказку к ссылке.
- [set_TargetFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlink/set_targetframe/) указывает целевой кадр внутри родительского HTML‑фреймсета, если применимо.
- [set_History](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlink/set_history/) управляет тем, добавляется ли целевая ссылка в список просмотренных гиперссылок при её активации.
- [set_HighlightClick](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlink/set_highlightclick/) управляет тем, будет ли гиперссылка подсвечиваться при клике.

## **Удалить гиперссылки из презентаций**

Для сбора контейнеров гиперссылок, включая ссылки частей текста, используйте [GetAnyHyperlinks](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/). Следующий пример удаляет оба типа активации с первого слайда. Чтобы удалить только один тип, вызовите лишь [RemoveHyperlinkClick](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) или [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/); удаление действия клика не удаляет соответствующее действие mouse‑over.

```cpp
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

if (presentation->get_Slides()->get_Count() > 0)
{
    auto containers = presentation->get_Slide(0)->get_HyperlinkQueries()->GetAnyHyperlinks();
    for (const auto& container : containers)
    {
        container->get_HyperlinkManager()->RemoveHyperlinkClick();
        container->get_HyperlinkManager()->RemoveHyperlinkMouseOver();
    }
    presentation->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
}
else
{
    System::Console::WriteLine(u"The presentation has no slides to process.");
}
```

Для безусловного удаления [RemoveAllHyperlinks](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) удаляет оба типа активации в выбранном диапазоне одним вызовом. Для выборочной очистки и охвата мастеров, макетов и заметок см. раздел [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Создать полный инвентарь гиперссылок**

Перед распространением презентации составьте инвентарь её интерактивных действий и веб‑ссылок. [GetAnyHyperlinks](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) возвращает объекты [IHyperlinkContainer](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlinkcontainer/), а не простой список строк URL. Проверьте как [get_HyperlinkClick](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkclick/) и [get_HyperlinkMouseOver](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmouseover/) в каждом контейнере. Они независимы: один контейнер может содержать оба действия, поэтому полноценный отчёт требует до двух строк на контейнер.

Сканирование только гиперссылок уровня фигур может пропустить ссылки, прикреплённые к частям текста. Вместо этого запрашивайте соответствующий диапазон и сохраняйте возвращённые контейнеры, чтобы позже можно было обновлять или удалять их действия.

### **Запрос областей Презентация, Слайд и Текстовый‑кадр**

Интерфейс [IHyperlinkQueries](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlinkqueries/) доступен через [IPresentation::get_HyperlinkQueries](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/get_hyperlinkqueries/), [IBaseSlide::get_HyperlinkQueries](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseslide/get_hyperlinkqueries/) и [ITextFrame::get_HyperlinkQueries](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/get_hyperlinkqueries/). Каждая область поддерживает одинаковые запросы:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) возвращает контейнеры с действием клика.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) возвращает контейнеры с действием mouse‑over.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) возвращает контейнеры с одним или обоими действиями.

В следующем примере создаётся `hyperlink-audit-input.pptx` с внешней ссылкой по клику, ссылкой mouse‑over на файл, внутренней навигацией по слайдам, ссылкой mouse‑over в тексте и действием макроса. Ни одно из этих действий не выполняется. Три одинаковых запроса работают в каждой области; счётчики отражают количество контейнеров, а не суммарное количество действий. Область текстового кадра исключает собственные ссылки окружающей фигуры.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto printCounts = [](System::String scope, System::SharedPtr<IHyperlinkQueries> queries)
{
    auto clickContainers = queries->GetHyperlinkClicks();
    auto mouseOverContainers = queries->GetHyperlinkMouseOvers();
    auto allContainers = queries->GetAnyHyperlinks();
    System::Console::WriteLine(u"{0}: click={1}, mouse-over={2}, any={3}", scope, clickContainers->get_Count(), mouseOverContainers->get_Count(), allContainers->get_Count());
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto destination = presentation->get_Slides()->AddEmptySlide(slide->get_LayoutSlide());
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
shape->get_TextFrame()->set_Text(u"Click the text to go to slide 2");
shape->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://example.com/");
shape->get_HyperlinkClick()->set_Tooltip(u"Public website");
shape->get_HyperlinkManager()->SetExternalHyperlinkMouseOver(u"file:///C:/private/report.xlsx");

auto portionFormat = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
portionFormat->get_HyperlinkManager()->SetInternalHyperlinkClick(destination);
portionFormat->get_HyperlinkManager()->SetExternalHyperlinkMouseOver(u"https://example.com/help");
auto macroButton = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
macroButton->get_HyperlinkManager()->SetMacroHyperlinkClick(u"ReviewPresentation");

printCounts(u"Presentation", presentation->get_HyperlinkQueries());
printCounts(u"Slide 1", slide->get_HyperlinkQueries());
printCounts(u"Text frame", shape->get_TextFrame()->get_HyperlinkQueries());
presentation->Save(u"hyperlink-audit-input.pptx", SaveFormat::Pptx);
```

Для этого примера запросы презентации и слайда каждый возвращают три контейнера с кликом, два контейнера с mouse‑over и три контейнера с любым из действий. Запрос текстового кадра возвращает по одному контейнеру в каждой категории.

### **Классификация действий и целей**

Для интерпретации действия перед определением его цели используйте [IHyperlink::get_ActionType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlink/get_actiontype/). Значения [HyperlinkActionType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/hyperlinkactiontype/) охватывают не только веб‑навигацию:

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | Внешняя гиперссылка; проверьте URL и её схему. |
| `JumpSpecificSlide` | Внутренняя навигация к конкретному слайду. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Встроенная навигация в демонстрации, разрешаемая в контексте слайд‑шоу. |
| `JumpEndShow`, `StartCustomSlideShow` | Завершить текущую демонстрацию или запустить пользовательскую демонстрацию. |
| `StartMacro` | Выполнить макрос. |
| `StartProgram` | Запустить программу. |
| `OpenFile`, `OpenPresentation` | Открыть файл или другую презентацию; рассмотреть отдельно от веб‑URL. |
| `StartStopMedia` | Запустить или остановить воспроизведение медиа. |
| `NoAction`, `Unknown` | Нет действия навигации, либо нераспознанное действие, требующее проверки. |

Внешние цели читаются с помощью [get_ExternalUrl](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlink/get_externalurl/) и конкретные внутренние цели — через [get_TargetSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlink/get_targetslide/). Внутренние действия и встроенные команды могут не иметь внешнего URL; пустой URL не означает отсутствие действия у контейнера. Сохраняйте [get_ExternalUrlOriginal](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlink/get_externalurloriginal/), если он отличается от нормализованного URL, и включайте подсказку, возвращаемую [get_Tooltip](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlink/get_tooltip/), когда она доступна.

### **Отчёт, очистка и проверка гиперссылок**

В следующем примере на C++ читается существующая презентация (используйте файл, созданный выше), записывается `hyperlink-audit.json`, применяется политика, сохраняется `hyperlink-sanitized.pptx`, после чего файл открывается снова для повторной проверки обоих типов активации. Контейнеры собираются до их изменения, и используется сравнение указателей, чтобы не обрабатывать один и тот же контейнер дважды. Запросы презентации охватывают обычные слайды; для инвентаризации всего пакета также явно запрашиваются мастера, макеты, заметки и мастера заметок и раздаточных материалов, если они присутствуют.

Отчёт фиксирует номер слайда, начинающийся с 1, и [get_SlideId](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseslide/get_slideid/) , если он доступен. [ISlideComponent::get_Slide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecomponent/get_slide/) предоставляет принадлежащий слайд для поддерживаемых контейнеров. У мастеров, макетов и заметок нет обычного индекса слайда; они идентифицируются по своей области. Контейнеры фигур и контейнеры форматирования частей текста помечаются отдельно; остальные типы контейнеров сохраняют своё имя типа во время выполнения. Каждый контейнер получает локальный идентификатор в отчёте, чтобы их два действия можно было сопоставить.

Эта преднамеренно строгая политика приложения допускает только абсолютные HTTPS‑URL и корректные внутренние цели слайдов. Она отклоняет макросы, программы, действия с файлами, другие действия слайд‑шоу, неизвестные действия и другие схемы URL. Эти отклонения являются решениями политики, а не выводом о безопасности Aspose.Slides. Один лишь HTTPS не гарантирует доверие: добавьте список разрешённых хостов и другие проверки для вашего приложения. Проверяются как оригинальные, так и нормализованные внешние URL. Пример проводит аудит метаданных без перехода по ссылкам или выполнения действий.

Для исправления контейнерный метод [get_HyperlinkManager](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmanager/) поддерживает [SetExternalHyperlinkClick](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) и [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Здесь запрещённые внешние ссылки по клику заменяются фиксированной HTTPS‑страницей назначения; остальные запрещённые клики и действия mouse‑over удаляются отдельно. Установите `replaceExternalClicks` в `false`, чтобы вместо замены удалить все нарушения политики. Выберите страницу‑заменитель, принадлежащую приложению, перед развёртыванием.

Флаг экспорта в отчёте использует консервативную политику проверки PDF: помечать действия mouse‑over и всё, кроме внешних ссылок или переходов к конкретному слайду, как потенциально неподдерживаемое. Это лишь рекомендация для проверки, а не тест возможностей и не гарантия, что непомеченные ссылки сохранятся при экспорте. Поддерживаемый экспорт в [PDF](/slides/ru/cpp/convert-powerpoint-to-pdf/) и [HTML](/slides/ru/cpp/convert-powerpoint-to-html/) может сохранять гиперссылки в зависимости от действия, параметров экспорта и просмотрщика. Растровые [изображения](/slides/ru/cpp/convert-powerpoint-to-png/) и [видео](/slides/ru/cpp/convert-powerpoint-to-video/) не могут сохранять интерактивные гиперссылки; помечайте каждое действие при аудите для этих форматов вывода.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkActionType.h>
#include <DOM/IBaseSlide.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPresentation.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideComponent.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/uri.h>
#include <system/environment.h>
#include <fstream>
#include <sstream>
#include <iomanip>
#include <vector>
#include <unordered_set>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const auto replaceExternalClicks = true;
const System::String replacementUrl = u"https://example.com/blocked-link";
auto presentation = System::MakeObject<Presentation>(u"hyperlink-audit-input.pptx");

auto collectContainers = [](System::SharedPtr<IPresentation> source)
{
    std::vector<System::SharedPtr<IHyperlinkContainer>> found;
    std::unordered_set<IHyperlinkContainer*> seen;
    auto addQueries = [&](System::SharedPtr<IHyperlinkQueries> queries)
    {
        auto containers = queries->GetAnyHyperlinks();
        for (const auto& container : containers)
        {
            if (seen.insert(container.get()).second) found.push_back(container);
        }
    };
    auto addScope = [&](System::SharedPtr<IBaseSlide> slide)
    {
        if (slide != nullptr) addQueries(slide->get_HyperlinkQueries());
    };
    addQueries(source->get_HyperlinkQueries());
    for (const auto& master : source->get_Masters()) addScope(master);
    for (const auto& layout : source->get_LayoutSlides()) addScope(layout);
    for (const auto& slide : source->get_Slides()) addScope(slide->get_NotesSlideManager()->get_NotesSlide());
    addScope(source->get_MasterNotesSlideManager()->get_MasterNotesSlide());
    addScope(source->get_MasterHandoutSlideManager()->get_MasterHandoutSlide());
    return found;
};

auto isHttps = [](System::String value)
{
    System::SharedPtr<System::Uri> uri;
    return System::Uri::TryCreate(value, System::UriKind::Absolute, uri) && uri->get_Scheme() == System::Uri::UriSchemeHttps;
};
auto policyViolation = [&](System::SharedPtr<IHyperlink> link) -> System::String
{
    if (link == nullptr) return u"";
    if (link->get_ActionType() == HyperlinkActionType::JumpSpecificSlide)
    {
        return link->get_TargetSlide() == nullptr ? u"Missing target slide" : u"";
    }
    if (link->get_ActionType() != HyperlinkActionType::Hyperlink) return u"Action is not allowed";
    if (!isHttps(link->get_ExternalUrl())) return u"Normalized URL is not absolute HTTPS";
    auto original = link->get_ExternalUrlOriginal();
    if (!original.IsNullOrEmpty() && !isHttps(original)) return u"Original URL is not absolute HTTPS";
    return u"";
};
auto slideIndex = [&](System::SharedPtr<IBaseSlide> slide)
{
    for (auto index = 0; index < presentation->get_Slides()->get_Count(); index++)
    {
        if (presentation->get_Slide(index) == slide) return index + 1;
    }
    return 0;
};
auto jsonString = [](System::String value)
{
    std::ostringstream escaped;
    escaped << '"';
    for (unsigned char character : value.ToUtf8String())
    {
        if (character == '"' || character == '\\') escaped << '\\' << character;
        else if (character < 0x20) escaped << "\\u" << std::hex << std::setw(4) << std::setfill('0') << static_cast<int>(character);
        else escaped << character;
    }
    escaped << '"';
    return escaped.str();
};
auto containers = collectContainers(presentation);
std::ofstream report("hyperlink-audit.json", std::ios::binary);
if (!report)
{
    System::Console::WriteLine(u"Cannot open the audit report for writing.");
    System::Environment::set_ExitCode(1);
    return;
}
auto rowCount = 0;
report << "[\n";
auto addRow = [&](System::SharedPtr<IHyperlink> link, System::String activation, System::SharedPtr<IHyperlinkContainer> container, size_t containerId)
{
    if (link == nullptr) return;
    auto component = System::AsCast<ISlideComponent>(container);
    auto ownerSlide = component != nullptr ? component->get_Slide() : nullptr;
    auto targetSlide = link->get_TargetSlide();
    auto violation = policyViolation(link);
    auto shape = System::AsCast<IShape>(container);
    auto portionFormat = System::AsCast<IPortionFormat>(container);
    auto ownerType = shape != nullptr ? System::String(u"Shape") : portionFormat != nullptr ? System::String(u"Text portion") : container->GetType().get_Name();
    auto ordinaryAction = link->get_ActionType() == HyperlinkActionType::Hyperlink || link->get_ActionType() == HyperlinkActionType::JumpSpecificSlide;
    auto ownerIndex = slideIndex(ownerSlide);
    auto targetIndex = slideIndex(targetSlide);
    if (rowCount++ != 0) report << ",\n";
    report << "  {\"ContainerId\":" << containerId;
    report << ",\"SlideIndex\":" << (ownerIndex != 0 ? std::to_string(ownerIndex) : "null");
    report << ",\"SlideId\":" << (ownerSlide != nullptr ? std::to_string(ownerSlide->get_SlideId()) : "null");
    report << ",\"Scope\":" << (ownerSlide != nullptr ? jsonString(ownerSlide->GetType().get_Name()) : "null");
    report << ",\"OwnerType\":" << jsonString(ownerType);
    report << ",\"Activation\":" << jsonString(activation);
    report << ",\"ActionType\":" << jsonString(System::ObjectExt::ToString(link->get_ActionType()));
    report << ",\"ExternalUrl\":" << jsonString(link->get_ExternalUrl());
    report << ",\"TargetSlideIndex\":" << (targetIndex != 0 ? std::to_string(targetIndex) : "null");
    report << ",\"TargetSlideId\":" << (targetSlide != nullptr ? std::to_string(targetSlide->get_SlideId()) : "null");
    report << ",\"Tooltip\":" << jsonString(link->get_Tooltip());
    report << ",\"OriginalExternalUrl\":" << (link->get_ExternalUrlOriginal() != link->get_ExternalUrl() ? jsonString(link->get_ExternalUrlOriginal()) : "null");
    report << ",\"PotentiallyUnsafe\":" << (!violation.IsNullOrEmpty() ? "true" : "false");
    report << ",\"PolicyViolation\":" << (!violation.IsNullOrEmpty() ? jsonString(violation) : "null");
    report << ",\"TargetExport\":\"PDF\",\"PotentiallyUnsupportedByExport\":" << (activation == u"mouse-over" || !ordinaryAction ? "true" : "false") << "}";
};
for (auto index = size_t{0}; index < containers.size(); index++)
{
    auto container = containers[index];
    addRow(container->get_HyperlinkClick(), u"click", container, index + 1);
    addRow(container->get_HyperlinkMouseOver(), u"mouse-over", container, index + 1);
}
report << "\n]\n";
report.close();
if (!report)
{
    System::Console::WriteLine(u"The audit report could not be written completely.");
    System::Environment::set_ExitCode(1);
    return;
}

for (const auto& container : containers)
{
    auto click = container->get_HyperlinkClick();
    if (!policyViolation(click).IsNullOrEmpty())
    {
        if (replaceExternalClicks && click->get_ActionType() == HyperlinkActionType::Hyperlink)
        {
            container->get_HyperlinkManager()->SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container->get_HyperlinkManager()->RemoveHyperlinkClick();
        }
    }
    if (!policyViolation(container->get_HyperlinkMouseOver()).IsNullOrEmpty())
    {
        container->get_HyperlinkManager()->RemoveHyperlinkMouseOver();
    }
}
presentation->Save(u"hyperlink-sanitized.pptx", SaveFormat::Pptx);
auto reopened = System::MakeObject<Presentation>(u"hyperlink-sanitized.pptx");
auto remainingContainers = collectContainers(reopened);
auto violations = 0;
for (const auto& container : remainingContainers)
{
    if (!policyViolation(container->get_HyperlinkClick()).IsNullOrEmpty()) violations++;
    if (!policyViolation(container->get_HyperlinkMouseOver()).IsNullOrEmpty()) violations++;
}
System::Console::WriteLine(u"Audit rows: {0}; prohibited actions after reopening: {1}", rowCount, violations);
if (violations != 0)
{
    System::Console::WriteLine(u"Verification failed: do not distribute the saved presentation.");
    System::Environment::set_ExitCode(1);
}
```

С созданным выше вводом отчёт содержит пять строк действий. Ссылка mouse‑over на файл и клик макроса удалены, а HTTPS‑ссылки и внутренняя навигация по слайдам остаются. Проверка выводит ноль запрещённых действий. Ввод, содержащий запрещённый внешний URL по клику, также демонстрирует ветку замены. Контейнер с разрешённым кликом и запрещённым mouse‑over сохраняет действие клика.

Эта выборочная очистка отличается от [RemoveAllHyperlinks](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), который удаляет оба типа активации во всём выбранном диапазоне независимо от политики. Проверка здесь проверяет только действия гиперссылок; она не удаляет встроенные проекты VBA, объекты OLE или другое активное содержимое и не проверяет экспортированный PDF или HTML файл.

## **FAQ**

**Как я могу связать раздел или его первый слайд?**

Разделы в PowerPoint группируют слайды, но внутренняя гиперссылка ориентируется на отдельный слайд. Чтобы создать навигацию к разделу, привяжите её к первому слайду этого раздела.

**Могу ли я привязать гиперссылку к элементам мастер‑слайда, чтобы она действовала на всех слайдах?**

Да. Элементы мастер‑слайда и макета поддерживают гиперссылки. Ссылки на этих элементах доступны во время показа на слайдах, использующих соответствующий мастер или макет.

**Сохранятся ли гиперссылки при экспорте в PDF, HTML, изображения или видео?**

Поддерживаемый экспорт в PDF и HTML может сохранять гиперссылки; растровые изображения и видео – нет. См. соображения экспорта в разделе [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).