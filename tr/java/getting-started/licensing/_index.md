---
title: Lisanslama
type: docs
weight: 90
url: /tr/java/licensing/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da lisansları uygulayın, yönetin ve sorunlarını giderin. Adım adım lisanslama kılavuzumuzla tam özelliklere kesintisiz erişimi sağlayın."
---
## **Genel Bakış**

Aspose.Slides, değerlendirme modunda veya geçerli bir lisansla kullanılabilir. Değerlendirme sürümü, lisanslı sürümle aynı işlevselliği sağlar, ancak sunumlar açıldığında veya kaydedildiğinde bir değerlendirme filigranı ekler ve metin çıkarımını yalnızca bir slaytla sınırlar.

Bu makale, Aspose.Slides'de lisanslamanın nasıl çalıştığını ve kütüphaneyi kullanmadan önce nasıl lisans uygulanacağını açıklar. Bir lisans, `License` sınıfı kullanılarak dosyadan, akıştan veya gömülü kaynaktan yüklenebilir. Makale ayrıca bir lisansın doğru şekilde uygulanıp uygulanmadığını nasıl doğrulayacağınızı gösterir.

## **Aspose.Slides'ı Değerlendirin**

{{% alert color="info" %}} 

Bir değerlendirme sürümünü **Aspose.Slides for Java**'nın [indirme sayfası](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) üzerinden indirebilirsiniz. Değerlendirme sürümü, ürünün lisanslı sürümüyle aynı işlevleri sunar. Değerlendirme paketi, satın alınan paketle aynıdır. Değerlendirme sürümü, lisansı uygulamak için birkaç satır kod eklediğinizde basitçe lisanslı hâle gelir.

Aspose.Slides'ı değerlendirmeden memnun kaldığınızda, bir [lisans satın alabilirsiniz](https://purchase.aspose.com/buy). Farklı abonelik tiplerini incelemenizi öneririz. Sorularınız varsa, Aspose satış ekibiyle iletişime geçin.

Her Aspose lisansı, abonelik süresi içinde yayınlanan yeni sürümlere veya düzeltmelere ücretsiz yükseltme sağlayan bir yıllık abonelik içerir. Lisanslı ürünleri (ve hatta değerlendirme sürümleri) kullanan kullanıcılar ücretsiz ve sınırsız teknik destek alır.

{{% /alert %}} 

**Değerlendirme sürümü sınırlamaları**

* Lisans belirtilmemiş Aspose.Slides değerlendirme sürümü tam ürün işlevselliği sunsa da, açma ve kaydetme işlemlerinde belgenin üst kısmına bir değerlendirme filigranı ekler. 
* Sunum slaytlarından metin çıkartırken yalnızca bir slaytla sınırlısınız.

{{% alert color="info" %}} 

Aspose.Slides'ı sınırlama olmadan test etmek için **30-Day Temporary License** isteyebilirsiniz. Daha fazla bilgi için [Geçici Lisans Nasıl Alınır](https://purchase.aspose.com/temporary-license) sayfasına bakın.

{{% /alert %}}

## **Aspose.Slides'da Lisanslama**

* Bir değerlendirme sürümü, lisans satın alındıktan ve birkaç satır kod eklendikten sonra lisanslı hâle gelir. 
* Lisans, ürün adı, lisanslı geliştirici sayısı, abonelik son tarihi vb. detayları içeren düz metin XML dosyasıdır. 
* Lisans dosyası dijital olarak imzalanmıştır; bu nedenle dosyayı değiştirmemelisiniz. Dosyanın içeriğine istemsiz bir satır sonu eklenmesi bile lisansı geçersiz kılar. 
* Aspose.Slides for Java genellikle lisansı şu konumlarda arar:
  * Açık bir yol
  * Aspose.Slides.jar dosyasının bulunduğu klasör
* Değerlendirme sürümüyle ilişkili sınırlamalardan kaçınmak için **Aspose.Slides**'ı kullanmadan önce bir lisans ayarlamanız gerekir. Bir uygulama veya süreç başına yalnızca bir kez lisans ayarlamanız yeterlidir.

{{% alert color="info" %}} 

[Ölçülü Lisanslama](/slides/tr/java/metered-licensing/) sayfasına göz atmak isteyebilirsiniz.

{{% /alert %}} 


## **Lisans Uygulama**

Bir lisans, **dosya** veya **akış** üzerinden yüklenebilir.

{{% alert color="info" %}}

Aspose.Slides, lisans işlemleri için [License](https://reference.aspose.com/slides/tr/java/com.aspose.slides/License) sınıfını sağlar.

{{% /alert %}} 

{{% alert color="warning" %}}

Yeni lisanslar yalnızca 21.4 veya sonraki sürümlerde Aspose.Slides'ı etkinleştirebilir. Daha eski sürümler farklı bir lisans sistemi kullanır ve bu lisansları tanımaz.

{{% /alert %}}

### **Dosya**

Lisans ayarlamanın en kolay yöntemi, lisans dosyasını Aspose.Slides.jar dosyasının bulunduğu klasöre veya uygulamanızın jar dosyasına yerleştirmenizi gerektirir.

Bu Java kodu, bir lisans dosyasının nasıl ayarlanacağını gösterir:

``` java
// Lisans sınıfının bir örneğini oluşturur
com.aspose.slides.License license = new com.aspose.slides.License();

// Lisans dosyası yolunu ayarlar
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" %}} 

Lisans dosyasını farklı bir dizine koyarsanız, [SetLicense](https://reference.aspose.com/slides/tr/java/com.aspose.slides/License#setLicense-java.lang.String-) metodunu çağırdığınızda belirtilen açık yolun sonundaki lisans dosyası adı, lisans dosyanızla aynı olmalıdır.

Örneğin, lisans dosya adını *Aspose.Slides.Java.lic.xml* olarak değiştirebilirsiniz. Ardından kodunuzda, dosyanın yolunu (sonu *Aspose.Slides.Java.lic.xml* olacak şekilde) [SetLicense](https://reference.aspose.com/slides/tr/java/com.aspose.slides/License#setLicense-java.lang.String-) metoduna iletmeniz gerekir.

{{% /alert %}}

### **Akış**

Bir lisansı akıştan yükleyebilirsiniz. Bu Java kodu, bir akıştan lisansın nasıl uygulanacağını gösterir:

``` java
// Lisans sınıfının bir örneğini oluşturur
com.aspose.slides.License license = new com.aspose.slides.License();

// Lisansı bir akış aracılığıyla ayarlar
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Köprüsü**

Java aracılığıyla PHP için Aspose.Slides kullanıyorsanız, bir PHP/Java köprüsü üzerinden lisans ayarlayabilirsiniz. Bu köprü, PHP sözdiziminde Java sınıflarını kullanmanıza olanak tanır. Daha fazla bilgi için [PHP'de Lisans](/slides/tr/php-java/licensing/) sayfasına bakın.

## **Lisansı Doğrulama**

Bir lisansın doğru şekilde ayarlanıp ayarlanmadığını kontrol etmek için onu doğrulayabilirsiniz. Bu Java kodu, bir lisansın nasıl doğrulanacağını gösterir:

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

{{% alert title="Note" color="warning" %}} 

[SetLicense](https://reference.aspose.com/slides/tr/java/com.aspose.slides/License#setLicense-java.io.InputStream-) metodu iş parçacığı güvenli değildir. Bu metodun çok sayıda iş parçacığı tarafından aynı anda çağrılması gerekiyorsa, sorunları önlemek için bir kilit gibi eşzamanlama primitifleri kullanmanız önerilir. 

{{% /alert %}}

## **SSS**

### Lisansı tamamen çevrim dışı bir ortamda (internet erişimi olmadan) uygulayabilir miyim?

Evet. Lisans doğrulaması, lisans dosyası yerel olarak kullanılarak yapılır; internet bağlantısı gerekmez.

### Bir yıllık abonelik sona erdikten sonra ne olur? Kütüphane çalışmayı durdurur mu?

Hayır. Lisans süresizdir: abonelik bitiş tarihinizden önce yayınlanan sürümleri kullanmaya devam edebilirsiniz; ancak yenilerini kullanmak için aboneliği yenilemeniz gerekir.