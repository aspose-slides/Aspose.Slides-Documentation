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
- kod legacy
- nowoczesny kod
- podejście legacy
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak dodać nagłówki i stopki w prezentacjach PowerPoint PPT, PPTX i ODP w .NET, korzystając zarówno ze starszych, jak i nowoczesnych interfejsów API Aspose.Slides."
---
{{% alert color="primary" %}} 
Zostało wydane nowe [Aspose.Slides for .NET API](/slides/pl/net/), które umożliwia generowanie dokumentów PowerPoint od podstaw oraz edytowanie istniejących.
{{% /alert %}} 
## **Obsługa starszego kodu**
Aby używać kodu legacy opracowanego w wersjach Aspose.Slides for .NET starszych niż 13.x, musisz wprowadzić niewielkie zmiany w swoim kodzie, a będzie on działał jak dotąd. Wszystkie klasy, które znajdowały się w starszych wersjach Aspose.Slides for .NET w przestrzeniach nazw Aspose.Slide i Aspose.Slides.Pptx, zostały teraz połączone w jedną przestrzeń nazw Aspose.Slides. Zapoznaj się z poniższym prostym fragmentem kodu dodającym nagłówek i stopkę w prezentacji w starszym API Aspose.Slides i postępuj zgodnie z krokami opisującymi, jak migrować do nowego, połączonego API.
## **Podejście legacy Aspose.Slides for .NET**
```c#
PresentationEx sourcePres = new PresentationEx();

//Ustawianie właściwości widoczności nagłówka i stopki
sourcePres.UpdateSlideNumberFields = true;

//Aktualizacja pól daty i czasu
sourcePres.UpdateDateTimeFields = true;

//Pokaż placeholder daty i czasu
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Pokaż placeholder stopki
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Pokaż numer slajdu
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Ustaw widoczność nagłówka i stopki na slajdzie tytułowym
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Zapisz prezentację na dysku
sourcePres.Write("NewSource.pptx");
```

```c#
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

//Zapisz prezentację na dysku
pres.Write("HeadFoot.ppt");
```

## **Nowe podejście Aspose.Slides for .NET 13.x**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //Ustawianie właściwości widoczności nagłówka i stopki
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Aktualizacja pól daty i czasu
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Pokaż placeholder daty i czasu
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Pokaż placeholder stopki
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Ustaw widoczność nagłówka i stopki na slajdzie tytułowym
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Zapisz prezentację na dysku
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```