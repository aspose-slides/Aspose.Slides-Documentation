---
title: Lisanslama
type: docs
weight: 80
url: /tr/nodejs-java/licensing/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js içinde lisansları uygulayın, yönetin ve sorun giderin. Adım adım lisanslama rehberimizle tam özelliklere kesintisiz erişimi sağlayın."
---
## **Giriş**

Bazen, en iyi değerlendirme sonuçları için uygulamalı bir yaklaşım gerekebilir. Bu nedenle, Aspose.Slides farklı satın alma planları sunar ve ayrıca ücretsiz bir deneme sürümü ve 30 günlük geçici lisans sağlar.

{{% alert color="primary" %}}
Lütfen değerlendirme, doğru lisanslama ve ürünlerimizi satın alma konusunda size rehberlik edecek bir dizi genel politika ve uygulamanın olduğunu unutmayın. Bunları ["Satın Alma Politikaları ve SSS"](https://purchase.aspose.com/policies) bölümünde bulabilirsiniz.
{{% /alert %}}

## **Aspose.Slides'ı Değerlendirin**
Aspose.Slides'ı değerlendirme amaçlı kolayca indirebilirsiniz. Değerlendirme paketi, satın alınan paketle aynı içeriktedir. Değerlendirme sürümü, bir kaç satır kod ekleyip lisansı uyguladığınızda lisanslı hâle gelir. 

## **Değerlendirme Sürümü Sınırlamaları**
Lisans belirtilmemiş Aspose.Slides değerlendirme sürümü tam ürün işlevselliğini sağlar, ancak belgeyi açtığınızda ve kaydettiğinizde sayfanın üstüne bir değerlendirme filigranı ekler. Ayrıca sunum slaytlarından metin çıkarırken yalnızca bir slaytla sınırlısınız.

{{% alert color="primary" %}} 
Değerlendirme sürümü sınırlamaları olmadan Aspose.Slides'ı test etmek istiyorsanız **30 Günlük Geçici Lisans** talep edebilirsiniz. Daha fazla bilgi için [Geçici Lisans Nasıl Alınır?](https://purchase.aspose.com/temporary-license) sayfasına bakın.
{{% /alert %}} 

## **Lisans Hakkında**
Node.js üzerinden Java ile Aspose.Slides değerlendirme sürümünü [indirme sayfasından](https://releases.aspose.com/slides/tr/nodejs-java/) kolayca edinebilirsiniz. Değerlendirme sürümü, lisanslı Aspose.Slides sürümüyle **aynı yetenekleri** sunar. Ayrıca lisansı satın alıp birkaç satır kod ekleyerek değerlendirme sürümü lisanslı hâle gelir.

Lisans, ürün adı, lisanslanan geliştirici sayısı, abonelik bitiş tarihi vb. bilgileri içeren düz metin XML dosyasıdır. Dosya dijital olarak imzalanmıştır; bu yüzden dosyada değişiklik yapmayın. Dosyanın içeriğine istemeden bir satır sonu eklemek bile lisansı geçersiz kılar.

Değerlendirme sürümüne ilişkin sınırlamaları önlemek için **Aspose.Slides** kullanmadan önce bir lisans ayarlamanız gerekir. Bir uygulama veya süreç için lisansı yalnızca bir kez ayarlamanız yeterlidir.

{{% alert color="primary" %}} 
[Metered Lisanslama](https://docs.aspose.com/slides/tr/nodejs-java/metered-licensing/) sayfasına göz atmak isteyebilirsiniz.
{{% /alert %}} 

## **Satın Alınan Lisans**

Satın alım sonrası lisans dosyasını veya akışını uygulamanız gerekir. 

{{% alert color="primary" %}}
Lisansı ayarlamanız gerekir:
* uygulama etki alanı başına sadece bir kez
* herhangi bir Aspose.Slides sınıfını kullanmadan önce
{{% /alert %}}

{{% alert color="primary" %}}
Fiyatlandırma bilgilerini [“Fiyatlandırma Bilgileri”](https://purchase.aspose.com/pricing/slides/tr/family) sayfasında bulabilirsiniz.
{{% /alert %}}

### **Aspose.Slides için Node.js üzerinden Java'da Lisans Ayarlama**

Lisanslar şu konumlardan uygulanabilir:

* Açık yol
* Akış
* Metered Lisans olarak – yeni bir lisans mekanizması

{{% alert color="primary" %}}
Bir bileşeni lisanslamak için **setLicense** metodunu kullanın.

Birden fazla **setLicense** çağrısı zararlı olmasa da gereksiz kaynak (işlemci) tüketir.
{{% /alert %}}

{{% alert color="warning" %}}
Yeni lisanslar yalnızca 21.4 ve üzeri sürümlerde Aspose.Slides'ı etkinleştirebilir. Daha eski sürümler farklı bir lisans sistemi kullanır ve bu lisansları tanımaz.
{{% /alert %}}

#### **Bir Dosya Kullanarak Lisans Uygulama**

Bu kod parçacığı bir lisans dosyasını ayarlamak için kullanılır:

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();
license.setLicense("Aspose.Slides.lic");
```

setLicense metodunu çağırdığınızda lisans adı, lisans dosyanızın adıyla aynı olmalıdır. Örneğin lisans dosyasının adını "Aspose.Slides.lic.xml" olarak değiştirebilirsiniz. Ardından kodunuzda yeni lisans adını (Aspose.Slides.lic.xml) setLicense metoduna geçirmeniz gerekir.

#### **Akıştan Lisans Uygulama**

Bu kod parçacığı bir akıştan lisans uygulamak için kullanılır:

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();

var fs = require("fs");

var readStream = fs.createReadStream("Aspose.Slides.lic");

license.setLicense(readStream, function(err, list) {
    if(err) { 
        console.error(err); return; 
    }});
```

## **SSS**

**Lisansı tamamen çevrim dışı bir ortamda (internet erişimi olmadan) uygulayabilir miyim?**

Evet. Lisans doğrulaması yerel olarak lisans dosyasıyla yapılır; internet bağlantısı gerekmez.

**Bir yıllık abonelik sona erdiğinde ne olur? Kütüphane çalışmayı durdurur mu?**

Hayır. Lisans süresizdir: abonelik bitiş tarihinizden önce yayınlanan sürümleri kullanmaya devam edebilirsiniz; ancak yenilerini kullanmak için yenilemeniz gerekir.