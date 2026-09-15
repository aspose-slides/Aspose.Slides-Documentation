---
title: Kelola Proyek VBA dalam Presentasi Menggunakan Python
linktitle: Presentasi via VBA
type: docs
weight: 250
url: /id/python-java/presentation-via-vba/
keywords:
- makro
- VBA
- makro VBA
- tambahkan makro
- hapus makro
- ekstrak makro
- tambahkan VBA
- hapus VBA
- ekstrak VBA
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Temukan cara membuat dan memanipulasi presentasi PowerPoint dan OpenDocument melalui VBA dengan Aspose.Slides untuk Python via Java untuk menyederhanakan alur kerja Anda."
---
## **Pendahuluan**

Aspose.Slides menyediakan kelas dan antarmuka untuk bekerja dengan makro dan kode VBA.

{{% alert title="Warning" color="warning" %}} 

Saat Anda mengonversi presentasi yang berisi makro ke format file yang berbeda (PDF, HTML, dll.), Aspose.Slides mengabaikan semua makro (makro tidak dibawa ke file hasil).

Saat Anda menambahkan makro ke presentasi atau menyimpan ulang presentasi yang berisi makro, Aspose.Slides hanya menulis byte untuk makro.

Aspose.Slides **tidak pernah** menjalankan makro dalam sebuah presentasi.

{{% /alert %}}

## **Menambahkan Makro VBA**

Aspose.Slides menyediakan kelas [VbaProject](https://reference.aspose.com/slides/id/python-java/aspose.slides/vbaproject/) yang memungkinkan Anda membuat proyek VBA (dan referensi proyek) serta mengedit modul yang ada. Anda dapat menggunakan kelas [VbaProject](https://reference.aspose.com/slides/id/python-java/aspose.slides/vbaproject/) untuk mengelola VBA yang tertanam dalam sebuah presentasi.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
1. Gunakan konstruktor [VbaProject](https://reference.aspose.com/slides/id/python-java/aspose.slides/vbaproject/#vbaproject) untuk menambahkan proyek VBA baru.
1. Tambahkan modul ke proyek VBA.
1. Setel kode sumber modul.
1. Tambahkan referensi ke `stdole`.
1. Tambahkan referensi ke **Microsoft Office**.
1. Asosiasikan referensi dengan proyek VBA.
1. Simpan presentasi.

Kode Python berikut menunjukkan cara menambahkan makro VBA dari awal ke sebuah presentasi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VbaProject, VbaReferenceOleTypeLib

presentation = Presentation()
try:
    # Buat proyek VBA baru.
    vba_project = VbaProject()
    presentation.setVbaProject(vba_project)

    # Tambahkan modul kosong dan atur kode sumbernya.
    module = vba_project.getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test(oShape As Shape)\n    MsgBox "Test"\nEnd Sub')

    # Buat referensi ke stdole dan Microsoft Office.
    stdole_reference = VbaReferenceOleTypeLib("stdole", r"*\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\Windows\system32\stdole2.tlb#OLE Automation")
    office_reference = VbaReferenceOleTypeLib("Office", r"*\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\Program Files\Common Files\Microsoft Shared\OFFICE14\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Tambahkan referensi ke proyek VBA.
    vba_project.getReferences().add(stdole_reference)
    vba_project.getReferences().add(office_reference)

    # Simpan presentasi.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

Anda mungkin ingin melihat **Aspose** [Macro Remover](https://products.aspose.app/slides/id/remove-macros), yang merupakan aplikasi web gratis untuk menghapus makro dari dokumen PowerPoint, Excel, dan Word. 

{{% /alert %}} 

## **Menghapus Makro VBA**

Dengan menggunakan metode [getVbaProject](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getvbaproject) dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/), Anda dapat menghapus makro VBA.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dan muat presentasi yang berisi makro.
1. Akses modul makro dan hapus.
1. Simpan presentasi yang telah dimodifikasi.

Kode Python berikut menunjukkan cara menghapus makro VBA:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpaml.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Muat presentasi yang berisi makro.
presentation = Presentation("VBA.pptm")
try:
    # Akses modul VBA dan hapus.
    vba_project = presentation.getVbaProject()
    if vba_project is not None and len(list(vba_project.getModules())) > 0:
        module = vba_project.getModules().get_Item(0)
        vba_project.getModules().remove(module)

    # Simpan presentasi.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Mengekstrak Makro VBA**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dan muat presentasi yang berisi makro.
2. Periksa apakah presentasi berisi Proyek VBA.
3. Lakukan perulangan pada semua modul yang terdapat dalam Proyek VBA untuk melihat makro.

Kode Python berikut menunjukkan cara mengekstrak makro VBA dari sebuah presentasi yang berisi makro:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# Muat presentasi yang berisi makro.
presentation = Presentation("VBA.pptm")
try:
    # Periksa apakah presentasi berisi proyek VBA.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        for module in vba_project.getModules():
            print(module.getName())
            print(module.getSourceCode())
finally:
    presentation.dispose()
```

## **Memeriksa Apakah Proyek VBA Dilindungi Kata Sandi**

Dengan menggunakan metode [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/id/python-java/aspose.slides/vbaproject/#ispasswordprotected), Anda dapat menentukan apakah properti proyek dilindungi kata sandi.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dan muat presentasi yang berisi makro.
2. Periksa apakah presentasi berisi [proyek VBA](https://reference.aspose.com/slides/id/python-java/aspose.slides/vbaproject/).
3. Periksa apakah proyek VBA dilindungi kata sandi untuk melihat propertinya.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("VBA.pptm")
try:
    # Periksa apakah presentasi berisi proyek VBA.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        if vba_project.isPasswordProtected():
            print(f"The VBA project '{vba_project.getName()}' is password-protected for viewing its properties.")
finally:
    presentation.dispose()
```

## **FAQ**

**Apa yang terjadi pada makro jika saya menyimpan presentasi sebagai PPTX?**

Makro akan dihapus karena PPTX tidak mendukung VBA. Untuk menyimpan makro, pilih PPTM, PPSM, atau POTM.

**Apakah Aspose.Slides dapat menjalankan makro di dalam presentasi, misalnya untuk menyegarkan data?**

Tidak. Perpustakaan tidak pernah mengeksekusi kode VBA; eksekusi hanya dimungkinkan di dalam PowerPoint dengan pengaturan keamanan yang tepat.

**Apakah bekerja dengan kontrol ActiveX yang terhubung ke kode VBA didukung?**

Ya, Anda dapat mengakses [kontrol ActiveX](/slides/id/python-java/activex/) yang ada, memodifikasi propertinya, dan menghapusnya. Ini berguna ketika makro berinteraksi dengan ActiveX.