---
title: Hur man lägger till sidhuvuden och sidfötter i presentationer i .NET
linktitle: Lägg till sidhuvud och sidfot
type: docs
weight: 20
url: /sv/net/how-to-add-header-footer-in-a-presentation/
keywords:
- migrering
- lägg till sidhuvud
- lägg till sidfot
- gammal kod
- modern kod
- gammal metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du lägger till sidhuvuden och sidfötter i PowerPoint PPT-, PPTX- och ODP-presentationer i .NET med både äldre och moderna Aspose.Slides-API:er."
---
{{% alert color="info" %}} 
En ny [Aspose.Slides for .NET API](/slides/sv/net/) har släppts och nu stödjer denna enda produkt möjligheten att skapa PowerPoint-dokument från grunden och redigera befintliga.
{{% /alert %}} 
## **Stöd för äldre kod**
För att kunna använda den äldre koden som utvecklats med Aspose.Slides for .NET versioner före 13.x måste du göra några mindre ändringar i din kod så att den fungerar som tidigare. Alla klasser som fanns i den gamla Aspose.Slides for .NET under namnutrymmena Aspose.Slide och Aspose.Slides.Pptx har nu slagits samman i ett enda Aspose.Slides-namnutrymme. Titta på följande enkla kodexempel för att lägga till sidhuvud och sidfot i en presentation i den äldre Aspose.Slides-API:n och följ stegen som beskriver hur du migrerar till det nya sammanslagna API:t.
## **Äldre Aspose.Slides för .NET-metod**
```c#
PresentationEx sourcePres = new PresentationEx();

//Ställer in synlighetsegenskaper för sidhuvud och sidfot
sourcePres.UpdateSlideNumberFields = true;

//Uppdatera datum- och tidsfält
sourcePres.UpdateDateTimeFields = true;

//Visa datum- och tid platshållare
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Visa sidfotens platshållare
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Visa bildnummer
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Ställ in  sidhuvud och sidfot synlighet på titelsliden
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Skriv presentationen till disken
sourcePres.Write("NewSource.pptx");
```

```c#
using Aspose.Slides;

//Skapa presentationen
Presentation pres = new Presentation();

//Hämta första bilden
Slide sld = pres.GetSlideByPosition(1);

//Åtkomst till sidhuvud / sidfot på bilden
HeaderFooter hf = sld.HeaderFooter;

//Ställ in bildnumrets synlighet
hf.PageNumberVisible = true;

//Ställ in sidfotens synlighet
hf.FooterVisible = true;

//Ställ in sidhuvudets synlighet
hf.HeaderVisible = true;

//Ställ in datum- och tidsynlighet
hf.DateTimeVisible = true;

//Ställ in datum- och tidsformat
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//Ställ in sidhuvudstext
hf.HeaderText = "Header Text";

//Ställ in sidfotstext
hf.FooterText = "Footer Text";

//Skriv presentationen till disken
pres.Write("HeadFoot.ppt");
```

## **Ny Aspose.Slides för .NET 13.x-metod**
``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation sourcePres = new Presentation())
{
    //Ställer in synlighetsegenskaper för sidhuvud och sidfot
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Uppdatera datum- och tidsfält
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Visa datum- och tid platshållare
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Visa sidfotens platshållare
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Ställ in sidhuvud och sidfot synlighet på titelsliden
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Skriv presentationen till disken
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```