---
title: Python'da Sunumları Yazma Koruması
linktitle: Yazma Koruması
type: docs
weight: 25
url: /tr/python-net/write-protected-presentation/
keywords:
- yazma koruması
- PowerPoint'i yazma koruması
- değiştirme parolası
- sunum düzenlemesini kısıtlama
- yazma korumasını kaldırma
- değiştirme parolasını doğrulama
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python kullanarak PowerPoint PPT ve PPTX sunumlarında yazma koruma parolalarını ayarlama, tespit etme, doğrulama ve kaldırma."
---
## **Giriş**

Yazma koruma parolası bir sunumun değiştirilmesini kısıtlar ancak içeriğini şifrelemez. Kullanıcılar, yazma korumalı bir sunumu parolası olmadan yükleyip görüntüleyebilir. Uygulamaya bağlı olarak içeriği düzenleyip farklı bir adla kaydedebilirler, bu yüzden yazma koruması gizlilik mekanizması olarak değerlendirilmemelidir.

Açma parolası farklı bir amaç taşır: sunumu şifreler ve içeriğini yüklemek için gereklidir. Bir sunumu şifrelemek veya açma parolasını doğrulamak için bkz. [Parola ile Sunumları Koruma](/slides/tr/python-net/password-protected-presentation/).

Bu makaledeki iş akışları PPT ve PPTX sunumlarının her ikisine de uygulanır. Örnekler PPTX dosyalarını kullanır; PPT olarak kaydederken `.ppt` uzantısını ve ilgili PPT kaydetme biçimini kullanın.

## **Sunuma Yazma Koruması Ayarlama**

Bir sunumu değiştirmek için bir parola atamak üzere [ProtectionManager.set_write_protection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/protectionmanager/set_write_protection/) kullanın. Sunumu kaydetmek koruma ayarını kalıcı hâle getirir.

Aşağıdaki örnek bir PPTX sunumuna yazma koruması ekler:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.set_write_protection("modify_password")
    presentation.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Yazma Koruması Olan Sunumu Yükleme**

Yazma koruması sunum içeriğini şifrelemediği için sunumu yüklemek için parola gerekmez. Parola yalnızca korumalı sunumu değiştirme yetkisini doğrularken önemlidir.

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Yazma koruma parolasını [LoadOptions.password](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/password/) adresine geçirmeyin. Bu özellik şifreli içerik için bir açma parolası kabul eder. Sunum her iki koruma tipine de sahipse, yüklemek için açma parolasını sağlayın ve yazma koruma parolasını ayrı olarak işleyin.

## **Sunumdan Yazma Korumasını Kaldırma**

Değiştirme sınırlamasını kaldırmak için [ProtectionManager.remove_write_protection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/protectionmanager/remove_write_protection/) kullanın, ardından sunumu kaydedin.

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    presentation.protection_manager.remove_write_protection()
    presentation.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Sunumun Yazma Koruması Olup Olmadığını Kontrol Etme**

Tam bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturmadan bir dosyayı incelemek için [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationfactory/get_presentation_info/) çağırın ve [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/is_write_protected/) özelliğini kontrol edin. Bu özellik [NullableBool](https://reference.aspose.com/slides/tr/python-net/aspose.slides/nullablebool/) kullanır ve yazma koruması tespit edildiğinde `NullableBool.TRUE` döndürür.

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected == slides.NullableBool.TRUE:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

[PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationfactory/get_presentation_info/) metodunun akış aşırı yüklemesi, akış olarak sağlanan bir sunum için aynı bilgiyi verir.

## **Yazma Koruma Parolasını Doğrulama**

Tam bir sunumu yüklemeden bir değiştirme parolasını doğrulamak için [PresentationInfo.check_write_protection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/check_write_protection/) kullanın. Uygulamanın yalnızca yazma koruması mevcut olduğunda parola isteyebilmesi veya doğrulayabilmesi için önce [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/is_write_protected/) kontrol edin.

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected != slides.NullableBool.TRUE:
    print("The presentation is not write protected.")
elif presentation_info.check_write_protection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.check_write_protection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/check_write_protection/) yalnızca yazma koruma parolasını doğrular. Açma parolasını doğrulamaz veya şifreli içeriğin yüklenip yüklenemeyeceğini belirlemez. Buna karşılık, [PresentationInfo.check_password](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/check_password/) yalnızca bir açma parolasını doğrular. Eğer tam bir sunum zaten yüklenmişse, [ProtectionManager.check_write_protection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/protectionmanager/check_write_protection/) koruma yöneticisi aracılığıyla eşdeğer bir yazma koruma kontrolü sağlar.

Üretim uygulamalarında parolaları loglamayın veya tanı mesajlarına eklemeyin. Gereksiz tekrar doğrulama girişimlerinden kaçının ve parolaları yalnızca gerektiği sürece bellekte tutun.

{{% alert color="info" title="Ayrıca bakınız" %}}
- [Parola ile Sunumları Koruma](/slides/tr/python-net/password-protected-presentation/)
- [Yalnızca Okunabilir Sunumlar](/slides/tr/python-net/read-only-presentation/)
- [PowerPoint'te Dijital İmza](/slides/tr/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Yazma koruması bir sunumu şifreler mi?**

Hayır. Değiştirmeyi kısıtlar ancak sunum içeriğini yükleme ve görüntüleme için erişilebilir tutar.

**Sunumu açmak için yazma koruma parolasına ihtiyaç var mı?**

Hayır. Şifreli sunum içeriğini yüklemek için yalnızca açma parolasına ihtiyaç vardır.

**Bir sunum hem açma parolasına hem de yazma koruma parolasına sahip olabilir mi?**

Evet. Şifreli sunumu açmak için yükleme seçenekleri aracılığıyla açma parolasını sağlayın ve değişiklik yetkisi gerektiğinde yazma koruma parolasını ayrı olarak doğrulayın.