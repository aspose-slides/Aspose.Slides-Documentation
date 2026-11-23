---
title: Automatisera presentationstillpersonalisering med Mail Merge
linktitle: Mail Merge
type: docs
weight: 233
url: /sv/net/mail-merge/
keywords:
- Mail Merge
- presentationstillpersonalisering
- presentationmall
- textplatshållare
- datakälla
- CSV
- Excel
- XLSX
- JSON
- XML
- sammanfoga data
- generera presentationer
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du använder Mail Merge i Aspose.Slides för .NET för att fylla presentationmallar med data och generera personliga PowerPoint‑presentationer från CSV-, Excel‑, JSON‑ och XML‑källor."
---
## **Mail Merge i PowerPoint‑presentationer**

Aspose.Slides för .NET gör det möjligt att automatiskt generera PowerPoint‑presentationer med hjälp av en mall och en datakälla. Mail Merge fyller mallens platshållare med data och skapar antingen en enda presentation som innehåller upprepade mallbilder för varje dataset eller en separat presentation för varje dataset.

Denna funktion är användbar för att generera produktkataloger, personliga presentationer, rapporter, certifikat, förslag, prislistor och andra dokument där presentationsstrukturen förblir densamma medan innehållet varierar.

![Mail Merge: före och efter](mail-merge-before-after.png)


## **Hur Mail Merge fungerar**

Mail Merge använder en PowerPoint‑presentation som mall och ersätter platshållare med värden från en datakälla.

![Mail Merge‑arbetsflöde](mail-merge-workflow.png)

En platshållare är ett fältnamn omgärdat av dubbla måsvingar, t.ex. `{{title}}` eller `{{price}}`. Platshållare kan placeras i text i former, tabellceller, grupperade former och föreläsningsanteckningar.

Till exempel kan en mallbild innehålla följande text:

- `Product: {{title}}`
- `Price: {{price}}`
- `Description: {{description}}`

När datakällan innehåller följande värden:

| Fält | Värde |
|---|---|
| title | Laptop X1 |
| price | $999 |
| description | 14‑inch display, 16 GB RAM |

Ersätter Mail Merge platshållarna med motsvarande värden och producerar en bild med den faktiska produktinformationen.

Fältnamn är skiftlägesokänsliga, så `{{title}}` och `{{Title}}` refererar till samma fält.

Följande regler gäller vid ersättning av platshållare:

- Platshållare ersätts på bilder, inklusive grupperade former och tabellceller, samt i föreläsningsanteckningar.
- Platshållare på masternivåbilder och layoutbilder ersätts inte.
- En platshållare vars fält inte finns i datasetet förblir oförändrad.
- Ett tomt fältvärde ersätter dess platshållare med en tom sträng.
- Den infogade texten ärver formateringen från den första tecknet i platshållaren.
- Värden får inte innehålla platshållartext, eftersom den infogade texten annars kan bearbetas igen och ersättas av ett annat fält.

Den ursprungliga mall‑presentationen ändras inte under sammanslagningsoperationen och måste innehålla minst en bild.

## **Stödda datakällor**

Mail Merge stöder två sätt att tillhandahålla data:

- Skapa en datakälla programmässigt med `IMailMergeDataSource`.
- Läs data från en CSV‑, XLSX‑, JSON‑ eller XML‑fil eller –ström.

Dataformatet identifieras utifrån innehållet, inte filändelsen. Strömmar som inte stödjer sökning stöds också.

Datakällan måste innehålla minst ett dataset. Varje dataset representerar en kopia av mallen som ska fyllas med dess värden.

Om data inte kan identifieras som ett stödt format kastas `NotSupportedException`. Om innehållet känns igen men inte uppfyller formatkraven kastas `InvalidDataException`. Undantagsmeddelandet innehåller platsen för felet i datan.

### **JSON**

JSON‑datakällan måste ha ett rotobjekt som innehåller en `sets`‑array. Varje element i arrayen representerar ett dataset och måste innehålla en `fields`‑array. Varje fält måste ha en `name`‑ och en `value`‑sträng.

Den valfria egenskapen `version` måste vara `"1.0"`, och den valfria egenskapen `type` för ett fält måste vara `"text"`. Egendomsnamn är skiftlägeskänsliga. Okända egenskaper ignoreras.

JSON‑data läses som UTF‑8, eller som UTF‑16 när datan börjar med en byte‑order‑mark (BOM).

Följande exempel innehåller två dataset:

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

XML‑datakällan måste ha ett `template`‑rotnod som innehåller `sets`‑elementet. Varje `set`‑element innehåller `field`‑element, och varje fält måste innehålla `name`‑ och `value`‑element.

Ett tomt `value`‑element behandlas som en tom sträng. Elementnamn är skiftlägeskänsliga. Okända element och kommentarer ignoreras. Kodningen bestäms av XML‑deklarationen. Dokumenttypdefinitioner (DTD) är inte tillåtna.

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

CSV‑data använder semikolon som värdeavgränsare.

Den första raden innehåller fältnamn och slutar vid det första tomma fältnamnet. Varje efterföljande rad representerar ett dataset. Data slutar vid den första tomma raden.

Följande regler gäller:

- Saknade värden i slutet av en rad behandlas som tomma strängar.
- Värden längre än de definierade fältnamnen ignoreras.
- Ett värde som innehåller ett semikolon, citationstecken eller radbrytning måste omges av citationstecken.
- Citationstecken inom ett citerat värde måste dubbleras.
- Data läses som UTF‑8, eller som UTF‑16 när den börjar med en byte‑order‑mark (BOM).

Exempel:

```csv
title;price;description
Laptop X1;$999;"14"" display; 16 GB RAM"
Tablet S2;$499;
```

### **XLSX**

XLSX‑data läses från det första kalkylbladet.

Kalkylbladet följer samma regler som CSV:

- Den första raden innehåller fältnamn och slutar vid den första tomma cellen.
- Varje efterföljande rad representerar ett dataset.
- Data slutar vid den första tomma raden.
- Tomma celler behandlas som tomma strängar.
- Numeriska värden konverteras till text med invariant kultur.

## **Skapa en enda presentation**

Metoden `MergeToSinglePresentation` skapar en presentation som innehåller en kopia av mallbilderna för varje dataset. Varje kopia fylls med motsvarande data.

Ordningen på dataseten bestämmer ordningen på bildgrupperna i den resulterande presentationen.

### **Sammanfoga data från en fil**

Följande exempel laddar en mall och en JSON‑datofil, skapar en enda presentation som innehåller bilderna för alla dataset och sparar resultatet.

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

Data kan också läsas från en ström. Strömmen läses från sin nuvarande position och stängs inte av Mail Merge‑operationen.

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

### **Skapa en datakälla i kod**

Du kan bygga en datakälla programmässigt med `MailMergeDataSource` och `MailMergeDataSet`. Lägg till ett dataset för varje post och definiera dess fält med metoden `AddText`.

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

I detta exempel upprepas mallbilderna två gånger: en gång för laptopen och en gång för surfplattan. Platshållarna fylls med de värden som definierats i varje dataset.

## **Skapa flera presentationer**

Om du behöver en separat presentation för varje dataset, använd metoden `MergeToMultiplePresentations`.

Denna metod bearbetar dataseten ett efter ett, skapar en presentation från mallen, fyller den med den aktuella datan och överlämnar den resulterande presentationen till en hanterare.

Han­teraren anropas en gång för varje dataset, i den ursprungliga dataordningen.

### **Spara varje presentation**

Följande exempel läser data från en CSV‑fil och sparar varje genererad presentation som en separat fil.

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

Egenskapen `args.Index` ger det nollbaserade indexet för det aktuella datasetet. I exemplet används den för att generera sekventiella filnamn med start från `product_1.pptx`.

Data kan också läsas från en ström:

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

### **Använd datasetvärden för att namnge filer**

Han­teraren får både den genererade presentationen och information om datasetet som användes för att skapa den. Du kan använda datasetvärdena för att bygga meningsfulla filnamn.

Till exempel sparar följande kod varje presentation med produktens titel:

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

Egenskapen `DataSet` returnerar det dataset som användes för att fylla den aktuella presentationen. Metoden `GetText` hämtar värdet för ett angivet fält, eller `null` om fältet saknas.

Detta gör det möjligt att använda datavärden för att namnge filer, organisera utdata eller utföra ytterligare bearbetning i han­teraren.

## **Hantera genererade presentationer**

`MergeToMultiplePresentations` använder delegaten `MailMergedPresentationHandler` för att bearbeta varje genererad presentation.

Han­teraren får två argument:

- `presentation` — presentationen som skapats från mallen och fyllts med det aktuella datasetet.
- `args` — information om den genererade presentationen, inklusive dataset‑index och själva datasetet.

Den genererade presentationen ägs av Mail Merge‑operationen och avyttras omedelbart efter att han­teraren returnerat. Därför måste du spara den eller kopiera all nödvändig data inuti han­teraren. Behåll inte en referens till den efter att han­teraren har returnerat och avyttra den inte manuellt.

Han­teraren körs på anropartråden, en presentation i taget, i samma ordning som dataseten. Endast en genererad presentation hålls i minnet åt gången, vilket gör detta tillvägagångssätt lämpligt för att bearbeta stora datakällor utan att hålla alla genererade presentationer i minnet samtidigt.

Om han­teraren kastar ett undantag stoppas Mail Merge‑operationen och undantaget propageras till anroparen oförändrat. Presentationer som redan bearbetats påverkas inte, och återstående dataset bearbetas inte.

Följande exempel sparar genererade presentationer till en särskild katalog:

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

## **Arbeta med Mail Merge‑data**

Klassen `MailMergeDataSource` representerar en ordnad samling av dataset. Den kan användas för att skapa data i kod, inspektera antalet dataset och komma åt enskilda dataset via index.

### **Hämta antalet dataset**

Egenskapen `Count` returnerar antalet dataset i källan.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine("Presentations to create: " + source.Count);
```

### **Åtkomst till ett dataset via index**

Egenskapen `Item(int)` ger åtkomst till ett dataset på det angivna nollbaserade indexet.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine(source[1].GetText("title"));
```

Detta exempel hämtar titeln på det andra datasetet.

### **Lägg till textfält**

Metoden `AddText` lägger till ett namngivet textfält i ett dataset. Fältvärdet ersätter alla matchande platshållare i mallen.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet dataSet = source.AddDataSet();
dataSet.AddText("title", "Laptop X1");
dataSet.AddText("subtitle", string.Empty);
```

Ett tomt värde tar bort motsvarande platshållare från den resulterande texten. Om fältet inte läggs till i datasetet förblir platshållaren oförändrad.

### **Läsa textfält**

Metoden `GetText` hämtar värdet för ett fält efter namn. Fältnamn är skiftlägesokänsliga.

```csharp
IMailMergeDataSet dataSet = source[0];

string title = dataSet.GetText("title");
string price = dataSet.GetText("price");
```

Om fältet inte finns eller det angivna fältnamnet är `null` returnerar `GetText` `null`.

## **Sammanfattning**

Mail Merge i Aspose.Slides för .NET erbjuder ett bekvämt sätt att generera datadrivna presentationer från en återanvändbar mall.

Du kan använda det för att:

- Fylla presentationsmallar med värden från datakällor.
- Generera en enda presentation som innehåller upprepade mallbilder för flera dataset.
- Skapa en separat presentation för varje dataset.
- Läsa data från CSV‑, XLSX‑, JSON‑ och XML‑filer eller ‑strömmar.
- Bygga datakällor direkt i kod.
- Bearbeta och spara genererade presentationer sekventiellt med en han­terare.

Genom att kombinera återanvändbara mallar med strukturerad data kan du automatisera skapandet av stora mängder presentationer samtidigt som malldesign och databehandlingslogik hålls separata.

## **Vanliga frågor**

**Kan jag använda samma platshållare flera gånger i en mall?**

Ja. Varje förekomst av en platshållare med ett matchande fältnamn ersätts med motsvarande värde från det aktuella datasetet.

**Är fältnamn skiftlägeskänsliga?**

Nej. Platshållar‑ och datafältnamn är skiftlägesokänsliga. Till exempel refererar `{{title}}`, `{{Title}}` och `{{TITLE}}` till samma fält.

**Vad händer om ett fält saknas i ett dataset?**

Om datasetet inte innehåller ett fält som refereras av en platshållare förblir den platshållaren oförändrad i den genererade presentationen.

**Vad händer om ett fält har ett tomt värde?**

Ett tomt fältvärde ersätter platshållaren med en tom sträng. Platshållartexten tas bort och lämnar ingen text på sin plats.

**Kan jag bevara formateringen av en platshållare vid ersättning?**

Den ersatta texten ärver formateringen från det första tecknet i platshållaren. Tillämpa önskad formatering på platshållartexten i mallen innan du utför sammanslagningen.

**Ersätter Mail Merge platshållare på master‑ eller layoutbilder?**

Nej. Mail Merge ersätter endast platshållare i stödjande innehåll på presentationsbilder, inklusive former, grupperade former, tabellceller och föreläsningsanteckningar. Platshållare på master‑ och layoutbilder ersätts inte.

**Ändras mall‑presentationen under sammanslagningen?**

Nej. Den ursprungliga mallen ändras inte av sammanslagningsoperationen. Du kan återanvända den för att generera presentationer från samma eller olika datakällor.

**Kan jag generera en separat presentation för varje dataset?**

Ja. Använd `MergeToMultiplePresentations` och spara varje genererad presentation i han­teraren. Han­teraren anropas sekventiellt för varje dataset.

**Kan jag kombinera alla dataset i en enda presentation?**

Ja. Använd `MergeToSinglePresentation`. Den skapar en enda utdata‑presentation som innehåller en kopia av mallbilderna för varje dataset, i den ordning de förekommer i datakällan.

**Kan jag använda en datakälla utan att spara den till en fil?**

Ja. Du kan skapa en `MailMergeDataSource` i kod, lägga till dataset och fylla fält med `AddText`. Detta är praktiskt när dina data redan finns i din applikation.

**Detekterar Mail Merge dataformatet utifrån filändelsen?**

Nej. Dataformatet identifieras från innehållet, så en stödd datakälla behöver inte ha någon särskild filändelse.

**Kan jag läsa data från en ström som inte stödjer sökning?**

Ja. Mail Merge stöder icke‑sökbara strömmar.

**Vad händer om datakällan är tom eller saknar dataset?**

Datakällan måste innehålla minst ett dataset. Säkerställ att den innehåller minst en post innan du påbörjar sammanslagningsoperationen.

**Vad händer om datakällan har ett ogiltigt format?**

Om innehållet inte känns igen som ett av de stödda formaten kastas `NotSupportedException`. Om det känns igen men är felaktigt kastas `InvalidDataException`. Undantagsmeddelandet innehåller information om felplatsen.

**Kan jag använda den genererade presentationen efter att han­teraren har returnerat?**

Presentation som skickas till `MergeToMultiplePresentations`‑han­teraren ägs av Mail Merge och avyttras efter att han­teraren har returnerat. Spara den eller kopiera det du behöver inuti han­teraren och behåll inte eller avyttra presentationen själv.

**Kallas han­teraren parallellt?**

Nej. Genererade presentationer bearbetas sekventiellt, på anroparens tråd. Endast en genererad presentation hålls i minnet åt gången.

**Vad händer om ett undantag uppstår i han­teraren?**

Sammanslagningsoperationen stoppas och undantaget propageras till anroparen oförändrat. Presentationer som redan bearbetats påverkas inte, och efterföljande dataset bearbetas inte.

**Kan jag använda fältvärden för att generera filnamn för utdata?**

Ja. Han­teraren tillhandahåller det aktuella datasetet via sina argument. Använd `GetText` för att hämta fält och bygga ett filnamn för varje genererad presentation. Säkerställ att värdena är giltiga som filnamn i din målmiljö.