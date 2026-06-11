---
title: Efektywne scalanie prezentacji w .NET
linktitle: Scalanie prezentacji
type: docs
weight: 40
url: /pl/net/merge-presentation/
keywords:
- scal PowerPoint
- scal prezentacje
- scal slajdy
- scal PPT
- scal PPTX
- scal ODP
- połącz PowerPoint
- połącz prezentacje
- połącz slajdy
- połącz PPT
- połącz PPTX
- połącz ODP
- .NET
- C#
- Aspose.Slides
description: "Bezproblemowo scalaj prezentacje PowerPoint (PPT, PPTX) i OpenDocument (ODP) przy użyciu Aspose.Slides for .NET, usprawniając swój przepływ pracy."
---
## **Przegląd**

Aspose.Slides umożliwia scalanie prezentacji poprzez klonowanie slajdów z jednej prezentacji do drugiej. Ten artykuł wyjaśnia, jak scalić całe prezentacje lub wybrane slajdy, używać szablonu mastera slajdów lub konkretnego układu podczas scalania, obsługiwać prezentacje o różnych rozmiarach slajdów oraz dodawać scalone slajdy do sekcji prezentacji. Omówione są również praktyczne uwagi dotyczące scalanej treści, w tym notatki prelegenta, komentarze, pliki źródłowe chronione hasłem oraz użycie wątków.

## **Optymalizacja scalania prezentacji**

Z [Aspose.Slides for .NET](https://products.aspose.com/slides/pl/net/) łatwo łączysz prezentacje PowerPoint, zachowując style, układy i wszystkie elementy. W przeciwieństwie do innych narzędzi, Aspose.Slides scala prezentacje bez utraty jakości ani danych. Scalaj całe prezentacje, konkretne slajdy oraz różne formaty plików (PPT do PPTX itp.).

### **Funkcje scalania**

- **Pełne scalanie prezentacji:** Zbierz wszystkie slajdy w jednym pliku.
- **Scalanie wybranych slajdów:** Wybierz i połącz wybrane slajdy.
- **Scalanie międzyformatowe:** Integruj prezentacje o różnych formatach, zachowując integralność.

{{% alert title="Wskazówka" color="primary" %}}  

Szukasz szybkiego i **darmowego narzędzia online** do **scalania prezentacji PowerPoint**? Wypróbuj [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/pl/merger).  

- **Łatwe scalanie plików PowerPoint**: Połącz wiele prezentacji **PPT, PPTX, ODP** w jeden plik.  
- **Obsługa różnych formatów**: Scal **PPT do PPTX**, **PPTX do ODP** i inne.  
- **Bez instalacji**: Działa bezpośrednio w przeglądarce, szybko i bezpiecznie.  

[![Scal pliki PowerPoint online](slides-merger.png)](https://products.aspose.app/slides/pl/merger)  

Rozpocznij scalanie swoich plików PowerPoint już dziś z **darmowym narzędziem online Aspose**!  

{{% /alert %}}

## **Scalanie prezentacji**

Kiedy [scalasz jedną prezentację z drugą](https://products.aspose.com/slides/pl/net/merger/ppt/), efektywnie łączysz ich slajdy w jednej prezentacji, aby uzyskać jeden plik. 

{{% alert title="Informacja" color="info" %}}

Większość programów do prezentacji (PowerPoint lub OpenOffice) nie posiada funkcji umożliwiających łączenie prezentacji w taki sposób. 

[Aspose.Slides for .NET](https://products.aspose.com/slides/pl/net/) umożliwia scalanie prezentacji na różne sposoby. Możesz scalić prezentacje ze wszystkimi ich kształtami, stylami, tekstami, formatowaniem, komentarzami, animacjami itp., nie obawiając się utraty jakości lub danych. 

**Zobacz także**

[Clone Slides](https://docs.aspose.com/slides/pl/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **Co można scalić**

Z Aspose.Slides możesz scalić 

* całe prezentacje. Wszystkie slajdy z prezentacji trafiają do jednej prezentacji
* wybrane slajdy. Wybrane slajdy trafiają do jednej prezentacji
* prezentacje w jednym formacie (PPT do PPT, PPTX do PPTX itp.) oraz w różnych formatach (PPT do PPTX, PPTX do ODP itp.) ze sobą. 

{{% alert title="Uwaga" color="warning" %}} 

Oprócz prezentacji Aspose.Slides umożliwia scalanie innych plików:

* [Obrazy](https://products.aspose.com/slides/pl/net/merger/image-to-image/), np. [JPG do JPG](https://products.aspose.com/slides/pl/net/merger/jpg-to-jpg/) lub [PNG do PNG](https://products.aspose.com/slides/pl/net/merger/png-to-png/)
* Dokumenty, np. [PDF do PDF](https://products.aspose.com/slides/pl/net/merger/pdf-to-pdf/) lub [HTML do HTML](https://products.aspose.com/slides/pl/net/merger/html-to-html/)
* Dwa różne pliki, np. [obraz do PDF](https://products.aspose.com/slides/pl/net/merger/image-to-pdf/), [JPG do PDF](https://products.aspose.com/slides/pl/net/merger/jpg-to-pdf/) lub [TIFF do PDF](https://products.aspose.com/slides/pl/net/merger/tiff-to-pdf/).

{{% /alert %}}

### **Opcje scalania**

Możesz zastosować opcje określające, czy

* każdy slajd w wynikowej prezentacji zachowuje unikalny styl
* określony styl jest używany dla wszystkich slajdów w wynikowej prezentacji. 

Aby scalić prezentacje, Aspose.Slides udostępnia metody [AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/methods/addclone) (z interfejsu [ISlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection)). Istnieje kilka implementacji metod `AddClone`, które definiują parametry procesu scalania prezentacji. Każdy obiekt Presentation ma kolekcję [Slides](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/properties/slides), więc możesz wywołać metodę `AddClone` z prezentacji, do której chcesz scalić slajdy. 

Metoda `AddClone` zwraca obiekt `ISlide`, będący klonem slajdu źródłowego. Slajdy w prezentacji wynikowej są po prostu kopiami slajdów ze źródła. Dzięki temu możesz modyfikować powstałe slajdy (np. stosować style, opcje formatowania lub układy), nie martwiąc się o wpływ na prezentacje źródłowe. 

## **Scalanie prezentacji** 

Aspose.Slides udostępnia metodę [**AddClone (ISlide)**](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection/methods/addclone), która pozwala łączyć slajdy, zachowując ich układy i style (parametry domyślne). 

Ten kod C# pokazuje, jak scalić prezentacje:

```c#
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

## **Scalanie prezentacji z szablonem mastera slajdów**

Aspose.Slides udostępnia metodę [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/pl/net/aspose.slides.islidecollection/addclone/methods/2), która pozwala połączyć slajdy, stosując szablon mastera slajdów. Dzięki temu, w razie potrzeby, możesz zmienić styl slajdów w prezentacji wynikowej. 

Ten kod C# demonstruje opisaną operację:

```c#
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

{{% alert title="Uwaga" color="warning" %}} 

Układ slajdu dla mastera jest określany automatycznie. Gdy nie można określić odpowiedniego układu, a parametr logiczny `allowCloneMissingLayout` metody `AddClone` jest ustawiony na true, używany jest układ slajdu źródłowego. W przeciwnym razie zostanie zgłoszony [PptxEditException](https://reference.aspose.com/slides/pl/net/aspose.slides/pptxeditexception). 

{{% /alert %}}

Jeśli chcesz, aby slajdy w prezentacji wynikowej miały inny układ slajdu, użyj metody [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/pl/net/aspose.slides.islidecollection/addclone/methods/1) podczas scalania. 

## **Scalanie wybranych slajdów z prezentacji**

Scalanie konkretnych slajdów z wielu prezentacji jest przydatne przy tworzeniu niestandardowych zestawów slajdów. Aspose.Slides for .NET umożliwia wybranie i importowanie tylko potrzebnych slajdów. API zachowuje formatowanie, układ i projekt oryginalnych slajdów.

Poniższy kod C# tworzy nową prezentację, dodaje slajdy tytułowe z dwóch innych prezentacji i zapisuje wynik do pliku:

```cs
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
```
```cs
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

## **Scalanie prezentacji z układem slajdu**

Ten kod C# pokazuje, jak połączyć slajdy z prezentacji, stosując wybrany układ slajdu, aby uzyskać jedną prezentację wynikową:

```c#
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

## **Scalanie prezentacji o różnych rozmiarach slajdów**

{{% alert title="Uwaga" color="warning" %}} 

Nie można scalić prezentacji o różnych rozmiarach slajdów. 

{{% /alert %}}

Aby scalić dwie prezentacje o różnych rozmiarach slajdów, należy zmienić rozmiar jednej z nich, aby dopasować go do drugiej. 

Poniższy kod demonstruje opisane działanie:

```c#
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

## **Scalanie slajdów do sekcji prezentacji**

Ten kod C# pokazuje, jak scalić określony slajd do sekcji w prezentacji:

```c#
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

Slajd jest dodawany na koniec sekcji. 

{{% alert title="Wskazówka" color="primary" %}}

Aspose oferuje [DARMOWĄ aplikację internetową Collage](https://products.aspose.app/slides/pl/collage). Korzystając z tej usługi online, możesz scalić [JPG do JPG](https://products.aspose.app/slides/pl/collage/jpg) lub PNG do PNG, tworzyć [siatki zdjęć](https://products.aspose.app/slides/pl/collage/photo-grid) i inne. 

{{% /alert %}}

## **FAQ**

**Czy notatki prelegenta są zachowywane podczas scalania?**

Tak. Podczas klonowania slajdów Aspose.Slides przenosi wszystkie elementy slajdu, w tym notatki, formatowanie i animacje.

**Czy komentarze i ich autorzy są przenoszeni?**

Komentarze, jako część treści slajdu, są kopiowane razem ze slajdem. Etykiety autorów komentarzy są zachowywane jako obiekty komentarzy w powstałej prezentacji.

**Co zrobić, gdy prezentacja źródłowa jest chroniona hasłem?**

Należy ją [otworzyć z hasłem](/slides/pl/net/password-protected-presentation/) przy użyciu [LoadOptions.Password](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/password/); po załadowaniu slajdy można bezpiecznie sklonować do niechronionego pliku docelowego (lub również chronionego).

**Jak bezpieczne jest użycie wielu wątków podczas scalania?**

Nie używaj tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) z [wielu wątków](/slides/pl/net/multithreading/). Zalecana zasada to „jeden dokument — jeden wątek”; różne pliki mogą być przetwarzane równolegle w oddzielnych wątkach.