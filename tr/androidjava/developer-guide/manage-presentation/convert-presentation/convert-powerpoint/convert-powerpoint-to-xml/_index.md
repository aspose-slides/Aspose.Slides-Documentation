---
title: Android'de PowerPoint Sunumlarını XML'e Dönüştürme
linktitle: PowerPoint'ten XML'e
type: docs
weight: 145
url: /tr/androidjava/convert-powerpoint-to-xml/
keywords:
- PowerPoint'i XML'e dönüştür
- sunumu XML'e dönüştür
- PPT'den XML'e
- PPTX'den XML'e
- ODP'den XML'e
- PowerPoint XML Sunumu
- SaveFormat.Xml
- sunumu XML olarak kaydet
- sunumu XML'e aktar
- XML akışı
- Android
- Java
- Aspose.Slides
description: "Android'de Aspose.Slides ile PowerPoint ve OpenDocument sunumlarını PowerPoint XML dosyalarına veya akışlarına dönüştürün."
---
## **Genel Bakış**

Aspose.Slides for Android via Java, PowerPoint sunumlarını PowerPoint XML Sunum formatına dönüştürebilir. XML çıktısı, sunum yapısını incelemek, oluşturulan belgelerde sorun gidermek, otomatik testlerde çıktıyı karşılaştırmak veya bir sunum paketinin yerine XML tüketen bir iş akışıyla bütünleşmek için metin tabanlı bir temsil gerektiğinde kullanışlıdır.

Sonucu doğrudan bir dosyaya ya da bir akıma yazmak için [Presentation.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) metodunu [SaveFormat.Xml](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/saveformat/#Xml) ile kullanın.

{{% alert color="info" title="Not" %}}

`SaveFormat.Xml` bir PowerPoint XML Sunumu oluşturur. PPTX paketinin içinde depolanan bireysel Office Open XML bölümlerini çıkarmaz. `ppt/presentation.xml` gibi tam PPTX paket bölümlerine veya tek tek slayt XML dosyalarına ihtiyacınız varsa, PPTX paketini doğrudan inceleyin.

{{% /alert %}}

## **Bir Sunumu XML Dosyasına Dönüştürme**

Kaynak bir sunumu [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfı ile yükleyin ve ardından çıktı yolunu ve [SaveFormat.Xml](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/saveformat/#Xml) değerini [Presentation.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) metoduna iletin. Kaynak, PPT, PPTX veya ODP gibi yükleme için desteklenen herhangi bir sunum biçimi olabilir.

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

XML bellekte kalmalıysa veya bir web servisi, depolama sağlayıcı ya da XML işleme hattı gibi başka bir bileşene aktarılacaksa, [Presentation.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) metodunun akım aşırı yüklemesini kullanın. Aşağıdaki örnek sonucu bir [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) içine yazar ve oluşturulan XML’i bir bayt dizisi olarak elde eder:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ByteArrayOutputStream xmlStream = new ByteArrayOutputStream();
    try {
        presentation.save(xmlStream, SaveFormat.Xml);
        byte[] xmlData = xmlStream.toByteArray();

        // xmlData'yı iş akışındaki bir sonraki bileşene aktar.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **XML'yi Sunum ve Dışa Aktarım Formatlarıyla Karşılaştırma**

Sonucun nasıl kullanılacağına göre çıktı biçimini seçin:

| Format | Çıktı | Tipik kullanım |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Sunumu | Yapıyı inceleme, sorun giderme, oluşturulan çıktıyı karşılaştırma ve XML tabanlı entegrasyon |
| PPT (`.ppt`) | Eski ikili bir sunum dosyası | Eski PowerPoint iş akışlarıyla uyumluluk |
| PPTX (`.pptx`) | Birden çok bölüm içeren Office Open XML paketi | Normal PowerPoint düzenleme ve sunum değişimi |
| PDF veya TIFF | Sabit sayfa düzeni sayfaları veya çok sayfalı görüntü | Görme, yazdırma ve arşivleme |
| PNG, JPEG veya SVG | Tek bir slaytın işlenmiş temsili | Küçük resimler, ön izlemeler ve görsel varlıklar |
| HTML veya HTML5 | Web odaklı sunum çıktısı | Tarayıcıda görüntüleme ve web yayınlama |

PPT ve PPTX’in aksine XML çıktısı esas olarak denetim ve veri odaklı iş akışları için tasarlanmıştır. PDF, TIFF, HTML ve slayt görsel formatlarının aksine, slaytları sayfa veya görsel varlık olarak işlemek yerine sunum verisini temsil eder. [desteklenen dosya formatları](/slides/tr/androidjava/supported-file-formats/) tablosu PowerPoint XML Sunumunu yalnızca kaydetme formatı olarak listeler; bu nedenle bir iş akışı dosyayı tekrar Aspose.Slides’a yükleyerek düzenlemeye devam etmesi gerekiyorsa bu formatı kullanmayın.

## **SSS**

**`SaveFormat.Xml`, bir PPTX dosyası kaydetmekle aynı mı?**

Hayır. PPTX, birden çok Office Open XML bölümünü içeren bir paket iken, `SaveFormat.Xml` bir PowerPoint XML Sunumu dosyası oluşturur.

**XML çıktısını diskte dosya oluşturmadan kaydedebilir miyim?**

Evet. Yazılabilir bir akımı [Presentation.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) metoduna iletin. Örneğin, bellekte işlemek için bir [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) kullanabilirsiniz.

**Aspose.Slides, dışa aktarılan XML dosyasını tekrar yükleyebilir mi?**

Hayır. PowerPoint XML Sunumu şu anda yalnızca kaydetme için desteklenir; yükleme desteklenmez. Çevrim içi düzenleme gerektiğinde PPTX veya başka bir desteklenen sunum formatını kullanın.

**XML dönüşümü her slaytı bir sayfa veya görüntü olarak işliyor mu?**

Hayır. XML dönüşümü yapılandırılmış sunum verisini yazar. Sayfa odaklı çıktı için PDF veya TIFF, tek slayt görselleri için PNG, JPEG ve SVG kullanın.