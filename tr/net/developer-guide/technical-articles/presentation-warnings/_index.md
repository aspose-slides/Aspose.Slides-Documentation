---
title: Sunum Uyarılarını .NET'te Yönet
type: docs
weight: 120
url: /tr/net/presentation-warnings/
aliases:
- /net/uyari-geri-aramasi-yazı-tipi-degistirimi-aspose-slides-icinde/
keywords:
- uyarı geri araması
- uyarı politikası
- veri kaybı
- kaynak bozulması
- uyumluluk sorunu
- yazı tipi değiştirme
- dijital imza
- sunum yükleme
- sunum renderleme
- sunum dönüşümü
- sunum kaydetme
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile sunumları yüklerken, renderlarken, dönüştürürken ve kaydederken uyarıları nasıl toplar, sınıflandırır ve bunlara nasıl müdahale eder öğrenin."
---
## **Genel Bakış**

Aspose.Slides, bir sunumu yüklerken, renderlarken, dönüştürürken veya kaydederken kurtarılabilir sorunları raporlayabilir. Örnekler arasında bozuk kaynak kayıtları, korunamayan içerik, yazı tipi değiştirme ve hedef formatın sınırlamaları bulunur. Bir uyarı callback, bir uygulamanın bu koşulları kaydetmesine ve geçerli işlemin devam edip etmeyeceğine karar vermesine olanak tanır.

Uygulamak için [IWarningCallback](https://reference.aspose.com/slides/tr/net/aspose.slides.warnings/iwarningcallback/) arayüzünü uygulayın ve [IWarningInfo](https://reference.aspose.com/slides/tr/net/aspose.slides.warnings/iwarninginfo/) aracılığıyla sağlanan [WarningType](https://reference.aspose.com/slides/tr/net/aspose.slides.warnings/iwarninginfo/warningtype/) ve [Description](https://reference.aspose.com/slides/tr/net/aspose.slides.warnings/iwarninginfo/description/) özelliklerini inceleyin. Uyarıyı kabul etmek için [ReturnAction.Continue](https://reference.aspose.com/slides/tr/net/aspose.slides.warnings/returnaction/) ve işlemi durdurmak için `ReturnAction.Abort` döndürün.

Bir sunumu açarken ortaya çıkan uyarılar için [LoadOptions.WarningCallback](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/warningcallback/) kullanın. Renderleme ve dışa aktarım seçenek sınıfları, slayt renderlemesi, dönüşüm ve kaydetme sırasında gelen uyarıları alan [SaveOptions.WarningCallback](https://reference.aspose.com/slides/tr/net/aspose.slides.export/saveoptions/warningcallback/) sınıfından miras alır. Uyarı kendi başına uygulama işlemini tanımlamadığından, birleşik bir rapor oluştururken her callback örneğini bir işlem aşamasıyla ilişkilendirin.

## **Uyarılar ve İstisnalar**

Bir uyarı, callback `ReturnAction.Continue` döndürdüğünde Aspose.Slides'in kurtarabileceği bir durumu tanımlar. Bir istisna, istenen işlemin normal olarak tamamlanamayacağını gösterir; istisnalar uyarılara dönüştürülmez ve bir uyarı politikasıyla ele alınamaz.

`ReturnAction.Abort` döndürmek, uyarı dağıtıcısına bir istisna yükselterek geçerli işlemi sonlandırmasını söyler. Ortaya çıkan istisna, işlem ve sunum formatına bağlıdır. Örneğin, yükleme sırasında bir [PptxReadException](https://reference.aspose.com/slides/tr/net/aspose.slides/pptxreadexception/) veya [PptReadException](https://reference.aspose.com/slides/tr/net/aspose.slides/pptreadexception/) görülebilir; kaydetme veya dışa aktarma sırasında ise bir [PptxException](https://reference.aspose.com/slides/tr/net/aspose.slides/pptxexception/) görülebilir. İstisnayı işlemin sınırında yakalayın ve bir uyarı raporunu, uygulama politikasının sonlandırmaya yol açıp açmadığını belirlemek için kullanın; tek bir istisna alt tipi veya mesajına güvenmeyin. Callback, `ReturnAction.Abort` döndürmeden önce uyarıyı kaydeder, böylece neden uygulamaya ulaşabilir durumda kalır.

## **Uyarı Kategorileri**

[WarningType](https://reference.aspose.com/slides/tr/net/aspose.slides.warnings/warningtype/) sayımı aşağıdaki kategorileri sunar:

| Uyarı türü | Anlam | Tipik politika |
| --- | --- | --- |
| `SourceFileCorruption` | Kaynak sunum, orijinal formatında kaydedilen belgenin kullanılamaz hale gelmesine neden olabilecek bozulma içerir. | İptal. |
| `DataLoss` | Yükleme veya kaydetme sonrası metin, grafik, resim veya diğer veriler eksik olabilir. | İptal. |
| `MajorFormattingLoss` | Sunum önemli biçimlendirmeyi kaybedebilir. | Sıkı doğrulama modunda iptal; aksi takdirde kayda al ve devam et. |
| `MinorFormattingLoss` | Sınırlı bir biçimlendirme farkı ortaya çıkabilir. | Teşhis için kayda al ve devam et. |
| `CompatibilityIssue` | Sonuç, bazı uygulamalarda veya eski sürümlerde açılamayabilir veya doğru çalışmayabilir. | Uyumluluk zorunlu değilse günlük kaydına al ve devam et; aksi takdirde iptal. |
| `UnexpectedContent` | Kaynak, desteklenmeyen veya tanınmayan içerik içerir ve etkisi henüz bilinmeyebilir. | Kayda al ve devam et, sıkı bir politikada hata olarak ele al. |

Kategori, politika kararını yönlendirmelidir. Teşhis amacıyla `Description` kaydedin, ancak mesaj metni senaryolar ve ürün sürümleri arasında değişebileceği için uygulama mantığında buna bağlı kalmayın.

## **Uyarıları Topla ve Sınıflandır**

Aşağıdaki örnek, tam işlem hattı için tek bir uygulama‑seviyesi raporu kullanır. Ayrı bir callback örneği, yükleme, renderleme, PDF dönüşümü ve PPTX kaydetme sırasında oluşan uyarıları etiketler. Politika, kaynak bozulması veya veri kaybında iptal eder, isteğe bağlı olarak büyük biçimlendirme kaybında da iptal eder ve diğer uyarılar için devam eder.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

internal static class PresentationWarningExample
{
    public static void Main()
    {
        var report = new WarningReport();
        var policy = new WarningPolicy(abortOnMajorFormattingLoss: true);
        var completed = ProcessPresentation("input.pptx", report, policy);

        Console.WriteLine(completed ? "Processing completed." : "Processing stopped.");

        foreach (var entry in report.Entries)
        {
            Console.WriteLine($"[{entry.Stage}] {entry.Type}: {entry.Description}");
        }
    }

    private static bool ProcessPresentation(string inputPath, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var loadOptions = new LoadOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Loading, report, policy)
            };

            using var presentation = new Presentation(inputPath, loadOptions);

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
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Loading stopped: {exception.Message}");
            return false;
        }
    }

    private static bool RenderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new RenderingOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Rendering, report, policy)
            };

            using var image = presentation.Slides[0].GetImage(options);
            image.Save("slide-1.png", ImageFormat.Png);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Rendering stopped: {exception.Message}");
            return false;
        }
    }

    private static bool ConvertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PdfOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Conversion, report, policy)
            };

            presentation.Save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Conversion stopped: {exception.Message}");
            return false;
        }
    }

    private static bool SaveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PptxOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Saving, report, policy)
            };

            presentation.Save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Saving stopped: {exception.Message}");
            return false;
        }
    }

    private enum OperationStage
    {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private sealed class WarningEntry
    {
        public WarningEntry(OperationStage stage, WarningType type, string description)
        {
            Stage = stage;
            Type = type;
            Description = description;
        }

        public OperationStage Stage { get; }

        public WarningType Type { get; }

        public string Description { get; }
    }

    private sealed class WarningReport
    {
        private readonly List<WarningEntry> _entries = new List<WarningEntry>();

        public IReadOnlyList<WarningEntry> Entries => _entries;

        public void Add(OperationStage stage, IWarningInfo warning)
        {
            _entries.Add(new WarningEntry(stage, warning.WarningType, warning.Description));
        }
    }

    private sealed class WarningPolicy
    {
        private readonly bool _abortOnMajorFormattingLoss;

        public WarningPolicy(bool abortOnMajorFormattingLoss)
        {
            _abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        public ReturnAction GetAction(WarningType warningType)
        {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss)
            {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && _abortOnMajorFormattingLoss)
            {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private sealed class ReportingWarningCallback : IWarningCallback
    {
        private readonly OperationStage _stage;
        private readonly WarningReport _report;
        private readonly WarningPolicy _policy;

        public ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy)
        {
            _stage = stage;
            _report = report;
            _policy = policy;
        }

        public ReturnAction Warning(IWarningInfo warning)
        {
            _report.Add(_stage, warning);
            return _policy.GetAction(warning.WarningType);
        }
    }
}
```

Büyük biçimlendirme farklılıkları kabul edilebilir olduğunda `abortOnMajorFormattingLoss` değerini `false` olarak ayarlayın. Uyumluluk sorunları, küçük biçimlendirme kaybı ve beklenmeyen içerik, işlem devam etse bile raporda tutulur. Uygulama bu kategorilerden birini reddetmek zorundaysa `WarningPolicy.GetAction` yöntemini genişletin.

## **Ortak Uyarı Senaryoları**

Uyarılar bir iş akışının farklı aşamalarında ortaya çıkabilir:

- **Digital signatures:** İmzalı bir sunum, yükleme sırasında işlenirken imzasının kaybolacağı uyarısını üretebilir. Aspose.Slides bu `DataLoss` durumunu [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/tr/net/aspose.slides.warnings/ipresentationsignedwarninginfo/) aracılığıyla raporlar. Yükleme aşamasındaki callback, dosyayı reddetmeye ya da raporlanan kaybı açıkça kabul etmeye olanak tanır.
- **Font substitution:** Kullanılamayan bir yazı tipi, bir slayt renderlenirken veya dışa aktarılırken değiştirilir. Yazı tipi değiştirme uyarıları `DataLoss` olarak raporlanır; bu nedenle yukarıdaki sıkı politika, uygulama görsel olarak kabul edilebilir bir değişikliği dahi iptal eder. Bu davranışı gözlemlemek için çalışma zamanında bulunmayan bir yazı tipi içeren bir sunum kullanın. Uyarı açıklaması değişikliği belirtir; gerekli yazı tiplerini yapılandırın veya [yazı tipi değiştirme kuralları](/slides/tr/net/font-substitution/) uygulamadan önce yeniden deneyin.
- **Unsupported or unexpected content:** Bir yükleyici, tanımadığı sunum kayıtları veya özelliklerle karşılaşabilir. Bu tür uyarılar `UnexpectedContent` ya da veri ve biçimlendirme etkileniyorsa daha ciddi bir kategori kullanabilir.
- **Format compatibility:** Farklı bir sunum formatına kaydetmek, özellikleri atlayabilir veya sonuç bazı uygulamalarda farklı davranabilir. Örneğin, sekizden fazla yatay veya dikey çizim rehberi içeren bir sunumu eski PPT'ye kaydetmek bir `CompatibilityIssue` raporlar. Kaydetme aşamasındaki callback, kaybı kayda alıp devam edebilir veya tüm rehberlerin korunması gerekiyorsa iptal edebilir.
- **Loading behavior:** Yükleme seçenekleri ve eski davranışlar da uyarı üretebilir. Örneğin, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/tr/net/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) eski bir sunum kilitleme davranışının kullanımını `CompatibilityIssue` olarak tanımlar.

Uyarılar, kaynak belge, hedef format, işlem ve Aspose.Slides sürümüne bağlıdır. Her dosyanın uyarı üreteceğini ya da bir senaryonun yalnızca bir kategoriye karşılık geleceğini varsaymayın.

## **İptal Edilen İşlemleri Güvenli Şekilde Ele Al**

Bir callback `ReturnAction.Abort` döndürdüğünde, yüklenemeyen nesneyi kullanmayın ve render ya da kaydetme çıktısının tamamlandığını varsaymayın. İşlem, bir çıktı dosyası oluşturulduktan sonra ancak tamamlanmadan önce sonlanabilir.

Doğrulanmış sonuçları `validated-output.pptx` gibi ayrı bir yol içinde kaydedin. Mevcut bir sunumu yalnızca işlem başarıyla bitince, uyarı raporu uygulama politikasını karşıladığında ve çıktı açılıp kontrol edilebildiğinde değiştirin. Bu, geçerli bir kaynak dosyanın kısmi ya da reddedilmiş bir sonuçla üzerine yazılmasını önler.

Boş bir uyarı raporu, her kaynak özelliğinin korunduğunun garantisi değildir. Uygulamanın gerektirdiği ek içerik ve görsel kontrolleri uygulayın. Ayrıntılar için [Open Presentations](/slides/tr/net/open-presentation/) ve [Save Presentations](/slides/tr/net/save-presentation/) sayfalarına bakın.

## **SSS**

**Bir uyarı callback tüm Aspose.Slides hatalarını işleyebilir mi?**

Hayır. Geri çağırma, uyarı olarak raporlanan kurtarılabilir koşulları işler. Callback'ten bağımsız olarak ortaya çıkan istisnalar, yükleme, renderleme, dönüşüm veya kaydetme çağrısı etrafında uygulama tarafından ele alınmalıdır.

**`ReturnAction.Continue` döndürmek aynı çıktıyı garanti eder mi?**

Hayır. Sadece işlemin devam etmesine izin verir. Raporlanan koşul hâlâ veri, biçimlendirme veya uyumluluk farklarına yol açabilir, bu yüzden toplanan uyarı türlerini ve açıklamaları inceleyin.

**Bir uygulama, uyarıyı üreten işlemi nasıl belirleyebilir?**

Her işlem için bir callback örneği oluşturup, `WarningType` ve `Description` ile birlikte uygulama tanımlı bir aşamayı saklayın, örnekte gösterildiği gibi.