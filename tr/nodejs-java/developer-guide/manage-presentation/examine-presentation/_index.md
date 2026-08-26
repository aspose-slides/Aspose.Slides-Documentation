---
title: JavaScript'te Sunum Bilgilerini Al ve Güncelle
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
description: "JavaScript kullanarak PowerPoint ve OpenDocument sunumlarında slaytları, yapıyı ve meta verileri keşfedin; daha hızlı içgörüler ve daha akıllı içerik denetimleri sağlayın."
---
## **Genel Bakış**

Bu makale Aspose.Slides içinde sunum bilgilerini nasıl inceleyeceğinizi gösterir. Sunumun tam dosyasını yüklemeden geçerli formatını nasıl belirleyeceğinizi, belge özelliklerini nasıl okuyacağınızı ve gerektiğinde bu özellikleri nasıl güncelleyeceğinizi açıklar.

Örnekler, [PresentationInfo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationinfo/) ve [DocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/) API'lerine dayanır ve sunum meta verileriyle çalışmak için tipik işlemleri gösterir.

## **Sunum Formatını Kontrol Et**

Bir sunum üzerinde çalışmadan önce, o anda sunumun hangi formatta (PPT, PPTX, ODP ve diğerleri) olduğunu öğrenmek isteyebilirsiniz.

Sunumu yüklemeden bir sunumun formatını kontrol edebilirsiniz. Bu JavaScript koduna bakın:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **Sunum Özelliklerini Al**

Bu JavaScript kodu size sunum özelliklerini (sunum hakkında bilgi) nasıl alacağınızı gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// vb.
```

[DocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) sınıfı altındaki özellikleri görmek isteyebilirsiniz.

## **Sunum Özelliklerini Güncelle**

Aspose.Slides, sunum özelliklerinde değişiklik yapmanıza olanak tanıyan [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) yöntemini sağlar.

Aşağıda gösterilen belge özelliklerine sahip bir PowerPoint sunumumuz olduğunu varsayalım.

![PowerPoint sunumunun orijinal belge özellikleri](input_properties.png)

Bu kod örneği bazı sunum özelliklerini nasıl düzenleyeceğinizi gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Belge özelliklerini değiştirmenin sonuçları aşağıda gösterilmiştir.

![PowerPoint sunumunun değiştirilmiş belge özellikleri](output_properties.png)

## **Faydalı Bağlantılar**

Bir sunum ve güvenlik özellikleri hakkında daha fazla bilgi edinmek için aşağıdaki bağlantılar faydalı olabilir:

- [Sunumları Parola ile Koruma](/slides/tr/nodejs-java/password-protected-presentation/)
- [Sunumları Yazma Koruması ile Koruma](/slides/tr/nodejs-java/write-protected-presentation/)

## **SSS**

**Yazı tiplerinin gömülü olup olmadığını ve hangileri olduğunu nasıl kontrol edebilirim?**

Sunum seviyesindeki [embedded-font information](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) kısmına bakın, ardından bu girişleri [gerçekten kullanılan yazı tipleri](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsmanager/getfonts/) ile karşılaştırarak hangi yazı tiplerinin render için kritik olduğunu belirleyin.

**Dosyada gizli slaytların olup olmadığını ve sayısını nasıl hızlıca öğrenebilirim?**

[slide collection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidecollection/) içinde döngü yapın ve her slaytın [visibility flag](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/gethidden/) özelliğini inceleyin.

**Özel slayt boyutu ve yöneliminin kullanılıp kullanılmadığını ve varsayılanlardan farklı olup olmadığını nasıl tespit edebilirim?**

Evet. Mevcut [slide size](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getslidesize/) ve yönelimini standart ön ayarlarla karşılaştırın; bu, baskı ve dışa aktarma davranışını öngörmeye yardımcı olur.

**Grafiklerin harici veri kaynaklarına referans verip vermediğini hızlı bir şekilde nasıl görebilirim?**

Evet. Tüm [charts](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chart/) üzerinden geçin, [data source](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) özelliklerini kontrol edin ve verinin içsel mi yoksa bağlantı tabanlı mı olduğunu, ayrıca kırık bağlantıların olup olmadığını not edin.

**Render veya PDF dışa aktarmayı yavaşlatabilecek 'ağır' slaytları nasıl değerlendirebilirim?**

Her slayt için nesne sayılarını toplayın ve büyük görüntüler, saydamlık, gölgeler, animasyonlar ve multimedya öğelerini arayın; potansiyel performans sorunlarını işaretlemek için kaba bir karmaşıklık puanı atayın.