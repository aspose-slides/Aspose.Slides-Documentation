---
title: "Python'da Sunumları Parola ile Korumak"
linktitle: "Parola Koruması"
type: docs
weight: 20
url: /tr/python-java/password-protected-presentation/
keywords:
- parola korumalı sunum
- açılış parolası
- PowerPoint şifreleme
- PowerPoint şifre çözme
- sunum parolasını doğrulama
- sunum parolasını kontrol et
- şifreli sunumu aç
- şifrelemeyi kaldır
- PowerPoint
- PPT
- PPTX
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile parola korumalı PowerPoint PPT ve PPTX sunumlarını şifreleyin, tespit edin, doğrulayın, açın ve şifrelerini çözün."
---
## **Genel Bakış**

Açılış parolası bir sunumu şifreler. Sunum içeriğini yüklemek ve görüntülemek için doğru parola gereklidir; bu koruma gizliliği sağlar.

Açılış parolası, yazma koruması parolasından farklıdır. Yazma koruması, değiştirmeyi kısıtlar ancak içeriği şifrelemez veya sunumun yüklenmesini engellemez. Sunumları değiştirmek için parolaları yönetmek amacıyla, [Write-Protect Presentations](/slides/tr/python-java/write-protected-presentation/) bölümüne bakın.

Aşağıdaki iş akışları hem PPT hem de PPTX sunumları için geçerlidir. Örnekler, dosya tabanlı ve akış tabanlı davranışlarının önemli olduğu her iki formatı da kullanır.

## **Açılış Parolasıyla Sunumu Şifrele**

Açılış parolası atamak için [ProtectionManager.encrypt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/protectionmanager/#encrypt) kullanın. Ardından şifreli sunumu kalıcı hâle getirmek için [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) yöntemini kullanın.

Aşağıdaki örnek bir PPTX sunumunu şifreler:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Belge Özelliklerini Genel Tut**

Varsayılan olarak, Aspose.Slides belge özelliklerini sunum şifrelemesine dahil eder. Bu davranışı slayt içeriği şifrelemesinden bağımsız olarak kontrol eden yöntem [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties)’dir. Açılış parolası olmadan indeksleme, sınıflandırma, arama veya belge yönetim sistemlerinin meta verileri okuması gerektiğinde, [ProtectionManager.encrypt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/protectionmanager/#encrypt) çağırmadan önce `False` geçin.

Aşağıdaki örnek, yerleşik belge özelliklerini genel tutarak şifreli bir PPTX sunumu oluşturur:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    properties = presentation.getDocumentProperties()
    properties.setAuthor("Contoso Knowledge Management")
    properties.setTitle("Quarterly Product Roadmap")
    properties.setKeywords("roadmap, planning, internal")

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content")
    presentation.getProtectionManager().setEncryptDocumentProperties(False)
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`False` değerinin [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) yöntemine geçirilmesi slaytları, ana sayfaları, düzenleri, şekilleri, medyayı veya diğer sunum içeriğini genel hale getirmez. Bu yalnızca belge özelliklerini etkiler. Şifreli içeriği yüklemeden bu özellikleri okumak için, [Manage Presentation Properties](/slides/tr/python-java/presentation-properties/) bölümüne bakın.

## **Şifreli Bir Sunumu Yükle**

Dosyayı yüklerken açılış parolasını [LoadOptions.setPassword](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setPassword) ile ayarlayın ve bu seçenekleri [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) nesnesine geçirin. Açılış parolası gerekli olduğunda ancak sağlanan parola eksik ya da hatalıysa yükleme başarısız olur.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    # Şifre çözülmüş sunumla çalış.
    pass
finally:
    presentation.dispose()
```

## **Bir Sunumdan Şifrelemeyi Kaldır**

Sunumu açılış parolasıyla yükleyin, [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/tr/python-java/aspose.slides/protectionmanager/#removeEncryption) yöntemini çağırın ve sonucu kaydedin. Kaydedilen sunum daha sonra parola olmadan yüklenebilir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    presentation.getProtectionManager().removeEncryption()
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Yüklemeden Önce Açılış Parolasını Doğrula**

[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationfactory/#getPresentationInfo) kullanarak tam bir sunum örneği oluşturmadan [PresentationInfo](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/) elde edin. Parola istemeden veya doğrulamadan önce [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/#isPasswordProtected) özelliğini kontrol edin. Koruma mevcutsa, sağlanan değeri [PresentationInfo.checkPassword](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/#checkPassword) ile doğrulayın.

### **Dosya Yolu İş Akışı**

Aşağıdaki örnek, bir PPTX dosyası için açılış parolasını doğrular, doğrulanan değeri [LoadOptions.setPassword](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setPassword)’e geçirir ve ardından tam sunumu yükler:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)

if not presentation_info.isPasswordProtected():
    print("The presentation does not have an opening password.")
elif not presentation_info.checkPassword(password):
    print("The opening password is incorrect.")
else:
    load_options = LoadOptions()
    load_options.setPassword(password)

    presentation = Presentation(file_path, load_options)
    try:
        print("The presentation was validated and loaded successfully.")
    finally:
        presentation.dispose()
```

### **Akış İş Akışı**

[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationfactory/#getPresentationInfo) yönteminin akış aşırı yüklemesi aynı iş akışını sağlar. Tam sunumu o akıştan yüklemeden önce, aranabilir bir akışın konumunu sıfırlayın.

Aşağıdaki örnek bir PPT dosyası kullanır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

FileInputStream = jpype.JClass("java.io.FileInputStream")

password = "open_password"

presentation_stream = FileInputStream("protected-presentation.ppt")
try:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(presentation_stream)

    if not presentation_info.isPasswordProtected():
        print("The presentation does not have an opening password.")
    elif not presentation_info.checkPassword(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.getChannel().position(0)

        load_options = LoadOptions()
        load_options.setPassword(password)

        presentation = Presentation(presentation_stream, load_options)
        try:
            print("The presentation was validated and loaded successfully.")
        finally:
            presentation.dispose()
finally:
    presentation_stream.close()
```

### **checkPassword Dönüş Değerleri**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/#checkPassword) yalnızca sunumda bir açılış parolası varsa ve sağlanan parola doğruysa `True` döndürür. Aşağıdaki durumlarda `False` döndürür:

- Parola yanlıştır.
- Sunumun bir açılış parolası yoktur.
- Sağlanan parola `None` veya boştur.

Davranış PPT ve PPTX sunumları için aynı olur.

## **Yüklenen Sunumun Şifrelenip Şifrelenmediğini Kontrol Et**

Doğru parola ile bir sunumu yükledikten sonra, kaynak sunumun şifrelenip şifrelenmediğini doğrulamak için [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/tr/python-java/aspose.slides/protectionmanager/#isEncrypted) öğesini inceleyin. Yüklemeden önce açılış parolası korumasını tespit etmek için, yukarıda gösterildiği gibi [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/#isPasswordProtected) yöntemini kullanın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    is_encrypted = presentation.getProtectionManager().isEncrypted()
    print(f"The presentation is encrypted: {is_encrypted}")
finally:
    presentation.dispose()
```

## **Güvenlik Önerileri**
{{% alert color="warning" title="Güvenlik" %}}
Açılış parolalarını loglamayın ve tanı mesajlarında bulunmasına izin vermeyin. Gereksiz tekrar doğrulama girişimlerinden kaçının, parolaları yalnızca gerekli olduğu sürece bellekte tutun ve sunumu hemen yüklerken başarılı bir doğrulama sonucunu yeniden kullanın.

Genel belge özellikleri, sunum içeriği şifrelenmiş olsa bile yazar adlarını, başlıkları, konuları, anahtar kelimeleri, şirket bilgilerini, yorumları ve özel değerleri ortaya çıkarabilir. Hassas meta verileri sunumla birlikte şifreleyin. Özelliklerin genel bırakılması, yalnızca sistemlerin dosyayı bir açılış parolası olmadan indekslemesi, sınıflandırması, araması veya yönetmesi gerektiğinde alınacak açık bir karar olmalıdır.
{{% /alert %}}

## **Sunumu Çevrimiçi Parola Korumalı Hale Getir**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/tr/lock) uygulamasını açın.
1. Sunumu seçin veya yükleyin.
1. Görünüm koruması için bir parola girin.
1. İsteğe bağlı olarak düzenleme koruması için ayrı bir parola girin.
1. Koruması uygulayın ve ortaya çıkan dosyayı indirin.

{{% alert color="info" title="İlgili" %}}
- [Sunumları Yazma Korumasıyla Koru](/slides/tr/python-java/write-protected-presentation/)
- [PowerPoint’te Dijital İmza](/slides/tr/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Açılış parolası ile yazma koruması parolası arasındaki fark nedir?**

Açılış parolası sunumu şifreler ve içeriğini yüklemek için gereklidir. Yazma koruması parolası ise içeriği şifrelemeden değişikliği kısıtlar.

**Tüm slaytları yüklemeden bir açılış parolasını doğrulayabilir miyim?**

Evet. Sunum bilgilerini alın, açılış parolası korumasının mevcut olup olmadığını kontrol edin ve tam bir sunum örneği oluşturmadan önce parolayı doğrulayın.

**Bir uygulama açılış parolası olmadan meta verileri okuyabilir mi?**

Evet, ancak yalnızca sunum belge‑özelliği şifrelemesi devre dışı bırakılarak şifrelenmişse. Uygulama o zaman [Manage Presentation Properties](/slides/tr/python-java/presentation-properties/) bölümünde açıklanan yalnızca belge özelliklerini yükleme modunu kullanmalıdır.

**Parola kontrol iş akışları hem PPT hem PPTX’i destekliyor mu?**

Evet. Dosya yolu ve akış tabanlı parola tespiti ve doğrulaması, PPT ve PPTX sunumları için aynı şekilde çalışır.