---
title: Licencelés
type: docs
weight: 90
url: /hu/androidjava/licensing/
keywords:
- licenc
- ideiglenes licenc
- licenc beállítása
- licenc használata
- licenc érvényesítése
- licencfájl
- kiértékelési verzió
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Licencelés alkalmazása, kezelése és hibakeresése az Aspose.Slides for Android via Java-ban. Biztosítsa a megszakítás nélküli teljes funkciók elérését licencelési útmutatónkkal."
---
## **Áttekintés**

Az Aspose.Slides használható kiértékelési módban vagy érvényes licenccel. A kiértékelési verzió ugyanazt a funkcionalitást biztosítja, mint a licencelt verzió, de minden mentett prezentáció minden diájára egy kiértékelési vízjelet helyez, és lerövidíti a kódból olvasott szöveget a prezentációkból.

Ez a cikk elmagyarázza, hogyan működik a licencelés az Aspose.Slides-ben, és hogyan kell licencet alkalmazni a könyvtár használata előtt. Licencet fájlból, adatfolyamból vagy beágyazott erőforrásból lehet betölteni a [Licenc](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/) osztály segítségével. A cikk bemutatja továbbá, hogyan lehet ellenőrizni, hogy a licenc helyesen lett-e alkalmazva.

## **Az Aspose.Slides kiértékelése**

{{% alert color="info" title="Note" %}}
Letöltheti a **Aspose.Slides for Android via Java** kiértékelési verzióját a [letöltési oldalról](https://releases.aspose.com/slides/androidjava/). A kiértékelési verzió ugyanazokat a funkciókat kínálja, mint a termék licencelt verziója. A kiértékelési csomag megegyezik a megvásárolt csomaggal. A kiértékelési verzió egyszerűen licenccé válik, miután néhány kódsort hozzáad (a licenc alkalmazásához).

Miután elégedett a **Aspose.Slides** kiértékelésével, [licencet vásárolhat](https://purchase.aspose.com/pricing/slides/android-java/). Javasoljuk, hogy tekintse át a különböző előfizetési típusokat. Kérdéseivel forduljon az Aspose értékesítési csapatához.

Minden Aspose licenc egyéves előfizetést tartalmaz, amely ingyenes frissítéseket biztosít az előfizetési időszakon belül kiadott új verziókra vagy javításokra. A licencelt termékeket (vagy akár a kiértékelési verziókat) használó felhasználók ingyenes és korlátlan műszaki támogatást kapnak.
{{% /alert %}}

**A kiértékelési verzió korlátozásai**

* A kiértékelési verzió (licenc megadása nélkül) teljes termékfunkcionalitást biztosít, de minden mentett prezentáció minden diájára kiértékelési vízjel szövegdobozt helyez.
* A prezentációból a kód által olvasott szöveg első néhány karakterre rövidül le, majd egy értesítést kap a kiértékelési korlátozásról. A kód által írt szöveg teljes formában kerül mentésre.

{{% alert color="info" title="Note" %}}
Aspose.Slides korlátozások nélküli teszteléséhez kérhet **30 napos ideiglenes licencet**. További információkért tekintse meg a [Hogyan szerezhet ideiglenes licencet](https://purchase.aspose.com/temporary-license) oldalt.
{{% /alert %}}

## **Licencelés az Aspose.Slides-ben**

* A kiértékelési verzió licencelté válik, miután licencet vásárol és néhány kódsort hozzáad (a licenc alkalmazásához).
* A licenc egy egyszerű szöveges XML-fájl, amely olyan részleteket tartalmaz, mint a termék neve, a licencelt fejlesztők száma, az előfizetés lejárati dátuma stb.
* A licencfájlt digitálisan aláírják, ezért nem szabad módosítani. Még egy felesleges sortörés hozzáadása a fájl tartalmához is érvényteleníti azt.
* Az Aspose.Slides for Android via Java általában ezeken a helyeken keresi a licencet:
  * Közvetlen útvonal
  * Az Aspose.Slides.jar-t tartalmazó mappa
* A kiértékelési verzióhoz kapcsolódó korlátozások elkerülése érdekében be kell állítania egy licencet a **Aspose.Slides** használata előtt. Egy licencet csak egyszer kell beállítani alkalmazásonként vagy folyamatként.

## **Licenc alkalmazása**

Licenc betölthető **fájlból** vagy **adatfolyamból**.

{{% alert color="info" title="Note" %}}
Az Aspose.Slides a [Licenc](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/) osztályt biztosítja a licencelési műveletekhez.
{{% /alert %}}

{{% alert color="warning" title="Warning" %}}
Az új licencek csak a 21.4-es vagy újabb verzióval aktiválhatják az Aspose.Slides-et. A korábbi verziók más licencelési rendszert használnak, és nem ismerik fel ezeket a licenceket.
{{% /alert %}}

### **Fájl**

A licenc beállításának legegyszerűbb módja, ha a licencfájlt az Aspose.Slides.jar-t vagy az alkalmazás JAR-ját tartalmazó mappába helyezi.

{{% alert color="info" title="Note" %}}
Androidon a könyvtár és az alkalmazás az APK-ba van csomagolva, így nincs olyan mappa, amely a könyvtár JAR fájlját tartalmazza, és például az *Aspose.Slides.Android.via.Java.lic* relatív útvonal nem mutat egy fájlra az alkalmazásban. Adja hozzá a licencfájlt az alkalmazás *assets* mappájához, és töltse be adatfolyamból, ahogy a [Stream from App Assets](#stream-from-app-assets) részben látható.
{{% /alert %}}

``` java
// Példányosítja a License osztályt
com.aspose.slides.License license = new com.aspose.slides.License();

// Beállítja a licencfájl útvonalát
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" title="Warning" %}}
Ha a licencfájlt egy másik könyvtárba helyezi, a [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) metódus hívásakor az adott útvonal végén szereplő licencfájl neve meg kell, hogy egyezzen a licencfájljának nevével.

Például megváltoztathatja a licencfájl nevét *Aspose.Slides.Android.via.Java.lic.xml*-re. Ezután a kódban át kell adnia a fájl elérési útját (amely *Aspose.Slides.Android.via.Java.lic.xml*-re végződik) a [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) metódusnak.
{{% /alert %}}

### **Adatfolyam**

Licenc betölthető adatfolyamból. Ez a Java kód bemutatja, hogyan kell licencet alkalmazni adatfolyamról:
``` java
// Példányosítja a License osztályt
com.aspose.slides.License license = new com.aspose.slides.License();

// Beállítja a licencet adatfolyamon keresztül
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

### **Adatfolyam az alkalmazás eszközeiből**

Android alkalmazásban helyezze a licencfájlt az alkalmazás *assets* mappájába, azaz *app/src/main/assets* könyvtárba, hogy az APK-ba legyen csomagolva. Nyissa meg a fájlt a [getAssets](https://developer.android.com/reference/android/content/Context#getAssets()) metódussal, és adja át az adatfolyamot a [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) metódusnak. A kód egy `Activity`-ben fut, például az `onCreate` metódusában, mielőtt az alkalmazás az Aspose.Slides-et használja:
```java
import android.util.Log;
import com.aspose.slides.License;
import java.io.IOException;
import java.io.InputStream;

License license = new License();
try (InputStream licenseStream = getAssets().open("Aspose.Slides.Android.via.Java.lic")) {
    license.setLicense(licenseStream);
} catch (IOException exception) {
    Log.e("Licensing", "Cannot read the license file from the app's assets.", exception);
}
```

A [open](https://developer.android.com/reference/android/content/res/AssetManager#open(java.lang.String)) metódusnak átadott fájlnév az *assets* mappához relatív. Ha a fájl nem található, a kód naplózza a hibát, és az Aspose.Slides kiértékelési módban marad. A licenc alkalmazásának ellenőrzéséhez lásd a [Licenc ellenőrzése](#validating-a-license) részt.

## **Licenc ellenőrzése**

Annak ellenőrzésére, hogy a licenc megfelelően lett-e beállítva, érvényesítheti azt. Ez a Java kód bemutatja, hogyan kell licencet ellenőrizni:
```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Szálbiztonság**

{{% alert color="warning" title="Warning" %}}
A [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) metódus nem szálbiztos. Ha ezt a metódust egyszerre több szál hívja, érdemes szinkronizációs primitíveket (például zárolást) használni a problémák elkerülése érdekében.
{{% /alert %}}

## **GYIK**

### Alkalmazhatom a licencet teljesen offline környezetben (internetkapcsolat nélkül)?

Igen. A licenc ellenőrzése helyben, a licencfájl segítségével történik; internetkapcsolat nem szükséges.

### Mi történik, ha az egyéves előfizetés lejár? Leáll a könyvtár működése?

Nem. A licenc örökös: a feliratkozás befejezési dátuma előtt kiadott verziókat továbbra is használhatja; azonban a megújítás nélkül nem lesz jogosult az újabb kiadásokra.