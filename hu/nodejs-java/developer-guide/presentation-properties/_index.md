---
title: Presentáció tulajdonságok kezelése JavaScriptben
linktitle: Prezentáció tulajdonságai
type: docs
weight: 70
url: /hu/nodejs-java/presentation-properties/
keywords:
- PowerPoint tulajdonságok
- prezentáció tulajdonságok
- dokumentum tulajdonságok
- beépített tulajdonságok
- egyéni tulajdonságok
- haladó tulajdonságok
- tulajdonságok kezelése
- tulajdonságok módosítása
- dokumentum metaadatok
- metaadatok szerkesztése
- helyesírási nyelv
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Mesteri prezentációs tulajdonságok az Aspose.Slides for Node.js via Java használatával, és egyszerűsítse a keresést, a márkázást és a munkafolyamatot PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides két típusú dokumentumtulajdonságot támogat: **Beépített** és **Egyéni**. Mindkét tulajdonságtípust könnyen el lehet érni és kezelni az Aspose.Slides API segítségével.

Az Aspose.Slides lehetővé teszi a prezentáció dokumentumtulajdonságokkal való munkát a [DocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/documentproperties/) osztályon keresztül. Ennek az osztálynak egy példányát a [Presentation.getDocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getDocumentProperties) metódus adja vissza. A következő példák bemutatják, hogyan lehet ezeket a tulajdonságokat olvasni, módosítani és kezelni.

{{% alert color="info" title="Note" %}}
Kérjük vegye figyelembe, hogy a **Application** és **AppVersion** mezőket nem lehet módosítani. Az Aspose.Slides minden mentéskor felülírja őket, ezért egy mentett prezentáció mindig azt jelzi, hogy "Aspose.Slides for Node.js via Java" és a könyvtár verziója, amely létrehozta. A `setNameOfApplication`-nek átadott bármely értéket eldobja a rendszer a prezentáció írásakor.
{{% /alert %}} 

## **Prezentációtulajdonságok kezelése**

A Microsoft PowerPoint lehetőséget biztosít a prezentációs fájlokhoz bizonyos tulajdonságok hozzáadására. Ezek a dokumentumtulajdonságok hasznos információk tárolását teszik lehetővé a dokumentumokkal (prezentációs fájlokkal) együtt. Kétféle dokumentumtulajdonság létezik:

- Rendszer által definiált (Beépített) tulajdonságok
- Felhasználó által definiált (Egyéni) tulajdonságok

**Beépített** tulajdonságok általános információkat tartalmaznak a dokumentumról, például a dokumentum címét, a szerző nevét, a dokumentum statisztikáit stb. **Egyéni** tulajdonságok olyanok, amelyeket a felhasználók **Név/Érték** párokként definiálnak, ahol a név és az érték is a felhasználó által kerül meghatározásra. Az Aspose.Slides for Node.js via Java használatával a fejlesztők hozzáférhetnek és módosíthatják a beépített és az egyéni tulajdonságok értékeit.

## **Dokumentumtulajdonságok a PowerPointban**

A Microsoft PowerPoint 2007 lehetővé teszi a prezentációs fájlok dokumentumtulajdonságainak kezelését. Csak kattintson az Office ikonra, majd a **Prepare | Properties | Advanced Properties** menüpontra a Microsoft PowerPoint 2007-ben, ahogyan az alább látható:

|**Az Advanced Properties menüpont kiválasztása**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Az **Advanced Properties** menüpont kiválasztása után egy párbeszédablak jelenik meg, amely lehetővé teszi a PowerPoint-fájl dokumentumtulajdonságainak kezelését, az alábbi ábrán látható módon:

|**Tulajdonságok párbeszédablaka**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Az előző **Tulajdonságok párbeszédablakban** számos lapot láthat, például **General**, **Summary**, **Statistics**, **Contents** és **Custom**. Ezek a lapok különféle információk beállítását teszik lehetővé a PowerPoint-fájlokkal kapcsolatban. A **Custom** lap a PowerPoint-fájlok egyéni tulajdonságainak kezelésére szolgál.

Dokumentumtulajdonságok kezelése az Aspose.Slides for Node.js via Java használatával

Ahogy korábban leírtuk, az Aspose.Slides for Node.js via Java kétféle dokumentumtulajdonságot támogat: **Beépített** és **Egyéni** tulajdonságokat. Így a fejlesztők mindkét típusú tulajdonsághoz hozzáférhetnek az Aspose.Slides for Node.js via Java API használatával. Az Aspose.Slides for Node.js via Java egy [DocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/documentproperties) osztályt biztosít, amely a prezentációs fájlhoz kapcsolódó dokumentumtulajdonságokat reprezentálja a **Presentation.DocumentProperties** tulajdonságon keresztül.

Fejlesztők a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) objektum által biztosított **DocumentProperties** tulajdonságot használva hozzáférhetnek a prezentációs fájlok dokumentumtulajdonságaihoz, amint az alább le van írva:

## **Nyilvános tulajdonságok olvasása titkosított prezentációból**

A megnyitási jelszó általában a prezentáció tartalmát és a dokumentumtulajdonságokat is védi. Ha a prezentációt úgy titkosítják, hogy a [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) metódusnak `false` értéket adnak, akkor a dokumentumtulajdonságok nyilvánosak maradnak. Ezután az alkalmazás a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) metódusnak `true` értéket adva a nyilvános metaadatokat olvashatja anélkül, hogy megadná a megnyitási jelszót.

A csak dokumentumtulajdonságok betöltését vezérlő opció határozza meg, hogy az Aspose.Slides mit tölt be; semmit sem titkosít vissza. Ha a tulajdonságok a titkosítás részét képezték, akkor jelszó nélkül a betöltés sikertelen. Ha a prezentáció nincs titkosítva, az opciót figyelmen kívül hagyják, és a teljes prezentáció betöltődik.

A következő példa ellenőrzi a betöltési módot a [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) segítségével, majd beolvassa a beépített tulajdonságokat a [Presentation.getDocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getDocumentProperties) segítségével:

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const properties = presentation.getDocumentProperties();

        console.log("Author: " + properties.getAuthor());
        console.log("Title: " + properties.getTitle());
        console.log("Keywords: " + properties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

Ebben a módban a dia tartalma nem töltődik be. A diák, a masterek, az elrendezések, az alakzatok, a média és egyéb prezentációs objektumok nem állnak rendelkezésre. Az alkalmazásoknak mindig ellenőrizniük kell a [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) metódust, mielőtt olyan műveletet hajtanának végre, amely a teljes prezentációs objektummodellt igényli.

{{% alert color="warning" title="Warning" %}}
A nyilvános metaadatok felfedhetik a szerzők nevét, a címeket, a tárgyakat, a kulcsszavakat, a céginformációkat, a megjegyzéseket és az egyéni értékeket. Titkosítsa a személyes tulajdonságokat a prezentációval együtt. Hagyja őket nyilvánosnak csak akkor, ha indexelés, osztályozás, keresés vagy dokumentumkezelő rendszerek speciális igényei miatt jelszó nélkül kell hozzáférni.
{{% /alert %}}

## **Titkosított prezentáció tulajdonságainak frissítése**

Titkosított PPTX fájl esetén a dokumentumtulajdonságok-only módban betöltött prezentáció arra szolgál, hogy a nyilvános metaadatokat olvassa. Az Aspose.Slides nem tudja menteni a módosított tulajdonságokat ebből a csak metaadatot tartalmazó objektumból, mivel a nyilvános tulajdonságoknak összhangban kell lenniük a titkosított prezentációban lévő megfelelő adatokkal. Ennek frissítése ezért a helyes megnyitási jelszót és a teljes betöltést igényli.

A következő példa a prezentációt a [LoadOptions.setPassword](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#setPassword) segítségével nyitja meg, frissíti a nyilvános beépített tulajdonságokat, és elmenti az eredményt. Ezután a [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationinfo/#isEncrypted) metódust használja, hogy ellenőrizze a titkosítás megmaradását, és a nyilvános metaadatokat jelszó nélkül nyissa meg az új értékek ellenőrzéséhez:

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
    presentation.save(outputPath, slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(outputPath);
console.log("The presentation is encrypted: " + presentationInfo.isEncrypted());

const metadataLoadOptions = new slides.LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

const metadataPresentation = new slides.Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        console.log("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        console.log("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Ha egy alkalmazás nem kap engedélyt a prezentáció tartalmának visszafejtésére vagy betöltésére, akkor a titkosított PPTX fájl nyilvános tulajdonságait csak olvashatóként kell kezelnie.

## **Beépített tulajdonságok elérése**

Ezeket a tulajdonságokat a [DocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/documentproperties) objektum teszi elérhetővé: **Creator** (Szerző), **Description**, **Keywords**, **Created** (Létrehozás dátuma), **Modified** (Módosítás dátuma), **Printed** (Legutóbbi nyomtatás dátuma), **LastModifiedBy**, **SharedDoc** (Megosztott dokumentum különböző előállítók között?), **PresentationFormat**, **Subject** és **Title**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// A prezentációt képviselő Presentation osztály példányosítása
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Hivatkozás létrehozása a Presentation-hez kapcsolódó IDocumentProperties objektumra
    var dp = pres.getDocumentProperties();
    // A beépített tulajdonságok megjelenítése
    console.log("Category : " + dp.getCategory());
    console.log("Current Status : " + dp.getContentStatus());
    console.log("Creation Date : " + dp.getCreatedTime());
    console.log("Author : " + dp.getAuthor());
    console.log("Description : " + dp.getComments());
    console.log("KeyWords : " + dp.getKeywords());
    console.log("Last Modified By : " + dp.getLastSavedBy());
    console.log("Supervisor : " + dp.getManager());
    console.log("Modified Date : " + dp.getLastSavedTime());
    console.log("Presentation Format : " + dp.getPresentationFormat());
    console.log("Last Print Date : " + dp.getLastPrinted());
    console.log("Is Shared between producers : " + dp.getSharedDoc());
    console.log("Subject : " + dp.getSubject());
    console.log("Title : " + dp.getTitle());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Beépített tulajdonságok módosítása**

A prezentációs fájlok beépített tulajdonságainak módosítása ugyanolyan egyszerű, mint a hozzáférésük. Egyszerűen egy karakterlánc értéket adhat meg bármely kívánt tulajdonságnak, és a tulajdonság értéke módosul. Az alábbi példában bemutattuk, hogyan módosíthatjuk a prezentációs fájl beépített dokumentumtulajdonságait az Aspose.Slides for Node.js via Java használatával.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Hozzon létre egy hivatkozást a Presentation-hez kapcsolódó IDocumentProperties objektumra
    var dp = pres.getDocumentProperties();
    // Állítsa be a beépített tulajdonságokat
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // Mentse a prezentációt egy fájlba
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ez a példa módosítja a prezentáció beépített tulajdonságait, amelyek az alábbiakban láthatók:

|**Beépített dokumentumtulajdonságok módosítás után**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Egyéni dokumentumtulajdonságok hozzáadása**

Az Aspose.Slides for Node.js via Java lehetővé teszi a fejlesztők számára, hogy egyéni értékeket adjanak hozzá a prezentáció dokumentumtulajdonságaihoz. Az alábbi példában látható, hogyan állíthatók be az egyéni tulajdonságok egy prezentációhoz.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Dokumentum tulajdonságainak lekérése
    var dProps = pres.getDocumentProperties();
    // Egyéni tulajdonságok hozzáadása
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // Tulajdonság nevének lekérése adott indexnél
    var getPropertyName = dProps.getCustomPropertyName(2);
    // Kijelölt tulajdonság eltávolítása
    dProps.removeCustomProperty(getPropertyName);
    // Prezentáció mentése
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**Egyéni dokumentumtulajdonságok hozzáadva**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Egyéni tulajdonságok elérése és módosítása**

Az Aspose.Slides for Node.js via Java lehetővé teszi a fejlesztők számára, hogy hozzáférjenek az egyéni tulajdonságok értékeihez. Az alábbi példa azt mutatja, hogyan érheti el és módosíthatja ezeket az egyéni tulajdonságokat egy prezentációban.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Hozzon létre egy hivatkozást a Presentation-hez kapcsolódó DocumentProperties objektumra
    var dp = pres.getDocumentProperties();
    // Az egyéni tulajdonságok elérése és módosítása
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Az egyéni tulajdonságok nevének és értékének megjelenítése
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // Az egyéni tulajdonságok értékeinek módosítása
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // Mentse a prezentációt egy fájlba
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ez a példa módosítja a [PPTX ](https://docs.fileformat.com/presentation/pptx/) prezentáció egyéni tulajdonságait. Az alábbi ábrák a prezentáció egyéni tulajdonságait mutatják módosítás előtt és után:

|**Egyéni tulajdonságok módosítás előtt**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Egyéni tulajdonságok módosítás után**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Speciális dokumentumtulajdonságok**

{{% alert color="info" title="Note" %}}
Új metódusok – [ReadDocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), és [WriteBindedPresentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) – lettek hozzáadva a [PresentationInfo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PresentationInfo) osztályhoz, a [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) tulajdonság beállítójának logikája megváltozott.
{{% /alert %}} 

A két új metódus – [ReadDocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) és [UpdateDocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) – hozzá lett adva a [PresentationInfo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PresentationInfo) osztályhoz. Gyors hozzáférést biztosítanak a dokumentumtulajdonságokhoz, és lehetővé teszik azok módosítását és frissítését anélkül, hogy a teljes prezentációt betöltenék.

A tipikus forgatókönyv, amikor betöltjük a tulajdonságokat, módosítunk egy értéket, és frissítjük a dokumentumot, az alábbi módon valósítható meg:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// olvassa be a prezentáció adatait
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
var props = info.readDocumentProperties();
props.setAuthor("New Author");
props.setTitle("New Title");
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Van egy másik mód is, amelyben egy adott prezentáció tulajdonságait sablonként használva frissíthetők más prezentációk tulajdonságai:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("template.pptx");
var template = info.readDocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Új sablon hozható létre teljesen az elejétől, majd használható több prezentáció frissítésére:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var template = new aspose.slides.DocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Helyesírási nyelv beállítása**

Az Aspose.Slides a LanguageId tulajdonságot (a PortionFormat osztály által biztosítva) biztosítja, amely lehetővé teszi a PowerPoint-dokumentum helyesírási nyelvének beállítását. A helyesírási nyelv az a nyelv, amelynek helyesírását és nyelvtanát a PowerPoint ellenőrzi.

Ez a JavaScript kód megmutatja, hogyan állítható be a PowerPoint helyesírási nyelve: xxx Miért hiányzik a LanguageId a JavaScript PortionFormat osztályból?

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();
    var newPortion = new aspose.slides.Portion();
    var font = new aspose.slides.FontData("SimSun");
    var portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);
    portionFormat.setLanguageId("zh-CN");// állítsa be a helyesírási nyelv azonosítóját
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Alapértelmezett nyelv beállítása**

Ez a JavaScript kód megmutatja, hogyan állítható be az alapértelmezett nyelv az egész PowerPoint-prezentációhoz:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // Új téglalap alakzat hozzáadása szöveggel
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // Ellenőrzi az első rész nyelvét
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Élő példa**

Próbálja ki a [**Aspose.Slides Metadata**](https://products.aspose.app/slides/hu/metadata) online alkalmazást, hogy lássa, hogyan dolgozhat a dokumentumtulajdonságokkal az Aspose.Slides API-n keresztül:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/hu/metadata)

## **GYIK**

**Hogyan távolíthatok el egy beépített tulajdonságot egy prezentációból?**

A beépített tulajdonságok a prezentáció szerves részét képezik, és nem távolíthatók el teljesen. Azonban megváltoztathatja az értéküket, vagy ha az adott tulajdonság megengedi, üresre állíthatja őket.

**Mi történik, ha egy már létező egyéni tulajdonságot adok hozzá?**

Ha egy már létező egyéni tulajdonságot ad hozzá, a meglévő érték felülíródik az újjal. Nem szükséges a tulajdonságot előre eltávolítani vagy ellenőrizni, mivel az Aspose.Slides automatikusan frissíti a tulajdonság értékét.

**Hozzáférhetek a prezentáció tulajdonságaihoz anélkül, hogy teljesen betölteném a prezentációt?**

Igen. Használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) metódust, majd a [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) metódust a tárolt dokumentum metaadatok olvasásához anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) példányt hozna létre. Tekintse meg a [Build a Lightweight Presentation Inventory](/slides/hu/nodejs-java/examine-presentation/) példát a teljes jelentési példáért és a formátumspecifikus korlátozásokért.

**Olvashatok nyilvános tulajdonságokat egy titkosított prezentációból a megnyitási jelszó nélkül?**

Igen. A dokumentumtulajdonságok titkosítását a prezentáció titkosítása előtt le kell tiltani, és a prezentációt a dokumentumtulajdonságok-only módban kell betölteni.

**Frissíthetek egy titkosított PPTX fájlt dokumentumtulajdonságok-only módban?**

Nem. A nyilvános és a titkosított tulajdonságadatoknak összhangban kell maradniuk, ezért egy titkosított PPTX fájl frissítéséhez a teljes prezentációt kell betölteni a megfelelő megnyitási jelszóval.