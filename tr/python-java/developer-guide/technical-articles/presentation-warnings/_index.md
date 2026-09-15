---
title: Python üzerinden Java ile Sunum Uyarılarını Ele Alma
type: docs
weight: 90
url: /tr/python-java/presentation-warnings/
aliases:
- /python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- uyarı geri araması
- uyarı politikası
- veri kaybı
- kaynak bozulması
- uyumluluk sorunu
- yazı tipi ikamesi
- dijital imza
- sunum yükleme
- sunum render etme
- sunum dönüşümü
- sunum kaydetme
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile sunumları yüklerken, render ederken, dönüştürürken ve kaydederken uyarıları toplama, sınıflandırma ve bunlarla nasıl işlem yapacağınızı öğrenin."
---
## **Genel Bakış**

Aspose.Slides, bir sunumu yüklerken, render ederken, dönüştürürken veya kaydederken kurtarılabilir sorunları raporlayabilir. Örnekler arasında bozuk kaynak kayıtları, korunamayan içerik, yazı tipi ikamesi ve hedef format sınırlamaları bulunur. Bir uyarı geri araması, bir uygulamanın bu koşulları kaydetmesine ve mevcut işlemin devam edip etmeyeceğine karar vermesine olanak tanır.

`jpype.JProxy` aracılığıyla `IWarningCallback` arayüzünü uygulayın ve `IWarningInfo` tarafından sağlanan `getWarningType` ve `getDescription` değerlerini inceleyin. Uyarıyı kabul etmek için [ReturnAction.Continue](https://reference.aspose.com/slides/tr/python-java/aspose.slides/returnaction/#Continue) döndürün veya işlemi durdurmak için [ReturnAction.Abort](https://reference.aspose.com/slides/tr/python-java/aspose.slides/returnaction/#Abort) döndürün.

Uyarılar, bir sunum açılırken yükseltildiğinde [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setWarningCallback) kullanın. Render ve dışa aktarma seçenek sınıfları, slayt render'ı, dönüşüm ve kaydetme sırasında uyarıları alan [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveoptions/#setWarningCallback) miras alır. Uyarı kendisi uygulama işlemini tanımlamadığından, birleşik bir rapor oluştururken her geri arama örneğini bir işlem aşamasına bağlayın.

## **Uyarılar ve İstisnalar**

Bir uyarı, geri arama `ReturnAction.Continue` döndürdüğünde Aspose.Slides'ın kurtarabileceği bir koşulu tanımlar. Bir istisna, talep edilen işlemin normal olarak tamamlanamayacağını gösterir; istisnalar uyarıya dönüştürülmez ve bir uyarı politikasıyla ele alınamaz.

`ReturnAction.Abort` döndürmek, uyarı dağıtıcısına bir istisna yükselterek mevcut işlemi sonlandırmasını söyler. Genel istisna, işleme ve sunum formatına bağlıdır. Örneğin, yükleme sırasında bir [PptxReadException](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pptxreadexception/) veya [PptReadException](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pptreadexception/) ortaya çıkabilir; kaydetme veya dışa aktarma sırasında ise bir [PptxException](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pptxexception/) ortaya çıkabilir. İstisnayı işlemin sınırında yakalayın ve uygulama politikasının sonlandırmaya neden olup olmadığını belirlemek için uyarı raporunu kullanın; yalnızca bir istisna alt türüne veya mesajına güvenmeyin. Geri arama, `ReturnAction.Abort` döndürmeden önce uyarıyı kaydeder ve nedeni uygulamaya sunulabilir tutar.

## **Uyarı Kategorileri**

[WarningType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/warningtype/) sınıfı aşağıdaki kategoriler için tamsayı sabitleri sağlar:

| Uyarı türü | Anlamı | Tipik politika |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/tr/python-java/aspose.slides/warningtype/#SourceFileCorruption) | Kaynak sunum, orijinal formatta kaydedilen belgenin kullanılamaz hale gelmesine neden olabilecek bozulma içerir. | İptal. |
| [DataLoss](https://reference.aspose.com/slides/tr/python-java/aspose.slides/warningtype/#DataLoss) | Metin, grafik, resim veya diğer veriler yükleme veya kaydetme sonrası eksik olabilir. | İptal. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/tr/python-java/aspose.slides/warningtype/#MajorFormattingLoss) | Sunum önemli biçimlendirmeyi kaybedebilir. | Sıkı doğrulama modunda iptal; aksi takdirde kaydet ve devam et. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/tr/python-java/aspose.slides/warningtype/#MinorFormattingLoss) | Sınırlı bir biçimlendirme farkı ortaya çıkabilir. | Tanı için kaydedin ve devam edin. |
| [CompatibilityIssue](https://reference.aspose.com/slides/tr/python-java/aspose.slides/warningtype/#CompatibilityIssue) | Sonuç bazı uygulamalarda veya eski sürümlerde açılamayabilir veya doğru çalışmayabilir. | Uyumluluk zorunlu değilse kaydedin ve devam edin. |
| [UnexpectedContent](https://reference.aspose.com/slides/tr/python-java/aspose.slides/warningtype/#UnexpectedContent) | Kaynak, henüz etkisi bilinmeyen desteklenmeyen veya tanınmayan içerik içerir. | Kaydedin ve devam edin, ya da sıkı politikada hataya dönüştürün. |

Kategori, politika kararını yönlendirmelidir. Tanı amaçlı `getDescription` tarafından döndürülen değeri saklayın, ancak mesaj metni uyarı senaryoları ve ürün sürümleri arasında değişebileceği için uygulama mantığında metnine dayanmayın.

## **Uyarıları Topla ve Sınıflandır**

Aşağıdaki örnek, tam işleme hattı için tek bir uygulama‑seviyesi raporu kullanır. Ayrı bir geri arama örneği, yükleme, render, PDF dönüşümü ve PPTX kaydetme aşamalarından gelen uyarıları etiketler. Politika, kaynak bozulması veya veri kaybı durumunda iptal eder, büyük biçimlendirme kaybında isteğe bağlı olarak iptal eder ve diğer uyarılar için devam eder.

```python
import sys
from dataclasses import dataclass
from enum import Enum

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, LoadOptions, PdfOptions, PptxOptions, Presentation, RenderingOptions, ReturnAction, SaveFormat, WarningType


class OperationStage(Enum):
    Loading = "Loading"
    Rendering = "Rendering"
    Conversion = "Conversion"
    Saving = "Saving"


@dataclass(frozen=True)
class WarningEntry:
    stage: OperationStage
    type: int
    description: str


class WarningReport:
    def __init__(self):
        self._entries = []

    def get_entries(self):
        return tuple(self._entries)

    def add(self, stage, warning):
        entry = WarningEntry(stage, warning.getWarningType(), str(warning.getDescription()))
        self._entries.append(entry)


class WarningPolicy:
    def __init__(self, abort_on_major_formatting_loss):
        self.abort_on_major_formatting_loss = abort_on_major_formatting_loss

    def get_action(self, warning_type):
        if warning_type in (WarningType.SourceFileCorruption, WarningType.DataLoss):
            return ReturnAction.Abort
        if warning_type == WarningType.MajorFormattingLoss and self.abort_on_major_formatting_loss:
            return ReturnAction.Abort
        return ReturnAction.Continue


class ReportingWarningCallback:
    def __init__(self, stage, report, policy):
        self.stage = stage
        self.report = report
        self.policy = policy

    def warning(self, warning):
        self.report.add(self.stage, warning)
        return self.policy.get_action(warning.getWarningType())


def process_presentation(input_path, report, policy):
    try:
        load_options = LoadOptions()
        handler = ReportingWarningCallback(OperationStage.Loading, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        load_options.setWarningCallback(callback)
        presentation = Presentation(input_path, load_options)
        try:
            if not render_first_slide(presentation, report, policy):
                return False
            if not convert_to_pdf(presentation, report, policy):
                return False
            return save_validated_copy(presentation, report, policy)
        finally:
            presentation.dispose()
    except Exception as exception:
        print(f"Loading stopped: {exception}", file=sys.stderr)
        return False


def render_first_slide(presentation, report, policy):
    if presentation.getSlides().size() == 0:
        print("Rendering stopped: the presentation has no slides.", file=sys.stderr)
        return False
    try:
        options = RenderingOptions()
        handler = ReportingWarningCallback(OperationStage.Rendering, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        image = presentation.getSlides().get_Item(0).getImage(options)
        try:
            image.save("slide-1.png", ImageFormat.Png)
            return True
        finally:
            image.dispose()
    except Exception as exception:
        print(f"Rendering stopped: {exception}", file=sys.stderr)
        return False


def convert_to_pdf(presentation, report, policy):
    try:
        options = PdfOptions()
        handler = ReportingWarningCallback(OperationStage.Conversion, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("converted.pdf", SaveFormat.Pdf, options)
        return True
    except Exception as exception:
        print(f"Conversion stopped: {exception}", file=sys.stderr)
        return False


def save_validated_copy(presentation, report, policy):
    try:
        options = PptxOptions()
        handler = ReportingWarningCallback(OperationStage.Saving, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("validated-output.pptx", SaveFormat.Pptx, options)
        return True
    except Exception as exception:
        print(f"Saving stopped: {exception}", file=sys.stderr)
        return False


def warning_type_name(warning_type):
    names = {
        WarningType.SourceFileCorruption: "SourceFileCorruption",
        WarningType.DataLoss: "DataLoss",
        WarningType.MajorFormattingLoss: "MajorFormattingLoss",
        WarningType.MinorFormattingLoss: "MinorFormattingLoss",
        WarningType.CompatibilityIssue: "CompatibilityIssue",
        WarningType.UnexpectedContent: "UnexpectedContent",
    }
    return names.get(warning_type, f"Unknown ({warning_type})")


report = WarningReport()
policy = WarningPolicy(True)
completed = process_presentation("input.pptx", report, policy)

print("Processing completed." if completed else "Processing stopped.")
for entry in report.get_entries():
    type_name = warning_type_name(entry.type)
    print(f"[{entry.stage.value}] {type_name}: {entry.description}")
```

`WarningPolicy` oluştururken büyük biçimlendirme farkları kabul edilebiliyorsa `abort_on_major_formatting_loss` için `False` gönderin. Uyumluluk sorunları, küçük biçimlendirme kaybı ve beklenmeyen içerik, işlem devam etse bile raporda tutulur. Uygulamanın bu kategorilerden herhangi birini reddetmesi gerekiyorsa `WarningPolicy.get_action` yöntemini genişletin.

## **Ortak Uyarı Senaryoları**

Uyarılar, bir iş akışının farklı aşamalarında ortaya çıkabilir:

- **Dijital imzalar:** İmzalı bir sunum, işleme sırasında imzasının kaybolacağı uyarısını yükleme sırasında üretebilir. Aspose.Slides bu `DataLoss` durumunu `IPresentationSignedWarningInfo` aracılığıyla raporlar. Yükleme aşaması geri araması, uygulamanın dosyayı reddetmesini veya bildirilen kaybı açıkça kabul etmesini sağlar.
- **Yazı tipi ikamesi:** Kullanılamayan bir yazı tipi, bir slayt render edilirken veya dışa aktarılırken ikame edilebilir. Yazı tipi ikamesi uyarıları `DataLoss` olarak raporlanır; bu nedenle yukarıdaki sıkı politika, uygulama ikame edilen yazı tipini görsel olarak kabul etse bile iptal eder. Bu davranışı gözlemlemek için çalıştırma zamanında mevcut olmayan bir yazı tipinde metin içeren bir giriş sunumu kullanın. Uyarı açıklaması ikameyi belirtir; gerekli yazı tiplerini yapılandırın veya [font substitution rules](/slides/tr/python-java/font-substitution/) belirleyin ve yeniden deneyin.
- **Desteklenmeyen veya beklenmeyen içerik:** Bir yükleyici, tanımadığı sunum kayıtları veya özelliklerle karşılaşabilir. Bu uyarılar `UnexpectedContent` veya verinin/faaliyet kaybının bilindiği daha şiddetli bir kategori kullanabilir.
- **Format uyumluluğu:** Başka bir sunum formatına kaydetmek, özellikleri atlayabilir veya sonucun bazı uygulamalarda farklı davranmasına neden olabilir. Örneğin, sekizden fazla yatay veya dikey çizim kılavuzu içeren bir sunumu eski PPT formatına kaydetmek bir `CompatibilityIssue` raporlar. Kaydetme aşaması geri araması kaybı kaydedebilir ve devam edebilir veya tüm kılavuzların korunması gerekiyorsa reddedebilir.
- **Yükleme davranışı:** Yükleme seçenekleri ve eski davranışlar da uyarı üretebilir. Örneğin, `IObsoletePresLockingBehaviorWarningInfo` bir `CompatibilityIssue` olarak eski bir sunum kilitleme davranışının kullanımını tanımlar.

Uyarılar, kaynak belge, hedef format, işlem ve Aspose.Slides sürümüne bağlıdır. Her dosyanın uyarı üreteceğini veya bir senaryonun yalnızca bir kategoriye denk geleceğini varsaymayın.

## **İptal Edilen İşlemleri Güvenli Bir Şekilde Yönetme**

Bir geri arama `ReturnAction.Abort` döndürdüğünde, yüklenemeyen bir nesneyi kullanmayın ve bir render veya kaydetme çıktısının tamamlandığını varsamayın. İşlem, bir çıktı dosyası oluşturulduktan ancak tamamlanmadan önce sonlanabilir.

Doğrulanmış sonuçları `validated-output.pptx` gibi ayrı bir yola kaydedin. Var olan bir sunumu yalnızca işlem başarılı bir şekilde tamamlandığında, uyarı raporu uygulama politikasını karşıladığında ve çıktı açılıp kontrol edilebildiğinde değiştirin. Bu, geçerli bir kaynak dosyanın kısmi ya da reddedilmiş bir sonuçla üzerine yazılmasını önler.

Boş bir uyarı raporu, her kaynak özelliğin korunduğunun garantisi değildir. Uygulamanın gerektirdiği ek içerik ve görsel kontrolleri uygulayın. Ayrıca [Open Presentations](/slides/tr/python-java/open-presentation/) ve [Save Presentations](/slides/tr/python-java/save-presentation/) bölümlerine bakın.

## **SSS**

**Bir uyarı geri araması her Aspose.Slides hatasını yönetebilir mi?**

Hayır. Sadece uyarı olarak raporlanan kurtarılabilir koşulları yönetir. Geri aramadan bağımsız olarak ortaya çıkan istisnalar, yükleme, render, dönüşüm veya kaydetme çağrısı etrafında uygulama tarafından ele alınmalıdır.

**`ReturnAction.Continue` döndürmek aynı çıktıyı garantiler mi?**

Hayır. Sadece işleme devam edilmesine izin verir. Raporlanan koşul hâlâ veri, biçimlendirme veya uyumluluk farklılıklarına yol açabilir; bu nedenle toplanan uyarı türlerini ve açıklamalarını gözden geçirin.

**Bir uygulama, uyarıyı üreten işlemi nasıl belirleyebilir?**

Her işlem için bir geri arama örneği oluşturun ve `getWarningType` ve `getDescription` tarafından döndürülen değerlerle birlikte uygulama tanımlı bir aşamayı saklayın; örnekte gösterildiği gibi.