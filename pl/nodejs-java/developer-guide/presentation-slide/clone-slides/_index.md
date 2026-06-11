---
title: "Klonowanie slajdów prezentacji w JavaScript"
linktitle: "Klonuj slajdy"
type: docs
weight: 35
url: /pl/nodejs-java/clone-slides/
keywords:
- "klonowanie slajdu"
- "kopiowanie slajdu"
- "zapis slajdu"
- "PowerPoint"
- "OpenDocument"
- "prezentacja"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Szybko duplikuj slajdy PowerPoint za pomocą Aspose.Slides dla Node.js. Śledź nasze przykłady kodu, aby zautomatyzować tworzenie prezentacji PPT w kilka sekund i wyeliminować ręczną pracę."
---
## **Wprowadzenie**

Klonowanie to proces tworzenia dokładnej kopii lub reprodukcji czegoś. Aspose.Slides for Node.js via Java umożliwia także wykonanie kopii lub klona dowolnego slajdu, a następnie wstawienie tego sklonowanego slajdu do bieżącej lub innej otwartej prezentacji. Proces klonowania slajdu tworzy nowy slajd, który może być modyfikowany przez programistów bez zmiany oryginalnego slajdu. Istnieje kilka możliwych sposobów klonowania slajdu:

- Klonowanie na końcu w obrębie prezentacji.
- Klonowanie w innej pozycji w obrębie prezentacji.
- Klonowanie na końcu w innej prezentacji.
- Klonowanie w innej pozycji w innej prezentacji.
- Klonowanie w określonej pozycji w innej prezentacji.

W Aspose.Slides for Node.js via Java, (kolekcja obiektów [Slide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Slide)) udostępniona przez obiekt [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) zapewnia metody [addClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) oraz [insertClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) do wykonywania wymienionych rodzajów klonowania slajdów

## **Klonowanie na końcu w obrębie prezentacji**
Jeśli chcesz sklonować slajd i następnie użyć go w tym samym pliku prezentacji na końcu istniejących slajdów, użyj metody [addClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
2. Zainicjuj klasę [SlideCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#getSlides--) odwołując się do kolekcji Slides udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
3. Wywołaj metodę [addClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) udostępnioną przez obiekt [SlideCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#getSlides--) i przekazując slajd do sklonowania jako parametr do metody [addClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
4. Zapisz zmodyfikowany plik prezentacji.

W poniższym przykładzie sklonowaliśmy slajd (znajdujący się na pierwszej pozycji – indeks zero – w prezentacji) na koniec prezentacji.

```javascript
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Sklonuj wybrany slajd na koniec kolekcji slajdów w tej samej prezentacji
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // Zapisz zmodyfikowaną prezentację na dysku
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klonowanie w innej pozycji w obrębie prezentacji**
Jeśli chcesz sklonować slajd i następnie użyć go w tym samym pliku prezentacji, ale w innej pozycji, użyj metody [insertClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-):

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
2. Zainicjuj klasę, odwołując się do kolekcji [**Slides**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#getSlides--) udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
3. Wywołaj metodę [insertClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) udostępnioną przez obiekt [SlideCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#getSlides--) i przekazując slajd do sklonowania wraz z indeksem nowej pozycji jako parametr do metody [insertClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
4. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie sklonowaliśmy slajd (znajdujący się na indeksie zero – pozycja 1 – w prezentacji) do indeksu 1 – pozycja 2 – w prezentacji.

```javascript
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // Sklonuj wybrany slajd na koniec kolekcji slajdów w tej samej prezentacji
    var slds = pres.getSlides();
    // Sklonuj wybrany slajd do określonego indeksu w tej samej prezentacji
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // Zapisz zmodyfikowaną prezentację na dysku
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klonowanie na końcu w innej prezentacji**
Jeśli musisz sklonować slajd z jednej prezentacji i użyć go w innym pliku prezentacji, na końcu istniejących slajdów:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation), zawierającą prezentację, z której slajd będzie klonowany.
2. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation), zawierającą docelową prezentację, do której slajd zostanie dodany.
3. Zainicjuj klasę [SlideCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection) odwołując się do kolekcji [**Slides**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#getSlides--) udostępnionej przez obiekt Presentation docelowej prezentacji.
4. Wywołaj metodę [addClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) udostępnioną przez obiekt [SlideCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#getSlides--) i przekazując slajd z prezentacji źródłowej jako parametr do metody [addClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
5. Zapisz zmodyfikowany plik docelowej prezentacji.

W poniższym przykładzie sklonowaliśmy slajd (z pierwszego indeksu prezentacji źródłowej) na koniec docelowej prezentacji.

```javascript
// Utwórz instancję klasy Presentation, aby załadować plik prezentacji źródłowej
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Utwórz instancję klasy Presentation dla docelowego PPTX (gdzie slajd ma zostać sklonowany)
    var destPres = new aspose.slides.Presentation();
    try {
        // Sklonuj wybrany slajd z prezentacji źródłowej na koniec kolekcji slajdów w prezentacji docelowej
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // Zapisz docelową prezentację na dysku
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klonowanie w innej pozycji w innej prezentacji**
Jeśli musisz sklonować slajd z jednej prezentacji i użyć go w innym pliku prezentacji, w określonej pozycji:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation), zawierającą prezentację źródłową, z której slajd będzie klonowany.
2. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation), zawierającą prezentację, do której slajd zostanie dodany.
3. Zainicjuj klasę [SlideCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#getSlides--) odwołując się do kolekcji Slides udostępnionej przez obiekt Presentation docelowej prezentacji.
4. Wywołaj metodę [insertClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) udostępnioną przez obiekt [SlideCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#getSlides--) i przekazując slajd z prezentacji źródłowej wraz z żądaną pozycją jako parametr do metody [insertClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
5. Zapisz zmodyfikowany plik docelowej prezentacji.

W poniższym przykładzie sklonowaliśmy slajd (z indeksu zero prezentacji źródłowej) do indeksu 1 (pozycja 2) w docelowej prezentacji.

```javascript
// Utwórz instancję klasy Presentation, aby załadować plik prezentacji źródłowej
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Utwórz instancję klasy Presentation dla docelowego PPTX (gdzie slajd ma zostać sklonowany)
    var destPres = new aspose.slides.Presentation();
    try {
        // Sklonuj wybrany slajd z prezentacji źródłowej na koniec kolekcji slajdów w prezentacji docelowej
        var slds = destPres.getSlides();
        slds.insertClone(2, srcPres.getSlides().get_Item(0));
        // Zapisz docelową prezentację na dysku
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klonowanie w określonej pozycji w innej prezentacji**
Jeśli musisz sklonować slajd z master slajdem z jednej prezentacji i użyć go w innej prezentacji, najpierw musisz sklonować żądany master slajd z prezentacji źródłowej do docelowej. Następnie użyj tego master slajdu do klonowania slajdu z master slajdem. Metoda [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) oczekuje master slajdu z docelowej prezentacji, a nie ze źródłowej. Aby sklonować slajd z masterem, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation), zawierającą prezentację źródłową, z której slajd będzie klonowany.
2. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation), zawierającą docelową prezentację, do której slajd zostanie sklonowany.
3. Uzyskaj dostęp do slajdu, który ma być sklonowany, wraz z jego master slajdem.
4. Zainicjuj klasę [MasterSlideCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/MasterSlideCollection) odwołując się do kolekcji Masters udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) docelowej prezentacji.
5. Wywołaj metodę [addClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) udostępnioną przez obiekt [MasterSlideCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/MasterSlideCollection) i przekazując master z źródłowego pliku PPTX do sklonowania jako parametr do metody [addClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
6. Zainicjuj klasę [SlideCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#getSlides--) ustawiając odwołanie do kolekcji Slides udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) docelowej prezentacji.
7. Wywołaj metodę [addClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) udostępnioną przez obiekt [SlideCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#getSlides--) i przekazując slajd z prezentacji źródłowej do sklonowania oraz master slajd jako parametr do metody [addClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
8. Zapisz zmodyfikowany plik docelowej prezentacji.

W poniższym przykładzie sklonowaliśmy slajd z masterem (znajdujący się na indeksie zero w prezentacji źródłowej) na koniec docelowej prezentacji, używając mastera ze slajdu źródłowego.

```javascript
// Utwórz instancję klasy Presentation, aby załadować plik prezentacji źródłowej
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Utwórz instancję klasy Presentation dla prezentacji docelowej (gdzie slajd ma zostać sklonowany)
    var destPres = new aspose.slides.Presentation();
    try {
        // Utwórz obiekt ISlide z kolekcji slajdów w prezentacji źródłowej wraz z
        // magistralnym slajdem
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Sklonuj żądany slajd magistralny z prezentacji źródłowej do kolekcji magistrali w
        // prezentacji docelowej
        var masters = destPres.getMasters();
        var DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Sklonuj żądany slajd magistralny z prezentacji źródłowej do kolekcji magistrali w
        // prezentacji docelowej
        var iSlide = masters.addClone(SourceMaster);
        // Sklonuj żądany slajd z prezentacji źródłowej z określonym magistralnym slajdem na koniec
        // kolekcji slajdów w prezentacji docelowej
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);
        // Zapisz prezentację docelową na dysku
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klonowanie na końcu w określonej sekcji**
Jeśli chcesz sklonować slajd i następnie użyć go w tym samym pliku prezentacji, ale w innej sekcji, użyj metody [**addClone**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) udostępnionej przez klasę [**SlideCollection**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection). Aspose.Slides for Node.js via Java umożliwia klonowanie slajdu z pierwszej sekcji i wstawienie tego sklonowanego slajdu do drugiej sekcji tej samej prezentacji.

Poniższy fragment kodu pokazuje, jak sklonować slajd i wstawić sklonowany slajd do określonej sekcji.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // Zapisz prezentację docelową na dysku
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **FAQ**

**Czy notatki prelegenta i komentarze recenzenta są klonowane?**

Tak. Strona notatek i komentarze recenzenta są włączone do klona. Jeśli ich nie chcesz, [usuń je](/slides/pl/nodejs-java/presentation-notes/) po wstawieniu.

**Jak obsługiwane są wykresy i ich źródła danych?**

Obiekt wykresu, formatowanie i osadzone dane są kopiowane. Jeśli wykres był powiązany z zewnętrznym źródłem (np. z osadzonym w OLE skoroszytem), to powiązanie jest zachowane jako [obiekt OLE](/slides/pl/nodejs-java/manage-ole/). Po przeniesieniu między plikami sprawdź dostępność danych oraz zachowanie odświeżania.

**Czy mogę kontrolować pozycję wstawiania i sekcje dla klona?**

Tak. Możesz wstawić klon na określonym indeksie slajdu i umieścić go w wybranej [sekcji](/slides/pl/nodejs-java/slide-section/). Jeśli docelowa sekcja nie istnieje, najpierw ją utwórz, a następnie przenieś do niej slajd.