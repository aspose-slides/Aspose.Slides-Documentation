---
title: Konversi Presentasi ke HTML5 dengan JavaScript
linktitle: Presentasi ke HTML5
type: docs
weight: 40
url: /id/nodejs-java/export-to-html5/
keywords:
- PowerPoint ke HTML5
- OpenDocument ke HTML5
- presentasi ke HTML5
- slide ke HTML5
- PPT ke HTML5
- PPTX ke HTML5
- ODP ke HTML5
- simpan PPT sebagai HTML5
- simpan PPTX sebagai HTML5
- simpan ODP sebagai HTML5
- ekspor PPT ke HTML5
- ekspor PPTX ke HTML5
- ekspor ODP ke HTML5
- Node.js
- JavaScript
- Aspose.Slides
description: "Ekspor presentasi PowerPoint & OpenDocument ke HTML5 responsif dengan Aspose.Slides untuk Node.js. Pertahankan format, animasi, dan interaktivitas."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mengonversi presentasi PowerPoint ke HTML5 menggunakan Aspose.Slides. Ini mencakup ekspor HTML5 dasar tanpa ekstensi web atau dependensi tambahan, serta opsi untuk mengontrol animasi bentuk dan transisi slide. Artikel ini juga menunjukkan proses ekspor standar PowerPoint-ke-HTML, menjelaskan cara menghasilkan output HTML5 dalam mode tampilan slide, dan memperagakan cara menyertakan komentar dalam dokumen yang diekspor dengan mengonfigurasi tata letaknya.

## **Ekspor PowerPoint ke HTML5**

Kode JavaScript ini menunjukkan cara mengekspor presentasi ke HTML5 tanpa ekstensi web dan dependensi:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 
Dalam kasus ini, Anda mendapatkan HTML bersih. 
{{% /alert %}}

Anda mungkin ingin menentukan pengaturan untuk animasi bentuk dan transisi slide dengan cara ini:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    pres.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ekspor PowerPoint ke HTML**

JavaScript ini memperagakan proses standar PowerPoint ke HTML:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Dalam kasus ini, konten presentasi dirender melalui SVG dalam bentuk seperti ini:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Catatan" color="warning" %}} 
Ketika Anda menggunakan metode ini untuk mengekspor PowerPoint ke HTML, karena rendering SVG, Anda tidak dapat menerapkan gaya atau memberi animasi pada elemen tertentu. 
{{% /alert %}}

## **Ekspor PowerPoint ke Tampilan Slide HTML5**

**Aspose.Slides** memungkinkan Anda mengonversi presentasi PowerPoint ke dokumen HTML5 di mana slide ditampilkan dalam mode tampilan slide. Dalam hal ini, ketika Anda membuka file HTML5 yang dihasilkan di browser, Anda melihat presentasi dalam mode tampilan slide di halaman web. 

Kode JavaScript ini memperagakan proses ekspor PowerPoint ke Tampilan Slide HTML5:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);
    pres.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Konversi Presentasi ke Dokumen HTML5 dengan Komentar**

Komentar di PowerPoint adalah alat yang memungkinkan pengguna meninggalkan catatan atau umpan balik pada slide presentasi. Mereka sangat berguna dalam proyek kolaboratif, di mana banyak orang dapat menambahkan saran atau catatan mereka pada elemen slide tertentu tanpa mengubah konten utama. Setiap komentar menampilkan nama penulis, sehingga mudah melacak siapa yang memberi catatan.

Misalkan kita memiliki presentasi PowerPoint berikut yang disimpan dalam file "sample.pptx".

![Dua komentar pada slide presentasi](two_comments_pptx.png)

Saat Anda mengonversi presentasi PowerPoint ke dokumen HTML5, Anda dapat dengan mudah menentukan apakah akan menyertakan komentar dari presentasi dalam dokumen output. Untuk melakukannya, Anda perlu menentukan parameter tampilan untuk komentar dalam properti `notes_comments_layouting` dari kelas [Html5Options](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/html5options/).

Contoh kode berikut mengonversi presentasi ke dokumen HTML5 dengan komentar yang ditampilkan di sebelah kanan slide.
```javascript
let html5Options = new aspose.slides.Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(aspose.slides.CommentsPositions.Right);

let presentation = new aspose.slides.Presentation("sample.pptx");
presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
presentation.dispose();
```

Dokumen "output.html" ditampilkan pada gambar di bawah ini.

![Komentar dalam dokumen HTML5 output](two_comments_html5.png)

## **FAQ**

**Apakah saya dapat mengontrol apakah animasi objek dan transisi slide akan diputar di HTML5?**

Ya, HTML5 menyediakan opsi terpisah untuk mengaktifkan atau menonaktifkan [animasi bentuk](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/html5options/setanimateshapes/) dan [transisi slide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/html5options/setanimatetransitions/).

**Apakah output komentar didukung, dan di mana dapat ditempatkan relatif terhadap slide?**

Ya, komentar dapat ditambahkan di HTML5 dan diposisikan (misalnya, di sebelah kanan slide) melalui [pengaturan tata letak](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/html5options/#setNotesCommentsLayouting) untuk catatan dan komentar.

**Apakah saya dapat melewatkan tautan yang memanggil JavaScript untuk alasan keamanan atau CSP?**

Ya, ada [pengaturan](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) yang memungkinkan Anda melewatkan hyperlink dengan panggilan JavaScript selama penyimpanan. Ini membantu mematuhi kebijakan keamanan yang ketat.