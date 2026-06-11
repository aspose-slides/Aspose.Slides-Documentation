---
title: "Klonowanie slajdów prezentacji w .NET"
linktitle: "Klonowanie slajdów"
type: docs
weight: 40
url: /pl/net/clone-slides/
keywords:
- klonowanie slajdu
- kopiowanie slajdu
- zapis slajdu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Szybko duplikuj slajdy PowerPoint za pomocą Aspose.Slides dla .NET. Skorzystaj z naszych przejrzystych przykładów kodu, aby w kilka sekund zautomatyzować tworzenie prezentacji PPT i wyeliminować ręczną pracę."
---
## **Wprowadzenie**

Klonowanie to proces tworzenia dokładnej kopii lub repliki czegoś. Aspose.Slides umożliwia także kopiowanie (klonowanie) dowolnego slajdu i wstawienie sklonowanego slajdu do bieżącej prezentacji lub dowolnej innej otwartej prezentacji. Klonowanie slajdu tworzy nowy slajd, który deweloperzy mogą modyfikować bez wpływu na oryginalny slajd. Istnieje kilka sposobów klonowania slajdu:

- Klonowanie na końcu prezentacji.
- Klonowanie w innym miejscu w obrębie prezentacji.
- Klonowanie na końcu innej prezentacji.
- Klonowanie w innym miejscu w innej prezentacji.
- Klonowanie w określonym miejscu w innej prezentacji.

W Aspose.Slides for .NET kolekcja slajdów (kolekcja obiektów [ISlide](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/) ) udostępniona przez obiekt [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) zapewnia metody [AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/addclone/) i [InsertClone](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/insertclone/) do wykonywania opisanych powyżej operacji klonowania slajdów.

## **Klonowanie slajdu na końcu prezentacji**

Jeśli chcesz sklonować slajd i następnie użyć go w tym samym pliku prezentacji na końcu istniejących slajdów, użyj metody [AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/methods/addclone/index) zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
1. Zainicjuj klasę [ISlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection), odwołując się do kolekcji Slides udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
1. Wywołaj metodę [AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/methods/addclone/index) udostępnioną przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection) i przekaż slajd do sklonowania jako parametr do metody [AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/methods/addclone/index).
1. Zapisz zmodyfikowany plik prezentacji.

W poniższym przykładzie sklonowaliśmy slajd (znajdujący się na pierwszej pozycji – indeks zero – w prezentacji) na koniec prezentacji.

```c#
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // Sklonuj wybrany slajd na koniec kolekcji slajdów w tej samej prezentacji
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // Zapisz zmodyfikowaną prezentację na dysku
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```

## **Klonowanie slajdu w innym miejscu w obrębie prezentacji**

Jeśli chcesz sklonować slajd i następnie użyć go w tym samym pliku prezentacji, ale w innym miejscu, użyj metody [InsertClone](https://reference.aspose.com/slides/pl/net/aspose.slides.ishapecollection/insertclone/methods/1):

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
1. Zainicjuj klasę, odwołując się do kolekcji **Slides** udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
1. Wywołaj metodę [InsertClone](https://reference.aspose.com/slides/pl/net/aspose.slides.ishapecollection/insertclone/methods/1) udostępnioną przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection) i przekaż slajd do sklonowania wraz z indeksem nowej pozycji jako parametr do metody [InsertClone](https://reference.aspose.com/slides/pl/net/aspose.slides.ishapecollection/insertclone/methods/1).
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie sklonowaliśmy slajd (znajdujący się na indeksie zero – pozycja 1 – w prezentacji) na indeks 1 – pozycję 2 – w prezentacji.

```c#
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // Sklonuj wybrany slajd na koniec kolekcji slajdów w tej samej prezentacji
    ISlideCollection slds = pres.Slides;

    // Sklonuj wybrany slajd do określonego indeksu w tej samej prezentacji
    slds.InsertClone(2, pres.Slides[1]);

    // Zapisz zmodyfikowaną prezentację na dysku
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **Klonowanie slajdu na końcu innej prezentacji**

Jeśli musisz sklonować slajd z jednej prezentacji i użyć go w innej prezentacji, na końcu istniejących slajdów:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) zawierającej prezentację, z której slajd zostanie sklonowany.
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) zawierającej docelową prezentację, do której slajd zostanie dodany.
1. Zainicjuj klasę [ISlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection), odwołując się do kolekcji **Slides** udostępnionej przez obiekt Presentation docelowej prezentacji.
1. Wywołaj metodę [AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/methods/addclone/index) udostępnioną przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection) i przekaż slajd z prezentacji źródłowej jako parametr do metody [AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/methods/addclone/index).
1. Zapisz zmodyfikowany plik docelowej prezentacji.

W poniższym przykładzie sklonowaliśmy slajd (z pierwszego indeksu prezentacji źródłowej) na koniec prezentacji docelowej.

```c#
// Utwórz instancję klasy Presentation, aby wczytać plik prezentacji źródłowej
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Utwórz instancję klasy Presentation dla docelowego pliku PPTX (gdzie slajd ma zostać sklonowany)
    using (Presentation destPres = new Presentation())
    {
        // Sklonuj wybrany slajd z prezentacji źródłowej na koniec kolekcji slajdów w prezentacji docelowej
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // Zapisz docelową prezentację na dysku
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Klonowanie slajdu w innym miejscu w innej prezentacji**

Jeśli musisz sklonować slajd z jednej prezentacji i użyć go w innej prezentacji, w określonym miejscu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) zawierającej prezentację źródłową, z której slajd zostanie sklonowany.
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) zawierającej prezentację, do której slajd zostanie dodany.
1. Zainicjuj klasę [ISlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection), odwołując się do kolekcji Slides udostępnionej przez obiekt Presentation docelowej prezentacji.
1. Wywołaj metodę [InsertClone](https://reference.aspose.com/slides/pl/net/aspose.slides.ishapecollection/insertclone/methods/1) udostępnioną przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection) i przekaż slajd z prezentacji źródłowej wraz z żądaną pozycją jako parametr do metody [InsertClone](https://reference.aspose.com/slides/pl/net/aspose.slides.ishapecollection/insertclone/methods/1).
1. Zapisz zmodyfikowany plik docelowej prezentacji.

W poniższym przykładzie sklonowaliśmy slajd (z indeksu zero w prezentacji źródłowej) na indeks 1 (pozycja 2) w prezentacji docelowej.

```c#
// Utwórz instancję klasy Presentation, aby wczytać plik prezentacji źródłowej
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Utwórz instancję klasy Presentation dla docelowego pliku PPTX (gdzie slajd ma zostać sklonowany)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // Zapisz docelową prezentację na dysku
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Klonowanie slajdu w określonym miejscu w innej prezentacji**

Jeśli musisz sklonować slajd wraz z masterem z jednej prezentacji i użyć go w innej prezentacji, najpierw musisz sklonować żądany master ze źródła do prezentacji docelowej. Następnie użyj tego mastera do klonowania slajdu z masterem. Metoda **AddClone(ISlide, IMasterSlide)** oczekuje mastera z prezentacji docelowej, a nie ze źródłowej. Aby sklonować slajd z masterem, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) zawierającej prezentację źródłową, z której slajd zostanie sklonowany.
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) zawierającej prezentację docelową, do której slajd zostanie sklonowany.
1. Uzyskaj dostęp do slajdu, który ma zostać sklonowany, wraz z masterem.
1. Zainicjuj klasę [IMasterSlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslidecollection), odwołując się do kolekcji Masters udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) prezentacji docelowej.
1. Wywołaj metodę [AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/methods/addclone/index) udostępnioną przez obiekt [IMasterSlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslidecollection) i przekaż master z pliku PPTX źródłowego jako parametr do metody [AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/methods/addclone/index).
1. Zainicjuj klasę [ISlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection), ustawiając referencję do kolekcji Slides udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) prezentacji docelowej.
1. Wywołaj metodę [AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/methods/addclone/index) udostępnioną przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection) i przekaż slajd z prezentacji źródłowej oraz master jako parametry do metody [AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/methods/addclone/index).
1. Zapisz zmodyfikowany plik docelowej prezentacji.

W poniższym przykładzie sklonowaliśmy slajd z masterem (znajdujący się w indeksie zero prezentacji źródłowej) na koniec prezentacji docelowej, używając mastera ze slajdu źródłowego.

```c#
// Utwórz instancję klasy Presentation, aby wczytać plik prezentacji źródłowej

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Utwórz instancję klasy Presentation dla prezentacji docelowej (gdzie slajd ma zostać sklonowany)
    using (Presentation destPres = new Presentation())
    {

        // Utwórz ISlide z kolekcji slajdów w prezentacji źródłowej wraz z
        // slajdem master
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Sklonuj wybrany slajd master z prezentacji źródłowej do kolekcji masterów w
        // prezentacji docelowej
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Sklonuj wybrany slajd master z prezentacji źródłowej do kolekcji masterów w
        // prezentacji docelowej
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Sklonuj wybrany slajd z prezentacji źródłowej z wybranym masterem na koniec
        // kolekcji slajdów w prezentacji docelowej
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Sklonuj wybrany slajd master z prezentacji źródłowej do kolekcji masterów w // prezentacji docelowej
        // Zapisz docelową prezentację na dysku
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **Klonowanie slajdu na końcu określonej sekcji**

Za pomocą Aspose.Slides for .NET możesz klonować slajd z jednej sekcji prezentacji i wstawiać go do innej sekcji w tej samej prezentacji. W takim wypadku należy użyć metody [AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/methods/addclone/index) z interfejsu [ISlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection).

Ten kod C# pokazuje, jak sklonować slajd i wstawić sklonowany slajd do określonej sekcji:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // do sklonowania
    
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Czy notatki prelegenta i komentarze recenzenta są klonowane?**

Tak. Strona z notatkami oraz komentarze recenzenta są uwzględnione w klonie. Jeśli ich nie chcesz, [usuń je](/slides/pl/net/presentation-notes/) po wstawieniu.

**Jak obsługiwane są wykresy i ich źródła danych?**

Obiekt wykresu, formatowanie oraz osadzone dane są kopiowane. Jeśli wykres był powiązany z zewnętrznym źródłem (np. skoroszytem osadzonym jako OLE), to powiązanie zostaje zachowane jako [obiekt OLE](/slides/pl/net/manage-ole/). Po przeniesieniu między plikami sprawdź dostępność danych i zachowanie odświeżania.

**Czy mogę kontrolować pozycję wstawiania i sekcje dla klonu?**

Tak. Możesz wstawić klon na określonym indeksie slajdu i umieścić go w wybranej [sekcji](/slides/pl/net/slide-section/). Jeśli docelowa sekcja nie istnieje, najpierw ją utwórz, a potem przenieś slajd do niej.