---
title: Jelszóval védett prezentációk biztonságban JavaScript-ben
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
- PowerPoint visszafejtése
- prezentáció visszafejtése
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
description: "Könnyedén zárolhat és feloldhat jelszóval védett PowerPoint és OpenDocument prezentációkat az Aspose.Slides for Node.js segítségével Java használatával. Biztonságossá teheti prezentációit."
---
## **Bevezetés**

Amikor jelszóval véd egy bemutatót, azt jelenti, hogy egy jelszót állít be, amely bizonyos korlátozásokat kényszerít ki a bemutatóra. A korlátozások eltávolításához a jelszót meg kell adni. A jelszóval védett bemutató zárolt bemutatónak tekinthető.

Általában beállíthat egy jelszót, hogy érvényesítse ezeket a korlátozásokat egy bemutatón:

- **Modification**

  Ha csak bizonyos felhasználóknak szeretné engedélyezni a bemutató módosítását, beállíthat egy módosítási korlátozást. Ez a korlátozás megakadályozza, hogy az emberek módosítsák, változtassák vagy másolják a bemutató tartalmát (kivéve, ha megadják a jelszót).  

  Azonban ebben az esetben, még jelszó nélkül is a felhasználó hozzáférhet a dokumentumhoz és megnyithatja azt. Olvasás‑csak módban a felhasználó megtekintheti a bemutató tartalmát, például a hiperhivatkozásokat, animációkat, effektusokat és egyebeket, de nem másolhat elemeket vagy mentheti a bemutatót.  

- **Opening**

  Ha csak bizonyos felhasználóknak szeretné engedélyezni a bemutató megnyitását, beállíthat egy megnyitási korlátozást. Ez a korlátozás megakadályozza, hogy az emberek egyáltalán megtekintsék a bemutató tartalmát (kivéve, ha megadják a jelszót).  

  Technikai szempontból a megnyitási korlátozás szintén megakadályozza a bemutatók módosítását: ha valaki nem tudja megnyitni a bemutatót, nem tudja módosítani vagy változtatni rajta.  

  **Megjegyzés** hogy amikor jelszóval védi a bemutatót a megnyitás megakadályozása érdekében, a bemutató fájl titkosítva lesz.

## **Hogyan védhet jelszóval egy bemutatót online**

1. Látogasson el a mi [**Aspose.Slides Lock**](https://products.aspose.app/slides/hu/lock) oldalunkra.  

   ![todo:image_alt_text](slides-lock.png)

2. Kattintson a **Húzza ide vagy töltse fel a fájlokat** gombra.

3. Válassza ki a számítógépén azt a fájlt, amelyet jelszóval szeretne védeni.

4. Adja meg a kívánt jelszót a szerkesztési védelemhez; adja meg a kívánt jelszót a megtekintési védelemhez.

5. Ha azt szeretné, hogy a felhasználók a bemutatót a végső példányként lássák, jelölje be a **Mark as final** jelölőnégyzetet.

6. Kattintson a **PROTECT NOW.** gombra.

7. Kattintson a **DOWNLOAD NOW.** gombra.

## **Jelszóvédelem a bemutatókhoz az Aspose.Slides-ban**
**Támogatott formátumok**

Az Aspose.Slides támogatja a jelszóvédelmet, titkosítást és hasonló műveleteket a következő formátumú bemutatók esetén: 

- PPTX és PPT – Microsoft PowerPoint bemutató 
- ODP – OpenDocument bemutató 
- OTP – OpenDocument bemutató sablon 

**Támogatott műveletek**

Az Aspose.Slides lehetővé teszi, hogy jelszóvédelemmel megakadályozza a bemutatók módosítását a következő módokon:

- Bemutató titkosítása
- Írásvédettség beállítása egy bemutatón

**Egyéb műveletek**

Az Aspose.Slides lehetővé teszi egyéb jelszóvédelmi és titkosítási feladatok végrehajtását a következő módokon:

- Bemutató visszafejtése; titkosított bemutató megnyitása
- Titkosítás eltávolítása; jelszóvédelem letiltása
- Írásvédelem eltávolítása egy bemutatóról
- Titkosított bemutató tulajdonságainak lekérése
- Annak ellenőrzése, hogy a bemutató titkosított-e
- Annak ellenőrzése, hogy a bemutató jelszóval védett-e

## **Bemutató titkosítása**

Titkosíthat egy bemutatót jelszó beállításával. Ezután a zárolt bemutató módosításához a felhasználónak meg kell adnia a jelszót.  

A bemutató titkosításához vagy jelszóval való védelméhez az encrypt metódust kell használnia (a [ProtectionManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ProtectionManager) osztályból), hogy jelszót állítson be a bemutatóhoz. A jelszót átadja az encrypt metódusnak, majd a save metódussal menti a most már titkosított bemutatót.  

Ez a példakód bemutatja, hogyan lehet titkosítani egy bemutatót:

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

## **Írásvédelem beállítása egy bemutatón**

Hozzáadhat egy „Ne módosítsa” feliratot a bemutatóhoz. Ezzel jelezheti a felhasználóknak, hogy nem kívánja, hogy módosítsák a bemutatót.  

**Megjegyzés** hogy az írásvédelmi folyamat nem titkosítja a bemutatót. Ezért a felhasználók – ha akarják – módosíthatják a bemutatót, de a változtatások mentéséhez másik néven kell menteniük a bemutatót.  

Az írásvédelem beállításához a [setWriteProtection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ProtectionManager#setWriteProtection-java.lang.String-) metódust kell használnia. Ez a példakód bemutatja, hogyan állíthat be írásvédelmet egy bemutatón:

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

## **Bemutató visszafejtése; Titkosított bemutató megnyitása**

Az Aspose.Slides lehetővé teszi egy titkosított fájl betöltését a jelszó megadásával. A bemutató visszafejtéséhez a [removeEncryption](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) metódust kell meghívnia paraméterek nélkül. Ezután a helyes jelszót kell megadnia a bemutató betöltéséhez.  

Ez a példakód bemutatja, hogyan lehet visszafejteni egy bemutatót: 

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    // munka a visszafejtett prezentációval
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Titkosítás eltávolítása; Jelszóvédelem letiltása**

Eltávolíthatja a titkosítást vagy a jelszóvédelmet egy bemutatóról. Így a felhasználók korlátozások nélkül hozzáférhetnek a bemutatóhoz vagy módosíthatják azt.  

A titkosítás vagy jelszóvédelem eltávolításához a [removeEncryption](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) metódust kell meghívnia. Ez a példakód bemutatja, hogyan távolítható el a titkosítás egy bemutatóról:

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

## **Írásvédelem eltávolítása egy bemutatóról**

Az Aspose.Slides használatával eltávolíthatja a bemutató fájlon alkalmazott írásvédelmet. Így a felhasználók szabadon módosíthatják azt, és nem kapnak figyelmeztetést ilyen műveletek végrehajtásakor.  

Az írásvédelem eltávolításához a [removeWriteProtection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ProtectionManager#removeWriteProtection--) metódust kell használni. Ez a példakód bemutatja, hogyan távolítható el az írásvédelem egy bemutatóról:

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

## **Titkosított bemutató tulajdonságainak lekérése**

Általában a felhasználók nehezen jutnak hozzá a titkosított vagy jelszóval védett bemutató dokumentum tulajdonságaihoz. Az Aspose.Slides azonban olyan mechanizmust kínál, amely lehetővé teszi a bemutató jelszóval való védelmét, miközben a felhasználók továbbra is elérhetik a bemutató tulajdonságait.  

**Megjegyzés** hogy amikor az Aspose.Slides titkosít egy bemutatót, a bemutató dokumentum tulajdonságai is alapértelmezés szerint jelszóval védettek lesznek. Ha azonban a bemutató tulajdonságait elérhetővé kell tenni (még a titkosítás után is), az Aspose.Slides lehetővé teszi ezt.  

Ha azt szeretné, hogy a felhasználók továbbra is hozzáférhessenek a titkosított bemutató tulajdonságaihoz, a [encryptDocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ProtectionManager#getEncryptDocumentProperties--) tulajdonságot állítsa `true` értékre. Ez a példakód bemutatja, hogyan titkosíthat egy bemutatót, miközben lehetőséget biztosít a felhasználóknak a dokumentum tulajdonságok elérésére:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **A bemutató jelszóval védett-e ellenőrzése betöltés előtt**

Mielőtt betöltene egy bemutatót, lehetséges, hogy ellenőrizni és megerősíteni szeretné, hogy a bemutató nincs jelszóval védve. Így elkerülheti a hibákat és hasonló problémákat, amelyek akkor merülnek fel, amikor egy jelszóval védett bemutatót a jelszó nélkül próbálják betölteni.  

Ez a JavaScript kód bemutatja, hogyan vizsgálhatja meg egy bemutatót annak megállapításához, hogy jelszóval védett-e (a bemutató betöltése nélkül):

```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Ellenőrizze, hogy a bemutató titkosított-e**

Az Aspose.Slides lehetővé teszi, hogy ellenőrizze, titkosított-e egy bemutató. Ehhez használhatja a [isEncrypted](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ProtectionManager#isEncrypted--) tulajdonságot, amely `true` értéket ad, ha a bemutató titkosított, vagy `false` értéket, ha nem titkosított.  

Ez a példakód bemutatja, hogyan ellenőrizhető, hogy egy bemutató titkosított-e:

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

## **Ellenőrizze, hogy a bemutató írásvédett-e**

Az Aspose.Slides lehetővé teszi, hogy ellenőrizze, írásvédett-e egy bemutató. Ehhez használhatja a [isWriteProtected](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ProtectionManager#isWriteProtected--) tulajdonságot, amely `true` értéket ad, ha a bemutató titkosított, vagy `false` értéket, ha a bemutató nincs titkosítva.  

Ez a példakód bemutatja, hogyan ellenőrizhető, hogy egy bemutató írásvédett-e:

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

## **Egy adott jelszó használatának ellenőrzése egy bemutató védelméhez**

Lehet, hogy ellenőrizni és megerősíteni szeretné, hogy egy adott jelszót használtak-e a bemutató dokumentum védelmére. Az Aspose.Slides lehetőséget biztosít a jelszó érvényesítésére.  

Ez a példakód bemutatja, hogyan validálható egy jelszó:

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

`true` értéket ad, ha a bemutató a megadott jelszóval lett titkosítva. Egyébként `false` értéket ad.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/hu/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **GYIK**

**Milyen titkosítási módszereket támogat az Aspose.Slides?**

Az Aspose.Slides modern titkosítási módszereket támogat, beleértve az AES-alapú algoritmusokat, biztosítva a bemutatók magas szintű adatbiztonságát.

**Mi történik, ha helytelen jelszót ad meg a bemutató megnyitásakor?**

Kivétel keletkezik, ha helytelen jelszót használnak, jelezve, hogy a bemutatóhoz való hozzáférés megtagadva. Ez segít megakadályozni a jogosulatlan hozzáférést és védi a bemutató tartalmát.

**Vannak-e teljesítménybeli következmények a jelszóval védett bemutatókkal való munka során?**

A titkosítási és visszafejtési folyamat enyhe késleltetést okozhat a megnyitási és mentési műveletek során. A legtöbb esetben ez a teljesítményhatás minimális, és nem befolyásolja jelentősen a bemutató feladatai általános feldolgozási idejét.