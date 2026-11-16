---
title: Pobieranie i aktualizacja właściwości widoku prezentacji w JavaScript
linktitle: Właściwości widoku
type: docs
weight: 80
url: /pl/nodejs-java/presentation-view-properties/
keywords:
- właściwości widoku
- normalny widok
- treść konspektu
- ikony konspektu
- przyciąganie pionowego podziału
- pojedynczy widok
- stan paska
- rozmiar wymiaru
- automatyczna regulacja
- domyślne powiększenie
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Użyj Aspose.Slides dla Node.js poprzez Java, aby skonfigurować układ normalnego widoku, powiększenie slajdu i notatek, odstępy siatki oraz widoczność komentarzy w prezentacjach PowerPoint."
---
## **Wprowadzenie**

W normalnym widoku programu PowerPoint slajd wyświetlany jest pomiędzy bocznym panelem z miniaturami lub konspektem a panelem notatek poniżej. Aspose.Slides dla Node.js poprzez Java udostępnia zapisane preferencje edycji prezentacji poprzez [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties). Obejmują one układ paneli, poziomy powiększenia, odstępy siatki i widoczność komentarzy.

## **O NormalViewProperties**

Użyj [getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNormalViewProperties), aby uzyskać dostęp do klasy [NormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) kontroluje, czy ikony pojawiają się obok tytułów slajdów w konspekcie. [setSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) umożliwia przyciągnięcie bocznego panelu do stanu zminimalizowanego, gdy użytkownik go zwęża. [setPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setPreferSingleView) wskazuje preferencję wyświetlania jednego panelu w pełnym oknie.

[setVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setVerticalBarState) steruje podziałką pomiędzy bocznym panelem a slajdem. [setHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setHorizontalBarState) steruje podziałką nad panelem notatek. Obie przyjmują wartość typu [SplitterBarStateType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/splitterbarstatetype/) `Minimized`, `Maximized` lub `Restored`.

## **O przywracaniu NormalViewProperties**

Gdy podziałka zostaje przywrócona, [getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredLeft) zwraca zapisany rozmiar bocznego panelu, a [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) zwraca zapisany rozmiar górnej części slajdu. Obie udostępniają [NormalViewRestoredProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/). Metoda [setDimensionSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) przyjmuje procent od 0 do 100, a [setAutoAdjust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) kontroluje, czy edytor dostosowuje rozmiar przy zmianie rozmiaru okna.

Ten przykład aktualizuje istniejącą prezentację. Przywraca poziomą podziałkę, ustawia rozmiar zwrócony przez [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) na 80% z włączoną automatyczną regulacją oraz maksymalizuje pionową podziałkę. Wywołuje także [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons), aby wyświetlić ikony w widoku konspektu.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(slides.SplitterBarStateType.Restored);
    normalView.setVerticalBarState(slides.SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw domyślną wartość powiększenia**

[getSlideViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getSlideViewProperties) i [getNotesViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNotesViewProperties) przechowują niezależne ustawienia powiększenia dla edytora. Ustawienia te nie wpływają na wymiary slajdu, odtwarzanie pokazu slajdów ani rozdzielczość eksportu obrazu.

Ten przykład otwiera istniejącą prezentację i wywołuje [setVariableScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setVariableScale), aby dopasować slajd do okna edycji. Dla strony notatek wyłącza automatyczne skalowanie i wywołuje [setScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setScale), aby ustawić stałe powiększenie 80%.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw odstęp siatki**

[setGridSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setGridSpacing) ustawia odległość pomiędzy liniami siatki edycji w całej prezentacji. Przyjmuje dodatnią wartość w punktach, przy 72 punktach na cal. Ten przykład wypisuje aktualny odstęp w istniejącej prezentacji i zapisuje siatkę o ćwierćcala, ustawiając interwał na 18 punktów.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18);

    presentation.save("grid-spacing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Siatka powtarza się w stałym interwale. [Drawing guides](/slides/pl/nodejs-java/drawing-guides/) oznaczają pojedyncze pozycje poziome lub pionowe. Oba służą jako pomoce edycyjne i pojawiają się tylko w edytorach, które je wyświetlają. Pokazy slajdów oraz eksporty do PDF, obrazów lub SVG ich nie zawierają.

## **Pokaż lub ukryj komentarze podczas otwierania prezentacji**

[setShowComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setShowComments) przechowuje preferencję, której kompatybilne edytory używają przy otwieraniu prezentacji. Dla istniejącej prezentacji z komentarzami ten przykład wypisuje bieżące ustawienie i zapisuje kopię z ukrytymi komentarzami. Wywołuje także [setLastView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setLastView) z [ViewType.SlideView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewtype/#SlideView), aby kopia otworzyła się w widoku slajdu.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current comment visibility: " + viewProperties.getShowComments());

    const hideComments = java.newByte(slides.NullableBool.False);
    viewProperties.setShowComments(hideComments);
    viewProperties.setLastView(slides.ViewType.SlideView);

    presentation.save("comments-hidden.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ukrywanie komentarzy zachowuje ich tekst, autorów, pozycje, odpowiedzi i statusy. Aby zmienić same komentarze, zobacz [Presentation Comments](/slides/pl/nodejs-java/presentation-comments/). Ustawienia eksportu kontrolują, czy komentarze pojawiają się w PDF, HTML, obrazach, notatkach lub materiałach rozdawniczych.

## **FAQ**

**Dlaczego siatka jest ukryta po ponownym otwarciu prezentacji?**

Prezentacja przechowuje interwał siatki. Aby zobaczyć siatkę, włącz widoczność siatki w edytorze.

**Czy usunięcie prowadnic rysunkowych zmienia odstęp siatki?**

Nie. Dodanie, przesunięcie lub usunięcie prowadnicy nie zmienia interwału siatki.

**Czy różne sekcje prezentacji mogą mieć różne ustawienia widoku?**

Nie. [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties) obowiązuje dla całej prezentacji.

**Czy mogę zapisać różne ustawienia widoku dla różnych użytkowników?**

Plik przechowuje jedną grupę właściwości widoku dla wszystkich. Edytor może także zastosować lokalne preferencje użytkownika.

**Czy mogę zapisać ustawienia widoku w szablonie?**

Tak. Prezentacje utworzone na podstawie szablonu dziedziczą zapisane w nim ustawienia widoku.