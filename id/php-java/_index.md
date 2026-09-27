---
title: Aspose.Slides untuk PHP via Java
second_title: Aspose.Slides untuk PHP
type: docs
weight: 45
url: /id/php-java/
keywords:
- dokumentasi
- pemrosesan presentasi
- konversi presentasi
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Mulai di sini: instal Aspose.Slides untuk PHP via Java, buat presentasi pertama, dan temukan panduan untuk tugas umum, referensi API, dan dukungan."
is_root: true
---
<img src="aspose_slides-for-php-via-java.png" alt="Aspose.Slides for PHP via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for PHP via Java adalah pustaka kelas untuk membuat, membaca, mengedit, dan mengonversi presentasi PowerPoint dan OpenDocument dalam aplikasi PHP, tanpa Microsoft PowerPoint atau Office Automation.

Ia memuat dan menyimpan PPT, PPTX, PPS, POT, dan ODP, termasuk varian yang mendukung makro dan templat, serta mengekspor ke PDF, XPS, HTML, SVG, TIFF, Markdown, dan gambar.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Mulai</b></p>
<hr>
<p>MEMULAI</p>
<ul>
<li><a href="/slides/id/php-java/installation/">Instalasi</a></li>
<li><a href="/slides/id/php-java/create-presentation/">Buat presentasi pertama Anda</a></li>
<li><a href="/slides/id/php-java/getting-started/">Panduan memulai</a></li>
</ul>
<p>EVALUASI</p>
<ul>
<li><a href="/slides/id/php-java/supported-file-formats/">Format file yang didukung</a></li>
<li><a href="/slides/id/php-java/evaluate-aspose-slides/">Batasan percobaan</a></li>
<li><a href="/slides/id/php-java/licensing/">Lisensi</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Bangun dengan Slides</b></p>
<hr>
<p>TUGAS UMUM</p>
<ul>
<li><a href="/slides/id/php-java/open-presentation/">Buka presentasi</a></li>
<li><a href="/slides/id/php-java/save-presentation/">Simpan presentasi</a></li>
<li><a href="/slides/id/php-java/convert-powerpoint-to-pdf/">Konversi ke PDF</a></li>
<li><a href="/slides/id/php-java/convert-slide/">Render slide sebagai gambar</a></li>
<li><a href="/slides/id/php-java/manage-text/">Sunting teks dan bentuk</a></li>
</ul>
<p>ALUR KERJA SLIDES</p>
<ul>
<li><a href="/slides/id/php-java/powerpoint-charts/">Diagram</a></li>
<li><a href="/slides/id/php-java/powerpoint-animation/">Animasi</a></li>
<li><a href="/slides/id/php-java/manage-media-files/">Audio dan video</a></li>
<li><a href="/slides/id/php-java/presentation-design/">Desain slide</a></li>
<li><a href="/slides/id/php-java/merge-presentation/">Gabungkan presentasi</a></li>
</ul>
<p>CONTOH</p>
<ul>
<li><a href="/slides/id/php-java/examples/">Contoh per elemen slide</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referensi &amp; Dukungan</b></p>
<hr>
<p>REFERENSI</p>
<ul>
<li><a href="https://reference.aspose.com/slides/php-java/">Referensi API</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/release-notes/">Catatan rilis</a></li>
<li><a href="/slides/id/php-java/known-issues/">Masalah yang diketahui</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/">Unduh</a></li>
</ul>
<p>DUKUNGAN</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Forum dukungan gratis</a></li>
<li><a href="https://helpdesk.aspose.com/">Helpdesk dukungan berbayar</a></li>
</ul>
</div>
</div>

------

## **Presentasi pertama Anda**

Aspose.Slides for PHP via Java berjalan di Java dalam Apache Tomcat, dan skrip PHP Anda mengaksesnya melalui PHP/Java Bridge. [Instalasi](/slides/id/php-java/installation/) menyiapkan PHP 8.3 atau yang lebih lama, Java, Tomcat, dan bridge, lalu menginstal paket dari Packagist di folder proyek:

```bash
composer require aspose/slides
```

Kemudian salin file JAR paket ke dalam bridge dan restart Tomcat, seperti pada langkah 4 dari [Instal di Linux](/slides/id/php-java/installation/#install-on-linux) atau langkah 6 dari [Instal di Windows](/slides/id/php-java/installation/#install-on-windows). Dengan Tomcat berjalan, simpan skrip ini sebagai *hello.php* di folder proyek dan jalankan `php hello.php`:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/id/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Skrip tersebut menyimpan *hello.pptx* di sampingnya, dengan satu slide yang berisi kotak teks. Tanpa lisensi, file yang disimpan memiliki watermark evaluasi — lihat [Lisensi](/slides/id/php-java/licensing/). Untuk lebih banyak cara membuat dan mengisi presentasi, lihat [Buat Presentasi](/slides/id/php-java/create-presentation/).