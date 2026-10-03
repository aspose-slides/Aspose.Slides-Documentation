---
title: PowerPoint Sunumlarını Java'da XML'e Dönüştür
linktitle: PowerPoint'ten XML'e
type: docs
weight: 145
url: /tr/java/convert-powerpoint-to-xml/
keywords:
- PowerPoint'i XML'e dönüştür
- sunumu XML'e dönüştür
- PPT'yi XML'e
- PPTX'i XML'e
- ODP'yi XML'e
- PowerPoint XML Sunumu
- SaveFormat.Xml
- sunumu XML olarak kaydet
- sunumu XML'e dışa aktar
- XML akışı
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak PowerPoint ve OpenDocument sunumlarını Java'da PowerPoint XML dosyalarına veya akışlarına dönüştürün."
---
## **Genel Bakış**

Aspose.Slides for Java, PowerPoint sunumlarını PowerPoint XML Sunumu formatına dönüştürebilir. XML çıktısı, sunum yapısını incelemek, oluşturulan belgelerde sorun gidermek, otomatik testlerde çıktıyı karşılaştırmak veya XML tüketen bir iş akışıyla bütünleştirmek istediğinizde metin tabanlı bir temsil sağlar.

`Xml` değeriyle birlikte [Presentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#save-java.lang.String-int-) metodunu [SaveFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/saveformat/) sınıfından kullanın. Sonucu doğrudan bir dosyaya ya da akıma yazabilirsiniz.

{{% alert color="info" title="Note" %}}

`SaveFormat.Xml` bir PowerPoint XML Sunumu oluşturur. PPTX paketinin içinde saklanan ayrı Office Open XML bölümlerini dışa çıkarmaz. Eğer `ppt/presentation.xml` gibi tam PPTX paket bölümlerine veya tek tek slayt XML dosyalarına ihtiyacınız varsa PPTX paketini inceleyin.

{{% /alert %}}

## **Sunumu XML Dosyasına Dönüştür**

[Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfı ile bir kaynak sunum yükleyin ve çıkış yolunu ve `SaveFormat.Xml` değerini [Presentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#save-java.lang.String-int-) metoduna aktarın. Kaynak, PPT, PPTX veya ODP gibi yükleme için desteklenen herhangi bir sunum formatı olabilir.

Aşağıdaki örnek bir PPTX sunumunu XML dosyasına dönüştürür:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.xml", SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **XML Çıktısını Akıma Yaz**

XML bellekte kalmalı veya bir web hizmeti, depolama sağlayıcısı veya XML işleme hattı gibi başka bir bileşene aktarılacaksa [Presentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) metodunun akış aşırı yüklemesini kullanın. Aşağıdaki örnek sonucu bir [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html)ʼa yazar ve elde edilen XML’i bayt dizisi olarak alır:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // xmlData'yı iş akışındaki bir sonraki bileşene iletin.
} finally {
    presentation.dispose();
}
```

## **XML'i Sunum ve Dışa Aktarım Biçimleriyle Karşılaştır**

Sonucun nasıl kullanılacağına göre çıkış biçimini seçin:

| Biçim | Çıktı | Tipik kullanım |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Sunumu | Yapıyı inceleme, sorun giderme, oluşturulan çıktıyı karşılaştırma ve XML tabanlı entegrasyon |
| PPT (`.ppt`) | Eski ikili sunum dosyası | Eski PowerPoint iş akışlarıyla uyumluluk |
| PPTX (`.pptx`) | Birden çok bölüm içeren Office Open XML paketi | Normal PowerPoint düzenleme ve sunum değişimi |
| PDF veya TIFF | Sabit düzenli sayfalar veya çok sayfalı görüntü | Görüntüleme, yazdırma ve arşivleme |
| PNG, JPEG veya SVG | Tek bir slaytın işlenmiş temsili | Küçük resimler, ön izlemeler ve görsel varlıklar |
| HTML veya HTML5 | Web odaklı sunum çıktısı | Tarayıcıda görüntüleme ve web yayınlama |

PPT ve PPTX’ten farklı olarak XML çıktısı öncelikle inceleme ve veri odaklı iş akışları için tasarlanmıştır. PDF, TIFF, HTML ve slayt görüntü biçimlerinden farklı olarak, slaytları sayfa veya görsel varlık olarak render etmek yerine sunum verisini temsil eder. [Desteklenen dosya formatları](/slides/tr/java/supported-file-formats/) tablosu, Aspose.Slides’ın yükleyebileceği, içe aktarabileceği, kaydedebileceği veya render edebileceği tüm formatları listeler.

## **SSS**

**`SaveFormat.Xml` bir PPTX dosyası kaydetmekle aynı mı?**

Hayır. PPTX birden çok Office Open XML parçası içeren bir paket iken, `SaveFormat.Xml` bir PowerPoint XML Sunumu dosyası oluşturur.

**XML çıktısını diskte dosya oluşturmadan kaydedebilir miyim?**

Evet. Yazılabilir bir akışı [Presentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) metoduna aktarın. Örneğin, bellekte işleme için bir [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) kullanabilirsiniz.

**Aspose.Slides dışa aktarılan XML dosyasını tekrar yükleyebilir mi?**

Evet. XML dosyasını veya bir akışı [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) yapıcısına aktarın. [Presentation.getSourceFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getSourceFormat--) daha sonra `SourceFormat.Xml` değerini döndürür. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) bu format için `LoadFormat.Unknown` raporlar, bu nedenle bir XML dosyasının açılıp açılamayacağını karar vermek için kullanmayın.

**XML dönüşümü her slaytı sayfa veya görüntü olarak render eder mi?**

Hayır. XML dönüşümü yapılandırılmış sunum verisi yazar. Sayfa odaklı çıkış için PDF veya TIFF, tek slayt görüntüleri için ise PNG, JPEG ve SVG kullanın.