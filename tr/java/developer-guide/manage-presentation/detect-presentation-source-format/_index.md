---
title: Java’da Orijinal Sunum Biçimini Belirleme
linktitle: Kaynak Biçim
type: docs
weight: 35
url: /tr/java/detect-presentation-source-format/
keywords:
- kaynak format
- sunum formatını algıla
- PowerPoint
- OpenDocument
- sunum
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile Java’da yüklü bir sunumun orijinal formatını okuyun, algılama API’lerini karşılaştırın ve dosyalar, akışlar ve eski formatlarla çalışın."
---
## **Genel Bakış**

Bir sunum yüklendikten sonra, orijinal biçimini belirlemek için [Presentation.getSourceFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getSourceFormat--) yöntemini çağırın. Bu yöntem, ayrıca [IPresentation.getSourceFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentation/#getSourceFormat--) aracılığıyla da kullanılabilir. Mevcut örneğin yüklendiği biçime bağlı olarak sonraki işleme ihtiyaç duyulduğunda bunu kullanın.

Kaynak biçim, bir çıktı dosyası için seçilen [SaveFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/saveformat/) biçiminden farklıdır. Başka bir biçime kaydetmek, mevcut örneğin kaynak biçimini değiştirmez.

## **Bir Dosyanın Kaynak Biçimini Okuma**

Bu örnek, mevcut bir `sample.pptx` dosyası gerektirir. Dosyayı yükler ve dosya adı yerine [Presentation.getSourceFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getSourceFormat--) kullanarak bir uygulama işleme politikasını seçer. Giriş yolunu değiştirerek diğer biçimleri deneyebilirsiniz. Örnek seçilen politikayı yazdırır; mesajları uygulama mantığınızla değiştirin.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
        case SourceFormat.Pps:
        case SourceFormat.Pot:
            System.out.println("Use the legacy PowerPoint processing policy.");
            break;
        case SourceFormat.Pptx:
            System.out.println("Use the standard PPTX processing policy.");
            break;
        default:
            System.out.println("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **Desteklenen Değerleri Tanıma**

[SourceFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/sourceformat/) sınıfı, aşağıdaki sunum biçimlerini ayıran tam sayı sabitlerini tanımlar. Aşağıdaki uzantılar geleneksel uzantılardır, orijinal dosya adının yeniden oluşturulması değildir.

| SourceFormat değeri | Uzantı | Biçim |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 sunumu |
| `Pptx` | `.pptx` | Office Open XML sunumu |
| `Pptm` | `.pptm` | Makro etkin Office Open XML sunumu |
| `Pps` | `.pps` | PowerPoint 97–2003 slayt gösterisi |
| `Ppsx` | `.ppsx` | Office Open XML slayt gösterisi |
| `Ppsm` | `.ppsm` | Makro etkin Office Open XML slayt gösterisi |
| `Pot` | `.pot` | PowerPoint 97–2003 şablonu |
| `Potx` | `.potx` | Office Open XML şablonu |
| `Potm` | `.potm` | Makro etkin Office Open XML şablonu |
| `Odp` | `.odp` | OpenDocument sunumu |
| `Otp` | `.otp` | OpenDocument şablonu |
| `Fodp` | `.fodp` | Düz XML ODF sunumu |
| `Xml` | `.xml` | PowerPoint XML sunumu |

## **Bir Akışın Kaynak Biçimini Okuma**

Bu örnek, mevcut bir `sample.pps` dosyası gerektirir. Baytlarını bir bellek akışına okuma, bir veritabanı değeri veya yüklenmiş bayt dizisi gibi dosya adı olmadan alınan girdiyi modeller. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) oluşturucusu yalnızca akışı alır.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

try {
    byte[] bytes = Files.readAllBytes(Paths.get("sample.pps"));
    try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
        Presentation presentation = new Presentation(stream);
        try {
            System.out.println("Source format: " + presentation.getSourceFormat());
        } finally {
            presentation.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read the presentation: " + exception.getMessage());
}
```

PPT, PPS ve POT aynı temel ikili biçimi kullanır. Dosya yolu ile yüklerken, uzantı bir slayt gösterisi mi yoksa şablon mu olduğunu ayırt etmeye yardımcı olabilir. Dosya adı olmadan, eski PPS ve POT içeriği `SourceFormat.Ppt` olarak raporlanabilir; yukarıdaki PPS örneği `SourceFormat.Ppt` tam sayı değerini yazdırır.

Uygulamanız ayrımı korumak zorundaysa, orijinal dosya adını veya alt tür meta verilerini ayrı tutun. Bir uzantı bu eski alt türler için faydalı bir ipucu olsa da, keyfi sunum içeriğini tanımlamanın tek temeli olmamalıdır.

## **Yüklemeden Önce ve Sonra Algılamayı Karşılaştırma**

Dosyayı tam sunum nesnesi modeli yüklemeden önce incelemeniz gerektiğinde [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) ve [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) kullanın. Örneğin, örnek zaten var olduğunda [Presentation.getSourceFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getSourceFormat--) kullanın.

Bu örnek `sample.pptx` gerektirir ve `LoadFormat.Pptx` ile `SourceFormat.Pptx` tam sayı değerlerini sırasıyla yazdırır. Üretimde, işleme aşamanıza uygun API'yi seçin; zaten yüklenmiş bir sunumun kaynak biçimini elde etmek için ikinci bir inceleme yapmaya gerek yoktur.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;

String path = "sample.pptx";
IPresentationInfo information = PresentationFactory.getInstance().getPresentationInfo(path);
System.out.println("Before loading: " + information.getLoadFormat());

Presentation presentation = new Presentation(path);
try {
    System.out.println("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

Sonuçlar farklı sınıflardan sabitler kullanır: [LoadFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadformat/) ve [SourceFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/sourceformat/). Sayısal değerlerini karşılaştırmayın veya her biçimin aynı algı sonuçlarına sahip olduğunu varsaymayın. PowerPoint XML, yüklemeden önce `LoadFormat.Unknown` ve yükledikten sonra `SourceFormat.Xml` olarak raporlanabilir.

## **Kaynak ve Çıktı Biçimlerini Ayrı Tutma**

Bu örnek `sample.pptx` gerektirir ve `converted.odp` yazar. `SourceFormat.Pptx` tam sayı değerini hem kaydetmeden önce hem sonra yazdırır. Yalnızca ODP çıktısından yüklenen yeni örnek `Odp` raporlar.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", SaveFormat.Odp);
    System.out.println("After saving: " + presentation.getSourceFormat());

    Presentation reopened = new Presentation("converted.odp");
    try {
        System.out.println("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

`new Presentation()` ile sıfırdan oluşturulan bir sunum `SourceFormat.Pptx` raporlar. Giriş dosyası yoktur: bu, yeni oluşturulan bir örnek için varsayılan değerdir, bir PPTX dosyasının yüklendiğinin kanıtı değildir. Bu ayrım sizin için önemliyse, uygulamanızın örneği oluşturup oluşturmadığını ayrı olarak izleyin.

## **Bir Kaynak Biçimini Uzantıya Eşleme**

Aşağıdaki örnek `sample.pptx` gerektirir. Şu anda desteklenen her [SourceFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/sourceformat/) değerini, giriş dosya adını ayrıştırmadan geleneksel bir uzantıya eşler. Geri dönüş, tanınmayan bir değere sessizce uzantı atamaktan kaçınır.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    String extension;
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case SourceFormat.Pps:
            extension = ".pps";
            break;
        case SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case SourceFormat.Pot:
            extension = ".pot";
            break;
        case SourceFormat.Potx:
            extension = ".potx";
            break;
        case SourceFormat.Potm:
            extension = ".potm";
            break;
        case SourceFormat.Odp:
            extension = ".odp";
            break;
        case SourceFormat.Otp:
            extension = ".otp";
            break;
        case SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    System.out.println(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

Bu eşleme bir dosyayı dönüştürmez veya akış yüklemesi sırasında kaybolan eski PPS/POT alt türünü kurtarmaz. Gerçek kaydetme için, bir [SaveFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/saveformat/) açıkça seçin veya [Orijinal Biçimlerinde Sunumları Kaydetme](/slides/tr/java/save-presentation/#save-presentations-in-their-original-format) bölümündeki dönüşümü kullanın.

## **Kaydedip Yeniden Açarak Biçimleri Doğrulama**

Bu bağımsız örnek bir sunum oluşturur ve çalışma dizininde üç dosya yazar, aynı isimli dosyaları üzerine yazar. Her çıkışı hem yol üzerinden hem de bir bellek akışı aracılığıyla yeniden açar. PPTX ve ODP için, her iki yol da kaydedilen biçimi raporlar. PPS için, yol üzerinden yükleme `Pps` rapor ederken, aynı baytları dosya adı olmadan yükleme `Ppt` rapor eder.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes = Files.readAllBytes(Paths.get(path));
            try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
                Presentation fromStream = new Presentation(stream);
                try {
                    System.out.println(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            }
        } finally {
            fromFile.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read a saved presentation: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

Aşağıdaki tablo, eşleşen uzantılara sahip sunumlar için kaynak‑biçim tanımlamasını özetler. İsimler sabitleri gösterir; Java örnekleri tam sayı değerlerini yazdırır:

| Kaydedilen biçim | Dosya yolundan SourceFormat | İsimsiz akıştan SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` sırasıyla | Dosya yoluyla aynı |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` sırasıyla | Dosya yoluyla aynı |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` sırasıyla | Dosya yoluyla aynı |
| ODP, OTP | `Odp`, `Otp` sırasıyla | Dosya yoluyla aynı |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT içeriği, isimsiz akışlar için `Ppt` olarak tanımlanır. Tablo, biçim tanımlamasını gösterir; dönüşüm sırasında her sunum özelliğinin korunmasını göstermeyecek.

## **SSS**

**ODP’ye kaydetmek, PPTX’ten yüklü bir sunumun kaynak biçimini değiştirir mi?**

Hayır. Mevcut örnek hâlâ `Pptx` raporlar. Kaydedilen ODP dosyasından yüklenen bir örnek `Odp` raporlar.

**Bir akış her zaman eski bir sunumu, slayt gösterisini ve şablonu ayırt edebilir mi?**

Hayır. PPT, PPS ve POT aynı ikili biçimi paylaşır. Bu ayrım gerekli olduğunda dosya adını veya alt‑tür meta verisini ayrı tutun.

**Sunum zaten yüklüyse hangi API’yi kullanmalıyım?**

[Presentation.getSourceFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getSourceFormat--) okuyun. Yüklemeden önce inceleme için [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) kullanın.