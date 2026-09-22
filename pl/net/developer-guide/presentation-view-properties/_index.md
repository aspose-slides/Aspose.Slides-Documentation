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
- przyciąganie pionowego podziałnika
- widok pojedynczy
- stan paska
- rozmiar wymiaru
- automatyczne dopasowanie
- domyślne przybliżenie
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Odkryj właściwości widoku Aspose.Slides dla .NET, aby dostosować formaty slajdów PPT, PPTX i ODP — modyfikować układy, poziomy przybliżenia i ustawienia wyświetlania."
---
## **Wprowadzenie**

Widok normalny składa się z trzech obszarów treści: samego slajdu, bocznego obszaru treści oraz dolnego obszaru treści. Właściwości dotyczące pozycjonowania różnych obszarów treści. Informacje te pozwalają aplikacji zapisać stan widoku w pliku, tak aby po ponownym otwarciu widok znajdował się w takim samym stanie, w jakim prezentacja została ostatnio zapisana.

Właściwość [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/iviewproperties/properties/normalviewproperties) została dodana, aby zapewnić dostęp do właściwości widoku normalnego prezentacji.

Interfejsy [INormalViewProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/inormalviewrestoredproperties) oraz ich pochodne, a także wyliczenie [SplitterBarStateType](https://reference.aspose.com/slides/pl/net/aspose.slides/splitterbarstatetype) zostały dodane.

## **O INormalViewProperties**

Reprezentuje właściwości widoku normalnego.

Właściwość **ShowOutlineIcons** określa, czy aplikacja powinna wyświetlać ikony podczas wyświetlania treści konspektu w którymkolwiek z obszarów treści trybu widoku normalnego.

Właściwość **SnapVerticalSplitter** określa, czy pionowy podziałnik powinien przejść do stanu zminimalizowanego, gdy boczny obszar jest wystarczająco mały.

Właściwość **PreferSingleView** określa, czy użytkownik preferuje widok pełnoekranowy jednego obszaru treści zamiast standardowego widoku normalnego z trzema obszarami treści. Gdy jest włączona, aplikacja może wyświetlić jeden z obszarów w całym oknie.

Właściwości **VerticalBarState** i **HorizontalBarState** określają stan, w jakim powinien być wyświetlany odpowiednio pionowy lub poziomy pasek podziału. Pionowy pasek oddziela slajd od bocznego obszaru treści, poziomy od obszaru pod slajdem. Dostępne wartości: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** oraz **SplitterBarStateType.Restored**.

Właściwości **RestoredLeft** i **RestoredTop** określają rozmiar górnego lub bocznego obszaru slajdu w widoku normalnym, gdy dla **VerticalBarState** i **HorizontalBarState** zastosowano wartość **SplitterBarStateType.Restored**.

## **O przywracaniu INormalViewProperties**

Określa rozmiar obszaru slajdu (szerokość, gdy jest dzieckiem RestoredTop, wysokość, gdy jest dzieckiem RestoredLeft) w widoku normalnym, gdy obszar ma zmienny rozmiar przywrócony (niezminimalizowany ani zmaksymalizowany).

Właściwość **DimensionSize** określa rozmiar obszaru slajdu (szerokość, gdy jest dzieckiem restoredTop, wysokość, gdy jest dzieckiem restoredLeft).

Właściwość **AutoAdjust** określa, czy boczny obszar treści powinien automatycznie dostosowywać się do nowego rozmiaru przy zmianie rozmiaru okna zawierającego widok w aplikacji.

Przykład poniżej pokazuje, jak uzyskać dostęp do właściwości **ViewProperties.NormalViewProperties** prezentacji.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // Przywróć właściwości widoku prezentacji
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **Ustaw domyślną wartość przybliżenia**

Aspose.Slides for .NET obsługuje teraz ustawianie domyślnej wartości przybliżenia dla prezentacji, tak aby po otwarciu prezentacji przybliżenie było już ustawione. Można to zrobić, ustawiając [ViewProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/viewproperties) prezentacji. Właściwości widoku slajdu oraz [NotesViewProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/viewproperties/properties/notesviewproperties) można ustawić programowo. W tym temacie zobaczymy na przykładzie, jak ustawić właściwości widoku prezentacji w Aspose.Slides.

Aby ustawić właściwości widoku, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation)
1. Ustaw [Properties](https://reference.aspose.com/slides/pl/net/aspose.slides/viewproperties) widoku prezentacji
1. Zapisz prezentację jako plik PPTX

W przykładzie poniżej ustawiono wartość przybliżenia zarówno dla widoku slajdu, jak i widoku notatek.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Ustawianie właściwości widoku prezentacji
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Wartość przybliżenia w procentach dla widoku slajdu
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Wartość przybliżenia w procentach dla widoku notatek 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **Ustaw odstępy siatki**

Użyj [Presentation.ViewProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/viewproperties/) aby uzyskać dostęp do ustawień widoku obowiązujących w całej prezentacji. Właściwość [IViewProperties.GridSpacing](https://reference.aspose.com/slides/pl/net/aspose.slides/iviewproperties/gridspacing/) odczytuje lub zmienia odstęp fundamentu siatki edycyjnej. Ustawienie to ma zastosowanie do całej prezentacji, a nie do pojedynczego slajdu. Odstęp siatki podawany jest w punktach, gdzie 72 punkty to jedna jard. Używaj wartości dodatniej, zgodnie z dokumentacją API.

W poniższym przykładzie otwieramy istniejący plik `demo.pptx`, wyświetlamy bieżący odstęp siatki, ustawiamy odstęp ćwierć cala i zapisujemy wynik.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");
var gridSpacing = presentation.ViewProperties.GridSpacing;
Console.WriteLine($"Current grid spacing: {gridSpacing} points");

presentation.ViewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

Siatka różni się od [drawing guides](/slides/pl/net/drawing-guides/). Odstęp siatki kontroluje regularny interwał, natomiast prowadnice są indywidualnie pozycjonowanymi liniami wyrównania poziomego lub pionowego. Dodawanie, przesuwanie lub usuwanie prowadnic nie zmienia odstępu siatki.

Zarówno siatka, jak i prowadnice są pomocą edycyjną. Nie są renderowane jako zawartość slajdu w formatach PDF, obrazy, SVG ani podczas pokazu slajdów. Przechowywanie ustawienia odstępu siatki nie gwarantuje, że edytor wyświetli siatkę: jej widoczność zależy również od preferencji przeglądarki lub edytora.

## **FAQ**

**Dlaczego siatka nie jest widoczna po ponownym otwarciu prezentacji?**

Plik przechowuje ustawienie odstępu siatki, ale to edytor decyduje, czy siatka jest wyświetlana. Sprawdź ustawienia widoczności siatki w edytorze.

**Czy usunięcie prowadnic zmienia odstęp siatki?**

Nie. Prowadnice i odstęp siatki to niezależne ustawienia. Usunięcie prowadnic nie zmienia zapisanego interwału siatki.

**Czy mogę ustawić różne ustawienia widoku dla różnych sekcji prezentacji?**

[View settings](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/viewproperties/) są definiowane na poziomie prezentacji ([Normal View](https://reference.aspose.com/slides/pl/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/pl/net/aspose.slides/viewproperties/slideviewproperties/)), a nie na poziomie sekcji, więc jeden zestaw parametrów obowiązuje w całym dokumencie przy otwarciu.

**Czy mogę zdefiniować różne stany widoku dla różnych użytkowników?**

Nie. Ustawienia są przechowywane w pliku i są współdzielone. Aplikacje przeglądające mogą honorować preferencje użytkownika, ale sam plik zawiera jeden zestaw właściwości widoku.

**Czy mogę przygotować szablon z predefiniowanymi właściwościami widoku, aby nowe prezentacje otwierały się w ten sam sposób?**

Tak. Ponieważ [view properties](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/viewproperties/) są przechowywane na poziomie prezentacji, możesz osadzić je w szablonie i tworzyć nowe dokumenty z tym samym początkowym układem widoku.