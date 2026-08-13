---
title: C++ Kullanarak Okuma-Yalnızca Modunda Sunumları Kaydetme
linktitle: Okuma-Yalnızca Sunum
type: docs
weight: 30
url: /tr/cpp/read-only-presentation/
keywords:
- okuma-yalnızca
- sunumu koru
- düzenlemeyi önle
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint dosyalarını (PPT, PPTX) okuma-yalnızca modunda yükleyip kaydedin; sunumlarınızı değiştirmeden kesin slayt ön izlemeleri sunar."
---
## **Giriş**

PowerPoint 2019'da Microsoft, sunumları korumak için kullanıcıların kullanabileceği seçeneklerden biri olarak **Always Open Read-Only** ayarını tanıttı. Bu Okuma-Yalnızca ayarını bir sunumu korumak için şu durumlarda kullanmak isteyebilirsiniz

- Yanlışlıkla yapılan düzenlemeleri önlemek ve sunum içeriğinizi güvende tutmak istediğinizde. 
- Sağladığınız sunumun son sürüm olduğunu insanlara bildirmek istediğinizde. 

Bir sunum için **Always Open Read-Only** seçeneğini belirledikten sonra, kullanıcılar sunumu açtıklarında **Read-Only** önerisini görür ve şu şekilde bir ileti görebilirler: *Yanlışlıkla değişiklik yapılmasını önlemek için yazar bu dosyayı yalnızca okunacak şekilde ayarlamıştır.*

Read-Only önerisi, kullanıcıların bir sunumu düzenleyebilmek için önce bu öneriyi kaldırması gerektiği için düzenlemeyi caydıran basit ama etkili bir önlemdir. Kullanıcıların bir sunumu değiştirmesini istemiyor ve bunu nazik bir şekilde belirtmek istiyorsanız, Read-Only önerisi sizin için iyi bir seçenek olabilir. 

> **Read-Only** korumalı bir sunum, yeni eklenen işlevi desteklemeyen daha eski bir Microsoft PowerPoint uygulamasında açılırsa, **Read-Only** önerisi göz ardı edilir (sunum normal şekilde açılır).

## **Okuma-Yalnızca Modunu Uygula**

Aspose.Slides for C++ size bir sunumu **Read-Only** olarak ayarlama imkanı sağlar; bu, kullanıcıların (sunumu açtıktan sonra) **Read-Only** önerisini görmesi anlamına gelir. Bu örnek kod, Aspose.Slides kullanarak C++’ta bir sunumu **Read-Only** olarak nasıl ayarlayacağınızı gösterir:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="info" %}} 

**Not**: **Read-Only** önerisi, bir PowerPoint sunumunda düzenlemeyi caydırmak veya kullanıcıların yanlışlıkla değişiklik yapmasını önlemek için tasarlanmıştır. Ne yaptığını bilen motive bir kişi sunumunuzu düzenlemeye karar verirse, Read-Only ayarını kolayca kaldırabilir. Yetkisiz düzenlemeleri gerçekten önlemeniz gerekiyorsa, [şifrelemeler ve parolalar içeren daha katı korumalar](https://docs.aspose.com/slides/tr/cpp/password-protected-presentation/) kullanmanız daha iyidir. 

{{% /alert %}} 

## **SSS**

### 'Read-Only recommended' tam parola korumasından nasıl farklıdır?

'Read-Only recommended' yalnızca dosyanın yalnızca okunacak modda açılması önerisini gösterir ve geçmesi kolaydır. [Parola koruması](/slides/tr/cpp/password-protected-presentation/) aslında açma veya düzenlemeyi kısıtlar ve gerçek güvenlik kontrollerine ihtiyacınız olduğunda uygundur.

### 'Read-Only recommended' su işaretlemelerle birleştirilebilir mi?

Evet. Öneri, görsel bir caydırıcı olarak [filigranlar](/slides/tr/cpp/watermark/) ile eşleştirilebilir; bunlar ayrı mekanizmalardır ve birlikte iyi çalışırlar.

### Bir makro ya da dış araç, öneri etkin olduğunda dosyayı değiştirebilir mi?

Evet. Öneri programatik değişiklikleri engellemez. Otomatik düzenlemeleri önlemek için [parolalar ve şifreleme](/slides/tr/cpp/password-protected-presentation/) kullanın.

### 'Read-Only recommended' 'is encrypted' ve 'is write protected' bayraklarıyla nasıl ilişkilidir?

Bunlar farklı sinyallerdir. 'Read-Only recommended' yumuşak, isteğe bağlı bir istemdir; [get_IsWriteProtected](https://reference.aspose.com/slides/tr/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) ve [get_IsEncrypted](https://reference.aspose.com/slides/tr/cpp/aspose.slides/protectionmanager/get_isencrypted/) ise parolalar veya şifreleme ile belirlenen gerçek yazma veya okuma kısıtlamalarını gösterir.