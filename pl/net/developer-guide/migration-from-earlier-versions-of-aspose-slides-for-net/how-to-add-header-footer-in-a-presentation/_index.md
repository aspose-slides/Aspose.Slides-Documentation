---
title: Jak dodać nagłówki i stopki do prezentacji w .NET
linktitle: Dodaj nagłówek i stopkę
type: docs
weight: 20
url: /pl/net/how-to-add-header-footer-in-a-presentation/
keywords:
- migracja
- dodaj nagłówek
- dodaj stopkę
- kod starszy
- nowoczesny kod
- stare podejście
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak dodać nagłówki i stopki w prezentacjach PowerPoint PPT, PPTX i ODP w .NET, używając zarówno starszych, jak i nowoczesnych interfejsów API Aspose.Slides."
---
{{% alert color="info" %}} 

Nowe [Aspose.Slides for .NET API](/slides/pl/net/) zostało wydane i teraz ten jedyny produkt obsługuje możliwość generowania dokumentów PowerPoint od podstaw oraz edytowania istniejących.

{{% /alert %}} 
## **Wsparcie dla starszego kodu**
Aby korzystać ze starszego kodu opracowanego w wersjach Aspose.Slides for .NET wcześniejszych niż 13.x, musisz wprowadzić niewielkie zmiany w swoim kodzie, a kod będzie działał tak jak wcześniej. Wszystkie klasy, które były dostępne w starej wersji Aspose.Slides for .NET w przestrzeniach nazw Aspose.Slide i Aspose.Slides.Pptx, zostały teraz połączone w jedną przestrzeń nazw Aspose.Slides. Proszę przyjrzeć się poniższemu prostemu fragmentowi kodu służącemu do dodawania nagłówka i stopki w prezentacji w starszym API Aspose.Slides oraz postępować zgodnie z opisanymi krokami migracji do nowego, połączonego API.
## **Starsze podejście Aspose.Slides for .NET**
```c#
PresentationEx sourcePres = new PresentationEx();

//Ustawianie właściwości widoczności nagłówka i stopki
sourcePres.UpdateSlideNumberFields = true;

//Aktualizacja pól daty i czasu
sourcePres.UpdateDateTimeFields = true;

//Pokaż miejsce na datę i czas
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Pokaż miejsce na stopkę
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Pokaż numer slajdu
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Ustaw widoczność nagłówka i stopki na slajdzie tytułowym
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Zapisz prezentację na dysk
sourcePres.Write("NewSource.pptx");
```

```c#
using Aspose.Slides;

//Utwórz prezentację
Presentation pres = new Presentation();

//Pobierz pierwszy slajd
Slide sld = pres.GetSlideByPosition(1);

//Uzyskaj dostęp do nagłówka / stopki slajdu
HeaderFooter hf = sld.HeaderFooter;

//Ustaw widoczność numeru strony
hf.PageNumberVisible = true;

//Ustaw widoczność stopki
hf.FooterVisible = true;

//Ustaw widoczność nagłówka
hf.HeaderVisible = true;

//Ustaw widoczność daty i czasu
hf.DateTimeVisible = true;

//Ustaw format daty i czasu
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//Ustaw tekst nagłówka
hf.HeaderText = "Header Text";

//Ustaw tekst stopki
hf.FooterText = "Footer Text";

//Zapisz prezentację na dysk
pres.Write("HeadFoot.ppt");
```



## **Nowe podejście Aspose.Slides for .NET 13.x**
``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation sourcePres = new Presentation())
{
    //Ustawianie właściwości widoczności nagłówka i stopki
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Aktualizacja pól daty i czasu
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Pokaż miejsce na datę i czas
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Pokaż miejsce na stopkę
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Ustaw widoczność nagłówka i stopki na slajdzie tytułowym
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Zapisz prezentację na dysk
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```