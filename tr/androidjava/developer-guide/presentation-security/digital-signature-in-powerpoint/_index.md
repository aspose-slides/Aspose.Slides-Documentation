---
title: Android'de Sunumlara Dijital İmzalar Ekleyin
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
description: "PFX sertifikalarıyla mevcut PPTX sunumlarını nasıl imzalayacağınızı ve Java üzerinden Android için Aspose.Slides kullanarak dijital imzaları doğrulama veya kaldırma işlemlerini öğrenin."
---
## **Genel Bakış**

Dijital imza, alıcının bir sunumu kimin imzaladığını ve imzalı içeriğin değişip değişmediğini belirlemesine yardımcı olur. Burada üç ilgili güvenlik kavramı önemlidir:

- **dijital sertifika**, bir kimliği bir ortak anahtara bağlayan elektronik bir kimlik belgesidir. Güvenilir bir sertifika otoritesi (CA) bir sertifika yayınlayabilir veya bir organizasyon dahili iş akışları için kendinden imzalı bir sertifika kullanabilir.
- **dijital imza**, sunum içeriği ve sertifika sahibinin özel anahtarıyla oluşturulur. Sertifikanın ortak anahtarı daha sonra imzayı doğrulamak için kullanılabilir. Bir imza, kaynağın ve bütünlüğün kanıtını sağlar; sunumu şifrelemez.
- **Şifre koruması**, bir kullanıcının bir sunumu açıp değiştirebileceğini kontrol eder. Bu, dijital imzalamadan ayrı bir konudur ve [Şifre Koruması ile Sunumlar](/slides/tr/androidjava/password-protected-presentation/) bölümünde açıklanmıştır.

PowerPoint, **Dosya > Bilgi > Sunumu Koru** altında **Dijital İmza Ekle** komutunu sağlar.

![PowerPoint Sunumu Koru menüsü, Dijital İmza Ekle vurgulanmış](add-digital-signature-in-powerpoint.png)

İmzalı bir sunum açıldıktan sonra, PowerPoint bir imza durumu bildirimi gösterebilir.

![PowerPoint bildirimi, sunumun geçerli imzalar içerdiğini belirtiyor](digital-signature-status-in-powerpoint.png)

Aspose.Slides, imzaları [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) aracılığıyla açığa çıkarır; bu, öğeleri [IDigitalSignature](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idigitalsignature/) arayüzünü uygulayan bir [IDigitalSignatureCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idigitalsignaturecollection/) döndürür. Bir sunum birden çok imza içerebilir.

## **PFX Sertifikalarını ve Şifreleri Anlamak**

Bir PFX dosyası, PKCS#12 dosyası olarak da bilinir ve genellikle `.pfx` ya da `.p12` uzantısına sahiptir; X.509 sertifikası, onun özel anahtarı ve sertifika zincirini içerebilir. Özel anahtar, imza oluşturmayı sağlar. Erişilebilir bir özel anahtarına sahip olmayan bir sertifika, bir sunumu imzalamak için kullanılamaz.

PFX şifresi, sertifika paketini ve özel anahtarı korur. Bu, **sunumu açma ya da düzenleme şifresi değildir**. PFX dosyalarını veya şifrelerini kaynak kontrolüne göndermeyin. üretim ortamında, sertifika dosyasına erişimi sınırlayın ve şifresini gizli bir mağazadan ya da başka bir korumalı yapılandırma kaynağından alın. Aşağıdaki örneklerde şifreyi koda gömmekten kaçınmak için yalnızca bir ortam değişkeni kullanılmıştır.

## **Bir Sunuma Dijital İmza Eklemek**

Gerçek bir sunum iş akışını imzalamak için var olan bir PPTX dosyasını yükleyin, bir PFX sertifikası ve şifresinden bir [DigitalSignature](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/digitalsignature/) oluşturun, imzayı sunumun koleksiyonuna ekleyin ve bir PPTX dosyasına kaydedin.

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

Sonucu yeni bir adla kaydetmek, imzasız kaynak dosyasını korur. [IDigitalSignature.setComments](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) ile ayarlanan değer, imzanın amacını açıklar; bu bir güvenlik kontrolü değildir.

## **Dijital İmzaları Doğrulama**

İmzalı bir PPTX dosyasını yüklediğinizde, [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) tarafından döndürülen her öğeyi inceleyin. [IDigitalSignature.isValid](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idigitalsignature/#isValid--) yöntemi, gömülü imzanın geçerli sunum içeriği için geçerli olup olmadığını gösterir.

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

Geçersiz bir sonuç genellikle imzalı sunum içeriğinin veya imza verisinin imzalandıktan sonra değiştiği ya da dosyanın zarar gördüğü anlamına gelir. Tüm imzaları kaldırmak imzasız bir sunum üretir; bu yüzden yalnızca öğelerin geçerliliğini kontrol etmek yeterli değildir: güvenlik duyarlı bir iş akışı, beklenen imza sayısının ve beklenen imzalayan kimliklerinin mevcut olduğunu da doğrulamalıdır.

Bu doğrulama sonucu, tam bir sertifika‑güven kararının yerine geçmemelidir. Güvenlik politikanıza bağlı olarak uygulamanız X.509 sertifika zincirini oluşturup doğrulamalı, sertifika geçerlilik tarihlerini ve iptal durumunu kontrol etmeli, beklenen konu ya da parmak izini teyit etmeli, anahtar kullanımını doğrulamalı ve güvenilir bir zaman damgasını değerlendirmelidir. [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idigitalsignature/#getSignTime--) değeri tek başına güvenilir bir zaman damgası otoritesinden kanıt niteliği taşımaz.

## **Dijital İmzaları Kaldırma**

İmzaları kaldırmak, sunumun güvenlik durumunu değiştirir. Aşağıdaki örnek, bir imzalı PPTX dosyasını yükler, tüm imzaları [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idigitalsignaturecollection/#clear--) ile kaldırır ve imzasız bir kopya kaydeder.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Yalnızca bir imzayı kaldırmak için, sıfır‑tabanlı indeksini belirterek [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) metodunu çağırın. İş akışınızın açık bir parçası değilse, üzerine yazmak yerine yeni bir dosyaya kaydedin.

## **Düzenleme ve Biçim Hususları**

- Bir imza, sunumu salt‑okunur hâle getirmez. Kullanıcılar ve uygulamalar dosyayı hâlâ düzenleyebilir, ancak imzalı içeriğin değiştirilmesi genellikle mevcut imzayı geçersiz kılar.
- İmzalamadan önce tüm planlanan düzenlemeleri tamamlayın. Sunumun değiştirilmesi gerekiyorsa, revize edilmiş sunumu kaydedin ve bu revizyonu yeniden imzalayın.
- Son çıktıyı PPTX biçiminde tutun. İmzalı bir sunumu başka bir biçime dönüştürmek, orijinal PPTX imzasını geçerli bir imza olarak dönüştürülmüş dosyaya taşımaz.
- Sertifikanın özel anahtarını hassas bir bilgi olarak değerlendirin. Özel anahtarı ve şifresini elde eden herkes, bu sertifika sahibinin adı altında imza oluşturabilir.
- Belge saklama politikanız gerektiriyorsa, imzasız kaynağı ya da başka bir kontrol edilen kopyayı saklayın.

## **SSS**

**Bir dijital imza sunumu şifreler mi?**

Hayır. Dijital imza, kaynağın ve bütünlüğün kanıtını sağlar, ancak sunum içeriği ayrı bir şifreleme uygulanmadıkça okunabilir kalır. İçeriğe erişimin kısıtlanması gerektiğinde [Şifre Koruması](/slides/tr/androidjava/password-protected-presentation/) kullanın.

**PFX şifresi sunum şifresiyle aynı şey midir?**

Hayır. PFX şifresi, sertifika paketindeki özel anahtarı açmak için kullanılır. PPTX dosyasını kimlerin açabileceğini ya da düzenleyebileceğini kontrol etmez.

**Kendinden imzalı bir sertifika kullanabilir miyim?**

Teknik olarak, erişilebilir bir özel anahtar içeriyorsa kendinden imzalı bir sertifika kullanılabilir. Alıcılar bu sertifikayı otomatik olarak güvenmez; ancak sertifika güvenilir ortamlarına açıkça eklenmişse güven kazanabilir. Genel ya da kuruluşlar arası iş akışları genellikle güvenilir bir CA tarafından verilen bir sertifika kullanır.

**Bir imzayı geçersiz kılan nedir?**

İmzalı sunum içeriğini veya imza verisini imzalandıktan sonra değiştirmek imzayı geçersiz kılar. Dosya bozulması da doğrulamanın başarısız olmasına neden olabilir. Tüm imzalar kaldırılırsa, sunum geçersiz bir imza içermez; sadece imzasız olur.

**Geçerli bir imza, imzalayanı güvenilir olarak kabul etmem gerektiği anlamına mı gelir?**

Yalnız başına bu anlamı taşımaz. İmza bütünlüğü ve imzalayan güveni ayrı kararlardır. Üretim ortamı doğrulama politikası, ayrıca sertifika zincirini, geçerlilik süresini, iptal durumunu, beklenen kimliği, anahtar kullanımını ve olası güvenilir zaman damgası gereksinimlerini kontrol etmelidir.

**Sertifika süresi dolduğunda ne olur?**

Sertifikanın süresi dolması sunumun baytlarını değiştirmez, ancak sertifika‑güven değerlendirmesini etkiler. Bir imzanın kabul edilebilirliği, politikalarınıza ve geçerli bir güvenilir zaman damgasının, imzalamanın sertifikanın geçerli olduğu bir dönemde gerçekleştiğini kanıtlayıp kanıtlamadığına bağlıdır. Görünen imzalama zamanına tek başına güvenmek yeterli değildir.

**İmzalı bir sunum hâlâ düzenlenebilir mi?**

Evet. İmzalama dosyayı kilitlemez. İmzalı içeriği düzenlemek genellikle mevcut imzayı geçersiz kılar; bu yüzden önce sunumu tamamlayıp ardından son revizyonu imzalayın.

**Bir sunum birden fazla imza içerebilir mi?**

Evet. Kaydetmeden önce her bir imzayı [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) tarafından döndürülen koleksiyona ekleyin. Doğrulama sırasında her imzayı inceleyin ve gerekli tüm imzalayanların mevcut olduğunu onaylayın.

**Hangi sunum formatları bu işlemleri destekler?**

Aspose.Slides, burada açıklanan dijital‑imza işlemlerini yalnızca PPTX formatı için destekler. PPT ve OpenDocument sunum formatları bu API iş akışı tarafından desteklenmez.

**İmzayı kaldırmak slaytları etkiler mi?**

Hayır. Bir imzayı kaldırabilir veya tüm koleksiyonu temizleyebilir, ardından sunumu kaydedebilirsiniz. Slayt içeriği mevcut kalır; ancak kaydedilen dosyada kaldırılan imza kanıtı bulunmaz.