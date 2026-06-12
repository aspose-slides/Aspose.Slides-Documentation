---
title: Konversi Presentasi ke HTML5 dengan Java
linktitle: Presentasi ke HTML5
type: docs
weight: 40
url: /id/java/export-to-html5/
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
- Java
- Aspose.Slides
description: "Ekspor presentasi PowerPoint & OpenDocument ke HTML5 responsif dengan Aspose.Slides untuk Java. Pertahankan pemformatan, animasi, dan interaktivitas."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mengonversi presentasi PowerPoint ke HTML5 menggunakan Aspose.Slides. Ini mencakup ekspor HTML5 dasar tanpa ekstensi web atau dependensi tambahan, serta opsi untuk mengontrol animasi bentuk dan transisi slide. Artikel ini juga menunjukkan proses ekspor standar dari PowerPoint ke HTML, menjelaskan cara menghasilkan output HTML5 dalam mode tampilan slide, dan mendemonstrasikan cara menyertakan komentar dalam dokumen yang diekspor dengan mengonfigurasi tata letaknya.

## **Ekspor PowerPoint ke HTML5**

Kode Java ini menunjukkan cara mengekspor presentasi ke HTML5 tanpa ekstensi web dan dependensi:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

Dalam kasus ini, Anda mendapatkan HTML bersih. 

{{% /alert %}}

Anda mungkin ingin menentukan pengaturan untuk animasi bentuk dan transisi slide dengan cara ini:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    
    pres.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ekspor PowerPoint ke HTML**

Java ini mendemonstrasikan proses standar PowerPoint ke HTML:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

Dalam kasus ini, konten presentasi dirender melalui SVG dalam bentuk berikut:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Note" color="warning" %}} 

Saat Anda menggunakan metode ini untuk mengekspor PowerPoint ke HTML, karena rendering SVG, Anda tidak dapat menerapkan gaya atau menganimasikan elemen tertentu. 

{{% /alert %}}

## **Ekspor PowerPoint ke Tampilan Slide HTML5**

**Aspose.Slides** memungkinkan Anda mengonversi presentasi PowerPoint ke dokumen HTML5 di mana slide ditampilkan dalam mode tampilan slide. Dalam hal ini, ketika Anda membuka file HTML5 yang dihasilkan di peramban, Anda melihat presentasi dalam mode tampilan slide pada halaman web. 

Kode Java ini mendemonstrasikan proses ekspor PowerPoint ke Tampilan Slide HTML5:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);

    pres.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Mengonversi Presentasi ke Dokumen HTML5 dengan Komentar**

Komentar di PowerPoint adalah alat yang memungkinkan pengguna meninggalkan catatan atau umpan balik pada slide presentasi. Mereka sangat berguna dalam proyek kolaboratif, di mana banyak orang dapat menambahkan saran atau catatan pada elemen slide tertentu tanpa mengubah konten utama. Setiap komentar menampilkan nama penulis, sehingga mudah melacak siapa yang memberikan catatan.

Misalkan kita memiliki presentasi PowerPoint berikut yang disimpan dalam file "sample.pptx".

![Two comments on the presentation slide](two_comments_pptx.png)

Saat Anda mengonversi presentasi PowerPoint ke dokumen HTML5, Anda dapat dengan mudah menentukan apakah akan menyertakan komentar dari presentasi dalam dokumen output. Untuk melakukannya, Anda perlu menentukan parameter tampilan untuk komentar dalam metode `getNotesCommentsLayouting` dari kelas [Html5Options](https://reference.aspose.com/slides/id/java/com.aspose.slides/html5options/).

Contoh kode berikut mengonversi presentasi ke dokumen HTML5 dengan komentar yang ditampilkan di sebelah kanan slide.
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

Dokumen "output.html" ditampilkan pada gambar di bawah ini.

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

**Apakah saya dapat mengontrol apakah animasi objek dan transisi slide akan diputar di HTML5?**

Ya, HTML5 menyediakan opsi terpisah untuk mengaktifkan atau menonaktifkan [shape animations](https://reference.aspose.com/slides/id/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) dan [slide transitions](https://reference.aspose.com/slides/id/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Apakah output komentar didukung, dan di mana mereka dapat ditempatkan relatif terhadap slide?**

Ya, komentar dapat ditambahkan dalam HTML5 dan diposisikan (misalnya, di sebelah kanan slide) melalui [layout settings](https://reference.aspose.com/slides/id/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) untuk catatan dan komentar.

**Apakah saya dapat melewatkan tautan yang memanggil JavaScript demi keamanan atau alasan CSP?**

Ya, ada [setting](https://reference.aspose.com/slides/id/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) yang memungkinkan Anda melewatkan hyperlink dengan panggilan JavaScript saat menyimpan. Ini membantu mematuhi kebijakan keamanan yang ketat.