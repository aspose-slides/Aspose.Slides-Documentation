---
title: Licencelés
description: "Az Aspose.Slides for Python via Java különböző vásárlási terveket kínál, vagy ingyenes próba és 30 napos ideiglenes licencet biztosít az értékeléshez a Licencelési és Előfizetési szabályzatok használatával."
type: docs
weight: 80
url: /hu/python-java/licensing/
---
Néha a legjobb értékelési eredményekhez gyakorlati megközelítésre lehet szükség. Ezért az Aspose.Slides különböző vásárlási csomagokat kínál, valamint ingyenes próbaverziót és 30 napos ideiglenes licencet biztosít az értékeléshez.

{{% alert color="primary" %}}
Vegye figyelembe, hogy számos általános irányelv és gyakorlat van, amely segít az értékelésben, a megfelelő licencelésben és termékeink megvásárlásában. Ezeket megtalálja a ["Vásárlási irányelvek és GYIK"](https://purchase.aspose.com/policies) szakaszban.
{{% /alert %}}

## **Az Aspose.Slides értékelése**
Az Aspose.Slides-et könnyen letöltheti értékelés céljából. Az értékelési csomag megegyezik a vásárolt csomaggal. Az értékelési verzió egyszerűen licencessé válik, miután néhány kódsort hozzáad a licenc alkalmazásához. 

## **Az értékelési verzió korlátozása**
Az Aspose.Slides (licenc nélküli) értékelési verziója a teljes termékfunkciókat biztosítja, de a dokumentum tetejére értékelési vízjelet helyez meg megnyitáskor és mentéskor. A bemutató diák szövegeinek kinyerése esetén csak egy diára van korlátozva.

{{% alert color="primary" %}} 
Ha az Aspose.Slides-et az értékelési verzió korlátozása nélkül szeretné tesztelni, kérhet **30 napos ideiglenes licencet**. További információért tekintse meg a [Hogyan szerezhet ideiglenes licencet?](https://purchase.aspose.com/temporary-license) oldalt.
{{% /alert %}} 

## **A licencről**
Az Aspose.Slides for Python via Java értékelési verzióját könnyen letöltheti a [letöltési oldalról](https://releases.aspose.com/slides/hu/python-java/). Az értékelési verzió teljesen **ugyanazokat a képességeket** kínálja, mint az Aspose.Slides licencelt verziója. Ráadásul az értékelési verzió egyszerűen licencessé válik, miután megvásárol egy licencet és néhány kódsort hozzáad a licenc alkalmazásához.

A licenc egy egyszerű szöveges XML fájl, amely olyan részleteket tartalmaz, mint a termék neve, a licencelt fejlesztők száma, az előfizetés lejárati dátuma stb. A fájl digitálisan alá van írva, ezért ne módosítsa. Még egy véletlen új sor hozzáadása a fájl tartalmához is érvényteleníti azt.

Az értékelési verzióval járó korlátozások elkerülése érdekében licencet kell beállítania a **Aspose.Slides** használata előtt. A licencet csak egyszer kell beállítani alkalmazásonként vagy folyamathoz.

## **Megvásárolt licenc**

Vásárlás után alkalmaznia kell a licencfájlt vagy -folyamot. 

{{% alert color="primary" %}}
Be kell állítania a licencet:
* csak egyszer az alkalmazás domainjében
* mielőtt bármely más Aspose.Slides osztályt használná
{{% /alert %}}

{{% alert color="primary" %}}
Ár információkat a [“Ár információk”](https://purchase.aspose.com/pricing/slides/hu/family) oldalon talál.
{{% /alert %}}

### **Licence beállítása az Aspose.Slides for Python via Java‑ban**

A licenceket az alábbi helyekről lehet alkalmazni:
* Kifejezett útvonal
* Folyam
* Metered licencként – egy új licencelési mechanizmus

{{% alert color="primary" %}}
Használja a **setLicense** metódust egy komponens licenceléséhez.

Bár a **setLicense** több hívása nem káros, csak feleslegesen terheli a rendszert (processzort).
{{% /alert %}}

{{% alert color="warning" %}}
Az új licencek csak a 21.4 vagy újabb verziójú Aspose.Slides-ot aktiválják. A korábbi verziók más licencelési rendszert használnak, és nem ismerik fel ezeket a licenceket.
{{% /alert %}}

#### **Licenc alkalmazása fájlból**

Ez a kódrészlet a licencfájl beállításához használható:

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
pres = Presentation()
license.setLicense("Aspose.Slides.lic");

jpype.shutdownJVM()
```

A setLicense metódus meghívásakor a licenc neve megegyező kell legyen a licencfájl nevével. Például megváltoztathatja a licencfájl nevét „Aspose.Slides.lic.xml”-ra. Ezután a kódban át kell adnia az új licencnevet (Aspose.Slides.lic.xml) a setLicense metódusnak.

#### **Licenc alkalmazása bájtokból**

Ez a kódrészlet a licenc bájtokból történő alkalmazásához használható:

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
input = open("Aspose.Slides.lic", mode="rb")
data = input.read()
pres = Presentation()
license.setLicenseFromBytes(data);

jpype.shutdownJVM()
```

#### **Metered licenc alkalmazása**

Az Aspose.Slides lehetővé teszi a fejlesztőknek, hogy metered kulcsot alkalmazzanak. Ez egy új licencelési mechanizmus.

Az új licencelési mechanizmus a meglévő licencelési móddal együtt kerül használatra. Azok az ügyfelek, akik az API funkciók használata alapján szeretnének számlázást kapni, a Metered licencelést választhatják.

A szükséges lépések befejezése után a kulcsokat kapja meg, nem pedig a licencfájlt. Ezt a metered kulcsot a kifejezetten erre a célra bevezetett **Metered** osztály segítségével lehet alkalmazni.

A következő kódrészlet bemutatja, hogyan állíthatók be a metered nyilvános és privát kulcsok:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, Metered, SaveFormat

# Hozzon létre egy példányt a CAD Metered osztályból
metered = Metered();

# Hozzáfér a set_metered_key tulajdonsághoz, és átadja a nyilvános és privát kulcsokat paraméterként
metered.setMeteredKey("*****", "*****");

# Kérdezze le a metered adat mennyiségét az API hívása előtt
amountbefore = Metered.getConsumptionQuantity()

# Információk kiíratása
print("Amount Consumed Before: \" + amountbefore + \"" )

# Betölti a dokumentumot a lemezről.
pres = Presentation();

# Lekéri a dokumentum oldalszámát
print("Amount Consumed After: \" +  pres.getSlides().size()) + \"" )

# Mentés PDF-ként
pres.save("out_pdf.pdf", SaveFormat.Pdf);

# Kérdezze le a metered adat mennyiségét az API hívása után
amountafter = Metered.getConsumptionQuantity()

# Információk kiíratása
print("Amount Consumed After: \" + amountafter + \"" )

jpype.shutdownJVM()
```

{{% alert color="primary" %}}
Kérjük, vegye figyelembe, hogy a Metered licenc helyes használatához stabil internetkapcsolatra van szükség, mivel a Metered mechanizmus folyamatosan kommunikál szolgáltatásainkkal a pontos számítások érdekében. További részletekért tekintse meg a [“Metered licenc GYIK”](https://purchase.aspose.com/faqs/licensing/metered) részt.
{{% /alert %}}