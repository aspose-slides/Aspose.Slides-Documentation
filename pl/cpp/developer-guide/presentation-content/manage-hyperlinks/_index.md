---
title: Zarządzaj hiperłączami prezentacji w C++
linktitle: Zarządzaj hiperłączami
type: docs
weight: 20
url: /pl/cpp/manage-hyperlinks/
keywords:
- dodaj URL
- dodaj hiperłącze
- utwórz hiperłącze
- formatuj hiperłącze
- usuń hiperłącze
- zaktualizuj hiperłącze
- hiperłącze tekstowe
- hiperłącze slajdu
- hiperłącze kształtu
- hiperłącze obrazu
- hiperłącze wideo
- zmienialne hiperłącze
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Dodaj, formatuj, aktualizuj i usuwaj hiperłącza w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla C++, z przykładami w C++."
---
## **Wprowadzenie**

Hiperłącze łączy zawartość prezentacji ze stroną internetową lub lokalizacją w obrębie prezentacji. W programie PowerPoint hiperłącza zazwyczaj spełniają dwa cele:

* Otwórz stronę internetową z tekstu, kształtu lub ramki multimedialnej.
* Przejdź do innego slajdu, na przykład z spisu treści.

Aspose.Slides for C++ pozwala dodawać te linki, kontrolować ich wygląd i dźwięk, aktualizować ich ustawienia oraz usuwać je. Poniższe przykłady pokazują, jak pracować z hiperłączami na poszczególnych elementach oraz jak uzyskać dostęp do hiperłączy na poziomie prezentacji, slajdu lub ramki tekstowej.

{{% alert color="info" title="Uwaga" %}}
Możesz również edytować prezentacje za pomocą [darmowego edytora Aspose PowerPoint online](https://products.aspose.app/slides/pl/editor).
{{% /alert %}} 

## **Dodaj hiperłącza URL**

Możesz przypisać adres URL strony internetowej do tekstu, kształtu lub ramki multimedialnej. Element, któremu przypiszesz hiperłącze, określa obszar klikalny: fragment tekstu łączy zaznaczony tekst, natomiast kształt lub ramka łączy obiekt slajdu.

### **Dodaj hiperłącza URL do tekstu**

Aby połączyć tekst ze stroną internetową, utwórz [Hyperlink](https://reference.aspose.com/slides/pl/cpp/aspose.slides/hyperlink/) i przypisz go metodą [set_HyperlinkClick](https://reference.aspose.com/slides/pl/cpp/aspose.slides/portionformat/set_hyperlinkclick/) fragmentu tekstu, jak pokazano poniżej. Tylko ten fragment tekstu stanie się klikalny.

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

### **Dodaj hiperłącza URL do kształtów i ramek multimedialnych**

Aby zrobić kształt lub ramkę klikalną, użyj jego metody [set_HyperlinkClick](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/set_hyperlinkclick/). Hiperłącze należy do samego obiektu, a nie do fragmentu tekstu w jego wnętrzu.

To samo podejście stosuje się do ramek obrazu, audio i wideo: przypisz hiperłącze do ramki i użyj [set_Tooltip](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlink/set_tooltip/), aby dodać podpowiedź, jeśli jest potrzebna.

Poniższy przykład sprawia, że prostokąt jest klikalny:

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

## **Użyj hiperłączy do stworzenia spisu treści**

Wewnętrzne hiperłącza pozwalają czytelnikom przeskoczyć ze spisu treści do konkretnego slajdu. Poniższy przykład używa [SetInternalHyperlinkClick](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) do połączenia tekstu „Page 2” na pierwszym slajdzie z drugim slajdem.

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

## **Formatuj hiperłącza**

### **Kolor**

Metoda [set_ColorSource](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlink/set_colorsource/) interfejsu [IHyperlink](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlink/) określa, czy hiperłącze używa koloru hiperłącza prezentacji czy formatowania fragmentu tekstu. Aby zastosować własny kolor tekstu, wybierz [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/hyperlinkcolorsource/) i ustaw kolor wypełnienia fragmentu. Funkcja została wprowadzona w PowerPoint 2019; starsze wersje nie stosują tego ustawienia.

Poniższy przykład dodaje dwa hiperłącza tekstowe do tego samego slajdu. Pierwsze używa czerwonego wypełnienia tekstu, a drugie zachowuje domyślny kolor hiperłącza.

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

### **Dźwięk**

Hiperłącze może odtworzyć dźwięk po aktywacji lub zatrzymać już odtwarzany dźwięk. Użyj następujących metod, aby skonfigurować te zachowania:

- [IHyperlink::set_Sound](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlink/set_sound/) określa dźwięk powiązany z hiperłączem.
- [IHyperlink::set_StopSoundOnClick](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlink/set_stopsoundonclick/) kontroluje, czy aktywacja hiperłącza zatrzymuje poprzedni dźwięk.

#### **Dodaj dźwięk do hiperłącza**

Poniższy przykład ładuje `sampleaudio.wav` i powiązuje go z przyciskiem na pierwszym slajdzie. Kliknięcie przycisku odtwarza dźwięk i przechodzi do następnego slajdu. Drugi kształt na tym slajdzie zatrzymuje poprzedni dźwięk po kliknięciu, nie wykonując akcji nawigacji.

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

#### **Wyodrębnij dźwięk z hiperłącza**

Poniższy przykład otwiera prezentację utworzoną powyżej i wczytuje dźwięk hiperłącza pierwszego kształtu do pamięci przy użyciu [get_Sound](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlink/get_sound/) oraz [get_BinaryData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iaudio/get_binarydata/).

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

### **Ustawienia podpowiedzi i interakcji**

Możesz zaktualizować następujące ustawienia [IHyperlink](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlink/) przy użyciu tych metod po przypisaniu hiperłącza do tekstu lub kształtu:

- [set_Tooltip](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlink/set_tooltip/) ustawia tekst, który widz może wyświetlić jako podpowiedź dla linku.
- [set_TargetFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlink/set_targetframe/) określa docelową ramkę w ramach nadrzędnego zestawu ramek HTML, jeśli ma zastosowanie.
- [set_History](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlink/set_history/) kontroluje, czy aktywacja linku dodaje jego docelowy adres do listy przeglądanych hiperłączy.
- [set_HighlightClick](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlink/set_highlightclick/) kontroluje, czy hiperłącze jest podświetlane po kliknięciu.

## **Usuń hiperłącza z prezentacji**

Użyj [GetAnyHyperlinks](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/), aby zebrać kontenery hiperłączy, w tym linki fragmentów tekstu, przed ich zmianą. Poniższy przykład usuwa oba typy aktywacji z pierwszego slajdu. Aby usunąć tylko jeden typ, wywołaj wyłącznie [RemoveHyperlinkClick](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) lub [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/); usunięcie akcji kliknięcia nie usuwa jej odpowiednika najazdu myszą.

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

Dla bezwarunkowego usunięcia, [RemoveAllHyperlinks](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) usuwa oba typy aktywacji w wybranym zakresie jednym wywołaniem. Dla selektywnego czyszczenia i objęcia masterów, układów i notatek, zobacz [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Zbuduj kompletny inwentarz hiperłączy**

Przed dystrybucją prezentacji, sporządź inwentarz jej interaktywnych działań oraz linków internetowych. [GetAnyHyperlinks](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) zwraca obiekty [IHyperlinkContainer](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlinkcontainer/), a nie płaską listę ciągów URL. Inspekcjonuj zarówno [get_HyperlinkClick](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkclick/), jak i [get_HyperlinkMouseOver](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmouseover/) w każdym kontenerze. Są one niezależne: ten sam kontener może udostępniać obie akcje, więc pełny raport wymaga do dwóch wierszy na kontener.

Skanowanie jedynie hiperłączy na poziomie kształtu może pominąć linki dołączone do fragmentów tekstu. Zamiast tego zapytaj odpowiedni zakres i zachowaj zwrócone kontenery, aby później móc zaktualizować lub usunąć ich akcje.

### **Zapytaj zakresy prezentacji, slajdu i ramki tekstowej**

Interfejs [IHyperlinkQueries](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlinkqueries/) jest dostępny przez [IPresentation::get_HyperlinkQueries](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/get_hyperlinkqueries/), [IBaseSlide::get_HyperlinkQueries](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseslide/get_hyperlinkqueries/) oraz [ITextFrame::get_HyperlinkQueries](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/get_hyperlinkqueries/). Każdy zakres obsługuje te same zapytania:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) zwraca kontenery z akcją kliknięcia.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) zwraca kontenery z akcją najazdu myszą.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) zwraca kontenery z jedną lub obiema akcjami.

Poniższy przykład tworzy `hyperlink-audit-input.pptx` z zewnętrznym linkiem kliknięcia, linkiem najazdu na plik, wewnętrzną nawigacją slajdu, linkiem najazdu tekstu i akcją makra. Nie wykonuje żadnej z tych akcji. Te same trzy zapytania działają w każdym zakresie; liczby opisują kontenery, a nie sumy akcji. Zakres ramki tekstowej wyklucza własne linki otaczającego kształtu.

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

Dla tego przykładu, zapytania prezentacji i slajdu zwracają po trzy kontenery kliknięcia, dwa kontenery najazdu myszą i trzy kontenery z jedną z akcji. Zapytanie ramki tekstowej zwraca po jednym kontenerze w każdej kategorii.

### **Klasyfikuj akcje i cele**

Użyj [IHyperlink::get_ActionType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlink/get_actiontype/), aby zinterpretować akcję przed określeniem jej celu. Wartości [HyperlinkActionType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/hyperlinkactiontype/) obejmują więcej niż nawigację internetową:

| Wartości | Znaczenie w audycie |
| --- | --- |
| `Hyperlink` | Zewnętrzne hiperłącze; sprawdź URL i jego schemat. |
| `JumpSpecificSlide` | Nawigacja wewnętrzna do konkretnego slajdu. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Wbudowana nawigacja pokazu slajdów, rozwiązywana w kontekście pokazu. |
| `JumpEndShow`, `StartCustomSlideShow` | Zakończenie bieżącego pokazu lub uruchomienie pokazu niestandardowego. |
| `StartMacro` | Wykonaj makro. |
| `StartProgram` | Uruchom program. |
| `OpenFile`, `OpenPresentation` | Otwórz plik lub inną prezentację; traktuj osobno od adresów URL. |
| `StartStopMedia` | Rozpocznij lub zatrzymaj odtwarzanie mediów. |
| `NoAction`, `Unknown` | Brak akcji nawigacji lub nierozpoznana akcja wymagająca przeglądu. |

Odczytaj zewnętrzne cele z [get_ExternalUrl](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlink/get_externalurl/) oraz konkretne wewnętrzne cele z [get_TargetSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlink/get_targetslide/). Wewnętrzne akcje i wbudowane polecenia mogą nie mieć zewnętrznego URL; pusty URL nie oznacza braku akcji w kontenerze. Zachowaj [get_ExternalUrlOriginal](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlink/get_externalurloriginal/), gdy różni się od znormalizowanego URL, i uwzględnij podpowiedź zwróconą przez [get_Tooltip](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlink/get_tooltip/), jeśli jest dostępna.

### **Raport, sanitizacja i weryfikacja hiperłączy**

Poniższy przykład w C++ odczytuje istniejącą prezentację (użyj pliku utworzonego powyżej), zapisuje `hyperlink-audit.json`, stosuje politykę, zapisuje `hyperlink-sanitized.pptx` i otwiera go ponownie, aby ponownie sprawdzić oba typy aktywacji. Zbiera kontenery przed ich zmianą i używa tożsamości wskaźników, aby nie przetwarzać tego samego kontenera dwukrotnie. Zapytania prezentacji obejmują zwykłe slajdy; dla inwentaryzacji całego pakietu, zapytuje także wyraźnie mastery, układy, notatki oraz mastery notatek i materiałów rozdawniczych, gdy są obecne.

Raport zapisuje jedynowy indeks slajdu zaczynający się od 1 oraz [get_SlideId](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseslide/get_slideid/), o ile jest dostępny. [ISlideComponent::get_Slide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecomponent/get_slide/) dostarcza slajd właściciela dla obsługiwanych kontenerów. Mastery, układy i notatki nie mają zwykłego indeksu slajdu i są identyfikowane przez swój zakres. Kontenery kształtów i kontenery formatowania fragmentów tekstu są oznaczone osobno; inne typy kontenerów zachowują nazwę typu w czasie wykonywania. Każdy kontener otrzymuje lokalny identyfikator raportu, aby jego dwie akcje mogły być skorelowane.

Ta celowo restrykcyjna polityka aplikacji zezwala wyłącznie na bezwzględne adresy HTTPS oraz prawidłowe wewnętrzne cele slajdów. Odrzuca makra, programy, akcje plikowe, inne akcje pokazu, nieznane akcje oraz inne schematy URL. Te odrzuty są decyzjami politycznymi, a nie orzeczeniem o bezpieczeństwie Aspose.Slides. Sam protokół HTTPS nie zapewnia zaufania: dodaj listy dozwolonych hostów i inne kontrole dla swojej aplikacji. Sprawdzane są zarówno oryginalne, jak i znormalizowane zewnętrzne URL‑e. Przykład audituje metadane bez podążania za linkami ani uruchamiania akcji.

W celu naprawy, [get_HyperlinkManager](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmanager/) kontenera obsługuje [SetExternalHyperlinkClick](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) i [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Tutaj zabronione zewnętrzne linki kliknięcia są zastępowane stałą stroną docelową HTTPS; inne zabronione kliknięcia i zabronione akcje najazdu są usuwane niezależnie. Ustaw `replaceExternalClicks` na `false`, aby zamiast tego usunąć wszystkie naruszenia polityki. Wybierz stronę zastępczą zarządzaną przez aplikację przed wdrożeniem.

Flaga eksportu raportu używa konserwatywnej polityki przeglądu PDF: oznacz akcje najazdu oraz wszystko oprócz zewnętrznego linku lub konkretnego przeskoku slajdu jako potencjalnie nieobsługiwane. To wskazówka przeglądowa, a nie test możliwości lub gwarancja, że nieoznaczone linki przetrwają eksport. Obsługiwane eksporty [PDF](/slides/pl/cpp/convert-powerpoint-to-pdf/) i [HTML](/slides/pl/cpp/convert-powerpoint-to-html/) mogą zachować hiperłącza, zależnie od akcji, opcji eksportu i przeglądarki. Rasterowe [images](/slides/pl/cpp/convert-powerpoint-to-png/) i [video](/slides/pl/cpp/convert-powerpoint-to-video/) nie mogą zachować interaktywnych hiperłączy; oznacz każdą akcję przy audycie pod kątem tych wyjść.

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

Przy użyciu wejścia utworzonego powyżej, raport zawiera pięć wierszy akcji. Link najazdu na plik i kliknięcie makra zostały usunięte, podczas gdy linki HTTPS i wewnętrzna nawigacja slajdów pozostały. Weryfikacja wypisuje zero zabronionych akcji. Wejście zawierające zabroniony zewnętrzny URL kliknięcia również uruchamia gałąź zamiany. Kontener z dozwolonym kliknięciem i zabronionym najazdem zachowuje akcję kliknięcia.

To selektywne czyszczenie różni się od [RemoveAllHyperlinks](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), które usuwa oba typy aktywacji w wybranym zakresie bez względu na politykę. Weryfikacja tutaj sprawdza wyłącznie akcje hiperłączy; nie usuwa osadzonych projektów VBA, obiektów OLE ani innej treści aktywnej i nie weryfikuje wyeksportowanego pliku PDF lub HTML.

## **FAQ**

**Jak mogę połączyć się z sekcją lub jej pierwszym slajdem?**

Sekcje w PowerPoint grupują slajdy, ale wewnętrzne hiperłącze celuje w pojedynczy slajd. Aby stworzyć nawigację do sekcji, połącz się z pierwszym slajdem tej sekcji.

**Czy mogę dołączyć hiperłącze do elementów slajdu wzorcowego, aby działało na wszystkich slajdach?**

Tak. Elementy slajdu wzorcowego i układu obsługują hiperłącza. Linki na tych elementach są dostępne podczas pokazu slajdów na slajdach korzystających z odpowiedniego mastera lub układu.

**Czy hiperłącza będą zachowane przy eksporcie do PDF, HTML, obrazów lub wideo?**

Obsługiwane eksporty PDF i HTML mogą zachować hiperłącza; rasterowe obrazy i wideo nie mogą. Zobacz uwagi dotyczące eksportu w sekcji [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).