---
title: C++'ta Sunum Uyarılarını İşlemek
type: docs
weight: 70
url: /tr/cpp/presentation-warnings/
aliases:
- /cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- uyarı geri çağırması
- uyarı politikası
- veri kaybı
- kaynak bozulması
- uyumluluk sorunu
- yazı tipi ikamesi
- dijital imza
- sunum yükleme
- sunum renderleme
- sunum dönüşümü
- sunum kaydetme
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile sunumları yüklerken, renderlerken, dönüştürürken ve kaydederken uyarıları toplama, sınıflandırma ve bunlara göre işlem yapma konusunda bilgi edinin."
---
## **Genel Bakış**

Aspose.Slides, bir sunumu yüklerken, işlerken, dönüştürürken veya kaydederken kurtarılabilir sorunları raporlayabilir. Örnekler arasında hasar görmüş kaynak kayıtları, korunamayan içerik, yazı tipi ikamesi ve hedef formatın sınırlamaları bulunur. Bir uyarı geri çağırma (callback) uygulamanın bu koşulları kaydetmesine ve geçerli işlemin devam edip etmeyeceğine karar vermesine olanak tanır.

İlgili [IWarningCallback](https://reference.aspose.com/slides/tr/cpp/aspose.slides.warnings/iwarningcallback/) arayüzünü uygulayın ve [IWarningInfo](https://reference.aspose.com/slides/tr/cpp/aspose.slides.warnings/iwarninginfo/) üzerinden sağlanan [IWarningInfo::get_WarningType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.warnings/iwarninginfo/get_warningtype/) ve [IWarningInfo::get_Description](https://reference.aspose.com/slides/tr/cpp/aspose.slides.warnings/iwarninginfo/get_description/) yöntemlerini inceleyin. Uyarıyı kabul etmek için [ReturnAction::Continue](https://reference.aspose.com/slides/tr/cpp/aspose.slides.warnings/returnaction/) döndürün veya işlemi durdurmak için `ReturnAction::Abort` döndürün.

Bir sunumu açarken ortaya çıkan uyarılar için [LoadOptions::set_WarningCallback](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_warningcallback/) kullanın. Renderleme ve dışa aktarma seçenek sınıfları, slayt renderleme, dönüşüm ve kaydetme sırasında uyarıları alan [SaveOptions::set_WarningCallback](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/saveoptions/set_warningcallback/) miras alır. Uyarı kendisi uygulama işlemini tanımlamadığından, birleşik bir rapor oluştururken her geri çağırma örneğini bir işlem aşamasıyla ilişkilendirin.

## **Uyarılar ve İstisnalar**

Bir uyarı, geri çağırma `ReturnAction::Continue` döndürdüğünde Aspose.Slides'ın kurtarabileceği bir durumu tanımlar. Bir istisna, istenen işlemin normal olarak tamamlanamayacağını ifade eder; istisnalar uyarılara dönüştürülmez ve bir uyarı politikasıyla ele alınamaz.

`ReturnAction::Abort` döndürmek, uyarı dağıtıcısına bir istisna yükselterek geçerli işlemi sonlandırmasını söyler. Ortaya çıkan istisna, işleme ve sunum formatına bağlıdır. Örneğin, yükleme sırasında bir [PptxReadException](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pptxreadexception/) veya [PptReadException](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pptreadexception/) oluşabilir; kaydetme veya dışa aktarma sırasında ise bir [PptxException](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pptxexception/) ortaya çıkabilir. İstisnayı işlemin sınırında yakalayın ve bir istisna alt türüne veya mesajına güvenmek yerine, uygulama politikasının sonlandırmaya sebep olup olmadığını belirlemek için uyarı raporunu kullanın. Geri çağırma, `ReturnAction::Abort` döndürmeden önce uyarıyı kaydeder ve böylece neden uygulama tarafından erişilebilir olur.

## **Uyarı Kategorileri**

[WarningType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.warnings/warningtype/) adlı enum aşağıdaki kategorileri sağlar:

| Uyarı tür | Anlam | Tipik politika |
| --- | --- | --- |
| `SourceFileCorruption` | Kaynak sunum, özgün formatında kaydedilen belgenin kullanılamaz hale gelmesine neden olabilecek bozulma içerir. | İptal. |
| `DataLoss` | Yükleme veya kaydetme sonrasında metin, grafik, resim veya diğer veriler eksik olabilir. | İptal. |
| `MajorFormattingLoss` | Sunum önemli biçimlendirmeyi kaybedebilir. | Sıkı doğrulama modunda iptal; aksi takdirde kaydet ve devam et. |
| `MinorFormattingLoss` | Sınırlı bir biçimlendirme farkı oluşabilir. | Teşhis amacıyla kaydet ve devam et. |
| `CompatibilityIssue` | Sonuç bazı uygulamalarda veya eski sürümlerde açılmayabilir veya doğru davranmayabilir. | Uyumluluk zorunlu değilse kaydet ve devam et. |
| `UnexpectedContent` | Kaynak, desteklenmeyen veya tanınmayan bir içerik içerir ve etkisi henüz bilinmemektedir. | Kaydet ve devam et, veya sıkı bir politikada hatalı olarak değerlendir. |

Kategori, politika kararını yönlendirmelidir. Uyarı açıklamasını teşhis amacıyla saklayın, ancak mesaj metni uyarı senaryoları ve ürün sürümleri arasında değişebileceği için uygulama mantığında metne bağlı olmayın.

## **Uyarıları Topla ve Sınıflandır**

Aşağıdaki örnek, tam işlem hattı için tek bir uygulama düzeyi rapor kullanır. Ayrı bir geri çağırma örneği, yükleme, renderleme, PDF dönüşümü ve PPTX kaydetme sırasında oluşan uyarıları etiketler. Politika, kaynak bozulması veya veri kaybında iptal eder, isteğe bağlı olarak büyük biçimlendirme kaybında da iptal eder ve diğer uyarılar için devam eder.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/PptxOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/scope_guard.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <memory>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

struct WarningEntry
{
    String Stage;
    WarningType Type;
    String Description;
};

class WarningReport
{
public:
    const std::vector<WarningEntry>& GetEntries() const
    {
        return entries;
    }

    void Add(const String& stage, const SharedPtr<IWarningInfo>& warning)
    {
        entries.push_back({stage, warning->get_WarningType(), warning->get_Description()});
    }

private:
    std::vector<WarningEntry> entries;
};

class WarningPolicy
{
public:
    explicit WarningPolicy(bool abortOnMajorFormattingLoss)
        : abortOnMajorFormattingLoss(abortOnMajorFormattingLoss)
    {
    }

    ReturnAction GetAction(WarningType warningType) const
    {
        if (warningType == WarningType::SourceFileCorruption || warningType == WarningType::DataLoss)
        {
            return ReturnAction::Abort;
        }

        if (warningType == WarningType::MajorFormattingLoss && abortOnMajorFormattingLoss)
        {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }

private:
    bool abortOnMajorFormattingLoss;
};

class ReportingWarningCallback : public IWarningCallback
{
public:
    ReportingWarningCallback(const String& stage, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
        : stage(stage), report(report), policy(policy)
    {
    }

    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        report->Add(stage, warning);
        return policy.GetAction(warning->get_WarningType());
    }

private:
    String stage;
    std::shared_ptr<WarningReport> report;
    WarningPolicy policy;
};

class PresentationWarningExample
{
public:
    static void Run()
    {
        auto report = std::make_shared<WarningReport>();
        auto policy = WarningPolicy(true);
        auto completed = ProcessPresentation(u"input.pptx", report, policy);

        Console::WriteLine(completed ? u"Processing completed." : u"Processing stopped.");

        for (const auto& entry : report->GetEntries())
        {
            Console::WriteLine(u"[{0}] {1}: {2}", entry.Stage, entry.Type, entry.Description);
        }
    }

private:
    static bool ProcessPresentation(const String& inputPath, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto loadOptions = MakeObject<LoadOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Loading", report, policy);
            loadOptions->set_WarningCallback(callback);

            auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
            auto cleanup = MakeScopeGuard([&presentation] { presentation->Dispose(); });

            if (!RenderFirstSlide(presentation, report, policy))
            {
                return false;
            }

            if (!ConvertToPdf(presentation, report, policy))
            {
                return false;
            }

            return SaveValidatedCopy(presentation, report, policy);
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Loading stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool RenderFirstSlide(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            if (presentation->get_Slides()->get_Count() == 0)
            {
                Console::WriteLine(u"Rendering stopped: the presentation has no slides.");
                return false;
            }

            auto options = MakeObject<RenderingOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Rendering", report, policy);
            options->set_WarningCallback(callback);

            auto image = presentation->get_Slide(0)->GetImage(options);
            auto cleanup = MakeScopeGuard([&image] { image->Dispose(); });
            image->Save(u"slide-1.png", ImageFormat::Png);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Rendering stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool ConvertToPdf(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PdfOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Conversion", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"converted.pdf", SaveFormat::Pdf, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Conversion stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool SaveValidatedCopy(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PptxOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Saving", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"validated-output.pptx", SaveFormat::Pptx, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Saving stopped: {0}", exception->get_Message());
            return false;
        }
    }
};

PresentationWarningExample::Run();
```

Büyük biçimlendirme farkları kabul edilebilir olduğunda `abortOnMajorFormattingLoss` değerini `false` olarak ayarlayın. İşlem devam etse bile uyumluluk sorunları, küçük biçimlendirme kaybı ve beklenmeyen içerik raporda tutulur. Uygulama bu kategorilerin herhangi birini reddetmek zorundaysa `WarningPolicy::GetAction` metodunu genişletin.

## **Yaygın Uyarı Senaryoları**

Uyarılar, bir çalışma akışının farklı aşamalarında ortaya çıkabilir:

- **Dijital imzalar:** İmzalı bir sunum, işlem sırasında imzasının kaybolacağı uyarısını yükleme sırasında üretebilir. Aspose.Slides bu `DataLoss` durumunu [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/tr/cpp/aspose.slides.warnings/ipresentationsignedwarninginfo/) aracılığıyla raporlar. Yükleme aşamasındaki geri çağırma, uygulamanın dosyayı reddetmesine veya bildirilen kaybı açıkça kabul etmesine olanak tanır.
- **Yazı tipi ikamesi:** Kullanılamayan bir yazı tipi, bir slayt renderlenirken veya dışa aktarılırken değiştirilebilir. Yazı tipi ikamesi uyarıları `DataLoss` olarak raporlanır, bu yüzden yukarıdaki katı politika, uygulama belirli bir ikameyi görsel olarak kabul etse bile iptal eder. Bu davranışı gözlemlemek için, çalışma zamanında bulunmayan bir yazı tipinde metin içeren bir giriş sunumu kullanın. Uyarı açıklaması ikameyi belirtir; yeniden denemeden önce gerekli yazı tiplerini veya [yazı tipi ikame kuralları](/slides/tr/cpp/font-substitution/) yapılandırın.
- **Desteklenmeyen veya beklenmeyen içerik:** Bir yükleyici, tanımadığı sunum kayıtları veya özelliklerle karşılaşabilir. Bu tür uyarılar `UnexpectedContent` veya veri/biçimlendirme etkilendiği biliniyorsa daha ciddi bir kategori kullanabilir.
- **Format uyumluluğu:** Başka bir sunum formatına kaydetmek, bazı özellikleri atlayabilir veya bazı uygulamalarda farklı davranan bir sonuç üretebilir. Örneğin, sekizden fazla yatay ya da sekizden fazla dikey çizim rehberi içeren bir sunumu eski PPT formatına kaydetmek `CompatibilityIssue` rapor eder. Kaydetme aşamasındaki geri çağırma kaybı kaydedebilir ve devam edebilir, ya da tüm rehberlerin korunması gerekiyorsa reddedebilir.
- **Yükleme davranışı:** Yükleme seçenekleri ve eski davranışlar da uyarı üretebilir. Örneğin, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/tr/cpp/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) eski bir sunum kilitleme davranışının kullanımını `CompatibilityIssue` olarak tanımlar.

Uyarılar, kaynak belge, hedef format, işlem ve Aspose.Slides sürümüne bağlıdır. Her dosyanın uyarı üreteceğini veya bir senaryonun daima tek bir kategoriye karşılık geleceğini varsaymayın.

## **İptal Edilen İşlemleri Güvenli Şekilde Ele Al**

Bir geri çağırma `ReturnAction::Abort` döndürdüğünde, yüklenmesi başarısız olan bir nesneyi kullanmayın ve bir renderleme veya kaydetme çıktısının tamamlandığını varsaymayın. İşlem, çıktı dosyasını oluşturduktan ancak tamamlamadan önce sonlandırılabilir.

Doğrulanmış sonuçları `validated-output.pptx` gibi ayrı bir yol altında kaydedin. İşlem başarılı bir şekilde tamamlandıktan, uyarı raporu uygulama politikasını karşıladıktan ve çıktı açılıp kontrol edilebildikten sonra mevcut bir sunumu değiştirin. Bu, geçerli bir kaynak dosyanın kısmi veya reddedilmiş bir sonuçla üzerine yazılmasını önler.

Boş bir uyarı raporu, her kaynak özelliğin korunduğunun garantisi değildir. Uygulamanın gerektirdiği ek içerik ve görsel kontrolleri uygulayın. Ayrıca [Sunumları Aç](/slides/tr/cpp/open-presentation/) ve [Sunumları Kaydet](/slides/tr/cpp/save-presentation/) bölümlerine bakın.

## **SSS**

**Bir uyarı geri çağırması her Aspose.Slides hatasını ele alabilir mi?**  
Hayır. Yalnızca uyarı olarak raporlanan kurtarılabilir durumları ele alır. Geri çağırmadan bağımsız olarak ortaya çıkan istisnalar, yükleme, renderleme, dönüşüm veya kaydetme çağrısı etrafında uygulama tarafından ele alınmalıdır.

**`ReturnAction::Continue` döndürmek aynı çıktıyı garanti eder mi?**  
Hayır. Sadece işleme devam edilmesini sağlar. Raporlanan durum hâlâ veri, biçimlendirme veya uyumluluk farklılıklarına yol açabilir; bu yüzden toplanan uyarı türlerini ve açıklamalarını gözden geçirin.

**Bir uygulama, uyarıyı üreten işlemi nasıl tanımlayabilir?**  
Her işlem için bir geri çağırma örneği oluşturun ve örnekte gösterildiği gibi uyarı türü ve açıklamasıyla birlikte uygulama tanımlı bir aşamayı saklayın.