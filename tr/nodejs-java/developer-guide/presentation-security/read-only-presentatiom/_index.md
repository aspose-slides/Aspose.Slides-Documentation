---
title: JavaScript Kullanarak Okunur Modda Sunumları Kaydetme
linktitle: Okunur Mod Sunumu
type: docs
weight: 30
url: /tr/nodejs-java/read-only-presentation/
keywords:
- sadece okuma
- sunumu koruma
- düzenlemeyi önleme
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java ile PowerPoint dosyalarını okunur modda yükleyin ve kaydedin, sunumlarınızı değiştirmeden kesin slayt önizlemeleri sunar."
---
## **Giriş**

PowerPoint 2019'da Microsoft, sunumları korumak için kullanıcıların kullanabileceği seçeneklerden biri olarak **Always Open Read-Only** ayarını tanıttı. Bu Okunur Modu ayarını şu durumlarda kullanmak isteyebilirsiniz:

- Kazara düzenlemeleri önlemek ve sunum içeriğinizi güvende tutmak istediğinizde. 
- Sağladığınız sunumun son sürüm olduğunu insanlara bildirmek istediğinizde. 

Bir sunum için **Always Open Read-Only** seçeneğini seçtikten sonra, kullanıcılar sunumu açtıklarında **Read-Only** önerisini görür ve şu mesajı görebilirler: *Kazara değişiklikleri önlemek için yazar bu dosyayı yalnızca okunur olarak açılacak şekilde ayarladı.*

Read-Only önerisi, kullanıcıların düzenleme yapmadan önce bu öneriyi kaldırmak için bir işlem gerçekleştirmesini gerektirdiği için düzenlemeyi engelleyen basit ama etkili bir caydırıcıdır. Kullanıcıların bir sunumu değiştirmesini istemiyor ve bunu nazik bir şekilde ifade etmek istiyorsanız, Read-Only önerisi sizin için iyi bir seçenek olabilir. 

> **Read-Only** korumasıyla bir sunum, bu işlevi desteklemeyen eski bir Microsoft PowerPoint uygulamasında açılırsa (**Read-Only** önerisi göz ardı edilir ve sunum normal şekilde açılır).

## **Okunur Modu Uygula**

Aspose.Slides for Node.js via Java, bir sunumu **Read-Only** olarak ayarlamanıza olanak tanır; bu, kullanıcıların (sunumu açtıktan sonra) **Read-Only** önerisini görmesi anlamına gelir. Aşağıdaki örnek kod, Aspose.Slides kullanarak bir sunumu JavaScript'te **Read-Only** olarak nasıl ayarlayacağınızı gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 

**Not**: **Read-Only** önerisi, bir PowerPoint sunumunda düzenlemeyi caydırmak veya kazara değişiklikleri önlemek amacıyla sunulmuş basit bir tavsiyedir. Ne yaptığını bilen motive bir kişi sunumunuzu düzenlemeye karar verirse, Read-Only ayarını kolayca kaldırabilir. Yetkisiz düzenlemeleri gerçekten önlemeniz gerekiyorsa, [şifreleme ve parola içeren daha katı korumaları] (https://docs.aspose.com/slides/tr/nodejs-java/password-protected-presentation/) kullanmanız daha iyidir.

{{% /alert %}} 

## **SSS**

**'Read-Only recommended' tam şifre korumasından nasıl farklıdır?**

'Read-Only recommended' yalnızca dosyanın yalnızca okunur modda açılması önerisini gösterir ve kolayca atlatılabilir. [Şifre koruması](/slides/tr/nodejs-java/password-protected-presentation/) ise açma veya düzenleme üzerinde gerçek bir kısıtlama getirir ve gerçek güvenlik kontrollerine ihtiyaç duyduğunuzda uygundur.

**'Read-Only recommended' su işaretleriyle birleştirilebilir mi?**

Evet. Öneri, [su işaretleri](/slides/tr/nodejs-java/watermark/) ile görsel bir caydırıcı olarak eşleştirilebilir; bunlar ayrı mekanizmalardır ve birlikte iyi çalışır.

**Öneri etkin olduğunda bir makro ya da dış araç dosyayı hâlâ değiştirebilir mi?**

Evet. Öneri programatik değişiklikleri engellemez. Otomatik düzenlemeleri önlemek için [parolalar ve şifreleme](/slides/tr/nodejs-java/password-protected-presentation/) kullanın.

**'Read-Only recommended' 'IsEncrypted' ve 'IsWriteProtected' bayraklarıyla nasıl ilişkilidir?**

Bunlar farklı sinyallerdir. 'Read-Only recommended' yumuşak, isteğe bağlı bir öneridir; [isWriteProtected](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/protectionmanager/iswriteprotected/) ve [isEncrypted](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/protectionmanager/isencrypted/) ise parolalar veya şifreleme üzerine kurulu gerçek yazma veya okuma kısıtlamalarını gösterir.