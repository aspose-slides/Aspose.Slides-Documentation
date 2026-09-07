---
title: Python üzerinden Java ile PowerPoint Sunumlarını XML'e Dönüştür
linktitle: PowerPoint'ten XML'e
type: docs
weight: 145
url: /tr/python-java/convert-powerpoint-to-xml/
keywords:
- PowerPoint'i XML'e dönüştür
- sunumu XML'e dönüştür
- PPT'yi XML'e dönüştür
- PPTX'i XML'e dönüştür
- ODP'yi XML'e dönüştür
- PowerPoint XML Sunumu
- SaveFormat.Xml
- sunumu XML olarak kaydet
- sunumu XML'e aktar
- XML akışı
- Python
- Java
- Aspose.Slides
description: "Python üzerinden Java ile Aspose.Slides for Python via Java kullanarak PowerPoint ve OpenDocument sunumlarını PowerPoint XML dosyalarına veya akışlarına dönüştürün."
---
## **Genel Bakış**

Aspose.Slides for Python via Java, PowerPoint sunumlarını PowerPoint XML Sunum formatına dönüştürebilir. XML çıktısı, sunum yapısını incelemek, oluşturulan belgelerde sorun gidermek, otomatik testlerde çıktıyı karşılaştırmak veya XML tüketen bir iş akışıyla entegrasyon sağlamak gibi metin tabanlı bir temsile ihtiyaç duyduğunuzda kullanışlıdır.

Sonucu bir dosyaya ya da bir akışa doğrudan yazabilen, [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) metodunu [SaveFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/) sınıfındaki [Xml](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/#Xml) değeriyle kullanın.

{{% alert color="info" title="Note" %}}
[SaveFormat.Xml](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/#Xml) bir PowerPoint XML Sunumu oluşturur. PPTX paketinin içinde saklanan bireysel Office Open XML parçalarını çıkartmaz. `ppt/presentation.xml` gibi kesin PPTX paket parçalarına veya tek tek slayt XML dosyalarına ihtiyacınız varsa, PPTX paketini kendiniz inceleyin.
{{% /alert %}}

## **Bir Sunumu XML Dosyasına Dönüştürme**

[Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfıyla bir kaynak sunumu yükleyin ve ardından çıktı yolu ile [SaveFormat.Xml](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/#Xml) değerini [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) yöntemine iletin. Kaynak, PPT, PPTX veya ODP gibi yükleme için desteklenen herhangi bir sunum formatı olabilir.

Aşağıdaki örnek bir PPTX sunumunu XML dosyasına dönüştürür:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.xml", SaveFormat.Xml)
finally:
    presentation.dispose()
```

## **XML Çıktısını Bir Akışa Yazma**

[Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) metodunun akış aşırı yüklemesini, XML'in bellekte kalması gerektiğinde ya da bir web servisi, depolama sağlayıcısı veya XML işleme hattı gibi başka bir bileşene iletilmesi gerektiğinde kullanın. Aşağıdaki örnek sonucu bir [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html)’a yazar ve elde edilen XML'i bir Python bytes nesnesi olarak alır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

presentation = Presentation("presentation.pptx")
try:
    xml_stream = ByteArrayOutputStream()
    try:
        presentation.save(xml_stream, SaveFormat.Xml)
        java_bytes = xml_stream.toByteArray()
        xml_data = bytes(java_bytes)

        # xml_data'yı iş akışındaki bir sonraki bileşene aktar.
    finally:
        xml_stream.close()
finally:
    presentation.dispose()
```

## **XML'i Sunum ve Dışa Aktarma Biçimleriyle Karşılaştırma**

Sonucun nasıl kullanılacağına göre çıktı formatını seçin:

| Biçim | Çıktı | Tipik Kullanım |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Sunumu | Yapıyı inceleme, sorun giderme, oluşturulan çıktıyı karşılaştırma ve XML tabanlı entegrasyon |
| PPT (`.ppt`) | Eski ikili sunum dosyası | Eski PowerPoint iş akışlarıyla uyumluluk |
| PPTX (`.pptx`) | Birden fazla bölüm içeren Office Open XML paketi | Normal PowerPoint düzenleme ve sunum değişimi |
| PDF or TIFF | Sabit düzenli sayfalar veya çok sayfalı görüntü | Görüntüleme, yazdırma ve arşivleme |
| PNG, JPEG, or SVG | Tek bir slaytın işlenmiş temsilî görüntüsü | Küçük resimler, ön izlemeler ve görsel varlıklar |
| HTML or HTML5 | Web odaklı sunum çıktısı | Tarayıcıda görüntüleme ve web yayıncılığı |

PPT ve PPTX'ten farklı olarak, XML çıktısı öncelikle inceleme ve veri odaklı iş akışları için tasarlanmıştır. PDF, TIFF, HTML ve slayt görüntü formatlarından farklı olarak, slaytları sayfa veya görsel varlık olarak render etmek yerine sunum verilerini temsil eder. [supported file formats](/slides/tr/python-java/supported-file-formats/) tablosu PowerPoint XML Sunumunu yalnızca kaydetme formatı olarak listeler; bu nedenle, bir iş akışının dışa aktarılan dosyayı Aspose.Slides'a yeniden yükleyip düzenlemeye devam etmesi gerekiyorsa kullanmayın.

## **SSS**

**XML dışa aktarma bir PPTX dosyası kaydetmekle aynı mı?**  
Hayır. PPTX, birden çok Office Open XML parçası içeren bir pakettir; oysa [SaveFormat.Xml](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/#Xml) bir PowerPoint XML Sunumu dosyası oluşturur.

**XML çıktısını diskte dosya oluşturmadan kaydedebilir miyim?**  
Evet. Yazılabilir bir Java çıkış akışını [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) metoduna iletebilirsiniz. Örneğin, bellek içi işleme için bir [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) kullanın.

**Aspose.Slides dışa aktarılan XML dosyasını tekrar yükleyebilir mi?**  
Hayır. PowerPoint XML Sunumu şu anda yalnızca kaydetme için desteklenir, yükleme için değil. Çift yönlü düzenleme gerektiğinde PPTX veya başka bir desteklenen sunum formatını kullanın.

**XML dönüşümü her slaytı bir sayfa veya görüntü olarak işler mi?**  
Hayır. XML dönüşümü yapılandırılmış sunum verilerini yazar. Sayfa odaklı çıktı için PDF veya TIFF, tek slayt görüntüleri için ise PNG, JPEG ve SVG kullanın.