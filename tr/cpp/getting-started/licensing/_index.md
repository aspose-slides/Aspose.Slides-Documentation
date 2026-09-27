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
description: "Aspose.Slides for C++ içinde lisansları uygulayın, yönetin ve sorunlarını giderin. Adım adım lisanslama kılavuzumuzla tam özelliklere kesintisiz erişimi sağlayın."
---
## **Genel Bakış**

Aspose.Slides, değerlendirme modunda veya geçerli bir lisans ile kullanılabilir. Değerlendirme sürümü, lisanslı sürümle aynı işlevselliği sağlar, ancak kaydettiği her sunumun her slaytına bir değerlendirme filigranı ekler ve kodunuzun sunumlardan okuduğu metni kısaltır.

Bu makale, Aspose.Slides'te lisanslamanın nasıl çalıştığını ve kütüphaneyi kullanmadan önce bir lisansın nasıl uygulanacağını açıklar. Bir lisans, `License` sınıfı kullanılarak bir dosyadan veya akıştan yüklenebilir. Makale ayrıca bir lisansın doğru şekilde uygulanıp uygulanmadığını nasıl doğrulayacağınızı gösterir.

## **Aspose.Slides'ı Değerlendirin**

{{% alert color="info" title="Note" %}}
**Aspose.Slides for C++**'ın değerlendirme sürümünü [NuGet indirme sayfasından](https://www.nuget.org/packages/Aspose.Slides.Cpp/) veya ZIP paketi olarak [indirme sayfasından](https://releases.aspose.com/slides/cpp/) indirebilirsiniz. Değerlendirme sürümü, lisanslı ürünle aynı işlevselliği sunar. Aslında, değerlendirme paketi satın alınan paketle aynıdır—lisansı uygulamak için birkaç satır kod eklediğinizde lisanslı hâle gelir.
  
Değerlendirme sürecinizden memnun kalırsanız, bir [lisans satın alabilirsiniz](https://purchase.aspose.com/pricing/slides/cpp/). Mevcut abonelik türlerini incelemenizi tavsiye ederiz. Herhangi bir sorunuz olursa, Aspose satış ekibiyle iletişime geçmekten çekinmeyin.

Her Aspose lisansı, yeni sürümler ve bu süre içinde yayınlanan hata düzeltmeleri dahil olmak üzere ücretsiz yükseltmeler için bir yıllık abonelik içerir. Lisanslı veya değerlendirme sürümünü kullanıyor olsanız da ücretsiz ve sınırsız teknik destek alırsınız.
{{% /alert %}} 

**Değerlendirme Sürümü Sınırlamaları**

* Lisans belirtilmemiş bir değerlendirme sürümü, tam ürün işlevselliği sağlar, ancak kaydettiği her sunumun her slaytına bir değerlendirme filigranı metin kutusu ekler.
* Kodunuzun bir sunumdan okuduğu metin, ilk birkaç karakteri ve değerlendirme sınırlamasına dair bir uyarı ile kısaltılır. Kodunuzun yazdığı metin ise tam olarak kaydedilir.

{{% alert color="info" title="Note" %}}
Sınırlamalar olmadan Aspose.Slides'ı test etmek için **30 Günlük Geçici Lisans** talep edebilirsiniz. Daha fazla bilgi için [Geçici Lisans Nasıl Alınır](https://purchase.aspose.com/temporary-license) sayfasına bakın.
{{% /alert %}}

## **Aspose.Slides'te Lisanslama**

* Bir değerlendirme sürümü, bir lisans satın alındıktan ve birkaç satır kod eklenerek uygulandıktan sonra lisanslı hâle gelir.
* Lisans, ürün adı, lisans verilen geliştirici sayısı, abonelik sonlanma tarihi gibi ayrıntıları içeren düz metin XML dosyasıdır.
* Lisans dosyası dijital olarak imzalanmıştır; bu yüzden değiştirilmemelidir. Bir satır sonu eklemek gibi kazara bir değişiklik bile dosyayı geçersiz kılar.
* Bir dosya adı klasör belirtilmeden verildiğinde, Aspose.Slides for C++ lisans dosyasını yalnızca geçerli çalışma dizininde arar. Çalıştırılabilir dosyanızın veya Aspose.Slides kütüphanenizin klasöründe arama yapmaz; lisans dosyası başka bir yerdeyse tam yolu belirtin.
* Değerlendirme sürümünün sınırlamalarından kaçınmak için, Aspose.Slides'ı kullanmadan önce lisansı ayarlamalısınız. Bir lisans, uygulama ya da süreç başına yalnızca bir kez ayarlanmalıdır.

## **Bir Lisans Uygulama**

Bir lisans **dosyadan** veya **akıştan** yüklenebilir.

{{% alert color="info" title="Note" %}}
Aspose.Slides, lisans işlemleri için [License](https://reference.aspose.com/slides/cpp/aspose.slides/license/) sınıfını sağlar.
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
Yeni lisanslar, yalnızca 21.4 veya sonraki sürümde Aspose.Slides'ı etkinleştirebilir. Daha eski sürümler farklı bir lisanslama sistemi kullanır ve bu lisansları tanımaz.
{{% /alert %}}

### **Dosya**

Lisansı ayarlamanın en kolay yolu, lisans dosyasını programınızın çalışma dizinine yerleştirmek ve yalnızca dosya adını, yolu olmadan belirtmektir. Aksi takdirde, dosyanın tam yolunu belirtin.

Aşağıdaki C++ kodu, programın çalışma dizinindeki *Aspose.Slides.lic* lisans dosyasını uygular:

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

Lisans geçerli ise, [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) geri döner ve program hiçbir çıktı üretmeden sonlanır; bundan sonra Aspose.Slides, değerlendirme sınırlamaları olmadan çalışır. Dosya çalışma dizininde yoksa, yöntem [FileNotFoundException](https://reference.aspose.com/slides/cpp/system.io/filenotfoundexception/) ile "*License \"Aspose.Slides.lic\" doesn't exist or access is restricted*" mesajını atar. Örnek istisna yönetimi yapmadığı için program durur.

{{% alert color="warning" title="Warning" %}}
Lisans dosyasını farklı bir dizine koyarsanız, [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) yöntemini çağırırken belirtilen açık yolun sonundaki dosya adı, lisans dosyanızın adıyla tam olarak eşleşmelidir.

Örneğin, lisans dosyanızın adını *Aspose.Slides.lic.xml* olarak değiştirirseniz, kodunuzdaki [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) yöntemine *Aspose.Slides.lic.xml* ile biten tam yolu geçirmeniz gerekir.
{{% /alert %}}

### **Akış**

Programınız lisansı bir dosya olarak tutmuyorsa, örneğin lisansı bir veritabanından okuduysa, lisansı bir akıştan yükleyin. [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) lisansı içeren herhangi bir [Stream](https://reference.aspose.com/slides/cpp/system.io/stream/) kabul eder. Örneği kısa tutmak için aşağıdaki C++ kodu, çalışma dizinindeki *Aspose.Slides.lic* dosyasını [File::OpenRead](https://reference.aspose.com/slides/cpp/system.io/file/openread/) ile açar ve lisansı o akıştan uygular:

```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

int main()
{
    auto license = MakeObject<License>();
    auto stream = File::OpenRead(u"Aspose.Slides.lic");
    license->SetLicense(stream);

    return 0;
}
```

Geçerli bir lisans, dosya örneğiyle aynı sonucu verir. Dosya mevcut değilse, [File::OpenRead](https://reference.aspose.com/slides/cpp/system.io/file/openread/) lisans uygulanmadan önce bir [FileNotFoundException](https://reference.aspose.com/slides/cpp/system.io/filenotfoundexception/) atar ve program durur.

## **Bir Lisansı Doğrulama**

Bir lisansın doğru şekilde ayarlanıp ayarlanmadığını kontrol etmek için [License::IsLicensed](https://reference.aspose.com/slides/cpp/aspose.slides/license/islicensed/) yöntemini çağırın. Geçerli bir lisans uygulandıktan sonra `true`, öncesinde `false` döner. Aşağıdaki C++ kodu, çalışma dizinindeki lisans dosyasını uygular ve ardından doğrular:

```c++
#include <Util/License.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    if (license->IsLicensed())
    {
        Console::WriteLine(u"License is good!");
    }

    return 0;
}
```

Geçerli bir lisansla program "*License is good!*" mesajını yazdırır. Dosya eksik ya da lisans dosyası değilse, [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) kontrol öncesinde bir istisna atar ve program hiçbir şey yazdırmadan durur. Dosya bir lisans ancak imzası eşleşmiyorsa (örneğin düzenlendiyse), SetLicense hata vermeden döner ancak `IsLicensed` `false` döner; bu durumda hiçbir şey yazdırılmaz ve Aspose.Slides değerlendirme modunda kalır.

## **Thread Güvenliği**

{{% alert color="warning" title="Warning" %}}
[License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) yöntemi **thread-safe değildir**. Bu yöntemi birden fazla iş parçacığından aynı anda çağırmanız gerekiyorsa, olası sorunları önlemek için bir kilit gibi senkronizasyon ilkelileri kullanmanız önerilir.
{{% /alert %}}

## **SSS**

### Lisansı tamamen çevrim dışı bir ortamda (internet erişimi yok) uygulayabilir miyim?

Evet. Lisans doğrulaması, lisans dosyası kullanılarak yerel olarak yapılır; internet bağlantısı gerekmez.

### Bir yıllık abonelik sona erdiğinde ne olur? Kütüphane çalışmayı durdurur mu?

Hayır. Lisans süresizdir: abonelik bitiş tarihinizden önce yayınlanan sürümleri kullanmaya devam edebilirsiniz; ancak yenileme yapmadan daha yeni sürümleri kullanamazsınız.