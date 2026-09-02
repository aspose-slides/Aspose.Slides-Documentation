---
title: Java'da PowerPoint Sunumlarını XML'e Dönüştür
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
description: "Aspose.Slides for Java ile Java'da PowerPoint ve OpenDocument sunumlarını PowerPoint XML dosyalarına veya akışlarına dönüştürün."
---
## **Genel Bakış**

Aspose.Slides for Java, PowerPoint sunumlarını PowerPoint XML Sunum formatına dönüştürebilir. XML çıktısı, sunum yapısını incelemek, oluşturulan belgelerde sorun gidermek, otomatik testlerde çıktıyı karşılaştırmak veya XML tüketen bir iş akışıyla bütünleştirmek istediğinizde metin tabanlı bir temsil sağlamada yararlıdır.

Presentation.save metodunu, [SaveFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/saveformat/) sınıfındaki `Xml` değeriyle birlikte kullanın. Sonucu doğrudan bir dosyaya veya bir akıma yazabilirsiniz.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` bir PowerPoint XML Sunumu oluşturur. PPTX paketinin içinde depolanan ayrı Office Open XML bölümlerini çıkarmaz. Eğer `ppt/presentation.xml` gibi tam PPTX paket bölümlerine veya tek tek slayt XML dosyalarına ihtiyacınız varsa, PPTX paketini doğrudan inceleyin.
{{% /alert %}}

## **Sunumu XML Dosyasına Dönüştürme**

Kaynak bir sunumu [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfı ile yükleyin ve ardından çıktı yolunu ve `SaveFormat.Xml` değerini [Presentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#save-java.lang.String-int-) metoduna aktarın. Kaynak, PPT, PPTX veya ODP gibi yükleme için desteklenen herhangi bir sunum formatı olabilir.

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

## **XML Çıktısını Bir Akıma Yazma**

XML bellekte kalmalı veya bir web servisi, depolama sağlayıcı veya XML işleme hattı gibi başka bir bileşene geçirilmeliyse, [Presentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) metodunun akım aşırı yüklemesini kullanın. Aşağıdaki örnek sonucu bir [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) ile yazar ve oluşan XML'i bir bayt dizisi olarak elde eder:

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

## **XML'yi Sunum ve Dışa Aktarım Biçimleriyle Karşılaştırma**

Sonucun nasıl kullanılacağına göre çıktı biçimini seçin:

| Biçim | Çıktı | Tipik kullanım |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Sunumu | Yapıyı inceleme, sorun giderme, oluşturulan çıktıyı karşılaştırma ve XML‑tabanlı entegrasyon |
| PPT (`.ppt`) | Eski ikili bir sunum dosyası | Eski PowerPoint iş akışlarıyla uyumluluk |
| PPTX (`.pptx`) | Birden fazla bölüm içeren Office Open XML paketi | Normal PowerPoint düzenleme ve sunum alışverişi |
| PDF or TIFF | Sabit düzenli sayfalar veya çok sayfalı bir resim | Görüntüleme, baskı ve arşivleme |
| PNG, JPEG, or SVG | Tek bir slaytın render edilmiş temsili | Küçük resimler, ön izlemeler ve görsel varlıklar |
| HTML or HTML5 | Web‑odaklı sunum çıktısı | Tarayıcıda görüntüleme ve web yayıncılığı |

PPT ve PPTX'ye kıyasla, XML çıktısı öncelikle inceleme ve veri‑odaklı iş akışları için tasarlanmıştır. PDF, TIFF, HTML ve slayt görüntü formatlarından farklı olarak, slaytları sayfalar ya da görsel varlıklar olarak render etmek yerine sunum verilerini temsil eder. [supported file formats](/slides/tr/java/supported-file-formats/) tablosu, PowerPoint XML Sunumu'nu yalnızca kaydetme formatı olarak listeler; bu nedenle, bir iş akışının dışa aktarılan dosyayı Aspose.Slides'e tekrar yükleyip düzenleme yapması gerektiğinde kullanmayın.

## **SSS**

**`SaveFormat.Xml`, PPTX dosyası kaydetmekle aynı şey mi?**

Hayır. PPTX, birden fazla Office Open XML bölümünü içeren bir paket iken, `SaveFormat.Xml` bir PowerPoint XML Sunumu dosyası oluşturur.

**XML çıktısını diskte dosya oluşturmadan kaydedebilir miyim?**

Evet. Yazılabilir bir akımı [Presentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) metoduna aktarın. Örneğin, hafıza içi işleme için bir [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) kullanın.

**Aspose.Slides dışa aktarılan XML dosyasını tekrar yükleyebilir mi?**

Hayır. PowerPoint XML Sunumu şu anda yalnızca kaydetme için desteklenir, yükleme için desteklenmez. Çift yönlü düzenleme gerektiğinde PPTX veya başka bir desteklenen sunum formatını kullanın.

**XML dönüşümü her slaytı bir sayfa veya resim olarak render eder mi?**

Hayır. XML dönüşümü yapılandırılmış sunum verilerini yazar. Sayfa‑odaklı çıktı için PDF veya TIFF, tek slayt görselleri için ise PNG, JPEG ve SVG kullanın.