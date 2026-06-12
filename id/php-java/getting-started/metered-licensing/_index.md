---
title: Lisensi Metered
type: docs
weight: 100
url: /id/php-java/metered-licensing/
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
- PHP
- Aspose.Slides
description: "Pelajari bagaimana Aspose.Slides untuk PHP melalui metered licensing berbasis Java memungkinkan Anda memproses file PowerPoint dan OpenDocument secara fleksibel, hanya membayar apa yang Anda gunakan."
---
## **Pendahuluan**

Metered licensing adalah mekanisme lisensi yang dapat digunakan bersama metode lisensi yang ada. Jika Anda ingin ditagih berdasarkan penggunaan fitur API Aspose.Slides, pilihlah metered licensing.

## **Menerapkan Kunci Metered**

Saat Anda membeli lisensi metered, Anda menerima kunci (bukan file lisensi). Kunci metered ini dapat diterapkan menggunakan kelas [Metered](https://reference.aspose.com/slides/id/php-java/aspose.slides/metered/) yang disediakan Aspose untuk operasi metering. Untuk detail lebih lanjut, lihat [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

1. Buat sebuah instance dari kelas [Metered](https://reference.aspose.com/slides/id/php-java/aspose.slides/metered/).

1. Berikan kunci publik dan privat Anda ke metode [setMeteredKey](https://reference.aspose.com/slides/id/php-java/aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) .

1. Lakukan beberapa pemrosesan (menjalankan tugas).

1. Panggil metode [getConsumptionQuantity](https://reference.aspose.com/slides/id/php-java/aspose.slides/metered/#getConsumptionQuantity--) dari kelas `Metered`.

Anda akan melihat jumlah/kuantitas permintaan API yang telah Anda konsumsi sejauh ini.

```php
// Membuat instance dari kelas Metered
$metered = new Metered();

try {
    // Meneruskan kunci publik dan privat ke objek Metered
    $metered->setMeteredKey("<valid pablic key>", "<valid private key>");

    // Mendapatkan nilai kuantitas yang dikonsumsi sebelum panggilan API
    $amountBefore = Metered::getConsumptionQuantity();
    echo("Amount consumed before: " . $amountBefore);

    // Lakukan sesuatu dengan API Aspose.Slides di sini
    // ...

    // Mendapatkan nilai kuantitas yang dikonsumsi setelah panggilan API
    $amountAfter = Metered::getConsumptionQuantity();
    echo("Amount consumed after: " . $amountAfter);
} catch (JavaException $ex) {
  $ex->printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 
Untuk menggunakan metered licensing, Anda memerlukan koneksi internet yang stabil karena mekanisme lisensi menggunakan internet untuk terus berinteraksi dengan layanan kami dan melakukan perhitungan.
{{% /alert %}} 

## **FAQ**

**Apakah saya dapat menggunakan lisensi metered bersama dengan lisensi reguler (perpetual atau temporary) dalam aplikasi yang sama?**

Ya. Metered adalah mekanisme lisensi tambahan yang dapat digunakan bersamaan dengan [metode lisensi](/slides/id/php-java/licensing/). Anda memilih mekanisme mana yang akan diterapkan saat aplikasi dimulai.

**Apa yang sebenarnya dihitung sebagai konsumsi pada lisensi metered: operasi atau file?**

Penggunaan API yang dihitung, yaitu jumlah permintaan atau operasi. Anda dapat memperoleh konsumsi saat ini melalui [metode pelacakan konsumsi](https://reference.aspose.com/slides/id/php-java/aspose.slides/metered/).

**Apakah metered cocok untuk lingkungan microservices dan serverless di mana instance sering di-restart?**

Ya. Karena pencatatan dilakukan pada tingkat panggilan API, skenario dengan cold start yang sering kompatibel, asalkan ada akses jaringan yang stabil untuk perhitungan metered.

**Apakah fungsionalitas pustaka berbeda saat menggunakan lisensi metered dibandingkan dengan lisensi perpetual?**

Tidak. Ini hanya mengenai mekanisme lisensi dan penagihan; kemampuan produk tetap sama.

**Bagaimana hubungan metered dengan versi percobaan dan lisensi temporary?**

Versi trial memiliki batasan dan watermark, [lisensi temporary](https://purchase.aspose.com/temporary-license/) menghapus batasan selama 30 hari, dan metered menghapus batasan serta menagih berdasarkan penggunaan aktual.

**Apakah saya dapat mengontrol anggaran dengan otomatis merespons ketika ambang konsumsi terlampaui?**

Ya. Praktik umum adalah secara berkala membaca konsumsi saat ini melalui [metode pelacakan](https://reference.aspose.com/slides/id/php-java/aspose.slides/metered/) dan menerapkan batasan atau peringatan Anda sendiri pada tingkat aplikasi atau pemantauan.