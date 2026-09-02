---
title: Prezentáció tulajdonságok kezelése JavaScript-ben
linktitle: Prezentáció tulajdonságok
type: docs
weight: 70
url: /hu/nodejs-java/presentation-properties/
keywords:
- PowerPoint tulajdonságok
- prezentáció tulajdonságok
- dokumentumtulajdonságok
- beépített tulajdonságok
- egyéni tulajdonságok
- speciális tulajdonságok
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
description: "Kezelje a prezentáció tulajdonságait az Aspose.Slides for Node.js via Java segítségével, és egyszerűsítse a keresést, a márkázást és a munkafolyamatot PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides két típusú dokumentumtulajdonságot támogat: **Beépített** és **Egyéni**. Mindkét tulajdonságtípust könnyen el lehet érni és kezelni az Aspose.Slides API segítségével.

Az Aspose.Slides lehetővé teszi, hogy a prezentáció dokumentumtulajdonságokkal a [DocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/documentproperties/) osztályon keresztül dolgozzon. Ennek az osztálynak egy példánya a [Presentation.getDocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getDocumentProperties) metódus visszatérési értéke. A következő példák bemutatják, hogyan olvassuk, módosítsuk és kezeljük ezeket a tulajdonságokat.

{{% alert color="info" title="Note" %}}
Kérjük, vegye figyelembe, hogy a **Application** és **AppVersion** mezők nem módosíthatók. Az Aspose.Slides minden mentéskor felülírja őket, így egy mentett prezentáció mindig azt a szöveget jelzi, hogy "Aspose.Slides for Node.js via Java" és a könyvtár verzióját, amely előállította. A `setNameOfApplication`‑nek átadott bármely érték eldobásra kerül a prezentáció írása során.
{{% /alert %}} 

## **Prezentáció tulajdonságainak kezelése**

A Microsoft PowerPoint lehetőséget nyújt a prezentációfájlokhoz tulajdonságok hozzáadására. Ezek a dokumentumtulajdonságok hasznos információk tárolását teszik lehetővé a dokumentumok (prezentációfájlok) mellett. Kétféle dokumentumtulajdonság létezik:

- Rendszer által definiált (Beépített) tulajdonságok
- Felhasználó által definiált (Egyéni) tulajdonságok

A **Beépített** tulajdonságok általános információkat tartalmaznak a dokumentumról, például a dokumentum címe, a szerző neve, a dokumentum statisztikái stb. Az **Egyéni** tulajdonságok olyanok, amelyeket a felhasználók **Név/Érték** párok formájában definiálnak, ahol mind a név, mind az érték a felhasználó által meghatározott. Az Aspose.Slides for Node.js via Java segítségével a fejlesztők hozzáférhetnek és módosíthatják mind a beépített, mind az egyéni tulajdonságok értékeit.

## **Dokumentumtulajdonságok a PowerPointban**

A Microsoft PowerPoint 2007 lehetővé teszi a prezentációfájlok dokumentumtulajdonságainak kezelését. Elég csak rákattintani az Office ikonra, majd a **Prepare | Properties | Advanced Properties** menüpontra, ahogy az alább látható:

|**Speciális tulajdonságok menüpont kiválasztása**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

A **Advanced Properties** menüpont kiválasztása után egy párbeszédablak jelenik meg, amely lehetővé teszi a PowerPoint-fájl dokumentumtulajdonságainak kezelését, ahogy az alábbi ábra mutatja:

|**Tulajdonságok párbeszédablaka**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

A fenti **Tulajdonságok párbeszédablak** számos lapot tartalmaz, például **General**, **Summary**, **Statistics**, **Contents** és **Custom**. Ezek a lapok különböző információk konfigurálását teszik lehetővé a PowerPoint-fájlokhoz. Az **Custom** lap a PowerPoint-fájlok egyéni tulajdonságainak kezelésére szolgál.

## **Beépített tulajdonságok elérése**

Az [DocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/documentproperties) objektum által kiadott tulajdonságok a következőket tartalmazzák: **Creator** (Szerző), **Description**, **Keywords**, **Created** (Létrehozás dátuma), **Modified** (Módosítás dátuma), **Printed** (Utolsó nyomtatás dátuma), **LastModifiedBy**, **Keywords**, **SharedDoc** (Megosztott dokumentum?), **PresentationFormat**, **Subject** és **Title**.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Példányosítsa a Presentation osztályt, amely a prezentációt képviseli
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Hozzon létre egy hivatkozást a prezentációhoz tartozó IDocumentProperties objektumra
    var dp = pres.getDocumentProperties();
    // Jelenítse meg a beépített tulajdonságokat
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

A beépített tulajdonságok módosítása olyan egyszerű, mint azok elérése. Egyszerűen egy karakterlánc értéket adhat a kívánt tulajdonsághoz, és az érték módosul. Az alábbi példában bemutatjuk, hogyan módosíthatjuk a prezentáció beépített dokumentumtulajdonságait az Aspose.Slides for Node.js via Java használatával.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Hozzon létre egy hivatkozást a prezentációhoz tartozó IDocumentProperties objektumra
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

Ez a példa módosítja a prezentáció beépített tulajdonságait, amelyek az alább láthatóak:

|**Beépített dokumentumtulajdonságok módosítás után**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Egyéni dokumentumtulajdonságok hozzáadása**

Az Aspose.Slides for Node.js via Java lehetővé teszi a fejlesztők számára, hogy egyéni értékeket adjanak a prezentáció dokumentumtulajdonságaihoz. Az alábbi példában látható, hogyan állíthatók be egyéni tulajdonságok egy prezentációhoz.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Dokumentumtulajdonságok lekérése
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

Az Aspose.Slides for Node.js via Java lehetővé teszi a fejlesztők számára, hogy hozzáférjenek az egyéni tulajdonságok értékeihez. Az alábbi példa bemutatja, hogyan érheti el és módosíthatja ezeket az egyéni tulajdonságokat egy prezentációban.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Hozzon létre egy hivatkozást a prezentációhoz tartozó DocumentProperties objektumra
    var dp = pres.getDocumentProperties();
    // Egyéni tulajdonságok elérése és módosítása
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Az egyéni tulajdonságok neveinek és értékeinek megjelenítése
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

Ez a példa módosítja a [PPTX](https://docs.fileformat.com/presentation/pptx/) prezentáció egyéni tulajdonságait. Az alábbi ábrák a prezentáció egyéni tulajdonságait mutatják módosítás előtt és után:

|**Egyéni tulajdonságok módosítás előtt**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Egyéni tulajdonságok módosítás után**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Speciális dokumentumtulajdonságok**

{{% alert color="info" title="Note" %}}
Új módszerek: [ReadDocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), és [WriteBindedPresentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) lettek hozzáadva a [PresentationInfo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PresentationInfo) osztályhoz, a [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) tulajdonság beállítójának logikája módosult.
{{% /alert %}} 

Az új [ReadDocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) és [UpdateDocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) módszerek a [PresentationInfo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PresentationInfo) osztályhoz lettek hozzáadva. Ezek gyors hozzáférést biztosítanak a dokumentumtulajdonságokhoz, és lehetővé teszik a tulajdonságok módosítását a teljes prezentáció betöltése nélkül.

A tipikus forgatókönyv a tulajdonságok betöltése, értékek módosítása és a dokumentum frissítése a következő módon valósítható meg:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// olvassa be a prezentáció információit
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// obtain the current properties
var props = info.readDocumentProperties();
// set the new values of Author and Title fields
props.setAuthor("New Author");
props.setTitle("New Title");
// update the presentation with a new values
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Létezik egy másik mód is, amelyben egy adott prezentáció tulajdonságait sablonként használva frissíthetjük a tulajdonságokat más prezentációkban:

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

Új sablon hozható létre a semmiből, és azt felhasználhatjuk több prezentáció frissítésére:

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

Az Aspose.Slides a LanguageId tulajdonságot (a PortionFormat osztály által kiadott) biztosítja, hogy beállíthassa a helyesírási nyelvet egy PowerPoint-dokumentumhoz. A helyesírási nyelv az a nyelv, amelyre a PowerPoint helyesírás- és nyelvtani ellenőrzése vonatkozik. 

Ez a JavaScript kód megmutatja, hogyan állítható be a helyesírási nyelv egy PowerPointhoz: xxx Miért hiányzik a LanguageId a JavaScript PortionFormat osztályból?

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
    portionFormat.setLanguageId("zh-CN");// a helyesírási nyelv azonosítójának beállítása
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Alapértelmezett nyelv beállítása**

Ez a JavaScript kód megmutatja, hogyan állítható be az alapértelmezett nyelv egy teljes PowerPoint prezentációhoz:

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

Próbálja ki az **Aspose.Slides Metadata** online alkalmazást, hogy lássa, hogyan dolgozhat a dokumentumtulajdonságokkal az Aspose.Slides API segítségével:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/hu/metadata)

## **FAQ**

**Hogyan távolíthatok el egy beépített tulajdonságot egy prezentációból?**

A beépített tulajdonságok a prezentáció szerves részei, és nem távolíthatók el teljesen. Azonban megváltoztathatja az értéküket vagy, ha a konkrét tulajdonság engedélyezi, üresen is beállíthatja.

**Mi történik, ha már létező egyéni tulajdonságot adok hozzá?**

Ha olyan egyéni tulajdonságot ad hozzá, amely már létezik, a meglévő érték felül lesz írva az újjal. Nem szükséges előbb eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti a tulajdonság értékét.

**Elérhetem a prezentáció tulajdonságait anélkül, hogy teljesen betölteném a prezentációt?**

Igen. Használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) metódust, majd a [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) metódust a tárolt dokumentum metaadatok olvasásához anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) példányt hozna létre. Lásd a [Build a Lightweight Presentation Inventory](/slides/hu/nodejs-java/examine-presentation/) cikket a teljes jelentéspéldáért és a formátumspecifikus korlátozásokért.