---
title: Java'da Sunumlara Dijital İmzalar Ekleme
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
description: "PFX sertifikalarıyla mevcut PPTX sunumlarını nasıl imzalayacağınızı ve Java için Aspose.Slides kullanarak dijital imzaları nasıl doğrulayacağınızı veya kaldıracağınızı öğrenin."
---
## **Genel Bakış**

Dijital imza, alıcının bir sunumu kimin imzaladığını ve imzalanan içeriğin değişip değişmediğini belirlemesine yardımcı olur. Burada üç ilgili güvenlik kavramı önemlidir:

- Bir **digital certificate** (dijital sertifika), bir kimliği bir açık anahtarla ilişkilendiren elektronik kimlik belgesidir. Güvenilir bir sertifika otoritesi (CA) bir sertifika verebilir veya bir organizasyon dahili iş akışları için kendinden imzalı bir sertifika kullanabilir.
- Bir **digital signature** (dijital imza), sunum içeriği ve sertifika sahibinin özel anahtarı kullanılarak oluşturulur. Sertifikanın açık anahtarı daha sonra imzayı doğrulamak için kullanılabilir. İmza, kaynağın ve bütünlüğün kanıtını sağlar; sunumu şifrelemez.
- **Password protection** (parola koruması), bir kullanıcının bir sunumu açıp düzenleyip düzenleyemeyeceğini kontrol eder. Dijital imzalamadan ayrı bir konudur ve [Password-Protected Presentations](/java/password-protected-presentation/) bölümünde açıklanmıştır.

PowerPoint, **File > Info > Protect Presentation** menüsü altında **Add a Digital Signature** (Dijital İmza Ekle) komutunu sağlar.

![Add a Digital Signature seçeneği vurgulanmış PowerPoint Protect Presentation menüsü](add-digital-signature-in-powerpoint.png)

İmzalı bir sunum açıldıktan sonra, PowerPoint bir imza durumu bildirimi gösterebilir.

![Sunumun geçerli imzalar içerdiğini belirten PowerPoint bildirimi](digital-signature-status-in-powerpoint.png)

Aspose.Slides, imzaları [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) aracılığıyla sunar; bu, öğeleri [IDigitalSignature] uygulayan bir [IDigitalSignatureCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idigitalsignaturecollection/) döndürür. Bir sunum birden fazla imza içerebilir.

## **PFX Sertifikaları ve Parolalarını Anlamak**

Bir PFX dosyası, PKCS#12 dosyası olarak da bilinir ve genellikle `.pfx` veya `.p12` uzantısı alır; X.509 sertifikası, bunun özel anahtarı ve sertifika zincirini içerebilir. Özel anahtar, imza oluşturulmasını sağlar. Erişilebilir bir özel anahtarı olmayan bir sertifika, bir sunumu imzalamak için kullanılamaz.

PFX parolası, sertifika paketini ve özel anahtarı korur. Bu, sunumu açmak veya düzenlemek için bir parola **değildir**. PFX dosyalarını veya parolalarını kaynak kontrolüne göndermeyin. Üretimde, sertifika dosyasına erişimi sınırlayın ve parolasını gizli bir mağazadan ya da başka korumalı bir yapılandırma kaynağından alın. Aşağıdaki örnekler, kodun içinde parola yerleştirmemek için yalnızca bir ortam değişkeni kullanır.

## **Bir Sunuma Dijital İmza Ekleme**

Gerçek bir sunum iş akışını imzalamak için var olan bir PPTX dosyasını yükleyin, bir PFX sertifikası ve parolasından bir [DigitalSignature](https://reference.aspose.com/slides/tr/java/com.aspose.slides/digitalsignature/) oluşturun, imzayı sunumun koleksiyonuna ekleyin ve bir PPTX dosyasına kaydedin.

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

Sonucu yeni bir ad altında kaydetmek, imzasız kaynak dosyasını korur. [IDigitalSignature.setComments](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) ile ayarlanan değer, imzanın amacını açıklar; bu bir güvenlik kontrolü değildir.

## **Dijital İmzaları Doğrulama**

İmzalı bir PPTX dosyasını yüklediğinizde, [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) tarafından döndürülen her öğeyi inceleyin. [IDigitalSignature.isValid](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idigitalsignature/#isValid--) yöntemi, gömülü imzanın geçerli sunum içeriği için geçerli olup olmadığını gösterir.

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

Geçersiz bir sonuç genellikle, imzalı sunum içeriği veya imza verilerinin imzalama sonrası değiştiği ya da dosyanın bozulmuş olduğu anlamına gelir. Tüm imzaların kaldırılması imzasız bir sunum üretir; bu nedenle yalnızca öğelerin geçerliliğini kontrol etmek yeterli değildir: güvenliğe duyarlı bir iş akışı, beklenen imza sayısının ve beklenen imzalayan kimliklerinin mevcut olduğunu da doğrulamalıdır.

Bu geçerlilik sonucu, tam bir sertifika‑güven kararı olarak ele alınmamalıdır. Güvenlik politikanıza bağlı olarak, uygulamanız X.509 sertifika zincirini oluşturup doğrulamalı, sertifika geçerlilik tarihlerini ve iptal durumunu kontrol etmeli, beklenen konu ya da parmak izini onaylamalı, anahtar kullanımını doğrulamalı ve güvenilir bir zaman damgasını değerlendirmelidir. [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idigitalsignature/#getSignTime--) değeri tek başına güvenilir bir zaman damgası otoritesinden kanıt oluşturmaz.

## **Dijital İmzaları Kaldırma**

İmzaların kaldırılması, sunumun güvenlik durumunu değiştirir. Aşağıdaki örnek, imzalı bir PPTX dosyasını yükler, tüm imzaları [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idigitalsignaturecollection/#clear--) ile kaldırır ve imzasız bir kopya olarak kaydeder.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Yalnızca bir imzayı kaldırmak için, sıfır‑tabanlı diziniyle birlikte [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) çağırın. İş akışınızın açık bir parçası olmadığı sürece, yeni bir dosyaya kaydedin; imzalı orijinali üzerine yazmayın.

## **Düzenleme ve Biçim Hususları**

- Bir imza, bir sunumu yalnızca‑okunur yapmaz. Kullanıcılar ve uygulamalar dosyayı hâlâ düzenleyebilir, ancak imzalı içeriğe yapılan değişiklikler genellikle mevcut imzayı geçersiz kılar.
- Tüm planlanan düzenlemeleri imzalamadan önce tamamlayın. Sunumun değiştirilmesi gerekiyorsa, revize edilmiş sunumu kaydedin ve o revizyonu tekrar imzalayın.
- Son çıktıyı PPTX formatında tutun. İmzalı bir sunumu başka bir formata dönüştürmek, orijinal PPTX imzasını dönüştürülmüş dosya için geçerli bir imza olarak taşımaz.
- Sertifikanın özel anahtarını hassas bir veri olarak değerlendirin. Özel anahtar ve parolasını elde eden herkes, o sertifika sahibi adına imzalar oluşturabilir.
- Belge‑saklama politikanız gerektiriyorsa, imzasız kaynağı veya başka bir kontrol edilen kopyayı saklayın.

## **SSS**

**Dijital imza sunumu şifreler mi?**

Hayır. Dijital imza, kaynağa ve bütünlüğe ilişkin kanıt sağlar, ancak ayrı bir şifreleme uygulanmadıkça sunum içeriği okunabilir kalır. İçeriğe erişimin kısıtlanması gerektiğinde [password protection](/java/password-protected-presentation/) kullanın.

**PFX parolası sunum parolasıyla aynı mı?**

Hayır. PFX parolası, sertifika paketinde depolanan özel anahtarın kilidini açar. PPTX dosyasını kimlerin açıp düzenleyebileceğini kontrol etmez.

**Kendinden imzalı bir sertifika kullanabilir miyim?**

Teknik olarak, erişilebilir bir özel anahtar içeren bir kendinden imzalı sertifika kullanılabilir. Alıcılar, bu sertifikayı güvenilir ortamlarına açıkça eklemedikçe otomatik olarak güvenmezler. Genel ya da kurumlar arası iş akışları genellikle güvenilir bir CA tarafından verilen bir sertifika kullanır.

**Bir imzayı geçersiz kılan nedir?**

İmzalı sunum içeriğini ya da imza verilerini imzalama sonrası değiştirmek imzayı geçersiz kılabilir. Dosya bozulması da doğrulamanın başarısız olmasına yol açar. Tüm imzalar kaldırılırsa, sunum imzasız olur; geçersiz bir imza içeren bir dosya değildir.

**Geçerli bir imza, imzalayan kişiye güvenmem gerektiği anlamına mı gelir?**

Tek başına hayır. İmza bütünlüğü ve imzalayan güveni ayrı kararlardır. Üretim doğrulama politikasının ayrıca sertifika zincirini, geçerlilik süresini, iptal durumunu, beklenen kimliği, anahtar kullanımını ve olası güvenilir zaman damgası gereksinimlerini kontrol etmesi gerekir.

**Sertifika süresi dolduğunda ne olur?**

Sertifika süresinin dolması, sunum baytlarını değiştirmez, ancak sertifika‑güven değerlendirmesini etkiler. Bir imzanın kabul edilebilirliği, politikanıza ve geçerli bir güvenilir zaman damgasının imzalamanın sertifika geçerli iken gerçekleştiğini kanıtlayıp kanıtlamadığına bağlıdır. Görünen imzalama zamanına yalnızca güvenilir bir zaman damgası olarak güvenmeyin.

**İmzalı bir sunum hâlâ düzenlenebilir mi?**

Evet. İmzalama dosyayı kilitlemez. İmzalı içeriği düzenlemek genellikle mevcut imzayı geçersiz kılar; bu yüzden sunumu önce tamamlayın ve son revizyonu imzalayın.

**Bir sunum birden fazla imza içerebilir mi?**

Evet. Kaydetmeden önce her imzayı [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) tarafından döndürülen koleksiyona ekleyin. Doğrulama sırasında her imzayı inceleyin ve tüm gerekli imzalayanların mevcut olduğunu doğrulayın.

**Hangi sunum formatları bu işlemleri destekler?**

Aspose.Slides, burada açıklanan dijital‑imza işlemlerini yalnızca PPTX için destekler. PPT ve OpenDocument sunum formatları bu API iş akışıyla desteklenmez.

**İmzayı slaytları etkilemeden kaldırabilir miyim?**

Evet. Tek bir imzayı kaldırabilir veya tüm koleksiyonu temizleyip ardından sunumu kaydedebilirsiniz. Slayt içeriği mevcut kalır, ancak kaydedilen dosya artık kaldırılan imza kanıtını taşımaz.