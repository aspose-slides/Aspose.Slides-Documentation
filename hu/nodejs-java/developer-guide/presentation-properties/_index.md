---
title: Prezentációs tulajdonságok kezelése JavaScriptben
linktitle: Prezentációs tulajdonságok
type: docs
weight: 70
url: /hu/nodejs-java/presentation-properties/
keywords:
- PowerPoint tulajdonságok
- prezentációs tulajdonságok
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
description: "Mestere a prezentációs tulajdonságokat az Aspose.Slides for Node.js via Java használatával, és optimalizálja a keresést, a márkaépítést és a munkafolyamatot PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides for Node.js via Java **beépített** és **egyéni** dokumentumtulajdonságokat támogat. Ezeket a tulajdonságokat a prezentáció metaadatai olvasására és frissítésére használhatja, például a szerző, a cím és a felhasználó által meghatározott értékek.

Az Aspose.Slides lehetővé teszi a prezentáció dokumentumtulajdonságokkal való munkát a [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) osztályon keresztül. Ennek az osztálynak egy példánya a [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) metódus hívásával kap vissza. Az alábbi példák bemutatják, hogyan lehet olvasni, módosítani és kezelni ezeket a tulajdonságokat.

{{% alert color="info" title="Megjegyzés" %}}
Az Aspose.Slides kezeli az alkalmazás és a gyártó metaadatait a prezentációk mentésekor; ezek a mezők azonosítják a kimenetet létrehozó szoftvert.
{{% /alert %}}

## **A prezentáció tulajdonságainak kezelése**

A dokumentumtulajdonságok leíró információkat tárolnak a prezentáció tartalma mellett. Két kategóriába sorolhatók:

- **Beépített tulajdonságok** szabványos metaadatokat tartalmaznak, például a címet, a szerzőt és a dokumentum statisztikákat.
- **Egyéni tulajdonságok** felhasználó által meghatározott név/érték párokat tárolnak.

Az Aspose.Slides for Node.js via Java mindkét kategóriához hozzáférést biztosít. PowerPointban válassza a **File → Info → Properties → Advanced Properties** menüpontot a dokumentum metaadatainak megtekintéséhez. A párbeszédablak információkat csoportosít fülekre, például **Summary**, **Statistics**, **Contents**, és **Custom**. Az **Custom** fül használatával kezelheti a felhasználó által definiált tulajdonságokat.

## **Nyilvános tulajdonságok olvasása titkosított prezentációból**

A nyitójelszó általában védi mind a prezentáció tartalmát, mind a dokumentumtulajdonságokat. Ha egy prezentáció titkosítva van a [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) `false` értékkel történő hívása után, a dokumentumtulajdonságai nyilvánosak maradnak. Az alkalmazás ezután a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) `true` értékével hívhatja meg, és a nyitójelszó megadása nélkül olvashatja a nyilvános metaadatokat.

Az [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) szabályozza, hogy az Aspose.Slides mit tölt be; semmit sem dekriptál. Ha a tulajdonságok a titkosítás részei voltak, jelszó nélkül a betöltés sikertelen. Ha a prezentáció nincs titkosítva, az opció figyelmen kívül marad, és a teljes prezentáció betöltődik.

A példa egy titkosított prezentációt igényel, amelynek a dokumentumtulajdonságai nyilvánosak maradtak. A betöltési módot a [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) ellenőrzi, majd a beépített tulajdonságokat a [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) hívja.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const documentProperties = presentation.getDocumentProperties();

        console.log("Author: " + documentProperties.getAuthor());
        console.log("Title: " + documentProperties.getTitle());
        console.log("Keywords: " + documentProperties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

Ebben a módban a diák tartalma nem töltődik be. A diák, mesterdiák, elrendezések, alakzatok, média és egyéb prezentációs objektumok nem érhetők el. Az alkalmazásoknak mindig ellenőrizniük kell a [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) hívással, mielőtt olyan műveletet hajtanának végre, amely a teljes prezentációs objektummodellt igényli.

{{% alert color="warning" title="Figyelmeztetés" %}}
Az nyilvános metaadatok felfedhetik a szerző nevét, címeket, tárgyakat, kulcsszavakat, vállalati információkat, megjegyzéseket és egyéni értékeket. Titkosítsa az érzékeny tulajdonságokat a prezentációval együtt. Csak akkor hagyja nyilvánosan elérhetően, ha indexelés, osztályozás, keresés vagy dokumentumkezelő rendszereknek kifejezett igénye van a jelszó nélküli hozzáférésre.
{{% /alert %}}

## **Titkosított prezentáció tulajdonságainak frissítése**

Egy titkosított PPTX fájl esetén a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) `true` értékével betöltött prezentáció a nyilvános metaadatok olvasására szolgál. Az Aspose.Slides nem tudja menteni a módosított tulajdonságokat ebből a csak metaadatokat tartalmazó objektumból, mivel a nyilvános tulajdonságoknak összhangban kell lenniük a titkosított prezentáció megfelelő adataival. A frissítéshez ezért a helyes nyitójelszó és a teljes betöltés szükséges.

A példa egy titkosított PPTX prezentációt igényel nyilvános dokumentumtulajdonságokkal és ismert nyitójelszóval. A teljes prezentációt a [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setPassword) hívással nyitja meg, frissíti a nyilvános beépített tulajdonságokat, és elmenti az eredményt. Ezután a [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#isEncrypted) használatával ellenőrzi, hogy a titkosítás megmaradt-e, és a nyilvános metaadatokat jelszó nélkül nyitja meg az új értékek ellenőrzésére:

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");
    
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

Ha egy alkalmazás nem engedélyezett a prezentáció tartalmának dekriptálására vagy betöltésére, a titkosított PPTX fájl nyilvános tulajdonságait csak olvasásra használhatja.

## **Beépített tulajdonságok elérése**

A [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) osztály getter metódusokon keresztül teszi elérhetővé a beépített metaadatokat, többek között a [getAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getAuthor), [getTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTitle), és a [getCreatedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCreatedTime). Ez a példa egy meglévő prezentációt nyit meg, és a tárolt metaadatait kiírja a konzolra. Az értékek a bemeneti prezentációtól függenek; egyes mezők üresek lehetnek.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    console.log("Category: " + documentProperties.getCategory());
    console.log("Content status: " + documentProperties.getContentStatus());
    console.log("Creation date: " + documentProperties.getCreatedTime());
    console.log("Author: " + documentProperties.getAuthor());
    console.log("Comments: " + documentProperties.getComments());
    console.log("Keywords: " + documentProperties.getKeywords());
    console.log("Last modified by: " + documentProperties.getLastSavedBy());
    console.log("Manager: " + documentProperties.getManager());
    console.log("Modified date: " + documentProperties.getLastSavedTime());
    console.log("Presentation format: " + documentProperties.getPresentationFormat());
    console.log("Last print date: " + documentProperties.getLastPrinted());
    console.log("Is shared between producers: " + documentProperties.getSharedDoc());
    console.log("Subject: " + documentProperties.getSubject());
    console.log("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

### **Revíziószám és szerkesztési idő jelentése**

A `presentations` mappában található minden PPTX fájl revíziószámának és teljes szerkesztési idejének jelentéséhez használja a [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties) metódust. Ez a fájl [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) objektumát adja vissza a diák szerkesztés nélküli betöltése nélkül. A példa a rögzített időtartamot milliszekundumból órára, percre és másodpercre konvertálja. 24 óra vagy több időtartam esetén a napok számával előtagolja az időt.

```javascript
const fs = require("fs");
const path = require("path");
const slides = require("aspose.slides.via.java");

const folder = "presentations";
const files = fs.readdirSync(folder, { withFileTypes: true });
const factory = slides.PresentationFactory.getInstance();

console.log("File | RevisionNumber | TotalEditingTime");
for (const file of files) {
    if (!file.isFile() || path.extname(file.name).toLowerCase() !== ".pptx") {
        continue;
    }
    const filePath = path.join(folder, file.name);
    const info = factory.getPresentationInfo(filePath);
    const properties = info.readDocumentProperties();
    const totalSeconds = Math.floor(properties.getTotalEditingTime() / 1000);
    const days = Math.floor(totalSeconds / 86400);
    const hours = Math.floor(totalSeconds / 3600) % 24;
    const minutes = Math.floor(totalSeconds / 60) % 60;
    const seconds = totalSeconds % 60;
    const time = [hours, minutes, seconds].map(value => String(value).padStart(2, "0")).join(":");
    const editingTime = days > 0 ? `${days}.${time}` : time;
    console.log(`${file.name} | ${properties.getRevisionNumber()} | ${editingTime}`);
}
```

Egy 1 nap, 2 óra és 5 perc szerkesztési idővel rögzített prezentáció esetén a jelentés a következő kimenetet mutatja.

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[getRevisionNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getRevisionNumber) értéket olvas, amelyet az alkalmazások a [setRevisionNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setRevisionNumber) segítségével módosíthatnak. A revíziószám önmagában nem állapítja meg, hogy a prezentáció hányszor lett mentve, vagy nem állítható helyre annak verziótörténete.

[getTotalEditingTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTotalEditingTime) a fájlban rögzített szerkesztési időt olvassa. A `00:00:00` érték azt jelenti, hogy a tárolt időtartam nulla, még akkor is, ha valaki szerkesztette a prezentációt.

## **Beépített tulajdonságok módosítása**

A beépített metaadatok frissítéséhez használja a setter metódusokat a [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) által visszaadott objektumon. Ez a példa egy meglévő prezentációt nyit meg, meghívja a [setAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setAuthor), [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setTitle), [setSubject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setSubject), [setComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setComments), és [setManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setManager), majd a frissített prezentációt a [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save) metódussal menti. A mentett PPTX tartalmazza az új metaadatokat.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ModifyBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Node.js via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A hiperhivatkozás alapjának kezelése**

A [DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getHyperlinkBase) visszaadja a dokumentumszintű alapot a relatív hiperhivatkozásokhoz. A [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setHyperlinkBase) használatával módosítható vagy törölhető. Hasznos, ha a prezentációt és a kapcsolódó fájlokat más helyre mozgatja. Ez elkülönül egy egyedi hiperhivatkozás [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) metódusától: az alap módosítása nem írja felül a tárolt hivatkozási címeket, és nem változtatja meg a abszolút célokat.

A példa olyan prezentációt igényel, amely tartalmaz egy relatív hivatkozást, például `target.html`, és egy abszolút hivatkozást, például `https://example.org/absolute.html`. Kiolvassa a meglévő alapot, új alapcímre állítja, majd elmenti és újra megnyitja a prezentációt az érték ellenőrzéséhez. Ezután egy üres karakterlánccal törli az alapot, és egy külön mentett fájlban ellenőrzi az üres értéket. A példabeli alapcímet cserélje le a saját kapcsolódó fájljai helyére.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("hyperlinks.pptx");
try {
    console.log("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    const newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", slides.SaveFormat.Pptx);

    const updatedPresentation = new slides.Presentation("hyperlinks-updated.pptx");
    try {
        console.log("Base preserved: " + (newBase === updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", slides.SaveFormat.Pptx);

        const clearedPresentation = new slides.Presentation("hyperlinks-cleared.pptx");
        try {
            console.log("Base cleared: " + ("" === clearedPresentation.getDocumentProperties().getHyperlinkBase()));
        } finally {
            clearedPresentation.dispose();
        }
    } finally {
        updatedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

A két ellenőrző üzenetnek `true` értéket kell kiírnia. Az alap törlése nem érinti az egyedi hiperhivatkozási címeket.

Egy relatív hivatkozás a `target.pptx` fájlra az `old/target.pptx`-t nyitotta meg, amikor az alap az `old` mappára mutatott. Az alap a `new` mappára történő módosítása, a mentés és a prezentáció újranyitása után ugyanez a hivatkozás a `new/target.pptx`-t nyitotta meg. Egy abszolút hivatkozás továbbra is ugyanazt a fájlt nyitotta. Tesztelje a relatív hivatkozásokat PowerPointban a prezentáció mozgatása vagy az alap módosítása előtt és után.

## **Egyéni prezentációs tulajdonságok hozzáadása**

Egyéni tulajdonságok olyan metaadatokat tárolnak, amelyeknek nincs megfelelő beépített mezőjük. A [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) metódus lehetővé teszi egy érték hozzárendelését a tulajdonság nevével. Ez a példa létrehoz egy prezentációt, két szöveges és egy egész verzióértéket ad hozzá, majd a [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save) segítségével elmenti a prezentációt. Létező névhez érték hozzárendelése felülírja a tulajdonság értékét.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Egyéni tulajdonságok elérése és módosítása**

Ez a példa egy egyéni tulajdonságokat tartalmazó prezentációt nyit meg, és a [getCountOfCustomProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCountOfCustomProperties) segítségével iterál rajtuk. A [getCustomPropertyName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCustomPropertyName) nullától indexelt számot fogad, és visszaadja a [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) által használt nevet. A példa kiírja minden eredeti nevet és értéket, minden értéket egy számozott szövegre cserél, függetlenül az eredeti típustól, majd elmenti a módosításokat. Ha nincsenek egyéni tulajdonságok, a ciklus nem végez változtatást.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessAndModifyProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    for (let i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        const propertyName = documentProperties.getCustomPropertyName(i);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log("Custom property name: " + propertyName);
        console.log("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Élő példa**

Próbálja ki a [**Nézze meg és szerkessze a PowerPoint metaadatokat**](https://products.aspose.app/slides/metadata) online alkalmazást, hogy lássa, hogyan dolgozhat a dokumentumtulajdonságokkal az Aspose.Slides API használatával:

[![Nézze meg és szerkessze a PowerPoint metaadatokat](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **GYIK**

**Hogyan távolíthatok el egy beépített tulajdonságot a prezentációból?**

A beépített tulajdonságok a prezentáció szerves részei, és nem távolíthatók el teljesen. Azonban megváltoztathatja az értéküket, vagy ha az adott tulajdonság megengedi, üresre állíthatja őket.

**Mi történik, ha olyan egyéni tulajdonságot adok hozzá, amely már létezik?**

Ha olyan egyéni tulajdonságot ad hozzá, amely már létezik, a meglévő érték felülíródik az újjal. Nem szükséges előzetesen eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti annak értékét.

**Elérhetem a prezentáció tulajdonságait anélkül, hogy teljesen betölteném a prezentációt?**

Igen. Használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationFactory#getPresentationInfo) majd a [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties) metódusokat a tárolt dokumentum metaadatok olvasásához, anélkül, hogy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) példányt hozna létre. Lásd a [Build a Lightweight Presentation Inventory](/slides/hu/nodejs-java/examine-presentation/) példát a teljes jelentéshez és a formátumspecifikus korlátozásokhoz.

**Olvashatok nyilvános tulajdonságokat egy titkosított prezentációból anélkül, hogy megadnám a nyitójelszót?**

Igen. A prezentációnak a [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) `false` értékkel történő hívása után kell titkosítva lennie, és [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) `true` értékkel történő hívás után kell betöltve lennie.

**Frissíthetek egy titkosított PPTX fájlt csak dokumentumtulajdonságok módban?**

Nem. A nyilvános és a titkosított tulajdonságadatoknak összhangban kell maradniuk, ezért egy titkosított PPTX fájl frissítéséhez a teljes prezentációt a megfelelő nyitójelszóval kell betölteni.