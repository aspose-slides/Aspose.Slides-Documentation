---
title: C++'ta Sunumlara Dijital İmzalar Ekleme
linktitle: Dijital İmza
type: docs
weight: 10
url: /tr/cpp/digital-signature-in-powerpoint/
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
- C++
- Aspose.Slides
description: "PFX sertifikalarıyla mevcut PPTX sunumlarını nasıl imzalayacağınızı ve C++ için Aspose.Slides kullanarak dijital imzaları nasıl doğrulayacağınızı veya kaldıracağınızı öğrenin."
---
## **Genel Bakış**

Bir dijital imza, alıcının bir sunumu kimin imzaladığını ve imzalı içeriğin değişip değişmediğini belirlemesine yardımcı olur. Burada üç ilgili güvenlik kavramı önemlidir:

- **dijital sertifika**, bir kimliği bir açık anahtarla ilişkilendiren elektronik bir kimlik belgesidir. Güvenilir bir sertifika yetkilisi (CA) bir sertifika düzenleyebilir veya bir organizasyon dahili iş akışları için kendinden imzalı bir sertifika kullanabilir.
- **dijital imza**, sunum içeriği ve sertifika sahibinin özel anahtarı ile oluşturulur. Sertifikanın açık anahtarı daha sonra imzayı doğrulamak için kullanılabilir. Bir imza, köken ve bütünlük kanıtı sağlar; sunumu şifrelemez.
- **Parola koruması**, bir kullanıcının bir sunumu açıp açamayacağını veya değiştirebileceğini kontrol eder. Bu, dijital imzalamadan ayrı bir konu olup [Parola Koruma ile Sunumlar](/cpp/password-protected-presentation/) bölümünde açıklanmıştır.

PowerPoint, **Dijital İmza Ekle** komutunu **Dosya > Bilgi > Sunumu Koru** altında sunar.

![PowerPoint Sunumu Koru menüsü, Dijital İmza Ekle vurgulanmış](add-digital-signature-in-powerpoint.png)

İmzalı bir sunum açıldıktan sonra, PowerPoint bir imza durumu bildirimi gösterebilir.

![PowerPoint bildirimi, sunumun geçerli imzalar içerdiğini belirtiyor](digital-signature-status-in-powerpoint.png)

Aspose.Slides, imzaları [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/get_digitalsignatures/) aracılığıyla açığa çıkarır; bu, öğeleri [IDigitalSignature](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idigitalsignature/) arayüzünü uygulayan bir [IDigitalSignatureCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idigitalsignaturecollection/) döndürür. Bir sunum birden çok imza içerebilir.

## **PFX Sertifikalarını ve Parolaları Anlamak**

PFX dosyası, PKCS#12 dosyası olarak da bilinir ve genellikle `.pfx` ya da `.p12` uzantısına sahiptir; bir X.509 sertifikası, onun özel anahtarı ve sertifika zincirini içerebilir. Özel anahtar, sahibinin bir imza oluşturmasını sağlar. Erişilebilir bir özel anahtarı olmayan bir sertifika, sunumu imzalamak için kullanılamaz.

PFX parolası sertifika paketini ve özel anahtarı korur. Bu **sunumu açmak veya düzenlemek için bir parola değildir**. PFX dosyalarını veya parolalarını kaynak kontrolüne göndermeyin. Üretim ortamında, sertifika dosyasına erişimi sınırlayın ve parolasını gizli bir depodan veya başka bir korumalı yapılandırma kaynağından alın. Aşağıdaki örneklerde parola kod içinde gömülmemesi için yalnızca bir ortam değişkeni kullanılmıştır.

## **Bir Sunuma Dijital İmza Ekleme**

Gerçek bir sunum iş akışını imzalamak için mevcut bir PPTX dosyasını yükleyin, bir PFX sertifikası ve onun parolasıyla bir [DigitalSignature](https://reference.aspose.com/slides/tr/cpp/aspose.slides/digitalsignature/) oluşturun, imzayı sunumun koleksiyonuna ekleyin ve bir PPTX dosyasına kaydedin.

```cpp
auto certificatePassword = Environment::GetEnvironmentVariable(u"PFX_PASSWORD");
if (certificatePassword.IsNullOrEmpty())
{
    throw InvalidOperationException(u"Set the PFX_PASSWORD environment variable.");
}

auto presentation = MakeObject<Presentation>(u"InputPresentation.pptx");

auto signature = MakeObject<DigitalSignature>(u"signing-certificate.pfx", certificatePassword);
signature->set_Comments(u"Approved for release.");

presentation->get_DigitalSignatures()->Add(signature);
presentation->Save(u"InputPresentation-signed.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonucu yeni bir adla kaydetmek, imzasız kaynak dosyasını korur. [IDigitalSignature::set_Comments](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idigitalsignature/set_comments/) değeri, imzanın amacını açıklar; bir güvenlik kontrolü değildir.

## **Dijital İmzaları Doğrulama**

İmzalı bir PPTX dosyasını yüklediğinizde, [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/get_digitalsignatures/) tarafından döndürülen her öğeyi inceleyin. [IDigitalSignature::get_IsValid](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idigitalsignature/get_isvalid/) yöntemi, gömülü imzanın mevcut sunum içeriği için geçerli olup olmadığını gösterir.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

auto signatureCount = presentation->get_DigitalSignatures()->get_Count();

if (signatureCount == 0)
{
    Console::WriteLine(u"The presentation does not contain digital signatures.");
}
else
{
    bool allSignaturesAreValid = true;

    for (int signatureIndex = 0; signatureIndex < signatureCount; ++signatureIndex)
    {
        auto signature = presentation->get_DigitalSignature(signatureIndex);
        auto signatureIsValid = signature->get_IsValid();
        auto signatureStatus = signatureIsValid ? u"VALID" : u"INVALID";
        auto signerName = signature->get_Certificate()->get_SubjectName()->get_Name();
        auto signingTime = signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm:ss");

        Console::WriteLine(u"{0}, {1} -- {2}", signerName, signingTime, signatureStatus);

        allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"All embedded signatures are valid for the current presentation.");
    }
    else
    {
        Console::WriteLine(u"At least one embedded signature is invalid.");
    }
}

presentation->Dispose();
```

Geçersiz bir sonuç genellikle imzalı sunum içeriği veya imza verisinin imzalama sonrasında değiştiği veya dosyanın bozulduğu anlamına gelir. Tüm imzaları kaldırmak, imzasız bir sunum üretir; bu nedenle yalnızca öğelerin geçerliliğini kontrol etmek yeterli değildir: güvenlik duyarlı bir iş akışı, beklenen imza sayısının ve beklenen imzalayan kimliklerin mevcut olduğunu da doğrulamalıdır.

Bu geçerlilik sonucu, tam bir sertifika güven kararı olarak ele alınmamalıdır. Güvenlik politikanıza bağlı olarak, uygulamanız X.509 sertifika zincirini oluşturup doğrulamalı, sertifika geçerlilik tarihlerini ve iptal durumunu kontrol etmeli, beklenen konu ya da parmak izini teyit etmeli, anahtar kullanımını doğrulamalı ve güvenilir bir zaman damgasını değerlendirmelidir. [IDigitalSignature::get_SignTime](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idigitalsignature/get_signtime/) değeri tek başına güvenilir bir zaman damgası otoritesinden kanıt sağlamaz.

## **Dijital İmzaları Kaldırma**

İmzaları kaldırmak, sunumun güvenlik durumunu değiştirir. Aşağıdaki örnek, imzalı bir PPTX dosyasını yükler, tüm imzaları [IDigitalSignatureCollection::Clear](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idigitalsignaturecollection/clear/) ile kaldırır ve imzasız bir kopya kaydeder.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

presentation->get_DigitalSignatures()->Clear();
presentation->Save(u"InputPresentation-unsigned.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Yalnızca bir imzayı kaldırmak için, sıfır tabanlı indeksini kullanarak [IDigitalSignatureCollection::RemoveAt](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idigitalsignaturecollection/removeat/) çağırın. İmzalı orijinali üzerine yazmak açık bir iş akışı gerektirmiyorsa, yeni bir dosyaya kaydedin.

## **Düzenleme ve Biçim Hususları**

- Bir imza, bir sunumu salt okunur yapmaz. Kullanıcılar ve uygulamalar dosyayı hâlâ düzenleyebilir, ancak imzalı içeriğe yapılan değişiklikler genellikle mevcut imzayı geçersiz kılar.
- İmzalamadan önce tüm istenen düzenlemeleri tamamlayın. Sunumun değiştirilmesi gerekiyorsa, revize edilmiş sunumu kaydedin ve o revizyonu yeniden imzalayın.
- Son çıktıyı PPTX biçiminde tutun. İmzalı bir sunumu başka bir formata dönüştürmek, orijinal PPTX imzasını dönüştürülmüş dosya için geçerli bir imza olarak taşımaz.
- Sertifikanın özel anahtarını hassas bir bilgi olarak tutun. Özel anahtar ve parolasını elde eden herkes, o sertifika sahibiymiş gibi imzalar oluşturabilir.
- Belgelerin saklama politikanız gerektiriyorsa, imzasız kaynağı veya başka kontrollü bir kopyayı koruyun.

## **SSS**

**Bir dijital imza sunumu şifreler mi?**

Hayır. Dijital bir imza, köken ve bütünlük kanıtı sağlar, ancak içerik ayrı bir şifreleme uygulanmadıkça okunabilir kalır. İçeriğe erişimin kısıtlanması gerektiğinde [parola koruması](/cpp/password-protected-presentation/) kullanın.

**PFX parolası sunum parolasıyla aynı mı?**

Hayır. PFX parolası, sertifika paketindeki özel anahtarın kilidini açar. PPTX dosyasını kimlerin açıp düzenleyebileceğini kontrol etmez.

**Kendinden imzalı bir sertifika kullanabilir miyim?**

Teknik olarak, erişilebilir bir özel anahtar içeriyorsa kendinden imzalı bir sertifika kullanılabilir. Alıcılar otomatik olarak güvenmez; ancak bu sertifika açıkça güvenilir ortama eklenmişse güvenilir olur. Kamu ya da çapraz organizasyon iş akışları genellikle güvenilir bir CA tarafından verilen bir sertifika kullanır.

**Bir imzayı geçersiz kılan nedir?**

İmzalı sunum içeriğini veya imza verisini imzalama sonrasında değiştirmek imzayı geçersiz kılar. Dosya bozulması da doğrulamayı başarısız kılabilir. Tüm imzalar kaldırılırsa, sunum bir imzasız dosya olur, geçersiz bir imza içermez.

**Geçerli bir imza imzalayan kişiye güvenmem gerektiği anlamına mı gelir?**

Tek başına değildir. İmza bütünlüğü ve imzalayan güveni ayrı kararlar olarak değerlendirilir. Üretim doğrulama politikası aynı zamanda sertifika zincirini, geçerlilik süresini, iptal durumunu, beklenen kimliği, anahtar kullanımını ve olası güvenilir zaman damgası gereksinimlerini kontrol etmelidir.

**Sertifikanın süresi dolarsa ne olur?**

Sertifikanın süresi dolması sunum baytlarını değiştirmez, ancak sertifika güven değerlendirmesini etkiler. Bir imzanın kabul edilebilir olup olmadığı politikaya ve geçerli bir güvenilir zaman damgasının, imzalamanın sertifikanın geçerli olduğu sırada gerçekleştiğini kanıtlayıp kanıtlamadığına bağlıdır. Tek başına gösterilen imzalama zamanına güvenilir bir zaman damgası olarak dayanmayın.

**İmzalı bir sunum hâlâ düzenlenebilir mi?**

Evet. İmzalama dosyayı kilitlemez. İmzalı içeriği düzenlemek genellikle mevcut imzayı geçersiz kılar; bu yüzden önce sunumu tamamlayıp son revizyonu imzalayın.

**Bir sunum birden fazla imza içerebilir mi?**

Evet. Kaydetmeden önce her bir imzayı [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/get_digitalsignatures/) tarafından döndürülen koleksiyona ekleyin. Doğrulama sırasında her imzayı inceleyin ve tüm gerekli imzalayanların mevcut olduğunu teyit edin.

**Hangi sunum biçimleri bu işlemleri destekler?**

Aspose.Slides, burada açıklanan dijital imza işlemlerini yalnızca PPTX için destekler. PPT ve OpenDocument sunum biçimleri bu API iş akışı tarafından desteklenmez.

**İmza kaldırıldığında slaytlar etkilenir mi?**

Evet. Tek bir imzayı kaldırabilir veya tüm koleksiyonu temizleyip ardından sunumu kaydedebilirsiniz. Slayt içeriği mevcut kalır, ancak kaydedilen dosya artık kaldırılan imza kanıtını taşımaz.