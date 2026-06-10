---
title: Licencelés
type: docs
weight: 80
url: /hu/python-net/licensing/
keywords:
- licenc
- ideiglenes licenc
- licenc beállítása
- licenc használata
- licenc ellenőrzése
- licencfájl
- értékelő verzió
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan kell alkalmazni, kezelni és hibaelhárítani a licenceket az Aspose.Slides for Python via .NET-ben. Biztosítsa a teljes funkciók megszakítás nélküli elérését lépésről lépésre útmutatónk segítségével."
---
## **Áttekintés**

Az Aspose.Slides használható értékelő módban vagy érvényes licenccel. Az értékelő verzió ugyanazt a funkcionalitást kínálja, mint a licencelt verzió, de értékelő vízjelet ad a prezentációk megnyitásakor vagy mentésekor, és korlátozza a szövegkinyerést egy diára.

## **Az Aspose.Slides értékelése**

Letöltheti a **Aspose.Slides for Python via .NET** értékelő verzióját a [letöltési oldalról](https://pypi.org/project/Aspose.Slides/). Az értékelő verzió ugyanazokat a funkciókat biztosítja, mint a licencelt termék. Az értékelő csomag azonos a megvásárolt csomaggal, és a licenc alkalmazására néhány kódsor hozzáadása után licencelté válik.

Amikor elégedett az **Aspose.Slides** értékelésével, [licencet vásárolhat](https://purchase.aspose.com/buy). Javasoljuk, hogy tekintse át a rendelkezésre álló előfizetési lehetőségeket. Ha kérdése van, forduljon az Aspose értékesítési csapathoz.

Minden Aspose licenc egy éves előfizetést tartalmaz, amely ingyenes frissítéseket és az időszak alatt kiadott hibajavításokat biztosít az új verziókra. A licencelt és az értékelő felhasználók egyaránt ingyenes, korlátlan technikai támogatást kapnak.

**Az értékelő verzió korlátai**

* Bár az Aspose.Slides értékelő verzió (licenc hiányában) teljes funkcionalitást biztosít, minden megnyitáskor vagy mentéskor értékelő vízjelet tesz a dokumentum tetejére.
* Prezentáció szövegkivonásakor egy diára van korlátozva.

{{% alert color="primary" %}}
Az Aspose.Slides korlátok nélküli teszteléséhez kérhet **30 napos ideiglenes licencet**. A részletekért tekintse meg a [Hogyan kérhet ideiglenes licencet](https://purchase.aspose.com/temporary-license) oldalt.
{{% /alert %}}

## **Licencelés az Aspose.Slides-ben**

* Az értékelő verzió licencelté válik, miután megvásárol egy licencet, és néhány kódsort hozzáad a alkalmazásához.
* A licenc egy egyszerű szöveges XML fájl, amely tartalmazza a termék nevét, a lefedett fejlesztők számát, az előfizetés lejárati dátumát és egyebeket.
* A licencfájl digitálisan alá van írva, ezért nem szabad módosítani. Még egyetlen sortörés hozzáadása is érvényteleníti.
* Az Aspose.Slides for Python via .NET általában ezeken a helyeken keres licencet:
  * Az Ön által megadott explicit útvonal
  * Az a mappa, amely tartalmazza a Python szkriptet, amely meghívja az Aspose.Slides for Python via .NET‑et
* Az értékelő korlátok elkerülése érdekében állítsa be a licencet az Aspose.Slides használata előtt. Ezt csak egyszer kell megtenni alkalmazásonként vagy folyamatként.

{{% alert color="primary" %}}
Lehet, hogy szeretné áttekinteni a [Metered Licensing](/slides/hu/python-net/metered-licensing/) oldalt.
{{% /alert %}}

## **Licenc alkalmazása**

A licenc betölthető **fájlból**, **folyam** vagy **beágyazott erőforrásból**.

{{% alert color="primary" %}}
Az Aspose.Slides biztosítja a licenckezeléshez a [License](https://reference.aspose.com/slides/hu/python-net/aspose.slides/license/) osztályt.
{{% /alert %}}

{{% alert color="warning" %}}
Az új licencek csak a 21.4 vagy újabb verzióval aktiválhatók az Aspose.Slides-ben. A korábbi verziók más licencelési rendszert használnak, és nem ismerik fel ezeket a licenceket.
{{% /alert %}}

### **Fájl**

A licenc beállításának legegyszerűbb módja, ha a licencfájlt a komponens DLL‑jével azonos mappába helyezi, és csak a fájlnevet adja meg (útvonal nélkül).

Az alábbi Python kód bemutatja, hogyan állítható be a licencfájl:

```py
import aspose.slides as slides

# Példányosítja a License osztályt. 
license = slides.License()

# Beállítja a licencfájl elérési útvonalát. 
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" %}}
Ha a licencfájlt egy másik könyvtárba helyezi, a [License.set_license()](https://reference.aspose.com/slides/hu/python-net/aspose.slides/license/set_license/#str) hívásakor az explicit útvonal végén szereplő fájlnévnek meg kell egyeznie a licencfájl nevével.

Például átnevezheti a licencfájlt *Aspose.Slides.lic.xml*-ra. Ezután a kódban adja meg a teljes útvonalat a fájlhoz (amely Aspose.Slides.lic.xml‑re végződik) a [License.set_license()](https://reference.aspose.com/slides/hu/python-net/aspose.slides/license/set_license/#str) metódusnak.
{{% /alert %}}

### **Folyam**

A licenc betölthető egy folyam (stream) segítségével. Az alábbi Python példa bemutatja, hogyan alkalmazzon licencet folyamról:

```py
import aspose.slides as slides

# Példányosítja a License osztályt.
license = slides.License()

# Beállítja a licencet egy folyamról.
license.set_license(stream)
```

## **Licenc ellenőrzése**

A licenc helyes alkalmazásának ellenőrzéséhez validálhatja azt. Az alábbi Python kód bemutatja, hogyan validálja a licencet:

```py
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("License is good!")
```

## **Szálbiztonság**

{{% alert title="Note" color="warning" %}}
A [License.set_license](https://reference.aspose.com/slides/hu/python-net/aspose.slides/license/) metódusok nem szálbiztosak. Ha több szálból kell egyszerre meghívni őket, használjon szinkronizációs primitíveket (pl. `threading.Lock`) a problémák elkerülése érdekében.
{{% /alert %}}

## **GYIK**

**Alkalmazhatom a licencet teljesen offline környezetben (internetkapcsolat nélkül)?**

Igen. A licenc ellenőrzése helyben történik a licencfájl használatával; internetkapcsolat nem szükséges.

**Mi történik, amikor az egyéves előfizetés lejár? Leáll a könyvtár?**

Nem. A licenc örökös: továbbra is használhatja a feliratkozása lejárta előtti kiadott verziókat; azonban az újabb kiadásokat csak megújítás után használhatja.