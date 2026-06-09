---
title: Lisanslama
type: docs
weight: 120
url: /tr/cpp/licensing/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'ta lisansları uygulayın, yönetin ve sorun giderin. Adım adım lisans rehberimizle tam özelliklere kesintisiz erişimi sağlayın."
---
## **Genel Bakış**

Aspose.Slides, değerlendirme modunda veya geçerli bir lisansla kullanılabilir. Değerlendirme sürümü, lisanslı sürümle aynı işlevselliği sunar, ancak sunumlar açıldığında veya kaydedildiğinde bir değerlendirme filigranı ekler ve metin çıkarımını bir slayt ile sınırlandırır.

Bu makale, Aspose.Slides'te lisanslamanın nasıl çalıştığını ve kütüphaneyi kullanmadan önce nasıl bir lisans uygulanacağını açıklar. Bir lisans, `License` sınıfı kullanılarak bir dosyadan, akıştan veya gömülü kaynaktan yüklenebilir. Makale ayrıca bir lisansın doğru şekilde uygulanıp uygulanmadığını nasıl doğrulayacağınızı gösterir.

## **Aspose.Slides'ı Değerlendirin**

{{% alert color="primary" %}} 

**Aspose.Slides for C++**'nin bir değerlendirme sürümünü [NuGet indirme sayfasından](https://www.nuget.org/packages/Aspose.Slides.CPP/) indirebilirsiniz. Değerlendirme sürümü, lisanslı ürünle aynı işlevselliği sunar. Aslında, değerlendirme paketi satın alınan paketle aynıdır—sadece lisansı uygulamak için birkaç satır kod eklediğinizde lisanslı olur.

**Aspose.Slides**'i değerlendirmesinden memnun kaldığınızda, [bir lisans satın alabilirsiniz](https://purchase.aspose.com/buy). Mevcut abonelik türlerini incelemenizi öneririz. Herhangi bir sorunuz olursa, Aspose satış ekibiyle iletişime geçmekten çekinmeyin.

Her Aspose lisansı, bu süre içinde yayınlanan yeni sürümler ve hata düzeltmeleri dahil olmak üzere ücretsiz yükseltmeler için bir yıllık bir abonelik içerir. Lisanslı ya da değerlendirme sürümü kullanıyor olsanız da ücretsiz ve sınırsız teknik destek alırsınız.

{{% /alert %}} 

**Değerlendirme Sürümü Sınırlamaları**

* Aspose.Slides değerlendirme sürümü (lisans uygulanmadığında) tam ürün işlevselliği sağlar, ancak açma ve kaydetme işlemleri sırasında belgenin üst kısmına bir değerlendirme filigranı ekler.
* Değerlendirme sürümü kullanılırken metin çıkarımı bir slayt ile sınırlıdır.

{{% alert color="primary" %}} 

Aspose.Slides'ı sınırlamalar olmadan test etmek için **30 Günlük Geçici Lisans** talep edebilirsiniz. Daha fazla bilgi için [Geçici Lisans Nasıl Alınır](https://purchase.aspose.com/temporary-license) sayfasına bakın.

{{% /alert %}}

## **Aspose.Slides'te Lisanslama**

* Bir değerlendirme sürümü, bir lisans satın alıp birkaç satır kod ekleyerek lisansı uyguladığınızda lisanslı hale gelir.
* Lisans, ürün adı, lisanslı olduğu geliştirici sayısı, abonelik son tarihi ve diğer detayları içeren düz metin XML dosyasıdır.
* Lisans dosyası dijital olarak imzalanmıştır, bu yüzden değiştirilmemelidir. Bir satır sonu eklemek gibi kazara bir değişiklik bile dosyayı geçersiz kılar.
* Aspose.Slides for C++ genellikle lisans dosyasını aşağıdaki konumlarda arar:
  * Kodunuzda açıkça belirtilen bir yol
  * Bileşenin DLL'sini (Aspose.Slides içinde) içeren klasör
  * Bileşenin DLL'sini çağıran assembly'nin bulunduğu klasör
* Değerlendirme sürümünün sınırlamalarından kaçınmak için, Aspose.Slides'ı kullanmadan önce lisansı ayarlamalısınız. Bir lisans, uygulama ya da süreç başına yalnızca bir kez ayarlanması gerekir.

## **Lisansı Uygula**

Bir lisans **dosyadan**, **akıştan** veya **gömülü kaynaktan** yüklenebilir.

{{% alert color="primary" %}}

Aspose.Slides, lisans işlemleri için [License](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.license/) sınıfını sunar.

{{% /alert %}} 

{{% alert color="warning" %}}

Yeni lisanslar, Aspose.Slides'ı yalnızca 21.4 veya daha sonraki sürümde etkinleştirebilir. Daha eski sürümler farklı bir lisans sistemine sahiptir ve bu lisansları tanımaz.

{{% /alert %}}

### **Dosya**

Lisans ayarlamanın en kolay yolu, lisans dosyasını bileşenin DLL'si ile aynı klasöre (Aspose.Slides içinde) koymak ve sadece dosya adını, yolu belirtmeden vermektir. Aşağıdaki C++ kodu, bir lisans dosyasının nasıl ayarlanacağını gösterir:

```c++
#include <Util/License.h>

using namespace Aspose::Slides;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

{{% alert color="warning" %}}

Lisans dosyasını farklı bir dizine koyarsanız, [License::SetLicense](https://reference.aspose.com/slides/tr/cpp/aspose.slides/license/setlicense/) yöntemini çağırdığınızda, belirtilen açık yolun sonundaki dosya adı lisans dosyanızın adıyla tam olarak eşleşmelidir.

Örneğin, lisans dosyanızın adını *Aspose.Slides.lic.xml* olarak değiştirirseniz, kodunuzda [License::SetLicense](https://reference.aspose.com/slides/tr/cpp/aspose.slides/license/setlicense/) yöntemine *Aspose.Slides.lic.xml* ile biten tam yolu geçirmeniz gerekir.

{{% /alert %}}

### **Akış**

Bir lisansı bir akıştan yükleyebilirsiniz. Aşağıdaki C++ kodu, bir akıştan lisansın nasıl uygulanacağını gösterir:

```c++
auto license = MakeObject<License>();

auto stream = File::OpenRead(u"Aspose.Slides.lic");

license->SetLicense(stream);
```

## **Lisansı Doğrulama**

Bir lisansın doğru şekilde ayarlanıp ayarlanmadığını kontrol etmek için doğrulayabilirsiniz. Aşağıdaki C++ kodu, bir lisansın nasıl doğrulanacağını gösterir:

```c++
auto license = MakeObject<License>();

license->SetLicense(u"Aspose.Slides.lic");

if (license->IsLicensed())
{
    Console::WriteLine(u"License is good!");
    Console::ReadKey();
}
```

## **İş Parçacığı Güvenliği**

{{% alert title="Note" color="warning" %}} 

[License::SetLicense](https://reference.aspose.com/slides/tr/cpp/aspose.slides/license/setlicense/) yöntemi **iş parçacığı güvenli değildir**. Bu yöntemi aynı anda birden çok iş parçacığından çağırmanız gerekiyorsa, olası sorunları önlemek için bir kilit gibi eşzamanlama primitiflerini kullanmanız önerilir.

{{% /alert %}}

## **SSS**

**Lisansı tamamen çevrim dışı bir ortamda (internet erişimi olmadan) uygulayabilir miyim?**

Evet. Lisans doğrulaması, lisans dosyası kullanılarak yerel olarak gerçekleştirilir; internet bağlantısı gerekmez.

**Bir yıllık abonelik sona erdiğinde ne olur? Kütüphane çalışmayı durdurur mu?**

Hayır. Lisans süresizdir: abonelik bitiş tarihinizden önce yayınlanan sürümleri kullanmaya devam edebilirsiniz; ancak yenilerini kullanmak için yenileme yapmanız gerekir.