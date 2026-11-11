---
title: Zmień rozmiar i orientację strony notatek na Androidzie
linktitle: Rozmiar strony notatek
type: docs
weight: 10
url: /pl/androidjava/notes-size/
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
- Android
- Java
- Aspose.Slides
description: "Odczytaj i zmień wymiary strony notatek w Aspose.Slides dla Androida przy użyciu Javy, zmień orientację, zweryfikuj zapisane rozmiary oraz wyeksportuj notatki lub materiały pomocnicze do PDF i obrazów."
---
## **Przegląd**

Użyj [Presentation.getNotesSize](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getNotesSize--) aby uzyskać dostęp do ustawień strony notatek prezentacji. Zwraca on obiekt [INotesSize](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/inotessize/) którego metoda [setSize](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/inotessize/#setSize-com.aspose.slides.android.SizeF-) ustawia wymiary strony. Chociaż sam obiekt ustawień nie może zostać zastąpiony, możesz przypisać nowe wymiary za pomocą tej metody.

Szerokość i wysokość podawane są w **punktach**, przy 72 punktach na cal. Na przykład 900 × 600 punktów to 12,5 × 8⅓ cala. Ustawienia te dotyczą całej prezentacji, a nie notatek pojedynczego slajdu.

| Ustawienie | Cel |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getNotesSize--) | Kontroluje wymiary strony notatek oraz wymiary strony używane przy eksporcie materiałów pomocniczych. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getSlideSize--) | Kontroluje rozmiary standardowych slajdów prezentacji poprzez [ISlideSize](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidesize/). |

Zmiana jednego z ustawień nie powoduje automatycznej zmiany drugiego. Zmiana orientacji strony notatek nie obraca również standardowych slajdów. Zobacz [Slide Size](/slides/pl/androidjava/slide-size/), aby zmienić rozmiar standardowych slajdów.

Poniższe przykłady używają istniejącego pliku `sample.pptx`. Dla przykładów eksportu użyj prezentacji zawierającej co najmniej jeden slajd z notatkami prelegenta. Każdy przykład może być uruchomiony niezależnie.

## **Odczyt rozmiaru i orientacji strony notatek**

Odczytaj szerokość i wysokość i porównaj je, aby określić orientację: szersza strona to tryb poziomy, wyższa strona to tryb pionowy, a równe wymiary opisują stronę kwadratową. Ten przykład wypisuje rzeczywiste wymiary w punktach, bez zakładania standardowego rozmiaru papieru.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();
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

Aby zmienić tylko orientację, zamień istniejącą szerokość i wysokość. Dzięki temu zachowane zostają długości obu boków, w tym niestandardowego rozmiaru papieru. Warunek poniżej zapobiega przełączeniu już poziomej strony z powrotem na pionową i pozostawia niezmienioną stronę kwadratową.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        SizeF landscapeSize = new SizeF(size.getHeight(), size.getWidth());
        presentation.getNotesSize().setSize(landscapeSize);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dla orientacji pionowej użyj tego samego przypisania, gdy `size.getWidth() > size.getHeight()`. Nie zamieniaj wymiarów A4 ani Letter, chyba że chcesz również zmienić rozmiar papieru.

## **Ustaw i zweryfikuj niestandardowy rozmiar strony notatek**

Przypisz oba wymiary jednocześnie, a następnie użyj [Presentation.save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) aby zapisać prezentację. Ten przykład ustawia stronę w trybie poziomym o wymiarach 900 × 600 punktów, zapisuje ją jako PPTX i ponownie otwiera zapisany plik, aby sprawdzić zachowane wartości. Porównanie dopuszcza tolerancję 0,01 punktu dla wartości zmiennoprzecinkowych; nie jest to gwarancja precyzji dla każdego formatu pliku.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF expectedSize = new SizeF(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        SizeF actualSize = reopened.getNotesSize().getSize();
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

Oczekiwany wynik to `900.0 x 600.0 points` oraz `Size preserved: true`. Sprawdzenie nowo otwartej prezentacji weryfikuje zapisany plik, a nie tylko ustawienia w pamięci.

## **Eksport notatek i materiałów pomocniczych**

Wymiary strony definiują dostępny obszar dla układów notatek lub materiałów pomocniczych. Same w sobie nie włączają tych układów: należy również skonfigurować opcje eksportu. Eksport standardowych slajdów nadal używa wymiarów slajdu.

### **Eksport notatek do PDF i PNG**

Przypisz [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/notescommentslayoutingoptions/) do [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) aby uwzględnić notatki w PDF. Ten przykład renderuje również pierwszy slajd z notatkami do PNG przy użyciu [Slide.getImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) i [RenderingOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/renderingoptions/).

Tryb [BottomTruncated](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/notespositions/) utrzymuje notatki na jednej stronie; notatki, które nie mieszczą się, mogą być obcięte. PDF używa stron o wymiarach 900 × 600 punktów. Przy skali obrazu 1 × 1 użytej poniżej PNG ma 900 × 600 pikseli. Punkty opisują geometrie strony; piksele opisują wyjście rastrowe, którego wymiary zależą również od skali renderowania.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
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

Podczas eksportu PDF z długimi notatkami, [BottomFull](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/notespositions/) pozwala na dodatkowe strony w razie potrzeby. Nie używaj tego trybu z wywołaniem obrazu pojedynczego slajdu powyżej, które go nie obsługuje. Po zmianie rozmiaru sprawdź wynik pod kątem przyciętych notatek i położenia istniejących obiektów notes‑master; zmiana wymiarów strony sama w sobie nie gwarantuje, że cała zawartość się zmieści. Zobacz [Convert PowerPoint to PDF with Notes](/slides/pl/androidjava/convert-powerpoint-to-pdf-with-notes/) po więcej informacji o eksporcie notatek.

### **Eksport materiałów pomocniczych do PDF**

Użyj [HandoutLayoutingOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/handoutlayoutingoptions/) aby umieścić wiele miniatur slajdów na jednej stronie. Poniższy przykład ustawia stronę o wymiarach 900 × 600 punktów i wykorzystuje [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/handouttype/) aby rozmieszczać do czterech slajdów na stronie. Ustawienie poziome kontroluje kolejność slajdów; orientacja strony pochodzi z jej szerokości i wysokości.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
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

Zmiana rozmiaru strony zmienia dostępny obszar dla siatki materiałów pomocniczych bez zmiany wymiarów slajdów źródłowych. Dla obrazów materiałów pomocniczych użyj [Presentation.getImages](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) z układem handoutu, a nie metody obrazu pojedynczego slajdu. W Aspose.Slides renderowanie handoutu na poziomie prezentacji używa wymiarów strony notatek, podczas gdy wywołanie obrazu pojedynczego slajdu nie tworzy strony handoutu. Zobacz [Handout Mode](/slides/pl/androidjava/convert-powerpoint-in-handout-mode/) po opcje układu.

## **Rozmiar strony w przeglądarkach, eksportach i drukowaniu**

Trzymaj oddzielnie rozmiar przechowywanej prezentacji, rozmiar eksportowanej strony oraz rozmiar drukowanego papieru:

- **Podglądy prezentacji:** Podgląd może wyświetlać lub drukować notatki używając własnych reguł układu. Jeśli inna aplikacja zapisze plik, otwórz go ponownie i sprawdź wymiary; konwersja formatu tej aplikacji może je znormalizować.
- **Formaty eksportu:** Przykłady PDF notatek i materiałów pomocniczych powyżej używają skonfigurowanych wymiarów strony. Obrazy rastrowe używają całkowitych wymiarów w pikselach oraz skali renderowania, więc ułamkowe wartości punktów mogą być zaokrąglane w wyniku obrazu. Eksport standardowych slajdów nie stosuje rozmiaru strony notatek.
- **Sterowniki drukarek:** Wybór papieru, automatyczna rotacja i ustawienia dopasowania do strony mogą zmienić fizyczny wynik bez zmiany wymiarów zapisanych w prezentacji lub PDF. Dla określonego rozmiaru papieru dopasuj ustawienia drukarki i sprawdź podgląd wydruku.

## **FAQ**

**Czy mogę ustawić rozmiar notatek tylko dla jednego slajdu?**

Rozmiar strony notatek jest ustawieniem na poziomie całej prezentacji. Poszczególne slajdy mogą mieć różną treść notatek, ale to właściwość nie zapewnia osobnego rozmiaru strony dla każdego slajdu.

**Dlaczego zmiana orientacji notatek nie zmieniła moich slajdów?**

Strony notatek i standardowe slajdy mają odrębne wymiary. Użyj ustawień rozmiaru regularnych slajdów, gdy chcesz zmienić rozmiar samych slajdów.

**Dlaczego mój zapisany lub wydrukowany wynik ma inny rozmiar?**

Najpierw otwórz ponownie zapisaną prezentację i porównaj wymiary notatek. Jeśli się zmieniły, sprawdź, czy zapis lub konwersja pliku w innej aplikacji zmieniła ustawienia strony. Jeśli nie, sprawdź układ eksportu, skalę obrazu, ustawienia podglądu oraz wybór papieru w drukarce.