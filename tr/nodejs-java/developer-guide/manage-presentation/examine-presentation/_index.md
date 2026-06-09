---
title: JavaScript'te Sunum Bilgilerini Alıp Güncelleme
linktitle: Sunum Bilgileri
type: docs
weight: 30
url: /tr/nodejs-java/examine-presentation/
keywords:
- sunum formatı
- sunum özellikleri
- belge özellikleri
- özellikleri al
- özellikleri oku
- özellikleri değiştir
- özellikleri düzenle
- özellikleri güncelle
- PPTX incele
- PPT incele
- ODP incele
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript kullanarak PowerPoint ve OpenDocument sunumlarındaki slaytları, yapıyı ve meta verileri keşfedin, daha hızlı içgörüler ve daha akıllı içerik denetimleri sağlayın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde sunum bilgilerini nasıl inceleyeceğinizi gösterir. Sunumun tam dosyasını yüklemeden mevcut biçimini nasıl belirleyeceğinizi, belge özelliklerini nasıl okuyacağınızı ve gerektiğinde bu özellikleri nasıl güncelleyeceğinizi açıklar.

Örnekler, [PresentationInfo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/) ve [DocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/) API’lerine dayanır ve sunum meta verileriyle çalışmak için tipik işlemleri gösterir.

## **Sunum Biçimini Kontrol Et**

Bir sunum üzerinde çalışmaya başlamadan önce, sunumun şu anda hangi biçimde (PPT, PPTX, ODP ve diğerleri) olduğunu öğrenmek isteyebilirsiniz.

Sunumun biçimini, sunumu yüklemeden kontrol edebilirsiniz. Aşağıdaki JavaScript koduna bakın:

```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **Sunum Özelliklerini Al**

Bu JavaScript kodu, sunum özelliklerini (sunumla ilgili bilgileri) nasıl alacağınızı gösterir:

```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ..
```

[DocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) sınıfı altındaki özelliklere bakmak isteyebilirsiniz.

## **Sunum Özelliklerini Güncelle**

Aspose.Slides, sunum özelliklerinde değişiklik yapmanıza olanak tanıyan [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) yöntemini sağlar.

Aşağıda gösterilen belge özelliklerine sahip bir PowerPoint sunumumuz olduğunu varsayalım.

![PowerPoint sunumunun orijinal belge özellikleri](input_properties.png)

Bu kod örneği, bazı sunum özelliklerini nasıl düzenleyeceğinizi gösterir:

```javascript
let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Belge özelliklerinin değiştirilmesinin sonuçları aşağıda gösterilmiştir.

![PowerPoint sunumunun değiştirilmiş belge özellikleri](output_properties.png)

## **Faydalı Bağlantılar**

Bir sunum ve güvenlik özellikleri hakkında daha fazla bilgi edinmek için aşağıdaki bağlantılar faydalı olabilir:

- [Sunumun Şifreli Olup Olmadığını Kontrol Etme](https://docs.aspose.com/slides/tr/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Sunumun Yazma Koruması (salt okunur) Olup Olmadığını Kontrol Etme](https://docs.aspose.com/slides/tr/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Sunumu Yüklemeden Önce Şifre Koruması Kontrolü](https://docs.aspose.com/slides/tr/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Sunumu Koruyan Şifrenin Doğrulanması](https://docs.aspose.com/slides/tr/nodejs-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **SSS**

**Sunumda gömülü fontları ve hangi fontların gömülü olduğunu nasıl kontrol edebilirim?**

Sunum düzeyinde [gömülü font bilgilerini](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) arayın, ardından bu girdileri [gerçekte kullanılan fontların](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsmanager/getfonts/) setiyle karşılaştırarak hangi fontların render için kritik olduğunu belirleyin.

**Dosyada gizli slaytlar olup olmadığını ve sayısını nasıl hızlıca öğrenebilirim?**

[Slayt koleksiyonunu](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidecollection/) yineleyin ve her slaydın [görünürlük bayrağını](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/gethidden/) inceleyin.

**Özel slayt boyutu ve yönünün kullanılıp kullanılmadığını ve varsayılanlardan farklı olup olmadığını tespit edebilir miyim?**

Evet. Mevcut [slayt boyutunu](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getslidesize/) ve yönünü standart ön ayarlarla karşılaştırın; bu, yazdırma ve dışa aktarma davranışını öngörmeye yardımcı olur.

**Grafiklerin dış veri kaynaklarına başvurup başvurmadığını hızlı bir şekilde görmenin bir yolu var mı?**

Evet. Tüm [grafikleri](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chart/) dolaşın, [veri kaynaklarını](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) kontrol edin ve verinin dahili mi yoksa bağlantı‑tabanlı mı olduğunu not edin; kırık bağlantılar da dahil.

**Render veya PDF dışa aktarmayı yavaşlatabilecek “ağır” slaytları nasıl değerlendirebilirim?**

Her slayt için nesne sayılarını toplayın, büyük resimler, şeffaflık, gölgeler, animasyonlar ve multimedya öğelerini arayın; potansiyel performans darboğazlarını işaretlemek için kaba bir karmaşıklık puanı atayın.