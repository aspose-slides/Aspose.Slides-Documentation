---
title: PHP'de PowerPoint Sunumlarını XML'e Dönüştür
linktitle: PowerPoint'ten XML'e
type: docs
weight: 145
url: /tr/php-java/convert-powerpoint-to-xml/
keywords:
- PowerPoint'i XML'e dönüştür
- Sunumu XML'e dönüştür
- PPT'den XML'e
- PPTX'ten XML'e
- ODP'den XML'e
- PowerPoint XML Sunumu
- SaveFormat.Xml
- Sunumu XML olarak kaydet
- Sunumu XML'e dışa aktar
- XML akışı
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PHP'de PowerPoint ve OpenDocument sunumlarını PowerPoint XML dosyalarına veya akışlarına dönüştürün."
---
## **Genel Bakış**

Aspose.Slides for PHP via Java, PowerPoint sunumlarını PowerPoint XML Sunum formatına dönüştürebilir. XML çıktısı, sunum yapısını incelemek, oluşturulan belgeleri sorun gidermek, otomatik testlerde çıktıyı karşılaştırmak veya bir sunum paketi yerine XML tüketen bir iş akışıyla entegrasyon sağlamak istediğinizde metin tabanlı bir temsil gerektirdiğinde faydalıdır.

[Presentation::save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) metodunu, [SaveFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/saveformat/) enumarasyonundaki `Xml` değeriyle kullanın. Sonucu doğrudan bir dosyaya ya da bir akışa yazabilirsiniz.

{{% alert color="info" title="Not" %}}

`SaveFormat::Xml` bir PowerPoint XML Sunumu oluşturur. PPTX paketinin içinde depolanan bireysel Office Open XML bölümlerini çıkartmaz. `ppt/presentation.xml` gibi tam PPTX paket bölümlerine ya da tek tek slayt XML dosyalarına ihtiyacınız varsa, PPTX paketini doğrudan inceleyin.

{{% /alert %}}

## **Bir Sunumu XML Dosyasına Dönüştür**

[Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfıyla bir kaynak sunumu yükleyin ve ardından çıkış yolunu ve `SaveFormat::Xml` değerini [Presentation::save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) metoduna iletin. Kaynak, PPT, PPTX veya ODP gibi yükleme için desteklenen herhangi bir sunum biçimi olabilir.

Aşağıdaki örnek bir PPTX sunumunu XML dosyasına dönüştürür:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.xml";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Xml);
} finally {
    $presentation->dispose();
}
```

## **XML Çıktısını Bir Akışa Yazma**

XML bellekte kalmalı veya bir web hizmeti, depolama sağlayıcı veya XML işleme hattı gibi başka bir bileşene aktarılacaksa, [Presentation::save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) metodunun akış aşırı yüklemesini kullanın. Aşağıdaki örnek sonucu bir [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) ‘e yazar ve oluşturulan XML’i bir bayt dizisi olarak alır:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$presentation = new Presentation($inputPath);
try {
    $xmlStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $presentation->save($xmlStream, SaveFormat::Xml);
        $xmlBytes = $xmlStream->toByteArray();

        // $xmlBytes'i iş akışındaki bir sonraki bileşene iletin.
    } finally {
        $xmlStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Bir `ByteArrayOutputStream`, tüm oluşturulan veriyi bellekte saklar; bu nedenle `toByteArray` çağrılmadan önce konum sıfırlaması gerekmez.

## **XML'yi Sunum ve Dışa Aktarım Biçimleriyle Karşılaştırma**

Sonucun nasıl kullanılacağına göre çıktı biçimini seçin:

| Biçim | Çıktı | Tipik kullanım |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Sunumu | Yapıyı inceleme, sorun giderme, oluşturulan çıktıyı karşılaştırma ve XML tabanlı entegrasyon |
| PPT (`.ppt`) | Eski bir ikili sunum dosyası | Eski PowerPoint iş akışlarıyla uyumluluk |
| PPTX (`.pptx`) | Birden çok bölümü içeren Office Open XML paketi | Normal PowerPoint düzenleme ve sunum paylaşımı |
| PDF veya TIFF | Sabit düzenli sayfalar veya çok sayfalı bir görüntü | Görüntüleme, yazdırma ve arşivleme |
| PNG, JPEG veya SVG | Tek bir slaydın işlenmiş temsili | Küçük resimler, ön izlemeler ve görüntü varlıkları |
| HTML veya HTML5 | Web odaklı sunum çıktısı | Tarayıcıda görüntüleme ve web yayını |

PPT ve PPTX’ten farklı olarak XML çıktısı temel olarak inceleme ve veri odaklı iş akışları için tasarlanmıştır. PDF, TIFF, HTML ve slayt görüntü biçimlerinden farklı olarak, slaytları sayfalara veya görsel varlıklara dönüştürmek yerine sunum verisini temsil eder. [Desteklenen dosya biçimleri](/slides/tr/php-java/supported-file-formats/) tablosu PowerPoint XML Sunumunu yalnızca kaydetme amaçlı bir format olarak listeler; bu yüzden bir iş akışı, dışa aktarılan dosyayı Aspose.Slides içinde yeniden yükleyip düzenleme yapması gerekiyorsa bu formatı kullanmayın.

## **SSS**

**`SaveFormat::Xml` bir PPTX dosyası kaydetmekle aynı mı?**

Hayır. PPTX, birden çok Office Open XML bölümünü içeren bir pakettir, `SaveFormat::Xml` ise bir PowerPoint XML Sunumu dosyası oluşturur.

**XML çıktısını diskte bir dosya oluşturmadan kaydedebilir miyim?**

Evet. Yazılabilir bir akışı [Presentation::save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) metoduna iletin. Örneğin, bellek içi işlem için bir [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) kullanabilirsiniz.

**Aspose.Slides, dışa aktarılan XML dosyasını tekrar yükleyebilir mi?**

Hayır. PowerPoint XML Sunumu şu anda sadece kaydetme amaçlı desteklenir, yükleme için desteklenmez. Çift yönlü düzenleme gerektiğinde PPTX veya başka bir desteklenen sunum biçimini kullanın.

**XML dönüşümü her slaytı bir sayfa ya da görüntü olarak işler mi?**

Hayır. XML dönüşümü yapılandırılmış sunum verisini yazar. Sayfa odaklı çıktı için PDF veya TIFF, tek slayt görüntüleri için PNG, JPEG ve SVG kullanın.