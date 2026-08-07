---
title: JavaScript Kullanarak Sunumlarda Etiketler ve Özel Verileri Yönetme
linktitle: Etiketler ve Özel Veri
type: docs
weight: 300
url: /tr/nodejs-java/managing-tags-and-custom-data/
keywords:
- belge özellikleri
- etiket
- özel veri
- özel XML
- özel XML bölümü
- XML üst verisi
- ItemId
- etiket ekle
- çift değerler
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java ile PowerPoint sunumlarında etiketleri ve özel XML verilerini yönetmeyi, ekleme, okuma, güncelleme, denetleme ve özel XML bölümlerini kaldırmayı öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ın PowerPoint sunumlarında etiketler ve özel verilerle nasıl çalıştığını açıklar. Sunuma özgü veriler etiketler veya özel XML bölümleri olarak saklanabilir. Etiketler basit anahtar‑değer metin çiftleridir, özel XML bölümleri ise yapılandırılmış üst veri ve uygulamaya özgü XML yüklerini depolayabilir.

Aspose.Slides, sunum, slayt ve şekil seviyelerinde özel XML bölümlerini eklemek, okumak, güncellemek, denetlemek ve kaldırmak için API'ler sağlar. Özel XML bölümleri, belge‑yönetimi tanımlayıcıları, iş akışı durumu, uyumluluk üst verileri, şablon bağlama verileri veya sunum içinde bulunan diğer yapılandırılmış uygulama verileri gibi bilgileri saklayan entegrasyonlar için yararlıdır.

## **Sunum Dosyalarında Veri Depolama**

`.pptx` uzantılı PPTX dosyaları, Office Open XML spesifikasyonunun bir parçası olan PresentationML biçiminde depolanır. Office Open XML, sunum içeriği ve ilgili verileri saklamak için kullanılan paket yapısını ve ilişkileri tanımlar.

Bir sunum, ilişkilerle bağlanmış birden fazla bölüm içerir. Örneğin, bir slayt bölümü tek bir slaydın içeriğini taşır ve ISO/IEC 29500 tarafından tanımlanan diğer bölümlere açık ilişkileri olabilir.

Özel veriler etiketler ([TagCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tagcollection/)) veya özel XML bölümleri ([CustomXmlPartCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/customxmlpartcollection/)) olarak depolanabilir. Her ikisi de [`CustomData`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/customdata/) sınıfı aracılığıyla kullanılabilir.

{{% alert color="primary" %}}
Etiketler basit metin anahtar‑değer çiftlerini saklar. Özel XML bölümleri yapılandırılmış XML verisini saklar ve bir sunuma, slayta veya şekle ilişkilendirilebilir.
{{% /alert %}}

## **Özel XML Bölümleriyle Çalışma**

[`CustomData`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/customdata/) sınıfının `getCustomXmlParts()` yöntemi, belirli bir sunum nesnesiyle ilişkili özel XML bölümleri koleksiyonunu döndürür. Örneğin:

- `presentation.getCustomData().getCustomXmlParts()` sunuma ait özel XML bölümlerini içerir.
- `slide.getCustomData().getCustomXmlParts()` belirli bir slayta ait özel XML bölümlerini içerir.
- `shape.getCustomData().getCustomXmlParts()` belirli bir şekle ait özel XML bölümlerini içerir.

Sunumdaki tüm özel XML bölümlerini, bunların nerede ilişkili olduğuna bakılmaksızın incelemeniz gerektiğinde [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) metodunu kullanın.

### **Bir Sunuma Özel XML Bölümü Ekleme**

[`CustomXmlPartCollection`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/customxmlpartcollection/) sınıfının `add` metodunu kullanarak bir XML verisini özel XML bölümü koleksiyonuna ekleyebilirsiniz. XML geçerli ve boş olmamalıdır.

Aşağıdaki örnek, sunum‑seviyesindeki özel veri koleksiyonuna yapılandırılmış üst veri ekler:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' +
    '<metadata xmlns="urn:example:metadata">' +
        '<documentId>DOC-1001</documentId>' +
        '<workflowState>Draft</workflowState>' +
    '</metadata>';

const presentation = new aspose.slides.Presentation();
try {
    const customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add otomatik olarak bir tanımlayıcı atar. Belirli bir UUID yalnızca gerektiğinde ayarlanmalıdır.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("presentation_with_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`add` metodu ayrıca XML'i bayt dizisi olarak kabul edebilir; bu, XML içeriği zaten ikili biçimde mevcut olduğunda faydalıdır.

### **Bir Slayta veya Şekle Özel XML Bölümü Ekleme**

Özel XML verileri, tüm sunuma değil belirli bir slayta veya şekle ilişkilendirilebilir. Bu, üst verinin yalnızca bir nesneyi (örneğin bir şablon anahtarı, dış kayıt tanımlayıcısı veya bağlama bilgisi) tanımlaması gerektiğinde yararlıdır.

Aşağıdaki örnek, bir slayta bir ve bir şekle bir özel XML bölümü ekler:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        '<slideMetadata xmlns="urn:example:slides">' +
            '<templateKey>TitleSlide</templateKey>' +
        '</slideMetadata>');

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        '<shapeMetadata xmlns="urn:example:shapes">' +
            '<recordId>CRM-4281</recordId>' +
        '</shapeMetadata>');

    presentation.save("object_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bir bölümün eklendiği seviye, hangi nesnenin `getCustomData().getCustomXmlParts()` koleksiyonunun bu bölüme ilişkin ilişkiyi içerdiğini belirler. Sunum‑seviyesindeki veri belge genelinde üst veri için, slayt‑seviyesindeki veri belirli bir slayta ait bilgi için, şekil‑seviyesindeki veri ise tek bir şekle bağlı üst veri için uygundur.

### **Tüm Özel XML Bölümlerini Listeleme ve Denetleme**

Bir sunumdan tüm özel XML bölümlerini almak için [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) metodunu kullanın. Her [`CustomXmlPart`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/customxmlpart/) kimliğini, XML içeriğini ve ilişkili ad alanı şemalarını ortaya koyar.

Aşağıdaki örnek, tüm özel XML bölümlerini ve bunların ad alanı şemalarını listeler:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        const customXmlPart = customXmlParts[partIndex];

        console.log("ItemId: " + customXmlPart.getItemId());
        console.log("XML:");
        console.log(customXmlPart.getXmlAsString());

        const namespaceSchemas = customXmlPart.getNamespaceSchemas();
        for (let schemaIndex = 0; schemaIndex < namespaceSchemas.length; schemaIndex++) {
            console.log("Namespace schema: " + namespaceSchemas[schemaIndex]);
        }

        console.log();
    }
} finally {
    presentation.dispose();
}
```

[`CustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/customxmlpart/) yöntemi, özel XML bölümüyle ilişkilendirilmiş XML şemalarını döndürür. Bu bilgi, harici sistemler tarafından üretilen XML içeren sunumları denetlerken kullanışlıdır.

### **XML İçeriğini ve ItemId'yi Okuma ve Güncelleme**

[`CustomXmlPart`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/customxmlpart/) üzerinden `getXmlAsString()` ve `setXmlAsString()` yöntemleriyle XML'i UTF‑8 metin olarak, `getXmlData()` ve `setXmlData()` yöntemleriyle ise ham XML baytları olarak işleyebilirsiniz.

`getItemId()` yöntemi, Office Open XML belgesindeki özel XML bölümünü tanımlayan UUID'yi döndürür. Entegrasyon yeni bir tanımlayıcı gerektirdiğinde `setItemId()` kullanılabilir.

Aşağıdaki örnek, XML içeriğini ve tanımlayıcıyı günceller:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Mevcut XML'i metin olarak okuyun.
    const currentXmlContent = customXmlPart.getXmlAsString();
    console.log(currentXmlContent);

    // XML'i UTF-8 dizesi olarak güncelleyin.
    customXmlPart.setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' +
            '<documentId>DOC-1001</documentId>' +
            '<workflowState>Approved</workflowState>' +
        '</metadata>');

    // getXmlData, aynı XML içeriğini ham bayt olarak sağlar.
    const customXmlData = customXmlPart.getXmlData();
    console.log(Buffer.from(customXmlData).toString("utf8"));

    // Entegrasyon tarafından gerektiğinde tanımlayıcıyı değiştirin.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("updated_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`setXmlAsString` veya `setXmlData` çağrılırken geçerli ve boş olmayan XML sağlandığından emin olun. Uygulamanın öncelikli olarak metinle mi yoksa bayt verisiyle mi çalıştığına bağlı olarak bir temsil kullanılabilir.

### **Bir Özel XML Bölümünü Kaldırma**

Aspose.Slides, özel XML verilerini kaldırmak için birkaç yol sunar:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/customxmlpart/) özel XML bölümünü sunumdan kaldırır.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/customxmlpartcollection/) belirli bir bölümü koleksiyondan kaldırır.
- [`CustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/customxmlpartcollection/) belirtilen indeksdeki bölümü kaldırır.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/customxmlpartcollection/) belirli bir koleksiyondaki tüm bölümleri kaldırır.

Aşağıdaki örnek, referans üzerinden bir sunum‑seviyesindeki özel XML bölümünü kaldırır:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        const customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Elinizde bir `CustomXmlPart` nesnesi varsa ve bu bölümü belirli bir koleksiyondan değil doğrudan sunumdan kaldırmak istiyorsanız `customXmlPart.remove()` metodunu çağırın.

İndeks üzerinden bir öğe de kaldırılabilir:

```javascript
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Bir Koleksiyondaki Tüm Özel XML Bölümlerini Temizleme**

Belirli bir sunum nesnesine ilişkin tüm özel XML bölümlerinin kaldırılması gerektiğinde `clear` metodunu kullanın.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` yalnızca seçilen koleksiyonu etkiler. Örneğin, bir slaydın koleksiyonunu temizlemek, sunum‑seviyesi veya şekil‑seviyesi koleksiyonlarını temizlemez.

Sunumdaki her özel XML bölümünü kaldırmak için `getAllCustomXmlParts()` üzerinden döngüyle geçip her bölümü kaldırabilirsiniz:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        customXmlParts[partIndex].remove();
    }

    presentation.save("all_custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Bağlı veya Paylaşılan Özel XML Bölümlerini Yönetme**

Office Open XML bir sunumunda aynı özel XML bölümü birden fazla nesne tarafından referans alınabilir. Örneğin, mevcut bir dosyada aynı temel özel XML bölümüne birden çok slayt veya şekil ilişkilendirilmiş olabilir.

Paylaşılan bir bölüm, birden çok referansa sahip tek bir veri nesnesi gibi ele alınmalıdır:

- `setXmlAsString`, `setXmlData` veya `setItemId` ile yapılan güncellemeler temel özel XML bölümünü değiştirir; bu değişiklik, bölümün referans alındığı her yerde geçerli olur.
- `getItemId()` aynı özel XML bölümünü nesne‑seviyesi koleksiyonlarını denetlerken tanımlamak için kullanılabilir.
- Belirli bir `getCustomXmlParts()` koleksiyonundan bir bölümü kaldırmak, sadece o koleksiyondan siler. Bölümün kendisinin sunumdan tamamen kaldırılması gerektiğinde `CustomXmlPart.remove()` kullanılmalıdır.
- Paylaşılan bir bölümü silmeden veya değiştirmeden önce, diğer slayt veya şekillerin hâlâ ona referans verip vermediğini belirlemek için nesne‑seviyesi koleksiyonları inceleyin.

`add` aşırı yüklemeleri, XML içeriğinden yeni bir özel XML bölümü oluşturur; mevcut bir `CustomXmlPart` kabul etmez. Bu nedenle, paylaşılan ilişkiler genellikle zaten bu bölümleri içeren sunumlar yüklendiğinde ortaya çıkar.

Aşağıdaki örnek, `ItemId` üzerinden sunum‑, slayt‑ ve şekil‑seviyesi koleksiyonları denetler ve birden fazla konumda referans verilen bölümleri raporlar:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const referencesByItemId = new Map();

    const registerCustomXmlParts = (ownerName, customXmlParts) => {
        for (let partIndex = 0; partIndex < customXmlParts.size(); partIndex++) {
            const customXmlPart = customXmlParts.get_Item(partIndex);
            const itemId = customXmlPart.getItemId().toString();

            if (!referencesByItemId.has(itemId)) {
                referencesByItemId.set(itemId, []);
            }

            referencesByItemId.get(itemId).push(ownerName);
        }
    };

    registerCustomXmlParts("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        registerCustomXmlParts("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);

            registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (const [itemId, owners] of referencesByItemId) {
        if (owners.length > 1) {
            console.log("Shared custom XML part: " + itemId);

            for (const ownerName of owners) {
                console.log("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Bu tür bir denetim, dış sistemler tarafından oluşturulmuş sunumlarda özel XML verileri değiştirilmeden veya silinmeden önce faydalıdır; çünkü aynı üst veri bölümü birden fazla ilişki içinde bulunabilir.

## **Etiket Değerlerini Alma**

Slaytlarda bir etiket, `DocumentProperties.getKeywords()` metoduna karşılık gelir. Bu örnek kod, Aspose.Slides for Node.js via Java kullanarak bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) üzerindeki etiket değerini nasıl alacağınızı gösterir:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Sunumlara Etiket Ekleme**

Aspose.Slides, sunumlara etiket eklemenizi sağlar. Bir etiket genellikle iki öğeden oluşur:

- özel bir özelliğin adı, örneğin `MyTag`;
- özel özelliğin değeri, örneğin `My Tag Value`.

Sunumları belirli bir kural veya özellik temelinde sınıflandırmanız gerektiğinde bu amaçla etiket ekleyebilirsiniz. Örneğin, Kuzey Amerika ülkelerinden gelen sunumları sınıflandırmak isterseniz bir “North American” etiketi oluşturup ilgili ülkeyi değer olarak atayabilirsiniz.

Bu örnek kod, Aspose.Slides for Node.js via Java kullanarak bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) üzerine etiket eklemeyi gösterir:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

Etiketler bir [Slide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/) için de ayarlanabilir:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

Veya bireysel bir [Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) için:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);

    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **Sınırlamalar**

`getCustomData().getTags()` koleksiyonu aracılığıyla eklenen etiketler yalnızca PowerPoint dosyasında depolanır. Sunum PDF’ye dışa aktarıldığında bu etiket yapısı PDF etiketlerine **aktarılmaz**. Bu nedenle, bir etiket olarak atanmış özel tanımlayıcı PDF’den alınamaz.

**Geçici çözüm**: Özel tanımlayıcıyı nesnenin **Alt Text** (örneğin `shape.setAlternativeText("MyId")`) içinde saklayabilirsiniz. PDF’ye dışa aktarıldıktan sonra Alt Text PDF etiket yapısında görünebilir.

## **SSS**

**Bir sunum, slayt veya şekilden tüm etiketleri tek bir işlemle kaldırabilir miyim?**

Evet. [Etiket koleksiyonu](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tagcollection/) bir [clear](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tagcollection/) işlemini destekler ve tüm anahtar‑değer çiftlerini bir kerede siler.

**Bir etiketi, koleksiyonu döngüyle gezmeden, yalnızca adını kullanarak nasıl silebilirim?**

Etiket koleksiyonunda `remove(name)` metodunu kullanarak etiketi anahtarıyla silebilirsiniz.

**Analitik veya filtreleme amaçlı tüm etiket adlarının tam listesini nasıl alabilirim?**

Etiket koleksiyonunda `getNamesOfTags()` metodunu kullanın; bu, tüm etiket adlarını içeren bir dizi döndürür.

**Tüm özel XML bölümlerini, nerede saklandıklarına bakılmaksızın nasıl bulabilirim?**

Sunumdaki tüm özel XML bölümlerini almak için [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) metodunu kullanın.

**Bir özel XML bölümünü güncellerken `getXmlAsString`/`setXmlAsString` mı yoksa `getXmlData`/`setXmlData` mı kullanılmalı?**

Uygulama UTF‑8 XML metniyle çalışıyorsa `getXmlAsString` ve `setXmlAsString` kullanın. XML zaten bir bayt dizisi olarak mevcutsa veya ikili‑yönelimli işlem daha uygun ise `getXmlData` ve `setXmlData` kullanın. Her iki temsil de aynı özel XML bölümünün içeriğine işaret eder.