---
title: Lisensi Metered
type: docs
weight: 90
url: /id/python-net/metered-licensing/
keywords:
- lisensi
- lisensi metered
- kunci lisensi
- kunci publik
- kunci privat
- kuantitas konsumsi
- Python
- Aspose.Slides
description: "Pelajari bagaimana Aspose.Slides untuk Python via .NET dengan lisensi metered memungkinkan Anda memproses file PowerPoint dan OpenDocument secara fleksibel, hanya membayar sesuai penggunaan."
---
## **Pendahuluan**

Metered licensing adalah mekanisme lisensi yang dapat digunakan bersamaan dengan metode lisensi yang ada. Jika Anda ingin ditagih berdasarkan penggunaan fitur API Aspose.Slides, pilihlah metered licensing.

## **Terapkan Kunci Metered**

{{% alert color="primary" %}} 

Metered licensing adalah mekanisme lisensi baru yang dapat digunakan bersamaan dengan metode lisensi yang ada. Jika Anda ingin ditagih berdasarkan penggunaan fitur API Aspose.Slides, pilihlah metered licensing.

Saat Anda membeli lisensi metered, Anda memperoleh kunci (bukan file lisensi). Kunci metered ini dapat diterapkan menggunakan kelas [Metered](https://reference.aspose.com/slides/id/python-net/aspose.slides/metered/) yang disediakan Aspose untuk operasi metering. Untuk detail lebih lanjut, lihat [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Buat sebuah instance kelas [Metered](https://reference.aspose.com/slides/id/python-net/aspose.slides/metered/).
1. Berikan kunci publik dan privat Anda ke metode [set_metered_key](https://reference.aspose.com/slides/id/python-net/aspose.slides/metered/set_metered_key/#str-str).
1. Lakukan beberapa pemrosesan (melakukan tugas).
1. Panggil metode [get_consumption_quantity](https://reference.aspose.com/slides/id/python-net/aspose.slides/metered/get_consumption_quantity/#) dari kelas `Metered`.

Anda akan melihat jumlah/kuantitas permintaan API yang telah Anda konsumsi sejauh ini.

Kode contoh ini menunjukkan cara menggunakan lisensi metered:

```python
import aspose.slides as slides

# Membuat instance dari kelas Metered
metered = slides.Metered()

# Menyerahkan kunci publik dan privat ke objek Metered
metered.set_metered_key("<valid public key>", "<valid private key>")

# Mengambil nilai kuantitas yang dikonsumsi sebelum panggilan API
amount_before = slides.Metered.get_consumption_quantity()
print("Amount consumed before:", amount_before)

# Lakukan sesuatu dengan API Aspose.Slides di sini
# ...

# Mengambil nilai kuantitas yang dikonsumsi setelah panggilan API
amount_after = slides.Metered.get_consumption_quantity()
print("Amount consumed after:", amount_after)
```

{{% alert color="warning" title="NOTE"  %}} 

Untuk menggunakan lisensi metered, Anda memerlukan koneksi internet yang stabil karena mekanisme lisensi menggunakan internet untuk terus berinteraksi dengan layanan kami dan melakukan perhitungan.

{{% /alert %}} 

## **FAQ**

**Apakah saya dapat menggunakan lisensi metered bersama dengan lisensi reguler (perpetual atau temporary) dalam aplikasi yang sama?**

Ya. Metered adalah mekanisme lisensi tambahan yang dapat digunakan bersamaan dengan [licensing methods](/slides/id/python-net/licensing/). Anda memilih mekanisme mana yang akan diterapkan saat aplikasi dimulai.

**Apa yang tepat dihitung sebagai konsumsi pada lisensi metered: operasi atau file?**

Penggunaan API yang dihitung, yaitu jumlah permintaan atau operasi. Anda dapat memperoleh konsumsi saat ini melalui [consumption-tracking methods](https://reference.aspose.com/slides/id/python-net/aspose.slides/metered/).

**Apakah metered cocok untuk microservices dan lingkungan serverless di mana instansi sering restart?**

Ya. Karena perhitungan dilakukan pada tingkat panggilan API, skenario dengan cold start yang sering kompatibel, asalkan ada akses jaringan yang stabil untuk perhitungan metered.

**Apakah fungsionalitas perpustakaan berbeda saat menggunakan lisensi metered dibandingkan dengan lisensi perpetual?**

Tidak. Ini hanya tentang mekanisme lisensi dan penagihan; kemampuan produk tetap sama.

**Bagaimana kaitan metered dengan versi trial dan lisensi sementara?**

Versi trial memiliki batasan dan watermark, [temporary license](https://purchase.aspose.com/temporary-license/) menghapus batasan selama 30 hari, dan metered menghapus batasan serta mengenakan biaya berdasarkan penggunaan sebenarnya.

**Apakah saya dapat mengontrol anggaran dengan secara otomatis merespon ketika ambang konsumsi terlampaui?**

Ya. Praktik umum adalah secara berkala membaca konsumsi saat ini melalui [tracking methods](https://reference.aspose.com/slides/id/python-net/aspose.slides/metered/) dan menerapkan batas atau peringatan sendiri pada tingkat aplikasi atau pemantauan.