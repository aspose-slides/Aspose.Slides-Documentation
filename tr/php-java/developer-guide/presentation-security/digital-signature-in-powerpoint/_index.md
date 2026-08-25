---
title: PHP'de Sunumlara Dijital İmzalar Ekleyin
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
- imza doğrulama
- PowerPoint
- PPTX
- sunum güvenliği
- PHP
- Aspose.Slides
description: "PFX sertifikalarıyla mevcut PPTX sunumlarını nasıl imzalayacağınızı ve Aspose.Slides for PHP via Java'ı kullanarak dijital imzaları doğrulama veya kaldırma işlemlerini öğrenin."
---
## **Genel Bakış**

Bir dijital imza, alıcının bir sunumu kimin imzaladığını ve imzalı içeriğin değişip değişmediğini belirlemesine yardımcı olur. Burada üç ilgili güvenlik kavramı önemlidir:

- Bir **dijital sertifika**, bir kimliği bir açık anahtarla ilişkilendiren elektronik kimlik belgesidir. Güvenilir bir sertifika otoritesi (CA) bir sertifika düzenleyebilir veya bir organizasyon dahili iş akışları için kendinden imzalı bir sertifika kullanabilir.
- Bir **dijital imza**, sunum içeriği ve sertifika sahibinin özel anahtarından oluşturulur. Sertifikanın açık anahtarı daha sonra imzayı doğrulamak için kullanılabilir. Bir imza, kaynak ve bütünlük kanıtı sağlar; sunumu şifrelemez.
- **Parola koruması**, bir kullanıcının bir sunumu açıp açamayacağını veya değiştirebileceğini kontrol eder. Bu, dijital imzalamadan ayrı bir konudur ve [Parola Koruması ile Sunumlar](/slides/tr/php-java/password-protected-presentation/) içinde açıklanmıştır.

PowerPoint, **Dosya > Bilgi > Sunumu Koru** altında **Dijital İmza Ekle** komutunu sağlar.

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

İmzalı bir sunum açıldıktan sonra, PowerPoint bir imza durumu bildirimi gösterebilir.

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Aspose.Slides, imzaları [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getDigitalSignatures) aracılığıyla sunar; bu yöntem bir [DigitalSignatureCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/digitalsignaturecollection/) döndürür ve öğeleri [DigitalSignature](https://reference.aspose.com/slides/tr/php-java/aspose.slides/digitalsignature/) nesneleriyle temsil eder. Bir sunum birden çok imza içerebilir.

## **PFX Sertifikaları ve Parolaları Anlama**

PFX dosyası, PKCS#12 dosyası olarak da bilinir ve genellikle `.pfx` veya `.p12` uzantısına sahiptir; bir X.509 sertifikası, onun özel anahtarı ve sertifika zincirini içerebilir. Özel anahtar, sahibinin bir imza oluşturmasını sağlar. Erişilebilir bir özel anahtarı olmayan bir sertifika, bir sunumu imzalamak için kullanılamaz.

PFX parolası, sertifika paketini ve özel anahtarı korur. Bu, sunumu açmak veya düzenlemek için bir parola **değildir**. PFX dosyalarını veya parolalarını kaynak kontrolüne commit etmeyin. Üretim ortamında, sertifika dosyasına erişimi kısıtlayın ve parolasını bir gizli depo ya da başka bir korumalı yapılandırma kaynağından alın. Aşağıdaki örnekler, parolayı koda gömmekten kaçınmak için sadece bir ortam değişkeni kullanır.

## **Bir Sunuma Dijital İmza Ekleme**

Gerçek bir sunum iş akışını imzalamak için, mevcut bir PPTX dosyasını yükleyin, bir PFX sertifikası ve parolasıyla bir [DigitalSignature](https://reference.aspose.com/slides/tr/php-java/aspose.slides/digitalsignature/) oluşturun, imzayı sunumun koleksiyonuna ekleyin ve bir PPTX dosyasına kaydedin.

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

Sonucu yeni bir adla kaydetmek, imzasız kaynak dosyasını korur. [DigitalSignature::setComments](https://reference.aspose.com/slides/tr/php-java/aspose.slides/digitalsignature/setcomments/) ile ayarlanan değer, imzanın amacını açıklar; bu bir güvenlik kontrolü değildir.

## **Dijital İmzaları Doğrulama**

İmzalı bir PPTX dosyasını yüklediğinizde, [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getDigitalSignatures) tarafından döndürülen her öğeyi inceleyin. [DigitalSignature::isValid](https://reference.aspose.com/slides/tr/php-java/aspose.slides/digitalsignature/isvalid/) yöntemi, gömülü imzanın mevcut sunum içeriği için geçerli olup olmadığını gösterir.

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

Geçersiz bir sonuç genellikle imzalı sunum içeriği veya imza verisinin imzalama sonrası değiştiği ya da dosyanın bozulmuş olduğu anlamına gelir. Tüm imzaların kaldırılması imzasız bir sunum üretir, bu yüzden yalnızca öğelerin geçerliliğini kontrol etmek yeterli değildir: güvenlik açısından hassas bir iş akışı, beklenen imza sayısının ve beklenen imzalayan kimliklerinin mevcut olduğunu da doğrulamalıdır.

Bu geçerlilik sonucu, tam bir sertifika-güven kararı olarak ele alınmamalıdır. Güvenlik politikanıza bağlı olarak, uygulamanız X.509 sertifika zincirini oluşturup doğrulamalı, sertifika geçerlilik tarihlerini ve iptal durumunu kontrol etmeli, beklenen konu ya da parmak izini teyit etmeli, anahtar kullanımını doğrulamalı ve güvenilir bir zaman damgasını değerlendirmelidir. [DigitalSignature::getSignTime](https://reference.aspose.com/slides/tr/php-java/aspose.slides/digitalsignature/getsigntime/) değeri tek başına güvenilir bir zaman damgası otoritesinden bir kanıt değildir.

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

Sadece bir imzayı kaldırmak için, sıfır tabanlı indeksini kullanarak [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/digitalsignaturecollection/removeat/) çağırın. İmzalı orijinali üzerine yazmak iş akışınızın açık bir parçası değilse, yeni bir dosyaya kaydedin.

## **Düzenleme ve Biçim Düşünceleri**

- Bir imza, bir sunumu salt okunur yapmaz. Kullanıcılar ve uygulamalar dosyayı hâlâ düzenleyebilir, ancak imzalı içeriğe yapılan değişiklikler genellikle mevcut imzayı geçersiz kılar.
- İmzalamadan önce tüm istenen düzenlemeleri tamamlayın. Eğer bir sunumu değiştirmeniz gerekiyorsa, revize edilmiş sunumu kaydedin ve o revizyonu tekrar imzalayın.
- Son çıktıyı PPTX formatında tutun. İmzalı bir sunumu başka bir formata dönüştürmek, orijinal PPTX imzasını geçerli bir imza olarak dönüştürülmüş dosyaya taşımaz.
- Sertifikanın özel anahtarını hassas bir bilgi olarak tutun. Özel anahtar ve parolasını elde eden herkes, bu sertifika sahibinden geliyormuş gibi imzalar oluşturabilir.
- Belgelerin saklama politikanız gerektiriyorsa, imzasız kaynağı ya da başka bir kontrol edilen kopyayı koruyun.

## **SSS**

**Bir dijital imza sunumu şifreler mi?**

Hayır. Dijital imza, kaynak ve bütünlük hakkında kanıt sağlar, ancak sunum içeriği ayrı bir şifreleme uygulanmadıkça okunabilir kalır. İçeriğe erişimin kısıtlanması gerektiğinde [parola koruması](/slides/tr/php-java/password-protected-presentation/) kullanın.

**PFX parolası, sunum parolasıyla aynı mı?**

Hayır. PFX parolası, sertifika paketindeki özel anahtarın kilidini açar. PPTX dosyasını kimlerin açıp düzenleyebileceğini kontrol etmez.

**Kendinden imzalı bir sertifika kullanabilir miyim?**

Teknik olarak, erişilebilir bir özel anahtar içeriyorsa kendinden imzalı bir sertifika kullanılabilir. Alıcılar bunu otomatik olarak güvenmez; ancak bu sertifika güvenilir ortamlarına açıkça eklenmişse güvenilir kabul edilir. Genel veya çapraz organizasyon iş akışları genellikle güvenilir bir CA tarafından verilen bir sertifika kullanır.

**Bir imzayı geçersiz kılan nedir?**

İmzalı sunum içeriğini veya imza verisini imzalama sonrası değiştirmek imzayı geçersiz kılar. Dosya bozulması da doğrulamanın başarısız olmasına neden olabilir. Tüm imzalar kaldırılırsa, sunum geçersiz bir imza taşıyan bir dosya değil, imzasız bir sunum olur.

**Geçerli bir imza, imzalayanına güvenmem gerektiği anlamına mı gelir?**

Tek başına hayır. İmza bütünlüğü ve imzalayan güveni ayrı kararlardır. Üretim doğrulama politikası, ayrıca sertifika zinciri, geçerlilik süresi, iptal durumu, beklenen kimlik, anahtar kullanımı ve güvenilir zaman damgası gereksinimlerini de kontrol etmelidir.

**Sertifika süresi dolduğunda ne olur?**

Sertifikanın süresi dolması, sunum baytlarını değiştirmez, ancak sertifika güveni değerlendirmesini etkiler. Bir imzanın kabul edilebilir olup olmadığı, politikanıza ve geçerli bir güvenilir zaman damgasının imzalanma sırasında sertifikanın geçerli olduğunu kanıtlayıp kanıtlamadığına bağlıdır. Görüntülenen imzalama zamanına yalnızca güvenilir bir zaman damgası olarak güvenmemek gerekir.

**İmzalı bir sunum hâlâ düzenlenebilir mi?**

Evet. İmzalama dosyayı kilitlemez. İmzalı içeriği düzenlemek genellikle mevcut imzayı geçersiz kılar, bu yüzden önce sunumu tamamlayıp son revizyonu imzalayın.

**Bir sunum birden fazla imza içerebilir mi?**

Evet. Kaydetmeden önce [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getDigitalSignatures) tarafından döndürülen koleksiyona her imzayı ekleyin. Doğrulama sırasında, her imzayı inceleyin ve gerekli tüm imzalayanların mevcut olduğunu doğrulayın.

**Hangi sunum formatları bu işlemleri destekler?**

Aspose.Slides, burada açıklanan dijital imza işlemlerini yalnızca PPTX için destekler. PPT ve OpenDocument sunum formatları bu API iş akışı tarafından desteklenmez.

**İmzayı slaytları etkilemeden kaldırabilir miyim?**

Evet. Tek bir imzayı kaldırabilir veya tüm koleksiyonu temizleyip ardından sunumu kaydedebilirsiniz. Slayt içeriği mevcut kalır, ancak kaydedilen dosya artık kaldırılan imza kanıtını taşımaz.