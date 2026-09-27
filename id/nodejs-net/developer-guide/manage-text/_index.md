---
title: Kelola Teks Presentasi di Node.js via .NET
linktitle: Kelola Teks
type: docs
weight: 50
url: /id/nodejs-net/manage-text/
keywords:
- teks
- kotak teks
- menambahkan teks
- mengubah teks
- memformat teks
- ukuran font
- teks tebal
- bingkai teks
- paragraf
- bagian
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Tambahkan kotak teks ke slide, lalu ubah teks, ukuran font, dan gaya tebalnya dalam JavaScript dengan Aspose.Slides untuk Node.js via .NET."
---
## **Gambaran Umum**

Di Aspose.Slides, teks pada slide menjadi bagian dari sebuah shape. Sebuah auto shape, seperti persegi panjang, memiliki teks frame; teks frame berisi paragraf, dan setiap paragraf berisi portion, yaitu rangkaian teks dengan format yang sama. Anda mengubah teks melalui teks frame dan mengubah font melalui format portion.

Artikel ini menambahkan kotak teks ke sebuah slide dan menyimpan presentasi. Kemudian membuka file yang disimpan dan mengubah teks, ukuran font, serta gaya tebal kotak teks tersebut.

Contoh‑contoh memerlukan proyek yang disiapkan seperti yang dijelaskan dalam [Instalasi](/slides/id/nodejs-net/installation/). Simpan setiap contoh sebagai file `.js` di folder proyek dan jalankan dari folder itu dengan `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides untuk Node.js via .NET tidak memiliki referensi API tersendiri. Ia mencerminkan API Aspose.Slides untuk .NET dengan nama camelCase, sehingga tautan API dalam artikel ini mengarah ke kelas dan anggota yang sesuai dalam [referensi API Aspose.Slides untuk .NET](https://reference.aspose.com/slides/id/net/).
{{% /alert %}}

## **Menambahkan Kotak Teks**

Untuk menambahkan kotak teks, tambahkan auto shape ke slide dengan metode [addAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/shapecollection/addautoshape/) dan berikan teks dengan metode [addTextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/autoshape/addtextframe/). Contoh berikut menambahkan persegi panjang ke slide pertama dari presentasi baru dan menyimpan presentasi sebagai `text-box.pptx`:

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Posisi (x, y) dan ukuran (lebar, tinggi) dalam satuan poin.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80);
    textBox.addTextFrame("Quarterly report");

    presentation.save("text-box.pptx", SaveFormat.Pptx);
    console.log("Saved text-box.pptx");
} finally {
    presentation.dispose();
}
```

Slide dalam `text-box.pptx` berisi persegi panjang berukuran 500 poin lebar dan 80 poin tinggi, dengan teks "Quarterly report" menggunakan font dan ukuran default. Contoh berikutnya mengubah kotak teks ini.

## **Mengubah Teks dan Pemformatannya**

Contoh berikut membuka `text-box.pptx`, yang dibuat pada contoh sebelumnya, dan mengambil shape pertama pada slide pertama. Shape seperti gambar dan tabel tidak memiliki teks frame, sehingga contoh memeriksa apakah shape tersebut merupakan [AutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/autoshape/) sebelum menggunakan [textFrame](https://reference.aspose.com/slides/id/net/aspose.slides/autoshape/textframe/) milik shape. Selanjutnya dilakukan hal‑hal berikut:

1. Mengganti teks melalui properti [text](https://reference.aspose.com/slides/id/net/aspose.slides/textframe/text/) pada teks frame. Setelah itu, teks frame berisi satu paragraf dengan satu portion.
2. Mengambil portion tersebut dari koleksi [paragraphs](https://reference.aspose.com/slides/id/net/aspose.slides/textframe/paragraphs/) dan [portions](https://reference.aspose.com/slides/id/net/aspose.slides/paragraph/portions/) serta membaca [portionFormat](https://reference.aspose.com/slides/id/net/aspose.slides/portion/portionformat/).
3. Menetapkan [fontHeight](https://reference.aspose.com/slides/id/net/aspose.slides/baseportionformat/fontheight/), ukuran font dalam poin, dan [fontBold](https://reference.aspose.com/slides/id/net/aspose.slides/baseportionformat/fontbold/), yang menerima nilai [NullableBool](https://reference.aspose.com/slides/id/net/aspose.slides/nullablebool/).

```javascript
const { Presentation, AutoShape, NullableBool, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("text-box.pptx");
try {
    const shape = presentation.slides.get(0).shapes.get(0);
    if (shape instanceof AutoShape) {
        const textFrame = shape.textFrame;
        textFrame.text = "Quarterly report: third quarter";

        const portionFormat = textFrame.paragraphs.get(0).portions.get(0).portionFormat;
        portionFormat.fontHeight = 32;
        portionFormat.fontBold = NullableBool.True;

        presentation.save("text-box-updated.pptx", SaveFormat.Pptx);
        console.log("Saved text-box-updated.pptx");
    } else {
        console.log("The first shape on the first slide is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

Dalam `text-box-updated.pptx`, kotak teks menampilkan "Quarterly report: third quarter" dengan tipe tebal 32 poin. Karena teks baru merupakan satu portion, dua properti pemformatan diterapkan ke seluruhnya. Tanpa lisensi, setiap penyimpanan menambahkan watermark evaluasi. Karena `text-box.pptx` sendiri disimpan dalam mode evaluasi, `text-box-updated.pptx` berisi dua watermark; lihat [Evaluasi Aspose.Slides](/slides/id/nodejs-net/evaluate-aspose-slides/).

## **FAQ**

**Mengapa `fontBold` menerima nilai `NullableBool` bukan `true` atau `false`?**

Sebuah portion dapat membiarkan properti tidak terdefinisi dan mewarisinya dari paragraf, shape, atau tata letak dan master slide. `NullableBool.NotDefined` berarti "inherit", sedangkan `NullableBool.True` dan `NullableBool.False` menggantikan nilai yang diwarisi. Menetapkan `true` atau `false` akan menghasilkan error. Untuk alasan yang sama, `fontHeight` mengembalikan `NaN` ketika portion mewarisi ukuran font.

**Bagaimana cara mengubah warna teks?**

Setel isian format portion: berikan `FillType.Solid` ke `portionFormat.fillFormat.fillType`, lalu berikan warna seperti `"#FF0000"` ke `portionFormat.fillFormat.solidFillColor.color`. Tambahkan `FillType` ke nama‑nama yang Anda impor dari paket.

**Bagaimana cara memformat hanya sebagian teks?**

Pemformatan berlaku pada portions, jadi tempatkan bagian teks yang ingin diformat dalam portion tersendiri. Buat portion dengan `Portion.CreatePortionFromText`, tambahkan ke paragraf menggunakan metode `add` pada koleksi `portions` paragraf, lalu setel `portionFormat` untuk portion baru tersebut. Tambahkan `Portion` ke nama‑nama yang Anda impor dari paket.

**Mengapa membaca teks mengembalikan "... text has been truncated due to evaluation version limitation"?**

Tanpa lisensi, Aspose.Slides hanya mengembalikan lima karakter pertama dari teks yang lebih panjang saat Anda membacanya, seperti `textFrame.text`, diikuti pemberitahuan ini. Teks yang Anda tulis disimpan secara penuh. Terapkan lisensi sebagaimana dijelaskan dalam [Lisensi](/slides/id/nodejs-net/licensing/) untuk membaca teks lengkap.