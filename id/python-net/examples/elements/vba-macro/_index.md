---
title: Makro VBA
type: docs
weight: 150
url: /id/python-net/examples/elements/vba-macro/
keywords:
- makro VBA
- menambahkan makro VBA
- mengakses makro VBA
- menghapus makro VBA
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Bekerja dengan makro VBA di Python menggunakan Aspose.Slides: menambahkan atau mengedit proyek dan modul, menandatangani atau menghapus makro, dan menyimpan presentasi dalam format PPT, PPTX, dan ODP."
---
Menunjukkan cara menambahkan, mengakses, dan menghapus makro VBA menggunakan **Aspose.Slides for Python via .NET**.

## **Menambahkan Makro VBA**

Buat presentasi dengan proyek VBA dan modul makro sederhana.

```py
def add_vba_macro():
    with slides.Presentation() as presentation:
        # Inisialisasi proyek VBA.
        presentation.vba_project = slides.vba.VbaProject()

        # Tambahkan modul kosong bernama "Module".
        module = presentation.vba_project.modules.add_empty_module("Module")
        module.source_code = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub"

        presentation.save("vba_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **Mengakses Makro VBA**

Dapatkan modul pertama dari proyek VBA.

```py
def access_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:
        first_module = presentation.vba_project.modules[0]
```

## **Menghapus Makro VBA**

Hapus modul dari proyek VBA.

```py
def remove_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:

        # Mengasumsikan presentasi berisi proyek VBA dan setidaknya satu modul.
        module = presentation.vba_project.modules[0]

        # Hapus modul dari proyek.
        presentation.vba_project.modules.remove(module)

        presentation.save("vba_macro_removed.pptx", slides.export.SaveFormat.PPTX)
```