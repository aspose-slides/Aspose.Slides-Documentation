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
- przyciąganie pionowego rozdzielacza
- pojedynczy widok
- stan paska
- rozmiar wymiaru
- automatyczne dopasowanie
- domyślne powiększenie
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Użyj Aspose.Slides for Java, aby skonfigurować układ widoku normalnego, powiększenie slajdu i notatek, odstępy siatki oraz widoczność komentarzy w prezentacjach PowerPoint."
---
## **Wprowadzenie**

W normalnym widoku programu PowerPoint slajd wyświetlany jest pomiędzy bocznym panelem miniatur lub konspektem a panelem notatek znajdującym się poniżej. Aspose.Slides for Java udostępnia zapisane preferencje edycji prezentacji poprzez [Presentation.getViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--). Obejmują one układ paneli, poziomy powiększenia, odstępy siatki oraz widoczność komentarzy.

## **O INormalViewProperties**

Użyj [getNormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getNormalViewProperties--) aby uzyskać dostęp do interfejsu [INormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/). Metoda [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) kontroluje, czy ikony pojawiają się obok tytułów slajdów w konspekcie. Metoda [setSnapVerticalSplitter](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) pozwala, aby boczny panel przyciągał się do stanu zminimalizowanego, gdy użytkownik go zwęża. Metoda [setPreferSingleView](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) wskazuje preferencję wyświetlania jednego panelu w pełnym oknie.

Metoda [setVerticalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) kontroluje podziałkę między bocznym panelem a slajdem. Metoda [setHorizontalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) kontroluje podziałkę nad panelem notatek. Obie przyjmują wartość typu [SplitterBarStateType](https://reference.aspose.com/slides/java/com.aspose.slides/splitterbarstatetype/) – `Minimized`, `Maximized` lub `Restored`.

## **O przywracaniu INormalViewProperties**

Kiedy podziałka jest przywracana, [getRestoredLeft](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) podaje zapisaną wielkość bocznego panelu, a [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredTop--) podaje zapisaną wielkość górnej części slajdu. Obie udostępniają [INormalViewRestoredProperties](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/). Jej metoda [setDimensionSize](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) przyjmuje procent od 0 do 100, a [setAutoAdjust](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) kontroluje, czy edytor dostosowuje rozmiar przy zmianie rozmiaru okna.

Ten przykład aktualizuje istniejącą prezentację. Przywraca poziomą podziałkę, ustawia rozmiar zwrócony przez [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredTop--) na 80 % z włączonym automatycznym dopasowaniem oraz maksymalizuje pionową podziałkę. Dodatkowo wywołuje [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-), aby wyświetlać ikony w widoku konspektu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    INormalViewProperties normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(SplitterBarStateType.Restored);
    normalView.setVerticalBarState(SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw domyślną wartość powiększenia**

Metody [getSlideViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getSlideViewProperties--) i [getNotesViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getNotesViewProperties--) przechowują niezależne ustawienia powiększenia dla edytora. Ustawienia te nie wpływają na wymiary slajdów, odtwarzanie pokazu slajdów ani rozdzielczość eksportowanych obrazów.

Ten przykład otwiera istniejącą prezentację i wywołuje [setVariableScale](https://reference.aspose.com/slides/java/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-), aby dopasować slajd do okna edycji. Dla strony notatek wyłącza automatyczne skalowanie i wywołuje [setScale](https://reference.aspose.com/slides/java/com.aspose.slides/icommonslideviewproperties/#setScale-int-), aby ustawić stałe powiększenie 80 %.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw odstęp siatki**

Metoda [setGridSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) określa odległość między liniami siatki edycji w całej prezentacji. Przyjmuje wartość dodatnią w punktach, przy 72 punktach na cal. Ten przykład wypisuje bieżący odstęp w istniejącej prezentacji i zapisuje siatkę o odległości jednego czwartego cala, ustawiając interwał na 18 punktów.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18f);
    
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Siatka powtarza się w stałym odstępie. [Drawing guides](/slides/pl/java/drawing-guides/) oznaczają poszczególne pozycje poziome lub pionowe. Oba są pomocnikami edycji i pojawiają się wyłącznie w edytorach, które je wyświetlają. Pokazy slajdów oraz eksport do PDF, obrazów lub SVG ich nie zawierają.

## **Pokaż lub ukryj komentarze przy otwieraniu prezentacji**

Metoda [setShowComments](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setShowComments-byte-) przechowuje preferencję, którą zgodne edytory wykorzystują przy otwieraniu prezentacji. Dla istniejącej prezentacji z komentarzami ten przykład wypisuje bieżące ustawienie i zapisuje kopię z ukrytymi komentarzami. Dodatkowo wywołuje [setLastView](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setLastView-int-) z [ViewType.SlideView](https://reference.aspose.com/slides/java/com.aspose.slides/viewtype/#SlideView), aby kopia otworzyła się w widoku slajdu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("comments.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current comment visibility: " + viewProperties.getShowComments());

    viewProperties.setShowComments(NullableBool.False);
    viewProperties.setLastView(ViewType.SlideView);

    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ukrywanie komentarzy zachowuje ich tekst, autorów, pozycje, odpowiedzi i statusy. Aby zmienić same komentarze, zobacz [Presentation Comments](/slides/pl/java/presentation-comments/). Ustawienia eksportu kontrolują, czy komentarze pojawiają się w PDF, HTML, obrazach, notatkach lub materiałach rozdawczych.

## **FAQ**

**Dlaczego siatka jest ukryta po ponownym otwarciu prezentacji?**  
Prezentacja zapisuje odstęp siatki. Aby zobaczyć siatkę, włącz jej widoczność w edytorze.

**Czy usunięcie przewodników rysowania zmienia odstęp siatki?**  
Nie. Dodawanie, przesuwanie lub usuwanie przewodnika nie zmienia odstępu siatki.

**Czy różne sekcje prezentacji mogą mieć różne ustawienia widoku?**  
Nie. [Presentation.getViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--) dotyczy całej prezentacji.

**Czy mogę zapisać różne ustawienia widoku dla różnych użytkowników?**  
Plik przechowuje jeden zestaw właściwości widoku dla wszystkich. Edytor może także zastosować lokalne preferencje użytkownika.

**Czy mogę zapisać ustawienia widoku w szablonie?**  
Tak. Prezentacje utworzone z szablonu dziedziczą zapisane w nim ustawienia widoku.