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
- imzayı doğrulama
- PowerPoint
- PPTX
- sunum güvenliği
- C++
- Aspose.Slides
description: "PFX sertifikalarıyla mevcut PPTX sunumlarını nasıl imzalayacağınızı ve C++ için Aspose.Slides'ı dijital imzaları doğrulamak veya kaldırmak için nasıl kullanacağınızı öğrenin."
---
## **Genel Bakış**

Dijital imza, alıcıya bir sunumu kimin imzaladığını ve imzalanmış içeriğin değişip değişmediğini belirlemesine yardımcı olur. Burada üç ilgili güvenlik kavramı önemlidir:

- **Dijital sertifika**, bir kimliği bir açık anahtarla ilişkilendiren elektronik kimlik doğrulama belgesidir. Güvenilir bir sertifika otoritesi (CA) sertifika çıkarabilir veya bir kuruluş dahili iş akışları için kendinden imzalı bir sertifika kullanabilir.
- **Dijital imza**, sunum içeriği ve sertifika sahibinin özel anahtarı kullanılarak oluşturulur. Sertifikanın açık anahtarı daha sonra imzayı doğrulamak için kullanılabilir. Bir imza, kaynağın ve bütünlüğün kanıtını sağlar; sunumu şifrelemez.
- **Şifre koruması**, bir kullanıcının bir sunumu açıp açamayacağını veya değiştirebileceğini kontrol eder. Dijital imzalamadan ayrı bir konudur ve [Şifre Koruması ile Sunumlar](/slides/tr/cpp/password-protected-presentation/) başlığında açıklanmıştır.

PowerPoint, **Dosya > Bilgi > Sunumu Koru** altındaki **Dijital İmza Ekle** komutunu sağlar.

![PowerPoint Sunumu Koru menüsü, Dijital İmza Ekle vurgulanmış şekilde](add-digital-signature-in-powerpoint.png)

İmzalı bir sunum açıldıktan sonra, PowerPoint bir imza durumu bildirimi gösterebilir.

![PowerPoint bildirimi, sunumun geçerli imzalar içerdiğini belirtiyor](digital-signature-status-in-powerpoint.png)

Aspose.Slides, imzaları [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/get_digitalsignatures/) aracılığıyla açığa çıkarır; bu yöntem, öğeleri [IDigitalSignature] uygulayan bir [IDigitalSignatureCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idigitalsignaturecollection/) döndürür. Bir sunum birden fazla imza içerebilir.

## **PFX Sertifikalarını ve Şifreleri Anlamak**

PFX dosyası, PKCS#12 dosyası olarak da bilinir ve genellikle `.pfx` veya `.p12` uzantılıdır; X.509 sertifikası, onun özel anahtarı ve sertifika zincirini içerebilir. Özel anahtar, sahibine imza oluşturma olanağı verir. Erişilebilir bir özel anahtarı olmayan bir sertifika, bir sunumu imzalamak için kullanılamaz.

PFX şifresi, sertifika paketi ve özel anahtarı korur. Bu **sunumu açmak veya düzenlemek** için bir şifre değildir. PFX dosyalarını veya şifrelerini kaynak kontrolüne commit etmeyin. Üretim ortamında, sertifika dosyasına erişimi sınırlayın ve şifresini bir gizli mağazadan ya da başka bir korumalı yapılandırma kaynağından alın. Aşağıdaki örneklerde şifreyi kod içine gömmekten kaçınmak için yalnızca bir ortam değişkeni kullanılmaktadır.

## **Bir Sunuma Dijital İmza Ekleme**

Gerçek bir sunum iş akışını imzalamak için, mevcut bir PPTX dosyasını yükleyin, bir PFX sertifikası ve şifresinden bir [DigitalSignature](https://reference.aspose.com/slides/tr/cpp/aspose.slides/digitalsignature/) oluşturun, imzayı sunumun koleksiyonuna ekleyin ve PPTX dosyasına kaydedin.

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

Sonucu yeni bir adla kaydetmek, imzasız kaynak dosyasını korur. [IDigitalSignature::set_Comments](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idigitalsignature/set_comments/) değeri imzanın amacını açıklar; bu bir güvenlik kontrolü değildir.

## **Dijital İmzaları Doğrulama**

İmzalı bir PPTX dosyası yüklediğinizde, [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/get_digitalsignatures/) tarafından döndürülen her öğeyi inceleyin. [IDigitalSignature::get_IsValid](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idigitalsignature/get_isvalid/) yöntemi, gömülü imzanın geçerli sunum içeriği için geçerli olup olmadığını gösterir.

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

Geçersiz bir sonuç genellikle, imzalı sunum içeriğinin veya imza verisinin imzalama sonrasında değiştiği ya da dosyanın bozuk olduğu anlamına gelir. Tüm imzaların kaldırılması imzasız bir sunum oluşturur; bu nedenle yalnızca öğelerin geçerliliğinin kontrol edilmesi yeterli değildir: güvenliğe duyarlı bir iş akışı, beklenen imza sayısının ve beklenen imzalayan kimliklerinin mevcut olduğunu da doğrulamalıdır.

Bu geçerlilik sonucu, tam bir sertifika güven kararı olarak değerlendirilmemelidir. Güvenlik politikanıza bağlı olarak uygulamanız, X.509 sertifika zincirini oluşturup doğrulamalı, sertifika geçerlilik tarihlerini ve iptal durumunu kontrol etmeli, beklenen konu ya da parmak izini doğrulamalı, anahtar kullanımını denetlemeli ve güvenilir bir zaman damgasını değerlendirmelidir. [IDigitalSignature::get_SignTime](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idigitalsignature/get_signtime/) değeri tek başına güvenilir bir zaman damgası otoritesinden bir kanıt değildir.

## **Dijital İmzaları Kaldırma**

İmzaların kaldırılması, sunumun güvenlik durumunu değiştirir. Aşağıdaki örnek, imzalı bir PPTX dosyasını yükler, tüm imzaları [IDigitalSignatureCollection::Clear](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idigitalsignaturecollection/clear/) ile kaldırır ve imzasız bir kopya kaydeder.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

presentation->get_DigitalSignatures()->Clear();
presentation->Save(u"InputPresentation-unsigned.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Yalnızca bir imzayı kaldırmak için, sıfır tabanlı indeksini kullanarak [IDigitalSignatureCollection::RemoveAt](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idigitalsignaturecollection/removeat/) çağırın. İş akışınızın açık bir parçası olarak signed orijinali üzerine yazmıyorsanız yeni bir dosyaya kaydedin.

## **Düzenleme ve Format Hususları**

- Bir imza, sunumu salt okunur yapmaz. Kullanıcılar ve uygulamalar dosyayı hâlâ düzenleyebilir, ancak imzalı içeriğe yapılan değişiklikler genellikle mevcut imzayı geçersiz kılar.
- İmzalamadan önce tüm planlanan düzenlemeleri tamamlayın. Sunumun değiştirilmesi gerekiyorsa, revize edilmiş sunumu kaydedin ve o revizyonu tekrar imzalayın.
- Son çıktıyı PPTX formatında tutun. İmzalı bir sunumu başka bir formata dönüştürmek, orijinal PPTX imzasını dönüştürülmüş dosya için geçerli bir imza olarak taşımaz.
- Sertifikanın özel anahtarını hassas bir veri olarak ele alın. Özel anahtar ve şifresini elde eden herkes, bu sertifika sahibinden geliyormuş gibi görünen imzalar oluşturabilir.
- Belge saklama politikanız gerektiğinde, imzasız kaynak dosyayı veya başka bir kontrol edilen kopyayı saklayın.

## **FAQ**

**Dijital bir imza sunumu şifreler mi?**

Hayır. Dijital imza, kaynağın ve bütünlüğün kanıtını sağlar; ancak içerik ayrı bir şifreleme uygulanmadıkça okunabilir kalır. İçeriğe erişimin kısıtlanması gerektiğinde [şifre koruması](/slides/tr/cpp/password-protected-presentation/) kullanın.

**PFX şifresi sunum şifresiyle aynı mı?**

Hayır. PFX şifresi, sertifika paketindeki özel anahtarı açar. PPTX dosyasını kimlerin açıp düzenleyebileceğini kontrol etmez.

**Kendinden imzalı bir sertifika kullanabilir miyim?**

Teknik olarak, erişilebilir bir özel anahtarı içeren bir kendinden imzalı sertifika kullanılabilir. Alıcılar otomatik olarak güvenmez; sertifikanın güvenilir ortamlarına açıkça eklenmesi gerekir. Genel veya çapraz‑organizasyon iş akışları genellikle güvenilir bir CA tarafından verilen sertifikalar kullanır.

**Bir imzayı geçersiz kılan nedir?**

İmzalı içerik veya imza verisinin imzalama sonrasında değiştirilmesi imzayı geçersiz kılar. Dosya bozulması da doğrulamayı başarısız yapabilir. Tüm imzalar kaldırılırsa sunum imzasız olur, geçersiz bir imza içermez.

**Geçerli bir imza, imzalayan kişiye güvenmem gerektiği anlamına mı geliyor?**

Tek başına hayır. İmza bütünlüğü ve imzalayan güveni ayrı kararlardır. Üretim doğrulama politikası ayrıca sertifika zinciri, geçerlilik süresi, iptal durumu, beklenen kimlik, anahtar kullanımı ve güvenilir zaman damgası gereksinimlerini kontrol etmelidir.

**Sertifika süresi dolduğunda ne olur?**

Sertifikanın süresi dolması sunumun baytlarını değiştirmez, ancak sertifika‑güven değerlendirmesini etkiler. Bir imzanın kabul edilebilirliği politikanıza ve geçerli bir güvenilir zaman damgasının imzalamanın sertifikanın geçerli olduğu zamanda gerçekleştiğini kanıtlayıp kanıtlamadığına bağlıdır. Tek başına gösterilen imzalama zamanı güvenilir bir zaman damgası olarak kullanılmamalıdır.

**İmzalı bir sunum hâlâ düzenlenebilir mi?**

Evet. İmzalama dosyayı kilitlemez. İmzalı içeriği düzenlemek genellikle mevcut imzayı geçersiz kılar; bu yüzden sunumu önce tamamlayıp ardından son revizyonu imzalayın.

**Bir sunum birden fazla imza içerebilir mi?**

Evet. Kaydedilmeden önce her imzayı [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/get_digitalsignatures/) tarafından döndürülen koleksiyona ekleyin. Doğrulama sırasında her imzayı inceleyin ve gerekli tüm imzalayanların mevcut olduğunu teyit edin.

**Hangi sunum formatları bu işlemleri destekler?**

Aspose.Slides, burada anlatılan dijital‑imza işlemlerini yalnızca PPTX için destekler. PPT ve OpenDocument sunum formatları bu API iş akışıyla desteklenmez.

**İmzayı slaytlara etkisi olmadan kaldırabilir miyim?**

Evet. Tek bir imzayı kaldırabilir veya tüm koleksiyonu temizleyebilir ve ardından sunumu kaydedebilirsiniz. Slayt içeriği korunur, ancak kaydedilen dosyada kaldırılan imza kanıtı bulunmaz.