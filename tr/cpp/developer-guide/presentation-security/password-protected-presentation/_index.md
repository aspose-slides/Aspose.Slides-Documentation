---
title: C++ ile Şifreli Sunumları Güvenceye Alın
linktitle: Şifre Koruması
type: docs
weight: 20
url: /tr/cpp/password-protected-presentation/
keywords:
- PowerPoint kilitle
- sunumu kilitle
- PowerPoint kilidini aç
- sunumun kilidini aç
- PowerPoint koru
- sunumu koru
- şifre belirle
- şifre ekle
- PowerPoint şifrele
- sunumu şifrele
- PowerPoint şifresini çöz
- sunumun şifresini çöz
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
description: "Aspose.Slides for C++ ile şifre korumalı PowerPoint ve OpenDocument sunumlarını kolayca kilitleyip açmayı öğrenin. Sunumlarınızı güvene alın."
---
## **Giriş**

Bir sunumu şifreyle koruduğunuzda, sunuma belirli kısıtlamalar getiren bir şifre ayarlamış olursunuz. Kısıtlamaları kaldırmak için şifrenin girilmesi gerekir. Şifre korumalı bir sunum kilitli bir sunum olarak kabul edilir.

Tipik olarak, bir sunuma bu kısıtlamaları uygulamak için şifre ayarlayabilirsiniz:

- **Değiştirme**

  Sunumunuzu yalnızca belirli kullanıcıların değiştirmesini istiyorsanız, bir değiştirme kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, kullanıcıların sunumunuzu değiştirmesini, düzenlemesini veya kopyalamasını (şifreyi sağlamadıkları sürece) engeller. 

  Ancak bu durumda, şifre olmadan da bir kullanıcı belgenize erişebilir ve onu açabilir. Bu sadece‑okuma modunda, kullanıcı sunumunuzdaki içerikleri—hiper‑bağlantılar, animasyonlar, efektler vb.—görebilir, ancak öğeleri kopyalayamaz veya sunumu kaydedemez. 

- **Açma**

  Sunumunuzu yalnızca belirli kullanıcıların açmasını istiyorsanız, bir açma kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, kullanıcıların sunumunuzun içeriğini (şifreyi sağlamadıkları sürece) görmesini engeller.

  Teknik olarak, açma kısıtlaması aynı zamanda kullanıcıların sunumunuzu değiştirmesini de engeller: Kullanıcılar bir sunumu açamadıklarında, onu değiştiremez veya üzerinde değişiklik yapamazlar.  
  
  **Not** Şifre korumasıyla bir sunumun açılmasını engellediğinizde, sunum dosyası şifrelenir.

## **Sunumları Çevrimiçi Şifreyle Koruma**

1. **Aspose.Slides Lock** sayfamıza gidin: [**Aspose.Slides Lock**](https://products.aspose.app/slides/tr/lock).

   ![todo:image_alt_text](slides-lock.png)

2. **Dosyalarınızı sürükleyip bırakın veya yükleyin**.

3. Bilgisayarınızdan şifreyle korumak istediğiniz dosyayı seçin.

4. Düzenleme koruması için tercih ettiğiniz şifreyi girin; görüntüleme koruması için tercih ettiğiniz şifreyi girin.

5. Kullanıcıların sunumunuzu son kopya olarak görmesini istiyorsanız **Mark as final** kutusunu işaretleyin.

6. **PROTECT NOW.** düğmesine tıklayın.

7. **DOWNLOAD NOW.** düğmesine tıklayın.

## **Aspose.Slides'ta Sunumlar İçin Şifre Koruması**
**Desteklenen formatlar**

Aspose.Slides, aşağıdaki formatlardaki sunumlar için şifre koruması, şifreleme ve benzeri işlemleri destekler: 

- PPTX ve PPT - Microsoft PowerPoint Sunumu 
- ODP - OpenDocument Sunumu 
- OTP - OpenDocument Sunum Şablonu 

**Desteklenen işlemler**

Aspose.Slides, sunumları aşağıdaki yollarla değiştirmeyi önlemek için şifre koruması kullanmanıza olanak tanır:

- Bir sunumu şifreleme
- Sunuma yazma koruması ayarlama

**Diğer işlemler**

Aspose.Slides, şifre koruması ve şifreleme ile ilgili diğer görevleri aşağıdaki yollarla gerçekleştirmenizi sağlar:

- Bir sunumu şifre çözme; şifreli bir sunumu açma
- Şifrelemeyi kaldırma; şifre korumasını devre dışı bırakma
- Bir sunumdan yazma korumasını kaldırma
- Şifreli bir sunumun özelliklerini alma
- Bir sunumun şifreli olup olmadığını kontrol etme
- Bir sunumun şifre korumalı olup olmadığını kontrol etme.

## **Sunumu Şifrele**

Bir sunumu şifre belirleyerek şifreleyebilirsiniz. Daha sonra kilitli sunumu değiştirmek isteyen bir kullanıcı şifreyi sağlamalıdır. 

Bir sunumu şifrelemek veya şifreyle korumak için, sunuma şifre ayarlamak amacıyla [ProtectionManager](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.protection_manager) sınıfındaki **encrypt** metodunu kullanmanız gerekir. Şifreyi encrypt metoduna geçirirsiniz ve ardından şifrelenmiş sunumu kaydetmek için **save** metodunu kullanırsınız. 

Bu örnek kod bir sunumu nasıl şifreleyeceğinizi gösterir:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Sunuma Yazma Koruması Ayarla** 

Sunuma “Değiştirmeyin” işareti ekleyebilirsiniz. Bu sayede, kullanıcıların sunumu değiştirmesini istemediğinizi belirtebilirsiniz.  

**Not** yazma koruması süreci sunumu şifrelemez. Bu nedenle, kullanıcılar—gerçekten isterlerse—sunumu değiştirebilir, ancak değişiklikleri kaydetmek için sunumu farklı bir adla kaydetmek zorunda kalacaklardır. 

Yazma koruması ayarlamak için **setWriteProtection** metodunu kullanmalısınız. Bu örnek kod bir sunuma yazma koruması nasıl ayarlanacağını gösterir:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Şifrelenmiş Bir Sunumu Yükle**

Aspose.Slides, bir şifreyi geçirerek şifreli bir dosyayı yüklemenize izin verir. Bir sunumu şifre çözmek için, parametresiz **RemoveEncryption** metodunu çağırmanız gerekir. Ardından doğru şifreyi girerek sunumu yüklemelisiniz. 

Bu örnek kod bir sunumu nasıl şifre çözeceğinizi gösterir: 

``` cpp
#include <DOM/LoadOptions.h>
using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// şifre çözülmüş sunum ile çalış
```

## **Bir Sunumdan Şifrelemeyi Kaldır**

Bir sunum üzerindeki şifreleme veya şifre korumasını kaldırabilirsiniz. Böylece, kullanıcılar sunuma kısıtlama olmadan erişebilir veya değiştirebilir. 

Şifrelemeyi veya şifre korumasını kaldırmak için **RemoveEncryption** metodunu çağırmalısınız. Bu örnek kod bir sunumdan şifrelemeyi nasıl kaldıracağınızı gösterir:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Bir Sunumdan Yazma Korumasını Kaldır**

Aspose.Slides kullanarak bir sunum dosyasındaki yazma korumasını kaldırabilirsiniz. Böylece kullanıcılar istedikleri gibi değiştirebilir ve bu işlemleri yaparken herhangi bir uyarı almazlar.

Yazma korumasını kaldırmak için **RemoveWriteProtection** metodunu kullanın. Bu örnek kod bir sunumdan yazma korumasını nasıl kaldıracağınızı gösterir:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Şifreli Bir Sunumun Özelliklerini Al**

Genellikle kullanıcılar şifreli veya şifre korumalı bir sunumun belge özelliklerini almada zorluk çeker. Ancak Aspose.Slides, bir sunumu şifreyle korurken aynı zamanda belge özelliklerine erişimi sağlamanıza olanak tanıyan bir mekanizma sunar.

**Not:** Aspose.Slides bir sunumu şifrelediğinde, sunumun belge özellikleri de varsayılan olarak şifre korumalı olur. Şifrelemeden sonra belge özelliklerinin erişilebilir olmasını istiyorsanız, [IProtectionManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iprotectionmanager/) sınıfındaki **set_EncryptDocumentProperties** metoduna `false` değeri geçirebilirsiniz. Bu örnek kod, kullanıcıların belge özelliklerine erişebildiği bir şekilde sunumu nasıl şifreleyeceğinizi gösterir:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Şifreli Bir Sunumdan Yalnızca Belge Özelliklerini Yükle**

Sunumun kaydırılarını veya diğer içeriğini yüklemeden şifreli bir sunumun meta verilerini incelemek için bir **LoadOptions** nesnesi oluşturup **set_OnlyLoadDocumentProperties** özelliğini `true` olarak ayarlayın. Bu modda, Aspose.Slides şifreyi görmezden gelir ve yalnızca halka açık olarak erişilebilen belge özelliklerini yükler.

Aşağıdaki kod örneği, **IPresentation::get_DocumentProperties** aracılığıyla yerleşik ve özel belge özelliklerini okur:

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

Bu iş akışı, sunum şifrelenirken belge özellikleri şifrelenmemiş (halka açık) olduğunda çalışır. Belge özellikleri şifreli ise, **LoadOptions::set_OnlyLoadDocumentProperties** özelliğini `true` olarak ayarlamak bir istisna üretir çünkü bu modda şifre yok sayılır. Şifreli belge özelliklerine erişmek veya slaytlar ve diğer içerikler dahil tam bir sunumu yüklemek için **LoadOptions::set_Password** ile doğru şifreyi **LoadOptions** içinde belirtmelisiniz.

## **Bir Sunumun Şifre Koruması Olup Olmadığını Kontrol Et**

Bir sunumu yüklemeden önce, sunumun şifre korumalı olup olmadığını kontrol etmek isteyebilirsiniz. Böylece, şifresi girilmemiş bir şifre korumalı sunum yüklendiğinde ortaya çıkan hataları ve benzeri sorunları önleyebilirsiniz.

Bu C++ kodu, sunumu kendisini yüklemeden şifre korumalı olup olmadığını nasıl inceleyeceğinizi gösterir:

```c++
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Bir Sunumun Şifrelenip Şifrelenmediğini Kontrol Et**

Aspose.Slides, bir sunumun şifreli olup olmadığını kontrol etmenizi sağlar. Bu görevi yerine getirmek için **get_IsEncrypted()** metodunu kullanabilirsiniz; bu metod sunum şifreli ise `true`, değilse `false` döndürür. 

Bu örnek kod bir sunumun şifreli olup olmadığını nasıl kontrol edeceğinizi gösterir:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Bir Sunumun Yazma Koruması Olup Olmadığını Kontrol Et**

Aspose.Slides, bir sunumun yazma korumalı olup olmadığını kontrol etmenizi sağlar. Bu görevi yerine getirmek için **get_IsWriteProtected()** metodunu kullanabilirsiniz; bu metod sunum yazma korumalı ise `true`, değilse `false` döndürür. 

Bu örnek kod bir sunumun yazma korumalı olup olmadığını nasıl kontrol edeceğinizi gösterir:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Sunum Şifre Kullanımını Doğrula**

Belirli bir şifrenin bir sunum belgesini korumak için kullanılıp kullanılmadığını kontrol etmek isteyebilirsiniz. Aspose.Slides, bir şifreyi doğrulamanız için gerekli araçları sağlar. 

Bu örnek kod bir şifreyi nasıl doğrulayacağınızı gösterir:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// "pass" eşleşip eşleşmediğini kontrol et
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

Şifre belirtilen şekilde belgenin şifrelenmesi durumunda `true`, aksi takdirde `false` döndürür. 

{{% alert color="info" title="Ayrıca bakınız" %}} 
- [Digital Signature in PowerPoint](/slides/tr/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Aspose.Slides hangi şifreleme yöntemlerini destekliyor?**

Aspose.Slides, modern şifreleme yöntemlerini, özellikle AES tabanlı algoritmaları destekleyerek sunumlarınız için yüksek düzeyde veri güvenliği sağlar.

**Sunumu açmaya çalışırken yanlış bir şifre girilirse ne olur?**

Yanlış şifre kullanıldığında bir istisna fırlatılır ve sunuma erişimin reddedildiği bildirilir. Bu, yetkisiz erişimi önlemeye ve sunum içeriğini korumaya yardımcı olur.

**Şifre korumalı sunumlarla çalışırken performans üzerinde bir etkisi var mı?**

Şifreleme ve şifre çözme işlemleri, açma ve kaydetme sırasında hafif bir ek yük oluşturabilir. Çoğu senaryoda bu performans etkisi çok azdır ve sunum görevlerinizin genel işleme süresini önemli ölçüde etkilemez.