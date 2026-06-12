---
title: Dia's van een presentatie klonen in .NET
linktitle: Dia's klonen
type: docs
weight: 40
url: /nl/net/clone-slides/
keywords:
- dia klonen
- dia kopiëren
- dia opslaan
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Dupliceer snel PowerPoint-dia's met Aspose.Slides voor .NET. Volg onze duidelijke code-voorbeelden om PPT-creatie in seconden te automatiseren en handmatig werk te elimineren."
---
## **Introductie**

Clonen is het proces van het maken van een exacte kopie of replica van iets. Aspose.Slides stelt je ook in staat om (een) dia te kopiëren (clonen) en vervolgens de gekloonde dia in de huidige presentatie of een andere geopende presentatie in te voegen. Dia‑clonen maakt een nieuwe dia die ontwikkelaars kunnen aanpassen zonder de oorspronkelijke dia te beïnvloeden. Er zijn verschillende manieren om een dia te klonen:

- Kloon aan het einde van een presentatie.
- Kloon op een andere positie binnen een presentatie.
- Kloon aan het einde van een andere presentatie.
- Kloon op een andere positie in een andere presentatie.
- Kloon op een specifieke positie in een andere presentatie.

In Aspose.Slides voor .NET biedt de dia‑collectie (een collectie van [ISlide](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/) objecten) die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) object de methoden [AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/addclone/) en [InsertClone](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/insertclone/) om de hierboven beschreven dia‑kloningsbewerkingen uit te voeren.

## **Kloon een dia aan het einde van een presentatie**

Als je een dia wilt klonen en vervolgens in hetzelfde presentatie‑bestand aan het einde van de bestaande dia's wilt gebruiken, gebruik je de [AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/methods/addclone/index) methode volgens de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.
2. Instantieer de [ISlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection) klasse door te refereren naar de Slides‑collectie die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) object.
3. Roep de [AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/methods/addclone/index) methode aan die wordt blootgesteld door het [ISlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection) object en geef de te klonen dia als parameter mee aan de [AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/methods/addclone/index) methode.
4. Schrijf het gewijzigde presentatie‑bestand weg.

In het onderstaande voorbeeld hebben we een dia (die zich op de eerste positie – index 0 – van de presentatie bevindt) naar het einde van de presentatie gekloond.

```c#
// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // Kloon de gewenste dia naar het einde van de verzameling dia's in dezelfde presentatie
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // Schrijf de aangepaste presentatie naar schijf
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```

## **Kloon een dia naar een andere positie binnen een presentatie**

Als je een dia wilt klonen en vervolgens in hetzelfde presentatie‑bestand, maar op een andere positie, wilt gebruiken, gebruik dan de [InsertClone](https://reference.aspose.com/slides/nl/net/aspose.slides.ishapecollection/insertclone/methods/1) methode:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.
2. Instantieer de klasse door te refereren naar de **Slides**‑collectie die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) object.
3. Roep de [InsertClone](https://reference.aspose.com/slides/nl/net/aspose.slides.ishapecollection/insertclone/methods/1) methode aan die wordt blootgesteld door het [ISlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection) object en geef de te klonen dia samen met de index voor de nieuwe positie als parameter mee aan de [InsertClone](https://reference.aspose.com/slides/nl/net/aspose.slides.ishapecollection/insertclone/methods/1) methode.
4. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een dia (die zich op index 0 – positie 1 – van de presentatie bevindt) naar index 1 – positie 2 – van de presentatie gekloond.

```c#
// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // Kloon de gewenste dia naar het einde van de verzameling dia's in dezelfde presentatie
    ISlideCollection slds = pres.Slides;

    // Kloon de gewenste dia naar de gespecificeerde index in dezelfde presentatie
    slds.InsertClone(2, pres.Slides[1]);

    // Schrijf de aangepaste presentatie naar schijf
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **Kloon een dia aan het einde van een andere presentatie**

Als je een dia uit één presentatie wilt klonen en deze in een andere presentatie‑bestand wilt gebruiken, aan het einde van de bestaande dia's:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse die de presentatie bevat waaruit de dia gekloond zal worden.
2. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse die de doelpresentatie bevat waaraan de dia zal worden toegevoegd.
3. Instantieer de [ISlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection) klasse door te refereren naar de **Slides**‑collectie die wordt blootgesteld door het Presentation‑object van de doelpresentatie.
4. Roep de [AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/methods/addclone/index) methode aan die wordt blootgesteld door het [ISlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection) object en geef de dia uit de bronpresentatie als parameter mee aan de [AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/methods/addclone/index) methode.
5. Schrijf het gewijzigde doel‑presentatie‑bestand weg.

In het onderstaande voorbeeld hebben we een dia (van de eerste index van de bronpresentatie) naar het einde van de doelpresentatie gekloond.

```c#
// Instantieer de Presentation-klasse om het bronpresentatiebestand te laden
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Instantieer de Presentation-klasse voor de bestemmings-PPTX (waar de dia gekloond moet worden)
    using (Presentation destPres = new Presentation())
    {
        // Kloon de gewenste dia vanuit de bronpresentatie naar het einde van de verzameling dia's in de bestemmingspresentatie
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // Schrijf de bestemmingspresentatie naar schijf
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Kloon een dia naar een andere positie in een andere presentatie**

Als je een dia uit één presentatie moet klonen en deze in een andere presentatie‑bestand op een specifieke positie wilt gebruiken:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse die de bronpresentatie bevat waaruit de dia gekloond zal worden.
2. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse die de presentatie bevat waaraan de dia zal worden toegevoegd.
3. Instantieer de [ISlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection) klasse door te refereren naar de Slides‑collectie die wordt blootgesteld door het Presentation‑object van de doelpresentatie.
4. Roep de [InsertClone](https://reference.aspose.com/slides/nl/net/aspose.slides.ishapecollection/insertclone/methods/1) methode aan die wordt blootgesteld door het [ISlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection) object en geef de dia uit de bronpresentatie samen met de gewenste positie als parameter mee aan de [InsertClone](https://reference.aspose.com/slides/nl/net/aspose.slides.ishapecollection/insertclone/methods/1) methode.
5. Schrijf het gewijzigde doel‑presentatie‑bestand weg.

In het onderstaande voorbeeld hebben we een dia (van de nul‑index van de bronpresentatie) naar index 1 (positie 2) van de doelpresentatie gekloond.

```c#
// Instantieer de Presentation-klasse om het bronpresentatiebestand te laden
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Instantieer de Presentation-klasse voor de bestemmings-PPTX (waar de dia gekloond moet worden)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // Schrijf de bestemmingspresentatie naar schijf
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Kloon een dia op een specifieke positie in een andere presentatie**

Als je een dia met een masterslide uit één presentatie moet klonen en in een andere presentatie wilt gebruiken, moet je eerst de gewenste masterslide van de bronpresentatie naar de doelpresentatie klonen. Vervolgens moet je die masterslide gebruiken om de dia met masterslide te klonen. De methode **AddClone(ISlide, IMasterSlide)** verwacht een masterslide uit de doelpresentatie in plaats van uit de bronpresentatie. Volg de onderstaande stappen om een dia met een master te klonen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse die de bronpresentatie bevat waaruit de dia gekloond zal worden.
2. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse die de doelpresentatie bevat waaraan de dia gekloond zal worden.
3. Toegang tot de te klonen dia samen met de masterslide.
4. Instantieer de [IMasterSlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslidecollection) klasse door te refereren naar de Masters‑collectie die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) object van de doelpresentatie.
5. Roep de [AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/methods/addclone/index) methode aan die wordt blootgesteld door het [IMasterSlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslidecollection) object en geef de master uit de bron‑PPTX die gekloond moet worden als parameter mee aan de [AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/methods/addclone/index) methode.
6. Instantieer de [ISlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection) klasse door de referentie naar de Slides‑collectie die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) object van de doelpresentatie in te stellen.
7. Roep de [AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/methods/addclone/index) methode aan die wordt blootgesteld door het [ISlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection) object en geef de te klonen dia uit de bronpresentatie en de masterslide als parameters mee aan de [AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/methods/addclone/index) methode.
8. Schrijf het gewijzigde doel‑presentatie‑bestand weg.

In het onderstaande voorbeeld hebben we een dia met een master (die zich op de nul‑index van de bronpresentatie bevindt) naar het einde van de doelpresentatie gekloond met een master uit de bron‑dia.

```c#
// Instantieer de Presentation-klasse om het bronpresentatiebestand te laden

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Instantieer de Presentation-klasse voor de bestemmingspresentatie (waar de dia gekloond moet worden)
    using (Presentation destPres = new Presentation())
    {

        // Instantieer ISlide uit de verzameling dia's in de bronpresentatie samen met
        // Masterslide
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Kloon de gewenste masterslide van de bronpresentatie naar de verzameling masters in de
        // Doelpresentatie
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Kloon de gewenste masterslide van de bronpresentatie naar de verzameling masters in de
        // Doelpresentatie
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Kloon de gewenste dia van de bronpresentatie met de gewenste master naar het einde van de
        // Verzameling dia's in de bestemmingspresentatie
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Kloon de gewenste masterslide van de bronpresentatie naar de verzameling masters in de // Doelpresentatie
        // Sla de bestemmingspresentatie op naar schijf
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **Kloon een dia aan het einde van een opgegeven sectie**

Met Aspose.Slides voor .NET kun je een dia uit een sectie van een presentatie klonen en die dia in een andere sectie van dezelfde presentatie invoegen. In dit geval moet je de [AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/methods/addclone/index) methode gebruiken van de [ISlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection) interface.

Deze C#‑code toont hoe je een dia kunt klonen en de gekloonde dia in een opgegeven sectie kunt invoegen:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // om te klonen
    
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Veelgestelde vragen**

**Worden spreker‑notities en beoordelingscommentaren gekloond?**

Ja. De notitiepagina en beoordelingscommentaren worden meegenomen in de kloon. Als je ze niet wilt, [verwijder ze](/slides/nl/net/presentation-notes/) na het invoegen.

**Hoe worden grafieken en hun gegevensbronnen behandeld?**

Het grafiekobject, de opmaak en de ingesloten gegevens worden gekopieerd. Als de grafiek gekoppeld was aan een externe bron (bijv. een OLE‑ingesloten werkmap), blijft die koppeling bewaard als een [OLE‑object](/slides/nl/net/manage-ole/). Na het verplaatsen tussen bestanden moet je de beschikbaarheid van de gegevens en het vernieuwingsgedrag verifiëren.

**Kan ik de invoegpositie en secties voor de kloon regelen?**

Ja. Je kunt de kloon invoegen op een specifieke dia‑index en plaatsen in een gekozen [sectie](/slides/nl/net/slide-section/). Als de doel‑sectie nog niet bestaat, maak deze dan eerst aan en verplaats de dia ernaartoe.