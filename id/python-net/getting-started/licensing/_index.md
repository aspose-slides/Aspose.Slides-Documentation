---
title: Lisensi
type: docs
weight: 80
url: /id/python-net/licensing/
keywords:
- lisensi
- lisensi sementara
- atur lisensi
- gunakan lisensi
- validasi lisensi
- file lisensi
- versi evaluasi
- Python
- Aspose.Slides
description: "Pelajari cara menerapkan, mengelola, dan memecahkan masalah lisensi di Aspose.Slides untuk Python via .NET. Pastikan akses tanpa gangguan ke semua fitur dengan panduan lisensi langkah demi langkah kami."
---
## **Ikhtisar**

Aspose.Slides dapat digunakan dalam mode evaluasi atau dengan lisensi yang valid. Versi evaluasi menyediakan fungsi yang sama seperti versi berlisensi, tetapi menambahkan watermark evaluasi ketika presentasi dibuka atau disimpan dan membatasi ekstraksi teks ke satu slide.

## **Mengevaluasi Aspose.Slides**

Anda dapat mengunduh versi evaluasi **Aspose.Slides for Python via .NET** dari [halaman unduhan](https://pypi.org/project/Aspose.Slides/). Versi evaluasi menyediakan fitur yang sama dengan produk berlisensi. Paket evaluasi identik dengan paket yang dibeli dan menjadi berlisensi setelah Anda menambahkan beberapa baris kode untuk menerapkan lisensi.

Setelah Anda puas dengan evaluasi **Aspose.Slides**, Anda dapat [membeli lisensi](https://purchase.aspose.com/buy). Kami merekomendasikan meninjau opsi langganan yang tersedia. Jika Anda memiliki pertanyaan, hubungi tim penjualan Aspose.

Setiap lisensi Aspose mencakup langganan satu tahun dengan peningkatan gratis ke versi baru dan perbaikan yang dirilis selama periode tersebut. Baik pengguna berlisensi maupun evaluasi menerima dukungan teknis gratis tak terbatas.

**Batasan Versi Evaluasi**

* Meskipun versi evaluasi Aspose.Slides (saat tidak ada lisensi yang diterapkan) menyediakan fungsionalitas penuh, ia menambahkan watermark evaluasi di bagian atas dokumen setiap kali Anda membukanya atau menyimpannya.
* Saat mengekstrak teks dari presentasi, Anda dibatasi hanya satu slide.

{{% alert color="primary" %}}
Untuk menguji Aspose.Slides tanpa batasan, Anda dapat meminta **Lisensi Sementara 30‑hari**. Lihat halaman [How to Get a Temporary License](https://purchase.aspose.com/temporary-license) untuk detailnya.
{{% /alert %}}

## **Lisensi di Aspose.Slides**

* Versi evaluasi menjadi berlisensi setelah Anda membeli lisensi dan menambahkan beberapa baris kode untuk menerapkannya.
* Lisensi adalah file XML teks biasa yang berisi detail seperti nama produk, jumlah pengembang yang dicakup, tanggal kedaluwarsa langganan, dan sebagainya.
* File lisensi ditandatangani secara digital, jadi Anda tidak boleh mengubahnya. Bahkan menambahkan satu baris baru saja akan membuatnya tidak valid.
* Aspose.Slides for Python via .NET biasanya mencari lisensi di lokasi berikut:
  * Jalur eksplisit yang Anda berikan
  * Folder yang berisi skrip Python yang memanggil Aspose.Slides for Python via .NET
* Untuk menghindari batasan evaluasi, tetapkan lisensi sebelum menggunakan Aspose.Slides. Anda hanya perlu menetapkannya sekali per aplikasi atau proses.

{{% alert color="primary" %}}
Anda mungkin juga ingin meninjau [Metered Licensing](/slides/id/python-net/metered-licensing/).
{{% /alert %}}

## **Menerapkan Lisensi**

Lisensi dapat dimuat dari **file**, **stream**, atau **resource tertanam**. 

{{% alert color="primary" %}}
Aspose.Slides menyediakan kelas [License](https://reference.aspose.com/slides/id/python-net/aspose.slides/license/) untuk menangani lisensi.
{{% /alert %}}

{{% alert color="warning" %}}
Lisensi baru dapat mengaktifkan Aspose.Slides hanya dengan versi 21.4 atau yang lebih baru. Versi sebelumnya menggunakan sistem lisensi yang berbeda dan tidak akan mengenali lisensi ini.
{{% /alert %}}

### **File**

Cara termudah untuk menetapkan lisensi adalah menempatkan file lisensi di folder yang sama dengan DLL komponen dan menyebutkan hanya nama file (tanpa jalur).

Kode Python berikut menunjukkan cara menetapkan file lisensi:

```py
import aspose.slides as slides

# Membuat instance kelas License. 
license = slides.License()

# Mengatur jalur file lisensi.
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" %}}
Jika Anda menempatkan file lisensi di direktori lain, ketika Anda memanggil [License.set_license()](https://reference.aspose.com/slides/id/python-net/aspose.slides/license/set_license/#str), nama file di akhir jalur eksplisit harus cocok dengan nama file lisensi Anda.

Sebagai contoh, Anda dapat mengganti nama file lisensi menjadi *Aspose.Slides.lic.xml*. Kemudian, dalam kode Anda, berikan jalur lengkap ke file tersebut (yang berakhir dengan Aspose.Slides.lic.xml) ke metode [License.set_license()](https://reference.aspose.com/slides/id/python-net/aspose.slides/license/set_license/#str).
{{% /alert %}}

### **Stream**

Anda dapat memuat lisensi dari stream. Contoh Python berikut menunjukkan cara menerapkan lisensi dari stream:

```py
import aspose.slides as slides

# Membuat instance kelas License.
license = slides.License()

# Mengatur lisensi dari stream.
license.set_license(stream)
```

## **Mvalidasi Lisensi**

Untuk memverifikasi bahwa lisensi telah diterapkan dengan benar, Anda dapat memvalidasinya. Kode Python berikut menunjukkan cara memvalidasi lisensi:

```py
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("License is good!")
```

## **Keamanan Thread**

{{% alert title="Catatan" color="warning" %}}
Metode [License.set_license](https://reference.aspose.com/slides/id/python-net/aspose.slides/license/) tidak thread‑safe. Jika harus dipanggil secara bersamaan dari beberapa thread, gunakan primitif sinkronisasi (misalnya `threading.Lock`) untuk menghindari masalah.
{{% /alert %}}

## **FAQ**

**Apakah saya dapat menerapkan lisensi di lingkungan yang sepenuhnya offline (tanpa akses internet)?**

Ya. Validasi lisensi dilakukan secara lokal menggunakan file lisensi; tidak diperlukan koneksi internet.

**Apa yang terjadi setelah langganan satu tahun berakhir? Apakah pustaka akan berhenti bekerja?**

Tidak. Lisensi bersifat permanen: Anda dapat terus menggunakan versi yang dirilis sebelum tanggal berakhirnya langganan Anda; Anda hanya tidak akan bisa menggunakan rilis yang lebih baru tanpa memperbarui langganan.