---
title: Makro VBA
type: docs
weight: 150
url: /id/python-java/examples/elements/vba-macro/
keywords:
- contoh kode
- VBA
- makro
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Menambahkan, mengakses, dan menghapus makro VBA dalam presentasi PowerPoint menggunakan Aspose.Slides untuk Python via Java dengan contoh kode yang jelas dan praktis."
---
Artikel ini menunjukkan cara menambahkan, mengakses, dan menghapus makro VBA menggunakan **Aspose.Slides for Python via Java**.

Instal paket seperti yang dijelaskan dalam [Installation](/slides/id/python-java/installation/). Setiap contoh mengimpor `asposeslides` sebelum memulai JVM, kemudian mengimpor API setelah JVM berjalan.

## **Menambahkan Makro VBA**

Buat sebuah presentasi dengan proyek VBA dan modul makro sederhana.

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

## **Mengakses Makro VBA**

Ambil modul pertama dari proyek VBA.

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

## **Menghapus Makro VBA**

Hapus sebuah modul dari proyek VBA.

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