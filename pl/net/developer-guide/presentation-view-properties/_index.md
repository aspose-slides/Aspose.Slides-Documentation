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
- przyciąganie pionowego separatora
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
description: "Poznaj właściwości widoku Aspose.Slides dla .NET, aby dostosować formaty slajdów PPT, PPTX i ODP — zmieniać układy, poziomy powiększenia i ustawienia wyświetlania."
---
## **Wprowadzenie**

Widok normalny składa się z trzech obszarów zawartości: samego slajdu, bocznego obszaru zawartości oraz dolnego obszaru zawartości. Właściwości dotyczące położenia poszczególnych obszarów zawartości. Informacje te umożliwiają aplikacji zapisanie stanu widoku do pliku, tak aby po ponownym otwarciu widok znajdował się w takim samym stanie, w jakim prezentacja była ostatnio zapisana.

Property [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/iviewproperties/properties/normalviewproperties) has been added to provide access to normal view properties of presentation. 

[INormalViewProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/inormalviewrestoredproperties) interfaces and its descendants, [SplitterBarStateType](https://reference.aspose.com/slides/pl/net/aspose.slides/splitterbarstatetype) enum have been added.

## **O INormalViewProperties**

Reprezentuje normal view properties.

Property **ShowOutlineIcons** określa, czy aplikacja powinna wyświetlać ikony przy wyświetlaniu treści konspektu w którymkolwiek z obszarów zawartości trybu widoku normalnego.

Property **SnapVerticalSplitter** określa, czy pionowy separator ma przełączać się do stanu zminimalizowanego, gdy boczny obszar jest wystarczająco mały.

Property **PreferSingleView** określa, czy użytkownik woli widzieć jedną, pełnoekranową zawartość zamiast standardowego widoku normalnego z trzema obszarami zawartości. Jeśli włączona, aplikacja może wyświetlić jeden z obszarów zawartości na całym ekranie.

Properties **VerticalBarState** i **HorizontalBarState** określają stan, w jakim ma być wyświetlany odpowiedni pasek separatora (poziomy lub pionowy). Poziomy pasek separatora oddziela slajd od obszaru zawartości znajdującego się pod slajdem, pionowy pasek separatora oddziela slajd od bocznego obszaru zawartości. Dozwolone wartości to: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** oraz **SplitterBarStateType.Restored**.

Properties **RestoredLeft** i **RestoredTop** określają rozmiary górnego lub bocznego obszaru slajdu w widoku normalnym, gdy dla **VerticalBarState** i **HorizontalBarState** zastosowano wartość **SplitterBarStateType.Restored**.

## **O przywracaniu INormalViewProperties** 

Określa wymiary obszaru slajdu (szerokość, gdy jest dzieckiem RestoredTop, wysokość, gdy jest dzieckiem RestoredLeft) w widoku normalnym, gdy obszar ma zmienny rozmiar przywrócony (niezminimalizowany ani niezmaksymalizowany). 

Property **DimensionSize** określa rozmiar obszaru slajdu (szerokość, gdy jest dzieckiem restoredTop, wysokość, gdy jest dzieckiem restoredLeft).

Property **AutoAdjust** określa, czy rozmiar bocznego obszaru zawartości ma kompensować nowy rozmiar przy zmianie rozmiaru okna zawierającego widok w aplikacji.

Poniżej przedstawiono przykład, który pokazuje, jak uzyskać dostęp do właściwości **ViewProperties.NormalViewProperties** dla prezentacji.

```c#
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

Aspose.Slides for .NET obsługuje teraz ustawianie domyślnej wartości powiększenia dla prezentacji, tak aby po otwarciu prezentacji powiększenie było już ustawione. Można to zrobić, ustawiając [ViewProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/viewproperties) prezentacji. Właściwości widoku slajdu oraz [NotesViewProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/viewproperties/properties/notesviewproperties) można ustawiać programowo. W tym temacie pokażemy na przykładzie, jak ustawić właściwości widoku prezentacji w Aspose.Slides.

Aby ustawić właściwości widoku, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation)
1. Ustaw View [Properties](https://reference.aspose.com/slides/pl/net/aspose.slides/viewproperties) prezentacji
1. Zapisz prezentację jako plik PPTX

W poniższym przykładzie ustawiliśmy wartość powiększenia zarówno dla widoku slajdu, jak i widoku notatek.

```c#
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Ustawianie właściwości widoku prezentacji
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Wartość powiększenia w procentach dla widoku slajdu
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Wartość powiększenia w procentach dla widoku notatek 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Czy mogę ustawić różne ustawienia widoku dla różnych sekcji prezentacji?**

Ustawienia [View settings](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/viewproperties/) są definiowane na poziomie prezentacji ([Normal View](https://reference.aspose.com/slides/pl/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/pl/net/aspose.slides/viewproperties/slideviewproperties/)), a nie dla poszczególnych sekcji, więc pojedynczy zestaw parametrów obowiązuje dla całego dokumentu po jego otwarciu.

**Czy mogę zdefiniować różne stany widoku dla różnych użytkowników?**

Nie. Ustawienia są przechowywane w pliku i są współdzielone. Aplikacje przeglądające mogą uwzględniać preferencje użytkownika, ale sam plik zawiera jedną zestaw właściwości widoku.

**Czy mogę przygotować szablon z wstępnie zdefiniowanymi właściwościami widoku, aby nowe prezentacje otwierały się w ten sam sposób?**

Tak. Ponieważ [view properties](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/viewproperties/) są przechowywane na poziomie prezentacji, możesz osadzić je w szablonie i tworzyć z niego nowe dokumenty z taką samą początkową konfiguracją widoku.