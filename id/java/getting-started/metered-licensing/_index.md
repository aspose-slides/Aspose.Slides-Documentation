---
title: Lisensi Metered
type: docs
weight: 100
url: /id/java/metered-licensing/
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
- Java
- Aspose.Slides
description: "Pelajari cara lisensi metered Aspose.Slides untuk Java memungkinkan Anda memproses file PowerPoint dan OpenDocument secara fleksibel, hanya membayar apa yang Anda gunakan."
---
## **Pengantar**

Lisensi Metered adalah mekanisme lisensi yang dapat digunakan bersama metode lisensi yang ada. Jika Anda ingin ditagih berdasarkan penggunaan fitur API Aspose.Slides, pilih lisensi Metered.

## **Terapkan Kunci Metered**

{{% alert color="info" %}} 

Lisensi Metered adalah mekanisme lisensi baru yang dapat digunakan bersama metode lisensi yang ada. Jika Anda ingin ditagih berdasarkan penggunaan fitur API Aspose.Slides, pilih lisensi Metered.

Saat Anda membeli lisensi Metered, Anda mendapatkan kunci (bukan file lisensi). Kunci Metered ini dapat diterapkan menggunakan kelas [Metered](https://reference.aspose.com/slides/id/java/com.aspose.slides/metered/) yang disediakan Aspose untuk operasi metering. Untuk detail lebih lanjut, lihat [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Buat instance kelas [Metered](https://reference.aspose.com/slides/id/java/com.aspose.slides/metered/).

1. Berikan kunci publik dan privat Anda ke metode [setMeteredKey](https://reference.aspose.com/slides/id/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) .

1. Lakukan beberapa pemrosesan (melakukan tugas).

1. Panggil metode [getConsumptionQuantity](https://reference.aspose.com/slides/id/java/com.aspose.slides/metered/#getConsumptionQuantity--) dari kelas `Metered`.

Anda akan melihat jumlah kuantitas permintaan API yang telah Anda konsumsi sejauh ini.

Kode contoh ini menunjukkan cara menggunakan lisensi Metered:

```java
// Membuat instance dari kelas Metered
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // Mengirimkan kunci publik dan privat ke objek Metered
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // Mengambil nilai kuantitas yang dikonsumsi sebelum panggilan API
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // Lakukan sesuatu dengan API Aspose.Slides di sini
    // ...

    // Mengambil nilai kuantitas yang dikonsumsi setelah panggilan API
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

Untuk menggunakan lisensi Metered, Anda memerlukan koneksi internet yang stabil karena mekanisme lisensi menggunakan internet untuk terus berinteraksi dengan layanan kami dan melakukan perhitungan.

{{% /alert %}} 

## **FAQ**

### Apakah saya dapat menggunakan lisensi Metered bersama dengan lisensi reguler (perpetual atau sementara) dalam aplikasi yang sama?

Ya. Metered adalah mekanisme lisensi tambahan yang dapat digunakan bersamaan dengan [metode lisensi](/slides/id/java/licensing/). Anda memilih mekanisme mana yang akan diterapkan saat aplikasi dimulai.

### Apa yang sebenarnya dihitung sebagai konsumsi pada lisensi Metered: operasi atau file?

Penggunaan API yang dihitung, artinya jumlah permintaan atau operasi. Anda dapat memperoleh konsumsi saat ini melalui [metode pelacakan konsumsi](https://reference.aspose.com/slides/id/java/com.aspose.slides/metered/).

### Apakah Metered cocok untuk microservices dan lingkungan serverless di mana instance sering di-restart?

Ya. Karena perhitungan dilakukan pada tingkat panggilan API, skenario dengan cold start yang sering kompatibel, asalkan ada akses jaringan yang stabil untuk perhitungan Metered.

### Apakah fungsionalitas perpustakaan berbeda saat menggunakan lisensi Metered dibandingkan dengan lisensi perpetual?

Tidak. Ini hanya tentang mekanisme lisensi dan penagihan; kemampuan produk tetap sama.

### Bagaimana Metered terkait dengan versi percobaan dan lisensi sementara?

Versi percobaan memiliki batasan dan watermark, [lisensi sementara](https://purchase.aspose.com/temporary-license/) menghapus batasan selama 30 hari, dan Metered menghapus batasan serta menagih berdasarkan penggunaan aktual.

### Bisakah saya mengontrol anggaran dengan secara otomatis merespons saat ambang konsumsi terlampaui?

Ya. Praktik umum adalah secara berkala membaca konsumsi saat ini melalui [metode pelacakan](https://reference.aspose.com/slides/id/java/com.aspose.slides/metered/) dan menerapkan batas atau peringatan Anda sendiri pada tingkat aplikasi atau pemantauan.