---
title: Java'da Sunum Uyarılarını İşleme
type: docs
weight: 90
url: /tr/java/presentation-warnings/
aliases:
- /java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- uyarı geri araması
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile sunumları yüklerken, işlerken, dönüştürürken ve kaydederken uyarıları toplama, sınıflandırma ve bunlara göre hareket etme hakkında bilgi edinin."
---
## **Genel Bakış**

Aspose.Slides, bir sunumu yüklerken, işlerken, dönüştürürken veya kaydederken kurtarılabilir sorunları raporlayabilir. Örnekler arasında bozuk kaynak kayıtları, korunamayan içerik, yazı tipi ikamesi ve hedef format sınırlamaları bulunur. Bir uyarı geri araması, uygulamanın bu koşulları kaydetmesine ve geçerli işlemin devam edip etmeyeceğine karar vermesine olanak tanır.

[IWarningCallback](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iwarningcallback/) arayüzünü uygulayın ve [IWarningInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iwarninginfo/) aracılığıyla sağlanan [getWarningType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iwarninginfo/#getWarningType--) ve [getDescription](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iwarninginfo/#getDescription--) değerlerini inceleyin. Uyarıyı kabul etmek için [ReturnAction.Continue](https://reference.aspose.com/slides/tr/java/com.aspose.slides/returnaction/#Continue), işlemi durdurmak için [ReturnAction.Abort](https://reference.aspose.com/slides/tr/java/com.aspose.slides/returnaction/#Abort) döndürün.

Sunum açılırken yükselen uyarılar için [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) kullanın. İşleme, dönüştürme ve kaydetme sırasında gelen uyarılar ise kaydetme seçenek sınıflarının kalıtımı olan [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/tr/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) aracılığıyla alınır. Uyarı kendisi uygulama işlemini tanımlamadığından, birleşik bir rapor oluştururken her geri arama örneğini bir işlem aşamasıyla ilişkilendirin.

## **Uyarılar ve İstisnalar**

Uyarı, geri arama `ReturnAction.Continue` döndürülürse Aspose.Slides'in kurtarabileceği bir koşulu tanımlar. İstisna, istenen işlemin normal olarak tamamlanamayacağını gösterir; istisnalar uyarıya dönüştürülmez ve bir uyarı politikasıyla ele alınamaz.

`ReturnAction.Abort` döndürmek, uyarı dağıtıcısına mevcut işlemi bir istisna fırlatarak sonlandırmasını söyler. Ortaya çıkan istisna, işlem ve sunum formatına bağlıdır. Örneğin, yükleme sırasında bir [PptxReadException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pptxreadexception/) veya [PptReadException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pptreadexception/) ortaya çıkabilir; kaydetme veya dışa aktarma sırasında ise bir [PptxException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pptxexception/) görülebilir. İstisnayı işlemin sınırında yakalayın ve uyarı raporunu, uygulama politikasının sonlandırmaya neden olup olmadığını belirlemek için kullanın; tek bir istisna alt türüne veya mesajına güvenmeyin. Geri arama, `ReturnAction.Abort` döndürmeden önce uyarıyı kaydeder, böylece neden uygulamaya erişilebilir kalır.

## **Uyarı Kategorileri**

[WarningType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/warningtype/) sınıfı aşağıdaki kategoriler için tam sayı sabitleri sunar:

| Uyarı türü | Anlamı | Tipik politika |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/tr/java/com.aspose.slides/warningtype/#SourceFileCorruption) | Kaynak sunum, orijinal formatta kaydedildiğinde kullanılmaz hale gelebilecek bozulma içerir. | İptal. |
| [DataLoss](https://reference.aspose.com/slides/tr/java/com.aspose.slides/warningtype/#DataLoss) | Metin, grafik, resim veya diğer veri, yükleme ya da kaydetme sonrasında eksik olabilir. | İptal. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/tr/java/com.aspose.slides/warningtype/#MajorFormattingLoss) | Sunum önemli biçimlendirme kaybı yaşayabilir. | Sıkı doğrulama modunda iptal; aksi takdirde kaydet ve devam et. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/tr/java/com.aspose.slides/warningtype/#MinorFormattingLoss) | Sınırlı bir biçimlendirme farkı oluşabilir. | Tanı için kaydet ve devam et. |
| [CompatibilityIssue](https://reference.aspose.com/slides/tr/java/com.aspose.slides/warningtype/#CompatibilityIssue) | Sonuç bazı uygulamalarda veya eski sürümlerde açılamayabilir ya da doğru çalışmayabilir. | Uyumluluk zorunlu değilse kaydet ve devam et. |
| [UnexpectedContent](https://reference.aspose.com/slides/tr/java/com.aspose.slides/warningtype/#UnexpectedContent) | Kaynak, etkisi henüz bilinmeyen desteklenmeyen veya tanınmayan içerik barındırıyor. | Kaydet ve devam et, ya da sıkı bir politikada hataya çevir. |

Kategori, politika kararını yönlendirmelidir. Tanı amaçlı değeri saklamak için [getDescription](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iwarninginfo/#getDescription--) değerini kaydedin, ancak uygulama mantığında bu metne güvenmeyin; mesaj metni uyarı senaryoları ve ürün sürümleri arasında değişebilir.

## **Uyarıları Topla ve Sınıflandır**

Aşağıdaki örnek, tam işleme hattı için tek bir uygulama‑seviyesi rapor kullanır. Ayrı bir geri arama örneği, yükleme, işleme, PDF dönüştürme ve PPTX kaydetme aşamalarındaki uyarıları etiketler. Politika, kaynak bozulması veya veri kaybında iptal eder, isteğe bağlı olarak büyük biçimlendirme kaybında da iptal eder ve diğer uyarılarda devam eder.

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
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

class PresentationWarningExample {
    public static void main(String[] args) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        boolean completed = processPresentation("input.pptx", report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, report, policy);
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

    private static boolean renderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy) {
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
                image.save("slide-1.png", ImageFormat.Png);
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

    private static boolean convertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            presentation.save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            presentation.save("validated-output.pptx", SaveFormat.Pptx, options);
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

`WarningPolicy` oluştururken büyük biçimlendirme farkları kabul edilebiliyorsa `abortOnMajorFormattingLoss` parametresine `false` geçirin. Uyumluluk sorunları, küçük biçimlendirme kaybı ve beklenmeyen içerik, işlem devam etse bile raporda tutulur. Uygulama bu kategorilerden herhangi birini reddetmek zorundaysa `WarningPolicy.getAction` metodunu genişletin.

## **Yaygın Uyarı Senaryoları**

Uyarılar, iş akışının farklı aşamalarında ortaya çıkabilir:

- **Dijital imzalar:** İmzalı bir sunum, yükleme sırasında işleme sırasında imzanın kaybolacağı konusunda bir uyarı üretebilir. Aspose.Slides bu `DataLoss` durumunu [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationsignedwarninginfo/) aracılığıyla raporlar. Yükleme aşaması geri araması, dosyayı reddetmeye ya da raporlanan kaybı açıkça kabul etmeye olanak tanır.
- **Yazı tipi ikamesi:** Kullanılamayan bir yazı tipi, slayt işlenirken veya dışa aktarılırken ikame edilebilir. Yazı tipi ikamesi uyarıları `DataLoss` olarak raporlanır; bu yüzden yukarıdaki sıkı politika, uygulama ikameyi görsel olarak kabul etse bile iptal eder. Bu davranışı gözlemlemek için, çalışma zamanında mevcut olmayan bir yazı tipinde metin içeren bir sunum kullanın. Uyarı açıklaması ikame edilen yazı tipini gösterir; gerekli yazı tiplerini yapılandırın veya [yazı tipi ikame kuralları](/slides/tr/java/font-substitution/) ekleyin ve tekrar deneyin.
- **Desteklenmeyen veya beklenmeyen içerik:** Bir yükleyici, tanımadığı sunum kayıtları veya özelliklerle karşılaşabilir. Bu uyarılar `UnexpectedContent` ya da veri/biçimlendirme etkilendiğinde daha şiddetli bir kategori kullanabilir.
- **Format uyumluluğu:** Başka bir sunum formatına kaydetmek, bazı özellikleri atlayabilir veya sonucun bazı uygulamalarda farklı davranmasına sebep olabilir. Örneğin, sekizden fazla yatay veya dikey çizim kılavuzu içeren bir sunumu eski PPT’ye kaydetmek `CompatibilityIssue` raporlar. Kaydetme aşaması geri araması, kaybı kaydedip devam edebilir ya da tüm kılavuzların korunması gerekiyorsa reddedebilir.
- **Yükleme davranışı:** Yükleme seçenekleri ve eski davranışlar da uyarı üretebilir. Örneğin, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) eski bir sunum kilitleme davranışının kullanımını `CompatibilityIssue` olarak tanımlar.

Uyarılar, kaynak belge, hedef format, işlem ve Aspose.Slides sürümüne bağlıdır. Her dosyanın uyarı üreteceğini ya da bir senaryonun yalnızca bir kategoriye eşleneceğini varsaymayın.

## **Durdurulan İşlemleri Güvenli Şekilde Ele Alma**

Bir geri arama `ReturnAction.Abort` döndürdüğünde, yüklenemeyen nesneyi kullanmayın ve bir işleme ya da kaydetme çıktısının tamamlandığını varsaymayın. İşlem, bir çıktı dosyası oluşturduktan sonra ama tamamlamadan önce sonlanabilir.

Doğrulanmış sonuçları `validated-output.pptx` gibi ayrı bir yola kaydedin. Mevcut bir sunumu yalnızca işlem başarılı bir şekilde tamamlandığında, uyarı raporu uygulama politikasını karşıladığında ve çıktı açılıp kontrol edilebildiğinde üzerine yazın. Bu, geçerli bir kaynak dosyanın kısmi ya da reddedilmiş bir sonuçla üzerine yazılmasını önler.

Boş bir uyarı raporu, her kaynak özelliğin korunduğunun garantisi değildir. Uygulamanın gerektirdiği ek içerik ve görsel kontrolleri uygulayın. Ayrıca [Sunum Açma](/slides/tr/java/open-presentation/) ve [Sunum Kaydetme](/slides/tr/java/save-presentation/) bölümlerine bakın.

## **SSS**

**Bir uyarı geri araması her Aspose.Slides hatasını ele alabilir mi?**

Hayır. Sadece uyarı olarak raporlanan kurtarılabilir koşulları ele alır. Geri aramadan bağımsız olarak ortaya çıkan istisnalar, yükleme, işleme, dönüştürme veya kaydetme çağrısı çevresinde uygulama tarafından yakalanmalıdır.

**`ReturnAction.Continue` döndürmek aynı çıktıyı garantiler mi?**

Hayır. Sadece işlemin devam etmesine izin verir. Raporlanan koşul hâlâ veri, biçimlendirme veya uyumluluk farklılıklarına yol açabilir; bu nedenle toplanan uyarı türlerini ve açıklamalarını gözden geçirin.

**Bir uygulama, uyarıyı üreten işlemi nasıl tanımlar?**

Her işlem için bir geri arama örneği oluşturun ve değerleri döndüren [getWarningType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iwarninginfo/#getWarningType--) ve [getDescription](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iwarninginfo/#getDescription--) ile birlikte uygulama‑tanımlı aşamayı saklayın; örnek buna göre gösterilmiştir.