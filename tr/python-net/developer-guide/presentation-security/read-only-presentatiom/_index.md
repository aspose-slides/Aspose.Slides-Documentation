---
title: Read-Only Modda Sunumları Python ile Kaydet
linktitle: Read-Only Sunumu
type: docs
weight: 30
url: /tr/python-net/read-only-presentation/
keywords:
- salt okunur
- sunumu koru
- düzenlemeyi önle
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint dosyalarını (PPT, PPTX) salt okunur modda yükleyin ve kaydedin, sunumlarınızı değiştirmeden kesin slayt önizlemeleri sunar."
---
## **Giriş**

PowerPoint 2019'da Microsoft, kullanıcıların sunumlarını korumak için kullanabilecekleri seçeneklerden biri olarak **Always Open Read-Only** ayarını tanıttı. Sunumu korumak için bu Read-Only ayarını şu durumlarda kullanmak isteyebilirsiniz:

- Sunumunuzun içeriğini kazara düzenlemelerden korumak ve güvende tutmak istiyorsanız. 
- Sağladığınız sunumun son sürüm olduğunu insanlara bildirmek istiyorsanız. 

Bir sunum için **Always Open Read-Only** seçeneğini seçtikten sonra, kullanıcılar sunumu açtıklarında **Read-Only** önerisini görür ve şu şekilde bir mesaj alabilirler: *Kazara değişiklikleri önlemek için yazar bu dosyayı yalnızca okunacak şekilde açılacak şekilde ayarlamıştır.*

Read-Only önerisi, kullanıcıların bir sunumu düzenleyebilmeleri için önce bu öneriyi kaldırmaları gerektiğinden dolayı düzenlemeyi caydıran basit ama etkili bir engeldir. Kullanıcıların bir sunumda değişiklik yapmasını istemiyor ve bunu nazik bir şekilde bildirmek istiyorsanız, Read-Only önerisi sizin için iyi bir seçenek olabilir. 

> **Read-Only** korumalı bir sunum, bu yeni işlevi desteklemeyen daha eski bir Microsoft PowerPoint uygulamasında açılırsa, **Read-Only** önerisi göz ardı edilir (sunum normal olarak açılır).

## **Read-Only Modu Uygula**

Aspose.Slides for Python via .NET, bir sunumu **Read-Only** olarak ayarlamanıza olanak tanır; bu, kullanıcıların (sunumu açtıktan sonra) **Read-Only** önerisini görmesi anlamına gelir. Bu örnek kod, Aspose.Slides kullanarak Python'da bir sunumu **Read-Only** olarak nasıl ayarlayacağınızı gösterir:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.read_only_recommended = True
    pres.save("ReadOnlyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

**Not**: **Read-Only** önerisi, bir PowerPoint sunumunda düzenlemeyi caydırmak veya kullanıcıların kazara değişiklik yapmasını önlemek amacıyla tasarlanmıştır. Ne yaptığını bilen istekli bir kişi sunumunuzu düzenlemeye karar verirse, Read-Only ayarını kolayca kaldırabilir. Yetkisiz düzenlemeleri ciddiyetle önlemeniz gerekiyorsa, [şifreleme ve parolalar içeren daha katı korumalar](https://docs.aspose.com/slides/tr/python-net/password-protected-presentation/) kullanmanız daha iyi olur. 

{{% /alert %}} 

## **SSS**

**'Read-Only recommended' tam parola korumasından nasıl farklıdır?**

'Read-Only recommended' yalnızca dosyanın yalnızca okunacak modda açılması önerisini gösterir ve atlatması kolaydır. [Parola koruması](/slides/tr/python-net/password-protected-presentation/) aslında açma veya düzenlemeyi kısıtlar ve gerçek güvenlik kontrollerine ihtiyaç duyduğunuzda uygundur.

**'Read-Only recommended' su işaretleriyle birleştirilebilir ve düzenlemeleri daha da caydırabilir mi?**

Evet. Öneri, görsel bir caydırıcı olarak [su işaretleri](/slides/tr/python-net/watermark/) ile birleştirilebilir; bunlar ayrı mekanizmalardır ve birlikte iyi çalışır.

**Öneri etkin olduğunda bir makro veya dış araç hâlâ dosyayı değiştirebilir mi?**

Evet. Öneri programatik değişiklikleri engellemez. Otomatik düzenlemeleri önlemek için [parolalar ve şifreleme](/slides/tr/python-net/password-protected-presentation/) kullanın.

**'Read-Only recommended' 'is_encrypted' ve 'is_write_protected' bayraklarıyla nasıl ilişkilidir?**

Bunlar farklı sinyallerdir. 'Read-Only recommended' yumuşak, isteğe bağlı bir uyarıdır; [is_write_protected](https://reference.aspose.com/slides/tr/python-net/aspose.slides/protectionmanager/is_write_protected/) ve [is_encrypted](https://reference.aspose.com/slides/tr/python-net/aspose.slides/protectionmanager/is_encrypted/) ise parolalar veya şifreleme ile belirlenen gerçek yazma veya okuma kısıtlamalarını gösterir.