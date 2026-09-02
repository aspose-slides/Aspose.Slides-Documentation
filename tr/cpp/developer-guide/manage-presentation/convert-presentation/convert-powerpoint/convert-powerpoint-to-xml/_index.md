---
title: PowerPoint Sunumlarını C++'ta XML'e Dönüştür
linktitle: PowerPoint'ten XML'e
type: docs
weight: 145
url: /tr/cpp/convert-powerpoint-to-xml/
keywords:
- PowerPoint'i XML'e dönüştür
- sunumu XML'e dönüştür
- PPT'yi XML'e
- PPTX'i XML'e
- ODP'yi XML'e
- PowerPoint XML Sunumu
- SaveFormat::Xml
- sunumu XML olarak kaydet
- sunumu XML'e dışa aktar
- XML akışı
- C++
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını C++ için Aspose.Slides ile PowerPoint XML dosyalarına veya akışlarına dönüştür."
---
## **Genel Bakış**

Aspose.Slides for C++ PowerPoint sunumlarını PowerPoint XML Sunum formatına dönüştürebilir. XML çıktısı, sunum yapısını incelemek, oluşturulan belgelerde sorun gidermek, otomatik testlerde çıktıyı karşılaştırmak veya XML tüketen bir iş akışıyla bütünleştirmek gibi durumlarda metin tabanlı bir temsil gerektiğinde faydalıdır.

[Presentation::Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/save/) metodunu, [SaveFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/saveformat/) enum'undan `Xml` değeriyle kullanın. Sonucu doğrudan bir dosyaya veya bir akışa yazabilirsiniz.

{{% alert color="info" title="Note" %}}

`SaveFormat::Xml` bir PowerPoint XML Sunumu oluşturur. PPTX paketinin içinde depolanan bireysel Office Open XML parçalarını çıkartmaz. Eğer `ppt/presentation.xml` gibi tam PPTX paket parçalarına ihtiyacınız varsa, PPTX paketini kendiniz inceleyin.

{{% /alert %}}

## **Bir Sunumu XML Dosyasına Dönüştürme**

Kaynak bir sunumu [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfı ile yükleyin ve ardından çıktı yolunu ve `SaveFormat::Xml` değerini [Presentation::Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/save/) metoduna geçirin. Kaynak, PPT, PPTX veya ODP gibi desteklenen herhangi bir sunum formatı olabilir.

Aşağıdaki örnek bir PPTX sunumunu XML dosyasına dönüştürür:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.xml", SaveFormat::Xml);
presentation->Dispose();
```

## **XML Çıktısını Bir Akışa Yazma**

XML'in bellekte kalması veya bir web servisi, depolama sağlayıcısı veya XML işleme hattı gibi başka bir bileşene geçirilmesi gerektiğinde [Presentation::Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/save/) metodunun akış aşırı yüklemesini kullanın. Aşağıdaki örnek sonucu bir [MemoryStream](https://reference.aspose.com/slides/tr/cpp/system.io/memorystream/)’e yazar ve sonradan okuma için başa alır:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto xmlStream = System::MakeObject<MemoryStream>();

presentation->Save(xmlStream, SaveFormat::Xml);
xmlStream->set_Position(0);
presentation->Dispose();

// xmlStream'i iş akışındaki bir sonraki bileşene gönder.
```

## **XML'i Sunum ve Dışa Aktarma Biçimleriyle Karşılaştırma**

Sonucun nasıl kullanılacağına göre çıktı biçimini seçin:

| Biçim | Çıktı | Tipik kullanım |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Bir PowerPoint XML Sunumu | Yapıyı inceleme, sorun giderme, oluşturulan çıktıyı karşılaştırma ve XML tabanlı bütünleştirme |
| PPT (`.ppt`) | Eski bir ikili sunum dosyası | Eski PowerPoint iş akışlarıyla uyumluluk |
| PPTX (`.pptx`) | Birden çok parçayı içeren Office Open XML paketi | Normal PowerPoint düzenleme ve sunum değişimi |
| PDF veya TIFF | Sabit sayfa düzeni veya çok sayfalı görüntü | Görüntüleme, yazdırma ve arşivleme |
| PNG, JPEG veya SVG | Tek bir slaytın render edilmiş temsili | Küçük resimler, ön izlemeler ve görsel varlıklar |
| HTML veya HTML5 | Web odaklı sunum çıktısı | Tarayıcıda görüntüleme ve web yayıncılığı |

PPT ve PPTX'den farklı olarak XML çıktısı öncelikle inceleme ve veri odaklı iş akışları için tasarlanmıştır. PDF, TIFF, HTML ve slayt görüntü biçimlerinden farklı olarak sunumu sayfa veya görsel varlık olarak render etmez, sadece sunum verisini temsil eder. [Desteklenen dosya biçimleri](/slides/tr/cpp/supported-file-formats/) tablosu PowerPoint XML Sunumunu yalnızca kaydetme biçimi olarak listeler; bu nedenle bir iş akışının dosyayı tekrar Aspose.Slides ile yüklemesi gerektiğinde kullanmayın.

## **SSS**

**`SaveFormat::Xml` bir PPTX dosyası kaydetmekle aynı şey mi?**

Hayır. PPTX, birden çok Office Open XML parçası içeren bir pakettir, `SaveFormat::Xml` ise bir PowerPoint XML Sunumu dosyası oluşturur.

**XML çıktısını dosya oluşturmadan kaydedebilir miyim?**

Evet. [Presentation::Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/save/) metoduna yazılabilir bir akış geçirin. Örneğin, bellek içinde işleme için bir [MemoryStream](https://reference.aspose.com/slides/tr/cpp/system.io/memorystream/) kullanabilirsiniz.

**Aspose.Slides dışa aktarılan XML dosyasını yeniden yükleyebilir mi?**

Hayır. PowerPoint XML Sunumu şu anda sadece kaydetme için desteklenir, yükleme için değil. Çevrim içi düzenleme gerektiğinde PPTX veya başka bir desteklenen sunum biçimini kullanın.

**XML dönüşümü her slaytı bir sayfa veya görüntü olarak render eder mi?**

Hayır. XML dönüşümü yapılandırılmış sunum verisini yazar. Sayfa odaklı çıktı için PDF veya TIFF, tek slayt görüntüleri için PNG, JPEG ve SVG kullanın.