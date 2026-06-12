---
title: Lisensi Berukur
type: docs
weight: 100
url: /id/java/metered-licensing/
keywords:
- lisensi
- lisensi berukur
- kunci lisensi
- kunci publik
- kunci privat
- kuantitas konsumsi
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Pelajari bagaimana lisensi berukur Aspose.Slides untuk Java memungkinkan Anda memproses file PowerPoint dan OpenDocument secara fleksibel, hanya membayar atas apa yang Anda gunakan."
---
## **Pendahuluan**

Lisensi berukur adalah mekanisme lisensi yang dapat digunakan bersamaan dengan metode lisensi yang ada. Jika Anda ingin ditagih berdasarkan penggunaan fitur API Aspose.Slides, Anda memilih lisensi berukur.

## **Terapkan Kunci Berukur**

{{% alert color="primary" %}} 

Lisensi berukur adalah mekanisme lisensi baru yang dapat digunakan bersamaan dengan metode lisensi yang ada. Jika Anda ingin ditagih berdasarkan penggunaan fitur API Aspose.Slides, Anda memilih lisensi berukur.

Saat Anda membeli lisensi berukur, Anda mendapatkan kunci (bukan file lisensi). Kunci berukur ini dapat diterapkan menggunakan kelas [Metered](https://reference.aspose.com/slides/id/java/com.aspose.slides/metered/) yang disediakan Aspose untuk operasi pengukuran. Untuk detail lebih lanjut, lihat [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Buat sebuah instance dari kelas [Metered](https://reference.aspose.com/slides/id/java/com.aspose.slides/metered/).

1. Kirimkan kunci publik dan privat Anda ke metode [setMeteredKey](https://reference.aspose.com/slides/id/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-).

1. Lakukan beberapa pemrosesan (eksekusi tugas).

1. Panggil metode [getConsumptionQuantity](https://reference.aspose.com/slides/id/java/com.aspose.slides/metered/#getConsumptionQuantity--) dari kelas `Metered`.

Anda akan melihat jumlah/kuantitas permintaan API yang telah Anda konsumsi sejauh ini.

Contoh kode ini menunjukkan cara menggunakan lisensi berukur:

```java
// Membuat instance dari kelas Metered
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // Mengirimkan kunci publik dan privat ke objek Metered
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // Mendapatkan nilai kuantitas konsumsi sebelum panggilan API
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // Lakukan sesuatu dengan API Aspose.Slides di sini
    // ...

    // Mendapatkan nilai kuantitas konsumsi setelah panggilan API
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

Untuk menggunakan lisensi berukur, Anda memerlukan koneksi internet yang stabil karena mekanisme lisensi menggunakan internet untuk terus berinteraksi dengan layanan kami dan melakukan perhitungan.

{{% /alert %}} 

## **FAQ**

**Apakah saya dapat menggunakan lisensi berukur bersama dengan lisensi reguler (perpetual atau sementara) dalam aplikasi yang sama?**

Ya. Berukur adalah mekanisme lisensi tambahan yang dapat digunakan bersamaan dengan [metode lisensi](/slides/id/java/licensing/). Anda memilih mekanisme mana yang akan diterapkan ketika aplikasi dimulai.

**Apa yang sebenarnya dihitung sebagai konsumsi pada lisensi berukur: operasi atau berkas?**

Penggunaan API dihitung, artinya jumlah permintaan atau operasi. Anda dapat memperoleh konsumsi saat ini melalui [metode pelacakan konsumsi](https://reference.aspose.com/slides/id/java/com.aspose.slides/metered/).

**Apakah berukur cocok untuk microservices dan lingkungan serverless di mana instance sering di-restart?**

Ya. Karena perhitungan dilakukan pada tingkat panggilan API, skenario dengan start dingin yang sering kompatibel, asalkan ada akses jaringan yang stabil untuk perhitungan berukur.

**Apakah fungsi perpustakaan berbeda ketika menggunakan lisensi berukur dibandingkan dengan lisensi perpetual?**

Tidak. Ini hanya tentang mekanisme lisensi dan penagihan; kemampuan produk tetap sama.

**Bagaimana kaitan berukur dengan versi percobaan dan lisensi sementara?**

Versi percobaan memiliki batasan dan watermark, [lisensi sementara](https://purchase.aspose.com/temporary-license/) menghapus batasan selama 30 hari, dan berukur menghapus batasan serta menagih berdasarkan penggunaan sebenarnya.

**Apakah saya dapat mengontrol anggaran dengan secara otomatis merespons ketika ambang konsumsi terlampaui?**

Ya. Praktik umum adalah secara periodik membaca konsumsi saat ini via [metode pelacakan](https://reference.aspose.com/slides/id/java/com.aspose.slides/metered/) dan menerapkan batas atau peringatan Anda sendiri pada level aplikasi atau pemantauan.