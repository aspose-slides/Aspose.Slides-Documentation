---
title: Beheer presentatie‑eigenschappen in .NET
linktitle: Presentatie‑eigenschappen
type: docs
weight: 70
url: /nl/net/presentation-properties/
keywords:
- PowerPoint‑eigenschappen
- presentatie‑eigenschappen
- document‑eigenschappen
- ingebouwde eigenschappen
- aangepaste eigenschappen
- geavanceerde eigenschappen
- eigenschappen beheren
- eigenschappen wijzigen
- documentmetadata
- metadata bewerken
- controletaal
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheer presentatie‑eigenschappen in Aspose.Slides voor .NET en stroomlijn zoeken, branding en workflow in uw PowerPoint‑ en OpenDocument‑bestanden."
---
## **Inleiding**

Aspose.Slides for .NET ondersteunt twee soorten documenteigenschappen: **Ingebouwde** en **Aangepaste**. Beide soorten eigenschappen kunnen gemakkelijk worden benaderd en beheerd met de Aspose.Slides for .NET API.

Aspose.Slides stelt u in staat om met de documenteigenschappen van een presentatie te werken via de [IDocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/) interface. Een instantie van deze interface wordt geretourneerd door de [Presentation.DocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/documentproperties/) eigenschap. De volgende voorbeelden laten zien hoe u deze eigenschappen kunt lezen, wijzigen en beheren.

{{% alert color="info" %}} 
Let op dat de velden **Applicatie** en **Producer** niet kunnen worden gewijzigd, omdat deze velden altijd “Aspose Ltd.” en “Aspose.Slides for .NET x.x.x” weergeven.
{{% /alert %}} 

## **Beheer Presentatie‑eigenschappen**

Microsoft PowerPoint biedt een functie om eigenschappen aan presentatie‑bestanden toe te voegen. Deze documenteigenschappen maken het mogelijk nuttige informatie samen met de bestanden op te slaan. Er zijn twee typen documenteigenschappen:

- Systeem‑gedefinieerde (ingebouwde) eigenschappen
- Gebruiker‑gedefinieerde (aangepaste) eigenschappen

**Ingebouwde** eigenschappen bevatten algemene informatie over het document, zoals de documenttitel, de naam van de auteur, documentstatistieken en meer.

**Aangepaste** eigenschappen worden door gebruikers gedefinieerd als **Naam/Waarde**‑paren, waarbij zowel de naam als de waarde door de gebruiker worden opgegeven.

Met Aspose.Slides for .NET kunnen ontwikkelaars zowel ingebouwde als aangepaste eigenschappen benaderen en wijzigen.

Microsoft PowerPoint maakt het mogelijk om documenteigenschappen te beheren door op het Office‑pictogram te klikken en vervolgens **Bestand → Info → Eigenschappen** te kiezen. Na het selecteren van **Geavanceerde eigenschappen** verschijnt er een dialoogvenster waarin u alle documenteigenschappen van het presentatie‑bestand kunt beheren.

In het dialoogvenster **Eigenschappen** zijn meerdere tabbladen aanwezig, zoals **Algemeen**, **Samenvatting**, **Statistieken**, **Inhoud** en **Aangepast**. Elk tabblad biedt opties om specifieke soorten informatie over het PowerPoint‑bestand te configureren. Het tabblad **Aangepast** wordt gebruikt om door de gebruiker gedefinieerde eigenschappen te beheren.

## **Benader Ingebouwde Eigenschappen**

Deze eigenschappen, zoals blootgelegd door de [IDocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/) interface, omvatten: **Creator** (Auteur), **Description**, **Keywords**, **Created** (Aanmaakdatum), **Modified** (Wijzigingsdatum), **Printed** (Datum laatste afdruk), **LastModifiedBy**, **SharedDoc** (geeft aan of het document wordt gedeeld tussen verschillende producenten), **PresentationFormat**, **Subject**, **Title**, en meer.

```cs
using Aspose.Slides;

// Maak een instantie van de Presentation‑klasse die een presentatie‑bestand vertegenwoordigt.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Display the Built-in properties.
Console.WriteLine("Category : " + documentProperties.Category);
Console.WriteLine("Content status : " + documentProperties.ContentStatus);
Console.WriteLine("Creation date : " + documentProperties.CreatedTime);
Console.WriteLine("Author : " + documentProperties.Author);
Console.WriteLine("Comments : " + documentProperties.Comments);
Console.WriteLine("Key words : " + documentProperties.Keywords);
Console.WriteLine("Last modified by : " + documentProperties.LastSavedBy);
Console.WriteLine("Manager : " + documentProperties.Manager);
Console.WriteLine("Modified date : " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format : " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date : " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers : " + documentProperties.SharedDoc);
Console.WriteLine("Subject : " + documentProperties.Subject);
Console.WriteLine("Title : " + documentProperties.Title);
```

## **Wijzig Ingebouwde Eigenschappen**

Het wijzigen van de ingebouwde eigenschappen van presentatiebestanden is net zo eenvoudig als ze te benaderen. U kunt eenvoudig een tekenreeks toewijzen aan elke gewenste eigenschap, waarna de waarde van die eigenschap wordt bijgewerkt. In het voorbeeld hieronder tonen we hoe u de ingebouwde documenteigenschappen van een presentatiebestand kunt wijzigen.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Maak een instantie van de Presentation‑klasse die een presentatie‑bestand vertegenwoordigt.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Haal een referentie op naar het object van type IDocumentProperties dat bij de presentatie hoort.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Stel de ingebouwde eigenschappen in.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Sla de presentatie op in een bestand.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Aangepaste Presentatie‑eigenschappen Toevoegen**

Aangepaste presentatie‑eigenschappen stellen ontwikkelaars in staat extra metadata of specifieke informatie in een presentatiebestand op te slaan. Aspose.Slides maakt het eenvoudig om deze aangepaste eigenschappen programmatisch te creëren en te beheren. De volgende voorbeelden laten zien hoe u aangepaste eigenschappen aan uw presentaties kunt toevoegen.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantieer de Presentation‑klasse.
using Presentation presentation = new Presentation();

// Haal een referentie op naar het object van type IDocumentProperties dat bij de presentatie hoort.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Voeg aangepaste eigenschappen toe.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Sla de presentatie op in een bestand.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Aangepaste Eigenschappen Benaderen en Wijzigen**

Aspose.Slides maakt het ook mogelijk om bestaande aangepaste eigenschappen te benaderen en hun waarden gemakkelijk te wijzigen. Deze functionaliteit helpt bij het onderhouden van nauwkeurige metadata en ondersteunt dynamische updates op basis van gebruikersinvoer of bedrijfslogica. De voorbeelden hieronder illustreren hoe u aangepaste eigenschapswaarden binnen een presentatie kunt ophalen en bijwerken.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantieer de Presentation‑klasse die een PPTX‑bestand vertegenwoordigt.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Haal een referentie op naar het object van type IDocumentProperties dat bij de presentatie hoort.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Access and modify the custom properties.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // Toon de naam en waarde van de aangepaste eigenschap.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // Wijzig de waarde van de aangepaste eigenschap.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// Sla de presentatie op in een bestand.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Live‑voorbeeld**

Probeer de online app [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/nl/metadata) om te zien hoe u met documenteigenschappen kunt werken via de Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/nl/metadata)

## ***FAQ**

### Hoe kan ik een ingebouwde eigenschap uit een presentatie verwijderen?

Ingebouwde eigenschappen maken een integraal onderdeel van de presentatie uit en kunnen niet volledig worden verwijderd. U kunt echter hun waarden wijzigen of, indien toegestaan door de specifieke eigenschap, ze leegmaken.

### Wat gebeurt er als ik een aangepaste eigenschap toevoeg die al bestaat?

Als u een aangepaste eigenschap toevoegt die al bestaat, wordt de bestaande waarde overschreven met de nieuwe. Het is niet nodig de eigenschap vooraf te verwijderen of te controleren; Aspose.Slides werkt de eigenschapswaarde automatisch bij.

### Kan ik presentatie‑eigenschappen benaderen zonder de volledige presentatie te laden?

Ja, u kunt presentatie‑eigenschappen benaderen zonder de volledige presentatie te laden door gebruik te maken van de `GetPresentationInfo`‑methode van de [PresentationFactory](https://reference.aspose.com/slides/nl/net/aspose.slides/presentationfactory/) klasse. Vervolgens kunt u de `ReadDocumentProperties`‑methode van de [IPresentationInfo](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/) interface gebruiken om de eigenschappen efficiënt uit te lezen, waardoor geheugen wordt bespaard en de prestaties verbeteren.