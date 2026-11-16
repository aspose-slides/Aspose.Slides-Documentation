---
title: Pobieranie i aktualizacja właściwości widoku prezentacji w .NET
linktitle: Właściwości widoku
type: docs
weight: 80
url: /pl/net/presentation-view-properties/
keywords:
- właściwości widoku
- widok normalny
- zawartość konspektu
- ikony konspektu
- przyciąganie pionowego podziału
- pojedynczy widok
- stan paska
- rozmiar wymiaru
- automatyczne dopasowanie
- domyślne powiększenie
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Użyj Aspose.Slides dla .NET, aby skonfigurować układ widoku normalnego, powiększenie slajdu i notatek, odstęp siatki oraz widoczność komentarzy w prezentacjach PowerPoint."
---
## **Wstęp**

W normalnym widoku programu PowerPoint slajd wyświetlany jest pomiędzy bocznym panelem miniatur lub konspektem a panelem notatek poniżej. Aspose.Slides dla .NET udostępnia zapisane preferencje edycji prezentacji poprzez [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/). Obejmują one układ paneli, poziomy powiększenia, rozmieszczenie siatki oraz widoczność komentarzy.

## **O INormalViewProperties**

Użyj [NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/normalviewproperties/) aby uzyskać dostęp do interfejsu [INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/). [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) kontroluje, czy ikony pojawiają się obok tytułów slajdów w konspekcie. [SnapVerticalSplitter](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/snapverticalsplitter/) pozwala, aby boczny panel przyciągał się do stanu zminimalizowanego, gdy użytkownik go zwęża. [PreferSingleView](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/prefersingleview/) wskazuje preferencję wyświetlania jednego panelu w całym oknie.

[VerticalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/verticalbarstate/) kontroluje podziałkę pomiędzy bocznym panelem a slajdem. [HorizontalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/horizontalbarstate/) kontroluje podziałkę nad panelem notatek. Oba przyjmują wartość [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype/) równą `Minimized`, `Maximized` lub `Restored`.

## **O przywracaniu INormalViewProperties**

Kiedy podziałka jest przywrócona, [RestoredLeft](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredleft/) podaje zapisaną wielkość bocznego panelu, a [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) podaje zapisaną wielkość górnego obszaru slajdu. Oba udostępniają [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/). Jego właściwość [DimensionSize](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/dimensionsize/) przyjmuje procent od 0 do 100, a [AutoAdjust](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/autoadjust/) kontroluje, czy edytor dostosowuje rozmiar po zmianie rozmiaru okna.

Ten przykład aktualizuje istniejącą prezentację. Przywraca poziomą podziałkę, ustawia [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) na 80% z włączonym automatycznym dostosowaniem i maksymalizuje pionową podziałkę. Włącza również [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) dla widoku konspektu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var normalView = presentation.ViewProperties.NormalViewProperties;
normalView.HorizontalBarState = SplitterBarStateType.Restored;
normalView.VerticalBarState = SplitterBarStateType.Maximized;
normalView.RestoredTop.AutoAdjust = true;
normalView.RestoredTop.DimensionSize = 80;
normalView.ShowOutlineIcons = true;

presentation.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
```

## **Ustaw domyślną wartość powiększenia**

[SlideViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/slideviewproperties/) i [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/notesviewproperties/) przechowują niezależne ustawienia powiększenia dla edytora. Ustawienia te nie wpływają na wymiary slajdu, odtwarzanie pokazu slajdów ani rozdzielczość eksportu obrazu.

Ten przykład otwiera istniejącą prezentację i włącza [VariableScale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/variablescale/) , aby dopasować slajd do okna edycji. Dla strony notatek wyłącza automatyczne skalowanie i ustawia [Scale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/scale/) na stałe powiększenie 80%.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
viewProperties.SlideViewProperties.VariableScale = true;
viewProperties.NotesViewProperties.VariableScale = false;
viewProperties.NotesViewProperties.Scale = 80;

presentation.Save("zoom.pptx", SaveFormat.Pptx);
```

## **Ustaw odstęp siatki**

[GridSpacing](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/gridspacing/) ustawia odległość między liniami siatki edycji w całej prezentacji. Przyjmuje dodatnią wartość w punktach, przy 72 punktach na cal. Ten przykład wyświetla bieżący odstęp w istniejącej prezentacji i zapisuje siatkę o szerokości ćwierć cala, ustawiając interwał na 18 punktów.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current grid spacing: {viewProperties.GridSpacing} points");

viewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

Siatka powtarza się w stałym odstępie. [Drawing guides](/slides/pl/net/drawing-guides/) oznaczają pojedyncze pozycje poziome lub pionowe. Oba są pomocnikami edycji i pojawiają się tylko w edytorach, które je wyświetlają. Pokazy slajdów oraz eksport do PDF, obrazów lub SVG ich nie uwzględniają.

## **Pokaż lub ukryj komentarze przy otwieraniu prezentacji**

[ShowComments](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/showcomments/) przechowuje preferencję, którą zgodne edytory używają przy otwieraniu prezentacji. Dla istniejącej prezentacji z komentarzami ten przykład wyświetla bieżące ustawienie i zapisuje kopię z ukrytymi komentarzami. Ustawia również [LastView](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/lastview/) na [ViewType.SlideView](https://reference.aspose.com/slides/net/aspose.slides/viewtype/), aby kopia otworzyła się w widoku slajdu.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current comment visibility: {viewProperties.ShowComments}");

viewProperties.ShowComments = NullableBool.False;
viewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

Ukrywanie komentarzy zachowuje ich tekst, autorów, pozycje, odpowiedzi i statusy. Aby zmienić same komentarze, zobacz [Presentation Comments](/slides/pl/net/presentation-comments/). Ustawienia eksportu kontrolują, czy komentarze pojawiają się w PDF, HTML, obrazach, notatkach lub materiach rozdawniczych.

## **FAQ**

**Dlaczego siatka jest ukryta, gdy ponownie otwieram prezentację?**  
Prezentacja przechowuje interwał siatki. Aby zobaczyć siatkę, włącz jej widoczność w edytorze.

**Czy usunięcie prowadnic rysunkowych zmienia odstęp siatki?**  
Nie. Dodanie, przemieszczenie lub usunięcie prowadnicy nie zmienia interwału siatki.

**Czy różne sekcje prezentacji mogą mieć różne ustawienia widoku?**  
Nie. [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) ma zastosowanie do całej prezentacji.

**Czy mogę zapisać różne ustawienia widoku dla różnych użytkowników?**  
Plik przechowuje jeden zestaw właściwości widoku dla wszystkich. Edytor może również stosować lokalne preferencje użytkownika.

**Czy mogę zapisać ustawienia widoku w szablonie?**  
Tak. Prezentacje utworzone z szablonu dziedziczą jego zapisane ustawienia widoku.