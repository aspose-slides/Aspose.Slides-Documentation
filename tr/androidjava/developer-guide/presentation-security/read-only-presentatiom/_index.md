---
title: Android'de Sunumları Salt Okunur Modda Kaydet
linktitle: Salt Okunur Sunum
type: docs
weight: 30
url: /tr/androidjava/read-only-presentation/
keywords:
- salt okunur
- sunumu koruma
- düzenlemeyi önleme
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java kullanarak PowerPoint dosyalarını (PPT, PPTX) salt okunur modda kaydedin, sunumlarınızı değiştirmeden kesin slayt önizlemeleri sunar."
---
## **Giriş**

PowerPoint 2019'da Microsoft, sunumlarını korumak için kullanıcıların kullanabileceği seçeneklerden biri olarak **Always Open Read-Only** ayarını tanıttı. Bu Read-Only ayarını bir sunumu korumak için şu durumlarda kullanmak isteyebilirsiniz:

- Yanlışlıkla yapılan düzenlemeleri önlemek ve sunumunuzun içeriğini güvende tutmak istiyorsanız. 
- Sağladığınız sunumun son versiyon olduğunu insanlara bildirmek istiyorsanız. 

Bir sunum için **Always Open Read-Only** seçeneğini seçtikten sonra, kullanıcılar sunumu açtıklarında **Read-Only** önerisini görür ve şu şekilde bir mesaj görebilirler: *Yanlışlıkla yapılan değişiklikleri önlemek için yazar bu dosyayı sadece okunabilir olarak açılacak şekilde ayarlamıştır.*

Read-Only önerisi, kullanıcıların bir sunumu düzenlemeden önce bunu kaldırmak için bir işlem yapması gerektiğinden düzenlemeyi caydıran basit ama etkili bir önlemdir. Kullanıcıların bir sunumda değişiklik yapmasını istemiyor ve bunu nazik bir şekilde onlara bildirmek istiyorsanız, Read-Only önerisi sizin için iyi bir seçenek olabilir. 

> **Read-Only** korumalı bir sunum, yeni eklenen işlevi desteklemeyen daha eski bir Microsoft PowerPoint uygulamasında açılırsa, **Read-Only** önerisi yok sayılır (sunum normal şekilde açılır).

## **Read-Only Modu Uygula**

Aspose.Slides for Android via Java, bir sunumu **Read-Only** olarak ayarlamanıza olanak tanır; bu, kullanıcıların (sunumu açtıktan sonra) **Read-Only** önerisini görmesi anlamına gelir. Bu örnek kod, Aspose.Slides kullanarak Java'da bir sunumu **Read-Only** olarak nasıl ayarlayacağınızı gösterir:

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

**Not**: **Read-Only** önerisi, bir PowerPoint sunumunda düzenlemeyi caydırmak veya kullanıcıların yanlışlıkla değişiklik yapmasını önlemek amacıyla basitçe sunulur. Ne yaptığını bilen motive bir kişi sunumunuzu düzenlemeye karar verirse, Read-Only ayarını kolayca kaldırabilir. Yetkisiz düzenlemeleri gerçekten engellemeniz gerekiyorsa, [şifreleme ve parolalar içeren daha katı korumaları](https://docs.aspose.com/slides/tr/androidjava/password-protected-presentation/) kullanmanız daha iyidir.

{{% /alert %}} 

## **SSS**

### 'Read-Only recommended' tam şifre korumasından nasıl farklıdır?

'Read-Only recommended' yalnızca dosyanın sadece okunur modda açılması önerisini gösterir ve atlatması kolaydır. [Şifre koruması](/slides/tr/androidjava/password-protected-presentation/) aslında açma veya düzenlemeyi kısıtlar ve gerçek güvenlik kontrollerine ihtiyacınız olduğunda uygundur.

### 'Read-Only recommended' filigranlarla birleştirilebilir ve düzenlemeler daha da caydırılabilir mi?

Evet. Öneri, görsel bir caydırıcı olarak [filigranlar](/slides/tr/androidjava/watermark/) ile eşleştirilebilir; bunlar ayrı mekanizmalardır ve birlikte iyi çalışır.

### Öneri etkinken bir makro veya dış araç dosyayı hâlâ değiştirebilir mi?

Evet. Öneri programatik değişiklikleri engellemez. Otomatik düzenlemeleri önlemek için [parolalar ve şifreleme](/slides/tr/androidjava/password-protected-presentation/) kullanın.

### 'Read-Only recommended' 'isEncrypted' ve 'isWriteProtected' yöntemleriyle nasıl ilişkilidir?

Bunlar farklı sinyallerdir. 'Read-Only recommended' yumuşak, isteğe bağlı bir bildirimdir; [isWriteProtected](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) ve [isEncrypted](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) ise parolalara veya şifrelemeye bağlı gerçek yazma veya okuma kısıtlamalarını gösterir.