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
- lisans doğrula
- lisans dosyası
- değerlendirme sürümü
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java’da lisansları uygulayın, yönetin ve sorunlarını giderin. Adım adım lisanslama rehberimizle tam özelliklere kesintisiz erişimi sağlayın."
---
## **Genel Bakış**

Aspose.Slides, değerlendirme modunda veya geçerli bir lisansla kullanılabilir. Değerlendirme sürümü, lisanslı sürümle aynı işlevselliği sağlasa da sunumlar açıldığında veya kaydedildiğinde bir değerlendirme filigranı ekler ve metin çıkarımını bir slaytla sınırlı tutar.

Bu makale, Aspose.Slides’da lisanslamanın nasıl çalıştığını ve kitaplığı kullanmadan önce nasıl lisans uygulanacağını açıklar. Bir lisans, `License` sınıfı kullanılarak bir dosyadan, akıştan veya gömülü kaynaktan yüklenebilir. Makale ayrıca bir lisansın doğru şekilde uygulanıp uygulanmadığını nasıl doğrulayacağınızı gösterir.

## **Aspose.Slides'ı Değerlendirin**

{{% alert color="primary" %}} 
Aspose.Slides for Java’nın değerlendirme sürümünü, [download page](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) üzerinden indirebilirsiniz. Değerlendirme sürümü, ürünün lisanslı sürümüyle aynı işlevselliği sağlar. Değerlendirme paketi, satın alınan paketle aynıdır. Değerlendirme sürümü, lisansı uygulamak için birkaç satır kod eklediğinizde basitçe lisanslı hâle gelir.

**Aspose.Slides** değerlendirmesinden memnun kaldığınızda bir [purchase a license](https://purchase.aspose.com/buy) alabilirsiniz. Çeşitli abonelik türlerini incelemenizi öneririz. Sorularınız varsa Aspose satış ekibiyle iletişime geçin.

Her Aspose lisansı, abonelik süresi içinde yeni sürümler veya hata düzeltmeleri için ücretsiz yükseltmeler sağlayan bir yıllık abonelikle birlikte gelir. Lisanslı ürün (veya değerlendirme sürümü) kullanan kullanıcılar ücretsiz ve sınırsız teknik destek alır.
{{% /alert %}} 

**Değerlendirme sürümü sınırlamaları**

* Lisans belirtilmemiş Aspose.Slides değerlendirme sürümü tam ürün işlevselliği sağlasa da, açma ve kaydetme işlemlerinde belgenin en üstüne bir değerlendirme filigranı ekler. 
* Sunum slaytlarından metin çıkarırken sadece bir slaytla sınırlısınız.

{{% alert color="primary" %}} 
Sınırlamaları olmadan Aspose.Slides’ı denemek isterseniz **30-Day Temporary License** talep edebilirsiniz. Daha fazla bilgi için [How to get a Temporary License](https://purchase.aspose.com/temporary-license) sayfasına bakın.
{{% /alert %}}

## **Aspose.Slides'da Lisanslama**

* Değerlendirme sürümü, bir lisans satın alıp birkaç satır kod ekledikten sonra lisanslı hâle gelir (lisansı uygulamak için).
* Lisans, ürün adı, lisanslı geliştirici sayısı, abonelik son tarih vb. bilgileri içeren düz metin XML dosyasıdır. 
* Lisans dosyası dijital olarak imzalıdır; dosyayı değiştirmeniz yasaktır. Dosyanın içeriğine istem dışı bir satır sonu eklenmesi bile lisansı geçersiz kılar.
* Aspose.Slides for Java genellikle lisansı şu konumlardan arar:
  * Açık bir yol
  * Aspose.Slides.jar dosyasının bulunduğu klasör
* Değerlendirme sürümünün sınırlamalarından kaçınmak için **Aspose.Slides** kullanmadan önce bir lisans ayarlamanız gerekir. Bir uygulama veya işlem başına yalnızca bir kez lisans ayarlamanız yeterlidir.

{{% alert color="primary" %}} 
[Metered Licensing](/slides/tr/java/metered-licensing/) sayfasına göz atmak isteyebilirsiniz.
{{% /alert %}} 

## **Lisansı Uygulama**

Bir lisans **dosya** veya **akış** üzerinden yüklenebilir.

{{% alert color="primary" %}}
Aspose.Slides, lisanslama işlemleri için [License](https://reference.aspose.com/slides/tr/java/com.aspose.slides/License) sınıfını sağlar.
{{% /alert %}} 

{{% alert color="warning" %}}
Yeni lisanslar yalnızca 21.4 ve sonraki sürümlerle Aspose.Slides’ı etkinleştirebilir. Daha eski sürümler farklı bir lisanslama sistemi kullanır ve bu lisansları tanımaz.
{{% /alert %}}

### **Dosya**

Lisans ayarlamanın en kolay yöntemi, lisans dosyasını Aspose.Slides.jar’ın bulunduğu klasöre veya uygulamanızın jar’ına yerleştirmektir.

Bu Java kodu, bir lisans dosyasının nasıl ayarlanacağını gösterir:

``` java
// Lisans sınıfını örnekler
com.aspose.slides.License license = new com.aspose.slides.License();

// Lisans dosyası yolunu ayarlar
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" %}} 
Lisans dosyasını farklı bir dizine koyarsanız, [SetLicense](https://reference.aspose.com/slides/tr/java/com.aspose.slides/License#setLicense-java.lang.String-) metodunu çağırdığınızda, belirtilen açık yolun sonundaki lisans dosyası adı lisans dosyanızla aynı olmalıdır.

Örneğin, lisans dosyasının adını *Aspose.Slides.Java.lic.xml* olarak değiştirebilirsiniz. Ardından kodunuzda, dosyanın yolunu ( *Aspose.Slides.Java.lic.xml* ile biten ) [SetLicense](https://reference.aspose.com/slides/tr/java/com.aspose.slides/License#setLicense-java.lang.String-) metoduna geçirmeniz gerekir.
{{% /alert %}}

### **Akış**

Bir lisansı akıştan yükleyebilirsiniz. Bu Java kodu, bir akıştan lisans uygulamanın nasıl yapılacağını gösterir:

``` java
// Lisans sınıfını oluşturur
com.aspose.slides.License license = new com.aspose.slides.License();

// Lisansı bir akış üzerinden ayarlar
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Köprüsü**

Java üzerinden PHP için Aspose.Slides kullanıyorsanız, bir PHP/Java köprüsü aracılığıyla lisans ayarlayabilirsiniz. Bu köprü, Java sınıflarını PHP sözdiziminde kullanmanıza izin verir. Daha fazla bilgi için [License in PHP](/slides/tr/php-java/licensing/) sayfasına bakın.

## **Lisansı Doğrulama**

Bir lisansın doğru şekilde ayarlanıp ayarlanmadığını kontrol etmek için doğrulama yapabilirsiniz. Bu Java kodu, bir lisansın nasıl doğrulanacağını gösterir:

```java
License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **İş Parçacığı Güvenliği**

{{% alert title="Note" color="warning" %}} 
[SetLicense](https://reference.aspose.com/slides/tr/java/com.aspose.slides/License#setLicense-java.io.InputStream-) metodu iş parçacığı güvenli değildir. Bu metodun aynı anda birçok iş parçacığından çağrılması gerekiyorsa, sorunları önlemek için bir kilit gibi senkronizasyon ilkelileri kullanmak isteyebilirsiniz. 
{{% /alert %}}

## **SSS**

**Lisansı tamamen çevrim dışı bir ortamda (internet erişimi olmadan) uygulayabilir miyim?**

Evet. Lisans doğrulaması, lisans dosyası kullanılarak yerel olarak gerçekleştirilir; internet bağlantısı gerekmez.

**Bir yıllık abonelik süresi dolduğunda ne olur? Kütüphane çalışmayı durdurur mu?**

Hayır. Lisans süresizdir: abonelik bitiş tarihinizden önce yayınlanan sürümleri kullanmaya devam edebilirsiniz; ancak yenileme yapmadan daha yeni sürümleri kullanma hakkınız olmaz.