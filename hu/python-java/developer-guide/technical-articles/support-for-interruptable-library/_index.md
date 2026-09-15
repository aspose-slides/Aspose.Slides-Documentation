---
title: Megszakítható könyvtár támogatása
type: docs
weight: 120
url: /hu/python-java/support-for-interruptable-library/
keywords:
- megszakítható könyvtár
- megszakítási token
- Mégse token
- hosszú futású feladat
- feladat megszakítása
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Tegye a hosszú futású feladatokat lemondhatóvá az Aspose.Slides for Python via Java segítségével. Biztonságosan szakítsa meg a renderelést és a konverziókat PowerPoint és OpenDocument esetén, példákkal."
---
## **Áttekintés**

Az Aspose.Slides megszakítható feldolgozási mechanizmust biztosít a hosszú ideig futó bemutató feladatokhoz, például a deszerializáláshoz, szerializáláshoz és rendereléshez. Ez a mechanizmus a [InterruptionToken](https://reference.aspose.com/slides/hu/python-java/aspose.slides/interruptiontoken/) és a [InterruptionTokenSource](https://reference.aspose.com/slides/hu/python-java/aspose.slides/interruptiontokensource/) osztályokon alapul.

Egy [InterruptionToken](https://reference.aspose.com/slides/hu/python-java/aspose.slides/interruptiontoken/) hozzárendelhető a [LoadOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/) osztályhoz, és átadható a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) konstruktorának. Amikor a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/interruptiontokensource/#interrupt) meghívásra kerül, a kapcsolódó hosszú ideig futó feladat megszakad.

## **Megszakítható könyvtár**

Az Aspose.Slides for Python via Java biztosítja a [InterruptionToken](https://reference.aspose.com/slides/hu/python-java/aspose.slides/interruptiontoken/) és a [InterruptionTokenSource](https://reference.aspose.com/slides/hu/python-java/aspose.slides/interruptiontokensource/) osztályokat. Lehetővé teszik a hosszú ideig futó feladatok, például a deszerializálás, szerializálás és renderelés megszakítását.

- [InterruptionTokenSource](https://reference.aspose.com/slides/hu/python-java/aspose.slides/interruptiontokensource/) a token(ek) forrása, amely(ek)et a [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#setInterruptionToken) kapja.
- Amikor a [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#setInterruptionToken) meghívásra kerül, és a [LoadOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/) példány átadásra kerül a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) konstruktorának, a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/interruptiontokensource/#interrupt) meghívása megszakítja a hozzá kapcsolódó bármely hosszú ideig futó feladatot a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) esetében.

Az alábbi kódrészlet bemutatja egy futó feladat megszakítását:

```python
from concurrent.futures import ThreadPoolExecutor
import time

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat


token_source = InterruptionTokenSource()


def convert_presentation():
    load_options = LoadOptions()
    load_options.setInterruptionToken(token_source.getToken())

    presentation = Presentation("sample.pptx", load_options)
    try:
        presentation.save("sample.ppt", SaveFormat.Ppt)
    finally:
        presentation.dispose()


with ThreadPoolExecutor(max_workers=1) as executor:
    conversion_task = executor.submit(convert_presentation)  # Futtassa a műveletet egy külön szálban.
    time.sleep(10)  # Időtúllépés.
    token_source.interrupt()  # Állítsa le a konverziót.
    conversion_task.result()
```

## **GYIK**

**Mi a célja az Aspose.Slides megszakítási könyvtárának?**

Mechanizmust biztosít a hosszú ideig futó műveletek—például a prezentációk betöltése, mentése vagy renderelése—megszakításához, mielőtt befejeződnének. Ez akkor hasznos, ha a feldolgozási időt korlátozni kell, vagy a feladat már nem szükséges.

**Mi a különbség a [InterruptionToken](https://reference.aspose.com/slides/hu/python-java/aspose.slides/interruptiontoken/) és a [InterruptionTokenSource](https://reference.aspose.com/slides/hu/python-java/aspose.slides/interruptiontokensource/) között?**

- [InterruptionToken](https://reference.aspose.com/slides/hu/python-java/aspose.slides/interruptiontoken/) átadásra kerül az Aspose.Slides API-nak, és a hosszú ideig futó műveletek során ellenőrzésre kerül.
- [InterruptionTokenSource](https://reference.aspose.com/slides/hu/python-java/aspose.slides/interruptiontokensource/) a kódban használható tokenek létrehozására és a megszakítások kiváltására a [interrupt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/interruptiontokensource/#interrupt) meghívásával.

**Mely feladatok szakíthatók meg?**

Bármely Aspose.Slides feladat, amely elfogad egy [InterruptionToken](https://reference.aspose.com/slides/hu/python-java/aspose.slides/interruptiontoken/)—például egy prezentáció betöltése a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) vagy a mentése a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) segítségével—megszakítható.

**A megszakítás azonnal megtörténik?**

Nem. A megszakítás együttműködésen alapul: a művelet időközönként ellenőrzi a tokent, és leáll, amint észleli, hogy a [interrupt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/interruptiontokensource/#interrupt) meghívásra került.

**Mi történik, ha a [interrupt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/interruptiontokensource/#interrupt) meghívását egy már befejezett feladat után végzem?**

Semmi— a hívás nem okoz semmit, ha a megfelelő feladat már befejeződött.

**Újra felhasználhatom ugyanazt a [InterruptionTokenSource](https://reference.aspose.com/slides/hu/python-java/aspose.slides/interruptiontokensource/) több feladathoz?**

Igen—de miután meghívja a [interrupt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/interruptiontokensource/#interrupt) függvényt azon a forráson, az összes, az ő tokenjeit használó feladat megszakad. Használjon külön tokenforrásokat a feladatok független kezeléséhez.