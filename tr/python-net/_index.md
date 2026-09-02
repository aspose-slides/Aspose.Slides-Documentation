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
- Python PPT kitaplığı
- Python ile PowerPoint'i PDF'e dışa aktar
- Python ile PowerPoint'i SVG'ye dışa aktar
- Python'da PowerPoint düzenleme
- Microsoft Office olmadan Python PowerPoint
- Python ile PPTX yönetimi
- Python slayt önizleme
- Python ile slaytlara ses ekleme
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET, metin, şekil, tablo ve animasyon yönetimi, slaytlara ses ve video ekleme, slayt önizleme ve SVG, PDF ve daha fazlasına dışa aktarma dahil olmak üzere kapsamlı bir özellik seti sunar."
---
{{% alert color="primary" %}}

**Aspose.Slides for Python via .NET'e Hoş Geldiniz**

![Aspose.Slides for Python via .NET Ürün Logosu](aspose_slides-for-python.png)

Aspose.Slides for Python via .NET, Microsoft PowerPoint® gerektirmeden PowerPoint® sunumlarını okuma ve yazma imkanı sağlayan sağlam bir sınıf kitaplığıdır.

Python geliştiricileri için tam özellikli PowerPoint® belge yönetimi sunan ilk ve tek bileşendir.

Aspose.Slides for Python via .NET, metin, şekil, tablo ve animasyonlarla çalışma; ses ve video ekleme; slayt önizleme; ve slaytları SVG, PDF ve diğer formatlara dışa aktarma gibi geniş bir özellik yelpazesi sunar.

{{% /alert %}}

## Aspose.Slides for Python via .NET'i Yükleme

```bash
pip install aspose.slides
```

Paket, ihtiyaç duyduğu .NET çalışma zamanını içerdiği için başka bir şey yüklemeniz gerekmez ve Microsoft PowerPoint gerektirmez. Windows, Linux veya macOS üzerinde Python 3.7 veya üzeri sürümler desteklenir.

## Python'da PowerPoint Sunumu Oluşturma

Bu örnek bir sunum oluşturur, ilk slayta metin içeren bir şekil ekler ve sonucu hem PPTX hem de PDF olarak kaydeder.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 600, 100)
    shape.text_frame.text = "Created with Aspose.Slides for Python via .NET"

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF)
```

Çalıştırıldığında `presentation.pptx` (yaklaşık 34 KB) ve `presentation.pdf` (yaklaşık 36 KB) dosyaları çalışma dizinine yazılır.

Lisans olmadan kütüphane değerlendirme modunda çalışır; bu mod su işareti ekler ve slayt sayısını sınırlamaya alır. Lisans uygulamak için [Lisanslama](/slides/tr/python-net/licensing/) bölümüne bakın.

## Aspose.Slides for Python via .NET Kaynakları

Bu yararlı kaynakları keşfedin::

- [Aspose.Slides for Python via .NET Çevrimiçi Dokümantasyonu](/slides/tr/python-net/)
- [Aspose.Slides for Python via .NET Özellikleri](/slides/tr/python-net/features-overview/)
- [Aspose.Slides for Python via .NET Sürüm Notları](https://releases.aspose.com/slides/tr/python-net/release-notes/)
- [Aspose.Slides for Python via .NET Ürün Sayfası](https://products.aspose.com/slides/tr/python-net/)
- [Aspose.Slides for Python via .NET İndir](https://releases.aspose.com/slides/tr/python-net/)
- [Aspose.Slides for Python via .NET PyPi Paketi Yükleme](https://pypi.org/project/aspose.slides/)
- [Aspose.Slides for Python via .NET API Referans Kılavuzu](https://reference.aspose.com/slides/tr/python-net/)
- [Aspose.Slides for Python via .NET Ücretsiz Destek Forumu](https://forum.aspose.com/c/slides/tr/11)
- [Aspose.Slides for Python via .NET Ücretli Destek Yardım Masası](https://helpdesk.aspose.com/)

## SSS

### Aspose.Slides for Python via .NET nedir?

Aspose.Slides for Python via .NET, Microsoft PowerPoint yüklü olmadan PowerPoint sunumlarını (PPT, PPTX, ODP) programlı olarak oluşturmanıza, düzenlemenize ve dönüştürmenize olanak tanıyan güçlü bir Python kitaplığıdır.

### Aspose.Slides hangi sunum özelliklerini destekliyor?

Kitaplık, metin, şekil, tablo, grafik, animasyon, ana slaytlar, ses, video ve daha fazlasını yönetmeyi destekler. Ayrıca slayt önizleme, render, yazdırma ve PDF, SVG, HTML ve görüntü formatları gibi formatlara dışa aktarmayı sağlar.

### Sunumları diğer formatlara dönüştürebilir miyim?

Evet. Aspose.Slides, PowerPoint dosyalarını yüksek doğruluk ve performansla PDF, SVG, HTML, JPG, PNG, TIFF ve diğer formatlara dönüştürmeyi mümkün kılar.

### Aspose.Slides kullanmak için Microsoft PowerPoint gerekli mi?

Hayır. Aspose.Slides bağımsız bir API'dir ve Microsoft Office veya üçüncü taraf bir yazılım gerektirmez.

### Aspose.Slides for Python via .NET hangi platformları destekliyor?

Çapraz platformdur; Windows, Linux ve macOS ortamlarında çalışır.

### Aspose.Slides for Python ile nasıl başlayabilirim?

PyPi üzerinden yükleyebilir ve örnekler, API referansları ve öğreticiler için [Geliştirici Kılavuzu](/slides/tr/python-net/developer-guide/) sayfasını inceleyebilirsiniz.