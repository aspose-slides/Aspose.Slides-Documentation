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
- lisansı doğrula
- lisans dosyası
- değerlendirme sürümü
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te lisansları uygulayın, yönetin ve sorun gidermek için çözümler bulun. Adım adım lisanslama rehberimizle tam özelliklere kesintisiz erişimi sağlayın."
---
## **Genel Bakış**

Aspose.Slides, değerlendirme modunda veya geçerli bir lisansla kullanılabilir. Değerlendirme sürümü, lisanslı sürümle aynı işlevi sunar; ancak kaydettiği her sununun her slaytına bir değerlendirme filigranı ekler ve kodunuzun sunumlardan okuduğu metni kısaltır.

Bu makale, Aspose.Slides’ta lisanslamanın nasıl çalıştığını ve kütüphaneyi kullanmadan önce nasıl bir lisans uygulanacağını açıklar. Bir lisans, `License` sınıfı kullanılarak dosyadan, akıştan veya gömülü kaynaktan yüklenebilir. Makale ayrıca bir lisansın doğru şekilde uygulanıp uygulanmadığını doğrulamanın yollarını gösterir.

## **Aspose.Slides Değerlendirme**

{{% alert color="info" title="Not" %}}
**Aspose.Slides for .NET**’in bir değerlendirme sürümünü [its NuGet download page](https://www.nuget.org/packages/Aspose.Slides.NET/) adresinden indirebilirsiniz. Değerlendirme sürümü, ürünün lisanslı sürümüyle aynı işlevleri sağlar. Değerlendirme paketi, satın alınan paketle aynıdır. Değerlendirme sürümü, lisansı uygulamak için birkaç satır kod eklediğinizde lisanslı hâle gelir.
{{% /alert %}}

Değerlendirme sürecinizden memnun kaldığınızda **Aspose.Slides**’i [purchase a license](https://purchase.aspose.com/pricing/slides/tr/net/) ile lisanslayabilirsiniz. Farklı abonelik türlerine göz atmanızı öneririz. Sorularınız varsa Aspose satış ekibiyle iletişime geçin.

Her Aspose lisansı, abonelik süresi içinde ücretsiz yükseltmeler ve düzeltmeler alabileceğiniz bir yıllık abonelik içerir. Lisanslı ürünler ya da değerlendirme sürümleri sınırsız teknik destek alır.

**Değerlendirme sürümü sınırlamaları**
* Lisans belirtilmemiş değerlendirme sürümü, tam ürün işlevselliği sağlar, ancak kaydettiği her sununun her slaytına bir değerlendirme filigranı metin kutusu ekler.
* Kodunuzun bir sunumdan okuduğu metin, ilk birkaç karaktere kısaltılır ve değerlendirme sınırlaması hakkında bir uyarı eklenir. Kodunuzun yazdığı metin tam olarak kaydedilir.

{{% alert color="info" title="Not" %}}
Kısıtlamasız bir şekilde Aspose.Slides’ı test etmek isterseniz **30 Günlük Geçici Lisans** talep edebilirsiniz. Daha fazla bilgi için [How to get a Temporary License](https://purchase.aspose.com/temporary-license) sayfasına bakın.
{{% /alert %}}

## **Aspose.Slides’da Lisanslama**
* Değerlendirme sürümü, bir lisans satın alıp birkaç satır kod eklediğinizde lisanslı hâle gelir.
* Lisans, ürün adı, lisanslı geliştirici sayısı, abonelik bitiş tarihi gibi bilgileri içeren sade‑metin XML dosyasıdır.
* Lisans dosyası dijital olarak imzalıdır; dosyada herhangi bir ek satır boşluğu gibi değişiklik yapılmamalıdır, aksi takdirde lisans geçersiz olur.
* Aspose.Slides for .NET genellikle lisansı şu konumlardan bulmaya çalışır:
  * Açık bir yol
  * Bileşenin DLL dosyasının bulunduğu klasör (Aspose.Slides içinde)
  * Bileşenin DLL dosyasını çağıran derlemenin bulunduğu klasör (Aspose.Slides içinde)
  * Giriş derlemesinin (exe) bulunduğu klasör
  * Bileşenin DLL dosyasını çağıran derlemede gömülü bir kaynak (Aspose.Slides içinde)
* Değerlendirme sürümüne ait sınırlamaları aşmak için Aspose.Slides’ı kullanmadan önce bir lisans ayarlamanız gerekir. Bir uygulama ya da süreç için lisansı yalnızca bir kez ayarlamanız yeterlidir.

{{% alert color="info" title="Not" %}}
[Metered Licensing](/slides/tr/net/metered-licensing/) sayfasına göz atmak isteyebilirsiniz.
{{% /alert %}}

## **Lisans Uygulama**
Bir lisans **dosyadan**, **akıştan** veya **gömülü kaynaktan** yüklenebilir.

{{% alert color="info" title="Not" %}}
Aspose.Slides, lisanslama işlemleri için [License](https://reference.aspose.com/slides/tr/net/aspose.slides/license) sınıfını sağlar.
{{% /alert %}}

{{% alert color="warning" title="Uyarı" %}}
Yeni lisanslar, yalnızca 21.4 veya sonraki sürümlerde Aspose.Slides’ı etkinleştirir. Daha eski sürümler farklı bir lisanslama sistemi kullanır ve bu lisansları tanımaz.
{{% /alert %}}

### **Dosya**
Lisans ayarlamanın en kolay yöntemi, lisans dosyasını bileşenin DLL (Aspose.Slides içinde) ile aynı klasöre koymak ve yalnızca dosya adını, yol olmadan belirtmektir.

Bu C# kodu, bir lisans dosyasının nasıl ayarlanacağını gösterir:

``` csharp
// License sınıfını örnekler 
Aspose.Slides.License license = new Aspose.Slides.License();

// Lisans dosyası yolunu ayarlar
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" title="Uyarı" %}}
Lisans dosyasını farklı bir dizine koyarsanız, [SetLicense](https://reference.aspose.com/slides/tr/net/aspose.slides/license/setlicense/#setlicense_1) yöntemini çağırdığınızda belirtilen yolun sonundaki lisans dosyası adı, gerçek lisans dosyası adınızla aynı olmalıdır.

Örneğin, lisans dosyası adını *Aspose.Slides.lic.xml* olarak değiştirirseniz, kodunuzda dosya yolunu (sonu *Aspose.Slides.lic.xml* olacak şekilde) [SetLicense](https://reference.aspose.com/slides/tr/net/aspose.slides/license/setlicense/#setlicense_1) metoduna geçirmeniz gerekir.
{{% /alert %}}

### **Akış**
Bir lisansı bir akıştan yükleyebilirsiniz. Bu C# kodu, bir akıştan lisans uygulamanın nasıl yapılacağını gösterir:

``` csharp
// License sınıfını örnekler
Aspose.Slides.License license = new Aspose.Slides.License();

// Lisans dosyasını akış olarak açar
using FileStream licenseStream = File.OpenRead("Aspose.Slides.lic");

// Lisansı bir akış üzerinden ayarlar
license.SetLicense(licenseStream);
```

### **Gömülü Kaynak**
Lisansı uygulamanızla birlikte paketleyerek (kayıp olmasını önlemek için) bileşenin DLL dosyasını çağıran derlemelerden birine gömülü kaynak olarak ekleyebilirsiniz.

Lisans dosyasını gömülü kaynak olarak ekleme adımları:

1. Visual Studio’da, lisans (.lic) dosyasını projeye ekleyin: **File** > **Add Existing Item** > **Add** yolunu izleyin.  
2. Dosyayı **Solution Explorer** içinde seçin.  
3. **Properties** penceresinde **Build Action** değerini **Embedded Resource** olarak ayarlayın.  
4. Derlemede gömülü lisansa erişmek için lisans dosyasını gömülü kaynak olarak projeye ekleyin ve `SetLicense` metoduna lisans dosyası adını aktarın.  

`License` sınıfı, gömülü kaynaklarda lisans dosyasını otomatik olarak bulur. Microsoft .NET Framework’te `System.Reflection.Assembly` sınıfının `GetExecutingAssembly` ve `GetManifestResourceStream` metodlarını çağırmanıza gerek yoktur.

Bu C# kodu, lisansın gömülü kaynak olarak nasıl ayarlanacağını gösterir:

``` csharp
// License sınıfını örnekler
Aspose.Slides.License license = new Aspose.Slides.License();

// Derlemede gömülü lisans dosyası adını iletir
license.SetLicense("Aspose.Slides.lic");
```

## **Lisansı Doğrulama**

Bir lisansın doğru şekilde ayarlanıp ayarlanmadığını kontrol etmek için doğrulayabilirsiniz. Bu C# kodu, bir lisansı nasıl doğrulayacağınızı gösterir:

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

{{% alert color="warning" title="Uyarı" %}}
[license.SetLicense](https://reference.aspose.com/slides/tr/net/aspose.slides/license/setlicense/) metodu iş parçacığı güvenli değildir. Bu yöntem birden çok iş parçacığından aynı anda çağrılacaksa, sorunları önlemek için bir kilit gibi senkronizasyon ilkelileri kullanmanız önerilir.
{{% /alert %}}

## **SSS**

### Lisansı tamamen çevrim dışı bir ortamda (internet erişimi olmadan) uygulayabilir miyim?

Evet. Lisans doğrulaması yerel olarak lisans dosyasıyla yapılır; internet bağlantısı gerekmez.

### Bir yıllık abonelik süresi dolduğunda ne olur? Kütüphane çalışmayı durdurur mu?

Hayır. Lisans kalıcıdır: abonelik bitiş tarihinizden önce yayımlanan sürümleri kullanmaya devam edebilirsiniz; ancak yenilerini kullanmak için lisans yenilemeniz gerekir.