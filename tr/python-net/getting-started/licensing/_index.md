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
description: "Aspose.Slides for Python via .NET içinde lisansları nasıl uygulayacağınızı, yöneteceğinizi ve sorunlarını gidereceğinizi öğrenin. Adım adım lisanslama rehberimizle tam özelliklere kesintisiz erişimi sağlayın."
---
## **Genel Bakış**

Aspose.Slides değerlendirme modunda veya geçerli bir lisansla kullanılabilir. Değerlendirme sürümü, lisanslı sürümle aynı işlevselliği sağlar, ancak sunumlar açıldığında veya kaydedildiğinde bir değerlendirme filigranı ekler ve metin çıkarımını bir slaytla sınırlar.

## **Aspose.Slides'ı Değerlendirin**

**Aspose.Slides for Python via .NET**'in bir değerlendirme sürümünü [indirme sayfasından](https://pypi.org/project/Aspose.Slides/) indirebilirsiniz. Değerlendirme sürümü, lisanslı ürünle aynı özellikleri sunar. Değerlendirme paketi, satın alınan paketle aynıdır ve lisansı uygulamak için birkaç satır kod ekledikten sonra lisanslı hale gelir.

**Aspose.Slides**'ı değerlendirmeden memnun kaldığınızda, [bir lisans satın alabilirsiniz](https://purchase.aspose.com/buy). Mevcut abonelik seçeneklerini gözden geçirmenizi öneririz. Sorularınız varsa, Aspose satış ekibiyle iletişime geçin.

Her Aspose lisansı, bu süre içinde yayınlanan yeni sürümlere ve düzeltmelere ücretsiz yükseltmeler içeren bir yıllık abonelik içerir. Lisanslı ve değerlendirme kullanıcıları ücretsiz, sınırsız teknik destek alır.

**Değerlendirme Sürümünün Sınırlamaları**

* Aspose.Slides değerlendirme sürümü (lisans uygulanmadığında) tam işlevsellik sağlasa da, belgeyi her açtığınızda veya kaydettiğinizde belgenin üst kısmına bir değerlendirme filigranı ekler.
* Bir sunumdan metin çıkarırken, bir slaytla sınırlı kalırsınız.

{{% alert color="primary" %}}
Aspose.Slides'i sınırlamalar olmadan test etmek için **30 günlük Geçici Lisans** talep edebilirsiniz. Ayrıntılar için [Geçici Lisans Nasıl Alınır](https://purchase.aspose.com/temporary-license) sayfasına bakın.
{{% /alert %}}

## **Aspose.Slides'ta Lisanslama**

* Bir değerlendirme sürümü, bir lisans satın alındıktan ve onu uygulamak için birkaç satır kod eklendikten sonra lisanslı hâle gelir.
* Lisans, ürün adı, kapsadığı geliştirici sayısı, abonelik son tarih gibi ayrıntıları içeren düz metin bir XML dosyasıdır.
* Lisans dosyası dijital olarak imzalıdır, bu yüzden değiştirilmemelidir. Tek bir satır sonu eklemek bile geçersiz kılar.
* Aspose.Slides for Python via .NET genellikle lisansı şu konumlarda arar:
  * Belirttiğiniz açık yol
  * Aspose.Slides for Python via .NET'i çağıran Python betiğini içeren klasör
* Değerlendirme sınırlamalarından kaçınmak için, Aspose.Slides'i kullanmadan önce lisansı ayarlayın. Uygulama ya da süreç başına sadece bir kez ayarlamanız yeterlidir.

{{% alert color="primary" %}}
[Ölçülü Lisanslama](/slides/tr/python-net/metered-licensing/) bölümünü de incelemek isteyebilirsiniz.
{{% /alert %}}

## **Lisans Uygulama**

Bir lisans **dosyadan**, **akıştan** veya **gömülü kaynaktan** yüklenebilir.

{{% alert color="primary" %}}
Aspose.Slides, lisanslamayı yönetmek için [License](https://reference.aspose.com/slides/tr/python-net/aspose.slides/license/) sınıfını sağlar.
{{% /alert %}}

{{% alert color="warning" %}}
Yeni lisanslar yalnızca 21.4 veya sonraki sürümde Aspose.Slides'i etkinleştirebilir. Daha eski sürümler farklı bir lisans sistemine sahiptir ve bu lisansları tanımaz.
{{% /alert %}}

### **Dosya**

Lisans ayarlamanın en kolay yolu, lisans dosyasını bileşenin DLL'inin bulunduğu aynı klasöre yerleştirmek ve yalnızca dosya adını (yol olmadan) belirtmektir.

Aşağıdaki Python kodu, lisans dosyasının nasıl ayarlanacağını gösterir:

```py
import aspose.slides as slides

# Lisans sınıfını örnekler. 
license = slides.License()

# Lisans dosyası yolunu ayarlar.
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" %}}
Lisans dosyasını farklı bir dizine koyarsanız, [License.set_license()](https://reference.aspose.com/slides/tr/python-net/aspose.slides/license/set_license/#str) çağırdığınızda, açık yolun sonundaki dosya adı lisans dosyanızın adıyla eşleşmelidir.

Örneğin, lisans dosyasının adını *Aspose.Slides.lic.xml* olarak değiştirebilirsiniz. Ardından, kodunuzda bu dosyanın tam yolunu (Aspose.Slides.lic.xml ile biten) [License.set_license()](https://reference.aspose.com/slides/tr/python-net/aspose.slides/license/set_license/#str) yöntemine iletebilirsiniz.
{{% /alert %}}

### **Akış**

Bir lisansı bir akıştan yükleyebilirsiniz. Aşağıdaki Python örneği, bir akıştan lisans uygulamayı gösterir:

```py
import aspose.slides as slides

# Lisans sınıfını örnekler.
license = slides.License()

# Lisansı bir akıştan ayarlar.
license.set_license(stream)
```

## **Lisansı Doğrulama**

Lisansın doğru bir şekilde uygulandığını doğrulamak için, lisansı doğrulayabilirsiniz. Aşağıdaki Python kodu, bir lisansı nasıl doğrulayacağınızı gösterir:

```py
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("License is good!")
```

## **İş Parçacığı Güvenliği**

{{% alert title="Note" color="warning" %}}
[License.set_license](https://reference.aspose.com/slides/tr/python-net/aspose.slides/license/) yöntemleri iş parçacığı güvenli değildir. Birden çok iş parçacığından aynı anda çağrılması gerekiyorsa, sorunları önlemek için senkronizasyon ilkelini (ör. `threading.Lock`) kullanın.
{{% /alert %}}

## **SSS**

**Lisansı tamamen çevrim dışı bir ortamda (internet erişimi yok) uygulayabilir miyim?**

Evet. Lisans doğrulaması, lisans dosyası kullanılarak yerel olarak gerçekleştirilir; internet bağlantısı gerekli değildir.

**Bir yıllık abonelik sona erdiğinde ne olur? Kütüphane çalışmayı durdurur mu?**

Hayır. Lisans süresizdir: abonelik bitiş tarihinizden önce yayınlanan sürümleri kullanmaya devam edebilirsiniz; yalnızca yenilemeden daha yeni sürümleri kullanma hakkınız olmayacaktır.