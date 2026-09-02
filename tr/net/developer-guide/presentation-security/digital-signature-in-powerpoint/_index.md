---
title: .NET'te Sunumlara Dijital İmzalar Ekleme
linktitle: Dijital İmza
type: docs
weight: 10
url: /tr/net/digital-signature-in-powerpoint/
keywords:
- dijital imza
- dijital sertifika
- sertifika otoritesi
- PFX sertifikası
- PKCS#12
- imzayı doğrulama
- PowerPoint
- PPTX
- sunum güvenliği
- .NET
- C#
- Aspose.Slides
description: "PFX sertifikalarıyla mevcut PPTX sunumlarını nasıl imzalayacağınızı ve .NET için Aspose.Slides kullanarak dijital imzaları nasıl doğrulayacağınızı veya kaldıracağınızı öğrenin."
---
## **Genel Bakış**

Dijital imza, alıcının bir sunumu kimin imzaladığını ve imzalı içeriğin değişip değişmediğini belirlemesine yardımcı olur. Burada üç ilgili güvenlik kavramı önemlidir:

- **Dijital sertifika**, bir kimliği bir genel anahtarla ilişkilendiren elektronik bir kimlik belgesidir. Güvenilir bir sertifika otoritesi (CA) bir sertifika verebilir veya bir organizasyon dahili iş akışları için kendinden imzalı bir sertifika kullanabilir.
- **Dijital imza**, sunum içeriğinden ve sertifika sahibinin özel anahtarından oluşturulur. Sertifikanın genel anahtarı daha sonra imzayı doğrulamak için kullanılabilir. İmza, kaynağın ve bütünlüğün kanıtını sağlar; sunumu şifrelemez.
- **Şifre koruması**, bir kullanıcının bir sunumu açıp değiştirebilmesini kontrol eder. Bu, dijital imzalamadan ayrı bir konudur ve [Şifreyle Korunan Sunumlar](/net/password-protected-presentation/) bölümünde açıklanmıştır.

PowerPoint, **File > Info > Protect Presentation** altında **Add a Digital Signature** komutunu sağlar.

![PowerPoint Protect Presentation menüsü, Add a Digital Signature vurgulanmış](add-digital-signature-in-powerpoint.png)

İmzalı bir sunum açıldıktan sonra, PowerPoint bir imza‑durumu bildirimi gösterebilir.

![PowerPoint bildirimi, sunumun geçerli imzalar içerdiğini belirtiyor](digital-signature-status-in-powerpoint.png)

Aspose.Slides, imzaları [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/digitalsignatures/) aracılığıyla, öğeleri [IDigitalSignature](https://reference.aspose.com/slides/tr/net/aspose.slides/idigitalsignature/) uygulayan bir [IDigitalSignatureCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/idigitalsignaturecollection/) olarak sunar. Bir sunum birden fazla imza içerebilir.

## **PFX Sertifikalarını ve Şifreleri Anlamak**

PFX dosyası, PKCS#12 dosyası olarak da bilinir ve genellikle `.pfx` veya `.p12` uzantısına sahiptir; bir X.509 sertifikası, özel anahtarı ve sertifika zincirini içerebilir. Özel anahtar, imza oluşturmayı sağlar. Erişilebilir bir özel anahtarı olmayan bir sertifika, bir sunumu imzalamak için kullanılamaz.

PFX şifresi, sertifika paketini ve özel anahtarı korur. Bu, sunumu açmak veya düzenlemek için bir şifre **değildir**. PFX dosyalarını veya şifrelerini kaynak kontrolüne gönderip saklamayın. Üretim ortamında, sertifika dosyasına erişimi sınırlayın ve şifresini bir gizli depo veya başka bir korumalı yapılandırma kaynağından alın. Aşağıdaki örneklerde, şifreyi koda gömmemek için yalnızca bir ortam değişkeni kullanılmıştır.

## **Bir Sunuma Dijital İmza Eklemek**

Gerçek bir sunum iş akışını imzalamak için mevcut bir PPTX dosyasını yükleyin, bir PFX sertifikasından ve şifresinden bir [DigitalSignature](https://reference.aspose.com/slides/tr/net/aspose.slides/digitalsignature/) oluşturun, imzayı sunumun koleksiyonuna ekleyin ve bir PPTX dosyasına kaydedin.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var certificatePassword = Environment.GetEnvironmentVariable("PFX_PASSWORD")
    ?? throw new InvalidOperationException("Set the PFX_PASSWORD environment variable.");

using var presentation = new Presentation("InputPresentation.pptx");

var signature = new DigitalSignature("signing-certificate.pfx", certificatePassword)
{
    Comments = "Approved for release."
};

presentation.DigitalSignatures.Add(signature);
presentation.Save("InputPresentation-signed.pptx", SaveFormat.Pptx);
```

Sonucu yeni bir adla kaydetmek, imzasız kaynak dosyasını korur. [DigitalSignature.Comments](https://reference.aspose.com/slides/tr/net/aspose.slides/digitalsignature/comments/) değeri, imzanın amacını açıklar; bu bir güvenlik kontrolü **değildir**.

## **Dijital İmzaları Doğrulama**

İmzalı bir PPTX dosyasını yüklediğinizde, [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/digitalsignatures/) içindeki her öğeyi inceleyin. [IDigitalSignature.IsValid](https://reference.aspose.com/slides/tr/net/aspose.slides/idigitalsignature/isvalid/) özelliği, gömülü imzanın mevcut sunum içeriği için geçerli olup olmadığını gösterir.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("InputPresentation-signed.pptx");

var signatureCount = presentation.DigitalSignatures.Count;

if (signatureCount == 0)
{
    Console.WriteLine("The presentation does not contain digital signatures.");
}
else
{
    var allSignaturesAreValid = true;

    foreach (var signature in presentation.DigitalSignatures)
    {
        var signatureStatus = signature.IsValid ? "VALID" : "INVALID";
        var signerName = signature.Certificate.SubjectName.Name;

        Console.WriteLine(
            $"{signerName}, {signature.SignTime:yyyy-MM-dd HH:mm:ss} -- {signatureStatus}");

        allSignaturesAreValid &= signature.IsValid;
    }

    Console.WriteLine(allSignaturesAreValid
        ? "All embedded signatures are valid for the current presentation."
        : "At least one embedded signature is invalid.");
}
```

Geçersiz bir sonuç genellikle, imzalı sunum içeriği veya imza verisinin imzalama sonrasında değiştiği ya da dosyanın bozuk olduğu anlamına gelir. Tüm imzaları kaldırmak imzasız bir sunum üretir, bu yüzden yalnızca öğelerin geçerliliğini kontrol etmek yeterli değildir: güvenlik duyarlı bir iş akışı, beklenen imza sayısının ve beklene imzalayan kimliklerin mevcut olduğunu da doğrulamalıdır.

Bu geçerlilik sonucu, tam bir sertifika‑güven kararı olarak değerlendirilmemelidir. Güvenlik politikanıza bağlı olarak, uygulamanız ayrıca X.509 sertifika zincirini oluşturup doğrulamalı, sertifika geçerlilik tarihlerini ve iptal durumunu kontrol etmeli, beklenen konu ya da parmak izini onaylamalı, anahtar kullanımını doğrulamalı ve güvenilir bir zaman damgası değerlendirmelidir. [IDigitalSignature.SignTime](https://reference.aspose.com/slides/tr/net/aspose.slides/idigitalsignature/signtime/) değeri tek başına güvenilir bir zaman damgası otoritesinden kanıt değildir.

## **Dijital İmzaları Kaldırma**

İmzaları kaldırmak, sunumun güvenlik durumunu değiştirir. Aşağıdaki örnek, imzalı bir PPTX dosyasını yükler, tüm imzaları [IDigitalSignatureCollection.Clear](https://reference.aspose.com/slides/tr/net/aspose.slides/idigitalsignaturecollection/clear/) yöntemiyle kaldırır ve imzasız bir kopya kaydeder.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

Sadece bir imzayı kaldırmak için, sıfır‑tabanlı diziniyle birlikte [IDigitalSignatureCollection.RemoveAt](https://reference.aspose.com/slides/tr/net/aspose.slides/idigitalsignaturecollection/removeat/) yöntemini çağırın. İmzalı orijinali üzerine yazmak açık bir iş akışı parçası olmadıkça, yeni bir dosyaya kaydedin.

## **Düzenleme ve Biçim Düşünceleri**

- Bir imza, bir sunumu yalnızca‑okunur hâle getirmez. Kullanıcılar ve uygulamalar dosyayı hâlâ düzenleyebilir, ancak imzalı içeriğe yapılan değişiklikler genellikle mevcut imzayı geçersiz kılar.
- Tüm istenen düzenlemeleri imzalamadan önce tamamlayın. Bir sunumun değiştirilmesi gerekiyorsa, revize edilmiş sunumu kaydedin ve o revizyonu tekrar imzalayın.
- Son çıktıyı PPTX formatında tutun. İmzalı bir sunumu başka bir formata dönüştürmek, orijinal PPTX imzasını dönüştürülmüş dosya için geçerli bir imza olarak taşımaz.
- Sertifikanın özel anahtarını hassas bir bilgi olarak tutun. Özel anahtara ve şifresine erişen herkes, o sertifika sahibinden geliyormuş gibi imzalar oluşturabilir.
- Belgelerin saklama politikanız gerektiriyorsa, imzasız kaynağı veya başka kontrollü bir kopyayı koruyun.

## **SSS**

**Dijital bir imza sunumu şifreler mi?**

Hayır. Dijital imza, kaynağın ve bütünlüğün kanıtını sağlar, ancak sunum içeriği ayrı bir şifreleme uygulanmadıkça okunabilir kalır. İçeriğe erişimin sınırlanması gerektiğinde [şifre korumasını](/net/password-protected-presentation/) kullanın.

**PFX şifresi sunum şifresiyle aynı mıdır?**

Hayır. PFX şifresi, sertifika paketindeki özel anahtarı açar. PPTX dosyasını açma veya düzenleme yetkisini kontrol etmez.

**Kendinden imzalı bir sertifika kullanabilir miyim?**

Teknik olarak, erişilebilir bir özel anahtar içerdiği sürece kendinden imzalı bir sertifika kullanılabilir. Alıcılar otomatik olarak güvenmez; ancak sertifika açıkça güvenilen ortama eklenmişse güvenilir olabilir. Genel veya çapraz‑organizasyon iş akışları genellikle güvenilir bir CA tarafından verilen bir sertifika kullanır.

**Bir imzayı geçersiz kılan nedir?**

İmzalı sunum içeriğini veya imza verisini imzalama sonrası değiştirmek imzayı geçersiz kılar. Dosya bozulması da doğrulamanın başarısız olmasına neden olabilir. Tüm imzalar kaldırılırsa, sunum geçersiz bir imza içeren bir dosya değil, imzasız bir sunum olur.

**Geçerli bir imza, imzalayan kişiye güvenmem gerektiği anlamına mı gelir?**

Tek başına hayır. İmza bütünlüğü ve imzalayan güveni ayrı kararlardır. Üretim doğrulama politikası ayrıca sertifika zinciri, geçerlilik süresi, iptal durumu, beklenen kimlik, anahtar kullanımı ve güvenilir zaman damgası gereksinimlerini kontrol etmelidir.

**Sertifika süresi dolduğunda ne olur?**

Sertifika süresi dolması sunum baytlarını değiştirmez, ancak sertifika‑güven değerlendirmesini etkiler. Bir imzanın kabul edilebilir olup olmadığı politikanıza ve geçerli bir güvenilir zaman damgasının imzalamanın sertifika geçerli olduğu sırada gerçekleştiğini kanıtlayıp kanıtlamadığına bağlıdır. Tek başına görüntülenen imzalama zamanına güvenilir bir zaman damgası olarak güvenmeyin.

**İmzalı bir sunum hâlâ düzenlenebilir mi?**

Evet. İmzalama dosyayı kilitlemez. İmzalı içeriği düzenlemek genellikle mevcut imzayı geçersiz kılar; bu yüzden önce sunumu tamamlayın ve son revizyonu imzalayın.

**Bir sunum birden fazla imza içerebilir mi?**

Evet. Her imzayı kaydetmeden önce [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/digitalsignatures/) koleksiyonuna ekleyin. Doğrulama sırasında her imzayı inceleyin ve tüm gerekli imzalayanların mevcut olduğunu onaylayın.

**Hangi sunum formatları bu işlemleri destekler?**

Aspose.Slides, burada açıklanan dijital‑imza işlemlerini yalnızca PPTX için destekler. PPT ve OpenDocument sunum formatları bu API iş akışı tarafından desteklenmez.

**Bir imzayı slaytlara zarar vermeden kaldırabilir miyim?**

Evet. Tek bir imzayı kaldırabilir veya tüm koleksiyonu temizleyebilir ve ardından sunumu kaydedebilirsiniz. Slayt içeriği mevcut kalır, ancak kaydedilen dosya artık kaldırılan imzanın kanıtını taşımaz.