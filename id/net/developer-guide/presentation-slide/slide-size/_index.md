---
title: Ubah Ukuran Slide Presentasi dalam .NET
linktitle: Ukuran Slide
type: docs
weight: 70
url: /id/net/slide-size/
keywords:
- ukuran slide
- rasio aspek
- standar
- layar lebar
- 4:3
- 16:9
- atur ukuran slide
- ubah ukuran slide
- ukuran slide kustom
- ukuran slide khusus
- ukuran slide unik
- slide ukuran penuh
- tipe layar
- jangan skalakan
- pastikan muat
- maksimalkan
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara cepat mengubah ukuran slide dalam file PPT, PPTX, dan ODP dengan .NET dan Aspose.Slides, optimalkan presentasi untuk layar apa pun tanpa kehilangan kualitas."
---
## **Pendahuluan**

Aspose.Slides for .NET menyediakan alat yang komprehensif untuk menyesuaikan ukuran slide dan rasio aspek dalam presentasi PowerPoint, penting untuk pencetakan maupun tampilan di layar. 

Ukuran Slide Populer dan Rasio:

- **Standar (Rasio Aspek 4:3)**: Ideal untuk layar dan perangkat lama.
- **Layar Lebar (Rasio Aspek 16:9)**: Disarankan untuk proyektor dan tampilan modern.

Pastikan konsistensi di seluruh presentasi Anda karena satu ukuran slide dan rasio aspek berlaku untuk semua slide. Untuk hasil optimal, tetapkan dimensi slide di awal proses pembuatan presentasi untuk menghindari komplikasi.

{{% alert color="info" %}} 
Secara default, presentasi yang dibuat dengan Aspose.Slides menggunakan rasio aspek standar 4:3.
{{% /alert %}}

Halaman catatan dan handout memiliki dimensi terpisah dari slide reguler. Lihat [Ukuran Halaman Catatan](/slides/id/net/notes-size/) untuk mengubah ukuran dan orientasinya.

## **Cara Mengubah Ukuran Slide dalam Presentasi**

Contoh ini menunjukkan cara mengubah ukuran slide presentasi dengan Aspose.Slides di C#:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Tentukan Ukuran Slide Kustom**

Menyesuaikan ukuran slide dengan kebutuhan spesifik Anda, seperti untuk tata letak kertas unik atau spesifikasi layar, dapat bermanfaat. Berikut cara menetapkan ukuran slide kustom dengan Aspose.Slides untuk .NET:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // Ukuran kertas A4
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Kelola Konten Slide Setelah Mengubah Ukuran**

Setelah mengubah ukuran, konten slide dapat terdistorsi. Anda dapat mengontrol bagaimana Aspose.Slides mengelola perubahan ukuran ini:

- **`DoNotScale`**: Menjaga objek pada ukuran asli untuk menghindari skala.
- **`EnsureFit`**: Menskala objek agar sesuai dengan slide yang lebih kecil, mencegah kehilangan konten.
- **`Maximize`**: Membesarkan objek agar sesuai dengan slide yang lebih besar untuk konsistensi estetika.

Contoh penggunaan pengaturan `Maximize` untuk penyesuaian ukuran slide:

```csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **FAQ**

### Bisakah saya mengatur ukuran slide kustom menggunakan satuan selain inci (misalnya, poin atau milimeter)?

Ya. Aspose.Slides menggunakan poin secara internal, di mana 1 poin sama dengan 1/72 inci. Anda dapat mengonversi satuan apa pun (seperti milimeter atau sentimeter) ke poin dan menggunakan nilai yang dikonversi untuk mendefinisikan lebar dan tinggi slide.

### Apakah ukuran slide kustom yang sangat besar akan memengaruhi kinerja dan penggunaan memori saat rendering?

Ya. Dimensi slide yang lebih besar (dalam poin) dikombinasikan dengan skala rendering yang lebih tinggi menyebabkan peningkatan konsumsi memori dan waktu proses yang lebih lama. Tujuannya adalah ukuran slide yang praktis dan sesuaikan skala rendering hanya bila diperlukan untuk mencapai kualitas output yang diinginkan.

### Bisakah saya menentukan satu ukuran slide non-standar lalu menggabungkan slide dari presentasi yang memiliki ukuran berbeda?

Anda tidak dapat [gabungkan presentasi](/slides/id/net/merge-presentation/) saat mereka memiliki ukuran slide yang berbeda — pertama, ubah ukuran satu presentasi agar cocok dengan yang lain. Saat mengubah ukuran slide, Anda dapat memilih bagaimana konten yang ada ditangani melalui opsi [SlideSizeScaleType](https://reference.aspose.com/slides/id/net/aspose.slides/slidesizescaletype/). Setelah menyelaraskan ukuran, Anda dapat menggabungkan slide sambil mempertahankan format.

### Bisakah saya menghasilkan thumbnail untuk bentuk individual atau wilayah spesifik dari slide, dan apakah mereka akan menghormati ukuran slide baru?

Ya. Aspose.Slides dapat merender thumbnail untuk [seluruh slide](https://reference.aspose.com/slides/id/net/aspose.slides/slide/getimage/) serta untuk [bentuk terpilih](https://reference.aspose.com/slides/id/net/aspose.slides/shape/getimage/). Gambar yang dihasilkan mencerminkan ukuran slide dan rasio aspek saat ini, memastikan framing dan geometri yang konsisten.