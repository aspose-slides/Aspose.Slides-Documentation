---
title: PowerPoint Sunumlarını .NET'te Salt Okunur Modda Kaydet
linktitle: Salt Okunur Sunum
type: docs
weight: 30
url: /tr/net/read-only-presentation/
keywords:
- salt okunur
- sunumu koru
- düzenlemeyi önle
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint dosyalarını (PPT, PPTX) salt okunur modda yükleyip kaydedin, sunumlarınızı değiştirmeden kesin slayt önizlemeleri sağlar."
---
## **Giriş**

PowerPoint 2019'da Microsoft, sunumları korumak için kullanıcıların kullanabileceği seçeneklerden biri olarak **Always Open Read-Only** ayarını tanıttı. Bu Read-Only ayarını bir sunumu korumak için aşağıdaki durumlarda kullanmak isteyebilirsiniz:

- Yanlışlıkla yapılan düzenlemeleri önlemek ve sunumunuzun içeriğini güvende tutmak istiyorsanız. 
- Sağladığınız sunumun son sürüm olduğunu insanlara bildirmek istiyorsanız. 

Bir sunum için **Always Open Read-Only** seçeneğini seçtikten sonra, kullanıcılar sunumu açtıklarında **Read-Only** önerisini görür ve aşağıdaki biçimde bir mesaj alabilirler: *Yanlışlıkla yapılan değişiklikleri önlemek için yazar bu dosyayı yalnızca okunacak şekilde açılacak şekilde ayarlamıştır.*

Read-Only önerisi, kullanıcıların bir sunumu düzenleyebilmek için öncelikle bunu kaldırmaları gerektiği için düzenlemeyi caydıran basit ama etkili bir önlemdir. Kullanıcıların bir sunumu değiştirmesini istemiyor ve bunu kibar bir şekilde belirtmek istiyorsanız, Read-Only önerisi sizin için iyi bir seçenek olabilir. 

> Eski bir Microsoft PowerPoint uygulamasında (**Read-Only** korumasına sahip bir sunum açılırsa—yeni eklenen işlevi desteklemezse— **Read-Only** önerisi göz ardı edilir (sunum normal olarak açılır)). 

## **Read-Only Modunu Uygula**

Aspose.Slides for .NET, bir sunumu **Read-Only** olarak ayarlamanıza olanak tanır; bu, kullanıcıların (sunumu açtıktan sonra) **Read-Only** önerisini görmesi anlamına gelir. Bu örnek kod, Aspose.Slides kullanarak C# içinde bir sunumu **Read-Only** olarak nasıl ayarlayacağınızı gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}} 

**Not**: **Read-Only** önerisi yalnızca bir PowerPoint sunumunda düzenlemeyi caydırmak veya kullanıcıların yanlışlıkla değişiklik yapmasını önlemek içindir. Ne yaptığını bilen motive bir kişi sunumunuzu düzenlemeye karar verirse, Read-Only ayarını kolayca kaldırabilir. Yetkisiz düzenlemeleri ciddi şekilde önlemeniz gerekiyorsa, [şifreleme ve parolalar içeren daha katı korumalar](https://docs.aspose.com/slides/tr/net/password-protected-presentation/) kullanmanız daha iyidir. 

{{% /alert %}} 

## **SSS**

### 'Read-Only recommended' tam parola korumasından nasıl farklıdır?

'Read-Only recommended', dosyayı yalnızca yalnız okuma modunda açma önerisi gösterir ve geçmesi kolaydır. [Password protection](/slides/tr/net/password-protected-presentation/) ise gerçek anlamda açma veya düzenleme kısıtlaması getirir ve gerçek güvenlik denetimlerine ihtiyaç duyduğunuzda uygundur.

### 'Read-Only recommended' su işaretleriyle birleştirilebilir mi?

Evet. Öneri, [watermarks](/slides/tr/net/watermark/) ile bir görsel caydırıcı olarak eşleştirilebilir; bunlar ayrı mekanizmalardır ve birlikte iyi çalışır.

### Öneri aktifken bir makro veya dış araç dosyayı değiştirebilir mi?

Evet. Öneri programatik değişiklikleri engellemez. Otomatik düzenlemeleri önlemek için [passwords and encryption](/slides/tr/net/password-protected-presentation/) kullanın.

### 'Read-Only recommended' 'IsEncrypted' ve 'IsWriteProtected' bayraklarıyla nasıl ilişkilidir?

Bunlar farklı sinyallerdir. 'Read-Only recommended' yumuşak, isteğe bağlı bir bildirimdir; [IsWriteProtected](https://reference.aspose.com/slides/tr/net/aspose.slides/protectionmanager/iswriteprotected/) ve [IsEncrypted](https://reference.aspose.com/slides/tr/net/aspose.slides/protectionmanager/isencrypted/) ise parolalar veya şifreleme gerektiren gerçek yazma veya okuma kısıtlamalarını gösterir.