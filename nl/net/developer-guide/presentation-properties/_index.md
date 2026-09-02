---
title: Beheer presentatie‑eigenschappen in .NET
linktitle: Presentatie‑eigenschappen
type: docs
weight: 70
url: /nl/net/presentation-properties/
keywords:
- PowerPoint‑eigenschappen
- presentatie‑eigenschappen
- documenteigenschappen
- standaard‑eigenschappen
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
description: "Beheer presentatie‑eigenschappen in Aspose.Slides voor .NET en optimaliseer zoeken, branding en workflow in uw PowerPoint‑ en OpenDocument‑bestanden."
---
## **Inleiding**

Aspose.Slides for .NET ondersteunt twee soorten documenteigenschappen: **Built-in** en **Custom**. Beide soorten eigenschappen kunnen eenvoudig worden benaderd en beheerd met de Aspose.Slides for .NET API.

Aspose.Slides stelt u in staat om met presentatie‑documenteigenschappen te werken via de [IDocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/) interface. Een instantie van deze interface wordt geretourneerd door de [Presentation.DocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/documentproperties/) eigenschap. De volgende voorbeelden laten zien hoe u deze eigenschappen kunt lezen, wijzigen en beheren.

{{% alert color="info" title="Note" %}}
Houd er rekening mee dat de velden **Application** en **Producer** niet kunnen worden gewijzigd, omdat deze velden altijd "Aspose Ltd." en "Aspose.Slides for .NET x.x.x" weergeven.
{{% /alert %}} 

## **Beheer Presentatie‑eigenschappen**

Microsoft PowerPoint biedt een functie om eigenschappen toe te voegen aan presentatiebestanden. Deze documenteigenschappen maken het mogelijk nuttige informatie op te slaan bij de bestanden. Er zijn twee soorten documenteigenschappen:

- Systeem‑gedefinieerde (built-in) eigenschappen
- Gebruiker‑gedefinieerde (custom) eigenschappen

**Built-in** eigenschappen bevatten algemene informatie over het document, zoals de documenttitel, de naam van de auteur, documentstatistieken en meer.

**Custom** eigenschappen worden door gebruikers gedefinieerd als **Naam/Waarde**‑paren, waarbij zowel de naam als de waarde door de gebruiker worden opgegeven.

Met Aspose.Slides for .NET kunnen ontwikkelaars zowel built-in als custom eigenschappen benaderen en wijzigen.

Microsoft PowerPoint stelt gebruikers in staat documenteigenschappen te beheren door op het Office‑pictogram te klikken en vervolgens **Bestand → Info → Eigenschappen** te selecteren. Na het kiezen van **Geavanceerde eigenschappen** verschijnt een dialoogvenster waarin u alle documenteigenschappen van het presentatie‑bestand kunt beheren.

In het dialoogvenster **Properties** staan verschillende tabbladen, zoals **General**, **Summary**, **Statistics**, **Contents**, en **Custom**. Elk tabblad biedt opties om specifieke soorten informatie met betrekking tot het PowerPoint‑bestand te configureren. Het tabblad **Custom** wordt gebruikt om gebruikers‑gedefinieerde eigenschappen te beheren.

## **Toegang tot Built-in eigenschappen**

Deze eigenschappen, zoals aangeboden door de [IDocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/) interface, omvatten: **Creator** (Auteur), **Description**, **Keywords**, **Created** (Aanmaakdatum), **Modified** (Wijzigingsdatum), **Printed** (Datum laatste afdruk), **LastModifiedBy**, **SharedDoc** (geeft aan of het document gedeeld wordt tussen verschillende producenten), **PresentationFormat**, **Subject**, **Title**, en meer.

```cs
using Aspose.Slides;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Haal een referentie op naar het object van het type IDocumentProperties dat bij de presentatie hoort.
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

## **Wijzigen van Built-in‑eigenschappen**

Het wijzigen van de built-in‑eigenschappen van presentatiebestanden is net zo eenvoudig als ze benaderen. U kunt eenvoudig een tekenreeks toewijzen aan elke gewenste eigenschap, waarna de waarde van de eigenschap wordt bijgewerkt. In het onderstaande voorbeeld laten we zien hoe u de built-in‑documenteigenschappen van een presentatiebestand wijzigt.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Haal een referentie op naar het object van het type IDocumentProperties dat bij de presentatie hoort.
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

## **Aangepaste presentatieweigenschappen toevoegen**

Aangepaste presentatieweigenschappen stellen ontwikkelaars in staat om extra metadata of specifieke informatie in een presentatiebestand op te slaan. Aspose.Slides maakt het eenvoudig om deze custom eigenschappen programmatisch te creëren en te beheren. De volgende voorbeelden tonen hoe u custom eigenschappen aan uw presentaties kunt toevoegen.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantieer de Presentation-klasse.
using Presentation presentation = new Presentation();

// Haal een referentie op naar het object van het type IDocumentProperties dat bij de presentatie hoort.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Voeg aangepaste eigenschappen toe.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Sla de presentatie op in een bestand.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Toegang tot en wijzigen van Custom‑eigenschappen**

Aspose.Slides stelt ontwikkelaars bovendien in staat om bestaande custom‑eigenschappen te benaderen en hun waarden eenvoudig te wijzigen. Deze functionaliteit helpt bij het behouden van nauwkeurige metadata en ondersteunt dynamische updates op basis van gebruikersinvoer of bedrijfslogica. De onderstaande voorbeelden illustreren hoe u custom‑eigenschapswaarden binnen een presentatie kunt ophalen en bijwerken.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantieer de Presentation-klasse die een PPTX‑bestand vertegenwoordigt.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Haal een referentie op naar het object van het type IDocumentProperties dat bij de presentatie hoort.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Open en wijzig de aangepaste eigenschappen.
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

## **Veelgestelde vragen**

**Hoe kan ik een built-in eigenschap uit een presentatie verwijderen?**

Built-in eigenschappen maken een integraal onderdeel van de presentatie uit en kunnen niet volledig worden verwijderd. U kunt echter hun waarden wijzigen of, indien toegestaan door de specifieke eigenschap, leegmaken.

**Wat gebeurt er als ik een custom eigenschap toevoeg die al bestaat?**

Als u een custom eigenschap toevoegt die al bestaat, wordt de bestaande waarde overschreven door de nieuwe. U hoeft de eigenschap niet vooraf te verwijderen of te controleren, aangezien Aspose.Slides de waarde van de eigenschap automatisch bijwerkt.

**Kan ik presentatie‑eigenschappen benaderen zonder de presentatie volledig te laden?**

Ja. Gebruik [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/nl/net/aspose.slides/presentationfactory/getpresentationinfo/) en vervolgens [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/readdocumentproperties/) om opgeslagen documentmetadata te lezen zonder een [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑instance te maken. Zie [Build a Lightweight Presentation Inventory](/slides/nl/net/examine-presentation/) voor een volledig voorbeeld van rapportage en formaatspecifieke beperkingen.