---
title: JavaScript'te Sunum Bilgilerini Al ve Güncelle
linktitle: Sunum Bilgileri
type: docs
weight: 30
url: /tr/nodejs-java/examine-presentation/
keywords:
- sunum formatı
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
description: "JavaScript kullanarak PowerPoint ve OpenDocument sunumlarındaki slaytları, yapıyı ve meta verileri keşfedin; daha hızlı içgörüler ve daha akıllı içerik denetimleri için."
---
## **Genel Bakış**

Aspose.Slides, bir sunumun formatını belirleyebilir ve tam bir sunum nesne modeli oluşturmadan belge meta verilerini okuyabilir. Bu, dosyaları sınıflandırmanız, bir envanter oluşturmanız veya sunum içeriğini yükleyip işleme kararı vermeden önce özellikleri incelemeniz gerektiğinde kullanışlıdır.

Bu makale, hafif incelemeyi [PresentationFactory](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationfactory/) ve [PresentationInfo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/) üzerinden, ayrıca hedefli güncellemeleri [DocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/) ile göstermektedir.

## **Sunum Formatını Kontrol Et**

Zaten yüklü bir sunumunuz varsa, yükleme sonrası tespit ve eski PPT, PPS ve POT akışlarının sınırlamaları için [Determine the Original Presentation Format](/slides/tr/nodejs-java/detect-presentation-source-format/) sayfasına bakın.

[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) yöntemini kullanarak bir dosyayı [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) örneği oluşturmadan inceleyebilirsiniz. [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/getloadformat/) yöntemi, PPTX, PPT veya ODP gibi tespit edilen formatı raporlar.

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

    console.log(`${fileName}: ${formatName}`);
}
```

## **Hafif Bir Sunum Envanteri Oluştur**

Birçok sunum dosyasını işlediğinizde, doğrulama, dizinleme veya bir belge yönetim sistemi için kompakt bir envantere ihtiyaç duyabilirsiniz. Bu senaryoda, [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) kullanarak bir [PresentationInfo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/) nesnesi alın ve ardından [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) çağrısıyla belge meta verilerini okuyun. Bu yaklaşım bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) örneği yaratmaz ve tam sunum nesne modelini dolaşmanızı gerektirmez.

[DocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/) tarafından sunulan genişletilmiş özellikler aşağıdaki envanter değerlerini sağlar:

| Yöntem | Envanter değeri |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/#getSlides) | Toplam slayt sayısı. |
| [getHiddenSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | Gizli slayt sayısı. |
| [getNotes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/#getNotes) | Not içeren slayt sayısı. |
| [getParagraphs](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | Mevcut olduğunda toplam paragraf sayısı. |
| [getWords](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/#getWords) | Toplam kelime sayısı. |
| [getMultimediaClips](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | Toplam ses ve video klip sayısı. |

Aşağıdaki örnek bu değerleri bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) nesnesi oluşturmadan okur ve kompakt bir envanter yazdırır. Ayrıca [DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs) ile [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) birleştirilerek fontlar, temalar ve slayt başlıkları gibi içerik grupları gösterilir.

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

Her bir [HeadingPair](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/headingpair/) grup adını [HeadingPair.getName](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/headingpair/#getName) ile ve o gruptaki öğe sayısını [HeadingPair.getCount](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/headingpair/#getCount) ile sağlar. [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) düz, sıralı bir dizi döndürdüğü için her başlık çiftinin belirttiği ardışık başlık sayısı kadar tüketilmelidir.

### **Depolanan Meta Veriler ve Format Sınırlamaları**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) tarafından döndürülen envanter özellikleri, kaynak belgede mevcut olan meta verileri yansıtır. Aspose.Slides bu çağrı için bu değerleri yeniden hesaplamak amacıyla sunum nesne modelini yüklemez ve dolaşmaz. Eksik özellikler varsayılan değerlerle temsil edilir ve saklanan değerler, dosyayı son kaydeden uygulama belge özelliklerini güncellememişse eski olabilir.

- **PPTX:** Format, slayt, not, gizli‑slayt, paragraf, kelime ve multimedya sayımları ile başlık çiftleri ve parça başlıkları için genişletilmiş belge özellikleri sağlar. Kullanılabilirlik, belge üreticisinin hangi özellikleri yazdığına bağlıdır.
- **PPT:** İkili format ilgili belge‑özet özelliklerini depolayabilir. Bir özellik eksikse veya belge üreticisi tarafından yenilenmemişse, Aspose.Slides bu özelliği slaytlardan hesaplamak yerine saklanan ya da varsayılan değerini döndürür.
- **ODP:** OpenDocument meta verileri sayfa, paragraf ve kelime sayısı gibi genel istatistikler sunar, ancak bu değerler her PowerPoint‑özel genişletilmiş özelliğe eşlenmez. Gizli‑slayt, not‑slaytı, multimedya, başlık‑çifti ve parça‑başlığı meta verileri mevcut olmayabilir ve envanter özellikleri varsayılan değer döndürebilir. Sıfır değerini veya boş diziyi, ilgili içeriğin yokluğunun kesin kanıtı olarak değerlendirmeyin.

Envanterler ve ön kontrol için hafif meta veri yaklaşımını kullanın. Sonucun bellek içi değişiklikleri yansıtması gerektiğinde veya gerçek sunum içeriğini doğrulamanız gerektiğinde sunumu yükleyin ve canlı nesne modelini inceleyin.

## **Sunum Özelliklerini Güncelle**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) tarafından döndürülen özellikler, bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) örneği oluşturulmadan da değiştirilebilir. Değişiklikleri [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/) ile uygulayın ve ardından bağlı sunumu [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/) ile yazın.

Orijinal belge özellikleri aşağıdaki görselde gösterilmiştir.

![PowerPoint sunumunun orijinal belge özellikleri](input_properties.png)

Aşağıdaki örnek başlığı ve son‑kaydetme zamanını değiştirir ve sonucu yeni bir dosyaya yazar:

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

Güncellenmiş belge özellikleri aşağıdaki görselde gösterilmiştir.

![PowerPoint sunumunun değiştirilen belge özellikleri](output_properties.png)

## **Faydalı Bağlantılar**

İlgili güvenlik kontrolleri ve koruma ayarları için aşağıdaki makalelere bakın:

- [Sunumları Parola ile Koruma](/slides/tr/nodejs-java/password-protected-presentation/)
- [Sunumları Yazma Koruması ile Koru](/slides/tr/nodejs-java/write-protected-presentation/)

## **SSS**

**Yazı tiplerinin gömülü olup olmadığını ve hangileri olduğunu nasıl kontrol edebilirim?**

Sunumu yükleyin ve [Presentation.getFontsManager](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getfontsmanager/) yöntemini kullanın. Gömülü yazı tiplerini elde etmek için [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) ve sunumda kullanılan yazı tiplerini almak için [FontsManager.getFonts](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsmanager/getfonts/) çağırın. İki sonucu karşılaştırarak, render için gerekli ama gömülmemiş yazı tiplerini bulabilirsiniz.

**Dosyanın gizli slaytlara sahip olup olmadığını ve sayısını nasıl hızlıca öğrenebilirim?**

Depolanmış belge meta verileri yeterli olduğunda, [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) ve [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) aracılığıyla [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) okuyun. Bu, hafif bir envanter için uygundur. Sunum bellek içinde değiştirilmişse, saklanan meta verileri eksik ya da eski olabilir; bu durumda canlı değerleri doğrulamak için [Presentation.getSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getslides/) döngüsüyle her slaytı inceleyin ve [Slide.getHidden](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/gethidden/) metodunu kontrol edin.

**Özel slayt boyutu ve yöneliminin kullanılıp kullanılmadığını ve varsayılanlardan farklı olup olmadığını tespit edebilir miyim?**

Evet. Sunumu yükleyin ve [Presentation.getSlideSize](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getslidesize/) metodunu çağırın. Mevcut ayarları beklenen ön ayar ve boyutlarla karşılaştırmak için [SlideSize.getType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidesize/gettype/), [SlideSize.getSize](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidesize/getsize/) ve [SlideSize.getOrientation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidesize/getorientation/) kullanın.

**Grafiklerin harici veri kaynaklarına başvurup başvurmadığını hızlı bir şekilde nasıl görebilirim?**

Her bir [Chart](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chart/) öğesini bulun ve [ChartData.getDataSourceType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) metodunu çağırın. Harici bir çalışma kitabı için [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) metodunu kullanın. Veri kaynağı türü ve yolu dış referansı tanımlasa da, hedefin erişilebilir olup olmadığını doğrulamak ayrı bir kaynak kontrolü gerektirir.

**Render süresini veya PDF dışa aktarımını yavaşlatabilecek 'ağır' slaytları nasıl değerlendirebilirim?**

Tek bir karmaşıklık özelliği yoktur. [Presentation.getSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getslides/) ve her slaydın [BaseSlide.getShapes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseslide/#getShapes) koleksiyonunu dolaşın. Şekil sayısı, büyük görseller, efektler, animasyonlar veya multimedya varlığı gibi sinyallerle tarama yapın ve bir temsili render veya dışa aktarım ölçümü alın; ardından bir slaytı kesin bir performans darboğazı olarak nitelendirin.