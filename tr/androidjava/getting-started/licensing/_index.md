---
title: Lisanslama
type: docs
weight: 90
url: /tr/androidjava/licensing/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java'da lisansları uygulayın, yönetin ve sorun giderin. Lisanslama kılavuzumuzla tam özelliklere kesintisiz erişimi sağlayın."
---
## **Genel Bakış**

Aspose.Slides, değerlendirme modunda ya da geçerli bir lisansla kullanılabilir. Değerlendirme sürümü, lisanslı sürümle aynı işlevselliği sağlar, ancak sunumlar açıldığında veya kaydedildiğinde bir değerlendirme filigranı ekler ve metin çıkarmayı bir slaytla sınırlı tutar.

Bu makale, Aspose.Slides'te lisanslamanın nasıl çalıştığını ve kütüphaneyi kullanmadan önce bir lisansın nasıl uygulanacağını açıklar. `License` sınıfı kullanılarak bir lisans dosyadan, akıştan veya gömülü kaynaktan yüklenebilir. Makale ayrıca bir lisansın doğru şekilde uygulanıp uygulanmadığını nasıl doğrulayacağınızı gösterir.

## **Aspose.Slides'i Değerlendirin**

{{% alert color="primary" %}} 

**Aspose.Slides for Android via Java**'ın bir değerlendirme sürümünü [indirme sayfasından](https://releases.aspose.com/slides/tr/androidjava/) indirebilirsiniz. Değerlendirme sürümü, ürünün lisanslı sürümüyle aynı işlevleri sağlar. Değerlendirme paketi, satın alınan paketle aynıdır. Değerlendirme sürümü, birkaç satır kod ekleyerek (lisansı uygulamak için) lisanslı hâle gelir.

Aspose.Slides değerlendirmesinden memnun kaldıktan sonra, bir [lisans satın alabilirsiniz](https://purchase.aspose.com/buy). Farklı abonelik türlerine göz atmanızı öneririz. Sorularınız varsa, Aspose satış ekibiyle iletişime geçin.

Her Aspose lisansı, abonelik süresi içinde yayınlanan yeni sürümler veya düzeltmeler için ücretsiz yükseltmeler sağlayan bir yıllık abonelikle gelir. Lisanslı ürün (veya hatta değerlendirme sürümü) kullanan kullanıcılar ücretsiz ve sınırsız teknik destek alır.

{{% /alert %}} 

**Değerlendirme sürümü sınırlamaları**

* Aspose.Slides değerlendirme sürümü (lisans belirtilmediği sürece) tam ürün işlevselliği sağlar, ancak açma ve kaydetme işlemlerinde belgenin üst kısmına bir değerlendirme filigranı ekler.  
* Sunum slaytlarından metin çıkarırken yalnızca bir slaytla sınırlısınız.

{{% alert color="primary" %}} 

Aspose.Slides'i sınırlama olmadan test etmek için **30 Günlük Geçici Lisans** talep edebilirsiniz. Daha fazla bilgi için [Geçici Lisans Nasıl Alınır](https://purchase.aspose.com/temporary-license) sayfasına bakın.

{{% /alert %}}

## **Aspose.Slides'te Lisanslama**

* Değerlendirme sürümü, bir lisans satın alıp birkaç satır kod ekleyerek (lisansı uygulamak için) lisanslı hâle gelir.  
* Lisans, ürün adı, lisanslı geliştirici sayısı, abonelik son tarih gibi ayrıntıları içeren düz metin XML dosyasıdır.  
* Lisans dosyası dijital olarak imzalıdır, bu yüzden dosyayı değiştirmemelisiniz. Dosya içeriğine iste dışı bir satır sonu eklenmesi bile lisansı geçersiz kılar.  
* Aspose.Slides for Android via Java genellikle lisansı şu konumlarda arar:  
  * Açık bir yol  
  * Aspose.Slides.jar dosyasını içeren klasör  
* Değerlendirme sürümüyle ilgili sınırlamalardan kaçınmak için **Aspose.Slides**'i kullanmadan önce bir lisans ayarlamanız gerekir. Bir uygulama veya işlem başına sadece bir kez lisans ayarlamanız yeterlidir.

## **Lisans Uygulama**

Bir lisans **dosyadan** veya **akıştan** yüklenebilir.

{{% alert color="primary" %}}

Aspose.Slides, lisans işlemleri için [License](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/license/) sınıfını sağlar.

{{% /alert %}} 

{{% alert color="warning" %}}

Yeni lisanslar, Aspose.Slides'ı yalnızca 21.4 veya sonraki sürümlerde etkinleştirebilir. Daha eski sürümler farklı bir lisanslama sistemi kullanır ve bu lisansları tanımaz.

{{% /alert %}}

### **Dosya**

Lisans ayarlamanın en kolay yöntemi, lisans dosyasını Aspose.Slides.jar dosyasını veya uygulamanızın jar dosyasını içeren klasöre koymanızı gerektirir.

Bu Java kodu, bir lisans dosyasının nasıl ayarlanacağını gösterir:

``` java
// Lisans sınıfını örnekler
com.aspose.slides.License license = new com.aspose.slides.License();

// Lisans dosyası yolunu ayarlar
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" %}} 

Lisans dosyasını farklı bir dizine koyarsanız, [SetLicense](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) yöntemini çağırdığınızda, belirtilen açık yolun sonundaki lisans dosyası adı lisans dosyanızla aynı olmalıdır.

Örneğin, lisans dosyası adını *Aspose.Slides.Android.via.Java.lic.xml* olarak değiştirebilirsiniz. Ardından, kodunuzda [SetLicense](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) yöntemine dosyanın yolunu (*Aspose.Slides.Android.via.Java.lic.xml* ile biten) geçirmeniz gerekir.

{{% /alert %}}

### **Akış**

Bir lisansı akıştan yükleyebilirsiniz. Bu Java kodu, bir lisansın akıştan nasıl uygulanacağını gösterir:

``` java
// Lisans sınıfını örnekler
com.aspose.slides.License license = new com.aspose.slides.License();

// Lisansı bir akış üzerinden ayarlar
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

## **Lisans Doğrulama**

Bir lisansın doğru şekilde ayarlanıp ayarlanmadığını kontrol etmek için doğrulayabilirsiniz. Bu Java kodu, bir lisansın nasıl doğrulanacağını gösterir:

```java
License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **İş Parçacığı Güvenliği**

{{% alert title="Note" color="warning" %}} 

[SetLicense](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) yöntemi iş parçacığı güvenli değildir. Bu yöntem çok sayıda iş parçacığından aynı anda çağrılması gerekiyorsa, sorunları önlemek için senkronizasyon primitifleri (örneğin bir kilit) kullanmak isteyebilirsiniz. 

{{% /alert %}}

## **SSS**

**Lisansı tamamen çevrim dışı bir ortamda (internet erişimi olmadan) uygulayabilir miyim?**

Evet. Lisans doğrulaması, lisans dosyası kullanılarak yerel olarak gerçekleştirilir; internet bağlantısı gerekmez.

**Bir yıllık abonelik sona erdiğinde ne olur? Kütüphane çalışmayı durdurur mu?**

Hayır. Lisans süresizdir: abonelik bitiş tarihinizden önce yayınlanan sürümleri kullanmaya devam edebilirsiniz; yalnızca yenileme yapmadığınız sürece daha yeni sürümleri kullanamazsınız.