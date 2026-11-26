---
title: Prezentációtulajdonságok kezelése .NET-ben
linktitle: Prezentációtulajdonságok
type: docs
weight: 70
url: /hu/net/presentation-properties/
keywords:
- PowerPoint tulajdonságok
- prezentáció tulajdonságok
- dokumentumtulajdonságok
- beépített tulajdonságok
- egyéni tulajdonságok
- haladó tulajdonságok
- tulajdonságok kezelése
- tulajdonságok módosítása
- dokumentum metaadatok
- metaadatok szerkesztése
- ellenőrzési nyelv
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Vezérelje a prezentációtulajdonságokat az Aspose.Slides for .NET-ben, és egyszerűsítse a keresést, a márkaépítést és a munkafolyamatot PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides for .NET **beépített** és **egyéni** dokumentumtulajdonságokat támogat. Ezeket a tulajdonságokat használhatja a prezentáció metaadatai olvasására és frissítésére, például a szerző, a cím és a felhasználó által definiált értékek esetén.

Az Aspose.Slides lehetővé teszi a prezentáció dokumentumtulajdonságokkal való munkát a [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) interfészen keresztül. Ennek az interfésznek egy példányát a [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) adja vissza. A következő példák bemutatják, hogyan olvassuk, módosítsuk és kezeljük ezeket a tulajdonságokat.

{{% alert color="info" title="Note" %}}
Az Aspose.Slides kezeli az alkalmazás- és gyártói metaadatokat a prezentációk mentésekor; ezek a mezők azonosítják a kimenetet létrehozó szoftvert.
{{% /alert %}}

## **Prezentációtulajdonságok kezelése**

A dokumentumtulajdonságok leíró információkat tárolnak a prezentáció tartalma mellett.  
Két kategóriába sorolhatók:

- **Beépített tulajdonságok** tartalmazzák a szabványos metaadatokat, például a címet, a szerzőt és a dokumentum statisztikákat.  
- **Egyéni tulajdonságok** felhasználó által meghatározott név/érték párokat tárolnak.

Az Aspose.Slides for .NET hozzáférést biztosít mindkét kategóriához. PowerPointban válassza a **File → Info → Properties → Advanced Properties** lehetőséget a dokumentum metaadatainak megtekintéséhez. A párbeszédablak az információkat olyan fülekbe csoportosítja, mint a **Summary**, **Statistics**, **Contents** és **Custom**. Az **Custom** fület használja a felhasználó által definiált tulajdonságok kezeléséhez.

## **Publikus tulajdonságok olvasása titkosított prezentációból**

Egy megnyitási jelszó általában védi a prezentáció tartalmát és a dokumentumtulajdonságokat is. Ha egy prezentáció titkosítva van a [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) `false` értékre állítva, a dokumentumtulajdonságai nyilvánosak maradnak. Egy alkalmazás ekkor a [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) `true` értékre állíthatja, és a nyilvános metaadatokat a megnyitási jelszó megadása nélkül olvashatja.

[LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) szabályozza, hogy az Aspose.Slides mit tölt be; nem titkosít semmit. Ha a tulajdonságok a titkosítás részei voltak, a jelszó nélkül történő betöltés sikertelen. Ha a prezentáció nincs titkosítva, az opció figyelmen kívül marad, és a teljes prezentáció betöltődik.

A példához egy titkosított prezentációra van szükség, amelynek dokumentumtulajdonságai nyilvánosak maradtak. A betöltési módot az [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) ellenőrzi, majd a beépített tulajdonságokat a [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) segítségével olvassa:

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var documentProperties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + documentProperties.Author);
    Console.WriteLine("Title: " + documentProperties.Title);
    Console.WriteLine("Keywords: " + documentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

Ebben a módban a dia tartalma nem töltődik be. A diák, a master-diák, elrendezések, alakzatok, média és egyéb prezentációs objektumok nem érhetők el. Az alkalmazásoknak mindig ellenőrizniük kell az [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) értéket, mielőtt olyan műveletet hajtanának végre, amely a teljes prezentációs objektummodellt igényli.

{{% alert color="warning" title="Security" %}}
A nyilvános metaadatok felfedhetik a szerző neveit, címeket, tárgyakat, kulcsszavakat, vállalati információkat, megjegyzéseket és egyéni értékeket. Titkosítsa az érzékeny tulajdonságokat a prezentációval együtt. Hagyja őket nyilvánosnak csak akkor, ha indexelési, osztályozási, keresési vagy dokumentumkezelő rendszereknek kifejezett igénye van a jelszó nélküli hozzáférésre.
{{% /alert %}}

## **Titkosított prezentáció tulajdonságainak frissítése**

Titkosított PPTX fájl esetén a [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) segítségével betöltött prezentáció a nyilvános metaadatok olvasására szolgál. Az Aspose.Slides nem tudja elmenteni a módosított tulajdonságokat ebből a csak metaadatokat tartalmazó objektumból, mivel a nyilvános tulajdonságoknak meg kell egyezniük a titkosított prezentációban lévő megfelelő adatokkal. Ennek frissítése ezért a helyes megnyitási jelszót és a teljes betöltést igényli.

A példához egy titkosított PPTX prezentációra van szükség, amelynek nyilvános dokumentumtulajdonságai vannak, valamint ismert megnyitási jelszó. A teljes prezentációt a [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) segítségével nyitja meg, frissíti a nyilvános beépített tulajdonságokat, és elmenti az eredményt. Ezután az [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/isencrypted/) segítségével ellenőrzi, hogy a titkosítás megmaradt-e, és a nyilvános metaadatokat jelszó nélkül újra megnyitja az új értékek ellenőrzéséhez:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation(inputPath, loadOptions);

var documentProperties = presentation.DocumentProperties;
documentProperties.Title = "Updated Product Roadmap";
documentProperties.Keywords = "roadmap, planning, indexed";

presentation.Save(outputPath, SaveFormat.Pptx);

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

Ha egy alkalmazás számára nem engedélyezett a prezentáció tartalmának dekódolása vagy betöltése, akkor a titkosított PPTX fájl nyilvános tulajdonságait csak olvashatóként kell kezelni.

## **Beépített tulajdonságok elérése**

A [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) interfész a beépített metaadatokat típusos tulajdonságokon keresztül teszi elérhetővé, többek között a [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), a [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/) és a [CreatedTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/createdtime/) tulajdonságokat. Ez a példa egy meglévő prezentációt nyit meg, és a tárolt metaadatait a konzolra írja. Az értékek a bemeneti prezentációtól függnek; egyes mezők üresek lehetnek.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AccessBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

Console.WriteLine("Category: " + documentProperties.Category);
Console.WriteLine("Content status: " + documentProperties.ContentStatus);
Console.WriteLine("Creation date: " + documentProperties.CreatedTime);
Console.WriteLine("Author: " + documentProperties.Author);
Console.WriteLine("Comments: " + documentProperties.Comments);
Console.WriteLine("Keywords: " + documentProperties.Keywords);
Console.WriteLine("Last modified by: " + documentProperties.LastSavedBy);
Console.WriteLine("Manager: " + documentProperties.Manager);
Console.WriteLine("Modified date: " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format: " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date: " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers: " + documentProperties.SharedDoc);
Console.WriteLine("Subject: " + documentProperties.Subject);
Console.WriteLine("Title: " + documentProperties.Title);
```

### **Javítási szám és szerkesztési idő jelentése**

A `presentations` mappában lévő minden PPTX fájlhoz egy sort jelenteni, hívja a [ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) metódust, így lekérheti a [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) objektumot a diák betöltése nélkül. A `TimeSpan` szabványos `c` formátuma a napok számát is tartalmazza, ha az időtartam eléri a 24 órát.

```csharp
using System;
using System.IO;
using Aspose.Slides;

Console.WriteLine("File | RevisionNumber | TotalEditingTime");
foreach (var path in Directory.EnumerateFiles("presentations", "*.pptx"))
{
    var info = PresentationFactory.Instance.GetPresentationInfo(path);
    var properties = info.ReadDocumentProperties();
    Console.WriteLine($"{Path.GetFileName(path)} | {properties.RevisionNumber} | {properties.TotalEditingTime:c}");
}
```

Minta kimenet egy olyan prezentációhoz, amelynek 1 nap, 2 óra és 5 perc szerkesztési ideje van rögzítve:

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[RevisionNumber](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/revisionnumber/) írható metaadat. Az értéke önmagában nem bizonyítja, hogy hányszor mentették a prezentációt, vagy nem állítható helyre a verziótörténet.

[TotalEditingTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/totaleditingtime/) a fájlban tárolt szerkesztési időt mutatja. A `00:00:00` érték azt jelenti, hogy a tárolt időtartam nulla. Ez nem bizonyítja, hogy senki sem szerkesztette a prezentációt.

## **Beépített tulajdonságok módosítása**

A beépített metaadatok frissítéséhez adjon értékeket a [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) által biztosított írható tulajdonságoknak. Ez a példa egy meglévő prezentációt nyit meg, beállítja a [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), a [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/), a [Subject](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/subject/), a [Comments](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/comments/) és a [Manager](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/manager/) attribútumokat, majd a [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) metódussal elmenti a frissített prezentációt. A mentett PPTX tartalmazza az új metaadatokat.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ModifyBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Hiperlink alap kezelése**

[IDocumentProperties.HyperlinkBase](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/hyperlinkbase/) a dokumentumszintű alapot tárolja a relatív hiperhivatkozásokhoz. Ez akkor hasznos, amikor a prezentációt és a kapcsolt fájlokat egy másik helyre helyezi át. Ez különálló az egyes hiperhivatkozások [IHyperlink.ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) attribútumától: az alap módosítása nem írja felül a tárolt linkcímeket, és nem változtatja meg az abszolút célokat.

A példához egy olyan prezentációra van szükség, amely tartalmaz egy relatív hivatkozást, például `target.html`, és egy abszolút hivatkozást, például `https://example.org/absolute.html`. A meglévő alapot beolvassa, új alapcímre állítja, majd elmenti és újra megnyitja a prezentációt az érték ellenőrzéséhez. Ezután a `string.Empty` segítségével törli az alapot, és egy külön mentett fájlban ellenőrzi az üres értéket. Cserélje ki a példa alapcímét a saját kapcsolt fájljainak helyére.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("hyperlinks.pptx");
Console.WriteLine("Original base: " + presentation.DocumentProperties.HyperlinkBase);

const string newBase = "https://example.com/new/";
presentation.DocumentProperties.HyperlinkBase = newBase;
presentation.Save("hyperlinks-updated.pptx", SaveFormat.Pptx);

using var updatedPresentation = new Presentation("hyperlinks-updated.pptx");
Console.WriteLine("Base preserved: " + (updatedPresentation.DocumentProperties.HyperlinkBase == newBase));

updatedPresentation.DocumentProperties.HyperlinkBase = string.Empty;
updatedPresentation.Save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

using var clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
Console.WriteLine("Base cleared: " + (clearedPresentation.DocumentProperties.HyperlinkBase == string.Empty));
```

A két ellenőrző üzenetnek `True` értéket kell kiírnia. Az alap törlése nem érinti az egyedi hiperhivatkozás címeket.

Egy relatív hivatkozás a `target.pptx`-re `old/target.pptx`-t nyitott meg, amikor az alap az `old` mappára mutatott. Az alap `new` mappára való módosítása, a mentés és a prezentáció újra megnyitása után ugyanaz a hivatkozás `new/target.pptx`-t nyitott. Egy abszolút hivatkozás továbbra is ugyanazt a fájlt nyitotta. Tesztelje a relatív hivatkozásait a PowerPointban a prezentáció áthelyezése vagy az alap módosítása előtt és után.

## **Egyéni prezentációtulajdonságok hozzáadása**

Az egyéni tulajdonságok olyan metaadatokat tárolnak, amelyeknek nincs megfelelő beépített mezője. A [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) lehetővé teszi, hogy név alapján értéket hozzon hozzárendelésre. Ez a példa egy prezentációt hoz létre, két szöveges értéket és egy egészverzió értéket ad hozzá, majd a [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) metódussal menti. Egy létező névre történő értékadás felülírja a tulajdonság korábbi értékét.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var documentProperties = presentation.DocumentProperties;

documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Egyéni tulajdonságok elérése és módosítása**

Ez a példa olyan prezentációt nyit meg, amely egyéni tulajdonságokat tartalmaz, és a [CountOfCustomProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/countofcustomproperties/) segítségével iterál rajtuk. A [GetCustomPropertyName](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/getcustompropertyname/) nullánál indexelt pozíciót fogad, és visszaadja a [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) által használt nevet. A példa kiírja az eredeti nevet és értéket, minden értéket egy számozott karakterláncra cserél, függetlenül az eredeti típustól, majd elmenti a módosításokat. Ha nincsenek egyéni tulajdonságok, a ciklus nem hajt végre változtatást.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AccessAndModifyProperties.pptx");

var documentProperties = presentation.DocumentProperties;

for (var i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    var propertyName = documentProperties.GetCustomPropertyName(i);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine("Custom property name: " + propertyName);
    Console.WriteLine("Custom property value: " + propertyValue);

    documentProperties[propertyName] = "New Value " + (i + 1);
}

presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Élő példa**

Próbálja ki a [**Megtekintés és szerkesztés PowerPoint metaadatok**](https://products.aspose.app/slides/metadata) online alkalmazást, hogy lássa, hogyan lehet a dokumentumtulajdonságokkal dolgozni az Aspose.Slides API használatával:

[![Megtekintés és szerkesztés PowerPoint metaadatok](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **GYIK**

**Hogyan távolíthatok el egy beépített tulajdonságot a prezentációból?**

A beépített tulajdonságok a prezentáció szerves részei, és nem távolíthatók el teljesen. Azonban megváltoztathatja értéküket, vagy ha az adott tulajdonság megengedi, üresre állíthatja őket.

**Mi történik, ha olyan egyéni tulajdonságot adok hozzá, amely már létezik?**

Ha olyan egyéni tulajdonságot ad hozzá, amely már létezik, a meglévő értéke felülíródik az újjal. Nem szükséges előre eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti a tulajdonság értékét.

**Elérhetem-e a prezentáció tulajdonságait anélkül, hogy teljesen betölteném a prezentációt?**

Igen. Használja a [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) metódust, majd a [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) segítségével olvassa el a tárolt dokumentum metaadatait anélkül, hogy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) példányt hozna létre. Lásd a [Build a Lightweight Presentation Inventory](/slides/hu/net/examine-presentation/) példát a teljes jelentéshez és a formátumspecifikus korlátozásokhoz.

**Olvashatok-e nyilvános tulajdonságokat egy titkosított prezentációból anélkül, hogy megadnám a megnyitási jelszót?**

Igen. A prezentációnak úgy kell titkosítva lennie, hogy a [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) `false` értékre legyen állítva, és a [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) `true` értékkel legyen betöltve.

**Frissíthetek-e egy titkosított PPTX fájlt csak a dokumentumtulajdonságok betöltése üzemmódban?**

Nem. A nyilvános és a titkosított tulajdonságadatoknak konzisztensnek kell maradniuk, ezért egy titkosított PPTX fájl frissítéséhez a teljes prezentációt a helyes megnyitási jelszóval kell betölteni.