---
title: PHP'de Sunumları Açma
linktitle: Sunumu Aç
type: docs
weight: 20
url: /tr/php-java/open-presentation/
keywords:
- PowerPoint aç
- OpenDocument aç
- sunum aç
- PPTX aç
- PPT aç
- ODP aç
- sunumu yükle
- PPTX yükle
- PPT yükle
- ODP yükle
- korumalı sunum
- büyük sunum
- harici kaynak
- ikili nesne
- PHP
- Aspose.Slides
description: "Java aracılığıyla PHP için Aspose.Slides ile PowerPoint (.pptx, .ppt) ve OpenDocument (.odp) sunumlarını zahmetsizce açın — hızlı, güvenilir, tam özellikli."
---
## **Giriş**

Sıfırdan PowerPoint sunumları oluşturmanın ötesinde, Aspose.Slides mevcut sunumları da açmanıza olanak tanır. Bir sunumu yükledikten sonra, onunla ilgili bilgi alabilir, slayt içeriğini düzenleyebilir, yeni slaytlar ekleyebilir, mevcut slaytları kaldırabilir ve daha fazlasını yapabilirsiniz.

## **Sunumları Açma**

Mevcut bir sunumu açmak için, [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun ve dosya yolunu yapıcıya geçirin.

Aşağıdaki PHP örneği, bir sunumu nasıl açacağınızı ve slayt sayısını nasıl alacağınızı gösterir:

```php
// Presentation sınıfını örnekleyin ve yapıcıya bir dosya yolu geçirin.
$presentation = new Presentation("Sample.pptx");
try {
    // Sunumdaki toplam slayt sayısını yazdır.
    echo($presentation->getSlides()->size());
} finally {
    $presentation->dispose();
}
```

## **Şifre Korumalı Sunumları Açma**

Şifre korumalı bir sunumu açmanız gerektiğinde, şifreyi [LoadOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/) sınıfının [setPassword](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/#setPassword) yöntemiyle geçirerek çözüp yükleyebilirsiniz. Aşağıdaki PHP kodu bu işlemi gösterir:

```php
$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$presentation = new Presentation("Sample.pptx", $loadOptions);
try {
    // Şifrelenmiş sunum üzerinde işlemler gerçekleştir.
} finally {
    $presentation->dispose();
}
```

## **Büyük Sunumları Açma**

Aspose.Slides, büyük sunumları yüklemenize yardımcı olmak için seçenekler sunar—özellikle [LoadOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/) sınıfındaki [getBlobManagementOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) yöntemi.

Aşağıdaki PHP kodu, büyük bir sunumu (örneğin 2 GB) yüklemeyi gösterir:

```php
$filePath = "LargePresentation.pptx";

$loadOptions = new LoadOptions();
// Choose the KeepLocked behavior—the presentation file will remain locked for the lifetime of
// the Presentation instance, but it does not need to be loaded into memory or copied to a temporary file.
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

$presentation = new Presentation($filePath, $loadOptions);
try {
    // The large presentation has been loaded and can be used, while memory consumption remains low.

    // Make changes to the presentation.
    $presentation->getSlides()->get_Item(0)->setName("Very large presentation");

    // Save the presentation to another file. Memory consumption remains low during this operation.
    $presentation->save("LargePresentation-copy.pptx", SaveFormat::Pptx);
	
	// Don't do this! An I/O exception will be thrown because the file is locked until the presentation object is disposed.
	//unlink($filePath);
} finally {
    $presentation->dispose();
}
// It is OK to do it here. The source file is no longer locked by the presentation object.
unlink($filePath);
```

{{% alert color="info" title="Info" %}}
Akışlarla (streams) çalışırken bazı sınırlamaları aşmak için Aspose.Slides akışın içeriğini kopyalayabilir. Bir akıştan büyük bir sunumu yüklemek, sunumun kopyalanmasına neden olur ve yükleme süresini yavaşlatabilir. Bu nedenle, büyük bir sunumu yüklemeniz gerektiğinde, akış yerine sunum dosya yolunu kullanmanızı şiddetle öneririz.

Büyük nesneler (video, ses, yüksek çözünürlüklü görüntüler vb.) içeren bir sunum oluştururken, bellek tüketimini azaltmak için [BLOB management](/slides/tr/php-java/manage-blob/) kullanabilirsiniz.
{{%/alert %}}

## **Harici Kaynakları Kontrol Etme**

Aspose.Slides, harici kaynakları yönetmenizi sağlayan [IResourceLoadingCallback](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iresourceloadingcallback/) arayüzünü sunar. Aşağıdaki PHP kodu, `IResourceLoadingCallback` arayüzünün nasıl kullanılacağını gösterir:

```php
class ImageLoadingHandler {
    function resourceLoading($args) {
        if (java_values($args->getOriginalUri()->endsWith(".jpg"))) {
            // Yerine bir görsel yükle.
			$bytes = file_get_contents("aspose-logo.jpg");
			$javaByteArray = java_values($bytes);
            $args->setData($javaByteArray);
            return ResourceLoadingAction::UserProvided;
        } else if (java_values($args->getOriginalUri()->endsWith(".png"))) {
            // Yerine bir URL ayarla.
            $args->setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }
        // Diğer tüm görselleri atla.
        return ResourceLoadingAction::Skip;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("Sample.pptx", $loadOptions);
```

## **Gömülü İkili Nesneler Olmadan Sunumları Yükleme**

Bir PowerPoint sunumu aşağıdaki türlerde gömülü ikili nesneler içerebilir:

- VBA projesi ([Presentation.getVbaProject](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getVbaProject) aracılığıyla erişilebilir);
- OLE nesnesi gömülü verisi ([OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/tr/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) aracılığıyla erişilebilir);
- ActiveX denetimi ikili verisi ([Control.getActiveXControlBinary](https://reference.aspose.com/slides/tr/php-java/aspose.slides/control/#getActiveXControlBinary) aracılığıyla erişilebilir).

[LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) yöntemini kullanarak, herhangi bir gömülü ikili nesne olmadan bir sunumu yükleyebilirsiniz.

Bu yöntem, potansiyel olarak kötü amaçlı ikili içeriği kaldırmak için faydalıdır. Aşağıdaki PHP kodu, hiçbir gömülü ikili içerik olmadan bir sunumu nasıl yükleyeceğinizi gösterir:

```php
$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("malware.ppt", $loadOptions);
try {
    // Sunum üzerinde işlemler gerçekleştir.
} finally {
    $presentation->dispose();
}
```

## **SSS**

**Bir dosyanın bozuk olduğunu ve açılamadığını nasıl anlayabilirim?**  
Yükleme sırasında bir ayrıştırma/biçim doğrulama istisnası alırsınız. Bu tür hatalar genellikle geçersiz bir ZIP yapısını veya bozuk PowerPoint kayıtlarını belirtir.

**Açma sırasında gerekli yazı tipleri eksik olursa ne olur?**  
Dosya açılacaktır, ancak daha sonra [rendering/export](/slides/tr/php-java/convert-presentation/) yazı tiplerini değiştirebilir. Çalışma zamanına [yazı tipi ikamelerini yapılandırın](/slides/tr/php-java/font-substitution/) veya [gereken yazı tiplerini ekleyin](/slides/tr/php-java/custom-font/).

**Açma sırasında gömülü medya (video/ses) ne olur?**  
Sunum kaynakları olarak kullanılabilir hale gelirler. Medyalar dış yollarla referans veriliyorsa, bu yolların ortamınızda erişilebilir olduğundan emin olun; aksi takdirde [rendering/export](/slides/tr/php-java/convert-presentation/) medya atlanabilir.