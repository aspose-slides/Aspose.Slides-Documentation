---
title: Java Kullanarak Okunur-Olarak Modda Sunumları Kaydetme
linktitle: Okunur-Olarak Sunum
type: docs
weight: 30
url: /tr/java/read-only-presentation/
keywords:
- okunur
- sunumu koru
- düzenlemeyi önle
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint dosyalarını (PPT, PPTX) okunur modda yükleyin ve kaydedin, sunumlarınızı değiştirmeden tam slide ön izlemeleri sağlar."
---
## **Giriş**

PowerPoint 2019'da Microsoft, sunumları korumak için kullanıcıların kullanabileceği seçeneklerden biri olarak **Always Open Read-Only** ayarını tanıttı. Bu Okunur-Olarak Aç ayarını bir sunumu korumak için şu durumlarda kullanmak isteyebilirsiniz

- Sunumunuzun içeriğini korumak ve kazara yapılan düzenlemeleri önlemek istiyorsanız. 
- Sağladığınız sunumun son sürüm olduğunu insanlara bildirmek istiyorsanız. 

Bir sunum için **Always Open Read-Only** seçeneğini seçtikten sonra, kullanıcılar sunumu açtıklarında **Read-Only** önerisini görürler ve şu şekilde bir mesaj görebilirler: *Kazara değişiklikleri önlemek için yazar bu dosyayı yalnızca okunacak şekilde açacak şekilde ayarlamış.*

Read-Only önerisi, kullanıcıların bir sunumu düzenleyebilmeleri için bunu kaldırmak üzere bir görev yapmalarını gerektirdiğinden düzenlemeyi caydıran basit ama etkili bir önlemdir. Kullanıcıların bir sunumu değiştirmesini istemiyor ve bunu nazik bir şekilde bildirmek istiyorsanız, Read-Only önerisi sizin için iyi bir seçenek olabilir. 

> **Read-Only** korumalı bir sunum, yeni eklenen işlevi desteklemeyen daha eski bir Microsoft PowerPoint uygulamasında açılırsa, **Read-Only** önerisi göz ardı edilir (sunum normal şekilde açılır).

## **Okunur-Olarak Aç Modunu Uygula**

Aspose.Slides for Java, bir sunumu **Read-Only** olarak ayarlamanıza izin verir; bu, kullanıcıların (sunumu açtıktan sonra) **Read-Only** önerisini görmesi anlamına gelir. Bu örnek kod, Aspose.Slides kullanarak Java'da bir sunumu **Read-Only** olarak nasıl ayarlayacağınızı gösterir:

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

**Not**: **Read-Only** önerisi, bir PowerPoint sunumundaki düzenlemeleri caydırmak veya kullanıcıların kazara değişiklik yapmasını önlemek amacıyla hazırlanmıştır. Ne yaptığını bilen motive bir kişi, sunumunuzu düzenlemeye karar verirse, **Read-Only** ayarını kolayca kaldırabilir. Yetkisiz düzenlemeleri gerçekten önlemeniz gerekiyorsa, [şifreleme ve parolalar içeren daha katı korumaları](https://docs.aspose.com/slides/tr/java/password-protected-presentation/) kullanmanız daha iyidir. 

{{% /alert %}} 

## **SSS**

**'Read-Only recommended' tam şifre korumasından nasıl farklıdır?**

'Read-Only recommended' sadece dosyanın yalnızca okunacak modda açılması önerisini gösterir ve kolayca baypas edilebilir. [Şifre koruması](/slides/tr/java/password-protected-presentation/) aslında açmayı veya düzenlemeyi kısıtlar ve gerçek güvenlik kontrollerine ihtiyacınız olduğunda uygundur.

**'Read-Only recommended' filigranlarla birleştirilebilir mi?**

Evet. Öneri, [filigranlar](/slides/tr/java/watermark/) ile görsel bir caydırıcı olarak eşleştirilebilir; bunlar ayrı mekanizmalardır ve birlikte iyi çalışır.

**Bir makro veya dış araç öneri etkin olduğunda dosyayı hâlâ değiştirebilir mi?**

Evet. Öneri programatik değişiklikleri engellemez. Otomatik düzenlemeleri önlemek için [parolalar ve şifreleme](/slides/tr/java/password-protected-presentation/) kullanın.

**'Read-Only recommended' 'isEncrypted' ve 'isWriteProtected' yöntemleriyle nasıl ilişkilidir?**

Farklı sinyallerdir. 'Read-Only recommended' yumuşak, isteğe bağlı bir istemdir; [isWriteProtected](https://reference.aspose.com/slides/tr/java/com.aspose.slides/protectionmanager/#isWriteProtected--) ve [isEncrypted](https://reference.aspose.com/slides/tr/java/com.aspose.slides/protectionmanager/#isEncrypted--) ise parolalar ya da şifreleme ile sınırlanan gerçek yazma veya okuma kısıtlamalarını gösterir.