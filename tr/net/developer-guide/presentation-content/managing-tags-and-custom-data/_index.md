---
title: .NET'te Sunumlarda Etiketleri ve Özel Verileri Yönetme
linktitle: Etiketler ve Özel Veri
type: docs
weight: 300
url: /tr/net/managing-tags-and-custom-data/
keywords:
- belge özellikleri
- etiket
- özel veri
- etiket ekle
- çift değerler
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te PowerPoint ve OpenDocument sunumları için örneklerle etiketleri ve özel verileri eklemeyi, okumayı, güncellemeyi ve kaldırmayı öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'in PowerPoint sunumlarında etiketler ve özel veriyle nasıl çalıştığını açıklar. Verinin PPTX dosyalarında nasıl saklandığını kısaca özetler, sunuma özgü verilerin etiketler ve özel XML bölümleri olarak bulunabileceğini belirtir ve etiketleri anahtar‑değer dize çiftleri olarak tanımlar.

Ayrıca etiket değerlerinin nasıl okunacağını ve bir güneşe, tek bir slayta veya bir şekle nasıl etiket ekleneceğini gösterir. Bunun yanı sıra, tüm etiketleri temizleme, bir etiketi adıyla kaldırma ve etiket adları listesini alma gibi yaygın etiket yönetimi görevlerini kapsar.

## **Sunum Dosyalarındaki Veri Depolama**

.pptx uzantılı PPTX dosyaları, Office Open XML (OOXML) spesifikasyonunun bir parçası olan PresentationML formatında depolanır. Office Open XML formatı, sunumlarda bulunan verinin yapısını tanımlar.

*Slide* (slayt), sunumların öğelerinden biridir; bir *slide part* tek bir slaydın içeriğini barındırır. Bir slide part, ISO/IEC 29500 tarafından tanımlanan Kullanıcı Tanımlı Etiketler gibi birçok parçaya açık ilişkiler kurabilir.

Özel veri (sunuma özgü) veya kullanıcı, etiketler ([ITagCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/itagcollection)) ve CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/icustomxmlpartcollection)) olarak bulunabilir.

{{% alert color="primary" %}} 
Etiketler esasen dize‑anahtar çift değerlerdir. 
{{% /alert %}} 

## **Etiket Değerlerini Almak**

Slaytlarda bir etiket, IDocumentProperties.Keywords özelliğine karşılık gelir. Bu örnek kod, Aspose.Slides for .NET kullanarak bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) üzerindeki bir etiketin değerini nasıl alacağınızı gösterir:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```

## **Sunumlara Etiket Ekleme**

Aspose.Slides, sunumlara etiket eklemenize olanak tanır. Bir etiket tipik olarak iki öğeden oluşur:

- özel özelliğin adı – `MyTag`
- özel özelliğin değeri – `My Tag Value`

Bazı sunumları belirli bir kural veya özelliğe göre sınıflandırmanız gerekiyorsa, bu sunumlara etiket eklemek faydalı olabilir. Örneğin, Kuzey Amerika ülkelerindeki tüm sunumları bir araya getirmek istiyorsanız, bir “North American” etiketi oluşturup ilgili ülkeleri (ABD, Meksika ve Kanada) değer olarak atayabilirsiniz.

Bu örnek kod, Aspose.Slides for .NET kullanarak bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) üzerine nasıl etiket ekleneceğini gösterir:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```

Etiketler ayrıca bir [Slide](https://reference.aspose.com/slides/tr/net/aspose.slides/slide) için de ayarlanabilir:

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```

Ya da tek bir [Shape](https://reference.aspose.com/slides/tr/net/aspose.slides/shape) için:

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```

### **Sınırlamalar**

`CustomData.Tags` koleksiyonu aracılığıyla eklenen etiketler yalnızca PowerPoint dosyasında depolanır. Sunum PDF’ye dışa aktarıldığında bu etiketler **PDF etiket yapısına** aktarılmaz. Sonuç olarak, etiket olarak atanmış bir özel tanımlayıcı PDF’de elde edilemez.

**Geçici Çözüm**: Nesnenin **Alt Metin** içine bir özel tanımlayıcı (ör. `shape.AlternativeText = "MyId"`) kaydedebilirsiniz. PDF’ye dışa aktarıldıktan sonra Alt Metin, PDF etiket yapısında görünebilir.

## **SSS**

**Bir sunum, slayt veya şekilden tüm etiketleri tek bir işlemle kaldırabilir miyim?**

Evet. [TagCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/tagcollection/) **clear**(https://reference.aspose.com/slides/tr/net/aspose.slides/tagcollection/clear/) işlemini destekler; bu işlem tüm anahtar‑değer çiftlerini bir seferde siler.

**Tüm koleksiyonu dolaşmadan adıyla tek bir etiketi nasıl silerim?**

[TagCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/tagcollection/) üzerindeki [Remove(name)](https://reference.aspose.com/slides/tr/net/aspose.slides/tagcollection/remove/) işlemini kullanarak etiketi anahtarıyla silebilirsiniz.

**Analiz veya filtreleme için etiket adlarının tam listesini nasıl alırım?**

[tag collection](https://reference.aspose.com/slides/tr/net/aspose.slides/tagcollection/) üzerindeki [GetNamesOfTags](https://reference.aspose.com/slides/tr/net/aspose.slides/tagcollection/getnamesoftags/) metodunu kullanın; bu metod tüm etiket adlarını içeren bir dizi döndürür.