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
description: "Ismerje meg, hogyan kell alkalmazni, kezelni és hibaelhárítani a licenceket az Aspose.Slides for Python via .NET-ben. Biztosítson folyamatos hozzáférést a teljes funkciókhoz lépésről lépésre útmutatónkkal a licencelésről."
---
## **Áttekintés**

Aspose.Slides használható értékelő módban vagy érvényes licencel. Az értékelő verzió ugyanazt a funkcionalitást biztosítja, mint a licencelt verzió, de minden mentett prezentáció minden diájára értékelő vízjelet helyez, és a prezentációkból a kód által olvasott szöveget levágja.

## **Az Aspose.Slides értékelése**

Az **Aspose.Slides for Python via .NET** értékelő verzióját letöltheti a [letöltési oldal](https://pypi.org/project/Aspose.Slides/)ról. Az értékelő verzió ugyanazokat a funkciókat biztosítja, mint a licencelt termék. Az értékelő csomag azonos a megvásárolt csomaggal, és licencessé válik, ha néhány kódsort hozzáad a licenc alkalmazásához.

Ha elégedett az **Aspose.Slides** értékelésével, akkor [licencet vásárolhat](https://purchase.aspose.com/pricing/slides/hu/python-net/). Javasoljuk, hogy tekintse át a rendelkezésre álló előfizetési lehetőségeket. Ha kérdése van, lépjen kapcsolatba az Aspose értékesítési csapatával.

Minden Aspose licenc egyéves előfizetést tartalmaz, amely ingyenes frissítéseket és a periódus alatt kiadott hibajavításokat biztosítja. A licencelt és az értékelő felhasználók egyaránt ingyenes, korlátlan technikai támogatást kapnak.

**Az értékelő verzió korlátozásai**

* Az értékelő verzió (ha nincs licenc alkalmazva) teljes funkcionalitást biztosít, de minden mentett prezentáció minden diájára egy értékelő vízjel szövegdobozt helyez.
* A prezentációból a kód által olvasott szöveg az első néhány karakterre lesz levágva, majd egy értesítés követi az értékelési korlátozásról. A kód által írt szöveg teljesen mentésre kerül.

{{% alert color="info" title="Note" %}}
Az Aspose.Slides korlátozások nélküli teszteléséhez kérhet **30 napos ideiglenes licencet**. A részletekért tekintse meg a [Hogyan szerezhet ideiglenes licencet](https://purchase.aspose.com/temporary-license) oldalt.
{{% /alert %}}

## **Licenckezelés az Aspose.Slides-ben**

* Az értékelő verzió licencessé válik, miután licencet vásárol, és néhány kódsort hozzáad a licenc alkalmazásához.
* A licenc egy egyszerű szöveges XML fájl, amely részleteket tartalmaz, például a termék neve, a lefedett fejlesztők száma, az előfizetés lejárati dátuma stb.
* A licencfájl digitálisan alá van írva, ezért nem szabad módosítani. Még egyetlen sortörés hozzáadása is érvényteleníti.
* Az Aspose.Slides for Python via .NET a licencet a megadott útvonalon keresi. A relatív útvonal vagy a útvonal nélküli fájlnév a jelenlegi munkakönyvtár alapján kerül feloldásra, amely nem feltétlenül az a mappa, amely a Python szkriptet tartalmazza.
* Az értékelési korlátozások elkerülése érdekében állítsa be a licencet az Aspose.Slides használata előtt. Alkalmazásonként vagy folyamatonként csak egyszer szükséges beállítani.

{{% alert color="info" title="Note" %}}
Érdemes lehet átnézni a [Mértékhez kötött licencelés](/slides/hu/python-net/metered-licensing/) oldalt.
{{% /alert %}}

## **Licenc alkalmazása**

A licenc betölthető egy **fájlból** vagy egy **folyamból**.

{{% alert color="info" title="Note" %}}
Az Aspose.Slides a [License](https://reference.aspose.com/slides/hu/python-net/aspose.slides/license/) osztályt biztosítja a licenckezeléshez.
{{% /alert %}}

{{% alert color="warning" title="Warning" %}}
Az új licenc csak a 21.4 vagy újabb verzióval aktiválja az Aspose.Slides-et. Korábbi verziók más licencelési rendszert használnak, és nem ismerik fel ezeket a licenceket.
{{% /alert %}}

### **Fájl**

A licenc beállításának legegyszerűbb módja, ha a licencfájl útvonalát átadja a [set_license](https://reference.aspose.com/slides/hu/python-net/aspose.slides/license/set_license/) metódusnak. Ha csak a fájlnevet adja meg, ahogy az alábbi példában is, az Aspose.Slides a fájlt a jelenlegi munkakönyvtárban keresi.

Az alábbi Python kód bemutatja, hogyan kell beállítani a licencfájlt:
```py
import aspose.slides as slides

# Létrehozza a License osztályt. 
license = slides.License()

# Beállítja a licencfájl elérési útját.
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" title="Warning" %}}
Ha a licencfájlt egy másik könyvtárba helyezi, a [License.set_license](https://reference.aspose.com/slides/hu/python-net/aspose.slides/license/set_license/#str) hívásakor a kifejezett útvonal végén szereplő fájlnévnek meg kell egyeznie a licencfájl nevével.

Például átnevezheti a licencfájlt *Aspose.Slides.lic.xml*-re. Ezután a kódban adja meg a teljes útvonalat a fájlhoz (a végén Aspose.Slides.lic.xml-vel), a [License.set_license](https://reference.aspose.com/slides/hu/python-net/aspose.slides/license/set_license/#str) metódusnak.
{{% /alert %}}

### **Folyam**

Licencet betölthet egy folyamról. Az alábbi Python példa bemutatja, hogyan lehet licencet alkalmazni egy folyam segítségével:
```py
import aspose.slides as slides

# Létrehozza a License osztályt.
license = slides.License()

# Licenc beállítása egy folyamról.
with open("Aspose.Slides.lic", "rb") as stream:
    license.set_license(stream)
```

## **Licenc ellenőrzése**

Annak ellenőrzésére, hogy a licenc helyesen lett-e alkalmazva, ellenőrizheti azt. Az alábbi Python kód bemutatja, hogyan lehet licencet ellenőrizni:
```py
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("License is good!")
```

## **Szálbiztonság**

{{% alert color="warning" title="Warning" %}}
A [License.set_license](https://reference.aspose.com/slides/hu/python-net/aspose.slides/license/set_license/) metódus nem szálbiztos. Ha több szálból kell egyszerre meghívni, használjon szinkronizációs primitívet, például `threading.Lock`-ot, a problémák elkerülése érdekében.
{{% /alert %}}

## **GYIK**

### Alkalmazhatom a licencet teljesen offline környezetben (nincs internetkapcsolat)?

Igen. A licenc ellenőrzése helyben, a licencfájl használatával történik; internetkapcsolat nem szükséges.

### Mi történik, ha az egyéves előfizetés lejár? Megszakad-e a könyvtár működése?

Nem. A licenc örökös: a előfizetés lejárati dátuma előtt kiadott verziókat továbbra is használhatja; csak a újabb kiadásokhoz újbóli megújítás szükséges.