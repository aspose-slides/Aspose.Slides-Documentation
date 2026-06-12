---
title: Ubah Ukuran Slide Presentasi di .NET
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
- jangan skala
- pastikan muat
- maksimalkan
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
descriptions: "Pelajari cara cepat mengubah ukuran slide dalam file PPT, PPTX, dan ODP dengan .NET dan Aspose.Slides, optimalkan presentasi untuk layar apa pun tanpa mengurangi kualitas."
---
## **Pendahuluan**

Aspose.Slides for .NET menyediakan alat lengkap untuk menyesuaikan ukuran slide dan rasio aspek dalam presentasi PowerPoint, penting untuk pencetakan maupun tampilan di layar. 

Ukuran Slide Populer dan Rasio:

- **Standard (Rasio Aspek 4:3)**: Ideal untuk layar dan perangkat lama.
- **Widescreen (Rasio Aspek 16:9)**: Direkomendasikan untuk proyektor dan tampilan modern.

Pastikan konsistensi di seluruh presentasi Anda karena satu ukuran slide dan rasio aspek berlaku untuk semua slide. Untuk hasil optimal, tetapkan dimensi slide Anda di awal proses pembuatan presentasi untuk menghindari komplikasi.

{{% alert color="primary" %}} 
Secara default, presentasi yang dibuat dengan Aspose.Slides menggunakan rasio aspek standar 4:3.
{{% /alert %}}

## **Cara Mengubah Ukuran Slide dalam Presentasi**

Contoh ini memperlihatkan cara mengubah ukuran slide presentasi dengan Aspose.Slides dalam C#:

```csharp
using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Tentukan Ukuran Slide Kustom**

Menyesuaikan ukuran slide dengan kebutuhan spesifik Anda, seperti untuk tata letak kertas unik atau spesifikasi layar, dapat bermanfaat. Berikut cara mengatur ukuran slide kustom dengan Aspose.Slides untuk .NET:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // Ukuran kertas A4
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Kelola Konten Slide Setelah Mengubah Ukuran**

Setelah mengubah ukuran, konten slide dapat terdistorsi. Anda dapat mengontrol bagaimana Aspose.Slides mengelola perubahan ukuran ini:

- **`DoNotScale`**: Menjaga objek pada ukuran asli untuk menghindari skala.
- **`EnsureFit`**: Menskalakan objek agar sesuai dengan slide yang lebih kecil, mencegah kehilangan konten.
- **`Maximize`**: Membesarkan objek agar cocok dengan slide yang lebih besar untuk konsistensi estetika.

Contoh penggunaan pengaturan `Maximize` untuk penyesuaian ukuran slide:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **FAQ**

**Apakah saya dapat mengatur ukuran slide kustom menggunakan satuan selain inci (misalnya, poin atau milimeter)?**

Ya. Aspose.Slides menggunakan poin secara internal, di mana 1 poin sama dengan 1/72 inci. Anda dapat mengonversi satuan apa pun (seperti milimeter atau sentimeter) ke poin dan menggunakan nilai yang dikonversi untuk menentukan lebar dan tinggi slide.

**Apakah ukuran slide kustom yang sangat besar akan memengaruhi kinerja dan penggunaan memori saat rendering?**

Ya. Dimensi slide yang lebih besar (dalam poin) yang dikombinasikan dengan skala rendering yang lebih tinggi menyebabkan peningkatan konsumsi memori dan waktu pemrosesan yang lebih lama. Tujuannya adalah ukuran slide yang praktis dan sesuaikan skala rendering hanya bila diperlukan untuk mencapai kualitas output yang diinginkan.

**Apakah saya dapat menentukan satu ukuran slide non-standar lalu menggabungkan slide dari presentasi yang memiliki ukuran berbeda?**

Anda tidak dapat [merge presentations](/slides/id/net/merge-presentation/) saat memiliki ukuran slide yang berbeda — pertama, ubah ukuran satu presentasi agar cocok dengan yang lain. Saat mengubah ukuran slide, Anda dapat memilih cara menangani konten yang ada melalui opsi [SlideSizeScaleType](https://reference.aspose.com/slides/id/net/aspose.slides/slidesizescaletype/). Setelah menyelaraskan ukuran, Anda dapat menggabungkan slide sambil mempertahankan pemformatan.

**Apakah saya dapat menghasilkan thumbnail untuk bentuk individual atau wilayah spesifik dari slide, dan apakah mereka akan mematuhi ukuran slide baru?**

Ya. Aspose.Slides dapat merender thumbnail untuk [entire slides](https://reference.aspose.com/slides/id/net/aspose.slides/slide/getimage/) serta untuk [selected shapes](https://reference.aspose.com/slides/id/net/aspose.slides/shape/getimage/). Gambar yang dihasilkan mencerminkan ukuran slide dan rasio aspek saat ini, memastikan bingkai dan geometri yang konsisten.