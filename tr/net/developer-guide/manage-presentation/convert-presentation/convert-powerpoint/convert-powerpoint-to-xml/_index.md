---
title: .NET'te PowerPoint Sunumlarını XML'e Dönüştür
linktitle: PowerPoint'ten XML'e
type: docs
weight: 145
url: /tr/net/convert-powerpoint-to-xml/
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
- .NET
- C#
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını C# ile Aspose.Slides for .NET kullanarak PowerPoint XML dosyalarına veya akışlarına dönüştürün."
---
## **Genel Bakış**

Aspose.Slides for .NET, PowerPoint sunumlarını PowerPoint XML Sunum formatına dönüştürebilir. XML çıktısı, sunum yapısını incelemek, oluşturulan belgelerde sorun gidermek, otomatik testlerde çıktıyı karşılaştırmak veya XML tüketen bir iş akışıyla bütünleştirmek için metin tabanlı temsile ihtiyaç duyduğunuzda faydalıdır.

Sunum kaydetme biçimini belirtmek için [Presentation.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) yöntemini, [SaveFormat](https://reference.aspose.com/slides/tr/net/aspose.slides.export/saveformat/) enum'ından `Xml` değeriyle kullanın. Sonucu doğrudan bir dosyaya veya bir akışa yazabilirsiniz.

{{% alert color="info" title="Not" %}}

`SaveFormat.Xml` bir PowerPoint XML Sunumu oluşturur. PPTX paketinin içinde depolanan bireysel Office Open XML bölümlerini çıkartmaz. `ppt/presentation.xml` gibi kesin PPTX paket bölümlerine veya tek tek slayt XML dosyalarına ihtiyacınız varsa, PPTX paketini doğrudan inceleyin.

{{% /alert %}}

## **Bir Sunumu XML Dosyasına Dönüştürme**

[Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfı ile bir kaynak sunumu yükleyin ve ardından çıktının yolunu ve `SaveFormat.Xml` değerini [Presentation.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) yöntemine geçirin. Kaynak, PPT, PPTX veya ODP gibi yükleme için desteklenen herhangi bir sunum formatı olabilir.

Aşağıdaki örnek, bir PPTX sunumunu XML dosyasına dönüştürür:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **XML Çıktısını Bir Akışa Yazma**

XML'in bellekte kalması veya bir web servisi, depolama sağlayıcısı veya XML işleme hattı gibi başka bir bileşene aktarılması gerektiğinde [Presentation.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) yönteminin akış aşırı yüklemesini kullanın. Aşağıdaki örnek, sonucu bir [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) içine yazar ve sonraki okuma için başa sarar:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// xmlStream'i iş akışındaki bir sonraki bileşene geçir.
```

## **XML'yi Sunum ve Dışa Aktarım Biçimleriyle Karşılaştırma**

Sonucun nasıl kullanılacağına göre çıktı biçimini seçin:

| Biçim | Çıktı | Tipik kullanım |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Sunumu | Yapıyı inceleme, sorun giderme, oluşturulan çıktıyı karşılaştırma ve XML tabanlı bütünleştirme |
| PPT (`.ppt`) | Eski ikili bir sunum dosyası | Eski PowerPoint iş akışlarıyla uyumluluk |
| PPTX (`.pptx`) | Birçok bölümü içeren Office Open XML paketi | Normal PowerPoint düzenleme ve sunum değişimi |
| PDF veya TIFF | Sabit düzenli sayfalar veya çok sayfalı bir görüntü | Görüntüleme, yazdırma ve arşivleme |
| PNG, JPEG veya SVG | Tek bir slaydın renderlanmış temsili | Küçük resimler, ön izlemeler ve görsel varlıklar |
| HTML veya HTML5 | Web odaklı sunum çıktısı | Tarayıcıda görüntüleme ve web yayıncılığı |

PPT ve PPTX'in aksine, XML çıktısı esas olarak denetim ve veri odaklı iş akışları için tasarlanmıştır. PDF, TIFF, HTML ve slayt görüntü formatlarının aksine, slaytları sayfa veya görsel varlık olarak renderlemez, sunum verilerini temsil eder. [supported file formats](/slides/tr/net/supported-file-formats/) tablosu PowerPoint XML Sunumu'nu yalnızca kaydetme formatı olarak listeler; bu nedenle, bir iş akışının dışa aktarılan dosyayı Aspose.Slides'e tekrar yükleyerek düzenlemeye devam etmesi gerektiğinde bunu kullanmayın.

## **SSS**

**`SaveFormat.Xml`, PPTX dosyası kaydetmekle aynı şey mi?**

Hayır. PPTX, birden çok Office Open XML bölümünü içeren bir paket iken, `SaveFormat.Xml` bir PowerPoint XML Sunumu dosyası oluşturur.

**XML çıktısını diskte dosya oluşturmadan kaydedebilir miyim?**

Evet. Yazılabilir bir akışı [Presentation.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) yöntemine aktarın. Örneğin, bellek içi işlem için bir [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) kullanabilirsiniz.

**Aspose.Slides, dışa aktarılan XML dosyasını tekrar yükleyebilir mi?**

Hayır. PowerPoint XML Sunumu şu anda yalnızca kaydetme için desteklenir, yükleme için desteklenmez. Çift yönlü düzenleme gerektiğinde PPTX veya başka bir desteklenen sunum formatını kullanın.

**XML dönüşümü her slaytı sayfa veya görüntü olarak renderler mi?**

Hayır. XML dönüşümü yapılandırılmış sunum verileri yazar. Sayfa odaklı çıktı için PDF veya TIFF, tek slayt görüntüleri için ise PNG, JPEG ve SVG kullanın.