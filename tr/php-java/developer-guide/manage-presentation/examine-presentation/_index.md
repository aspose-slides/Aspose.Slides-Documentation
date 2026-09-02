---
title: "PHP'de Sunum Bilgilerini Al ve Güncelle"
linktitle: Sunum Bilgileri
type: docs
weight: 30
url: /tr/php-java/examine-presentation/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP kullanarak PowerPoint ve OpenDocument sunumlarında slaytları, yapıyı ve meta verileri keşfedin; daha hızlı içgörüler ve daha akıllı içerik denetimleri sağlayın."
---
## **Genel Bakış**

Aspose.Slides, bir sunumun formatını belirleyebilir ve tam bir sunum nesne modeli oluşturmadan belge meta verilerini okuyabilir. Bu, dosyaları sınıflandırmanız, bir envanter oluşturmanız veya sunum içeriğini yükleyip işlemeye karar vermeden önce özellikleri incelemeniz gerektiğinde faydalıdır.

Bu makale, [PresentationFactory](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationfactory/) ve [PresentationInfo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationinfo/) aracılığıyla hafif denetimi, ayrıca [DocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties/) aracılığıyla hedeflenmiş güncellemeleri gösterir.

## **Sunum Formatını Kontrol Etme**

[PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationfactory/) kullanarak bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) örneği oluşturmadan bir dosyayı inceleyebilirsiniz. [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationinfo/#getLoadFormat) yöntemi, PPTX, PPT veya ODP gibi tespit edilen formatı raporlar.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

foreach ($fileNames as $fileName) {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($fileName);
    $loadFormat = java_values($presentationInfo->getLoadFormat());
    $formatName = "Other (" . $loadFormat . ")";

    if ($loadFormat === LoadFormat::Pptx) {
        $formatName = "PPTX";
    } elseif ($loadFormat === LoadFormat::Ppt) {
        $formatName = "PPT";
    } elseif ($loadFormat === LoadFormat::Odp) {
        $formatName = "ODP";
    }

    echo $fileName . ": " . $formatName . PHP_EOL;
}
```

## **Hafif Bir Sunum Envanteri Oluşturma**

Birçok sunum dosyasını işlediğinizde, doğrulama, indeksleme veya bir belge yönetim sistemi için kompakt bir envantere ihtiyaç duyabilirsiniz. Bu senaryoda, [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationfactory/) kullanarak bir [PresentationInfo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationinfo/) nesnesi elde edin ve ardından [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationinfo/#readDocumentProperties) çağırarak belge meta verilerini okuyun. Bu yaklaşım bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) örneği oluşturmaz ve tam sunum nesne modelini dolaşmanızı gerektirmez.

[DocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties/) tarafından sunulan genişletilmiş özellikler aşağıdaki envanter değerlerini sağlar:

| Yöntem | Envanter değeri |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties/#getSlides) | Toplam slayt sayısı. |
| [getHiddenSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties/#getHiddenSlides) | Gizli slayt sayısı. |
| [getNotes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties/#getNotes) | Not içeren slayt sayısı. |
| [getParagraphs](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties/#getParagraphs) | Mevcut olduğunda toplam paragraf sayısı. |
| [getWords](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties/#getWords) | Toplam kelime sayısı. |
| [getMultimediaClips](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties/#getMultimediaClips) | Toplam ses ve video klip sayısı. |

Aşağıdaki örnek bu değerleri bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) nesnesi oluşturmadan okur ve kompakt bir envanter yazdırır. Ayrıca [DocumentProperties::getHeadingPairs](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties/#getHeadingPairs) ile [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties/#getTitlesOfParts) birleştirilerek yazı tipleri, temalar ve slayt başlıkları gibi içerik grupları görüntülenir.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$filePath = "sample.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);
$documentProperties = $presentationInfo->readDocumentProperties();

$loadFormat = java_values($presentationInfo->getLoadFormat());
$formatName = "Other (" . $loadFormat . ")";

if ($loadFormat === LoadFormat::Pptx) {
    $formatName = "PPTX";
} elseif ($loadFormat === LoadFormat::Ppt) {
    $formatName = "PPT";
} elseif ($loadFormat === LoadFormat::Odp) {
    $formatName = "ODP";
}

echo "File: " . basename($filePath) . PHP_EOL;
echo "Format: " . $formatName . PHP_EOL;
echo "Title: " . java_values($documentProperties->getTitle()) . PHP_EOL;
echo "Author: " . java_values($documentProperties->getAuthor()) . PHP_EOL;
echo "Statistics:" . PHP_EOL;
echo "  Slides: " . java_values($documentProperties->getSlides()) . PHP_EOL;
echo "  Hidden slides: " . java_values($documentProperties->getHiddenSlides()) . PHP_EOL;
echo "  Slides with notes: " . java_values($documentProperties->getNotes()) . PHP_EOL;
echo "  Paragraphs: " . java_values($documentProperties->getParagraphs()) . PHP_EOL;
echo "  Words: " . java_values($documentProperties->getWords()) . PHP_EOL;
echo "  Multimedia clips: " . java_values($documentProperties->getMultimediaClips()) . PHP_EOL;

$headingPairs = $documentProperties->getHeadingPairs();
$titlesOfParts = $documentProperties->getTitlesOfParts();

if (java_is_null($headingPairs) || java_is_null($titlesOfParts)) {
    echo "Content groups: not available" . PHP_EOL;
} else {
    $headingPairs = java_values($headingPairs);
    $titlesOfParts = java_values($titlesOfParts);
    $partIndex = 0;

    if (count($headingPairs) === 0 || count($titlesOfParts) === 0) {
        echo "Content groups: not available" . PHP_EOL;
    } else {
        echo "Content groups:" . PHP_EOL;

        foreach ($headingPairs as $headingPair) {
            $partCount = java_values($headingPair->getCount());
            echo "  " . java_values($headingPair->getName()) . " (" . $partCount . ")" . PHP_EOL;

            for ($partOffset = 0; $partOffset < $partCount && $partIndex < count($titlesOfParts); $partOffset++) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }

        if ($partIndex < count($titlesOfParts)) {
            echo "  Other parts:" . PHP_EOL;

            while ($partIndex < count($titlesOfParts)) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }
    }
}
```

Her [HeadingPair](https://reference.aspose.com/slides/tr/php-java/aspose.slides/headingpair/) bir grup adı ve o gruptaki öğe sayısını sağlar. [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties/#getTitlesOfParts) düz, sıralı bir dizi döndürdüğü için, her başlık çiftinin belirttiği ardışık başlık sayısını tüketin.

### **Depolanmış Meta Veriler ve Format Kısıtlamaları**

[PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationinfo/#readDocumentProperties) tarafından döndürülen envanter özellikleri, kaynak belgede mevcut meta verilere dayanır. Aspose.Slides, bu çağrı için bu değerleri yeniden hesaplamak amacıyla sunum nesne modelini yükleyip dolaşmaz. Eksik özellikler varsayılan değerlerle temsil edilir ve saklanan değerler, dosyayı son kaydeden uygulama belge özelliklerini güncellememişse eski olabilir.

- **PPTX:** Format, slayt, not, gizli‑slayt, paragraf, kelime ve multimedya sayımları ile başlık çiftleri ve bölüm başlıkları için genişletilmiş belge özellikleri sağlar. Kullanılabilirlik, belge üreticisinin hangi özellikleri yazdığına bağlıdır.
- **PPT:** İkili format, karşılık gelen belge‑özet özelliklerini depolayabilir. Bir özellik eksikse veya belge üreticisi tarafından yenilenmemişse, Aspose.Slides bu özelliği slaytlardan hesaplamak yerine saklanan veya varsayılan değerini döndürür.
- **ODP:** OpenDocument meta verileri, sayfa, paragraf ve kelime sayısı gibi genel belge istatistikleri sunar, ancak bu değerler her PowerPoint‑özel genişletilmiş özelliğe eşlenmez. Gizli‑slayt, not‑slaytı, multimedya, başlık‑çifti ve bölüm‑başlığı meta verileri mevcut olmayabilir ve envanter özellikleri varsayılan değer döndürebilir. Sıfır değeri veya boş diziyi, ilgili içeriğin yok olduğunun kesin kanıtı olarak değerlendirmeyin.

Envanter ve ön kontrol amaçları için hafif meta veri yaklaşımını kullanın. Sonuçların bellek içi değişiklikleri yansıtması gerektiğinde veya gerçek sunum içeriğini doğrulamanız gerektiğinde sunumu yükleyin ve canlı nesne modelini inceleyin.

## **Sunum Özelliklerini Güncelleme**

[PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationinfo/#readDocumentProperties) tarafından döndürülen özellikler, bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) örneği oluşturmadan da değiştirilebilir. Değişiklikleri [PresentationInfo::updateDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationinfo/#updateDocumentProperties) ile uygulayın ve ardından bağlanmış sunumu [PresentationInfo::writeBindedPresentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationinfo/#writeBindedPresentation) ile yazın.

Aşağıdaki resim orijinal belge özelliklerini gösterir.

![PowerPoint sunumunun orijinal belge özellikleri](input_properties.png)

Aşağıdaki örnek başlığı ve son‑kaydetme zamanını değiştirir ve sonucu yeni bir dosyaya yazar:

```php
use aspose\slides\PresentationFactory;

$sourceFile = "sample.pptx";
$outputFile = "sample_with_updated_properties.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($sourceFile);
$documentProperties = $presentationInfo->readDocumentProperties();

$documentProperties->setTitle("Quarterly sales report");
$documentProperties->setLastSavedTime(new Java("java.util.Date"));

$presentationInfo->updateDocumentProperties($documentProperties);
$outputStream = new Java("java.io.FileOutputStream", $outputFile);
try {
    $presentationInfo->writeBindedPresentation($outputStream);
} finally {
    $outputStream->close();
}
```

Aşağıdaki resim güncellenmiş belge özelliklerini gösterir.

![PowerPoint sunumunun değiştirilen belge özellikleri](output_properties.png)

## **Yararlı Bağlantılar**

İlgili güvenlik kontrolleri ve koruma ayarları için aşağıdaki makalelere bakın:

- [Parola ile Sunumları Koru](/slides/tr/php-java/password-protected-presentation/)
- [Yazma Korumasıyla Sunumlar](/slides/tr/php-java/write-protected-presentation/)

## **SSS**

**Yazı tiplerinin gömülü olup olmadığını ve hangileri olduğunu nasıl kontrol edebilirim?**

Sunumu yükleyin ve [Presentation::getFontsManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getFontsManager) kullanın. Gömülü yazı tiplerini elde etmek için [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts), sunum tarafından kullanılan yazı tiplerini elde etmek için ise [FontsManager::getFonts](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsmanager/#getFonts) çağırın. İki sonucu karşılaştırarak render için gerekli ancak gömülmemiş yazı tiplerini bulabilirsiniz.

**Dosyanın gizli slaytları olup olmadığını ve kaç tane olduğunu hızlıca nasıl öğrenebilirim?**

Depolanmış belge meta verileri yeterli olduğunda, [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationfactory/) ve [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationinfo/#readDocumentProperties) aracılığıyla [DocumentProperties::getHiddenSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/documentproperties/#getHiddenSlides) okuyun. Bu, hafif bir envanter için uygundur. Sunum bellek içinde değiştirilmişse, saklanan meta veri eksik veya eski olabilir; bu durumda canlı değerleri doğrulamak için [Presentation::getSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getSlides) üzerinden döngü yapıp her slaytın [Slide::getHidden](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/#getHidden) yöntemini inceleyin.

**Özel slayt boyutu ve yöneliminin kullanılıp kullanılmadığını ve varsayılanlardan farklı olup olmadığını nasıl tespit edebilirim?**

Evet. Sunumu yükleyin ve [Presentation::getSlideSize](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getSlideSize) çağırın. Mevcut ayarları beklenen ön ayar ve boyutlarla karşılaştırmak için [SlideSize::getType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidesize/#getType), [SlideSize::getSize](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidesize/#getSize) ve [SlideSize::getOrientation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidesize/#getOrientation) kullanın.

**Grafiklerin dış veri kaynaklarına başvurup başvurmadığını hızlıca görebilir miyim?**

Evet. Her bir [Chart](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/) bulun ve [ChartData::getDataSourceType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/#getDataSourceType) çağır. Dış bir çalışma kitabı için [ChartData::getExternalWorkbookPath](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/#getExternalWorkbookPath) çağır. Veri kaynağı türü ve yolu dış başvuruyu gösterir, ancak hedefin mevcut olup olmadığını doğrulamak ayrı bir kaynak kontrolü gerektirir.

**Render veya PDF dışa aktarımını yavaşlatabilecek 'ağır' slaytları nasıl değerlendirebilirim?**

Tek bir karmaşıklık özelliği yoktur. [Presentation::getSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getSlides) ve her slaydın [BaseSlide::getShapes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseslide/#getShapes) koleksiyonunu dolaşın. Şekil sayısı, büyük resimler, efektler, animasyonlar veya multimedya varlığı gibi sinyallerle tarama yapın ve bir slaydın performans darboğazı olduğunu doğrulamak için temsilci bir render veya dışa aktarma ölçümü alın.