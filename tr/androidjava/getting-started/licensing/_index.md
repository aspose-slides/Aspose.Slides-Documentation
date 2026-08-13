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
description: "Aspose.Slides for Android via Java'da lisansları uygulayın, yönetin ve sorunları gidermek için adımları izleyin. Lisanslama kılavuzumuzla tam özelliklere kesintisiz erişim sağlayın."
---
## **Genel Bakış**

Aspose.Slides, değerlendirme modunda veya geçerli bir lisansla kullanılabilir. Değerlendirme sürümü, lisanslı sürümle aynı işlevselliği sağlar, ancak sunumlar açıldığında veya kaydedildiğinde bir değerlendirme filigranı ekler ve metin çıkarmayı bir slaytla sınırlandırır.

Bu makale, Aspose.Slides'te lisanslamanın nasıl çalıştığını ve kütüphaneyi kullanmadan önce bir lisansın nasıl uygulanacağını açıklar. `License` sınıfı kullanılarak bir lisans dosyadan, akıştan veya gömülü kaynaktan yüklenebilir. Makale ayrıca bir lisansın doğru şekilde uygulanıp uygulanmadığını nasıl doğrulayacağınızı gösterir.

## **Aspose.Slides'i Değerlendirin**

{{% alert color="info" %}} 
Aspose.Slides for Android via Java'in **değerlendirme sürümünü** [indirme sayfası](https://releases.aspose.com/slides/tr/androidjava/) adresinden indirebilirsiniz. Değerlendirme sürümü, ürünün lisanslı sürümüyle aynı işlevselliği sunar. Değerlendirme paketi, satın alınan paketle aynıdır. Değerlendirme sürümü, birkaç satır kod ekleyip lisansı uyguladığınızda basitçe lisanslı hâle gelir.

Aspose.Slides'i değerlendirmelerinizden memnun kaldıktan sonra bir [lisans satın alabilirsiniz](https://purchase.aspose.com/buy). Farklı abonelik türlerini incelemenizi öneririz. Sorularınız varsa Aspose satış ekibiyle iletişime geçin.

Her Aspose lisansı, abonelik süresi içinde yayınlanan yeni sürümlere veya düzeltmelere ücretsiz yükseltme sağlayan bir yıllık abonelikle birlikte gelir. Lisanslı ürünleri (ve hatta değerlendirme sürümlerini) kullananlar ücretsiz ve sınırsız teknik destek alır.
{{% /alert %}} 

**Değerlendirme sürümü sınırlamaları**

* Lisans belirtilmemiş Aspose.Slides değerlendirme sürümü tam ürün işlevselliği sağlasa da, açma ve kaydetme işlemlerinde belgenin üst kısmına bir değerlendirme filigranı ekler. 
* Sunum slaytlarından metin çıkartırken yalnızca bir slaytla sınırlısınız.

{{% alert color="info" %}} 
Aspose.Slides'i sınırlamalar olmadan test etmek için **30 Günlük Geçici Lisans** talep edebilirsiniz. Daha fazla bilgi için [Geçici Lisans Nasıl Alınır](https://purchase.aspose.com/temporary-license) sayfasına bakın.
{{% /alert %}}

## **Aspose.Slides'te Lisanslama**

* Değerlendirme sürümü, bir lisans satın alıp birkaç satır kod ekleyerek (lisansı uygulamak için) lisanslı hâle gelir.
* Lisans, ürün adı, lisanslı geliştirici sayısı, abonelik son tarih gibi ayrıntıları içeren düz metin XML dosyasıdır.
* Lisans dosyası dijital olarak imzalıdır, bu nedenle dosyayı değiştirmemelisiniz. Dosya içeriğine istemeden ek bir satır sonu eklemek bile lisansı geçersiz kılar.
* Aspose.Slides for Android via Java genellikle lisansı şu konumlarda arar:
  * Açık bir yol
  * Aspose.Slides.jar dosyasını içeren klasör
* Değerlendirme sürümüyle ilişkili sınırlamalardan kaçınmak için **Aspose.Slides** kullanmadan önce bir lisans ayarlamanız gerekir. Bir uygulama veya işlem başına sadece bir kez lisans ayarlamanız yeterlidir.

## **Lisans Uygulama**

Bir lisans **dosyadan** veya **akıştan** yüklenebilir.

{{% alert color="info" %}}
Aspose.Slides, lisans işlemleri için [License](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/license/) sınıfını sağlar.
{{% /alert %}} 

{{% alert color="warning" %}}
Yeni lisanslar, Aspose.Slides'i yalnızca 21.4 veya sonraki sürümle etkinleştirebilir. Daha eski sürümler farklı bir lisans sistemini kullanır ve bu lisansları tanımaz.
{{% /alert %}}

### **Dosya**

Lisans ayarlamanın en kolay yöntemi, lisans dosyasını Aspose.Slides.jar dosyasını veya uygulamanızın jar dosyasını içeren klasöre yerleştirmenizi gerektirir.

Bu Java kodu, bir lisans dosyasının nasıl ayarlanacağını gösterir:

``` java
// License sınıfını örnekler
com.aspose.slides.License license = new com.aspose.slides.License();

// Lisans dosyası yolunu ayarlar
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" %}} 
Lisans dosyasını farklı bir dizine koyarsanız, [SetLicense](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) yöntemini çağırdığınızda, belirtilen açık yolun sonundaki lisans dosyası adı lisans dosyanızla aynı olmalıdır.

Örneğin, lisans dosyası adını *Aspose.Slides.Android.via.Java.lic.xml* olarak değiştirebilirsiniz. Ardından, kodunuzda dosyanın yolunu (*Aspose.Slides.Android.via.Java.lic.xml* ile biten) [SetLicense](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) yöntemine geçirmeniz gerekir.
{{% /alert %}}

### **Akış**

Bir lisansı bir akıştan yükleyebilirsiniz. Bu Java kodu, bir akıştan lisansın nasıl uygulanacağını gösterir:

``` java
// License sınıfını örnekler
com.aspose.slides.License license = new com.aspose.slides.License();

// Lisansı bir akış üzerinden ayarlar
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

## **Lisansı Doğrulama**

Bir lisansın doğru şekilde ayarlanıp ayarlanmadığını kontrol etmek için doğrulayabilirsiniz. Bu Java kodu, bir lisansın nasıl doğrulanacağını gösterir:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **İş Parçacığı Güvenliği**

{{% alert title="Note" color="warning" %}} 
[SetLicense](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) yöntemi iş parçacığı güvenli değildir. Bu yöntem birden çok iş parçacığından aynı anda çağrılması gerektiğinde, sorunları önlemek için senkronizasyon primitiflerini (örneğin bir kilit) kullanmak isteyebilirsiniz. 
{{% /alert %}}

## **SSS**

### Lisansı tamamen çevrim dışı bir ortamda (internet erişimi olmadan) uygulayabilir miyim?

Evet. Lisans doğrulaması, lisans dosyası kullanılarak yerel olarak gerçekleştirilir; internet bağlantısı gerekmez.

### Bir yıllık abonelik sona erdikten sonra ne olur? Kütüphane çalışmayı durdurur mu?

Hayır. Lisans süresizdir: Abonelik tarihinden önce yayınlanan sürümleri kullanmaya devam edebilirsiniz; ancak yenileri için yenileme yapmadığınız sürece kullanamazsınız.