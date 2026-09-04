---
title: Jelszóval védett bemutatók JavaScriptben
linktitle: Jelszóvédelem
type: docs
weight: 20
url: /hu/nodejs-java/password-protected-presentation/
keywords:
- jelszóval védett bemutató
- nyitó jelszó
- PowerPoint titkosítása
- PowerPoint visszafejtése
- bemutató jelszó ellenőrzése
- bemutató jelszó ellenőrzése
- titkosított bemutató megnyitása
- titkosítás eltávolítása
- PowerPoint
- PPT
- PPTX
- bemutató
- Node.js
- JavaScript
- Aspose.Slides
description: "Titkosítsa, észlelje, ellenőrizze, nyissa meg és fejlessze vissza a jelszóval védett PowerPoint PPT és PPTX bemutatókat JavaScriptben az Aspose.Slides segítségével."
---
## **Áttekintés**

A nyitó jelszó titkosítja a bemutatót. A helyes jelszó szükséges a bemutató tartalmának betöltéséhez és megtekintéséhez, így ez a védelem bizalmasságot biztosít.

A nyitó jelszó különbözik az írásvédelmi jelszótól. Az írásvédelem korlátozza a módosítást, de nem titkosítja a tartalmat, és nem akadályozza meg a bemutató betöltését. A bemutatók módosításához szükséges jelszavak kezeléséhez tekintse meg a [Írásvédett bemutatók](/slides/hu/nodejs-java/write-protected-presentation/) oldalt.

Az alábbi munkafolyamatok mind a PPT, mind a PPTX bemutatókra vonatkoznak. A példák mindkét formátumot használják, ahol a fájl‑alapú és adatfolyam‑alapú viselkedés fontos.

## **Bemutató titkosítása nyitó jelszóval**

Használja a [ProtectionManager.encrypt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/protectionmanager/#encrypt) metódust a nyitó jelszó megadásához. Ezután a [Presentation.save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#save) segítségével mentse el a titkosított bemutatót.

A következő példa egy PPTX bemutatót titkosít:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A dokumentumtulajdonságok nyilvánosak tartása**

Alapértelmezés szerint az Aspose.Slides a dokumentumtulajdonságokat is belefoglalja a bemutató titkosításába. A [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) metódus ezt a viselkedést a diatartalom titkosításától függetlenül szabályozza. Hívja meg a [ProtectionManager.encrypt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/protectionmanager/#encrypt) metódust `false` értékkel, ha egy indexelő, osztályozó, kereső vagy dokumentumkezelő rendszernek a metaadatokat a nyitó jelszó nélkül kell olvasnia.

A következő példa egy titkosított PPTX bemutatót hoz létre, miközben beépített dokumentumtulajdonságait nyilvánosan hagyja:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`false` átadása a [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) metódusnak nem teszi a diákat, mestereket, elrendezéseket, alakzatokat, médiát vagy a bemutató egyéb tartalmát nyilvánossá. Csak a dokumentumtulajdonságokra van hatással. A titkosított tartalom betöltése nélkül ezeknek a tulajdonságoknak az olvasásához tekintse meg a [Bemutató tulajdonságok kezelése](/slides/hu/nodejs-java/presentation-properties/) oldalt.

## **Titkosított bemutató betöltése**

Állítsa be a [LoadOptions.setPassword](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#setPassword) opciót a nyitó jelszóra, és adja át ezt a beállítást a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) betöltésekor. A betöltés sikertelen, ha nyitó jelszó szükséges, de a megadott jelszó hiányzik vagy helytelen.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Dolgozz a visszafejtett bemutatóval.
} finally {
    presentation.dispose();
}
```

## **Titkosítás eltávolítása a bemutatóból**

Töltse be a bemutatót a nyitó jelszóval, hívja meg a [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/protectionmanager/#removeEncryption) metódust, majd mentse el az eredményt. A mentett bemutató ezután jelszó nélkül betölthető.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nyitó jelszó ellenőrzése betöltés előtt**

Használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) metódust a [PresentationInfo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationinfo/) beszerzéséhez anélkül, hogy teljes bemutató példányt hozna létre. A jelszó kérése vagy ellenőrzése előtt ellenőrizze a [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) állapotát. Ha védelem van, ellenőrizze a megadott értéket a [PresentationInfo.checkPassword](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationinfo/#checkPassword) metódussal.

### **Fájlútvonal munkafolyamat**

Az alábbi példa egy PPTX fájl nyitó jelszavát ellenőrzi, a validált értéket átadja a [LoadOptions.setPassword](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#setPassword) metódusnak, majd betölti a teljes bemutatót:

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "protected-presentation.pptx";
const password = "open_password";
const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    console.log("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    console.log("The opening password is incorrect.");
} else {
    const loadOptions = new slides.LoadOptions();
    loadOptions.setPassword(password);

    const presentation = new slides.Presentation(filePath, loadOptions);
    try {
        console.log("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **Adatfolyam munkafolyamat**

Használja a [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) metódust egy Node.js olvasható adatfolyam vizsgálatához. Miután a vizsgálati adatfolyam felhasználásra került, hozzon létre egy új adatfolyamot, mielőtt a teljes bemutatót a [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#createPresentationFromStream) metódussal betöltené.

A következő példa egy PPT fájlt használ:

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");

const filePath = "protected-presentation.ppt";
const password = "open_password";
const presentationFactory = slides.PresentationFactory.getInstance();
const infoStream = fs.createReadStream(filePath);

slides.PresentationFactory.getPresentationInfoFromStream(presentationFactory, infoStream, function(infoError, presentationInfo) {
    if (infoError) {
        console.log("The presentation information could not be read: " + infoError.message);
    } else if (!presentationInfo.isPasswordProtected()) {
        console.log("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        console.log("The opening password is incorrect.");
    } else {
        const loadOptions = new slides.LoadOptions();
        loadOptions.setPassword(password);
        const presentationStream = fs.createReadStream(filePath);

        slides.Presentation.createPresentationFromStream(presentationStream, loadOptions, function(loadError, presentation) {
            if (loadError) {
                console.log("The presentation could not be loaded: " + loadError.message);
            } else {
                try {
                    console.log("The presentation was validated and loaded successfully.");
                } finally {
                    presentation.dispose();
                }
            }
        });
    }
});
```

### **checkPassword visszatérési értékek**

Az [PresentationInfo.checkPassword](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationinfo/#checkPassword) csak akkor ad vissza `true` értéket, ha a bemutató rendelkezik nyitó jelszóval és a megadott jelszó helyes. `false` értéket ad vissza a következő esetekben:

- A jelszó helytelen.
- A bemutató nem rendelkezik nyitó jelszóval.
- A megadott jelszó `null` vagy üres.

A viselkedés ugyanaz PPT és PPTX bemutatók esetén.

## **Ellenőrizze, hogy a betöltött bemutató titkosított-e**

A bemutató helyes jelszóval történő betöltése után ellenőrizze a [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/protectionmanager/#isEncrypted) állapotát, hogy megerősítse, a forrásbemutató titkosítva volt-e. A nyitó jelszó védelmének betöltés előtti felismeréséhez használja a [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) metódust, ahogy fentebb látható.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const isEncrypted = presentation.getProtectionManager().isEncrypted();
    console.log("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **Biztonsági ajánlások**

{{% alert color="warning" title="Security" %}}
Ne naplózza a nyitó jelszavakat, és ne helyezze őket diagnosztikai üzenetekbe. Kerülje a szükségtelen ismételt ellenőrzési kísérleteket, tartsa a jelszavakat memóriában csak annyira, amennyi szükséges, és használja újra a sikeres ellenőrzés eredményét, ha azonnal betölti a bemutatót.

A nyilvános dokumentumtulajdonságok felfedhetik a szerző neveit, címeket, tárgyakat, kulcsszavakat, vállalati információkat, megjegyzéseket és egyéni értékeket, még akkor is, ha a bemutató tartalma titkosított. Titkosítsa a érzékeny metaadatokat együtt a bemutatóval. A tulajdonságok nyilvánosra hagyása csak akkor legyen szándékos döntés, amikor a rendszereknek a fájlt nyitó jelszó nélkül kell indexelniük, osztályozniuk, keresniük vagy kezelniük.
{{% /alert %}}

## **Bemutató jelszóvédelme online**

1. Nyissa meg az [Aspose.Slides Lock](https://products.aspose.app/slides/hu/lock) alkalmazást.
2. Válassza ki vagy töltse fel a bemutatót.
3. Adjon meg egy jelszót a megtekintés védelméhez.
4. Opcionálisan adjon meg egy külön jelszót a szerkesztés védelméhez.
5. Alkalmazza a védelmet, majd töltse le a kapott fájlt.

{{% alert color="info" title="See also" %}}
- [Írásvédett bemutatók](/slides/hu/nodejs-java/write-protected-presentation/)
- [Digitális aláírás PowerPointban](/slides/hu/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **GYIK**

**Mi a különbség a nyitó jelszó és az írásvédelmi jelszó között?**

A nyitó jelszó titkosítja a bemutatót, és szükséges a tartalom betöltéséhez. Az írásvédelmi jelszó a módosítást korlátozza anélkül, hogy titkosítaná a tartalmat.

**Ellenőrizhetem a nyitó jelszót anélkül, hogy az összes diát betölteném?**

Igen. Szerezze meg a bemutató információkat, ellenőrizze, hogy a nyitó jelszó védelem jelen van-e, és validálja a jelszót még a teljes bemutató példány létrehozása előtt.

**Olvashat egy alkalmazás metaadatokat a nyitó jelszó nélkül?**

Igen, de csak akkor, ha a bemutató a dokumentumtulajdonságok titkosítása letiltásával lett titkosítva. Az alkalmazásnak ekkor a [Bemutató tulajdonságok kezelése](/slides/hu/nodejs-java/presentation-properties/) leírt dokumentumtulajdonság‑csak betöltési módot kell használnia.

**Támogatja a jelszó‑ellenőrző munkafolyamatok a PPT és PPTX formátumokat egyaránt?**

Igen. A fájlútvonal és adatfolyam alapú jelszó‑detektálás és ellenőrzés ugyanúgy működik PPT és PPTX bemutatók esetén.