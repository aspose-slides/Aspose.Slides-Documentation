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
- pojedynczy widok
- stan paska
- rozmiar wymiaru
- automatyczna regulacja
- domyślne powiększenie
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Poznaj właściwości widoku Aspose.Slides for Java, aby dostosować formaty slajdów PPT, PPTX i ODP — regulować układy, poziomy powiększenia i ustawienia wyświetlania."
---
## **Wprowadzenie**

Widok normalny składa się z trzech obszarów treści: samego slajdu, bocznego obszaru treści oraz dolnego obszaru treści. Właściwości dotyczące pozycjonowania różnych obszarów treści. Informacje te pozwalają aplikacji zapisać stan widoku do pliku, tak aby po ponownym otwarciu widok znajdował się w takim samym stanie, w jakim był ostatnio zapisany.

Metoda [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) została dodana w celu udostępnienia właściwości widoku normalnego prezentacji.  

Dodano interfejsy [INormalViewProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewRestoredProperties) oraz ich pochodne, a także wyliczenie [SplitterBarStateType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SplitterBarStateType).

## **O INormalViewProperties**

Reprezentuje właściwości widoku normalnego.

Metody [getShowOutlineIcons](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) i [setShowOutlineIcons](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) określają, czy aplikacja ma wyświetlać ikony przy wyświetlaniu zawartości konspektu w którymkolwiek z obszarów treści trybu widoku normalnego.

Metody [getSnapVerticalSplitter](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) i [setSnapVerticalSplitter](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) określają, czy pionowy podziałnik ma przechodzić w stan zminimalizowany, gdy boczny obszar jest wystarczająco mały.

Właściwość [getPreferSingleView](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) i [setPreferSingleView](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) określają, czy użytkownik woli widzieć pełnoekranowy pojedynczy obszar treści zamiast standardowego widoku normalnego z trzema obszarami. Jeśli jest włączone, aplikacja może wyświetlić jeden z obszarów treści w całym oknie.

Metody [getVerticalBarState](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) i [getHorizontalBarState](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) określają stan, w jakim ma być wyświetlany odpowiednio pionowy lub poziomy pasek podziału. Pionowy pasek oddziela slajd od bocznego obszaru treści, poziomy – od obszaru pod slajdem. Dostępne wartości: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SplitterBarStateType#Maximized) oraz [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SplitterBarStateType#Restored).

Metody [getRestoredLeft](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) i [getRestoredTop](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) określają rozmiar górnego lub bocznego obszaru slajdu w widoku normalnym, gdy dla [getVerticalBarState](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) i [getHorizontalBarState](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) zastosowano wartość [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SplitterBarStateType#Restored).

## **O przywracaniu INormalViewProperties**

Określa rozmiar obszaru slajdu (szerokość, gdy jest dzieckiem [getRestoredTop](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), wysokość, gdy jest dzieckiem [getRestoredLeft](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) w widoku normalnym, gdy obszar ma zmienny przywrócony rozmiar (niezminimalizowany ani niezmaksymalizowany).

Metoda [getDimensionSize](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) określa rozmiar obszaru slajdu (szerokość przy przywróconym górnym, wysokość przy przywróconym lewym).

Metoda [getAutoAdjust](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) określa, czy rozmiar bocznego obszaru treści ma być automatycznie dostosowywany do nowego rozmiaru przy zmianie rozmiaru okna zawierającego widok w aplikacji.

Poniższy przykład pokazuje, jak uzyskać dostęp do właściwości [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) dla prezentacji.

```java
import com.aspose.slides.*;

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

## **Ustaw domyślną wartość powiększenia**

{{% alert color="info" %}} 

Aspose.Slides for Java obsługuje teraz ustawianie domyślnej wartości powiększenia prezentacji, tak aby po jej otwarciu powiększenie było już ustawione. Można to zrobić, ustawiając [ViewProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ViewProperties) prezentacji. Metody [getSlideViewProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) oraz [getNotesViewProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) mogą być ustawiane programowo. W tym temacie pokażemy na przykładzie, jak ustawić [View Properties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ViewProperties) dla [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation) w [Aspose.Slides](/slides/pl/).

{{% /alert %}} 

Aby ustawić właściwości widoku, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation).
2. Ustaw [View Properties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ViewProperties) dla [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation).
3. Zapisz prezentację jako plik [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   W poniższym przykładzie ustawiono wartość powiększenia zarówno dla widoku slajdu, jak i widoku notatek.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Ustawianie właściwości widoku prezentacji
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Wartość powiększenia w procentach dla widoku slajdu
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Wartość powiększenia w procentach dla widoku notatek 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Czy mogę ustawić różne ustawienia widoku dla różnych sekcji prezentacji?

[Ustawienia widoku](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getViewProperties--) są definiowane na poziomie całej prezentacji ([Normal View](https://reference.aspose.com/slides/pl/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/pl/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), a nie dla poszczególnych sekcji, więc jeden zestaw parametrów obowiązuje dla całego dokumentu po otwarciu.

### Czy mogę zdefiniować wstępnie różne stany widoku dla różnych użytkowników?

Nie. Ustawienia są zapisywane w pliku i są współdzielone. Aplikacje odtwarzające mogą uwzględniać preferencje użytkownika, ale sam plik zawiera tylko jeden zestaw właściwości widoku.

### Czy mogę przygotować szablon z wstępnie zdefiniowanymi właściwościami widoku, aby nowe prezentacje otwierały się w ten sam sposób?

Tak. Ponieważ [właściwości widoku](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getViewProperties--) są przechowywane na poziomie prezentacji, możesz osadzić je w szablonie i tworzyć nowe dokumenty na jego podstawie z taką samą początkową konfiguracją widoku.