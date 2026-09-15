---
title: Lisensi Metered
type: docs
weight: 100
url: /id/python-java/metered-licensing/
keywords:
- lisensi
- lisensi metered
- kunci lisensi
- kunci publik
- kunci privat
- kuantitas konsumsi
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara Aspose.Slides untuk Python via Java dengan lisensi metered memungkinkan Anda memproses file PowerPoint dan OpenDocument secara fleksibel, hanya membayar sesuai penggunaan."
---
## **Pendahuluan**

Lisensi metered adalah mekanisme lisensi yang dapat digunakan bersama metode lisensi yang ada. Jika Anda ingin ditagih berdasarkan penggunaan fitur API Aspose.Slides, pilih lisensi metered.

## **Terapkan Kunci Metered**

{{% alert color="info" title="Catatan" %}}

Lisensi metered adalah mekanisme lisensi baru yang dapat digunakan bersama metode lisensi yang ada. Jika Anda ingin ditagih berdasarkan penggunaan fitur API Aspose.Slides, pilih lisensi metered.

Saat Anda membeli lisensi metered, Anda menerima kunci (bukan file lisensi). Kunci metered ini dapat diterapkan menggunakan kelas [Metered](https://reference.aspose.com/slides/id/python-java/aspose.slides/metered/) yang disediakan oleh Aspose untuk operasi metering. Untuk detail lebih lanjut, lihat [FAQ Lisensi Metered](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}}

1. Buat sebuah instance dari kelas [Metered](https://reference.aspose.com/slides/id/python-java/aspose.slides/metered/).

1. Berikan kunci publik dan privat Anda ke metode [setMeteredKey](https://reference.aspose.com/slides/id/python-java/aspose.slides/metered/#setMeteredKey).

1. Lakukan beberapa pemrosesan (menjalankan tugas).

1. Panggil metode [getConsumptionQuantity](https://reference.aspose.com/slides/id/python-java/aspose.slides/metered/#getConsumptionQuantity) dari kelas [Metered](https://reference.aspose.com/slides/id/python-java/aspose.slides/metered/).

Anda akan melihat jumlah/kuantitas permintaan API yang telah Anda konsumsi sejauh ini.

Kode contoh ini menunjukkan cara menggunakan lisensi metered:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Metered

# Buat instance dari kelas Metered.
metered = Metered()

try:
    # Berikan kunci publik dan privat ke objek Metered.
    metered.setMeteredKey("<valid public key>", "<valid private key>")

    # Dapatkan kuantitas yang dikonsumsi sebelum pemanggilan API.
    amount_before = Metered.getConsumptionQuantity()
    print("Amount consumed before:", amount_before)

    # Lakukan sesuatu dengan API Aspose.Slides di sini.
    # ...

    # Dapatkan kuantitas yang dikonsumsi setelah pemanggilan API.
    amount_after = Metered.getConsumptionQuantity()
    print("Amount consumed after:", amount_after)
except Exception as error:
    print(error)
```

{{% alert color="warning" title="Peringatan" %}}

Untuk menggunakan lisensi metered, Anda memerlukan koneksi internet yang stabil karena mekanisme lisensi menggunakan internet untuk terus berinteraksi dengan layanan kami dan melakukan perhitungan.

{{% /alert %}}

## **FAQ**

**Apakah saya dapat menggunakan lisensi metered bersamaan dengan lisensi reguler (perpetual atau temporary) dalam aplikasi yang sama?**

Ya. Metered adalah mekanisme lisensi tambahan yang dapat digunakan bersama [metode lisensi](/slides/id/python-java/licensing/). Anda memilih mekanisme mana yang akan diterapkan saat aplikasi dimulai.

**Apa yang dihitung sebagai konsumsi pada lisensi metered: operasi atau file?**

Penggunaan API yang dihitung, yaitu jumlah permintaan atau operasi. Anda dapat memperoleh konsumsi saat ini melalui [metode pelacakan konsumsi](https://reference.aspose.com/slides/id/python-java/aspose.slides/metered/).

**Apakah metered cocok untuk microservice dan lingkungan serverless di mana instance sering di-restart?**

Ya. Karena perhitungan dilakukan pada tingkat panggilan API, skenario dengan cold start yang sering kompatibel, asalkan terdapat akses jaringan yang stabil untuk perhitungan metered.

**Apakah fungsionalitas perpustakaan berbeda ketika menggunakan lisensi metered dibandingkan dengan lisensi perpetual?**

Tidak. Ini hanya tentang mekanisme lisensi dan penagihan; kemampuan produk tetap sama.

**Bagaimana hubungan antara metered dengan versi trial dan lisensi temporary?**

Versi trial memiliki batasan dan watermark, [lisensi temporary](https://purchase.aspose.com/temporary-license/) menghapus batasan selama 30 hari, dan metered menghapus batasan serta menagih berdasarkan penggunaan aktual.

**Apakah saya dapat mengontrol anggaran dengan secara otomatis merespons ketika ambang konsumsi terlampaui?**

Ya. Praktik umum adalah secara berkala membaca konsumsi saat ini melalui [metode pelacakan](https://reference.aspose.com/slides/id/python-java/aspose.slides/metered/) dan menerapkan batas atau peringatan sendiri di tingkat aplikasi atau pemantauan.