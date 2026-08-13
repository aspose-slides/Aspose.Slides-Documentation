---
title: Hoe je koppen en voetteksten toevoegt aan presentaties in .NET
linktitle: Kop en voettekst toevoegen
type: docs
weight: 20
url: /nl/net/how-to-add-header-footer-in-a-presentation/
keywords:
- migratie
- kop toevoegen
- voettekst toevoegen
- legacy code
- moderne code
- legacy aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u koppen en voetteksten toevoegt aan PowerPoint PPT, PPTX en ODP‑presentaties in .NET met zowel de legacy‑ als de moderne Aspose.Slides‑API’s."
---
{{% alert color="info" %}} 

Er is een nieuwe [Aspose.Slides for .NET API](/slides/nl/net/) uitgebracht en nu ondersteunt dit enkele product de mogelijkheid om PowerPoint‑documenten vanaf nul te genereren en bestaande documenten te bewerken.

{{% /alert %}} 
## **Ondersteuning voor legacy‑code**
Om de legacy‑code te kunnen gebruiken die ontwikkeld is met Aspose.Slides for .NET versies ouder dan 13.x, moet u enkele kleine aanpassingen in uw code doen, waarna de code weer werkt zoals voorheen. Alle klassen die aanwezig waren in de oude Aspose.Slides for .NET onder de Aspose.Slide‑ en Aspose.Slides.Pptx‑namespaces zijn nu samengevoegd in één Aspose.Slides‑namespace. Bekijk alstublieft het volgende eenvoudige code‑fragment voor het toevoegen van een kop‑en‑voettekst aan een presentatie in de legacy Aspose.Slides‑API en volg de stappen die beschrijven hoe u naar de nieuwe samengestelde API migreert.
## **Legacy Aspose.Slides for .NET aanpak**
```c#
PresentationEx sourcePres = new PresentationEx();

//Instellen van zichtbaarheid van kop‑ en voettekst‑eigenschappen
sourcePres.UpdateSlideNumberFields = true;

//Werk de datum‑tijdvelden bij
sourcePres.UpdateDateTimeFields = true;

//Toon datum‑tijd‑placeholder
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Toon de voettekst‑placeholder
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Toon dia‑nummer
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Stel de zichtbaarheid van kop‑ en voettekst in op titeldia
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Schrijf de presentatie naar de schijf
sourcePres.Write("NewSource.pptx");
```

```c#
using Aspose.Slides;

//Maak de presentatie
Presentation pres = new Presentation();

//Haal de eerste dia op
Slide sld = pres.GetSlideByPosition(1);

//Toegang tot de kop-/voettekst van de dia
HeaderFooter hf = sld.HeaderFooter;

//Stel de zichtbaarheid van paginanummer in
hf.PageNumberVisible = true;

//Stel de zichtbaarheid van voettekst in
hf.FooterVisible = true;

//Stel de zichtbaarheid van koptekst in
hf.HeaderVisible = true;

//Stel de zichtbaarheid van datum-tijd in
hf.DateTimeVisible = true;

//Stel het datum-tijdformaat in
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//Stel de koptekst in
hf.HeaderText = "Header Text";

//Stel de voettekst in
hf.FooterText = "Footer Text";

//Schrijf de presentatie naar de schijf
pres.Write("HeadFoot.ppt");
```



## **Nieuwe Aspose.Slides for .NET 13.x aanpak**
``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation sourcePres = new Presentation())
{
    //Instellen van de zichtbaarheid van kop‑ en voettekst‑eigenschappen
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Werk de datum‑tijdvelden bij
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Toon datum‑tijd‑placeholder
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Toon de voettekst‑placeholder
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //Stel de zichtbaarheid van kop‑ en voettekst in op de titeldia
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //Schrijf de presentatie naar de schijf
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```