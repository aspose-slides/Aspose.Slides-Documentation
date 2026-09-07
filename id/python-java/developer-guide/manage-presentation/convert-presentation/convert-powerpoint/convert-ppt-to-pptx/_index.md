---
title: Mengonversi PPT ke PPTX dalam Python
linktitle: PPT ke PPTX
type: docs
weight: 20
url: /id/python-java/convert-ppt-to-pptx/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- PPT ke PPTX
- simpan PPT sebagai PPTX
- ekspor PPT ke PPTX
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Mengonversi file PPT lama ke PPTX dalam Python dengan Aspose.Slides. Menyertakan contoh Python untuk konversi satu file dan batch, penanganan kesalahan, serta catatan keakuratan."
---
## **Ikhtisar**

PPT adalah format binari lama PowerPoint, sedangkan PPTX adalah format Open XML yang lebih baru. Aspose.Slides for Python via Java dapat memuat file PPT dan menyimpannya sebagai PPTX tanpa Microsoft PowerPoint. Artikel ini menunjukkan cara mengonversi satu file atau direktori file dan menjelaskan apa yang perlu diverifikasi setelah konversi.

Setiap contoh memulai mesin virtual Java bila diperlukan dan melepaskan presentasi setelah digunakan. Ganti jalur contoh dengan jalur file atau direktori Anda sendiri.

## **Konversi File PPT ke PPTX**

Muat file sumber dengan kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/), lalu panggil [Presentation.save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save) dengan [SaveFormat.Pptx](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveformat/#Pptx). Blok `finally` membuang presentasi dan melepaskan sumber dayanya.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Muat presentasi PPT lama.
presentation = Presentation("presentation.ppt")
try:
    # Simpan presentasi dalam format PPTX.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ekstensi file tidak secara otomatis memilih format output; argumen [SaveFormat.Pptx](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveformat/#Pptx) yang melakukannya. Pastikan jalur input dan output berbeda jika Anda perlu mempertahankan file PPT asli.

## **Konversi Banyak File PPT**

Contoh berikut mengonversi setiap file `.ppt` dalam satu direktori. Setiap file diproses secara independen, sehingga satu konversi yang gagal tidak menghentikan batch lainnya.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

input_directory = Path("input")
output_directory = Path("output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
    input_files = list(input_directory.iterdir())
except OSError as error:
    print(f"Cannot prepare the conversion directories: {error}")
else:
    for input_file in input_files:
        if not input_file.is_file() or input_file.suffix.lower() != ".ppt":
            continue

        output_file = output_directory / (input_file.stem + ".pptx")
        input_path = str(input_file)
        output_path = str(output_file)
        presentation = None

        try:
            presentation = Presentation(input_path)
            presentation.save(output_path, SaveFormat.Pptx)
            print(f"Converted: {input_path}")
        except Exception as error:
            print(f"Failed: {input_path} ({error})")
        finally:
            if presentation is not None:
                presentation.dispose()
```

Untuk beban kerja produksi, catat pengecualian lengkap, tentukan apakah file output yang ada boleh ditimpa, dan tulis nama file yang gagal ke antrean retry atau review. File rusak, file yang dilindungi sandi yang dibuka tanpa sandi yang diperlukan, jalur yang tidak dapat diakses, dan konten yang tidak didukung semuanya dapat menyebabkan konversi gagal. Lihat [Password-Protected Presentations](/slides/id/python-java/password-protected-presentation/) untuk memuat file terenkripsi.

## **Fidelity dan Fitur Warisan**

Konversi biasanya mempertahankan slide, master, layout, teks, bentuk, gambar, tabel, dan diagram. Namun, PPT dan PPTX tidak mewakili setiap fitur dengan cara yang persis sama. Fitur warisan yang tidak memiliki padanan PPTX, atau tidak didukung oleh perpustakaan, mungkin dinormalisasi, dihilangkan, atau ditampilkan secara berbeda.

Periksa file yang telah dikonversi bila mengandung animasi, transisi, objek OLE yang disematkan atau ditautkan, kontrol ActiveX, media tersemat, font yang tidak umum, atau makro VBA. File PPTX biasa bukan format yang mendukung makro, jadi gunakan alur kerja yang mendukung makro bila VBA harus tetap tersedia. Juga verifikasi bahwa font yang diperlukan dan sumber daya eksternal ada di lingkungan tempat presentasi yang dikonversi akan dibuka atau dirender.

Untuk dokumen penting, buka kembali PPTX yang dihasilkan secara programatis dan inspeksi jumlah slide serta kontennya, lalu bandingkan tampilannya dan perilaku slide‑show di penampil yang dimaksud. Jangan menganggap panggilan [Presentation.save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save) yang berhasil sebagai bukti bahwa setiap fitur warisan memiliki representasi PPTX yang tepat.

## **Kapan Menggunakan PPTX**

Gunakan PPTX ketika presentasi akan diedit di versi PowerPoint saat ini, dipertukarkan dengan sistem yang bekerja dengan paket Open XML, atau disimpan dalam format yang lebih mudah diperiksa dan dipulihkan daripada PPT binari lama. Simpan PPT asli sebagai salinan arsip atau rollback sampai presentasi yang dikonversi telah melewati pemeriksaan fidelity Anda.

Jika Anda memerlukan PDF, HTML, gambar, XPS, atau tipe output lain, gunakan panduan spesifik format di [Convert Presentations to Multiple Formats](/slides/id/python-java/convert-presentation/) alih‑alih mengasumsikan bahwa semua target mempertahankan fitur PowerPoint yang dapat diedit.

## **Konverter Daring**

Untuk file sesekali atau perbandingan cepat, Anda dapat menggunakan [online PPT to PPTX converter](https://products.aspose.app/slides/id/conversion/ppt-to-pptx). Untuk konversi yang dapat diulang, pemrosesan batch, atau penanganan error tingkat aplikasi, gunakan API Python via Java.

## **Artikel Terkait**

- [PPT vs PPTX](/slides/id/python-java/ppt-vs-pptx/)
- [Save Presentations in Python](/slides/id/python-java/save-presentation/)
- [Supported File Formats](/slides/id/python-java/supported-file-formats/)
- [Open Presentations in Python](/slides/id/python-java/open-presentation/)

## **FAQ**

**Apakah saya dapat mengonversi PPT ke PPTX tanpa Microsoft PowerPoint terinstal?**

Ya. Aspose.Slides for Python via Java memuat dan menyimpan file presentasi tanpa memerlukan Microsoft PowerPoint.

**Apakah konversi PPT ke PPTX akan mempertahankan semua konten secara persis?**

Ini mempertahankan konten presentasi umum, tetapi fidelity yang tepat tidak dijamin untuk setiap fitur warisan atau yang tidak didukung. Tinjau file yang dihasilkan bila mengandung makro, objek OLE atau ActiveX, media, animasi khusus, atau font yang tidak umum.

**Apakah saya dapat mengonversi file PPT yang dilindungi sandi?**

Ya, jika Anda memberikan sandi yang tepat saat memuat file. Sandi yang hilang atau salah akan menyebabkan operasi pemuatan gagal.

**Haruskah saya menghapus file PPT setelah konversi?**

Simpan file asli sampai Anda memverifikasi PPTX di penampil dan alur kerja yang penting bagi Anda. Ini memberikan salinan rollback bila fitur warisan terkonversi secara berbeda.