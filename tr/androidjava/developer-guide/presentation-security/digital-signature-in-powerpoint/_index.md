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
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile PowerPoint ve OpenDocument dosyalarını nasıl dijital olarak imzalayacağınızı öğrenin. Net Java kod örnekleriyle slaytlarınızı saniyeler içinde güvenceye alın."
---
## **Giriş**

**Dijital sertifika**, belirli bir kuruluş veya kişi tarafından oluşturulduğu işaretlenmiş, parola korumalı bir PowerPoint sunumu oluşturmak için kullanılır. Dijital sertifika, yetkili bir kuruluşa - bir sertifika otoritesine başvurarak elde edilebilir. Dijital sertifika sistemi kurulduktan sonra, File -> Info -> Protect Presentation aracılığıyla sunuma dijital imza eklemek için kullanılabilir:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Sunum birden fazla dijital imza içerebilir. Dijital imza sunuma eklendikten sonra, PowerPoint içinde özel bir mesaj görüntülenir:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Sunumu imzalamak veya imzaların özgünlüğünü kontrol etmek için **Aspose.Slides API**, [**IDigitalSignature**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IDigitalSignature) arayüzünü, [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IDigitalSignatureCollection) arayüzünü ve [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IPresentation#getDigitalSignatures--) yöntemini sağlar. Şu anda dijital imzalar yalnızca PPTX formatı için desteklenmektedir.
## **PFX Sertifikasından Dijital İmza Ekleme**
Aşağıdaki kod örneği, PFX sertifikasından dijital imza eklemenin nasıl yapılacağını gösterir:

1. PFX dosyasını açın ve PFX şifresini [**DigitalSignature**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/DigitalSignature) nesnesine aktarın.
1. Oluşturulan imzayı sunum nesnesine ekleyin.

```java
// Sunum dosyasını açma
Presentation pres = new Presentation();
try {
    // PFX dosyası ve PFX şifresi ile DigitalSignature nesnesi oluştur
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // Yeni dijital imzaya açıklama ekle
    signature.setComments("Aspose.Slides digital signing test.");

    // Sunuma dijital imza ekle
    pres.getDigitalSignatures().add(signature);

    // Sunumu kaydet
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Artık sunumun dijital olarak imzalanıp imzalanmadığını ve değiştirilip değiştirilmediğini kontrol etmek mümkündür:

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

**Bir dosyadan mevcut imzaları kaldırabilir miyim?**

Evet. Dijital imza koleksiyonu, [tek tek öğeleri kaldırmayı](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/digitalsignaturecollection/#removeAt-int-) ve [tamamen temizlemeyi](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/digitalsignaturecollection/#clear--) destekler; dosyayı kaydettikten sonra sunumda imza kalmayacaktır.

**İmzaladıktan sonra dosya "salt okunur" olur mu?**

Hayır. İmza bütünlüğü ve yazar kimliğini korur ancak düzenlemeyi engellemez. Düzenlemeyi kısıtlamak için bunu ["Salt Okunur" veya bir parola](/slides/tr/androidjava/password-protected-presentation/) ile birleştirin.

**İmza, PowerPoint'in farklı sürümlerinde doğru şekilde görüntülenecek mi?**

İmza, OOXML (PPTX) konteyneri için oluşturulur. OOXML imzalarını destekleyen modern PowerPoint sürümleri, bu imzaların durumunu doğru şekilde gösterir.