---
title: JavaScript'te Sunumları Kaydet
linktitle: Sunumu Kaydet
type: docs
weight: 80
url: /tr/nodejs-java/save-presentation/
keywords:
- PowerPoint'i kaydet
- OpenDocument'i kaydet
- sunumu kaydet
- slaytı kaydet
- PPT'yi kaydet
- PPTX'i kaydet
- ODP'yi kaydet
- dosyaya sunum
- akışa sunum
- önceden tanımlı görünüm türü
- Katı Office Open XML Formatı
- Zip64 modu
- küçük resmi yenileme
- kaydetme ilerlemesi
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides ile JavaScript'te PowerPoint ve OpenDocument sunumlarını dosyalara veya akışlara kaydedin ve PPTX çıktısını ve ilerleme raporlamasını yapılandırın."
---
## **Genel Bakış**

Sunum oluşturduktan sonra veya [var olan bir sunumu açtıktan](/slides/tr/nodejs-java/open-presentation/) sonra, sonucu yazmak için [Presentation.save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#save) metodunu kullanın. Aspose.Slides for Node.js via Java, bir sunumu PowerPoint, OpenDocument, PDF ve diğer formatlarda bir dosyaya veya akışa kaydedebilir. Aşağıdaki bölümler standart kaydetme işlemlerini ve PPTX çıktısı için mevcut seçenekleri kapsar.

## **Sunumları Dosyalara Kaydet**

Bir sunumu dosyaya kaydetmek için, çıktı yolunu ve bir [SaveFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/saveformat/) değerini [Presentation.save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#save) metoduna geçirin. Format değeri, Aspose.Slides'ın oluşturacağı dosya türünü belirler.

Aşağıdaki örnek bir sunum oluşturur ve PPTX dosyası olarak kaydeder:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    // Burada sunum içeriğini ekleyin veya değiştirin.

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sunumları Orijinal Formatlarında Kaydet**

Dosya ve akış tespiti örnekleri, yeni oluşturulan sunumların davranışı ve kaynak ile çıktı formatları arasındaki ayrım için, [Determine the Original Presentation Format](/slides/tr/nodejs-java/detect-presentation-source-format/) bölümüne bakın.

Batch işleme uygulamasında, giriş formatı önceden bilinmeyebilir. Bir dosya yüklendikten sonra, orijinal formatını [Presentation.getSourceFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getSourceFormat) metodundan okuyun. Elde edilen [SourceFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sourceformat/) değerini [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideutil/#toSaveFormat) metoduna geçirerek karşılık gelen [SaveFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/saveformat/) değerini alın ve ardından [Presentation.save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#save) ile değiştirilmiş sunumu yazın.

Aşağıdaki tam örnek, bir giriş dizinindeki her dosyayı işler, başlığını günceller ve yüklendiği formatta bir çıktı dizinine kaydeder:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const fs = require("fs");
const path = require("path");

const inputDirectory = "Input";
const outputDirectory = "Output";

if (!fs.existsSync(inputDirectory)) {
    console.error("The input directory does not exist.");
} else {
    fs.mkdirSync(outputDirectory, { recursive: true });

    const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
        .filter((entry) => entry.isFile());

    for (const inputFile of inputFiles) {
        const inputPath = path.join(inputDirectory, inputFile.name);
        try {
            const presentation = new aspose.slides.Presentation(inputPath);
            try {
                const saveFormat = aspose.slides.SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                const outputPath = path.join(outputDirectory, inputFile.name);
                presentation.save(outputPath, saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (error) {
            console.error(`Cannot process '${inputPath}': ${error.message}`);
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideutil/#toSaveFormat) PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP ve PowerPoint XML'i ilgili sunum kaydetme formatlarına eşler. Yalnızca sunum kaynak formatlarını eşler; PDF, HTML, TIFF veya resimler gibi dışa aktarma formatlarını seçmek için tasarlanmamıştır. Desteklenmeyen veya geçersiz bir [SourceFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sourceformat/) değeri geçmek bir hataya yol açar.

Eski PPT, PPS ve POT dosyaları aynı ikili konteyneri kullanır. Böyle bir sunum, dosya uzantısı olmadan bir akıştan yüklendiğinde, bir PPS veya POT dosyası PPT olarak tanımlanabilir. Bu eski alt türlerin korunması gerekiyorsa, orijinal dosya adını veya format meta verilerini ayrı olarak tutun ve çıktı dosya adı ve formatını seçerken kullanın.

## **Sunumları Akışlara Kaydet**

Son bir dosya yoluna bağlı kalmadan bir sunumu yazmak için, yazılabilir bir akış ve bir [SaveFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/saveformat/) değeri [Presentation.save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#save) metoduna geçirin. Bu yaklaşım, çıkışın bir web hizmetinden döndürülmesi, bir veritabanına kaydedilmesi veya bellekte işlenmesi gerektiğinde yararlıdır.

Aşağıdaki örnek yeni bir sunumu bir dosya akışına kaydeder:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "output.pptx");
    try {
        presentation.save(outputStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Önceden Tanımlı Görünüm Türüyle Sunumları Kaydet**

PowerPoint'in kaydedilmiş bir sunumu ilk açtığı görünümü belirtebilirsiniz. Kaydetmeden önce bir [ViewType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/viewtype/) değeri ile [ViewProperties.setLastView](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/viewproperties/#setLastView) metodunu kullanın.

Aşağıdaki örnek Slide Master görünümünü başlangıç görünümü olarak yapılandırır:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("slide-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sunumları Katı Office Open XML Formatında Kaydet**

Office Open XML'in Strict profiline uyan bir PPTX dosyası oluşturmak için, bir [PptxOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pptxoptions/) örneği oluşturun ve [setConformance](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pptxoptions/#setConformance) metodunu [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict) ile kullanın. Ardından seçenekleri [Presentation.save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#save) metoduna geçirin.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

const presentation = new aspose.slides.Presentation();
try {
    presentation.save("strict-office-open-xml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Sunumları Office Open XML Formatında Zip64 Modunda Kaydet**

Standart bir ZIP arşivi, her girişin sıkıştırılmış ve sıkıştırılmamış boyutunu, toplam arşiv boyutunu ve giriş sayısını sınırlar. PPTX dosyası bir ZIP arşivi olduğundan, çok büyük bir sunum bu sınırlamaları aşabilir. ZIP64 uzantıları geçerli boyut ve giriş sayısı sınırlamalarını artırır.

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pptxoptions/#setZip64Mode) metodunu kullanarak Aspose.Slides'ın ZIP64 uzantılarını yazıp yazmayacağını kontrol edin:

- [IfNecessary](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/zip64mode/#IfNecessary) yalnızca sunum standart ZIP limitlerini aştığında ZIP64 kullanır. Bu varsayılan moddur.
- [Never](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/zip64mode/#Never) ZIP64 uzantılarını devre dışı bırakır.
- [Always](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/zip64mode/#Always) her zaman ZIP64 uzantılarını yazar.

Aşağıdaki örnek, çıktı sunumu için her zaman ZIP64 uzantılarını etkinleştirir:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setZip64Mode(aspose.slides.Zip64Mode.Always);

    presentation.save("output-zip64.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Eğer [Zip64Mode.Never](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/zip64mode/#Never) kullanılır ve sunum standart ZIP limitlerine sığamazsa, kaydetme işlemi bir [PptxException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pptxexception/) fırlatır.
{{% /alert %}}

## **Sunumları Office Open XML Formatında Sıkıştırma Düzeyleriyle Kaydet**

PPTX çıktısı için, kaydetme hızını dosya boyutuna göre dengelemek üzere [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel) metodunu kullanabilirsiniz. [CompressionLevel](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compressionlevel/) sınıfı aşağıdaki değerleri sağlar:

- [None](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compressionlevel/#None) veriyi sıkıştırma olmadan depolar.
- [Level1](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compressionlevel/#Level1) en hızlı sıkıştırmayı ve en büyük sıkıştırılmış çıktıyı sağlar.
- [Level2](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compressionlevel/#Level2) ile [Level5](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compressionlevel/#Level5) arasında, kaydetme hızından ziyade daha küçük çıktı elde etmeyi tercih eder.
- [Level6](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compressionlevel/#Level6) kaydetme hızı ile dosya boyutunu dengeler. Bu varsayılan düzeydedir.
- [Level7](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compressionlevel/#Level7) ve [Level8](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compressionlevel/#Level8) daha da küçük çıktıyı, kaydetme hızına tercih eder.
- [Level9](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compressionlevel/#Level9) en güçlü sıkıştırmayı sağlar ve en fazla işlem süresi gerektirir.

Aşağıdaki örnek bir sunumu sıkıştırma olmadan kaydeder:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.None);

    presentation.save("output-no-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

Aşağıdaki örnek maksimum sıkıştırma düzeyini kullanır:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

    presentation.save("output-maximum-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Küçük Resmi Yenilemeden Sunumları Kaydet**

PPTX olarak kaydedilen bir sunumda, [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) metodu belge küçük resmini kontrol eder:

- `true` kaydetme sırasında küçük resmi yeniden oluşturur. Bu varsayılan değerdir.
- `false` mevcut küçük resmi korur. Sunumda küçük resim yoksa, Aspose.Slides bir tane oluşturmaz.

Aşağıdaki örnek, bir sunumu küçük resmi yenilemeden kaydeder:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Küçük resim yenilemesini devre dışı bırakmak, PPTX dosyasının kaydedilme süresini azaltabilir.
{{% /alert %}}

## **Kaydetme İlerleme Güncellemelerini Yüzde Olarak Al**

Kaydetme işlemini izlemek için, bir Java vekiliyle [IProgressCallback](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iprogresscallback/) arayüzünü uygulayın ve uygulamayı [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) metoduna geçirin. Aspose.Slides, dışa aktarma sırasında ilerleme değerleriyle [IProgressCallback.reporting](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iprogresscallback/#reporting-double-) metodunu çağırır.

Aşağıdaki örnek, bir PDF dışa aktarımının ilerlemesini konsola raporlar:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const exportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

const options = new aspose.slides.PdfOptions();
options.setProgressCallback(exportProgressHandler);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose, Aspose.Slides API'si ile oluşturulmuş ücretsiz bir PowerPoint Bölücü sunar. Bu araç, bir sunumdan seçilen slaytları ayrı PPT veya PPTX dosyaları olarak kaydeder.
{{% /alert %}}

## **FAQ**

**Aspose.Slides artımlı veya “hızlı kaydetme” destekliyor mu?**

Hayır. Her kaydetme işlemi, yalnızca değişen bölümleri güncellemek yerine tam bir çıktı dosyası yazar.

**Birden çok iş parçacığı aynı Presentation örneğini kaydedebilir mi?**

Hayır. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) örneği [thread-safe değildir](/slides/tr/nodejs-java/multithreading/). Her bir örneğe aynı anda yalnızca bir iş parçacığından erişin ve kaydedin.

**Sunumu kaydettiğimde bağlantılar ve harici bağlı dosyalar ne olur?**

[Hyperlinks](/slides/tr/nodejs-java/manage-hyperlinks/) sunumda kalır. Aspose.Slides harici bağlı dosyaları kopyalamaz, bu yüzden kaydedilen sunum hâlâ bu dosyaların konumlarına erişebilmelidir.

**Yazar, başlık, şirket ve oluşturulma tarihi gibi belge meta verilerini kaydedebilir miyim?**

Evet. Kaydetmeden önce uygun [document properties](/slides/tr/nodejs-java/presentation-properties/) ayarlayın ve Aspose.Slides bunları çıktı dosyasına yazar.