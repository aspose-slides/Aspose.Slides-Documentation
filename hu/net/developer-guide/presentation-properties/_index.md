---
title: Bemutató tulajdonságok kezelése a .NET környezetben
linktitle: Bemutató tulajdonságok
type: docs
weight: 70
url: /hu/net/presentation-properties/
keywords:
- PowerPoint tulajdonságok
- bemutató tulajdonságok
- dokumentum tulajdonságok
- beépített tulajdonságok
- egyedi tulajdonságok
- speciális tulajdonságok
- tulajdonságok kezelése
- tulajdonságok módosítása
- dokumentum metaadatok
- metaadatok szerkesztése
- helyesírási nyelv
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Mesteri szinten kezelheti a bemutató tulajdonságokat az Aspose.Slides for .NET segítségével, és egyszerűsítheti a keresést, a márkázást és a munkafolyamatot PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides for .NET két típusú dokumentumtulajdonságot támogat: **Beépített** és **Egyedi**. Mindkét tulajdonságtípust egyszerűen el lehet érni és kezelni az Aspose.Slides for .NET API-val.

Az Aspose.Slides lehetővé teszi a bemutató dokumentumtulajdonságok kezelését az [IDocumentProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/) interfészen keresztül. Ennek az interfésznek egy példánya a [Presentation.DocumentProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/documentproperties/) tulajdonsággal érhető el. Az alábbi példák bemutatják, hogyan olvashatók, módosíthatók és kezelhetők ezek a tulajdonságok.

{{% alert color="info" %}} 
Felhívjuk a figyelmet, hogy a **Application** és **Producer** mezők nem módosíthatók, mivel ezek a mezők mindig az „Aspose Ltd.” és az „Aspose.Slides for .NET x.x.x” értékeket fogják mutatni.
{{% /alert %}} 

## **Bemutató Tulajdonságok Kezelése**

A Microsoft PowerPoint lehetőséget biztosít a bemutató fájlokhoz tulajdonságok hozzáadására. Ezek a dokumentumtulajdonságok lehetővé teszik, hogy hasznos információk legyenek tárolva a fájlokkal együtt. Két típusú dokumentumtulajdonság létezik:

- Rendszer által definiált (beépített) tulajdonságok
- Felhasználó által definiált (egyedi) tulajdonságok

A **beépített** tulajdonságok általános információkat tartalmaznak a dokumentumról, például a dokumentum címét, a szerző nevét, a dokumentum statisztikáit és egyebeket.

A **egyedi** tulajdonságokat a felhasználók **Név/Érték** párokként definiálják, ahol mind a név, mind az érték felhasználó által megadott.

Az Aspose.Slides for .NET használatával a fejlesztők hozzáférhetnek és módosíthatják mind a beépített, mind az egyedi tulajdonságokat.

A Microsoft PowerPoint lehetővé teszi a felhasználók számára a dokumentumtulajdonságok kezelését a Office ikonra kattintva, majd a **File → Info → Properties** pontos választásával. Az **Advanced Properties** kiválasztása után megjelenik egy párbeszédablak, ahol a bemutató fájl összes dokumentumtulajdonságát kezelheti.

A **Properties** párbeszédablakban több fül található, például **General**, **Summary**, **Statistics**, **Contents** és **Custom**.  
Minden fül lehetőséget biztosít a PowerPoint fájlhoz kapcsolódó különféle információk beállítására. A **Custom** fül az felhasználó által definiált tulajdonságok kezelésére szolgál.

## **Beépített Tulajdonságok Elérése**

Ezek a tulajdonságok, amelyeket a [IDocumentProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/idocumentproperties/) interfész biztosít, a következőket tartalmazzák: **Creator** (Szerző), **Description**, **Keywords**, **Created** (Létrehozás dátuma), **Modified** (Módosítás dátuma), **Printed** (Legutóbbi nyomtatás dátuma), **LastModifiedBy**, **SharedDoc** (jelzi, hogy a dokumentum több különböző készítő között megosztott-e), **PresentationFormat**, **Subject**, **Title**, és egyebek.

```cs
using Aspose.Slides;

// Példányosítja a Presentation osztályt, amely egy bemutató fájlt képvisel.
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

## **Beépített Tulajdonságok Módosítása**

A bemutató fájlok beépített tulajdonságainak módosítása ugyanolyan egyszerű, mint azok elérése. Egyszerűen egy karakterlánc értéket rendelhet bármely kívánt tulajdonsághoz, és a tulajdonság értéke frissülni fog. Az alábbi példában bemutatjuk, hogyan módosíthatjuk egy bemutató fájl beépített dokumentumtulajdonságait.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosítja a Presentation osztályt, amely egy bemutató fájlt képvisel.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Lekéri a bemutatóhoz kapcsolódó IDocumentProperties típusú objektum hivatkozását.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Beállítja a beépített tulajdonságokat.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Save the presentation to a file.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Egyedi Bemutató Tulajdonságok Hozzáadása**

Az egyedi bemutató tulajdonságok lehetővé teszik a fejlesztők számára, hogy további metaadatokat vagy specifikus információkat tároljanak egy bemutató fájlban. Az Aspose.Slides egyszerűvé teszi ezen egyedi tulajdonságok programozott létrehozását és kezelését. Az alábbi példák bemutatják, hogyan adhat egyedi tulajdonságokat a bemutatókhoz.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosítja a Presentation osztályt.
using Presentation presentation = new Presentation();

// Lekéri a bemutatóhoz kapcsolódó IDocumentProperties típusú objektum hivatkozását.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Egyedi tulajdonságok hozzáadása.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// A prezentáció mentése egy fájlba.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Egyedi Tulajdonságok Elérése és Módosítása**

Az Aspose.Slides lehetővé teszi a fejlesztők számára, hogy meglévő egyedi tulajdonságokhoz hozzáférjenek és könnyen módosítsák azok értékét. Ez a funkció segít a pontos metaadatok fenntartásában, és támogatja a felhasználói bevitel vagy üzleti logika alapján történő dinamikus frissítéseket. Az alábbi példák bemutatják, hogyan lehet egy bemutatóban lekérni és frissíteni az egyedi tulajdonságok értékét.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Lekéri a bemutatóhoz kapcsolódó IDocumentProperties típusú objektum hivatkozását.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Az egyedi tulajdonságok elérése és módosítása.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // Megjeleníti az egyedi tulajdonság nevét és értékét.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // Módosítja az egyedi tulajdonság értékét.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// A bemutató mentése egy fájlba.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Élő Példa**

Próbálja ki a [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/hu/metadata) online alkalmazást, hogy lássa, hogyan dolgozhat a dokumentumtulajdonságokkal az Aspose.Slides API használatával:

[![Nézze meg és szerkessze a PowerPoint metaadatait](slides-metadata.png)](https://products.aspose.app/slides/hu/metadata)

## ***GYIK**

### Hogyan távolíthatok el egy beépített tulajdonságot egy bemutatóból?

A beépített tulajdonságok a bemutató szerves részei, és nem távolíthatók el teljesen. Azonban módosíthatja azok értékeit, vagy ha az adott tulajdonság lehetővé teszi, beállíthatja őket üresre.

### Mi történik, ha olyan egyedi tulajdonságot adok hozzá, amely már létezik?

Ha olyan egyedi tulajdonságot ad hozzá, amely már létezik, a meglévő érték felül lesz írva az újjal. Nem szükséges előre eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti a tulajdonság értékét.

### Elérhetem a bemutató tulajdonságait a bemutató teljes betöltése nélkül?

Igen, a bemutató tulajdonságait teljes betöltés nélkül elérheti a `GetPresentationInfo` metódus használatával a [PresentationFactory](https://reference.aspose.com/slides/hu/net/aspose.slides/presentationfactory/) osztályból. Ezután használja a [IPresentationInfo](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationinfo/) interfész által biztosított `ReadDocumentProperties` metódust a tulajdonságok hatékony beolvasásához, ami memóriát takarít meg és javítja a teljesítményt.