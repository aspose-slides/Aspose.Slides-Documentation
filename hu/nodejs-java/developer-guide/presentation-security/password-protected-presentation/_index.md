---
title: Jelszóval védett prezentációk biztonságos kezelése JavaScriptben
linktitle: Jelszóvédelem
type: docs
weight: 20
url: /hu/nodejs-java/password-protected-presentation/
keywords:
- PowerPoint zárolása
- prezentáció zárolása
- PowerPoint feloldása
- prezentáció feloldása
- PowerPoint védelme
- prezentáció védelme
- jelszó beállítása
- jelszó hozzáadása
- PowerPoint titkosítása
- prezentáció titkosítása
- PowerPoint feloldása
- prezentáció feloldása
- írásvédelem
- PowerPoint biztonság
- prezentáció biztonsága
- jelszó eltávolítása
- védelem eltávolítása
- titkosítás eltávolítása
- jelszó letiltása
- védelem letiltása
- írásvédelem eltávolítása
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Könnyedén zárolhatja és feloldhatja a jelszóval védett PowerPoint és OpenDocument prezentációkat az Aspose.Slides for Node.js segítségével Java segítségével. Biztonságba helyezheti prezentációit."
---
## **Bevezetés**

Amikor jelszóval védi a prezentációt, egy jelszót állít be, amely bizonyos korlátozásokat alkalmaz a prezentáción. A korlátozások eltávolításához a jelszót meg kell adni. A jelszóval védett prezentációt zárolt prezentációnak tekintik.

Általában beállíthat egy jelszót, hogy ezeket a korlátozásokat a prezentáción alkalmazza:

- **Módosítás**

  Ha csak bizonyos felhasználók számára szeretné engedélyezni a prezentáció módosítását, beállíthat egy módosítási korlátozást. Ez a korlátozás megakadályozza, hogy a felhasználók módosítsák, változtassák vagy másolják a prezentáció tartalmát (kivéve, ha megadják a jelszót).

  Azonban ebben az esetben a jelszó nélkül is a felhasználó hozzáférhet a dokumentumhoz és megnyithatja azt. Olvasásvédett módban a felhasználó megtekintheti a tartalmakat vagy elemeket – hiperlinkeket, animációkat, effektusokat és másokat – a prezentációban, de nem másolhat elemeket, illetve nem mentheti a prezentációt.

- **Megnyitás**

  Ha csak bizonyos felhasználók számára szeretné engedélyezni a prezentáció megnyitását, beállíthat egy megnyitási korlátozást. Ez a korlátozás megakadályozza, hogy a felhasználók még csak a prezentáció tartalmát is megtekinthessék (kivéve, ha megadják a jelszót).

  Technikailag a megnyitási korlátozás megakadályozza a felhasználókat a prezentációk módosításában is: Ha a felhasználó nem tudja megnyitni a prezentációt, nem tud módosításokat végrehajtani benne. 

  **Megjegyzés** hogy ha a prezentációt jelszóval védve a megnyitás megakadályozására használja, a prezentáció fájl titkosítva lesz.

## **Hogyan védjünk jelszóvel egy prezentációt online**

1. Nyissa meg a [**Aspose.Slides Lock**](https://products.aspose.app/slides/hu/lock) oldalunkat. 

   ![todo:image_alt_text](slides-lock.png)

2. Kattintson a **Fájlok elhelyezése vagy feltöltése**.

3. Válassza ki a fájlt, amelyet jelszóval szeretne védeni a számítógépén. 

4. Adja meg a kívánt jelszót a szerkesztési védelemhez; adja meg a kívánt jelszót a megtekintési védelemhez. 

5. Ha azt szeretné, hogy a felhasználók a prezentációt végleges példányként lássák, jelölje be a **Mark as final** jelölőnégyzetet.

6. Kattintson a **PROTECT NOW.** gombra. 

7. Kattintson a **DOWNLOAD NOW.** gombra.

## **Jelszóvédelem a prezentációkhoz az Aspose.Slides-ban**
**Támogatott formátumok**

Az Aspose.Slides támogatja a jelszóvédelmet, titkosítást és hasonló műveleteket a következő formátumú prezentációk esetén: 

- PPTX és PPT – Microsoft PowerPoint prezentáció 
- ODP – OpenDocument prezentáció 
- OTP – OpenDocument prezentációs sablon 

**Támogatott műveletek**

Az Aspose.Slides lehetővé teszi a jelszóvédelem alkalmazását a prezentációkon, hogy a következő módokon megakadályozza a módosításokat:

- Egy prezentáció titkosítása
- Írásvédettség beállítása egy prezentáción

**Egyéb műveletek**

Az Aspose.Slides lehetővé teszi egyéb jelszóvédelmi és titkosítási feladatok elvégzését a következő módon:

- Egy prezentáció feloldása; titkosított prezentáció megnyitása
- Titkosítás eltávolítása; jelszóvédelem letiltása
- Írásvédelem eltávolítása egy prezentációról
- Titkosított prezentáció tulajdonságainak lekérése
- Annak ellenőrzése, hogy a prezentáció titkosított-e
- Annak ellenőrzése, hogy a prezentáció jelszóval védett-e.

## **Egy prezentáció titkosítása**

Egy prezentációt titkosíthat egy jelszó beállításával. Ezután a zárolt prezentáció módosításához a felhasználónak meg kell adnia a jelszót. 

A prezentáció titkosításához vagy jelszóvédelemhez használja az encrypt metódust (a [ProtectionManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ProtectionManager)) osztályból, amely jelszót állít be a prezentációhoz. A jelszót az encrypt metódusnak adja át, majd a save metódussal mentse a most titkosított prezentációt.

Ez a mintakód bemutatja, hogyan titkosítható egy prezentáció:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Írásvédelem beállítása egy prezentációhoz**

A prezentációhoz hozzáadhat egy „Ne módosítsa” megjelölést. Ezzel jelezheti a felhasználóknak, hogy nem kívánja, hogy módosítsák a prezentációt.  

**Megjegyzés** hogy az írásvédelmi folyamat nem titkosítja a prezentációt. Ezért a felhasználók – ha akarják – módosíthatják a prezentációt, de a változtatások mentéséhez másik névvel kell menteniük a prezentációt. 

Az írásvédelem beállításához használja a [setWriteProtection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ProtectionManager#setWriteProtection-java.lang.String-) metódust. Ez a mintakód bemutatja, hogyan állítható be az írásvédelem egy prezentációhoz:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Prezentáció feloldása; titkosított prezentáció megnyitása**

Az Aspose.Slides lehetővé teszi egy titkosított fájl betöltését a jelszó átadásával. Egy prezentáció feloldásához hívja meg a [removeEncryption](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) metódust paraméterek nélkül. Ezután meg kell adnia a helyes jelszót a prezentáció betöltéséhez.

Ez a mintakód bemutatja, hogyan lehet feloldani egy prezentációt:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    // dolgozzunk a feloldott prezentációval
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Titkosítás eltávolítása; jelszóvédelem letiltása**

Eltávolíthatja a prezentáció titkosítását vagy jelszóvédelmét. Így a felhasználók korlátozások nélkül hozzáférhetnek vagy módosíthatják a prezentációt.

A titkosítás vagy jelszóvédelem eltávolításához hívja meg a [removeEncryption](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) metódust. Ez a mintakód bemutatja, hogyan távolítható el a titkosítás egy prezentációból:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Írásvédelem eltávolítása egy prezentációból**

Az Aspose.Slides segítségével eltávolíthatja a prezentációfájlra alkalmazott írásvédelmet. Így a felhasználók szabadon módosíthatják, és nem kapnak figyelmeztetést az ilyen műveletek során.

Az írásvédelmet a [removeWriteProtection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ProtectionManager#removeWriteProtection--) metódus használatával távolíthatja el a prezentációról. Ez a mintakód bemutatja, hogyan távolítható el az írásvédelem egy prezentációról:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Titkosított prezentáció tulajdonságainak lekérése**

Általában a felhasználók nehezen tudják lekérni egy titkosított vagy jelszóval védett prezentáció dokumentumtulajdonságait. Azonban az Aspose.Slides egy olyan mechanizmust kínál, amely lehetővé teszi a prezentáció jelszóvédelmét miközben a felhasználók továbbra is hozzáférhetnek a tulajdonságaihoz.

**Megjegyzés:** Alapértelmezés szerint, amikor az Aspose.Slides titkosít egy prezentációt, a prezentáció dokumentumtulajdonságai is jelszóval védettek. Ha szükséges, hogy a dokumentumtulajdonságok a titkosítás után is hozzáférhetőek legyenek, az Aspose.Slides ezt lehetővé teszi.

Ha azt szeretné, hogy a felhasználók továbbra is hozzáférhessenek egy titkosított prezentáció tulajdonságaihoz, adja át a `false` értéket a `setEncryptDocumentProperties` metódusnak a [ProtectionManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/protectionmanager/) segítségével. Ez a mintakód bemutatja, hogyan titkosítható egy prezentáció, miközben a felhasználók hozzáférhetnek a dokumentumtulajdonságaihoz:

```javascript
const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Csak a dokumentumtulajdonságok betöltése egy titkosított prezentációból**

Az egy titkosított prezentáció metaadatainak a diák vagy egyéb tartalom betöltése nélkül történő megtekintéséhez hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/) objektumot, és adja át a `true` értéket a `setOnlyLoadDocumentProperties` metódusnak. Ebben a módban az Aspose.Slides figyelmen kívül hagyja a jelszót, és csak a nyilvánosan elérhető dokumentumtulajdonságokat tölti be.

A következő kódrészlet a beépített és egyedi dokumentumtulajdonságokat olvassa a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) `getDocumentProperties` metódusán keresztül:

```javascript
const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new aspose.slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();

    // Beépített dokumentumtulajdonságok olvasása.
    console.log("Title: " + documentProperties.getTitle());
    console.log("Author: " + documentProperties.getAuthor());

    // Egyedi dokumentumtulajdonságok olvasása.
    const customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (let propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        const propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

Ez a munkafolyamat csak akkor működik, ha a dokumentumtulajdonságok titkosítás nélkül (nyilvános) maradtak a prezentáció titkosításakor. Ha a dokumentumtulajdonságok titkosítva vannak, a `true` érték átadása a `LoadOptions.setOnlyLoadDocumentProperties` metódusnak kivételt eredményez, mivel ebben a módban a jelszó figyelmen kívül marad. A titkosított dokumentumtulajdonságok eléréséhez vagy a teljes prezentáció, beleértve a diákat és egyéb tartalmakat, betöltéséhez adja meg a helyes jelszót a [LoadOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/) `LoadOptions.setPassword` metódusával.

## **Ellenőrzés, hogy a prezentáció jelszóval védett-e betöltés előtt**

Mielőtt betöltene egy prezentációt, érdemes ellenőrizni és megerősíteni, hogy a prezentáció nincs jelszóval védve. Így elkerülhetők a hibák és hasonló problémák, amelyek akkor merülnek fel, amikor egy jelszóval védett prezentációt a jelszó nélkül próbálják betölteni.

Ez a JavaScript kód bemutatja, hogyan vizsgálhat meg egy prezentációt annak megállapítására, hogy jelszóval van-e védve (a prezentáció tényleges betöltése nélkül):

```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Ellenőrzés, hogy a prezentáció titkosított-e**

Az Aspose.Slides lehetővé teszi, hogy ellenőrizze, egy prezentáció titkosított-e. Ehhez használhatja a [isEncrypted](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ProtectionManager#isEncrypted--) tulajdonságot, amely `true` értéket ad vissza, ha a prezentáció titkosított, vagy `false` értéket, ha nincs titkosítva.

Ez a mintakód bemutatja, hogyan ellenőrizhető, hogy egy prezentáció titkosított-e:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Ellenőrzés, hogy a prezentáció írásvédett-e**

Az Aspose.Slides lehetővé teszi, hogy ellenőrizze, egy prezentáció írásvédett-e. Ehhez használhatja a [isWriteProtected](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ProtectionManager#isWriteProtected--) tulajdonságot, amely `true` értéket ad vissza, ha a prezentáció írásvédett, vagy `false` értéket, ha nincs írásvédett.

Ez a mintakód bemutatja, hogyan ellenőrizhető, hogy egy prezentáció írásvédett-e:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Egy adott jelszó használatának ellenőrzése vagy megerősítése a prezentáció védelméhez**

Előfordulhat, hogy ellenőrizni és megerősíteni szeretné, hogy egy adott jelszót használtak-e a prezentáció dokumentum védelméhez. Az Aspose.Slides lehetőséget biztosít a jelszó érvényesítésére. 

Ez a mintakód bemutatja, hogyan lehet érvényesíteni egy jelszót:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    // ellenőrizze, hogy a "pass" egyezik-e
    var isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Az `true` értéket adja vissza, ha a prezentációt a megadott jelszóval titkosították. Ellenkező esetben `false` értéket ad.

{{% alert color="primary" title="Lásd még" %}} 
- [Digitális aláírás PowerPointban](/slides/hu/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **GYIK**

**Milyen titkosítási módszereket támogat az Aspose.Slides?**

Az Aspose.Slides modern titkosítási módszereket támogat, beleértve az AES-alapú algoritmusokat, amelyek magas szintű adatbiztonságot biztosítanak a prezentációk számára.

**Mi történik, ha hibás jelszót adunk meg egy prezentáció megnyitásakor?**

Kivétel keletkezik, ha hibás jelszót használnak, ami tájékoztatja, hogy a prezentációhoz való hozzáférés megtagadva. Ez segít megelőzni a jogosulatlan hozzáférést és védi a prezentáció tartalmát.

**Vannak-e teljesítménybeli hatásai a jelszóval védett prezentációk használatának?**

A titkosítási és feloldási folyamat apró késleltetést okozhat a megnyitás és mentés során. A legtöbb esetben ez a teljesítménybeli hatás minimális, és nem befolyásolja jelentősen a prezentáció feladatai feldolgozásának összidejét.