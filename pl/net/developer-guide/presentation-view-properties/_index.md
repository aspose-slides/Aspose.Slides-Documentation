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
description: "Odkryj właściwości widoku Aspose.Slides dla .NET, aby dostosować formaty slajdów PPT, PPTX i ODP — regulować układy, poziomy powiększenia i ustawienia wyświetlania."
---
## **Wprowadzenie**

Widok normalny składa się z trzech obszarów treści: samego slajdu, bocznego obszaru treści oraz dolnego obszaru treści. Właściwości dotyczące pozycjonowania poszczególnych obszarów treści. Ta informacja pozwala aplikacji zapisać stan widoku do pliku, tak aby po ponownym otwarciu widok znajdował się w tym samym stanie, co w momencie ostatniego zapisu prezentacji.

Dodano właściwość [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/iviewproperties/properties/normalviewproperties), aby zapewnić dostęp do właściwości widoku normalnego prezentacji.

Dodano interfejsy [INormalViewProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/inormalviewrestoredproperties) oraz ich pochodne, a także enum [SplitterBarStateType](https://reference.aspose.com/slides/pl/net/aspose.slides/splitterbarstatetype).

## **O INormalViewProperties**

Reprezentuje właściwości widoku normalnego.

Właściwość **ShowOutlineIcons** określa, czy aplikacja powinna wyświetlać ikony przy wyświetlaniu treści konspektu w dowolnym z obszarów treści trybu widoku normalnego.

Właściwość **SnapVerticalSplitter** określa, czy pionowy podziałnik powinien przełączać się do stanu zminimalizowanego, gdy boczny obszar jest wystarczająco mały.

Właściwość **PreferSingleView** określa, czy użytkownik woli widzieć pełnoekranowy pojedynczy obszar treści zamiast standardowego widoku normalnego z trzema obszarami treści. Jeśli jest włączona, aplikacja może wyświetlić jeden z obszarów treści na całym oknie.

Właściwości **VerticalBarState** i **HorizontalBarState** określają stan, w jakim powinien być wyświetlany odpowiednio pionowy lub poziomy pasek podziału. Pasek poziomy oddziela slajd od obszaru treści pod slajdem, pasek pionowy oddziela slajd od bocznego obszaru treści. Dostępne wartości to: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** oraz **SplitterBarStateType.Restored**.

Właściwości **RestoredLeft** i **RestoredTop** określają rozmiar górnego lub bocznego obszaru slajdu w widoku normalnym, gdy dla **VerticalBarState** i **HorizontalBarState** zastosowano wartość **SplitterBarStateType.Restored**.

## **O przywracaniu INormalViewProperties**

Określa rozmiar obszaru slajdu (szerokość, gdy jest dzieckiem RestoredTop, wysokość, gdy jest dzieckiem RestoredLeft) w widoku normalnym, gdy obszar ma zmienny rozmiar przywrócony (nie zminimalizowany ani zmaksymalizowany).

Właściwość **DimensionSize** określa rozmiar obszaru slajdu (szerokość, gdy jest dzieckiem restoredTop, wysokość, gdy jest dzieckiem restoredLeft).

Właściwość **AutoAdjust** określa, czy rozmiar bocznego obszaru treści powinien kompensować nowy rozmiar przy zmianie rozmiaru okna zawierającego widok w aplikacji.

Poniżej podano przykład, który pokazuje, jak uzyskać dostęp do właściwości **ViewProperties.NormalViewProperties** prezentacji.

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

## **Ustaw domyślną wartość powiększenia**

Aspose.Slides dla .NET obsługuje teraz ustawianie domyślnej wartości powiększenia dla prezentacji, tak aby po jej otwarciu powiększenie było już ustawione. Można to zrobić, ustawiając [ViewProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/viewproperties) prezentacji. Właściwości widoku slajdu oraz [NotesViewProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/viewproperties/properties/notesviewproperties) mogą być ustawiane programowo. W tym temacie pokażemy na przykładzie, jak ustawić właściwości widoku prezentacji w Aspose.Slides.

Aby ustawić właściwości widoku, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
2. Ustaw [Properties](https://reference.aspose.com/slides/pl/net/aspose.slides/viewproperties) widoku prezentacji.
3. Zapisz prezentację jako plik PPTX.

W poniższym przykładzie ustawiliśmy wartość powiększenia zarówno dla widoku slajdu, jak i widoku notatek.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Ustawianie właściwości widoku prezentacji
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Wartość powiększenia w procentach dla widoku slajdu
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Wartość powiększenia w procentach dla widoku notatek 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **Ustaw odstęp siatki**

Użyj [Presentation.ViewProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/viewproperties/) , aby uzyskać dostęp do ustawień widoku obowiązujących w całej prezentacji. Właściwość [IViewProperties.GridSpacing](https://reference.aspose.com/slides/pl/net/aspose.slides/iviewproperties/gridspacing/) odczytuje lub zmienia odstęp podstawowej siatki edycji. Ustawienie to dotyczy całej prezentacji, a nie pojedynczego slajdu. Odstęp siatki podawany jest w punktach, gdzie 72 punkty równa się jednemu calowi. Użyj dodatniej wartości, zgodnie z dokumentacją API.

Poniższy przykład otwiera istniejący plik `demo.pptx`, wyświetla bieżący odstęp siatki, ustawia odstęp ćwierć cala i zapisuje wynik.

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

Siatka różni się od [drawing guides](/slides/pl/net/drawing-guides/). Odstęp siatki kontroluje regularny interwał, podczas gdy prowadnice to indywidualnie rozmieszczone linie wyrównania poziome lub pionowe. Dodawanie, przesuwanie lub usuwanie prowadnic nie zmienia odstępu siatki.

Zarówno siatka, jak i prowadnice są narzędziami pomocniczymi przy edycji. Nie są renderowane jako zawartość slajdu w PDF, obrazach, SVG ani w pokazie slajdów. Zapisanie odstępu siatki nie gwarantuje, że edytor wyświetli siatkę: jej widoczność zależy również od preferencji przeglądarki lub edytora.

## **Pokaż lub ukryj komentarze przy otwieraniu prezentacji**

Użyj [Presentation.ViewProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/viewproperties/) , aby uzyskać dostęp do ustawień widoku obowiązujących w całej prezentacji. Odczytaj lub zmień [IViewProperties.ShowComments](https://reference.aspose.com/slides/pl/net/aspose.slides/iviewproperties/showcomments/) , aby zapisać preferencję, czy komentarze mają być wyświetlane przy otwieraniu prezentacji w PowerPoint lub innym kompatybilnym edytorze.

To ustawienie kontroluje jedynie zapisaną preferencję widoku. Nie dodaje, nie usuwa, nie edytuje ani nie rozwiązuje komentarzy. Ukrywanie komentarzy zachowuje ich treść, autorów, pozycje, odpowiedzi i statusy. Zobacz [Presentation Comments](/slides/pl/net/presentation-comments/) w celu wykonania operacji zmieniających same komentarze.

Poniższy przykład wymaga istniejącego pliku `comments.pptx` zawierającego komentarze. Wyświetla bieżące ustawienie widoczności, żąda ukrycia komentarzy i zapisuje nowy plik PPTX bez usuwania żadnych komentarzy. Ustawia także [IViewProperties.LastView](https://reference.aspose.com/slides/pl/net/aspose.slides/iviewproperties/lastview/) na [ViewType.SlideView](https://reference.aspose.com/slides/pl/net/aspose.slides/viewtype/), aby skonfigurować początkowy widok edycji wraz z widocznością komentarzy.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");
var showComments = presentation.ViewProperties.ShowComments;
Console.WriteLine($"Current comment visibility: {showComments}");

presentation.ViewProperties.ShowComments = NullableBool.False;
presentation.ViewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

To ustawienie nie decyduje, czy komentarze są uwzględniane w eksportach do PDF, HTML, obrazu, notatek czy materiałów rozdawniczych. Konfiguruj odpowiednie opcje specyficzne dla eksportu osobno.

## **FAQ**

**Dlaczego siatka nie jest widoczna po ponownym otwarciu prezentacji?**

Plik przechowuje odstęp siatki, ale to edytor decyduje, czy siatka jest wyświetlana. Sprawdź ustawienia widoczności siatki w edytorze.

**Czy usunięcie prowadnic zmienia odstęp siatki?**

Nie. Prowadnice i odstęp siatki są niezależnymi ustawieniami. Usunięcie prowadnic nie zmienia zapisanego interwału siatki.

**Czy mogę ustawić różne ustawienia widoku dla różnych sekcji prezentacji?**

[Ustawienia widoku](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/viewproperties/) są definiowane na poziomie prezentacji ([Normal View](https://reference.aspose.com/slides/pl/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/pl/net/aspose.slides/viewproperties/slideviewproperties/)), a nie per sekcja, dlatego pojedynczy zestaw parametrów obowiązuje dla całego dokumentu po jego otwarciu.

**Czy mogę zdefiniować różne stany widoku dla różnych użytkowników?**

Nie. Ustawienia są przechowywane w pliku i są współdzielone. Aplikacje przeglądające mogą respektować preferencje użytkownika, ale sam plik zawiera jedną zestaw właściwości widoku.

**Czy mogę przygotować szablon z wstępnie zdefiniowanymi właściwościami widoku, aby nowe prezentacje otwierały się w ten sam sposób?**

Tak. Ponieważ [właściwości widoku](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/viewproperties/) są przechowywane na poziomie prezentacji, możesz osadzić je w szablonie i tworzyć z niego nowe dokumenty z taką samą początkową konfiguracją widoku.