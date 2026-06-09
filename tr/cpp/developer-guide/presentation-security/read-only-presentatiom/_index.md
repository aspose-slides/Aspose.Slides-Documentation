---
title: C++ Kullanarak Okunabilir Modda Sunumları Kaydet
linktitle: Okunabilir Sunum
type: docs
weight: 30
url: /tr/cpp/read-only-presentation/
keywords:
- yalnızca okuma
- sunumu koruma
- düzenlemeyi önleme
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint dosyalarını (PPT, PPTX) okunabilir modda yükleyin ve kaydedin, sunumlarınızı değiştirmeden kesin slayt önizlemeleri sağlayın."
---
## **Giriş**

PowerPoint 2019'da Microsoft, sunumları korumak için kullanıcıların kullanabileceği seçeneklerden biri olarak **Always Open Read-Only** ayarını tanıttı. Bu Read-Only ayarını bir sunumu korumak istediğinizde kullanmak isteyebilirsiniz:

- Sunumunuzun içeriğini kazara düzenlemeleri önlemek ve güvenli tutmak isterseniz.  
- Sağladığınız sunumun son sürüm olduğunu insanlara bildirmek isterseniz.  

**Always Open Read-Only** seçeneğini bir sunum için etkinleştirdikten sonra, kullanıcılar sunumu açtıklarında **Read-Only** tavsiyesini görür ve şu şekilde bir mesaj görebilirler: *Kazara değişiklikleri önlemek için yazar bu dosyayı yalnızca okunacak biçimde açılacak şekilde ayarlamıştır.*

Read-Only tavsiyesi, kullanıcıların bir sunumu düzenleyebilmeleri için önce bu tavsiyeyi kaldırmalarını gerektiren basit ama etkili bir caydırıcıdır. Eğer kullanıcıların bir sunumu değiştirmesini istemiyor ve bunu kibar bir şekilde iletmek istiyorsanız, Read-Only tavsiyesi sizin için iyi bir seçenek olabilir.  

> **Read-Only** korumasıyla açılmış bir sunum daha eski bir Microsoft PowerPoint uygulamasında (yeni işlevi desteklemeyen) açılırsa, **Read-Only** tavsiyesi yoksayılır (sunum normal şekilde açılır).

## **Read-Only Modunu Uygula**

Aspose.Slides for C++ size bir sunumu **Read-Only** olarak ayarlama imkanı verir; bu, kullanıcıların (sunumu açtıktan sonra) **Read-Only** tavsiyesini görmeleri anlamına gelir. Aşağıdaki örnek kod, Aspose.Slides kullanarak C++ içinde bir sunumu **Read-Only** olarak nasıl ayarlayacağınızı gösterir:

``` cpp
auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="primary" %}} 

**Not**: **Read-Only** tavsiyesi, bir PowerPoint sunumunda kazara değişiklik yapılmasını önlemek ya da düzenlemeyi caydırmak için tasarlanmıştır. İşini bilen bir kişi (ne yaptığını bilen) sunumunuzu düzenlemeye karar verirse, Read-Only ayarını kolayca kaldırabilir. Gerçekten yetkisiz düzenlemeleri önlemek istiyorsanız, [more stringent protections that involve encryptions and passwords](https://docs.aspose.com/slides/tr/cpp/password-protected-presentation/) kullanmanız daha iyidir. 

{{% /alert %}} 

## **SSS**

**'Read-Only recommended' tam parola korumasından nasıl farklıdır?**

'Read-Only recommended' yalnızca dosyanın yalnızca okunacak modda açılması önerisini gösterir ve kolayca aşılabilir. [Password protection](/slides/tr/cpp/password-protected-presentation/) ise açma ya da düzenleme işlemlerini gerçekten kısıtlar ve gerçek güvenlik kontrollerine ihtiyaç duyduğunuzda uygundur.

**'Read-Only recommended' bir su işareti (watermark) ile birleştirilebilir ve düzenlemeleri daha da caydırabilir mi?**

Evet. Bu öneri, görsel bir caydırıcı olarak [watermarks](/slides/tr/cpp/watermark/) ile eşleştirilebilir; bunlar ayrı mekanizmalardır ve birlikte iyi çalışır.

**Öneri etkin olduğunda bir makro ya da dış araç hâlâ dosyayı değiştirebilir mi?**

Evet. Öneri programatik değişiklikleri engellemez. Otomatik düzenlemeleri önlemek için [passwords and encryption](/slides/tr/cpp/password-protected-presentation/) kullanın.

**'Read-Only recommended' “is encrypted” ve “is write protected” bayraklarıyla nasıl ilişkilidir?**

Bunlar farklı sinyallerdir. 'Read-Only recommended' yumuşak, isteğe bağlı bir uyarıdır; [get_IsWriteProtected](https://reference.aspose.com/slides/tr/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) ve [get_IsEncrypted](https://reference.aspose.com/slides/tr/cpp/aspose.slides/protectionmanager/get_isencrypted/) ise parolalar ya da şifreleme ile bağlı gerçek yazma ya da okuma kısıtlamalarını gösterir.