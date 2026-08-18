---
title: "Klonowanie slajdów prezentacji w JavaScript"
linktitle: "Klonuj slajdy"
type: docs
weight: 35
url: /pl/nodejs-java/clone-slides/
keywords:
- "klonuj slajd"
- "kopiuj slajd"
- "zapisz slajd"
- "PowerPoint"
- "OpenDocument"
- "prezentacja"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Szybko duplikuj slajdy PowerPoint przy użyciu Aspose.Slides dla Node.js. Postępuj zgodnie z naszymi przykładami kodu, aby zautomatyzować tworzenie prezentacji PPT w kilka sekund i wyeliminować ręczną pracę."
---
## **Wprowadzenie**

Klonowanie to proces tworzenia dokładnej kopii lub repliki czegoś. Aspose.Slides for Node.js via Java umożliwia również utworzenie kopii lub klona dowolnego slajdu, a następnie wstawienie tego sklonowanego slajdu do bieżącej lub dowolnej innej otwartej prezentacji. Proces klonowania slajdu tworzy nowy slajd, który może być modyfikowany przez programistów bez zmiany oryginalnego slajdu. Istnieje kilka możliwych sposobów klonowania slajdu:

- Klonowanie na końcu w obrębie prezentacji.
- Klonowanie w innym miejscu w obrębie prezentacji.
- Klonowanie na końcu w innej prezentacji.
- Klonowanie w innym miejscu w innej prezentacji.
- Klonowanie w określonym miejscu w innej prezentacji.

W Aspose.Slides for Node.js via Java (kolekcja obiektów [Slide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Slide) udostępniana przez obiekt [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) zapewnia metody [addClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) i [insertClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) umożliwiające wykonanie powyższych rodzajów klonowania slajdów

## **Klonowanie na końcu w obrębie prezentacji**
Jeśli chcesz sklonować slajd i następnie użyć go w tym samym pliku prezentacji na końcu istniejących slajdów, użyj metody [addClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
2. Zainicjuj klasę [SlideCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#getSlides--) odwołując się do kolekcji Slides udostępnianej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
3. Wywołaj metodę [addClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) udostępnioną przez obiekt [SlideCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#getSlides--) i przekaż slajd do sklonowania jako parametr tej metody.
4. Zapisz zmodyfikowany plik prezentacji.

W poniższym przykładzie sklonowaliśmy slajd (znajdujący się na pierwszej pozycji – indeks zero – prezentacji) na koniec prezentacji.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Utwórz klasę Presentation, która reprezentuje plik prezentacji
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Sklonuj wybrany slajd na koniec kolekcji slajdów w tej samej prezentacji
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // Zapisz zmodyfikowaną prezentację na dysk
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klonowanie w innym miejscu w obrębie prezentacji**
Jeśli chcesz sklonować slajd i następnie użyć go w tym samym pliku prezentacji, ale w innej pozycji, użyj metody [insertClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-):

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
2. Zainicjuj klasę, odwołując się do kolekcji [**Slides**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#getSlides--) udostępnianej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
3. Wywołaj metodę [insertClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) udostępnioną przez obiekt [SlideCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#getSlides--) i przekaż slajd do sklonowania wraz z indeksem nowej pozycji jako parametr tej metody.
4. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie sklonowaliśmy slajd (znajdujący się pod indeksem 1 – pozycja 2 – prezentacji) na indeks 2 – pozycja 3 – prezentacji.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Utwórz klasę Presentation, która reprezentuje plik prezentacji
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // Sklonuj wybrany slajd na koniec kolekcji slajdów w tej samej prezentacji
    var slds = pres.getSlides();
    // Sklonuj wybrany slajd do określonego indeksu w tej samej prezentacji
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // Zapisz zmodyfikowaną prezentację na dysk
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klonowanie na końcu w innej prezentacji**
Jeśli potrzebujesz sklonować slajd z jednej prezentacji i użyć go w innej prezentacji, na końcu istniejących slajdów:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) zawierającej prezentację, z której slajd zostanie sklonowany.
2. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) zawierającej docelową prezentację, do której slajd zostanie dodany.
3. Zainicjuj klasę [SlideCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection) odwołując się do kolekcji [**Slides**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#getSlides--) udostępnianej przez obiekt Presentation docelowej prezentacji.
4. Wywołaj metodę [addClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) udostępnioną przez obiekt [SlideCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#getSlides--) i przekaż slajd z prezentacji źródłowej jako parametr tej metody.
5. Zapisz zmodyfikowany plik docelowej prezentacji.

W poniższym przykładzie sklonowaliśmy slajd (z pierwszego indeksu prezentacji źródłowej) na koniec docelowej prezentacji.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Utwórz klasę Presentation, aby załadować plik prezentacji źródłowej
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Utwórz klasę Presentation dla docelowego PPTX (gdzie slajd ma być sklonowany)
    var destPres = new aspose.slides.Presentation();
    try {
        // Sklonuj wybrany slajd z prezentacji źródłowej na koniec kolekcji slajdów w prezentacji docelowej
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // Zapisz docelową prezentację na dysk
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klonowanie w innym miejscu w innej prezentacji**
Jeśli potrzebujesz sklonować slajd z jednej prezentacji i użyć go w innej prezentacji, w określonej pozycji:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) zawierającej prezentację źródłową, z której slajd zostanie sklonowany.
2. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) zawierającej prezentację, do której slajd zostanie dodany.
3. Zainicjuj klasę [SlideCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#getSlides--) odwołując się do kolekcji Slides udostępnianej przez obiekt Presentation docelowej prezentacji.
4. Wywołaj metodę [insertClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) udostępnioną przez obiekt [SlideCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#getSlides--) i przekaż slajd z prezentacji źródłowej wraz z żądaną pozycją jako parametr tej metody.
5. Zapisz zmodyfikowany plik docelowej prezentacji.

W poniższym przykładzie sklonowaliśmy slajd (z indeksu zero prezentacji źródłowej) na indeks 1 (pozycja 2) docelowej prezentacji.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Utwórz klasę Presentation, aby załadować plik prezentacji źródłowej
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Utwórz klasę Presentation dla docelowego PPTX (gdzie slajd ma być sklonowany)
    var destPres = new aspose.slides.Presentation();
    try {
        // Sklonuj wybrany slajd z prezentacji źródłowej na koniec kolekcji slajdów w prezentacji docelowej
        var slds = destPres.getSlides();
        slds.insertClone(1, srcPres.getSlides().get_Item(0));
        // Zapisz docelową prezentację na dysk
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klonowanie w określonym miejscu w innej prezentacji**
Jeśli musisz sklonować slajd wraz z master‑slajdem z jednej prezentacji i użyć go w innej prezentacji, najpierw musisz sklonować żądany master‑slajd z prezentacji źródłowej do prezentacji docelowej. Następnie należy użyć tego master‑slajdu do klonowania slajdu z master‑slajdem. Metoda [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) oczekuje master‑slajdu z prezentacji docelowej, a nie ze źródłowej. Aby sklonować slajd wraz z master‑slajdem, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) zawierającej prezentację źródłową, z której slajd zostanie sklonowany.
2. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) zawierającej docelową prezentację, do której slajd zostanie sklonowany.
3. Uzyskaj dostęp do slajdu, który ma być sklonowany, wraz z master‑slajdem.
4. Zainicjuj klasę [MasterSlideCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/MasterSlideCollection) odwołując się do kolekcji Masters udostępnianej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) docelowej prezentacji.
5. Wywołaj metodę [addClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) udostępnioną przez obiekt [MasterSlideCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/MasterSlideCollection) i przekaż master‑slajd z pliku źródłowego PPTX jako parametr tej metody.
6. Zainicjuj klasę [SlideCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#getSlides--) ustawiając odwołanie do kolekcji Slides udostępnianej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) docelowej prezentacji.
7. Wywołaj metodę [addClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) udostępnioną przez obiekt [SlideCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#getSlides--) i przekaż slajd z prezentacji źródłowej do sklonowania oraz master‑slajd jako parametr tej metody.
8. Zapisz zmodyfikowany plik docelowej prezentacji.

W poniższym przykładzie sklonowaliśmy slajd z master‑slajdem (znajdujący się na indeksie zero prezentacji źródłowej) na koniec prezentacji docelowej, używając master‑slajdu ze slajdu źródłowego.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instantiate Presentation class to load the source presentation file
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instantiate Presentation class for destination presentation (where slide is to be cloned)
    var destPres = new aspose.slides.Presentation();
    try {
        // Instantiate ISlide from the collection of slides in source presentation along with
        // Master slide
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Clone the desired master slide from the source presentation to the collection of masters in the
        // Destination presentation
        var masters = destPres.getMasters();
        var DestMaster = masters.addClone(SourceMaster);
        // Clone the desired slide from the source presentation with the desired master to the end of the
        // Collection of slides in the destination presentation
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);
        // Save the destination presentation to disk
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klonowanie na końcu w określonej sekcji**
Jeśli chcesz sklonować slajd i następnie użyć go w tym samym pliku prezentacji, ale w innej sekcji, użyj metody [**addClone**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) udostępnionej przez klasę [**SlideCollection**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection). Aspose.Slides for Node.js via Java umożliwia sklonowanie slajdu z pierwszej sekcji i wstawienie tego sklonowanego slajdu do drugiej sekcji tej samej prezentacji.

Poniższy fragment kodu pokazuje, jak sklonować slajd i wstawić sklonowany slajd do określonej sekcji.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // Zapisz docelową prezentację na dysk
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Zapewnienie zgodnego rozmiaru slajdu**

Podczas klonowania slajdów do innej prezentacji upewnij się, że prezentacja docelowa ma taki sam rozmiar slajdu jak źródłowa. Jeśli rozmiary slajdów różnią się, Aspose.Slides nie skalowuje automatycznie sklonowanych kształtów – ich pierwotne współrzędne i wymiary są zachowane, co może spowodować nieprawidłowe wyrównanie treści lub wyjście poza granice slajdu.

Możesz ustawić rozmiar slajdu prezentacji docelowej, aby odpowiadał rozmiarowi źródłowemu przed klonowaniem master‑slajdu i slajdu:

```javascript
const sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), aspose.slides.SlideSizeScaleType.DoNotScale);
```

Wykonaj to przed klonowaniem master‑slajdu i slajdu.

## **FAQ**

**Czy notatki prelegenta i komentarze recenzentów są klonowane?**

Tak. Strona notatek i komentarze recenzji są zawarte w klonie. Jeśli ich nie chcesz, [usuń je](/slides/pl/nodejs-java/presentation-notes/) po wstawieniu.

**Jak obsługiwane są wykresy i ich źródła danych?**

Obiekt wykresu, formatowanie i osadzone dane są kopiowane. Jeśli wykres był powiązany zewnętrznie (np. z osadzonym skoroszytem OLE), to powiązanie jest zachowane jako [obiekt OLE](/slides/pl/nodejs-java/manage-ole/). Po przeniesieniu między plikami sprawdź dostępność danych i zachowanie odświeżania.

**Czy mogę kontrolować pozycję wstawiania i sekcje dla klonu?**

Tak. Możesz wstawić klon na określony indeks slajdu i umieścić go w wybranej [sekcji](/slides/pl/nodejs-java/slide-section/). Jeśli docelowa sekcja nie istnieje, najpierw ją utwórz, a następnie przenieś slajd do niej.