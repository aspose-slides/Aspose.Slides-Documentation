---
title: Jelszóval védett prezentációk Androidon
linktitle: Jelszóvédelem
type: docs
weight: 20
url: /hu/androidjava/password-protected-presentation/
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
- prezentáció biztonság
- jelszó eltávolítása
- védelem eltávolítása
- titkosítás eltávolítása
- jelszó letiltása
- védelem letiltása
- írásvédelem eltávolítása
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Könnyedén zárolhatsz és feloldhatsz jelszóval védett PowerPoint és OpenDocument prezentációkat az Aspose.Slides for Android segítségével Java nyelven. Biztosítsd prezentációidat."
---
## **Bevezetés**

Amikor egy bemutatót jelszóval védelmezel, egy jelszót állítasz be, amely bizonyos korlátozásokat érvényesít a bemutatón. A korlátozások eltávolításához a jelszót meg kell adni. A jelszóval védett bemutatót zárolt bemutatónak tekintik.

Általában beállíthatsz egy jelszót, hogy ezeket a korlátozásokat a bemutatónra érvényesítsd:

- **Módosítás**

  Ha csak bizonyos felhasználókat szeretnél engedélyezni a bemutató módosítására, beállíthatsz egy módosítási korlátozást. Ez a korlátozás megakadályozza, hogy a felhasználók módosítsák, változtassák vagy másolják a bemutató tartalmát (kivéve ha a jelszót megadják).  

  Azonban ebben az esetben a felhasználó a jelszó nélkül is hozzáférhet a dokumentumhoz és megnyithatja azt. Ez az írásvédett mód lehetővé teszi a felhasználó számára a tartalom (hiperhivatkozások, animációk, effektusok és egyebek) megtekintését a bemutatóban, de nem másolhat elemeket, és nem mentheti a bemutatót. 

- **Megnyitás**

  Ha csak bizonyos felhasználókat szeretnél engedélyezni a bemutató megnyitására, beállíthatsz egy megnyitási korlátozást. Ez a korlátozás megakadályozza, hogy a felhasználók még csak a bemutató tartalmát is megtekintsék (kivéve ha a jelszót megadják).

  Technikailag a megnyitási korlátozás megakadályozza a felhasználók számára a bemutató módosítását is: ha valaki nem tudja megnyitni a bemutatót, nem tudja módosítani vagy változtatni rajta.  

  **Megjegyzés** hogy amikor jelszóval véded a bemutatót a megnyitás meggátolása érdekében, a bemutató fájl titkosítottá válik.

## **Jelszóvédelem a prezentációkhoz az Aspose.Slides-ban**
**Támogatott formátumok**

- PPTX és PPT - Microsoft PowerPoint prezentáció 
- ODP - OpenDocument prezentáció 
- OTP - OpenDocument prezentáció sablon 

**Támogatott műveletek**

Az Aspose.Slides lehetővé teszi a jelszóvédelem használatát a prezentációkon a módosítások megakadályozása érdekében a következő módon:

- A prezentáció titkosítása
- Írásvédettség beállítása a prezentáción

**Egyéb műveletek**

Az Aspose.Slides lehetővé teszi egyéb feladatok végrehajtását, amelyek jelszóvédelmet és titkosítást érintenek, a következő módon:

- Egy prezentáció visszafejtése; egy titkosított prezentáció megnyitása
- Titkosítás eltávolítása; jelszóvédelem letiltása
- Írásvédelem eltávolítása a prezentációról
- Titkosított prezentáció tulajdonságainak lekérdezése
- Ellenőrzés, hogy a prezentáció titkosított-e
- Ellenőrzés, hogy a prezentáció jelszóval védett-e.

## **Prezentáció titkosítása**

Titkosíthatod a prezentációt jelszó beállításával. Ezután a zárolt prezentáció módosításához a felhasználónak meg kell adnia a jelszót.

Ahhoz, hogy titkosítsd vagy jelszóval védd a prezentációt, használnod kell az encrypt metódust (az [IProtectionManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IProtectionManager)) osztályból a jelszó beállításához. A jelszót átadod az encrypt metódusnak, majd a save metódussal mented a most titkosított prezentációt.

Ez a példakód megmutatja, hogyan titkosítható egy prezentáció:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Írásvédelem beállítása egy prezentációra**

Hozzáadhatsz egy „Ne módosítsa” feliratot a prezentációhoz. Ezzel jelezheted a felhasználóknak, hogy nem szeretnéd, ha módosítanák a prezentációt.  

**Megjegyzés** hogy az írásvédelmi folyamat nem titkosítja a prezentációt. Ezért a felhasználók—ha akarják—módosíthatják a prezentációt, de a változtatások mentéséhez más néven kell menteniük a prezentációt. 

Az írásvédelem beállításához a [setWriteProtection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) metódust kell használnod. Ez a példakód megmutatja, hogyan állíts be írásvédelmet egy prezentációra:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Titkosított prezentáció betöltése**

Az Aspose.Slides lehetővé teszi egy titkosított prezentáció betöltését a megfelelő jelszó átadásával a [LoadOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/) segítségével.

Ez a példakód megmutatja, hogyan nyithatsz meg egy titkosított prezentációt: 

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // dolgozz a visszafejtett prezentációval
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Titkosítás eltávolítása egy prezentációból**

Eltávolíthatod a titkosítást vagy a jelszóvédelmet egy prezentációról. Így a felhasználók korlátozások nélkül férhetnek hozzá vagy módosíthatják a prezentációt.

Az titkosítás vagy jelszóvédelem eltávolításához a [removeEncryption](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) metódust kell meghívnod. Ez a példakód megmutatja, hogyan távolítható el a titkosítás egy prezentációból:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Írásvédelem eltávolítása egy prezentációról**

Az Aspose.Slides segítségével eltávolíthatod a prezentáció fájlon alkalmazott írásvédelmet. Így a felhasználók kedvük szerint módosíthatnak—és nem kapnak figyelmeztetést az ilyen feladatok végrehajtásakor.

Az írásvédelmet a [removeWriteProtection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) metódus használatával távolíthatod el egy prezentációról. Ez a példakód megmutatja, hogyan távolítható el az írásvédelem egy prezentációról:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Titkosított prezentáció tulajdonságainak lekérdezése**

Általában a felhasználók nehezen jutnak hozzá a titkosított vagy jelszóval védett prezentáció dokumentumtulajdonságaihoz. Azonban az Aspose.Slides egy olyan mechanizmust kínál, amely lehetővé teszi a prezentáció jelszóval való védelmét, miközben a felhasználók továbbra is hozzáférhetnek a tulajdonságaihoz.

**Megjegyzés:** Alapértelmezés szerint, amikor az Aspose.Slides titkosít egy prezentációt, a prezentáció dokumentumtulajdonságai is jelszóval védettek. Ha a dokumentumtulajdonságokat a titkosítás után is elérhetővé szeretnéd tenni, az Aspose.Slides ezt lehetővé teszi.

Ha szeretnéd, hogy a felhasználók a titkosított prezentáció tulajdonságait továbbra is elérhessék, add át a `false` értéket a [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) metódusnak. Ez a példakód megmutatja, hogyan titkosítható egy prezentáció, miközben a felhasználók hozzáférhetnek a dokumentumtulajdonságaihoz:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Csak a dokumentumtulajdonságok betöltése egy titkosított prezentációból**

Egy titkosított prezentáció metaadatainak a diák vagy egyéb tartalom betöltése nélkül való megtekintéséhez hozz létre egy [LoadOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/) objektumot, és adj `true` értéket a [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-) metódusnak. Ebben a módban az Aspose.Slides figyelmen kívül hagyja a jelszót, és csak a nyilvánosan elérhető dokumentumtulajdonságokat tölti be.

A következő kódrészlet beolvassa a beépített és egyéni dokumentumtulajdonságokat a [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) segítségével:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // Beépített dokumentumtulajdonságok olvasása.
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // Egyéni dokumentumtulajdonságok olvasása.
    int customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        String propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

Ez a munkafolyamat csak akkor működik, ha a dokumentumtulajdonságok a prezentáció titkosítása során titkosítatlanul (nyilvánosan) maradtak. Ha a dokumentumtulajdonságok titkosítottak, a `true` érték átadása a `loadOptions.setOnlyLoadDocumentProperties` metódusnak kivételt eredményez, mivel ebben a módban a jelszó figyelmen kívül marad. A titkosított dokumentumtulajdonságok eléréséhez vagy a teljes prezentáció, beleértve a diák és egyéb tartalom betöltéséhez, add meg a megfelelő jelszót a [ILoadOptions.setPassword](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) metóduson keresztül.

## **Ellenőrzés, hogy a prezentáció jelszóval védett-e**

Mielőtt betöltenél egy prezentációt, érdemes ellenőrizni és megerősíteni, hogy a prezentáció nincs jelszóval védve. Így elkerülheted a hibákat és hasonló problémákat, amelyek egy jelszóval védett prezentáció jelszó nélkül történő betöltésekor merülnek fel.

Ez a Java kód megmutatja, hogyan vizsgálhatod meg egy prezentációt, hogy jelszóval védett-e (a prezentáció tényleges betöltése nélkül):

```java
import com.aspose.slides.*;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Ellenőrzés, hogy a prezentáció titkosított-e**

Az Aspose.Slides lehetővé teszi, hogy ellenőrizd, titkosított-e egy prezentáció. Ehhez használhatod az [isEncrypted](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) tulajdonságot, amely `true` értéket ad vissza, ha a prezentáció titkosított, vagy `false` értéket, ha nem titkosított.

Ez a példakód megmutatja, hogyan ellenőrizhető, hogy egy prezentáció titkosított-e:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Ellenőrzés, hogy a prezentáció írásvédett-e**

Az Aspose.Slides lehetővé teszi, hogy ellenőrizd, írásvédett-e egy prezentáció. Ehhez használhatod az [isWriteProtected](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) tulajdonságot, amely `true` értéket ad, ha a prezentáció írásvédett, vagy `false` értéket, ha nem.

Ez a példakód megmutatja, hogyan ellenőrizhető, hogy egy prezentáció írásvédett-e:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Egy adott jelszó használatának ellenőrzése vagy megerősítése**

Lehet, hogy ellenőrizni és megerősíteni szeretnéd, hogy egy adott jelszót használtak a prezentáció dokumentum védelmére. Az Aspose.Slides biztosítja a lehetőséget a jelszó ellenőrzésére.

Ez a példakód megmutatja, hogyan validálható egy jelszó:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    // ellenőrizze, hogy a "pass" egyezik-e
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

`true` értéket ad vissza, ha a prezentáció a megadott jelszóval írásvédett. Ellenkező esetben `false` értéket ad.

{{% alert color="info" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/hu/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **GYIK**

**Milyen titkosítási módszereket támogat az Aspose.Slides?**

Az Aspose.Slides modern titkosítási módszereket támogat, többek között AES-alapú algoritmusokat, amelyek magas szintű adatbiztonságot biztosítanak a prezentációid számára.

**Mi történik, ha helytelen jelszót adnak meg a prezentáció megnyitásakor?**

Kivétel keletkezik, ha helytelen jelszót használnak, és jezi, hogy a prezentációhoz való hozzáférés megtagadva. Ez segít megakadályozni a jogosulatlan hozzáférést és védi a prezentáció tartalmát.

**Vannak-e teljesítménybeli hatásai a jelszóval védett prezentációk használatának?**

A titkosítási és visszafejtési folyamat enyhe késleltetést okozhat a megnyitás és mentés műveletei során. A legtöbb esetben ez a teljesítményhatás minimális, és nem befolyásolja jelentősen a prezentációs feladatok teljes feldolgozási idejét.