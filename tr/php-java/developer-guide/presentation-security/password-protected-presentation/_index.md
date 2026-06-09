---
title: Parolalarla PHP'de Sunuları Güvenceye Alın
linktitle: Şifre Koruması
type: docs
weight: 20
url: /tr/php-java/password-protected-presentation/
keywords:
- PowerPoint kilitle
- sunuyu kilitle
- PowerPoint kilidini aç
- sununun kilidini aç
- PowerPoint koru
- sunuyu koru
- parola ayarla
- parola ekle
- PowerPoint şifrele
- sunuyu şifrele
- PowerPoint şifresini çöz
- sununun şifresini çöz
- yazma koruması
- PowerPoint güvenliği
- sunum güvenliği
- parolayı kaldır
- korumayı kaldır
- şifrelemeyi kaldır
- parolayı devre dışı bırak
- korumayı devre dışı bırak
- yazma korumasını kaldır
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP ile şifre korumalı PowerPoint ve OpenDocument sunularını kolayca kilitleyip açmayı öğrenin. Sunularınızı güvene alın."
---
## **Giriş**

Bir sunumu şifreyle koruduğunuzda, sunuma belirli kısıtlamalar getiren bir şifre belirlediğiniz anlamına gelir. Kısıtlamaları kaldırmak için şifre girilmelidir. Şifre korumalı bir sunum kilitli bir sunum olarak kabul edilir.

Genellikle, bu kısıtlamaları bir sunuya uygulamak için bir şifre belirleyebilirsiniz:

- **Değiştirme**

  Sadece belirli kullanıcıların sununuzu düzenlemesini istiyorsanız, bir düzenleme kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, insanların (şifreyi sağlamaları durumunda haricinde) sununuzdaki öğeleri değiştirmesini, düzenlemesini veya kopyalamasını engeller. 

  Ancak bu durumda, şifre olmadan da bir kullanıcı belgenize erişebilir ve açabilir. Bu yalnızca okuma modunda, kullanıcı sununuzdaki içerikleri veya öğeleri—hiperlinkler, animasyonlar, efektler ve diğerleri—görebilir, ancak öğeleri kopyalayamaz veya sunuyu kaydedemez. 

- **Açma**

  Sadece belirli kullanıcıların sununuzu açmasını istiyorsanız, bir açma kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, insanların (şifreyi sağlamaları durumunda hariç) sununuzun içeriğini bile görmesini engeller.

  Teknik olarak, açma kısıtlaması aynı zamanda kullanıcıların sunularınızı düzenlemesini de engeller: İnsanlar bir sunuyu açamadıklarında, üzerinde değişiklik yapamazlar. 

  **Not**: Bir sunuyu açmayı engelleyecek şekilde şifreyle koruduğunuzda, sunu dosyası şifrelenir.

## **Sunuyu Çevrimiçi Şifreyle Koruma**

1. [**Aspose.Slides Kilitle**](https://products.aspose.app/slides/tr/lock) sayfasına gidin.

   ![todo:image_alt_text](slides-lock.png)

2. **Dosyalarınızı bırakın veya yükleyin** üzerine tıklayın.

3. Bilgisayarınızda şifreyle korumak istediğiniz dosyayı seçin.

4. Düzenleme koruması için tercih ettiğiniz şifreyi girin; Görüntüleme koruması için tercih ettiğiniz şifreyi girin.

5. Kullanıcıların sununuzu son kopya olarak görmesini istiyorsanız, **Son olarak işaretle** onay kutusunu işaretleyin.

6. **PROTECT NOW.** üzerine tıklayın.

7. **DOWNLOAD NOW.** üzerine tıklayın.

## **Aspose.Slides'ta Sunular İçin Şifre Koruması**
**Desteklenen formatlar**

Aspose.Slides, aşağıdaki formatlardaki sunular için şifre koruması, şifreleme ve benzeri işlemleri destekler: 

- PPTX ve PPT - Microsoft PowerPoint Sunumu 
- ODP - OpenDocument Sunumu 
- OTP - OpenDocument Sunum Şablonu 

**Desteklenen işlemler**

Aspose.Slides, bir sunuyu şifreleyerek veya yazma koruması ekleyerek düzenlemeleri şu şekillerde engelleyebilir:

- Bir sunuyu şifreleme
- Bir sunuya yazma koruması ayarlama

**Diğer işlemler**

Aspose.Slides, şifre koruması ve şifreleme ile ilgili diğer görevleri şu şekillerde gerçekleştirebilir:

- Bir sununun şifresini çözme; şifrelenmiş bir sunuyu açma
- Şifrelemeyi kaldırma; şifre korumasını devre dışı bırakma
- Bir sunudan yazma korumasını kaldırma
- Şifrelenmiş bir sununun özelliklerini alma
- Bir sununun şifrelenip şifrelenmediğini kontrol etme
- Bir sununun şifreyle korunduğunu kontrol etme.

## **Bir Sunuyu Şifreleme**

Bir sunuyu şifre ayarlayarak şifreleyebilirsiniz. Ardından, kilitli sunuyu değiştirmek için kullanıcının şifreyi sağlaması gerekir.

Bir sunuyu şifrelemek veya şifreyle korumak için, sunuya şifre ayarlamak amacıyla encrypt metodunu ([ProtectionManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/)) kullanmanız gerekir. Şifreyi encrypt metoduna geçirirsiniz ve ardından şifrelenmiş sunuyu kaydetmek için save metodunu kullanırsınız.

Bu örnek kod bir sunuyu nasıl şifreleyeceğinizi gösterir:

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

## **Bir Sunuya Yazma Koruması Ayarlama**

Sunuya “Değiştirmeyin” ifadesi ekleyebilirsiniz. Böylece, kullanıcılara sunuyu değiştirmelerini istemediğinizi bildirebilirsiniz.  

**Not**: Yazma koruma işlemi sunuyu şifrelemez. Bu nedenle, kullanıcılar—gerçekten isterlerse—sunuyu değiştirebilir, ancak değişiklikleri kaydetmek için farklı bir adla yeni bir sunu oluşturmak zorundadır. 

Bir sunuya yazma koruması ayarlamak için [setWriteProtection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/#setWriteProtection) metodunu kullanmanız gerekir. Bu örnek kod bir sunuya yazma koruması nasıl ayarlanacağını gösterir:

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

## **Şifrelenmiş Bir Sunu Yükleme**

Aspose.Slides, şifresini girerek şifreli bir dosyayı yüklemenize olanak tanır. Bir sununun şifresini çözmek için [removeEncryption](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/#removeEncryption) metodunu parametresiz olarak çağırmanız gerekir. Daha sonra sunuyu yüklemek için doğru şifreyi girmeniz gerekir.

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    # şifre çözülmüş sunuyla çalış
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Bir Sunudan Şifrelemeyi Kaldırma**

Bir sunudaki şifreleme veya şifre korumasını kaldırabilirsiniz. Böylece, kullanıcılar sunuya sınırsız erişebilir veya değiştirebilir.

Şifrelemeyi veya şifre korumasını kaldırmak için [removeEncryption](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/#removeEncryption) metodunu çağırmanız gerekir. Bu örnek kod bir sunudan şifrelemenin nasıl kaldırılacağını gösterir:

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

## **Bir Sunudan Yazma Korumasını Kaldırma**

Aspose.Slides'ı kullanarak bir sunu dosyasındaki yazma korumasını kaldırabilirsiniz. Böylece, kullanıcılar istedikleri gibi değişiklik yapabilir ve bu işlemlerde uyarı almazlar.

Bir sunudan yazma korumasını kaldırmak için [removeWriteProtection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/#removeWriteProtection) metodunu kullanabilirsiniz. Bu örnek kod bir sunudan yazma korumasının nasıl kaldırılacağını gösterir:

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

## **Şifrelenmiş Bir Sununun Özelliklerini Alma**

Genellikle, kullanıcılar şifrelenmiş veya şifreyle korunan bir sununun belge özelliklerini almada zorlanırlar. Ancak Aspose.Slides, bir sunuyu şifreyle korurken kullanıcıların bu sununun özelliklerine erişebilmesini sağlayan bir mekanizma sunar.

**Not**: Aspose.Slides bir sunuyu şifrelediğinde, sununun belge özellikleri de varsayılan olarak şifreyle korunur. Ancak sununun özelliklerini (sunucu şifrelendikten sonra bile) erişilebilir kılmanız gerekiyorsa, Aspose.Slides bunu yapmanızı sağlar. 

Şifrelediğiniz bir sununun özelliklerine erişim yetisini kullanıcıların koruması için, `true` değeriyle [encryptDocumentProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/#getEncryptDocumentProperties) metodunu kullanabilirsiniz. Bu örnek kod, kullanıcıların belge özelliklerine erişebilmesini sağlayarak bir sunuyu nasıl şifreleyeceğinizi gösterir:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(true);
    $presentation->getProtectionManager()->encrypt("123123");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Bir Sununun Şifreyle Korunduğunu Kontrol Etme**

Bir sunuyu yüklemeden önce, sununun şifreyle korunup korunmadığını kontrol edip doğrulamak isteyebilirsiniz. Bu sayede, şifreli bir sunu şifresi olmadan yüklendiğinde ortaya çıkabilecek hataları ve benzer sorunları önleyebilirsiniz.

Bu PHP kodu, sunuyu (kendisini yüklemeden) şifreyle korunup korunmadığını incelemenizi gösterir:

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```

## **Bir Sununun Şifrelenip Şifrelenmediğini Kontrol Etme**

Aspose.Slides bir sununun şifrelenip şifrelenmediğini kontrol etmenizi sağlar. Bu işlemi yapmak için [isEncrypted](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/#isEncrypted) metodunu kullanabilirsiniz; bu metod sunu şifrelenmişse `true`, şifrelenmemişse `false` döndürür.

Bu örnek kod bir sununun şifreli olup olmadığını nasıl kontrol edeceğinizi gösterir:

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

## **Bir Sununun Yazma Koruması Olduğunu Kontrol Etme**

Aspose.Slides bir sununun yazma koruması olup olmadığını kontrol etmenizi sağlar. Bu işlemi yapmak için [isWriteProtected](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/#isWriteProtected) metodunu kullanabilirsiniz; bu metod sunu yazma korumalıysa `true`, değilse `false` döndürür.

Bu örnek kod bir sununun yazma korumalı olup olmadığını nasıl kontrol edeceğinizi gösterir:

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

Bir sunu belgesini korumak için belirli bir şifrenin kullanıldığını kontrol edip onaylamak isteyebilirsiniz. Aspose.Slides, bir şifreyi doğrulamanız için gerekli yöntemi sunar. 

Bu örnek kod bir şifreyi nasıl doğrulayacağınızı gösterir:

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

Belirtilen şifreyle şifrelenmişse `true` döndürür; aksi takdirde `false` döndürür. 

{{% alert color="primary" title="Ayrıca bakınız" %}} 
- [PowerPoint'ta Dijital İmza](/slides/tr/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Aspose.Slides tarafından hangi şifreleme yöntemleri destekleniyor?**

Aspose.Slides, AES tabanlı algoritmalar dahil olmak üzere modern şifreleme yöntemlerini destekler ve sunularınız için yüksek veri güvenliği sağlar.

**Bir sunuyu açmaya çalışırken yanlış bir şifre girilirse ne olur?**

Yanlış bir şifre kullanıldığında bir istisna fırlatılır ve sunuya erişimin reddedildiği konusunda sizi uyarır. Bu, yetkisiz erişimi önlemeye ve sunu içeriğini korumaya yardımcı olur.

**Şifre korumalı sunularla çalışırken performans açısından herhangi bir etkisi var mı?**

Şifreleme ve şifre çözme işlemleri, açma ve kaydetme sırasında hafif bir ek yük oluşturabilir. Çoğu durumda bu performans etkisi minimaldir ve sunu görevlerinizin genel işleme süresine önemli ölçüde etki etmez.