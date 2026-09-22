---
title: Pobieranie i aktualizacja właściwości widoku prezentacji w JavaScript
linktitle: Właściwości widoku
type: docs
weight: 80
url: /pl/nodejs-java/presentation-view-properties/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Odkryj Aspose.Slides dla Node.js via Java właściwości widoku, aby dostosować formaty slajdów PPT, PPTX i ODP - regulować układy, poziomy przybliżenia oraz ustawienia wyświetlania."
---
## **Wprowadzenie**

Widok normalny składa się z trzech regionów zawartości: samego slajdu, bocznego regionu zawartości oraz dolnego regionu zawartości. Właściwości dotyczące pozycjonowania różnych regionów zawartości. Informacje te pozwalają aplikacji zapisać stan widoku do pliku, tak aby po ponownym otwarciu widok znajdował się w tym samym stanie, w jakim prezentacja była ostatnio zapisana.

Metoda [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) została dodana, aby zapewnić dostęp do właściwości widoku normalnego prezentacji. 

[NormalViewProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewRestoredProperties) klasy i ich potomne, [SplitterBarStateType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SplitterBarStateType) wyliczenie zostały dodane.

## **O NormalViewProperties**

Reprezentuje właściwości widoku normalnego.

Metody [getShowOutlineIcons](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) i [setShowOutlineIcons](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) określają, czy aplikacja powinna wyświetlać ikony przy wyświetlaniu zawartości konspektu w dowolnym z regionów zawartości trybu widoku normalnego.

Metody [getSnapVerticalSplitter](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) i [setSnapVerticalSplitter](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) określają, czy pionowy podziałnik powinien przeskoczyć do stanu zminimalizowanego, gdy boczny region jest wystarczająco mały.

Właściwość [getPreferSingleView](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) i [setPreferSingleView](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) określają, czy użytkownik preferuje widok pełnoekranowego jednego regionu zawartości zamiast standardowego widoku normalnego z trzema regionami zawartości. Jeśli włączone, aplikacja może wyświetlić jeden z regionów zawartości na całym ekranie.

Metody [getVerticalBarState](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) i [getHorizontalBarState](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) określają stan, w jakim powinien być wyświetlany poziomy lub pionowy pasek podziału. Poziomy pasek podziału oddziela slajd od regionu zawartości pod slajdem, pionowy pasek podziału oddziela slajd od bocznego regionu zawartości. Możliwe wartości to: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) oraz [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Metody [getRestoredLeft](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) i [getRestoredTop](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) określają rozmiar górnego lub bocznego regionu slajdu w widoku normalnym, gdy wartość [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SplitterBarStateType#Restored) jest zastosowana dla [getVerticalBarState](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) i [getHorizontalBarState](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) odpowiednio.

## **O przywracaniu NormalViewProperties**

Określa rozmiar regionu slajdu (szerokość, gdy jest potomkiem [getRestoredTop](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), wysokość, gdy jest potomkiem [getRestoredLeft](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) w widoku normalnym, gdy region ma zmienny rozmiar przywrócony (niezminimalizowany ani zmaksymalizowany). 

Metoda [getDimensionSize](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) określa rozmiar regionu slajdu (szerokość, gdy jest potomkiem restoredTop, wysokość, gdy jest potomkiem restoredLeft).

Metoda [getAutoAdjust](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) określa, czy rozmiar bocznego regionu zawartości powinien kompensować nowy rozmiar przy zmianie rozmiaru okna zawierającego widok w aplikacji.

Poniżej podano przykład, który pokazuje, jak uzyskać dostęp do właściwości [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) dla prezentacji.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // Przywróć właściwości widoku prezentacji
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Ustaw domyślną wartość przybliżenia**

{{% alert color="info" %}} 

Aspose.Slides dla Node.js via Java obsługuje teraz ustawianie domyślnej wartości przybliżenia dla prezentacji, tak aby po otwarciu prezentacji przybliżenie było już ustawione. Można to zrobić, ustawiając [ViewProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ViewProperties) prezentacji. [getSlideViewProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) oraz [getNotesViewProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) mogą być ustawione programowo. W tym temacie zobaczymy na przykładzie, jak ustawić [View Properties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ViewProperties) dla [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation) w Aspose.Slides.

{{% /alert %}} 

Aby ustawić właściwości widoku, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).
1. Ustaw [View Properties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ViewProperties) dla [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).
1. Zapisz prezentację jako plik [PPTX](https://docs.fileformat.com/presentation/pptx/). W poniższym przykładzie ustawiliśmy wartość przybliżenia zarówno dla widoku slajdu, jak i widoku notatek.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // Ustawianie właściwości widoku prezentacji
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Wartość przybliżenia w procentach dla widoku slajdu
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Wartość przybliżenia w procentach dla widoku notatek
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw odstęp siatki**

Użyj [Presentation.getViewProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getViewProperties--) aby uzyskać dostęp do ustawień widoku obowiązujących w całej prezentacji. Metody [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) i [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) odczytują lub zmieniają odstęp podstawowej siatki edycji. To ustawienie dotyczy całej prezentacji, a nie pojedynczego slajdu. Odstęp siatki jest podawany w punktach, gdzie 72 punkty odpowiadają jednemu calowi. Użyj wartości dodatniej, zgodnie z dokumentacją API.

Poniższy przykład otwiera istniejący plik `demo.pptx`, wypisuje bieżący odstęp siatki, ustawia odstęp ćwierć cala i zapisuje wynik.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("demo.pptx");
try {
    var gridSpacing = presentation.getViewProperties().getGridSpacing();
    console.log("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18);
    presentation.save("grid-spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Siatka różni się od [drawing guides](/slides/pl/nodejs-java/drawing-guides/). Odstęp siatki kontroluje regularny interwał, podczas gdy prowadnice rysunkowe są indywidualnie pozycjonowane jako poziome lub pionowe linie wyrównania. Dodawanie, przemieszczanie lub usuwanie prowadnic nie zmienia odstępu siatki.

Zarówno siatka, jak i prowadnice rysunkowe są narzędziami pomocniczymi edycji. Nie są renderowane jako zawartość slajdu w PDF, obrazach, SVG ani w pokazie slajdów. Przechowywanie odstępu siatki nie gwarantuje, że edytor wyświetli siatkę: jej widoczność zależy również od preferencji przeglądarki lub edytora.

## **FAQ**

**Dlaczego siatka nie jest widoczna po ponownym otwarciu prezentacji?**

Plik przechowuje odstęp siatki, ale to edytor decyduje, czy siatka jest wyświetlana. Sprawdź ustawienia widoczności siatki w edytorze.

**Czy usunięcie prowadnic rysunkowych zmienia odstęp siatki?**

Nie. Prowadnice rysunkowe i odstęp siatki są niezależnymi ustawieniami. Usunięcie prowadnic nie zmienia zapisanego interwału siatki.

**Czy mogę ustawić różne ustawienia widoku dla różnych sekcji prezentacji?**

[View settings](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/getviewproperties/) są definiowane na poziomie prezentacji ([Normal View](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), a nie per sekcja, więc jeden zestaw parametrów obowiązuje dla całego dokumentu przy otwieraniu.

**Czy mogę zdefiniować różne stany widoku dla różnych użytkowników?**

Nie. Ustawienia są przechowywane w pliku i są współdzielone. Aplikacje przeglądające mogą uwzględniać preferencje użytkownika, ale sam plik zawiera jeden zestaw właściwości widoku.

**Czy mogę przygotować szablon z zdefiniowanymi wcześniej właściwościami widoku, aby nowe prezentacje otwierały się w ten sam sposób?**

Tak. Ponieważ [view properties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/getviewproperties/) są przechowywane na poziomie prezentacji, możesz je osadzić w szablonie i tworzyć nowe dokumenty z tą samą początkową konfiguracją widoku.