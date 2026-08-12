---
title: JavaScript'te Sunumları Kaydet
linktitle: Sunumu Kaydet
type: docs
weight: 80
url: /tr/nodejs-java/save-presentation/
keywords:
- PowerPoint kaydet
- OpenDocument kaydet
- sunumu kaydet
- slaytı kaydet
- PPT kaydet
- PPTX kaydet
- ODP kaydet
- dosyaya sunum
- akışa sunum
- ön tanımlı görünüm türü
- Katı Office Open XML Formatı
- Zip64 modu
- küçük resmi yenileme
- kaydetme ilerlemesi
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js kullanarak Java üzerinden sunumları nasıl kaydedeceğinizi keşfedin—düzenleri, yazı tiplerini ve efektleri koruyarak PowerPoint veya OpenDocument olarak dışa aktarın."
---
## **Genel Bakış**

[JavaScript'te Sunum Açma](/slides/tr/nodejs-java/open-presentation/) Aspose.Slides for Node.js'ta bir sunumu açmak için [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının nasıl kullanılacağını açıkladı. Bu makale, sunumların nasıl oluşturulacağını ve kaydedileceğini açıklar. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfı bir sunumun içeriğini tutar. Sıfırdan bir sunum oluşturuyor ya da var olan bir sunumu değiştiriyor olun, işinizi bitirdiğinizde onu kaydetmek isteyeceksiniz. Aspose.Slides for Node.js ile bir **dosya**ya ya da **akış**a kaydedebilirsiniz. Bu makale, bir sunumu kaydetmenin farklı yollarını açıklar.

## **Sunumları Dosyalara Kaydet**

Bir sunumu dosyaya kaydetmek için [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının `save` metodunu çağırın. Metoda dosya adını ve kaydetme formatını geçirin. Aşağıdaki örnek, Aspose.Slides ile bir sunumu nasıl kaydedeceğinizi gösterir.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation();
try {
    // Burada bazı işlemler yapın...

    // Sunumu bir dosyaya kaydedin.
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sunumları Akışlara Kaydet**

Bir sunumu bir akışa kaydetmek için çıktıyı bir akış olarak [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının `save` metoduna geçirebilirsiniz. Bir sunum birçok akış türüne yazılabilir. Aşağıdaki örnekte yeni bir sunum oluşturup bir dosya akışına kaydediyoruz.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // Sunumu akışa kaydedin.
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Ön Tanımlı Görünüm Türü ile Sunumları Kaydet**

Aspose.Slides, oluşturulan sunum açıldığında PowerPoint'in kullandığı başlangıç görünümünü [ViewProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/viewproperties/) sınıfı aracılığıyla ayarlamanıza izin verir. [setLastView](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/viewproperties/#setLastView) metodunu, [ViewType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/viewtype/) enum'ından bir değerle kullanın.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sunumları Katı Office Open XML Formatında Kaydet**

Aspose.Slides, bir sunumu Katı Office Open XML formatında kaydetmenizi sağlar. Kaydederken [PptxOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pptxoptions/) sınıfını kullanın ve conformance özelliğini ayarlayın. [Conformance.Iso29500_2008_Strict] ayarlanırsa, çıktı dosyası Katı Office Open XML formatında kaydedilir.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation();
try {
    // Sunumu Katı Office Open XML formatında kaydedin.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Sunumları Office Open XML Formatında Zip64 Modunda Kaydet**

Office Open XML dosyası, sıkıştırılmamış herhangi bir dosyanın, sıkıştırılmış herhangi bir dosyanın ve arşivin toplam boyutunun 4 GB (2^32 bayt) sınırını getiren bir ZIP arşividir ve ayrıca arşivi 65 535 (2^16‑1) dosya ile sınırlar. ZIP64 formatı uzantıları bu sınırları 2^64’e yükseltir.

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) metodu, bir Office Open XML dosyası kaydederken ZIP64 formatı uzantılarını ne zaman kullanacağınızı seçmenizi sağlar.

Bu yöntem aşağıdaki modlarla kullanılabilir:

- [IfNecessary](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/zip64mode/#IfNecessary) ZIP64 format uzantılarını yalnızca sunum yukarıdaki sınırlamaları aşarsa kullanır. Bu varsayılan moddur.
- [Never](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/zip64mode/#Never) ZIP64 format uzantılarını asla kullanmaz.
- [Always](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/zip64mode/#Always) ZIP64 format uzantılarını her zaman kullanır.

Aşağıdaki kod, ZIP64 format uzantıları etkinleştirilmiş bir PPTX dosyası olarak bir sunumun nasıl kaydedileceğini gösterir:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setZip64Mode(aspose.slides.Zip64Mode.Always);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOT" color="warning" %}}
Zip64Mode.Never ile kaydettiğinizde, sunum ZIP32 formatında kaydedilemezse bir [PptxException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pptxexception/) hatası fırlatılır.
{{% /alert %}}

## **Sunumları Office Open XML Formatında Sıkıştırma Düzeyleriyle Kaydet**

Büyük sunumlarla çalışırken, dosya boyutu ve işleme süresi arasında denge kurmak için sıkıştırma düzeyini ayarlayabilirsiniz. Gereksinimlerinize bağlı olarak daha hızlı işleme veya daha küçük çıktı dosyaları tercih edebilirsiniz.

Aspose.Slides, Office Open XML formatında bir sunumu kaydederken kullanılan sıkıştırma düzeyini belirtmenizi sağlayan [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel) metodunu sunar.

Aşağıdaki sıkıştırma düzeyleri mevcuttur:

- [**None**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compressionlevel/#None): Sıkıştırma uygulanmaz. Dosyalar olduğu gibi saklanır.
- [**Level1**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compressionlevel/#Level1): En hızlı sıkıştırma, en düşük sıkıştırma oranı.
- [**Level2**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compressionlevel/#Level2): Daha hızlı sıkıştırma, **Level1**’e göre biraz daha iyi sıkıştırma oranı.
- [**Level3**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compressionlevel/#Level3): **Level2**'ye göre daha iyi sıkıştırma, işleme süresi üzerinde orta düzeyde etki.
- [**Level4**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compressionlevel/#Level4): **Level3**'e göre daha iyi sıkıştırma.
- [**Level5**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compressionlevel/#Level5): **Level4**'e göre geliştirilmiş sıkıştırma, ek işleme süresi.
- [**Level6**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compressionlevel/#Level6): Standart sıkıştırma, işleme hızı ve dosya boyutu arasında iyi bir denge sunar. Bu *varsayılan sıkıştırma düzeyi*dir.
- [**Level7**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compressionlevel/#Level7): **Level6**'dan daha iyi sıkıştırma, daha yavaş işleme.
- [**Level8**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compressionlevel/#Level8): **Level7**'den daha iyi sıkıştırma.
- [**Level9**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/compressionlevel/#Level9): Maksimum sıkıştırma. En uzun işleme süresi karşılığında en küçük dosya boyutunu üretir.

Aşağıdaki örnek, bir sunumu *sıkıştırma olmadan* PPTX dosyası olarak nasıl kaydedeceğinizi gösterir:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.None);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

Bu örnek, bir sunumu *maksimum sıkıştırma* ile PPTX dosyası olarak nasıl kaydedeceğinizi gösterir:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **Küçük Resmi Yenilemeden Sunumları Kaydet**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) metodu, bir sunumu PPTX olarak kaydederken küçük resim (thumbnail) oluşturulmasını kontrol eder:

- `true` olarak ayarlandığında, kaydetme sırasında küçük resim yenilenir. Bu varsayılandır.
- `false` olarak ayarlandığında, mevcut küçük resim korunur. Sunumun küçük resmi yoksa, hiçbir şey oluşturulmaz.

Aşağıdaki kodda, sunum küçük resmi yenilenmeden PPTX olarak kaydedilir.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setRefreshThumbnail(false);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Bilgi" color="info" %}}
Bu seçenek, PPTX formatında bir sunumu kaydetme süresini azaltmaya yardımcı olur.
{{% /alert %}}

## **İlerleme Güncellemelerini Yüzde Olarak Kaydet**

Kaydetme ilerlemesi raporlaması, [SaveOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/saveoptions/) ve alt sınıfları üzerindeki [setProgressCallback](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) metodu aracılığıyla yapılandırılır. [IProgressCallback](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iprogresscallback/) arayüzünü uygulayan bir Java vekili sağlayın; dışa aktarım sırasında geri arama periyodik yüzde güncellemeleri alır.

Aşağıdaki kod parçacıkları, `IProgressCallback` kullanımını gösterir.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // Burada ilerleme yüzde değerini kullanın.
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

let saveOptions = new aspose.slides.PdfOptions();
saveOptions.setProgressCallback(ExportProgressHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", aspose.slides.SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Bilgi" color="info" %}}
Aspose, kendi API'sini kullanarak [ücretsiz PowerPoint Splitter uygulaması](https://products.aspose.app/slides/tr/splitter) geliştirdi. Uygulama, seçilen slaytları yeni PPTX veya PPT dosyaları olarak kaydederek bir sunumu birden fazla dosyaya bölmenizi sağlar.
{{% /alert %}}

## **SSS**

**“Hızlı kaydet” (artımlı kaydetme) yalnızca değişikliklerin yazılması için destekleniyor mu?**

Hayır. Kaydetme her seferinde tam hedef dosyayı oluşturur; artımlı “hızlı kaydet” desteklenmez.

**Aynı Presentation örneğini birden fazla thread'den kaydetmek güvenli mi?**

Hayır. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) örneği [thread‑safe değildir](/slides/tr/nodejs-java/multithreading/); tek bir thread'den kaydedilmelidir.

**Kaydederken hiperlinkler ve dışa bağlı dosyalar ne olur?**

[Hiperlinkler](/slides/tr/nodejs-java/manage-hyperlinks/) korunur. Dışarıdan bağlı dosyalar (örneğin göreli yollarla videolar) otomatik olarak kopyalanmaz — referans verilen yolların erişilebilir olduğundan emin olun.

**Belge meta verilerini (Yazar, Başlık, Şirket, Tarih) ayarlayıp/kaydedebilir miyim?**

Evet. Standart [belge özellikleri](/slides/tr/nodejs-java/presentation-properties/) desteklenir ve kaydetme sırasında dosyaya yazılır.