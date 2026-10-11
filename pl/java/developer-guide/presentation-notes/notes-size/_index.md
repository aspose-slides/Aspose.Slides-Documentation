---
title: Zmień rozmiar i orientację strony notatek w Java
linktitle: Rozmiar strony notatek
type: docs
weight: 10
url: /pl/java/notes-size/
keywords:
- rozmiar strony notatek
- orientacja notatek
- notatki poziome
- notatki pionowe
- rozmiar ulotki
- PowerPoint
- prezentacja
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Odczytaj i zmień wymiary strony notatek w Aspose.Slides dla Java, zmień orientację, zweryfikuj zapisane rozmiary oraz wyeksportuj notatki lub ulotki do PDF i obrazów."
---
## **Przegląd**

Użyj [Presentation.getNotesSize](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getNotesSize--) aby uzyskać dostęp do ustawień strony notatek prezentacji. Zwraca on obiekt [INotesSize](https://reference.aspose.com/slides/pl/java/com.aspose.slides/inotessize/) którego metoda [setSize](https://reference.aspose.com/slides/pl/java/com.aspose.slides/inotessize/#setSize-java.awt.geom.Dimension2D-) ustawia wymiary strony. Chociaż obiektu ustawień nie można wymienić, można przypisać nowe wymiary przy użyciu tej metody.

Szerokość i wysokość podawane są w **punktach**, przy 72 punktach na cal. Na przykład 900 × 600 punktów to 12,5 × 8⅓ cala. Ustawienia te dotyczą całej prezentacji, a nie notatek pojedynczego slajdu.

| Ustawienie | Cel |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getNotesSize--) | Kontroluje wymiary strony notatek oraz wymiary strony używane przy eksporcie ulotek. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getSlideSize--) | Kontroluje wymiary standardowych slajdów prezentacji za pomocą [ISlideSize](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidesize/). |

Zmiana jednego z tych ustawień nie powoduje automatycznej zmiany drugiego. Zmiana orientacji strony notatek nie obraca również standardowych slajdów. Zobacz [Rozmiar slajdu](/slides/pl/java/slide-size/) aby zmienić rozmiar standardowych slajdów.

Poniższe przykłady używają istniejącego pliku `sample.pptx`. Dla przykładów eksportu użyj prezentacji z co najmniej jednym slajdem zawierającym notatki prelegenta. Każdy przykład może być uruchomiony niezależnie.

## **Odczyt rozmiaru i orientacji strony notatek**

Odczytaj szerokość i wysokość oraz porównaj je, aby określić orientację: szersza strona to tryb poziomy, wyższa – tryb pionowy, a równe wymiary opisują stronę kwadratową. Ten przykład wypisuje rzeczywiste wymiary w punktach, bez zakładania standardowego rozmiaru papieru.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();
    String orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    System.out.println("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    System.out.println("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **Przełącz na orientację poziomą bez zmiany rozmiaru papieru**

Aby zmienić tylko orientację, zamień istniejącą szerokość i wysokość miejscami. Zachowuje to długości obu boków, w tym te z niestandardowego rozmiaru papieru. Poniższy warunek zapobiega przełączeniu już poziomej strony z powrotem na pionową i pozostawia niezmienioną stronę kwadratową.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        double width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dla orientacji pionowej użyj tego samego przypisania, gdy `size.getWidth() > size.getHeight()`. Nie podstawiaj wymiarów A4 ani Letter, chyba że chcesz również zmienić rozmiar papieru.

## **Ustaw i zweryfikuj niestandardowy rozmiar strony notatek**

Przypisz oba wymiary jednocześnie, a następnie użyj [Presentation.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#save-java.lang.String-int-) aby zapisać prezentację. Ten przykład ustawia stronę poziomą o wymiarach 900 × 600 punktów, zapisuje ją jako PPTX i ponownie otwiera zapisany plik, aby sprawdzić zachowane wartości. Porównanie dopuszcza tolerancję 0,01 punktu dla wartości zmiennoprzecinkowych; nie jest to gwarancja precyzji dla każdego formatu pliku.

```java
import com.aspose.slides.*;
import java.awt.Dimension;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D expectedSize = new Dimension(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        Dimension2D actualSize = reopened.getNotesSize().getSize();
        boolean widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        boolean heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        boolean preserved = widthMatches && heightMatches;

        System.out.println("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        System.out.println("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Oczekiwanym wynikiem jest `900.0 x 600.0 points` oraz `Size preserved: true`. Sprawdzenie nowo otwartej prezentacji weryfikuje zapisany plik, a nie tylko ustawienia w pamięci.

## **Eksport notatek i ulotek**

Wymiary strony definiują dostępny obszar dla układów notatek lub ulotek. Same w sobie nie włączają tych układów: należy również skonfigurować opcje eksportu. Eksport standardowych slajdów nadal używa wymiarów slajdu.

### **Eksport notatek do PDF i PNG**

Przypisz [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/notescommentslayoutingoptions/) do [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) aby uwzględnić notatki w PDF. Ten przykład renderuje również pierwszy slajd z notatkami do PNG przy użyciu [Slide.getImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) i [RenderingOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/renderingoptions/).

Tryb [BottomTruncated](https://reference.aspose.com/slides/pl/java/com.aspose.slides/notespositions/) utrzymuje notatki na jednej stronie; notatki, które nie mieszczą się, mogą być obcięte. PDF używa stron o wymiarach 900 × 600 punktów. Przy skali obrazu 1 × 1 użytej poniżej, PNG ma 900 × 600 pikseli. Punkty opisują geometrię strony; piksele opisują wyjście rastrowe, którego wymiary zależą również od skali renderowania.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    NotesCommentsLayoutingOptions layout = new NotesCommentsLayoutingOptions();
    layout.setNotesPosition(NotesPositions.BottomTruncated);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", SaveFormat.Pdf, pdfOptions);

    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    IImage image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Dla eksportu PDF z długimi notatkami, [BottomFull](https://reference.aspose.com/slides/pl/java/com.aspose.slides/notespositions/) pozwala na dodatkowe strony w razie potrzeby. Nie używaj tego trybu z wywołaniem obrazu pojedynczego slajdu powyżej, które go nie obsługuje. Po zmianie rozmiaru sprawdź wyjście pod kątem przyciętych notatek oraz rozmieszczenia istniejących obiektów notes-master; zmiana samych wymiarów strony nie powinna być traktowana jako gwarancja, że cała zawartość zmieści się. Zobacz [Konwertuj PowerPoint do PDF z notatkami](/slides/pl/java/convert-powerpoint-to-pdf-with-notes/) po więcej informacji o eksporcie notatek.

### **Eksport ulotek do PDF**

Użyj [HandoutLayoutingOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/handoutlayoutingoptions/) aby umieścić miniatury wielu slajdów na jednej stronie. Poniższy przykład ustawia stronę o wymiarach 900 × 600 punktów i używa [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/pl/java/com.aspose.slides/handouttype/) aby rozmieścić do czterech slajdów na stronę. Ustawienie poziome kontroluje kolejność slajdów; orientacja strony wynika z jej szerokości i wysokości.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    HandoutLayoutingOptions layout = new HandoutLayoutingOptions();
    layout.setHandout(HandoutType.Handouts4Horizontal);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Zmiana rozmiaru strony zmienia obszar dostępny dla siatki ulotek bez zmiany wymiarów slajdów źródłowych. Dla obrazów ulotek użyj [Presentation.getImages](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) z układem ulotek, zamiast metody obrazującej pojedynczy slajd. W Aspose.Slides renderowanie ulotek na poziomie prezentacji korzysta z wymiarów strony notatek, podczas gdy wywołanie obrazu pojedynczego slajdu nie generuje strony ulotki. Zobacz [Handout Mode](/slides/pl/java/convert-powerpoint-in-handout-mode/) po opcje układu.

## **Rozmiar strony w przeglądarkach, eksporcie i drukowaniu**

Zachowaj odrębność rozmiaru przechowywanej prezentacji, rozmiaru eksportowanej strony oraz rozmiaru drukowanego papieru:

- **Przeglądarki prezentacji:** Przeglądarka może wyświetlać lub drukować notatki, stosując własne zasady układu. Jeśli inna aplikacja zapisze plik, otwórz go ponownie i sprawdź wymiary; konwersja formatu w tej aplikacji może je znormalizować.
- **Formaty eksportu:** Powyższe przykłady PDF notatek i ulotek używają skonfigurowanych wymiarów strony. Obrazy rastrowe używają całkowitych wymiarów w pikselach i skali renderowania, więc ułamkowe wartości punktów mogą być zaokrąglane w wyjściu obrazu. Eksport standardowych slajdów nie stosuje rozmiaru strony notatek.
- **Sterowniki drukarek:** Wybór papieru, automatyczne obracanie i ustawienia dopasowania do strony mogą zmienić fizyczny wydruk bez zmiany wymiarów zapisanych w prezentacji lub PDF. Dla konkretnego rozmiaru papieru dopasuj ustawienia drukarki i sprawdź podgląd wydruku.

## **FAQ**

**Czy mogę ustawić rozmiar notatek tylko dla jednego slajdu?**

Rozmiar strony notatek jest ustawieniem na poziomie prezentacji. Poszczególne slajdy mogą mieć różną treść notatek, ale ta właściwość nie umożliwia określenia osobnego rozmiaru strony dla każdego slajdu.

**Dlaczego zmiana orientacji notatek nie zmieniła moich slajdów?**

Strony notatek i standardowe slajdy mają niezależne wymiary. Użyj ustawień rozmiaru standardowych slajdów, gdy chcesz zmienić rozmiar samych slajdów.

**Dlaczego mój zapisany lub wydrukowany wynik ma inny rozmiar?**

Najpierw otwórz ponownie zapisaną prezentację i porównaj jej wymiary notatek. Jeśli się zmieniły, sprawdź, czy zapis lub konwersja pliku w innej aplikacji zmieniły ustawienia strony. Jeśli nie, sprawdź układ eksportu, skalę obrazu, ustawienia przeglądarki oraz wybór papieru w drukarce.