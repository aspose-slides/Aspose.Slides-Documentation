---
title: Prezentáció tulajdonságainak kezelése JavaScriptben
linktitle: Prezentáció tulajdonságok
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
description: "Mesteri szinten kezelje a prezentáció tulajdonságokat az Aspose.Slides for Node.js via Java segítségével, és egyszerűsítse a keresést, a márkázást és a munkafolyamatot PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides for Node.js via Java támogatja a **beépített** és **egyéni** dokumentumtulajdonságokat. Ezeket a tulajdonságokat használhatja a prezentáció metaadatainak olvasására és frissítésére, például a szerző, a cím és a felhasználó által meghatározott értékek esetén.

Az Aspose.Slides lehetővé teszi a prezentáció dokumentumtulajdonságokkal való munkát a [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) osztályon keresztül. Ennek az osztálynak egy példánya a [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) által kerül visszaadásra. Az alábbi példák bemutatják, hogyan olvashatók, módosíthatók és kezelhetők ezek a tulajdonságok.

{{% alert color="info" title="Note" %}}
Az Aspose.Slides kezeli az alkalmazás- és producer-metaadatokat a prezentációk mentésekor; ezek a mezők azonosítják a kimenetet létrehozó szoftvert.
{{% /alert %}}

## **Prezentációtulajdonságok kezelése**

A dokumentumtulajdonságok leíró információkat tárolnak a prezentáció tartalmával együtt. Két kategóriába sorolhatók:

- **Beépített tulajdonságok** szabványos metaadatokat tartalmaznak, például a címet, a szerzőt és a dokumentum statisztikákat.
- **Egyéni tulajdonságok** felhasználó által meghatározott név/érték párokat tárolnak.

Az Aspose.Slides for Node.js via Java hozzáférést biztosít mindkét kategóriához. A PowerPointban válassza a **File → Info → Properties → Advanced Properties** menüpontot a dokumentum metaadatainak megtekintéséhez. A párbeszédablak információkat csoportosít fülekre, mint például **Summary**, **Statistics**, **Contents**, és **Custom**. Használja a **Custom** fület a felhasználó által definiált tulajdonságok kezeléséhez.

## **Nyilvános tulajdonságok olvasása titkosított prezentációból**

A megnyitási jelszó általában védi a prezentáció tartalmát és a dokumentumtulajdonságokat is. Ha egy prezentáció titkosítva van a [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) `false` paraméterrel történő meghívása után, a dokumentumtulajdonságok nyilvánosak maradnak. Egy alkalmazás ezután a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) `true` paraméterrel hívásával a nyilvános metaadatokat olvashatja anélkül, hogy megadná a megnyitási jelszót.

A [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) határozza meg, hogy az Aspose.Slides mit tölt be; semmit sem titkosít vissza. Ha a tulajdonságok a titkosítás részei voltak, a jelszó nélkül történő betöltés sikertelen. Ha a prezentáció nincs titkosítva, az opció figyelmen kívül marad, és a teljes prezentáció betöltődik.

A példa egy titkosított prezentációt igényel, amelynek dokumentumtulajdonságai nyilvánosak maradtak. A betöltési módot a [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) segítségével ellenőrzi, majd a beépített tulajdonságokat a [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) segítségével olvassa:

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

Ebben a módban a diák tartalma nem töltődik be. A diák, mesterdiák, elrendezések, alakzatok, média és egyéb prezentációobjektumok nem érhetők el. Az alkalmazásoknak mindig ellenőrizniük kell a [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) értékét, mielőtt olyan műveletet végeznének, amely a teljes prezentáció objektummodelljét igényli.

{{% alert color="warning" title="Warning" %}}
A nyilvános metaadatok felfedhetik a szerzők neveit, címeket, témákat, kulcsszavakat, vállalati információkat, megjegyzéseket és egyéni értékeket. Titkosítsa a érzékeny tulajdonságokat a prezentációval együtt. Csak akkor hagyja nyilvánosan, ha indexelési, osztályozási, keresési vagy dokumentumkezelő rendszereknek van konkrét igénye a jelszó nélküli hozzáférésre.
{{% /alert %}}

## **Titkosított prezentáció tulajdonságainak frissítése**

Titkosított PPTX fájl esetén a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) `true` paraméterrel betöltött prezentáció a nyilvános metaadatok olvasására szolgál. Az Aspose.Slides nem tudja elmenteni a megváltozott tulajdonságokat ebből a csak metaadatokat tartalmazó objektumból, mivel a nyilvános tulajdonságoknak konzisztensnek kell maradniuk a titkosított prezentációban lévő megfelelő adatokkal. Ennek frissítéséhez ezért a helyes megnyitási jelszó és a teljes betöltés szükséges.

A példa egy nyilvános dokumentumtulajdonságokkal rendelkező titkosított PPTX prezentációt és egy ismert megnyitási jelszót igényel. A teljes prezentációt a [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setPassword) segítségével nyitja meg, frissíti a nyilvános beépített tulajdonságokat, és elmenti az eredményt. Ezután a [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#isEncrypted) segítségével ellenőrzi, hogy a titkosítás megmaradt-e, és a jelszó nélkül újra megnyitja a nyilvános metaadatokat az új értékek ellenőrzéséhez:

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

Ha egy alkalmazásnak nincs engedélye a prezentáció tartalmának visszafejtésére vagy betöltésére, a titkosított PPTX fájl nyilvános tulajdonságait csak olvashatóként kell kezelnie.

## **Beépített tulajdonságokhoz való hozzáférés**

A [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) osztály getter metódusok révén teszi elérhetővé a beépített metaadatokat, többek között a [getAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getAuthor), [getTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTitle) és [getCreatedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCreatedTime) metódusokkal. Ez a példa megnyit egy meglévő prezentációt, és a tárolt metaadatokat a konzolra írja. Az értékek a bemeneti prezentációtól függenek; egyes mezők üresek lehetnek.

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

## **Beépített tulajdonságok módosítása**

A beépített metaadatok frissítéséhez használja a setter metódusokat a [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) által visszaadott objektumon. Ez a példa megnyit egy meglévő prezentációt, meghívja a [setAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setAuthor), [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setTitle), [setSubject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setSubject), [setComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setComments) és [setManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setManager) metódusokat, majd a [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save) segítségével elmenti a frissített prezentációt. A mentett PPTX tartalmazza az új metaadatokat.

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

A [DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getHyperlinkBase) visszaadja a dokumentumszintű alapot a relatív hiperhivatkozásokhoz. A [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setHyperlinkBase) segítségével módosíthatja vagy törölheti azt. Ez akkor hasznos, amikor egy prezentációt és a hozzá kapcsolódó fájlokat egy másik helyre helyezi át. Ez különálló az egyes hiperhivatkozások [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) metódusától: az alap módosítása nem írja felül a tárolt hivatkozási címeket, és nem változtatja meg az abszolút célpontokat.

A példa egy olyan prezentációt igényel, amely tartalmaz egy relatív hivatkozást, például a `target.html`-t, és egy abszolút hivatkozást, például a `https://example.org/absolute.html`-t. Kiolvassa a meglévő alapot, új alapcímre állítja, majd menti és újra megnyitja a prezentációt az érték ellenőrzéséhez. Ezután egy üres karakterlánccal törli az alapot, és egy külön mentett fájlban ellenőrzi az üres értéket. Cserélje le a példában szereplő alapcímet a saját kapcsolt fájljainak helyére.

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

A két ellenőrző üzenetnek `true`-t kell kiírnia. Az alap törlése nem érinti az egyes hiperhivatkozások címét.

Egy relatív hivatkozás a `target.pptx`-re az `old/target.pptx` fájlt nyitotta meg, amikor az alap az `old` mappára mutatott. Az alap `new` mappára történő módosítása, a mentés és a prezentáció újra megnyitása után ugyanaz a hivatkozás a `new/target.pptx`-t nyitotta meg. Egy abszolút hivatkozás továbbra is ugyanazt a fájlt nyitotta. Tesztelje a relatív hivatkozásait a PowerPointban a prezentáció áthelyezése vagy az alap megváltoztatása előtt és után.

## **Egyéni prezentációtulajdonságok hozzáadása**

Az egyéni tulajdonságok olyan metaadatokat tárolnak, amelyeknek nincs megfelelő beépített mezője. A [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) metódus lehetővé teszi érték hozzárendelését a tulajdonság nevével. Ez a példa létrehoz egy prezentációt, két szöveges értéket és egy egész számú verzióértéket ad hozzá, majd a [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save) segítségével elmenti a prezentációt. Egy meglévő névhez való érték hozzárendelése felülírja az adott tulajdonság értékét.

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

Ez a példa megnyit egy olyan prezentációt, amely egyéni tulajdonságokat tartalmaz, és a [getCountOfCustomProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCountOfCustomProperties) segítségével iterálja őket. A [getCustomPropertyName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCustomPropertyName) nulláralapú indexet fogad, és visszaadja a [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) által használt nevet. A példa kiírja az egyes eredeti neveket és értékeket, minden értéket egy számozott karakterláncra cserél az eredeti típusától függetlenül, majd elmenti a módosításokat. Ha nincsenek egyéni tulajdonságok, a ciklus nem hajt végre változtatást.

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

Próbálja ki a [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) online alkalmazást, hogy lássa, hogyan lehet a dokumentumtulajdonságokkal dolgozni az Aspose.Slides API-val:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **GYIK**

**Hogyan távolíthatok el egy beépített tulajdonságot egy prezentációból?**

A beépített tulajdonságok szerves részei a prezentációnak, és nem távolíthatók el teljesen. Azonban megváltoztathatja azok értékét, vagy a konkrét tulajdonság megengedi, akkor üresre állíthatja őket.

**Mi történik, ha olyan egyéni tulajdonságot adok hozzá, amely már létezik?**

Ha olyan egyéni tulajdonságot ad hozzá, amely már létezik, akkor a meglévő érték felül lesz írva az újval. Nem kell előre eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti a tulajdonság értékét.

**Hozzáférhetek a prezentáció tulajdonságaihoz anélkül, hogy teljesen betölteném a prezentációt?**

Igen. Használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationFactory#getPresentationInfo) metódust, majd a [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties) metódust a tárolt dokumentum metaadatok olvasásához anélkül, hogy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) példányt hozna létre. Lásd a [Build a Lightweight Presentation Inventory](/slides/hu/nodejs-java/examine-presentation/) cikket a teljes jelentési példáért és a formátumspecifikus korlátozásokért.

**Olvashatok nyilvános tulajdonságokat egy titkosított prezentációból anélkül, hogy megadnám a megnyitási jelszavát?**

Igen. A prezentációt a [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) `false` paraméterrel történő meghívása után kell titkosítani, és a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) `true` paraméterrel történő betöltés után.

**Frissíthetek egy titkosított PPTX fájlt csak dokumentumtulajdonságok módjában?**

Nem. A nyilvános és a titkosított tulajdonságok adatai konzisztensnek kell maradniuk, ezért egy titkosított PPTX fájl frissítéséhez a teljes prezentációt a megfelelő megnyitási jelszóval kell betölteni.