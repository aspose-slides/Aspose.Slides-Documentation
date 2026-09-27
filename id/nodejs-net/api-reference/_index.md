---
title: Referensi API
type: docs
weight: 50
url: /id/nodejs-net/api-reference/
description: "Aspose.Slides for Node.js via .NET didokumentasikan oleh referensi API Aspose.Slides untuk .NET. Lihat bagaimana nama kelas dan anggota .NET dipetakan ke JavaScript."
---
## **Ikhtisar**

Aspose.Slides for Node.js via .NET tidak memiliki referensi API tersendiri. Paket ini mengekspos kelas‑kelas Aspose.Slides untuk .NET ke JavaScript dengan nama yang sama, dengan nama anggota camelCase, sehingga [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/id/net/) mendokumentasikan kelas, anggota, dan enumerasinya.

## **Pemetaan Nama .NET ke JavaScript**

- **Kelas dan enumerasi mempertahankan nama .NET mereka**, begitu pula nilai enumerasi: `Presentation`, `ShapeType.Rectangle`, `SaveFormat.Pdf`. Impor mereka dari paket: `const { Presentation, SaveFormat } = require("aspose.slides.via.net");`.
- **Properti dan metode dimulai dengan huruf kecil.** `Presentation.Slides` menjadi `presentation.slides`, dan `ShapeCollection.AddAutoShape` menjadi `shapes.addAutoShape`. Properti tetap properti: Anda membacanya dan menetapkannya tanpa tanda kurung.
- **Item koleksi dibaca dengan `get(index)`**, dan jumlah item dengan `count`: `presentation.slides.get(0)` bukan `presentation.Slides[0]`.
- **Beberapa overload memiliki nama terpisah.** Misalnya, overload `Slide.GetImage(Size)` menjadi `slide.getImageWithImageSize({ width, height })`. Lainnya berbagi satu metode dengan argumen opsional di akhir: `presentation.save(path, format, options, slides)` mencakup beberapa overload `Presentation.Save`, dan `new Presentation(null, buffer)` membuka presentasi dari sebuah `Buffer`. Setiap kelas berada dalam satu file di bawah folder `lib` paket (misalnya, `node_modules/aspose.slides.via.net/lib/Slide.js`), dimana Anda dapat mencari nama yang tepat.
- **Lepaskan presentasi dengan `dispose`** ketika Anda selesai menggunakannya; JavaScript tidak memiliki pernyataan `using`.

Paket ini tidak membungkus setiap anggota .NET. Jika sebuah anggota dari referensi API .NET tidak ada dalam file kelas, maka tidak tersedia di JavaScript.

## **Contoh**

Script berikut menggunakan aturan di atas. Setiap komentar menunjukkan panggilan .NET yang sesuai dengan baris berikutnya. Script ini menambahkan sebuah persegi panjang dengan teks ke slide pertama, merender slide sebagai gambar PNG berukuran 960 × 540 piksel, dan menyimpan presentasi sebagai PDF. Jalankan dari folder proyek dimana paket diinstal seperti dijelaskan pada [Installation](/slides/id/nodejs-net/installation/).

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat, ImageFormat } = asposeSlides;

const presentation = new Presentation();
try {
    // .NET: presentation.Slides[0]
    const slide = presentation.slides.get(0);

    // .NET: slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);

    // .NET: rectangle.TextFrame.Text = "..."
    rectangle.textFrame.text = "Names follow the .NET API in camelCase.";

    // .NET: slide.GetImage(new Size(960, 540))
    const slideImage = slide.getImageWithImageSize({ width: 960, height: 540 });
    slideImage.save("slide.png", ImageFormat.Png);
    slideImage.dispose();

    // .NET: presentation.Save("slide.pdf", SaveFormat.Pdf)
    presentation.save("slide.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Script ini menulis `slide.png` dan `slide.pdf` ke folder saat ini. Keduanya menampilkan persegi panjang dengan teksnya. Tanpa lisensi, mereka juga menampilkan watermark evaluasi; lihat [Licensing](/slides/id/nodejs-net/licensing/).

Untuk detail tentang anggota yang digunakan di sini, lihat [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/), [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/shapecollection/addautoshape/), [TextFrame.Text](https://reference.aspose.com/slides/id/net/aspose.slides/textframe/text/) dan [Slide.GetImage](https://reference.aspose.com/slides/id/net/aspose.slides/slide/getimage/) di referensi API Aspose.Slides untuk .NET.