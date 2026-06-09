---
title: Java Kullanarak Sunumlarda Etiketleri ve Özel Verileri Yönetme
linktitle: Etiketler ve Özel Veri
type: docs
weight: 300
url: /tr/java/managing-tags-and-custom-data/
keywords:
- belge özellikleri
- etiket
- özel veri
- etiket ekle
- çift değerler
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da etiketleri ve özel verileri eklemeyi, okumayı, güncellemeyi ve kaldırmayı, PowerPoint ve OpenDocument sunum örnekleriyle öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ın PowerPoint sunumlarında etiketler ve özel veri ile nasıl çalıştığını açıklar. PPTX dosyalarında verinin nasıl depolandığını kısaca özetler, sunuma özgü verilerin etiketler ve özel XML bölümleri olarak bulunabileceğini belirtir ve etiketleri anahtar‑değer string çiftleri olarak tanımlar.

Ayrıca, etiket değerlerini nasıl okuyacağınızı ve bir sunuma, tek bir slayta veya bir şekle nasıl etiket ekleyeceğinizi gösterir. Ek olarak, makale tüm etiketleri temizleme, bir etiketi adını vererek kaldırma ve etiket adları listesini almayı gibi yaygın etiket yönetimi görevlerini kapsar.

## **Sunum Dosyalarında Veri Depolama**

PPTX dosyaları—.pptx uzantılı öğeler—Office Open XML (OOXML) spesifikasyonunun bir parçası olan PresentationML formatında depolanır. Office Open XML formatı, sunumlarda bulunan verilerin yapısını tanımlar.

*Slide* (slayt), sunumların öğelerinden biridir ve *slide part* (slayt bölümü) tek bir slaytın içeriğini barındırır. Bir slayt bölümü, ISO/IEC 29500 tarafından tanımlanan Kullanıcı Tanımlı Etiketler gibi birçok bölüme açık ilişkiler içerebilir.

Özel veri (sunuma özgü) veya kullanıcı, etiketler ([ITagCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITagCollection)) ve CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICustomXmlPartCollection)) olarak bulunabilir.

{{% alert color="primary" %}} 
Etiketler aslında string‑anahtar çift değerlerdir. 
{{% /alert %}} 

## **Etiket Değerlerini Alma**

Slaytlarda bir etiket, [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IDocumentProperties#getKeywords--) ve [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) metotlarına karşılık gelir. Bu örnek kod, Aspose.Slides for Java ile bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) için etiket değerini nasıl alacağınızı gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sunumlara Etiket Ekleme**

Aspose.Slides, sunumlara etiket eklemenize olanak tanır. Bir etiket genellikle iki öğeden oluşur:

- özel bir özelliğin adı - `MyTag`
- özel bir özelliğin değeri - `My Tag Value`

Belirli bir kural veya özelliğe göre bazı sunumları sınıflandırmanız gerekiyorsa, bu sunumlara etiket eklemek faydalı olabilir. Örneğin, Kuzey Amerika ülkelerinden tüm sunumları bir araya getirmek istiyorsanız, bir Kuzey Amerika etiketi oluşturabilir ve ilgili ülkeleri (ABD, Meksika ve Kanada) değer olarak atayabilirsiniz.

Bu örnek kod, Aspose.Slides for Java kullanarak bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation)’a etiket nasıl ekleyeceğinizi gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

Etiketler ayrıca bir [Slide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlide) için de ayarlanabilir:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

Veya herhangi bir tekil [Shape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IAutoShape):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

### **Sınırlamalar**

`getCustomData().getTags()` kullanılarak özel veri etiket koleksiyonu aracılığıyla eklenen etiketler yalnızca PowerPoint dosyasında depolanır. Sunum PDF'ye dışa aktarıldığında bu etiketler PDF etiket yapısına **transfer edilmez**. Sonuç olarak, etiket olarak atanan özel bir tanımlayıcı etiketli PDF'den alınamaz.

**Geçici çözüm**: Özel bir tanımlayıcıyı nesnenin **Alt Text** (ör. `shape.setAlternativeText("MyId")`) içinde saklayabilirsiniz. PDF'ye dışa aktarıldıktan sonra Alt Text PDF etiket yapısında görünebilir.

## **SSS**

**Bir sunumdan, slayttan veya şekilden tüm etiketleri tek bir işlemle kaldırabilir miyim?**

Evet. [tag collection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tagcollection/) [clear](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tagcollection/#clear--) işlemini destekler; bu işlem tüm anahtar‑değer çiftlerini bir anda siler.

**Tüm koleksiyonu döndürmeden, adını vererek tek bir etiketi nasıl silirim?**

Etiketi anahtarıyla silmek için [tag collection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tagcollection/) üzerindeki [Remove(name)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) işlemini kullanın.

**Analiz veya filtreleme için etiket adlarının tam listesini nasıl alabilirim?**

[tag collection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tagcollection/) üzerindeki [getNamesOfTags](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tagcollection/#getNamesOfTags--) metodunu kullanın; bu metod tüm etiket adlarını içeren bir dizi döndürür.