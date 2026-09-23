---
title: Pobieranie i aktualizacja właściwości widoku prezentacji w JavaScript
linktitle: Właściwości widoku
type: docs
weight: 80
url: /pl/nodejs-java/presentation-view-properties/
keywords:
- właściwości widoku
- normalny widok
- zawartość konspektu
- ikony konspektu
- przyciąganie pionowego rozdzielacza
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
description: "Odkryj Aspose.Slides dla Node.js poprzez właściwości widoku w Java, aby dostosować formaty slajdów PPT, PPTX i ODP — modyfikować układy, poziomy powiększenia i ustawienia wyświetlania."
---
## **Wprowadzenie**

Normalny widok składa się z trzech regionów zawartości: samego slajdu, bocznego regionu zawartości oraz dolnego regionu zawartości. Właściwości dotyczące pozycjonowania poszczególnych regionów zawartości. Te informacje pozwalają aplikacji zapisać stan widoku w pliku, tak aby po ponownym otwarciu widok znajdował się w tym samym stanie, w którym prezentacja została ostatnio zapisana.

Metoda [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) została dodana, aby zapewnić dostęp do właściwości normalnego widoku prezentacji.  

[NormalViewProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewRestoredProperties) klasy i ich pochodne, [SplitterBarStateType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SplitterBarStateType) wyliczenie zostały dodane.

## **O NormalViewProperties**

Reprezentuje właściwości normalnego widoku.

Metody [getShowOutlineIcons](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) i [setShowOutlineIcons](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) określają, czy aplikacja powinna wyświetlać ikony przy wyświetlaniu zawartości konspektu w którymkolwiek z regionów zawartości trybu normalnego widoku.

Metody [getSnapVerticalSplitter](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) i [setSnapVerticalSplitter](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) określają, czy pionowy rozdzielacz powinien przełączać się do stanu zminimalizowanego, gdy boczny region jest wystarczająco mały.

Właściwość [getPreferSingleView](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) i [setPreferSingleView](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) określa, czy użytkownik preferuje pełnoekranowy jednorodnikowy region zawartości zamiast standardowego normalnego widoku z trzema regionami zawartości. Jeśli włączone, aplikacja może wyświetlić jeden z regionów zawartości na całym oknie.

Metody [getVerticalBarState](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) i [getHorizontalBarState](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) określają stan, w jakim pasek rozdzielacza powinien być wyświetlany. Pionowy pasek rozdzielacza oddziela slajd od bocznego regionu zawartości, poziomy pasek rozdzielacza oddziela slajd od regionu zawartości pod slajdem. Możliwe wartości to: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) oraz [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Metody [getRestoredLeft](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) i [getRestoredTop](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) określają rozmiar górnego lub bocznego regionu slajdu w normalnym widoku, gdy zastosowano wartość [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SplitterBarStateType#Restored) dla [getVerticalBarState](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) i [getHorizontalBarState](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) odpowiednio.

## **O przywracaniu NormalViewProperties**

Określa rozmiar regionu slajdu (szerokość, gdy jest potomkiem [getRestoredTop](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), wysokość, gdy jest potomkiem [getRestoredLeft](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) w normalnym widoku, gdy region ma zmienny przywrócony rozmiar (niezminimalizowany ani zmaksymalizowany).

Metoda [getDimensionSize](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) określa rozmiar regionu slajdu (szerokość, gdy jest dzieckiem restoredTop, wysokość, gdy jest dzieckiem restoredLeft).

Metoda [getAutoAdjust](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) określa, czy rozmiar bocznego regionu zawartości powinien kompensować nowy rozmiar przy zmianie rozmiaru okna zawierającego widok w aplikacji.

Poniżej podany przykład pokazuje, jak uzyskać dostęp do właściwości [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) prezentacji.

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

## **Ustaw domyślną wartość powiększenia**

{{% alert color="info" %}} 

Aspose.Slides dla Node.js w Java teraz obsługuje ustawianie domyślnej wartości powiększenia dla prezentacji, tak aby po otwarciu prezentacji powiększenie było już ustawione. Można to zrobić, ustawiając [ViewProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ViewProperties) prezentacji. [getSlideViewProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) oraz [getNotesViewProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) można ustawić programowo. W tym temacie zobaczymy na przykładzie, jak ustawić [View Properties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ViewProperties) dla [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation) w Aspose.Slides.

{{% /alert %}} 

Aby ustawić właściwości widoku, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).
2. Ustaw [View Properties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ViewProperties) dla [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).
3. Zapisz prezentację jako plik [PPTX](https://docs.fileformat.com/presentation/pptx/).
   W poniższym przykładzie ustawiliśmy wartość powiększenia dla widoku slajdu oraz widoku notatek.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // Ustawianie właściwości widoku prezentacji
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Wartość powiększenia w procentach dla widoku slajdu
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Wartość powiększenia w procentach dla widoku notatek
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw odstęp siatki**

Użyj [Presentation.getViewProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getViewProperties--) , aby uzyskać dostęp do ustawień widoku obowiązujących w całej prezentacji. Metody [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) i [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) odczytują lub zmieniają interwał podstawowej siatki edycji. To ustawienie ma zastosowanie do całej prezentacji, a nie do pojedynczego slajdu. Odstęp siatki podawany jest w punktach, gdzie 72 punkty to jeden cal. Użyj wartości dodatniej, zgodnie z dokumentacją API.

Poniższy przykład otwiera istniejący plik `demo.pptx`, wypisuje bieżący odstęp siatki, ustawia interwał ćwierćcala i zapisuje wynik.

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

Siatka różni się od [drawing guides](/slides/pl/nodejs-java/drawing-guides/). Odstęp siatki kontroluje regularny interwał, podczas gdy prowadnice to indywidualnie rozmieszczone linie wyrównania poziome lub pionowe. Dodawanie, przemieszczanie lub usuwanie prowadnic nie zmienia odstępu siatki.

Zarówno siatka, jak i prowadnice są pomocnikami edycji. Nie są renderowane jako zawartość slajdu w PDF, obrazach, SVG ani w pokazie slajdów. Przechowywanie odstępu siatki nie gwarantuje, że edytor wyświetli siatkę: jej widoczność zależy także od preferencji przeglądarki lub edytora.

## **Pokaż lub ukryj komentarze przy otwieraniu prezentacji**

Użyj [Presentation.getViewProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getViewProperties--) , aby uzyskać dostęp do ustawień widoku obowiązujących w całej prezentacji. Użyj [ViewProperties.getShowComments](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/viewproperties/#getShowComments--) i [ViewProperties.setShowComments](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/viewproperties/#setShowComments-byte--) , aby odczytać lub zmienić przechowywaną preferencję dotyczącą wyświetlania komentarzy przy otwieraniu prezentacji w PowerPoint lub innym kompatybilnym edytorze.

To ustawienie kontroluje jedynie przechowywaną preferencję widoku. Nie dodaje, nie usuwa, nie edytuje ani nie rozwiązuje komentarzy. Ukrycie komentarzy zachowuje ich treść, autorów, pozycje, odpowiedzi i statusy. Zobacz [Presentation Comments](/slides/pl/nodejs-java/presentation-comments/) w celu wykonania operacji zmieniających same komentarze.

Poniższy przykład wymaga istniejącego pliku `comments.pptx` zawierającego komentarze. Wypisuje bieżące ustawienie widoczności, żąda ukrycia komentarzy i zapisuje nowy plik PPTX bez usuwania żadnych komentarzy. Używa również [ViewProperties.setLastView](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/viewproperties/#setLastView-int-) razem z [ViewType.SlideView](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/viewtype/#SlideView), aby skonfigurować początkowy widok edycji wraz z widocznością komentarzy.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("comments.pptx");
try {
    var showComments = presentation.getViewProperties().getShowComments();
    console.log("Current comment visibility: " + showComments);

    var hideComments = java.newByte(aspose.slides.NullableBool.False);
    presentation.getViewProperties().setShowComments(hideComments);
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideView);
    presentation.save("comments-hidden.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

To ustawienie nie określa, czy komentarze są uwzględniane w eksportach PDF, HTML, obrazu, notatek czy materiałów rozdawanych. Skonfiguruj odpowiednie opcje specyficzne dla eksportu osobno.

## **FAQ**

**Dlaczego siatka nie jest widoczna po ponownym otwarciu prezentacji?**

Plik przechowuje odstęp siatki, ale edytor decyduje, czy siatka jest wyświetlana. Sprawdź ustawienia widoczności siatki w edytorze.

**Czy usunięcie prowadnic zmienia odstęp siatki?**

Nie. Prowadnice i odstęp siatki to niezależne ustawienia. Usunięcie prowadnic nie zmienia przechowywanego interwału siatki.

**Czy mogę ustawić różne ustawienia widoku dla różnych sekcji prezentacji?**

[Ustawienia widoku](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/getviewproperties/) są definiowane na poziomie prezentacji ([Normal View](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), a nie w poszczególnych sekcjach, dlatego pojedynczy zestaw parametrów obowiązuje dla całego dokumentu przy jego otwieraniu.

**Czy mogę zdefiniować różne stany widoku dla różnych użytkowników?**

Nie. Ustawienia są przechowywane w pliku i są współdzielone. Aplikacje oglądające mogą respektować preferencje użytkownika, ale sam plik zawiera jedną zestaw właściwości widoku.

**Czy mogę przygotować szablon z wstępnie zdefiniowanymi właściwościami widoku, aby nowe prezentacje otwierały się tak samo?**

Tak. Ponieważ [właściwości widoku](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/getviewproperties/) są przechowywane na poziomie prezentacji, możesz osadzić je w szablonie i tworzyć nowe dokumenty z tymi samymi początkowymi ustawieniami widoku.