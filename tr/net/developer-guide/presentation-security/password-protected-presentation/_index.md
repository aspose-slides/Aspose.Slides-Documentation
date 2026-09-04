---
title: Sunumları .NET'te Şifreyle Koruma
linktitle: Şifre Koruması
type: docs
weight: 20
url: /tr/net/password-protected-presentation/
keywords:
- şifrelenmiş sunum
- açma şifresi
- PowerPoint şifreleme
- PowerPoint şifre çözme
- sunum şifresini doğrulama
- sunum şifresini kontrol etme
- şifreli sunumu açma
- şifrelemeyi kaldırma
- PowerPoint
- PPT
- PPTX
- sunum
- .NET
- C#
- Aspose.Slides
description: "C# ile Aspose.Slides for .NET kullanarak şifrelenmiş PowerPoint PPT ve PPTX sunumlarını şifreleme, algılama, doğrulama, açma ve şifre çözme."
---
## **Genel Bakış**

Bir açma şifresi bir sunumu şifreler. Sunum içeriğini yüklemek ve görüntülemek için doğru şifre gerekir; bu koruma gizliliği sağlar.

Açma şifresi, yazma koruma şifresinden farklıdır. Yazma koruması değişikliği kısıtlar ancak içeriği şifrelemez ya da sunumun yüklenmesini engellemez. Sunumları değiştirmek için şifreleri yönetmek istiyorsanız, [Write-Protect Presentations](/slides/tr/net/write-protected-presentation/) sayfasına bakın.

Aşağıdaki iş akışları hem PPT hem de PPTX sunumları için geçerlidir. Örneklerde, dosya tabanlı ve akış tabanlı davranışlarının önemli olduğu her iki format da kullanılmıştır.

## **Bir Sunumu Açma Şifresiyle Şifreleme**

Açma şifresi atamak için [IProtectionManager.Encrypt](https://reference.aspose.com/slides/tr/net/aspose.slides/iprotectionmanager/encrypt/) yöntemini kullanın. Ardından şifrelenmiş sunumu kalıcı hâle getirmek için [IPresentation.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/save/) yöntemini çağırın.

Aşağıdaki örnek bir PPTX sunumunu şifreler:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Belge Özelliklerini Genel Tutun**

Varsayılan olarak Aspose.Slides, belge özelliklerini sunum şifrelemesine dahil eder. [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) özelliği, kaydırma içeriği şifrelemesinden bağımsız olarak bu davranışı kontrol eder. Bir indeksleme, sınıflandırma, arama veya belge‑yönetim sistemi açma şifresi olmadan üst verileri okuyabilmeli ise, [IProtectionManager.Encrypt](https://reference.aspose.com/slides/tr/net/aspose.slides/iprotectionmanager/encrypt/) çağrılmadan önce bu özelliği `false` olarak ayarlayın.

Aşağıdaki örnek, yerleşik belge özellikleri genel olarak bırakılarak şifrelenmiş bir PPTX sunumu oluşturur:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var properties = presentation.DocumentProperties;
properties.Author = "Contoso Knowledge Management";
properties.Title = "Quarterly Product Roadmap";
properties.Keywords = "roadmap, planning, internal";

presentation.Slides[0].Name = "Encrypted presentation content";
presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("public-properties-encrypted.pptx", SaveFormat.Pptx);
```

`EncryptDocumentProperties` değerini `false` yapmak, slaytları, ana düzenleri, yerleşimleri, şekilleri, medyayı veya diğer sunum içeriğini genel hâle getirmez. Sadece belge özelliklerini etkiler. Bu özellikleri şifreli içeriği yüklemeden okumak için [Manage Presentation Properties](/slides/tr/net/presentation-properties/) sayfasına bakın.

## **Şifrelenmiş Bir Sunumu Yükleme**

[LoadOptions.Password](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/password/) özelliğine açma şifresini atayın ve dosyayı yüklerken bu seçenekleri [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) yapıcısına iletin. Açma şifresi gerekli olduğunda fakat şifre eksik ya da hatalıysa yükleme başarısız olur.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// Şifre çözülmüş sunumla çalışın.
```

## **Bir Sunumdan Şifrelemeyi Kaldırma**

Sunumu açma şifresiyle yükleyin, [IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/tr/net/aspose.slides/iprotectionmanager/removeencryption/) yöntemini çağırın ve sonucu kaydedin. Kaydedilen sunum artık şifre olmadan yüklenebilir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **Yüklemeden Önce Açma Şifresini Doğrulama**

[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationfactory/getpresentationinfo/) yöntemiyle tam bir sunum örneği oluşturmadan [IPresentationInfo](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationinfo/) alın. Şifre talep etmeden ya da doğrulamadan önce [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationinfo/ispasswordprotected/) özelliğini kontrol edin. Koruma mevcutsa, sağlanan değeri [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationinfo/checkpassword/) ile doğrulayın.

### **Dosya Yolu İş Akışı**

Aşağıdaki örnek bir PPTX dosyasının açma şifresini doğrular, doğrulanan değeri [LoadOptions.Password](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/password/) özelliğine geçirir ve ardından tam sunumu yükler:

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

[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationfactory/getpresentationinfo/) yönteminin akış aşırı yüklemesi aynı iş akışını sağlar. Tam sunumu akıştan yüklemeden önce, arama yapılabilir bir akışın konumunu sıfırlamayı unutmayın.

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

### **CheckPassword Dönüş Değerleri**

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentationinfo/checkpassword/) yalnızca sunumda bir açma şifresi bulunuyorsa ve sağlanan şifre doğruysa `true` döndürür. Aşağıdaki durumlarda `false` döner:

- Şifre yanlıştır.
- Sunumda açma şifresi yoktur.
- Sağlanan şifre `null` veya boştur.

Davranış PPT ve PPTX sunumları için aynıdır.

## **Yüklenen Sunumun Şifrelenip Şifrelenmediğini Kontrol Etme**

Doğru şifreyle bir sunumu yükledikten sonra, kaynak sunumun şifrelenip şifrelenmediğini doğrulamak için [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/tr/net/aspose.slides/iprotectionmanager/isencrypted/) özelliğine bakın. Yüklemeden önce açma‑şifresi korumasını tespit etmek için yukarıda gösterildiği gibi `IPresentationInfo.IsPasswordProtected` kullanın.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **Güvenlik Önerileri**

{{% alert color="warning" title="Güvenlik" %}}
Açma şifrelerini kaydetmeyin veya tanı diagnostic mesajlarına eklemeyin. Gereksiz tekrar doğrulama girişimlerinden kaçının, şifreleri yalnızca gerektiği süre kadar bellekte tutun ve sunumu hemen yükleyecekseniz başarılı bir doğrulama sonucunu yeniden kullanın.

Genel belge özellikleri yazar adları, başlıklar, konular, anahtar kelimeler, şirket bilgileri, yorumlar ve özel değerler gibi bilgileri ifşa edebilir; bu durum sunum içeriği şifreli olsa bile geçerlidir. Hassas üst verileri sunumla birlikte şifreleyin. Özellikleri genel bırakmak, yalnızca sistemlerin dosyayı açma şifresi olmadan indekslemesi, sınıflandırması, araması veya yönetmesi gerektiğinde alınan açık bir karardır.
{{% /alert %}}

## **Sunumu Çevrimiçi Şifreleme**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/tr/lock) uygulamasını açın.
2. Sunumu seçin veya yükleyin.
3. Görüntü koruması için bir şifre girin.
4. İsteğe bağlı olarak düzenleme koruması için ayrı bir şifre girin.
5. Koruma uygulayın ve oluşan dosyayı indirin.

{{% alert color="info" title="Bakınız" %}}
- [Write-Protect Presentations](/slides/tr/net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/tr/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **SSS**

**Açma şifresi ile yazma koruma şifresi arasındaki fark nedir?**

Açma şifresi sunumu şifreler ve içeriğinin yüklenmesi için gerekir. Yazma koruma şifresi içeriği şifrelemeden değişikliği kısıtlar.

**Tüm slaytları yüklemeden açma şifresini doğrulayabilir miyim?**

Evet. Sunum bilgilerini alın, açma‑şifresi korumasının mevcut olup olmadığını kontrol edin ve tam bir sunum örneği oluşturmadan şifreyi doğrulayın.

**Bir uygulama açma şifresi olmadan üst verileri okuyabilir mi?**

Evet, ancak sadece sunum `EncryptDocumentProperties` `false` olarak ayarlandıysa mümkündür. Bu durumda uygulama, [Manage Presentation Properties](/slides/tr/net/presentation-properties/) sayfasında anlatıldığı gibi yalnızca belge‑özellikleri yükleme modunu kullanmalıdır.

**Şifre kontrol iş akışları hem PPT hem de PPTX için destekleniyor mu?**

Evet. Dosya yolu ve akış tabanlı şifre tespiti ve doğrulama, PPT ve PPTX sunumları için aynı şekilde çalışır.