---
title: Python'da Sunumları Yazma Koruması ile Korumak
linktitle: Yazma Koruması
type: docs
weight: 25
url: /tr/python-java/write-protected-presentation/
keywords:
- yazma koruması
- PowerPoint'i yazma korumalı
- değiştirme parolası
- sunum düzenlemeyi kısıtlama
- yazma korumasını kaldırma
- değişiklik parolasını doğrulama
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PowerPoint PPT ve PPTX sunumlarında yazma koruma parolalarını ayarlama, tespit etme, doğrulama ve kaldırma."
---
## **Giriş**

Yazma koruma parolası bir sunumun değiştirilmesini kısıtlar ancak içeriğini şifrelemez. Kullanıcılar, yazma korumalı bir sunumu parolasız olarak yükleyebilir ve görüntüleyebilir. Uygulamaya bağlı olarak içeriği düzenleyebilir ve farklı bir adla kaydedebilirler; bu nedenle yazma koruması gizlilik mekanizması olarak ele alınmamalıdır.

Açma parolası farklı bir amaca hizmet eder: sunumu şifreler ve içeriğini yüklemek için gereklidir. Bir sunumu şifrelemek veya açma parolasını doğrulamak için, bakınız [Sunumları Parola ile Koruma](/slides/tr/python-java/password-protected-presentation/).

Bu makaledeki iş akışları hem PPT hem de PPTX sunumları için geçerlidir. Örnekler PPTX dosyalarını kullanır; PPT olarak kaydederken `.ppt` uzantısını ve ilgili PPT kaydetme formatını kullanın.

## **Sunuma Yazma Koruması Ayarlama**

Bir sunumu değiştirmek için bir parola atamak üzere [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/protectionmanager/#setWriteProtection) kullanın. Sunumu kaydetmek koruma ayarını kalıcı hale getirir.

Aşağıdaki örnek bir PPTX sunumuna yazma koruması ekler:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().setWriteProtection("modify_password")
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Yazma Koruması Olan Bir Sunumu Yükleme**

Yazma koruması sunum içeriğini şifrelemediği için sunumu yüklemek için parola gerekmez. Parola yalnızca korumalı sunumu değiştirme yetkisinin doğrulanmasında ilgilidir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("write-protected-pres.pptx")
try:
    print("Slide count: " + str(presentation.getSlides().size()))
finally:
    presentation.dispose()
```

Yazma koruma parolasını [LoadOptions.setPassword](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setPassword) metoduna geçirmeyin. Bu yöntem şifreli içerik için bir açma parolası kabul eder. Bir sunum her iki koruma türüne de sahipse, açma parolasını sunumu yüklemek için sağlayın ve yazma koruma parolasını ayrı olarak işleyin.

## **Sunumdan Yazma Korumasını Kaldırma**

Değişiklik kısıtlamasını kaldırmak ve ardından sunumu kaydetmek için [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/protectionmanager/#removeWriteProtection) kullanın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("write-protected-pres.pptx")
try:
    presentation.getProtectionManager().removeWriteProtection()
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bir Sunumun Yazma Koruması Olup Olmadığını Kontrol Etme**

Tam bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneği oluşturmadan bir dosyayı incelemek için [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationfactory/#getPresentationInfo) metodunu çağırın ve [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/#isWriteProtected) özelliğini kontrol edin. Metot [NullableBool](https://reference.aspose.com/slides/tr/python-java/aspose.slides/nullablebool/) kullanır ve yazma koruması tespit edildiğinde `NullableBool.True_` döndürür.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() == NullableBool.True_:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationfactory/#getPresentationInfo) metodunun akış aşırı yüklemesi, akış olarak sağlanan bir sunum için aynı bilgileri verir.

## **Yazma Koruma Parolasını Doğrulama**

Tam bir sunumu yüklemeden bir değiştirme parolasını doğrulamak için [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/#checkWriteProtection) kullanın. Uygulamanın yalnızca yazma koruması mevcut olduğunda parolayı isteyebilmesi veya doğrulayabilmesi için önce [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/#isWriteProtected) kontrol edin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() != NullableBool.True_:
    print("The presentation is not write protected.")
elif presentation_info.checkWriteProtection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/#checkWriteProtection) yalnızca yazma koruma parolasını doğrular. Açma parolasını doğrulamaz ve şifreli içeriğin yüklenip yüklenemeyeceğini belirlemez. Aksine, [PresentationInfo.checkPassword](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/#checkPassword) yalnızca açma parolasını doğrular. Tam bir sunum zaten yüklendiyse, [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/protectionmanager/#checkWriteProtection) koruma yöneticisi aracılığıyla eşdeğer yazma koruma kontrolünü sağlar.

Üretim uygulamalarında parolaları günlüklemek veya tanı mesajlarına eklemekten kaçının. Gereksiz tekrar doğrulama girişimlerinden kaçının ve parolaları yalnızca ihtiyaç duyulduğu sürece bellekte tutun.

{{% alert color="info" title="Ayrıca bakınız" %}}
- [Sunumları Parola ile Koruma](/slides/tr/python-java/password-protected-presentation/)
- [Salt Okunur Sunumlar](/slides/tr/python-java/read-only-presentation/)
- [PowerPoint'te Dijital İmza](/slides/tr/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Yazma koruması bir sunumu şifreler mi?**

Hayır. Değişikliği kısıtlar ancak sunum içeriği yükleme ve görüntüleme için kullanılabilir bırakır.

**Sunumu açmak için yazma koruma parolası gerekli mi?**

Hayır. Yalnızca şifreli sunum içeriğini yüklemek için bir açma parolası gerekir.

**Bir sunum hem açma parolası hem de yazma koruma parolası içerebilir mi?**

Evet. Şifreli sunumu açmak için açma parolasını yükleme seçenekleri aracılığıyla sağlayın ve değişiklik yetkisi gerektiğinde yazma koruma parolasını ayrı olarak doğrulayın.