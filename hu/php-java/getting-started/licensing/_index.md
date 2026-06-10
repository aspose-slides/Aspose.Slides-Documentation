---
title: Licencelés
type: docs
weight: 80
url: /hu/php-java/licensing/
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
- bemutató
- PHP
- Aspose.Slides
description: "Alkalmazza, kezelje és hibaelhárítsa a licenceket az Aspose.Slides for PHP via Java-ban. Biztosítsa a teljes funkciók megszakítás nélküli elérését lépésről lépésre útmutatónkkal."
---
## **Bevezetés**

Néha a legjobb értékelési eredmények elérése érdekében gyakorlati megközelítésre lehet szükség. Emiatt az Aspose.Slides különböző vásárlási csomagokat kínál, valamint egy Ingyenes Próbaverziót és egy 30 napos Ideiglenes Licencet a kiértékeléshez.

{{% alert color="primary" %}}
Vegye figyelembe, hogy számos általános irányelv és gyakorlat van, amelyek útmutatást adnak a termékeink kiértékeléséhez, megfelelő licenceléséhez és megvásárlásához. Ezeket a ["Vásárlási szabályzatok és GYIK"](https://purchase.aspose.com/policies) szekcióban találja.
{{% /alert %}}

## **Az Aspose.Slides kiértékelése**
Az Aspose.Slides könnyen letölthető kiértékeléshez. A kiértékelési csomag megegyezik a megvásárolt csomaggal. A kiértékelési verzió egyszerűen licencelté válik, miután néhány kódsort hozzáad a licenc alkalmazásához. 

## **A kiértékelési verzió korlátozása**
Az Aspose.Slides kiértékelési verziója (licenc megadása nélkül) a termék teljes funkcionalitását biztosítja, de egy kiértékelési vízjelet helyez a dokumentum tetejére megnyitáskor és mentéskor. Emellett egy diára korlátozódik a szöveg kinyerése a bemutató diákból.

{{% alert color="primary" %}} 
Ha az Aspose.Slides-t a kiértékelési verzió korlátozása nélkül szeretné tesztelni, kérhet egy **30 napos Ideiglenes Licencet**. További információkért tekintse meg a [Hogyan szerezhet Ideiglenes Licencet?](https://purchase.aspose.com/temporary-license) oldalt.
{{% /alert %}} 

## **A licencről**
Az Aspose.Slides PHP via Java kiértékelési verzióját egyszerűen letöltheti a [letöltési oldalról](https://packagist.org/packages/aspose/slides). A kiértékelési verzió **azonos képességeket** biztosít, mint az Aspose.Slides licencelt változata. Továbbá a kiértékelési verzió egyszerűen licencelté válik, miután megvásárol egy licencet és néhány kódsort hozzáad a licenc alkalmazásához.

A licenc egy egyszerű szöveges XML-fájl, amely a termék nevét, a licencelt fejlesztők számát, az előfizetés lejárati dátumát stb. tartalmazza. A fájl digitálisan alá van írva, ezért ne módosítsa. Még egy véletlenül hozzáadott sortörés is érvényteleníti a fájlt.

A kiértékelési verzióval kapcsolatos korlátoások elkerülése érdekében a **Aspose.Slides** használata előtt licencet kell beállítania. A licencet csak egyszer kell beállítani alkalmazásonként vagy folyamatonként.

{{% alert color="primary" %}}
Érdemes megtekinteni a [Mértékelt licencelés](https://docs.aspose.com/slides/hu/php-java/metered-licensing/) oldalt.
{{% /alert %}} 

## **Megvásárolt licenc**

Vásárlás után alkalmaznia kell a licencfájlt vagy -folyamot. 

{{% alert color="primary" %}}
Szükséges beállítani a licencet:
* csak egyszer alkalmazás domainként
* mielőtt bármely más Aspose.Slides osztályt használná
{{% /alert %}}

{{% alert color="primary" %}}
Az árinformációkat a [Ár információ](https://purchase.aspose.com/pricing/slides/hu/family) oldalon találhatja.
{{% /alert %}}

### **Licenc beállítása az Aspose.Slides for PHP via Java-ban**

A licencek az alábbi helyekről alkalmazhatók:

* Kifejezett útvonal
* Stream
* Metered License-ként – egy új licencelési mechanizmus

{{% alert color="primary" %}}
Használja a **setLicense** metódust egy komponens licenceléséhez.

Bár a **setLicense** több hívása nem árt, erőforrás-pazarlás (processzor).
{{% /alert %}}

{{% alert color="warning" %}}
Az új licencek csak a 21.4 vagy újabb verzióval aktiválhatják az Aspose.Slides-et. A régebbi verziók más licencelési rendszert használnak, és nem ismerik fel ezeket a licenceket.
{{% /alert %}}

#### **Licenc alkalmazása fájl használatával**

Ez a kódrészlet a licencfájl beállításához használható:

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense("Aspose.Slides.lic");
?>
```

A setLicense metódus hívásakor a licenc neve megegyező kell legyen a licencfájl nevével. Például a licencfájl nevét megváltoztathatja "Aspose.Slides.lic.xml"-re. Ezután a kódban át kell adnia az új licenc nevet (Aspose.Slides.lic.xml) a setLicense metódusnak.

#### **Licenc alkalmazása stream-ből**

Ez a kódrészlet a licenc stream-ből való alkalmazásához használható:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense($stream);
?>
```

## **GYIK**

**Alkalmazhatom a licencet teljesen offline környezetben (nincs internetkapcsolat)?**

Igen. A licenc ellenőrzése helyileg, a licencfájl használatával történik; internetkapcsolat nem szükséges.

**Mi történik, ha az egyéves előfizetés lejár? Leáll a könyvtár?**

Nem. A licenc örökös: a feliratkozás befejezési dátuma előtt kiadott verziókat továbbra is használhatja; csak az újabb kiadásokhoz licencet kell újítania.