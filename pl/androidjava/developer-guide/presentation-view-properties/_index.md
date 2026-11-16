---
title: Pobieranie i aktualizacja właściwości widoku prezentacji na Androidzie
linktitle: Właściwości widoku
type: docs
weight: 80
url: /pl/androidjava/presentation-view-properties/
keywords:
- właściwości widoku
- normalny widok
- zawartość konspektu
- ikony konspektu
- przyciąganie pionowego podziału
- pojedynczy widok
- stan paska
- rozmiar wymiaru
- automatyczne dostosowanie
- domyślne przybliżenie
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Użyj Aspose.Slides for Android via Java, aby skonfigurować układ normalnego widoku, przybliżenie slajdu i notatek, odstępy siatki oraz widoczność komentarzy w prezentacjach PowerPoint."
---
## **Wstęp**

W normalnym widoku programu PowerPoint slajd wyświetlany jest pomiędzy bocznym panelem miniatur lub konspektem a panelem notatek poniżej. Aspose.Slides for Android via Java udostępnia zapisane preferencje edycji prezentacji poprzez [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--). Zawierają one układ paneli, poziomy przybliżenia, odstępy siatki oraz widoczność komentarzy.

## **Informacje o INormalViewProperties**

Użyj [getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNormalViewProperties--) aby uzyskać dostęp do interfejsu [INormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) kontroluje, czy ikony wyświetlane są obok tytułów slajdów w konspekcie. [setSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) umożliwia przyciąganie bocznego panelu do stanu zminimalizowanego, gdy użytkownik go zwęża. [setPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) wskazuje preferencję wyświetlania jednego panelu w pełnym oknie.

[setVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) kontroluje podziałkę pomiędzy bocznym panelem a slajdem. [setHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) kontroluje podziałkę nad panelem notatek. Oba przyjmują wartość typu [SplitterBarStateType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/splitterbarstatetype/) `Minimized`, `Maximized` lub `Restored`.

## **Informacje o przywracaniu INormalViewProperties**

Gdy podziałka zostaje przywrócona, [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) zwraca zapisaną szerokość bocznego panelu, a [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) zwraca zapisaną wysokość górnego obszaru slajdu. Oba udostępniają [INormalViewRestoredProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/). Jego metoda [setDimensionSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) przyjmuje procent od 0 do 100, a [setAutoAdjust](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) kontroluje, czy edytor dostosowuje rozmiar przy zmianie rozmiaru okna.

Ten przykład aktualizuje istniejącą prezentację. Przywraca poziomą podziałkę, ustawia rozmiar zwrócony przez [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) na 80 % z włączonym automatycznym dostosowaniem i maksymalizuje pionową podziałkę. Wywołuje także [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) aby wyświetlić ikony w widoku konspektu.

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

## **Ustaw domyślną wartość przybliżenia**

[getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getSlideViewProperties--) i [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNotesViewProperties--) przechowują niezależne ustawienia przybliżenia dla edytora. Ustawienia te nie wpływają na wymiary slajdu, odtwarzanie pokazu slajdów ani rozdzielczość eksportowanych obrazów.

Ten przykład otwiera istniejącą prezentację i wywołuje [setVariableScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-) aby dopasować slajd do okna edycji. Dla strony notatek wyłącza automatyczną skalowanie i wywołuje [setScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setScale-int-) aby ustawić stałe przybliżenie 80 %.

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

[setGridSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) ustawia odległość między liniami siatki edycji w całej prezentacji. Przyjmuje dodatnią wartość w punktach, przy 72 punktach na cal. Ten przykład wypisuje bieżący odstęp w istniejącej prezentacji i zapisuje siatkę o kwart calowej, ustawiając interwał na 18 punktów.

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

Siatka powtarza się w stałych odstępach. [Drawing guides](/slides/pl/androidjava/drawing-guides/) oznaczają pojedyncze pozycje poziome lub pionowe. Oba są pomocnikami edycji i pojawiają się tylko w edytorach, które je wyświetlają. Pokazy slajdów oraz eksport do PDF, obrazów lub SVG ich nie uwzględniają.

## **Pokaż lub ukryj komentarze podczas otwierania prezentacji**

[setShowComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) przechowuje preferencję, którą kompatybilne edytory używają przy otwieraniu prezentacji. Dla istniejącej prezentacji z komentarzami, ten przykład wypisuje bieżące ustawienie i zapisuje kopię z ukrytymi komentarzami. Wywołuje także [setLastView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) z [ViewType.SlideView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewtype/#SlideView), aby kopia otworzyła się w widoku slajdu.

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

Ukrywanie komentarzy zachowuje ich tekst, autorów, pozycje, odpowiedzi i statusy. Aby zmienić same komentarze, zobacz [Presentation Comments](/slides/pl/androidjava/presentation-comments/). Ustawienia eksportu kontrolują, czy komentarze pojawiają się w PDF, HTML, obrazach, notatkach lub materiałach rozdawniczych.

## **FAQ**

**Dlaczego siatka jest ukryta po ponownym otwarciu prezentacji?**

Prezentacja przechowuje interwał siatki. Aby zobaczyć siatkę, włącz widoczność siatki w edytorze.

**Czy usunięcie prowadnic rysunkowych zmienia odstęp siatki?**

Nie. Dodanie, przesunięcie lub usunięcie prowadnicy nie zmienia interwału siatki.

**Czy różne sekcje prezentacji mogą mieć różne ustawienia widoku?**

Nie. [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) ma zastosowanie do całej prezentacji.

**Czy mogę zapisać różne ustawienia widoku dla różnych użytkowników?**

Plik przechowuje jeden zestaw właściwości widoku dla wszystkich. Edytor może również zastosować lokalne preferencje użytkownika.

**Czy mogę zapisać ustawienia widoku w szablonie?**

Tak. Prezentacje utworzone z szablonu dziedziczą zapisane ustawienia widoku.