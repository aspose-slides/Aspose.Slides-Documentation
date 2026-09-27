---
title: Lisanslama
type: docs
weight: 90
url: /tr/java/licensing/
keywords:
- lisans
- geçici lisans
- lisansı ayarla
- lisansı kullan
- lisansı doğrula
- lisans dosyası
- değerlendirme sürümü
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da lisansları uygulayın, yönetin ve sorun giderin. Adım adım lisanslama kılavuzumuzla tam özelliklere kesintisiz erişimi sağlayın."
---
## **Genel Bakış**

Aspose.Slides, değerlendirme modunda veya geçerli bir lisansla kullanılabilir. Değerlendirme sürümü, lisanslı sürümle aynı işlevselliği sağlar, ancak kaydettiği her sunumun her slaytına bir değerlendirme filigranı ekler ve API üzerinden kodunuzun okuduğu metni keser.

Bu makale, Aspose.Slides'te lisanslamanın nasıl çalıştığını ve kütüphaneyi kullanmadan önce lisansın nasıl uygulanacağını açıklar. Bir lisans, `License` sınıfı kullanılarak dosya, akış veya gömülü kaynak aracılığıyla yüklenebilir. Makale ayrıca, bir lisansın doğru şekilde uygulanıp uygulanmadığını doğrulamanın yollarını gösterir.

## **Aspose.Slides'ı Değerlendirin**

{{% alert color="info" title="Note" %}}
**Aspose.Slides for Java**'ın değerlendirme sürümünü [indirme sayfasından](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) indirebilirsiniz. Değerlendirme sürümü, ürünün lisanslı sürümüyle aynı işlevleri sağlar. Değerlendirme paketi, satın alınan paketle aynıdır. Değerlendirme sürümü, birkaç satır kod ekleyerek (lisansı uygulamak için) lisanslı hâle gelir.

**Aspose.Slides**'ı değerlendirmeden memnun kaldıktan sonra bir [lisans satın alabilirsiniz](https://purchase.aspose.com/pricing/slides/java/). Farklı abonelik tiplerini gözden geçirmenizi öneririz. Sorularınız varsa, Aspose satış ekibiyle iletişime geçin.

Her Aspose lisansı, abonelik süresi içinde yayınlanan yeni sürümlere veya düzeltmelere ücretsiz yükseltmeler için bir yıllık abonelik içerir. Lisanslı ürünleri (veya hatta değerlendirme sürümlerini) kullanan kullanıcılar ücretsiz ve sınırsız teknik destek alır.
{{% /alert %}} 

**Değerlendirme sürümü sınırlamaları**

* Lisans belirtilmeyen değerlendirme sürümü, tam ürün işlevselliği sağlar, ancak kaydettiği her sunumun her slaytına bir değerlendirme filigranı metin kutusu ekler.
* API üzerinden kodunuzun okuduğu metin, yeni ayarladığı metin dahil, ilk birkaç karakterine kesilir ve ardından değerlendirme sınırlamasıyla ilgili bir uyarı eklenir. Kodunuzun yazdığı metin ise tam olarak kaydedilir.

{{% alert color="info" title="Note" %}}
Aspose.Slides'ı sınırlama olmadan test etmek için **30 Günlük Geçici Lisans** isteyebilirsiniz. Daha fazla bilgi için [Geçici Lisans Nasıl Alınır](https://purchase.aspose.com/temporary-license) sayfasına bakın.
{{% /alert %}}

## **Aspose.Slides'te Lisanslama**

* Bir değerlendirme sürümü, lisans satın alındıktan ve birkaç satır kod eklenerek (lisansı uygulamak için) lisanslı hâle gelir.
* Lisans, ürün adı, lisanslı geliştirici sayısı, abonelik bitiş tarihi gibi ayrıntıları içeren düz metin XML dosyasıdır.
* Lisans dosyası dijital olarak imzalanmıştır, bu nedenle dosyayı değiştirmemelisiniz. Dosyanın içeriğine yanlışlıkla ekstra bir satır sonu eklenmesi bile lisansı geçersiz kılar.
* Aspose.Slides for Java genellikle lisansı şu konumlarda arar:
  * Açık bir yol
  * Aspose.Slides.jar içeren klasör
* Değerlendirme sürümüne ilişkin sınırlamalardan kaçınmak için **Aspose.Slides**'ı kullanmadan önce bir lisans ayarlamanız gerekir. Lisansı yalnızca uygulama veya süreç başına bir kez ayarlamanız yeterlidir.
{{% alert color="info" title="Note" %}}
[Ölçülü Lisanslama](/slides/tr/java/metered-licensing/) sayfasına bakmak isteyebilirsiniz.
{{% /alert %}} 

## **Lisans Uygulama**

Bir lisans **dosyadan** veya **akıştan** (stream) yüklenebilir.

{{% alert color="info" title="Note" %}}
Aspose.Slides, lisansleme işlemleri için [License](https://reference.aspose.com/slides/java/com.aspose.slides/license/) sınıfını sağlar.
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
Yeni lisanslar, Aspose.Slides'ı yalnızca 21.4 veya sonraki sürümlerde etkinleştirebilir. Daha eski sürümler farklı bir lisanslama sistemi kullanır ve bu lisansları tanımaz.
{{% /alert %}}

### **Dosya**

Lisans ayarlamanın en kolay yöntemi, lisans dosyasını Aspose.Slides.jar içeren klasöre veya uygulamanızın jar dosyasına yerleştirmenizi gerektirir.

``` java
// Lisans sınıfını örnekler
com.aspose.slides.License license = new com.aspose.slides.License();

// Lisans dosyası yolunu ayarlar
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" title="Warning" %}}
Lisans dosyasını farklı bir dizine koyarsanız, [setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.lang.String-) metodunu çağırdığınızda, belirtilen yolun sonundaki lisans dosyası adı, lisans dosyanızın adıyla aynı olmalıdır.

Örneğin, lisans dosyası adını *Aspose.Slides.Java.lic.xml* olarak değiştirebilirsiniz. Ardından, kodunuzda [setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.lang.String-) metoduna dosyanın yolunu (*Aspose.Slides.Java.lic.xml* ile biten) geçirmeniz gerekir.
{{% /alert %}}

### **Akış**

Bir lisansı akıştan (stream) yükleyebilirsiniz. Bu Java kodu, bir akıştan lisans nasıl uygulanır gösterir:

``` java
// Lisans sınıfını örnekler
com.aspose.slides.License license = new com.aspose.slides.License();

// Lisansı bir akış üzerinden ayarlar
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

Java üzerinden PHP için Aspose.Slides kullanıyorsanız, bir PHP/Java köprüsü aracılığıyla lisans ayarlayabilirsiniz. Bu köprü, Java sınıflarını PHP sözdiziminde kullanmanıza olanak tanır. Daha fazla bilgi için [License in PHP](/slides/tr/php-java/licensing/) sayfasına bakın.

## **Lisansı Doğrulama**

Bir lisansın doğru şekilde ayarlanıp ayarlanmadığını kontrol etmek için doğrulayabilirsiniz. Bu Java kodu, bir lisansı nasıl doğrulayacağınızı gösterir:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **İş Parçacığı Güvenliği**

{{% alert color="warning" title="Warning" %}}
[setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.io.InputStream-) metodu iş parçacığı güvenli değildir. Bu metodun birçok iş parçacığından aynı anda çağrılması gerekiyorsa, sorunları önlemek için senkronizasyon primitifleri (örneğin bir kilit) kullanmak isteyebilirsiniz.
{{% /alert %}}

## **FAQ**

### Lisansı tamamen çevrim dışı bir ortamda (internet bağlantısı olmadan) uygulayabilir miyim?

Evet. Lisans doğrulaması, lisans dosyası kullanılarak yerel olarak yapılır; internet bağlantısı gerekmez.

### Bir yıllık abonelik süresi dolduğunda ne olur? Kütüphane çalışmayı durdurur mu?

Hayır. Lisans süresizdir: abonelik bitiş tarihinizden önce yayınlanan sürümleri kullanmaya devam edebilirsiniz; ancak yenilerini yenilemeden kullanamazsınız.