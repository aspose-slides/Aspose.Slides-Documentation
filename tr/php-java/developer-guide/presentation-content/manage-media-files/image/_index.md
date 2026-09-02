---
title: PHP Kullanarak Sunumlarda Görüntü Yönetimini Optimize Edin
linktitle: Görüntüleri Yönet
type: docs
weight: 10
url: /tr/php-java/image/
keywords:
- görsel ekle
- resim ekle
- bitmap ekle
- görsel değiştir
- resim değiştir
- web'den
- arka plan
- PNG ekle
- JPG ekle
- SVG ekle
- harici SVG kaynakları
- SVG çözücü
- bağlantılı SVG görüntüleri
- SVG fontları
- EMF ekle
- WMF ekle
- TIFF ekle
- PowerPoint
- OpenDocument
- sunum
- EMF
- SVG
- PHP
- Aspose.Slides
description: "PowerPoint ve OpenDocument'ta görüntü yönetimini, Java üzerinden PHP için Aspose.Slides ile kolaylaştırın; performansı optimize edin ve iş akışınızı otomatikleştirin."
---
## **Giriş**

Görseller, sunumları daha ilgi çekici ve görsel olarak çekici hâle getirir. Microsoft PowerPoint'te, dosyalardan, internetten veya diğer kaynaklardan slaytlara resim ekleyebilirsiniz. Benzer şekilde, Aspose.Slides, sunum slaytlarına çeşitli yollarla resim eklemenize olanak tanır.

{{% alert  title="Tip" color="primary" %}} 

Aspose, ücretsiz dönüştürücüler—[JPEG to PowerPoint](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG to PowerPoint](https://products.aspose.app/slides/tr/import/png-to-ppt)—sağlayarak görüntülerden hızlıca sunumlar oluşturmanıza imkan verir. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Bir resmi resim çerçevesi olarak eklemek istiyorsanız—özellikle yeniden boyutlandırmayı, efekt uygulamayı veya diğer standart biçimlendirme seçeneklerini kullanmayı planlıyorsanız—[Picture Frame](/slides/tr/php-java/picture-frame/) sayfasına bakın. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Görüntüleri bir formattan başka bir formata dönüştürebilirsiniz. Aşağıdaki sayfalara bakın: görüntüyü JPG'ye dönüştürme[image to JPG](https://products.aspose.com/slides/tr/php-java/conversion/image-to-jpg/), JPG'yi görüntüye dönüştürme[JPG to image](https://products.aspose.com/slides/tr/php-java/conversion/jpg-to-image/), JPG'yi PNG'ye dönüştürme[JPG to PNG](https://products.aspose.com/slides/tr/php-java/conversion/jpg-to-png/), PNG'yi JPG'ye dönüştürme[PNG to JPG](https://products.aspose.com/slides/tr/php-java/conversion/png-to-jpg/), PNG'yi SVG'ye dönüştürme[PNG to SVG](https://products.aspose.com/slides/tr/php-java/conversion/png-to-svg/), ve SVG'yi PNG'ye dönüştürme[SVG to PNG](https://products.aspose.com/slides/tr/php-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides, JPEG, PNG, BMP, GIF ve diğer popüler formatlardaki görüntüleri destekler. 

## **Yerel Olarak Saklanan Görüntüleri Slaytlara Ekleyin**

Bilgisayarınızda depolanan bir veya birden fazla görüntüyü bir sunum slaytına ekleyebilirsiniz. Aşağıdaki PHP örnek kod bir görüntüyü slayta nasıl ekleyeceğinizi gösterir:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **Web'den Görüntüleri Slaytlara Ekleyin**

Eğer bir slayta eklemek istediğiniz görüntü bilgisayarınızda depolanmamışsa, doğrudan web üzerinden ekleyebilirsiniz. 

Aşağıdaki PHP örnek kod, bir görüntüyü web'den slayta nasıl ekleyeceğinizi gösterir:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $imageUrl = new Java("java.net.URL", "[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();

    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 1024);

        while (($read = java_values($inputStream->read($buffer, 0, $Array->getLength($buffer)))) != -1) {
            $outputStream->write($buffer, 0, $read);
        }

        $outputStream->flush();

        $image = $pres->getImages()->addImage($outputStream->toByteArray());
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $pres->save("pres.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **Slide Master'lara Görüntü Ekleyin**

Slide master, onu kullanan slaytların tema ve düzen gibi bilgilerini depolar ve kontrol eder. Bir slide master'a bir görüntü eklediğinizde, görüntü o master'a dayalı her slaytta görünür. 

Aşağıdaki PHP örnek kod bir görüntüyü slide master'a nasıl ekleyeceğinizi gösterir:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **Görüntüleri Slayt Arka Planı Olarak Ekleyin**

Bir veya birden fazla slaytın arka planı olarak bir resmi kullanabilirsiniz. Ayrıntılar için *[Setting Images as Backgrounds for Slides](/slides/tr/php-java/presentation-background/#setting-images-as-background-for-slides)* sayfasına bakın.

## **Sunumlara SVG Ekleyin**

SVG içeriği, bir sunuma [SvgImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgimage/) sınıfı kullanılarak eklenebilir. Oluşan SVG görüntü nesnesi daha sonra sunumun resim koleksiyonuna eklenebilir ve bir resim çerçevesi oluşturmak için kullanılabilir.

Aşağıdaki PHP örneği, kendine özgü bir SVG dizesini içe aktarır. Bu SVG tarafından kullanılan tüm görüntüler, stiller ve diğer kaynaklar doğrudan SVG içeriğine gömülür.

```php
$svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" .
    "    <rect width='320' height='180' fill='#4F81BD'/>" .
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" .
    "</svg>";

$presentation = new Presentation();
try {
    $svgImage = new SvgImage($svgContent);
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("self-contained-svg.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Dış Kaynaklı SVG İçeriğini İçeri Aktarın**

Tasarım araçları, diyagram editörleri, ikon sistemleri ve web pipeline'larından dışa aktarılan SVG dosyaları, SVG belgesinin dışındaki kaynaklara başvurabilir. Örneğin, bir SVG `images/photo.png` gibi bir resim bağlantısı, bir CSS `url(...)` değeri veya bir font URL'si içerebilir.

Bu tür SVG içeriğini içe aktarmak için bir [ExternalResourceResolver](https://reference.aspose.com/slides/tr/php-java/aspose.slides/externalresourceresolver/) uygulaması oluşturun ve temel URI ile birlikte uygun bir [SvgImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgimage/) yapıcısına geçirin. Temel URI, SVG belgesinin konumunu belirler ve göreli bağlantıların çözülmesinde kullanılır.

SVG görüntü nesnesi içe aktarılan SVG hakkında bilgiye erişim sağlar:

- `getSvgContent()` SVG işaretlemesini bir dize olarak döndürür.
- `getSvgData()` SVG içeriğini bir bayt dizisi olarak döndürür.
- `getBaseUri()` göreli bağlantılar için kullanılan temel URI'yi döndürür.
- `getExternalResourceResolver()` SVG görüntüsüne atanan çözücüyü döndürür.

### **External Resource Resolver'ı Uygula**

Çözücünün iki yöntemi vardır:

- `resolveUri` temel URI ve göreli kaynak bağlantısını birleştirerek mutlak bir URI döndürür. Bağlantı çözülemediğinde veya izin verilmediğinde `null` döndürülür.
- `getEntity` mutlak bir kaynak URI'si için okunabilir bir akış döndürür. Kaynak eksik, engellenmiş veya erişilemez olduğunda `null` döndürülür. Gerekli olduğunda bir yedek akış da döndürülebilir.

Aşağıdaki çözücü, yalnızca izin verilen yerel bir dizinden bağlı kaynakları yükler. Ağ kaynakları ve izin verilen dizin dışındaki yollar engellenir. Çözülmemiş resim bağlantıları için isteğe bağlı bir yedek resim döndürülür.

```php
class LocalSvgResourceResolver extends ExternalResourceResolver
{
    private $allowedRoot;
    private $fallbackImageData;

    public function __construct($allowedRoot, $fallbackImageData)
    {
        parent::__construct();

        $Paths = new JavaClass("java.nio.file.Paths");
        $this->allowedRoot = $Paths->get($allowedRoot)->toAbsolutePath()->normalize();
        $this->fallbackImageData = $fallbackImageData;
    }

    public function resolveUri($baseUri, $relativeUri)
    {
        if ($baseUri === null || trim(java_values($baseUri)) === "" ||
            $relativeUri === null || trim(java_values($relativeUri)) === "") {
            return null;
        }

        try {
            $URI = new JavaClass("java.net.URI");
            $baseAddress = $URI->create($baseUri);
            $absoluteAddress = $baseAddress->resolve($relativeUri);

            // Bu çözücü kasıtlı olarak yalnızca yerel dosyalara izin verir.
            if (strcasecmp(java_values($absoluteAddress->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($absoluteAddress)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            return $resourcePath->toUri()->toString();
        } catch (JavaException $e) {
            return null;
        }
    }

    public function getEntity($absoluteUri)
    {
        try {
            $URI = new JavaClass("java.net.URI");
            $resourceUri = $URI->create($absoluteUri);

            if (strcasecmp(java_values($resourceUri->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($resourceUri)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            $Files = new JavaClass("java.nio.file.Files");
            if (java_values($Files->exists($resourcePath))) {
                return $Files->newInputStream($resourcePath);
            }

            // Yalnızca resim kaynakları için bir yedek kullanın. Bir resim akışı döndürmek
            // eksik bir font veya stil sayfası için geçerli olmaz.
            if ($this->fallbackImageData !== null && $this->isImageFile($resourcePath)) {
                return new Java("java.io.ByteArrayInputStream", $this->fallbackImageData);
            }
        } catch (JavaException $e) {
            return null;
        }

        return null;
    }

    private function isInsideAllowedRoot($resourcePath)
    {
        return java_values($resourcePath->normalize()->startsWith($this->allowedRoot));
    }

    private function isImageFile($path)
    {
        $fileName = strtolower(java_values($path->getFileName()->toString()));

        return str_ends_with($fileName, ".png") ||
            str_ends_with($fileName, ".jpg") ||
            str_ends_with($fileName, ".jpeg") ||
            str_ends_with($fileName, ".gif") ||
            str_ends_with($fileName, ".bmp");
    }
}
```

### **SVG İçe Aktarımı Sırasında Bağlı Kaynakları Çöz**

`assets/diagram.svg` dosyasının aşağıdaki gibi bir göreli referans içerdiğini varsayalım:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Aşağıdaki PHP örneği, SVG dosyasının URI'sini temel URI olarak geçirir ve özel bir çözücü sağlar. Çözücü, göreli resim bağlantısını mutlak bir URI'ye dönüştürür ve Aspose.Slides SVG'yi işlerken bağlanan kaynağı içeren bir akış döndürür.

```php
$Paths = new JavaClass("java.nio.file.Paths");
$Files = new JavaClass("java.nio.file.Files");
$StandardCharsets = new JavaClass("java.nio.charset.StandardCharsets");

$svgFilePath = $Paths->get("assets", "diagram.svg")->toAbsolutePath()->normalize();
$assetDirectory = $svgFilePath->getParent();

$svgData = $Files->readAllBytes($svgFilePath);
$svgContent = new Java("java.lang.String", $svgData, $StandardCharsets->UTF_8);

// Temel URI, SVG belgesinin konumunu temsil eder.
$baseUri = $svgFilePath->toUri()->toString();

$fallbackImageData = null;
$fallbackImagePath = $assetDirectory->resolve("fallback.png");
if (java_values($Files->exists($fallbackImagePath))) {
    $fallbackImageData = $Files->readAllBytes($fallbackImagePath);
}

$resolver = new LocalSvgResourceResolver(java_values($assetDirectory->toString()), $fallbackImageData);
$svgImage = new SvgImage($svgContent, $resolver, $baseUri);

// SVG görüntü nesnesi kaynak içerik, ikili veri, temel URI ve çözücüyü gösterir.
$importedContent = $svgImage->getSvgContent();
$importedData = $svgImage->getSvgData();
$importedBaseUri = $svgImage->getBaseUri();
$importedResolver = $svgImage->getExternalResourceResolver();

$presentation = new Presentation();
try {
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("svg-with-linked-resources.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`SvgImage` sınıfı ayrıca, bir dış kaynak çözücüsü ve temel URI ile birlikte SVG verilerini bir bayt dizisi veya giriş akışı olarak kabul eden aşırı yüklemeler sağlar.

{{% alert title="Important" color="warning" %}}

Kaynak çözücü, Aspose.Slides SVG'yi işler ve render ederken dış kaynakların kullanılabilir olmasını sağlar. Orijinal SVG işaretlemesini değiştirmez veya çözülmüş kaynakları otomatik olarak içine gömme işlemi yapmaz.

Bir SVG görüntüsü sunumun resim koleksiyonuna eklendiğinde, PPTX dosyası hem orijinal SVG temsili hem de bir raster yedek resim içerebilir. Bağlı bir kaynak, oluşturulan yedek resimde görünebilirken `images/photo.png` gibi bir göreli bağlantı depolanan SVG'de değişmeden kalır. Yerel SVG temsili sağlayan bir uygulama, orijinal dış kaynak mevcut olmadığında bağlı içeriği atlayabilir.

{{% /alert %}}

### **Taşınabilir Bir SVG Resmi Oluşturun**

Harici dosyalara bağımlı olmayan bir SVG resmi oluşturmak için, `SvgImage` oluşturulmadan önce SVG'yi kendine özgü hâle getirin. Örneğin, bağlı resim URL'lerini resim verilerini içeren `data:` URI'leriyle değiştirin:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Gerekli tüm kaynaklar SVG içeriğine gömüldükten sonra `SvgImage` oluşturun, sunumun resim koleksiyonuna ekleyin ve önceki örnekte gösterildiği gibi bir resim çerçevesine yerleştirin.

### **Eksik veya Engellenen Kaynakları Ele Alın**

`resolveUri` yönteminden, bir kaynak URI'si geçersiz, yasaklanmış veya çözülemiyorsa `null` döndürün. `getEntity` yönteminden, kaynak okunamıyorsa `null` döndürün. Aspose.Slides mümkün olduğunda o kaynağı olmadan SVG işleme devam eder.

Eksik bir kaynak için bir yedek akış döndürülebilir, ancak içeriği istenen kaynak türüyle uyumlu olmalıdır. Örneğin, bir eksik resim için yalnızca bir resim akışı döndürün, bir font veya stil sayfası için değil.

{{% alert title="Security" color="warning" %}}

Güvenilmeyen SVG dosyalarından rastgele dosya yolları veya sınırsız ağ URL'leri çözülmemelidir. İzin verilen şemalar, dizinler ve ana bilgisayarlar kısıtlanmalıdır. Ağ kaynakları için bağlantı zaman aşımı, yanıt boyutu limitleri ve içerik doğrulaması da uygulanmalıdır.

{{% /alert %}}

## **SVG'yi Bir Şekil Kümesine Dönüştürün**

Aspose.Slides, bir SVG'yi PowerPoint'teki karşılık gelen işlevselliğe benzer şekilde bir şekil kümesine dönüştürebilir:

![PowerPoint Popup Menu](img_01_01.png)

Bu işlevsellik, ilk argüman olarak bir [SvgImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgimage/) nesnesi alan [ShapeCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/) sınıfının [addGroupShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/addgroupshape/) metodunun bir aşırı yüklemesi tarafından sağlanır.

Aşağıdaki PHP örnek kod bu yöntemi kullanarak bir SVG dosyasını şekil kümesine nasıl dönüştüreceğinizi gösterir:

```php
// Kaynak SVG dosya adı.
$svgFileName = "sample.svg";

// Çıktı sunum dosya adı.
$outPptxPath = "presentation.pptx";

// Yeni bir sunum oluştur.
$presentation = new Presentation();
try {
    // SVG dosya içeriğini okuyun.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $svgFileName));
    try {
        $svgContent = $Array->newInstance($Byte, $dis->available());
        $dis->readFully($svgContent);
    } finally {
        if (!java_is_null($dis)) {
            $dis->close();
        }
    }

    // Bir SvgImage nesnesi oluştur.
    $svgImage = new SvgImage($svgContent);

    // Slayt boyutunu al.
    $slideSize = $presentation->getSlideSize()->getSize();

    // SVG görüntüsünü bir şekil grubuna dönüştürün ve slayt boyutuna ölçeklendirin.
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape(
        $svgImage,
        0.0,
        0.0,
        $slideSize->getWidth(),
        $slideSize->getHeight()
    );

    // Sunumu PPTX formatında kaydedin.
    $presentation->save($outPptxPath, SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $presentation->dispose();
}
```

## **Görüntüleri EMF Olarak Slaytlara Ekleyin**

Aspose.Slides for PHP via Java, Aspose.Cells ile Excel çalışma sayfalarından EMF görüntüleri oluşturmanıza ve bunları sunum slaytlarına eklemenize olanak tanır.

Aşağıdaki PHP örnek kod bu işlemi nasıl yapacağınızı gösterir:

```php
$book = new Workbook("chart.xlsx");
$sheet = $book->getWorksheets()->get(0);

$options = new ImageOrPrintOptions();
$options->setHorizontalResolution(200);
$options->setVerticalResolution(200);
$options->setImageType(ImageType::EMF);

// Çalışma kitabını bir akışa kaydet.
$sr = new SheetRender($sheet, $options);
$pres = new Presentation();
try {
    $pres->getSlides()->removeAt(0);

    for ($j = 0; $j < java_values($sr->getPageCount()); $j++) {
        $emfSheetName = "test" . $sheet->getName() . " Page" . ($j + 1) . ".out.emf";
        $sr->toImage($j, $emfSheetName);

        // Dosyayı olduğu gibi ekle ki resim vektör EMF olarak kalsın, rasterleştirilmesin.
        $picture = null;
        $imageStream = new Java("java.io.FileInputStream", $emfSheetName);
        try {
            $picture = $pres->getImages()->addImage($imageStream);
        } finally {
            $imageStream->close();
        }

        $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle,
            0,
            0,
            $pres->getSlideSize()->getSize()->getWidth(),
            $pres->getSlideSize()->getSize()->getHeight(),
            $picture
        );
    }

    $pres->save("output.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **Resim Koleksiyonundaki Görüntüleri Değiştirin**

Aspose.Slides, bir sunumun resim koleksiyonunda depolanan görüntüleri, slayt şekilleri tarafından kullanılan görüntüler dahil, değiştirmenize izin verir. Bu bölüm, koleksiyondaki görüntüleri güncellemenin çeşitli yollarını açıklar. Bir görüntüyü ham bayt verisi, bir [IImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/iimage/) örneği veya koleksiyonda zaten mevcut başka bir görüntü kullanarak değiştirebilirsiniz.

Aşağıdaki adımları izleyin:

1. Görüntüleri içeren sunum dosyasını [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfı ile yükleyin.
1. Yeni bir görüntüyü dosyadan bir bayt dizisine yükleyin.
1. Hedef görüntüyü bayt dizisini kullanarak yeni görüntüyle değiştirin.
1. İkinci yöntemde, görüntüyü bir [IImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/iimage/) nesnesine yükleyin ve hedef görüntüyü bu nesneyle değiştirin.
1. Üçüncü yöntemde, hedef görüntüyü sunumun resim koleksiyonunda zaten var olan bir görüntüyle değiştirin.
1. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation("sample.pptx");
try {
    // İlk yol.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new JavaClass("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // İkinci yol.
    $newImage = Images::fromFile("image1.png");
    try {
        $oldImage = $presentation->getImages()->get_Item(1);
        $oldImage->replaceImage($newImage);
    } finally {
        if (!java_is_null($newImage)) {
            $newImage->dispose();
        }
    }

    // Üçüncü yol.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));

    // Sunumu bir dosyaya kaydet.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}

Aspose'un ücretsiz [Text to GIF](https://products.aspose.app/slides/tr/text-to-gif) dönüştürücüsü ile metni kolayca canlandırabilir ve metinden GIF'ler oluşturabilirsiniz. 

{{% /alert %}}

## **SSS**

**Eklemeden sonra orijinal görüntü çözünürlüğü aynı kalır mı?**

Evet. Kaynak pikseller korunur, ancak son görünüm [picture](/slides/tr/php-java/picture-frame/) slaytta nasıl ölçeklendirildiğine ve kaydedilirken uygulanan sıkıştırmaya bağlıdır.

**Yüzlerce slaytta aynı logoyu bir anda değiştirmek için en iyi yol nedir?**

Logoyu master slayta veya bir yerleşime yerleştirip sunumun resim koleksiyonunda değiştirin—güncellemeler bu kaynağı kullanan tüm öğelere yayılır.

**Eklenen bir SVG düzenlenebilir şekillere dönüştürülebilir mi?**

Evet. Bir SVG'yi şekil grubuna dönüştürebilirsiniz; böylece bireysel parçalar standart şekil özellikleriyle düzenlenebilir hâle gelir.

**Birden fazla slaytın arka planı olarak resmi aynı anda nasıl ayarlayabilirim?**

Resmi master slayta veya ilgili yerleşime [arkaplan olarak atayın](/slides/tr/php-java/presentation-background/); bu master/yerleşimi kullanan tüm slaytlar arka planı miras alır.

**Birçok resim nedeniyle sunumun çok büyük olmasını nasıl önleyebilirim?**

Tek bir resim kaynağını tekrar kullanın, makul çözünürlükler seçin, kaydederken sıkıştırma uygulayın ve gerektiğinde grafikleri master'da tutun.