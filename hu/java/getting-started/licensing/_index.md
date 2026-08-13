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
- értékelési verzió
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Alkalmazza, kezelje és hárítja el a licencelési problémákat az Aspose.Slides for Java-ban. Biztosítsa a teljes funkcionalitáshoz való folytonos hozzáférést lépésről lépésre útmutatónkkal."
---
## **Áttekintés**

Az Aspose.Slides használható értékelési módban vagy érvényes licenccel. Az értékelési verzió ugyanazt a funkcionalitást biztosítja, mint a licencelt verzió, de értékelési vízjelet ad a prezentációk megnyitásakor vagy mentésekor, és korlátozza a szövegkinyerést egy diára.

Ez a cikk ismerteti, hogyan működik a licenckezelés az Aspose.Slides-ben, és hogyan kell licencet alkalmazni a könyvtár használata előtt. A licenc betölthető fájlból, áramlásból (stream) vagy beágyazott erőforrásból a `License` osztály használatával. A cikk bemutatja továbbá, hogyan ellenőrizhető, hogy a licenc helyesen lett-e alkalmazva.

## **Az Aspose.Slides értékelése**

{{% alert color="info" %}} 
Letöltheti az **Aspose.Slides for Java** értékelési verzióját a [letöltési oldalról](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Az értékelési verzió ugyanazokat a funkciókat biztosítja, mint a termék licencelt változata. Az értékelési csomag megegyezik a megvásárolt csomaggal. Az értékelési verzió egyszerűen licencessé válik, miután néhány kódsort hozzáad (a licenc alkalmazásához). 

Miután elégedett az **Aspose.Slides** értékelésével, [licencet vásárolhat](https://purchase.aspose.com/buy). Javasoljuk, hogy tekintse át a különböző előfizetési típusokat. Ha kérdése van, lépjen kapcsolatba az Aspose értékesítési csapatával. 

Minden Aspose licenc egyéves előfizetést tartalmaz, amely ingyenes frissítéseket biztosít az előfizetési időszakban kiadott új verziókhoz vagy javításokhoz. A licencelt termékek (vagy még az értékelési verziók) felhasználói ingyenes és korlátlan technikai támogatást kapnak. 
{{% /alert %}} 

**Az értékelési verzió korlátozásai**

* Bár az Aspose.Slides értékelési verziója (licenc nélkül) teljes termékfunkcionalitást biztosít, megnyitáskor és mentéskor a dokumentum tetejére értékelési vízjelet helyez. 
* A prezentációs diák szövegének kinyerésekor csak egy diára van korlátozva. 

{{% alert color="info" %}} 
Az Aspose.Slides korlátozások nélküli teszteléséhez kérhet **30 napos ideiglenes licencet**. További információkért lásd a [Hogyan szerezzen ideiglenes licencet](https://purchase.aspose.com/temporary-license) oldalt. 
{{% /alert %}}

## **Licencelés az Aspose.Slides-ben**

* Az értékelési verzió licencszerűvé válik, miután licencet vásárol és néhány kódsort hozzáad (a licenc alkalmazásához). 
* A licenc egy egyszerű szöveges XML fájl, amely olyan részleteket tartalmaz, mint a termék neve, a licencelt fejlesztők száma, az előfizetés lejárati dátuma stb. 
* A licencfájl digitálisan alá van írva, ezért nem szabad módosítani. Még egy véletlenül hozzáadott sorvége is érvényteleníti a fájlt. 
* Aspose.Slides for Java általában az alábbi helyeken próbálja megtalálni a licencet:
  * Közvetlen útvonal
  * Az Aspose.Slides.jar fájlt tartalmazó könyvtár 
* Az értékelési verzióval kapcsolatos korlátozások elkerüléséhez licencet kell beállítani a **Aspose.Slides** használata előtt. Az alkalmazás vagy folyamat során csak egyszer kell licencet megadni. 

{{% alert color="info" %}} 
Érdemes megnézni a [Méréses licencelés](/slides/hu/java/metered-licensing/). 
{{% /alert %}} 


## **Licenc alkalmazása**

A licenc betölthető **fájlból** vagy **áramlásból**. 

{{% alert color="info" %}}

Az Aspose.Slides a [License](https://reference.aspose.com/slides/hu/java/com.aspose.slides/License) osztályt biztosítja a licencelési műveletekhez. 
{{% /alert %}} 

{{% alert color="warning" %}}

Az új licencek csak a 21.4 vagy újabb verzióval tudják aktiválni az Aspose.Slides-t. A korábbi verziók más licencelési rendszert használnak, és nem ismerik fel ezeket a licenceket. 
{{% /alert %}}

### **Fájl**

A licenc beállításának legegyszerűbb módja, ha a licencfájlt az Aspose.Slides.jar vagy az alkalmazás jar fájlját tartalmazó mappába helyezi. 

Ez a Java kód bemutatja, hogyan állíthat be egy licencfájlt: 

``` java
// Létrehozza a License osztályt
com.aspose.slides.License license = new com.aspose.slides.License();

// Beállítja a licencfájl útvonalát
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" %}} 

Ha a licencfájlt más könyvtárba helyezi, a [SetLicense](https://reference.aspose.com/slides/hu/java/com.aspose.slides/License#setLicense-java.lang.String-) metódus hívásakor a megadott explicit útvonal végén szereplő licencfájl neve meg kell, hogy egyezzen a tényleges licencfájllal. 

Például átnevezheti a licencfájlt *Aspose.Slides.Java.lic.xml*-re. Ezután a kódban a fájl elérési útját (amely *Aspose.Slides.Java.lic.xml*-re végződik) kell átadni a [SetLicense](https://reference.aspose.com/slides/hu/java/com.aspose.slides/License#setLicense-java.lang.String-) metódusnak. 
{{% /alert %}}

### **Áramlás**

Licenc betölthető áramlatból. Ez a Java kód bemutatja, hogyan alkalmazzon licencet áramlatból: 

``` java
// Létrehozza a License osztályt
com.aspose.slides.License license = new com.aspose.slides.License();

// Beállítja a licencet áramlatból
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

Ha Java-n keresztül használja az Aspose.Slides for PHP-t, licencet állíthat be egy PHP/Java hídon keresztül. Ez a híd lehetővé teszi a Java osztályok PHP szintaxisban való használatát. További információkért lásd a [Licenc PHP-ben](/slides/hu/php-java/licensing/) oldalt. 

## **Licenc ellenőrzése**

Annak ellenőrzésére, hogy a licenc megfelelően van-e beállítva, ellenőrizhetjük. Ez a Java kód bemutatja, hogyan validáljon egy licencet: 

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Szálbiztonság**

{{% alert title="Note" color="warning" %}} 

A [SetLicense](https://reference.aspose.com/slides/hu/java/com.aspose.slides/License#setLicense-java.io.InputStream-) metódus nem szálbiztos. Ha ezt a metódust sok szál hívja egyszerre, célszerű szinkronizációs primitíveket (pl. lock) használni a problémák elkerülése érdekében. 
{{% /alert %}}

## **GYIK**

### Alkalmazhatom a licencet teljesen offline környezetben (internetkapcsolat nélkül)?

Igen. A licenc érvényesítése helyben, a licencfájl segítségével történik; internetkapcsolat nem szükséges. 

### Mi történik, miután az egyéves előfizetés lejár? Leáll a könyvtár működése?

Nem. A licenc örökös: a feliratkozási dátum előtt megjelenő verziókat továbbra is használhatja; azonban a későbbi kiadásokat csak megújítás után vehetik igénybe.