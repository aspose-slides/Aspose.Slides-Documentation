---
title: Lisanslama
description: "Aspose.Slides for Node.js via .NET, satın alma için farklı planlar sunar ve değerlendirme için Lisanslama ve Abonelik politikalarını kullanarak Ücretsiz Deneme ve 30 günlük Geçici Lisans sağlar."
type: docs
weight: 80
url: /tr/nodejs-net/licensing/
---
Bazen, en iyi değerlendirme sonuçları için pratik bir yaklaşım gerekebilir. Bu nedenle, Aspose.Slides farklı satın alma planları sunar ve ayrıca ücretsiz deneme ve değerlendirme için 30 günlük geçici lisans sağlar.

{{% alert color="primary" %}}
Ürünlerimizi değerlendirmenize, uygun lisanslamanıza ve satın almanıza rehberlik eden bir dizi genel politika ve uygulama olduğunu unutmayın. Bu politikaları ["Satın Alma Politikaları ve SSS"](https://purchase.aspose.com/policies) bölümünde bulabilirsiniz.
{{% /alert %}}

## **Aspose.Slides'ı Değerlendirin**
Aspose.Slides'i değerlendirme amacıyla kolayca indirebilirsiniz. Değerlendirme paketi, satın alınan paketle aynı içeriktedir. Değerlendirme sürümü, lisansı uygulamak için birkaç satır kod eklediğinizde otomatik olarak lisanslı hâle gelir.

## **Değerlendirme Sürümü Sınırlamaları**
Lisans belirtilmemiş Aspose.Slides değerlendirme sürümü tam ürün işlevselliğini sağlar, ancak açma ve kaydetme sırasında belgenin üst kısmına bir değerlendirme filigranı ekler. Ayrıca sunum slaytlarından metin çıkarırken yalnızca bir slaytla sınırlısınız.

{{% alert color="primary" %}}
Değerlendirme sürümü sınırlamaları olmadan Aspose.Slides'i test etmek istiyorsanız **30 Günlük Geçici Lisans** talep edebilirsiniz. Daha fazla bilgi için [Geçici Lisans Nasıl Alınır?](https://purchase.aspose.com/temporary-license) bölümüne bakın.
{{% /alert %}}

## **Lisans Hakkında**
Aspose.Slides for Node.js via .NET'in değerlendirme sürümünü [indirme sayfasından](https://releases.aspose.com/slides/tr/nodejs-net/) kolayca indirebilirsiniz. Değerlendirme sürümü, Aspose.Slides'in lisanslı sürümüyle **tamamen aynı yetenekleri** sunar. Ayrıca, bir lisans satın alıp birkaç satır kod eklediğinizde değerlendirme sürümü otomatik olarak lisanslı hâle gelir.

Lisans, ürün adı, lisanslı geliştirici sayısı, abonelik son tarihi gibi ayrıntıları içeren düz metin XML dosyasıdır. Dosya dijital olarak imzalanmıştır, bu yüzden dosyayı değiştirmeyin. Dosyanın içeriğine istem dışı bir satır sonu eklemek bile lisansı geçersiz kılar.

Değerlendirme sürümüyle gelen sınırlamaları önlemek için **Aspose.Slides**'i kullanmadan önce bir lisans ayarlamanız gerekir. Lisansı yalnızca uygulama veya işlem başına bir kez ayarlamanız yeterlidir.

## **Satın Alınan Lisans**
Satın alım sonrasında lisans dosyasını veya akışını uygulamanız gerekir.

{{% alert color="primary" %}}
Lisansı ayarlamanız gerekir:
* yalnızca bir kez uygulama alanı başına
* Aspose.Slides'in diğer sınıflarını kullanmadan önce
{{% /alert %}}

{{% alert color="primary" %}}
Fiyatlandırma bilgilerini [“Fiyatlandırma Bilgileri”](https://purchase.aspose.com/pricing/slides/tr/family) sayfasında bulabilirsiniz.
{{% /alert %}}

### **Aspose.Slides for Node.js via .NET'te Lisans Ayarlama**

Lisanslar şu konumlardan uygulanabilir:
* Açık yol
* Akış
* Ölçümlü Lisans olarak – yeni bir lisanslama mekanizması

{{% alert color="primary" %}}
Bir bileşeni lisanslamak için **setLicense** metodunu kullanın.

**setLicense**'e birden çok kez çağrı yapılması zararlı olmasa da, kaynak (işlemci) israfıdır.
{{% /alert %}}

{{% alert color="warning" %}}
Yeni lisanslar, Aspose.Slides'i yalnızca 21.4 veya sonraki sürümlerde etkinleştirebilir. Daha eski sürümler farklı bir lisanslama sistemi kullanır ve bu lisansları tanımaz.
{{% /alert %}}

#### **Dosya Kullanarak Lisans Uygulama**

Bu kod parçacığı bir lisans dosyasını ayarlamak için kullanılır:

**Node.js**

```javascript
// PowerPoint dosyası işleme için Aspose.Slides modülünü içe aktar
const asposeSlides = require('aspose.slides.via.net');

// Bu işlev Aspose.Slides kütüphanesini bir lisansla kurar
function setupAsposeSlidesLicense() {
	
    // Aspose.Slides modülünden License sınıfını başlat
    var license = new asposeSlides.License();
    
    // Lisansı bir dosyadan uygula
    // "your_license_file.lic" ifadesini gerçek lisans dosyanızın yolu ile değiştirin
    license.setLicense("your_license_file.lic");
}

// Aspose.Slides için lisansı kurmak üzere işlevi çalıştır
setupAsposeSlidesLicense();
```
{{% alert color="primary" %}}
setLicense metodunu çağırırken, lisans adı lisans dosyanızın adıyla aynı olmalıdır. Örneğin, lisans dosyasının adını "Aspose.Slides.lic.xml" olarak değiştirebilirsiniz. Ardından, kodunuzda yeni lisans adını (Aspose.Slides.lic.xml) setLicense metoduna geçirmeniz gerekir.
{{% /alert %}}