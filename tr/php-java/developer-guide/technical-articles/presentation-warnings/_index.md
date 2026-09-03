---
title: PHP'de Sunum Uyarılarını İşleme
type: docs
weight: 90
url: /tr/php-java/presentation-warnings/
aliases:
- /php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak sunumları yüklerken, işlerken, dönüştürürken ve kaydederken uyarıları nasıl toplayacağınızı, sınıflandıracağınızı ve bunlara nasıl aksiyon alacağınızı öğrenin."
---
## **Genel Bakış**

Aspose.Slides, bir sunumu yüklerken, işlerken, dönüştürürken veya kaydederken kurtarılabilir sorunları raporlayabilir. Örnekler arasında bozuk kaynak kayıtları, korunamayan içerik, yazı tipi ikamesi ve hedef formatın sınırlamaları yer alır. Bir uyarı geri çağrısı, uygulamanın bu koşulları kaydetmesine ve mevcut işlemin devam edip etmeyeceğine karar vermesine olanak tanır.

PHP'de `warning` adlı bir public metoda sahip bir sınıf oluşturun ve bunu PHP Java Bridge üzerinden `java_closure` kullanarak Java [IWarningCallback](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iwarningcallback/) arayüzü olarak ortaya koyun. [IWarningInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iwarninginfo/) aracılığıyla sağlanan [getWarningType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iwarninginfo/#getWarningType--) ve [getDescription](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iwarninginfo/#getDescription--) değerlerini inceleyin. Uyarıyı kabul etmek için [ReturnAction::Continue](https://reference.aspose.com/slides/tr/php-java/aspose.slides/returnaction/#Continue), işlemi durdurmak için ise [ReturnAction::Abort](https://reference.aspose.com/slides/tr/php-java/aspose.slides/returnaction/#Abort) döndürün.

[LoadOptions::setWarningCallback](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/#setWarningCallback) sunumu açarken ortaya çıkan uyarılar için kullanın. İşleme ve dışa aktarma seçenek sınıfları, slayt işleme, dönüşüm ve kaydetme sırasında uyarıları alan [SaveOptions::setWarningCallback](https://reference.aspose.com/slides/tr/php-java/aspose.slides/saveoptions/#setWarningCallback) metodunu devralır. Uyarı, uygulama işlemini tanımlamadığından, birleşik rapor oluştururken her geri çağrı örneğini bir işlem aşamasıyla ilişkilendirin.

## **Uyarılar ve İstisnalar**

Java istisnaları PHP Java Bridge aracılığıyla PHP'ye aktarılır; aşağıdaki örnekte gösterildiği gibi bu istisnaları işlem sınırında yakalayın. Bu makaledeki Java arayüz bağlantıları, köprü tarafından kullanılan geri çağrı sözleşmesini açıklar.

Bir uyarı, geri çağrı `ReturnAction::Continue` döndürürse Aspose.Slides'in kurtulabileceği bir durumu tanımlar. Bir istisna, istenen işlemin normal olarak tamamlanamayacağını gösterir; istisnalar uyarılara dönüştürülmez ve bir uyarı politikasıyla işlenemez.

`ReturnAction::Abort` döndürmek, uyarı dağıtıcısına bir istisna yükselterek mevcut işlemi sonlandırmasını söyler. Açık istisna, işlem ve sunum formatına bağlıdır. Örneğin, yükleme sırasında bir [PptxReadException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pptxreadexception/) veya [PptReadException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pptreadexception/) ortaya çıkabilir; kaydetme veya dışa aktarma sırasında ise bir [PptxException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pptxexception/) ortaya çıkabilir. İstisnayı işlem sınırında ele alın ve bir istisna alt türüne veya mesajına dayanmak yerine, uygulama politikasının sonlandırmaya neden olup olmadığını belirlemek için uyarı raporunu kullanın. Geri çağrı, `ReturnAction::Abort` döndürmeden önce uyarıyı kaydeder, böylece neden uygulama için kullanılabilir olur.

## **Uyarı Kategorileri**

[WarningType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/warningtype/) sınıfı aşağıdaki kategoriler için tamsayı sabitleri sağlar:

| Uyarı türü | Anlam | Tipik politika |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/tr/php-java/aspose.slides/warningtype/#SourceFileCorruption) | Kaynak sunum, orijinal formatta kaydedilen belgenin kullanılamaz hale gelmesine neden olabilecek bozulma içerir. | İptal. |
| [DataLoss](https://reference.aspose.com/slides/tr/php-java/aspose.slides/warningtype/#DataLoss) | Metin, grafikler, görseller veya diğer veriler yükleme veya kaydetme sonrasında eksik olabilir. | İptal. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/tr/php-java/aspose.slides/warningtype/#MajorFormattingLoss) | Sunum önemli biçimlendirmeyi kaybedebilir. | Sıkı doğrulama modunda iptal; aksi takdirde kaydet ve devam et. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/tr/php-java/aspose.slides/warningtype/#MinorFormattingLoss) | Sınırlı bir biçimlendirme farkı meydana gelebilir. | Tanılama için kaydet ve devam et. |
| [CompatibilityIssue](https://reference.aspose.com/slides/tr/php-java/aspose.slides/warningtype/#CompatibilityIssue) | Sonuç, bazı uygulamalarda veya eski sürümlerde açılamayabilir veya düzgün çalışmayabilir. | Uyumluluk zorunlu değilse kaydet ve devam et. |
| [UnexpectedContent](https://reference.aspose.com/slides/tr/php-java/aspose.slides/warningtype/#UnexpectedContent) | Kaynak, etkisi henüz bilinmeyen desteklenmeyen veya tanınmayan içerik içerir. | Kaydet ve devam et, ya da sıkı bir politikada hataya dönüştür. |

Kategori, politika kararını yönlendirmelidir. Tanılama için [getDescription](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iwarninginfo/#getDescription--) tarafından döndürülen değeri saklayın, ancak uygulama mantığı için metin içeriğine güvenmeyin çünkü mesaj metni uyarı senaryoları ve ürün sürümleri arasında değişebilir.

## **Uyarıları Toplamak ve Sınıflandırmak**

Aşağıdaki örnek, tam işleme hattı için tek bir uygulama düzeyinde rapor kullanır. Ayrı bir geri çağrı örneği, yükleme, işleme, PDF dönüşümü ve PPTX kaydetme sırasında ortaya çıkan uyarıları etiketler. Politika, kaynak bozulması veya veri kaybında iptal eder, isteğe bağlı olarak büyük biçimlendirme kaybında da iptal eder ve diğer uyarılar için devam eder. Geri çağrı, uyarı değerlerini kaydetmeden ve karşılaştırmadan önce `java_values` ile yerel PHP değerlerine dönüştürür.

```php
use aspose\slides\ImageFormat;
use aspose\slides\LoadOptions;
use aspose\slides\PdfOptions;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class WarningReport {
    private $entries = [];

    public function getEntries() {
        return $this->entries;
    }

    public function add($stage, $type, $description) {
        $this->entries[] = [
            "stage" => $stage,
            "type" => $type,
            "description" => $description
        ];
    }
}

class WarningPolicy {
    private $abortOnMajorFormattingLoss;

    public function __construct($abortOnMajorFormattingLoss) {
        $this->abortOnMajorFormattingLoss = $abortOnMajorFormattingLoss;
    }

    public function getAction($warningType) {
        if ($warningType === WarningType::SourceFileCorruption || $warningType === WarningType::DataLoss) {
            return ReturnAction::Abort;
        }

        if ($warningType === WarningType::MajorFormattingLoss && $this->abortOnMajorFormattingLoss) {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }
}

class ReportingWarningCallback {
    private $stage;
    private $report;
    private $policy;

    public function __construct($stage, WarningReport $report, WarningPolicy $policy) {
        $this->stage = $stage;
        $this->report = $report;
        $this->policy = $policy;
    }

    public function warning($warning) {
        $type = (int) java_values($warning->getWarningType());
        $description = (string) java_values($warning->getDescription());
        $this->report->add($this->stage, $type, $description);
        return $this->policy->getAction($type);
    }
}

function createWarningCallback($stage, WarningReport $report, WarningPolicy $policy) {
    $handler = new ReportingWarningCallback($stage, $report, $policy);
    $warningInterface = java("com.aspose.slides.IWarningCallback");
    return java_closure($handler, null, $warningInterface);
}

function processPresentation($inputPath, WarningReport $report, WarningPolicy $policy) {
    try {
        $loadOptions = new LoadOptions();
        $callback = createWarningCallback("Loading", $report, $policy);
        $loadOptions->setWarningCallback($callback);

        $presentation = new Presentation($inputPath, $loadOptions);
        try {
            if (!renderFirstSlide($presentation, $report, $policy)) {
                return false;
            }

            if (!convertToPdf($presentation, $report, $policy)) {
                return false;
            }

            return saveValidatedCopy($presentation, $report, $policy);
        } finally {
            $presentation->dispose();
        }
    } catch (Throwable $exception) {
        echo "Loading stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function renderFirstSlide($presentation, WarningReport $report, WarningPolicy $policy) {
    if ((int) java_values($presentation->getSlides()->size()) === 0) {
        echo "Rendering stopped: the presentation has no slides." . PHP_EOL;
        return false;
    }

    try {
        $options = new RenderingOptions();
        $callback = createWarningCallback("Rendering", $report, $policy);
        $options->setWarningCallback($callback);

        $image = $presentation->getSlides()->get_Item(0)->getImage($options);
        try {
            $image->save("slide-1.png", ImageFormat::Png);
            return true;
        } finally {
            $image->dispose();
        }
    } catch (Throwable $exception) {
        echo "Rendering stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function convertToPdf($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PdfOptions();
        $callback = createWarningCallback("Conversion", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("converted.pdf", SaveFormat::Pdf, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Conversion stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function saveValidatedCopy($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PptxOptions();
        $callback = createWarningCallback("Saving", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("validated-output.pptx", SaveFormat::Pptx, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Saving stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function warningTypeName($warningType) {
    switch ($warningType) {
        case WarningType::SourceFileCorruption:
            return "SourceFileCorruption";
        case WarningType::DataLoss:
            return "DataLoss";
        case WarningType::MajorFormattingLoss:
            return "MajorFormattingLoss";
        case WarningType::MinorFormattingLoss:
            return "MinorFormattingLoss";
        case WarningType::CompatibilityIssue:
            return "CompatibilityIssue";
        case WarningType::UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" . $warningType . ")";
    }
}

$report = new WarningReport();
$policy = new WarningPolicy(true);
$completed = processPresentation("input.pptx", $report, $policy);

echo ($completed ? "Processing completed." : "Processing stopped.") . PHP_EOL;

foreach ($report->getEntries() as $entry) {
    $typeName = warningTypeName($entry["type"]);
    echo "[" . $entry["stage"] . "] " . $typeName . ": " . $entry["description"] . PHP_EOL;
}
```

`WarningPolicy` oluştururken büyük biçimlendirme farklılıkları kabul edilebiliyorsa `abortOnMajorFormattingLoss` için `false` geçirin. İşlem devam ettiğinde bile uyumluluk sorunları, küçük biçimlendirme kaybı ve beklenmeyen içerik raporda tutulur. Uygulama bu kategorilerin herhangi birini reddetmek zorundaysa `WarningPolicy::getAction`ı genişletin.

## **Yaygın Uyarı Senaryoları**

Uyarılar, bir iş akışının farklı aşamalarında ortaya çıkabilir:

- **Dijital imzalar:** İmzalı bir sunum, işleme sırasında imzasının kaybolacağı uyarısını yükleme sırasında üretebilir. Aspose.Slides bu `DataLoss` koşulunu [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationsignedwarninginfo/) aracılığıyla raporlar. Yükleme aşamasındaki geri çağrı, uygulamanın dosyayı reddetmesine veya bildirilen kaybı açıkça kabul etmesine olanak tanır.
- **Yazı tipi ikamesi:** Kullanılamayan bir yazı tipi, bir slayt işlenirken veya dışa aktarılırken değiştirilebilir. Yazı tipi ikamesi uyarıları `DataLoss` olarak raporlanır, bu yüzden yukarıdaki katı politika, uygulama belirli bir ikameyi görsel olarak kabul etse bile iptal eder. Bu davranışı gözlemlemek için, çalışma zamanında bulunmayan bir yazı tipinde metin içeren bir giriş sunumu kullanın. Uyarı açıklaması ikameyi tanımlar; gerekli yazı tiplerini yapılandırın veya yeniden denemeden önce [font substitution rules](/slides/tr/php-java/font-substitution/) ayarlayın.
- **Desteklenmeyen veya beklenmeyen içerik:** Bir yükleyici, tanımadığı sunum kayıtları veya özelliklerle karşılaşabilir. Bu tür uyarılar `UnexpectedContent` veya veri ve biçimlendirmenin etkilendiği biliniyorsa daha ciddi bir kategori kullanabilir.
- **Format uyumluluğu:** Başka bir sunum formatına kaydetmek özellikleri atlayabilir veya bazı uygulamalarda farklı davranan bir sonuç üretebilir. Örneğin, sekizden fazla yatay veya sekizden fazla dikey çizim kılavuzuna sahip bir sunumu eski PPT formatına kaydetmek bir `CompatibilityIssue` raporlar. Kaydetme aşamasındaki geri çağrı, kaybı kaydedebilir ve devam edebilir veya tüm kılavuzların korunması gerekiyorsa reddedebilir.
- **Yükleme davranışı:** Yükleme seçenekleri ve eski davranışlar da uyarılar üretebilir. Örneğin, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) eski bir sunum kilitleme davranışının kullanımını `CompatibilityIssue` olarak tanımlar.

Uyarılar, kaynak belge, hedef format, işlem ve Aspose.Slides sürümüne bağlıdır. Her dosyanın bir uyarı üreteceğini veya bir senaryonun her zaman yalnızca bir kategoriye eşleşeceğini varsaymayın.

## **İptal Edilen İşlemleri Güvenli Şekilde Ele Alma**

Bir geri çağrı `ReturnAction::Abort` döndürdüğünde, yüklenemeyen bir nesneyi kullanmayın ve bir işleme veya kaydetme çıktısının tamamlandığını varsamıyın. İşlem, bir çıktı dosyası oluşturulduktan sonra ama tamamlanmadan önce sonlanabilir.

Doğrulanmış sonuçları `validated-output.pptx` gibi ayrı bir yola kaydedin. İşlem başarıyla tamamlandıktan, uyarı raporu uygulama politikasını karşıladıktan ve çıktı açılıp kontrol edilebildikten sonra mevcut bir sunumu değiştirin. Bu, geçerli bir kaynak dosyanın kısmi veya reddedilmiş bir sonuçla üzerine yazılmasını önler.

Boş bir uyarı raporu, her kaynak özelliğinin korunduğunun garantisi değildir. Uygulamanın gerektirdiği ek içerik ve görsel kontrolleri uygulayın. Ayrıca [Open Presentations](/slides/tr/php-java/open-presentation/) ve [Save Presentations](/slides/tr/php-java/save-presentation/) bölümlerine bakın.

## **SSS**

**Bir uyarı geri çağrısı her Aspose.Slides hatasını işleyebilir mi?**

Hayır. Yalnızca uyarı olarak raporlanan kurtarılabilir koşulları yönetir. Geri çağrıdan bağımsız olarak oluşan istisnalar, yükleme, işleme, dönüşüm veya kaydetme çağrısı çevresinde uygulama tarafından ele alınmalıdır.

**`ReturnAction::Continue` döndürmek aynı çıktıyı garanti eder mi?**

Hayır. Sadece işlemin devam etmesine izin verir. Raporlanan koşul hâlâ veri, biçimlendirme veya uyumluluk farklılıklarına neden olabilir, bu yüzden toplanan uyarı türlerini ve açıklamaları gözden geçirin.

**Bir uygulama, uyarıyı hangi işlemin ürettiğini nasıl belirleyebilir?**

Her işlem için bir geri çağrı örneği oluşturun ve örnekte gösterildiği gibi, [getWarningType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iwarninginfo/#getWarningType--) ve [getDescription](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iwarninginfo/#getDescription--) tarafından döndürülen değerlerle birlikte uygulama tarafından tanımlanan aşamayı depolayın.