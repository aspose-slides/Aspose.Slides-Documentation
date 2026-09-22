---
title: Android'de Orijinal Sunum Biçimini Belirleme
linktitle: Kaynak Biçim
type: docs
weight: 35
url: /tr/androidjava/detect-presentation-source-format/
keywords:
- kaynak biçim
- sunum biçimini algıla
- PowerPoint
- OpenDocument
- sunum
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Android'de Java aracılığıyla Aspose.Slides for Android ile yüklenmiş bir sunumun orijinal biçimini okuyun, algılama API'lerini karşılaştırın ve dosyaları, akışları ve eski biçimleri yönetin."
---
## **Genel Bakış**

Bir sunumu yükledikten sonra, orijinal biçimini belirlemek için [Presentation.getSourceFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getSourceFormat--) yöntemini çağırın. Bu yöntem ayrıca [IPresentation.getSourceFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--) aracılığıyla da kullanılabilir. Gelecek işlem, mevcut örneğin yüklendiği biçime bağlı olduğunda bunu kullanın.

Kaynak biçim, bir çıktı dosyası için seçilen [SaveFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/saveformat/) biçiminden farklıdır. Başka bir biçime kaydetmek, mevcut örneğin kaynak biçimini değiştirmez.

Örnekler Java ve dosya yolları kullanır. Android'de, örnek yolları uygulamanın erişilebilir depolama alanındaki yollarla değiştirin; örneğin uygulamanızın dahili dosyalar dizini.

## **Bir Dosyanın Kaynak Biçimini Okuma**

Bu örnek mevcut bir `sample.pptx` dosyası gerektirir. Dosyayı yükler ve dosya adı yerine [Presentation.getSourceFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getSourceFormat--) kullanarak bir uygulama işleme politikasını seçer. Başka biçimleri denemek için giriş yolunu değiştirin. Örnek, seçilen politikayı yazdırır; mesajları uygulamanızın mantığıyla değiştirin.

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

[SourceFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/sourceformat/) sınıfı, aşağıdaki sunum biçimlerini ayıran tamsayı sabitlerini tanımlar. Aşağıdaki uzantılar geleneksel uzantılardır, orijinal dosya adının yeniden oluşturulması değildir.

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
| `Otp` | `.otp` | OpenDocument sunum şablonu |
| `Fodp` | `.fodp` | Düz XML ODF sunumu |
| `Xml` | `.xml` | PowerPoint XML sunumu |

## **Bir Akışın Kaynak Biçimini Okuma**

Bu örnek mevcut bir `sample.pps` dosyası gerektirir. Baytlarını bir bellek akışına okumak, veritabanı değeri ya da yüklenen bayt dizisi gibi dosya adı olmadan alınan girişi taklit eder. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) yapıcısı yalnızca akışı alır.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

try {
    byte[] bytes;
    try (FileInputStream input = new FileInputStream("sample.pps");
         ByteArrayOutputStream output = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = input.read(buffer)) != -1) {
            output.write(buffer, 0, bytesRead);
        }
        bytes = output.toByteArray();
    }
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

PPT, PPS ve POT aynı temel ikili biçimi kullanır. Dosya yoluyla yüklerken, uzantı bir slayt gösterisi ya da şablonu ayırt etmeye yardımcı olabilir. Dosya adı olmadan, eski PPS ve POT içeriği `SourceFormat.Ppt` olarak raporlanabilir; yukarıdaki PPS örneği `SourceFormat.Ppt` tamsayı değerini yazdırır.

Uygulamanız ayrımı korumak zorundaysa, özgün dosya adını veya alt tür meta verisini ayrı tutun. Uzantı bu eski alt türler için yararlı bir ipucu olsa da, rastgele sunum içeriğini tanımlamanın tek temeli olmamalıdır.

## **Yüklemeden Önce ve Sonra Algılamayı Karşılaştırma**

[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) ve [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) yöntemlerini, bir dosyayı tam sunum nesne modeline yüklemeden önce incelemeniz gerektiğinde kullanın. Örneğin zaten var olan bir örnek için [Presentation.getSourceFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getSourceFormat--) yöntemini kullanın.

Bu örnek `sample.pptx` gerektirir ve sırasıyla `LoadFormat.Pptx` ve `SourceFormat.Pptx` tamsayı değerlerini yazdırır. Üretimde, işleme aşamanıza uygun API'yi seçin; zaten yüklenmiş bir sunum, yalnızca kaynak biçimini elde etmek için ikinci bir inceleme gerektirmez.

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

Sonuçlar, farklı sınıflardan sabitler kullanır: [LoadFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/loadformat/) ve [SourceFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/sourceformat/). Sayısal değerlerini karşılaştırmayın veya her biçimin aynı algılama sonucuna sahip olduğunu varsaymayın. PowerPoint XML, yüklemeden önce `LoadFormat.Unknown` ve yükledikten sonra `SourceFormat.Xml` olarak raporlanabilir.

## **Kaynak ve Çıktı Biçimlerini Ayrı Tutma**

Bu örnek `sample.pptx` gerektirir ve `converted.odp` yazar. Orijinal örnek kaydedilmeden önce ve sonra `SourceFormat.Pptx` tamsayı değerini yazdırır. Yalnızca ODP çıktısından yüklenen yeni örnek `Odp` rapor eder.

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

`new Presentation()` ile sıfırdan oluşturulan bir sunum `SourceFormat.Pptx` rapor eder. Giriş dosyası yoktur: bu yeni oluşturulan bir örnek için varsayılan değerdir, PPTX dosyasının yüklendiğine dair bir kanıt değildir. Bu ayrım önemliyse, uygulamanızın örneği oluşturup oluşturmadığını ayrı olarak izleyin.

## **Bir Kaynak Biçimini Uzantıya Eşleme**

Aşağıdaki örnek `sample.pptx` gerektirir. Her mevcut desteklenen [SourceFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/sourceformat/) değerini geleneksel bir uzantıya eşler, girdi dosya adını ayrıştırmadan. Yedek plan, tanınmayan bir değere sessizce uzantı atamaktan kaçınır.

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

Bu eşleme bir dosyayı dönüştürmez veya akış yüklemesi sırasında kaybolan eski PPS/POT alt türünü geri getirmez. Gerçek kaydetme için, bir [SaveFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/saveformat/) açıkça seçin veya [Orijinal Biçiminde Sunumları Kaydet](/slides/tr/androidjava/save-presentation/#save-presentations-in-their-original-format) içinde gösterilen dönüşümü kullanın.

## **Kaydederek ve Yeniden Açarak Biçimleri Doğrulama**

Bu bağımsız örnek bir sunum oluşturur ve çalışma dizininde üç dosya yazar, aynı adlardaki dosyaları üzerine yazar. Her çıkışı hem yol hem de bellek akışı aracılığıyla yeniden açar. PPTX ve ODP için her iki yol da kaydedilen biçimi rapor eder. PPS için, yol üzerinden yükleme `Pps` rapor ederken, aynı baytları dosya adı olmadan yüklemek `Ppt` rapor eder.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes;
            try (FileInputStream input = new FileInputStream(path);
                 ByteArrayOutputStream output = new ByteArrayOutputStream()) {
                byte[] buffer = new byte[8192];
                int bytesRead;
                while ((bytesRead = input.read(buffer)) != -1) {
                    output.write(buffer, 0, bytesRead);
                }
                bytes = output.toByteArray();
            }
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

Aşağıdaki tablo, eşleşen uzantılara sahip sunumlar için kaynak‑biçim tanımlamasını özetler. İsimler sabitleri gösterir; Java örnekleri tamsayı değerlerini yazdırır:

| Kaydedilen biçim | Dosya yolundan SourceFormat | Adı olmayan akıştan SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectively | Dosya yolu ile aynı |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectively | Dosya yolu ile aynı |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectively | Dosya yolu ile aynı |
| ODP, OTP | `Odp`, `Otp` respectively | Dosya yolu ile aynı |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT içeriği, adı olmayan akışlar için `Ppt` olarak tanımlanır. Tablo, biçim tanımlamasını açıklar; dönüşüm sırasında her sunum özelliğinin korunmasını değil.

## **SSS**

**PPTX'ten yüklü bir sunumu ODP olarak kaydetmek kaynak biçimini değiştirir mi?**

Hayır. Mevcut örnek hâlâ `Pptx` rapor eder. Kaydedilen ODP dosyasından yüklenen bir örnek `Odp` rapor eder.

**Bir akış her zaman eski bir sunumu, slayt gösterisini ve şablonu ayırt edebilir mi?**

Hayır. PPT, PPS ve POT aynı ikili biçimi paylaşır. Bu ayrım gerektiğinde dosya adını veya alt tür meta verisini ayrı tutun.

**Sunum zaten yüklüyse hangi API'yi kullanmalıyım?**

[Presentation.getSourceFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getSourceFormat--) metodunu kullanın. Yüklemeden önce inceleme için [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) metodunu kullanın.