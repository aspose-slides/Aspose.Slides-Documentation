---
title: Automatisera anpassning av presentationer med Mail Merge
linktitle: Mail Merge
type: docs
weight: 233
url: /sv/net/mail-merge/
keywords:
- Mail Merge
- presentationstillpersonalisering
- presentationsmall
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
description: "Lär dig hur du använder Mail Merge i Aspose.Slides för .NET för att fylla presentationsmallar med data och generera personliga PowerPoint-presentationer från CSV-, Excel-, JSON- och XML-källor."
---
# Mail Merge i PowerPoint-presentationer

Aspose.Slides för .NET gör det möjligt att automatiskt generera PowerPoint-presentationer med hjälp av en mall och en datakälla. Mail Merge fyller mallens platshållare med data och skapar antingen en enda presentation som innehåller upprepade mallbilder för varje dataset eller en separat presentation för varje dataset.

Denna funktionalitet är användbar för att skapa produktkataloger, personliga presentationer, rapporter, certifikat, förslag, prislistor och andra dokument där presentationsstrukturen förblir densamma medan innehållet varierar.

![Mail Merge: före och efter](mail-merge-before-after.png)


## Så fungerar Mail Merge

Mail Merge använder en PowerPoint-presentation som mall och ersätter platshållare med värden från en datakälla.

![Mail Merge arbetsflöde](mail-merge-workflow.png)

En platshållare är ett fältnamn omgivet av dubbla måsvanggar, t.ex. `{{title}}` eller `{{price}}`. Platshållare kan placeras i text i former, tabellceller, grupperade former och talarnoter.

Till exempel kan en mallbild innehålla följande text:

- `Produkt: {{title}}`
- `Pris: {{price}}`
- `Beskrivning: {{description}}`

När datakällan innehåller följande värden:

| Fält | Värde |
|---|---|
| title | Laptop X1 |
| price | $999 |
| description | 14‑inch display, 16 GB RAM |

Mail Merge ersätter platshållarna med motsvarande värden och skapar en bild med den faktiska produktinformationen.

Fältnamn är skiftlägesokänsliga, så `{{title}}` och `{{Title}}` refererar till samma fält.

Följande regler gäller när platshållare ersätts:

- Platshållare ersätts på bilder, inklusive grupperade former och tabellceller, samt i talarnoter.
- Platshållare på mästarbilder och layoutbilder ersätts inte.
- En platshållare vars fält inte finns i datasetet förblir oförändrad.
- Ett tomt fältvärde ersätter sin platshållare med en tom sträng.
- Den infogade texten ärver formateringen från den första tecknet i platshållaren.
- Värden får inte innehålla platshållartext, eftersom den infogade texten kan bearbetas igen och ersättas av ett annat fält.

Den ursprungliga mallpresentationen ändras inte under sammanslagningsoperationen och måste innehålla minst en bild.

## Supporterade datakällor

Mail Merge stöder två sätt att leverera data:

- Skapa en datakälla programatiskt med `IMailMergeDataSource`.
- Läsa data från en CSV-, XLSX-, JSON- eller XML-fil eller ström.

Datformatet identifieras av dess innehåll, inte av filändelsen. Strömmar som inte stöder sökning stöds också.

Datakällan måste innehålla minst ett dataset. Varje dataset representerar en kopia av mallen som ska fyllas med dess värden.

Om datainnehållet inte kan kännas igen som ett stödd format kastas `NotSupportedException`. Om innehållet känns igen men inte uppfyller formatkraven kastas `InvalidDataException`. Undantagsmeddelandet innehåller platsen för felet i datan.

### JSON

JSON-datakällan måste ha ett rotobjekt som innehåller en `sets`‑array. Varje element i arrayen representerar ett dataset och måste innehålla en `fields`‑array. Varje fält måste ha en `name`‑ och en `value`‑sträng.

Den valfria `version`‑egenskapen måste vara `"1.0"`, och den valfria `type`‑egenskapen för ett fält måste vara `"text"`. Egenskapsnamn är skiftlägeskänsliga. Okända egenskaper ignoreras.

JSON-data läses som UTF‑8, eller som UTF‑16 när datan startar med en byte‑order‑mark (BOM).

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

### XML

XML-datakällan måste ha ett `template`‑rootelement som innehåller `sets`‑elementet. Varje `set`‑element innehåller `field`‑element, och varje fält måste innehålla `name`‑ och `value`‑element.

Ett tomt `value`‑element behandlas som en tom sträng. Elementnamn är skiftlägeskänsliga. Okända element och kommentarer ignoreras. Kodningen bestäms av XML-deklarationen. Dokumenttypsdefinitioner (DTD) är inte tillåtna.

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

CSV-data använder semikolon som värdeavgränsare.

Den första raden innehåller fältnamn och slutar vid det första tomma fältnamnet. Varje efterföljande rad representerar ett dataset. Data slutar vid den första tomma raden.

Följande regler gäller:

- Saknade värden i slutet av en rad behandlas som tomma strängar.
- Värden som ligger utanför de definierade fältnamnen ignoreras.
- Ett värde som innehåller ett semikolon, citationstecken eller radbrytning måste omges av citationstecken.
- Citationstecken inuti ett onoterat värde måste dubblas.
- Data läses som UTF‑8, eller som UTF‑16 när det börjar med en byte‑order‑mark (BOM).

Exempel:

```csv
title;price;description
Laptop X1;$999;"14"" display; 16 GB RAM"
Tablet S2;$499;
```

### XLSX

XLSX-data läses från det första kalkylbladet.

Kalkylbladet följer samma regler som CSV:

- Den första raden innehåller fältnamn och slutar vid den första tomma cellen.
- Varje efterföljande rad representerar ett dataset.
- Data slutar vid den första tomma raden.
- Tomma celler behandlas som tomma strängar.
- Numeriska värden konverteras till text med den invariant culture.

## Skapa en enkel presentation

`MergeToSinglePresentation`‑metoden skapar en presentation som innehåller en kopia av mallbilderna för varje dataset. Varje kopia fylls med motsvarande data.

Ordningen på datamängderna bestämmer ordningen på bildgrupperna i den resulterande presentationen.

### Slå samman data från en fil

Följande exempel laddar en mall och en JSON‑datafil, skapar en enda presentation som innehåller bilderna för alla dataset och sparar resultatet.

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

Datan kan också läsas från en ström. Strömmen läses från sin aktuella position och stängs inte av Mail Merge‑operationen.

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

### Skapa en datakälla i kod

Du kan bygga en datakälla programatiskt med `MailMergeDataSource` och `MailMergeDataSet`. Lägg till ett dataset för varje post och definiera dess fält med `AddText`‑metoden.

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

I det här exemplet upprepas mallbilderna två gånger: en gång för laptopen och en gång för surfplattan. Platshållarna fylls med de värden som definierats i varje dataset.

## Skapa flera presentationer

Om du behöver en separat presentation för varje dataset, använd `MergeToMultiplePresentations`‑metoden.

Denna metod bearbetar dataseten ett i taget, skapar en presentation från mallen, fyller den med aktuell data och skickar den resulterande presentationen till en handler.

Handlern anropas en gång för varje dataset, i den ursprungliga datasekvensen.

### Spara varje presentation

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

`args.Index`‑egenskapen ger det nollbaserade indexet för det aktuella datasetet. I exemplet används den för att generera sekventiella filnamn som börjar med `product_1.pptx`.

Datan kan också läsas från en ström:

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

### Använd datasetvärden för att namnge filer

Handlern får både den genererade presentationen och information om datasetet som användes för att skapa den. Du kan använda datasetvärdena för att bygga meningsfulla filnamn.

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

`DataSet`‑egenskapen returnerar datasetet som användes för att fylla den aktuella presentationen. `GetText`‑metoden hämtar värdet för ett angivet fält, eller `null` om fältet saknas.

Detta gör att du kan använda datavärden för att namnge filer, organisera utdata eller applicera ytterligare bearbetning i handlern.

## Hantera genererade presentationer

`MergeToMultiplePresentations` använder delegaten `MailMergedPresentationHandler` för att bearbeta varje genererad presentation.

Handlern får två argument:

- `presentation` — presentationen som skapats från mallen och fyllts med det aktuella datasetet.
- `args` — information om den genererade presentationen, inklusive dataset‑index och själva datasetet.

Den genererade presentationen ägs av Mail Merge‑operationen och tas bort omedelbart efter att handlern återvänder. Därför måste du spara den eller kopiera nödvändig data inuti handlern. Behåll inte en referens till den efter att handlern återvänder och disponera den inte manuellt.

Handlern körs på anropartråden, en presentation i taget, i den ordning datasetena listas. Endast en genererad presentation hålls i minnet åt gången, vilket gör detta tillvägagångssätt lämpligt för att bearbeta stora datakällor utan att alla genererade presentationer hålls i minnet samtidigt.

Om handlern kastar ett undantag stoppas Mail Merge‑operationen och undantaget vidarebefordras oförändrat till anroparen. Presentationer som redan bearbetats förblir opåverkade, och återstående dataset bearbetas inte.

Följande exempel sparar genererade presentationer i en särskild katalog:

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

## Arbeta med Mail Merge-data

`MailMergeDataSource`‑klassen representerar en ordnad samling av dataset. Den kan användas för att skapa data i kod, inspektera antalet dataset och komma åt enskilda dataset via index.

### Hämta antal dataset

`Count`‑egenskapen returnerar antalet dataset i källan.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine("Presentations to create: " + source.Count);
```

### Åtkomst till ett dataset via index

`Item(int)`‑egenskapen ger åtkomst till ett dataset på det angivna nollbaserade indexet.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine(source[1].GetText("title"));
```

Detta exempel hämtar titeln för det andra datasetet.

### Lägga till textfält

`AddText`‑metoden lägger till ett namngivet textfält i ett dataset. Fältvärdet ersätter alla matchande platshållare i mallen.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet dataSet = source.AddDataSet();
dataSet.AddText("title", "Laptop X1");
dataSet.AddText("subtitle", string.Empty);
```

Ett tomt värde tar bort motsvarande platshållare från den resulterande texten. Om fältet inte läggs till i datasetet förblir platshållaren oförändrad.

### Läsa textfält

`GetText`‑metoden hämtar värdet för ett fält enligt namn. Fältnamn är skiftlägesokänsliga.

```csharp
IMailMergeDataSet dataSet = source[0];

string title = dataSet.GetText("title");
string price = dataSet.GetText("price");
```

Om fältet inte finns eller det angivna fältnamnet är `null` returnerar `GetText` `null`.

## Sammanfattning

Mail Merge i Aspose.Slides för .NET erbjuder ett bekvämt sätt att generera datadrivna presentationer från en återanvändbar mall.

Du kan använda det för att:

- Fyll i presentationsmallar med värden från datakällor.
- Generera en enda presentation som innehåller upprepade mallbilder för flera dataset.
- Skapa en separat presentation för varje dataset.
- Läsa data från CSV-, XLSX-, JSON- och XML-filer eller strömmar.
- Bygga datakällor direkt i kod.
- Bearbeta och spara genererade presentationer sekventiellt med en handler.

Genom att kombinera återanvändbara mallar med strukturerad data kan du automatisera skapandet av stora mängder presentationer samtidigt som mallens design och databehandlingslogik hålls åtskilda.

## Vanliga frågor

### Kan jag använda samma platshållare flera gånger i en mall?

Ja. Varje förekomst av en platshållare med ett matchande fältnamn ersätts med motsvarande värde från det aktuella datasetet.

### Är fältnamn skiftlägeskänsliga?

Nej. Platshållar‑ och datafält‑namn är skiftlägesokänsliga. Till exempel refererar `{{title}}`, `{{Title}}` och `{{TITLE}}` till samma fält.

### Vad händer om ett fält saknas i ett dataset?

Om datasetet inte innehåller ett fält som refereras av en platshållare, förblir den platshållaren oförändrad i den genererade presentationen.

### Vad händer om ett fält har ett tomt värde?

Ett tomt fältvärde ersätter platshållaren med en tom sträng. Platshållartexten tas bort, så det finns ingen text på dess plats.

### Kan jag bevara formateringen av en platshållare när den ersätts?

Den infogade texten ärver formateringen från den första tecknet i platshållaren. Applicera önskad formatering på platshållartexten i mallen innan sammanslagningen utförs.

### Ersätter Mail Merge platshållare på mästarbilder eller layoutbilder?

Nej. Mail Merge ersätter platshållare i stödjat innehåll på presentationsbilder, inklusive former, grupperade former, tabellceller och talarnoter. Platshållare på mästar‑ och layoutbilder ersätts inte.

### Ändras mallpresentationen under sammanslagningen?

Nej. Den ursprungliga mallen ändras inte av sammanslagningsoperationen. Du kan återanvända den för att generera presentationer från samma eller olika datakällor.

### Kan jag generera en separat presentation för varje dataset?

Ja. Använd `MergeToMultiplePresentations` och spara varje genererad presentation i handlern. Handlern anropas sekventiellt för varje dataset.

### Kan jag kombinera alla dataset till en presentation?

Ja. Använd `MergeToSinglePresentation`. Den skapar en enda utgångspresentation som innehåller en kopia av mallbilderna för varje dataset, i den ordning de förekommer i datakällan.

### Kan jag använda en datakälla utan att spara den till en fil?

Ja. Du kan skapa ett `MailMergeDataSource` i kod, lägga till dataset och fylla fält med `AddText`. Detta är användbart när dina data redan finns tillgängliga i applikationen.

### Upptäcker Mail Merge dataformatet från filändelsen?

Nej. Dataformatet identifieras från innehållet, så en stödd datakälla behöver inte ha en specifik filändelse.

### Kan jag läsa data från en ström som inte stöder sökning?

Ja. Mail Merge stöder icke‑sökbara strömmar.

### Vad händer om datakällan är tom eller inte innehåller dataset?

Datakällan måste innehålla minst ett dataset. Se till att den innehåller minst en post innan du startar sammanslagningsoperationen.

### Vad händer om datakällan har ett ogiltigt format?

Om innehållet inte känns igen som ett av de stödda dataformaten kastas `NotSupportedException`. Om det känns igen men är felaktigt formatat kastas `InvalidDataException`. Undantagsmeddelandet innehåller information om felplatsen.

### Kan jag använda den genererade presentationen efter att handlern har återvänt?

Presentation som skickas till `MergeToMultiplePresentations`‑handlern ägs av Mail Merge och disponeras efter att handlern återvänder. Spara den eller kopiera innehållet du behöver i handlern och behåll inte eller disponera presentationen själv.

### Kallas handlern parallellt?

Nej. Genererade presentationer bearbetas sekventiellt, på anroparens tråd. Endast en genererad presentation hålls i minnet åt gången av denna operation.

### Vad händer om ett undantag uppstår i handlern?

Sammanslagningsoperationen stoppas och undantaget vidarebefordras till anroparen oförändrat. Presentationer som redan bearbetats påverkas inte, och efterföljande dataset behandlas inte.

### Kan jag använda fältvärden för att generera utdatafilnamn?

Ja. Handlern tillhandahåller det aktuella datasetet via sina argument. Använd `GetText` för att hämta fält och bygga ett filnamn för varje genererad presentation. Se till att värdena är giltiga som filnamn i din målmiljö.