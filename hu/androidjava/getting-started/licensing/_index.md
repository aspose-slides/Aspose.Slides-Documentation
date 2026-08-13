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
- licenc ellenőrzése
- licencfájl
- értékelési verzió
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Alkalmazza, kezelje és hibaelhárítsa a licenceket az Aspose.Slides for Android via Java-ban. Biztosítsa a folyamatos hozzáférést a teljes funkcionalitáshoz licencelési útmutatónkkal."
---
## **Áttekintés**

Az Aspose.Slides használható értékelési módban vagy érvényes licenccel. Az értékelési verzió ugyanazt a funkcionalitást nyújtja, mint a licencelt verzió, de értékelési vízjelet helyez el a dokumentum tetejére a megnyitás és mentés során, és a szövegkinyerést egy diára korlátozza.

Ez a cikk elmagyarázza, hogyan működik a licencelés az Aspose.Slides-ben, és hogyan lehet licencet alkalmazni a könyvtár használata előtt. A licenc betölthető fájlból, streame-ből vagy beágyazott erőforrásból a `License` osztály használatával. A cikk azt is bemutatja, hogyan ellenőrizhető, hogy a licenc helyesen lett-e alkalmazva.

## **Az Aspose.Slides értékelése**

{{% alert color="info" %}} 

Letöltheti az **Aspose.Slides for Android via Java** értékelési verzióját a [letöltési oldalról](https://releases.aspose.com/slides/hu/androidjava/). Az értékelési verzió ugyanazokat a funkciókat nyújtja, mint a termék licencelt verziója. Az értékelési csomag megegyezik a megvásárolt csomaggal. Az értékelési verzió egyszerűen licencszerűvé válik, miután néhány kódsort hozzáad (a licenc alkalmazásához).

Ha elégedett az **Aspose.Slides** értékelésével, [vásárolhat licencet](https://purchase.aspose.com/buy). Javasoljuk, hogy tekintse át a különböző előfizetési típusokat. Ha kérdése van, vegye fel a kapcsolatot az Aspose értékesítési csapatával.

Minden Aspose licenc egy éves előfizetést tartalmaz, amely ingyenes frissítéseket biztosít az előfizetési időszakban kiadott új verziókra vagy javításokra. A licencelt termékek (vagy még az értékelési verziók) felhasználói ingyenes és korlátlan technikai támogatást kapnak.

{{% /alert %}} 

**Az értékelési verzió korlátozásai**

* Míg az Aspose.Slides értékelési verziója (licenc megadása nélkül) teljes termékfunkcionalitást nyújt, a megnyitás és mentés során a dokumentum tetejére értékelési vízjelet helyez.
* Szövegkinyerés esetén csak egy diára vagy korlátozva.

{{% alert color="info" %}} 

Az Aspose.Slides korlátozások nélküli teszteléséhez kérhet **30 napos ideiglenes licencet**. További információért tekintse meg a [How to get a Temporary License](https://purchase.aspose.com/temporary-license) oldalt.

{{% /alert %}}

## **Licencelés az Aspose.Slides-ben**

* Az értékelési verzió licencszerűvé válik, miután megvásárolta a licencet és néhány kódsort hozzáad (a licenc alkalmazásához).
* A licenc egy egyszerű szöveges XML-fájl, amely részleteket tartalmaz, például a termék nevét, a licencelt fejlesztők számát, az előfizetés lejárati dátumát stb.
* A licencfájl digitálisan alá van írva, ezért nem szabad módosítani. Még egy véletlenül beillesztett sortörés is érvényteleníti a fájlt.
* Az Aspose.Slides for Android via Java általában a licencet a következő helyeken keresi:
  * Kifejezett útvonal
  * Az Aspose.Slides.jar-t tartalmazó mappa
* Az értékelési verzióval kapcsolatos korlátozások elkerülése érdekében a **Aspose.Slides** használata előtt be kell állítania egy licencet. Az alkalmazáson vagy folyamatonként csak egyszer kell licencet beállítani.

## **Licenc alkalmazása**

A licenc betölthető **fájlból** vagy **streamből**.

{{% alert color="info" %}}

Az Aspose.Slides biztosítja a [License](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/license/) osztályt a licencelési műveletekhez.

{{% /alert %}} 

{{% alert color="warning" %}}

Az új licencek csak a 21.4 vagy annál újabb verzióval aktiválhatják az Aspose.Slides-et. A korábbi verziók más licencelési rendszert használnak, és nem ismerik fel ezeket a licenceket.

{{% /alert %}}

### **Fájl**

A licenc beállításának legegyszerűbb módja, ha a licencfájlt az Aspose.Slides.jar-t vagy az alkalmazás jar-ját tartalmazó mappába helyezi.

Ez a Java kód megmutatja, hogyan állítható be egy licencfájl:

``` java
// Példányosítja a License osztályt
com.aspose.slides.License license = new com.aspose.slides.License();

// Beállítja a licencfájl elérési útvonalát
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" %}} 

Ha a licencfájlt más könyvtárba helyezi, akkor a [SetLicense](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) metódus hívásakor a megadott kifejezett útvonal végén lévő licencfájl neve meg kell, hogy egyezzen a licencfájl nevével.

Például megváltoztathatja a licencfájl nevét *Aspose.Slides.Android.via.Java.lic.xml*-ra. Ezután a kódban át kell adnia a fájl elérési útját (amely *Aspose.Slides.Android.via.Java.lic.xml*-ra végződik) a [SetLicense](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) metódusnak.

{{% /alert %}}

### **Stream**

Licencet betölthet egy streame-ből. Ez a Java kód megmutatja, hogyan alkalmazzák a licencet egy streame-ből:

``` java
// Példányosítja a License osztályt
com.aspose.slides.License license = new com.aspose.slides.License();

// Beállítja a licencet egy streamen keresztül
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

## **Licenc ellenőrzése**

A licenc helyes beállításának ellenőrzéséhez validálhatja azt. Ez a Java kód bemutatja, hogyan validáljunk egy licencet:

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

{{% alert title="Note" color="warning" %}} 

A [SetLicense](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) metódus nem szálbiztos. Ha ezt a metódust sok szálból kell egyszerre meghívni, érdemes szinkronizációs primitíveket (például lockot) használni a problémák elkerülése érdekében. 

{{% /alert %}}

## **GYIK**

### Alkalmazhatom a licencet teljesen offline környezetben (nincs internetkapcsolat)?

Igen. A licenc ellenőrzése helyileg, a licencfájl segítségével történik; nincs szükség internetkapcsolatra.

### Mi történik, ha az egyéves előfizetés lejár? Leáll a könyvtár működése?

Nem. A licenc örökös: a feliratkozás lejárati dátuma előtt kiadott verziókat továbbra is használhatja; azonban az újabb kiadások használatához megújítás szükséges.