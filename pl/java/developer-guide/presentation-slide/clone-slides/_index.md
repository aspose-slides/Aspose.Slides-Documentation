---
title: "Klonowanie slajdów prezentacji w Javie"
linktitle: "Klonuj slajdy"
type: docs
weight: 35
url: /pl/java/clone-slides/
keywords:
  - "klonowanie slajdu"
  - "kopiowanie slajdu"
  - "zapis slajdu"
  - "PowerPoint"
  - "OpenDocument"
  - "prezentacja"
  - "Java"
  - "Aspose.Slides"
description: "Szybko duplikuj slajdy PowerPoint za pomocą Aspose.Slides for Java. Skorzystaj z naszych przejrzystych przykładów kodu, aby w ciągu kilku sekund zautomatyzować tworzenie prezentacji PPT i wyeliminować ręczną pracę."
---
## **Wprowadzenie**

Klonowanie to proces tworzenia dokładnej kopii lub repliki czegoś. Aspose.Slides for Java umożliwia również wykonanie kopii lub klona dowolnego slajdu, a następnie wstawienie tego sklonowanego slajdu do bieżącej lub dowolnej innej otwartej prezentacji. Proces klonowania slajdu tworzy nowy slajd, który może być modyfikowany przez programistów bez zmieniania oryginalnego slajdu. Istnieje kilka możliwych sposobów klonowania slajdu:

- Klonowanie na końcu w obrębie prezentacji.
- Klonowanie w innym miejscu w obrębie prezentacji.
- Klonowanie na końcu w innej prezentacji.
- Klonowanie w innym miejscu w innej prezentacji.
- Klonowanie razem z jego slajdem-mistrzem do innej prezentacji.

W Aspose.Slides for Java (kolekcja obiektów [ISlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlide) ) udostępniona przez obiekt [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation) zapewnia metody [addClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) i [insertClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) do wykonywania powyższych typów klonowania slajdów

## **Klonowanie slajdu na końcu prezentacji**
Jeśli chcesz sklonować slajd i użyć go w tym samym pliku prezentacji na końcu istniejących slajdów, użyj metody [addClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
1. Zainicjuj klasę [ISlideCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation#getSlides--) odwołując się do kolekcji Slides udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
1. Wywołaj metodę [addClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) udostępnioną przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation#getSlides--), przekazując slajd do sklonowania jako parametr do metody [addClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Zapisz zmodyfikowany plik prezentacji.

W poniższym przykładzie sklonowaliśmy slajd (znajdujący się na pierwszej pozycji – indeks zero – w prezentacji) na koniec prezentacji.

```java
import com.aspose.slides.*;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Sklonuj wybrany slajd na koniec kolekcji slajdów w tej samej prezentacji
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Zapisz zmodyfikowaną prezentację na dysk
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klonowanie slajdu w inną pozycję w obrębie prezentacji**
Jeśli chcesz sklonować slajd i użyć go w tym samym pliku prezentacji, ale w innej pozycji, użyj metody [insertClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
1. Zainicjuj klasę, odwołując się do kolekcji **Slides** udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
1. Wywołaj metodę [insertClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) udostępnioną przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation#getSlides--) i przekazując slajd do sklonowania wraz z indeksem nowej pozycji jako parametr do metody [insertClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie sklonowaliśmy slajd (znajdujący się pod indeksem 1 – pozycja 2 – w prezentacji) do indeksu 2 – pozycja 3 – w prezentacji.

```java
import com.aspose.slides.*;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Pobierz kolekcję slajdów w prezentacji
    ISlideCollection slds = pres.getSlides();

    // Sklonuj wybrany slajd do określonego indeksu w tej samej prezentacji
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Zapisz zmodyfikowaną prezentację na dysk
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klonowanie slajdu na końcu innej prezentacji**
Jeśli musisz sklonować slajd z jednej prezentacji i użyć go w innym pliku prezentacji, na końcu istniejących slajdów:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation), zawierającej prezentację, z której slajd zostanie sklonowany.
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation), zawierającej docelową prezentację, do której slajd zostanie dodany.
1. Zainicjuj klasę [ISlideCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlideCollection) odwołując się do kolekcji **Slides** udostępnionej przez obiekt Presentation docelowej prezentacji.
1. Wywołaj metodę [addClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) udostępnioną przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation#getSlides--) i przekazując slajd z prezentacji źródłowej jako parametr do metody [addClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Zapisz zmodyfikowany plik prezentacji docelowej.

W poniższym przykładzie sklonowaliśmy slajd (z pierwszego indeksu prezentacji źródłowej) na koniec prezentacji docelowej.

```java
import com.aspose.slides.*;

// Utwórz instancję klasy Presentation, aby załadować plik źródłowej prezentacji
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Utwórz instancję klasy Presentation dla docelowego PPTX (gdzie slajd ma być sklonowany)
    Presentation destPres = new Presentation();
    try {
        // Sklonuj wybrany slajd ze źródłowej prezentacji na koniec kolekcji slajdów w docelowej prezentacji
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Zapisz docelową prezentację na dysk
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klonowanie slajdu w inną pozycję w innej prezentacji**
Jeśli musisz sklonować slajd z jednej prezentacji i użyć go w innym pliku prezentacji, w określonej pozycji:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation), zawierającej prezentację źródłową, z której slajd zostanie sklonowany.
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation), zawierającej prezentację, do której slajd zostanie dodany.
1. Zainicjuj klasę [ISlideCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation#getSlides--) odwołując się do kolekcji Slides udostępnionej przez obiekt Presentation prezentacji docelowej.
1. Wywołaj metodę [insertClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) udostępnioną przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation#getSlides--) i przekazując slajd z prezentacji źródłowej wraz z żądaną pozycją jako parametr do metody [insertClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Zapisz zmodyfikowany plik prezentacji docelowej.

W poniższym przykładzie sklonowaliśmy slajd (z indeksu zero w prezentacji źródłowej) do indeksu 1 (pozycja 2) w prezentacji docelowej.

```java
import com.aspose.slides.*;

// Utwórz instancję klasy Presentation, aby załadować plik źródłowej prezentacji
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Utwórz instancję klasy Presentation dla docelowego PPTX (gdzie slajd ma być sklonowany)
    Presentation destPres = new Presentation();
    try {
        // Sklonuj wybrany slajd ze źródłowej prezentacji do określonego indeksu w docelowej prezentacji
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // Zapisz docelową prezentację na dysk
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klonowanie slajdu wraz z jego slajdem-mistrzem do innej prezentacji**
Jeśli musisz sklonować slajd wraz ze slajdem-mistrzem z jednej prezentacji i użyć go w innej prezentacji, najpierw musisz sklonować żądany slajd-mistrz z prezentacji źródłowej do prezentacji docelowej. Następnie użyj tego slajdu-mistrza do klonowania slajdu z slajdem-mistrzem. Metoda [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) oczekuje slajdu-mistrza z prezentacji docelowej, a nie ze źródłowej. Aby sklonować slajd z mistrzem, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation), zawierającej prezentację źródłową, z której slajd zostanie sklonowany.
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation), zawierającej prezentację docelową, do której slajd zostanie sklonowany.
1. Uzyskaj dostęp do slajdu, który ma zostać sklonowany, wraz ze slajdem-mistrzem.
1. Zainicjuj klasę [IMasterSlideCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IMasterSlideCollection) odwołując się do kolekcji Masters udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation) prezentacji docelowej.
1. Wywołaj metodę [addClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) udostępnioną przez obiekt [IMasterSlideCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IMasterSlideCollection) i przekazując slajd-mistrz z pliku PPTX źródłowego jako parametr do metody [addClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Zainicjuj klasę [ISlideCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation#getSlides--) ustawiając odwołanie do kolekcji Slides udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation) prezentacji docelowej.
1. Wywołaj metodę [addClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) udostępnioną przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation#getSlides--) i przekazując slajd z prezentacji źródłowej do sklonowania oraz slajd-mistrz jako parametr do metody [addClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-).
1. Zapisz zmodyfikowany plik prezentacji docelowej.

W poniższym przykładzie sklonowaliśmy slajd z mistrzem (znajdujący się w indeksie zero w prezentacji źródłowej) na koniec prezentacji docelowej, używając mistrza ze slajdu źródłowego.

```java
import com.aspose.slides.*;

// Utwórz instancję klasy Presentation, aby załadować plik źródłowej prezentacji
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Utwórz instancję klasy Presentation dla prezentacji docelowej (gdzie slajd ma być sklonowany)
    Presentation destPres = new Presentation();
    try {
        // Utwórz instancję ISlide z kolekcji slajdów w prezentacji źródłowej wraz z
        // slajdem-mistrzem
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Sklonuj wybrany slajd-mistrz z prezentacji źródłowej do kolekcji mistrzów w
        // prezentacji docelowej
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = masters.addClone(SourceMaster);

        // Sklonuj wybrany slajd z prezentacji źródłowej z wybranym mistrzem na koniec
        // kolekcji slajdów w prezentacji docelowej
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);

        // Zapisz docelową prezentację na dysk
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klonowanie slajdu na końcu określonej sekcji**
Jeśli chcesz sklonować slajd i użyć go w tym samym pliku prezentacji, ale w innej sekcji, użyj metody [**addClone**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) udostępnionej przez interfejs [**ISlideCollection**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlideCollection). Aspose.Slides for Java umożliwia sklonowanie slajdu z pierwszej sekcji i wstawienie tego sklonowanego slajdu do drugiej sekcji tej samej prezentacji.

Poniższy fragment kodu pokazuje, jak sklonować slajd i wstawić sklonowany slajd do określonej sekcji.

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);

    // Zapisz docelową prezentację na dysk
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Zapewnienie dopasowanego rozmiaru slajdu**
Podczas klonowania slajdów do innej prezentacji upewnij się, że prezentacja docelowa ma taki sam rozmiar slajdu jak źródłowa. Jeśli rozmiary slajdów różnią się, Aspose.Slides nie przeskalowuje automatycznie sklonowanych kształtów – ich pierwotne współrzędne i wymiary są zachowane, co może spowodować, że zawartość będzie nieprawidłowo wyrównana lub wyjdzie poza granice slajdu.

Możesz ustawić rozmiar slajdu prezentacji docelowej tak, aby odpowiadał źródłowemu przed klonowaniem mistrza i slajdu:

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

Zrób to przed klonowaniem mistrza i slajdu.

## **FAQ**

**Czy notatki prelegenta i komentarze recenzentów są klonowane?**

Tak. Strona notatek oraz komentarze recenzentów są dołączane do klonu. Jeśli ich nie chcesz, [usuń je](/slides/pl/java/presentation-notes/) po wstawieniu.

**Jak obsługiwane są wykresy i ich źródła danych?**

Obiekt wykresu, formatowanie oraz osadzone dane są kopiowane. Jeśli wykres był połączony z zewnętrznym źródłem (np. zeszytem OLE), to połączenie jest zachowane jako [obiekt OLE](/slides/pl/java/manage-ole/). Po przeniesieniu między plikami sprawdź dostępność danych i zachowanie odświeżania.

**Czy mogę kontrolować pozycję wstawiania i sekcje dla klonu?**

Tak. Możesz wstawić klon na określony indeks slajdu i umieścić go w wybranej [sekcji](/slides/pl/java/slide-section/). Jeśli docelowa sekcja nie istnieje, najpierw ją utwórz, a następnie przenieś slajd do niej.