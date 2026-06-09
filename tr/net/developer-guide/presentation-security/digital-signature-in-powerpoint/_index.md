---
title: .NET'te Sunumlara Dijital İmzalar Ekleme
linktitle: Dijital İmza
type: docs
weight: 10
url: /tr/net/digital-signature-in-powerpoint/
keywords:
- dijital imza
- dijital sertifika
- sertifika otoritesi
- PFX sertifikası
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint ve OpenDocument dosyalarını dijital olarak nasıl imzalayacağınızı öğrenin. Açık kod örnekleriyle slaytlarınızı saniyeler içinde güvenceye alın."
---
## **Giriş**

**Dijital sertifika** şifre korumalı bir PowerPoint sunumu oluşturmak için kullanılır ve belirli bir kuruluş veya kişi tarafından oluşturulmuş olarak işaretlenir. Dijital sertifika, yetkili bir kuruluş - bir sertifika otoritesi ile iletişime geçilerek elde edilebilir. Dijital sertifika sisteminize kurulduktan sonra, Dosya -> Bilgi -> Sunumu Koruma yoluyla sunuma dijital imza eklemek için kullanılabilir:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Sunum birden fazla dijital imza içerebilir. Dijital imza sunuma eklendikten sonra, PowerPoint'te özel bir mesaj görüntülenir:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Sunumu imzalamak veya sunum imzalarının özgünlüğünü kontrol etmek için **Aspose.Slides API**, [**IDigitalSignature**](https://reference.aspose.com/slides/tr/net/aspose.slides/idigitalsignature) arayüzünü, [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/tr/net/aspose.slides/IDigitalSignatureCollection) arayüzünü ve [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/properties/digitalsignatures) özelliğini sağlar. Şu anda, dijital imzalar yalnızca PPTX formatı için desteklenmektedir.

## **PFX Sertifikasından Dijital İmza Ekleme**

Aşağıdaki kod örneği, bir PFX sertifikasından dijital imza eklemenin nasıl yapılacağını gösterir:

1. PFX dosyasını açın ve PFX şifresini [**DigitalSignature**](https://reference.aspose.com/slides/tr/net/aspose.slides/digitalsignature) nesnesine iletin.
1. Oluşturulan imzayı sunum nesnesine ekleyin.

```c#
using (Presentation pres = new Presentation())
{
    // PFX dosyası ve PFX parolasıyla DigitalSignature nesnesi oluştur.
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", @"testpass1");

    // Yeni dijital imzaya yorum ekle.
    signature.Comments = "Aspose.Slides digital signing test.";

    // Dijital imzayı sunuma ekle.
    pres.DigitalSignatures.Add(signature);

    // Sunumu kaydet.
    pres.Save("SomePresentationSigned.pptx", SaveFormat.Pptx);
}
```



Artık sunumun dijital olarak imzalanıp imzalanmadığını ve değiştirilip değiştirilmediğini kontrol etmek mümkün:

```c#
// Sunumu aç
using (Presentation pres = new Presentation("SomePresentationSigned.pptx"))
{
    if (pres.DigitalSignatures.Count > 0)
    {
        bool allSignaturesAreValid = true;

        Console.WriteLine("Signatures used to sign the presentation: ");

        // Tüm dijital imzaların geçerli olup olmadığını kontrol et
        foreach (DigitalSignature signature in pres.DigitalSignatures)
        {
            Console.WriteLine(signature.Certificate.SubjectName.Name + ", "
                    + signature.SignTime.ToString("yyyy-MM-dd HH:mm") + " -- " + (signature.IsValid ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.IsValid;
        }

        if (allSignaturesAreValid)
            Console.WriteLine("Presentation is genuine, all signatures are valid.");
        else
            Console.WriteLine("Presentation has been modified since signing.");
    }
}
```

## **SSS**

**Bir dosyadan mevcut imzaları kaldırabilir miyim?**

Evet. Dijital imzalar koleksiyonu, [bireysel öğeleri kaldırmayı](https://reference.aspose.com/slides/tr/net/aspose.slides/digitalsignaturecollection/removeat/) ve [tamamen temizlemeyi](https://reference.aspose.com/slides/tr/net/aspose.slides/digitalsignaturecollection/clear/) destekler; dosyayı kaydettikten sonra, sunumda imza kalmaz.

**İmzaladıktan sonra dosya "salt okunur" olur mu?**

Hayır. Bir imza bütünlüğü ve yazarlığı korur ancak düzenlemeleri engellemez. Düzenlemeyi kısıtlamak için bunu ["Salt okunur" veya bir parola](/slides/tr/net/password-protected-presentation/) ile birleştirin.

**İmza, PowerPoint'in farklı sürümlerinde doğru şekilde görüntülenecek mi?**

İmza OOXML (PPTX) konteyneri için oluşturulmuştur. OOXML imzalarını destekleyen modern PowerPoint sürümleri, bu imzaların durumunu doğru şekilde gösterir.