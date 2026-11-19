---
title: Zarządzanie hiperłączami w prezentacji w .NET
linktitle: Zarządzaj hiperłączami
type: docs
weight: 20
url: /pl/net/manage-hyperlinks/
keywords:
- dodaj URL
- dodaj hiperłącze
- utwórz hiperłącze
- formatowanie hiperłącza
- usuń hiperłącze
- aktualizuj hiperłącze
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
## **Wprowadzenie**

Hyperlink łączy treść prezentacji ze stroną internetową lub miejscem w obrębie prezentacji. W programie PowerPoint hiperlinki zazwyczaj służą dwóm celom:

* Otworzyć stronę internetową z tekstu, kształtu lub ramki multimedialnej.
* Przejść do innego slajdu, np. z tabeli treści.

Aspose.Slides for .NET umożliwia dodawanie tych linków, kontrolowanie ich wyglądu i dźwięku, aktualizowanie ich właściwości oraz ich usuwanie. Poniższe przykłady pokazują, jak pracować z hiperlinkami na poszczególnych elementach oraz jak uzyskać dostęp do hiperlinków na poziomie prezentacji, slajdu lub ramki tekstowej.

{{% alert color="info" title="Note" %}}
Możesz także edytować prezentacje za pomocą [darmowego internetowego edytora Aspose PowerPoint](https://products.aspose.app/slides/editor).
{{% /alert %}}

## **Dodawanie hiperlinków URL**

Możesz przypisać adres URL strony internetowej do tekstu, kształtu lub ramki multimedialnej. Element, któremu przypiszesz hiperlink, określa klikany obszar: fragment tekstu łączy wybrany tekst, natomiast kształt lub ramka łączy obiekt slajdu.

W prezentacjach zawierających względne hiperlinki zobacz [Zarządzanie podstawą hiperlinków](/slides/pl/net/presentation-properties/#manage-the-hyperlink-base), aby odczytać, zmienić lub wyczyścić podstawę na poziomie dokumentu.

### **Dodawanie hiperlinków URL do tekstu**

Aby połączyć tekst ze stroną internetową, przypisz [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink/) do właściwości [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/portionformat/hyperlinkclick/) fragmentu tekstu, jak pokazano poniżej. Tylko ten fragment tekstu stanie się klikalny.

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

### **Dodawanie hiperlinków URL do kształtów i ramek multimedialnych**

Przypisz adres URL do właściwości [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/hyperlinkclick/) prostokąta, aby cały jego obszar był klikalny. [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) daje czytelnikom podpowiedź o miejscu docelowym, gdy najadą myszą na prostokąt. Te same właściwości mają zastosowanie do ramek obrazu, audio i wideo.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **Użycie hiperlinków do tworzenia spisu treści**

Hiperlinki wewnętrzne pozwalają czytelnikom przeskoczyć ze spisu treści do konkretnego slajdu. Poniższy przykład używa [SetInternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/), aby połączyć tekst „Page 2” na pierwszym slajdzie z drugim slajdem.

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

## **Formatowanie hiperlinków**

Możesz zmienić kolor połączonego tekstu, odtwarzać lub zatrzymywać dźwięk, gdy czytelnik aktywuje link, oraz ustawić podpowiedź (tooltip), która pojawia się po najechaniu.

### **Kolor**

Właściwość [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) interfejsu [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) określa, czy hiperlink używa koloru hiperlinku prezentacji, czy formatowania fragmentu tekstu. Aby zastosować własny kolor tekstu, wybierz [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkcolorsource/) i ustaw kolor wypełnienia fragmentu. Funkcja ta została wprowadzona w PowerPoint 2019; starsze wersje nie stosują tego ustawienia.

W tym przykładzie ustawienie [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) w pierwszym linku powoduje, że jego tekst jest czerwony. Drugi link zachowuje kolor hiperlinku prezentacji.

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

Hiperlink może odtwarzać dźwięk po aktywacji lub zatrzymywać już odtwarzany dźwięk. Użyj następujących właściwości, aby skonfigurować te zachowania:

- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) określa dźwięk powiązany z hiperlinkiem.
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) kontroluje, czy aktywacja hiperlinku zatrzymuje poprzedni dźwięk.

#### **Dodanie dźwięku do hiperlinku**

Przycisk na pierwszym slajdzie używa [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) do odtwarzania dźwięku z pliku WAV po kliknięciu przez czytelnika. Na drugim slajdzie osobny przycisk używa [StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) do zatrzymania odtwarzania i pozostawienia czytelnika na tym slajdzie.

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

#### **Wyodrębnienie dźwięku z hiperlinku**

Poniższy przykład otwiera wcześniej utworzoną prezentację i odczytuje dźwięk hiperlinku pierwszego kształtu do pamięci przy użyciu [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) i [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/).

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

### **Ustawienia podpowiedzi i interakcji**

Możesz zaktualizować następujące właściwości [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) po przypisaniu hiperlinku do tekstu lub kształtu:

- [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) ustawia tekst, który widz może wyświetlić jako podpowiedź dla linku.
- [TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetframe/) określa docelową ramkę w ramach nadrzędnego zestawu ramek HTML, gdy ma to zastosowanie.
- [History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/history/) kontroluje, czy aktywacja linku dodaje jego miejsce docelowe do listy przeglądanych hiperlinków.
- [HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/highlightclick/) kontroluje, czy hiperlink jest podświetlany po kliknięciu.

## **Usuwanie hiperlinków z prezentacji**

Użyj [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/), aby zebrac kontenery hiperlinków, w tym linki fragmentów tekstu, przed ich zmianą. Poniższy przykład usuwa oba typy aktywacji z pierwszego slajdu. Aby usunąć tylko jeden typ, wywołaj jedynie [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) lub [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/); usunięcie akcji kliknięcia nie usuwa odpowiadającej akcji najazdu myszą.

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

Do bezwarunkowego usunięcia, [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) usuwa oba typy aktywacji w wybranym zasięgu w jednym wywołaniu. Aby wykonać selektywne czyszczenie i objąć mastery, układy i notatki, zobacz [Raportowanie, sanitowanie i weryfikacja hiperlinków](#report-sanitize-and-verify-hyperlinks).

### **Usuwanie hiperlinków przed zamianą tekstu SmartArt**

Podczas zamiany akapitu w istniejącym węźle SmartArt, wyczyszczenie jego fragmentów tekstu może pozostawić aktywny stary hiperlink. Pobierz akapit za pomocą [ISmartArtNode.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/textframe/). Przed wyczyszczeniem fragmentów, wywołaj [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) przez [HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/) na ramce tekstowej kształtu węzła, który wyświetla akapit. To usuwa każdy hiperlink w tej ramce, włącznie z linkami w innych akapitach.

Przykład zakłada, że trzeci kształt na pierwszym slajdzie jest grafiką SmartArt. Zastępuje pierwszy akapit czwartego węzła. W tej prezentacji pierwszy kształt węzła wyświetla ten akapit.

Po dodaniu obu fragmentów przykład odczytuje ich skuteczne formatowanie przy użyciu [GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/). Skuteczna właściwość [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/iportionformateffectivedata/hyperlinkclick/) zwraca nowy hiperlink dla pierwszego fragmentu oraz `null` dla drugiego.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("SmartArtHyperlink.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt)slide.Shapes[2];
var node = smartArt.AllNodes[3];
var paragraph = node.TextFrame.Paragraphs[0];

node.Shapes[0].TextFrame.HyperlinkQueries.RemoveAllHyperlinks();
paragraph.Portions.Clear();

var link = new Portion("New reference");
link.PortionFormat.HyperlinkClick = new Hyperlink("https://example.com/new");
paragraph.Portions.Add(link);
var text = new Portion(" (updated)");
paragraph.Portions.Add(text);

Console.WriteLine(link.PortionFormat.GetEffective().HyperlinkClick.ExternalUrl); // https://example.com/new
Console.WriteLine(text.PortionFormat.GetEffective().HyperlinkClick?.ToString() ?? "null"); // null
```

## **Zbudowanie pełnego spisu hiperlinków**

Przed rozpowszechnieniem prezentacji należy spisać jej interaktywne działania oraz linki internetowe. [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) zwraca obiekty [IHyperlinkContainer](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/), a nie płaską listę ciągów URL. Sprawdź zarówno [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) jak i [HyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) w każdym kontenerze. Są one niezależne: ten sam kontener może udostępniać obie akcje, więc pełny raport wymaga do dwóch wierszy na kontener.

Skanowanie tylko hiperlinków na poziomie kształtów może pominąć linki dołączone do fragmentów tekstu. Zamiast tego zapytaj odpowiedni zakres i zachowaj zwrócone kontenery, aby później móc aktualizować lub usuwać ich akcje.

### **Zapytania o zakresy prezentacji, slajdu i ramki tekstowej**

Interfejs [IHyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/) jest dostępny poprzez [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/hyperlinkqueries/) oraz [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/). Każdy zakres obsługuje te same zapytania:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) zwraca kontenery z akcją kliknięcia.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) zwraca kontenery z akcją najazdu myszą.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) zwraca kontenery z jedną lub obiema akcjami.

Ten przykład przypisuje akcje kliknięcia i najazdu myszą do kształtu i jego tekstu oraz akcję makra do osobnego przycisku. Porównuje kontenery zwrócone przez [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) z liczbami dla każdego typu aktywacji. Zapytanie ramki tekstowej liczy tylko linki w tekście. Własne akcje otaczającego kształtu pojawiają się w zapytaniach slajdu i prezentacji.

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

Dla tego przykładu zapytania prezentacji i slajdu zgłaszają po trzy kontenery kliknięcia, dwa kontenery najazdu myszą i trzy kontenery z jedną z akcji. Zapytanie ramki tekstowej zgłasza po jednym kontenerze w każdej kategorii.

### **Klasyfikacja akcji i docelowych lokalizacji**

Użyj [IHyperlink.ActionType](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/actiontype/), aby zinterpretować akcję przed interpretacją jej docelowego miejsca. Wartości [HyperlinkActionType](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkactiontype/) obejmują więcej niż nawigację internetową:

| Values | Znaczenie w audycie |
| --- | --- |
| `Hyperlink` | Zewnętrzny hiperlink; sprawdź URL i jego schemat. |
| `JumpSpecificSlide` | Wewnętrzna nawigacja do konkretnego slajdu. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Wbudowana nawigacja pokazu slajdów, rozwiązywana w kontekście pokazu. |
| `JumpEndShow`, `StartCustomSlideShow` | Zakończenie bieżącego pokazu lub rozpoczęcie pokazu niestandardowego. |
| `StartMacro` | Uruchomienie makra. |
| `StartProgram` | Uruchomienie programu. |
| `OpenFile`, `OpenPresentation` | Otwórz plik lub inną prezentację; przeglądaj oddzielnie od adresów URL w sieci. |
| `StartStopMedia` | Rozpoczęcie lub zatrzymanie odtwarzania multimediów. |
| `NoAction`, `Unknown` | Brak akcji nawigacyjnej lub nieznana akcja wymagająca przeglądu. |

Odczytuj zewnętrzne miejsca docelowe z [ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) oraz konkretne wewnętrzne miejsca docelowe z [TargetSlide](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetslide/). Wewnętrzne akcje i wbudowane polecenia mogą nie mieć zewnętrznego URL; pusty URL nie oznacza, że kontener nie ma akcji. Zachowaj [ExternalUrlOriginal](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurloriginal/), gdy różni się od znormalizowanego URL, i uwzględnij [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/), gdy jest dostępny.

### **Raportowanie, sanitacja i weryfikacja hiperlinków**

Ten przykład .NET 6+ otwiera prezentację z poprzedniego przykładu i zapisuje jeden rekord JSON dla każdej akcji. Używa [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/), aby zebrać kontenery na zwykłych slajdach, masterach, układach i notatkach, w tym mastery notatek i materiałów pomocniczych, gdy są obecne. Używa równości referencyjnej, aby policzyć każdy kontener raz, stosuje poniższą politykę i ponownie otwiera zapisaną prezentację, aby sprawdzić akcje kliknięcia i najazdu myszą.

Raport rejestruje indeks slajdu zaczynający się od 1 oraz [SlideId](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideid/), jeśli dostępny. [ISlideComponent.Slide](https://reference.aspose.com/slides/net/aspose.slides/islidecomponent/slide/) dostarcza slajd właściciela dla obsługiwanych kontenerów. Mastery, układy i notatki nie mają zwykłego indeksu slajdu i są identyfikowane przez ich zakres. Kontenery kształtów i formatowania fragmentów tekstu są oznaczone osobno; inne typy kontenerów zachowują nazwę typu w czasie wykonywania. Każdy kontener otrzymuje lokalny identyfikator raportu, aby jego dwie akcje można było powiązać.

Ta celowo restrykcyjna polityka aplikacji dopuszcza tylko bezwzględne adresy HTTPS oraz prawidłowe wewnętrzne cele slajdów. Odrzuca makra, programy, akcje plikowe, inne akcje pokazu slajdów, nieznane akcje oraz inne schematy URL. Te odrzucenia są decyzjami politycznymi, a nie werdyktem bezpieczeństwa Aspose.Slides. Same HTTPS nie zapewniają zaufania: dodaj listy dozwolonych hostów i inne kontrole w swojej aplikacji. Sprawdzane są zarówno oryginalne, jak i znormalizowane zewnętrzne URL. Przykład audytuje metadane bez podążania za linkami czy uruchamiania akcji.

W celu naprawy, [HyperlinkManager](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) kontenera obsługuje [SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) i [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Tutaj zabronione zewnętrzne linki kliknięcia są zastępowane stałą stroną docelową HTTPS; inne zabronione kliknięcia i akcje najazdu myszą są usuwane niezależnie. Ustaw `replaceExternalClicks` na `false`, aby zamiast tego usunąć wszystkie naruszenia polityki. Wybierz stronę zastępczą należącą do aplikacji przed wdrożeniem.

Flaga eksportu raportu używa konserwatywnej polityki przeglądu PDF: oznacza akcje najazdu myszą oraz wszystko oprócz zewnętrznego linku lub konkretnego skoku slajdu jako potencjalnie nieobsługiwane. To wskazówka przeglądu, a nie test możliwości ani gwarancja, że nieoznaczone linki przetrwają eksport. Obsługiwane eksporty do [PDF](/slides/pl/net/convert-powerpoint-to-pdf/) i [HTML](/slides/pl/net/convert-powerpoint-to-html/) mogą zachować hiperlinki, w zależności od akcji, opcji eksportu i przeglądarki. Rasterowe [images](/slides/pl/net/convert-powerpoint-to-png/) i [video](/slides/pl/net/convert-powerpoint-to-video/) nie mogą zachować interaktywnych hiperlinków; oznacz każdą akcję przy audycie pod kątem tych wyjść.

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

Przy danych wejściowych utworzonych powyżej raport zawiera pięć wierszy akcji. Link najazdu myszą na plik i kliknięcie makra są usunięte, podczas gdy linki HTTPS i wewnętrzna nawigacja slajdów pozostają. Weryfikacja wypisuje zero niedozwolonych akcji. Dane wejściowe zawierające niedozwolony zewnętrzny URL kliknięcia również uruchamiają gałąź zastępowania. Kontener z dozwolonym kliknięciem i zabronionym najazdem myszą zachowuje akcję kliknięcia.

To selektywne czyszczenie różni się od [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), które usuwa oba typy aktywacji w całym wybranym zakresie bez względu na politykę. Weryfikacja tutaj sprawdza tylko akcje hiperlinków; nie usuwa osadzonych projektów VBA, obiektów OLE ani innej aktywnej zawartości i nie weryfikuje wyeksportowanego pliku PDF lub HTML.

## **FAQ**

**Jak mogę połączyć się z sekcją lub jej pierwszym slajdem?**

Sekcje w PowerPoint grupują slajdy, ale wewnętrzny hiperlink celuje w pojedynczy slajd. Aby utworzyć nawigację do sekcji, połącz się z pierwszym slajdem tej sekcji.

**Czy mogę dołączyć hiperlink do elementów master slajdu, aby działał na wszystkich slajdach?**

Tak. Elementy master slajdu i układu obsługują hiperlinki. Linki na tych elementach są dostępne podczas pokazu slajdów na slajdach korzystających z odpowiadającego mastera lub układu.

**Czy hiperlinki zostaną zachowane przy eksporcie do PDF, HTML, obrazów lub wideo?**

Obsługiwane eksporty do PDF i HTML mogą zachować hiperlinki; obrazy rastrowe i wideo nie mogą. Zobacz rozważania dotyczące eksportu w [Raportowanie, sanitacja i weryfikacja hiperlinków](#report-sanitize-and-verify-hyperlinks).