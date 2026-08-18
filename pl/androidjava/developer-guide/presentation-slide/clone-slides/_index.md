---
title: "Klonowanie slajdów prezentacji na Androidzie"
linktitle: "Klonuj slajdy"
type: docs
weight: 35
url: /pl/androidjava/clone-slides/
keywords:
- klonowanie slajdu
- kopiowanie slajdu
- zapis slajdu
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Powielaj slajdy PowerPoint za pomocą Aspose.Slides dla Androida. Postępuj zgodnie z naszymi przejrzystymi przykładami kodu w języku Java, aby automatyzować tworzenie plików PPT w ciągu kilku sekund i wyeliminować ręczną pracę."
---
## **Wprowadzenie**

Klonowanie jest procesem tworzenia dokładnej kopii lub repliki czegoś. Aspose.Slides for Android via Java umożliwia również stworzenie kopii lub klonu dowolnego slajdu, a następnie wstawienie tego sklonowanego slajdu do bieżącej lub innej otwartej prezentacji. Proces klonowania slajdu tworzy nowy slajd, który może być modyfikowany przez programistów bez zmiany oryginalnego slajdu. Istnieje kilka możliwych sposobów klonowania slajdu:

- Klonowanie na końcu w obrębie prezentacji.
- Klonowanie w innej pozycji w obrębie prezentacji.
- Klonowanie na końcu w innej prezentacji.
- Klonowanie w innej pozycji w innej prezentacji.
- Klonowanie w określonej pozycji w innej prezentacji.

W Aspose.Slides for Android via Java (kolekcja obiektów [ISlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlide) ) udostępniona przez obiekt [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) zapewnia metody [addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) i [insertClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-), które umożliwiają wykonanie powyższych typów klonowania slajdów.

## **Klonowanie slajdu na końcu prezentacji**
Jeśli chcesz sklonować slajd i następnie użyć go w tym samym pliku prezentacji na końcu istniejących slajdów, użyj metody [addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2. Zainicjuj klasę [ISlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getSlides--) odwołując się do kolekcji Slides udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
3. Wywołaj metodę [addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) udostępnioną przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getSlides--) i przekazując slajd do sklonowania jako parametr do metody [addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
4. Zapisz zmodyfikowany plik prezentacji.

W poniższym przykładzie sklonowaliśmy slajd (znajdujący się na pierwszej pozycji – indeks zerowy – prezentacji) na koniec prezentacji.

```java
import com.aspose.slides.*;

// Tworzy klasę Presentation, która reprezentuje plik prezentacji
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

## **Klonowanie slajdu w innej pozycji w obrębie prezentacji**
Jeśli chcesz sklonować slajd i następnie użyć go w tym samym pliku prezentacji, ale w innej pozycji, użyj metody [insertClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2. Zainicjuj klasę, odwołując się do kolekcji [**Slides**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getSlides--) udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
3. Wywołaj metodę [insertClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) udostępnioną przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getSlides--) , przekazując slajd do sklonowania razem z indeksem nowej pozycji jako parametr do metody [insertClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
4. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie sklonowaliśmy slajd (znajdujący się na indeksie 1 – pozycja 2 – prezentacji) na indeks 2 – pozycja 3 – prezentacji.

```java
import com.aspose.slides.*;

// Tworzy klasę Presentation, która reprezentuje plik prezentacji
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Pobiera kolekcję slajdów w tej samej prezentacji
    ISlideCollection slds = pres.getSlides();

    // Klonuje wybrany slajd do określonego indeksu w tej samej prezentacji
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Zapisuje zmodyfikowaną prezentację na dysk
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klonowanie slajdu na końcu innej prezentacji**
Jeśli potrzebujesz sklonować slajd z jednej prezentacji i użyć go w pliku innej prezentacji, na końcu istniejących slajdów:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) zawierającej prezentację, z której slajd zostanie sklonowany.
2. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) zawierającej docelową prezentację, do której slajd zostanie dodany.
3. Zainicjuj klasę [ISlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection) odwołując się do kolekcji [**Slides**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getSlides--) udostępnionej przez obiekt Presentation docelowej prezentacji.
4. Wywołaj metodę [addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) udostępnioną przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getSlides--) , przekazując slajd z prezentacji źródłowej jako parametr do metody [addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
5. Zapisz zmodyfikowany plik docelowej prezentacji.

W poniższym przykładzie sklonowaliśmy slajd (z pierwszego indeksu prezentacji źródłowej) na koniec docelowej prezentacji.

```java
import com.aspose.slides.*;

// Tworzy klasę Presentation, aby wczytać plik prezentacji źródłowej
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Tworzy klasę Presentation dla docelowego pliku PPTX (gdzie slajd będzie klonowany)
    Presentation destPres = new Presentation();
    try {
        // Klonuje wybrany slajd z prezentacji źródłowej na koniec kolekcji slajdów w prezentacji docelowej
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Zapisuje docelową prezentację na dysk
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klonowanie slajdu w innej pozycji w innej prezentacji**
Jeśli potrzebujesz sklonować slajd z jednej prezentacji i użyć go w pliku innej prezentacji, w określonej pozycji:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) zawierającej prezentację źródłową, z której slajd zostanie sklonowany.
2. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) zawierającej prezentację, do której slajd zostanie dodany.
3. Zainicjuj klasę [ISlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getSlides--) odwołując się do kolekcji Slides udostępnionej przez obiekt Presentation docelowej prezentacji.
4. Wywołaj metodę [insertClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) udostępnioną przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getSlides--) , przekazując slajd z prezentacji źródłowej wraz z żądaną pozycją jako parametr do metody [insertClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
5. Zapisz zmodyfikowany plik docelowej prezentacji.

W poniższym przykładzie sklonowaliśmy slajd (z indeksu zerowego prezentacji źródłowej) na indeks 1 (pozycja 2) docelowej prezentacji.

```java
import com.aspose.slides.*;

// Tworzy klasę Presentation, aby wczytać plik prezentacji źródłowej
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Tworzy klasę Presentation dla docelowego pliku PPTX (gdzie slajd ma być klonowany)
    Presentation destPres = new Presentation();
    try {
        // Klonuje wybrany slajd z prezentacji źródłowej do określonego indeksu w prezentacji docelowej
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // Zapisuje docelową prezentację na dysk
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klonowanie slajdu w określonej pozycji w innej prezentacji**
Jeśli potrzebujesz sklonować slajd razem z master slajdem z jednej prezentacji i użyć go w innej prezentacji, najpierw musisz sklonować żądany master slajd z prezentacji źródłowej do docelowej. Następnie użyj tego master slajdu do klonowania slajdu z masterem. Metoda [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) oczekuje master slajdu z docelowej prezentacji, a nie z źródłowej. Aby sklonować slajd z masterem, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) zawierającej prezentację źródłową, z której slajd zostanie sklonowany.
2. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) zawierającej docelową prezentację, do której slajd zostanie sklonowany.
3. Uzyskaj dostęp do slajdu, który ma być sklonowany, wraz z master slajdem.
4. Zainicjuj klasę [IMasterSlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IMasterSlideCollection) odwołując się do kolekcji Masters udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) docelowej prezentacji.
5. Wywołaj metodę [addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) udostępnioną przez obiekt [IMasterSlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IMasterSlideCollection) , przekazując master z pliku PPTX źródłowego do sklonowania jako parametr do metody [addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
6. Zainicjuj klasę [ISlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getSlides--) , ustawiając odwołanie do kolekcji Slides udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) docelowej prezentacji.
7. Wywołaj metodę [addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) udostępnioną przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getSlides--) , przekazując slajd z prezentacji źródłowej do sklonowania oraz master slajd jako parametr do metody [addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
8. Zapisz zmodyfikowany plik docelowej prezentacji.

W poniższym przykładzie sklonowaliśmy slajd z masterem (znajdujący się na indeksie zerowym prezentacji źródłowej) na koniec docelowej prezentacji, używając mastera ze slajdu źródłowego.

```java
import com.aspose.slides.*;

// Tworzy klasę Presentation, aby wczytać plik prezentacji źródłowej
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Tworzy klasę Presentation dla prezentacji docelowej (gdzie slajd ma być klonowany)
    Presentation destPres = new Presentation();
    try {
        // Tworzy obiekt ISlide z kolekcji slajdów w prezentacji źródłowej wraz z
        // slajdem master
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Klonuje wybrany slajd master z prezentacji źródłowej do kolekcji masterów w
        // prezentacji docelowej
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Klonuje wybrany slajd z prezentacji źródłowej wraz z wybranym masterem na koniec
        // kolekcji slajdów w prezentacji docelowej
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Zapisuje prezentację docelową na dysk
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klonowanie slajdu na końcu określonej sekcji**
Jeśli chcesz sklonować slajd i następnie użyć go w tym samym pliku prezentacji, ale w innej sekcji, użyj metody [**addClone**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) udostępnionej przez interfejs [**ISlideCollection**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection). Aspose.Slides for Android via Java umożliwia sklonowanie slajdu z pierwszej sekcji i wstawienie tego sklonowanego slajdu do drugiej sekcji tej samej prezentacji.

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

## **Upewnij się, że rozmiar slajdu jest zgodny**

Podczas klonowania slajdów do innej prezentacji, upewnij się, że prezentacja docelowa ma taki sam rozmiar slajdu jak źródłowa. Jeśli rozmiary slajdów się różnią, Aspose.Slides nie przeskaluje automatycznie sklonowanych kształtów — ich pierwotne współrzędne i wymiary zostają zachowane, co może spowodować, że treść będzie nieprawidłowo wyrównana lub wyjdzie poza granice slajdu.

Możesz ustawić rozmiar slajdu prezentacji docelowej tak, aby odpowiadał rozmiarowi slajdu źródłowego przed sklonowaniem mastera i slajdu:

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

Zrób to przed sklonowaniem mastera i slajdu.

## **FAQ**

**Czy notatki prelegenta i komentarze recenzentów są klonowane?**

Tak. Strona z notatkami i komentarze recenzentów są uwzględniane w klonie. Jeśli ich nie chcesz, [usuń je](/slides/pl/androidjava/presentation-notes/) po wstawieniu.

**Jak obsługiwane są wykresy i ich źródła danych?**

Obiekt wykresu, formatowanie i osadzone dane są kopiowane. Jeśli wykres był połączony z zewnętrznym źródłem (np. skoroszytem osadzonym jako OLE), to połączenie jest zachowane jako [obiekt OLE](/slides/pl/androidjava/manage-ole/). Po przeniesieniu między plikami sprawdź dostępność danych i zachowanie odświeżania.

**Czy mogę kontrolować pozycję wstawiania i sekcje dla klonu?**

Tak. Możesz wstawić klon na określony indeks slajdu i umieścić go w wybranej [sekcji](/slides/pl/androidjava/slide-section/). Jeśli docelowa sekcja nie istnieje, najpierw ją utwórz, a potem przenieś slajd do niej.