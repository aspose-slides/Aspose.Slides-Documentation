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
- licenc fájl
- értékelési verzió
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Alkalmazza, kezelje és hibaelhárítsa a licenceket az Aspose.Slides Node.js verziójában. Biztosítsa a teljes funkciók megszakítás nélküli elérését lépésről‑lépésre útmutatónkkal."
---
## **Bevezetés**

Néha a legjobb értékelési eredmények elérése érdekében gyakorlati megközelítésre lehet szükség. Emiatt az Aspose.Slides különféle vásárlási csomagokat kínál, valamint ingyenes próbaverziót és 30 napos ideiglenes licencet biztosít az értékeléshez.

{{% alert color="primary" %}}
Vegye figyelembe, hogy számos általános irányelv és gyakorlat segíti Önt abban, hogyan értékelje, licencelje megfelelően és vásárolja meg termékeinket. Ezeket megtalálja a [Vásárlási irányelvek és GYIK](https://purchase.aspose.com/policies) szakaszban.
{{% /alert %}}

## **Az Aspose.Slides értékelése**
Az Aspose.Slides könnyen letölthető értékelés céljából. Az értékelési csomag megegyezik a megvásárolt csomaggal. Az értékelési verzió egyszerűen licencelté válik, ha néhány kódsort hozzáad a licenc alkalmazásához. 

## **Az értékelési verzió korlátozása**
Az Aspose.Slides értékelési verziója (licenc megadása nélkül) a teljes termékfunkciókat biztosítja, de a dokumentum tetejére beilleszt egy értékelési vízjelet megnyitáskor és mentéskor. Emellett csak egy diára vagy korlátozva a szövegek kivonásakor a prezentáció diákból.

{{% alert color="primary" %}} 
Ha az Aspose.Slides-t a forgalmi verzió korlátozása nélkül szeretné tesztelni, kérhet egy **30 napos ideiglenes licencet**. További információért tekintse meg a [Hogyan szerezhet ideiglenes licencet?](https://purchase.aspose.com/temporary-license) oldalt.
{{% /alert %}} 

## **A licencről**
Az Aspose.Slides Node.js (Java) értékelési verzióját könnyen letöltheti a [letöltési oldalról](https://releases.aspose.com/slides/hu/nodejs-java/). Az értékelési verzió **teljes mértékben ugyanazokat a képességeket** biztosítja, mint az Aspose.Slides licencelt verziója. Továbbá az értékelési verzió egyszerűen licencelté válik, ha megvásárol egy licencet és néhány kódsort hozzáad a licenc alkalmazásához.

A licenc egy egyszerű szöveges XML-fájl, amely olyan adatokat tartalmaz, mint a termék neve, a licencelt fejlesztők száma, a feliratkozás lejárati dátuma stb. A fájl digitálisan alá van írva, ezért ne módosítsa. Még egy véletlenül hozzáadott sortörés is érvényteleníti a fájlt.

Az értékelési verzióval járó korlátozások elkerülése érdekében licencet kell beállítania a **Aspose.Slides** használata előtt. A licencet csak egyszer kell beállítania alkalmazáson vagy folyamatonként.

{{% alert color="primary" %}} 
Érdemes megtekinteni a [Mérték szerinti licencelést](https://docs.aspose.com/slides/hu/nodejs-java/metered-licensing/).
{{% /alert %}} 

## **Megvásárolt licenc**

Vásárlás után alkalmaznia kell a licencfájlt vagy -folyamot. 

{{% alert color="primary" %}}
Szükséges beállítani a licencet:
* csak egyszer az alkalmazás domainjén belül
* bármely más Aspose.Slides osztály használata előtt
{{% /alert %}}

{{% alert color="primary" %}}
Az árakra vonatkozó információkat megtalálja a [„Ár információ”](https://purchase.aspose.com/pricing/slides/hu/family) oldalon.
{{% /alert %}}

### **Licenc beállítása az Aspose.Slides Node.js esetén Java használatával**

A licencek a következő helyekről alkalmazhatók:

* Kifejezett útvonal
* Áramlás
* Metered licencként – új licencelési mechanizmus

{{% alert color="primary" %}}
Használja a **setLicense** metódust egy komponens licenceléséhez.

Bár a **setLicense** többszörös meghívása nem árt, erőforrás-pazarlás (processzor).
{{% /alert %}}

{{% alert color="warning" %}}
Az új licencek csak a 21.4 vagy újabb verzióval aktiválhatják az Aspose.Slides-t. A korábbi verziók más licencelési rendszert használnak, ezért nem ismerik fel ezeket a licenceket.
{{% /alert %}}

#### **Licenc alkalmazása fájlból**

Ez a kódrészlet a licencfájl beállításához használható:

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();
license.setLicense("Aspose.Slides.lic");
```

A setLicense metódus hívásakor a licenc neve megegyező kell legyen a licencfájl nevével. Például a licencfájl nevét megváltoztathatja "Aspose.Slides.lic.xml"-ra. Ezután a kódban a új licenc nevet (Aspose.Slides.lic.xml) kell átadni a setLicense metódusnak.

#### **Licenc alkalmazása áramlásból**

Ez a kódrészlet licenc áramlásból való alkalmazásához használható:

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();

var fs = require("fs");

var readStream = fs.createReadStream("Aspose.Slides.lic");

license.setLicense(readStream, function(err, list) {
    if(err) { 
        console.error(err); return; 
    }});
```

## **GYIK**

**Alkalmazhatom a licencet teljesen offline környezetben (nincs internetkapcsolat)?**

Igen. A licenc ellenőrzése helyileg történik a licencfájl használatával; internetkapcsolat nem szükséges.

**Mi történik, ha az egyéves előfizetés lejár? Leáll a könyvtár működése?**

Nem. A licenc örökös: továbbra is használhatja az előfizetési dátum előtt kiadott verziókat; azonban új kiadásokat csak megújítás után vehet igénybe.