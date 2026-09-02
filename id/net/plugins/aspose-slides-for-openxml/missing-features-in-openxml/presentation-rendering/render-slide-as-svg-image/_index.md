---
title: Render Slide sebagai Gambar SVG
type: docs
weight: 50
url: /id/net/render-slide-as-svg-image/
---
SVG—singkatan dari Scalable Vector Graphics—adalah jenis atau format grafik standar yang digunakan untuk merender gambar dua dimensi. SVG menyimpan gambar sebagai vektor dalam XML dengan detail yang mendefinisikan perilaku atau tampilan mereka. 

SVG adalah salah satu dari sedikit format gambar yang memenuhi standar sangat tinggi dalam hal: skalabilitas, interaktivitas, kinerja, aksesibilitas, kemampuan pemrograman, dan lainnya. Karena alasan ini, biasanya digunakan dalam pengembangan web. 

Anda mungkin ingin menggunakan file SVG dalam skenario berikut:

- ketika Anda berencana mencetak presentasi Anda dalam format yang sangat besar. Gambar SVG dapat diperbesar ke resolusi atau tingkat apa pun. Anda dapat mengubah ukuran gambar SVG sebanyak yang diperlukan tanpa mengorbankan kualitas.
- ketika Anda berniat menggunakan bagan dan grafik dari slide Anda di media atau platform yang berbeda. Sebagian besar pembaca dapat menafsirkan file SVG. 
- ketika Anda perlu menggunakan ukuran gambar sekecil mungkin. File SVG umumnya lebih kecil daripada setara resolusi tinggi dalam format lain, terutama format berbasis bitmap (JPEG atau PNG).

Aspose.Slides for .NET memungkinkan Anda mengekspor slide dalam presentasi Anda sebagai gambar **SVG**. Untuk menghasilkan gambar SVG dari apa pun, lakukan hal berikut:

- Buat instance kelas Presentation.
- Iterasi melalui semua slide dalam presentasi.
- Tuliskan setiap slide ke file SVG terpisah melalui FileStream.

{{% alert color="info" %}} 

Anda mungkin ingin mencoba [aplikasi web gratis](https://products.aspose.app/slides/id/conversion/ppt-to-svg) di mana kami mengimplementasikan fungsi konversi PPT ke SVG dari Aspose.Slides for .NET.

{{% /alert %}} 

Contoh kode ini dalam C# menunjukkan cara mengonversi PPT ke SVG menggunakan Aspose.Slides:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```