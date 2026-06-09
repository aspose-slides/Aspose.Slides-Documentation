---
title: Salt Okunur Modda Sunumları .NET'te Kaydet
linktitle: Salt Okunur Sunum
type: docs
weight: 30
url: /tr/net/read-only-presentation/
keywords:
- salt okunur
- sunumu koruma
- düzenlemeyi önle
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint dosyalarını (PPT, PPTX) salt okunur modda yükleyip kaydedin, sunumlarınızı değiştirmeden kesin slayt ön izlemeleri sağlar."
---
## **Giriş**

PowerPoint 2019'da Microsoft, sunumları korumak için kullanıcıların kullanabileceği seçeneklerden biri olarak **Always Open Read-Only** ayarını tanıttı. Bu Read-Only ayarını bir sunumu korumak için şu durumlarda kullanmak isteyebilirsiniz:

- Yanlışlıkla yapılan düzenlemeleri önlemek ve sunum içeriğinizi güvende tutmak istiyorsunuz. 
- Sağladığınız sunumun son sürüm olduğunu insanlara bildirmek istiyorsunuz. 

Bir sunum için **Always Open Read-Only** seçeneğini seçtikten sonra, kullanıcılar sunumu açtıklarında **Read-Only** önerisini görür ve şu biçimde bir mesaj alabilirler: *Yanlışlıkla değişiklik yapılmasını önlemek için yazar bu dosyayı yalnızca okunacak şekilde açacak şekilde ayarlamıştır.*

Read-Only önerisi, kullanıcıların bir sunumu düzenleyebilmeleri için önce bu öneriyi kaldırmaları gerektiğinden düzenlemeyi caydıran basit ama etkili bir önlemdir. Kullanıcıların bir sunumu değiştirmesini istemiyor ve bunu nazik bir şekilde bildirmek istiyorsanız, Read-Only önerisi sizin için iyi bir seçenek olabilir. 

> **Read-Only** korumalı bir sunum, yakın zamanda tanıtılan işlevi desteklemeyen eski bir Microsoft PowerPoint uygulamasında açılırsa, **Read-Only** önerisi görmezden gelinir (sunum normal şekilde açılır).

## **Read-Only Modunu Uygula**

Aspose.Slides for .NET, bir sunumu **Read-Only** olarak ayarlamanıza izin verir; bu, kullanıcıların (sunumu açtıktan sonra) **Read-Only** önerisini görmesi anlamına gelir. Aşağıdaki örnek kod, Aspose.Slides kullanarak bir sunumu C# ile **Read-Only** olarak nasıl ayarlayacağınızı gösterir:

```c#
using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}} 

**Not**: **Read-Only** önerisi, bir PowerPoint sunumunda düzenlemeyi caydırmak veya yanlışlıkla yapılan değişiklikleri önlemek amacıyla sunulur. İşini bilen ve kararlı bir kişi sunumunuzu düzenlemeye karar verirse, Read-Only ayarını kolayca kaldırabilir. Yetkisiz düzenlemeyi gerçekten engellemek istiyorsanız, [daha sıkı korumalar ve şifreleme ile parola koruması](https://docs.aspose.com/slides/tr/net/password-protected-presentation/) kullanmanız daha iyidir. 

{{% /alert %}} 

## **SSS**

**'Read-Only recommended' tam parola korumasından nasıl farklıdır?**

'Read-Only recommended' sadece dosyanın yalnızca okunacak modda açılmasını önerir ve kolayca geçilebilir. [Parola koruması](/slides/tr/net/password-protected-presentation/) ise açma veya düzenlemeyi gerçekten kısıtlar ve gerçek güvenlik kontrollerine ihtiyaç duyduğunuzda uygundur.

**'Read-Only recommended' su işaretleriyle birleştirilebilir mi?**

Evet. Öneri, görsel bir caydırıcı olarak [su işaretleri](/slides/tr/net/watermark/) ile eşleştirilebilir; bunlar ayrı mekanizmalardır ve birlikte iyi çalışır.

**Bir makro ya da dış araç öneri etkin olduğunda dosyayı yine de değiştirebilir mi?**

Evet. Öneri programatik değişiklikleri engellemez. Otomatik düzenlemeyi önlemek için [parola ve şifreleme](/slides/tr/net/password-protected-presentation/) kullanın.

**'Read-Only recommended' 'IsEncrypted' ve 'IsWriteProtected' bayraklarıyla nasıl ilişkilidir?**

Farklı sinyallerdir. 'Read-Only recommended' yumuşak, isteğe bağlı bir bildirimdir; [IsWriteProtected](https://reference.aspose.com/slides/tr/net/aspose.slides/protectionmanager/iswriteprotected/) ve [IsEncrypted](https://reference.aspose.com/slides/tr/net/aspose.slides/protectionmanager/isencrypted/) ise parolalar veya şifreleme ile bağlı gerçek yazma veya okuma kısıtlamalarını gösterir.