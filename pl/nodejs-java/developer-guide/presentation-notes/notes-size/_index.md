---
title: Zmien rozmiar i orientację strony notatek w JavaScript
linktitle: Rozmiar strony notatek
type: docs
weight: 10
url: /pl/nodejs-java/notes-size/
keywords:
  - rozmiar strony notatek
  - orientacja notatek
  - notatki poziome
  - notatki pionowe
  - rozmiar materiałów pomocniczych
  - PowerPoint
  - prezentacja
  - PPT
  - PPTX
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Odczytaj i zmień wymiary strony notatek w Aspose.Slides dla Node.js przy użyciu Java, zmień orientację, zweryfikuj zapisane rozmiary oraz wyeksportuj notatki lub materiały pomocnicze do PDF i obrazów."
---
## **Przegląd**

Użyj [Presentation.getNotesSize](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/getnotessize/) , aby uzyskać dostęp do ustawień strony notatek prezentacji. Zwraca on obiekt [NotesSize](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/notessize/) , którego metoda [setSize](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/notessize/setsize/) ustawia wymiary strony. Chociaż samego obiektu ustawień nie można zastąpić, można przypisać nowe wymiary za pomocą tej metody.

Szerokość i wysokość są podawane w **punktach**, przy 72 punktach na cal. Na przykład 900 × 600 punktów to 12,5 × 8⅓ cala. Ustawienia te odnoszą się do całej prezentacji, a nie do notatek pojedynczego slajdu.

| Ustawienie | Cel |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/getnotessize/) | Kontroluje wymiary strony notatek oraz wymiary strony używane przy eksporcie materiałów pomocniczych. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/getslidesize/) | Kontroluje zwykłe wymiary slajdów prezentacji za pomocą [SlideSize](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidesize/). |

Zmiana któregokolwiek z ustawień nie zmienia automatycznie drugiego. Zmiana orientacji strony notatek nie obraca również zwykłych slajdów. Zobacz [Rozmiar slajdu](/slides/pl/nodejs-java/slide-size/) , aby zmienić rozmiar zwykłych slajdów.

Poniższe przykłady używają istniejącego pliku `sample.pptx`. Dla przykładów eksportu użyj prezentacji z co najmniej jednym slajdem zawierającym notatki prelegenta. Każdy przykład może być uruchomiony niezależnie.

## **Odczyt rozmiaru i orientacji strony notatek**

Odczytaj szerokość i wysokość i porównaj je, aby określić orientację: szersza strona to orientacja pozioma, wyższa strona to orientacja pionowa, a równe wymiary opisują stronę kwadratową. Ten przykład wypisuje rzeczywiste wymiary w punktach, bez zakładania standardowego rozmiaru papieru.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();
    let orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    console.log("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    console.log("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **Przejście do orientacji poziomej bez zmiany rozmiaru papieru**

Aby zmienić tylko orientację, zamień miejscami istniejącą szerokość i wysokość. Zachowuje to długości obu stron, w tym te z niestandardowego rozmiaru papieru. Warunek poniżej zapobiega przekształceniu już poziomej strony z powrotem na pionową i pozostawia stronę kwadratową niezmienioną.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        let width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dla orientacji pionowej użyj tego samego przypisania, gdy `size.getWidth() > size.getHeight()`. Nie podstawiaj wymiarów A4 lub Letter, chyba że chcesz również zmienić rozmiar papieru.

## **Ustaw i zweryfikuj niestandardowy rozmiar strony notatek**

Przypisz oba wymiary jednocześnie, a następnie użyj [Presentation.save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/save/) , aby zapisać prezentację. Ten przykład ustawia stronę poziomą o wymiarach 900 × 600 punktów, zapisuje ją jako PPTX i ponownie otwiera zapisany plik, aby sprawdzić zachowane wartości. Porównanie dopuszcza tolerancję 0,01 punktu dla wartości zmiennoprzecinkowych; nie jest to gwarancja precyzji dla każdego formatu pliku.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let expectedSize = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", slides.SaveFormat.Pptx);

    let reopened = new slides.Presentation("custom-notes.pptx");
    try {
        let actualSize = reopened.getNotesSize().getSize();
        let widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        let heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        let preserved = widthMatches && heightMatches;

        console.log("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        console.log("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Oczekiwany wynik to `900 x 600 points` oraz `Size preserved: true`. Sprawdzenie nowo otwartej prezentacji weryfikuje zapisany plik, a nie tylko ustawienia w pamięci.

## **Eksport notatek i materiałów pomocniczych**

Wymiary strony określają dostępny obszar dla układów notatek lub materiałów pomocniczych. Same nie włączają tych układów: należy także skonfigurować opcje eksportu. Eksport zwykłych slajdów nadal korzysta z wymiarów slajdu.

### **Eksport notatek do PDF i PNG**

Przypisz [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/notescommentslayoutingoptions/) do [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) , aby uwzględnić notatki w pliku PDF. Ten przykład renderuje także pierwszy slajd z notatkami do PNG przy użyciu [Slide.getImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/#getImage) i [RenderingOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/renderingoptions/).

Tryb [BottomTruncated](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/notespositions/) utrzymuje notatki na jednej stronie; notatki, które nie mieszczą się, mogą zostać obcięte. PDF używa stron o wymiarach 900 × 600 punktów. Przy skali obrazu 1 × 1 użytej poniżej, PNG ma 900 × 600 pikseli. Punkty opisują geometrię strony; piksele opisują wyjście rastrowe, którego wymiary zależą również od skali renderowania.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.NotesCommentsLayoutingOptions();
    layout.setNotesPosition(slides.NotesPositions.BottomTruncated);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", slides.SaveFormat.Pdf, pdfOptions);

    let renderingOptions = new slides.RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    let image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Podczas eksportu PDF z długimi notatkami, [BottomFull](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/notespositions/) pozwala na dodatkowe strony w razie potrzeby. Nie używaj tego trybu z wywołaniem pojedynczego slajdu do obrazu powyżej, które go nie obsługuje. Po zmianie rozmiaru sprawdź wynik pod kątem przyciętych notatek oraz rozmieszczenia istniejących obiektów notes‑master; sama zmiana wymiarów strony nie powinna być traktowana jako gwarancja, że cała zawartość się zmieści. Zobacz [Convert PowerPoint to PDF with Notes](/slides/pl/nodejs-java/convert-powerpoint-to-pdf-with-notes/) po więcej informacji o eksporcie notatek.

### **Eksport materiałów pomocniczych do PDF**

Użyj [HandoutLayoutingOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/handoutlayoutingoptions/) do umieszczenia wielu miniatur slajdów na jednej stronie. Poniższy przykład ustawia stronę o wymiarach 900 × 600 punktów i używa [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/handouttype/) , aby rozmieścić do czterech slajdów na stronie. Preset poziomy kontroluje kolejność slajdów; orientacja strony wynika z jej szerokości i wysokości.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.HandoutLayoutingOptions();
    layout.setHandout(slides.HandoutType.Handouts4Horizontal);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Zmiana rozmiaru strony zmienia dostępny obszar siatki materiałów pomocniczych bez zmiany wymiarów slajdów źródłowych. Do obrazów materiałów pomocniczych użyj [Presentation.getImages](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/getimages/) z układem handout, zamiast metody obrazu pojedynczego slajdu. W Aspose.Slides renderowanie handout na poziomie prezentacji korzysta z wymiarów strony notatek, podczas gdy wywołanie obrazu pojedynczego slajdu nie generuje strony handout. Zobacz [Handout Mode](/slides/pl/nodejs-java/convert-powerpoint-in-handout-mode/) po opcje układu.

## **Rozmiar strony w przeglądarkach, eksporcie i drukowaniu**

Utrzymuj odrębny rozmiar zapisanej prezentacji, rozmiar eksportowanej strony i rozmiar drukowanego papieru:

- **Przeglądarki prezentacji:** Przeglądarka może wyświetlać lub drukować notatki, stosując własne zasady układu. Jeśli inna aplikacja zapisze plik, otwórz go ponownie i sprawdź wymiary; konwersja formatu tej aplikacji może je znormalizować.
- **Formaty eksportu:** Przykłady PDF z notatkami i materiałami pomocniczymi powyżej używają skonfigurowanych wymiarów strony. Obrazy rastrowe używają całkowitych wymiarów w pikselach i skali renderowania, więc ułamkowe wartości punktów mogą być zaokrąglane w wyjściu obrazu. Eksport zwykłych slajdów nie stosuje rozmiaru strony notatek.
- **Sterowniki drukarek:** Wybór papieru, automatyczna rotacja i ustawienia dopasowania do strony mogą zmienić fizyczny wydruk bez zmiany wymiarów zapisanych w prezentacji lub PDF. Dla konkretnego rozmiaru papieru dopasuj ustawienia drukarki i sprawdź podgląd wydruku.

## **FAQ**

**Czy mogę ustawić rozmiar notatek tylko dla jednego slajdu?**

Rozmiar strony notatek jest ustawieniem na poziomie prezentacji. Poszczególne slajdy mogą mieć różną zawartość notatek, ale ta właściwość nie zapewnia osobnego rozmiaru strony dla każdego slajdu.

**Dlaczego zmiana orientacji notatek nie zmieniła moich slajdów?**

Strony notatek i zwykłe slajdy mają niezależne wymiary. Użyj ustawień rozmiaru zwykłych slajdów, gdy chcesz zmienić rozmiar samych slajdów.

**Dlaczego mój zapisany lub wydrukowany wynik ma inny rozmiar?**

Najpierw otwórz ponownie zapisaną prezentację i porównaj wymiary notatek. Jeśli uległy zmianie, sprawdź, czy zapis lub konwersja pliku w innej aplikacji zmieniła ustawienia strony. Jeśli nie, sprawdź układ eksportu, skalę obrazu, ustawienia przeglądarki oraz wybór papieru w drukarce.