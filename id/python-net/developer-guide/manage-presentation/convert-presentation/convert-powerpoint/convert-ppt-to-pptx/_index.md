---
title: Mengonversi PPT ke PPTX di Python
linktitle: PPT ke PPTX
type: docs
weight: 20
url: /id/python-net/convert-ppt-to-pptx/
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
- Aspose.Slides
description: "Konversi file PPT warisan ke PPTX di Python dengan Aspose.Slides. Menyertakan contoh untuk konversi satu file dan batch, penanganan error, serta catatan kesetiaan."
---
## **Ringkasan**

PPT adalah format PowerPoint biner warisan, sedangkan PPTX adalah format Open XML yang lebih baru. Aspose.Slides for Python via .NET dapat memuat file PPT dan menyimpannya sebagai PPTX tanpa Microsoft PowerPoint. Artikel ini menunjukkan cara mengonversi satu file atau direktori file dan menjelaskan apa yang harus diverifikasi setelah konversi.

## **Mengonversi File PPT ke PPTX**

Muat file sumber dengan kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) kemudian panggil [Presentation.save](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/save/) dengan [SaveFormat.PPTX](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/saveformat/). Pernyataan `with` membuang presentasi dan melepaskan sumber dayanya ketika blok berakhir.

```python
import aspose.slides as slides

# Muat presentasi PPT warisan.
with slides.Presentation("presentation.ppt") as presentation:
    # Simpan presentasi dalam format PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

Ekstensi file tidak memilih format output secara otomatis; argumen [SaveFormat.PPTX](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/saveformat/) melakukannya. Jaga agar jalur input dan output berbeda jika Anda perlu mempertahankan file PPT asli.

## **Mengonversi Beberapa File PPT**

Contoh berikut mengonversi setiap file `.ppt` dalam satu direktori. Setiap file diproses secara independen, sehingga satu konversi yang gagal tidak menghentikan batch yang lain.

```python
from pathlib import Path

import aspose.slides as slides

input_directory = Path("input")
output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

for input_path in input_directory.glob("*.ppt"):
    output_path = output_directory / f"{input_path.stem}.pptx"

    try:
        with slides.Presentation(str(input_path)) as presentation:
            presentation.save(str(output_path), slides.export.SaveFormat.PPTX)
        print(f"Converted: {input_path}")
    except Exception as exception:
        print(f"Failed: {input_path} ({exception})")
```

Untuk beban kerja produksi, catat pengecualian lengkap, tentukan apakah file output yang ada dapat ditimpa, dan tulis nama file yang gagal ke antrean coba ulang atau tinjauan. File yang rusak, file yang dilindungi kata sandi yang dibuka tanpa kata sandi yang diperlukan, jalur yang tidak dapat diakses, dan konten yang tidak didukung semuanya dapat menyebabkan konversi gagal. Lihat [Password-Protected Presentations](/slides/id/python-net/password-protected-presentation/) untuk memuat file terenkripsi.

## **Kesetiaan dan Fitur Warisan**

Konversi biasanya mempertahankan slide, master, tata letak, teks, bentuk, gambar, tabel, dan diagram. Namun, PPT dan PPTX tidak merepresentasikan setiap fitur dengan cara yang persis sama. Fitur warisan yang tidak memiliki padanan PPTX, atau tidak didukung oleh pustaka, dapat dinormalisasi, dihilangkan, atau ditampilkan secara berbeda.

Periksa file yang dikonversi ketika mengandung animasi, transisi, objek OLE yang tertanam atau ditautkan, kontrol ActiveX, media tertanam, font yang tidak umum, atau makro VBA. File PPTX biasa bukan format yang mendukung makro, jadi gunakan alur kerja yang mendukung makro yang sesuai bila VBA harus tetap tersedia. Juga verifikasi bahwa font yang diperlukan dan sumber daya eksternal ada di lingkungan tempat presentasi yang dikonversi akan dibuka atau dirender.

Untuk dokumen penting, buka kembali PPTX yang dihasilkan secara programatis dan periksa jumlah slide utama serta kontennya, kemudian bandingkan tampilan dan perilaku slide-show-nya di penampil yang dimaksud. Jangan menganggap panggilan [Presentation.save](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/save/) yang berhasil sebagai bukti bahwa setiap fitur warisan memiliki representasi PPTX yang tepat.

## **Kapan Menggunakan PPTX**

Gunakan PPTX ketika presentasi akan diedit dalam versi PowerPoint terbaru, dipertukarkan dengan sistem yang bekerja dengan paket Open XML, atau disimpan dalam format yang lebih mudah diperiksa dan dipulihkan dibandingkan PPT biner warisan. Simpan PPT asli sebagai salinan arsip atau rollback sampai presentasi yang dikonversi telah lulus pemeriksaan kesetiaan Anda.

Jika Anda memerlukan PDF, HTML, gambar, XPS, atau tipe output lain, gunakan panduan format-spesifik di [Convert Presentations to Multiple Formats](/slides/id/python-net/convert-presentation/) alih-alih mengasumsikan semua target mempertahankan fitur PowerPoint yang dapat diedit.

## **Konverter Online**

Untuk file sesekali atau perbandingan cepat, Anda dapat menggunakan [online PPT to PPTX converter](https://products.aspose.app/slides/id/conversion/ppt-to-pptx). Untuk konversi berulang, pemrosesan batch, atau penanganan error tingkat aplikasi, gunakan API Python.

## **Artikel Terkait**

- [PPT vs PPTX](/slides/id/python-net/ppt-vs-pptx/)
- [Simpan Presentasi di Python](/slides/id/python-net/save-presentation/)
- [Format File yang Didukung](/slides/id/python-net/supported-file-formats/)
- [Buka Presentasi di Python](/slides/id/python-net/open-presentation/)

## **FAQ**

**Bisakah saya mengonversi PPT ke PPTX tanpa Microsoft PowerPoint terpasang?**

Ya. Aspose.Slides for Python via .NET memuat dan menyimpan file presentasi tanpa memerlukan Microsoft PowerPoint.

**Apakah konversi PPT ke PPTX akan mempertahankan semua konten secara tepat?**

Ia mempertahankan konten presentasi umum, namun kesetiaan yang tepat tidak dijamin untuk setiap fitur warisan atau yang tidak didukung. Tinjau file yang dihasilkan ketika mengandung makro, objek OLE atau ActiveX, media, animasi khusus, atau font yang tidak umum.

**Bisakah saya mengonversi file PPT yang dilindungi kata sandi?**

Ya, jika Anda menyediakan kata sandi yang benar saat memuat file. Kata sandi yang hilang atau salah menyebabkan operasi pemuatan gagal.

**Haruskah saya menghapus file PPT setelah konversi?**

Simpan yang asli sampai Anda memverifikasi PPTX di penampil dan alur kerja yang penting bagi Anda. Ini memberikan salinan rollback jika fitur warisan dikonversi secara berbeda.