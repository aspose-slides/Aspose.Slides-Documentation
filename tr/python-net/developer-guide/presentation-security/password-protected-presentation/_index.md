---
title: Python Kullanarak Şifreyle Güvenli Sunumlar
linktitle: Şifre Koruması
type: docs
weight: 20
url: /tr/python-net/password-protected-presentation/
keywords:
- PowerPoint kilitle
- sunumu kilitle
- PowerPoint kilidini aç
- sunum kilidini aç
- PowerPoint koru
- sunumu koru
- şifre ayarla
- şifre ekle
- PowerPoint şifrele
- sunumu şifrele
- PowerPoint şifresini çöz
- sunumu şifresini çöz
- yazma koruması
- PowerPoint güvenliği
- sunum güvenliği
- şifreyi kaldır
- korumayı kaldır
- şifrelemeyi kaldır
- şifreyi devre dışı bırak
- korumayı devre dışı bırak
- yazma korumasını kaldır
- PowerPoint sunumu
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile şifre korumalı PowerPoint ve OpenDocument sunumlarını nasıl kolayca kilitleyeceğinizi ve kilidini açacağınızı öğrenin. Üretkenliğinizi artırın ve adım adım rehberimizle sunumlarınızı güvence altına alın."
---
## **Giriş**

Bir sunumu şifreyle koruduğunuzda, sunuma belirli kısıtlamalar getiren bir şifre ayarladığınız anlamına gelir. Kısıtlamaları kaldırmak için şifrenin girilmesi gerekir. Şifre korumalı bir sunum kilitli bir sunum olarak kabul edilir.

Tipik olarak, bu kısıtlamaları bir sunumda uygulamak için şifre ayarlayabilirsiniz:

- **Değişiklik**

  Sadece belirli kullanıcıların sunumunuzu değiştirmesini istiyorsanız, bir değişiklik kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, insanlar şifreyi sağlamadıkları sürece sunumunuzdaki öğeleri değiştirmelerini, düzenlemelerini veya kopyalamalarını engeller.  

  Ancak bu durumda, şifre olmadan bile bir kullanıcı belgenize erişebilir ve açabilir. Bu sadece okuma modunda, kullanıcı sunumunuzdaki içerikleri—hiperlinkler, animasyonlar, efektler ve diğerlerini—görüntüleyebilir, ancak öğeleri kopyalayamaz veya sunumu kaydedemez.  

- **Açma**

  Sadece belirli kullanıcıların sunumunuzu açmasını istiyorsanız, bir açma kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, insanlar şifreyi sağlamadıkları sürece sunumunuzun içeriğini görmelerini bile engeller.  

  Teknik olarak, açma kısıtlaması aynı zamanda kullanıcıların sunumlarınızı değiştirmesini de engeller: İnsanlar bir sunumu açamadıklarında, üzerinde değişiklik yapamazlar.  

  **Not**: Bir sunumu açılmasını engellemek için şifreyle koruduğunuzda, sunum dosyası şifrelenir.

## Sunumu Çevrimiçi Şifreyle Nasıl Korursunuz

1. Şu sayfamıza gidin: [**Aspose.Slides Lock**](https://products.aspose.app/slides/tr/lock).

   ![todo:image_alt_text](slides-lock.png)

2. **Drop or upload your files** öğesine tıklayın.

3. Bilgisayarınızda şifreyle korumak istediğiniz dosyayı seçin.

4. Düzenleme koruması için tercih ettiğiniz şifreyi girin; görüntüleme koruması için tercih ettiğiniz şifreyi girin.

5. Kullanıcıların sunumunuzu son kopya olarak görmesini istiyorsanız, **Mark as final** kutusunu işaretleyin.

6. **PROTECT NOW.** düğmesine tıklayın.

7. **DOWNLOAD NOW.** düğmesine tıklayın.

## **Aspose.Slides'da Sunumlar İçin Şifre Koruması**
**Desteklenen formatlar**

Aspose.Slides, bu formatlardaki sunumlar için şifre koruması, şifreleme ve benzeri işlemleri destekler:

- PPTX and PPT - Microsoft PowerPoint Presentation
- ODP - OpenDocument Presentation
- OTP -  OpenDocument Presentation Template

**Desteklenen işlemler**

Aspose.Slides, sunumlarda şifre koruması kullanarak değişiklikleri önlemenizi şu yollarla sağlar:

- Sunumu şifreleme
- Sunuma yazma koruması ayarlama

**Diğer işlemler**

Aspose.Slides, şifre koruması ve şifreleme ile ilgili diğer görevleri şu şekilde gerçekleştirmenizi sağlar:

- Sunumu şifre çözme; şifreli bir sunumu açma
- Şifrelemeyi kaldırma; şifre korumasını devre dışı bırakma
- Sunumdan yazma korumasını kaldırma
- Şifreli bir sunumun özelliklerini alma
- Bir sunumun şifreli olup olmadığını kontrol etme
- Bir sunumun şifre korumalı olup olmadığını kontrol etme.

## **Sunumu Şifreleme**

Bir sunumu şifre belirleyerek şifreleyebilirsiniz. Kilitli sunumu değiştirmek için kullanıcı şifreyi girmelidir.

Bir sunumu şifrelemek veya şifreyle korumak için, [ProtectionManager](https://reference.aspose.com/slides/tr/python-net/aspose.slides/protectionmanager/) içindeki encrypt yöntemini kullanarak sunuma şifre ayarlamanız gerekir. Şifreyi encrypt yöntemine geçirirsiniz ve ardından save yöntemiyle şifrelenmiş sunumu kaydedersiniz.

Bu örnek kod, bir sunumu nasıl şifreleyeceğinizi gösterir:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Sunuma Yazma Koruması Ayarlama**

Sunuma “Değiştirmeyin” ibaresini ekleyebilirsiniz. Böylece, kullanıcılara sunumu değiştirmelerini istemediğinizi bildirirsiniz.  

**Not**: Yazma koruması süreci sunumu şifrelemez. Bu nedenle, kullanıcılar—gerçekten istiyorlarsa—sunumu değiştirebilir, ancak değişiklikleri kaydetmek için farklı bir adla sunum oluşturmak zorunda kalırlar.  

Yazma koruması ayarlamak için setWriteProtection yöntemini kullanmanız gerekir. Bu örnek kod, bir sunuma yazma koruması nasıl eklenir gösterir:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Sunumu Şifre Çözme; Şifreli Bir Sunumu Açma**

Aspose.Slides, şifresini vererek şifreli bir dosyayı yüklemenizi sağlar. Bir sunumu şifre çözmek için, parametresiz olarak [remove_encryption](https://reference.aspose.com/slides/tr/python-net/aspose.slides/protectionmanager/) metodunu çağırmanız gerekir. Ardından sunumu yüklemek için doğru şifreyi girmeniz istenir.  

Bu örnek kod, bir sunumu nasıl şifre çözeceğinizi gösterir: 

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **Şifrelemeyi Kaldırma; Şifre Korumasını Devre Dışı Bırakma**

Bir sunumdaki şifrelemeyi veya şifre korumasını kaldırabilirsiniz. Böylece, kullanıcılar sunuma kısıtlama olmadan erişebilir veya değiştirebilir.  

Şifrelemeyi veya şifre korumasını kaldırmak için [remove_encryption](https://reference.aspose.com/slides/tr/python-net/aspose.slides/protectionmanager/) metodunu çağırmanız gerekir. Bu örnek kod, bir sunumdan şifrelemeyi nasıl kaldıracağınızı gösterir:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Sunumdan Yazma Korumasını Kaldırma**

Aspose.Slides ile bir sunum dosyasındaki yazma korumasını kaldırabilirsiniz. Böylece, kullanıcılar istedikleri gibi değiştirebilir ve bu işlemleri yaparken hiçbir uyarı almazlar.  

Sunumdan yazma korumasını [remove_write_protection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/protectionmanager/) yöntemiyle kaldırabilirsiniz. Bu örnek kod, bir sunumdan yazma korumasını nasıl kaldıracağınızı gösterir:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Şifreli Bir Sunumun Özelliklerini Alma**

Genellikle, kullanıcılar şifreli veya şifre korumalı bir sunumun belge özelliklerini almada zorlanırlar. Ancak Aspose.Slides, bir sunumu şifreyle korurken kullanıcıların bu sunumun özelliklerine erişmesini sağlayan bir mekanizma sunar.  

**Not**: Aspose.Slides bir sunumu şifrelediğinde, sunumun belge özellikleri de varsayılan olarak şifre korumalı olur. Ancak, sunumun özelliklerini erişilebilir kılmanız (sunum şifrelendikten sonra bile) gerekir ise, Aspose.Slides bunun tam olarak yapmanıza izin verir.  

Şifrelediğiniz bir sunumun özelliklerine erişme yeteneğini kullanıcıların korumasını istiyorsanız, [EncryptDocumentProperties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/protectionmanager/) özelliğini `True` olarak ayarlayabilirsiniz. Bu örnek kod, kullanıcıların belge özelliklerine erişmesini sağlarken bir sunumu nasıl şifreleyeceğinizi gösterir:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt_document_properties = True
    pres.protection_manager.encrypt("123123")
```

## **Yüklemeden Önce Sunumun Şifre Koruması Olup Olmadığını Kontrol Etme**

Bir sunumu yüklemeden önce, sunumun şifreyle korunup korunmadığını kontrol etmek ve doğrulamak isteyebilirsiniz. Böylece, şifre korumalı bir sunum şifresi olmadan yüklendiğinde ortaya çıkan hatalar ve benzeri sorunlardan kaçınırsınız.  

Bu Python kodu, bir sunumun şifre korumalı olup olmadığını (sunumu yüklemeden) incelemenizi gösterir:

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("The presentation is password protected: " + str(presentationInfo.is_password_protected))
```

## **Sunumun Şifreli Olup Olmadığını Kontrol Etme**

Aspose.Slides, bir sunumun şifreli olup olmadığını kontrol etmenizi sağlar. Bu işlemi gerçekleştirmek için [is_encrypted](https://reference.aspose.com/slides/tr/python-net/aspose.slides/protectionmanager/) özelliğini kullanabilirsiniz; bu özellik, sunum şifreliyse `True`, değilse `False` döndürür.  

Bu örnek kod, bir sunumun şifreli olup olmadığını nasıl kontrol edeceğinizi gösterir:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **Sunumun Yazma Koruması Olup Olmadığını Kontrol Etme**

Aspose.Slides, bir sunumun yazma korumalı olup olmadığını kontrol etmenizi sağlar. Bu görevi yerine getirmek için [is_write_protected](https://reference.aspose.com/slides/tr/python-net/aspose.slides/protectionmanager/) özelliğini kullanabilirsiniz; bu özellik, sunum yazma korumalıysa `True`, değilse `False` döndürür.  

Bu örnek kod, bir sunumun yazma korumalı olup olmadığını nasıl kontrol edeceğinizi gösterir:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **Belirli Bir Şifrenin Sunumu Koruyup Korumadığını Doğrulama**

Bir sunum belgesini korumak için belirli bir şifrenin kullanılıp kullanılmadığını kontrol edip doğrulamak isteyebilirsiniz. Aspose.Slides, bir şifreyi doğrulamanız için gereken araçları sağlar.  

Bu örnek kod, bir şifreyi nasıl doğrulayacağınızı gösterir:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # “pass” ile eşleşip eşleşmediğini kontrol et
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

Belirtilen şifreyle sunum şifrelenmişse `True`, aksi takdirde `False` döndürür.

{{% alert color="primary" title="See also" %}} 
- [PowerPoint'ta Dijital İmza](/slides/tr/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Aspose.Slides tarafından hangi şifreleme yöntemleri desteklenmektedir?**

Aspose.Slides, AES temelli algoritmalar dahil modern şifreleme yöntemlerini destekler ve sunumlarınız için yüksek düzeyde veri güvenliği sağlar.

**Bir sunumu açmaya çalışırken yanlış şifre girilirse ne olur?**

Yanlış bir şifre kullanılırsa bir istisna fırlatılır ve sunuma erişimin reddedildiği bildirilir. Bu, yetkisiz erişimi önlemeye ve sunum içeriğini korumaya yardımcı olur.

**Şifre korumalı sunumlarla çalışırken performans açısından bir etkisi var mı?**

Şifreleme ve şifre çözme süreci, açma ve kaydetme işlemleri sırasında hafif bir ek yük oluşturabilir. Çoğu durumda bu performans etkisi minimaldir ve sunum görevlerinizin genel işleme süresini önemli ölçüde etkilemez.