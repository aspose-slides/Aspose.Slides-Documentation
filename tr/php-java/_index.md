---
title: Aspose.Slides for PHP via Java
second_title: Aspose.Slides for PHP
type: docs
weight: 45
url: /tr/php-java/
keywords:
- dokümantasyon
- sunum işleme
- sunum dönüştürme
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Buradan başlayın: Aspose.Slides for PHP via Java'ı kurun, ilk sunumunuzu oluşturun ve ortak görevler, API referansı ve destek için kılavuzları bulun."
is_root: true
---
<img src="aspose_slides-for-php-via-java.png" alt="Aspose.Slides for PHP via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for PHP via Java, Microsoft PowerPoint veya Office Otomasyonu olmadan PHP uygulamalarında PowerPoint ve OpenDocument sunumları oluşturmak, okumak, düzenlemek ve dönüştürmek için bir sınıf kitaplığıdır.

PPT, PPTX, PPS, POT ve ODP dosyalarını, makro destekli ve şablon çeşitleri dahil olmak üzere yükler ve kaydeder; ayrıca PDF, XPS, HTML, SVG, TIFF, Markdown ve görüntülere dışa aktarır.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Başlarken</b></p>
<hr>
<p>BAŞLANGIÇ</p>
<ul>
<li><a href="/slides/tr/php-java/installation/">Kurulum</a></li>
<li><a href="/slides/tr/php-java/create-presentation/">İlk sunumunuzu oluşturun</a></li>
<li><a href="/slides/tr/php-java/getting-started/">Başlangıç kılavuzu</a></li>
</ul>
<p>DEĞERLENDİRME</p>
<ul>
<li><a href="/slides/tr/php-java/supported-file-formats/">Desteklenen dosya biçimleri</a></li>
<li><a href="/slides/tr/php-java/evaluate-aspose-slides/">Deneme sınırlamaları</a></li>
<li><a href="/slides/tr/php-java/licensing/">Lisanslama</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides ile Oluşturun</b></p>
<hr>
<p>ORTAK GÖREVLER</p>
<ul>
<li><a href="/slides/tr/php-java/open-presentation/">Bir sunumu açın</a></li>
<li><a href="/slides/tr/php-java/save-presentation/">Bir sunumu kaydedin</a></li>
<li><a href="/slides/tr/php-java/convert-powerpoint-to-pdf/">PDF'e dönüştürün</a></li>
<li><a href="/slides/tr/php-java/convert-slide/">Slaytları görüntü olarak render edin</a></li>
<li><a href="/slides/tr/php-java/manage-text/">Metin ve şekilleri düzenleyin</a></li>
</ul>
<p>SLAYT İŞ AKIŞLARI</p>
<ul>
<li><a href="/slides/tr/php-java/powerpoint-charts/">Grafikler</a></li>
<li><a href="/slides/tr/php-java/powerpoint-animation/">Animasyonlar</a></li>
<li><a href="/slides/tr/php-java/manage-media-files/">Ses ve video</a></li>
<li><a href="/slides/tr/php-java/presentation-design/">Slayt tasarımı</a></li>
<li><a href="/slides/tr/php-java/merge-presentation/">Sunumları birleştirin</a></li>
</ul>
<p>ÖRNEKLER</p>
<ul>
<li><a href="/slides/tr/php-java/examples/">Slayt öğesine göre örnekler</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referans &amp; Destek</b></p>
<hr>
<p>REFERANS</p>
<ul>
<li><a href="https://reference.aspose.com/slides/php-java/">API referansı</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/release-notes/">Sürüm notları</a></li>
<li><a href="/slides/tr/php-java/known-issues/">Bilinen sorunlar</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/">İndir</a></li>
</ul>
<p>DESTEK</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Ücretsiz destek forumu</a></li>
<li><a href="https://helpdesk.aspose.com/">Ücretli destek helpdesk</a></li>
</ul>
</div>
</div>

------

## **İlk sunumunuz**

Aspose.Slides for PHP via Java, Apache Tomcat içinde Java üzerinde çalışır ve PHP betikleriniz ona PHP/Java Bridge aracılığıyla ulaşır. [Kurulum](/slides/tr/php-java/installation/) PHP 8.3 veya daha eski bir sürüm, Java, Tomcat ve köprüyü kurar ve ardından paketi Packagist'ten proje klasörüne kurar:

```bash
composer require aspose/slides
```

Ardından paketin JAR dosyasını köprüye kopyalayın ve Tomcat'i yeniden başlatın; bu, [Linux'ta Kurulum](/slides/tr/php-java/installation/#install-on-linux) adım 4'te veya [Windows'ta Kurulum](/slides/tr/php-java/installation/#install-on-windows) adım 6'da gösterildiği gibidir. Tomcat çalışırken, bu betiği proje klasörüne *hello.php* adıyla kaydedin ve `php hello.php` komutunu çalıştırın:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/tr/lib/aspose.slides.php");

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

Betik kendisinin yanına *hello.pptx* dosyasını kaydeder; bu dosyada bir metin kutusu içeren bir slayt bulunur. Lisans olmadan, kaydedilen dosya bir değerlendirme filigranı içerir — [Lisanslama](/slides/tr/php-java/licensing/) bölümüne bakın. Sunum oluşturmanın ve doldurmanın daha fazla yolu için, [Sunum Oluşturma](/slides/tr/php-java/create-presentation/) bölümüne bakın.