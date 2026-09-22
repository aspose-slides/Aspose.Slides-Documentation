---
title: PHP'de Sunumları Aç
linktitle: Sunumu Aç
type: docs
weight: 20
url: /tr/php-java/open-presentation/
keywords:
- PowerPoint Aç
- Sunumu Aç
- PPTX Aç
- PPT Aç
- ODP Aç
- Sunumu Yükle
- PPTX Yükle
- PPT Yükle
- ODP Yükle
- Korunan Sunum
- Büyük Sunum
- Harici Kaynak
- İkili Nesne
- PHP
- Aspose.Slides
description: "PHP'de PowerPoint ve OpenDocument sunumlarını nasıl açacağınızı, açma parolaları sağlayarak, kaynak yüklemeyi kontrol ederek ve Aspose.Slides for PHP via Java ile bellek kullanımını nasıl azaltacağınızı öğrenin."
---
## **Giriş**

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/tr/php-java/) dosyalar ve akışlardan PowerPoint ve OpenDocument sunumlarını yükleyebilir. Sunum yüklendikten sonra yapısını inceleyebilir, slaytları düzenleyebilir, kaynakları yönetebilir ve orijinal ya da başka bir desteklenen formatta kaydedebilirsiniz.

Yükleme davranışı, [LoadOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/) sınıfı aracılığıyla özelleştirilebilir. Örneğin, bir açma parolası sağlayabilir, büyük ikili nesneleri Java yığın belleğinin dışında tutabilir, dış kaynakları kontrol edebilir veya gömülü ikili verileri atlayabilirsiniz.

## **Sunumları Aç**

Bir dosya veya akış yüklendikten sonra, uygulamanızın nasıl işleyeceğini seçmek için [orijinal sunum formatını belirleyin](/slides/tr/php-java/detect-presentation-source-format/).

Mevcut bir sunumu açmak için, dosya yolunu [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) yapıcısına gönderin. Sunumu kullandıktan sonra, dosya tanıtıcıları, geçici veriler ve diğer kaynakların hızlı bir şekilde serbest bırakılması için dispose edin.

Aşağıdaki PHP örneği, bir sunumu nasıl açacağınızı ve slayt sayısını nasıl alacağınızı gösterir:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **Parola Korumasıyla Açılan Sunumlar**

Açma parolası, sunum içeriğini şifreler. Sunumu tamamen yüklemek için, doğru parolayı [LoadOptions::setPassword](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/#setPassword) metoduna geçirin ve seçenekleri [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) yapıcısına sağlayın. Parola eksik ya da yanlış olduğunda yükleme başarısız olur.

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

Parola algılama, doğrulama ve şifreleme iş akışları için [Password-Protect Presentations](/slides/tr/php-java/password-protected-presentation/) sayfasına bakın. Şifrelenmiş bir sunum, kasıtlı olarak genel belge özellikleriyle kaydedildiyse, bu özellikler parola olmadan okunabilir; buna [Manage Presentation Properties](/slides/tr/php-java/presentation-properties/) sayfasından ulaşabilirsiniz.

## **Büyük Sunumları Aç**

[LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) , Aspose.Slides'in görüntüler, ses ve video gibi büyük ikili nesneleri nasıl yönettiğini kontrol eden seçenekleri döndürür. Kaynak dosyayı kilitli tutabilir, geçici dosyalara izin verebilir ve bellekte tutulan BLOB veri miktarını sınırlayabilirsiniz.

Aşağıdaki PHP kodu, büyük bir sunumun (örneğin 2 GB) nasıl yükleneceğini gösterir:

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
With [PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked), the source file remains locked until the presentation instance is disposed. Do not move, overwrite, or delete the source file while that instance is alive.

Aspose.Slides may copy the contents of an input stream while loading it. For large presentations, a file path is therefore generally more efficient than a stream. See [Manage BLOBs](/slides/tr/php-java/manage-blob/) for additional storage and memory-management options.
{{% /alert %}}

## **Harici Kaynakları Kontrol Et**

[LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback) PHP/Java Bridge üzerinden Java [IResourceLoadingCallback](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iresourceloadingcallback/) arayüzünün bir uygulamasını kabul eder. Geri çağırma, yerine veri sağlayabilir, bir kaynağı yönlendirebilir, varsayılan yükleyiciyi kullanabilir veya kaynağı atlayabilir. Bu, sunumlarda uygulamaya özgü güvenlik veya depolama kurallarına göre çözülmesi gereken harici görüntüler bulunduğunda yararlıdır.

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

## **Gömülü İkili Nesneler Olmadan Sunumları Yükle**

Bir sunum, uygulamanın ihtiyacı olmayan veya tutmak istemediği gömülü ikili veriler içerebilir. Örnekler:

- VBA projeleri, [Presentation::getVbaProject](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getVbaProject) aracılığıyla erişilebilir;
- gömülü OLE verileri, [OleEmbeddedDataInfo::getEmbeddedFileData](https://reference.aspose.com/slides/tr/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) aracılığıyla erişilebilir;
- ActiveX kontrol verileri, [Control::getActiveXControlBinary](https://reference.aspose.com/slides/tr/php-java/aspose.slides/control/#getActiveXControlBinary) aracılığıyla erişilebilir.

[LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) `true` olarak ayarlayarak bu ikili verileri yükleme sırasında kaldırabilirsiniz. Temizlenmiş sonucu kalıcı kılmak için yüklenen sunumu kaydedin.

Bu seçenek istenmeyen gömülü yükleri azaltır, ancak tam bir kötü amaçlı yazılım tespiti veya içerik temizleme sistemi değildir.

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

Aspose.Slides, yükleme sırasında bir ayrıştırma veya format istisnası fırlatır. Bu hatayı, hatalı parola hatasından ayrı olarak ele alın, böylece uygulama nedeni doğru bir şekilde raporlayabilir.

**Gerekli yazı tipleri eksik olursa ne olur?**

Sunum yine de yüklenebilir, ancak renderlama ve dışa aktarma sırasında yazı tipleri değiştirilebilir. Çıktıyı daha öngörülebilir kılmak için [configure font substitution](/slides/tr/php-java/font-substitution/) ya da [provide custom fonts](/slides/tr/php-java/custom-font/) yapabilirsiniz.

**Bir sunumu yüklemek aynı zamanda gömülü medyalarını da yükler mi?**

Gömülü ses ve video, sunum nesne modeli aracılığıyla erişilebilir olur. Harici kaynaklar, yapılandırılmış kaynak yükleme davranışına göre çözülür ve konumlarına erişilemezse kullanılamaz olabilir.