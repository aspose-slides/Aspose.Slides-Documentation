---
title: Aspose.Slides for Python via .NET
second_title: Aspose.Slides for Python
type: docs
weight: 35
url: /tr/python-net/
is_root: true
keywords:
- Aspose.Slides for Python
- Python ile PowerPoint otomasyonu
- Python PPT kütüphanesi
- Python ile PowerPoint'i PDF'e dışa aktar
- Python ile PowerPoint'i SVG'ye dışa aktar
- Python'da PowerPoint düzenleme
- Microsoft Office olmadan Python PowerPoint
- Python ile PPTX yönetimi
- Python ile slayt ön izlemesi
- Python ile slaytlara ses ekleme
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET, metin, şekil, tablo ve animasyon yönetimi, slaytlara ses ve video ekleme, slayt ön izleme ve SVG, PDF ve daha fazlasına dışa aktarım gibi kapsamlı bir özellik seti sunar."
---
{{% alert color="info" %}}

**Aspose.Slides for Python via .NET'ye Hoş Geldiniz**

![Aspose.Slides for Python via .NET Ürün Logosu](aspose_slides-for-python.png)

Aspose.Slides for Python via .NET, uygulamalarınızın Microsoft PowerPoint® gerektirmeden PowerPoint® sunumlarını okumasını ve yazmasını sağlayan sağlam bir sınıf kitaplığıdır.

Python geliştiricileri için tam özellikli PowerPoint® belge yönetimi sağlayan ilk ve tek bileşendir.

Aspose.Slides for Python via .NET, metin, şekiller, tablolar ve animasyonlarla çalışma; ses ve video ekleme; slayt ön izleme; ve slaytları SVG, PDF ve daha fazlası gibi formatlara dışa aktarma gibi çok çeşitli özellikler içerir.

{{% /alert %}}

## Aspose.Slides for Python via .NET'i Kurun

```bash
pip install aspose.slides
```

Paket, ihtiyaç duyduğu .NET çalışma zamanını içerir, bu yüzden başka bir şey kurmanıza gerek yok ve Microsoft PowerPoint gerektirmez. Windows, Linux veya macOS üzerinde Python 3.7 veya daha yeni sürüm.

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

Çalıştırıldığında `presentation.pptx` (yaklaşık 34 KB) ve `presentation.pdf` (yaklaşık 36 KB) dosyalarını çalışma dizinine yazar.

Lisans olmadan kütüphane değerlendirme modunda çalışır, bu da filigran ekler ve slayt sayısını sınırlar. Bir lisans uygulamak için [Licensing](/slides/tr/python-net/licensing/) sayfasına bakın.

## Aspose.Slides for Python via .NET Kaynakları

Bu yararlı kaynakları inceleyin:

- [Aspose.Slides for Python via .NET Çevrimiçi Dokümantasyonu](/slides/tr/python-net/)
- [Aspose.Slides for Python via .NET Özellikleri](/slides/tr/python-net/features-overview/)
- [Aspose.Slides for Python via .NET Sürüm Notları](https://releases.aspose.com/slides/tr/python-net/release-notes/)
- [Aspose.Slides for Python via .NET Ürün Sayfası](https://products.aspose.com/slides/tr/python-net/)
- [Aspose.Slides for Python via .NET'i İndir](https://releases.aspose.com/slides/tr/python-net/)
- [Aspose.Slides for Python via .NET PyPi Paketi'ni Kurun](https://pypi.org/project/aspose.slides/)
- [Aspose.Slides for Python via .NET API Referans Kılavuzu](https://reference.aspose.com/slides/tr/python-net/)
- [Aspose.Slides for Python via .NET Ücretsiz Destek Forumu](https://forum.aspose.com/c/slides/tr/11)
- [Aspose.Slides for Python via .NET Ücretli Destek Yardım Masası](https://helpdesk.aspose.com/)

## SSS

### Aspose.Slides for Python via .NET nedir?

Aspose.Slides for Python via .NET, Microsoft PowerPoint yüklü olmadan PowerPoint sunumlarını (PPT, PPTX, ODP) programlı olarak oluşturmanızı, düzenlemenizi ve dönüştürmenizi sağlayan güçlü bir Python kitaplığıdır.

### Aspose.Slides hangi sunum özelliklerini destekliyor?

Kitaplık, metin, şekil, tablo, grafik, animasyon, ana slaytlar, ses, video ve daha fazlasını yönetmeyi destekler. Ayrıca slayt ön izleme, renderleme ve PDF, SVG, HTML ve görüntü gibi formatlara dışa aktarmayı sağlar.

### Aspose.Slides kullanarak sunumları başka formatlara dönüştürebilir miyim?

Evet. Aspose.Slides, PowerPoint dosyalarını PDF, SVG, HTML, JPG, PNG, TIFF ve diğer formatlara yüksek doğruluk ve performansla dönüştürmeyi sağlar.

### Aspose.Slides'ı kullanmak için Microsoft PowerPoint gerekli mi?

Hayır. Aspose.Slides bağımsız bir API'dir ve Microsoft Office ya da herhangi bir üçüncü taraf yazılımı gerektirmez.

### Aspose.Slides for Python via .NET hangi platformları destekliyor?

Çapraz platformdur ve Windows, Linux ve macOS ortamlarında çalışır.

### Aspose.Slides for Python ile nasıl başlayabilirim?

PyPi üzerinden kurabilir ve örnekler, API referansları ve öğreticilerle başlamanız için [Developer Guide](/slides/tr/python-net/developer-guide/) sayfasını inceleyebilirsiniz.