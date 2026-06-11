---
title: Hur man lägger till rubriker och sidfot i presentationer i .NET
linktitle: Lägg till rubrik & sidfot
type: docs
weight: 20
url: /sv/net/how-to-add-header-footer-in-a-presentation/
keywords:
- migrering
- lägg till rubrik
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
description: "Lär dig hur du lägger till rubriker och sidfot i PowerPoint PPT, PPTX och ODP presentationer i .NET med både äldre och moderna Aspose.Slides API:er."
---
{{% alert color="primary" %}} 

En ny [Aspose.Slides for .NET API](/slides/sv/net/) har släppts och nu stödjer detta enda produkt möjligheten att skapa PowerPoint‑dokument från grunden samt redigera befintliga.

{{% /alert %}} 
## **Stöd för äldre kod**
För att kunna använda den äldre koden som utvecklats med Aspose.Slides for .NET versioner före 13.x, måste du göra några mindre ändringar i din kod så att den fungerar som tidigare. Alla klasser som fanns i den gamla Aspose.Slides for .NET under namnutrymmena Aspose.Slide och Aspose.Slides.Pptx har nu slagits samman i ett enda Aspose.Slides‑namnutrymme. Titta på följande enkla kodexempel för att lägga till sidhuvud och sidfot i en presentation i det äldre Aspose.Slides‑API:et och följ stegen som beskriver hur du migrerar till det nya sammanslagna API:et.
## **Legacy Aspose.Slides for .NET‑metod**
```c#
PresentationEx sourcePres = new PresentationEx();

//Ställer in egenskaper för rubrik- och sidfotssynlighet
sourcePres.UpdateSlideNumberFields = true;

//Uppdatera datum/tidsfält
sourcePres.UpdateDateTimeFields = true;

//Visa datum/tidsplatshållare
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Visa sidfotens platshållare
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Visa bildnummer
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Ställ in rubrik- och sidfotssynlighet på titelsidan
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Skriv presentationen till disk
sourcePres.Write("NewSource.pptx");
```

```c#
//Skapa presentationen
Presentation pres = new Presentation();

//Hämta första bilden
Slide sld = pres.GetSlideByPosition(1);

//Åtkomst till rubrik / sidfot på bilden
HeaderFooter hf = sld.HeaderFooter;

//Ställ in bildnummerns synlighet
hf.PageNumberVisible = true;

//Ställ in sidfotens synlighet
hf.FooterVisible = true;

//Ställ in rubrikens synlighet
hf.HeaderVisible = true;

//Ställ in datum/tid synlighet
hf.DateTimeVisible = true;

//Ställ in datum/tidsformat
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//Ställ in rubriktext
hf.HeaderText = "Header Text";

//Ställ in sidfotstext
hf.FooterText = "Footer Text";

//Skriv presentationen till disk
pres.Write("HeadFoot.ppt");
```



## **Ny Aspose.Slides for .NET 13.x‑metod**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //Ställer in egenskaper för rubrik- och sidfotssynlighet
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Uppdatera datum/tidsfält
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Visa datum/tidsplatshållare
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Visa sidfotens platshållare
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Ställ in  rubrik- och sidfotssynlighet på titelsidan
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Skriv presentationen till disk
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```