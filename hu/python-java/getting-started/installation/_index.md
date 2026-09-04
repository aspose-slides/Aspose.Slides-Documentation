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
description: "Telepítse az Aspose.Slides for Python via Java‑t Windows, Linux vagy macOS rendszeren, konfigurálja a Java‑t és a JPype‑t, és ellenőrizze a beállítást egy működő példával."
---
Az Aspose.Slides for Python via Java Windows, Linux és macOS rendszereken fut. JPype‑t használ a Java könyvtár Pythonból történő eléréséhez. A Microsoft PowerPoint nem szükséges.

## **Előfeltételek**

Mielőtt telepítené a Python csomagokat, telepítse a Pythont és egy JDK‑t, amely megfelel a [System Requirements](/slides/hu/python-java/system-requirements/) követelményeknek. Az oldal felsorolja a kompatibilis verziókat, az architektúra‑követelményeket, valamint az JPype forrásból történő felépítéséhez szükséges függőségeket.

Állítsa be a `JAVA_HOME` környezeti változót a JDK telepítési könyvtárára, nem a `bin` almappára, és adja hozzá a JDK `bin` könyvtárát a `PATH`‑hez. A környezeti változók módosítása után nyisson meg egy új terminált.

## **Telepítés PyPI‑ról**

Futtassa a következő parancsokat egy terminálban, nem a Python interaktív promptján. Hozzon létre egy projektkönyvtárat és egy virtuális környezetet, hogy a csomagok izolálva legyenek a többi projektben.

### **Windows**

Ha a választott Python értelmező elérhető `python` néven a `PATH`‑ban, futtassa a következő parancsokat a Parancssorban:

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux és macOS**

Ha a választott Python verzió elérhető `python3` néven, futtassa a következő parancsokat Bash‑ban vagy zsh‑ban:

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

Debian vagy Ubuntu esetén, ha a környezet létrehozása sikertelen, mert az `ensurepip` nem érhető el, telepítse a `python3-venv` csomagot a `sudo apt-get install python3-venv` paranccsal, majd ismételje meg a környezet létrehozásának parancsát. Egy külön telepített Python verzióhoz szükség lehet a megfelelő verzióspecifikus `venv` csomagra.

### **Csomagok telepítése**

A virtuális környezet aktív állapotában telepítse a JPype‑t és az Aspose.Slides‑t:

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

`python -m pip` használata biztosítja, hogy a csomagok a alkalmazás futtatásához használt értelmezőhöz legyenek telepítve.

Egy meglévő Aspose.Slides telepítés frissítéséhez futtassa a `python -m pip install --upgrade aspose-slides-java` parancsot ugyanabban a környezetben.

## **Telepítés ZIP archívumból**

A könyvtárat a [Aspose.Slides letöltési oldalról](https://releases.aspose.com/slides/hu/python-java/) is szintén használhatja:

1. Telepítse a Pythont és a Javat a [Előfeltételek](#prerequisites) szekcióban leírtak szerint.
2. Hozzon létre és aktiváljon egy virtuális környezetet a fenti útmutató szerint.
3. Telepítse a JPype‑t a `python -m pip install JPype1` paranccsal.
4. Töltse le és csomagolja ki az Aspose.Slides for Python via Java ZIP archívumát.
5. Keresse meg a kicsomagolt `asposeslides` csomag könyvtárát. Tartsa meg a tartalmát, beleértve a `lib` könyvtárat és a JAR fájlt, együtt.
6. Helyezze a `example.py` fájlt a következő szakaszból az `asposeslides` könyvtár mellé, hogy a Python importálni tudja a csomagot.

## **A telepítés ellenőrzése**

Mentse el a következő kódot `example.py` néven. Ez létrehoz egy prezentációt egy szövegdobozzal, és elmenti `out.pptx` néven az aktuális munkakönyvtárba.

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

A virtuális környezet aktív állapotában futtassa a példát annak a könyvtárnak a tartalmából, amelyik tartalmazza a `example.py` fájlt:

```sh
python example.py
```

Az `asposeslides` import regisztrálja a csomagolt Java könyvtárat a JVM indítása előtt. Importálja az `asposeslides.api`‑t a JVM indítása után, és a leállítás előtt szabadítsa fel a prezentáció erőforrásait.

{{% alert color="info" title="Note" %}}

Licenc hiányában a kimenet értékelési vízjelet tartalmaz. Lásd a [Értékelés Aspose.Slides](/slides/hu/python-java/evaluate-aspose-slides/) oldalt az értékelési korlátozásokért és az ideiglenes licenc információkért.

{{% /alert %}}

## **GYIK**

**Miért jelzi a Python, hogy a JVM nem található vagy nem tölthető be?**

Ellenőrizze, hogy a `JAVA_HOME` egy a Python és JPype telepítésével kompatibilis JDK‑ra mutat, ahogyan a [System Requirements](/slides/hu/python-java/system-requirements/) leírja. További ellenőrzésekért tekintse meg a [JPype installation troubleshooting guide](https://jpype.readthedocs.io/en/latest/install.html) útmutatót.

**Miért jelzi a Python, hogy az `asposeslides` hiányzik a telepítés után?**

Lehetséges, hogy a csomag egy másik Python értelmezőhöz lett telepítve. Aktiválja a telepítéshez használt virtuális környezetet, és futtassa a `python -m pip show aspose-slides-java` parancsot. ZIP‑telepítés esetén győződjön meg róla, hogy az `asposeslides` könyvtár a szkript mellett vagy más módon elérhető legyen a Python modulkeresési útvonalán.

**Futtathatom a példát többször egy notebookban?**

A példát egy önálló Python folyamatban való futtatásra tervezték. Mielőtt ismételt notebook‑végrehajtásra alakítaná át, tekintse meg a [Limitations and API Differences](/slides/hu/python-java/limitations-and-api-differences/#import-the-library) szekciót a JVM életciklusáról és a notebook‑használatról.

**Miért hibázik a pip a `CERTIFICATE_VERIFY_FAILED` hibával?**

Ha a hálózata HTTPS ellenőrző proxyt használ, a pip‑nek meg kell bízni annak tanúsítványkiadójában. Állítsa be a megbízható CA csomagot a pip `--cert` kapcsolójával vagy a `PIP_CERT` környezeti változóval, a [pip HTTPS certificate instructions](https://pip.pypa.io/en/stable/topics/https-certificates/) útmutató szerint. A szükséges beállítás a hálózattól és a pip verziótól függ.