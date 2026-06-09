---
title: Sunumlara JavaScript'te Dijital İmzalar Ekle
linktitle: Dijital İmza
type: docs
weight: 10
url: /tr/nodejs-java/digital-signature-in-powerpoint/
keywords:
- dijital imza
- dijital sertifika
- sertifika otoritesi
- PFX sertifikası
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js kullanarak Java üzerinden PowerPoint ve OpenDocument dosyalarını dijital olarak imzalamayı öğrenin. Temiz kod örnekleriyle slaytlarınızı saniyeler içinde güvenceye alın."
---
## **Giriş**

**Digital certificate** şifre korumalı bir PowerPoint sunumu oluşturmak için kullanılır ve belirli bir organizasyon veya kişi tarafından oluşturulmuş olarak işaretlenir. Digital certificate, yetkili bir kuruluş - bir sertifika otoritesi ile iletişime geçilerek elde edilebilir. Digital certificate sisteminize kurulduktan sonra, Dosya -> Bilgi -> Sunumu Koru yoluyla sunuma bir dijital imza eklemek için kullanılabilir:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Sunum birden fazla dijital imza içerebilir. Dijital imza eklendikten sonra, PowerPoint'te özel bir mesaj görüntülenir:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Sunumu imzalamak veya imzaların doğruluğunu kontrol etmek için **Aspose.Slides API**, [**DigitalSignature**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/DigitalSignature) sınıfını, [**DigitalSignatureCollection**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/DigitalSignatureCollection) sınıfını ve [**Presentation.getDigitalSignatures**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation#getDigitalSignatures--) metodunu sağlar. Şu anda dijital imzalar yalnızca PPTX formatı için desteklenmektedir.

## **PFX Sertifikasından Dijital İmza Ekle**
Aşağıdaki kod örneği, bir PFX sertifikasından dijital imza nasıl eklenir gösterir:

1. PFX dosyasını açın ve PFX şifresini **DigitalSignature** nesnesine iletin.
2. Oluşturulan imzayı sunum nesnesine ekleyin.

```javascript
// Sunum dosyasını açma
var pres = new aspose.slides.Presentation();
try {
    // PFX dosyası ve PFX şifresiyle DigitalSignature nesnesi oluştur
    var signature = new aspose.slides.DigitalSignature("testsignature1.pfx", "testpass1");
    // Yeni dijital imzaya yorum ekle
    signature.setComments("Aspose.Slides digital signing test.");
    // Dijital imzayı sunuma ekle
    pres.getDigitalSignatures().add(signature);
    // Sunumu kaydet
    pres.save("SomePresentationSigned.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Artık sunumun dijital olarak imzalanıp imzalanmadığını ve değiştirilip değiştirilmediğini kontrol etmek mümkün:

```javascript
// Sunumu aç
var pres = new aspose.slides.Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0) {
        var allSignaturesAreValid = true;
        console.log("Signatures used to sign the presentation: ");
        // Tüm dijital imzaların geçerli olup olmadığını kontrol et
        for (let i = 0; i < pres.getDigitalSignatures().size(); i++) {
        let signature = pres.getDigitalSignatures().get_Item(i);
            console.log((((signature.getComments() + ", ") + signature.getSignTime().toString()) + " -- ") + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }
        if (allSignaturesAreValid) {
            console.log("Presentation is genuine, all signatures are valid.");
        } else {
            console.log("Presentation has been modified since signing.");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Bir dosyadan mevcut imzaları kaldırabilir miyim?**

Evet. Dijital imza koleksiyonu, [removing individual items](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) ve [clearing it entirely](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/digitalsignaturecollection/clear/) destekler; dosyayı kaydettikten sonra sunumun imzası olmayacaktır.

**İmzaladıktan sonra dosya "salt okunur" olur mu?**

Hayır. Bir imza bütünlüğü ve sahipliği korur ancak düzenlemeleri engellemez. Düzenlemeyi kısıtlamak için bunu ["Read-only" or a password](/slides/tr/nodejs-java/password-protected-presentation/) ile birleştirin.

**İmza farklı PowerPoint sürümlerinde doğru görüntülenecek mi?**

İmza OOXML (PPTX) konteyneri için oluşturulur. OOXML imzalarını destekleyen modern PowerPoint sürümleri, bu imzaların durumunu doğru bir şekilde gösterir.