---
title: Node.js'te Sunum Uyarılarını İşleme
type: docs
weight: 90
url: /tr/nodejs-java/presentation-warnings/
aliases:
- /nodejs-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- uyarı geri araması
- uyarı politikası
- veri kaybı
- kaynak bozulması
- uyumluluk sorunu
- yazı tipi ikameti
- dijital imza
- sunum yükleme
- sunum renderleme
- sunum dönüşümü
- sunum kaydetme
- PowerPoint
- OpenDocument
- JavaScript
- Node.js
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java kullanarak sunumları yüklerken, render ederken, dönüştürürken ve kaydederken uyarıları nasıl toplar, sınıflandırır ve bu uyarılarla nasıl hareket eder öğrenin."
---
## **Genel Bakış**

Aspose.Slides, bir sunumu yüklerken, render ederken, dönüştürürken veya kaydederken kurtarılabilir sorunları raporlayabilir. Örnekler arasında bozuk kaynak kayıtları, korunamayan içerik, yazı tipi ikameti ve hedef formatın sınırlamaları bulunur. Bir uyarı geri araması, uygulamanın bu koşulları kaydetmesine ve mevcut işlemin devam edip etmeyeceğine karar vermesine olanak tanır.

`java.newProxy` kullanarak JavaScript'te [IWarningCallback](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iwarningcallback/) Java arayüzünü uygulayın ve [IWarningInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iwarninginfo/) aracılığıyla sağlanan [getWarningType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iwarninginfo/#getWarningType--) ve [getDescription](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iwarninginfo/#getDescription--) değerlerini inceleyin. Uyarıyı kabul etmek için [ReturnAction.Continue](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/returnaction/#Continue), işlemi durdurmak için ise [ReturnAction.Abort](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/returnaction/#Abort) döndürün.

[LoadOptions.setWarningCallback](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#setWarningCallback) kullanarak bir sunum açılırken yükselen uyarıları yakalayabilirsiniz. Render ve dışa aktarım seçenek sınıfları, slayt renderı, dönüşüm ve kaydetme sırasında gelen uyarıları alan [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) yöntemini miras alır. Uyarı kendisi uygulama işlemini tanımlamadığı için, birleştirilmiş rapor oluştururken her geri arama örneğini bir işlem aşamasıyla ilişkilendirin.

## **Uyarılar ve İstisnalar**

Bir uyarı, geri arama `ReturnAction.Continue` döndürdüğü takdirde Aspose.Slides'ın kurtarabileceği bir koşulu tanımlar. Bir istisna, istenen işlemin normal olarak tamamlanamayacağını gösterir; istisnalar uyarıya dönüştürülmez ve bir uyarı politikasıyla ele alınamaz.

`ReturnAction.Abort` döndürmek, uyarı dağıtıcısına bir istisna yükselterek mevcut işlemi sonlandırmasını söyler. Oluşturulan istisna, işlem ve sunum formatına bağlıdır. Örneğin, yükleme sırasında bir [PptxReadException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pptxreadexception/) veya [PptReadException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pptreadexception/) ortaya çıkabilir; kaydetme veya dışa aktarma sırasında ise bir [PptxException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pptxexception/) oluşabilir. İşlem sınırında Java köprüsü üzerinden hatayı yakalayın ve uyarı raporunu, uygulama politikasının sonlandırmaya neden olup olmadığını belirlemek için kullanın; tek bir istisna alt türüne veya mesajına güvenmeyin. Geri arama, `ReturnAction.Abort` döndürmeden önce uyarıyı kaydeder, böylece neden uygulamaya hâlâ ulaşılabilir.

## **Uyarı Kategorileri**

[WarningType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/warningtype/) sınıfı aşağıdaki kategoriler için tamsayı sabitleri sağlar:

| Uyarı türü | Anlamı | Tipik politika |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/warningtype/#SourceFileCorruption) | Kaynak sunum, orijinal formatında kaydedilen belgeyi kullanılamaz hâle getirebilecek bozulma içeriyor. | Abort. |
| [DataLoss](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/warningtype/#DataLoss) | Metin, grafik, resim veya diğer veri, yükleme veya kaydetme sonrasında eksik olabilir. | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/warningtype/#MajorFormattingLoss) | Sunum önemli biçimlendirme kayıpları yaşayabilir. | Katı doğrulama modunda Abort; aksi takdirde kaydet ve devam et. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/warningtype/#MinorFormattingLoss) | Sınırlı bir biçimlendirme farkı oluşabilir. | Tanı için kaydet ve devam et. |
| [CompatibilityIssue](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/warningtype/#CompatibilityIssue) | Sonuç bazı uygulamalarda veya eski sürümlerde açılamayabilir veya doğru çalışmayabilir. | Logla ve devam et, uyumluluk zorunlu değilse. |
| [UnexpectedContent](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/warningtype/#UnexpectedContent) | Kaynak, etkisi henüz bilinmeyen desteklenmeyen veya tanınmayan içerik içeriyor. | Kaydet ve devam et, katı bir politikada hata olarak da değerlendirilebilir. |

Kategori, politika kararını yönlendirmelidir. Tanı amaçlı olarak [getDescription](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iwarninginfo/#getDescription--) tarafından döndürülen değeri saklayın, ancak mesaj metni uyarı senaryoları ve ürün sürümleri arasında değişebileceği için uygulama mantığında bu metne dayanmayın.

## **Uyarıları Topla ve Sınıflandır**

Aşağıdaki JavaScript örneği, tüm işleme hattı için tek bir uygulama‑seviyesi rapor kullanır. Ayrı bir geri arama örneği, yükleme, render, PDF dönüşümü ve PPTX kaydetme aşamalarındaki uyarıları etiketler. Politika, kaynak bozulması veya veri kaybı durumunda abort eder, büyük biçimlendirme kaybı durumunda isteğe bağlı olarak abort eder ve diğer uyarılar için devam eder.

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

class WarningPolicy {
    constructor(abortOnMajorFormattingLoss) {
        this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
    }

    getAction(warningType) {
        if (warningType === aspose.slides.WarningType.SourceFileCorruption || warningType === aspose.slides.WarningType.DataLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        if (warningType === aspose.slides.WarningType.MajorFormattingLoss && this.abortOnMajorFormattingLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        return aspose.slides.ReturnAction.Continue;
    }
}

function createReportingWarningCallback(stage, report, policy) {
    return java.newProxy("com.aspose.slides.IWarningCallback", {
        warning: function (warning) {
            const type = warning.getWarningType();
            const description = warning.getDescription();
            report.push({ stage, type, description });
            return policy.getAction(type);
        }
    });
}

function processPresentation(inputPath, report, policy) {
    try {
        const loadOptions = new aspose.slides.LoadOptions();
        const callback = createReportingWarningCallback("Loading", report, policy);
        loadOptions.setWarningCallback(callback);

        const presentation = new aspose.slides.Presentation(inputPath, loadOptions);
        try {
            if (!renderFirstSlide(presentation, report, policy)) {
                return false;
            }

            if (!convertToPdf(presentation, report, policy)) {
                return false;
            }

            return saveValidatedCopy(presentation, report, policy);
        } finally {
            presentation.dispose();
        }
    } catch (error) {
        console.error("Loading stopped: " + error.message);
        return false;
    }
}

function renderFirstSlide(presentation, report, policy) {
    if (presentation.getSlides().size() === 0) {
        console.error("Rendering stopped: the presentation has no slides.");
        return false;
    }

    try {
        const options = new aspose.slides.RenderingOptions();
        const callback = createReportingWarningCallback("Rendering", report, policy);
        options.setWarningCallback(callback);

        const image = presentation.getSlides().get_Item(0).getImage(options);
        try {
            image.save("slide-1.png", aspose.slides.ImageFormat.Png);
            return true;
        } finally {
            image.dispose();
        }
    } catch (error) {
        console.error("Rendering stopped: " + error.message);
        return false;
    }
}

function convertToPdf(presentation, report, policy) {
    try {
        const options = new aspose.slides.PdfOptions();
        const callback = createReportingWarningCallback("Conversion", report, policy);
        options.setWarningCallback(callback);

        presentation.save("converted.pdf", aspose.slides.SaveFormat.Pdf, options);
        return true;
    } catch (error) {
        console.error("Conversion stopped: " + error.message);
        return false;
    }
}

function saveValidatedCopy(presentation, report, policy) {
    try {
        const options = new aspose.slides.PptxOptions();
        const callback = createReportingWarningCallback("Saving", report, policy);
        options.setWarningCallback(callback);

        presentation.save("validated-output.pptx", aspose.slides.SaveFormat.Pptx, options);
        return true;
    } catch (error) {
        console.error("Saving stopped: " + error.message);
        return false;
    }
}

function warningTypeName(warningType) {
    switch (warningType) {
        case aspose.slides.WarningType.SourceFileCorruption:
            return "SourceFileCorruption";
        case aspose.slides.WarningType.DataLoss:
            return "DataLoss";
        case aspose.slides.WarningType.MajorFormattingLoss:
            return "MajorFormattingLoss";
        case aspose.slides.WarningType.MinorFormattingLoss:
            return "MinorFormattingLoss";
        case aspose.slides.WarningType.CompatibilityIssue:
            return "CompatibilityIssue";
        case aspose.slides.WarningType.UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" + warningType + ")";
    }
}

const report = [];
const policy = new WarningPolicy(true);
const completed = processPresentation("input.pptx", report, policy);

console.log(completed ? "Processing completed." : "Processing stopped.");

for (const entry of report) {
    const typeName = warningTypeName(entry.type);
    console.log("[" + entry.stage + "] " + typeName + ": " + entry.description);
}
```

`WarningPolicy` oluştururken büyük biçimlendirme farklılıkları kabul edilebilir ise `abortOnMajorFormattingLoss` için `false` geçin. Uyumluluk sorunları, küçük biçimlendirme kaybı ve beklenmeyen içerik, işlem devam etse bile raporda tutulur. Uygulama bu kategorilerin herhangi birini reddetmek zorunda kalırsa `WarningPolicy.getAction` metodunu genişletin.

## **Yaygın Uyarı Senaryoları**

Uyarılar, iş akışının farklı aşamalarında ortaya çıkabilir:

- **Digital signatures:** İmzalı bir sunum, yükleme sırasında imzanın işlem sırasında kaybolacağı uyarısını üretebilir. Aspose.Slides bu `DataLoss` durumunu [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationsignedwarninginfo/) aracılığıyla bildirir. Yükleme aşaması geri araması, dosyayı reddetmenize veya raporlanan kaybı açıkça kabul etmenize olanak tanır.
- **Font substitution:** Kullanılamayan bir yazı tipi, bir slayt render edilirken veya dışa aktarılırken ikame edilebilir. Yazı tipi ikameti uyarıları `DataLoss` olarak raporlanır; bu yüzden yukarıdaki katı politika, görsel olarak kabul edilebilir bir ikame olsa bile abort eder. Bu davranışı gözlemlemek için çalışma zamanında mevcut olmayan bir yazı tipinde metin içeren bir giriş sunumu kullanın. Uyarı açıklaması ikameti gösterir; gerekli yazı tiplerini yapılandırın veya [font substitution rules](/slides/tr/nodejs-java/font-substitution/) ekleyerek tekrar deneyin.
- **Unsupported or unexpected content:** Yükleyici, tanımadığı sunum kayıtları veya özellikleriyle karşılaşabilir. Bu uyarılar `UnexpectedContent` veya veri/biçimlendirme etkilendiğinde daha ağır bir kategori kullanabilir.
- **Format compatibility:** Başka bir sunum formatına kaydetmek, bazı özellikleri atlayabilir veya sonucun bazı uygulamalarda farklı davranmasına neden olabilir. Örneğin, sekizden fazla yatay veya dikey çizim kılavuzu içeren bir sunumu eski PPT formatına kaydetmek `CompatibilityIssue` raporlar. Kaydetme aşaması geri araması, kaybı kaydedip devam edebilir veya tüm kılavuzların korunması gerekiyorsa reddedebilir.
- **Loading behavior:** Yükleme seçenekleri ve eski davranışlar da uyarı üretebilir. Örneğin, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) eski bir sunum‑kilitleme davranışının kullanımını `CompatibilityIssue` olarak tanımlar.

Uyarılar, kaynak belge, hedef format, işlem ve Aspose.Slides sürümüne bağlıdır. Her dosyanın uyarı üreteceğini veya bir senaryonun yalnızca tek bir kategoriye denk geleceğini varsaymayın.

## **İptal Edilen İşlemleri Güvenli Şekilde Ele Alın**

Bir geri arama `ReturnAction.Abort` döndürdüğünde, yüklenememiş bir nesneyi kullanmayın ve render ya da kaydetme çıktısının tamamlanmış olduğunu varsaymayın. İşlem, bir çıktı dosyası oluşturulduktan sonra ama tam olarak tamamlanmadan önce sonlanabilir.

Doğrulanmış sonuçları `validated-output.pptx` gibi ayrı bir yola kaydedin. Mevcut bir sunumu yalnızca işlem başarıyla tamamlandığında, uyarı raporu uygulama politikasına uygun olduğunda ve çıktı açılıp kontrol edildiğinde üzerine yazın. Bu, geçerli bir kaynak dosyanın kısmi veya reddedilmiş bir sonuçla üzerine yazılmasını önler.

Boş bir uyarı raporu, her kaynak özelliğin korunduğunun garantisi değildir. Uygulamanın gerektirdiği ek içerik ve görsel kontrolleri uygulayın. Ayrıca [Open Presentations](/slides/tr/nodejs-java/open-presentation/) ve [Save Presentations](/slides/tr/nodejs-java/save-presentation/) bölümlerine bakın.

## **SSS**

**Bir uyarı geri araması her Aspose.Slides hatasını ele alabilir mi?**

Hayır. Geri arama, uyarı olarak raporlanan kurtarılabilir koşulları ele alır. Geri aramadan bağımsız olarak ortaya çıkan istisnalar, yükleme, render, dönüşüm veya kaydetme çağrıları çevresinde uygulama tarafından ele alınmalıdır.

**`ReturnAction.Continue` döndürmek aynı çıktıyı garanti eder mi?**

Hayır. Bu yalnızca işlemin devam etmesine izin verir. Raporlanan koşul hâlâ veri, biçimlendirme veya uyumluluk farklılıklarına yol açabilir; bu nedenle toplanan uyarı türlerini ve açıklamalarını inceleyin.

**Bir uygulama, uyarıyı üreten işlemi nasıl tanımlayabilir?**

Her işlem için bir geri arama örneği oluşturun ve örnekle birlikte [getWarningType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iwarninginfo/#getWarningType--) ve [getDescription](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iwarninginfo/#getDescription--) tarafından döndürülen değerleri saklayın; örnek kodda gösterildiği gibi.