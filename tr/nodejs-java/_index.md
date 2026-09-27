---
title: Aspose.Slides for Node.js via Java
second_title: Aspose.Slides for Node.js
type: docs
weight: 47
url: /tr/nodejs-java/
keywords:
- belgelendirme
- sunum işleme
- sunum dönüşümü
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Buradan başlayın: Aspose.Slides for Node.js via Java'ı kurun, ilk sunumu oluşturun ve ortak görevler, API referansı ve destek kılavuzlarını bulun."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-java.png" alt="Aspose.Slides for Node.js via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via Java, Microsoft PowerPoint olmadan Node.js uygulamalarında PowerPoint ve OpenDocument sunumları oluşturmak, okumak, düzenlemek ve dönüştürmek için bir kütüphanedir.

PPT, PPTX, PPS, POT ve ODP dosyalarını, makro etkin ve şablon varyantları dahil olmak üzere yükler ve kaydeder; ayrıca PDF, XPS, HTML, SVG, TIFF, Markdown ve görsellere aktarır.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Başlayın</b></p>
<hr>
<p>BAŞLANGIÇ</p>
<ul>
<li><a href="/slides/tr/nodejs-java/installation/">Kurulum</a></li>
<li><a href="/slides/tr/nodejs-java/create-presentation/">İlk sunumunuzu oluşturun</a></li>
<li><a href="/slides/tr/nodejs-java/getting-started/">Başlangıç kılavuzu</a></li>
</ul>
<p>DEĞERLENDİR</p>
<ul>
<li><a href="/slides/tr/nodejs-java/supported-file-formats/">Desteklenen dosya formatları</a></li>
<li><a href="/slides/tr/nodejs-java/evaluate-aspose-slides/">Deneme sınırlamaları</a></li>
<li><a href="/slides/tr/nodejs-java/licensing/">Lisanslama</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides ile Oluşturun</b></p>
<hr>
<p>ORTAK GÖREVLER</p>
<ul>
<li><a href="/slides/tr/nodejs-java/open-presentation/">Sunumu aç</a></li>
<li><a href="/slides/tr/nodejs-java/save-presentation/">Sunumu kaydet</a></li>
<li><a href="/slides/tr/nodejs-java/convert-powerpoint-to-pdf/">PDF'ye dönüştür</a></li>
<li><a href="/slides/tr/nodejs-java/convert-slide/">Slaytları görüntü olarak oluştur</a></li>
<li><a href="/slides/tr/nodejs-java/manage-text/">Metin ve şekilleri düzenle</a></li>
</ul>
<p>SLAYT İŞ AKIŞLARI</p>
<ul>
<li><a href="/slides/tr/nodejs-java/powerpoint-charts/">Grafikler</a></li>
<li><a href="/slides/tr/nodejs-java/powerpoint-animation/">Animasyonlar</a></li>
<li><a href="/slides/tr/nodejs-java/manage-media-files/">Ses ve video</a></li>
<li><a href="/slides/tr/nodejs-java/presentation-design/">Slayt tasarımı</a></li>
<li><a href="/slides/tr/nodejs-java/merge-presentation/">Sunumları birleştir</a></li>
</ul>
<p>ÖRNEKLER</p>
<ul>
<li><a href="/slides/tr/nodejs-java/examples/">Slayt öğesine göre örnekler</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referans &amp; Destek</b></p>
<hr>
<p>REFERANS</p>
<ul>
<li><a href="https://reference.aspose.com/slides/tr/nodejs-java/">API referansı</a></li>
<li><a href="https://releases.aspose.com/slides/tr/nodejs-java/release-notes/">Sürüm notları</a></li>
<li><a href="/slides/tr/nodejs-java/known-issues/">Bilinen sorunlar</a></li>
<li><a href="https://releases.aspose.com/slides/tr/nodejs-java/">İndir</a></li>
</ul>
<p>DESTEK</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/tr/11">Ücretsiz destek forumu</a></li>
<li><a href="https://helpdesk.aspose.com/">Ücretli destek masası</a></li>
</ul>
</div>
</div>

------

## **İlk sunumunuz**

Node.js 20 veya daha yeni bir sürümünün yanı sıra, paket bir Java Development Kit (JDK), Python ve bir C++ derleme araç zincirine ihtiyaç duyar, çünkü npm kurulum sırasında `java` köprüsünü derler. Her işletim sistemi için adımları görmek üzere [Installation](/slides/tr/nodejs-java/installation/) sayfasına bakın. Ardından bir proje oluşturup paketi npm'den kurun:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

Bu kodu proje klasöründe *hello.js* olarak kaydedin:

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides, Node.js'in çalışmasını sürdüren bir Java sanal makinesinde çalışır, bu yüzden işlemi açıkça sonlandırın.
process.exit(0);
```

`node hello.js` ile çalıştırın. Betik, bir metin kutusu içeren bir slayt ile *hello.pptx* dosyasını kaydeder. Lisans olmadan, kaydedilen dosya bir değerlendirme filigranı taşır — [Licensing](/slides/tr/nodejs-java/licensing/) sayfasına bakın. Bir sunumu oluşturmanın ve doldurmanın daha fazla yolu için [Create Presentations](/slides/tr/nodejs-java/create-presentation/) bakın.