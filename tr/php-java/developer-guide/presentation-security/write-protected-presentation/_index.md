---
title: PHP'de Sunumları Yazma Korumalı Hale Getirme
linktitle: Yazma Koruması
type: docs
weight: 25
url: /tr/php-java/write-protected-presentation/
keywords:
- yazma koruması
- PowerPoint yazma koruması
- değiştirme parolası
- sunum düzenlemesini kısıtla
- yazma korumasını kaldır
- değişiklik parolasını doğrula
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP kullanarak PowerPoint PPT ve PPTX sunumlarında yazma koruma şifrelerini ayarlama, algılama, doğrulama ve kaldırma."
---
## **Giriş**

Yazma koruma parolası bir sunumun değiştirilmesini kısıtlar ancak içeriğini şifrelemez. Kullanıcılar bir yazma korumalı sunumu parola olmadan yükleyip görüntüleyebilirler. Uygulamaya bağlı olarak, içeriği düzenleyip farklı bir adla kaydedebilirler, bu yüzden yazma koruması gizlilik mekanizması olarak değerlendirilmemelidir.

Açma parolası farklı bir amaç taşır: sunumu şifreler ve içeriğini yüklemek için gereklidir. Bir sunumu şifrelemek veya açma parolasını doğrulamak için, [Sunumları Parola ile Koruma](/slides/tr/php-java/password-protected-presentation/) bölümüne bakın.

Bu makaledeki iş akışları PPT ve PPTX sunumlarının her ikisine de uygulanır. Örnekler PPTX dosyalarını kullanır; PPT olarak kaydederken `.ppt` uzantısını ve ilgili PPT kaydetme biçimini kullanın.

## **Bir Sunuma Yazma Koruması Ayarlama**

Bir sunumu değiştirmek için bir parola atamak üzere [ProtectionManager::setWriteProtection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/#setWriteProtection) yöntemini kullanın. Sunumu kaydetmek koruma ayarını kalıcı hâle getirir.

Aşağıdaki örnek, bir PPTX sunumunda yazma koruması ayarlar:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->setWriteProtection("modify_password");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Yazma Korumalı Bir Sunumu Yükleme**

Yazma koruması sunum içeriğini şifrelemediği için sunumu yüklemek için parola gerekmez. Parola yalnızca korumalı sunumu değiştirme yetkisini doğrularken ilgilidir.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    echo("Slide count: " . $presentation->getSlides()->size() . "\n");
} finally {
    $presentation->dispose();
}
```

Yazma koruma parolasını [LoadOptions::setPassword](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/#setPassword) metoduna göndermeyin. Bu metod şifreli içerik için bir açma parolası alır. Bir sunum her iki koruma türüne de sahipse, yüklemek için açma parolasını sağlayın ve yazma koruma parolasını ayrı şekilde işleyin.

## **Bir Sunumdan Yazma Korumasını Kaldırma**

[ProtectionManager::removeWriteProtection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/#removeWriteProtection) yöntemini kullanarak değiştirme kısıtlamasını kaldırın, ardından sunumu kaydedin.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Bir Sunumun Yazma Koruması Olup Olmadığını Kontrol Etme**

Tam bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) örneği oluşturmadan bir dosyayı incelemek için [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationfactory/#getPresentationInfo) metodunu çağırın ve [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationinfo/#isWriteProtected) özelliğini inceleyin. Metot [NullableBool](https://reference.aspose.com/slides/tr/php-java/aspose.slides/nullablebool/) kullanır ve yazma koruması tespit edildiğinde `NullableBool::True` döndürür.

```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() == NullableBool::True) {
    echo("The presentation is write protected.\n");
} else {
    echo("Write protection was not detected.\n");
}
```

[PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationfactory/#getPresentationInfo) metodunun akış aşırı yüklemesi, akış olarak verilen bir sunum için aynı bilgileri sağlar.

## **Yazma Koruma Parolasını Doğrulama**

Tam bir sunumu yüklemeden bir değiştirme parolasını doğrulamak için [PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationinfo/#checkWriteProtection) yöntemini kullanın. Uygulamanın yalnızca yazma koruması mevcut olduğunda parola isteyip doğrulaması için önce [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationinfo/#isWriteProtected) özelliğini kontrol edin.

```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() != NullableBool::True) {
    echo("The presentation is not write protected.\n");
} elseif ($presentationInfo->checkWriteProtection("modify_password")) {
    echo("The write-protection password is correct.\n");
} else {
    echo("The write-protection password is incorrect.\n");
}
```

[PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationinfo/#checkWriteProtection) yalnızca yazma koruma parolasını doğrular. Bir açma parolasını doğrulamaz veya şifreli içeriğin yüklenip yüklenemeyeceğini belirlemez. Bunun tersine, [PresentationInfo::checkPassword](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationinfo/#checkPassword) yalnızca bir açma parolasını doğrular. Eğer tam bir sunum zaten yüklendiyse, [ProtectionManager::checkWriteProtection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/#checkWriteProtection) koruma yöneticisi aracılığıyla eşdeğer yazma koruma kontrolünü sağlar.

Üretim uygulamalarında parolaları kaydetmeyin veya tanı mesajlarına eklemeyin. Gereksiz tekrar doğrulama denemelerinden kaçının ve parolaları bellekte yalnızca gerektiği sürece tutun.

{{% alert color="info" title="Ayrıca bakınız" %}}
- [Sunumları Parola ile Koruma](/slides/tr/php-java/password-protected-presentation/)
- [Salt Okunur Sunumlar](/slides/tr/php-java/read-only-presentation/)
- [PowerPoint'te Dijital İmza](/slides/tr/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Yazma koruması bir sunumu şifreler mi?**

Hayır. Değiştirmeyi kısıtlar ancak sunum içeriğini yükleme ve görüntüleme için kullanılabilir bırakır.

**Bir sunumu açmak için yazma koruma parolası gerekli mi?**

Hayır. Şifrelenmiş sunum içeriğini yüklemek için yalnızca bir açma parolası gereklidir.

**Bir sunum hem açma parolası hem de yazma koruma parolası içerebilir mi?**

Evet. Şifreli sunumu açmak için açma parolasını yükleme seçenekleriyle sağlayın ve değiştirme yetkisi gerektiğinde yazma koruma parolasını ayrı olarak doğrulayın.