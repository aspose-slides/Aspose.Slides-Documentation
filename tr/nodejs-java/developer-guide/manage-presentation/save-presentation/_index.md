---
title: JavaScript ile Sunumları Kaydet
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
- sunumu dosyaya
- sunumu akışa
- önceden tanımlı görünüm türü
- Katı Office Open XML Biçimi
- Zip64 modu
- küçük resmi yenileme
- kaydetme ilerlemesi
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js kullanarak Java üzerinden sunumları nasıl kaydedeceğinizi keşfedin—düzenleri, yazı tiplerini ve efektleri koruyarak PowerPoint veya OpenDocument olarak dışa aktarın."
---
## **Genel Bakış**

[Open Presentations in JavaScript](/slides/tr/nodejs-java/open-presentation/) sunumları JavaScript'te nasıl açacağınızı gösterir. Bu makale, sunumları nasıl oluşturacağınızı ve kaydedeceğinizi açıklar. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfı bir sunumun içeriğini barındırır. Sıfırdan bir sunum oluşturuyor veya mevcut bir sunumu değiştiriyor olun, işiniz bittiğinde kaydetmek isteyeceksiniz. Aspose.Slides for Node.js ile bir **dosyaya** veya **akışa** kaydedebilirsiniz. Bu makale, bir sunumu kaydetmenin farklı yollarını açıklar.

## **Sunumları Dosyalara Kaydetme**

Bir sunumu dosyaya kaydetmek için [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının `save` yöntemini çağırın. Yönteme dosya adını ve kaydetme biçimini geçirin. Aşağıdaki örnek, Aspose.Slides ile bir sunumu nasıl kaydedeceğinizi gösterir.

```js
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

## **Sunumları Akışlara Kaydetme**

Bir sunumu, çıkış akışını [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının `save` yöntemine geçirerek akışa kaydedebilirsiniz. Bir sunum birçok akış türüne yazılabilir. Aşağıdaki örnekte yeni bir sunum oluşturup bir dosya akışına kaydediyoruz.

```js
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

## **Önceden Tanımlı Görünüm Türüyle Sunumları Kaydetme**

Aspose.Slides, oluşturulan sunum açıldığında PowerPoint'in kullandığı ilk görünümü [ViewProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/viewproperties/) sınıfı aracılığıyla ayarlamanıza izin verir. [setLastView](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/viewproperties/#setLastView) yöntemini, [ViewType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/viewtype/) enum'undan bir değerle kullanın.

```js
let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sunumları Katı Office Open XML Biçiminde Kaydetme**

Aspose.Slides, bir sunumu Katı Office Open XML biçiminde kaydetmenize olanak tanır. Kaydederken [PptxOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pptxoptions/) sınıfını kullanın ve uyum özelliğini ayarlayın. [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict) ayarlanırsa, çıktı dosyası Katı Office Open XML biçiminde kaydedilir.

Aşağıdaki örnek bir sunum oluşturur ve Katı Office Open XML biçiminde kaydeder.

```js
let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation();
try {
    // Sunumu Katı Office Open XML biçiminde kaydedin.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Sunumları Office Open XML Biçiminde Zip64 Modunda Kaydetme**

Bir Office Open XML dosyası, sıkıştırılmamış herhangi bir dosyanın, sıkıştırılmış herhangi bir dosyanın ve arşivin toplam boyutunun 4 GB (2^32 bayt) sınırına tabi olduğu bir ZIP arşividir ve aynı zamanda arşivde 65 535 (2^16‑1) dosya sınırı vardır. ZIP64 biçim uzantıları bu sınırları 2^64’e yükseltir.

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) yöntemi, bir Office Open XML dosyası kaydedilirken ZIP64 uzantılarının ne zaman kullanılacağını seçmenizi sağlar.

Bu yöntem aşağıdaki modlarla kullanılabilir:

- [IfNecessary](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/zip64mode/#IfNecessary) yalnızca sunum yukarıdaki sınırlamaları aşarsa ZIP64 uzantılarını kullanır. Bu varsayılan moddur.
- [Never](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/zip64mode/#Never) ZIP64 uzantılarını asla kullanmaz.
- [Always](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/zip64mode/#Always) ZIP64 uzantılarını her zaman kullanır.

Aşağıdaki kod, ZIP64 uzantıları etkinleştirilmiş bir PPTX olarak sunumu nasıl kaydedeceğinizi gösterir:

```js
let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setZip64Mode(aspose.slides.Zip64Mode.Always);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
[Zip64Mode.Never](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/zip64mode/#Never) ile kaydettiğinizde, sunum ZIP32 biçiminde kaydedilemezse bir [PptxException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pptxexception/) fırlatılır.
{{% /alert %}}

## **Küçük Resmi Yenilemeden Sunumları Kaydetme**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) yöntemi, bir sunumu PPTX olarak kaydederken küçük resim oluşturulmasını kontrol eder:

- `true` olarak ayarlanırsa, kaydetme sırasında küçük resim yenilenir. Bu varsayılandır.
- `false` olarak ayarlanırsa, mevcut küçük resim korunur. Sunumun küçük resmi yoksa hiçbir şey oluşturulmaz.

Aşağıdaki kodda sunum, küçük resmi yenilenmeden PPTX olarak kaydedilir.

```js
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

{{% alert title="Info" color="info" %}}
Bu seçenek, PPTX biçiminde bir sunumu kaydetme süresini azaltmaya yardımcı olur.
{{% /alert %}}

## **Kaydetme İlerleme Güncellemelerini Yüzde Olarak Kaydetme**

Kaydetme ilerleme raporlaması, [SaveOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/saveoptions/) ve alt sınıfları üzerindeki [setProgressCallback](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) yöntemiyle yapılandırılır. Java'da [IProgressCallback](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iprogresscallback/) arayüzünü uygulayan bir proxy sağlayın; dışa aktarım sırasında geri çağırma periyodik yüzde güncellemeleri alır.

Aşağıdaki kod parçacıkları `IProgressCallback` kullanımını gösterir.

```javascript
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

{{% alert title="Info" color="info" %}}
Aspose, kendi API'sini kullanarak ücretsiz bir [PowerPoint Splitter uygulaması](https://products.aspose.app/slides/tr/splitter) geliştirdi. Uygulama, seçili slaytları yeni PPTX veya PPT dosyaları olarak kaydederek bir sunumu birden çok dosyaya bölmenize olanak tanır.
{{% /alert %}}

## **SSS**

**"Hızlı kaydetme" (artımlı kaydetme) yalnızca değişikliklerin yazılmasını destekliyor mu?**

Hayır. Kaydetme her seferinde tam hedef dosyayı oluşturur; artımlı "hızlı kaydetme" desteklenmez.

**Aynı Presentation örneğini birden fazla iş parçacığından kaydetmek güvenli mi?**

Hayır. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) örneği [thread‑safe değildir](/slides/tr/nodejs-java/multithreading/); tek bir iş parçacığından kaydedilmelidir.

**Kaydedilirken köprüler ve harici bağlı dosyalar ne olur?**

[Hyperlinks](/slides/tr/nodejs-java/manage-hyperlinks/) korunur. Harici bağlı dosyalar (örneğin, göreli yollarla eklenen videolar) otomatik olarak kopyalanmaz—referans verilen yolların erişilebilir olduğundan emin olun.

**Belge meta verilerini (Yazar, Başlık, Şirket, Tarih) ayarlayıp kaydedebilir miyim?**

Evet. Standart [belge özellikleri](/slides/tr/nodejs-java/presentation-properties/) desteklenir ve kaydetme sırasında dosyaya yazılır.