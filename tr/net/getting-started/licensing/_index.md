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
description: "Aspose.Slides for .NET içinde lisansları uygulama, yönetme ve sorun giderme. Adım adım lisanslama rehberimizle tam özelliklere kesintisiz erişimi sağlayın."
---
## **Genel Bakış**

Aspose.Slides değerlendirme modunda veya geçerli bir lisansla kullanılabilir. Değerlendirme sürümü, lisanslı sürümle aynı işlevselliği sağlar, ancak sunumlar açıldığında veya kaydedildiğinde bir değerlendirme filigranı ekler ve metin çıkarımını bir slayt ile sınırlar.

Bu makale Aspose.Slides'te lisanslamanın nasıl çalıştığını ve kütüphaneyi kullanmadan önce nasıl lisans uygulanacağını açıklar. Bir lisans, `License` sınıfı kullanılarak bir dosyadan, akıştan veya gömülü kaynaktan yüklenebilir. Makale ayrıca bir lisansın doğru bir şekilde uygulanıp uygulanmadığını nasıl doğrulayacağınızı gösterir.

## **Aspose.Slides'i Değerlendirin**

{{% alert color="info" %}} 

**Aspose.Slides for NET**'in bir değerlendirme sürümünü [NuGet indirme sayfası](https://www.nuget.org/packages/Aspose.Slides.NET/) üzerinden indirebilirsiniz. Değerlendirme sürümü, ürünün lisanslı sürümüyle aynı işlevselliği sunar. Değerlendirme paketi, satın alınan paketle aynı içeriktedir. Değerlendirme sürümü, lisansı uygulamak için birkaç satır kod eklediğinizde lisanslı hâle gelir.

**Aspose.Slides** değerlendirmesinden memnun kaldığınızda, [lisans satın alabilirsiniz](https://purchase.aspose.com/buy). Farklı abonelik tiplerini incelemenizi öneririz. Sorularınız olduğunda Aspose satış ekibiyle iletişime geçin.

Her Aspose lisansı, abonelik süresi içinde yayınlanan yeni sürümler ve düzeltmeler için ücretsiz bir yıllık yükseltme aboneliği içerir. Lisanslı ürünleri veya hatta değerlendirme sürümlerini kullananlar, ücretsiz ve sınırsız teknik destek alır.

{{% /alert %}} 

**Değerlendirme sürümü sınırlamaları**

* Aspose.Slides değerlendirme sürümü (lisans belirtilmediğinde) tam ürün işlevselliği sağlarken, belgeyi açma ve kaydetme işlemlerinde belgenin üst kısmına bir değerlendirme filigranı ekler. 
* Sunum slaytlarından metin çıkarırken bir slayt ile sınırlısınız.

{{% alert color="info" %}} 

Sınırlamaları olmayan bir biçimde Aspose.Slides'i test etmek isterseniz **30 Günlük Geçici Lisans** talep edebilirsiniz. Daha fazla bilgi için [Geçici Lisans Nasıl Alınır](https://purchase.aspose.com/temporary-license) sayfasına bakın.

{{% /alert %}}

## **Aspose.Slides Lisanslama**
* Değerlendirme sürümü, lisans satın alındıktan ve birkaç satır kod eklendikten sonra lisanslı hâle gelir.
* Lisans, ürün adı, lisanslanan geliştirici sayısı, abonelik sona erme tarihi vb. bilgileri içeren düz metin bir XML dosyasıdır. 
* Lisans dosyası dijital olarak imzalanmıştır; dosyayı değiştirmemelisiniz. Dosya içeriğine istemeden bir satır sonu eklemek bile lisansı geçersiz kılar.
* Aspose.Slides for .NET genellikle lisansı şu konumlardan bulur:
  * Açık bir yol
  * Bileşenin DLL'sini içeren klasör (Aspose.Slides içinde bulunur)
  * Bileşenin DLL'sini çağıran derlemenin bulunduğu klasör (Aspose.Slides içinde bulunur)
  * Çalışma giriş derlemini (exe dosyanızı) içeren klasör
  * Bileşenin DLL'sini çağıran derlemede gömülü kaynak (Aspose.Slides içinde bulunur).
* Değerlendirme sürümüne bağlı sınırlamaları ortadan kaldırmak için Aspose.Slides'i kullanmadan önce bir lisans ayarlamalısınız. Bir uygulama veya işlem başına yalnızca bir kez lisans ayarlamanız gerekir.

{{% alert color="info" %}} 

[Metered Licensing](https://docs.aspose.com/slides/tr/net/metered-licensing/) sayfasına göz atabilirsiniz.

{{% /alert %}} 


## **Lisansı Uygula**
Bir lisans **dosyadan**, **akıştan** veya **gömülü kaynaktan** yüklenebilir. 

{{% alert color="info" %}}

Aspose.Slides lisanslama işlemleri için [License](https://reference.aspose.com/slides/tr/net/aspose.slides/license) sınıfını sağlar.

{{% /alert %}} 

{{% alert color="warning" %}} 

Yeni lisanslar sadece 21.4 veya sonraki sürümle Aspose.Slides'i etkinleştirebilir. Daha eski sürümler farklı bir lisanslama sistemi kullanır ve bu lisansları tanımaz.

{{% /alert %}}

### **Dosya**
Lisans ayarlamanın en kolay yöntemi, lisans dosyasını bileşenin DLL'sinin bulunduğu aynı klasöre (Aspose.Slides içinde) koymak ve sadece dosya adını, yol olmaksızın belirtmektir.

Bu C# kodu bir lisans dosyasının nasıl ayarlanacağını gösterir:

``` csharp
// License sınıfını örnekler 
Aspose.Slides.License license = new Aspose.Slides.License();

// Lisans dosyası yolunu ayarlar
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

Lisans dosyasını farklı bir klasöre koyarsanız, [SetLicense](https://reference.aspose.com/slides/tr/net/aspose.slides/license/setlicense/#setlicense_1) yöntemini çağırdığınızda belirtilen açık yolun sonunda yer alan lisans dosyası adı, mevcut lisans dosyanızla aynı olmalıdır.

Örneğin, lisans dosyası adını *Aspose.Slides.lic.xml* olarak değiştirebilirsiniz. Ardından kodunuzda, dosya yolunu (*Aspose.Slides.lic.xml* ile biten) [SetLicense](https://reference.aspose.com/slides/tr/net/aspose.slides/license/setlicense/#setlicense_1) yöntemine geçirmeniz gerekir.

{{% /alert %}}

### **Akış**
Lisans bir akıştan da yüklenebilir. Bu C# kodu bir lisansın akıştan nasıl uygulanacağını gösterir:

``` csharp
// License sınıfını örnekler
Aspose.Slides.License license = new Aspose.Slides.License();

// Lisans dosyasını akış olarak açar
using FileStream licenseStream = File.OpenRead("Aspose.Slides.lic");

// Lisansı bir akış üzerinden ayarlar
license.SetLicense(licenseStream);
```

### **Gömülü Kaynak**
Lisansı uygulamanızla birlikte paketleyerek (kayıp olmaması için) bileşenin DLL'sini çağıran derlemelerden birine gömülü kaynak olarak ekleyebilirsiniz. 

Lisans dosyasını gömülü kaynak olarak eklemek için şu adımları izleyin:

1. Visual Studio’da, lisans (.lic) dosyasını projeye **File** > **Add Existing Item** > **Add** yolunu izleyerek ekleyin. 
2. Dosyayı **Solution Explorer** içinde seçin.
3. **Properties** penceresinde **Build Action** özelliğini **Embedded Resource** olarak ayarlayın.
4. Assembly içinde gömülü lisansa erişmek için, lisans dosyasını projeye gömülü kaynak olarak ekleyin ve ardından lisans dosyası adını `SetLicense` yöntemine geçirin. 

`License` sınıfı gömülü kaynaklardaki lisans dosyasını otomatik olarak bulur. Microsoft .NET Framework içinde `System.Reflection.Assembly` sınıfının `GetExecutingAssembly` ve `GetManifestResourceStream` yöntemlerini çağırmanıza gerek yoktur.

Bu C# kodu bir lisansın gömülü kaynak olarak nasıl ayarlanacağını gösterir:

``` csharp
// License sınıfını örnekler
Aspose.Slides.License license = new Aspose.Slides.License();

// Derlemeye gömülü lisans dosyası adını geçirir
license.SetLicense("Aspose.Slides.lic");
```

## **Lisansı Doğrulama**

Bir lisansın doğru ayarlanıp ayarlanmadığını kontrol etmek için doğrulama yapabilirsiniz. Bu C# kodu bir lisansın nasıl doğrulanacağını gösterir:

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

[license.SetLicense](https://reference.aspose.com/slides/tr/net/aspose.slides/license/setlicense/) yöntemi iş parçacığı güvenli değildir. Bu yöntem birçok iş parçacığından aynı anda çağrılması gerekiyorsa, sorunları önlemek için bir kilit gibi senkronizasyon primi­tifleri kullanmanız önerilir. 

{{% /alert %}}

## **SSS**

### Lisansı tamamen çevrim dışı bir ortamda (internet erişimi olmadan) uygulayabilir miyim?

Evet. Lisans doğrulaması, lisans dosyası kullanılarak yerel olarak yapılır; internet bağlantısına ihtiyaç yoktur.

### Bir yıllık abonelik sona erdiğinde ne olur? Kütüphane çalışmayı durdurur mu?

Hayır. Lisans süresizdir: abonelik bitiş tarihinizden önce yayınlanan sürümleri kullanmaya devam edebilirsiniz; yalnızca yenileme yapmazsanız daha yeni sürümleri kullanamazsınız.