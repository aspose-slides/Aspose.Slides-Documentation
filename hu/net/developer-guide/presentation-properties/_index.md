---
title: Prezentáció tulajdonságainak kezelése .NET-ben
linktitle: Prezentáció tulajdonságok
type: docs
weight: 70
url: /hu/net/presentation-properties/
keywords:
- PowerPoint tulajdonságok
- prezentáció tulajdonságok
- dokumentum tulajdonságok
- beépített tulajdonságok
- egyéni tulajdonságok
- speciális tulajdonságok
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
description: "Kezelje a prezentáció tulajdonságait az Aspose.Slides for .NET-ben, és egyszerűsítse a keresést, a márkázást és a munkafolyamatot PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides for .NET **beépített** és **egyéni** dokumentumtulajdonságokat támogat. Ezeket a tulajdonságokat használhatja a prezentáció metaadatainak olvasására és frissítésére, például a szerző, a cím és a felhasználó által meghatározott értékek esetén.

Az Aspose.Slides lehetővé teszi, hogy a prezentáció dokumentumtulajdonságokkal a [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) felületen keresztül dolgozzon. Ennek a felületnek egy példánya a [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) által kerül visszaadásra. A következő példák bemutatják, hogyan olvassa, módosítsa és kezelje ezeket a tulajdonságokat.

{{% alert color="info" title="Note" %}}
Az Aspose.Slides kezeli az alkalmazás- és kiadó metaadatokat a prezentációk mentésekor; ezek a mezők azonosítják a kimenetet létrehozó szoftvert.
{{% /alert %}}

## **A prezentáció tulajdonságainak kezelése**

A dokumentumtulajdonságok a leíró információkat tárolják a prezentáció tartalma mellett. Két kategóriába sorolhatók:

- **Beépített tulajdonságok** szabványos metaadatokat tartalmaznak, például a címet, a szerzőt és a dokumentum statisztikákat.
- **Egyéni tulajdonságok** felhasználó által meghatározott név/érték párokat tárolnak.

Az Aspose.Slides for .NET hozzáférést biztosít mindkét kategóriához. PowerPointban válassza a **File → Info → Properties → Advanced Properties** menüpontot a dokumentum metaadatainak megtekintéséhez. A párbeszédpanel információkat csoportosít külön lapokra, mint például **Summary**, **Statistics**, **Contents** és **Custom**. Használja a **Custom** lapot a felhasználó által meghatározott tulajdonságok kezeléséhez.

## **Nyilvános tulajdonságok olvasása titkosított prezentációból**

Egy nyitó jelszó általában védi a prezentáció tartalmát és a dokumentumtulajdonságokat is. Ha egy prezentációt úgy titkosítanak, hogy a [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) értéke **false**, akkor a dokumentumtulajdonságok nyilvánosak maradnak. Egy alkalmazás ekkor a [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) értékét **true**-ra állíthatja, és a nyilvános metaadatokat anélkül olvashatja, hogy a nyitó jelszót megadná.

[LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) határozza meg, mit tölt be az Aspose.Slides; semmit nem titkosít fel. Ha a tulajdonságok a titkosítás részét képezték, a jelszó nélküli betöltés sikertelen. Ha a prezentáció nincs titkosítva, a beállítás figyelmen kívül marad, és a teljes prezentáció betöltődik.

A példa egy olyan titkosított prezentációt igényel, amelynek dokumentumtulajdonságai nyilvánosak. A betöltési módot a [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) ellenőrzi, majd a beépített tulajdonságokat a [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) segítségével olvassa:

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

Ebben a módban a diák tartalma nem töltődik be. Diák, mesteroldalak, elrendezések, alakzatok, média és egyéb prezentációs objektumok nem érhetők el. Az alkalmazásoknak mindig ellenőrizniük kell a [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) értékét, mielőtt olyan műveletet végeznek, amely a teljes prezentáció objektummodelljét igényli.

{{% alert color="warning" title="Security" %}}
A nyilvános metaadatok felfedhetik a szerzők neveit, címeket, tárgyakat, kulcsszavakat, céginformációkat, megjegyzéseket és egyéni értékeket. Titkosítsa az érzékeny tulajdonságokat a prezentációval együtt. Csak akkor hagyja nyilvánosként, ha indexelési, osztályozási, keresési vagy dokumentumkezelő rendszereknek konkrétan szükségük van jelszó nélküli hozzáférésre.
{{% /alert %}}

## **Titkosított prezentáció tulajdonságainak frissítése**

Titkosított PPTX fájl esetén a [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) által betöltött prezentáció a nyilvános metaadatok olvasására szolgál. Az Aspose.Slides nem képes menteni a módosított tulajdonságokat ebből a csak-metaadat objektumból, mert a nyilvános tulajdonságoknak összhangban kell lenniük a titkosított prezentációban lévő adatokkal. Ezért a frissítéshez a helyes nyitó jelszó és a teljes betöltés szükséges.

A példa egy titkosított PPTX prezentációt igényel, amelynek dokumentumtulajdonságai nyilvánosak, valamint egy ismert nyitó jelszót. A teljes prezentációt a [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) segítségével nyitja meg, frissíti a nyilvános beépített tulajdonságokat, és elmenti az eredményt. Ezután a [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/isencrypted/) használatával ellenőrzi, hogy a titkosítás fennmaradt, és jelszó nélkül újra megnyitja a nyilvános metaadatokat az új értékek ellenőrzéséhez:

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

Ha egy alkalmazás nem kap engedélyt a prezentáció tartalmának dekódolására vagy betöltésére, a titkosított PPTX fájl nyilvános tulajdonságait csak olvasásra használhatja.

## **Beépített tulajdonságok elérése**

Az [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) felület a beépített metaadatokat típusos tulajdonságokként teszi elérhetővé, többek között a [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), a [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/) és a [CreatedTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/createdtime/) tulajdonságokat. Ez a példa egy létező prezentációt nyit meg, és a tárolt metaadatokat a konzolra írja. Az értékek a bemeneti prezentációtól függenek; egyes mezők üresek lehetnek.

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

## **Beépített tulajdonságok módosítása**

A beépített metaadatok frissítéséhez írható értékeket kell adni az [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) által biztosított tulajdonságoknak. Ez a példa egy létező prezentációt nyit meg, beállítja a [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), a [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/), a [Subject](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/subject/), a [Comments](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/comments/) és a [Manager](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/manager/) tulajdonságokat, majd a [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) segítségével menti a frissített prezentációt. A mentett PPTX tartalmazza az új metaadatokat.

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

## **A hiperhivatkozás alapjának kezelése**

[IDocumentProperties.HyperlinkBase](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/hyperlinkbase/) a dokumentumszintű alapot tárolja a relatív hiperhivatkozásokhoz. Ez akkor hasznos, ha egy prezentációt és a hozzákapcsolt fájlokat egy másik helyre helyezzük át. Ez különáll a egyes hiperhivatkozások [IHyperlink.ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) értékétől: az alap módosítása nem írja át a tárolt hivatkozási címeket, és nem változtatja meg az abszolút célpontokat.

A példa egy prezentációt igényel, amely tartalmaz egy relatív hivatkozást, például `target.html`, és egy abszolút hivatkozást, például `https://example.org/absolute.html`. Kiolvassa a meglévő alapot, új alapcímet ad meg, majd elmenti és újra megnyitja a prezentációt az érték ellenőrzésére. Ezután a `string.Empty` segítségével törli az alapot, és egy külön mentett fájlban ellenőrzi az üres értéket. Cserélje le a példa alapcímet a saját kapcsolt fájljainak helyére.

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

A két ellenőrző üzenetnek `True`‑t kell kiírnia. Az alap törlése nem érinti az egyes hiperhivatkozás címeket.

Egy relatív hivatkozás a `target.pptx` fájlra `old/target.pptx`-t nyitott meg, amikor az alap az `old` mappára mutatott. Az alap `new` mappára változtatása, a mentés és a prezentáció újra megnyitása után ugyanaz a hivatkozás a `new/target.pptx` fájlt nyitja meg. Egy abszolút hivatkozás továbbra is ugyanazt a fájlt nyitja meg. Tesztelje a relatív hivatkozásait PowerPointban a prezentáció áthelyezése vagy az alap módosítása előtt és után.

## **Egyéni prezentáció tulajdonságok hozzáadása**

Az egyéni tulajdonságok olyan metaadatokat tárolnak, amelyeknek nincs megfelelő beépített mezője. Az [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) lehetővé teszi, hogy név alapján értéket rendeljünk hozzá. Ez a példa létrehoz egy prezentációt, két szöveges értéket és egy egész verzióértéket ad hozzá, majd a [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) segítségével menti a prezentációt. Egy meglévő névhez érték hozzárendelése felülírja az adott tulajdonság értékét.

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

Ez a példa egy olyan prezentációt nyit meg, amely egyéni tulajdonságokat tartalmaz, és a [CountOfCustomProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/countofcustomproperties/) segítségével iterál rajtuk. A [GetCustomPropertyName](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/getcustompropertyname/) nulláról induló indexet fogad, és visszaadja a [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) által használt nevet. A példa kiírja minden eredeti nevet és értéket, minden értéket számozott karakterláncra cserél, függetlenül annak eredeti típusától, és elmenti a módosításokat. Ha nincsenek egyéni tulajdonságok, a ciklus nem végez változtatást.

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

Próbálja ki a [**PowerPoint metaadatok megtekintése és szerkesztése**](https://products.aspose.app/slides/metadata) online alkalmazást, hogy lássa, hogyan lehet a dokumentumtulajdonságokkal dolgozni az Aspose.Slides API használatával:

[![PowerPoint metaadatok megtekintése és szerkesztése](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **GYIK**

**Hogyan távolíthatok el egy beépített tulajdonságot a prezentációból?**

A beépített tulajdonságok a prezentáció szerves részei, és nem távolíthatók el teljesen. Azonban megváltoztathatja értékeiket, vagy ha az adott tulajdonság megengedi, üresre állíthatja őket.

**Mi történik, ha egy már létező egyéni tulajdonságot adok hozzá?**

Ha egy már létező egyéni tulajdonságot ad hozzá, a meglévő értéke felül lesz írva az újjal. Nem szükséges előtte eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti a tulajdonság értékét.

**Hozzáférhetek a prezentáció tulajdonságaihoz anélkül, hogy teljesen betölteném a prezentációt?**

Igen. Használja a [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) metódust, majd a [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) segítségével olvassa a tárolt dokumentum metaadatait anélkül, hogy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) példányt hozna létre. Lásd a [Könnyű prezentáció-inventár létrehozása](/slides/hu/net/examine-presentation/) cikket a teljes jelentési példáért és a formátumspecifikus korlátozásokért.

**Olvashatok nyilvános tulajdonságokat egy titkosított prezentációból a nyitó jelszó nélkül?**

Igen. A prezentációnak úgy kell titkosítva lennie, hogy a [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) értéke **false**, és a [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) értéke **true** legyen.

**Frissíthetek egy titkosított PPTX fájlt csak a dokumentumtulajdonságok betöltésével?**

Nem. A nyilvános és a titkosított tulajdonságadatoknak összhangban kell lenniük, ezért egy titkosított PPTX fájl frissítéséhez a teljes prezentációt kell betölteni a helyes nyitó jelszóval.