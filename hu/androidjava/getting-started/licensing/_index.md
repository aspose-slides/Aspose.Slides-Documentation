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
- értékelő verzió
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Alkalmazza, kezelje és hibakeresse a licenceket az Aspose.Slides for Android via Java-ban. Biztosítsa a teljes funkcionalitás folyamatos elérését licencelési útmutatónkkal."
---
## **Áttekintés**

Az Aspose.Slides értékelő módban vagy érvényes licencsel használható. Az értékelő verzió ugyanazt a funkcionalitást biztosítja, mint a licencelt verzió, de egy értékelő vízjelet helyez el a prezentációk megnyitásakor vagy mentésekor, és korlátozza a szövegkinyerést egy diára.

Ez a cikk elmagyarázza, hogyan működik a licencelés az Aspose.Slides-ben, és hogyan lehet licencet alkalmazni a könyvtár használata előtt. A licenc betölthető fájlból, stream‑ből vagy beágyazott erőforrásból a `License` osztály használatával. A cikk bemutatja továbbá, hogyan lehet ellenőrizni, hogy a licenc helyesen lett‑e alkalmazva.

## **Az Aspose.Slides értékelése**

{{% alert color="primary" %}} 

Letöltheti a **Aspose.Slides for Android via Java** értékelő verzióját a [letöltési oldalról](https://releases.aspose.com/slides/hu/androidjava/). Az értékelő verzió ugyanazokat a funkciókat nyújtja, mint a termék licencelt változata. Az értékelő csomag megegyezik a megvásárolt csomaggal. Az értékelő verzió egyszerűen licencessé válik, ha néhány kódsort hozzáad (a licenc alkalmazásához).

Miután megelégedett az **Aspose.Slides** értékelésével, megvásárolhatja a [licencet](https://purchase.aspose.com/buy). Javasoljuk, hogy tekintse át a különböző előfizetéstípusokat. Ha kérdései vannak, vegye fel a kapcsolatot az Aspose értékesítési csapatával.

Minden Aspose licenc egy éves előfizetést tartalmaz, amely ingyenes frissítéseket biztosít az előfizetési időszakban megjelenő új verziókra vagy javításokra. A licencelt termékek (vagy akár az értékelő verziók) felhasználói ingyenes és korlátlan technikai támogatást kapnak.

{{% /alert %}} 

**Az értékelő verzió korlátozásai**

* Bár az Aspose.Slides értékelő verziója (licenc megadása nélkül) a teljes termékfunkcionalitást biztosítja, megnyitáskor és mentéskor az dokumentum tetejére értékelő vízjelet helyez.
* A prezentációs diák szövegének kinyerésekor csak egy diára korlátozódik.

{{% alert color="primary" %}} 

Az Aspose.Slides korlátozások nélküli teszteléséhez kérhet **30 napos ideiglenes licencet**. További információkért tekintse meg a [Hogyan szerezhet ideiglenes licencet](https://purchase.aspose.com/temporary-license) oldalt.

{{% /alert %}}

## **Licencelés az Aspose.Slides-ben**

* Az értékelő verzió licencessé válik, miután megvásárolta a licencet és néhány kódsort hozzáad (a licenc alkalmazásához).
* A licenc egy egyszerű szöveges XML fájl, amely részleteket tartalmaz, például a termék nevét, a licencelt fejlesztők számát, az előfizetés lejárati dátumát stb.
* A licencfájl digitálisan alá van írva, ezért nem szabad módosítani. Még egy véletlen sorvége hozzáadása a fájl tartalmához is érvényteleníti azt.
* Az Aspose.Slides for Android via Java általában ezeken a helyeken keresi a licencet:
  * Egy explicit útvonal
  * Az Aspose.Slides.jar‑t tartalmazó mappa
* Az értékelő verzióval járó korlátozások elkerülése érdekében a **Aspose.Slides** használata előtt be kell állítania egy licencet. A licencet csak egyszer kell beállítani alkalmazásonként vagy folyamatonként.

## **Licenc alkalmazása**

A licenc betölthető **fájlból** vagy **stream‑ből**.

{{% alert color="primary" %}}

Az Aspose.Slides biztosítja a [License](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/license/) osztályt a licencelési műveletekhez.

{{% /alert %}} 

{{% alert color="warning" %}}

Új licencek csak a 21.4‑es vagy újabb verzióval aktiválhatók az Aspose.Slides-ben. A korábbi verziók más licencelési rendszert használnak, és nem ismerik fel ezeket a licenceket.

{{% /alert %}}

### **Fájl**

A licenc beállításának legegyszerűbb módja, ha a licencfájlt az Aspose.Slides.jar‑t vagy az alkalmazás jar‑ját tartalmazó mappába helyezi.

Ez a Java kód bemutatja, hogyan állíthat be egy licencfájlt:

``` java
// Létrehozza a License osztályt
com.aspose.slides.License license = new com.aspose.slides.License();

// Beállítja a licencfájl útvonalát
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" %}} 

Ha a licencfájlt más könyvtárba helyezi, a [SetLicense](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) metódus hívásakor a megadott explicit útvonal végén lévő licencfájl neve meg kell egyezzen a saját licencfájljával.

Például megváltoztathatja a licencfájl nevét *Aspose.Slides.Android.via.Java.lic.xml*-ra. Ezután a kódban a fájl elérési útját (amely *Aspose.Slides.Android.via.Java.lic.xml*-re végződik) kell átadni a [SetLicense](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) metódusnak.

{{% /alert %}}

### **Stream**

Licenc betölthető egy stream‑ből. Ez a Java kód bemutatja, hogyan alkalmazhat licencet egy stream‑ből:

``` java
// Létrehozza a License osztályt
com.aspose.slides.License license = new com.aspose.slides.License();

// Beállítja a licencet egy streamen keresztül
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

## **Licenc ellenőrzése**

Annak ellenőrzésére, hogy a licenc megfelelően lett‑e beállítva, validálhatja azt. Ez a Java kód bemutatja, hogyan validálhat egy licencet:

```java
License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Szálbiztonság**

{{% alert title="Note" color="warning" %}} 

A [SetLicense](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) metódus nem szálbiztos. Ha ezt a metódust egyszerre több szálból kell meghívni, érdemes szinkronizációs primitíveket (például zárat) használni a problémák elkerülése érdekében. 

{{% /alert %}}

## **GYIK**

**Alkalmazhatom a licencet teljesen offline környezetben (nincs internetkapcsolat)?**

Igen. A licencvalidálás helyben történik a licencfájl használatával; internetkapcsolat nem szükséges.

**Mi történik, amikor az egyéves előfizetés lejár? Megszűnik a könyvtár működése?**

Nem. A licenc örökös: továbbra is használhatja a előfizetés lejárata előtti kiadott verziókat; azonban az újabb kiadások használatához megújítás szükséges.