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
description: "Aspose.Slides for C++'de lisansları uygulayın, yönetin ve sorun giderin. Adım adım lisanslama rehberimizle tam özelliklere kesintisiz erişimi sağlayın."
---
## **Genel Bakış**

Aspose.Slides, değerlendirme modunda veya geçerli bir lisansla kullanılabilir. Değerlendirme sürümü, lisanslı sürümle aynı işlevselliği sağlar, ancak sunumlar açıldığında veya kaydedildiğinde bir değerlendirme filigranı ekler ve metin çıkarımını bir slaytla sınırlar.

Bu makale, Aspose.Slides'da lisanslamanın nasıl çalıştığını ve kütüphaneyi kullanmadan önce bir lisansın nasıl uygulanacağını açıklar. Bir lisans, `License` sınıfı kullanılarak dosyadan, akıştan veya gömülü kaynaktan yüklenebilir. Makale ayrıca bir lisansın doğru şekilde uygulanıp uygulanmadığını nasıl doğrulayacağınızı da gösterir.

## **Aspose.Slides'ı Değerlendirin**

{{% alert color="info" %}} 

**Aspose.Slides for C++**'ın bir değerlendirme sürümünü [its NuGet download page](https://www.nuget.org/packages/Aspose.Slides.CPP/) üzerinden indirebilirsiniz. Değerlendirme sürümü, lisanslı ürünle aynı işlevselliği sunar. Aslında, değerlendirme paketi satın alınan paketle özdeştir—sadece lisansı uygulamak için birkaç satır kod eklediğinizde lisanslı hâle gelir.

**Aspose.Slides**'ı değerlendirmeden memnun kaldığınızda, [purchase a license](https://purchase.aspose.com/buy) sayfasından bir lisans satın alabilirsiniz. Kullanılabilir abonelik tiplerini gözden geçirmenizi öneririz. Herhangi bir sorunuz olursa, lütfen Aspose satış ekibiyle iletişime geçin.

Her Aspose lisansı, bu süre içinde yayınlanan yeni sürümler ve hata düzeltmeleri dahil olmak üzere ücretsiz yükseltmeler için bir yıllık abonelik içerir. Lisanslı veya değerlendirme sürümünü kullanıyor olsanız da ücretsiz ve sınırsız teknik destek alırsınız.

{{% /alert %}} 

**Değerlendirme Sürümü Kısıtlamaları**

* Aspose.Slides değerlendirme sürümü (lisans uygulanmadığında) tam ürün işlevselliği sunsa da, belgeyi açma ve kaydetme işlemleri sırasında belgenin üst kısmına bir değerlendirme filigranı ekler.
* Değerlendirme sürümünü kullanırken metin çıkarımı bir slaytla sınırlıdır.

{{% alert color="info" %}} 

Sınırlamaları olmadan Aspose.Slides'ı test etmek için **30 Günlük Geçici Lisans** talep edebilirsiniz. Daha fazla bilgi için [How to Get a Temporary License](https://purchase.aspose.com/temporary-license) sayfasına bakın.

{{% /alert %}}

## **Aspose.Slides'da Lisanslama**

* Bir değerlendirme sürümü, bir lisans satın alındıktan ve birkaç satır kod eklenerek uygulandıktan sonra lisanslı hâle gelir.
* Lisans, ürün adı, lisans verilen geliştirici sayısı, abonelik sona erme tarihi vb. detayları içeren düz metin XML dosyasıdır.
* Lisans dosyası dijital olarak imzalanmıştır; bu nedenle değiştirilemez. Bir satır sonu eklenmesi gibi tesadüfi bir değişiklik bile dosyayı geçersiz kılar.
* Aspose.Slides for C++ genellikle lisans dosyasını aşağıdaki konumlarda arar:
  * Kodunuzda açıkça belirtilen bir yol
  * Bileşenin DLL'inin bulunduğu klasör (Aspose.Slides içinde dahil)
  * Bileşenin DLL'ini çağıran derlemenin bulunduğu klasör
* Değerlendirme sürümünün sınırlamalarından kaçınmak için, Aspose.Slides'ı kullanmadan önce lisansı ayarlamalısınız. Bir lisans, uygulama veya işlem başına yalnızca bir kez ayarlanır.

## **Lisans Uygulama**

Bir lisans **dosyadan**, **akıştan** veya **gömülü kaynaktan** yüklenebilir.

{{% alert color="info" %}}

Aspose.Slides, lisans işlemleri için [License](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.license/) sınıfını sağlar.

{{% /alert %}} 

{{% alert color="warning" %}}

Yeni lisanslar, sadece 21.4 ve sonraki sürümlerle Aspose.Slides'ı etkinleştirebilir. Daha eski sürümler farklı bir lisans sistemi kullanır ve bu lisansları tanımaz.

{{% /alert %}}

### **Dosya**

Lisansı ayarlamanın en kolay yolu, lisans dosyasını bileşenin DLL'inin (Aspose.Slides içinde dahil) bulunduğu aynı klasöre koymak ve sadece dosya adını, yol olmadan belirtmektir.

Aşağıdaki C++ kodu, bir lisans dosyasının nasıl ayarlanacağını gösterir:

```c++
#include <Util/License.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

{{% alert color="warning" %}} 

Lisans dosyasını farklı bir dizine koyarsanız, [License::SetLicense](https://reference.aspose.com/slides/tr/cpp/aspose.slides/license/setlicense/) yöntemini çağırırken belirtilen açık yolun sonundaki dosya adı, lisans dosyanızın adıyla tam olarak eşleşmelidir.

Örneğin, lisans dosyanızın adını *Aspose.Slides.lic.xml* olarak değiştirirseniz, kodunuzda [License::SetLicense](https://reference.aspose.com/slides/tr/cpp/aspose.slides/license/setlicense/) metoduna *Aspose.Slides.lic.xml* ile biten tam yolu geçirmeniz gerekir.

{{% /alert %}}

### **Akış**

Bir lisansı akıştan yükleyebilirsiniz. Aşağıdaki C++ kodu, bir akıştan lisansın nasıl uygulanacağını gösterir:

```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto license = MakeObject<License>();

auto stream = File::OpenRead(u"Aspose.Slides.lic");

license->SetLicense(stream);
```

## **Lisans Doğrulama**

Bir lisansın doğru şekilde ayarlanıp ayarlanmadığını kontrol etmek için doğrulama yapabilirsiniz. Aşağıdaki C++ kodu, bir lisansın nasıl doğrulanacağını gösterir:

```c++
#include <Util/License.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto license = MakeObject<License>();

license->SetLicense(u"Aspose.Slides.lic");

if (license->IsLicensed())
{
    Console::WriteLine(u"License is good!");
    Console::ReadKey();
}
```

## **İş Parçacığı Güvenliği**

{{% alert title="Not" color="warning" %}} 

[License::SetLicense](https://reference.aspose.com/slides/tr/cpp/aspose.slides/license/setlicense/) yöntemi **iş parçacığı güvenli değildir**. Bu yöntemi aynı anda birden fazla iş parçacığından çağırmanız gerekiyorsa, potansiyel sorunları önlemek için bir kilit gibi senkronizasyon primitiflerini kullanmanız önerilir.

{{% /alert %}}

## **SSS**

### Lisansı tamamen çevrim dışı bir ortamda (internet erişimi olmadan) uygulayabilir miyim?

Evet. Lisans doğrulaması, lisans dosyası kullanılarak yerel olarak gerçekleştirilir; internet bağlantısı gerektirmez.

### Bir yıllık abonelik sona erdiğinde ne olur? Kütüphane çalışmayı durdurur mu?

Hayır. Lisans süresizdir: abonelik bitiş tarihinizden önce yayınlanan sürümleri kullanmaya devam edebilirsiniz; ancak yenilerini kullanmak için yenileme yapmanız gerekir.