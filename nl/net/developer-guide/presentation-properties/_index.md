---
title: Beheer presentatie-eigenschappen in .NET
linktitle: Presentatie-eigenschappen
type: docs
weight: 70
url: /nl/net/presentation-properties/
keywords:
- PowerPoint-eigenschappen
- presentatie-eigenschappen
- documenteigenschappen
- ingebouwde eigenschappen
- aangepaste eigenschappen
- geavanceerde eigenschappen
- eigenschappen beheren
- eigenschappen wijzigen
- documentmetadata
- metadata bewerken
- proefleestaal
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheers presentatie-eigenschappen in Aspose.Slides voor .NET en optimaliseer zoeken, branding en workflow in uw PowerPoint- en OpenDocument-bestanden."
---
## **Inleiding**

Aspose.Slides voor .NET ondersteunt twee soorten documenteigenschappen: **Ingebouwd** en **Aangepast**. Beide eigenschapstypen kunnen eenvoudig worden benaderd en beheerd via de Aspose.Slides voor .NET API.

Aspose.Slides stelt u in staat om met presentatiedocumenteigenschappen te werken via de [IDocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/) interface. Een instantie van deze interface wordt geretourneerd door de [Presentation.DocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/documentproperties/) eigenschap. De volgende voorbeelden laten zien hoe u deze eigenschappen kunt lezen, wijzigen en beheren.

{{% alert color="primary" %}} 

Houd er rekening mee dat de velden **Application** en **Producer** niet kunnen worden aangepast, want deze velden zullen altijd “Aspose Ltd.” en “Aspose.Slides for .NET x.x.x” weergeven.

{{% /alert %}} 

## **Beheer Presentatie‑eigenschappen**

Microsoft PowerPoint biedt een functie om eigenschappen toe te voegen aan presentatie‑bestanden. Deze documenteigenschappen maken het mogelijk nuttige informatie bij de bestanden op te slaan. Er zijn twee soorten documenteigenschappen:

- Systeem‑gedefinieerde (ingebouwde) eigenschappen
- Door de gebruiker gedefinieerde (aangepaste) eigenschappen

**Ingebouwde** eigenschappen bevatten algemene informatie over het document, zoals de titel van het document, de naam van de auteur, documentstatistieken, enzovoort.

**Aangepaste** eigenschappen worden door gebruikers gedefinieerd als **Naam/Waarde**‑paren, waarbij zowel de naam als de waarde door de gebruiker worden opgegeven.

Met Aspose.Slides voor .NET kunnen ontwikkelaars zowel ingebouwde als aangepaste eigenschappen benaderen en wijzigen.

Microsoft PowerPoint maakt het mogelijk voor gebruikers om documenteigenschappen te beheren door op het Office‑icoon te klikken, vervolgens **Bestand → Info → Eigenschappen** te selecteren. Na het kiezen van **Geavanceerde eigenschappen** verschijnt een dialoogvenster waarin u alle documenteigenschappen van het presentatie‑bestand kunt beheren.

In het dialoogvenster **Eigenschappen** zijn er verschillende tabbladen, zoals **Algemeen**, **Samenvatting**, **Statistieken**, **Inhoud** en **Aangepast**. Elk tabblad biedt opties voor het configureren van specifieke soorten informatie gerelateerd aan het PowerPoint‑bestand. Het tabblad **Aangepast** wordt gebruikt om door de gebruiker gedefinieerde eigenschappen te beheren.

## **Toegang tot Ingebouwde Eigenschappen**

Deze eigenschappen, zoals blootgesteld door de [IDocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/) interface, omvatten: **Creator** (Auteur), **Description**, **Keywords**, **Created** (Aanmaakdatum), **Modified** (Wijzigingsdatum), **Printed** (Datum laatste afdruk), **LastModifiedBy**, **SharedDoc** (geeft aan of het document gedeeld wordt tussen verschillende producenten), **PresentationFormat**, **Subject**, **Title**, en meer.

```cs
// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Krijg een referentie naar het object van het type IDocumentProperties dat aan de presentatie is gekoppeld.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Toon de ingebouwde eigenschappen.
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

## **Wijzigen van Ingebouwde Eigenschappen**

Het wijzigen van de ingebouwde eigenschappen van presentatiebestanden is net zo eenvoudig als ze benaderen. U kunt eenvoudig een tekenreekswaarde toewijzen aan elke gewenste eigenschap, en de waarde van de eigenschap wordt bijgewerkt. In het onderstaande voorbeeld laten we zien hoe u de ingebouwde documenteigenschappen van een presentatiebestand kunt wijzigen.

```cs
// Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Krijg een referentie naar het object van het type IDocumentProperties dat aan de presentatie gekoppeld is.
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

Aangepaste presentatie‑eigenschappen stellen ontwikkelaars in staat extra metadata of specifieke informatie binnen een presentatiebestand op te slaan. Aspose.Slides maakt het eenvoudig om deze aangepaste eigenschappen programmatisch te creëren en te beheren. De volgende voorbeelden demonstreren hoe u aangepaste eigenschappen aan uw presentaties kunt toevoegen.

```cs
// Maak een instantie van de Presentation-klasse.
using Presentation presentation = new Presentation();

// Krijg een referentie naar het object van het type IDocumentProperties dat aan de presentatie gekoppeld is.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Voeg aangepaste eigenschappen toe.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Sla de presentatie op in een bestand.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Toegang tot en Wijzigen van Aangepaste Eigenschappen**

Aspose.Slides stelt ontwikkelaars daarnaast in staat bestaande aangepaste eigenschappen te benaderen en hun waarden eenvoudig te wijzigen. Deze functionaliteit helpt bij het behouden van nauwkeurige metadata en ondersteunt dynamische updates op basis van gebruikersinvoer of bedrijfslogica. De onderstaande voorbeelden illustreren hoe u aangepaste eigenschapswaarden binnen een presentatie kunt ophalen en bijwerken.

```cs
// Maak een instantie van de Presentation-klasse die een PPTX-bestand vertegenwoordigt.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Krijg een referentie naar het object van het type IDocumentProperties dat aan de presentatie gekoppeld is.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Toegang tot en wijzig de aangepaste eigenschappen.
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

Probeer de online app [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/nl/metadata) om te zien hoe u met documenteigenschappen kunt werken via de Aspose.Slides‑API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/nl/metadata)

## ***FAQ**

**Hoe kan ik een ingebouwde eigenschap uit een presentatie verwijderen?**

Ingebouwde eigenschappen maken een integraal onderdeel van de presentatie uit en kunnen niet volledig worden verwijderd. U kunt echter hun waarden wijzigen of, indien de specifieke eigenschap het toestaat, ze leeg maken.

**Wat gebeurt er als ik een aangepaste eigenschap toevoeg die al bestaat?**

Als u een aangepaste eigenschap toevoegt die al bestaat, wordt de bestaande waarde overschreven met de nieuwe. U hoeft de eigenschap niet eerst te verwijderen of te controleren, omdat Aspose.Slides de eigenschapswaarde automatisch bijwerkt.

**Kan ik presentatieweigenschappen benaderen zonder de volledige presentatie te laden?**

Ja, u kunt presentatieweigenschappen benaderen zonder de volledige presentatie te laden door de `GetPresentationInfo`‑methode van de [PresentationFactory](https://reference.aspose.com/slides/nl/net/aspose.slides/presentationfactory/)‑klasse te gebruiken. Gebruik vervolgens de `ReadDocumentProperties`‑methode van de [IPresentationInfo](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/)‑interface om de eigenschappen efficiënt te lezen, waardoor geheugen wordt bespaard en de prestaties verbeteren.