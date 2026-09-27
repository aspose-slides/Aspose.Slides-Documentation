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
- használati licenc
- értékelési korlátozások
description: "Alkalmazzon fájl, bájt-alapú vagy használati licencet az Aspose.Slides for Python via Java-ban, és távolítsa el az értékelési korlátozásokat az alkalmazásaiból."
---
## **Áttekintés**

Az Aspose.Slides for Python via Java futtatható értékelő módban vagy licenccel. Értékelő módban egy értékelő vízjel szövegdobozt ad minden diára minden mentett prezentációban, és a prezentációkból a kód által olvasott szöveget csonkolja. Ez a cikk elmagyarázza, hogyan lehet licencet alkalmazni fájlból vagy bájtokból, és hogyan konfigurálható a használati licencelés.

A vásárlási lehetőségekért tekintse meg a [Ár információ](https://purchase.aspose.com/pricing/slides/family) oldalt. Általános licencelési és vásárlási kérdésekért lásd a [Vásárlási irányelvek és GYIK](https://purchase.aspose.com/policies) oldalt.

Az értékelési korlátozásokért és az ideiglenes licenc kérésének módjáért tekintse meg a [Evaluate Aspose.Slides](/slides/hu/python-java/evaluate-aspose-slides/) oldalt. Az ideiglenes licencet ugyanúgy kell alkalmazni, mint a megvásárolt licencfájlt.

## **A licencről**

A licencfájl olyan információkat tartalmaz, mint a termék neve, a licencelt fejlesztők száma és az előfizetés lejárati dátuma. A fájl digitálisan aláírt XML.

{{% alert color="warning" title="Warning" %}}
Ne módosítsa a licencfájlt. Még egy felesleges sortörés is érvénytelenítheti digitális aláírását.
{{% /alert %}}

A licencet egyszer kell alkalmazni alkalmazásonként vagy folyamatonként, mielőtt prezentációkat hozna létre vagy más Aspose.Slides műveleteket végezne. Licencfájl esetén használja a [License](https://reference.aspose.com/slides/python-java/aspose.slides/license/) osztályt. A használati (metered) licencelés nyilvános és privát kulcspárt használ a licencfájl helyett.

## **Licenc alkalmazása**

A következő példák feltételezik, hogy az Aspose.Slides for Python via Java és előfeltételei telepítve vannak. Minden példa egy önálló szkript, amely elindítja a JVM-et, importálja az API-t, és alkalmaz egy licencet. Az alkalmazásában a prezentációs műveleteket a licenc alkalmazása után végezze, és csak akkor állítsa le a JVM-et, amikor minden Aspose.Slides feladat befejeződött.

### **Licenc alkalmazása fájlból**

Adja át a licencfájl útvonalát a [License.setLicense](https://reference.aspose.com/slides/python-java/aspose.slides/license/#setLicense) metódusnak. Cserélje le a `Aspose.Slides.lic`-et a licencfájl útvonalára.

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
        # Végezze a prezentációs műveleteket itt, mielőtt leállítja a JVM-et.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Használja a pontos fájlnevet, beleértve a kiterjesztést is. Például, ha a fájl neve `Aspose.Slides.lic.xml`, a `.xml` kiterjesztést is adja meg az úton. Egy abszolút útvonal elkerüli a bizonytalanságot az alkalmazás munkakönyvtárát illetően.

A példa a [License.isLicensed](https://reference.aspose.com/slides/python-java/aspose.slides/license/#isLicensed) metódust használja annak ellenőrzésére, hogy a licenc alkalmazva lett-e.

### **Licenc alkalmazása bájtokból**

Használja a [License.setLicenseFromBytes](https://reference.aspose.com/slides/python-java/aspose.slides/license/#setLicenseFromBytes) metódust, amikor a licenc Python bájtokként érhető el. A következő példa bináris módban olvassa be a fájlt, majd a licenc alkalmazása előtt bezárja azt.

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
        # Végezze a prezentációs műveleteket itt, mielőtt leállítja a JVM-et.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Tartsa a eredeti bájtokat változatlanul. Ne dekódolja, formázza át vagy módosítsa a licenc tartalmát a alkalmazás előtt.

## **Használati (metered) licenc alkalmazása**

A használati licenc az API használat alapján számláz. A használati licenc megszerzése után a nyilvános és privát kulcsait a [Metered.setMeteredKey](https://reference.aspose.com/slides/python-java/aspose.slides/metered/#setMeteredKey) metódussal alkalmazza. Inicializálja a [Metered](https://reference.aspose.com/slides/python-java/aspose.slides/metered/) objektumot, és a kulcsokat egyszer az alkalmazás indításánál alkalmazza.

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
        # Végezze a prezentációs műveleteket itt, mielőtt leállítja a JVM-et.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Note" %}}
A használati licenchez internetkapcsolat szükséges a kulcsok érvényesítéséhez és a használat jelentéséhez. A privát kulcsot tartsa távol a forráskódtól és a naplóktól. A kapcsolódási és számlázási részletekért tekintse meg a [Használati licenc GYIK](https://purchase.aspose.com/faqs/licensing/metered) oldalt.
{{% /alert %}}

## **GYIK**

**Szükségem van másik csomag telepítésére a licenc megvásárlása után?**  
Nem. A licencet ugyanarra a csomagra alkalmazza, amelyet az értékeléshez használt.

**Minden prezentációhoz alkalmazni kell licencet?**  
Nem. Egyszer alkalmazza az alkalmazás indításakor, mielőtt prezentációkat hozna létre vagy betöltene.

**Át tudom nevezni a licencfájlt?**  
Igen. A kódban használja a pontos új fájlnevet, és a fájl tartalmát változatlanul hagyja.

**Használhatok ideiglenes licencet a bájt-alapú példával?**  
Igen. Olvassa be az ideiglenes licencfájlt bájtokként, és ugyanúgy alkalmazza, mint a megvásárolt licencet.