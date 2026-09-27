---
title: Lisanslama
type: docs
weight: 80
url: /tr/php-java/licensing/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java'da lisansları uygulayın, yönetin ve sorunları gidermeye yönelik adım adım lisanslama rehberi ile tam özelliklere kesintisiz erişimi sağlayın."
---
## **Giriş**

Bazen en iyi değerlendirme sonuçları için pratik bir yaklaşım gerekebilir. Bu nedenle Aspose.Slides farklı satın alma planları sunar ve ayrıca bir Ücretsiz Deneme ve 30 günlük Geçici Lisans sağlar.

{{% alert color="info" title="Note" %}}
Şunu unutmayın: Ürünlerimizi nasıl değerlendireceğiniz, doğru lisanslayacağınız ve satın alacağınız konusunda size rehberlik eden bir dizi genel politika ve uygulama bulunmaktadır. Bunları ["Satın Alma Politikaları ve SSS"](https://purchase.aspose.com/policies) bölümünde bulabilirsiniz.
{{% /alert %}}

## **Aspose.Slides'ı Değerlendirin**
Aspose.Slides'ı değerlendirme amaçlı kolayca indirebilirsiniz. Değerlendirme paketi, satın alınan paketle aynı olur. Değerlendirme sürümü, lisansı uygulamak için birkaç satır kod eklediğinizde otomatik olarak lisanslı hâle gelir.

## **Değerlendirme Sürümü Sınırlamaları**
Aspose.Slides'ın (lisans belirtilmemiş) değerlendirme sürümü tam ürün işlevselliğini sunar, ancak iki sınırlaması vardır:

* Kaydettiği her sunumun her slaytının ortasına bir değerlendirme filigranı metin kutusu ekler.
* Kodunuzun bir sunumdan okuduğu metin, ilk birkaç karakterine kesilir ve ardından değerlendirme sınırlaması uyarısı eklenir. Kodunuzun yazdığı metin ise tam olarak kaydedilir.

{{% alert color="info" title="Note" %}}
Aspose.Slides'ı değerlendirme sürümü sınırlamaları olmadan test etmek istiyorsanız **30 Günlük Geçici Lisans** isteyebilirsiniz. Daha fazla bilgi için [Geçici Lisans Nasıl Alınır?](https://purchase.aspose.com/temporary-license) sayfasına bakabilirsiniz.
{{% /alert %}}

## **Lisans Hakkında**
Aspose.Slides for PHP via Java'nin [indirme sayfasından](https://packagist.org/packages/aspose/slides) kolayca bir değerlendirme sürümü indirebilirsiniz. Değerlendirme sürümü, Aspose.Slides'ın lisanslı sürümüyle **tamamen aynı yetenekleri** sunar. Ayrıca, bir lisans satın alıp lisansı uygulamak için birkaç satır kod eklediğinizde değerlendirme sürümü otomatik olarak lisanslı hâle gelir.

Lisans, ürün adı, lisanslı geliştirici sayısı, abonelik son tarihi gibi ayrıntıları içeren düz metin bir XML dosyasıdır. Dosya dijital olarak imzalıdır, bu yüzden dosyada değişiklik yapmayın. Dosyanın içeriğine istemeden ek bir satır sonu eklemek bile lisansı geçersiz kılar.

Değerlendirme sürümüne ait sınırlamaları önlemek için **Aspose.Slides**'ı kullanmadan önce bir lisans ayarlamanız gerekir. Lisansı sadece uygulama veya süreç başına bir kez ayarlamanız yeterlidir.

{{% alert color="info" title="Note" %}}
İsterseniz [Ölçülü Lisanslama](/slides/tr/php-java/metered-licensing/) sayfasına bakabilirsiniz.
{{% /alert %}}

## **Satın Alınan Lisans**
Satın alımın ardından lisans dosyasını veya akışı uygulamanız gerekir.

{{% alert color="info" title="Note" %}}
Lisansı ayarlamanız gerekir:
* sadece bir uygulama alanı başına bir kez
* diğer Aspose.Slides sınıflarını kullanmadan önce
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Fiyatlandırma bilgilerini [“Fiyatlandırma Bilgileri”](https://purchase.aspose.com/pricing/slides/family) sayfasında bulabilirsiniz.
{{% /alert %}}

### **Aspose.Slides for PHP via Java'da Lisans Ayarlama**
Lisanslar aşağıdaki konumlardan uygulanabilir:

* Açık yol
* Akış
* Ölçülü Lisans olarak – yeni bir lisanslama mekanizması

{{% alert color="info" title="Note" %}}
Bir bileşeni lisanslamak için **setLicense** metodunu kullanın.

Birden fazla **setLicense** çağrısı zararlı olmasa da kaynak (işlemci) israfıdır.
{{% /alert %}}

{{% alert color="warning" title="Warning" %}}
Yeni lisanslar, sadece 21.4 veya daha sonraki sürümlerle Aspose.Slides'ı etkinleştirebilir. Daha eski sürümler farklı bir lisanslama sistemi kullandığından bu lisansları tanımaz.
{{% /alert %}}

#### **Dosya Kullanarak Lisans Uygulama**
Bu kod parçacığı bir lisans dosyası ayarlamak için kullanılır:

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/tr/lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense(__DIR__ . "/Aspose.Slides.lic");
```

Örnek, lisans dosyasının betiğin yanında olmasını bekler ve mutlak yolunu aktarır: Aspose.Slides Tomcat içinde çalıştığından, betiğinizin klasörüne göre bir göreli yolu çözümlemez. setLicense metodunu çağırırken lisans adı, lisans dosyanızın adıyla aynı olmalıdır. Örneğin, lisans dosyasının adını "Aspose.Slides.lic.xml" olarak değiştirebilirsiniz. Ardından, kodunuzda yeni lisans adını (Aspose.Slides.lic.xml) setLicense metoduna geçirmeniz gerekir.

#### **Akıştan Lisans Uygulama**
Bu kod parçacığı bir akıştan lisans uygulamak için kullanılır:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/tr/lib/aspose.slides.php");

use aspose\slides\License;

$stream = new Java("java.io.FileInputStream", __DIR__ . "/Aspose.Slides.lic");

$license = new License();
$license->setLicense($stream);

$stream->close();
```

## **SSS**

### Lisansı tamamen çevrim dışı bir ortamda (internet erişimi olmadan) uygulayabilir miyim?
Evet. Lisans doğrulaması, lisans dosyası kullanılarak yerel olarak yapılır; internet bağlantısı gerekmez.

### Bir yıllık abonelik süresi dolduktan sonra ne olur? Kütüphane çalışmayı bırakır mı?
Hayır. Lisans süresizdir: abonelik bitiş tarihinizden önce yayınlanan sürümleri kullanmaya devam edebilirsiniz; sadece yenilemeden daha yeni sürümleri kullanamazsınız.