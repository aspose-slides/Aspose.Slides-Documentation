---
title: Şifreli Sunumları C++ ile Güvence Altına Alın
linktitle: Şifre Koruması
type: docs
weight: 20
url: /tr/cpp/password-protected-presentation/
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
- sunum şifresini çöz
- yazma koruması
- PowerPoint güvenliği
- sunum güvenliği
- şifreyi kaldır
- korumayı kaldır
- şifrelemeyi kaldır
- şifreyi devre dışı bırak
- korumayı devre dışı bırak
- yazma korumasını kaldır
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak şifre korumalı PowerPoint ve OpenDocument sunumlarını sorunsuz bir şekilde kilitleyip açmayı öğrenin. Sunumlarınızı güvene alın."
---
## **Giriş**

Bir sunumu şifreyle koruduğunuzda, sunuma bazı kısıtlamalar getiren bir şifre ayarladığınız anlamına gelir. Kısıtlamaları kaldırmak için şifre girilmelidir. Şifre korumalı bir sunum kilitli bir sunum olarak kabul edilir.

Genellikle, bir sunuma bu kısıtlamaları uygulamak için bir şifre ayarlayabilirsiniz:

- **Değiştirme**

  Sadece belirli kullanıcıların sunumunuzu değiştirmesini istiyorsanız, bir değiştirme kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, insanların sunumunuzdaki öğeleri değiştirmesini, düzenlemesini veya kopyalamasını (şifreyi sağlamaları koşuluyla) engeller.  

  Ancak bu durumda, şifre olmadan bile bir kullanıcı belgenize erişebilir ve açabilir. Bu yalnızca okuma modunda, kullanıcı sunumunuzdaki içerikleri—köprüler, animasyonlar, efektler ve diğerlerini—görebilir, ancak öğeleri kopyalayamaz veya sunumu kaydedemez. 

- **Açma**

  Sadece belirli kullanıcıların sunumunuzu açmasını istiyorsanız, bir açma kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, insanların sunumunuzun içeriğini bile görüntülemesini (şifreyi sağlamaları koşuluyla) engeller.  

  Teknik olarak, açma kısıtlaması aynı zamanda kullanıcıların sunumlarınızı düzenlemesini de engeller: İnsanlar bir sunumu açamadıklarında, ona değişiklik yapamazlar.  

  **Not**: Bir sunumu açılmasını engelleyecek şekilde şifreyle koruduğunuzda, sunum dosyası şifrelenir.

## **Sunumu Çevrimiçi Şifreyle Korumak Nasıl Yapılır**

1. Bizim [**Aspose.Slides Lock**](https://products.aspose.app/slides/tr/lock) sayfamıza gidin. 

   ![todo:image_alt_text](slides-lock.png)

2. **Dosyalarınızı bırakın veya yükleyin**.

3. Bilgisayarınızda şifreyle korumak istediğiniz dosyayı seçin. 

4. Düzenleme koruması için tercih ettiğiniz şifreyi girin; Görüntüleme koruması için tercih ettiğiniz şifreyi girin. 

5. Kullanıcıların sunumunuzu son kopya olarak görmesini istiyorsanız, **Mark as final** kutusunu işaretleyin.

6. **ŞİMDİ KORU**. 

7. **ŞİMDİ İNDİR**.

## **Aspose.Slides'ta Sunumlar için Şifre Koruması**
**Desteklenen formatlar**

Aspose.Slides, bu formatlardaki sunumlar için şifre koruması, şifreleme ve benzeri işlemleri destekler: 

- PPTX ve PPT - Microsoft PowerPoint Sunumu 
- ODP - OpenDocument Sunumu 
- OTP - OpenDocument Sunum Şablonu 

**Desteklenen işlemler**

Aspose.Slides, sunumlarda şifre korumasını şu yollarla değişiklikleri engellemek için kullanmanıza olanak tanır:

- Bir sunumu şifreleme
- Sunuma yazma koruması ayarlama

**Diğer işlemler**

Aspose.Slides, şifre koruması ve şifreleme ile ilgili diğer görevleri şu şekilde yapmanıza olanak tanır:

- Bir sunumu şifre çözme; şifreli bir sunumu açma
- Şifrelemeyi kaldırma; şifre korumasını devre dışı bırakma
- Sunumdan yazma korumasını kaldırma
- Şifreli bir sunumun özelliklerini alma
- Bir sunumun şifreli olup olmadığını kontrol etme
- Bir sunumun şifreyle korunup korunmadığını kontrol etme.

## **Bir Sunumu Şifrele**

Bir sunumu şifre belirleyerek şifreleyebilirsiniz. Kilitli sunumu değiştirmek için kullanıcı şifreyi sağlamalıdır. 

Bir sunumu şifrelemek veya şifreyle korumak için, sunuma bir şifre ayarlamak amacıyla encrypt metodunu ([ProtectionManager](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.protection_manager)) kullanmalısınız. Şifreyi encrypt metoduna geçirirsiniz ve ardından kaydetme metodunu kullanarak şifrelenmiş sunumu kaydedersiniz. 

Bu örnek kod, bir sunumu nasıl şifreleyeceğinizi gösterir:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Sunuma Yazma Koruması Ayarla** 

Sunuma “Değiştirmeyin” ibaresi ekleyebilirsiniz. Bu şekilde, kullanıcılarına sunumu değiştirmelerini istemediğinizi bildirirsiniz.  

**Not**: Yazma koruma işlemi sunumu şifrelemez. Bu nedenle, kullanıcılar—gerçekten istediklerinde—sunumu değiştirebilir, ancak değişiklikleri kaydetmek için farklı bir adla sunum oluşturmak zorunda kalırlar. 

Yazma koruması ayarlamak için setWriteProtection metodunu kullanmalısınız. Bu örnek kod, bir sunuma yazma koruması nasıl ayarlanacağını gösterir:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Şifreli Bir Sunumu Yükle**

Aspose.Slides, şifresini girerek şifreli bir dosyayı yüklemenize izin verir. Bir sunumu şifre çözmek için, parametresiz olarak [RemoveEncryption](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) metodunu çağırmalısınız. Daha sonra sunumu yüklemek için doğru şifreyi girmeniz gerekir. 

Bu örnek kod, bir sunumu nasıl şifre çözeceğinizi gösterir:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// şifre çözülmüş sunumla çalış
```

## **Sunumdan Şifrelemeyi Kaldır**

Bir sunum üzerindeki şifrelemeyi veya şifre korumasını kaldırabilirsiniz. Bu şekilde, kullanıcılar sunuma kısıtlama olmadan erişebilir veya değiştirebilir. 

Şifrelemeyi veya şifre korumasını kaldırmak için [RemoveEncryption](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) metodunu çağırmalısınız. Bu örnek kod, bir sunumdan şifrelemeyi nasıl kaldıracağınızı gösterir:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Sunumdan Yazma Korumasını Kaldır**

Aspose.Slides'i kullanarak bir sunum dosyasındaki yazma korumasını kaldırabilirsiniz. Böylece, kullanıcılar istedikleri gibi değiştirebilir ve bu işlemleri yaparken herhangi bir uyarı almazlar.  

Sunumdan yazma korumasını [RemoveWriteProtection](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50) metodunu kullanarak kaldırabilirsiniz. Bu örnek kod, bir sunumdan yazma korumasını nasıl kaldıracağınızı gösterir:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Şifreli Bir Sunumun Özelliklerini Al**

Genellikle, kullanıcılar şifreli veya şifre korumalı bir sunumun belge özelliklerini almada zorlanırlar. Ancak, Aspose.Slides, bir sunumu şifreyle korurken aynı zamanda belge özelliklerine erişim sağlayan bir mekanizma sunar.  

**Not:** Varsayılan olarak, Aspose.Slides bir sunumu şifrelediğinde, sunumun belge özellikleri de şifre korumalı olur. Şifreleme sonrası belge özelliklerinin erişilebilir olmasını istiyorsanız, Aspose.Slides bunu yapmanıza izin verir.  

Kullanıcıların şifreli bir sunumun özelliklerine erişim yeteneğini korumalarını istiyorsanız, [IProtectionManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iprotectionmanager/) sınıfının `set_EncryptDocumentProperties` metoduna `false` değeri gönderin. Bu örnek kod, bir sunumu şifrelerken kullanıcıların belge özelliklerine erişimini nasıl sağlamayı gösterir:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Şifreli Bir Sunumdan Yalnızca Belge Özelliklerini Yükle**

Şifreli bir sunumun slaytlarını veya diğer içeriklerini yüklemeden meta verilerini incelemek için bir [LoadOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/) nesnesi oluşturun ve [set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) özelliğini `true` olarak ayarlayın. Bu modda, Aspose.Slides şifreyi görmezden gelir ve yalnızca herkese açık belge özelliklerini yükler.  

Aşağıdaki kod örneği, [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/get_documentproperties/) aracılığıyla yerleşik ve özel belge özelliklerini okur:

``` cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);
auto documentProperties = presentation->get_DocumentProperties();

// Read built-in document properties.
auto title = documentProperties->get_Title();
auto author = documentProperties->get_Author();
Console::WriteLine(String(u"Title: ") + title);
Console::WriteLine(String(u"Author: ") + author);

// Read custom document properties.
int customPropertyCount = documentProperties->get_CountOfCustomProperties();

for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(propertyIndex);
    auto propertyValue = documentProperties->idx_get(propertyName);
    auto propertyValueText = ObjectExt::ToString(propertyValue);

    Console::WriteLine(propertyName + u": " + propertyValueText);
}

presentation->Dispose();
```

Bu iş akışı yalnızca sunum şifrelenirken belge özellikleri şifrelenmemiş (genel) bırakıldığında çalışır. Belge özellikleri şifrelenmişse, `LoadOptions::set_OnlyLoadDocumentProperties` değerini `true` yapmak bir istisna oluşturur çünkü bu modda şifre göz ardı edilir. Şifreli belge özelliklerine erişmek veya slaytlar ve diğer içerik dahil tam sunumu yüklemek için, doğru şifreyi `LoadOptions::set_Password` ile [LoadOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/) içinde sağlayın.  

## **Bir Sunumun Şifre Koruması Olup Olmadığını Kontrol Et**

Bir sunumu yüklemeden önce, sunumun şifreyle korunup korunmadığını kontrol etmek ve doğrulamak isteyebilirsiniz. Bu sayede, şifre korumalı bir sunumun şifresi olmadan yüklendiğinde ortaya çıkan hatalar ve benzeri sorunlardan kaçınabilirsiniz.  

Bu C++ kod, bir sunumu şifre korumalı olup olmadığını (sunumu kendisini yüklemeden) incelemenin yolunu gösterir:

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Bir Sunumun Şifrelenmiş Olup Olmadığını Kontrol Et**

Aspose.Slides, bir sunumun şifrelenip şifrelenmediğini kontrol etmenizi sağlar. Bu görevi yerine getirmek için, sunum şifreli ise `true`, şifreli değilse `false` dönen [get_IsEncrypted()](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68) metodunu kullanabilirsiniz.  

Bu örnek kod, bir sunumun şifreli olup olmadığını nasıl kontrol edeceğinizi gösterir:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Bir Sunumun Yazma Koruması Olup Olmadığını Kontrol Et**

Aspose.Slides, bir sunumun yazma korumalı olup olmadığını kontrol etmenizi sağlar. Bu görevi gerçekleştirmek için, sunum yazma korumalı ise `true`, değilse `false` dönen [get_IsWriteProtected()](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2) metodunu kullanabilirsiniz.  

Bu örnek kod, bir sunumun yazma korumalı olup olmadığını nasıl kontrol edeceğinizi gösterir:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Sunum Şifresi Kullanımını Doğrula**

Belirli bir şifrenin bir sunum belgesini korumak için kullanıldığını kontrol etmek ve doğrulamak isteyebilirsiniz. Aspose.Slides, bir şifreyi doğrulamanız için gerekli araçları sağlar.  

Bu örnek kod, bir şifreyi nasıl doğrulayacağınızı gösterir:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// "pass" parolasının eşleşip eşleşmediğini kontrol et
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

Belirtilen şifreyle sunum şifrelenmişse `true` döner. Aksi takdirde `false` döner.  

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/tr/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Aspose.Slides hangi şifreleme yöntemlerini destekliyor?**

Aspose.Slides, AES tabanlı algoritmalar dahil modern şifreleme yöntemlerini destekler ve sunumlarınız için yüksek düzeyde veri güvenliği sağlar.  

**Bir sunumu açmaya çalışırken yanlış şifre girilirse ne olur?**

Yanlış bir şifre kullanılırsa bir istisna fırlatılır ve sunuma erişimin reddedildiği bildirilir. Bu, yetkisiz erişimi önlemeye ve sunum içeriğini korumaya yardımcı olur.  

**Şifre korumalı sunumlarla çalışırken performans üzerinde bir etkisi var mı?**

Şifreleme ve şifre çözme işlemleri, açma ve kaydetme sırasında hafif bir ek yük oluşturabilir. Çoğu durumda, bu performans etkisi çok azdır ve sunum görevlerinizin genel işleme süresini önemli ölçüde etmez.