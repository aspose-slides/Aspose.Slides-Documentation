---
title: C++'ta Sunumları Parola ile Koruma
linktitle: Parola Koruması
type: docs
weight: 20
url: /tr/cpp/password-protected-presentation/
keywords:
- parola korumalı sunum
- açma parolası
- PowerPoint şifreleme
- PowerPoint şifre çözme
- sunum parolasını doğrulama
- sunum parolasını kontrol et
- şifreli sunumu aç
- şifrelemeyi kaldır
- PowerPoint
- PPT
- PPTX
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides ile C++'ta parola korumalı PowerPoint PPT ve PPTX sunumlarını şifreleyin, algılayın, doğrulayın, açın ve şifrelerini çözün."
---
## **Genel Bakış**

Açma parolası bir sunumu şifreler. Doğru parola, sunum içeriğini yüklemek ve görüntülemek için gereklidir; bu koruma gizliliği sağlar.

Açma parolası, yazma koruma parolasından farklıdır. Yazma koruması değişiklikleri kısıtlar ancak içeriği şifrelemez ve sunumun yüklenmesini engellemez. Sunumları değiştirmek için parolaları yönetmek amacıyla [Write-Protect Presentations](/slides/tr/cpp/write-protected-presentation/) bölümüne bakın.

Aşağıdaki iş akışları PPT ve PPTX sunumları için geçerlidir. Örnekler, dosya tabanlı ve akış tabanlı davranışların önemli olduğu durumları her iki formatta da gösterir.

## **Açma Parolası ile Sunumu Şifreleme**

Açma parolası atamak için [IProtectionManager::Encrypt](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iprotectionmanager/encrypt/) kullanın. Ardından şifreli sunumu kaydetmek için [IPresentation::Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/save/) yöntemini çağırın.

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

## **Şifreli Sunumu Yükleme**

[LoadOptions::set_Password](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_password/) özelliğine açma parolasını ata ve dosyayı yüklerken bu seçenekleri [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) yapıcısına geçir. Açma parolası gerekli ancak sağlanan parola eksik veya hatalı ise yükleme başarısız olur.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// Şifrelenmiş sunumla çalış.
```

## **Sunumdan Şifrelemeyi Kaldırma**

Sunumu açma parolasıyla yükleyin, [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iprotectionmanager/removeencryption/) yöntemini çağırın ve sonucu kaydedin. Kaydedilen sunum artık parola olmadan yüklenebilir.

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

## **Yüklemeden Önce Açma Parolasını Doğrulama**

Tam bir sunum örneği oluşturmadan [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) ile [IPresentationInfo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationinfo/) alın. Parola isteği veya doğrulaması yapmadan önce [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/) özelliğini kontrol edin. Koruma mevcutsa, sağlanan değeri [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationinfo/checkpassword/) ile doğrulayın.

### **Dosya Yolu İş Akışı**

Aşağıdaki örnek bir PPTX dosyası için açma parolasını doğrular, doğrulanan değeri [LoadOptions::set_Password](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_password/) metoduna geçirir ve ardından tam sunumu yükler:

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

[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) metodunun akış aşırı yüklemesi aynı iş akışını sağlar. Tam sunumu akıştan yüklemeden önce, konumlanabilir bir akışın konumunu sıfırlamayı unutmayın.

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

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationinfo/checkpassword/) yalnızca sunumda bir açma parolası varsa ve sağlanan parola doğruysa `true` döndürür. Aşağıdaki durumlarda `false` döner:

- Parola yanlış.
- Sunumda bir açma parolası yok.
- Sağlanan parola null veya boş.

Davranış PPT ve PPTX sunumları için aynı şekildedir.

## **Yüklenen Sunumun Şifreli Olup Olmadığını Kontrol Etme**

Doğru parola ile bir sunumu yükledikten sonra, kaynağın şifreli olduğunu doğrulamak için [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iprotectionmanager/get_isencrypted/) incelenir. Açma‑parola korumasını yüklemeden önce tespit etmek için yukarıda gösterildiği gibi `IPresentationInfo::get_IsPasswordProtected` kullanılabilir.

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
Açma parolalarını loglamayın veya tanılama mesajlarına eklemeyin. Gereksiz tekrar doğrulama girişimlerinden kaçının, parolaları sadece gerektiği sürece bellekte tutun ve sunumu hemen yüklerken başarılı bir doğrulama sonucunu yeniden kullanın.
{{% /alert %}}

## **Sunumu Çevrimiçi Parola ile Koruma**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/tr/lock) uygulamasını açın.
2. Sunumu seçin veya yükleyin.
3. Görüntüleme koruması için bir parola girin.
4. İsteğe bağlı olarak düzenleme koruması için ayrı bir parola girin.
5. Koruma uygulayın ve ortaya çıkan dosyayı indirin.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/tr/cpp/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/tr/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Açma parolası ile yazma koruma parolası arasındaki fark nedir?**

Açma parolası sunumu şifreler ve içeriğin yüklenmesi için gereklidir. Yazma koruma parolası içeriği şifrelemez, sadece değişiklikleri kısıtlar.

**Tüm slaytları yüklemeden bir açma parolasını doğrulayabilir miyim?**

Evet. Sunum bilgilerini alın, açma‑parola korumasının varlığını kontrol edin ve tam bir sunum örneği oluşturulmadan önce parolayı doğrulayın.

**Parola kontrol iş akışları PPT ve PPTX için destekleniyor mu?**

Evet. Dosya yolu ve akış tabanlı parola algılama ve doğrulama, PPT ve PPTX sunumları için aynı şekilde çalışır.