---
title: Lisensi
type: docs
weight: 80
url: /id/python-net/licensing/
keywords:
- lisensi
- lisensi sementara
- set lisensi
- gunakan lisensi
- validasi lisensi
- file lisensi
- versi evaluasi
- Python
- Aspose.Slides
description: "Pelajari cara menerapkan, mengelola, dan memecahkan masalah lisensi di Aspose.Slides untuk Python via .NET. Pastikan akses tanpa gangguan ke semua fitur dengan panduan lisensi langkah demi langkah kami."
---
## **Gambaran Umum**

Aspose.Slides dapat digunakan dalam mode evaluasi atau dengan lisensi yang sah. Versi evaluasi menyediakan fungsionalitas yang sama dengan versi berlisensi, tetapi menambahkan tanda air evaluasi pada setiap slide dari setiap presentasi yang disimpan dan memotong teks yang dibaca kode Anda dari presentasi.

## **Evaluasi Aspose.Slides**

Anda dapat mengunduh versi evaluasi **Aspose.Slides for Python via .NET** dari [halaman unduhan](https://pypi.org/project/Aspose.Slides/). Versi evaluasi menyediakan fitur yang sama dengan produk berlisensi. Paket evaluasi identik dengan paket yang dibeli dan menjadi berlisensi setelah Anda menambahkan beberapa baris kode untuk menerapkan lisensi.

Ketika Anda puas dengan evaluasi **Aspose.Slides**, Anda dapat [membeli lisensi](https://purchase.aspose.com/pricing/slides/id/python-net/). Kami menyarankan meninjau opsi langganan yang tersedia. Jika Anda memiliki pertanyaan, hubungi tim penjualan Aspose.

Setiap lisensi Aspose mencakup langganan satu tahun dengan peningkatan gratis ke versi baru dan perbaikan yang dirilis selama periode tersebut. Baik pengguna berlisensi maupun evaluasi menerima dukungan teknis gratis dan tak terbatas.

**Batasan Versi Evaluasi**

* Versi evaluasi (ketika tidak ada lisensi yang diterapkan) menyediakan fungsionalitas penuh, tetapi menambahkan kotak teks tanda air evaluasi pada setiap slide dari setiap presentasi yang disimpan.
* Teks yang dibaca kode Anda dari sebuah presentasi dipotong menjadi beberapa karakter pertama, diikuti oleh pemberitahuan tentang batasan evaluasi. Teks yang ditulis kode Anda disimpan secara lengkap.

{{% alert color="info" title="Note" %}}
Untuk menguji Aspose.Slides tanpa batasan, Anda dapat meminta **Lisensi Sementara 30‑hari**. Lihat halaman [How to Get a Temporary License](https://purchase.aspose.com/temporary-license) untuk detailnya.
{{% /alert %}}

## **Lisensi di Aspose.Slides**

* Versi evaluasi menjadi berlisensi setelah Anda membeli lisensi dan menambahkan beberapa baris kode untuk menerapkannya.
* Lisensi adalah file XML teks biasa yang berisi detail seperti nama produk, jumlah pengembang yang dicakup, tanggal kedaluwarsa langganan, dan sebagainya.
* File lisensi ditandatangani secara digital, jadi Anda tidak boleh memodifikasinya. Bahkan menambahkan satu baris kosong akan membuatnya tidak sah.
* Aspose.Slides for Python via .NET mencari lisensi pada jalur yang Anda berikan. Jalur relatif, atau nama file tanpa jalur, diresolusikan terhadap direktori kerja saat ini, yang tidak selalu merupakan folder yang berisi skrip Python Anda.
* Untuk menghindari batasan evaluasi, tetapkan lisensi sebelum menggunakan Aspose.Slides. Anda hanya perlu menentukannya sekali per aplikasi atau proses.

{{% alert color="info" title="Note" %}}
Anda mungkin juga ingin meninjau [Metered Licensing](/slides/id/python-net/metered-licensing/).
{{% /alert %}}

## **Menerapkan Lisensi**

Lisensi dapat dimuat dari sebuah **berkas** atau sebuah **stream**.

{{% alert color="info" title="Note" %}}
Aspose.Slides menyediakan kelas [License](https://reference.aspose.com/slides/id/python-net/aspose.slides/license/) untuk menangani lisensi.
{{% /alert %}}

{{% alert color="warning" title="Warning" %}}
Lisensi baru dapat mengaktifkan Aspose.Slides hanya dengan versi 21.4 atau lebih baru. Versi sebelumnya menggunakan sistem lisensi yang berbeda dan tidak akan mengenali lisensi ini.
{{% /alert %}}

### **Berkas**

Cara paling sederhana untuk menetapkan lisensi adalah dengan memberikan jalur file lisensi ke metode [set_license](https://reference.aspose.com/slides/id/python-net/aspose.slides/license/set_license/). Jika Anda hanya memberikan nama file, seperti pada contoh di bawah, Aspose.Slides mencari file tersebut di direktori kerja saat ini.

Kode Python berikut menunjukkan cara menetapkan file lisensi:

```py
import aspose.slides as slides

# Membuat instance kelas License. 
license = slides.License()

# Menetapkan jalur file lisensi.
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" title="Warning" %}}
Jika Anda menempatkan file lisensi di direktori yang berbeda, ketika Anda memanggil [License.set_license](https://reference.aspose.com/slides/id/python-net/aspose.slides/license/set_license/#str), nama file di akhir jalur eksplisit harus cocok dengan nama file lisensi Anda.

Sebagai contoh, Anda dapat mengganti nama file lisensi menjadi *Aspose.Slides.lic.xml*. Kemudian, dalam kode Anda, berikan jalur lengkap ke file tersebut (berakhiran Aspose.Slides.lic.xml) ke metode [License.set_license](https://reference.aspose.com/slides/id/python-net/aspose.slides/license/set_license/#str).
{{% /alert %}}

### **Stream**

Anda dapat memuat lisensi dari sebuah stream. Contoh Python berikut menunjukkan cara menerapkan lisensi dari stream:

```py
import aspose.slides as slides

# Membuat instance kelas License.
license = slides.License()

# Menetapkan lisensi dari stream.
with open("Aspose.Slides.lic", "rb") as stream:
    license.set_license(stream)
```

## **Memvalidasi Lisensi**

Untuk memverifikasi bahwa lisensi telah diterapkan dengan benar, Anda dapat memvalidasinya. Kode Python berikut mendemonstrasikan cara memvalidasi lisensi:

```py
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("License is good!")
```

## **Keamanan Thread**

{{% alert color="warning" title="Warning" %}}
Metode [License.set_license](https://reference.aspose.com/slides/id/python-net/aspose.slides/license/set_license/) tidak aman untuk thread. Jika Anda perlu memanggilnya secara bersamaan dari beberapa thread, gunakan primitif sinkronisasi, seperti `threading.Lock`, untuk menghindari masalah.
{{% /alert %}}

## **FAQ**

### Bisakah saya menerapkan lisensi dalam lingkungan yang sepenuhnya offline (tanpa akses internet)?

Ya. Validasi lisensi dilakukan secara lokal menggunakan file lisensi; tidak diperlukan koneksi internet.

### Apa yang terjadi setelah langganan satu tahun berakhir? Apakah perpustakaan akan berhenti berfungsi?

Tidak. Lisensi bersifat perpetual: Anda dapat terus menggunakan versi yang dirilis sebelum tanggal berakhirnya langganan; Anda hanya tidak akan dapat menggunakan rilis yang lebih baru tanpa memperbarui langganan.