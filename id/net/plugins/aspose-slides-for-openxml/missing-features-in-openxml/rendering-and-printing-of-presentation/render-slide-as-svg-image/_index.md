---
title: Render Slide Sebagai Gambar SVG
type: docs
weight: 50
url: /id/net/render-slide-as-svg-image/
---
SVG—singkatan dari Scalable Vector Graphics—adalah tipe atau format grafis standar yang digunakan untuk merender gambar dua dimensi. SVG menyimpan gambar sebagai vektor dalam XML dengan detail yang menentukan perilaku atau tampilannya. 

SVG adalah salah satu sedikit format gambar yang memenuhi standar sangat tinggi dalam hal: skalabilitas, interaktivitas, kinerja, aksesibilitas, dapat diprogram, dan lain-lain. Karena alasan‑alas ini, SVG biasanya digunakan dalam pengembangan web. 

Anda mungkin ingin menggunakan file SVG dalam skenario berikut:

- ketika Anda berencana mencetak presentasi dalam format sangat besar. Gambar SVG dapat diskalakan ke resolusi atau tingkat berapa pun. Anda dapat mengubah ukuran gambar SVG berkali‑kali tanpa mengorbankan kualitas.
- ketika Anda ingin menggunakan bagan dan grafik dari slide Anda di media atau platform yang berbeda. Sebagian besar pembaca dapat menafsirkan file SVG. 
- ketika Anda memerlukan ukuran gambar sekecil mungkin. File SVG biasanya lebih kecil daripada setara resolusi tinggi dalam format lain, terutama format berbasis bitmap (JPEG atau PNG).

Aspose.Slides for .NET memungkinkan Anda mengekspor slide dalam presentasi sebagai gambar **SVG**. Untuk menghasilkan gambar SVG dari apa pun, lakukan hal berikut:

- Buat instance kelas Presentation. 
- Iterasi melalui semua slide dalam presentasi. 
- Tulis setiap slide ke file SVG terpisah melalui FileStream.

{{% alert color="primary" %}} 

Anda dapat mencoba [aplikasi web gratis](https://products.aspose.app/slides/id/conversion/ppt-to-svg) kami di mana kami mengimplementasikan fungsi konversi PPT ke SVG dari Aspose.Slides for .NET.

{{% /alert %}} 

Kode contoh ini dalam C# menunjukkan cara mengonversi PPT ke SVG menggunakan Aspose.Slides:

``` csharp
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