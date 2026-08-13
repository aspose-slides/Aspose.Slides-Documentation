---
title: .NET'te Şifrelerle Sunuları Güvenceye Almak
linktitle: Şifre Koruması
type: docs
weight: 20
url: /tr/net/password-protected-presentation/
keywords:
- PowerPoint Kilitle
- Sunuyu Kilitle
- PowerPoint Kilidini Aç
- Sununun Kilidini Aç
- PowerPoint Koruma
- Sunuyu Koruma
- Şifre Ayarla
- Şifre Ekle
- PowerPoint Şifrele
- Sunuyu Şifrele
- PowerPoint Şifresini Çöz
- Sununun Şifresini Çöz
- Yazma Koruması
- PowerPoint Güvenliği
- Sunum Güvenliği
- Şifreyi Kaldır
- Koruma Kaldır
- Şifrelemeyi Kaldır
- Şifreyi Devre Dışı Bırak
- Koruma Devre Dışı
- Yazma Korumasını Kaldır
- PowerPoint
- OpenDocument
- Sunum
- .NET
- C#
- Aspose.Slides
description: Aspose.Slides for .NET ile şifre korumalı PowerPoint ve OpenDocument sunularını sorunsuz bir şekilde nasıl kilitleyeceğinizi ve kilidini açacağınızı öğrenin. Sunularınızı güvenceye alın.
---
## **Giriş**

Bir sunuyu şifreyle koruduğunuzda, sunuya belirli kısıtlamalar getiren bir şifre belirlediğiniz anlamına gelir. Bu kısıtlamaları kaldırmak için şifre girilmelidir. Şifreyle korunan bir sunu kilitli bir sunu olarak kabul edilir.

Genellikle, bir sunuya bu kısıtlamaları uygulamak için şifre belirleyebilirsiniz:

- **Modification**

Sadece belirli kullanıcıların sununuzu değiştirmesini istiyorsanız, bir değişiklik kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, şifre sağlanmadıkça kişilerin sununuzdaki öğeleri değiştirmesini, düzenlemesini veya kopyalamasını engeller. 

Ancak şifre olmadan da bir kullanıcı belgelerinize erişebilir ve açabilir. Bu yalnızca-okunur modda, kullanıcı içerikleri—hiperlinkler, animasyonlar, efektler ve diğer öğeler dahil—görüntüleyebilir, ancak öğeleri kopyalayamaz veya sunuyu kaydedemez.

- **Opening**

Sadece belirli kullanıcıların sununuzu açmasını istiyorsanız, bir açma kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, şifre sağlanmadıkça kullanıcıların sunununuzun içeriğini görmesini engeller.

Teknik olarak, açma kısıtlaması aynı zamanda kullanıcıların sunularınızı değiştirmesini de engeller—eğer bir sunu açılamıyorsa, değiştirilemez veya üzerinde değişiklik yapılamaz.

**Not:** Sunuyu açmayı engellemek için şifreyle koruduğunuzda, sunu dosyası şifrelenir.

## **Aspose.Slides'de Şifre Koruması**

**Desteklenen formatlar**

Aspose.Slides, bu formatlardaki sunular için şifre koruması, şifreleme ve benzeri işlemleri destekler:

- PPTX ve PPT – Microsoft PowerPoint Sunuları
- ODP – OpenDocument Sunuları
- OTP – OpenDocument Sunu Şablonları

**Desteklenen işlemler**

Aspose.Slides, aşağıdaki yollarla sunularda değişiklikleri önlemek için şifre koruması kullanmanıza olanak tanır:

- Sunuyu şifreleme
- Sunuya yazma koruması ayarlama

**Diğer işlemler**

Aspose.Slides, şifre koruması ve şifreleme ile ilgili ek görevleri aşağıdaki yollarla gerçekleştirmenizi sağlar:

- Sunuyu şifre çözme; şifreli bir sunuyu açma
- Şifrelemeyi kaldırma; şifre korumasını devre dışı bırakma
- Sunudan yazma korumasını kaldırma
- Şifreli bir sununun özelliklerini alma
- Sunuyu yüklemeden önce şifre korumalı olup olmadığını kontrol etme
- Sununun şifrelenip şifrelenmediğini kontrol etme
- Sununun şifre korumalı olup olmadığını kontrol etme

## **Bir Sunuyu Şifreyle Korumak**

Bir sunuyu şifre belirleyerek şifreleyebilirsiniz. Kilitli sunuyu değiştirmek isteyen bir kullanıcı şifreyi girmek zorundadır.

Bir sunuyu (veya şifreyle korumayı) şifrelemek için, şifre ayarlamak amacıyla [ProtectionManager](https://reference.aspose.com/slides/tr/net/aspose.slides/protectionmanager) üzerindeki `Encrypt` metodunu kullanın. Şifreyi `Encrypt` metoduna geçirin, ardından şifrelenmiş sunuyu kaydetmek için `Save` metodunu kullanın.

Bu örnek kod, bir sunuyu nasıl şifreleyeceğinizi gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **Sunuda Yazma Koruması Ayarlama** 

Sununuza “Değiştirmeyin” ibaresi ekleyebilirsiniz. Bu, kullanıcılara sunuyu değiştirmelerini istemediğinizi bildirir.

**Not:** Yazma koruma işlemi sunuyu şifrelemez. Bu nedenle kullanıcılar—istemedikleri takdirde—sunuyu değiştirebilir, ancak değişiklikleri kaydetmek için farklı bir adla kaydetmek zorunda kalırlar.

Yazma koruması ayarlamak için `SetWriteProtection` metodunu kullanın. Bu örnek kod, bir sunuya yazma koruması nasıl ayarlanır gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **Şifreli Bir Sunu Yükleme**

Aspose.Slides, doğru şifreyi geçerek şifreli bir sunuyu yüklemenize izin verir. Bu örnek kod, şifreli bir sununun nasıl yükleneceğini gösterir:

```c#
using Aspose.Slides;

LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // Şifre çözülmüş sunuyla çalış.
}
```

## **Sunudan Şifrelemeyi Kaldırma**

Şifreleme veya şifre korumasını bir sunudan kaldırarak kullanıcıların sınırsız erişim ve değişiklik yapmasını sağlayabilirsiniz.

Şifreleme veya şifre korumasını kaldırmak için [RemoveEncryption](https://reference.aspose.com/slides/tr/net/aspose.slides/protectionmanager/methods/removeencryption) metodunu çağırın. Bu örnek kod, bir sunudan şifrelemenin nasıl kaldırılacağını gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **Sunudan Yazma Korumasını Kaldırma**

Aspose.Slides ile bir sunu dosyasından yazma korumasını kaldırabilirsiniz. Böylece kullanıcılar istedikleri gibi değiştirebilir ve bu tür görevlerde uyarı almazlar.

Yazma korumasını kaldırmak için [RemoveWriteProtection](https://reference.aspose.com/slides/tr/net/aspose.slides/protectionmanager/methods/removewriteprotection) metodunu kullanın. Bu örnek kod, bir sunudan yazma korumasının nasıl kaldırılacağını gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **Şifreli Bir Sununun Özelliklerini Alma**

Genellikle kullanıcılar şifreli veya şifre korumalı bir sununun belge özelliklerini almada zorluk yaşar. Ancak Aspose.Slides, bir sunuyu şifreyle korurken kullanıcıların özelliklerine erişebilmesini sağlayan bir mekanizma sunar.

**Not:** Varsayılan olarak, Aspose.Slides bir sunuyu şifrelediğinde, sununun belge özellikleri de şifre korunur. Şifreleme sonrasında belge özelliklerinin erişilebilir olmasını istiyorsanız, Aspose.Slides bunu tam olarak yapmanıza izin verir.

Şifreli bir sununun özelliklerine kullanıcıların erişebilmesini istiyorsanız, [IProtectionManager](https://reference.aspose.com/slides/tr/net/aspose.slides/iprotectionmanager/) üzerindeki `EncryptDocumentProperties` özelliğini `false` olarak ayarlayın. Bu örnek kod, bir sunuyu şifrelerken aynı zamanda belge özelliklerine erişim sağlamayı gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Şifreli Bir Sunudan Yalnızca Belge Özelliklerini Yükleme**

Şifreli bir sununun meta verilerini slaytlarını veya diğer içeriğini yüklemeden incelemek için bir [LoadOptions](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/) nesnesi oluşturun ve [OnlyLoadDocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) özelliğini `true` olarak ayarlayın. Bu modda Aspose.Slides şifreyi yok sayar ve yalnızca herkese açık olan belge özelliklerini yükler.

Aşağıdaki kod örneği, [IPresentation.DocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/documentproperties/) aracılığıyla yerleşik ve özel belge özelliklerini okur:

```c#
using Aspose.Slides;

var loadOptions = new LoadOptions
{
    OnlyLoadDocumentProperties = true
};

using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);
var documentProperties = presentation.DocumentProperties;

// Yerleşik belge özelliklerini oku.
Console.WriteLine("Title: " + documentProperties.Title);
Console.WriteLine("Author: " + documentProperties.Author);

// Özel belge özelliklerini oku.
var customPropertyCount = documentProperties.CountOfCustomProperties;

for (var propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    var propertyName = documentProperties.GetCustomPropertyName(propertyIndex);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine(propertyName + ": " + propertyValue);
}
```

Bu iş akışı yalnızca sunu şifrelenirken belge özellikleri şifrelenmemiş (halka açık) olduğunda çalışır. Belge özellikleri şifreli ise, `OnlyLoadDocumentProperties` özelliğini `true` yapmanız bir istisna oluşturur çünkü bu modda şifre yok sayılır. Şifreli belge özelliklerine erişmek veya slaytlar ve diğer içerik dahil tam sunuyu yüklemek için [LoadOptions](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/) içinde doğru `Password` değerini sağlayın.

## **Sununun Şifre Koruması Olup Olmadığını Kontrol Etme**

Bir sunuyu yüklemeden önce, şifre korumalı olup olmadığını kontrol etmek isteyebilirsiniz. Bu, şifre korumalı bir sunu doğru şifre olmadan yüklendiğinde oluşabilecek hataları ve benzeri sorunları önlemenize yardımcı olur.

Bu C# kodu, bir sununun şifre korumalı olup olmadığını aslında yüklemeden incelemenizi gösterir:

```c#
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **Sununun Şifrelenip Şifrelenmediğini Kontrol Etme**

Aspose.Slides, bir sununun şifrelenip şifrelenmediğini kontrol etmenizi sağlar. Bu görevi yerine getirmek için, sunu şifreli ise `true`, değilse `false` dönen [IsEncrypted](https://reference.aspose.com/slides/tr/net/aspose.slides/protectionmanager/properties/isencrypted) özelliğini kullanabilirsiniz.

Bu örnek kod, bir sununun şifreli olup olmadığını nasıl kontrol edeceğinizi gösterir:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **Sununun Yazma Koruması Olup Olmadığını Kontrol Etme**

Aspose.Slides, bir sununun yazma korumalı olup olmadığını kontrol etmenizi sağlar. Bu görevi yerine getirmek için, sunu yazma korumalı ise `true`, değilse `false` dönen [IsWriteProtected](https://reference.aspose.com/slides/tr/net/aspose.slides/protectionmanager/properties/iswriteprotected) özelliğini kullanabilirsiniz.

Bu örnek kod, bir sununun yazma korumalı olup olmadığını nasıl kontrol edeceğinizi gösterir:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **Sununun Şifre Kullanımını Doğrulama**

Belirli bir şifrenin bir sunu belgesini korumak için kullanılıp kullanılmadığını kontrol etmek ve doğrulamak isteyebilirsiniz. Aspose.Slides, bir şifreyi doğrulamanız için gerekli araçları sunar.

Bu örnek kod, bir şifrenin doğrulanmasını nasıl yapacağınızı gösterir:

```c#
using Aspose.Slides;

using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // Parolanın eşleşip eşleşmediğini kontrol et.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

Belirtilen şifreyle şifrelenmişse `true`, aksi takdirde `false` döner.

{{% alert color="info" title="Ayrıca" %}} 
- [PowerPoint'ta Dijital İmza](/slides/tr/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Sunuyu Çevrimiçi Şifreyle Koruma**

1. Bizim [**Aspose.Slides Lock**](https://products.aspose.app/slides/tr/lock) sayfamıza gidin. 
1. **Dosyalarınızı bırakın veya yükleyin** seçeneğine tıklayın.
1. Bilgisayarınızdan şifreyle korumak istediğiniz dosyayı seçin. 
1. Düzenleme koruması ve görüntüleme koruması için tercih ettiğiniz şifreleri girin.
1. Kullanıcıların sununuzu son kopya olarak görmesini istiyorsanız, **Mark as final** kutusunu işaretleyin.
1. **ŞİMDİ KORU** butonuna tıklayın. 
1. **ŞİMDİ İNDİR** butonuna tıklayın.

![PowerPoint sunularını şifreyle koruma](slides-lock.png)

## **SSS**

**Aspose.Slides hangi şifreleme yöntemlerini destekliyor?**

Aspose.Slides, AES tabanlı algoritmalar dahil modern şifreleme yöntemlerini destekleyerek sunularınız için yüksek düzeyde veri güvenliği sağlar.

**Sunuyu açmaya çalışırken hatalı şifre girilirse ne olur?**

Yanlış şifre kullanıldığında bir istisna fırlatılır ve sunuya erişimin reddedildiği konusunda sizi uyarır. Bu, yetkisiz erişimi önlemeye ve sunu içeriğini korumaya yardımcı olur.

**Şifre korumalı sunularla çalışırken performans etkileri var mı?**

Şifreleme ve şifre çözme işlemleri açma ve kaydetme sırasında hafif bir ek yük oluşturabilir. Çoğu durumda bu performans etkisi çok düşüktür ve sunu görevlerinizin toplam işleme süresini önemli ölçüde etkilemez.