---
title: Automatiseer presentatiepersonalisatie met Mail Merge
linktitle: Mail Merge
type: docs
weight: 233
url: /nl/net/mail-merge/
keywords:
- Mail Merge
- presentatiepersonalisatie
- presentatiesjabloon
- tekstplaatsaanduidingen
- gegevensbron
- CSV
- Excel
- XLSX
- JSON
- XML
- gegevens samenvoegen
- presentaties genereren
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u Mail Merge in Aspose.Slides voor .NET kunt gebruiken om presentatiesjablonen met gegevens te vullen en gepersonaliseerde PowerPoint‑presentaties te genereren vanuit CSV‑, Excel‑, JSON‑ en XML‑bronnen."
---
# Mail Merge in PowerPoint‑presentaties

Aspose.Slides for .NET stelt u in staat om automatisch PowerPoint‑presentaties te genereren met behulp van een sjabloon en een gegevensbron. Mail Merge vult sjabloon‑plaatsaanduidingen met gegevens en maakt ofwel één enkele presentatie met herhaalde sjabloonslides voor elke gegevensset, of een aparte presentatie voor elke gegevensset.

Deze functionaliteit is handig voor het genereren van productcatalogi, gepersonaliseerde presentaties, rapporten, certificaten, voorstellen, prijslijsten en andere documenten waarbij de presentatiestructuur gelijk blijft terwijl de inhoud varieert.

![Mail Merge: voor en na](mail-merge-before-after.png)


## Hoe Mail Merge werkt

Mail Merge gebruikt een PowerPoint‑presentatie als sjabloon en vervangt plaatsaanduidingen door waarden uit een gegevensbron.

![Mail Merge‑werkstroom](mail-merge-workflow.png)

Een plaatsaanduiding is een veldnaam die tussen dubbele accolades staat, zoals `{{title}}` of `{{price}}`. Plaatsaanduidingen kunnen in tekst in vormen, tabelcellen, gegroepeerde vormen en aantekeningen voor de spreker worden geplaatst.

Bijvoorbeeld, een sjabloonslide kan de volgende tekst bevatten:

- `Product: {{title}}`
- `Prijs: {{price}}`
- `Beschrijving: {{description}}`

Wanneer de gegevensbron de volgende waarden bevat:

| Veld | Waarde |
|---|---|
| title | Laptop X1 |
| price | $999 |
| description | 14‑inch display, 16 GB RAM |

Mail Merge vervangt de plaatsaanduidingen door de overeenkomstige waarden en maakt een slide met de daadwerkelijke productinformatie.

Veldnamen zijn niet‑hoofdlettergevoelig, dus `{{title}}` en `{{Title}}` verwijzen naar hetzelfde veld.

De volgende regels zijn van toepassing bij het vervangen van plaatsaanduidingen:

- Plaatsaanduidingen worden vervangen op slides, inclusief gegroepeerde vormen en tabelcellen, en in aantekeningen voor de spreker.
- Plaatsaanduidingen op master‑slides en layout‑slides worden niet vervangen.
- Een plaatsaanduiding waarvan het veld niet aanwezig is in de gegevensset blijft ongewijzigd.
- Een lege veldwaarde vervangt de plaatsaanduiding door een lege tekenreeks.
- De ingevoegde tekst erft de opmaak van het eerste teken van de plaatsaanduiding.
- Waarden mogen geen plaatsaanduidingstekst bevatten, omdat de ingevoegde tekst opnieuw verwerkt kan worden en door een ander veld kan worden vervangen.

De originele sjabloonpresentatie wordt niet aangepast tijdens de merge‑bewerking en moet minstens één slide bevatten.

## Ondersteunde gegevensbronnen

Mail Merge ondersteunt twee manieren om gegevens aan te leveren:

- Maak een gegevensbron programmatisch met behulp van `IMailMergeDataSource`.
- Lees gegevens uit een CSV‑, XLSX‑, JSON‑ of XML‑bestand of -stream.

Het gegevensformaat wordt gedetecteerd op basis van de inhoud, niet op basis van de bestandsextensie. Streams die geen seeking ondersteunen worden eveneens ondersteund.

De gegevensbron moet minstens één gegevensset bevatten. Elke gegevensset vertegenwoordigt één kopie van het sjabloon die wordt ingevuld met zijn waarden.

Als de gegevensinhoud niet wordt herkend als een ondersteund formaat, wordt `NotSupportedException` gegooid. Als de inhoud wordt herkend maar niet voldoet aan de formaatvereisten, wordt `InvalidDataException` gegooid. Het exceptiebericht bevat de locatie van de fout in de gegevens.

### JSON

De JSON‑gegevensbron moet een root‑object bevatten met een `sets`‑array. Elk element van de array vertegenwoordigt een gegevensset en moet een `fields`‑array bevatten. Elk veld moet een `name`‑ en een `value`‑string hebben.

De optionele `version`‑eigenschap moet `"1.0"` zijn, en de optionele `type`‑eigenschap van een veld moet `"text"` zijn. Eigenschapsnamen zijn hoofdlettergevoelig. Onbekende eigenschappen worden genegeerd.

JSON‑gegevens worden gelezen als UTF‑8, of als UTF‑16 wanneer de gegevens beginnen met een byte‑order‑mark (BOM).

Het volgende voorbeeld bevat twee gegevenssets:

```json
{
  "version": "1.0",
  "sets": [
    {
      "fields": [
        { "name": "title", "value": "Laptop X1" },
        { "name": "price", "value": "$999" }
      ]
    },
    {
      "fields": [
        { "name": "title", "value": "Tablet S2" },
        { "name": "price", "value": "$499" }
      ]
    }
  ]
}
```

### XML

De XML‑gegevensbron moet een `template`‑root‑element hebben dat het `sets`‑element bevat. Elk `set`‑element bevat `field`‑elementen, en elk veld moet `name`‑ en `value`‑elementen bevatten.

Een leeg `value`‑element wordt behandeld als een lege tekenreeks. Elementnamen zijn hoofdlettergevoelig. Onbekende elementen en commentaren worden genegeerd. De codering wordt bepaald door de XML‑declaratie. Documenttype‑definities (DTD) zijn niet toegestaan.

```xml
<?xml version="1.0" encoding="utf-8"?>
<template>
  <sets>
    <set>
      <field>
        <name>title</name>
        <value>Laptop X1</value>
      </field>
      <field>
        <name>price</name>
        <value>$999</value>
      </field>
    </set>
    <set>
      <field>
        <name>title</name>
        <value>Tablet S2</value>
      </field>
      <field>
        <name>price</name>
        <value>$499</value>
      </field>
    </set>
  </sets>
</template>
```

### CSV

CSV‑gegevens gebruiken puntkomma’s als scheidingsteken voor waarden.

De eerste rij bevat veldnamen en eindigt bij de eerste lege veldnaam. Elke volgende rij vertegenwoordigt één gegevensset. Gegevens eindigen bij de eerste lege rij.

De volgende regels zijn van toepassing:

- Ontbrekende waarden aan het einde van een rij worden behandeld als lege tekenreeksen.
- Waarden buiten de gedefinieerde veldnamen worden genegeerd.
- Een waarde die een puntkomma, aanhalingsteken of regelafbreking bevat, moet tussen aanhalingstekens staan.
- Aanhalingstekens binnen een gequote waarde moeten worden verdubbeld.
- Gegevens worden gelezen als UTF‑8, of als UTF‑16 wanneer ze beginnen met een byte‑order‑mark (BOM).

Voorbeeld:

```csv
title;price;description
Laptop X1;$999;"14"" display; 16 GB RAM"
Tablet S2;$499;
```

### XLSX

XLSX‑gegevens worden gelezen uit het eerste werkblad.

Het werkblad volgt dezelfde regels als CSV:

- De eerste rij bevat veldnamen en eindigt bij de eerste lege cel.
- Elke volgende rij vertegenwoordigt één gegevensset.
- Gegevens eindigen bij de eerste lege rij.
- Lege cellen worden behandeld als lege tekenreeksen.
- Numerieke waarden worden geconverteerd naar tekst met behulp van de invariant‑culture.

## Een enkele presentatie maken

De `MergeToSinglePresentation`‑methode maakt één presentatie die een kopie van de sjabloonslides bevat voor elke gegevensset. Elke kopie wordt ingevuld met de bijbehorende gegevens.

De volgorde van de gegevenssets bepaalt de volgorde van de slide‑groepen in de resulterende presentatie.

### Gegevens uit een bestand samenvoegen

Het volgende voorbeeld laadt een sjabloon en een JSON‑gegevensbestand, maakt één presentatie met de slides voor alle gegevenssets en slaat het resultaat op.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, "products.json"))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

De gegevens kunnen ook uit een stream worden gelezen. De stream wordt gelezen vanaf de huidige positie en wordt niet gesloten door de Mail Merge‑bewerking.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Stream data = File.OpenRead("products.xml"))
using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, data))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

### Een gegevensbron in code maken

U kunt een gegevensbron programmatisch bouwen met `MailMergeDataSource` en `MailMergeDataSet`. Voeg een gegevensset toe voor elk record en definieer de velden met de `AddText`‑methode.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet laptop = source.AddDataSet();
laptop.AddText("title", "Laptop X1");
laptop.AddText("price", "$999");

IMailMergeDataSet tablet = source.AddDataSet();
tablet.AddText("title", "Tablet S2");
tablet.AddText("price", "$499");

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, source))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

In dit voorbeeld worden de sjabloonslides twee keer herhaald: één keer voor de laptop en één keer voor de tablet. De plaatsaanduidingen worden ingevuld met de waarden die in elke gegevensset zijn gedefinieerd.

## Meerdere presentaties maken

Als u voor elke gegevensset een aparte presentatie nodig heeft, gebruikt u de `MergeToMultiplePresentations`‑methode.

Deze methode verwerkt de gegevenssets één voor één, maakt een presentatie van het sjabloon, vult deze met de huidige gegevens en geeft de resulterende presentatie door aan een handler.

De handler wordt één keer aangeroepen voor elke gegevensset, in de oorspronkelijke volgorde van de gegevens.

### Elke presentatie opslaan

Het volgende voorbeeld leest gegevens uit een CSV‑bestand en slaat elke gegenereerde presentatie op als een apart bestand.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.csv",
        (presentation, args) =>
        {
            presentation.Save(
                "product_" + (args.Index + 1) + ".pptx",
                SaveFormat.Pptx);
        });
}
```

De eigenschap `args.Index` levert de nulgebaseerde index van de huidige gegevensset. In het voorbeeld wordt deze gebruikt om opeenvolgende bestandsnamen te genereren beginnend bij `product_1.pptx`.

De gegevens kunnen ook uit een stream worden gelezen:

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Stream data = File.OpenRead("products.xlsx"))
using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        data,
        (presentation, args) =>
        {
            presentation.Save(
                "product_" + (args.Index + 1) + ".pptx",
                SaveFormat.Pptx);
        });
}
```

### Gegevensset‑waarden gebruiken voor bestandsnamen

De handler ontvangt zowel de gegenereerde presentatie als informatie over de gegevensset die gebruikt is om deze te maken. U kunt de waarden van de gegevensset gebruiken om betekenisvolle bestandsnamen te bouwen.

Bijvoorbeeld, de volgende code slaat elke presentatie op met de producttitel:

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.json",
        (presentation, args) =>
        {
            string title = args.DataSet.GetText("title");
            string fileName = title != null
                ? title
                : "product_" + (args.Index + 1);

            presentation.Save(fileName + ".pptx", SaveFormat.Pptx);
        });
}
```

De eigenschap `DataSet` retourneert de gegevensset die wordt gebruikt om de huidige presentatie te vullen. De methode `GetText` haalt de waarde van een opgegeven veld op, of `null` als het veld niet bestaat.

Dit maakt het mogelijk om gegevenswaarden te gebruiken voor het benoemen van bestanden, het organiseren van uitvoer, of extra verwerking toe te passen in de handler.

## Verwerkte presentaties afhandelen

`MergeToMultiplePresentations` gebruikt de `MailMergedPresentationHandler`‑delegate om elke gegenereerde presentatie te verwerken.

De handler ontvangt twee argumenten:

- `presentation` — de presentatie die is gemaakt van het sjabloon en is ingevuld met de huidige gegevensset.
- `args` — informatie over de gegenereerde presentatie, inclusief de index van de gegevensset en de gegevensset zelf.

De gegenereerde presentatie behoort toe aan de Mail Merge‑bewerking en wordt direct na het terugkeren van de handler vrijgegeven. Daarom moet u deze opslaan of benodigde gegevens binnen de handler kopiëren. Houd geen referentie naar de presentatie vast nadat de handler heeft geretourneerd en vernietig deze niet handmatig.

De handler wordt uitgevoerd op de aanroepende thread, één presentatie per keer, in de volgorde van de gegevenssets. Er wordt slechts één gegenereerde presentatie tegelijk in het geheugen gehouden, waardoor deze aanpak geschikt is voor het verwerken van grote gegevensbronnen zonder alle gegenereerde presentaties tegelijk in het geheugen te laden.

Als de handler een uitzondering gooit, stopt de Mail Merge‑bewerking en wordt de uitzondering ongewijzigd aan de aanroeper doorgegeven. Presentaties die al zijn verwerkt blijven onaangetast, en de resterende gegevenssets worden niet verwerkt.

Het volgende voorbeeld slaat gegenereerde presentaties op in een speciale map:

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

string outputFolder = "output";
Directory.CreateDirectory(outputFolder);

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.json",
        (presentation, args) =>
        {
            string path = Path.Combine(
                outputFolder,
                "product_" + (args.Index + 1) + ".pptx");

            presentation.Save(path, SaveFormat.Pptx);
        });
}
```

## Werken met Mail Merge‑gegevens

De `MailMergeDataSource`‑klasse vertegenwoordigt een geordende verzameling gegevenssets. Ze kan worden gebruikt om gegevens in code te maken, het aantal gegevenssets te inspecteren en individuele gegevenssets op te vragen via een index.

### Het aantal gegevenssets opvragen

De eigenschap `Count` retourneert het aantal gegevenssets in de bron.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine("Presentations to create: " + source.Count);
```

### Een gegevensset opvragen via index

De eigenschap `Item(int)` biedt toegang tot een gegevensset op de opgegeven nulgebaseerde index.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine(source[1].GetText("title"));
```

Dit voorbeeld haalt de titel op van de tweede gegevensset.

### Tekstvelden toevoegen

De methode `AddText` voegt een benoemd tekstveld toe aan een gegevensset. De veldwaarde vervangt alle overeenkomende plaatsaanduidingen in het sjabloon.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet dataSet = source.AddDataSet();
dataSet.AddText("title", "Laptop X1");
dataSet.AddText("subtitle", string.Empty);
```

Een lege waarde verwijdert de overeenkomstige plaatsaanduiding uit de resulterende tekst. Als het veld niet aan de gegevensset wordt toegevoegd, blijft de plaatsaanduiding ongewijzigd.

### Tekstvelden lezen

De methode `GetText` haalt de waarde van een veld op op basis van de naam. Veldnamen zijn niet‑hoofdlettergevoelig.

```csharp
IMailMergeDataSet dataSet = source[0];

string title = dataSet.GetText("title");
string price = dataSet.GetText("price");
```

Als het veld niet bestaat of de opgegeven veldnaam `null` is, retourneert `GetText` `null`.

## Samenvatting

Mail Merge in Aspose.Slides for .NET biedt een handige manier om gegevensgestuurde presentaties te genereren vanuit een herbruikbaar sjabloon.

U kunt het gebruiken om:

- Presentatiesjablonen te vullen met waarden uit gegevensbronnen.
- Eén presentatie te genereren met herhaalde sjabloonslides voor meerdere gegevenssets.
- Een aparte presentatie te maken voor elke gegevensset.
- Gegevens te lezen uit CSV‑, XLSX‑, JSON‑ en XML‑bestanden of streams.
- Gegevensbronnen direct in code op te bouwen.
- Gegenereerde presentaties opeenvolgend te verwerken en op te slaan met een handler.

Door herbruikbare sjablonen te combineren met gestructureerde gegevens kunt u het maken van een groot aantal presentaties automatiseren terwijl het sjabloonontwerp en de gegevensverwerkingslogica gescheiden blijven.

## Veelgestelde vragen

### Kan ik dezelfde plaatsaanduiding meerdere keren in een sjabloon gebruiken?

Ja. Elke keer dat een plaatsaanduiding met een overeenkomstige veldnaam voorkomt, wordt deze vervangen door de bijbehorende waarde uit de huidige gegevensset.

### Zijn veldnamen hoofdlettergevoelig?

Nee. Plaatsaanduidingen en veldnamen zijn niet‑hoofdlettergevoelig. Bijvoorbeeld `{{title}}`, `{{Title}}` en `{{TITLE}}` verwijzen naar hetzelfde veld.

### Wat gebeurt er als een veld ontbreekt in een gegevensset?

Als de gegevensset geen veld bevat dat door een plaatsaanduiding wordt aangeduid, blijft die plaatsaanduiding ongewijzigd in de gegenereerde presentatie.

### Wat gebeurt er als een veld een lege waarde heeft?

Een lege veldwaarde vervangt de plaatsaanduiding door een lege tekenreeks. De plaatsaanduidingstekst wordt verwijderd, waardoor er geen tekst op die plaats staat.

### Kan ik de opmaak van een plaatsaanduiding behouden bij het vervangen?

De vervangende tekst erft de opmaak van het eerste teken van de plaatsaanduiding. Pas de gewenste opmaak toe op de plaatsaanduiding in het sjabloon voordat u de merge uitvoert.

### Vervangt Mail Merge plaatsaanduidingen op master‑slides of layout‑slides?

Nee. Mail Merge vervangt plaatsaanduidingen alleen in ondersteunde inhoud op presentatieslides, inclusief vormen, gegroepeerde vormen, tabelcellen en aantekeningen voor de spreker. Plaatsaanduidingen op master‑ en layout‑slides worden niet vervangen.

### Wordt de sjabloonpresentatie aangepast tijdens de merge?

Nee. Het originele sjabloon wordt niet gewijzigd door de merge‑bewerking. U kunt het hergebruiken om presentaties te genereren vanuit dezelfde of verschillende gegevensbronnen.

### Kan ik een aparte presentatie genereren voor elke gegevensset?

Ja. Gebruik `MergeToMultiplePresentations` en sla elke gegenereerde presentatie op binnen de handler. De handler wordt opeenvolgend aangeroepen voor elke gegevensset.

### Kan ik alle gegevenssets combineren in één presentatie?

Ja. Gebruik `MergeToSinglePresentation`. Dit maakt één uitvoer‑presentatie die een kopie van de sjabloonslides bevat voor elke gegevensset, in de volgorde van de gegevensbron.

### Kan ik een gegevensbron gebruiken zonder deze op te slaan in een bestand?

Ja. U kunt een `MailMergeDataSource` in code maken, gegevenssets toevoegen en velden invullen met `AddText`. Dit is handig wanneer uw gegevens al beschikbaar zijn in uw applicatie.

### Detecteert Mail Merge het gegevensformaat aan de hand van de bestandsextensie?

Nee. Het gegevensformaat wordt gedetecteerd op basis van de inhoud, zodat een ondersteunde gegevensbron geen specifieke bestandsextensie hoeft te hebben.

### Kan ik gegevens lezen uit een stream die geen seeking ondersteunt?

Ja. Mail Merge ondersteunt non‑seekable streams.

### Wat gebeurt er als de gegevensbron leeg is of geen gegevenssets bevat?

De gegevensbron moet minstens één gegevensset bevatten. Zorg ervoor dat er minimaal één record aanwezig is voordat u de merge‑bewerking start.

### Wat gebeurt er als de gegevensbron een ongeldig formaat heeft?

Als de inhoud niet wordt herkend als een van de ondersteunde formaten, wordt `NotSupportedException` gegooid. Als de inhoud wel wordt herkend maar ongeldige structuur heeft, wordt `InvalidDataException` gegooid. Het exceptiebericht bevat informatie over de locatie van de fout.

### Kan ik de gegenereerde presentatie gebruiken nadat de handler is teruggekeerd?

De presentatie die aan de `MergeToMultiplePresentations`‑handler wordt doorgegeven, behoort toe aan Mail Merge en wordt na het terugkeren van de handler vrijgegeven. Sla deze op of kopieer de benodigde inhoud binnen de handler, en bewaar of vernietig de presentatie niet zelf.

### Wordt de handler parallel aangeroepen?

Nee. Gegenereerde presentaties worden opeenvolgend verwerkt, op de thread van de aanroeper. Er wordt telkens slechts één presentatie in het geheugen gehouden.

### Wat gebeurt er als er een uitzondering optreedt binnen de handler?

De merge‑bewerking stopt en de uitzondering wordt ongewijzigd aan de aanroeper doorgegeven. Presentaties die al verwerkt zijn blijven onaangetast, en de resterende gegevenssets worden niet verwerkt.

### Kan ik veldwaarden gebruiken om bestandsnamen voor de uitvoer te genereren?

Ja. De handler levert de huidige gegevensset via zijn argumenten. Gebruik `GetText` om velden op te halen en bouw een bestandsnaam voor elke gegenereerde presentatie. Zorg ervoor dat de waarden geldig zijn voor bestandsnamen in uw doelomgeving.