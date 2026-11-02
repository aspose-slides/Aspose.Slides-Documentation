---
title: Zarządzaj hiperłączami prezentacji w .NET
linktitle: Zarządzaj hiperłączami
type: docs
weight: 20
url: /pl/net/manage-hyperlinks/
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
- modyfikowalne hiperłącze
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dodawaj, formatuj, aktualizuj i usuwaj hiperłącza w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla .NET, z przykładami w C#."
---
## **Wstęp**

Hipertłącze łączy zawartość prezentacji ze stroną internetową lub lokalizacją w obrębie prezentacji. W programie PowerPoint hiperłącza zwykle służą dwóm celom:

* Otworzyć stronę internetową z tekstu, kształtu lub ramki multimedialnej.  
* Przejść do innego slajdu, na przykład z spisu treści.  

Aspose.Slides dla .NET umożliwia dodawanie tych linków, kontrolowanie ich wyglądu i dźwięku, aktualizowanie ich właściwości oraz usuwanie ich. Poniższe przykłady pokazują, jak pracować z hiperłączami na pojedynczych elementach oraz jak uzyskać dostęp do hiperłączy na poziomie prezentacji, slajdu lub ramki tekstowej.

{{% alert color="info" title="Note" %}}
Możesz także edytować prezentacje za pomocą [darmowego edytora Aspose PowerPoint online](https://products.aspose.app/slides/editor).
{{% /alert %}} 

## **Dodaj hiperłącza URL**

Możesz przypisać adres URL witryny do tekstu, kształtu lub ramki multimedialnej. Element, któremu przypiszesz hiperłącze, określa obszar klikalny: fragment tekstu łączy zaznaczony tekst, natomiast kształt lub ramka łączy obiekt slajdu.

W prezentacjach zawierających względne hiperłącza zobacz [Zarządzaj bazą hiperłącza](/slides/pl/net/presentation-properties/#manage-the-hyperlink-base), aby odczytać, zmienić lub wyczyścić bazę na poziomie dokumentu.

### **Dodaj hiperłącza URL do tekstu**

Aby połączyć tekst ze stroną internetową, przypisz [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink/) do właściwości [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/portionformat/hyperlinkclick/) fragmentu tekstu, jak pokazano poniżej. Tylko ten fragment tekstu staje się klikalny.

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

### **Dodaj hiperłącza URL do kształtów i ramek multimedialnych**

Aby uczynić kształt lub ramkę klikalną, ustaw jej właściwość [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/hyperlinkclick/). Hiperłącze należy do samego obiektu, a nie do fragmentu tekstu wewnątrz niego.

To samo podejście dotyczy ramek obrazu, dźwięku i wideo: przypisz hiperłącze do ramki i w razie potrzeby ustaw [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/).

Poniższy przykład sprawia, że prostokąt jest klikalny:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **Użyj hiperłączy do stworzenia spisu treści**

Wewnętrzne hiperłącza pozwalają czytelnikom przejść ze spisu treści do konkretnego slajdu. Poniższy przykład używa [SetInternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) do połączenia tekstu „Page 2” na pierwszym slajdzie z drugim slajdem.

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

## **Formatuj hiperłącza**

### **Kolor**

Właściwość [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) interfejsu [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) określa, czy hiperłącze używa koloru hiperłącza prezentacji, czy formatowania fragmentu tekstu. Aby zastosować własny kolor tekstu, wybierz [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkcolorsource/) i ustaw kolor wypełnienia fragmentu. Funkcja ta została wprowadzona w programie PowerPoint 2019; starsze wersje nie stosują tego ustawienia.

Poniższy przykład dodaje dwa hiperłącza tekstowe do tego samego slajdu. Pierwsze używa czerwonego wypełnienia tekstu, natomiast drugie zachowuje domyślny kolor hiperłącza.

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
### **Dźwięk**

Hiperłącze może odtwarzać dźwięk po aktywacji lub zatrzymać dźwięk już odtwarzany. Użyj następujących właściwości, aby skonfigurować te zachowania:

- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) określa dźwięk skojarzony z hiperłączem.  
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) kontroluje, czy aktywacja hiperłącza zatrzymuje poprzedni dźwięk.  

#### **Dodaj dźwięk do hiperłącza**

Poniższy przykład ładuje `sampleaudio.wav` i wiąże go z przyciskiem na pierwszym slajdzie. Kliknięcie przycisku odtwarza dźwięk i przechodzi do kolejnego slajdu. Drugi kształt na tym slajdzie zatrzymuje poprzedni dźwięk po kliknięciu, nie wykonując akcji nawigacji.

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

#### **Wyodrębnij dźwięk z hiperłącza**

Poniższy przykład otwiera wcześniej utworzoną prezentację i odczytuje dźwięk hiperłącza pierwszego kształtu do pamięci za pomocą [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) i [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/).

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

### **Ustawienia etykiety (Tooltip) i interakcji**

Możesz zaktualizować następujące właściwości [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) po przypisaniu hiperłącza do tekstu lub kształtu:

- [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) ustawia tekst, który podgląd może wyświetlać jako podpowiedź dla linku.  
- [TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetframe/) określa ramkę docelową w ramach nadrzędnego zestawu ramek HTML, gdy ma to zastosowanie.  
- [History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/history/) kontroluje, czy aktywacja linku dodaje jego docelowy adres do listy obejrzanych hiperłączy.  
- [highlightclick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/highlightclick/) kontroluje, czy hiperłącze jest podświetlane po kliknięciu.  

## **Usuń hiperłącza z prezentacji**

Użyj [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) aby zebrać kontenery hiperłączy, w tym linki fragmentów tekstu, przed ich zmianą. Poniższy przykład usuwa oba typy aktywacji z pierwszego slajdu. Aby usunąć tylko jeden typ, wywołaj tylko [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) lub [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/); usunięcie akcji kliknięcia nie usuwa jej odpowiednika po najechaniu myszą.

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

W przypadku bezwarunkowego usunięcia, [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) usuwa oba typy aktywacji w wybranym zakresie jednym wywołaniem. Aby wykonać selektywne czyszczenie i objąć mastery, układy i notatki, zobacz [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Zbuduj pełny spis hiperłączy**

Przed rozpowszechnieniem prezentacji należy spisać jej interaktywne akcje oraz linki internetowe. [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) zwraca obiekty [IHyperlinkContainer](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/), a nie płaską listę ciągów URL. Sprawdź zarówno [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) jak i [HyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) w każdym kontenerze. Są one niezależne: ten sam kontener może udostępniać oba rodzaje akcji, więc pełny raport wymaga do dwóch wierszy na kontener.

Skanowanie jedynie hiperłączy na poziomie kształtu może pominąć linki dołączone do fragmentów tekstu. Zamiast tego zapytaj odpowiedni zakres i zachowaj zwrócone kontenery, aby później móc zaktualizować lub usunąć ich akcje.

### **Zapytaj zakresy prezentacji, slajdu i ramki tekstowej**

Interfejs [IHyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/) jest dostępny poprzez [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/hyperlinkqueries/), i [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/). Każdy zakres obsługuje te same zapytania:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) zwraca kontenery z akcją kliknięcia.  
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) zwraca kontenery z akcją najechania myszą.  
- [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) zwraca kontenery z jedną lub obiema akcjami.  

Poniższy przykład tworzy `hyperlink-audit-input.pptx` z zewnętrznym linkiem kliknięcia, linkiem pliku po najechaniu, wewnętrzną nawigacją slajdu, linkiem tekstowym po najechaniu i akcją makra. Nie wykonuje żadnej z tych akcji. Te same trzy zapytania działają w każdym zakresie; liczby opisują kontenery, a nie sumy akcji. Zakres ramki tekstowej wyklucza własne linki otaczającego kształtu.

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

W tym przykładzie zapytania prezentacji i slajdu zgłaszają po trzy kontenery kliknięć, dwa kontenery najechań i trzy kontenery z jedną z akcji. Zapytanie ramki tekstowej zgłasza po jednym kontenerze w każdej kategorii.

### **Klasyfikuj akcje i cele**

Użyj [IHyperlink.ActionType](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/actiontype/) aby zinterpretować akcję przed interpretacją jej celu. Wartości [HyperlinkActionType](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkactiontype/) obejmują więcej niż nawigację internetową:

| Wartości | Znaczenie dla audytu |
| --- | --- |
| `Hyperlink` | Zewnętrzne hiperłącze; sprawdź URL i jego schemat. |
| `JumpSpecificSlide` | Nawigacja wewnętrzna do konkretnego slajdu. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Wbudowana nawigacja w pokaz slajdów, rozwiązywana w kontekście pokazu. |
| `JumpEndShow`, `StartCustomSlideShow` | Zakończenie bieżącego pokazu lub rozpoczęcie pokazu niestandardowego. |
| `StartMacro` | Wykonaj makro. |
| `StartProgram` | Uruchom program. |
| `OpenFile`, `OpenPresentation` | Otwórz plik lub inną prezentację; przeglądaj oddzielnie od adresów URL. |
| `StartStopMedia` | Rozpocznij lub zatrzymaj odtwarzanie multimediów. |
| `NoAction`, `Unknown` | Brak akcji nawigacji lub nieznana akcja wymagająca przeglądu. |

Odczytaj zewnętrzne cele z [ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) i konkretne wewnętrzne cele z [TargetSlide](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetslide/). Akcje wewnętrzne i wbudowane polecenia mogą nie mieć zewnętrznego URL; pusty URL nie oznacza, że kontener nie ma akcji. Zachowaj [ExternalUrlOriginal](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurloriginal/), gdy różni się od znormalizowanego URL, i uwzględnij [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/), jeśli jest dostępny.

### **Raportowanie, sanityzacja i weryfikacja hiperłączy**

Poniższy przykład .NET 6+ odczytuje istniejącą prezentację (użyj pliku utworzonego powyżej), zapisuje `hyperlink-audit.json`, stosuje politykę, zapisuje `hyperlink-sanitized.pptx` i ponownie otwiera go, aby ponownie sprawdzić oba typy aktywacji. Zbiera kontenery przed ich zmianą i używa równości referencyjnej, aby uniknąć podwójnego przetwarzania tego samego kontenera. Zapytania prezentacji obejmują zwykłe slajdy; dla spisu całego pakietu, dodatkowo explicite zapytuje mastery, układy, notatki oraz mastery notatek i notatek rozdania, jeśli występują.

Raport zapisuje indeks slajdu zaczynający się od 1 oraz [SlideId](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideid/) , jeśli dostępny. [ISlideComponent.Slide](https://reference.aspose.com/slides/net/aspose.slides/islidecomponent/slide/) dostarcza slajd właściciela dla obsługiwanych kontenerów. Mastery, układy i notatki nie mają zwykłego indeksu slajdu i są identyfikowane po ich zakresie. Kontenery kształtów i kontenery formatowania fragmentów tekstu są oznaczone osobno; inne typy kontenerów zachowują nazwę typu w czasie działania. Każdy kontener otrzymuje lokalny identyfikator raportu, aby jego dwie akcje mogły być powiązane.

Ta celowo restrykcyjna polityka aplikacji zezwala tylko na bezwzględne adresy HTTPS i prawidłowe wewnętrzne cele slajdów. Odrzuca makra, programy, akcje plikowe, inne akcje pokazu, nieznane akcje oraz inne schematy URL. Te odrzucenia są decyzjami politycznymi, a nie werdyktem bezpieczeństwa Aspose.Slides. Sam protokół HTTPS nie zapewnia zaufania: dodaj listy dozwolonych hostów i inne kontrole w aplikacji. Sprawdzane są zarówno oryginalne, jak i znormalizowane zewnętrzne adresy URL. Przykład audytuje metadane bez podążania za linkami lub wykonywania akcji.

W celu naprawy, [HyperlinkManager](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) kontenera obsługuje [SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) i [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Tutaj zakazane zewnętrzne linki kliknięć są zastępowane stałą stroną docelową HTTPS; inne zakazane kliknięcia i zakazane akcje po najechaniu są usuwane niezależnie. Ustaw `replaceExternalClicks` na `false`, aby zamiast tego usunąć wszystkie naruszenia polityki. Wybierz stronę zastępczą zarządzaną przez aplikację przed wdrożeniem.

Flaga eksportu w raporcie używa konserwatywnej polityki przeglądu PDF: oznacza akcje po najechaniu i wszystko poza zewnętrznym linkiem lub konkretnym skokiem slajdu jako potencjalnie nieobsługiwane. Jest to wskazówka przeglądu, a nie test możliwości ani gwarancja, że nieoznaczone linki przetrwają eksport. Obsługiwane eksporty [PDF](/slides/pl/net/convert-powerpoint-to-pdf/) i [HTML](/slides/pl/net/convert-powerpoint-to-html/) mogą zachować hiperłącza, w zależności od akcji, opcji eksportu i przeglądarki. Rasterowe [images](/slides/pl/net/convert-powerpoint-to-png/) i [video](/slides/pl/net/convert-powerpoint-to-video/) nie mogą zachować interaktywnych hiperłączy; oznacz każdą akcję przy audycie pod kątem tych wyjść.

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

Przy danych wejściowych utworzonych powyżej raport zawiera pięć wierszy akcji. Link pliku po najechaniu i kliknięcie makra są usunięte, podczas gdy linki HTTPS oraz wewnętrzna nawigacja slajdów pozostają. Weryfikacja wypisuje zero zakazanych akcji. Dane wejściowe zawierające zakazany zewnętrzny URL kliknięcia również uruchamiają gałąź zamiany. Kontener z dozwolonym kliknięciem i zakazanym najechaniem zachowuje akcję kliknięcia.

To selektywne czyszczenie różni się od [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), które usuwa oba typy aktywacji w całym wybranym zakresie niezależnie od polityki. Weryfikacja tutaj sprawdza tylko akcje hiperłączy; nie usuwa osadzonych projektów VBA, obiektów OLE ani innej aktywnej treści i nie weryfikuje wyeksportowanego pliku PDF lub HTML.

## **Najczęściej zadawane pytania**

**Jak mogę połączyć się z sekcją lub jej pierwszym slajdem?**

Sekcje w programie PowerPoint grupują slajdy, ale wewnętrzne hiperłącze kieruje do pojedynczego slajdu. Aby utworzyć nawigację do sekcji, połącz się z pierwszym slajdem tej sekcji.

**Czy mogę dołączyć hiperłącze do elementów slajdu master, aby działało na wszystkich slajdach?**

Tak. Elementy slajdu master i układu obsługują hiperłącza. Linki na tych elementach są dostępne podczas pokazu slajdów na slajdach korzystających z odpowiedniego mastera lub układu.

**Czy hiperłącza będą zachowane przy eksporcie do PDF, HTML, obrazów lub wideo?**

Obsługiwane eksporty PDF i HTML mogą zachować hiperłącza; obrazy rastrowe i wideo nie mogą. Zobacz uwagi dotyczące eksportu w [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).