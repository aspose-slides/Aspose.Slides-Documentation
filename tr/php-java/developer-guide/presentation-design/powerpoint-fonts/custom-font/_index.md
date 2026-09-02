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
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint slaytlarındaki yazı tiplerini özelleştirerek sunumlarınızın her cihazda net ve tutarlı olmasını sağlayın."
---
## **Genel Bakış**

Aspose.Slides, işletim sistemine kurmadan sunumlarda özel yazı tiplerini kullanmanıza olanak tanır. Yazı tiplerini özel klasörlerden yükleyebilir, belge seviyesindeki yazı tipi kaynakları aracılığıyla belirli bir sunum için yazı tipleri sağlayabilir veya dış yazı tiplerini doğrudan ikili veriden yükleyebilirsiniz.

Yüklenen yazı tipleri, bir sunum renderlandığında veya dışa aktarıldığında, örneğin PDF, görüntüler ve diğer desteklenen formatlara, kullanılır. Bu, sunum çıktısının farklı ortamlar arasında tutarlı kalmasına yardımcı olur. Makale ayrıca Aspose.Slides tarafından kullanılan yazı tipi klasörlerini nasıl inceleyeceğinizi ve dış yazı tipleriyle çalıştıktan sonra yazı tipi önbelleğini nasıl temizleyeceğinizi açıklar.

Özel yazı tiplerini renderleme için kaydetmek, bir PPTX dosyasına gömmekten ayrı bir işlemdir. Eğer bir yazı tipinin sunum içinde saklanması gerekiyorsa, yazı tipi gömme özelliklerini açıkça kullanın.

Bir sunum teması, farklı yazı sistemleri için farklı yazı tipi ailelerine başvurabilir. Bu eşlemeler yalnızca yazı tipi adlarını saklar, ancak yazı tipi dosyalarını kurmaz veya yüklemez. Eşlemeleri yönetmek için [Script-Specific Theme Fonts](/slides/tr/php-java/script-specific-font-mappings/) sayfasına bakın ve aşağıdaki yükleme seçeneklerini kullanarak başvurulan yazı tiplerini tutarlı renderleme için kullanılabilir hâle getirin.

{{% alert color="info" title="Note" %}}
Aspose Slides, bu yazı tiplerini [loadExternalFonts](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) yöntemini kullanarak yüklemenize olanak tanır:

* TrueType (.ttf) ve TrueType Collection (.ttc) yazı tipleri. Bkz. [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) yazı tipleri. Bkz. [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Özel Yazı Tiplerini Yükleme**

Aspose.Slides, bir sunumda kullanılan yazı tiplerini sistemde kurmadan yüklemenize olanak tanır. Bu, PDF, görüntüler ve diğer desteklenen formatlar gibi dışa aktarma çıktısını etkileyerek, oluşan belgelerin farklı ortamlar arasında tutarlı görünmesini sağlar. Yazı tipleri özel dizinlerden yüklenir.

1. Yazı tipi dosyalarını içeren bir veya daha fazla klasör belirtin.
2. Bu klasörlerden yazı tiplerini yüklemek için statik [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) metodunu çağırın.
3. Sunumu yükleyin ve render/​dışa aktarın.
4. Yazı tipi önbelleğini temizlemek için [FontsLoader::clearCache](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsloader/#clearCache--) metodunu çağırın.

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
    
    // Yüklenen yazı tiplerini kullanarak sunumu renderlayın/​dışa aktarın (ör. PDF, görüntüler veya diğer formatlar).
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // İş tamamlandıktan sonra yazı tipi önbelleğini temizleyin.
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) ek klasörler ekler, ancak yazı tipi başlatma sırasını değiştirmez.  
Yazı tipleri aşağıdaki sırayla başlatılır:

1. Varsayılan işletim sistemi yazı tipi yolu.  
1. [FontsLoader](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsloader/) aracılığıyla yüklenen yollar.

{{%/alert %}}

## **Özel Yazı Tipi Klasörlerini Al**

Aspose.Slides, yazı tipi klasörlerini bulmanıza olanak tanıyan [getFontFolders](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsloader/#getFontFolders--) metodunu sunar. Bu metod, `LoadExternalFonts` yöntemiyle eklenen klasörleri ve sistem yazı tipi klasörlerini döndürür.

```php
# Bu satır, yazı tipi dosyalarının arandığı klasörleri çıktılar.
# Bunlar LoadExternalFonts yöntemiyle eklenen klasörler ve sistem yazı tipi klasörleridir.
$fontFolders = FontsLoader::getFontFolders();
```

## **Bir Sunumda Kullanılan Özel Yazı Tiplerini Belirtme**

Aspose.Slides, sunumla birlikte kullanılacak dış yazı tiplerini belirtmenize olanak tanıyan [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) metodunu sunar.

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
    # CustomFont1, CustomFont2, ve assets\fonts & global\fonts klasörleri ve alt klasörlerinden gelen yazı tipleri sunumda kullanılabilir
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Yazı Tiplerini Dışarıdan Yönetme**

Aspose.Slides, ikili veriden dış yazı tiplerini yüklemenizi sağlayan [loadExternalFont](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) metodunu sunar.

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
        # sunum süresi boyunca harici yazı tipi yüklendi
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

### Özel yazı tipleri tüm formatlara (PDF, PNG, SVG, HTML) dışa aktarmayı etkiler mi?

Evet. Bağlı yazı tipleri renderlayıcı tarafından tüm dışa aktarma formatlarında kullanılır.

### Özel yazı tipleri otomatik olarak sonuç PPTX dosyasına gömülür mü?

Hayır. Bir yazı tipini renderleme için kaydetmek, PPTX dosyasına gömmekle aynı şey değildir. Yazı tipinin sunum dosyasında taşınmasını istiyorsanız, açıkça [gömme özelliklerini](/slides/tr/php-java/embedded-font/) kullanmalısınız.

### Bir özel yazı tipi belirli glifleri içermediğinde geri dönüş davranışını kontrol edebilir miyim?

Evet. İstenen glif bulunmadığında hangi yazı tipinin kullanılacağını tam olarak tanımlamak için [yazı tipi ikamesi](/slides/tr/php-java/font-substitution/), [değiştirme kuralları](/slides/tr/php-java/font-replacement/) ve [geri dönüş setleri](/slides/tr/php-java/fallback-font/) yapılandırabilirsiniz.

### Yazı tiplerini Linux/Docker konteynerlerinde sistem genelinde kurmadan kullanabilir miyim?

Evet. Kendi yazı tipi klasörlerinize işaret edebilir veya yazı tiplerini bayt dizilerinden yükleyebilirsiniz. Bu, konteyner imajındaki sistem yazı tipi dizinlerine olan bağımlılığı ortadan kaldırır.

### Lisanslama nasıl? Herhangi bir özel yazı tipini kısıtlama olmadan gömebilir miyim?

Yazı tipi lisansına uyumdan siz sorumlusunuz. Şartlar farklılık gösterir; bazı lisanslar gömme veya ticari kullanımını yasaklar. Çıktıları dağıtmadan önce her zaman yazı tipinin EULA'sını gözden geçirin.