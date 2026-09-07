---
title: VBA makró
type: docs
weight: 150
url: /hu/python-java/examples/elements/vba-macro/
keywords:
- kódpélda
- VBA
- makró
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "VBA makrók hozzáadása, elérése és eltávolítása PowerPoint prezentációkban az Aspose.Slides for Python via Java használatával, világos, gyakorlati kódpéldákkal."
---
Ez a cikk bemutatja, hogyan lehet VBA makrókat hozzáadni, elérni és eltávolítani a **Aspose.Slides for Python via Java** használatával.

Telepítse a csomagot az [Installation](/slides/hu/python-java/installation/) útmutató szerint. Minden példa importálja a `asposeslides`‑t a JVM indítása előtt, majd a JVM futása közben importálja az API‑t.

## **VBA makró hozzáadása**

Hozzon létre egy prezentációt egy VBA projekttel és egy egyszerű makrómodullal.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VbaProject

presentation = Presentation()
try:
    presentation.setVbaProject(VbaProject())

    module = presentation.getVbaProject().getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test()\n MsgBox "Hi" \nEnd Sub')
finally:
    presentation.dispose()
```

## **VBA makró elérése**

Hozza vissza az első modult a VBA projektből.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VbaProject

presentation = Presentation()
try:
    presentation.setVbaProject(VbaProject())

    module = presentation.getVbaProject().getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test()\n MsgBox "Hi" \nEnd Sub')

    first_module = presentation.getVbaProject().getModules().get_Item(0)
finally:
    presentation.dispose()
```

## **VBA makró eltávolítása**

Törölje a modult a VBA projektből.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VbaProject

presentation = Presentation()
try:
    presentation.setVbaProject(VbaProject())

    module = presentation.getVbaProject().getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test()\n MsgBox "Hi" \nEnd Sub')

    presentation.getVbaProject().getModules().remove(module)
finally:
    presentation.dispose()
```