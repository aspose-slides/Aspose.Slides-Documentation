---
title: JavaScript'te Sunum Bilgilerini Getirme ve Güncelleme
linktitle: Sunum Bilgileri
type: docs
weight: 30
url: /tr/nodejs-java/examine-presentation/
keywords:
- sunum biçimi
- sunum özellikleri
- belge özellikleri
- özellikleri al
- özellikleri oku
- özellikleri değiştir
- özellikleri düzenle
- özellikleri güncelle
- PPTX incele
- PPT incele
- ODP incele
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript kullanarak PowerPoint ve OpenDocument sunumlarında slaytları, yapıyı ve meta verileri keşfedin; daha hızlı içgörüler ve daha akılcı içerik denetimleri sağlayın."
---
## **Genel Bakış**

Aspose.Slides, bir sunumun biçimini tanımlayabilir ve tam bir sunum nesne modeli oluşturmadan belge meta verilerini okuyabilir. Dosyaları sınıflandırmanız, bir envanter oluşturmanız veya sunum içeriğini yükleyip işlemeye karar vermeden önce özellikleri incelemeniz gerektiğinde bu kullanışlıdır.

Bu makale, hafif denetimi [PresentationFactory](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationfactory/) ve [PresentationInfo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/) aracılığıyla, ayrıca hedefli güncellemeleri [DocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/) kullanarak göstermektedir.

## **Sunum Biçimini Kontrol Etme**

[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) kullanarak bir dosyayı [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) örneği oluşturmadan inceleyin. [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/getloadformat/) yöntemi algılanan biçimi, örneğin PPTX, PPT veya ODP olarak raporlar.

```javascript
const aspose = require("aspose.slides.via.java");

const fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

for (const fileName of fileNames) {
    const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(fileName);
    const loadFormat = presentationInfo.getLoadFormat();
    let formatName = `Other (${loadFormat})`;

    if (loadFormat === aspose.LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat === aspose.LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat === aspose.LoadFormat.Odp) {
        formatName = "ODP";
    }

    console.log(`${fileName}: ${formatName`);
}
```

## **Hafif Bir Sunum Envanteri Oluşturma**

Birçok sunum dosyasını işlerken, doğrulama, indeksleme veya bir belge yönetim sistemi için kompakt bir envantere ihtiyacınız olabilir. Bu senaryoda, bir [PresentationInfo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/) nesnesi elde etmek için [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) kullanın ve ardından belge meta verilerini okumak için [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) çağırın. Bu yaklaşım bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) örneği oluşturmaz ve tam sunum nesne modelini dolaşmanızı gerektirmez.

[DocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/) tarafından sunulan genişletilmiş özellikler aşağıdaki envanter değerlerini sağlar:

| Yöntem | Envanter değeri |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/#getSlides) | Toplam slayt sayısı. |
| [getHiddenSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | Gizli slayt sayısı. |
| [getNotes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/#getNotes) | Not içeren slayt sayısı. |
| [getParagraphs](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | Mevcut olduğunda toplam paragraf sayısı. |
| [getWords](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/#getWords) | Toplam kelime sayısı. |
| [getMultimediaClips](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | Toplam ses ve video klip sayısı. |

Aşağıdaki örnek, bu değerleri bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) nesnesi oluşturmadan okuyup kompakt bir envanter yazdırır. Ayrıca [DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs) ile [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) kombinasyonunu kullanarak yazı tipleri, temalar ve slayt başlıkları gibi içerik gruplarını gösterir.

```javascript
const path = require("path");
const aspose = require("aspose.slides.via.java");

const filePath = "sample.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(filePath);
const documentProperties = presentationInfo.readDocumentProperties();

const loadFormat = presentationInfo.getLoadFormat();
let formatName = `Other (${loadFormat})`;

if (loadFormat === aspose.LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat === aspose.LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat === aspose.LoadFormat.Odp) {
    formatName = "ODP";
}

console.log(`File: ${path.basename(filePath)}`);
console.log(`Format: ${formatName}`);
console.log(`Title: ${documentProperties.getTitle()}`);
console.log(`Author: ${documentProperties.getAuthor()}`);
console.log("Statistics:");
console.log(`  Slides: ${documentProperties.getSlides()}`);
console.log(`  Hidden slides: ${documentProperties.getHiddenSlides()}`);
console.log(`  Slides with notes: ${documentProperties.getNotes()}`);
console.log(`  Paragraphs: ${documentProperties.getParagraphs()}`);
console.log(`  Words: ${documentProperties.getWords()}`);
console.log(`  Multimedia clips: ${documentProperties.getMultimediaClips()}`);

const headingPairs = documentProperties.getHeadingPairs() || [];
const titlesOfParts = documentProperties.getTitlesOfParts() || [];
let partIndex = 0;

if (headingPairs.length === 0 || titlesOfParts.length === 0) {
    console.log("Content groups: not available");
} else {
    console.log("Content groups:");

    for (const headingPair of headingPairs) {
        const partCount = headingPair.getCount();
        console.log(`  ${headingPair.getName()} (${partCount})`);

        for (let partOffset = 0; partOffset < partCount && partIndex < titlesOfParts.length; partOffset++) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        console.log("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }
}
```

Her [HeadingPair], grup adını [HeadingPair.getName](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/headingpair/#getName) aracılığıyla ve grup içindeki öğe sayısını [HeadingPair.getCount](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/headingpair/#getCount) ile sağlar. [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) düz, sıralı bir dizi döndürür; bu yüzden her başlık çiftinin belirttiği ardışık başlık sayısını tüketin.

### **Depolanmış Meta Veriler ve Biçim Sınırlamaları**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) tarafından döndürülen envanter özellikleri, kaynak belgede mevcut meta verileri yansıtır. Aspose.Slides, bu çağrı için bu değerleri yeniden hesaplamak amacıyla sunum nesne modelini yüklemez ve dolaşmaz. Eksik özellikler varsayılan değerlerle temsil edilir ve saklanan değerler, dosyayı son kaydeden uygulama belge özelliklerini güncellememişse güncel olmayabilir.

- **PPTX:** Biçim, slayt, not, gizli slayt, paragraf, kelime ve multimedya sayımları için genişletilmiş belge özellikleri ile başlık çiftleri ve bölüm başlıkları sunar. Kullanılabilirlik, belge üreticisinin hangi özellikleri yazdığına bağlıdır.
- **PPT:** İkili format, karşılık gelen belge‑özet özelliklerini depolayabilir. Bir özellik yoksa veya belge üreticisi tarafından yenilenmemişse, Aspose.Slides, slaytlardan hesaplamak yerine saklanan ya da varsayılan değerini döner.
- **ODP:** OpenDocument meta verileri, sayfa, paragraf ve kelime sayısı gibi genel belge istatistikleri sağlar, ancak bu değerler her PowerPoint‑özelliğine özgü genişletilmiş özelliğe eşlenmez. Gizli slayt, not slaytı, multimedya, başlık çifti ve bölüm başlığı meta verileri mevcut olmayabilir ve envanter özellikleri varsayılan değer dönebilir. Sıfır değerini veya boş bir diziyi, ilgili içeriğin bulunmadığının kesin kanıtı olarak değerlendirmeyin.

Envanterler ve ön incelemeler için hafif meta veri yaklaşımını kullanın. Sonucun bellek içi değişiklikleri yansıtması gerektiğinde veya gerçek sunum içeriğini doğrulamanız gerektiğinde, sunumu yükleyip canlı nesne modelini inceleyin.

## **Sunum Özelliklerini Güncelleme**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) tarafından döndürülen özellikler, bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) örneği oluşturmadan da değiştirilebilir. Değişiklikleri [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/) ile uygulayın ve ardından bağlanmış sunumu [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/) ile yazın.

Aşağıdaki resim, orijinal belge özelliklerini göstermektedir.

![PowerPoint sunumunun orijinal belge özellikleri](input_properties.png)

Aşağıdaki örnek, başlığı ve son kaydetme zamanını değiştirir ve sonucu yeni bir dosyaya yazar:

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");

const sourceFile = "sample.pptx";
const outputFile = "sample_with_updated_properties.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(sourceFile);
const documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

presentationInfo.updateDocumentProperties(documentProperties);
const outputStream = java.newInstanceSync("java.io.FileOutputStream", outputFile);
try {
    presentationInfo.writeBindedPresentation(outputStream);
} finally {
    outputStream.close();
}
```

Aşağıdaki resim, güncellenmiş belge özelliklerini göstermektedir.

![PowerPoint sunumunun değiştirilen belge özellikleri](output_properties.png)

## **Yararlı Bağlantılar**

İlgili güvenlik kontrolleri ve koruma ayarları için aşağıdaki makalelere bakın:

- [Sunumları Parola ile Korumak](/slides/tr/nodejs-java/password-protected-presentation/)
- [Sunumları Yazma Koruması ile Koruma](/slides/tr/nodejs-java/write-protected-presentation/)

## **SSS**

**Yazı tiplerinin gömülü olup olmadığını ve hangileri olduğunu nasıl kontrol edebilirim?**

Sunumu yükleyin ve [Presentation.getFontsManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getfontsmanager/) kullanın. Gömülü yazı tiplerini elde etmek için [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) çağırın ve sunumda kullanılan yazı tiplerini elde etmek için [FontsManager.getFonts](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsmanager/getfonts/) kullanın. İki sonucu karşılaştırarak render için gerekli ancak gömülmemiş yazı tiplerini bulun.

**Dosyanın gizli slaytları olup olmadığını ve kaç tane olduğunu nasıl hızlıca öğrenebilirim?**

Depolanmış belge meta verileri yeterli olduğunda, [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) ve [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) aracılığıyla [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) okuyun. Bu, hafif bir envanter için uygundur. Sunum bellek içinde değiştirilmişse, saklanan meta veriler eksik ya da güncel olmayabilir; bu durumda canlı değerleri doğrulamak için [Presentation.getSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getslides/) üzerinden döngü yapıp her slaytın [Slide.getHidden](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/gethidden/) metodunu inceleyin.

**Özel slayt boyutu ve yöneliminin kullanılıp kullanılmadığını ve varsayılanlardan farklı olup olmadığını tespit edebilir miyim?**

Evet. Sunumu yükleyin ve [Presentation.getSlideSize](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getslidesize/) çağırın. Mevcut ayarları beklenen ön ayar ve boyutlarla karşılaştırmak için [SlideSize.getType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidesize/gettype/), [SlideSize.getSize](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidesize/getsize/) ve [SlideSize.getOrientation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidesize/getorientation/) kullanın.

**Grafiklerin harici veri kaynaklarına referans verip vermediğini hızlıca görmek mümkün mü?**

Evet. Her [Chart](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chart/) öğesini bulun ve [ChartData.getDataSourceType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) çağırın. Harici bir çalışma kitabı için [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) kullanın. Veri kaynağı türü ve yol, harici referansı gösterir, ancak hedefin erişilebilir olup olmadığını doğrulamak ayrı bir kaynak kontrolü gerektirir.

**Render veya PDF dışa aktarma işlemlerini yavaşlatabilecek 'ağır' slaytları nasıl değerlendirebilirim?**

Tek bir karmaşıklık özelliği yoktur. [Presentation.getSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getslides/) ve her slaydın [BaseSlide.getShapes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseslide/#getShapes) koleksiyonunu dolaşın. Şekil sayısı ve büyük resimler, efektler, animasyonlar veya multimedya varlığı gibi sinyalleri tarama göstergesi olarak kullanın ve bir slaytı kesin bir performans darboğazı olarak kabul etmeden önce temsilî bir render veya dışa aktarma ölçümü yapın.