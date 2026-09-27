---
title: Licencelés
type: docs
weight: 80
url: /hu/nodejs-java/licensing/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Alkalmazza, kezelje és hibaelhárítsa a licenceket az Aspose.Slides Node.js verziójában. Biztosítsa a folyamatos hozzáférést a teljes funkciókhoz lépésről lépésre útmutatónk segítségével."
---
## **Bevezetés**

Néha a legjobb értékelési eredményekhez gyakorlati megközelítésre lehet szükség. Ezért az Aspose.Slides különböző vásárlási terveket kínál, valamint ingyenes próbaverziót és 30 napos ideiglenes licencet biztosít az értékeléshez.

{{% alert color="info" title="Note" %}}
Vegye figyelembe, hogy több általános irányelv és gyakorlat segít abban, hogyan értékelje, megfelelően licencelje és vásárolja meg termékeinket. Ezeket megtalálja a ["Vásárlási irányelvek és GYIK"](https://purchase.aspose.com/policies) szakaszban.
{{% /alert %}}

## **Az Aspose.Slides értékelése**
Az Aspose.Slides könnyen letölthető értékelés céljából. Az értékelő csomag megegyezik a megvásárolt csomaggal. Az értékelő verzió egyszerűen licencelté válik, miután néhány kódsort hozzáad a licenc alkalmazásához.

## **Az értékelő verzió korlátozása**
Az Aspose.Slides értékelő verziója (licenc nélkül) a teljes termékfunkcionalitást biztosítja, két korláttal:
* Minden elmentett prezentáció minden diájára egy értékelési vízjel szövegdobozt ad hozzá.
* Az előadástól beolvasott, öt karakternél hosszabb szöveg az első öt karakterre vágásra kerül, majd a `... text has been truncated due to evaluation version limitation.` szöveg következik. Az öt vagy kevesebb karakteres szöveg változatlanul visszatér, és a kód által írt szöveg teljes egészében mentésre kerül.

{{% alert color="info" title="Note" %}}
Ha az Aspose.Slides-et az értékelő verzió korlátozása nélkül szeretné tesztelni, kérhet **30 napos ideiglenes licencet**. További információért tekintse meg a [Hogyan kérhet ideiglenes licencet?](https://purchase.aspose.com/temporary-license) oldalt.
{{% /alert %}}

## **A licencről**
Az Aspose.Slides Node.js (Java) értékelő verziója könnyen letölthető a [letöltési oldalról](https://releases.aspose.com/slides/hu/nodejs-java/). Az értékelő verzió ugyanazokkal a funkciókkal rendelkezik, mint a licencelt verzió, a fent leírt korlátozásokkal. Továbbá az értékelő verzió egyszerűen licencelté válik, miután megvásárol egy licencet és néhány kódsort hozzáad a licenc alkalmazásához.

A licenc egy egyszerű szöveges XML fájl, amely tartalmazza például a termék nevét, a licencelt fejlesztők számát, az előfizetés lejárati dátumát stb. A fájl digitálisan alá van írva, ezért ne módosítsa. Még egy véletlen sorvége hozzáadása is érvényteleníti.

Az értékelő verzió korlátozása elkerülése érdekében a **Aspose.Slides** használata előtt licencet kell beállítania. A licencet csak egyszer kell beállítani alkalmazáson vagy folyamatonként.

{{% alert color="info" title="Note" %}}
Érdekelheti a [Metered Licensing](/slides/hu/nodejs-java/metered-licensing/) oldal.
{{% /alert %}}

## **Megvásárolt licenc**
Vásárlás után a licenc fájlt vagy adatfolyamot kell alkalmaznia.

{{% alert color="info" title="Note" %}}
A licencet a következőképpen kell beállítani:
* csak egyszer folyamatonként
* mielőtt bármely más Aspose.Slides osztályt használna
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Az árazási információk a [“Pricing Information”](https://purchase.aspose.com/pricing/slides/hu/family) oldalon érhetők el.
{{% /alert %}}

### **Licenc beállítása az Aspose.Slides Node.js (Java) verzióban**
A licence-ek a következő helyekről alkalmazhatók:
* Kifejezett útvonal
* Adatfolyam
* Metered License‑ként – új licencelési mechanizmus

{{% alert color="info" title="Note" %}}
Használja a **setLicense** metódust egy komponens licencelésére.

Bár a **setLicense** többszöri hívása nem árt, erőforrás-pazarlás (processzor).
{{% /alert %}}

#### **Licenc alkalmazása fájlból**
Ez a kódrészlet egy licencfájl beállítására szolgál:

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");

const license = new asposeSlides.License();
license.setLicense("Aspose.Slides.lic");
console.log("The license was applied.");

// Az Aspose.Slides egy Java virtuális gépen fut, amely a Node.js‑t futtatva tartja, ezért explicit módon kell befejezni a folyamatot.
process.exit(0);
```

A setLicense metódus meghívásakor a licenc neve meg kell, hogy egyezzen a licencfájl nevével. Például megváltoztathatja a licencfájl nevét "Aspose.Slides.lic.xml"-re. Ezután a kódban az új licencnevet (Aspose.Slides.lic.xml) kell átadni a setLicense metódusnak. Ha a fájl hiányzik vagy nem tartalmaz érvényes licencet, a [setLicense](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/license/setlicense/) kivételt dob, ami hibával befejezi a szkriptet.

#### **Licenc alkalmazása adatfolyamból**
Licenc adatfolyamból történő alkalmazásához adja át a [License](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/license/) objektumot és egy olvasható adatfolyamot a statikus [setLicenseFromStream](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/license/setlicense/) metódusnak. Az adatfolyam aszinkron módon olvasódik, és a visszahívás hibát kap, ha az adatfolyam nem tartalmaz érvényes licencet:

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");

const license = new asposeSlides.License();
const readStream = fs.createReadStream("Aspose.Slides.lic");
asposeSlides.License.setLicenseFromStream(license, readStream, function (error) {
    if (error) {
        console.error("The license was not applied:", error.message);
    } else {
        console.log("The license was applied.");
    }

    // Az Aspose.Slides egy Java virtuális gépen fut, amely a Node.js‑t futtatva tartja, ezért explicit módon kell befejezni a folyamatot.
    process.exit(0);
});
```

A licenc akkor kerül alkalmazásra, amikor az egész adatfolyam be lett olvasva, közvetlenül a visszahívás előtt, ezért a többi Aspose.Slides műveletet a visszahívásból indítsa.

Mindkét minta a befejezéskor `process.exit(0)`‑t hív, mert a Aspose.Slides‑t futtató Java virtuális gép a Node.js‑t futtatva tartja. Alkalmazásban a folyamat befejezése helyett folytassa az Aspose.Slides kódját.

## **GYIK**

### Alkalmazhatom a licencet teljesen offline környezetben (internetkapcsolat nélkül)?
Igen. A licenc ellenőrzése helyben, a licencfájl segítségével történik; internetkapcsolat nem szükséges.

### Mi történik, ha az egyéves előfizetés lejár? Leáll a könyvtár működése?
Nem. A licenc örökös: továbbra is használhatja az előfizetés vége előtti verziókat; azonban az újabb kiadások használatához megújítás szükséges.