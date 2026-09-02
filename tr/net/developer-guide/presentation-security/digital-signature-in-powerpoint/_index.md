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
- imza doğrulama
- PowerPoint
- PPTX
- sunum güvenliği
- .NET
- C#
- Aspose.Slides
description: "PFX sertifikalarıyla mevcut PPTX sunumlarını nasıl imzalayacağınızı ve .NET için Aspose.Slides kullanarak dijital imzaları doğrulamayı veya kaldırmayı öğrenin."
---
## **Genel Bakış**

Bir dijital imza, alıcının bir sunumu kimin imzaladığını ve imzalı içeriğin değişip değişmediğini belirlemesine yardımcı olur. Burada üç ilgili güvenlik kavramı önemlidir:

- **dijital sertifika**, bir kimliği bir açık anahtarla ilişkilendiren elektronik bir kimlik belgesidir. Güvenilir bir sertifika otoritesi (CA) bir sertifika yayabilir ya da bir kuruluş, dahili iş akışları için kendinden imzalı bir sertifika kullanabilir.
- **dijital imza**, sunum içeriği ve sertifika sahibinin özel anahtarı kullanılarak oluşturulur. Sertifikanın açık anahtarı daha sonra imzayı doğrulamak için kullanılabilir. Bir imza, kaynağın ve bütünlüğün kanıtını sağlar; sunumu şifrelemez.
- **Parola koruması**, bir kullanıcının bir sunumu açıp değiştirebilip değiştiremeyeceğini kontrol eder. Bu, dijital imzalamanın dışında bir özelliktir ve [Parola Korumalı Sunumlar](/slides/tr/net/password-protected-presentation/) bölümünde açıklanmıştır.

PowerPoint, **Dosya > Bilgi > Sunumu Koruma** altında **Dijital İmza Ekle** komutunu sunar.

![PowerPoint Protect Presentation menüsü, Dijital İmza Ekle vurgulanmış olarak] (add-digital-signature-in-powerpoint.png)

İmzalı bir sunum açıldıktan sonra, PowerPoint bir imza durumu bildirimi gösterebilir.

![PowerPoint bildirimi, sunumun geçerli imzalar içerdiğini belirtiyor] (digital-signature-status-in-powerpoint.png)

Aspose.Slides, imzaları [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/digitalsignatures/) aracılığıyla sunar; bu, öğeleri [IDigitalSignature](https://reference.aspose.com/slides/tr/net/aspose.slides/idigitalsignature/) uygulayan bir [IDigitalSignatureCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/idigitalsignaturecollection/)dır. Bir sunum birden fazla imza içerebilir.

## **PFX Sertifikalarını ve Parolalarını Anlamak**

PFX dosyası, aynı zamanda PKCS#12 dosyası olarak da bilinir ve genellikle `.pfx` ya da `.p12` uzantısına sahiptir; X.509 sertifikası, özel anahtarı ve sertifika zincirini içerebilir. Özel anahtar, sahibinin bir imza oluşturmasını sağlar. Erişilebilir özel anahtarı olmayan bir sertifika, sunumu imzalamak için kullanılamaz.

PFX parolası, sertifika paketini ve özel anahtarı korur. Bu, sunumu açmak ya da düzenlemek için bir parola **değildir**. PFX dosyalarını ve parolalarını kaynak kontrolüne eklemeyin. Üretim ortamında, sertifika dosyasına erişimi sınırlayın ve parolayı bir gizli depodan ya da başka korumalı bir yapılandırma kaynağından alın. Aşağıdaki örneklerde, parola kod içinde gömülmemesi için sadece bir ortam değişkeni kullanılmıştır.

## **Bir Sunuma Dijital İmza Ekleme**

Gerçek bir sunum iş akışını imzalamak için mevcut bir PPTX dosyasını yükleyin, bir PFX sertifikası ve parolasıyla bir [DigitalSignature](https://reference.aspose.com/slides/tr/net/aspose.slides/digitalsignature/) oluşturun, imzayı sunumun koleksiyonuna ekleyin ve bir PPTX dosyasına kaydedin.

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

Sonucu yeni bir ad altında kaydetmek, imzasız kaynak dosyasını korur. [DigitalSignature.Comments](https://reference.aspose.com/slides/tr/net/aspose.slides/digitalsignature/comments/) değeri, imzanın amacını açıklar; bir güvenlik kontrolü değildir.

## **Dijital İmzaları Doğrulama**

İmzalı bir PPTX dosyasını yüklediğinizde, [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/digitalsignatures/) içindeki her öğeyi inceleyin. [IDigitalSignature.IsValid](https://reference.aspose.com/slides/tr/net/aspose.slides/idigitalsignature/isvalid/) özelliği, gömülü imzanın geçerli sunum içeriği için geçerli olup olmadığını gösterir.

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

Geçersiz bir sonuç, genellikle imzalı sunum içeriğinin ya da imza verilerinin imzalamadan sonra değiştiği ya da dosyanın bozulmuş olduğu anlamına gelir. Tüm imzaları kaldırmak, imzasız bir sunum üretir; bu nedenle yalnızca öğelerin geçerliliğini kontrol etmek yeterli değildir: güvenlik açısından hassas bir iş akışı, beklenen imza sayısının ve beklenen imzalayan kimliklerin mevcut olduğunu da doğrulamalıdır.

Bu geçerlilik sonucu, tam bir sertifika güven kararı olarak değerlendirilmemelidir. Güvenlik politikanıza bağlı olarak, uygulamanız ayrıca X.509 sertifika zincirini oluşturup doğrulamalı, sertifika geçerlilik tarihlerini ve iptal durumunu kontrol etmeli, beklenen konu ya da parmak izini onaylamalı, anahtar kullanımını doğrulamalı ve güvenilir bir zaman damgasını değerlendirmelidir. [IDigitalSignature.SignTime](https://reference.aspose.com/slides/tr/net/aspose.slides/idigitalsignature/signtime/) değeri tek başına güvenilir bir zaman damgası otoritesinden bir kanıt değildir.

## **Dijital İmzaları Kaldırma**

İmzaları kaldırmak, sunumun güvenlik durumunu değiştirir. Aşağıdaki örnek, imzalı bir PPTX dosyasını yükler, tüm imzaları [IDigitalSignatureCollection.Clear](https://reference.aspose.com/slides/tr/net/aspose.slides/idigitalsignaturecollection/clear/) ile kaldırır ve imzasız bir kopya olarak kaydeder.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

Yalnızca bir imzayı kaldırmak için, sıfır tabanlı indeksini kullanarak [IDigitalSignatureCollection.RemoveAt](https://reference.aspose.com/slides/tr/net/aspose.slides/idigitalsignaturecollection/removeat/) metodunu çağırın. İmzalı orijinali üzerine yazmak iş akışınızın açık bir parçası değilse, yeni bir dosyaya kaydedin.

## **Düzenleme ve Biçimlendirme Hususları**

- Bir imza, bir sunumu yalnızca okuma‑yazma korumalı hale getirmez. Kullanıcılar ve uygulamalar dosyayı hâlâ düzenleyebilir; ancak imzalı içeriğe yapılan değişiklikler genellikle mevcut imzayı geçersiz kılar.
- İmzalamadan önce tüm istenen düzenlemeleri tamamlayın. Sunumun değiştirilmesi gerekiyorsa, revize edilmiş sunumu kaydedin ve bu revizyonu tekrar imzalayın.
- Çıktıyı PPTX formatında tutun. İmzalı bir sunumu başka bir formata dönüştürmek, orijinal PPTX imzasını geçerli bir imza olarak yeni dosyaya aktarmaz.
- Sertifikanın özel anahtarını hassas bir veri olarak tutun. Özel anahtar ve parolasını elde eden herkes, o sertifika sahibinden geliyormuş gibi imzalar oluşturabilir.
- Belge saklama politikanız gerektiriyorsa, imzasız kaynağı ya da başka bir kontrollü kopyayı saklayın.

## **SSS**

**Dijital bir imza sunumu şifreler mi?**

Hayır. Dijital bir imza, kaynağın ve bütünlüğün kanıtını sağlar, ancak içerik ayrı bir şifreleme uygulanmadıkça okunabilir kalır. İçeriğe erişimin kısıtlanması gerektiğinde [parola korumasını](/slides/tr/net/password-protected-presentation/) kullanın.

**PFX parolası sunum parolasıyla aynı mı?**

Hayır. PFX parolası, sertifika paketindeki özel anahtarı açar. PPTX dosyasını kimlerin açıp düzenleyebileceğini kontrol etmez.

**Kendinden imzalı bir sertifika kullanabilir miyim?**

Teknik olarak, erişilebilir bir özel anahtar içeriyorsa kendinden imzalı bir sertifika kullanılabilir. Alıcılar otomatik olarak güvenmez; bu sertifikanın güvenilir bir ortama açıkça eklenmesi gerekir. Genel veya kurumlar arası iş akışları genellikle güvenilir bir CA tarafından verilen sertifikaları tercih eder.

**Bir imzayı geçersiz kılan nedir?**

İmzalı sunum içeriğini veya imza verilerini imzalama sonrasında değiştirmek imzayı geçersiz kılar. Dosya bozulması da doğrulamayı başarısız kılabilir. Tüm imzalar kaldırılırsa, sunum imzasız olur; geçersiz bir imza içermez.

**Geçerli bir imza, imzalayan kişiye güvenmem gerektiği anlamına mı gelir?**

Tek başına değil. İmza bütünlüğü ve imzalayanın güvenilirliği ayrı kararlar alınır. Üretim doğrulama politikası, ayrıca sertifika zinciri, geçerlilik süresi, iptal durumu, beklenen kimlik, anahtar kullanımı ve güvenilir zaman damgası gereksinimlerini kontrol etmelidir.

**Sertifika süresi dolduğunda ne olur?**

Sertifika süresi dolması sunum dosyasının baytlarını değiştirmez, ancak sertifika güven değerlendirmesini etkiler. Bir imzanın kabul edilebilirliği, politikalarınıza ve geçerli bir güvenilir zaman damgasının, imzalamanın sertifikanın geçerli olduğu süre içinde gerçekleştiğini kanıtlayıp kanıtlamadığına bağlıdır. Görüntülenen imzalama zamanına yalnızca güvenilir bir zaman damgası olarak güvenmeyin.

**İmzalı bir sunum hâlâ düzenlenebilir mi?**

Evet. İmza dosyayı kilitlemez. İmzalı içeriği düzenlemek genellikle mevcut imzayı geçersiz kılar; bu yüzden önce sunumu tamamlayıp ardından son revizyonu imzalayın.

**Bir sunum birden fazla imza içerebilir mi?**

Evet. Kaydetmeden önce her imzayı [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/digitalsignatures/) koleksiyonuna ekleyin. Doğrulama sırasında, her imzayı inceleyin ve gerekli tüm imzalayanların mevcut olduğunu doğrulayın.

**Hangi sunum formatları bu işlemleri destekler?**

Aspose.Slides, burada açıklanan dijital imza işlemlerini yalnızca PPTX için destekler. PPT ve OpenDocument sunum formatları bu API iş akışı tarafından desteklenmez.

**Bir imzayı slaytları etkilemeden kaldırabilir miyim?**

Evet. Tek bir imzayı kaldırabilir veya tüm koleksiyonu temizleyebilir ve ardından sunumu kaydedebilirsiniz. Slayt içeriği kullanılabilir kalır, ancak kaydedilen dosya artık kaldırılan imza kanıtını taşımaz.