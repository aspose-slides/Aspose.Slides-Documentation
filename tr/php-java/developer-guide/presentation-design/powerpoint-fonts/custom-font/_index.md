---
title: PHP'de PowerPoint Yazı Tiplerini Özelleştirme
linktitle: Özel Yazı Tipi
type: docs
weight: 20
url: /tr/php-java/custom-font/
keywords:
- yazı tipi
- özel yazı tipi
- harici yazı tipi
- yazı tipi yükle
- yazı tiplerini yönet
- yazı tipi klasörü
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "PowerPoint slaytlarındaki yazı tiplerini, Java aracılığıyla PHP için Aspose.Slides kullanarak özelleştirin; böylece sunumlarınız herhangi bir cihazda net ve tutarlı olur."
---
## **Genel Bakış**

Aspose.Slides, işletim sistemine kurulum yapmadan sunumlarda özel yazı tipleri kullanmanıza olanak tanır. Yazı tiplerini özel klasörlerden yükleyebilir, belirli bir sunum için belge düzeyinde yazı tipi kaynakları aracılığıyla yazı tipleri sağlayabilir veya harici yazı tiplerini doğrudan ikili veri olarak yükleyebilirsiniz.

Yüklenen yazı tipleri, bir sunum render edildiğinde veya dışa aktarıldığında, örneğin PDF, görüntüler ve diğer desteklenen formatlara, kullanılır. Bu, sunum çıktısının farklı ortamlar arasında tutarlı kalmasına yardımcı olur. Makale ayrıca Aspose.Slides tarafından kullanılan yazı tipi klasörlerini nasıl inceleyeceğinizi ve harici yazı tipleriyle çalıştıktan sonra yazı tipi önbelleğini nasıl temizleyeceğinizi açıklar.

Özel yazı tiplerini render için kaydetmek, bir PPTX dosyasına gömmekten ayrı bir işlemdir. Bir yazı tipinin sunumun içinde depolanması gerekiyorsa, yazı tipi gömme özelliklerini açıkça kullanın.

{{% alert color="primary" %}} 

Aspose Slides, bu yazı tiplerini [loadExternalFonts](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) yöntemiyle yüklemenize olanak tanır:

* TrueType (.ttf) ve TrueType Collection (.ttc) yazı tipleri. Bkz. [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) yazı tipleri. Bkz. [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Özel Yazı Tiplerini Yükleme**

Aspose.Slides, bir sunumda kullanılan yazı tiplerini sisteme kurmadan yüklemenizi sağlar. Bu, PDF, görüntüler ve diğer desteklenen formatlar gibi dışa aktarım çıktısını etkiler; böylece ortaya çıkan belgeler ortamlar arasında tutarlı görünür. Yazı tipleri özel dizinlerden yüklenir.

1. Yazı tipi dosyalarını içeren bir veya daha fazla klasör belirtin.
2. Bu klasörlerden yazı tiplerini yüklemek için statik [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) metodunu çağırın.
3. Sunumu yükleyin ve render/dışa aktarın.
4. Yazı tipi önbelleğini temizlemek için [FontsLoader::clearCache](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsloader/#clearCache--) metodunu çağırın.

Aşağıdaki kod örneği, yazı tipi yükleme sürecini gösterir:

```php
// Özel yazı tipi dosyalarını içeren klasörleri tanımlayın.
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// Belirtilen klasörlerden özel yazı tiplerini yükleyin.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentationPath = __DIR__ . "/sample.pptx";
    $presentation = new Presentation($presentationPath);
    
    // Yüklenen yazı tiplerini kullanarak sunumu render/dışa aktarın (örneğin PDF, görüntüler veya diğer formatlar).
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // İş tamamlandıktan sonra yazı tipi önbelleğini temizleyin.
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) yazı tipi arama yollarına ek klasörler ekler, ancak yazı tipi başlatma sırasını değiştirmez.  
Yazı tipleri aşağıdaki sırayla başlatılır:

1. Varsayılan işletim sistemi yazı tipi yolu.
1. [FontsLoader](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsloader/) aracılığıyla yüklenen yollar.

{{%/alert %}}

## **Özel Yazı Tipi Klasörlerini Alın**

Aspose.Slides, yazı tipi klasörlerini bulmanıza izin veren [getFontFolders](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsloader/#getFontFolders--) metodunu sağlar. Bu metod, `LoadExternalFonts` yöntemiyle eklenen klasörleri ve sistem yazı tipi klasörlerini döndürür.

Bu PHP kodu, [getFontFolders](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsloader/#getFontFolders--) yönteminin nasıl kullanılacağını gösterir:

```php
# Bu satır, yazı tipi dosyalarının arandığı klasörleri çıktılar.
# Bunlar, LoadExternalFonts yöntemiyle eklenen ve sistem yazı tipi klasörleri olan klasörlerdir.
$fontFolders = FontsLoader::getFontFolders();
```

## **Bir Sunumda Kullanılan Özel Yazı Tiplerini Belirleme**

Aspose.Slides, sunumla birlikte kullanılacak harici yazı tiplerini belirtmenize olanak tanıyan [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) metodunu sağlar.

Bu PHP kodu, [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) yönteminin nasıl kullanılacağını gösterir:

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;

$customFontsDirectory = __DIR__ . "/customfonts/";
$customFont1Path = $customFontsDirectory . "CustomFont1.ttf";
$customFontFile1 = new Java("java.io.File", $customFont1Path);
$customFontFile1Length = $customFontFile1->length();
$memoryFont1 = $javaArray->newInstance($javaByteType, $customFontFile1Length);
$dataInputStream1 = null;
try {
    $fileInputStream1 = new Java("java.io.FileInputStream", $customFontFile1);
    $dataInputStream1 = new Java("java.io.DataInputStream", $fileInputStream1);
    $dataInputStream1->readFully($memoryFont1);
} finally {
    if (!java_is_null($dataInputStream1)) $dataInputStream1->close();
}

$customFont2Path = $customFontsDirectory . "CustomFont2.ttf";
$customFontFile2 = new Java("java.io.File", $customFont2Path);
$customFontFile2Length = $customFontFile2->length();
$memoryFont2 = $javaArray->newInstance($javaByteType, $customFontFile2Length);
$dataInputStream2 = null;
try {
    $fileInputStream2 = new Java("java.io.FileInputStream", $customFontFile2);
    $dataInputStream2 = new Java("java.io.DataInputStream", $fileInputStream2);
    $dataInputStream2->readFully($memoryFont2);
} finally {
    if (!java_is_null($dataInputStream2)) $dataInputStream2->close();
}

$loadOptions = new LoadOptions();
$assetFontsFolder = __DIR__ . "/assets/fonts";
$globalFontsFolder = __DIR__ . "/global/fonts";
$loadOptions->getDocumentLevelFontSources()->setFontFolders(array($assetFontsFolder, $globalFontsFolder));
$loadOptions->getDocumentLevelFontSources()->setMemoryFonts(array($memoryFont1, $memoryFont2 ));

$presentationPath = __DIR__ . "/MyPresentation.pptx";
$presentation = new Presentation($presentationPath, $loadOptions);
try {
    # Sunumla çalış
    # CustomFont1, CustomFont2 ve assets\fonts ve global\fonts klasörlerinden ve alt klasörlerinden gelen yazı tipleri sunuma kullanılabilir
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Yazı Tiplerini Dışarıdan Yönetme**

Aspose.Slides, ikili veriden harici yazı tiplerini yüklemenize olanak tanıyan [loadExternalFont](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) metodunu sağlar.

Bu PHP kodu, byte dizisi ile yazı tipi yükleme sürecini gösterir:

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;
$fontDirectory = __DIR__ . "/";

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALN.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNBI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

try {
    $presentation = new Presentation();
    try {
        #        sunum ömrü boyunca harici yazı tipi yüklendi
    } finally {
        if (!java_is_null($presentation)) {
            $presentation->dispose();
        }
    }
} finally {
    FontsLoader->clearCache();
}
```

## **SSS**

**Özel yazı tipleri tüm formatlara (PDF, PNG, SVG, HTML) dışa aktarmayı etkiler mi?**  
Evet. Bağlı yazı tipleri, render tarafından tüm dışa aktarma formatlarında kullanılır.

**Özel yazı tipleri sonuç PPTX dosyasına otomatik olarak gömülür mü?**  
Hayır. Bir yazı tipini render için kaydetmek, onu bir PPTX'e gömmekle aynı şey değildir. Yazı tipinin sunum dosyası içinde bulunmasını istiyorsanız, açıkça [gömme özelliklerini](/slides/tr/php-java/embedded-font/) kullanmalısınız.

**Özel bir yazı tipi belirli gliflere sahip olmadığında geri dönüş (fallback) davranışını kontrol edebilir miyim?**  
Evet. İstenen glif bulunmadığında hangi yazı tipinin kullanılacağını tam olarak tanımlamak için [font substitution](/slides/tr/php-java/font-substitution/), [replacement rules](/slides/tr/php-java/font-replacement/) ve [fallback sets](/slides/tr/php-java/fallback-font/) yapılandırabilirsiniz.

**Yazı tiplerini Linux/Docker konteynerlerinde sistem genelinde kurulum yapmadan kullanabilir miyim?**  
Evet. Kendi yazı tipi klasörlerinize yönlendirebilir veya yazı tiplerini byte dizilerinden yükleyebilirsiniz. Bu, konteyner imajındaki sistem yazı tipi dizinlerine bağımlılığı ortadan kaldırır.

**Lisanslama konusunda ne durum? Herhangi bir özel yazı tipini kısıtlama olmadan gömebilir miyim?**  
Yazı tipi lisansına uyumdan siz sorumlusunuz. Şartlar değişiklik gösterir; bazı lisanslar gömme veya ticari kullanımı yasaklar. Çıktıları dağıtmadan önce her zaman yazı tipinin EULA'sını inceleyin.