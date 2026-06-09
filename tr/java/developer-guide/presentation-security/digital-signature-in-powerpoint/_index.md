---
title: Java’da Sunumlara Dijital İmzalar Ekleyin
linktitle: Dijital İmza
type: docs
weight: 10
url: /tr/java/digital-signature-in-powerpoint/
keywords:
- dijital imza
- dijital sertifika
- sertifika otoritesi
- PFX sertifikası
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint ve OpenDocument dosyalarını dijital olarak imzalamayı öğrenin. Açık kod örnekleriyle slaytlarınızı saniyeler içinde güvenceye alın."
---
## **Giriş**

**Digital certificate** bir şifre korumalı PowerPoint sunumu oluşturmak için kullanılır ve belirli bir kuruluş veya kişi tarafından oluşturulmuş olarak işaretlenir. Digital certificate, yetkili bir kuruluş—bir sertifika otoritesi—ile iletişime geçilerek elde edilebilir. Digital certificate sisteminize kurulduktan sonra, Dosya -> Bilgi -> Sunumu Koru aracılığıyla sunuma dijital imza eklemek için kullanılabilir:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Sunum birden fazla dijital imza içerebilir. Dijital imza sunuma eklendikten sonra PowerPoint’te özel bir mesaj görüntülenir:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Sunumu imzalamak veya sunum imzalarının özgünlüğünü kontrol etmek için **Aspose.Slides API**, [**IDigitalSignature**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IDigitalSignature) arayüzünü, [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IDigitalSignatureCollection) arayüzünü ve [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPresentation#getDigitalSignatures--) yöntemini sağlar. Şu anda dijital imzalar yalnızca PPTX formatı için desteklenmektedir.
## **PFX Sertifikasından Dijital İmza Ekleme**
Aşağıdaki kod örneği, bir PFX sertifikasından dijital imza eklemeyi gösterir:

1. PFX dosyasını açın ve PFX parolasını [**DigitalSignature**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/DigitalSignature) nesnesine iletin.
1. Oluşturulan imzayı sunum nesnesine ekleyin.

```java
// Sunum dosyasını açma
Presentation pres = new Presentation();
try {
    // PFX dosyası ve PFX parolasıyla DigitalSignature nesnesi oluştur
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // Yeni dijital imzaya yorum ekle
    signature.setComments("Aspose.Slides digital signing test.");

    // Dijital imzayı sunuma ekle
    pres.getDigitalSignatures().add(signature);

    // Sunumu kaydet
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Artık sunumun dijital olarak imzalı olup olmadığını ve değiştirilip değiştirilmediğini kontrol etmek mümkündür:

```java
// Sunumu aç
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("Signatures used to sign the presentation: ");

        // Tüm dijital imzaların geçerli olup olmadığını kontrol et
        for (IDigitalSignature signature : pres.getDigitalSignatures())
        {
            System.out.println(signature.getComments() + ", "
                    + signature.getSignTime().toString() + " -- " + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }

        if (allSignaturesAreValid)
            System.out.println("Presentation is genuine, all signatures are valid.");
        else
            System.out.println("Presentation has been modified since signing.");
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Bir dosyadaki mevcut imzaları kaldırabilir miyim?**

Evet. Dijital imza koleksiyonu, [bireysel öğeleri kaldırmayı](https://reference.aspose.com/slides/tr/java/com.aspose.slides/digitalsignaturecollection/#removeAt-int-) ve [tamamen temizlemeyi](https://reference.aspose.com/slides/tr/java/com.aspose.slides/digitalsignaturecollection/#clear--) destekler; dosyayı kaydettikten sonra sunumda imza bulunmayacaktır.

**Dosya imzalandıktan sonra “yalnızca okunur” olur mu?**

Hayır. Bir imza bütünlüğü ve yazarlığı korur ancak düzenlemeyi engellemez. Düzenlemeyi kısıtlamak için bunu ["Yalnızca okunur" veya bir şifre](/slides/tr/java/password-protected-presentation/) ile birleştirin.

**İmza farklı PowerPoint sürümlerinde doğru şekilde görüntülenir mi?**

İmza OOXML (PPTX) kapsayıcısı için oluşturulmuştur. OOXML imzalarını destekleyen modern PowerPoint sürümleri, bu imzaların durumunu doğru bir şekilde gösterir.