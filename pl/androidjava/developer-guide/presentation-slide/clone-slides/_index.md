---
title: "Klonowanie slajdów prezentacji w Androidzie"
linktitle: "Klonuj slajdy"
type: docs
weight: 35
url: /pl/androidjava/clone-slides/
keywords:
- "klonuj slajd"
- "kopiuj slajd"
- "zapisz slajd"
- "PowerPoint"
- "OpenDocument"
- "prezentacja"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Duplikuj slajdy PowerPoint za pomocą Aspose.Slides dla Androida. Skorzystaj z naszych przejrzystych przykładów kodu Java, aby automatyzować tworzenie PPT w kilka sekund i wyeliminować ręczną pracę."
---
## **Wstęp**

Klonowanie jest procesem tworzenia dokładnej kopii lub repliki czegoś. Aspose.Slides for Android via Java umożliwia również wykonanie kopii lub klona dowolnego slajdu, a następnie wstawienie tego sklonowanego slajdu do bieżącej lub dowolnej innej otwartej prezentacji. Proces klonowania slajdu tworzy nowy slajd, który może być modyfikowany przez programistów bez zmiany oryginalnego slajdu. Istnieje kilka możliwych sposobów klonowania slajdu:

- Klonowanie na końcu w obrębie prezentacji.
- Klonowanie w innym miejscu w prezentacji.
- Klonowanie na końcu w innej prezentacji.
- Klonowanie w innym miejscu w innej prezentacji.
- Klonowanie w określonej pozycji w innej prezentacji.

W Aspose.Slides for Android via Java (kolekcja obiektów [ISlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlide) ) udostępniona przez obiekt [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) zapewnia metody [addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) i [insertClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) do wykonywania powyższych typów klonowania slajdów

## **Klonowanie slajdu na końcu prezentacji**
Jeśli chcesz sklonować slajd i użyć go w tym samym pliku prezentacji na końcu istniejących slajdów, użyj metody [addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2. Zainicjalizuj klasę [ISlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getSlides--) odwołując się do kolekcji Slides udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
3. Wywołaj metodę [addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) udostępnioną przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getSlides--) i przekaż slajd do sklonowania jako parametr do metody [addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
4. Zapisz zmodyfikowany plik prezentacji.

W poniższym przykładzie sklonowaliśmy slajd (znajdujący się na pierwszej pozycji – indeks zero – w prezentacji) na koniec prezentacji.

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Sklonuj wybrany slajd na koniec kolekcji slajdów w tej samej prezentacji
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Zapisz zmodyfikowaną prezentację na dysku
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klonowanie slajdu w inną pozycję w obrębie prezentacji**
Jeśli chcesz sklonować slajd i użyć go w tym samym pliku prezentacji, ale w innej pozycji, użyj metody [insertClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2. Zainicjalizuj klasę, odwołując się do kolekcji [**Slides**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getSlides--) udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
3. Wywołaj metodę [insertClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) udostępnioną przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getSlides--) i przekaż slajd do sklonowania wraz z indeksem nowej pozycji jako parametr do metody [insertClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
4. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie sklonowaliśmy slajd (znajdujący się na indeksie zero – pozycja 1 – w prezentacji) do indeksu 1 – Pozycja 2 – w prezentacji.

```java
// Utwórz klasę Presentation, która reprezentuje plik prezentacji
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Sklonuj wybrany slajd na koniec kolekcji slajdów w tej samej prezentacji
    ISlideCollection slds = pres.getSlides();

    // Sklonuj wybrany slajd do wskazanego indeksu w tej samej prezentacji
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Zapisz zmodyfikowaną prezentację na dysku
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klonowanie slajdu na końcu innej prezentacji**
Jeśli potrzebujesz sklonować slajd z jednej prezentacji i użyć go w pliku innej prezentacji, na końcu istniejących slajdów:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) zawierającej prezentację, z której slajd zostanie sklonowany.
2. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) zawierającej docelową prezentację, do której slajd zostanie dodany.
3. Zainicjalizuj klasę [ISlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection) odwołując się do kolekcji [**Slides**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getSlides--) udostępnionej przez obiekt Presentation docelowej prezentacji.
4. Wywołaj metodę [addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) udostępnioną przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getSlides--) i przekaż slajd z prezentacji źródłowej jako parametr do metody [addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
5. Zapisz zmodyfikowany plik docelowej prezentacji.

W poniższym przykładzie sklonowaliśmy slajd (z pierwszego indeksu prezentacji źródłowej) na koniec docelowej prezentacji.

```java
// Utwórz klasę Presentation, aby załadować plik prezentacji źródłowej
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Utwórz klasę Presentation dla docelowego PPTX (gdzie slajd ma zostać sklonowany)
    Presentation destPres = new Presentation();
    try {
        // Sklonuj wybrany slajd z prezentacji źródłowej na koniec kolekcji slajdów w prezentacji docelowej
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Zapisz docelową prezentację na dysku
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klonowanie slajdu w inną pozycję w innej prezentacji**
Jeśli potrzebujesz sklonować slajd z jednej prezentacji i użyć go w pliku innej prezentacji, w konkretnej pozycji:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) zawierającej prezentację źródłową, z której slajd zostanie sklonowany.
2. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) zawierającej prezentację, do której slajd zostanie dodany.
3. Zainicjalizuj klasę [ISlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getSlides--) odwołując się do kolekcji Slides udostępnionej przez obiekt Presentation docelowej prezentacji.
4. Wywołaj metodę [insertClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) udostępnioną przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getSlides--) i przekaż slajd z prezentacji źródłowej wraz z żądaną pozycją jako parametr do metody [insertClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
5. Zapisz zmodyfikowany plik docelowej prezentacji.

W poniższym przykładzie sklonowaliśmy slajd (z indeksu zero prezentacji źródłowej) do indeksu 1 (pozycja 2) w docelowej prezentacji.

```java
// Utwórz klasę Presentation, aby załadować plik prezentacji źródłowej
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Utwórz klasę Presentation dla docelowego PPTX (gdzie slajd ma zostać sklonowany)
    Presentation destPres = new Presentation();
    try {
        // Sklonuj wybrany slajd z prezentacji źródłowej na koniec kolekcji slajdów w prezentacji docelowej
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // Zapisz docelową prezentację na dysku
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klonowanie slajdu w określonej pozycji w innej prezentacji**
Jeśli musisz sklonować slajd wraz z master slajdem z jednej prezentacji i użyć go w innej prezentacji, najpierw musisz sklonować żądany master slajd z prezentacji źródłowej do prezentacji docelowej. Następnie należy użyć tego master slajdu do klonowania slajdu z master slajdem. Metoda [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) oczekuje master slajdu z prezentacji docelowej, a nie z źródłowej. Aby sklonować slajd z masterem, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) zawierającej prezentację źródłową, z której slajd zostanie sklonowany.
2. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) zawierającej prezentację docelową, do której slajd zostanie sklonowany.
3. Uzyskaj dostęp do slajdu, który ma być sklonowany, wraz z master slajdem.
4. Zainicjalizuj klasę [IMasterSlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IMasterSlideCollection) odwołując się do kolekcji Masters udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) prezentacji docelowej.
5. Wywołaj metodę [addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) udostępnioną przez obiekt [IMasterSlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IMasterSlideCollection) i przekaż master z pliku PPTX źródłowego jako parametr do metody [addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
6. Zainicjalizuj klasę [ISlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getSlides--) ustawiając odniesienie do kolekcji Slides udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) prezentacji docelowej.
7. Wywołaj metodę [addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) udostępnioną przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getSlides--) i przekaż slajd z prezentacji źródłowej do sklonowania oraz master slajd jako parametr do metody [addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
8. Zapisz zmodyfikowany plik prezentacji docelowej.

W poniższym przykładzie sklonowaliśmy slajd z masterem (znajdujący się na indeksie zero w prezentacji źródłowej) na koniec prezentacji docelowej, używając mastera ze slajdu źródłowego.

```java
// Instantiate Presentation class to load the source presentation file
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instantiate Presentation class for destination presentation (where slide is to be cloned)
    Presentation destPres = new Presentation();
    try {
        // Instantiate ISlide from the collection of slides in source presentation along with
        // Master slide
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Clone the desired master slide from the source presentation to the collection of masters in the
        // Destination presentation
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Clone the desired master slide from the source presentation to the collection of masters in the
        // Destination presentation
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Clone the desired slide from the source presentation with the desired master to the end of the
        // Collection of slides in the destination presentation
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Save the destination presentation to disk
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klonowanie slajdu na końcu określonej sekcji**
Jeśli chcesz sklonować slajd i użyć go w tym samym pliku prezentacji, ale w innej sekcji, użyj metody [**addClone**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) udostępnionej przez interfejs [**ISlideCollection**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection). Aspose.Slides for Android via Java umożliwia klonowanie slajdu z pierwszej sekcji i wstawienie tego sklonowanego slajdu do drugiej sekcji tej samej prezentacji.

Poniższy fragment kodu pokazuje, jak sklonować slajd i wstawić sklonowany slajd do określonej sekcji.

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// Zapisz docelową prezentację na dysku
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Czy notatki prelegenta i komentarze recenzenta są klonowane?**

Tak. Strona z notatkami i komentarze recenzenta są dołączane do klonu. Jeśli ich nie chcesz, [usuń je](/slides/pl/androidjava/presentation-notes/) po wstawieniu.

**Jak obsługiwane są wykresy i ich źródła danych?**

Obiekt wykresu, formatowanie i wbudowane dane są kopiowane. Jeśli wykres był połączony z zewnętrznym źródłem (np. skoroszytem osadzonym jako OLE), to połączenie jest zachowane jako [obiekt OLE](/slides/pl/androidjava/manage-ole/). Po przeniesieniu między plikami sprawdź dostępność danych oraz zachowanie odświeżania.

**Czy mogę kontrolować pozycję wstawiania i sekcje dla klonu?**

Tak. Możesz wstawić klon na określony indeks slajdu i umieścić go w wybranej [sekcji](/slides/pl/androidjava/slide-section/). Jeśli docelowa sekcja nie istnieje, najpierw ją utwórz, a następnie przenieś slajd do niej.