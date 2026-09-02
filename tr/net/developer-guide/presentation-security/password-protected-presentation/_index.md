---
title: .NET'te Şifrelerle Güvenli Sunumlar
linktitle: Şifre Koruması
type: docs
weight: 20
url: /tr/net/password-protected-presentation/
keywords:
- PowerPoint'i Kilitle
- Sunumu Kilitle
- PowerPoint'in Kilidini Aç
- Sunumun Kilidini Aç
- PowerPoint'i Koruyun
- Sunumu Koruyun
- Şifre Ayarla
- Şifre Ekle
- PowerPoint'i Şifrele
- Sunumu Şifrele
- PowerPoint'in Şifresini Çöz
- Sunumun Şifresini Çöz
- Yazma Koruması
- PowerPoint Güvenliği
- Sunum Güvenliği
- Şifreyi Kaldır
- Koruması Kaldır
- Şifrelemeyi Kaldır
- Şifreyi Devre Dışı Bırak
- Korumaı Devre Dışı Bırak
- Yazma Korumasını Kaldır
- PowerPoint
- OpenDocument
- Sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile şifre korumalı PowerPoint ve OpenDocument sunumlarını zahmetsizce nasıl kilitleyip açabileceğinizi öğrenin. Sunumlarınızı güvence altına alın."
---
## **Giriş**

Bir sunumu şifreyle koruduğunuzda, sunuma belirli kısıtlamaları uygulayan bir şifre belirlemiş olursunuz. Bu kısıtlamaları kaldırmak için şifre girilmelidir. Şifreyle korunan bir sunum kilitli bir sunum olarak kabul edilir.

Genellikle, bir sunuma bu kısıtlamaları uygulamak için bir şifre ayarlayabilirsiniz:

- **Değişiklik**

  Belirli kullanıcıların sunumunuzu değiştirmesini istiyorsanız, bir değişiklik kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, şifreyi sağlamayan kişilerin sunumunuzdaki öğeleri değiştirmesini, düzenlemesini veya kopyalamasını engeller.  

  Ancak şifre olmadan bir kullanıcı hâlâ belgenize erişebilir ve açabilir. Bu sadece‑okuma modunda kullanıcı içeriği—bağlantılar, animasyonlar, efektler ve diğer öğeler dahil—görebilir, ancak öğeleri kopyalayamaz veya sunumu kaydedemez.

- **Açma**

  Belirli kullanıcıların sunumunuzu açmasını istiyorsanız, bir açma kısıtlaması ayarlayabilirsiniz. Bu kısıtlama, şifreyi sağlamayan kişilerin sunum içeriğini hatta görüntülemesini bile engeller.

  Teknik olarak, açma kısıtlaması aynı zamanda kullanıcıların sunumlarınızı değiştirmesini de engeller—eğer bir sunum açılamıyorsa, değiştirilemez veya değişiklik yapılamaz.

**Not:** Bir sunumu açılmasını engellemek için şifreyle koruduğunuzda, sunum dosyası şifrelenir.

## **Aspose.Slides'da Şifre Koruması**

**Desteklenen formatlar**

Aspose.Slides, aşağıdaki formatlardaki sunumlar için şifre koruması, şifreleme ve benzeri işlemleri destekler:

- PPTX ve PPT – Microsoft PowerPoint Sunumları
- ODP – OpenDocument Sunumları
- OTP – OpenDocument Sunum Şablonları

**Desteklenen işlemler**

Aspose.Slides, bir sunumu değişikliklerden korumak için şifre korumasını aşağıdaki şekillerde kullanmanıza olanak tanır:

- Bir sunumu şifreleme
- Bir sunuma yazma koruması ayarlama

**Diğer işlemler**

Aspose.Slides, şifre koruması ve şifreleme ile ilgili ek görevleri aşağıdaki şekillerde gerçekleştirmenizi sağlar:

- Bir sunumu şifre çözme; şifreli bir sunumu açma
- Şifrelemeyi kaldırma; şifre korumasını devre dışı bırakma
- Bir sunumdan yazma korumasını kaldırma
- Şifreli bir sunumun özelliklerini alma
- Bir sunumu yüklemeden önce şifreyle korunup korunmadığını kontrol etme
- Bir sunumun şifreli olup olmadığını kontrol etme
- Bir sunumun şifreyle korunup korunmadığını kontrol etme

## **Bir Sunumu Şifreyle Koruma**

Bir sunumu şifre belirleyerek şifreleyebilirsiniz. Ardından kilitli sunumu değiştirmek isteyen bir kullanıcı şifreyi girmelidir.

Bir sunumu şifreyle korumak (şifrelemek) için `Encrypt` yöntemini [ProtectionManager](https://reference.aspose.com/slides/tr/net/aspose.slides/protectionmanager) üzerinden kullanın. Şifreyi `Encrypt` yöntemine geçirin, ardından şifrelenmiş sunumu kaydetmek için `Save` yöntemini kullanın.

Bu örnek kod, bir sunumu nasıl şifreleyeceğinizi gösterir:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **Bir Sunuma Yazma Koruması Ayarlama** 

Sunuma “Değiştirmeyin” işareti ekleyebilirsiniz. Bu, kullanıcıların sunumu değiştirmesini istemediğinizi bildirir.

**Not:** Yazma koruma işlemi sunumu şifrelemez. Bu nedenle, kullanıcılar—isterlerse—sunumu değiştirebilir, fakat değişiklikleri kaydetmek için farklı bir adla kaydetmek zorunda kalırlar.

Yazma koruması ayarlamak için `SetWriteProtection` yöntemini kullanın. Bu örnek kod, bir sunuma yazma koruması nasıl ayarlanır gösterir:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **Şifrelenmiş Bir Sunumu Yükleme**

Aspose.Slides, doğru şifreyi geçirerek şifrelenmiş bir sunumu yüklemenize izin verir. Bu örnek kod, şifrelenmiş bir sunumu nasıl yükleyeceğinizi gösterir:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // Şifresi çözülmüş sunumla çalış.
}
```

## **Bir Sunumdan Şifrelemeyi Kaldırma**

Şifrelemeyi veya şifre korumasını bir sunumdan kaldırabilirsiniz; böylece kullanıcılar sunuma kısıtlama olmadan erişebilir veya değiştirebilir.

Şifrelemeyi veya şifre korumasını kaldırmak için [RemoveEncryption](https://reference.aspose.com/slides/tr/net/aspose.slides/protectionmanager/methods/removeencryption) yöntemini çağırın. Bu örnek kod, bir sunumdan şifrelemeyi nasıl kaldıracağınızı gösterir:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **Bir Sunumdan Yazma Korumasını Kaldırma**

Aspose.Slides kullanarak bir sunum dosyasından yazma korumasını kaldırabilirsiniz. Böylece kullanıcılar istedikleri gibi değiştirebilir ve bu görevleri gerçekleştirirken herhangi bir uyarı almazlar.

Yazma korumasını kaldırmak için [RemoveWriteProtection](https://reference.aspose.com/slides/tr/net/aspose.slides/protectionmanager/methods/removewriteprotection) yöntemini kullanın. Bu örnek kod, bir sunumdan yazma korumasını nasıl kaldıracağınızı gösterir:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **Şifreli Bir Sunumun Özelliklerini Alma**

Genellikle kullanıcılar şifreli veya şifreyle korunan bir sunumun belge özelliklerini almada zorlanırlar. Ancak Aspose.Slides, bir sunumu şifreyle korurken kullanıcıların hâlâ özelliklerine erişebilmesini sağlayan bir mekanizma sunar.

**Not:** Varsayılan olarak Aspose.Slides bir sunumu şifrelediğinde, sunumun belge özellikleri de şifre korumasına alınır. Belge özelliklerinin şifreleme sonrasında da erişilebilir olmasını istiyorsanız, Aspose.Slides bunu tam olarak yapmanıza izin verir.

Kullanıcıların şifreli bir sunumun özelliklerine erişebilmesini istiyorsanız, [IProtectionManager](https://reference.aspose.com/slides/tr/net/aspose.slides/iprotectionmanager/) arayüzünün `EncryptDocumentProperties` özelliğini `false` olarak ayarlayın. Bu örnek kod, şifreli bir sunumu belge özelliklerini hâlâ sunarken nasıl şifreleyeceğinizi gösterir:

```c#
using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Şifreli Bir Sunumdan Yalnızca Belge Özelliklerini Yükleme**

Sunumun slaytlarını veya diğer içeriğini yüklemeden şifreli bir sunumun meta verilerini incelemek için bir [LoadOptions](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/) nesnesi oluşturun ve `OnlyLoadDocumentProperties` özelliğini `true` olarak ayarlayın. Bu modda Aspose.Slides şifreyi görmezden gelir ve yalnızca genel olarak erişilebilir belge özelliklerini yükler.

Aşağıdaki kod örneği, [IPresentation.DocumentProperties](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/documentproperties/) aracılığıyla yerleşik ve özel belge özelliklerini okur:

```c#
var loadOptions = new LoadOptions
{
    OnlyLoadDocumentProperties = true
};

using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);
var documentProperties = presentation.DocumentProperties;

// Read built-in document properties.
Console.WriteLine("Title: " + documentProperties.Title);
Console.WriteLine("Author: " + documentProperties.Author);

// Read custom document properties.
var customPropertyCount = documentProperties.CountOfCustomProperties;

for (var propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    var propertyName = documentProperties.GetCustomPropertyName(propertyIndex);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine(propertyName + ": " + propertyValue);
}
```

Bu iş akışı yalnızca belge özellikleri şifrelenmemiş (halka açık) olduğunda çalışır. Belge özellikleri şifrelenmişse, `OnlyLoadDocumentProperties` değerini `true` yapmak bir istisna oluşturur çünkü bu modda şifre göz ardı edilir. Şifrelenmiş belge özelliklerine erişmek veya slaytlar ve diğer içerik dahil tam sunumu yüklemek için, [LoadOptions](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/) içinde doğru `Password` değerini sağlayın.

## **Bir Sunumun Şifreyle Korunduğunu Kontrol Etme**

Bir sunumu yüklemeden önce, şifreyle korunup korunmadığını kontrol etmek isteyebilirsiniz. Bu, şifre korumalı bir sunumu doğru şifre olmadan yüklemeye çalışırken ortaya çıkan hataları ve benzeri sorunları önlemenize yardımcı olur.

Bu C# kodu, bir sunumun şifreyle korunup korunmadığını aslında yüklemeden nasıl inceleyeceğinizi gösterir:

```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **Bir Sunumun Şifrelenip Şifrelenmediğini Kontrol Etme**

Aspose.Slides, bir sunumun şifrelenip şifrelenmediğini kontrol etmenizi sağlar. Bu işlemi gerçekleştirmek için, sunum şifreli ise `true`, değilse `false` döndüren [IsEncrypted](https://reference.aspose.com/slides/tr/net/aspose.slides/protectionmanager/properties/isencrypted) özelliğini kullanabilirsiniz.

Bu örnek kod, bir sunumun şifreli olup olmadığını nasıl kontrol edeceğinizi gösterir:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **Bir Sunumun Yazma Koruması Olup Olmadığını Kontrol Etme**

Aspose.Slides, bir sunumun yazma korumalı olup olmadığını kontrol etmenizi sağlar. Bu işlemi gerçekleştirmek için, sunum yazma korumalı ise `true`, değilse `false` döndüren [IsWriteProtected](https://reference.aspose.com/slides/tr/net/aspose.slides/protectionmanager/properties/iswriteprotected) özelliğini kullanabilirsiniz.

Bu örnek kod, bir sunumun yazma korumalı olup olmadığını nasıl kontrol edeceğinizi gösterir:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **Sunum Şifresi Kullanımını Doğrulama**

Belirli bir şifrenin bir sunum belgesini korumak için kullanılıp kullanılmadığını kontrol etmek ve onaylamak isteyebilirsiniz. Aspose.Slides, bir şifreyi doğrulamanız için gerekli araçları sunar.

Bu örnek kod, bir şifreyi nasıl doğrulayacağınızı gösterir:

```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // Şifrenin eşleşip eşleşmediğini kontrol edin.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

Şifre belirtilen şifre ile şifrelenmişse `true`, aksi takdirde `false` döndürür.

{{% alert color="primary" title="Ayrıca bakınız" %}} 
- [PowerPoint'ta Dijital İmza](/slides/tr/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Bir Sunumu Çevrimiçi Şifreyle Korumak**

1. **Aspose.Slides Lock** sayfamıza gidin. 
2. **Dosyalarınızı sürükleyin veya yükleyin** kısmına tıklayın. 
3. Bilgisayarınızdan şifrelemek istediğiniz dosyayı seçin. 
4. Düzenleme koruması için tercih ettiğiniz şifreyi ve görüntüleme koruması için tercih ettiğiniz şifreyi girin. 
5. Kullanıcıların sunumunuzu nihai kopya olarak görmesini istiyorsanız **Son olarak işaretle** kutusunu işaretleyin. 
6. **ŞİMDİ KORU** butonuna tıklayın. 
7. **ŞİMDİ İNDİR** butonuna tıklayın. 

![PowerPoint sunumlarını şifreyle koruma](slides-lock.png)

## **SSS**

**Aspose.Slides tarafından hangi şifreleme yöntemleri desteklenir?**

Aspose.Slides, AES tabanlı algoritmalar dahil olmak üzere modern şifreleme yöntemlerini destekler ve sunumlarınız için yüksek düzeyde veri güvenliği sağlar.

**Bir sunumu açmaya çalışırken yanlış bir şifre girilirse ne olur?**

Yanlış şifre kullanıldığında bir istisna oluşur ve sunuma erişimin reddedildiği bildirilir. Bu, yetkisiz erişimi önlemeye ve sunum içeriğini korumaya yardımcı olur.

**Şifreyle korunan sunumlarla çalışırken performans açısından bir etkisi var mı?**

Şifreleme ve şifre çözme işlemleri, açma ve kaydetme sırasında hafif bir ek yük oluşturabilir. Çoğu durumda bu performans etkisi çok küçüktür ve sunum görevlerinizin genel işlem süresini önemli ölçüde etkilemez.