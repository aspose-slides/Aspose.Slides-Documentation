---
title: PHP'de Sunumları Açma
linktitle: Sunumu Aç
type: docs
weight: 20
url: /tr/php-java/open-presentation/
keywords:
- PowerPoint'ı aç
- sunumu aç
- PPTX'i aç
- PPT'yi aç
- ODP'yi aç
- sunumu yükle
- PPTX'i yükle
- PPT'yi yükle
- ODP'yi yükle
- korumalı sunum
- büyük sunum
- harici kaynak
- ikili nesne
- PHP
- Aspose.Slides
description: "PHP'de PowerPoint ve OpenDocument sunumlarını nasıl açacağınızı, açma şifreleri sağlamayı, kaynak yüklemeyi kontrol etmeyi ve Aspose.Slides for PHP via Java ile bellek kullanımını azaltmayı öğrenin."
---
## **Giriş**

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/tr/php-java/) dosyalardan ve akışlardan PowerPoint ve OpenDocument sunumlarını yükleyebilir. Bir sunum yüklendikten sonra, yapısını inceleyebilir, slaytları düzenleyebilir, kaynakları yönetebilir ve orijinal ya da başka bir desteklenen formatta kaydedebilirsiniz.

Yükleme davranışı, [LoadOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/) sınıfı aracılığıyla özelleştirilebilir. Örneğin, bir açma şifresi sağlayabilir, büyük ikili nesneleri Java yığını belleğinin dışında tutabilir, harici kaynakları kontrol edebilir veya gömülü ikili verileri atlayabilirsiniz.

## **Sunumları Açma**

Mevcut bir sunumu açmak için, dosya yolunu [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) yapıcıya iletin. Sunumu kullandıktan sonra serbest bırakın, böylece dosya tanıtıcıları, geçici veriler ve diğer kaynaklar hızlıca serbest bırakılır.

Aşağıdaki PHP örneği, bir sunumu nasıl açıp slayt sayısını nasıl alacağınızı gösterir:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **Şifre Koruması Olan Sunumları Açma**

Açma şifresi, sunum içeriğini şifreler. Tam sunumu yüklemek için doğru şifreyi [LoadOptions::setPassword](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/#setPassword) metoduna iletin ve seçenekleri [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) yapıcısına sağlayın. Şifre eksik ya da hatalı olduğunda yükleme başarısız olur.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-presentation.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

Şifre algılama, doğrulama ve şifreleme iş akışları için [Password-Protect Presentations](/slides/tr/php-java/password-protected-presentation/) bölümüne bakın. Şifreli bir sunum kasıtlı olarak genel belge özellikleriyle kaydedildiyse, bu özellikler şifre olmadan okunabilir; [Manage Presentation Properties](/slides/tr/php-java/presentation-properties/) bölümüne bakın.

## **Büyük Sunumları Açma**

[LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) görüntüler, ses ve video gibi ikili büyük nesnelerin (BLOB) Aspose.Slides tarafından nasıl yönetileceğini kontrol eden seçenekleri döndürür. Kaynak dosyayı kilitli tutabilir, geçici dosyalara izin verebilir ve bellekte tutulan BLOB verisinin miktarını sınırlayabilirsiniz.

Aşağıdaki PHP kodu, büyük bir sunumu (örneğin 2 GB) yüklemeyi gösterir:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationLockingBehavior;
use aspose\slides\SaveFormat;

$filePath = "large-presentation.pptx";

$loadOptions = new LoadOptions();
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024);

$presentation = new Presentation($filePath, $loadOptions);
try {
    $presentation->getSlides()->get_Item(0)->setName("Large presentation");
    $presentation->save("large-presentation-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Bu davranışla [PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked), kaynak dosya, sunum örneği serbest bırakılana kadar kilitli kalır. O örnek hayatta olduğu sürece kaynak dosyayı taşımayın, üzerine yazmayın veya silmeyin.

Aspose.Slides, yükleme sırasında bir giriş akışının içeriğini kopyalayabilir. Büyük sunumlar için dosya yolu genellikle akıstan daha verimlidir. Ek depolama ve bellek yönetimi seçenekleri için [Manage BLOBs](/slides/tr/php-java/manage-blob/) bölümüne bakın.
{{% /alert %}}

## **Harici Kaynakları Kontrol Etme**

[LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback) PHP/Java Bridge aracılığıyla Java [IResourceLoadingCallback](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iresourceloadingcallback/) arayüzünün bir uygulamasını kabul eder. Geri arama, yedek veri sağlayabilir, bir kaynağı yönlendirebilir, varsayılan yükleyiciyi kullanabilir veya kaynağı atlayabilir. Bu, sunumlarda uygulamaya özgü güvenlik ya da depolama kurallarına göre çözümlenmesi gereken harici görüntüler bulunduğunda faydalıdır.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ResourceLoadingAction;

class ImageLoadingHandler {
    function resourceLoading($args) {
        $originalUri = strtolower(java_values($args->getOriginalUri()));
        $approvedImagePath = "approved-image.jpg";
        $isJpeg = substr($originalUri, -4) === ".jpg";

        if (!$isJpeg || !file_exists($approvedImagePath)) {
            return ResourceLoadingAction::Skip;
        }

        $imageData = file_get_contents($approvedImagePath);
        if ($imageData === false) {
            echo("The approved replacement image could not be read.\n");
            return ResourceLoadingAction::Skip;
        }

        $args->setData(java_values($imageData));
        return ResourceLoadingAction::UserProvided;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("presentation-with-external-images.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **Gömülü İkili Nesneler Olmadan Sunumları Yükleme**

Bir sunum, uygulamanın ihtiyacı olmayan veya tutmak istemediği gömülü ikili veriler içerebilir. Örnekler:

- VBA projeleri, [Presentation::getVbaProject](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getVbaProject) aracılığıyla erişilebilir;
- gömülü OLE verileri, [OleEmbeddedDataInfo::getEmbeddedFileData](https://reference.aspose.com/slides/tr/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) aracılığıyla erişilebilir;
- ActiveX kontrol verileri, [Control::getActiveXControlBinary](https://reference.aspose.com/slides/tr/php-java/aspose.slides/control/#getActiveXControlBinary) aracılığıyla erişilebilir.

[LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) `true` olarak ayarlayarak bu ikili verileri yükleme sırasında kaldırabilirsiniz. Temizlenmiş sonucu kalıcı hâle getirmek için yüklenen sunumu kaydedin.

Bu seçenek, istenmeyen gömülü yüklerden kaynaklanan riski azaltır, ancak tam bir kötü amaçlı yazılım tespiti ya da içerik temizleme sistemi değildir.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("presentation-with-embedded-data.pptx", $loadOptions);
try {
    $presentation->save("presentation-without-embedded-data.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **SSS**

**Bir dosyanın bozuk olduğunu ve açılamadığını nasıl anlayabilirim?**

Aspose.Slides, yükleme sırasında bir ayrıştırma ya da format istisnası fırlatır. Bu hatayı, hatalı şifre hatasından ayrı şekilde ele alın, böylece uygulama nedeni doğru bir şekilde raporlayabilir.

**Gerekli yazı tipleri eksik olduğunda ne olur?**

Sunum hâlâ yüklenebilir, ancak render ve dışa aktarım sırasında yazı tipleri yerine başka yazı tipleri kullanılabilir. Çıktıyı daha öngörülebilir hâle getirmek için [configure font substitution](/slides/tr/php-java/font-substitution/) ya da [provide custom fonts](/slides/tr/php-java/custom-font/) kullanabilirsiniz.

**Bir sunumu yüklemek aynı zamanda gömülü medyalarını da yükler mi?**

Gömülü ses ve video, sunum nesne modeli aracılığıyla erişilebilir olur. Harici kaynaklar, yapılandırılmış kaynak yükleme davranışına göre çözülür ve konumlarına erişilemezse kullanılabilir olmayabilir.