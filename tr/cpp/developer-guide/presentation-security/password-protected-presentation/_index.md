---
title: C++'ta Sunumları Parola ile Korumak
linktitle: Parola Koruması
type: docs
weight: 20
url: /tr/cpp/password-protected-presentation/
keywords:
- parola korumalı sunum
- açılış şifresi
- PowerPoint şifrele
- PowerPoint şifre çöz
- sunum şifresini doğrula
- sunum şifresini kontrol et
- şifreli sunumu aç
- şifrelemeyi kaldır
- PowerPoint
- PPT
- PPTX
- sunum
- C++
- Aspose.Slides
description: "Parola korumalı PowerPoint PPT ve PPTX sunumlarını C++ ile Aspose.Slides kullanarak şifrele, algıla, doğrula, aç ve şifresini çöz."
---
## **Genel Bakış**

Açılış şifresi bir sunumu şifreler. Doğru şifre, sunum içeriğini yüklemek ve görüntülemek için gereklidir, bu nedenle bu koruma gizlilik sağlar.

Açılış şifresi, yazma koruma şifresinden farklıdır. Yazma koruması değişikliği kısıtlar ancak içeriği şifrelemez veya sunumun yüklenmesini engellemez. Sunumları değiştirmek için şifreleri yönetmek için, [Write-Protect Presentations](/slides/tr/cpp/write-protected-presentation/) bölümüne bakın.

Aşağıdaki iş akışları hem PPT hem de PPTX sunumları için geçerlidir. Örnekler, dosya tabanlı ve akış tabanlı davranışların önemli olduğu her iki formatı da kullanır.

## **Açılış Şifresi ile Bir Sunumu Şifreleme**

Açılış şifresi atamak için [IProtectionManager::Encrypt](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iprotectionmanager/encrypt/) yöntemini kullanın. Ardından şifrelenmiş sunumu kaydetmek için [IPresentation::Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/save/) yöntemini kullanın.

Aşağıdaki örnek bir PPTX sunumunu şifreler:

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Belge Özelliklerini Genel Tut**

Varsayılan olarak, Aspose.Slides belge özelliklerini sunum şifrelemesine dahil eder. [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) bu davranışı slayt içeriği şifrelemesinden bağımsız olarak kontrol eder. Bir indeksleme, sınıflandırma, arama veya belge yönetim sistemi açılış şifresi olmadan üst veriyi okuması gerektiğinde, [IProtectionManager::Encrypt](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iprotectionmanager/encrypt/) metodunu çağırmadan önce bu metoda `false` değeri gönderin.

Aşağıdaki örnek, yerleşik belge özelliklerini genel tutarak şifrelenmiş bir PPTX sunumu oluşturur:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto properties = presentation->get_DocumentProperties();
properties->set_Author(u"Contoso Knowledge Management");
properties->set_Title(u"Quarterly Product Roadmap");
properties->set_Keywords(u"roadmap, planning, internal");

presentation->get_Slide(0)->set_Name(u"Encrypted presentation content");
presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"public-properties-encrypted.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`set_EncryptDocumentProperties` metoduna `false` gönderilmesi, slaytları, ana slaytları, düzenleri, şekilleri, medyayı veya diğer sunum içeriğini genel tutmaz. Yalnızca belge özelliklerini etkiler. Şifreli içeriği yüklemeden bu özellikleri okumak için [Manage Presentation Properties](/slides/tr/cpp/presentation-properties/) bölümüne bakın.

## **Şifrelenmiş Bir Sunumu Yükleme**

Açılış şifresini ayarlamak için [LoadOptions::set_Password](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_password/) yöntemini kullanın ve dosyayı yüklerken seçenekleri [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfına iletin. Açılış şifresi gerekli olduğunda fakat verilen şifre eksik ya da hatalı olduğunda yükleme başarısız olur.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// Şifre çözülmüş sunumla çalış.
```

## **Bir Sunumdan Şifrelemeyi Kaldırma**

Sunumu açılış şifresiyle yükleyin, [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iprotectionmanager/removeencryption/) metodunu çağırın ve sonucu kaydedin. Kaydedilen sunum daha sonra şifre olmadan yüklenebilir.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Yüklemeden Önce Açılış Şifresini Doğrulama**

[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) kullanarak tam bir sunum örneği oluşturmadan [IPresentationInfo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationinfo/) alın. Şifre talep etmeden veya doğrulamadan önce [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/) kontrol edin. Koruma mevcutsa, verilen değeri [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationinfo/checkpassword/) ile doğrulayın.

### **Dosya Yolu İş Akışı**

Aşağıdaki örnek, bir PPTX dosyası için açılış şifresini doğrular, doğrulanan değeri [LoadOptions::set_Password](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_password/) metoduna iletir ve ardından tam sunumu yükler:

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

String filePath = u"protected-presentation.pptx";
String password = u"open_password";
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(filePath, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **Akış İş Akışı**

[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) metodunun akış aşırı yüklemesi aynı iş akışını sunar. Akıştan tam sunumu yüklemeden önce, arama yapılabilir bir akışın konumunu sıfırlayın.

Aşağıdaki örnek bir PPT dosyası kullanır:

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

String password = u"open_password";
auto presentationStream = File::OpenRead(u"protected-presentation.ppt");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(presentationStream);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    presentationStream->set_Position(0);

    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(presentationStream, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **CheckPassword Dönüş Değerleri**

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationinfo/checkpassword/) yalnızca sunumda bir açılış şifresi olduğunda ve verilen şifre doğru olduğunda `true` döndürür. Aşağıdaki durumlarda `false` döner:

- Şifre yanlıştır.
- Sunumun bir açılış şifresi yoktur.
- Verilen şifre null veya boş.

Davranış PPT ve PPTX sunumları için aynıdır.

## **Yüklenen Sunumun Şifrelenip Şifrelenmediğini Kontrol Et**

Doğru şifreyle bir sunumu yükledikten sonra, kaynağın şifrelenip şifrelenmediğini doğrulamak için [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iprotectionmanager/get_isencrypted/) özelliğine bakın. Yüklemeden önce açılış şifresi korumasını tespit etmek için yukarıda gösterildiği gibi `IPresentationInfo::get_IsPasswordProtected` kullanın.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");
auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
Console::WriteLine(isEncrypted ? u"The presentation is encrypted." : u"The presentation is not encrypted.");
```

## **Güvenlik Önerileri**

{{% alert color="warning" title="Security" %}}
Açılış şifrelerini günlüğe kaydetmeyin veya teşhis mesajlarında bulundurmayın. Gereksiz tekrar doğrulama girişimlerinden kaçının, şifreleri yalnızca gerektiği süre boyunca bellekte tutun ve sunumu hemen yüklerken başarılı bir doğrulama sonucunu yeniden kullanın.

Sunum içeriği şifreli olsa bile, genel belge özellikleri yazar adlarını, başlıkları, konuları, anahtar kelimeleri, şirket bilgilerini, yorumları ve özel değerleri ifşa edebilir. Hassas üst verileri sunumla birlikte şifreleyin. Özellikleri genel bırakmak, yalnızca sistemlerin dosyayı açılış şifresi olmadan indekslemesi, sınıflandırması, araması veya yönetmesi gerektiğinde alınacak açık bir karar olmalıdır.
{{% /alert %}}

## **Bir Sunumu Çevrimiçi Şifreleme**

1. Aspose.Slides Lock uygulamasını açın.
2. Sunumu seçin veya yükleyin.
3. Görünüm koruması için bir şifre girin.
4. İsteğe bağlı olarak düzenleme koruması için ayrı bir şifre girin.
5. Koruma uygulayın ve ortaya çıkan dosyayı indirin.

{{% alert color="info" title="See also" %}}
- [Sunumları Yazma Koruması](/slides/tr/cpp/write-protected-presentation/)
- [PowerPoint'te Dijital İmza](/slides/tr/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Açılış şifresi ile yazma koruma şifresi arasındaki fark nedir?**

Açılış şifresi sunumu şifreler ve içeriğini yüklemek için gereklidir. Yazma koruma şifresi, içeriği şifrelemeden değişikliği kısıtlar.

**Tüm slaytları yüklemeden bir açılış şifresini doğrulayabilir miyim?**

Evet. Sunum bilgilerini alın, açılış şifresi korumasının mevcut olup olmadığını kontrol edin ve tam bir sunum örneği oluşturmadan önce şifreyi doğrulayın.

**Bir uygulama açılış şifresi olmadan üst verileri okuyabilir mi?**

Evet, ancak yalnızca sunum `set_EncryptDocumentProperties(false)` ile şifrelenmişse. Uygulama daha sonra [Manage Presentation Properties](/slides/tr/cpp/presentation-properties/) bölümünde açıklanan sadece belge özelliklerini yükleme modunu kullanmalıdır.

**Şifre kontrol iş akışları hem PPT hem de PPTX'i destekliyor mu?**

Evet. Dosya yolu ve akış tabanlı şifre tespiti ve doğrulama, PPT ve PPTX sunumları için aynı şekilde çalışır.