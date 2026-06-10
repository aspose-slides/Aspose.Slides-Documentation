---
title: Prezentációtulajdonságok kezelése JavaScriptben
linktitle: Prezentáció tulajdonságai
type: docs
weight: 70
url: /hu/nodejs-java/presentation-properties/
keywords:
- PowerPoint tulajdonságok
- prezentációtulajdonságok
- dokumentumtulajdonságok
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
description: "Mesteri szinten kezelje a prezentációtulajdonságokat az Aspose.Slides for Node.js via Java segítségével, és egyszerűsítse a keresést, a márkázást és a munkafolyamatot PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides két típusú dokumentumtulajdonságot támogat: **Beépített** és **Egyéni**. Mindkét tulajdonságtípust könnyen elérhetjük és kezelhetjük az Aspose.Slides API-val.

Az Aspose.Slides lehetővé teszi a prezentáció dokumentumtulajdonságokkal való munkát a [DocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/documentproperties/) osztályon keresztül. Ennek az osztálynak egy példányát a [Presentation.getDocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getDocumentProperties) metódus adja vissza. A következő példák bemutatják, hogyan olvashatók, módosíthatók és kezelhetők ezek a tulajdonságok.

{{% alert color="primary" %}} 
Felhívjuk a figyelmet, hogy a **Application** és **Producer** mezőkre nem állíthat be értékeket, mivel az Aspose Ltd. és az Aspose.Slides for Node.js via Java x.x.x lesz megjelenítve ezekben a mezőkben.
{{% /alert %}} 

## **Prezentációtulajdonságok kezelése**

A Microsoft PowerPoint lehetővé teszi, hogy bizonyos tulajdonságokat adjon a prezentációfájlokhoz. Ezek a dokumentumtulajdonságok hasznos információkat tárolnak a dokumentumok (prezentációfájlok) mellett. Kétféle dokumentumtulajdonság létezik:

- Rendszer által definiált (Beépített) tulajdonságok
- Felhasználó által definiált (Egyéni) tulajdonságok

**Beépített** tulajdonságok általános információkat tartalmaznak a dokumentumról, mint a dokumentum címe, a szerző neve, a dokumentum statisztikái stb. **Egyéni** tulajdonságok olyanok, amelyeket a felhasználók **Név/Érték** párokként definiálnak, ahol a név és az érték is a felhasználó által kerül meghatározásra. Az Aspose.Slides for Node.js via Java segítségével a fejlesztők elérhetik és módosíthatják a beépített és az egyéni tulajdonságok értékeit.

## **Dokumentumtulajdonságok a PowerPointban**

A Microsoft PowerPoint 2007 lehetővé teszi a prezentációfájlok dokumentumtulajdonságainak kezelését. Csak kattintson az Office ikonjára, majd a **Prepare | Properties | Advanced Properties** menüpontra a Microsoft PowerPoint 2007-ben, ahogy az alább látható:

|**Az Advanced Properties menüpont kiválasztása**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

A **Advanced Properties** menüpont kiválasztása után egy párbeszédablak jelenik meg, amely lehetővé teszi a PowerPoint fájl dokumentumtulajdonságainak kezelését, ahogy az alábbi ábrán látható:

|**Tulajdonságok párbeszédablak**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

A fenti **Tulajdonságok párbeszédablakban** látható, hogy számos lap található, például **General**, **Summary**, **Statistics**, **Contents** és **Custom**. Ezek a lapok különböző típusú információk konfigurálását teszik lehetővé a PowerPoint fájlokhoz kapcsolódóan. A **Custom** lapot a PowerPoint fájlok egyéni tulajdonságainak kezelésére használják.

## **A dokumentumtulajdonságok kezelése Aspose.Slides for Node.js via Java használatával**

Ahogyan korábban leírtuk, az Aspose.Slides for Node.js via Java kétféle dokumentumtulajdonságot támogat: **Beépített** és **Egyéni** tulajdonságokat. Így a fejlesztők mindkét típusú tulajdonsághoz hozzáférhetnek az Aspose.Slides for Node.js via Java API használatával. Az Aspose.Slides for Node.js via Java egy [DocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/documentproperties) osztályt biztosít, amely a **Presentation.DocumentProperties** tulajdonságon keresztül a prezentációfájlhoz kapcsolódó dokumentumtulajdonságokat képviseli.

A fejlesztők a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) objektum által biztosított **DocumentProperties** tulajdonságot használhatják a prezentációfájlok dokumentumtulajdonságainak elérésére az alább leírtak szerint:

## **Beépített tulajdonságok elérése**

Ezek a [DocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/documentproperties) objektum által elérhető tulajdonságok a következők: **Creator** (Szerző), **Description**, **Keywords**, **Created** (Létrehozás dátuma), **Modified** (Módosítás dátuma), **Printed** (Utolsó nyomtatás dátuma), **LastModifiedBy**, **Keywords**, **SharedDoc** (Különböző gyártók között megosztott?), **PresentationFormat**, **Subject** és **Title**.

```javascript
// Példányosítsa a Presentation osztályt, amely a prezentációt képviseli
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Hozzon létre egy hivatkozást a Presentation-hez kapcsolódó IDocumentProperties objektumra
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

A prezentáció fájlok beépített tulajdonságainak módosítása olyan egyszerű, mint azok elérése. Egyszerűen egy karakterlánc értéket adhat meg bármely kívánt tulajdonságnak, és ez módosítja a tulajdonság értékét. Az alább bemutatott példában azt mutatjuk be, hogyan módosíthatjuk a prezentáció fájl beépített dokumentumtulajdonságait az Aspose.Slides for Node.js via Java használatával.

```javascript
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
    // Mentse el a prezentációt egy fájlba
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ez a példa módosítja a beépített tulajdonságokat, amely az alábbiakban látható:

|**Beépített dokumentumtulajdonságok módosítás után**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Egyéni dokumentumtulajdonságok hozzáadása**

Az Aspose.Slides for Node.js via Java lehetővé teszi a fejlesztők számára, hogy egyéni értékeket adjanak a prezentáció dokumentumtulajdonságaihoz. Az alábbi példa bemutatja, hogyan állíthatók be az egyéni tulajdonságok egy prezentációhoz.

```javascript
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
    // Kiválasztott tulajdonság eltávolítása
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

Az Aspose.Slides for Node.js via Java lehetővé teszi a fejlesztők számára az egyéni tulajdonságok értékeinek elérését is. Az alábbi példa bemutatja, hogyan férhet hozzá és módosíthatja ezeket az egyéni tulajdonságokat egy prezentáció esetén.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Hozzon létre egy hivatkozást a Presentation-hez kapcsolódó DocumentProperties objektumra
    var dp = pres.getDocumentProperties();
    // Egyéni tulajdonságok elérése és módosítása
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Az egyéni tulajdonságok neveinek és értékeinek megjelenítése
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // Az egyéni tulajdonságok értékeinek módosítása
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // Mentse el a prezentációt egy fájlba
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ez a példa módosítja a [PPTX](https://docs.fileformat.com/presentation/pptx/) prezentáció egyéni tulajdonságait. A következő ábrák a módosítás előtti és utáni egyéni tulajdonságokat mutatják:

|**Módosítás előtti egyéni tulajdonságok**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Módosítás utáni egyéni tulajdonságok**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Haladó dokumentumtulajdonságok**

{{% alert color="primary" %}} 
Új módszerek [ReadDocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), és [WriteBindedPresentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) lettek hozzáadva a [PresentationInfo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PresentationInfo) osztályhoz, a [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) tulajdonság‑setter logikája módosult.
{{% /alert %}} 

A két új módszer, a [ReadDocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) és a [UpdateDocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) hozzá lett adva a [PresentationInfo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PresentationInfo) osztályhoz. Gyors hozzáférést biztosítanak a dokumentumtulajdonságokhoz, és lehetővé teszik a tulajdonságok módosítását és frissítését anélkül, hogy a teljes prezentációt betöltenék.

A tipikus forgatókönyv, amely betölti a tulajdonságokat, módosít egy értéket, majd frissíti a dokumentumot, a következő módon valósítható meg:

```javascript
// olvasd be a prezentáció adatait
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// szerezze be az aktuális tulajdonságokat
var props = info.readDocumentProperties();
// állítsa be a Szerző és Cím mezők új értékeit
props.setAuthor("New Author");
props.setTitle("New Title");
// frissítse a prezentációt az új értékekkel
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Egy másik módja, hogy egy adott prezentáció tulajdonságait sablonként használjuk fel más prezentációk tulajdonságainak frissítésére:

```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Új sablon hozható létre a semmiből, majd több prezentáció frissítésére használható:

```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Helyesírási nyelv beállítása**

Az Aspose.Slides a LanguageId tulajdonságot (a PortionFormat osztály által biztosított) kínálja, amely lehetővé teszi a PowerPoint dokumentum helyesírási nyelvének beállítását. A helyesírási nyelv az a nyelv, amelynek helyesírását és nyelvtanát a PowerPoint ellenőrzi. Ez a JavaScript kód bemutatja, hogyan állítható be a PowerPoint helyesírási nyelve: xxx Miért hiányzik a LanguageId a JavaScript PortionFormat osztályból?

```javascript
var pres = new aspose.slides.Presentation(pptxFileName);
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
    portionFormat.setLanguageId("zh-CN"); // állítsa be egy helyesírási nyelv azonosítóját
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Alapértelmezett nyelv beállítása**

Ez a JavaScript kód bemutatja, hogyan állítható be az alapértelmezett nyelv egy teljes PowerPoint prezentációhoz:

```javascript
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

[![PowerPoint metaadatok megtekintése és szerkesztése](slides-metadata.png)](https://products.aspose.app/slides/hu/metadata)

## ***GYIK**

**Hogyan távolíthatok el egy beépített tulajdonságot egy prezentációból?**

A beépített tulajdonságok a prezentáció szerves részei, és nem távolíthatók el teljesen. Azonban megváltoztathatja az értéküket, vagy ha a konkrét tulajdonság megengedi, üresre állíthatja őket.

**Mi történik, ha már létező egyéni tulajdonságot adok hozzá?**

Ha már létező egyéni tulajdonságot ad hozzá, a meglévő érték felül lesz írva az újjal. Nem szükséges előre eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti a tulajdonság értékét.

**Elérhetem a prezentáció tulajdonságait anélkül, hogy a teljes prezentációt betölteném?**

Igen, a prezentáció tulajdonságait a teljes prezentáció betöltése nélkül is elérheti a [PresentationFactory](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationfactory/) osztály `getPresentationInfo` metódusának használatával. Ezután a [PresentationInfo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationinfo/) osztály által biztosított `readDocumentProperties` metódussal hatékonyan olvashatja a tulajdonságokat, így memóriát takarít meg és javítja a teljesítményt.