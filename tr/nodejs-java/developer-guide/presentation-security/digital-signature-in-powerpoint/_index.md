---
title: JavaScript'te Sunumlara Dijital İmzalar Ekleme
linktitle: Dijital İmza
type: docs
weight: 10
url: /tr/nodejs-java/digital-signature-in-powerpoint/
keywords:
- dijital imza
- dijital sertifika
- sertifika yetkilisi
- PFX sertifikası
- PKCS#12
- imzayı doğrulama
- PowerPoint
- PPTX
- sunum güvenliği
- Node.js
- JavaScript
- Aspose.Slides
description: "PFX sertifikalarıyla mevcut PPTX sunumlarını nasıl imzalayacağınızı ve Aspose.Slides for Node.js'i Java aracılığıyla dijital imzaları doğrulamak veya kaldırmak için nasıl kullanacağınızı öğrenin."
---
## **Genel Bakış**

Bir dijital imza, alıcının bir sunumu kimin imzaladığını ve imzalı içeriğin değişip değişmediğini belirlemesine yardımcı olur. Burada üç ilgili güvenlik kavramı önemlidir:

- **dijital sertifika**, bir kimliği bir açık anahtarla ilişkilendiren elektronik bir kimlik belgesidir. Güvenilir bir sertifika yetkilisi (CA) bir sertifika yayınlayabilir veya bir kuruluş dahili iş akışları için kendinden imzalı bir sertifika kullanabilir.
- **dijital imza**, sunum içeriği ve sertifika sahibinin özel anahtarıyla oluşturulur. Sertifikanın açık anahtarı daha sonra imzayı doğrulamak için kullanılabilir. Bir imza, kaynağın ve bütünlüğün kanıtını sağlar; sunumu şifrelemez.
- **Parola koruması**, bir kullanıcının bir sunumu açıp değiştirebilmesini kontrol eder. Bu, dijital imzalamadan ayrı bir konudur ve [Parola Korumalı Sunumlar](/slides/tr/nodejs-java/password-protected-presentation/) bölümünde açıklanmıştır.

PowerPoint, **Dosya > Bilgi > Sunumu Koru** altında **Dijital İmza Ekle** komutunu sağlar.

![PowerPoint Koruma Sunumu menüsü, Dijital İmza Ekle vurgulanmış halde](add-digital-signature-in-powerpoint.png)

İmzalı bir sunum açıldıktan sonra PowerPoint, bir imza durumu bildirimi gösterebilir.

![PowerPoint bildirimi, sunumun geçerli imzalar içerdiğini belirtiyor](digital-signature-status-in-powerpoint.png)

Aspose.Slides, imzaları [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) aracılığıyla ortaya çıkarır; bu yöntem, [DigitalSignatureCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/digitalsignaturecollection/) içinde [DigitalSignature](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/digitalsignature/) nesnelerini döndürür. Bir sunum birden çok imza içerebilir.

## **PFX Sertifikalarını ve Parolaları Anlamak**

PFX dosyası, PKCS#12 dosyası olarak da bilinir ve genellikle `.pfx` veya `.p12` uzantısına sahiptir; bir X.509 sertifikası, özel anahtarı ve sertifika zincirini içerebilir. Özel anahtar, sahibi tarafından bir imza oluşturulmasını sağlar. Erişilebilir bir özel anahtarı olmayan bir sertifika, bir sunumu imzalamak için kullanılamaz.

PFX parolası, sertifika paketini ve özel anahtarı korur. Bu, sunumu açmak veya düzenlemek için kullanılan bir parola **değildir**. PFX dosyalarını veya parolalarını kaynak kontrolüne göndermeyin. Üretim ortamında, sertifika dosyasına erişimi sınırlayın ve parolasını bir gizli depodan veya başka bir korumalı yapılandırma kaynağından alın. Aşağıdaki örneklerde, parolayı koda gömmekten kaçınmak için yalnızca bir ortam değişkeni kullanılmıştır.

## **Sunuma Dijital İmza Ekleme**

Gerçek bir sunum iş akışını imzalamak için mevcut bir PPTX dosyasını yükleyin, PFX sertifikasından ve parolasından bir [DigitalSignature](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/digitalsignature/) oluşturun, imzayı sunumun koleksiyonuna ekleyin ve bir PPTX dosyasına kaydedin.

```javascript
const slides = require("aspose.slides.via.java");

const certificatePassword = process.env.PFX_PASSWORD;
if (!certificatePassword) {
    throw new Error("Set the PFX_PASSWORD environment variable.");
}

const presentation = new slides.Presentation("InputPresentation.pptx");
try {
    const signature = new slides.DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonucu yeni bir ad altında kaydetmek, imzasız kaynak dosyasını korur. [DigitalSignature.setComments](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/digitalsignature/) tarafından ayarlanan değer, imzanın amacını açıklar; bu bir güvenlik kontrolü değildir.

## **Dijital İmzaları Doğrulama**

İmzalı bir PPTX dosyasını yüklediğinizde, [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) tarafından döndürülen her öğeyi inceleyin. [DigitalSignature.isValid](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/digitalsignature/) yöntemi, gömülü imzanın mevcut sunum içeriği için geçerli olup olmadığını gösterir.

Aşağıdaki örnek ayrıca, her gömülü sertifikadan konu adını okumak için Node.js `X509Certificate` sınıfını kullanır.

```javascript
const { X509Certificate } = require("node:crypto");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    const signatures = presentation.getDigitalSignatures();
    const signatureCount = signatures.size();

    if (signatureCount === 0) {
        console.log("The presentation does not contain digital signatures.");
    } else {
        let allSignaturesAreValid = true;

        for (let index = 0; index < signatureCount; index++) {
            const signature = signatures.get_Item(index);
            const signatureIsValid = signature.isValid();
            const signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            const signTime = signature.getSignTime().toString();

            const certificateData = signature.getCertificate();
            const certificate = new X509Certificate(Buffer.from(certificateData));
            const signerName = certificate.subject;

            console.log(`${signerName}, ${signTime} -- ${signatureStatus}`);

            allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
        }

        if (allSignaturesAreValid) {
            console.log("All embedded signatures are valid for the current presentation.");
        } else {
            console.log("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

Geçersiz bir sonuç, genellikle imzalı sunum içeriği ya da imza verisinin imzalama sonrası değiştiği ya da dosyanın bozulduğu anlamına gelir. Tüm imzaları kaldırmak, imzasız bir sunum üretir; bu yüzden yalnızca öğelerin geçerliliğini kontrol etmek yeterli değildir: güvenlik açısından hassas bir iş akışı, beklenen imza sayısının ve beklenen imzalayan kimliklerinin mevcut olduğunu da doğrulamalıdır.

Bu geçerlilik sonucu, tam bir sertifika‑güven kararı olarak değerlendirilmemelidir. Güvenlik politikanıza bağlı olarak, uygulamanız X.509 sertifika zincirini oluşturup doğrulamalı, sertifika geçerlilik tarihlerini ve iptal durumunu kontrol etmeli, beklenen konu ya da parmak izini onaylamalı, anahtar kullanımını doğrulamalı ve güvenilir bir zaman damgasını değerlendirmelidir. [DigitalSignature.getSignTime](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/digitalsignature/) değeri tek başına güvenilir bir zaman damgası otoritesinden gelen bir kanıt değildir.

## **Dijital İmzaları Kaldırma**

İmzaları kaldırmak, sunumun güvenlik durumunu değiştirir. Aşağıdaki örnek bir imzalı PPTX dosyasını yükler, tüm imzaları [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/digitalsignaturecollection/clear/) ile kaldırır ve imzasız bir kopya kaydeder.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Yalnızca bir imzayı kaldırmak için, sıfır‑tabanlı diziniyle birlikte [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) yöntemini çağırın. Imzalı orijinali üzerine yazma, iş akışınızın açık bir parçası değilse, yeni bir dosyaya kaydedin.

## **Düzenleme ve Biçim Düşünceleri**

- Bir imza, bir sunumu salt okunur hâle getirmez. Kullanıcılar ve uygulamalar dosyayı hâlâ düzenleyebilir, ancak imzalı içeriğe yapılan değişiklikler genellikle mevcut imzayı geçersiz kılar.
- İmzalamadan önce tüm planlanan düzenlemeleri tamamlayın. Sunumun değiştirilmesi gerekiyorsa, revize edilmiş sunumu kaydedip bu revizyonu tekrar imzalayın.
- Nihai çıktıyı PPTX biçiminde tutun. İmzalı bir sunumu başka bir formata dönüştürmek, orijinal PPTX imzasını dönüştürülmüş dosya için geçerli bir imza olarak taşımaz.
- Sertifikanın özel anahtarını hassas bir veri olarak tutun. Özel anahtarı ve parolasını elde eden herkes, o sertifika sahibinden geliyormuş gibi imzalar oluşturabilir.
- Belgelerin saklanma politikanız gerektiriyorsa, imzasız kaynağı veya başka bir kontrollü kopyayı saklayın.

## **SSS**

**Bir dijital imza sunumu şifreler mi?**

Hayır. Dijital imza, kaynağın ve bütünlüğün kanıtını sağlar, ancak içerik ayrı bir şifreleme uygulanmadıkça okunabilir durumda kalır. İçeriğe erişimin kısıtlanması gerektiğinde [parola korumasını](/slides/tr/nodejs-java/password-protected-presentation/) kullanın.

**PFX parolası sunum parolasıyla aynı mı?**

Hayır. PFX parolası, sertifika paketindeki özel anahtarı açar. PPTX dosyasını kimlerin açabileceğini veya düzenleyebileceğini kontrol etmez.

**Kendinden imzalı bir sertifika kullanabilir miyim?**

Teknik olarak, erişilebilir bir özel anahtar içeriyorsa kendinden imzalı bir sertifika kullanılabilir. Alıcılar otomatik olarak güvenmez; sertifikanın güvenilir ortamlarına açıkça eklenmesi gerekir. Genel ya da çapraz‑kurumsal iş akışları genellikle güvenilir bir CA tarafından verilmiş bir sertifika kullanır.

**Bir imzayı geçersiz kılan nedir?**

İmzalı sunum içeriğini veya imza verisini imzalama sonrası değiştirmek imzayı geçersiz kılar. Dosya bozulması da doğrulamanın başarısız olmasına yol açabilir. Tüm imzalar kaldırıldığında, sunum imzasız olur; bu bir geçersiz imza değildir.

**Geçerli bir imza, imzalayan kişiye güvenmem gerektiği anlamına mı gelir?**

Tek başına hayır. İmza bütünlüğü ve imzalayanın güvenilirliği ayrı kararlardır. Üretim doğrulama politikası ayrıca sertifika zincirini, geçerlilik süresini, iptal durumunu, beklenen kimliği, anahtar kullanımını ve gerekli güvenilir zaman damgası gereksinimlerini kontrol etmelidir.

**Sertifika süresi dolduğunda ne olur?**

Sertifikanın süresi dolması, sunumun baytlarını değiştirmez, ancak sertifika‑güven değerlendirmesini etkiler. Bir imzanın kabul edilebilirliği, politikanıza ve geçerli bir güvenilir zaman damgasının, imzalamanın sertifika geçerli iken gerçekleştirildiğini kanıtlayıp kanıtlamadığına bağlıdır. Tek başına görüntülenen imzalama zamanına güvenilir bir zaman damgası olarak güvenmemelisiniz.

**İmzalı bir sunum hâlâ düzenlenebilir mi?**

Evet. İmzalama dosyayı kilitlemez. İmzalı içeriği düzenlemek genellikle mevcut imzayı geçersiz kılar; bu yüzden sunumu önce tamamlayıp ardından son revizyonu imzalayın.

**Bir sunum birden çok imza içerebilir mi?**

Evet. Kaydetmeden önce her imzayı [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) tarafından döndürülen koleksiyona ekleyin. Doğrulama sırasında, her imzayı inceleyin ve gerekli tüm imzalayanların mevcut olduğunu onaylayın.

**Hangi sunum biçimleri bu işlemleri destekler?**

Aspose.Slides, burada açıklanan dijital‑imza işlemlerini yalnızca PPTX için destekler. PPT ve OpenDocument sunum biçimleri bu API iş akışı tarafından desteklenmez.

**Bir imzayı slaytları etkilemeden kaldırabilir miyim?**

Evet. Tek bir imzayı kaldırabilir veya tüm koleksiyonu temizleyip ardından sunumu kaydedebilirsiniz. Slayt içeriği kullanılabilir kalır, ancak kaydedilen dosyada kaldırılan imza kanıtı bulunmaz.