---
title: Android'de Sunumlarda Etiketleri ve Özel Verileri Yönetme
linktitle: Etiketler ve Özel Veri
type: docs
weight: 300
url: /tr/androidjava/managing-tags-and-custom-data
keywords:
- belge özellikleri
- etiket
- özel veri
- etiket ekle
- çift değerler
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'de etiketleri ve özel verileri ekleyin, okuyun, güncelleyin ve kaldırın; PowerPoint ve OpenDocument sunumları için Java örnekleriyle."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'in PowerPoint sunumlarında etiketler ve özel veri ile nasıl çalıştığını açıklar. Veri'nin PPTX dosyalarında nasıl depolandığını kısaca özetler, sunuma özgü verilerin etiketler ve özel XML bölümleri olarak bulunabileceğini belirtir ve etiketleri anahtar‑değer dize çiftleri olarak tanımlar.

Ayrıca etiket değerlerinin nasıl okunacağını ve bir sunuma, tek bir slayta veya bir şekle nasıl etiket ekleneceğini gösterir. Ek olarak, makale tüm etiketleri temizleme, bir etiketi adını belirterek kaldırma ve etiket adlarının listesini alma gibi yaygın etiket yönetimi görevlerini kapsar.

## **Sunum Dosyalarında Veri Depolama**

PPTX dosyaları—.pptx uzantısına sahip öğeler—Office Open XML spesifikasyonunun bir parçası olan PresentationML formatında depolanır. Office Open XML formatı, sunumlarda bulunan verilerin yapısını tanımlar.

*slayt* sunumların öğelerinden biri olduğunda, *slayt bölümü* tek bir slaytın içeriğini içerir. Bir slayt bölümü, ISO/IEC 29500 tarafından tanımlanan Kullanıcı Tanımlı Etiketler gibi birçok bölüme açık ilişkiler sahip olabilir.

Özel veri (bir sunuma özgü) veya kullanıcı, etiketler ([ITagCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITagCollection)) ve CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICustomXmlPartCollection)) şeklinde bulunabilir.

{{% alert color="primary" %}} 
Etiketler temelde anahtar‑değer dize çiftleridir. 
{{% /alert %}} 

## **Etiket Değerlerini Almak**

Slaytlarda, bir etiket [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IDocumentProperties#getKeywords--) ve [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) yöntemlerine karşılık gelir. Bu örnek kod, Aspose.Slides for Android via Java ile bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) için bir etiketin değerini nasıl alacağınızı gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sunumlara Etiket Ekleme**

Aspose.Slides, sunumlara etiket eklemenize izin verir. Bir etiket genellikle iki öğeden oluşur:

- özel bir özelliğin adı - `MyTag`
- özel bir özelliğin değeri - `My Tag Value`

Belirli bir kural veya özelliğe göre bazı sunumları sınıflandırmanız gerekiyorsa, bu sunumlara etiket eklemek faydalı olabilir. Örneğin, Kuzey Amerika ülkelerinden tüm sunumları bir araya getirmek istiyorsanız, bir Kuzey Amerika etiketi oluşturabilir ve ilgili ülkeleri (ABD, Meksika ve Kanada) değer olarak atayabilirsiniz.

Bu örnek kod, Aspose.Slides for Android via Java kullanarak bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) öğesine nasıl etiket ekleneceğini gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

Etiketler ayrıca bir [Slide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlide) için de ayarlanabilir:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

Veya herhangi bir tekil [Shape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IAutoShape) için:

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

### **Kısıtlamalar**

`getCustomData().getTags()` kullanılarak özel veri etiket koleksiyonu aracılığıyla eklenen etiketler yalnızca PowerPoint dosyasında depolanır. Sunum PDF olarak dışa aktarıldığında etiket yapısına **aktarılmaz**. Sonuç olarak, bir etiket olarak atanan özel tanımlayıcı etiketli PDF'den alınamaz.

**Geçici Çözüm**: Özel bir tanımlayıcıyı nesnenin **Alt Text** (örn., `shape.setAlternativeText("MyId")`) içinde depolayabilirsiniz. PDF'ye dışa aktardıktan sonra Alt Text PDF etiket yapısında görünebilir.

## **SSS**

**Bir sunum, slayt veya şekilden tüm etiketleri tek bir işlemle kaldırabilir miyim?**

Evet. [tag collection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tagcollection/) bir kerede tüm anahtar‑değer çiftlerini silen bir [clear](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tagcollection/#clear--) işlemini destekler.

**Tüm koleksiyonu döngüye sokmadan, adını belirterek tek bir etiketi nasıl silebilirim?**

Etiketi anahtarıyla silmek için [tag collection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tagcollection/) üzerinde [remove(name)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) işlemini kullanın.

**Analiz veya filtreleme için etiket adlarının tam listesini nasıl alabilirim?**

Etiket adlarının tam listesini almak için [tag collection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tagcollection/) üzerinde [getNamesOfTags](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) metodunu kullanın; bu metod tüm etiket adlarını içeren bir dizi döndürür.