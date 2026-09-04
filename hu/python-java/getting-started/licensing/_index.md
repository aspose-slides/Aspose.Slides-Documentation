---
title: Licencelés
type: docs
weight: 80
url: /hu/python-java/licensing/
keywords:
- Aspose.Slides
- Python
- Java
- licencfájl
- ideiglenes licenc
- mérő alapú licencelés
- értékelési korlátozások
description: "Alkalmazzon fájlból, bájt alapú vagy mérő licencet az Aspose.Slides for Python via Java-ban, és távolítsa el az értékelési korlátozásokat alkalmazásaiból."
---
## **Áttekintés**

Az Aspose.Slides for Python via Java futtatható értékelő módban vagy licence-szel. Ez a cikk elmagyarázza, hogyan alkalmazzunk licence-t fájlból vagy bájtokból, és hogyan konfiguráljuk a mérő alapú licencelést.

A vásárlási lehetőségekért tekintse meg a [Árazási információkat](https://purchase.aspose.com/pricing/slides/hu/family). Általános licencelési és vásárlási kérdések esetén tekintse meg a [Vásárlási irányelveket és GYIK-et](https://purchase.aspose.com/policies).

Az értékelési korlátozásokért és a ideiglenes licence kérésének módjáért tekintse meg a [Aspose.Slides értékelése](/slides/hu/python-java/evaluate-aspose-slides/). Egy ideiglenes licence-t ugyanúgy alkalmazzon, mint egy megvásárolt licence-fájlt.

## **A licence-ről**

Egy licence-fájl információkat tartalmaz, mint például a termék neve, a licencelt fejlesztők száma és az előfizetés lejárati dátuma. A fájl digitálisan aláírt XML.

{{% alert color="warning" title="Warning" %}}
Ne módosítsa a licence-fájlt. Még egy felesleges sortörés is érvénytelenítheti a digitális aláírását.
{{% /alert %}}

A licence-t egyszer kell alkalmazni alkalmazásonként vagy folyamatonként, a prezentációk létrehozása vagy egyéb Aspose.Slides műveletek előtt. Licence-fájlhoz használja a [License](https://reference.aspose.com/slides/hu/python-java/aspose.slides/license/) osztályt. A mérő alapú licencelés nyilvános és privát kulcspárt használ a licence-fájl helyett.

## **Licence alkalmazása**

A következő példák feltételezik, hogy az Aspose.Slides for Python via Java és előfeltételei telepítve vannak. Minden példa egy önálló szkript, amely elindítja a JVM-et, importálja az API-t, és alkalmaz egy licence-t. Az alkalmazásában a licence alkalmazása után végezze el a prezentációs műveleteket, és csak akkor állítsa le a JVM-et, amikor minden Aspose.Slides feladat befejeződött.

### **Licence alkalmazása fájlból**

Adja át a licence-fájl útvonalát a [License.setLicense](https://reference.aspose.com/slides/hu/python-java/aspose.slides/license/#setLicense) metódusnak. Cserélje le az `Aspose.Slides.lic` értéket a licence-fájlja elérési útjára.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        license = License()
        license.setLicense(str(license_path))
        print("Licensed:", license.isLicensed())
        # Végezze el a prezentációs műveleteket itt, a JVM leállítása előtt.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Használja a pontos fájlnevet a kiterjesztésével együtt. Például ha a fájl neve `Aspose.Slides.lic.xml`, akkor a `.xml` kiterjesztést is adja meg az útvonalban. Egy abszolút útvonal elkerüli a kettősségeket az alkalmazás munkakönyvtárával kapcsolatban.

A példa a [License.isLicensed](https://reference.aspose.com/slides/hu/python-java/aspose.slides/license/#isLicensed) metódust használja annak ellenőrzésére, hogy a licence alkalmazva van-e.

### **Licence alkalmazása bájtokból**

Használja a [License.setLicenseFromBytes](https://reference.aspose.com/slides/hu/python-java/aspose.slides/license/#setLicenseFromBytes) metódust, amikor a licence Python bájtokként áll rendelkezésre. A következő példa bináris módban olvassa be a fájlt, és a licence alkalmazása előtt bezárja azt.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        with license_path.open("rb") as license_file:
            license_data = license_file.read()

        license = License()
        license.setLicenseFromBytes(license_data)
        print("Licensed:", license.isLicensed())
        # Végezze el a prezentációs műveleteket itt, a JVM leállítása előtt.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Tartsa meg az eredeti bájtokat változatlanul. Ne dekódolja, ne formázza át, vagy bármilyen módon ne módosítsa a licence tartalmát a alkalmazás előtt.

## **Mérő licenc alkalmazása**

A mérő alapú licenc a API használat alapján számláz. A mérő licenc megszerzése után alkalmazza a nyilvános és privát kulcsait a [Metered.setMeteredKey](https://reference.aspose.com/slides/hu/python-java/aspose.slides/metered/#setMeteredKey) metódussal. Inicializálja a [Metered](https://reference.aspose.com/slides/hu/python-java/aspose.slides/metered/) objektumot, és egyszer alkalmazza a kulcsokat az alkalmazás indításakor.

A következő példa a `ASPOSE_METERED_PUBLIC_KEY` és `ASPOSE_METERED_PRIVATE_KEY` környezeti változókból olvassa be a kulcsokat. Állítsa be mindkét változót a szkript futtatása előtt.

```python
import os

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Metered

    public_key = os.environ.get("ASPOSE_METERED_PUBLIC_KEY")
    private_key = os.environ.get("ASPOSE_METERED_PRIVATE_KEY")

    if public_key and private_key:
        metered = Metered()
        metered.setMeteredKey(public_key, private_key)
        # Végezze el a prezentációs műveleteket itt, a JVM leállítása előtt.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Note" %}}
A mérő licenc működéséhez internetkapcsolat szükséges a kulcsok érvényesítéséhez és a használat jelentéséhez. Tartsa a privát kulcsot a forráskódtól és a naplóktól távol. A csatlakozási és számlázási részletekért tekintse meg a [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) oldalt.
{{% /alert %}}

## **GYIK**

**Szükséges másik csomagot telepítenem a licence megvásárlása után?**

Nem. Alkalmazza a licence-t ugyanarra a csomagra, amelyet az értékeléshez használ.

**Minden prezentációra alkalmazni kell licence-t?**

Nem. Egyszer alkalmazza az alkalmazás indításakor, a prezentációk létrehozása vagy betöltése előtt.

**Átnevezhetem a licence-fájlt?**

Igen. A kódban használja a pontos új fájlnevet, és a fájl tartalmát változatlanul hagyja.

**Használhatok ideiglenes licence-t a bájt-alapú példával?**

Igen. Olvassa be az ideiglenes licence-fájlt bájtokként, és ugyanúgy alkalmazza, mint egy megvásárolt licence-t.