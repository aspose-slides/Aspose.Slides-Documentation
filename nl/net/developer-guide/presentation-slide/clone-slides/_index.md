---
title: Presentatiedia's klonen in .NET
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
description: "Dupliceer snel PowerPoint-dia's met Aspose.Slides voor .NET. Volg onze heldere codevoorbeelden om PPT-creatie in enkele seconden te automatiseren en handmatig werk te elimineren."
---
## **Inleiding**

Klonen is het proces waarbij een exacte kopie of replica van iets wordt gemaakt. Aspose.Slides maakt het ook mogelijk om elke dia te kopiëren (klonen) en vervolgens de gekloonde dia in de huidige presentatie of een andere geopende presentatie in te voegen. Dia‑klonen maakt een nieuwe dia aan die ontwikkelaars kunnen aanpassen zonder de originele dia te beïnvloeden. Er zijn verschillende manieren om een dia te klonen:

- Kloon aan het einde van een presentatie.
- Kloon op een andere positie binnen een presentatie.
- Kloon aan het einde van een andere presentatie.
- Kloon op een andere positie in een andere presentatie.
- Kloon samen met zijn mastersdia naar een andere presentatie.

In Aspose.Slides for .NET biedt de dia‑collectie (een verzameling van [ISlide](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/) objecten) die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) object de methoden [AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/addclone/) en [InsertClone](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/insertclone/) om de hierboven beschreven dia‑kloningsbewerkingen uit te voeren.

## **Kloon een Dia aan het Einde van een Presentatie**

Als u een dia wilt klonen en vervolgens gebruiken in hetzelfde presentatiebestand aan het einde van de bestaande dia's, gebruikt u de [AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/methods/addclone/index) methode volgens de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.  
1. Instantieser de [ISlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection) klasse door te verwijzen naar de Slides‑collectie die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) object.  
1. Roep de [AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/methods/addclone/index) methode aan die wordt blootgesteld door het [ISlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection) object en geef de te klonen dia als parameter door aan de [AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/methods/addclone/index) methode.  
1. Schrijf het gewijzigde presentatie‑bestand weg.

In het onderstaande voorbeeld hebben we een dia (die zich op de eerste positie – nul‑index – van de presentatie bevindt) gekloond naar het einde van de presentatie.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Maak een instantie van de Presentation-klasse die een presentatiebestand voorstelt
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // Kloon de gewenste dia naar het einde van de collectie dia's in dezelfde presentatie
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // Schrijf de gewijzigde presentatie naar schijf
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```

## **Kloon een Dia naar een Andere Positie binnen een Presentatie**

Als u een dia wilt klonen en vervolgens gebruiken in hetzelfde presentatiebestand, maar op een andere positie, gebruikt u de [InsertClone](https://reference.aspose.com/slides/nl/net/aspose.slides.ishapecollection/insertclone/methods/1) methode:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.  
1. Instantieser de klasse door te verwijzen naar de **Slides**‑collectie die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) object.  
1. Roep de [InsertClone](https://reference.aspose.com/slides/nl/net/aspose.slides.ishapecollection/insertclone/methods/1) methode aan die wordt blootgesteld door het [ISlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection) object en geef de te klonen dia samen met de index voor de nieuwe positie door als parameter aan de [InsertClone](https://reference.aspose.com/slides/nl/net/aspose.slides.ishapecollection/insertclone/methods/1) methode.  
1. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een dia (die zich op index 1 – positie 2 – van de presentatie bevindt) gekloond naar index 2 – positie 3 – van de presentatie.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Maak een instantie van de Presentation-klasse die een presentatiebestand voorstelt
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // Kloon de gewenste dia naar het einde van de collectie dia's in dezelfde presentatie
    ISlideCollection slds = pres.Slides;

    // Kloon de gewenste dia naar de opgegeven index in dezelfde presentatie
    slds.InsertClone(2, pres.Slides[1]);

    // Schrijf de gewijzigde presentatie naar schijf
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **Kloon een Dia aan het Einde van een Andere Presentatie**

Als u een dia van de ene presentatie wilt klonen en in een ander presentatiebestand wilt gebruiken, aan het einde van de bestaande dia's:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse die de presentatie bevat waaruit de dia wordt gekloond.  
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse die de doelpresentatie bevat waar de dia aan wordt toegevoegd.  
1. Instantieser de [ISlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection) klasse door te verwijzen naar de **Slides**‑collectie die wordt blootgesteld door het Presentation‑object van de doelpresentatie.  
1. Roep de [AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/methods/addclone/index) methode aan die wordt blootgesteld door het [ISlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection) object en geef de dia uit de bronpresentatie als parameter door aan de [AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/methods/addclone/index) methode.  
1. Schrijf het gewijzigde doelpresentatie‑bestand weg.

In het onderstaande voorbeeld hebben we een dia (van de eerste index van de bronpresentatie) gekloond naar het einde van de doelpresentatie.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Maak een instantie van de Presentation-klasse om het bronpresentatiebestand te laden
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Maak een instantie van de Presentation-klasse voor de doel-PPTX (waar de dia gekloond moet worden)
    using (Presentation destPres = new Presentation())
    {
        // Kloon de gewenste dia van de bronpresentatie naar het einde van de collectie dia's in de doelpresentatie
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // Schrijf de doelpresentatie naar schijf
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Kloon een Dia naar een Andere Positie in een Andere Presentatie**

Als u een dia van de ene presentatie wilt klonen en in een ander presentatiebestand wilt gebruiken, op een specifieke positie:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse die de bronpresentatie bevat waaruit de dia wordt gekloond.  
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse die de presentatie bevat waaraan de dia wordt toegevoegd.  
1. Instantieser de [ISlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection) klasse door te verwijzen naar de Slides‑collectie die wordt blootgesteld door het Presentation‑object van de doelpresentatie.  
1. Roep de [InsertClone](https://reference.aspose.com/slides/nl/net/aspose.slides.ishapecollection/insertclone/methods/1) methode aan die wordt blootgesteld door het [ISlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection) object en geef de dia uit de bronpresentatie samen met de gewenste positie door als parameter aan de [InsertClone](https://reference.aspose.com/slides/nl/net/aspose.slides.ishapecollection/insertclone/methods/1) methode.  
1. Schrijf het gewijzigde doelpresentatie‑bestand weg.

In het onderstaande voorbeeld hebben we een dia (van de nul‑index van de bronpresentatie) gekloond naar index 1 (positie 2) van de doelpresentatie.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantieer de Presentation-klasse om het bronpresentatiebestand te laden
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Instantieer de Presentation-klasse voor de doel-PPTX (waar de dia moet worden gekloond)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // Schrijf de doelpresentatie naar schijf
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Kloon een Dia met Zijn Mastersdia naar een Andere Presentatie**

Als u een dia met een mastersdia van een presentatie wilt klonen en in een andere presentatie wilt gebruiken, moet u eerst de gewenste mastersdia van de bronpresentatie naar de doelpresentatie klonen. Vervolgens moet u die mastersdia gebruiken om de dia met mastersdia te klonen. De **AddClone(ISlide, IMasterSlide)** verwacht een mastersdia uit de doelpresentatie in plaats van uit de bronpresentatie. Volg de onderstaande stappen om een dia met een master te klonen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse die de bronpresentatie bevat waaruit de dia wordt gekloond.  
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse die de doelpresentatie bevat waar de dia naartoe wordt gekloond.  
1. Toegang tot de te klonen dia samen met de mastersdia.  
1. Instantieser de [IMasterSlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslidecollection) klasse door te verwijzen naar de Masters‑collectie die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) object van de doelpresentatie.  
1. Roep de [AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/methods/addclone/index) methode aan die wordt blootgesteld door het [IMasterSlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslidecollection) object en geef de mastersdia uit de bron‑PPTX die gekloond moet worden als parameter door aan de [AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/methods/addclone/index) methode.  
1. Instantieser de [ISlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection) klasse door de referentie naar de Slides‑collectie die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) object van de doelpresentatie in te stellen.  
1. Roep de [AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/methods/addclone/index) methode aan die wordt blootgesteld door het [ISlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection) object en geef de te klonen dia uit de bronpresentatie en de mastersdia als parameters door aan de [AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/methods/addclone/index) methode.  
1. Schrijf het gewijzigde doelpresentatie‑bestand weg.

In het onderstaande voorbeeld hebben we een dia met een master (die zich op de nul‑index van de bronpresentatie bevindt) gekloond naar het einde van de doelpresentatie met gebruik van een master uit de bron‑dia.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantieer de Presentation-klasse om het bronpresentatiebestand te laden

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Instantieer de Presentation-klasse voor de doelpresentatie (waar de dia moet worden gekloond)
    using (Presentation destPres = new Presentation())
    {

        // Instantieer ISlide uit de collectie dia's in de bronpresentatie samen met
        // Mastersdia
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Kloon de gewenste mastersdia van de bronpresentatie naar de verzameling masters in de
        // Doelpresentatie
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Kloon de gewenste mastersdia van de bronpresentatie naar de verzameling masters in de
        // Doelpresentatie
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Kloon de gewenste dia van de bronpresentatie met de gewenste master naar het einde van de
        // Collectie dia's in de doelpresentatie
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Kloon de gewenste mastersdia van de bronpresentatie naar de verzameling masters in de // Doelpresentatie
        // Sla de doelpresentatie op naar schijf
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **Kloon een Dia aan het Einde van een Gespecificeerde Sectie**

Met Aspose.Slides for .NET kunt u een dia uit een sectie van een presentatie klonen en die dia in een andere sectie van dezelfde presentatie invoegen. In dit geval moet u de [AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection/methods/addclone/index) methode van de [ISlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection) interface gebruiken.

Deze C#‑code laat zien hoe u een dia kunt klonen en de gekloonde dia in een gespecificeerde sectie kunt invoegen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Zorg voor Gelijke Dia‑Grootte**

Wanneer u dia's in een andere presentatie kloont, zorg er dan voor dat de doelpresentatie dezelfde dia‑grootte heeft als de bron. Als de dia‑groottes verschillen, schaalt Aspose.Slides de gekloonde vormen niet automatisch – hun oorspronkelijke coördinaten en afmetingen blijven behouden, wat kan leiden tot een scheve weergave of dat de inhoud buiten de dia‑randen treedt.

U kunt de dia‑grootte van de doelpresentatie instellen zodat deze overeenkomt met die van de bron vóór het klonen van de master en de dia:

```cs
SizeF sourceSize = sourcePresentation.SlideSize.Size;

targetPresentation.SlideSize.SetSize(
    sourceSize.Width, sourceSize.Height, SlideSizeScaleType.DoNotScale);
```

Doe dit vóór het klonen van de master en de dia.

## **FAQ**

**Worden presentatienotities en beoordelingscommentaren gekloond?**

Ja. De notitiepagina en beoordelingscommentaren zijn onderdeel van de kloon. Als u ze niet wilt, [verwijder ze](/slides/nl/net/presentation-notes/) na het invoegen.

**Hoe worden grafieken en hun gegevensbronnen behandeld?**

Het grafiekobject, de opmaak en de ingesloten gegevens worden gekopieerd. Als de grafiek gekoppeld was aan een externe bron (bijv. een OLE‑ingesloten werkmap), blijft die koppeling behouden als een [OLE‑object](/slides/nl/net/manage-ole/). Controleer na het verplaatsen tussen bestanden de beschikbaarheid van de gegevens en het vernieuwingsgedrag.

**Kan ik de invoegpositie en secties voor de kloon bepalen?**

Ja. U kunt de kloon invoegen op een specifieke dia‑index en plaatsen in een gekozen [sectie](/slides/nl/net/slide-section/). Als de doel‑sectie nog niet bestaat, maakt u deze eerst aan en verplaatst u vervolgens de dia ernaar.