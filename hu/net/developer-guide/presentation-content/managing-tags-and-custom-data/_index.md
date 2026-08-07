---
title: Címkék és egyedi adatok kezelése prezentációkban .NET-ben
linktitle: Címkék és egyedi adatok
type: docs
weight: 300
url: /hu/net/managing-tags-and-custom-data/
keywords:
- dokumentum tulajdonságok
- címke
- egyedi adatok
- egyedi XML
- egyedi XML rész
- XML metaadat
- ItemId
- címke hozzáadása
- páros értékek
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan kezelhetők a címkék és az egyedi XML adatok PowerPoint prezentációkban az Aspose.Slides for .NET segítségével, beleértve a címkék hozzáadását, olvasását, frissítését, auditálását és az egyedi XML részek eltávolítását."
---
## **Áttekintés**

Ez a cikk ismerteti, hogy az Aspose.Slides hogyan kezel címkéket és egyedi adatokat PowerPoint‑prezentációkban. A prezentáció‑specifikus adatokat címkék vagy egyedi XML‑részek formájában tárolhatjuk. A címkék egyszerű kulcs‑érték karakterlánc párok, míg az egyedi XML‑részek strukturált metaadatokat és alkalmazás‑specifikus XML‑tartalmakat tárolhatnak.

Az Aspose.Slides API‑kat biztosít az egyedi XML‑részek hozzáadásához, olvasásához, frissítéséhez, auditálásához és eltávolításához a prezentáció, dia és alakzat szintjein. Az egyedi XML‑részek hasznosak olyan integrációkhoz, amelyek olyan információkat tárolnak, mint a dokumentum‑kezelő azonosítók, munkafolyamat‑állapot, megfelelőségi metaadatok, sablon‑kötési adatok vagy egyéb strukturált alkalmazás‑adatok a prezentáción belül.

## **Adattárolás a prezentációs fájlokban**

A PPTX fájlok – a „.pptx” kiterjesztésű fájlok – a PresentationML formátumban kerülnek tárolásra, amely az Office Open XML specifikáció része. Az Office Open XML definiálja a csomagstruktúrát és a kapcsolatrendszert, amelyet a prezentáció‑tartalom és a kapcsolódó adatok tárolására használnak.

Egy prezentáció több részből áll, amelyeket kapcsolatok kötnek össze. Például egy dia‑rész tartalmaz egyetlen dia tartalmát, és kifejezett kapcsolatokkal rendelkezhet más részekhez, ahogy azt az ISO/IEC 29500 definiálja.

Az egyedi adatokat tárolhatjuk címkékként ([ITagCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/itagcollection)) vagy egyedi XML‑részekként ([ICustomXmlPartCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/icustomxmlpartcollection)). Mindkettő elérhető a [`ICustomData`](https://reference.aspose.com/slides/hu/net/aspose.slides/icustomdata/) interfészen keresztül.

{{% alert color="primary" %}}
A címkék egyszerű karakterlánc kulcs‑érték párokat tárolnak. Az egyedi XML‑részek strukturált XML‑adatot tárolnak, és egy prezentációhoz, diához vagy alakzathoz kapcsolhatók.
{{% /alert %}}

## **Egyedi XML‑részek kezelése**

A [`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/hu/net/aspose.slides/icustomdata/customxmlparts/) tulajdonság visszaadja az adott prezentációs objektumhoz kapcsolt egyedi XML‑részek gyűjteményét. Például:

- `presentation.CustomData.CustomXmlParts` a prezentációhoz tartozó egyedi XML‑részeket tartalmazza.
- `slide.CustomData.CustomXmlParts` egy adott diához kapcsolt egyedi XML‑részeket tartalmazza.
- `shape.CustomData.CustomXmlParts` egy adott alakzathoz kapcsolt egyedi XML‑részeket tartalmazza.

Használja a [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/allcustomxmlparts/) metódust, ha a prezentációban lévő összes egyedi XML‑részt szeretné áttekinteni, függetlenül attól, hogy hol vannak kapcsolva.

### **Egyedi XML‑rész hozzáadása a prezentációhoz**

Használja a [`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/hu/net/aspose.slides/icustomxmlpartcollection/add/) metódust, hogy XML‑adatot adjon egy egyedi XML‑rész gyűjteményhez. Az XML‑nek érvényesnek és nem üresnek kell lennie.

Az alábbi példa strukturált metaadatot ad a prezentáció‑szintű egyedi adatgyűjteményhez:

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

// A hozzáadás automatikusan hozzárendel egy azonosítót. Egy konkrét GUID-ot csak akkor állítson be, ha szükséges.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

Az `Add` metódus XML‑t byte‑tömbként vagy streamként is elfogadhat, ami akkor hasznos, ha az XML‑tartalom már bináris formában rendelkezésre áll.

### **Egyedi XML‑rész hozzáadása diához vagy alakzathoz**

Az egyedi XML‑adatot egy adott diához vagy alakzathoz is lehet kapcsolni a teljes prezentáció helyett. Ez akkor hasznos, ha a metaadat csak egy objektumot ír le, például egy sablon‑kulcsot, külső rekord‑azonosítót vagy kötési információt.

Az alábbi példa egy egyedi XML‑részt ad egy diához, a másikat egy alakzathoz:

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

Az a szint, ahol a rész hozzáadásra kerül, meghatározza, hogy melyik objektum `CustomData.CustomXmlParts` gyűjteménye tartalmazza a részre mutató kapcsolatot. A prezentáció‑szintű adat a dokumentum‑széles metaadatokhoz, a dia‑szintű adat egy adott diához tartozó információkhoz, míg a alakzat‑szintű adat egy egyedi alakzathoz kötött metaadatokhoz használható.

### **Az összes egyedi XML‑rész listázása és auditálása**

Használja a [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/allcustomxmlparts/) metódust az összes egyedi XML‑rész lekéréséhez a prezentációból. Minden [`ICustomXmlPart`](https://reference.aspose.com/slides/hu/net/aspose.slides/icustomxmlpart/) tartalmazza az azonosítóját, XML‑tartalmát és a kapcsolódó névtér‑sémákat.

Az alábbi példa felsorolja az összes egyedi XML‑részt és azok névtér‑sémáit:

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

A [`ICustomXmlPart.NamespaceSchemas`](https://reference.aspose.com/slides/hu/net/aspose.slides/icustomxmlpart/namespaceschemas/) visszaadja a részhez kapcsolódó XML‑sémákat. Ez az információ hasznos lehet olyan prezentációk auditálásakor, amelyek külső rendszerek által generált XML‑t tartalmaznak.

### **XML‑tartalom és ItemId olvasása és frissítése**

Használja a [`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/hu/net/aspose.slides/icustomxmlpart/xmlasstring/) tulajdonságot az XML‑UTF‑8 szövegként történő kezeléséhez, vagy a [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/hu/net/aspose.slides/icustomxmlpart/xmldata/) tulajdonságot a nyers XML‑byte‑adatokhoz. Mindkét tulajdonság olvasható és írható.

A [`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/hu/net/aspose.slides/icustomxmlpart/itemid/) tulajdonság a GUID‑t tartalmazza, amely az egyedi XML‑részt az Office Open XML dokumentumban azonosítja. Ez az érték módosítható, ha egy integrációnak új azonosítóra van szüksége.

Az alábbi példa frissíti az XML‑tartalmat és az azonosítót:

```csharp
using System;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlPart = presentation.AllCustomXmlParts[0];

// Olvassa be a jelenlegi XML-t szövegként.
var currentXmlContent = customXmlPart.XmlAsString;
Console.WriteLine(currentXmlContent);

// Frissítse az XML-t UTF-8 karakterláncként.
customXmlPart.XmlAsString =
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Approved</workflowState>" +
    "</metadata>";

// Az XmlData ugyanazt az XML-tartalmat nyers bájtokként biztosítja.
var customXmlData = customXmlPart.XmlData;
Console.WriteLine(Encoding.UTF8.GetString(customXmlData));

// Cserélje ki az azonosítót, ha az integráció megköveteli.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("updated_custom_xml.pptx", SaveFormat.Pptx);
```

Az `XmlAsString` vagy `XmlData` beállításakor érvényes, nem üres XML‑t adjon meg. Válasszon egyik reprezentációt a másik helyett attól függően, hogy az alkalmazás főként sztringekkel vagy byte‑adatokkal dolgozik.

### **Egyedi XML‑rész eltávolítása**

Az Aspose.Slides több módot kínál az egyedi XML‑adatok eltávolítására:

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/hu/net/aspose.slides/icustomxmlpart/remove/) eltávolítja az egyedi XML‑részt a prezentációból.
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/hu/net/aspose.slides/icustomxmlpartcollection/remove/) eltávolít egy adott részt az egyedi XML‑rész gyűjteményből.
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/hu/net/aspose.slides/icustomxmlpartcollection/removeat/) eltávolítja a részt a megadott gyűjtemény‑indexnél.
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/hu/net/aspose.slides/icustomxmlpartcollection/clear/) törli az összes részt egy adott gyűjteményből.

Az alábbi példa egy prezentáció‑szintű egyedi XML‑részt referenciával távolít el:

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

Ha már rendelkezik egy `ICustomXmlPart` objektummal, és azt a prezentációból szeretné eltávolítani a konkrét gyűjtemény helyett, hívja a `customXmlPart.Remove()` metódust.

Elemet index alapján is eltávolíthat:

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **Az összes egyedi XML‑rész törlése egy gyűjteményből**

Használja a `Clear` metódust, ha egy adott prezentációs objektumhoz kapcsolt összes egyedi XML‑részt el kell távolítani.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

A `Clear` csak a kiválasztott gyűjteményre hat. Például egy dia gyűjteményének törlése nem érinti a prezentáció‑szintű vagy alakzat‑szintű gyűjteményeket.

Az összes egyedi XML‑rész eltávolításához a prezentációban iteráljon a `AllCustomXmlParts` gyűjteményen, és minden részt távolítson el:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **Kapcsolt vagy megosztott egyedi XML‑részek kezelése**

Egy Office Open XML prezentációban ugyanaz a egyedi XML‑rész több prezentációs objektumról is hivatkozható. Például egy meglévő fájl tartalmazhat kapcsolatokat több diától vagy alakzattól ugyanahhoz az alappartnertől.

A megosztott részt úgy kell kezelni, mint egy adatobjektumot több hivatkozással:

- Az `XmlAsString`, `XmlData` vagy `ItemId` frissítése módosítja a mögöttes egyedi XML‑részt, így a változás minden hivatkozási helyen megjelenik.
- Az `ItemId` használható ugyanazon egyedi XML‑rész azonosítására objektumszintű gyűjtemények auditálásakor.
- Egy rész eltávolítása egy adott `CustomXmlParts` gyűjteményből csak azt a gyűjteményt érinti. Használja az `ICustomXmlPart.Remove()` metódust, ha a részt magát is el kell távolítani a prezentációból.
- Megosztott rész törlése vagy helyettesítése előtt ellenőrizze az objektumszintű gyűjteményeket, hogy más diák vagy alakzatok még hivatkoznak‑e rá.

Az `Add` túlterhelések új egyedi XML‑részt hoznak létre XML‑tartalom alapján; nem fogadnak el meglévő `ICustomXmlPart` objektumot. Ezért a megosztott kapcsolatok leggyakrabban akkor fordulnak elő, amikor már meglévő, ilyen részeket tartalmazó prezentációkat tölt be.

Az alábbi példa auditálja a prezentáció‑, dia‑ és alakzat‑szintű gyűjteményeket `ItemId` szerint, és jelentést készít a több helyről hivatkozott részeiről:

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

Ez a fajta auditálás hasznos, mielőtt módosítaná vagy törölné az egyedi XML‑adatokat olyan külső rendszerek által létrehozott prezentációkban, mert ugyanaz a metaadat‑rész több kapcsolatban is szerepelhet.

## **Címkék értékeinek lekérése**

A slide‑okban egy címke a `IDocumentProperties.Keywords` tulajdonságnak felel meg. Ez a mintakód megmutatja, hogyan lehet egy címke értékét lekérni az Aspose.Slides for .NET segítségével a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) esetén:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **Címkék hozzáadása a prezentációkhoz**

Az Aspose.Slides lehetővé teszi címkék hozzáadását a prezentációkhoz. Egy címke általában két elemből áll:

- a saját tulajdonság neve, például `MyTag`;
- a saját tulajdonság értéke, például `My Tag Value`.

Ha bizonyos szabály vagy tulajdonság alapján szeretné csoportosítani a prezentációkat, ennek megfelelően hozzáadhat címkéket. Például ha az észak-amerikai országokból származó prezentációkat szeretné kategorizálni, létrehozhat egy „NorthAmerican” címkét, és a megfelelő országot állíthatja be értékként.

Ez a mintakód megmutatja, hogyan adjon hozzá egy címkét egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) objektumhoz az Aspose.Slides for .NET használatával:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var tags = presentation.CustomData.Tags;
tags["MyTag"] = "My Tag Value";
```

A címkéket beállíthatja egy [Slide](https://reference.aspose.com/slides/hu/net/aspose.slides/slide) esetén is:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
slide.CustomData.Tags["tag"] = "value";
```

Vagy egyetlen [Shape](https://reference.aspose.com/slides/hu/net/aspose.slides/shape) esetén:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
shape.TextFrame.Text = "My text";
shape.CustomData.Tags["tag"] = "value";
```

### **Korlátozások**

A `CustomData.Tags` gyűjteményen keresztül hozzáadott címkék csak a PowerPoint‑fájlban tárolódnak. **Nem** kerülnek át a PDF címke‑struktúrába, amikor a prezentációt PDF‑re exportálják. Ennek következtében egy címkeként tárolt egyedi azonosítót nem lehet lekérni a címkézett PDF‑ből.

**Megoldás**: Az egyedi azonosítót tárolhatja az objektum **Alt Text**‑ében (például `shape.AlternativeText = "MyId"`). PDF‑export után az Alt Text előfordulhat a PDF címke‑struktúrájában.

## **GYIK**

**Eltávolíthatok minden címkét egy prezentációból, diából vagy alakzatból egy műveletben?**  
Igen. A [címke‑gyűjtemény](https://reference.aspose.com/slides/hu/net/aspose.slides/tagcollection/) támogatja a [Clear](https://reference.aspose.com/slides/hu/net/aspose.slides/tagcollection/clear/) műveletet, amely egyszerre törli az összes kulcs‑érték párt.

**Hogyan töröljek egyetlen címkét a nevével anélkül, hogy végig kellene járni az egész gyűjteményt?**  
Használja a `[Remove(name)](https://reference.aspose.com/slides/hu/net/aspose.slides/tagcollection/remove/)` metódust a [TagCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/tagcollection/) objektumon a címke kulcs szerinti törléséhez.

**Hogyan szerezhetem meg a címkék teljes neves listáját elemzéshez vagy szűréshez?**  
Használja a [GetNamesOfTags](https://reference.aspose.com/slides/hu/net/aspose.slides/tagcollection/getnamesoftags/) metódust a [címke‑gyűjteményen](https://reference.aspose.com/slides/hu/net/aspose.slides/tagcollection/); ez egy tömböt ad vissza az összes címkenévvel.

**Hogyan találhatom meg az összes egyedi XML‑részt függetlenül attól, hogy hol vannak tárolva?**  
Használja a [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/allcustomxmlparts/) metódust az összes egyedi XML‑rész lekéréséhez a prezentációban.

**Az `XmlAsString` vagy `XmlData` használandó a egyedi XML‑rész frissítéséhez?**  
Használja az `XmlAsString`‑et, ha az alkalmazás UTF‑8 XML‑szöveggel dolgozik. Használja az `XmlData`‑t, ha az XML már byte‑tömbként áll rendelkezésre, vagy a bináris feldolgozás kényelmesebb. Mindkét tulajdonság ugyanazon egyedi XML‑rész XML‑tartalmát képviseli.