---
title: Presentatieweergave-eigenschappen ophalen en bijwerken op Android
linktitle: Weergave-eigenschappen
type: docs
weight: 80
url: /nl/androidjava/presentation-view-properties/
keywords:
- weergave-eigenschappen
- normale weergave
- outline-inhoud
- outline-pictogrammen
- verticale splitter vastklikken
- enkele weergave
- balkstatus
- dimensiegrootte
- automatisch aanpassen
- standaardzoom
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Ontdek Aspose.Slides voor Android via Java-weergave-eigenschappen om PPT-, PPTX- en ODP-dia’s aan te passen—lay-out, zoomniveaus en weergave-instellingen wijzigen."
---
## **Inleiding**

De normale weergave bestaat uit drie inhoudsgebieden: de dia zelf, een zij‑inhoudsgebied en een onderste inhoudsgebied. Eigenschappen met betrekking tot de positionering van de verschillende inhoudsgebieden. Deze informatie stelt de applicatie in staat om de weergavestatus op te slaan in het bestand, zodat bij het opnieuw openen de weergave in dezelfde staat is als toen de presentatie voor het laatst werd opgeslagen.

Methode[IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) is toegevoegd om toegang te bieden tot de normale weergave‑eigenschappen van een presentatie.

De interfaces[INormalViewProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties),[INormalViewRestoredProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewRestoredProperties) en hun afstammelingen, en de enum[SplitterBarStateType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SplitterBarStateType) zijn toegevoegd.

## **Over INormalViewProperties**

Stelt normale weergave‑eigenschappen voor.

Methoden[getShowOutlineIcons](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--)en[setShowOutlineIcons](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean--)geven aan of de applicatie pictogrammen moet weergeven wanneer outline‑inhoud in een van de inhoudsgebieden van de normale weergavemodus wordt getoond.

Methoden[getSnapVerticalSplitter](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--)en[setSnapVerticalSplitter](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean--)geven aan of de verticale scheidingsbalk moet inklappen wanneer het zij‑gebied voldoende klein is.

Eigenschappen[getPreferSingleView](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--)en[setPreferSingleView](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean--)geven aan of de gebruiker de voorkeur geeft aan een enkel‑inhoudsgebied op volledig venster in plaats van de standaard normale weergave met drie inhoudsgebieden. Indien ingeschakeld, kan de applicatie ervoor kiezen om één van de inhoudsgebieden over het volledige venster weer te geven.

Methoden[getVerticalBarState](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--)en[getHorizontalBarState](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--)geven de status op die de horizontale of verticale scheidingsbalk moet hebben. Een horizontale scheidingsbalk scheidt de dia van het inhoudsgebied onder de dia, een verticale scheidingsbalk scheidt de dia van het zij‑inhoudsgebied. Mogelijke waarden zijn:[SplitterBarStateType.Minimized](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SplitterBarStateType#Minimized),[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SplitterBarStateType#Maximized)en[SplitterBarStateType.Restored](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Methoden[getRestoredLeft](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)en[getRestoredTop](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--)specificeren de afmetingen van respectievelijk het boven‑ of zijkant‑dia‑gebied van de normale weergave wanneer[SplitterBarStateType.Restored](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SplitterBarStateType#Restored)waarde is toegepast op[getVerticalBarState](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--)en[getHorizontalBarState](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) dienovereenkomstig.

## **Over het herstellen van INormalViewProperties**

Specificeert de afmetingen van het dia‑gebied (breedte wanneer kind van[getRestoredTop](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), hoogte wanneer kind van[getRestoredLeft](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) van de normale weergave, wanneer het gebied een variabele herstelde grootte heeft (niet ingeklapt noch uitgeklapt).

Methode[getDimensionSize](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--)specificeert de grootte van het dia‑gebied (breedte wanneer kind van restoredTop, hoogte wanneer kind van restoredLeft).

Methode[getAutoAdjust](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--)specificeert of de grootte van het zij‑inhoudsgebied moet compenseren voor de nieuwe grootte bij het aanpassen van de grootte van het venster dat de weergave bevat binnen de applicatie.

Een voorbeeld hieronder toont hoe u de eigenschappen[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--)van een presentatie kunt benaderen.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Herstel de weergave‑eigenschappen van de presentatie
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Standaard zoomwaarde instellen**

{{% alert color="info" %}} 

Aspose.Slides voor Android via Java ondersteunt nu het instellen van de standaard zoomwaarde voor een presentatie, zodat bij het openen van de presentatie de zoom al is ingesteld. Dit kan gedaan worden door de[ViewProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ViewProperties)van een presentatie te configureren.[getSlideViewProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--)en[getNotesViewProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--)kunnen programmeermatig worden ingesteld. In dit onderwerp laten we met een voorbeeld zien hoe de[View Properties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ViewProperties)van een[Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)in Aspose.Slides kunnen worden ingesteld.

{{% /alert %}} 

Om de weergave‑eigenschappen in te stellen, volg de onderstaande stappen:

1. Maak een instantie van de klasse[Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)aan.
1. Stel de[View Properties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ViewProperties)van de[Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)in.
1. Schrijf de presentatie naar een[PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand. In het onderstaande voorbeeld hebben we de zoomwaarde ingesteld voor zowel de dia‑weergave als de notitie‑weergave.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Instellen van de weergave‑eigenschappen van de presentatie
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Zoomwaarde in procenten voor dia‑weergave
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Zoomwaarde in procenten voor notitie‑weergave 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Rasterspatiëring instellen**

Gebruik[Presentation.getViewProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getViewProperties--)om toegang te krijgen tot de weergave‑instellingen voor de gehele presentatie. De methoden[IViewProperties.getGridSpacing](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--)en[IViewProperties.setGridSpacing](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-)lezen of wijzigen het interval van het onderliggende bewerkingsraster. Deze instelling geldt voor de hele presentatie, niet voor een enkele dia. Rasterspatiëring wordt opgegeven in points, waarbij 72 points gelijk zijn aan één inch. Gebruik een positieve waarde, zoals vereist door de API‑documentatie.

Het volgende voorbeeld opent een bestaande `demo.pptx`, print de huidige rasterspatiëring, stelt een kwart‑inch interval in en slaat het resultaat op.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("demo.pptx");
try {
    float gridSpacing = presentation.getViewProperties().getGridSpacing();
    System.out.println("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18f);
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het raster is anders dan[drawing guides](/slides/nl/androidjava/drawing-guides/). Rasterspatiëring bepaalt een regelmatig interval, terwijl tekenlijnen individueel gepositioneerde horizontale of verticale uitlijningslijnen zijn. Het toevoegen, verplaatsen of wissen van tekenlijnen verandert de rasterspatiëring niet.

Zowel het raster als tekenlijnen zijn hulpmiddelen voor bewerken. Ze worden niet gerenderd als dia‑inhoud in PDF, afbeeldingen, SVG of een diavoorstelling. Het opslaan van de rasterspatiëring garandeert niet dat een editor het raster weergeeft: de zichtbaarheid hangt ook af van de voorkeuren van de viewer of editor.

## **Reacties tonen of verbergen bij het openen van een presentatie**

Gebruik[Presentation.getViewProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getViewProperties--)om toegang te krijgen tot de weergave‑instellingen voor de gehele presentatie. Gebruik[IViewProperties.getShowComments](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iviewproperties/#getShowComments--)en[IViewProperties.setShowComments](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-)om de opgeslagen voorkeur te lezen of te wijzigen of reacties getoond moeten worden wanneer de presentatie wordt geopend in PowerPoint of een andere compatibele editor.

Deze instelling bepaalt alleen de opgeslagen weergave‑voorkeur. Ze voegt geen reacties toe, verwijdert ze niet, bewerkt ze niet en lost ze niet op. Het verbergen van reacties behoudt hun inhoud, auteurs, posities, antwoorden en statussen. Zie[Presentation Comments](/slides/nl/androidjava/presentation-comments/) voor bewerkingen die de reacties zelf wijzigen.

Het volgende voorbeeld vereist een bestaande `comments.pptx` met reacties. Het print de huidige zichtbaarheid, vraagt om de reacties te verbergen en slaat een nieuwe PPTX op zonder reacties te verwijderen. Het gebruikt bovendien[IViewProperties.setLastView](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-)met[ViewType.SlideView](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/viewtype/#SlideView)om de initiële bewerkingsweergave naast de reactie‑zichtbaarheid te configureren.

```java
import com.aspose.slides.NullableBool;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation("comments.pptx");
try {
    byte showComments = presentation.getViewProperties().getShowComments();
    System.out.println("Current comment visibility: " + showComments);

    presentation.getViewProperties().setShowComments(NullableBool.False);
    presentation.getViewProperties().setLastView(ViewType.SlideView);
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Deze instelling bepaalt niet of reacties zijn inbegrepen in PDF-, HTML-, afbeelding-, notitie- of handout‑exporten. Configureer de relevante export‑specifieke opties afzonderlijk.

## **FAQ**

**Waarom is het raster niet zichtbaar nadat ik de presentatie opnieuw heb geopend?**

Het bestand slaat de rasterspatiëring op, maar de editor bepaalt of het raster wordt weergegeven. Controleer de raster‑zichtbaarheid instellingen van de editor.

**Verandert het wissen van tekenlijnen de rasterspatiëring?**

Nee. Tekenlijnen en rasterspatiëring zijn onafhankelijke instellingen. Het wissen van tekenlijnen laat het opgeslagen rasterinterval ongewijzigd.

**Kan ik verschillende weergave‑instellingen instellen voor verschillende secties van een presentatie?**

Weergave‑instellingen zijn gedefinieerd op presentatieniveau (Normale weergave/Dia‑weergave), niet per sectie, waardoor één set parameters van toepassing is op het volledige document bij het openen.

**Kan ik verschillende weergave‑toestanden vooraf definiëren voor verschillende gebruikers?**

Nee. De instellingen worden opgeslagen in het bestand en zijn gedeeld. Viewer‑applicaties kunnen gebruikersvoorkeuren respecteren, maar het bestand zelf bevat één set weergave‑eigenschappen.

**Kan ik een sjabloon voorbereiden met vooraf gedefinieerde weergave‑eigenschappen zodat nieuwe presentaties op dezelfde manier openen?**

Ja. Omdat weergave‑eigenschappen worden opgeslagen op presentatieniveau, kun je ze in een sjabloon opnemen en nieuwe documenten hiervan maken met dezelfde initiële weergaveconfiguratie.