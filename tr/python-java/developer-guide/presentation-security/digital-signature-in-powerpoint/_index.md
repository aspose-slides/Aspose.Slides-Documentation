---
title: Python'da Sunumalara Dijital İmzalar Ekleme
linktitle: Dijital İmza
type: docs
weight: 10
url: /tr/python-java/digital-signature-in-powerpoint/
keywords:
- dijital imza
- dijital sertifika
- sertifika yetkilisi
- PFX sertifikası
- PKCS#12
- imza doğrulama
- PowerPoint
- PPTX
- sunum güvenliği
- Python
- Aspose.Slides
description: "PFX sertifikalarıyla mevcut PPTX sunumlarını nasıl imzalayacağınızı ve Java üzerinden Python için Aspose.Slides kullanarak dijital imzaları doğrulamayı ya da kaldırmayı öğrenin."
---
## **Genel Bakış**

Bir dijital imza, alıcının bir sunumu kim imzaladığını ve imzalı içeriğin değişip değişmediğini belirlemesine yardımcı olur. Burada üç ilgili güvenlik kavramı önemlidir:

- Bir **dijital sertifika**, bir kimliği bir genel anahtarla ilişkilendiren elektronik kimlik bilgisi‑dosyasıdır. Güvenilir bir sertifika yetkilisi (CA) bir sertifika verebilir veya bir kuruluş dahili iş akışları için kendinden imzalı bir sertifika kullanabilir.
- Bir **dijital imza**, sunum içeriği ve sertifika sahibinin özel anahtarı kullanılarak oluşturulur. Sertifikanın genel anahtarı daha sonra imzayı doğrulamak için kullanılabilir. İmza, kaynağın ve bütünlüğün kanıtını sağlar; sunumu şifrelemez.
- **Parola koruması**, bir kullanıcının bir sunumu açıp düzenleyip düzenleyemeyeceğini kontrol eder. Bu, dijital imzalamadan ayrı bir özelliktir ve [Parola Korumalı Sunumlar](/slides/tr/python-java/password-protected-presentation/) bölümünde açıklanmıştır.

PowerPoint, **Dosya > Bilgi > Sunumu Koru** altında **Dijital İmza Ekle** komutunu sunar.

![PowerPoint sunumu koruma menüsü, Dijital İmza Ekle vurgulanmış](add-digital-signature-in-powerpoint.png)

İmzalı bir sunum açıldığında, PowerPoint bir imza‑durum bildirimi gösterebilir.

![PowerPoint bildiriminde sunumun geçerli imzalar içerdiği belirtiliyor](digital-signature-status-in-powerpoint.png)

Aspose.Slides, imzaları [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getDigitalSignatures) aracılığıyla sunar; bu metod, öğeleri [DigitalSignature](https://reference.aspose.com/slides/tr/python-java/aspose.slides/digitalsignature/) örnekleri olan bir [DigitalSignatureCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/digitalsignaturecollection/) döndürür. Bir sunum birden fazla imza içerebilir.

## **PFX Sertifikaları ve Parolaları Anlamak**

PFX dosyası, PKCS#12 dosyası olarak da bilinir ve genellikle `.pfx` veya `.p12` uzantısına sahiptir; bir X.509 sertifikası, onun özel anahtarı ve sertifika zincirini içerebilir. Özel anahtar, sahibine bir imza oluşturma yetkisi verir. Erişilebilir bir özel anahtarı olmayan bir sertifika, bir sunumu imzalamak için kullanılamaz.

PFX parolası, sertifika paketini ve özel anahtarı korur. Bu, sunumu açmak veya düzenlemek için kullanılan bir parola **değildir**. PFX dosyalarını veya parolalarını kaynak kontrol sistemine göndermeyin. Üretim ortamında, sertifika dosyasına erişimi sınırlayın ve parolayı bir gizli depodan ya da başka bir korumalı yapılandırma kaynağından temin edin. Aşağıdaki örneklerde, parolayı koda gömmekten kaçınmak için yalnızca bir ortam değişkeni kullanılmıştır.

## **Bir Sunuma Dijital İmza Ekleme**

Gerçek bir sunum iş akışını imzalamak için, mevcut bir PPTX dosyasını yükleyin, bir PFX sertifikası ve parolasıyla bir [DigitalSignature](https://reference.aspose.com/slides/tr/python-java/aspose.slides/digitalsignature/) oluşturun, imzayı sunumun koleksiyonuna ekleyin ve PPTX dosyası olarak kaydedin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

import os
from asposeslides.api import Presentation, DigitalSignature, SaveFormat

certificate_password = os.environ.get("PFX_PASSWORD")
if not certificate_password:
    print("Set the PFX_PASSWORD environment variable.")
else:
    presentation = Presentation("InputPresentation.pptx")
    try:
        signature = DigitalSignature("signing-certificate.pfx", certificate_password)
        signature.setComments("Approved for release.")

        presentation.getDigitalSignatures().add(signature)
        presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

Sonucu yeni bir ad altında kaydetmek, imzasız kaynak dosyasını korur. [DigitalSignature.setComments](https://reference.aspose.com/slides/tr/python-java/aspose.slides/digitalsignature/#setComments) ile ayarlanan değer, imzanın amacını açıklar; bir güvenlik kontrolü değildir.

## **Dijital İmzaları Doğrulama**

İmzalı bir PPTX dosyasını yüklediğinizde, [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getDigitalSignatures) tarafından döndürülen her öğeyi inceleyin. [DigitalSignature.isValid](https://reference.aspose.com/slides/tr/python-java/aspose.slides/digitalsignature/#isValid) yöntemi, gömülü imzanın geçerli sunum içeriği için geçerli olup olmadığını gösterir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
CertificateFactory = jpype.JClass("java.security.cert.CertificateFactory")
SimpleDateFormat = jpype.JClass("java.text.SimpleDateFormat")

presentation = Presentation("InputPresentation-signed.pptx")
try:
    signatures = presentation.getDigitalSignatures()
    signature_count = signatures.size()

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True
        sign_time_format = SimpleDateFormat("yyyy-MM-dd HH:mm:ss")
        certificate_factory = CertificateFactory.getInstance("X.509")

        for signature in signatures:
            signature_is_valid = signature.isValid()
            signature_status = "VALID" if signature_is_valid else "INVALID"
            sign_time = signature.getSignTime()
            formatted_sign_time = sign_time_format.format(sign_time)

            certificate_data = signature.getCertificate()
            certificate_stream = ByteArrayInputStream(certificate_data)
            certificate = certificate_factory.generateCertificate(certificate_stream)
            signer_principal = certificate.getSubjectX500Principal()
            signer_name = signer_principal.getName()

            print(f"{signer_name}, {formatted_sign_time} -- {signature_status}")

            all_signatures_are_valid = all_signatures_are_valid and signature_is_valid

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
finally:
    presentation.dispose()
```

Geçersiz bir sonuç, genellikle imzalı sunum içeriği ya da imza verisinin imzalama sonrası değiştiği ya da dosyanın bozuk olduğu anlamına gelir. Tüm imzaları kaldırmak, imzasız bir sunum üretir; bu yüzden yalnızca öğelerin geçerliliğini kontrol etmek yeterli değildir: güvenlikle ilgili bir iş akışı, beklenen imza sayısının ve beklenen imzalayan kimliklerinin mevcut olduğunu da doğrulamalıdır.

Bu geçerlilik sonucu, tam bir sertifika‑güveni kararı olarak değerlendirilmemelidir. Güvenlik politikalarınıza bağlı olarak uygulamanız ayrıca X.509 sertifika zincirini oluşturup doğrulamalı, sertifika geçerlilik tarihlerini ve iptal durumunu kontrol etmeli, beklenen konu ya da parmak izini teyit etmeli, anahtar kullanımını doğrulamalı ve güvenilir bir zaman damgasını değerlendirmelidir. [DigitalSignature.getSignTime](https://reference.aspose.com/slides/tr/python-java/aspose.slides/digitalsignature/#getSignTime) değeri tek başına güvenilir bir zaman damgası otoritesinden kanıt oluşturmaz.

## **Dijital İmzaları Kaldırma**

İmzaları kaldırmak, sunumun güvenlik durumunu değiştirir. Aşağıdaki örnek, bir imzalı PPTX dosyasını yükler, tüm imzaları [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/tr/python-java/aspose.slides/digitalsignaturecollection/#clear) ile kaldırır ve imzasız bir kopya kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("InputPresentation-signed.pptx")
try:
    presentation.getDigitalSignatures().clear()
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Yalnızca tek bir imzayı kaldırmak için, sıfır‑tabanlı indeksiyle [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/digitalsignaturecollection/#removeAt) metodunu çağırın. İmzalı orijinali üzerine yazmak, iş akışınızın açık bir parçası değilse, yeni bir dosyaya kaydedin.

## **Düzenleme ve Format Düşünceleri**

- Bir imza, bir sunumu salt‑okunur hâle getirmez. Kullanıcılar ve uygulamalar dosyayı hâlâ düzenleyebilir; ancak imzalı içeriğe yapılan değişiklikler genellikle mevcut imzayı geçersiz kılar.
- İmzalamadan önce tüm istenen düzenlemeleri tamamlayın. Sunumun değiştirilmesi gerekiyorsa, revize edilmiş sunumu kaydedin ve bu revizyonu yeniden imzalayın.
- Son çıktıyı PPTX formatında tutun. İmzalı bir sunumu başka bir formata dönüştürmek, orijinal PPTX imzasını geçerli bir imza olarak dönüştürülmüş dosyaya taşımaz.
- Sertifikanın özel anahtarını hassas bir veri olarak tutun. Özel anahtarı ve parolasını elde eden herkes, o sertifika sahibinden geldiği izlenimini yaratan imzalar oluşturabilir.
- Belge‑saklama politikanız gerektirdiği sürece, imzasız kaynağı ya da kontrol edilen başka bir kopyayı saklayın.

## **SSS**

**Bir dijital imza sunumu şifreler mi?**

Hayır. Dijital imza, kaynağın ve bütünlüğün kanıtını sağlar, ancak sunum içeriği ayrı bir şifreleme uygulanmadıkça okunabilir kalır. İçeriğe erişimin sınırlandırılması gerektiğinde [parola koruma](/slides/tr/python-java/password-protected-presentation/) kullanın.

**PFX parolası sunum parolasıyla aynı mıdır?**

Hayır. PFX parolası, sertifika paketinde saklanan özel anahtarı açar. PPTX dosyasını kimlerin açıp düzenleyebileceğini kontrol etmez.

**Kendinden imzalı bir sertifika kullanabilir miyim?**

Teknik olarak, erişilebilir bir özel anahtar içerdiği sürece kendinden imzalı bir sertifika kullanılabilir. Ancak alıcılar bu sertifikaya otomatik olarak güvenmez; sertifikanın güvenilir ortama açıkça eklenmesi gerekir. Genel ya da kurumlar arası iş akışları genellikle güvenilir bir CA tarafından verilen sertifikaları tercih eder.

**Bir imzayı geçersiz kılan nedir?**

İmzalı sunum içeriğini ya da imza verisini imzalama sonrası değiştirmek imzayı geçersiz kılar. Dosya bozulması da doğrulamanın başarısız olmasına yol açar. Tüm imzalar kaldırılırsa, sunum imzasız olur; geçersiz bir imza taşıyan bir dosya değildir.

**Geçerli bir imza, imzalayan kişiye güvenmem gerektiği anlamına mı gelir?**

Yalnız kendi başına değildir. İmza bütünlüğü ve imzalayan güveni ayrı kararlar gerektirir. Üretim ortamı doğrulama politikası ayrıca sertifika zincirini, geçerlilik süresini, iptal durumunu, beklenen kimliği, anahtar kullanımını ve gerekirse güvenilir bir zaman damgasını kontrol etmelidir.

**Sertifika süresi dolarsa ne olur?**

Sertifikanın süresinin dolması sunumun baytlarını değiştirmez, ancak sertifika‑güveni değerlendirmesini etkiler. Bir imzanın kabul edilebilirliği, politikanıza ve geçerli bir güvenilir zaman damgasının imzalama sırasında sertifikanın geçerli olduğunu kanıtlayıp kanıtlamadığına bağlıdır. Tek başına gösterilen imzalama zamanı, güvenilir bir zaman damgası olarak kullanılmamalıdır.

**İmzalı bir sunum hâlâ düzenlenebilir mi?**

Evet. İmzalama dosyayı kilitlemez. İmzalı içeriği düzenlemek genellikle mevcut imzayı geçersiz kılar; bu yüzden önce sunumu tamamlayıp son revizyonu imzalayın.

**Bir sunum birden fazla imza içerebilir mi?**

Evet. Kaydetmeden önce her imzayı [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getDigitalSignatures) tarafından döndürülen koleksiyona ekleyin. Doğrulama sırasında her imzayı inceleyin ve tüm gerekli imzalayanların mevcut olduğunu doğrulayın.

**Hangi sunum formatları bu işlemleri destekler?**

Aspose.Slides, burada açıklanan dijital‑imza işlemlerini yalnızca PPTX için destekler. PPT ve OpenDocument sunum formatları bu API iş akışı tarafından desteklenmez.

**Bir imzayı silerken slaytlar etkilenir mi?**

Evet. Tek bir imzayı kaldırabilir ya da tüm koleksiyonu temizleyip ardından sunumu kaydedebilirsiniz. Slayt içeriği mevcut kalır, ancak kaydedilen dosya artık kaldırılan imza kanıtını taşımaz.