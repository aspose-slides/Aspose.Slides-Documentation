---
title: Python ile OpenDocument Sunumlarını Dönüştür
linktitle: OpenDocument Dönüştür
type: docs
weight: 10
url: /tr/python-java/convert-openoffice-odp/
keywords:
- ODP'yi dönüştür
- ODP PDF'ye
- ODP HTML'ye
- ODP TIFF'e
- ODP PPT'ye
- ODP PPTX'e
- ODP XPS'e
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak OpenDocument (ODP) sunumlarını PDF, HTML ve diğer formatlara dönüştürün, OpenOffice veya LibreOffice kurmadan."
---
## **Giriş**

Aspose.Slides for Python via Java, OpenDocument (ODP) sunumlarını PDF, HTML, TIFF, XPS, PPT ve PPTX gibi formatlara dönüştürmenizi sağlar. ODP dönüştürmesi, PowerPoint dönüştürmesiyle aynı API'yi kullanır: kaynağı [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) ile yükleyin ve çıktı formatını [SaveFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/) ile seçin.

## **ODP'yi PDF'ye Dönüştür**

Örneği çalıştırmadan önce [kurulum talimatları](/slides/tr/python-java/installation/) adresindeki kurulum talimatlarını izleyin. `pres.odp` adlı bir ODP sunumunu çalışma dizinine koyun. Aşağıdaki kod gerektiğinde JVM'i başlatır, sunumu yükler ve `pres.pdf` olarak kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.odp")
try:
    presentation.save("pres.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **Farklı Uygulamalarda OpenDocument Sunumu**

Bir ODP sunumu, bu uygulamalar farklı sunum özellikleri ve renderleme davranışları desteklediği için PowerPoint ve LibreOffice/OpenOffice Impress'te farklı görünebilir. Düzenleri karmaşık biçimlendirmeye bağlı olduğunda dönüştürülmüş sunumları inceleyin.

Uyumluluk farkları şunları etkileyebilir:

- Tablolar, diğer şekillere göre katman sırası ve resim doldurmaları desteği dahil.
- Metin döndürme ve hizalama.
- Metne uygulanan resim, degrade ve desen doldurmaları.
- Numaralı ve madde işaretli listeler.

Aşağıdaki resim, LibreOffice Impress'te oluşturulan bir listeyi gösterir:

![LibreOffice Impress'te ODP liste örneği](odp-list-example.png)

Aspose.Slides, LibreOffice/OpenOffice Impress ile uyumluluk sağlamak için ODP listelerini kaydeder.

Özellik uyumluluğu hakkında ayrıntılar için [Microsoft'un OpenDocument Sunum formatı rehberine](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0) bakın.

## **SSS**

**Dönüştürmeden sonra ODP dosyamın biçimlendirmesi değişirse ne olur?**

ODP ve PowerPoint farklı sunum modelleri kullanır. Tablolar, yazı tipleri ve dolgu stilleri farklı görüntülenebilir. Gerekli yazı tiplerinin mevcut olduğundan emin olun, çıktıyı gözden geçirin ve gerekirse düzeni veya biçimlendirmeyi ayarlayın.

**ODP dosyalarını dönüştürmek için OpenOffice veya LibreOffice yüklü olması gerekir mi?**

Hayır. Aspose.Slides for Python via Java, bu uygulamalardan hiçbiri olmadan sunumları işler. Uyumlu bir Java çalışma zamanı ve Python paketi gereklidir.

**ODP sunumunu dönüştürürken PDF çıktısını özelleştirebilir miyim?**

Evet. PDF dışa aktarım ayarlarını, görüntü kalitesi ve sıkıştırma gibi seçenekleri yapılandırmak için [PdfOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pdfoptions/) kullanın.

**ODP sunumlarını bir sunucuda veya konteyner içinde dönüştürebilir miyim?**

Evet. Hedef ortamda Python paketini, uyumlu bir Java çalışma zamanını ve sunumlarınız için gereken yazı tiplerini kurun. Hiçbir ofis uygulamasına ihtiyaç yok.