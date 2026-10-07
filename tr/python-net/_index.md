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
- Python ile PowerPoint'i PDF olarak dışa aktar
- Python ile PowerPoint'i SVG olarak dışa aktar
- Python'da PowerPoint'i düzenle
- Microsoft Office olmadan Python PowerPoint
- Python ile PPTX yönet
- Python ile slayt önizleme
- Python ile slaytlara ses ekle
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Buradan başlayın: Aspose.Slides for Python via .NET'i kurun, ilk sunumu oluşturun ve yaygın görevler, API referansı ve destek için kılavuzları bulun."
---
<img src="aspose_slides-for-python.png" alt="Aspose.Slides Python için .NET üzerinden" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via .NET, Microsoft PowerPoint veya Microsoft Office gerektirmeden PowerPoint ve OpenDocument sunumları oluşturmak, okumak, düzenlemek ve dönüştürmek için bir Python kütüphanesidir.

PPT, PPTX, PPS, POT ve ODP formatlarını, makro etkin ve şablon çeşitlerini de içerecek şekilde yükler ve kaydeder ve PDF, XPS, HTML, SVG, TIFF, Markdown ve görüntüler formatına dışa aktarır.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Başlarken</b></p>
<hr>
<p>BAŞLANGIÇ</p>
<ul>
<li><a href="/slides/tr/python-net/installation/">Kurulum</a></li>
<li><a href="/slides/tr/python-net/create-presentation/">İlk sunumunuzu oluşturun</a></li>
<li><a href="/slides/tr/python-net/getting-started/">Başlangıç kılavuzu</a></li>
</ul>
<p>DEĞERLENDİR</p>
<ul>
<li><a href="/slides/tr/python-net/supported-file-formats/">Desteklenen dosya formatları</a></li>
<li><a href="/slides/tr/python-net/evaluate-aspose-slides/">Deneme sınırlamaları</a></li>
<li><a href="/slides/tr/python-net/licensing/">Lisanslama</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides ile Oluşturun</b></p>
<hr>
<p>ORTAK GÖREVLER</p>
<ul>
<li><a href="/slides/tr/python-net/open-presentation/">Bir sunumu aç</a></li>
<li><a href="/slides/tr/python-net/save-presentation/">Bir sunumu kaydet</a></li>
<li><a href="/slides/tr/python-net/convert-powerpoint-to-pdf/">PDF'ye dönüştür</a></li>
<li><a href="/slides/tr/python-net/convert-slide/">Slaytları görüntü olarak oluştur</a></li>
<li><a href="/slides/tr/python-net/manage-text/">Metin ve şekilleri düzenle</a></li>
</ul>
<p>SLAYT İŞ AKIŞLARI</p>
<ul>
<li><a href="/slides/tr/python-net/powerpoint-charts/">Grafikler</a></li>
<li><a href="/slides/tr/python-net/powerpoint-animation/">Animasyonlar</a></li>
<li><a href="/slides/tr/python-net/manage-media-files/">Ses ve video</a></li>
<li><a href="/slides/tr/python-net/presentation-design/">Slayt tasarımı</a></li>
<li><a href="/slides/tr/python-net/merge-presentation/">Sunumları birleştir</a></li>
</ul>
<p>ÖRNEKLER</p>
<ul>
<li><a href="/slides/tr/python-net/examples/">Slayt öğesine göre örnekler</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Python-via-.NET">GitHub'da örnekler</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referans &amp; Destek</b></p>
<hr>
<p>REFERANS</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-net/">API referansı</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/release-notes/">Sürüm notları</a></li>
<li><a href="https://products.aspose.com/slides/python-net/">Ürün sayfası</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/">İndir</a></li>
</ul>
<p>DESTEK</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Ücretsiz destek forumu</a></li>
<li><a href="https://helpdesk.aspose.com/">Ücretli destek yardım masası</a></li>
</ul>
</div>
</div>

------

## **İlk sunumunuz**

Paketi PyPI'dan kurun:

```bash
pip install aspose.slides
```

Paket, kullandığı .NET çalışma zamanı dahildir, bu yüzden .NET kurmanıza gerek yoktur. Linux'ta ayrıca libgdiplus ve ICU kütüphanelerini kurun ve Debian veya Ubuntu'nun sistem Python'u ile bir sanal ortamda komutu çalıştırın. macOS için ek önkoşullar vardır ve burada kurulumu doğrulamadık. Komutlar, macOS önkoşulları ve desteklenen Python sürümleri için [Kurulum](/slides/tr/python-net/installation/) sayfasına bakın.

Bu kodu *hello.py* olarak kaydedin:

```py
import aspose.slides as slides

# Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:
    # İlk slaytı alın.
    slide = presentation.slides[0]

    # CLOUD tipinde bir otomatik şekil ekleyin.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Sunumu PPTX dosyası olarak kaydedin.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

`python hello.py` ile çalıştırın. Betik, geçerli klasöre *new_presentation.pptx* dosyasını kaydeder; bir slayt, üzerinde "Hello, Aspose!" yazan bir bulut şekli içerir. Lisans olmadan, kaydedilen dosya bir değerlendirme filigranı taşır — [Lisanslama](/slides/tr/python-net/licensing/) bölümüne bakın. Sunum oluşturma ve doldurma hakkında daha fazla yöntem için [Sunum Oluşturma](/slides/tr/python-net/create-presentation/) sayfasına bakın.