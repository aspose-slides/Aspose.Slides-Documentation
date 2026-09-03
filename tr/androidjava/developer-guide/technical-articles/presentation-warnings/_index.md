---
title: Android'de Sunum Uyarılarını Yönet
type: docs
weight: 90
url: /tr/androidjava/presentation-warnings/
aliases:
- /androidjava/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- uyarı geri çağrısı
- uyarı politikası
- veri kaybı
- kaynak bozulması
- uyumluluk sorunu
- yazı tipi ikamesi
- dijital imza
- sunum yükleme
- sunum işleme
- sunum dönüştürme
- sunum kaydetme
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'ı Java aracılığıyla kullanarak sunumları yüklerken, işlerken, dönüştürürken ve kaydederken uyarıları nasıl toplayacağınızı, sınıflandıracağınızı ve bunlara nasıl müdahale edeceğinizi öğrenin."
---
## **Genel Bakış**

Aspose.Slides, bir sunumu yüklerken, işlerken, dönüştürürken veya kaydederken kurtarılabilir sorunları raporlayabilir. Örnekler arasında bozuk kaynak kayıtları, korunamayan içerik, yazı tipi ikamesi ve hedef formatın sınırlamaları bulunur. Bir uyarı geri çağrısı, uygulamanın bu koşulları kaydetmesine ve geçerli işlemin devam edip etmeyeceğine karar vermesine olanak tanır.

[IWarningCallback](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iwarningcallback/) arabirimini uygulayın ve [IWarningInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iwarninginfo/) aracılığıyla sağlanan [getWarningType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) ve [getDescription](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) değerlerini inceleyin. Uyarıyı kabul etmek için [ReturnAction.Continue](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/returnaction/#Continue) döndürün veya işlemi durdurmak için [ReturnAction.Abort](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/returnaction/#Abort) döndürün.

Bir sunum açılırken ortaya çıkan uyarılar için [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) kullanın. Rendering ve dışa aktarma seçenek sınıfları, slayt işleme, dönüşüm ve kaydetme sırasında uyarıları alan [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) miras alır. Uyarı kendisi uygulama işlemini tanımlamadığı için, birleşik bir rapor oluştururken her geri çağrı örneğini bir işlem aşamasıyla ilişkilendirin.

## **Uyarılar ve İstisnalar**

Bir uyarı, geri çağrı `ReturnAction.Continue` döndürürse Aspose.Slides'ın kurtarabileceği bir durumu tanımlar. Bir istisna, istenen işlemin normal olarak tamamlanamayacağını gösterir; istisnalar uyarılara dönüştürülmez ve bir uyarı politikasıyla ele alınamaz.

`ReturnAction.Abort` döndürmek, uyarı dağıtıcısından bir istisna fırlatarak geçerli işlemi sonlandırmasını ister. Açık istisna, işleme ve sunum formatına bağlıdır. Örneğin, yükleme sırasında bir [PptxReadException](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pptxreadexception/) veya [PptReadException](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pptreadexception/) ortaya çıkabilir, kaydetme veya dışa aktarma sırasında ise bir [PptxException](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pptxexception/) ortaya çıkabilir. İstisnayı işlemin sınırında yakalayın ve bir uyarı raporunu, uygulama politikasının sonlandırmaya neden olup olmadığını belirlemek için kullanın; tek bir istisna alt türüne veya mesajına güvenmek yerine. Geri çağrı, `ReturnAction.Abort` döndürmeden önce uyarıyı kaydeder, böylece neden uygulamaya hâlâ ulaşılabilir.

## **Uyarı Kategorileri**

[WarningType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/warningtype/) sınıfı, aşağıdaki kategoriler için tam sayı sabitleri sağlar:

| Uyarı türü | Anlam | Tipik politika |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/warningtype/#SourceFileCorruption) | Kaynak sunum, özgün formatında kaydedilen belgenin kullanılamaz hale gelmesine neden olabilecek bozulma içerir. | İptal. |
| [DataLoss](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/warningtype/#DataLoss) | Yükleme veya kaydetme sonrasında metin, grafik, resim veya diğer veriler eksik olabilir. | İptal. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/warningtype/#MajorFormattingLoss) | Sunum, önemli biçimlendirmeyi kaybedebilir. | Sıkı doğrulama modunda iptal; aksi takdirde kaydet ve devam et. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/warningtype/#MinorFormattingLoss) | Sınırlı bir biçimlendirme farkı meydana gelebilir. | Tanı amaçlı kaydet ve devam et. |
| [CompatibilityIssue](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/warningtype/#CompatibilityIssue) | Sonuç, bazı uygulamalarda veya eski sürümlerde açılamayabilir veya doğru çalışmayabilir. | Uyumluluk zorunlu değilse kaydet ve devam et. |
| [UnexpectedContent](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/warningtype/#UnexpectedContent) | Kaynak, etkisi henüz bilinmeyen, desteklenmeyen veya tanımlanamayan içerik içerir. | Kaydet ve devam et, ya da sıkı bir politikada hatalı olarak değerlendirin. |

Kategori, politika kararını yönlendirmelidir. Tanı amaçlı [getDescription](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) tarafından döndürülen değeri saklayın, ancak mesaj metni uyarı senaryoları ve ürün sürümleri arasında değişebileceği için uygulama mantığında metnine dayanmayın.

## **Uyarıları Toplama ve Sınıflandırma**

Aşağıdaki örnek, tam işleme hattı için tek bir uygulama seviyesinde rapor kullanır. Ayrı bir geri çağrı örneği, yükleme, işleme, PDF dönüşümü ve PPTX kaydetme sırasında ortaya çıkan uyarıları etiketler. Politika, kaynak bozulması veya veri kaybında iptal eder, isteğe bağlı olarak büyük biçimlendirme kaybında da iptal eder ve diğer uyarılar için devam eder.

`input.pptx` dosyasını yazılabilir bir uygulama dizinine yerleştirin ve bu dizini `PresentationWarningExample.run` metoduna aktarın. Örnek, çıktıları aynı dizine kaydeder. Android kullanıcı arayüzünün yanıt vermeye devam etmesi için sunum işleme işlemini bir arka plan iş parçacığında çalıştırın.

```java
import com.aspose.slides.IImage;
import com.aspose.slides.IWarningCallback;
import com.aspose.slides.IWarningInfo;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import com.aspose.slides.ReturnAction;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.WarningType;
import java.io.File;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class PresentationWarningExample {
    public static void run(File dataDirectory) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        File inputFile = new File(dataDirectory, "input.pptx");
        boolean completed = processPresentation(inputFile.getAbsolutePath(), dataDirectory, report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, dataDirectory, report, policy);
            }
            finally {
                presentation.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Loading stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean renderFirstSlide(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        if (presentation.getSlides().size() == 0) {
            System.err.println("Rendering stopped: the presentation has no slides.");
            return false;
        }

        try {
            RenderingOptions options = new RenderingOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Rendering, report, policy);
            options.setWarningCallback(callback);

            IImage image = presentation.getSlides().get_Item(0).getImage(options);
            try {
                File outputFile = new File(dataDirectory, "slide-1.png");
                image.save(outputFile.getAbsolutePath(), ImageFormat.Png);
                return true;
            }
            finally {
                image.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Rendering stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean convertToPdf(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "converted.pdf");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "validated-output.pptx");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Saving stopped: " + exception.getMessage());
            return false;
        }
    }

    private static String warningTypeName(int warningType) {
        switch (warningType) {
            case WarningType.SourceFileCorruption:
                return "SourceFileCorruption";
            case WarningType.DataLoss:
                return "DataLoss";
            case WarningType.MajorFormattingLoss:
                return "MajorFormattingLoss";
            case WarningType.MinorFormattingLoss:
                return "MinorFormattingLoss";
            case WarningType.CompatibilityIssue:
                return "CompatibilityIssue";
            case WarningType.UnexpectedContent:
                return "UnexpectedContent";
            default:
                return "Unknown (" + warningType + ")";
        }
    }

    private enum OperationStage {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private static final class WarningEntry {
        final OperationStage stage;
        final int type;
        final String description;

        WarningEntry(OperationStage stage, int type, String description) {
            this.stage = stage;
            this.type = type;
            this.description = description;
        }
    }

    private static final class WarningReport {
        private final List<WarningEntry> entries = new ArrayList<WarningEntry>();

        List<WarningEntry> getEntries() {
            return Collections.unmodifiableList(entries);
        }

        void add(OperationStage stage, IWarningInfo warning) {
            WarningEntry entry = new WarningEntry(stage, warning.getWarningType(), warning.getDescription());
            entries.add(entry);
        }
    }

    private static final class WarningPolicy {
        private final boolean abortOnMajorFormattingLoss;

        WarningPolicy(boolean abortOnMajorFormattingLoss) {
            this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        int getAction(int warningType) {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss) {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && abortOnMajorFormattingLoss) {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private static final class ReportingWarningCallback implements IWarningCallback {
        private final OperationStage stage;
        private final WarningReport report;
        private final WarningPolicy policy;

        ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy) {
            this.stage = stage;
            this.report = report;
            this.policy = policy;
        }

        @Override
        public int warning(IWarningInfo warning) {
            report.add(stage, warning);
            return policy.getAction(warning.getWarningType());
        }
    }
}
```

`WarningPolicy` oluştururken büyük biçimlendirme farkları kabul edilebilir ise `abortOnMajorFormattingLoss` için `false` geçirin. Uyumluluk sorunları, küçük biçimlendirme kaybı ve beklenmeyen içerik, işlem devam etse bile raporda tutulur. Uygulama bu kategorilerin herhangi birini reddetmek zorundaysa `WarningPolicy.getAction` metodunu genişletin.

## **Yaygın Uyarı Senaryoları**

Uyarılar, bir iş akışının farklı aşamalarında ortaya çıkabilir:

- **Dijital imzalar:** İmzalı bir sunum, işleme sırasında imzanın kaybolacağını belirten bir uyarıyı yükleme sırasında üretebilir. Aspose.Slides bu `DataLoss` durumunu [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationsignedwarninginfo/) aracılığıyla raporlar. Yükleme aşamasındaki geri çağrı, uygulamanın dosyayı reddetmesine veya bildirilen kaybı açıkça kabul etmesine olanak tanır.
- **Yazı tipi ikamesi:** Kullanılamayan bir yazı tipi, bir slayt işlenirken veya dışa aktarılırken değiştirilebilir. Yazı tipi ikamesi uyarıları `DataLoss` olarak raporlanır, bu yüzden yukarıdaki sıkı politika, uygulama belirli bir ikameyi görsel olarak kabul etse bile iptal eder. Bu davranışı gözlemlemek için çalışma zamanında mevcut olmayan bir yazı tipinde metin içeren bir giriş sunumu kullanın. Uyarı açıklaması ikameyi belirtir; yeniden denemeden önce gerekli yazı tiplerini yapılandırın veya [font substitution rules](/slides/tr/androidjava/font-substitution/) ayarlayın.
- **Desteklenmeyen veya beklenmeyen içerik:** Yükleyici, tanımadığı sunum kayıtları veya özelliklerle karşılaşabilir. Bu tür uyarılar `UnexpectedContent` ya da veri veya biçimlendirmenin etkilendiği biliniyorsa daha ciddi bir kategori kullanabilir.
- **Format uyumluluğu:** Başka bir sunum formatına kaydetmek, bazı özellikleri atlayabilir veya bazı uygulamalarda farklı davranan bir sonuç üretebilir. Örneğin, sekizden fazla yatay veya sekizden fazla dikey çizim kılavuzu içeren bir sunumu eski PPT formatına kaydetmek bir `CompatibilityIssue` raporlar. Kaydetme aşamasındaki geri çağrı kaybı kaydedebilir ve devam edebilir, ya da tüm kılavuzların korunması gerekiyorsa reddedebilir.
- **Yükleme davranışı:** Yükleme seçenekleri ve eski davranışlar da uyarılar üretebilir. Örneğin, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) kullanımının artık olmayan bir sunum kilitleme davranışı olduğunu `CompatibilityIssue` olarak tanımlar.

Uyarılar, kaynak belge, hedef format, işlem ve Aspose.Slides sürümüne bağlıdır. Her dosyanın uyarı üretileceğini veya bir senaryonun her zaman yalnızca bir kategoriye eşleneceğini varsaymayın.

## **İptal Edilen İşlemleri Güvenli Şekilde Ele Alma**

Bir geri çağrı `ReturnAction.Abort` döndürdüğünde, yüklenemeyen bir nesneyi kullanmayın ve bir işleme veya kaydetme çıktısının tamamlandığını varsaymayın. İşlem, çıktı dosyası oluşturulduktan ama tamamlanmadan önce sonlanabilir.

Doğrulanmış sonuçları `validated-output.pptx` gibi ayrı bir yola kaydedin. Mevcut bir sunumu, işlem başarıyla tamamlandıktan, uyarı raporu uygulama politikasını karşıladıktan ve çıktının açılıp kontrol edilebildiğinden emin olduktan sonra değiştirin. Bu, geçerli bir kaynak dosyasının eksik veya reddedilmiş bir sonuçla üzerine yazılmasını önler.

Boş bir uyarı raporu, her kaynak özelliğin korunduğunun garantisi değildir. Uygulamanın gerektirdiği ek içerik ve görsel kontrolleri uygulayın. Ayrıca [Open Presentations](/slides/tr/androidjava/open-presentation/) ve [Save Presentations](/slides/tr/androidjava/save-presentation/) bölümlerine bakın.

## **SSS**

**Bir uyarı geri çağrısı her Aspose.Slides hatasını ele alabilir mi?**

Hayır. Yalnızca uyarı olarak raporlanan kurtarılabilir koşulları ele alır. Geri çağrıdan bağımsız olarak meydana gelen istisnalar, yükleme, işleme, dönüşüm veya kaydetme çağrısı etrafında uygulama tarafından ele alınmalıdır.

**`ReturnAction.Continue` döndürmek aynı çıktıyı garanti eder mi?**

Hayır. Sadece işlemin devam etmesine izin verir. Raporlanan durum hâlâ veri, biçimlendirme veya uyumluluk farklılıklarına neden olabilir; bu nedenle toplanan uyarı türlerini ve açıklamalarını gözden geçirin.

**Bir uygulama uyarıyı hangi işlem ürettiğini nasıl belirleyebilir?**

Her işlem için bir geri çağrı örneği oluşturun ve örnekte gösterildiği gibi [getWarningType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) ve [getDescription](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) tarafından döndürülen değerlerle birlikte uygulama tanımlı bir aşamayı depolayın.