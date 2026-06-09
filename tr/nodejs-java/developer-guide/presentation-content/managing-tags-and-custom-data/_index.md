---
title: JavaScript Kullanarak Sunumlarda Etiketleri ve Özel Verileri Yönetme
linktitle: Etiketler ve Özel Veri
type: docs
weight: 300
url: /tr/nodejs-java/managing-tags-and-custom-data/
keywords:
- belge özellikleri
- etiket
- özel veri
- etiket ekle
- çift değerler
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js'te etiketleri ve özel verileri ekleme, okuma, güncelleme ve kaldırma yöntemlerini, PowerPoint ve OpenDocument sunumları için örneklerle öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'in PowerPoint sunumlarındaki etiketler ve özel verilerle nasıl çalıştığını açıklar. PPTX dosyalarında verilerin nasıl depolandığını kısaca özetler, sunuma özgü verilerin etiketler ve özel XML bölümleri olarak bulunabileceğini belirtir ve etiketleri anahtar‑değer dize çiftleri olarak tanımlar.

Ayrıca etiket değerlerinin nasıl okunacağını ve bir sunuma, tek bir slayta veya bir şekle nasıl etiket ekleneceğini gösterir. Ek olarak, makale tüm etiketlerin temizlenmesi, bir etiketin adını kullanarak kaldırılması ve etiket adlarının listesinin alınması gibi yaygın etiket yönetimi görevlerini kapsar.

## **Sunum Dosyalarında Veri Depolama**

PPTX dosyaları—.pptx uzantısına sahip öğeler—Office Open XML (OOXML) spesifikasyonunun bir parçası olan PresentationML formatında depolanır. Office Open XML formatı, sunumlarda bulunan verilerin yapısını tanımlar. 

*Slayt*, sunumlardaki öğelerden biri olduğundan, bir *slayt bölümü* tek bir slaytın içeriğini barındırır. Bir slayt bölümü, ISO/IEC 29500 tarafından tanımlanan Kullanıcı Tanımlı Etiketler gibi birçok bölüme açık ilişkiler kurabilir. 

Özel veri (bir sunuma özgü) veya kullanıcı, etiketler ([TagCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/TagCollection)) ve CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/CustomXmlPartCollection)) olarak bulunabilir.

{{% alert color="primary" %}} 
Etiketler temelde anahtar‑değer dize çiftleridir. 
{{% /alert %}} 

## **Etiket Değerlerini Almak**

Slaytlarda, bir etiket [DocumentProperties.getKeywords()](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/DocumentProperties#getKeywords--) ve [DocumentProperties.setKeywords()](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/DocumentProperties#setKeywords-java.lang.String-) yöntemlerine karşılık gelir. Bu örnek kod, Aspose.Slides for Node.js via Java ile bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) için etiket değerinin nasıl alınacağını gösterir:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Sunumlara Etiket Ekleme**

Aspose.Slides, sunumlara etiket eklemenize izin verir. Bir etiket genellikle iki öğeden oluşur: 

- özel bir özelliğin adı - `MyTag` 
- özel bir özelliğin değeri - `My Tag Value`

Belirli bir kural veya özelliğe göre bazı sunumları sınıflandırmanız gerekiyorsa, bu sunumlara etiket eklemek faydalı olabilir. Örneğin, Kuzey Amerika ülkelerinden gelen tüm sunumları bir araya getirmek isterseniz, bir Kuzey Amerika etiketi oluşturabilir ve ilgili ülkeleri (ABD, Meksika ve Kanada) değer olarak atayabilirsiniz. 

Bu örnek kod, Aspose.Slides for Node.js via Java kullanarak bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) içine etiket nasıl ekleyeceğinizi gösterir:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Etiketler ayrıca [Slide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Slide) için de ayarlanabilir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Veya herhangi bir bireysel [Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/AutoShape):

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Sınırlamalar**

`getCustomData().getTags()` kullanılarak özel veri etiket koleksiyonu aracılığıyla eklenen etiketler yalnızca PowerPoint dosyası içinde depolanır. Sunum PDF'ye dışa aktarıldığında bu etiketler PDF etiket yapısına **aktarılmaz**. Sonuç olarak, etiket olarak atanmış bir özel tanımlayıcı, etiketli PDF'den alınamaz.

**Geçici Çözüm**: Özel bir tanımlayıcıyı nesnenin **Alt Metni** içinde (örn., `shape.setAlternativeText("MyId")`) depolayabilirsiniz. PDF'ye dışa aktardıktan sonra Alt Metin PDF etiket yapısında görünebilir.

## **SSS**

**Bir sunum, slayt veya şekilden tüm etiketleri tek bir işlemle kaldırabilir miyim?**

Evet. [tag collection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tagcollection/) bir kerede tüm anahtar‑değer çiftlerini silen bir [clear](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tagcollection/clear/) işlemini destekler.

**Bir etiketi, tüm koleksiyonu dolaşmadan yalnızca adını kullanarak nasıl silebilirim?**

[TagCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tagcollection/) üzerindeki [remove(name)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tagcollection/remove/) işlemini kullanarak etiketi anahtarına göre silebilirsiniz.

**Analiz veya filtreleme için etiket adlarının tam listesini nasıl alabilirim?**

[tag collection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tagcollection/) üzerinde [getNamesOfTags](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tagcollection/getnamesoftags/) kullanın; bu, tüm etiket adlarını içeren bir dizi döndürür.