---
title: Read-Only Modunda Sunumları PHP ile Kaydedin
linktitle: Read-Only Sunum
type: docs
weight: 30
url: /tr/php-java/read-only-presentation/
keywords:
- salt okunur
- sunumu koru
- düzenlemeyi önle
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP ile PowerPoint dosyalarını (PPT, PPTX) salt okunur modda yükleyin ve kaydedin, sunumlarınızı değiştirmeden kesin slayt ön izlemeleri sunar."
---
## **Giriş**

PowerPoint 2019'da Microsoft, sunumları korumak için kullanıcıların kullanabileceği seçeneklerden biri olarak **Always Open Read-Only** ayarını tanıttı. Bu Read-Only ayarını bir sunumu korumak için şu durumlarda kullanmak isteyebilirsiniz:

- Sunumunuzun içeriğini kazara düzenlenmelerden korumak ve güvenli tutmak istiyorsanız. 
- Sunumunuzun son sürüm olduğunu insanlara bildirmek istiyorsanız. 

Bir sunum için **Always Open Read-Only** seçeneğini seçtikten sonra, kullanıcılar sunumu açtıklarında **Read-Only** önerisini görürler ve şu şekilde bir mesaj alabilirler: *Kazara değişiklikleri önlemek için yazar bu dosyayı yalnızca okunacak şekilde açılacak şekilde ayarlamıştır.*

Read-Only önerisi, kullanıcıların bir sunumu düzenleyebilmek için önce bunu kaldırmaları gerektiğinden düzenlemeyi caydıran basit ama etkili bir önlemdir. Kullanıcıların bir sunumu değiştirmesini istemiyor ve bunu nazik bir şekilde belirtmek istiyorsanız, Read-Only önerisi sizin için iyi bir seçenek olabilir. 

> **Read-Only** korumasına sahip bir sunum, yakın zamanda tanıtılan işlevi desteklemeyen eski bir Microsoft PowerPoint uygulamasında açılırsa, **Read-Only** önerisi yok sayılır (sunum normal olarak açılır).

## **Read-Only Modunu Uygula**

Aspose.Slides for PHP via Java, bir sunumu **Read-Only** olarak ayarlamanıza olanak tanır; bu, kullanıcıların (sunumu açtıktan sonra) **Read-Only** önerisini görmesi demektir. Bu örnek kod, bir sunumu Aspose.Slides kullanarak **Read-Only** olarak nasıl ayarlayacağınızı gösterir:

```php
  $pres = new Presentation();
  try {
    $pres->getProtectionManager()->setReadOnlyRecommended(true);
    $pres->save("ReadOnlyPresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
**Not**: **Read-Only** önerisi, PowerPoint sunumunda düzenlemeyi caydırmak veya kullanıcıların kazara değişiklik yapmasını önlemek amacıyla basitçe tasarlanmıştır. Ne yaptığını bilen motive bir kişi sunumunuzu düzenlemeye karar verirse, Read-Only ayarını kolayca kaldırabilir. Yetkisiz düzenlemeyi ciddi şekilde önlemeniz gerekiyorsa, [şifreleme ve parolaları içeren daha katı korumaları](https://docs.aspose.com/slides/tr/php-java/password-protected-presentation/) kullanmanız daha iyidir.
{{% /alert %}} 

## **SSS**

**'Read-Only recommended' tam parola korumasından nasıl farklıdır?**

'Read-Only recommended' yalnızca dosyanın yalnızca okunur modda açılması önerisini gösterir ve kolayca atlatılabilir. [Password protection](/slides/tr/php-java/password-protected-presentation/) aslında açma veya düzenlemeyi kısıtlar ve gerçek güvenlik kontrollerine ihtiyacınız olduğunda uygundur.

**'Read-Only recommended' su işaretleriyle birleştirilebilir ve düzenlemeleri daha da caydırır mı?**

Evet. Öneri, görsel bir caydırıcı olarak [watermarks](/slides/tr/php-java/watermark/) ile eşleştirilebilir; bunlar ayrı mekanizmalardır ve birlikte iyi çalışır.

**Öneri etkin olduğunda bir makro veya dış araç hala dosyayı değiştirebilir mi?**

Evet. Öneri programatik değişiklikleri engellemez. Otomatik düzenlemeleri önlemek için [passwords and encryption](/slides/tr/php-java/password-protected-presentation/) kullanın.

**'Read-Only recommended' 'isEncrypted' ve 'isWriteProtected' yöntemleriyle nasıl ilişkilidir?**

Bunlar farklı sinyallerdir. 'Read-Only recommended' yumuşak, isteğe bağlı bir istemdir; [isWriteProtected](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/iswriteprotected/) ve [isEncrypted](https://reference.aspose.com/slides/tr/php-java/aspose.slides/protectionmanager/isencrypted/) ise parolalar veya şifrelemeye bağlı gerçek yazma veya okuma kısıtlamalarını gösterir.