---
title: Licencelés
type: docs
weight: 90
url: /hu/java/licensing/
keywords:
- licenc
- ideiglenes licenc
- licenc beállítása
- licenc használata
- licenc ellenőrzése
- licenc fájl
- értékelő verzió
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Alkalmazza, kezelje és hibaelhárítsa a licenceket az Aspose.Slides for Java-ban. Biztosítsa a megszakítás nélküli hozzáférést a teljes funkciókhoz lépésről lépésre útmutatónk segítségével."
---
## **Áttekintés**

Az Aspose.Slides használható értékelő módban vagy érvényes licencel. Az értékelő verzió ugyanazt a funkcionalitást nyújtja, mint a licencelt verzió, de értékelő vízjelet ad a prezentációk megnyitásakor vagy mentésekor, és korlátozza a szöveg kinyerését egy diára.

Ez a cikk bemutatja, hogyan működik a licencelés az Aspose.Slides-ben, és hogyan lehet licencet alkalmazni a könyvtár használata előtt. Egy licencet betölthet fájlból, streame-ből vagy beágyazott erőforrásból a `License` osztály használatával. A cikk azt is megmutatja, hogyan lehet ellenőrizni, hogy a licenc helyesen lett-e alkalmazva.

## **Az Aspose.Slides értékelése**

{{% alert color="primary" %}} 

Letöltheti az **Aspose.Slides for Java** értékelő verzióját a [letöltési oldalról](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Az értékelő verzió ugyanazokat a funkciókat biztosítja, mint a termék licencelt változata. Az értékelő csomag megegyezik a megvásárolt csomaggal. Az értékelő verzió egyszerűen licencelté válik, miután néhány kódsort hozzáad (a licenc alkalmazásához).

Ha elégedett az **Aspose.Slides** értékelésével, [vásárolhat licencet](https://purchase.aspose.com/buy). Javasoljuk, hogy tekintse át a különböző előfizetési típusokat. Ha kérdése van, vegye fel a kapcsolatot az Aspose értékesítési csapatával.

Minden Aspose licenc egy éves előfizetést tartalmaz ingyenes frissítésekhez az új verziókra vagy a előfizetési időszakban kiadott javításokra. A licencelt termékek (vagy akár az értékelő verziók) felhasználói ingyenes és korlátlan műszaki támogatást kapnak.

{{% /alert %}} 

**Az értékelő verzió korlátozásai**

* Noha az Aspose.Slides értékelő verziója (licenc nélkül) a teljes termékfunkcionalitást biztosítja, a megnyitás és mentés műveletek során egy értékelő vízjelet helyez a dokumentum tetejére. 
* Szöveg kinyerésekor a prezentáció diákból csak egy diára korlátozódik.

{{% alert color="primary" %}} 

Az Aspose.Slides korlátozások nélküli teszteléséhez kérhet egy **30 napos ideiglenes licencet**. További információkért tekintse meg a [Hogyan kérhet ideiglenes licencet](https://purchase.aspose.com/temporary-license) oldalt.

{{% /alert %}}

## **Licencelés az Aspose.Slides-ben**

* Az értékelő verzió licencelté válik, miután megvásárol egy licencet és néhány kódsort hozzáad (a licenc alkalmazásához).
* A licenc egy egyszerű szöveges XML fájl, amely részleteket tartalmaz, például a termék neve, a licencelt fejlesztők száma, az előfizetés lejárati dátuma stb.
* A licencfájlt digitálisan aláírják, ezért nem szabad módosítani. Még egy véletlen sorvége hozzáadása is érvényteleníti a fájlt.
* Az Aspose.Slides for Java általában a következő helyeken keresi a licencet:
  * Kifejezett útvonal
  * Az Aspose.Slides.jar fájlt tartalmazó mappa
* Az értékelő verzióval járó korlátozások elkerülése érdekében licencet kell beállítania a **Aspose.Slides** használata előtt. A licencet csak egyszer kell beállítani alkalmazásonként vagy folyamatként.

{{% alert color="primary" %}} 

Érdemes lehet megnézni a [Metered Licensing](/slides/hu/java/metered-licensing/) oldalt.

{{% /alert %}} 

## **Licenc alkalmazása**

A licenc betölthető **fájlból** vagy **streame-ből**.

{{% alert color="primary" %}}

Az Aspose.Slides a [License](https://reference.aspose.com/slides/hu/java/com.aspose.slides/License) osztályt biztosítja a licencelési műveletekhez.

{{% /alert %}} 

{{% alert color="warning" %}}

Az új licencek csak a 21.4 vagy annál újabb verzióval aktiválhatják az Aspose.Slides-t. A korábbi verziók más licencelési rendszert használnak, és nem fogadják el ezeket a licenceket.

{{% /alert %}}

### **Fájl**

A licenc beállításának legegyszerűbb módja, ha a licencfájlt az Aspose.Slides.jar vagy az alkalmazás jar fájlját tartalmazó mappában helyezi el.

Ez a Java kód bemutatja, hogyan állítsa be a licencfájlt:

``` java
// Példányosítja a License osztályt
com.aspose.slides.License license = new com.aspose.slides.License();

// Beállítja a licencfájl elérési útvonalát
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" %}} 

Ha a licencfájlt más könyvtárba helyezi, a [SetLicense](https://reference.aspose.com/slides/hu/java/com.aspose.slides/License#setLicense-java.lang.String-) metódus meghívásakor a megadott kifejezett útvonal végén lévő licencfájl neve meg kell, hogy egyezzen a saját licencfájljával.

Például megváltoztathatja a licencfájl nevét *Aspose.Slides.Java.lic.xml*-re. Ezután a kódban a [SetLicense](https://reference.aspose.com/slides/hu/java/com.aspose.slides/License#setLicense-java.lang.String-) metódusnak a fájl elérési útvonalát (amely *Aspose.Slides.Java.lic.xml*-re végződik) kell átadnia.

{{% /alert %}}

### **Áram**

Licencet betölthet egy streame-ből. Ez a Java kód bemutatja, hogyan alkalmazzon licencet egy streame-ből:

``` java
// Példányosítja a License osztályt
com.aspose.slides.License license = new com.aspose.slides.License();

// Beállítja a licencet egy streamen keresztül
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

Ha Az Aspose.Slides for PHP-t Java-n keresztül használja, licencet állíthat be egy PHP/Java hídon keresztül. Ez a híd lehetővé teszi, hogy Java osztályokat használjon PHP szintaxisban. További információért tekintse meg a [License in PHP](/slides/hu/php-java/licensing/) oldalt.

## **Licenc ellenőrzése**

Az ellenőrzéshez, hogy a licenc helyesen lett-e beállítva, validálhatja azt. Ez a Java kód bemutatja, hogyan validáljon egy licencet:

```java
License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Szálbiztonság**

{{% alert title="Megjegyzés" color="warning" %}} 

A [SetLicense](https://reference.aspose.com/slides/hu/java/com.aspose.slides/License#setLicense-java.io.InputStream-) metódus nem szálbiztos. Ha ezt a metódust egyszerre több szálból kell meghívni, érdemes szinkronizációs primitíveket (például egy lock-ot) használni a problémák elkerülése érdekében. 

{{% /alert %}}

## **GYIK**

**Alkalmazhatom a licencet egy teljesen offline környezetben (nincs internetkapcsolat)?**

Igen. A licenc ellenőrzése helyben, a licencfájl használatával történik; internetkapcsolat nem szükséges.

**Mi történik, ha az egyéves előfizetés lejár? Megszűnik a könyvtár működése?**

Nem. A licenc örökös: továbbra is használhatja a feliratkozás lejárta előtti kiadott verziókat; csak megújítás nélkül nem lesz jogosult az újabb kiadások használatára.