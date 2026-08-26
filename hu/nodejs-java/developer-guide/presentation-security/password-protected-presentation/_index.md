---
title: Jelszóval védett prezentációk JavaScriptben
linktitle: Jelszóvédelem
type: docs
weight: 20
url: /hu/nodejs-java/password-protected-presentation/
keywords:
- jelszóval védett prezentáció
- megnyitási jelszó
- PowerPoint titkosítása
- PowerPoint visszafejtése
- prezentáció jelszavának ellenőrzése
- prezentáció jelszó ellenőrzése
- titkosított prezentáció megnyitása
- titkosítás eltávolítása
- PowerPoint
- PPT
- PPTX
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Titkosítson, észleljen, ellenőrizzen, nyisson meg és fejtsen vissza jelszóval védett PowerPoint PPT és PPTX prezentációkat JavaScriptben az Aspose.Slides segítségével."
---
## **Áttekintés**

A megnyitási jelszó titkosítja a prezentációt. A megfelelő jelszó szükséges a prezentáció tartalmának betöltéséhez és megtekintéséhez, így ez a védelem bizalmasságot biztosít.

A megnyitási jelszó különbözik a írásvédelmi jelszótól. Az írásvédelem korlátozza a módosítást, de nem titkosítja a tartalmat, és nem akadályozza a prezentáció betöltését. A prezentációk módosításához használt jelszavak kezeléséhez lásd a [Write-Protect Presentations](/slides/hu/nodejs-java/write-protected-presentation/) oldalt.

Az alábbi munkafolyamatok mind a PPT, mind a PPTX prezentációkra vonatkoznak. A példák mindkét formátumot használják, ahol a fájl‑alapú és az adatfolyam‑alapú viselkedés fontos.

## **Prezentáció titkosítása megnyitási jelszóval**

Használja a [ProtectionManager.encrypt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/protectionmanager/#encrypt) metódust a megnyitási jelszó hozzárendeléséhez. Ezután használja a [Presentation.save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#save) metódust a titkosított prezentáció mentéséhez.

A következő példa egy PPTX prezentációt titkosít:

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

## **Titkosított prezentáció betöltése**

Állítsa be a [LoadOptions.setPassword](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#setPassword) értékét a megnyitási jelszóra, és adja át a beállításokat a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) objektumnak a fájl betöltésekor. A betöltés sikertelen, ha megnyitási jelszó szükséges, de a megadott jelszó hiányzik vagy helytelen.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Munka a visszafejtett prezentációval.
} finally {
    presentation.dispose();
}
```

## **Titkosítás eltávolítása egy prezentációból**

Töltse be a prezentációt a megnyitási jelszóval, hívja meg a [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/protectionmanager/#removeEncryption) metódust, és mentse az eredményt. A mentett prezentáció ezután jelszó nélkül betölthető.

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

## **Megnyitási jelszó ellenőrzése betöltés előtt**

Használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) metódust, hogy megszerezze a [PresentationInfo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationinfo/) objektumot egy komplett prezentáció példány létrehozása nélkül. Ellenőrizze a [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) állapotát, mielőtt jelszót kérne vagy ellenőrizne. Ha védelem van, a megadott értéket a [PresentationInfo.checkPassword](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationinfo/#checkPassword) metódussal ellenőrizze.

### **Fájl‑útvonal munkafolyamat**

Az alábbi példa egy PPTX fájl megnyitási jelszavát ellenőrzi, a validált értéket átadja a [LoadOptions.setPassword](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#setPassword) metódusnak, majd betölti a komplett prezentációt:

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

Használja a [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) metódust egy Node.js olvasható adatfolyam vizsgálatához. A vizsgálati adatfolyam felhasználása után hozzon létre egy új adatfolyamot a komplett prezentáció [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#createPresentationFromStream) metódussal történő betöltése előtt.

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

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationinfo/#checkPassword) csak akkor ad vissza `true` értéket, ha a prezentációnak megnyitási jelszója van, és a megadott jelszó helyes. A következő esetekben `false` értéket ad:

- A jelszó helytelen.
- A prezentációnak nincs megnyitási jelszava.
- A megadott jelszó `null` vagy üres.

A viselkedés ugyanaz a PPT és PPTX prezentációk esetén.

## **Ellenőrizze, hogy a betöltött prezentáció titkosított‑e**

A helyes jelszóval betöltött prezentáció után ellenőrizze a [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/protectionmanager/#isEncrypted) metódust, hogy megerősítse, a forrás prezentáció titkosított volt. A megnyitási jelszóval való védelem betöltés előtti észleléséhez használja a [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) metódust, ahogy fentebb bemutattuk.

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
Ne naplózza a megnyitási jelszavakat, és ne tartalmazza őket diagnosztikai üzenetekben. Kerülje a szükségtelen, ismételt ellenőrzési kísérleteket, a jelszavakat csak addig tartsa memóriában, amíg szükséges, és egy sikeres ellenőrzési eredményt újrahasználja a prezentáció azonnali betöltésekor.
{{% /alert %}}

## **Prezentáció jelszóval védelme online**

1. Nyissa meg az [Aspose.Slides Lock](https://products.aspose.app/slides/hu/lock) alkalmazást.
2. Válassza ki vagy töltse fel a prezentációt.
3. Adjon meg egy jelszót a megtekintési védelemhez.
4. Opcionálisan adjon meg egy külön jelszót a szerkesztési védelemhez.
5. Alkalmazza a védelmet, és töltse le a kapott fájlt.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/hu/nodejs-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/hu/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **GYIK**

**Mi a különbség a megnyitási jelszó és az írásvédelmi jelszó között?**

A megnyitási jelszó titkosítja a prezentációt, és szükséges a tartalom betöltéséhez. Az írásvédelmi jelszó a módosítást korlátozza anélkül, hogy a tartalmat titkosítaná.

**Ellenőrizhetem a megnyitási jelszót anélkül, hogy az összes diát betölteném?**

Igen. Szerezze meg a prezentáció információkat, ellenőrizze, hogy van‑e megnyitási jelszóval védelem, és ellenőrizze a jelszót, mielőtt komplett prezentáció példányt hozna létre.

**A jelszó‑ellenőrző munkafolyamatok támogatják a PPT és PPTX formátumokat is?**

Igen. A fájlútvonal és az adatfolyam‑alapú jelszó‑észlelés és ellenőrzés ugyanúgy működik a PPT és PPTX prezentációknál.