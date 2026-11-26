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
description: "Aspose.Slides for PHP via Java'da sunum özelliklerini yönetin ve PowerPoint ve OpenDocument dosyalarınızda aramayı, markalamayı ve iş akışını basitleştirin."
---
## **Giriş**

Aspose.Slides for PHP via Java, **yerleşik** ve **özel** belge özelliklerini destekler. Bu özellikleri yazar, başlık ve kullanıcı tanımlı değerler gibi sunum meta verilerini okumak ve güncellemek için kullanın.

Aspose.Slides, sunum belge özellikleriyle [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) sınıfı aracılığıyla çalışmanıza izin verir. Bu sınıfın bir örneği [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties) tarafından döndürülür. Aşağıdaki örnekler bu özelliklerin nasıl okunacağını, değiştirileceğini ve yönetileceğini gösterir. PHP/Java Bridge ve Aspose.Slides PHP sarmalayıcısının başlatıldığını varsayarlar.

{{% alert color="info" title="Note" %}}
Aspose.Slides, sunumları kaydederken uygulama ve üretici meta verilerini yönetir; bu alanlar çıktıyı oluşturan yazılımı tanımlar.
{{% /alert %}}

## **Sunum Özelliklerini Yönet**

Belge özellikleri, sunum içeriğiyle birlikte açıklayıcı bilgi depolar. İki kategoriye ayrılırlar:

- **Yerleşik özellikler** standard meta verileri içerir, örneğin başlık, yazar ve belge istatistikleri.
- **Özel özellikler** kullanıcı tanımlı ad/değer çiftlerini depolar.

Aspose.Slides for PHP via Java, her iki kategoriye de erişim sağlar. PowerPoint'ta belge meta verilerini incelemek için **File → Info → Properties → Advanced Properties** seçeneğini kullanın. İletişim kutusu bilgileri **Summary**, **Statistics**, **Contents** ve **Custom** gibi sekmelere ayırır. Kullanıcı tanımlı özellikleri yönetmek için **Custom** sekmesini kullanın.

## **Şifreli Sunumdan Genel Özellikleri Okuma**

Bir açma parolası genellikle hem sunum içeriğini hem de belge özelliklerini korur. Sunum, [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) `false` ile çağrıldıktan sonra şifrelenirse, belge özellikleri genel olarak kalır. Bir uygulama daha sonra [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) `true` ile çağırarak açma parolası vermeden genel meta verileri okuyabilir.

[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) Aspose.Slides'in neyi yükleyeceğini kontrol eder; hiçbir şeyi çözmez. Özellikler şifreleme içine dahil edilmişse, parolası olmadan yükleme başarısız olur. Sunum şifrelenmemişse, seçenek yok sayılır ve tam sunum yüklenir.

Örnek, belge özellikleri genel bırakılmış bir şifreli sunum gerektirir. Yükleme modunu [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) ile doğrular ve ardından [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties) aracılığıyla yerleşik özellikleri okur:

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

Bu modda slayt içeriği yüklenmez. Slaytlar, master slaytlar, düzenler, şekiller, medya ve diğer sunum nesneleri kullanılamaz. Uygulamalar, tam sunum nesne modelini gerektiren bir işlem yapmadan önce her zaman [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) kontrol etmelidir.

{{% alert color="warning" title="Warning" %}}
Genel meta veriler yazar adlarını, başlıkları, konuları, anahtar kelimeleri, şirket bilgilerini, yorumları ve özel değerleri ifşa edebilir. Hassas özellikleri sunumla birlikte şifreleyin. Bunları yalnızca indeksleme, sınıflandırma, arama veya belge yönetim sistemlerinin şifre olmadan erişim ihtiyacı olduğunda genel bırakın.
{{% /alert %}}

## **Şifreli Sunumun Özelliklerini Güncelleme**

Şifreli bir PPTX dosyası için, [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) `true` ile çağrıldıktan sonra yüklenen bir sunum, genel meta verileri okumak için tasarlanmıştır. Aspose.Slides, bu yalnızca meta veri nesnesinden değiştirilen özellikleri kaydedemez çünkü genel özellikler şifreli sunumdaki ilgili veriyle tutarlı olmalıdır. Bu nedenle güncelleme doğru açma parolası ve tam yükleme gerektirir.

Örnek, genel belge özelliklerine sahip şifreli bir PPTX sunumu ve bilinen bir açma parolası gerektirir. Tam sunumu [LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setPassword) ile açar, genel yerleşik özellikleri günceller ve sonucu kaydeder. Ardından [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#isEncrypted) kullanarak şifrelemenin korunduğunu doğrular ve yeni değerleri kontrol etmek için genel meta verileri parolasız yeniden açar:

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

Bir uygulama sunum içeriğini çözme veya yükleme iznine sahip değilse, şifreli bir PPTX dosyasının genel özelliklerini yalnızca okunabilir olarak değerlendirmelidir.

## **Yerleşik Özelliklere Erişim**

[DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) sınıfı, [getAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getAuthor), [getTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getTitle) ve [getCreatedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCreatedTime) gibi getter yöntemleri aracılığıyla yerleşik meta verileri sunar. Bu örnek mevcut bir sunumu açar ve saklanan meta verileri konsola yazdırır. Değerler giriş sunumuna bağlıdır; bazı alanlar boş olabilir.

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

### **Revizyon Numarasını ve Düzenleme Süresini Raporla**

`presentations` klasöründeki her PPTX dosyası için revizyon numarasını ve toplam düzenleme süresini raporlamak amacıyla, slaytları düzenleme için yüklemeden [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#readDocumentProperties) kullanarak [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) okunur. PHP via Java API, düzenleme süresini milisaniye olarak döndürür. Örnek, bunu saat, dakika ve saniyeye çevirir ve 24 saatten uzun sürelere gün sayısı ekler.

```php
use aspose\slides\PresentationFactory;

echo "File | RevisionNumber | TotalEditingTime\n";
foreach (new GlobIterator("presentations/*.pptx") as $file) {
    if (!$file->isFile()) {
        continue;
    }

    $info = PresentationFactory::getInstance()->getPresentationInfo($file->getRealPath());
    $properties = $info->readDocumentProperties();
    $totalSeconds = (int) (java_values($properties->getTotalEditingTime()) / 1000);
    $days = intdiv($totalSeconds, 86400);
    $time = sprintf("%02d:%02d:%02d", intdiv($totalSeconds, 3600) % 24, intdiv($totalSeconds, 60) % 60, $totalSeconds % 60);
    $editingTime = $days > 0 ? $days . "." . $time : $time;
    printf("%s | %d | %s\n", $file->getFilename(), java_values($properties->getRevisionNumber()), $editingTime);
}
```

Revizyon numarası 17 ve kaydedilmiş düzenleme süresi 1 gün, 2 saat ve 5 dakika olan bir sunum için rapor aşağıdaki çıktıyı gösterir.

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[DocumentProperties::getRevisionNumber](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getRevisionNumber) bir değeri okur; bu değer uygulamalar tarafından [DocumentProperties::setRevisionNumber](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setRevisionNumber) ile değiştirilebilir. Revizyon numarası tek başına sunumun kaç kez kaydedildiğini belirleyemez veya sürüm geçmişini yeniden oluşturamaz.

[DocumentProperties::getTotalEditingTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getTotalEditingTime) dosyada kaydedilen düzenleme süresini okur. Bir sunum, birisi düzenlemiş olsa bile saklanan süresi sıfır (`00:00:00`) olabilir.

## **Yerleşik Özellikleri Değiştir**

Yerleşik meta verileri güncellemek için, [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties) tarafından döndürülen nesnenin setter yöntemlerini kullanın. Bu örnek mevcut bir sunumu açar, [setAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setAuthor), [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setTitle), [setSubject](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setSubject), [setComments](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setComments) ve [setManager](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setManager) metodlarını çağırır, ardından güncellenmiş sunumu [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) ile kaydeder. Kaydedilen PPTX yeni meta verileri içerir.

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

## **Hipermenin Temelini Yönet**

[DocumentProperties::getHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getHyperlinkBase) göreceli hipermeninler için belge düzeyinde temel adresi döndürür. Bu temeli değiştirmek veya temizlemek için [DocumentProperties::setHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setHyperlinkBase) kullanın. Sunumu ve bağlı dosyalarını başka bir konuma taşırken faydalıdır. Bu, tek bir hipermenin'in [Hyperlink::getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/#getExternalUrl) yönteminden ayrı bir özelliktir: temeli değiştirmek, kaydedilen bağlantı adreslerini yeniden yazmaz veya mutlak hedefleri değiştirmez.

Bu örnek, `target.html` gibi bir göreceli bağlantı ve `https://example.org/absolute.html` gibi bir mutlak bağlantı içeren bir sunum gerektirir. Mevcut temeli okur, yeni bir temel adresi atar ve değeri kontrol etmek için sunumu kaydedip yeniden açar. Ardından temeli boş bir dizeyle temizler ve ayrı bir kaydedilmiş dosyada boş değeri doğrular. Örnek temel adresini, bağlı dosyalarınızın konumuyla değiştirin.

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

İki doğrulama mesajı `true` yazdırmalıdır. Temelin temizlenmesi, tek tek hipermenin adreslerini aynı tutar.

`target.pptx`'ye göreceli bir bağlantı, temel `old` klasörüne işaret ettiğinde `old/target.pptx` dosyasını açtı. Temel `new` klasörüne değiştirildikten, kaydedilip sunum yeniden açıldıktan sonra aynı bağlantı `new/target.pptx` dosyasını açtı. Mutlak bir bağlantı aynı dosyayı açmaya devam etti. Sunumu taşımadan veya temelini değiştirmeden önce ve sonra PowerPoint'te göreceli bağlantılarınızı test edin.

## **Özel Sunum Özellikleri Ekle**

Özel özellikler, karşılığı yerleşik bir alan olmayan meta verileri depolar. [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#set_Item) yöntemi, özellik adına göre bir değer atamanızı sağlar. Bu örnek bir sunum oluşturur, iki metin değeri ve bir tam sayı sürüm değeri ekler ve sunumu [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) ile kaydeder. Mevcut bir ada değer atamak, o özelliğin değerini değiştirir.

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

Bu örnek, özel özellikler içeren bir sunumu açar ve [getCountOfCustomProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCountOfCustomProperties) kullanarak üzerlerinde döner. [getCustomPropertyName](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCustomPropertyName), sıfır tabanlı bir indeks alır ve [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#set_Item) tarafından kullanılan adı döndürür. Örnek, her orijinal adı ve değeri yazdırır, tüm değerleri orijinal tipine bakılmaksızın numaralı bir dizeyle değiştirir ve değişiklikleri kaydeder. Eğer özel özellik yoksa, döngü hiçbir değişiklik yapmaz.

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

Aspose.Slides API'siyle belge özellikleriyle nasıl çalışılacağını görmek için çevrimiçi uygulama [**PowerPoint Meta Verilerini Görüntüle ve Düzenle**](https://products.aspose.app/slides/metadata) deneyin:

[![PowerPoint Meta Verilerini Görüntüle ve Düzenle](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **SSS**

**Bir sunumdan yerleşik bir özelliği nasıl kaldırabilirim?**

Yerleşik özellikler, sunumun ayrılmaz bir parçasıdır ve tamamen kaldırılamaz. Ancak, değerlerini değiştirebilir veya belirli özellik izin veriyorsa boş olarak ayarlayabilirsiniz.

**Zaten var olan bir özel özellik eklersem ne olur?**

Zaten var olan bir özel özellik eklenirse, mevcut değeri yeniyle üzerine yazılır. Özelliği önceden kaldırmanıza veya kontrol etmenize gerek yoktur; Aspose.Slides özelliğin değerini otomatik olarak günceller.

**Sunumu tamamen yüklemeden sunum özelliklerine erişebilir miyim?**

Evet. [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/#getPresentationInfo) ve ardından [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#readDocumentProperties) kullanarak [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) örneği oluşturulmadan saklanan belge meta verilerini okuyabilirsiniz. Tam bir raporlama örneği ve format‑spesifik sınırlamalar için [Hafif Bir Sunum Envanteri Oluştur](/slides/tr/php-java/examine-presentation/) bölümüne bakın.

**Şifreli bir sunumun genel özelliklerini açma parolası olmadan okuyabilir miyim?**

Evet. Sunum, [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) `false` ile çağrıldıktan sonra şifrelenmiş olmalı ve [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) `true` ile çağrıldıktan sonra yüklenmiş olmalıdır.

**Belge‑sadece‑özellikleri modunda bir şifreli PPTX dosyasını güncelleyebilir miyim?**

Hayır. Genel ve şifreli özellik verileri tutarlı olmalıdır; bu nedenle şifreli bir PPTX dosyasını güncellemek, doğru açma parolasıyla tam sunumu yüklemeyi gerektirir.