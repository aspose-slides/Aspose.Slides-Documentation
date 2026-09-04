---
title: PHP'de Sunumları Parola ile Koruma
linktitle: Parola Koruması
type: docs
weight: 20
url: /tr/php-java/password-protected-presentation/
keywords:
- parola korumalı sunum
- açma parolası
- PowerPoint şifrele
- PowerPoint şifre çöz
- sunum parolasını doğrula
- sunum parolasını kontrol et
- şifreli sunumu aç
- şifreleme kaldır
- PowerPoint
- PPT
- PPTX
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides ile PHP'de parola korumalı PowerPoint PPT ve PPTX sunumlarını şifreleme, algılama, doğrulama, açma ve şifre çözme."
---
## **Genel Bakış**

Açma parolası bir sunumu şifreler. Doğru parola, sunum içeriğini yüklemek ve görüntülemek için gereklidir; bu koruma gizlilik sağlar.

Açma parolası, yazma koruma parolasından farklıdır. Yazma koruması, değişikliği kısıtlar ancak içeriği şifrelemez veya sunumun yüklenmesini engellemez. Sunumları değiştirmek için parolaları yönetmek üzere bakınız [Write-Protect Presentations](/slides/tr/php-java/write-protected-presentation/).

Aşağıdaki iş akışları hem PPT hem de PPTX sunumları için geçerlidir. Örnekler, dosya tabanlı ve akış tabanlı davranışların önemli olduğu durumlarda her iki biçimi de kullanır.

## **Açma Parolasıyla Sunumu Şifrele**

Açma parolası atamak için [ProtectionManager::encrypt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/#encrypt) kullanın. Ardından şifrelenmiş sunumu kaydetmek için [Presentation::save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#save) kullanın.

Aşağıdaki örnek bir PPTX sunumunu şifreler:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Belge Özelliklerini Genel Tut**

Varsayılan olarak, Aspose.Slides sunum şifrelemesine belge özelliklerini dahil eder. [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) yöntemi, kaydırak içeriği şifrelemesinden bağımsız olarak bu davranışı kontrol eder. Açma parolası olmadan indeksleme, sınıflandırma, arama veya belge yönetim sistemi metadata okumak zorunda olduğunda, [ProtectionManager::encrypt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/#encrypt) çağırmadan önce `false` geçin.

Aşağıdaki örnek, yerleşik belge özellikleri genel bırakılarak bir PPTX sunumunu şifreli oluşturur:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $properties = $presentation->getDocumentProperties();
    $properties->setAuthor("Contoso Knowledge Management");
    $properties->setTitle("Quarterly Product Roadmap");
    $properties->setKeywords("roadmap, planning, internal");

    $presentation->getSlides()->get_Item(0)->setName("Encrypted presentation content");
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("public-properties-encrypted.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`false` değerini [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) yöntemine geçirmek, slaytları, ana şablonları, düzenleri, şekilleri, medyayı veya diğer sunum içeriklerini genel yapmaz. Yalnızca belge özelliklerini etkiler. Bu özellikleri şifreli içeriği yüklemeden okumak için bakınız [Manage Presentation Properties](/slides/tr/php-java/presentation-properties/).

## **Şifreli Sunumu Yükle**

Dosyayı yüklerken açma parolasını [LoadOptions::setPassword](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/#setPassword) ile ayarlayın ve seçenekleri [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) öğesine geçirin. Açma parolası gerektiğinde, sağlanan parola eksik ya da hatalıysa yükleme başarısız olur.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    # Şifre çözülen sunumla çalışın.
} finally {
    $presentation->dispose();
}
```

## **Sunumdan Şifrelemeyi Kaldır**

Sunumu açma parolasıyla yükleyin, [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/#removeEncryption) yöntemini çağırın ve sonucu kaydedin. Kaydedilen sunum daha sonra parola olmadan yüklenebilir.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Yüklemeden Önce Açma Parolasını Doğrula**

Tam bir sunum örneği oluşturmadan [PresentationInfo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationinfo/) elde etmek için [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationfactory/#getPresentationInfo) kullanın. Parola talep etmeden veya doğrulamadan önce [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationinfo/#isPasswordProtected) kontrol edin. Koruma mevcutsa, sağlanan değeri [PresentationInfo::checkPassword](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationinfo/#checkPassword) ile doğrulayın.

### **Dosya Yolu İş Akışı**

Aşağıdaki örnek bir PPTX dosyası için açma parolasını doğrular, doğrulanan değeri [LoadOptions::setPassword](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/#setPassword) öğesine geçirir ve ardından tam sunumu yükler:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$filePath = "protected-presentation.pptx";
$password = "open_password";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);

if (!$presentationInfo->isPasswordProtected()) {
    echo("The presentation does not have an opening password.\n");
} elseif (!$presentationInfo->checkPassword($password)) {
    echo("The opening password is incorrect.\n");
} else {
    $loadOptions = new LoadOptions();
    $loadOptions->setPassword($password);

    $presentation = new Presentation($filePath, $loadOptions);
    try {
        echo("The presentation was validated and loaded successfully.\n");
    } finally {
        $presentation->dispose();
    }
}
```

### **Akış İş Akışı**

[PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationfactory/#getPresentationInfo) yönteminin akış aşırı yüklemesi aynı iş akışını sağlar. Tam sunumu bu akıştan yüklemeden önce, aranabilir bir akışın konumunu sıfırlayın.

Aşağıdaki örnek bir PPT dosyası kullanır:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$password = "open_password";

$presentationStream = new Java("java.io.FileInputStream", "protected-presentation.ppt");
try {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($presentationStream);

    if (!$presentationInfo->isPasswordProtected()) {
        echo("The presentation does not have an opening password.\n");
    } elseif (!$presentationInfo->checkPassword($password)) {
        echo("The opening password is incorrect.\n");
    } else {
        $presentationStream->getChannel()->position(0);

        $loadOptions = new LoadOptions();
        $loadOptions->setPassword($password);

        $presentation = new Presentation($presentationStream, $loadOptions);
        try {
            echo("The presentation was validated and loaded successfully.\n");
        } finally {
            $presentation->dispose();
        }
    }
} finally {
    $presentationStream->close();
}
```

### **checkPassword Dönüş Değerleri**

[PresentationInfo::checkPassword](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationinfo/#checkPassword) yalnızca sunumun bir açma parolası olduğu ve sağlanan parolanın doğru olduğu durumda `true` döndürür. Aşağıdaki durumlarda `false` döndürür:

- Parola yanlıştır.
- Sunumun bir açma parolası yoktur.
- Sağlanan parola `null` veya boştur.

Davranış PPT ve PPTX sunumları için aynı şekildedir.

## **Yüklenen Sunumun Şifreli Olup Olmadığını Kontrol Et**

Doğru parola ile bir sunum yüklendikten sonra, kaynak sunumun şifrelenip şifrelenmediğini doğrulamak için [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/#isEncrypted) inceleyin. Yüklemeden önce açma parolası korumasını tespit etmek için yukarıda gösterildiği gibi [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationinfo/#isPasswordProtected) kullanın.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
    echo("The presentation is encrypted: " . ($isEncrypted ? "true" : "false") . "\n");
} finally {
    $presentation->dispose();
}
```

## **Güvenlik Önerileri**

{{% alert color="warning" title="Güvenlik" %}}
Açma parolalarını kaydetmeyin ve tanı mesajlarına eklemeyin. Gereksiz tekrar doğrulama girişimlerinden kaçının, parolaları yalnızca gerektiği sürece bellekte tutun ve sunumu hemen yüklerken başarılı bir doğrulama sonucunu yeniden kullanın.

Genel belge özellikleri, sunum içeriği şifreli olsa bile yazar adlarını, başlıkları, konuları, anahtar kelimeleri, şirket bilgilerini, yorumları ve özel değerleri ortaya çıkarabilir. Hassas meta verileri sunumla birlikte şifreleyin. Özellikleri genel bırakmak, yalnızca sistemlerin dosyayı açma parolası olmadan indekslemesi, sınıflandırması, araması veya yönetmesi gerektiğinde alınacak açık bir karar olmalıdır.
{{% /alert %}}

## **Sunumu Çevrimiçi Parola ile Koruyun**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/tr/lock) uygulamasını açın.
2. Sunumu seçin veya yükleyin.
3. Görüntüleme koruması için bir parola girin.
4. İsteğe bağlı olarak düzenleme koruması için ayrı bir parola girin.
5. Koruma uygulayın ve ortaya çıkan dosyayı indirin.

{{% alert color="info" title="Ayrıca Bakınız" %}}
- [Write-Protect Presentations](/slides/tr/php-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/tr/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Açma parolası ile yazma koruma parolası arasındaki fark nedir?**

Açma parolası sunumu şifreler ve içeriğini yüklemek için gereklidir. Yazma koruma parolası ise içeriği şifrelemeden değişikliği kısıtlar.

**Tüm slaytları yüklemeden bir açma parolasını doğrulayabilir miyim?**

Evet. Sunum bilgilerini elde edin, açma parolası korumasının mevcut olup olmadığını kontrol edin ve tam bir sunum örneği oluşturmadan önce parolayı doğrulayın.

**Bir uygulama açma parolası olmadan meta verileri okuyabilir mi?**

Evet, ancak yalnızca sunum belge özelliği şifrelemesi devre dışı bırakılarak şifrelenmişse. Uygulama daha sonra [Manage Presentation Properties](/slides/tr/php-java/presentation-properties/) bölümünde açıklanan yalnızca belge özelliklerini yükleme modunu kullanmalıdır.

**Parola kontrol iş akışları hem PPT hem de PPTX'i destekliyor mu?**

Evet. Dosya yolu ve akış tabanlı parola tespiti ve doğrulama, PPT ve PPTX sunumları için aynı şekilde çalışır.