---
title: Mengonversi PPT dan PPTX ke JPG di .NET
linktitle: PowerPoint ke JPG
type: docs
weight: 60
url: /id/net/convert-powerpoint-to-jpg/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke JPG
- presentasi ke JPG
- slide ke JPG
- PPT ke JPG
- PPTX ke JPG
- simpan PowerPoint sebagai JPG
- simpan presentasi sebagai JPG
- simpan slide sebagai JPG
- simpan PPT sebagai JPG
- simpan PPTX sebagai JPG
- ekspor PPT ke JPG
- ekspor PPTX ke JPG
- .NET
- C#
- Aspose.Slides
description: "Konversi slide PowerPoint (PPT, PPTX) ke gambar JPG berkualitas tinggi di C# dengan Aspose.Slides untuk .NET menggunakan contoh kode yang cepat dan dapat diandalkan."
---
## **Pendahuluan**

Mengonversi presentasi PowerPoint dan OpenDocument menjadi gambar JPG membantu dalam berbagi slide, mengoptimalkan kinerja, dan menyematkan konten ke situs web atau aplikasi. Aspose.Slides untuk .NET memungkinkan Anda mengubah file PPTX, PPT, dan ODP menjadi gambar JPEG berkualitas tinggi. Panduan ini menjelaskan berbagai metode konversi.

Dengan fitur-fitur ini, mudah untuk mengimplementasikan penampil presentasi Anda sendiri dan membuat thumbnail untuk setiap slide. Hal ini dapat berguna jika Anda ingin melindungi slide presentasi dari penyalinan atau menunjukkan presentasi dalam mode hanya‑baca. Aspose.Slides memungkinkan Anda mengonversi seluruh presentasi atau slide tertentu ke format gambar.

## **Mengonversi Slide Presentasi ke Gambar JPG**

Berikut langkah‑langkah untuk mengonversi file PPT, PPTX, atau ODP ke JPG:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Dapatkan objek slide bertipe [ISlide](https://reference.aspose.com/slides/id/net/aspose.slides/islide) dari koleksi [Presentation.Slides](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/properties/slides).
3. Buat gambar slide dengan menggunakan metode [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/id/net/aspose.slides/islide/getimage/#getimage_5).
4. Panggil metode [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/id/net/aspose.slides/iimage/save/#save_3) pada objek gambar. Berikan nama file output dan format gambar sebagai argumen.

{{% alert color="primary" %}} 
**Catatan:** Konversi PPT, PPTX, atau ODP ke JPG berbeda dari konversi ke format lain dalam API Aspose.Slides .NET. Untuk format lain, biasanya Anda menggunakan metode [IPresentation.Save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentation/save/#save_5). Namun, untuk konversi JPG, Anda perlu menggunakan metode [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/id/net/aspose.slides/iimage/save/#save_3).
{{% /alert %}} 

```c#
int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Buat gambar slide dengan skala yang ditentukan.
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // Simpan gambar ke disk dalam format JPEG.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **Mengonversi Slide ke JPG dengan Dimensi yang Disesuaikan**

Untuk mengubah dimensi gambar JPG yang dihasilkan, Anda dapat mengatur ukuran gambar dengan melewatkannya ke metode [ISlide.GetImage(Size)](https://reference.aspose.com/slides/id/net/aspose.slides/islide/getimage/#getimage_6). Ini memungkinkan Anda menghasilkan gambar dengan nilai lebar dan tinggi tertentu, memastikan output memenuhi persyaratan resolusi dan rasio aspek Anda. Fleksibilitas ini sangat berguna saat menghasilkan gambar untuk aplikasi web, laporan, atau dokumentasi, di mana dimensi gambar yang tepat diperlukan.

```c#
Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Buat gambar slide dengan ukuran yang ditentukan.
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // Simpan gambar ke disk dalam format JPEG.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **Menyisipkan Komentar Saat Menyimpan Slide sebagai Gambar**

Aspose.Slides untuk .NET menyediakan fitur yang memungkinkan Anda menyisipkan komentar pada slide presentasi saat mengonversinya menjadi gambar JPG. Fungsionalitas ini sangat berguna untuk mempertahankan anotasi, umpan balik, atau diskusi yang ditambahkan oleh kolaborator dalam presentasi PowerPoint. Dengan mengaktifkan opsi ini, Anda memastikan komentar terlihat dalam gambar yang dihasilkan, memudahkan peninjauan dan berbagi umpan balik tanpa harus membuka file presentasi asli.

Misalkan kita memiliki file presentasi, "sample.pptx," dengan slide yang berisi komentar:

![Slide dengan komentar](slide_with_comments.png)

Kode C# berikut mengonversi slide menjadi gambar JPG sambil mempertahankan komentar:

```c#
int scaleX = 2;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        // Atur opsi untuk komentar slide.
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            CommentsPosition = CommentsPositions.Right,
            CommentsAreaWidth = 200,
            CommentsAreaColor = Color.DarkOrange                  
        }
    };

    // Konversi slide pertama menjadi gambar.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        image.Save("Slide_1.jpg", ImageFormat.Jpeg);
    }
}
```

Hasil:

![Gambar JPG dengan komentar](image_with_comments.png)

## **Lihat Juga**

- [Mengonversi PowerPoint ke GIF](/slides/id/net/convert-powerpoint-to-animated-gif/)
- [Mengonversi PowerPoint ke PNG](/slides/id/net/convert-powerpoint-to-png/)
- [Mengonversi PowerPoint ke TIFF](/slides/id/net/convert-powerpoint-to-tiff/)
- [Mengonversi PowerPoint ke SVG](/slides/id/net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
Untuk melihat cara Aspose.Slides mengonversi PowerPoint ke gambar JPG, coba konverter online gratis berikut: PowerPoint [PPTX ke JPG](https://products.aspose.app/slides/id/conversion/pptx-to-jpg) dan [PPT ke JPG](https://products.aspose.app/slides/id/conversion/ppt-to-jpg). 
{{% /alert %}} 

![Konverter PPTX ke JPG Gratis Online](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose menyediakan [aplikasi web Collage GRATIS](https://products.aspose.app/slides/id/collage). Dengan layanan online ini, Anda dapat menggabungkan gambar [JPG ke JPG](https://products.aspose.app/slides/id/collage/jpg) atau PNG ke PNG, membuat [grid foto](https://products.aspose.app/slides/id/collage/photo-grid), dan sebagainya. 

Dengan prinsip yang sama seperti yang dijelaskan dalam artikel ini, Anda dapat mengonversi gambar dari satu format ke format lain. Untuk informasi lebih lanjut, lihat halaman berikut: konversi [gambar ke JPG](https://products.aspose.com/slides/id/net/conversion/image-to-jpg/); konversi [JPG ke gambar](https://products.aspose.com/slides/id/net/conversion/jpg-to-image/); konversi [JPG ke PNG](https://products.aspose.com/slides/id/net/conversion/jpg-to-png/), konversi [PNG ke JPG](https://products.aspose.com/slides/id/net/conversion/png-to-jpg/); konversi [PNG ke SVG](https://products.aspose.com/slides/id/net/conversion/png-to-svg/), konversi [SVG ke PNG](https://products.aspose.com/slides/id/net/conversion/svg-to-png/).
{{% /alert %}}

## **Tanya Jawab**

**Apakah metode ini mendukung konversi batch?**

Ya, Aspose.Slides memungkinkan konversi batch banyak slide ke JPG dalam satu operasi.

**Apakah konversi mendukung SmartArt, diagram, dan objek kompleks lainnya?**

Ya, Aspose.Slides merender semua konten, termasuk SmartArt, diagram, tabel, bentuk, dan lainnya. Namun, akurasi rendering mungkin sedikit berbeda dibandingkan PowerPoint, terutama saat menggunakan font khusus atau yang tidak tersedia.

**Apakah ada batasan jumlah slide yang dapat diproses?**

Aspose.Slides sendiri tidak memberlakukan batasan ketat pada jumlah slide yang dapat Anda proses. Namun, Anda mungkin mengalami kesalahan out‑of‑memory ketika bekerja dengan presentasi besar atau gambar resolusi tinggi.