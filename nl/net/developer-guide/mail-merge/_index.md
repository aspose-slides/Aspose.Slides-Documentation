---
title: Automatiseer personalisatie van presentaties met Mail Merge
linktitle: Mail Merge
type: docs
weight: 233
url: /nl/net/mail-merge/
keywords:
- Mail Merge
- presentatiepersonalizatie
- presentatiesjabloon
- tekstplaatsaanduidingen
- gegevensbron
- CSV
- Excel
- XLSX
- JSON
- XML
- samengevoegde gegevens
- presentaties genereren
- .NET
- C#
- Aspose.Slides
description: "Leer hoe je Mail Merge in Aspose.Slides voor .NET kunt gebruiken om presentatiesjablonen te vullen met gegevens en gepersonaliseerde PowerPoint‑presentaties te genereren vanuit CSV-, Excel-, JSON- en XML‑bronnen."
---
## **Mail Merge in PowerPoint‑presentaties**

Aspose.Slides for .NET stelt je in staat om automatisch PowerPoint‑presentaties te genereren met behulp van een sjabloon en een gegevensbron. Mail Merge vult sjabloonplaatsaanduidingen met data en maakt ofwel één presentatie met herhaalde sjabloonslides voor elke gegevensset, of een aparte presentatie voor elke gegevensset.

Deze functionaliteit is nuttig voor het genereren van productcatalogi, gepersonaliseerde presentaties, rapporten, certificaten, voorstellen, prijslijsten en andere documenten waarbij de presentatiestructuur gelijk blijft terwijl de inhoud varieert.

![Mail Merge: voor en na](mail-merge-before-after.png)


## **Hoe Mail Merge werkt**

Mail Merge gebruikt een PowerPoint‑presentatie als sjabloon en vervangt plaatsaanduidingen door waarden uit een gegevensbron.

![Mail Merge-werkstroom](mail-merge-workflow.png)

Een plaatsaanduiding is een veldnaam tussen dubbele accolades, zoals `{{title}}` of `{{price}}`. Plaatsaanduidingen kunnen in tekst van vormen, tabelcellen, gegroepeerde vormen en notities van de spreker worden geplaatst.

Bijvoorbeeld kan een sjabloonslide de volgende tekst bevatten:

- `Product: {{title}}`
- `Prijs: {{price}}`
- `Beschrijving: {{description}}`

Wanneer de gegevensbron de volgende waarden bevat:

| Veld | Waarde |
|---|---|
| title | Laptop X1 |
| price | $999 |
| description | 14‑inch display, 16 GB RAM |

Mail Merge vervangt de plaatsaanduidingen door de overeenkomstige waarden, waardoor een slide met de daadwerkelijke productinformatie ontstaat.

Veldnamen zijn niet hoofdlettergevoelig, dus `{{title}}` en `{{Title}}` verwijzen naar hetzelfde veld.

De volgende regels gelden bij het vervangen van plaatsaanduidingen:

- Plaatsaanduidingen worden vervangen op slides, inclusief gegroepeerde vormen en tabelcellen, en in notities van de spreker.
- Plaatsaanduidingen op masterslides en layoutslides worden niet vervangen.
- Een plaatsaanduiding waarvan het veld niet aanwezig is in de gegevensset blijft ongewijzigd.
- Een leeg veldwaarde vervangt de plaatsaanduiding door een lege tekenreeks.
- De ingevoegde tekst erft de opmaak van het eerste teken van de plaatsaanduiding.
- Waarden mogen geen plaatsaanduidings‑tekst bevatten, omdat de ingevoegde tekst opnieuw verwerkt kan worden en door een ander veld vervangen kan worden.

De originele sjabloonpresentatie wordt niet gewijzigd tijdens de samenvoegbewerking en moet minimaal één slide bevatten.

## **Ondersteunde gegevensbronnen**

Mail Merge ondersteunt twee manieren om gegevens te leveren:

- Maak een gegevensbron programmatisch met `IMailMergeDataSource`.
- Lees gegevens uit een CSV‑, XLSX‑, JSON‑ of XML‑bestand of -stream.

Het gegevensformaat wordt gedetecteerd aan de hand van de inhoud, niet aan de bestandsextensie. Streams die geen zoeken ondersteunen, worden ook ondersteund.

De gegevensbron moet minimaal één gegevensset bevatten. Elke gegevensset vertegenwoordigt één kopie van het sjabloon die met zijn waarden wordt gevuld.

Als de gegevensinhoud niet herkend wordt als een ondersteund formaat, wordt `NotSupportedException` gegooid. Als de inhoud wel herkend wordt maar niet voldoet aan de formatvereisten, wordt `InvalidDataException` gegooid. Het exceptiebericht bevat de locatie van de fout in de gegevens.

### **JSON**

De JSON‑gegevensbron moet een root‑object hebben met een `sets`‑array. Elk element van de array vertegenwoordigt een gegevensset en moet een `fields`‑array bevatten. Elk veld moet een `name`‑ en een `value`‑string hebben.

De optionele `version`‑eigenschap moet `"1.0"` zijn, en de optionele `type`‑eigenschap van een veld moet `"text"` zijn. Eigenschapsnamen zijn hoofdlettergevoelig. Onbekende eigenschappen worden genegeerd.

JSON‑data wordt gelezen als UTF‑8, of als UTF‑16 wanneer de data begint met een byte‑order‑mark (BOM).

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

### **XML**

De XML‑gegevensbron moet een `template`‑root‑element hebben met het `sets`‑element. Elk `set`‑element bevat `field`‑elementen, en elk veld moet `name`‑ en `value`‑elementen bevatten.

Een leeg `value`‑element wordt behandeld als een lege tekenreeks. Elementnamen zijn hoofdlettergevoelig. Onbekende elementen en opmerkingen worden genegeerd. De codering wordt bepaald door de XML‑declaratie. Documenttype‑definities (DTD) zijn niet toegestaan.

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

### **CSV**

CSV‑data gebruikt puntkomma’s als waarde‑scheidingsteken.

De eerste rij bevat veldnamen en eindigt bij de eerste lege veldnaam. Elke volgende rij vertegenwoordigt één gegevensset. Data eindigt bij de eerste lege rij.

De volgende regels gelden:

- Missende waarden aan het eind van een rij worden behandeld als lege tekenreeksen.
- Waarden buiten de gedefinieerde veldnamen worden genegeerd.
- Een waarde die een puntkomma, aanhalingsteken of regeleinde bevat, moet tussen aanhalingstekens staan.
- Aanhalingstekens binnen een gequoteerde waarde moeten verdubbeld worden.
- Data wordt gelezen als UTF‑8, of als UTF‑16 wanneer het begint met een byte‑order‑mark (BOM).

Voorbeeld:

```csv
title;price;description
Laptop X1;$999;"14"" display; 16 GB RAM"
Tablet S2;$499;
```

### **XLSX**

XLSX‑data wordt gelezen uit het eerste werkblad.

Het werkblad volgt dezelfde regels als CSV:

- De eerste rij bevat veldnamen en eindigt bij de eerste lege cel.
- Elke volgende rij vertegenwoordigt één gegevensset.
- Data eindigt bij de eerste lege rij.
- Lege cellen worden behandeld als lege tekenreeksen.
- Numerieke waarden worden omgezet naar tekst met de invariant‑culture.

## **Een enkele presentatie maken**

De `MergeToSinglePresentation`‑methode maakt één presentatie die een kopie van de sjabloonslides bevat voor elke gegevensset. Elke kopie wordt gevuld met de overeenkomstige data.

De volgorde van de gegevenssets bepaalt de volgorde van de slide‑groepen in de resulterende presentatie.

### **Gegevens samenvoegen vanuit een bestand**

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

De gegevens kunnen ook uit een stream worden gelezen. De stream wordt gelezen vanaf de huidige positie en wordt niet gesloten door de Mail‑Merge‑bewerking.

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

### **Een gegevensbron in code maken**

Je kunt een gegevensbron programmatically bouwen met `MailMergeDataSource` en `MailMergeDataSet`. Voeg een gegevensset toe voor elk record en definieer de velden met de `AddText`‑methode.

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

In dit voorbeeld worden de sjabloonslides twee keer herhaald: één keer voor de laptop en één keer voor de tablet. De plaatsaanduidingen worden gevuld met de waarden die in elke gegevensset zijn gedefinieerd.

## **Meerdere presentaties maken**

Als je een aparte presentatie wilt voor elke gegevensset, gebruik je de `MergeToMultiplePresentations`‑methode.

Deze methode verwerkt de gegevenssets één voor één, maakt een presentatie vanuit het sjabloon, vult deze met de huidige data en geeft de resulterende presentatie door aan een handler.

De handler wordt één keer aangeroepen voor elke gegevensset, in de oorspronkelijke gegevensvolgorde.

### **Elke presentatie opslaan**

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

De eigenschap `args.Index` geeft de nul‑gebaseerde index van de huidige gegevensset terug. In het voorbeeld wordt deze gebruikt om opeenvolgende bestandsnamen te genereren beginnend bij `product_1.pptx`.

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

### **Gegevensset‑waarden gebruiken om bestanden te benoemen**

De handler ontvangt zowel de gegenereerde presentatie als informatie over de gebruikte gegevensset. Je kunt de waarden van de gegevensset gebruiken om betekenisvolle bestandsnamen te bouwen.

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

De eigenschap `DataSet` geeft de gegevensset terug die is gebruikt om de huidige presentatie te vullen. De methode `GetText` haalt de waarde van een opgegeven veld op, of `null` als het veld niet bestaat.

Dit maakt het mogelijk om gegevenswaarden te gebruiken voor bestandsnamen, het organiseren van de output, of extra verwerking in de handler.

## **Gegenereerde presentaties verwerken**

`MergeToMultiplePresentations` gebruikt de delegate `MailMergedPresentationHandler` om elke gegenereerde presentatie te verwerken.

De handler ontvangt twee argumenten:

- `presentation` — de presentatie die is gemaakt vanuit het sjabloon en is gevuld met de huidige gegevensset.
- `args` — informatie over de gegenereerde presentatie, inclusief de index van de gegevensset en de gegevensset zelf.

De gegenereerde presentatie is eigendom van de Mail‑Merge‑bewerking en wordt onmiddellijk na het terugkeren van de handler disposed. Je moet deze dus opslaan of benodigde gegevens kopiëren binnen de handler. Houd geen referentie naar de presentatie vast nadat de handler heeft geretourneerd en probeer deze niet handmatig te disposen.

De handler wordt uitgevoerd op de aanroepende thread, één presentatie per keer, in de volgorde van de gegevenssets. Er wordt slechts één gegenereerde presentatie tegelijk in het geheugen gehouden, waardoor deze aanpak geschikt is voor het verwerken van grote gegevensbronnen zonder alle gegenereerde presentaties tegelijk in het geheugen te moeten laden.

Als de handler een exceptie gooit, stopt de Mail‑Merge‑bewerking en wordt de exceptie onveranderd doorgegeven aan de aanroeper. Presentaties die al verwerkt zijn, blijven onaangetast, en de resterende gegevenssets worden niet verwerkt.

Het volgende voorbeeld slaat gegenereerde presentaties op in een toegewijde map:

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

## **Werken met Mail‑Merge‑data**

De klasse `MailMergeDataSource` vertegenwoordigt een geordende collectie van gegevenssets. Ze kan worden gebruikt om data in code aan te maken, het aantal gegevenssets te inspecteren en individuele gegevenssets op index te benaderen.

### **Het aantal gegevenssets opvragen**

De eigenschap `Count` geeft het aantal gegevenssets in de bron terug.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine("Presentations to create: " + source.Count);
```

### **Een gegevensset benaderen op index**

De eigenschap `Item(int)` biedt toegang tot een gegevensset op de opgegeven nul‑gebaseerde index.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine(source[1].GetText("title"));
```

Dit voorbeeld haalt de titel op van de tweede gegevensset.

### **Tekstvelden toevoegen**

De methode `AddText` voegt een benoemd tekstveld toe aan een gegevensset. De veldwaarde vervangt alle overeenkomstige plaatsaanduidingen in het sjabloon.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet dataSet = source.AddDataSet();
dataSet.AddText("title", "Laptop X1");
dataSet.AddText("subtitle", string.Empty);
```

Een lege waarde verwijdert de overeenkomstige plaatsaanduiding uit de resulterende tekst. Als het veld niet aan de gegevensset wordt toegevoegd, blijft de plaatsaanduiding ongewijzigd.

### **Tekstvelden lezen**

De methode `GetText` haalt de waarde van een veld op op basis van de naam. Veldnamen zijn niet hoofdlettergevoelig.

```csharp
IMailMergeDataSet dataSet = source[0];

string title = dataSet.GetText("title");
string price = dataSet.GetText("price");
```

Als het veld niet bestaat of de opgegeven veldnaam `null` is, retourneert `GetText` `null`.

## **Samenvatting**

Mail Merge in Aspose.Slides for .NET biedt een handige manier om gegevens‑gedreven presentaties te genereren vanuit een herbruikbaar sjabloon.

Je kunt het gebruiken om:

- Presentatiesjablonen te vullen met waarden uit gegevensbronnen.
- Eén presentatie te genereren met herhaalde sjabloonslides voor meerdere gegevenssets.
- Een aparte presentatie te maken voor elke gegevensset.
- Gegevens te lezen uit CSV‑, XLSX‑, JSON‑ en XML‑bestanden of -streams.
- Gegevensbronnen rechtstreeks in code op te bouwen.
- Gegenereerde presentaties sequentieel te verwerken en op te slaan met een handler.

Door herbruikbare sjablonen te combineren met gestructureerde data kun je het maken van grote aantallen presentaties automatiseren, terwijl je het sjabloon‑ontwerp en de dataverwerkingslogica gescheiden houdt.

## **Veelgestelde vragen**

**Kan ik dezelfde plaatsaanduiding meerdere keren in een sjabloon gebruiken?**

Ja. Elke verschijning van een plaatsaanduiding met een overeenkomende veldnaam wordt vervangen door de overeenkomstige waarde uit de huidige gegevensset.

**Zijn veldnamen hoofdlettergevoelig?**

Nee. Plaatsaanduidings‑ en gegevensveld‑namen zijn niet hoofdlettergevoelig. Bijvoorbeeld `{{title}}`, `{{Title}}` en `{{TITLE}}` verwijzen naar hetzelfde veld.

**Wat gebeurt er als een veld ontbreekt in een gegevensset?**

Als de gegevensset geen veld bevat dat door een plaatsaanduiding wordt gerefereerd, blijft die plaatsaanduiding ongewijzigd in de gegenereerde presentatie.

**Wat gebeurt er als een veld een lege waarde heeft?**

Een lege veldwaarde vervangt de plaatsaanduiding door een lege tekenreeks. De plaatsaanduidingstekst wordt verwijderd, waardoor er geen tekst op die plek blijft staan.

**Kan ik de opmaak van een plaatsaanduiding behouden bij het vervangen?**

De vervangingstekst erft de opmaak van het eerste teken van de plaatsaanduiding. Pas de gewenste opmaak toe op de plaatsaanduiding in het sjabloon vóór de samenvoegbewerking.

**Vervangt Mail Merge plaatsaanduidingen op masterslides of layout‑slides?**

Nee. Mail Merge vervangt plaatsaanduidingen alleen in ondersteunde inhoud op presentatieslides, inclusief vormen, gegroepeerde vormen, tabelcellen en notities van de spreker. Plaatsaanduidingen op masterslides en layout‑slides worden niet vervangen.

**Wordt de sjabloonpresentatie gewijzigd tijdens de samenvoegbewerking?**

Nee. Het originele sjabloon wordt niet aangepast door de samenvoegbewerking. Je kunt het opnieuw gebruiken om presentaties te genereren uit dezelfde of andere gegevensbronnen.

**Kan ik een aparte presentatie genereren voor elke gegevensset?**

Ja. Gebruik `MergeToMultiplePresentations` en sla elke gegenereerde presentatie op binnen de handler. De handler wordt achtereenvolgens aangeroepen voor elke gegevensset.

**Kan ik alle gegevenssets combineren in één presentatie?**

Ja. Gebruik `MergeToSinglePresentation`. Deze maakt één uitvoer‑presentatie die een kopie van de sjabloonslides bevat voor elke gegevensset, in de volgorde van de gegevensbron.

**Kan ik een gegevensbron gebruiken zonder deze op te slaan in een bestand?**

Ja. Je kunt een `MailMergeDataSource` in code maken, gegevenssets toevoegen en velden vullen met `AddText`. Dit is handig wanneer je data al beschikbaar is in je applicatie.

**Detecteert Mail Merge het gegevensformaat op basis van de bestandsextensie?**

Nee. Het gegevensformaat wordt gedetecteerd aan de hand van de inhoud, dus een ondersteunde gegevensbron hoeft geen specifieke bestandsextensie te hebben.

**Kan ik data lezen uit een stream die geen zoeken ondersteunt?**

Ja. Mail Merge ondersteunt niet‑zoekbare streams.

**Wat gebeurt er als de gegevensbron leeg is of geen gegevenssets bevat?**

De gegevensbron moet minimaal één gegevensset bevatten. Zorg ervoor dat er minstens één record aanwezig is voordat je de samenvoegbewerking start.

**Wat gebeurt er als de gegevensbron een onjuist formaat heeft?**

Als de inhoud niet herkend wordt als een van de ondersteunde formaten, wordt `NotSupportedException` gegooid. Als de inhoud wel herkend wordt maar ongeldig is, wordt `InvalidDataException` gegooid. Het exceptiebericht bevat informatie over de locatie van de fout.

**Kan ik de gegenereerde presentatie gebruiken nadat de handler is teruggekeerd?**

De presentatie die aan de `MergeToMultiplePresentations`‑handler wordt doorgegeven, blijft eigendom van Mail Merge en wordt disposed nadat de handler is teruggekeerd. Sla deze op of kopieer de benodigde inhoud binnen de handler, en bewaar of dispose de presentatie niet zelf.

**Wordt de handler parallel uitgevoerd?**

Nee. Gegenereerde presentaties worden sequentieel verwerkt, op de thread van de aanroeper. Er wordt slechts één gegenereerde presentatie tegelijk in het geheugen gehouden door deze operatie.

**Wat gebeurt er als er een exceptie optreedt binnen de handler?**

De samenvoegbewerking stopt en de exceptie wordt onveranderd doorgegeven aan de aanroeper. Presentaties die al verwerkt zijn, blijven onaangetast, en de resterende gegevenssets worden niet meer verwerkt.

**Kan ik veldwaarden gebruiken om bestandsnamen te genereren?**

Ja. De handler levert de huidige gegevensset via zijn argumenten. Gebruik `GetText` om velden op te halen en een bestandsnaam voor elke gegenereerde presentatie te bouwen. Zorg ervoor dat de waarden geldig zijn als bestandsnamen in je doelomgeving.