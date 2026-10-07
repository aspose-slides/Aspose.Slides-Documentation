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
- Python'da PowerPoint sunumlarını yönetin
- Python'da PowerPoint oku ve yaz
- Python'da PowerPoint slaytlarını düzenleyin
- Python'da PowerPoint'i PDF'e dışa aktar
- Python'da PowerPoint'i SVG'ye dışa aktar
- Python'da slaytları önizleyin
- Python'da slaytlara ses ve video ekleyin
- Microsoft Office olmadan PowerPoint
- Python
- Java
- Aspose.Slides
description: "Buradan başlayın: Aspose.Slides for Python via Java'ı kurun, ilk sunumu oluşturun ve ortak görevler, API referansı ve destek için kılavuzları bulun."
---
<img src="aspose_slides-for-python-via-java.png" alt="Aspose.Slides for Python via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via Java, Microsoft PowerPoint olmadan Python uygulamalarında PowerPoint ve OpenDocument sunumları oluşturmak, okumak, düzenlemek ve dönüştürmek için bir kütüphanedir; JPype aracılığıyla Python sürecinizde Aspose.Slides Java motorunu çalıştırır.

Makro kullanan ve şablon varyantları dahil olmak üzere PPT, PPTX, PPS, POT ve ODP dosyalarını yükler ve kaydeder, ayrıca PDF, XPS, HTML, SVG, TIFF, Markdown ve görüntülere dışa aktarır.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Başlayın</b></p>
<hr>
<p>BAŞLANGIÇ</p>
<ul>
<li><a href="/slides/tr/python-java/installation/">Kurulum</a></li>
<li><a href="/slides/tr/python-java/create-presentation/">İlk sunumunuzu oluşturun</a></li>
<li><a href="/slides/tr/python-java/getting-started/">Başlangıç kılavuzu</a></li>
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
<li><a href="/slides/tr/python-java/open-presentation/">Bir sunumu açın</a></li>
<li><a href="/slides/tr/python-java/save-presentation/">Bir sunumu kaydedin</a></li>
<li><a href="/slides/tr/python-java/convert-powerpoint-to-pdf/">PDF'ye dönüştürün</a></li>
<li><a href="/slides/tr/python-java/convert-slide/">Slaytları görsel olarak render edin</a></li>
<li><a href="/slides/tr/python-java/manage-text/">Metin ve şekilleri düzenleyin</a></li>
</ul>
<p>SLIDES İŞ AKIŞLARI</p>
<ul>
<li><a href="/slides/tr/python-java/powerpoint-charts/">Grafikler</a></li>
<li><a href="/slides/tr/python-java/powerpoint-animation/">Animasyonlar</a></li>
<li><a href="/slides/tr/python-java/manage-media-files/">Ses ve video</a></li>
<li><a href="/slides/tr/python-java/presentation-design/">Slayt tasarımı</a></li>
<li><a href="/slides/tr/python-java/merge-presentation/">Sunumları birleştirin</a></li>
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
<li><a href="https://reference.aspose.com/slides/python-java/">API referansı</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/release-notes/">Sürüm notları</a></li>
<li><a href="/slides/tr/python-java/known-issues/">Bilinen sorunlar</a></li>
<li><a href="https://products.aspose.com/slides/python-java/">Ürün sayfası</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/">İndirme</a></li>
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

Python ve bir JDK kurun, `JAVA_HOME` ayarlayın ve [Kurulum](/slides/tr/python-java/installation/) bölümünde açıklandığı gibi bir sanal ortam oluşturup etkinleştirin. Ardından JPype ve Aspose.Slides'ı PyPI'dan kurun:

```sh
python -m pip install JPype1 aspose-slides-java
```

*hello.py* olarak kaydedin. Bu, Java Sanal Makinesini başlatır, yeni bir sunumun ilk slaytına metin içeren bir bulut şekli ekler ve sunumu kaydeder:

```python
import jpype
import asposeslides

if not jpode.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Bir sunum oluştur ve bir boş slayt ekle.
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

Komut dosyası, "Hello, Aspose!" metniyle bir bulut şekli içeren bir slaytı olan *new_presentation.pptx* dosyasını kaydeder. Lisans olmadan, kaydedilen dosya ayrıca bir değerlendirme filigranı içerir — [Lisanslama](/slides/tr/python-java/licensing/) bölümüne bakın. Sunum oluşturmak ve doldurmak için daha fazla yol için [Sunumları Oluştur](/slides/tr/python-java/create-presentation/) bölümüne bakın.