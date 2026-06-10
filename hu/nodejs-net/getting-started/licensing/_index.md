---
title: Licencelés
description: "Az Aspose.Slides Node.js (via .NET) különböző vásárlási csomagokat kínál, illetve ingyenes próbaidőszakot és 30 napos ideiglenes licencet biztosít a kiértékeléshez a Licencelés és Előfizetés szabályzatok használatával."
type: docs
weight: 80
url: /hu/nodejs-net/licensing/
---
Néha a legjobb kiértékelési eredmények eléréséhez gyakorlati megközelítésre lehet szükség. Emiatt az Aspose.Slides különböző vásárlási csomagokat kínál, valamint ingyenes próbaidőszakot és 30 napos ideiglenes licencet biztosít a kiértékeléshez.

{{% alert color="primary" %}}
Fontos megjegyezni, hogy több általános irányelv és gyakorlat létezik, amely segít a termékeink kiértékelésében, megfelelő licencelésében és megvásárlásában. Ezeket a ["Vásárlási irányelvek és GYIK"](https://purchase.aspose.com/policies) részben találja meg.
{{% /alert %}}

## **Az Aspose.Slides kiértékelése**
Az Aspose.Slides könnyen letölthető kiértékelés céljából. A kiértékelési csomag megegyezik a megvásárolt csomaggal. A kiértékelési verzió egyszerűen licencszerűvé válik, ha néhány kódsort hozzáad a licenc alkalmazásához.

## **A kiértékelési verzió korlátozása**
Az Aspose.Slides (licenc nélkül) kiértékelési verziója teljes funkcionalitást nyújt, de a dokumentum megnyitásakor és mentésekor egy kiértékelési vízjelet helyez a felső részre. Emellett a prezentációs diák szövegének kinyerésekor csak egy diára korlátozódik.

{{% alert color="primary" %}} 
Ha az Aspose.Slides korlátozások nélkül szeretné tesztelni, kérhet **30 napos ideiglenes licencet**. További információkért tekintse meg a [Hogyan szerezhető ideiglenes licenc?](https://purchase.aspose.com/temporary-license) oldalt.
{{% /alert %}} 

## **A licence szerepe**
Az Aspose.Slides Node.js (via .NET) kiértékelési verzióját egyszerűen letöltheti a [letöltési oldalról](https://releases.aspose.com/slides/hu/nodejs-net/). A kiértékelési verzió **azonos képességeket** biztosít, mint a licencelt változat. Ráadásul a kiértékelési verzió licencszerűvé válik, ha megvásárol egy licencet és néhány kódsort hozzáad a licenc alkalmazásához.

A licenc egy egyszerű szöveges XML-fájl, amely tartalmazza a termék nevét, a licencelt fejlesztők számát, az előfizetés lejárati dátumát stb. A fájl digitálisan alá van írva, ezért ne módosítsa. Még egy felesleges sortörés is érvényteleníti.

A kiértékelési verzió korlátaival szemben a **Aspose.Slides** használata előtt licencet kell beállítania. Az alkalmazáson vagy folyamatonként csak egyszer szükséges licencet beállítani.

## Licenc vásárlása után

A vásárlás után alkalmaznia kell a licencfájlt vagy -folyamot. 

{{% alert color="primary" %}}
A licencet a következő esetekben kell beállítani:
* csak egyszer az alkalmazás domainjében
* mielőtt bármely más Aspose.Slides osztályt használna
{{% /alert %}}

{{% alert color="primary" %}}
Az árakra vonatkozó információkat a [“Ár információ”](https://purchase.aspose.com/pricing/slides/hu/family) oldalon tekintheti meg.
{{% /alert %}}

### **Licenc beállítása az Aspose.Slides Node.js (via .NET) környezetben**

A licencet a következő helyekről lehet alkalmazni:

* Kifejezett útvonal
* Stream
* Metered licenc – új licencelési mechanizmus

{{% alert color="primary" %}}
A **setLicense** metódust kell használni egy összetevő licenceléséhez.

Bár a **setLicense** többszöri hívása nem árt, felesleges erőforrás‑(processzor‑)használatot eredményez.
{{% /alert %}}

{{% alert color="warning" %}}
Az új licencek csak a 21.4-es vagy újabb verzióval aktiválják az Aspose.Slides‑t. A korábbi verziók más licencelési rendszert használnak, és nem ismerik fel ezeket a licenceket.
{{% /alert %}}

#### **Licenc alkalmazása fájlból**

Ez a kódrészlet a licencfájl beállításához használható:

**Node.js**

```javascript
// Importálja az Aspose.Slides modult a PowerPoint fájlok manipulálásához
const asposeSlides = require('aspose.slides.via.net');

// Ez a függvény beállítja az Aspose.Slides könyvtárat licenccel
function setupAsposeSlidesLicense() {
	
    // Inicializálja a License osztályt az Aspose.Slides modulból
    var license = new asposeSlides.License();
    
    // Alkalmazza a licencet egy fájlból
    // Cserélje le a "your_license_file.lic"‑t a saját licencfájlja útvonalára
    license.setLicense("your_license_file.lic");
}

// Futtassa a függvényt az Aspose.Slides licenc beállításához
setupAsposeSlidesLicense();
```
{{% alert color="primary" %}}
A setLicense metódus hívásakor a licenc neve megegyező kell legyen a licencfájl nevével. Például megváltoztathatja a licencfájl nevét „Aspose.Slides.lic.xml”-re. Ezután a kódban a setLicense metódusnak a új licencnevet (Aspose.Slides.lic.xml) kell átadnia.
{{% /alert %}}