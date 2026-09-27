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
- licenc ellenőrzése
- licencfájl
- kiértékelési verzió
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Alkalmazza, kezelje és hibaelhárítsa a licenceket a PHP (Java) számára készült Aspose.Slides-ben. Biztosítsa a teljes funkciók megszakítás nélküli elérését lépésről lépésre útmutatónkkal a licenceléshez."
---
## **Bevezetés**

Néha a legjobb kiértékelési eredmények eléréséhez gyakorlati megközelítésre lehet szükség. Emiatt az Aspose.Slides különböző vásárlási csomagokat kínál, valamint ingyenes próbaidőszakot és 30 napos Ideiglenes Licencet biztosít az értékeléshez.

{{% alert color="info" title="Note" %}}
Vegye figyelembe, hogy számos általános irányelv és gyakorlat segít abban, hogyan értékelje, megfelelően licencelje és vásárolja meg termékeinket. Ezeket megtalálja a ["Vásárlási irányelvek és GYIK"](https://purchase.aspose.com/policies) szakaszban.
{{% /alert %}}

## **Az Aspose.Slides kiértékelése**
Az Aspose.Slides-et egyszerűen letöltheti kiértékelés céljából. A kiértékelési csomag megegyezik a vásárolt csomaggal. A kiértékelési verzió egyszerűen licencelté válik, ha néhány kódsort hozzáad a licenc alkalmazásához.

## **A kiértékelési verzió korlátozása**
Az Aspose.Slides kiértékelési verziója (licenc nélkül) a teljes termékfunkciókat kínálja, két korlátozással:
* Minden mentett prezentáció közepére egy kiértékelési vízjel szövegdobozt tesz.
* A prezentációból a kód által beolvasott szöveg csak az első néhány karakterre van csonkolva, majd egy értesítés követi a kiértékelési korlátozásról. A kód által írt szöveg teljesen mentésre kerül.

{{% alert color="info" title="Note" %}}
Ha az Aspose.Slides-et a kiértékelési verzió korlátozása nélkül szeretné tesztelni, kérhet **30 napos Ideiglenes Licencet**. További információért lásd a [Hogyan lehet Ideiglenes Licencet szerezni?](https://purchase.aspose.com/temporary-license) oldalt.
{{% /alert %}} 

## **A licencről**
Az Aspose.Slides PHP (Java) kiértékelési verzióját egyszerűen letöltheti a [letöltési oldalról](https://packagist.org/packages/aspose/slides). A kiértékelési verzió **azonos képességeket** kínál, mint az Aspose.Slides licencelt verziója. Továbbá a kiértékelési verzió licencelté válik, ha megvásárol egy licencet és néhány kódsort hozzáad a licenc alkalmazásához.

A licenc egy egyszerű szöveges XML fájl, amely olyan részleteket tartalmaz, mint a termék neve, a licencelt fejlesztők száma, az előfizetés lejárati dátuma stb. A fájl digitálisan alá van írva, ezért ne módosítsa. Még egy véletlenül hozzáadott sortörés is érvényteleníti.

A kiértékelési verzióhoz kapcsolódó korlátozások elkerüléséhez licencet kell beállítania a **Aspose.Slides** használata előtt. A licencet csak egyszer kell beállítani alkalmazásonként vagy folyamatonként.

{{% alert color="info" title="Note" %}}
Érdemes megtekinteni a [Mérés alapú licenc](/slides/hu/php-java/metered-licensing/).
{{% /alert %}} 

## **Megvásárolt licenc**
Vásárlás után alkalmaznia kell a licencfájlt vagy -folyamot.

{{% alert color="info" title="Note" %}}
Be kell állítania a licencet:
* csak egyszer egy alkalmazási tartományon belül
* mielőtt bármely más Aspose.Slides osztályt használná
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Ár információkat a [Ár információ](https://purchase.aspose.com/pricing/slides/hu/family) oldalon találja.
{{% /alert %}}

### **Licenc beállítása az Aspose.Slides PHP (Java) verziójában**
Licenceket a következő helyekről lehet alkalmazni:
* Kifejezett útvonal
* Folyam
* Mint Mérés alapú licenc – egy új licencelési mechanizmus

{{% alert color="info" title="Note" %}}
Használja a **setLicense** metódust egy komponens licenceléséhez.

Bár a **setLicense** többszöri meghívása nem káros, felesleges erőforrás (processzor) felhasználás.
{{% /alert %}}

{{% alert color="warning" title="Warning" %}}
Az új licencek csak a 21.4 vagy újabb verzióval aktiválhatók az Aspose.Slides-ben. A régebbi verziók más licencelési rendszert használnak, és nem ismerik fel ezeket a licenceket.
{{% /alert %}}

#### **Licenc alkalmazása fájlból**
Ez a kódrészlet a licencfájl beállításához használható:

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/hu/lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense(__DIR__ . "/Aspose.Slides.lic");
```

A minta a licencfájl a szkript mellett létezését feltételezi, és az abszolút útvonalát adja át: az Aspose.Slides a Tomcat alatt fut, így nem oldja fel a relatív útvonalat a szkript mappája alapján. A setLicense metódus hívásakor a licenc neve meg kell, hogy egyezzen a licencfájl nevével. Például átnevezheti a licencfájlt „Aspose.Slides.lic.xml”-ra. Ezután a kódban a setLicense metódusnak ezt az új licencnevet (Aspose.Slides.lic.xml) kell átadni.

#### **Licenc alkalmazása folyamról**
Ez a kódrészlet a licenc folyamról történő alkalmazásához használható:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/hu/lib/aspose.slides.php");

use aspose\slides\License;

$stream = new Java("java.io.FileInputStream", __DIR__ . "/Aspose.Slides.lic");

$license = new License();
$license->setLicense($stream);

$stream->close();
```

## **GYIK**

### Alkalmazhatom a licencet teljesen offline környezetben (internetkapcsolat nélkül)?
Igen. A licenc ellenőrzése helyben történik a licencfájllal; internetkapcsolat nem szükséges.

### Mi történik, ha az egyéves előfizetés lejár? Leáll a könyvtár működése?
Nem. A licenc örökös: a feliratkozás lejárati dátuma előtt kiadott verziókat továbbra is használhatja; csak az újabb kiadásokhoz újra kell fizetnie.