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
description: "Beheer presentatie-eigenschappen in Aspose.Slides voor .NET en stroomlijn zoeken, branding en workflow in uw PowerPoint- en OpenDocument-bestanden."
---
## **Inleiding**

Aspose.Slides for .NET ondersteunt twee soorten documenteigenschappen: **Ingebouwde** en **Aangepaste**. Beide typen eigenschappen kunnen eenvoudig worden geraadpleegd en beheerd met de Aspose.Slides for .NET‑API.

Aspose.Slides stelt u in staat om met presentatie‑documenteigenschappen te werken via de [IDocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/) interface. Een instantie van deze interface wordt geretourneerd door [IPresentation.DocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentation/documentproperties/). De volgende voorbeelden laten zien hoe u deze eigenschappen kunt lezen, wijzigen en beheren.

{{% alert color="info" title="Opmerking" %}}
Let op: de velden **Application** en **Producer** kunnen niet worden aangepast, want deze velden tonen altijd “Aspose Ltd.” en “Aspose.Slides for .NET x.x.x”.
{{% /alert %}} 

## **Beheer Presentatie‑eigenschappen**

Microsoft PowerPoint biedt een functie om eigenschappen toe te voegen aan presentatie‑bestanden. Deze documenteigenschappen maken het mogelijk om nuttige informatie samen met de bestanden op te slaan. Er zijn twee soorten documenteigenschappen:

- Systeem‑gedefinieerde (inge­bouwde) eigenschappen
- Gebruiker‑gedefinieerde (aangepaste) eigenschappen

**Ingebouwde** eigenschappen bevatten algemene informatie over het document, zoals de titel, de naam van de auteur, statistieken van het document, enzovoort.

**Aangepaste** eigenschappen worden door gebruikers gedefinieerd als **Naam/Waarde**‑paren, waarbij zowel de naam als de waarde door de gebruiker worden opgegeven.

Met Aspose.Slides for .NET kunnen ontwikkelaars zowel ingebouwde als aangepaste eigenschappen benaderen en wijzigen.

Microsoft PowerPoint stelt gebruikers in staat documenteigenschappen te beheren door op het Office‑icoon te klikken, vervolgens **File → Info → Properties** te selecteren. Na het kiezen van **Advanced Properties** verschijnt een dialoogvenster waarin u alle documenteigenschappen van het presentatie‑bestand kunt beheren.

In het dialoogvenster **Properties** zijn verschillende tabbladen aanwezig, zoals **General**, **Summary**, **Statistics**, **Contents** en **Custom**. Elk tabblad biedt opties voor het configureren van specifieke soorten informatie met betrekking tot het PowerPoint‑bestand. Het tabblad **Custom** wordt gebruikt om door de gebruiker gedefinieerde eigenschappen te beheren.

## **Openbare eigenschappen lezen van een versleutelde presentatie**

Een openings‑wachtwoord beveiligt normaal zowel de inhoud van de presentatie als de documenteigenschappen. Wanneer een presentatie is versleuteld met [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) ingesteld op `false`, blijven de documenteigenschappen openbaar. Een applicatie kan dan [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) op `true` zetten en de openbare metadata lezen zonder het openings‑wachtwoord op te geven.

`OnlyLoadDocumentProperties` bepaalt wat Aspose.Slides laadt; het ontsleutelt niets. Als de eigenschappen in de versleuteling zijn opgenomen, mislukt het laden zonder wachtwoord. Als de presentatie niet versleuteld is, wordt de optie genegeerd en wordt de volledige presentatie geladen.

Het volgende voorbeeld controleert de laadmodus via [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nl/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) en leest vervolgens ingebouwde eigenschappen via [IPresentation.DocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentation/documentproperties/):

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var properties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + properties.Author);
    Console.WriteLine("Title: " + properties.Title);
    Console.WriteLine("Keywords: " + properties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

In deze modus wordt de inhoud van de dia’s niet geladen. Dia’s, masters, layouts, shapes, media en andere presentatie‑objecten zijn niet beschikbaar. Applicaties moeten altijd `IsOnlyDocumentPropertiesLoaded` controleren voordat ze een bewerking uitvoeren die het volledige presentatiemodel vereist.

{{% alert color="warning" title="Beveiliging" %}}
Openbare metadata kan namen van auteurs, titels, onderwerpen, trefwoorden, bedrijfsinformatie, opmerkingen en aangepaste waarden blootleggen. Versleutel gevoelige eigenschappen samen met de presentatie. Laat ze alleen openbaar wanneer indexeer‑, classificatie‑, zoek‑ of document‑beheersystemen een specifieke eis hebben om ze zonder wachtwoord te benaderen.
{{% /alert %}}

## **Eigenschappen bijwerken van een versleutelde presentatie**

Voor een versleuteld PPTX‑bestand is een presentatie die is geladen met `OnlyLoadDocumentProperties` bedoeld om openbare metadata te lezen. Aspose.Slides kan gewijzigde eigenschappen van dat uitsluitend‑metadata‑object niet opslaan, omdat de openbare eigenschappen consistent moeten blijven met de corresponderende gegevens in de versleutelde presentatie. Bijwerken vereist daarom het juiste openings‑wachtwoord en een volledige laadbewerking.

Het volgende voorbeeld opent de presentatie met [LoadOptions.Password](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/password/), werkt openbare ingebouwde eigenschappen bij en slaat het resultaat op. Vervolgens wordt [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/isencrypted/) gebruikt om te verifiëren dat de versleuteling behouden blijft en wordt de openbare metadata zonder wachtwoord opnieuw geopend om de nieuwe waarden te controleren:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

{
    var loadOptions = new LoadOptions { Password = "open_password" };
    using var presentation = new Presentation(inputPath, loadOptions);

    presentation.DocumentProperties.Title = "Updated Product Roadmap";
    presentation.DocumentProperties.Keywords = "roadmap, planning, indexed";
    presentation.Save(outputPath, SaveFormat.Pptx);
}

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(outputPath);
Console.WriteLine("The presentation is encrypted: " + presentationInfo.IsEncrypted);

var metadataLoadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var metadataPresentation = new Presentation(outputPath, metadataLoadOptions);

if (metadataPresentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    Console.WriteLine("Title: " + metadataPresentation.DocumentProperties.Title);
    Console.WriteLine("Keywords: " + metadataPresentation.DocumentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

Als een applicatie niet is toegestaan om de inhoud van de presentatie te ontsleutelen of te laden, moet zij openbare eigenschappen van een versleuteld PPTX‑bestand als alleen‑lezen behandelen.

## **Ingebouwde eigenschappen benaderen**

Deze eigenschappen, zoals blootgelegd door de [IDocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/) interface, omvatten: **Creator** (Auteur), **Description**, **Keywords**, **Created** (Aanmaakdatum), **Modified** (Wijzigingsdatum), **Printed** (Datum laatste afdruk), **LastModifiedBy**, **SharedDoc** (geeft aan of het document gedeeld wordt tussen verschillende producers), **PresentationFormat**, **Subject**, **Title**, en meer.

```cs
using Aspose.Slides;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
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

## **Ingebouwde eigenschappen wijzigen**

Het wijzigen van de ingebouwde eigenschappen van presentaties is net zo eenvoudig als ze benaderen. U kunt eenvoudig een tekenreekswaarde toewijzen aan elke gewenste eigenschap en de waarde wordt bijgewerkt. In het voorbeeld hieronder laten we zien hoe u de ingebouwde documenteigenschappen van een presentatie‑bestand wijzigt.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Verkrijg een referentie naar het object van het type IDocumentProperties dat bij de presentatie hoort.
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

## **Aangepaste presentatie‑eigenschappen toevoegen**

Aangepaste presentatie‑eigenschappen stellen ontwikkelaars in staat extra metadata of specifieke informatie op te slaan binnen een presentatie‑bestand. Aspose.Slides maakt het eenvoudig om deze aangepaste eigenschappen programmatically te creëren en beheren. De volgende voorbeelden tonen hoe u aangepaste eigenschappen aan uw presentaties toevoegt.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantieer de Presentation-klasse.
using Presentation presentation = new Presentation();

// Verkrijg een referentie naar het object van het type IDocumentProperties dat bij de presentatie hoort.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Voeg aangepaste eigenschappen toe.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Sla de presentatie op in een bestand.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Aangepaste eigenschappen benaderen en wijzigen**

Aspose.Slides biedt ontwikkelaars ook de mogelijkheid bestaande aangepaste eigenschappen te benaderen en hun waarden eenvoudig te wijzigen. Deze functionaliteit helpt bij het behouden van nauwkeurige metadata en ondersteunt dynamische updates op basis van gebruikersinvoer of bedrijfslogica. De voorbeelden hieronder illustreren hoe u aangepaste eigenschapswaarden binnen een presentatie kunt ophalen en bijwerken.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantieer de Presentation-klasse die een PPTX‑bestand vertegenwoordigt.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Verkrijg een referentie naar het object van het type IDocumentProperties dat bij de presentatie hoort.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Benader en wijzig de aangepaste eigenschappen.
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

## **Veelgestelde vragen**

**Hoe kan ik een ingebouwde eigenschap uit een presentatie verwijderen?**

Ingebouwde eigenschappen maken een integraal onderdeel van de presentatie uit en kunnen niet volledig worden verwijderd. U kunt echter de waarden wijzigen of, indien toegestaan door de specifieke eigenschap, ze op een lege tekenreeks zetten.

**Wat gebeurt er als ik een aangepaste eigenschap toevoeg die al bestaat?**

Als u een aangepaste eigenschap toevoegt die al aanwezig is, wordt de bestaande waarde overschreven met de nieuwe. Het is niet nodig de eigenschap vooraf te verwijderen of te controleren; Aspose.Slides werkt de waarde automatisch bij.

**Kan ik presentatie‑eigenschappen benaderen zonder de volledige presentatie te laden?**

Ja. Gebruik [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/nl/net/aspose.slides/presentationfactory/getpresentationinfo/) en vervolgens [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/readdocumentproperties/) om opgeslagen documentmetadata te lezen zonder een [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) instantie te creëren. Zie [Build a Lightweight Presentation Inventory](/slides/nl/net/examine-presentation/) voor een volledig rapportage‑voorbeeld en format‑specifieke beperkingen.

**Kan ik openbare eigenschappen van een versleutelde presentatie lezen zonder het openings‑wachtwoord?**

Ja. De presentatie moet versleuteld zijn met `EncryptDocumentProperties` ingesteld op `false`, en moet worden geladen met `OnlyLoadDocumentProperties` ingesteld op `true`.

**Kan ik een versleuteld PPTX‑bestand bijwerken in de modus alleen‑document‑eigenschappen?**

Nee. Publieke en versleutelde eigenschapsdata moeten consistent blijven, dus bijwerken van een versleuteld PPTX‑bestand vereist het volledige laden van de presentatie met het correcte openings‑wachtwoord.