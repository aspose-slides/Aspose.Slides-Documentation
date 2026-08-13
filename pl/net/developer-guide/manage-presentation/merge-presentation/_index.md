---
title: Efektywne scalanie prezentacji w .NET
linktitle: Scalanie prezentacji
type: docs
weight: 40
url: /pl/net/merge-presentation/
keywords:
- scalanie PowerPoint
- scalanie prezentacji
- scalanie slajdów
- scalanie PPT
- scalanie PPTX
- scalanie ODP
- łączenie PowerPoint
- łączenie prezentacji
- łączenie slajdów
- łączenie PPT
- łączenie PPTX
- łączenie ODP
- .NET
- C#
- Aspose.Slides
description: "Bezproblemowo scalaj prezentacje PowerPoint (PPT, PPTX) oraz OpenDocument (ODP) przy użyciu Aspose.Slides dla .NET, usprawniając swój przepływ pracy."
---
## **Przegląd**

Aspose.Slides pozwala łączyć prezentacje poprzez klonowanie slajdów z jednej prezentacji do drugiej. Ten artykuł wyjaśnia, jak scalać całe prezentacje lub wybrane slajdy, używać mastera slajdów lub konkretnego układu podczas scalania, obsługiwać prezentacje o różnych rozmiarach slajdów oraz dodawać scalone slajdy do sekcji prezentacji. Omówiono także praktyczne uwagi dotyczące scalonej treści, w tym notatki prelegenta, komentarze, pliki źródłowe zabezpieczone hasłem oraz wykorzystanie wątków.

## **Optymalizacja scalania prezentacji**

Z [Aspose.Slides for .NET](https://products.aspose.com/slides/pl/net/), płynnie łącz prezentacje PowerPoint, zachowując style, układy i wszystkie elementy. W odróżnieniu od innych narzędzi, Aspose.Slides scala prezentacje bez utraty jakości ani danych. Scalaj całe prezentacje, wybrane slajdy oraz różne formaty plików (PPT do PPTX itp.).

### **Funkcje scalania**

- **Pełne scalanie prezentacji:** Połącz wszystkie slajdy w jeden plik.  
- **Scalanie wybranych slajdów:** Wybierz i połącz wybrane slajdy.  
- **Scalanie między formatami:** Łącz prezentacje o różnych formatach, zachowując integralność.

{{% alert title="Tip" color="info" %}}  
Szukasz szybkiego i **darmowego narzędzia online** do **scalania prezentacji PowerPoint**? Wypróbuj [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/pl/merger).  

- **Łatwe scalanie plików PowerPoint**: Połącz wiele prezentacji **PPT, PPTX, ODP** w jeden plik.  
- **Obsługa różnych formatów**: Scalaj **PPT do PPTX**, **PPTX do ODP** i inne.  
- **Brak instalacji**: Działa bezpośrednio w przeglądarce, szybko i bezpiecznie.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/pl/merger)  

Rozpocznij scalanie plików PowerPoint już dziś z **darmowym narzędziem online Aspose**!  
{{% /alert %}}

## **Scalanie prezentacji**

Kiedy [scalasz jedną prezentację z drugą](https://products.aspose.com/slides/pl/net/merger/ppt/), skutecznie łączysz ich slajdy w jedną prezentację, aby uzyskać jeden plik.

{{% alert title="Info" color="info" %}}  
Większość programów do prezentacji (PowerPoint lub OpenOffice) nie posiada funkcji umożliwiających łączenie prezentacji w ten sposób.  

[**Aspose.Slides for .NET**](https://products.aspose.com/slides/pl/net/) pozwala jednak scalać prezentacje na różne sposoby. Możesz scalać prezentacje ze wszystkimi ich kształtami, stylami, tekstami, formatowaniem, komentarzami, animacjami itp., nie martwiąc się o utratę jakości czy danych.  

**Zobacz także**  

[Clone Slides](https://docs.aspose.com/slides/pl/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.*  
{{% /alert %}}

### **Co można scalać**

Z Aspose.Slides możesz scalać  

* całe prezentacje. Wszystkie slajdy z prezentacji trafiają do jednej prezentacji  
* wybrane slajdy. Wybrane slajdy trafiają do jednej prezentacji  
* prezentacje w jednym formacie (PPT do PPT, PPTX do PPTX itp.) oraz w różnych formatach (PPT do PPTX, PPTX do ODP itp.) ze sobą.  

{{% alert title="Note" color="warning" %}}  
Poza prezentacjami, Aspose.Slides umożliwia scalanie innych plików:  

* [Obrazy](https://products.aspose.com/slides/pl/net/merger/image-to-image/), takie jak [JPG do JPG](https://products.aspose.com/slides/pl/net/merger/jpg-to-jpg/) czy [PNG do PNG](https://products.aspose.com/slides/pl/net/merger/png-to-png/)  
* Dokumenty, takie jak [PDF do PDF](https://products.aspose.com/slides/pl/net/merger/pdf-to-pdf/) lub [HTML do HTML](https://products.aspose.com/slides/pl/net/merger/html-to-html/)  
* Dwa różne pliki, np. [obraz do PDF](https://products.aspose.com/slides/pl/net/merger/image-to-pdf/), [JPG do PDF](https://products.aspose.com/slides/pl/net/merger/jpg-to-pdf/) lub [TIFF do PDF](https://products.aspose.com/slides/pl/net/merger/tiff-to-pdf/).  
{{% /alert %}}

### **Opcje scalania**

Możesz zastosować opcje określające, czy  

* każdy slajd w prezentacji wynikowej zachowuje unikalny styl  
* określony styl jest używany dla wszystkich slajdów w prezentacji wynikowej.  

Aby scalać prezentacje, Aspose.Slides udostępnia metodę [AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/methods/addclone) (z interfejsu [ISlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection)). Istnieje kilka implementacji metod `AddClone`, które definiują parametry procesu scalania prezentacji. Każdy obiekt Presentation posiada kolekcję [Slides](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/properties/slides), więc możesz wywołać metodę `AddClone` z prezentacji, do której chcesz dodać slajdy.  

Metoda `AddClone` zwraca obiekt `ISlide`, będący klonem slajdu źródłowego. Slajdy w prezentacji wyjściowej są po prostu kopią slajdów ze źródła. Dzięki temu możesz modyfikować otrzymane slajdy (np. stosować style, opcje formatowania lub układy) bez obaw, że zostaną zmienione prezentacje źródłowe.  

## **Merge Presentations**  

Aspose.Slides udostępnia metodę [**AddClone (ISlide)**](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/methods/addclone), która pozwala łączyć slajdy, zachowując ich układy i style (domyślne parametry).  

Ten kod C# pokazuje, jak scalać prezentacje:  

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Merge Presentations with a Slide Master**  

Aspose.Slides udostępnia metodę [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/pl/net/aspose.slides.islidecollection/addclone/methods/2), która pozwala łączyć slajdy, zastosowując szablon mastera slajdów. Dzięki temu, w razie potrzeby, możesz zmienić styl slajdów w prezentacji wynikowej.  

Poniższy kod C# demonstruje opisane działanie:  

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.Masters[0], allowCloneMissingLayout: true);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Note" color="warning" %}}  
Układ slajdu dla mastera jest określany automatycznie. Gdy nie można określić odpowiedniego układu, a parametr `allowCloneMissingLayout` metody `AddClone` ma wartość true, używany jest układ slajdu źródłowego. W przeciwnym razie zostanie zgłoszony [PptxEditException](https://reference.aspose.com/slides/pl/net/aspose.slides/pptxeditexception).  
{{% /alert %}}

Jeśli chcesz, aby slajdy w prezentacji wynikowej miały inny układ, użyj zamiast tego metody [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/pl/net/aspose.slides.islidecollection/addclone/methods/1) podczas scalania.  

## **Merge Specific Slides from Presentations**  

Scalanie konkretnych slajdów z wielu prezentacji jest przydatne przy tworzeniu dedykowanych zestawów slajdów. Aspose.Slides for .NET umożliwia wybór i import tylko potrzebnych slajdów. API zachowuje formatowanie, układ i projekt oryginalnych slajdów.  

Poniższy kod C# tworzy nową prezentację, dodaje slajdy tytułowe z dwóch innych prezentacji i zapisuje wynik do pliku:  

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
using (Presentation presentation1 = new Presentation("presentation1.pptx"))
using (Presentation presentation2 = new Presentation("presentation2.pptx"))
{
    presentation.Slides.RemoveAt(0);

    ISlide slide1 = GetTitleSlide(presentation1);

    if (slide1 != null)
        presentation.Slides.AddClone(slide1);

    ISlide slide2 = GetTitleSlide(presentation2);

    if (slide2 != null)
        presentation.Slides.AddClone(slide2);

    presentation.Save("combined.pptx", SaveFormat.Pptx);
}

static ISlide GetTitleSlide(IPresentation presentation)
{
    foreach (ISlide slide in presentation.Slides)
    {
        if (slide.LayoutSlide.LayoutType == SlideLayoutType.Title)
        {
            return slide;
        }
    }
    return null;
}
```
```cs
using Aspose.Slides;

static ISlide GetTitleSlide(IPresentation presentation)
{
    foreach (ISlide slide in presentation.Slides)
    {
        if (slide.LayoutSlide.LayoutType == SlideLayoutType.Title)
        {
            return slide;
        }
    }
    return null;
}
```

## **Merge Presentations with a Slide Layout**  

Ten kod C# pokazuje, jak połączyć slajdy z prezentacji, stosując wybrany układ slajdu, aby uzyskać jedną prezentację wynikową:  

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.LayoutSlides[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Merge Presentations with Different Slide Sizes**  

{{% alert title="Note" color="warning" %}}  
Scalanie prezentacji o różnych rozmiarach slajdów nie generuje błędu, ale scalone slajdy przyjmują rozmiar slajdu docelowej prezentacji, podczas gdy ich kształty zachowują pierwotne pozycje i rozmiary, co może spowodować nieprawidłowe rozmieszczenie treści lub wystawienie jej poza granice slajdu.  
{{% /alert %}}  

Aby scalić dwie prezentacje o różnych rozmiarach slajdów i zachować prawidłowe rozmieszczenie treści, zmień rozmiar jednej z prezentacji tak, aby odpowiadał rozmiarowi drugiej.  

Przykładowy kod demonstrujący opisane działanie:  

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres1 = new Presentation("pres1.pptx"),
   pres2 = new Presentation("pres2.pptx"))
{
   pres2.SlideSize.SetSize(pres1.SlideSize.Size.Width, pres1.SlideSize.Size.Height, SlideSizeScaleType.EnsureFit);
 
   foreach (ISlide slide in pres2.Slides)
   {
       pres1.Slides.AddClone(slide);
   }
 
   pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Merge Slides to a Presentation Section**  

Ten kod C# pokazuje, jak scalić konkretny slajd do sekcji w prezentacji:  

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    for (var index = 0; index < pres2.Slides.Count; index++)
    {
        ISlide slide = pres2.Slides[index];
        pres1.Slides.AddClone(slide, pres1.Sections[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

Slajd zostaje dodany na końcu sekcji.  

{{% alert title="Tip" color="info" %}}  
Aspose udostępnia [DARMOWĄ aplikację internetową Collage](https://products.aspose.app/slides/pl/collage). Korzystając z tego serwisu online, możesz scalać [JPG do JPG](https://products.aspose.app/slides/pl/collage/jpg) lub PNG do PNG, tworzyć [siatki zdjęć](https://products.aspose.app/slides/pl/collage/photo-grid) i wiele więcej.  
{{% /alert %}}

## **FAQ**

### Czy notatki prelegenta są zachowywane podczas scalania?

Tak. Podczas klonowania slajdów Aspose.Slides przenosi wszystkie elementy slajdu, w tym notatki, formatowanie i animacje.

### Czy komentarze i ich autorzy są przenoszeni?

Komentarze, jako część treści slajdu, są kopiowane razem ze slajdem. Etykiety autorów komentarzy są zachowywane jako obiekty komentarzy w wynikowej prezentacji.

### Co zrobić, gdy prezentacja źródłowa jest zabezpieczona hasłem?

Należy ją [otworzyć przy użyciu hasła](/slides/pl/net/password-protected-presentation/) poprzez [LoadOptions.Password](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/password/); po załadowaniu slajdy mogą być bezpiecznie klonowane do niechronionego pliku docelowego (lub również chronionego).

### Jak bezpieczne jest wielowątkowe wykonywanie operacji scalania?

Nie należy używać tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) z [wielu wątków](/slides/pl/net/multithreading/). Zalecana zasada to „jeden dokument — jeden wątek”; różne pliki mogą być przetwarzane równolegle w oddzielnych wątkach.