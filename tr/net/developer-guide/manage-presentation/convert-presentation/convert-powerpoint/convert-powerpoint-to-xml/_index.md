---
title: PowerPoint Sunumlarını .NET'te XML'e Dönüştür
linktitle: PowerPoint'ten XML'e
type: docs
weight: 145
url: /tr/net/convert-powerpoint-to-xml/
keywords:
- PowerPoint'i XML'e dönüştür
- sunumu XML'e dönüştür
- PPT'den XML'e
- PPTX'ten XML'e
- ODP'den XML'e
- PowerPoint XML Sunumu
- SaveFormat.Xml
- sunumu XML olarak kaydet
- sunumu XML'e aktar
- XML akışı
- .NET
- C#
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını C# ile Aspose.Slides for .NET kullanarak PowerPoint XML dosyalarına veya akışlarına dönüştür."
---
## **Genel Bakış**

Aspose.Slides for .NET, PowerPoint sunumlarını PowerPoint XML Sunum formatına dönüştürebilir. XML çıktısı, sunum yapısını incelemek, oluşturulan belgelerde sorun gidermek, otomatik testlerde çıktıyı karşılaştırmak veya bir sunum paketinin yerine XML tüketen bir iş akışıyla entegre olmak gibi metin tabanlı bir temsil gerektiğinde yararlıdır.

[Presentation.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) yöntemini, [SaveFormat](https://reference.aspose.com/slides/tr/net/aspose.slides.export/saveformat/) sayımındaki `Xml` değeriyle kullanın. Sonucu doğrudan bir dosyaya ya da bir akışa (stream) yazabilirsiniz.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` bir PowerPoint XML Sunumu oluşturur. PPTX paketinin içinde depolanan bireysel Office Open XML parçalarını çıkartmaz. `ppt/presentation.xml` gibi belirli PPTX paket parçalarına veya ayrı ayrı slayt XML dosyalarına ihtiyacınız varsa, PPTX paketini doğrudan inceleyin.
{{% /alert %}}

## **Bir Sunumu XML Dosyasına Dönüştürme**

Kaynak bir sunumu [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfıyla yükleyin ve ardından çıktı yolunu ve `SaveFormat.Xml` değerini [Presentation.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) metoduna aktarın. Kaynak, PPT, PPTX veya ODP gibi yükleme için desteklenen herhangi bir sunum formatı olabilir.

Aşağıdaki örnek, bir PPTX sunumunu XML dosyasına dönüştürür:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **XML Çıktısını Bir Akışa Yazma**

[Presentation.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) metodunun akış (stream) aşırı yüklemesini, XML'in bellekte kalması veya bir web hizmeti, depolama sağlayıcısı veya XML işleme hattı gibi başka bir bileşene aktarılması gerektiğinde kullanın. Aşağıdaki örnek, sonucu bir [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) içine yazar ve sonraki okumalar için konumunu başa alır:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// xmlStream'i iş akışındaki bir sonraki bileşene aktar.
```

## **XML'i Sunum ve Dışa Aktarım Formatlarıyla Karşılaştırma**

Sonucun nasıl kullanılacağına göre çıktı formatını seçin:

| Biçim | Çıktı | Tipik kullanım |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Bir PowerPoint XML Sunumu | Yapıyı inceleme, sorun giderme, oluşturulan çıktıyı karşılaştırma ve XML tabanlı bütünleştirme |
| PPT (`.ppt`) | Eski bir ikili sunum dosyası | Daha eski PowerPoint iş akışlarıyla uyumluluk |
| PPTX (`.pptx`) | Birden fazla parçayı içeren Office Open XML paketi | Normal PowerPoint düzenleme ve sunum değişimi |
| PDF veya TIFF | Sabit sayfa düzeni sayfaları veya TIFF görüntüleri | Görüntüleme, yazdırma ve arşivleme |
| PNG, JPEG veya SVG | Tek bir slaydın render edilmiş temsili | Küçük resimler, önizlemeler ve görsel varlıklar |
| HTML veya HTML5 | Web odaklı sunum çıktısı | Tarayıcıda görüntüleme ve web yayımlama |

PPT ve PPTX'ye kıyasla, XML çıktısı öncelikle denetim ve veri odaklı iş akışları için tasarlanmıştır. PDF, TIFF, HTML ve slayt görüntü formatlarından farklı olarak, slaytları sayfa ya da görsel varlık olarak render etmek yerine sunum verilerini temsil eder. [Desteklenen dosya formatları](/slides/tr/net/supported-file-formats/) tablosu, Aspose.Slides'in yükleyebildiği, içe aktarabildiği, kaydedebildiği veya render edebildiği tüm formatları listeler.

## **SSS**

**`SaveFormat.Xml` PPTX dosyası kaydetmeye aynı şey midir?**

Hayır. PPTX, birden fazla Office Open XML parçasını içeren bir paket iken, `SaveFormat.Xml` bir PowerPoint XML Sunumu dosyası oluşturur.

**XML çıktısını disk üzerinde bir dosya oluşturmadan kaydedebilir miyim?**

Evet. Yazılabilir bir akışı [Presentation.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) metoduna aktarın. Örneğin, bellek içi işleme için bir [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) kullanabilirsiniz.

**Aspose.Slides dışa aktarılan XML dosyasını tekrar yükleyebilir mi?**

Evet. XML dosyasını veya bir akışı [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/presentation/) yapıcısına (constructor) aktarın. [Presentation.SourceFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/sourceformat/) ardından `SourceFormat.Xml` döndürür. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/tr/net/aspose.slides/presentationfactory/getpresentationinfo/) bu format için `LoadFormat.Unknown` bildirir, bu yüzden bir XML dosyasının açılıp açılamayacağını karar vermek için bunu kullanmayın.

**XML dönüşümü her slaytı bir sayfa ya da görüntü olarak render eder mi?**

Hayır. XML dönüşümü yapılandırılmış sunum verileri yazar. Sayfa odaklı çıktı için PDF veya TIFF, tek tek slayt görüntüleri için ise PNG, JPEG ve SVG kullanın.