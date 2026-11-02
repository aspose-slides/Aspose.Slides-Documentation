---
title: PHP'de Sunum Özelliklerini Yönet
linktitle: Sunum Özellikleri
type: docs
weight: 70
url: /tr/php-java/presentation-properties/
keywords:
- PowerPoint özellikleri
- sunum özellikleri
- belge özellikleri
- yerleşik özellikler
- özel özellikler
- gelişmiş özellikler
- özellikleri yönet
- özellikleri değiştir
- belge meta verileri
- meta verileri düzenle
- düzeltme dili
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java'da sunum özelliklerini yönetin ve PowerPoint ve OpenDocument dosyalarınızda aramayı, markalaşmayı ve iş akışını kolaylaştırın."
---
## **Giriş**

Aspose.Slides for PHP via Java **yerleşik** ve **özel** belge özelliklerini destekler. Bu özellikleri, yazar, başlık ve kullanıcı tanımlı değerler gibi sunum meta verilerini okumak ve güncellemek için kullanın.

Aspose.Slides, sunum belge özellikleriyle [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) sınıfı üzerinden çalışmanıza olanak tanır. Bu sınıfın bir örneği [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/) tarafından döndürülür. Aşağıdaki örnekler, bu özelliklerin nasıl okunacağını, değiştirileceğini ve yönetileceğini gösterir. PHP/Java Bridge ve Aspose.Slides PHP sarmalısının başlatıldığını varsayar.

{{% alert color="info" title="Note" %}}
Aspose.Slides, sunumları kaydederken uygulama ve üretici meta verilerini yönetir; bu alanlar çıktıyı oluşturan yazılımı tanımlar.
{{% /alert %}}

## **Sunum Özelliklerini Yönet**

Belge özellikleri, sunum içeriğinin yanında tanımlayıcı bilgileri depolar. İki kategoriye ayrılırlar:

- **Yerleşik özellikler** standart meta verileri içerir, örneğin başlık, yazar ve belge istatistikleri.
- **Özel özellikler** kullanıcı tanımlı ad/değer çiftlerini depolar.

Aspose.Slides for PHP via Java, her iki kategoriye de erişim sağlar. PowerPoint'te belge meta verilerini incelemek için **File → Info → Properties → Advanced Properties** seçeneğini seçin. İletişim kutusu bilgileri **Summary**, **Statistics**, **Contents** ve **Custom** gibi sekmelere ayırır. Kullanıcı tanımlı özellikleri yönetmek için **Custom** sekmesini kullanın.

## **Şifrelenmiş Sunumdan Genel Özellikleri Okuma**

Açma şifresi genellikle sunum içeriğini ve belge özelliklerini korur. Bir sunum, [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) `false` ile şifrelenince, belge özellikleri genel kalır. Bir uygulama daha sonra [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) `true` ile çağırarak açma şifresi vermeden genel meta verileri okuyabilir.

[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) Aspose.Slides'ın neyi yüklediğini kontrol eder; hiçbir şeyi çözmez. Özellikler şifreleme içine dahil edilmişse, şifre olmadan yükleme başarısız olur. Sunum şifreli değilse, seçenek yok sayılır ve tam sunum yüklenir.

Örnek, belge özellikleri genel bırakılmış bir şifreli sunum gerektirir. Yükleme modunu [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/) ile doğrular ve ardından yerleşik özellikleri [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/) aracılığıyla okur:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $documentProperties = $presentation->getDocumentProperties();

        echo("Author: " . $documentProperties->getAuthor() . "\n");
        echo("Title: " . $documentProperties->getTitle() . "\n");
        echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $presentation->dispose();
}
```

Bu modda, slayt içeriği yüklenmez. Slaytlar, masterlar, düzenler, şekiller, medya ve diğer sunum nesneleri kullanılabilir değildir. Uygulamalar, tam sunum nesne modelini gerektiren bir işlem yapmadan önce her zaman [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/) kontrol etmelidir.

{{% alert color="warning" title="Warning" %}}
Genel meta veriler, yazar adları, başlıklar, konular, anahtar kelimeler, şirket bilgileri, yorumlar ve özel değerleri ortaya çıkarabilir. Hassas özellikleri sunumla birlikte şifreleyin. Bunları yalnızca indeksleme, sınıflandırma, arama veya belge yönetim sistemlerinin şifre olmadan erişim gerektirdiği durumlarda genel bırakın.
{{% /alert %}}

## **Şifreli Sunumun Özelliklerini Güncelleme**

Şifreli bir PPTX dosyası için, [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) `true` ile çağırıldıktan sonra yüklenen bir sunum, genel meta verileri okumak içindir. Aspose.Slides, bu yalnızca meta veri nesnesinden değiştirilen özellikleri kaydedemez çünkü genel özellikler, şifreli sunum içindeki ilgili verilerle tutarlı olmalıdır. Bu nedenle güncelleme doğru açma şifresi ve tam bir yükleme gerektirir.

Örnek, genel belge özelliklerine sahip şifreli bir PPTX sunumu ve bilinen bir açma şifresi gerektirir. Tam sunumu [LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setpassword/) ile açar, genel yerleşik özellikleri günceller ve sonucu kaydeder. Ardından şifrelemenin korunduğunu doğrulamak için [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/isencrypted/) kullanır ve yeni değerleri doğrulamak için genel meta verileri şifre olmadan yeniden açar:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;
use aspose\slides\SaveFormat;

$inputPath = "public-properties-encrypted.pptx";
$outputPath = "updated-public-properties-encrypted.pptx";

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation($inputPath, $loadOptions);
try {
    $documentProperties = $presentation->getDocumentProperties();
    $documentProperties->setTitle("Updated Product Roadmap");
    $documentProperties->setKeywords("roadmap, planning, indexed");
    
    $presentation->save($outputPath, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($outputPath);
echo("The presentation is encrypted: " . (java_values($presentationInfo->isEncrypted()) ? "true" : "false") . "\n");

$metadataLoadOptions = new LoadOptions();
$metadataLoadOptions->setOnlyLoadDocumentProperties(true);

$metadataPresentation = new Presentation($outputPath, $metadataLoadOptions);
try {
    if (java_values($metadataPresentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        echo("Title: " . $metadataPresentation->getDocumentProperties()->getTitle() . "\n");
        echo("Keywords: " . $metadataPresentation->getDocumentProperties()->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

Bir uygulamanın sunum içeriğini çözmesine veya yüklemesine izin verilmiyorsa, şifreli bir PPTX dosyasının genel özelliklerini yalnızca okunabilir olarak ele almalıdır.

## **Yerleşik Özelliklere Erişim**

[DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) sınıfı, [getAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getauthor/), [getTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gettitle/) ve [getCreatedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcreatedtime/) gibi getter metodlarıyla yerleşik meta verileri sunar. Bu örnek mevcut bir sunumu açar ve depolanmış meta verileri konsola yazar. Değerler giriş sunumuna bağlıdır; bazı alanlar boş olabilir.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    echo("Category: " . $documentProperties->getCategory() . "\n");
    echo("Content status: " . $documentProperties->getContentStatus() . "\n");
    echo("Creation date: " . $documentProperties->getCreatedTime() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");
    echo("Comments: " . $documentProperties->getComments() . "\n");
    echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    echo("Last modified by: " . $documentProperties->getLastSavedBy() . "\n");
    echo("Manager: " . $documentProperties->getManager() . "\n");
    echo("Modified date: " . $documentProperties->getLastSavedTime() . "\n");
    echo("Presentation format: " . $documentProperties->getPresentationFormat() . "\n");
    echo("Last print date: " . $documentProperties->getLastPrinted() . "\n");
    echo("Is shared between producers: " . (java_values($documentProperties->getSharedDoc()) ? "true" : "false") . "\n");
    echo("Subject: " . $documentProperties->getSubject() . "\n");
    echo("Title: " . $documentProperties->getTitle() . "\n");
} finally {
    $presentation->dispose();
}
```

## **Yerleşik Özellikleri Değiştirme**

Yerleşik meta verileri güncellemek için, [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/) tarafından döndürülen nesnenin setter metodlarını kullanın. Bu örnek mevcut bir sunumu açar, [setAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setauthor/), [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/settitle/), [setSubject](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setsubject/), [setComments](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setcomments/), ve [setManager](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setmanager/) metodlarını çağırır, ardından güncellenen sunumu [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) ile kaydeder. Kaydedilen PPTX yeni meta verileri içerir.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->setAuthor("Aspose.Slides for PHP via Java");
    $documentProperties->setTitle("Manage PowerPoint Presentation Properties");
    $documentProperties->setSubject("Modify Built-in Properties");
    $documentProperties->setComments("Aspose description");
    $documentProperties->setManager("Aspose manager");

    $presentation->save("DocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Hipermetin Bağlantı Temelini Yönetme**

[DocumentProperties::getHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gethyperlinkbase/) göreceli hipermetin bağlantıları için belge seviyesindeki temeli döndürür. [DocumentProperties::setHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/sethyperlinkbase/) ile bunu değiştirebilir veya temizleyebilirsiniz. Bu, bir sunumu ve ilişkili dosyalarını başka bir konuma taşırken faydalıdır. Bu, bireysel bir hipermetin bağlantısının [Hyperlink::getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/) öğesinden ayrıdır: temeli değiştirmek, depolanmış bağlantı adreslerini yeniden yazmaz veya mutlak hedefleri değiştirmez.

Örnek, `target.html` gibi bir göreceli bağlantı ve `https://example.org/absolute.html` gibi bir mutlak bağlantı içeren bir sunum gerektirir. Mevcut temeli okur, yeni bir temel adresi atar ve değeri kontrol etmek için sunumu kaydedip yeniden açar. Ardından temeli boş bir dizeyle temizler ve boş değeri ayrı bir kaydedilmiş dosyada doğrular. Örnek temel adresini, ilişkili dosyalarınızın konumuyla değiştirin.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hyperlinks.pptx");
try {
    echo("Original base: " . $presentation->getDocumentProperties()->getHyperlinkBase() . "\n");

    $newBase = "https://example.com/new/";
    $presentation->getDocumentProperties()->setHyperlinkBase($newBase);
    $presentation->save("hyperlinks-updated.pptx", SaveFormat::Pptx);

    $updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        echo("Base preserved: " . ((string) $updatedPresentation->getDocumentProperties()->getHyperlinkBase() === $newBase ? "true" : "false") . "\n");

        $updatedPresentation->getDocumentProperties()->setHyperlinkBase("");
        $updatedPresentation->save("hyperlinks-cleared.pptx", SaveFormat::Pptx);

        $clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            echo("Base cleared: " . ((string) $clearedPresentation->getDocumentProperties()->getHyperlinkBase() === "" ? "true" : "false") . "\n");
        } finally {
            $clearedPresentation->dispose();
        }
    } finally {
        $updatedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

İki doğrulama mesajı `true` yazdırmalıdır. Temelin temizlenmesi, bireysel hipermetin bağlantı adreslerini olduğu gibi bırakır.

`target.pptx` göreceli bağlantısı, temel `old` klasörüne işaret ettiğinde `old/target.pptx` dosyasını açtı. Temel `new` klasörüne değiştirildikten, kaydedilip sunum yeniden açıldıktan sonra aynı bağlantı `new/target.pptx` dosyasını açtı. Mutlak bir bağlantı aynı dosyayı açmaya devam etti. Sunumu taşımadan veya temeli değiştirmeden önce ve sonra PowerPoint'te göreceli bağlantılarınızı test edin.

## **Özel Sunum Özellikleri Ekleme**

Özel özellikler, karşılığı olan bir yerleşik alanı olmayan meta verileri depolar. [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/) yöntemi, özellik adına göre bir değer atamanızı sağlar. Bu örnek bir sunum oluşturur, iki metin değeri ve bir tam sayı sürüm değeri ekler ve sunumu [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) ile kaydeder. Mevcut bir ada değer atamak, o özelliğin değerini değiştirir.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->set_Item("Reviewed by", "John Smith");
    $documentProperties->set_Item("Confidentiality level", "Internal");
    $documentProperties->set_Item("Document version", 2);

    $presentation->save("CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Özel Özelliklere Erişim ve Değiştirme**

Bu örnek, özel özellikler içeren bir sunumu açar ve [getCountOfCustomProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcountofcustomproperties/) kullanarak bunları döndürür. [getCustomPropertyName](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcustompropertyname/) sıfırdan başlayan bir indeks alır ve [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/) tarafından kullanılan adı döndürür. Örnek, her orijinal adı ve değeri yazar, her değeri orijinal tipine bakılmaksızın numaralı bir dizeyle değiştirir ve değişiklikleri kaydeder. Eğer özel özellik yoksa, döngü hiçbir değişiklik yapmaz.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    for ($i = 0; $i < java_values($documentProperties->getCountOfCustomProperties()); $i++) {
        $propertyName = $documentProperties->getCustomPropertyName($i);
        $propertyValue = $documentProperties->get_Item($propertyName);

        echo("Custom property name: " . $propertyName . "\n");
        echo("Custom property value: " . $propertyValue . "\n");

        $documentProperties->set_Item($propertyName, "New Value " . ($i + 1));
    }

    $presentation->save("CustomProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Canlı Örnek**

Aspose.Slides API'si ile belge özellikleriyle nasıl çalışılacağını görmek için çevrimiçi [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) uygulamasını deneyin:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **SSS**

**Bir sunumdan yerleşik bir özelliği nasıl kaldırabilirim?**

Yerleşik özellikler, sunumun ayrılmaz bir parçasıdır ve tamamen kaldırılamaz. Ancak, değerlerini değiştirebilir veya ilgili özellik izin veriyorsa boş olarak ayarlayabilirsiniz.

**Zaten var olan bir özel özelliği eklersem ne olur?**

Zaten var olan bir özel özellik eklenirse, mevcut değeri yeni değerle üzerine yazılır. Özelliği önceden kaldırmanıza veya kontrol etmenize gerek yoktur; Aspose.Slides otomatik olarak özelliğin değerini günceller.

**Sunumu tam olarak yüklemeden sunum özelliklerine erişebilir miyim?**

Evet. [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/getpresentationinfo/) ve ardından [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/readdocumentproperties/) kullanarak bir [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) örneği oluşturmadan depolanmış belge meta verilerini okuyabilirsiniz. Tam bir raporlama örneği ve format‑özel sınırlamalar için [Build a Lightweight Presentation Inventory](/slides/tr/php-java/examine-presentation/) bölümüne bakın.

**Şifreli bir sunumun genel özelliklerini açma şifresi olmadan okuyabilir miyim?**

Evet. Sunum, [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) `false` ile çağrıldıktan sonra şifrelenmiş olmalı ve [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) `true` ile çağrıldıktan sonra yüklenmiş olmalıdır.

**Belge‑özellikleri‑sadece modunda şifreli bir PPTX dosyasını güncelleyebilir miyim?**

Hayır. Genel ve şifreli özellik verileri tutarlı olmalı, bu yüzden şifreli bir PPTX dosyasını güncellemek, doğru açma şifresiyle tam sunumu yüklemeyi gerektirir.