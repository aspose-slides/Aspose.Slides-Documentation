---
title: C++'ta Sunumları Kaydetme
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
- dosyaya sunum
- akışa sunum
- önceden tanımlı görünüm türü
- Katı Office Open XML Formatı
- Zip64 modu
- küçük resmi yenileme
- kaydetme ilerlemesi
- C++
- Aspose.Slides
description: "Aspose.Slides kullanarak C++'ta sunumları nasıl kaydedeceğinizi keşfedin—düzenleri, yazı tiplerini ve efektleri koruyarak PowerPoint veya OpenDocument olarak dışa aktarın."
---
## **Genel Bakış**

[C++'ta Sunumları Aç](/slides/tr/cpp/open-presentation/) sunumun nasıl açılacağını [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfı ile nasıl kullanılacağını açıkladı. Bu makale, nasıl sunum oluşturulur ve kaydedilir açıklamaktadır. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfı bir sunumun içeriğini içerir. Sıfırdan bir sunum oluşturuyor ya da mevcut bir sunumu değiştiriyor olun, işiniz bittiğinde onu kaydetmek isteyeceksiniz. Aspose.Slides for C++ ile bir **dosya** veya **akış** kaydedebilirsiniz. Bu makale, bir sunumu kaydetmenin farklı yollarını açıklamaktadır.

## **Sunumları Dosyalara Kaydetme**

Bir sunumu, [Presentation] sınıfının `Save` metodunu çağırarak dosyaya kaydedin. Metoda dosya adını ve kaydetme biçimini geçirin. Aşağıdaki örnek, Aspose.Slides ile bir sunumu nasıl kaydedeceğinizi göstermektedir.

```cpp
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>();

// Burada bazı işlemler yapın...
// Sunumu bir dosyaya kaydedin.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Sunumları Akışa Kaydetme**

Bir sunumu, çıktıyı bir akışa geçirerek [Presentation] sınıfının `Save` metoduyla akışa kaydedebilirsiniz. Bir sunum birçok akış türüne yazılabilir. Aşağıdaki örnekte yeni bir sunum oluşturup bir dosya akışına kaydediyoruz.

```cpp
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Sunumu akışa kaydedin.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **Önceden Tanımlı Görünüm Türüyle Sunumları Kaydetme**

Aspose.Slides, oluşturulan sunum açıldığında PowerPoint'in kullandığı başlangıç görünümünü [ViewProperties] sınıfı aracılığıyla ayarlamanıza izin verir. [set_LastView] metodunu [ViewType] enumarasyonundan bir değerle kullanın.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Sunumları Katı Office Open XML Biçiminde Kaydetme**

Aspose.Slides, bir sunumu Katı Office Open XML formatında kaydetmenize olanak tanır. Kaydederken [PptxOptions] sınıfını kullanın ve onun conformance özelliğini ayarlayın. `Conformance.Iso29500_2008_Strict` ayarlarsanız, çıktı dosyası Katı Office Open XML formatında kaydedilir.

Aşağıdaki örnek bir sunum oluşturur ve onu Katı Office Open XML formatında kaydeder.

```cpp
auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>();

// Sunumu Katı Office Open XML formatında kaydedin.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Zip64 Modunda Office Open XML Formatında Sunumları Kaydetme**

Bir Office Open XML dosyası, herhangi bir dosyanın sıkıştırılmamış boyutu, sıkıştırılmış boyutu ve arşivin toplam boyutu için 4 GB (2^32 bayt) sınırlaması getiren bir ZIP arşividir ve ayrıca arşivi 65 535 (2^16‑1) dosyayla sınırlar. ZIP64 format uzantıları bu sınırları 2^64’e yükseltir.

[IPptxOptions::set_Zip64Mode] yöntemi, bir Office Open XML dosyası kaydederken ZIP64 format uzantılarının ne zaman kullanılacağını seçmenizi sağlar.

Bu yöntem aşağıdaki modlarla kullanılabilir:

- `IfNecessary` yalnızca sunum yukarıdaki sınırlamaları aşarsa ZIP64 format uzantılarını kullanır. Bu varsayılan moddur.
- `Never` ZIP64 format uzantılarını hiç kullanmaz.
- `Always` her zaman ZIP64 format uzantılarını kullanır.

Aşağıdaki kod, ZIP64 format uzantıları etkinleştirilmiş bir PPTX olarak bir sunumun nasıl kaydedileceğini gösterir:

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
`Zip64Mode.Never` ile kaydettiğinizde, sunum ZIP32 formatında kaydedilemezse bir [PptxException] istisnası fırlatılır.
{{% /alert %}}

## **Küçük Resmi Yenilemeden Sunumları Kaydetme**

[PptxOptions::set_RefreshThumbnail] metodu, bir sunumu PPTX olarak kaydederken küçük resim (thumbnail) oluşturulmasını kontrol eder:

- `true` olarak ayarlanırsa, kaydetme sırasında küçük resim yenilenir. Bu varsayılandır.
- `false` olarak ayarlanırsa, mevcut küçük resim korunur. Sunumda küçük resim yoksa, hiç oluşturulmaz.

Aşağıdaki kodda, sunum küçük resmi yenilenmeden PPTX olarak kaydedilir.

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Bu seçenek, PPTX formatında bir sunumu kaydetme süresini azaltmaya yardımcı olur.
{{% /alert %}}

## **Kaydetme İlerleme Güncellemelerini Yüzde Olarak Almak**

[IProgressCallback] arabirimi, [ISaveOptions] arabirimi ve soyut [SaveOptions] sınıfı tarafından sunulan `set_ProgressCallback` yöntemi aracılığıyla kullanılır. `set_ProgressCallback` ile bir [IProgressCallback] uygulaması atayarak kaydetme ilerlemesi güncellemelerini yüzde olarak alabilirsiniz.

Aşağıdaki kod parçacıkları, `IProgressCallback` kullanımını göstermektedir.

```cpp
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue)
    {
        // Burada ilerleme yüzde değerini kullanın.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Aspose, kendi API'sini kullanarak bir [ücretsiz PowerPoint Splitter uygulaması] geliştirdi. Uygulama, seçilen slaytları yeni PPTX veya PPT dosyaları olarak kaydederek bir sunumu birden çok dosyaya bölmenizi sağlar.
{{% /alert %}}

## **SSS**

**"Hızlı kaydetme" (kademeli kaydetme) yalnızca değişikliklerin yazılması destekleniyor mu?**

Hayır. Kaydetme her seferinde tam hedef dosyasını oluşturur; kademeli “hızlı kaydetme” desteklenmez.

**Aynı Presentation örneğini birden çok thread'ten kaydetmek güvenli mi?**

Hayır. Bir [Presentation] örneği [thread-safe değildir](/slides/tr/cpp/multithreading/); tek bir thread'ten kaydedin.

**Hipernöbetler ve dışa bağlı dosyalar kaydedildiğinde ne olur?**

[Köprüler](/slides/tr/cpp/manage-hyperlinks/) korunur. Dışarıdan bağlanan dosyalar (ör. göreceli yollarla videolar) otomatik olarak kopyalanmaz—referans verilen yolların erişilebilir olduğundan emin olun.

**Belge meta verilerini (Yazar, Başlık, Şirket, Tarih) ayarlayabilir/kaydedebilir miyim?**

Evet. Standart [doküman özellikleri](/slides/tr/cpp/presentation-properties/) desteklenir ve kaydetme sırasında dosyaya yazılır.