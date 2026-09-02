---
title: Prezentációs tulajdonságok kezelése .NET-ben
linktitle: Prezentációs tulajdonságok
type: docs
weight: 70
url: /hu/net/presentation-properties/
keywords:
- PowerPoint tulajdonságok
- prezentációs tulajdonságok
- dokumentumtulajdonságok
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
description: "A prezentációs tulajdonságok teljes körű kezelése az Aspose.Slides for .NET segítségével, és a keresés, márkázás és munkafolyamat egyszerűsítése a PowerPoint és OpenDocument fájlokban."
---
## **Bevezetés**

Az Aspose.Slides for .NET két típusú dokumentumtulajdonságot támogat: **Beépített** és **Egyéni**. Mindkét tulajdonságtípus könnyen elérhető és kezelhető az Aspose.Slides for .NET API segítségével.

Az Aspose.Slides lehetővé teszi a bemutató dokumentumtulajdonságok kezelését a [IDocumentProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/) interfészen keresztül. Ennek az interfésznek egy példánya a [Presentation.DocumentProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/documentproperties/) tulajdonságon keresztül érhető el. Az alábbi példák bemutatják, hogyan olvassuk, módosítsuk és kezeljük ezeket a tulajdonságokat.

{{% alert color="info" title="Megjegyzés" %}}
Kérjük vegye figyelembe, hogy a **Application** és **Producer** mezőket nem lehet módosítani, mivel ezek a mezők mindig az "Aspose Ltd." és a "Aspose.Slides for .NET x.x.x" értékeket fogják mutatni.
{{% /alert %}} 

## **A bemutató tulajdonságainak kezelése**

Az Microsoft PowerPoint lehetővé teszi a tulajdonságok hozzáadását a bemutató fájlokhoz. Ezek a dokumentumtulajdonságok hasznos információk tárolását teszik lehetővé a fájlok mellett. Kétféle dokumentumtulajdonság létezik:

- Rendszer által definiált (beépített) tulajdonságok
- Felhasználó által definiált (egyéni) tulajdonságok

**Beépített** tulajdonságok általános információkat tartalmaznak a dokumentumról, például a dokumentum címét, a szerző nevét, a dokumentum statisztikáit és egyebeket.

**Egyéni** tulajdonságokat a felhasználók **Név/Érték** párok formájában definiálják, ahol mind a név, mind az érték felhasználó által van megadva.

Az Aspose.Slides for .NET segítségével a fejlesztők elérhetik és módosíthatják mind a beépített, mind az egyéni tulajdonságokat.

Az Microsoft PowerPoint lehetővé teszi a felhasználók számára a dokumentumtulajdonságok kezelését az Office ikonjára kattintva, majd a **File → Info → Properties** (Fájl → Információ → Tulajdonságok) kiválasztásával. Az **Advanced Properties** (Speciális tulajdonságok) választása után egy párbeszédablak jelenik meg, ahol a bemutató fájl összes dokumentumtulajdonságát kezelheti.

A **Properties** (Tulajdonságok) párbeszédablakban több fül található, például **General** (Általános), **Summary** (Összefoglaló), **Statistics** (Statisztika), **Contents** (Tartalom) és **Custom** (Egyéni). Minden fül lehetőséget biztosít a PowerPoint fájlhoz kapcsolódó specifikus információk beállítására. Az **Custom** (Egyéni) fül a felhasználó által definiált tulajdonságok kezelésére szolgál.

## **Beépített tulajdonságok elérése**

Az [IDocumentProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/) interfész által kiexponált tulajdonságok közé tartozik: **Creator** (Szerző), **Description**, **Keywords**, **Created** (Létrehozás dátuma), **Modified** (Módosítás dátuma), **Printed** (Legutóbbi nyomtatás dátuma), **LastModifiedBy**, **SharedDoc** (mutatja, hogy a dokumentum több különböző producer között meg van-e osztva), **PresentationFormat**, **Subject**, **Title**, és egyebek.

```cs
using Aspose.Slides;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
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

A bemutató fájlok beépített tulajdonságainak módosítása ugyanolyan egyszerű, mint azok elérése. Egyszerűen egy karakterlánc értéket rendelhet a kívánt tulajdonsághoz, és az érték frissülni fog. Az alábbi példában bemutatjuk, hogyan módosíthatja egy bemutató fájl beépített dokumentumtulajdonságait.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Szerezzen referenciát a prezentációval társított IDocumentProperties típusú objektumra.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Állítsa be a beépített tulajdonságokat.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Mentse a prezentációt egy fájlba.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Egyéni bemutató tulajdonságok hozzáadása**

Az egyéni bemutató tulajdonságok lehetővé teszik a fejlesztők számára, hogy további metaadatokat vagy specifikus információkat tároljanak egy bemutató fájlban. Az Aspose.Slides egyszerűvé teszi ezen egyéni tulajdonságok programozott létrehozását és kezelését. Az alábbi példák bemutatják, hogyan adhat egyéni tulajdonságokat a prezentációkhoz.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosítja a Presentation osztályt.
using Presentation presentation = new Presentation();

// Referenciát szerez a prezentációhoz társított IDocumentProperties típusú objektumra.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Egyéni tulajdonságok hozzáadása.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// A prezentáció mentése egy fájlba.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Egyéni tulajdonságok elérése és módosítása**

Az Aspose.Slides emellett lehetővé teszi a fejlesztők számára, hogy elérjék a meglévő egyéni tulajdonságokat és könnyedén módosítsák azok értékeit. Ez a funkcionalitás segít a pontos metaadatok fenntartásában, és támogatja a felhasználói bemenet vagy üzleti logika alapján történő dinamikus frissítéseket. Az alábbi példák bemutatják, hogyan lehet lekérni és frissíteni egy egyéni tulajdonság értékét egy bemutatóban.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Referenciát szerez a prezentációhoz társított IDocumentProperties típusú objektumra.
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

Próbálja ki a [**PowerPoint metaadatok megtekintése és szerkesztése**](https://products.aspose.app/slides/hu/metadata) online alkalmazást, hogy lássa, hogyan lehet a dokumentumtulajdonságokkal dolgozni az Aspose.Slides API segítségével:

[![PowerPoint metaadatok megtekintése és szerkesztése](slides-metadata.png)](https://products.aspose.app/slides/hu/metadata)

## **GYIK**

**Hogyan távolíthatok el egy beépített tulajdonságot egy bemutatóból?**

A beépített tulajdonságok a bemutató szerves részét képezik, és nem távolíthatók el teljesen. Azonban módosíthatja az értéküket, vagy ha az adott tulajdonság megengedi, üresre állíthatja őket.

**Mi történik, ha olyan egyéni tulajdonságot adok hozzá, amely már létezik?**

Ha olyan egyéni tulajdonságot ad hozzá, amely már létezik, a meglévő értéke felül lesz írva az újval. Nem szükséges előre eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti a tulajdonság értékét.

**Elérhetem a bemutató tulajdonságait anélkül, hogy teljesen betölteném a bemutatót?**

Igen. Használja a [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hu/net/aspose.slides/presentationfactory/getpresentationinfo/) és aztán a [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationinfo/readdocumentproperties/) módszereket a tárolt dokumentum‑metaadatok olvasásához anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) példányt hozna létre. Lásd a [Build a Lightweight Presentation Inventory](/slides/hu/net/examine-presentation/) oldalt a teljes jelentési példáért és formátumspecifikus korlátokért.