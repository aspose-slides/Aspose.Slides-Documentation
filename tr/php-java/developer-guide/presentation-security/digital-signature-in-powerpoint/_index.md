---
title: PHP'de Sunumlara Dijital İmzalar Ekleme
linktitle: Dijital İmza
type: docs
weight: 10
url: /tr/php-java/digital-signature-in-powerpoint/
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
- PHP
- Aspose.Slides
description: "PFX sertifikalarıyla mevcut PPTX sunumlarını nasıl imzalayacağınızı ve Java aracılığıyla PHP için Aspose.Slides kullanarak dijital imzaları nasıl doğrulayacağınızı veya kaldıracağınızı öğrenin."
---
## **Genel Bakış**

Dijital imza, alıcının bir sunumu kim imzaladığını ve imzalı içeriğin değişip değişmediğini belirlemesine yardımcı olur. Burada üç ilgili güvenlik kavramı önemlidir:

- **Dijital sertifika**, bir kimliği bir ortak anahtarla ilişkilendiren elektronik bir kimlik bilgileridir. Güvenilir bir sertifika otoritesi (CA) bir sertifika düzenleyebilir veya bir organizasyon dahili iş akışları için kendi kendine imzalanmış bir sertifika kullanabilir.
- **Dijital imza**, sunum içeriği ve sertifika sahibinin özel anahtarından oluşturulur. Sertifikanın ortak anahtarı daha sonra imzayı doğrulamak için kullanılabilir. Bir imza, kaynağın ve bütünlüğün kanıtını sağlar; sunumu şifrelemez.
- **Şifre koruması**, bir kullanıcının sunumu açıp düzenleyip düzenleyemeyeceğini kontrol eder. Dijital imzalamadan ayrı bir konudur ve [Şifreyle Korunan Sunumlar](/php-java/password-protected-presentation/) içinde açıklanmıştır.

PowerPoint, **Dosya > Bilgi > Sunumu Koru** altında **Dijital İmza Ekle** komutunu sağlar.

![PowerPoint Koruma Sunumu menüsü, Dijital İmza Ekle vurgulanmış](add-digital-signature-in-powerpoint.png)

İmzalı bir sunum açıldıktan sonra, PowerPoint bir imza durumu bildirimi gösterebilir.

![PowerPoint bildirimi, sunumun geçerli imzalar içerdiğini belirtiyor](digital-signature-status-in-powerpoint.png)

Aspose.Slides, imzaları [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getDigitalSignatures) aracılığıyla ortaya koyar; bu yöntem, öğeleri [DigitalSignature](https://reference.aspose.com/slides/tr/php-java/aspose.slides/digitalsignature/) nesneleriyle temsil edilen bir [DigitalSignatureCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/digitalsignaturecollection/) döndürür. Bir sunum birden fazla imza içerebilir.

## **PFX Sertifikalarını ve Şifreleri Anlamak**

PFX dosyası, PKCS#12 dosyası olarak da bilinir ve genellikle `.pfx` veya `.p12` uzantısına sahiptir; bir X.509 sertifikası, onun özel anahtarı ve sertifika zincirini içerebilir. Özel anahtar, sahibinin bir imza oluşturmasına izin verir. Erişilebilir bir özel anahtarı olmayan bir sertifika, bir sunumu imzalamak için kullanılamaz.

PFX şifresi, sertifika paketini ve özel anahtarı korur. Bu şifre, sunumu açmak veya düzenlemek için bir şifre **değildir**. PFX dosyalarını veya şifrelerini kaynak kontrolüne göndermeyin. Üretim ortamında, sertifika dosyasına erişimi sınırlayın ve şifresini bir gizli depolama veya başka bir korumalı yapılandırma kaynağından temin edin. Aşağıdaki örnekler, şifrenin kod içinde gömülmesini önlemek için yalnızca bir ortam değişkeni kullanır.

## **Bir Sunuma Dijital İmza Ekleme**

Gerçek bir sunum iş akışını imzalamak için, mevcut bir PPTX dosyasını yükleyin, bir PFX sertifikasından ve şifresinden bir [DigitalSignature](https://reference.aspose.com/slides/tr/php-java/aspose.slides/digitalsignature/) oluşturun, imzayı sunumun koleksiyonuna ekleyin ve bir PPTX dosyasına kaydedin.

```php
$certificatePassword = getenv("PFX_PASSWORD");
if ($certificatePassword === false || $certificatePassword === "") {
    throw new RuntimeException("Set the PFX_PASSWORD environment variable.");
}

$presentation = new Presentation("InputPresentation.pptx");
try {
    $signature = new DigitalSignature("signing-certificate.pfx", $certificatePassword);
    $signature->setComments("Approved for release.");

    $presentation->getDigitalSignatures()->add($signature);
    $presentation->save("InputPresentation-signed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonucu yeni bir adla kaydetmek, imzasız kaynak dosyasını korur. [DigitalSignature::setComments](https://reference.aspose.com/slides/tr/php-java/aspose.slides/digitalsignature/setcomments/) ile ayarlanan değer, imzanın amacını açıklar; bu bir güvenlik denetimi değildir.

## **Dijital İmzaları Doğrulama**

İmzalı bir PPTX dosyası yüklediğinizde, [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getDigitalSignatures) tarafından döndürülen her öğeyi inceleyin. [DigitalSignature::isValid](https://reference.aspose.com/slides/tr/php-java/aspose.slides/digitalsignature/isvalid/) yöntemi, gömülü imzanın mevcut sunum içeriği için geçerli olup olmadığını gösterir.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $signatures = $presentation->getDigitalSignatures();
    $signatureCount = java_values($signatures->size());

    if ($signatureCount === 0) {
        echo "The presentation does not contain digital signatures." . PHP_EOL;
    } else {
        $allSignaturesAreValid = true;
        $signTimeFormat = new Java("java.text.SimpleDateFormat", "yyyy-MM-dd HH:mm:ss");
        $certificateFactoryClass = new JavaClass("java.security.cert.CertificateFactory");
        $certificateFactory = $certificateFactoryClass->getInstance("X.509");

        for ($index = 0; $index < $signatureCount; $index++) {
            $signature = $signatures->get_Item($index);
            $signatureIsValid = java_values($signature->isValid());
            $signatureStatus = $signatureIsValid ? "VALID" : "INVALID";
            $formattedSignTime = java_values($signTimeFormat->format($signature->getSignTime()));

            $certificateData = $signature->getCertificate();
            $certificateStream = new Java("java.io.ByteArrayInputStream", $certificateData);
            try {
                $certificate = $certificateFactory->generateCertificate($certificateStream);
                $signerName = java_values($certificate->getSubjectX500Principal()->getName());
            } finally {
                $certificateStream->close();
            }

            echo $signerName . ", " . $formattedSignTime . " -- " . $signatureStatus . PHP_EOL;

            $allSignaturesAreValid = $allSignaturesAreValid && $signatureIsValid;
        }

        if ($allSignaturesAreValid) {
            echo "All embedded signatures are valid for the current presentation." . PHP_EOL;
        } else {
            echo "At least one embedded signature is invalid." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Geçersiz bir sonuç genellikle, imzalı sunum içeriği veya imza verilerinin imzalama sonrasında değiştiği ya da dosyanın zarar gördüğü anlamına gelir. Tüm imzaların kaldırılması imzasız bir sunum üretir; bu nedenle yalnızca öğelerin geçerliliğini kontrol etmek yeterli değildir: güvenlik açısından hassas bir iş akışı, beklenen imza sayısı ve beklenen imzalayan kimliklerinin mevcut olduğunu da doğrulamalıdır.

Bu geçerlilik sonucu, tam bir sertifika-güven kararı olarak ele alınmamalıdır. Güvenlik politikanıza bağlı olarak, uygulamanız X.509 sertifika zincirini oluşturmalı ve doğrulamalı, sertifikanın geçerlilik tarihlerini ve iptal durumunu kontrol etmeli, beklenen konu ya da parmak izini onaylamalı, anahtar kullanımını doğrulamalı ve güvenilir bir zaman damgasını değerlendirmelidir. [DigitalSignature::getSignTime](https://reference.aspose.com/slides/tr/php-java/aspose.slides/digitalsignature/getsigntime/) değeri tek başına güvenilir bir zaman damgası otoritesinden kanıt değildir.

## **Dijital İmzaları Kaldırma**

İmzaları kaldırmak, sunumun güvenlik durumunu değiştirir. Aşağıdaki örnek, imzalı bir PPTX dosyasını yükler, tüm imzaları [DigitalSignatureCollection::clear](https://reference.aspose.com/slides/tr/php-java/aspose.slides/digitalsignaturecollection/clear/) ile kaldırır ve imzasız bir kopya kaydeder.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sadece bir imzayı kaldırmak için, sıfır tabanlı diziniyle [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/digitalsignaturecollection/removeat/) metodunu çağırın. İmzalı orijinali üzerine yazmak iş akışınızın açık bir parçası değilse yeni bir dosyaya kaydedin.

## **Düzenleme ve Format Hususları**

- Bir imza, sunumu yalnızca okunur (read‑only) yapmaz. Kullanıcılar ve uygulamalar dosyayı hâlâ düzenleyebilir, ancak imzalı içeriğe yapılan değişiklikler genellikle mevcut imzayı geçersiz kılar.
- İmzalamadan önce tüm planlanan düzenlemeleri tamamlayın. Sunumun değiştirilmesi gerekiyorsa, revize edilmiş sunumu kaydedin ve o revizyonu tekrar imzalayın.
- Son çıktıyı PPTX formatında tutun. İmzalı bir sunumu başka bir formata dönüştürmek, orijinal PPTX imzasını dönüştürülmüş dosya için geçerli bir imza olarak taşımaz.
- Sertifikanın özel anahtarını hassas bir veri olarak ele alın. Özel anahtarı ve şifresini elde eden herkes, o sertifika sahibinden geldiği izlenimini veren imzalar oluşturabilir.
- Belge saklama politikanız gerektirdiğinde imzasız kaynağı veya başka bir kontrollü kopyayı saklayın.

## **SSS**

**Dijital imza sunumu şifreler mi?**

Hayır. Dijital imza, kaynağın ve bütünlüğün kanıtını sağlar, ancak ayrı bir şifreleme uygulanmadıkça sunum içeriği okunabilir halde kalır. İçeriğe erişimin kısıtlanması gerektiğinde [şifre koruması](/php-java/password-protected-presentation/) kullanın.

**PFX şifresi sunum şifresiyle aynı mı?**

Hayır. PFX şifresi, sertifika paketinde depolanan özel anahtarın kilidini açar. PPTX dosyasını kimlerin açabileceğini veya düzenleyebileceğini kontrol etmez.

**Kendi kendine imzalanmış bir sertifika kullanabilir miyim?**

Teknik olarak, erişilebilir bir özel anahtar içeren kendi kendine imzalanmış bir sertifika kullanılabilir. Ancak alıcılar, bu sertifika açıkça güvenilen ortamlarına eklenmedikçe otomatik olarak güvenmezler. Kamu veya kuruluşlar arası iş akışları genellikle güvenilir bir CA tarafından verilen bir sertifika kullanır.

**İmzayı geçersiz kılan nedir?**

İmzalı sunum içeriğini veya imza verilerini imzalama sonrasında değiştirmek imzayı geçersiz kılar. Dosya bozulması da doğrulamanın başarısız olmasına neden olabilir. Tüm imzalar kaldırılırsa, sunum geçersiz bir imza içeren bir dosya değil, imzasız olur.

**Geçerli bir imza, imzalayanın güvenilir olduğu anlamına mı gelir?**

Yalnız başına değil. İmza bütünlüğü ve imzalayanın güvenilirliği ayrı kararlardır. Üretim doğrulama politikası, ayrıca sertifika zincirini, geçerlilik süresini, iptal durumunu, beklenen kimliği, anahtar kullanımını ve herhangi bir güvenilir zaman damgası gereksinimini kontrol etmelidir.

**Sertifika süresi dolduğunda ne olur?**

Sertifika süresi dolması, sunum baytlarını değiştirmez, ancak sertifika‑güven değerlendirmesini etkiler. Bir imzanın kabul edilebilir olup olmadığı, politikanıza ve geçerli bir güvenilir zaman damgasının imzalamanın sertifikanın geçerli olduğu sırada gerçekleştiğini kanıtlayıp kanıtlamadığına bağlıdır. Görünen imzalama zamanına tek başına güvenilir bir zaman damgası gibi güvenmeyin.

**İmzalı bir sunum hâlâ düzenlenebilir mi?**

Evet. İmzalama dosyayı kilitlemez. İmzalı içeriği düzenlemek genellikle mevcut imzayı geçersiz kılar; bu yüzden önce sunumu tamamlayın ve son revizyonu imzalayın.

**Bir sunum birden fazla imza içerebilir mi?**

Evet. Kaydetmeden önce, her imzayı [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getDigitalSignatures) tarafından döndürülen koleksiyona ekleyin. Doğrulama sırasında, her imzayı inceleyin ve gerekli tüm imzalayanların mevcut olduğunu doğrulayın.

**Bu işlemleri hangi sunum formatları destekliyor?**

Aspose.Slides, burada açıklanan dijital‑imza işlemlerini yalnızca PPTX için destekler. PPT ve OpenDocument sunum formatları bu API iş akışı tarafından desteklenmez.

**İmzayı slaytları etkilemeden kaldırabilir miyim?**

Evet. Tek bir imzayı kaldırabilir veya tüm koleksiyonu temizleyip ardından sunumu kaydedebilirsiniz. Slayt içeriği mevcut kalır, ancak kaydedilen dosya artık kaldırılan imzanın kanıtını taşımaz.