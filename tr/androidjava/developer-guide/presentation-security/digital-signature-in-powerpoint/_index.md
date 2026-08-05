---
title: Android'de Sunumlara Dijital İmzalar Ekleme
linktitle: Dijital İmza
type: docs
weight: 10
url: /tr/androidjava/digital-signature-in-powerpoint/
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
- Android
- Java
- Aspose.Slides
description: "PFX sertifikalarıyla mevcut PPTX sunumlarını imzalamayı ve Java üzerinden Android için Aspose.Slides kullanarak dijital imzaları doğrulamayı veya kaldırmayı öğrenin."
---
## **Genel Bakış**

Bir dijital imza, alıcının bir sunumu kimin imzaladığını ve imzalanan içeriğin değişip değişmediğini belirlemesine yardımcı olur. Burada önemli olan üç ilgili güvenlik kavramı şunlardır:

- **Dijital sertifika**, bir kimliği bir açık anahtarla ilişkilendiren elektronik kimlik bilgisi dir. Güvenilir bir sertifika yetkilisi (CA) bir sertifika yayabilir veya bir kuruluş dahili iş akışları için kendinden‑imzalı bir sertifika kullanabilir.
- **Dijital imza**, sunum içeriği ve sertifika sahibinin özel anahtarıyla oluşturulur. Sertifikanın açık anahtarı daha sonra imzayı doğrulamak için kullanılabilir. Bir imza, kaynağın ve bütünlüğün kanıtını sağlar; sunumu şifrelemez.
- **Parola koruması**, bir kullanıcının bir sunumu açıp değiştirebileceğini kontrol eder. Bu, dijital imzalamadan ayrı bir konudur ve [Parola‑Korunan Sunumlar](/androidjava/password-protected-presentation/) bölümünde açıklanmıştır.

PowerPoint, **Dosya > Bilgi > Sunumu Koru** menüsü altında **Dijital İmza Ekle** komutunu sağlar.

![PowerPoint Sunumu Koru menüsü Add a Digital Signature vurgulanmış biçimde](add-digital-signature-in-powerpoint.png)

İmzalı bir sunum açıldıktan sonra PowerPoint, bir imza‑durumu bildirimi gösterebilir.

![PowerPoint bildirimi, sunumun geçerli imzalar içerdiğini belirtiyor](digital-signature-status-in-powerpoint.png)

Aspose.Slides, imzaları [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) aracılığıyla sunar; bu metod bir [IDigitalSignatureCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idigitalsignaturecollection/) döndürür ve öğeleri [IDigitalSignature](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idigitalsignature/) arayüzünü uygular. Bir sunum birden fazla imza içerebilir.

## **PFX Sertifikalarını ve Parolaları Anlamak**

PFX dosyası, PKCS#12 dosyası olarak da bilinir ve genellikle `.pfx` ya da `.p12` uzantısına sahiptir; bir X.509 sertifikası, onun özel anahtarı ve sertifika zincirini içerebilir. Özel anahtar, sahibinin bir imza oluşturmasını sağlar. Erişilebilir bir özel anahtarı olmayan bir sertifika, bir sunumu imzalamak için kullanılamaz.

PFX parolası, sertifika paketini ve özel anahtarı korur. Bu, **sunumu açmak veya düzenlemek için bir parola değildir**. PFX dosyalarını veya parolalarını kaynak kontrolüne commit etmeyin. Üretim ortamında, sertifika dosyasına erişimi sınırlayın ve parolayı bir gizli mağazadan ya da başka bir korumalı yapılandırma kaynağından alın. Aşağıdaki örnekler, parolayı kod içinde sabitlemekten kaçınmak için sadece bir ortam değişkeni kullanır.

## **Bir Sunuma Dijital İmza Ekleme**

Gerçek bir sunum iş akışını imzalamak için mevcut bir PPTX dosyasını yükleyin, bir PFX sertifikası ve parolasıyla bir [DigitalSignature](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/digitalsignature/) oluşturun, imzayı sunumun koleksiyonuna ekleyin ve bir PPTX dosyasına kaydedin.

```java
import com.aspose.slides.*;

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

Sonucu yeni bir adla kaydetmek, imzasız kaynak dosyasını korur. [IDigitalSignature.setComments](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) ile ayarlanan değer, imzanın amacını açıklar; güvenlik kontrolü değildir.

## **Dijital İmzaları Doğrulama**

İmzalı bir PPTX dosyasını yüklediğinizde, [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) tarafından döndürülen her öğeyi inceleyin. [IDigitalSignature.isValid](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idigitalsignature/#isValid--) yöntemi, gömülü imzanın mevcut sunum içeriği için geçerli olup olmadığını gösterir.

```java
import com.aspose.slides.*;

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

Geçersiz bir sonuç genellikle imzalı sunum içeriğinin veya imza verilerinin imzalama sonrası değiştiği veya dosyanın hasar gördüğü anlamına gelir. Tüm imzaları kaldırmak imzasız bir sunum üretir; yalnızca öğelerin geçerliliğinin kontrol edilmesi yeterli değildir: güvenlik‑duyarlı bir iş akışı, beklenen imza sayısının ve beklenen imzalayan kimliklerinin mevcut olduğunu da doğrulamalıdır.

Bu geçerlilik sonucu, tam bir sertifika‑güven kararı olarak değerlendirilmemelidir. Güvenlik politikanıza bağlı olarak, uygulamanız X.509 sertifika zincirini oluşturup doğrulamalı, sertifika geçerlilik tarihlerini ve iptal durumunu kontrol etmeli, beklenen konu ya da parmak izini onaylamalı, anahtar kullanımını doğrulamalı ve güvenilir bir zaman damgasını değerlendirmelidir. [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idigitalsignature/#getSignTime--) değeri tek başına güvenilir bir zaman damgası otoritesinden kanıt olarak kabul edilmez.

## **Dijital İmzaları Kaldırma**

İmzaların kaldırılması, sunumun güvenlik durumunu değiştirir. Aşağıdaki örnek, imzalı bir PPTX dosyasını yükler, tüm imzaları [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idigitalsignaturecollection/#clear--) ile kaldırır ve imzasız bir kopya kaydeder.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Yalnızca tek bir imzayı kaldırmak için, sıfır‑tabanlı indeksiyle [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) metodunu çağırın. İmzalı orijinali üzerine yazmak, iş akışınızın açık bir parçası değilse, yeni bir dosyaya kaydedin.

## **Düzenleme ve Biçim Düşünceleri**

- Bir imza, sunumu yalnızca‑okunur yapmaz. Kullanıcılar ve uygulamalar dosyayı hâlâ düzenleyebilir, ancak imzalı içeriğe yapılan değişiklikler genellikle mevcut imzayı geçersiz kılar.
- İmzalamadan önce tüm planlanan düzenlemeleri tamamlayın. Sunumun değiştirilmesi gerekiyorsa, revize edilmiş sunumu kaydedin ve o revizyonu yeniden imzalayın.
- Son çıktıyı PPTX biçiminde tutun. İmzalı bir sunumu başka bir biçime dönüştürmek, orijinal PPTX imzasını geçerli bir imza olarak aktarmaz.
- Sertifikanın özel anahtarını hassas bir veri olarak tutun. Özel anahtar ve parolasını elde eden herkes, o sertifika sahibinden gelmiş gibi görünecek imzalar oluşturabilir.
- Belge‑saklama politikanız gerektiriyorsa, imzasız kaynağı ya da başka kontrollü bir kopyayı saklayın.

## **SSS**

**Dijital imza sunumu şifreler mi?**

Hayır. Dijital imza, kaynağın ve bütünlüğün kanıtını sağlar, ancak içerik ayrı bir şifreleme uygulanmadıkça okunabilir kalır. İçeriğe erişimin sınırlı olması gerektiğinde [parola koruması](/androidjava/password-protected-presentation/) kullanın.

**PFX parolası, sunum parolasıyla aynı mı?**

Hayır. PFX parolası, sertifika paketindeki özel anahtarı açmak için kullanılır. PPTX dosyasını kimlerin açıp düzenleyebileceğini kontrol etmez.

**Kendinden‑imzalı bir sertifika kullanabilir miyim?**

Teknik olarak, erişilebilir bir özel anahtar içeren bir kendinden‑imzalı sertifika kullanılabilir. Alıcılar bunu otomatik olarak güvenmez; sertifikanın güvenilir ortama açıkça eklenmesi gerekir. Genel ya da çapraz‑kurumsal iş akışları genellikle güvenilir bir CA tarafından verilen bir sertifika kullanır.

**Bir imzayı geçersiz kılan nedir?**

İmzalı sunum içeriğini veya imza verilerini imzalama sonrası değiştirmek imzayı geçersiz kılar. Dosya bozulması da doğrulamanın başarısız olmasına yol açabilir. Tüm imzalar kaldırıldığında sunum, geçersiz bir imza içeren bir dosya değil, imzasız bir sunum olur.

**Geçerli bir imza, imzalayanı güvenmem gerektiği anlamına mı gelir?**

Tek başına hayır. İmza bütünlüğü ve imzalayanın güvenilirliği ayrı kararlar gerektirir. Üretim doğrulama politikası ayrıca sertifika zincirini, geçerlilik süresini, iptal durumunu, beklenen kimliği, anahtar kullanımını ve olası güvenilir zaman damgası gereksinimlerini kontrol etmelidir.

**Sertifika süresi dolduğunda ne olur?**

Sertifikanın süresi dolması, sunum baytlarını değiştirmez, ancak sertifika‑güven değerlendirmesini etkiler. Bir imzanın kabul edilebilir olup olmadığı politikanıza ve geçerli bir güvenilir zaman damgasının imzalamanın sertifikanın geçerli olduğu sırada gerçekleştiğini kanıtlayıp kanıtlamadığına bağlıdır. Tek başına gösterilen imzalama zamanına güvenilir bir zaman damgası olarak güvenmemelisiniz.

**İmzalı bir sunum hâlâ düzenlenebilir mi?**

Evet. İmzalama dosyayı kilitlemez. İmzalı içeriği düzenlemek genellikle mevcut imzayı geçersiz kılar; bu yüzden önce sunumu tamamlayıp ardından son revizyonu imzalayın.

**Bir sunum birden fazla imza içerebilir mi?**

Evet. [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) tarafından döndürülen koleksiyona her bir imzayı ekleyin ve kaydedin. Doğrulama sırasında her imzayı inceleyin ve gerekli tüm imzalayanların mevcut olduğunu doğrulayın.

**Hangi sunum biçimleri bu işlemleri destekler?**

Aspose.Slides, burada açıklanan dijital imza işlemlerini yalnızca PPTX için destekler. PPT ve OpenDocument sunum biçimleri bu API iş akışı tarafından desteklenmez.

**Bir imzayı slaytlara zarar vermeden kaldırabilir miyim?**

Evet. Tek bir imzayı kaldırabilir veya tüm koleksiyonu temizleyip ardından sunumu kaydedebilirsiniz. Slayt içeriği mevcut kalır, ancak kaydedilen dosya kaldırılan imza kanıtını taşımaz.