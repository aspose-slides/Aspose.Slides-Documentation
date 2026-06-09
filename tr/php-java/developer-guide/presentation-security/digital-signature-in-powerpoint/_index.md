---
title: PHP'de Sunumlara Dijital İmza Ekleme
linktitle: Dijital İmza
type: docs
weight: 10
url: /tr/php-java/digital-signature-in-powerpoint/
keywords:
- dijital imza
- dijital sertifika
- sertifika otoritesi
- PFX sertifikası
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint ve OpenDocument dosyalarını dijital olarak nasıl imzalayacağınızı öğrenin. Açık kod örnekleriyle slaytlarınızı saniyeler içinde güvence altına alın."
---
## **Giriş**

**Dijital sertifika** bir şifreyle korunan PowerPoint sunumu oluşturmak için kullanılır, belirli bir kuruluş veya kişi tarafından oluşturulmuş olarak işaretlenir. Dijital sertifika, yetkili bir kuruluş - bir sertifika otoritesi ile iletişime geçilerek temin edilebilir. Dijital sertifika sisteme kurulduktan sonra, Dosya -> Bilgi -> Sunumu Koru aracılığıyla sunuma dijital imza eklemek için kullanılabilir:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Sunum birden fazla dijital imza içerebilir. Dijital imza sunuma eklendikten sonra, PowerPoint'te özel bir mesaj görüntülenir:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Sunumu imzalamak veya sunum imzalarının özgünlüğünü kontrol etmek için **Aspose.Slides API** [**DigitalSignature**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/DigitalSignature) sınıfını, [**DigitalSignatureCollection**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/DigitalSignatureCollection) sınıfını ve [**Presentation::getDigitalSignatures**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation/#getDigitalSignatures) methodunu sağlar. Şu anda dijital imzalar yalnızca PPTX formatı için desteklenmektedir.

## **PFX Sertifikasından Dijital İmza Ekleme**

Aşağıdaki kod örneği, bir PFX sertifikasından dijital imza nasıl eklenir gösterir:

1. PFX dosyasını açın ve PFX şifresini [**DigitalSignature**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/DigitalSignature) nesnesine iletin.
2. Oluşturulan imzayı sunum nesnesine ekleyin.

```php
  # Sunum dosyasını açma
  $pres = new Presentation();
  try {
    # PFX dosyası ve PFX şifresi ile DigitalSignature nesnesi oluştur
    $signature = new DigitalSignature("testsignature1.pfx", "testpass1");
    # Yeni dijital imzaya yorum ekle
    $signature->setComments("Aspose.Slides digital signing test.");
    # Dijital imzayı sunuma ekle
    $pres->getDigitalSignatures()->add($signature);
    # Sunumu kaydet
    $pres->save("SomePresentationSigned.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

Artık sunumun dijital olarak imzalanıp imzalanmadığını ve değiştirilip değiştirilmediğini kontrol edebilirsiniz:

```php
  # Sunumu aç
  $pres = new Presentation("SomePresentationSigned.pptx");
  try {
    if (java_values($pres->getDigitalSignatures()->size()) > 0) {
      $allSignaturesAreValid = true;
      echo("Signatures used to sign the presentation: ");
      # Tüm dijital imzaların geçerli olup olmadığını kontrol et
      foreach($pres->getDigitalSignatures() as $signature) {
        echo($signature->getComments() . ", " . $signature->getSignTime()->toString() . " -- " . $signature->isValid() ? "VALID" : "INVALID");
        $allSignaturesAreValid &= $signature->isValid();
      }
      if ($allSignaturesAreValid) {
        echo("Presentation is genuine, all signatures are valid.");
      } else {
        echo("Presentation has been modified since signing.");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Bir dosyadan mevcut imzaları kaldırabilir miyim?**

Evet. Dijital imza koleksiyonu [tek tek öğeleri kaldırmayı](https://reference.aspose.com/slides/tr/php-java/aspose.slides/digitalsignaturecollection/removeat/) ve [tamamen temizlemeyi](https://reference.aspose.com/slides/tr/php-java/aspose.slides/digitalsignaturecollection/clear/) destekler; dosyayı kaydettikten sonra sunumun hiç imzası olmaz.

**İmzaladıktan sonra dosya "yalnızca okuma" olur mu?**

Hayır. Bir imza bütünlüğü ve yazarlığı korur ancak düzenlemeleri engellemez. Düzenlemeyi kısıtlamak için bunu [\"Yalnızca okuma\" veya bir şifre](/slides/tr/php-java/password-protected-presentation/) ile birleştirin.

**İmza farklı PowerPoint sürümlerinde doğru görüntülenecek mi?**

İmza OOXML (PPTX) konteyneri için oluşturulur. OOXML imzalarını destekleyen modern PowerPoint sürümleri, bu imzaların durumunu doğru bir şekilde gösterir.