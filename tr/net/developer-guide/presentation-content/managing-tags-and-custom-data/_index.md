---
title: Sunumlarda Etiketleri ve Özel Verileri .NET'te Yönetme
linktitle: Etiketler ve Özel Veriler
type: docs
weight: 300
url: /tr/net/managing-tags-and-custom-data/
keywords:
- belge özellikleri
- etiket
- özel veri
- özel XML
- özel XML parçası
- XML meta verileri
- ItemId
- etiket ekle
- değer çiftleri
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint sunumlarında etiketleri ve özel XML verilerini yönetmeyi, ekleme, okuma, güncelleme, denetleme ve özel XML parçalarını kaldırmayı öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ın PowerPoint sunumlarında etiketler ve özel verilerle nasıl çalıştığını açıklar. Sunuma özgü veriler etiketler veya özel XML parçaları olarak depolanabilir. Etiketler basit anahtar-değer dize çiftleridir, özel XML parçaları ise yapılandırılmış meta verileri ve uygulamaya özgü XML yüklerini depolayabilir.

Aspose.Slides, sunum, slayt ve şekil düzeylerinde özel XML parçalarını ekleme, okuma, güncelleme, denetleme ve kaldırma için API'ler sağlar. Özel XML parçaları, belge yönetimi tanımlayıcıları, iş akışı durumu, uyumluluk meta verileri, şablon bağlama verileri veya bir sunum içinde diğer yapılandırılmış uygulama verileri gibi bilgileri depolayan entegrasyonlar için yararlıdır.

## **Sunum Dosyalarında Veri Depolama**

PPTX dosyaları—`.pptx` uzantılı dosyalar—PresentationML formatında saklanır ve bu, Office Open XML spesifikasyonunun bir parçasıdır. Office Open XML, sunum içeriğini ve ilgili verileri depolamak için kullanılan paket yapısını ve ilişkileri tanımlar.

Bir sunum, ilişkilerle bağlanmış birden çok parçadan oluşur. Örneğin, bir slayt parçası tek bir slaydın içeriğini içerir ve ISO/IEC 29500 tarafından tanımlanan diğer parçalara açık ilişkiler sahip olabilir.

Özel veriler etiketler ([ITagCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/itagcollection)) veya özel XML parçaları ([ICustomXmlPartCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/icustomxmlpartcollection)) olarak depolanabilir. Her ikisi de [`ICustomData`](https://reference.aspose.com/slides/tr/net/aspose.slides/icustomdata/) arayüzü aracılığıyla kullanılabilir.

{{% alert color="info" %}}
Etiketler basit dize anahtar-değer çiftlerini depolar. Özel XML parçaları yapılandırılmış XML verilerini depolar ve bir sunum, slayt veya şekil ile ilişkilendirilebilir.
{{% /alert %}}

## **Özel XML Parçalarıyla Çalışma**

`[`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/tr/net/aspose.slides/icustomdata/customxmlparts/)` özelliği, belirli bir sunum nesnesiyle ilişkili özel XML parçalarının koleksiyonunu döndürür. Örneğin:

- `presentation.CustomData.CustomXmlParts` doğrudan sunumla ilişkili özel XML parçalarını içerir.
- `slide.CustomData.CustomXmlParts` belirli bir slaytla ilişkili özel XML parçalarını içerir.
- `shape.CustomData.CustomXmlParts` belirli bir şekille ilişkili özel XML parçalarını içerir.

İlişkilendirme konumundan bağımsız olarak bir sunumdaki tüm özel XML parçalarını incelemeniz gerektiğinde [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/allcustomxmlparts/) kullanın.

### **Sunuma Özel XML Parçası Ekleme**

`[`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/tr/net/aspose.slides/icustomxmlpartcollection/add/)` metodunu kullanarak bir özel XML parçası koleksiyonuna XML verisi ekleyebilirsiniz. XML geçerli ve boş olmamalıdır.

Aşağıdaki örnek, sunum düzeyindeki özel veri koleksiyonuna yapılandırılmış meta verileri ekler:

```csharp
using System;
using Aspose.Slides;

var customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

using var presentation = new Presentation();
var customXmlPart = presentation.CustomData.CustomXmlParts.Add(customXmlContent);

// Add otomatik olarak bir tanımlayıcı atar. Yalnızca gerektiğinde belirli bir GUID ayarlayın.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

`Add` metodu ayrıca XML'i bir bayt dizisi veya akış olarak kabul edebilir; bu, XML içeriği zaten ikili biçimde mevcut olduğunda faydalıdır.

### **Slayt veya Şekle Özel XML Parçası Ekleme**

Özel XML verileri, tüm sunum yerine belirli bir slayt veya şekil ile ilişkilendirilebilir. Bu, meta verilerin yalnızca bir nesneyi (örneğin bir şablon anahtarı, dış kayıt tanımlayıcısı veya bağlama bilgisi) tanımladığı durumlarda yararlıdır.

Aşağıdaki örnek, bir slayta bir özel XML parçası ve bir şekle bir diğerini ekler:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.CustomData.CustomXmlParts.Add(
    "<slideMetadata xmlns=\"urn:example:slides\">" +
        "<templateKey>TitleSlide</templateKey>" +
    "</slideMetadata>");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

shape.TextFrame.Text = "Customer data";
shape.CustomData.CustomXmlParts.Add(
    "<shapeMetadata xmlns=\"urn:example:shapes\">" +
        "<recordId>CRM-4281</recordId>" +
    "</shapeMetadata>");

presentation.Save("object_custom_xml.pptx", SaveFormat.Pptx);
```

Bir parçanın eklenme seviyesi, hangi nesnenin `CustomData.CustomXmlParts` koleksiyonunun o parçaya ilişkin ilişkiyi içerdiğini belirler. Sunum düzeyindeki veri, belge genelindeki meta veriler için uygundur; slayt düzeyindeki veri, belirli bir slayta ait bilgiler için; şekil düzeyindeki veri ise tek bir şekle bağlı meta veriler için uygundur.

### **Tüm Özel XML Parçalarını Listeleme ve Denetleme**

`[`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/allcustomxmlparts/)` kullanarak bir sunumdan tüm özel XML parçalarını alabilirsiniz. Her [`ICustomXmlPart`](https://reference.aspose.com/slides/tr/net/aspose.slides/icustomxmlpart/) kimliğini, XML içeriğini ve ilişkili ad alanı şemalarını gösterir.

Aşağıdaki örnek, tüm özel XML parçalarını ve bunların ad alanı şemalarını listeler:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    Console.WriteLine("ItemId: " + customXmlPart.ItemId);
    Console.WriteLine("XML:");
    Console.WriteLine(customXmlPart.XmlAsString);

    foreach (var namespaceSchema in customXmlPart.NamespaceSchemas)
    {
        Console.WriteLine("Namespace schema: " + namespaceSchema);
    }

    Console.WriteLine();
}
```

`[`ICustomXmlPart.NamespaceSchemas`](https://reference.aspose.com/slides/tr/net/aspose.slides/icustomxmlpart/namespaceschemas/)` özel XML parçasıyla ilişkili XML şemalarını döndürür. Bu bilgi, dış sistemler tarafından üretilen XML içeren sunumları denetlerken yararlı olabilir.

### **XML İçeriğini ve ItemId'yi Okuma ve Güncelleme**

`[`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/tr/net/aspose.slides/icustomxmlpart/xmlasstring/)` kullanarak XML'i UTF-8 dizesi olarak, ya da [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/tr/net/aspose.slides/icustomxmlpart/xmldata/)` ile ham XML baytları olarak işleyebilirsiniz. Her iki özellik de okunabilir ve güncellenebilir.

`[`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/tr/net/aspose.slides/icustomxmlpart/itemid/)` özelliği, Office Open XML belgesindeki özel XML parçasını tanımlayan GUID'i içerir. Bir entegrasyon yeni bir tanımlayıcı gerektirdiğinde bu da değiştirilebilir.

Aşağıdaki örnek, XML içeriğini ve tanımlayıcıyı günceller:

```csharp
using System;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlPart = presentation.AllCustomXmlParts[0];

// Mevcut XML'i metin olarak oku.
var currentXmlContent = customXmlPart.XmlAsString;
Console.WriteLine(currentXmlContent);

// Update the XML as a UTF-8 string.
customXmlPart.XmlAsString =
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Approved</workflowState>" +
    "</metadata>";

// XmlData provides the same XML content as raw bytes.
var customXmlData = customXmlPart.XmlData;
Console.WriteLine(Encoding.UTF8.GetString(customXmlData));

// Replace the identifier when required by the integration.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("updated_custom_xml.pptx", SaveFormat.Pptx);
```

`XmlAsString` veya `XmlData` atarken geçerli ve boş olmayan bir XML sağlayın. Uygulamanın esas olarak dize mi yoksa bayt verisiyle mi çalıştığına bağlı olarak bir gösterimi diğerine tercih edin.

### **Özel XML Parçasını Kaldırma**

Aspose.Slides, özel XML verilerini kaldırmak için çeşitli yollar sunar:

- `[`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/tr/net/aspose.slides/icustomxmlpart/remove/)` özel XML parçasını sunumdan kaldırır.
- `[`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/tr/net/aspose.slides/icustomxmlpartcollection/remove/)` bir özel XML parçası koleksiyonundan belirli bir parçayı kaldırır.
- `[`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/tr/net/aspose.slides/icustomxmlpartcollection/removeat/)` belirtilen koleksiyon indeksindeki parçayı kaldırır.
- `[`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/tr/net/aspose.slides/icustomxmlpartcollection/clear/)` belirli bir koleksiyondaki tüm parçaları kaldırır.

Aşağıdaki örnek, referansla bir sunum düzeyindeki özel XML parçasını kaldırır:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlParts = presentation.CustomData.CustomXmlParts;

if (customXmlParts.Count > 0)
{
    var customXmlPart = customXmlParts[0];
    customXmlParts.Remove(customXmlPart);
}

presentation.Save("custom_xml_removed.pptx", SaveFormat.Pptx);
```

Zaten bir `ICustomXmlPart`'iniz varsa ve belirli bir koleksiyona yönelmek yerine bu parçayı sunumdan kaldırmak istiyorsanız, `customXmlPart.Remove()` çağırın.

Ayrıca bir öğeyi indeksle kaldırabilirsiniz:

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **Bir Koleksiyondan Tüm Özel XML Parçalarını Temizleme**

Belirli bir sunum nesnesiyle ilişkili tüm özel XML parçaları kaldırılmak istendiğinde `Clear` kullanın.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

`Clear`, yalnızca seçilen koleksiyonu etkiler. Örneğin, bir slaydın koleksiyonunu temizlemek, sunum düzeyindeki veya şekil düzeyindeki koleksiyonları temizlemez.

Sunumdaki tüm özel XML parçalarını kaldırmak için `AllCustomXmlParts` üzerinden döngü yapıp her parçayı kaldırın:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **Bağlantılı veya Paylaşılan Özel XML Parçalarını Yönetme**

Office Open XML sunumunda aynı özel XML parçası birden fazla sunum nesnesinden referans alınabilir. Örneğin, mevcut bir dosya aynı temel özel XML parçasına birden çok slayt veya şekilden ilişkiler içerebilir.

Paylaşılan bir parça, birden çok referansa sahip tek bir veri nesnesi olarak ele alınmalıdır:

- `XmlAsString`, `XmlData` veya `ItemId` güncellenmesi, temel özel XML parçasını değiştirir; bu değişiklik, parçanın referans alındığı her yerde uygulanır.
- `ItemId`, nesne düzeyindeki koleksiyonları denetlerken aynı özel XML parçasını tanımlamak için kullanılabilir.
- Belirli bir `CustomXmlParts` koleksiyonundan bir parçanın kaldırılması, onu o koleksiyondan siler. Parçanın kendisinin sunumdan kaldırılması gerektiğinde `ICustomXmlPart.Remove()` kullanın.
- Paylaşılan bir parçayı silmeden veya değiştirmeden önce, diğer slaytların veya şekillerin hala ona referans verip vermediğini belirlemek için nesne düzeyindeki koleksiyonları inceleyin.

`Add` aşırı yüklemeleri, XML içeriğinden yeni bir özel XML parçası oluşturur; mevcut bir `ICustomXmlPart` kabul etmez. Bu nedenle, paylaşılan ilişkiler genellikle zaten bu ilişkileri içeren sunumlar yüklendiğinde karşılaşılır.

Aşağıdaki örnek, `ItemId` ile sunum, slayt ve şekil düzeyindeki koleksiyonları denetler ve birden fazla yerden referans verilen parçaları raporlar:

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var referencesByItemId = new Dictionary<Guid, List<string>>();

var registerCustomXmlParts = (string ownerName, ICustomXmlPartCollection customXmlParts) =>
    {
        foreach (var customXmlPart in customXmlParts)
        {
            if (!referencesByItemId.ContainsKey(customXmlPart.ItemId))
            {
                referencesByItemId[customXmlPart.ItemId] = new List<string>();
            }

            referencesByItemId[customXmlPart.ItemId].Add(ownerName);
        }
    };

registerCustomXmlParts("Presentation", presentation.CustomData.CustomXmlParts);

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    registerCustomXmlParts("Slide " + (slideIndex + 1), slide.CustomData.CustomXmlParts);

    for (var shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.CustomData.CustomXmlParts);
    }
}

foreach (var referenceEntry in referencesByItemId)
{
    if (referenceEntry.Value.Count > 1)
    {
        Console.WriteLine("Shared custom XML part: " + referenceEntry.Key);

        foreach (var ownerName in referenceEntry.Value)
        {
            Console.WriteLine("  Referenced by: " + ownerName);
        }
    }
}
```

Bu tür bir denetim, dış sistemler tarafından oluşturulan sunumlarda özel XML verilerini değiştirmeden veya silmeden önce yararlıdır; aynı meta veri parçası birden fazla ilişkide yer alabilir.

## **Etiket Değerlerini Alma**

Slaytlarda bir etiket, `IDocumentProperties.Keywords` özelliğine karşılık gelir. Bu örnek kod, Aspose.Slides for .NET ile bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) etiket değerini nasıl alacağınızı gösterir:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **Sunumlara Etiket Ekleme**

Aspose.Slides, sunumlara etiket eklemenize olanak tanır. Bir etiket genellikle iki öğeden oluşur:

- özel bir özelliğin adı, örneğin `MyTag`;
- özel özelliğin değeri, örneğin `My Tag Value`.

Sunumları belirli bir kural veya özelliğe göre sınıflandırmanız gerekiyorsa, bu amaçla etiketler ekleyebilirsiniz. Örneğin, Kuzey Amerika ülkelerinden gelen sunumları kategorize etmek istiyorsanız, bir Kuzey Amerika etiketi oluşturup ilgili ülkeyi değeri olarak atayabilirsiniz.

Bu örnek kod, Aspose.Slides for .NET kullanarak bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) etiket eklemenin nasıl yapılacağını gösterir:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var tags = presentation.CustomData.Tags;
tags["MyTag"] = "My Tag Value";
```

Etiketler ayrıca bir [Slide](https://reference.aspose.com/slides/tr/net/aspose.slides/slide) için de ayarlanabilir:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
slide.CustomData.Tags["tag"] = "value";
```

Veya tek bir [Shape](https://reference.aspose.com/slides/tr/net/aspose.slides/shape) için:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
shape.TextFrame.Text = "My text";
shape.CustomData.Tags["tag"] = "value";
```

### **Sınırlamalar**

`CustomData.Tags` koleksiyonu aracılığıyla eklenen etiketler yalnızca PowerPoint dosyasında depolanır. Sunum PDF'ye dışa aktarıldığında bu etiketler PDF etiket yapısına **aktarılamaz**. Sonuç olarak, bir etiket olarak atanan özel tanımlayıcı PDF'den elde edilemez.

**Geçici Çözüm**: Özel bir tanımlayıcıyı nesnenin **Alt Text**'inde (örneğin, `shape.AlternativeText = "MyId"`) depolayabilirsiniz. PDF'ye dışa aktarıldıktan sonra Alt Text PDF etiket yapısında görünebilir.

## **SSS**

**Bir sunum, slayt veya şekilden tüm etiketleri tek bir işlemle kaldırabilir miyim?**  
Evet. [tag collection](https://reference.aspose.com/slides/tr/net/aspose.slides/tagcollection/) tek seferde tüm anahtar-değer çiftlerini silen bir [Clear](https://reference.aspose.com/slides/tr/net/aspose.slides/tagcollection/clear/) işlemini destekler.

**Tüm koleksiyonu döngüye almadan bir etiketin adını kullanarak tek bir etiketi nasıl silerim?**  
`[Remove(name)](https://reference.aspose.com/slides/tr/net/aspose.slides/tagcollection/remove/)` metodunu [TagCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/tagcollection/) üzerinde, etiketi anahtarına göre silmek için kullanın.

**Analiz veya filtreleme için etiket adlarının tam listesini nasıl alabilirim?**  
`[GetNamesOfTags](https://reference.aspose.com/slides/tr/net/aspose.slides/tagcollection/getnamesoftags/)` metodunu [tag collection](https://reference.aspose.com/slides/tr/net/aspose.slides/tagcollection/) üzerinde kullanın; tüm etiket adlarını içeren bir dizi döndürür.

**Özel XML parçalarının hepsini, depolandıkları yer ne olursa olsun nasıl bulabilirim?**  
`[Presentation.AllCustomXmlParts](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/allcustomxmlparts/)` kullanarak sunumdaki tüm özel XML parçalarını alabilirsiniz.

**Bir özel XML parçasını güncellemek için `XmlAsString` mi yoksa `XmlData` mı kullanmalıyım?**  
`XmlAsString`, uygulama UTF-8 XML metniyle çalışıyorsa kullanılmalıdır. `XmlData`, XML zaten bir bayt dizisi olarak mevcutsa veya ikili odaklı işleme daha uygun olduğunda kullanılmalıdır. Her iki özellik de aynı özel XML parçasının XML içeriğini temsil eder.