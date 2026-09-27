---
title: Aspose.Slides for Python via Java
second_title: Aspose.Slides for Python
type: docs
weight: 47
url: /tr/python-java/
is_root: true
keywords:
- Aspose.Slides for Python via Java
- Python PowerPoint kitaplığı
- Python'da PowerPoint sunumlarını yönet
- Python'da PowerPoint okuyup yaz
- Python'da PowerPoint slaytlarını düzenle
- Python'da PowerPoint'i PDF olarak dışa aktar
- Python'da PowerPoint'i SVG olarak dışa aktar
- Python'da slaytları ön izleme
- Python'da slaytlara ses ve video ekle
- Microsoft Office olmadan PowerPoint
- Python
- Java
- Aspose.Slides
description: "Buradan başlayın: Aspose.Slides for Python via Java'ı kurun, ilk sunumu oluşturun ve ortak görevler, API referansı ve destek için kılavuzları bulun."
---
<img src="aspose_slides-for-python-via-java.png" alt="Aspose.Slides for Python via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via Java, Microsoft PowerPoint olmadan Python uygulamalarında PowerPoint ve OpenDocument sunumları oluşturmak, okumak, düzenlemek ve dönüştürmek için bir kütüphanedir; JPype aracılığıyla Python işleminizde Aspose.Slides Java motorunu çalıştırır.

PPT, PPTX, PPS, POT ve ODP formatlarını, makro etkin ve şablon çeşitlerini yükler ve kaydeder; ayrıca PDF, XPS, HTML, SVG, TIFF, Markdown ve görüntü formatlarına dışa aktarır.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Başlarken</b></p>
<hr>
<p>BAŞLANGIÇ</p>
<ul>
<li><a href="/slides/tr/python-java/installation/">Kurulum</a></li>
<li><a href="/slides/tr/python-java/create-presentation/">İlk sunumunuzu oluşturun</a></li>
<li><a href="/slides/tr/python-java/getting-started/">Başlangıç rehberi</a></li>
</ul>
<p>DEĞERLENDİR</p>
<ul>
<li><a href="/slides/tr/python-java/supported-file-formats/">Desteklenen dosya formatları</a></li>
<li><a href="/slides/tr/python-java/evaluate-aspose-slides/">Deneme sınırlamaları</a></li>
<li><a href="/slides/tr/python-java/licensing/">Lisanslama</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides ile Oluşturun</b></p>
<hr>
<p>ORTAK GÖREVLER</p>
<ul>
<li><a href="/slides/tr/python-java/open-presentation/">Sunumu aç</a></li>
<li><a href="/slides/tr/python-java/save-presentation/">Sunumu kaydet</a></li>
<li><a href="/slides/tr/python-java/convert-powerpoint-to-pdf/">PDF'ye dönüştür</a></li>
<li><a href="/slides/tr/python-java/convert-slide/">Slaytları resim olarak işleme</a></li>
<li><a href="/slides/tr/python-java/manage-text/">Metin ve şekilleri düzenle</a></li>
</ul>
<p>SLAYT İŞ AKIŞLARI</p>
<ul>
<li><a href="/slides/tr/python-java/powerpoint-charts/">Grafikler</a></li>
<li><a href="/slides/tr/python-java/powerpoint-animation/">Animasyonlar</a></li>
<li><a href="/slides/tr/python-java/manage-media-files/">Ses ve video</a></li>
<li><a href="/slides/tr/python-java/presentation-design/">Slayt tasarımı</a></li>
<li><a href="/slides/tr/python-java/merge-presentation/">Sunumları birleştir</a></li>
</ul>
<p>ÖRNEKLER</p>
<ul>
<li><a href="/slides/tr/python-java/examples/">Slayt öğesine göre örnekler</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referans &amp; Destek</b></p>
<hr>
<p>REFERANS</p>
<ul>
<li><a href="https://reference.aspose.com/slides/tr/python-java/">API referansı</a></li>
<li><a href="https://releases.aspose.com/slides/tr/python-java/release-notes/">Sürüm notları</a></li>
<li><a href="/slides/tr/python-java/known-issues/">Bilinen sorunlar</a></li>
<li><a href="https://releases.aspose.com/slides/tr/python-java/">İndir</a></li>
</ul>
<p>DESTEK</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/tr/11">Ücretsiz destek forumu</a></li>
<li><a href="https://helpdesk.aspose.com/">Ücretli destek hizmet masası</a></li>
</ul>
</div>
</div>

------

## **İlk sunumunuz**

Python ve bir JDK kurun, `JAVA_HOME` değişkenini ayarlayın ve [Kurulum](/slides/tr/python-java/installation/) bölümünde açıklandığı gibi sanal ortam oluşturup etkinleştirin. Ardından PyPI'dan JPype ve Aspose.Slides'i yükleyin:

```sh
python -m pip install JPype1 aspose-slides-java
```

Bu kodu *hello.py* olarak kaydedin. Bu, Java Sanal Makinesini başlatır, yeni bir sunumun ilk slaytına metinli bir bulut şekli ekler ve sunumu kaydeder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Bir boş slayt ile bir sunum oluştur.
presentation = Presentation()
try:
    # İlk slaytı al.
    slide = presentation.getSlides().get_Item(0)

    # Bir bulut şekli ekle ve metnini ayarla.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Sunumu PPTX dosyası olarak kaydet.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Aynı sanal ortamda çalıştırın:

```sh
python hello.py
```

Betik, “Hello, Aspose!” metniyle bulut şekli içeren bir slaytı *new_presentation.pptx* olarak kaydeder. Lisans olmadan kaydedilen dosya bir değerlendirme filigranı taşır — [Lisanslama](/slides/tr/python-java/licensing/) bölümüne bakın. Sunum oluşturmak ve doldurmak için daha fazla yöntem görmek isterseniz [Sunum Oluşturma](/slides/tr/python-java/create-presentation/) sayfasına bakın.