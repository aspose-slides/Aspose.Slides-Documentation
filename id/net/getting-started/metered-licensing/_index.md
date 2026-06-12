---
title: Lisensi Bermeter
type: docs
weight: 90
url: /id/net/metered-licensing/
keywords:
- lisensi
- lisensi bermeter
- kunci lisensi
- kunci publik
- kunci pribadi
- jumlah konsumsi
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari bagaimana lisensi bermeter Aspose.Slides untuk .NET memungkinkan Anda memproses file PowerPoint dan OpenDocument secara fleksibel, hanya membayar untuk apa yang Anda gunakan."
---
## **Pendahuluan**

Lisensi bermeter adalah mekanisme lisensi yang dapat digunakan bersama metode lisensi yang ada. Jika Anda ingin ditagih berdasarkan penggunaan fitur API Aspose.Slides, Anda memilih lisensi bermeter.

## **Terapkan Kunci Metered**

Saat Anda membeli lisensi bermeter, Anda menerima kunci (bukan berkas lisensi). Kunci bermeter ini dapat diterapkan menggunakan kelas [Metered](https://reference.aspose.com/slides/id/net/aspose.slides/metered/) yang disediakan Aspose untuk operasi metering. Untuk detail lebih lanjut, lihat [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

1. Buat sebuah instance dari kelas [Metered](https://reference.aspose.com/slides/id/net/aspose.slides/metered/).
2. Berikan kunci publik dan pribadi Anda ke metode [SetMeteredKey](https://reference.aspose.com/slides/id/net/aspose.slides/metered/setmeteredkey/).
3. Lakukan beberapa pemrosesan (menjalankan tugas).
4. Panggil metode [GetConsumptionQuantity](https://reference.aspose.com/slides/id/net/aspose.slides/metered/getconsumptionquantity/) dari kelas `Metered`.

Anda akan melihat jumlah/kuantitas permintaan API yang telah Anda konsumsi sejauh ini.

Kode contoh ini menunjukkan cara menggunakan lisensi bermeter:

```cs
// Membuat instance dari kelas Metered
Aspose.Slides.Metered metered = new Aspose.Slides.Metered();

// Menyerahkan kunci publik dan pribadi ke objek Metered
metered.SetMeteredKey("<valid public key>", "<valid private key>");

// Mendapatkan kuantitas data bermeter sebelum pemanggilan API
decimal amountBefore = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed before: " + amountBefore.ToString());

// Lakukan sesuatu dengan API Aspose.Slides di sini
// ...

// Mendapatkan jumlah data bermeter setelah pemanggilan API
decimal amountAfter = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed after: " + amountAfter.ToString());
```

{{% alert color="warning" title="NOTE"  %}} 
Untuk menggunakan lisensi bermeter, Anda memerlukan koneksi internet yang stabil karena mekanisme lisensi menggunakan internet untuk terus berinteraksi dengan layanan kami dan melakukan perhitungan.
{{% /alert %}} 

## **FAQ**

**Apakah saya dapat menggunakan lisensi bermeter bersama dengan lisensi reguler (perpetual atau temporary) dalam aplikasi yang sama?**

Ya. Metered adalah mekanisme lisensi tambahan yang dapat digunakan bersama [metode lisensi](/slides/id/net/licensing/). Anda memilih mekanisme mana yang akan diterapkan saat aplikasi dimulai.

**Apa yang sebenarnya dihitung sebagai konsumsi dalam lisensi bermeter: operasi atau berkas?**

Penggunaan API yang dihitung, yaitu jumlah permintaan atau operasi. Anda dapat memperoleh konsumsi saat ini melalui [metode pelacakan konsumsi](https://reference.aspose.com/slides/id/net/aspose.slides/metered/).

**Apakah bermeter cocok untuk mikroservis dan lingkungan serverless dimana instance sering direstart?**

Ya. Karena perhitungan dilakukan pada tingkat panggilan API, skenario dengan cold start yang sering kompatibel, asalkan ada akses jaringan yang stabil untuk perhitungan bermeter.

**Apakah fungsionalitas perpustakaan berbeda saat menggunakan lisensi bermeter dibandingkan dengan lisensi perpetual?**

Tidak. Ini hanya mengenai mekanisme lisensi dan penagihan; kemampuan produk tetap sama.

**Bagaimana hubungan bermeter dengan versi percobaan dan lisensi temporary?**

Versi percobaan memiliki batasan dan watermark, [lisensi temporary](https://purchase.aspose.com/temporary-license/) menghilangkan batasan selama 30 hari, dan bermeter menghilangkan batasan serta menagih berdasarkan penggunaan sebenarnya.

**Apakah saya dapat mengontrol anggaran dengan otomatis merespon ketika ambang konsumsi terlampaui?**

Ya. Praktik umum adalah secara berkala membaca konsumsi saat ini melalui [metode pelacakan](https://reference.aspose.com/slides/id/net/aspose.slides/metered/) dan menerapkan batasan atau peringatan Anda sendiri pada level aplikasi atau pemantauan.