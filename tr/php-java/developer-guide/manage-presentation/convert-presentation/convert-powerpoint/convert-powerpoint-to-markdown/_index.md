---
title: PowerPoint Sunumlarını PHP ile Markdown'a Dönüştür
linktitle: PowerPoint'ten Markdown'a
type: docs
weight: 140
url: /tr/php-java/convert-powerpoint-to-markdown/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten MD'ye
- sunumdan MD'ye
- slayttan MD'ye
- PPT'den MD'ye
- PPTX'den MD'ye
- PowerPoint'i Markdown olarak kaydet
- sunumu Markdown olarak kaydet
- slaytı Markdown olarak kaydet
- PPT'yi MD olarak kaydet
- PPTX'i MD olarak kaydet
- PPT'yi MD'ye dışa aktar
- PPTX'i MD'ye dışa aktar
- Markdown görüntü dışa aktarımı
- CDN görüntü bağlantıları
- PowerPoint
- sunum
- Markdown
- PHP
- Aspose.Slides
description: "PPT ve PPTX sunumlarını PHP'de Markdown'a dönüştürün ve dışa aktarılan bitmap, metafile ve SVG görüntülerinin nerede kaydedileceğini ve başvurulacağını kontrol edin."
---
## **Genel Bakış**

Aspose.Slides for PHP via Java, PPT ve PPTX sunumlarını belge, statik site, içerik taşıma ve sürüm kontrolü iş akışları için Markdown'a dönüştürebilir. Bir Markdown çeşidi seçebilir, slayt içeriğinin nasıl işleneceğini kontrol edebilir ve dışa aktarılan görüntülerin nerede saklanacağını ve oluşturulan Markdown'ın bunlara nasıl başvurduğunu belirleyebilirsiniz.

Varsayılan olarak, Markdown dışa aktarımı yalnızca metin çıktısı üretir. Görsel içeriği dışa aktarmak için, [MarkdownSaveOptions::setExportType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/markdownsaveoptions/) yöntemini kullanarak ihracat türünü [MarkdownExportType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/markdownexporttype/) enum'undan `Sequential` veya `Visual` değerine ayarlayın. `Sequential`, slayt öğelerini ayrı ayrı ve sırayla render ederken, `Visual` gruplanmış öğeleri birlikte tutarak görsel ilişkilerini korur. `TextOnly` değeri görüntü kaynakları üretmez, bu nedenle bu modda görüntü kaydetme geri aramaları yürütülmez.

## **Bir Sunumu Markdown'a Dönüştür**

Kaynak dosyayı [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfı ile yükleyin ve ardından [Presentation::save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) yöntemini, [SaveFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/saveformat/) enum'undan `Md` değeriyle çağırın.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **Markdown Çeşidini Seçin**

[MarkdownSaveOptions::setFlavor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/markdownsaveoptions/) yöntemi, çıktıda kullanılan Markdown spesifikasyonunu kontrol eder. [Flavor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/flavor/) enum'ı CommonMark, GitHub Flavored Markdown ve diğer desteklenen varyantları içerir.

Aşağıdaki örnek bir sunumu CommonMark olarak dışa aktarır:

```php
use aspose\slides\Flavor;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setFlavor(Flavor::CommonMark);

    $presentation->save($outputPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

## **Varsayılan Yerel Kaydetme Davranışıyla Görüntüleri Dışa Aktarın**

[MarkdownSaveOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/markdownsaveoptions/) sınıfı, yerel olarak kaydedilen görüntüleri yapılandırmak için iki yöntem sağlar:

- `setBasePath` temel dizini belirtilir.
- `setImagesSaveFolderName` görüntü alt dizinini belirtir. Varsayılan değeri `Images`tır.

Aşağıdaki örnek görsel içeriği render eder, görüntüleri `output/assets` klasörüne yazar ve Markdown belgesinde göreli görüntü referansları oluşturur:

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("assets");

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

Bu davranış, özel bir görüntü kaydetme işleyicisi `false` döndürdüğünde geri dönüş olarak da hizmet eder.

## **Görüntü Kaydetmeyi ve Markdown Bağlantılarını Özelleştirin**

Markdown dışa aktarımı sırasında oluşturulan SVG dışı bitmap ve metafile kaynakları için bir geri arama kaydetmek üzere [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/tr/php-java/aspose.slides/markdownsaveoptions/) yöntemini kullanın. `MarkdownImageSavingHandler` geri araması, [IImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/iimage/) nesnesini, onun [ImageFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imageformat/) değerini ve oluşturulan Markdown bağlantısını tek elemanlı bir Java dizi olarak alır. Görüntüyü verilen formatta kaydedin veya yükleyin ve `$link[0]` değerini Markdown çıktısında yer alması gereken referansla değiştirin.

SVG formatında oluşturulan kaynaklar ayrı olarak işlenir. [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/tr/php-java/aspose.slides/markdownsaveoptions/) yöntemiyle bir geri arama kaydedin. `MarkdownSvgImageSavingHandler` geri araması, bir [ISvgImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/isvgimage/) nesnesi ve tek elemanlı Java dizi `$link` alır. SVG'nin `ImageFormat` argümanı yoktur; bunun yerine [ISvgImage::getSvgData](https://reference.aspose.com/slides/tr/php-java/aspose.slides/isvgimage/) yönteminden XML verisini yazın veya yükleyin. Dışa aktarma modu ve görsel gruplamaya bağlı olarak, kaynak sunumdaki bir SVG rasterleştirilebilir veya diğer içerikle birleştirilebilir; ortaya çıkan SVG olmayan kaynak daha sonra görüntü kaydetme geri aramasına geçirilir. Her dışa aktarılan görsel kaynağın özel işlenmesi gerektiğinde her iki geri aramayı da kaydedin.

PHP üzerinden Java'da, her geri aramayı bir PHP sınıfında uygulayın ve bu nesneyi ilgili Java arayüzü olarak ortaya çıkarmak için `java_closure` kullanın.

{{% alert color="info" title="Note" %}}
`Java.inc` dosyasını yüklemeden önce `JAVA_PREFER_VALUES` etkinleştirilmiş şekilde PHP/Java Köprüsü'nü başlatın. [Presentation::save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) yöntemi `void` döndürür ve köprünün varsayılan akış modu, bu sıraya alınmış çağrı sırasında bir PHP geri aramasını çalıştıramaz. Aşağıdaki tam örnek gerekli başlatmayı içerir.
{{% /alert %}}

İşleyicinin dönüş değeri, görüntüyü kimin işleyeceğini belirler:

- Görüntüyü kaydettikten, yükledikten, dönüştürdükten veya başka bir şekilde işledikten ve `$link[0]`'a geçerli bir değer atadıktan sonra `true` döndürün. Aspose.Slides bu değeri Markdown belgesine yazar ve varsayılan yerel kaydetme işlemini gerçekleştirmez.
- `false` döndürerek Aspose.Slides'in görüntüyü yerel olarak kaydetmesini ve bağlantısını, [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/tr/php-java/aspose.slides/markdownsaveoptions/) ve [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/tr/php-java/aspose.slides/markdownsaveoptions/) ile ayarlanan değerlere göre oluşturmasını sağlayın.

{{% alert color="warning" title="Important" %}}
`true` döndüren bir işleyici, görüntünün sorumluluğunu alır. Geçerli ve boş olmayan bir bağlantı atamadan `true` dönerse, dışa aktarma `InvalidOperationException` hatasıyla başarısız olur.
{{% /alert %}}

### **Görüntüleri CDN Kaynak Dizini'ne Kaydedin ve Harici URL'ler Kullanın**

Aşağıdaki örnek, `cdn-origin/presentations/quarterly-report` dizinini bağlanmış veya senkronize edilmiş bir CDN kaynak dizini olarak ele alır. Her işleyici oluşturulan dosya adını çıkarır, görüntüyü bu özel dizine kaydeder ve oluşturulan yerel referansı genel bir CDN URL'siyle değiştirir. Örnek kendisi ağ üzerinden bir yükleme yapmaz: URL, dizin CDN kaynağı olarak bağlandıktan veya dosyaları CDN'ye yayımlandıktan sonra geçerli olur. Nesne depolama için, dosya sistemi yazımını depolama SDK'sının yükleme işlemiyle değiştirin ve `$link[0]`'ı sadece yükleme başarılı olduğunda atayın.

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

define("JAVA_PREFER_VALUES", 1);
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

function getFileNameFromLink($generatedLink)
{
    $urlCompatibleLink = str_replace("\\", "/", java_values($generatedLink));
    return basename($urlCompatibleLink);
}

function buildPublicUrl($publicBaseUrl, $fileName)
{
    return rtrim($publicBaseUrl, "/") . "/" . rawurlencode($fileName);
}

class CustomImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($image, $format, $link)
    {
        if (java_values($image->getWidth()) < 128 || java_values($image->getHeight()) < 128) {
            return false;
        }

        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $image->save($storagePath, $format);
        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

class CustomSvgImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($svgImage, $link)
    {
        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $outputStream = null;
        try {
            $outputStream = new Java("java.io.FileOutputStream", $storagePath);
            $outputStream->write($svgImage->getSvgData());
        } catch (Throwable $exception) {
            fwrite(STDERR, "Could not save the SVG image: " . $exception->getMessage() . PHP_EOL);
            return false;
        } finally {
            if ($outputStream !== null) {
                $outputStream->close();
            }
        }

        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
$publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
$storageDirectory = __DIR__ . DIRECTORY_SEPARATOR . "cdn-origin" . DIRECTORY_SEPARATOR . "presentations" . DIRECTORY_SEPARATOR . "quarterly-report";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}
if (!is_dir($storageDirectory)) {
    mkdir($storageDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("fallback-images");

    $imageSavingHandler = java_closure(new CustomImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler'));
    $svgImageSavingHandler = java_closure(new CustomSvgImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler'));
    $options->setImageSaving($imageSavingHandler);
    $options->setSvgImageSaving($svgImageSavingHandler);

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

Bitmap işleyicisi, 128 × 128 pikselden daha küçük görüntüler için kasıtlı olarak `false` döndürür, böylece Aspose.Slides bu görüntüleri varsayılan davranışı kullanarak `output/fallback-images` klasörüne kaydeder. Daha büyük bitmap ve metafile kaynakları ve SVG kaynakları özel kod tarafından işlenir. Örneğin, `fallback-images/image1.png` gibi bir yerel referans `https://cdn.example.com/presentations/quarterly-report/image1.png` haline gelir. İşleyiciler dosya yazarken yalnızca işletim sistemi yollarını kullanır; Markdown'a yazılan bağlantılar ileri eğik çizgi ve URL kodlu dosya adları içerir. Göreli bağlantılar oluştururken aynı kuralı uygulayın: platforma özgü dizin ayırıcı yerine `/` kullanın.

## **SSS**

**Bir işleyici hem raster görüntüleri hem de SVG görüntüleri işleyebilir mi?**

Hayır. Oluşturulan bitmap ve metafile kaynakları için [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/tr/php-java/aspose.slides/markdownsaveoptions/) yöntemini, SVG olarak oluşturulan kaynaklar için ise [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/tr/php-java/aspose.slides/markdownsaveoptions/) yöntemini kullanın. İlki bir [IImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/iimage/) nesnesi ve bir [ImageFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imageformat/) değeri sağlar; ikincisi ise SVG verisi [ISvgImage::getSvgData](https://reference.aspose.com/slides/tr/php-java/aspose.slides/isvgimage/) ile okunabilen bir [ISvgImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/isvgimage/) nesnesi sağlar. Dışa aktarım sırasında rasterleştirilen bir kaynak SVG, görüntü kaydetme geri araması tarafından işlenir.

**Bir görüntü kaydetme işleyicisi `false` döndürdüğünde ne olur?**

Aspose.Slides varsayılan yerel kaydetme davranışını kullanır. Görüntü konumu ve oluşturulan referans, [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/tr/php-java/aspose.slides/markdownsaveoptions/) ve [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/tr/php-java/aspose.slides/markdownsaveoptions/) ile ayarlanan değerler tarafından kontrol edilir.

**Bir işleyici, görüntüyü yerel olarak kaydetmeden bir URL sağlayabilir mi?**

Evet. İşleyici görüntüyü nesne depolamaya yükleyebilir veya başka bir servise gönderebilir, ortaya çıkan URL'yi `$link[0]`'a atayabilir ve `true` döndürebilir. İşleyici işleme kendisi tamamlamalıdır; `true` döndürmek varsayılan yerel kaydetmeyi engeller.

**Markdown dışa aktarımı neden bir işleyiciden `InvalidOperationException` hatası fırlatıyor?**

Bu istisna, işleyici `true` döndürdüğünde ancak geçerli bir bağlantı sağlamadığında oluşur. `true` döndürmeden önce Markdown'a yazılması gereken göreli yolu veya harici URL'yi atayın.

**Görüntü bağlantıları hangi yol ayırıcıyı kullanmalı?**

Markdown bağlantılarında ve URL'lerde ileri eğik çizgi (`/`) kullanın. `DIRECTORY_SEPARATOR` sadece dosya sistemi yolları için kullanılmalı, ardından Markdown referansı ayrı olarak oluşturulmalı veya normleştirilmelidir.

**Markdown dışa aktarımı sırasında köprüler korunuyor mu?**

Evet. Metin [hyperlinks](/slides/tr/php-java/manage-hyperlinks/) standart Markdown bağlantıları olarak korunur. Slayt [transitions](/slides/tr/php-java/slide-transition/) ve [animations](/slides/tr/php-java/powerpoint-animation/) dönüştürülmez.

**Sunumlar paralel olarak Markdown'a dönüştürülebilir mi?**

Farklı sunum dosyalarını paralel olarak işleyebilirsiniz, ancak aynı [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) örneğini iş parçacıkları arasında paylaşmayın. [multithreading guidelines](/slides/tr/php-java/multithreading/) yönergelerini izleyin ve her dosya için ayrı bir örnek kullanın.