---
title: ".NET'te Sunumlarda Etiketleri ve Özel Verileri Yönetme"
linktitle: "Etiketler ve Özel Veri"
type: docs
weight: 300
url: /tr/net/managing-tags-and-custom-data/
keywords:
- belge özellikleri
- etiket
- özel veri
- özel XML
- özel XML parçası
- XML üst verileri
- ItemId
- etiket ekle
- çift değerler
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PowerPoint sunumlarında etiketleri ve özel XML verilerini yönetmeyi öğrenin; özel XML parçalarını ekleme, okuma, güncelleme, denetleme ve kaldırma dahil."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'in PowerPoint sunumlarında etiketler ve özel verilerle nasıl çalıştığını açıklar. Sunuma özgü veriler etiketler veya özel XML parçaları olarak depolanabilir. Etiketler basit anahtar‑değer dize çiftleridir, özel XML parçaları ise yapılandırılmış üst verileri ve uygulamaya özgü XML yüklerini depolayabilir.

Aspose.Slides, sunum, slayt ve şekil düzeyinde özel XML parçalarını ekleme, okuma, güncelleme, denetleme ve kaldırma için API'ler sağlar. Özel XML parçaları, belge yönetimi kimlikleri, iş akışı durumu, uyumluluk üst verileri, şablon bağlama verileri veya sunum içinde depolanacak diğer yapılandırılmış uygulama verileri gibi bilgileri saklamak için entegrasyonlarda yararlıdır.

## **Sunum Dosyalarında Veri Depolama**

`.pptx` uzantılı PPTX dosyaları, Office Open XML spesifikasyonunun bir parçası olan PresentationML formatında depolanır. Office Open XML, sunum içeriğini ve ilişkili verileri saklamak için paket yapısını ve ilişkileri tanımlar.

Bir sunum, ilişkilerle bağlanmış birden çok parçadan oluşur. Örneğin, bir slayt parçası tek bir slaytın içeriğini tutar ve ISO/IEC 29500 tarafından tanımlanan diğer parçalara açık ilişkiler içerebilir.

Özel veriler etiketler ([ITagCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/itagcollection)) veya özel XML parçaları ([ICustomXmlPartCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/icustomxmlpartcollection)) şeklinde saklanabilir. Her ikisi de [`ICustomData`](https://reference.aspose.com/slides/tr/net/aspose.slides/icustomdata/) arabirimi üzerinden erişilebilir.

{{% alert color="primary" %}}
Etiketler basit dize anahtar‑değer çiftlerini saklar. Özel XML parçaları yapılandırılmış XML verilerini saklar ve bir sunuma, slayta veya şekle ilişkilendirilebilir.
{{% /alert %}}

## **Özel XML Parçalarıyla Çalışma**

[`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/tr/net/aspose.slides/icustomdata/customxmlparts/) özelliği, belirli bir sunum nesnesiyle ilişkili özel XML parçalarının koleksiyonunu döndürür. Örnek:

- `presentation.CustomData.CustomXmlParts` sunumun kendisiyle ilişkili özel XML parçalarını içerir.
- `slide.CustomData.CustomXmlParts` belirli bir slaytla ilişkili özel XML parçalarını içerir.
- `shape.CustomData.CustomXmlParts` belirli bir şekille ilişkili özel XML parçalarını içerir.

Sunumdaki tüm özel XML parçalarını, bunların nerede ilişkilendirildiğine bakılmaksızın incelemek istediğinizde [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/allcustomxmlparts/) kullanın.

### **Bir Sunuma Özel XML Parçası Ekleme**

[`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/tr/net/aspose.slides/icustomxmlpartcollection/add/) kullanarak bir XML verisini özel XML parça koleksiyonuna ekleyin. XML geçerli ve boş olmamalıdır.

Aşağıdaki örnek, sunum‑düzeyinde yapılandırılmış üst veriyi özel veri koleksiyonuna ekler:

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

// Add otomatik olarak bir tanımlayıcı atar. Belirli bir GUID yalnızca gerektiğinde ayarlanır.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

`Add` yöntemi ayrıca XML'i bayt dizisi veya akış olarak da kabul eder; bu, XML içeriği zaten ikili biçimde mevcut olduğunda kullanışlıdır.

### **Bir Slayta veya Şekle Özel XML Parçası Ekleme**

Özel XML verisi, tüm sunum yerine belirli bir slayt veya şekle ilişkilendirilebilir. Bu, üst verinin yalnızca bir nesneyi (örneğin şablon anahtarı, dış kayıt kimliği veya bağlama bilgisi) tanımladığı durumlarda faydalıdır.

Aşağıdaki örnek bir slayta ve bir şekle ayrı ayrı özel XML parçaları ekler:

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

Bir parçanın eklendiği düzey, o parçanın ilişkilendirildiği nesnenin `CustomData.CustomXmlParts` koleksiyonunda yer almasını belirler. Sunum‑düzeyi veri belge‑geneli üst veriler için, slayt‑düzeyi veri belirli bir slayta ait bilgiler için, şekil‑düzeyi veri ise tek bir şekle bağlı üst veriler için uygundur.

### **Tüm Özel XML Parçalarını Listeleme ve Denetleme**

Tüm özel XML parçalarını almak için [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/allcustomxmlparts/) kullanın. Her [`ICustomXmlPart`](https://reference.aspose.com/slides/tr/net/aspose.slides/icustomxmlpart/) kimliğini, XML içeriğini ve ilgili ad alanı şemalarını ortaya koyar.

Aşağıdaki örnek, tüm özel XML parçalarını ve onların ad alanı şemalarını listeler:

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

[`ICustomXmlPart.NamespaceSchemas`](https://reference.aspose.com/slides/tr/net/aspose.slides/icustomxmlpart/namespaceschemas/) özel XML parçasına ilişkin XML şemalarını döndürür. Bu bilgi, dış sistemler tarafından üretilen XML içeren sunumların denetlenmesinde yararlı olabilir.

### **XML İçeriğini ve ItemId'yi Okuma ve Güncelleme**

XML ile UTF‑8 dizesi olarak çalışmak için [`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/tr/net/aspose.slides/icustomxmlpart/xmlasstring/), ham XML baytlarıyla çalışmak için ise [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/tr/net/aspose.slides/icustomxmlpart/xmldata/) kullanın. Her iki özellik de okunabilir ve güncellenebilir.

[`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/tr/net/aspose.slides/icustomxmlpart/itemid/) özelliği, özel XML parçasını Office Open XML belgesinde tanımlayan GUID'i tutar. Bir entegrasyon yeni bir kimlik gerektirdiğinde bu değer değiştirilebilir.

Aşağıdaki örnek, XML içeriğini ve kimliği günceller:

```csharp
using System;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlPart = presentation.AllCustomXmlParts[0];

// Read the current XML as text.
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

`XmlAsString` ya da `XmlData` atarken geçerli ve boş olmayan XML sağlayın. Uygulamanın esas olarak dize mi yoksa bayt verisi mi kullandığına bağlı olarak bir temsil seçin.

### **Bir Özel XML Parçasını Kaldırma**

Aspose.Slides, özel XML verisini kaldırmak için çeşitli yollar sunar:

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/tr/net/aspose.slides/icustomxmlpart/remove/) özel XML parçasını sunumdan siler.
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/tr/net/aspose.slides/icustomxmlpartcollection/remove/) belirli bir parçayı koleksiyondan siler.
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/tr/net/aspose.slides/icustomxmlpartcollection/removeat/) belirtilen indeksdeki parçayı siler.
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/tr/net/aspose.slides/icustomxmlpartcollection/clear/) bir koleksiyondaki tüm parçaları siler.

Aşağıdaki örnek, referans yoluyla bir sunum‑düzeyi özel XML parçasını kaldırır:

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

Elinizde bir `ICustomXmlPart` varsa ve onu belirli bir koleksiyona göre değil doğrudan sunumdan kaldırmak istiyorsanız `customXmlPart.Remove()` çağırın.

İndeks ile bir öğeyi kaldırmak da mümkündür:

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **Bir Koleksiyondaki Tüm Özel XML Parçalarını Temizleme**

Belirli bir sunum nesnesiyle ilişkili tüm özel XML parçaları kaldırılacaksa `Clear` kullanın.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

`Clear` yalnızca seçili koleksiyonu etkiler. Örneğin bir slaytın koleksiyonunu temizlemek, sunum‑düzeyi ya da şekil‑düzeyi koleksiyonlarını temizlemez.

Sunumdaki tüm özel XML parçalarını kaldırmak için `AllCustomXmlParts` üzerinden döngüyle her bir parçayı silin:

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

Office Open XML bir sunumunda aynı özel XML parçası birden çok sunum nesnesinden referans alınabilir. Örneğin, mevcut bir dosya birden çok slayt veya şekilden aynı temel özel XML parçasına ilişki içerebilir.

Paylaşılan bir parça, birden çok referansla tek bir veri nesnesi olarak ele alınmalıdır:

- `XmlAsString`, `XmlData` veya `ItemId` güncellemesi, temel XML parçasını değiştirir; değişiklik parçanın referans alındığı her yerde geçerli olur.
- `ItemId`, aynı özel XML parçasını nesne‑düzeyi koleksiyonlarını denetlerken tanımlamak için kullanılabilir.
- Belirli bir `CustomXmlParts` koleksiyonundan bir parçayı kaldırmak, sadece o koleksiyondan siler. Parçanın tamamen sunumdan kaldırılması gerektiğinde `ICustomXmlPart.Remove()` kullanın.
- Paylaşılan bir parçayı silmeden veya değiştirmeden önce, diğer slayt veya şekillerin hâlâ referans verip vermediğini belirlemek için nesne‑düzeyi koleksiyonları inceleyin.

`Add` aşırı yüklemeleri, XML içeriğinden yeni bir özel XML parçası oluşturur; mevcut bir `ICustomXmlPart` kabul etmez. Bu nedenle, paylaşılan ilişkiler genellikle parçaları zaten içeren sunumların yüklenmesi sırasında ortaya çıkar.

Aşağıdaki örnek, `ItemId` üzerinden sunum, slayt ve şekil‑düzeyi koleksiyonlarını denetler ve birden çok konumda referans verilen parçaları raporlar:

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

Bu denetim, dış sistemler tarafından oluşturulan sunumlarda özel XML verisini değiştirmeden veya silmeden önce faydalıdır; çünkü aynı üst veri parçası birden çok ilişkide bulunabilir.

## **Etiket Değerlerini Alma**

Slaytlarda bir etiket, `IDocumentProperties.Keywords` özelliğine karşılık gelir. Aşağıdaki örnek kod, Aspose.Slides for .NET kullanarak bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) için etiket değerinin nasıl alınacağını gösterir:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **Sunumlara Etiket Ekleme**

Aspose.Slides, sunumlara etiket eklemenizi sağlar. Bir etiket tipik olarak iki öğeden oluşur:

- bir özel özelliğin adı, örneğin `MyTag`;
- özel özelliğin değeri, örneğin `My Tag Value`.

Sunumları belirli bir kural veya özellik temelinde sınıflandırmanız gerekiyorsa, bu amaçla etiket ekleyebilirsiniz. Örneğin, Kuzey Amerika ülkelerinden gelen sunumları sınıflandırmak istiyorsanız, bir Kuzey Amerika etiketi oluşturup ilgili ülkeyi değer olarak atayabilirsiniz.

Aşağıdaki örnek kod, Aspose.Slides for .NET kullanarak bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) içine etiket eklemeyi gösterir:

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

Ya da tek bir [Shape](https://reference.aspose.com/slides/tr/net/aspose.slides/shape) için:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
shape.TextFrame.Text = "My text";
shape.CustomData.Tags["tag"] = "value";
```

### **Sınırlamalar**

`CustomData.Tags` koleksiyonu aracılığıyla eklenen etiketler yalnızca PowerPoint dosyasında saklanır. Sunum PDF'ye aktarıldığında bu etiketler PDF etiket yapısına **aktarılmaz**. Sonuç olarak, bir etiket olarak atanan özel tanımlayıcı PDF'den alınamaz.

**Çözüm**: Nesnenin **Alt Text** özelliğine (örneğin `shape.AlternativeText = "MyId"`) özel bir tanımlayıcı kaydedebilirsiniz. PDF'ye aktarıldıktan sonra Alt Text, PDF etiket yapısında görünebilir.

## **SSS**

**Bir sunum, slayt veya şekilden tüm etiketleri tek bir işlemle kaldırabilir miyim?**

Evet. [tag collection](https://reference.aspose.com/slides/tr/net/aspose.slides/tagcollection/) bir seferde tüm anahtar‑değer çiftlerini silen bir [Clear](https://reference.aspose.com/slides/tr/net/aspose.slides/tagcollection/clear/) işlemini destekler.

**Tüm koleksiyonu döngüye almadan yalnızca adıyla tek bir etiketi nasıl silerim?**

[TagCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/tagcollection/) üzerinde [Remove(name)](https://reference.aspose.com/slides/tr/net/aspose.slides/tagcollection/remove/) kullanarak etiketi anahtarına göre silin.

**Analiz veya filtreleme için etiket adlarının tam listesini nasıl alabilirim?**

[tag collection](https://reference.aspose.com/slides/tr/net/aspose.slides/tagcollection/) üzerinde [GetNamesOfTags](https://reference.aspose.com/slides/tr/net/aspose.slides/tagcollection/getnamesoftags/) kullanın; bu yöntem tüm etiket adlarını bir dizi olarak döndürür.

**Tüm özel XML parçalarını, nerede saklandıklarına bakılmaksızın nasıl bulabilirim?**

Sunumdaki tüm özel XML parçalarını almak için [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/allcustomxmlparts/) kullanın.

**Bir özel XML parçasını güncellemek için `XmlAsString` mi yoksa `XmlData` mı kullanmalıyım?**

Uygulama UTF‑8 XML metniyle çalışıyorsa `XmlAsString` kullanın. XML zaten bir bayt dizisi olarak mevcutsa ya da ikili‑odaklı işleme daha uygun ise `XmlData` kullanın. Her iki özellik de aynı özel XML parçasının içeriğini temsil eder.