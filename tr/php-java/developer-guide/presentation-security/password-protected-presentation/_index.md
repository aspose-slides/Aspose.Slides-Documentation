---
title: PHP'de Şifrelerle Sunumları Güvenceye Alma
linktitle: Şifre Koruması
type: docs
weight: 20
url: /tr/php-java/password-protected-presentation/
keywords:
- PowerPoint kilitle
- sunumu kilitle
- PowerPoint kilidini aç
- sunum kilidini aç
- PowerPoint koru
- sunumu koru
- şifre ayarla
- şifre ekle
- PowerPoint şifrele
- sunumu şifrele
- PowerPoint şifresini çöz
- sunum şifresini çöz
- yazma koruması
- PowerPoint güvenliği
- sunum güvenliği
- şifreyi kaldır
- korumayı kaldır
- şifrelemeyi kaldır
- şifreyi devre dışı bırak
- korumayı devre dışı bırak
- yazma korumasını kaldır
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP ile şifre korumalı PowerPoint ve OpenDocument sunumlarını nasıl kolayca kilitleyip açacağınızı öğrenin. Sunumlarınızı güvence altına alın."
---
## **Giriş**

Bir sunumu şifreyle koruduğunuzda, sunuma belirli kısıtlamalar getiren bir şifre belirlediğiniz anlamına gelir. Kısıtlamaları kaldırmak için şifrenin girilmesi gerekir. Şifreyle korunmuş bir sunum, kilitli bir sunum kabul edilir.

Genellikle, bu kısıtlamaları bir sunuma uygulamak için şifre belirleyebilirsiniz:

- **Değişiklik**

  Sadece belirli kullanıcıların sunumunuzu değiştirmesini istiyorsanız, bir değiştirme kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, insanların sunumunuzu değiştirmesini, düzenlemesini veya kopyalamasını (şifreyi sağlamadıkları sürece) engeller.  

  Ancak bu durumda, şifre olmadan bile bir kullanıcı belgenize erişebilir ve onu açabilir. Okuma yalnızca modunda, kullanıcı sunumunuzdaki içerikleri—hiperlinkler, animasyonlar, efektler ve diğer öğeler—görüntüleyebilir, ancak öğeleri kopyalayamaz veya sunumu kaydedemez.  

- **Açma**

  Sadece belirli kullanıcıların sunumunuzu açmasını istiyorsanız, bir açma kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, insanların sunumunuzun içeriğini bile görmesini (şifreyi sağlamadıkları sürece) engeller.  

  Teknik olarak, açma kısıtlaması aynı zamanda kullanıcıların sunumlarınızı değiştirmesini de engeller: İnsanlar bir sunumu açamadıklarında, onu değiştiremez veya üzerinde değişiklik yapamazlar.  

  **Not**: Bir sunumu açılmasını engellemek için şifreyle koruduğunuzda, sunum dosyası şifrelenir.

## **Sunumu Çevrimiçi Şifreyle Koruma**

1. Şu [**Aspose.Slides Lock**](https://products.aspose.app/slides/tr/lock) sayfasına gidin.  

   ![todo:image_alt_text](slides-lock.png)

2. **Dosyalarınızı sürükleyin veya yükleyin** seçeneğine tıklayın.

3. Bilgisayarınızda şifreyle korumak istediğiniz dosyayı seçin. 

4. Düzenleme koruması için tercih ettiğiniz şifreyi girin; Görüntüleme koruması için tercih ettiğiniz şifreyi girin. 

5. Kullanıcıların sunumunuzu son kopya olarak görmesini istiyorsanız, **Mark as final** onay kutusunu işaretleyin.

6. **PROTECT NOW.**'a tıklayın. 

7. **DOWNLOAD NOW.**'a tıklayın.

## **Aspose.Slides'ta Sunumlar İçin Şifre Koruması**
**Desteklenen formatlar**

Aspose.Slides, bu formatlardaki sunumlar için şifre koruması, şifreleme ve benzeri işlemleri destekler: 

- PPTX ve PPT - Microsoft PowerPoint Sunumu 
- ODP - OpenDocument Sunumu 
- OTP - OpenDocument Sunum Şablonu 

**Desteklenen işlemler**

Aspose.Slides, sunumlarda şifre korumasını kullanarak değişiklikleri önlemenizi bu şekillerde sağlar:

- Sunumu şifreleme
- Sunuma yazma koruması ayarlama

**Diğer işlemler**

Aspose.Slides, şifre koruması ve şifreleme ile ilgili diğer görevleri şu şekilde gerçekleştirmenizi sağlar:

- Sunumu şifre çözme; şifrelenmiş bir sunumu açma
- Şifrelemeyi kaldırma; şifre korumasını devre dışı bırakma
- Sunumdan yazma korumasını kaldırma
- Şifrelenmiş bir sunumun özelliklerini alma
- Sunumun şifrelenip şifrelenmediğini kontrol etme
- Sunumun şifreyle korunup korunmadığını kontrol etme.

## **Sunumu Şifreleme**

Bir şifre belirleyerek bir sunumu şifreleyebilirsiniz. Kilitli sunumu değiştirmek için kullanıcının şifreyi girmesi gerekir.

Bir sunumu şifrelemek veya şifreyle korumak için, sunuma şifre ayarlamak amacıyla [ProtectionManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/) içindeki encrypt metodunu kullanmanız gerekir. Şifreyi encrypt metoduna geçirir ve ardından artık şifrelenmiş sunumu kaydetmek için save metodunu kullanırsınız.

Bu örnek kod, bir sunumu nasıl şifreleyeceğinizi gösterir:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Sunuma Yazma Koruması Ayarlama**

Bir sunuma “Değiştirmeyin” işareti ekleyebilirsiniz. Böylece, kullanıcılara sunumu değiştirmelerini istemediğinizi bildirebilirsiniz.  

**Not**: Yazma koruma süreci sunumu şifrelemez. Bu nedenle, kullanıcılar—istemedikleri takdirde—sunumu değiştirebilir, ancak değişiklikleri kaydetmek için farklı bir adla yeni bir sunum oluşturmak zorunda kalırlar.  

Yazma koruması ayarlamak için [setWriteProtection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/#setWriteProtection) metodunu kullanmanız gerekir. Bu örnek kod, bir sunuma yazma koruması nasıl ayarlanacağını gösterir:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setWriteProtection("123123");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Şifrelenmiş Bir Sunumu Yükleme**

Aspose.Slides, şifresini girerek şifrelenmiş bir dosyayı yüklemenize olanak tanır. Bir sunumu şifre çözmek için, parametresiz olarak [removeEncryption](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/#removeEncryption) metodunu çağırmanız gerekir. Daha sonra sunumu yüklemek için doğru şifreyi girmeniz istenir.

Bu örnek kod, bir sunumu nasıl şifre çözeceğinizi gösterir:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    # şifre çözülmüş sunumla çalış
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Sunumdan Şifrelemeyi Kaldırma**

Bir sunum üzerindeki şifreleme veya şifre korumasını kaldırabilirsiniz. Böylece, kullanıcılar sunuma kısıtlama olmadan erişebilir veya değiştirebilir.

Şifreleme veya şifre korumasını kaldırmak için [removeEncryption](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/#removeEncryption) metodunu çağırmanız gerekir. Bu örnek kod, bir sunumdan şifrelemeyi nasıl kaldıracağınızı gösterir:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Sunumdan Yazma Korumasını Kaldırma**

Aspose.Slides'ı kullanarak bir sunum dosyasında kullanılan yazma korumasını kaldırabilirsiniz. Böylece, kullanıcılar istedikleri gibi değiştirebilir ve bu işlemleri yaparken hiçbir uyarı almazlar.

Sunumdan yazma korumasını kaldırmak için [removeWriteProtection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/#removeWriteProtection) metodunu kullanabilirsiniz. Bu örnek kod, bir sunumdan yazma korumasını nasıl kaldıracağınızı gösterir:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Şifrelenmiş Bir Sunumun Özelliklerini Alma**

Genellikle, kullanıcılar şifrelenmiş veya şifreyle korunan bir sunumun belge özelliklerini almada zorluk çeker. Ancak, Aspose.Slides, bir sunumu şifreyle korurken kullanıcıların özelliklerine erişebilmesini sağlayan bir mekanizma sunar.

**Not:** Varsayılan olarak, Aspose.Slides bir sunumu şifrelediğinde, sunumun belge özellikleri de şifreyle korunur. Şifreleme sonrasında belge özelliklerine erişilebilir olmasını istiyorsanız, Aspose.Slides bunu yapmanıza izin verir.

Kullanıcıların şifrelenmiş bir sunumun özelliklerine erişebilmesini istiyorsanız, [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) metoduna `false` parametresini gönderin. Bu örnek kod, bir sunumu şifrelerken kullanıcıların belge özelliklerine erişimini nasıl sağlayacağınızı gösterir:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Şifrelenmiş Bir Sunumdan Yalnızca Belge Özelliklerini Yükleme**

Şifrelenmiş bir sunumun slaytlarını veya diğer içeriğini yüklemeden meta verilerini incelemek için bir [LoadOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/) nesnesi oluşturun ve [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) metoduna `true` gönderin. Bu modda, Aspose.Slides şifreyi göz ardı eder ve yalnızca herkese açık belge özelliklerini yükler.

Aşağıdaki kod örneği, [Presentation::getDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getDocumentProperties) aracılığıyla yerleşik ve özel belge özelliklerini okur:

```php
$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $documentProperties = $presentation->getDocumentProperties();

    # Yerleşik belge özelliklerini okuyun.
    echo("Title: " . $documentProperties->getTitle() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");

    # Özel belge özelliklerini okuyun.
    $customPropertyCount = java_values($documentProperties->getCountOfCustomProperties());

    for ($propertyIndex = 0; $propertyIndex < $customPropertyCount; $propertyIndex++) {
        $propertyName = $documentProperties->getCustomPropertyName($propertyIndex);
        $propertyValue = java_values($documentProperties->get_Item($propertyName));

        echo($propertyName . ": " . $propertyValue . "\n");
    }
} finally {
    $presentation->dispose();
}
```

Bu iş akışı yalnızca sunum şifrelenirken belge özellikleri şifrelenmemiş (herkese açık) bırakıldığında çalışır. Belge özellikleri şifrelenmişse, [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) metoduna `true` gönderilmesi bir istisna oluşturur çünkü bu modda şifre göz ardı edilir. Şifrelenmiş belge özelliklerine erişmek veya slaytları ve diğer içeriği dahil olmak üzere tam sunumu yüklemek için doğru şifreyi [LoadOptions::setPassword](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/#setPassword) ile sağlayın.

## **Bir Sunumun Şifreyle Korunup Korunmadığını Kontrol Etme**

Bir sunumu yüklemeden önce, sunumun şifreyle korunup korunmadığını kontrol etmek ve doğrulamak isteyebilirsiniz. Böylece, şifre korumalı bir sunum şifresi olmadan yüklendiğinde ortaya çıkan hataları ve benzeri sorunları önleyebilirsiniz.

Bu PHP kodu, bir sunumun şifreyle korunup korunmadığını (sunumu kendisini yüklemeden) nasıl inceleyeceğinizi gösterir:

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```

## **Bir Sunumun Şifrelenip Şifrelenmediğini Kontrol Etme**

Aspose.Slides, bir sunumun şifrelenip şifrelenmediğini kontrol etmenizi sağlar. Bu görevi yerine getirmek için, sunum şifrelenmişse `true`, şifrelenmemişse `false` dönen [isEncrypted](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/#isEncrypted) metodunu kullanabilirsiniz.

Bu örnek kod, bir sunumun şifrelenip şifrelenmediğini nasıl kontrol edeceğinizi gösterir:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Bir Sunumun Yazma Koruması Olup Olmadığını Kontrol Etme**

Aspose.Slides, bir sunumun yazma koruması olup olmadığını kontrol etmenizi sağlar. Bu görevi yerine getirmek için, sunum yazma korumalıysa `true`, değilse `false` dönen [isWriteProtected](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/#isWriteProtected) metodunu kullanabilirsiniz.

Bu örnek kod, bir sunumun yazma korumalı olup olmadığını nasıl kontrol edeceğinizi gösterir:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isWriteProtected();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Belirli Bir Şifrenin Kullanıldığını Doğrulama veya Onaylama**

Sunum belgesini korumak için belirli bir şifrenin kullanılıp kullanılmadığını kontrol edip onaylamak isteyebilirsiniz. Aspose.Slides, bir şifreyi doğrulamanız için gerekli aracı sağlar.

Bu örnek kod, bir şifreyi nasıl doğrulayacağınızı gösterir:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    # "pass" ile eşleşip eşleşmediğini kontrol et
    $isWriteProtected = $presentation->getProtectionManager()->checkWriteProtection("my_password");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

Belirtilen şifreyle sunum şifrelenmişse `true` döner. Aksi takdirde `false` döner.

{{% alert color="primary" title="Ayrıca bakınız" %}} 
- [PowerPoint'ta Dijital İmza](/slides/tr/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Aspose.Slides tarafından desteklenen şifreleme yöntemleri nelerdir?**

Aspose.Slides, AES tabanlı algoritmalar dahil olmak üzere modern şifreleme yöntemlerini destekler ve bu sayede sunumlarınız için yüksek veri güvenliği sağlar.

**Sunumu açarken yanlış bir şifre girilirse ne olur?**

Yanlış şifre kullanıldığında bir istisna oluşturulur ve sunuma erişimin reddedildiği size bildirilir. Bu, yetkisiz erişimi önlemeye ve sunum içeriğini korumaya yardımcı olur.

**Şifre korumalı sunumlarla çalışırken performans etkileri var mı?**

Şifreleme ve şifre çözme süreçleri, açma ve kaydetme işlemleri sırasında hafif bir ek yük getirebilir. Çoğu durumda bu performans etkisi minimaldir ve sunum görevlerinizin toplam işleme süresini önemli ölçüde etkilemez.