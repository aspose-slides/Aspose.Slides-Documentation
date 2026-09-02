---
title: Python ile Şifreli Sunuları Güvenceye Alın
linktitle: Şifre Koruması
type: docs
weight: 20
url: /tr/python-net/password-protected-presentation/
keywords:
- PowerPoint'i Kilitle
- Sunumu Kilitle
- PowerPoint'i Kilit Aç
- Sunumu Kilit Aç
- PowerPoint'i Koru
- Sunumu Koru
- Şifre Ayarla
- Şifre Ekle
- PowerPoint'i Şifrele
- Sunumu Şifrele
- PowerPoint'i Şifresini Çöz
- Sunumu Şifresini Çöz
- Yazma Koruması
- PowerPoint Güvenliği
- Sunum Güvenliği
- Şifreyi Kaldır
- Koruma Kaldır
- Şifrelemeyi Kaldır
- Şifreyi Devre Dışı Bırak
- Koruma Devre Dışı Bırak
- Yazma Korumasını Kaldır
- PowerPoint Sunumu
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile şifre korumalı PowerPoint ve OpenDocument sunumlarını kolayca kilitleyip açmayı öğrenin. Üretkenliğinizi artırın ve adım adım kılavuzumuzla sunumlarınızı güvenceye alın."
---
## **Giriş**

Bir sunumu şifreyle koruduğunuzda, sunuma belirli kısıtlamalar getiren bir şifre ayarladığınız anlamına gelir. Kısıtlamaları kaldırmak için şifrenin girilmesi gerekir. Şifre korumalı bir sunum, kilitli bir sunum olarak kabul edilir.

Genellikle, bir sunuma bu kısıtlamaları uygulamak için bir şifre belirleyebilirsiniz:

- **Değişiklik**

  Sadece belirli kullanıcıların sunumunuzu değiştirmesini istiyorsanız, bir değişiklik kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, insanların sunumunuzdaki içerikleri değiştirmesini, düzenlemesini veya kopyalamasını (şifreyi sağlamaları durumunda hariç) engeller.  

  Ancak, bu durumda şifre olmadan da bir kullanıcı belgenize erişip açabilecektir. Bu sadece‑okuma modunda, kullanıcı sunumunuzdaki içerikleri—hiperlinkler, animasyonlar, efektler ve diğer öğeleri—görüntüleyebilir, ancak öğeleri kopyalayamaz veya sunumu kaydedemez.  

- **Açma**

  Sadece belirli kullanıcıların sunumunuzu açmasını istiyorsanız, bir açma kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, insanların sunumunuzun içeriğini hatta görüntülemesini (şifreyi sağlamaları durumunda hariç) engeller.  

  Teknik olarak, açma kısıtlaması aynı zamanda kullanıcıların sunumlarınızı değiştirmesini de engeller: İnsanlar bir sunumu açamadıklarında, değişiklik yapamazlar.  

  **Not**: Bir sunumu açılmasını engellemek için şifreyle koruduğunuzda, sunum dosyası şifrelenir.

## Sunumu Çevrimiçi Şifreyle Korumak İçin

1. Şu sayfaya gidin: [**Aspose.Slides Lock**](https://products.aspose.app/slides/tr/lock).  

   ![todo:image_alt_text](slides-lock.png)

2. **Dosyalarınızı bırakın veya yükleyin**.

3. Bilgisayarınızda şifreyle korumak istediğiniz dosyayı seçin.  

4. Düzenleme koruması için tercih ettiğiniz şifreyi girin; Görüntüleme koruması için tercih ettiğiniz şifreyi girin.  

5. Kullanıcıların sunumunuzu son kopya olarak görmesini istiyorsanız, **Mark as final** kutusunu işaretleyin.  

6. **PROTECT NOW.** butonuna tıklayın.  

7. **DOWNLOAD NOW.** butonuna tıklayın.

## **Aspose.Slides'da Sunumlar için Şifre Koruması**
**Desteklenen formatlar**

Aspose.Slides, bu formatlardaki sunumlar için şifre koruması, şifreleme ve benzeri işlemleri destekler: 

- PPTX ve PPT - Microsoft PowerPoint Sunumu 
- ODP - OpenDocument Sunumu 
- OTP - OpenDocument Sunum Şablonu 

**Desteklenen işlemler**

Aspose.Slides, sunumlarda şifre koruması kullanarak değişiklikleri önlemenizi şu yollarla sağlar:

- Sunumu şifreleme
- Sunuma yazma koruması ayarlama

**Diğer işlemler**

Aspose.Slides, şifre koruması ve şifreleme ile ilgili diğer görevleri şu yollarla gerçekleştirmenizi sağlar:

- Sunumu şifre çözme; şifreli bir sunumu açma
- Şifrelemeyi kaldırma; şifre korumasını devre dışı bırakma
- Sunumdan yazma korumasını kaldırma
- Şifreli bir sunumun özelliklerini alma
- Sunumun şifreli olup olmadığını kontrol etme
- Sunumun şifreyle korunduğunu kontrol etme.

## **Sunumu Şifreleme**

Bir sunumu şifre ayarlayarak şifreleyebilirsiniz. Kilitli sunumu değiştirmek için kullanıcının şifreyi sağlaması gerekir.  

Bir sunumu şifrelemek veya şifreyle korumak için, [ProtectionManager](https://reference.aspose.com/slides/tr/python-net/aspose.slides/protectionmanager/) üzerinden encrypt metodunu kullanarak sunuma bir şifre belirlemeniz gerekir. Şifreyi encrypt metoduna geçirirsiniz ve save metodunu kullanarak artık şifreli sunumu kaydedersiniz.  

Bu örnek kod, bir sunumu nasıl şifreleyeceğinizi gösterir:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Sunuma Yazma Koruması Ayarlama** 

Sunuma “Değiştirmeyin” ifadesi ekleyebilirsiniz. Böylece kullanıcılara sunumu değiştirmelerini istemediğinizi bildirirsiniz.  

**Not**: Yazma koruma işlemi sunumu şifrelemez. Bu nedenle, kullanıcılar—gerçekten isterlerse—sunumu değiştirebilir, ancak değişiklikleri kaydetmek için farklı bir adla sunum oluşturmak zorunda kalırlar.  

Yazma koruması ayarlamak için setWriteProtection metodunu kullanmanız gerekir. Bu örnek kod, bir sunuma nasıl yazma koruması ekleyeceğinizi gösterir:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Sunumu Şifre Çözme; Şifreli Sunumu Açma**

Aspose.Slides, şifreli bir dosyayı şifresini girerek yüklemenizi sağlar. Bir sunumu şifre çözmek için [remove_encryption](https://reference.aspose.com/slides/tr/python-net/aspose.slides/protectionmanager/) metodunu parametresiz olarak çağırmanız gerekir. Daha sonra sunumu yüklemek için doğru şifreyi girmeniz gerekir.  

Bu örnek kod, bir sunumu nasıl şifre çözeceğinizi gösterir: 

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **Şifrelemeyi Kaldırma; Şifre Korumasını Devre Dışı Bırakma**

Bir sunumdaki şifreleme veya şifre korumasını kaldırabilirsiniz. Böylece kullanıcılar sunuma kısıtlama olmadan erişip değiştirebilir.  

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

Aspose.Slides'i kullanarak bir sunum dosyasındaki yazma korumasını kaldırabilirsiniz. Böylece kullanıcılar istedikleri gibi değiştirebilir ve bu işlemleri yaparken herhangi bir uyarı almazlar.  

Sunumdan yazma korumasını kaldırmak için [remove_write_protection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/protectionmanager/) metodunu kullanabilirsiniz. Bu örnek kod, bir sunumdan yazma korumasını nasıl kaldıracağınızı gösterir:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Şifreli Bir Sunumun Özelliklerini Alma**

Genellikle, kullanıcılar şifreli veya şifre korumalı bir sunumun belge özelliklerini almada zorlanırlar. Ancak, Aspose.Slides, bir sunumu şifreyle korurken kullanıcıların özelliklerine erişebilmesini sağlayan bir mekanizma sunar.  

**Not:** Varsayılan olarak, Aspose.Slides bir sunumu şifrelediğinde, sunumun belge özellikleri de şifre korumalı olur. Şifreleme sonrasında belge özelliklerinin erişilebilir olmasını istiyorsanız, Aspose.Slides bunu tam olarak yapmanıza imkan verir.  

Belge özelliklerinin şifreli bir sunumdan sonra da erişilebilir olmasını istiyorsanız, [ProtectionManager](https://reference.aspose.com/slides/tr/python-net/aspose.slides/protectionmanager/) nesnesinin `encrypt_document_properties` özelliğini `False` olarak ayarlayın. Bu örnek kod, bir sunumu şifrelerken kullanıcıların belge özelliklerine erişimini nasıl sağlayacağınızı gösterir:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("123123")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Şifreli Bir Sunumdan Yalnızca Belge Özelliklerini Yükleme**

Şifreli bir sunumun meta verilerini slaytlarını veya diğer içeriğini yüklemeden incelemek için bir [LoadOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/) nesnesi oluşturun ve [only_load_document_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/only_load_document_properties/) özelliğini `True` olarak ayarlayın. Bu modda, Aspose.Slides şifreyi yok sayar ve yalnızca halka açık erişilebilen belge özelliklerini yükler.  

Aşağıdaki kod örneği, yerleşik belge özelliklerini okur ve özel belge özelliklerini [Presentation.document_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/document_properties/) aracılığıyla listeler:

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    document_properties = presentation.document_properties

    # Yerleşik belge özelliklerini oku.
    print("Title: " + document_properties.title)
    print("Author: " + document_properties.author)

    # Özel belge özelliklerini listele.
    custom_property_count = document_properties.count_of_custom_properties

    for property_index in range(custom_property_count):
        property_name = document_properties.get_custom_property_name(property_index)
        print(property_name)
```

Bu iş akışı yalnızca belge özellikleri şifrelenmemiş (halka açık) ise çalışır. Belge özellikleri şifreli ise, `only_load_document_properties` özelliğini `True` olarak ayarlamak bir istisna oluşturur çünkü şifre bu modda yok sayılır. Şifreli belge özelliklerine erişmek veya slaytları ve diğer içeriği de dahil olmak üzere tam sunumu yüklemek için doğru `password` değerini [LoadOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/) içinde sağlayın.

## **Sunumu Yüklemeden Önce Şifre Koruması Kontrolü**

Bir sunumu yüklemeden önce, sunumun şifreyle korunup korunmadığını kontrol edip doğrulamak isteyebilirsiniz. Böylece şifre korumalı bir sunumun şifresi olmadan yüklenmesi durumunda ortaya çıkan hata ve benzeri sorunlardan kaçınmış olursunuz.  

Bu Python kodu, bir sunumu gerçekten yüklemeden şifre korumalı olup olmadığını nasıl inceleyeceğinizi gösterir:

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("The presentation is password protected: " + str(presentationInfo.is_password_protected))
```

## **Sunumun Şifreli Olduğunu Kontrol Etme**

Aspose.Slides, bir sunumun şifreli olup olmadığını kontrol etmenizi sağlar. Bu görevi yerine getirmek için [is_encrypted](https://reference.aspose.com/slides/tr/python-net/aspose.slides/protectionmanager/) özelliğini kullanabilirsiniz; bu özellik sunum şifreli ise `True`, değilse `False` döndürür.  

Bu örnek kod, bir sunumun şifreli olup olmadığını nasıl kontrol edeceğinizi gösterir:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **Sunumun Yazma Koruması Olduğunu Kontrol Etme**

Aspose.Slides, bir sunumun yazma korumalı olup olmadığını kontrol etmenizi sağlar. Bu görevi yerine getirmek için [is_write_protected](https://reference.aspose.com/slides/tr/python-net/aspose.slides/protectionmanager/) özelliğini kullanabilirsiniz; bu özellik sunum yazma korumalı ise `True`, değilse `False` döndürür.  

Bu örnek kod, bir sunumun yazma korumalı olup olmadığını nasıl kontrol edeceğinizi gösterir:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **Belirli Bir Şifrenin Sunumu Korumak İçin Kullanıldığını Doğrulama veya Onaylama**

Belirli bir şifrenin bir sunum belgesini korumak için kullanılıp kullanılmadığını kontrol edip doğrulamak isteyebilirsiniz. Aspose.Slides, bir şifreyi doğrulamanızı sağlayan bir yöntem sunar.  

Bu örnek kod, bir şifreyi nasıl doğrulayacağınızı gösterir:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # "pass" ile eşleşip eşleşmediğini kontrol et
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

Belirtilen şifreyle şifrelenmişse `True`, aksi takdirde `False` döndürür.  

{{% alert color="primary" title="Ayrıca bakınız" %}} 
- [PowerPoint'ta Dijital İmza](/slides/tr/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Aspose.Slides tarafından desteklenen şifreleme yöntemleri nelerdir?**

Aspose.Slides, AES tabanlı algoritmalar dahil modern şifreleme yöntemlerini destekleyerek sunumlarınız için yüksek düzeyde veri güvenliği sağlar.

**Sunumu açmaya çalışırken hatalı bir şifre girilirse ne olur?**

Yanlış bir şifre kullanıldığında bir istisna fırlatılır ve sunuma erişimin reddedildiği bildirilir. Bu, yetkisiz erişimi önlemeye ve sunum içeriğini korumaya yardımcı olur.

**Şifre korumalı sunumlarla çalışırken performans etkileri var mı?**

Şifreleme ve şifre çözme işlemleri, açma ve kaydetme sırasında hafif bir ek yük getirebilir. Çoğu durumda bu performans etkisi küçüktür ve sunum görevlerinizin toplam işleme süresini önemli ölçüde etkilemez.