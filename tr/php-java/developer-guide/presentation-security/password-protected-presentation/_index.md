---
title: PHP'de Sunumları Parola ile Koruma
linktitle: Parola Koruması
type: docs
weight: 20
url: /tr/php-java/password-protected-presentation/
keywords:
- parola korumalı sunum
- açma parolası
- PowerPoint şifreleme
- PowerPoint şifre çözme
- sunum parolasını doğrulama
- sunum parolasını kontrol etme
- şifreli sunumu açma
- şifrelemeyi kaldırma
- PowerPoint
- PPT
- PPTX
- sunum
- PHP
- Aspose.Slides
description: "PHP'de Aspose.Slides ile parola korumalı PowerPoint PPT ve PPTX sunumlarını şifreleme, algılama, doğrulama, açma ve şifre çözme."
---
## **Genel Bakış**

Bir açma parolası bir sunumu şifreler. Sunum içeriğini yüklemek ve görüntülemek için doğru parola gereklidir; bu koruma gizliliği sağlar.

Açma parolası, yazma koruma parolasından farklıdır. Yazma koruması, değişikliği kısıtlar ancak içeriği şifrelemez ve sunumun yüklenmesini engellemez. Sunumları değiştirmek için parolaları yönetmek istiyorsanız, bakınız [Sunumları Yazma Koruması](/slides/tr/php-java/write-protected-presentation/).

Aşağıdaki iş akışı hem PPT hem de PPTX sunumları için geçerlidir. Örnekler, dosya tabanlı ve akış tabanlı davranışlarının önemli olduğu her iki formatı da kullanır.

## **Açma Parolasıyla Sunumu Şifreleme**

Açma parolası atamak için [ProtectionManager::encrypt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/#encrypt) kullanın. Ardından şifreli sunumu kalıcı hâle getirmek için [Presentation::save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#save) metodunu çağırın.

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

## **Şifreli Sunumu Yükleme**

Açma parolasını [LoadOptions::setPassword](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/#setPassword) ile ayarlayın ve dosyayı yüklerken seçenekleri [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) nesnesine geçirin. Bir açma parolası gerekli olduğunda fakat sağlanan parola eksik ya da hatalıysa yükleme başarısız olur.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    # Şifre çözülmüş sunumla çalışın.
} finally {
    $presentation->dispose();
}
```

## **Sunumdan Şifrelemeyi Kaldırma**

Sunumu açma parolasıyla yükleyin, [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/#removeEncryption) metodunu çağırın ve sonucu kaydedin. Kaydedilen sunum artık parola olmadan yüklenebilir.

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

## **Yüklemeden Önce Açma Parolasını Doğrulama**

Tam bir sunum örneği oluşturmadan [PresentationInfo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationinfo/) elde etmek için [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationfactory/#getPresentationInfo) kullanın. Parola talep etmeden veya doğrulamadan önce [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationinfo/#isPasswordProtected) kontrol edin. Koruma mevcutsa, sağlanan değeri [PresentationInfo::checkPassword](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationinfo/#checkPassword) ile doğrulayın.

### **Dosya Yolu İş Akışı**

Aşağıdaki örnek bir PPTX dosyası için açma parolasını doğrular, doğrulanan değeri [LoadOptions::setPassword](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/#setPassword) metoduna geçirir ve ardından tam sunumu yükler:

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

[PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationfactory/#getPresentationInfo) akış aşırı yüklemesi aynı iş akışını sağlar. Tam sunumu bu akıştan yüklemeden önce, aranabilir bir akışın konumunu sıfırlayın.

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

[PresentationInfo::checkPassword](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationinfo/#checkPassword) sadece sunumun bir açma parolası olduğu ve sağlanan parola doğru olduğunda `true` döndürür. Aşağıdaki durumlarda `false` döner:

- Parola yanlıştır.
- Sunumun bir açma parolası yoktur.
- Sağlanan parola `null` veya boştur.

Davranış PPT ve PPTX sunumları için aynıdır.

## **Yüklenen Sunumun Şifreli Olup Olmadığını Kontrol Etme**

Doğru parola ile bir sunum yükledikten sonra, kaynağın şifreli olduğunu teyit etmek için [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/#isEncrypted) incelenir. Yüklemeden önce açma‑parola korumasını tespit etmek için yukarıda gösterildiği gibi [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationinfo/#isPasswordProtected) kullanın.

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
Açma parolalarını günlüğe kaydetmeyin veya tanı mesajlarında bulundurmayın. Gereksiz tekrarlanan doğrulama girişimlerinden kaçının, parolaları yalnızca gerektiği sürece bellekte tutun ve sunumu hemen yüklerken başarılı bir doğrulama sonucunu yeniden kullanın.
{{% /alert %}}

## **Sunumu Çevrimiçi Parola ile Koruma**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/tr/lock) uygulamasını açın.
2. Sunumu seçin veya yükleyin.
3. Görüntüleme koruması için bir parola girin.
4. İsteğe bağlı olarak düzenleme koruması için ayrı bir parola girin.
5. Koruma uygulayın ve ortaya çıkan dosyayı indirin.

{{% alert color="info" title="Ayrıca Bakınız" %}}
- [Sunumları Yazma Koruması](/slides/tr/php-java/write-protected-presentation/)
- [PowerPoint’te Dijital İmza](/slides/tr/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Açma parolası ile yazma koruma parolası arasındaki fark nedir?**

Açma parolası sunumu şifreler ve içeriğini yüklemek için gereklidir. Yazma koruma parolası, içeriği şifrelemeden değişikliği sınırlar.

**Tüm slaytları yüklemeden açma parolasını doğrulayabilir miyim?**

Evet. Sunum bilgilerini alın, açma‑parola korumasının varlığını kontrol edin ve tam bir sunum örneği oluşturmadan önce parolayı doğrulayın.

**Parola‑kontrol iş akışları hem PPT hem de PPTX için destekleniyor mu?**

Evet. Dosya‑yolu ve akış‑tabanlı parola tespiti ve doğrulama, PPT ve PPTX sunumları için aynı şekilde çalışır.