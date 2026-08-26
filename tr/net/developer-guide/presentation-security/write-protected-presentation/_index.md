---
title: .NET'te Sunumları Yazma Koruması
linktitle: Yazma Koruması
type: docs
weight: 25
url: /tr/net/write-protected-presentation/
keywords:
- yazma koruması
- PowerPoint Yazma Koruması
- değiştirme şifresi
- sunum düzenlemesini kısıtlama
- yazma korumasını kaldırma
- değiştirme şifresini doğrulama
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PowerPoint PPT ve PPTX sunumlarında yazma koruma şifrelerini ayarlama, tespit etme, doğrulama ve kaldırma."
---
## **Giriş**

Yazma koruması şifresi bir sunumun değiştirilmesini kısıtlar ancak içeriğini şifrelemez. Kullanıcılar şifre olmadan yazma korumalı bir sunumu yükleyebilir ve görüntüleyebilir. Uygulamaya bağlı olarak, içeriği düzenleyip farklı bir adla kaydedebilirler, bu nedenle yazma koruması bir gizlilik mekanizması olarak değerlendirilmemelidir.

Açma şifresi farklı bir amaca hizmet eder: sunumu şifreler ve içeriğini yüklemek için gereklidir. Bir sunumu şifrelemek veya açma şifresini doğrulamak için [Password-Protect Presentations](/slides/tr/net/password-protected-presentation/) bölümüne bakın.

Bu makaledeki iş akışları hem PPT hem de PPTX sunumları için geçerlidir. Örnekler PPTX dosyalarını kullanır; PPT olarak kaydederken `.ppt` uzantısını ve ilgili PPT kaydetme formatını kullanın.

## **Bir Sunuma Yazma Koruması Ayarlama**

Bir sunumun değiştirilmesi için şifre atamak üzere [IProtectionManager.SetWriteProtection](https://reference.aspose.com/slides/tr/net/aspose.slides/iprotectionmanager/setwriteprotection/) yöntemini kullanın. Sunumu kaydetmek koruma ayarını kalıcı hâle getirir.

Aşağıdaki örnek, bir PPTX sunumuna yazma koruması ekler:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.SetWriteProtection("modify_password");
presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
```

## **Yazma Koruması Olan Bir Sunumu Yükleme**

Yazma koruması sunum içeriğini şifrelemediğinden, sunumu yüklemek için şifre gerekmez. Şifre yalnızca korumalı sunumu değiştirme yetkisinin doğrulanmasında önemlidir.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("write-protected-pres.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Yazma koruma şifresini [LoadOptions.Password](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/password/) özelliğine gönderme. Bu özellik şifreli içerik için açma şifresini kabul eder. Bir sunumda her iki koruma türü de varsa, yüklemek için açma şifresini sağlayın ve yazma koruma şifresini ayrı olarak işleyin.

## **Bir Sunumdan Yazma Korumasını Kaldırma**

Değiştirme kısıtlamasını kaldırmak ve ardından sunumu kaydetmek için [IProtectionManager.RemoveWriteProtection](https://reference.aspose.com/slides/tr/net/aspose.slides/iprotectionmanager/removewriteprotection/) yöntemini kullanın.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("write-protected-pres.pptx");

presentation.ProtectionManager.RemoveWriteProtection();
presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
```

## **Bir Sunumun Yazma Koruması Olup Olmadığını Kontrol Etme**

Tam bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) nesnesi oluşturmadan bir dosyayı incelemek için [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationfactory/getpresentationinfo/) yöntemini çağırın ve [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationinfo/iswriteprotected/) özelliğini inceleyin. Bu özellik [NullableBool](https://reference.aspose.com/slides/tr/net/aspose.slides/nullablebool/) kullanır ve yazma koruması tespit edildiğinde `NullableBool.True` döndürür.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected == NullableBool.True)
{
    Console.WriteLine("The presentation is write protected.");
}
else
{
    Console.WriteLine("Write protection was not detected.");
}
```

[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationfactory/getpresentationinfo/) yönteminin akış (stream) aşırı yüklemesi, akış olarak sağlanan bir sunum için aynı bilgileri verir.

## **Yazma Koruma Şifresini Doğrulama**

Tam sunumu yüklemeden bir değiştirme şifresini doğrulamak için [IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationinfo/checkwriteprotection/) yöntemini kullanın. Uygulamanın sadece yazma koruması mevcut olduğunda şifre talep etmesi veya doğrulaması için önce [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationinfo/iswriteprotected/) kontrol edin.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected != NullableBool.True)
{
    Console.WriteLine("The presentation is not write protected.");
}
else if (presentationInfo.CheckWriteProtection("modify_password"))
{
    Console.WriteLine("The write-protection password is correct.");
}
else
{
    Console.WriteLine("The write-protection password is incorrect.");
}
```

[IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationinfo/checkwriteprotection/) yalnızca yazma koruma şifresini doğrular. Açma şifresini doğrulamaz ve şifreli içeriğin yüklenip yüklenemeyeceğini belirlemez. Buna karşılık, [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationinfo/checkpassword/) yalnızca açma şifresini doğrular. Tam bir sunum zaten yüklendiyse, [IProtectionManager.CheckWriteProtection](https://reference.aspose.com/slides/tr/net/aspose.slides/iprotectionmanager/checkwriteprotection/) koruma yöneticisi aracılığıyla eşdeğer bir yazma koruması kontrolü sağlar.

Üretim uygulamalarında şifreleri kaydetmeyin veya tanı mesajlarına eklemeyin. Gereksiz tekrar doğrulama girişimlerinden kaçının ve şifreleri yalnızca gerektiği süre boyunca bellekte tutun.

{{% alert color="info" title="Ayrıca bakınız" %}}
- [Sunumları Şifreleme](/slides/tr/net/password-protected-presentation/)
- [Salt Okunur Sunumlar](/slides/tr/net/read-only-presentation/)
- [PowerPoint'te Dijital İmza](/slides/tr/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Yazma koruması bir sunumu şifreler mi?**

Hayır. Değiştirmeyi kısıtlar ancak sunum içeriğinin yüklenip görüntülenmesine izin verir.

**Yazma koruma şifresi bir sunumu açmak için gerekli mi?**

Hayır. Şifreli sunum içeriğini yüklemek için yalnızca açma şifresi gerekir.

**Bir sunum hem açma şifresi hem de yazma koruma şifresi alabilir mi?**

Evet. Şifreli sunumu açmak için yükleme seçenekleri aracılığıyla açma şifresini sağlayın ve değiştirme yetkisi gerektiğinde yazma koruma şifresini ayrı olarak doğrulayın.