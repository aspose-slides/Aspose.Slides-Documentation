---
title: Ophalen en bijwerken van presentatieweergave-eigenschappen in C++
linktitle: Weergave-eigenschappen
type: docs
weight: 80
url: /nl/cpp/presentation-view-properties/
keywords:
- weergave-eigenschappen
- normale weergave
- outline-inhoud
- outline-pictogrammen
- snap verticale splitter
- enkele weergave
- balk-status
- dimensiegrootte
- automatisch aanpassen
- standaardzoom
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Ontdek de weergave-eigenschappen van Aspose.Slides voor C++ om PPT-, PPTX- en ODP-dia’s aan te passen—lay-outs, zoomniveaus en weergave-instellingen te wijzigen."
---
## **Inleiding**

De normale weergave bestaat uit drie inhoudsgebieden: de dia zelf, een zij‑inhoudsgebied en een onder‑inhoudsgebied. Eigenschappen die betrekking hebben op de positionering van de verschillende inhoudsgebieden. Deze informatie stelt de applicatie in staat om zijn weergavetoestand op te slaan in het bestand, zodat bij het opnieuw openen de weergave zich in dezelfde toestand bevindt als toen de presentatie voor het laatst werd opgeslagen.

Methode [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) is toegevoegd om toegang te bieden tot de normale weergave‑eigenschappen van een presentatie. 

De interfaces [INormalViewProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/inormalviewrestoredproperties/) en hun afgeleiden, evenals de enumeratie [SplitterBarStateType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/splitterbarstatetype/) zijn toegevoegd.

## **Over INormalViewProperties**

Stelt de normale weergave‑eigenschappen voor.

Eigenschap **ShowOutlineIcons** geeft aan of de applicatie pictogrammen moet weergeven bij het tonen van de outline‑inhoud in een van de inhoudsgebieden van de normale weergavemodus.

Eigenschap **SnapVerticalSplitter** geeft aan of de verticale splitter moet ‘snapen’ naar een geminimaliseerde toestand wanneer het zijgebied voldoende klein is.

Eigenschap **PreferSingleView** geeft aan of de gebruiker de voorkeur geeft aan één volledig venster‑inhoudsgebied in plaats van de standaard normale weergave met drie inhoudsgebieden. Indien ingeschakeld, kan de applicatie ervoor kiezen om een van de inhoudsgebieden in het gehele venster weer te geven.

De eigenschappen **VerticalBarState** en **HorizontalBarState** geven de toestand aan waarin de horizontale of verticale splitterbalk moet worden weergegeven. Een horizontale splitterbalk scheidt de dia van het inhoudsgebied onder de dia, een verticale splitterbalk scheidt de dia van het zij‑inhoudsgebied. Mogelijke waarden zijn: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** en **SplitterBarStateType.Restored**.

De eigenschappen **RestoredLeft** en **RestoredTop** bepalen de grootte van respectievelijk het boven‑ of zij‑dia‑gebied van de normale weergave, wanneer de waarde **SplitterBarStateType.Restored** wordt toegepast op **VerticalBarState** en **HorizontalBarState**.

## **Over het herstellen van INormalViewProperties**

Bepaalt de afmetingen van het dia‑gebied (breedte wanneer het een kind is van RestoredTop, hoogte wanneer het een kind is van RestoredLeft) van de normale weergave, wanneer het gebied een variabele herstelde grootte heeft (noch geminimaliseerd noch gemaximaliseerd). 

Eigenschap **DimensionSize** geeft de grootte van het dia‑gebied aan (breedte wanneer een kind van RestoredTop, hoogte wanneer een kind van RestoredLeft).

Eigenschap **AutoAdjust** geeft aan of de grootte van het zij‑inhoudsgebied moet worden aangepast aan de nieuwe grootte bij het wijzigen van het venster dat de weergave binnen de applicatie bevat.

Een voorbeeld hieronder toont hoe je toegang krijgt tot de **ViewProperties.NormalViewProperties**‑eigenschappen van een presentatie.

``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// Herstel de weergave-eigenschappen van de presentatie
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Standaardzoomwaarde instellen**

Aspose.Slides voor C++ ondersteunt nu het instellen van de standaard zoom‑waarde voor een presentatie, zodat bij het openen van de presentatie de zoom al is ingesteld. Dit kan worden gedaan door de [ViewProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/viewproperties/) van een presentatie in te stellen. Zowel de dia‑weergave‑eigenschappen als [get_NotesViewProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/viewproperties/get_notesviewproperties/) kunnen programmatisch worden ingesteld. In dit onderwerp laten we met een voorbeeld zien hoe je de weergave‑eigenschappen van een presentatie in Aspose.Slides kunt instellen.

Om de weergave‑eigenschappen in te stellen, volg de onderstaande stappen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)  
2. Stel de weergave‑[Properties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/viewproperties/) van de presentatie in  
3. Schrijf de presentatie weg als een PPTX‑bestand  

In het onderstaande voorbeeld hebben we de zoom‑waarde ingesteld voor zowel de dia‑weergave als de notitie‑weergave.

``` cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Instellen van de weergave‑eigenschappen van de presentatie
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Zoomwaarde in percentages voor dia‑weergave
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Zoomwaarde in percentages voor notitie‑weergave 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Kan ik verschillende weergave‑instellingen definiëren voor verschillende secties van een presentatie?**

[View settings](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_viewproperties/) zijn gedefinieerd op presentatieniveau ([Normal View](https://reference.aspose.com/slides/nl/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/nl/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), niet per sectie, dus één set parameters geldt voor het volledige document bij het openen.

**Kan ik verschillende weergave‑staten vooraf definiëren voor verschillende gebruikers?**

Nee. De instellingen worden in het bestand opgeslagen en gedeeld. Viewer‑applicaties kunnen de voorkeuren van de gebruiker respecteren, maar het bestand zelf bevat één set weergave‑eigenschappen.

**Kan ik een sjabloon voorbereiden met vooraf gedefinieerde weergave‑eigenschappen zodat nieuwe presentaties op dezelfde manier openen?**

Ja. Omdat [view properties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_viewproperties/) op presentatieniveau worden opgeslagen, kun je ze in een sjabloon opnemen en nieuwe documenten hiervan maken met dezelfde initiële weergave‑configuratie.