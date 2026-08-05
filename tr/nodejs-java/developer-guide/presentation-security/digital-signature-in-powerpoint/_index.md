---
title: JavaScript'te Sunumlara Dijital İmzalar Ekleme
linktitle: Dijital İmza
type: docs
weight: 10
url: /tr/nodejs-java/digital-signature-in-powerpoint/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "PFX sertifikalarıyla mevcut PPTX sunumlarını nasıl imzalayacağınızı ve Node.js için Aspose.Slides'ı Java aracılığıyla dijital imzaları doğrulamak veya kaldırmak için nasıl kullanacağınızı öğrenin."
---
## **Genel Bakış**

Dijital imza, alıcının bir sunumu kimin imzaladığını ve imzalı içeriğin değişip değişmediğini belirlemesine yardımcı olur. Burada üç ilgili güvenlik kavramı önemlidir:

- **Dijital sertifika**, bir kimliği bir açık anahtarla ilişkilendiren elektronik bir kimlik belgesidir. Güvenilir bir sertifika yetkilisi (CA) bir sertifika düzenleyebilir veya bir organizasyon dahili iş akışları için kendinden imzalı bir sertifika kullanabilir.
- **Dijital imza**, sunum içeriği ve sertifika sahibinin özel anahtarı kullanılarak oluşturulur. Sertifikanın açık anahtarı daha sonra imzayı doğrulamak için kullanılabilir. İmza, kaynağın ve bütünlüğün kanıtını sağlar; sunumu şifrelemez.
- **Şifre koruması**, bir kullanıcının bir sunumu açıp açamayacağını veya değiştirebileceğini kontrol eder. Dijital imzalama ile ayrı bir konudur ve [Şifre Koruması ile Sunumlar](/nodejs-java/password-protected-presentation/) bölümünde açıklanmıştır.

PowerPoint, **Dosya > Bilgi > Sunumu Koru** altında **Dijital İmza Ekle** komutunu sunar.

![PowerPoint Sunumu Koru menüsü, Dijital İmza Ekle vurgulanmış](add-digital-signature-in-powerpoint.png)

İmzalı bir sunum açıldıktan sonra, PowerPoint bir imza durumu bildirimi gösterebilir.

![PowerPoint bildirimi, sunumun geçerli imzalar içerdiğini belirtiyor](digital-signature-status-in-powerpoint.png)

Aspose.Slides, imzaları [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) aracılığıyla açığa çıkarır; bu, [DigitalSignatureCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/digitalsignaturecollection/) içinde [DigitalSignature](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/digitalsignature/) nesneleri döndürür. Bir sunum birden fazla imza içerebilir.

## **PFX Sertifikalarını ve Şifreleri Anlamak**

PFX dosyası, PKCS#12 dosyası olarak da bilinir ve genellikle `.pfx` veya `.p12` uzantısına sahiptir; X.509 sertifikası, özel anahtarı ve sertifika zincirini içerebilir. Özel anahtar, sahibine bir imza oluşturma imkanı sağlar. Erişilebilir bir özel anahtarı olmayan bir sertifika, bir sunumu imzalamak için kullanılamaz.

PFX şifresi, sertifika paketini ve özel anahtarı korur. Sunumu açmak veya düzenlemek için bir şifre **değildir**. PFX dosyalarını veya şifrelerini kaynak kontrolüne yüklemeyin. Üretim ortamında, sertifika dosyasına erişimi sınırlayın ve şifresini bir gizli depodan veya başka bir korumalı yapılandırma kaynağından alın. Aşağıdaki örnekler, şifreyi koda gömmekten kaçınmak için yalnızca bir ortam değişkeni kullanır.

## **Bir Sunuma Dijital İmza Ekleme**

Gerçek bir sunum iş akışını imzalamak için, mevcut bir PPTX dosyasını yükleyin, bir PFX sertifikası ve şifresinden bir [DigitalSignature](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/digitalsignature/) oluşturun, imzayı sunumun koleksiyonuna ekleyin ve bir PPTX dosyasına kaydedin.

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

Sonucu yeni bir ad altında kaydetmek, imzasız kaynak dosyasını korur. [DigitalSignature.setComments](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/digitalsignature/) ile ayarlanan değer, imzanın amacını açıklar; bu bir güvenlik kontrolü değildir.

## **Dijital İmzaları Doğrulama**

İmzalı bir PPTX dosyasını yüklediğinizde, [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) tarafından döndürülen her öğeyi inceleyin. [DigitalSignature.isValid](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/digitalsignature/) yöntemi, gömülü imzanın mevcut sunum içeriği için geçerli olup olmadığını gösterir.

Aşağıdaki örnek, her gömülü sertifikadan konu adını okumak için Node.js `X509Certificate` sınıfını da kullanır.

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

Geçersiz bir sonuç genellikle imzalı sunum içeriğinin veya imza verilerinin imzalamadan sonra değiştiği veya dosyanın bozulmuş olduğu anlamına gelir. Tüm imzaların kaldırılması imzasız bir sunum üretir; bu yüzden yalnızca öğelerin geçerliliğini kontrol etmek yeterli değildir: güvenlik açısından hassas bir iş akışı, beklenen imza sayısının ve beklenen imzalayan kimliklerin de mevcut olduğunu doğrulamalıdır.

Bu geçerlilik sonucu, tam bir sertifika güven kararı olarak ele alınmamalıdır. Güvenlik politikanıza bağlı olarak, uygulamanız X.509 sertifika zincirini oluşturup doğrulamalı, sertifika geçerlilik tarihlerini ve iptal durumunu kontrol etmeli, beklenen konu veya parmak izini onaylamalı, anahtar kullanımını doğrulamalı ve güvenilir bir zaman damgasını değerlendirmelidir. [DigitalSignature.getSignTime](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/digitalsignature/) değeri tek başına güvenilir bir zaman damgası otoritesinden kanıt değildir.

## **Dijital İmzaları Kaldırma**

İmzaları kaldırmak, sunumun güvenlik durumunu değiştirir. Aşağıdaki örnek, imzalı bir PPTX dosyasını yükler, [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/digitalsignaturecollection/clear/) ile tüm imzaları kaldırır ve imzasız bir kopya kaydeder.

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

Yalnızca bir imzayı kaldırmak için, sıfır tabanlı diziniyle [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) metodunu çağırın. İş akışınızın açık bir parçası olarak imzalı orijinali üzerine yazmadığınız sürece yeni bir dosyaya kaydedin.

## **Düzenleme ve Biçim Hususları**

- Bir imza, bir sunumu salt okunur yapmaz. Kullanıcılar ve uygulamalar dosyayı hâlâ düzenleyebilir, ancak imzalı içeriğe yapılan değişiklikler genellikle mevcut imzayı geçersiz kılar.
- İmzalamadan önce tüm planlanan düzenlemeleri tamamlayın. Sunumun değiştirilmesi gerekiyorsa, revize edilmiş sunumu kaydedin ve bu revizyonu yeniden imzalayın.
- Son çıktıyı PPTX formatında tutun. İmzalı bir sunumu başka bir formata dönüştürmek, orijinal PPTX imzasını dönüştürülmüş dosya için geçerli bir imza olarak taşımaz.
- Sertifikanın özel anahtarını hassas bir veri olarak ele alın. Özel anahtarı ve şifresini elde eden herkes, o sertifika sahibinden gelmiş gibi görünen imzalar oluşturabilir.
- Belge saklama politikanız gerektirdiğinde imzasız kaynağı veya başka bir kontrol edilmiş kopyayı koruyun.

## **SSS**

**Dijital imza sunumu şifreler mi?**

Hayır. Dijital imza, kaynağın ve bütünlüğün kanıtını sağlar, ancak ayrı bir şifreleme uygulanmadıkça sunum içeriği okunabilir kalır. İçeriğe erişimin kısıtlanması gerektiğinde [şifre koruması](/nodejs-java/password-protected-presentation/) kullanın.

**PFX şifresi, bir sunum şifresiyle aynı mı?**

Hayır. PFX şifresi, sertifika paketinde depolanan özel anahtarın kilidini açar. PPTX dosyasını kimlerin açıp düzenleyebileceğini kontrol etmez.

**Kendinden imzalı bir sertifika kullanabilir miyim?**

Teknik olarak, erişilebilir bir özel anahtar içeriyorsa kendinden imzalı bir sertifika kullanılabilir. Ancak alıcılar, bu sertifika güvenilir ortamlarına açıkça eklenmediği sürece otomatik olarak güvenmezler. Kamu veya kuruluşlar arası iş akışları genellikle güvenilir bir CA tarafından verilen bir sertifika kullanır.

**Bir imzayı geçersiz kılan nedir?**

İmzalı sunum içeriğini veya imza verilerini imzalama sonrası değiştirmek imzayı geçersiz kılar. Dosya bozulması da doğrulamanın başarısız olmasına neden olabilir. Tüm imzalar kaldırılırsa, sunum geçersiz bir imza içeren bir dosya değil, imzasız olur.

**Geçerli bir imza, imzalayanına güvenmem gerektiği anlamına mı geliyor?**

Yalnız başına değildir. İmza bütünlüğü ve imzalayanın güvenilirliği ayrı kararlar gerektirir. Üretim doğrulama politikası ayrıca sertifika zincirini, geçerlilik süresini, iptal durumunu, beklenen kimliği, anahtar kullanımını ve güvenilir zaman damgası gereksinimlerini kontrol etmelidir.

**Sertifika süresi dolduğunda ne olur?**

Sertifikanın süresi dolması sunum baytlarını değiştirmez, ancak sertifika güven değerlendirmesini etkiler. Bir imzanın kabul edilebilir olup olmadığı, politikanıza ve geçerli bir güvenilir zaman damgasının imzalamanın sertifikanın geçerli olduğu sürede gerçekleştiğini kanıtlayıp kanıtlamadığına bağlıdır. Görüntülenen imzalama zamanına yalnızca güvenilir bir zaman damgası olarak güvenmeyin.

**İmzalı bir sunum hâlâ düzenlenebilir mi?**

Evet. İmzalamak dosyayı kilitlemez. İmzalı içeriği düzenlemek genellikle mevcut imzayı geçersiz kılar; bu yüzden önce sunumu tamamlayın ve son revizyonu imzalayın.

**Bir sunum birden fazla imza içerebilir mi?**

Evet. Kaydetmeden önce her imzayı [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) tarafından döndürülen koleksiyona ekleyin. Doğrulama sırasında her imzayı inceleyin ve tüm gerekli imzalayanların mevcut olduğunu doğrulayın.

**Hangi sunum formatları bu işlemleri destekler?**

Aspose.Slides, burada açıklanan dijital imza işlemlerini yalnızca PPTX için destekler. PPT ve OpenDocument sunum formatları bu API iş akışıyla desteklenmez.

**Bir imzayı slaytlara zarar vermeden kaldırabilir miyim?**

Evet. Tek bir imzayı kaldırabilir veya tüm koleksiyonu temizleyip ardından sunumu kaydedebilirsiniz. Slayt içeriği kullanılabilir olur, ancak kaydedilen dosyada artık kaldırılan imza kanıtı bulunmaz.