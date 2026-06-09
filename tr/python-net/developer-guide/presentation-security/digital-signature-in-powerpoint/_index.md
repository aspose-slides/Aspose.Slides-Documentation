---
title: Python ile Sunumlara Dijital İmzalar Ekleyin
linktitle: Dijital İmza
type: docs
weight: 10
url: /tr/python-net/digital-signature-in-powerpoint/
keywords:
- dijital imza
- dijital sertifika
- sertifika otoritesi
- PFX sertifikası
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint ve OpenDocument dosyalarını nasıl dijital olarak imzalayacağınızı öğrenin. Net kod örnekleriyle slaytlarınızı saniyeler içinde güvenceye alın."
---
## **Giriş**

**Dijital sertifika**, belirli bir organizasyon veya kişi tarafından oluşturulduğu işaretlenmiş, parola korumalı bir PowerPoint sunumu oluşturmak için kullanılır. Dijital sertifika, yetkili bir kuruluş - bir sertifika yetkilisi ile iletişime geçilerek elde edilebilir. Dijital sertifika sistemi kurulduktan sonra, Dosya -> Bilgi -> Sunumu Koru yoluyla sunuma dijital imza eklemek için kullanılabilir:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Sunum birden fazla dijital imza içerebilir. Dijital imza sunuma eklendikten sonra, PowerPoint'te özel bir mesaj görüntülenir:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Sunumu imzalamak veya sunum imzalarının doğruluğunu kontrol etmek için **Aspose.Slides API**, [**DigitalSignature**](https://reference.aspose.com/slides/tr/python-net/aspose.slides/digitalsignature/) sınıfını, [**DigitalSignatureCollection**](https://reference.aspose.com/slides/tr/python-net/aspose.slides/DigitalSignatureCollection/) sınıfını ve [**Presentation.digital_signatures**](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/digital_signatures/) özelliğini sağlar. Şu anda dijital imzalar yalnızca PPTX formatı için desteklenmektedir.

## **PFX Sertifikasından Dijital İmza Ekleme**

Aşağıdaki kod örneği, bir PFX sertifikasından dijital imza nasıl eklenir gösterir:

1. PFX dosyasını açın ve PFX şifresini [**DigitalSignature**](https://reference.aspose.com/slides/tr/python-net/aspose.slides/digitalsignature/) nesnesine aktarın.
1. Oluşturulan imzayı sunum nesnesine ekleyin.

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    # PFX dosyası ve PFX şifresi ile DigitalSignature nesnesi oluştur
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # Yeni dijital imzayı yorumla
    signature.comments = "Aspose.Slides digital signing test."

    # Dijital imzayı sunuma ekle
    pres.digital_signatures.add(signature)

    # Sunumu kaydet
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```

Artık sunumun dijital olarak imzalanıp imzalanmadığını ve değiştirilip değiştirilmediğini kontrol etmek mümkün:

```py
# Sunumu aç
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Signatures used to sign the presentation: ")
        # Tüm dijital imzaların geçerli olup olmadığını kontrol et
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "VALID" if signature.is_valid else "INVALID")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        

        if allSignaturesAreValid:
            print("Presentation is genuine, all signatures are valid.")
        else:
            print("Presentation has been modified since signing.")
```

## **SSS**

**Bir dosyadan mevcut imzaları kaldırabilir miyim?**

Evet. Dijital imzalar koleksiyonu [bireysel öğeleri kaldırmayı](https://reference.aspose.com/slides/tr/python-net/aspose.slides/digitalsignaturecollection/remove_at/) ve koleksiyonu tamamen [temizlemeyi](https://reference.aspose.com/slides/tr/python-net/aspose.slides/digitalsignaturecollection/clear/) destekler; dosyayı kaydettikten sonra, sunumda hiçbir imza bulunmayacaktır.

**İmzaladıktan sonra dosya “salt okunur” olur mu?**

Hayır. Bir imza bütünlüğü ve yazarlığı korur ancak düzenlemeleri engellemez. Düzenlemeyi kısıtlamak için, bunu ["Read-only" veya bir parola](/slides/tr/python-net/password-protected-presentation/) ile birleştirin.

**İmza farklı PowerPoint sürümlerinde doğru görüntülenecek mi?**

İmza, OOXML (PPTX) konteyneri için oluşturulur. OOXML imzalarını destekleyen modern PowerPoint sürümleri, bu imzaların durumunu doğru şekilde görüntüler.