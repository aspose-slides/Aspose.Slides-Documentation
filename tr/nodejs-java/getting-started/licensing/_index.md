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
description: "Aspose.Slides for Node.js'de lisansları uygulayın, yönetin ve sorunları giderin. Adım adım lisanslama kılavuzumuzla tam özelliklere kesintisiz erişimi sağlayın."
---
## **Giriş**

Bazen, en iyi değerlendirme sonuçları için uygulamalı bir yaklaşım gerekebilir. Bu nedenle, Aspose.Slides farklı satın alma planları sunar ve ayrıca ücretsiz deneme ve 30 günlük geçici lisans sağlar.

{{% alert color="info" title="Note" %}}
Şunu unutmayın ki, ürünlerimizi nasıl değerlendireceğiniz, doğru lisanslayacağınız ve satın alacağınız konusunda size rehberlik eden bir dizi genel politika ve uygulama bulunmaktadır. Bunları ["Satın Alma Politikaları ve SSS"](https://purchase.aspose.com/policies) bölümünde bulabilirsiniz.
{{% /alert %}}

## **Aspose.Slides Değerlendirme**
Aspose.Slides'i değerlendirme için kolayca indirebilirsiniz. Değerlendirme paketi, satın alınan paketle aynıdır. Değerlendirme sürümü, lisansı uygulamak için birkaç satır kod eklediğinizde basitçe lisanslı hale gelir.

## **Değerlendirme Sürümü Sınırlamaları**
Aspose.Slides'in (lisans belirtilmemiş) değerlendirme sürümü tam ürün işlevselliğini sunar, ancak iki sınırlaması vardır:

* Kaydettiği her sunumun her slaytına bir değerlendirme filigranı metin kutusu ekler.
* Sunumdan kodunuzun okuduğu beş karakterden uzun metin, ilk beş karakterine kesilir ve ardından `... text has been truncated due to evaluation version limitation.` eklenir. Beş karakter veya daha az olan metin değiştirilmeden döndürülür, kodunuzun yazdığı metin ise tamamen kaydedilir.

{{% alert color="info" title="Note" %}}
Aspose.Slides'i değerlendirme sürümü sınırlamaları olmadan test etmek isterseniz, **30 Günlük Geçici Lisans** talep edebilirsiniz. Daha fazla bilgi için [Geçici Lisans Nasıl Alınır?](https://purchase.aspose.com/temporary-license) sayfasına bakın.
{{% /alert %}}

## **Lisans Hakkında**
Aspose.Slides'in Node.js (Java üzerinden) değerlendirme sürümünü [indirme sayfasından](https://releases.aspose.com/slides/tr/nodejs-java/) kolayca indirebilirsiniz. Değerlendirme sürümü, lisanslı sürümle aynı özelliklere sahiptir, ancak yukarıda açıklanan sınırlamalara tabidir. Ayrıca, lisans satın alıp lisansı uygulamak için birkaç satır kod eklediğinizde değerlendirme sürümü basitçe lisanslı hale gelir.

Lisans, ürün adı, lisanslanan geliştirici sayısı, abonelik son tarih gibi bilgileri içeren düz metin bir XML dosyasıdır. Dosya dijital olarak imzalanmıştır, bu yüzden dosyayı değiştirmeyin. Dosyanın içeriğine istemeden ekstra bir satır sonu eklenmesi bile lisansı geçersiz kılar.

Değerlendirme sürümüyle ilgili sınırlamaları önlemek için **Aspose.Slides** kullanmadan önce bir lisans ayarlamanız gerekir. Lisansı uygulamak, her uygulama veya süreç için yalnızca bir kez gereklidir.

{{% alert color="info" title="Note" %}}
İsterseniz [Metrik Lisanslama](/slides/tr/nodejs-java/metered-licensing/) sayfasına bakabilirsiniz.
{{% /alert %}}

## **Satın Alınan Lisans**
Satın alım sonrasında, lisans dosyasını veya akışını uygulamanız gerekir.

{{% alert color="info" title="Note" %}}
Lisansı ayarlamanız gerekir:
* süreç başına sadece bir kez
* başka Aspose.Slides sınıflarını kullanmadan önce
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Fiyatlandırma bilgilerini [“Fiyat Bilgileri”](https://purchase.aspose.com/pricing/slides/tr/family) sayfasında bulabilirsiniz.
{{% /alert %}}

### **Node.js (Java) için Aspose.Slides'te Lisans Ayarlama**
Lisanslar aşağıdaki konumlardan uygulanabilir:

* Açık yol
* Akış
* Metrik Lisans olarak – yeni bir lisans mekanizması

{{% alert color="info" title="Note" %}}
**setLicense** metodunu bir bileşeni lisanslamak için kullanın.

**setLicense**'e birden fazla çağrı zararlı olmasa da kaynak (işlemci) israfıdır.
{{% /alert %}}

#### **Dosya Kullanarak Lisans Uygulama**
Bu kod parçacığı bir lisans dosyasını ayarlamak için kullanılır:

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");

const license = new asposeSlides.License();
license.setLicense("Aspose.Slides.lic");
console.log("The license was applied.");

// Aspose.Slides, Node.js'in çalışmasını sürdüren bir Java sanal makinesinde çalıştığından, işlemi açıkça sonlandırın.
process.exit(0);
```

setLicense metodunu çağırdığınızda, lisans adının lisans dosyanızın adıyla aynı olması gerekir. Örneğin, lisans dosyasının adını "Aspose.Slides.lic.xml" olarak değiştirebilirsiniz. Ardından, kodunuzda yeni lisans adını (Aspose.Slides.lic.xml) setLicense metoduna geçirmeniz gerekir. Dosya eksikse veya geçerli bir lisans içermiyorsa, [setLicense](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/license/setlicense/) bir istisna fırlatır ve script hata ile sonlanır.

#### **Akıştan Lisans Uygulama**
Bir akıştan lisans uygulamak için, [License](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/license/) nesnesini ve okunabilir bir akışı statik [setLicenseFromStream](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/license/setlicense/) metoduna aktarın. Akış asenkron olarak okunur ve geri arama, akış geçerli bir lisans içermiyorsa bir hata alır:

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");

const license = new asposeSlides.License();
const readStream = fs.createReadStream("Aspose.Slides.lic");
asposeSlides.License.setLicenseFromStream(license, readStream, function (error) {
    if (error) {
        console.error("The license was not applied:", error.message);
    } else {
        console.log("The license was applied.");
    }

    // Aspose.Slides, Node.js'in çalışmasını sürdüren bir Java sanal makinesinde çalıştığından, işlemi açıkça sonlandırın.
    process.exit(0);
});
```

Lisans, akış tamamen okunduğunda ve geri arama gerçekleşmeden hemen önce uygulanır, bu yüzden diğer Aspose.Slides işlemlerine geri aramadan başlayın.

Her iki örnek de tamamlandıklarında `process.exit(0)` çağırır, çünkü Aspose.Slides'i çalıştıran Java sanal makinesi Node.js'in çalışmasını sürdürür. Bir uygulamada, süreci sonlandırmak yerine Aspose.Slides kodunuza devam edin.

## **SSS**

### Lisansı tamamen çevrimdışı bir ortamda (internet erişimi olmadan) uygulayabilir miyim?
Evet. Lisans doğrulaması, lisans dosyası kullanılarak yerel olarak gerçekleştirilir; internet bağlantısına gerek yoktur.

### Bir yıllık abonelik sona erdiğinde ne olur? Kütüphane çalışmayı durdurur mu?
Hayır. Lisans süresizdir: abonelik bitiş tarihinizden önce yayınlanan sürümleri kullanmaya devam edebilirsiniz; sadece yenileme yapmadığınız sürece daha yeni sürümleri kullanma hakkınız olmaz.