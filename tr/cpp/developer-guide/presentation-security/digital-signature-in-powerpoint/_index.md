---
title: C++ ile Sunumlara Dijital İmza Ekleme
linktitle: Dijital İmza
type: docs
weight: 10
url: /tr/cpp/digital-signature-in-powerpoint/
keywords:
- dijital imza
- dijital sertifika
- sertifika otoritesi
- PFX sertifikası
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PowerPoint ve OpenDocument dosyalarına nasıl dijital imza ekleyeceğinizi öğrenin. Açık kod örnekleriyle slaytlarınızı saniyeler içinde güvenceye alın."
---
## **Giriş**

**Dijital sertifika** bir parola korumalı PowerPoint sunumu oluşturmak, belirli bir kuruluş veya kişi tarafından oluşturulmuş olarak işaretlenmek için kullanılır. Dijital sertifika, yetkili bir kuruluş – bir sertifika otoritesi – ile iletişime geçilerek elde edilebilir. Dijital sertifika sistemi kurulduktan sonra, **File -> Info -> Protect Presentation** yoluyla sunuma dijital imza eklemek için kullanılabilir:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Sunum birden fazla dijital imza içerebilir. Dijital imza sunuma eklendikten sonra, PowerPoint'te özel bir mesaj görüntülenecektir:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Sunumu imzalamak veya sunum imzalarının özgünlüğünü kontrol etmek için **Aspose.Slides API** [**IDigitalSignature**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_digital_signature) arayüzünü, [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_digital_signature_collection) arayüzünü ve [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_presentation#a6f78aff0f8ffa07ff67368fa003722b1) yöntemini sağlar. Şu anda dijital imzalar yalnızca PPTX formatı için desteklenmektedir.

## **PFX Sertifikasından Dijital İmza Ekleme**
Aşağıdaki kod örneği, bir PFX sertifikasından dijital imza eklemeyi gösterir:

1. PFX dosyasını açın ve PFX şifresini [**DigitalSignature**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.digital_signature) nesnesine geçirin.
2. Oluşturulan imzayı sunum nesnesine ekleyin.

``` cpp
auto pres = System::MakeObject<Presentation>();

// PFX dosyası ve PFX şifresi ile DigitalSignature nesnesi oluştur 
auto signature = System::MakeObject<DigitalSignature>(u"testsignature1.pfx", u"testpass1");

// Yeni dijital imzaya yorum ekle
signature->set_Comments(u"Aspose.Slides digital signing test.");

// Dijital imzayı sunuma ekle
pres->get_DigitalSignatures()->Add(signature);

// Sunumu kaydet
pres->Save(u"SomePresentationSigned.pptx", SaveFormat::Pptx);
```

Şimdi sunumun dijital olarak imzalanıp imzalanmadığını ve değiştirilip değiştirilmediğini kontrol etmek mümkündür:

``` cpp
// Sunumu aç
auto pres = System::MakeObject<Presentation>(u"SomePresentationSigned.pptx");

if (pres->get_DigitalSignatures()->get_Count() > 0)
{
    bool allSignaturesAreValid = true;

    Console::WriteLine(u"Signatures used to sign the presentation: ");

    // Tüm dijital imzaların geçerli olup olmadığını kontrol et
    for (auto signature : pres->get_DigitalSignatures())
    {
        Console::WriteLine(signature->get_Certificate()->get_SubjectName()->get_Name() 
            + u", " 
            + signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm") 
            + u" -- " 
            + (signature->get_IsValid() ? System::String(u"VALID") : System::String(u"INVALID")));
        allSignaturesAreValid &= signature->get_IsValid();
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"Presentation is genuine, all signatures are valid.");
    }
    else
    {
        Console::WriteLine(u"Presentation has been modified since signing.");
    }
}
```

## **SSS**

**Dosyadan mevcut imzaları kaldırabilir miyim?**

Evet. Dijital imza koleksiyonu, [tek bir öğeyi kaldırma](https://reference.aspose.com/slides/tr/cpp/aspose.slides/digitalsignaturecollection/removeat/) ve [tamamen temizleme](https://reference.aspose.com/slides/tr/cpp/aspose.slides/digitalsignaturecollection/clear/) yeteneklerini destekler; dosyayı kaydettikten sonra, sunumda hiçbir imza bulunmayacaktır.

**İmzaladıktan sonra dosya "salt okunur" olur mu?**

Hayır. Bir imza bütünlüğü ve yazar kimliğini korur ancak düzenlemeyi engellemez. Düzenlemeyi kısıtlamak için ["Read-only" or a password](/slides/tr/cpp/password-protected-presentation/) ile birleştirebilirsiniz.

**İmza farklı PowerPoint sürümlerinde doğru şekilde görüntülenecek mi?**

İmza, OOXML (PPTX) kapsayıcısı için oluşturulmuştur. OOXML imzalarını destekleyen modern PowerPoint sürümleri, bu imzaların durumunu doğru bir şekilde gösterir.