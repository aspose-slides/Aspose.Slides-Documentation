---
title: ActiveX
type: docs
weight: 200
url: /id/python-java/examples/elements/activex/
keywords:
- contoh kode
- ActiveX
- kontrol ActiveX
- properti ActiveX
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Gunakan Aspose.Slides for Python via Java untuk menambahkan, mengakses, menghapus, dan mengkonfigurasi kontrol ActiveX dalam presentasi PowerPoint dengan contoh kode praktis."
---
Artikel ini menunjukkan cara menambahkan, mengakses, menghapus, dan mengkonfigurasi kontrol ActiveX dalam sebuah presentasi menggunakan **Aspose.Slides for Python via Java**.

Instal paket seperti yang dijelaskan pada [Instalasi](/slides/id/python-java/installation/). Setiap contoh mengimpor `asposeslides` sebelum memulai JVM, kemudian mengimpor API setelah JVM berjalan. Contoh akses dan penghapusan menggunakan `add_activex.pptm`, yang dibuat oleh contoh pertama.

## **Menambahkan Kontrol ActiveX**

Sisipkan kontrol Windows Media Player pada slide pertama dan simpan presentasi sebagai file PPTM.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Tambahkan kontrol Windows Media Player.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50)
    control.getProperties().set_Item("autoStart", "false")

    presentation.save("add_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Mengakses Kontrol ActiveX**

Baca nama dan pengaturan pemutaran otomatis dari kontrol ActiveX pertama pada slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # Akses kontrol ActiveX pertama.
            control = slide.getControls().get_Item(0)
            print("Control Name:", control.getName())
            print("autoStart:", control.getProperties().get_Item("autoStart"))
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

## **Menghapus Kontrol ActiveX**

Hapus kontrol ActiveX pertama dari slide dan simpan presentasi yang telah dimodifikasi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # Hapus kontrol ActiveX pertama.
            slide.getControls().removeAt(0)
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")

    presentation.save("removed_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Menetapkan Properti ActiveX**

Tambahkan kontrol Windows Media Player, nonaktifkan pemutaran otomatis, dan sembunyikan kontrol pemutarannya. Gunakan [ControlPropertiesCollection.set_Item](https://reference.aspose.com/slides/id/python-java/aspose.slides/controlpropertiescollection/#set_Item) untuk menetapkan nilai properti sebagai string.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Tambahkan kontrol Windows Media Player dan konfigurasikan propertinya.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50)
    properties = control.getProperties()
    properties.set_Item("autoStart", "false")
    properties.set_Item("uiMode", "none")

    presentation.save("set_activex_props.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```