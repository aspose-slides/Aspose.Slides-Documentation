---
title: PowerPoint Sunumlarını Python'da XML'e Dönüştür
linktitle: PowerPoint'ten XML'e
type: docs
weight: 145
url: /tr/python-net/convert-powerpoint-to-xml/
keywords:
- PowerPoint'i XML'e dönüştür
- sunumu XML'e dönüştür
- PPT'yi XML'e
- PPTX'i XML'e
- ODP'yi XML'e
- PowerPoint XML Sunumu
- SaveFormat.XML
- sunumu XML olarak kaydet
- sunumu XML'e dışa aktar
- XML akışı
- Python
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını Python'da Aspose.Slides ile PowerPoint XML dosyalarına veya akışlarına dönüştürün."
---
## **Genel Bakış**

Aspose.Slides for Python via .NET PowerPoint sunumlarını PowerPoint XML Sunum formatına dönüştürebilir. XML çıktısı, sunum yapısını incelemek, oluşturulan belgeleri sorun gidermek, otomatik testlerde çıktıyı karşılaştırmak veya bir sunum paketi yerine XML tüketen bir iş akışıyla entegrasyon sağlamak gibi metin tabanlı bir temsil gerektiğinde faydalıdır.

Presentation.save yöntemini, SaveFormat sayımının `XML` değerini kullanarak çağırın. Sonucu doğrudan bir dosyaya veya bir akısa yazabilirsiniz.

{{% alert color="info" title="Note" %}}
`SaveFormat.XML`, bir PowerPoint XML Sunumu oluşturur. PPTX paketinin içinde depolanan bireysel Office Open XML bölümlerini çıkartmaz. Eğer `ppt/presentation.xml` gibi tam PPTX paket bölümlerine veya tek tek slayt XML dosyalarına ihtiyacınız varsa, PPTX paketini kendiniz inceleyin.
{{% /alert %}}

## **Bir Sunumu XML Dosyasına Dönüştürme**

Kaynak bir sunumu [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfı ile yükleyin ve ardından çıktı yolunu ve `SaveFormat.XML` değerini [Presentation.save](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/save/) yöntemine geçirin. Kaynak, PPT, PPTX veya ODP gibi yükleme için desteklenen herhangi bir sunum formatı olabilir.

Aşağıdaki örnek bir PPTX sunumunu XML dosyasına dönüştürür:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.xml", slides.export.SaveFormat.XML)
```

## **XML Çıktısını Bir Akısa Yazma**

XML bellekte kalmalı ya da bir web hizmeti, depolama sağlayıcı ya da XML işleme hattı gibi başka bir bileşene geçirilmeliyse, [Presentation.save](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/save/) yönteminin akış aşırı yüklemesini kullanın. Aşağıdaki örnek sonucu bir [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) akışına yazar ve sonraki okuma için akışı başa alır:

```py
from io import BytesIO

import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    xml_stream = BytesIO()
    presentation.save(xml_stream, slides.export.SaveFormat.XML)
    xml_stream.seek(0)

    # xml_stream'i iş akışındaki bir sonraki bileşene aktar.
```

## **XML'i Sunum ve Dışa Aktarma Formatlarıyla Karşılaştırma**

Sonucun nasıl kullanılacağına göre çıktı formatını seçin:

| Biçim | Çıktı | Tipik kullanım |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Bir PowerPoint XML Sunumu | Yapıyı inceleme, sorun giderme, oluşturulan çıktıyı karşılaştırma ve XML tabanlı entegrasyon |
| PPT (`.ppt`) | Eski bir ikili sunum dosyası | Eski PowerPoint iş akışlarıyla uyumluluk |
| PPTX (`.pptx`) | Birçok bölümü içeren bir Office Open XML paketi | Normal PowerPoint düzenleme ve sunum değişimi |
| PDF veya TIFF | Sabit düzenli sayfalar veya çok sayfalı bir görüntü | Görütleme, yazdırma ve arşivleme |
| PNG, JPEG veya SVG | Tek bir slaydın işlenmiş temsili | Küçük resimler, ön izlemeler ve görüntü varlıkları |
| HTML veya HTML5 | Web odaklı sunum çıktısı | Tarayıcıda görüntüleme ve web yayıncılığı |

PPT ve PPTX'in aksine, XML çıktısı öncelikle inceleme ve veri odaklı iş akışları için tasarlanmıştır. PDF, TIFF, HTML ve slayt görüntü formatlarının aksine, slaytları sayfa ya da görsel varlık olarak işlemek yerine sunum verilerini temsil eder. Desteklenen dosya formatları tablosu, PowerPoint XML Sunumu'nu yalnızca kaydetme formatı olarak listeler; bu nedenle bir iş akışı dışa aktarılan dosyayı Aspose.Slides'a tekrar yükleyip düzenlemeye devam etmesi gerekiyorsa bunu kullanmayın.

## **SSS**

**`SaveFormat.XML`, PPTX dosyası kaydetmekle aynı mı?**

Hayır. PPTX, birden fazla Office Open XML bölümünü içeren bir pakettir, oysa `SaveFormat.XML` bir PowerPoint XML Sunumu dosyası oluşturur.

**XML çıktısını diske dosya oluşturmadan kaydedebilir miyim?**

Evet. Presentation.save yöntemine yazılabilir bir akış geçirin. Örneğin, bellek içi işleme için bir [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) akışı kullanabilirsiniz.

**Aspose.Slides dışa aktarılan XML dosyasını tekrar yükleyebilir mi?**

Hayır. PowerPoint XML Sunumu şu anda sadece kaydetme için desteklenir, yükleme için değildir. Çift yönlü düzenleme gerektiğinde PPTX ya da başka bir desteklenen sunum formatını kullanın.

**XML dönüşümü her slaytı bir sayfa veya görüntü olarak işler mi?**

Hayır. XML dönüşümü yapılandırılmış sunum verileri yazar. Sayfa odaklı çıktı için PDF veya TIFF, tek tek slayt görüntüleri için ise PNG, JPEG ve SVG kullanın.