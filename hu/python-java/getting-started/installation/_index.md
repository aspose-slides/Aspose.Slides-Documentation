---
title: Telepítés
type: docs
weight: 70
url: /hu/python-java/installation/
keywords:
- Aspose.Slides letöltése
- Aspose.Slides telepítése
- Aspose.Slides telepítése
- Python
- Java
- JPype
- Windows
- macOS
- Linux
description: "Telepítse az Aspose.Slides for Python via Java-t Windows, Linux vagy macOS rendszeren, konfigurálja a Java-t és a JPype-ot, és ellenőrizze a beállítást egy működő példával."
---
Aspose.Slides for Python via Java Windows, Linux és macOS rendszereken fut. A JPype-t használja a Java könyvtár Python‑ból történő eléréséhez. A Microsoft PowerPoint nem szükséges.

## **Előfeltételek**

A Python csomagok telepítése előtt telepítsen Python‑t és egy JDK‑t, amely megfelel a [Rendszerkövetelmények](/slides/hu/python-java/system-requirements/) követelményeinek. Az oldal felsorolja a kompatibilis verziókat, az architektúra követelményeket, és minden szükséges függőséget a JPype forrásból történő felépítéséhez.

Állítsa be a `JAVA_HOME` változót a JDK telepítési könyvtárra, nem a `bin` almappára, és adja hozzá a JDK `bin` könyvtárát a `PATH`‑hez. A környezeti változók módosítása után nyisson meg egy új terminált.

## **Telepítés a PyPI‑ról**

Futtassa a következő parancsokat egy terminálban, ne a Python interaktív promptban. Hozzon létre egy projektkönyvtárat és egy virtuális környezetet, hogy a csomagok izoláltak legyenek más projektektől.

### **Windows**

Ha a kiválasztott Python interpreter a `python` néven elérhető a `PATH`‑ban, futtassa a következő parancsokat a Parancssorban:

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux és macOS**

Ha a kiválasztott Python verzió a `python3` néven elérhető, futtassa a következő parancsokat Bash vagy zsh környezetben:

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

Debian vagy Ubuntu rendszeren, ha a környezet létrehozása sikertelen, mert az `ensurepip` nem érhető el, telepítse a `python3-venv` csomagot a `sudo apt-get install python3-venv` parancs segítségével, majd ismételje meg a környezet létrehozásának parancsát. Egy külön telepített Python verzió esetén szükség lehet a megfelelő verzióspecifikus `venv` csomagra.

### **A csomagok telepítése**

A virtuális környezet aktív állapotában telepítse a JPype‑t és az Aspose.Slides‑et:

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

`python -m pip` használata biztosítja, hogy a csomagok az alkalmazás futtatásához használt interpreterhez legyenek telepítve.

Egy meglévő Aspose.Slides telepítés frissítéséhez futtassa a `python -m pip install --upgrade aspose-slides-java` parancsot ugyanabban a környezetben.

## **Telepítés ZIP archívumból**

A könyvtárat a [Aspose.Slides letöltési oldalról](https://releases.aspose.com/slides/hu/python-java/) is használhatja:

1. Telepítse a Python‑t és a Java‑t a [Előfeltételek](#prerequisites) leírása szerint.
2. Hozzon létre és aktiváljon egy virtuális környezetet a fenti útmutató szerint.
3. Telepítse a JPype‑t a `python -m pip install JPype1` paranccsal.
4. Töltse le és csomagolja ki az Aspose.Slides for Python via Java ZIP archívumot.
5. Keresse meg a kicsomagolt `asposeslides` csomagkönyvtárat. Tartsa meg a tartalmát, beleértve a `lib` könyvtárat és a JAR fájlt, együtt.
6. Helyezze a következő szakaszból származó `example.py` fájlt az `asposeslides` könyvtár mellé, hogy a Python importálni tudja a csomagot. Az archívum már tartalmaz egy `example.py` fájlt az `asposeslides` mellett; cserélje le az alábbira.

## **Ellenőrizze a telepítést**

Mentse el a következő kódot `example.py` néven. Ez egy prezentációt hoz létre egy szövegdobozzal, és a `out.pptx` fájlként menti el az aktuális munkakönyvtárban.

```python
import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Presentation, SaveFormat, ShapeType

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 500, 80)
        shape.getTextFrame().setText("Aspose.Slides is ready!")
        presentation.save("out.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    jpype.shutdownJVM()
```

A virtuális környezet aktív állapotában futtassa a példát abban a könyvtárban, ahol a `example.py` található:

```sh
python example.py
```

Az `asposeslides` import regisztrálja a csomagolt Java könyvtárat, mielőtt a JVM elindul. Importálja az `asposeslides.api`‑t a JVM indítása után, és szabadítsa fel a prezentáció erőforrásait a leállítás előtt.

{{% alert color="info" title="Note" %}}
Licenc nélkül a kimenet egy értékelési vízjelet tartalmaz. Lásd a [Aspose.Slides értékelése](/slides/hu/python-java/evaluate-aspose-slides/) oldalt az értékelési korlátozások és az ideiglenes licenc információiért.
{{% /alert %}}

## **GYIK**

**Miért jelzi a Python, hogy a JVM nem található vagy nem tölthető be?**

Ellenőrizze, hogy a `JAVA_HOME` egy a Python és JPype telepítésével kompatibilis JDK‑re mutat, ahogy a [Rendszerkövetelmények](/slides/hu/python-java/system-requirements/) leírásában szerepel. További ellenőrzésekért tekintse meg a [JPype telepítési hibaelhárítási útmutatót](https://jpype.readthedocs.io/en/latest/install.html).

**Miért jelzi a Python, hogy a `asposeslides` hiányzik a telepítés után?**

A csomag egy másik Python interpreterhez lett telepítve. Aktiválja a telepítéshez használt virtuális környezetet, és futtassa a `python -m pip show aspose-slides-java` parancsot. ZIP telepítés esetén győződjön meg róla, hogy a `asposeslides` könyvtár a szkriptje mellett vagy egyébként elérhető a Python modulkeresési útvonalában.

**Futtathatom a példát többször egy notebookban?**

A példa egy önálló Python folyamat számára készült. Mielőtt adaptálná ismételt notebook futtatáshoz, tekintse meg a [Korlátozások és API eltérések](/slides/hu/python-java/limitations-and-api-differences/#import-the-library) oldalt a JVM életciklus és notebook útmutató tekintetében.

**Miért hibázik a pip a `CERTIFICATE_VERIFY_FAILED` hibával?**

Ha a hálózata HTTPS ellenőrző proxy‑t használ, a pip‑nek bizalommal kell rendelkeznie annak tanúsítványkiadójával. Állítsa be a megbízható CA csomagot a pip `--cert` opciójával vagy a `PIP_CERT` környezeti változóval, az [pip HTTPS tanúsítványi útmutató](https://pip.pypa.io/en/stable/topics/https-certificates/) útmutatása szerint. A szükséges konfiguráció a hálózattól és a pip verziójától függ.