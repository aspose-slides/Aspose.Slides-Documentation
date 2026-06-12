---
title: Kelola Proyek VBA dalam Presentasi dengan Python
linktitle: Presentasi via VBA
type: docs
weight: 250
url: /id/python-net/presentation-via-vba/
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
- Aspose.Slides
description: "Temukan cara membuat dan memanipulasi presentasi PowerPoint dan OpenDocument melalui VBA dengan Aspose.Slides untuk Python via .NET untuk menyederhanakan alur kerja Anda."
---
## **Ikhtisar**

Artikel ini membahas kemampuan utama Aspose.Slides untuk Python via .NET dalam bekerja dengan makro pada presentasi PowerPoint. Perpustakaan ini menyediakan alat yang mudah untuk menambahkan, menghapus, dan mengekstrak makro, yang memungkinkan Anda mengotomatisasi pembuatan dan modifikasi presentasi.

Dengan Aspose.Slides, Anda dapat:

- Mempercepat pengembangan presentasi—otomatisasi tugas rutin mengurangi waktu yang diperlukan untuk menyiapkan materi.
- Menjamin fleksibilitas—kemampuan mengelola makro memungkinkan Anda menyesuaikan presentasi untuk tugas dan skenario tertentu.
- Mengintegrasikan data—integrasi sederhana dengan sumber data eksternal membantu menjaga konten slide tetap mutakhir.
- Menyederhanakan pemeliharaan—manajemen makro terpusat memudahkan penerapan perubahan dan pembaruan presentasi.

Artikel ini selanjutnya menyajikan contoh praktis tentang cara menggunakan Aspose.Slides untuk bekerja secara efektif dengan makro di PowerPoint.

Namespace [aspose.slides.vba](https://reference.aspose.com/slides/id/python-net/aspose.slides.vba/) menyediakan kelas untuk bekerja dengan makro dan kode VBA.

{{% alert title="Note" color="warning" %}}
Saat Anda mengonversi presentasi yang berisi makro ke format lain (PDF, HTML, dll.), Aspose.Slides mengabaikan makro—makro tidak dipindahkan ke file output.

Saat Anda menambahkan makro ke sebuah presentasi atau menyimpan ulang presentasi yang berisi makro, Aspose.Slides menulis byte makro apa adanya.

Aspose.Slides **tidak pernah** mengeksekusi makro dalam sebuah presentasi.
{{% /alert %}}

## **Menambahkan Makro VBA**

Aspose.Slides menyediakan kelas [VbaProject](https://reference.aspose.com/slides/id/python-net/aspose.slides.vba/vbaproject/) untuk membuat proyek VBA (dan referensi proyek) serta mengedit modul yang ada.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Gunakan konstruktor [VbaProject](https://reference.aspose.com/slides/id/python-net/aspose.slides.vba/vbaproject/#constructors) untuk menambahkan proyek VBA baru.
1. Tambahkan modul ke proyek VBA.
1. Tetapkan kode sumber modul.
1. Tambahkan referensi ke `<stdole>`.
1. Tambahkan referensi ke **Microsoft Office**.
1. Kaitkan referensi dengan proyek VBA.
1. Simpan presentasi.

Kode Python berikut menunjukkan cara menambahkan makro VBA dari awal ke sebuah presentasi:

```python
import aspose.slides as slides

# Buat sebuah instance dari kelas Presentation.
with slides.Presentation() as presentation:

    # Buat proyek VBA baru.
    presentation.vba_project = slides.vba.VbaProject()

    # Tambahkan modul kosong ke proyek VBA.
    module = presentation.vba_project.modules.add_empty_module("Module")

    # Setel kode sumber modul.
    module.source_code = """
        Sub Test(oShape As Shape)
            MsgBox "Hello, world!"
        End Sub
    """

    # Buat referensi ke <stdole>.
    stdole_reference = slides.vba.VbaReferenceOleTypeLib("stdole",
        "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # Buat referensi ke Microsoft Office.
    office_reference = slides.vba.VbaReferenceOleTypeLib("Office",
        "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Tambahkan referensi ke proyek VBA.
    presentation.vba_project.references.add(stdole_reference)
    presentation.vba_project.references.add(office_reference)

    # Simpan presentasi.
    presentation.save("macros.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}}
Anda mungkin ingin mencoba **Aspose** [Macro Remover](https://products.aspose.app/slides/id/remove-macros), aplikasi web gratis untuk menghapus makro dari dokumen PowerPoint, Excel, dan Word.
{{% /alert %}}

## **Menghapus Makro VBA**

Dengan menggunakan properti [vba_project](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/vba_project/) dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/), Anda dapat menghapus sebuah makro VBA.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dan muat presentasi yang berisi makro.
1. Akses modul makro dan hapus.
1. Simpan presentasi yang telah dimodifikasi.

Kode Python berikut menunjukkan cara menghapus sebuah makro VBA:

```python
import aspose.slides as slides

# Muat presentasi yang berisi makro.
with slides.Presentation("VBA.pptm") as presentation:
    
    # Akses modul VBA.
    vba_module = presentation.vba_project.modules[0]

    # Hapus modul VBA.
    presentation.vba_project.modules.remove(vba_module)

    # Simpan presentasi.
    presentation.save("removed_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **Mengekstrak Makro VBA**

Dengan menggunakan properti `modules` pada kelas [VbaProject](https://reference.aspose.com/slides/id/python-net/aspose.slides.vba/vbaproject/), Anda dapat mengakses semua modul dalam sebuah proyek VBA. Kelas [VbaModule](https://reference.aspose.com/slides/id/python-net/aspose.slides.vba/vbamodule/) dapat digunakan untuk mengekstrak properti modul seperti nama dan kode.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dan muat presentasi yang berisi makro.
1. Periksa apakah presentasi berisi proyek VBA.
1. Loop melalui semua modul dalam proyek VBA untuk melihat makro.

Kode Python berikut menunjukkan cara mengekstrak makro VBA dari sebuah presentasi:

```python
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Periksa apakah presentasi berisi proyek VBA.
    if presentation.vba_project is not None:
        for module in presentation.vba_project.modules:
            print(module.name)
            print(module.source_code)
```

## **Memeriksa Apakah Proyek VBA Dilindungi Kata Sandi**

Menggunakan properti [VbaProject.is_password_protected](https://reference.aspose.com/slides/id/python-net/aspose.slides.vba/vbaproject/is_password_protected/), Anda dapat menentukan apakah properti sebuah proyek dilindungi kata sandi.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dan muat presentasi yang berisi makro.
1. Periksa apakah presentasi berisi [VBA project](https://reference.aspose.com/slides/id/python-net/aspose.slides.vba/vbaproject/).
1. Periksa apakah proyek VBA dilindungi kata sandi untuk melihat propertinya.

```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Periksa apakah presentasi berisi proyek VBA.
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```

## **FAQ**

**Apa yang terjadi pada makro jika saya menyimpan presentasi sebagai PPTX?**

Makro akan dihapus karena PPTX tidak mendukung VBA. Untuk mempertahankan makro, pilih PPTM, PPSM, atau POTM.

**Apakah Aspose.Slides dapat menjalankan makro di dalam presentasi, misalnya untuk menyegarkan data?**

Tidak. Perpustakaan tidak pernah mengeksekusi kode VBA; eksekusi hanya dimungkinkan di dalam PowerPoint dengan pengaturan keamanan yang sesuai.

**Apakah kerja dengan kontrol ActiveX yang terhubung ke kode VBA didukung?**

Ya, Anda dapat mengakses [ActiveX controls](/slides/id/python-net/activex/), mengubah properti mereka, dan menghapusnya. Ini berguna ketika makro berinteraksi dengan ActiveX.