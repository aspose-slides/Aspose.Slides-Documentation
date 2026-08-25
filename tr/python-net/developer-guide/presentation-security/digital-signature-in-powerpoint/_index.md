---
title: Python’da Sunumlara Dijital İmza Ekleme
linktitle: Dijital İmza
type: docs
weight: 10
url: /tr/python-net/digital-signature-in-powerpoint/
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
description: "PFX sertifikalarıyla mevcut PPTX sunumlarını nasıl imzalayacağınızı ve .NET üzerinden Python için Aspose.Slides kullanarak dijital imzaları doğrulama veya kaldırma işlemlerini öğrenin."
---
## **Genel Bakış**

Bir dijital imza, alıcının bir sunumu kimin imzaladığını ve imzalı içeriğin değişip değişmediğini belirlemesine yardımcı olur. Burada üç ilgili güvenlik kavramı önemlidir:

- Bir **dijital sertifika**, bir kimliği bir açık anahtarla ilişkilendiren elektronik bir kimlik belgesidir. Güvenilir bir sertifika yetkilisi (CA) bir sertifika yayabilir veya bir organizasyon iç süreçler için kendinden imzalı bir sertifika kullanabilir.
- Bir **dijital imza**, sunum içeriği ve sertifika sahibinin özel anahtarıyla oluşturulur. Sertifikanın açık anahtarı daha sonra imzayı doğrulamak için kullanılabilir. Bir imza, köken ve bütünlük kanıtı sağlar; sunumu şifrelemez.
- **Parola koruması**, bir kullanıcının bir sunumu açıp değiştirebileceğini kontrol eder. Bu, dijital imzalamadan ayrı bir konudur ve [Password-Protected Presentations](/slides/tr/python-net/password-protected-presentation/) içinde açıklanmıştır.

PowerPoint, **Dosya > Bilgi > Sunumu Koru** altında **Dijital İmza Ekle** komutunu sunar.

![PowerPoint Protect Presentation menüsünde Dijital İmza Ekle vurgulanmış şekilde](add-digital-signature-in-powerpoint.png)

İmzalı bir sunum açıldığında, PowerPoint bir imza‑durumu bildirimi gösterebilir.

![PowerPoint, sunumun geçerli imzalar içerdiğini belirten bir bildirim gösteriyor](digital-signature-status-in-powerpoint.png)

Aspose.Slides, imzaları [Presentation.digital_signatures](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/digital_signatures/) aracılığıyla, öğeleri [DigitalSignature](https://reference.aspose.com/slides/tr/python-net/aspose.slides/digitalsignature/) nesneleri olan bir [DigitalSignatureCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/digitalsignaturecollection/) olarak sunar. Bir sunum birden çok imza içerebilir.

## **PFX Sertifikalarını ve Parolaları Anlamak**

PFX dosyası, PKCS#12 dosyası olarak da bilinir ve genellikle `.pfx` veya `.p12` uzantısı taşır; bir X.509 sertifikası, onun özel anahtarı ve sertifika zincirini içerebilir. Özel anahtar, sahibine bir imza oluşturma yetkisi verir. Özel anahtara erişilemeyen bir sertifika, bir sunumu imzalamak için kullanılamaz.

PFX parolası, sertifika paketini ve özel anahtarı korur. Bu, sunumu açmak veya düzenlemek için bir parola **değildir**. PFX dosyalarını veya parolalarını sürüm kontrolüne göndermeyin. Üretim ortamında, sertifika dosyasına erişimi sınırlayın ve parolayı bir gizli mağazadan veya başka bir korumalı yapılandırma kaynağından alın. Aşağıdaki örneklerde, parolanın kod içinde gömülmemesi için sadece bir ortam değişkeni kullanılmaktadır.

## **Bir Sunuma Dijital İmza Ekleme**

Gerçek bir sunumu imzalama sürecinde, mevcut bir PPTX dosyasını yükleyin, PFX sertifikası ve parolasıyla bir [DigitalSignature](https://reference.aspose.com/slides/tr/python-net/aspose.slides/digitalsignature/) oluşturun, imzayı sunumun koleksiyonuna ekleyin ve bir PPTX dosyasına kaydedin.

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

Sonucu yeni bir adla kaydetmek, imzasız kaynak dosyasını korur. [DigitalSignature.comments](https://reference.aspose.com/slides/tr/python-net/aspose.slides/digitalsignature/comments/) değeri, imzanın amacını açıklar; bir güvenlik kontrolü değildir.

## **Dijital İmzaları Doğrulama**

İmzalı bir PPTX dosyasını yüklediğinizde, [Presentation.digital_signatures](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/digital_signatures/) içindeki her öğeyi inceleyin. [DigitalSignature.is_valid](https://reference.aspose.com/slides/tr/python-net/aspose.slides/digitalsignature/is_valid/) özelliği, gömülü imzanın mevcut sunum içeriği için geçerli olup olmadığını gösterir.

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

Geçersiz bir sonuç genellikle imzalı sunum içeriği veya imza verisinin imzalama sonrası değiştiği ya da dosyanın bozulmuş olduğu anlamına gelir. Tüm imzalar kaldırıldığında sunum imzasız olur, bu yüzden sadece öğelerin geçerliliğini kontrol etmek yeterli değildir: güvenlik‑duyarlı bir iş akışı, beklenen imza sayısının ve beklenen imzalayan kimliklerinin mevcut olduğunu da doğrulamalıdır.

[DigitalSignature.certificate](https://reference.aspose.com/slides/tr/python-net/aspose.slides/digitalsignature/certificate/) özelliği, sertifika verilerini bir bayt dizisi olarak sunar. Örnek, bir uygulamanın beklenen imzalayan sertifikasının parmak izini karşılaştırabilmesi için SHA‑256 parmak izini hesaplar.

Bu geçerlilik sonucu, tam bir sertifika‑güven kararı olarak ele alınmamalıdır. Güvenlik politikanıza bağlı olarak, uygulamanız X.509 sertifika zincirini oluşturup doğrulamalı, sertifika geçerlilik tarihlerini ve iptal durumunu kontrol etmeli, beklenen konu ya da parmak izini doğrulamalı, anahtar kullanımını incelemeli ve güvenilir bir zaman damgası değerlendirmelidir. [DigitalSignature.sign_time](https://reference.aspose.com/slides/tr/python-net/aspose.slides/digitalsignature/sign_time/) değeri tek başına güvenilir bir zaman damgası otoritesinden bir kanıt teşkil etmez.

## **Dijital İmzaları Kaldırma**

İmzaları kaldırmak, sunumun güvenlik durumunu değiştirir. Aşağıdaki örnek bir imzalı PPTX dosyasını yükler, tüm imzaları [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/tr/python-net/aspose.slides/digitalsignaturecollection/clear/) ile kaldırır ve imzasız bir kopya kaydeder.

```python
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    presentation.digital_signatures.clear()
    presentation.save("InputPresentation-unsigned.pptx", slides.export.SaveFormat.PPTX)
```

Yalnızca bir imzayı kaldırmak için, sıfır‑tabanlı indeksiyle [DigitalSignatureCollection.remove_at](https://reference.aspose.com/slides/tr/python-net/aspose.slides/digitalsignaturecollection/remove_at/) metodunu çağırın. İmzası olan orijinali üzerine yazmak iş akışınızın açık bir parçası değilse, yeni bir dosyaya kaydedin.

## **Düzenleme ve Biçim Hususları**

- Bir imza, bir sunumu salt‑okunur hâle getirmez. Kullanıcılar ve uygulamalar dosyayı hâlâ düzenleyebilir, ancak imzalı içeriğe yapılan değişiklikler genellikle mevcut imzayı geçersiz kılar.
- İmzalamadan önce tüm istenen düzenlemeleri tamamlayın. Sunumun değiştirilmesi gerekiyorsa, revize edilmiş sunumu kaydedin ve o revizyonu yeniden imzalayın.
- Son çıktıyı PPTX biçiminde tutun. İmzalı bir sunumu başka bir biçime dönüştürmek, orijinal PPTX imzasını dönüştürülmüş dosya için geçerli bir imza olarak taşımaz.
- Sertifikanın özel anahtarını hassas bir bilgi olarak tutun. Özel anahtar ve parolasını elde eden herkes, o sertifika sahibinden geliyormuş gibi imzalar oluşturabilir.
- Belge‑koruma politikanız gerektiriyorsa, imzasız kaynak ya da başka bir kontrol edilen kopyayı saklayın.

## **SSS**

**Dijital imza sunumu şifreler mi?**

Hayır. Dijital imza, köken ve bütünlük kanıtı sağlar, ancak içerik ayrı bir şifreleme uygulanmadıkça okunabilir kalır. İçeriğe erişimin kısıtlanması gerektiğinde [password protection](/slides/tr/python-net/password-protected-presentation/) kullanın.

**PFX parolası sunum parolasıyla aynı mı?**

Hayır. PFX parolası, sertifika paketindeki özel anahtarı açar. PPTX dosyasını kimlerin açıp düzenleyebileceğini kontrol etmez.

**Kendinden imzalı bir sertifika kullanabilir miyim?**

Teknik olarak, erişilebilir bir özel anahtar içeriyorsa kendinden imzalı bir sertifika kullanılabilir. Alıcılar otomatik olarak güvenmez; sertifikanın güvenilir ortama açıkça eklenmesi gerekir. Kamu veya çapraz‑organizasyon iş akışları genellikle güvenilir bir CA tarafından verilen bir sertifika kullanır.

**Bir imzayı geçersiz kılan nedir?**

İmzalı sunum içeriğini veya imza verisini imzalama sonrası değiştirmek imzayı geçersiz kılar. Dosya bozulması da doğrulamayı başarısız kılar. Tüm imzalar kaldırılırsa sunum, geçersiz bir imza içeren bir dosya değil, imzasız bir dosudur.

**Geçerli bir imza imzalayan kişiye güvenmem gerektiği anlamına gelir mi?**

Yalnız başına değil. İmza bütünlüğü ve imzalayanın güvenilirliği ayrı kararlar gerektirir. Üretim doğrulama politikası, ayrıca sertifika zinciri, geçerlilik süresi, iptal durumu, beklenen kimlik, anahtar kullanımı ve olası güvenilir zaman damgası gereksinimlerini kontrol etmelidir.

**Sertifika süresi dolduğunda ne olur?**

Sertifikanın süresi dolması, sunum baytlarını değiştirmez, ancak sertifika‑güven değerlendirmesini etkiler. Bir imzanın kabul edilebilir olup olmadığı, politikanıza ve geçerli bir güvenilir zaman damgasının imzalamanın sertifika geçerli iken gerçekleştiğini kanıtlayıp kanıtlamadığına bağlıdır. Görüntülenen imzalama zamanına yalnızca güvenilir bir zaman damgası olarak güvenmeyin.

**İmzalı bir sunum hâlâ düzenlenebilir mi?**

Evet. İmzalama dosyayı kilitlemez. İmzalı içeriği düzenlemek genellikle mevcut imzayı geçersiz kılar; bu yüzden önce sunumu tamamlayıp son revizyonu imzalayın.

**Bir sunum birden fazla imza içerebilir mi?**

Evet. Kaydetmeden önce her imzayı [Presentation.digital_signatures](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/digital_signatures/) koleksiyonuna ekleyin. Doğrulama sırasında her imzayı inceleyin ve gerekli tüm imzalayanların mevcut olduğunu doğrulayın.

**Hangi sunum biçimleri bu işlemleri destekler?**

Aspose.Slides, burada açıklanan dijital‑imza işlemlerini yalnızca PPTX için destekler. PPT ve OpenDocument sunum biçimleri bu API iş akışıyla desteklenmez.

**Bir imzayı slaytları etkilemeden kaldırabilir miyim?**

Evet. Tek bir imzayı kaldırabilir veya tüm koleksiyonu temizleyip ardından sunumu kaydedebilirsiniz. Slayt içeriği kalır, ancak kaydedilen dosya artık kaldırılan imza kanıtını içermez.