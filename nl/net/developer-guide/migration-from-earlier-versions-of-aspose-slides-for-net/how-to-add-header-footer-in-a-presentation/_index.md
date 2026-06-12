---
title: Hoe kop‑ en voetteksten toe te voegen aan presentaties in .NET
linktitle: Kop‑ en voettekst toevoegen
type: docs
weight: 20
url: /nl/net/how-to-add-header-footer-in-a-presentation/
keywords:
- migratie
- koptekst toevoegen
- voettekst toevoegen
- legacy-code
- moderne code
- legacy-benadering
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u kop‑ en voetteksten kunt toevoegen aan PowerPoint‑PPT, PPTX‑ en ODP‑presentaties in .NET met zowel legacy‑ als moderne Aspose.Slides‑API’s."
---
{{% alert color="primary" %}} 
Er is een nieuwe [Aspose.Slides for .NET API](/slides/nl/net/) uitgebracht en nu ondersteunt dit enkele product de mogelijkheid om PowerPoint‑documenten vanaf nul te genereren en bestaande documenten te bewerken.
{{% /alert %}} 
## **Ondersteuning voor legacy‑code**
Om de legacy‑code die ontwikkeld is met Aspose.Slides for .NET versies ouder dan 13.x te gebruiken, moet u enkele kleine aanpassingen in uw code doen zodat de code weer functioneert zoals voorheen. Alle klassen die aanwezig waren in de oude Aspose.Slides for .NET onder de namespaces Aspose.Slide en Aspose.Slides.Pptx zijn nu samengevoegd in één enkele Aspose.Slides‑namespace. Bekijk de volgende eenvoudige code‑snippet voor het toevoegen van een kop‑ en voettekst aan een presentatie in de legacy Aspose.Slides‑API en volg de stappen die beschrijven hoe u migreert naar de nieuwe samengevoegde API.
## **Legacy‑benadering van Aspose.Slides for .NET**
```c#
PresentationEx sourcePres = new PresentationEx();

//Instellen van de zichtbaarheid van kop- en voettekst
sourcePres.UpdateSlideNumberFields = true;

//Datum- en tijdvelden bijwerken
sourcePres.UpdateDateTimeFields = true;

//Datum- en tijd-placeholder weergeven
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Voettekst-placeholder weergeven
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Dia-nummer weergeven
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Zichtbaarheid van kop- en voettekst op titelpagina instellen
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Presentatie naar schijf schrijven
sourcePres.Write("NewSource.pptx");
```

```c#
//Maak de presentatie
Presentation pres = new Presentation();

//Haal de eerste dia op
Slide sld = pres.GetSlideByPosition(1);

//Toegang tot de kop-/voettekst van de dia
HeaderFooter hf = sld.HeaderFooter;

//Stel zichtbaarheid van paginanummer in
hf.PageNumberVisible = true;

//Stel zichtbaarheid van voettekst in
hf.FooterVisible = true;

//Stel zichtbaarheid van koptekst in
hf.HeaderVisible = true;

//Stel zichtbaarheid van datum-tijd in
hf.DateTimeVisible = true;

//Stel datum-tijdformaat in
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//Stel koptekst in
hf.HeaderText = "Header Text";

//Stel voettekst in
hf.FooterText = "Footer Text";

//Schrijf de presentatie naar de schijf
pres.Write("HeadFoot.ppt");
```

## **Nieuwe benadering van Aspose.Slides for .NET 13.x**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //Instellen van de zichtbaarheid van kop- en voetteksten
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Datum- en tijdvelden bijwerken
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Datum- en tijd-placeholder weergeven
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Voettekst-placeholder weergeven
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Zichtbaarheid van kop- en voettekst op titelpagina instellen
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Presentatie naar schijf schrijven
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```