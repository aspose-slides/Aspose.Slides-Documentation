---
title: FAQ
type: docs
weight: 340
url: /id/python-java/faqs/
keywords:
- FAQ
- format presentasi
- kesalahan kehabisan memori
- ukuran slide
- ekstrak teks
- ukuran paragraf
- batas tabel
- font
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Temukan jawaban atas pertanyaan umum tentang Aspose.Slides untuk Python via Java, termasuk format file, penggunaan memori, ukuran slide, teks, tabel, gambar, dan font."
---
## **Ikhtisar**

FAQ ini mencakup format file yang didukung, penggunaan memori dengan presentasi besar, ukuran slide dan pratinjau, ekstraksi teks, batas tabel, penempatan gambar, serta perbedaan font saat mengonversi presentasi ke PDF atau gambar.

## **FAQ**

### **Format File yang Didukung**

**Format file apa yang didukung oleh Aspose.Slides untuk Python via Java?**

Lihat [Format File yang Didukung](/slides/id/python-java/supported-file-formats/) untuk format presentasi, dokumen, dan gambar yang didukung serta kemampuan impor dan ekspor mereka.

### **Pengecualian**

**Mengapa saya mendapatkan kesalahan out-of-memory saat memuat presentasi besar dengan gambar? Apakah ada batas ukuran file?**

Tidak ada ambang ukuran file tunggal yang dapat memprediksi apakah sebuah presentasi akan muat dalam memori. Kebutuhan memori bergantung pada struktur presentasi, gambar yang terdekompresi, efek, dan operasi yang Anda lakukan. Gambar dapat memakan memori jauh lebih besar daripada ukuran terkompresi mereka di disk.

Aspose.Slides untuk Python via Java menggunakan mesin Java melalui JPype, sehingga heap JVM harus memiliki ruang yang cukup untuk pemrosesan. RAM sistem yang tersedia tidak menunjukkan berapa banyak memori yang dapat digunakan JVM. Lepaskan presentasi dengan [Presentation.dispose](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#dispose) setelah selesai menggunakannya. Untuk pengaturan lingkungan, lihat [Persyaratan Sistem](/slides/id/python-java/system-requirements/) dan [Instalasi](/slides/id/python-java/installation/).

### **Bekerja dengan Slide**

**Apakah saya dapat mengubah ukuran slide dalam sebuah presentasi?**

Ya. Gunakan [Presentation.getSlideSize](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getslidesize) untuk mengakses pengaturan ukuran slide presentasi, lalu gunakan [SlideSize.setSize](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidesize/#setsize) untuk menetapkan dimensi dan memilih bagaimana konten yang ada diskalakan.

**Apakah slide dalam presentasi yang sama dapat memiliki ukuran berbeda?**

Tidak. Dokumen Microsoft PowerPoint menentukan ukuran slide pada level presentasi, sehingga semua slide berbagi dimensi yang sama.

**Apakah saya dapat melihat pratinjau slide sebelum menyimpan presentasi?**

Ya. Render slide menjadi gambar dan tampilkan gambar tersebut dalam aplikasi Anda. Anda tidak perlu menyimpan presentasi terlebih dahulu.

### **Bekerja dengan Teks**

**Apakah saya dapat mengambil semua teks dari sebuah presentasi?**

Ya. Kelas [SlideUtil](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideutil/) menyediakan metode untuk mengambil teks dari presentasi dan slide individual.

**Mengapa ukuran paragraf berbeda di Windows dan Linux?**

Dimensi paragraf bergantung pada metrik font yang digunakan untuk merender teks. Jika sebuah font tidak ada, font pengganti mungkin memiliki lebar karakter dan tinggi baris yang berbeda, yang mengubah pembungkus baris dan dimensi paragraf. Instal font yang sama di kedua sistem atau muat berkas font yang sama dengan [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsloader/#loadexternalfonts) sebelum membuat atau memuat presentasi.

### **Pemformatan dan Gambar**

**Bagaimana cara mengatur warna batas tabel?**

Gunakan [Cell.getCellFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/cell/#getcellformat) untuk mengakses pemformatan batas setiap sel dan tetapkan warna isi untuk batas yang relevan. Untuk mengubah semua batas, proses semua sel. Untuk mengubah hanya garis luar tabel, perbarui hanya batas yang menghadap ke luar pada sel-sel di tepinya.

**Unit apa yang digunakan untuk memposisikan dan mengukur gambar?**

Koordinat dan dimensi bentuk diukur dalam poin. Satu inci sama dengan 72 poin; nilai ini bukan koordinat piksel.

### **Bekerja dengan Font**

**Mengapa font berubah ketika saya mengonversi presentasi ke PDF atau gambar?**

Font yang diperlukan mungkin tidak ada pada mesin yang melakukan konversi. Instal font asli atau gunakan [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsloader/#loadexternalfonts) untuk menambahkan folder yang berisi font tersebut. Muat font eksternal sebelum membuat atau membuka presentasi.

Contoh berikut mendaftarkan folder font. Ganti jalur dengan folder yang ada yang berisi berkas font Anda. Contoh ini mengasumsikan lingkungan yang dijelaskan dalam [Instalasi](/slides/id/python-java/installation/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontsLoader

font_folders = jpype.JArray(jpype.JString)(["path_to_a_folder_with_fonts"])
FontsLoader.loadExternalFonts(font_folders)
```

Contoh ini membiarkan JVM tetap berjalan untuk operasi presentasi berikutnya. Untuk penggunaan notebook dan pembatasan siklus hidup JVM, lihat [Batasan dan Perbedaan API](/slides/id/python-java/limitations-and-api-differences/).