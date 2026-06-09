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
description: "Aspose.Slides for PHP via Java içinde lisansları uygulayın, yönetin ve sorun giderin. Adım adım lisanslama kılavuzumuzla tam özelliklere kesintisiz erişimi sağlayın."
---
## **Giriş**

Bazen en iyi değerlendirme sonuçları için uygulamalı bir yaklaşım gerekebilir. Bu nedenle, Aspose.Slides farklı satın alma planları sunar ve ayrıca ücretsiz deneme ve 30 günlük geçici lisans sağlar.

{{% alert color="primary" %}}
Ürünlerimizi nasıl değerlendireceğiniz, doğru bir şekilde lisanslayacağınız ve satın alacağınız konusunda size rehberlik eden çeşitli genel politika ve uygulamaların bulunduğunu unutmayın. Bunları ["Satın Alma Politikaları ve SSS"](https://purchase.aspose.com/policies) bölümünde bulabilirsiniz.
{{% /alert %}}

## **Aspose.Slides’ı Değerlendirin**
Aspose.Slides'ı değerlendirme amacıyla kolayca indirebilirsiniz. Değerlendirme paketi, satın alınan paketle aynıdır. Değerlendirme sürümü, lisansı uygulamak için birkaç satır kod eklediğinizde sadece lisanslı hâle gelir. 

## **Değerlendirme Sürümü Sınırlamaları**
Lisans belirtilmemiş Aspose.Slides değerlendirme sürümü tam ürün işlevselliğini sağlar, ancak belgeyi açtığınızda ve kaydettiğinizde belge üst kısmına bir değerlendirme filigranı ekler. Sunum slaytlarından metin çıkarırken ayrıca yalnızca bir slaytla sınırlısınız.

{{% alert color="primary" %}} 
Aspose.Slides'ı değerlendirme sürümü sınırlamaları olmadan test etmek isterseniz **30 Günlük Geçici Lisans** isteyebilirsiniz. Daha fazla bilgi için [Geçici Lisans Nasıl Alınır?](https://purchase.aspose.com/temporary-license) bölümüne bakın.
{{% /alert %}} 

## **Lisans Hakkında**
Aspose.Slides for PHP via Java'nin [indirme sayfasından](https://packagist.org/packages/aspose/slides) değerlendirme sürümünü kolayca indirebilirsiniz. Değerlendirme sürümü, Aspose.Slides lisanslı sürümüyle **tamamen aynı yetenekleri** sunar. Ayrıca, bir lisans satın alıp lisansı uygulamak için birkaç satır kod eklediğinizde değerlendirme sürümü sadece lisanslı hâle gelir.

Lisans, ürün adı, lisanslı geliştirici sayısı, abonelik son tarih gibi bilgileri içeren düz metin bir XML dosyasıdır. Dosya dijital olarak imzalıdır, bu yüzden dosyayı değiştirmeyin. Dosya içeriğine istemeden ekstra bir satır sonu eklemek bile lisansı geçersiz kılar.

Değerlendirme sürümüyle ilişkili sınırlamaları önlemek için **Aspose.Slides** kullanmadan önce bir lisans ayarlamanız gerekir. Lisansı yalnızca uygulama ya da işlem başına bir kez ayarlamanız yeterlidir.

{{% alert color="primary" %}} 
İsterseniz [Metered Lisanslama](https://docs.aspose.com/slides/tr/php-java/metered-licensing/) sayfasına bakabilirsiniz.
{{% /alert %}} 

## **Satın Alınan Lisans**

Satın alım sonrası, lisans dosyasını ya da akışını uygulamanız gerekir. 

{{% alert color="primary" %}}
Lisansı ayarlamanız gerekir:
* uygulama alanı başına yalnızca bir kez
* diğer Aspose.Slides sınıflarını kullanmadan önce
{{% /alert %}}

{{% alert color="primary" %}}
Fiyatlandırma bilgilerini [“Fiyatlandırma Bilgileri”](https://purchase.aspose.com/pricing/slides/tr/family) sayfasında bulabilirsiniz.
{{% /alert %}}

### **Aspose.Slides for PHP via Java’da Lisans Ayarlama**

Lisanslar aşağıdaki konumlardan uygulanabilir:

* Belirli yol
* Akış
* Metered Lisans olarak – yeni bir lisanslama mekanizması

{{% alert color="primary" %}}
**setLicense** yöntemini bir bileşeni lisanslamak için kullanın.

**setLicense**'e birden fazla kez çağırmak zararlı olmasa da kaynak (işlemci) israfıdır.
{{% /alert %}}

{{% alert color="warning" %}}
Yeni lisanslar sadece 21.4 veya daha sonraki Aspose.Slides sürümlerinde etkinleştirilebilir. Daha eski sürümler farklı bir lisanslama sistemi kullanır ve bu lisansları tanımaz.
{{% /alert %}}

#### **Bir Dosya Kullanarak Lisans Uygulama**

Bu kod parçası bir lisans dosyasını ayarlamak için kullanılır:

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense("Aspose.Slides.lic");
?>
```

setLicense yöntemini çağırırken, lisans adı lisans dosyanızın adıyla aynı olmalıdır. Örneğin, lisans dosyasının adını "Aspose.Slides.lic.xml" olarak değiştirebilirsiniz. Ardından, kodunuzda yeni lisans adını (Aspose.Slides.lic.xml) setLicense yöntemine geçirmeniz gerekir.

#### **Bir Akıştan Lisans Uygulama**

Bu kod parçası bir akıştan lisans uygulamak için kullanılır:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense($stream);
?>
```

## **SSS**

**Lisansı tamamen çevrim dışı bir ortamda (internet erişimi olmadan) uygulayabilir miyim?**

Evet. Lisans doğrulaması, lisans dosyası kullanılarak yerel olarak yapılır; internet bağlantısı gerekmez.

**Bir yıllık abonelik sona erdiğinde ne olur? Kütüphane çalışmayı durduracak mı?**

Hayır. Lisans kalıcıdır: abonelik bitiş tarihinizden önce yayımlanan sürümleri kullanmaya devam edebilirsiniz; yalnızca yenileme yapmadığınız sürece daha yeni sürümleri kullanma hakkınız olmayacaktır.