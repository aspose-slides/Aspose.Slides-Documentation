---
title: JavaScript'te PowerPoint Sunumlarını XML'e Dönüştür
linktitle: PowerPoint'ten XML'e
type: docs
weight: 145
url: /tr/nodejs-java/convert-powerpoint-to-xml/
keywords:
- PowerPoint'i XML'e dönüştür
- sunumu XML'e dönüştür
- PPT'yi XML'e dönüştür
- PPTX'i XML'e dönüştür
- ODP'yi XML'e dönüştür
- PowerPoint XML Sunumu
- SaveFormat.Xml
- sunumu XML olarak kaydet
- sunumu XML'e dışa aktar
- XML akışı
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java ile JavaScript'te PowerPoint ve OpenDocument sunumlarını PowerPoint XML dosyalarına veya akışlarına dönüştürün."
---
## **Genel Bakış**

Aspose.Slides for Node.js via Java, PowerPoint sunumlarını PowerPoint XML Sunum formatına dönüştürebilir. XML çıktısı, sunum yapısını incelemek, oluşturulan belgeleri sorun giderme, otomatik testlerde çıktıyı karşılaştırma veya XML tüketen bir iş akışıyla bütünleştirme gibi metin tabanlı bir temsil gerektiğinde faydalıdır.

[Presentation.save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#save) metodunu, [SaveFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/saveformat/) enum'undan `Xml` değeriyle kullanın. Sonucu doğrudan bir dosyaya veya bir akışa yazabilirsiniz.

{{% alert color="info" title="Not" %}}
`SaveFormat.Xml` bir PowerPoint XML Sunumu oluşturur. PPTX paketinin içinde depolanan bireysel Office Open XML parçalarını çıkartmaz. Eğer `ppt/presentation.xml` gibi tam PPTX paketi parçalarına ihtiyacınız varsa, PPTX paketini kendiniz inceleyin.
{{% /alert %}}

## **Sunumu XML Dosyasına Dönüştür**

[Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfıyla bir kaynak sunumu yükleyin ve ardından çıktı yolunu ve `SaveFormat.Xml` değerini [Presentation.save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#save) metoduna geçirin. Kaynak, PPT, PPTX veya ODP gibi yükleme desteklenen herhangi bir sunum formatı olabilir.

Aşağıdaki örnek bir PPTX sunumunu XML dosyasına dönüştürür:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("presentation.xml", aspose.slides.SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **XML Çıktısını Bir Akışa Yaz**

XML bellekte kalmalı veya bir web servisi, depolama sağlayıcı veya XML işleme hattı gibi başka bir bileşene aktarılacaksa, [Presentation.save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#save) metodunun akış aşırı yüklemesini kullanın. Aşağıdaki örnek sonucu bir Java `ByteArrayOutputStream`'e yazar ve oluşturulan verileri bir Node.js `Buffer`'a kopyalar:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xmlStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        presentation.save(xmlStream, aspose.slides.SaveFormat.Xml);

        const xmlBuffer = Buffer.from(xmlStream.toByteArray());
        console.log(`XML size: ${xmlBuffer.length} bytes`);

        // xmlBuffer'ı iş akışındaki bir sonraki bileşene aktarın.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **XML'yi Sunum ve Dışa Aktarma Biçimleriyle Karşılaştır**

Sonucun nasıl kullanılacağına göre çıktı biçimini seçin:

| Biçim | Çıktı | Tipik kullanım |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Bir PowerPoint XML Sunumu | Yapıyı inceleme, sorun giderme, oluşturulan çıktıyı karşılaştırma ve XML tabanlı entegrasyon |
| PPT (`.ppt`) | Eski tip bir ikili sunum dosyası | Eski PowerPoint iş akışlarıyla uyumluluk |
| PPTX (`.pptx`) | Birden çok parçayı içeren Office Open XML paketi | Normal PowerPoint düzenleme ve sunum paylaşımı |
| PDF veya TIFF | Sabit sayfa düzeni veya çok sayfalı görüntü | Görüntüleme, yazdırma ve arşivleme |
| PNG, JPEG veya SVG | Tek bir slaytın renderlanmış temsili | Küçük resimler, ön izlemeler ve görsel varlıklar |
| HTML veya HTML5 | Web odaklı sunum çıktısı | Tarayıcı görüntüleme ve web yayınlama |

PPT ve PPTX'in aksine XML çıktısı öncelikle inceleme ve veri odaklı iş akışları için tasarlanmıştır. PDF, TIFF, HTML ve slayt görüntü biçimlerinin aksine sunum verisini temsil eder, slaytları sayfa ya da görsel varlık olarak render etmez. [Desteklenen dosya biçimleri](/slides/tr/nodejs-java/supported-file-formats/) tablosu PowerPoint XML Sunumunu yalnızca kaydetme biçimi olarak listeler; bu nedenle bir iş akışının dosyayı tekrar Aspose.Slides ile yükleyip düzenlemesi gerekiyorsa bu biçimi kullanmayın.

## **SSS**

**`SaveFormat.Xml`, PPTX dosyası kaydetmekle aynı mı?**  
Hayır. PPTX, birden çok Office Open XML parçası içeren bir pakettir, `SaveFormat.Xml` ise bir PowerPoint XML Sunum dosyası oluşturur.

**XML çıktısını bir dosya oluşturmadan kaydedebilir miyim?**  
Evet. Yazılabilir bir akışı [Presentation.save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#save) metoduna iletin. Örneğin bir Java `ByteArrayOutputStream` kullanıp verilerini bir Node.js `Buffer`'a kopyalayarak bellek içi işleme yapabilirsiniz.

**Aspose.Slides, dışa aktarılan XML dosyasını tekrar yükleyebilir mi?**  
Hayır. PowerPoint XML Sunumu şu anda yalnızca kaydetme amaçlı desteklenir, yükleme için desteklenmez. Yuvarlak dönüş düzenleme gerekiyorsa PPTX veya başka bir desteklenen sunum biçimini kullanın.

**XML dönüşümü her slaytı bir sayfa veya görüntü olarak render eder mi?**  
Hayır. XML dönüşümü yapılandırılmış sunum verisi yazar. Sayfa odaklı çıktı için PDF veya TIFF, tek slayt görüntüleri için PNG, JPEG ve SVG kullanın.