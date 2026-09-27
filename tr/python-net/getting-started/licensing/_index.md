---
title: Lisanslama
type: docs
weight: 80
url: /tr/python-net/licensing/
keywords:
- lisans
- geçici lisans
- lisans ayarla
- lisans kullan
- lisans doğrula
- lisans dosyası
- değerlendirme sürümü
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET içinde lisansların nasıl uygulanacağını, yönetileceğini ve sorun giderileceğini öğrenin. Adım adım lisanslama rehberimizle tam özelliklere kesintisiz erişimi sağlayın."
---
## **Genel Bakış**

Aspose.Slides, değerlendirme modunda veya geçerli bir lisansla kullanılabilir. Değerlendirme sürümü, lisanslı sürümle aynı işlevselliği sunar, ancak kaydettiği her sunumun her slaytına bir değerlendirme filigranı ekler ve kodunuzun sunumlardan okuduğu metni kısaltır.

## **Aspose.Slides'i Değerlendirin**

**Aspose.Slides for Python via .NET**'in değerlendirme sürümünü [indirme sayfası](https://pypi.org/project/Aspose.Slides/) üzerinden indirebilirsiniz. Değerlendirme sürümü, lisanslı ürünle aynı özellikleri sunar. Değerlendirme paketi, satın alınan paketle aynı olup lisansı uygulamak için birkaç satır kod eklediğinizde lisanslı hâle gelir.

**Aspose.Slides**'in değerlendirmesinden memnun kaldığınızda, bir [lisans satın alabilirsiniz](https://purchase.aspose.com/pricing/slides/python-net/). Mevcut abonelik seçeneklerini incelemenizi öneririz. Sorularınız varsa, Aspose satış ekibiyle iletişime geçin.

Her Aspose lisansı, bu süre içinde yayınlanan yeni sürümlere ve düzeltmelere ücretsiz yükseltmeler içeren bir yıllık abonelik içerir. Lisanslı ve değerlendirme kullanıcıları ücretsiz ve sınırsız teknik destek alır.

**Değerlendirme Sürümünün Sınırlamaları**

* Değerlendirme sürümü (lisans uygulanmadığında) tam işlevsellik sağlar, ancak kaydettiği her sunumun her slaytına bir değerlendirme filigranı metin kutusu ekler.
* Kodunuzun bir sunumdan okuduğu metin, ilk birkaç karakterine kısaltılır ve ardından değerlendirme sınırlamasına dair bir uyarı eklenir. Kodunuzun yazdığı metin tam olarak kaydedilir.

{{% alert color="info" title="Note" %}}Kısıtlamalar olmadan Aspose.Slides'i test etmek için **30 günlük Geçici Lisans** talep edebilirsiniz. Detaylar için [Geçici Lisans Nasıl Alınır](https://purchase.aspose.com/temporary-license) sayfasına bakın.{{% /alert %}}

## **Aspose.Slides'te Lisanslama**

* Bir değerlendirme sürümü, bir lisans satın alındıktan ve lisansı uygulamak için birkaç satır kod eklendikten sonra lisanslı hale gelir.
* Lisans, ürün adı, kapsadığı geliştirici sayısı, abonelik bitiş tarihi vb. gibi ayrıntıları içeren, düz metin XML dosyasıdır.
* Lisans dosyası dijital olarak imzalanmıştır, bu yüzden değiştirilmemelidir. Tek bir satır sonu eklemek bile geçersiz kılar.
* Aspose.Slides for Python via .NET, lisansı kendisine verdiğiniz yolda arar. Göreli bir yol ya da yolsuz bir dosya adı, geçerli çalışma dizinine göre çözülür; bu dizin Python betiğinizin bulunduğu klasör olmayabilir.
* Değerlendirme sınırlamalarından kaçınmak için, Aspose.Slides'i kullanmadan önce lisansı ayarlayın. Uygulama ya da işlem başına yalnızca bir kez ayarlamanız yeterlidir.

{{% alert color="info" title="Note" %}}Ayrıca [Ölçülü Lisanslama](/slides/tr/python-net/metered-licensing/) sayfasını inceleyebilirsiniz.{{% /alert %}}

## **Lisans Uygulama**

Bir lisans, **dosya** ya da **akış** üzerinden yüklenebilir.

{{% alert color="info" title="Note" %}}Aspose.Slides, lisanslamayı yönetmek için [License](https://reference.aspose.com/slides/python-net/aspose.slides/license/) sınıfını sağlar.{{% /alert %}}

{{% alert color="warning" title="Warning" %}}Yeni lisanslar, sadece 21.4 veya daha sonraki sürümde Aspose.Slides'ı etkinleştirebilir. Daha eski sürümler farklı bir lisanslama sistemi kullanır ve bu lisansları tanımaz.{{% /alert %}}

### **Dosya**

Bir lisansı ayarlamanın en basit yolu, lisans dosyasının yolunu [set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/) metoduna geçirmek​dir. Aşağıdaki örnekteki gibi yalnızca dosya adını verirseniz, Aspose.Slides dosyayı geçerli çalışma dizininde arar.

Aşağıdaki Python kodu, lisans dosyasını nasıl ayarlayacağınızı gösterir:

```py
import aspose.slides as slides

# Lisans sınıfını örnekler.
license = slides.License()

# Lisans dosyası yolunu ayarlar.
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" title="Warning" %}}Eğer lisans dosyasını farklı bir dizine yerleştirirseniz, [License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/#str) metodunu çağırdığınızda, açık yolun sonundaki dosya adı lisans dosyanızın adıyla aynı olmalıdır.

Örneğin, lisans dosyasını *Aspose.Slides.lic.xml* olarak yeniden adlandırabilirsiniz. Ardından kodunuzda, bu dosyanın tam yolunu (Aspose.Slides.lic.xml ile biten) [License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/#str) metoduna geçirin.{{% /alert %}}

### **Akış**

Bir lisansı akıştan (stream) yükleyebilirsiniz. Aşağıdaki Python örneği, bir akıştan lisans nasıl uygulanacağını gösterir:

```py
import aspose.slides as slides

# Lisans sınıfının bir örneğini oluşturur.
license = slides.License()

# Lisansı bir akıştan ayarlar.
with open("Aspose.Slides.lic", "rb") as stream:
    license.set_license(stream)
```

## **Lisansı Doğrulama**

Lisansın doğru bir şekilde uygulanıp uygulanmadığını doğrulamak için, lisansı doğrulayabilirsiniz. Aşağıdaki Python kodu, bir lisansı nasıl doğrulayacağınızı gösterir:

```py
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("License is good!")
```

## **İş Parçacığı Güvenliği**

{{% alert color="warning" title="Warning" %}}[License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/) metodu iş parçacığı güvenli değildir. Birden fazla iş parçacığından aynı anda çağırmanız gerektiğinde, `threading.Lock` gibi bir senkronizasyon primi kullanarak sorunlardan kaçının.{{% /alert %}}

## **SSS**

### Lisansı tamamen çevrim dışı bir ortamda (internet erişimi olmadan) uygulayabilir miyim?

Evet. Lisans doğrulaması, lisans dosyası kullanılarak yerel olarak yapılır; internet bağlantısı gerekmez.

### Bir yıllık abonelik süresi dolduktan sonra ne olur? Kütüphane çalışmayı durdurur mu?

Hayır. Lisans süresizdir: Abonelik bitiş tarihinizden önce yayınlanan sürümleri kullanmaya devam edebilirsiniz; ancak yenilerini kullanmak için aboneliği yenilemeniz gerekir.