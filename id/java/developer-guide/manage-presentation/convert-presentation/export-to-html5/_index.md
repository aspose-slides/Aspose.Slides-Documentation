---
title: Mengonversi Presentasi ke HTML5 dengan Java
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
description: "Ekspor presentasi PowerPoint & OpenDocument ke HTML5 responsif dengan Aspose.Slides untuk Java. Pertahankan format, animasi, dan interaktivitas."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mengonversi presentasi PowerPoint ke HTML5 menggunakan Aspose.Slides. Artikel ini mencakup ekspor HTML5 dasar tanpa ekstensi web atau ketergantungan tambahan, serta opsi untuk mengendalikan animasi bentuk dan transisi slide. Artikel ini juga menunjukkan proses ekspor standar dari PowerPoint ke HTML, menjelaskan cara menghasilkan output HTML5 dalam mode tampilan slide, dan mendemonstrasikan cara menyertakan komentar dalam dokumen yang diekspor dengan mengonfigurasi tata letaknya.

## **Ekspor PowerPoint ke HTML5**

Kode Java ini menunjukkan cara mengekspor presentasi ke HTML5 tanpa ekstensi web dan ketergantungan:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
Pada kasus ini, Anda mendapatkan HTML yang bersih. 
{{% /alert %}}

Anda dapat menentukan pengaturan untuk animasi bentuk dan transisi slide dengan cara ini:

```java
import com.aspose.slides.*;

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

Kode Java ini mendemonstrasikan proses standar PowerPoint ke HTML:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

Pada kasus ini, konten presentasi dirender melalui SVG dalam bentuk seperti ini:

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
Saat Anda menggunakan metode ini untuk mengekspor PowerPoint ke HTML, karena render SVG, Anda tidak dapat menerapkan gaya atau menganimasikan elemen tertentu. 
{{% /alert %}}

## **Ekspor PowerPoint ke Tampilan Slide HTML5**

**Aspose.Slides** memungkinkan Anda mengonversi presentasi PowerPoint ke dokumen HTML5 di mana slide ditampilkan dalam mode tampilan slide. Dalam kasus ini, ketika Anda membuka file HTML5 yang dihasilkan di peramban, Anda melihat presentasi dalam mode tampilan slide pada halaman web. 

Kode Java ini mendemonstrasikan proses ekspor PowerPoint ke Tampilan Slide HTML5:

```java
import com.aspose.slides.*;

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

## **Konversi Presentasi ke Dokumen HTML5 dengan Komentar**

Komentar dalam PowerPoint adalah alat yang memungkinkan pengguna meninggalkan catatan atau umpan balik pada slide presentasi. Komentar sangat berguna dalam proyek kolaboratif, di mana banyak orang dapat menambahkan saran atau catatan mereka pada elemen slide tertentu tanpa mengubah konten utama. Setiap komentar menampilkan nama penulis, sehingga mudah melacak siapa yang memberi catatan.

Misalkan kita memiliki presentasi PowerPoint berikut yang disimpan dalam file "sample.pptx".

![Dua komentar pada slide presentasi](two_comments_pptx.png)

Saat Anda mengonversi presentasi PowerPoint ke dokumen HTML5, Anda dapat dengan mudah menentukan apakah menyertakan komentar dari presentasi dalam dokumen output. Untuk melakukan ini, berikan parameter tampilan untuk komentar ke metode `setSlidesLayoutOptions` dari kelas [Html5Options](https://reference.aspose.com/slides/id/java/com.aspose.slides/html5options/).

Contoh kode berikut mengonversi presentasi ke dokumen HTML5 dengan komentar ditampilkan di sebelah kanan slide.
```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setCommentsPosition(CommentsPositions.Right);
html5Options.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

Dokumen "output.html" ditampilkan pada gambar di bawah.

![Komentar dalam dokumen HTML5 output](two_comments_html5.png)

## **FAQ**

### Apakah saya dapat mengontrol apakah animasi objek dan transisi slide akan diputar di HTML5?

Ya, HTML5 menyediakan opsi terpisah untuk mengaktifkan atau menonaktifkan [animasi bentuk](https://reference.aspose.com/slides/id/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) dan [transisi slide](https://reference.aspose.com/slides/id/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

### Apakah output komentar didukung, dan di mana dapat ditempatkan relatif terhadap slide?

Ya, komentar dapat ditambahkan dalam HTML5 dan diposisikan (misalnya, di sebelah kanan slide) melalui [pengaturan tata letak](https://reference.aspose.com/slides/id/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) untuk catatan dan komentar.

### Apakah saya dapat melewatkan tautan yang memanggil JavaScript karena alasan keamanan atau CSP?

Ya, ada [pengaturan](https://reference.aspose.com/slides/id/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) yang memungkinkan Anda melewatkan hyperlink dengan panggilan JavaScript saat menyimpan. Ini membantu mematuhi kebijakan keamanan yang ketat.