---
title: Python'da Sunumları Şifreyle Koruma
linktitle: Şifre Koruma
type: docs
weight: 20
url: /tr/python-net/password-protected-presentation/
keywords:
- şifre korumalı sunum
- açılış şifresi
- PowerPoint şifreleme
- PowerPoint şifre çözme
- sunum şifresi doğrulama
- sunum şifresi kontrolü
- şifreli sunumu açma
- şifrelemeyi kaldırma
- PowerPoint
- PPT
- PPTX
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides ile Python'da şifre korumalı PowerPoint PPT ve PPTX sunumlarını şifreleyin, tespit edin, doğrulayın, açın ve şifresini çözün."
---
## **Genel Bakış**

Açılış şifresi bir sunumu şifreler. Sunum içeriğini yüklemek ve görüntülemek için doğru şifre gerekir; bu koruma gizliliği sağlar.

Açılış şifresi, yazma koruma şifresinden farklıdır. Yazma koruması düzenlemeyi kısıtlar ancak içeriği şifrelemez veya sunumun yüklenmesini engellemez. Sunumları düzenlemek için şifreleri yönetmek istiyorsanız, [Yazma Koruma Sunumları](/slides/tr/python-net/write-protected-presentation/) bölümüne bakın.

Aşağıdaki iş akışları PPT ve PPTX sunumları için geçerlidir. Örneklerde, dosya tabanlı ve akış tabanlı davranışların önemli olduğu durumlarda her iki format da kullanılmıştır.

## **Açılış Şifresi ile Sunumu Şifreleme**

Açılış şifresi atamak için [ProtectionManager.encrypt](https://reference.aspose.com/slides/tr/python-net/aspose.slides/protectionmanager/encrypt/) yöntemini kullanın. Ardından şifrelenmiş sunumu kalıcı hale getirmek için [Presentation.save](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/save/) yöntemini çağırın.

Aşağıdaki örnek bir PPTX sunumunu şifreler:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Şifreli Sunumu Yükleme**

Açılış şifresini ayarlamak için [LoadOptions.password](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/password/) özelliğini belirleyin ve dosyayı yüklerken bu seçenekleri [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) yapıcısına iletin. Açılış şifresi gerekli olduğunda ancak sağlanan şifre eksik veya hatalıysa yükleme başarısız olur.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # Şifre çözülmüş sunumla çalış.
    pass
```

## **Sunumdan Şifrelemeyi Kaldırma**

Sunumu açılış şifresi ile yükleyin, [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/tr/python-net/aspose.slides/protectionmanager/remove_encryption/) yöntemini çağırın ve sonucu kaydedin. Kaydedilen sunum daha sonra şifre gerektirmeden yüklenebilir.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Yüklemeden Önce Açılış Şifresini Doğrulama**

Tam bir sunum örneği oluşturmadan [PresentationInfo](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/) elde etmek için [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationfactory/get_presentation_info/) yöntemini kullanın. Şifre talep edilmeden veya doğrulanmadan önce [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/is_password_protected/) özelliğini kontrol edin. Koruma mevcutsa, sağlanan değeri [PresentationInfo.check_password](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/check_password/) ile doğrulayın.

### **Dosya Yolu İş Akışı**

Aşağıdaki örnek bir PPTX dosyası için açılış şifresini doğrular, doğrulanan değeri [LoadOptions.password](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/password/) özelliğine geçirir ve ardından tam sunumu yükler:

```python
import aspose.slides as slides

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)

if not presentation_info.is_password_protected:
    print("The presentation does not have an opening password.")
elif not presentation_info.check_password(password):
    print("The opening password is incorrect.")
else:
    load_options = slides.LoadOptions()
    load_options.password = password

    with slides.Presentation(file_path, load_options) as presentation:
        print("The presentation was validated and loaded successfully.")
```

### **Akış İş Akışı**

[PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationfactory/get_presentation_info/) metodunun akış aşırı yüklemesi aynı iş akışını sağlar. Tam sunumu bu akıştan yüklemeden önce, konumunu yeniden ayarlamayı unutmayın.

Aşağıdaki örnek bir PPT dosyası kullanır:

```python
import aspose.slides as slides

password = "open_password"

with open("protected-presentation.ppt", "rb") as presentation_stream:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(presentation_stream)

    if not presentation_info.is_password_protected:
        print("The presentation does not have an opening password.")
    elif not presentation_info.check_password(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.seek(0)
        load_options = slides.LoadOptions()
        load_options.password = password

        with slides.Presentation(presentation_stream, load_options) as presentation:
            print("The presentation was validated and loaded successfully.")
```

### **CheckPassword Dönüş Değerleri**

[PresentationInfo.check_password](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/check_password/) yalnızca sunumda bir açılış şifresi bulunduğunda ve sağlanan şifre doğru olduğunda `True` döndürür. Aşağıdaki durumlarda `False` döner:

- Şifre yanlış.
- Sunumda açılış şifresi yok.
- Sağlanan şifre `None` ya da boş.

Davranış PPT ve PPTX sunumları için aynı şekildedir.

## **Yüklenen Sunumun Şifreli Olup Olmadığını Kontrol Etme**

Doğru şifreyle bir sunum yüklendikten sonra, kaynağın şifreli olduğunu doğrulamak için [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/tr/python-net/aspose.slides/protectionmanager/is_encrypted/) özelliğine bakın. Yüklemeden önce açılış‑şifresi korumasını tespit etmek için yukarıda gösterildiği gibi `PresentationInfo.is_password_protected` kullanılabilir.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **Güvenlik Önerileri**

{{% alert color="warning" title="Güvenlik" %}}
Açılış şifrelerini günlük dosyalarına kaydetmeyin ve tanı mesajlarında göstermeyin. Gereksiz tekrar doğrulama girişimlerinden kaçının, şifreleri yalnızca gerektiği süre boyunca bellekte tutun ve sunumu hemen yüklemeniz gerektiğinde başarılı bir doğrulama sonucunu yeniden kullanın.
{{% /alert %}}

## **Sunumu Çevrimiçi Şifreleme**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/tr/lock) uygulamasını açın.  
2. Sunumu seçin veya yükleyin.  
3. Görüntü koruması için bir şifre girin.  
4. İsterseniz düzenleme koruması için ayrı bir şifre daha girin.  
5. Koruma uygulayın ve oluşturulan dosyayı indirin.

{{% alert color="info" title="Ayrıca Bakınız" %}}
- [Yazma Koruma Sunumları](/slides/tr/python-net/write-protected-presentation/)  
- [PowerPoint'te Dijital İmza](/slides/tr/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Açılış şifresi ile yazma koruma şifresi arasındaki fark nedir?**

Açılış şifresi sunumu şifreler ve içeriğin yüklenmesi için gereklidir. Yazma koruma şifresi ise içeriği şifrelemez, yalnızca düzenlemeyi kısıtlar.

**Tüm slaytları yüklemeden bir açılış şifresini doğrulayabilir miyim?**

Evet. Sunum bilgilerini alın, açılış‑şifresi korumasının mevcut olup olmadığını kontrol edin ve tam bir sunum örneği oluşturulmadan şifreyi doğrulayın.

**Şifre kontrol iş akışları hem PPT hem de PPTX için destekleniyor mu?**

Evet. Dosya‑yolu ve akış‑tabanlı şifre algılama ve doğrulama, PPT ve PPTX sunumları için aynı şekilde çalışır.