---
title: Aspose.Slides for Python via .NET
second_title: Aspose.Slides for Python
type: docs
weight: 35
url: /tr/python-net/
is_root: true
keywords:
- Aspose.Slides for Python
- Python için PowerPoint otomasyonu
- Python PPT kütüphanesi
- Python ile PowerPoint'i PDF'e dışa aktar
- Python ile PowerPoint'i SVG'e dışa aktar
- Python ile PowerPoint düzenleme
- Microsoft Office olmadan Python PowerPoint
- Python ile PPTX yönetme
- Python ile slayt önizleme
- Python ile slaytlara ses ekleme
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Buradan başlayın: Aspose.Slides for Python via .NET'ı kurun, ilk sunumunuzu oluşturun ve ortak görevler, API referansı ve destek için kılavuzları bulun."
---
<img src="aspose_slides-for-python.png" alt="Aspose.Slides for Python via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via .NET, Microsoft PowerPoint veya Microsoft Office olmadan PowerPoint ve OpenDocument sunumları oluşturmak, okumak, düzenlemek ve dönüştürmek için bir Python kütüphanesidir.

PPT, PPTX, PPS, POT ve ODP dosyalarını, makro‑destekli ve şablon varyantları dahil olmak üzere yükler ve kaydeder; ayrıca PDF, XPS, HTML, SVG, TIFF, Markdown ve görüntü formatlarına dışa aktarır.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Başlarken</b></p>
<hr>
<p>BAŞLAMA REHBERİ</p>
<ul>
<li><a href="/slides/tr/python-net/installation/">Kurulum</a></li>
<li><a href="/slides/tr/python-net/create-presentation/">İlk sunumunuzu oluşturun</a></li>
<li><a href="/slides/tr/python-net/getting-started/">Başlangıç kılavuzu</a></li>
</ul>
<p>DEĞERLENDİRME</p>
<ul>
<li><a href="/slides/tr/python-net/supported-file-formats/">Desteklenen dosya formatları</a></li>
<li><a href="/slides/tr/python-net/evaluate-aspose-slides/">Deneme sınırlamaları</a></li>
<li><a href="/slides/tr/python-net/licensing/">Lisanslama</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides ile Geliştirin</b></p>
<hr>
<p>ORTAK GÖREVLER</p>
<ul>
<li><a href="/slides/tr/python-net/open-presentation/">Sunumu açın</a></li>
<li><a href="/slides/tr/python-net/save-presentation/">Sunumu kaydedin</a></li>
<li><a href="/slides/tr/python-net/convert-powerpoint-to-pdf/">PDF’ye dönüştürün</a></li>
<li><a href="/slides/tr/python-net/convert-slide/">Slaytları görsel olarak render edin</a></li>
<li><a href="/slides/tr/python-net/manage-text/">Metin ve şekilleri düzenleyin</a></li>
</ul>
<p>SLAYT İŞ AKIŞLARI</p>
<ul>
<li><a href="/slides/tr/python-net/powerpoint-charts/">Grafikler</a></li>
<li><a href="/slides/tr/python-net/powerpoint-animation/">Animasyonlar</a></li>
<li><a href="/slides/tr/python-net/manage-media-files/">Ses ve video</a></li>
<li><a href="/slides/tr/python-net/presentation-design/">Slayt tasarımı</a></li>
<li><a href="/slides/tr/python-net/merge-presentation/">Sunumları birleştirin</a></li>
</ul>
<p>ÖRNEKLER</p>
<ul>
<li><a href="/slides/tr/python-net/examples/">Slayt öğesine göre örnekler</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Python-via-.NET">GitHub’daki örnekler</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referans &amp; Destek</b></p>
<hr>
<p>REFERANS</p>
<ul>
<li><a href="https://reference.aspose.com/slides/tr/python-net/">API referansı</a></li>
<li><a href="https://releases.aspose.com/slides/tr/python-net/release-notes/">Sürüm notları</a></li>
<li><a href="https://releases.aspose.com/slides/tr/python-net/">İndir</a></li>
</ul>
<p>DESTEK</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/tr/11">Ücretsiz destek forumu</a></li>
<li><a href="https://helpdesk.aspose.com/">Ücretli destek hizmeti</a></li>
</ul>
</div>
</div>

------

## **İlk sunumunuz**

Paketi PyPI’dan kurun:

```bash
pip install aspose.slides
```

Paket, kullandığı .NET çalışma zamanını içerdiği için .NET kurmanız gerekmez. Linux’da ayrıca libgdiplus ve ICU kütüphanelerini kurun; Debian ya da Ubuntu sistem Python’u kullanıyorsanız komutu bir sanal ortamda çalıştırın. macOS’da ek gereksinimler bulunmakta ve kurulum burada doğrulanmamıştır. Komutlar, macOS gereksinimleri ve desteklenen Python sürümleri için [Kurulum](/slides/tr/python-net/installation/) sayfasına bakın.

Bu kodu *hello.py* olarak kaydedin:

```py
import aspose.slides as slides

# Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluşturun.
with slides.Presentation() as presentation:
    # İlk slaytı alın.
    slide = presentation.slides[0]

    # CLOUD tipinde bir otomatik şekil ekleyin.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Sunumu bir PPTX dosyası olarak kaydedin.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

`python hello.py` komutuyla çalıştırın. Betik, geçerli klasörde bir slayt içeren *new_presentation.pptx* dosyasını kaydeder; slayt bulut şeklinde bir nesne taşır ve içinde “Hello, Aspose!” yazar. Lisans olmadan kaydedilen dosya bir değerlendirme filigranı taşır — detaylar için [Lisanslama](/slides/tr/python-net/licensing/) sayfasına bakın. Sunum oluşturma ve doldurma hakkında daha fazla bilgi için [Sunum Oluşturma](/slides/tr/python-net/create-presentation/) sayfasına göz atın.