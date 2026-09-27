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
- licenc érvényesítése
- licencfájl
- kiértékelési verzió
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Alkalmazza, kezelje és hibakeresse a licenceket az Aspose.Slides for Java-ban. Biztosítsa a megszakítás nélküli hozzáférést a teljes funkcionalitáshoz lépésről lépésre útmutatónkkal."
---
## **Áttekintés**

Aspose.Slides használható kiértékelési módban vagy érvényes licenccel. A kiértékelési verzió ugyanazt a funkcionalitást biztosítja, mint a licencelt verzió, de minden mentett prezentáció minden diájára kiértékelési vízjelet helyez, és a kódból az API-n keresztül olvasott szöveget rövidíti.

Ez a cikk elmagyarázza, hogyan működik a licencelés az Aspose.Slides-ben, és hogyan lehet licencet alkalmazni a könyvtár használata előtt. A licenc betölthető fájlból, streame-ből vagy beágyazott erőforrásból a `License` osztály segítségével. A cikk bemutatja, hogyan ellenőrizhetjük, hogy a licenc helyesen lett-e alkalmazva.

## **Aspose.Slides kiértékelése**

{{% alert color="info" title="Megjegyzés" %}}

Letöltheti a **Aspose.Slides for Java** kiértékelési verzióját a [letöltési oldalról](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). A kiértékelési verzió ugyanazokat a funkciókat kínálja, mint a termék licencelt változata. A kiértékelési csomag megegyezik a megvásárolt csomaggal. A kiértékelési verzió egyszerűen licencszerűvé válik, ha néhány kódsort hozzáad (a licenc alkalmazásához).

Miután megelégedett a **Aspose.Slides** kiértékelésével, [licencet vásárolhat](https://purchase.aspose.com/pricing/slides/java/). Javasoljuk, hogy tekintse át a különböző előfizetéstípusokat. Kérdései esetén forduljon az Aspose értékesítési csapatához.

Minden Aspose licenc egyéves előfizetést tartalmaz ingyenes frissítésekhez új verziókra vagy a feliratkozási időszakban kiadott hibajavításokhoz. A licencelt termékek (vagy akár a kiértékelési verziók) felhasználói ingyenes és korlátlan technikai támogatást kapnak.

{{% /alert %}} 

**Kiértékelési verzió korlátozásai**

* A kiértékelési verzió (licenc nélkül) teljes funkciókészletet biztosít, de minden mentett prezentáció minden diájára kiértékelési vízjel szövegdobozt helyez.
* A kód által az API-n keresztül olvasott szöveg, beleértve a frissen beállított szöveget is, az első néhány karakterre van csonkolva, majd egy figyelmeztetés a kiértékelési korlátozásról követi. A kód által írt szöveg teljes egészében mentésre kerül.

{{% alert color="info" title="Megjegyzés" %}}

A korlátozások nélküli teszteléshez kérhet **30 napos ideiglenes licencet**. További információkért tekintse meg a [Hogyan kérhet ideiglenes licencet](https://purchase.aspose.com/temporary-license) oldalt.

{{% /alert %}}

## **Licencelés az Aspose.Slides-ben**

* A kiértékelési verzió licencszerűvé válik, ha licencet vásárol, és néhány kódsort hozzáad (a licenc alkalmazásához).
* A licenc egy egyszerű szöveges XML fájl, amely tartalmazza a termék nevét, a licencelt fejlesztők számát, az előfizetés lejárati dátumát stb.
* A licencfájl digitálisan alá van írva, ezért nem módosítható. Még egy felesleges sortörés is érvényteleníti.
* Az Aspose.Slides for Java általában az alábbi helyeken keresi a licencet:
  * Kifejezett útvonal
  * Az Aspose.Slides.jar-t tartalmazó mappa
* A kiértékelési verzióhoz kapcsolódó korlátozások elkerüléséhez be kell állítania egy licencet a **Aspose.Slides** használata előtt. Egy licencet csak egyszer kell beállítani alkalmazásonként vagy folyamatonként.

{{% alert color="info" title="Megjegyzés" %}}

Érdemes megnézni a [Mérték szerinti licencelés](/slides/hu/java/metered-licensing/) oldalt.

{{% /alert %}} 


## **Licenc alkalmazása**

A licenc betölthető **fájlból** vagy **streame-ből**.

{{% alert color="info" title="Megjegyzés" %}}

Az Aspose.Slides a licencelési műveletekhez a [License](https://reference.aspose.com/slides/java/com.aspose.slides/license/) osztályt biztosítja.

{{% /alert %}} 

{{% alert color="warning" title="Figyelmeztetés" %}}

Az új licencek csak a 21.4-es vagy újabb verzióval aktiválhatók. A korábbi verziók más licencelési rendszert használnak, és nem ismerik fel ezeket a licenceket.

{{% /alert %}}

### **Fájl**

A legegyszerűbb licenc beállítási mód, ha a licencfájlt az Aspose.Slides.jar-t vagy az alkalmazás jar-ját tartalmazó mappában helyezi el.

Ez a Java kód megmutatja, hogyan állíts be egy licencfájlt:

``` java
// Példányosítja a License osztályt
com.aspose.slides.License license = new com.aspose.slides.License();

// Beállítja a licencfájl útvonalát
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" title="Figyelmeztetés" %}}

Ha a licencfájlt másik könyvtárba helyezi, a [setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.lang.String-) metódus hívásakor a megadott útvonal végén szereplő fájlnévnek meg kell egyeznie a licencfájl nevével.

Például megváltoztathatja a licencfájl nevét *Aspose.Slides.Java.lic.xml*-re. Ezután a kódban a [setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.lang.String-) metódusnak a *Aspose.Slides.Java.lic.xml*-re végződő útvonalat kell átadnia.

{{% /alert %}}

### **Stream**

Licenc betölthető streame-ből is. Ez a Java kód azt mutatja, hogyan alkalmazzunk licencet streame-ből:

``` java
// Példányosítja a License osztályt
com.aspose.slides.License license = new com.aspose.slides.License();

// Beállítja a licencet streame-ből
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

Ha a Aspose.Slides for PHP-t Java-n keresztül használja, licencet állíthat be egy PHP/Java hídon keresztül. Ez a híd lehetővé teszi, hogy Java osztályokat PHP szintaxisban használjon. További információkért lásd a [Licenc PHP-ben](/slides/hu/php-java/licensing/) oldalt.

## **Licenc ellenőrzése**

Annak ellenőrzéséhez, hogy a licenc helyesen lett-e beállítva, ellenőrizheti azt. Ez a Java kód megmutatja, hogyan validálhat egy licencet:

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

{{% alert color="warning" title="Figyelmeztetés" %}}

A [setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.io.InputStream-) metódus nem szálbiztos. Ha ezt a metódust egyszerre több szálból kell hívni, érdemes szinkronizációs primitíveket (például zárat) használni a problémák elkerülése érdekében.

{{% /alert %}}

## **GYIK**

### Alkalmazhatom a licencet teljesen offline környezetben (nincs internetkapcsolat)?

Igen. A licenc ellenőrzése helyben, a licencfájllal történik; internetkapcsolat nem szükséges.

### Mi történik, amikor az egyéves előfizetés lejár?

Nem. A licenc örökéletű: a feliratkozási dátum előtt kiadott verziókat továbbra is használhatja; csak a újabb kiadásokhoz megújítás szükséges.