---
title: Ophalen en bijwerken van presentatieweergave‑eigenschappen in .NET
linktitle: Weergave‑eigenschappen
type: docs
weight: 80
url: /nl/net/presentation-view-properties/
keywords:
- weergave‑eigenschappen
- normale weergave
- outline‑inhoud
- outline‑pictogrammen
- verticale splitter insnappen
- enkele weergave
- balkstatus
- afmetingsgrootte
- automatisch aanpassen
- standaard zoom
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Ontdek de weergave‑eigenschappen van Aspose.Slides voor .NET om PPT-, PPTX- en ODP‑diaformaten aan te passen—indelingen, zoomniveaus en weergave‑instellingen aanpassen."
---
## **Introductie**

De normale weergave bestaat uit drie inhoudsgebieden: de dia zelf, een zijinhoudsgebied en een onderinhoudsgebied. Eigenschappen met betrekking tot de positionering van de verschillende inhoudsgebieden. Deze informatie stelt de applicatie in staat om de weergavetoestand op te slaan in het bestand, zodat bij het opnieuw openen de weergave in dezelfde toestand is als toen de presentatie voor het laatst werd opgeslagen.

Eigenschap [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/iviewproperties/properties/normalviewproperties) is toegevoegd om toegang te bieden tot de normale weergave‑eigenschappen van een presentatie.  

[INormalViewProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/inormalviewrestoredproperties) interfaces en hun afstammelingen, [SplitterBarStateType](https://reference.aspose.com/slides/nl/net/aspose.slides/splitterbarstatetype) enum zijn toegevoegd.

## **Over INormalViewProperties**

Stelt de normale weergave‑eigenschappen voor.

Eigenschap **ShowOutlineIcons** geeft aan of de applicatie pictogrammen moet tonen bij het weergeven van outline‑inhoud in een van de inhoudsgebieden van de normale weergavemodus.

Eigenschap **SnapVerticalSplitter** geeft aan of de verticale splitter naar een geminimaliseerde staat moet springen wanneer het zijgebied voldoende klein is.

Eigenschap **PreferSingleView** geeft aan of de gebruiker de voorkeur geeft aan een volledig‑venster enkel‑inhoudsgebied boven de standaard normale weergave met drie inhoudsgebieden. Indien ingeschakeld, kan de applicatie ervoor kiezen om één van de inhoudsgebieden over het gehele venster weer te geven.

De eigenschappen **VerticalBarState** en **HorizontalBarState** geven de toestand aan waarin de horizontale of verticale splitter‑balk moet worden weergegeven. Een horizontale splitter‑balk scheidt de dia van het inhoudsgebied onder de dia, een verticale splitter‑balk scheidt de dia van het zij‑inhoudsgebied. Mogelijke waarden zijn: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** en **SplitterBarStateType.Restored**.

De eigenschappen **RestoredLeft** en **RestoredTop** geven de afmetingen van respectievelijk het boven‑ of zij‑dia‑gebied van de normale weergave aan, wanneer de waarde **SplitterBarStateType.Restored** wordt toegepast op **VerticalBarState** en **HorizontalBarState**.

## **Over het herstellen van INormalViewProperties**

Bepaalt de afmetingen van het dia‑gebied (breedte wanneer een kind van RestoredTop, hoogte wanneer een kind van RestoredLeft) van de normale weergave, wanneer het gebied een variabel hersteld formaat heeft (niet geminimaliseerd of gemaximaliseerd).  

Eigenschap **DimensionSize** geeft de grootte van het dia‑gebied aan (breedte wanneer een kind van RestoredTop, hoogte wanneer een kind van RestoredLeft).

Eigenschap **AutoAdjust** geeft aan of de grootte van het zij‑inhoudsgebied moet worden aangepast aan de nieuwe grootte bij het aanpassen van het venster dat de weergave bevat binnen de applicatie.

Een voorbeeld hieronder laat zien hoe u toegang kunt krijgen tot de eigenschappen **ViewProperties.NormalViewProperties** van een presentatie.

```c#
using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // Herstel de weergave‑eigenschappen van de presentatie
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **Stel de standaard zoomwaarde in**

Aspose.Slides voor .NET ondersteunt nu het instellen van de standaard zoomwaarde voor een presentatie, zodat bij het openen van de presentatie de zoom al ingesteld is. Dit kan worden gedaan door de ViewProperties van een presentatie in te stellen. Slide View Properties en [NotesViewProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/viewproperties/properties/notesviewproperties) kunnen programmeermatig worden ingesteld. In dit onderwerp laten we met een voorbeeld zien hoe u de weergave‑eigenschappen van een presentatie kunt instellen in Aspose.Slides.

Om de weergave‑eigenschappen in te stellen, volgt u de onderstaande stappen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)
1. Stel de View [Properties](https://reference.aspose.com/slides/nl/net/aspose.slides/viewproperties) van de presentatie in
1. Schrijf de presentatie weg als een PPTX‑bestand

In het onderstaande voorbeeld hebben we de zoomwaarde ingesteld voor zowel de dia‑weergave als de notitie‑weergave.

```c#
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Instellen van de weergave‑eigenschappen van de presentatie
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Zoomwaarde in procenten voor dia‑weergave
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Zoomwaarde in procenten voor notitie‑weergave 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Kan ik verschillende weergave‑instellingen instellen voor verschillende secties van een presentatie?**

Instellingen voor weergave zijn gedefinieerd op presentatieniveau (Normal View/Slide View) en niet per sectie, dus één set parameters geldt voor het gehele document bij het openen.

**Kan ik verschillende weergave‑statussen vooraf definiëren voor verschillende gebruikers?**

Nee. De instellingen worden opgeslagen in het bestand en zijn gedeeld. Viewer‑applicaties kunnen de gebruikersvoorkeuren respecteren, maar het bestand zelf bevat één set weergave‑eigenschappen.

**Kan ik een sjabloon met vooraf gedefinieerde weergave‑eigenschappen maken zodat nieuwe presentaties op dezelfde manier openen?**

Ja. Omdat weergave‑eigenschappen worden opgeslagen op presentatieniveau, kunt u ze in een sjabloon opnemen en nieuwe documenten daarvan maken met dezelfde initiële weergave‑configuratie.