---
title: Lisensi
description: "Aspose.Slides untuk Python via Java menyediakan berbagai rencana pembelian atau menawarkan Uji Coba Gratis dan Lisensi Sementara 30 hari untuk evaluasi menggunakan kebijakan Lisensi dan Langganan."
type: docs
weight: 80
url: /id/python-java/licensing/
---
Kadang‑kadang, untuk hasil evaluasi yang terbaik, pendekatan langsung mungkin diperlukan. Karena itu, Aspose.Slides menyediakan berbagai rencana pembelian serta menawarkan Uji Coba Gratis dan Lisensi Sementara 30‑hari untuk evaluasi.

{{% alert color="primary" %}}
Perhatikan bahwa terdapat sejumlah kebijakan dan praktik umum yang membimbing Anda tentang cara mengevaluasi, melisensikan dengan benar, dan membeli produk kami. Anda dapat menemukannya di bagian ["Purchase Policies and FAQ"](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Evaluasi Aspose.Slides**
Anda dapat dengan mudah mengunduh Aspose.Slides untuk evaluasi. Paket evaluasi sama dengan paket yang dibeli. Versi evaluasi hanya perlu dilisensikan dengan menambahkan beberapa baris kode untuk menerapkan lisensi. 

## **Batasan Versi Evaluasi**
Versi evaluasi Aspose.Slides (tanpa lisensi yang ditentukan) menyediakan semua fungsi produk, namun menambahkan watermark evaluasi di bagian atas dokumen saat dibuka dan disimpan. Anda juga dibatasi hanya satu slide ketika mengekstrak teks dari slide presentasi.

{{% alert color="primary" %}} 
Jika Anda ingin menguji Aspose.Slides tanpa batasan versi evaluasi, Anda dapat meminta **Lisensi Sementara 30 Hari**. Silakan lihat [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) untuk informasi lebih lanjut.
{{% /alert %}} 

## **Tentang Lisensi**
Anda dapat dengan mudah mengunduh versi evaluasi Aspose.Slides untuk Python via Java dari [halaman unduhan](https://releases.aspose.com/slides/id/python-java/). Versi evaluasi sepenuhnya **memiliki kemampuan yang sama** dengan versi berlisensi Aspose.Slides. Selain itu, versi evaluasi hanya perlu dilisensikan setelah Anda membeli lisensi dan menambahkan beberapa baris kode untuk menerapkan lisensi.

Lisensi adalah file XML teks biasa yang berisi detail seperti nama produk, jumlah pengembang yang dilisensikan, tanggal kedaluwarsa langganan, dan lain‑lain. File ini ditandatangani secara digital, jadi jangan memodifikasinya. Bahkan penambahan baris kosong secara tidak sengaja ke dalam isi file akan membuatnya tidak berlaku.

Untuk menghindari batasan terkait versi evaluasi, Anda harus mengatur lisensi sebelum menggunakan **Aspose.Slides**. Anda hanya perlu mengatur lisensi sekali per aplikasi atau proses.

## Lisensi yang Dibeli

Setelah pembelian, Anda harus menerapkan file atau aliran lisensi. 

{{% alert color="primary" %}}
Anda perlu mengatur lisensi:
* hanya sekali per domain aplikasi
* sebelum menggunakan kelas Aspose.Slides lainnya
{{% /alert %}}

{{% alert color="primary" %}}
Anda dapat menemukan informasi harga pada halaman [“Pricing Information”](https://purchase.aspose.com/pricing/slides/id/family).
{{% /alert %}}

### **Mengatur Lisensi di Aspose.Slides untuk Python via Java**

Lisensi dapat diterapkan dari lokasi berikut:

* Jalur eksplisit
* Aliran
* Sebagai Lisensi Metered – mekanisme lisensi baru

{{% alert color="primary" %}}
Gunakan metode **setLicense** untuk melisensikan sebuah komponen.

Meskipun memanggil **setLicense** berkali‑kali tidak berbahaya, hal itu membuang sumber daya (processor).
{{% /alert %}}

{{% alert color="warning" %}}
Lisensi baru hanya dapat mengaktifkan Aspose.Slides dengan versi 21.4 atau yang lebih baru. Versi sebelumnya menggunakan sistem lisensi yang berbeda dan tidak akan mengenali lisensi ini.
{{% /alert %}}

#### **Menerapkan Lisensi Menggunakan File**

Potongan kode ini digunakan untuk mengatur file lisensi:

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
pres = Presentation()
license.setLicense("Aspose.Slides.lic");

jpype.shutdownJVM()
```

Saat memanggil metode setLicense, nama lisensi harus sama dengan nama file lisensi Anda. Misalnya, Anda dapat mengubah nama file lisensi menjadi "Aspose.Slides.lic.xml". Kemudian, dalam kode Anda, Anda harus menyertakan nama lisensi baru (Aspose.Slides.lic.xml) ke metode setLicense.

#### **Menerapkan Lisensi dari Byte**

Potongan kode ini digunakan untuk menerapkan lisensi dari byte:

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
input = open("Aspose.Slides.lic", mode="rb")
data = input.read()
pres = Presentation()
license.setLicenseFromBytes(data);

jpype.shutdownJVM()
```

#### Terapkan Lisensi Metered

Aspose.Slides memungkinkan pengembang menerapkan kunci metered. Ini merupakan mekanisme lisensi baru.

Mekanisme lisensi baru akan digunakan bersamaan dengan metode lisensi yang ada. Pelanggan yang ingin ditagih berdasarkan penggunaan fitur API dapat menggunakan Lisensi Metered.

Setelah menyelesaikan semua langkah yang diperlukan untuk memperoleh jenis lisensi ini, Anda akan menerima kunci, bukan file lisensi. Kunci metered ini dapat diterapkan menggunakan kelas **Metered** yang khusus diperkenalkan untuk tujuan ini.

Contoh kode berikut menunjukkan cara mengatur kunci publik dan privat metered:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, Metered, SaveFormat

# Buat instance dari kelas CAD Metered
metered = Metered();

# Akses properti set_metered_key dan lewati kunci publik serta privat sebagai parameter
metered.setMeteredKey("*****", "*****");

# Dapatkan jumlah data metered sebelum memanggil API
amountbefore = Metered.getConsumptionQuantity()

# Tampilkan informasi
print("Amount Consumed Before: \" + amountbefore + \"" )

# Muat dokumen dari disk.
pres = Presentation();

# Dapatkan jumlah halaman dokumen
print("Amount Consumed After: \" +  pres.getSlides().size()) + \"" )

# simpan sebagai PDF
pres.save("out_pdf.pdf", SaveFormat.Pdf);

# Dapatkan jumlah data metered setelah memanggil API
amountafter = Metered.getConsumptionQuantity()

# Tampilkan informasi
print("Amount Consumed After: \" + amountafter + \"" )

jpype.shutdownJVM()
```

{{% alert color="primary" %}}
Harap perhatikan bahwa Anda harus memiliki koneksi Internet yang stabil untuk penggunaan lisensi Metered yang tepat, karena mekanisme Metered memerlukan interaksi terus‑menerus dengan layanan kami untuk perhitungan yang benar. Untuk detail lebih lanjut, lihat bagian [“Metered Licensing FAQ”](https://purchase.aspose.com/faqs/licensing/metered).
{{% /alert %}}