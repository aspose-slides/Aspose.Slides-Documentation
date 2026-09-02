---
title: .NET'te Sunumları Parola ile Koruma
linktitle: Parola Koruması
type: docs
weight: 20
url: /tr/net/password-protected-presentation/
keywords:
- parola korumalı sunum
- açılış parolası
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
- .NET
- C#
- Aspose.Slides
description: "C# ile Aspose.Slides for .NET kullanarak parola korumalı PowerPoint PPT ve PPTX sunumlarını şifreleyin, algılayın, doğrulayın, açın ve şifresini çözün."
---
## **Genel Bakış**

Açılış parolası bir sunumu şifreler. Doğru parola, sunum içeriğini yüklemek ve görüntülemek için gereklidir; bu koruma gizlilik sağlar.

Açılış parolası, yazma koruma parolası ile farklıdır. Yazma koruması değişiklikleri kısıtlar ancak içeriği şifrelemez veya sunumun yüklenmesini engellemez. Sunumları değiştirmek için parolaları yönetmek üzere, bakınız [Write-Protect Presentations](/slides/tr/net/write-protected-presentation/).

Aşağıdaki iş akışları hem PPT hem de PPTX sunumları için geçerlidir. Örneklerde, dosya tabanlı ve akış tabanlı davranışlarının önemli olduğu iki format da kullanılmıştır.

## **Açılış Parolasıyla Bir Sunumu Şifreleme**

[IProtectionManager.Encrypt](https://reference.aspose.com/slides/tr/net/aspose.slides/iprotectionmanager/encrypt/) kullanarak bir açılış parolası atayın. Ardından şifrelenmiş sunumu kaydetmek için [IPresentation.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/save/) kullanın.

Aşağıdaki örnek bir PPTX sunumunu şifreler:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Şifreli Bir Sunumu Yükleme**

[LoadOptions.Password](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/password/) açılış parolasına ayarlayın ve dosyayı yüklerken seçenekleri [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/)’a iletin. Açılış parolası gerektiği halde sağlanan parola eksik ya da hatalı olduğunda yükleme başarısız olur.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// Şifre çözülmüş sunumla çalış.
```

## **Bir Sunumdan Şifrelemeyi Kaldırma**

Sunumu açılış parolasıyla yükleyin, [IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/tr/net/aspose.slides/iprotectionmanager/removeencryption/) metodunu çağırın ve sonucu kaydedin. Kaydedilen sunum daha sonra parola olmadan yüklenebilir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **Yüklemeden Önce Açılış Parolasını Doğrulama**

[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationfactory/getpresentationinfo/) kullanarak bir tam sunum örneği oluşturmadan [IPresentationInfo](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationinfo/) alın. Parola istemeden veya doğrulamadan önce [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationinfo/ispasswordprotected/) kontrol edin. Koruma mevcut olduğunda, sağlanan değeri [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationinfo/checkpassword/) ile doğrulayın.

### **Dosya Yolu İş Akışı**

Aşağıdaki örnek bir PPTX dosyası için açılış parolasını doğrular, doğrulanmış değeri [LoadOptions.Password](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/password/)’a gönderir ve ardından tam sunumu yükler:

```csharp
using System;
using Aspose.Slides;

var filePath = "protected-presentation.pptx";
var password = "open_password";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(filePath, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **Akış İş Akışı**

[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationfactory/getpresentationinfo/)’in akış aşırı yüklemesi aynı iş akışını sağlar. Tam sunumu o akıştan yüklemeden önce arama yapılabilir bir akışın konumunu sıfırlayın.

Aşağıdaki örnek bir PPT dosyası kullanır:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var password = "open_password";
using var presentationStream = File.OpenRead("protected-presentation.ppt");
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(presentationStream);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    presentationStream.Position = 0;

    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(presentationStream, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **CheckPassword Döndürdüğü Değerler**

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationinfo/checkpassword/) yalnızca sunumun bir açılış parolası olması ve sağlanan parolanın doğru olması durumunda `true` döndürür. Aşağıdaki durumlarda `false` döner:

- Parola yanlış.
- Sunumun bir açılış parolası yok.
- Sağlanan parola `null` veya boş.

Davranış PPT ve PPTX sunumları için aynı şekilde olur.

## **Yüklenen Sunumun Şifreli Olup Olmadığını Kontrol Et**

Doğru parolayla bir sunumu yükledikten sonra, kaynak sunumun şifreli olduğunu teyit etmek için [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/tr/net/aspose.slides/iprotectionmanager/isencrypted/) inceleyin. Yüklemeden önce açılış parolası korumasını tespit etmek için yukarıda gösterildiği gibi `IPresentationInfo.IsPasswordProtected` kullanın.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **Güvenlik Önerileri**

{{% alert color="warning" title="Security" %}}
Açılış parolalarını günlüğe kaydetmeyin ve tanılama mesajlarına eklemeyin. Gereksiz tekrar doğrulama denemelerinden kaçının, parolaları yalnızca gerektiği süre boyunca bellekte tutun ve sunumu hemen yüklerken başarılı bir doğrulama sonucunu yeniden kullanın.
{{% /alert %}}

## **Sunumu Çevrimiçi Şifreyle Koruma**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/tr/lock) uygulamasını açın.
1. Sunumu seçin veya yükleyin.
1. Görüntüleme koruması için bir parola girin.
1. İsteğe bağlı olarak düzenleme koruması için ayrı bir parola girin.
1. Koruma uygulayın ve oluşan dosyayı indirin.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/tr/net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/tr/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Açılış parolası ile yazma koruma parolası arasındaki fark nedir?**

Açılış parolası sunumu şifreler ve içeriğini yüklemek için gereklidir. Yazma koruma parolası, içeriği şifrelemeden değişiklikleri kısıtlar.

**Tüm slaytları yüklemeden bir açılış parolasını doğrulayabilir miyim?**

Evet. Sunum bilgilerini elde edin, açılış parolası korumasının mevcut olup olmadığını kontrol edin ve tam bir sunum örneği oluşturmadan önce parolayı doğrulayın.

**Parola kontrol iş akışları hem PPT hem de PPTX'i destekliyor mu?**

Evet. Dosya yolu ve akış tabanlı parola algılama ve doğrulama, PPT ve PPTX sunumları için aynı şekilde çalışır.