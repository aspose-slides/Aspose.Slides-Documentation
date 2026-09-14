---
title: Python Kullanarak Okuma‑Yazma Modunda Sunumları Kaydetme
linktitle: Okuma‑Yazma Sunumu
type: docs
weight: 30
url: /tr/python-java/read-only-presentation/
keywords:
- salt okunur
- sunumu koru
- düzenlemeyi önle
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PowerPoint dosyalarını (PPT, PPTX) salt okunur modda yükleyin ve kaydedin; sunumlarınızı değiştirmeden kesin slayt önizlemeleri sunar."
---
## **Giriş**

PowerPoint 2019’da Microsoft, sunumları korumak için kullanıcıların kullanabileceği seçeneklerden biri olarak **Always Open Read-Only** (Her Zaman Okuma‑Yazma Modunda Aç) ayarını tanıttı. Bu Okuma‑Yazma ayarını aşağıdaki durumlarda bir sunumu korumak için kullanmak isteyebilirsiniz:

- Sunumunuzun içeriğini kazara değişikliklerden koruyarak güvenli tutmak istediğinizde.  
- Sağladığınız sunumun son sürüm olduğunu insanlara bildirmek istediğinizde.  

Bir sunum için **Always Open Read-Only** seçeneğini belirlediğinizde, kullanıcılar sunumu açtıklarında **Read-Only** (Salt Okunur) önerisini görür ve aşağıdaki gibi bir ileti alabilirler: *Kazara değişiklikleri önlemek için yazar bu dosyayı salt okunur olarak açılacak şekilde ayarlamıştır.*

Read-Only önerisi, kullanıcıların bir sunumu düzenleyebilmeleri için bu öneriyi kaldırmalarını gerektirdiği için düzenlemeyi engelleyen basit ama etkili bir caydırıcıdır. Kullanıcıların bir sunumu değiştirmesini istemiyor ve bunu nazik bir şekilde bildirmek istiyorsanız, Read-Only önerisi sizin için uygun bir seçenek olabilir.

> **Not:** **Read-Only** koruması olan bir sunum, bu yeni işlevi desteklemeyen daha eski bir Microsoft PowerPoint uygulamasında açıldığında **Read-Only** önerisi göz ardı edilir (sunum normal şekilde açılır).

## **Okuma Modunu Uygula**

Aspose.Slides for Python via Java, bir sunumu **Read-Only** olarak ayarlamanıza olanak tanır; yani kullanıcılar (sunumu açtıktan sonra) **Read-Only** önerisini görür. Aşağıdaki örnek kod, Aspose.Slides kullanarak Python’da bir sunumu **Read-Only** olarak nasıl ayarlayacağınızı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getProtectionManager().setReadOnlyRecommended(True)
    presentation.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

**Read-Only** önerisi, PowerPoint sunumunda düzenlemeyi caydırmak veya kazara değişiklikleri önlemek amacıyla tasarlanmıştır. İşini bilen motive bir kişi sunumunuzu düzenlemeye karar verirse, Read-Only ayarını kolayca kaldırabilir. Yetkisiz düzenlemeleri gerçekten engellemeniz gerekiyorsa, [daha katı şifreleme ve parola içeren korumalar](/slides/tr/python-java/password-protected-presentation/) kullanmanız daha iyidir. 

{{% /alert %}} 

## **SSS**

**'Read-Only recommended' tam parola korumasından nasıl farklıdır?**  
‘Read-Only recommended’ yalnızca dosyanın salt okunur modda açılması önerisini gösterir ve kolayca atlatılabilir. [Parola koruması](/slides/tr/python-java/password-protected-presentation/) ise açma veya düzenlemeyi gerçekten kısıtlar ve gerçek güvenlik kontrolüne ihtiyaç duyduğunuzda uygundur.  

**'Read-Only recommended' su işaretleriyle (watermarks) birleştirilebilir mi?**  
Evet. Öneri, görsel bir caydırıcı olarak [filigranlar](/slides/tr/python-java/watermark/) ile eşleştirilebilir; bunlar ayrı mekanizmalardır ve birlikte iyi çalışır.  

**Öneri etkin olduğunda bir makro ya da dış araç dosyayı hâlâ değiştirebilir mi?**  
Evet. Öneri programatik değişiklikleri engellemez. Otomatik düzenlemeleri önlemek için [parolalar ve şifreleme](/slides/tr/python-java/password-protected-presentation/) kullanın.  

**'Read-Only recommended' aşağıdaki yöntemlerle nasıl ilişkilidir: [isEncrypted](https://reference.aspose.com/slides/tr/python-java/aspose.slides/protectionmanager/#isEncrypted) ve [isWriteProtected](https://reference.aspose.com/slides/tr/python-java/aspose.slides/protectionmanager/#isWriteProtected)?**  
Bunlar farklı sinyallerdir. ‘Read-Only recommended’ yumuşak, isteğe bağlı bir öneridir; [isWriteProtected] ve [isEncrypted] ise parolalar veya şifreleme gerektiren gerçek yazma veya okuma kısıtlamalarını gösterir.