---
title: Node.js'te Orijinal Sunum Biçimini Belirleme
linktitle: Kaynak Biçimi
type: docs
weight: 35
url: /tr/nodejs-java/detect-presentation-source-format/
keywords:
- kaynak formatı
- sunum formatını algıla
- PowerPoint
- OpenDocument
- sunum
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js için Java üzerinden Aspose.Slides ile yüklenmiş bir sunumun orijinal formatını okuyun, algılama API'lerini karşılaştırın ve dosyaları, akışları ve eski formatları yönetin."
---
## **Genel Bakış**

Bir sunumu yükledikten sonra, orijinal biçimini belirlemek için [Presentation.getSourceFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getSourceFormat) yöntemini çağırın. Gelecek işleme, mevcut örneğin yüklendiği biçime bağlı olduğunda bunu kullanın.

Kaynak biçim, çıktı dosyası için seçilen [SaveFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/saveformat/) biçiminden farklıdır. Başka bir biçime kaydetmek, mevcut örneğin kaynak biçimini değiştirmez.

## **Bir Dosyanın Kaynak Biçimini Okuma**

Bu örnek mevcut bir `sample.pptx` dosyası gerektirir. Dosyayı yükler ve dosya adını kullanmak yerine [Presentation.getSourceFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getSourceFormat) kullanarak bir uygulama işleme politikası seçer. Başka biçimleri denemek için giriş yolunu değiştirin. Örnek seçilen politikayı yazdırır; mesajları kendi uygulama mantığınızla değiştirin.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
        case aspose.SourceFormat.Pps:
        case aspose.SourceFormat.Pot:
            console.log("Use the legacy PowerPoint processing policy.");
            break;
        case aspose.SourceFormat.Pptx:
            console.log("Use the standard PPTX processing policy.");
            break;
        default:
            console.log("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **Desteklenen Değerleri Tanıma**

[SourceFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sourceformat/) sınıfı, aşağıdaki sunum biçimlerini ayırt eden tam sayı sabitlerini tanımlar. Aşağıdaki uzantılar, orijinal dosya adının yeniden oluşturulması değil, geleneksel uzantılardır.

| SourceFormat değeri | Uzantı | Biçim |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 presentation |
| `Pptx` | `.pptx` | Office Open XML presentation |
| `Pptm` | `.pptm` | Macro-enabled Office Open XML presentation |
| `Pps` | `.pps` | PowerPoint 97–2003 slide show |
| `Ppsx` | `.ppsx` | Office Open XML slide show |
| `Ppsm` | `.ppsm` | Macro-enabled Office Open XML slide show |
| `Pot` | `.pot` | PowerPoint 97–2003 template |
| `Potx` | `.potx` | Office Open XML template |
| `Potm` | `.potm` | Macro-enabled Office Open XML template |
| `Odp` | `.odp` | OpenDocument presentation |
| `Otp` | `.otp` | OpenDocument presentation template |
| `Fodp` | `.fodp` | Flat XML ODF presentation |
| `Xml` | `.xml` | PowerPoint XML presentation |

## **Bir Akışın Kaynak Biçimini Okuma**

Bu örnek mevcut bir `sample.pps` dosyası gerektirir. Baytlarını bir bellek akışına okumak, bir dosya adı olmadan alınan girdiyi (veritabanı değeri veya yüklenmiş bayt dizisi gibi) modellemektedir. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) yapıcı yalnızca akışı alır.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const buffer = fs.readFileSync("sample.pps");
const bytes = java.newArray("byte", Array.from(buffer));
const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
try {
    const presentation = new aspose.Presentation(stream);
    try {
        console.log("Source format: " + presentation.getSourceFormat());
    } finally {
        presentation.dispose();
    }
} finally {
    stream.close();
}
```

PPT, PPS ve POT aynı temel ikili biçimi kullanır. Dosya yoluyla yüklerken, uzantı slayt gösterisi mi yoksa şablon mu olduğunu ayırt etmeye yardımcı olabilir. Dosya adı olmadan, eski PPS ve POT içeriği `SourceFormat.Ppt` olarak raporlanabilir; yukarıdaki PPS örneği `SourceFormat.Ppt`'in tam sayı değerini yazdırır.

Eğer uygulamanız bu ayrımı korumak zorundaysa, orijinal dosya adını veya alt tür meta verilerini ayrı olarak tutun. Uzantı bu eski alt türler için yararlı bir ipucu olsa da, rastgele bir sunum içeriğini tanımlamanın tek temeli olmamalıdır.

## **Yüklemeden Önce ve Sonra Algılamayı Karşılaştırma**

[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) ve [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/#getLoadFormat) yöntemlerini, bir dosyayı tam sunum nesne modeline yüklemeden önce incelemeniz gerektiğinde kullanın. Örneği zaten var olan bir örnek için [Presentation.getSourceFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getSourceFormat) kullanın.

Bu örnek `sample.pptx` gerektirir ve sırasıyla `LoadFormat.Pptx` ve `SourceFormat.Pptx` tam sayı değerlerini yazdırır. Üretimde, işleme aşamanıza uygun API'yi seçin; zaten yüklü bir sunum, kaynak biçimini elde etmek için ikinci bir incelemeye ihtiyaç duymaz.

```javascript
const aspose = require("aspose.slides.via.java");

const path = "sample.pptx";
const information = aspose.PresentationFactory.getInstance().getPresentationInfo(path);
console.log("Before loading: " + information.getLoadFormat());

const presentation = new aspose.Presentation(path);
try {
    console.log("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

Sonuçlar farklı sınıflardan gelen sabitleri kullanır: [LoadFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadformat/) ve [SourceFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sourceformat/). Sayısal değerlerini karşılaştırmayın veya her biçimin aynı algılama sonuçlarına sahip olduğunu varsaymayın. PowerPoint XML, yüklemeden önce `LoadFormat.Unknown` ve yükledikten sonra `SourceFormat.Xml` olarak raporlanabilir.

## **Kaynak ve Çıktı Biçimlerini Ayrı Tutun**

Bu örnek `sample.pptx` gerektirir ve `converted.odp` yazar. `SourceFormat.Pptx`'in tam sayı değerini hem kaydetmeden önce hem de kaydettikten sonra yazdırır. Yalnızca ODP çıktısından yüklenen yeni örnek `Odp` raporlar.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    console.log("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", aspose.SaveFormat.Odp);
    console.log("After saving: " + presentation.getSourceFormat());

    const reopened = new aspose.Presentation("converted.odp");
    try {
        console.log("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Yeni `new Presentation()` ile oluşturulan bir sunum, `SourceFormat.Pptx` raporlar. Giriş dosyası yoktur: bu, yeni oluşturulmuş bir örnek için varsayılan değerdir, bir PPTX dosyasının yüklendiğinin kanıtı değildir. Eğer bu ayrım sizin için önemliyse, uygulamanızın örneği oluşturup oluşturmadığını ayrı olarak izleyin.

## **Bir Kaynak Biçimini Uzantıya Eşleme**

Aşağıdaki örnek `sample.pptx` gerektirir. Her mevcut desteklenen [SourceFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sourceformat/) değerini geleneksel bir uzantıya eşler, giriş dosya adını ayrıştırmadan. Geri dönüş, tanınmayan bir değere sessizce uzantı atamaktan kaçınır.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    let extension;
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case aspose.SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case aspose.SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case aspose.SourceFormat.Pps:
            extension = ".pps";
            break;
        case aspose.SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case aspose.SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case aspose.SourceFormat.Pot:
            extension = ".pot";
            break;
        case aspose.SourceFormat.Potx:
            extension = ".potx";
            break;
        case aspose.SourceFormat.Potm:
            extension = ".potm";
            break;
        case aspose.SourceFormat.Odp:
            extension = ".odp";
            break;
        case aspose.SourceFormat.Otp:
            extension = ".otp";
            break;
        case aspose.SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case aspose.SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    console.log(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

Bu eşleme bir dosyayı dönüştürmez veya akış yükleme sırasında kaybolan eski PPS/POT alt türünü geri getirmez. Gerçek kaydetme için bir [SaveFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/saveformat/) açıkça seçin veya [Save Presentations in Their Original Format](/slides/tr/nodejs-java/save-presentation/#save-presentations-in-their-original-format) içinde gösterildiği gibi dönüşümü kullanın.

## **Kaydedip Yeniden Açarak Biçimleri Doğrulama**

Bu bağımsız örnek bir sunum oluşturur ve çalışma dizininde üç dosya yazar, aynı isimdeki dosyaları üzerine yazar. Her çıktıyı hem yol üzerinden hem de bellek akışıyla yeniden açar. PPTX ve ODP için her iki yol da kaydedilen biçimi raporlar. PPS için yol üzerinden yükleme `Pps` rapor ederken, aynı baytları dosya adı olmadan yüklemek `Ppt` rapor eder.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.Presentation();
try {
    const formats = [aspose.SaveFormat.Pptx, aspose.SaveFormat.Odp, aspose.SaveFormat.Pps];
    const extensions = ["pptx", "odp", "pps"];

    for (let i = 0; i < formats.length; i++) {
        const path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        const fromFile = new aspose.Presentation(path);
        try {
            const buffer = fs.readFileSync(path);
            const bytes = java.newArray("byte", Array.from(buffer));
            const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
            try {
                const fromStream = new aspose.Presentation(stream);
                try {
                    console.log(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            } finally {
                stream.close();
            }
        } finally {
            fromFile.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

Aşağıdaki tablo, eşleşen uzantılara sahip sunumların kaynak‑biçim tanımlamasını özetler. İsimler sabitleri temsil eder; JavaScript örnekleri tam sayı değerlerini yazdırır:

| Kaydedilen biçim | Dosya yolundan SourceFormat | İsimsiz akıştan SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectively | Same as file path |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectively | Same as file path |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectively | Same as file path |
| ODP, OTP | `Odp`, `Otp` respectively | Same as file path |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT içeriği, isimli olmayan akışlar için `Ppt` olarak tanımlanır. Tablo, format tanımlamasını, dönüştürme sırasında her sunum özelliğinin korunmasını değil, tanımlamayı açıklar.

## **FAQ**

**ODP'ye kaydetmek, PPTX'ten yüklenen bir sunumun kaynak biçimini değiştirir mi?**

Hayır. Mevcut örnek hâlâ `Pptx` rapor eder. Kaydedilen ODP dosyasından yüklenen bir örnek `Odp` rapor eder.

**Bir akış her zaman eski bir sunumu, slayt gösterisini ve şablonu ayırt edebilir mi?**

Hayır. PPT, PPS ve POT aynı ikili biçimi paylaşır. Bu ayrım gerektiğinde dosya adını veya alt tür meta verisini ayrı tutun.

**Sunum zaten yüklüyse hangi API kullanılmalı?**

[Presentation.getSourceFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getSourceFormat) metodunu okuyun. Yüklemeden önce inceleme için [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) kullanın.