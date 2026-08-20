---
title: Mengonversi PPT ke PPTX dengan Python
linktitle: PPT ke PPTX
type: docs
weight: 20
url: /id/python-net/convert-ppt-to-pptx/
keywords:
- mengonversi PowerPoint
- mengonversi presentasi
- mengonversi slide
- mengonversi PPT
- PPT ke PPTX
- menyimpan PPT sebagai PPTX
- mengekspor PPT ke PPTX
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Mengonversi file PPT warisan ke PPTX dalam Python dengan Aspose.Slides. Menyertakan contoh untuk konversi satu file dan batch, penanganan kesalahan, serta catatan fidelitas."
---
## **Gambaran Umum**

PPT adalah format PowerPoint biner warisan, sedangkan PPTX adalah format Open XML yang lebih baru. Aspose.Slides for Python via .NET dapat memuat file PPT dan menyimpannya sebagai PPTX tanpa Microsoft PowerPoint. Artikel ini menunjukkan cara mengonversi satu file atau direktori file dan menjelaskan hal apa yang harus diverifikasi setelah konversi.

## **Mengonversi File PPT ke PPTX**

Muat file sumber dengan kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/), lalu panggil [Presentation.save](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/save/) dengan [SaveFormat.PPTX](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/saveformat/). Pernyataan `with` membuang objek presentasi dan melepaskan sumber dayanya ketika blok selesai.

```python
import aspose.slides as slides

# Muat presentasi PPT warisan.
with slides.Presentation("presentation.ppt") as presentation:
    # Simpan presentasi dalam format PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

Ekstensi file tidak memilih format output secara otomatis; argumen [SaveFormat.PPTX](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/saveformat/) melakukannya. Jaga agar jalur input dan output berbeda jika Anda perlu mempertahankan file PPT asli.

## **Mengonversi Beberapa File PPT**

Contoh berikut mengonversi setiap file `.ppt` dalam satu direktori. Setiap file diproses secara independen, sehingga satu konversi yang gagal tidak menghentikan batch sisanya.

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

Untuk beban kerja produksi, catat pengecualian secara lengkap, tentukan apakah file output yang ada boleh ditimpa, dan tulis nama file yang gagal ke antrean retry atau review. File yang rusak, file yang dilindungi kata sandi yang dibuka tanpa kata sandi yang diperlukan, jalur yang tidak dapat diakses, dan konten yang tidak didukung semuanya dapat menyebabkan konversi gagal. Lihat [Presentasi yang Dilindungi Kata Sandi](/python-net/password-protected-presentation/) untuk memuat file terenkripsi.

## **Fidelitas dan Fitur Warisan**

Konversi biasanya mempertahankan slide, master, tata letak, teks, bentuk, gambar, tabel, dan diagram. Namun, PPT dan PPTX tidak merepresentasikan setiap fitur dengan cara yang persis sama. Fitur warisan yang tidak memiliki padanan PPTX, atau tidak didukung oleh pustaka, dapat dinormalisasi, dihilangkan, atau ditampilkan secara berbeda.

Periksa file yang dikonversi bila berisi animasi, transisi, objek OLE yang disematkan atau ditautkan, kontrol ActiveX, media yang disematkan, font yang tidak umum, atau makro VBA. File PPTX biasa bukan format yang mendukung makro, jadi gunakan alur kerja yang mendukung makro bila VBA harus tetap tersedia. Juga pastikan bahwa font yang diperlukan dan sumber daya eksternal ada di lingkungan tempat presentasi yang dikonversi akan dibuka atau dirender.

Untuk dokumen penting, buka kembali PPTX yang dihasilkan secara programatis dan periksa jumlah slide utama serta kontennya, kemudian bandingkan tampilan dan perilaku slide-show‑nya pada penampil yang dimaksud. Jangan anggap pemanggilan [Presentation.save](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/save/) yang berhasil sebagai bukti bahwa setiap fitur warisan memiliki representasi PPTX yang tepat.

## **Kapan Menggunakan PPTX**

Gunakan PPTX ketika presentasi akan diedit di versi PowerPoint terkini, dipertukarkan dengan sistem yang bekerja dengan paket Open XML, atau disimpan dalam format yang lebih mudah diperiksa dan dipulihkan dibandingkan PPT biner warisan. Simpan PPT asli sebagai salinan arsip atau cadangan sampai presentasi yang dikonversi melewati pemeriksaan fidelitas Anda.

Jika Anda membutuhkan PDF, HTML, gambar, XPS, atau tipe output lain sebagai gantinya, gunakan panduan khusus format di [Mengonversi Presentasi ke Berbagai Format](/python-net/convert-presentation/) alih-alih mengasumsikan bahwa semua target mempertahankan fitur PowerPoint yang dapat diedit.

## **Konverter Daring**

Untuk file sesekali atau perbandingan cepat, Anda dapat menggunakan [konverter PPT ke PPTX daring](https://products.aspose.app/slides/id/conversion/ppt-to-pptx). Untuk konversi berulang, pemrosesan batch, atau penanganan kesalahan tingkat aplikasi, gunakan API Python.

## **Artikel Terkait**

- [PPT vs PPTX](/python-net/ppt-vs-pptx/)
- [Simpan Presentasi di Python](/python-net/save-presentation/)
- [Format File yang Didukung](/python-net/supported-file-formats/)
- [Buka Presentasi di Python](/python-net/open-presentation/)

## **FAQ**

**Bisakah saya mengonversi PPT ke PPTX tanpa Microsoft PowerPoint terpasang?**

Ya. Aspose.Slides for Python via .NET memuat dan menyimpan file presentasi tanpa memerlukan Microsoft PowerPoint.

**Apakah konversi PPT ke PPTX akan mempertahankan semua konten secara persis?**

Ia mempertahankan konten presentasi umum, tetapi fidelitas yang persis tidak dijamin untuk setiap fitur warisan atau yang tidak didukung. Tinjau file yang dihasilkan bila berisi makro, objek OLE atau ActiveX, media, animasi khusus, atau font yang tidak umum.

**Bisakah saya mengonversi file PPT yang dilindungi kata sandi?**

Ya, jika Anda memberikan kata sandi yang benar saat memuat file. Kata sandi yang hilang atau salah menyebabkan operasi pemuatan gagal.

**Haruskah saya menghapus file PPT setelah konversi?**

Simpan yang asli sampai Anda memverifikasi PPTX pada penampil dan alur kerja yang penting bagi Anda. Ini menyediakan salinan cadangan bila fitur warisan dikonversi secara berbeda.