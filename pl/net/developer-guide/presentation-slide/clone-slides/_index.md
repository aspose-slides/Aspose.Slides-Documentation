---
title: Klonowanie slajdów prezentacji w .NET
linktitle: Klonuj slajdy
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
description: "Szybko powielaj slajdy PowerPoint za pomocą Aspose.Slides dla .NET. Korzystaj z naszych przejrzystych przykładów kodu, aby zautomatyzować tworzenie prezentacji PPT w ciągu kilku sekund i wyeliminować ręczną pracę."
---
## **Wprowadzenie**

Klonowanie jest procesem tworzenia dokładnej kopii lub repliki czegoś. Aspose.Slides umożliwia również kopiowanie (klonowanie) dowolnego slajdu i wstawienie sklonowanego slajdu do bieżącej prezentacji lub do innej otwartej prezentacji. Klonowanie slajdu tworzy nowy slajd, który programiści mogą modyfikować bez wpływu na oryginalny slajd. Istnieje kilka sposobów klonowania slajdu:

- Klonowanie na końcu prezentacji.  
- Klonowanie w innej pozycji wewnątrz prezentacji.  
- Klonowanie na końcu innej prezentacji.  
- Klonowanie w innej pozycji w innej prezentacji.  
- Klonowanie razem z jego slajdem głównym do innej prezentacji.

W Aspose.Slides for .NET kolekcja slajdów (kolekcja obiektów [ISlide](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/)) udostępniana przez obiekt [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) zapewnia metody [AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/addclone/) i [InsertClone](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/insertclone/) umożliwiające wykonywanie opisanych powyżej operacji klonowania slajdu.

## **Klonowanie slajdu na końcu prezentacji**

Jeśli chcesz sklonować slajd i następnie użyć go w tej samej prezentacji, umieszczając go na końcu istniejących slajdów, użyj metody [AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/methods/addclone/index) zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).  
1. Uzyskaj dostęp do kolekcji [ISlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection) poprzez odwołanie się do kolekcji Slides udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).  
1. Wywołaj metodę [AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/methods/addclone/index) dostarczoną przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection) i przekaż slajd do sklonowania jako parametr tej metody.  
1. Zapisz zmodyfikowany plik prezentacji.

W przykładzie poniżej sklonowaliśmy slajd (znajdujący się na pierwszej pozycji – indeks zero – w prezentacji) na koniec prezentacji.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Klonowanie slajdu do innej pozycji w prezentacji**
Jeśli chcesz sklonować slajd i użyć go w tej samej prezentacji, ale w innej pozycji, użyj metody [InsertClone](https://reference.aspose.com/slides/pl/net/aspose.slides.ishapecollection/insertclone/methods/1):

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).  
1. Uzyskaj dostęp do kolekcji **Slides** udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).  
1. Wywołaj metodę [InsertClone](https://reference.aspose.com/slides/pl/net/aspose.slides.ishapecollection/insertclone/methods/1) dostarczoną przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection) i przekaż slajd do sklonowania wraz z indeksem nowej pozycji jako parametry tej metody.  
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W przykładzie poniżej sklonowaliśmy slajd (znajdujący się na indeksie 1 – pozycja 2 – w prezentacji) do indeksu 2 – pozycja 3 – w tej samej prezentacji.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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
Jeśli musisz sklonować slajd z jednej prezentacji i użyć go w innej prezentacji, umieszczając go na końcu istniejących slajdów:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) zawierającej prezentację, z której slajd ma być sklonowany.  
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) zawierającej docelową prezentację, do której slajd zostanie dodany.  
1. Uzyskaj dostęp do kolekcji [ISlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection) poprzez odwołanie się do kolekcji **Slides** udostępnionej przez obiekt Presentation docelowej prezentacji.  
1. Wywołaj metodę [AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/methods/addclone/index) dostarczoną przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection) i przekaż slajd z prezentacji źródłowej jako parametr tej metody.  
1. Zapisz zmodyfikowany plik prezentacji docelowej.

W przykładzie poniżej sklonowaliśmy slajd (z pierwszego indeksu prezentacji źródłowej) na koniec prezentacji docelowej.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Utwórz instancję klasy Presentation, aby wczytać plik prezentacji źródłowej
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Utwórz instancję klasy Presentation dla docelowego pliku PPTX (gdzie slajd ma być sklonowany)
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

## **Klonowanie slajdu do innej pozycji w innej prezentacji**
Jeśli musisz sklonować slajd z jednej prezentacji i użyć go w innej prezentacji, umieszczając go w określonej pozycji:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) zawierającej prezentację źródłową, z której slajd ma być sklonowany.  
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) zawierającej prezentację, do której slajd zostanie dodany.  
1. Uzyskaj dostęp do kolekcji [ISlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection) poprzez odwołanie się do kolekcji Slides udostępnionej przez obiekt Presentation prezentacji docelowej.  
1. Wywołaj metodę [InsertClone](https://reference.aspose.com/slides/pl/net/aspose.slides.ishapecollection/insertclone/methods/1) dostarczoną przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection) i przekaż slajd z prezentacji źródłowej wraz z żądaną pozycją jako parametry tej metody.  
1. Zapisz zmodyfikowany plik prezentacji docelowej.

W przykładzie poniżej sklonowaliśmy slajd (z indeksu zero prezentacji źródłowej) do indeksu 1 (pozycja 2) prezentacji docelowej.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Utwórz instancję klasy Presentation, aby wczytać plik prezentacji źródłowej
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Utwórz instancję klasy Presentation dla docelowego pliku PPTX (gdzie slajd ma być sklonowany)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // Zapisz docelową prezentację na dysku
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Klonowanie slajdu wraz ze slajdem głównym do innej prezentacji**
Jeśli musisz sklonować slajd razem ze slajdem głównym z jednej prezentacji i użyć go w innej prezentacji, najpierw musisz sklonować żądany slajd główny z prezentacji źródłowej do prezentacji docelowej. Następnie użyj tego slajdu głównego do klonowania slajdu ze slajdem głównym. Metoda **AddClone(ISlide, IMasterSlide)** oczekuje slajdu głównego z prezentacji docelowej, a nie ze źródłowej. Aby sklonować slajd z masterem, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) zawierającej prezentację źródłową, z której slajd ma być sklonowany.  
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) zawierającej prezentację docelową, do której slajd zostanie sklonowany.  
1. Uzyskaj dostęp do slajdu, który ma być sklonowany, wraz ze slajdem głównym.  
1. Uzyskaj kolekcję [IMasterSlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslidecollection) poprzez odwołanie się do kolekcji Masters udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) prezentacji docelowej.  
1. Wywołaj metodę [AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/methods/addclone/index) dostarczoną przez obiekt [IMasterSlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/imasterslidecollection) i przekaź master z pliku PPTX źródłowego jako parametr tej metody.  
1. Uzyskaj dostęp do kolekcji [ISlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection) ustawiając odniesienie do kolekcji Slides udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) prezentacji docelowej.  
1. Wywołaj metodę [AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/methods/addclone/index) dostarczoną przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection) i przekaż slajd z prezentacji źródłowej oraz master jako parametry tej metody.  
1. Zapisz zmodyfikowany plik prezentacji docelowej.

W przykładzie poniżej sklonowaliśmy slajd wraz z masterem (znajdujący się w indeksie zero prezentacji źródłowej) na koniec prezentacji docelowej, używając mastera ze slajdu źródłowego.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Utwórz instancję klasy Presentation, aby wczytać plik prezentacji źródłowej

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Utwórz instancję klasy Presentation dla prezentacji docelowej (gdzie slajd ma być sklonowany)
    using (Presentation destPres = new Presentation())
    {

        // Utwórz instancję ISlide z kolekcji slajdów w prezentacji źródłowej wraz z
        // Slajdem głównym
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Sklonuj wybrany slajd główny z prezentacji źródłowej do kolekcji masterów w
        // Prezentacji docelowej
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Sklonuj wybrany slajd główny z prezentacji źródłowej do kolekcji masterów w
        // Prezentacji docelowej
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Sklonuj wybrany slajd z prezentacji źródłowej z wybranym slajdem głównym na koniec
        // Kolekcji slajdów w prezentacji docelowej
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Sklonuj wybrany slajd główny z prezentacji źródłowej do kolekcji masterów w // Prezentacji docelowej
        // Zapisz prezentację docelową na dysku
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **Klonowanie slajdu na koniec określonej sekcji**

W Aspose.Slides for .NET możesz sklonować slajd z jednej sekcji prezentacji i wstawić go do innej sekcji w tej samej prezentacji. W takim przypadku należy użyć metody [AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/methods/addclone/index) z interfejsu [ISlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection).

Poniższy kod w C# pokazuje, jak sklonować slajd i wstawić go do określonej sekcji:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Zapewnienie zgodnego rozmiaru slajdu**

Podczas klonowania slajdów do innej prezentacji upewnij się, że prezentacja docelowa ma taki sam rozmiar slajdu jak źródłowa. Jeśli rozmiary różnią się, Aspose.Slides nie skaluje automatycznie sklonowanych kształtów – ich pierwotne współrzędne i wymiary są zachowywane, co może spowodować nieprawidłowe wyrównanie lub wyjście treści poza granice slajdu.

Możesz ustawić rozmiar slajdu prezentacji docelowej tak, aby pasował do rozmiaru źródłowego przed klonowaniem mastera i slajdu:

```cs
SizeF sourceSize = sourcePresentation.SlideSize.Size;

targetPresentation.SlideSize.SetSize(
    sourceSize.Width, sourceSize.Height, SlideSizeScaleType.DoNotScale);
```

Zrób to przed klonowaniem mastera i slajdu.

## **FAQ**

**Czy notatki prelegenta i komentarze recenzenta są klonowane?**

Tak. Strona z notatkami i komentarze recenzenta są włączone do klonu. Jeśli ich nie chcesz, [usuń je](/slides/pl/net/presentation-notes/) po wstawieniu.

**Jak obsługiwane są wykresy i ich źródła danych?**

Obiekt wykresu, formatowanie oraz osadzone dane są kopiowane. Jeśli wykres był powiązany z zewnętrznym źródłem (np. skoroszytem osadzonym jako OLE), to połączenie jest zachowane jako [obiekt OLE](/slides/pl/net/manage-ole/). Po przeniesieniu między plikami sprawdź dostępność danych i zachowanie odświeżania.

**Czy mogę kontrolować pozycję wstawiania i sekcje klonu?**

Tak. Możesz wstawić klon na konkretnym indeksie slajdu i umieścić go w wybranej [sekcji](/slides/pl/net/slide-section/). Jeśli docelowa sekcja nie istnieje, utwórz ją najpierw, a następnie przenieś do niej slajd.