---
title: Java Kullanarak Okunabilir Modda Sunumları Kaydet
linktitle: Okunabilir Sunum
type: docs
weight: 30
url: /tr/java/read-only-presentation/
keywords:
- okunabilir
- sunumu koru
- düzenlemeyi önle
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint dosyalarını (PPT, PPTX) okunabilir modda yükleyip kaydedin, sunumlarınızı değiştirmeden kesin slayt önizlemeleri sunun."
---
## **Giriş**

PowerPoint 2019'da Microsoft, sunumlarını korumak için kullanıcıların kullanabileceği seçeneklerden biri olarak **Always Open Read-Only** ayarını tanıttı. Bu Okunabilir (Read-Only) ayarını bir sunumu korumak için şu durumlarda kullanmak isteyebilirsiniz

- Yanlışlıkla yapılan düzenlemeleri önlemek ve sunumunuzun içeriğini güvende tutmak istiyorsunuz. 
- Sağladığınız sunumun son sürüm olduğunu insanlara bildirmek istiyorsunuz. 

Bir sunum için **Always Open Read-Only** seçeneğini seçtikten sonra, kullanıcılar sunumu açtıklarında **Read-Only** önerisini görürler ve şu şekilde bir mesaj alabilirler: *Yanlışlıkla yapılan değişiklikleri önlemek için yazar bu dosyayı yalnızca okunabilir olarak açılacak şekilde ayarlamıştır.*

Read-Only önerisi, kullanıcıların bir sunumu düzenleyebilmek için öncelikle bu öneriyi kaldırması gerektiğinden düzenlemeyi caydıran basit ama etkili bir önlemdir. Kullanıcıların bir sunumda değişiklik yapmasını istemiyor ve bunu nazik bir şekilde onlara iletmek istiyorsanız, Read-Only önerisi sizin için iyi bir seçenek olabilir. 

> **Read-Only** korumasına sahip bir sunum, yeni eklenen işlevi desteklemeyen eski bir Microsoft PowerPoint uygulamasında açılırsa, **Read-Only** önerisi yok sayılır (sunum normal şekilde açılır).

## **Read-Only Modunu Uygula**

Aspose.Slides for Java, bir sunumu **Read-Only** olarak ayarlamanıza izin verir; bu, kullanıcıların (sunumu açtıktan sonra) **Read-Only** önerisini görmesi anlamına gelir. Bu örnek kod, Aspose.Slides kullanarak Java'da bir sunumu **Read-Only** olarak nasıl ayarlayacağınızı gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 

**Not**: **Read-Only** önerisi, bir PowerPoint sunumunda düzenlemeyi caydırmak veya kullanıcıların yanlışlıkla değişiklik yapmasını önlemek amacıyla basitçe sunulur. Ne yaptıklarını bilen motive bir kişi sunumunuzu düzenlemeye karar verirse, Read-Only ayarını kolayca kaldırabilir. Gerçek bir yetkisiz düzenlemeyi engellemeniz gerekiyorsa, [daha katı şifreleme ve parola korumaları](https://docs.aspose.com/slides/tr/java/password-protected-presentation/) kullanmanız daha iyidir. 

{{% /alert %}} 

## **SSS**

### 'Read-Only recommended' tam parola korumasından nasıl farklıdır?

'Read-Only recommended' sadece dosyanın yalnızca okunur modda açılması önerisini gösterir ve geçişi kolaydır. [Password protection](/slides/tr/java/password-protected-presentation/) aslında açma veya düzenlemeyi kısıtlar ve gerçek güvenlik kontrollerine ihtiyaç duyduğunuzda uygundur.

### 'Read-Only recommended' düzenlemeyi daha da caydırmak için filigranlarla birleştirilebilir mi?

Evet. Öneri, görsel bir caydırıcı olarak [watermarks](/slides/tr/java/watermark/) ile eşleştirilebilir; bunlar ayrı mekanizmalardır ve birlikte iyi çalışır.

### Öneri etkin olduğunda bir makro veya harici araç dosyayı hâlâ değiştirebilir mi?

Evet. Öneri programatik değişiklikleri engellemez. Otomatik düzenlemeleri önlemek için [passwords and encryption](/slides/tr/java/password-protected-presentation/) kullanın.

### 'Read-Only recommended' 'isEncrypted' ve 'isWriteProtected' yöntemleriyle nasıl ilişkilidir?

Bunlar farklı sinyallerdir. 'Read-Only recommended' yumuşak, isteğe bağlı bir istemdir; [isWriteProtected](https://reference.aspose.com/slides/tr/java/com.aspose.slides/protectionmanager/#isWriteProtected--) ve [isEncrypted](https://reference.aspose.com/slides/tr/java/com.aspose.slides/protectionmanager/#isEncrypted--) ise parolalar veya şifreleme ile bağlı gerçek yazma veya okuma kısıtlamalarını gösterir.