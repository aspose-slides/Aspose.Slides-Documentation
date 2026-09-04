---
title: Python'da Sunumları Şifre ile Koruma
linktitle: Şifre Koruması
type: docs
weight: 20
url: /tr/python-net/password-protected-presentation/
keywords:
- şifre korumalı sunum
- açma şifresi
- PowerPoint şifreleme
- PowerPoint şifre çözme
- sunum şifresi doğrulama
- sunum şifresi kontrolü
- şifreli sunumu açma
- şifreyi kaldırma
- PowerPoint
- PPT
- PPTX
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides ile Python'da şifre korumalı PowerPoint PPT ve PPTX sunumlarını şifreleyin, tespit edin, doğrulayın, açın ve şifresini çözün."
---
## **Genel Bakış**

Bir açma şifresi bir sunumu şifreler. Sunum içeriğini yüklemek ve görüntülemek için doğru şifre gereklidir, bu koruma gizliliği sağlar.

Bir açma şifresi, yazma koruma şifresinden farklıdır. Yazma koruması, değişikliği kısıtlar ancak içeriği şifrelemez veya sunumun yüklenmesini engellemez. Sunumları değiştirmek için şifreleri yönetmek için [Write-Protect Presentations](/slides/tr/python-net/write-protected-presentation/) bölümüne bakın.

Aşağıdaki iş akışları hem PPT hem de PPTX sunumlarına uygulanır. Örneklerde, dosya tabanlı ve akış tabanlı davranışın önemli olduğu her iki format da kullanılmıştır.

## **Açma Şifresiyle Sunum Şifreleme**

[ProtectionManager.encrypt](https://reference.aspose.com/slides/tr/python-net/aspose.slides/protectionmanager/encrypt/) yöntemiyle bir açma şifresi atayın. Ardından şifrelenmiş sunumu kalıcı hale getirmek için [Presentation.save](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/save/) kullanın.

Aşağıdaki örnek bir PPTX sunumunu şifreler:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Belge Özelliklerini Genel Tutun**

Varsayılan olarak, Aspose.Slides belge özelliklerini sunum şifrelemesine dahil eder. [ProtectionManager.encrypt_document_properties] özelliği bu davranışı slayt içeriği şifrelemesinden bağımsız olarak kontrol eder. Açma şifresi olmadan indeksleme, sınıflandırma, arama veya belge yönetim sistemi meta verileri okuması gerektiğinde [ProtectionManager.encrypt] çağırmadan önce bu özelliği `False` olarak ayarlayın.

Aşağıdaki örnek, yerleşik belge özelliklerini genel tutarken şifrelenmiş bir PPTX sunumu oluşturur:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    properties = presentation.document_properties
    properties.author = "Contoso Knowledge Management"
    properties.title = "Quarterly Product Roadmap"
    properties.keywords = "roadmap, planning, internal"

    presentation.slides[0].name = "Encrypted presentation content"
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", slides.export.SaveFormat.PPTX)
```

`encrypt_document_properties` özelliğini `False` olarak ayarlamak slaytları, masterları, düzenleri, şekilleri, medyayı veya diğer sunum içeriğini genel yapmaz. Yalnızca belge özelliklerini etkiler. Şifrelenmiş içeriği yüklemeden bu özellikleri okumak için [Manage Presentation Properties](/slides/tr/python-net/presentation-properties/) bölümüne bakın.

## **Şifreli Sunumu Yükleme**

[LoadOptions.password] özelliğini açma şifresine ayarlayın ve dosya yüklenirken bu seçenekleri [Presentation] nesnesine iletin. Açma şifresi gerekli ancak sağlanan şifre eksik ya da yanlış olduğunda yükleme başarısız olur.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # Şifrelenmiş sunumla çalış.
    pass
```

## **Sunumdan Şifreyi Kaldırma**

Sunumu açma şifresiyle yükleyin, [ProtectionManager.remove_encryption] metodunu çağırın ve sonucu kaydedin. Kaydedilen sunum daha sonra şifre olmadan yüklenebilir.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Yüklemeden Önce Açma Şifresini Doğrulama**

[PresentationFactory.get_presentation_info] yöntemini kullanarak tam bir sunum örneği oluşturmadan [PresentationInfo] elde edin. Şifre talep etmeden veya doğrulamadan önce [PresentationInfo.is_password_protected] durumunu kontrol edin. Koruma mevcut ise sağlanan değeri [PresentationInfo.check_password] ile doğrulayın.

### **Dosya Yolu İş Akışı**

Aşağıdaki örnek bir PPTX dosyası için açma şifresini doğrular, doğrulanan değeri [LoadOptions.password] öğesine geçirir ve ardından tam sunumu yükler:

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

[PresentationFactory.get_presentation_info] yönteminin akış aşırı yüklemesi aynı iş akışını sağlar. O akıştan tam sunumu yüklemeden önce arama yapılabilir bir akışın konumunu sıfırlayın.

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

### **CheckPassword Döndürdüğü Değerler**

[PresentationInfo.check_password] yalnızca sunumda bir açma şifresi bulunduğunda ve sağlanan şifre doğru olduğunda `True` döndürür. Aşağıdaki durumlarda `False` döner:

- Şifre yanlıştır.
- Sunumun bir açma şifresi yoktur.
- Sağlanan şifre `None` ya da boş.

Davranış PPT ve PPTX sunumları için aynı şekildedir.

## **Yüklenmiş Sunumun Şifreli Olup Olmadığını Kontrol Etme**

Doğru şifreyle bir sunumu yükledikten sonra kaynak sunumun şifrelenip şifrelenmediğini doğrulamak için [ProtectionManager.is_encrypted] özelliğine bakın. Yüklemeden önce açma şifresi korumasını tespit etmek için yukarıda gösterildiği gibi `PresentationInfo.is_password_protected` kullanın.

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
Açma şifrelerini günlüğe kaydetmeyin ve tanı mesajlarına eklemeyin. Gereksiz tekrar doğrulama girişimlerinden kaçının, şifreleri yalnızca gerektiği sürece bellekte tutun ve sunumu hemen yüklerken başarılı bir doğrulama sonucunu yeniden kullanın.

Genel belge özellikleri, sunum içeriği şifreli olsa bile yazar adları, başlıklar, konular, anahtar kelimeler, şirket bilgileri, yorumlar ve özel değerleri ifşa edebilir. Hassas meta verileri sunumla birlikte şifreleyin. Özellikleri genel bırakmak, yalnızca sistemlerin dosyayı açma şifresi olmadan indekslemesi, sınıflandırması, araması veya yönetmesi gerektiğinde alınan açık bir karar olmalıdır.
{{% /alert %}}

## **Sunumu Çevrimiçi Şifreleme**

1. [Aspose.Slides Lock] uygulamasını açın.
2. Sunumu seçin veya yükleyin.
3. Görünüm koruması için bir şifre girin.
4. İsterseniz düzenleme koruması için ayrı bir şifre girin.
5. Koruma uygulayın ve ortaya çıkan dosyayı indirin.

{{% alert color="info" title="Ayrıca Bakınız" %}}
- [Write-Protect Presentations](/slides/tr/python-net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/tr/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Açma şifresi ile yazma koruma şifresi arasındaki fark nedir?**

Bir açma şifresi sunumu şifreler ve içeriğini yüklemek için gereklidir. Yazma koruma şifresi, içeriği şifrelemeden değişikliği kısıtlar.

**Tüm slaytları yüklemeden açma şifresini doğrulayabilir miyim?**

Evet. Sunum bilgilerini edinin, açma şifresi korumasının mevcut olup olmadığını kontrol edin ve tam bir sunum örneği oluşturmadan önce şifreyi doğrulayın.

**Bir uygulama açma şifresi olmadan meta verileri okuyabilir mi?**

Evet, ancak yalnızca sunum `encrypt_document_properties` özelliği `False` olarak ayarlanarak şifrelendiğinde. Uygulama daha sonra [Manage Presentation Properties](/slides/tr/python-net/presentation-properties/) bölümünde açıklanan yalnızca belge özelliklerini yükleme modunu kullanmalıdır.

**Şifre kontrol iş akışları PPT ve PPTX'i destekliyor mu?**

Evet. Dosya yolu ve akış tabanlı şifre tespiti ve doğrulama, PPT ve PPTX sunumları için aynı şekilde çalışır.