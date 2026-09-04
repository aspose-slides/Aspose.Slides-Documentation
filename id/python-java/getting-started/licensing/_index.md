---
title: Lisensi
type: docs
weight: 80
url: /id/python-java/licensing/
keywords:
- Aspose.Slides
- Python
- Java
- file lisensi
- lisensi sementara
- lisensi bermeteran
- batasan evaluasi
description: "Terapkan lisensi berbentuk file, berbasis byte, atau bermeteran di Aspose.Slides for Python via Java dan hilangkan batasan evaluasi dari aplikasi Anda."
---
## **Gambaran Umum**

Aspose.Slides for Python via Java dapat dijalankan dalam mode evaluasi atau dengan lisensi. Artikel ini menjelaskan cara menerapkan lisensi dari file atau byte serta cara mengonfigurasi lisensi bermeteran.

Untuk opsi pembelian, lihat [Informasi Harga](https://purchase.aspose.com/pricing/slides/id/family). Untuk pertanyaan umum tentang lisensi dan pembelian, lihat [Kebijakan Pembelian dan FAQ](https://purchase.aspose.com/policies).

Untuk batasan evaluasi dan cara meminta lisensi sementara, lihat [Evaluasi Aspose.Slides](/slides/id/python-java/evaluate-aspose-slides/). Terapkan lisensi sementara dengan cara yang sama seperti file lisensi yang dibeli.

## **Tentang Lisensi**

File lisensi berisi informasi seperti nama produk, jumlah pengembang berlisensi, dan tanggal kedaluwarsa langganan. File tersebut adalah XML yang ditandatangani secara digital.

{{% alert color="warning" title="Warning" %}}
Jangan edit file lisensi. Bahkan tambahan baris kosong dapat membuat tanda tangan digitalnya tidak berlaku.
{{% /alert %}}

Terapkan lisensi satu kali per aplikasi atau proses, sebelum membuat presentasi atau melakukan operasi Aspose.Slides lainnya. Untuk file lisensi, gunakan kelas [License](https://reference.aspose.com/slides/id/python-java/aspose.slides/license/). Lisensi bermeteran menggunakan pasangan kunci publik dan privat alih-alih file lisensi.

## **Menerapkan Lisensi**

Contoh berikut mengasumsikan bahwa Aspose.Slides for Python via Java dan prasyaratnya telah terpasang. Setiap contoh adalah skrip mandiri yang memulai JVM, mengimpor API, dan menerapkan lisensi. Dalam aplikasi Anda, lakukan operasi presentasi setelah menerapkan lisensi dan matikan JVM hanya setelah semua pekerjaan Aspose.Slides selesai.

### **Menerapkan Lisensi dari File**

Berikan jalur file lisensi ke [License.setLicense](https://reference.aspose.com/slides/id/python-java/aspose.slides/license/#setLicense). Ganti `Aspose.Slides.lic` dengan jalur ke file lisensi Anda.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        license = License()
        license.setLicense(str(license_path))
        print("Licensed:", license.isLicensed())
        # Lakukan operasi presentasi di sini, sebelum mematikan JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Gunakan nama file yang tepat, termasuk ekstensi. Misalnya, jika file bernama `Aspose.Slides.lic.xml`, sertakan `.xml` dalam jalur. Jalur absolut menghindari ambiguitas tentang direktori kerja aplikasi.

Contoh ini menggunakan [License.isLicensed](https://reference.aspose.com/slides/id/python-java/aspose.slides/license/#isLicensed) untuk memeriksa apakah lisensi telah diterapkan.

### **Menerapkan Lisensi dari Byte**

Gunakan [License.setLicenseFromBytes](https://reference.aspose.com/slides/id/python-java/aspose.slides/license/#setLicenseFromBytes) ketika lisensi tersedia sebagai byte Python. Contoh berikut membaca file dalam mode biner dan menutupnya sebelum menerapkan lisensi.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        with license_path.open("rb") as license_file:
            license_data = license_file.read()

        license = License()
        license.setLicenseFromBytes(license_data)
        print("Licensed:", license.isLicensed())
        # Lakukan operasi presentasi di sini, sebelum mematikan JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Pertahankan byte asli tetap tidak berubah. Jangan melakukan decode, reformat, atau memodifikasi konten lisensi sebelum menerapkannya.

## **Menerapkan Lisensi Bermeteran**

Lisensi bermeteran menagih Anda berdasarkan penggunaan API. Setelah memperoleh lisensi bermeteran, terapkan kunci publik dan privatnya dengan [Metered.setMeteredKey](https://reference.aspose.com/slides/id/python-java/aspose.slides/metered/#setMeteredKey). Inisialisasi objek [Metered](https://reference.aspose.com/slides/id/python-java/aspose.slides/metered/) dan terapkan kunci satu kali saat aplikasi dimulai.

Contoh berikut membaca kunci dari variabel lingkungan `ASPOSE_METERED_PUBLIC_KEY` dan `ASPOSE_METERED_PRIVATE_KEY`. Tetapkan kedua variabel tersebut sebelum menjalankan skrip.

```python
import os

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Metered

    public_key = os.environ.get("ASPOSE_METERED_PUBLIC_KEY")
    private_key = os.environ.get("ASPOSE_METERED_PRIVATE_KEY")

    if public_key and private_key:
        metered = Metered()
        metered.setMeteredKey(public_key, private_key)
        # Lakukan operasi presentasi di sini, sebelum mematikan JVM.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Note" %}}
Lisensi bermeteran memerlukan koneksi Internet untuk memvalidasi kunci dan melaporkan penggunaan. Jaga agar kunci privat tidak berada dalam kode sumber dan log. Lihat [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) untuk detail konektivitas dan penagihan.
{{% /alert %}}

## **FAQ**

**Apakah saya harus menginstal paket yang berbeda setelah membeli lisensi?**

Tidak. Terapkan lisensi pada paket yang sama yang Anda gunakan untuk evaluasi.

**Apakah saya harus menerapkan lisensi untuk setiap presentasi?**

Tidak. Terapkan sekali saat aplikasi dimulai, sebelum membuat atau memuat presentasi.

**Apakah saya dapat mengganti nama file lisensi?**

Ya. Gunakan nama file baru yang tepat dalam kode Anda dan pertahankan isi file tidak berubah.

**Apakah saya dapat menggunakan lisensi sementara dengan contoh berbasis byte?**

Ya. Baca file lisensi sementara sebagai byte dan terapkan dengan cara yang sama seperti lisensi yang dibeli.