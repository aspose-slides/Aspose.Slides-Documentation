---
title: Prezentáció személyre szabásának automatizálása levélösszevonással
linktitle: Levélösszevonás
type: docs
weight: 233
url: /hu/net/mail-merge/
keywords:
- Levélösszevonás
- prezentáció személyre szabása
- prezentáció sablon
- szöveghelyettesítők
- adatforrás
- CSV
- Excel
- XLSX
- JSON
- XML
- adatok összevonása
- prezentációk generálása
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan használhatja a levélösszevonást az Aspose.Slides for .NET-ben a prezentációs sablonok adatfeltöltésére és személyre szabott PowerPoint prezentációk generálására CSV, Excel, JSON és XML forrásokból."
---
# Levélösszevonás PowerPoint bemutatókban

Az Aspose.Slides for .NET lehetővé teszi, hogy egy sablon és egy adatforrás használatával automatikusan generáljon PowerPoint‑bemutatókat. A levélösszevonás kitölti a sablonhelyettesítőket az adatokkal, és vagy egyetlen bemutatót hoz létre, amely ismétlődő sablonsorokat tartalmaz minden adatkészlethez, vagy külön bemutatót minden adatkészlethez.

Ez a funkció hasznos termékkatalógusok, személyre szabott bemutatók, jelentések, bizonyítványok, ajánlatok, árlisták és egyéb dokumentumok előállításához, ahol a bemutató szerkezete változatlan, a tartalom pedig eltérő.

![Mail Merge: before and after](mail-merge-before-after.png)


## Hogyan működik a levélösszevonás

A levélösszevonás a PowerPoint‑bemutatót használja sablonként, és a helyettesítőket adatforrásból származó értékekkel cseréli le.

![Mail Merge workflow](mail-merge-workflow.png)

A helyettesítő egy dupla kapcsos zárójelek közé zárt mezőnév, például `{{title}}` vagy `{{price}}`. Helyettesítők elhelyezhetők szövegként alakzatokban, táblázatcellákban, csoportos alakzatokban és előadói jegyzetekben.

Például egy sablondia a következő szöveget tartalmazhatja:

- `Product: {{title}}`
- `Price: {{price}}`
- `Description: {{description}}`

Amikor az adatforrás a következő értékeket tartalmazza:

| Field | Value |
|---|---|
| title | Laptop X1 |
| price | $999 |
| description | 14‑inch display, 16 GB RAM |

A levélösszevonás a helyettesítőket a megfelelő értékekkel cseréli le, és a tényleges termékinformációt tartalmazó diát hoz létre.

A mezőnevek nem kis‑ és nagybetű érzékenyek, ezért a `{{title}}` és a `{{Title}}` ugyanarra a mezőre hivatkozik.

A következő szabályok érvényesek a helyettesítők cseréjekor:

- A helyettesítőket a diákon, a csoportos alakzatokban és a táblázatcellákban, valamint az előadói jegyzetekben cserélik le.
- A mester‑diákon és elrendezés‑diákon lévő helyettesítők nem kerülnek cserére.
- A helyettesítő, amelynek mezője nem található meg az adatkészletben, változatlan marad.
- Egy üres mezőérték a helyettesítőt egy üres karakterláncra cseréli.
- A beillesztett szöveg örökli a helyettesítő első karakterének formázását.
- Az értékek nem tartalmazhatnak helyettesítő‑szöveget, mert a beillesztett szövegre újabb helyettesítők is alkalmazhatók lehetnek.

Az eredeti sablonbemutatót a összevonási művelet során nem módosítják, és legalább egy diát kell tartalmaznia.

## Támogatott adatforrások

A levélösszevonás két módon fogadja az adatokat:

- Programból hozható létre adatforrás a `IMailMergeDataSource` használatával.
- Olvasható adat CSV, XLSX, JSON vagy XML fájlból vagy adatfolyamból.

Az adatformátumot a tartalma alapján állapítják meg, nem a fájlkiterjesztés alapján. A nem kereshető (non‑seeking) adatfolyamok is támogatottak.

Az adatforrásnak legalább egy adatkészletet kell tartalmaznia. Minden adatkészlet egy sablonmásolatot jelent, amelyet a saját értékeivel töltenek fel.

Ha a tartalom nem ismerhető fel támogatott formátumként, `NotSupportedException` kivétel keletkezik. Ha a tartalom felismerésre kerül, de nem felel meg a formátumkövetelményeknek, `InvalidDataException` kivétel keletkezik. A kivétel üzenete tartalmazza a hiba helyét az adatban.

### JSON

A JSON adatforrásnak egy `sets` tömböt tartalmazó gyökérobjektummal kell rendelkeznie. A tömb minden eleme egy adatkészlet, amelynek tartalmaznia kell egy `fields` tömböt. Minden mezőnek `name` és `value` karakterlánc-értéke kell legyen.

Az opcionális `version` tulajdonság értéke `"1.0"` kell legyen, az opcionális `type` tulajdonság egy mezőnél `"text"` kell legyen. A tulajdonságnevek kis‑ és nagybetű érzékenyek. Ismeretlen tulajdonságok figyelmen kívül maradnak.

A JSON adat UTF‑8‑ként, vagy UTF‑16‑ként olvasódik, ha a fájl BOM‑mal (byte order mark) kezdődik.

Az alábbi példa két adatkészletet tartalmaz:

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

Az XML adatforrásnak egy `template` gyökérelemmel kell rendelkeznie, amely a `sets` elemet tartalmazza. Minden `set` elem `field` elemeket tartalmaz, és minden mezőnek `name` és `value` elemeket kell tartalmaznia.

Az üres `value` elem üres karakterláncként kezelendő. Az elemek nevei kis‑ és nagybetű érzékenyek. Ismeretlen elemek és megjegyzések figyelmen kívül maradnak. A kódolást az XML deklaráció határozza meg. A dokumentumtípus‑definíciók (DTD) nem engedélyezettek.

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

A CSV adat pontosvesszőket használ értékhatárolóként.

Az első sor mezőneveket tartalmaz, és az első üres mezőnévnél végződik. Minden ezt követő sor egy adatkészletet jelent. Az adat az első üres sorban áll le.

A következő szabályok érvényesek:

- Sor végén hiányzó értékek üres karakterláncként kezelendők.
- A meghatározott mezőneveken túli értékek figyelmen kívül maradnak.
- Az érték, amely pontosvesszőt, idézőjelet vagy sortörést tartalmaz, idézőjelek közé kell kerüljön.
- Az idézőjelek egy idézőjeles értéken belül duplázandók.
- Az adat UTF‑8‑ként, vagy UTF‑16‑ként olvasódik, ha BOM‑mal kezdődik.

Példa:

```csv
title;price;description
Laptop X1;$999;"14"" display; 16 GB RAM"
Tablet S2;$499;
```

### XLSX

Az XLSX adatot az első munkalapról olvassák be.

A munkalap ugyanazokat a szabályokat követi, mint a CSV:

- Az első sor mezőneveket tartalmaz, és az első üres cellánál végződik.
- Minden ezt követő sor egy adatkészlet.
- Az adat az első üres sorban áll le.
- Üres cellák üres karakterláncként kezelendők.
- Numerikus értékeket az invariáns kultúra használatával karakterlánccá konvertálják.

## Egyetlen bemutató létrehozása

A `MergeToSinglePresentation` metódus egy bemutatót hoz létre, amely a sablondiák másolatát tartalmazza minden adatkészlethez. Minden másolat a megfelelő adatokkal töltődik fel.

Az adatkészletek sorrendje határozza meg a diacsoportok sorrendjét a kimeneti bemutatóban.

### Adatok összefésülése fájlból

Az alábbi példa betölti a sablont és egy JSON adatfájlt, egyetlen bemutatót hoz létre, amely a minden adatkészlethez tartozó diákot tartalmaz, majd elmenti az eredményt.

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

Az adat olvasható adatfolyamból is. A folyamot a jelenlegi pozíciótól kezdve olvassák, és a levélösszevonási művelet nem zárja be.

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

### Adatforrás létrehozása kódból

Programból építhető adatforrás a `MailMergeDataSource` és a `MailMergeDataSet` használatával. Adjunk hozzá egy adatkészletet minden rekordhoz, és definiáljuk mezőit a `AddText` metódussal.

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

Ebben a példában a sablondiák kétszer ismétlődnek: egyszer a laptophoz, egyszer a táblagéphez. A helyettesítőket az egyes adatkészletekben definiált értékekkel töltik fel.

## Több bemutató létrehozása

Ha minden adatkészlethez külön bemutatót szeretnénk, használjuk a `MergeToMultiplePresentations` metódust.

Ez a metódus egyenként dolgozza fel az adatkészleteket, minden alkalommal létrehozza a sablon alapján a bemutatót, feltölti a jelenlegi adatokkal, majd átadja a keletkezett bemutatót egy kezelőnek.

A kezelő minden adatkészlethez egyszer kerül meghívásra, az eredeti adatrendben.

### Minden bemutató mentése

Az alábbi példa CSV‑fájlból olvas adatot, és minden előállított bemutatót külön fájlként ment.

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

Az `args.Index` tulajdonság a jelenlegi adatkészlet null‑alapú indexét adja. A példában ezt használják sorozatos fájlnevek generálásához, a `product_1.pptx` névtől kezdve.

Az adat olvasható adatfolyamból is:

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

### Adatkészlet‑értékek használata fájlnevekhez

A kezelő megkapja a generált bemutatót és az adatkészletet, amelyből létrejött. A adatkészlet‑értékek felhasználhatók értelmes fájlnevek létrehozásához.

Például az alábbi kód minden bemutatót a termék címével menti:

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

A `DataSet` tulajdonság visszaadja a jelenlegi bemutató kitöltéséhez használt adatkészletet. A `GetText` metódus a megadott mező értékét adja vissza, vagy `null`‑t, ha a mező nem létezik.

Ez lehetővé teszi a mezőértékek használatát fájlnevekhez, a kimenet szervezéséhez vagy további feldolgozáshoz a kezelőben.

## Generált bemutatók kezelése

A `MergeToMultiplePresentations` a `MailMergedPresentationHandler` delegáltat használja minden generált bemutató feldolgozásához.

A kezelő két argumentumot kap:

- `presentation` — a sablonból létrehozott és a jelenlegi adatkészlettel feltöltött bemutató.
- `args` — információ a generált bemutatóról, beleértve az adatkészlet indexét és magát az adatkészletet.

A generált bemutató a levélösszevonási művelet tulajdona, és a kezelő visszatérése után azonnal eldobásra kerül. Ezért menteni kell, vagy a szükséges adatot a kezelőn belül másolni kell. Ne tartsunk meg rá hivatkozást a kezelő visszatérése után, és ne dobjuk el kézzel.

A kezelő a hívó szálon, egy bemutatót egyszerre futtat, az adatkészletek sorrendjében. Egy időben csak egy generált bemutató van a memóriában, így a megközelítés nagy adatforrások feldolgozására alkalmas anélkül, hogy az összes bemutatót egyszerre a memóriában tartaná.

Ha a kezelő kivételt dob, a levélösszevonási művelet leáll, a kivétel változatlanul továbbadódik a hívónak. A már feldolgozott bemutatók érintetlenek, a maradék adatkészletek nem kerülnek feldolgozásra.

Az alábbi példában a generált bemutatókat egy dedikált könyvtárba mentik:

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

## Levélösszevonási adatok kezelése

A `MailMergeDataSource` osztály egy rendezett adatkészlet‑gyűjteményt képvisel. Használható adat létrehozására a kódban, az adatkészletek számának lekérdezésére és egyes adatkészletek index szerinti elérésére.

### Az adatkészletek számának lekérdezése

A `Count` tulajdonság visszaadja az adatforrásban lévő adatkészletek számát.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine("Presentations to create: " + source.Count);
```

### Adatkészlet elérése index alapján

Az `Item(int)` tulajdonság lehetővé teszi egy adatkészlet elérését a megadott null‑alapú indexen.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine(source[1].GetText("title"));
```

Ez a példa a második adatkészlet címét kérdezi le.

### Szövegmezők hozzáadása

Az `AddText` metódus egy névvel ellátott szövegmezőt ad egy adatkészlethez. A mezőérték minden megfelelő helyettesítőt a sablonban lecserél.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet dataSet = source.AddDataSet();
dataSet.AddText("title", "Laptop X1");
dataSet.AddText("subtitle", string.Empty);
```

Az üres érték eltávolítja a megfelelő helyettesítőt a kapott szövegből. Ha a mező nincs hozzáadva az adatkészlethez, a helyettesítő változatlan marad.

### Szövegmezők olvasása

A `GetText` metódus mező nevétől függően visszaadja a mező értékét. A mezőnevek kis‑ és nagybetű érzékenyek.

```csharp
IMailMergeDataSet dataSet = source[0];

string title = dataSet.GetText("title");
string price = dataSet.GetText("price");
```

Ha a mező nem létezik, vagy a megadott mezőnév `null`, a `GetText` `null`‑t ad vissza.

## Összefoglalás

A levélösszevonás az Aspose.Slides for .NET‑ben kényelmes módot biztosít adat‑vezérelt bemutatók előállítására újrahasználható sablonból.

Használhatja a következőkre:

- Bemutatósablonok feltöltése adatforrásokból származó értékekkel.
- Egyetlen bemutató létrehozása, amely többszörösen tartalmazza a sablondiákat több adatkészlethez.
- Külön bemutató létrehozása minden adatkészlethez.
- Adatok olvasása CSV, XLSX, JSON és XML fájlokból vagy adatfolyamokból.
- Adatforrások közvetlenül a kódban felépítése.
- Generált bemutatók sorozatos feldolgozása és mentése kezelő segítségével.

Az újrahasználható sablonok és a strukturált adatok kombinálásával automatizálható nagy számú bemutató létrehozása, miközben a sablon tervezése és az adatfeldolgozási logika külön marad.

## Gyakran ismételt kérdések

### Használhatom ugyanazt a helyettesítőt többször a sablonban?

Igen. A helyettesítő minden előfordulása a megfelelő mezőértékkel cserélődik a jelenlegi adatkészletből.

### A mezőnevek kis‑ és nagybetű érzékenyek?

Nem. A helyettesítő- és adatmezőnevek nem érzékenyek a kis‑ és nagybetűkre. Például a `{{title}}`, `{{Title}}` és `{{TITLE}}` ugyanarra a mezőre hivatkozik.

### Mi történik, ha egy mező hiányzik az adatkészletből?

Ha egy adatkészlet nem tartalmaz egy helyettesítő által hivatkozott mezőt, az a helyettesítő változatlan marad a generált bemutatóban.

### Mi történik, ha egy mezőnek üres értéke van?

Az üres mezőérték a helyettesítőt egy üres karakterláncra cseréli. A helyettesítő szövege eltűnik, és nem marad szöveg a helyén.

### Megőrizhetem a helyettesítő formázását a csere során?

A helyettesítő első karakterének formázása öröklődik a csere‑szövegre. Alkalmazza a kívánt formázást a sablonban a helyettesítőre, mielőtt a összevonást végrehajtja.

### A levélösszevonás cseréli a helyettesítőket a mester‑ vagy elrendezés‑diákon?

Nem. A levélösszevonás csak a prezentáció‑diák támogatott tartalmában cserél helyettesítőket, beleértve az alakzatokat, csoportos alakzatokat, táblázatcellákat és előadói jegyzeteket. A mester‑ és elrendezés‑diákon lévő helyettesítők nem cserélődnek.

### Módosul a sablonbemutató a összevonás során?

Nem. Az eredeti sablon nem módosul a művelet során. Újra felhasználható ugyanazokhoz vagy más adatforrásokhoz történő bemutató generálásához.

### Létrehozhatok külön bemutatót minden adatkészlethez?

Igen. Használja a `MergeToMultiplePresentations` metódust, és mentse el minden generált bemutatót a kezelőben. A kezelő minden adatkészlethez egymás után meghívásra kerül.

### Egyesíthetem az összes adatkészletet egy bemutatóba?

Igen. Használja a `MergeToSinglePresentation` metódust. Ez egyetlen kimeneti bemutatót hoz létre, amely a sablondiák másolatát tartalmazza minden adatkészlethez, az adatforrás sorrendjében.

### Létrehozhatok adatforrást fájl mentése nélkül?

Igen. Létrehozhat `MailMergeDataSource`‑t a kódban, adatkészleteket adhat hozzá, és mezőket tölthet fel a `AddText`‑szal. Ez akkor hasznos, ha az adatok már az alkalmazásban rendelkezésre állnak.

### A levélösszevonás a fájlkiterjesztéstől észleli a formátumot?

Nem. A formátumot a fájl tartalma alapján állapítják meg, így egy támogatott adatforrás nem igényel meghatározott fájlkiterjesztést.

### Olvashatok adatot olyan adatfolyamból, amely nem támogatja a keresést?

Igen. A levélösszevonás támogatja a nem kereshető (non‑seeking) adatfolyamokat.

### Mi történik, ha az adatforrás üres vagy nem tartalmaz adatkészleteket?

Az adatforrásnak legalább egy adatkészletet kell tartalmaznia. Győződjön meg róla, hogy a művelet indítása előtt legalább egy rekordot tartalmaz.

### Mi történik, ha az adatforrás formátuma érvénytelen?

Ha a tartalom nem ismerhető fel támogatott formátumként, `NotSupportedException` keletkezik. Ha a tartalom felismerésre kerül, de hibás, `InvalidDataException` keletkezik. A kivétel üzenete információt ad a hiba helyéről.

### Használhatom a generált bemutatót a kezelő visszatérése után?

A `MergeToMultiplePresentations` kezelőnek átadott bemutató a levélösszevonás tulajdona, és a kezelő visszatérése után eldobásra kerül. Mentse el, vagy másolja a szükséges adatot a kezelőn belül, és ne tartson meg hivatkozást vagy ne dobja el kézzel.

### A kezelő párhuzamosan hívódik meg?

Nem. A generált bemutatók sorban, a hívó szálon kerülnek feldolgozásra. Egyszerre csak egy generált bemutató van a memóriában, így ez a megközelítés nagy adatforrások esetén is megfelelő.

### Mi történik, ha kivétel történik a kezelőben?

A összevonási művelet leáll, és a kivétel változatlanul továbbadódik a hívónak. A már feldolgozott bemutatók érintetlenek, a maradék adatkészletek nem kerülnek feldolgozásra.

### Használhatom a mezőértékeket kimeneti fájlnevek generálásához?

Igen. A kezelő az aktuális adatkészletet adja át argumentumként. A `GetText`‑tel lekérheti a mezőket, és a kimeneti fájlnevekhez felhasználhatja. Győződjön meg róla, hogy az értékek érvényesek a célkörnyezet fájlneveihez.