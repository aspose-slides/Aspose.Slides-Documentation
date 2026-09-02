---
title: C++'ta Sunumları Yazma Koruması
linktitle: Yazma Koruması
type: docs
weight: 25
url: /tr/cpp/write-protected-presentation/
keywords:
- yazma koruması
- PowerPoint Yazma Koruması
- değiştirme parolası
- sunum düzenlemesini kısıtlama
- yazma korumasını kaldırma
- değişiklik parolasını doğrulama
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PowerPoint PPT ve PPTX sunumlarında yazma koruma parolalarını ayarlama, tespit etme, doğrulama ve kaldırma."
---
## **Giriş**

Yazma koruma parolası bir sunumun değiştirilmesini kısıtlar ancak içeriğini şifrelemez. Kullanıcılar yazma korumalı bir sunumu parola olmadan yükleyebilir ve görüntüleyebilir. Uygulamaya bağlı olarak içeriği düzenleyebilir ve farklı bir adla kaydedebilirler, bu yüzden yazma koruması gizlilik mekanizması olarak değerlendirilmemelidir.

Açma parolası farklı bir amaca hizmet eder: sunumu şifreler ve içeriğini yüklemek için gereklidir. Bir sunumu şifrelemek veya açma parolasını doğrulamak için, bkz. [Sunumları Şifreleme](/slides/tr/cpp/password-protected-presentation/).

Bu makaledeki iş akışları hem PPT hem de PPTX sunumları için geçerlidir. Örnekler PPTX dosyalarını kullanır; PPT olarak kaydederken `.ppt` uzantısını ve ilgili PPT kaydetme biçimini kullanın.

## **Bir Sunuma Yazma Koruması Ayarlama**

[IProtectionManager::SetWriteProtection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iprotectionmanager/setwriteprotection/) metodunu kullanarak bir sunumu değiştirmek için bir parola atayabilirsiniz. Sunumu kaydetmek koruma ayarını saklar.

Aşağıdaki örnek bir PPTX sunumuna yazma koruması ekler:

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"modify_password");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Yazma Korumalı Sunumu Yükleme**

Yazma koruması sunum içeriğini şifrelemediği için sunumu yüklemek için parola gerekmez. Parola yalnızca korumalı sunumu değiştirme yetkisini doğrularken geçerlidir.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"write-protected-pres.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());
```

Yazma koruma parolasını [LoadOptions::set_Password](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_password/) metoduna geçirmeyin. Bu özellik şifreli içerik için bir açma parolası kabul eder. Bir sunumda her iki koruma tipi varsa, şifreli içeriği yüklemek için açma parolasını sağlayın ve yazma koruma parolasını ayrı olarak işleyin.

## **Bir Sunumdan Yazma Korumasını Kaldırma**

[IProtectionManager::RemoveWriteProtection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iprotectionmanager/removewriteprotection/) metodunu kullanarak değişiklik kısıtlamasını kaldırın, ardından sunumu kaydedin.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"write-protected-pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Bir Sunumun Yazma Koruması Olup Olmadığını Kontrol Etme**

Tam bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) örneği oluşturmadan bir dosyayı incelemek için [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) metodunu çağırın ve [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/) özelliğini inceleyin. Bu özellik [NullableBool](https://reference.aspose.com/slides/tr/cpp/aspose.slides/nullablebool/) kullanır ve yazma koruması tespit edildiğinde `NullableBool::True` döndürür.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() == NullableBool::True)
{
    Console::WriteLine(u"The presentation is write protected.");
}
else
{
    Console::WriteLine(u"Write protection was not detected.");
}
```

Akış aşırı yüklemesi, bir akış olarak sağlanan sunum için aynı bilgiyi verir.

## **Yazma Koruma Parolasını Doğrulama**

[IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) metodunu kullanarak tam sunumu yüklemeden bir değiştirme parolasını doğrulayabilirsiniz. Uygulamanın yalnızca yazma koruması mevcut olduğunda parola talep etmesi veya doğrulaması için önce [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/) özelliğini kontrol edin.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() != NullableBool::True)
{
    Console::WriteLine(u"The presentation is not write protected.");
}
else if (presentationInfo->CheckWriteProtection(u"modify_password"))
{
    Console::WriteLine(u"The write-protection password is correct.");
}
else
{
    Console::WriteLine(u"The write-protection password is incorrect.");
}
```

[IPresentationInfo::CheckWriteProtection] sadece yazma koruma parolasını doğrular. Açma parolasını doğrulamaz ve şifreli içeriğin yüklenip yüklenemeyeceğini belirlemez. Buna karşılık, [IPresentationInfo::CheckPassword] yalnızca açma parolasını doğrular. Tam bir sunum zaten yüklendiyse, [IProtectionManager::CheckWriteProtection] koruma yöneticisi aracılığıyla eşdeğer bir yazma koruma kontrolü sağlar.

Üretim uygulamalarında parolaları günlüğe kaydetmeyin veya tanılayıcı mesajlarda bulundurmayın. Gereksiz tekrarlanan doğrulama girişimlerinden kaçının ve parolaları yalnızca gerektiği süre boyunca bellekte tutun.

{{% alert color="info" title="Ayrıca bakınız" %}}
- [Sunumları Şifreleme](/slides/tr/cpp/password-protected-presentation/)
- [Salt Okunur Sunumlar](/slides/tr/cpp/read-only-presentation/)
- [PowerPoint'te Dijital İmza](/slides/tr/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Yazma koruması bir sunumu şifreler mi?**

Hayır. Değişikliği kısıtlar ancak sunum içeriğinin yüklenip görüntülenebilmesini sağlar.

**Bir sunumu açmak için yazma koruma parolası gerekli mi?**

Hayır. Şifreli sunum içeriğini yüklemek için yalnızca açma parolası gerekir.

**Bir sunum aynı anda açma parolası ve yazma koruma parolası içerebilir mi?**

Evet. Şifreli sunumu açmak için açma parolasını yükleme seçenekleriyle sağlayın ve değişiklik yetkisi gerektiğinde yazma koruma parolasını ayrı olarak doğrulayın.