---
title: Kompatibilitas dengan PyInstaller dan cx_Freeze
linktitle: Kompatibilitas dengan PyInstaller
type: docs
weight: 122
url: /id/python-net/compatibility-with-pyinstaller/
keywords:
- kompatibilitas
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "Kemasan Aspose.Slides untuk Python via .NET dengan PyInstaller. Ikuti panduan ini untuk menggabungkan, mengkonfigurasi, dan memecahkan masalah aplikasi Anda menjadi executable mandiri."
---
## **Pengantar**

Aspose.Slides for Python via .NET adalah ekstensi C Python standar, sehingga dapat dibekukan sebagai dependensi program dengan alat seperti PyInstaller dan cx_Freeze (atau serupa). Ini memungkinkan Anda membuat file executable dari skrip Python Anda. Alat semacam itu disebut “freezer” karena mereka menggabungkan kode Anda dan dependensinya ke dalam satu file yang dapat didistribusikan dan dapat dijalankan di mesin lain tanpa memerlukan instalasi Python atau perpustakaan tambahan. Pendekatan ini menyederhanakan distribusi aplikasi Python Anda.

Membekukan ekstensi Aspose.Slides for Python via .NET sebagai dependensi ditunjukkan di bawah dengan program sederhana yang menggunakan Aspose.Slides.

## **PyInstaller**

Umumnya, tidak ada yang khusus diperlukan saat mengemas program yang bergantung pada ekstensi Aspose.Slides for Python via .NET. Ketika sebuah program mengimpor ekstensi dengan cara yang terlihat oleh PyInstaller, ekstensi tersebut akan dibundel bersama program. Karena Aspose.Slides for Python via .NET menyertakan hook PyInstaller, dependensinya secara otomatis terdeteksi dan disalin ke dalam bundel.

slide_app.py:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50.0, 150.0, 300.0, 0.0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

```bash
$ pyinstaller slide_app.py
```

Namun, PyInstaller terkadang dapat melewatkan impor tersembunyi—modul yang diimpor secara dinamis atau tidak langsung oleh kode Anda. Untuk menyertakan impor tersembunyi, gunakan opsi PyInstaller. Dependensi ekstensi ditentukan dalam hook PyInstaller yang disertakan bersama Aspose.Slides for Python via .NET.

slide_app.spec:
```
a = Analysis(
    ['slide_app.py'],
    ...
    hiddenimports=['aspose.slides']
)
```

```bash
$ pyinstaller slide_app.spec
```

## **cx_Freeze**

Untuk membekukan program dengan cx_Freeze, konfigurasikan agar menyertakan paket root dari ekstensi Aspose.Slides for Python via .NET yang Anda gunakan. Ini memastikan ekstensi dan semua modul dependennya disalin ke dalam build bersama aplikasi Anda.

### **Menggunakan Skrip cxfreeze**

```bash
$ cxfreeze slide_app.py --packages=aspose
```

### **Menggunakan Skrip Setup**

setup.py:
```
executables = [Executable('slide_app.py')]

options = {
    'build_exe': {
        'packages': ['aspose'],
    }
}

setup(...
    options=options,
    executables=executables)
```

```bash
$ python setup.py build_exe
```

## **FAQ**

**Apakah saya perlu menginstal Microsoft PowerPoint atau .NET di mesin pengguna?**

Tidak, PowerPoint tidak diperlukan. Aspose.Slides adalah mesin yang mandiri; paket Python menyertakan semua yang dibutuhkan sebagai ekstensi untuk CPython. Pengguna tidak perlu menginstal .NET secara terpisah.

**Bagaimana cara yang tepat untuk melampirkan lisensi pada aplikasi yang dibekukan?**

Anda dapat menyimpan XML lisensi di samping executable atau menyematkannya sebagai sumber daya dan memuatnya dari path yang dapat diakses sebelum panggilan API pertama. Penting: jangan mengubah konten XML (bahkan tidak memodifikasi baris baru).

**Apa yang harus saya lakukan jika font tampil berbeda setelah build dibandingkan dengan pengembangan?**

Pastikan font yang Anda gunakan tersedia di lingkungan target (terbundel atau terpasang di sistem) dan jalurnya berhasil diresolusikan pada saat runtime; perilaku font sangat sensitif terutama di Linux.