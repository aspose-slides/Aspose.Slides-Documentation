---
title: ".NET'te Şifrelerle Sunumları Güvenli Hale Getirme"
linktitle: "Şifre Koruması"
type: docs
weight: 20
url: /tr/net/password-protected-presentation/
keywords:
- "PowerPoint'i kilitle"
- "sunumu kilitle"
- "PowerPoint'i aç"
- "sunumu aç"
- "PowerPoint'i koru"
- "sunumu koru"
- "şifre belirle"
- "şifre ekle"
- "PowerPoint'i şifrele"
- "sunumu şifrele"
- "PowerPoint'i şifresini çöz"
- "sunumun şifresini çöz"
- "yazma koruması"
- "PowerPoint güvenliği"
- "sunum güvenliği"
- "şifreyi kaldır"
- "korumayı kaldır"
- "şifrelemeyi kaldır"
- "şifreyi devre dışı bırak"
- "korumayı devre dışı bırak"
- "yazma korumasını kaldır"
- "PowerPoint"
- "OpenDocument"
- "sunum"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET ile şifre korumalı PowerPoint ve OpenDocument sunumlarını nasıl sorunsuz bir şekilde kilitleyeceğinizi ve kilidini açacağınızı öğrenin. Sunumlarınızı güvence altına alın."
---
## **Giriş**

Bir sunumu şifreyle koruduğunuzda, sunuma belirli kısıtlamalar getiren bir şifre ayarladığınız anlamına gelir. Bu kısıtlamaları kaldırmak için şifre girilmelidir. Şifreyle korunan bir sunum kilitli bir sunum olarak kabul edilir.

Genellikle, bir sunuma bu kısıtlamaları uygulamak için bir şifre ayarlayabilirsiniz:

- **Değiştirme**

Yalnızca belirli kullanıcıların sunumunuzu değiştirmesini istiyorsanız, bir değiştirme kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, şifreyi sağlamayan kişilerin sunumunuzdaki öğeleri değiştirmesini, düzenlemesini veya kopyalamasını önler.  

Bununla birlikte, şifre olmadan da bir kullanıcı belgenize erişebilir ve açabilir. Bu yalnızca‑okuma modunda, kullanıcı sunumunuzdaki içeriği—hiperlinkler, animasyonlar, efektler ve diğer öğeler dahil—görebilir, ancak öğeleri kopyalayamaz veya sunumu kaydedemez.

- **Açma**

Yalnızca belirli kullanıcıların sunumunuzu açmasını istiyorsanız, bir açma kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, şifreyi sağlamayan kişilerin sunum içeriğini bile görüntülemesini engeller.  

Teknik olarak, açma kısıtlaması aynı zamanda kullanıcıların sunumunuzu değiştirmesini de engeller—eğer bir kişi bir sunumu açamazsa, onu değiştiremez veya üzerinde değişiklik yapamaz.

**Not:** Bir sunumu açmayı engelleyecek şekilde şifreyle koruduğunuzda, sunum dosyası şifrelenir.

## **Aspose.Slides'ta Şifre Koruması**

**Desteklenen formatlar**

Aspose.Slides, bu formatlardaki sunumlar için şifre koruması, şifreleme ve benzeri işlemleri destekler:

- PPTX ve PPT – Microsoft PowerPoint Sunumları
- ODP – OpenDocument Sunumları
- OTP – OpenDocument Sunum Şablonları

**Desteklenen işlemler**

Aspose.Slides, sunumlarda şifre korumasını kullanarak değişiklikleri aşağıdaki şekillerde önlemenizi sağlar:

- Bir sunumu şifreleme
- Bir sunumda yazma koruması ayarlama

**Diğer işlemler**

Aspose.Slides, şifre koruması ve şifreleme ile ilgili ek görevleri aşağıdaki şekillerde gerçekleştirmenizi sağlar:

- Bir sunumu şifre çözme; şifreli bir sunumu açma
- Şifrelemeyi kaldırma; şifre korumasını devre dışı bırakma
- Bir sunumdan yazma korumasını kaldırma
- Şifreli bir sunumun özelliklerini alma
- Bir sunumu yüklemeden önce şifreyle korunduğunu kontrol etme
- Bir sunumun şifreli olup olmadığını kontrol etme
- Bir sunumun şifreyle korunduğunu kontrol etme

## **Bir Sunumu Şifreyle Korumak**

Bir şifre belirleyerek bir sunumu şifreleyebilirsiniz. Kilitli sunumu değiştirmek için kullanıcı şifreyi girmelidir.

Bir sunumu şifrelemek (veya şifreyle korumak) için, şifreyi ayarlamak amacıyla [ProtectionManager](https://reference.aspose.com/slides/tr/net/aspose.slides/protectionmanager) içindeki `Encrypt` metodunu kullanın. Şifreyi `Encrypt` metoduna iletin, ardından şifrelenmiş sunumu kaydetmek için `Save` metodunu kullanın.

Bu örnek kod, bir sunumu nasıl şifreleyeceğinizi gösterir:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **Bir Sunuma Yazma Koruması Ayarlamak** 

Sunuma “Değiştirmeyin” ibaresi ekleyebilirsiniz. Bu, kullanıcılara sunuma değişiklik yapmamalarını bildirir.

**Not:** Yazma koruma işlemi sunumu şifrelemez. Bu nedenle, kullanıcılar—isterlerse—sunumu değiştirebilir, ancak değişiklikleri kaydetmek için farklı bir ad altında kaydetmeleri gerekir.

Yazma koruması ayarlamak için `SetWriteProtection` metodunu kullanın. Bu örnek kod, bir sunuma yazma koruması nasıl ekleyeceğinizi gösterir:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **Şifreli Bir Sunumu Yüklemek**

Aspose.Slides, doğru şifreyi sağlayarak şifreli bir sunumu yüklemenize olanak tanır. Bu örnek kod, şifreli bir sunumu nasıl yükleyeceğinizi gösterir:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // Şifre çözülmüş sunumla çalış.
}
```

## **Bir Sunumdan Şifrelemeyi Kaldırmak**

Bir sunumdan şifreleme ya da şifre korumasını kaldırabilirsiniz; bu sayede kullanıcılar sınırsız olarak erişebilir veya değiştirebilir.

Şifreleme veya şifre korumasını kaldırmak için [RemoveEncryption](https://reference.aspose.com/slides/tr/net/aspose.slides/protectionmanager/methods/removeencryption) metodunu çağırın. Bu örnek kod, bir sunumdan şifrelemeyi nasıl kaldıracağınızı gösterir:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **Bir Sunumdan Yazma Korumasını Kaldırmak**

Aspose.Slides ile bir sunum dosyasının yazma korumasını kaldırabilirsiniz. Böylece kullanıcılar istedikleri gibi değiştirebilir—ve bu işlemleri yaparken herhangi bir uyarı almazlar.

Yazma korumasını, [RemoveWriteProtection](https://reference.aspose.com/slides/tr/net/aspose.slides/protectionmanager/methods/removewriteprotection) metodunu kullanarak kaldırabilirsiniz. Bu örnek kod, bir sunumdan yazma korumasını nasıl kaldıracağınızı gösterir:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **Şifreli Bir Sunumun Özelliklerini Almak**

Genellikle, kullanıcılar şifreli veya şifreyle korunan bir sunumun belge özelliklerini almada zorlanırlar. Bununla birlikte, Aspose.Slides, bir sunumu şifreyle korurken kullanıcıların özelliklerine erişimini sağlayan bir mekanizma sunar.

**Not:** Varsayılan olarak, Aspose.Slides bir sunumu şifrelediğinde, sunumun belge özellikleri de şifre korumalı olur. Şifreleme sonrasında belge özelliklerine erişilebilir olmasını istiyorsanız, Aspose.Slides bunu yapmanıza olanak tanır.

Kullanıcıların şifreli bir sunumun özelliklerine erişim yeteneğini korumasını istiyorsanız, [EncryptDocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/protectionmanager/properties/encryptdocumentproperties) özelliğini `true` olarak ayarlayabilirsiniz. Bu örnek kod, bir sunumu şifrelerken aynı zamanda kullanıcıların belge özelliklerine erişimini nasıl sağlayacağınızı gösterir:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.EncryptDocumentProperties = true;
    presentation.ProtectionManager.Encrypt("123123");
}
```

## **Bir Sunumun Şifreyle Korunup Korunmadığını Kontrol Etmek**

Bir sunumu yüklemeden önce, şifreyle korunup korunmadığını kontrol etmek isteyebilirsiniz. Bu, şifre korumalı bir sunum doğru şifre olmadan yüklendiğinde oluşabilecek hataları ve benzeri sorunları önlemenize yardımcı olur.

Bu C# kodu, bir sunumu gerçekten yüklemeden şifreyle korunduğunu nasıl inceleyeceğinizi gösterir:

```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **Bir Sunumun Şifreli Olup Olmadığını Kontrol Etmek**

Aspose.Slides, bir sunumun şifreli olup olmadığını kontrol etmenizi sağlar. Bu işlemi gerçekleştirmek için, sunum şifreli ise `true`, değilse `false` dönen [IsEncrypted](https://reference.aspose.com/slides/tr/net/aspose.slides/protectionmanager/properties/isencrypted) özelliğini kullanabilirsiniz.

Bu örnek kod, bir sunumun şifreli olup olmadığını nasıl kontrol edeceğinizi gösterir:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **Bir Sunumun Yazma Koruması Olup Olmadığını Kontrol Etmek**

Aspose.Slides, bir sunumun yazma korumalı olup olmadığını kontrol etmenizi sağlar. Bu işlemi gerçekleştirmek için, sunum yazma korumalı ise `true`, değilse `false` dönen [IsWriteProtected](https://reference.aspose.com/slides/tr/net/aspose.slides/protectionmanager/properties/iswriteprotected) özelliğini kullanabilirsiniz.

Bu örnek kod, bir sunumun yazma korumalı olup olmadığını nasıl kontrol edeceğinizi gösterir:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **Sunum Şifresi Kullanımını Doğrulamak**

Belirli bir şifrenin bir sunum belgesini korumak için kullanılıp kullanılmadığını kontrol etmek ve doğrulamak isteyebilirsiniz. Aspose.Slides, bir şifreyi doğrulamanız için gerekli yöntemleri sunar.

Bu örnek kod, bir şifreyi nasıl doğrulayacağınızı gösterir:

```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // Şifrenin eşleşip eşleşmediğini kontrol et.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

Belirtilen şifreyle sunum şifrelenmişse `true`; aksi takdirde `false` döner.

{{% alert color="primary" title="Ayrıca bakınız" %}} 
- [PowerPoint'ta Dijital İmza](/slides/tr/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Sunumu Çevrimiçi Şifreyle Koruma**

1. [**Aspose.Slides Lock**](https://products.aspose.app/slides/tr/lock) sayfamıza gidin. 
2. **Dosyalarınızı sürükleyin veya yükleyin** seçeneğine tıklayın. 
3. Bilgisayarınızda şifrelemek istediğiniz dosyayı seçin. 
4. Düzenleme koruması ve görüntüleme koruması için istediğiniz şifreleri girin. 
5. Kullanıcıların sunumunuzu son kopya olarak görmesini istiyorsanız, **Final olarak işaretle** kutusunu işaretleyin. 
6. **ŞİMDİ KORU** üzerine tıklayın. 
7. **ŞİMDİ İNDİR** üzerine tıklayın. 

![PowerPoint sunumlarını şifreyle koruma](slides-lock.png)

## **SSS**

**Aspose.Slides hangi şifreleme yöntemlerini destekliyor?**

Aspose.Slides, AES tabanlı algoritmalar dahil olmak üzere modern şifreleme yöntemlerini destekler ve sunumlarınız için yüksek veri güvenliği sağlar.

**Bir sunumu açmaya çalışırken yanlış şifre girilirse ne olur?**

Yanlış bir şifre kullanılırsa bir istisna fırlatılır ve sunuma erişimin reddedildiği bildirilir. Bu, yetkisiz erişimi önlemeye ve sunum içeriğini korumaya yardımcı olur.

**Şifre korumalı sunumlarla çalışırken performans etkileri var mı?**

Şifreleme ve şifre çözme işlemi, açma ve kaydetme sırasında hafif bir ek yük oluşturabilir. Çoğu durumda bu performans etkisi çok azdır ve sunum görevlerinizin genel işlem süresini önemli ölçüde etkilemez.