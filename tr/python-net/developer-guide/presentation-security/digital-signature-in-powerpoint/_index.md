---
title: Python'da Sunumlara Dijital İmzalar Ekleyin
linktitle: Dijital İmza
type: docs
weight: 10
url: /tr/python-net/digital-signature-in-powerpoint/
keywords:
- dijital imza
- dijital sertifika
- sertifika otoritesi
- PFX sertifikası
- PKCS#12
- imza doğrulama
- PowerPoint
- PPTX
- sunum güvenliği
- Python
- Aspose.Slides
description: "PFX sertifikalarıyla mevcut PPTX sunumlarını nasıl imzalayacağınızı ve .NET aracılığıyla Python için Aspose.Slides kullanarak dijital imzaları nasıl doğrulayacağınızı veya kaldıracağınızı öğrenin."
---
## **Genel Bakış**

Dijital imza, alıcının bir sunumu kimin imzaladığını ve imzalı içeriğin değişip değişmediğini belirlemesine yardımcı olur. Burada üç ilgili güvenlik kavramı önemlidir:

- **Dijital sertifika**, bir kimliği bir ortak anahtarla ilişkilendiren elektronik bir kimlik belgesidir. Güvenilir bir sertifika otoritesi (CA) bir sertifika düzenleyebilir veya bir kuruluş dahili iş akışları için kendinden imzalı bir sertifika kullanabilir.
- **Dijital imza**, sunum içeriği ve sertifika sahibinin özel anahtarından oluşturulur. Sertifikanın ortak anahtarı imzayı doğrulamak için kullanılabilir. Bir imza, kaynağın ve bütünlüğün kanıtını sağlar; sunumu şifrelemez.
- **Parola koruması**, bir kullanıcının bir sunumu açıp değiştirebileceğini kontrol eder. Dijital imzalamadan ayrı bir konudur ve [Password-Protected Presentations](/python-net/password-protected-presentation/) bölümünde açıklanmıştır.

PowerPoint, **Dosya > Bilgi > Sunuyu Koru** menüsü altında **Add a Digital Signature** (Dijital İmza Ekle) komutunu sunar.

![PowerPoint Sunuyu Korumak menüsü, Dijital İmza Ekle vurgulanmış](add-digital-signature-in-powerpoint.png)

PowerPoint bildirimi, sunumun geçerli imzalar içerdiğini belirtiyor.

![PowerPoint bildirimi, sunumun geçerli imzalar içerdiğini belirtiyor](digital-signature-status-in-powerpoint.png)

Aspose.Slides, imzaları [Presentation.digital_signatures] aracılığıyla sunar, bu bir [DigitalSignatureCollection] olup öğeleri [DigitalSignature] nesneleridir. Bir sunum birden çok imza içerebilir.

## **PFX Sertifikalarını ve Parolaları Anlamak**

PFX dosyası, PKCS#12 dosyası olarak da bilinir ve genellikle `.pfx` ya da `.p12` uzantısına sahiptir; X.509 sertifikası, onun özel anahtarı ve sertifika zincirini içerebilir. Özel anahtar, sahibinin bir imza oluşturmasını sağlar. Erişilebilir bir özel anahtarı olmayan bir sertifika, bir sunumu imzalamak için kullanılamaz.

PFX parolası, sertifika paketini ve özel anahtarı korur. Bu, sunumu açmak ya da düzenlemek için bir parola **değildir**. PFX dosyalarını veya parolalarını kaynak kontrolüne göndermeyin. Üretim ortamında, sertifika dosyasına erişimi sınırlayın ve parolasını gizli bir depodan ya da başka bir korumalı yapılandırma kaynağından temin edin. Aşağıdaki örnekler, parolayı kodun içine gömmemek için yalnızca bir ortam değişkeni kullanır.

## **Bir Sunuma Dijital İmza Ekleme**

Gerçek bir sunum iş akışını imzalamak için, mevcut bir PPTX dosyasını yükleyin, bir PFX sertifikası ve parolasıyla bir [DigitalSignature] oluşturun, imzayı sunumun koleksiyonuna ekleyin ve PPTX dosyası olarak kaydedin.

```python
import os
import aspose.slides as slides

certificate_password = os.environ.get("PFX_PASSWORD")
if certificate_password is None:
    raise RuntimeError("Set the PFX_PASSWORD environment variable.")

with slides.Presentation("InputPresentation.pptx") as presentation:
    signature = slides.DigitalSignature("signing-certificate.pfx", certificate_password)
    signature.comments = "Approved for release."

    presentation.digital_signatures.add(signature)
    presentation.save("InputPresentation-signed.pptx", slides.export.SaveFormat.PPTX)
```

Sonucu yeni bir ad altında kaydetmek, imzasız kaynak dosyasını korur. [DigitalSignature.comments] değeri, imzanın amacını açıklar; bu bir güvenlik kontrolü değildir.

## **Dijital İmzaları Doğrulama**

İmzalı bir PPTX dosyasını yüklediğinizde, [Presentation.digital_signatures] içindeki her öğeyi inceleyin. [DigitalSignature.is_valid] özelliği, gömülü imzanın geçerli sunum içeriği için geçerli olup olmadığını gösterir.

```python
import hashlib
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    signature_count = len(presentation.digital_signatures)

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True

        for signature in presentation.digital_signatures:
            signature_status = "VALID" if signature.is_valid else "INVALID"
            certificate_fingerprint = hashlib.sha256(signature.certificate).hexdigest().upper()
            signing_time = signature.sign_time.strftime("%Y-%m-%d %H:%M:%S")

            print(
                f"Certificate SHA-256: {certificate_fingerprint}, "
                f"{signing_time} -- {signature_status}"
            )

            all_signatures_are_valid = (all_signatures_are_valid and signature.is_valid)

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
```

Geçersiz bir sonuç, genellikle imzalı sunum içeriğinin veya imza verisinin imzalama sonrası değiştiği ya da dosyanın bozuk olduğu anlamına gelir. Tüm imzaları kaldırmak imzasız bir sunum oluşturur, bu yüzden yalnızca öğelerin geçerliliğini kontrol etmek yeterli değildir: güvenlik açısından hassas bir iş akışı, beklenen imza sayısının ve beklenen imzalayan kimliklerinin mevcut olduğunu da doğrulamalıdır.

[DigitalSignature.certificate] özelliği, sertifika verilerini bir bayt dizisi olarak sunar. Örnek, bir uygulamanın bunu beklenen imzalayan sertifikanın parmak izine karşılaştırabilmesi için SHA-256 parmak izini hesaplar.

Bu geçerlilik sonucu, tam bir sertifika güven kararı olarak ele alınmamalıdır. Güvenlik politikanıza bağlı olarak, uygulamanız X.509 sertifika zincirini oluşturup doğrulamalı, sertifika geçerlilik tarihlerini ve iptal durumunu kontrol etmeli, beklenen konu ya da parmak izini onaylamalı, anahtar kullanımını doğrulamalı ve güvenilir bir zaman damgasını değerlendirmelidir. [DigitalSignature.sign_time] değeri tek başına güvenilir bir zaman damgası otoritesinden gelen bir kanıt değildir.

## **Dijital İmzaları Kaldırma**

İmzaları kaldırmak, sunumun güvenlik durumunu değiştirir. Aşağıdaki örnek, imzalı bir PPTX dosyasını yükler, tüm imzaları [DigitalSignatureCollection.clear] ile kaldırır ve imzasız bir kopya kaydeder.

```python
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    presentation.digital_signatures.clear()
    presentation.save("InputPresentation-unsigned.pptx", slides.export.SaveFormat.PPTX)
```

Sadece bir imzayı kaldırmak için, sıfır tabanlı indeksini kullanarak [DigitalSignatureCollection.remove_at] yöntemini çağırın. İş akışınızda imzalı orijinali üzerine yazmak açık bir gereklilik olmadıkça yeni bir dosyaya kaydedin.

## **Düzenleme ve Biçim Hususları**

- Bir imza, sunumu yalnızca okunabilir yapmaz. Kullanıcılar ve uygulamalar dosyayı hâlâ düzenleyebilir, ancak imzalı içeriğe yapılan değişiklikler genellikle mevcut imzayı geçersiz kılar.
- İmzalamadan önce tüm planlanan düzenlemeleri tamamlayın. Sunumun değiştirilmesi gerekiyorsa, revize edilmiş sunumu kaydedin ve o revizyonu yeniden imzalayın.
- Son çıktıyı PPTX biçiminde tutun. İmzalı bir sunumu başka bir biçime dönüştürmek, orijinal PPTX imzasını dönüştürülmüş dosya için geçerli bir imza olarak taşımaz.
- Sertifikanın özel anahtarını hassas bir veri olarak tutun. Özel anahtarı ve parolasını elde eden herkes, o sertifika sahibinden geldiği izlenimini veren imzalar oluşturabilir.
- Belge saklama politikanız gerektirdiğinde imzasız kaynağı veya başka bir kontrollü kopyayı saklayın.

## **SSS**

**Dijital imza sunumu şifreler mi?**  
Hayır. Dijital imza, kaynağa ve bütünlüğe dair kanıt sağlar, ancak ayrı bir şifreleme uygulanmadıkça sunum içeriği okunabilir kalır. İçeriğe erişim kısıtlanmalıysa [parola koruması](/python-net/password-protected-presentation/) kullanın.

**PFX parolası bir sunum parolasıyla aynı mı?**  
Hayır. PFX parolası, sertifika paketinde saklanan özel anahtarın kilidini açar. PPTX dosyasını kimlerin açıp düzenleyebileceğini kontrol etmez.

**Kendinden imzalı bir sertifika kullanabilir miyim?**  
Teknik olarak, erişilebilir bir özel anahtar içeriyorsa kendinden imzalı bir sertifika kullanılabilir. Ancak alıcılar otomatik olarak güvenmez; bu sertifika güvenilir ortamlarına açıkça eklenmedikçe. Kamu veya kuruluşlar arası iş akışları genellikle güvenilir bir CA tarafından verilen bir sertifika kullanır.

**Bir imzayı geçersiz kılan nedir?**  
İmzalı sunum içeriğini veya imza verisini imzalama sonrası değiştirmek imzayı geçersiz kılar. Dosya bozulması da doğrulamanın başarısız olmasına yol açabilir. Tüm imzalar kaldırılırsa, sunum geçersiz bir imza içeren bir dosya değil, imzasız olur.

**Geçerli bir imza, imzalayan kişiye güvenmem gerektiği anlamına mı gelir?**  
Sadece bu şekilde değildir. İmza bütünlüğü ve imzalayanın güvenilirliği ayrı kararlar gerektirir. Üretim ortamındaki doğrulama politikası ayrıca sertifika zincirini, geçerlilik süresini, iptal durumunu, beklenen kimliği, anahtar kullanımını ve güvenilir zaman damgası gereksinimlerini kontrol etmelidir.

**Sertifika süresi dolduğunda ne olur?**  
Sertifikanın süresi dolması, sunumun baytlarını değiştirmez, ancak sertifika güven değerlendirmesini etkiler. Bir imzanın kabul edilebilir olup olmadığı, politikanıza ve geçerli bir güvenilir zaman damgasının imzalamanın sertifikanın geçerli olduğu sırada gerçekleştiğini kanıtlayıp kanıtlamadığına bağlıdır. Görüntülenen imzalama zamanına tek başına güvenilir bir zaman damgası olarak güvenmeyin.

**İmzalı bir sunum hâlâ düzenlenebilir mi?**  
Evet. İmzalamak dosyayı kilitlemez. İmzalı içeriği düzenlemek genellikle mevcut imzayı geçersiz kılar, bu yüzden önce sunumu tamamlayıp son revizyonu imzalayın.

**Bir sunum birden fazla imza içerebilir mi?**  
Evet. Her bir imzayı kaydetmeden önce [Presentation.digital_signatures] koleksiyonuna ekleyin. Doğrulama sırasında her imzayı inceleyin ve tüm gerekli imzalayanların mevcut olduğunu onaylayın.

**Hangi sunum formatları bu işlemleri destekler?**  
Aspose.Slides, burada açıklanan dijital imza işlemlerini yalnızca PPTX için destekler. PPT ve OpenDocument (ODP) sunum formatları bu API iş akışı tarafından desteklenmez.

**Bir imzayı slaytlara dokunmadan kaldırabilir miyim?**  
Evet. Bir imzayı kaldırabilir veya tüm koleksiyonu temizleyip ardından sunumu kaydedebilirsiniz. Slayt içeriği kullanılabilir durumda kalır, ancak kaydedilen dosya artık kaldırılan imza kanıtını taşımaz.