---
title: Evaluasi Aspose.Slides
type: docs
weight: 120
url: /id/nodejs-net/evaluate-aspose-slides/
keywords:
- evaluasi Aspose.Slides
- versi evaluasi
- watermark evaluasi
- batasan percobaan
- lisensi sementara
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Apa yang dibatasi oleh versi evaluasi Aspose.Slides untuk Node.js via .NET, dengan skrip yang menunjukkan kedua batasan serta cara menghapusnya dengan lisensi."
---
## **Gambaran Umum**

Versi evaluasi Aspose.Slides untuk Node.js via .NET adalah paket npm yang sama dengan versi berlisensi. Tanpa lisensi, paket ini berjalan dalam mode evaluasi: semua fitur berfungsi, tetapi presentasi yang disimpan dan sebagian besar ekspor menambahkan watermark, dan teks yang dibaca kembali oleh kode Anda dipotong. Artikel ini menjelaskan kedua keterbatasan tersebut dan menunjukkan cara menghapusnya.

## **Batasan Evaluasi**

**Watermark evaluasi pada setiap slide.** Ketika Anda menyimpan presentasi tanpa lisensi, Aspose.Slides menambahkan kotak teks di tengah setiap slide pada file yang disimpan. Kotak teks tersebut terkunci dan berisi "Evaluation only." diikuti oleh baris produk dan baris hak cipta. Watermark dimasukkan ke dalam file yang disimpan, bukan ke dalam presentasi dalam memori, dan membuka presentasi tidak menambahnya. Namun, file yang telah disimpan dalam mode evaluasi sudah berisi kotak teks tersebut, sehingga membuka dan menyimpannya kembali menambahkan watermark kedua pada setiap slide.

Watermark yang sama digambar pada output ketika Anda mengekspor ke PDF, XPS, atau HTML, atau merender slide sebagai gambar. Jika Anda merender presentasi yang sudah disimpan dalam mode evaluasi, gambar akan menampilkan kedua watermark, yang disimpan dan yang dirender.

**Teks terpotong ketika kode Anda membacanya.** Teks yang dibaca kode Anda melalui properti `text` dari sebuah bingkai teks, paragraf, atau bagian dipotong menjadi lima karakter pertama, diikuti dengan pemberitahuan "... text has been truncated due to evaluation version limitation." Teks dengan lima karakter atau kurang dikembalikan secara lengkap. Hal ini berlaku pada setiap slide, bahkan pada teks yang baru saja ditetapkan oleh kode Anda. Ekspor Markdown dan HTML5 dipotong dengan cara yang sama.

Teks yang ditulis kode Anda disimpan secara lengkap: file PPTX, halaman PDF, dan gambar slide berisi teks lengkap.

## **Lihat Batasan dalam Skrip**

Skrip berikut menunjukkan kedua batasan. Skrip ini mengasumsikan Anda telah menginstal paket seperti dijelaskan di [Instalasi](/slides/id/nodejs-net/installation/) dan Anda menjalankannya dari folder proyek. Skrip ini menambahkan persegi panjang dengan sebuah kalimat ke slide pertama, membaca kembali kalimat tersebut, menyimpan presentasi sebagai `evaluation.pptx`, lalu membuka kembali file untuk menghitung bentuk di slide.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 500, 100);
    rectangle.textFrame.text = "Quarterly results are ready for review.";

    // Tanpa lisensi, hanya lima karakter pertama yang dikembalikan.
    console.log("Text read back:", rectangle.textFrame.text);

    // Menyimpan menambahkan watermark evaluasi ke setiap slide dalam file.
    presentation.save("evaluation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new Presentation("evaluation.pptx");
try {
    // Slide sekarang berisi persegi panjang dan kotak teks watermark.
    console.log("Shapes on the saved slide:", savedPresentation.slides.get(0).shapes.count);
} finally {
    savedPresentation.dispose();
}
```

Tanpa lisensi, skrip mencetak:

```text
Text read back: Quart... text has been truncated due to evaluation version limitation.
Shapes on the saved slide: 2
```

Bentuk kedua adalah kotak teks watermark. Buka `evaluation.pptx` untuk melihat kalimat lengkap dalam persegi panjang dan watermark di tengah slide.

## **Hapus Batasan**

Untuk menghapus kedua batasan, terapkan lisensi sebelum Anda membuat objek `Presentation` apa pun. [Lisensi](/slides/id/nodejs-net/licensing/) menunjukkan cara menerapkan file lisensi.

{{% alert color="success" title="Tip" %}}
Untuk menguji Aspose.Slides tanpa batasan evaluasi sebelum Anda membeli, minta **lisensi sementara 30 hari** gratis. Lihat [Bagaimana cara mendapatkan Lisensi Sementara?](https://purchase.aspose.com/temporary-license) untuk detail.
{{% /alert %}}

## **FAQ**

**Apakah mode evaluasi membatasi jumlah slide?**  
Tidak. Presentasi dibuat, dibuka, dan disimpan dengan semua slidennya. Watermark dan pemotongan teks diterapkan pada setiap slide secara sama.

**Mengapa gambar slide yang saya ekspor menampilkan watermark dua kali?**  
Presentasi disimpan dalam mode evaluasi sebelum Anda merendernya, sehingga sudah berisi kotak teks watermark, dan merender tanpa lisensi menggambar satu lagi di atasnya.

**Apakah saya dapat memeriksa bahwa kode saya menghasilkan teks yang benar dalam mode evaluasi?**  
Ya. Buka file yang disimpan atau PDF yang diekspor: keduanya berisi teks lengkap. Hanya teks yang dibaca kembali oleh kode Anda, serta output Markdown atau HTML5, yang dipotong.