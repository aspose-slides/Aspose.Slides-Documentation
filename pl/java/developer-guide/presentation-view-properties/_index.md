---
title: Pobieranie i aktualizacja właściwości widoku prezentacji w Javie
linktitle: Właściwości widoku
type: docs
weight: 80
url: /pl/java/presentation-view-properties/
keywords:
- właściwości widoku
- widok normalny
- zawartość konspektu
- ikony konspektu
- przyciąganie pionowego podziałnika
- widok pojedynczy
- stan paska
- rozmiar wymiaru
- automatyczna regulacja
- domyślne przybliżenie
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Poznaj właściwości widoku Aspose.Slides dla Javy, aby dostosować formaty slajdów PPT, PPTX i ODP — modyfikować układy, poziomy przybliżenia i ustawienia wyświetlania."
---
## **Wprowadzenie**

Widok normalny składa się z trzech obszarów treści: samego slajdu, bocznego obszaru treści i dolnego obszaru treści. Właściwości dotyczące pozycjonowania różnych obszarów treści. Informacje te pozwalają aplikacji zapisać stan widoku do pliku, tak aby po ponownym otwarciu widok znajdował się w tym samym stanie, w jakim prezentacja została ostatnio zapisana.

Metoda [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) została dodana w celu udostępnienia właściwości widoku normalnego prezentacji.  

Interfejsy [INormalViewProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewRestoredProperties) oraz ich pochodne, a także wyliczenie [SplitterBarStateType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SplitterBarStateType) zostały dodane.

## **O INormalViewProperties**

Reprezentuje właściwości widoku normalnego.

Metody [getShowOutlineIcons](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) i [setShowOutlineIcons](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) określają, czy aplikacja powinna wyświetlać ikony przy wyświetlaniu treści konspektu w dowolnym z obszarów treści trybu widoku normalnego.

Metody [getSnapVerticalSplitter](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) i [setSnapVerticalSplitter](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) określają, czy pionowy podziałnik ma przełączać się do stanu zminimalizowanego, gdy boczny obszar jest wystarczająco mały.

Właściwości [getPreferSingleView](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) i [setPreferSingleView](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean--) określają, czy użytkownik preferuje widok jednego regionu treści w pełnym oknie zamiast standardowego widoku normalnego z trzema regionami treści. Jeśli jest włączone, aplikacja może wyświetlić jeden z regionów treści w całym oknie.

Metody [getVerticalBarState](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) i [getHorizontalBarState](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) określają stan, w jakim ma być wyświetlany odpowiednio pionowy lub poziomy pasek podziałnika. Poziomy pasek podziałnika oddziela slajd od regionu treści poniżej slajdu, pionowy pasek podziałnika oddziela slajd od bocznego regionu treści. Możliwe wartości to: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SplitterBarStateType#Maximized) oraz [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SplitterBarStateType#Restored).

Metody [getRestoredLeft](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) i [getRestoredTop](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) określają rozmiar górnego lub bocznego regionu slajdu w widoku normalnym, gdy wartość [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SplitterBarStateType#Restored) jest zastosowana dla [getVerticalBarState](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) i [getHorizontalBarState](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) odpowiednio.

## **O przywracaniu INormalViewProperties** 

Określa rozmiar regionu slajdu (szerokość, gdy jest dzieckiem [getRestoredTop](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), wysokość, gdy jest dzieckiem [getRestoredLeft](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) w widoku normalnym, gdy region ma zmienny przywrócony rozmiar (nie jest zminimalizowany ani zmaksymalizowany).  

Metoda [getDimensionSize](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) określa rozmiar regionu slajdu (szerokość, gdy jest dzieckiem restoredTop, wysokość, gdy jest dzieckiem restoredLeft).  

Metoda [getAutoAdjust](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) określa, czy rozmiar bocznego regionu treści powinien kompensować nowy rozmiar przy zmianie rozmiaru okna zawierającego widok w aplikacji.  

Poniżej podano przykład, który pokazuje, jak uzyskać dostęp do właściwości [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) dla prezentacji.

```java
Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Przywróć właściwości widoku prezentacji
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Ustaw domyślną wartość przybliżenia**

{{% alert color="primary" %}} 

Aspose.Slides dla Javy obsługuje teraz ustawianie domyślnej wartości przybliżenia prezentacji, tak aby po otwarciu prezentacji przybliżenie było już ustawione. Można to zrobić, ustawiając [ViewProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ViewProperties) prezentacji. Metody [getSlideViewProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) oraz [getNotesViewProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) mogą być ustawiane programowo. W tym temacie pokażemy na przykładzie, jak ustawić właściwości widoku [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation) w [Aspose.Slides](/slides/pl/).

{{% /alert %}} 

Aby ustawić właściwości widoku, proszę wykonać poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation).
1. Ustaw [View Properties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ViewProperties) prezentacji ([Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation)).
1. Zapisz prezentację jako plik [PPTX](https://docs.fileformat.com/presentation/pptx/) .
   W poniższym przykładzie ustawiliśmy wartość przybliżenia dla widoku slajdu oraz widoku notatek.

```java
Presentation presentation = new Presentation();
try {
    // Ustawianie właściwości widoku prezentacji
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Wartość przybliżenia w procentach dla widoku slajdu
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Wartość przybliżenia w procentach dla widoku notatek 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy mogę ustawić różne ustawienia widoku dla różnych sekcji prezentacji?**

[Ustawienia widoku](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getViewProperties--) są definiowane na poziomie prezentacji ([Normal View](https://reference.aspose.com/slides/pl/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/pl/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), a nie dla poszczególnych sekcji, więc pojedynczy zestaw parametrów obowiązuje dla całego dokumentu po jego otwarciu.

**Czy mogę zdefiniować różne stany widoku dla różnych użytkowników?**

Nie. Ustawienia są przechowywane w pliku i są współdzielone. Aplikacje przeglądające mogą respektować preferencje użytkownika, ale sam plik zawiera tylko jeden zestaw właściwości widoku.

**Czy mogę przygotować szablon z zdefiniowanymi wcześniej właściwościami widoku, aby nowe prezentacje otwierały się w ten sam sposób?**

Tak. Ponieważ [właściwości widoku](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getViewProperties--) są przechowywane na poziomie prezentacji, możesz osadzić je w szablonie i tworzyć z niego nowe dokumenty z taką samą początkową konfiguracją widoku.