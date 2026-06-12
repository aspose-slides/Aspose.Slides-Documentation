---
title: Konversi Presentasi ke HTML5 dalam PHP
linktitle: Presentasi ke HTML5
type: docs
weight: 40
url: /id/php-java/export-to-html5/
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
- PHP
- Aspose.Slides
description: "Ekspor presentasi PowerPoint & OpenDocument ke HTML5 responsif dengan Aspose.Slides untuk PHP via Java. Pertahankan format, animasi, dan interaktivitas."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengonversi presentasi PowerPoint ke HTML5 menggunakan Aspose.Slides. Artikel ini mencakup ekspor HTML5 dasar tanpa ekstensi web atau dependensi tambahan, serta opsi untuk mengendalikan animasi bentuk dan transisi slide. Artikel ini juga menunjukkan proses ekspor standar PowerPoint ke HTML, menjelaskan cara menghasilkan output HTML5 dalam mode tampilan slide, dan mendemonstrasikan cara menyertakan komentar dalam dokumen yang diekspor dengan mengonfigurasi tata letaknya.

## **Ekspor PowerPoint ke HTML5**

Kode PHP ini menunjukkan cara mengekspor presentasi ke HTML5 tanpa ekstensi web dan dependensi:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.html", SaveFormat::Html5);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
Dalam kasus ini, Anda mendapatkan HTML bersih. 
{{% /alert %}}

Anda mungkin ingin menentukan pengaturan untuk animasi bentuk dan transisi slide dengan cara ini:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $html5Options = new Html5Options();
    $html5Options->setAnimateShapes(false);
    $html5Options->setAnimateTransitions(false);
    $pres->save("pres5.html", SaveFormat::Html5, $html5Options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ekspor PowerPoint ke HTML**

Java ini mendemonstrasikan proses standar ekspor PowerPoint ke HTML:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.html", SaveFormat::Html);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
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
```php

```

{{% alert title="Note" color="warning" %}} 

When you use this method to export PowerPoint to HTML, due to the SVG rendering, you will not be to apply styles or animate specific elements. 

{{% /alert %}}

## **Export PowerPoint to HTML5 Slide View**

**Aspose.Slides** allows you to convert a PowerPoint presentation to an HTML5 document in which the slides are presented in a slide view mode. In this case, when you open the resulting HTML5 file in a browser, you see the presentation in slide view mode on a web page. 

This PHP code demonstrates the PowerPoint to HTML5 Slide View export process:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $html5Options = new Html5Options();
    $html5Options->setAnimateShapes(true);
    $html5Options->setAnimateTransitions(true);
    $pres->save("HTML5-slide-view.html", SaveFormat::Html5, $html5Options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Convert Presentations to HTML5 Documents with Comments**

Comments in PowerPoint are a tool that allows users to leave notes or feedback on presentation slides. They are especially useful in collaborative projects, where multiple people can add their suggestions or remarks to specific slide elements without altering the main content. Each comment shows the author's name, making it easy to track who left the remark.

Let's say we have the following PowerPoint presentation saved in the "sample.pptx" file.

![Two comments on the presentation slide](two_comments_pptx.png)

When you convert a PowerPoint presentation to an HTML5 document, you can easily specify whether to include comments from the presentation in the output document. To do this, you need to specify the display parameters for comments in the `getNotesCommentsLayouting` method of the `Html5Options` class.

The following code example converts a presentation to an HTML5 document with comments displayed to the right of the slides.
```php
$html5Options = new Html5Options();
$html5Options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);

$presentation = new Presentation("sample.pptx");
$presentation->save("output.html", SaveFormat::Html5, $html5Options);
$presentation->dispose();

Dokumen "output.html" ditampilkan pada gambar di bawah ini.

![Komentar dalam dokumen HTML5 output](two_comments_html5.png)

## **FAQ**

**Apakah saya dapat mengontrol apakah animasi objek dan transisi slide akan diputar di HTML5?**

Ya, HTML5 menyediakan opsi terpisah untuk mengaktifkan atau menonaktifkan [animasi bentuk](https://reference.aspose.com/slides/id/php-java/aspose.slides/html5options/setanimateshapes/) dan [transisi slide](https://reference.aspose.com/slides/id/php-java/aspose.slides/html5options/setanimatetransitions/).

**Apakah output komentar didukung, dan di mana komentar dapat ditempatkan relatif terhadap slide?**

Ya, komentar dapat ditambahkan dalam HTML5 dan diposisikan (misalnya, di sebelah kanan slide) melalui [pengaturan tata letak](https://reference.aspose.com/slides/id/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) untuk catatan dan komentar.

**Apakah saya dapat melewatkan tautan yang memanggil JavaScript karena alasan keamanan atau CSP?**

Ya, ada [pengaturan](https://reference.aspose.com/slides/id/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) yang memungkinkan Anda melewatkan hyperlink dengan panggilan JavaScript saat menyimpan. Ini membantu mematuhi kebijakan keamanan yang ketat.