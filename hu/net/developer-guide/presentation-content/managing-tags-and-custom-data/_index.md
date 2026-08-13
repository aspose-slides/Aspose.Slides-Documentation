---
title: Címkék és egyéni adatok kezelése prezentációkban .NET-ben
linktitle: Címkék és egyéni adatok
type: docs
weight: 300
url: /hu/net/managing-tags-and-custom-data/
keywords:
- dokumentum tulajdonságok
- címke
- egyéni adat
- egyéni XML
- egyéni XML rész
- XML metaadatok
- ItemId
- címke hozzáadása
- páros értékek
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan kezelhetők a címkék és az egyéni XML adatok PowerPoint prezentációkban az Aspose.Slides for .NET segítségével, beleértve a hozzáadást, olvasást, frissítést, auditálást és az egyéni XML részek eltávolítását."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan működik az Aspose.Slides a címkékkel és az egyedi adatokkal a PowerPoint‑prezentációkban. A prezentációra jellemző adatokat címkék vagy egyéni XML‑részek formájában tárolhatjuk. A címkék egyszerű kulcs‑érték karakterlánc párok, míg az egyéni XML‑részek strukturált metaadatokat és alkalmazásspecifikus XML‑payload‑okat tárolhatnak.

Az Aspose.Slides API‑kat kínál egyéni XML‑részek hozzáadásához, olvasásához, frissítéséhez, auditálásához és eltávolításához a prezentáció, dia és alakzat szintjén. Az egyéni XML‑részek hasznosak integrációk számára, amelyek információkat tárolnak, például dokumentum‑kezelési azonosítókat, munkafolyamat‑állapotot, megfelelőségi metaadatokat, sablon‑kötési adatokat vagy más strukturált alkalmazásadatokat egy prezentációban.

## **Adattárolás a prezentációs fájlokban**

A PPTX fájlok – a `.pptx` kiterjesztésű fájlok – a PresentationML formátumban tárolódnak, amely az Office Open XML specifikáció része. Az Office Open XML meghatározza a csomagfelépítést és a kapcsolatok struktúráját, amely a prezentáció tartalmát és a kapcsolódó adatokat tárolja.

Egy prezentáció több, kapcsolatokkal összekapcsolt részből áll. Például egy dia rész tartalmazza egyetlen dia tartalmát, és kifejezett kapcsolatokat tartalmazhat más részekkel, amelyeket az ISO/IEC 29500 definiál.

Az egyéni adatokat tárolhatjuk címkék ([ITagCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/itagcollection)) vagy egyéni XML‑részek ([ICustomXmlPartCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/icustomxmlpartcollection)) formájában. Mindkettő elérhető az [`ICustomData`](https://reference.aspose.com/slides/hu/net/aspose.slides/icustomdata/) interfészen keresztül.

{{% alert color="info" %}}
A címkék egyszerű karakterlánc kulcs‑érték párokat tárolnak. Az egyéni XML‑részek strukturált XML‑adatokat tárolnak, és hozzárendelhetők egy prezentációhoz, diahoz vagy alakzathoz.
{{% /alert %}}

## **Egyéni XML‑részek kezelése**

`[`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/hu/net/aspose.slides/icustomdata/customxmlparts/)` tulajdonsága visszaadja a megadott prezentációs objektumhoz kapcsolódó egyéni XML‑részek gyűjteményét. Például:

- `presentation.CustomData.CustomXmlParts` a prezentációhoz közvetlenül kapcsolódó egyéni XML‑részeket tartalmazza.
- `slide.CustomData.CustomXmlParts` egy adott diához kapcsolódó egyéni XML‑részeket tartalmaz.
- `shape.CustomData.CustomXmlParts` egy adott alakzathoz kapcsolódó egyéni XML‑részeket tartalmaz.

Használja a [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/allcustomxmlparts/) metódust, ha a prezentációban lévő összes egyéni XML‑részt ellenőrizni szeretné, függetlenül attól, hogy hol kapcsolódnak.

### **Egyéni XML‑rész hozzáadása a prezentációhoz**

Használja a [`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/hu/net/aspose.slides/icustomxmlpartcollection/add/) metódust XML‑adatok hozzáadásához egy egyéni XML‑rész gyűjteményhez. Az XML-nek érvényesnek és nem üresnek kell lennie.

Az alábbi példa strukturált metaadatokat ad a prezentációszintű egyéni adatok gyűjteményéhez:

```csharp
using System;
using Aspose.Slides;

var customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

using var presentation = new Presentation();
var customXmlPart = presentation.CustomData.CustomXmlParts.Add(customXmlContent);

// Az Add automatikusan hozzárendel egy azonosítót. Csak szükség esetén állítson be egy konkrét GUID-et.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

Az `Add` metódus XML‑t is elfogadhat bájt‑tömbként vagy stream‑ként, ami akkor hasznos, ha az XML‑tartalom már bináris formában rendelkezésre áll.

### **Egyéni XML‑rész hozzáadása diához vagy alakzathoz**

Az egyéni XML‑adatok egy adott diához vagy alakzathoz is kapcsolhatók a teljes prezentáció helyett. Ez akkor hasznos, ha a metaadat csak egy objektumot ír le, például egy sablonkulcsot, külső rekord azonosítót vagy kötési információt.

Az alábbi példa egy egyéni XML‑részt ad egy diához, és egy másikat egy alakzathoz:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.CustomData.CustomXmlParts.Add(
    "<slideMetadata xmlns=\"urn:example:slides\">" +
        "<templateKey>TitleSlide</templateKey>" +
    "</slideMetadata>");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

shape.TextFrame.Text = "Customer data";
shape.CustomData.CustomXmlParts.Add(
    "<shapeMetadata xmlns=\"urn:example:shapes\">" +
        "<recordId>CRM-4281</recordId>" +
    "</shapeMetadata>");

presentation.Save("object_custom_xml.pptx", SaveFormat.Pptx);
```

Az a szint, amelyen a rész hozzáadásra kerül, meghatározza, hogy melyik objektum `CustomData.CustomXmlParts` gyűjteménye tartalmazza a részre mutató kapcsolatot. A prezentációszintű adat a dokumentum‑szintű metaadatokhoz megfelelő, a dia‑szintű adat egy adott diához tartozó információkhoz, a alakzat‑szintű adat pedig egyetlen alakzathoz kapcsolódó metaadatokhoz.

### **Az összes egyéni XML‑rész listázása és auditálása**

Használja a [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/allcustomxmlparts/) metódust az összes egyéni XML‑rész lekérdezéséhez egy prezentációból. Minden [`ICustomXmlPart`](https://reference.aspose.com/slides/hu/net/aspose.slides/icustomxmlpart/) megjeleníti az azonosítóját, az XML‑tartalmát és a kapcsolódó névtér‑sémákat.

Az alábbi példa felsorolja az összes egyéni XML‑részt és azok névtér‑sémáit:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    Console.WriteLine("ItemId: " + customXmlPart.ItemId);
    Console.WriteLine("XML:");
    Console.WriteLine(customXmlPart.XmlAsString);

    foreach (var namespaceSchema in customXmlPart.NamespaceSchemas)
    {
        Console.WriteLine("Namespace schema: " + namespaceSchema);
    }

    Console.WriteLine();
}
```

Az `[`ICustomXmlPart.NamespaceSchemas`](https://reference.aspose.com/slides/hu/net/aspose.slides/icustomxmlpart/namespaceschemas/)` visszaadja az egyéni XML‑részhez kapcsolódó XML‑sémákat. Ez az információ hasznos lehet külső rendszerek által előállított XML‑t tartalmazó prezentációk auditálásakor.

### **XML‑tartalom és ItemId olvasása és frissítése**

Használja a [`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/hu/net/aspose.slides/icustomxmlpart/xmlasstring/) tulajdonságot az XML UTF‑8 szövegként történő kezeléséhez, vagy a [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/hu/net/aspose.slides/icustomxmlpart/xmldata/) tulajdonságot a nyers XML‑bájtok kezeléséhez. Mindkét tulajdonság olvasható és frissíthető.

A [`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/hu/net/aspose.slides/icustomxmlpart/itemid/) tulajdonság a GUID‑et tartalmazza, amely az egyéni XML‑részt az Office Open XML dokumentumban azonosítja. Szükség esetén megváltoztatható, ha egy integrációnak új azonosítóra van szüksége.

Az alábbi példa frissíti az XML‑tartalmat és az azonosítót:

```csharp
using System;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlPart = presentation.AllCustomXmlParts[0];

// Olvassa el a jelenlegi XML-t szövegként.
var currentXmlContent = customXmlPart.XmlAsString;
Console.WriteLine(currentXmlContent);

// Frissítse az XML-t UTF-8 karakterláncként.
customXmlPart.XmlAsString =
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Approved</workflowState>" +
    "</metadata>";

// Az XmlData ugyanazt az XML-t tartalmazza nyers bájtokként.
var customXmlData = customXmlPart.XmlData;
Console.WriteLine(Encoding.UTF8.GetString(customXmlData));

// Cserélje le az azonosítót, ha az integráció megköveteli.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("updated_custom_xml.pptx", SaveFormat.Pptx);
```

Az `XmlAsString` vagy `XmlData` értékadása során adjon meg érvényes, nem üres XML‑t. Az egyiket vagy a másikat válassza attól függően, hogy az alkalmazás elsősorban karakterláncokkal vagy bájtadatokkal dolgozik.

### **Egyéni XML‑rész eltávolítása**

Az Aspose.Slides több módot kínál az egyéni XML‑adatok eltávolítására:

- `[`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/hu/net/aspose.slides/icustomxmlpart/remove/)` eltávolítja az egyéni XML‑részt a prezentációból.
- `[`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/hu/net/aspose.slides/icustomxmlpartcollection/remove/)` egy adott részt távolít el egy egyéni XML‑rész gyűjteményből.
- `[`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/hu/net/aspose.slides/icustomxmlpartcollection/removeat/)` a megadott indexű részt távolítja el a gyűjteményből.
- `[`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/hu/net/aspose.slides/icustomxmlpartcollection/clear/)` az adott gyűjtemény összes részét eltávolítja.

Az alábbi példa egy prezentációszintű egyéni XML‑részt távolít el hivatkozással:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlParts = presentation.CustomData.CustomXmlParts;

if (customXmlParts.Count > 0)
{
    var customXmlPart = customXmlParts[0];
    customXmlParts.Remove(customXmlPart);
}

presentation.Save("custom_xml_removed.pptx", SaveFormat.Pptx);
```

Ha már rendelkezik egy `ICustomXmlPart` példánnyal, és a prezentációból szeretné eltávolítani azt, ahelyett, hogy egy adott gyűjteményt célozna meg, hívja meg a `customXmlPart.Remove()` metódust.

Elemet index alapján is eltávolíthat:

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **Az összes egyéni XML‑rész törlése egy gyűjteményből**

Használja a `Clear` metódust, ha egy adott prezentációs objektumhoz kapcsolódó összes egyéni XML‑részt el akarja távolítani.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

`Clear` csak a kijelölt gyűjteményre hat. Például egy dia gyűjteményének törlése nem érinti a prezentációszintű vagy alakzatszintű gyűjteményeket.

Az összes egyéni XML‑rész eltávolításához a prezentációból, iteráljon a `AllCustomXmlParts` gyűjteményen, és távolítsa el minden egyes részt:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **Kapcsolt vagy megosztott egyéni XML‑részek kezelése**

Egy Office Open XML prezentációban ugyanaz a egyéni XML‑rész több prezentációs objektumról is hivatkozható. Például egy meglévő fájl tartalmazhat kapcsolatokat több diából vagy alakzatból az ugyanazon alapul szolgáló egyéni XML‑résre.

Egy megosztott részt egy adatobjektumként kell kezelni, amelyre több hivatkozás mutat:

- Az `XmlAsString`, `XmlData` vagy `ItemId` frissítése módosítja az alapul szolgáló egyéni XML‑részt, így a változás minden hivatkozási helyen érvényesül.
- `ItemId` használható ugyanazon egyéni XML‑rész azonosítására az objektumszintű gyűjtemények auditálása során.
- Egy rész eltávolítása egy adott `CustomXmlParts` gyűjteményből csak azt a gyűjteményt érinti. Használja az `ICustomXmlPart.Remove()` metódust, ha magát a részt szeretné eltávolítani a prezentációból.
- A megosztott rész törlése vagy cseréje előtt ellenőrizze az objektumszintű gyűjteményeket, hogy megtudja, más diák vagy alakzatok továbbra is hivatkoznak‑e rá.

Az `Add` túlterhelések új egyéni XML‑részt hoznak létre XML‑tartalomból; meglévő `ICustomXmlPart` objektumot nem fogadnak el. Ezért a megosztott kapcsolatok leggyakrabban akkor jelentkeznek, amikor már tartalmazott részekkel rendelkező prezentációkat töltenek be.

Az alábbi példa auditálja a prezentáció‑, dia‑ és alakzatszintű gyűjteményeket `ItemId` alapján, és jelzi a több helyen hivatkozott részeket:

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var referencesByItemId = new Dictionary<Guid, List<string>>();

var registerCustomXmlParts = (string ownerName, ICustomXmlPartCollection customXmlParts) =>
    {
        foreach (var customXmlPart in customXmlParts)
        {
            if (!referencesByItemId.ContainsKey(customXmlPart.ItemId))
            {
                referencesByItemId[customXmlPart.ItemId] = new List<string>();
            }

            referencesByItemId[customXmlPart.ItemId].Add(ownerName);
        }
    };

registerCustomXmlParts("Presentation", presentation.CustomData.CustomXmlParts);

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    registerCustomXmlParts("Slide " + (slideIndex + 1), slide.CustomData.CustomXmlParts);

    for (var shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.CustomData.CustomXmlParts);
    }
}

foreach (var referenceEntry in referencesByItemId)
{
    if (referenceEntry.Value.Count > 1)
    {
        Console.WriteLine("Shared custom XML part: " + referenceEntry.Key);

        foreach (var ownerName in referenceEntry.Value)
        {
            Console.WriteLine("  Referenced by: " + ownerName);
        }
    }
}
```

Ez a fajta auditálás hasznos, mielőtt módosítana vagy törölne egyéni XML‑adatokat külső rendszerek által létrehozott prezentációkban, mivel ugyanaz a metaadat‑rész több kapcsolatban is részt vehet.

## **Címkék értékeinek lekérése**

A diákban egy címke a `IDocumentProperties.Keywords` tulajdonságnak felel meg. Ez a mintakód bemutatja, hogyan lehet lekérni egy címke értékét az Aspose.Slides for .NET segítségével a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation):

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **Címkék hozzáadása a prezentációkhoz**

Az Aspose.Slides lehetővé teszi címkék hozzáadását a prezentációkhoz. Egy címke általában két elemből áll:

- az egyéni tulajdonság neve, például `MyTag`;
- az egyéni tulajdonság értéke, például `My Tag Value`.

Ha a prezentációkat egy adott szabály vagy tulajdonság alapján szeretné besorolni, hozzáadhat címkéket erre a célra. Például, ha az Észak‑Amerikai országokból származó prezentációkat szeretné csoportosítani, létrehozhat egy "Észak‑Amerikai" címkét, és az adott országot rendelheti hozzá értékként.

Ez a mintakód bemutatja, hogyan adjon címkét egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) objektumhoz az Aspose.Slides for .NET segítségével:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var tags = presentation.CustomData.Tags;
tags["MyTag"] = "My Tag Value";
```

A címkék beállíthatók egy [Slide](https://reference.aspose.com/slides/hu/net/aspose.slides/slide) számára is:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
slide.CustomData.Tags["tag"] = "value";
```

Vagy egy egyedi [Shape](https://reference.aspose.com/slides/hu/net/aspose.slides/shape) esetén:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
shape.TextFrame.Text = "My text";
shape.CustomData.Tags["tag"] = "value";
```

### **Korlátozások**

A `CustomData.Tags` gyűjteményen keresztül hozzáadott címkék csak a PowerPoint‑fájlban tárolódnak. Az exportálás PDF‑be történő átalakításkor **nem** kerülnek át a PDF címkeszerkezetbe. Ennek következtében egy címkeként rendelt egyéni azonosító nem kérhető le a címkézett PDF‑ből.

**Megoldás**: A egyéni azonosítót tárolhatja az objektum **Alternatív szövegében** (például `shape.AlternativeText = "MyId"`). PDF‑exportálás után az Alternatív szöveg megjelenhet a PDF címkeszerkezetben.

## **GYIK**

**Eltávolíthatok minden címkét egy prezentációból, diádból vagy alakzatból egy művelettel?**

Igen. A [tag collection](https://reference.aspose.com/slides/hu/net/aspose.slides/tagcollection/) támogatja a [Clear](https://reference.aspose.com/slides/hu/net/aspose.slides/tagcollection/clear/) műveletet, amely egyszerre törli az összes kulcs‑érték párt.

**Hogyan törölhetek egyetlen címkét a neve alapján anélkül, hogy végig iterálnék a teljes gyűjteményen?**

Használja a [Remove(name)](https://reference.aspose.com/slides/hu/net/aspose.slides/tagcollection/remove/) metódust a [TagCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/tagcollection/) objektumon a címke kulcs szerinti törléséhez.

**Hogyan szerezhetem meg a címkék teljes listáját elemzés vagy szűrés céljából?**

Használja a [GetNamesOfTags](https://reference.aspose.com/slides/hu/net/aspose.slides/tagcollection/getnamesoftags/) metódust a [tag collection](https://reference.aspose.com/slides/hu/net/aspose.slides/tagcollection/); ez egy tömböt ad vissza az összes címkenévvel.

**Hogyan találhatom meg az összes egyéni XML‑részt függetlenül attól, hol vannak tárolva?**

Használja a [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/allcustomxmlparts/) metódust az összes egyéni XML‑rész lekérdezéséhez a prezentációban.

**A `XmlAsString` vagy az `XmlData` használjam egy egyéni XML‑rész frissítéséhez?**

Használja az `XmlAsString`‑t, ha az alkalmazás UTF‑8 XML‑szöveggel dolgozik. Használja az `XmlData`‑t, ha az XML már bájt‑tömbként elérhető, vagy ha a bináris feldolgozás kényelmesebb. Mindkét tulajdonság ugyanannak az egyéni XML‑résznek a tartalmát képviseli.