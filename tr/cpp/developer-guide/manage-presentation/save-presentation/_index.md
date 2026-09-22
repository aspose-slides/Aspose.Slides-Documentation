---
title: C++'ta Sunumları Kaydet
linktitle: Sunumu Kaydet
type: docs
weight: 80
url: /tr/cpp/save-presentation/
keywords:
- PowerPoint kaydet
- OpenDocument kaydet
- sunumu kaydet
- slaytı kaydet
- PPT kaydet
- PPTX kaydet
- ODP kaydet
- dosyaya sunum
- akışa sunum
- önceden tanımlı görünüm türü
- Katı Office Open XML Biçimi
- Zip64 modu
- küçük resmi yenileme
- kaydetme ilerlemesi
- C++
- Aspose.Slides
description: "Aspose.Slides kullanarak C++'ta PowerPoint ve OpenDocument sunumlarını dosyalara veya akışlara kaydedin ve PPTX çıktısını ve ilerleme raporlamasını yapılandırın."
---
## **Genel Bakış**

Sunum oluşturduktan veya [var olan bir sunumu açtıktan](/slides/tr/cpp/open-presentation/) sonra, sonucu yazmak için [Presentation::Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/save/) metodunu kullanın. Aspose.Slides for C++ bir sunumu PowerPoint, OpenDocument, PDF ve diğer biçimlerde bir dosyaya veya akışa kaydedebilir. Aşağıdaki bölümler standart kaydetme işlemlerini ve PPTX çıktısı için mevcut seçenekleri kapsar.

## **Sunumları Dosyalara Kaydet**

Bir sunumu bir dosyaya kaydetmek için, çıkış yolunu ve bir [SaveFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/saveformat/) değerini [Presentation::Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/save/) metoduna geçirin. Biçim değeri, Aspose.Slides'in oluşturduğu dosya türünü belirler.

Aşağıdaki örnek bir sunum oluşturur ve PPTX dosyası olarak kaydeder:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

// Sunum içeriğini buraya ekleyin veya değiştirin.

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Sunumları Orijinal Biçimlerinde Kaydet**

[Orijinal Sunum Biçimini Belirleme](/slides/tr/cpp/detect-presentation-source-format/) örnekleri, yeni oluşturulan sunumların davranışı ve kaynak ile çıktı biçimleri arasındaki fark için bakınız.

Batch işleme uygulamasında, giriş biçimi önceden bilinmeyebilir. Bir dosya yüklendikten sonra, orijinal biçimini [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/get_sourceformat/) ile okuyun. Oluşan [SourceFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/sourceformat/) değerini [SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides.util/slideutil/tosaveformat/) metoduna geçirin, karşılık gelen [SaveFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/saveformat/) değerini elde edin ve ardından [Presentation::Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/save/) ile değiştirilen sunumu yazın.

Aşağıdaki tam örnek, bir giriş klasöründeki her dosyayı işler, başlığını günceller ve yüklendiği biçimde bir çıktı klasörüne kaydeder:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;
using namespace System::IO;

String inputDirectory = u"Input";
String outputDirectory = u"Output";

Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory);
for (const auto& inputPath : inputPaths)
{
    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);

        auto sourceFormat = presentation->get_SourceFormat();
        auto saveFormat = SlideUtil::ToSaveFormat(sourceFormat);

        presentation->get_DocumentProperties()->set_Title(u"Processed by the batch application");

        auto outputPath = Path::Combine(outputDirectory, Path::GetFileName(inputPath));
        presentation->Save(outputPath, saveFormat);
        presentation->Dispose();
    }
    catch (ArgumentException& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot map the source format of '{0}': {1}", inputPath, exception->get_Message()));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot process '{0}': {1}", inputPath, exception->get_Message()));
    }
}
```

[SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides.util/slideutil/tosaveformat/) PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP ve PowerPoint XML'i ilgili sunum kaydetme biçimlerine eşler. Yalnızca sunum kaynak biçimlerini eşler; PDF, HTML, TIFF veya görseller gibi dışa aktarım biçimlerini seçmek için tasarlanmamıştır. Desteklenmeyen veya geçersiz bir [SourceFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/sourceformat/) değeri geçmek bir [ArgumentException](https://reference.aspose.com/slides/tr/cpp/system/argumentexception/) oluşturur.

Legacy PPT, PPS ve POT dosyaları aynı ikili kapsayıcıyı kullanır. Böyle bir sunum dosya uzantısı olmadan bir akıştan yüklendiğinde bir PPS veya POT dosyası PPT olarak tanımlanabilir. Bu eski alt türleri korumanız gerekiyorsa, orijinal dosya adını veya biçim üst verilerini ayrı olarak saklayın ve çıktı dosya adı ve biçimini seçerken kullanın.

## **Sunumları Akışlara Kaydet**

Bir sunumu son dosya yoluna bağlı olmadan yazmak için, yazılabilir bir [Stream](https://reference.aspose.com/slides/tr/cpp/system.io/stream/) ve bir [SaveFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/saveformat/) değerini [Presentation::Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/save/) metoduna geçirin. Bu yöntem, çıktının bir web hizmetinden döndürülmesi, bir veritabanında saklanması veya bellekte işlenmesi gerektiğinde faydalıdır.

Aşağıdaki örnek yeni bir sunumu bir dosya akışına kaydeder:

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

auto presentation = MakeObject<Presentation>();
auto outputStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

presentation->Save(outputStream, SaveFormat::Pptx);

outputStream->Close();
presentation->Dispose();
```

## **Önceden Tanımlı Görünüm Türüyle Sunumları Kaydet**

PowerPoint'in kaydedilen bir sunumu ilk açtığı görünümü belirtebilirsiniz. Kaydetmeden önce bir [ViewType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/viewtype/) değeriyle [ViewProperties::set_LastView](https://reference.aspose.com/slides/tr/cpp/aspose.slides/viewproperties/set_lastview/) metodunu çağırın.

Aşağıdaki örnek Slide Master görünümünü başlangıç görünümü olarak ayarlar:

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

## **Sunumları Katı Office Open XML Biçiminde Kaydet**

Office Open XML'in Strict profiline uygun bir PPTX dosyası oluşturmak için bir [PptxOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pptxoptions/) örneği oluşturun ve `Conformance::Iso29500_2008_Strict` ile [PptxOptions::set_Conformance](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pptxoptions/set_conformance/) metodunu çağırın. Ardından seçenekleri [Presentation::Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/save/) metoduna geçirin.

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

auto presentation = MakeObject<Presentation>();

presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Sunumları Office Open XML Biçiminde Zip64 Modunda Kaydet**

Standart ZIP arşivi her girişin sıkıştırılmış ve sıkıştırılmamış boyutunu, toplam arşiv boyutunu ve giriş sayısını sınırlar. PPTX bir ZIP arşivi olduğundan, çok büyük bir sunum bu sınırları aşabilir. Zip64 uzantıları uygulanabilir boyut ve giriş sayısı limitlerini yükseltir.

[```PptxOptions::set_Zip64Mode```](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pptxoptions/set_zip64mode/) ile Aspose.Slides'in Zip64 uzantılarını yazıp yazmayacağını kontrol edin:

- `IfNecessary` sunum standart ZIP limitlerini aştığında yalnızca Zip64 kullanır. Bu varsayılan moddur.
- `Never` Zip64 uzantılarını devre dışı bırakır.
- `Always` her zaman Zip64 uzantılarını yazar.

Aşağıdaki örnek çıktıyı her zaman Zip64 uzantılarını etkinleştirir:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_Zip64Mode(Zip64Mode::Always);

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="warning" title="Warning" %}}
`Zip64Mode` `Never` olarak ayarlanırsa ve sunum standart ZIP limitlerine sığmazsa, kaydetme işlemi bir [PptxException](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pptxexception/) fırlatır.
{{% /alert %}}

## **Sunumları Office Open XML Biçiminde Sıkıştırma Seviyeleriyle Kaydet**

PPTX çıktısı için [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/) metodunu çağırarak kaydetme hızını dosya boyutuna göre dengeleyebilirsiniz. [CompressionLevel](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/compressionlevel/) enum\'u şu değerleri sağlar:

- `None` veriyi sıkıştırma olmadan depolar.
- `Level1` en hızlı sıkıştırmayı ve en büyük sıkıştırılmış çıktıyı sağlar.
- `Level2`‑`Level5` daha küçük çıktıyı kaydetme hızı pahasına tercih eder.
- `Level6` kaydetme hızı ve dosya boyutunu dengeler. Bu varsayılan düzeydir.
- `Level7` ve `Level8` daha küçük çıktıyı daha fazla tercih eder.
- `Level9` en güçlü sıkıştırmayı sağlar ve en çok işlem süresi gerektirir.

Aşağıdaki örnek bir sunumu sıkıştırma olmadan kaydeder:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::None);

presentation->Save(u"OutputNoCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

Aşağıdaki örnek en yüksek sıkıştırma seviyesini kullanır:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::Level9);

presentation->Save(u"OutputMaximumCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Sunumları Küçük Resmi Yenilemeksizin Kaydet**

Bir sunum PPTX olarak kaydedildiğinde, [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) belge küçük resmini kontrol eder:

- `true` kaydetme sırasında küçük resmi yeniden oluşturur. Bu varsayılan değerdir.
- `false` mevcut küçük resmi korur. Sunumda küçük resim yoksa Aspose.Slides bir tane oluşturmaz.

Aşağıdaki örnek bir sunumu küçük resmini yenilemeden kaydeder:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_RefreshThumbnail(false);

presentation->Save(u"Output.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Küçük resim yenilemenin devre dışı bırakılması, bir PPTX dosyasının kaydedilme süresini azaltabilir.
{{% /alert %}}

## **Kaydetme İlerleme Güncellemelerini Yüzde Olarak Al**

Kaydetme işlemini izlemek için [IProgressCallback](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iprogresscallback/) arayüzünü uygulayın ve uygulamayı [ISaveOptions::set_ProgressCallback](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/isaveoptions/set_progresscallback/) metoduna geçirin. Aspose.Slides, dışa aktarım sırasında ilerleme değerleriyle [IProgressCallback::Reporting](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iprogresscallback/reporting/) metodunu çağırır.

Aşağıdaki örnek PDF dışa aktarımının ilerlemesini konsola bildirir:

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

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);
        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto options = MakeObject<PdfOptions>();
options->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Aspose, Aspose.Slides API ile oluşturulmuş ücretsiz bir [PowerPoint Splitter](https://products.aspose.app/slides/tr/splitter) sunar. Bu araç, bir sunumdan seçili slaytları ayrı PPT veya PPTX dosyaları olarak kaydeder.
{{% /alert %}}

## **Sık Sorulan Sorular**

**Aspose.Slides artımlı veya “hızlı kayıt” özelliğini destekliyor mu?**

Hayır. Her kaydetme işlemi yalnızca değişen bölümleri güncellemek yerine tam bir çıktı dosyası yazar.

**Birden fazla iş parçacığı aynı [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) örneğini kaydedebilir mi?**

Hayır. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) örneği [çok iş parçacıklı değildir](/slides/tr/cpp/multithreading/). Her bir örneğe aynı anda yalnızca bir iş parçacığından erişin ve kaydedin.

**Bir sunumu kaydettiğimde hiperlinkler ve dışarıdan bağlanan dosyalar ne olur?**

[Hiperlinkler](/slides/tr/cpp/manage-hyperlinks/) sunumda kalır. Aspose.Slides dışarıdan bağlanan dosyaları kopyalamaz, bu yüzden kaydedilen sunum hâlâ bu dosyaların konumlarına erişebilmelidir.

**Yazar, başlık, şirket ve oluşturma tarihi gibi belge meta verilerini kaydedebilir miyim?**

Evet. Kaydetmeden önce uygun [belge özelliklerini](/slides/tr/cpp/presentation-properties/) ayarlayın ve Aspose.Slides bunları çıktı dosyasına yazar.