---
title: Java'da Sunumlara Dijital İmza Eklemek
linktitle: Dijital İmza
type: docs
weight: 10
url: /tr/java/digital-signature-in-powerpoint/
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
- Java
- Aspose.Slides
description: "PFX sertifikalarıyla mevcut PPTX sunumlarını nasıl imzalayacağınızı ve Aspose.Slides for Java ile dijital imzaları doğrulama veya kaldırma işlemlerini öğrenin."
---
## **Genel Bakış**

Dijital imza, alıcının bir sunumu kimin imzaladığını ve imzalı içeriğin değişip değişmediğini belirlemesine yardımcı olur. Burada üç ilgili güvenlik kavramı önemlidir:

- **Dijital sertifika**, bir kimliği bir açık anahtarla ilişkilendiren elektronik bir kimlik bilgisi olarak tanımlanır. Güvenilir bir sertifika otoritesi (CA) sertifika verebilir ya da bir kuruluş, dahili iş akışları için kendinden imzalı bir sertifika kullanabilir.
- **Dijital imza**, sunum içeriği ve sertifika sahibinin özel anahtarıyla oluşturulur. Sertifikanın açık anahtarı daha sonra imzayı doğrulamak için kullanılabilir. İmza, kaynağın ve bütünlüğün kanıtını sağlar; sunumu şifrelemez.
- **Parola koruması**, bir kullanıcının bir sunumu açıp açamayacağını veya değiştirebileceğini kontrol eder. Bu, dijital imzalamadan ayrı bir özelliktir ve [Parola Koruması ile Sunumlar](/slides/tr/java/password-protected-presentation/) bölümünde açıklanmıştır.

PowerPoint, **Dosya > Bilgi > Sunumu Koru** menüsü altında **Dijital İmza Ekle** komutunu sağlar.

![PowerPoint Sunumu Koru menüsü, Dijital İmza Ekle vurgulanmış](add-digital-signature-in-powerpoint.png)

İmzalı bir sunum açıldıktan sonra, PowerPoint bir imza‑durumu bildirimi gösterebilir.

![PowerPoint bildirimi, sunumun geçerli imzalar içerdiğini belirtiyor](digital-signature-status-in-powerpoint.png)

Aspose.Slides, imzaları [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) aracılığıyla sunar; bu yöntem bir [IDigitalSignatureCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idigitalsignaturecollection/) döndürür ve öğeleri [IDigitalSignature](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idigitalsignature/) arayüzünü uygular. Bir sunum birden çok imza içerebilir.

## **PFX Sertifikaları ve Parolaları Anlamak**

`.pfx` veya `.p12` uzantılı bir PFX dosyası (PKCS#12 dosyası olarak da bilinir), bir X.509 sertifikası, bunun özel anahtarı ve sertifika zincirini içerebilir. Özel anahtar, imzayı oluşturmayı sağlayan bileşendir. Erişilebilir bir özel anahtarı olmayan bir sertifika, bir sunumu imzalamak için kullanılamaz.

PFX parolası, sertifika paketini ve özel anahtarı korur. Bu, sunumu açmak veya düzenlemek için kullanılan bir parola **değildir**. PFX dosyalarını veya parolalarını kaynak kontrolüne göndermeyin. Üretim ortamında, sertifika dosyasına erişimi kısıtlayın ve parolasını gizli bir depodan veya başka bir korumalı yapılandırma kaynağından alın. Aşağıdaki örneklerde parola yalnızca kod içinde gömmekten kaçınmak için bir ortam değişkeni olarak kullanılmıştır.

## **Sunuma Dijital İmza Ekleme**

Gerçek bir sunum iş akışını imzalamak için mevcut bir PPTX dosyasını yükleyin, bir PFX sertifikası ve parolasından bir [DigitalSignature](https://reference.aspose.com/slides/tr/java/com.aspose.slides/digitalsignature/) oluşturun, imzayı sunumun koleksiyonuna ekleyin ve bir PPTX dosyasına kaydedin.

```java
String certificatePassword = System.getenv("PFX_PASSWORD");
if (certificatePassword == null || certificatePassword.isEmpty()) {
    throw new IllegalStateException("Set the PFX_PASSWORD environment variable.");
}

Presentation presentation = new Presentation("InputPresentation.pptx");
try {
    DigitalSignature signature = new DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonucu yeni bir adla kaydetmek, imzasız kaynak dosyasını korur. [IDigitalSignature.setComments](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) yöntemiyle ayarlanan değer, imzanın amacını açıklar; güvenlik kontrolü değildir.

## **Dijital İmzaları Doğrulama**

İmzalı bir PPTX dosyasını yüklediğinizde, [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) tarafından döndürülen her öğeyi inceleyin. [IDigitalSignature.isValid](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idigitalsignature/#isValid--) yöntemi, gömülü imzanın mevcut sunum içeriği için geçerli olup olmadığını gösterir.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    IDigitalSignatureCollection signatures = presentation.getDigitalSignatures();
    int signatureCount = signatures.size();

    if (signatureCount == 0) {
        System.out.println("The presentation does not contain digital signatures.");
    } else {
        boolean allSignaturesAreValid = true;
        java.text.SimpleDateFormat signTimeFormat = new java.text.SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        java.security.cert.CertificateFactory certificateFactory = java.security.cert.CertificateFactory.getInstance("X.509");

        for (IDigitalSignature signature : signatures) {
            boolean signatureIsValid = signature.isValid();
            String signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            java.util.Date signTime = signature.getSignTime();
            String formattedSignTime = signTimeFormat.format(signTime);

            byte[] certificateData = signature.getCertificate();
            java.io.ByteArrayInputStream certificateStream = new java.io.ByteArrayInputStream(certificateData);
            java.security.cert.X509Certificate certificate = (java.security.cert.X509Certificate) certificateFactory.generateCertificate(certificateStream);
            javax.security.auth.x500.X500Principal signerPrincipal = certificate.getSubjectX500Principal();
            String signerName = signerPrincipal.getName();

            System.out.println(signerName + ", " + formattedSignTime + " -- " + signatureStatus);

            allSignaturesAreValid &= signatureIsValid;
        }

        if (allSignaturesAreValid) {
            System.out.println("All embedded signatures are valid for the current presentation.");
        } else {
            System.out.println("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

Geçersiz bir sonuç, genellikle imzalı içerik veya imza verilerinin imzalama sonrası değiştiği ya da dosyanın hasar gördüğü anlamına gelir. Tüm imzaları kaldırmak imzasız bir sunum üretir; bu nedenle yalnızca öğelerin geçerliliğini kontrol etmek yeterli değildir: güvenlik açısından hassas bir iş akışı, beklenen imza sayısının ve beklenen imzalayan kimliklerin mevcut olduğunu da doğrulamalıdır.

Bu geçerlilik sonucu, tam bir sertifika‑güven kararı olarak değerlendirilmemelidir. Güvenlik politikanıza bağlı olarak uygulamanız, X.509 sertifika zincirini oluşturup doğrulamalı, sertifikanın geçerlilik tarihlerini ve iptal durumunu kontrol etmeli, beklenen konu adını veya parmak izini teyit etmeli, anahtar kullanımını doğrulamalı ve güvenilir bir zaman damgasını değerlendirmelidir. [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idigitalsignature/#getSignTime--) değeri tek başına güvenilir bir zaman damgası otoritesinden kanıt teşkil etmez.

## **Dijital İmzaları Kaldırma**

İmzaları kaldırmak, sunumun güvenlik durumunu değiştirir. Aşağıdaki örnek, imzalı bir PPTX dosyasını yükler, tüm imzaları [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idigitalsignaturecollection/#clear--) ile temizler ve imzasız bir kopya kaydeder.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sadece bir imzayı kaldırmak için, sıfır‑tabanlı indeksiyle [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) yöntemini kullanın. İmzalı orijinali üzerine yazmak iş akışınızın açık bir parçası değilse, yeni bir dosyaya kaydedin.

## **Düzenleme ve Biçim Düşünceleri**

- Bir imza, bir sunumu yalnızca okuma‑yalnızına dönüştürmez. Kullanıcılar ve uygulamalar dosyayı hâlâ düzenleyebilir, ancak imzalı içeriğe yapılan değişiklikler genellikle mevcut imzayı geçersiz kılar.
- İmzalamadan önce tüm istenen düzenlemeleri tamamlayın. Sunumun değiştirilmesi gerekiyorsa, revize edilmiş sunumu kaydedin ve bu revizyonu yeniden imzalayın.
- Çıktıyı PPTX biçiminde tutun. İmzalı bir sunumu başka bir biçime dönüştürmek, orijinal PPTX imzasını dönüştürülmüş dosya için geçerli bir imza olarak taşımaz.
- Sertifikanın özel anahtarını hassas bir veri olarak tutun. Özel anahtarı ve parolasını elde eden herkes, bu sertifika sahibinden gelmiş gibi görünecek imzalar oluşturabilir.
- Doküman saklama politikanız gerektiriyorsa, imzasız kaynağı veya başka bir kontrol edilen kopyayı koruyun.

## **SSS**

**Bir dijital imza sunumu şifreler mi?**

Hayır. Dijital imza, kaynağın ve bütünlüğün kanıtını sağlar, ancak sunum içeriği ayrı bir şifreleme uygulanmadıkça okunabilir kalır. İçeriğe erişimin kısıtlanması gerektiğinde [parola koruması](/slides/tr/java/password-protected-presentation/) kullanın.

**PFX parolası sunum parolasıyla aynı mı?**

Hayır. PFX parolası, sertifika paketindeki özel anahtarı açar. PPTX dosyasını kimlerin açıp düzenleyebileceğini kontrol etmez.

**Kendinden imzalı bir sertifika kullanabilir miyim?**

Teknik olarak, erişilebilir bir özel anahtar içeriyorsa kendinden imzalı bir sertifika kullanılabilir. Alıcılar otomatik olarak güvenmez; ancak sertifika açıkça güvenilir ortama eklenmişse güvenilir olur. Genel veya çapraz‑kurum iş akışları genellikle güvenilir bir CA tarafından verilen bir sertifika kullanır.

**Bir imzayı geçersiz kılan nedir?**

İmzalı sunum içeriğini veya imza verilerini imzalama sonrası değiştirmek imzayı geçersiz kılar. Dosya bozulması da doğrulamanın başarısız olmasına yol açabilir. Tüm imzalar kaldırılırsa, sunum imzasız olur; geçersiz bir imza içermez.

**Geçerli bir imza, imzalayanı güvenmem gerektiği anlamına mı gelir?**

Tek başına hayır. İmza bütünlüğü ve imzalayan güveni ayrı kararlardır. Üretim doğrulama politikanız ayrıca sertifika zincirini, geçerlilik süresini, iptal durumunu, beklenen kimliği, anahtar kullanımını ve güvenilir zaman damgası gereksinimlerini kontrol etmelidir.

**Sertifika süresi dolduğunda ne olur?**

Sertifikanın süresi dolması, sunum baytlarını değiştirmez, ancak sertifika‑güven değerlendirmesini etkiler. Bir imzanın hâlâ kabul edilebilir olup olmadığı, politikanıza ve geçerli bir güvenilir zaman damgasının imzalamanın sertifika geçerli olduğu sırada gerçekleştiğini kanıtlayıp kanıtlamadığına bağlıdır. Gösterilen imzalama zamanına tek başına güvenmeyin.

**İmzalı bir sunum hâlâ düzenlenebilir mi?**

Evet. İmzalama dosyayı kilitlemez. İmzalı içeriği düzenlemek genellikle mevcut imzayı geçersiz kılar; bu yüzden önce sunumu tamamlayın ve son revizyonu imzalayın.

**Bir sunum birden fazla imza içerebilir mi?**

Evet. Kaydetmeden önce **IPresentation.getDigitalSignatures** tarafından döndürülen koleksiyona her bir imzayı ekleyin. Doğrulama sırasında her imzayı inceleyin ve tüm gerekli imzalayanların mevcut olduğunu teyit edin.

**Hangi sunum biçimleri bu işlemleri destekler?**

Aspose.Slides, burada açıklanan dijital‑imza işlemlerini yalnızca PPTX için destekler. PPT ve OpenDocument sunum biçimleri bu API iş akışıyla desteklenmez.

**Bir imzayı slaytları etkilemeden kaldırabilir miyim?**

Evet. Tek bir imzayı kaldırabilir veya tüm koleksiyonu temizleyebilir ve ardından sunumu kaydedebilirsiniz. Slayt içeriği mevcut kalır, ancak kaydedilen dosyada kaldırılan imza kanıtı bulunmaz.