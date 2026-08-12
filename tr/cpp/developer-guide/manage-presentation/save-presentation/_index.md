---
title: C++'ta Sunumları Kaydet
linktitle: Sunumu Kaydet
type: docs
weight: 80
url: /tr/cpp/save-presentation/
keywords:
- PowerPoint'i kaydet
- OpenDocument'i kaydet
- sunumu kaydet
- slaytı kaydet
- PPT'yi kaydet
- PPTX'i kaydet
- ODP'yi kaydet
- sunumu dosyaya
- sunumu akışa
- önceden tanımlı görünüm türü
- Kesin Office Open XML Biçimi
- Zip64 modu
- küçük resmi yenileme
- kaydetme ilerlemesi
- C++
- Aspose.Slides
description: "Aspose.Slides kullanarak C++'ta sunumları nasıl kaydedeceğinizi keşfedin—düzenleri, yazı tiplerini ve efektleri koruyarak PowerPoint veya OpenDocument olarak dışa aktarın."
---
## **Genel Bakış**

[**C++'ta Sunumları Açma**](/slides/tr/cpp/open-presentation/) bir sunumu açmak için [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının nasıl kullanılacağını açıklamıştır. Bu makale, sunumların nasıl oluşturulup kaydedileceğini anlatır. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfı bir sunumun içeriğini tutar. Sıfırdan bir sunum oluşturuyor veya mevcut bir sunumu değiştiriyor olun, işiniz bittiğinde onu kaydetmek isteyeceksiniz. Aspose.Slides for C++ ile **dosya**ya ya da **akış**a kaydedebilirsiniz. Bu makale, bir sunumu kaydetmenin farklı yollarını açıklar.

## **Sunumları Dosyalara Kaydet**

Sunumu bir dosyaya kaydetmek için [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının `Save` metodunu çağırın. Metoda dosya adını ve kaydetme biçimini iletin. Aşağıdaki örnek, Aspose.Slides ile bir sunumun nasıl kaydedileceğini gösterir.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>();

// Burada bazı işlemler yapın...
 
// Sunumu bir dosyaya kaydedin.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Sunumları Akışlara Kaydet**

[Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının `Save` metoduna bir çıktı akışı vererek sunumu bir akışa kaydedebilirsiniz. Sunum birçok akış türüne yazılabilir. Aşağıdaki örnekte yeni bir sunum oluşturup bir dosya akışına kaydediyoruz.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Sunumu akışa kaydedin.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **Önceden Tanımlı Görünüm Türüyle Sunumları Kaydet**

Aspose.Slides, oluşturulan sunum açıldığında PowerPoint’in kullandığı başlangıç görünümünü [ViewProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/viewproperties/) sınıfı aracılığıyla ayarlamanıza izin verir. [ViewType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/viewtype/) enum değerlerinden birini kullanarak `set_LastView` metodunu çağırın.

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Sunumları Kesin Office Open XML Biçiminde Kaydet**

Aspose.Slides, bir sunumu Kesin Office Open XML biçiminde kaydetmenize olanak tanır. Kaydederken `PptxOptions` sınıfını kullanıp `Conformance` özelliğini ayarlayın. `Conformance.Iso29500_2008_Strict` değerini ayarlarsanız, çıktı dosyası Kesin Office Open XML biçiminde kaydedilir.

Aşağıdaki örnek bir sunum oluşturup Kesin Office Open XML biçiminde kaydeder.

```cpp
#include <DOM/Presentation.h>
#include <Export/Conformance.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>();

// Sunumu Kesin Office Open XML biçiminde kaydedin.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Sunumları Office Open XML Biçiminde Zip64 Modunda Kaydet**

Office Open XML dosyası, sıkıştırılmamış dosya boyutu, sıkıştırılmış dosya boyutu ve arşiv toplamı için 4 GB (2^32 bayt) limitleri ve en fazla 65 535 (2^16‑1) dosya limiti getiren bir ZIP arşividir. Zip64 biçim uzantıları bu limitleri 2^64’e yükseltir.

[IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) metodu, bir Office Open XML dosyasını kaydederken Zip64 uzantılarını ne zaman kullanacağınızı seçmenize izin verir.

Bu metod şu modlarla kullanılabilir:

- `IfNecessary` yalnızca sunum yukarıdaki sınırlamaları aşıyorsa Zip64 uzantılarını kullanır. Varsayılan moddur.
- `Never` Zip64 uzantılarını asla kullanmaz.
- `Always` her zaman Zip64 uzantılarını kullanır.

Aşağıdaki kod, Zip64 uzantıları etkinleştirilmiş bir PPTX dosyası olarak bir sunumu nasıl kaydedeceğinizi gösterir:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
`Zip64Mode.Never` ile kaydettiğinizde, sunum ZIP32 biçiminde kaydedilemezse bir [PptxException](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pptxexception/) fırlatılır.
{{% /alert %}}

## **Sunumları Office Open XML Biçiminde Sıkıştırma Seviyeleriyle Kaydet**

Büyük sunumlarla çalışırken, dosya boyutu ile işleme süresini dengelemek için sıkıştırma seviyesini ayarlayabilirsiniz. Gereksinimlerinize bağlı olarak daha hızlı işleme ya da daha küçük çıktı dosyaları tercih edebilirsiniz.

Aspose.Slides, Office Open XML biçiminde bir sunumu kaydederken kullanılacak sıkıştırma seviyesini belirlemenize olanak tanıyan [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/) metodunu sağlar.

Mevcut sıkıştırma seviyeleri şunlardır:

- **None**: Sıkıştırma uygulanmaz. Dosyalar olduğu gibi saklanır.
- **Level1**: En düşük sıkıştırma oranıyla en hızlı sıkıştırma.
- **Level2**: **Level1**’e göre biraz daha iyi sıkıştırma oranı, daha hızlı.
- **Level3**: **Level2**’ye göre daha iyi sıkıştırma, işleme süresi orta düzeyde.
- **Level4**: **Level3**’ten daha iyi sıkıştırma.
- **Level5**: **Level4**’e ek olarak daha fazla sıkıştırma, ek işleme süresi.
- **Level6**: İşleme hızı ve dosya boyutu arasında iyi bir denge sunan standart sıkıştırma. *Varsayılan sıkıştırma seviyesidir*.
- **Level7**: **Level6**’dan daha iyi sıkıştırma, daha yavaş işleme.
- **Level8**: **Level7**’den daha iyi sıkıştırma.
- **Level9**: Maksimum sıkıştırma. En küçük dosya boyutunu üretir, ancak en uzun işleme süresine sahiptir.

Aşağıdaki örnek, bir sunumu *sıkıştırma olmadan* PPTX dosyası olarak kaydetmeyi gösterir:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::None);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-out.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

Bu örnek, bir sunumu *maksimum sıkıştırma* ile PPTX dosyası olarak kaydetmeyi gösterir:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::Level9);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-level9.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

## **Küçük Resmi Yenilemeden Sunumları Kaydet**

[PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) metodu, bir sunumu PPTX olarak kaydederken küçük resim oluşturulmasını kontrol eder:

- `true` olarak ayarlanırsa, kaydetme sırasında küçük resim yenilenir. Bu varsayılandır.
- `false` olarak ayarlanırsa, mevcut küçük resim korunur. Sunumda küçük resim yoksa hiç oluşturulmaz.

Aşağıdaki kodda, sunum küçük resmi yenilenmeden PPTX olarak kaydedilir.

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Bu seçenek, PPTX formatında bir sunumu kaydetme süresini azaltmaya yardımcı olur.
{{% /alert %}}

## **Kaydetme İlerleme Güncellemelerini Yüzde Olarak Al**

[IProgressCallback](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iprogresscallback/) arayüzü, [ISaveOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/isaveoptions/) arayüzünün `set_ProgressCallback` metodu ve soyut [SaveOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/saveoptions/) sınıfı üzerinden kullanılır. `set_ProgressCallback` ile bir [IProgressCallback](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iprogresscallback/) uygulaması atayarak kaydetme ilerlemesini yüzde olarak alabilirsiniz.

Aşağıdaki kod parçacıkları, `IProgressCallback` nasıl kullanılacağını gösterir.

```cpp
#include <IProgressCallback.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        // Burada ilerleme yüzde değerini kullanın.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <IProgressCallback.h>
#include <system/console.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Yukarıda tanımlanan ilerleme geri çağırma sınıfı.
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Aspose, kendi API’sını kullanarak **Ücretsiz PowerPoint Bölücü** uygulaması geliştirmiştir ([https://products.aspose.app/slides/tr/splitter](https://products.aspose.app/slides/tr/splitter)). Bu uygulama, seçilen slaytları yeni PPTX veya PPT dosyaları olarak kaydederek bir sunumu birden fazla dosyaya bölmenizi sağlar.
{{% /alert %}}

## **SSS**

**“Hızlı kaydet” (artımlı kaydet) destekleniyor mu, böylece yalnızca değişiklikler mi yazılıyor?**

Hayır. Kaydetme her seferinde tam hedef dosyasını oluşturur; artımlı “hızlı kaydet” desteklenmez.

**Aynı Presentation örneğini birden fazla thread’den kaydetmek güvenli mi?**

Hayır. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) örneği **thread‑safe değildir** (/slides/tr/cpp/multithreading/); tek bir thread’den kaydedin.

**Kaydederken köprüler ve harici bağlı dosyalar ne olur?**

[Hyperlinkler](/slides/tr/cpp/manage-hyperlinks/) korunur. Harici bağlı dosyalar (örneğin göreceli yollarla eklenen videolar) otomatik olarak kopyalanmaz—referans verilen yolların erişilebilir olduğundan emin olun.

**Belge meta verilerini (Yazar, Başlık, Şirket, Tarih) ayarlayıp/ kaydedebilir miyim?**

Evet. Standart [belge özellikleri](/slides/tr/cpp/presentation-properties/) desteklenir ve kaydetme sırasında dosyaya yazılır.