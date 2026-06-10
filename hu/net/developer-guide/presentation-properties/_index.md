---
title: Prezentációtulajdonságok kezelése .NET-ben
linktitle: Prezentációtulajdonságok
type: docs
weight: 70
url: /hu/net/presentation-properties/
keywords:
- PowerPoint tulajdonságok
- prezentációtulajdonságok
- dokumentumtulajdonságok
- beépített tulajdonságok
- egyéni tulajdonságok
- speciális tulajdonságok
- tulajdonságok kezelése
- tulajdonságok módosítása
- dokumentum metaadatai
- metaadatok szerkesztése
- helyesírási nyelv
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Teljes körűen kezelje a prezentációtulajdonságokat az Aspose.Slides for .NET segítségével, és egyszerűsítse a keresést, a márkázást és a munkafolyamatot PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides for .NET kétféle dokumentumtulajdonságot támogat: **Beépített** és **Egyéni**. Mindkét tulajdonságtípus könnyen elérhető és kezelhető az Aspose.Slides for .NET API segítségével.

Az Aspose.Slides lehetővé teszi, hogy a prezentáció dokumentumtulajdonságokkal a [IDocumentProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/) interfészen keresztül dolgozzon. Ennek az interfésznek egy példánya a [Presentation.DocumentProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/documentproperties/) tulajdonságon keresztül érhető el. A következő példák bemutatják, hogyan olvassuk, módosítsuk és kezeljük ezeket a tulajdonságokat.

{{% alert color="primary" %}} 
Felhívjuk a figyelmet, hogy a **Application** és **Producer** mezők nem módosíthatók, mivel ezek a mezők mindig az “Aspose Ltd.” és az “Aspose.Slides for .NET x.x.x” értéket fogják mutatni.
{{% /alert %}} 

## **Prezentációtulajdonságok kezelése**

A Microsoft PowerPoint lehetőséget biztosít a prezentációs fájlokhoz tulajdonságok hozzáadására. Ezek a dokumentumtulajdonságok hasznos információk tárolását teszik lehetővé a fájlokkal együtt. Két típusa van a dokumentumtulajdonságoknak:

- Rendszer által meghatározott (beépített) tulajdonságok
- Felhasználó által meghatározott (egyéni) tulajdonságok

**Beépített** tulajdonságok általános információkat tartalmaznak a dokumentumról, például a dokumentum címet, a szerző nevét, a dokumentum statisztikáit és egyebeket.

**Egyéni** tulajdonságokat a felhasználók **Név/Érték** párok formájában definiálnak, ahol a név és az érték egyaránt a felhasználó által van megadva.

Az Aspose.Slides for .NET használatával a fejlesztők hozzáférhetnek és módosíthatják mind a beépített, mind az egyéni tulajdonságokat.

A Microsoft PowerPoint lehetővé teszi a felhasználók számára a dokumentumtulajdonságok kezelését az Office ikonra kattintva, majd a **File → Info → Properties** lehetőséget választva. Az **Advanced Properties** kiválasztása után megjelenik egy párbeszédablak, ahol a prezentációs fájl összes dokumentumtulajdonságát kezelheti.

A **Properties** párbeszédablakban több lap található, például **General**, **Summary**, **Statistics**, **Contents**, és **Custom**. Minden lap lehetőséget nyújt a PowerPoint fájlhoz kapcsolódó specifikus információk beállítására. A **Custom** lapot a felhasználó által meghatározott tulajdonságok kezelésére használják.

## **Beépített tulajdonságok elérése**

Ezek a tulajdonságok, amelyeket a [IDocumentProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/) interfész biztosít, a következők: **Creator** (Szerző), **Description**, **Keywords**, **Created** (Létrehozás dátuma), **Modified** (Módosítás dátuma), **Printed** (Legutóbbi nyomtatás dátuma), **LastModifiedBy**, **SharedDoc** (jelzi, hogy a dokumentum több különböző gyártó között meg van-e osztva), **PresentationFormat**, **Subject**, **Title**, és egyebek.

```cs
// A Presentation osztály példányosítása, amely egy prezentációs fájlt képvisel.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Display the Built-in properties.
Console.WriteLine("Category : " + documentProperties.Category);
Console.WriteLine("Content status : " + documentProperties.ContentStatus);
Console.WriteLine("Creation date : " + documentProperties.CreatedTime);
Console.WriteLine("Author : " + documentProperties.Author);
Console.WriteLine("Comments : " + documentProperties.Comments);
Console.WriteLine("Key words : " + documentProperties.Keywords);
Console.WriteLine("Last modified by : " + documentProperties.LastSavedBy);
Console.WriteLine("Manager : " + documentProperties.Manager);
Console.WriteLine("Modified date : " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format : " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date : " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers : " + documentProperties.SharedDoc);
Console.WriteLine("Subject : " + documentProperties.Subject);
Console.WriteLine("Title : " + documentProperties.Title);
```

## **Beépített tulajdonságok módosítása**

A prezentációs fájlok beépített tulajdonságainak módosítása ugyanolyan egyszerű, mint a hozzáférés. Egyszerűen hozzárendelhet egy karakterlánc értéket bármely kívánt tulajdonsághoz, és a tulajdonság értéke frissülni fog. Az alábbi példában bemutatjuk, hogyan módosíthatja egy prezentációs fájl beépített dokumentumtulajdonságait.

```cs
// A Presentation osztály példányosítása, amely egy prezentációs fájlt képvisel.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Referenciát kap a prezentációhoz társított IDocumentProperties típusú objektumra.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Beállítja a beépített tulajdonságokat.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// A prezentáció mentése egy fájlba.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Egyéni prezentációtulajdonságok hozzáadása**

Az egyéni prezentációtulajdonságok lehetővé teszik a fejlesztők számára további metaadatok vagy specifikus információk tárolását egy prezentációs fájlban. Az Aspose.Slides megkönnyíti ezen egyéni tulajdonságok programozott létrehozását és kezelését. A következő példák bemutatják, hogyan adhat egyéni tulajdonságokat a prezentációihoz.

```cs
// A Presentation osztály példányosítása.
using Presentation presentation = new Presentation();

// Referenciát kap a prezentációhoz társított IDocumentProperties típusú objektumra.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Egyéni tulajdonságok hozzáadása.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// A prezentáció mentése egy fájlba.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Egyéni tulajdonságok elérése és módosítása**

Az Aspose.Slides lehetővé teszi a fejlesztők számára, hogy elérjék a meglévő egyéni tulajdonságokat és egyszerűen módosítsák azok értékeit. Ez a funkció segít a pontos metaadatok fenntartásában, és támogatja a felhasználói bemenet vagy üzleti logika alapján történő dinamikus frissítéseket. Az alábbi példák bemutatják, hogyan lehet lekérni és frissíteni egyéni tulajdonságértékeket egy prezentációban.

```cs
// A Presentation osztály példányosítása, amely egy PPTX fájlt képvisel.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Egyéni tulajdonságok elérése és módosítása.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // Az egyéni tulajdonság nevét és értékét jeleníti meg.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // Az egyéni tulajdonság értékének módosítása.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// A prezentáció mentése egy fájlba.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Élő példa**

Próbálja ki az [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/hu/metadata) online alkalmazást, hogy lássa, hogyan dolgozhat a dokumentumtulajdonságokkal az Aspose.Slides API segítségével:

[![Megtekintés és szerkesztés PowerPoint metaadatok](slides-metadata.png)](https://products.aspose.app/slides/hu/metadata)

## ***GYIK**

**Hogyan távolíthatok el egy beépített tulajdonságot egy prezentációból?**

A beépített tulajdonságok a prezentáció szerves részét képezik, ezért nem távolíthatók el teljesen. Azonban megváltoztathatja az értéküket, vagy üresre állíthatja őket, ha az adott tulajdonság megengedi.

**Mi történik, ha olyan egyéni tulajdonságot adok hozzá, amely már létezik?**

Ha olyan egyéni tulajdonságot ad hozzá, amely már létezik, a meglévő értéke felülíródik az újjal. Nem kell előzőleg eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti a tulajdonság értékét.

**Hozzáférhetek a prezentáció tulajdonságaihoz anélkül, hogy teljesen betölteném a prezentációt?**

Igen, a prezentáció tulajdonságaihoz hozzáférhet anélkül, hogy a teljes prezentációt betöltené, a [PresentationFactory](https://reference.aspose.com/slides/hu/net/aspose.slides/presentationfactory/) osztály `GetPresentationInfo` metódusának használatával. Ezután a [IPresentationInfo](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationinfo/) interfész `ReadDocumentProperties` metódusát alkalmazva hatékonyan olvashatja a tulajdonságokat, ezzel memóriát takarítva meg és javítva a teljesítményt.