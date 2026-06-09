---
title: Lisanslama
type: docs
weight: 80
url: /tr/net/licensing/
keywords:
- lisans
- geçici lisans
- lisans ayarla
- lisans kullan
- lisans doğrula
- lisans dosyası
- değerlendirme sürümü
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te lisansları uygulayın, yönetin ve sorun giderin. Adım adım lisanslama rehberimizle tam özelliklere kesintisiz erişimi sağlayın."
---
## **Genel Bakış**

Aspose.Slides değerlendirme modunda veya geçerli bir lisansla kullanılabilir. Değerlendirme sürümü, lisanslı sürümle aynı işlevselliği sağlar, ancak sunumlar açıldığında veya kaydedildiğinde bir değerlendirme filigranı ekler ve metin çıkarımını bir slaytla sınırlar.

Bu makale, Aspose.Slides'te lisanslamanın nasıl çalıştığını ve kütüphaneyi kullanmadan önce nasıl lisans uygulanacağını açıklar. Lisans, `License` sınıfı kullanılarak bir dosya, akış ya da gömülü kaynak üzerinden yüklenebilir. Makale ayrıca lisansın doğru bir şekilde uygulanıp uygulanmadığını nasıl doğrulayacağınızı gösterir.

## **Aspose.Slides'ı Değerlendirin**

{{% alert color="primary" %}} 

Bir değerlendirme sürümünü **Aspose.Slides for NET**'i [NuGet indirme sayfasından](https://www.nuget.org/packages/Aspose.Slides.NET/) indirebilirsiniz. Değerlendirme sürümü, ürünün lisanslı sürümüyle aynı işlevselliği sağlar. Değerlendirme paketi, satın alınan paketle aynıdır. Değerlendirme sürümü, birkaç kod satırı ekleyip lisansı uyguladıktan sonra basitçe lisanslı hâle gelir.

Aspose.Slides değerlendirmesinden memnun kaldığınızda, bir [lisans satın alabilirsiniz](https://purchase.aspose.com/buy). Farklı abonelik türlerine göz atmanızı öneririz. Sorularınız varsa, Aspose satış ekibiyle iletişime geçin.

Her Aspose lisansı, abonelik süresi içinde yayınlanan yeni sürüm ve düzeltmelere ücretsiz yükseltme sağlayan bir yıllık abonelik içerir. Lisanslı ürünlere sahip kullanıcılar ya da değerlendirme sürümünü kullananlar ücretsiz ve sınırsız teknik destek alır.

{{% /alert %}} 

**Değerlendirme sürümü sınırlamaları**

* Lisans belirtilmemiş Aspose.Slides değerlendirme sürümü tam ürün işlevselliği sağlarken, açma ve kaydetme işlemlerinde belgenin üst kısmına bir değerlendirme filigranı ekler.
* Sunum slaytlarından metin çıkarırken yalnızca bir slaytla sınırlısınız.

{{% alert color="primary" %}} 

Aspose.Slides'ı sınırlamaları olmadan test etmek için **30 Günlük Geçici Lisans** talep edebilirsiniz. Daha fazla bilgi için [Geçici Lisans nasıl alınır](https://purchase.aspose.com/temporary-license) sayfasına bakın.

{{% /alert %}}

## **Aspose.Slides'te Lisanslama**
* Bir değerlendirme sürümü, bir lisans satın alındıktan ve birkaç kod satırı eklenerek (lisansı uygulamak için) lisanslı hâle gelir.
* Lisans, ürün adı, lisanslı geliştirici sayısı, abonelik bitiş tarihi gibi ayrıntıları içeren düz metin XML dosyasıdır.
* Lisans dosyası dijital olarak imzalanmıştır, bu yüzden dosyayı değiştirmemelisiniz. Dosyaya fazladan bir satır sonu eklenmesi bile lisansı geçersiz kılar.
* Aspose.Slides for .NET genellikle lisansı şu konumlarda arar:
  * Açık bir yol
  * Bileşenin DLL'ini içeren klasör (Aspose.Slides içinde dahil edilir)
  * Bileşenin DLL'ini çağıran derlemenin bulunduğu klasör (Aspose.Slides içinde dahil edilir)
  * Giriş derlemesini (exe dosyanızı) içeren klasör
  * Bileşenin DLL'ini çağıran derlemede gömülü kaynak (Aspose.Slides içinde dahil edilir).
* Değerlendirme sürümüyle ilişkili sınırlamalardan kaçınmak için Aspose.Slides'ı kullanmadan önce bir lisans ayarlamanız gerekir. Bir uygulama ya da süreç için lisansı yalnızca bir kez ayarlamanız yeterlidir.

{{% alert color="primary" %}} 

İsterseniz [Ölçülü Lisanslama](https://docs.aspose.com/slides/tr/net/metered-licensing/) sayfasına göz atabilirsiniz.

{{% /alert %}} 


## **Lisans Uygulama**
Lisans, bir **dosyadan**, **akıştan** veya **gömülü kaynaktan** yüklenebilir. 

{{% alert color="primary" %}}

Aspose.Slides, lisanslama işlemleri için [License](https://reference.aspose.com/slides/tr/net/aspose.slides/license) sınıfını sağlar.

{{% /alert %}} 

{{% alert color="warning" %}} 

Yeni lisanslar yalnızca 21.4 veya daha sonraki sürümde Aspose.Slides'ı etkinleştirebilir. Daha eski sürümler farklı bir lisanslama sistemi kullanır ve bu lisansları tanımaz.

{{% /alert %}}

### **Dosya**
Lisans ayarlamanın en kolay yöntemi, lisans dosyasını bileşenin DLL'inin (Aspose.Slides içinde dahil) bulunduğu aynı klasöre koymayı ve yalnızca dosya adını, yol olmadan belirtmeyi gerektirir.

Bu C# kodu, bir lisans dosyasının nasıl ayarlanacağını gösterir:

``` csharp
// Lisans sınıfını örnekler 
Aspose.Slides.License license = new Aspose.Slides.License();

// Lisans dosyası yolunu ayarlar
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

Lisans dosyasını farklı bir dizine koyarsanız, [SetLicense](https://reference.aspose.com/slides/tr/net/aspose.slides/license/setlicense/#setlicense_1) yöntemini çağırdığınızda, belirtilen açık yolun sonunda yer alan lisans dosyası adı lisans dosyanızla aynı olmalıdır.

Örneğin, lisans dosyası adını *Aspose.Slides.lic.xml* olarak değiştirebilirsiniz. Ardından, kodunuzda [SetLicense](https://reference.aspose.com/slides/tr/net/aspose.slides/license/setlicense/#setlicense_1) yöntemine dosya yolunu ( *Aspose.Slides.lic.xml* ile biten) vermeniz gerekir.

{{% /alert %}}

### **Akış**
Bir lisansı akıştan yükleyebilirsiniz. Bu C# kodu, bir akıştan lisans nasıl uygulanır gösterir:

``` csharp
// Lisans sınıfını örnekler 
Aspose.Slides.License license = new Aspose.Slides.License();

// Lisansı bir akış üzerinden ayarlar
license.SetLicense(myStream);
```

### **Gömülü Kaynak**
Lisansı, bileşenin DLL'ini çağıran derlemelerden birine gömülü kaynak olarak ekleyerek uygulamanızla birlikte paketleyebilir (kaybolmasını önlemek için). 

Lisans dosyasını gömülü kaynak olarak ekleme yöntemi şu şekildedir:

1. Visual Studio'da, lisans (.lic) dosyasını projeye şu şekilde ekleyin: **File** > **Add Existing Item** > **Add** menüsüne gidin.
2. **Solution Explorer** içinde dosyayı seçin.
3. **Properties** penceresinde, **Build Action** değerini **Embedded Resource** olarak ayarlayın.
4. Derlemede gömülü lisansa erişmek için lisans dosyasını projeye gömülü kaynak olarak ekleyin ve ardından lisans dosyası adını `SetLicense` yöntemine geçirin. 


`License` sınıfı, lisans dosyasını gömülü kaynaklarda otomatik olarak bulur. Microsoft .NET Framework'te `System.Reflection.Assembly` sınıfının `GetExecutingAssembly` ve `GetManifestResourceStream` yöntemlerini çağırmanıza gerek yoktur.

Bu C# kodu, bir lisansı gömülü kaynak olarak nasıl ayarlayacağınızı gösterir:

``` csharp
// Lisans sınıfını örnekler
Aspose.Slides.License license = new Aspose.Slides.License();

// Derlemede gömülü olan lisans dosyası adını aktarır
license.SetLicense("Aspose.Slides.lic");
```

## **Lisansı Doğrulama**

Bir lisansın doğru bir şekilde ayarlanıp ayarlanmadığını kontrol etmek için onu doğrulayabilirsiniz. Bu C# kodu, bir lisansın nasıl doğrulanacağını gösterir:

```c#
Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");

if (license.IsLicensed())
{
    Console.WriteLine("License is good!");
    Console.Read();
}
```

## **İş Parçacığı Güvenliği**

{{% alert title="Note" color="warning" %}} 

[license.SetLicense](https://reference.aspose.com/slides/tr/net/aspose.slides/license/setlicense/) yöntemi iş parçacığı güvenli değildir. Bu yöntem birden çok iş parçacığından aynı anda çağrılması gerekiyorsa, sorunları önlemek için bir kilit gibi senkronizasyon primiitiflerini kullanmak isteyebilirsiniz. 

{{% /alert %}}

## **Sıkça Sorulan Sorular**

**Lisansı tamamen çevrim dışı bir ortamda (internet erişimi olmadan) uygulayabilir miyim?**

Evet. Lisans doğrulaması, lisans dosyası kullanılarak yerel olarak yapılır; internet bağlantısı gerekmez.

**Bir yıllık abonelik sona erdiğinde ne olur? Kütüphane çalışmayı durdurur mu?**

Hayır. Lisans süresizdir: abonelik bitiş tarihinizden önce yayınlanan sürümleri kullanmaya devam edebilirsiniz; ancak yenilerini kullanmak için yenilemeniz gerekir.