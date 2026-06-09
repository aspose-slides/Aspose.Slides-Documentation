---
title: Android'de Okunur Modda Sunumları Kaydet
linktitle: Okunur Sunum
type: docs
weight: 30
url: /tr/androidjava/read-only-presentation/
keywords:
- okunur
- sunumu koru
- düzenlemeyi önle
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java kullanarak PowerPoint dosyalarını (PPT, PPTX) okuma modunda kaydedin, sunumlarınızı değiştirmeden kesin slayt ön izlemeleri sunar."
---
## **Giriş**

PowerPoint 2019'da Microsoft, kullanıcıların sunumlarını korumak için kullanabilecekleri seçeneklerden biri olarak **Always Open Read-Only** ayarını tanıttı. Bu Read-Only ayarını şu durumlarda bir sunumu korumak için kullanmak isteyebilirsiniz

- Yanlışlıkla yapılan düzenlemeleri önlemek ve sunumunuzun içeriğini güvenli tutmak istiyorsunuz. 
- Sağladığınız sunumun son sürüm olduğunu insanlara bildirmek istiyorsunuz. 

**Always Open Read-Only** seçeneğini bir sunum için seçtikten sonra, kullanıcılar sunumu açtıklarında **Read-Only** önerisini görür ve şu şekilde bir mesaj görebilirler: *Yanlışlıkla yapılan değişiklikleri önlemek için yazar bu dosyayı sadece okunur olarak açılacak şekilde ayarlamıştır.*

Read-Only önerisi, kullanıcıların bir sunumu düzenlemeden önce bunu kaldırmak için bir işlem yapmasını gerektirdiği için düzenlemeyi caydıran basit ama etkili bir önlemdir. Kullanıcıların bir sunumu değiştirmesini istemiyor ve bunu nazik bir şekilde onlara söylemek istiyorsanız, Read-Only önerisi sizin için iyi bir seçenek olabilir. 

> **Read-Only** korumasına sahip bir sunum, bu yeni işlevi desteklemeyen daha eski bir Microsoft PowerPoint uygulamasında açılırsa, **Read-Only** önerisi göz ardı edilir (sunum normal şekilde açılır).

## **Read-Only Modunu Uygula**

Aspose.Slides for Android via Java, bir sunumu **Read-Only** olarak ayarlamanıza olanak tanır; yani kullanıcılar (sunumu açtıktan sonra) **Read-Only** önerisini görür. Bu örnek kod, Aspose.Slides kullanarak Java'da bir sunumu **Read-Only** olarak nasıl ayarlayacağınızı gösterir:

```java
Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

**Not**: **Read-Only** önerisi, PowerPoint sunumunda düzenlemeyi caydırmak veya kullanıcıların yanlışlıkla değişiklik yapmasını önlemek amacıyla basitçe sunulur. Ne yaptığını bilen motive bir kişi sunumunuzu düzenlemeye karar verirse, Read-Only ayarını kolayca kaldırabilir. Yetkisiz düzenlemeleri gerçekten engellemeniz gerekiyorsa, [şifreleme ve parola içeren daha sıkı korumalar](https://docs.aspose.com/slides/tr/androidjava/password-protected-presentation/) kullanmanız daha iyi olur.

{{% /alert %}} 

## **SSS**

**'Read-Only recommended' tam parola korumasından nasıl farklıdır?**

'Read-Only recommended' yalnızca dosyanın sadece okunur modda açılması önerisini gösterir ve kolayca atlatılabilir. [Parola koruması](/slides/tr/androidjava/password-protected-presentation/) aslında açma veya düzenleme işlemlerini kısıtlar ve gerçek güvenlik kontrollerine ihtiyacınız olduğunda uygundur.

**'Read-Only recommended' su işaretleriyle birleştirilebilir ve düzenlemeleri daha da caydırabilir mi?**

Evet. Öneri, [filigranlar](/slides/tr/androidjava/watermark/) ile görsel bir caydırıcı olarak eşleştirilebilir; bunlar ayrı mekanizmalardır ve birlikte iyi çalışır.

**Öneri etkin olduğunda bir makro ya da dış araç hâlâ dosyayı değiştirebilir mi?**

Evet. Öneri programatik değişiklikleri engellemez. Otomatik düzenlemeleri önlemek için [parolalar ve şifreleme](/slides/tr/androidjava/password-protected-presentation/) kullanın.

**'Read-Only recommended', 'isEncrypted' ve 'isWriteProtected' yöntemleriyle nasıl ilişkilidir?**

Farklı sinyallerdir. 'Read-Only recommended' yumuşak, isteğe bağlı bir uyarıdır; [isWriteProtected](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) ve [isEncrypted](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) ise parolalar veya şifreleme gibi gerçek yazma ya da okuma kısıtlamalarını gösterir.