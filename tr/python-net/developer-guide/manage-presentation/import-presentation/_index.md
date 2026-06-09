---
title: Python ile Sunumları İçe Aktarın
linktitle: Sunumu İçe Aktar
type: docs
weight: 60
url: /tr/python-net/import-presentation/
keywords:
- PowerPoint içe aktar
- sunum içe aktar
- slayt içe aktar
- PDF'den sunuma
- PDF'den PPT'ye
- PDF'den PPTX'e
- PDF'den ODP'ye
- HTML'den sunuma
- HTML'den PPT'ye
- HTML'den PPTX'e
- HTML'den ODP'ye
- Python
- Aspose.Slides
description: "Aspose.Slides ile Python’da PDF ve HTML belgelerini sorunsuz ve yüksek performanslı slayt işleme için PowerPowerPoint ve OpenDocument sunumlarına zahmetsizce içe aktarın."
---
## **Giriş**

Bu sayede diğer dosya formatlarından bir sunuma içerik aktarabilirsiniz. [SlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/) sınıfı, PDF, HTML ve diğer kaynaklardan slaytları içe aktarmak için yöntemler sağlar.

## **PDF'yi Sunuma Dönüştür**

Bu bölüm, Aspose.Slides kullanarak bir PDF'yi sunuma nasıl dönüştüreceğinizi gösterir. PDF'yi içe aktarmayı, sayfalarını slaytlara dönüştürmeyi ve sonucu PPTX dosyası olarak kaydetmeyi adım adım anlatır.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. PDF dosyasını aktararak [add_from_pdf](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/add_from_pdf/) metodunu çağırın.  
3. [save](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/save/) metodunu kullanarak sunumu PowerPoint formatında kaydedin.

Aşağıdaki Python örneği, bir PDF'yi sunuma dönüştürmeyi gösterir:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("sample.pdf")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}
Burada anlatılan sürecin canlı bir uygulamasını denemek isterseniz, **Aspose’un ücretsiz** [PDF to PowerPoint](https://products.aspose.app/slides/tr/import/pdf-to-powerpoint) web uygulamasını kullanabilirsiniz.
{{% /alert %}}

## **HTML'yi Sunuma Dönüştür**

Bu bölüm, Aspose.Slides kullanarak HTML içeriğini bir sunuma nasıl aktaracağınızı gösterir. HTML'i yüklemeyi, metin, resim ve temel biçimlendirmeyi koruyarak slaytlara dönüştürmeyi ve sonucu PPTX dosyası olarak kaydetmeyi kapsar.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. HTML dosyasını aktararak [add_from_html](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/add_from_html/) metodunu çağırın.  
3. [save](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/save/) metodunu kullanarak sunumu PowerPoint formatında kaydedin.

Aşağıdaki Python örneği, bir HTML'i sunuma dönüştürmeyi gösterir:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    with open("page.html", "rb") as html_stream:
        presentation.slides.add_from_html(html_stream)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**PDF içe aktarırken tablolar korunur mu ve tespiti geliştirilebilir mi?**

Tablolar içe aktarım sırasında tespit edilebilir; [PdfImportOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.importing/pdfimportoptions/) içinde tablo tanımını etkinleştiren bir [detect_tables](https://reference.aspose.com/slides/tr/python-net/aspose.slides.importing/pdfimportoptions/detect_tables/) parametresi bulunur. Etkinlik, PDF'nin yapısına bağlıdır.

{{% alert title="Note" color="info" %}}
Aspose.Slides ayrıca HTML'i diğer popüler dosya formatlarına dönüştürmek için de kullanılabilir:

* [HTML'den görüntü](https://products.aspose.com/slides/tr/python-net/conversion/html-to-image/)
* [HTML'den JPG](https://products.aspose.com/slides/tr/python-net/conversion/html-to-jpg/)
* [HTML'den XML](https://products.aspose.com/slides/tr/python-net/conversion/html-to-xml/)
* [HTML'den TIFF](https://products.aspose.com/slides/tr/python-net/conversion/html-to-tiff/)
{{% /alert %}}