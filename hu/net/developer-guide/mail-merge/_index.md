---
title: Prezentáció személyre szabásának automatizálása Mail Merge-szel
linktitle: Mail Merge
type: docs
weight: 233
url: /hu/net/mail-merge/
keywords:
- Mail Merge
- prezentáció személyre szabása
- prezentációs sablon
- szöveghelyettesítők
- adatforrás
- CSV
- Excel
- XLSX
- JSON
- XML
- adatok összeolvasztása
- prezentációk generálása
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan használja a Mail Merge-t az Aspose.Slides for .NETben a prezentációs sablonok adatfeltöltéséhez, és hogyan generál személyre szabott PowerPoint előadásokat CSV, Excel, JSON és XML forrásokból."
---
## **Mail Merge PowerPoint előadásokban**

Az Aspose.Slides for .NET lehetővé teszi, hogy sablon és adatforrás felhasználásával automatikusan PowerPoint előadásokat generáljon. A Mail Merge kitölti a sablonhelyettesítőket adatként, és vagy egyetlen előadást hoz létre, amely ismételt sablon diákból áll minden adatkészlethez, vagy egy külön előadást minden adatkészlethez.

Ez a funkció hasznos termékkatalógusok, személyre szabott előadások, jelentések, bizonyítványok, ajánlatok, árlisták és egyéb dokumentumok generálásához, ahol az előadás felépítése ugyanaz, a tartalom pedig változik.

![Mail Merge: before and after](mail-merge-before-after.png)


## **A Mail Merge működése**

A Mail Merge egy PowerPoint előadást használ sablonként, és a helyettesítőket az adatforrás értékeivel cseréli le.

![Mail Merge workflow](mail-merge-workflow.png)

A helyettesítő egy mező neve, amelyet dupla kapcsos zárójelek közé tesznek, például `{{title}}` vagy `{{price}}`. A helyettesítők elhelyezhetők szövegdobozokban, táblázatcellákban, csoportosított alakzatokban és előadói jegyzetekben.

Például egy sablon dia a következő szöveget tartalmazhatja:

- `Termék: {{title}}`
- `Ár: {{price}}`
- `Leírás: {{description}}`

Ha az adatforrás a következő értékeket tartalmazza:

| Mező | Érték |
|---|---|
| title | Laptop X1 |
| price | $999 |
| description | 14-inch display, 16 GB RAM |

A Mail Merge lecseréli a helyettesítőket a megfelelő értékekre, és egy olyan diát hoz létre, amely a tényleges termékinformációkat tartalmazza.

A mezőnevek nem tesznek különbséget a kis- és nagybetűk között, így a `{{title}}` és a `{{Title}}` ugyanarra a mezőre hivatkozik.

A helyettesítők cseréjére a következő szabályok vonatkoznak:

- A helyettesítőket a diákon, beleértve a csoportosított alakzatokat és táblázatcellákat, valamint a jegyzetekben cserélik.
- A master‑diákon és elrendezési diákon lévő helyettesítőket nem cserélik.
- Egy olyan helyettesítő, amelyhez a mező nem szerepel az adatkészletben, változatlan marad.
- Egy üres mezőérték a helyettesítőt egy üres karakterlánccal helyettesíti.
- A beillesztett szöveg az első karakter formázását örökli a helyettesítőből.
- Az értékek nem tartalmazhatnak helyettesítő szöveget, mivel a beillesztett szöveg újból feldolgozható és egy másik mező által cserélhető.

Az eredeti sablon előadást a merge művelet során nem módosítják, és legalább egy diát kell tartalmaznia.


## **Támogatott adatforrások**

A Mail Merge két módon biztosít adatbevitelre lehetőséget:

- Programozottan hozhat létre adatforrást a `IMailMergeDataSource` használatával.
- CSV, XLSX, JSON vagy XML fájlból vagy adatfolyamból olvashat adatokat.

Az adatformátumot a tartalma alapján határozzák meg, nem a fájlkiterjesztés alapján. A nem kereshető (non‑seekable) adatfolyamok is támogatottak.

Az adatforrásnak legalább egy adatkészletet kell tartalmaznia. Minden adatkészlet a sablon egy példányát jelenti, amelyet a saját értékeivel töltenek fel.

Ha a tartalom nem ismerhető fel támogatott formátumként, `NotSupportedException` kerül dobásra. Ha a tartalom felismert, de nem felel meg a formátumkövetelményeknek, `InvalidDataException` kerül dobásra. A kivétel üzenete tartalmazza a hiba helyét az adatokban.

### **JSON**

A JSON adatforrásnak gyökérobjektummal kell rendelkeznie, amely egy `sets` tömböt tartalmaz. A tömb minden eleme egy adatkészletet képvisel, és `fields` tömböt kell, hogy tartalmazzon. Minden mezőnek `name` és `value` karakterlánc kell legyen.

Az opcionális `version` tulajdonságnak `"1.0"`‑nak kell lennie, az opcionális `type` tulajdonságnak egy mező esetén `"text"`‑nek. A tulajdonságnevek kis‑ és nagybetűérzékenyek. Ismeretlen tulajdonságok figyelmen kívül maradnak.

A JSON adat UTF‑8‑ként vagy (ha a fájl BOM‑mal kezdődik) UTF‑16‑ként kerül beolvasásra.

A következő példa két adatkészletet tartalmaz:

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

Az XML adatforrásnak `template` gyökérelemet kell tartalmaznia, amelyen belül a `sets` elem található. Minden `set` elem `field` elemeket tartalmaz, és minden mezőnek `name` és `value` elemekkel kell rendelkeznie.

Az üres `value` elem üres karakterláncként kezelendő. Az elemek nevei kis‑ és nagybetűérzékenyek. Ismeretlen elemek és megjegyzések figyelmen kívül maradnak. A kódolást az XML deklaráció határozza meg. DTD‑k nem engedélyezettek.

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

A CSV adatok értéselválasztóként pontosvesszőt használnak.

Az első sor mezőneveket tartalmaz, és az első üres mezőnévig tart. Minden további sor egy adatkészletet jelent. Az adat a első üres sorban ér véget.

A következő szabályok érvényesek:

- A sor végén hiányzó értékek üres karakterláncként kezelendők.
- A meghatározott mezőneveken túl lévő értékek figyelmen kívül maradnak.
- A pontosvesszőt, idézőjelet vagy sortörést tartalmazó értéket idézőjelek közé kell tenni.
- Az idézőjelek a idézőjeles értéken belül megduplázandók.
- Az adat UTF‑8‑ként vagy (ha BOM‑mal kezdődik) UTF‑16‑ként olvasandó.

Példa:

```csv
title;price;description
Laptop X1;$999;"14"" display; 16 GB RAM"
Tablet S2;$499;
```

### **XLSX**

Az XLSX adatot az első munkalapról olvassák be.

A munkalap szabályai megegyeznek a CSV‑éval:

- Az első sor mezőneveket tartalmaz, és az első üres celláig tart.
- Minden további sor egy adatkészletet jelent.
- Az adat az első üres sorban ér véget.
- Az üres cellákat üres karakterláncként kezelik.
- A numerikus értékeket a kulturálisan invariant módon szöveggé konvertálják.

## **Egyetlen előadás létrehozása**

A `MergeToSinglePresentation` metódus egy olyan előadást hoz létre, amely a sablon diáinak másolatát tartalmazza minden adatkészlethez. Minden másolat a megfelelő adatokkal lesz feltöltve.

Az adatkészletek sorrendje határozza meg a diacsoportok sorrendjét a kimeneti előadásban.

### **Adatok egy fájlból való összefésülése**

Az alábbi példa betölti a sablont és egy JSON adatfájlt, egyetlen előadást hoz létre, amely a minden adatkészlethez tartozó diákat tartalmaz, és elmenti az eredményt.

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

Az adatot adatfolyamból is be lehet olvasni. Az adatfolyam a jelenlegi pozíciójától kezdve kerül olvasásra, és a Mail Merge művelet nem zárja be.

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

### **Adatforrás létrehozása kódból**

Programozottan építhet adatforrást a `MailMergeDataSource` és a `MailMergeDataSet` használatával. Minden rekordhoz adjon adatkészletet, és definiálja a mezőket a `AddText` metódussal.

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

Ebben a példában a sablon diák kétszer ismétlődnek: egyszer a laptop, egyszer a tablet számára. A helyettesítőket a megfelelő adatkészletben definiált értékekkel töltik fel.

## **Több előadás létrehozása**

Ha minden adatkészlethez külön előadást szeretne, használja a `MergeToMultiplePresentations` metódust.

Ez a metódus az adatkészleteket egyesével dolgozza fel, sablonból hoz létre egy előadást, feltölti az aktuális adatokkal, majd a keletkezett előadást átadja egy kezelőnek.

A kezelőt minden adatkészlet esetén egyszer hívják meg, az eredeti adat sorrendjében.

### **Minden előadás mentése**

Az alábbi példa CSV fájlból olvas adatokat, és minden generált előadást külön fájlként ment.

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

A `args.Index` tulajdonság a jelenlegi adatkészlet null‑alapú indexét adja vissza. A példában ezt használják sorozatos fájlnevek generálására, a `product_1.pptx`‑től indulva.

Az adatot adatfolyamból is be lehet olvasni:

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

### **Adatkészlet értékek használata fájlnevekhez**

A kezelő megkapja a generált előadást és az azt létrehozó adatkészlet információit. Az adatkészlet értékeivel értelmes fájlneveket építhet fel.

Például az alábbi kód a termék címét használja a fájl elmentéséhez:

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

A `DataSet` tulajdonság visszaadja azt az adatkészletet, amely a jelenlegi előadást kitöltötte. A `GetText` metódus egy megadott mező értékét adja vissza, vagy `null`‑t, ha a mező nem létezik.

Ez lehetővé teszi az adatértékek felhasználását fájlnevekhez, a kimenet szervezéséhez vagy további feldolgozáshoz a kezelőben.

## **Generált előadások kezelése**

A `MergeToMultiplePresentations` a `MailMergedPresentationHandler` delegálttal dolgozza fel az egyes generált előadásokat.

A kezelő két argumentumot kap:

- `presentation` — a sablonból létrehozott és a jelenlegi adatkészlettel feltöltött előadás.
- `args` — információk a generált előadásról, beleértve az adatkészlet indexét és magát az adatkészletet.

A generált előadást a Mail Merge művelet birtokolja, és a kezelő visszatérése után azonnal eldobja. Ezért menteni kell, vagy másolni a szükséges adatokat a kezelőn belül, és nem szabad referenciát megtartani a kezelés után, illetve manuálisan eldobni sem.

A kezelő a hívó szálon, egy előadást egyszerre, az adatkészletek sorrendjében fut le. Egyszerre csak egy generált előadás van memóriában, ami alkalmas nagy adatforrások feldolgozására anélkül, hogy az összes előadást egyszerre kellene tárolni.

Ha a kezelő kivételt dob, a Mail Merge művelet leáll, és a kivétel változatlanul továbbítódik a hívónak. Az eddig feldolgozott előadások érintetlenek, a maradék adatkészletek nem kerülnek feldolgozásra.

Az alábbi példa a generált előadásokat egy dedikált könyvtárba menti:

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

## **Mail Merge adatok kezelése**

A `MailMergeDataSource` osztály egy rendezett gyűjteményt képvisel adatkészletekből. Használható adatprogramozásra, az adatkészletek számának lekérdezésére és egyedi adatkészletek index szerinti elérésére.

### **Adatkészletek számának lekérdezése**

A `Count` tulajdonság visszaadja a forrásban lévő adatkészletek számát.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine("Presentations to create: " + source.Count);
```

### **Adatkészlet elérése index alapján**

Az `Item(int)` tulajdonság lehetővé teszi egy adatkészlet elérését a megadott null‑alapú indexen.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine(source[1].GetText("title"));
```

Ez a példa a második adatkészlet címét kérdezi le.

### **Szövegmezők hozzáadása**

Az `AddText` metódus egy névvel ellátott szövegmezőt ad egy adatkészlethez. A mező értéke minden megfelelő helyettesítőt a sablonban lecserél.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet dataSet = source.AddDataSet();
dataSet.AddText("title", "Laptop X1");
dataSet.AddText("subtitle", string.Empty);
```

Az üres érték eltávolítja a megfelelő helyettesítőt a végső szövegből. Ha a mező nincs hozzáadva az adatkészlethez, a helyettesítő változatlan marad.

### **Szövegmezők olvasása**

A `GetText` metódus egy mező értékét adja vissza név alapján. A mezőnevek nem tesznek különbséget a kis‑ és nagybetűk között.

```csharp
IMailMergeDataSet dataSet = source[0];

string title = dataSet.GetText("title");
string price = dataSet.GetText("price");
```

Ha a mező nem létezik, vagy a megadott mezőnév `null`, a `GetText` `null`‑t ad vissza.

## **Összefoglalás**

A Mail Merge az Aspose.Slides for .NET‑ben kényelmes módot kínál adat‑vezérelt előadások előre definiált sablonból történő generálására.

Használható:

- előadássablonok adatforrások értékeivel való feltöltésére,
- egyetlen előadás létrehozására, amely ismételt sablon diákot tartalmaz több adatkészlethez,
- külön előadás létrehozására minden adatkészlethez,
- adatolvasásra CSV, XLSX, JSON és XML fájlokból vagy adatfolyamokból,
- adatforrások közvetlen kódból történő felépítésére,
- generált előadások sorozatos feldolgozására és mentésére kezelő segítségével.

Az újrahasználható sablonok és strukturált adatok kombinálásával automatizálható a nagy számú előadás létrehozása, miközben a sablon tervezése és az adatok feldolgozása különálló marad.

## **Gyakran ismételt kérdések**

**Használhatom ugyanazt a helyettesítőt többször a sablonban?**

Igen. A helyettesítő minden előfordulása, amelynek a mezőneve megegyezik, a jelenlegi adatkészlet megfelelő értékével lesz helyettesítve.

**A mezőnevek kis‑ és nagybetűérzékenyek?**

Nem. A helyettesítő és adatmezőnevek nem tesznek különbséget a kis‑ és nagybetűk között. Például a `{{title}}`, `{{Title}}` és `{{TITLE}}` ugyanarra a mezőre hivatkoznak.

**Mi történik, ha egy mező hiányzik az adatkészletből?**

Ha az adatkészlet nem tartalmazza a helyettesítő által hivatkozott mezőt, az a helyettesítő változatlan marad a generált előadásban.

**Mi történik, ha egy mezőnek üres az értéke?**

Az üres mezőérték a helyettesítőt egy üres karakterlánccal helyettesíti. A helyettesítő szövege eltűnik, és nem marad szöveg a helyén.

**Megőrizhetem a helyettesítő formázását a cserénél?**

A csere szövege az első karakter formázását örökli a helyettesítőből. Alkalmazza a kívánt formázást a helyettesítő szövegre a sablonban a merge előtt.

**A Mail Merge helyettesítőket cserél a master‑ vagy layout‑diákon?**

Nem. A Mail Merge csak a diákon lévő támogatott tartalmakban (alakzatok, csoportosított alakzatok, táblázatcellák, jegyzetek) cseréli a helyettesítőket. A master‑ és layout‑diák helyettesítői nem kerülnek cserére.

**Módosul a sablon előadás a merge során?**

Nem. Az eredeti sablont a merge művelet nem módosítja. Újra felhasználható ugyanazból vagy különböző adatforrásokból történő előadások generálásához.

**Létrehozhatok külön előadást minden adatkészlethez?**

Igen. Használja a `MergeToMultiplePresentations` metódust, és mentse az egyes generált előadásokat a kezelőben. A kezelő minden adatkészlethez sorban meghívásra kerül.

**Összevonhatom az összes adatkészletet egyetlen előadásba?**

Igen. Használja a `MergeToSinglePresentation` metódust. Ez egyetlen kimeneti előadást hoz létre, amely a sablon diák másolatát tartalmazza minden adatkészlethez, az adatforrás sorrendjében.

**Használhatok adatforrást anélkül, hogy fájlba menteném?**

Igen. Létrehozhat `MailMergeDataSource`‑t kódból, hozzáadhat adatkészleteket, és mezőket tölthet fel `AddText`‑el. Hasznos, ha az adatok már rendelkezésre állnak az alkalmazásában.

**A Mail Merge a fájlkiterjesztésből határozza meg az adatformátumot?**

Nem. Az adatformátumot a tartalom határozza meg, ezért a támogatott adatforrásnak nem kell konkrét fájlkiterjesztést használni.

**Olvashatok adatot olyan adatfolyamból, amely nem támogatja a keresést?**

Igen. A Mail Merge támogatja a nem kereshető (non‑seekable) adatfolyamokat is.

**Mi történik, ha az adatforrás üres vagy nem tartalmaz adatkészletet?**

Az adatforrásnak legalább egy adatkészletet kell tartalmaznia. Győződjön meg róla, hogy legalább egy rekord van, mielőtt elindítaná a merge műveletet.

**Mi történik, ha az adatforrás formátuma érvénytelen?**

Ha a tartalom nem ismerhető fel egyik támogatott adatformátumként sem, `NotSupportedException` dobódik. Ha felismert, de hibás a formátum, `InvalidDataException` dobódik. A kivétel üzenete tartalmazza a hiba pontos helyét.

**Használhatom a generált előadást a kezelő visszatérése után?**

A `MergeToMultiplePresentations` kezelőnek átadott előadást a Mail Merge birtokolja, és a kezelő visszatérése után azonnal eldobja. Mentse el, vagy másolja a szükséges adatokat a kezelőben, és ne tartsa meg vagy dobja el saját kezűleg.

**A kezelő párhuzamosan hívódik?**

Nem. A generált előadások sorozatosan, a hívó szálon kerülnek feldolgozásra, egyszerre csak egy előadás van memóriában, így nagy adatforrások esetén is hatékony a memóriahasználat.

**Mi történik, ha kivétel keletkezik a kezelőben?**

A merge művelet leáll, a kivétel változatlanul továbbítódik a hívónak. Az eddig feldolgozott előadások érintetlenek, a további adatkészletek nem kerülnek feldolgozásra.

**Használhatom a mezőértékeket a kimeneti fájlnevek generálásához?**

Igen. A kezelő a `args` argumentumon keresztül biztosítja a jelenlegi adatkészletet. A `GetText` segítségével lekérdezheti a mezőket, és minden generált előadáshoz építhet egyedi fájlnevet. Győződjön meg arról, hogy az értékek érvényesek a célkörnyezet fájlnévre vonatkozó szabályaival.