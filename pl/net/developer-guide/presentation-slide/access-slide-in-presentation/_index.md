---
title: Dostęp do slajdów prezentacji w .NET
linktitle: Dostęp do slajdu
type: docs
weight: 20
url: /pl/net/access-slide-in-presentation/
keywords:
- dostęp do slajdu
- indeks slajdu
- identyfikator slajdu
- pozycja slajdu
- zmiana pozycji
- właściwości slajdu
- numer slajdu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak uzyskać dostęp i zarządzać slajdami w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla .NET. Zwiększ wydajność dzięki przykładom kodu."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak uzyskać dostęp i zarządzać slajdami w prezentacji przy użyciu Aspose.Slides. Pokazuje, jak pobrać slajdy według ich indeksu zerowego z kolekcji `Slides` oraz jak uzyskać slajd po jego unikalnym identyfikatorze przy użyciu metody `GetSlideById`.

Dowiesz się także, jak zmienić pozycję slajdu, ustawiając właściwość `SlideNumber`, oraz jak określić początkowy numer slajdu w prezentacji przy pomocy właściwości `FirstSlideNumber`. Przykłady demonstrują wczytywanie prezentacji, pobieranie referencji do slajdów, aktualizację kolejności lub numeracji slajdów oraz zapisywanie zmodyfikowanej prezentacji.

## **Dostęp do slajdu po indeksie**

Wszystkie slajdy w prezentacji są uporządkowane numerycznie według pozycji slajdu, począwszy od 0. Pierwszy slajd jest dostępny pod indeksem 0; drugi slajd pod indeksem 1; itd.

Klasa Presentation, reprezentująca plik prezentacji, udostępnia wszystkie slajdy jako kolekcję [ISlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection) (kolekcję obiektów [ISlide](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/) ). Ten kod C# pokazuje, jak uzyskać dostęp do slajdu przez jego indeks:

```c#
 // Tworzy obiekt Presentation, który reprezentuje plik prezentacji
 Presentation presentation = new Presentation("AccessSlides.pptx");

 // Pobiera referencję do slajdu przez jego indeks
 ISlide slide = presentation.Slides[0];
```

## **Dostęp do slajdu po identyfikatorze**

Każdy slajd w prezentacji ma przypisany unikalny identyfikator. Możesz użyć metody [GetSlideById](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/methods/getslidebyid) (udostępnionej przez klasę [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation)), aby odwołać się do tego identyfikatora. Ten kod C# pokazuje, jak podać prawidłowy identyfikator slajdu i uzyskać dostęp do tego slajdu za pomocą metody [GetSlideById](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/methods/getslidebyid):

```c#
 // Tworzy obiekt Presentation, który reprezentuje plik prezentacji
 Presentation presentation = new Presentation("AccessSlides.pptx");

 // Pobiera identyfikator slajdu
 uint id = presentation.Slides[0].SlideId;

 // Uzyskuje dostęp do slajdu za pomocą jego identyfikatora
 IBaseSlide slide = presentation.GetSlideById(id);
```

## **Zmiana pozycji slajdu**
Aspose.Slides pozwala zmienić pozycję slajdu. Na przykład możesz określić, że pierwszy slajd ma stać się drugim slajdem.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
1. Pobierz referencję do slajdu (którego pozycję chcesz zmienić) przez jego indeks
1. Ustaw nową pozycję slajdu poprzez właściwość [SlideNumber](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/slidenumber/).
1. Zapisz zmodyfikowaną prezentację.

Ten kod C# demonstruje operację, w której slajd na pozycji 1 jest przenoszony na pozycję 2:

```c#
 // Tworzy obiekt Presentation, który reprezentuje plik prezentacji
using (Presentation pres = new Presentation("ChangePosition.pptx"))
{
    // Pobiera slajd, którego pozycja zostanie zmieniona
    ISlide sld = pres.Slides[0];

    // Ustawia nową pozycję slajdu
    sld.SlideNumber = 2;

    // Zapisuje zmodyfikowaną prezentację
    pres.Save("Aspose_out.pptx", SaveFormat.Pptx);
}
```

Pierwszy slajd stał się drugim; drugi slajd stał się pierwszym. Gdy zmieniasz pozycję slajdu, inne slajdy są automatycznie dostosowywane.

## **Ustawienie numeru slajdu**
Korzystając z właściwości [FirstSlideNumber](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/firstslidenumber/) (udostępnionej przez klasę [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation)), możesz określić nowy numer pierwszego slajdu w prezentacji. Operacja ta powoduje przeliczenie numerów pozostałych slajdów.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
1. Pobierz numer slajdu.
1. Ustaw numer slajdu.
1. Zapisz zmodyfikowaną prezentację.

Ten kod C# demonstruje operację, w której pierwszy numer slajdu jest ustawiony na 10:

```c#
 // Tworzy obiekt Presentation, który reprezentuje plik prezentacji
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    // Pobiera numer pierwszego slajdu
    int firstSlideNumber = presentation.FirstSlideNumber;

    // Ustawia numer pierwszego slajdu
    presentation.FirstSlideNumber=10;
    
    // Zapisuje zmodyfikowaną prezentację
    presentation.Save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
}
```

Jeśli wolisz pominąć pierwszy slajd, możesz rozpocząć numerację od drugiego slajdu (i ukryć numerację dla pierwszego slajdu) w następujący sposób:

```c#
using (var presentation = new Presentation())
{
    var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);

    // Ustawia numer pierwszego slajdu prezentacji
    presentation.FirstSlideNumber = 0;

    // Pokazuje numery slajdów dla wszystkich slajdów
    presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    // Ukrywa numer slajdu pierwszego
    presentation.Slides[0].HeaderFooterManager.SetSlideNumberVisibility(false);

    // Zapisuje zmodyfikowaną prezentację
    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Czy numer slajdu widziany przez użytkownika odpowiada zerowemu indeksowi kolekcji?**

Numer wyświetlany na slajdzie może rozpoczynać się od dowolnej wartości (np. 10) i nie musi odpowiadać indeksowi; zależność jest kontrolowana przez ustawienie [first slide number](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/firstslidenumber/) prezentacji.

**Czy ukryte slajdy wpływają na indeksowanie?**

Tak. Ukryty slajd pozostaje w kolekcji i jest liczony w indeksowaniu; „ukryty” odnosi się do wyświetlania, a nie do jego pozycji w kolekcji.

**Czy indeks slajdu zmienia się, gdy dodawane lub usuwane są inne slajdy?**

Tak. Indeksy zawsze odzwierciedlają bieżący porządek slajdów i są przeliczane po operacjach wstawiania, usuwania i przenoszenia.